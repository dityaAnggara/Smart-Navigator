Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win.C1FlexGrid
Public Class Form_Move_Table

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
        Call CheckPermission(UserInformation.UserTypeUID, True)
    End Sub
    Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)
        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2207'")
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
            TMPRecord = MyDatabase.MyReader("SELECT * FROM TABLELIST T LEFT OUTER JOIN FLOORNO F ON T.FLOORNOUID=F.FLOORNOUID WHERE F.FLOORDEPTUID ='" & DeptInfo.DeptUID & "' AND (TABLELISTACTV IS NULL OR TABLELISTACTV = 0 ) AND TABLEMBTRANSUID IS NULL ORDER BY TABLELISTNAME")
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

    Private Function GetTableSelected() As Integer
        For i As Integer = 0 To TableList.Rows.Count - 1
            If TableList.Item(i, 0) = True Then
                Return i
                Exit Function
            End If
        Next
    End Function

#End Region

#Region "Form Control Function"

    Private Sub Form_Move_Table_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
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

            NoteTxt.Text = ""
            NoteTxt.Text = "MOVE TABLE - TABLE " & TableList.Item(TableList.Row, 2)
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
                ShowMessage(Me, "Maaf, anda tidak dapat melakukan transaksi pindah meja, karena meja '" & SelectedTable.TableName & "' sudah dibuatkan bill tagihan !")
                Exit Sub
            End If
        End If

        Dim TMPCheckTable As FbDataReader
        TMPCheckTable = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLELISTUID = '" & SelectedTable.TableUID & "'")
        While TMPCheckTable.Read
            If IsDBNull(TMPCheckTable.Item("TABLEMBTRANSUID")) Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Maaf, anda tidak dapat melakukan transaksi pindah meja, karena status meja '" & SelectedTable.TableName & "' adalah kosong (tidak terisi customer) !")
                Exit Sub
            End If
        End While

        If TableList.Rows.Count > 0 Then
            If GetTableSelected() = -1 Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Silakan pilih meja tujuan !")
                Exit Sub
            End If

            If NoteTxt.Text = "" Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Silakan isikan alasan customer pindah meja !")
                Exit Sub
            End If

            Dim NewTableIndex As Integer = GetTableSelected(), Query As String

            Dim TMPCheck As FbDataReader
            TMPCheck = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLELISTUID = '" & TableList.Item(NewTableIndex, 1) & "'")
            While TMPCheck.Read
                If Not IsDBNull(TMPCheck.Item("TABLEMBTRANSUID")) Then
                    Me.Cursor = Cursors.Default
                    ShowMessage(Me, "Maaf, status meja '" & TableList.Item(NewTableIndex, 2) & "' sudah terisi, silakan pilih meja yang lain !")
                    Exit Sub
                End If
            End While

            Query = "UPDATE MBTRANS SET MBTRANSTABLELISTUID='" & TableList.Item(NewTableIndex, 1) & "' ,MBTRANSCANCELLEDNOTE='" & ReplacePetik(NoteTxt.Text) & "',MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSUID LIKE '" & TransactionUID & "'"
            Call MyDatabase.MyAdapter(Query)

            Query = "UPDATE MBTRANSTABLELIST SET MBTRANSTABLELISTUID='" & TableList.Item(NewTableIndex, 1) & "' WHERE MBTRANSTABLELISTUID LIKE '" & SelectedTable.TableUID & "'"
            Call MyDatabase.MyAdapter(Query)

            Query = "UPDATE TABLELIST SET TABLEMBTRANSUID=NULL WHERE TABLELISTUID = '" & SelectedTable.TableUID & "'"
            Call MyDatabase.MyAdapter(Query)

            Query = "UPDATE TABLELIST SET TABLEMBTRANSUID='" & TransactionUID & "' WHERE TABLELISTUID LIKE '" & TableList.Item(NewTableIndex, 1) & "'"
            Call MyDatabase.MyAdapter(Query)

            'Call MainPage.TableReset(True)
            'Call MainPage.TableSelected(selectedObject, myEvent)
            Call MainPage.TableResetAndSelect(selectedObject, myEvent, True)
            Me.Cursor = Cursors.Default

            Me.Close()
        Else
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Silakan pilih meja tujuan !")
        End If

        Me.Cursor = Cursors.Default

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

    Private Sub TableList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableList.Click

    End Sub
End Class