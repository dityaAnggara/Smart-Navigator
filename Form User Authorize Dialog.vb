Public Class Form_User_Authorize_Dialog
    Public ParentOBJForm As Object
    Public NeedAuthorizationForMakeBill As Boolean
    
    Private Sub Form_User_Authorize_Dialog_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        'Me.Location = New System.Drawing.Point(230, 333)
        If NeedAuthorizationForMakeBill = True Then
            LabelInformation.Text = "Anda membutuhkan otorisasi manager untuk melakukan perubahan bill tagihan !"
        Else
            LabelInformation.Text = "Anda membutuhkan otorisasi manager untuk menghapus order pesanan yang sudah diproses !"
        End If
    End Sub

    Private Sub BTNAuthorize_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNAuthorize.Click
        UUID = UserInformation.UserUID
        UName = UserInformation.UserName
        UOrderPoint = UserInformation.UserOrderPoint
        UTypeUID = UserInformation.UserTypeUID
        UDeptUID = UserInformation.UserDeptUID
        'Dim OBJNew As New Form_Sign_In
        'OBJNew.Name = "Form_Sign_In"
        'OBJNew.Cancel.Visible = False
        'OBJNew.BTNClose.Visible = True
        'OBJNew.BTNClose.Location = New System.Drawing.Point(408, 117)
        'OBJNew.ShowDialog()

        Dim OBJNew As New Form_Log_In
        OBJNew.Name = "Form_Log_In"
        OBJNew.authorisationMode = True
        OBJNew.BTNQuit.Visible = True

        OBJNew.ShowDialog()

        If OBJNew.loginSuccessful = False Then Exit Sub

        Authorize = True
        Call MainPage.StatusBarInitialize()
        Me.Close()
    End Sub

    Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancel.Click
        Me.Close()

    End Sub
End Class