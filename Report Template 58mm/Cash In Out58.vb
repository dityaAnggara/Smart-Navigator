Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports System.Drawing.Printing

Public Class Cash_In_Out58

  Private Sub Make_Bill_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
    Me.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF")
  End Sub

  Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
    CompanyNameText.Value = CompanyInformation.CompanyName
    CompanyAddressText.Value = CompanyInformation.Address & ", " & CompanyInformation.City
    CompanyPhoneText.Value = IIf(pubIsDemo = True, "=Demo Version=", "Phone : " & CompanyInformation.Phone & "    Fax : " & CompanyInformation.Fax)
  End Sub

  Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
    BillNoLabel.Text = BillNoLabel.Text & "  " & Format(TransactionDateLabel.Value, "dd/MM/yyyy HH:mm")
    txtPaymentType.Text = "Tipe Pembayaran : " & txtPaymentType.Text
    txtTipeTransaksi.Text = "Tipe Transaksi  : " & txtTipeTransaksi.Text
    Label1.Text = "Nilai : " & FormatNumber(IIf(Val(Label1.Text) < 0, Val(Label1.Text) * (-1), Val(Label1.Text)), DijitKoma, , , TriState.True).ToString
  End Sub
End Class
