Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class Reservation_Sub_Item58

    Dim iRow As Long = 0

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        If Label1.Text = "" Then
            Label1.Visible = False
            TextBox1.Visible = False
            Detail1.Height = 0
        Else
            If PrefInfo.PRINTQUANTITYDETAILPACKET = "1" Then
                Label1.Visible = True
            Else
                Label1.Visible = False
            End If
            TextBox1.Visible = True
            Detail1.Height = 0.2
        End If
    End Sub

    Private Sub Reservation_Sub_Item_NoData(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.NoData
        Cancel()
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        If CDbl(ReservationItemQtyLabel.Text) <> 1 Then
            GroupHeader1.Height = 0.2
            ReservationItemName.Value = ReservationItemName.Text & vbCrLf & " @" & FormatNumber(ReservationItemPriceLabel.Text, DijitKoma, , TriState.True)
        Else
            GroupHeader1.Height = 0.2
        End If

        ReservationItemSubTotalPriceLabel.Value = FormatNumber(ReservationItemPriceLabel.Text * ReservationItemQtyLabel.Text, DijitKoma, , , TriState.True)

        If Me.iRow Mod 2 = 1 Then
            Me.GroupHeader1.BackColor = Color.White
        Else
            Me.GroupHeader1.BackColor = Color.White
        End If
        Me.iRow = Me.iRow + 1
    End Sub
End Class
