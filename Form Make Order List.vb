Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win
Imports C1.Win.C1FlexGrid
Imports DataDynamics.ActiveReports

Public Class Form_Make_Order_List

#Region "Variable Reference"

    Dim TransactionUID As String = GetTransactionCode(SelectedTable.TableUID)
    Public ParentOBJForm As Object
    Public ItemNotes As String = Nothing

    Dim UserPermition As New UserPermitionLib
    Dim ListCollection As New Collection
    Dim FormStatus As FormStatusLib
#End Region

#Region "Initialize & Object Function"

    Private Sub BasicInitialize()
        Dim TMPRecord As FbDataReader
        Dim I As Integer = 0
        Dim NewStyle As CellStyle
        NewStyle = TableList.Styles.Add("Disable")
        NewStyle.BackColor = Color.Silver
        Try
            TMPRecord = MyDatabase.MyReader("SELECT * FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "' AND MBTRANSDTITEMSTAT > -1 ") 'ORDER BY MBTRANSDTITEMNAME")
            With TableList
                .Redraw = False
                .Rows.Count = 1
                While TMPRecord.Read
                    I = I + 1
                    TableList.AddItem(vbTab & TMPRecord.Item("MBTRANSUID") & vbTab & TMPRecord.Item("MBTRANSDTUID") & vbTab & TMPRecord.Item("MBTRANSDTITEMUID") & vbTab & TMPRecord.Item("MBTRANSDTITEMNAME") & vbTab & Format(TMPRecord.Item("MODIFIEDDATETIME"), "HH:mm") & vbTab & TMPRecord.Item("MBTRANSDTITEMQTY") & vbTab & TMPRecord.Item("MBTRANSDTITEMPRICE") & vbTab & TMPRecord.Item("MBTRANSDTSUBVAL") & vbTab & TMPRecord.Item("MBTRANSDTITEMNOTE"))
                    .Rows(I).Height = 45
                    If TMPRecord.Item("MBTRANSDTITEMSTAT") = 1 Then
                        .Item(I, 11) = 1
                        .Rows(I).Style = TableList.Styles("Disable")
                    End If
                End While
                .Redraw = True
            End With
        Catch ex As Exception
            TableList.Redraw = True
        End Try

        'ListCollection = DBListCollection("SELECT * FROM MBTRANSDT WHERE MBTRANSDTITEMSTAT IS NULL OR MBTRANSDTITEMSTAT=0")
        'FormStatus = OBJControlInitialize(ListCollection)
        Call OBJControlHandler(Me, FormStatusLib.OpenAndView)
        Call CheckPermission(UserInformation.UserTypeUID, True)
    End Sub

    Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)
        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2203'")
        While TMPRecord.Read()
            UserPermition.PermitionInitialize(TMPRecord.Item("USERCATCREATEACCESS"), TMPRecord.Item("USERCATEDITACCESS"), TMPRecord.Item("USERCATDELETEACCESS"), TMPRecord.Item("USERCATREADACCESS"), TMPRecord.Item("USERCATPRINTACCESS"), TMPRecord.Item("USERCATCHANGEDATEACCESS"), TMPRecord.Item("USERCATCHANGETIMEACCESS"), TMPRecord.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
        End While

        With UserPermition
            If Not .ReadAccess Then
                ShowMessage(Me, "Maaf, anda tidak mempunyai akses terhadap form ini !" & vbNewLine & "Silakan hubungi administrator anda.")
                Me.Close()
            End If

            If .EditAccess Then
                BTNEdit.Enabled = True
                BTNEdit.VisualStyle = C1Input.VisualStyle.Office2007Blue
            Else
                BTNEdit.Enabled = False
                BTNEdit.VisualStyle = C1Input.VisualStyle.Office2007Silver
            End If

            If .DeleteAccess Then
                BTNDelete.Enabled = True
                BTNDelete.VisualStyle = C1Input.VisualStyle.Office2007Blue
            Else
                BTNDelete.Enabled = False
                BTNDelete.VisualStyle = C1Input.VisualStyle.Office2007Silver
            End If

            If .PrintAccess Then
                BTNPrint.Enabled = True
                BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Blue
            Else
                BTNPrint.Enabled = False
                BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Silver
            End If
        End With
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

    Private Sub ShowPrintPreview(Optional ByVal Nota As Boolean = False, Optional ByVal printerName As String = "")

        'Dim foundPrint As Boolean = False
        'Dim myListUID As String = ""
        'Dim filterItem As String = ""

        'With TableList
        '    For counter As Integer = 1 To .Rows.Count - 1
        '        If .Item(counter, 9) = True Then
        '            foundPrint = True
        '            If Len(Trim(myListUID)) = 0 Then
        '                myListUID = .Item(counter, 2)
        '            Else
        '                myListUID = myListUID & "|" & .Item(counter, 2)
        '            End If
        '        End If
        '    Next
        'End With

        'If foundPrint = False Then
        '    ShowMessage(Me, "Silakan tick pada menu yang akan dicetak !")
        '    Exit Sub
        'End If

        'Dim arrayData() As String
        'arrayData = Split(myListUID, "|")
        'For looper As Integer = 0 To UBound(arrayData)
        '    If looper = 0 Then
        '        filterItem = " MBTRANSDTUID='" & CStr(arrayData(looper)) & "'"
        '    Else
        '        filterItem = filterItem & " OR MBTRANSDTUID='" & CStr(arrayData(looper)) & "'"
        '    End If
        'Next

        Dim OBJNew As New Form_Print_Preview
        Dim Query As String

        Query = "SELECT a.MBTRANSUID, a.MBTRANSNO, a.MBTRANSDATE, a.MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME, a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID,(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = a.MBTRANSSERVICETYPEUID) AS MBTRANSSERVICETYPENAME, a.MBTRANSRSVTRANSUID, a.MBTRANSSUBVAL, a.MBTRANSDISCPERC, a.MBTRANSDISCVAL, a.MBTRANSTAXVAL1, a.MBTRANSTAXVAL2, a.MBTRANSDPVAL, a.MBTRANSTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT, a.MODIFIEDUSER, b.TABLELISTNAME " & _
                "FROM MBTRANS a LEFT JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE MBTRANSUID = '" & TransactionUID & "'"
        OBJNew.Printer = printerName
        OBJNew.Name = "Form_Print_Preview"
        OBJNew.RPTTitle = "Make Order"
        OBJNew.RPTDocument = New Make_Order
        OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
        OBJNew.VersiNota = Nota
        OBJNew.ShowDialog()

    End Sub
#End Region

#Region "Form Control Function"

    Private Sub Form_Make_Order_List_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 44)
        Me.Text = "Make Order List - Table " & SelectedTable.TableName
        TableList.Styles("Normal").WordWrap = True
        If PrefInfo.UseKitchenPrintOut = "1" Then
            BTNEdit.Visible = False
        Else
            BTNEdit.Visible = True
        End If
        Call BasicInitialize()
    End Sub

    Private Sub BTNEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEdit.Click
        Me.Cursor = Cursors.WaitCursor
        If Authorize = True Then
            Authorize = False
            UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, UDeptUID)
            Call MainPage.StatusBarInitialize()
        End If
        Dim TMPHeader As FbDataReader
        TMPHeader = MyDatabase.MyReader("SELECT * FROM MBTrans WHERE MBTransUID = '" & TransactionUID & "'")
        TMPHeader.Read()
        If Not IsDBNull(TMPHeader.Item("ISBILLED")) Then
            If TMPHeader.Item("ISBILLED") = 1 Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Maaf, anda tidak dapat merubah/menambah order pesanan, karena transaksi ini sudah dibuatkan bill tagihan !" & vbNewLine & "Silakan hubungi manager anda !")
                Exit Sub
            End If
        End If

        Dim TMPCheckTable As FbDataReader
        TMPCheckTable = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLELISTUID = '" & SelectedTable.TableUID & "'")
        While TMPCheckTable.Read
            If IsDBNull(TMPCheckTable.Item("TABLEMBTRANSUID")) Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Maaf, proses edit tidak dapat dilakukan, karena customer telah pindah ke meja lain, atau telah check out !")
                Exit Sub
            End If
        End While

        If TableList.Row > 0 Then
            If ParentOBJForm.name = "Make_Order" Then
                If PrefInfo.ShowMenuImage = False Then
                    ParentOBJForm.close()
                    Dim OBJNew As New Form_Make_Order
                    OBJNew.Name = "Make_Order"
                    OBJNew.GetDTOrder(TableList.Item(TableList.Row, 1))
                    OBJNew.EditStatus = True
                    OBJNew.ShowDialog()
                    Call BasicInitialize()
                ElseIf PrefInfo.ShowMenuImage = True Then
                    ParentOBJForm.close()
                    Dim OBJNew As New Form_Make_Order_Image
                    OBJNew.Name = "Make_Order"
                    OBJNew.GetDTOrder(TableList.Item(TableList.Row, 1))
                    OBJNew.EditStatus = True
                    OBJNew.ShowDialog()
                    Call BasicInitialize()
                End If
            Else
                If PrefInfo.ShowMenuImage = False Then
                    'Dim OBJNew As New Form_Make_Order
                    'OBJNew.Name = "Make_Order"
                    'OBJNew.GetDTOrder(TableList.Item(TableList.Row, 1))
                    'OBJNew.EditStatus = True
                    'OBJNew.ShowDialog()
                    Form_Make_Order.Close()
                    Form_Make_Order.GetDTOrder(TableList.Item(TableList.Row, 1))
                    Form_Make_Order.EditStatus = True
                    Form_Make_Order.ShowDialog()
                    Call BasicInitialize()
                ElseIf PrefInfo.ShowMenuImage = True Then
                    'Dim OBJNew As New Form_Make_Order_Image
                    'OBJNew.Name = "Make_Order"
                    'OBJNew.GetDTOrder(TableList.Item(TableList.Row, 1))
                    'OBJNew.EditStatus = True
                    'OBJNew.ShowDialog()
                    Form_Make_Order_Image.Close()
                    Form_Make_Order_Image.GetDTOrder(TableList.Item(TableList.Row, 1))
                    Form_Make_Order_Image.EditStatus = True
                    Form_Make_Order_Image.ShowDialog()
                    Call BasicInitialize()
                End If
            End If
            Me.Close()
        Else
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Maaf, tidak ada data order pesanan untuk diedit !")
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BTNVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNDelete.Click

        'Check apakah meja sudah dibuatkan tagihan
        Dim TMPHeader As FbDataReader
        Dim DeleteQty As Integer = 0
        TMPHeader = MyDatabase.MyReader("SELECT * FROM MBTrans WHERE MBTransUID = '" & TransactionUID & "'")
        TMPHeader.Read()
        If Not IsDBNull(TMPHeader.Item("ISBILLED")) Then
            If TMPHeader.Item("ISBILLED") = 1 Then
                ShowMessage(Me, "Maaf, anda tidak dapat merubah order pesanan, karena transaksi ini telah dibuatkan bill tagihan !" & vbNewLine & "Silakan hubungi manager anda !")
                Exit Sub
            End If
        End If

        'Check apakah status meja kosong (tidak terisi)
        Dim TMPCheckTable As FbDataReader
        TMPCheckTable = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLELISTUID = '" & SelectedTable.TableUID & "'")
        While TMPCheckTable.Read
            If IsDBNull(TMPCheckTable.Item("TABLEMBTRANSUID")) Then
                ShowMessage(Me, "Maaf, anda tidak dapat merubah order pesanan, karena customer telah pindah ke meja lain, atau telah check out !")
                Exit Sub
            End If
        End While

        If TableList.Row > 0 Then
            With TableList
                Dim TMPRecord As FbDataReader
                TMPRecord = MyDatabase.MyReader("SELECT * FROM MBTRANSDT WHERE MBTRANSDTUID = '" & .Item(.Row, 2) & "'")

                If TMPRecord.Read() Then
                    If TMPRecord.Item("MBTRANSDTITEMSTAT") > 0 Then

                        'Anjo - 18 Jan 2012 : Tidak perlu query lagi, karena sudah ikut basic initialise
                        'Dim TMPRecordd As FbDataReader
                        'TMPRecordd = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2203'")
                        'While TMPRecordd.Read()
                        '    UserPermition.PermitionInitialize(TMPRecordd.Item("USERCATCREATEACCESS"), TMPRecordd.Item("USERCATEDITACCESS"), TMPRecordd.Item("USERCATDELETEACCESS"), TMPRecordd.Item("USERCATREADACCESS"), TMPRecordd.Item("USERCATPRINTACCESS"), TMPRecordd.Item("USERCATCHANGEDATEACCESS"), TMPRecordd.Item("USERCATCHANGETIMEACCESS"), TMPRecordd.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
                        'End While

                        If Not UserPermition.DeleteOrderAccess Then ShowMessage(Me, "Maaf, order pesanan tidak dapat dibatalkan, karena order pesanan telah diproses !")

                        With UserPermition

                            If Not .DeleteOrderAccess Then
                                Dim OBJNew As New Form_User_Authorize_Dialog
                                OBJNew.Name = "Form_User_Authorize_Dialog"
                                OBJNew.ParentOBJForm = Me
                                OBJNew.NeedAuthorizationForMakeBill = True
                                OBJNew.ShowDialog()

                                If Authorize = False Then Exit Sub

                                Dim TMPRecordAuthorize As FbDataReader
                                TMPRecordAuthorize = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2203'")
                                While TMPRecordAuthorize.Read()
                                    UserPermition.PermitionInitialize(TMPRecordAuthorize.Item("USERCATCREATEACCESS"), TMPRecordAuthorize.Item("USERCATEDITACCESS"), TMPRecordAuthorize.Item("USERCATDELETEACCESS"), TMPRecordAuthorize.Item("USERCATREADACCESS"), TMPRecordAuthorize.Item("USERCATPRINTACCESS"), TMPRecordAuthorize.Item("USERCATCHANGEDATEACCESS"), TMPRecordAuthorize.Item("USERCATCHANGETIMEACCESS"), TMPRecordAuthorize.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
                                End While

                                With UserPermition
                                    If .DeleteOrderAccess Then
                                        Authorize = True
                                        GoTo Del
                                    Else
                                        ShowMessage(Me, "Maaf, anda tidak mempunyai akses untuk membatalkan order pesanan !")
                                        UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, UDeptUID)
                                        Call MainPage.StatusBarInitialize()

                                        FormStatus = FormStatusLib.OpenAndLock
                                        Call OBJControlHandler(Me, FormStatus)

                                        Exit Sub
                                    End If
                                End With
                            End If

                            If .DeleteOrderAccess Then
Del:
                                Dim OBJInput As New Form_Input_Box
                                OBJInput.Name = "Form_Input_Box"
                                OBJInput.Quantity = TableList.Item(TableList.Row, 6)
                                OBJInput.Text = "Delete Quantity"
                                OBJInput.QuantityLabel.Text = "Delete Quantity"
                                OBJInput.ParentOBJForm = Me
                                OBJInput.ShowDialog()

                                If OBJInput.Cancel = False Then
                                    DeleteQty = OBJInput.TotalMove.Text
                                Else
                                    If Authorize = True Then
                                        Authorize = False
                                        UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, UDeptUID)
                                        Call MainPage.StatusBarInitialize()
                                    End If
                                    Exit Sub
                                End If

                                Dim ItemToDel As String = TableList.Item(TableList.Row, 4)

                                If DeleteQty = TableList.Item(TableList.Row, 6) Then
                                    Dim OBJNew As New Dialog_Notes
                                    OBJNew.Name = "Dialog_Notes"
                                    OBJNew.ParentOBJForm = Me
                                    OBJNew.ShowDialog()

                                    If ItemNotes = Nothing Then
                                        Exit Sub
                                    End If

                                    Call PrintOutDel(TableList.Item(TableList.Row, 2), DeleteQty.ToString, ItemNotes)

                                    Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSUID LIKE '" & TransactionUID & "'")
                                    Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET DELETEDUSER='" & UserInformation.UserName & "',DELETEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSDTUID = '" & TableList.Item(TableList.Row, 2) & "'")
                                    Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMCANCELLEDNOTE='" & ReplacePetik(ItemNotes) & "',MBTRANSDTITEMSTAT=-1 WHERE MBTRANSDTUID = '" & TableList.Item(TableList.Row, 2) & "'")
                                    Call BasicInitialize()
                                    ShowMessage(Me, "Order pesanan '" & ItemToDel & "' telah berhasil dibatalkan !")

                                    If Authorize = True Then
                                        Authorize = False
                                        UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, UDeptUID)
                                        Call MainPage.StatusBarInitialize()
                                    End If
                                    Exit Sub
                                Else
                                    Dim OBJNew As New Dialog_Notes
                                    OBJNew.Name = "Dialog_Notes"
                                    OBJNew.ParentOBJForm = Me
                                    OBJNew.ShowDialog()

                                    If ItemNotes = Nothing Then
                                        Exit Sub
                                    End If

                                    Call PrintOutDel(TableList.Item(TableList.Row, 2), DeleteQty.ToString, ItemNotes)
                                    TableList.Item(TableList.Row, 6) = CInt(TableList.Item(TableList.Row, 6)) - DeleteQty
                                    Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSUID LIKE '" & TransactionUID & "'")
                                    Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET DELETEDUSER='" & UserInformation.UserName & "',DELETEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSDTUID = '" & TableList.Item(TableList.Row, 2) & "'")
                                    Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMCANCELLEDNOTE='" & ReplacePetik(ItemNotes) & "',MBTRANSDTITEMQTY='" & TableList.Item(TableList.Row, 6) & "',MBTRANSDTSUBVAL='" & TableList.Item(TableList.Row, 6) * TableList.Item(TableList.Row, 7) & "' WHERE MBTRANSDTUID = '" & TableList.Item(TableList.Row, 2) & "'")
                                    Call BasicInitialize()

                                    ShowMessage(Me, "" & DeleteQty & " " & ItemToDel & " telah berhasil dibatalkan !")
                                    If Authorize = True Then
                                        Authorize = False
                                        UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, UDeptUID)
                                        Call MainPage.StatusBarInitialize()
                                    End If
                                    Exit Sub
                                End If
                            Else
                                FormStatus = FormStatusLib.OpenAndLock
                                Call OBJControlHandler(Me, FormStatus)
                            End If
                        End With

                        Exit Sub
                    End If
                End If

                Dim DeleteQuantity As Integer = 0
                If ShowQuestion(Me, "Remove item " & .Item(.Row, 4) & " from the list ?") = True Then

                    If PrefInfo.UseKitchenPrintOut = "1" Then
                        Dim OBJNew As New Dialog_Notes
                        OBJNew.Name = "Dialog_Notes"
                        OBJNew.ParentOBJForm = Me
                        OBJNew.ShowDialog()

                        If ItemNotes = Nothing Then
                            Exit Sub
                        End If
                    End If

                    Call PrintOutDel(TableList.Item(TableList.Row, 2), TableList.Item(TableList.Row, 6), ItemNotes)
                    Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSUID LIKE '" & TransactionUID & "'")
                    Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET DELETEDUSER='" & UserInformation.UserName & "',DELETEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',MBTRANSDTITEMCANCELLEDNOTE='" & ReplacePetik(ItemNotes) & "' WHERE MBTRANSDTUID = '" & .Item(.Row, 2) & "'")
                    'Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDTDETAIL WHERE MBTRANSDTUID = '" & .Item(.Row, 2) & "'")
                    Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDT WHERE MBTRANSDTUID = '" & .Item(.Row, 2) & "'")

                    Call BasicInitialize()
                    Exit Sub
                End If
            End With
        End If

    End Sub

    Private Sub PrintOutDel(ByVal kodeItem As String, ByVal jumlahHapus As String, ByVal keterangan As String)
        If PrefInfo.UseKitchenPrintOut <> "1" Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Make_Order.pubQueryLap = ""
        Dim rs As FbDataReader, selPrinterName As String
        rs = MyDatabase.MyReader("SELECT DISTINCT(INVENKITCHENUID) AS KodeKitchen FROM INVEN A INNER JOIN " & _
                                "(SELECT IIF(B.MBTRANSDTITEMUID IS NULL,A.MBTRANSDTITEMUID,B.MBTRANSDTITEMUID) AS KodeBarang FROM MBTRANSDT A LEFT JOIN MBTRANSDTDETAIL B ON A.MBTRANSDTUID=B.MBTRANSDTUID WHERE a.MBTRANSDTUID='" & kodeItem & "') B " & _
                                "ON A.INVENUID=B.KodeBarang")

        While rs.Read = True
            selPrinterName = getPrinterName(rs("KodeKitchen"))
            If Len(Trim(selPrinterName)) > 0 Then
                Make_Order.pubHarusCetakNotes = True
                Make_Order.pubQueryLap = "SELECT B.*,'-" & jumlahHapus & "' AS MBTRANSDTITEMQTY,'(BATAL) " & keterangan & "' AS MBTRANSDTITEMNOTE FROM INVEN A INNER JOIN " & _
                                        "(" & _
                                        "SELECT a.MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang, a.MBTRANSDTITEMNAME,b.MBTRANSDTITEMNAME AS DETAILITEM,(b.MBTRANSDTITEMQTY/a.MBTRANSDTITEMQTY)*(-1*" & Replace(CDec(jumlahHapus), ",", ".") & ") AS DETAILQTY " & _
                                        "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
                                        "WHERE a.MBTRANSDTUID ='" & kodeItem & "' " & _
                                        ") B ON A.INVENUID=B.KodeBarang WHERE INVENKITCHENUID='" & Trim(rs("KodeKitchen")) & "'"
                Call ShowPrintPreview(True, selPrinterName)           
            End If
        End While
        Me.Cursor = Cursors.Default
        rs = Nothing
    End Sub

    Private Function getPrinterName(ByVal idKitchen As String) As String
        getPrinterName = ""
        Dim rs As FbDataReader
        rs = MyDatabase.MyReader("SELECT * FROM KITCHEN WHERE KITCHENUID='" & ReplacePetik(idKitchen) & "'")
        While rs.Read = True
            If IsDBNull(rs("KITCHENPRINTER")) = False Then
                getPrinterName = rs("KITCHENPRINTER")
            Else
                getPrinterName = ""
            End If
        End While
        rs = Nothing
    End Function

    Private Sub BTNViewNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNViewNotes.Click
        With TableList
            If .Row > 0 Then
                Dim OBJNew As New Form_View_Notes
                OBJNew.Name = "Form_View_Notes"
                OBJNew.ParentOBJForm = Me
                OBJNew.NotesTxt.Text = .Item(.Row, 9)
                OBJNew.ShowDialog()
            End If
        End With
    End Sub

    Private Sub BTNClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClose.Click
        Dim Query As String = Nothing

        If Authorize = True Then
            Authorize = False
            UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, UDeptUID)
            Call MainPage.StatusBarInitialize()
        End If

        Query = "UPDATE MBTRANSDT SET PRINT=0 WHERE MBTRANSUID ='" & TransactionUID & "'"
        Call MyDatabase.MyAdapter(Query)

        Call MainPage.TableClickInfo(selectedObject, myEvent)
        Me.Close()
    End Sub

    Private Sub TableList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TableList.MouseDown
        If TableList.Rows.Count > 1 Then

            Dim NewStyle As CellStyle
            NewStyle = TableList.Styles.Add("Click")
            NewStyle.BackColor = Color.LightCoral

            Dim Style As CellStyle
            Style = TableList.Styles.Add("Disable")
            Style.BackColor = Color.Silver

            For i As Integer = 0 To TableList.Rows.Count - 1
                'TableList.Item(i, 0) = False
                TableList.Rows(i).Style = Nothing
                If TableList.Item(i, 11) = 1 Then
                    TableList.Rows(i).Style = TableList.Styles("Disable")
                End If
            Next
            'TableList.Item(TableList.Row, 0) = True
            TableList.Rows(TableList.Row).Style = TableList.Styles("Click")

            'If TableList.Item(TableList.Row, 10) = 1 Then
            '    TableList.Rows(TableList.Row).Style = TableList.Styles("Disable")
            'Else
            '    TableList.Rows(TableList.Row).Style = TableList.Styles("Click")
            'End If
        End If
    End Sub

    Private Sub BTNPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPrint.Click

        Me.Cursor = Cursors.WaitCursor

        If Authorize = True Then
            Authorize = False
            UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, UDeptUID)
            Call MainPage.StatusBarInitialize()
        End If

        'Check apakah order sudah dibuatkan tagihan
        Dim TMPHeader As FbDataReader
        TMPHeader = MyDatabase.MyReader("SELECT * FROM MBTrans WHERE MBTransUID = '" & TransactionUID & "'")
        TMPHeader.Read()
        If Not IsDBNull(TMPHeader.Item("ISBILLED")) Then
            If TMPHeader.Item("ISBILLED") = 1 Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Maaf, anda tidak dapat mencetak order pesanan, karena transaksi ini sudah dibuatkan bill tagihan !" & vbNewLine & "Silakan hubungi manager anda !")
                Exit Sub
            End If
        End If

        'Check apakah meja kosong (tidak terisi customer)
        Dim TMPCheckTable As FbDataReader
        TMPCheckTable = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLELISTUID = '" & SelectedTable.TableUID & "'")
        While TMPCheckTable.Read
            If IsDBNull(TMPCheckTable.Item("TABLEMBTRANSUID")) Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Maaf, anda tidak dapat mencetak order pesanan, karena customer telah pindah ke meja lain atau telah check out !")
                Exit Sub
            End If
        End While

        If PrefInfo.UseKitchenPrintOut = "1" Then
            Dim frmA As New Form_Select_Printer
            frmA.Name = "Form_Select_Printer"
            frmA.ShowDialog()
            If frmA.Batal = True Then Me.Cursor = Cursors.Default : Exit Sub
            Make_Order.pubQueryLap = ""
            If frmA.chkKitchenPrinter.Checked = True Then
                Call RePrintOrder()
            End If
            Make_Order.pubQueryLap = ""
            If frmA.chkLocalPrinter.Checked = True Then
                Call RePrintOrder("True")
            End If
        Else
            Make_Order.pubQueryLap = ""
            Call RePrintOrder("True")
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub RePrintOrder(Optional ByVal isToLocal As String = "")

        Me.Cursor = Cursors.WaitCursor
        Dim i As Integer
        Dim tmpData As String = ""

        For i = 1 To TableList.Rows.Count - 1
            If TableList.Item(i, 10) = True Then
                tmpData = tmpData & "'" & TableList.Item(i, 2) & "',"
            End If
        Next

        If Trim(tmpData) = "" Then Me.Cursor = Cursors.Default : Exit Sub
        tmpData = Mid(tmpData, 1, Len(tmpData) - 1)

        If isToLocal = "" Then
            Dim rs As FbDataReader
            rs = MyDatabase.MyReader("SELECT DISTINCT(INVENKITCHENUID) AS KodeKitchen FROM INVEN A INNER JOIN " & _
                                    "(SELECT IIF(B.MBTRANSDTITEMUID IS NULL,A.MBTRANSDTITEMUID,B.MBTRANSDTITEMUID) AS KodeBarang FROM MBTRANSDT A LEFT JOIN MBTRANSDTDETAIL B ON A.MBTRANSDTUID=B.MBTRANSDTUID WHERE a.MBTRANSDTUID IN (" & tmpData & ")) B " & _
                                    "ON A.INVENUID=B.KodeBarang")

            While rs.Read = True
                Make_Order.pubHarusCetakNotes = True
                Make_Order.pubQueryLap = "SELECT B.* FROM INVEN A INNER JOIN " & _
                                        "(" & _
                                        "SELECT a.MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang,a.MBTRANSDTITEMQTY,a.MBTRANSDTITEMNOTE, a.MBTRANSDTITEMNAME,b.MBTRANSDTITEMNAME AS DETAILITEM,b.MBTRANSDTITEMQTY AS DETAILQTY " & _
                                        "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
                                        "WHERE a.MBTRANSDTUID IN (" & tmpData & ") " & _
                                        ") B ON A.INVENUID=B.KodeBarang WHERE INVENKITCHENUID='" & Trim(rs("KodeKitchen")) & "'"

                Call ShowPrintPreview(True, getPrinterName(rs("KodeKitchen")))
            End While
            rs = Nothing
        Else
            Make_Order.pubHarusCetakNotes = False
            Make_Order.pubQueryLap = "SELECT B.* FROM INVEN A INNER JOIN " & _
                                        "(" & _
                                        "SELECT a.MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang,a.MBTRANSDTITEMQTY,a.MBTRANSDTITEMNOTE, a.MBTRANSDTITEMNAME,b.MBTRANSDTITEMNAME AS DETAILITEM,b.MBTRANSDTITEMQTY AS DETAILQTY " & _
                                        "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
                                        "WHERE a.MBTRANSDTUID IN (" & tmpData & ") " & _
                                        ") B ON A.INVENUID=B.KodeBarang "

            Call ShowPrintPreview(True)
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FocusMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMoveUp.Click, BTNMoveDown.Click
        With TableList
            If .Rows.Count > 1 Then
                Select Case sender.name
                    Case "BTNMoveUp"
                        If .Row > 1 Then .Row = .Row - 1
                        TableList_MouseDown(sender, e)
                    Case "BTNMoveDown"
                        If .Row < .Rows.Count - 1 Then .Row = .Row + 1
                        TableList_MouseDown(sender, e)
                End Select
            End If
        End With
    End Sub
#End Region

    Private Sub TableList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableList.Click
        'If TableList.Row > 0 Then
        '    If TableList.Item(TableList.Row, 10) = True Then
        '        Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET PRINT=1 WHERE MBTRANSDTUID = '" & TableList.Item(TableList.Row, 2) & "'")
        '    Else
        '        Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET PRINT=0 WHERE MBTRANSDTUID = '" & TableList.Item(TableList.Row, 2) & "'")
        '    End If
        'End If
    End Sub

End Class