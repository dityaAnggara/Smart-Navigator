Imports FirebirdSql.Data.FirebirdClient

Public Class Form_Split_Bill

#Region "Variable Reference"

    Dim TransactionUID As String = GetTransactionCode(SelectedTable.TableUID)
    Dim IndexCust As Integer = 0
    Dim UserPermition As New UserPermitionLib
    'Dim ListCollection As New Collection
    Dim FormStatus As FormStatusLib

    Dim CustomerType As String
    Dim ServiceType As String
#End Region

#Region "Initialize & Object Function"

    Private Sub BasicInitialize()
        Call TableInitialize()
        Call InfoInitialize()
        Call GetItemInitialize()
        'Call CustomerTypeInitialize()
        Call CustomerInitialize()

        'ListCollection = DBListCollection("SELECT * FROM MBTRANS WHERE MBTRANSUID = '" & TransactionUID & "'")
        'FormStatus = OBJControlInitialize(ListCollection)
        'Call OBJControlHandler(Me, FormStatus)
        'Call CheckPermission(UserInformation.UserTypeUID, IIf(ListCollection.Count > 0, True, False))

        Call CheckPermission(UserInformation.UserTypeUID, True)

    End Sub
    Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)

        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2210'")
        While TMPRecord.Read()
            UserPermition.PermitionInitialize(TMPRecord.Item("USERCATCREATEACCESS"), TMPRecord.Item("USERCATEDITACCESS"), TMPRecord.Item("USERCATDELETEACCESS"), TMPRecord.Item("USERCATREADACCESS"), TMPRecord.Item("USERCATPRINTACCESS"))
        End While

        With UserPermition
            If Not .ReadAccess Then
                ShowMessage(Me, "Maaf, anda tidak mempunyai akses terhadap form ini !" & vbNewLine & "Silakan hubungi administrator anda.")
                Me.Close()
            End If

            If Not .CreateAccess Then
                BTNSave.Enabled = False
                BTNSave.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Silver
            Else
                BTNSave.Enabled = True
                BTNSave.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
            End If

            If Not .EditAccess Then
                BTNSave.Enabled = False
                BTNSave.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Silver
            Else
                BTNSave.Enabled = True
                BTNSave.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
            End If

            If Not .CreateAccess And Not .EditAccess Then
                FormStatus = FormStatusLib.OpenAndLock
                Call OBJControlHandler(Me, FormStatus)
            End If
        End With

    End Sub
    Private Sub TableInitialize()
        Dim TMPRecord As FbDataReader
        Try
            TMPRecord = MyDatabase.MyReader("SELECT * FROM TABLELIST T LEFT OUTER JOIN FLOORNO F ON T.FLOORNOUID=F.FLOORNOUID WHERE F.FLOORDEPTUID ='" & DeptInfo.DeptUID & "' AND (TABLELISTACTV IS NULL OR TABLELISTACTV = 0 ) AND TABLEMBTRANSUID IS NULL ORDER BY TABLELISTNAME")

            TableCombo.ClearItems()
            TableCombo.HoldFields()
            While TMPRecord.Read()
                TableCombo.AddItem(TMPRecord.Item("TABLELISTNAME") & ";" & TMPRecord.Item("TABLELISTUID"))
            End While
            TableCombo.SelectedIndex = TableCombo.FindString(SelectedTable.TableUID, 0, 1)
            TableCombo.SelectedIndex = 0
        Catch ex As Exception
        End Try
        TMPRecord = Nothing
    End Sub
    Private Sub InfoInitialize()
        Dim TMPRecord As FbDataReader
        Try
            TMPRecord = MyDatabase.MyReader("SELECT * FROM MBTRANS WHERE MBTRANSUID = '" & TransactionUID & "'")
            TMPRecord.Read()

            'TableName2Txt.Text = TableCombo.GetItemText(TableCombo.SelectedIndex, "Table Name")
            PAX2txt.Text = "1"

            TableNameTxt.Text = SelectedTable.TableName
            If Not IsDBNull(TMPRecord.Item("MBTRANSUID")) Then
                Dim TMPArray As New ArrayList
                TMPArray = GetCustInfo(TMPRecord.Item("MBTRANSCUSTUID"))

                PAXTxt.Text = TMPRecord.Item("MBTRANSPAXVAL")
                CustType.Text = TMPArray(4)
                CustName.Text = TMPRecord.Item("MBTRANSCUSTNAME")

                ServiceType = TMPRecord.Item("MBTRANSSERVICETYPEUID")
                'CustomerType = TMPRecord.Item("MBTRANSCUSTUID")
            End If

        Catch ex As Exception

        End Try
        TMPRecord = Nothing
    End Sub

    Private Sub GetItemInitialize()
        Dim TMPRecord As FbDataReader
        Dim I As Integer = 0
        Try
            TMPRecord = MyDatabase.MyReader("SELECT A.*, B.INVENMEASUNITDESC, B.INVENLEVEL FROM MBTRANSDT A, INVEN B  WHERE A.MBTRANSDTITEMUID=B.INVENUID AND A.MBTRANSUID = '" & TransactionUID & "' AND A.MBTRANSDTITEMSTAT > -1  ORDER BY A.MBTRANSDTITEMNAME")
            With TableList
                .Redraw = False
                .Rows.Count = 1
                While TMPRecord.Read
                    I = I + 1
                    TableList.AddItem(TMPRecord.Item("MBTRANSDTUID") & vbTab & TMPRecord.Item("MBTRANSDTITEMQTY") & vbTab & TMPRecord.Item("MBTRANSDTITEMNAME") & vbTab & TMPRecord.Item("MBTRANSDTSUBVAL") & vbTab & TMPRecord.Item("MBTRANSDTITEMUID") & vbTab & TMPRecord.Item("MBTRANSDTITEMSTAT") & vbTab & TMPRecord.Item("MBTRANSDTITEMNOTE") & vbTab & TMPRecord.Item("MBTRANSDTISTAKEAWAY") & vbTab & vbTab & TMPRecord.Item("INVENMEASUNITDESC") & vbTab & TMPRecord.Item("INVENLEVEL"))
                    .Rows(I).Height = 45
                End While
                .Redraw = True
            End With
        Catch ex As Exception
            TableList.Redraw = True
        End Try
    End Sub

    'Private Sub CustomerTypeInitialize()
    '    Dim TMPRecord As FbDataReader
    '    Try
    '        TMPRecord = MyDatabase.MyReader("SELECT * FROM CUSTCAT ORDER BY CUSTCATNAME")

    '        CustomerType1.HoldFields() : CustomerType1.AddItem("None;")
    '        CustomerType2.HoldFields() : CustomerType2.AddItem("None;")
    '        While TMPRecord.Read()
    '            CustomerType1.AddItem(TMPRecord.Item("CUSTCATNAME") & ";" & TMPRecord.Item("CUSTCATUID"))
    '            CustomerType2.AddItem(TMPRecord.Item("CUSTCATNAME") & ";" & TMPRecord.Item("CUSTCATUID"))
    '        End While
    '        CustomerType1.SelectedIndex = 1 : CustomerType2.SelectedIndex = 1

    '    Catch ex As Exception

    '    End Try
    '    TMPRecord = Nothing
    'End Sub

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

    Public Sub BringCustInfo(ByVal CustUID As String)
        Dim CurCust As Integer = CustomerList.FindString(CustUID, 0, 1)
        CustomerList.SelectedIndex = CurCust
    End Sub

    Private Sub CustomerInitialize(ByVal OBJCombo As Object, Optional ByVal Search As String = Nothing)
        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT CUSTUID, CUSTNAME, CUSTADDR1, CUSTCATUID, (SELECT CUSTCATNAME FROM CUSTCAT WHERE CUSTCATUID = CUST.CUSTCATUID) FROM CUST WHERE CUSTCATUID = '" & Search & "' ORDER BY CUSTNAME")

        OBJCombo.ClearItems()
        OBJCombo.HoldFields()
        While TMPRecord.Read()
            OBJCombo.AddItem(TMPRecord.Item("CUSTNAME") & ";" & TMPRecord.Item("CUSTUID"))
        End While

        TMPRecord = Nothing
    End Sub

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

    'Public Sub BringCustInfo(ByVal CustCatUID As String, ByVal CustUID As String)
    '    Select Case IndexCust
    '        Case 0
    '            Dim CurType As Integer = CustomerType1.FindString(CustCatUID, 0, 1)
    '            CustomerType1.SelectedIndex = CurType

    '            CustomerList1.Enabled = True
    '            Call CustomerInitialize(CustomerList1, CustCatUID)
    '            Dim CurCust As Integer = CustomerList1.FindString(CustUID, 0, 1)
    '            CustomerList1.SelectedIndex = CurCust
    '        Case 1
    '            Dim CurType As Integer = CustomerType2.FindString(CustCatUID, 0, 1)
    '            CustomerType2.SelectedIndex = CurType

    '            CustomerList2.Enabled = True
    '            Call CustomerInitialize(CustomerList2, CustCatUID)
    '            Dim CurCust As Integer = CustomerList2.FindString(CustUID, 0, 1)
    '            CustomerList2.SelectedIndex = CurCust
    '    End Select
    'End Sub

#End Region

#Region "Form Control Function"

    Private Sub Form_Split_Bill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 44)
        Me.Cursor = Cursors.Default
        TableList.Styles("Normal").WordWrap = True
        Spliter1.Styles("Normal").WordWrap = True
        Call BasicInitialize()
    End Sub

    'Private Sub CustomerType_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles CustomerType1.Change, CustomerType2.Change
    '    Select Case sender.name
    '        Case "CustomerType1"
    '            If CustomerType1.SelectedIndex <= 0 Then
    '                CustomerList1.Enabled = False
    '                CustomerList1.ClearItems()
    '            Else
    '                CustomerList1.Enabled = True
    '                Call CustomerInitialize(CustomerList1, CustomerType1.Columns(1).Text)
    '            End If
    '        Case "CustomerType2"
    '            If CustomerType2.SelectedIndex <= 0 Then
    '                CustomerList2.Enabled = False
    '                CustomerList2.ClearItems()
    '            Else
    '                CustomerList2.Enabled = True
    '                Call CustomerInitialize(CustomerList2, CustomerType2.Columns(1).Text)
    '            End If
    '    End Select
    'End Sub

    Private Sub BTNMove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableList.DoubleClick, BTNMoveTo1.Click
        Dim MoveQuantity As Decimal = 0
        Dim Price As Decimal = 0

        With TableList
            If .Row > 0 Then
                Price = CDec(.Item(.Row, 3)) / CDec(.Item(.Row, 1))

                If .Rows(.Row).Visible Then

                    If PrefInfo.UseKitchenPrintOut = "0" Then
                        If .Item(.Row, 1) = 1 Or CStr(.Item(.Row, 10)) = "3" Then
                            GoTo Move
                        End If
                    ElseIf PrefInfo.UseKitchenPrintOut = "1" Then
                        If .Item(.Row, 1) = 1 Then
                            GoTo Move
                        End If
                    End If

                    Dim OBJNew As New Form_Input_Box
                    OBJNew.Name = "Form_Input_Box"
                    OBJNew.Quantity = .Item(.Row, 1)
                    OBJNew.ParentOBJForm = Me
                    OBJNew.ShowDialog()

                    If OBJNew.Cancel = False Then
                        MoveQuantity = OBJNew.TotalMove.Text
                    Else
                        Exit Sub
                    End If

                    If MoveQuantity = .Item(.Row, 1) Then
Move:
                        For i As Integer = 0 To Spliter1.Rows.Count - 1
                            If .Item(.Row, 0) = Spliter1.Item(i, 0) Then
                                Spliter1.Item(i, 1) = FormatNumber(CDec(Spliter1.Item(i, 1)) + CDec(.Item(.Row, 1)), IIf(Fix(CDec(Spliter1.Item(i, 1)) + CDec(.Item(.Row, 1))) = CDec(Spliter1.Item(i, 1)) + CDec(.Item(.Row, 1)), 0, 1))
                                Spliter1.Item(i, 3) = CDec(Spliter1.Item(i, 1)) * Price
                                .RemoveItem(.Row)
                                Exit Sub
                            End If
                        Next

                        Spliter1.AddItem(.Item(.Row, 0) & vbTab & .Item(.Row, 1) & vbTab & .Item(.Row, 2) & vbTab & .Item(.Row, 3) & vbTab & .Item(.Row, 4) & vbTab & .Item(.Row, 5) & vbTab & .Item(.Row, 6) & vbTab & .Item(.Row, 7) & vbTab & vbTab & .Item(.Row, 9) & vbTab & .Item(.Row, 10))
                        Spliter1.Rows(Spliter1.Rows.Count - 1).Height = 45
                        .RemoveItem(.Row)
                    Else
                        For i As Integer = 0 To Spliter1.Rows.Count - 1
                            If .Item(.Row, 0) = Spliter1.Item(i, 0) Then
                                Spliter1.Item(i, 1) = FormatNumber(CDec(Spliter1.Item(i, 1)) + MoveQuantity, IIf(Fix(CDec(Spliter1.Item(i, 1)) + MoveQuantity) = CDec(Spliter1.Item(i, 1)) + MoveQuantity, 0, 1))
                                Spliter1.Item(i, 3) = CDec(Spliter1.Item(i, 1)) * Price

                                .Item(.Row, 1) = FormatNumber(CDec(.Item(.Row, 1)) - MoveQuantity, IIf(Fix(CDec(.Item(.Row, 1)) - MoveQuantity) = CDec(.Item(.Row, 1)) - MoveQuantity, 0, 1))
                                .Item(.Row, 3) = CDec(.Item(.Row, 1)) * Price
                                Exit Sub
                            End If
                        Next

                        Spliter1.AddItem(.Item(.Row, 0) & vbTab & MoveQuantity & vbTab & .Item(.Row, 2) & vbTab & MoveQuantity * Price & vbTab & .Item(.Row, 4) & vbTab & .Item(.Row, 5) & vbTab & .Item(.Row, 6) & vbTab & .Item(.Row, 7) & vbTab & vbTab & .Item(.Row, 9) & vbTab & .Item(.Row, 10))
                        Spliter1.Rows(Spliter1.Rows.Count - 1).Height = 45

                        .Item(.Row, 1) = FormatNumber(CDec(.Item(.Row, 1)) - MoveQuantity, IIf(Fix(CDec(.Item(.Row, 1)) - MoveQuantity) = CDec(.Item(.Row, 1)) - MoveQuantity, 0, 1))
                        .Item(.Row, 3) = .Item(.Row, 1) * Price
                    End If
                End If
            End If
        End With
        'With TableList
        '    If .Row >= 0 Then
        '        If .Rows(.Row).Visible Then
        '            Spliter1.AddItem(.Item(.Row, 0) & vbTab & .Item(.Row, 1) & vbTab & .Item(.Row, 2) & vbTab & .Item(.Row, 3))
        '            Spliter1.Rows(Spliter1.Rows.Count - 1).Height = 45
        '            .Rows(.Row).Visible = False
        '        End If
        '    End If
        'End With
    End Sub

    Private Sub BTNRemoveCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Spliter1.DoubleClick, BTNCancel1.Click
        With Spliter1
            If .Row > 0 Then
                For i As Integer = 0 To TableList.Rows.Count - 1
                    If .Item(.Row, 0) = TableList.Item(i, 0) Then
                        TableList.Item(i, 1) = FormatNumber(CDec(TableList.Item(i, 1)) + CDec(.Item(.Row, 1)), IIf(Fix(CDec(TableList.Item(i, 1)) + CDec(.Item(.Row, 1))) = CDec(TableList.Item(i, 1)) + CDec(.Item(.Row, 1)), 0, 1))
                        TableList.Item(i, 3) = FormatNumber(CDec(TableList.Item(i, 3)) + CDec(.Item(.Row, 3)), IIf(Fix(CDec(TableList.Item(i, 3)) + CDec(.Item(.Row, 3))) = CDec(TableList.Item(i, 3)) + CDec(.Item(.Row, 3)), 0, 1))
                        .RemoveItem(.Row)
                        Exit Sub
                    End If
                Next

                TableList.AddItem(.Item(.Row, 0) & vbTab & .Item(.Row, 1) & vbTab & .Item(.Row, 2) & vbTab & .Item(.Row, 3) & vbTab & .Item(.Row, 4) & vbTab & .Item(.Row, 5) & vbTab & .Item(.Row, 6) & vbTab & .Item(.Row, 7) & vbTab & vbTab & .Item(.Row, 9) & vbTab & .Item(.Row, 10))
                TableList.Rows(TableList.Rows.Count - 1).Height = 45
                .RemoveItem(.Row)
            End If
        End With
        'With Spliter1
        '    If .Row >= 0 Then
        '        Dim CurRow As Integer = TableList.FindRow(.Item(.Row, 0).ToString, 1, 0, True)
        '        TableList.Rows(CurRow).Visible = True
        '        .RemoveItem(.Row)
        '    End If
        'End With
    End Sub

    Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click

        Me.Cursor = Cursors.WaitCursor
        Dim TMPHeader As FbDataReader
        TMPHeader = MyDatabase.MyReader("SELECT * FROM MBTrans WHERE MBTransUID = '" & TransactionUID & "'")
        TMPHeader.Read()
        If Not IsDBNull(TMPHeader.Item("ISBILLED")) Then
            If TMPHeader.Item("ISBILLED") = 1 Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Maaf, transaksi pemisahan bill tagihan tidak dapat dilakukan, karena meja '" & SelectedTable.TableName & "' sudah dibuatkan bill tagihan !")
                Exit Sub
            End If
        End If

        Dim TMPCheckTable As FbDataReader
        TMPCheckTable = MyDatabase.MyReader("SELECT * FROM  TABLELIST WHERE TABLELISTUID = '" & SelectedTable.TableUID & "'")
        While TMPCheckTable.Read
            If IsDBNull(TMPCheckTable.Item("TABLEMBTRANSUID")) Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Maaf, transaksi pemisahan bill tagihan tidak dapat dilakukan, karena status meja '" & SelectedTable.TableName & "' adalah kosong (tidak terisi customer) !")
                Exit Sub
            End If
        End While

        Dim TMPCheck As FbDataReader
        TMPCheck = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLELISTUID = '" & TableCombo.Columns(1).Text & "'")
        While TMPCheck.Read
            If Not IsDBNull(TMPCheck.Item("TABLEMBTRANSUID")) Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Maaf, transaksi pemisahan bill tagihan tidak dapat dilakukan, karena status meja '" & TableCombo.Columns(0).Text & "' tidak kosong (sudah terisi customer) !")
                Dim TMPCombo As FbDataReader
                TMPCombo = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLEMBTRANSUID IS NULL ORDER BY TABLELISTNAME")

                TableCombo.ClearItems()
                TableCombo.HoldFields()

                While TMPCombo.Read()
                    TableCombo.AddItem(TMPCombo.Item("TABLELISTNAME") & ";" & TMPCombo.Item("TABLELISTUID"))
                End While
                TMPCombo = Nothing

                Exit Sub
            End If
        End While

        If TableCombo.SelectedIndex < 0 Then
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Silakan pilih meja tujuan terlebih dahulu !")
            TableCombo.Focus()
            Exit Sub
        End If

        If CustomerList.SelectedIndex < 0 Then
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Silakan pilih customer terlebih dahulu !")
            CustomerList.Focus()
            Exit Sub
        End If

        If CustNametxt.Text = "" Then
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Silakan isikan nama customer terlebih dahulu !")
            CustNametxt.Focus()
            Exit Sub
        End If

        If Spliter1.Rows.Count < 2 Then
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Silakan pilih order pesanan yang akan dipisahkan !")
            Exit Sub
        End If

        Dim Query As String = Nothing
        Dim LastID = AutoUID()
        Dim TransactionNo As String

        TransactionNo = AutoIDNumber("2202", "MBTRANS", "MBTRANSNO")

        Query = "UPDATE MBTRANS SET MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSUID LIKE '" & TransactionUID & "'"
        Call MyDatabase.MyAdapter(Query)

        Query = "INSERT INTO MBTRANS(MBTRANSUID,MBTRANSNO,MBTRANSDATE,MBTRANSDEPTUID,MBTRANSMODULETYPEID,MBTRANSPAXVAL,MBTRANSCUSTUID,MBTRANSCUSTNAME,MBTRANSTABLELISTUID,MBTRANSSERVICETYPEUID,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,ISBILLED,ISFISCAL) " & _
            "VALUES('" & LastID & "','" & TransactionNo & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2202','" & PAX2txt.Text & "','" & CustomerList.GetItemText(CustomerList.SelectedIndex, 1) & "','" & ReplacePetik(CustNametxt.Text) & "','" & TableCombo.Columns(1).Text & "','" & ServiceType & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',0,0)"
        Call MyDatabase.MyAdapter(Query)

        Query = "INSERT INTO MBTRANSTABLELIST(MBTRANSDTUID,MBTRANSTABLELISTUID,MBTRANSUID) VALUES('" & AutoUID() & "','" & TableCombo.GetItemText(TableCombo.SelectedIndex, 1) & "','" & LastID & "')"
        Call MyDatabase.MyAdapter(Query)

        Query = "UPDATE TABLELIST SET TABLEMBTRANSUID = '" & LastID & "' WHERE TABLELISTUID LIKE '" & TableCombo.GetItemText(TableCombo.SelectedIndex, 1) & "'"
        Call MyDatabase.MyAdapter(Query)

        'If Spliter1.Rows.Count > 1 Then
        '    With Spliter1
        '        For i As Integer = 1 To .Rows.Count - 1
        '            Query = "UPDATE MBTRANSDT SET MBTRANSUID ='" & LastID & "', MBTRANSDTITEMCANCELLEDNOTE='Split Bill " & TransactionUID & "' WHERE MBTRANSDTUID LIKE '" & .Item(i, 0) & "'"
        '            Call MyDatabase.MyAdapter(Query)
        '        Next
        '    End With
        '    Call MainPage.TableClickInfo(selectedObject, myEvent)
        '    Me.Close()
        'Else
        '    ShowMessage(Me, "Please select the item !")
        'End If

        If Spliter1.Rows.Count > 1 Then
            If TableList.Rows.Count > 1 Then
                Query = "UPDATE MBTRANS SET MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSUID LIKE '" & TransactionUID & "'"
                Call MyDatabase.MyAdapter(Query)

                For a As Integer = 1 To TableList.Rows.Count - 1

                    Query = "UPDATE MBTRANSDT SET MBTRANSDTITEMQTY ='" & TableList.Item(a, 1) & "',MBTRANSDTSUBVAL='" & TableList.Item(a, 3) & "',MODIFIEDUSER='" & UserInformation.UserName & "',MODIFIEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',DELETEDUSER='" & UserInformation.UserName & "',DELETEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "' WHERE MBTRANSDTUID LIKE '" & TableList.Item(a, 0) & "'"
                    Call MyDatabase.MyAdapter(Query)

                    'Call DeleteItemMB(TransactionUID)
                Next

                For b As Integer = 1 To Spliter1.Rows.Count - 1
                    'Dim ItemRecord As FbDataReader
                    Dim DetailUID As String = AutoUID()

                    'Query = "SELECT * FROM INVEN WHERE INVENUID = '" & Spliter1.Item(b, 4) & "'"
                    'ItemRecord = MyDatabase.MyReader(Query)
                    'ItemRecord.Read()

                    If PrefInfo.UseKitchenPrintOut = "0" Then
                        If CStr(Spliter1.Item(b, 10)) = "3" Then
                            Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSUID='" & LastID & "' WHERE MBTRANSDTUID = '" & Spliter1.Item(b, 0) & "'")
                        Else
                            If ItemExistInGrid(Spliter1.Item(b, 0)) = True Then
                                Query = "INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMSTAT,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT) " & _
                                        "VALUES('" & DetailUID & "','" & LastID & "','" & Spliter1.Item(b, 4) & "','" & ReplacePetik(Spliter1.Item(b, 2)) & "','" & ReplacePetik(Spliter1.Item(b, 9)) & "','" & Spliter1.Item(b, 1) & "','" & Spliter1.Item(b, 3) / Spliter1.Item(b, 1) & "','" & Spliter1.Item(b, 3) & "','" & Spliter1.Item(b, 5) & "','" & ReplacePetik(Spliter1.Item(b, 6)) & "','" & Spliter1.Item(b, 7) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1)"
                            Else
                                Query = "UPDATE MBTRANSDT SET MBTRANSUID='" & LastID & "',MBTRANSDTITEMUID='" & Spliter1.Item(b, 4) & "',MBTRANSDTITEMNAME='" & ReplacePetik(Spliter1.Item(b, 2)) & "',MBTRANSDTITEMMEASUNITDESC='" & ReplacePetik(Spliter1.Item(b, 9)) & "',MBTRANSDTITEMQTY='" & Replace(Spliter1.Item(b, 1), ",", ".") & "'," & _
                                    "MBTRANSDTITEMPRICE='" & Spliter1.Item(b, 3) / Spliter1.Item(b, 1) & "',MBTRANSDTSUBVAL='" & Spliter1.Item(b, 3) & "',MBTRANSDTITEMSTAT='" & Spliter1.Item(b, 5) & "',MBTRANSDTITEMNOTE='" & ReplacePetik(Spliter1.Item(b, 6)) & "',MBTRANSDTISTAKEAWAY='" & Spliter1.Item(b, 7) & "',MODIFIEDUSER='" & UserInformation.UserName & "',MODIFIEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',PRINT='1' WHERE MBTRANSDTUID='" & Spliter1.Item(b, 0) & "'"
                            End If
                            Call MyDatabase.MyAdapter(Query)
                        End If
                    ElseIf PrefInfo.UseKitchenPrintOut = "1" Then
                        If ItemExistInGrid(Spliter1.Item(b, 0)) = True Then
                            Query = "INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMSTAT,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT) " & _
                                    "VALUES('" & DetailUID & "','" & LastID & "','" & Spliter1.Item(b, 4) & "','" & ReplacePetik(Spliter1.Item(b, 2)) & "','" & ReplacePetik(Spliter1.Item(b, 9)) & "','" & Spliter1.Item(b, 1) & "','" & Spliter1.Item(b, 3) / Spliter1.Item(b, 1) & "','" & Spliter1.Item(b, 3) & "','" & Spliter1.Item(b, 5) & "','" & ReplacePetik(Spliter1.Item(b, 6)) & "','" & Spliter1.Item(b, 7) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1)"
                        Else
                            Query = "UPDATE MBTRANSDT SET MBTRANSUID='" & LastID & "',MBTRANSDTITEMUID='" & Spliter1.Item(b, 4) & "',MBTRANSDTITEMNAME='" & ReplacePetik(Spliter1.Item(b, 2)) & "',MBTRANSDTITEMMEASUNITDESC='" & ReplacePetik(Spliter1.Item(b, 9)) & "',MBTRANSDTITEMQTY='" & Replace(Spliter1.Item(b, 1), ",", ".") & "'," & _
                                    "MBTRANSDTITEMPRICE='" & Spliter1.Item(b, 3) / Spliter1.Item(b, 1) & "',MBTRANSDTSUBVAL='" & Spliter1.Item(b, 3) & "',MBTRANSDTITEMSTAT='" & Spliter1.Item(b, 5) & "',MBTRANSDTITEMNOTE='" & ReplacePetik(Spliter1.Item(b, 6)) & "',MBTRANSDTISTAKEAWAY='" & Spliter1.Item(b, 7) & "',MODIFIEDUSER='" & UserInformation.UserName & "',MODIFIEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',PRINT='1' WHERE MBTRANSDTUID='" & Spliter1.Item(b, 0) & "'"
                        End If
                        Call MyDatabase.MyAdapter(Query)
                    End If

                        'Anjo : 31 okt - Detail is done via trigger
                        'If ItemRecord("INVENLEVEL") = 3 Then
                        '    Dim ItemDetail As FbDataReader
                        '    ItemDetail = MyDatabase.MyReader("SELECT DT.*,I.INVENNAME  FROM INVENDT DT LEFT OUTER JOIN INVEN I ON DT.INVENDTITEMUID = I.INVENUID WHERE DT.INVENUID='" & Spliter1.Item(b, 4) & "'")
                        '    While ItemDetail.Read
                        '        For a As Integer = 1 To TableList.Rows.Count - 1
                        '            Query = "UPDATE MBTRANSDTDETAIL SET MBTRANSDTITEMQTY ='" & ItemDetail("ITEMQTY") * TableList.Item(a, 1) & "',MBTRANSDTSUBVAL='" & TableList.Item(a, 3) & "' WHERE MBTRANSDTUID LIKE '" & TableList.Item(a, 0) & "'"
                        '            Call MyDatabase.MyAdapter(Query)
                        '        Next

                        '        Query = "INSERT INTO MBTRANSDTDETAIL (MBTRANSDTDETAILUID,MBTRANSDTUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTITEMSTAT,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME) " & _
                        '        "VALUES('" & AutoUID() & "','" & DetailUID & "','" & ItemDetail("INVENDTITEMUID") & "','" & ReplacePetik(ItemDetail("INVENNAME")) & "','" & ReplacePetik(ItemDetail("ITEMMEASUNITDESC")) & "','" & ItemDetail("ITEMQTY") * Spliter1.Item(b, 1) & "','" & Spliter1.Item(b, 3) / Spliter1.Item(b, 1) & "','" & Spliter1.Item(b, 3) & "','','" & Spliter1.Item(b, 5) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "')"
                        '        Call MyDatabase.MyAdapter(Query)
                        '    End While
                        'End If
                        'ItemRecord = Nothing
                Next
            Else
                For a As Integer = 1 To Spliter1.Rows.Count - 1
                    Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSUID='" & LastID & "' WHERE MBTRANSDTUID = '" & Spliter1.Item(a, 0) & "'")
                Next
            End If

            'Call MainPage.TableReset(True)
            'Call MainPage.TableSelected(selectedObject, myEvent)
            Call MainPage.TableResetAndSelect(selectedObject, myEvent, True)
            Me.Cursor = Cursors.Default
            Me.Close()
        Else
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Silakan pilih order pesanan yang akan dipisahkan !")
        End If

    End Sub

    Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancel.Click
        Call MainPage.TableClickInfo(selectedObject, myEvent)
        Me.Close()
    End Sub

    Private Sub DeleteItemMB(ByVal InputMBTransUID As String)
        Dim RecordItem As FbDataReader
        Dim ArrayItem() As String
        Dim Delete As String = ""
        Const MY_DELIMITER = "~%^%$#$~"

        'Temukan Item Yang Ada Di DB Tapi Tidak Ada Di FlexGrid 
        RecordItem = MyDatabase.MyReader("SELECT A.MBTRANSDTUID, B.INVENLEVEL FROM MBTRANSDT A, INVEN B WHERE A.MBTRANSDTITEMUID=B.INVENUID AND A.MBTRANSDTITEMSTAT > -1 AND A.MBTRANSUID = '" & InputMBTransUID & "'")
        While RecordItem.Read
            'If ItemExistInGrid(RecordItem.Item("MBTRANSDTITEMNAME")) = False Then Delete = Delete & MY_DELIMITER & RecordItem.Item("MBTRANSDTITEMNAME")

            If PrefInfo.UseKitchenPrintOut = "0" Then
                If CStr(RecordItem.Item("INVENLEVEL")) <> "3" Then
                    If ItemExistInGrid(RecordItem.Item("MBTRANSDTUID")) = False Then Delete = Delete & MY_DELIMITER & RecordItem.Item("MBTRANSDTUID")
                End If
            ElseIf PrefInfo.UseKitchenPrintOut = "1" Then
                If ItemExistInGrid(RecordItem.Item("MBTRANSDTUID")) = False Then Delete = Delete & MY_DELIMITER & RecordItem.Item("MBTRANSDTUID")
            End If

        End While
        RecordItem = Nothing

        'Hapus Item Yang Ada Di DB Tapi Tidak Ada Di FlexGrid
        If Len(Trim(Delete)) > 0 Then
            ArrayItem = Split(Delete, MY_DELIMITER)
            For i As Integer = 0 To UBound(ArrayItem)
                If Len(Trim(CStr(ArrayItem(i)))) > 0 Then
                    'Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDT WHERE MBTRANSDTITEMNAME = '" & CStr(ArrayItem(i)) & "' AND MBTRANSUID = '" & InputMBTransUID & "'")
                    Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET DELETEDUSER='" & UserInformation.UserName & "' WHERE MBTRANSDTUID = '" & CStr(ArrayItem(i)) & "'")
                    'Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDTDETAIL WHERE MBTRANSDTUID = '" & CStr(ArrayItem(i)) & "'")
                    Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDT WHERE MBTRANSDTUID = '" & CStr(ArrayItem(i)) & "' AND MBTRANSUID = '" & InputMBTransUID & "'")
                End If
            Next
        End If
    End Sub

    Private Function ItemExistInGrid(ByVal InputMBTransUID As String) As Boolean

        Dim R As Boolean = False
        Dim i As Integer

        With TableList
            For i = 1 To .Rows.Count - 1
                If Trim(.Item(i, 0)) = Trim(InputMBTransUID) Then R = True
            Next
        End With

        ItemExistInGrid = R

    End Function
#End Region

    Private Sub FindCust1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        IndexCust = 0
        Dim CustDialog As New Form_Customer_Pick
        CustDialog.Name = "Form_Customer_Pick"
        CustDialog.ParentOBJForm = Me
        CustDialog.ShowDialog()
    End Sub

    Private Sub FindCust2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)
        IndexCust = 1
        Dim CustDialog As New Form_Customer_Pick
        CustDialog.Name = "Form_Customer_Pick"
        CustDialog.ParentOBJForm = Me
        CustDialog.ShowDialog()
    End Sub

    Private Sub TableCombo_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles TableCombo.Change
        If TableCombo.SelectedIndex > -1 Then
            Dim TMPCheck As FbDataReader
            TMPCheck = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLELISTUID = '" & TableCombo.GetItemText(TableCombo.SelectedIndex, "Table UID") & "'")
            While TMPCheck.Read
                If Not IsDBNull(TMPCheck.Item("TABLEMBTRANSUID")) Then
                    Dim TMPCombo As FbDataReader
                    TMPCombo = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLEMBTRANSUID IS NULL ORDER BY TABLELISTNAME")

                    TableCombo.ClearItems()
                    TableCombo.HoldFields()

                    While TMPCombo.Read()
                        TableCombo.AddItem(TMPCombo.Item("TABLELISTNAME") & ";" & TMPCombo.Item("TABLELISTUID"))
                    End While
                    TMPCombo = Nothing

                    'TableName2Txt.Text = "00"
                    Exit Sub
                End If
            End While
        End If

        'TableName2Txt.Text = TableCombo.Text
    End Sub

    Private Sub VirtualKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKey.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(CustNametxt, False)
        VirtuKey.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Spliter1_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Spliter1.MouseDown
        If Spliter1.Rows.Count > 1 Then

            Dim NewStyle As C1.Win.C1FlexGrid.CellStyle
            NewStyle = Spliter1.Styles.Add("Click")
            NewStyle.BackColor = Color.LightCoral

            For i As Integer = 0 To Spliter1.Rows.Count - 1
                Spliter1.Item(i, 8) = False
                Spliter1.Rows(i).Style = Nothing
            Next
            Spliter1.Item(Spliter1.Row, 8) = True
            Spliter1.Rows(Spliter1.Row).Style = Spliter1.Styles("Click")
        End If
    End Sub

    Private Sub TableList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TableList.MouseDown
        If TableList.Rows.Count > 1 Then

            Dim NewStyle As C1.Win.C1FlexGrid.CellStyle
            NewStyle = TableList.Styles.Add("Click")
            NewStyle.BackColor = Color.LightCoral

            For i As Integer = 0 To TableList.Rows.Count - 1
                TableList.Item(i, 8) = False
                TableList.Rows(i).Style = Nothing
            Next
            TableList.Item(TableList.Row, 8) = True
            TableList.Rows(TableList.Row).Style = TableList.Styles("Click")
        End If
    End Sub

    Private Sub FocusMove1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMoveUp2.Click, BTNMoveDown2.Click
        With TableList
            If .Rows.Count > 1 Then
                Select Case sender.name
                    Case "BTNMoveUp2"
                        If .Row > 1 Then .Row = .Row - 1
                        TableList_MouseDown(sender, e)
                    Case "BTNMoveDown2"
                        If .Row < .Rows.Count - 1 Then .Row = .Row + 1
                        TableList_MouseDown(sender, e)
                End Select
            End If
        End With
    End Sub

    Private Sub FocusMove2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMoveUp.Click, BTNMoveDown.Click
        With Spliter1
            If .Rows.Count > 1 Then
                Select Case sender.name
                    Case "BTNMoveUp"
                        If .Row > 1 Then .Row = .Row - 1
                        Spliter1_MouseDown(sender, e)
                    Case "BTNMoveDown"
                        If .Row < .Rows.Count - 1 Then .Row = .Row + 1
                        Spliter1_MouseDown(sender, e)
                End Select
            End If
        End With
    End Sub

    Private Sub FindCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindCust.Click
        Me.Cursor = Cursors.WaitCursor
        Dim CustDialog As New Form_Customer_Pick
        CustDialog.Name = "Form_Customer_Pick"
        CustDialog.ParentOBJForm = Me
        CustDialog.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub CustomerList_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles CustomerList.Change
        If CustomerList.SelectedIndex = -1 Then
            CustNametxt.Text = Nothing
        Else
            CustNametxt.Text = CustomerList.Columns(0).Text
        End If
    End Sub

End Class