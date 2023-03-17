Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win
Imports C1.Win.C1FlexGrid
Imports DataDynamics.ActiveReports

Public Class Form_Cash_In_Out_List

#Region "Variable Reference"

    Public ParentOBJForm As Object
    Public ItemNotes As String = Nothing

    Dim UserPermition As New UserPermitionLib
    Dim ListCollection As New Collection
    Dim FormStatus As FormStatusLib
#End Region

#Region "Initialize & Object Function"

    Private Sub BasicInitialize()
        
        Call CheckPermission(UserInformation.UserTypeUID, True)
    End Sub

    Private Sub fillGrid()
        Dim rs As FbDataReader
        Dim i As Integer = 0
        Dim strSQL As String = "SELECT A.*,C.PAYMENTTYPENAME FROM PBTRANS A INNER JOIN PBTRANSDT B ON A.PBTRANSUID=B.PBTRANSUID INNER JOIN PAYMENTTYPE C ON B.PAYMENTTYPEUID=C.PAYMENTTYPEUID WHERE A.DELETEDDATETIME IS NULL AND CAST(PBTRANSDATE AS DATE) BETWEEN '" & Format(FromDate.Value, "yyyy/MM/dd") & "' AND '" & Format(ToDate.Value, "yyyy/MM/dd") & "' AND PBTRANSMODULETYPEID='" & IIf(InStr(UCase(Trim(Me.Text)), "CASH IN") > 0, "2501", "2502") & "'" & IIf(Trim(FindNo.Text) = "" And Trim(FindName.Text) = "", "", " AND (PBTransNo LIKE '" & ReplacePetik(FindNo.Text) & "' OR PBTransDesc LIKE '%" & ReplacePetik(FindName.Text) & "%')") & " ORDER BY PBTRANSNO"
        rs = MyDatabase.MyReader(strSQL)
        With TableList
            .Redraw = False
            .Rows.Count = 1
            While rs.Read()
                I = I + 1
                TableList.AddItem(rs("PBTRANSUID") & vbTab & rs("PBTRANSNO") & vbTab & rs("PAYMENTTYPENAME") & vbTab & Format(rs("PBTRANSDATE"), "dd/MM/yyyy HH:mm:ss") & vbTab & IIf(CDec(rs("PBTRANSTOTVAL")) < 0, CDec(rs("PBTRANSTOTVAL")) * (-1), rs("PBTRANSTOTVAL")) & vbTab & rs("PBTRANSDESC"))
                .Rows(I).Height = 45
            End While
            .Redraw = True
        End With
        rs = Nothing
    End Sub

    Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)
        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '" & IIf(InStr(UCase(Trim(Me.Text)), "CASH IN") > 0, "2501", "2502") & "'")
        While TMPRecord.Read()
            UserPermition.PermitionInitialize(TMPRecord.Item("USERCATCREATEACCESS"), TMPRecord.Item("USERCATEDITACCESS"), TMPRecord.Item("USERCATDELETEACCESS"), TMPRecord.Item("USERCATREADACCESS"), TMPRecord.Item("USERCATPRINTACCESS"), TMPRecord.Item("USERCATCHANGEDATEACCESS"), TMPRecord.Item("USERCATCHANGETIMEACCESS"), TMPRecord.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
        End While

        With UserPermition
            If Not .ReadAccess Then
                ShowMessage(Me, "Maaf, anda tidak mempunyai akses terhadap form ini !" & vbNewLine & "Silakan hubungi administrator anda.")
                Me.Close()
            End If

            If .EditAccess Then
                BTNEdit.Enabled = True
                BTNEdit.VisualStyle = C1Input.VisualStyle.Office2007Blue
            Else
                BTNEdit.Enabled = False
                BTNEdit.VisualStyle = C1Input.VisualStyle.Office2007Silver
            End If

            If .DeleteAccess Then
                BTNDelete.Enabled = True
                BTNDelete.VisualStyle = C1Input.VisualStyle.Office2007Blue
            Else
                BTNDelete.Enabled = False
                BTNDelete.VisualStyle = C1Input.VisualStyle.Office2007Silver
            End If

            If .PrintAccess Then
                BTNPrint.Enabled = True
                BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Blue
            Else
                BTNPrint.Enabled = False
                BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Silver
            End If
        End With
    End Sub

   
    Private Sub ShowPrintPreview(Optional ByVal Nota As Boolean = False, Optional ByVal printerName As String = "")


        'Dim OBJNew As New Form_Print_Preview
        'Dim Query As String

        'Query = "SELECT a.MBTRANSUID, a.MBTRANSNO, a.MBTRANSDATE, a.MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME, a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID,(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = a.MBTRANSSERVICETYPEUID) AS MBTRANSSERVICETYPENAME, a.MBTRANSRSVTRANSUID, a.MBTRANSSUBVAL, a.MBTRANSDISCPERC, a.MBTRANSDISCVAL, a.MBTRANSTAXVAL1, a.MBTRANSTAXVAL2, a.MBTRANSDPVAL, a.MBTRANSTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT, a.MODIFIEDUSER, b.TABLELISTNAME " & _
        '        "FROM MBTRANS a LEFT JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE MBTRANSUID = '" & TransactionUID & "'"
        'OBJNew.Printer = printerName
        'OBJNew.Name = "Form_Print_Preview"
        'OBJNew.RPTTitle = "Make Order"
        'OBJNew.RPTDocument = New Make_Order
        'OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
        'OBJNew.VersiNota = Nota
        'OBJNew.ShowDialog()

    End Sub
#End Region

#Region "Form Control Function"

    Private Sub Form_Cash_In_Out_List_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 44)
        TableList.Styles("Normal").WordWrap = True
        FromDate.Value = Month(Now) & "/" & "1/" & Year(Now)
        ToDate.Value = Now.Date

        FromDateLabel.Text = Format(FromDate.Value, "dd MMMM yyyy")
        ToDateLabel.Text = Format(ToDate.Value, "dd MMMM yyyy")
        Call BasicInitialize()
    End Sub

    Private Sub BTNEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEdit.Click
        With TableList
            If .RowSel <= 0 Then Exit Sub
            Form_Cash_In_Out.pubIdTrans = .Item(.RowSel, 0)
        End With
        Me.Close()
    End Sub

    Private Sub BTNDelete_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNDelete.Click
        If TableList.Row > 0 Then
            If ShowQuestion(Me, "Apakah anda ingin membatalkan invoice nomor '" & TableList.Item(TableList.Row, 1) & "' ?") = True Then
                Dim strSQL As String = "UPDATE PBTRANS SET PBTRANSSTAT='-1',DELETEDUSER='" & ReplacePetik(UserInformation.UserName) & "',DELETEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSUID='" & TableList.Item(TableList.Row, 0) & "'"
                Call MyDatabase.MyAdapter(strSQL)
                Call BTNSearch_Click(BTNSearch, e)
            End If
        End If
    End Sub

    Private Sub BTNViewNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNViewNotes.Click
        With TableList
            If .Row > 0 Then
                Dim OBJNew As New Form_View_Notes
                OBJNew.Name = "Form_View_Notes"
                OBJNew.ParentOBJForm = Me
                OBJNew.NotesTxt.Text = .Item(.Row, 9)
                OBJNew.ShowDialog()
            End If
        End With
    End Sub

    Private Sub BTNClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClose.Click
        Me.Close()
    End Sub

    Private Sub TableList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TableList.MouseDown
        'If TableList.Rows.Count > 1 Then

        '    Dim NewStyle As CellStyle
        '    NewStyle = TableList.Styles.Add("Click")
        '    NewStyle.BackColor = Color.LightCoral

        '    Dim Style As CellStyle
        '    Style = TableList.Styles.Add("Disable")
        '    Style.BackColor = Color.Silver

        '    For i As Integer = 0 To TableList.Rows.Count - 1
        '        'TableList.Item(i, 0) = False
        '        TableList.Rows(i).Style = Nothing
        '        If TableList.Item(i, 11) = 1 Then
        '            TableList.Rows(i).Style = TableList.Styles("Disable")
        '        End If
        '    Next
        '    'TableList.Item(TableList.Row, 0) = True
        '    TableList.Rows(TableList.Row).Style = TableList.Styles("Click")

        '    'If TableList.Item(TableList.Row, 10) = 1 Then
        '    '    TableList.Rows(TableList.Row).Style = TableList.Styles("Disable")
        '    'Else
        '    '    TableList.Rows(TableList.Row).Style = TableList.Styles("Click")
        '    'End If
        'End If
    End Sub

    Private Sub BTNPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPrint.Click

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
#End Region

    Private Sub TableList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TableList.Click
        'If TableList.Row > 0 Then
        '    If TableList.Item(TableList.Row, 10) = True Then
        '        Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET PRINT=1 WHERE MBTRANSDTUID = '" & TableList.Item(TableList.Row, 2) & "'")
        '    Else
        '        Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET PRINT=0 WHERE MBTRANSDTUID = '" & TableList.Item(TableList.Row, 2) & "'")
        '    End If
        'End If
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
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VirtualKey2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKey2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(FindNo, False)
        VirtuKey.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VirtualKey1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKey1.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(FindName, False)
        VirtuKey.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BTNSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSearch.Click
        Call fillGrid()
    End Sub
End Class