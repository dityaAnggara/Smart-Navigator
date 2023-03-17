Imports FirebirdSql.Data.FirebirdClient

Public Class Form_Customer_Pick
    Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

#Region "Variable Reference"

    Public ParentOBJForm As Object

#End Region

#Region "Initialize & Object Function"

    Private Sub BasicInitialize(Optional ByVal SearchNo As String = Nothing, Optional ByVal SearchName As String = Nothing)

        Dim TMPRecord As FbDataReader
        Dim I As Integer = 0
        Try

            TMPRecord = MyDatabase.MyReader("SELECT a.CUSTUID, a.CUSTNO, a.CUSTNAME, a.CUSTADDR1, a.CUSTCITYPROVZIPCODE, a.CUSTCATUID , (SELECT CUSTCATNAME FROM CUSTCAT WHERE CUSTCATUID = a.CUSTCATUID) AS CUSTCATNAME FROM CUST a WHERE (a.CUSTACTV IS NULL or a.CUSTACTV = '0') AND (upper(CUSTNO) LIKE '%" & ReplacePetik(UCase(SearchNo)) & "%' AND upper(CUSTNAME) LIKE '%" & ReplacePetik(UCase(SearchName)) & "%') ORDER BY a.CUSTNAME ASC, CUSTCATNAME ASC")

            With TableList
                .Redraw = False
                .Rows.Count = 1
                While TMPRecord.Read
                    I = I + 1
                    TableList.AddItem(TMPRecord.Item("CUSTNO") & vbTab & TMPRecord.Item("CUSTUID") & vbTab & TMPRecord.Item("CUSTNAME") & vbTab & TMPRecord.Item("CUSTADDR1") & vbTab & TMPRecord.Item("CUSTCITYPROVZIPCODE") & vbTab & TMPRecord.Item("CUSTCATUID") & vbTab & TMPRecord.Item("CUSTCATNAME"))
                    .Rows(I).Height = 45
                End While
                .Redraw = True
            End With

        Catch ex As Exception

        End Try
    End Sub

#End Region

#Region "Form Control Function"

    Private Sub Form_Customer_Pick_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If screenWidth < 1024 Then
            Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y)
            Label11.Text = "No"
            Label1.Text = "Cust"
            Dim origWidth As Integer = Me.Width
            Dim origHeight As Integer = Me.Height
            Me.Width = screenWidth
            Me.Height = screenHeight
            Dim fSize As New SizeF((Me.Width / 692), (Me.Height / origHeight))
            Panel1.Scale(fSize)
            TableList.Scale(fSize)
            GroupBox2.Scale(fSize)
        Else
            Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 44)
        End If
        TableList.Styles("Normal").WordWrap = True
        Call BasicInitialize()
    End Sub

    Private Sub VirtualKey1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKey1.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(FindName, False)
        VirtuKey.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VirtualKey2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKey2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(FindNo, False)
        VirtuKey.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub SearchByList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
        FindName.Text = Nothing
    End Sub

    Private Sub BTNSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSearch.Click
        With TableList
            Me.Cursor = Cursors.WaitCursor
            Call BasicInitialize(Trim(FindNo.Text), Trim(FindName.Text))
            Me.Cursor = Cursors.Default
        End With
    End Sub

    Private Sub FindNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FindNo.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNSearch_Click(sender, e)
        End If
    End Sub

    Private Sub FindName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FindName.KeyPress
        If e.KeyChar = Chr(13) Then
            BTNSearch_Click(sender, e)
        End If
    End Sub

    Private Sub BTNOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNOK.Click
        If TableList.Row > 0 Then
            Call ParentOBJForm.BringCustInfo(TableList.Item(TableList.Row, 1))
            Me.Close()
        End If
    End Sub

    Private Sub TableList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TableList.DoubleClick
        If TableList.Row > 0 Then
            Call ParentOBJForm.BringCustInfo(TableList.Item(TableList.Row, 1))
            Me.Close()
        End If
    End Sub

    Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancel.Click
        Me.Close()
    End Sub

#End Region
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

    Private Sub TableList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TableList.MouseDown
        If TableList.Rows.Count > 1 Then

            Dim NewStyle As C1.Win.C1FlexGrid.CellStyle
            NewStyle = TableList.Styles.Add("Click")
            NewStyle.BackColor = Color.LightCoral

            For i As Integer = 0 To TableList.Rows.Count - 1
                TableList.Item(i, 7) = False
                TableList.Rows(i).Style = Nothing
            Next
            TableList.Item(TableList.Row, 7) = True
            TableList.Rows(TableList.Row).Style = TableList.Styles("Click")
        End If
    End Sub
End Class