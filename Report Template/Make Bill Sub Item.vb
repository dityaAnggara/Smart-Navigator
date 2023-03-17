Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class Make_Bill_Sub_Item

    Dim iRow As Long = 0
    Dim TMenu As Decimal = 0

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        If Me.iRow Mod 2 = 1 Then
            Me.Detail1.BackColor = Color.White
        Else
            Me.Detail1.BackColor = Color.White
        End If
        Me.iRow = Me.iRow + 1

        If BillItemQty.Value > 1 Then
            BillItemName.Value = BillItemName.Text & vbCrLf & " @" & FormatNumber(Label38.Text, DijitKoma, , TriState.True)
        Else
            BillItemName.Value = BillItemName.Text
        End If

        BillItemPrice.Value = FormatNumber(Label38.Text * BillItemQty.Text, DijitKoma, , , TriState.True)
        TMenu = TMenu + BillItemPrice.Value

        If BillItemDisc1.Value <> 0 And BillItemDisc2.Value <> 0 Then
            Detail1.Height = 0.57
            LabelDisc1.Visible = True
            LabelDisc2.Visible = True
            BillItemDisc1.Visible = True
            BillItemDisc2.Visible = True
            BillItemDisc1.Value = "-" & FormatNumber(BillItemDisc1.Value, DijitKoma)
            BillItemDisc2.Value = "-" & FormatNumber(BillItemDisc2.Value, DijitKoma)
        End If

        If BillItemDisc1.Value <> 0 And BillItemDisc2.Value = 0 Then
            Detail1.Height = 0.375
            LabelDisc1.Visible = True
            BillItemDisc1.Visible = True
            LabelDisc2.Visible = False
            BillItemDisc2.Visible = False
            BillItemDisc1.Value = "-" & FormatNumber(BillItemDisc1.Value, DijitKoma)
            LabelDisc2.Location = New System.Drawing.PointF(0.375, 0.375)
            BillItemDisc2.Location = New System.Drawing.PointF(1.5, 0.375)
        End If

        If BillItemDisc1.Value = 0 And BillItemDisc2.Value = 0 Then
            Detail1.Height = 0.2
            LabelDisc1.Visible = False
            LabelDisc2.Visible = False
            BillItemDisc1.Visible = False
            BillItemDisc2.Visible = False
        End If

        If BillItemDisc1.Value = 0 And BillItemDisc2.Value <> 0 Then
            Detail1.Height = 0.375
            LabelDisc1.Visible = False
            BillItemDisc1.Visible = False
            LabelDisc2.Visible = True
            BillItemDisc2.Visible = True
            BillItemDisc2.Value = "-" & FormatNumber(BillItemDisc2.Value, DijitKoma)
            LabelDisc2.Location = New System.Drawing.PointF(0.375, 0.19)
            BillItemDisc2.Location = New System.Drawing.PointF(1.5, 0.19)
        End If

    End Sub

    Private Sub Make_Bill_Sub_Item_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart

    End Sub
End Class
