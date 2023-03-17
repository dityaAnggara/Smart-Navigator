Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class Make_Bill_Room_Gift

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        If CStr(txtBarcodeSupport.Text) = "1" Then
            Barcode1.Visible = True
            Detail1.Height = 0.677
        Else
            Barcode1.Visible = False
            Detail1.Height = 0.188
        End If
        If IsDBNull(txtExpiredDate.Text) = False Then
            If Trim(txtExpiredDate.Text) <> "" Then
                txtExpiredDate.Text = "Exp " & Format(CDate(txtExpiredDate.Text), "dd/MM/yyyy").ToString
            End If
        Else
            txtExpiredDate.Text = ""
        End If
    End Sub
End Class
