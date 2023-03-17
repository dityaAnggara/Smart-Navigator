Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win.C1FlexGrid

Public Class Form_Join_Bill

#Region "Variable Reference"

    Dim TransactionUID As String = GetTransactionCode(SelectedTable.TableUID)
    Dim UserPermition As New UserPermitionLib
    'Dim ListCollection As New Collection
    Dim FormStatus As FormStatusLib

#End Region

#Region "Initialize & Object Function"

    Private Sub BasicInitialize()
        TableNameTxt.Text = SelectedTable.TableName
        NoteTxt.Text = "JOIN BILL - " & GetTransactionNo(TransactionUID) & ""

        Call TableInitialize()
        Call CheckPermission(UserInformation.UserTypeUID, True)
    End Sub

    Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)
        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2209'")
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
            Else
                FormStatus = FormStatusLib.OpenAndLock
                Call OBJControlHandler(Me, FormStatus)
            End If
        End With

    End Sub

    Private Sub TableInitialize()
        Dim TMPRecord As FbDataReader
        Dim I As Integer = -1
        Try
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

    Private Function GetMBTransDetail(ByVal TransUID As String) As ArrayList
        Dim TMPRecord As FbDataReader
        Dim TMPArray As New ArrayList
        TMPRecord = MyDatabase.MyReader("SELECT * FROM MBTRANS WHERE MBTRANSUID = '" & TransUID & "'")
        While TMPRecord.Read()
            For i As Integer = 0 To TMPRecord.FieldCount - 1
                TMPArray.Add(TMPRecord.Item(i))
            Next
        End While

        Return TMPArray
        TMPRecord = Nothing
    End Function

    Private Function GetTransactionCode(ByVal TableUID As String) As String
        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT TABLEMBTRANSUID FROM TABLELIST WHERE TABLELISTUID = '" & TableUID & "'")
        TMPRecord.Read()

        If IsDBNull(TMPRecord.Item("TABLEMBTRANSUID")) Then
            Return Nothing
        Else
            Return TMPRecord.Item("TABLEMBTRANSUID")
        End If

    End Function

    Private Function GetTableSelected() As Integer
        For i As Integer = 0 To TableList.Rows.Count - 1
            If TableList.Item(i, 0) = True Then
                Return i
                Exit Function
            End If
        Next
    End Function

    Private Function GetTransactionNo(ByVal MBTransUID As String)
        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT MBTRANSNO FROM MBTRANS WHERE MBTRANSUID='" & MBTransUID & "'")
        If TMPRecord.Read() Then
            If IsDBNull(TMPRecord.Item("MBTRANSNO")) Then
                Return Nothing
            Else
                Return TMPRecord.Item("MBTRANSNO")
            End If
        End If

        Return Nothing
    End Function

#End Region

#Region "Form Control Function"

    Private Sub Form_Join_Bill_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New System.Drawing.Point(MainPage.Location.X + 407, MainPage.Location.Y + 87)
        Me.Cursor = Cursors.Default
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

    Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click

        Me.Cursor = Cursors.WaitCursor
        Dim TMPHeader As FbDataReader
        TMPHeader = MyDatabase.MyReader("SELECT * FROM MBTrans WHERE MBTransUID = '" & TransactionUID & "'")
        TMPHeader.Read()
        If Not IsDBNull(TMPHeader.Item("ISBILLED")) Then
            If TMPHeader.Item("ISBILLED") = 1 Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Maaf, transaksi penggabungan tagihan tidak dapat dilakukan, karena tagihan untuk  meja '" & SelectedTable.TableName & "' sudah dibuat !")
                Exit Sub
            End If
        End If

        Dim TMPCheckTable As FbDataReader
        TMPCheckTable = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLELISTUID = '" & SelectedTable.TableUID & "'")
        While TMPCheckTable.Read
            If IsDBNull(TMPCheckTable.Item("TABLEMBTRANSUID")) Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Maaf, transaksi penggabungan tagihan tidak dapat dilakukan, karena status meja '" & SelectedTable.TableName & "' saat ini adalah kosong (tidak ada customer) !")
                Exit Sub
            End If
        End While

        If TableList.Rows.Count > 0 Then
            If GetTableSelected() = -1 Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Silakan pilih tagihan meja yang akan digabungkan !")
                Exit Sub
            End If

            If Len(Trim(NoteTxt.Text)) = 0 Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Silakan isikan keterangan penggabungan !")
                NoteTxt.Focus()
                Exit Sub
            End If

            With TableList
                For i As Integer = 0 To .Rows.Count - 1
                    Dim Query As String = Nothing
                    If .Item(i, 0) = True Then
                        Dim DestTransUID As String = GetTransactionCode(TableList.Item(i, 1))

                        Dim TMPCheckTableCheck As FbDataReader
                        TMPCheckTableCheck = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLELISTUID = '" & TableList.Item(i, 1) & "'")
                        While TMPCheckTableCheck.Read
                            If IsDBNull(TMPCheckTableCheck.Item("TABLEMBTRANSUID")) Then
                                Me.Cursor = Cursors.Default
                                ShowMessage(Me, "Maaf, transaksi penggabungan tagihan tidak dapat dilakukan, karena status meja '" & TableList.Item(i, 2) & "' saat ini adalah kosong (tidak ada customer) !")
                                Exit Sub
                            End If
                        End While

                        Dim TMPCheck As FbDataReader
                        'Variable to hold the down payment used value (27 Jan 2011)
                        'Dim DPVal As Decimal
                        TMPCheck = MyDatabase.MyReader("SELECT * FROM MBTrans WHERE MBTransUID = '" & DestTransUID & "'")
                        TMPCheck.Read()
                        If Not IsDBNull(TMPCheck.Item("ISBILLED")) Then
                            If TMPCheck.Item("ISBILLED") = 1 Then
                                Me.Cursor = Cursors.Default
                                ShowMessage(Me, "Maaf, transaksi penggabungan tagihan tidak dapat dilakukan, karena tagihan untuk  meja '" & TableList.Item(i, 2) & "' sudah dibuat !")
                                Exit Sub
                            End If
                        End If

                        'Add by Rudy (9 Juni 2011)
                        If Not IsDBNull(TMPCheck.Item("MBTRANSRSVTRANSUID")) Then
                            Me.Cursor = Cursors.Default
                            ShowMessage(Me, "Maaf, transaksi penggabungan tagihan tidak dapat dilakukan, karena meja '" & TableList.Item(i, 2) & "' mempunyai data reservasi !")
                            Exit Sub
                        End If

                        'Removed by Rudy (9 Juni 2011)
                        'Assign the down payment used value to variable(27 Jan 2011)
                        'If Not IsDBNull(TMPCheck.Item("MBTransDPVal")) Then
                        '    DPVal = TMPCheck.Item("MBTransDPVal")
                        'End If

                        ''Update the down payment value of joined transaction(27 Jan 2011)
                        'Query = "UPDATE MBTRANS SET MBTransDPVal=MBTransDPVal + " & DPVal & " WHERE MBTRANSUID = '" & TransactionUID & "'"
                        'Call MyDatabase.MyAdapter(Query)
                        'End

                        Query = "UPDATE MBTRANS SET MBTRANSCANCELLEDNOTE='" & ReplacePetik(NoteTxt.Text) & "' WHERE MBTRANSUID = '" & DestTransUID & "'"
                        Call MyDatabase.MyAdapter(Query)

                        '3 Des 2011 - Anjo, jgn lupa update modified time untuk source dan target table untuk multi user
                        Query = "UPDATE MBTRANS SET MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSUID LIKE '" & TransactionUID & "' OR MBTRANSUID LIKE '" & DestTransUID & "'"
                        Call MyDatabase.MyAdapter(Query)

                        'Anjo - 31 Okt - too much junk
                        'Dim TMPRecord As FbDataReader
                        'Dim DetailList As New ArrayList
                        'DetailList = GetMBTransDetail(TransactionUID)
                        'TMPRecord = MyDatabase.MyReader("SELECT * FROM MBTRANSDT WHERE MBTRANSUID = '" & DestTransUID & "'")

                        'While TMPRecord.Read
                        '    Query = "UPDATE MBTRANSDT SET MBTRANSDTITEMDISCUID1=NULL, MBTRANSDTITEMDISCVAL1='0', MBTRANSDTITEMDISCUID2=NULL, MBTRANSDTITEMDISCVAL2='0', MBTRANSUID ='" & TransactionUID & "', MODIFIEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "', MODIFIEDUSER ='" & UserInformation.UserName & "' WHERE MBTRANSDTUID = '" & TMPRecord.Item("MBTRANSDTUID") & "'"
                        '    Call MyDatabase.MyAdapter(Query)
                        'End While
                        'TMPRecord = Nothing

                        Query = "UPDATE MBTRANSDT SET MBTRANSDTITEMDISCUID1=NULL, MBTRANSDTITEMDISCVAL1='0', MBTRANSDTITEMDISCUID2=NULL, MBTRANSDTITEMDISCVAL2='0', MBTRANSUID ='" & TransactionUID & "', MODIFIEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "', MODIFIEDUSER ='" & UserInformation.UserName & "' WHERE MBTRANSDTUID IN (SELECT MBTRANSDTUID FROM MBTRANSDT WHERE MBTRANSUID='" & DestTransUID & "')"
                        Call MyDatabase.MyAdapter(Query)

                    End If
                Next
            End With

            'Call MainPage.TableReset(True)
            'Call MainPage.TableSelected(selectedObject, myEvent)
            Call MainPage.TableResetAndSelect(selectedObject, myEvent, True)
            Me.Cursor = Cursors.Default
            Me.Close()
        Else
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Silakan pilih meja terlebih dahulu !")
            Exit Sub
        End If
    End Sub

    Private Sub VirtualKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKey.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(NoteTxt, False)
        VirtuKey.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancel.Click
        Call MainPage.TableClickInfo(selectedObject, myEvent)
        Me.Close()
    End Sub

#End Region

    Private Sub FocusMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMoveUp.Click, BTNMoveDown.Click
        With TableList
            If .Rows.Count > -1 Then
                Select Case sender.name
                    Case "BTNMoveUp"
                        If .Row > 0 Then .Row = .Row - 1
                        TableList_MouseDown(sender, e)
                    Case "BTNMoveDown"
                        If .Row < .Rows.Count - 1 Then .Row = .Row + 1
                        TableList_MouseDown(sender, e)
                End Select
            End If
        End With
    End Sub
End Class