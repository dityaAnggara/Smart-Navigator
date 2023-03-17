Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win
Imports C1.Win.C1FlexGrid
Imports DataDynamics.ActiveReports
Imports System.IO

Public Class Form_Make_Order_Image


#Region "Variable Reference"
  Dim CatCollection As New Collection
  Dim PMCollection As New Collection
  Dim CatPosition As Long = 0
  Dim PMPosition As Long = 0
  Dim KitchenSplitOrder As String = "0"
  Dim OrderListCollection As New Collection
  Dim CustOrderInfo As New ArrayList
  Public TransactionNumber As String
  Public ItemNotes As String = Nothing

  Dim TransactionUID As String = GetTransactionCode(SelectedTable.TableUID)
  'Dim UIDtoRemove As New ArrayList

  Dim mbTransNO As String = Nothing
  Dim UserPermition As New UserPermitionLib
  Dim ListCollection As New Collection
  Dim FormStatus As FormStatusLib
  Public EditStatus As Boolean = False
  Dim hitungPopUP As Integer = 0
  Dim curRow As Integer = 0

#End Region

#Region "Initialize & Object Function"

  Private Sub BasicInitialize()

    'CustOrderInfo = GetCustOrderInfo(FindCust(TransactionUID))
    CatCollection = DBListCollection("SELECT * FROM INVENCAT WHERE (INVENCATLVL = '2' or INVENCATLVL = '3') and (INVENCATACTV IS NULL OR INVENCATACTV = 0 ) ORDER BY INVENCATDISPLAYORDER")
    Call CategoryList(IIf(CatCollection.Count > 0, 1, 0))
    Call ReinitializeOrderList()

    'Dim Query As String = "SELECT COUNT(*) AS DATAEXISTS FROM MBTRANSDT LEFT OUTER JOIN TABLELIST ON MBTRANSDT.MBTRANSUID = TABLELIST.TABLEMBTRANSUID WHERE MBTRANSDTITEMSTAT IS NULL OR MBTRANSDTITEMSTAT=0 AND TABLELISTUID= '" & SelectedTable.TableUID & "'"
    'Dim TMPRecord As FbDataReader
    'TMPRecord = MyDatabase.MyReader(Query)

    'While TMPRecord.Read
    '    If TMPRecord.Item("DATAEXISTS") = 0 Then
    '        FormStatus = FormStatusLib.OpenFirstUse
    '        Call OBJControlHandler(Me, FormStatus)
    '        Call CheckPermission(UserInformation.UserTypeUID, False)
    '    Else
    '        FormStatus = FormStatusLib.OpenAndView
    '        Call OBJControlHandler(Me, FormStatus)
    '        Call CheckPermission(UserInformation.UserTypeUID, True)
    '    End If
    'End While 

    'ListCollection = DBListCollection("SELECT COUNT(mbDt.MBTRANSDTUID) AS DATAEXISTS FROM TABLELIST tb JOIN MBTransDt mbDt ON tb.TABLEMBTRANSUID = mbDt.MBTRANSUID AND (mbDt.MBTransDtItemStat IS NULL OR mbDt.MBTransDtItemStat = 0) WHERE tb.TABLELISTUID='" & SelectedTable.TableUID & "'")
    'FormStatus = OBJControlInitialize(ListCollection)
    'Call OBJControlHandler(Me, FormStatus)
    'Call CheckPermission(UserInformation.UserTypeUID, IIf(ListCollection.Count > 0, True, False))
    Call CheckPermission(UserInformation.UserTypeUID, True)

  End Sub

  Private Sub SettingAccess(ByVal Access As Boolean)
    BTNSave.Enabled = Access
    BTNTakeAway.Enabled = Access
    BTNNotes.Enabled = Access
    BTNReset.Enabled = Access
    GroupQty.Enabled = Access
    GroupCategory.Enabled = Access
    GroupItem.Enabled = Access

    If Access = True Then
      BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Blue
      BTNTakeAway.VisualStyle = C1Input.VisualStyle.Office2007Blue
      BTNNotes.VisualStyle = C1Input.VisualStyle.Office2007Blue
      BTNReset.VisualStyle = C1Input.VisualStyle.Office2007Blue
    Else
      BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver
      BTNTakeAway.VisualStyle = C1Input.VisualStyle.Office2007Silver
      BTNNotes.VisualStyle = C1Input.VisualStyle.Office2007Silver
      BTNReset.VisualStyle = C1Input.VisualStyle.Office2007Silver
    End If
  End Sub

  Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)
    Dim TMPRecord As FbDataReader
    TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2203'")
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

      If .EditAccess Then
        'If ListCollection.Count > 0 Then
        SettingAccess(True)
        'Else
        'SettingAccess(False)
        'End If
      Else
        SettingAccess(False)
      End If

      If PrefInfo.UseKitchenPrintOut = "0" Then
        If .DeleteAccess Then
          BTNRemove.Enabled = True
          BTNRemove.VisualStyle = C1Input.VisualStyle.Office2007Blue
        Else
          BTNRemove.Enabled = False
          BTNRemove.VisualStyle = C1Input.VisualStyle.Office2007Silver
        End If
      ElseIf PrefInfo.UseKitchenPrintOut = "1" Then
        BTNRemove.Enabled = True
        BTNRemove.VisualStyle = C1Input.VisualStyle.Office2007Blue
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

  Public Sub GetDTOrder(ByVal MBUID As String)

    'OrderListCollection.Clear()
    'With OrderListCollection
    '    Dim ItemRecord As FbDataReader
    '    ItemRecord = MyDatabase.MyReader("SELECT A.*, B.INVENLEVEL FROM MBTRANSDT A, INVEN B WHERE A.MBTRANSDTITEMUID=B.INVENUID AND A.MBTRANSUID = '" & MBUID & "' AND A.MBTRANSDTITEMSTAT > -1")
    '    While ItemRecord.Read
    '        Dim ListArray As New ArrayList
    '        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMUID"))
    '        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMQTY"))
    '        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMNAME"))
    '        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMPRICE"))
    '        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMQTY") * ItemRecord.Item("MBTRANSDTITEMPRICE"))
    '        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMNOTE"))
    '        ListArray.Add(IIf(ItemRecord.Item("MBTRANSDTITEMNOTE") = Nothing, False, True))
    '        ListArray.Add(IIf(ItemRecord.Item("MBTRANSDTISTAKEAWAY") = 0, False, True))
    '        ListArray.Add(ItemRecord.Item("MBTRANSDTUID"))
    '        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMSTAT"))
    '        ListArray.Add(ItemRecord.Item("INVENLEVEL"))
    '        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMMEASUNITDESC"))
    '        ListArray.Add(ItemRecord.Item("MBTRANSDTUID"))
    '        OrderListCollection.Add(ListArray)
    '    End While
    'End With
    OrderListCollection.Clear()
    With OrderListCollection
      Dim ItemRecord As FbDataReader
      ItemRecord = MyDatabase.MyReader("SELECT A.*, B.INVENLEVEL,C.jmlMod FROM MBTRANSDT A INNER JOIN INVEN B ON A.MBTRANSDTITEMUID=B.INVENUID LEFT JOIN (SELECT COUNT(MBTRANSDTITEMNAME) AS jmlMod,MBTRANSDTPARENTUID FROM MBTRANSDT WHERE MBTRANSDTPARENTUID IS NOT NULL GROUP BY MBTRANSDTPARENTUID) AS C ON A.MBTRANSDTUID=C.MBTRANSDTPARENTUID WHERE A.MBTRANSUID = '" & MBUID & "' AND A.MBTRANSDTITEMSTAT > -1 AND A.MBTRANSDTPARENTUID IS NULL")
      While ItemRecord.Read
        Dim ListArray As New ArrayList
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMUID"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMQTY"))
        If IsDBNull(ItemRecord("MBTRANSDTLISTNOTE")) = True Then
          ListArray.Add(ItemRecord.Item("MBTRANSDTITEMNAME"))
        Else
          If Trim(ItemRecord("MBTRANSDTLISTNOTE")) = "" Then
            ListArray.Add(ItemRecord.Item("MBTRANSDTITEMNAME"))
          Else
            ListArray.Add(ItemRecord.Item("MBTRANSDTITEMNAME") & vbNewLine & "   +" & Replace(ItemRecord("MBTRANSDTLISTNOTE"), MY_SUB_DELIMITER, vbNewLine & "   +"))
          End If
        End If
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMPRICE"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMQTY") * ItemRecord.Item("MBTRANSDTITEMPRICE"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMNOTE"))
        ListArray.Add(IIf(ItemRecord.Item("MBTRANSDTITEMNOTE") = Nothing, False, True))
        ListArray.Add(IIf(ItemRecord.Item("MBTRANSDTISTAKEAWAY") = 0, False, True))
        ListArray.Add(ItemRecord.Item("MBTRANSDTUID"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMSTAT"))
        ListArray.Add(ItemRecord.Item("INVENLEVEL"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMMEASUNITDESC"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTUID"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTLISTNOTE"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTLISTNOTEUID"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTUID"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTPARENTUID"))
        ListArray.Add(IIf(IsDBNull(ItemRecord.Item("jmlMod")) = True, "0", ItemRecord.Item("jmlMod")))
        OrderListCollection.Add(ListArray)
      End While
    End With
  End Sub

  Private Function GetCustOrderInfo(ByVal CustUID As String) As ArrayList
    Dim TMPRecord As FbDataReader
    Dim TMPArray As New ArrayList
    TMPRecord = MyDatabase.MyReader("SELECT * FROM CUST WHERE CUSTUID = '" & CustUID & "'")
    While TMPRecord.Read
      If Not IsDBNull(TMPRecord.Item("CUSTNO")) Then
        For i As Integer = 0 To TMPRecord.FieldCount - 1
          TMPArray.Add(TMPRecord.Item(i))
        Next
      End If
    End While
    Return TMPArray
  End Function

  Private Function GetTransactionCode(ByVal TableUID As String)
    Dim TMPRecord As FbDataReader
    TMPRecord = MyDatabase.MyReader("SELECT TABLEMBTRANSUID FROM TABLELIST WHERE TABLELISTUID = '" & TableUID & "'")
    TMPRecord.Read()

    If IsDBNull(TMPRecord.Item("TABLEMBTRANSUID")) Then
      Return Nothing
    Else
      Return TMPRecord.Item("TABLEMBTRANSUID")
    End If

  End Function

  Private Sub ReinitializeOrderList()

    Dim itemModFound As Boolean = False
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
          .AddItem(CurrentRecord(12) & vbTab & CurrentRecord(0) & vbTab & CurrentRecord(1) & vbTab & CurrentRecord(2) & vbTab & CurrentRecord(3) & vbTab & CurrentRecord(4) & vbTab & CurrentRecord(5) & vbTab & CurrentRecord(6) & vbTab & CurrentRecord(7) & vbTab & CurrentRecord(8) & vbTab & CurrentRecord(9) & vbTab & CurrentRecord(10) & vbTab & CurrentRecord(11) & vbTab & CurrentRecord(14) & vbTab & CurrentRecord(15))
          If CInt(CurrentRecord(17)) > 0 Then 'jika ada item modifier
            Dim arrData() As String
            arrData = Split(CurrentRecord(2), vbNewLine & "   +")
            If CInt(UBound(arrData)) > 2 Then
              .Rows(.Rows.Count - 1).Height = 45 + (10 * CInt(CurrentRecord(17)) - 2)
            Else
              .Rows(.Rows.Count - 1).Height = 45
            End If
            Call fillItemMod(CurrentRecord(15))
            itemModFound = True
          Else
            .Rows(.Rows.Count - 1).Height = 45
          End If
          If CurrentRecord(9) = 1 Then
            .Rows(i).Style = OrderDetail.Styles("Disable")
          End If
        Next
        If itemModFound = True Then
          Dim rs As FbDataReader
          rs = MyDatabase.MyReader("SELECT MBTRANSNO FROM MBTRANS WHERE MBTRANSUID='" & TransactionUID & "'")
          If rs.Read() = True Then mbTransNO = rs("MBTRANSNO")
          rs = Nothing
        Else
          mbTransNO = ""
        End If
        Call ReInitializePrice()
      End If
      .Redraw = True
    End With

  End Sub

  Private Sub fillItemMod(ByVal idParent As String)
    Dim rs As FbDataReader
    Dim cR As CellRange
    Dim cs As CellStyle
    rs = MyDatabase.MyReader("SELECT * FROM MBTRANSDT WHERE MBTRANSDTPARENTUID='" & idParent & "'")
    With OrderDetail
      cs = .Styles.Add("string")
      cs.DataType = Type.GetType("System.String")
      While rs.Read()
        .AddItem(vbTab & rs("MBTRANSDTITEMUID") & vbTab & "-" & vbTab & "   +" & Trim(rs("MBTRANSDTITEMNAME")) & vbTab & " " & vbTab & " " & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "2" & vbTab & "" & vbTab & "" & vbTab & rs("MBTRANSDTUID") & vbTab & idParent)
        .Rows(.Rows.Count - 1).Height = 25
        cR = .GetCellRange(.Rows.Count - 1, 7)
        cR.Style = .Styles("string")
        cR = .GetCellRange(.Rows.Count - 1, 8)
        cR.Style = .Styles("string")
      End While
    End With
    rs = Nothing
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
    Dim x As Integer = 0

    Call ResetAll()
    CatPosition = Position
    If CatCollection.Count > 6 Then
      LoopFrom = Position
      If Position + 5 > CatCollection.Count Then
        LoopTo = CatCollection.Count
      Else
        LoopTo = Position + 5
      End If
    Else
      LoopFrom = Position
      LoopTo = CatCollection.Count
    End If

    If Position > 0 Then
      For i As Integer = LoopFrom To LoopTo
        CurrentRecord = CatCollection(i)

        CurOBJIndex = IIf(i > 6, (i Mod 6), i)
        CurOBJIndex = IIf(CurOBJIndex = 0, 6, CurOBJIndex)

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

    BackCategory.Enabled = Position > 6
    NextCategory.Enabled = CatCollection.Count > Position + 5
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

    If PMCollection.Count > 15 Then
      LoopFrom = Position
      If Position + 14 > PMCollection.Count Then
        LoopTo = PMCollection.Count
      Else
        LoopTo = Position + 14
      End If
    Else
      LoopFrom = Position
      LoopTo = PMCollection.Count
    End If

    If Position > 0 Then
      For i As Integer = LoopFrom To LoopTo
        CurrentRecord = PMCollection(i)

        CurOBJIndex = IIf(i > 15, (i Mod 15), i)
        CurOBJIndex = IIf(CurOBJIndex = 0, 15, CurOBJIndex)

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
                  OBJ.VisualStyle = C1Input.VisualStyle.System
                Else
                  If CurrentRecord(31).ToString = "DEFAULT COLOUR" Then
                    OBJ.VisualStyle = C1Input.VisualStyle.System
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
              'OBJ.text = Replace(CurrentRecord(2), "&", "&&")
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
              OBJ.tag = CurrentRecord(0) & MY_DELIMITER & CurrentRecord(2) & MY_DELIMITER & CurrentRecord(3) & MY_DELIMITER & CurrentRecord(16) & MY_DELIMITER & selectedPriceLevel & MY_DELIMITER & IIf(IsDBNull(CurrentRecord(33)) = True, "0", CurrentRecord(33)) & MY_DELIMITER & tmpSisaMakanan & MY_DELIMITER & IIf(IsDBNull(CurrentRecord(34)) = True, "0", CurrentRecord(34)) & MY_DELIMITER & IIf(IsDBNull(CurrentRecord(35)) = True, "0", CurrentRecord(35))
            End If
          End If
        Next
      Next
    End If

    BackItem.Enabled = Position > 15
    NextItem.Enabled = PMCollection.Count > Position + 14
    BackItem.VisualStyle = IIf(BackItem.Enabled, C1Input.VisualStyle.Office2007Blue, C1Input.VisualStyle.Office2007Silver)
    NextItem.VisualStyle = IIf(NextItem.Enabled, C1Input.VisualStyle.Office2007Blue, C1Input.VisualStyle.Office2007Silver)
    Me.Cursor = Cursors.Default

  End Sub

  Private Function GetInvenImageFromByteArray(ByVal inputUID As Object) As Image

    Dim IMGResult() As Byte = inputUID
    Dim FS As MemoryStream = New MemoryStream(IMGResult)

    Return Image.FromStream(FS)

  End Function

  Private Sub CategoryClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Category1.Click, Category2.Click, Category3.Click, Category4.Click, Category5.Click, Category6.Click
    Me.Cursor = Cursors.WaitCursor
    'Susilo, 6 Agustus 2014. Query dirubah karena ada modifier
    'PMCollection = DBListCollection("SELECT A.INVENUID, A.INVENNO, A.INVENNAME, A.INVENLEVEL, A.INVENTYPEID, A.INVENCATUID, A.INVENPARENTUID, A.INVENMEASUNITUID, A.INVENDFTWAREHUID, A.INVENDISCPERC, A.INVENSALESTAXUID, A.INVENDFTVENDUID, A.INVENPURCHTAXUID, A.INVENMINQTYREORDER, A.INVENDESC," & _
    '                                "A.INVENDFTPRICELISTLVL, A.INVENMEASUNITDESC, A.INVENKITCHENUID, A.INVENACTV, A.INVENDISPLAYORDER, A.INVENISPRINTED, B.INVENPRICELISTLVL1,B.INVENPRICELISTLVL2,B.INVENPRICELISTLVL3,B.INVENPRICELISTLVL4,B.INVENPRICELISTLVL5,B.INVENPRICELISTLVL6,B.INVENPRICELISTLVL7," & _
    '                                "B.INVENPRICELISTLVL8,B.INVENPRICELISTLVL9,B.INVENPRICELISTLVL10,A.INVENCOLOUR,A.INVENIMG,A.INVENEDITABLEMENU FROM INVEN A INNER JOIN INVENPRICELIST B ON A.INVENUID=B.INVENUID WHERE A.INVENCATUID = '" & sender.tag & "' AND (A.INVENACTV IS NULL OR A.INVENACTV = 0 ) ORDER BY A.INVENNAME")
    PMCollection = DBListCollection("SELECT A.INVENUID, A.INVENNO, A.INVENNAME, A.INVENLEVEL, A.INVENTYPEID, A.INVENCATUID, A.INVENPARENTUID, A.INVENMEASUNITUID, A.INVENDFTWAREHUID, A.INVENDISCPERC, A.INVENSALESTAXUID, A.INVENDFTVENDUID, A.INVENPURCHTAXUID, A.INVENMINQTYREORDER, A.INVENDESC, " & _
                                    "A.INVENDFTPRICELISTLVL, A.INVENMEASUNITDESC, A.INVENKITCHENUID, A.INVENACTV, A.INVENDISPLAYORDER, A.INVENISPRINTED, B.INVENPRICELISTLVL1,B.INVENPRICELISTLVL2,B.INVENPRICELISTLVL3,B.INVENPRICELISTLVL4,B.INVENPRICELISTLVL5,B.INVENPRICELISTLVL6,B.INVENPRICELISTLVL7," & _
                                    "B.INVENPRICELISTLVL8,B.INVENPRICELISTLVL9,B.INVENPRICELISTLVL10,A.INVENCOLOUR,A.INVENIMG,A.INVENEDITABLEMENU,jmlRowC,jmlRowD " & _
                                    "FROM INVEN A INNER JOIN INVENPRICELIST B ON A.INVENUID=B.INVENUID " & _
                                    "LEFT JOIN (SELECT COUNT(INVENPARENTUID) AS jmlRowC,INVENPARENTUID AS idParent FROM INVEN GROUP BY idParent) AS C ON A.INVENUID=C.idParent " & _
                                    "LEFT JOIN (SELECT COUNT(INVENUID) AS jmlRowD,INVENUID AS idItem FROM INVENITEMMOD GROUP BY idItem) AS D ON A.INVENUID=D.idItem " & _
                                    "WHERE (A.INVENPARENTUID IS NULL OR A.INVENPARENTUID=A.INVENUID) AND A.INVENCATUID = '" & sender.tag & "' AND (A.INVENACTV IS NULL OR A.INVENACTV = 0 ) ORDER BY A.INVENNAME")
    Call PMList(IIf(PMCollection.Count > 0, 1, 0))
    Me.Cursor = Cursors.Default
  End Sub

  Private Sub ItemClick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Item01.Click, Item02.Click, Item03.Click, Item04.Click, Item05.Click, Item06.Click, Item07.Click, Item08.Click, Item09.Click, Item10.Click, Item11.Click, Item12.Click, Item13.Click, Item14.Click, Item15.Click

    Dim Bypas As Boolean = False
    'Item UID, QTY, Item, Price, Amount, TXTNotes, Order By, Notes, TA

    Dim selItemUID As String, selItemName As String, selItemLevel As String, selItemMeas As String, isOpenPrice As String
    Dim selItemPrice As String, jmlSisaMakanan As String
    Dim arrayData As String()
    'txtcatu.Text = sender.tag
    'MessageBox.Show(sender.tag)
    'txtBarcode.Text = sender.tag


    arrayData = Split(sender.tag, MY_DELIMITER)
    If UBound(arrayData) >= 5 Then

      selItemUID = CStr(arrayData(0))
      selItemName = CStr(arrayData(1))
      selItemLevel = CStr(arrayData(2))
      selItemMeas = CStr(arrayData(3))
      selItemPrice = CStr(arrayData(4))
      isOpenPrice = CStr(arrayData(5))
      jmlSisaMakanan = CStr(arrayData(6))
      If CInt(arrayData(7)) = 0 And CInt(arrayData(8)) = 0 Then
        With OrderDetail
          For i As Integer = 1 To .Rows.Count - 1
            If .Item(i, 1) = selItemUID And Trim(.Item(i, 15)) = "" Then
              If .Item(i, 10) = "1" Then
                ShowMessage(Me, "Maaf, anda tidak dapat menambahkan order pesanan yang sudah dimasak." & vbNewLine & "Silakan keluar dari form ini, dan panggil form Make Order, untuk menambahkan order baru !")
                Exit Sub
              End If
              If PrefInfo.ShowQuantity = "1" And jmlSisaMakanan < CInt(.Item(i, 2) + 1) Then
                If ShowQuestion(Me, "Maaf, jumlah menu yang Anda pilih sudah habis atau tidak cukup untuk di order. Lanjutkan ?", True) = False Then
                  Exit Sub : Bypas = True : Exit For
                End If
              End If
              .Item(i, 2) = .Item(i, 2) + 1
              .Item(i, 5) = .Item(i, 2) * .Item(i, 4)
              Call ReInitializePrice()
              Application.DoEvents()
              Call ShowPoleDisplay(Mid(.Item(i, 2) & "x" & .Item(i, 3), 1, 18), False)
              Call ShowPoleDisplay(FormatNumber(.Item(i, 5), 0), True)
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
            Call ReInitializePrice()
            Application.DoEvents()
            Call ShowPoleDisplay(Strings.Left(selItemName, 18), False)
            '& vbNewLine & "@" & selItemPrice
            Call ShowPoleDisplay(FormatNumber(selItemPrice, 0), True)
          End If
        End With

      Else
        Me.Cursor = Cursors.WaitCursor
        Form_Detail_Menu.nmMenu = sender.text
        Form_Detail_Menu.harga = arrayData(4)
        Form_Detail_Menu.meas = arrayData(3)
        Form_Detail_Menu.idBarang = selItemUID
        Form_Detail_Menu.itemEdit = ""
        Form_Detail_Menu.jmlItem = ""
        Form_Detail_Menu.ShowDialog()
        If Form_Detail_Menu.dftItem <> "" Then
          With OrderDetail
            Dim tmpUID As String = AutoUID()
            .AddItem(Form_Detail_Menu.dftItem & vbTab & tmpUID & vbTab & "")
            Dim arrData() As String
            arrData = Split(Form_Detail_Menu.dftItem, vbTab)
            If Form_Detail_Menu.jmlRow > 2 Then
              .Rows(.Rows.Count - 1).Height = 45 + (10 * Form_Detail_Menu.jmlRow - 2)
            Else
              .Rows(.Rows.Count - 1).Height = 45
            End If
            selItemName = .Item(.Rows.Count - 1, 3)
            selItemPrice = .Item(.Rows.Count - 1, 5)
            .Row = .Rows.Count - 1
            Dim arrBarang() As String = Split(arrData(UBound(arrData)), MY_DELIMITER)
            Dim cR As CellRange
            Dim cs As CellStyle
            cs = .Styles.Add("string")
            cs.DataType = Type.GetType("System.String")
            For i As Integer = 0 To UBound(arrBarang) - 1
              Dim arrDetailBarang() As String = Split(arrBarang(i), MY_SUB_DELIMITER)
              If Trim(arrDetailBarang(3)) <> "-" Then
                Dim tmpIdDetail As String = AutoUID()
                .AddItem(vbTab & arrDetailBarang(3) & vbTab & "-" & vbTab & "   +" & Trim(arrDetailBarang(4)) & vbTab & " " & vbTab & " " & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "2" & vbTab & arrDetailBarang(5) & vbTab & "" & vbTab & tmpIdDetail & vbTab & tmpUID)
                .Rows(.Rows.Count - 1).Height = 25
                cR = .GetCellRange(.Rows.Count - 1, 7)
                cR.Style = .Styles("string")
                cR = .GetCellRange(.Rows.Count - 1, 8)
                cR.Style = .Styles("string")
              End If
            Next
          End With
        End If
        Form_Detail_Menu.Close()
        Call ReInitializePrice()
        Application.DoEvents()
        Call ShowPoleDisplay(Strings.Left(selItemName, 18), False)
        '& vbNewLine & "@" & selItemPrice
        Call ShowPoleDisplay(FormatNumber(selItemPrice, 0), True)
        Me.Cursor = Cursors.Default
      End If
      'Call FocusMove(BTNMoveDown, e)

    End If

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

  'Private Function ItemPrice(ByVal ItemID As String) As String
  '    Dim TMPRecord As FbDataReader
  '    Dim Level As String = Nothing
  '    Dim CurrentPrice As Double

  '    TMPRecord = MyDatabase.MyReader("SELECT INVENUID, INVENDFTPRICELISTLVL FROM INVEN WHERE INVENUID LIKE '" & ItemID & "'")
  '    While TMPRecord.Read
  '        Level = TMPRecord.Item("INVENDFTPRICELISTLVL")
  '    End While

  '    If Not CustOrderInfo(26) = Nothing Then
  '        Level = CustOrderInfo(26)
  '    End If

  '    If Level = Nothing Then Level = "1"

  '    TMPRecord.Close()
  '    TMPRecord = MyDatabase.MyReader("SELECT INVENUID,(SELECT (INVENPRICELISTLVL" & Level & ")as Price FROM INVENPRICELIST WHERE INVENUID LIKE '" & ItemID & "') FROM INVEN WHERE INVENUID LIKE '" & ItemID & "'")
  '    While TMPRecord.Read
  '        CurrentPrice = TMPRecord.Item("Price")
  '    End While
  '    If CurrentPrice = Nothing Then CurrentPrice = 0
  '    Return CurrentPrice

  '    TMPRecord = Nothing
  'End Function

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
      If .Rows(.Row).Height = 25 Then Exit Sub
      If .Rows.Count > 1 Then
        If .Rows(.Row).Height = 25 Then Exit Sub
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
      End If
    End With
    Call ReInitializePrice()
  End Sub

  Private Sub QTYPlusMinus(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles QTYPlus.Click, QTYMinus.Click
    With OrderDetail
      If .Rows(.Row).Height = 25 Then Exit Sub
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
      If OrderDetail.Rows(OrderDetail.Row).Height = 25 Then Exit Sub
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

      Call ReInitializePrice()
    End If
  End Sub

  Private Sub CatBackNext(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackCategory.Click, NextCategory.Click
    Select Case sender.name
      Case "BackCategory"
        CatPosition = CatPosition - 6
      Case "NextCategory"
        CatPosition = CatPosition + 6
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
        PMPosition = PMPosition - 15
      Case "NextItem"
        PMPosition = PMPosition + 15
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

    With OrderDetail
      If .Rows.Count > 1 Then
        If .Rows(.Row).Height = 25 Then Exit Sub
        If Len(Trim(.Item(.Row, 9))) > 0 Then
          If ApakahMejaKosong() Then Exit Sub
          If ApakahMejaSudahBilling() Then Exit Sub
          Dim TMPRecord As FbDataReader
          TMPRecord = MyDatabase.MyReader("SELECT * FROM MBTRANSDT WHERE MBTRANSDTUID = '" & .Item(.Row, 9) & "'")
          If TMPRecord.Read() Then
            If TMPRecord.Item("MBTRANSDTITEMSTAT") > 0 Then
              ShowMessage(Me, "Maaf, order pesanan tidak dapat dibatalkan, karena order pesanan ini telah diproses !")

              'Dim TMPRecordd As FbDataReader
              Dim myDataSet As DataSet
              myDataSet = MyDatabase.MyAdapter("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2203'")

              If myDataSet.Tables(0).Rows.Count > 0 Then
                UserPermition.PermitionInitialize(myDataSet.Tables(0).Rows(0).Item("USERCATCREATEACCESS"), myDataSet.Tables(0).Rows(0).Item("USERCATEDITACCESS"), myDataSet.Tables(0).Rows(0).Item("USERCATDELETEACCESS"), myDataSet.Tables(0).Rows(0).Item("USERCATREADACCESS"), myDataSet.Tables(0).Rows(0).Item("USERCATPRINTACCESS"), myDataSet.Tables(0).Rows(0).Item("USERCATCHANGEDATEACCESS"), myDataSet.Tables(0).Rows(0).Item("USERCATCHANGETIMEACCESS"), myDataSet.Tables(0).Rows(0).Item("USERCATMODIFIEDORDERAFTERDUMPED"))
              End If

              'While TMPRecordd.Read()
              '    UserPermition.PermitionInitialize(TMPRecordd.Item("USERCATCREATEACCESS"), TMPRecordd.Item("USERCATEDITACCESS"), TMPRecordd.Item("USERCATDELETEACCESS"), TMPRecordd.Item("USERCATREADACCESS"), TMPRecordd.Item("USERCATPRINTACCESS"), TMPRecordd.Item("USERCATCHANGEDATEACCESS"), TMPRecordd.Item("USERCATCHANGETIMEACCESS"), TMPRecordd.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
              'End While

              With UserPermition
                If Not .DeleteOrderAccess Then
                  Dim OBJNew As New Form_User_Authorize_Dialog
                  OBJNew.Name = "Form_User_Authorize_Dialog"
                  OBJNew.ParentOBJForm = Me
                  OBJNew.NeedAuthorizationForMakeBill = False
                  OBJNew.ShowDialog()
                  Authorize = True
                End If

                If .DeleteOrderAccess Then

                  Dim OBJNew As New Dialog_Notes
                  OBJNew.Name = "Dialog_Notes"
                  OBJNew.ParentOBJForm = Me
                  OBJNew.ShowDialog()

                  If ItemNotes = Nothing Then
                    Exit Sub
                  End If
                  Dim DeleteOrder As String = OrderDetail.Item(OrderDetail.Row, 3)
                  Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMCANCELLEDNOTE='" & ReplacePetik(ItemNotes) & "',MBTRANSDTITEMSTAT=-1 WHERE MBTRANSDTUID = '" & OrderDetail.Item(OrderDetail.Row, 9) & "'")
                  Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMCANCELLEDNOTE='" & ReplacePetik(ItemNotes) & "',MBTRANSDTITEMSTAT=-1 WHERE MBTRANSDTPARENTUID = '" & OrderDetail.Item(OrderDetail.Row, 9) & "'")
                  For i As Integer = OrderDetail.Rows.Count - 1 To 1 Step -1
                    If Trim(OrderDetail.Item(i, 14)) <> "" And OrderDetail.Item(i, 15) <> "" Then
                      If OrderDetail.Item(i, 15) = OrderDetail.Item(OrderDetail.Row, 14) Then
                        OrderDetail.Rows.Remove(i)
                      End If
                    End If
                  Next
                  OrderDetail.Rows.Remove(OrderDetail.Row)
                  ShowMessage(Me, "Order pesanan '" & DeleteOrder & "' telah dibatalkan !")
                  If Authorize = True Then
                    Authorize = False
                    UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, UDeptUID)
                    Call MainPage.StatusBarInitialize()
                  End If
                Else
                  FormStatus = FormStatusLib.OpenAndLock
                  Call OBJControlHandler(Me, FormStatus)
                End If
              End With

              Exit Sub
            End If
          End If

          If ShowQuestion(Me, "Hapur order pesanan '" & .Item(.Row, 3) & "' dari daftar ?") = True Then
            Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET DELETEDUSER='" & UserInformation.UserName & "' WHERE MBTRANSDTUID = '" & .Item(.Row, 9) & "'")
            Dim tmpParent As String = .Item(.Row, 9)
            'Anjo : 12 Okt : Deleting detail is done via trigger
            'Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDTDETAIL WHERE MBTRANSDTUID = '" & .Item(.Row, 9) & "'")
            Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDT WHERE MBTRANSDTUID = '" & .Item(.Row, 9) & "'")
            Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET DELETEDUSER='" & UserInformation.UserName & "' WHERE MBTRANSDTPARENTUID = '" & tmpParent & "'")
            Call MyDatabase.MyAdapter("DELETE FROM MBTRANSDT WHERE MBTRANSDTPARENTUID = '" & tmpParent & "'")
            Application.DoEvents()

            For i As Integer = .Rows.Count - 1 To 1 Step -1
              If Trim(.Item(i, 14)) <> "" And .Item(i, 15) <> "" Then
                If .Item(i, 15) = .Item(.Row, 14) Then
                  .Rows.Remove(i)
                End If
              End If
            Next
            .Rows.Remove(.Row)
            Call ReInitializePrice()
          End If
        Else
          If ShowQuestion(Me, "Hapus order pesanan '" & .Item(.Row, 3) & "' dari daftar ?") = True Then
            For i As Integer = .Rows.Count - 1 To 1 Step -1
              If Trim(.Item(i, 14)) <> "" And .Item(i, 15) <> "" Then
                If .Item(i, 15) = .Item(.Row, 14) Then
                  .Rows.Remove(i)
                End If
              End If
            Next
            .Rows.Remove(.Row)
            Call ReInitializePrice()
          End If
        End If
      End If
    End With
  End Sub

  Private Sub BTNTakeAway_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNTakeAway.Click
    'If ApakahMejaKosong() = True Then
    '    Exit Sub
    'End If
    'If ApakahMejaSudahBilling() = True Then
    '    Exit Sub
    'End If

    With OrderDetail
      If .Rows.Count > 1 Then
        If .Rows(.Row).Height = 25 Then Exit Sub
        .Item(.Row, 8) = Not .Item(.Row, 8)
      End If
    End With
  End Sub

  Private Sub ShowPrintPreview(Optional ByVal Nota As Boolean = False, Optional ByVal printerName As String = "")
    Dim OBJNew As New Form_Print_Preview
    Dim Query As String
    Query = "SELECT a.MBTRANSUID, a.MBTRANSNO, a.MBTRANSDATE, a.MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME, a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID,(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = a.MBTRANSSERVICETYPEUID) AS MBTRANSSERVICETYPENAME, a.MBTRANSRSVTRANSUID, a.MBTRANSSUBVAL, a.MBTRANSDISCPERC, a.MBTRANSDISCVAL, a.MBTRANSTAXVAL1, a.MBTRANSTAXVAL2, a.MBTRANSDPVAL, a.MBTRANSTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT, a.MODIFIEDUSER, b.TABLELISTNAME " & _
             "FROM MBTRANS a LEFT JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE MBTRANSUID = '" & TransactionUID & "'"
    OBJNew.Printer = printerName
    OBJNew.Name = "Form_Print_Preview"
    OBJNew.RPTTitle = "Make Order"
    OBJNew.RPTDocument = New Make_Order
    OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
    OBJNew.VersiNota = Nota
    OBJNew.ShowDialog()
  End Sub

  Private Sub ShowPrintPreviewSplit(Optional ByVal Nota As Boolean = False, Optional ByVal printerName As String = "")
    Form_Print_Preview.Close()
    Dim OBJNew As New Form_Print_Preview
    Dim Query As String

    Query = "SELECT a.MBTRANSUID, a.MBTRANSNO, a.MBTRANSDATE, a.MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME, a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID,(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = a.MBTRANSSERVICETYPEUID) AS MBTRANSSERVICETYPENAME, a.MBTRANSRSVTRANSUID, a.MBTRANSSUBVAL, a.MBTRANSDISCPERC, a.MBTRANSDISCVAL, a.MBTRANSTAXVAL1, a.MBTRANSTAXVAL2, a.MBTRANSDPVAL, a.MBTRANSTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT, a.MODIFIEDUSER, b.TABLELISTNAME " & _
             "FROM MBTRANS a LEFT JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE MBTRANSUID = '" & TransactionUID & "'"
    OBJNew.Printer = printerName
    OBJNew.Name = "Form_Print_Preview"
    OBJNew.RPTTitle = "Make Order"
    OBJNew.RPTDocument = New Make_Order_Split
    OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
    OBJNew.VersiNota = Nota
    OBJNew.ShowDialog()
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

    'MessageBox.Show(NEWOrderListCollection(1))



    Dim Query As String = Nothing
    Dim nmItem As String = ""
    Dim listNote As String = ""
    Dim tmpJml As Integer = 0
    'Insert New Detail
    'Item UID, QTY, Item, Price, Amount, TXTNotes, TA
    Dim ins As Integer
    For ins = 1 To NEWOrderListCollection.Count
      Dim DETAILUID As String = AutoUID()
      Dim ListArray As New ArrayList
      ListArray = NEWOrderListCollection(ins)
      'Susilo, 7 Agustus 2014. Diganti karena ada modifier
      'Query = "INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT) " & _
      '        "VALUES('" & DETAILUID & "','" & TransactionUID & "','" & ListArray(0) & "','" & ReplacePetik(ListArray(2)) & "','" & ReplacePetik(ListArray(11)) & "','" & Replace(ListArray(1), ",", ".") & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ReplacePetik(ListArray(5)) & "','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1)"
      'Call MyDatabase.MyAdapter(Query)

      If InStr(ListArray(2), vbNewLine & "   +") <> 0 Then
        Dim arrItem() As String = Split(ListArray(2), vbNewLine & "   +")
        nmItem = arrItem(0)
        listNote = Replace(Replace(ListArray(2), nmItem & vbNewLine & "   +", ""), vbNewLine & "   +", MY_SUB_DELIMITER)
      Else
        nmItem = ListArray(2)
        listNote = ""
      End If
      'MessageBox.Show(listNote)
      'MessageBox.Show(ListArray(1))

      'If Trim(ListArray(14)) = "" Then
      'MyDatabase.MyAdapter("INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT,MBTRANSDTLISTNOTE,MBTRANSDTLISTNOTEUID) " & _
      '"VALUES('" & IIf(Trim(ListArray(13)) = "", DETAILUID, ListArray(13)) & "','" & TransactionUID & "','" & ListArray(0) & "','" & ReplacePetik(IIf(Mid(Trim(nmItem), 1, 1) = "+", Mid(Trim(nmItem), 2), Trim(nmItem))) & "','" & ReplacePetik(ListArray(11)) & "','" & ListArray(1) & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ReplacePetik(ListArray(5)) & "','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1,'" & ReplacePetik(listNote) & "','" & ReplacePetik(ListArray(12)) & "')")
      'tmpJml = ListArray(1)
      'Else
      'MyDatabase.MyAdapter("INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT,MBTRANSDTPARENTUID,MBTRANSDTLISTNOTE,MBTRANSDTLISTNOTEUID) " & _
      '"VALUES('" & IIf(Trim(ListArray(13)) = "", DETAILUID, ListArray(13)) & "','" & TransactionUID & "','" & ListArray(0) & "','" & ReplacePetik(IIf(Mid(Trim(nmItem), 1, 1) = "+", Mid(Trim(nmItem), 2), Trim(nmItem))) & "','" & ReplacePetik(ListArray(11)) & "','" & tmpJml & "','0','0','','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1,'" & ListArray(14) & "',NULL,NULL)")
      'End If

      If listNote <> "" Then
        MyDatabase.MyAdapter("INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT,MBTRANSDTLISTNOTE) " & _
        "VALUES('" & DETAILUID & "','" & TransactionUID & "','" & ListArray(0) & "','" & ReplacePetik(ListArray(2)) & "','" & ReplacePetik(ListArray(11)) & "','" & Replace(ListArray(1), ",", ".") & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ReplacePetik(ListArray(5)) & "','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1,'" & listNote & "')")
      Else
        MyDatabase.MyAdapter("INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT) " & _
        "VALUES('" & DETAILUID & "','" & TransactionUID & "','" & ListArray(0) & "','" & ReplacePetik(ListArray(2)) & "','" & ReplacePetik(ListArray(11)) & "','" & Replace(ListArray(1), ",", ".") & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ReplacePetik(ListArray(5)) & "','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1)")
      End If

      'MyDatabase.MyAdapter("INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT,,MBTRANSDTLISTNOTE) " & _
      '  "VALUES('" & DETAILUID & "','" & TransactionUID & "','" & ListArray(0) & "','" & ReplacePetik(ListArray(2)) & "','" & ReplacePetik(ListArray(11)) & "','" & Replace(ListArray(1), ",", ".") & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ReplacePetik(ListArray(5)) & "','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1,'" & listNote & "')")
      'MyDatabase.MyAdapter("INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT,MBTRANSDTLISTNOTE,MBTRANSDTLISTNOTEUID) " & _
      '"VALUES('" & DETAILUID & "','" & TransactionUID & "','" & ListArray(0) & "','" & ReplacePetik(IIf(Mid(Trim(nmItem), 1, 1) = "+", Mid(Trim(nmItem), 2), Trim(nmItem))) & "','" & ReplacePetik(ListArray(11)) & "','" & ListArray(1) & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ReplacePetik(ListArray(5)) & "','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1,'" & listNote & "','" & ReplacePetik(ListArray(12)) & "')")

      'Anjo 12 Okt 2011 : Detail paket is done via trigger
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
    Dim NEWOrderListCollection As New Collection
    If mbTransNO <> "" Then
      MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMCANCELLEDNOTE='" & MY_DELIMITER & "' WHERE MBTRANSUID='" & InputMBTransUID & "' AND MBTRANSDTPARENTUID IN (SELECT B.MBTRANSDTUID FROM MBTRANSDT B WHERE B.MBTRANSUID='" & InputMBTransUID & "' AND B.MBTRANSDTLISTNOTEUID<>'')")
      MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMCANCELLEDNOTE='" & MY_DELIMITER & "' WHERE MBTRANSUID='" & InputMBTransUID & "' AND (MBTRANSDTLISTNOTEUID<>'')")
      MyDatabase.MyAdapter("DELETE FROM MBTRANSDT WHERE MBTRANSUID='" & InputMBTransUID & "' AND MBTRANSDTPARENTUID IN (SELECT B.MBTRANSDTUID FROM MBTRANSDT B WHERE B.MBTRANSUID='" & InputMBTransUID & "' AND (B.MBTRANSDTLISTNOTEUID<>''))")
      MyDatabase.MyAdapter("DELETE FROM MBTRANSDT WHERE MBTRANSUID='" & InputMBTransUID & "' AND (MBTRANSDTLISTNOTEUID<>'')")
      MyDatabase.MyAdapter("DELETE FROM AUDITTRAILREG WHERE AUDITTRAILREGTRANSNO='" & mbTransNO & "' AND AUDITTRAILREGITEMCANCELLEDNOTE='" & MY_DELIMITER & "'")
    End If
    With OrderDetail
      For i As Integer = 1 To .Rows.Count - 1
        Dim OrderList As New ArrayList
        For j As Integer = 1 To .Cols.Count - 1
          OrderList.Add(.Item(i, j))
        Next
        NEWOrderListCollection.Add(OrderList)
      Next
    End With

    'Dim ItemRecord As FbDataReader
    Dim RecordItem As FbDataReader
    Dim Query As String = Nothing
    Dim nmItem As String = ""
    Dim listNote As String = ""
    Dim tmpJml As Integer = 0

    For i As Integer = 1 To NEWOrderListCollection.Count
      RecordItem = MyDatabase.MyReader("SELECT COUNT (*) FROM MBTRANSDT WHERE MBTRANSUID = '" & InputMBTransUID & "' AND MBTRANSDTUID = '" & OrderDetail.Item(i, 0) & "'")
      While RecordItem.Read
        If EditStatus = True Then
          If CInt(RecordItem.Item(0)) > 0 Then
            'Update Existing Detail
            Dim ListArray As New ArrayList
            ListArray = NEWOrderListCollection(i)

            'ItemRecord = MyDatabase.MyReader("SELECT * FROM INVEN WHERE INVENUID = '" & ListArray(0) & "'")
            'ItemRecord.Read()

            If InStr(ListArray(2), vbNewLine & "   +") <> 0 Then
              Dim arrItem() As String = Split(ListArray(2), vbNewLine & "   +")
              nmItem = arrItem(0)
              listNote = Replace(Replace(ListArray(2), nmItem & vbNewLine & "   +", ""), vbNewLine & "   +", MY_SUB_DELIMITER)
            Else
              nmItem = ListArray(2)
              listNote = ""
            End If
            'Susilo, 7 Agustus 2014. Dirubah karena ada item modifier
            'Query = "UPDATE MBTRANSDT SET MBTRANSDTITEMUID='" & ListArray(0) & "',MBTRANSDTITEMMEASUNITDESC='" & ReplacePetik(ListArray(11)) & "',MBTRANSDTITEMQTY='" & Replace(ListArray(1), ",", ".") & "',MBTRANSDTITEMPRICE='" & ListArray(3) & "',MBTRANSDTSUBVAL='" & ListArray(3) * ListArray(1) & "',MBTRANSDTITEMNOTE='" & ReplacePetik(ListArray(5)) & "',MBTRANSDTISTAKEAWAY='" & IIf(ListArray(7) = True, 1, 0) & "',CREATEDUSER='" & UserInformation.UserName & "',MODIFIEDUSER='" & UserInformation.UserName & "',CREATEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',MODIFIEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',PRINT=1 WHERE MBTRANSDTUID = '" & OrderDetail.Item(i, 0) & "' AND MBTRANSUID='" & InputMBTransUID & "'"
            'Call MyDatabase.MyAdapter(Query)
            If Trim(ListArray(14)) = "" Then
              MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMUID='" & ListArray(0) & "',MBTRANSDTITEMNAME='" & ReplacePetik(IIf(Mid(Trim(nmItem), 1, 1) = "+", Mid(Trim(nmItem), 2), Trim(nmItem))) & "',MBTRANSDTITEMMEASUNITDESC='" & ReplacePetik(ListArray(11)) & "',MBTRANSDTITEMQTY='" & ListArray(1) & "',MBTRANSDTITEMPRICE='" & ListArray(3) & "',MBTRANSDTSUBVAL='" & ListArray(3) * ListArray(1) & "',MBTRANSDTITEMNOTE='" & ReplacePetik(ListArray(5)) & "',MBTRANSDTISTAKEAWAY='" & IIf(ListArray(7) = True, 1, 0) & "',CREATEDUSER='" & UserInformation.UserName & "',MODIFIEDUSER='" & UserInformation.UserName & "',CREATEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',MODIFIEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',PRINT=1,MBTRANSDTLISTNOTE='" & ReplacePetik(listNote) & "',MBTRANSDTLISTNOTEUID='" & ReplacePetik(ListArray(12)) & "'" & _
                                   "WHERE MBTRANSDTUID = '" & OrderDetail.Item(i, 0) & "' AND MBTRANSUID='" & InputMBTransUID & "'")
              tmpJml = ListArray(1)
            Else
              MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMUID='" & ListArray(0) & "',MBTRANSDTITEMNAME='" & ReplacePetik(IIf(Mid(Trim(nmItem), 1, 1) = "+", Mid(Trim(nmItem), 2), Trim(nmItem))) & "',MBTRANSDTITEMMEASUNITDESC='" & ReplacePetik(ListArray(11)) & "',MBTRANSDTITEMQTY='" & tmpJml & "',MBTRANSDTITEMPRICE='0',MBTRANSDTSUBVAL='0',MBTRANSDTITEMNOTE='" & ReplacePetik(ListArray(5)) & "',MBTRANSDTISTAKEAWAY='" & IIf(ListArray(7) = True, 1, 0) & "',CREATEDUSER='" & UserInformation.UserName & "',MODIFIEDUSER='" & UserInformation.UserName & "',CREATEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',MODIFIEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',PRINT=1 " & _
                                   "WHERE MBTRANSDTUID = '" & OrderDetail.Item(i, 0) & "' AND MBTRANSUID='" & InputMBTransUID & "'")
            End If
            'listNote = ""
            'Anjo 12 Okt - Paket Detail is done via trigger
            'If CInt(ListArray(10)) = 3 Then
            '    Dim ItemDetail As FbDataReader
            '    ItemDetail = MyDatabase.MyReader("SELECT DT.*,I.INVENNAME  FROM INVENDT DT LEFT OUTER JOIN INVEN I ON DT.INVENDTITEMUID = I.INVENUID WHERE DT.INVENUID='" & ListArray(0) & "'")
            '    While ItemDetail.Read
            '        Query = "UPDATE MBTRANSDTDETAIL SET MBTRANSDTITEMQTY='" & ItemDetail("ITEMQTY") * ListArray(1) & "',MBTRANSDTITEMPRICE='" & ListArray(3) & "',MBTRANSDTSUBVAL='" & ListArray(3) * ListArray(1) & "',MBTRANSDTITEMNOTE='" & ListArray(5) & "',MBTRANSDTISTAKEAWAY='" & IIf(ListArray(7) = True, 1, 0) & "',CREATEDUSER='" & UserInformation.UserName & "',MODIFIEDUSER='" & UserInformation.UserName & "',CREATEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',MODIFIEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "' WHERE MBTRANSDTITEMUID='" & ItemDetail("INVENDTITEMUID") & "'"
            '        Call MyDatabase.MyAdapter(Query)
            '    End While
            'End If
          Else
            ''Insert New Detail
            Dim DETAILUID As String = AutoUID()
            Dim ListArray As New ArrayList
            ListArray = NEWOrderListCollection(i)
            'Susilo, 7 Agustus 2014. Dirubah karena ada item modifier
            'Query = "INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT) " & _
            '        "VALUES('" & DETAILUID & "','" & TransactionUID & "','" & ListArray(0) & "','" & ReplacePetik(ListArray(2)) & "','" & ReplacePetik(ListArray(11)) & "','" & Replace(ListArray(1), ",", ".") & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ReplacePetik(ListArray(5)) & "','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1)"
            'Call MyDatabase.MyAdapter(Query)
            If InStr(ListArray(2), vbNewLine & "   +") <> 0 Then
              Dim arrItem() As String = Split(ListArray(2), vbNewLine & "   +")
              nmItem = arrItem(0)
              listNote = Replace(Replace(ListArray(2), nmItem & vbNewLine & "   +", ""), vbNewLine & "   +", MY_SUB_DELIMITER)
            Else
              nmItem = ListArray(2)
            End If
            If Trim(ListArray(14)) = "" Then
              MyDatabase.MyAdapter("INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT,MBTRANSDTLISTNOTE,MBTRANSDTLISTNOTEUID) " & _
                      "VALUES('" & IIf(Trim(ListArray(13)) = "", DETAILUID, ListArray(13)) & "','" & TransactionUID & "','" & ListArray(0) & "','" & ReplacePetik(IIf(Mid(Trim(nmItem), 1, 1) = "+", Mid(Trim(nmItem), 2), Trim(nmItem))) & "','" & ReplacePetik(ListArray(11)) & "','" & ListArray(1) & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ReplacePetik(ListArray(5)) & "','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1,'" & ReplacePetik(listNote) & "','" & ReplacePetik(ListArray(12)) & "')")
              tmpJml = ListArray(1)
            Else
              MyDatabase.MyAdapter("INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT,MBTRANSDTPARENTUID,MBTRANSDTLISTNOTE,MBTRANSDTLISTNOTEUID) " & _
                                  "VALUES('" & IIf(Trim(ListArray(13)) = "", DETAILUID, ListArray(13)) & "','" & TransactionUID & "','" & ListArray(0) & "','" & ReplacePetik(IIf(Mid(Trim(nmItem), 1, 1) = "+", Mid(Trim(nmItem), 2), Trim(nmItem))) & "','" & ReplacePetik(ListArray(11)) & "','" & tmpJml & "','0','0','','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1,'" & ListArray(14) & "',NULL,NULL)")
            End If
            listNote = ""
            'Anjo 12 Okt 2011 : Paket detail is done via trigger
            'If CInt(ListArray(10)) = 3 Then
            '    Dim ItemDetail As FbDataReader
            '    ItemDetail = MyDatabase.MyReader("SELECT DT.*,I.INVENNAME  FROM INVENDT DT LEFT OUTER JOIN INVEN I ON DT.INVENDTITEMUID = I.INVENUID WHERE DT.INVENUID='" & ListArray(0) & "'")
            '    While ItemDetail.Read
            '        Query = "INSERT INTO MBTRANSDTDETAIL (MBTRANSDTDETAILUID,MBTRANSDTUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTITEMSTAT,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME) " & _
            '        "VALUES('" & AutoUID() & "','" & DETAILUID & "','" & ItemDetail("INVENDTITEMUID") & "','" & ItemDetail("INVENNAME") & "','" & ItemDetail("ITEMMEASUNITDESC") & "','" & ItemDetail("ITEMQTY") * ListArray(1) & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ListArray(5) & "','0','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "')"
            '        Call MyDatabase.MyAdapter(Query)
            '    End While
            'End If

          End If
        Else
          ''Insert New Detail
          Dim DETAILUID As String = AutoUID()
          Dim ListArray As New ArrayList
          ListArray = NEWOrderListCollection(i)
          'Susilo, 7 Agustus 2014. Dirubah karena ada item modifier
          'ShowMessage(Me,"INSERT " & OrderDetail.Item(i, 3))
          'Query = "INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT) " & _
          '        "VALUES('" & DETAILUID & "','" & TransactionUID & "','" & ListArray(0) & "','" & ReplacePetik(ListArray(2)) & "','" & ReplacePetik(ListArray(11)) & "','" & Replace(ListArray(1), ",", ".") & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ReplacePetik(ListArray(5)) & "','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1)"
          'Call MyDatabase.MyAdapter(Query)
          If InStr(ListArray(2), vbNewLine & "   +") <> 0 Then
            Dim arrItem() As String = Split(ListArray(2), vbNewLine & "   +")
            nmItem = arrItem(0)
            listNote = Replace(Replace(ListArray(2), nmItem & vbNewLine & "   +", ""), vbNewLine & "   +", MY_SUB_DELIMITER)
          Else
            nmItem = ListArray(2)
          End If
          'ListArray(13)
          If Trim(ListArray(14)) = "" Then
            MyDatabase.MyAdapter("INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT,MBTRANSDTLISTNOTE,MBTRANSDTLISTNOTEUID) " & _
                    "VALUES('" & IIf(Trim(ListArray(13)) = "", DETAILUID, ListArray(13)) & "','" & TransactionUID & "','" & ListArray(0) & "','" & ReplacePetik(IIf(Mid(Trim(nmItem), 1, 1) = "+", Mid(Trim(nmItem), 2), Trim(nmItem))) & "','" & ReplacePetik(ListArray(11)) & "','" & ListArray(1) & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ReplacePetik(ListArray(5)) & "','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1,'" & ReplacePetik(listNote) & "','" & ReplacePetik(ListArray(12)) & "')")
            tmpJml = ListArray(1)
          Else
            MyDatabase.MyAdapter("INSERT INTO MBTRANSDT (MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,PRINT,MBTRANSDTPARENTUID,MBTRANSDTLISTNOTE,MBTRANSDTLISTNOTEUID) " & _
                                "VALUES('" & IIf(Trim(ListArray(13)) = "", DETAILUID, ListArray(13)) & "','" & TransactionUID & "','" & ListArray(0) & "','" & ReplacePetik(IIf(Mid(Trim(nmItem), 1, 1) = "+", Mid(Trim(nmItem), 2), Trim(nmItem))) & "','" & ReplacePetik(ListArray(11)) & "','" & tmpJml & "','0','0','','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "',1,'" & ListArray(14) & "',NULL,NULL)")
          End If
          listNote = ""
          'Anjo : 12 okt 2011 : Detail paket is done via trigger
          'If CInt(ListArray(10)) = 3 Then
          '    Dim ItemDetail As FbDataReader
          '    ItemDetail = MyDatabase.MyReader("SELECT DT.*,I.INVENNAME  FROM INVENDT DT LEFT OUTER JOIN INVEN I ON DT.INVENDTITEMUID = I.INVENUID WHERE DT.INVENUID='" & ListArray(0) & "'")
          '    While ItemDetail.Read
          '        Query = "INSERT INTO MBTRANSDTDETAIL (MBTRANSDTDETAILUID,MBTRANSDTUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTITEMSTAT,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME) " & _
          '        "VALUES('" & AutoUID() & "','" & DETAILUID & "','" & ItemDetail("INVENDTITEMUID") & "','" & ItemDetail("INVENNAME") & "','" & ItemDetail("ITEMMEASUNITDESC") & "','" & ItemDetail("ITEMQTY") * ListArray(1) & "','" & ListArray(3) & "','" & ListArray(3) * ListArray(1) & "','" & ListArray(5) & "','0','" & IIf(ListArray(7) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "')"
          '        Call MyDatabase.MyAdapter(Query)
          '    End While
          'End If

        End If
      End While
      RecordItem = Nothing
    Next
  End Sub
  Private Sub DeleteItemMB(ByVal InputMBTransUID As String)
    Dim RecordItem As FbDataReader
    Dim ArrayItem() As String
    Dim Delete As String = ""
    Const MY_DELIMITER = "~%^%$#$~"

    'Temukan Item Yang Ada Di DB Tapi Tidak Ada Di FlexGrid 
    RecordItem = MyDatabase.MyReader("SELECT * FROM MBTRANSDT WHERE MBTRANSUID = '" & InputMBTransUID & "'")
    While RecordItem.Read
      If ItemExistInGrid(RecordItem.Item("MBTRANSDTUID")) = False Then Delete = Delete & MY_DELIMITER & RecordItem.Item("MBTRANSDTUID")
    End While
    RecordItem = Nothing

    'Hapus Item Yang Ada Di DB Tapi Tidak Ada Di FlexGrid
    If Len(Trim(Delete)) > 0 Then
      ArrayItem = Split(Delete, MY_DELIMITER)
      For i As Integer = 0 To UBound(ArrayItem)
        If Len(Trim(CStr(ArrayItem(i)))) > 0 Then
          'ShowMessage(Me,"DELETE " & ArrayItem(i))
          MyDatabase.MyAdapter("DELETE FROM MBTRANSDT WHERE MBTRANSDTUID = '" & CStr(ArrayItem(i)) & "'")
        End If
      Next
    End If
  End Sub
  Private Function ItemExistInGrid(ByVal InputMBTransDTUID As String) As Boolean

    Dim R As Boolean = False
    Dim i As Integer

    With OrderDetail
      For i = 1 To .Rows.Count - 1
        If Trim(.Item(i, 0)) = Trim(InputMBTransDTUID) Then R = True
      Next
    End With

    ItemExistInGrid = R

  End Function
  Private Sub LockFormMakeOrder()
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

    If UserPermition.PrintAccess Then
      BTNPrint.Enabled = True
      BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Blue
    Else
      BTNPrint.Enabled = False
      BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Silver
    End If
    BTNList.Enabled = True
    BTNList.VisualStyle = C1Input.VisualStyle.Office2007Blue
    BTNClose.Enabled = True
    BTNClose.VisualStyle = C1Input.VisualStyle.Office2007Blue

  End Sub
#End Region

#Region "Form Control Function"

  Private Sub Form_Make_Order_Image_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyDown

  End Sub

  Private Sub Form_Make_Order_Image_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Me.KeyPress
    If txtBarcode.Visible = False Then Exit Sub
    If Char.IsLetterOrDigit(e.KeyChar) Then
      e.Handled = True
      txtBarcode.Text = e.KeyChar
      txtBarcode.Focus()
    Else
      e.Handled = False
    End If
  End Sub

  Private Sub Form_Make_Order_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
    If PrefInfo.UseBarcode = "0" Then OrderDetail.Height = 544 : txtBarcode.Visible = False Else OrderDetail.Height = 503 : txtBarcode.Visible = True
    Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 44)
    Me.Text = "Make Order - Table " & SelectedTable.TableName

    OrderDetail.Styles("Normal").WordWrap = True
    Call BasicInitialize()

    If EditStatus = True Then
      Call LockFormMakeOrder()

      BTNPrint.Enabled = False
      BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Silver
      BTNList.Enabled = False
      BTNList.VisualStyle = C1Input.VisualStyle.Office2007Silver
      BTNSave.Enabled = False
      BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver
      BTNTakeAway.Enabled = False
      BTNTakeAway.VisualStyle = C1Input.VisualStyle.Office2007Silver
      BTNNotes.Enabled = False
      BTNNotes.VisualStyle = C1Input.VisualStyle.Office2007Silver
      BTNMoveUp.Enabled = True
      BTNMoveUp.VisualStyle = C1Input.VisualStyle.Office2007Blue
      BTNMoveDown.Enabled = True
      BTNMoveDown.VisualStyle = C1Input.VisualStyle.Office2007Blue
      BTNReset.Enabled = False
      BTNReset.VisualStyle = C1Input.VisualStyle.Office2007Silver
    End If

    BTNPrint.Enabled = False
    BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Silver
    BTNList.Enabled = False
    BTNList.VisualStyle = C1Input.VisualStyle.Office2007Silver

  End Sub

  Private Sub BTNNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNNotes.Click
    'If ApakahMejaKosong() = True Then
    '    Exit Sub
    'End If
    'If ApakahMejaSudahBilling() = True Then
    '    Exit Sub
    'End If

    With OrderDetail
      If .Rows.Count > 1 Then
        If .Rows(.Row).Height = 25 Then Exit Sub
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

  Private Sub BTNPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPrint.Click

    If Authorize = True Then
      Authorize = False
      UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
      Call MainPage.StatusBarInitialize()
    End If

    Me.Cursor = Cursors.WaitCursor
    If PrefInfo.PrintMakeOrder.ToString = "1" Then
      For i As Integer = 1 To CInt(PrefInfo.pubJumlahPrintOut)
        Call ShowPrintPreview(True)
        Application.DoEvents()
      Next
    End If
    If PrefInfo.UseKitchenPrintOut = "1" Then
      Call toPrint()
    End If

    Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET PRINT=0 WHERE MBTRANSUID ='" & TransactionUID & "'")
    BTNPrint.Enabled = False
    BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Silver
    Me.Cursor = Cursors.Default

  End Sub

  Private Sub toPrint()
    Dim rs As FbDataReader, selPrinterName As String = ""
    rs = MyDatabase.MyReader("SELECT DISTINCT(INVENKITCHENUID) AS KodeKitchen FROM INVEN A INNER JOIN " & _
                            "(SELECT IIF(B.MBTRANSDTITEMUID IS NULL,A.MBTRANSDTITEMUID,B.MBTRANSDTITEMUID) AS KodeBarang FROM MBTRANSDT A LEFT JOIN MBTRANSDTDETAIL B ON A.MBTRANSDTUID=B.MBTRANSDTUID WHERE A.PRINT=1 AND MBTRANSUID='" & TransactionUID & "') B " & _
                            "ON A.INVENUID=B.KodeBarang")
    While rs.Read = True
      selPrinterName = GetPrinterName(rs("KodeKitchen"))
      If Len(Trim(selPrinterName)) > 0 Then
        If KitchenSplitOrder = "0" Then
          Make_Order.pubHarusCetakNotes = True
          Make_Order.pubQueryLap = "SELECT B.* FROM INVEN A INNER JOIN " & _
                                  "(" & _
                                  "SELECT a.MBTRANSDTISTAKEAWAY, a.MBTRANSDTITEMNOTE, a.MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang, a.MBTRANSDTITEMNAME," & _
                                  "IIF(MBTRANSDTPARENTUID IS NULL, a.MBTRANSDTITEMNAME||ASCII_CHAR(13)||IIF(MBTRANSDTLISTNOTE IS NULL OR TRIM(MBTRANSDTLISTNOTE)='','','+'||REPLACE(a.MBTRANSDTLISTNOTE,'^#@$^',ASCII_CHAR(13)||'+')),(SELECT dtMod.MBTRANSDTITEMNAME||' -> + ' FROM MBTRANSDT dtMod WHERE dtMod.MBTRANSDTUID=a.MBTRANSDTPARENTUID)||a.MBTRANSDTITEMNAME) AS MBTRANSDTITEMLISTNOTE," & _
                                  "a.MBTRANSDTITEMQTY,b.MBTRANSDTITEMNAME AS DETAILITEM,b.MBTRANSDTITEMQTY AS DETAILQTY " & _
                                  "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
                                  "WHERE MBTRANSUID ='" & TransactionUID & "' AND a.PRINT=1 " & _
                                  ") B ON A.INVENUID=B.KodeBarang WHERE INVENKITCHENUID='" & Trim(rs("KodeKitchen")) & "'"
          'selPrinterName = GetPrinterName(rs("KodeKitchen"))

          'If Len(Trim(selPrinterName)) > 0 Then
          Call ShowPrintPreview(True, selPrinterName)
        Else
          Dim rs2 As FbDataReader = MyDatabase.MyReader("SELECT B.MBTRANSDTUID,B.MBTRANSDTITEMQTY FROM INVEN A INNER JOIN " & _
                                  "(" & _
                                  "SELECT a.MBTRANSDTISTAKEAWAY, a.MBTRANSDTITEMNOTE,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTUID,b.MBTRANSDTDETAILUID) AS MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang,a.MBTRANSDTITEMQTY,b.MBTRANSDTITEMNAME AS DETAILITEM,b.MBTRANSDTITEMQTY AS DETAILQTY " & _
                                  "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
                                  "WHERE MBTRANSUID ='" & TransactionUID & "' AND a.PRINT=1 " & _
                                  ") B ON A.INVENUID=B.KodeBarang WHERE INVENKITCHENUID='" & Trim(rs("KodeKitchen")) & "'")
          While rs2.Read = True
            For i As Integer = 1 To CInt(rs2("MBTRANSDTITEMQTY"))
              Make_Order_Split.pubHarusCetakNotes = True
              Make_Order_Split.pubQueryLap = "SELECT B.* FROM INVEN A INNER JOIN " & _
                                      "(" & _
                                      "SELECT a.MBTRANSDTISTAKEAWAY, a.MBTRANSDTITEMNOTE,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTUID,b.MBTRANSDTDETAILUID) AS MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang, IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMNAME,a.MBTRANSDTITEMNAME || ' - ' || b.MBTRANSDTITEMNAME) AS MBTRANSDTITEMNAME, a.MBTRANSDTITEMQTY,b.MBTRANSDTITEMNAME AS DETAILITEM,b.MBTRANSDTITEMQTY AS DETAILQTY " & _
                                      "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
                                      "WHERE MBTRANSUID ='" & TransactionUID & "' AND a.PRINT=1 " & _
                                      ") B ON A.INVENUID=B.KodeBarang WHERE B.MBTRANSDTUID='" & Trim(rs2("MBTRANSDTUID")) & "'"
              Call ShowPrintPreviewSplit(True, selPrinterName)
            Next
          End While
          rs2 = Nothing
        End If
      End If
    End While
    rs = Nothing
  End Sub

  Private Function GetPrinterName(ByVal idKitchen As String) As String
    GetPrinterName = ""
    Dim rs As FbDataReader
    rs = MyDatabase.MyReader("SELECT * FROM KITCHEN WHERE KITCHENUID='" & ReplacePetik(idKitchen) & "'")
    While rs.Read = True
      If IsDBNull(rs("KITCHENSPLITORDER")) = True Then
        KitchenSplitOrder = "0"
      Else
        KitchenSplitOrder = rs("KITCHENSPLITORDER").ToString
      End If
      If IsDBNull(rs("KITCHENPRINTER")) = False Then
        GetPrinterName = rs("KITCHENPRINTER")
      Else
        GetPrinterName = ""
      End If
    End While
    rs = Nothing
  End Function

  Private Sub BTNList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNList.Click
    If Authorize = True Then
      Authorize = False
      UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
      Call MainPage.StatusBarInitialize()
    End If

    'Anjo-29Okt , untuk melihat order list tidak perlu check di bawah ini
    'If ApakahMejaKosong() = True Then
    '    Exit Sub
    'End If
    'If ApakahMejaSudahBilling() = True Then
    '    Exit Sub
    'End If

    Dim OBJNew As New Form_Make_Order_List
    OBJNew.Name = "Form_Make_Order_List"
    OBJNew.ParentOBJForm = Me
    OBJNew.ShowDialog()
  End Sub

  Private Sub BTNReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNReset.Click

    If Authorize = True Then
      Authorize = False
      UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
      Call MainPage.StatusBarInitialize()
    End If

    'Anjo 29Okt, tidak perlu implement dibawah ini, karena tombol reset hanya aktif untuk order baru saja
    'dan untuk order baru, checking meja kosong dan billing cukup dilakukan pada saat save
    'If ApakahMejaKosong() = True Then
    '    Exit Sub
    'End If
    'If ApakahMejaSudahBilling() = True Then
    '    Exit Sub
    'End If

    If ShowQuestion(Me, "Hapus semua order pesanan ?") = True Then
      'For i As Integer = 1 To OrderDetail.Rows.Count - 1
      '    If Not IsNothing(OrderDetail.Item(i, 9)) Then
      '        ' UIDtoRemove.Add(OrderDetail.Item(i, 9))
      '    End If
      'Next

      OrderDetail.Rows.Count = 1
      Call ReInitializePrice()
    End If
  End Sub
  Private Function ApakahMejaSudahBilling() As Boolean
    Dim TMPHeader As FbDataReader
    TMPHeader = MyDatabase.MyReader("SELECT * FROM MBTrans WHERE MBTransUID = '" & TransactionUID & "'")
    TMPHeader.Read()
    If Not IsDBNull(TMPHeader.Item("ISBILLED")) Then
      If TMPHeader.Item("ISBILLED") = 1 Then
        ShowMessage(Me, "Maaf, anda tidak dapat merubah/menambah order pesanan, karena transaksi ini sudah dibuatkan bill tagihan !" & vbNewLine & "Silakan hubungi manager anda !")
        Return True
      End If
    End If
  End Function
  Private Function ApakahMejaKosong() As Boolean
    Dim TMPCheckTable As FbDataReader
    TMPCheckTable = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLELISTUID = '" & SelectedTable.TableUID & "'")
    While TMPCheckTable.Read
      If IsDBNull(TMPCheckTable.Item("TABLEMBTRANSUID")) Then
        ShowMessage(Me, "Maaf, anda tidak dapat merubah order pesanan, karena status meja '" & SelectedTable.TableName & "' adalah kosong (tidak ada customer check in) !")
        Return True
      End If
    End While
  End Function
  Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click

    If Authorize = True Then
      Authorize = False
      UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
      Call MainPage.StatusBarInitialize()
    End If

    If ApakahMejaKosong() = True Then Exit Sub
    If ApakahMejaSudahBilling() = True Then Exit Sub

    Me.Cursor = Cursors.WaitCursor
    If OrderDetail.Rows.Count > 1 Then
      'Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MBTRANSSUBVAL = '" & CDec(SubTotalTxt.Text) & "',MBTRANSMODULETYPEID='2203' WHERE MBTRANSUID LIKE '" & TransactionUID & "'")
      Call MyDatabase.MyAdapter("UPDATE MBTRANS SET MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTRANSUID LIKE '" & TransactionUID & "'")
      Call LockFormMakeOrder()
      OrderDetail.Enabled = False

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

      'Dim ItemRecord As FbDataReader
      Dim CountRecord As FbDataReader
      'Dim RecordItem As FbDataReader

      CountRecord = MyDatabase.MyReader("SELECT COUNT (*) FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "'")
      While CountRecord.Read
        If CInt(CountRecord.Item(0)) = 0 Then
          Call SimpanDetailNewMB()
        Else
          'Anjo : 14Okt 2012 : DeleteItemMB originally memang dicomment, jadi dikembalikan asal spt coding dian
          'DeleteItemMB(TransactionUID)
          Call SimpanDetailExistingMB(TransactionUID)
        End If
      End While
      CountRecord = Nothing
      'RecordItem = Nothing
      'ItemRecord = Nothing
    Else
      Me.Cursor = Cursors.Default
      ShowMessage(Me, "Transaksi tidak dapat disimpan, karena tidak ada order pesanan dalam daftar !")
      Exit Sub
    End If


    Call BTNPrint_Click(sender, e)
    Me.Cursor = Cursors.Default
    If PrefInfo.PrintMakeOrder = 1 Then
      Me.Close()
    End If

    Call MainPage.TableClickInfo(selectedObject, myEvent)
    Me.Cursor = Cursors.Default

  End Sub

  Private Sub BTNClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClose.Click
    Dim Query As String = Nothing

    If Authorize = True Then
      Authorize = False
      UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
      Call MainPage.StatusBarInitialize()
    End If

    'Anjo - 29Okt, tidak tau apa gunanya
    'Query = "UPDATE MBTRANSDT SET PRINT=0 WHERE MBTRANSUID ='" & TransactionUID & "'"
    'Call MyDatabase.MyAdapter(Query)

    Call MainPage.TableClickInfo(selectedObject, myEvent)
    Me.Close()
  End Sub
#End Region

  Public Sub New()

    ' This call is required by the Windows Form Designer.
    InitializeComponent()

    ' Add any initialization after the InitializeComponent() call.

  End Sub

  Private Sub OrderDetail_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles OrderDetail.DoubleClick
    If OrderDetail.Rows(OrderDetail.Row).Height = 25 Then Exit Sub
    With OrderDetail
      Dim tmpRow As Integer = .Row
      Dim tmpID As String = (.Item(.Row, "id"))
      Dim rs As FbDataReader
      rs = MyDatabase.MyReader("SELECT INVENPARENTUID,A.INVENUID,INVENNAME,INVENMEASUNITDESC,INVENSIZE,(SELECT COUNT(D.INVENUID) FROM INVENITEMMOD D WHERE D.INVENUID=A.INVENUID) AS jmlModItem FROM INVEN A INNER JOIN INVENPRICELIST C ON A.INVENUID=C.INVENUID WHERE A.INVENUID='" & .Item(.Row, 1) & "'")
      While rs.Read = True
        If IsDBNull(rs("INVENPARENTUID")) = False Or CLng(rs("jmlModItem")) > 0 Then
          Me.Cursor = Cursors.WaitCursor
          If IsDBNull(rs("INVENPARENTUID")) = False Then
            Form_Detail_Menu.idBarang = rs("INVENPARENTUID")
          Else
            Form_Detail_Menu.idBarang = rs("INVENUID")
          End If
          Form_Detail_Menu.nmMenu = rs("INVENNAME")
          Form_Detail_Menu.meas = rs("INVENMEASUNITDESC")
          Dim tmpItem As String = ""
          For i As Integer = 1 To .Rows.Count - 1
            '15 idParent
            If .Item(i, 15) = tmpID Then
              tmpItem = tmpItem & vbNewLine & "   +" & Trim(.Item(i, 3))
            End If
          Next
          Form_Detail_Menu.itemEdit = .Item(.Row, 3) & tmpItem
          If IsDBNull(rs("INVENSIZE")) = False Then
            Form_Detail_Menu.ukuran = rs("INVENSIZE")
          Else
            Form_Detail_Menu.ukuran = ""
          End If
          Form_Detail_Menu.idSML = rs("INVENUID")
          Form_Detail_Menu.idDetailSML = .Item(.Row, 13)
          Form_Detail_Menu.jmlItem = .Item(.Row, 2)
          Form_Detail_Menu.harga = .Item(.Row, 4)
          Form_Detail_Menu.ShowDialog()
          If Form_Detail_Menu.dftItem <> "" Then
            For i As Integer = .Rows.Count - 1 To 1 Step -1
              If .Item(i, 15) = tmpID Then
                .RemoveItem(i)
              End If
            Next
            .RemoveItem(tmpRow)
            .AddItem(Form_Detail_Menu.dftItem & vbTab & tmpID & vbTab & "", tmpRow)
            '.Item(tmpRow, 1) = tmpID
            Dim arrData() As String
            arrData = Split(Form_Detail_Menu.dftItem, vbTab)
            If Form_Detail_Menu.jmlRow > 2 Then
              .Rows(tmpRow).Height = 45 + (10 * Form_Detail_Menu.jmlRow - 2)
            Else
              .Rows(tmpRow).Height = 45
            End If
            Dim arrBarang() As String = Split(arrData(UBound(arrData)), MY_DELIMITER)
            Dim cR As CellRange
            Dim cs As CellStyle
            cs = .Styles.Add("string")
            cs.DataType = Type.GetType("System.String")
            For i As Integer = 0 To UBound(arrBarang) - 1
              Dim arrDetailBarang() As String = Split(arrBarang(i), MY_SUB_DELIMITER)
              If Trim(arrDetailBarang(3)) <> "-" Then
                Dim tmpIdDetail As String = AutoUID()
                tmpRow += 1
                .AddItem(vbTab & arrDetailBarang(3) & vbTab & "-" & vbTab & "   +" & Trim(arrDetailBarang(4)) & vbTab & " " & vbTab & " " & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "2" & vbTab & arrDetailBarang(5) & vbTab & "" & vbTab & tmpIdDetail & vbTab & tmpID, tmpRow)
                .Rows(tmpRow).Height = 25
                cR = .GetCellRange(.Rows.Count - 1, 7)
                cR.Style = .Styles("string")
                cR = .GetCellRange(.Rows.Count - 1, 8)
                cR.Style = .Styles("string")
              End If
            Next
          End If
          Form_Detail_Menu.Close()
          Call ReInitializePrice()
          Me.Cursor = Cursors.Default
        End If
      End While
      rs = Nothing
    End With
  End Sub

  Private Sub OrderDetail_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles OrderDetail.MouseDown
    If OrderDetail.Rows.Count > 1 Then
      tmrPopUp.Enabled = True
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
        Call LockFormMakeOrder()

        BTNPrint.Enabled = False
        BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Silver
        BTNList.Enabled = False
        BTNList.VisualStyle = C1Input.VisualStyle.Office2007Silver
        BTNMoveUp.Enabled = True
        BTNMoveUp.VisualStyle = C1Input.VisualStyle.Office2007Blue
        BTNMoveDown.Enabled = True
        BTNMoveDown.VisualStyle = C1Input.VisualStyle.Office2007Blue
        BTNReset.Enabled = False
        BTNReset.VisualStyle = C1Input.VisualStyle.Office2007Silver
      Else
        If BackItem.Enabled = False And NextItem.Enabled = False And BackCategory.Enabled = False And NextCategory.Enabled = False Then
          For Each OBJ As Object In Me.Controls
            If TypeOf OBJ Is GroupBox Then
              For Each CTR As Object In OBJ.Controls
                If TypeOf CTR Is C1Input.C1Button Then
                  If CTR.Text = "-" Then
                    'CTR.Enabled = False
                    'CTR.VisualStyle = C1Input.VisualStyle.Office2007Silver
                    CTR.enabled = True
                    CTR.VisualStyle = C1Input.VisualStyle.Office2007Blue
                  Else
                    If CTR.text = "Remove" Then
                      If UserPermition.DeleteAccess = True Then
                        BTNRemove.Enabled = True
                        BTNRemove.VisualStyle = C1Input.VisualStyle.Office2007Blue
                      ElseIf UserPermition.DeleteAccess = False Then
                        BTNRemove.Enabled = False
                        BTNRemove.VisualStyle = C1Input.VisualStyle.Office2007Silver
                      End If
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

          BTNPrint.Enabled = False
          BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Silver
          BTNList.Enabled = False
          BTNList.VisualStyle = C1Input.VisualStyle.Office2007Silver
          BTNReset.Enabled = False
          BTNReset.VisualStyle = C1Input.VisualStyle.Office2007Silver

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

  Private Sub OrderDetail_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OrderDetail.Click

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
          tmpSetting = "YES" & MY_DELIMITER & "NO"
          tmpEditable = OrderDetail.Item(curRow, 3).ToString & MY_DELIMITER & OrderDetail.Item(curRow, 4).ToString & MY_DELIMITER & OrderDetail.Item(curRow, 1).ToString '& MY_DELIMITER & OrderDetail.Item(curRow, 7).ToString
        Else
          tmpSetting = "NO" & MY_DELIMITER & "NO"
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

  Private Sub OrderDetail_MouseUp(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles OrderDetail.MouseUp
    hitungPopUP = 0
    tmrPopUp.Enabled = False
  End Sub
End Class