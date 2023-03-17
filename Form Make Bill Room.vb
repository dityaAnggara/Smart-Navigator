Imports System
Imports C1.Win
Imports FirebirdSql.Data.FirebirdClient
Imports DataDynamics.ActiveReports

Public Class Form_Make_Bill_Room

#Region "Variable Reference"
    Dim SaveStatus As Boolean = False
    Dim TransactionUID As String = GetTransactionCode(SelectedTable.TableUID)
    Dim CustInfo As New ArrayList
    Dim CustOrderInfo As New ArrayList
    'Dim CustOrderDetail As New Collection
    Public TMPDiscListCollection As New Collection
    Public FinalDisc As Double
    Dim FinalTime As DateTime
    Public TotalPrice As Double = 0

    Dim discUid As String = Nothing
    Dim TransactionNo As String
    Dim Visitor As String
    Dim ServiceUID As String
    Dim ReservationUID As String

    Dim x As Integer = 1
    Dim y As Integer = 1
    Dim t As Integer = 0
    Dim FileDatabase2 As String = Nothing

    Dim UserPermition As New UserPermitionLib
    Dim ListCollection As New Collection
    Dim FormStatus As FormStatusLib
#End Region

#Region "Initialize & Object Function"

    Private Sub BasicInitialize()
        ListCollection = DBListCollection("SELECT * FROM MBTRANSDT LEFT OUTER JOIN TABLELIST ON MBTRANSDT.MBTRANSUID = TABLELIST.TABLEMBTRANSUID WHERE MBTRANSDTITEMSTAT > -1 AND TABLELISTUID= '" & SelectedTable.TableUID & "'")
        FormStatus = OBJControlInitialize(ListCollection)
        Call OBJControlHandler(Me, FormStatus)
        Call CheckPermission(UserInformation.UserTypeUID, IIf(ListCollection.Count > 0, True, False))

        BillNo.Text = AutoIDNumber("2205", "PBTRANS", "PBTRANSNO")

        Tax1Check.Checked = PrefInfo.RentTax1Active
        Tax1Label.Text = PrefInfo.RentTax1Name
        If Tax1Check.Checked Then
            Tax1Txt.Value = PrefInfo.RentTax1Rate
            x = 1
            Tax1.Image = My.Resources.OK
        Else
            Tax1Txt.Value = 0
            x = 0
            Tax1.Image = My.Resources._NOTHING
        End If

        Tax2Check.Checked = PrefInfo.RentTax2Active
        Tax2Label.Text = PrefInfo.RentTax2Name
        If Tax2Check.Checked Then
            Tax2Txt.Value = PrefInfo.RentTax2Rate
            y = 1
            Tax2.Image = My.Resources.OK
        Else
            Tax2Txt.Value = 0
            y = 0
            Tax2.Image = My.Resources._NOTHING
        End If
        VirtualCalculator.Enabled = True : VirtualCalculator.VisualStyle = C1Input.VisualStyle.Office2007Blue
        Call CustomerInitialize()
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

                ShowMessage(Me, "Maaf, anda tidak mempunyai akses terhadap form ini !" & vbNewLine & "Silakan hubungi administrator anda !")
                Me.Close()
            End If

            If Not .CreateAccess Then
                BTNSave.Enabled = False
                BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver
            End If

            If Not .EditAccess Then
                BTNSave.Enabled = False
                BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver
            End If

            If .CreateAccess Then
                If ListCollection.Count > 0 Then
                    BTNSave.Enabled = True
                    BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Blue
                Else
                    BTNSave.Enabled = True
                    BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Blue
                End If
            ElseIf .EditAccess Then
                If ListCollection.Count > 0 Then
                    BTNSave.Enabled = True
                    BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Blue
                Else
                    BTNSave.Enabled = False
                    BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver
                End If
            Else
                FormStatus = FormStatusLib.OpenAndLock
                Call OBJControlHandler(Me, FormStatus)
            End If
        End With

    End Sub

    Private Sub LoadInformation()
        Dim isMultiple As Boolean = False
        If IsNothing(TransactionUID) Then
            CustOrderInfo = Nothing
            CustInfo = Nothing
            'CustOrderDetail = Nothing
            Call fillGrid()
        Else
            CustOrderInfo = GetCustOrderInfo(TransactionUID)
            CustInfo = GetCustInfo(CustOrderInfo(17))
            'CustOrderDetail = DBListCollection("SELECT * FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "'")

            'By Rudy
            Dim TMPDetail As DataSet
            Dim TMPHeader As DataSet
            Dim DPValue As Double = 0
            Dim TotalGlobal As Double = 0

            'By Rudy
            TMPHeader = MyDatabase.MyAdapter("SELECT * FROM MBTrans WHERE MBTransUID = '" & TransactionUID & "'")
            FinalTime = TMPHeader.Tables(0).Rows(0).Item("MODIFIEDDATETIME")
            If IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")) = False Then
                ReservationUID = TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")
            End If
            Dim TotalItem As Double = 0, TotalDisc As Double = 0
            If Not IsDBNull(TMPHeader.Tables(0).Rows(0).Item("ISROOMBILLED")) Then

                'Dim TMPCheck As FbDataReader
                Dim Count As Integer = 0
                Dim CountDump As Integer = 0
                Dim IsBilled As Integer = 0

                If Not IsDBNull(TMPHeader.Tables(0).Rows(0).Item("ISROOMBILLED")) Then
                    IsBilled = TMPHeader.Tables(0).Rows(0).Item("ISROOMBILLED")
                End If

                If Not IsDBNull(TMPHeader.Tables(0).Rows(0).Item("ISFISCAL")) Then
                    t = TMPHeader.Tables(0).Rows(0).Item("ISFISCAL")
                End If

                'If GetServiceInfo(TMPHeader.Tables(0).Rows(0).Item("MBTRANSSERVICETYPEUID")) = "1" Then
                ' susilo 27 Sep 2012, tidak dipakai karena tidak ada hubungan dengan make order
                'TMPCheck = MyDatabase.MyReader("SELECT MBTRANSDTITEMSTAT FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "'")
                'While TMPCheck.Read
                '    Count = Count + 1

                '    If TMPCheck.Item("MBTRANSDTITEMSTAT") = "-1" Then
                '        Count = Count - 1
                '    End If

                '    If TMPCheck.Item("MBTRANSDTITEMSTAT") = "1" Then
                '        CountDump = CountDump + 1
                '    End If
                'End While

                'If Count <> CountDump Then
                '    ShowMessage(Me, "Maaf, anda tidak dapat membuat tagihan, karena ada order pesanan yang belum diproses !")
                '    Me.Close()
                'End If
                'End If

                If IsBilled = 1 Then

                    Dim paymentExist As Boolean = False
                    Dim TMPRecordPayment As FbDataReader
                    TMPRecordPayment = MyDatabase.MyReader("SELECT PBTRANSSTAT FROM PBTRANS WHERE PBTRANSMBTRANSUID = '" & TransactionUID & "'")

                    While TMPRecordPayment.Read()
                        If TMPRecordPayment("PBTRANSSTAT") = 1 Then
                            paymentExist = True
                            If PrefInfo.AllowModifyBillAfterPayment = False Then

                                Dim OBJNew As New Form_Message_Box_Question
                                OBJNew.Name = "Form_Message_Box_Question"
                                OBJNew.QuestionLabel.Text = "Maaf, anda tidak dapat merubah tagihan, karena tagihan ini sudah dibayarkan !"
                                OBJNew.CenterScreen = True
                                OBJNew.BTNYes.Text = "OK"
                                OBJNew.BTNNo.Visible = False
                                OBJNew.ParentOBJForm = ParentForm
                                OBJNew.ShowDialog()

                                'Call MainPage.TableClickInfo(selectedObject, myEvent)
                                GoTo View
                                Exit Sub

                            End If
                        End If
                    End While

                    If paymentExist = False Then
                        If ShowQuestion(Me, "Tagihan untuk customer ini sudah dibuat, apakah anda ingin merubah tagihan ?") = False Then
                            GoTo View
                            Exit Sub
                        End If
                    Else
                        If ShowQuestion(Me, "Tagihan untuk customer ini sudah dibuat, dan sudah ada pembayaran. Apabila anda merubah tagihan, maka data pembayaran akan dihapus, apakah anda ingin merubah tagihan ?") = False Then
                            GoTo view
                            Exit Sub
                        End If
                    End If

                    Dim TMPRecord As FbDataReader, timeReader As FbDataReader
                    TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2205'")
                    While TMPRecord.Read()
                        UserPermition.PermitionInitialize(TMPRecord.Item("USERCATCREATEACCESS"), TMPRecord.Item("USERCATEDITACCESS"), TMPRecord.Item("USERCATDELETEACCESS"), TMPRecord.Item("USERCATREADACCESS"), TMPRecord.Item("USERCATPRINTACCESS"), TMPRecord.Item("USERCATCHANGEDATEACCESS"), TMPRecord.Item("USERCATCHANGETIMEACCESS"), TMPRecord.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
                    End While

                    With UserPermition
                        If Not .DeleteOrderAccess Then
                            Dim OBJNew As New Form_User_Authorize_Dialog
                            OBJNew.Name = "Form_User_Authorize_Dialog"
                            OBJNew.ParentOBJForm = Me
                            OBJNew.NeedAuthorizationForMakeBill = True
                            OBJNew.ShowDialog()

                            Dim TMPRecordAuthorize As FbDataReader
                            TMPRecordAuthorize = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2205'")
                            While TMPRecordAuthorize.Read()
                                UserPermition.PermitionInitialize(TMPRecordAuthorize.Item("USERCATCREATEACCESS"), TMPRecordAuthorize.Item("USERCATEDITACCESS"), TMPRecordAuthorize.Item("USERCATDELETEACCESS"), TMPRecordAuthorize.Item("USERCATREADACCESS"), TMPRecordAuthorize.Item("USERCATPRINTACCESS"), TMPRecordAuthorize.Item("USERCATCHANGEDATEACCESS"), TMPRecordAuthorize.Item("USERCATCHANGETIMEACCESS"), TMPRecordAuthorize.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
                            End While

                            With UserPermition
                                If .DeleteOrderAccess Then
                                    If Trim(ReservationUID) <> "" Then
                                        MyDatabase.MyAdapter("UPDATE RSVTRANS SET RSVTRANSUSEDPVAL=RSVTRANSUSEDPVAL-" & CDec(TMPHeader.Tables(0).Rows(0).Item("MBTRANSDPVAL")) & " WHERE RSVTRANSUID='" & ReservationUID & "'")
                                    End If
                                    MyDatabase.MyAdapter("UPDATE MBTRANS SET MBTRANSROOMSUBVAL=0,MBTRANSROOMDISCUID=NULL, MBTRANSROOMDISCPERC=0, MBTRANSROOMDISCVAL=0, MBTRANSROOMTAXVAL1=0, MBTRANSROOMTAXVAL2=0,MBTRANSTOTVAL=MBTRANSTOTVAL-MBTRANSROOMTOTVAL,MBTRANSROOMTOTVAL=0,ISROOMBILLED= 0,MBTRANSROUNDINGVAL=0,MBTRANSTIPSVAL=0 WHERE MBTRANSUID = '" & TransactionUID & "'")
                                    MyDatabase.MyAdapter("DELETE FROM MBTRANSROOMDT WHERE MBTRANSUID='" & TransactionUID & "'")
                                    If PrefInfo.AllowModifyBillAfterPayment = True Then
                                        Call MyDatabase.MyAdapter("DELETE FROM PBTRANSDT WHERE PBTRANSUID IN (SELECT PBTRANSUID FROM PBTRANS WHERE PBTRANSMBTRANSUID='" & TransactionUID & "')")
                                        Call MyDatabase.MyAdapter("DELETE FROM PBTRANS WHERE PBTRANSMBTRANSUID='" & TransactionUID & "'")
                                    End If

                                    'Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMDISCUID1=NULL, MBTRANSDTITEMDISCVAL1=0, MBTRANSDTITEMDISCUID2=NULL, MBTRANSDTITEMDISCVAL2=0 WHERE MBTRANSUID='" & TransactionUID & "'")

                                    'Anjo 29 Jan, finaltime perlu direquery ulang, karena trigger pak rudy mengupdate modifieddatetime
                                    timeReader = MyDatabase.MyReader("SELECT * FROM MBTRANS WHERE MBTRANSUID = '" & TransactionUID & "'")
                                    While timeReader.Read
                                        FinalTime = timeReader.Item("MODIFIEDDATETIME")
                                    End While

                                    'Call MainPage.TableClickInfo(selectedObject, myEvent)
                                    GoTo Edit
                                    Exit Sub
                                Else
                                    'Call MainPage.TableClickInfo(selectedObject, myEvent)
                                    GoTo View
                                    Exit Sub
                                End If
                            End With
                        End If

                        If .DeleteOrderAccess Then
                            If Trim(ReservationUID) <> "" Then
                                MyDatabase.MyAdapter("UPDATE RSVTRANS SET RSVTRANSUSEDPVAL=RSVTRANSUSEDPVAL-" & CDec(TMPHeader.Tables(0).Rows(0).Item("MBTRANSDPVAL")) & " WHERE RSVTRANSUID='" & ReservationUID & "'")
                            End If
                            MyDatabase.MyAdapter("UPDATE MBTRANS SET MBTRANSROOMSUBVAL=0,MBTRANSROOMDISCUID=NULL, MBTRANSROOMDISCPERC=0, MBTRANSROOMDISCVAL=0, MBTRANSROOMTAXVAL1=0, MBTRANSROOMTAXVAL2=0,MBTRANSTOTVAL=MBTRANSTOTVAL-MBTRANSROOMTOTVAL,MBTRANSROOMTOTVAL=0,ISROOMBILLED= 0,MBTRANSROUNDINGVAL=0,MBTRANSTIPSVAL=0 WHERE MBTRANSUID = '" & TransactionUID & "'")
                            MyDatabase.MyAdapter("DELETE FROM MBTRANSROOMDT WHERE MBTRANSUID='" & TransactionUID & "'")
                            If PrefInfo.AllowModifyBillAfterPayment = True Then
                                Call MyDatabase.MyAdapter("DELETE FROM PBTRANSDT WHERE PBTRANSUID IN (SELECT PBTRANSUID FROM PBTRANS WHERE PBTRANSMBTRANSUID='" & TransactionUID & "')")
                                Call MyDatabase.MyAdapter("DELETE FROM PBTRANS WHERE PBTRANSMBTRANSUID='" & TransactionUID & "'")
                            End If

                            'Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMDISCUID1=NULL, MBTRANSDTITEMDISCVAL1=0, MBTRANSDTITEMDISCUID2=NULL, MBTRANSDTITEMDISCVAL2=0 WHERE MBTRANSUID='" & TransactionUID & "'")

                            'Anjo 29 Jan, finaltime perlu direquery ulang, karena trigger pak rudy mengupdate modifieddatetime
                            timeReader = MyDatabase.MyReader("SELECT * FROM MBTRANS WHERE MBTRANSUID = '" & TransactionUID & "'")
                            While timeReader.Read
                                FinalTime = timeReader.Item("MODIFIEDDATETIME")
                            End While

                            'Call MainPage.TableClickInfo(selectedObject, myEvent)
                            GoTo Edit
                            Exit Sub
                        Else
                            'Call MainPage.TableClickInfo(selectedObject, myEvent)
                            GoTo View
                            Exit Sub
                        End If
                    End With
View:
                    Tax1Check.Enabled = False
                    Tax2Check.Enabled = False
                    Tax1.Enabled = False
                    Tax2.Enabled = False
                    CustomerList.Enabled = False
                    CustName.Enabled = False
                    FindCust.Enabled = False : FindCust.VisualStyle = C1Input.VisualStyle.Office2007Silver
                    VirtualKey.Enabled = False : VirtualKey.VisualStyle = C1Input.VisualStyle.Office2007Silver
                    BTNDiscount.Enabled = False : BTNDiscount.VisualStyle = C1Input.VisualStyle.Office2007Silver
                    'Anjo - 10 Nov 2011. Kalo sudah bayar tidak bisa di save, karena kalo bisa save, status berubah menjadi sudah bill
                    BTNSave.Enabled = False : BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver
                    VirtualCalculator.Enabled = False : VirtualCalculator.VisualStyle = C1Input.VisualStyle.Office2007Silver
                    cmdCalcRounding.Enabled = False : cmdCalcRounding.VisualStyle = C1Input.VisualStyle.Office2007Silver
                    Try
                        If t = 1 Then
                            Tax.Visible = True
                        End If
                    Catch ex As Exception
                        t = 0
                    End Try

                    TransactionNo = TMPHeader.Tables(0).Rows(0).Item("MBTRANSNO")
                    BillNo.Text = TransactionNo
                    Visitor = TMPHeader.Tables(0).Rows(0).Item("MBTRANSPAXVAL")
                    ServiceUID = TMPHeader.Tables(0).Rows(0).Item("MBTRANSSERVICETYPEUID")
                    If Not IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")) Then
                        ReservationUID = TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")
                    End If

                    CustomerList.SelectedIndex = CustomerList.FindString(TMPHeader.Tables(0).Rows(0).Item("MBTRANSCUSTUID"), 0, 1)
                    CustName.Text = TMPHeader.Tables(0).Rows(0).Item("MBTRANSCUSTNAME")

                    Tax1ValTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSROOMTAXVAL1"), 0)
                    Tax2ValTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSROOMTAXVAL2"), 0)
                    txtOverPax.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSOVERPAXVALUE"), 0)
                    SubTotalTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSROOMSUBVAL"), 0)
                    'DPtxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSDPVAL"), 0)

                    'Dim tmpSisaDP As String = "0"
                    'If IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")) = False Then
                    '    tmpSisaDP = getDPSisa(TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID"))
                    'End If
                    'If tmpSisaDP = "0" Then
                    '    DPtxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSDPVAL"), 0)
                    'Else
                    '    If CDec(tmpSisaDP) >= CDec(TMPHeader.Tables(0).Rows(0).Item("MBTRANSTOTVAL")) Then
                    '        DPtxt.Value = FormatNumber(CDec(TMPHeader.Tables(0).Rows(0).Item("MBTRANSTOTVAL")), 0)
                    '    ElseIf CDec(tmpSisaDP) < CDec(TMPHeader.Tables(0).Rows(0).Item("MBTRANSTOTVAL")) Then
                    '        DPtxt.Value = FormatNumber(tmpSisaDP, 0)
                    '    Else
                    '        DPtxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSDPVAL"), 0)
                    '    End If
                    'End If


                    If IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")) = False Then
                        isMultiple = isMultipleDP(TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID"))
                    End If

                    If isMultiple = True Then
                        DPtxt.Width = 208
                        VirtualCalculator.Visible = True
                    Else
                        DPtxt.Width = 264
                        VirtualCalculator.Visible = False
                    End If

                    DPtxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSDPVAL"), 0)
                    DiscountTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSROOMDISCVAL"), 0)

                    If IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSFNBTOTVAL")) = False Then
                        TotalItemTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSFNBTOTVAL"), 0)
                    Else
                        TotalItemTxt.Value = "0"
                    End If
                    TotalTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSROOMTOTVAL"), 0)

                    Dim TItem As Double = 0

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
                    lblGrangTotal.Value = FormatNumber(CDbl(TMPHeader.Tables(0).Rows(0).Item("MBTRANSTOTVAL")) - IIf(IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSROUNDINGVAL")) = False, CDbl(TMPHeader.Tables(0).Rows(0).Item("MBTRANSROUNDINGVAL")), 0), 0)
                    'TotalTxt.Value = FormatNumber(CDbl(TMPHeader.Tables(0).Rows(0).Item("MBTRANSTOTVAL")) - IIf(IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSROUNDINGVAL")) = False, CDbl(TMPHeader.Tables(0).Rows(0).Item("MBTRANSROUNDINGVAL")), 0), 0)
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

                    Call fillGridToView(TransactionUID)
                    VirtualCalculator.Enabled = False : VirtualCalculator.VisualStyle = C1Input.VisualStyle.Office2007Silver
                    Exit Sub
                End If
            End If
Edit:
            If t = 1 Then
                Tax.Visible = True
            End If
            TransactionNo = TMPHeader.Tables(0).Rows(0).Item("MBTRANSNO")
            BillNo.Text = TransactionNo

            Visitor = TMPHeader.Tables(0).Rows(0).Item("MBTRANSPAXVAL")
            ServiceUID = TMPHeader.Tables(0).Rows(0).Item("MBTRANSSERVICETYPEUID")
            If Not IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")) Then
                ReservationUID = TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")
                isMultiple = isMultipleDP(TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID"))
            End If

            Tax1ValTxt.Value = FormatNumber((((SubTotalTxt.Value - DiscountTxt.Value) * Tax1Txt.Value) / 100), 0)
            Tax2ValTxt.Value = FormatNumber((((SubTotalTxt.Value - DiscountTxt.Value + Tax1ValTxt.Value) * Tax2Txt.Value) / 100), 0)
            If isMultiple = True Then
                DPtxt.Width = 208
                VirtualCalculator.Visible = True
                DPValue = CDec(getDPSisa(ReservationUID))
            Else
                DPtxt.Width = 264
                'DPtxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSDPVAL"), 0)
                VirtualCalculator.Visible = False
                DPValue = TMPHeader.Tables(0).Rows(0).Item("MBTransDPVal")
            End If
            txtDPInvisible.Text = DPValue.ToString
            DPtxt.Value = FormatNumber(DPValue, 0)
            'TotalItemTxt.Value = TotalItem
            'By Rudy
            'TotalGlobal = SubTotalTxt.Value - DiscountTxt.Value + Tax1ValTxt.Value + Tax2ValTxt.Value - DPtxt.Value
            'TotalTxt.Value = FormatNumber(TotalGlobal, 0)
            If IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSFNBTOTVAL")) = False Then
                TotalItemTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSFNBTOTVAL"), 0)
            Else
                TotalItemTxt.Value = "0"
            End If
            'lblGrangTotal.Value = CDec(TMPHeader.Tables(0).Rows(0).Item("MBTRANSFNBTOTVAL"))

            CustomerList.SelectedIndex = CustomerList.FindString(CustInfo(0), 0, 1)
            CustName.Text = CustOrderInfo(18)

            TMPDetail = Nothing

            Tax1Check.Enabled = True
            Tax2Check.Enabled = True
            BTNDiscount.Enabled = True
            Call fillGrid()
            VirtualCalculator.Enabled = True : VirtualCalculator.VisualStyle = C1Input.VisualStyle.Office2007Blue
            Call fillRounding()
            Exit Sub
        End If
    End Sub

    Private Sub fillRounding()
        Dim TotalGlobal As Double = CDbl(lblGrangTotal.Text)
        If PrefInfo.UseRounding = True Then
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
                    txtRoundingInvisible.Text = lblSetelahRounding.Text
                Else
                    lblRounding.Value = "0"
                    lblSetelahRounding.Value = FormatNumber(TotalGlobal, 0)
                    txtRoundingInvisible.Text = TotalGlobal.ToString
                End If
            Else
                lblRounding.Value = "0"
                lblSetelahRounding.Value = FormatNumber(TotalGlobal, 0)
                txtRoundingInvisible.Text = TotalGlobal.ToString
            End If
        Else
            lblRounding.Value = "0"
            lblSetelahRounding.Value = FormatNumber(TotalGlobal, 0)
            txtRoundingInvisible.Text = TotalGlobal.ToString
        End If
    End Sub

    Private Function isMultipleDP(ByVal idReservation As String) As Boolean
        Dim rs As FbDataReader
        rs = MyDatabase.MyReader("SELECT RSVTRANSUSEDPMULTIPLE FROM RSVTRANS WHERE RSVTRANSUID='" & idReservation & "'")
        rs.Read()
        If rs("RSVTRANSUSEDPMULTIPLE").ToString = "1" Then
            isMultipleDP = True
        Else
            isMultipleDP = False
        End If
        rs = Nothing
    End Function

    Private Function getDPSisa(ByVal idReservation As String) As String
        Dim rs As FbDataReader
        Dim tmpDP As Decimal = 0
        'rs = MyDatabase.MyReader("SELECT MBTRANSDPVAL FROM MBTRANS WHERE MBTRANSNO='" & BillNo.Text & "'")
        'If rs.Read() = True Then
        '    tmpDP = CDec(rs(0))
        'Else
        '    tmpDP = 0
        'End If
        'rs = Nothing
        rs = MyDatabase.MyReader("SELECT RSVTRANSDPVAL-IIF(RSVTRANSUSEDPVAL IS NULL,0,RSVTRANSUSEDPVAL) FROM RSVTRANS a WHERE a.RSVTRANSUID='" & idReservation & "'")
        If rs.Read() = True Then
            Return (CDec(rs(0)) + tmpDP).ToString
        Else
            Return tmpDP.ToString
        End If
        rs.Close()
        rs = Nothing
    End Function

    Private Sub fillGridToView(ByVal idMBTRANS As String)
        Dim rs As FbDataReader        
        rs = MyDatabase.MyReader("SELECT * FROM MBTRANSROOMDT WHERE MBTRANSUID='" & idMBTRANS & "'")
        With grdPrice
            .Redraw = False
            .Rows.DefaultSize = 25
            .Rows.Count = 1
            While rs.Read()
                .AddItem("")
                .Cols("jam").Item(.Rows.Count - 1) = rs("MBTRANSROOMDTTIMEDESC")
                .Cols("harga").Item(.Rows.Count - 1) = FormatNumber(rs("MBTRANSROOMDTRATE"), 0)
                If CInt(rs("MBTRANSROOMDTRENTLENGTH")) = 60 Then
                    .Cols("jmljam").Item(.Rows.Count - 1) = "1 JAM"
                Else
                    .Cols("jmljam").Item(.Rows.Count - 1) = FormatNumber(rs("MBTRANSROOMDTRENTLENGTH"), 0) & " MENIT"
                End If
                .Cols("total").Item(.Rows.Count - 1) = FormatNumber(rs("MBTRANSROOMDTSUBVAL"), 0)
                .Cols("discount").Item(.Rows.Count - 1) = rs("MBTRANSROOMDTDISCVAL")
            End While
            .Redraw = True
        End With
        rs = Nothing
    End Sub

    Private Function GetServiceInfo(ByVal ServiceTypeUID As String) As String
        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM SERVICETYPE WHERE SERVICETYPEUID ='" & ServiceTypeUID & "'")
        TMPRecord.Read()

        If IsDBNull(TMPRecord.Item("SERVICETYPEISBILLEDAFTERDUMPED")) Then
            Return Nothing
        Else
            Return TMPRecord.Item("SERVICETYPEISBILLEDAFTERDUMPED")
        End If

    End Function

    Private Function GetCustInfo(ByVal CustUID As String) As ArrayList

        Dim TMPRecord As FbDataReader
        Dim TMPArray As New ArrayList
        TMPRecord = MyDatabase.MyReader("SELECT a.CUSTUID, a.CUSTNO, a.CUSTNAME, a.CUSTCATUID , (SELECT CUSTCATNAME FROM CUSTCAT WHERE CUSTCATUID = a.CUSTCATUID) FROM CUST a WHERE CUSTUID ='" & CustUID & "'")
        TMPRecord.Read()

        If IsDBNull(TMPRecord.Item("CUSTCATNAME")) Then
            Return Nothing
        Else
            For i As Integer = 0 To TMPRecord.FieldCount - 1
                TMPArray.Add(TMPRecord.Item(i))
            Next

            Return TMPArray
        End If

    End Function

    Private Function GetCustOrderInfo(ByVal TransUID As String) As ArrayList

        Dim TMPRecord As FbDataReader
        Dim TMPArray As New ArrayList
        TMPRecord = MyDatabase.MyReader("SELECT * FROM MBTRANS WHERE MBTRANSUID = '" & TransactionUID & "'")
        TMPRecord.Read()

        If IsDBNull(TMPRecord.Item("MBTRANSNO")) Then
            Return Nothing
        Else
            For i As Integer = 0 To TMPRecord.FieldCount - 1
                TMPArray.Add(TMPRecord.Item(i))
            Next

            Return TMPArray
        End If

    End Function

    Private Sub CustomerInitialize()
        Dim TMPRecord As FbDataReader
        Try

            TMPRecord = MyDatabase.MyReader("SELECT CUSTUID, CUSTNAME, CUSTADDR1, CUSTCATUID, (SELECT CUSTCATDISCUID FROM CUSTCAT WHERE CUSTCATUID = CUST.CUSTCATUID) AS CUSTCATDISCUID FROM CUST ORDER BY CUSTNAME")

            CustomerList.ClearItems()
            CustomerList.HoldFields()
            While TMPRecord.Read()
                CustomerList.AddItem(TMPRecord.Item("CUSTNAME") & ";" & TMPRecord.Item("CUSTUID") & ";" & IIf(IsDBNull(TMPRecord.Item("CUSTCATDISCUID")) = True, "", TMPRecord.Item("CUSTCATDISCUID")))
            End While

        Catch ex As Exception

        End Try
        TMPRecord = Nothing
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

        TotalGlobal = CDec(txtOverPax.Text) + SubTotalTxt.Text - DiscountTxt.Text + Tax1ValTxt.Text + Tax2ValTxt.Text - DPtxt.Text
        TotalTxt.Value = FormatNumber(TotalGlobal, 0)
        lblGrangTotal.Value = FormatNumber(CDec(TotalTxt.Text) + CDec(TotalItemTxt.Text), 0)
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
            '"(SELECT DISCNAME FROM DISC WHERE DISCUID = (SELECT CUSTCATDISCUID FROM CUSTCAT WHERE CUSTCATUID = a.CUSTCATUID)) AS DISCNAME, " & _
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

    Private Function GetTransactionCode(ByVal TableUID As String)

        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT TABLEMBTRANSUID FROM TABLELIST WHERE TABLELISTUID = '" & TableUID & "'")
        TMPRecord.Read()

        If IsDBNull(TMPRecord.Item("TABLEMBTRANSUID")) Then
            Return Nothing
        Else
            Return TMPRecord.Item("TABLEMBTRANSUID")
        End If

    End Function

    Public Sub BringCustInfo(ByVal CustUID As String)
        Dim CurCust As Integer = CustomerList.FindString(CustUID, 0, 1)
        CustomerList.SelectedIndex = CurCust
    End Sub

    Private Sub ShowPrintPreview(Optional ByVal Nota As Boolean = False)
        Dim OBJNew As New Form_Print_Preview
        Dim Query As String

        'Query = "SELECT a.MBTRANSUID, a.MBTRANSNO, a.MBTRANSDATE, a.MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME, a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID, a.MBTRANSRSVTRANSUID, a.MBTRANSSUBVAL, a.MBTRANSDISCPERC, a.MBTRANSDISCVAL, a.MBTRANSTAXVAL1, a.MBTRANSTAXVAL2, a.MBTRANSDPVAL, a.MBTRANSTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT,a.CREATEDUSER, a.MODIFIEDUSER,a.MODIFIEDDATETIME, b.TABLELISTNAME,(SELECT CUSTNO FROM CUST WHERE CUSTUID = a.MBTRANSCUSTUID) AS CUSTNO, (SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = a.MBTRANSSERVICETYPEUID ) AS SERVICENAME " & _
        '        "FROM MBTRANS a LEFT JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE MBTRANSUID = '" & TransactionUID & "'"

        Query = "SELECT a.MBTRANSUID, a.MBTRANSNO,a.MBTRANSSHIFTNO,a.MBTRANSOVERPAXVALUE,a.MBTRANSFNBTOTVAL,a.MBTRANSTOTVAL-IIF(a.MBTRANSROUNDINGVAL IS NULL,0,a.MBTRANSROUNDINGVAL) AS MBTRANSTOTVAL,a.MBTRANSROOMTAXVAL1, a.MBTRANSDATE,MBTRANSSTARTTIME, a.MBTRANSPAXVAL+a.MBTRANSPAXVAL3+a.MBTRANSPAXVAL5+a.MBTRANSPAXVAL2+a.MBTRANSPAXVAL4+a.MBTRANSPAXVAL6 AS MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME," & _
                "dateadd((a.MBTRANSSTARTRENTHOURS)+(a.MBTRANSADDITIONALRENTHOURS)+(a.MBTRANSFREEHOURS)+a.MBTRANSLENGTHFREEMINUTES+a.MBTRANSBONUSMINUTES  minute to (CAST(CAST(a.MBTRANSDATE AS DATE) || ' ' || a.MBTRANSSTARTTIME AS timestamp))) AS jamHabis," & _
                "a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID, a.MBTRANSRSVTRANSUID, a.MBTRANSROOMSUBVAL," & _
                "a.MBTRANSROOMDISCPERC, a.MBTRANSROOMDISCVAL, a.MBTRANSROOMTAXVAL1, a.MBTRANSROOMTAXVAL2, a.MBTRANSDPVAL," & _
                "a.MBTRANSROOMTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT,a.CREATEDUSER," & _
                "a.MODIFIEDUSER,a.MODIFIEDDATETIME, b.TABLELISTNAME," & _
                "(a.MBTRANSFREEHOURS)+a.MBTRANSLENGTHFREEMINUTES+a.MBTRANSBONUSMINUTES AS ttlMenit," & _
                "(SELECT CUSTNO FROM CUST WHERE CUSTUID = a.MBTRANSCUSTUID) AS CUSTNO " & _
                "FROM MBTRANS a LEFT OUTER JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE a.MBTRANSUID = '" & TransactionUID & "'"

        OBJNew.Name = "Form_Print_Preview"
        OBJNew.RPTTitle = "Bill"

        Dim myMakeBill As New Make_Bill_Room
        myMakeBill.BillTableTxt.Visible = True
        myMakeBill.BillTableTxt.Text = "Table : " & Replace(SelectedTable.TableName, vbNewLine, " ")
        If PrefInfo.UsePreSettledBill Then
            myMakeBill.ShowPreSettledBill = True
        Else
            myMakeBill.ShowPreSettledBill = False
        End If
        OBJNew.RPTDocument = myMakeBill
        OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
        OBJNew.VersiNota = Nota
        OBJNew.ShowDialog()
    End Sub

#End Region

#Region "Form Control Function"

    Private Sub fillGrid()
        Dim rs As FbDataReader
        Dim jamAkhirHitung As Date = Nothing
        Dim selisihMenit As Integer
        Dim isFoundRow As Boolean = False
        Dim tmpJamAwal As Date = Nothing, tmpJamSampai As Date = Nothing
        Dim tmpHarga As Decimal = 0
        Dim tmpHargaOP As Decimal = 0
        Dim tmpIsMin As Boolean = False
        Dim endHour As Date = Nothing, startHour As Date
        Dim tmpLama As String = ""
        Dim tmpJumlahJam As Integer = 0
        Dim tmpTotFNB As Decimal = 0
        Dim tmpCatRoomUID As String = ""
        Dim tmpJmlOrang As Decimal = 0
        Dim tmpTipeHarga As Integer = 1
        Dim tmpGetDayType As Date = Nothing
        grdGetPromo.Rows.Count = 1
        rs = MyDatabase.MyReader("SELECT A.*,B.TABLELISTCATUID,(SELECT CS.CUSTCATUID FROM CUST CS WHERE CS.CUSTUID=A.MBTRANSCUSTUID) AS CUSTUID FROM MBTRANS A INNER JOIN TABLELIST B ON A.MBTRANSTABLELISTUID=B.TABLELISTUID WHERE A.MBTRANSUID='" & TransactionUID & "'")
        With grdPrice
            .Redraw = False
            .Rows.Count = 1
            .Rows.DefaultSize = 25
            While rs.Read()
                'If DeptInfo.roomFreePassAfterRent = "0" Then
                '    jamAkhirHitung = DateAdd(DateInterval.Hour, CInt(rs("MBTRANSFREEHOURS")), rs("MBTRANSSTARTTIME"))
                '    tmpGetDayType = DateAdd(DateInterval.Hour, CInt(rs("MBTRANSFREEHOURS")), rs("MBTRANSDATE"))
                'Else
                jamAkhirHitung = rs("MBTRANSSTARTTIME")
                tmpGetDayType = rs("MBTRANSDATE")
                'End If

                tmpCatRoomUID = rs("TABLELISTCATUID")
                tmpJmlOrang = CInt(rs("MBTRANSPAXVAL")) + CInt(rs("MBTRANSPAXVAL2")) + CInt(rs("MBTRANSPAXVAL3")) + CInt(rs("MBTRANSPAXVAL4")) + CInt(rs("MBTRANSPAXVAL5")) + CInt(rs("MBTRANSPAXVAL6"))
                tmpTotFNB = IIf(IsDBNull(rs("MBTRANSFNBTOTVAL")) = True, 0, rs("MBTRANSFNBTOTVAL"))
                If PrefInfo.RentDayType.ToString = "1" Then
                    If CDate(rs("MBTRANSDATE")).Hour >= 0 And CDate(rs("MBTRANSDATE")).Hour <= 8 Then
                        tmpTipeHarga = CInt(CDate(rs("MBTRANSDATE")).DayOfWeek)
                        If tmpTipeHarga = 0 Then tmpTipeHarga = 7
                    Else
                        tmpTipeHarga = CInt(CDate(rs("MBTRANSDATE")).DayOfWeek + 1)
                    End If
                    'If CDate(tmpGetDayType).Hour >= 0 And CDate(tmpGetDayType).Hour <= 8 Then
                    '    tmpTipeHarga = CInt(CDate(tmpGetDayType).DayOfWeek)
                    '    If tmpTipeHarga = 0 Then tmpTipeHarga = 7
                    'Else
                    '    tmpTipeHarga = CInt(CDate(tmpGetDayType).DayOfWeek + 1)
                    'End If
                ElseIf PrefInfo.RentDayType.ToString = "2" Then
                    tmpTipeHarga = 8
                ElseIf PrefInfo.RentDayType.ToString = "3" Then
                    tmpTipeHarga = 9
                End If
                'Call fillGridHarga(rs("TABLELISTCATUID"), CDate(rs("MBTRANSDATE")).DayOfWeek + 1)
                'Call fillGridDiskon(CDate(rs("MBTRANSDATE")).DayOfWeek + 1, Format(rs("MBTRANSDATE"), "yyyy/MM/dd"))
                'Call fillGridPromo(rs("CUSTUID"), Format(rs("MBTRANSDATE"), "yyyy/MM/dd"), CDate(rs("MBTRANSDATE")).DayOfWeek + 1)
                'If DeptInfo.roomFreePassAfterRent = "0" Then
                '    startHour = DateAdd(DateInterval.Hour, CInt(rs("MBTRANSFREEHOURS")), rs("MBTRANSSTARTTIME"))
                'Else
                startHour = rs("MBTRANSSTARTTIME")
                'End If

                Call fillGridHarga(rs("TABLELISTCATUID"), tmpTipeHarga)
                Call fillGridDiskon(tmpTipeHarga - 1, Format(rs("MBTRANSDATE"), "yyyy/MM/dd"), rs("CUSTUID"))
                Call fillGridPromo(rs("CUSTUID"), Format(rs("MBTRANSDATE"), "yyyy/MM/dd"), tmpTipeHarga)

                'startHour = rs("MBTRANSDATE")
                'tmpJumlahJam = CInt(rs("MBTRANSSTARTRENTHOURS")) + CInt(rs("MBTRANSADDITIONALRENTHOURS"))
                tmpJumlahJam = CInt(rs("MBTRANSSTARTRENTHOURS")) + CInt(rs("MBTRANSADDITIONALRENTHOURS"))
                'Dim lamaMenit As Integer = (CInt(rs("MBTRANSSTARTRENTHOURS")) * 60) + _
                '            (CInt(rs("MBTRANSADDITIONALRENTHOURS")) * 60) + _
                '            (CInt(rs("MBTRANSFREEHOURS")) * 60) + _
                '            CInt(rs("MBTRANSLENGTHFREEMINUTES"))
                'If IsDBNull(rs("MBTRANSBONUSMINUTES")) = False Then lamaMenit += CInt(rs("MBTRANSBONUSMINUTES"))
                Dim lamaMenit As Integer = (CInt(rs("MBTRANSSTARTRENTHOURS"))) + (CInt(rs("MBTRANSADDITIONALRENTHOURS")))
                'If DeptInfo.roomFreePassAfterRent = "0" Then
                ' endHour = DateAdd(DateInterval.Hour, CInt(rs("MBTRANSFREEHOURS")), DateAdd(DateInterval.Minute, lamaMenit, startHour))
                ' Else                
                endHour = DateAdd(DateInterval.Minute, lamaMenit, startHour)
                'End If

                For i As Integer = 0 To 100 'IIf(Fix((lamaMenit / 60)) < (lamaMenit / 60), Fix((lamaMenit / 60) + 1), (lamaMenit / 60))                    
                    With grdMaster
                        isFoundRow = False
                        For j As Integer = 1 To .Rows.Count - 1
                            Dim tmpJamCari As Date
                            If i <> 0 Then
                                tmpJamCari = IIf(CDate(DateAdd(DateInterval.Minute, 1, jamAkhirHitung)).Hour >= 0 And CDate(DateAdd(DateInterval.Minute, 1, jamAkhirHitung)).Hour <= 8, DateAdd(DateInterval.Day, 1, CDate(DateAdd(DateInterval.Minute, 1, jamAkhirHitung))), CDate(DateAdd(DateInterval.Minute, 1, jamAkhirHitung)))
                            Else
                                tmpJamCari = IIf(CDate(jamAkhirHitung).Hour >= 0 And CDate(jamAkhirHitung).Hour <= 8, DateAdd(DateInterval.Day, 1, CDate(jamAkhirHitung)), CDate(jamAkhirHitung))
                            End If
                            tmpJamCari = IIf(CInt(tmpJamCari.Day) = 2 Or CInt(tmpJamCari.Day) = 1, tmpJamCari, DateAdd(DateInterval.Day, -1, tmpJamCari))
                            If Format(tmpJamCari, "HH:mm").ToString = "23:00" Or Format(tmpJamCari, "HH:mm").ToString = "18:00" Then tmpJamCari = DateAdd(DateInterval.Minute, -1, tmpJamCari)
                            'If CDate(.Item(j, "jammulai")) <= DateAdd(DateInterval.Minute, 1, jamAkhirHitung) And DateAdd(DateInterval.Minute, 1, jamAkhirHitung) <= CDate(.Item(j, "jamsampai")) Then
                            'MsgBox(tmpJamCari)
                            If CDate(.Item(j, "jammulai")) <= tmpJamCari And tmpJamCari <= CDate(.Item(j, "jamsampai")) Then
                                tmpJamAwal = jamAkhirHitung
                                If CStr(.Item(j, "mincount")) = "0" Then
                                    If tmpIsMin = True Then
                                        If selisihMenit > 0 Then
                                            tmpJamSampai = DateAdd(DateInterval.Minute, selisihMenit, jamAkhirHitung)
                                            selisihMenit = 0
                                        Else
                                            If lamaMenit < 60 Then
                                                tmpJamSampai = DateAdd(DateInterval.Minute, lamaMenit, jamAkhirHitung)
                                            Else
                                                tmpJamSampai = DateAdd(DateInterval.Hour, 1, jamAkhirHitung)
                                            End If
                                        End If
                                    Else
                                        tmpJamSampai = DateAdd(DateInterval.Hour, 1, jamAkhirHitung)
                                    End If
                                Else
                                    If IIf(selisihMenit = 0, DateAdd(DateInterval.Hour, 1, jamAkhirHitung), DateAdd(DateInterval.Minute, selisihMenit, jamAkhirHitung)) > CDate(.Item(j, "jamsampai")) Then                                        
                                        tmpJamSampai = CDate(.Item(j, "jamsampai"))
                                        If tmpJamSampai > endHour Then
                                            tmpJamSampai = endHour
                                        End If
                                        selisihMenit = DateDiff(DateInterval.Minute, CDate(.Item(j, "jamsampai")), DateAdd(DateInterval.Hour, 1, jamAkhirHitung))
                                    Else
                                        If selisihMenit > 0 Then
                                            tmpJamSampai = DateAdd(DateInterval.Minute, selisihMenit, jamAkhirHitung)
                                            selisihMenit = 0
                                        Else
                                            If lamaMenit < 60 Then
                                                tmpJamSampai = DateAdd(DateInterval.Minute, lamaMenit, jamAkhirHitung)
                                            Else
                                                tmpJamSampai = DateAdd(DateInterval.Hour, 1, jamAkhirHitung)
                                                If tmpJamSampai > endHour Then
                                                    tmpJamSampai = DateAdd(DateInterval.Minute, DateDiff(DateInterval.Minute, jamAkhirHitung, endHour), jamAkhirHitung)
                                                End If
                                            End If
                                        End If
                                    End If
                                End If
                                tmpHarga = CDec(.Item(j, "harga"))
                                If CDec(.Item(j, "pax")) < tmpJmlOrang Then
                                    tmpHargaOP = (tmpJmlOrang - CDec(.Item(j, "pax"))) * CDec(.Item(j, "hargapax"))
                                Else
                                    tmpHargaOP = 0
                                End If
                                If tmpIsMin = False Then tmpIsMin = IIf(CStr(.Item(j, "mincount")) = "0", False, True)
                                isFoundRow = True
                                Exit For
                            End If
                        Next
                        If isFoundRow = False Then
                            tmpJamAwal = jamAkhirHitung
                            If selisihMenit > 0 Then
                                tmpJamSampai = DateAdd(DateInterval.Minute, selisihMenit, jamAkhirHitung)
                                selisihMenit = 0
                            Else
                                tmpJamSampai = DateAdd(DateInterval.Hour, 1, jamAkhirHitung)
                            End If
                            tmpHarga = 0
                        End If
                        jamAkhirHitung = tmpJamSampai
                    End With
                    If jamAkhirHitung > endHour Then
                        Exit For
                    Else
                        If Format(tmpJamAwal, "HH:mm").ToString = Format(tmpJamSampai, "HH:mm").ToString Then Exit For
                        .AddItem("")
                        .Cols("jam").Item(.Rows.Count - 1) = Format(tmpJamAwal, "HH:mm") & " - " & Format(tmpJamSampai, "HH:mm")
                        .Cols("harga").Item(.Rows.Count - 1) = FormatNumber(tmpHarga, 0)
                        .Cols("jmljam").Item(.Rows.Count - 1) = IIf(DateDiff(DateInterval.Minute, tmpJamAwal, tmpJamSampai) = 60, "1 Jam", DateDiff(DateInterval.Minute, CDate(Format(tmpJamAwal, "yyyy/MM/dd HH:mm")), CDate(Format(tmpJamSampai, "yyyy/MM/dd HH:mm"))) & " Menit")
                        If InStr(UCase(.Item(.Rows.Count - 1, "jmljam")), "JAM") <> 0 Then
                            .Cols("total").Item(.Rows.Count - 1) = FormatNumber(tmpHarga, 0)
                            .Cols("overpax").Item(.Rows.Count - 1) = FormatNumber(tmpHargaOP, 0)
                        Else
                            .Cols("total").Item(.Rows.Count - 1) = IIf(tmpIsMin = True, FormatNumber((CInt(Replace(UCase(.Item(.Rows.Count - 1, "jmljam")), " MENIT", "")) / 60) * tmpHarga, 0), FormatNumber(tmpHarga, 0))
                            .Cols("overpax").Item(.Rows.Count - 1) = IIf(tmpIsMin = True, FormatNumber((CInt(Replace(UCase(.Item(.Rows.Count - 1, "jmljam")), " MENIT", "")) / 60) * tmpHargaOP, 0), FormatNumber(tmpHargaOP, 0))
                        End If
                        With grdMaterDiskon
                            For j As Integer = 1 To .Rows.Count - 1
                                If CDate(.Item(j, "jammulai")) <= tmpJamAwal And tmpJamAwal <= CDate(.Item(j, "jamsampai")) Then
                                    grdPrice.Cols("discount").Item(grdPrice.Rows.Count - 1) = (CDec(.Item(j, "diskon")) / 100) * CDec(grdPrice.Item(grdPrice.Rows.Count - 1, "total"))
                                    grdPrice.Cols("discountop").Item(grdPrice.Rows.Count - 1) = (CDec(.Item(j, "diskon")) / 100) * CDec(grdPrice.Item(grdPrice.Rows.Count - 1, "overpax"))
                                    Exit For
                                End If
                            Next
                        End With
                    End If
                Next
            End While
            .Redraw = True
        End With
        rs = Nothing
        'Call fillTotalOverPax(tmpCatRoomUID, tmpJmlOrang, tmpJumlahJam)
        Call FillTotalNotaRoom()
        With grdPromo
            .Redraw = False
            tmpJamAwal = startHour
            If tmpJamAwal.Hour >= 0 And tmpJamAwal.Hour <= 6 Then tmpJamAwal = tmpJamAwal.AddDays(1) : endHour = endHour.AddDays(1)
            While tmpJamAwal < endHour
                For j As Integer = 1 To .Rows.Count - 1                    
                    If CDate(.Item(j, "jammulai")) <= tmpJamAwal And tmpJamAwal <= CDate(.Item(j, "jamsampai")) Then
                        If CStr(.Item(j, "promoopt")) = "2" Then
                            If CDec(SubTotalTxt.Text) + tmpTotFNB >= CDec(.Item(j, "promocondition")) Then
                                Dim rowGrd As Integer = rowNumber(.Item(j, "id"))
                                If rowGrd = 0 Then
                                    grdGetPromo.AddItem("")
                                    grdGetPromo.Cols("namapromo").Item(grdGetPromo.Rows.Count - 1) = .Item(j, "id")
                                    grdGetPromo.Cols("barcodesupport").Item(grdGetPromo.Rows.Count - 1) = .Item(j, "barcodesupport")
                                    grdGetPromo.Cols("condition").Item(grdGetPromo.Rows.Count - 1) = .Item(j, "promocondition")
                                    grdGetPromo.Cols("jumlah").Item(grdGetPromo.Rows.Count - 1) = CStr(CDec(SubTotalTxt.Text) + tmpTotFNB)
                                    grdGetPromo.Cols("kelipatan").Item(grdGetPromo.Rows.Count - 1) = .Item(j, "kelipatan")
                                    grdGetPromo.Cols("tglexpired").Item(grdGetPromo.Rows.Count - 1) = IIf(.Item(j, "expireddays").ToString = "0", "", Format(DateAdd(DateInterval.Day, CInt(.Item(j, "expireddays")), Now.Date), "yyyy/MM/dd").ToString)
                                    grdGetPromo.Cols("promoopt").Item(grdGetPromo.Rows.Count - 1) = .Item(j, "promoopt")
                                End If
                            End If
                        Else
                            Dim rowGrd As Integer = rowNumber(.Item(j, "id"))
                            If rowGrd = 0 Then
                                grdGetPromo.AddItem("")
                                grdGetPromo.Cols("namapromo").Item(grdGetPromo.Rows.Count - 1) = .Item(j, "id")
                                grdGetPromo.Cols("barcodesupport").Item(grdGetPromo.Rows.Count - 1) = .Item(j, "barcodesupport")
                                grdGetPromo.Cols("condition").Item(grdGetPromo.Rows.Count - 1) = .Item(j, "promocondition")
                                grdGetPromo.Cols("jumlah").Item(grdGetPromo.Rows.Count - 1) = "1"
                                grdGetPromo.Cols("kelipatan").Item(grdGetPromo.Rows.Count - 1) = .Item(j, "kelipatan")
                                grdGetPromo.Cols("tglexpired").Item(grdGetPromo.Rows.Count - 1) = IIf(.Item(j, "expireddays").ToString = "0", "", Format(DateAdd(DateInterval.Day, CInt(.Item(j, "expireddays")), Now.Date), "yyyy/MM/dd").ToString)
                                grdGetPromo.Cols("promoopt").Item(grdGetPromo.Rows.Count - 1) = .Item(j, "promoopt")
                            Else
                                grdGetPromo.Cols("jumlah").Item(rowGrd) = CInt(grdGetPromo.Item(rowGrd, "jumlah")) + 1
                            End If
                        End If
                    End If
                Next
                tmpJamAwal = DateAdd(DateInterval.Hour, 1, tmpJamAwal)
            End While
            .Redraw = True
        End With
    End Sub

    Private Sub fillTotalOverPax(ByVal idCat As String, ByVal jmlOrang As Integer, ByVal jumlahJam As Integer)

        Dim rs As FbDataReader
        Dim tmpSelisih As Decimal = 0
        rs = MyDatabase.MyReader("SELECT A.TABLELISTCATPAX,B.TABLELISTCATDTPRICE,B.TABLELISTCATDTOVERPAX FROM TABLELISTCAT A INNER JOIN TABLELISTCATDT B ON A.TABLELISTCATUID=B.TABLELISTCATUID WHERE A.TABLELISTCATUID='" & idCat & "'")
        If rs.Read = True Then
            If jmlOrang > CInt(rs("TABLELISTCATPAX")) Then
                tmpSelisih = (jmlOrang - CInt(rs("TABLELISTCATPAX"))) * CDec(rs("TABLELISTCATDTOVERPAX"))
            End If
        End If
        rs = Nothing
        txtOverPax.Value = FormatNumber(tmpSelisih * jumlahJam, 0)
    End Sub

    Private Function rowNumber(ByVal idPromo As String) As Integer
        With grdGetPromo
            For i As Integer = 1 To .Rows.Count - 1
                If Trim(UCase(CStr(.Item(i, "namapromo")))) = Trim(UCase(idPromo)) Then
                    Return i
                End If
            Next
        End With
    End Function

    Private Sub FillTotalNotaRoom()
        Dim tmpTotal As Decimal = 0
        Dim tmpDisc As Decimal = 0
        Dim tmpOverPax As Decimal = 0
        With grdPrice
            For i As Integer = 1 To .Rows.Count - 1
                tmpTotal += CDec(.Item(i, "total"))
                tmpDisc += CDec(.Item(i, "discount")) + CDec(.Item(i, "discountop"))
                tmpOverPax += CDec(.Item(i, "overpax"))
            Next
        End With
        txtOverPax.Value = FormatNumber(tmpOverPax, 0)
        SubTotalTxt.Value = FormatNumber(tmpTotal + CDec(txtOverPax.Text), 0)
        DiscountTxt.Value = FormatNumber(tmpDisc, 0)
        If Tax1Check.Checked Then
            Tax1ValTxt.Value = FormatNumber((((SubTotalTxt.Value - DiscountTxt.Value) * Tax1Txt.Value) / 100), 0)
        Else
            Tax1ValTxt.Value = "0"
        End If
        If Tax2Check.Checked Then
            Tax2ValTxt.Value = FormatNumber((((SubTotalTxt.Value - DiscountTxt.Value + Tax1ValTxt.Value) * Tax2Txt.Value) / 100), 0)
        Else
            Tax2ValTxt.Value = "0"
        End If
        TotalTxt.Value = FormatNumber(CDec(SubTotalTxt.Value) - CDec(DiscountTxt.Value) + (CDec(Tax1ValTxt.Value) + CDec(Tax2ValTxt.Value) - CDec(DPtxt.Value)), 0)
        lblGrangTotal.Value = FormatNumber(CDec(TotalTxt.Text) + CDec(TotalItemTxt.Text), 0)
    End Sub

    Private Sub fillGridPromo(ByVal idCategoryCust As String, ByVal tglMB As Date, ByVal idHari As Integer)
        Dim rs As FbDataReader
        rs = MyDatabase.MyReader("SELECT B.*,C.* FROM CUSTCATDT A INNER JOIN PROMO B ON A.CUSTCATPROMOUID=B.PROMOUID INNER JOIN PROMODT C ON B.PROMOUID=C.PROMOUID WHERE A.CUSTCATUID='" & idCategoryCust & "' AND PROMOSTARTDATE<='" & tglMB & "' AND PROMOENDDATE>='" & tglMB & "' AND B.PROMOACTV='0' AND C.PROMODTDAYTYPE='" & idHari & "' AND (PROMOOPT='2' OR PROMOOPT='1')")
        With grdPromo
            .Redraw = False
            .Rows.Count = 1
            While rs.Read = True
                .AddItem("")
                .Cols("namapromo").Item(.Rows.Count - 1) = rs("PROMONAME")
                .Cols("promoopt").Item(.Rows.Count - 1) = rs("PROMOOPT")
                .Cols("promocondition").Item(.Rows.Count - 1) = rs("PROMOCONDITION")
                .Cols("valuetime").Item(.Rows.Count - 1) = rs("VALUETIMES")
                .Cols("barcodesupport").Item(.Rows.Count - 1) = rs("PROMOISBARCODESUPPORT")
                .Cols("tipehari").Item(.Rows.Count - 1) = rs("PROMODTDAYTYPE")
                .Cols("jammulai").Item(.Rows.Count - 1) = IIf(CDate(rs("PROMODTSTARTHR")).Hour > 0 And CDate(rs("PROMODTSTARTHR")).Hour <= 8, DateAdd(DateInterval.Day, 1, CDate(rs("PROMODTSTARTHR"))), CDate(rs("PROMODTSTARTHR")))
                .Cols("jamsampai").Item(.Rows.Count - 1) = IIf(CDate(rs("PROMODTENDHR")).Hour > 0 And CDate(rs("PROMODTENDHR")).Hour <= 8, DateAdd(DateInterval.Day, 1, CDate(rs("PROMODTENDHR"))), CDate(rs("PROMODTENDHR")))
                .Cols("id").Item(.Rows.Count - 1) = rs("PROMOUID")
                .Cols("kelipatan").Item(.Rows.Count - 1) = rs("VALIDTIMES")
                .Cols("expireddays").Item(.Rows.Count - 1) = IIf(IsDBNull(rs("PROMOEXPIREDDAYS")) = True, "0", IIf(Trim(rs("PROMOEXPIREDDAYS")) = "", "0", rs("PROMOEXPIREDDAYS")))
                .Cols("PROMOOPT").Item(.Rows.Count - 1) = rs("PROMOOPT")
            End While
            .Redraw = True
        End With
        rs = Nothing
    End Sub

    Private Sub fillGridHarga(ByVal idKategoriTable As String, ByVal idHari As Integer)
        Dim rs As FbDataReader
        rs = MyDatabase.MyReader("SELECT B.*,TABLELISTCATPAX FROM TABLELISTCAT A INNER JOIN TABLELISTCATDT B ON A.TABLELISTCATUID=B.TABLELISTCATUID WHERE B.TABLELISTCATUID='" & idKategoriTable & "' AND B.TABLELISTCATDTDAYTYPE='" & idHari & "' AND A.TABLELISTCATACTV='0'")
        With grdMaster
            .Redraw = False
            .Rows.Count = 1
            While rs.Read = True
                .AddItem("")
                .Cols("jammulai").Item(.Rows.Count - 1) = IIf(CDate(rs("TABLELISTCATDTSTARTHR")).Hour >= 0 And CDate(rs("TABLELISTCATDTSTARTHR")).Hour <= 8, DateAdd(DateInterval.Day, 1, CDate(rs("TABLELISTCATDTSTARTHR"))), CDate(rs("TABLELISTCATDTSTARTHR")))
                .Cols("jamsampai").Item(.Rows.Count - 1) = IIf(CDate(rs("TABLELISTCATDTENDHR")).Hour >= 0 And CDate(rs("TABLELISTCATDTENDHR")).Hour <= 8, DateAdd(DateInterval.Day, 1, CDate(rs("TABLELISTCATDTENDHR"))), CDate(rs("TABLELISTCATDTENDHR")))
                .Cols("harga").Item(.Rows.Count - 1) = rs("TABLELISTCATDTPRICE")
                .Cols("mincount").Item(.Rows.Count - 1) = rs("TABLELISTCATDTISMINCOUNT")
                .Cols("pax").Item(.Rows.Count - 1) = rs("TABLELISTCATPAX")
                .Cols("hargapax").Item(.Rows.Count - 1) = rs("TABLELISTCATDTOVERPAX")
            End While
            .Redraw = True
        End With
        rs = Nothing
    End Sub

    Private Sub fillGridDiskon(ByVal idHari As Integer, ByVal tglMB As Date, ByVal idCatCust As String)
        If idHari = 0 Then idHari = 7
        Dim rs As FbDataReader
        Dim rowCount As Integer
        Dim tmpJamAwal As Date
        rs = MyDatabase.MyReader("SELECT A.DISCAMT,B.DISCSTARTTIME,B.DISCENDTIME FROM DISC A INNER JOIN DISCDATETIME B ON A.DISCUID=B.DISCUID INNER JOIN CUSTCAT C ON A.DISCUID=C.CUSTCATDISCUID WHERE C.CUSTCATUID='" & idCatCust & "' AND A.DISCTYPEOPTID='5' AND (B.DISCDATETIMEDAYTYPEID='" & idHari & "' OR B.DISCDATETIMEDAYTYPEID='" & IIf(idHari = 7, 0, idHari + 1) & "') AND A.DISCSTARTDATE<='" & tglMB & "' AND A.DISCENDDATE>='" & tglMB & "' AND A.DISCACTV='0'")
        With grdMaterDiskon
            .Redraw = False
            .Rows.Count = 1
            While rs.Read = True
                .AddItem("")
                rowCount = .Rows.Count - 2
                .Cols("diskon").Item(.Rows.Count - 1) = rs("DISCAMT")
                If rowCount = 0 Then
                    tmpJamAwal = CDate(rs("DISCSTARTTIME"))
                End If
                If tmpJamAwal.Hour >= 8 Then
                    .Cols("jammulai").Item(.Rows.Count - 1) = IIf(CDate(rs("DISCSTARTTIME")).Hour > 0 And CDate(rs("DISCSTARTTIME")).Hour <= 8, DateAdd(DateInterval.Day, 1, CDate(rs("DISCSTARTTIME"))), CDate(rs("DISCSTARTTIME")))
                    .Cols("jamsampai").Item(.Rows.Count - 1) = IIf(CDate(rs("DISCENDTIME")).Hour > 0 And CDate(rs("DISCENDTIME")).Hour <= 8, DateAdd(DateInterval.Day, 1, CDate(rs("DISCENDTIME"))), CDate(rs("DISCENDTIME")))
                Else
                    .Cols("jammulai").Item(.Rows.Count - 1) = DateAdd(DateInterval.Day, rowCount, CDate(rs("DISCSTARTTIME"))) 'IIf(CDate(rs("DISCSTARTTIME")).Hour > 0 And CDate(rs("DISCSTARTTIME")).Hour <= 8, DateAdd(DateInterval.Day, 1, CDate(rs("DISCSTARTTIME"))), CDate(rs("DISCSTARTTIME")))
                    .Cols("jamsampai").Item(.Rows.Count - 1) = DateAdd(DateInterval.Day, rowCount, CDate(rs("DISCENDTIME"))) ' IIf(CDate(rs("DISCENDTIME")).Hour > 0 And CDate(rs("DISCENDTIME")).Hour <= 8, DateAdd(DateInterval.Day, 1, CDate(rs("DISCENDTIME"))), CDate(rs("DISCENDTIME")))
                End If
            End While
            .Redraw = True
        End With
        rs = Nothing
    End Sub

    Private Sub Form_Make_Bill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New System.Drawing.Point(MainPage.Location.X + 265, MainPage.Location.Y + 15)
        If PrefInfo.UseRounding = True Then
            'Me.Location = New System.Drawing.Point(MainPage.Location.X + 268, MainPage.Location.Y + 44)
            lblRounding.Visible = True
            If PrefInfo.UseAutoRounding = True Then
                lblSetelahRounding.Size = New System.Drawing.Size(263, 27)
                cmdCalcRounding.Visible = False
            Else
                lblSetelahRounding.Size = New System.Drawing.Size(208, 27)
                cmdCalcRounding.Visible = True
            End If
        Else
            'Me.Location = New System.Drawing.Point(MainPage.Location.X + 268, MainPage.Location.Y + 100)
            lblRounding.Visible = False
            GroupBox.Size = New System.Drawing.Point(407, 602)
            Me.Size = New System.Drawing.Size(430, 700)
            BTNDiscount.Location = New System.Drawing.Point(12, 620)
            BTNSave.Location = New System.Drawing.Point(BTNSave.Location.X, BTNDiscount.Location.Y)
            BTNCancel.Location = New System.Drawing.Point(BTNCancel.Location.X, BTNDiscount.Location.Y)
        End If
        Me.Text = "Make Bill - Room " & Replace(SelectedTable.TableName, vbNewLine, " ")
        Me.Cursor = Cursors.Default
        Call BasicInitialize()
        Call ShowPoleDisplay("Total : " & lblSetelahRounding.Text)
        CustomerList.Enabled = False
        CustName.Enabled = False
        FindCust.Enabled = False : FindCust.VisualStyle = C1Input.VisualStyle.Office2007Silver
        VirtualKey.Enabled = False : VirtualKey.VisualStyle = C1Input.VisualStyle.Office2007Silver
    End Sub

    Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancel.Click
        If Authorize = True Then
            Authorize = False
            UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
            Call MainPage.StatusBarInitialize()
        End If
        Call ShowPoleDisplay(PrefInfo.Header, False)
        Call MainPage.TableClickInfo(selectedObject, myEvent)
        Me.Close()
    End Sub

    Private Sub CustomerList_Change(ByVal sender As Object, ByVal e As System.EventArgs)
        If CustomerList.SelectedIndex > 0 Then
            Call ReinitializePrice()
        End If
    End Sub

    Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click
     
        Me.Cursor = Cursors.WaitCursor
        If Authorize = True Then
            Authorize = False
            UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
            Call MainPage.StatusBarInitialize()
        End If

        If CustomerList.SelectedIndex = -1 Then
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Silakan pilih customer terlebih dahulu !")
            Exit Sub
        End If

        'If TotalItemTxt.Text = 0 Then
        '    Me.Cursor = Cursors.Default
        '    ShowMessage(Me, "Maaf, anda tidak dapat membuat tagihan, karena tidak ada order pesanan yang terdaftar dalam tagihan ini !")
        '    Exit Sub
        'End If

        'BillNo.Text = AutoIDNumber("BIL", "PBTRANS", "PBTRANSNO")
        Dim idRoom As String = ""
        Dim custID As String = ""
        Dim nmCust As String = ""
        Dim idDept As String = ""
        Dim idModul As String = ""
        Dim idShift As String = ""
        Dim tglMBTrans As Date = Nothing
        Dim TMPHeader As FbDataReader, modifiedTime As DateTime
        TMPHeader = MyDatabase.MyReader("SELECT * FROM MBTrans WHERE MBTransUID = '" & TransactionUID & "'")
        TMPHeader.Read()
        modifiedTime = TMPHeader.Item("MODIFIEDDATETIME")
        idRoom = TMPHeader("MBTRANSTABLELISTUID")
        custID = TMPHeader("MBTRANSCUSTUID")
        nmCust = TMPHeader("MBTRANSCUSTNAME")
        idDept = TMPHeader("MBTRANSDEPTUID")
        idModul = TMPHeader("MBTRANSMODULETYPEID")
        tglMBTrans = TMPHeader("MBTRANSDATE")
        idShift = TMPHeader("MBTRANSSHIFTNO")
        Dim tmpIDResev As String = IIf(IsDBNull(TMPHeader("MBTRANSRSVTRANSUID")) = True, "", TMPHeader("MBTRANSRSVTRANSUID"))
        'MsgBox(FinalTime & " = " & ModifiedTime)

        If FinalTime <> modifiedTime Then
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Maaf, anda tidak dapat menyimpan tagihan, karena tagihan ini telah dirubah oleh user lain !")
            Me.Close()
            Exit Sub
        End If
        If CDec(getDPSisa(tmpIDResev)) < CDec(DPtxt.Value) Then
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Maaf, anda tidak dapat membuat tagihan, karena Anda memasukkan down payment yang nilainya lebih besar dari sisa down payment yang ada di 'Reservasi' !")
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

        'If SubTotalTxt.Text = "0" Then
        '    Query = "UPDATE MBTRANS SET MBTRANSCUSTUID='" & CustomerList.Columns(1).Text & "', MBTRANSCUSTNAME ='" & ReplacePetik(CustName.Text) & "',MBTRANSSUBVAL ='0', MBTRANSDISCPERC ='0', MBTRANSDISCVAL ='0', MBTransTaxVal1 = '0', MBTransTaxVal2 = '0', MBTRANSTOTVAL='0', MBTRANSSTAT='1', ISBILLED='1', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',ISFISCAL='" & t & "' WHERE MBTRANSUID = '" & TransactionUID & "'"
        '    Call MyDatabase.MyAdapter(Query)
        '    GoTo P
        'End If
        If SubTotalTxt.Text = "0" Then
            Query = "UPDATE MBTRANS SET MBTRANSROOMSUBVAL ='" & CDbl(SubTotalTxt.Text) & "', MBTRANSROOMDISCPERC ='0',MBTRANSROOMDISCUID=NULL, MBTRANSROOMDISCVAL ='" & CDbl(DiscountTxt.Text) & "', MBTRANSROOMTAXVAL1 = '" & CDbl(Tax1ValTxt.Text) & "', MBTRANSROOMTAXVAL2 = '" & CDbl(Tax2ValTxt.Text) & "', MBTRANSROOMTOTVAL='" & CDbl(TotalTxt.Text) & "', MBTRANSSTAT='1', ISROOMBILLED='1', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',ISFISCAL='" & t & "',MBTRANSROUNDINGVAL='" & CDbl(lblRounding.Text) & "',MBTRANSTOTVAL=" & CDbl(lblSetelahRounding.Text) & " WHERE MBTRANSUID = '" & TransactionUID & "'"
        Else
            'Query = "UPDATE MBTRANS SET MBTRANSROOMSUBVAL ='" & CDbl(SubTotalTxt.Text) & "',MBTRANSROOMDISCUID=" & IIf(CDec(DiscountTxt.Text) > 0, "'" & CustomerList.Columns(2).Text & "'", "NULL") & ", MBTRANSROOMDISCPERC ='" & Replace(Format((CDec(DiscountTxt.Text) * 100) / CDec(SubTotalTxt.Text), "#,##0.000"), ",", ".") & "', MBTRANSROOMDISCVAL ='" & CDbl(DiscountTxt.Text) & "', MBTRANSROOMTAXVAL1 = '" & CDbl(Tax1ValTxt.Text) & "', MBTRANSROOMTAXVAL2 = '" & CDbl(Tax2ValTxt.Text) & "', MBTRANSROOMTOTVAL='" & CDbl(TotalTxt.Text) & "',MBTRANSDPVAL='" & CDec(DPtxt.Text) & "',MBTRANSTOTVAL=IIF(MBTRANSFNBTOTVAL IS NULL,0,MBTRANSFNBTOTVAL)+" & CDbl(TotalTxt.Text) & ", MBTRANSSTAT='1', ISROOMBILLED='1',MBTRANSOVERPAXVALUE=" & CDbl(txtOverPax.Text) & ", MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',ISFISCAL='" & t & "',MBTRANSROUNDINGVAL='" & CDbl(lblRounding.Text) & "',MBTRANSTIPSVAL='" & CDbl(lblSetelahRounding.Text) & "' WHERE MBTRANSUID = '" & TransactionUID & "'"
            'Susilo, 28 April 2014. Setelah ada rounding
            Query = "UPDATE MBTRANS SET MBTRANSROOMSUBVAL ='" & CDbl(SubTotalTxt.Text) & "',MBTRANSROOMDISCUID=" & IIf(CDec(DiscountTxt.Text) > 0, "'" & CustomerList.Columns(2).Text & "'", "NULL") & ", MBTRANSROOMDISCPERC ='" & Replace(Format((CDec(DiscountTxt.Text) * 100) / CDec(SubTotalTxt.Text), "#,##0.000"), ",", ".") & "', MBTRANSROOMDISCVAL ='" & CDbl(DiscountTxt.Text) & "', MBTRANSROOMTAXVAL1 = '" & CDbl(Tax1ValTxt.Text) & "', MBTRANSROOMTAXVAL2 = '" & CDbl(Tax2ValTxt.Text) & "', MBTRANSROOMTOTVAL='" & CDbl(TotalTxt.Text) & "',MBTRANSDPVAL='" & CDec(DPtxt.Text) & "',MBTRANSTOTVAL=" & CDbl(lblSetelahRounding.Text) & ", MBTRANSSTAT='1', ISROOMBILLED='1',MBTRANSOVERPAXVALUE=" & CDbl(txtOverPax.Text) & ", MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',ISFISCAL='" & t & "',MBTRANSROUNDINGVAL='" & CDbl(lblRounding.Text) & "' WHERE MBTRANSUID = '" & TransactionUID & "'"
        End If
        Call MyDatabase.MyAdapter(Query)
        If Trim(tmpIDResev) <> "" Then
            Query = "UPDATE RSVTRANS SET RSVTRANSUSEDPVAL=RSVTRANSUSEDPVAL+" & CDec(DPtxt.Text) & " WHERE RSVTRANSUID='" & tmpIDResev & "'"
            MyDatabase.MyAdapter(Query)
        End If
        'If t = 1 Then
        '    Query = "INSERT INTO MBTRANS(MBTRANSUID,MBTRANSNO,MBTRANSDATE,MBTRANSDEPTUID, MBTRANSMODULETYPEID,MBTRANSPAXVAL,MBTRANSCUSTUID,MBTRANSCUSTNAME,MBTRANSTABLELISTUID,MBTRANSSERVICETYPEUID,MBTRANSRSVTRANSUID,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,ISBILLED,ISFISCAL) " & _
        '          "VALUES('" & TransactionUID & "','" & AutoIDNumber2(FileDatabase2, "2202", "MBTRANS", "MBTRANSNO") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2202','" & Visitor & "','" & CustomerList.Columns(1).Text & "','" & ReplacePetik(CustName.Text) & "','" & SelectedTable.TableUID & "','" & ServiceUID & "'," & ReservationUID & ",'" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',0,'" & x & "')"
        '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)

        '    'Anjo - 30Okt - Check divided by zero here
        '    'Query = "UPDATE MBTRANS SET MBTRANSCUSTUID='" & CustomerList.Columns(1).Text & "', MBTRANSCUSTNAME ='" & ReplacePetik(CustName.Text) & "',MBTRANSSUBVAL ='" & CDbl(SubTotalTxt.Text) & "', MBTRANSDISCPERC ='" & Replace(Format((CDec(DiscountTxt.Text) * 100) / CDec(SubTotalTxt.Text), "#,##0.000"), ",", ".") & "', MBTRANSDISCVAL ='" & CDbl(DiscountTxt.Text) & "', MBTransTaxVal1 = '" & CDbl(Tax1ValTxt.Text) & "', MBTransTaxVal2 = '" & CDbl(Tax2ValTxt.Text) & "', MBTRANSTOTVAL='" & CDbl(TotalTxt.Text) & "', MBTRANSSTAT='1', ISBILLED='1', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',ISFISCAL='" & t & "' WHERE MBTRANSUID = '" & TransactionUID & "'"
        '    'Call MyDatabase.MyAdapter2(FileDatabase2, Query)

        '    For D = 1 To ListCollection.Count
        '        Dim ListArray As New ArrayList
        '        ListArray = ListCollection(D)
        '        Query = "INSERT INTO MBTRANSDT (MBTRANSDTUID, MBTRANSUID, MBTRANSDTITEMUID, MBTRANSDTITEMNAME, MBTRANSDTITEMMEASUNITDESC, MBTRANSDTITEMQTY, MBTRANSDTITEMDISCUID1, MBTRANSDTITEMDISCVAL1, MBTRANSDTITEMDISCUID2, MBTRANSDTITEMDISCVAL2, MBTRANSDTITEMPRICE, MBTRANSDTSUBVAL, MBTRANSDTITEMNOTE, MBTRANSDTITEMSTAT, MBTRANSDTITEMCANCELLEDNOTE, MBTRANSDTISTAKEAWAY, MBTRANSDTISPOSTED, CREATEDUSER, MODIFIEDUSER, DELETEDUSER, CREATEDDATETIME, MODIFIEDDATETIME, DELETEDDATETIME, PRINT) " & _
        '                "VALUES ('" & ListArray(0) & "','" & ListArray(1) & "','" & ListArray(2) & "','" & ListArray(3) & "','" & ListArray(4) & "','" & ListArray(5) & "','" & ListArray(6) & "','" & ListArray(7) & "','" & ListArray(8) & "','" & ListArray(9) & "','" & ListArray(10) & "','" & ListArray(11) & "','" & ListArray(12) & "','" & ListArray(13) & "','" & ListArray(14) & "','" & ListArray(15) & "','" & ListArray(16) & "','" & ListArray(17) & "','" & ListArray(18) & "','" & ListArray(19) & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',NULL,'" & ListArray(23) & "')"
        '        Call MyDatabase.MyAdapter2(FileDatabase2, Query)
        '    Next
        'Else
        '    Query = "DELETE FROM MBTRANS WHERE MBTRANSUID='" & TransactionUID & "'"
        '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
        'End If


        'Dim Lastdiskitem As Double = 0, Lastprice As Double = 0
        'For i As Integer = 1 To TMPDiscListCollection.Count
        '    Dim TmpArray As New ArrayList
        '    TmpArray = TMPDiscListCollection(i)
        '    If i Mod 2 = 1 Then
        '        Lastprice = TmpArray(4) * TmpArray(7)
        '        Lastdiskitem = TmpArray(10) * TmpArray(11)
        '        Query = "UPDATE MBTRANSDT SET MBTRANSDTITEMDISCUID1 = '" & TmpArray(5) & "', MBTRANSDTITEMDISCVAL1='" & Replace(Format(CDec(TmpArray(10)) * CDec(TmpArray(11)), "###0"), ",", "") & "', MBTRANSDTSUBVAL ='" & (TmpArray(4) * TmpArray(7)) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSDTUID LIKE '" & TmpArray(1) & "'"
        '        Call MyDatabase.MyAdapter(Query)
        '    Else
        '        Query = "UPDATE MBTRANSDT SET MBTRANSDTITEMDISCUID2 = '" & TmpArray(5) & "', MBTRANSDTITEMDISCVAL2='" & Replace(Format(CDec(TmpArray(10)) * CDec(TmpArray(11)), "###0"), ",", "") & "', MBTRANSDTSUBVAL ='" & Lastprice & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSDTUID LIKE '" & TmpArray(1) & "'"
        '        Lastdiskitem = 0
        '        Call MyDatabase.MyAdapter(Query)
        '    End If
        'Next

        MyDatabase.MyAdapter("DELETE FROM MBTRANSROOMDT WHERE MBTRANSUID='" & TransactionUID & "'")
        Dim tmpJmlMenit As Integer = 0
        With grdPrice
            If .Rows.Count > 1 Then
                For i As Integer = 1 To .Rows.Count - 1
                    If InStr(UCase(Trim(CStr(.Item(i, "jmljam")))), " JAM") Then
                        tmpJmlMenit = 60
                    Else
                        tmpJmlMenit = Replace(UCase(Trim(CStr(.Item(i, "jmljam")))), " MENIT", "")
                    End If
                    MyDatabase.MyAdapter("INSERT INTO MBTRANSROOMDT (MBTRANSROOMDTUID,MBTRANSUID,MBTRANSROOMDTTIMEDESC,MBTRANSROOMDTRENTLENGTH,MBTRANSROOMDTDISCVAL,MBTRANSROOMDTRATE,MBTRANSROOMDTSUBVAL,CREATEDUSER,MODIFIEDUSER,DELETEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,DELETEDDATETIME) VALUES ('" & AutoUID() & "','" & TransactionUID & "','" & .Item(i, "jam") & "','" & tmpJmlMenit & "','" & Replace(CDec(.Item(i, "discount")), ",", ".") & "','" & CDec(.Item(i, "harga")) & "','" & CDec(.Item(i, "total")) & "','" & UserInformation.UserName & "',NULL,NULL,'" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',NULL,NULL)")
                Next
            End If
        End With

        MyDatabase.MyAdapter("DELETE FROM SALESPROMOREG WHERE SALESPROMOREGTRANSUID='" & TransactionUID & "' AND SALESPROMOREGPROMOUID IN (SELECT PROMOUID FROM PROMO WHERE PROMOOPT='1' OR PROMOOPT='2')")
        With grdGetPromo
            If .Rows.Count > 1 Then
                For i As Integer = 1 To .Rows.Count - 1
                    If CDec(.Item(i, "jumlah")) >= CDec(.Item(i, "condition")) Then
                        If CStr(.Item(i, "kelipatan")) = "0" Then
                            MyDatabase.MyAdapter("INSERT INTO SALESPROMOREG (SALESPROMOREGUID,SALESPROMOREGTRANSUID,SALESPROMOREGTRANSNO,SALESPROMOREGTRANSDATE,SALESPROMOREGTRANSDEPTUID,SALESPROMOREGTRANSMODULETYPEID,SALESPROMOREGTRANSSHIFTNO,SALESPROMOREGTRANSCUSTUID,SALESPROMOREGTRANSCUSTNAME,SALESPROMOREGTRANSTABLELISTUID,SALESPROMOREGPROMOUID,SALESPROMOREGPROMOQTY,SALESPROMOREGTRANSSTAT,SALESPROMOREGPROMOGENERATEDNO) VALUES (" & _
                                                 "'" & AutoUID() & "','" & TransactionUID & "','" & TransactionNo & "','" & Format(tglMBTrans, "yyyy/MM/dd HH:mm:ss") & "','" & DeptInfo.DeptUID & "'," & idModul & ",'" & idShift & "','" & custID & "','" & nmCust & "','" & idRoom & "','" & .Item(i, "namapromo") & "',1,0,'" & Strings.Left(AutoUID(), 20) & "')")
                        Else
                            If CStr(.Item(i, "barcodesupport")) = "0" Then
                                MyDatabase.MyAdapter("INSERT INTO SALESPROMOREG (SALESPROMOREGUID,SALESPROMOREGTRANSUID,SALESPROMOREGTRANSNO,SALESPROMOREGTRANSDATE,SALESPROMOREGTRANSDEPTUID,SALESPROMOREGTRANSMODULETYPEID,SALESPROMOREGTRANSSHIFTNO,SALESPROMOREGTRANSCUSTUID,SALESPROMOREGTRANSCUSTNAME,SALESPROMOREGTRANSTABLELISTUID,SALESPROMOREGPROMOUID,SALESPROMOREGPROMOQTY,SALESPROMOREGTRANSSTAT,SALESPROMOREGPROMOGENERATEDNO) VALUES (" & _
                                                 "'" & AutoUID() & "','" & TransactionUID & "','" & TransactionNo & "','" & Format(tglMBTrans, "yyyy/MM/dd HH:mm:ss") & "','" & DeptInfo.DeptUID & "'," & idModul & ",'" & idShift & "','" & custID & "','" & nmCust & "','" & idRoom & "','" & .Item(i, "namapromo") & "','" & Fix(CDec(.Item(i, "jumlah")) / CDec(.Item(i, "condition"))) & "',0,'" & Strings.Left(AutoUID(), 20) & "')")
                            Else
                                For j As Integer = 1 To Fix(CDec(.Item(i, "jumlah")) / CDec(.Item(i, "condition")))
                                    MyDatabase.MyAdapter("INSERT INTO SALESPROMOREG (SALESPROMOREGUID,SALESPROMOREGTRANSUID,SALESPROMOREGTRANSNO,SALESPROMOREGTRANSDATE,SALESPROMOREGTRANSDEPTUID,SALESPROMOREGTRANSMODULETYPEID,SALESPROMOREGTRANSSHIFTNO,SALESPROMOREGTRANSCUSTUID,SALESPROMOREGTRANSCUSTNAME,SALESPROMOREGTRANSTABLELISTUID,SALESPROMOREGPROMOUID,SALESPROMOREGPROMOQTY,SALESPROMOREGTRANSSTAT,SALESPROMOREGPROMOGENERATEDNO) VALUES (" & _
                                                     "'" & AutoUID() & "','" & TransactionUID & "','" & TransactionNo & "','" & Format(tglMBTrans, "yyyy/MM/dd HH:mm:ss") & "','" & DeptInfo.DeptUID & "'," & idModul & ",'" & idShift & "','" & custID & "','" & nmCust & "','" & idRoom & "','" & .Item(i, "namapromo") & "','1',0,'" & Strings.Left(AutoUID(), 20) & "')")
                                Next
                            End If
                        End If
                    End If
                Next
            End If
        End With

        Me.Cursor = Cursors.Default
        Call MainPage.TableClickInfo(selectedObject, myEvent)
        For i As Integer = 1 To CInt(PrefInfo.pubJumlahPrintOutBill)
            Call ShowPrintPreview(True)
        Next
        Me.Close()
        'P:
        '        SaveStatus = True
        '        

        'Call ShowPrintPreview(True)
        '        Me.Cursor = Cursors.Default

        '        Me.Close()

    End Sub

    Private Sub FindCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindCust.Click
        Me.Cursor = Cursors.WaitCursor
        Dim CustDialog As New Form_Customer_Pick
        CustDialog.Name = "Form_Customer_Pick"
        CustDialog.ParentOBJForm = Me
        CustDialog.ShowDialog()
        Me.Cursor = Cursors.Default
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
    End Sub

    Public Sub NewPriceAfterDiscount(ByVal NewPrice)
        'By Rudy 19 May 2010
        'Dim NewDisc As Double = 0
        'NewDisc = SubTotalTxt.Text - NewPrice
        'DiscountTxt.Value = FormatNumber(NewDisc, 0)

        Call ReinitializePrice()

    End Sub

    Private Sub Tax1Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tax1Check.CheckedChanged
        If Tax1Check.Checked = True Then
            Tax1Txt.Value = PrefInfo.RentTax1Rate
        Else
            Tax1Txt.Value = 0
        End If
        Call ReinitializePrice()
    End Sub

    Private Sub Tax2Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tax2Check.CheckedChanged
        If Tax2Check.Checked = True Then
            Tax2Txt.Value = PrefInfo.RentTax2Rate
        Else
            Tax2Txt.Value = 0
        End If
        Call ReinitializePrice()
    End Sub

    Private Sub Tax1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Tax1.MouseDown
        If PrefInfo.RentTax1Active = False Then Exit Sub
        'Exit Sub 'Andy 28 Des 2011 'Andy 8 Okt 2011

        If x = 0 Then
            x = 1
            Tax1.Image = My.Resources.OK
            Tax1Txt.Value = PrefInfo.RentTax1Rate
            Tax1Check.Checked = True
        Else
            x = 0
            Tax1.Image = My.Resources._NOTHING
            Tax1Txt.Value = 0
            Tax1Check.Checked = False
        End If
    End Sub

    Private Sub Tax2_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Tax2.MouseDown
        If PrefInfo.RentTax2Active = False Then Exit Sub
        'Exit Sub 'Andy 28 Des 2011 'Andy 8 Okt 2011

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

    Private Sub BillNo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles BillNo.MouseDown
        'Susilo, 9 Okt 2013. untuk backup per nota sudah bisa dilakukan di modul payment saja
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
        '        Tax.Visible = True
        '    Else
        '        ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
        '        t = 0
        '        Tax.Visible = False
        '    End If
        'Else
        '    t = 0
        '    Tax.Visible = False
        'End If
    End Sub

    
#End Region

    Private Sub Tax1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tax1.Click

    End Sub

    Private Sub Tax2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tax2.Click

    End Sub

    Private Sub VirtualCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualCalculator.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator1 As New Form_Virtual_Calculator
        VirtuCalculator1.OBJBind(txtDPInvisible)
        VirtuCalculator1.showMoney = True
        VirtuCalculator1.ShowDialog()        
        DPtxt.Value = FormatNumber(txtDPInvisible.Text, 0)
        Dim TotalGlobal As Decimal = 0
        TotalGlobal = SubTotalTxt.Value - DiscountTxt.Value + Tax1ValTxt.Value + Tax2ValTxt.Value - DPtxt.Value
        TotalTxt.Value = FormatNumber(TotalGlobal, 0)
        lblGrangTotal.Value = FormatNumber(TotalGlobal + CDec(TotalItemTxt.Text), 0)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdCalcRounding_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalcRounding.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        VirtuCalculator.OBJBind(txtRoundingInvisible)
        VirtuCalculator.showMoney = False
        VirtuCalculator.ShowDialog()
        If CDec(txtRoundingInvisible.Text) < CDec(lblGrangTotal.Text) Then
            ShowMessage(Me, "Maaf, nilai setelah rounding tidak boleh lebih kecil dari total !", True)
            txtRoundingInvisible.Text = lblSetelahRounding.Text
            Me.Cursor = Cursors.Default
            Exit Sub
        End If
        lblSetelahRounding.Value = FormatNumber(txtRoundingInvisible.Text, 0)
        Dim getRounding As Decimal = 0
        getRounding = txtRoundingInvisible.Text - lblGrangTotal.Text
        lblRounding.Value = FormatNumber(getRounding, 0)
        Me.Cursor = Cursors.Default
    End Sub
End Class