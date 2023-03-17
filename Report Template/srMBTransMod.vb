
Public Class srMBTransMod
    Public Shared mIsPrintNote As String = ""
    Dim iRow As Long = 0

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

        If mIsPrintNote = "True" Then
            If Trim(txtNoteHidden.Text) = "" Then
                txtNote.Visible = False
                Detail1.Height = 0.198
            Else
                txtNote.Text = "(" & txtNoteHidden.Text & ")"
                txtNote.Visible = True
                Detail1.Height = 0.375
            End If
        Else
            txtNote.Visible = False
            Detail1.Height = 0.198
        End If
        ItemName.Text = "+" & ItemName.Text
        If txtTA.Text = "1" Then
            txtTakeAway.Visible = True
        Else
            txtTakeAway.Visible = False
        End If

        If Me.iRow Mod 2 = 1 Then
            Me.Detail1.BackColor = Color.White
        Else
            Me.Detail1.BackColor = Color.White
        End If
        Me.iRow = Me.iRow + 1
    End Sub

    Private Sub srMBTransMod_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart

    End Sub
End Class
