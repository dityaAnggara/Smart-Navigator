Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class Make_Bill_Sub_Item_Room

    Dim iRow As Long = 0
    Dim TMenu As Decimal = 0

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        If CStr(Trim(TextBox2.Text)) = "60" Then TextBox2.Text = "1 Jam" Else TextBox2.Text = TextBox2.Text & " Mnt"
        TextBox3.Text = FormatNumber(TextBox3.Text, DijitKoma, , , TriState.True)
        TextBox4.Text = FormatNumber(TextBox4.Text, DijitKoma, , , TriState.True)
    End Sub

    Private Sub Make_Bill_Sub_Item_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart

    End Sub
End Class
