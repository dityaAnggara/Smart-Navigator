Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win

Public Class Form_Reservation_Down_Payment
    Public ParentOBJForm As Object
    Public TransactionUID As String = Nothing
    Public DPDetailListCollection As New Collection
    Dim UserPermition As New UserPermitionLib

    Public NewEditStatus As Boolean = False
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
    Public LockDownPayment As Boolean = True

    Public Sub BasicInitialize(ByVal RsvUID As String)

        Dim TMPRecord As FbDataReader
        Dim x As Integer = 0
        Try
            TMPRecord = MyDatabase.MyReader("SELECT a.PBTRANSUID, a.PBTRANSNO, a.PBTRANSDATE, a.PBTRANSDEPTUID, a.PBTRANSMODULETYPEID, a.PBTRANSSHIFTNO, a.PBTRANSRSVTRANSUID, a.PBTRANSMBTRANSUID, a.PBTRANSCUSTUID, a.PBTRANSCUSTNAME, a.PBTRANSTABLELISTUID, a.PBTRANSTOTVAL, a.PBTRANSSTAT, a.PBTRANSDESC, a.PBTRANSSTAT, a.PRINTCOUNTER, a.ISLOCKED, a.ISFISCAL, a.CREATEDUSER, a.MODIFIEDUSER, a.DELETEDUSER, a.CREATEDDATETIME, a.MODIFIEDDATETIME, a.DELETEDDATETIME FROM PBTRANS a WHERE a.PBTRANSSTAT <> -1 AND a.PBTRANSRSVTRANSUID='" & RsvUID & "'")

            TableList.Redraw = False
            TableList.Rows.Count = 1

            While TMPRecord.Read()
                x = x + 1
                TableList.AddItem(vbTab & TMPRecord.Item("PBTRANSUID") & vbTab & TMPRecord.Item("PBTRANSNO") & vbTab & TMPRecord.Item("PBTRANSDATE") & vbTab & TMPRecord.Item("PBTRANSCUSTNAME") & vbTab & TMPRecord.Item("PBTRANSTOTVAL") & vbTab & TMPRecord.Item("PBTRANSSTAT"))
                TableList.Rows(x).Height = 45
            End While : MyDatabase.ConnectionDatabase.Close()

            TableList.Redraw = True
            TMPRecord = Nothing

        Catch ex As Exception
            TableList.Redraw = True
        End Try
        TMPRecord = Nothing

    End Sub

    Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)

        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2212'")
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
            Else
                BTNNew.Enabled = True
                BTNNew.VisualStyle = C1Input.VisualStyle.Office2007Blue
            End If

            If Not .EditAccess Then
                BTNEdit.Enabled = False
                BTNEdit.VisualStyle = C1Input.VisualStyle.Office2007Silver
            Else
                BTNEdit.Enabled = True
                BTNEdit.VisualStyle = C1Input.VisualStyle.Office2007Blue
            End If

            If Not .DeleteAccess Then
                BTNVoid.Enabled = False
                BTNVoid.VisualStyle = C1Input.VisualStyle.Office2007Silver
            Else
                BTNVoid.Enabled = True
                BTNVoid.VisualStyle = C1Input.VisualStyle.Office2007Blue
            End If

        End With

    End Sub

    Private Sub Form_Reservation_Down_Payment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 44)

        Call BasicInitialize(TransactionUID)
        Call CheckPermission(UserInformation.UserTypeUID, True)

        If LockDownPayment Then
            BTNNew.Enabled = False : BTNNew.VisualStyle = C1Input.VisualStyle.Office2007Silver
            BTNEdit.Enabled = False : BTNEdit.VisualStyle = C1Input.VisualStyle.Office2007Silver
            BTNVoid.Enabled = False : BTNVoid.VisualStyle = C1Input.VisualStyle.Office2007Silver
        End If

        Me.ActiveControl = TableList

    End Sub

    Private Sub TableList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TableList.DoubleClick

        If BTNEdit.Enabled = False Then ShowMessage(Me, "Maaf, anda tidak mempunyai akses untuk mengedit data !") : Exit Sub
        Call BTNEdit_Click(sender, e)

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

            If TableList.Item(TableList.Row, 6) = 1 Then
                If Not LockDownPayment Then Call CheckPermission(UserInformation.UserTypeUID, True)
            Else
                'BTNEdit.Enabled = True
                'BTNEdit.VisualStyle = C1Input.VisualStyle.Office2007Blue
            End If
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
        Dim OBJNew As New Form_Payment
        OBJNew.Name = "Form_Payment"
        OBJNew.Text = "Down Payment"

        With OBJNew.ReservasiInfo
            .NewReservationUID = NewID
            .ReservationUID = CurrentUID
            .ReservationNumber = ReservationNumber
            .CustUID = CustUID
            .CustList = CustList
            .GrandTotal = GrandTotal
            .CustName = CustName
            If MainPage.InvoiceApplication = True Then
                .TableList = ""
                .TableUID = ""
            Else
                .TableList = Table
                .TableUID = TableUID
            End If
            .DP = DP
        End With

        If NewEditStatus = True Then
            OBJNew.IsNewEditReservation = True
        Else
            OBJNew.IsNewEditReservation = False
            OBJNew.IsNewReservation = True
        End If

        Dim TMPCheck As FbDataReader
        Dim Paid As Decimal = 0

        Try
            TMPCheck = MyDatabase.MyReader("SELECT SUM(PBTRANSTOTVAL) AS DOWNPAYMENT FROM PBTRANS WHERE PBTRANSSTAT <> -1 AND PBTRANSRSVTRANSUID='" & TransactionUID & "' GROUP BY PBTRANSRSVTRANSUID")
            While TMPCheck.Read
                Paid = TMPCheck.Item("DOWNPAYMENT")
            End While
        Catch ex As Exception
            Paid = 0
        End Try

        OBJNew.IsReservation = True
        OBJNew.Paid = Paid
        OBJNew.ParentOBJForm = Me
        OBJNew.Print.Visible = False
        OBJNew.PrintCounter.Visible = False
        OBJNew.ShowDialog()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BTNEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEdit.Click

        If TableList.Row > 0 Then
            Me.Cursor = Cursors.WaitCursor
            Dim OBJNew As New Form_Payment
            OBJNew.Name = "Form_Payment"
            OBJNew.Text = "Down Payment"

            With OBJNew.ReservasiInfo
                .NewReservationUID = NewID
                .ReservationUID = CurrentUID
                .ReservationNumber = ReservationNumber
                .CustUID = CustUID
                .CustList = CustList
                .GrandTotal = GrandTotal
                .CustName = CustName
                .TableList = Table
                .TableUID = TableUID
                .DP = DP
            End With

            Dim TMPCheck As FbDataReader
            Dim Paid As Decimal = 0

            Try
                TMPCheck = MyDatabase.MyReader("SELECT SUM(PBTRANSTOTVAL) AS DOWNPAYMENT FROM PBTRANS WHERE PBTRANSSTAT <> -1 AND PBTRANSRSVTRANSUID='" & TransactionUID & "' AND PBTRANSUID <> '" & TableList.Item(TableList.Row, 1) & "' GROUP BY PBTRANSRSVTRANSUID")
                While TMPCheck.Read
                    Paid = TMPCheck.Item("DOWNPAYMENT")
                End While
            Catch ex As Exception
                Paid = 0
            End Try

            OBJNew.IsReservation = True
            OBJNew.Paid = Paid
            OBJNew.IsNewReservation = False
            OBJNew.DPTransUID = TableList.Item(TableList.Row, 1)
            OBJNew.ParentOBJForm = Me
            OBJNew.Print.Visible = False
            OBJNew.PrintCounter.Visible = False
            OBJNew.ShowDialog()
            Me.Cursor = Cursors.Default
        End If
    End Sub

    Private Sub BTNVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVoid.Click
        If TableList.Row > 0 Then
            If ShowQuestion(Me, "Batalkan transaksi uang muka nomor '" & TableList.Item(TableList.Row, 2) & "' ?") = True Then
                Me.Cursor = Cursors.WaitCursor
                Call MyDatabase.MyAdapter("UPDATE PBTRANS SET PBTRANSSTAT = -1, DELETEDUSER='" & UserInformation.UserName & "',DELETEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSUID LIKE '" & TableList.Item(TableList.Row, 1) & "'")

                Dim TMPCheck As FbDataReader
                Dim Paid As Decimal = 0
                Try
                    TMPCheck = MyDatabase.MyReader("SELECT SUM(PBTRANSTOTVAL) AS DOWNPAYMENT FROM PBTRANS WHERE PBTRANSSTAT <> -1 AND PBTRANSRSVTRANSUID='" & TransactionUID & "' GROUP BY PBTRANSRSVTRANSUID")
                    While TMPCheck.Read
                        Paid = TMPCheck.Item("DOWNPAYMENT")
                    End While
                Catch ex As Exception
                    Paid = 0
                End Try

                Call MyDatabase.MyAdapter("UPDATE RSVTRANS SET RSVTRANSDPVAL='" & Paid & "' WHERE RSVTRANSUID='" & TransactionUID & "'")
                Call BasicInitialize(TransactionUID)
                Me.Cursor = Cursors.Default
            End If
        End If
    End Sub

    Private Sub BTNOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNOK.Click
        If TableList.Row > 0 Then
            Dim TMPRecord As FbDataReader
            TMPRecord = MyDatabase.MyReader("SELECT SUM(PBTRANSTOTVAL) AS DOWNPAYMENT FROM PBTRANS WHERE PBTRANSSTAT <> -1 AND PBTRANSRSVTRANSUID='" & TransactionUID & "' GROUP BY PBTRANSRSVTRANSUID")
            TMPRecord.Read()
            ParentOBJForm.DPValue = TMPRecord.Item("DOWNPAYMENT")
        Else
            ParentOBJForm.DPValue = 0
        End If

        Me.Close()
    End Sub
   
    Private Sub TableList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableList.Click

    End Sub
End Class