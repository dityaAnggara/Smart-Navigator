Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win.C1FlexGrid

Public Class Form_Move_Menu

#Region "Variable Reference"

    Dim TransactionUID As String = GetTransactionCode(SelectedTable.TableUID)
    Dim UserPermition As New UserPermitionLib
    'Dim ListCollection As New Collection
    Dim FormStatus As FormStatusLib

#End Region

#Region "Initialize & Object Function"

    Private Sub BasicInitialize()

        TableNameTxt.Text = SelectedTable.TableName
        Call TableInitialize()
        Call AllItemInitialize()

        '    ListCollection = DBListCollection("SELECT * FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "'")
        '    FormStatus = OBJControlInitialize(ListCollection)
        '    Call OBJControlHandler(Me, FormStatus)
        '    Call CheckPermission(UserInformation.UserTypeUID, IIf(ListCollection.Count > 0, True, False))

        Call CheckPermission(UserInformation.UserTypeUID, True)

    End Sub

    Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)

        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2208'")
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
        Dim I As Integer = -1
        Try
            'TMPRecord = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE (TABLELISTACTV IS NULL OR TABLELISTACTV = 0) AND NOT TABLEMBTRANSUID IS NULL ORDER BY TABLELISTNAME")
            TMPRecord = MyDatabase.MyReader("SELECT * FROM TABLELIST T LEFT OUTER JOIN FLOORNO F ON T.FLOORNOUID=F.FLOORNOUID LEFT OUTER JOIN MBTRANS MB ON T.TABLEMBTRANSUID=MB.MBTRANSUID WHERE (T.TABLELISTACTV Is NULL Or T.TABLELISTACTV = 0) AND NOT T.TABLEMBTRANSUID IS NULL AND MB.ISBILLED IS NULL OR MB.ISBILLED=0 AND F.FLOORDEPTUID ='" & DeptInfo.DeptUID & "' ORDER BY TABLELISTNAME")
            TableList.Redraw = False
            While TMPRecord.Read()
                If Trim(TMPRecord.Item("TABLELISTUID")) <> Trim(SelectedTable.TableUID) Then
                    I = I + 1
                    TableList.AddItem(vbTab & TMPRecord.Item("TABLELISTUID") & vbTab & TMPRecord.Item("TABLELISTNAME"))
                    TableList.Rows(I).Height = 45
                End If
            End While
            TableList.Redraw = True
        Catch ex As Exception
            TableList.Redraw = True
        End Try
        TMPRecord = Nothing

    End Sub

    Private Sub AllItemInitialize()

        Dim TMPRecord As FbDataReader
        Dim I As Integer = 0
        Try
            TMPRecord = MyDatabase.MyReader("SELECT A.*,B.INVENMEASUNITDESC, B.INVENLEVEL FROM MBTRANSDT A,INVEN B WHERE A.MBTRANSDTITEMUID=B.INVENUID AND A.MBTRANSUID = '" & TransactionUID & "' AND A.MBTRANSDTITEMSTAT > -1 ORDER BY A.MBTRANSDTITEMNAME")
            With CurrentList
                .Redraw = False
                .Rows.Count = 1
                While TMPRecord.Read
                    I = I + 1
                    .AddItem(TMPRecord.Item("MBTRANSDTUID") & vbTab & TMPRecord.Item("MBTRANSDTITEMQTY") & vbTab & TMPRecord.Item("MBTRANSDTITEMNAME") & vbTab & TMPRecord.Item("MBTRANSDTSUBVAL") & vbTab & TMPRecord.Item("MBTRANSDTITEMUID") & vbTab & TMPRecord.Item("MBTRANSDTITEMSTAT") & vbTab & TMPRecord.Item("MBTRANSDTITEMNOTE") & vbTab & TMPRecord.Item("MBTRANSDTISTAKEAWAY") & vbTab & vbTab & TMPRecord.Item("INVENMEASUNITDESC") & vbTab & TMPRecord.Item("INVENLEVEL"))
                    .Rows(I).Height = 45
                End While
                .Redraw = True
            End With
        Catch ex As Exception
            CurrentList.Redraw = True
        End Try

    End Sub

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

    Private Function GetTransactionNo(ByVal MBTransUID As String)
        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT MBTRANSNO FROM MBTRANS WHERE MBTRANSUID = '" & MBTransUID & "'")
        TMPRecord.Read()

        If IsDBNull(TMPRecord.Item("MBTRANSNO")) Then
            Return Nothing
        Else
            Return TMPRecord.Item("MBTRANSNO")
        End If

    End Function

    Private Function GetTableSelected() As Integer
        For i As Integer = 0 To TableList.Rows.Count - 1
            If TableList.Item(i, 0) = True Then
                Return i
                Exit Function
            End If
        Next
        Return -1
    End Function

#End Region

#Region "Form Control Function"

    Private Sub Form_Move_Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 44)
        Me.Cursor = Cursors.Default
        CurrentList.Styles("Normal").WordWrap = True
        MoveList.Styles("Normal").WordWrap = True
        Call BasicInitialize()
    End Sub

    Private Sub TableList_MouseDown(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableList.MouseDown
        If TableList.Rows.Count > 0 Then
            Dim NewStyle As CellStyle
            NewStyle = TableList.Styles.Add("Click")
            NewStyle.BackColor = Color.LightCoral

            For i As Integer = 0 To TableList.Rows.Count - 1
                TableList.Item(i, 0) = False
                TableList.Rows(i).Style = Nothing
            Next
            TableList.Item(TableList.Row, 0) = True
            TableList.Rows(TableList.Row).Style = TableList.Styles("Click")
        End If
    End Sub

    Private Sub CurrentList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles CurrentList.DoubleClick, BTNMove.Click
        Dim MoveQuantity As Decimal = 0
        Dim Price As Decimal = 0

        With CurrentList
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
                        For i As Integer = 0 To MoveList.Rows.Count - 1
                            If .Item(.Row, 0) = MoveList.Item(i, 0) Then
                                MoveList.Item(i, 1) = FormatNumber(CDec(MoveList.Item(i, 1)) + CDec(.Item(.Row, 1)), IIf(Fix(CDec(MoveList.Item(i, 1)) + CDec(.Item(.Row, 1))) = CDec(MoveList.Item(i, 1)) + CDec(.Item(.Row, 1)), 0, 1))
                                MoveList.Item(i, 3) = CDec(MoveList.Item(i, 1)) * Price

                                .RemoveItem(.Row)
                                Exit Sub
                            End If
                        Next

                        MoveList.AddItem(.Item(.Row, 0) & vbTab & .Item(.Row, 1) & vbTab & .Item(.Row, 2) & vbTab & .Item(.Row, 3) & vbTab & .Item(.Row, 4) & vbTab & .Item(.Row, 5) & vbTab & .Item(.Row, 6) & vbTab & .Item(.Row, 7) & vbTab & vbTab & .Item(.Row, 9) & vbTab & .Item(.Row, 10))
                        MoveList.Rows(MoveList.Rows.Count - 1).Height = 45
                        .RemoveItem(.Row)
                    Else
                        For i As Integer = 0 To MoveList.Rows.Count - 1
                            If .Item(.Row, 0) = MoveList.Item(i, 0) Then
                                MoveList.Item(i, 1) = FormatNumber(CDec(MoveList.Item(i, 1)) + MoveQuantity, IIf(Fix(CDec(MoveList.Item(i, 1)) + MoveQuantity) = CDec(MoveList.Item(i, 1)) + MoveQuantity, 0, 1))
                                MoveList.Item(i, 3) = CDec(MoveList.Item(i, 1)) * Price

                                .Item(.Row, 1) = FormatNumber(CDec(.Item(.Row, 1)) - MoveQuantity, IIf(Fix(CDec(.Item(.Row, 1)) - MoveQuantity) = CDec(.Item(.Row, 1)) - MoveQuantity, 0, 1))
                                .Item(.Row, 3) = CDec(.Item(.Row, 1)) * Price
                                Exit Sub
                            End If
                        Next

                        MoveList.AddItem(.Item(.Row, 0) & vbTab & MoveQuantity & vbTab & .Item(.Row, 2) & vbTab & MoveQuantity * Price & vbTab & .Item(.Row, 4) & vbTab & .Item(.Row, 5) & vbTab & .Item(.Row, 6) & vbTab & .Item(.Row, 7) & vbTab & vbTab & .Item(.Row, 9) & vbTab & .Item(.Row, 10))
                        MoveList.Rows(MoveList.Rows.Count - 1).Height = 45

                        .Item(.Row, 1) = FormatNumber(CDec(.Item(.Row, 1)) - MoveQuantity, IIf(Fix(CDec(.Item(.Row, 1)) - MoveQuantity) = CDec(.Item(.Row, 1)) - MoveQuantity, 0, 1))
                        .Item(.Row, 3) = CDec(.Item(.Row, 1)) * Price
                    End If
                End If
            End If
        End With
    End Sub

    Private Sub MoveList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles MoveList.DoubleClick, BTNCancel.Click
        With MoveList
            If .Row > 0 Then
                For i As Integer = 0 To CurrentList.Rows.Count - 1
                    If .Item(.Row, 2) = CurrentList.Item(i, 2) Then
                        CurrentList.Item(i, 1) = FormatNumber(CDec(CurrentList.Item(i, 1)) + CDec(.Item(.Row, 1)), IIf(Fix(CDec(CurrentList.Item(i, 1)) + CDec(.Item(.Row, 1))) = CDec(CurrentList.Item(i, 1)) + CDec(.Item(.Row, 1)), 0, 1))
                        CurrentList.Item(i, 3) = FormatNumber(CDec(CurrentList.Item(i, 3)) + CDec(.Item(.Row, 3)), IIf(Fix(CDec(CurrentList.Item(i, 3)) + CDec(.Item(.Row, 3))) = CDec(CurrentList.Item(i, 3)) + CDec(.Item(.Row, 3)), 0, 1))
                        .RemoveItem(.Row)
                        Exit Sub
                    End If
                Next

                CurrentList.AddItem(.Item(.Row, 0) & vbTab & .Item(.Row, 1) & vbTab & .Item(.Row, 2) & vbTab & .Item(.Row, 3) & vbTab & .Item(.Row, 4) & vbTab & .Item(.Row, 5) & vbTab & .Item(.Row, 6) & vbTab & .Item(.Row, 7) & vbTab & vbTab & .Item(.Row, 9) & vbTab & .Item(.Row, 10))
                CurrentList.Rows(CurrentList.Rows.Count - 1).Height = 45
                .RemoveItem(.Row)
            End If
        End With
    End Sub

    Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click

        Me.Cursor = Cursors.WaitCursor
        Dim TMPHeader As FbDataReader
        TMPHeader = MyDatabase.MyReader("SELECT * FROM MBTrans WHERE MBTransUID = '" & TransactionUID & "'")
        TMPHeader.Read()
        If Not IsDBNull(TMPHeader.Item("ISBILLED")) Then
            If TMPHeader.Item("ISBILLED") = 1 Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Maaf, anda tidak dapat memindahkan menu, karena meja '" & SelectedTable.TableName & "' sudah dibuatkan bill tagihan !")
                Exit Sub
            End If
        End If

        Dim TMPCheckTable As FbDataReader
        TMPCheckTable = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLELISTUID = '" & SelectedTable.TableUID & "'")
        While TMPCheckTable.Read
            If IsDBNull(TMPCheckTable.Item("TABLEMBTRANSUID")) Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Maaf, anda tidak dapat memindahkan menu, karena status meja '" & SelectedTable.TableName & " adalah kosong (tidak terisi customer) !")
                Exit Sub
            End If
        End While

        If MoveList.Rows.Count > 1 Then
            If GetTableSelected() = -1 Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Silakan pilih meja tujuan !")
                Exit Sub
            End If

            Dim Query As String, DestTransUID As String = GetTransactionCode(TableList.Item(GetTableSelected, 1))

            Dim TMPCheckTableCheck As FbDataReader
            TMPCheckTableCheck = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLELISTUID = '" & TableList.Item(GetTableSelected, 1) & "'")
            While TMPCheckTableCheck.Read
                If IsDBNull(TMPCheckTableCheck.Item("TABLEMBTRANSUID")) Then
                    Me.Cursor = Cursors.Default
                    ShowMessage(Me, "Maaf, anda tidak dapat memindahkan menu, karena status meja '" & TableList.Item(GetTableSelected, 2) & "' adalah kosong (tidak terisi customer) !")
                    Exit Sub
                End If
            End While

            Dim TMPCheck As FbDataReader
            TMPCheck = MyDatabase.MyReader("SELECT * FROM MBTrans WHERE MBTransUID = '" & DestTransUID & "'")
            TMPCheck.Read()
            If Not IsDBNull(TMPCheck.Item("ISBILLED")) Then
                If TMPCheck.Item("ISBILLED") = 1 Then
                    Me.Cursor = Cursors.Default
                    ShowMessage(Me, "Maaf, anda tidak dapat memindahkan menu, karena meja '" & TableList.Item(GetTableSelected, 2) & "' sudah dibuatkan tagihan !")
                    Exit Sub
                End If
            End If

            If CurrentList.Rows.Count > 1 Then
                '3 Des 2011 - Anjo, jgn lupa update modified time untuk source dan target table untuk multi user
                Query = "UPDATE MBTRANS SET MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSUID LIKE '" & TransactionUID & "' OR MBTRANSUID LIKE '" & DestTransUID & "'"
                Call MyDatabase.MyAdapter(Query)

                For a As Integer = 1 To CurrentList.Rows.Count - 1
                    'UPDATE CURRENT ITEM MENU
                    Query = "UPDATE MBTRANSDT SET MBTRANSDTITEMQTY ='" & CurrentList.Item(a, 1) & "',MBTRANSDTSUBVAL='" & CurrentList.Item(a, 3) & "',MODIFIEDUSER='" & UserInformation.UserName & "',MODIFIEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',DELETEDUSER='" & UserInformation.UserName & "',DELETEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "' WHERE MBTRANSDTUID = '" & CurrentList.Item(a, 0) & "'"
                    Call MyDatabase.MyAdapter(Query)
                Next

                ''DELETE CURRENT ITEM MENU - NOT IN CURRENTLIST
                'Call DeleteItemMB(TransactionUID)

                Dim destTransNo As String = GetTransactionNo(DestTransUID)
                For b As Integer = 1 To MoveList.Rows.Count - 1
                    ''CREATE NEW ITEM IN MOVELIST
                    'Dim ItemRecord As FbDataReader
                    Dim DetailUID As String = AutoUID()

                    'Query = "SELECT * FROM INVEN WHERE INVENUID = '" & MoveList.Item(b, 4) & "'"
                    'ItemRecord = MyDatabase.MyReader(Query)
                    'ItemRecord.Read()

                    If PrefInfo.UseKitchenPrintOut = "0" Then
                        If CStr(MoveList.Item(b, 10)) = "3" Then
                            Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSUID='" & DestTransUID & "' WHERE MBTRANSDTUID = '" & MoveList.Item(b, 0) & "'")
                        Else
                            'susilo, 18 Juli 2014, diganti update karena di laporan audittrial ada yang dihapus, sehingga aneh padahal cuma move menu ke table lain
                            If ItemExistInGrid(MoveList.Item(b, 0)) = True Then
                                Query = "INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMSTAT,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT,MBTRANSDTITEMCANCELLEDNOTE) " & _
                                        "VALUES('" & DetailUID & "','" & DestTransUID & "','" & MoveList.Item(b, 4) & "','" & ReplacePetik(MoveList.Item(b, 2)) & "','" & ReplacePetik(MoveList.Item(b, 9)) & "','" & Replace(MoveList.Item(b, 1), ",", ".") & "','" & MoveList.Item(b, 3) / MoveList.Item(b, 1) & "','" & MoveList.Item(b, 3) & "','" & MoveList.Item(b, 5) & "','" & ReplacePetik(MoveList.Item(b, 6)) & "','" & MoveList.Item(b, 7) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1,'Move To " & destTransNo & "')"
                            Else
                                Query = "UPDATE MBTRANSDT SET MBTRANSUID='" & DestTransUID & "',MBTRANSDTITEMUID='" & MoveList.Item(b, 4) & "',MBTRANSDTITEMNAME='" & ReplacePetik(MoveList.Item(b, 2)) & "',MBTRANSDTITEMMEASUNITDESC='" & ReplacePetik(MoveList.Item(b, 9)) & "',MBTRANSDTITEMQTY='" & Replace(MoveList.Item(b, 1), ",", ".") & "'," & _
                                "MBTRANSDTITEMPRICE='" & MoveList.Item(b, 3) / MoveList.Item(b, 1) & "',MBTRANSDTSUBVAL='" & MoveList.Item(b, 3) & "',MBTRANSDTITEMSTAT='" & MoveList.Item(b, 5) & "',MBTRANSDTITEMNOTE='" & ReplacePetik(MoveList.Item(b, 6)) & "',MBTRANSDTISTAKEAWAY='" & MoveList.Item(b, 7) & "',MODIFIEDUSER='" & UserInformation.UserName & "',MODIFIEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',PRINT='1',MBTRANSDTITEMCANCELLEDNOTE='Move To " & destTransNo & "' WHERE MBTRANSDTUID='" & MoveList.Item(b, 0) & "'"
                            End If
                            Call MyDatabase.MyAdapter(Query)
                        End If
                    ElseIf PrefInfo.UseKitchenPrintOut = "1" Then
                        If ItemExistInGrid(MoveList.Item(b, 0)) = True Then
                            Query = "INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMSTAT,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT,MBTRANSDTITEMCANCELLEDNOTE) " & _
                                    "VALUES('" & DetailUID & "','" & DestTransUID & "','" & MoveList.Item(b, 4) & "','" & ReplacePetik(MoveList.Item(b, 2)) & "','" & ReplacePetik(MoveList.Item(b, 9)) & "','" & Replace(MoveList.Item(b, 1), ",", ".") & "','" & MoveList.Item(b, 3) / MoveList.Item(b, 1) & "','" & MoveList.Item(b, 3) & "','" & MoveList.Item(b, 5) & "','" & ReplacePetik(MoveList.Item(b, 6)) & "','" & MoveList.Item(b, 7) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1,'Move To " & destTransNo & "')"
                        Else
                            Query = "UPDATE MBTRANSDT SET MBTRANSUID='" & DestTransUID & "',MBTRANSDTITEMUID='" & MoveList.Item(b, 4) & "',MBTRANSDTITEMNAME='" & ReplacePetik(MoveList.Item(b, 2)) & "',MBTRANSDTITEMMEASUNITDESC='" & ReplacePetik(MoveList.Item(b, 9)) & "',MBTRANSDTITEMQTY='" & Replace(MoveList.Item(b, 1), ",", ".") & "'," & _
                                "MBTRANSDTITEMPRICE='" & MoveList.Item(b, 3) / MoveList.Item(b, 1) & "',MBTRANSDTSUBVAL='" & MoveList.Item(b, 3) & "',MBTRANSDTITEMSTAT='" & MoveList.Item(b, 5) & "',MBTRANSDTITEMNOTE='" & ReplacePetik(MoveList.Item(b, 6)) & "',MBTRANSDTISTAKEAWAY='" & MoveList.Item(b, 7) & "',MODIFIEDUSER='" & UserInformation.UserName & "',MODIFIEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',PRINT='1',MBTRANSDTITEMCANCELLEDNOTE='Move To " & destTransNo & "' WHERE MBTRANSDTUID='" & MoveList.Item(b, 0) & "'"
                        End If
                        Call MyDatabase.MyAdapter(Query)
                    End If

                        'Anjo - 31 Okt -> Detail is done via trigger
                        'If ItemRecord("INVENLEVEL") = 3 Then
                        '    Dim ItemDetail As FbDataReader
                        '    ItemDetail = MyDatabase.MyReader("SELECT DT.*,I.INVENNAME  FROM INVENDT DT LEFT OUTER JOIN INVEN I ON DT.INVENDTITEMUID = I.INVENUID WHERE DT.INVENUID='" & MoveList.Item(b, 4) & "'")
                        '    While ItemDetail.Read
                        '        For a As Integer = 1 To CurrentList.Rows.Count - 1
                        '            Query = "UPDATE MBTRANSDTDETAIL SET MBTRANSDTITEMQTY ='" & ItemDetail("ITEMQTY") * CurrentList.Item(a, 1) & "',MBTRANSDTSUBVAL='" & CurrentList.Item(a, 3) & "' WHERE MBTRANSDTUID LIKE '" & CurrentList.Item(a, 0) & "'"
                        '            Call MyDatabase.MyAdapter(Query)
                        '        Next

                        '        Query = "INSERT INTO MBTRANSDTDETAIL (MBTRANSDTDETAILUID,MBTRANSDTUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTITEMSTAT,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME) " & _
                        '        "VALUES('" & AutoUID() & "','" & DetailUID & "','" & ItemDetail("INVENDTITEMUID") & "','" & ReplacePetik(ItemDetail("INVENNAME")) & "','" & ReplacePetik(ItemDetail("ITEMMEASUNITDESC")) & "','" & ItemDetail("ITEMQTY") * MoveList.Item(b, 1) & "','" & MoveList.Item(b, 3) / MoveList.Item(b, 1) & "','" & ReplacePetik(MoveList.Item(b, 3)) & "','','" & MoveList.Item(b, 5) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "')"
                        '        Call MyDatabase.MyAdapter(Query)
                        '    End While
                        'End If
                        'ItemRecord = Nothing
                Next
            Else
                '3 Des 2011 - Anjo, jgn lupa update modified time untuk source dan target table untuk multi user
                Query = "UPDATE MBTRANS SET MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSUID LIKE '" & TransactionUID & "' OR MBTRANSUID LIKE '" & DestTransUID & "'"
                Call MyDatabase.MyAdapter(Query)

                For a As Integer = 1 To MoveList.Rows.Count - 1
                    ''UPDATE ALL CURRENT ITEM IN MOVELIST
                    Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSUID='" & DestTransUID & "' WHERE MBTRANSDTUID = '" & MoveList.Item(a, 0) & "'")
                Next
            End If

            'Query = "UPDATE MBTRANS SET MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSUID LIKE '" & TransactionUID & "'"
            'Call MyDatabase.MyAdapter(Query)

            'With MoveList
            '    For i As Integer = 1 To .Rows.Count - 1
            '        For j As Integer = 1 To CurrentList.Rows.Count - 1
            '            If .Item(i, 2) <> CurrentList.Item(j, 2) Then
            '                Query = "UPDATE MBTRANSDT SET MBTRANSUID ='" & DestTransUID & "', MBTRANSDTITEMCANCELLEDNOTE='Move To " & GetTransactionNo(TransactionUID) & "' WHERE MBTRANSDTUID LIKE '" & .Item(i, 0) & "'"
            '                Call MyDatabase.MyAdapter(Query)
            '            End If
            '        Next
            '    Next
            'End With

            Me.Close()
        Else
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Silakan pilih order pesanan yang akan dipindahkan !")
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BTNClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClose.Click
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
                    'Anjo - 31 Okt, Deleting detail is done via trigger
                    'Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDTDETAIL WHERE MBTRANSDTUID = '" & CStr(ArrayItem(i)) & "'")
                    Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDT WHERE MBTRANSDTUID = '" & CStr(ArrayItem(i)) & "' AND MBTRANSUID = '" & InputMBTransUID & "'")
                End If
            Next
        End If
    End Sub

    Private Function ItemExistInGrid(ByVal InputMBTransUID As String) As Boolean

        Dim R As Boolean = False
        Dim i As Integer

        With CurrentList
            For i = 1 To .Rows.Count - 1
                If Trim(.Item(i, 0)) = Trim(InputMBTransUID) Then R = True
            Next
        End With

        ItemExistInGrid = R

    End Function
#End Region


    Private Sub CurrentList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles CurrentList.MouseDown
        If CurrentList.Rows.Count > 1 Then

            Dim NewStyle As CellStyle
            NewStyle = CurrentList.Styles.Add("Click")
            NewStyle.BackColor = Color.LightCoral

            For i As Integer = 0 To CurrentList.Rows.Count - 1
                CurrentList.Item(i, 8) = False
                CurrentList.Rows(i).Style = Nothing
            Next
            CurrentList.Item(CurrentList.Row, 8) = True
            CurrentList.Rows(CurrentList.Row).Style = CurrentList.Styles("Click")
        End If
    End Sub

    Private Sub MoveList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MoveList.MouseDown
        If MoveList.Rows.Count > 1 Then

            Dim NewStyle As CellStyle
            NewStyle = MoveList.Styles.Add("Click")
            NewStyle.BackColor = Color.LightCoral

            For i As Integer = 0 To MoveList.Rows.Count - 1
                MoveList.Item(i, 8) = False
                MoveList.Rows(i).Style = Nothing
            Next
            MoveList.Item(MoveList.Row, 8) = True
            MoveList.Rows(MoveList.Row).Style = MoveList.Styles("Click")
        End If
    End Sub

    Private Sub FocusMove1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMoveUp.Click, BTNMoveDown.Click
        With CurrentList
            If .Rows.Count > 1 Then
                Select Case sender.name
                    Case "BTNMoveUp"
                        If .Row > 1 Then .Row = .Row - 1
                        CurrentList_MouseDown(sender, e)
                    Case "BTNMoveDown"
                        If .Row < .Rows.Count - 1 Then .Row = .Row + 1
                        CurrentList_MouseDown(sender, e)
                End Select
            End If
        End With
    End Sub
    Private Sub FocusMove2(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMoveUp2.Click, BTNMoveDown2.Click
        With MoveList
            If .Rows.Count > 1 Then
                Select Case sender.name
                    Case "BTNMoveUp2"
                        If .Row > 1 Then .Row = .Row - 1
                        MoveList_MouseDown(sender, e)
                    Case "BTNMoveDown2"
                        If .Row < .Rows.Count - 1 Then .Row = .Row + 1
                        MoveList_MouseDown(sender, e)
                End Select
            End If
        End With
    End Sub

    Private Sub FocusMove3(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMoveUp3.Click, BTNMoveDown3.Click
        With TableList
            If .Rows.Count > -1 Then
                Select Case sender.name
                    Case "BTNMoveUp3"
                        If .Row > 0 Then .Row = .Row - 1
                        TableList_MouseDown(sender, e)
                    Case "BTNMoveDown3"
                        If .Row < .Rows.Count - 1 Then .Row = .Row + 1
                        TableList_MouseDown(sender, e)
                End Select
            End If
        End With
    End Sub
End Class