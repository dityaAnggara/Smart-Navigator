Public Class Form_Pop_Up_Open_Menu
    Public settingForm As String
    Public formAsal As Form
    Public dataMenu As String = ""
    Dim getForm As Form
    Dim arrData() As String

    Private Sub Form_Pop_Up_Open_Menu_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        Me.Close()
    End Sub

    Private Sub Form_Pop_Up_Open_Menu_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing
        settingForm = ""
    End Sub

    Private Sub Form_Pop_Up_Open_Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load                       
        arrData = Split(settingForm, MY_DELIMITER)
        If arrData(0) = "YES" Then
            If arrData(1).ToString = "NO" Then
                Me.Height = 84
            Else
                Me.Height = 151
            End If
        Else
            If arrData(1).ToString = "YES" Then
                cmdEditPaket.Top = cmdOpenMenu.Top
            End If
            Me.Height = 84
        End If
        Me.Location = New System.Drawing.Point(MainPage.Location.X + 48, MainPage.Location.Y + 150)
    End Sub

    Private Sub cmdOpenMenu_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOpenMenu.Click        
        If formAsal.Name.ToString = "Form_Reservation_Make_Order_Image" Then
            Dim tmpArr() As String = Split(dataMenu, MY_DELIMITER)
            Form_Edit_menu_On_MakeOrder.Close()
            With Form_Edit_menu_On_MakeOrder
                .Cancel = False
                .txtNamaMenu.Text = tmpArr(0)
                .txtHarga.Text = tmpArr(1)
                .ShowDialog(MainPage)
                If .Cancel = True Then Exit Sub
                Call Form_Reservation_Make_Order_Image.updateGrid(.txtNamaMenu.Text, (CDec(.txtHarga.Text)).ToString)
            End With
        ElseIf formAsal.Name.ToString = "Form_Reservation_Make_Order" Then
            Dim tmpArr() As String = Split(dataMenu, MY_DELIMITER)
            Form_Edit_menu_On_MakeOrder.Close()
            With Form_Edit_menu_On_MakeOrder
                .Cancel = False
                .txtNamaMenu.Text = tmpArr(0)
                .txtHarga.Text = tmpArr(1)
                .ShowDialog(MainPage)
                If .Cancel = True Then Exit Sub
                Call Form_Reservation_Make_Order.updateGrid(.txtNamaMenu.Text, (CDec(.txtHarga.Text)).ToString)
            End With
        ElseIf formAsal.Name.ToString = "Form_Make_Order_Image" Then
            Dim tmpArr() As String = Split(dataMenu, MY_DELIMITER)
            Form_Edit_menu_On_MakeOrder.Close()
            With Form_Edit_menu_On_MakeOrder
                .Cancel = False
                .txtNamaMenu.Text = tmpArr(0)
                .txtHarga.Text = tmpArr(1)
                .ShowDialog(MainPage)
                If .Cancel = True Then Exit Sub
                Call Form_Make_Order_Image.updateGrid(.txtNamaMenu.Text, (CDec(.txtHarga.Text)).ToString)
            End With
        ElseIf formAsal.Name.ToString = "Form_Make_Order" Then
            Dim tmpArr() As String = Split(dataMenu, MY_DELIMITER)
            Form_Edit_menu_On_MakeOrder.Close()
            With Form_Edit_menu_On_MakeOrder
                .Cancel = False
                .txtNamaMenu.Text = tmpArr(0)
                .txtHarga.Text = tmpArr(1)
                .ShowDialog(MainPage)
                If .Cancel = True Then Exit Sub
                Call Form_Make_Order.updateGrid(.txtNamaMenu.Text, (CDec(.txtHarga.Text)).ToString)
            End With
        End If
        Me.Close()
    End Sub

    Private Sub cmdEditPaket_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdEditPaket.Click
        Dim tmpArr() As String = Split(dataMenu, MY_DELIMITER)
        Edit_Detail_Paket.Close()
        Edit_Detail_Paket.formAsal = formAsal
        Edit_Detail_Paket.idMenu = tmpArr(2)
        Edit_Detail_Paket.idDetailReserv = tmpArr(3)
        Edit_Detail_Paket.ShowDialog(formAsal)
    End Sub
End Class