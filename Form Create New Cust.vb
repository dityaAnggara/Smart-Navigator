Imports FirebirdSql.Data.FirebirdClient

Public Class Form_Create_New_Cust    

    Public pubIDCustomer As String = Nothing

    Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click        
        If Trim(txtNamaCustomer.Text) = "" Then
            ShowMessage(Me, "Maaf, nama customer tidak boleh kosong !", True)
            txtNamaCustomer.Focus() : Exit Sub
        ElseIf Trim(txtTelp.Text) = "" Then
            ShowMessage(Me, "Maaf, telpon tidak boleh kosong !", True)
            txtTelp.Focus() : Exit Sub
        ElseIf cmbKategori.Row = -1 Then
            ShowMessage(Me, "Maaf, silahkan pilih kategori customer !", True)
            cmbKategori.Focus() : Exit Sub
        End If
        'Query = "INSERT INTO CUST (CUSTUID, CUSTNO, CUSTNAME, CUSTADDR1, CUSTCITYPROVZIPCODE, CUSTCONTACTNAME, CUSTTELP1, CUSTFAX, CUSTEMAIL, CUSTWEBSITE, CUSTCATUID, CUSTDFTLVLSELLPRICE, CUSTACTV, CUSTISDFT) VALUES('" & ReplacePetik(LastID) & "','" & ReplacePetik(CustNo.Text) & "','" & ReplacePetik(CustName.Text) & "','" & ReplacePetik(AddressTxt.Text) & "','" & ReplacePetik(CityTxt.Text) & "','" & ReplacePetik(CPTxt.Text) & "','" & ReplacePetik(NoTelpTxt.Text) & "','" & ReplacePetik(NoFaxTxt.Text) & "','" & ReplacePetik(Emailtxt.Text) & "','" & ReplacePetik(WebSiteTxt.Text) & "','" & ReplacePetik(CategoryList.Columns(1).Text) & "','" & ReplacePetik(PriceList.Columns(1).Text) & "','" & IIf(Checker.Checked, 1, 0) & "','" & IIf(chkBoxDefaultCustomer.Checked, 1, 0) & "')"
        If pubIDCustomer = Nothing Then
            Dim idCustomer As String = AutoUID()
            Call MyDatabase.MyAdapter("INSERT INTO CUST (CUSTUID, CUSTNO, CUSTNAME, CUSTADDR1, CUSTCITYPROVZIPCODE, CUSTCONTACTNAME, CUSTTELP1, CUSTFAX, CUSTEMAIL, CUSTWEBSITE, CUSTCATUID, CUSTDFTLVLSELLPRICE, CUSTACTV, CUSTISDFT) VALUES('" & ReplacePetik(idCustomer) & "','" & ReplacePetik(AutoIDNumber("2111", "CUST", "CUSTNO", True)) & "','" & ReplacePetik(txtNamaCustomer.Text) & "','" & ReplacePetik(txtAlamat.Text) & "','','','" & ReplacePetik(txtTelp.Text) & "','','','','" & ReplacePetik(cmbKategori.Columns(1).Text) & "','1','0','0')")
            pubIDCustomer = idCustomer
        Else
            MyDatabase.MyAdapter("UPDATE CUST SET CUSTNAME='" & ReplacePetik(txtNamaCustomer.Text) & "',CUSTADDR1='" & ReplacePetik(txtAlamat.Text) & "',CUSTTELP1='" & ReplacePetik(txtTelp.Text) & "',CUSTCATUID='" & ReplacePetik(cmbKategori.Columns(1).Text) & "' WHERE CUSTUID='" & pubIDCustomer & "'")
        End If
        Application.DoEvents()
        Me.Close()
    End Sub

    Private Sub fillCmbKategori()
        Dim rs As FbDataReader
        rs = MyDatabase.MyReader("SELECT * FROM CUSTCAT ORDER BY CUSTCATNAME")
        cmbKategori.HoldFields()
        While rs.Read()
            cmbKategori.AddItem(rs("CUSTCATNAME") & ";" & rs("CUSTCATUID"))
        End While
        MyDatabase.ConnectionDatabase.Close()
        rs = Nothing
    End Sub

    Private Sub Form_Create_New_Cust_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Location = New System.Drawing.Point((MainPage.Size.Width / 2), MainPage.Location.Y + 45)
        Call fillCmbKategori()
        If pubIDCustomer = Nothing Then Exit Sub
        Call fillForm()        
    End Sub

    Private Sub fillForm()
        Dim rs As FbDataReader
        Dim i As Long = 0
        rs = MyDatabase.MyReader("SELECT * FROM CUST WHERE CUSTUID='" & pubIDCustomer & "'")
        While rs.Read()
            txtNamaCustomer.Text = rs("CUSTNAME")
            txtAlamat.Text = rs("CUSTADDR1")
            txtTelp.Text = rs("CUSTTELP1")
            For i = 0 To cmbKategori.ListCount - 1
                cmbKategori.SelectedIndex = i
                If Trim(CStr(cmbKategori.Columns(1).Text)) = Trim(CStr(rs("CUSTCATUID"))) Then
                    Exit For
                End If
            Next
        End While
        rs = Nothing
    End Sub

    Private Sub BTNClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClose.Click
        Me.Close()
    End Sub

    Private Sub txtNamaCustomer_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtNamaCustomer.MouseDown
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(txtNamaCustomer, False)
        VirtuKey.ShowDialog()
        If Len(Trim(txtNamaCustomer.Text)) > 40 Then
            txtNamaCustomer.Text = Strings.Left(Trim(txtNamaCustomer.Text), 40)
        End If
    End Sub

    Private Sub txtNamaCustomer_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtNamaCustomer.TextChanged

    End Sub

    Private Sub txtAlamat_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtAlamat.MouseDown
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(txtAlamat, False)
        VirtuKey.ShowDialog()
        If Len(Trim(txtAlamat.Text)) > 80 Then
            txtAlamat.Text = Strings.Left(Trim(txtAlamat.Text), 80)
        End If
    End Sub

    Private Sub txtAlamat_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtAlamat.TextChanged

    End Sub

    Private Sub txtTelp_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtTelp.MouseDown
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(txtTelp, False)
        VirtuKey.ShowDialog()
        If Len(Trim(txtTelp.Text)) > 14 Then
            txtTelp.Text = Strings.Left(Trim(txtTelp.Text), 14)
        End If
    End Sub

    Private Sub txtTelp_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTelp.TextChanged

    End Sub
End Class