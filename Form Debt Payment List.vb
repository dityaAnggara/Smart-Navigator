Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win

Public Class Form_Debt_Payment_List

    Public ParentOBJForm As Object
    Public TransactionUID As String = Nothing
    Public MBTransUID As String = Nothing
    Public DPDetailListCollection As New Collection
    Dim UserPermition As New UserPermitionLib

    Public NewID As String = Nothing
    Public CurrentUID As String = Nothing
    Public ReservationNumber As String = Nothing
    Public CustUID As String = Nothing
    Public CustList As String = Nothing
    Public GrandTotal As String = Nothing
    Public CustName As String = Nothing
    Public Table As String = Nothing
    Public TableUID As String = Nothing
    Public DP As String = Nothing
    Public Lunas As Boolean = False
    'Add By Rudy (16 Mar 2011)
    Public Invoice As Boolean = False

    Public Sub BasicInitialize(ByVal MBTransUID As String)
        'Add By Rudy (Moved From Buttom) 16 Mar 2011

        Dim TMPRecord As FbDataReader
        Dim x As Integer = 0
        Call CheckPermission(UserInformation.UserTypeUID, True)
        Try
            TMPRecord = MyDatabase.MyReader("SELECT * FROM PBTRANS PB WHERE PB.PBTRANSMODULETYPEID='2206' AND PB.PBTRANSMBTRANSUID ='" & MBTransUID & "' AND PBTransStat <> -1")
            TableList.Redraw = False
            TableList.Rows.Count = 1
            If IsNothing(TMPRecord) Then
            Else
                While TMPRecord.Read()
                    x = x + 1
                    TableList.AddItem(vbTab & TMPRecord.Item("PBTRANSUID") & vbTab & TMPRecord.Item("PBTRANSNO") & vbTab & TMPRecord.Item("PBTRANSDATE") & vbTab & TMPRecord.Item("PBTRANSCUSTNAME") & vbTab & TMPRecord.Item("PBTRANSTOTVAL"))
                    TableList.Rows(x).Height = 45
                End While : MyDatabase.ConnectionDatabase.Close()
            End If
            TableList.Redraw = True
            TMPRecord = Nothing

        Catch ex As Exception
            TableList.Redraw = True
        End Try
        TMPRecord = Nothing

        If TableList.Rows.Count = 1 Then
            BTNEdit.Enabled = False
            BTNEdit.VisualStyle = C1Input.VisualStyle.Office2007Silver
            BTNVoid.Enabled = False
            BTNVoid.VisualStyle = C1Input.VisualStyle.Office2007Silver
        End If

        If Lunas = True Then
            BTNNew.Enabled = False
            BTNNew.VisualStyle = C1Input.VisualStyle.Office2007Silver
            BTNEdit.Enabled = False
            BTNEdit.VisualStyle = C1Input.VisualStyle.Office2007Silver
            BTNVoid.Enabled = False
            BTNVoid.VisualStyle = C1Input.VisualStyle.Office2007Silver

            ShowMessage(Me, "Semua nota untuk customer '" & CustName & "' telah lunas !")
            Call ParentOBJForm.BasicInitialize()
            Me.Close()
        End If

    End Sub

    Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)
        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2213'")
        While TMPRecord.Read()
            UserPermition.PermitionInitialize(TMPRecord.Item("USERCATCREATEACCESS"), TMPRecord.Item("USERCATEDITACCESS"), TMPRecord.Item("USERCATDELETEACCESS"), TMPRecord.Item("USERCATREADACCESS"), TMPRecord.Item("USERCATPRINTACCESS"), TMPRecord.Item("USERCATCHANGEDATEACCESS"), TMPRecord.Item("USERCATCHANGETIMEACCESS"), TMPRecord.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
        End While

        With UserPermition
            If Not .ReadAccess Then
                ShowMessage(Me, "Maaf, anda tidak mempunyai akses terhadap form ini !" & vbNewLine & "Silakan hubungi administrator anda.")
                Me.Close()
            End If

            If Not .CreateAccess Then
                BTNNew.Enabled = False
                BTNNew.VisualStyle = C1Input.VisualStyle.Office2007Silver
            End If

            If Not .EditAccess Then
                BTNEdit.Enabled = False
                BTNEdit.VisualStyle = C1Input.VisualStyle.Office2007Silver
            End If

            If Not .DeleteAccess Then
                BTNVoid.Enabled = False
                BTNVoid.VisualStyle = C1Input.VisualStyle.Office2007Silver
            End If

            If .CreateAccess Then
                BTNNew.Enabled = True
                BTNNew.VisualStyle = C1Input.VisualStyle.Office2007Blue
            End If

            If .EditAccess Then
                BTNEdit.Enabled = True
                BTNEdit.VisualStyle = C1Input.VisualStyle.Office2007Blue
            End If

            If .DeleteAccess Then
                BTNVoid.Enabled = True
                BTNVoid.VisualStyle = C1Input.VisualStyle.Office2007Blue
            End If

        End With
    End Sub

    Private Sub Form_Debt_Payment_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If MainPage.InvoiceApplication = True Then
            Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 45)
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Me.Width = 1024
            Me.Height = 700
            GroupBox1.Width = 1005
            GroupBox2.Width = 1005
            TableList.Width = GroupBox1.Width - 28
            GroupBox2.Top = 616
            BTNOK.Left = 847
            BTNMoveUp.Left = (GroupBox1.Width - 294) / 2
            BTNMoveDown.Left = BTNMoveUp.Left + 151
        Else
            Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 44)
        End If

        Call BasicInitialize(MBTransUID)
    End Sub

    Private Sub TableList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TableList.DoubleClick

        If BTNEdit.Enabled = False Then ShowMessage(Me, "Maaf, anda tidak mempunyai akses untuk mengedit data !") : Exit Sub

        If TableList.Row > 0 Then

            Me.Cursor = Cursors.WaitCursor
            Dim TMPCheck As FbDataReader
            Dim Paid As Decimal = 0

            Try
                TMPCheck = MyDatabase.MyReader("SELECT MB.MBTRANSPAIDVAL FROM MBTRANS MB WHERE MB.MBTRANSUID ='" & MBTransUID & "'")
                TMPCheck.Read()
                Paid = TMPCheck.Item("MBTRANSPAIDVAL")
                TMPCheck = Nothing
            Catch ex As Exception
                Paid = 0
            End Try

            Dim OBJNew As New Form_Debt_Payment
            OBJNew.Name = "Form_Debt_Payment"
            OBJNew.ParentOBJForm = Me
            OBJNew.TransactionUID = TableList.Item(TableList.Row, 1)
            OBJNew.MBTransUID = MBTransUID
            OBJNew.Paid = Paid
            OBJNew.NewTransaction = False
            OBJNew.ShowDialog()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub TableList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TableList.MouseDown
        If TableList.Rows.Count > 1 Then

            Dim NewStyle As C1.Win.C1FlexGrid.CellStyle
            NewStyle = TableList.Styles.Add("Click")
            NewStyle.BackColor = Color.LightCoral

            For i As Integer = 0 To TableList.Rows.Count - 1
                TableList.Item(i, 7) = False
                TableList.Rows(i).Style = Nothing
            Next
            TableList.Item(TableList.Row, 7) = True
            TableList.Rows(TableList.Row).Style = TableList.Styles("Click")
        End If
    End Sub

    Private Sub FocusMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMoveUp.Click, BTNMoveDown.Click
        With TableList
            If .Rows.Count > 1 Then
                Select Case sender.name
                    Case "BTNMoveUp"
                        If .Row > 1 Then .Row = .Row - 1
                        TableList_MouseDown(sender, e)
                    Case "BTNMoveDown"
                        If .Row < .Rows.Count - 1 Then .Row = .Row + 1
                        TableList_MouseDown(sender, e)
                End Select
            End If
        End With
    End Sub

    Private Sub BTNNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNNew.Click
        Me.Cursor = Cursors.WaitCursor
        Dim TMPCheck As FbDataReader
        Dim Paid As Decimal = 0

        Try
            TMPCheck = MyDatabase.MyReader("SELECT MB.MBTRANSPAIDVAL FROM MBTRANS MB WHERE MB.MBTRANSUID ='" & MBTransUID & "'")
            TMPCheck.Read()
            Paid = TMPCheck.Item("MBTRANSPAIDVAL")
            TMPCheck = Nothing
        Catch ex As Exception
            Paid = 0
        End Try

        Dim OBJNew As New Form_Debt_Payment
        OBJNew.Name = "Form_Debt_Payment"
        OBJNew.fromInvoice = False
        OBJNew.ParentOBJForm = Me
        'Add By Rudy (16 Mar 2011)
        If Invoice = True Then
            OBJNew.Invoice = True
        End If
        If (TableList.Rows.Count > 1) Then
            OBJNew.TransactionUID = TableList.Item(TableList.Row, 1)
        End If
        OBJNew.MBTransUID = MBTransUID
        OBJNew.Paid = Paid
        OBJNew.NewTransaction = True
        OBJNew.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BTNEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEdit.Click
        If TableList.Row > 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim TMPCheck As FbDataReader
            Dim Paid As Decimal = 0

            Try
                TMPCheck = MyDatabase.MyReader("SELECT MB.MBTRANSPAIDVAL FROM MBTRANS MB WHERE MB.MBTRANSUID ='" & MBTransUID & "'")
                TMPCheck.Read()
                Paid = TMPCheck.Item("MBTRANSPAIDVAL")
                TMPCheck = Nothing
            Catch ex As Exception
                Paid = 0
            End Try

            Dim OBJNew As New Form_Debt_Payment
            OBJNew.Name = "Form_Debt_Payment"
            OBJNew.ParentOBJForm = Me
            OBJNew.TransactionUID = TableList.Item(TableList.Row, 1)
            OBJNew.MBTransUID = MBTransUID
            OBJNew.Paid = Paid
            OBJNew.fromInvoice = False
            OBJNew.NewTransaction = False
            OBJNew.ShowDialog()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BTNVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVoid.Click
        If TableList.Row > 0 Then
            If ShowQuestion(Me, "Hapus transaksi pembayaran nomor '" & TableList.Item(TableList.Row, 2) & "' ?") = True Then
                Dim TMPCheck As FbDataReader
                Dim Paid As Decimal = 0

                Try
                    TMPCheck = MyDatabase.MyReader("SELECT MB.MBTRANSPAIDVAL FROM MBTRANS MB WHERE MB.MBTRANSUID ='" & MBTransUID & "'")
                    While TMPCheck.Read
                        Paid = TMPCheck.Item("MBTRANSPAIDVAL")
                        Paid = Paid - TableList.Item(TableList.Row, 5)
                    End While
                Catch ex As Exception
                    Paid = 0
                End Try

                Call MyDatabase.MyAdapter("UPDATE PBTRANS SET PBTRANSSTAT = -1 ,DELETEDUSER='" & UserInformation.UserName & "',DELETEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSUID LIKE '" & TableList.Item(TableList.Row, 1) & "'")
                Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MBTRANSPAIDVAL='" & Paid & "' WHERE MBTRANSUID='" & MBTransUID & "'")

                Call BasicInitialize(MBTransUID)
            End If
        Else
            ShowMessage(Me, "Silakan pilih transaksi pembayaran dari daftar terlebih dahulu !", True)
            Exit Sub
        End If
    End Sub

    Private Sub BTNOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNOK.Click
        Call ParentOBJForm.BasicInitialize()
        Me.Close()
    End Sub

    Private Sub TableList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableList.Click

    End Sub
End Class