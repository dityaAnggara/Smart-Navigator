Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win
Imports C1.Win.C1FlexGrid
Imports DataDynamics.ActiveReports

Public Class Form_Reservation_Make_Order

#Region "Variable Reference"
    Dim CatCollection As New Collection
    Dim PMCollection As New Collection
    Dim CatPosition As Long = 0
    Dim PMPosition As Long = 0
    Dim hitungPopUP As Integer = 0
    Dim curRow As Integer = 0

    Dim UserPermition As New UserPermitionLib
    Dim ListCollection As New Collection
    Dim FormStatus As FormStatusLib

    Public ParentOBJForm As Object
    Dim TMPOrderListCollection As New Collection
    Public ItemNotes As String = Nothing
    Public colOrderDetailPaket As New Collection

    Structure CustDetailLib
        Dim ReservationNumber As String
        Dim CustUID As String
    End Structure

    Public CustDetailInfo As CustDetailLib

#End Region

#Region "Initialize & Object Function"

    Private Sub BasicInitialize()

        CatCollection = DBListCollection("SELECT * FROM INVENCAT WHERE (INVENCATLVL = '2' or INVENCATLVL = '3') and (INVENCATACTV IS NULL OR INVENCATACTV = 0 ) ORDER BY INVENCATDISPLAYORDER")

        Call CategoryList(IIf(CatCollection.Count > 0, 1, 0))
        Call ReinitializeOrderList()
        Call CheckPermission(UserInformation.UserTypeUID, True)

    End Sub
    
Private Sub SettingAccess(ByVal Access As Boolean)

        BTNSave.Enabled = Access
        BTNTakeAway.Enabled = Access
        BTNNotes.Enabled = Access
        BTNReset.Enabled = Access
        BTNRemove.Enabled = Access
        GroupQty.Enabled = Access
        GroupCategory.Enabled = Access
        GroupItem.Enabled = Access

    End Sub

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

            If Not .CreateAccess Then
                SettingAccess(False)
            Else
                SettingAccess(True)
            End If

            If Not .EditAccess Then
                SettingAccess(False)
            Else
                SettingAccess(True)
            End If
            
            'Anjo - 25 Nov 2011 : Button remove sudah ikut di setting access
            'If Not .DeleteAccess Then
            '    BTNRemove.Enabled = False
            'Else
            '    BTNRemove.Enabled = True
            'End If
        End With

    End Sub

    Private Sub ReinitializeOrderList()

        Dim CurrentRecord As New ArrayList
        'Item UID, QTY, Item, Price, Amount, TXTNotes, DetailUID, Notes, TA
        TMPOrderListCollection = ParentOBJForm.OrderListCollection

        With OrderDetail
            If Not IsNothing(TMPOrderListCollection) Then
                For i As Integer = 1 To TMPOrderListCollection.Count
                    CurrentRecord = TMPOrderListCollection(i)
                    .AddItem(vbTab & CurrentRecord(0) & vbTab & CurrentRecord(1) & vbTab & CurrentRecord(2) & vbTab & CurrentRecord(3) & vbTab & CurrentRecord(4) & vbTab & CurrentRecord(5) & vbTab & CurrentRecord(6) & vbTab & CurrentRecord(7) & vbTab & CurrentRecord(8) & vbTab & CurrentRecord(9) & vbTab & CurrentRecord(10) & vbTab & CurrentRecord(11))
                    .Rows(.Rows.Count - 1).Height = 45
                Next
                Call ReInitializePrice()
            End If
        End With

    End Sub

    Private Sub ResetAll(Optional ByVal All As Boolean = True)

        If All Then
            For Each OBJ As Object In GroupCategory.Controls
                If TypeOf OBJ Is C1Input.C1Button Then
                    If Mid(OBJ.name, 1, 8) = "Category" Then
                        OBJ.VisualStyle = C1Input.VisualStyle.Office2007Silver
                        OBJ.Enabled = False
                        OBJ.Text = "-"
                    End If
                End If
            Next
            BackCategory.Enabled = False : NextCategory.Enabled = False
        End If

        For Each OBJ As Object In GroupItem.Controls
            If TypeOf OBJ Is C1Input.C1Button Then
                If Mid(OBJ.name, 1, 4) = "Item" Then
                    OBJ.VisualStyle = C1Input.VisualStyle.Office2007Silver
                    OBJ.Enabled = False
                    OBJ.Text = "-"
                End If
            End If
        Next
        BackItem.Enabled = False : NextItem.Enabled = False

    End Sub

    Private Sub CategoryList(ByVal Position As Long)

        Me.Cursor = Cursors.WaitCursor
        Dim CurrentRecord As New ArrayList
        Dim LoopFrom As Long, LoopTo As Long
        Dim CurOBJIndex As Integer
        Dim x As Integer = 0

        Call ResetAll()
        CatPosition = Position
        If CatCollection.Count > 9 Then
            LoopFrom = Position
            If Position + 8 > CatCollection.Count Then
                LoopTo = CatCollection.Count
            Else
                LoopTo = Position + 8
            End If
        Else
            LoopFrom = Position
            LoopTo = CatCollection.Count
        End If

        If Position > 0 Then
            For i As Integer = LoopFrom To LoopTo
                CurrentRecord = CatCollection(i)

                CurOBJIndex = IIf(i > 9, (i Mod 9), i)
                CurOBJIndex = IIf(CurOBJIndex = 0, 9, CurOBJIndex)

                For Each OBJ As Object In GroupCategory.Controls
                    If TypeOf OBJ Is C1Input.C1Button Then
                        If OBJ.name = "Category" & CurOBJIndex Then
                            If IsDBNull(CurrentRecord(7)) Then
                                OBJ.VisualStyle = C1Input.VisualStyle.Office2007Blue
                            Else
                                If CurrentRecord(7).ToString = "DEFAULT COLOUR" Then
                                    OBJ.VisualStyle = C1Input.VisualStyle.Office2007Blue
                                Else
                                    OBJ.visualstyle = C1Input.VisualStyle.System
                                    OBJ.BackColor = GetColor(CurrentRecord(7).ToString, True)
                                    OBJ.forecolor = GetColor(CurrentRecord(7).ToString, False)
                                End If
                            End If
                            OBJ.Enabled = True
                            OBJ.text = Replace(CurrentRecord(1), "&", "&&")
                            OBJ.tag = CurrentRecord(0)
                        End If
                    End If
                Next
            Next
        End If

        BackCategory.Enabled = Position > 9
        NextCategory.Enabled = CatCollection.Count > Position + 8
        BackCategory.VisualStyle = IIf(BackCategory.Enabled, C1Input.VisualStyle.Office2007Blue, C1Input.VisualStyle.Office2007Silver)
        NextCategory.VisualStyle = IIf(NextCategory.Enabled, C1Input.VisualStyle.Office2007Blue, C1Input.VisualStyle.Office2007Silver)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub PMList(ByVal Position As Long)

        Me.Cursor = Cursors.WaitCursor
        Dim CurrentRecord As New ArrayList
        Dim LoopFrom As Long, LoopTo As Long
        Dim CurOBJIndex As Integer

        Call ResetAll(False)
        PMPosition = Position

        If PMCollection.Count > 27 Then
            LoopFrom = Position
            If Position + 26 > PMCollection.Count Then
                LoopTo = PMCollection.Count
            Else
                LoopTo = Position + 26
            End If
        Else
            LoopFrom = Position
            LoopTo = PMCollection.Count
        End If

        If Position > 0 Then
            For i As Integer = LoopFrom To LoopTo
                CurrentRecord = PMCollection(i)

                CurOBJIndex = IIf(i > 27, (i Mod 27), i)
                CurOBJIndex = IIf(CurOBJIndex = 0, 27, CurOBJIndex)

                For Each OBJ As Object In GroupItem.Controls
                    If TypeOf OBJ Is C1Input.C1Button Then
                        If OBJ.name = "Item" & Format(CurOBJIndex, "00") Then
                            If IsDBNull(CurrentRecord(31)) Then
                                OBJ.VisualStyle = C1Input.VisualStyle.Office2007Blue
                            Else
                                If CurrentRecord(31).ToString = "DEFAULT COLOUR" Then
                                    OBJ.VisualStyle = C1Input.VisualStyle.Office2007Blue
                                Else
                                    OBJ.visualstyle = C1Input.VisualStyle.System
                                    OBJ.backcolor = GetColor(CurrentRecord(31).ToString, True)
                                    OBJ.forecolor = GetColor(CurrentRecord(31).ToString, False)
                                End If
                            End If

                            OBJ.Enabled = True
                            OBJ.text = Replace(CurrentRecord(2), "&", "&&")
                            Dim selectedPriceLevel As String = ""
                            Select Case CInt(CurrentRecord(15))
                                Case 1 : selectedPriceLevel = CStr(CurrentRecord(21))
                                Case 2 : selectedPriceLevel = CStr(CurrentRecord(22))
                                Case 3 : selectedPriceLevel = CStr(CurrentRecord(23))
                                Case 4 : selectedPriceLevel = CStr(CurrentRecord(24))
                                Case 5 : selectedPriceLevel = CStr(CurrentRecord(25))
                                Case 6 : selectedPriceLevel = CStr(CurrentRecord(26))
                                Case 7 : selectedPriceLevel = CStr(CurrentRecord(27))
                                Case 8 : selectedPriceLevel = CStr(CurrentRecord(28))
                                Case 9 : selectedPriceLevel = CStr(CurrentRecord(29))
                                Case 10 : selectedPriceLevel = CStr(CurrentRecord(30))
                            End Select
                            OBJ.tag = CurrentRecord(0) & MY_DELIMITER & CurrentRecord(2) & MY_DELIMITER & CurrentRecord(3) & MY_DELIMITER & CurrentRecord(16) & MY_DELIMITER & selectedPriceLevel & MY_DELIMITER & CurrentRecord(32)
                        End If
                    End If
                Next
            Next
        End If

        BackItem.Enabled = Position > 27
        NextItem.Enabled = PMCollection.Count > Position + 26
        BackItem.VisualStyle = IIf(BackItem.Enabled, C1Input.VisualStyle.Office2007Blue, C1Input.VisualStyle.Office2007Silver)
        NextItem.VisualStyle = IIf(NextItem.Enabled, C1Input.VisualStyle.Office2007Blue, C1Input.VisualStyle.Office2007Silver)
        Me.Cursor = Cursors.Default

    End Sub

    Private Function GetColor(ByVal inputString As String, ByVal isBackground As Boolean) As Color

        Dim fColor As Color, bColor As Color

        Select Case inputString
            Case "DarkRed | White"
                bColor = Color.DarkRed
                fColor = Color.White
            Case "IndianRed | White"
                bColor = Color.IndianRed
                fColor = Color.White
            Case "OrangeRed | White"
                bColor = Color.OrangeRed
                fColor = Color.White
            Case "SandyBrown | Black"
                bColor = Color.SandyBrown
                fColor = Color.Black
            Case "PeachPuff | Black"
                bColor = Color.PeachPuff
                fColor = Color.Black
            Case "Gold |Black"
                bColor = Color.Gold
                fColor = Color.Black
            Case "DarkKhaki | Black"
                bColor = Color.DarkKhaki
                fColor = Color.Black
            Case "YellowGreen | White"
                bColor = Color.YellowGreen
                fColor = Color.White
            Case "DarkGreen | White"
                bColor = Color.DarkGreen
                fColor = Color.White
            Case "LawnGreen | Black"
                bColor = Color.LawnGreen
                fColor = Color.Black
            Case "Turquoise | Black"
                bColor = Color.Turquoise
                fColor = Color.Black
            Case "DodgerBlue | White"
                bColor = Color.DodgerBlue
                fColor = Color.White
            Case "MediumBlue | White"
                bColor = Color.MediumBlue
                fColor = Color.White
            Case "BlueViolet | White"
                bColor = Color.BlueViolet
                fColor = Color.White
            Case "Fuchsia | White"
                bColor = Color.Fuchsia
                fColor = Color.White
            Case "DarkMagenta | White"
                bColor = Color.DarkMagenta
                fColor = Color.White
            Case "LightBlue | Black"
                bColor = Color.LightBlue
                fColor = Color.Black
        End Select

        If isBackground Then
            Return bColor
        Else
            Return fColor
        End If

    End Function

    Private Sub CategoryClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Category1.Click, Category2.Click, Category3.Click, Category4.Click, Category5.Click, Category6.Click, Category7.Click, Category8.Click, Category9.Click
        Me.Cursor = Cursors.WaitCursor
        PMCollection = DBListCollection("SELECT A.INVENUID, A.INVENNO, A.INVENNAME, A.INVENLEVEL, A.INVENTYPEID, A.INVENCATUID, A.INVENPARENTUID, A.INVENMEASUNITUID, A.INVENDFTWAREHUID, A.INVENDISCPERC, A.INVENSALESTAXUID, A.INVENDFTVENDUID, A.INVENPURCHTAXUID," & _
                                        "A.INVENMINQTYREORDER, A.INVENDESC, A.INVENDFTPRICELISTLVL, A.INVENMEASUNITDESC, A.INVENKITCHENUID, A.INVENACTV, A.INVENDISPLAYORDER, A.INVENISPRINTED, B.INVENPRICELISTLVL1,B.INVENPRICELISTLVL2,B.INVENPRICELISTLVL3,B.INVENPRICELISTLVL4," & _
                                        "B.INVENPRICELISTLVL5,B.INVENPRICELISTLVL6,B.INVENPRICELISTLVL7,B.INVENPRICELISTLVL8,B.INVENPRICELISTLVL9,B.INVENPRICELISTLVL10,A.INVENCOLOUR,A.INVENEDITABLEMENU FROM INVEN A INNER JOIN INVENPRICELIST B ON  A.INVENUID=B.INVENUID WHERE A.INVENCATUID = '" & sender.tag & "' AND (A.INVENACTV IS NULL OR A.INVENACTV = 0 ) ORDER BY A.INVENNAME")
        Call PMList(IIf(PMCollection.Count > 0, 1, 0))
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Item01.Click, Item02.Click, Item03.Click, Item04.Click, Item05.Click, Item06.Click, Item07.Click, Item08.Click, Item09.Click, Item10.Click, Item11.Click, Item12.Click, Item13.Click, Item14.Click, Item15.Click, Item16.Click, Item17.Click, Item18.Click, Item19.Click, Item20.Click, Item21.Click, Item22.Click, Item23.Click, Item24.Click, Item25.Click, Item26.Click, Item27.Click

    'MessageBox.Show("non table service non image")

    Dim Bypas As Boolean = False
    'Item UID, QTY, Item, Price, Amount, TXTNotes, Detail UID, Notes, TA

    Dim selItemUID As String, selItemName As String, selItemLevel As String, selItemMeas As String, isOpenPrice As String
    Dim selItemPrice As String
    Dim arrayData As String()

    arrayData = Split(sender.tag, MY_DELIMITER)
    If UBound(arrayData) = 5 Then

      selItemUID = CStr(arrayData(0))
      selItemName = CStr(arrayData(1))
      selItemLevel = CStr(arrayData(2))
      selItemMeas = CStr(arrayData(3))
      selItemPrice = CStr(arrayData(4))
      isOpenPrice = CStr(arrayData(5))

      With OrderDetail
        For i As Integer = 1 To .Rows.Count - 1
          If .Item(i, 1) = selItemUID Then
            .Item(i, 2) = .Item(i, 2) + 1
            .Item(i, 5) = .Item(i, 2) * .Item(i, 4)
            Bypas = True : Exit For
          End If
        Next
        If Not Bypas Then
          If isOpenPrice = "1" Then
            With Form_Edit_menu_On_MakeOrder
              .Cancel = False
              .txtNamaMenu.Text = selItemName
              .txtHarga.Text = selItemPrice
              .ShowDialog(Me)
              If .Cancel = True Then Exit Sub
              selItemName = .txtNamaMenu.Text
              selItemPrice = (CDec(.txtHarga.Text)).ToString
            End With
          End If
          Application.DoEvents()
          .AddItem(vbTab & selItemUID & vbTab & "1" & vbTab & selItemName & vbTab & selItemPrice & vbTab & selItemPrice & vbTab & vbTab & "0" & vbTab & vbTab & vbTab & selItemLevel & vbTab & selItemMeas)
          .Rows(.Rows.Count - 1).Height = 45
          .Row = .Rows.Count - 1
        End If
      End With
      'OrderDetail.Select(OrderDetail.Rows.Count - 1, 0)
      Call ReInitializePrice()
    End If

    End Sub

    Private Sub ReInitializePrice()

        Dim totalItem As Decimal = 0
        With OrderDetail
            If .Rows.Count > 1 Then
                Dim ReTotal As Double = 0
                For i As Integer = 1 To .Rows.Count - 1
                    ReTotal = ReTotal + .Item(i, 5)
                    totalItem = totalItem + .Item(i, 2)
                Next
                SubTotalTxt.Text = FormatNumber(ReTotal, 0)
                BalanceDueTxt.Text = FormatNumber(ReTotal, 0)
                If InStr(totalItem.ToString, ",") > 0 Then
                    lblTotalItem.Text = FormatNumber(totalItem, 2)
                Else
                    lblTotalItem.Text = FormatNumber(totalItem, 0)
                End If
            Else
                SubTotalTxt.Text = "0"
                BalanceDueTxt.Text = "0"
                lblTotalItem.Text = "0"
            End If
        End With

    End Sub

    Private Sub QTYUpdate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QTY01.Click, QTY02.Click, QTY03.Click, QTY04.Click, QTY05.Click, QTY06.Click, QTY07.Click, QTY08.Click, QTY09.Click, QTY10.Click
        With OrderDetail
            If .Rows.Count > 1 Then
                .Item(.Row, 2) = sender.text
                .Item(.Row, 5) = .Item(.Row, 2) * .Item(.Row, 4)
            End If
        End With
        Call ReInitializePrice()
    End Sub

    Private Sub QTYPlusMinus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QTYPlus.Click, QTYMinus.Click
        With OrderDetail
            If .Rows.Count > 1 Then
                Select Case sender.name
                    Case "QTYPlus"
                        .Item(.Row, 2) = .Item(.Row, 2) + 1
                        .Item(.Row, 5) = .Item(.Row, 2) * .Item(.Row, 4)
                    Case "QTYMinus"
                        If .Item(.Row, 2) > 1 Then
                            .Item(.Row, 2) = .Item(.Row, 2) - 1
                            .Item(.Row, 5) = .Item(.Row, 2) * .Item(.Row, 4)
                        End If
                End Select
            End If
        End With
        Call ReInitializePrice()
    End Sub

    Private Sub QtyCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QtyCalculator.Click
        If OrderDetail.Row > 0 Then
            QtyTxt.Text = OrderDetail.Item(OrderDetail.Row, 2)

            Dim VirtuCalculator As New Form_Virtual_Calculator
            VirtuCalculator.showComma = True
            VirtuCalculator.OBJBind(QtyTxt)
            VirtuCalculator.ShowDialog()

            If QtyTxt.Text = 0 Then
                QtyTxt.Text = 1
            End If

            OrderDetail.Item(OrderDetail.Row, 2) = QtyTxt.Text
            OrderDetail.Item(OrderDetail.Row, 5) = OrderDetail.Item(OrderDetail.Row, 2) * OrderDetail.Item(OrderDetail.Row, 4)

            Call ReInitializePrice()
        End If
    End Sub

    Private Sub CatBackNext(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackCategory.Click, NextCategory.Click
        Select Case sender.name
            Case "BackCategory"
                CatPosition = CatPosition - 9
            Case "NextCategory"
                CatPosition = CatPosition + 9
        End Select

        If 0 < CatPosition < CatCollection.Count Then
            Call CategoryList(CatPosition)
        End If

    End Sub

    Private Sub PMBackNext(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackItem.Click, NextItem.Click
        Select Case sender.name
            Case "BackItem"
                PMPosition = PMPosition - 27
            Case "NextItem"
                PMPosition = PMPosition + 27
        End Select

        If 0 < PMPosition < PMCollection.Count Then
            Call PMList(PMPosition)
        End If

    End Sub

    Private Sub FocusMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMoveUp.Click, BTNMoveDown.Click
        With OrderDetail
            If .Rows.Count > 1 Then
                Select Case sender.name
                    Case "BTNMoveUp"
                        If .Row > 1 Then .Row = .Row - 1
                        OrderDetail_MouseDown(sender, e)
                    Case "BTNMoveDown"
                        If .Row < .Rows.Count - 1 Then .Row = .Row + 1
                        OrderDetail_MouseDown(sender, e)
                End Select
            End If
        End With
    End Sub

    Private Sub BTNRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNRemove.Click
        With OrderDetail
            If .Rows.Count > 1 Then
                If ShowQuestion(Me, "Hapus order pesanan '" & .Item(.Row, 3) & "' dari daftar ?") = True Then
                    'If Len(Trim(.Item(.Row, 7))) > 0 Then
                    '    Dim Query As String = Nothing
                    '    Query = "DELETE FROM RSVTRANSDTDETAIL WHERE RSVTRANSDTUID = '" & .Item(.Row, 7) & "'"
                    '    Call MyDatabase.MyAdapter(Query)
                    'End If
                    .Rows.Remove(.Row)
                    Call ReInitializePrice()
                End If
            End If
        End With
    End Sub

    Private Sub BTNTakeAway_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNTakeAway.Click
        With OrderDetail
            If .Rows.Count > 1 Then
                .Item(.Row, 9) = Not .Item(.Row, 9)
            End If
        End With
    End Sub
#End Region

#Region "Form Control Function"

    Private Sub Form_Reservation_Make_Order_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
        If txtBarcode.Visible = False Then Exit Sub
        If Char.IsLetterOrDigit(e.KeyChar) Then
            e.Handled = True
            txtBarcode.Text = e.KeyChar
            txtBarcode.Focus()
        Else
            e.Handled = False
        End If
    End Sub

    Private Sub Form_Reservation_Make_Order_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        If PrefInfo.UseBarcode = "0" Then OrderDetail.Height = 540 : txtBarcode.Visible = False Else OrderDetail.Height = 501 : txtBarcode.Visible = True
        Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 44)
        OrderDetail.Styles("Normal").WordWrap = True
        Call BasicInitialize()

    End Sub

    Private Sub BTNNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNNotes.Click
        With OrderDetail
            If .Rows.Count > 1 Then
                ItemNotes = .Item(.Row, 6)

                Dim OBJNew As New Dialog_Notes
                OBJNew.Name = "Dialog_Notes"
                OBJNew.ParentOBJForm = Me
                OBJNew.ShowDialog()

                .Item(.Row, 6) = ItemNotes
                .Item(.Row, 8) = Not ItemNotes = Nothing
            End If
        End With
    End Sub

    Private Sub BTNReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNReset.Click

        If ShowQuestion(Me, "Hapus semua order pesanan ?") = True Then
            OrderDetail.Rows.Count = 1
            Call ReInitializePrice()
        End If

    End Sub

    Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click
        If OrderDetail.Rows.Count > 0 Then
            Dim NEWOrderListCollection As New Collection, NEWPriceDetailCollection As New Collection
            With OrderDetail
                For i As Integer = 1 To .Rows.Count - 1
                    Dim OrderList As New ArrayList
                    For j As Integer = 1 To .Cols.Count - 1
                        OrderList.Add(.Item(i, j))
                    Next
                    NEWOrderListCollection.Add(OrderList)
                Next
            End With

            NEWPriceDetailCollection.Add(CDbl(BalanceDueTxt.Text))
            NEWPriceDetailCollection.Add(CDbl(0))
            NEWPriceDetailCollection.Add(CDbl(0))
            NEWPriceDetailCollection.Add(CDbl(BalanceDueTxt.Text))

            ParentOBJForm.OrderListCollection = NEWOrderListCollection
            ParentOBJForm.PriceDetailCollection = NEWPriceDetailCollection            
            ParentOBJForm.colOrderDetailPaket = colOrderDetailPaket
        End If
        Me.Close()
    End Sub

    Private Sub BTNClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClose.Click
        Me.Close()
    End Sub

#End Region

    Private Sub OrderDetail_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles OrderDetail.MouseDown
        If OrderDetail.Rows.Count > 1 Then
            Dim NewStyle As CellStyle
            NewStyle = OrderDetail.Styles.Add("Click")
            NewStyle.BackColor = Color.LightCoral

            Dim Style As CellStyle
            Style = OrderDetail.Styles.Add("Disable")
            Style.BackColor = Color.Silver

            For i As Integer = 1 To OrderDetail.Rows.Count - 1
                OrderDetail.Rows(i).Style = Nothing
                If OrderDetail.Item(i, 10).ToString = "1" Then
                    OrderDetail.Rows(i).Style = OrderDetail.Styles("Disable")
                End If
            Next
            OrderDetail.Rows(OrderDetail.Row).Style = OrderDetail.Styles("Click")
            If OrderDetail.Item(OrderDetail.Row, 7).ToString = "0" Then Exit Sub
            tmrPopUp.Enabled = True
        End If
    End Sub

    Private Sub txtBarcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.GotFocus
        Me.KeyPreview = False
        If Trim(txtBarcode.Text) = "<Enter product id here>" Then
            txtBarcode.ForeColor = Color.Silver
            txtBarcode.SelectionStart = 0
        Else
            txtBarcode.ForeColor = Color.Black
            txtBarcode.SelectionStart = Len(txtBarcode.Text)
        End If
    End Sub

    Private Sub txtBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode = Keys.Return Then
            If Trim(txtBarcode.Text) = "" Then Exit Sub
            Dim tmpData As String = Nothing

            Dim rs As FbDataReader
            rs = MyDatabase.MyReader("SELECT A.INVENUID, A.INVENNO, A.INVENNAME, A.INVENLEVEL, A.INVENTYPEID, A.INVENCATUID, A.INVENPARENTUID, A.INVENMEASUNITUID, A.INVENDFTWAREHUID, A.INVENDISCPERC, A.INVENSALESTAXUID, A.INVENDFTVENDUID, A.INVENPURCHTAXUID, A.INVENMINQTYREORDER, A.INVENDESC, A.INVENDFTPRICELISTLVL, A.INVENMEASUNITDESC, A.INVENKITCHENUID, A.INVENACTV, A.INVENDISPLAYORDER, A.INVENISPRINTED, B.INVENPRICELISTLVL1,B.INVENPRICELISTLVL2,B.INVENPRICELISTLVL3,B.INVENPRICELISTLVL4,B.INVENPRICELISTLVL5,B.INVENPRICELISTLVL6,B.INVENPRICELISTLVL7,B.INVENPRICELISTLVL8,B.INVENPRICELISTLVL9,B.INVENPRICELISTLVL10,A.INVENCOLOUR FROM INVEN A, INVENPRICELIST B WHERE A.INVENUID=B.INVENUID AND A.INVENBARCODE = '" & ReplacePetik(txtBarcode.Text) & "' AND (A.INVENACTV IS NULL OR A.INVENACTV = 0 ) ORDER BY A.INVENNAME")
            If rs.Read() = False Then
                ShowMessage(Me, "Maaf, menu/item tidak ditemukan !", True)
                txtBarcode.SelectAll()
                Exit Sub
            Else
                Dim selectedPriceLevel As String = ""
                Select Case CInt(rs(15))
                    Case 1 : selectedPriceLevel = CStr(rs(21))
                    Case 2 : selectedPriceLevel = CStr(rs(22))
                    Case 3 : selectedPriceLevel = CStr(rs(23))
                    Case 4 : selectedPriceLevel = CStr(rs(24))
                    Case 5 : selectedPriceLevel = CStr(rs(25))
                    Case 6 : selectedPriceLevel = CStr(rs(26))
                    Case 7 : selectedPriceLevel = CStr(rs(27))
                    Case 8 : selectedPriceLevel = CStr(rs(28))
                    Case 9 : selectedPriceLevel = CStr(rs(29))
                    Case 10 : selectedPriceLevel = CStr(rs(30))
                End Select
                tmpData = rs(0) & MY_DELIMITER & rs(2) & MY_DELIMITER & rs(3) & MY_DELIMITER & rs(16) & MY_DELIMITER & selectedPriceLevel
            End If

            Dim Bypas As Boolean = False
            'Item UID, QTY, Item, Price, Amount, TXTNotes, Order By, Notes, TA

            Dim selItemUID As String, selItemName As String, selItemLevel As String, selItemMeas As String
            Dim selItemPrice As String
            Dim arrayData As String()

            arrayData = Split(tmpData, MY_DELIMITER)
            If UBound(arrayData) = 4 Then

                selItemUID = CStr(arrayData(0))
                selItemName = CStr(arrayData(1))
                selItemLevel = CStr(arrayData(2))
                selItemMeas = CStr(arrayData(3))
                selItemPrice = CStr(arrayData(4))

                With OrderDetail
                    For i As Integer = 1 To .Rows.Count - 1
                        If .Item(i, 1) = selItemUID Then
                            If .Item(i, 10) = "1" Then
                                ShowMessage(Me, "Maaf, anda tidak dapat menambahkan order pesanan yang sudah dimasak." & vbNewLine & "Silakan keluar dari form ini, dan panggil form Make Order, untuk menambahkan order baru !")
                                Exit Sub
                            End If

                            .Item(i, 2) = .Item(i, 2) + 1
                            .Item(i, 5) = .Item(i, 2) * .Item(i, 4)
                            Bypas = True : Exit For
                        End If
                    Next
                    If Not Bypas Then
                        .AddItem(vbTab & selItemUID & vbTab & "1" & vbTab & selItemName & vbTab & selItemPrice & vbTab & selItemPrice & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & selItemLevel & vbTab & selItemMeas)
                        .Rows(.Rows.Count - 1).Height = 45
                        .Row = .Rows.Count - 1
                    End If
                End With
                'Call FocusMove(BTNMoveDown, e)
                Call ReInitializePrice()
            End If
            txtBarcode.Text = ""            
        End If
    End Sub

    Private Sub txtBarcode_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtBarcode.KeyPress
        txtBarcode.Text = Replace(txtBarcode.Text, "<Enter product id here>", "")
    End Sub

    Private Sub txtBarcode_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyUp
        If Trim(txtBarcode.Text) = "" Then
            txtBarcode.ForeColor = Color.Silver
            txtBarcode.Text = "<Enter product id here>"
        Else
            txtBarcode.ForeColor = Color.Black
        End If
    End Sub

    Private Sub txtBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.LostFocus
        Me.KeyPreview = True
        txtBarcode.Text = "<Enter product id here>"
        txtBarcode.ForeColor = Color.Silver
    End Sub

    Private Sub txtBarcode_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles txtBarcode.MouseDown
        If Trim(txtBarcode.Text) = "<Enter product id here>" Then
            txtBarcode.ForeColor = Color.Silver
            txtBarcode.SelectionStart = 0
        End If
    End Sub

    Private Sub tmrPopUp_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tmrPopUp.Tick
        If hitungPopUP > 6 Then
            hitungPopUP = 0
            curRow = OrderDetail.Row
            Dim tmpEditable As String = ""
            tmrPopUp.Enabled = False
            Dim rs As FbDataReader
            Dim tmpSetting As String = ""
            rs = MyDatabase.MyReader("SELECT * FROM INVEN WHERE INVENUID='" & OrderDetail.Item(OrderDetail.Row, 1) & "'")
            If rs.Read() = True Then
                If rs("INVENEDITABLEMENU").ToString = "1" Then
                    tmpSetting = "YES"
                    tmpEditable = OrderDetail.Item(curRow, 3).ToString & MY_DELIMITER & OrderDetail.Item(curRow, 4).ToString & MY_DELIMITER & OrderDetail.Item(curRow, 1).ToString & MY_DELIMITER & OrderDetail.Item(curRow, 7).ToString
                Else
                    tmpSetting = "NO"
                End If
                If PrefInfo.POSPREFEDITABLEPACKET = "1" And rs("INVENLEVEL").ToString = "3" Then
                    tmpSetting = tmpSetting & MY_DELIMITER & "YES"
                Else
                    tmpSetting = tmpSetting & MY_DELIMITER & "NO"
                End If
            End If
            rs = Nothing
            If tmpSetting = "NO" & MY_DELIMITER & "NO" Then Exit Sub
            Dim newForm As New Form_Pop_Up_Open_Menu
            newForm.dataMenu = tmpEditable
            newForm.formAsal = Me
            newForm.settingForm = tmpSetting
            newForm.Show()
        End If
        hitungPopUP += 1
    End Sub

    Public Sub updateGrid(ByVal namaItem As String, ByVal hargaItem As String)
        'orderDetail.Item(1, 3) = namaItem
        'With Form_Edit_menu_On_MakeOrder
        '    .Cancel = False
        '    .txtNamaMenu.Text = "TEST" 'OrderDetail.Item(curRow, 4)
        '    .txtHarga.Text = "100000" 'OrderDetail.Item(curRow, 4)
        '    .ShowDialog(Me)
        'If .Cancel = True Then Exit Sub
        'selItemName = .txtNamaMenu.Text
        'selItemPrice = (CDec(.txtHarga.Text)).ToString
        'MsgBox(curRow)
        With Me.OrderDetail
            If .Rows.Count > 1 Then
                .Item(curRow, 4) = CInt(hargaItem)
                .Item(curRow, 3) = namaItem
                .Item(curRow, 5) = CInt(hargaItem) * .Item(curRow, 2)
            End If
        End With
        Call ReInitializePrice()
        'End With
    End Sub

    Private Sub OrderDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderDetail.Click

    End Sub
End Class