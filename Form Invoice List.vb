Imports FirebirdSql.Data.FirebirdClient

Public Class Form_Invoice_List

  Dim UserPermition As New UserPermitionLib
  Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height

#Region "Variable Reference"

  Public ParentOBJForm As Object
  Public OkToVoid As Boolean

#End Region

#Region "Initialize & Object Function"

  Private Sub BasicInitialize(Optional ByVal SearchNo As String = Nothing, Optional ByVal SearchName As String = Nothing)
    Dim tipeProgram As Boolean = MainPage.InvoiceApplication
    Dim TMPTrans As FbDataReader
    Dim I As Integer = 0
    Dim VSql As String
    'MsgBox(tipeProgram)
    'Try
    'TMPTrans = MyDatabase.MyReader("SELECT M.*,CASE WHEN M.MBTRANSSTAT='0' THEN 'NOT BILL' WHEN M.MBTRANSSTAT='1' THEN 'BILLED' WHEN M.MBTransStat = '2' THEN 'PAID' ELSE 'CHECK OUT' END AS STATUS FROM MBTRANS M WHERE M.MBTRANSDEPTUID='" & UserInformation.UserDeptUID & "' AND M.MBTRANSMODULETYPEID='2202' AND M.MBTRANSSTAT <> -1 AND M.MBTRANSSTAT <> 3 AND (upper(M.MBTRANSNO) LIKE '%" & ReplacePetik(UCase(SearchNo)) & "%' AND UPPER(M.MBTRANSCUSTNAME) LIKE '%" & ReplacePetik(UCase(SearchName)) & "%') AND CAST(MBTRANSDATE AS DATE) BETWEEN '" & Format(FromDate.Value, "MM/dd/yyyy") & "' AND '" & Format(ToDate.Value, "MM/dd/yyyy") & "' ORDER BY M.MBTRANSNO")
    If tipeProgram = True Then
      VSql = "SELECT M.*,CASE WHEN M.MBTRANSSTAT='0' THEN 'NOT BILL' WHEN M.MBTRANSSTAT='1' THEN 'BILLED' WHEN M.MBTransStat = '2' THEN 'PAID' ELSE 'CHECK OUT' END AS STATUS FROM MBTRANS M WHERE M.MBTRANSDEPTUID='" & UserInformation.UserDeptUID & "' AND M.MBTRANSMODULETYPEID='2202' AND M.MBTRANSSTAT <> -1 AND M.MBTRANSSTAT <> 3 AND (upper(M.MBTRANSNO) LIKE '%" & ReplacePetik(UCase(SearchNo)) & "%' AND UPPER(M.MBTRANSCUSTNAME) LIKE '%" & ReplacePetik(UCase(SearchName)) & "%') AND CAST(MBTRANSDATE AS DATE) BETWEEN '" & Format(FromDate.Value, "MM/dd/yyyy") & "' AND '" & Format(ToDate.Value, "MM/dd/yyyy") & "' ORDER BY M.MBTRANSNO"
    Else
      VSql = "SELECT M.*,CASE WHEN M.MBTRANSSTAT='0' THEN 'NOT BILL' WHEN M.MBTRANSSTAT='1' THEN 'BILLED' WHEN M.MBTransStat = '2' THEN 'PAID' ELSE 'CHECK OUT' END AS STATUS FROM MBTRANS M INNER JOIN TABLELIST T ON M.MBTRANSTABLELISTUID=T.TABLELISTUID WHERE T.IMAGE=(SELECT T2.IMAGE FROM TABLELIST T2 WHERE T2.TABLELISTUID='" & ParentOBJForm.tableUID & "') AND M.MBTRANSDEPTUID='" & UserInformation.UserDeptUID & "' AND M.MBTRANSMODULETYPEID='2202' AND M.MBTRANSSTAT <> -1 AND M.MBTRANSSTAT <> 3 AND (upper(M.MBTRANSNO) LIKE '%" & ReplacePetik(UCase(SearchNo)) & "%' AND UPPER(M.MBTRANSCUSTNAME) LIKE '%" & ReplacePetik(UCase(SearchName)) & "%') AND CAST(MBTRANSDATE AS DATE) BETWEEN '" & Format(FromDate.Value, "MM/dd/yyyy") & "' AND '" & Format(ToDate.Value, "MM/dd/yyyy") & "' ORDER BY M.MBTRANSNO"
    End If
    TMPTrans = MyDatabase.MyReader(VSql)
    With TableList
      .Redraw = False
      .Rows.Count = 1
      While TMPTrans.Read()
        I = I + 1
        TableList.AddItem(TMPTrans.Item("MBTRANSUID") & vbTab & TMPTrans.Item("MBTRANSNO") & vbTab & FormatDateTime(TMPTrans.Item("MBTRANSDATE"), DateFormat.ShortDate) & vbTab & TMPTrans.Item("MBTRANSCUSTNAME") & vbTab & vbTab & TMPTrans.Item("STATUS") & vbTab & TMPTrans.Item("CREATEDUSER"))
        .Rows(I).Height = 45
      End While
      .Redraw = True
    End With
    'Catch ex As Exception
    '    TableList.Redraw = True
    'End Try
    TMPTrans = Nothing
  End Sub

#End Region

#Region "Form Control Function"

  Private Sub Form_Invoice_List_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If screenWidth < 1024 Then
      Label11.Text = "NO" : VirtualKey1.Visible = False : VirtualKey2.Visible = False
      Label1.Text = "Cust"
      Panel1.Width = 1010
      Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y)
      Dim fSize2 As New SizeF((1010 / 679), (85 / 85))
      Panel1.Scale(fSize2)
      Dim origWidth As Integer = 1024
      Dim origHeight As Integer = Me.Height
      Me.Width = screenWidth
      Me.Height = screenHeight
      Dim fSize As New SizeF((Me.Width / origWidth), (Me.Height / origHeight))
      GroupBox2.Scale(fSize)
      TableList.Scale(fSize)
      Panel1.Scale(fSize)
    Else
      Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 45)
    End If

    FromDate.Value = Now.Date
    ToDate.Value = Now.Date

    FromDateLabel.Text = Format(FromDate.Value, "dd MMMM yyyy")
    ToDateLabel.Text = Format(ToDate.Value, "dd MMMM yyyy")

    Me.Cursor = Cursors.WaitCursor
    Call BasicInitialize()
    Call CheckPermission(UserInformation.UserTypeUID)
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub VirtualKey1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKey1.Click
    Dim VirtuKey As New VirtualKey
    VirtuKey.OBJBind(FindName, False)
    VirtuKey.ShowDialog()
  End Sub

  Private Sub VirtualKey2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKey2.Click
    Me.Cursor = Cursors.WaitCursor
    Dim VirtuKey As New VirtualKey
    VirtuKey.OBJBind(FindNo, False)
    VirtuKey.ShowDialog()
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub SearchByList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs)
    FindName.Text = Nothing
  End Sub

  Private Sub BTNSearch_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSearch.Click
    With TableList
      Me.Cursor = Cursors.WaitCursor
      Call BasicInitialize(Trim(FindNo.Text), Trim(FindName.Text))
      Me.Cursor = Cursors.Default
    End With
  End Sub

  Private Sub FindNo_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FindNo.KeyPress
    If e.KeyChar = Chr(13) Then
      BTNSearch_Click(sender, e)
    End If
  End Sub

  Private Sub FindName_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles FindName.KeyPress
    If e.KeyChar = Chr(13) Then
      BTNSearch_Click(sender, e)
    End If
  End Sub

  Private Sub BTNEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEdit.Click
    If TableList.Row > 0 Then
      'Removed By Rudy
      'If TableList.Item(TableList.Row, 5) = "NOT BILL" Then
      '    Me.ParentOBJForm.BillStatus = True
      'Else
      '    Me.ParentOBJForm.Billstatus = False
      'End If
      Me.ParentOBJForm.EditStatus = True
      Me.Close()
    End If
  End Sub

  Private Sub TableList_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TableList.DoubleClick
    If TableList.Row > 0 Then
      If TableList.Item(TableList.Row, 5) = "NOT BILL" Then
        Me.ParentOBJForm.BillStatus = True
      Else
        Me.ParentOBJForm.Billstatus = False
      End If
      Form_Custm_Display_MakeBill.IdFromInvoiceList.Text = TableList.Item(TableList.Row, 0)
      Me.ParentOBJForm.EditStatus = True
      Form_Custm_Display_MakeBill.Show()
      Me.Close()
    End If
  End Sub

  Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClose.Click
    If TableList.Row <= 0 Then
      If Me.ParentOBJForm.EditStatus = True Then
        Me.ParentOBJForm.EditStatus = False
      End If
    End If
    Me.ParentOBJForm.EditStatus = False
    Me.Close()
  End Sub

  Private Sub BTNVoid_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNVoid.Click

    If OkToVoid = False Then
      ShowMessage(Me, "Maaf, anda tidak mempunyai akses untuk melakukan void transaksi !")
      Exit Sub
    End If

    If TableList.Row > 0 Then
      If ShowQuestion(Me, "Apakah anda ingin membatalkan invoice nomor '" & TableList.Item(TableList.Row, 1) & "' ?") = True Then
        Call MyDatabase.MyAdapter("UPDATE RSVTRANS SET RSVTRANSSTAT = '0',MODIFIEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE RSVTRANSUID=(SELECT MBTRANSRSVTRANSUID FROM MBTRANS WHERE MBTRANSUID='" & TableList.Item(TableList.Row, 0) & "')")
        Call MyDatabase.MyAdapter("UPDATE MBTRANS SET DELETEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "', DELETEDUSER='" & ReplacePetik(UserInformation.UserName) & "',  MBTRANSCANCELLEDNOTE='Void Transaction " & TableList.Item(TableList.Row, 1) & "',MBTRANSSTAT = '-1' WHERE MBTRANSUID ='" & TableList.Item(TableList.Row, 0) & "'")
        Call BasicInitialize()
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

  Private Sub TableList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TableList.MouseDown
    If TableList.Rows.Count > 1 Then

      Dim NewStyle As C1.Win.C1FlexGrid.CellStyle
      NewStyle = TableList.Styles.Add("Click")
      NewStyle.BackColor = Color.LightCoral

      For i As Integer = 0 To TableList.Rows.Count - 1
        TableList.Item(i, 4) = False
        TableList.Rows(i).Style = Nothing
      Next
      TableList.Item(TableList.Row, 4) = True
      TableList.Rows(TableList.Row).Style = TableList.Styles("Click")
    End If
  End Sub
#End Region

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

  Private Sub CheckPermission(ByVal TypeUID As String)
    Dim TMPRecord As FbDataReader
    TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID IN ('2205')")
    While TMPRecord.Read()
      UserPermition.PermitionInitialize(TMPRecord.Item("USERCATCREATEACCESS"), TMPRecord.Item("USERCATEDITACCESS"), TMPRecord.Item("USERCATDELETEACCESS"), TMPRecord.Item("USERCATREADACCESS"), TMPRecord.Item("USERCATPRINTACCESS"), TMPRecord.Item("USERCATCHANGEDATEACCESS"), TMPRecord.Item("USERCATCHANGETIMEACCESS"), TMPRecord.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
    End While

    With UserPermition
      If .DeleteAccess Then
        OkToVoid = True
      Else
        OkToVoid = False
      End If
    End With
  End Sub

End Class