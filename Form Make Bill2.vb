Imports System
Imports C1.Win
Imports FirebirdSql.Data.FirebirdClient
Imports DataDynamics.ActiveReports

Public Class Form_Make_Bill2

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
            Tax1.Image = My.Resources.OK
        Else
            Tax2Txt.Value = 0
            y = 0
            Tax2.Image = My.Resources._NOTHING
        End If

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

        If IsNothing(TransactionUID) Then
            CustOrderInfo = Nothing
            CustInfo = Nothing
            'CustOrderDetail = Nothing
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
            Dim TotalItem As Double = 0, TotalDisc As Double = 0
            If Not IsDBNull(TMPHeader.Tables(0).Rows(0).Item("ISBILLED")) Then

                Dim TMPCheck As FbDataReader
                Dim Count As Integer = 0
                Dim CountDump As Integer = 0
                Dim IsBilled As Integer = 0

                If Not IsDBNull(TMPHeader.Tables(0).Rows(0).Item("ISBILLED")) Then
                    IsBilled = TMPHeader.Tables(0).Rows(0).Item("ISBILLED")
                End If

                If Not IsDBNull(TMPHeader.Tables(0).Rows(0).Item("ISFISCAL")) Then
                    t = TMPHeader.Tables(0).Rows(0).Item("ISFISCAL")
                End If

                If GetServiceInfo(TMPHeader.Tables(0).Rows(0).Item("MBTRANSSERVICETYPEUID")) = "1" Then
                    TMPCheck = MyDatabase.MyReader("SELECT MBTRANSDTITEMSTAT FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "'")
                    While TMPCheck.Read
                        Count = Count + 1

                        If TMPCheck.Item("MBTRANSDTITEMSTAT") = "-1" Then
                            Count = Count - 1
                        End If

                        If TMPCheck.Item("MBTRANSDTITEMSTAT") = "1" Then
                            CountDump = CountDump + 1
                        End If
                    End While

                    If Count <> CountDump Then
                        ShowMessage(Me, "Maaf, anda tidak dapat membuat tagihan, karena ada order pesanan yang belum diproses !")
                        Me.Close()
                    End If
                End If

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
                                    Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MBTRANSSUBVAL=0, MBTRANSDISCPERC=0, MBTRANSDISCVAL=0, MBTRANSTAXVAL1=0, MBTRANSTAXVAL2=0, MBTRANSTOTVAL=0, MBTRANSSTAT=0, ISBILLED= 0 WHERE MBTRANSUID = '" & TransactionUID & "'")

                                    If PrefInfo.AllowModifyBillAfterPayment = True Then
                                        Call MyDatabase.MyAdapter("DELETE FROM PBTRANSDT WHERE PBTRANSUID IN (SELECT PBTRANSUID FROM PBTRANS WHERE PBTRANSMBTRANSUID='" & TransactionUID & "')")
                                        Call MyDatabase.MyAdapter("DELETE FROM PBTRANS WHERE PBTRANSMBTRANSUID='" & TransactionUID & "'")
                                    End If

                                    Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMDISCUID1=NULL, MBTRANSDTITEMDISCVAL1=0, MBTRANSDTITEMDISCUID2=NULL, MBTRANSDTITEMDISCVAL2=0 WHERE MBTRANSUID='" & TransactionUID & "'")

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
                            Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MBTRANSSUBVAL=0, MBTRANSDISCPERC=0, MBTRANSDISCVAL=0, MBTRANSTAXVAL1=0, MBTRANSTAXVAL2=0, MBTRANSTOTVAL=0,  MBTRANSSTAT=0,ISBILLED= 0 WHERE MBTRANSUID = '" & TransactionUID & "'")

                            If PrefInfo.AllowModifyBillAfterPayment = True Then
                                Call MyDatabase.MyAdapter("DELETE FROM PBTRANSDT WHERE PBTRANSUID IN (SELECT PBTRANSUID FROM PBTRANS WHERE PBTRANSMBTRANSUID='" & TransactionUID & "')")
                                Call MyDatabase.MyAdapter("DELETE FROM PBTRANS WHERE PBTRANSMBTRANSUID='" & TransactionUID & "'")
                            End If

                            Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMDISCUID1=NULL, MBTRANSDTITEMDISCVAL1=0, MBTRANSDTITEMDISCUID2=NULL, MBTRANSDTITEMDISCVAL2=0 WHERE MBTRANSUID='" & TransactionUID & "'")

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
                    ReservationUID = "NULL"
                    If Not IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")) Then
                        ReservationUID = TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")
                    End If

                    CustomerList.SelectedIndex = CustomerList.FindString(TMPHeader.Tables(0).Rows(0).Item("MBTRANSCUSTUID"), 0, 1)
                    CustName.Text = TMPHeader.Tables(0).Rows(0).Item("MBTRANSCUSTNAME")

                    SubTotalTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSSUBVAL"), 0)
                    DiscountTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSDISCVAL"), 0)

                    Tax1ValTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSTAXVAL1"), 0)
                    Tax2ValTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSTAXVAL2"), 0)

                    DPtxt.Value = "0" ' FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSDPVAL"), 0)
                    If IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSTOTVAL")) = False Then
                        TotalTxt.Value = FormatNumber(TMPHeader.Tables(0).Rows(0).Item("MBTRANSTOTVAL"), 0)
                    Else
                        TotalTxt.Value = FormatNumber(0, 0)
                    End If
                    Dim TMPItem As FbDataReader
                    Dim TItem As Double = 0

                    TMPItem = MyDatabase.MyReader("SELECT SUM(MBTRANSDTITEMQTY) AS TOTALITEM FROM MBTRANSDT WHERE MBTransDtItemStat <> -1 AND MBTRANSUID = '" & TransactionUID & "'")
                    While TMPItem.Read
                        If IsDBNull(TMPItem.Item("TOTALITEM")) = False Then
                            TItem = TMPItem.Item("TOTALITEM")
                        End If
                    End While
                    TotalItemTxt.Value = TItem

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
            If t = 1 Then
                Tax.Visible = True
            End If

            TransactionNo = TMPHeader.Tables(0).Rows(0).Item("MBTRANSNO")
            BillNo.Text = TransactionNo

            Visitor = TMPHeader.Tables(0).Rows(0).Item("MBTRANSPAXVAL")
            ServiceUID = TMPHeader.Tables(0).Rows(0).Item("MBTRANSSERVICETYPEUID")
            ReservationUID = "NULL"
            If Not IsDBNull(TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")) Then
                ReservationUID = TMPHeader.Tables(0).Rows(0).Item("MBTRANSRSVTRANSUID")
            End If

            DPValue = 0 'TMPHeader.Tables(0).Rows(0).Item("MBTransDPVal")
            'TMPDetail = MyDatabase.MyAdapter("SELECT * FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "' AND MBTRANSDTITEMSTAT > -1 ")

            TMPDetail = MyDatabase.MyAdapter("SELECT SUM(MBTransDtSubVal) AS TOTALPRICE, SUM(MBTransDtItemDiscVal1+MBTransDtItemDiscVal2) AS TOTALDISC, SUM(MBTransDtItemQty) AS TOTALITEM " & _
                                             "FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "' AND MBTransDtItemStat <> -1")

            'If TMPDetail.Tables(0).Rows.Count > 0 Then
            '    Dim looper As Integer
            '    For looper = 0 To TMPDetail.Tables(0).Rows.Count - 1
            '        TotalPrice = TotalPrice + TMPDetail.Tables(0).Rows(looper).Item("MBTRANSDTSUBVAL")
            '        TotalDisc = TotalDisc + CDec(TMPDetail.Tables(0).Rows(looper).Item("MBTRANSDTITEMDISCVAL1")) + CDec(TMPDetail.Tables(0).Rows(looper).Item("MBTRANSDTITEMDISCVAL2"))
            '        TotalItem = TotalItem + TMPDetail.Tables(0).Rows(looper).Item("MBTRANSDTITEMQTY")
            '    Next
            'End If

            If IsDBNull(TMPDetail.Tables(0).Rows(0).Item("TotalPrice")) = False Then
                SubTotalTxt.Value = FormatNumber(TMPDetail.Tables(0).Rows(0).Item("TotalPrice"), 0)
                TotalPrice = TMPDetail.Tables(0).Rows(0).Item("TotalPrice")
            Else
                SubTotalTxt.Value = 0
                TotalPrice = 0
            End If

            If IsDBNull(TMPDetail.Tables(0).Rows(0).Item("TotalDisc")) = False Then
                DiscountTxt.Value = FormatNumber(TMPDetail.Tables(0).Rows(0).Item("TotalDisc"), 0)
            Else
                DiscountTxt.Value = 0
            End If

            If IsDBNull(TMPDetail.Tables(0).Rows(0).Item("TotalItem")) = False Then
                TotalItemTxt.Value = FormatNumber(TMPDetail.Tables(0).Rows(0).Item("TotalItem"), 0)
            Else
                TotalItemTxt.Value = 0
            End If

            'SubTotalTxt.Value = FormatNumber(TotalPrice, 0)
            'DiscountTxt.Value = FormatNumber(TotalDisc, 0)
            'By Rudy
            Tax1ValTxt.Value = FormatNumber((((SubTotalTxt.Value - DiscountTxt.Value) * Tax1Txt.Value) / 100), 0)
            Tax2ValTxt.Value = FormatNumber((((SubTotalTxt.Value - DiscountTxt.Value + Tax1ValTxt.Value) * Tax2Txt.Value) / 100), 0)
            DPtxt.Value = "0" ' FormatNumber(DPValue, 0)
            'TotalItemTxt.Value = TotalItem
            'By Rudy
            TotalGlobal = SubTotalTxt.Value - DiscountTxt.Value + Tax1ValTxt.Value + Tax2ValTxt.Value - DPtxt.Value
            TotalTxt.Value = FormatNumber(TotalGlobal, 0)

            CustomerList.SelectedIndex = CustomerList.FindString(CustInfo(0), 0, 1)
            CustName.Text = CustOrderInfo(18)

            TMPDetail = Nothing

            Tax1Check.Enabled = True
            Tax2Check.Enabled = True
            BTNDiscount.Enabled = True

            Exit Sub
        End If
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

            TMPRecord = MyDatabase.MyReader("SELECT CUSTUID, CUSTNAME, CUSTADDR1, CUSTCATUID, (SELECT CUSTCATNAME FROM CUSTCAT WHERE CUSTCATUID = CUST.CUSTCATUID) FROM CUST ORDER BY CUSTNAME")

            CustomerList.ClearItems()
            CustomerList.HoldFields()
            While TMPRecord.Read()
                CustomerList.AddItem(TMPRecord.Item("CUSTNAME") & ";" & TMPRecord.Item("CUSTUID"))
            End While

        Catch ex As Exception

        End Try
        TMPRecord = Nothing
    End Sub

    Private Sub ReinitializePrice()
        Dim TotalGlobal As Double = 0
        'By Rudy 19 May 2010
        'Dim TotalDisc As Double = 0

        'For i As Integer = 1 To CustOrderDetail.Count
        'Dim TMPArray As New ArrayList
        'TMPArray = CustOrderDetail(i)
        'TotalDisc = TotalDisc + ((ReInitializeDisc(CustomerList.Columns(1).Text, TMPArray(2)) * TMPArray(9)) / 100)
        'Next

        'DiscountTxt.Value = FormatNumber(TotalDisc, 0)

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

        Query = "SELECT a.MBTRANSUID, a.MBTRANSNO, a.MBTRANSDATE, a.MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME," & _
                "a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID, a.MBTRANSRSVTRANSUID, a.MBTRANSSUBVAL," & _
                "MBTRANSPAXVAL+MBTRANSPAXVAL2+MBTRANSPAXVAL3+MBTRANSPAXVAL4+MBTRANSPAXVAL5+MBTRANSPAXVAL6 AS jmlPax," & _
                "a.MBTRANSDISCPERC, a.MBTRANSDISCVAL, a.MBTRANSTAXVAL1, a.MBTRANSTAXVAL2, a.MBTRANSDPVAL," & _
                "a.MBTRANSTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT,a.CREATEDUSER," & _
                "a.MODIFIEDUSER,a.MODIFIEDDATETIME, b.TABLELISTNAME," & _
                "(SELECT CUSTNO FROM CUST WHERE CUSTUID = a.MBTRANSCUSTUID) AS CUSTNO," & _
                "(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = a.MBTRANSSERVICETYPEUID ) AS SERVICENAME," & _
                "(SELECT SUM((M.MBTRANSDTITEMPRICE * M.MBTRANSDTITEMQTY)-M.MBTRANSDTITEMDISCVAL1-M.MBTRANSDTITEMDISCVAL2) FROM MBTRANSDT M LEFT OUTER JOIN INVEN I ON I.INVENUID=M.MBTRANSDTITEMUID LEFT OUTER JOIN INVENCAT IC ON IC.INVENCATUID=I.INVENCATUID WHERE M.MBTRANSDTITEMSTAT > -1 AND IC.INVENCATSUBCATEGORYID=1 AND M.MBTRANSUID=a.MBTRANSUID) AS SUBTOTALFOOD," & _
                "(SELECT SUM((M.MBTRANSDTITEMPRICE * M.MBTRANSDTITEMQTY)-M.MBTRANSDTITEMDISCVAL1-M.MBTRANSDTITEMDISCVAL2) FROM MBTRANSDT M LEFT OUTER JOIN INVEN I ON I.INVENUID=M.MBTRANSDTITEMUID LEFT OUTER JOIN INVENCAT IC ON IC.INVENCATUID=I.INVENCATUID WHERE M.MBTRANSDTITEMSTAT > -1 AND IC.INVENCATSUBCATEGORYID=2 AND M.MBTRANSUID=a.MBTRANSUID) AS SUBTOTALBEVERAGE," & _
                "(SELECT SUM((M.MBTRANSDTITEMPRICE * M.MBTRANSDTITEMQTY)-M.MBTRANSDTITEMDISCVAL1-M.MBTRANSDTITEMDISCVAL2) FROM MBTRANSDT M LEFT OUTER JOIN INVEN I ON I.INVENUID=M.MBTRANSDTITEMUID LEFT OUTER JOIN INVENCAT IC ON IC.INVENCATUID=I.INVENCATUID WHERE M.MBTRANSDTITEMSTAT > -1 AND IC.INVENCATSUBCATEGORYID=3 AND M.MBTRANSUID=a.MBTRANSUID) AS SUBTOTALMENUETC " & _
                "FROM MBTRANS a LEFT OUTER JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE a.MBTRANSUID = '" & TransactionUID & "'"

        OBJNew.Name = "Form_Print_Preview"
        OBJNew.RPTTitle = "Bill"
        If PrefInfo.printSize = "58" Then
            Dim myMakeBill As New Make_Bill258
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
        Else
            Dim myMakeBill As New Make_Bill2
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
        End If
    End Sub

#End Region

#Region "Form Control Function"

    Private Sub Form_Make_Bill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New System.Drawing.Point(MainPage.Location.X + 268, MainPage.Location.Y + 44 + 100)
        Me.Text = "Make Bill - Table " & Replace(SelectedTable.TableName, vbNewLine, " ")
        Me.Cursor = Cursors.Default
        Call BasicInitialize()
        'Call fillGridPromo()
    End Sub

    Private Sub fillGridPromo()
        Dim rs As FbDataReader
        Dim idCategoryCust As String
        Dim tglMB As Date
        Dim idHari As Integer

        Dim jamAkhirHitung As Date = Nothing
        Dim tmpJamAwal As Date = Nothing, tmpJamSampai As Date = Nothing
        Dim tmpHarga As Decimal = 0
        Dim tmpIsMin As Boolean = False
        Dim endHour As Date = Nothing, startHour As Date
        Dim tmpLama As String = ""
        Dim tmpTotFNB As Decimal = 0
        grdGetPromo.Rows.Count = 1
        rs = MyDatabase.MyReader("SELECT A.*,B.TABLELISTCATUID,(SELECT CS.CUSTCATUID FROM CUST CS WHERE CS.CUSTUID=A.MBTRANSCUSTUID) AS CUSTUID FROM MBTRANS A INNER JOIN TABLELIST B ON A.MBTRANSTABLELISTUID=B.TABLELISTUID WHERE A.MBTRANSUID='" & TransactionUID & "'")
        If rs.Read = False Then Exit Sub
        idCategoryCust = rs("CUSTUID")
        tglMB = Format(rs("MBTRANSDATE"), "yyyy/MM/dd")
        'idHari = CDate(rs("MBTRANSDATE")).DayOfWeek + 1
        If PrefInfo.RentDayType.ToString = "1" Then
            idHari = CInt(CDate(rs("MBTRANSDATE")).DayOfWeek + 1)
        ElseIf PrefInfo.RentDayType.ToString = "2" Then
            idHari = 8
        ElseIf PrefInfo.RentDayType.ToString = "3" Then
            idHari = 9
        End If
        tmpJamAwal = rs("MBTRANSSTARTTIME")
        startHour = rs("MBTRANSSTARTTIME")
        tmpTotFNB = IIf(IsDBNull(rs("MBTRANSFNBTOTVAL")) = True, 0, rs("MBTRANSFNBTOTVAL"))
        Dim lamaMenit As Integer = (CInt(rs("MBTRANSSTARTRENTHOURS")) * 60) + _
                            (CInt(rs("MBTRANSADDITIONALRENTHOURS")) * 60) + _
                            (CInt(rs("MBTRANSFREEHOURS")) * 60) + _
                            CInt(rs("MBTRANSLENGTHFREEMINUTES"))
        endHour = DateAdd(DateInterval.Minute, lamaMenit, startHour)
        rs.Close()
        rs = Nothing

        rs = MyDatabase.MyReader("SELECT B.*,C.* FROM CUSTCATDT A INNER JOIN PROMO B ON A.CUSTCATPROMOUID=B.PROMOUID INNER JOIN PROMODT C ON B.PROMOUID=C.PROMOUID WHERE A.CUSTCATUID='" & idCategoryCust & "' AND PROMOSTARTDATE<='" & tglMB & "' AND PROMOENDDATE>='" & tglMB & "' AND B.PROMOACTV='0' AND C.PROMODTDAYTYPE='" & idHari & "' AND PROMOOPT='0'")
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
            End While
            .Redraw = True
        End With
        rs = Nothing
        With grdPromo
            .Redraw = False
            tmpJamAwal = startHour
            While tmpJamAwal <= endHour
                For j As Integer = 1 To .Rows.Count - 1
                    If CDate(.Item(j, "jammulai")) <= tmpJamAwal And tmpJamAwal <= CDate(.Item(j, "jamsampai")) Then
                        Dim rowGrd As Integer = rowNumber(.Item(j, "id"))
                        If rowGrd = 0 Then
                            grdGetPromo.AddItem("")
                            grdGetPromo.Cols("namapromo").Item(grdGetPromo.Rows.Count - 1) = .Item(j, "id")
                            grdGetPromo.Cols("barcodesupport").Item(grdGetPromo.Rows.Count - 1) = .Item(j, "barcodesupport")
                            grdGetPromo.Cols("condition").Item(grdGetPromo.Rows.Count - 1) = .Item(j, "promocondition")
                            grdGetPromo.Cols("jumlah").Item(grdGetPromo.Rows.Count - 1) = CStr(SubTotalTxt.Text)
                            grdGetPromo.Cols("kelipatan").Item(grdGetPromo.Rows.Count - 1) = .Item(j, "kelipatan")
                        End If
                    End If
                Next
                tmpJamAwal = DateAdd(DateInterval.Hour, 1, tmpJamAwal)
            End While
            .Redraw = True
        End With
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

    Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancel.Click
        If Authorize = True Then
            Authorize = False
            UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
            Call MainPage.StatusBarInitialize()
        End If
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
        Dim TMPHeader As FbDataReader, modifiedTime As DateTime
        TMPHeader = MyDatabase.MyReader("SELECT * FROM MBTrans WHERE MBTransUID = '" & TransactionUID & "'")
        TMPHeader.Read()
        modifiedTime = TMPHeader.Item("MODIFIEDDATETIME")
        Dim idRoom As String = TMPHeader("MBTRANSTABLELISTUID")
        Dim custID As String = TMPHeader("MBTRANSCUSTUID")
        Dim nmCust As String = TMPHeader("MBTRANSCUSTNAME")
        Dim idDept As String = TMPHeader("MBTRANSDEPTUID")
        Dim idModul As String = TMPHeader("MBTRANSMODULETYPEID")
        Dim tglMBTrans As Date = TMPHeader("MBTRANSDATE")
        Dim idShift As String = TMPHeader("MBTRANSSHIFTNO")

        'MsgBox(FinalTime & " = " & ModifiedTime)

        If FinalTime <> ModifiedTime Then
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Maaf, anda tidak dapat menyimpan tagihan, karena tagihan ini telah dirubah oleh user lain !")
            Me.Close()
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

        If SubTotalTxt.Text = "0" Then
            Query = "UPDATE MBTRANS SET MBTRANSCUSTUID='" & CustomerList.Columns(1).Text & "', MBTRANSCUSTNAME ='" & ReplacePetik(CustName.Text) & "',MBTRANSSUBVAL ='0', MBTRANSDISCPERC ='0', MBTRANSDISCVAL ='0', MBTransTaxVal1 = '0', MBTransTaxVal2 = '0', MBTRANSFNBTOTVAL='0', MBTRANSSTAT='1', ISBILLED='1', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',ISFISCAL='" & t & "' WHERE MBTRANSUID = '" & TransactionUID & "'"
            Call MyDatabase.MyAdapter(Query)
            GoTo P
        End If

        Query = "UPDATE MBTRANS SET MBTRANSCUSTUID='" & CustomerList.Columns(1).Text & "', MBTRANSCUSTNAME ='" & ReplacePetik(CustName.Text) & "',MBTRANSSUBVAL ='" & CDbl(SubTotalTxt.Text) & "', MBTRANSDISCPERC ='" & Replace(Format((CDec(DiscountTxt.Text) * 100) / CDec(SubTotalTxt.Text), "#,##0.000"), ",", ".") & "', MBTRANSDISCVAL ='" & CDbl(DiscountTxt.Text) & "', MBTransTaxVal1 = '" & CDbl(Tax1ValTxt.Text) & "', MBTransTaxVal2 = '" & CDbl(Tax2ValTxt.Text) & "', MBTRANSFNBTOTVAL='" & CDbl(TotalTxt.Text) & "',MBTRANSTOTVAL=IIF(MBTRANSROOMTOTVAL IS NULL,0,MBTRANSROOMTOTVAL)+" & CDbl(TotalTxt.Text) & ", MBTRANSSTAT='1', ISBILLED='1', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',ISFISCAL='" & t & "' WHERE MBTRANSUID = '" & TransactionUID & "'"
        Call MyDatabase.MyAdapter(Query)

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


        Dim Lastdiskitem As Double = 0, Lastprice As Double = 0
        For i As Integer = 1 To TMPDiscListCollection.Count
            Dim TmpArray As New ArrayList
            TmpArray = TMPDiscListCollection(i)
            If i Mod 2 = 1 Then
                Lastprice = TmpArray(4) * TmpArray(7)
                Lastdiskitem = TmpArray(10) * TmpArray(11)
                Query = "UPDATE MBTRANSDT SET MBTRANSDTITEMDISCUID1 = '" & TmpArray(5) & "', MBTRANSDTITEMDISCVAL1='" & Replace(Format(CDec(TmpArray(10)) * CDec(TmpArray(11)), "###0"), ",", "") & "', MBTRANSDTSUBVAL ='" & Replace(FormatNumber(CDec(TmpArray(4)) * CDec(TmpArray(7)), 4), ",", "") & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSDTUID LIKE '" & TmpArray(1) & "'"
                Call MyDatabase.MyAdapter(Query)
            Else
                Query = "UPDATE MBTRANSDT SET MBTRANSDTITEMDISCUID2 = '" & TmpArray(5) & "', MBTRANSDTITEMDISCVAL2='" & Replace(Format(CDec(TmpArray(10)) * CDec(TmpArray(11)), "###0"), ",", "") & "', MBTRANSDTSUBVAL ='" & Lastprice & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSDTUID LIKE '" & TmpArray(1) & "'"
                Lastdiskitem = 0
                Call MyDatabase.MyAdapter(Query)
            End If
        Next

        'MyDatabase.MyAdapter("DELETE FROM SALESPROMOREG WHERE SALESPROMOREGTRANSUID='" & TransactionUID & "' AND SALESPROMOREGPROMOUID IN (SELECT PROMOUID FROM PROMO WHERE PROMOOPT='0')")
        'With grdGetPromo
        '    If .Rows.Count > 1 Then
        '        For i As Integer = 1 To .Rows.Count - 1
        '            If CStr(.Item(i, "kelipatan")) = "0" Then
        '                MyDatabase.MyAdapter("INSERT INTO SALESPROMOREG (SALESPROMOREGUID,SALESPROMOREGTRANSUID,SALESPROMOREGTRANSNO,SALESPROMOREGTRANSDATE,SALESPROMOREGTRANSDEPTUID,SALESPROMOREGTRANSMODULETYPEID,SALESPROMOREGTRANSSHIFTNO,SALESPROMOREGTRANSCUSTUID,SALESPROMOREGTRANSCUSTNAME,SALESPROMOREGTRANSTABLELISTUID,SALESPROMOREGPROMOUID,SALESPROMOREGPROMOQTY,SALESTRANSREGTRANSSTAT,SALESPROMOREGPROMOGENERATEDNO) VALUES (" & _
        '                                     "'" & AutoUID() & "','" & TransactionUID & "','" & TransactionNo & "','" & Format(tglMBTrans, "yyyy/MM/dd") & "','" & DeptInfo.DeptUID & "'," & idModul & ",'" & idShift & "','" & custID & "','" & nmCust & "','" & idRoom & "','" & .Item(i, "namapromo") & "',1,0,'" & Format(Now, "ssmmHHfff") & Format(Now, "yyyyMMdd") & Strings.Left(AutoUID(), 3) & "')")
        '            Else
        '                If CStr(.Item(i, "barcodesupport")) = "0" Then
        '                    MyDatabase.MyAdapter("INSERT INTO SALESPROMOREG (SALESPROMOREGUID,SALESPROMOREGTRANSUID,SALESPROMOREGTRANSNO,SALESPROMOREGTRANSDATE,SALESPROMOREGTRANSDEPTUID,SALESPROMOREGTRANSMODULETYPEID,SALESPROMOREGTRANSSHIFTNO,SALESPROMOREGTRANSCUSTUID,SALESPROMOREGTRANSCUSTNAME,SALESPROMOREGTRANSTABLELISTUID,SALESPROMOREGPROMOUID,SALESPROMOREGPROMOQTY,SALESPROMOREGTRANSSTAT,SALESPROMOREGPROMOGENERATEDNO) VALUES (" & _
        '                                     "'" & AutoUID() & "','" & TransactionUID & "','" & TransactionNo & "','" & Format(tglMBTrans, "yyyy/MM/dd") & "','" & DeptInfo.DeptUID & "'," & idModul & ",'" & idShift & "','" & custID & "','" & nmCust & "','" & idRoom & "','" & .Item(i, "namapromo") & "','" & Fix(CDec(.Item(i, "jumlah")) / CDec(.Item(i, "condition"))) & "',0,'" & Format(Now, "ssmmHHfff") & Format(Now, "yyyyMMdd") & Strings.Left(AutoUID(), 3) & "')")
        '                Else
        '                    For j As Integer = 1 To Fix(CDec(.Item(i, "jumlah")) / CDec(.Item(i, "condition")))
        '                        MyDatabase.MyAdapter("INSERT INTO SALESPROMOREG (SALESPROMOREGUID,SALESPROMOREGTRANSUID,SALESPROMOREGTRANSNO,SALESPROMOREGTRANSDATE,SALESPROMOREGTRANSDEPTUID,SALESPROMOREGTRANSMODULETYPEID,SALESPROMOREGTRANSSHIFTNO,SALESPROMOREGTRANSCUSTUID,SALESPROMOREGTRANSCUSTNAME,SALESPROMOREGTRANSTABLELISTUID,SALESPROMOREGPROMOUID,SALESPROMOREGPROMOQTY,SALESTRANSREGTRANSSTAT,SALESPROMOREGPROMOGENERATEDNO) VALUES (" & _
        '                                         "'" & AutoUID() & "','" & TransactionUID & "','" & TransactionNo & "','" & Format(tglMBTrans, "yyyy/MM/dd") & "','" & DeptInfo.DeptUID & "'," & idModul & ",'" & idShift & "','" & custID & "','" & nmCust & "','" & idRoom & "','" & .Item(i, "namapromo") & "','1',0,'" & Format(Now, "ssmmHHfff") & Format(Now, "yyyyMMdd") & Strings.Left(AutoUID(), 3) & "')")
        '                    Next
        '                End If
        '            End If

        '        Next
        '    End If
        'End With

P:
        SaveStatus = True
        Call MainPage.TableClickInfo(selectedObject, myEvent)
        For i As Integer = 1 To CInt(PrefInfo.pubJumlahPrintOutBill)
            Call ShowPrintPreview(True)
        Next
        Me.Cursor = Cursors.Default

        Me.Close()

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
            Tax1Txt.Value = PrefInfo.Tax1Rate
        Else
            Tax1Txt.Value = 0
        End If
        Call ReinitializePrice()
    End Sub

    Private Sub Tax2Check_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Tax2Check.CheckedChanged
        If Tax2Check.Checked = True Then
            Tax2Txt.Value = PrefInfo.Tax2Rate
        Else
            Tax2Txt.Value = 0
        End If
        Call ReinitializePrice()
    End Sub

    Private Sub Tax1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Tax1.MouseDown

        'Exit Sub 'Andy 28 Des 2011 'Andy 8 Okt 2011

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
        '            Tax.Visible = True
        '        Else
        '            ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
        '            t = 0
        '            Tax.Visible = False
        '        End If
        '    Else
        '        t = 0
        '        Tax.Visible = False
        '    End If
        'End If
    End Sub

#End Region


End Class