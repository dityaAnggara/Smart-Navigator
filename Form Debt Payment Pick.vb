Imports FirebirdSql.Data.FirebirdClient

Public Class Form_Debt_Payment_Pick

#Region "Variable Reference"

    Public ParentOBJForm As Object

    'Add By Rudy (16 Mar 2011)
    Public Invoice As Boolean = False

#End Region

#Region "Initialize & Object Function"

    Public Sub BasicInitialize(Optional ByVal SearchNo As String = Nothing, Optional ByVal SearchName As String = Nothing)
        Dim TMPTrans As FbDataReader
        Dim x As Integer = 0
        Dim Rest As Decimal = 0

        Try
            TMPTrans = MyDatabase.MyReader("SELECT * FROM MBTRANS MB WHERE MB.MBTRANSDEPTUID='" & UserInformation.UserDeptUID & "' AND MB.MBTRANSTOTVAL > MB.MBTRANSPAIDVAL AND MB.MBTRANSSTAT = 3 AND (upper(MBTRANSNO) LIKE '%" & ReplacePetik(UCase(SearchNo)) & "%' AND UPPER(MBTRANSCUSTNAME) LIKE '%" & ReplacePetik(UCase(SearchName)) & "%') AND CAST(MBTRANSDATE AS DATE) BETWEEN '" & Format(FromDate.Value, "MM/dd/yyyy") & "' AND '" & Format(ToDate.Value, "MM/dd/yyyy") & "' ORDER BY MBTRANSNO")
            With TableList
                .Redraw = False
                .Rows.Count = 1
                While TMPTrans.Read()
                    x = x + 1

                    Rest = TMPTrans.Item("MBTRANSTOTVAL") - TMPTrans.Item("MBTRANSPAIDVAL")
                    TableList.AddItem(TMPTrans.Item("MBTRANSUID") & vbTab & TMPTrans.Item("MBTRANSNO") & vbTab & FormatDateTime(TMPTrans.Item("MBTRANSDATE"), DateFormat.ShortDate) & vbTab & FormatDateTime(TMPTrans.Item("MBTRANSDATE"), DateFormat.ShortTime) & vbTab & TMPTrans.Item("MBTRANSCUSTUID") & vbTab & TMPTrans.Item("MBTRANSCUSTNAME") & vbTab & vbTab & vbTab & Rest & vbTab & TMPTrans.Item("CREATEDUSER"))

                    .Rows(x).Height = 45
                End While
                .Redraw = True
            End With
        Catch ex As Exception

        End Try
        TMPTrans = Nothing
    End Sub

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

#End Region

#Region "Form Control Function"

    Private Sub Form_Debt_Payment_Pick_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If MainPage.InvoiceApplication = True Then
            Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 45)
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.Width = 1024
            Me.Height = 700
            TableList.Width = 1005 : TableList.Height = 500
            GroupBox2.Width = 1005
            GroupBox2.Top = 616
            BTNOK.Left = 696
            BTNCancel.Left = 847
        Else
            Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 44)
            TableList.Cols(5).Width = 200
            TableList.Cols(8).Width = 130
        End If

        FromDate.Value = Month(Now) & "/" & "1/" & Year(Now)
        ToDate.Value = Now.Date

        FromDateLabel.Text = Format(FromDate.Value, "dd MMMM yyyy")
        ToDateLabel.Text = Format(ToDate.Value, "dd MMMM yyyy")

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
            Me.Cursor = Cursors.WaitCursor
            Dim OBJNew As New Form_Debt_Payment_List
            OBJNew.Name = "Form_Debt_Payment_List"
            OBJNew.ParentOBJForm = Me
            'Add By Rudy (16 Mar 2011)
            If Invoice = True Then
                OBJNew.Invoice = True
            End If
            OBJNew.MBTransUID = TableList.Item(TableList.Row, 0)
            OBJNew.ShowDialog()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub TableList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TableList.DoubleClick
        If TableList.Row > 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim OBJNew As New Form_Debt_Payment_List
            OBJNew.Name = "Form_Debt_Payment_List"
            OBJNew.ParentOBJForm = Me
            'Add By Rudy (16 Mar 2011)
            If Invoice = True Then
                OBJNew.Invoice = True
            End If
            OBJNew.MBTransUID = TableList.Item(TableList.Row, 0)
            OBJNew.ShowDialog()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancel.Click
        Me.Close()
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
#End Region

    Private Sub VirtualDateFromDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualDateFromDate.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtualDate As New Form_Virtual_Date
        VirtualDate.Name = "Form_Virtual_Date"
        VirtualDate.Text = "Please Select Date"
        VirtualDate.ParentOBJForm = Me
        VirtualDate.publicChosenDate = FromDate.Value
        VirtualDate.ShowDialog()

        FromDate.Text = VirtualDate.publicChosenDate
        FromDateLabel.Text = Format(FromDate.Value, "dd MMMM yyyy")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VirtualDateToDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualDateToDate.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtualDate As New Form_Virtual_Date
        VirtualDate.Name = "Form_Virtual_Date"
        VirtualDate.Text = "Please Select Date"
        VirtualDate.ParentOBJForm = Me
        VirtualDate.publicChosenDate = ToDate.Value
        VirtualDate.ShowDialog()

        ToDate.Text = VirtualDate.publicChosenDate
        ToDateLabel.Text = Format(ToDate.Value, "dd MMMM yyyy")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TableList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableList.Click

    End Sub
End Class