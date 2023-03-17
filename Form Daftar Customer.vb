Imports System
Imports C1.Win
Imports C1.Win.C1FlexGrid
Imports System.Windows.Forms
Imports System.Threading
Imports System.Globalization
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports FirebirdSql.Data.FirebirdClient

Public Class Form_Daftar_Customer

    Public idTable As String
    Public ShowForm As String
    Public idCustomer As String    

    Private Sub fillGrid(ByVal idCustVal As String)
        With ListDetail
            .Rows.Count = 1
            .Refresh()
            .Redraw = False
            .Styles("Normal").WordWrap = True
            Dim rs As FbDataReader
            If Trim(idCustVal) = "" Then
                rs = MyDatabase.MyReader("SELECT * FROM CUST WHERE CUSTACTV='0' ORDER BY CUSTNAME")
            Else
                rs = MyDatabase.MyReader("SELECT * FROM CUST WHERE CUSTACTV='0' AND CUSTUID='" & ReplacePetik(idCustVal) & "' ORDER BY CUSTNAME")
            End If
            While rs.Read
                .Rows.Add()
                '.AddItem("")                
                .Cols("id").Item(.Rows.Count - 1) = rs("CUSTUID")
                .Cols("customer").Item(.Rows.Count - 1) = rs("CUSTNAME")
                .Cols("address").Item(.Rows.Count - 1) = rs("CUSTADDR1")
                .Cols("telp").Item(.Rows.Count - 1) = rs("CUSTTELP1")
                .Rows(.Rows.Count - 1).Height = 50
                '.Rows.Item(1) = rs("CUSTNAME")
                '.AddItem(vbTab & rs("CUSTUID") & vbTab & rs("CUSTNAME") & vbTab & rs("CUSTADDR1"))
            End While
            rs = Nothing
            .Redraw = True
        End With
    End Sub

    Private Sub Form_Daftar_Customer_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 45)
        Call fillGrid("")
    End Sub

    Private Sub cmdClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdClose.Click
        Me.Close()
    End Sub

    Private Sub BTNNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNNew.Click
        Form_Create_New_Cust.pubIDCustomer = Nothing
        Form_Create_New_Cust.ShowDialog()
        If Form_Create_New_Cust.pubIDCustomer = Nothing Then Exit Sub
        Dim tmpIDCustomer As String
        tmpIDCustomer = Form_Create_New_Cust.pubIDCustomer
        Form_Create_New_Cust.Close()
        Call fillGrid(tmpIDCustomer)
    End Sub

    Private Sub ListDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListDetail.Click        
        
    End Sub

    Private Sub ListDetail_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListDetail.DoubleClick
        With ListDetail
            If ShowForm = "image" Then
                Form_Invoice_Image.Close()
                Form_Invoice_Image.tableUID = idTable
                Form_Invoice_Image.pubIDCustomer = .Rows(.Row).Item("id")
                Form_Invoice_Image.pubNamaCustomer = .Rows(.Row).Item("customer")
                Form_Invoice_Image.ShowDialog()
            Else
                Form_Invoice.Close()
                Form_Invoice.tableUID = idTable
                Form_Invoice.pubIDCustomer = .Rows(.Row).Item("id")
                Form_Invoice.pubNamaCustomer = .Rows(.Row).Item("customer")
                Form_Invoice.ShowDialog()
            End If
        End With
        Me.Close()
    End Sub

    Private Sub txtCari_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCari.Click

    End Sub

    Private Sub txtCari_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtCari.GotFocus
        
    End Sub

    Private Sub txtCari_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtCari.KeyDown
        If e.KeyCode = 13 Then Call fillGridCari()
    End Sub

    Private Sub txtCari_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtCari.MouseDown
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(txtCari, False)
        VirtuKey.ShowDialog()
        Call fillGridCari()
    End Sub

    Private Sub fillGridCari()
        Dim rs As FbDataReader
        With ListDetail
            .Rows.Count = 1
            .Refresh()
            .Redraw = False
            .Styles("Normal").WordWrap = True
            rs = MyDatabase.MyReader("SELECT * FROM CUST WHERE CUSTACTV='0' AND (UPPER(CUSTNAME) LIKE '%" & ReplacePetik(UCase(txtCari.Text)) & "%' OR UPPER(CUSTADDR1) LIKE '%" & ReplacePetik(UCase(txtCari.Text)) & "%' OR UPPER(CUSTADDR2) LIKE '%" & ReplacePetik(UCase(txtCari.Text)) & "%' OR UPPER(CUSTTELP1) LIKE '%" & ReplacePetik(UCase(txtCari.Text)) & "%' OR UPPER(CUSTFAX) LIKE '%" & ReplacePetik(UCase(txtCari.Text)) & "%') ORDER BY CUSTNAME")
            While rs.Read
                .Rows.Add()
                '.AddItem("")                
                .Cols("id").Item(.Rows.Count - 1) = rs("CUSTUID")
                .Cols("customer").Item(.Rows.Count - 1) = rs("CUSTNAME")
                .Cols("address").Item(.Rows.Count - 1) = rs("CUSTADDR1")
                .Cols("telp").Item(.Rows.Count - 1) = rs("CUSTTELP1")
                .Rows(.Rows.Count - 1).Height = 50
                '.Rows.Item(1) = rs("CUSTNAME")
                '.AddItem(vbTab & rs("CUSTUID") & vbTab & rs("CUSTNAME") & vbTab & rs("CUSTADDR1"))
            End While
            rs = Nothing
            .Redraw = True
        End With
    End Sub

    Private Sub txtCari_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtCari.TextChanged

    End Sub

    Private Sub cmdEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEdit.Click                
        Form_Create_New_Cust.pubIDCustomer = ListDetail.Rows(ListDetail.Row).Item("id")
        Form_Create_New_Cust.ShowDialog()
        If Form_Create_New_Cust.pubIDCustomer = Nothing Then Exit Sub
        Dim tmpIDCustomer As String
        tmpIDCustomer = Form_Create_New_Cust.pubIDCustomer
        Form_Create_New_Cust.Close()
        Call fillGrid(tmpIDCustomer)
    End Sub
End Class