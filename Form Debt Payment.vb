Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win

Imports NPOI.HSSF.UserModel
Imports NPOI.HPSF
Imports NPOI.POIFS.FileSystem
Imports System.IO

Public Class Form_Debt_Payment
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


  Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
  Dim strConn2 As String = Nothing
  Dim VRFID_Saldo As Double = 0
  Dim VRFID_IsProceed As Boolean
  Dim VRFID_LastDataDetect As String
  Dim VBringToUID As String
  Dim VDataKartu As String
  Dim VNFC_ErrorCode As String = ""

#Region "NFC Func"
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
    VNFC_ErrorCode = ""
    ' 1. Establish context and obtain hContext handle
    retCode = ModWinsCard.SCardEstablishContext(ModWinsCard.SCARD_SCOPE_USER, 0, 0, hContext)
    VNFC_ErrorCode = "Establish context and obtain hContext handle (retCode=" & retCode & ")"
    If retCode <> ModWinsCard.SCARD_S_SUCCESS Then GoTo err_RFID_HardwareID

    ' 2. List PC/SC card readers installed in the system
    retCode = ModWinsCard.SCardListReaders(hContext, "", sReaderList, ReaderCount)
    VNFC_ErrorCode = "List PC/SC card readers installed in the system (retCode=" & retCode & ")"
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
      TmrLoadRFID.Enabled = False
      'ShowMessage(Me, "Scanner RFID tidak ditemukan", True)
      ShowMessage(Me, "Scanner NFC tidak ditemukan" & vbNewLine & VNFC_ErrorCode, True)
      Me.Close()
      'GoTo Err_RFID120U_ReadCard
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

  Private Sub TmrLoadRFID_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TmrLoadRFID.Tick
    Dim VRFIDData() As String
    Dim VTempS As String
    If BTNSave.Enabled = False Then Exit Sub
    Try
      TmrLoadRFID.Enabled = False
      If RFID120U_IsCardConnect() = True Then
        If Trim(LblInfoKartu.Text) = "" Then
          VTempS = ACR120U_GetInfo()
          If VTempS.Length > 3 Then
            If InStr(1, VTempS, "||PRIMECARD", CompareMethod.Text) > 1 Then
              VRFIDData = Split(VTempS, "||")
              Payment1.Text = FormatNumber(VRFIDData(0), 0)
              CardOwner1.Text = VRFIDData(2)
              CardNumber1.Text = VRFIDData(1)
              'NameCustLabel.Text = VRFIDData(2)
              'CatCustLabel.Text = VRFIDData(1)
              BankName1.Text = DeptInfo.DepName & "[" & DeptInfo.DeptNo & "]"
              VTempS = VTempS & vbNewLine & "Tgl Registrasi : " & FormatDateTime(VRFIDData(3), DateFormat.LongDate)
              VTempS = VTempS & vbNewLine & "Berlaku s/d : " & FormatDateTime(VRFIDData(4), DateFormat.LongDate)
              LblInfoKartu.Text = VTempS
            Else
              ShowMessage(Me, "Bukan Kartu e-Payment Primeresto", True)
            End If
          End If
        End If
        'Call ReTotal()
      Else
        Call ResetInputForm()
      End If
      TmrLoadRFID.Enabled = True
    Catch ex As Exception
      TmrLoadRFID.Enabled = True
    End Try

  End Sub

#End Region
  Private Sub ResetInputForm()

    'LblInfoKartu.Text = ""


    LblInfoKartu.Text = ""
    'CustName.Text = ""
    CardNumber1.Text = ""
    CardNumber2.Text = ""
    CardNumber3.Text = ""
    CardNumber4.Text = ""
    CardNumber5.Text = ""
    PaidTxt.Value = FormatNumber(0, 0)
    ChangeTxt.Value = FormatNumber(0, 0)

    ''add 28-12-2016

    'RestTxt.Value = FormatNumber(GrandTotalTxt.Value, 0)


    Payment1.Text = FormatNumber(0, 0)
    Payment2.Text = FormatNumber(0, 0)
    Payment3.Text = FormatNumber(0, 0)
    Payment4.Text = FormatNumber(0, 0)
    Payment5.Text = FormatNumber(0, 0)

    CardOwner1.Text = ""
    CardOwner2.Text = ""
    CardOwner3.Text = ""
    CardOwner4.Text = ""
    CardOwner5.Text = ""



    BankName1.Text = ""
    BankName2.Text = ""
    BankName3.Text = ""
    BankName4.Text = ""
    BankName5.Text = ""
  End Sub
#Region "Pajak"

  Private Sub unPost(ByVal idRsv As String, ByVal idMB As String, ByVal idPay As String)
    Dim tmpNumTransFounded As String = Nothing

    'PBTRANS
    'tmpNumTransFounded = getNotaNumber2("SELECT PBTRANSNO FROM PBTRANS WHERE PBTRANSUID='" & .Item(rowSel, "idpb") & "'")
    'SET UNPOST PBTRANS
    MyDatabase.MyAdapter("UPDATE PBTRANS SET ISFISCAL='0' WHERE PBTRANSUID='" & idPay & "'")
    'If tmpNumTransFounded <> Nothing Then
    MyDatabase.MyAdapter2(strConn2, "DELETE FROM PBTRANS WHERE PBTRANSUID='" & idPay & "'")
    'End If

    'MBTRANS
    'tmpNumTransFounded = getNotaNumber2("SELECT MBTRANSNO FROM MBTRANS WHERE MBTRANSUID='" & .Item(rowSel, "idmb") & "'")
    'SET UNPOST MBTRANS
    MyDatabase.MyAdapter("UPDATE MBTRANS SET ISFISCAL='0' WHERE MBTRANSUID='" & idMB & "'")
    'If tmpNumTransFounded <> Nothing Then
    MyDatabase.MyAdapter2(strConn2, "DELETE FROM MBTRANS WHERE MBTRANSUID='" & idMB & "'")
    'End If

    If idRsv <> Nothing Then
      'SET UNPOST RSVTRANS
      MyDatabase.MyAdapter("UPDATE RSVTRANS SET ISFISCAL='0' WHERE RSVTRANSUID='" & idRsv & "'")
      'tmpNumTransFounded = getNotaNumber2("SELECT RSVTRANSNO FROM RSVTRANS WHERERSVTRANSUID='" & .Item(rowSel, "idrsv") & "'")
      'If tmpNumTransFounded <> Nothing Then
      MyDatabase.MyAdapter2(strConn2, "DELETE FROM RSVTRANS WHERE RSVTRANSUID='" & idRsv & "'")
      'End If
    End If
  End Sub

  Private Function getFieldList(ByVal TableName As String) As String
    Dim tmpList As String = Nothing
    Dim rs As FbDataReader
    rs = MyDatabase.MyReader("SELECT f.rdb$field_name AS NamaField FROM rdb$relation_fields f JOIN rdb$relations r ON f.rdb$relation_name = r.rdb$relation_name AND r.rdb$view_blr is null AND (r.rdb$system_flag is null or r.rdb$system_flag = 0) WHERE f.rdb$relation_name='" & TableName & "' ORDER BY f.RDB$FIELD_POSITION")
    While rs.Read()
      tmpList = tmpList & Trim(IIf(IsDBNull(rs(0)) = True, "NULL", rs(0))) & ","
    End While
    rs = Nothing
    If Trim(tmpList) <> "" Then
      tmpList = Strings.Left(tmpList, Len(tmpList) - 1)
    End If
    Return tmpList
  End Function

  Private Function AutoIDNumber3(ByVal Database2 As String, ByVal ModuleTypeID As String, ByVal TableCheck As String, ByVal FieldCheck As String, Optional ByVal FixedFormat As Boolean = False, Optional ByVal Filter As String = Nothing, Optional ByVal partCode As String = Nothing) As String
    Dim Generate As String, Query As String = Nothing, TMPRecord As FbDataReader
    Dim JCODE As String = Nothing, TMPCheck As FbDataReader

    Query = "SELECT MODULETYPEJURNALCODE FROM MODULETYPE WHERE MODULETYPEID='" & ModuleTypeID & "'"
    TMPCheck = MyDatabase.MyReader2(Database2, Query)
    TMPCheck.Read()
    JCODE = TMPCheck.Item("MODULETYPEJURNALCODE")

    If FixedFormat Then
      Generate = Nothing
    Else
      If partCode <> Nothing Then
        Generate = partCode
      Else
        Generate = Format(Now.Month, "00") & Mid(Now.Year, 3)
      End If
    End If

    If IsNothing(Filter) Then
      Query = "SELECT MAX(" & ReplacePetik(FieldCheck) & ")AS LASTNO FROM " & ReplacePetik(TableCheck) & " WHERE " & FieldCheck & " like '" & JCODE & "-" & Generate & "%'"
    Else
      Query = "SELECT MAX(" & ReplacePetik(FieldCheck) & ")AS LASTNO FROM " & ReplacePetik(TableCheck) & " WHERE " & FieldCheck & " like '" & JCODE & Generate & "%' " & Filter
    End If

    TMPRecord = MyDatabase.MyReader2(Database2, Query)
    TMPRecord.Read()

    If IsDBNull(TMPRecord.Item("LASTNO")) Then
      If Generate = Nothing Then
        Return JCODE & "-" & "00001"
      Else
        Return JCODE & "-" & Generate & "-" & "00001"
      End If
    Else
      If Generate = Nothing Then
        Dim Result As String, Fixed As Long
        Result = TMPRecord.Item("LASTNO")
        Fixed = Mid(Result, Len(JCODE) + Len(Generate) + 3) + 1
        Return JCODE & "-" & Format(Fixed, "00000")
      Else
        Dim Result As String, Fixed As Long
        Result = TMPRecord.Item("LASTNO")
        Fixed = Mid(Result, Len(JCODE) + Len(Generate) + 3) + 1
        Return JCODE & "-" & Generate & "-" & Format(Fixed, "00000")
      End If
    End If

    TMPRecord = Nothing
    TMPCheck = Nothing
  End Function

  Private Function getValueToInsert(ByVal strSQL As String, Optional ByVal TransCode As String = "", Optional ByVal colNum As Integer = -1, Optional ByVal partCode As String = Nothing) As String
    Dim tmpList As String = Nothing
    Try
      Dim tmpCode As String = ""
      Dim rs As FbDataReader
      rs = MyDatabase.MyReader(strSQL)

      If rs.Read = False Then
        Return Nothing
      Else
        If Trim(TransCode) <> "" Then
          Dim tmpData As String = Nothing
          Dim col1 As Integer = 0, col2 As Integer = 0
          If TransCode = "MB" Then
            col1 = InStr(rs("MBTRANSNO"), "-")
            tmpData = Mid(rs("MBTRANSNO"), col1 + 1, 4)
            tmpCode = AutoIDNumber3(strConn2, "2202", "MBTRANS", "MBTRANSNO", , , tmpData)
          ElseIf TransCode = "RSV" Then
            col1 = InStr(rs("RSVTRANSNO"), "-")
            tmpData = Mid(rs("RSVTRANSNO"), col1 + 1, 4)
            tmpCode = AutoIDNumber3(strConn2, "2201", "RSVTRANS", "RSVTRANSNO", , , tmpData)
          ElseIf TransCode = "PAY" Then
            col1 = InStr(rs("PBTRANSNO"), "-")
            tmpData = Mid(rs("PBTRANSNO"), col1 + 1, 4)
            tmpCode = AutoIDNumber3(strConn2, "2206", "PBTRANS", "PBTRANSNO", , , tmpData)
          End If
        End If
        For i As Integer = 0 To 1000
          If colNum = i Then
            tmpList = tmpList & "'" & tmpCode & "',"
          Else
            If IsDate(rs(i)) = True Then
              If TransCode = "RSV" Then
                If i = 7 Then
                  tmpList = tmpList & "'" & Format(rs(i), "yyyy/MM/dd") & "',"
                ElseIf i = 8 Then
                  tmpList = tmpList & "'" & Format(rs(i), "HH:mm:ss") & "',"
                Else
                  tmpList = tmpList & "'" & Format(rs(i), "yyyy/MM/dd HH:mm:ss") & "',"
                End If
              ElseIf TransCode = "MB" Then
                If i = 12 Then
                  tmpList = tmpList & "'" & Format(CDate(rs(i)), "HH:mm:ss") & "',"
                Else
                  tmpList = tmpList & "'" & Format(rs(i), "yyyy/MM/dd HH:mm:ss") & "',"
                End If
              Else
                tmpList = tmpList & "'" & Format(rs(i), "yyyy/MM/dd HH:mm:ss") & "',"
              End If
            ElseIf IsDBNull(rs(i)) = True Then
              tmpList = tmpList & "NULL,"
            ElseIf IsNumeric(rs(i)) = True Then
              tmpList = tmpList & "'" & Replace(rs(i), ",", "") & "',"
            Else
              tmpList = tmpList & "'" & Replace(rs(i), "'", "''") & "',"
            End If
          End If
        Next
      End If
      rs = Nothing
      Return tmpList
    Catch ex As Exception
      If Trim(tmpList) <> "" Then
        tmpList = Strings.Left(tmpList, Len(tmpList) - 1)
      End If
      Return tmpList
    End Try
  End Function

  Private Sub fillData(ByVal idRsv As String, ByVal idMB As String, ByVal idPay As String)
    Dim tmpFieldList As String = Nothing, tmpValField As String = Nothing
    Dim tmpFieldList2 As String = Nothing, tmpValField2 As String = Nothing
    Dim INVENADDEDFIELD_ok As Boolean = False
    Dim INVENLINKEDACC_ok As Boolean = False

    Dim rs As FbDataReader
    Dim rs2 As FbDataReader

    'RSVTRANS
    If idRsv <> Nothing Then
      If jmlRowDB2("SELECT COUNT(*) FROM RSVTRANS WHERE RSVTRANSUID='" & idRsv & "'") = 0 Then
        tmpFieldList = getFieldList("RSVTRANS")
        tmpValField = getValueToInsert("SELECT * FROM RSVTRANS WHERE RSVTRANSUID='" & idRsv & "'", "RSV", 1)
        MyDatabase.MyAdapter2(strConn2, "INSERT INTO RSVTRANS (" & tmpFieldList & ") VALUES (" & tmpValField & ")")

        'SET TO FISCAL
        MyDatabase.MyAdapter("UPDATE RSVTRANS SET ISFISCAL='1' WHERE RSVTRANSUID='" & idRsv & "'")

        'RSVTRANSDT
        tmpFieldList = getFieldList("RSVTRANSDT")
        rs = MyDatabase.MyReader("SELECT * FROM RSVTRANSDT WHERE RSVTRANSUID='" & idRsv & "'")
        While rs.Read()
          tmpValField = getValueToInsert("SELECT * FROM RSVTRANSDT WHERE RSVTRANSDTUID='" & rs(0) & "'")
          MyDatabase.MyAdapter2(strConn2, "INSERT INTO RSVTRANSDT (" & tmpFieldList & ") VALUES (" & tmpValField & ")")

          'RSVTRANSDTDETAIL
          rs2 = MyDatabase.MyReader("SELECT * FROM RSVTRANSDTDETAIL WHERE RSVTRANSDTUID='" & rs("RSVTRANSDTUID") & "'")
          While rs2.Read() = True
            tmpValField2 = getValueToInsert("SELECT * FROM RSVTRANSDTDETAIL WHERE RSVTRANSDTDETAILUID='" & rs2("RSVTRANSDTDETAILUID") & "'")
            MyDatabase.MyAdapter2(strConn2, "INSERT INTO RSVTRANSDTDETAIL (" & tmpFieldList2 & ") VALUES (" & tmpValField2 & ")")
          End While
          rs2 = Nothing

        End While
        rs = Nothing

        'RSVTRANSTABLELIST
        tmpFieldList = getFieldList("RSVTRANSTABLELIST")
        rs = MyDatabase.MyReader("SELECT * FROM RSVTRANSTABLELIST WHERE RSVTRANSUID='" & idRsv & "'")
        While rs.Read() = True
          tmpValField = getValueToInsert("SELECT * FROM RSVTRANSTABLELIST WHERE RSVTRANSDTTABLELISTUID='" & rs("RSVTRANSDTTABLELISTUID") & "'")
          MyDatabase.MyAdapter2(strConn2, "INSERT INTO RSVTRANSTABLELIST (" & tmpFieldList & ") VALUES (" & tmpValField & ")")
        End While
        rs = Nothing
        'MyDatabase.MyAdapter2(strConn2, "UPDATE SALESTRANSREG SET SALESTRANSREGTRANSSTAT=1 WHERE SALESTRANSREGTRANSUID='" & idRsv & "'")

      End If
    End If

    'MBTRANS
    If jmlRowDB2("SELECT COUNT(*) FROM MBTRANS WHERE MBTRANSUID='" & idMB & "'") = 0 Then
      tmpFieldList = getFieldList("MBTRANS")
      tmpValField = getValueToInsert("SELECT * FROM MBTRANS WHERE MBTRANSUID='" & idMB & "'", "MB", 1)
      MyDatabase.MyAdapter2(strConn2, "INSERT INTO MBTRANS (" & tmpFieldList & ") VALUES (" & tmpValField & ")")

      'SET TO FISCAL
      MyDatabase.MyAdapter("UPDATE MBTRANS SET ISFISCAL='1' WHERE MBTRANSUID='" & idMB & "'")

      'MBTRANSDT  
      tmpFieldList = getFieldList("MBTRANSDT")
      tmpFieldList2 = getFieldList("MBTRANSDTDETAIL")
      rs = MyDatabase.MyReader("SELECT * FROM MBTRANSDT WHERE MBTRANSUID='" & idMB & "'")
      While rs.Read()
        tmpValField = getValueToInsert("SELECT * FROM MBTRANSDT WHERE MBTRANSDTUID='" & rs(0) & "'")
        MyDatabase.MyAdapter2(strConn2, "INSERT INTO MBTRANSDT (" & tmpFieldList & ") VALUES (" & tmpValField & ")")

        'MBTRANSDTDETAIL
        rs2 = MyDatabase.MyReader("SELECT * FROM MBTRANSDTDETAIL WHERE MBTRANSDTUID='" & rs("MBTRANSDTUID") & "'")
        While rs2.Read = True
          tmpValField2 = getValueToInsert("SELECT * FROM MBTRANSDTDETAIL WHERE MBTRANSDTDETAILUID='" & rs2("MBTRANSDTDETAILUID") & "'")
          MyDatabase.MyAdapter2(strConn2, "INSERT INTO MBTRANSDTDETAIL (" & tmpFieldList2 & ") VALUES (" & tmpValField2 & ")")
        End While
        rs2 = Nothing
      End While
      rs = Nothing

      'MBTRANSTABLELIST
      tmpFieldList = getFieldList("MBTRANSTABLELIST")
      rs = MyDatabase.MyReader("SELECT * FROM MBTRANSTABLELIST WHERE MBTRANSUID='" & idMB & "'")
      While rs.Read() = True
        tmpValField = getValueToInsert("SELECT * FROM MBTRANSTABLELIST WHERE MBTRANSDTTABLELISTUID='" & rs("MBTRANSDTTABLELISTUID") & "'")
        MyDatabase.MyAdapter2(strConn2, "INSERT INTO MBTRANSTABLELIST (" & tmpFieldList & ") VALUES (" & tmpValField & ")")
      End While
      rs = Nothing
      'MyDatabase.MyAdapter2(strConn2, "UPDATE SALESTRANSREG SET SALESTRANSREGTRANSSTAT=1 WHERE SALESTRANSREGTRANSUID='" & idMB & "'")
    End If

    'PAYMENT
    If jmlRowDB2("SELECT COUNT(*) FROM PBTRANS WHERE PBTRANSUID='" & idPay & "'") = 0 Then
      tmpFieldList = getFieldList("PBTRANS")
      tmpValField = getValueToInsert("SELECT * FROM PBTRANS WHERE PBTRANSUID='" & idPay & "'", "PAY", 1)
      MyDatabase.MyAdapter2(strConn2, "INSERT INTO PBTRANS (" & tmpFieldList & ") VALUES (" & tmpValField & ")")

      'SET TO FISCAL
      MyDatabase.MyAdapter("UPDATE PBTRANS SET ISFISCAL='1' WHERE PBTRANSUID='" & idPay & "'")

      tmpFieldList = getFieldList("PBTRANSDT")
      rs = MyDatabase.MyReader("SELECT * FROM PBTRANSDT WHERE PBTRANSUID='" & idPay & "'")
      While rs.Read() = True
        tmpValField = getValueToInsert("SELECT * FROM PBTRANSDT WHERE PBTRANSDTUID='" & rs("PBTRANSDTUID") & "'")
        MyDatabase.MyAdapter2(strConn2, "INSERT INTO PBTRANSDT (" & tmpFieldList & ") VALUES (" & tmpValField & ")")
      End While
      rs = Nothing
      'MyDatabase.MyAdapter2(strConn2, "UPDATE SALESTRANSREG SET SALESTRANSREGTRANSSTAT=1 WHERE SALESTRANSREGTRANSUID='" & idPay & "'")
    End If
    rs = Nothing
  End Sub

  Private Function isTableExist(ByVal tableName As String) As Boolean
    Try
      Dim rs As FbDataReader
      rs = MyDatabase.MyReader2(strConn2, "SELECT COUNT(*) FROM " & tableName & "")
      'do nothing
      rs = Nothing
      rs = MyDatabase.MyReader("SELECT COUNT(*) FROM " & tableName & "")
      'do nothing
      rs = Nothing
      Return True
    Catch ex As Exception
      Return False
    End Try
  End Function

  Private Function jmlRowDB2(ByVal strSQL As String) As Integer
    Dim rs As FbDataReader
    rs = MyDatabase.MyReader2(strConn2, strSQL)
    rs.Read()
    Return rs(0)
    rs = Nothing
  End Function


#End Region

#Region "Variable Reference"
  Dim myDetailStringArray As String
  Dim PaymentFormStatus As FormStatusLib
  Public SaveStatus As Boolean = False
  Dim tvPBTransUID As String
  Dim tvMBTransUID As String
  Dim tvCustUID As String
  Dim tvTableUID As String
  Public TransactionUID As String = Nothing
  Public MBTransUID As String = Nothing
  Public Paid As Decimal = 0
  Public Deviasi As Decimal = 0
  Public NewTransaction As Boolean = False
  Dim CurrDate As Date
  Dim CanEdit As Boolean = False

  Dim oldPaymentVal As Decimal = 0

  Public fromInvoice As Boolean
  Public ParentOBJForm As Object

  Dim UserPermition As New UserPermitionLib
  Dim ListCollection As New Collection
  Dim FormStatus As FormStatusLib

  Dim foundDefaultPayment As Boolean = False

  'Add By Rudy (16 Mar 2011)
  Public Invoice As Boolean = False

  Dim t As Integer = 0
  Dim FileDatabase2 As String = Nothing
  Dim Shift As String = GetShift()
  Dim ExitIsRefundable As Boolean = False

  Dim oldPayment1 As Decimal = 0
  Dim oldPayment2 As Decimal = 0
  Dim oldPayment3 As Decimal = 0
  Dim oldPayment4 As Decimal = 0
  Dim oldPayment5 As Decimal = 0

#End Region

#Region "Initialize & Object Function"

  Private Sub Basicinitialize()

    CurrDate = Now.Date
    PaymentDate.Value = Now
    DateLabel.Text = Format(PaymentDate.Value, "dddd , dd MMMM yyyy")

    'Anjo - 12 Okt : The following is genuinely trash
    'Dim Query As String = "SELECT COUNT(*) AS DATAEXISTS FROM MBTRANS MB WHERE MB.MBTRANSTOTVAL > MB.MBTRANSPAIDVAL"
    'Dim TMPData As FbDataReader
    'TMPData = MyDatabase.MyReader(Query)
    'While TMPData.Read
    '    If TMPData.Item("DATAEXISTS") = 0 Then
    '        FindTransaction.Enabled = False
    '        FormStatus = FormStatusLib.OpenFirstUse
    '        Call OBJControlHandler(Me, FormStatus)
    '        Call CheckPermission(UserInformation.UserTypeUID, False)
    '    Else
    '        FindTransaction.Enabled = True
    '        FormStatus = FormStatusLib.OpenAndView
    '        Call OBJControlHandler(Me, FormStatus)
    '        Call CheckPermission(UserInformation.UserTypeUID, True)
    '    End If
    'End While

    Call OBJControlHandler(Me, FormStatusLib.OpenFirstUse)
    Call CheckPermission(UserInformation.UserTypeUID, True)

    Dim TMPTrans As FbDataReader
    Try
      TMPTrans = MyDatabase.MyReader("SELECT * FROM MBTRANS MB WHERE MB.MBTRANSUID='" & MBTransUID & "' AND MB.MBTRANSTOTVAL > MB.MBTRANSPAIDVAL")
      TransactionList.ClearItems()
      TransactionList.HoldFields()
      While TMPTrans.Read()
        oldPaymentVal = CDec(TMPTrans.Item("MBTRANSPAIDVAL"))
        TransactionList.AddItem(TMPTrans.Item("MBTRANSNO") & ";" & TMPTrans.Item("MBTRANSUID") & ";" & TMPTrans.Item("MBTRANSMODULETYPEID"))
      End While
      If TransactionList.ListCount > 0 Then TransactionList.SelectedIndex = -1
    Catch ex As Exception
    End Try
    TMPTrans = Nothing

    Call PaymentTypeInitialize()
    If foundDefaultPayment Then
      DBInitialize()
    Else
      ShowMessage(Me, "Silakan tentukan default pembayaran pada data master 'Payment Type' !")
      Me.Close()
    End If
  End Sub
  Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)
    Dim TMPRecord As FbDataReader

    If MainPage.InvoiceApplication = True Then
      If fromInvoice = True Then
        TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2206'")
      Else
        TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2213'")
      End If
    Else
      TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2213'")
    End If

    While TMPRecord.Read()
      UserPermition.PermitionInitialize(TMPRecord.Item("USERCATCREATEACCESS"), TMPRecord.Item("USERCATEDITACCESS"), TMPRecord.Item("USERCATDELETEACCESS"), TMPRecord.Item("USERCATREADACCESS"), TMPRecord.Item("USERCATPRINTACCESS"), TMPRecord.Item("USERCATCHANGEDATEACCESS"), TMPRecord.Item("USERCATCHANGETIMEACCESS"), TMPRecord.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
    End While

    With UserPermition
      If Not .ReadAccess Then
        ShowMessage(Me, "Maaf, anda tidak mempunyai akses terhadap form ini !" & vbNewLine & "Silakan hubungi administrator anda.")
        Me.Close()
        Exit Sub
      End If

      If Not .CreateAccess Then
        BTNSave.Enabled = False
        BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver
      End If
      If Not .EditAccess Then
        CanEdit = False

        BTNSave.Enabled = False
        BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver
      End If

      If Not .ChangeDateAccess Then
        VirtualDate.Enabled = False
        VirtualDate.VisualStyle = C1Input.VisualStyle.Office2007Silver
      End If

      If .CreateAccess Then
        BTNSave.Enabled = True
        BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Blue
      End If

      If .EditAccess Then
        CanEdit = True

        BTNSave.Enabled = True
        BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Blue
      End If

      If .ChangeDateAccess Then
        VirtualDate.Enabled = True
        VirtualDate.VisualStyle = C1Input.VisualStyle.Office2007Blue
      End If
    End With
  End Sub
  Private Sub DBInitialize(Optional ByVal STRFind As String = Nothing)

    ''ARDIAN - INVOICE APPLICATION''

    If Invoice = True Then
      'Dim TMPRecordInvoice As FbDataReader

      'TMPRecordInvoice = MyDatabase.MyReader("SELECT MB.*,PB.*,(MB.MBTRANSTOTVAL-MB.MBTRANSPAIDVAL) AS MBTRANMINUSPAIDVAL,(SELECT CustName FROM Cust WHERE CustUID = PB.PBTRANSCUSTUID) AS SELECTEDCUSTNAME FROM MBTRANS MB LEFT OUTER JOIN PBTRANS PB ON MB.MBTRANSUID=PB.PBTRANSMBTRANSUID " & _
      '"WHERE PB.PBTRANSMODULETYPEID='2206' AND MB.MBTRANSSTAT='1' AND MB.MBTRANSUID = '" & MBTransUID & "'")

      'If TMPRecordInvoice.Read() Then
      '    PaymentFormStatus = FormStatusLib.OpenAndEdit
      '    t = TMPRecordInvoice.Item("ISFISCAL")
      '    If t = 1 Then
      '        Tax.Visible = True
      '    End If
      '    tvPBTransUID = TMPRecordInvoice.Item("PBTRANSUID")
      '    tvMBTransUID = TMPRecordInvoice.Item("MBTRANSUID")
      '    tvCustUID = TMPRecordInvoice.Item("MBTRANSCUSTUID")
      '    PaymentNo.Text = TMPRecordInvoice.Item("PBTRANSNO")
      '    TransactionList.Text = TMPRecordInvoice.Item("MBTRANSNO")
      '    PaymentDate.Text = TMPRecordInvoice.Item("PBTRANSDATE")
      '    CustomerList.Text = TMPRecordInvoice.Item("SELECTEDCUSTNAME")
      '    CustName.Text = TMPRecordInvoice.Item("PBTRANSCUSTNAME")
      '    GrandTotalTxt.Value = FormatNumber(TMPRecordInvoice.Item("MBTRANMINUSPAIDVAL"), 0)
      '    Call GetPaymentDetail(TMPRecordInvoice.Item("PBTRANSUID"))
      'End If

      'DateLabel.Text = Format(PaymentDate.Value, "dddd , dd MMMM yyyy")
      'CatCustLabel.Text = CustomerList.Text
      'NameCustLabel.Text = CustName.Text

      'MainArea.SelectedIndex = 0
      'PaymentType1.SelectedIndex = 1

      NewTransaction = True
    End If

    ''ARDIAN - PAYMENT REST ''

    If NewTransaction = False Then
      PaymentFormStatus = FormStatusLib.OpenAndEdit

      Dim TMPRecord As FbDataReader
      TMPRecord = MyDatabase.MyReader("SELECT PB.*,MB.*,C.CUSTNAME FROM PBTRANS PB " & _
                                      "LEFT OUTER JOIN MBTRANS MB ON MB.MBTRANSUID=PB.PBTRANSMBTRANSUID " & _
                                      "LEFT OUTER JOIN CUST C ON C.CUSTUID=PB.PBTRANSCUSTUID " & _
                                      "WHERE PB.PBTRANSUID = '" & TransactionUID & "'")
      While TMPRecord.Read
        Try
          t = TMPRecord.Item("ISFISCAL")
          If t = 1 Then
            Tax.Visible = True
          End If
        Catch ex As Exception
          Tax.Visible = False
        End Try

        tvPBTransUID = TMPRecord.Item("PBTRANSUID")
        tvMBTransUID = TMPRecord.Item("PBTRANSMBTRANSUID")
        tvCustUID = TMPRecord.Item("PBTRANSCUSTUID")
        tvTableUID = TMPRecord.Item("PBTRANSTABLELISTUID")
        PaymentNo.Text = TMPRecord.Item("PBTRANSNO")
        TransactionList.Text = TMPRecord.Item("MBTRANSNO")
        PaymentDate.Text = TMPRecord.Item("PBTRANSDATE")
        CustomerList.Text = TMPRecord.Item("CUSTNAME")
        CustName.Text = TMPRecord.Item("PBTRANSCUSTNAME")
        GrandTotalTxt.Value = FormatNumber(TMPRecord.Item("MBTRANSTOTVAL"), 0)
        Call GetPaymentDetail(TMPRecord.Item("PBTRANSUID"))

        DateLabel.Text = Format(PaymentDate.Value, "dddd , dd MMMM yyyy")
        CatCustLabel.Text = CustomerList.Text
        NameCustLabel.Text = CustName.Text
        Deviasi = CDbl(Payment1.Text) + CDbl(Payment2.Text) + CDbl(Payment3.Text) + CDbl(Payment4.Text) + CDbl(Payment5.Text)
      End While
    Else
      Dim TMPRecord As FbDataReader
      TMPRecord = MyDatabase.MyReader("SELECT MB.*,C.CUSTNAME FROM MBTRANS MB " & _
                                      "LEFT OUTER JOIN CUST C ON C.CUSTUID=MB.MBTRANSCUSTUID " & _
                                      "WHERE MB.MBTRANSUID = '" & MBTransUID & "'")
      While TMPRecord.Read
        PaymentFormStatus = FormStatusLib.OpenAndNew
        tvMBTransUID = TMPRecord.Item("MBTRANSUID")
        tvCustUID = TMPRecord.Item("MBTRANSCUSTUID")

        If Invoice = False Then
          tvTableUID = TMPRecord.Item("MBTRANSTABLELISTUID")
        End If

        PaymentNo.Text = AutoIDNumber("2206", "PBTRANS", "PBTRANSNO")
        CustomerList.Text = TMPRecord.Item("CUSTNAME")
        CustName.Text = TMPRecord.Item("MBTRANSCUSTNAME")
        GrandTotalTxt.Value = FormatNumber(TMPRecord.Item("MBTRANSTOTVAL"), 0)
      End While

      Dim TMPRecordDefault As FbDataReader
      Dim IndexPayment As Integer

      TMPRecordDefault = MyDatabase.MyReader("SELECT * FROM PAYMENTTYPE WHERE PAYMENTTYPEACTV IS NULL AND PAYMENTTYPEDEFAULT = 1 OR PAYMENTTYPEACTV = 0 AND PAYMENTTYPEDEFAULT = 1 ORDER BY PAYMENTTYPENAME")
      While TMPRecordDefault.Read
        IndexPayment = PaymentType1.FindString(Trim(TMPRecordDefault.Item("PAYMENTTYPENAME")), 0, 0)
      End While

      PaymentType1.SelectedIndex = IndexPayment
      'Modified By Rudy (16 Mar 2011)
      'Payment1.Text = "" : Payment1.Text = 0

      DateLabel.Text = Format(PaymentDate.Value, "dddd , dd MMMM yyyy")
      CatCustLabel.Text = CustomerList.Text
      NameCustLabel.Text = CustName.Text

      PaidTxt.Value = FormatNumber(Paid, 0)

      Deviasi = CDbl(Payment1.Text) + CDbl(Payment2.Text) + CDbl(Payment3.Text) + CDbl(Payment4.Text) + CDbl(Payment5.Text)
      'Add By Rudy (16 Mar 2011)
      Payment1.Text = CDbl(GrandTotalTxt.Value) - CDbl(PaidTxt.Value)
    End If

    If CDbl(GrandTotalTxt.Text) > CDbl(PaidTxt.Text) Then
      Dim Rest As Double
      Rest = CDbl(GrandTotalTxt.Text) - CDbl(PaidTxt.Text)

      RestTxt.Value = FormatNumber(Rest, 0)
      ChangeTxt.Value = 0
    Else
      Dim Change As Double
      Change = CDbl(PaidTxt.Text) - CDbl(GrandTotalTxt.Text)

      ChangeTxt.Value = FormatNumber(Change, 0)
      RestTxt.Value = 0
    End If
  End Sub

  Private Sub ResetMainArea()
    Payment1.Text = "0"
    Payment2.Text = "0"
    Payment3.Text = "0"
    Payment4.Text = "0"
    Payment5.Text = "0"

    CardOwner1.Text = ""
    CardOwner2.Text = ""
    CardOwner3.Text = ""
    CardOwner4.Text = ""
    CardOwner5.Text = ""

    CardNumber1.Text = ""
    CardNumber2.Text = ""
    CardNumber3.Text = ""
    CardNumber4.Text = ""
    CardNumber5.Text = ""

    PaymentType1.Enabled = True
    Payment1.Enabled = True
    CardOwner1.Enabled = True
    CardNumber1.Enabled = True
    BankName1.Enabled = True

    VirtualCalculator1.Enabled = True
    VirtualKeyCO1.Enabled = True
    VirtualKeyCN1.Enabled = True
    VirtualKeyBN1.Enabled = True

    PaymentType2.Enabled = True
    Payment2.Enabled = True
    CardOwner2.Enabled = True
    CardNumber2.Enabled = True
    BankName2.Enabled = True

    VirtualCalculator2.Enabled = True
    VirtualKeyCO2.Enabled = True
    VirtualKeyCN2.Enabled = True
    VirtualKeyBN2.Enabled = True

    PaymentType3.Enabled = True
    Payment3.Enabled = True
    CardOwner3.Enabled = True
    CardNumber3.Enabled = True
    BankName3.Enabled = True

    VirtualCalculator3.Enabled = True
    VirtualKeyCO3.Enabled = True
    VirtualKeyCN3.Enabled = True
    VirtualKeyBN3.Enabled = True

    PaymentType4.Enabled = True
    Payment4.Enabled = True
    CardOwner4.Enabled = True
    CardNumber4.Enabled = True
    BankName4.Enabled = True

    VirtualCalculator4.Enabled = True
    VirtualKeyCO4.Enabled = True
    VirtualKeyCN4.Enabled = True
    VirtualKeyBN4.Enabled = True

    PaymentType5.Enabled = True
    Payment5.Enabled = True
    CardOwner5.Enabled = True
    CardNumber5.Enabled = True
    BankName5.Enabled = True

    VirtualCalculator5.Enabled = True
    VirtualKeyCO5.Enabled = True
    VirtualKeyCN5.Enabled = True
    VirtualKeyBN5.Enabled = True

    PaymentType1.SelectedIndex = -1
    PaymentType2.SelectedIndex = -1
    PaymentType3.SelectedIndex = -1
    PaymentType4.SelectedIndex = -1
    PaymentType5.SelectedIndex = -1

    MainArea.SelectedIndex = 0
  End Sub

  Public Sub GetPaymentDetail(ByVal PBTransUID As String)
    Dim a As Integer = 1
    Dim ItemRecord As FbDataReader
    ItemRecord = MyDatabase.MyReader("SELECT a.PBTRANSDTUID, a.PBTRANSUID, a.PAYMENTTYPEUID, b.PAYMENTTYPENAME AS PAYMENTTYPENAME, b.ISCREDITCARDORCHEQUE AS ISCREDITCARDORCHEQUE, a.VISAORCHEQUENUMBER, a.VISAORCHEQUENAME, a.VISAORCHEQUEBANKNAME, a.PBTRANSDTSUBVAL FROM PBTRANSDT a LEFT OUTER JOIN PAYMENTTYPE b ON a.PAYMENTTYPEUID = b.PAYMENTTYPEUID WHERE a.PBTRANSUID = '" & PBTransUID & "'")

    Call ResetMainArea()

    If ItemRecord.Read() Then
      Label_PBTRANSDTUID1.Text = ItemRecord("PBTRANSDTUID")
      Focus_PaymentType("PaymentType1", ItemRecord.Item("PAYMENTTYPENAME"))
      Payment1.Text = ItemRecord.Item("PBTRANSDTSUBVAL")
      oldPayment1 = CDec(Payment1.Text)
      CardOwner1.Text = ItemRecord.Item("VISAORCHEQUENAME")
      CardNumber1.Text = ItemRecord.Item("VISAORCHEQUENUMBER")
      BankName1.Text = ItemRecord.Item("VISAORCHEQUEBANKNAME")

      If CanEdit = False Then
        PaymentType1.Enabled = False
        Payment1.Enabled = False
        CardOwner1.Enabled = False
        CardNumber1.Enabled = False
        BankName1.Enabled = False

        VirtualCalculator1.Enabled = False
        VirtualKeyCO1.Enabled = False
        VirtualKeyCN1.Enabled = False
        VirtualKeyBN1.Enabled = False
      End If
    End If

    If ItemRecord.Read() Then
      Label_PBTRANSDTUID2.Text = ItemRecord("PBTRANSDTUID")
      Focus_PaymentType("PaymentType2", ItemRecord.Item("PAYMENTTYPENAME"))
      Payment2.Text = ItemRecord.Item("PBTRANSDTSUBVAL")
      oldPayment2 = CDec(Payment2.Text)
      CardOwner2.Text = ItemRecord.Item("VISAORCHEQUENAME")
      CardNumber2.Text = ItemRecord.Item("VISAORCHEQUENUMBER")
      BankName2.Text = ItemRecord.Item("VISAORCHEQUEBANKNAME")

      If CanEdit = False Then
        PaymentType2.Enabled = False
        Payment2.Enabled = False
        CardOwner2.Enabled = False
        CardNumber2.Enabled = False
        BankName2.Enabled = False

        VirtualCalculator2.Enabled = False
        VirtualKeyCO2.Enabled = False
        VirtualKeyCN2.Enabled = False
        VirtualKeyBN2.Enabled = False
      End If
    End If

    If ItemRecord.Read() Then
      Label_PBTRANSDTUID3.Text = ItemRecord("PBTRANSDTUID")
      Focus_PaymentType("PaymentType3", ItemRecord.Item("PAYMENTTYPENAME"))
      Payment3.Text = ItemRecord.Item("PBTRANSDTSUBVAL")
      oldPayment3 = CDec(Payment3.Text)
      CardOwner3.Text = ItemRecord.Item("VISAORCHEQUENAME")
      CardNumber3.Text = ItemRecord.Item("VISAORCHEQUENUMBER")
      BankName3.Text = ItemRecord.Item("VISAORCHEQUEBANKNAME")

      If CanEdit = False Then
        PaymentType3.Enabled = False
        Payment3.Enabled = False
        CardOwner3.Enabled = False
        CardNumber3.Enabled = False
        BankName3.Enabled = False

        VirtualCalculator3.Enabled = False
        VirtualKeyCO3.Enabled = False
        VirtualKeyCN3.Enabled = False
        VirtualKeyBN3.Enabled = False
      End If
    End If

    If ItemRecord.Read() Then
      Label_PBTRANSDTUID4.Text = ItemRecord("PBTRANSDTUID")
      Focus_PaymentType("PaymentType4", ItemRecord.Item("PAYMENTTYPENAME"))
      Payment4.Text = ItemRecord.Item("PBTRANSDTSUBVAL")
      oldPayment4 = CDec(Payment4.Text)
      CardOwner4.Text = ItemRecord.Item("VISAORCHEQUENAME")
      CardNumber4.Text = ItemRecord.Item("VISAORCHEQUENUMBER")
      BankName4.Text = ItemRecord.Item("VISAORCHEQUEBANKNAME")

      If CanEdit = False Then
        PaymentType4.Enabled = False
        Payment4.Enabled = False
        CardOwner4.Enabled = False
        CardNumber4.Enabled = False
        BankName4.Enabled = False

        VirtualCalculator4.Enabled = False
        VirtualKeyCO4.Enabled = False
        VirtualKeyCN4.Enabled = False
        VirtualKeyBN4.Enabled = False
      End If
    End If

    If ItemRecord.Read() Then
      Label_PBTRANSDTUID5.Text = ItemRecord("PBTRANSDTUID")
      Focus_PaymentType("PaymentType5", ItemRecord.Item("PAYMENTTYPENAME"))
      Payment5.Text = ItemRecord.Item("PBTRANSDTSUBVAL")
      oldPayment5 = CDec(Payment5.Text)
      CardOwner5.Text = ItemRecord.Item("VISAORCHEQUENAME")
      CardNumber5.Text = ItemRecord.Item("VISAORCHEQUENUMBER")
      BankName5.Text = ItemRecord.Item("VISAORCHEQUEBANKNAME")

      If CanEdit = False Then
        PaymentType5.Enabled = False
        Payment5.Enabled = False
        CardOwner5.Enabled = False
        CardNumber5.Enabled = False
        BankName5.Enabled = False

        VirtualCalculator5.Enabled = False
        VirtualKeyCO5.Enabled = False
        VirtualKeyCN5.Enabled = False
        VirtualKeyBN5.Enabled = False
      End If

    End If
    ItemRecord.Close()
    Paid = Paid - oldPayment1 - oldPayment2 - oldPayment3 - oldPayment4 - oldPayment5
    Payment1.Text = oldPayment1

  End Sub

  Private Sub Focus_PaymentType(ByVal paymentType As String, ByVal paymentTypeName As String)
    Select Case paymentType
      Case "PaymentType1"
        PaymentType1.SelectedIndex = PaymentType1.FindStringExact(paymentTypeName)
      Case "PaymentType2"
        PaymentType2.SelectedIndex = PaymentType2.FindStringExact(paymentTypeName)
      Case "PaymentType3"
        PaymentType3.SelectedIndex = PaymentType3.FindStringExact(paymentTypeName)
      Case "PaymentType4"
        PaymentType4.SelectedIndex = PaymentType4.FindStringExact(paymentTypeName)
      Case "PaymentType5"
        PaymentType5.SelectedIndex = PaymentType5.FindStringExact(paymentTypeName)
    End Select
  End Sub

  Private Sub PaymentTypeInitialize()

    Dim TMPRecord As FbDataReader
    Dim isPaymentRefundable As String
    Try
      'Call CardInfo_Locked(1, False)
      'Call CardInfo_Locked(2, False)
      'Call CardInfo_Locked(3, False)
      'Call CardInfo_Locked(4, False)
      'Call CardInfo_Locked(5, False)
      If RFID_HardwareID() = "" Then
        TMPRecord = MyDatabase.MyReader("SELECT * FROM PAYMENTTYPE WHERE (PAYMENTTYPEACTV IS NULL OR PAYMENTTYPEACTV = 0 ) AND ISCREDITCARDORCHEQUE < 6 ORDER BY PAYMENTTYPENAME")
      Else
        TMPRecord = MyDatabase.MyReader("SELECT * FROM PAYMENTTYPE WHERE (PAYMENTTYPEACTV IS NULL OR PAYMENTTYPEACTV = 0 ) ORDER BY PAYMENTTYPENAME")
      End If


      PaymentType1.HoldFields() : PaymentType1.AddItem("* None;;;") : PaymentType1.SelectedIndex = 0
      PaymentType2.HoldFields() : PaymentType2.AddItem("* None;;;") : PaymentType2.SelectedIndex = 0
      PaymentType3.HoldFields() : PaymentType3.AddItem("* None;;;") : PaymentType3.SelectedIndex = 0
      PaymentType4.HoldFields() : PaymentType4.AddItem("* None;;;") : PaymentType4.SelectedIndex = 0
      PaymentType5.HoldFields() : PaymentType5.AddItem("* None;;;") : PaymentType5.SelectedIndex = 0

      While TMPRecord.Read()

        If IsDBNull(TMPRecord.Item("PAYMENTTYPEISREFUNDABLE")) = True Then
          isPaymentRefundable = "0"
        Else
          isPaymentRefundable = CStr(TMPRecord.Item("PAYMENTTYPEISREFUNDABLE"))
        End If

        PaymentType1.AddItem(TMPRecord.Item("PAYMENTTYPENAME") & ";" & TMPRecord.Item("PAYMENTTYPEUID") & ";" & TMPRecord.Item("ISCREDITCARDORCHEQUE") & ";" & isPaymentRefundable)

        If Val(TMPRecord.Item("ISCREDITCARDORCHEQUE")) <> 6 Then
          PaymentType2.AddItem(TMPRecord.Item("PAYMENTTYPENAME") & ";" & TMPRecord.Item("PAYMENTTYPEUID") & ";" & TMPRecord.Item("ISCREDITCARDORCHEQUE") & ";" & isPaymentRefundable)
          PaymentType3.AddItem(TMPRecord.Item("PAYMENTTYPENAME") & ";" & TMPRecord.Item("PAYMENTTYPEUID") & ";" & TMPRecord.Item("ISCREDITCARDORCHEQUE") & ";" & isPaymentRefundable)
          PaymentType4.AddItem(TMPRecord.Item("PAYMENTTYPENAME") & ";" & TMPRecord.Item("PAYMENTTYPEUID") & ";" & TMPRecord.Item("ISCREDITCARDORCHEQUE") & ";" & isPaymentRefundable)
          PaymentType5.AddItem(TMPRecord.Item("PAYMENTTYPENAME") & ";" & TMPRecord.Item("PAYMENTTYPEUID") & ";" & TMPRecord.Item("ISCREDITCARDORCHEQUE") & ";" & isPaymentRefundable)
        End If


        If CInt(TMPRecord.Item("PAYMENTTYPEDEFAULT")) = 1 Then foundDefaultPayment = True
      End While

    Catch ex As Exception

    End Try
    TMPRecord = Nothing
  End Sub

  Private Sub PaymentTypeBehaviour(ByVal paymentType As String)
    TmrLoadRFID.Enabled = False
    Select Case paymentType
      Case "PaymentType1"
        'Call CardInfo_Locked(1, True)
        If PaymentType1.SelectedIndex > 0 Then
          Payment1.Enabled = True
          VirtualCalculator1.Enabled = True
          If PaymentType1.Columns(2).Text = "1" Then
            CardInfo1.Visible = True
            'CardOwner1.Focus()
          ElseIf PaymentType1.Columns(2).Text = "6" Then
            If RFID_HardwareID() = "" Then
              ShowMessage(Me, "Maaf Scanner Tidak Terpasang")
              TmrLoadRFID.Enabled = False
              PaymentType1.SelectedIndex = 1
            Else
              TmrLoadRFID.Enabled = True
              CardInfo1.Visible = True
              CardOwner1.Focus()
              Payment1.Enabled = False
              VirtualCalculator1.Enabled = False
              CardOwner1.Enabled = False
              CardNumber1.Enabled = False
              BankName1.Enabled = False
              VirtualKeyCO1.Enabled = False
              VirtualKeyCN1.Enabled = False
              VirtualKeyBN1.Enabled = False
            End If

            'Call CardInfo_Locked(1, False)
          Else
            CardInfo1.Visible = False
          End If
          Payment1.Text = CDec(Payment1.Text) + CDec(RestTxt.Text)
        Else
          Payment1.Text = "0"
          CardOwner1.Text = ""
          CardNumber1.Text = ""
          BankName1.Text = ""
          Payment1.Enabled = False
          VirtualCalculator1.Enabled = False
          CardInfo1.Visible = False
        End If
      Case "PaymentType2"
        'Call CardInfo_Locked(2, True)
        If PaymentType2.SelectedIndex > 0 Then
          Payment2.Enabled = True
          VirtualCalculator2.Enabled = True
          If PaymentType2.Columns(2).Text = "1" Then
            CardInfo2.Visible = True
            'CardOwner2.Focus()
          ElseIf PaymentType2.Columns(2).Text = "6" Then
            CardInfo2.Visible = True
            CardOwner2.Focus()
            'Call CardInfo_Locked(2, False)
          Else
            CardInfo2.Visible = False
          End If
          Payment2.Text = CDec(Payment2.Text) + CDec(RestTxt.Text)
        Else
          Payment2.Text = "0"
          CardOwner2.Text = ""
          CardNumber2.Text = ""
          BankName2.Text = ""
          Payment2.Enabled = False
          VirtualCalculator2.Enabled = False
          CardInfo2.Visible = False
        End If
      Case "PaymentType3"
        'Call CardInfo_Locked(3, True)
        If PaymentType3.SelectedIndex > 0 Then
          Payment3.Enabled = True
          VirtualCalculator3.Enabled = True
          If PaymentType3.Columns(2).Text = "1" Then
            CardInfo3.Visible = True
            CardOwner3.Focus()
          ElseIf PaymentType3.Columns(2).Text = "6" Then
            CardInfo3.Visible = True
            'CardOwner3.Focus()
            'Call CardInfo_Locked(3, False)
          Else
            CardInfo3.Visible = False
          End If
          Payment3.Text = CDec(Payment3.Text) + CDec(RestTxt.Text)
        Else
          Payment3.Text = "0"
          CardOwner3.Text = ""
          CardNumber3.Text = ""
          BankName3.Text = ""
          Payment3.Enabled = False
          VirtualCalculator3.Enabled = False
          CardInfo3.Visible = False
        End If
      Case "PaymentType4"
        'Call CardInfo_Locked(4, True)
        If PaymentType4.SelectedIndex > 0 Then
          Payment4.Enabled = True
          VirtualCalculator4.Enabled = True
          If PaymentType4.Columns(2).Text = "1" Then
            CardInfo4.Visible = True
            'CardOwner4.Focus()
          ElseIf PaymentType4.Columns(2).Text = "6" Then
            CardInfo4.Visible = True
            CardOwner4.Focus()
            'Call CardInfo_Locked(4, False)
          Else
            CardInfo4.Visible = False
          End If
          Payment4.Text = CDec(Payment4.Text) + CDec(RestTxt.Text)
        Else
          Payment4.Text = "0"
          CardOwner4.Text = ""
          CardNumber4.Text = ""
          BankName4.Text = ""
          Payment4.Enabled = False
          VirtualCalculator4.Enabled = False
          CardInfo4.Visible = False
        End If
      Case "PaymentType5"
        'Call CardInfo_Locked(5, True)
        If PaymentType5.SelectedIndex > 0 Then
          Payment5.Enabled = True
          VirtualCalculator5.Enabled = True
          If PaymentType5.Columns(2).Text = "1" Then
            CardInfo5.Visible = True
            'CardOwner5.Focus()
          ElseIf PaymentType5.Columns(2).Text = "6" Then
            CardInfo5.Visible = True
            CardOwner5.Focus()
            'Call CardInfo_Locked(5, False)
          Else
            CardInfo5.Visible = False
          End If
          Payment5.Text = CDec(Payment5.Text) + CDec(RestTxt.Text)
        Else
          Payment5.Text = "0"
          CardOwner5.Text = ""
          CardNumber5.Text = ""
          BankName5.Text = ""
          Payment5.Enabled = False
          VirtualCalculator5.Enabled = False
          CardInfo5.Visible = False
        End If
    End Select
  End Sub

  Private Function GetTransactionCode(ByVal TableUID As String)
    Dim TMPRecord As FbDataReader
    TMPRecord = MyDatabase.MyReader("SELECT TABLEMBTRANSUID FROM TABLELIST WHERE TABLELISTUID = '" & TableUID & "'")
    If TMPRecord.Read() Then
      If IsDBNull(TMPRecord.Item("TABLEMBTRANSUID")) Then
        Return Nothing
      Else
        Return TMPRecord.Item("TABLEMBTRANSUID")
      End If
    End If
    Return Nothing
  End Function

  Private Function GetTransactionNo(ByVal PBTransMBTransUID As String)
    Dim TMPRecord As FbDataReader
    TMPRecord = MyDatabase.MyReader("SELECT MBTRANSNO FROM MBTRANS WHERE MBTRANSUID='" & PBTransMBTransUID & "'")
    If TMPRecord.Read() Then
      If IsDBNull(TMPRecord.Item("MBTRANSNO")) Then
        Return Nothing
      Else
        Return TMPRecord.Item("MBTRANSNO")
      End If
    End If

    Return Nothing
  End Function

  Private Sub SaveDetailNewPB(ByVal inputPBTransUID As String)
    Dim Query As String = Nothing
    Dim LastDtID As String
    If PaymentType1.SelectedIndex > 0 Then
      LastDtID = AutoUID()
      Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType1.Columns(1).Text & "','" & ReplacePetik(CardNumber1.Text) & "','" & ReplacePetik(CardOwner1.Text) & "','" & ReplacePetik(BankName1.Text) & "','" & CDbl(Payment1.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
      Call MyDatabase.MyAdapter(Query)

      'If t = 1 Then
      '    Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
      '              "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType1.Columns(1).Text & "','" & ReplacePetik(CardNumber1.Text) & "','" & ReplacePetik(CardOwner1.Text) & "','" & ReplacePetik(BankName1.Text) & "','" & CDbl(Payment1.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
      '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
      'End If
    End If

    If PaymentType2.SelectedIndex > 0 Then
      LastDtID = AutoUID()
      Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType2.Columns(1).Text & "','" & ReplacePetik(CardNumber2.Text) & "','" & ReplacePetik(CardOwner2.Text) & "','" & ReplacePetik(BankName2.Text) & "','" & CDbl(Payment2.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
      Call MyDatabase.MyAdapter(Query)

      'If t = 1 Then
      '    Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
      '            "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType2.Columns(1).Text & "','" & ReplacePetik(CardNumber2.Text) & "','" & ReplacePetik(CardOwner2.Text) & "','" & ReplacePetik(BankName2.Text) & "','" & CDbl(Payment2.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
      '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
      'End If
    End If

    If PaymentType3.SelectedIndex > 0 Then
      LastDtID = AutoUID()
      Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType3.Columns(1).Text & "','" & ReplacePetik(CardNumber3.Text) & "','" & ReplacePetik(CardOwner3.Text) & "','" & ReplacePetik(BankName3.Text) & "','" & CDbl(Payment3.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
      Call MyDatabase.MyAdapter(Query)

      'If t = 1 Then
      '    Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
      '               "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType3.Columns(1).Text & "','" & ReplacePetik(CardNumber3.Text) & "','" & ReplacePetik(CardOwner3.Text) & "','" & ReplacePetik(BankName3.Text) & "','" & CDbl(Payment3.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
      '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
      'End If
    End If

    If PaymentType4.SelectedIndex > 0 Then
      LastDtID = AutoUID()
      Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType4.Columns(1).Text & "','" & ReplacePetik(CardNumber4.Text) & "','" & ReplacePetik(CardOwner4.Text) & "','" & ReplacePetik(BankName4.Text) & "','" & CDbl(Payment4.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
      Call MyDatabase.MyAdapter(Query)

      'If t = 1 Then
      '    Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
      '                  "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType4.Columns(1).Text & "','" & ReplacePetik(CardNumber4.Text) & "','" & ReplacePetik(CardOwner4.Text) & "','" & ReplacePetik(BankName4.Text) & "','" & CDbl(Payment4.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
      '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
      'End If
    End If

    If PaymentType5.SelectedIndex > 0 Then
      LastDtID = AutoUID()
      Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType5.Columns(1).Text & "','" & ReplacePetik(CardNumber5.Text) & "','" & ReplacePetik(CardOwner5.Text) & "','" & ReplacePetik(BankName5.Text) & "','" & CDbl(Payment5.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
      Call MyDatabase.MyAdapter(Query)

      'If t = 1 Then
      '    Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
      '          "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType5.Columns(1).Text & "','" & ReplacePetik(CardNumber5.Text) & "','" & ReplacePetik(CardOwner5.Text) & "','" & ReplacePetik(BankName5.Text) & "','" & CDbl(Payment5.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
      '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
      'End If
    End If
  End Sub

  Private Sub SaveDetailExistingPB(ByVal inputPBTransUID As String)
    Dim arrayDetailToBeDeleted() As String
    Dim i As Integer
    Dim LastDtID As String
    Dim Query As String = ""
    Dim itemToDel As String = ""


    Dim TMPRecord As FbDataReader
    TMPRecord = MyDatabase.MyReader("SELECT PBTransDtUID FROM PBTransDt WHERE PBTransUID = '" & inputPBTransUID & "'")
    While TMPRecord.Read
      If DoesItemExistInGrid(TMPRecord.Item("PBTransDtUID")) = False Then
        itemToDel = itemToDel & MY_DELIMITER & TMPRecord.Item("PBTransDtUID")
      End If
    End While

    'Hapus item DB yang tidak ada di Grid
    If Len(Trim(itemToDel)) > 0 Then
      arrayDetailToBeDeleted = Split(itemToDel, MY_DELIMITER)
      For i = 0 To UBound(arrayDetailToBeDeleted)
        If Len(Trim(CStr(arrayDetailToBeDeleted(i)))) > 0 Then
          Call MyDatabase.MyAdapter("DELETE FROM PBTRANSDT WHERE PBTRANSDTUID = '" & arrayDetailToBeDeleted(i) & "'")
        End If
      Next
    End If

    If PaymentType1.SelectedIndex > 0 Then
      If Len(Trim(Label_PBTRANSDTUID1.Text)) = 0 Then
        LastDtID = AutoUID()
        Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                  "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType1.Columns(1).Text & "','" & ReplacePetik(CardNumber1.Text) & "','" & ReplacePetik(CardOwner1.Text) & "','" & ReplacePetik(BankName1.Text) & "','" & CDbl(Payment1.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
        Call MyDatabase.MyAdapter(Query)
      Else
        Query = "UPDATE PBTRANSDT SET  PAYMENTTYPEUID = '" & PaymentType1.Columns(1).Text & "', VISAORCHEQUENUMBER ='" & ReplacePetik(CardNumber1.Text) & "', VISAORCHEQUENAME ='" & ReplacePetik(CardOwner1.Text) & "', VISAORCHEQUEBANKNAME ='" & ReplacePetik(BankName1.Text) & "', PBTRANSDTSUBVAL='" & CDbl(Payment1.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSDTUID ='" & Label_PBTRANSDTUID1.Text & "'"
        Call MyDatabase.MyAdapter(Query)
      End If
    End If

    If PaymentType2.SelectedIndex > 0 Then
      If Len(Trim(Label_PBTRANSDTUID2.Text)) = 0 Then
        LastDtID = AutoUID()
        Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                  "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType2.Columns(1).Text & "','" & ReplacePetik(CardNumber2.Text) & "','" & ReplacePetik(CardOwner2.Text) & "','" & ReplacePetik(BankName2.Text) & "','" & CDbl(Payment2.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
        Call MyDatabase.MyAdapter(Query)
      Else
        Query = "UPDATE PBTRANSDT SET  PAYMENTTYPEUID = '" & PaymentType2.Columns(1).Text & "', VISAORCHEQUENUMBER ='" & ReplacePetik(CardNumber2.Text) & "', VISAORCHEQUENAME ='" & ReplacePetik(CardOwner2.Text) & "', VISAORCHEQUEBANKNAME ='" & ReplacePetik(BankName2.Text) & "', PBTRANSDTSUBVAL='" & CDbl(Payment2.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSDTUID ='" & Label_PBTRANSDTUID2.Text & "'"
        Call MyDatabase.MyAdapter(Query)
      End If
    End If

    If PaymentType3.SelectedIndex > 0 Then
      If Len(Trim(Label_PBTRANSDTUID3.Text)) = 0 Then
        LastDtID = AutoUID()
        Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                  "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType3.Columns(1).Text & "','" & ReplacePetik(CardNumber3.Text) & "','" & ReplacePetik(CardOwner3.Text) & "','" & ReplacePetik(BankName3.Text) & "','" & CDbl(Payment3.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
        Call MyDatabase.MyAdapter(Query)
      Else
        Query = "UPDATE PBTRANSDT SET  PAYMENTTYPEUID = '" & PaymentType3.Columns(1).Text & "', VISAORCHEQUENUMBER ='" & ReplacePetik(CardNumber3.Text) & "', VISAORCHEQUENAME ='" & ReplacePetik(CardOwner3.Text) & "', VISAORCHEQUEBANKNAME ='" & ReplacePetik(BankName3.Text) & "', PBTRANSDTSUBVAL='" & CDbl(Payment3.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSDTUID ='" & Label_PBTRANSDTUID3.Text & "'"
        Call MyDatabase.MyAdapter(Query)
      End If
    End If

    If PaymentType4.SelectedIndex > 0 Then
      If Len(Trim(Label_PBTRANSDTUID4.Text)) = 0 Then
        LastDtID = AutoUID()
        Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                  "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType4.Columns(1).Text & "','" & ReplacePetik(CardNumber4.Text) & "','" & ReplacePetik(CardOwner4.Text) & "','" & ReplacePetik(BankName4.Text) & "','" & CDbl(Payment4.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
        Call MyDatabase.MyAdapter(Query)
      Else
        Query = "UPDATE PBTRANSDT SET  PAYMENTTYPEUID = '" & PaymentType4.Columns(1).Text & "', VISAORCHEQUENUMBER ='" & ReplacePetik(CardNumber4.Text) & "', VISAORCHEQUENAME ='" & ReplacePetik(CardOwner4.Text) & "', VISAORCHEQUEBANKNAME ='" & ReplacePetik(BankName4.Text) & "', PBTRANSDTSUBVAL='" & CDbl(Payment4.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSDTUID ='" & Label_PBTRANSDTUID4.Text & "'"
        Call MyDatabase.MyAdapter(Query)
      End If
    End If

    If PaymentType5.SelectedIndex > 0 Then
      If Len(Trim(Label_PBTRANSDTUID5.Text)) = 0 Then
        LastDtID = AutoUID()
        Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                  "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType5.Columns(1).Text & "','" & ReplacePetik(CardNumber5.Text) & "','" & ReplacePetik(CardOwner5.Text) & "','" & ReplacePetik(BankName5.Text) & "','" & CDbl(Payment5.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
        Call MyDatabase.MyAdapter(Query)
      Else
        Query = "UPDATE PBTRANSDT SET  PAYMENTTYPEUID = '" & PaymentType5.Columns(1).Text & "', VISAORCHEQUENUMBER ='" & ReplacePetik(CardNumber5.Text) & "', VISAORCHEQUENAME ='" & ReplacePetik(CardOwner5.Text) & "', VISAORCHEQUEBANKNAME ='" & ReplacePetik(BankName5.Text) & "', PBTRANSDTSUBVAL='" & CDbl(Payment5.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSDTUID ='" & Label_PBTRANSDTUID5.Text & "'"
        Call MyDatabase.MyAdapter(Query)
      End If
    End If

  End Sub

  Private Function DoesItemExistInGrid(ByVal inputPBTransDtUid As String) As Boolean
    Dim retval As Boolean = False

    If PaymentType1.SelectedIndex > 0 Then
      If Label_PBTRANSDTUID1.Text = inputPBTransDtUid Then
        retval = True
      End If
    End If
    If PaymentType2.SelectedIndex > 0 Then
      If Label_PBTRANSDTUID2.Text = inputPBTransDtUid Then
        retval = True
      End If
    End If
    If PaymentType3.SelectedIndex > 0 Then
      If Label_PBTRANSDTUID3.Text = inputPBTransDtUid Then
        retval = True
      End If
    End If
    If PaymentType4.SelectedIndex > 0 Then
      If Label_PBTRANSDTUID4.Text = inputPBTransDtUid Then
        retval = True
      End If
    End If
    If PaymentType5.SelectedIndex > 0 Then
      If Label_PBTRANSDTUID5.Text = inputPBTransDtUid Then
        retval = True
      End If
    End If
    DoesItemExistInGrid = retval
  End Function

  Private Sub ShowPaymentChangePreview(Optional ByVal Nota As Boolean = False)

    Dim OBJNew As New Form_Print_Preview
    Dim Query As String = Nothing

    publicUseChange = True
    publicPayment1 = Payment1.Text
    publicPayment2 = Payment2.Text
    publicPayment3 = Payment3.Text
    publicPayment4 = Payment4.Text
    publicPayment5 = Payment5.Text
    publicPaymentChange = ChangeTxt.Text
    publicPaymentRest = RestTxt.Text

    '18 Juni 2012 - Weird, query palsu, buat pancingan aja
    Query = "SELECT * FROM POSPREF "

    OBJNew.Name = "Form_Print_Preview"
    OBJNew.RPTTitle = "Payment"
    If PrefInfo.printSize = "58" Then
      Make_Payment_Change58.TransactionUID = MBTransUID
      OBJNew.RPTDocument = New Make_Payment_Change58
    Else
      Make_Payment_Change.TransactionUID = MBTransUID
      OBJNew.RPTDocument = New Make_Payment_Change
    End If
    OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
    OBJNew.VersiNota = Nota
    OBJNew.ShowDialog()

  End Sub

  Private Sub ShowMakeBillPaymentPreview(Optional ByVal Nota As Boolean = False)

    Dim OBJNew As New Form_Print_Preview
    Dim Query As String = Nothing

    'Make_Bill_Payment.TransactionUID = TransactionUID
    Make_Bill_Payment.TransactionUID = MBTransUID
    publicUseChange = True
    publicPayment1 = Payment1.Text
    publicPayment2 = Payment2.Text
    publicPayment3 = Payment3.Text
    publicPayment4 = Payment4.Text
    publicPayment5 = Payment5.Text
    publicPaymentChange = ChangeTxt.Text
    publicPaymentRest = RestTxt.Text

    '18 Juni 2012 - Weird, query palsu, buat pancingan aja
    Query = "SELECT * FROM POSPREF "

    OBJNew.Name = "Form_Print_Preview"
    OBJNew.RPTTitle = "Payment"
    If PrefInfo.printSize = "58" Then
      OBJNew.RPTDocument = New Make_Bill_Payment58
    Else
      OBJNew.RPTDocument = New Make_Bill_Payment
    End If
    OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
    OBJNew.VersiNota = Nota
    OBJNew.ShowDialog()

  End Sub

  Private Sub ShowPrintPreview(Optional ByVal Nota As Boolean = False)
    Dim OBJNew As New Form_Print_Preview
    Dim Query As String

    Query = "SELECT PB.PBTRANSUID, PB.PBTRANSNO, PB.PBTRANSDATE, PB.PBTRANSMBTRANSUID, PB.PBTRANSMODULETYPEID, " & _
    "MB.MBTRANSNO, MB.MBTRANSDATE, MB.MBTRANSSUBVAL,MB.MBTRANSPAXVAL,PB.PBTRANSCUSTUID, " & _
    "C.CUSTNAME AS SELECTEDCUSTNAME, PB.PBTRANSCUSTNAME, PB.PBTRANSTABLELISTUID, T.TABLELISTNAME AS SELECTEDTABLELISTNAME, " & _
    "PB.PBTRANSTOTVAL AS PAY,PB.PRINTCOUNTER,PB.ISFISCAL,PB.CREATEDUSER,PB.MODIFIEDUSER " & _
    "FROM PBTRANS PB " & _
    "LEFT OUTER JOIN MBTRANS MB ON PB.PBTRANSMBTRANSUID = MB.MBTRANSUID " & _
    "LEFT OUTER JOIN TABLELIST T ON T.TABLELISTUID=PB.PBTRANSTABLELISTUID " & _
    "LEFT OUTER JOIN CUST C ON C.CUSTUID=PB.PBTRANSCUSTUID " & _
    "WHERE PB.PBTRANSSTAT <> -1 AND PB.PBTRANSMODULETYPEID='2206' AND PB.PBTRANSMBTRANSUID = '" & MBTransUID & "'"

    OBJNew.Name = "Form_Print_Preview"
    OBJNew.RPTTitle = "Payment Rest"
    If PrefInfo.printSize = "58" Then
      OBJNew.RPTDocument = New Payment58
    Else
      OBJNew.RPTDocument = New Payment
    End If
    OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
    OBJNew.VersiNota = Nota
    OBJNew.ShowDialog()
  End Sub

  Public Sub BringTransactionInfo(ByVal MBTUID As String)
    Dim CurRSV As Integer = TransactionList.FindString(MBTUID, 0, 1)
    TransactionList.SelectedIndex = CurRSV
  End Sub

  Private Sub UpdateIsRefundable(ByVal ISPBTRANSUID As String, ByVal Deviation As Decimal)
    Dim TMPRecord As FbDataReader
    Dim Query As String
    Dim PaymentValue As Decimal
    Dim ISPBTRANSDTUID As String

    Query = "SELECT * FROM PBTRANS P LEFT OUTER JOIN PBTRANSDT PDT ON PDT.PBTRANSUID=P.PBTRANSUID LEFT OUTER JOIN PAYMENTTYPE PT ON PT.PAYMENTTYPEUID=PDT.PAYMENTTYPEUID WHERE P.PBTRANSMODULETYPEID='2206' AND PT.PAYMENTTYPEISREFUNDABLE=1 AND P.PBTRANSUID='" & ISPBTRANSUID & "'"
    TMPRecord = MyDatabase.MyReader(Query)

    If TMPRecord.Read() Then
      ISPBTRANSDTUID = TMPRecord.Item("PBTRANSDTUID")
      PaymentValue = CDec(TMPRecord.Item("PBTRANSDTSUBVAL")) - Deviation

      Query = "UPDATE PBTRANSDT SET PBTRANSDTSUBVAL='" & PaymentValue & "' WHERE PBTRANSDTUID='" & ISPBTRANSDTUID & "'"
      Call MyDatabase.MyAdapter(Query)

      'If t = 1 Then
      '    Query = "UPDATE PBTRANSDT SET PBTRANSDTSUBVAL='" & PaymentValue & "' WHERE PBTRANSDTUID='" & ISPBTRANSDTUID & "'"
      '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
      'End If
    Else
      ShowMessage(Me, "Maaf, tipe pembayaran ini tidak dapat direfund, silakan pastikan nilai pembayaran sama dengan nilai tagihan !")
      ExitIsRefundable = True

      Exit Sub
    End If
  End Sub
#End Region

#Region "Form Control Function"

  Private Sub Form_Debt_Payment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If screenWidth < 1024 Then
      Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y)
      Dim origWidth As Integer = Me.Width
      Dim origHeight As Integer = Me.Height
      Me.Width = screenWidth
      Me.Height = screenHeight
      Dim fSize As New SizeF((Me.Width / origWidth), (Me.Height / origHeight))
      GroupBox1.Scale(fSize)
      MainArea.Scale(fSize)
      GroupBox4.Scale(fSize)
      BTNCancel.Scale(fSize)
      BTNSave.Scale(fSize)
    Else
      Me.Location = New System.Drawing.Point(MainPage.Location.X + 270, MainPage.Location.Y + 44)
    End If

    Me.Cursor = Cursors.Default
    Call Basicinitialize()
  End Sub

  Private Sub TransactionList_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles TransactionList.Change
    'Call DBInitialize()
  End Sub

  Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancel.Click
    'Call ParentOBJForm.BasicInitialize(MBTransUID)
    'ShowPoleDisplay(PrefInfo.Header)

    Form_Custm_Display_MakeBill.refOrder()
    Me.Close()
  End Sub

  Private Sub VirtualKeyCO(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKeyCO1.Click, VirtualKeyCO2.Click, VirtualKeyCO3.Click, VirtualKeyCO4.Click, VirtualKeyCO5.Click
    Me.Cursor = Cursors.WaitCursor
    Dim VirtuKey As New VirtualKey
    Select Case sender.name
      Case "VirtualKeyCO1"
        VirtuKey.OBJBind(CardOwner1, False)
      Case "VirtualKeyCO2"
        VirtuKey.OBJBind(CardOwner2, False)
      Case "VirtualKeyCO3"
        VirtuKey.OBJBind(CardOwner3, False)
      Case "VirtualKeyCO4"
        VirtuKey.OBJBind(CardOwner4, False)
      Case "VirtualKeyCO5"
        VirtuKey.OBJBind(CardOwner5, False)
    End Select
    VirtuKey.ShowDialog()
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub VirtualKeyCN(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKeyCN1.Click, VirtualKeyCN2.Click, VirtualKeyCN3.Click, VirtualKeyCN4.Click, VirtualKeyCN5.Click
    Me.Cursor = Cursors.WaitCursor
    Dim VirtuKey As New VirtualKey
    Select Case sender.name
      Case "VirtualKeyCN1"
        VirtuKey.OBJBind(CardNumber1, False)
      Case "VirtualKeyCN2"
        VirtuKey.OBJBind(CardNumber2, False)
      Case "VirtualKeyCN3"
        VirtuKey.OBJBind(CardNumber3, False)
      Case "VirtualKeyCN4"
        VirtuKey.OBJBind(CardNumber4, False)
      Case "VirtualKeyCN5"
        VirtuKey.OBJBind(CardNumber5, False)
    End Select
    VirtuKey.ShowDialog()
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub VirtualKeyBN(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKeyBN1.Click, VirtualKeyBN2.Click, VirtualKeyBN3.Click, VirtualKeyBN4.Click, VirtualKeyBN5.Click
    Me.Cursor = Cursors.WaitCursor
    Dim VirtuKey As New VirtualKey
    Select Case sender.name
      Case "VirtualKeyBN1"
        VirtuKey.OBJBind(BankName1, False)
      Case "VirtualKeyBN2"
        VirtuKey.OBJBind(BankName2, False)
      Case "VirtualKeyBN3"
        VirtuKey.OBJBind(BankName3, False)
      Case "VirtualKeyBN4"
        VirtuKey.OBJBind(BankName4, False)
      Case "VirtualKeyBN5"
        VirtuKey.OBJBind(BankName5, False)
    End Select
    VirtuKey.ShowDialog()
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click

    

    ExitIsRefundable = False

    Dim Query As String = Nothing

    If CDec(Payment1.Text) <> 0 Then
      If PaymentType1.SelectedIndex = 0 Then
        ShowMessage("Me", "Silakan pilih metode pembayaran !")
        MainArea.SelectedTab = PaymentType
        PaymentType1.Focus()
        Exit Sub
      End If
    End If

    If CDec(Payment2.Text) <> 0 Then
      If PaymentType2.SelectedIndex = 0 Then
        ShowMessage("Me", "Silakan pilih metode pembayaran !")
        MainArea.SelectedTab = C1DockingTabPage2
        PaymentType2.Focus()
        Exit Sub
      End If
    End If

    If CDec(Payment3.Text) <> 0 Then
      If PaymentType3.SelectedIndex = 0 Then
        ShowMessage("Me", "Silakan pilih metode pembayaran !")
        MainArea.SelectedTab = C1DockingTabPage3
        PaymentType3.Focus()
        Exit Sub
      End If
    End If

    If CDec(Payment4.Text) <> 0 Then
      If PaymentType4.SelectedIndex = 0 Then
        ShowMessage("Me", "Silakan pilih metode pembayaran !")
        MainArea.SelectedTab = CmdFindRFID4
        PaymentType4.Focus()
        Exit Sub
      End If
    End If

    If CDec(Payment5.Text) <> 0 Then
      If PaymentType5.SelectedIndex = 0 Then
        ShowMessage("Me", "Silakan pilih metode pembayaran !")
        MainArea.SelectedTab = C1DockingTabPage5
        PaymentType5.Focus()
        Exit Sub
      End If
    End If

    If CDec(Payment5.Text) <> 0 Then
      If CDec(Payment4.Text) = 0 Then
        ShowMessage("Me", "Silakan isikan metode pembayaran 4 !")
        MainArea.SelectedTab = CmdFindRFID4
        PaymentType4.Focus()
        Exit Sub
      End If
    End If

    If CDec(Payment4.Text) <> 0 Then
      If CDec(Payment3.Text) = 0 Then
        ShowMessage("Me", "Silakan isikan metode pembayaran 3 !")
        MainArea.SelectedTab = C1DockingTabPage3
        PaymentType3.Focus()
        Exit Sub
      End If
    End If

    If CDec(Payment3.Text) <> 0 Then
      If CDec(Payment2.Text) = 0 Then
        ShowMessage("Me", "Silakan isikan metode pembayaran 2 !")
        MainArea.SelectedTab = C1DockingTabPage2
        PaymentType2.Focus()
        Exit Sub
      End If
    End If

    If CDec(Payment2.Text) <> 0 Then
      If CDec(Payment1.Text) = 0 Then
        ShowMessage("Me", "Silakan isikan metode pembayaran 1 !")
        MainArea.SelectedTab = PaymentType
        PaymentType1.Focus()
        Exit Sub
      End If
    End If

    If PaymentType1.Columns(2).Text = "1" Then
      If CardOwner1.Text = Nothing Or CardNumber1.Text = Nothing Or BankName1.Text = Nothing Then
        ShowMessage(Me, "Maaf, detail credit card (Card Owner, Card Number, Bank Name) tidak boleh kosong !")
        MainArea.SelectedTab = PaymentType
        If CardOwner1.Text = Nothing Then
          CardOwner1.Focus()
        ElseIf CardNumber1.Text = Nothing Then
          CardNumber1.Focus()
        ElseIf BankName1.Text = Nothing Then
          BankName1.Focus()
        End If
        Exit Sub
      End If
    End If
    If PaymentType2.Columns(2).Text = "1" Then
      If CardOwner2.Text = Nothing Or CardNumber2.Text = Nothing Or BankName2.Text = Nothing Then
        ShowMessage(Me, "Maaf, detail credit card (Card Owner, Card Number, Bank Name) tidak boleh kosong !")
        MainArea.SelectedTab = C1DockingTabPage2
        If CardOwner2.Text = Nothing Then
          CardOwner2.Focus()
        ElseIf CardNumber2.Text = Nothing Then
          CardNumber2.Focus()
        ElseIf BankName2.Text = Nothing Then
          BankName2.Focus()
        End If
        Exit Sub
      End If
    End If
    If PaymentType3.Columns(2).Text = "1" Then
      If CardOwner3.Text = Nothing Or CardNumber3.Text = Nothing Or BankName3.Text = Nothing Then
        ShowMessage(Me, "Maaf, detail credit card (Card Owner, Card Number, Bank Name) tidak boleh kosong !")
        MainArea.SelectedTab = C1DockingTabPage3
        If CardOwner3.Text = Nothing Then
          CardOwner3.Focus()
        ElseIf CardNumber3.Text = Nothing Then
          CardNumber3.Focus()
        ElseIf BankName3.Text = Nothing Then
          BankName3.Focus()
        End If
        Exit Sub
      End If
    End If
    If PaymentType4.Columns(2).Text = "1" Then
      If CardOwner4.Text = Nothing Or CardNumber4.Text = Nothing Or BankName4.Text = Nothing Then
        ShowMessage(Me, "Maaf, detail credit card (Card Owner, Card Number, Bank Name) tidak boleh kosong !")
        MainArea.SelectedTab = CmdFindRFID4
        If CardOwner4.Text = Nothing Then
          CardOwner4.Focus()
        ElseIf CardNumber4.Text = Nothing Then
          CardNumber4.Focus()
        ElseIf BankName4.Text = Nothing Then
          BankName4.Focus()
        End If
        Exit Sub
      End If
    End If
    If PaymentType5.Columns(2).Text = "1" Then
      If CardOwner5.Text = Nothing Or CardNumber5.Text = Nothing Or BankName5.Text = Nothing Then
        ShowMessage(Me, "Maaf, detail credit card (Card Owner, Card Number, Bank Name) tidak boleh kosong !")
        MainArea.SelectedTab = C1DockingTabPage5
        If CardOwner5.Text = Nothing Then
          CardOwner5.Focus()
        ElseIf CardNumber5.Text = Nothing Then
          CardNumber5.Focus()
        ElseIf BankName5.Text = Nothing Then
          BankName5.Focus()
        End If
        Exit Sub
      End If
    End If

    CardNumber1.Text = Mid(Replace(Replace(Replace(Replace(CardNumber1.Text, "~", ""), "@", ""), "#", ""), "!", ""), 1, 40)
    CardNumber2.Text = Mid(Replace(Replace(Replace(Replace(CardNumber2.Text, "~", ""), "@", ""), "#", ""), "!", ""), 1, 40)
    CardNumber3.Text = Mid(Replace(Replace(Replace(Replace(CardNumber3.Text, "~", ""), "@", ""), "#", ""), "!", ""), 1, 40)
    CardNumber4.Text = Mid(Replace(Replace(Replace(Replace(CardNumber4.Text, "~", ""), "@", ""), "#", ""), "!", ""), 1, 40)
    CardNumber5.Text = Mid(Replace(Replace(Replace(Replace(CardNumber5.Text, "~", ""), "@", ""), "#", ""), "!", ""), 1, 40)

    CardOwner1.Text = Mid(Replace(Replace(Replace(Replace(CardOwner1.Text, "~", ""), "@", ""), "#", ""), "!", ""), 1, 40)
    CardOwner2.Text = Mid(Replace(Replace(Replace(Replace(CardOwner2.Text, "~", ""), "@", ""), "#", ""), "!", ""), 1, 40)
    CardOwner3.Text = Mid(Replace(Replace(Replace(Replace(CardOwner3.Text, "~", ""), "@", ""), "#", ""), "!", ""), 1, 40)
    CardOwner4.Text = Mid(Replace(Replace(Replace(Replace(CardOwner4.Text, "~", ""), "@", ""), "#", ""), "!", ""), 1, 40)
    CardOwner5.Text = Mid(Replace(Replace(Replace(Replace(CardOwner5.Text, "~", ""), "@", ""), "#", ""), "!", ""), 1, 40)

    BankName1.Text = Mid(Replace(Replace(Replace(Replace(BankName1.Text, "~", ""), "@", ""), "#", ""), "!", ""), 1, 40)
    BankName2.Text = Mid(Replace(Replace(Replace(Replace(BankName2.Text, "~", ""), "@", ""), "#", ""), "!", ""), 1, 40)
    BankName3.Text = Mid(Replace(Replace(Replace(Replace(BankName3.Text, "~", ""), "@", ""), "#", ""), "!", ""), 1, 40)
    BankName4.Text = Mid(Replace(Replace(Replace(Replace(BankName4.Text, "~", ""), "@", ""), "#", ""), "!", ""), 1, 40)
    BankName5.Text = Mid(Replace(Replace(Replace(Replace(BankName5.Text, "~", ""), "@", ""), "#", ""), "!", ""), 1, 40)

    If CDec(RestTxt.Text) > 0 Then
      If MainPage.InvoiceApplication Then
        If PrefInfo.AllowCustomerDebt = True Then
          If ShowQuestion(Me, "Maaf, jumlah pembayaran kurang dari nilai tagihan. Lanjutkan transaksi pembayaran ?") = False Then
            Exit Sub
          End If
        Else
          ShowMessage(Me, "Maaf, jumlah pembayaran kurang dari nilai tagihan !")
          Exit Sub
        End If
      Else
        If ShowQuestion(Me, "Maaf, jumlah pembayaran kurang dari nilai tagihan. Lanjutkan transaksi pembayaran ?") = False Then
          Exit Sub
        End If
      End If
    End If


    Me.Cursor = Cursors.WaitCursor
    Dim LastID = AutoUID()

    'Anjo - 12 Okt 2011, Check apakah ada user lain yang entry pembayaran saat bersamaan
    'dengan cara memastikan nilai total pembayaran lama tidak berubah
    Dim myReader As FbDataReader, dataTetapSama As Boolean = False
    myReader = MyDatabase.MyReader("SELECT MBTRANSPAIDVAL FROM MBTRANS WHERE MBTRANSUID='" & MBTransUID & "'")
    While myReader.Read
      If CDec(myReader.Item("MBTRANSPAIDVAL")) = CDec(oldPaymentVal) Then
        dataTetapSama = True
      Else
        dataTetapSama = False
      End If
    End While

    If dataTetapSama = False Then
      Me.Cursor = Cursors.Default
      ShowMessage(Me, "Maaf, data pembayaran telah dimasukkan oleh user lain, pada saat anda sedang mengedit transaksi ini !")
      ParentOBJForm.close()
      Me.Close()
      Exit Sub
    End If

    Dim TotalPaid As Double
    Dim TotalPaidAll As Double

    If CDec(PaidTxt.Text) > CDec(GrandTotalTxt.Text) Then
      TotalPaidAll = CDec(GrandTotalTxt.Text)
      TotalPaid = CDec(GrandTotalTxt.Text) - Paid
    Else
      TotalPaidAll = CDec(PaidTxt.Text)
      TotalPaid = CDbl(Payment1.Text) + CDbl(Payment2.Text) + CDbl(Payment3.Text) + CDbl(Payment4.Text) + CDbl(Payment5.Text)
    End If

    If CDec(PaidTxt.Text) > CDec(GrandTotalTxt.Text) Then
      Dim Selisih As Decimal
      Selisih = CDec(PaidTxt.Text) - CDec(GrandTotalTxt.Text)

      If Selisih > 0 Then
        If CheckAdaPembayaranRefundable() = False Then
          Me.Cursor = Cursors.Default
          ShowMessage(Me, "Maaf, tipe pembayaran yang anda pilih adalah non-refundable, silakan pastikan jumlah pembayaran sama dengan jumlah bill tagihan !")
          Exit Sub
        End If
      End If
    End If

    If PaymentType1.Columns(0).Text = "e-Payment" Then
      Dim VRFIDData() As String
      Dim VTempS As String
      Dim VDataKartu As String
      Try
        If RFID120U_IsCardConnect() = True Then
          VDataKartu = ACR120U_GetInfo()
          VRFIDData = Split(VDataKartu, "||")
          If VRFIDData(1) = CardNumber1.Text Then
            VTempS = CDbl(ChangeTxt.Text)
            VTempS = VTempS & "||" & VRFIDData(1)
            VTempS = VTempS & "||" & VRFIDData(2)
            VTempS = VTempS & "||" & VRFIDData(3)
            VTempS = VTempS & "||" & Format(DateAdd(DateInterval.Day, 10, Now()), VDateFormatSys)
            VTempS = VTempS & "||"
            Call ACR120U_WriteInfo(VTempS)
            NameCustLabel.Text = VRFIDData(2)
            CatCustLabel.Text = VRFIDData(2)
          Else
            Exit Sub
          End If
        End If
      Catch ex As Exception
        Me.Cursor = Cursors.Default
        ShowMessage(Me, "Maaf, Gagal menyimpan data di kartu NFC")
        Exit Sub
      End Try
    End If
    If NewTransaction = False Then
      If PaymentType1.Columns(2).Text = "6" Then
        Dim VCustUID As String = GetFieldValueDBString("CUST", "CUSTUID", "WHERE CUSTNO='" & CardNumber1.Text & "'")
        If VCustUID.Trim() <> "" Then
          Query = "UPDATE MBTRANS SET MBTRANSCUSTUID = '" & VCustUID & "', MBTRANSCUSTNAME ='" & CardOwner1.Text & "', MBTRANSPAIDVAL = '" & TotalPaidAll & "' WHERE MBTRANSUID = '" & MBTransUID & "'"
        Else
          Query = "UPDATE MBTRANS SET MBTRANSPAIDVAL = '" & TotalPaidAll & "' WHERE MBTRANSUID = '" & MBTransUID & "'"
        End If
        Call MyDatabase.MyAdapter(Query)
      Else
        Query = "UPDATE MBTRANS SET MBTRANSPAIDVAL = '" & TotalPaidAll & "' WHERE MBTRANSUID = '" & MBTransUID & "'"
        Call MyDatabase.MyAdapter(Query)
      End If
      'Call MyDatabase.MyAdapter(Query)

      If CDec(PaidTxt.Text) < CDec(GrandTotalTxt.Text) Then
        'add 27-12-2016

        If PaymentType1.Columns(2).Text = "6" Then
          Dim VCustUID As String = GetFieldValueDBString("CUST", "CUSTUID", "WHERE CUSTNO='" & CardNumber1.Text & "'")
          If VCustUID.Trim() <> "" Then
            Query = "UPDATE PBTRANS SET PBTRANSNO ='" & PaymentNo.Text & "',PBTRANSSTAT = 2, PBTRANSDATE ='" & Format(PaymentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "', PBTRANSDEPTUID ='" & DeptInfo.DeptUID & "', PBTRANSMODULETYPEID = '2206', PBTRANSMBTRANSUID ='" & tvMBTransUID & "', PBTRANSCUSTUID ='" & VCustUID & "', PBTRANSCUSTNAME ='" & CardOwner1.Text & "', PBTRANSTABLELISTUID ='" & tvTableUID & "', PBTRANSTOTVAL ='" & TotalPaid & "', MODIFIEDUSER ='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "', ISFISCAL='" & t & "' WHERE PBTRANSUID ='" & TransactionUID & "'"
          Else
            Query = "UPDATE PBTRANS SET PBTRANSNO ='" & PaymentNo.Text & "',PBTRANSSTAT = 2, PBTRANSDATE ='" & Format(PaymentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "', PBTRANSDEPTUID ='" & DeptInfo.DeptUID & "', PBTRANSMODULETYPEID = '2206', PBTRANSMBTRANSUID ='" & tvMBTransUID & "', PBTRANSCUSTUID ='" & tvCustUID & "', PBTRANSCUSTNAME ='" & CustName.Text & "', PBTRANSTABLELISTUID ='" & tvTableUID & "', PBTRANSTOTVAL ='" & TotalPaid & "', MODIFIEDUSER ='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "', ISFISCAL='" & t & "' WHERE PBTRANSUID ='" & TransactionUID & "'"
          End If
          Call MyDatabase.MyAdapter(Query)
        Else
          Query = "UPDATE PBTRANS SET PBTRANSNO ='" & PaymentNo.Text & "',PBTRANSSTAT = 2, PBTRANSDATE ='" & Format(PaymentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "', PBTRANSDEPTUID ='" & DeptInfo.DeptUID & "', PBTRANSMODULETYPEID = '2206', PBTRANSMBTRANSUID ='" & tvMBTransUID & "', PBTRANSCUSTUID ='" & tvCustUID & "', PBTRANSCUSTNAME ='" & CustName.Text & "', PBTRANSTABLELISTUID ='" & tvTableUID & "', PBTRANSTOTVAL ='" & TotalPaid & "', MODIFIEDUSER ='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "', ISFISCAL='" & t & "' WHERE PBTRANSUID ='" & TransactionUID & "'"
          Call MyDatabase.MyAdapter(Query)
        End If

        'Query = "UPDATE PBTRANS SET PBTRANSNO ='" & PaymentNo.Text & "',PBTRANSSTAT = 2, PBTRANSDATE ='" & Format(PaymentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "', PBTRANSDEPTUID ='" & DeptInfo.DeptUID & "', PBTRANSMODULETYPEID = '2206', PBTRANSMBTRANSUID ='" & tvMBTransUID & "', PBTRANSCUSTUID ='" & tvCustUID & "', PBTRANSCUSTNAME ='" & CustName.Text & "', PBTRANSTABLELISTUID ='" & tvTableUID & "', PBTRANSTOTVAL ='" & TotalPaid & "', MODIFIEDUSER ='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "', ISFISCAL='" & t & "' WHERE PBTRANSUID ='" & TransactionUID & "'"
        'Call MyDatabase.MyAdapter(Query)
      Else
        If PaymentType1.Columns(2).Text = "6" Then
          Dim VCustUID As String = GetFieldValueDBString("CUST", "CUSTUID", "WHERE CUSTNO='" & CardNumber1.Text & "'")
          If VCustUID.Trim() <> "" Then
            Query = "UPDATE PBTRANS SET PBTRANSNO ='" & PaymentNo.Text & "',PBTRANSSTAT = 2, PBTRANSDATE ='" & Format(PaymentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "', PBTRANSDEPTUID ='" & DeptInfo.DeptUID & "', PBTRANSMODULETYPEID = '2206', PBTRANSMBTRANSUID ='" & tvMBTransUID & "', PBTRANSCUSTUID ='" & VCustUID & "', PBTRANSCUSTNAME ='" & CardOwner1.Text & "', PBTRANSTABLELISTUID ='" & tvTableUID & "', PBTRANSTOTVAL ='" & TotalPaid & "', MODIFIEDUSER ='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "', ISFISCAL='" & t & "' WHERE PBTRANSUID ='" & TransactionUID & "'"
          Else
            Query = "UPDATE PBTRANS SET PBTRANSNO ='" & PaymentNo.Text & "',PBTRANSSTAT = 2, PBTRANSDATE ='" & Format(PaymentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "', PBTRANSDEPTUID ='" & DeptInfo.DeptUID & "', PBTRANSMODULETYPEID = '2206', PBTRANSMBTRANSUID ='" & tvMBTransUID & "', PBTRANSCUSTUID ='" & tvCustUID & "', PBTRANSCUSTNAME ='" & CustName.Text & "', PBTRANSTABLELISTUID ='" & tvTableUID & "', PBTRANSTOTVAL ='" & TotalPaid & "', MODIFIEDUSER ='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "', ISFISCAL='" & t & "' WHERE PBTRANSUID ='" & TransactionUID & "'"
          End If
          Call MyDatabase.MyAdapter(Query)
        Else
          Query = "UPDATE PBTRANS SET PBTRANSNO ='" & PaymentNo.Text & "',PBTRANSSTAT = 2, PBTRANSDATE ='" & Format(PaymentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "', PBTRANSDEPTUID ='" & DeptInfo.DeptUID & "', PBTRANSMODULETYPEID = '2206', PBTRANSMBTRANSUID ='" & tvMBTransUID & "', PBTRANSCUSTUID ='" & tvCustUID & "', PBTRANSCUSTNAME ='" & CustName.Text & "', PBTRANSTABLELISTUID ='" & tvTableUID & "', PBTRANSTOTVAL ='" & TotalPaid & "', MODIFIEDUSER ='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "', ISFISCAL='" & t & "' WHERE PBTRANSUID ='" & TransactionUID & "'"
          Call MyDatabase.MyAdapter(Query)
        End If
        'Call MyDatabase.MyAdapter(Query)

        ParentOBJForm.Lunas = True
        ParentOBJForm.CustName = CustName.Text
      End If

      'If t = 1 Then
      '    Query = "INSERT INTO PBTRANS (PBTRANSUID, PBTRANSNO,PBTRANSSTAT,PBTRANSDATE, PBTRANSDEPTUID, PBTRANSMODULETYPEID, PBTRANSSHIFTNO, PBTRANSMBTRANSUID, PBTRANSCUSTUID, PBTRANSCUSTNAME, PBTRANSTABLELISTUID, PBTRANSTOTVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME,ISFISCAL) " & _
      '         "VALUES ('" & tvPBTransUID & "','" & PaymentNo.Text & "',2,'" & Format(PaymentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2206','" & Shift & "','" & tvMBTransUID & "','" & tvCustUID & "','" & CustName.Text & "','" & tvTableUID & "','" & TotalPaid & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & t & "')"
      '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
      'Else
      '    Query = "DELETE FROM PBTRANS WHERE PBTRANSUID ='" & TransactionUID & "'"
      '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
      'End If

      Call SaveDetailExistingPB(tvPBTransUID)

      If CDec(PaidTxt.Text) > CDec(GrandTotalTxt.Text) Then
        Dim Selisih As Decimal
        Selisih = CDec(PaidTxt.Text) - CDec(GrandTotalTxt.Text)

        Call UpdateIsRefundable(tvPBTransUID, Selisih)

        If ExitIsRefundable = True Then
          Me.Cursor = Cursors.Default
          Exit Sub
        End If
      End If
    Else

      'susilo, 7 Nov 2012. cek apakah masa trial masih aktif

      ''dibuka lagi  ya
      'If totalRow("PBTRANS") >= CInt(getRealVal("—˜›‡…")) And pubIsDemo = True Then
      '  Me.Cursor = Cursors.Default
      '  ShowMessage(Me, "Maaf, data ini tidak dapat disimpan karena versi demo telah habis !", True)
      '  Exit Sub
      'End If

      'Dim IsPayByEPayment As Boolean = False
      'If PaymentType1.Columns(2).Text = "6" Then IsPayByEPayment = True
      'If PaymentType2.Columns(2).Text = "6" Then IsPayByEPayment = True
      'If PaymentType3.Columns(2).Text = "6" Then IsPayByEPayment = True
      'If PaymentType4.Columns(2).Text = "6" Then IsPayByEPayment = True
      'If PaymentType5.Columns(2).Text = "6" Then IsPayByEPayment = True
      'If IsPayByEPayment = True Then
      '  If ACR120U_Write() = False Then
      '    Me.Cursor = Cursors.Default
      '    ShowMessage(Me, "Saldo kartu Gagal terkurangi", True)
      '    Exit Sub
      '  End If
      'End If
      PaymentNo.Text = AutoIDNumber("2206", "PBTRANS", "PBTRANSNO")

      If CDec(PaidTxt.Text) < CDec(GrandTotalTxt.Text) Then
        Query = "INSERT INTO PBTRANS (PBTRANSUID, PBTRANSNO,PBTRANSSTAT,PBTRANSDATE, PBTRANSDEPTUID, PBTRANSMODULETYPEID, PBTRANSSHIFTNO, PBTRANSMBTRANSUID, PBTRANSCUSTUID, PBTRANSCUSTNAME, PBTRANSTABLELISTUID, PBTRANSTOTVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME,PRINTCOUNTER,ISFISCAL) " & _
            "VALUES ('" & LastID & "','" & PaymentNo.Text & "',2,'" & Format(PaymentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2206','" & Shift & "','" & tvMBTransUID & "','" & tvCustUID & "','" & ReplacePetik(CustName.Text) & "','" & tvTableUID & "','" & TotalPaid & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','1','" & t & "')"
        Call MyDatabase.MyAdapter(Query)
      Else
        Query = "INSERT INTO PBTRANS (PBTRANSUID, PBTRANSNO,PBTRANSSTAT,PBTRANSDATE, PBTRANSDEPTUID, PBTRANSMODULETYPEID, PBTRANSSHIFTNO, PBTRANSMBTRANSUID, PBTRANSCUSTUID, PBTRANSCUSTNAME, PBTRANSTABLELISTUID, PBTRANSTOTVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME,PRINTCOUNTER,ISFISCAL) " & _
            "VALUES ('" & LastID & "','" & PaymentNo.Text & "',2,'" & Format(PaymentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2206','" & Shift & "','" & tvMBTransUID & "','" & tvCustUID & "','" & ReplacePetik(CustName.Text) & "','" & tvTableUID & "','" & TotalPaid & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','1','" & t & "')"
        Call MyDatabase.MyAdapter(Query)

        If Invoice = False Then
          ParentOBJForm.Lunas = True
          ParentOBJForm.CustName = CustName.Text
        End If
      End If

      'add 27-12-2016

      If PaymentType1.Columns(2).Text = "6" Then
        Dim VCustUID As String = GetFieldValueDBString("CUST", "CUSTUID", "WHERE CUSTNO='" & CardNumber1.Text & "'")
        If VCustUID.Trim() <> "" Then
          Query = "UPDATE MBTRANS SET MBTRANSCUSTUID = '" & VCustUID & "', MBTRANSCUSTNAME ='" & CardOwner1.Text & "', MBTRANSPAIDVAL = '" & TotalPaidAll & "',MBTRANSSTAT=" & IIf(Invoice = False, "MBTRANSSTAT", "'3'") & "  WHERE MBTRANSUID = '" & MBTransUID & "'"
          'Query = "UPDATE MBTRANS SET MBTRANSPAIDVAL = '" & TotalPaidAll & "',MBTRANSSTAT=" & IIf(Invoice = False, "MBTRANSSTAT", "'3'") & " WHERE MBTRANSUID = '" & MBTransUID & "'"
        Else
          'Query = "UPDATE MBTRANS SET MBTRANSPAIDVAL = '" & TotalPaidAll & "' WHERE MBTRANSUID = '" & MBTransUID & "'"
          Query = "UPDATE MBTRANS SET MBTRANSPAIDVAL = '" & TotalPaidAll & "',MBTRANSSTAT=" & IIf(Invoice = False, "MBTRANSSTAT", "'3'") & " WHERE MBTRANSUID = '" & MBTransUID & "'"
        End If
        Call MyDatabase.MyAdapter(Query)
      Else
        Query = "UPDATE MBTRANS SET MBTRANSPAIDVAL = '" & TotalPaidAll & "',MBTRANSSTAT=" & IIf(Invoice = False, "MBTRANSSTAT", "'3'") & " WHERE MBTRANSUID = '" & MBTransUID & "'"
        Call MyDatabase.MyAdapter(Query)
      End If

      'Query = "UPDATE MBTRANS SET MBTRANSPAIDVAL = '" & TotalPaidAll & "',MBTRANSSTAT=" & IIf(Invoice = False, "MBTRANSSTAT", "'3'") & " WHERE MBTRANSUID = '" & MBTransUID & "'"
      'Call MyDatabase.MyAdapter(Query)

      'If Invoice = True Then
      '    Query = "UPDATE MBTRANS SET MBTRANSSTAT = 3 WHERE MBTRANSUID = '" & MBTransUID & "'"
      '    Call MyDatabase.MyAdapter(Query)
      'End If

      'If t = 1 Then
      '    Query = "INSERT INTO PBTRANS (PBTRANSUID, PBTRANSNO,PBTRANSSTAT,PBTRANSDATE, PBTRANSDEPTUID, PBTRANSMODULETYPEID, PBTRANSSHIFTNO, PBTRANSMBTRANSUID, PBTRANSCUSTUID, PBTRANSCUSTNAME, PBTRANSTABLELISTUID, PBTRANSTOTVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME,PRINTCOUNTER,ISFISCAL) " & _
      '         "VALUES ('" & LastID & "','" & AutoIDNumber2(FileDatabase2, "2206", "PBTRANS", "PBTRANSNO") & "',2,'" & Format(PaymentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2206','" & Shift & "','" & tvMBTransUID & "','" & tvCustUID & "','" & ReplacePetik(CustName.Text) & "','" & tvTableUID & "','" & TotalPaid & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','1','" & t & "')"
      '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
      'Else
      '    Query = "DELETE FROM PBTRANS WHERE PBTRANSUID ='" & TransactionUID & "'"
      '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
      'End If

      Call SaveDetailNewPB(LastID)

      If CDec(PaidTxt.Text) > CDec(GrandTotalTxt.Text) Then
        Dim Selisih As Decimal
        Selisih = CDec(PaidTxt.Text) - CDec(GrandTotalTxt.Text)

        Call UpdateIsRefundable(LastID, Selisih)

        If ExitIsRefundable = True Then
          Me.Cursor = Cursors.Default
          Exit Sub
        End If
      End If
    End If

    SaveStatus = True
    'Jika tidak ada pembayaran, tidak perlu print preview
    If CDec(Payment1.Text) <> 0 Or CDec(Payment2.Text) <> 0 Or CDec(Payment3.Text) <> 0 Or CDec(Payment4.Text) <> 0 Or CDec(Payment5.Text) <> 0 Then
      Call OpenCashDrawer()
      If UCase(ParentOBJForm.name) = "INVOICE" Then
        If PrefInfo.UsePreSettledBill Then
          'Call ShowMakeBillPaymentPreview(True)
          For i As Integer = 1 To CInt(PrefInfo.pubJumlahPrintOutPayment)
            Call ShowMakeBillPaymentPreview(True)
          Next
        Else
          'Call ShowPaymentChangePreview(True)
          For i As Integer = 1 To CInt(PrefInfo.pubJumlahPrintOutPayment)
            Call ShowPaymentChangePreview(True)
          Next
        End If
      Else
        Call ShowPrintPreview(True)
      End If
    End If

    'Call MainPage.CheckPaymentRest()
    If UCase(ParentOBJForm.name) <> "INVOICE" Then Call ParentOBJForm.BasicInitialize(MBTransUID)
    If UCase(ParentOBJForm.name) <> "INVOICE" Then Call GeneratePBTransExcelFile(TransactionUID, PaymentNo.Text)

    'Me.Close()
    Call ShowPoleDisplay("Pay   :" & PaidTxt.Text & vbNewLine & "Change:" & ChangeTxt.Text, False)
    'Call ShowPoleDisplay("Change:" & ChangeTxt.Text, True)
    BTNSave.Enabled = False
    BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver
    Me.Cursor = Cursors.Default
  End Sub

  Private Function CheckAdaPembayaranRefundable() As Boolean

    CheckAdaPembayaranRefundable = False

    If CDec(Payment1.Text) <> 0 Then
      If PaymentType1.Columns(3).Text = "1" Then CheckAdaPembayaranRefundable = True
    End If

    If CDec(Payment2.Text) <> 0 Then
      If PaymentType2.Columns(3).Text = "1" Then CheckAdaPembayaranRefundable = True
    End If

    If CDec(Payment3.Text) <> 0 Then
      If PaymentType3.Columns(3).Text = "1" Then CheckAdaPembayaranRefundable = True
    End If

    If CDec(Payment4.Text) <> 0 Then
      If PaymentType4.Columns(3).Text = "1" Then CheckAdaPembayaranRefundable = True
    End If

    If CDec(Payment5.Text) <> 0 Then
      If PaymentType5.Columns(3).Text = "1" Then CheckAdaPembayaranRefundable = True
    End If

  End Function

  Private Sub Payment1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Payment1.KeyUp, Payment2.KeyUp, Payment3.KeyUp, Payment4.KeyUp, Payment5.KeyUp
    sender.selectionstart = Len(sender.text)
  End Sub

  Private Sub PaymentTXTChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Payment1.TextChanged, Payment2.TextChanged, Payment3.TextChanged, Payment4.TextChanged, Payment5.TextChanged
    If IsNumeric(Payment1.Text) = False Then
      Payment1.Text = "0"
      Exit Sub
    End If
    If IsNumeric(Payment2.Text) = False Then
      Payment2.Text = "0"
      Exit Sub
    End If
    If IsNumeric(Payment3.Text) = False Then
      Payment3.Text = "0"
      Exit Sub
    End If
    If IsNumeric(Payment4.Text) = False Then
      Payment4.Text = "0"
      Exit Sub
    End If
    If IsNumeric(Payment5.Text) = False Then
      Payment5.Text = "0"
      Exit Sub
    End If

    If Payment1.Text = "" Then
      Payment1.Text = "0"
    End If
    If Payment2.Text = "" Then
      Payment2.Text = "0"
    End If
    If Payment3.Text = "" Then
      Payment3.Text = "0"
    End If
    If Payment4.Text = "" Then
      Payment4.Text = "0"
    End If
    If Payment5.Text = "" Then
      Payment5.Text = "0"
    End If

    If GrandTotalTxt.Text = "" Then
      GrandTotalTxt.Text = "0"
    End If
    If PaidTxt.Text = "" Then
      PaidTxt.Text = "0"
    End If
    If RestTxt.Text = "" Then
      RestTxt.Text = "0"
    End If
    Call ReTotal()
  End Sub

  Private Sub ReTotal()
    Dim Retotal As Double = 0
    If NewTransaction = True Then
      Retotal = CDbl(Payment1.Text) + CDbl(Payment2.Text) + CDbl(Payment3.Text) + CDbl(Payment4.Text) + CDbl(Payment5.Text) + (Paid - Deviasi)
    Else
      'Retotal = (Paid - Deviasi)
      Retotal = Paid + CDbl(Payment1.Text) + CDbl(Payment2.Text) + CDbl(Payment3.Text) + CDbl(Payment4.Text) + CDbl(Payment5.Text)
    End If

    PaidTxt.Value = FormatNumber(Retotal, 0)

    Payment1.Text = FormatNumber(Payment1.Text, 0)
    Payment2.Text = FormatNumber(Payment2.Text, 0)
    Payment3.Text = FormatNumber(Payment3.Text, 0)
    Payment4.Text = FormatNumber(Payment4.Text, 0)
    Payment5.Text = FormatNumber(Payment5.Text, 0)

    If CDbl(GrandTotalTxt.Text) > CDbl(PaidTxt.Text) Then
      Dim Rest As Double
      Rest = CDbl(GrandTotalTxt.Text) - CDbl(PaidTxt.Text)

      RestTxt.Value = FormatNumber(Rest, 0)
      ChangeTxt.Value = 0
    Else
      Dim Change As Double
      Change = CDbl(PaidTxt.Text) - CDbl(GrandTotalTxt.Text)

      ChangeTxt.Value = FormatNumber(Change, 0)
      RestTxt.Value = 0
    End If
  End Sub

  Private Sub PaymentType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentType1.TextChanged, PaymentType2.TextChanged, PaymentType3.TextChanged, PaymentType4.TextChanged, PaymentType5.TextChanged
    PaymentTypeBehaviour(sender.name)

    'Select Case sender.name
    '  Case "PaymentType1"
    '    If CardInfo1.Visible = True Then CardOwner1.Focus()
    '  Case "PaymentType2"
    '    If CardInfo2.Visible = True Then CardOwner2.Focus()
    '  Case "PaymentType3"
    '    If CardInfo3.Visible = True Then CardOwner3.Focus()
    '  Case "PaymentType4"
    '    If CardInfo4.Visible = True Then CardOwner4.Focus()
    '  Case "PaymentType5"
    '    If CardInfo5.Visible = True Then CardOwner5.Focus()
    'End Select

  End Sub
  Private Sub VirtualCalculator1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualCalculator1.Click
    Me.Cursor = Cursors.WaitCursor
    Dim VirtuCalculator As New Form_Virtual_Calculator
    VirtuCalculator.OBJBind(Payment1)
    VirtuCalculator.showMoney = True
    VirtuCalculator.ShowDialog()
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub VirtualCalculator2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualCalculator2.Click
    Me.Cursor = Cursors.WaitCursor
    Dim VirtuCalculator As New Form_Virtual_Calculator
    VirtuCalculator.OBJBind(Payment2)
    VirtuCalculator.showMoney = True
    VirtuCalculator.ShowDialog()
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub VirtualCalculator3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VirtualCalculator3.Click
    Me.Cursor = Cursors.WaitCursor
    Dim VirtuCalculator As New Form_Virtual_Calculator
    VirtuCalculator.OBJBind(Payment3)
    VirtuCalculator.showMoney = True
    VirtuCalculator.ShowDialog()
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub VirtualCalculator4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VirtualCalculator4.Click
    Me.Cursor = Cursors.WaitCursor
    Dim VirtuCalculator As New Form_Virtual_Calculator
    VirtuCalculator.OBJBind(Payment4)
    VirtuCalculator.showMoney = True
    VirtuCalculator.ShowDialog()
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub VirtualCalculator5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VirtualCalculator5.Click
    Me.Cursor = Cursors.WaitCursor
    Dim VirtuCalculator As New Form_Virtual_Calculator
    VirtuCalculator.OBJBind(Payment5)
    VirtuCalculator.showMoney = True
    VirtuCalculator.ShowDialog()
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub Form_Payment_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    If e.Control = True And e.Shift = True And e.KeyCode = Keys.Z Then
      Me.Cursor = Cursors.WaitCursor
      Dim Query As String = Nothing
      strConn2 = Nothing
      Dim TMPRecord As FbDataReader
      TMPRecord = MyDatabase.MyReader("SELECT * FROM POSPREF")
      While TMPRecord.Read
        Try
          FileDatabase2 = TMPRecord.Item("POSPREFDATABASEPATH2")
          strConn2 = TMPRecord.Item("POSPREFDATABASEPATH2")
        Catch ex As Exception
          Me.Cursor = Cursors.Default
          ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
        End Try
      End While

      If strConn2 = Nothing Then Me.Cursor = Cursors.Default : Exit Sub
      Dim rs As FbDataReader
      rs = MyDatabase.MyReader("SELECT PBTRANS.*,(SELECT a.MBTRANSRSVTRANSUID FROM MBTRANS a WHERE a.MBTRANSUID=PBTRANSMBTRANSUID) AS idRSV FROM PBTRANS WHERE PBTRANSNO='" & PaymentNo.Text & "'")
      If rs.Read() = False Then
        Me.Cursor = Cursors.Default
        Exit Sub
      Else
        If CInt(rs("ISFISCAL")) = 1 Then
          Call unPost(IIf(IsDBNull(rs("idRSV")) = True, Nothing, rs("idRSV")), rs("PBTRANSMBTRANSUID"), rs("PBTRANSUID"))
        Else
          Call fillData(IIf(IsDBNull(rs("idRSV")) = True, Nothing, rs("idRSV")), rs("PBTRANSMBTRANSUID"), rs("PBTRANSUID"))
        End If
      End If

      If t = 0 Then
        If CheckConnectionDB2(FileDatabase2) Then
          t = 1
          Tax.Visible = True
        Else
          Me.Cursor = Cursors.Default
          ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
          t = 0
          Tax.Visible = False
        End If
      Else
        t = 0
        Tax.Visible = False
      End If
      Me.Cursor = Cursors.Default
    ElseIf e.KeyCode = Keys.F2 Then
      Call OpenCashDrawer()
    End If
  End Sub

  Private Sub PaymentNo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles PaymentNo.MouseDown
    Me.Cursor = Cursors.WaitCursor
    Dim Query As String = Nothing
    strConn2 = Nothing
    Dim TMPRecord As FbDataReader
    TMPRecord = MyDatabase.MyReader("SELECT * FROM POSPREF")
    While TMPRecord.Read
      Try
        FileDatabase2 = TMPRecord.Item("POSPREFDATABASEPATH2")
        strConn2 = TMPRecord.Item("POSPREFDATABASEPATH2")
      Catch ex As Exception
        Me.Cursor = Cursors.Default
        ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
      End Try
    End While

    If strConn2 = Nothing Then Me.Cursor = Cursors.Default : Exit Sub
    Dim rs As FbDataReader
    rs = MyDatabase.MyReader("SELECT PBTRANS.*,(SELECT a.MBTRANSRSVTRANSUID FROM MBTRANS a WHERE a.MBTRANSUID=PBTRANSMBTRANSUID) AS idRSV FROM PBTRANS WHERE PBTRANSNO='" & PaymentNo.Text & "'")
    If rs.Read() = False Then
      Me.Cursor = Cursors.Default
      Exit Sub
    Else
      If CInt(rs("ISFISCAL")) = 1 Then
        Call unPost(IIf(IsDBNull(rs("idRSV")) = True, Nothing, rs("idRSV")), rs("PBTRANSMBTRANSUID"), rs("PBTRANSUID"))
      Else
        Call fillData(IIf(IsDBNull(rs("idRSV")) = True, Nothing, rs("idRSV")), rs("PBTRANSMBTRANSUID"), rs("PBTRANSUID"))
      End If
    End If

    If t = 0 Then
      If CheckConnectionDB2(FileDatabase2) Then
        t = 1
        Tax.Visible = True
      Else
        Me.Cursor = Cursors.Default
        ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
        t = 0
        Tax.Visible = False
      End If
    Else
      t = 0
      Tax.Visible = False
    End If
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub Tax_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Tax.MouseDown
    Dim Query As String = Nothing

    Dim TMPRecord As FbDataReader
    TMPRecord = MyDatabase.MyReader("SELECT * FROM POSPREF")
    While TMPRecord.Read
      Try
        FileDatabase2 = TMPRecord.Item("POSPREFDATABASEPATH2")
      Catch ex As Exception
        ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
      End Try
    End While

    If t = 0 Then
      If CheckConnectionDB2(FileDatabase2) Then
        t = 1
        Tax.Visible = True
      Else
        ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
        t = 0
        Tax.Visible = False
      End If
    Else
      t = 0
      Tax.Visible = False
    End If
  End Sub

  Private Sub FindTransaction_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindTransaction.Click

    'Dim CustDialog As New Form_Debt_Payment_Pick
    'CustDialog.Name = "Form_Debt_Payment_Pick"
    'CustDialog.ParentOBJForm = Me
    'CustDialog.ShowDialog()

  End Sub

  Private Sub VirtualDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualDate.Click

    Me.Cursor = Cursors.WaitCursor
    Dim VirtualDate As New Form_Virtual_Date
    VirtualDate.Name = "Form_Virtual_Date"
    VirtualDate.Text = "Please Select Date"
    VirtualDate.ParentOBJForm = Me
    VirtualDate.publicChosenDate = CurrDate

    VirtualDate.ShowDialog()
    PaymentDate.Text = VirtualDate.publicChosenDate & " " & Format(Now, "HH:mm:ss")
    CurrDate = VirtualDate.publicChosenDate
    DateLabel.Text = Format(PaymentDate.Value, "dddd , dd MMMM yyyy")
    Me.Cursor = Cursors.Default

  End Sub
#End Region


  Private Sub GeneratePBTransExcelFile(ByVal inputPBTransUID As String, ByVal inputPBTransNo As String)

    If PrefInfo.AutoGenerateExcelFile = "0" Then Exit Sub
    If Len(Trim(PrefInfo.AutoGenerateExcelFilePath)) = 0 Then Exit Sub
    If CheckFolderExist(PrefInfo.AutoGenerateExcelFilePath) = False Then Exit Sub

    Dim rs As FbDataReader
    Dim strSQL As String
    Dim rowNum As Integer
    Dim HSSFWorkbook As New HSSFWorkbook
    Dim fileName As String = inputPBTransNo
    Dim dsi As DocumentSummaryInformation = PropertySetFactory.CreateDocumentSummaryInformation()
    dsi.Company = "NAV"
    HSSFWorkbook.DocumentSummaryInformation = dsi

    Dim hssfSheet As HSSFSheet = HSSFWorkbook.CreateSheet("PAGE1")

    'strSQL = connDB.CreateCommand

    'susilo 4 juni, query diganti : Kode Payment, Diganti kode MBTRANS, tipe pembayaran diganti CASH,CC,DC dst
    'strSQL = "SELECT dept.DeptNo AS Entity, mb.MBTRANSNO AS TrNo, pType.PaymentTypeName AS Tipe,CASE WHEN pType.PaymentTypeEDCNumber IS NULL THEN '' ELSE pType.PaymentTypeEDCNumber END AS KodeMesin, pbdt.PBTransDtSubVal AS Amount " & _
    '"FROM PBTrans pb LEFT OUTER JOIN PBTransDt pbdt ON pb.PBTransUID = pbdt.PBTransUID  " & _
    '"LEFT OUTER JOIN MBTrans mb ON pb.PBTransMBTransUID = mb.MBTransUID " & _
    '"LEFT OUTER JOIN Dept dept ON pb.PBTransDeptUID = dept.DeptUID " & _
    '"LEFT OUTER JOIN Cust cust ON mb.MBTransCustUID = cust.CustUID " & _
    '"LEFT OUTER JOIN CustCat custcat ON cust.CustCatUID = custcat.CustCatUID " & _
    '"LEFT OUTER JOIN TableList tlist ON mb.MBTransTableListUID = tlist.TableListUID " & _
    '"LEFT OUTER JOIN PaymentType pType ON pbdt.PaymentTypeUID = pType.PaymentTypeUID WHERE pb.PBTRANSNO='" & inputPBTransNo & "'"

    strSQL = "SELECT dept.DeptNo AS Entity, mb.MBTRANSNO AS TrNo, " & _
                        "CASE WHEN pType.ISCREDITCARDORCHEQUE='0' THEN 'CASH' WHEN pType.ISCREDITCARDORCHEQUE='1' THEN 'CC' WHEN pType.ISCREDITCARDORCHEQUE='2' THEN 'DC' WHEN pType.ISCREDITCARDORCHEQUE='3' THEN 'PTG' WHEN pType.ISCREDITCARDORCHEQUE='4' THEN 'ENT' ELSE pType.PaymentTypeName END AS Tipe," & _
                        "CASE WHEN pType.PaymentTypeEDCNumber IS NULL THEN '' ELSE pType.PaymentTypeEDCNumber END AS KodeMesin, pbdt.PBTransDtSubVal AS Amount " & _
                        "FROM PBTrans pb LEFT OUTER JOIN PBTransDt pbdt ON pb.PBTransUID = pbdt.PBTransUID  " & _
                        "LEFT OUTER JOIN MBTrans mb ON pb.PBTransMBTransUID = mb.MBTransUID " & _
                        "LEFT OUTER JOIN Dept dept ON pb.PBTransDeptUID = dept.DeptUID " & _
                        "LEFT OUTER JOIN Cust cust ON mb.MBTransCustUID = cust.CustUID " & _
                        "LEFT OUTER JOIN CustCat custcat ON cust.CustCatUID = custcat.CustCatUID " & _
                        "LEFT OUTER JOIN TableList tlist ON mb.MBTransTableListUID = tlist.TableListUID " & _
                        "LEFT OUTER JOIN PaymentType pType ON pbdt.PaymentTypeUID = pType.PaymentTypeUID WHERE pb.PBTRANSNO='" & inputPBTransNo & "'"

    'rs = strSQL.ExecuteReader
    rs = MyDatabase.MyReader(strSQL)
    rowNum = 0

    While rs.Read() = True
      Dim hssfRow As HSSFRow = hssfSheet.CreateRow(rowNum)

      Dim hssfCell As HSSFCell = hssfRow.CreateCell(0)

      'Create Currency Cell Style
      Dim CurrencyCellStyle As HSSFCellStyle = HSSFWorkbook.CreateCellStyle()
      Dim CurrencyDataFormat As HSSFDataFormat = HSSFWorkbook.CreateDataFormat()
      CurrencyCellStyle.DataFormat = CurrencyDataFormat.GetFormat("#,##0.0000")

      'Create Date Cell Style
      Dim DateCellStyle As HSSFCellStyle = HSSFWorkbook.CreateCellStyle()
      Dim DateDataFormat As HSSFDataFormat = HSSFWorkbook.CreateDataFormat()
      DateCellStyle.DataFormat = DateDataFormat.GetFormat("yyyy-mm-dd")

      'Create Time Cell Style
      Dim TimeCellStyle As HSSFCellStyle = HSSFWorkbook.CreateCellStyle()
      Dim TimeDataFormat As HSSFDataFormat = HSSFWorkbook.CreateDataFormat()
      TimeCellStyle.DataFormat = TimeDataFormat.GetFormat("HH:mm:ss")

      hssfCell.SetCellValue(rs("Entity"))

      hssfCell = hssfRow.CreateCell(1)
      hssfCell.SetCellValue(rs("TrNo"))

      hssfCell = hssfRow.CreateCell(2)
      hssfCell.SetCellValue(rs("Tipe"))

      hssfCell = hssfRow.CreateCell(3)
      hssfCell.SetCellValue(rs("KodeMesin"))

      hssfCell = hssfRow.CreateCell(4)
      hssfCell.SetCellValue(CDec(rs("Amount")))
      hssfCell.SetCellType(hssfCell.CELL_TYPE_NUMERIC)
      hssfCell.CellStyle = CurrencyCellStyle

      rowNum += 1
    End While
    rs.Close()

    Dim file As FileStream = New FileStream(PrefInfo.AutoGenerateExcelFilePath & "\" & fileName & ".xls", FileMode.Create)
    HSSFWorkbook.Write(file)
    file.Close()

  End Sub

  Private Function DecodeCardReader(ByVal inputString As String) As String

    On Error GoTo decodeError

    Dim retVal As String = ""
    Dim tmpString As String, jenisKartu As String = "", noKartu As String = "", pemilikKartu As String = "", indexPos As Integer
    Dim arrayData

    indexPos = InStr(inputString, "%B")
    If indexPos > 0 Then inputString = Mid(inputString, indexPos, Len(inputString))

    If Strings.Left(inputString, 2) = "%B" Then
      tmpString = Mid(inputString, 3, Len(inputString))
      arrayData = Split(tmpString, "^")
      If UBound(arrayData) >= 2 Then
        If CStr(Mid(arrayData(0), 1, 1)) = "1" Then
          jenisKartu = "JCB"
        ElseIf CStr(Mid(arrayData(0), 1, 1)) = "2" Then
          jenisKartu = "JCB"
        ElseIf CStr(Mid(arrayData(0), 1, 1)) = "3" Then
          jenisKartu = "AMERICAN EXPRESS"
        ElseIf CStr(Mid(arrayData(0), 1, 1)) = "4" Then
          jenisKartu = "VISA"
        ElseIf CStr(Mid(arrayData(0), 1, 1)) = "5" Then
          jenisKartu = "MASTERCARD"
        ElseIf CStr(Mid(arrayData(0), 1, 1)) = "6" Then
          jenisKartu = "DISCOVER"
        End If
        noKartu = Trim(arrayData(0))
        pemilikKartu = Trim(arrayData(1))
        If Mid(pemilikKartu, 1, 1) = "/" Then pemilikKartu = Mid(pemilikKartu, 2, Len(pemilikKartu))
        If Strings.Right(pemilikKartu, 1) = "/" Then pemilikKartu = Strings.Left(pemilikKartu, Len(pemilikKartu) - 1)
      End If
      retVal = jenisKartu & MY_DELIMITER & noKartu & MY_DELIMITER & pemilikKartu
    End If

    DecodeCardReader = retVal

    Exit Function

decodeError:

    DecodeCardReader = ""

  End Function

  Private Sub CardDetail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CardOwner1.KeyUp, CardOwner2.KeyUp, CardOwner3.KeyUp, CardOwner4.KeyUp, CardOwner5.KeyUp, CardNumber1.KeyUp, CardNumber2.KeyUp, CardNumber3.KeyUp, CardNumber4.KeyUp, CardNumber5.KeyUp, BankName1.KeyUp, BankName2.KeyUp, BankName3.KeyUp, BankName4.KeyUp, BankName5.KeyUp

    Dim arrayData
    Dim readCard As String = ""

    If e.KeyCode = 13 Then
      If sender.name = "CardOwner1" Or sender.name = "CardNumber1" Or sender.name = "BankName1" Then
        If sender.name = "CardOwner1" Then
          readCard = DecodeCardReader(CardOwner1.Text)
        ElseIf sender.name = "CardNumber1" Then
          readCard = DecodeCardReader(CardNumber1.Text)
        ElseIf sender.name = "BankName1" Then
          readCard = DecodeCardReader(BankName1.Text)
        End If
        If Len(Trim(readCard)) > 0 Then
          arrayData = Split(readCard, MY_DELIMITER)
          CardOwner1.Text = CStr(arrayData(2))
          CardNumber1.Text = CStr(arrayData(1))
          BankName1.Text = CStr(arrayData(0))
          GrandTotalTxt.Focus()
        End If
      ElseIf sender.name = "CardOwner2" Or sender.name = "CardNumber2" Or sender.name = "BankName2" Then
        If sender.name = "CardOwner2" Then
          readCard = DecodeCardReader(CardOwner2.Text)
        ElseIf sender.name = "CardNumber2" Then
          readCard = DecodeCardReader(CardNumber2.Text)
        ElseIf sender.name = "BankName2" Then
          readCard = DecodeCardReader(BankName2.Text)
        End If
        If Len(Trim(readCard)) > 0 Then
          arrayData = Split(readCard, MY_DELIMITER)
          CardOwner2.Text = CStr(arrayData(2))
          CardNumber2.Text = CStr(arrayData(1))
          BankName2.Text = CStr(arrayData(0))
          GrandTotalTxt.Focus()
        End If
      ElseIf sender.name = "CardOwner3" Or sender.name = "CardNumber3" Or sender.name = "BankName3" Then
        If sender.name = "CardOwner3" Then
          readCard = DecodeCardReader(CardOwner3.Text)
        ElseIf sender.name = "CardNumber3" Then
          readCard = DecodeCardReader(CardNumber3.Text)
        ElseIf sender.name = "BankName3" Then
          readCard = DecodeCardReader(BankName3.Text)
        End If
        If Len(Trim(readCard)) > 0 Then
          arrayData = Split(readCard, MY_DELIMITER)
          CardOwner3.Text = CStr(arrayData(2))
          CardNumber3.Text = CStr(arrayData(1))
          BankName3.Text = CStr(arrayData(0))
          GrandTotalTxt.Focus()
        End If
      ElseIf sender.name = "CardOwner4" Or sender.name = "CardNumber4" Or sender.name = "BankName4" Then
        If sender.name = "CardOwner4" Then
          readCard = DecodeCardReader(CardOwner4.Text)
        ElseIf sender.name = "CardNumber4" Then
          readCard = DecodeCardReader(CardNumber4.Text)
        ElseIf sender.name = "BankName4" Then
          readCard = DecodeCardReader(BankName4.Text)
        End If
        If Len(Trim(readCard)) > 0 Then
          arrayData = Split(readCard, MY_DELIMITER)
          CardOwner4.Text = CStr(arrayData(2))
          CardNumber4.Text = CStr(arrayData(1))
          BankName4.Text = CStr(arrayData(0))
          GrandTotalTxt.Focus()
        End If
      ElseIf sender.name = "CardOwner5" Or sender.name = "CardNumber5" Or sender.name = "BankName5" Then
        If sender.name = "CardOwner5" Then
          readCard = DecodeCardReader(CardOwner5.Text)
        ElseIf sender.name = "CardNumber5" Then
          readCard = DecodeCardReader(CardNumber5.Text)
        ElseIf sender.name = "BankName5" Then
          readCard = DecodeCardReader(BankName5.Text)
        End If
        If Len(Trim(readCard)) > 0 Then
          arrayData = Split(readCard, MY_DELIMITER)
          CardOwner5.Text = CStr(arrayData(2))
          CardNumber5.Text = CStr(arrayData(1))
          BankName5.Text = CStr(arrayData(0))
          GrandTotalTxt.Focus()
        End If
      End If
    End If

  End Sub
  Protected Overrides Function ProcessCmdKey(ByRef msg As System.Windows.Forms.Message, ByVal keyData As System.Windows.Forms.Keys) As Boolean
    Dim VirtuKey As New VirtualKey

    If msg.WParam.ToInt32() = CInt(Keys.Enter) Then
      If VirtualCalculator1.Focused Then
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        VirtuCalculator.OBJBind(Payment1)
        VirtuCalculator.showMoney = True
        VirtuCalculator.ShowDialog()
        Me.Cursor = Cursors.Default
        If CardOwner1.Visible = False Then
          BTNSave.Focus()
        Else
          CardOwner1.Focus()
        End If
      ElseIf PaymentType1.Focused Then
        Payment1.Focus()
      ElseIf BankName1.Focused Then
        BTNSave.Focus()
      ElseIf Payment1.Focused Then
        If CardOwner1.Visible = False Then
          BTNSave.Focus()
        Else
          CardOwner1.Focus()
        End If
      ElseIf PaymentType2.Focused Then
        Payment2.Focus()
      ElseIf BankName2.Focused Then
        BTNSave.Focus()
      ElseIf Payment2.Focused Then
        If CardOwner2.Visible = False Then
          BTNSave.Focus()
        Else
          CardOwner2.Focus()
        End If
      ElseIf PaymentType3.Focused Then
        Payment3.Focus()
      ElseIf BankName3.Focused Then
        BTNSave.Focus()
      ElseIf Payment3.Focused Then
        If CardOwner3.Visible = False Then
          BTNSave.Focus()
        Else
          CardOwner3.Focus()
        End If
      ElseIf PaymentType4.Focused Then
        Payment4.Focus()
      ElseIf BankName4.Focused Then
        BTNSave.Focus()
      ElseIf Payment4.Focused Then
        If CardOwner4.Visible = False Then
          BTNSave.Focus()
        Else
          CardOwner4.Focus()
        End If
      ElseIf PaymentType5.Focused Then
        Payment5.Focus()
      ElseIf BankName5.Focused Then
        BTNSave.Focus()
      ElseIf Payment5.Focused Then
        If CardOwner5.Visible = False Then
          BTNSave.Focus()
        Else
          CardOwner5.Focus()
        End If
      ElseIf VirtualKeyCO1.Focused Then
        VirtuKey.OBJBind(CardOwner1, False)
        VirtuKey.ShowDialog()
        CardNumber1.Focus()
      ElseIf VirtualKeyCN1.Focused Then
        VirtuKey.OBJBind(CardNumber1, False)
        VirtuKey.ShowDialog()
        BankName1.Focus()
      ElseIf VirtualKeyBN1.Focused Then
        VirtuKey.OBJBind(BankName1, False)
        VirtuKey.ShowDialog()
        BTNSave.Focus()
      ElseIf VirtualCalculator2.Focused Then
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        VirtuCalculator.OBJBind(Payment2)
        VirtuCalculator.showMoney = True
        VirtuCalculator.ShowDialog()
        Me.Cursor = Cursors.Default
      ElseIf VirtualCalculator3.Focused Then
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        VirtuCalculator.OBJBind(Payment3)
        VirtuCalculator.showMoney = True
        VirtuCalculator.ShowDialog()
        Me.Cursor = Cursors.Default
      ElseIf VirtualCalculator4.Focused Then
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        VirtuCalculator.OBJBind(Payment4)
        VirtuCalculator.showMoney = True
        VirtuCalculator.ShowDialog()
        Me.Cursor = Cursors.Default
      ElseIf VirtualCalculator5.Focused Then
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        VirtuCalculator.OBJBind(Payment5)
        VirtuCalculator.showMoney = True
        VirtuCalculator.ShowDialog()
        Me.Cursor = Cursors.Default
      ElseIf BTNSave.Focused Then
        BTNSave_Click(BTNSave, New EventArgs())
        BTNCancel.Focus()
      ElseIf BTNCancel.Focused Then
        BTNCancel_Click(BTNCancel, New EventArgs())
      Else
        SendKeys.Send("{Tab}")
      End If

      Return True
    End If
    Return MyBase.ProcessCmdKey(msg, keyData)
  End Function
End Class