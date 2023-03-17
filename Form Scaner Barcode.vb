Public Class Form_Scaner_Barcode

    Public mbTransUID As String
    Public dateTrans As Date

    Private Sub txtBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode <> Keys.Return Then Exit Sub
        If Trim(txtBarcode.Text) = "" Then Exit Sub
        If totalRow("SALESPROMOREG WHERE LOWER(SALESPROMOREGPROMOGENERATEDNO)='" & ReplacePetik(LCase(txtBarcode.Text)) & "'") = 0 Then
            ShowMessage(Me, "Maaf, Data gift Anda tidak ditemukan !")
            Exit Sub
        ElseIf totalRow("SALESPROMOREG WHERE LOWER(SALESPROMOREGPROMOGENERATEDNO)='" & ReplacePetik(LCase(txtBarcode.Text)) & "' AND SALESPROMOREGUSAGETRANSUID IS NOT NULL") > 0 Then
            ShowMessage(Me, "Maaf, Data gift sudah terpakai !")
            Exit Sub
        ElseIf totalRow("SALESPROMOREG WHERE LOWER(SALESPROMOREGPROMOGENERATEDNO)='" & ReplacePetik(LCase(txtBarcode.Text)) & "' AND SALESPROMOREGPROMOEXPIREDDATE<'" & Format(Now.Date, "yyyy/MM/dd") & "' AND SALESPROMOREGPROMOEXPIREDDATE IS NOT NULL") > 0 Then
            ShowMessage(Me, "Maaf, Data gift Anda sudah expired !")
            Exit Sub
        End If
        Dim tmpIDMBTrans As String = txtBarcode.Text
        If ShowQuestion(Me, "Konfirmasi atas transaksi penukaran Gift ?", True) = False Then txtBarcode.Focus() : Exit Sub
        MyDatabase.MyAdapter("UPDATE SALESPROMOREG SET SALESPROMOREGUSAGETRANSUID='" & mbTransUID & "' WHERE SALESPROMOREGPROMOGENERATEDNO='" & ReplacePetik(tmpIDMBTrans) & "'")
        txtBarcode.Text = ""
        txtBarcode.Focus()
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub VirtualKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKey.Click
        txtBarcode.Text = ""
        Application.DoEvents()
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(txtBarcode, False)
        VirtuKey.ShowDialog()

        If Trim(txtBarcode.Text) = "" Then Exit Sub
        If totalRow("SALESPROMOREG WHERE LOWER(SALESPROMOREGPROMOGENERATEDNO)='" & ReplacePetik(LCase(txtBarcode.Text)) & "'") = 0 Then
            ShowMessage(Me, "Maaf, Data gift Anda tidak ditemukan !")
            Exit Sub
        ElseIf totalRow("SALESPROMOREG WHERE LOWER(SALESPROMOREGPROMOGENERATEDNO)='" & ReplacePetik(LCase(txtBarcode.Text)) & "' AND SALESPROMOREGUSAGETRANSUID IS NOT NULL") > 0 Then
            ShowMessage(Me, "Maaf, Data gift sudah terpakai !")
            Exit Sub
        ElseIf totalRow("SALESPROMOREG WHERE LOWER(SALESPROMOREGPROMOGENERATEDNO)='" & ReplacePetik(LCase(txtBarcode.Text)) & "' AND SALESPROMOREGPROMOEXPIREDDATE<'" & Format(dateTrans.Date, "yyyy/MM/dd") & "' AND SALESPROMOREGPROMOEXPIREDDATE IS NOT NULL") > 0 Then
            ShowMessage(Me, "Maaf, Data gift Anda sudah expired !")
            Exit Sub
        End If
        Dim tmpIDMBTrans As String = txtBarcode.Text
        If ShowQuestion(Me, "Konfirmasi atas transaksi penukaran Gift ?", True) = False Then txtBarcode.Focus() : Exit Sub
        MyDatabase.MyAdapter("UPDATE SALESPROMOREG SET SALESPROMOREGUSAGETRANSUID='" & mbTransUID & "' WHERE SALESPROMOREGPROMOGENERATEDNO='" & ReplacePetik(tmpIDMBTrans) & "'")
        Application.DoEvents()
        txtBarcode.Text = ""
    End Sub

    Private Sub txtBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarcode.TextChanged

    End Sub
End Class