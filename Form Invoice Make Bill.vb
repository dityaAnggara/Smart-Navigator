Imports System
Imports C1.Win
Imports FirebirdSql.Data.FirebirdClient
Imports DataDynamics.ActiveReports
Imports System.Security.Cryptography
Imports NPOI.HSSF.UserModel
Imports NPOI.HPSF
Imports NPOI.POIFS.FileSystem
Imports System.IO
Imports C1.Win.C1FlexGrid

Public Class Form_Invoice_Make_Bill

  Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

#Region "Variable Reference"
  Public SaveStatus As Boolean = False
  Public TransactionUID As String
  Dim CustInfo As New ArrayList
  Dim CustOrderInfo As New ArrayList
  Dim CustOrderDetail As New Collection
  Public TMPDiscListCollection As New Collection
  Public FinalDisc As Double
  Public FinalTime As DateTime
  Public TotalPrice As Double = 0
  Public ParentOBJForm As Object
  Dim KitchenSplitOrder As String = "0"
  Dim TransactionNo As String
  Dim Visitor As String
  Dim ServiceUID As String
  Dim ReservationUID As String
  Public isDelivery As Boolean
  Dim x As Integer = 1
  Dim y As Integer = 1
  Public t As Integer = 0
  Dim FileDatabase2 As String = Nothing

  Dim UserPermition As New UserPermitionLib
  Dim ListCollection As New Collection
  Dim FormStatus As FormStatusLib
#End Region

#Region "Initialize & Object Function"

  Private Sub BasicInitialize()
    ListCollection = DBListCollection("SELECT * FROM MBTRANSDT LEFT OUTER JOIN TABLELIST ON MBTRANSDT.MBTRANSUID = TABLELIST.TABLEMBTRANSUID WHERE MBTRANSDTITEMSTAT > -1 AND TABLELISTUID= '" & SelectedTable.TableUID & "'")
    FormStatus = OBJControlInitialize(ListCollection)
    'Call OBJControlHandler(Me, FormStatus) 'Anjo : 17 Okt tidak perlu
    Call CheckPermission(UserInformation.UserTypeUID, IIf(ListCollection.Count > 0, True, False))

    'BillNo.Text = AutoIDNumber("2205", "PBTRANS", "PBTRANSNO")

    Tax1Check.Checked = PrefInfo.Tax1Active
    Tax1Label.Text = PrefInfo.Tax1Name
    If Tax1Check.Checked Then
      Tax1Txt.Value = PrefInfo.Tax1Rate
      x = 1
      Tax1.Image = My.Resources.OK
    Else
      Tax1Txt.Value = 0
      x = 0
      Tax1.Image = My.Resources._NOTHING
    End If

    Tax2Check.Checked = PrefInfo.Tax2Active
    Tax2Label.Text = PrefInfo.Tax2Name
    If Tax2Check.Checked Then
      Tax2Txt.Value = PrefInfo.Tax2Rate
      y = 1
      Tax2.Image = My.Resources.OK
    Else
      Tax2Txt.Value = 0
      y = 0
      Tax2.Image = My.Resources._NOTHING
    End If

    Call LoadInformation()
  End Sub
  Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)
    Dim TMPRecord As FbDataReader
    TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2205'")
    While TMPRecord.Read()
      UserPermition.PermitionInitialize(TMPRecord.Item("USERCATCREATEACCESS"), TMPRecord.Item("USERCATEDITACCESS"), TMPRecord.Item("USERCATDELETEACCESS"), TMPRecord.Item("USERCATREADACCESS"), TMPRecord.Item("USERCATPRINTACCESS"), TMPRecord.Item("USERCATCHANGEDATEACCESS"), TMPRecord.Item("USERCATCHANGETIMEACCESS"), TMPRecord.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
    End While

    With UserPermition
      If Not .ReadAccess Then
        MainPage.BTNMakeBill.Enabled = False
        MainPage.BTNMakeBill.VisualStyle = C1Input.VisualStyle.Office2007Silver

        ShowMessage(Me, "Maaf, anda tidak mempunyai akses terhadap form ini !" & vbNewLine & "Silakan hubungi administrator anda.")
        Me.Close()
      End If
      If Not .CreateAccess Then
        BTNSave.Enabled = False
      End If
      If Not .EditAccess Then
        BTNSave.Enabled = False
      End If
      If .CreateAccess Then
        If ListCollection.Count > 0 Then
          BTNSave.Enabled = True
        Else
          BTNSave.Enabled = True
        End If
      ElseIf .EditAccess Then
        If ListCollection.Count > 0 Then
          BTNSave.Enabled = True
        Else
          BTNSave.Enabled = False
        End If
      Else
        FormStatus = FormStatusLib.OpenAndLock
        Call OBJControlHandler(Me, FormStatus)
      End If
    End With
  End Sub

  Private Sub fillRounding()
    If PrefInfo.UseRounding = True Then
      Dim TotalGlobal As Double = CDbl(TotalTxt.Text)
      If PrefInfo.UseAutoRounding = True Then
        Dim tmpPembulatan As Integer = 0
        Dim tmpNol As String = ""
        For i As Integer = 1 To PrefInfo.DigitOfRounding
          tmpNol = tmpNol & "0"
        Next
        tmpPembulatan = CDbl("1" & tmpNol)
        If TotalGlobal Mod tmpPembulatan <> 0 Then
          Dim tmpFix As Double
          Dim tmpSisa As Double = 0
          tmpFix = Fix(TotalGlobal / tmpPembulatan)
          tmpFix = (tmpFix * tmpPembulatan) + tmpPembulatan
          lblSetelahRounding.Value = FormatNumber(tmpFix, 0)
          tmpSisa = tmpFix - TotalGlobal
          lblRounding.Value = FormatNumber(tmpSisa, 0)
        Else
          lblRounding.Value = "0"
          lblSetelahRounding.Value = FormatNumber(TotalGlobal, 0)
        End If
      Else
        lblRounding.Value = "0"
        lblSetelahRounding.Value = TotalTxt.Text
        txtRoundingInvisible.Text = TotalTxt.Text
      End If
    Else
      lblRounding.Value = "0"
      lblSetelahRounding.Value = TotalTxt.Text
      txtRoundingInvisible.Text = TotalTxt.Text
    End If
  End Sub

  Private Sub LoadInformation()

    If IsNothing(TransactionUID) Then
      CustOrderInfo = Nothing
      CustInfo = Nothing
      'CustOrderDetail = Nothing
    Else
      'CustOrderDetail = DBListCollection("SELECT * FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "'")

      Dim TMPDetail As DataSet
      Dim TMPHeader As DataSet
      Dim DPValue As Double = 0
      Dim TotalGlobal As Double = 0

      TMPHeader = MyDatabase.MyAdapter("SELECT * FROM MBTrans WHERE MBTransUID = '" & TransactionUID & "'")
      FinalTime = TMPHeader.Tables(0).Rows(0).Item("MODIFIEDDATETIME")

      Dim TotalItem As Double = 0, TotalDisc As Double = 0
      If Not IsDBNull(TMPHeader.Tables(0).Rows(0).Item("ISBILLED")) Then

        Dim Count As Integer = 0
        Dim CountDump As Integer = 0

        If TMPHeader.Tables(0).Rows(0).Item("ISBILLED") = 1 Then

          'Dim TMPRecordPayment As FbDataReader
          Dim TmpRecordPayment As DataSet
          TmpRecordPayment = MyDatabase.MyAdapter("SELECT PBTRANSSTAT FROM PBTRANS WHERE PBTRANSMBTRANSUID = '" & TransactionUID & "'")

          If TmpRecordPayment.Tables(0).Rows.Count > 0 Then
            If TmpRecordPayment.Tables(0).Rows(0).Item("PBTRANSSTAT").ToString() = "1" Then

              Dim OBJNew As New Form_Message_Box_Question
              OBJNew.Name = "Form_Message_Box_Question"
              OBJNew.QuestionLabel.Text = "Maaf, bill tagihan ini sudah dibayarkan, anda tidak dapat melakukan perubahan pada tagihan ini !"
              OBJNew.CenterScreen = True
              OBJNew.BTNYes.Text = "OK"
              OBJNew.BTNNo.Visible = False
              OBJNew.ParentOBJForm = ParentForm
              OBJNew.ShowDialog()

              GoTo View
              Exit Sub
            End If
          End If

          If ShowQuestion(Me, "Bill tagihan sudah dibuat, apakah anda ingin mengedit tagihan yang ada ?") = False Then
            GoTo View
            Exit Sub
          End If

          Dim TMPRecord As DataSet
          TMPRecord = MyDatabase.MyAdapter("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2205'")
          If TMPRecord.Tables(0).Rows.Count > 0 Then
            UserPermition.PermitionInitialize(TMPRecord.Tables(0).Rows(0).Item("USERCATCREATEACCESS"), TMPRecord.Tables(0).Rows(0).Item("USERCATEDITACCESS"), TMPRecord.Tables(0).Rows(0).Item("USERCATDELETEACCESS"), TMPRecord.Tables(0).Rows(0).Item("USERCATREADACCESS"), TMPRecord.Tables(0).Rows(0).Item("USERCATPRINTACCESS"), TMPRecord.Tables(0).Rows(0).Item("USERCATCHANGEDATEACCESS"), TMPRecord.Tables(0).Rows(0).Item("USERCATCHANGETIMEACCESS"), TMPRecord.Tables(0).Rows(0).Item("USERCATMODIFIEDORDERAFTERDUMPED"))
          End If

          With UserPermition
            If Not .DeleteOrderAccess Then
              Dim OBJNew As New Form_User_Authorize_Dialog
              OBJNew.Name = "Form_User_Authorize_Dialog"
              OBJNew.ParentOBJForm = Me
              OBJNew.NeedAuthorizationForMakeBill = True
              OBJNew.ShowDialog()

              Dim TMPRecordAuthorize As DataSet
              TMPRecordAuthorize = MyDatabase.MyAdapter("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2205'")

              If TMPRecordAuthorize.Tables(0).Rows.Count > 0 Then
                UserPermition.PermitionInitialize(TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATCREATEACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATEDITACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATDELETEACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATREADACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATPRINTACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATCHANGEDATEACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATCHANGETIMEACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATMODIFIEDORDERAFTERDUMPED"))
              End If

              With UserPermition
                If .DeleteOrderAccess Then
                  Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MBTRANSSTAT=0,ISBILLED= 0,MBTRANSROUNDINGVAL=0,MBTRANSTIPSVAL=0,MBTRANSSMARTCARDPOINTVAL=0 WHERE MBTRANSUID = '" & TransactionUID & "'")

                  GoTo Edit
                  Exit Sub
                Else
                  GoTo View
                  Exit Sub
                End If
              End With
            End If

            If .DeleteOrderAccess Then
              Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MBTRANSSTAT=0,ISBILLED= 0,MBTRANSROUNDINGVAL=0,MBTRANSTIPSVAL=0,MBTRANSSMARTCARDPOINTVAL=0 WHERE MBTRANSUID = '" & TransactionUID & "'")

              GoTo Edit
              Exit Sub
            Else
              GoTo View
              Exit Sub
            End If
          End With
View:
          Tax1Check.Enabled = False
          Tax2Check.Enabled = False
          Tax1.Enabled = False
          Tax2.Enabled = False
          CustName.Enabled = False
          VirtualKey.Enabled = False : VirtualKey.VisualStyle = C1Input.VisualStyle.Office2007Silver
          BTNDiscount.Enabled = False : BTNDiscount.VisualStyle = C1Input.VisualStyle.Office2007Silver
          BTNSave.Enabled = False : BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver

          Try
            t = TMPHeader.Tables(0).Rows(0).Item("ISFISCAL")
            If t = 1 Then
              Tax.Image = My.Resources.OK
            End If
          Catch ex As Exception
            t = 0
          End Try

          TransactionNo = TMPHeader.Tables(0).Rows(0).Item("MBTRANSNO")
          dtOldDate.Value = TMPHeader.Tables(0).Rows(0).Item("MBTRANSDATE")
          Visitor = TMPHeader.Tables(0).Rows(0).Item("MBTRANSPAXVAL")
          ReservationUID = "NULL"
          If Not IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")) Then
            ReservationUID = TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")
          End If

          CustName.Text = TMPHeader.Tables(0).Rows(0).Item("MBTRANSCUSTNAME")

          'Added By Rudy (31 Mar 2011)
          TMPDetail = MyDatabase.MyAdapter("SELECT SUM(MBTransDtSubVal) AS TOTALPRICE, SUM(MBTransDtItemDiscVal1+MBTransDtItemDiscVal2) AS TOTALDISC, SUM(MBTransDtItemQty) AS TOTALITEM " & _
                                           "FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "' AND MBTransDtItemStat <> -1")
          'If TMPDetail.Tables(0).Rows.Count > 0 Then
          '    Dim counter As Integer = 0
          '    For counter = 0 To TMPDetail.Tables(0).Rows.Count - 1
          '        TotalPrice = TotalPrice + TMPDetail.Tables(0).Rows(counter).Item("MBTRANSDTSUBVAL")
          '        TotalDisc = TotalDisc + CDec(TMPDetail.Tables(0).Rows(counter).Item("MBTRANSDTITEMDISCVAL1")) + CDec(TMPDetail.Tables(0).Rows(counter).Item("MBTRANSDTITEMDISCVAL2"))
          '        TotalItem = TotalItem + TMPDetail.Tables(0).Rows(counter).Item("MBTRANSDTITEMQTY")
          '    Next
          'End If
          'Added By Rudy (31 Mar 2011)
          TotalPrice = TMPDetail.Tables(0).Rows(0).Item("TotalPrice")
          SubTotalTxt.Value = FormatNumber(TMPDetail.Tables(0).Rows(0).Item("TotalPrice"), 0)
          DiscountTxt.Value = FormatNumber(TMPDetail.Tables(0).Rows(0).Item("TotalDisc"), 0)
          TotalItemTxt.Value = FormatNumber(TMPDetail.Tables(0).Rows(0).Item("TotalItem"), 0)
          'Removed By Rudy (31 Mar 2011)
          'SubTotalTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSSUBVAL"), 0)
          'DiscountTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSDISCVAL"), 0)

          Tax1ValTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSTAXVAL1"), 0)
          Tax2ValTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSTAXVAL2"), 0)

          DPtxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSDPVAL"), 0)
          'TotalTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSTOTVAL"), 0)

          TotalTxt.Value = FormatNumber(CDbl(TMPHeader.Tables(0).Rows(0).Item("MBTRANSTOTVAL")) - IIf(IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSROUNDINGVAL")) = False, CDbl(TMPHeader.Tables(0).Rows(0).Item("MBTRANSROUNDINGVAL")), 0), 0)
          If PrefInfo.UseRounding = True Then
            If IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSROUNDINGVAL")) = True Then
              lblRounding.Value = 0
              lblSetelahRounding.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSTOTVAL"), 0)
              txtRoundingInvisible.Text = TMPHeader.Tables(0).Rows(0).Item("MBTRANSTOTVAL")
            Else
              lblRounding.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSROUNDINGVAL"), 0)
              lblSetelahRounding.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSTOTVAL"), 0)
              txtRoundingInvisible.Text = TMPHeader.Tables(0).Rows(0).Item("MBTRANSTOTVAL")
            End If
          Else
            lblRounding.Value = 0
            lblSetelahRounding.Value = TotalTxt.Text
            txtRoundingInvisible.Text = 0
          End If


          'Removed By Rudy (31 Mar 2011)
          'Dim TMPItem As FbDataReader
          'Dim TItem As Double

          'TMPItem = MyDatabase.MyReader("SELECT * FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "'")
          'While TMPItem.Read
          '    TItem = TItem + TMPItem.Item("MBTRANSDTITEMQTY")
          'End While
          'TotalItemTxt.Value = TItem

          If CDec(Tax1ValTxt.Text) <> 0 Then
            Tax1.Image = My.Resources.OK
            Tax1Txt.Value = FormatNumber((CDec(Tax1ValTxt.Text) / (CDec(SubTotalTxt.Text) - CDec(DiscountTxt.Text)) * 100), 0)
          Else
            Tax1.Image = My.Resources._NOTHING
            Tax1Txt.Value = "0"
          End If

          If CDec(Tax2ValTxt.Text) <> 0 Then
            Tax2.Image = My.Resources.OK
            Tax2Txt.Value = FormatNumber((CDec(Tax2ValTxt.Text) / (CDec(SubTotalTxt.Text) - CDec(DiscountTxt.Text) + CDec(Tax1ValTxt.Text)) * 100), 0)
          Else
            Tax2.Image = My.Resources._NOTHING
            Tax2Txt.Value = "0"
          End If

          Exit Sub
        End If
      End If
Edit:
      t = TMPHeader.Tables(0).Rows(0).Item("ISFISCAL")
      If t = 1 Then
        Tax.Image = My.Resources.OK
      End If

      TransactionNo = TMPHeader.Tables(0).Rows(0).Item("MBTRANSNO")
      dtOldDate.Value = TMPHeader.Tables(0).Rows(0).Item("MBTRANSDATE")
      Visitor = TMPHeader.Tables(0).Rows(0).Item("MBTRANSPAXVAL")
      ReservationUID = "NULL"
      If Not IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")) Then
        ReservationUID = TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")
      End If

      DPValue = TMPHeader.Tables(0).Rows(0).Item("MBTransDPVal")
      TMPDetail = MyDatabase.MyAdapter("SELECT SUM(MBTransDtSubVal) AS TOTALPRICE, SUM(MBTransDtItemDiscVal1+MBTransDtItemDiscVal2) AS TOTALDISC, SUM(MBTransDtItemQty) AS TOTALITEM " & _
                                       "FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "' AND MBTransDtItemStat <> -1")

      'Modified By Andy (31 Mar 2011)
      'If TMPDetail.Tables(0).Rows.Count > 0 Then
      '    Dim counter As Integer = 0
      '    For counter = 0 To TMPDetail.Tables(0).Rows.Count - 1
      '        TotalPrice = TotalPrice + TMPDetail.Tables(0).Rows(counter).Item("MBTRANSDTSUBVAL")
      '        TotalDisc = TotalDisc + CDec(TMPDetail.Tables(0).Rows(counter).Item("MBTRANSDTITEMDISCVAL1")) + CDec(TMPDetail.Tables(0).Rows(counter).Item("MBTRANSDTITEMDISCVAL2"))
      '        TotalItem = TotalItem + TMPDetail.Tables(0).Rows(counter).Item("MBTRANSDTITEMQTY")
      '    Next
      'End If
      If IsDBNull(TMPDetail.Tables(0).Rows(0).Item("TotalPrice")) = True Then
        TotalPrice = 0
        SubTotalTxt.Value = 0
        DiscountTxt.Value = 0
        TotalItemTxt.Value = 0
      Else
        TotalPrice = TMPDetail.Tables(0).Rows(0).Item("TotalPrice")
        SubTotalTxt.Value = FormatNumber(TMPDetail.Tables(0).Rows(0).Item("TotalPrice"), 0)
        DiscountTxt.Value = FormatNumber(TMPDetail.Tables(0).Rows(0).Item("TotalDisc"), 0)
        TotalItemTxt.Value = FormatNumber(TMPDetail.Tables(0).Rows(0).Item("TotalItem"), 0)
      End If
      Tax1ValTxt.Value = FormatNumber((((SubTotalTxt.Value - DiscountTxt.Value) * Tax1Txt.Value) / 100), 0)
      Tax2ValTxt.Value = FormatNumber((((SubTotalTxt.Value - DiscountTxt.Value + Tax1ValTxt.Value) * Tax2Txt.Value) / 100), 0)
      DPtxt.Value = FormatNumber(DPValue, 0)

      TotalGlobal = SubTotalTxt.Value - DiscountTxt.Value + Tax1ValTxt.Value + Tax2ValTxt.Value - DPtxt.Value
      TotalTxt.Value = FormatNumber(TotalGlobal, 0)
      Call fillRounding()
      TMPDetail = Nothing

      Tax1Check.Enabled = True
      Tax2Check.Enabled = True
      BTNDiscount.Enabled = True

      Exit Sub
    End If

    'Replace by Andy - Dataset is now used

    '        If IsNothing(TransactionUID) Then
    '            CustOrderInfo = Nothing
    '            CustInfo = Nothing
    '            CustOrderDetail = Nothing
    '        Else
    '            CustOrderDetail = DBListCollection("SELECT * FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "'")

    '            Dim TMPDetail As DataSet
    '            Dim TMPHeader As FbDataReader
    '            Dim DPValue As Double = 0
    '            Dim TotalGlobal As Double = 0

    '            TMPHeader = MyDatabase.MyReader("SELECT * FROM MBTrans WHERE MBTransUID = '" & TransactionUID & "'")
    '            TMPHeader.Read()
    '            FinalTime = TMPHeader.Item("MODIFIEDDATETIME")

    '            Dim TotalItem As Double = 0, TotalDisc As Double = 0
    '            If Not IsDBNull(TMPHeader.Item("ISBILLED")) Then

    '                Dim Count As Integer = 0
    '                Dim CountDump As Integer = 0

    '                If TMPHeader.Item("ISBILLED") = 1 Then

    '                    'Dim TMPRecordPayment As FbDataReader
    '                    Dim TmpRecordPayment As DataSet
    '                    TmpRecordPayment = MyDatabase.MyAdapter("SELECT PBTRANSSTAT FROM PBTRANS WHERE PBTRANSMBTRANSUID = '" & TransactionUID & "'")

    '                    If TmpRecordPayment.Tables(0).Rows.Count > 0 Then
    '                        If TmpRecordPayment.Tables(0).Rows(0).Item("PBTRANSSTAT").ToString() = "1" Then

    '                            Dim OBJNew As New Form_Message_Box_Question
    '                            OBJNew.Name = "Form_Message_Box_Question"
    '                            OBJNew.QuestionLabel.Text = "Maaf, bill tagihan ini sudah dibayarkan, anda tidak dapat melakukan perubahan pada tagihan ini !"
    '                            OBJNew.CenterScreen = True
    '                            OBJNew.BTNYes.Text = "OK"
    '                            OBJNew.BTNNo.Visible = False
    '                            OBJNew.ParentOBJForm = ParentForm
    '                            OBJNew.ShowDialog()

    '                            GoTo View
    '                            Exit Sub
    '                        End If
    '                    End If

    '                    If ShowQuestion(Me, "Bill tagihan sudah dibuat, apakah anda ingin mengedit tagihan yang ada ?") = False Then
    '                        GoTo View
    '                        Exit Sub
    '                    End If

    '                    Dim TMPRecord As DataSet
    '                    TMPRecord = MyDatabase.MyAdapter("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2205'")
    '                    If TMPRecord.Tables(0).Rows.Count > 0 Then
    '                        UserPermition.PermitionInitialize(TMPRecord.Tables(0).Rows(0).Item("USERCATCREATEACCESS"), TMPRecord.Tables(0).Rows(0).Item("USERCATEDITACCESS"), TMPRecord.Tables(0).Rows(0).Item("USERCATDELETEACCESS"), TMPRecord.Tables(0).Rows(0).Item("USERCATREADACCESS"), TMPRecord.Tables(0).Rows(0).Item("USERCATPRINTACCESS"), TMPRecord.Tables(0).Rows(0).Item("USERCATCHANGEDATEACCESS"), TMPRecord.Tables(0).Rows(0).Item("USERCATCHANGETIMEACCESS"), TMPRecord.Tables(0).Rows(0).Item("USERCATMODIFIEDORDERAFTERDUMPED"))
    '                    End If

    '                    With UserPermition
    '                        If Not .DeleteOrderAccess Then
    '                            Dim OBJNew As New Form_User_Authorize_Dialog
    '                            OBJNew.Name = "Form_User_Authorize_Dialog"
    '                            OBJNew.ParentOBJForm = Me
    '                            OBJNew.NeedAuthorizationForMakeBill = True
    '                            OBJNew.ShowDialog()

    '                            Dim TMPRecordAuthorize As DataSet
    '                            TMPRecordAuthorize = MyDatabase.MyAdapter("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2205'")

    '                            If TMPRecordAuthorize.Tables(0).Rows.Count > 0 Then
    '                                UserPermition.PermitionInitialize(TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATCREATEACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATEDITACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATDELETEACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATREADACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATPRINTACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATCHANGEDATEACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATCHANGETIMEACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATMODIFIEDORDERAFTERDUMPED"))
    '                            End If


    '                            With UserPermition
    '                                If .DeleteOrderAccess Then
    '                                    Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MBTRANSSTAT=0,ISBILLED= 0 WHERE MBTRANSUID = '" & TransactionUID & "'")

    '                                    GoTo Edit
    '                                    Exit Sub
    '                                Else
    '                                    GoTo View
    '                                    Exit Sub
    '                                End If
    '                            End With
    '                        End If

    '                        If .DeleteOrderAccess Then
    '                            Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MBTRANSSTAT=0,ISBILLED= 0 WHERE MBTRANSUID = '" & TransactionUID & "'")

    '                            GoTo Edit
    '                            Exit Sub
    '                        Else
    '                            GoTo View
    '                            Exit Sub
    '                        End If
    '                    End With
    'View:
    '                    Tax1Check.Enabled = False
    '                    Tax2Check.Enabled = False
    '                    Tax1.Enabled = False
    '                    Tax2.Enabled = False
    '                    CustName.Enabled = False
    '                    VirtualKey.Enabled = False
    '                    BTNDiscount.Enabled = False
    '                    BTNSave.Enabled = False

    '                    Try
    '                        t = TMPHeader.Item("ISFISCAL")
    '                        If t = 1 Then
    '                            Tax.Image = My.Resources.OK
    '                        End If
    '                    Catch ex As Exception
    '                        t = 0
    '                    End Try

    '                    TransactionNo = TMPHeader.Item("MBTRANSNO")
    '                    Visitor = TMPHeader.Item("MBTRANSPAXVAL")
    '                    ReservationUID = "NULL"
    '                    If Not IsDBNull(TMPHeader.Item("MBTRANSRSVTRANSUID")) Then
    '                        ReservationUID = TMPHeader.Item("MBTRANSRSVTRANSUID")
    '                    End If

    '                    CustName.Text = TMPHeader.Item("MBTRANSCUSTNAME")

    '                    SubTotalTxt.Value = FormatNumber(TMPHeader.Item("MBTRANSSUBVAL"), 0)
    '                    DiscountTxt.Value = FormatNumber(TMPHeader.Item("MBTRANSDISCVAL"), 0)

    '                    Tax1ValTxt.Value = FormatNumber(TMPHeader.Item("MBTRANSTAXVAL1"), 0)
    '                    Tax2ValTxt.Value = FormatNumber(TMPHeader.Item("MBTRANSTAXVAL2"), 0)

    '                    DPtxt.Value = FormatNumber(TMPHeader.Item("MBTRANSDPVAL"), 0)
    '                    TotalTxt.Value = FormatNumber(TMPHeader.Item("MBTRANSTOTVAL"), 0)

    '                    Dim TMPItem As FbDataReader
    '                    Dim TItem As Double

    '                    TMPItem = MyDatabase.MyReader("SELECT * FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "'")
    '                    While TMPItem.Read
    '                        TItem = TItem + TMPItem.Item("MBTRANSDTITEMQTY")
    '                    End While
    '                    TotalItemTxt.Value = TItem

    '                    Exit Sub
    '                End If
    '            End If
    'Edit:
    '            t = TMPHeader.Item("ISFISCAL")
    '            If t = 1 Then
    '                Tax.Image = My.Resources.OK
    '            End If

    '            TransactionNo = TMPHeader.Item("MBTRANSNO")
    '            Visitor = TMPHeader.Item("MBTRANSPAXVAL")
    '            ReservationUID = "NULL"
    '            If Not IsDBNull(TMPHeader.Item("MBTRANSRSVTRANSUID")) Then
    '                ReservationUID = TMPHeader.Item("MBTRANSRSVTRANSUID")
    '            End If

    '            DPValue = TMPHeader.Item("MBTransDPVal")
    '            TMPDetail = MyDatabase.MyAdapter("SELECT * FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "'")
    '            If TMPDetail.Tables(0).Rows.Count > 0 Then
    '                TotalPrice = TotalPrice + TMPDetail.Tables(0).Rows(0).Item("MBTRANSDTSUBVAL")
    '                TotalDisc = TotalDisc + CDec(TMPDetail.Tables(0).Rows(0).Item("MBTRANSDTITEMDISCVAL1")) + CDec(TMPDetail.Tables(0).Rows(0).Item("MBTRANSDTITEMDISCVAL2"))
    '                TotalItem = TotalItem + TMPDetail.Tables(0).Rows(0).Item("MBTRANSDTITEMQTY")
    '            End If

    '            SubTotalTxt.Value = FormatNumber(TotalPrice, 0)
    '            DiscountTxt.Value = FormatNumber(TotalDisc, 0)

    '            Tax1ValTxt.Value = FormatNumber((((SubTotalTxt.Value - DiscountTxt.Value) * Tax1Txt.Value) / 100), 0)
    '            Tax2ValTxt.Value = FormatNumber((((SubTotalTxt.Value - DiscountTxt.Value + Tax1ValTxt.Value) * Tax2Txt.Value) / 100), 0)
    '            DPtxt.Value = FormatNumber(DPValue, 0)
    '            TotalItemTxt.Value = TotalItem

    '            TotalGlobal = SubTotalTxt.Value - DiscountTxt.Value + Tax1ValTxt.Value + Tax2ValTxt.Value - DPtxt.Value
    '            TotalTxt.Value = FormatNumber(TotalGlobal, 0)

    '            TMPDetail = Nothing

    '            Tax1Check.Enabled = True
    '            Tax2Check.Enabled = True
    '            BTNDiscount.Enabled = True

    '            Exit Sub
    '        End If


  End Sub

  Private Sub ReinitializePrice()
    Dim TotalGlobal As Double = 0
    If Tax1Check.Checked = True Then
      Tax1ValTxt.Value = FormatNumber((Tax1Txt.Text * (SubTotalTxt.Text - DiscountTxt.Value) / 100), 0)
    Else
      Tax1ValTxt.Value = 0
    End If

    If Tax2Check.Checked = True Then
      Tax2ValTxt.Value = FormatNumber((Tax2Txt.Text * (SubTotalTxt.Text - DiscountTxt.Value + Tax1ValTxt.Value) / 100), 0)
    Else
      Tax2ValTxt.Value = 0
    End If

    TotalGlobal = SubTotalTxt.Text - DiscountTxt.Text + Tax1ValTxt.Text + Tax2ValTxt.Text - DPtxt.Text
    TotalTxt.Value = FormatNumber(TotalGlobal, 0)
    Call fillRounding()
  End Sub

  Private Function ReInitializeDisc(ByVal CustUID As String, ByVal ItemUID As String) As Double
    Dim TMPRecord As FbDataReader
    Dim Query As String
    Dim DiscCatRecord As FbDataReader
    Dim QueryDiscCat As String
    Dim DiscRecord As FbDataReader
    Dim DiscQuery As String
    Dim CUSTCATDISCUIDVALUE As String
    Try
      Query = "SELECT a.CUSTCATUID, " & _
                  "(SELECT CUSTCATNAME FROM CUSTCAT WHERE CUSTCATUID = a.CUSTCATUID) AS CUSTCATNAME, " & _
                  "a.CUSTUID, a.CUSTNO, a.CUSTNAME, a.CUSTADDR1, a.CUSTCITYPROVZIPCODE " & _
                  "FROM CUST a WHERE CUSTUID LIKE '" & CustUID & "'"

      TMPRecord = MyDatabase.MyReader(Query)
      TMPRecord.Read()
      CUSTCATDISCUIDVALUE = TMPRecord.Item("CUSTCATDISCUID")
      TMPRecord = Nothing

      QueryDiscCat = "SELECT a.DISCDTUID, a.DISCUID, a.DISCCATMENUUID, " & _
                  "(SELECT INVENCATNAME FROM INVENCAT WHERE INVENCATUID = a.DISCCATMENUUID), " & _
                  "a.DISCPERCENTAGE FROM DISCDT a " & _
                  "WHERE DISCUID LIKE '" & CUSTCATDISCUIDVALUE & "'"
      DiscCatRecord = MyDatabase.MyReader(QueryDiscCat)
      DiscCatRecord.Read()

      DiscQuery = "SELECT COUNT(*)as TOTAL FROM INVEN a WHERE INVENUID LIKE '" & ItemUID & "' AND INVENCATUID LIKE '" & DiscCatRecord.Item("DISCCATMENUUID") & "'"
      DiscRecord = MyDatabase.MyReader(DiscQuery)
      DiscRecord.Read()

      If DiscRecord.Item("TOTAL") > 0 Then
        Return DiscCatRecord.Item("DISCPERCENTAGE")
      Else
        Return Nothing
      End If

    Catch ex As Exception
      Return 0
    End Try
  End Function

  Private Sub ShowPrintPreview(Optional ByVal Nota As Boolean = False)

    Dim OBJNew As New Form_Print_Preview
    Dim Query As String

    'Query = "SELECT a.MBTRANSUID, a.MBTRANSNO, a.MBTRANSDATE, a.MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME, a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID, a.MBTRANSRSVTRANSUID, a.MBTRANSSUBVAL, a.MBTRANSDISCPERC, a.MBTRANSDISCVAL, a.MBTRANSTAXVAL1, a.MBTRANSTAXVAL2, a.MBTRANSDPVAL, a.MBTRANSTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT,a.CREATEDUSER, a.MODIFIEDUSER,a.MODIFIEDDATETIME, b.TABLELISTNAME " & _
    '           "FROM MBTRANS a LEFT JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE MBTRANSUID = '" & TransactionUID & "'"

    Query = "SELECT a.MBTRANSUID, a.MBTRANSNO, a.MBTRANSDATE, a.MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME," & _
        "a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID, a.MBTRANSRSVTRANSUID, a.MBTRANSSUBVAL," & _
        "a.MBTRANSDISCPERC, a.MBTRANSDISCVAL, a.MBTRANSTAXVAL1, a.MBTRANSTAXVAL2, a.MBTRANSDPVAL,IIF(a.MBTRANSROUNDINGVAL IS NULL,0,a.MBTRANSROUNDINGVAL) AS MBTRANSROUNDINGVAL," & _
        "a.MBTRANSTOTVAL-IIF(a.MBTRANSROUNDINGVAL IS NULL,0,a.MBTRANSROUNDINGVAL) AS MBTRANSTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT,a.CREATEDUSER," & _
        "a.MODIFIEDUSER,a.MODIFIEDDATETIME, b.TABLELISTNAME," & _
        "(SELECT CUSTNO FROM CUST WHERE CUSTUID = a.MBTRANSCUSTUID) AS CUSTNO," & _
        "(SELECT CUSTADDR1|| '^*^' || CUSTTELP1 FROM CUST WHERE CUSTUID = a.MBTRANSCUSTUID) AS Alamat," & _
        "(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = a.MBTRANSSERVICETYPEUID ) AS SERVICENAME," & _
        "(SELECT SUM((M.MBTRANSDTITEMPRICE * M.MBTRANSDTITEMQTY)-M.MBTRANSDTITEMDISCVAL1-M.MBTRANSDTITEMDISCVAL2) FROM MBTRANSDT M LEFT OUTER JOIN INVEN I ON I.INVENUID=M.MBTRANSDTITEMUID LEFT OUTER JOIN INVENCAT IC ON IC.INVENCATUID=I.INVENCATUID WHERE M.MBTRANSDTITEMSTAT > -1 AND IC.INVENCATSUBCATEGORYID=1 AND M.MBTRANSUID=a.MBTRANSUID) AS SUBTOTALFOOD," & _
        "(SELECT SUM((M.MBTRANSDTITEMPRICE * M.MBTRANSDTITEMQTY)-M.MBTRANSDTITEMDISCVAL1-M.MBTRANSDTITEMDISCVAL2) FROM MBTRANSDT M LEFT OUTER JOIN INVEN I ON I.INVENUID=M.MBTRANSDTITEMUID LEFT OUTER JOIN INVENCAT IC ON IC.INVENCATUID=I.INVENCATUID WHERE M.MBTRANSDTITEMSTAT > -1 AND IC.INVENCATSUBCATEGORYID=2 AND M.MBTRANSUID=a.MBTRANSUID) AS SUBTOTALBEVERAGE," & _
        "(SELECT SUM((M.MBTRANSDTITEMPRICE * M.MBTRANSDTITEMQTY)-M.MBTRANSDTITEMDISCVAL1-M.MBTRANSDTITEMDISCVAL2) FROM MBTRANSDT M LEFT OUTER JOIN INVEN I ON I.INVENUID=M.MBTRANSDTITEMUID LEFT OUTER JOIN INVENCAT IC ON IC.INVENCATUID=I.INVENCATUID WHERE M.MBTRANSDTITEMSTAT > -1 AND IC.INVENCATSUBCATEGORYID=3 AND M.MBTRANSUID=a.MBTRANSUID) AS SUBTOTALMENUETC " & _
        "FROM MBTRANS a LEFT OUTER JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE a.MBTRANSUID = '" & TransactionUID & "'"

    OBJNew.Name = "Form_Print_Preview"
    OBJNew.RPTTitle = "Bill"

    If isDelivery = Nothing Then
      If PrefInfo.printSize = "58" Then
        Dim myMakeBill As New Make_Bill58
        myMakeBill.BillTableTxt.Visible = False
        OBJNew.RPTDocument = myMakeBill
      Else
        Dim myMakeBill As New Make_Bill
        myMakeBill.BillTableTxt.Visible = False
        OBJNew.RPTDocument = myMakeBill
      End If
    Else
      If PrefInfo.printSize = "58" Then
        Dim myMakeBill2 As New Make_Bill_Delivery58
        myMakeBill2 = New Make_Bill_Delivery58
        myMakeBill2.BillTableTxt.Visible = False
        OBJNew.RPTDocument = myMakeBill2
      Else
        Dim myMakeBill2 As New Make_Bill_Delivery
        myMakeBill2 = New Make_Bill_Delivery
        myMakeBill2.BillTableTxt.Visible = False
        OBJNew.RPTDocument = myMakeBill2
      End If
    End If

    OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
    OBJNew.VersiNota = Nota
    OBJNew.ShowDialog()
  End Sub

#End Region

#Region "Form Control Function"

  Private Sub Form_Invoice_Make_Bill_Activated(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Activated
    'MessageBox.Show(DiscountFromMakeBillFCDP)
  End Sub

  Private Sub Form_Invoice_Make_Bill_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed

  End Sub

  Private Sub Form_Make_Bill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    If PrefInfo.UseRounding = True Then
      If screenWidth < 1024 Then
        Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y)
      Else
        Me.Location = New System.Drawing.Point(MainPage.Location.X + 268, MainPage.Location.Y + 44)
      End If

      lblRounding.Visible = True
      If PrefInfo.UseAutoRounding = True Then
        lblSetelahRounding.Size = New System.Drawing.Size(263, 42)
        cmdCalcRounding.Visible = False
      Else
        lblSetelahRounding.Size = New System.Drawing.Size(208, 42)
        cmdCalcRounding.Visible = True
      End If
    Else
      If screenWidth < 1024 Then
        Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y)
      Else
        Me.Location = New System.Drawing.Point(MainPage.Location.X + 268, MainPage.Location.Y + 44 + 100)
      End If
      lblRounding.Visible = False
      GroupBox.Size = New System.Drawing.Point(401, 414)
      Me.Size = New System.Drawing.Size(422, 506)
      BTNDiscount.Location = New System.Drawing.Point(7, 426)
      BTNSave.Location = New System.Drawing.Point(BTNSave.Location.X, BTNDiscount.Location.Y)
      BTNCancel.Location = New System.Drawing.Point(BTNCancel.Location.X, BTNDiscount.Location.Y)
    End If
    If screenWidth < 1024 Then
      Dim origWidth As Integer = Me.Width
      Dim origHeight As Integer = Me.Height
      Me.Width = screenWidth
      Me.Height = screenHeight
      Dim fSize As New SizeF((Me.Width / origWidth), (Me.Height / origHeight))
      GroupBox.Scale(fSize)
      BTNDiscount.Scale(fSize)
      BTNCancel.Scale(fSize)
      BTNSave.Scale(fSize)
    End If
    Me.Cursor = Cursors.Default
    Call BasicInitialize()
    Call ShowPoleDisplay("Total : " & lblSetelahRounding.Text)
    If PrefInfo.useBarcodeGift = "1" Then cmdBarcode.Visible = True Else cmdBarcode.Visible = False
    If PrefInfo.VIsAutoDisc = True Then
      VUIDAutoDisc = GetFieldValueDBString("CUSTCAT CC, CUST C, MBTRANS MBT", "CC.CUSTCATDISCUIDAUTO", "WHERE C.CUSTUID= MBT.MBTRANSCUSTUID AND CC.CUSTCATUID = C.CUSTCATUID AND MBT.MBTRANSUID ='" & TransactionUID & "'")
      BTNDiscount.Visible = False
      BTNDiscount_Click(sender, e)
    End If
    Form_Custm_Display_MakeBill.LblDiscountVal.Text = DiscountTxt.Text
    Form_Custm_Display_MakeBill.LabelSCVal.Text = Tax1ValTxt.Text
    Form_Custm_Display_MakeBill.LabelPBVal.Text = Tax2ValTxt.Text
    Form_Custm_Display_MakeBill.LabelDPVal.Text = DPtxt.Text
    Form_Custm_Display_MakeBill.LabelRoundVal.Text = lblRounding.Text
    Form_Custm_Display_MakeBill.LabelTAVal.Text = lblSetelahRounding.Text
    'FoundMakeBillForm = "True"
    'MessageBox.Show(FoundMakeBillForm)
  End Sub

  Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancel.Click
    'CloseFormCustomerDisplay = True
    Me.Close()
  End Sub

  Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click
    If Authorize = True Then
      Authorize = False
      UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, UDeptUID)
      Call MainPage.StatusBarInitialize()
    End If

    'BillNo.Text = AutoIDNumber("BIL", "PBTRANS", "PBTRANSNO")
    Dim TMPHeader As FbDataReader
    TMPHeader = MyDatabase.MyReader("SELECT * FROM MBTrans WHERE MBTransUID = '" & TransactionUID & "'")
    TMPHeader.Read()
    Dim ModifiedTime As DateTime
    ModifiedTime = TMPHeader.Item("MODIFIEDDATETIME")

    'MsgBox(FinalTime & " = " & ModifiedTime)

    If FinalTime <> ModifiedTime Then
      ShowMessage(Me, "Maaf, anda tidak dapat merubah bill tagihan, karena ada user lain yang telah melakukan perubahan pada saat anda sedang mengedit tagihan ini !")
      Me.Close()
      ParentOBJForm.close()
      Exit Sub
    End If

    If TotalItemTxt.Text = 0 Then
      ShowMessage(Me, "Silakan buat transaksi order pesanan, sebelum membuat bill tagihan !")
      Exit Sub
    End If

    'If CustName.Enabled = False Then
    '    SaveStatus = True
    '    Call ShowPrintPreview(True)

    '    Me.Close()
    '    Exit Sub
    'End If

    Dim Query As String = Nothing
    Dim D As Integer = 0
    Dim tmpPoint As Integer = 0
    If isUseRFID = True Then
      If CDec(FNBConversionPoint) > 0 Then
        If CDec(SubTotalTxt.Text) - CDec(DiscountTxt.Text) > 0 Then
          tmpPoint = Fix((CDec(SubTotalTxt.Text) - CDec(DiscountTxt.Text)) / CDec(FNBConversionPoint))
        Else
          tmpPoint = 0
        End If
      Else
        tmpPoint = 0
      End If
    Else
      tmpPoint = 0
    End If
    If CDec(DiscountTxt.Text) <> 0 Then
      Query = "UPDATE MBTRANS SET MBTRANSCUSTNAME ='" & ReplacePetik(CustName.Text) & "',MBTRANSSUBVAL ='" & CDbl(SubTotalTxt.Text) & "', MBTRANSDISCPERC ='" & Replace(Format((CDec(DiscountTxt.Text) * 100) / CDec(SubTotalTxt.Text), "#,##0.000"), ",", ".") & "', MBTRANSDISCVAL ='" & CDbl(DiscountTxt.Text) & "', MBTransTaxVal1 = '" & CDbl(Tax1ValTxt.Text) & "', MBTransTaxVal2 = '" & CDbl(Tax2ValTxt.Text) & "', MBTRANSTOTVAL='" & CDbl(lblSetelahRounding.Text) & "', MBTRANSSTAT='1', ISBILLED='1', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',ISFISCAL='" & t & "',MBTRANSROUNDINGVAL='" & CDbl(lblRounding.Text) & "',MBTRANSTIPSVAL='0',MBTRANSSMARTCARDPOINTVAL='" & tmpPoint & "' WHERE MBTRANSUID = '" & TransactionUID & "'"
    Else
      Query = "UPDATE MBTRANS SET MBTRANSCUSTNAME ='" & ReplacePetik(CustName.Text) & "',MBTRANSSUBVAL ='" & CDbl(SubTotalTxt.Text) & "', MBTRANSDISCPERC ='0', MBTRANSDISCVAL ='" & CDbl(DiscountTxt.Text) & "', MBTransTaxVal1 = '" & CDbl(Tax1ValTxt.Text) & "', MBTransTaxVal2 = '" & CDbl(Tax2ValTxt.Text) & "', MBTRANSTOTVAL='" & CDbl(lblSetelahRounding.Text) & "', MBTRANSSTAT='1', ISBILLED='1', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',ISFISCAL='" & t & "',MBTRANSROUNDINGVAL='" & CDbl(lblRounding.Text) & "',MBTRANSTIPSVAL='0',MBTRANSSMARTCARDPOINTVAL='" & tmpPoint & "' WHERE MBTRANSUID = '" & TransactionUID & "'"
    End If
    Call MyDatabase.MyAdapter(Query)

    Dim Lastdiskitem As Double = 0, Lastprice As Double = 0
    For i As Integer = 1 To TMPDiscListCollection.Count
      Dim TmpArray As New ArrayList
      TmpArray = TMPDiscListCollection(i)
      If i Mod 2 = 1 Then
        Lastprice = TmpArray(4) * TmpArray(7)
        Lastdiskitem = TmpArray(10) * TmpArray(11)
        Query = "UPDATE MBTRANSDT SET MBTRANSDTITEMDISCUID1 = '" & TmpArray(5) & "', MBTRANSDTITEMDISCVAL1='" & CDec(TmpArray(10)) * CDec(TmpArray(11)) & "', MBTRANSDTSUBVAL ='" & CDec(TmpArray(4)) * CDec(TmpArray(7)) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSDTUID LIKE '" & TmpArray(1) & "'"
        Call MyDatabase.MyAdapter(Query)
      Else
        Query = "UPDATE MBTRANSDT SET MBTRANSDTITEMDISCUID2 = '" & TmpArray(5) & "', MBTRANSDTITEMDISCVAL2='" & CDec(TmpArray(10)) * CDec(TmpArray(11)) & "', MBTRANSDTSUBVAL ='" & Lastprice & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSDTUID LIKE '" & TmpArray(1) & "'"
        Lastdiskitem = 0
        Call MyDatabase.MyAdapter(Query)
      End If
    Next

    Me.Cursor = Cursors.WaitCursor
    SaveStatus = True
    Make_Order.pubQueryLap = ""
    Call ShowPoleDisplay("Total:" & TotalTxt.Text, False)
    'MsgBox(PrefInfo.pubJumlahPrintOut)
    If PrefInfo.PrintMakeOrder.ToString = "1" Then
      For i As Integer = 1 To CInt(PrefInfo.pubJumlahPrintOutBill)
        Call ShowPrintPreview(True)
        Application.DoEvents()
      Next
    End If
    If PrefInfo.UseKitchenPrintOut = "1" Then
      publicCustomerNameInvoiceApplication = CustName.Text
      Call ToPrint()
    End If
    'Form_Custm_Display_MakeBill.Close()
    ItemMixFormCustomerDisplay = ""
    Form_Custm_Display_MakeBill.IdFromInvoiceList.Text = ""
    Me.Close()

  End Sub

  Private Function GetPrinterName(ByVal idKitchen As String) As String
    GetPrinterName = ""
    Dim rs As FbDataReader
    rs = MyDatabase.MyReader("SELECT * FROM KITCHEN WHERE KITCHENUID='" & ReplacePetik(idKitchen) & "'")
    While rs.Read = True
      If IsDBNull(rs("KITCHENSPLITORDER")) = True Then
        KitchenSplitOrder = "0"
      Else
        KitchenSplitOrder = rs("KITCHENSPLITORDER").ToString
      End If
      If IsDBNull(rs("KITCHENPRINTER")) = False Then
        GetPrinterName = rs("KITCHENPRINTER")
      Else
        GetPrinterName = ""
      End If
    End While
    rs = Nothing
  End Function

  Private Sub ToPrint()

    Dim rs As FbDataReader, selPrinterName As String = ""

    rs = MyDatabase.MyReader("SELECT DISTINCT(INVENKITCHENUID) AS KodeKitchen FROM INVEN A INNER JOIN " & _
                            "(SELECT IIF(B.MBTRANSDTITEMUID IS NULL,A.MBTRANSDTITEMUID,B.MBTRANSDTITEMUID) AS KodeBarang FROM MBTRANSDT A LEFT JOIN MBTRANSDTDETAIL B ON A.MBTRANSDTUID=B.MBTRANSDTUID WHERE A.PRINT=1 AND MBTRANSUID='" & TransactionUID & "') B " & _
                            "ON A.INVENUID=B.KodeBarang")
    While rs.Read = True
      selPrinterName = GetPrinterName(rs("KodeKitchen"))
      If Len(Trim(selPrinterName)) > 0 Then
        If KitchenSplitOrder = "0" Then
          If PrefInfo.printSize = "58" Then
            Make_Order58.pubHarusCetakNotes = True
            Make_Order58.pubQueryLap = "SELECT B.* FROM INVEN A INNER JOIN " & _
                                    "(" & _
                                    "SELECT a.MBTRANSDTISTAKEAWAY, a.MBTRANSDTITEMNOTE, a.MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang, a.MBTRANSDTITEMNAME, a.MBTRANSDTITEMQTY,b.MBTRANSDTITEMNAME AS DETAILITEM,b.MBTRANSDTITEMQTY AS DETAILQTY " & _
                                    "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
                                    "WHERE MBTRANSUID ='" & TransactionUID & "' AND a.PRINT=1 " & _
                                    ") B ON A.INVENUID=B.KodeBarang WHERE INVENKITCHENUID='" & Trim(rs("KodeKitchen")) & "'"
          Else
            Make_Order.pubHarusCetakNotes = True
            'Make_Order.pubQueryLap = "SELECT B.* FROM INVEN A INNER JOIN " & _
            '                        "(" & _
            '                        "SELECT a.MBTRANSDTISTAKEAWAY, a.MBTRANSDTITEMNOTE, a.MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang, a.MBTRANSDTITEMNAME, a.MBTRANSDTITEMQTY,b.MBTRANSDTITEMNAME AS DETAILITEM,b.MBTRANSDTITEMQTY AS DETAILQTY, IIF(MBTRANSDTPARENTUID IS NULL, a.MBTRANSDTITEMNAME||ASCII_CHAR(13)||IIF(MBTRANSDTLISTNOTE IS NULL OR TRIM(MBTRANSDTLISTNOTE)='','','+'||REPLACE(a.MBTRANSDTLISTNOTE,'^#@$^',ASCII_CHAR(13)||'+')),(SELECT dtMod.MBTRANSDTITEMNAME||' -> + ' FROM MBTRANSDT dtMod WHERE dtMod.MBTRANSDTUID=a.MBTRANSDTPARENTUID)||a.MBTRANSDTITEMNAME) AS MBTRANSDTITEMLISTNOTE " & _
            '                        "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
            '                        "WHERE MBTRANSUID ='" & TransactionUID & "' AND a.PRINT=1 " & _
            '                        ") B ON A.INVENUID=B.KodeBarang WHERE INVENKITCHENUID='" & Trim(rs("KodeKitchen")) & "'"
            Make_Order.pubQueryLap = "SELECT B.* FROM INVEN A INNER JOIN " & _
                                            "(" & _
                                            "SELECT a.MBTRANSDTISTAKEAWAY, a.MBTRANSDTITEMNOTE, a.MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang, a.MBTRANSDTITEMNAME," & _
                                            "IIF(MBTRANSDTPARENTUID IS NULL, a.MBTRANSDTITEMNAME||ASCII_CHAR(13)||IIF(MBTRANSDTLISTNOTE IS NULL OR TRIM(MBTRANSDTLISTNOTE)='','','+'||REPLACE(a.MBTRANSDTLISTNOTE,'^#@$^',ASCII_CHAR(13)||'+')),(SELECT dtMod.MBTRANSDTITEMNAME||' -> + ' FROM MBTRANSDT dtMod WHERE dtMod.MBTRANSDTUID=a.MBTRANSDTPARENTUID)||a.MBTRANSDTITEMNAME) AS MBTRANSDTITEMLISTNOTE," & _
                                            "a.MBTRANSDTITEMQTY,b.MBTRANSDTITEMNAME AS DETAILITEM,b.MBTRANSDTITEMQTY AS DETAILQTY " & _
                                            "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
                                            "WHERE MBTRANSUID ='" & TransactionUID & "' AND a.PRINT=1 " & _
                                            ") B ON A.INVENUID=B.KodeBarang WHERE INVENKITCHENUID='" & Trim(rs("KodeKitchen")) & "'"

          End If

          Call ShowMakeOrderPrintPreview(True, selPrinterName)
        Else
          Dim rs2 As FbDataReader = MyDatabase.MyReader("SELECT B.MBTRANSDTUID,B.MBTRANSDTITEMQTY FROM INVEN A INNER JOIN " & _
                                  "(" & _
                                  "SELECT a.MBTRANSDTISTAKEAWAY, a.MBTRANSDTITEMNOTE,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTUID,b.MBTRANSDTDETAILUID) AS MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang,a.MBTRANSDTITEMQTY,b.MBTRANSDTITEMNAME AS DETAILITEM,b.MBTRANSDTITEMQTY AS DETAILQTY " & _
                                  "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
                                  "WHERE MBTRANSUID ='" & TransactionUID & "' AND a.PRINT=1 " & _
                                  ") B ON A.INVENUID=B.KodeBarang WHERE INVENKITCHENUID='" & Trim(rs("KodeKitchen")) & "'")
          While rs2.Read = True
            For i As Integer = 1 To CInt(rs2("MBTRANSDTITEMQTY"))
              If PrefInfo.printSize = "58" Then
                Make_Order_Split58.pubHarusCetakNotes = True
                Make_Order_Split58.pubQueryLap = "SELECT B.* FROM INVEN A INNER JOIN " & _
                                        "(" & _
                                        "SELECT a.MBTRANSDTISTAKEAWAY, a.MBTRANSDTITEMNOTE,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTUID,b.MBTRANSDTDETAILUID) AS MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang, IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMNAME,a.MBTRANSDTITEMNAME || ' - ' || b.MBTRANSDTITEMNAME) AS MBTRANSDTITEMNAME, a.MBTRANSDTITEMQTY,b.MBTRANSDTITEMNAME AS DETAILITEM,b.MBTRANSDTITEMQTY AS DETAILQTY " & _
                                        "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
                                        "WHERE MBTRANSUID ='" & TransactionUID & "' AND a.PRINT=1 " & _
                                        ") B ON A.INVENUID=B.KodeBarang WHERE B.MBTRANSDTUID='" & Trim(rs2("MBTRANSDTUID")) & "'"
              Else
                Make_Order_Split.pubHarusCetakNotes = True
                Make_Order_Split.pubQueryLap = "SELECT B.* FROM INVEN A INNER JOIN " & _
                                        "(" & _
                                        "SELECT a.MBTRANSDTISTAKEAWAY, a.MBTRANSDTITEMNOTE,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTUID,b.MBTRANSDTDETAILUID) AS MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang, IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMNAME,a.MBTRANSDTITEMNAME || ' - ' || b.MBTRANSDTITEMNAME) AS MBTRANSDTITEMNAME, a.MBTRANSDTITEMQTY,b.MBTRANSDTITEMNAME AS DETAILITEM,b.MBTRANSDTITEMQTY AS DETAILQTY " & _
                                        "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
                                        "WHERE MBTRANSUID ='" & TransactionUID & "' AND a.PRINT=1 " & _
                                        ") B ON A.INVENUID=B.KodeBarang WHERE B.MBTRANSDTUID='" & Trim(rs2("MBTRANSDTUID")) & "'"
              End If
              Call ShowPrintPreviewSplit(True, selPrinterName)
            Next
          End While
          rs2 = Nothing
        End If
      End If
    End While
    rs = Nothing

  End Sub

  Private Sub ShowPrintPreviewSplit(Optional ByVal Nota As Boolean = False, Optional ByVal printerName As String = "")
    Form_Print_Preview.Close()
    Dim OBJNew As New Form_Print_Preview
    Dim Query As String
    Query = "SELECT a.MBTRANSUID, a.MBTRANSNO, a.MBTRANSDATE, a.MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME, a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID,(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = a.MBTRANSSERVICETYPEUID) AS MBTRANSSERVICETYPENAME, a.MBTRANSRSVTRANSUID, a.MBTRANSSUBVAL, a.MBTRANSDISCPERC, a.MBTRANSDISCVAL, a.MBTRANSTAXVAL1, a.MBTRANSTAXVAL2, a.MBTRANSDPVAL, a.MBTRANSTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT, a.MODIFIEDUSER, b.TABLELISTNAME " & _
             "FROM MBTRANS a LEFT JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE MBTRANSUID = '" & TransactionUID & "'"
    OBJNew.Printer = printerName
    OBJNew.Name = "Form_Print_Preview"
    OBJNew.RPTTitle = "Make Order"
    If PrefInfo.printSize = "58" Then
      OBJNew.RPTDocument = New Make_Order_Split58
    Else
      OBJNew.RPTDocument = New Make_Order_Split
    End If
    OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
    OBJNew.VersiNota = Nota
    OBJNew.ShowDialog()
  End Sub

  Private Sub ShowMakeOrderPrintPreview(Optional ByVal Nota As Boolean = False, Optional ByVal printerName As String = "")
    Dim OBJNew As New Form_Print_Preview
    Dim Query As String

    Query = "SELECT a.MBTRANSUID, a.MBTRANSNO, a.MBTRANSDATE, a.MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME, a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID,(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = a.MBTRANSSERVICETYPEUID) AS MBTRANSSERVICETYPENAME, a.MBTRANSRSVTRANSUID, a.MBTRANSSUBVAL, a.MBTRANSDISCPERC, a.MBTRANSDISCVAL, a.MBTRANSTAXVAL1, a.MBTRANSTAXVAL2, a.MBTRANSDPVAL, a.MBTRANSTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT, a.MODIFIEDUSER, b.TABLELISTNAME " & _
             "FROM MBTRANS a LEFT JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE MBTRANSUID = '" & TransactionUID & "'"
    OBJNew.Printer = printerName
    OBJNew.Name = "Form_Print_Preview"
    OBJNew.RPTTitle = "Make Order"
    If PrefInfo.printSize = "58" Then
      OBJNew.RPTDocument = New Make_Order58
    Else
      OBJNew.RPTDocument = New Make_Order
    End If
    OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
    OBJNew.VersiNota = Nota
    OBJNew.ShowDialog()
  End Sub

  Private Sub VirtualKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKey.Click
    Me.Cursor = Cursors.WaitCursor
    Dim VirtuKey As New VirtualKey
    VirtuKey.OBJBind(CustName, False)
    VirtuKey.ShowDialog()
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub BTNDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNDiscount.Click
    Me.Cursor = Cursors.WaitCursor
    Dim CustDialog As New Form_Make_Bill_Discount
    CustDialog.Name = "Form_Make_Bill_Discount"
    CustDialog.ParentOBJForm = Me
    CustDialog.Invoice = True
    CustDialog.TransactionUID = TransactionUID
    CustDialog.originalDiscVal = DiscountTxt.Value
    CustDialog.ShowDialog()
    Me.Cursor = Cursors.Default

    DiscountTxt.Value = FormatNumber(FinalDisc, 0)
    Call NewPriceAfterDiscount(SubTotalTxt.Text - FinalDisc)
    Call ShowPoleDisplay(IIf(FinalDisc > 0, "Disc  : " & DiscountTxt.Text.ToString & vbNewLine, "") & "Total : " & lblSetelahRounding.Text)
    Exit Sub


    If IsNothing(TMPDiscListCollection) Then
      DiscountTxt.Value = 0
    Else
      If TMPDiscListCollection.Count > 0 Then
        DiscountTxt.Value = FinalDisc
      Else
        DiscountTxt.Value = 0
      End If
    End If

    Call NewPriceAfterDiscount(SubTotalTxt.Text - FinalDisc)
    'Call fillRounding()
    Call ShowPoleDisplay("Total : " & lblSetelahRounding.Text)
  End Sub

  Public Sub NewPriceAfterDiscount(ByVal NewPrice)
    Call ReinitializePrice()
  End Sub

  Private Sub Tax1Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tax1Check.CheckedChanged
    If Tax1Check.Checked = True Then
      Tax1Txt.Value = PrefInfo.Tax1Rate
    Else
      Tax1Txt.Value = 0
    End If
    Call ReinitializePrice()
    Form_Custm_Display_MakeBill.LblDiscountVal.Text = DiscountTxt.Text
    Form_Custm_Display_MakeBill.LabelSCVal.Text = Tax1ValTxt.Text
    Form_Custm_Display_MakeBill.LabelPBVal.Text = Tax2ValTxt.Text
    Form_Custm_Display_MakeBill.LabelDPVal.Text = DPtxt.Text
    Form_Custm_Display_MakeBill.LabelRoundVal.Text = lblRounding.Text
    Form_Custm_Display_MakeBill.LabelTAVal.Text = lblSetelahRounding.Text
  End Sub

  Private Sub Tax2Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tax2Check.CheckedChanged
    If Tax2Check.Checked = True Then
      Tax2Txt.Value = PrefInfo.Tax2Rate
    Else
      Tax2Txt.Value = 0
    End If
    Call ReinitializePrice()
    Form_Custm_Display_MakeBill.LblDiscountVal.Text = DiscountTxt.Text
    Form_Custm_Display_MakeBill.LabelSCVal.Text = Tax1ValTxt.Text
    Form_Custm_Display_MakeBill.LabelPBVal.Text = Tax2ValTxt.Text
    Form_Custm_Display_MakeBill.LabelDPVal.Text = DPtxt.Text
    Form_Custm_Display_MakeBill.LabelRoundVal.Text = lblRounding.Text
    Form_Custm_Display_MakeBill.LabelTAVal.Text = lblSetelahRounding.Text
  End Sub

  Private Sub Tax1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Tax1.MouseDown
    If PrefInfo.Tax1Active = False Then Exit Sub
    If x = 0 Then
      x = 1
      Tax1.Image = My.Resources.OK
      Tax1Txt.Value = PrefInfo.Tax1Rate
      Tax1Check.Checked = True
    Else
      x = 0
      Tax1.Image = My.Resources._NOTHING
      Tax1Txt.Value = 0
      Tax1Check.Checked = False
    End If

  End Sub

  Private Sub Tax2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Tax2.MouseDown
    If PrefInfo.Tax2Active = False Then Exit Sub
    If y = 0 Then
      y = 1
      Tax2.Image = My.Resources.OK
      Tax2Txt.Value = PrefInfo.Tax2Rate
      Tax2Check.Checked = True
    Else
      y = 0
      Tax2.Image = My.Resources._NOTHING
      Tax2Txt.Value = 0
      Tax2Check.Checked = False
    End If
  End Sub

  Private Sub Tax_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Tax.MouseDown
    'Dim Query As String = Nothing

    'Dim TMPRecord As FbDataReader
    'TMPRecord = MyDatabase.MyReader("SELECT * FROM POSPREF")
    'While TMPRecord.Read
    '    Try
    '        FileDatabase2 = TMPRecord.Item("POSPREFDATABASEPATH2")
    '    Catch ex As Exception
    '        ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
    '    End Try
    'End While

    'If t = 0 Then
    '    If CheckConnectionDB2(FileDatabase2) Then
    '        t = 1
    '        Tax.Image = My.Resources.OK
    '    Else
    '        ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
    '        t = 0
    '        Tax.Image = My.Resources._NOTHING
    '    End If
    'Else
    '    t = 0
    '    Tax.Image = My.Resources._NOTHING
    'End If
  End Sub

  Private Sub Form_Make_Bill_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
    'If e.Control = True And e.Shift = True And e.KeyCode = Keys.Z Then
    '    Dim Query As String = Nothing

    '    Dim TMPRecord As FbDataReader
    '    TMPRecord = MyDatabase.MyReader("SELECT * FROM POSPREF")
    '    While TMPRecord.Read
    '        Try
    '            FileDatabase2 = TMPRecord.Item("POSPREFDATABASEPATH2")
    '        Catch ex As Exception
    '            ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
    '        End Try
    '    End While

    '    If t = 0 Then
    '        If CheckConnectionDB2(FileDatabase2) Then
    '            t = 1
    '            Tax.Image = My.Resources.OK
    '        Else
    '            ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
    '            t = 0
    '            Tax.Image = My.Resources._NOTHING
    '        End If
    '    Else
    '        t = 0
    '        Tax.Image = My.Resources._NOTHING
    '    End If
    'End If
  End Sub

#End Region

  Private Sub Form_Invoice_Make_Bill_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
    isDelivery = False
  End Sub

  Private Sub Tax1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tax1.Click
    Form_Custm_Display_MakeBill.LblDiscountVal.Text = DiscountTxt.Text
    Form_Custm_Display_MakeBill.LabelSCVal.Text = Tax1ValTxt.Text
    Form_Custm_Display_MakeBill.LabelPBVal.Text = Tax2ValTxt.Text
    Form_Custm_Display_MakeBill.LabelDPVal.Text = DPtxt.Text
    Form_Custm_Display_MakeBill.LabelRoundVal.Text = lblRounding.Text
  End Sub

  Private Sub Tax2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tax2.Click
    Form_Custm_Display_MakeBill.LblDiscountVal.Text = DiscountTxt.Text
    Form_Custm_Display_MakeBill.LabelSCVal.Text = Tax1ValTxt.Text
    Form_Custm_Display_MakeBill.LabelPBVal.Text = Tax2ValTxt.Text
    Form_Custm_Display_MakeBill.LabelDPVal.Text = DPtxt.Text
    Form_Custm_Display_MakeBill.LabelRoundVal.Text = lblRounding.Text
  End Sub

  Private Sub cmdCalcRounding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalcRounding.Click
    Me.Cursor = Cursors.WaitCursor
    Dim VirtuCalculator As New Form_Virtual_Calculator
    VirtuCalculator.OBJBind(txtRoundingInvisible)
    VirtuCalculator.showMoney = False
    VirtuCalculator.ShowDialog()
    If CDec(txtRoundingInvisible.Text) < CDec(TotalTxt.Text) Then
      ShowMessage(Me, "Maaf, nilai setelah rounding tidak boleh lebih kecil dari total !", True)
      txtRoundingInvisible.Text = lblSetelahRounding.Text
      Me.Cursor = Cursors.Default
      Exit Sub
    End If
    lblSetelahRounding.Value = FormatNumber(txtRoundingInvisible.Text, 0)
    Dim getRounding As Decimal = 0
    getRounding = lblSetelahRounding.Text - TotalTxt.Text
    lblRounding.Value = FormatNumber(getRounding, 0)
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub cmdBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBarcode.Click
    Me.Cursor = Cursors.WaitCursor
    Dim formBarcode As New Form_Scaner_Barcode
    formBarcode.Name = "Barcode"
    formBarcode.mbTransUID = TransactionUID
    formBarcode.dateTrans = dtOldDate.Value
    formBarcode.ShowDialog()
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub Form_Invoice_Make_Bill_Shown(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Shown
    'DiscountFromMakeBillFCDP = DiscountTxt.Text
    'FoundMakeBillForm = "True"
    'MessageBox.Show(DiscountFromMakeBillFCDP)
  End Sub
End Class