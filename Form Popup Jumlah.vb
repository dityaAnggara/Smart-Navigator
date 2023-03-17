Public Class Form_Popup_Jumlah
    Public PubJmlMenu As Integer = 1
    Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

    Private Sub cmdBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBatal.Click
        PubJmlMenu = 0
        Me.Close()
    End Sub

    Private Sub cmdOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        PubJmlMenu = Val(txtJumlah.Text)
        Me.Close()
    End Sub

    Private Sub cmdTambah_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdTambah.Click
        txtJumlah.Text = Val(txtJumlah.Text) + 1
    End Sub

    Private Sub cmdKurang_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKurang.Click
        If Val(txtJumlah.Text) = 1 Then Exit Sub
        txtJumlah.Text = Val(txtJumlah.Text) - 1
    End Sub

    Private Sub Form_Popup_Jumlah_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Top = (screenHeight / 2) - (Me.Height / 2)
        Dim origWidth As Integer = Me.Width
        Dim origHeight As Integer = Me.Height
        Me.Width = screenWidth
        Dim fSize As New SizeF((Me.Width / origWidth), (Me.Height / origHeight))
        Panel1.Scale(fSize)
        dtabUtama.Scale(fSize)
    End Sub

    Private Sub Panel1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles Panel1.Paint

    End Sub
End Class