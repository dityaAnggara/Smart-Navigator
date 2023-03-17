Imports FirebirdSql.Data.FirebirdClient

Public Class Form_Reservation_List_Show

    Public ParentOBJForm As Object
    Dim UserPermition As New UserPermitionLib
    Dim ListCollection As New Collection
    Dim FormStatus As FormStatusLib
    Dim X As Integer = 0
    Dim isUp As Boolean = False

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

        TMPRecord = MyDatabase.MyReader("SELECT * FROM RSVTRANS WHERE (RSVTRANSSTAT IS NULL OR RSVTRANSSTAT = 0) AND CAST(RSVTRANSDATE AS DATE) BETWEEN '" & FromDate.Value & "' AND '" & ToDate.Value & "' ORDER BY RSVTRANSNO")
        With TableList
            .Redraw = False
            .Rows.Count = 1
            While TMPRecord.Read
                I = I + 1
                TableList.AddItem(vbTab & TMPRecord.Item("RSVTRANSUID") & vbTab & TMPRecord.Item("RSVTRANSNO") & vbTab & TMPRecord.Item("RSVTRANSDATE") & vbTab & TMPRecord.Item("RSVTRANSCUSTNAME") & vbTab & Format(TMPRecord.Item("RSVTRANSRESERVEDDATE"), "dd/MM/yyyy") & " " & Format(TMPRecord.Item("RSVTRANSRESERVEDTIME"), "hh:mm:ss tt") & vbTab & Format(TMPRecord.Item("RSVTRANSRESERVEDTIME"), "hh:mm:ss tt") & vbTab & TMPRecord.Item("RSVTRANSPAXVAL") & vbTab & "")
                .Rows(I).Height = 25
            End While
            .Redraw = True
        End With

        Me.Cursor = Cursors.Default

    End Sub

#End Region

#Region "Form Control Function"

    Private Sub Form_Reservation_List_Show_Deactivate(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Deactivate
        'isUp = True
        'tmrSize.Enabled = True
    End Sub

    Private Sub Form_Reservation_List_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load        
        Me.Location = New System.Drawing.Point(MainPage.Location.X + 300, MainPage.Location.Y + 81)
        TableList.Styles("Normal").WordWrap = True

        Call BasicInitialize()
        tmrSize.Enabled = True
    End Sub


    Private Sub BTNClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClose.Click
        Me.Close()
    End Sub

#End Region

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
    
    Private Sub tmrSize_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrSize.Tick
        If isUp = False Then
            If Me.Size.Height >= 400 Then tmrSize.Enabled = False
            Me.Height += 20
        Else           
            If Me.Height <= 60 Then
                Me.Close()
                tmrSize.Enabled = False
                Exit Sub
            End If
            Me.Height -= 20
        End If
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        isUp = True
        tmrSize.Enabled = True
    End Sub

    Private Sub VirtualDateFromDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualDateFromDate.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtualDate As New Form_Virtual_Date
        VirtualDate.Name = "Form_Virtual_Date"
        VirtualDate.Text = "Please Select Date"
        VirtualDate.ParentOBJForm = Me
        VirtualDate.publicChosenDate = FromDate.Value
        VirtualDate.ShowDialog(Me)

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
        VirtualDate.ShowDialog(Me)

        ToDate.Text = VirtualDate.publicChosenDate
        ToDateLabel.Text = Format(ToDate.Value, "dd MMMM yyyy")

        Call BTNView_Click(sender, e)
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BTNView_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNView.Click

        Me.Cursor = Cursors.WaitCursor
        Dim TMPRecord As FbDataReader
        Dim I As Integer = 0
        Try
            TMPRecord = MyDatabase.MyReader("SELECT * FROM RSVTRANS WHERE CAST(RSVTRANSDATE AS DATE) BETWEEN '" & FromDate.Value & "' AND '" & ToDate.Value & "' ORDER BY RSVTRANSNO")
            With TableList
                .Redraw = False
                .Rows.Count = 1
                While TMPRecord.Read
                    I = I + 1
                    TableList.AddItem(vbTab & TMPRecord.Item("RSVTRANSUID") & vbTab & TMPRecord.Item("RSVTRANSNO") & vbTab & TMPRecord.Item("RSVTRANSDATE") & vbTab & TMPRecord.Item("RSVTRANSCUSTNAME") & vbTab & Format(TMPRecord.Item("RSVTRANSRESERVEDDATE"), "dd/MM/yyyy") & " " & Format(TMPRecord.Item("RSVTRANSRESERVEDTIME"), "hh:mm:ss tt") & vbTab & Format(TMPRecord.Item("RSVTRANSRESERVEDTIME"), "hh:mm:ss tt") & vbTab & TMPRecord.Item("RSVTRANSPAXVAL") & vbTab & "")
                    .Rows(I).Height = 45
                End While
                .Redraw = True
            End With
        Catch ex As Exception
            TableList.Redraw = True
        End Try
        Me.Cursor = Cursors.Default

    End Sub
End Class