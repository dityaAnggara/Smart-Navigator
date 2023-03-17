Public Class Form_Edit_menu_On_MakeOrder
    Public ParentOBJForm As Object
    Public pubHarga As Long
    Public pubNamaMenu As String
    Public Cancel As Boolean = False

    Private Sub Form_Input_Box_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        
    End Sub

    Private Sub BTNNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNNo.Click
        Cancel = True
        Me.Close()
    End Sub

    Private Sub VirtualCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdCalcPrice.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        VirtuCalculator.OBJBind(txtHarga)
        VirtuCalculator.showMoney = True
        VirtuCalculator.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TotalMove_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtHarga.KeyPress
        txtHarga.SelectionStart = Len(txtHarga.Text)
    End Sub

    Private Sub TotalMove_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtHarga.TextChanged

    End Sub

    Private Sub cmdKeyboardNamaMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdKeyboardNamaMenu.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(txtNamaMenu, False)
        VirtuKey.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdSimpan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSimpan.Click
        If Trim(txtNamaMenu.Text) = "" Then
            ShowMessage(Me, "Maaf, nama menu tidak boleh kosong !")
            txtNamaMenu.Focus() : Exit Sub
        End If
        Me.Close()
    End Sub
End Class