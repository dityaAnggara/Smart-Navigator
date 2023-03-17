Public Class Form_Select_Printer
    Public Batal As Boolean

    Private Sub BTNNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNNo.Click
        Batal = True
        Me.Close()
    End Sub

    Private Sub BTNYes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNYes.Click
        Batal = False
        Me.Close()
    End Sub

    Private Sub picBoxLocal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picBoxLocal.Click

        If chkLocalPrinter.Checked = True Then
            chkLocalPrinter.Checked = False
            picBoxLocal.Image = picBoxLocalOff.Image
        ElseIf chkLocalPrinter.Checked = False Then
            chkLocalPrinter.Checked = True
            picBoxLocal.Image = picBoxLocalOn.Image
        End If

    End Sub

    Private Sub picBoxKitchen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles picBoxKitchen.Click

        If chkKitchenPrinter.Checked = True Then
            chkKitchenPrinter.Checked = False
            picBoxKitchen.Image = picBoxKitchenOff.Image
        ElseIf chkKitchenPrinter.Checked = False Then
            chkKitchenPrinter.Checked = True
            picBoxKitchen.Image = picBoxKitchenOn.Image
        End If

    End Sub

    Private Sub picBoxLocal_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles picBoxLocal.MouseEnter

        Me.Cursor = Cursors.Hand

    End Sub

    Private Sub picBoxKitchen_MouseEnter(ByVal sender As Object, ByVal e As System.EventArgs) Handles picBoxKitchen.MouseEnter

        Me.Cursor = Cursors.Hand

    End Sub

    Private Sub picBoxKitchen_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles picBoxKitchen.MouseLeave

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub picBoxLocal_MouseLeave(ByVal sender As Object, ByVal e As System.EventArgs) Handles picBoxLocal.MouseLeave

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub GroupBox1_Enter(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupBox1.Enter

    End Sub

    Private Sub GroupBox1_MouseMove(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles GroupBox1.MouseMove

    End Sub
End Class