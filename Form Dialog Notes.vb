Public Class Dialog_Notes

    Public ParentOBJForm As Object
    Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

    Private Sub Dialog_Notes_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        Me.Close()
    End Sub

    Private Sub Dialog_Notes_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If screenWidth < 1024 Then
            Me.Left = 0
            Me.Top = (screenHeight / 2) - (Me.Height / 2)
            Dim origWidth As Integer = Me.Width
            Dim origHeight As Integer = Me.Height
            Me.Width = screenWidth
            Me.Height = Me.Height + 10
            Dim fSize As New SizeF((Me.Width / 582), (Me.Height / origHeight))
            GroupBox1.Scale(fSize)
        End If
        NotesTxt.Text = ParentOBJForm.ItemNotes

    End Sub

    Private Sub BTNClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClear.Click
        NotesTxt.Text = Nothing
    End Sub

    Private Sub VirtualKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKey.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(NotesTxt, False)
        VirtuKey.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click
        ParentOBJForm.ItemNotes = NotesTxt.Text
        Me.Close()
    End Sub

    Private Sub BTNClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClose.Click
        NotesTxt.Text = Nothing
        Me.Close()
    End Sub

End Class