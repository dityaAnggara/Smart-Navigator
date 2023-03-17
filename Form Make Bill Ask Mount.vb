Imports FirebirdSql.Data.FirebirdClient

Public Class Form_Make_Bill_Ask_Mount

    Public ParentOBJForm As Object
    Public isPercentValue As Boolean = False

    Private Sub Form_Make_Bill_Ask_Mount_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If isPercentValue Then
            LabelPercent.Text = "(%)"
            MountValueTxt.MaxLength = 3
        Else
            LabelPercent.Text = "(Rp)"
            MountValueTxt.MaxLength = 20
        End If
    End Sub

    Private Sub BTNOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNOK.Click
        If CStr(MountValueTxt.Text) = Nothing Or Val(MountValueTxt.Text) < 0 Then
            ShowMessage(Me, "Silakan isikan nilai yang valid !")
            MountValueTxt.Focus()
            Exit Sub
        End If
        If isPercentValue Then
            If MountValueTxt.Text > 100 Then
                MountValueTxt.Text = 100
                ParentOBJForm.AskMountValue = Val(MountValueTxt.Text)
                Me.Close()
            Else
                ParentOBJForm.AskMountValue = Val(MountValueTxt.Text)
                Me.Close()
            End If
        Else
            ParentOBJForm.AskMountValue = Val(MountValueTxt.Text)
            Me.Close()
        End If
    End Sub

    Private Sub BTNClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClose.Click
        ParentOBJForm.AskMountValue = -1
        Me.Close()
    End Sub
End Class