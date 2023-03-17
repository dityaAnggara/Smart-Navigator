Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports FirebirdSql.Data.FirebirdClient

Public Class CheckIn

    Private Sub Reservation_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Me.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF")
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        'If PrefInfo.isInvisibleCode = "1" Then ReservationNoLabel.Visible = False Else ReservationNoLabel.Visible = True
        ReservationPaxLabel.Value = ReservationPaxLabel.Value.ToString '& " MALE"
        lblPaxFemale.Value = lblPaxFemale.Value.ToString & " FEMALE"
        lblShift.Text = "SHIFT : " & IIf(lblShift.Text = "1" Or lblShift.Text = "3", "1", "2")
        TransactionDateLabel.Value = Format(TransactionDateLabel.Value, "dd/MM/yyyy hh:mm tt")

        lblHargaPerJam.Value = "PRICE : " & FormatNumber(lblHargaPerJam.Value.ToString, 0) & "/PER-HOURS"

        ReservationDateLabel.Value = "TOTAL : " & ReservationDateLabel.Value & " MNT(S)"
        lblLamaSewa.Value = "FREE : " & lblLamaSewa.Value & " MNT(S)"

        CurrentDateLabel.Value = Format(Now, "dd/MM/yyyy hh:mm tt")
        ReservationPrintUserLabel.Value = UserInformation.UserName

        ReservationTimeLabel.Value = "IN : " & Format(ReservationTimeLabel.Value, "hh:mm tt")
        lblJamCheckOut.Value = "OUT : " & Format(lblJamCheckOut.Value, "hh:mm tt")

        ReservationTableText.Value = "TABLE : " & lblNamaTable.Text & " (" & lblNamaKategoriTable.Text & ")"
        ReservationPrinterCounterLabel.Value = "PRINT : " & ReservationPrinterCounterLabel.Value
        ReservationCreatedUserLabel.Value = "OP : " & ReservationCreatedUserLabel.Value
        Dim GrandTotal As Decimal = 0

        If PrefInfo.Footer = "" Then
            FooterText.Visible = False
        Else
            FooterText.Text = PrefInfo.Footer
        End If
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        CompanyNameText.Value = CompanyInformation.CompanyName
        CompanyAddressText.Value = CompanyInformation.Address & ", " & CompanyInformation.City
        CompanyPhoneText.Value = "Phone : " & CompanyInformation.Phone & "    Fax : " & CompanyInformation.Fax
    End Sub

End Class
