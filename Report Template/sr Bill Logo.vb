Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class srBillLogo
    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Picture1.Image = PreferenceLib.Logo
    End Sub
    Private Sub srBillLogo_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        Picture1.Dispose()
    End Sub

    Private Sub srBillLogo_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Dim ukuran As String = PrefInfo.logoSize
        Dim arrData() As String
        Dim h As Integer, w As Integer
        arrData = Split(ukuran, " x ")
        h = CInt(arrData(0)) : w = CInt(arrData(1))
        Picture1.Height = h / 100
        Picture1.Width = w / 100
        Picture1.Left = 1.25 - (Picture1.Width / 2)
        Detail1.Height = Picture1.Height + 0.013
    End Sub
End Class
