Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class Payment_Sub_Payment58
    Dim iRow As Long = 0

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        PaymentTotalLabel.Value = FormatNumber(PaymentTotalLabel.Text, DijitKoma, , , TriState.True)

        If BankNameLabel.Value <> Nothing Then
            BankNameLabel.Visible = True
            CheqNumberLabel.Visible = True
            CheqNameLabel.Visible = True

            CheqName.Visible = True
            CheqNumber.Visible = True


            CheqNumber.Value = "Card-Number "
            CheqName.Value = "Card-Holder"

            Detail1.Height = 0.78
        Else
            BankNameLabel.Visible = False
            CheqNumberLabel.Visible = False
            CheqNameLabel.Visible = False

            CheqName.Visible = False
            CheqNumber.Visible = False

            Detail1.Height = 0.19
        End If

        If Me.iRow Mod 2 = 1 Then
            Me.Detail1.BackColor = Color.White
        Else
            Me.Detail1.BackColor = Color.White
            'Me.Detail1.BackColor = Color.Ivory
        End If

        Me.iRow = Me.iRow + 1
        Me.NomorLabel.Text = Me.iRow.ToString

        If publicUseChange = False Then Exit Sub
        If Me.iRow = 1 Then
            PaymentTotalLabel.Text = FormatNumber(publicPayment1, DijitKoma)
        ElseIf Me.iRow = 2 Then
            PaymentTotalLabel.Text = FormatNumber(publicPayment2, DijitKoma)
        ElseIf Me.iRow = 3 Then
            PaymentTotalLabel.Text = FormatNumber(publicPayment3, DijitKoma)
        ElseIf Me.iRow = 4 Then
            PaymentTotalLabel.Text = FormatNumber(publicPayment4, DijitKoma)
        Else
            PaymentTotalLabel.Text = FormatNumber(publicPayment5, DijitKoma)
        End If

    End Sub

    Private Sub Payment_Sub_Payment_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        If publicUseChange = True Then
            PaymentTotalLabel.Text = 0
            PaymentTotalLabel.DataField = Nothing
        End If

    End Sub
End Class

