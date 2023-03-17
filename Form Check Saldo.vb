Imports System.Security.Cryptography
Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win

Imports NPOI.HSSF.UserModel
Imports NPOI.HPSF
Imports NPOI.POIFS.FileSystem
Imports System.IO
Imports C1.Win.C1FlexGrid

Public Class Form_Check_Saldo
  Dim retCode, Protocol, hContext, hCard, ReaderCount As Integer
  Dim RdrState As SCARD_READERSTATE
  Dim sReaderList As String
  Dim sReaderGroup As String
  Dim sReaderAuthFailedMessage As String = "Read authentication keys failed!"
  Dim SendLen, RecvLen As Integer
  Dim ReaderLen, ATRLen As Integer
  Dim dwState, dwActProtocol As Long
  Dim ATRVal(256) As Byte
  Dim SendBuff(262), RecvBuff(262) As Byte
  Public pioSendRequest, pioRecvRequest As SCARD_IO_REQUEST

  Dim VRFID_IsProceed As Boolean
  Dim VRFID_LastDataDetect As String
  Dim VBringToUID As String
  Dim VDataKartu As String
  Dim CollectionchkSaldo As New Collection
  Dim checkArry As ArrayList

  Private Function ACR120U_GetInfo() As String
    Dim NewFormRFID As New frmReadCard
    'Dim wrapper As New Simple3Des("password")
    'Try
    VRFID_Msg = "GET_INFO|?-"
    NewFormRFID.ShowDialog(Me)
    'NewFormRFID = Nothing
    'VInfo = wrapper.DecryptData(VRFID_Msg)

    'Catch ex As System.Security.Cryptography.CryptographicException
    '  VInfo = "Data dalam kartu ini bukan dari kartu Primeresto"
    'End Try
    Return VRFID_Msg
  End Function

  Private Function ACR120U_WriteInfo(ByVal DataToWrite As String) As String
    Dim NewFormRFID As New frmReadCard

    VRFID_Msg = "SET_INFO|?" & DataToWrite & "|?"
    NewFormRFID.ShowDialog(Me)
    NewFormRFID = Nothing

    Return VRFID_Msg
  End Function

  Public Function RFID_HardwareID() As String
    Dim VHwId As String = ""
    Dim ReaderCount As Integer
    Dim ctr As Integer

    For ctr = 0 To 255
      sReaderList = sReaderList + vbNullChar
    Next

    ReaderCount = 255

    ' 1. Establish context and obtain hContext handle
    retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, hContext)
    If retCode <> ModWinsCard.SCARD_S_SUCCESS Then GoTo err_RFID_HardwareID

    ' 2. List PC/SC card readers installed in the system
    retCode = ModWinsCard.SCardListReaders(hContext, "", sReaderList, ReaderCount)
    If retCode <> ModWinsCard.SCARD_S_SUCCESS Then GoTo err_RFID_HardwareID

    If Trim(sReaderList) <> "" Then VHwId = Trim(sReaderList)

err_RFID_HardwareID:
    Return VHwId
  End Function

  Private Function RFID120U_IsCardConnect() As Boolean
    'On Error GoTo Err_RFID120U_ReadCard
    Dim VTempB As Boolean = False
    Dim VHwID As String = RFID_HardwareID()
    If VHwID = "" Then
      TmrNFC.Enabled = False
      ShowMessage(Me, "Scanner RFID tidak ditemukan", True)
      Me.Close()
      'GoTo Err_RFID120U_ReadCard
    End If
    If RFID_HardwareID() = "" Then
      TmrNFC.Enabled = False
      ShowMessage(Me, "Scanner RFID tidak ditemukan", True)
      Me.Close()
    End If

    'DisconnectCard
    retCode = ModWinsCard.SCardDisconnect(hCard, ModWinsCard.SCARD_UNPOWER_CARD)
    'ConnectCard
    'retCode = ModWinsCard.SCardConnect(hContext, sReaderList, ModWinsCard.SCARD_SHARE_SHARED, ModWinsCard.SCARD_PROTOCOL_T0 Or ModWinsCard.SCARD_PROTOCOL_T1, hCard, Protocol)
    retCode = ModWinsCard.SCardConnect(hContext, VHwID, ModWinsCard.SCARD_SHARE_SHARED, ModWinsCard.SCARD_PROTOCOL_T0 Or ModWinsCard.SCARD_PROTOCOL_T1, hCard, Protocol)
    If retCode = ModWinsCard.SCARD_S_SUCCESS Then VTempB = True
    'Err_RFID120U_ReadCard:
    Return VTempB
  End Function

  Private Function getAuthentication(ByVal blockNumber As String) As Boolean
    Dim indx As Integer
    Dim tmpStr As String = ""
    Call ClearBuffers()
    'Authentication command
    SendBuff(0) = &HFF                          'Class
    SendBuff(1) = &H86                          'INS
    SendBuff(2) = &H0                           'P1
    SendBuff(3) = &H0                           'P2
    SendBuff(4) = &H5                           'Lc
    SendBuff(5) = &H1                           'Byte 1 : Version number
    SendBuff(6) = &H0                           'Byte 2
    SendBuff(7) = CInt(blockNumber)          'Byte 3 : Block number
    SendBuff(8) = &H60                      'Byte 4 : Key Type A        

    SendBuff(9) = CInt("&H" & "00") 'Byte 5 : Key number

    SendLen = 10
    RecvLen = 2

    retCode = SendAPDU()
    If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
      'ShowMessage(Me, "Read authentication keys failed!", True)
      'LblInfoKartu.Text = sReaderAuthFailedMessage
      Exit Function
    Else
      For indx = 0 To RecvLen - 1

        'tmpStr = tmpStr & Right$("00" & Hex(RecvBuff(index)), 2)
        tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "

      Next indx

      'Checking for response
      If tmpStr.Trim = "90 00" Then
        Return True
      Else
        'ShowMessage(Me, "Read authentication keys failed!", True)
        'LblInfoKartu.Text = sReaderAuthFailedMessage
      End If
    End If

  End Function

  Private Sub ClearBuffers()
    Dim indx As Long
    For indx = 0 To 262
      RecvBuff(indx) = &H0
      SendBuff(indx) = &H0
    Next indx
  End Sub

  Public Function SendAPDU()

    Dim indx As Integer
    Dim tmpStr As String

    pioSendRequest.dwProtocol = Protocol
    pioSendRequest.cbPciLength = Len(pioSendRequest)

    tmpStr = ""

    For indx = 0 To SendLen - 1

      tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(SendBuff(indx)), 2) + " "

    Next indx

    retCode = ModWinsCard.SCardTransmit(hCard, pioSendRequest, SendBuff(0), SendLen, pioSendRequest, RecvBuff(0), RecvLen)

    If retCode <> ModWinsCard.SCARD_S_SUCCESS Then

      SendAPDU = retCode
      Exit Function
    End If

    tmpStr = ""

    For indx = 0 To RecvLen - 1

      tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "

    Next indx

    SendAPDU = retCode

  End Function

  Private Function LoadKey() As Boolean
    Dim tmpStr As String = Nothing
    Call ClearBuffers()
    'Load Authentication Keys command
    SendBuff(0) = &HFF                          'Class
    SendBuff(1) = &H82                          'INS
    SendBuff(2) = &H0                           'P1 : Key Structure
    SendBuff(3) = CLng("&H" + "00")     'P2 : Key Number
    SendBuff(4) = &H6                           'P3 : Lc
    SendBuff(5) = CLng("&H" + "FF")       'Key 1
    SendBuff(6) = CLng("&H" + "FF")       'Key 2
    SendBuff(7) = CLng("&H" + "FF")       'Key 3
    SendBuff(8) = CLng("&H" + "FF")       'Key 4
    SendBuff(9) = CLng("&H" + "FF")       'Key 5
    SendBuff(10) = CLng("&H" + "FF")      'Key 6

    SendLen = 11
    RecvLen = 2

    retCode = SendAPDU()
    If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
      ShowMessage(Me, "Load authentication keys error!", True)
      Exit Function
    Else
      For indx = RecvLen - 2 To RecvLen - 1
        tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "
      Next indx
      'Check for response
      If tmpStr.Trim <> "90 00" Then
        ShowMessage(Me, "Load authentication keys error!", True)
      Else
        Return True
      End If
    End If
  End Function

  Private Function readCard(ByVal blockNum As String) As String
    Dim tmpStr As String = Nothing
    Dim indx As Integer = 0
    Call ClearBuffers()
    'Read Binary Block command
    SendBuff(0) = &HFF                              'Class
    SendBuff(1) = &HB0                              'INS
    SendBuff(2) = &H0                               'P1
    SendBuff(3) = blockNum 'P2 : Block number
    SendBuff(4) = CInt(16)                  'Le : Number of bytes to read

    SendLen = 5
    RecvLen = CInt(16) + 2

    retCode = SendAPDU()
    If retCode <> ModWinsCard.SCARD_S_SUCCESS Then
      Return Nothing
    Else
      For indx = RecvLen - 2 To RecvLen - 1
        'tmpStr = tmpStr & Right$("00" & Hex(RecvBuff(index)), 2)
        tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "

      Next indx

      'Check for response
      If tmpStr.Trim = "90 00" Then
        tmpStr = ""
        For indx = 0 To RecvLen - 3

          'tmpstr = tempstr & Right$(Chr(RecvBuff(index)), 2)
          tmpStr = tmpStr + Chr(RecvBuff(indx))
          'tmpStr = tmpStr + Microsoft.VisualBasic.Right("00" & Hex(RecvBuff(indx)), 2) + " "

        Next indx

        Return tmpStr
      Else
        Return Nothing
      End If
    End If
  End Function

  Private Sub TmrNFC_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrNFC.Tick
    Dim VRFIDData() As String
    Dim VTempS As String
    Dim TMPRecord As FbDataReader
    Dim TMPRecord1 As FbDataReader

    TmrNFC.Enabled = False
    'If TempCardno.Text = "" Then
    If RFID_HardwareID() <> "" Then

      If RFID120U_IsCardConnect() = True Then
        If TempCardScnd.Text = "" Then
          'TmrNFC.Enabled = False
          VTempS = ACR120U_GetInfo()
          If VTempS.Length > 3 Then
            If InStr(1, VTempS, "||PRIMECARD", CompareMethod.Text) > 1 Then
              VRFIDData = Split(VTempS, "||")
              If TempCardno.Text <> VRFIDData(1) Then
                lblSaldo.Text = FormatNumber(VRFIDData(0), 0)
                VTempS = "Nama : " & VRFIDData(2) & " [" & VRFIDData(1) & "]"
                VTempS = VTempS & vbNewLine & "Tgl Registrasi : " & FormatDateTime(VRFIDData(3), DateFormat.LongDate)
                VTempS = VTempS & vbNewLine & "Berlaku s/d : " & FormatDateTime(VRFIDData(4), DateFormat.LongDate)
                LblInfoKartu.Text = VTempS
                TempCardno.Text = VRFIDData(1)
                TMPRecord1 = MyDatabase.MyReader("SELECT COUNT(PB.PBTRANSMBTRANSUID) AS Jumlah FROM CUST CT LEFT OUTER JOIN PBTRANSDT PBD ON CT.CUSTNO = PBD.VISAORCHEQUENUMBER LEFT OUTER JOIN PBTRANS PB ON PBD.PBTRANSUID = PB.PBTRANSUID LEFT OUTER JOIN MBTRANS MB ON PB.PBTRANSMBTRANSUID = MB.MBTRANSUID LEFT OUTER JOIN MBTRANSDT MBD ON MB.MBTRANSUID = MBD.MBTRANSUID LEFT OUTER JOIN PAYMENTTYPE PT ON PBD.PAYMENTTYPEUID = PT.PAYMENTTYPEUID WHERE CT.CUSTNO = '" & VRFIDData(1) & "' AND PBD.MODIFIEDDATETIME BETWEEN '" & ConvertDate1.Text & ", 00:00:00' AND '" & ConvertDate1.Text & ", 23:59:59'")
                TMPRecord1.Read()
                TempCardScnd.Text = TMPRecord1.Item("Jumlah")
                If CInt(TMPRecord1.Item("Jumlah")) <> 0 Then
                  BTNPrint.Enabled = True
                Else
                  BTNPrint.Enabled = False
                End If
                Call CleargrD()
                'TMPRecord = MyDatabase.MyReader("SELECT MBD.MBTRANSDTITEMNAME AS MENUNAME, MBD.MBTRANSDTITEMQTY AS Qty, (MBD.MBTRANSDTSUBVAL-MBD.MBTRANSDTITEMDISCVAL1) AS SubTotal, PBD.MODIFIEDDATETIME AS DT FROM CUST CT LEFT OUTER JOIN PBTRANSDT PBD ON CT.CUSTNO = PBD.VISAORCHEQUENUMBER LEFT OUTER JOIN PBTRANS PB ON PBD.PBTRANSUID = PB.PBTRANSUID LEFT OUTER JOIN MBTRANS MB ON PB.PBTRANSMBTRANSUID = MB.MBTRANSUID LEFT OUTER JOIN MBTRANSDT MBD ON MB.MBTRANSUID = MBD.MBTRANSUID WHERE CT.CUSTNO = '" & VRFIDData(1) & "' AND PBD.MODIFIEDDATETIME BETWEEN '" & ConvertDate1.Text & ", 00:00:00' AND '" & ConvertDate1.Text & ", 23:59:59' ORDER BY PBD.MODIFIEDDATETIME")
                TMPRecord = MyDatabase.MyReader("SELECT  PB.PBTRANSNO AS PBUID, PB.PBTRANSMBTRANSUID AS PAYUID, MBD.MBTRANSDTITEMNAME AS MENUNAME,SUM(MBD.MBTRANSDTITEMQTY) AS Qty,SUM(MBD.MBTRANSDTSUBVAL-MBD.MBTRANSDTITEMDISCVAL1) AS SubTotal FROM CUST CT LEFT OUTER JOIN PBTRANSDT PBD ON CT.CUSTNO = PBD.VISAORCHEQUENUMBER LEFT OUTER JOIN PBTRANS PB ON PBD.PBTRANSUID = PB.PBTRANSUID LEFT OUTER JOIN MBTRANS MB ON PB.PBTRANSMBTRANSUID = MB.MBTRANSUID LEFT OUTER JOIN MBTRANSDT MBD ON MB.MBTRANSUID = MBD.MBTRANSUID LEFT OUTER JOIN PAYMENTTYPE PT ON PBD.PAYMENTTYPEUID = PT.PAYMENTTYPEUID WHERE CT.CUSTNO = '" & VRFIDData(1) & "' AND PBD.MODIFIEDDATETIME BETWEEN '" & ConvertDate1.Text & ", 00:00:00' AND '" & ConvertDate1.Text & ", 23:59:59' GROUP BY PB.PBTRANSNO, PB.PBTRANSMBTRANSUID, MBD.MBTRANSDTITEMNAME")
                With DetailPurchase

                  While TMPRecord.Read()
                    .AddItem("(Choose to be Printing) " & TMPRecord.Item("PBUID") & vbTab & TMPRecord.Item("PAYUID") & vbTab & TMPRecord.Item("MENUNAME") & vbTab & TMPRecord.Item("Qty") & vbTab & TMPRecord.Item("SubTotal"))
                    '.AddItem(TMPRecord.Item("MENUNAME") & vbTab & TMPRecord.Item("Qty") & vbTab & TMPRecord.Item("SubTotal") & vbTab & TMPRecord.Item("DT"))
                  End While : MyDatabase.ConnectionDatabase.Close()
                End With
                DetailPurchase.AllowMerging = AllowMergingEnum.RestrictCols


                Dim i%
                For i = DetailPurchase.Cols.Fixed To DetailPurchase.Cols.Count - 1
                  DetailPurchase.Cols(i).AllowMerging = True
                Next
              End If
            End If

          Else
            ShowMessage(Me, "Bukan Kartu e-Payment Primeresto", True)
          End If

        End If
        'End If

      Else
        'Call ResetInputForm()
        'TmrNFC.Enabled = True
        TempCardScnd.Text = ""
      End If

      TmrNFC.Enabled = True

    End If
    'End If
    
    
  End Sub
  Private Sub ResetInputForm()
    LblInfoKartu.Text = ""
    Call CleargrD()
    lblSaldo.Text = ""
    TempCardno.Text = ""

  End Sub
  Private Sub CleargrD()
    With DetailPurchase
      For i As Integer = 1 To .Rows.Count - 1
        .Rows.Remove(.Row)
      Next
    End With
  End Sub
  Private Sub Form_Check_Saldo_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    LblInfoKartu.Text = ""
    Call CleargrD()
    lblSaldo.Text = ""
    Label2.Text = DateTime.Now.ToString("dd MMMM yyyy")
    Label1.Text = DateTime.Now.ToString("dd MMMM yyyy")
    ConvertDate1.Text = DateTime.Now.ToString("dd.MM.yyyy")
    ConvertDate2.Text = DateTime.Now.ToString("dd.MM.yyyy")

    
  End Sub
  Public Sub Tamp()
    Dim TMPRecord As FbDataReader
    TMPRecord = MyDatabase.MyReader("SELECT  PB.PBTRANSNO AS PBUID, PB.PBTRANSMBTRANSUID AS PAYUID, MBD.MBTRANSDTITEMNAME AS MENUNAME,SUM(MBD.MBTRANSDTITEMQTY) AS Qty,SUM(MBD.MBTRANSDTSUBVAL-MBD.MBTRANSDTITEMDISCVAL1) AS SubTotal FROM CUST CT LEFT OUTER JOIN PBTRANSDT PBD ON CT.CUSTNO = PBD.VISAORCHEQUENUMBER LEFT OUTER JOIN PBTRANS PB ON PBD.PBTRANSUID = PB.PBTRANSUID LEFT OUTER JOIN MBTRANS MB ON PB.PBTRANSMBTRANSUID = MB.MBTRANSUID LEFT OUTER JOIN MBTRANSDT MBD ON MB.MBTRANSUID = MBD.MBTRANSUID LEFT OUTER JOIN PAYMENTTYPE PT ON PBD.PAYMENTTYPEUID = PT.PAYMENTTYPEUID WHERE CT.CUSTNO = 'CST-00001' AND PBD.MODIFIEDDATETIME BETWEEN '13.01.2017, 00:00:00' AND '13.01.2017, 23:59:59' GROUP BY PB.PBTRANSNO, PB.PBTRANSMBTRANSUID, MBD.MBTRANSDTITEMNAME")
    
    With DetailPurchase
      
      While TMPRecord.Read()
        '.AddItem("(Choose to be Printing) " & TMPRecord.Item("PBUID") & vbTab & TMPRecord.Item("MENUNAME") & vbTab & TMPRecord.Item("Qty") & vbTab & TMPRecord.Item("SubTotal") & vbTab & TMPRecord.Item("PAYUID"))
        .AddItem("(Choose to be Printing) " & TMPRecord.Item("PBUID") & vbTab & TMPRecord.Item("PAYUID") & vbTab & TMPRecord.Item("MENUNAME") & vbTab & TMPRecord.Item("Qty") & vbTab & TMPRecord.Item("SubTotal"))
      End While : MyDatabase.ConnectionDatabase.Close()
      
    End With

    DetailPurchase.AllowMerging = AllowMergingEnum.RestrictCols


    Dim i%
    For i = DetailPurchase.Cols.Fixed To DetailPurchase.Cols.Count - 1
      DetailPurchase.Cols(i).AllowMerging = True
    Next
  End Sub
  Private Sub btnVirtualFromDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVirtualFromDate.Click
    Dim VirtualDate As New Form_Virtual_Date
    VirtualDate.Name = "Form_Virtual_Date"
    VirtualDate.Text = "Please Select Date"
    VirtualDate.ParentOBJForm = Me
    VirtualDate.publicChosenDate = dtFromDate.Value
    VirtualDate.ShowDialog()

    dtFromDate.Text = VirtualDate.publicChosenDate
    Label1.Text = Format(dtFromDate.Value, "dd MMMM yyyy")

    ConvertDate1.Text = Format(dtFromDate.Value, "dd.MM.yyyy")
  End Sub


  Private Sub btnVirtualFromDate1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnVirtualFromDate1.Click
    Dim VirtualDate As New Form_Virtual_Date
    VirtualDate.Name = "Form_Virtual_Date"
    VirtualDate.Text = "Please Select Date"
    VirtualDate.ParentOBJForm = Me
    VirtualDate.publicChosenDate = dtEndDate.Value
    VirtualDate.ShowDialog()

    dtEndDate.Text = VirtualDate.publicChosenDate
    Label2.Text = Format(dtEndDate.Value, "dd MMMM yyyy")
    'Label5.Text = Format(dtFromDate.Value, "dd/MM/yyyy")
    ConvertDate2.Text = Format(dtEndDate.Value, "dd.MM.yyyy")
  End Sub

  Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancel.Click
    Me.Close()

  End Sub
  Private Sub Cetak1()

    Dim ListTampung As List(Of String) = New List(Of String)

    With DetailPurchase
      For tUi As Integer = 1 To DetailPurchase.Rows.Count - 1
        If Mid(.Item(tUi, 0), 1, 24) = "(Choose to be Printing) " Then
         
          ListTampung.Add(.Item(tUi, 1).ToString())
        End If
      Next
      Dim haPusKembar As List(Of String) = ListTampung.Distinct().ToList
      For Each tBpBUid As String In haPusKembar

        Call Cetak(True, tBpBUid)
      Next
    End With
  End Sub
  Private Sub Cetak(Optional ByVal Nota As Boolean = False, Optional ByVal uiy As String = "")
    Dim OBJNew As New Form_Print_Preview
    Dim Query As String = Nothing
   

    publicPaymentChange = "-1.0"
    publicPaymentRest = "-1.0"

    
    Make_Bill_Payment.TransactionUID = uiy

    Query = "SELECT * FROM POSPREF "

    OBJNew.Name = "Form_Print_Preview"
    OBJNew.RPTTitle = "View Purchase Detail"

    OBJNew.RPTDocument = New Make_Bill_Payment
    OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
    OBJNew.VersiNota = Nota
    OBJNew.ShowDialog()
    
  End Sub
  Private Sub BTNPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPrint.Click

    Call Cetak1()
    Call ResetInputForm()
  End Sub

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
    Call Tamp()


  End Sub

  Private Sub DetailPurchase_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DetailPurchase.Click
    Dim getVals As String = ""
    With DetailPurchase

     
      getVals = .Item(.Row, 0)
      If Mid(.Item(.Row, 0), 1, 24) <> "(Choose to be Printing) " Then

        For uii As Integer = 1 To DetailPurchase.Rows.Count - 1
          If .Item(uii, 0).ToString() = getVals Then
            DetailPurchase.Item(uii, 0) = "(Choose to be Printing) " & DetailPurchase.Item(uii, 0)
          End If
        Next
      Else
        For uii As Integer = 1 To DetailPurchase.Rows.Count - 1
          If .Item(uii, 0).ToString() = getVals Then

            .Item(uii, 0) = Replace(.Item(uii, 0), "(Choose to be Printing) ", Nothing)
          End If
        Next
        
      End If

    End With

  End Sub

  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    Dim ListTampung As List(Of String) = New List(Of String)

    With DetailPurchase
      For tUi As Integer = 1 To DetailPurchase.Rows.Count - 1
        If Mid(.Item(tUi, 0), 1, 24) = "(Choose to be Printing) " Then
          
          ListTampung.Add(.Item(tUi, 4).ToString())
        End If
      Next
      Dim haPusKembar As List(Of String) = ListTampung.Distinct().ToList
      For Each tBpBUid As String In haPusKembar
        MessageBox.Show(tBpBUid)
      Next
    End With
  End Sub
End Class