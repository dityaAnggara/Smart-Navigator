Imports FirebirdSql.Data.FirebirdClient

Public Class Form_Reservation_List

    Public ParentOBJForm As Object
    Dim UserPermition As New UserPermitionLib
    Dim ListCollection As New Collection
    Dim FormStatus As FormStatusLib
    Dim X As Integer = 0

#Region "Initialize & Object Function"

    Private Sub BasicInitialize()

        Me.Cursor = Cursors.WaitCursor
        Dim TMPRecord As FbDataReader
        Dim I As Integer = 0

        FromDate.Value = Now.Date
        ToDate.Value = Now.Date

        FromDateLabel.Text = Format(FromDate.Value, "dd MMMM yyyy")
        ToDateLabel.Text = Format(ToDate.Value, "dd MMMM yyyy")

        X = 1
        Status.Image = My.Resources.OK
        LabelStatus.Text = "Not Used"
        If MainPage.InvoiceApplication = True Then
            TableList.Cols(8).Visible = False
            TableList.Cols(4).Width = 450
        End If
        Try
            TMPRecord = MyDatabase.MyReader("SELECT * FROM RSVTRANS WHERE (RSVTRANSSTAT IS NULL OR RSVTRANSSTAT = 0) AND CAST(RSVTRANSDATE AS DATE) BETWEEN '" & FromDate.Value & "' AND '" & ToDate.Value & "' ORDER BY RSVTRANSNO")
            With TableList
                .Redraw = False
                .Rows.Count = 1
                While TMPRecord.Read
                    I = I + 1
                    TableList.AddItem(vbTab & TMPRecord.Item("RSVTRANSUID") & vbTab & TMPRecord.Item("RSVTRANSNO") & vbTab & TMPRecord.Item("RSVTRANSDATE") & vbTab & TMPRecord.Item("RSVTRANSCUSTNAME") & vbTab & FormatDateTime(TMPRecord.Item("RSVTRANSRESERVEDDATE"), DateFormat.LongDate) & vbTab & Format(TMPRecord.Item("RSVTRANSRESERVEDTIME"), "hh:mm:ss tt") & vbTab & TMPRecord.Item("RSVTRANSPAXVAL") & vbTab & GetDaftarTable(TMPRecord.Item("RSVTRANSUID")))
                    .Rows(I).Height = 45
                End While
                .Redraw = True
            End With
        Catch ex As Exception

        End Try

        Call CheckPermission(UserInformation.UserTypeUID, True)
        Me.Cursor = Cursors.Default

    End Sub

    Private Function GetDaftarTable(ByVal TransUID As String) As String

        Dim Result As String = ""
        Dim TMPResult As FbDataReader
        TMPResult = MyDatabase.MyReader("SELECT a.RSVTRANSTABLELISTUID, (SELECT TABLELISTNAME FROM TABLELIST WHERE TABLELISTUID = a.RSVTRANSTABLELISTUID) FROM RSVTRANSTABLELIST a WHERE RSVTRANSUID='" & TransUID & "'")
        While TMPResult.Read()
            Result = Result & "," & TMPResult("TABLELISTNAME")
        End While

        GetDaftarTable = "Table : " & Mid(Result, 2, Len(Result))

    End Function

    Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)

        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2201'")
        While TMPRecord.Read()
            UserPermition.PermitionInitialize(TMPRecord.Item("USERCATCREATEACCESS"), TMPRecord.Item("USERCATEDITACCESS"), TMPRecord.Item("USERCATDELETEACCESS"), TMPRecord.Item("USERCATREADACCESS"), TMPRecord.Item("USERCATPRINTACCESS"))
        End While

        With UserPermition
            If Not .ReadAccess Then
                ShowMessage(Me, "Maaf, anda tidak mempunyai akses terhadap form ini !" & vbNewLine & "Silakan hubungi administrator anda.")
                Me.Close()
            End If

            If Not .DeleteAccess Then
                BTNVoid.Enabled = False
            Else
                BTNVoid.Enabled = True
            End If

        End With
    End Sub
#End Region

#Region "Form Control Function"

    Private Sub Form_Reservation_List_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 44)
        TableList.Styles("Normal").WordWrap = True

        Call BasicInitialize()

    End Sub

    Private Sub BTNEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEdit.Click
        With TableList
            If .Row <= 0 Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            ParentOBJForm.EditReservation(TableList.Item(TableList.Row, 1))
            Me.Cursor = Cursors.Default
            Me.Close()
        End With
    End Sub

    Private Sub BTNVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVoid.Click

        If TableList.Row > 0 Then
            If ShowQuestion(Me, "Hapus transaksi reservasi nomor '" & TableList.Item(TableList.Row, 2) & "' ?") = True Then
                Call MyDatabase.MyAdapter("UPDATE RSVTRANS SET RSVTRANSSTAT=-1,DELETEDUSER='" & UserInformation.UserName & "',DELETEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE RSVTRANSUID LIKE '" & TableList.Item(TableList.Row, 1) & "'")
                Call MyDatabase.MyAdapter("UPDATE PBTRANS SET PBTRANSSTAT=-1,DELETEDUSER='" & UserInformation.UserName & "',DELETEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSRSVTRANSUID LIKE '" & TableList.Item(TableList.Row, 1) & "'")

                Call BasicInitialize()
            End If
        End If

    End Sub

    Private Sub BTNClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClose.Click
        Me.Close()
    End Sub

#End Region

    Private Sub TableList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TableList.DoubleClick
        With TableList
            If .Row <= 0 Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            ParentOBJForm.EditReservation(.Item(.Row, 1))
            Me.Cursor = Cursors.Default
            Me.Close()
        End With
    End Sub

    Private Sub TableList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TableList.MouseDown
        If TableList.Rows.Count > 1 Then

            Dim NewStyle As C1.Win.C1FlexGrid.CellStyle
            NewStyle = TableList.Styles.Add("Click")
            NewStyle.BackColor = Color.LightCoral

            For i As Integer = 0 To TableList.Rows.Count - 1
                TableList.Item(i, 0) = False
                TableList.Rows(i).Style = Nothing
            Next
            TableList.Item(TableList.Row, 0) = True
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

    Private Sub VirtualDateFromDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualDateFromDate.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtualDate As New Form_Virtual_Date
        VirtualDate.Name = "Form_Virtual_Date"
        VirtualDate.Text = "Please Select Date"
        VirtualDate.ParentOBJForm = Me
        VirtualDate.publicChosenDate = FromDate.Value
        VirtualDate.ShowDialog()

        FromDate.Text = VirtualDate.publicChosenDate
        FromDateLabel.Text = Format(FromDate.Value, "dd MMMM yyyy")

        Call BTNView_Click(sender, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VirtualDateToDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualDateToDate.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtualDate As New Form_Virtual_Date
        VirtualDate.Name = "Form_Virtual_Date"
        VirtualDate.Text = "Please Select Date"
        VirtualDate.ParentOBJForm = Me
        VirtualDate.publicChosenDate = ToDate.Value
        VirtualDate.ShowDialog()

        ToDate.Text = VirtualDate.publicChosenDate
        ToDateLabel.Text = Format(ToDate.Value, "dd MMMM yyyy")

        Call BTNView_Click(sender, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Status_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Status.MouseDown, LabelStatus.MouseDown
        If X = 0 Then
            X = 1
            Status.Image = My.Resources.OK
            LabelStatus.Text = "Not Used"
        Else
            X = 0
            Status.Image = My.Resources._NOTHING
            LabelStatus.Text = "Already Used"
        End If

        Call BTNView_Click(sender, e)
    End Sub

    Private Sub BTNView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNView.Click

        Me.Cursor = Cursors.WaitCursor
        Dim TMPRecord As FbDataReader
        Dim I As Integer = 0
        Try
            TMPRecord = MyDatabase.MyReader("SELECT * FROM RSVTRANS WHERE RSVTRANSSTAT = '" & IIf(X = 1, 0, 1) & "' AND CAST(RSVTRANSDATE AS DATE) BETWEEN '" & FromDate.Value & "' AND '" & ToDate.Value & "' ORDER BY RSVTRANSNO")
            With TableList
                .Redraw = False
                .Rows.Count = 1
                While TMPRecord.Read
                    I = I + 1
                    TableList.AddItem(vbTab & TMPRecord.Item("RSVTRANSUID") & vbTab & TMPRecord.Item("RSVTRANSNO") & vbTab & TMPRecord.Item("RSVTRANSDATE") & vbTab & TMPRecord.Item("RSVTRANSCUSTNAME") & vbTab & FormatDateTime(TMPRecord.Item("RSVTRANSRESERVEDDATE"), DateFormat.LongDate) & vbTab & FormatDateTime(TMPRecord.Item("RSVTRANSRESERVEDTIME"), DateFormat.LongTime) & vbTab & TMPRecord.Item("RSVTRANSPAXVAL") & vbTab & GetDaftarTable(TMPRecord.Item("RSVTRANSUID")))
                    .Rows(I).Height = 45
                End While
                .Redraw = True
            End With
        Catch ex As Exception
            TableList.Redraw = True
        End Try
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub TableList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableList.Click

    End Sub
End Class