Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class Reservation_Sub_Payment58

    Dim iRow As Long = 0

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        PaymentTotalLabel.Value = FormatNumber(PaymentTotalLabel.Text, DijitKoma, , , TriState.True)

        If BankNameLabel.Value <> Nothing Then
            BankNameLabel.Visible = True
            CheqNumberLabel.Visible = True
            CheqNameLabel.Visible = True

            CheqName.Visible = True
            CheqNumber.Visible = True

            CheqNumber.Value = "Card-Number : "
            CheqName.Value = "Card-Holder : "

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
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        Label1.Value = Format(Label1.Value, "dd/MM/yyyy HH:mm")
        If PaymentNoText.Value <> "" Then
            PaymentNoText.Value = PaymentNoText.Value & "  " & Label1.Value
        Else
            PaymentNoText.Value = "DP : 0    " & Label1.Value
        End If
    End Sub
End Class
