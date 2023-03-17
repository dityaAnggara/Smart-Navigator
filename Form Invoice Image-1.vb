Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win
Imports C1.Win.C1FlexGrid
Imports DataDynamics.ActiveReports
Imports System.IO

Public Class Form_Invoice_Image

  Public tableUID As String = Nothing
  Public pubIDCustomer As String = Nothing
  Public pubNamaCustomer As String = Nothing

#Region "Variable Reference"

  Dim defaultCustUID As String
  Dim defaultCustName As String

  Dim defaultServiceUID As String
  Dim defaultServiceName As String

  Dim CatCollection As New Collection
  Dim PMCollection As New Collection
  Dim CatPosition As Long = 0
  Dim PMPosition As Long = 0

  Dim OrderListCollection As New Collection
  Public TransactionNumber As String
  Public ItemNotes As String = Nothing

  Public TransactionUID As String = AutoUID()
  Public TransactionNo As String = Nothing
  Dim UIDtoRemove As New ArrayList

  Dim UserPermition As New UserPermitionLib
  Dim ListCollection As New Collection
  Dim FormStatus As FormStatusLib
  Public EditStatus As Boolean = False
  Public BillStatus As Boolean = False
  Dim Shift As String = GetShift()

  Dim tmpRSV As String
  Dim oldModifiedTime As String

#End Region

#Region "Initialize & Object Function"

  Public Sub BasicInitialize(Optional ByVal MBTransUID As String = Nothing)
    Dim VSql As String
    If PrefInfo.VDeptIntance_IsUse = False Or Trim(UserInformation.UserDeptUIDOnDB) = "1" Then
      VSql = "SELECT * FROM INVENCAT WHERE (INVENCATLVL = '2' or INVENCATLVL = '3') and (INVENCATACTV IS NULL OR INVENCATACTV = 0 ) ORDER BY INVENCATDISPLAYORDER "
    Else
      VSql = "SELECT"
      VSql = VSql & " B.INVENCATUID, B.INVENCATNAME, B.INVENCATLVL"
      VSql = VSql & " , B.INVENCATACTV, B.INVENCATISSALEXTAXINCLUDEDUU"
      VSql = VSql & " , B.INVENCATDISPLAYORDER, B.INVENCATSUBCATEGORYID"
      VSql = VSql & " , B.INVENCATCOLOUR, B.MENUCATTENANTUID"
      VSql = VSql & " FROM INVEN A"
      VSql = VSql & " LEFT JOIN INVENCAT B ON A.INVENCATUID = B.INVENCATUID"
      VSql = VSql & " WHERE (B.INVENCATLVL = '2' or B.INVENCATLVL = '3') "
      VSql = VSql & " AND (B.INVENCATACTV IS NULL OR B.INVENCATACTV = 0 )"
      VSql = VSql & " AND A.INVENDEPTUID='" & UserInformation.UserDeptUIDOnDB & "'"
      VSql = VSql & " GROUP BY"
      VSql = VSql & " B.INVENCATUID, B.INVENCATNAME, B.INVENCATLVL"
      VSql = VSql & " , B.INVENCATACTV, B.INVENCATISSALEXTAXINCLUDEDUU"
      VSql = VSql & " , B.INVENCATDISPLAYORDER, B.INVENCATSUBCATEGORYID"
      VSql = VSql & " , B.INVENCATCOLOUR, B.MENUCATTENANTUID"
      VSql = VSql & " ORDER BY INVENCATDISPLAYORDER"
    End If
    CatCollection = DBListCollection(VSql)
    Call CategoryList(IIf(CatCollection.Count > 0, 1, 0))
    Call ReinitializeOrderList()

    Call CustomerInitialize()
    Call ServiceInitialize()
    DateLabel.Text = Format(Now, "dd MMMM yyyy")
    CurrentDate.Value = Now.Date
    VisitorLabel.Text = "1"

    ListCollection = DBListCollection("SELECT COUNT(*) AS DATAEXISTS FROM MBTRANSDT WHERE MBTRANSDTITEMSTAT IS NULL OR MBTRANSDTITEMSTAT=0 AND MBTRANSUID= '" & MBTransUID & "'")
    FormStatus = OBJControlInitialize(ListCollection)
    Call OBJControlHandler(Me, FormStatus)
    Call CheckPermission(UserInformation.UserTypeUID, IIf(ListCollection.Count > 0, True, False))

    TransactionNoLabel.Text = AutoIDNumber("2202", "MBTRANS", "MBTRANSNO")
    BTNNew.Enabled = True
    BTNNew.VisualStyle = C1Input.VisualStyle.Office2007Blue

    For Each OBJ As Object In Me.Controls
      If OBJ.Name = "GroupQty" Or OBJ.name = "GBoxCalc" Then
        For Each CTR As Object In OBJ.Controls
          If TypeOf CTR Is C1Input.C1Button Then
            CTR.Enabled = True
            CTR.VisualStyle = C1Input.VisualStyle.Office2007Blue
          End If
        Next
      End If
    Next

    BTNMoveDown.Enabled = True
    BTNMoveDown.VisualStyle = C1Input.VisualStyle.Office2007Blue
    BTNMoveUp.Enabled = True
    BTNMoveUp.VisualStyle = C1Input.VisualStyle.Office2007Blue

    BTNMakeBill.Enabled = False
    BTNMakeBill.VisualStyle = C1Input.VisualStyle.Office2007Silver
    BTNPaymentInvoice.Enabled = False
    BTNPaymentInvoice.VisualStyle = C1Input.VisualStyle.Office2007Silver

  End Sub

  Private Sub CustomerInitialize()
    CustomerUID.Text = defaultCustUID
    CustomLabel.Text = defaultCustName
    CustomerNameLabel.Text = CustomLabel.Text
  End Sub

  Private Sub ServiceInitialize()

    ServiceUID.Text = defaultServiceUID
    ServiceLabel.Text = defaultServiceName

  End Sub

  Private Sub SettingAccess(ByVal Access As Boolean)
    'BTNMakeBill.Enabled = Access
    BTNTakeAway.Enabled = Access
    BTNNotes.Enabled = Access
    BTNReset.Enabled = Access
    BTNRemove.Enabled = Access

    'GroupQty.Enabled = Access
    'GroupCategory.Enabled = Access
    'GroupItem.Enabled = Access

    If Access = True Then
      'BTNMakeBill.VisualStyle = C1Input.VisualStyle.Office2007Blue
      BTNTakeAway.VisualStyle = C1Input.VisualStyle.Office2007Blue
      BTNNotes.VisualStyle = C1Input.VisualStyle.Office2007Blue
      BTNReset.VisualStyle = C1Input.VisualStyle.Office2007Blue
      BTNRemove.VisualStyle = C1Input.VisualStyle.Office2007Blue
    Else
      'BTNMakeBill.VisualStyle = C1Input.VisualStyle.Office2007Silver
      BTNTakeAway.VisualStyle = C1Input.VisualStyle.Office2007Silver
      BTNNotes.VisualStyle = C1Input.VisualStyle.Office2007Silver
      BTNReset.VisualStyle = C1Input.VisualStyle.Office2007Silver
      BTNRemove.VisualStyle = C1Input.VisualStyle.Office2007Silver
    End If
  End Sub

  Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)

    Dim TMPRecord As FbDataReader
    TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID IN ('2214')")
    While TMPRecord.Read()
      UserPermition.PermitionInitialize(TMPRecord.Item("USERCATCREATEACCESS"), TMPRecord.Item("USERCATEDITACCESS"), TMPRecord.Item("USERCATDELETEACCESS"), TMPRecord.Item("USERCATREADACCESS"), TMPRecord.Item("USERCATPRINTACCESS"), TMPRecord.Item("USERCATCHANGEDATEACCESS"), TMPRecord.Item("USERCATCHANGETIMEACCESS"), TMPRecord.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
    End While

    With UserPermition
      If Not .ReadAccess Then
        ShowMessage(Me, "Maaf, anda tidak mempunyai akses terhadap form ini !" & vbNewLine & "Silakan hubungi administrator anda.")
        Me.Close()
      End If

      If .CreateAccess Then
        SettingAccess(True)
      Else
        SettingAccess(False)
      End If
      'Susilo 3 Agust 2015,pembetulan boleh simpan meskipun hak akses edit disable
      'If .EditAccess Then
      '    If ListCollection.Count > 0 Then
      '        SettingAccess(True)
      '    Else
      '        SettingAccess(False)
      '    End If
      'Else
      '    SettingAccess(False)
      'End If

      If .DeleteAccess = False Then
        BTNRemove.Enabled = False
        BTNRemove.VisualStyle = C1Input.VisualStyle.Office2007Silver
        BTNReset.Enabled = False
        BTNReset.VisualStyle = C1Input.VisualStyle.Office2007Silver
      End If

    End With
  End Sub

  Public Sub GetDTOrder(ByVal MBUID As String)
    OrderListCollection.Clear()
    With OrderListCollection
      Dim ItemRecord As FbDataReader
      ItemRecord = MyDatabase.MyReader("SELECT A.*, B.INVENLEVEL FROM MBTRANSDT A, INVEN B WHERE A.MBTRANSDTITEMUID=B.INVENUID AND A.MBTRANSUID = '" & MBUID & "' AND A.MBTRANSDTITEMSTAT > -1")
      While ItemRecord.Read
        Dim ListArray As New ArrayList
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMUID"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMQTY"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMNAME"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMPRICE"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMQTY") * ItemRecord.Item("MBTRANSDTITEMPRICE"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMNOTE"))
        ListArray.Add(IIf(ItemRecord.Item("MBTRANSDTITEMNOTE") = Nothing, False, True))
        ListArray.Add(IIf(ItemRecord.Item("MBTRANSDTISTAKEAWAY") = 0, False, True))
        ListArray.Add(ItemRecord.Item("MBTRANSDTUID"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMSTAT"))
        ListArray.Add(ItemRecord.Item("INVENLEVEL"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMMEASUNITDESC"))
        OrderListCollection.Add(ListArray)
      End While
    End With
  End Sub

  Private Sub ReinitializeOrderList()

    Dim NewStyle As CellStyle
    NewStyle = OrderDetail.Styles.Add("Disable")
    NewStyle.BackColor = Color.Silver

    Dim CurrentRecord As New ArrayList
    'Item UID, QTY, Item, Price, Amount, TXTNotes, Notes, TA,UID
    With OrderDetail
      .Redraw = False
      If Not IsNothing(OrderListCollection) Then
        For i As Integer = 1 To OrderListCollection.Count
          CurrentRecord = OrderListCollection(i)
          .AddItem(vbTab & CurrentRecord(0) & vbTab & CurrentRecord(1) & vbTab & CurrentRecord(2) & vbTab & CurrentRecord(3) & vbTab & CurrentRecord(4) & vbTab & CurrentRecord(5) & vbTab & CurrentRecord(6) & vbTab & CurrentRecord(7) & vbTab & CurrentRecord(8) & vbTab & CurrentRecord(9) & vbTab & CurrentRecord(10) & vbTab & CurrentRecord(11))
          .Rows(.Rows.Count - 1).Height = 45
          If CurrentRecord(9) = 1 Then
            .Rows(i).Style = OrderDetail.Styles("Disable")
          End If
        Next

        Call ReInitializePrice()
      End If
      .Redraw = True
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
          OBJ.TextAlign = ContentAlignment.MiddleCenter
          OBJ.backgroundimage = Nothing
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

    Call ResetAll()
    CatPosition = Position
    If CatCollection.Count > 8 Then
      LoopFrom = Position
      If Position + 7 > CatCollection.Count Then
        LoopTo = CatCollection.Count
      Else
        LoopTo = Position + 7
      End If
    Else
      LoopFrom = Position
      LoopTo = CatCollection.Count
    End If

    If Position > 0 Then
      For i As Integer = LoopFrom To LoopTo
        CurrentRecord = CatCollection(i)

        CurOBJIndex = IIf(i > 8, (i Mod 8), i)
        CurOBJIndex = IIf(CurOBJIndex = 0, 8, CurOBJIndex)

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

    BackCategory.Enabled = Position > 8
    NextCategory.Enabled = CatCollection.Count > Position + 7
    BackCategory.VisualStyle = IIf(BackCategory.Enabled, C1Input.VisualStyle.Office2007Blue, C1Input.VisualStyle.Office2007Silver)
    NextCategory.VisualStyle = IIf(NextCategory.Enabled, C1Input.VisualStyle.Office2007Blue, C1Input.VisualStyle.Office2007Silver)
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

  Private Sub PMList(ByVal Position As Long)

    Me.Cursor = Cursors.WaitCursor
    Dim CurrentRecord As New ArrayList
    Dim LoopFrom As Long, LoopTo As Long
    Dim CurOBJIndex As Integer

    Call ResetAll(False)
    PMPosition = Position

    If PMCollection.Count > 16 Then
      LoopFrom = Position
      If Position + 15 > PMCollection.Count Then
        LoopTo = PMCollection.Count
      Else
        LoopTo = Position + 15
      End If
    Else
      LoopFrom = Position
      LoopTo = PMCollection.Count
    End If

    If Position > 0 Then
      For i As Integer = LoopFrom To LoopTo
        CurrentRecord = PMCollection(i)

        CurOBJIndex = IIf(i > 16, (i Mod 16), i)
        CurOBJIndex = IIf(CurOBJIndex = 0, 16, CurOBJIndex)

        For Each OBJ As Object In GroupItem.Controls
          If TypeOf OBJ Is C1Input.C1Button Then
            If OBJ.name = "Item" & Format(CurOBJIndex, "00") Then
              If IsDBNull(CurrentRecord(32)) Then
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
              Else
                If IsDBNull(CurrentRecord(31)) Then
                  OBJ.visualstyle = C1Input.VisualStyle.System
                Else
                  If CurrentRecord(31).ToString = "DEFAULT COLOUR" Then
                    OBJ.visualstyle = C1Input.VisualStyle.System
                  Else
                    OBJ.visualstyle = C1Input.VisualStyle.System
                    OBJ.backcolor = GetColor(CurrentRecord(31).ToString, True)
                    OBJ.forecolor = GetColor(CurrentRecord(31).ToString, False)
                  End If
                End If
                OBJ.backgroundImage = GetInvenImageFromByteArray(CurrentRecord(32))
                OBJ.TextAlign = ContentAlignment.BottomCenter
              End If

              OBJ.Enabled = True
              Dim tmpSisaMakanan As String = "-1"
              If PrefInfo.ShowQuantity = "1" Then
                tmpSisaMakanan = getTotalQtyMenu(CurrentRecord(0)).ToString
                OBJ.text = "(" & tmpSisaMakanan & ")" & vbNewLine & Replace(CurrentRecord(2), "&", "&&")
              Else
                OBJ.text = Replace(CurrentRecord(2), "&", "&&")
              End If
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
              OBJ.tag = CurrentRecord(0) & MY_DELIMITER & CurrentRecord(2) & MY_DELIMITER & CurrentRecord(3) & MY_DELIMITER & CurrentRecord(16) & MY_DELIMITER & selectedPriceLevel & MY_DELIMITER & CurrentRecord(33) & MY_DELIMITER & tmpSisaMakanan
            End If
          End If
        Next
      Next
    End If

    BackItem.Enabled = Position > 16
    NextItem.Enabled = PMCollection.Count > Position + 15
    BackItem.VisualStyle = IIf(BackItem.Enabled, C1Input.VisualStyle.Office2007Blue, C1Input.VisualStyle.Office2007Silver)
    NextItem.VisualStyle = IIf(NextItem.Enabled, C1Input.VisualStyle.Office2007Blue, C1Input.VisualStyle.Office2007Silver)
    Me.Cursor = Cursors.Default

  End Sub

  Private Function GetInvenImageFromByteArray(ByVal inputUID As Object) As Image

    Dim IMGResult() As Byte = inputUID
    Dim FS As MemoryStream = New MemoryStream(IMGResult)

    Return Image.FromStream(FS)

  End Function

  Private Sub CategoryClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Category1.Click, Category2.Click, Category3.Click, Category4.Click, Category5.Click, Category6.Click, Category7.Click, Category8.Click

    Me.Cursor = Cursors.WaitCursor
    If PrefInfo.VDeptIntance_IsUse = False Or Trim(GetFieldValueDBString("USERLOGIN", "USERLOGINDEPTUID", "WHERE USERLOGINUID='" & UserInformation.UserUID & "'")) = "1" Then
      PMCollection = DBListCollection("SELECT A.INVENUID, A.INVENNO, A.INVENNAME, A.INVENLEVEL, A.INVENTYPEID, A.INVENCATUID, A.INVENPARENTUID, A.INVENMEASUNITUID, A.INVENDFTWAREHUID, A.INVENDISCPERC, A.INVENSALESTAXUID, A.INVENDFTVENDUID, A.INVENPURCHTAXUID, A.INVENMINQTYREORDER, A.INVENDESC, A.INVENDFTPRICELISTLVL, A.INVENMEASUNITDESC," & _
                                      "A.INVENKITCHENUID, A.INVENACTV, A.INVENDISPLAYORDER, A.INVENISPRINTED, B.INVENPRICELISTLVL1,B.INVENPRICELISTLVL2,B.INVENPRICELISTLVL3,B.INVENPRICELISTLVL4,B.INVENPRICELISTLVL5,B.INVENPRICELISTLVL6,B.INVENPRICELISTLVL7,B.INVENPRICELISTLVL8,B.INVENPRICELISTLVL9,B.INVENPRICELISTLVL10,A.INVENCOLOUR,A.INVENIMG,A.INVENEDITABLEMENU FROM INVEN A INNER JOIN INVENPRICELIST B ON A.INVENUID=B.INVENUID  WHERE A.INVENCATUID = '" & sender.tag & "' AND (A.INVENACTV IS NULL OR A.INVENACTV = 0 ) ORDER BY A.INVENNAME")
    Else
      PMCollection = DBListCollection("SELECT A.INVENUID, A.INVENNO, A.INVENNAME, A.INVENLEVEL, A.INVENTYPEID, A.INVENCATUID, A.INVENPARENTUID, A.INVENMEASUNITUID, A.INVENDFTWAREHUID, A.INVENDISCPERC, A.INVENSALESTAXUID, A.INVENDFTVENDUID, A.INVENPURCHTAXUID, A.INVENMINQTYREORDER, A.INVENDESC, A.INVENDFTPRICELISTLVL, A.INVENMEASUNITDESC," & _
                                        "A.INVENKITCHENUID, A.INVENACTV, A.INVENDISPLAYORDER, A.INVENISPRINTED, B.INVENPRICELISTLVL1,B.INVENPRICELISTLVL2,B.INVENPRICELISTLVL3,B.INVENPRICELISTLVL4,B.INVENPRICELISTLVL5,B.INVENPRICELISTLVL6,B.INVENPRICELISTLVL7,B.INVENPRICELISTLVL8,B.INVENPRICELISTLVL9,B.INVENPRICELISTLVL10,A.INVENCOLOUR,A.INVENIMG,A.INVENEDITABLEMENU FROM INVEN A INNER JOIN INVENPRICELIST B ON A.INVENUID=B.INVENUID  WHERE A.INVENCATUID = '" & sender.tag & "' AND (A.INVENACTV IS NULL OR A.INVENACTV = 0 ) AND A.INVENDEPTUID='" & ReplacePetik(UserInformation.UserDeptUID) & "' ORDER BY A.INVENNAME")
    End If
    Call PMList(IIf(PMCollection.Count > 0, 1, 0))
    Me.Cursor = Cursors.Default

  End Sub

  Private Sub ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Item01.Click, Item02.Click, Item03.Click, Item04.Click, Item05.Click, Item06.Click, Item07.Click, Item08.Click, Item09.Click, Item10.Click, Item11.Click, Item12.Click, Item13.Click, Item14.Click, Item15.Click, Item16.Click

    Dim Bypas As Boolean = False
    'Item UID, QTY, Item, Price, Amount, TXTNotes, Order By, Notes, TA

    Dim selItemUID As String, selItemName As String, selItemLevel As String, selItemMeas As String, isOpenPrice As String
    Dim selItemPrice As String, jmlSisaMakanan As Integer
    Dim arrayData As String()

    arrayData = Split(sender.tag, MY_DELIMITER)
    If UBound(arrayData) >= 5 Then

      selItemUID = CStr(arrayData(0))
      selItemName = CStr(arrayData(1))
      selItemLevel = CStr(arrayData(2))
      selItemMeas = CStr(arrayData(3))
      selItemPrice = CStr(arrayData(4))
      isOpenPrice = CStr(arrayData(5))
      jmlSisaMakanan = CInt(arrayData(6))
      With OrderDetail
        For i As Integer = 1 To .Rows.Count - 1
          If .Item(i, 1) = selItemUID Then
            If PrefInfo.ShowQuantity = "1" And jmlSisaMakanan < CInt(.Item(i, 2) + 1) Then
              If ShowQuestion(Me, "Maaf, jumlah menu yang Anda pilih sudah habis atau tidak cukup untuk di order. Lanjutkan ?", True) = False Then
                Exit Sub : Bypas = True : Exit For
              End If
            End If
            .Item(i, 2) = .Item(i, 2) + 1
            .Item(i, 5) = .Item(i, 2) * .Item(i, 4)
            'ShowPoleDisplay(Mid(.Item(i, 2) & "x" & .Item(i, 3), 1, 20) & vbNewLine & AddPrefixSpace("@" & .Item(i, 4)))
            Application.DoEvents()
            Call ShowPoleDisplay(Mid(.Item(i, 2) & "x" & .Item(i, 3), 1, 18) & vbNewLine & FormatNumber(.Item(i, 5), 0), False)
            'Call ShowPoleDisplay(FormatNumber(.Item(i, 5), 0), True)
            Bypas = True : Exit For
          End If
        Next
        If Not Bypas Then
          If PrefInfo.ShowQuantity = "1" And jmlSisaMakanan <= 0 Then
            If ShowQuestion(Me, "Maaf, jumlah menu yang Anda pilih sudah habis atau tidak cukup untuk di order. Lanjutkan ?", True) = False Then
              Exit Sub
            End If
          End If
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
          .AddItem(vbTab & selItemUID & vbTab & "1" & vbTab & selItemName & vbTab & selItemPrice & vbTab & selItemPrice & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & selItemLevel & vbTab & selItemMeas)
          .Rows(.Rows.Count - 1).Height = 45
          .Row = .Rows.Count - 1
          Application.DoEvents()
          Call ShowPoleDisplay("1x" & Mid(selItemName, 1, 18) & vbNewLine & FormatNumber(selItemPrice.ToString, 0), False)
          'Call ShowPoleDisplay(FormatNumber(selItemPrice.ToString, 0), True)
        End If
      End With

      'Call FocusMove(BTNMoveDown, e)
      Call ReInitializePrice()

      If OrderDetail.Rows.Count > 1 Then
        BTNMakeBill.Enabled = True
        BTNMakeBill.VisualStyle = C1Input.VisualStyle.Office2007Blue
      End If
    End If

  End Sub

  Private Function ReInitializeDisc(ByVal ItemUID As String) As Double
    Dim TMPRecord As FbDataReader
    Dim Query As String
    Dim DiscCatRecord As FbDataReader
    Dim QueryDiscCat As String
    Dim DiscRecord As FbDataReader
    Dim DiscQuery As String
    Dim CUSTCATDISCUIDVALUE As String

    Query = "SELECT a.CUSTCATUID, " & _
                "(SELECT CUSTCATNAME FROM CUSTCAT WHERE CUSTCATUID = a.CUSTCATUID) AS CUSTCATNAME, " & _
                "(SELECT CUSTCATDISCUID FROM CUSTCAT WHERE CUSTCATUID = a.CUSTCATUID) AS CUSTCATDISCUID, " & _
                "(SELECT DISCNAME FROM DISC WHERE DISCUID = (SELECT CUSTCATDISCUID FROM CUSTCAT WHERE CUSTCATUID = a.CUSTCATUID)) AS DISCNAME, " & _
                "a.VATTYPEUID, a.CUSTUID, a.CUSTNO, a.CUSTNAME, a.CUSTADDR1, a.CUSTCITYPROVZIPCODE " & _
                "FROM CUST a WHERE CUSTUID LIKE '" & FindCust(TransactionNumber) & "'"
    TMPRecord = MyDatabase.MyReader(Query)
    TMPRecord.Read()
    CUSTCATDISCUIDVALUE = TMPRecord.Item("CUSTCATDISCUID")
    TMPRecord = Nothing

    QueryDiscCat = "SELECT a.DISCDTUID, a.DISCUID, a.DISCCATMENUUID, " & _
                "(SELECT INVENCATNAME FROM INVENCAT WHERE INVENCATUID = a.DISCCATMENUUID), " & _
                "a.DISCPERCENTAGE FROM DISCDT a " & _
                "WHERE DISCUID LIKE '" & CUSTCATDISCUIDVALUE & "'"
    DiscCatRecord = MyDatabase.MyReader(QueryDiscCat)
    DiscCatRecord.Read()

    DiscQuery = "SELECT COUNT(*)as TOTAL FROM INVEN a WHERE INVENUID LIKE '" & ItemUID & "' AND INVENCATUID LIKE '" & DiscCatRecord.Item("DISCCATMENUUID") & "'"
    DiscRecord = MyDatabase.MyReader(DiscQuery)
    DiscRecord.Read()

    If DiscRecord.Item("TOTAL") > 0 Then
      Return DiscCatRecord.Item("DISCPERCENTAGE")
    Else
      Return Nothing
    End If

  End Function

  Private Function FindCust(ByVal TransactionNo As String) As String
    Dim TMPRecord As FbDataReader
    Dim Result As String = Nothing
    TMPRecord = MyDatabase.MyReader("SELECT * FROM MBTRANS WHERE MBTRANSUID LIKE '" & TransactionNo & "'")
    While TMPRecord.Read()
      Result = TMPRecord.Item("MBTRANSCUSTUID")
    End While
    Return Result
    TMPRecord = Nothing
  End Function

  Private Function ItemPrice(ByVal ItemID As String) As String
    Dim TMPRecord As FbDataReader
    Dim Level As String = Nothing
    Dim CurrentPrice As Double

    TMPRecord = MyDatabase.MyReader("SELECT INVENUID, INVENDFTPRICELISTLVL FROM INVEN WHERE INVENUID LIKE '" & ItemID & "'")
    While TMPRecord.Read
      Level = TMPRecord.Item("INVENDFTPRICELISTLVL")
    End While

    If Level = Nothing Then Level = "1"

    TMPRecord.Close()
    TMPRecord = MyDatabase.MyReader("SELECT INVENUID,(SELECT (INVENPRICELISTLVL" & Level & ")as Price FROM INVENPRICELIST WHERE INVENUID LIKE '" & ItemID & "') FROM INVEN WHERE INVENUID LIKE '" & ItemID & "'")
    While TMPRecord.Read
      CurrentPrice = TMPRecord.Item("Price")
    End While
    If CurrentPrice = Nothing Then CurrentPrice = 0
    Return CurrentPrice

    TMPRecord = Nothing
  End Function

  Private Sub ReInitializePrice()

    Dim CurrentDisc As Double = 0
    Dim totalItem As Decimal = 0

    With OrderDetail
      If .Rows.Count > 1 Then
        Dim ReTotal As Double = 0
        For i As Integer = 1 To .Rows.Count - 1
          ReTotal = ReTotal + .Item(i, 5)
          totalItem = totalItem + .Item(i, 2)
        Next
        SubTotalTxt.Text = FormatNumber(ReTotal, 0)
        If InStr(totalItem.ToString, ",") > 0 Then
          lblTotalItem.Text = FormatNumber(totalItem, 2)
        Else
          lblTotalItem.Text = FormatNumber(totalItem, 0)
        End If
      Else
        SubTotalTxt.Text = "0"
        lblTotalItem.Text = "0"
      End If
    End With

  End Sub

  Private Sub QTYUpdate(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QTY01.Click, QTY02.Click, QTY03.Click, QTY04.Click, QTY05.Click, QTY06.Click, QTY07.Click, QTY08.Click, QTY09.Click, QTY10.Click
    With OrderDetail
      If .Rows.Count > 1 Then
        If PrefInfo.ShowQuantity = "1" Then
          Dim tmpSisaMakanan As String = getTotalQtyMenu(.Item(.Row, 1)).ToString
          If CInt(tmpSisaMakanan) < CInt(sender.text) Then
            If ShowQuestion(Me, "Maaf, jumlah menu yang Anda pilih sudah habis atau tidak cukup untuk di order. Lanjutkan ?", True) = False Then
              Exit Sub
            End If
          End If
        End If
        .Item(.Row, 2) = sender.text
        .Item(.Row, 5) = .Item(.Row, 2) * .Item(.Row, 4)
        'ShowPoleDisplay(Mid(.Item(.Row, 2) & "x" & .Item(.Row, 3), 1, 20) & vbNewLine & AddPrefixSpace("@" & .Item(.Row, 4)))
        Application.DoEvents()
        Call ShowPoleDisplay(Mid(.Item(.Row, 2) & "x" & .Item(.Row, 3), 1, 18) & vbNewLine & FormatNumber(.Item(.Row, 5), 0), False)
        'Call ShowPoleDisplay(FormatNumber(.Item(.Row, 5), 0), True)
      End If
    End With
    Call ReInitializePrice()
  End Sub

  Private Sub QTYPlusMinus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QTYPlus.Click, QTYMinus.Click
    With OrderDetail
      If .Rows.Count > 1 Then
        Select Case sender.name
          Case "QTYPlus"
            If PrefInfo.ShowQuantity = "1" Then
              Dim tmpSisaMakanan As String = getTotalQtyMenu(.Item(.Row, 1)).ToString
              If CInt(tmpSisaMakanan) < CInt(.Item(.Row, 2) + 1) Then
                If ShowQuestion(Me, "Maaf, jumlah menu yang Anda pilih sudah habis atau tidak cukup untuk di order. Lanjutkan ?", True) = False Then
                  Exit Sub
                End If
              End If
            End If
            .Item(.Row, 2) = .Item(.Row, 2) + 1
            .Item(.Row, 5) = .Item(.Row, 2) * .Item(.Row, 4)
            'ShowPoleDisplay(Mid(.Item(.Row, 2) & "x" & .Item(.Row, 3), 1, 20) & vbNewLine & AddPrefixSpace("@" & .Item(.Row, 4)))
            Application.DoEvents()
            Call ShowPoleDisplay(Mid(.Item(.Row, 2) & "x" & .Item(.Row, 3), 1, 18) & vbNewLine & FormatNumber(.Item(.Row, 5), 0), False)
            'Call ShowPoleDisplay(FormatNumber(.Item(.Row, 5), 0), True)
          Case "QTYMinus"
            If .Item(.Row, 2) > 1 Then
              If PrefInfo.ShowQuantity = "1" Then
                Dim tmpSisaMakanan As String = getTotalQtyMenu(.Item(.Row, 1)).ToString
                If CInt(tmpSisaMakanan) < CInt(.Item(.Row, 2) - 1) Then
                  If ShowQuestion(Me, "Maaf, jumlah menu yang Anda pilih sudah habis atau tidak cukup untuk di order. Lanjutkan ?", True) = False Then
                    Exit Sub
                  End If
                End If
              End If
              .Item(.Row, 2) = .Item(.Row, 2) - 1
              .Item(.Row, 5) = .Item(.Row, 2) * .Item(.Row, 4)
              'ShowPoleDisplay(Mid(.Item(.Row, 2) & "x" & .Item(.Row, 3), 1, 20) & vbNewLine & AddPrefixSpace("@" & .Item(.Row, 4)))
              Application.DoEvents()
              Call ShowPoleDisplay(Mid(.Item(.Row, 2) & "x" & .Item(.Row, 3), 1, 18) & vbNewLine & FormatNumber(.Item(.Row, 5), 0), False)
              'Call ShowPoleDisplay(FormatNumber(.Item(.Row, 5), 0), True)
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
      If PrefInfo.ShowQuantity = "1" Then
        Dim tmpSisaMakanan As String = getTotalQtyMenu(OrderDetail.Item(OrderDetail.Row, 1)).ToString
        If CInt(tmpSisaMakanan) < CInt(QtyTxt.Text) Then
          If ShowQuestion(Me, "Maaf, jumlah menu yang Anda pilih sudah habis atau tidak cukup untuk di order. Lanjutkan ?", True) = False Then
            Exit Sub
          End If
        End If
      End If
      OrderDetail.Item(OrderDetail.Row, 2) = QtyTxt.Text
      OrderDetail.Item(OrderDetail.Row, 5) = OrderDetail.Item(OrderDetail.Row, 2) * OrderDetail.Item(OrderDetail.Row, 4)
      'ShowPoleDisplay(Mid(OrderDetail.Item(OrderDetail.Row, 2) & "x" & OrderDetail.Item(OrderDetail.Row, 3), 1, 20) & vbNewLine & AddPrefixSpace("@" & OrderDetail.Item(OrderDetail.Row, 4)))
      Application.DoEvents()
      Call ShowPoleDisplay(Mid(OrderDetail.Item(OrderDetail.Row, 2) & "x" & OrderDetail.Item(OrderDetail.Row, 3), 1, 18) & vbNewLine & OrderDetail.Item(OrderDetail.Row, 5), False)
      '& vbNewLine & "@" & selItemPrice
      'Call ShowPoleDisplay(OrderDetail.Item(OrderDetail.Row, 5), True)
      Call ReInitializePrice()
    End If
  End Sub

  Private Sub CatBackNext(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackCategory.Click, NextCategory.Click
    Select Case sender.name
      Case "BackCategory"
        CatPosition = CatPosition - 8
      Case "NextCategory"
        CatPosition = CatPosition + 8
    End Select

    If 0 < CatPosition < CatCollection.Count Then
      Call CategoryList(CatPosition)

      If BackItem.Enabled = False Then
        BackItem.VisualStyle = C1Input.VisualStyle.Office2007Silver
      End If
      If NextItem.Enabled = False Then
        NextItem.VisualStyle = C1Input.VisualStyle.Office2007Silver
      End If
      If BackCategory.Enabled = False Then
        BackCategory.VisualStyle = C1Input.VisualStyle.Office2007Silver
      End If
      If NextCategory.Enabled = False Then
        NextCategory.VisualStyle = C1Input.VisualStyle.Office2007Silver
      End If
    End If

  End Sub

  Private Sub PMBackNext(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackItem.Click, NextItem.Click
    Select Case sender.name
      Case "BackItem"
        PMPosition = PMPosition - 16
      Case "NextItem"
        PMPosition = PMPosition + 16
    End Select

    If 0 < PMPosition < PMCollection.Count Then
      Call PMList(PMPosition)

      If BackItem.Enabled = False Then
        BackItem.VisualStyle = C1Input.VisualStyle.Office2007Silver
      End If
      If NextItem.Enabled = False Then
        NextItem.VisualStyle = C1Input.VisualStyle.Office2007Silver
      End If
      If BackCategory.Enabled = False Then
        BackCategory.VisualStyle = C1Input.VisualStyle.Office2007Silver
      End If
      If NextCategory.Enabled = False Then
        NextCategory.VisualStyle = C1Input.VisualStyle.Office2007Silver
      End If
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

    If Authorize = True Then
      Authorize = False
      UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, , UDeptUID)
      Call MainPage.StatusBarInitialize()
      Call CheckPermission(UserInformation.UserTypeUID, True)
    End If

    With OrderDetail
      If .Rows.Count > 1 Then
        If Len(Trim(.Item(.Row, 9))) > 0 Then ' Col=9 = MBTRANSDTUID item pernah tersimpan dalam database
          Dim TMPRecord As FbDataReader
          TMPRecord = MyDatabase.MyReader("SELECT A. MODIFIEDDATETIME AS MBTRANSMODIFIEDDATETIME, B.* FROM MBTRANS A, MBTRANSDT B WHERE A.MBTRANSUID=B.MBTRANSUID AND B.MBTRANSDTUID = '" & .Item(.Row, 9) & "'")
          If TMPRecord.Read() Then
            If Format(TMPRecord.Item("MBTRANSMODIFIEDDATETIME"), "dd.MM.yyyy, HH:mm:ss") <> oldModifiedTime Then
              ShowMessage(Me, "Maaf, anda tidak dapat menghapus order ini, karena ada user lain yang telah melakukan perubahan pada saat anda sedang mengedit data ini !")
              Me.Close()
              Exit Sub
            End If

            'Cek apakah sudah dimasak
            If TMPRecord.Item("MBTRANSDTITEMSTAT") > 0 Then
              ShowMessage(Me, "Maaf, order pesanan yang sudah diproses tidak dapat dibatalkan tanpa otorisasi manager !")
              Dim TMPRecordd As FbDataReader
              TMPRecordd = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2214'")
              While TMPRecordd.Read()
                UserPermition.PermitionInitialize(TMPRecordd.Item("USERCATCREATEACCESS"), TMPRecordd.Item("USERCATEDITACCESS"), TMPRecordd.Item("USERCATDELETEACCESS"), TMPRecordd.Item("USERCATREADACCESS"), TMPRecordd.Item("USERCATPRINTACCESS"), TMPRecordd.Item("USERCATCHANGEDATEACCESS"), TMPRecordd.Item("USERCATCHANGETIMEACCESS"), TMPRecordd.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
              End While

              With UserPermition
                If Not .DeleteOrderAccess Then
                  Dim OBJNew As New Form_User_Authorize_Dialog
                  OBJNew.Name = "Form_User_Authorize_Dialog"
                  OBJNew.ParentOBJForm = Me
                  OBJNew.NeedAuthorizationForMakeBill = False
                  OBJNew.ShowDialog()

                  If Authorize = False Then Exit Sub

                  Dim TMPRecordAuthorize As DataSet
                  TMPRecordAuthorize = MyDatabase.MyAdapter("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2214'")

                  If TMPRecordAuthorize.Tables(0).Rows.Count > 0 Then
                    UserPermition.PermitionInitialize(TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATCREATEACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATEDITACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATDELETEACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATREADACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATPRINTACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATCHANGEDATEACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATCHANGETIMEACCESS"), TMPRecordAuthorize.Tables(0).Rows(0).Item("USERCATMODIFIEDORDERAFTERDUMPED"))
                  End If

                  If Not .DeleteOrderAccess Then
                    Authorize = False
                    UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, , UDeptUID)
                    Call MainPage.StatusBarInitialize()
                    Call CheckPermission(UserInformation.UserTypeUID, True)
                    Exit Sub
                  End If

                End If

                If .DeleteOrderAccess Then

                  Dim OBJNew As New Dialog_Notes
                  OBJNew.Name = "Dialog_Notes"
                  OBJNew.ParentOBJForm = Me
                  OBJNew.ShowDialog()

                  If ItemNotes = Nothing Then
                    Authorize = False
                    UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, , UDeptUID)
                    Call MainPage.StatusBarInitialize()
                    Call CheckPermission(UserInformation.UserTypeUID, True)
                    Exit Sub
                  End If

                  Dim DeleteOrder As String = OrderDetail.Item(OrderDetail.Row, 3)
                  Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET DELETEDUSER='" & UserInformation.UserName & "',DELETEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSDTUID = '" & OrderDetail.Item(OrderDetail.Row, 9) & "'")
                  Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMCANCELLEDNOTE='" & ReplacePetik(ItemNotes) & "',MBTRANSDTITEMSTAT=-1 WHERE MBTRANSDTUID = '" & OrderDetail.Item(OrderDetail.Row, 9) & "'")

                  OrderDetail.Rows.Remove(OrderDetail.Row)
                  ReInitializePrice()

                  oldModifiedTime = Format(Now, "dd.MM.yyyy, HH:mm:ss")
                  Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MODIFIEDDATETIME = '" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSUID='" & TransactionUID & "'")

                  ShowMessage(Me, "Item " & DeleteOrder & " telah berhasil dihapus !")
                  If Authorize = True Then
                    Authorize = False
                    UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, , UDeptUID)
                    Call MainPage.StatusBarInitialize()
                    Call CheckPermission(UserInformation.UserTypeUID, True)
                  End If
                Else
                  FormStatus = FormStatusLib.OpenAndLock
                  Call OBJControlHandler(Me, FormStatus)
                End If
              End With

              Exit Sub
            End If
          Else
            ShowMessage(Me, "Maaf, anda tidak dapat menghapus order ini, karena ada user lain yang telah melakukan perubahan pada saat anda sedang mengedit data ini !")
            Me.Close()
            Exit Sub
          End If

          'Kalo belum dimasak, boleh dihapus
          If ShowQuestion(Me, "Hapus item " & .Item(.Row, 3) & " dari daftar ?") = True Then
            Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET DELETEDUSER='" & UserInformation.UserName & "',DELETEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSDTUID = '" & .Item(.Row, 9) & "'")
            'Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDTDETAIL WHERE MBTRANSDTUID = '" & .Item(.Row, 9) & "'")
            Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDT WHERE MBTRANSDTUID = '" & .Item(.Row, 9) & "'")

            .Rows.Remove(.Row)

            'If OrderDetail.Rows.Count = 1 Then
            '    Call ReInitializePrice()
            '    Exit Sub
            'End If

            'If Not IsNothing(OrderDetail.Item(.Row, 9)) Then
            '    UIDtoRemove.Add(OrderDetail.Item(.Row, 9))
            'End If
            Call ReInitializePrice()
            oldModifiedTime = Format(Now, "dd.MM.yyyy, HH:mm:ss")
            Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MODIFIEDDATETIME = '" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSUID='" & TransactionUID & "'")
          End If
        Else 'item tidak pernah tersimpan dalam database
          If ShowQuestion(Me, "Hapus item " & .Item(.Row, 3) & " dari daftar ?") = True Then

            .Rows.Remove(.Row)

            'If OrderDetail.Rows.Count = 1 Then
            '    Call ReInitializePrice()
            '    Exit Sub
            'End If

            'If Not IsNothing(OrderDetail.Item(.Row, 9)) Then
            '    UIDtoRemove.Add(OrderDetail.Item(.Row, 9))
            'End If
            Call ReInitializePrice()
          End If
        End If
      End If
    End With
  End Sub

  Private Sub BTNTakeAway_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNTakeAway.Click
    With OrderDetail
      If .Rows.Count > 1 Then
        .Item(.Row, 8) = Not .Item(.Row, 8)
      End If
    End With
  End Sub

  Private Sub SimpanDetailNewMB()
    Dim NEWOrderListCollection As New Collection
    With OrderDetail
      For i As Integer = 1 To .Rows.Count - 1
        Dim OrderList As New ArrayList
        For j As Integer = 1 To .Cols.Count - 1
          OrderList.Add(.Item(i, j))
        Next
        NEWOrderListCollection.Add(OrderList)
      Next
    End With
    Dim Query As String

    TransactionNo = AutoIDNumber("2202", "MBTRANS", "MBTRANSNO")
    TransactionNoLabel.Text = TransactionNo

    oldModifiedTime = Format(Now, "dd.MM.yyyy, HH:mm:ss")

    'Query = "INSERT INTO MBTRANS(MBTRANSUID,MBTRANSNO,MBTRANSDATE,MBTRANSDEPTUID, MBTRANSMODULETYPEID,MBTRANSSHIFTNO,MBTRANSPAXVAL,MBTRANSCUSTUID,MBTRANSCUSTNAME,MBTRANSTABLELISTUID,MBTRANSSERVICETYPEUID,MBTRANSRSVTRANSUID,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,ISBILLED,ISFISCAL) " & _
    '       "VALUES('" & TransactionUID & "','" & TransactionNo & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2202','" & Shift & "','" & VisitorLabel.Text & "','" & CustomerUID.Text & "','" & ReplacePetik(CustomerNameLabel.Text) & "'," & IIf(MainPage.InvoiceApplication = False, "'" & tableUID & "'", "NULL") & ",'" & ServiceUID.Text & "',NULL,'" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',0,0)"
    'Call MyDatabase.MyAdapter(Query)

    Dim nilaiDP As Double = 0
    If tmpRSV <> Nothing Then
      Call MyDatabase.MyAdapter("UPDATE RSVTRANS SET RSVTRANSSTAT = '1' WHERE RSVTRANSUID='" & tmpRSV & "'")
      Dim rs As FbDataReader
      rs = MyDatabase.MyReader("SELECT RSVTRANSDPVAL FROM RSVTRANS WHERE RSVTRANSUID='" & tmpRSV & "'")
      If rs.Read() = True Then
        nilaiDP = rs("RSVTRANSDPVAL")
      End If
      rs = Nothing
    End If

    'Query = "INSERT INTO MBTRANS(MBTRANSUID,MBTRANSNO,MBTRANSDATE,MBTRANSDEPTUID, MBTRANSMODULETYPEID,MBTRANSSHIFTNO,MBTRANSPAXVAL,MBTRANSCUSTUID,MBTRANSCUSTNAME,MBTRANSTABLELISTUID,MBTRANSSERVICETYPEUID,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,ISBILLED,ISFISCAL,MBTRANSRSVTRANSUID,MBTRANSDPVAL) " & _
    '       "VALUES('" & TransactionUID & "','" & TransactionNo & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2202','" & Shift & "','" & VisitorLabel.Text & "','" & CustomerUID.Text & "','" & ReplacePetik(CustomerNameLabel.Text) & "'," & IIf(MainPage.InvoiceApplication = False, "'" & tableUID & "'", "NULL") & ",'" & ServiceUID.Text & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',0,0," & IIf(tmpRSV = Nothing, "NULL", "'" & tmpRSV & "'") & ",'" & nilaiDP & "')"
    Query = "INSERT INTO MBTRANS(MBTRANSUID,MBTRANSNO,MBTRANSDATE,MBTRANSDEPTUID, MBTRANSMODULETYPEID,MBTRANSSHIFTNO,MBTRANSPAXVAL,MBTRANSCUSTUID,MBTRANSCUSTNAME,MBTRANSTABLELISTUID,MBTRANSSERVICETYPEUID,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,ISBILLED,ISFISCAL,MBTRANSRSVTRANSUID,MBTRANSDPVAL) " & _
           "VALUES('" & TransactionUID & "','" & TransactionNo & "','" & Format(CurrentDate.Value, "dd.MM.yyyy") & ", " & Format(Now, "HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2202','" & Shift & "','" & VisitorLabel.Text & "','" & CustomerUID.Text & "','" & ReplacePetik(CustomerNameLabel.Text) & "'," & IIf(MainPage.InvoiceApplication = False, "'" & tableUID & "'", "NULL") & ",'" & ServiceUID.Text & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',0,0," & IIf(tmpRSV = Nothing, "NULL", "'" & tmpRSV & "'") & ",'" & nilaiDP & "')"
    Call MyDatabase.MyAdapter(Query)

    'Insert New Detail
    'Item UID, QTY, Item, Price, Amount, TXTNotes, TA
    Dim ins As Integer
    For ins = 1 To NEWOrderListCollection.Count
      Dim DETAILUID As String = AutoUID()
      Dim ListArray As New ArrayList
      ListArray = NEWOrderListCollection(ins)

      Query = "INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT) " & _
              "VALUES('" & DETAILUID & "','" & TransactionUID & "','" & ListArray(0) & "','" & ReplacePetik(ListArray(2)) & "','" & ReplacePetik(ListArray(11)) & "','" & Replace(ListArray(1), ",", ".") & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ReplacePetik(ListArray(5)) & "','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1)"
      Call MyDatabase.MyAdapter(Query)

      'Anjo - 12 Okt 2011 : Detail paket tidak perlu diisikan karena otomatis via trigger
      'If CInt(ListArray(10)) = 3 Then
      '    Dim ItemDetail As FbDataReader
      '    ItemDetail = MyDatabase.MyReader("SELECT DT.*,I.INVENNAME  FROM INVENDT DT LEFT OUTER JOIN INVEN I ON DT.INVENDTITEMUID = I.INVENUID WHERE DT.INVENUID='" & ListArray(0) & "'")
      '    While ItemDetail.Read
      '        Query = "INSERT INTO MBTRANSDTDETAIL (MBTRANSDTDETAILUID,MBTRANSDTUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTITEMSTAT,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME) " & _
      '        "VALUES('" & AutoUID() & "','" & DETAILUID & "','" & ItemDetail("INVENDTITEMUID") & "','" & ItemDetail("INVENNAME") & "','" & ItemDetail("ITEMMEASUNITDESC") & "','" & ItemDetail("ITEMQTY") * ListArray(1) & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ListArray(5) & "','0','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "')"
      '        Call MyDatabase.MyAdapter(Query)
      '    End While
      'End If
    Next

  End Sub

  Private Sub SimpanDetailExistingMB(ByVal InputMBTransUID As String)

    'oldModifiedTime = Format(Now, "dd.MM.yyyy, HH:mm:ss")
    'Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MODIFIEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSUID='" & InputMBTransUID & "'")

    Call MyDatabase.MyAdapter("UPDATE RSVTRANS SET RSVTRANSSTAT = '0',MODIFIEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE RSVTRANSUID=(SELECT MBTRANSRSVTRANSUID FROM MBTRANS WHERE MBTRANSUID='" & InputMBTransUID & "')")
    Dim nilaiDP As Double = 0
    If tmpRSV <> Nothing Then
      Call MyDatabase.MyAdapter("UPDATE RSVTRANS SET RSVTRANSSTAT = '1' WHERE RSVTRANSUID='" & tmpRSV & "'")
      Dim rs As FbDataReader
      rs = MyDatabase.MyReader("SELECT RSVTRANSDPVAL FROM RSVTRANS WHERE RSVTRANSUID='" & tmpRSV & "'")
      If rs.Read() = True Then
        nilaiDP = rs("RSVTRANSDPVAL")
      End If
      rs = Nothing
    End If

    oldModifiedTime = Format(Now, "dd.MM.yyyy, HH:mm:ss")
    Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MBTRANSDATE='" & Format(CurrentDate.Value, "dd.MM.yyyy") & ", " & Format(Now, "HH:mm:ss") & "',MBTRANSDPVAL='" & nilaiDP & "',MODIFIEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',MBTRANSRSVTRANSUID=" & IIf(tmpRSV = Nothing, "NULL", "'" & tmpRSV & "'") & " WHERE MBTRANSUID='" & InputMBTransUID & "'")

    Dim NEWOrderListCollection As New Collection, NEWriceDetailCollection As New Collection
    With OrderDetail
      For i As Integer = 1 To .Rows.Count - 1
        Dim OrderList As New ArrayList
        For j As Integer = 1 To .Cols.Count - 1
          OrderList.Add(.Item(i, j))
        Next
        NEWOrderListCollection.Add(OrderList)
      Next
    End With

    Dim RecordItem As FbDataReader
    Dim CheckRecord As FbDataReader
    Dim Query As String
    Dim tmpID As String = Nothing
    For i As Integer = 1 To NEWOrderListCollection.Count
      RecordItem = MyDatabase.MyReader("SELECT COUNT (*) FROM MBTRANSDT WHERE MBTRANSUID = '" & InputMBTransUID & "' AND MBTRANSDTITEMNAME = '" & ReplacePetik(OrderDetail.Item(i, 3)) & "'")
      While RecordItem.Read
        If CInt(RecordItem.Item(0)) > 0 Then
          'Update Existing Detail
          Dim ListArray As New ArrayList
          ListArray = NEWOrderListCollection(i)

          Query = "UPDATE MBTRANSDT SET MBTRANSDTITEMUID='" & ListArray(0) & "',MBTRANSDTITEMMEASUNITDESC='" & ReplacePetik(ListArray(11)) & "',MBTRANSDTITEMQTY='" & ListArray(1) & "',MBTRANSDTITEMPRICE='" & ListArray(3) & "',MBTRANSDTSUBVAL='" & ListArray(3) * ListArray(1) & "',MBTRANSDTITEMNOTE='" & ReplacePetik(ListArray(5)) & "',MBTRANSDTISTAKEAWAY='" & IIf(ListArray(7) = True, 1, 0) & "',CREATEDUSER='" & UserInformation.UserName & "',MODIFIEDUSER='" & UserInformation.UserName & "',CREATEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',MODIFIEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',PRINT=1 WHERE MBTRANSDTITEMNAME = '" & ReplacePetik(OrderDetail.Item(i, 3)) & "' AND MBTRANSUID='" & InputMBTransUID & "'"
          Call MyDatabase.MyAdapter(Query)

          'Anjo 23 Okt : Ignore the following, detail paket done via trigger
          'If CInt(ListArray(10)) = 3 Then
          '    Dim mbTransDtDetail As FbDataReader
          '    mbTransDtDetail = MyDatabase.MyReader("SELECT * FROM MBTransDtDetail WHERE MBTransSELECT DT.*,I.INVENNAME  FROM INVENDT DT LEFT OUTER JOIN INVEN I ON DT.INVENDTITEMUID = I.INVENUID WHERE DT.INVENUID='" & ListArray(0) & "'")
          '    'ItemDetail = MyDatabase.MyReader("SELECT DT.*  FROM INVENDT DT WHERE DT.INVENUID='" & ListArray(0) & "'")

          '    While ItemDetail.Read
          '        Query = "UPDATE MBTRANSDTDETAIL SET MBTRANSDTITEMQTY='" & ItemDetail("ITEMQTY") * ListArray(1) & "',MBTRANSDTITEMPRICE='" & ListArray(3) & "',MBTRANSDTSUBVAL='" & ListArray(3) * ListArray(1) & "',MBTRANSDTITEMNOTE='" & ReplacePetik(ListArray(5)) & "',MBTRANSDTISTAKEAWAY='" & IIf(ListArray(7) = True, 1, 0) & "',CREATEDUSER='" & UserInformation.UserName & "',MODIFIEDUSER='" & UserInformation.UserName & "',CREATEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',MODIFIEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "' WHERE MBTRANSDTDETAILUID='" & ItemDetail("INVENDTITEMUID") & "'"
          '        Call MyDatabase.MyAdapter(Query)
          '    End While
          'End If
          tmpID += "'" & OrderDetail.Item(i, 1) & "'" & ","
          CheckRecord = Nothing
        Else
          ''Insert New Detail
          Dim DETAILUID As String = AutoUID()
          Dim ListArray As New ArrayList
          ListArray = NEWOrderListCollection(i)

          Query = "INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT) " & _
                  "VALUES('" & DETAILUID & "','" & TransactionUID & "','" & ListArray(0) & "','" & ReplacePetik(ListArray(2)) & "','" & ReplacePetik(ListArray(11)) & "','" & Replace(ListArray(1), ",", ".") & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ReplacePetik(ListArray(5)) & "','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1)"
          Call MyDatabase.MyAdapter(Query)

          'Anjo : 23 Okt : Ignore the following, detail paket done via trigger
          'If CInt(ListArray(10)) = 3 Then
          '    Dim ItemDetail As FbDataReader
          '    ItemDetail = MyDatabase.MyReader("SELECT DT.*,I.INVENNAME  FROM INVENDT DT LEFT OUTER JOIN INVEN I ON DT.INVENDTITEMUID = I.INVENUID WHERE DT.INVENUID='" & ListArray(0) & "'")
          '    'ItemDetail = MyDatabase.MyReader("SELECT DT.*,I.INVENNAME  FROM INVENDT DT, INVEN I WHERE DT.INVENUID=I.INVENUID AND DT.INVENUID='" & ListArray(0) & "'")

          '    While ItemDetail.Read
          '        Query = "INSERT INTO MBTRANSDTDETAIL (MBTRANSDTDETAILUID,MBTRANSDTUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTITEMSTAT,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME) " & _
          '        "VALUES('" & AutoUID() & "','" & DETAILUID & "','" & ItemDetail("INVENDTITEMUID") & "','" & ItemDetail("INVENNAME") & "','" & ItemDetail("ITEMMEASUNITDESC") & "','" & ItemDetail("ITEMQTY") * ListArray(1) & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ListArray(5) & "','0','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "')"
          '        Call MyDatabase.MyAdapter(Query)
          '    End While
          'End If
          tmpID += "'" & ListArray(0) & "'" & ","
        End If
      End While
      RecordItem = Nothing
    Next
    If tmpID <> Nothing Then
      tmpID = Strings.Left(tmpID, Len(tmpID) - 1)
      MyDatabase.MyAdapter("DELETE FROM MBTRANSDT WHERE MBTRANSUID='" & TransactionUID & "' AND MBTRANSDTITEMUID NOT IN (" & tmpID & ")")
    End If
  End Sub
  Private Sub DeleteItemMB(ByVal InputMBTransUID As String)
    Dim RecordItem As FbDataReader
    Dim ArrayItem() As String
    Dim Delete As String = Nothing
    Dim DTDelete As String = Nothing

    Const MY_DELIMITER = "~%^%$#$~"

    'Temukan Item Yang Ada Di DB Tapi Tidak Ada Di FlexGrid 
    RecordItem = MyDatabase.MyReader("SELECT * FROM MBTRANSDT WHERE MBTRANSUID = '" & InputMBTransUID & "'")
    While RecordItem.Read
      If ItemExistInGrid(RecordItem.Item("MBTRANSDTITEMNAME")) = False Then
        Delete = Delete & MY_DELIMITER & RecordItem.Item("MBTRANSDTITEMNAME")
        DTDelete = DTDelete & RecordItem.Item("MBTRANSDTUID")
      End If
    End While
    RecordItem = Nothing

    'Hapus Item Yang Ada Di DB Tapi Tidak Ada Di FlexGrid
    If Len(Trim(Delete)) > 0 Then
      ArrayItem = Split(Delete, MY_DELIMITER)
      For i As Integer = 0 To UBound(ArrayItem)
        If Len(Trim(CStr(ArrayItem(i)))) > 0 Then
          'ShowMessage(Me,"DELETE " & ArrayItem(i))
          'Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET DELETEDUSER='" & UserInformation.UserName & "',DELETEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSDTITEMNAME = '" & CStr(ArrayItem(i)) & "' AND MBTRANSUID = '" & InputMBTransUID & "'")
          'Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDTDETAIL WHERE MBTRANSDTUID = '" & DTDelete & "'")
          Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDT WHERE MBTRANSDTITEMNAME = '" & CStr(ArrayItem(i)) & "' AND MBTRANSUID = '" & InputMBTransUID & "'")
        End If
      Next
    End If
  End Sub
  Private Function ItemExistInGrid(ByVal InputMBTransUID As String) As Boolean

    Dim R As Boolean = False
    Dim i As Integer

    With OrderDetail
      For i = 1 To .Rows.Count - 1
        If Trim(.Item(i, 3)) = Trim(InputMBTransUID) Then R = True
      Next
    End With

    ItemExistInGrid = R

  End Function
  Private Sub LockFormInvoice()

    For Each OBJ As Object In Me.Controls
      If TypeOf OBJ Is GroupBox Then
        For Each CTR As Object In OBJ.Controls
          If TypeOf CTR Is C1Input.C1Button Then
            CTR.Enabled = False
            CTR.VisualStyle = C1Input.VisualStyle.Office2007Silver
          End If
        Next
      End If
    Next
    BTNNew.Enabled = True
    BTNNew.VisualStyle = C1Input.VisualStyle.Office2007Blue
    BTNClose.Enabled = True
    BTNClose.VisualStyle = C1Input.VisualStyle.Office2007Blue
    BTNInvoiceList.Enabled = True
    BTNInvoiceList.VisualStyle = C1Input.VisualStyle.Office2007Blue
    BTNPaymentInvoice.Enabled = True
    BTNPaymentInvoice.VisualStyle = C1Input.VisualStyle.Office2007Blue

  End Sub
#End Region

#Region "Form Control Function"

  Private Sub Form_Invoice_Image_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    If txtBarcode.Visible = False Then Exit Sub
    If Char.IsLetterOrDigit(e.KeyChar) Then
      e.Handled = True
      txtBarcode.Text = e.KeyChar
      txtBarcode.Focus()
    Else
      e.Handled = False
    End If
  End Sub

  Private Sub Form_Invoice_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Me.Load

    If PrefInfo.UseBarcode = "0" Then OrderDetail.Height = 429 : txtBarcode.Visible = False Else OrderDetail.Height = 393 : txtBarcode.Visible = True
    Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 45)

    Me.Cursor = Cursors.Default
    Call ReadDefaultCustomer()
    Call ReadDefaultService()

    Call BasicInitialize()
    OrderDetail.Styles("Normal").WordWrap = True

  End Sub

  Private Sub ReadDefaultService()
    Dim tmpImage As String = Nothing
    If tableUID <> Nothing Then
      Dim rs As FbDataReader
      rs = MyDatabase.MyReader("SELECT IMAGE FROM TABLELIST WHERE TABLELISTUID='" & tableUID & "'")
      If rs.Read = True Then
        If IsDBNull(rs("IMAGE")) = True Then
          tmpImage = "0"
        Else
          Dim rs2 As FbDataReader
          tmpImage = rs("IMAGE")
          If tmpImage = "5" Or tmpImage = "6" Then
            'rs2 = MyDatabase.MyReader("SELECT * FROM SERVICETYPE WHERE SERVICETYPEACTV IS NULL AND (SERVICETYPEDEFAULT = 2 OR SERVICETYPEACTV = 0) AND SERVICETYPEDEFAULT = 2 ORDER BY SERVICETYPENAME")
            rs2 = MyDatabase.MyReader("SELECT * FROM SERVICETYPE WHERE SERVICETYPEACTV='0' AND SERVICETYPEDEFAULT = '2' ORDER BY SERVICETYPENAME")
          Else
            'rs2 = MyDatabase.MyReader("SELECT * FROM SERVICETYPE WHERE SERVICETYPEACTV IS NULL AND (SERVICETYPEDEFAULT = 3 OR SERVICETYPEACTV = 0) AND SERVICETYPEDEFAULT = 3 ORDER BY SERVICETYPENAME")
            rs2 = MyDatabase.MyReader("SELECT * FROM SERVICETYPE WHERE SERVICETYPEACTV='0' AND SERVICETYPEDEFAULT = '3' ORDER BY SERVICETYPENAME")
          End If
          If rs2.Read = True Then
            defaultServiceUID = rs2("SERVICETYPEUID")
            defaultServiceName = rs2("SERVICETYPENAME")
            Exit Sub
          End If
          rs2 = Nothing
        End If
      End If
      rs = Nothing
    End If
    Dim TMPRecordDefault As FbDataReader
    Try
      If pubIDCustomer = Nothing Then
        TMPRecordDefault = MyDatabase.MyReader("SELECT * FROM SERVICETYPE WHERE SERVICETYPEACTV='0' AND SERVICETYPEDEFAULT = 1 OR SERVICETYPEACTV = 0 AND SERVICETYPEDEFAULT = 1 ORDER BY SERVICETYPENAME")
      Else
        TMPRecordDefault = MyDatabase.MyReader("SELECT * FROM SERVICETYPE WHERE SERVICETYPEACTV='0' AND SERVICETYPEDEFAULT = 3 ORDER BY SERVICETYPENAME")
      End If
      TMPRecordDefault.Read()

      defaultServiceUID = TMPRecordDefault.Item("SERVICETYPEUID")
      defaultServiceName = TMPRecordDefault.Item("SERVICETYPENAME")
      TMPRecordDefault = Nothing
    Catch ex As Exception
    End Try

  End Sub

  Private Sub ReadDefaultCustomer()
    Dim TMPRecord As FbDataReader
    If Trim(pubIDCustomer) <> "" Then
      'defaultCustUID = pubIDCustomer
      'defaultCustName = pubNamaCustomer
      TMPRecord = MyDatabase.MyReader("SELECT FIRST 1 * FROM CUST  WHERE CUSTUID='" & ReplacePetik(pubIDCustomer) & "' ORDER BY CUSTNAME ASC")
    Else
      TMPRecord = MyDatabase.MyReader("SELECT FIRST 1 * FROM CUST  WHERE CUSTISDFT='1' ORDER BY CUSTNAME ASC")
    End If
    Try
      While TMPRecord.Read()
        defaultCustUID = TMPRecord.Item("CUSTUID")
        defaultCustName = TMPRecord.Item("CUSTNAME")
        CustomerNameLabel.Text = CustomLabel.Text
      End While
      TMPRecord = Nothing
    Catch ex As Exception
    End Try
  End Sub

  Private Sub BTNInvoiceList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNInvoiceList.Click
    Me.Cursor = Cursors.WaitCursor
    Dim OBJNew As New Form_Invoice_List
    OBJNew.Name = "Form_Invoice_List"

    OBJNew.ParentOBJForm = Me
    OBJNew.ShowDialog()

    If EditStatus = True Then
      Call ShowPoleDisplay(PrefInfo.Header, False)
      TransactionUID = OBJNew.TableList.Item(OBJNew.TableList.Row, 0)
      Call GetDTOrder(TransactionUID)

      OrderDetail.Rows.Count = 1
      Call ReinitializeOrderList()

      TransactionNo = OBJNew.TableList.Item(OBJNew.TableList.Row, 1)
      TransactionNoLabel.Text = OBJNew.TableList.Item(OBJNew.TableList.Row, 1)
      CustomerNameLabel.Text = OBJNew.TableList.Item(OBJNew.TableList.Row, 3)

      Dim TMPRecord As FbDataReader

      TMPRecord = MyDatabase.MyReader("SELECT * FROM MBTRANS MB LEFT OUTER JOIN CUST C ON MB.MBTRANSCUSTUID=C.CUSTUID LEFT OUTER JOIN SERVICETYPE S ON MB.MBTRANSSERVICETYPEUID=S.SERVICETYPEUID WHERE MB.MBTRANSUID='" & TransactionUID & "'")
      TMPRecord.Read()

      oldModifiedTime = Format(TMPRecord.Item("MODIFIEDDATETIME"), "dd.MM.yyyy, HH:mm:ss")
      CustomerUID.Text = TMPRecord.Item("CUSTUID")
      CustomLabel.Text = TMPRecord.Item("CUSTNAME")
      CustomerNameLabel.Text = CustomLabel.Text
      DateLabel.Text = Format(TMPRecord.Item("MBTRANSDATE"), "dd MMMM yyyy")
      CurrentDate.Value = TMPRecord.Item("MBTRANSDATE")
      If IsDBNull(TMPRecord.Item("MBTRANSRSVTRANSUID")) = False Then tmpRSV = TMPRecord.Item("MBTRANSRSVTRANSUID") Else tmpRSV = Nothing
      CustomerUID.Text = TMPRecord.Item("MBTRANSCUSTUID")
      CustomLabel.Text = TMPRecord.Item("CUSTNAME")
      CustomerNameLabel.Text = TMPRecord.Item("MBTRANSCUSTNAME")

      ServiceUID.Text = TMPRecord.Item("MBTRANSSERVICETYPEUID")
      ServiceLabel.Text = TMPRecord.Item("SERVICETYPENAME")

      VisitorLabel.Text = TMPRecord.Item("MBTRANSPAXVAL")

      If OrderDetail.Rows.Count > 1 Then LockFormInvoice()

      Select Case CInt(TMPRecord.Item("MBTRANSSTAT"))
        Case 0 'Not Billed
          Call CheckPermission(UserInformation.UserTypeUID, True)
          OrderDetail.Enabled = True
          BTNMakeBill.Enabled = True : BTNMakeBill.VisualStyle = C1Input.VisualStyle.Office2007Blue
          BTNPaymentInvoice.Enabled = False : BTNPaymentInvoice.VisualStyle = C1Input.VisualStyle.Office2007Silver
          Me.Cursor = Cursors.Default
        Case 1 'Billed
          Call CheckPermission(UserInformation.UserTypeUID, True)
          OrderDetail.Enabled = False
          BTNMakeBill.Enabled = True : BTNMakeBill.VisualStyle = C1Input.VisualStyle.Office2007Blue
          BTNPaymentInvoice.Enabled = True : BTNPaymentInvoice.VisualStyle = C1Input.VisualStyle.Office2007Blue
          BTNNotes.Enabled = False : BTNNotes.VisualStyle = C1Input.VisualStyle.Office2007Silver
          BTNTakeAway.Enabled = False : BTNTakeAway.VisualStyle = C1Input.VisualStyle.Office2007Silver
          BTNReset.Enabled = False : BTNReset.VisualStyle = C1Input.VisualStyle.Office2007Silver
          BTNRemove.Enabled = False : BTNRemove.VisualStyle = C1Input.VisualStyle.Office2007Silver
          Me.Cursor = Cursors.Default
        Case 2 'Paid
          Call CheckPermission(UserInformation.UserTypeUID, True)
          OrderDetail.Enabled = False
          BTNMakeBill.Enabled = False : BTNMakeBill.VisualStyle = C1Input.VisualStyle.Office2007Silver
          BTNPaymentInvoice.Enabled = False : BTNPaymentInvoice.VisualStyle = C1Input.VisualStyle.Office2007Silver
          BTNNotes.Enabled = False : BTNNotes.VisualStyle = C1Input.VisualStyle.Office2007Silver
          BTNTakeAway.Enabled = False : BTNTakeAway.VisualStyle = C1Input.VisualStyle.Office2007Silver
          BTNReset.Enabled = False : BTNReset.VisualStyle = C1Input.VisualStyle.Office2007Silver
          BTNRemove.Enabled = False : BTNRemove.VisualStyle = C1Input.VisualStyle.Office2007Silver
          Me.Cursor = Cursors.Default
      End Select
      TMPRecord = Nothing
      Me.Cursor = Cursors.Default
    Else
      Me.Cursor = Cursors.Default
      Exit Sub
    End If

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
        .Item(.Row, 7) = Not ItemNotes = Nothing
      End If
    End With
  End Sub

  Private Sub BTNReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNReset.Click

    'Anjo 14 Okt 2011
    'Reset disini tidak diimplement karena rawan sekali, dimana apabila existing order direset
    'maka old item tidak dihapus, karena fungsi deleteitemmb telah di-comment

    Exit Sub

    If Authorize = True Then
      Authorize = False
      UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, , UDeptUID)
      Call MainPage.StatusBarInitialize()
      Call CheckPermission(UserInformation.UserTypeUID, True)
    End If

    If ShowQuestion(Me, "Hapus semua item ?") = True Then
      For i As Integer = 1 To OrderDetail.Rows.Count - 1
        If Not IsNothing(OrderDetail.Item(i, 9)) Then
          UIDtoRemove.Add(OrderDetail.Item(i, 9))
        End If
      Next

      OrderDetail.Rows.Count = 1
      Call ReInitializePrice()
    End If
  End Sub

  Private Sub BTNMakeBill_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMakeBill.Click
    With UserPermition
      If EditStatus = False Then
        If .CreateAccess = False Then
          ShowMessage(Me, "Maaf, Anda tidak berhak menyimpan data ini !", True)
          Exit Sub
        End If
      Else
        If .EditAccess = False Then
          ShowMessage(Me, "Maaf, Anda tidak berhak menyimpan data ini !", True)
          Exit Sub
        End If
      End If
    End With
    Me.Cursor = Cursors.WaitCursor
    If Authorize = True Then
      Authorize = False
      UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, , UDeptUID)
      Call MainPage.StatusBarInitialize()
    End If

    If Len(Trim(CustomerUID.Text)) = 0 Then
      Me.Cursor = Cursors.Default
      ShowMessage(Me, "Maaf, silakan pilih nama customer terlebih dahulu !")
      Exit Sub
    End If
    If Len(Trim(ServiceUID.Text)) = 0 Then
      Me.Cursor = Cursors.Default
      ShowMessage(Me, "Maaf, silakan pilih nama service terlebih dahulu !")
      Exit Sub
    End If
    If OrderDetail.Rows.Count > 1 Then
      'Andy - the following is absolutely junk '30 sept 2011
      'Dim NEWOrderListCollection As New Collection, NEWPriceDetailCollection As New Collection
      'With OrderDetail
      '    For i As Integer = 1 To .Rows.Count - 1
      '        Dim OrderList As New ArrayList
      '        For j As Integer = 1 To .Cols.Count - 1
      '            OrderList.Add(.Item(i, j))
      '        Next
      '        NEWOrderListCollection.Add(OrderList)
      '    Next
      'End With

      Dim ItemRecord As FbDataReader
      Dim CountRecord As FbDataReader

      CountRecord = MyDatabase.MyReader("SELECT COUNT (*) FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "'")
      While CountRecord.Read
        If CInt(CountRecord.Item(0)) = 0 Then
          'susilo, 7 Nov 2012. cek apakah masa trial masih aktif
          If totalRow("MBTRANS") >= CInt(getRealVal("—˜›‡…")) And pubIsDemo = True Then
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Maaf, data ini tidak dapat disimpan karena versi demo telah habis !", True)
            Exit Sub
          End If
          Call SimpanDetailNewMB()
        Else
          'Anjo - 14 Okt 2011 : DeleteItemMB dicomment, karena proses remove old item yang tidak ada di grid
          'sudah dilakukan oleh button remove
          'DeleteItemMB(TransactionUID)
          'Anjo - 14Okt 2011 : Check dulu modified time, in case 2 user bersamaan mengedit data
          ItemRecord = MyDatabase.MyReader("SELECT MODIFIEDDATETIME FROM MBTRANS WHERE MBTRANSUID='" & TransactionUID & "'")
          Call ItemRecord.Read()
          If Format(ItemRecord.Item("MODIFIEDDATETIME"), "dd.MM.yyyy, HH:mm:ss") <> oldModifiedTime Then
            ShowMessage(Me, "Maaf, anda tidak dapat menyimpan order ini, karena ada user lain yang telah melakukan perubahan pada saat anda sedang mengedit data ini !")
            Me.Close()
            Exit Sub
          Else
            Call SimpanDetailExistingMB(TransactionUID)
          End If
        End If
      End While
      CountRecord = Nothing
      ItemRecord = Nothing
    Else
      Me.Cursor = Cursors.Default
      ShowMessage(Me, "Maaf, tidak ada order pesanan dalam daftar, silakan masukan order pesanan !")
      Exit Sub
    End If

    'Call Form Make Bill
    Me.Cursor = Cursors.WaitCursor
    Dim OBJNew As New Form_Invoice_Make_Bill
    OBJNew.Name = "Form_Invoice_Make_Bill"
    OBJNew.TransactionUID = TransactionUID
    OBJNew.BillNo.Text = TransactionNoLabel.Text
    OBJNew.CustName.Text = CustomerNameLabel.Text
    OBJNew.ParentOBJForm = Me
    OBJNew.ShowDialog()

    If OBJNew.SaveStatus = True Then
      LockFormInvoice()
      OrderDetail.Enabled = False

      'Ardian - Invoice Payment
      'Dim PaymentNo As String = AutoIDNumber("2206", "PBTRANS", "PBTRANSNO")
      'Dim GrandTotal As Double = CDbl(OBJNew.TotalTxt.Text)

      'If EditStatus = True Then
      'Removed By Rudy
      '    If BillStatus = True Then
      '        Call MyDatabase.MyAdapter("DELETE FROM PBTRANS WHERE PBTRANSMBTRANSUID='" & TransactionUID & "'")
      '        Call MyDatabase.MyAdapter("INSERT INTO PBTRANS (PBTRANSUID, PBTRANSNO,PBTRANSSTAT,PBTRANSDATE, PBTRANSDEPTUID, PBTRANSMODULETYPEID, PBTRANSSHIFTNO, PBTRANSMBTRANSUID, PBTRANSCUSTUID, PBTRANSCUSTNAME, PBTRANSTABLELISTUID, PBTRANSTOTVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME,ISFISCAL) " & _
      '           "VALUES ('" & AutoUID() & "','" & PaymentNo & "','2','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2206','" & Shift & "','" & TransactionUID & "','" & CustomerUID.Text & "','" & CustomerNameLabel.Text & "',NULL,'" & GrandTotal & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','0')")
      '    Else
      '        Call MyDatabase.MyAdapter("UPDATE PBTRANS SET PBTRANSDATE ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "', PBTRANSTOTVAL ='" & GrandTotal & "', MODIFIEDUSER ='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSMBTRANSUID ='" & TransactionUID & "'")
      '    End If
      '    Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MBTRANSSTAT = '1' WHERE MBTRANSUID ='" & TransactionUID & "'")
      'Else
      'Call MyDatabase.MyAdapter("INSERT INTO PBTRANS (PBTRANSUID, PBTRANSNO,PBTRANSSTAT,PBTRANSDATE, PBTRANSDEPTUID, PBTRANSMODULETYPEID, PBTRANSSHIFTNO, PBTRANSMBTRANSUID, PBTRANSCUSTUID, PBTRANSCUSTNAME, PBTRANSTABLELISTUID, PBTRANSTOTVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME,ISFISCAL) " & _
      '        "VALUES ('" & AutoUID() & "','" & PaymentNo & "','2','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2206','" & Shift & "','" & TransactionUID & "','" & CustomerUID.Text & "','" & CustomerNameLabel.Text & "',NULL,'" & GrandTotal & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','0')")
      'Changed By Rudy From MBTransStat = 2 To Be 1
      'Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MBTRANSSTAT = '1' WHERE MBTRANSUID ='" & TransactionUID & "'")
      'End If

      BTNPaymentInvoice.Enabled = True
      BTNPaymentInvoice.VisualStyle = C1Input.VisualStyle.Office2007Blue
      CustomerNameLabel.Text = OBJNew.CustName.Text
    Else
      Dim myDataSet As DataSet
      myDataSet = MyDatabase.MyAdapter("SELECT * FROM MBTRANS WHERE MBTRANSUID='" & TransactionUID & "'")
      If myDataSet.Tables(0).Rows.Count > 0 Then
        If myDataSet.Tables(0).Rows(0).Item("ISBILLED") = "0" And myDataSet.Tables(0).Rows(0).Item("MBTRANSSTAT") = "0" Then

          Call GetDTOrder(TransactionUID)

          OrderDetail.Rows.Count = 1
          Call ReinitializeOrderList()

          Call CheckPermission(UserInformation.UserTypeUID, True)
          OrderDetail.Enabled = True
          BTNMakeBill.Enabled = True : BTNMakeBill.VisualStyle = C1Input.VisualStyle.Office2007Blue
        End If
      End If
      BTNPaymentInvoice.Enabled = False
      BTNPaymentInvoice.VisualStyle = C1Input.VisualStyle.Office2007Silver
    End If

    BTNNew.Enabled = True
    BTNNew.VisualStyle = C1Input.VisualStyle.Office2007Blue

    Me.Cursor = Cursors.Default
  End Sub

  Private Sub BTNClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClose.Click

    If Authorize = True Then
      Authorize = False
      UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, , UDeptUID)
      Call MainPage.StatusBarInitialize()
      Call CheckPermission(UserInformation.UserTypeUID, True)
    End If

    'If UserPermition.DeleteAccess = False Then
    '    If OrderDetail.Enabled = True Then
    '        If CDec(lblTotalItem.Text) <> 0 Then
    '            ShowMessage(Me, "Maaf, anda tidak dapat keluar dari transaksi ini, karena ada transaksi yang belum disimpan !")
    '            Exit Sub
    '        End If
    '    End If
    'End If


    'If EditStatus = True Then
    '    Me.Close()
    'Else
    '    If OrderDetail.Rows.Count > 1 Then
    '        If ShowQuestion(Me, "This Invoice '" & TransactionNoLabel.Text & "' has the list of ordered item. Are you sure, you want to cancel this invoice ?") = True Then
    '            With OrderDetail
    '                For i As Integer = 1 To .Rows.Count - 1
    '                    Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET DELETEDUSER='" & UserInformation.UserName & "' WHERE MBTRANSDTUID = '" & .Item(.Row, 9) & "'")
    '                    Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDTDETAIL WHERE MBTRANSDTUID = '" & .Item(.Row, 9) & "'")
    '                    Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "'")
    '                    Call MyDatabase.MyAdapter("DELETE FROM MBTRANS WHERE MBTRANSUID = '" & TransactionUID & "'")
    '                Next
    '            End With
    '            Me.Close()
    '        End If
    '    Else
    '        Me.Close()
    '    End If
    'End If
    tmpRSV = Nothing
    Call ShowPoleDisplay(PrefInfo.Header, False)
    Me.Close()
  End Sub

  Private Sub OrderDetail_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles OrderDetail.MouseDown
    If OrderDetail.Rows.Count > 1 Then

      Dim NewStyle As CellStyle
      NewStyle = OrderDetail.Styles.Add("Click")
      NewStyle.BackColor = Color.LightCoral

      Dim Style As CellStyle
      Style = OrderDetail.Styles.Add("Disable")
      Style.BackColor = Color.Silver

      For i As Integer = 0 To OrderDetail.Rows.Count - 1
        'OrderDetail.Item(i, 0) = False
        OrderDetail.Rows(i).Style = Nothing
        If OrderDetail.Item(i, 10) = "1" Then
          OrderDetail.Rows(i).Style = OrderDetail.Styles("Disable")
        End If
      Next

      'OrderDetail.Item(OrderDetail.Row, 0) = True
      OrderDetail.Rows(OrderDetail.Row).Style = OrderDetail.Styles("Click")

      If OrderDetail.Item(OrderDetail.Row, 10) = "1" Then
        OrderDetail.Rows(OrderDetail.Row).Style = OrderDetail.Styles("Disable")
        Call LockFormInvoice()

        BTNMoveUp.Enabled = True
        BTNMoveUp.VisualStyle = C1Input.VisualStyle.Office2007Blue
        BTNMoveDown.Enabled = True
        BTNMoveDown.VisualStyle = C1Input.VisualStyle.Office2007Blue
        BTNMakeBill.Enabled = True
        BTNMakeBill.VisualStyle = C1Input.VisualStyle.Office2007Blue
        BTNEdit.Enabled = True
        BTNEdit.VisualStyle = C1Input.VisualStyle.Office2007Blue
        If UserPermition.DeleteAccess = True Then
          BTNRemove.Enabled = True
          BTNRemove.VisualStyle = C1Input.VisualStyle.Office2007Blue
        Else
          BTNRemove.Enabled = False
          BTNRemove.VisualStyle = C1Input.VisualStyle.Office2007Silver
        End If
      Else
        If BackItem.Enabled = False And NextItem.Enabled = False And BackCategory.Enabled = False And NextCategory.Enabled = False Then
          For Each OBJ As Object In Me.Controls
            If TypeOf OBJ Is GroupBox Then
              For Each CTR As Object In OBJ.Controls
                If TypeOf CTR Is C1Input.C1Button Then
                  If LCase(Trim(CTR.text)) = "payment" Then
                    'do nothing
                  Else
                    If CTR.Text = "-" Then
                      CTR.Enabled = True
                      CTR.VisualStyle = C1Input.VisualStyle.Office2007Blue
                    Else
                      CTR.Enabled = True
                      CTR.VisualStyle = C1Input.VisualStyle.Office2007Blue
                    End If
                  End If
                End If
              Next
            End If
          Next

          Call CategoryList(CatPosition)
          Call PMList(PMPosition)

          If UserPermition.DeleteAccess = False Then
            BTNRemove.Enabled = False
            BTNRemove.VisualStyle = C1Input.VisualStyle.Office2007Silver
            BTNReset.Enabled = False
            BTNReset.VisualStyle = C1Input.VisualStyle.Office2007Silver
          End If

          BTNNew.Enabled = True
          BTNNew.VisualStyle = C1Input.VisualStyle.Office2007Blue

          If BackItem.Enabled = False Then
            BackItem.VisualStyle = C1Input.VisualStyle.Office2007Silver
          End If
          If NextItem.Enabled = False Then
            NextItem.VisualStyle = C1Input.VisualStyle.Office2007Silver
          End If
          If BackCategory.Enabled = False Then
            BackCategory.VisualStyle = C1Input.VisualStyle.Office2007Silver
          End If
          If NextCategory.Enabled = False Then
            NextCategory.VisualStyle = C1Input.VisualStyle.Office2007Silver
          End If
        End If
      End If
    End If
  End Sub

  Private Sub BTNEdit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNEdit.Click

    Me.Cursor = Cursors.WaitCursor
    Dim OBJNew As New Form_Invoice_Check_In
    OBJNew.Name = "Form_Invoice_Check_In"

    If UserPermition.ChangeDateAccess = True Then
      OBJNew.publicAllowChangeDate = True
    Else
      OBJNew.publicAllowChangeDate = False
    End If

    OBJNew.pubRSVUID = tmpRSV
    OBJNew.TransactionNo.Text = TransactionNoLabel.Text
    OBJNew.DateLabel.Text = DateLabel.Text
    'OBJNew.CustomerList.Text = CustomLabel.Text
    OBJNew.CustName.Text = CustomerNameLabel.Text

    OBJNew.ServiceList.Text = ServiceLabel.Text
    OBJNew.TotalVisitor.Text = VisitorLabel.Text

    OBJNew.ParentOBJForm = Me
    OBJNew.selectedCustUID = CustomerUID.Text
    OBJNew.ShowDialog()

    If OBJNew.OKStatus = True Then
      DateLabel.Text = OBJNew.DateLabel.Text
      CurrentDate.Value = CDate(DateLabel.Text)
      CustomerUID.Text = OBJNew.CustomerList.Columns(1).Text
      CustomLabel.Text = OBJNew.CustomerList.Text
      CustomerNameLabel.Text = OBJNew.CustName.Text

      ServiceUID.Text = OBJNew.ServiceList.Columns(1).Text
      ServiceLabel.Text = OBJNew.ServiceList.Text
      VisitorLabel.Text = OBJNew.TotalVisitor.Text
      If tmpRSV <> OBJNew.ReservationList.Columns(1).Text Then
        tmpRSV = OBJNew.ReservationList.Columns(1).Text
        If OBJNew.BTNCancel.Enabled = False Then
          Call GetDTOrder(TransactionUID)
          OrderDetail.Rows.Count = 1
        Else
          Call GetDTOrderRSV(OBJNew.ReservationList.Columns(1).Text)
        End If
        Call ReinitializeOrderList()
      End If
      BTNMakeBill.Enabled = True : BTNMakeBill.VisualStyle = C1Input.VisualStyle.Office2007Blue
    End If

    Me.Cursor = Cursors.Default
  End Sub

  Private Function isAdaYangDimasak(ByVal idMBTrans As String) As Boolean
    If PrefInfo.UseKitchenPrintOut = "0" Then Return False
    Dim rs As FbDataReader
    rs = MyDatabase.MyReader("SELECT COUNT(*) FROM MBTRANSDT WHERE MBTRANSUID='" & idMBTrans & "' AND MBTRANSDTITEMSTAT>'0'")
    If rs.Read = True Then
      If IsDBNull(rs(0)) = True Then Return False
      If CDec(rs(0)) > 0 Then
        Return True
      Else
        Return False
      End If
    Else
      Return False
    End If
    rs = Nothing
  End Function

  Public Sub GetDTOrderRSV(ByVal MBUID As String)
    tmpRSV = MBUID
    OrderListCollection.Clear()
    With OrderListCollection
      Dim ItemRecord As FbDataReader
      ItemRecord = MyDatabase.MyReader("SELECT A.*, B.INVENLEVEL FROM RSVTRANSDT A INNER JOIN INVEN B ON A.RSVTRANSDTITEMUID=B.INVENUID  WHERE A.RSVTRANSUID = '" & MBUID & "'")
      While ItemRecord.Read
        Dim ListArray As New ArrayList
        ListArray.Add(ItemRecord.Item("RSVTRANSDTITEMUID"))
        ListArray.Add(ItemRecord.Item("RSVTRANSDTITEMQTY"))
        ListArray.Add(ItemRecord.Item("RSVTRANSDTITEMNAME"))
        ListArray.Add(ItemRecord.Item("RSVTRANSDTITEMPRICE"))
        ListArray.Add(ItemRecord.Item("RSVTRANSDTSUBVAL"))
        ListArray.Add(ItemRecord.Item("RSVTRANSDTITEMNOTE"))
        ListArray.Add(IIf(ItemRecord.Item("RSVTRANSDTITEMNOTE") = Nothing, False, True))
        ListArray.Add(IIf(ItemRecord.Item("RSVTRANSDTISTAKEAWAY") = 0, False, True))
        ListArray.Add("")
        ListArray.Add("0")
        ListArray.Add(ItemRecord.Item("INVENLEVEL"))
        ListArray.Add(ItemRecord.Item("RSVTRANSDTITEMMEASUNITDESC"))
        OrderListCollection.Add(ListArray)
      End While
    End With
  End Sub

  Private Sub BTNNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNNew.Click

    If Authorize = True Then
      Authorize = False
      UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, , UDeptUID)
      Call MainPage.StatusBarInitialize()
      Call CheckPermission(UserInformation.UserTypeUID, True)
    End If

    'If UserPermition.DeleteAccess = False Then
    '    If OrderDetail.Enabled = True Then
    '        If CDec(lblTotalItem.Text) <> 0 Then
    '            ShowMessage(Me, "Maaf, anda tidak dapat membuat transaksi baru, karena ada transaksi yang belum disimpan !")
    '            Exit Sub
    '        End If
    '    End If
    'End If

    Me.Cursor = Cursors.WaitCursor

    EditStatus = False
    tmpRSV = Nothing
    TransactionUID = AutoUID()
    OrderDetail.Rows.Count = 1
    OrderDetail.Enabled = True

    Call BasicInitialize()

    BTNNew.Enabled = True
    BTNNew.VisualStyle = C1Input.VisualStyle.Office2007Blue
    BTNEdit.Enabled = True
    BTNEdit.VisualStyle = C1Input.VisualStyle.Office2007Blue

    If OrderDetail.Rows.Count > 1 Then
      'For i As Integer = 1 To OrderDetail.Rows.Count - 1
      '    If Not IsNothing(OrderDetail.Item(i, 9)) Then
      '        UIDtoRemove.Add(OrderDetail.Item(i, 9))
      '    End If
      'Next

      OrderDetail.Rows.Count = 1
      OrderDetail.Enabled = True
      Call ReInitializePrice()
    End If

    oldModifiedTime = ""

    Me.Cursor = Cursors.Default
    Call ShowPoleDisplay(PrefInfo.Header, False)

  End Sub

  Private Sub BTNPaymentInvoice_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPaymentInvoice.Click
    Me.Cursor = Cursors.WaitCursor
    Dim OBJNew As New Form_Debt_Payment
    OBJNew.Invoice = True
    OBJNew.Name = "Form_Debt_Payment"
    OBJNew.Text = "Invoice - Payment"
    OBJNew.fromInvoice = True
    OBJNew.ParentOBJForm = Me
    'OBJNew.Invoice = True
    OBJNew.MBTransUID = TransactionUID
    OBJNew.ShowDialog()

    If OBJNew.SaveStatus = True Then
      Call BTNNew_Click(sender, e)
    End If
    Me.Cursor = Cursors.Default

  End Sub
#End Region

  Public Sub New()

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.

  End Sub

  Private Function AddPrefixSpace(ByVal inputString As String) As String

    Dim retVal As String = ""
    For counter = Len(inputString) To 19
      retVal = retVal & " "
    Next

    AddPrefixSpace = retVal & inputString

  End Function

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
      BTNMakeBill.Enabled = True : BTNMakeBill.VisualStyle = C1Input.VisualStyle.Office2007Blue
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

  Private Sub txtBarcode_LostFocus1(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.LostFocus
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

  Private Sub txtBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarcode.TextChanged

  End Sub
End Class