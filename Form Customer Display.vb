Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win
Imports C1.Win.C1FlexGrid
Imports System.IO
Imports System.IO.Path

Public Class Form_Custm_Display_MakeBill

  Dim uLang As Integer = 1
  Dim Flash As Integer = 1
  Dim Picture As Integer = 1
  Dim SlideOK As Boolean = False
  Public VarContoh As String = ""
  Dim OrderListCollection As New Collection
  Dim MoveAlong As Integer = 1

  Private Sub Timer1_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerCustDisplay.Tick
    Dim arrayitem() As String
    Dim ItemArray() As String
    Dim HitKemb As Integer = 0


    If IdFromInvoiceList.Text <> "" Then
      'MessageBox.Show("a")
      If OrderDetail.Rows.Count > 1 Then
        Call ReInitializePrice()

      End If
      If ItemMixFormCustomerDisplay <> "" Then
        arrayitem = ItemMixFormCustomerDisplay.Split("?")

        With OrderDetail
          If .Rows.Count <= 1 Then
            If arrayitem(4) = "mod" Then

              If CheckDoubleEntryforMod(arrayitem(6)) Then
                Exit Sub
              Else
                .AddItem(arrayitem(0) & vbTab & arrayitem(1) & vbTab & arrayitem(2) & vbTab & arrayitem(5) & vbTab & arrayitem(3) & vbTab & arrayitem(6))
                .Row = .Rows.Count - 1
                'MessageBox.Show(arrayitem(5))
              End If
            Else
              .AddItem(arrayitem(0) & vbTab & arrayitem(1) & vbTab & arrayitem(2) & vbTab & arrayitem(5) & vbTab & arrayitem(3) & vbTab & arrayitem(6))
              .Row = .Rows.Count - 1
            End If
          ElseIf .Rows.Count > 1 Then
            If arrayitem(4) = "add" Then
              If CheckDoubleEntry(arrayitem(0)) Then
                Exit Sub
              Else
                .AddItem(arrayitem(0) & vbTab & arrayitem(1) & vbTab & arrayitem(2) & vbTab & arrayitem(5) & vbTab & arrayitem(3) & vbTab & arrayitem(6))
                .Row = .Rows.Count - 1
              End If
            ElseIf arrayitem(4) = "plus" Then
              For ChekGanti As Integer = 1 To .Rows.Count - 1
                If arrayitem(0) = .Item(ChekGanti, 0) Then
                  .Item(ChekGanti, 1) = arrayitem(1)
                  .Item(ChekGanti, 4) = arrayitem(3)
                  .Row = ChekGanti
                End If
              Next
            ElseIf arrayitem(4) = "mod" Then

              If CheckDoubleEntryforMod(arrayitem(6)) Then
                Exit Sub
              Else
                .AddItem(arrayitem(0) & vbTab & arrayitem(1) & vbTab & arrayitem(2) & vbTab & arrayitem(5) & vbTab & arrayitem(3) & vbTab & arrayitem(6))
                .Row = .Rows.Count - 1
              End If
            End If
          End If
        End With
      End If

      Call GetDTOrder(IdFromInvoiceList.Text)
      Dim CurrentRecord As New ArrayList

      With OrderDetail
        '.Redraw = False
        If Not IsNothing(OrderListCollection) Then
          For i As Integer = 1 To OrderListCollection.Count
            CurrentRecord = OrderListCollection(i)
            If CheckDoubleEntry(CurrentRecord(0)) Then
              Exit Sub
            Else
              .AddItem(CurrentRecord(0) & vbTab & CurrentRecord(1) & vbTab & CurrentRecord(2) & vbTab & "" & vbTab & CurrentRecord(3) & vbTab & "")
              '.Row = .Rows.Count - 1

            End If
          Next
          
          'If Form_Invoice_Image.EditStatus = True Then
          '  MessageBox.Show("show")
          'End If

        End If

        '.Redraw = True

      End With


    Else
      If ItemMixFormCustomerDisplay <> "" Then
        arrayitem = ItemMixFormCustomerDisplay.Split("?")

        With OrderDetail
          If .Rows.Count <= 1 Then
            If arrayitem(4) = "mod" Then

              If CheckDoubleEntryforMod(arrayitem(6)) Then
                Exit Sub
              Else
                .AddItem(arrayitem(0) & vbTab & arrayitem(1) & vbTab & arrayitem(2) & vbTab & arrayitem(5) & vbTab & arrayitem(3) & vbTab & arrayitem(6))
                .Row = .Rows.Count - 1
                'MessageBox.Show(arrayitem(5))
              End If
            Else
              .AddItem(arrayitem(0) & vbTab & arrayitem(1) & vbTab & arrayitem(2) & vbTab & arrayitem(5) & vbTab & arrayitem(3) & vbTab & arrayitem(6))
              .Row = .Rows.Count - 1
            End If
          ElseIf .Rows.Count > 1 Then
            If arrayitem(4) = "add" Then
              If CheckDoubleEntry(arrayitem(0)) Then
                Exit Sub
              Else
                .AddItem(arrayitem(0) & vbTab & arrayitem(1) & vbTab & arrayitem(2) & vbTab & arrayitem(5) & vbTab & arrayitem(3) & vbTab & arrayitem(6))
                .Row = .Rows.Count - 1
              End If
            ElseIf arrayitem(4) = "plus" Then
              For ChekGanti As Integer = 1 To .Rows.Count - 1
                If arrayitem(0) = .Item(ChekGanti, 0) Then
                  .Item(ChekGanti, 1) = arrayitem(1)
                  .Item(ChekGanti, 4) = arrayitem(3)
                  .Row = ChekGanti
                End If
              Next
            ElseIf arrayitem(4) = "mod" Then

              If CheckDoubleEntryforMod(arrayitem(6)) Then
                Exit Sub
              Else
                .AddItem(arrayitem(0) & vbTab & arrayitem(1) & vbTab & arrayitem(2) & vbTab & arrayitem(5) & vbTab & arrayitem(3) & vbTab & arrayitem(6))
                .Row = .Rows.Count - 1
              End If
            End If
          End If
        End With
      End If
    End If

    If OrderDetail.Rows.Count > 1 Then
      Call ReInitializePrice()

    End If
  


  End Sub
  Private Sub MakeBillSection()
    Dim DiscVal As Decimal = 0
    DiscVal = DiscountFromMakeBillFCDP
    Me.Text = FoundMakeBillForm
    LblDiscountVal.Text = FormatNumber(DiscVal, 0)
  End Sub

  Private Function CheckDoubleEntry(ByVal UIDItem As String) As Boolean
    Dim counter As Integer, returnFunc As Boolean = False
    With OrderDetail
      For counter = 1 To .Rows.Count - 1
        If .Item(counter, 0) = UIDItem Then returnFunc = True : Exit For
      Next
    End With
    CheckDoubleEntry = returnFunc
  End Function
  Private Function CheckDoubleEntryforMod(ByVal UIDItem As String) As Boolean
    Dim counter As Integer, returnFunc As Boolean = False
    'Dim arrayitemPartTw() As String
    With OrderDetail
      For counter = 1 To .Rows.Count - 1
        If .Item(counter, 5) = UIDItem Then returnFunc = True : Exit For
      Next
    End With
    CheckDoubleEntryforMod = returnFunc
  End Function
  Private Sub ReInitializePrice()

    Dim CurrentDisc As Double = 0
    Dim totalItem As Decimal = 0

    With OrderDetail
      If .Rows.Count > 1 Then
        Dim ReTotal As Double = 0
        For i As Integer = 1 To .Rows.Count - 1
          ReTotal = ReTotal + .Item(i, 4)
          totalItem = totalItem + .Item(i, 1)
        Next
        SubTotalTxt.Text = FormatNumber(ReTotal, 0)
        If InStr(totalItem.ToString, ",") > 0 Then
          lblTotalItem.Text = FormatNumber(totalItem, 1)
        Else
          lblTotalItem.Text = FormatNumber(totalItem, 0)
        End If
      Else
        SubTotalTxt.Text = "0"
        lblTotalItem.Text = "0"
      End If
    End With

  End Sub
  Public Sub closeThisform()
    Me.Close()
  End Sub

  Private Sub Form_Custm_Display_MakeBill_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

    OrderDetail.Styles("Normal").WordWrap = True
    If GetSetting("Smart Pos", "Setting", "Interval Picture Customer Display") <= 0 Then
      TimerPicture.Interval = 1000
    Else
      TimerPicture.Interval = 1000 * CInt(GetSetting("Smart Pos", "Setting", "Interval Picture Customer Display"))
    End If

    'Me.Text = ""
    'PictureBox1.Image = My.Resources.Prime_Resto_1
  End Sub

  Private Sub TimerPicture_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles TimerPicture.Tick
    
    If GetSetting("Smart Pos", "Setting", "Path Picture Customer Display") <> "" Then
      For Each listFiles As String In Directory.GetFiles(GetSetting("Smart Pos", "Setting", "Path Picture Customer Display"))
        ListPictureCustDispl.Items.Add(listFiles)
      Next
    End If
    If ListPictureCustDispl.Items.Count <= 0 Then Exit Sub
    If ListPictureCustDispl.SelectedIndex < ListPictureCustDispl.Items.Count - 1 Then
      ListPictureCustDispl.SetSelected(ListPictureCustDispl.SelectedIndex + 1, True)
      PictureBox1.Image = Image.FromFile(ListPictureCustDispl.SelectedItem.ToString())
    Else
      ListPictureCustDispl.SetSelected(0, True)
    End If
  End Sub
  Public Sub GetDTOrder(ByVal MBUID As String)
    
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
        'ListArray.Add(ItemRecord.Item("MBTRANSDTITEMPRICE"))
        ListArray.Add(ItemRecord.Item("MBTRANSDTITEMQTY") * ItemRecord.Item("MBTRANSDTITEMPRICE"))
        'ListArray.Add(ItemRecord.Item("MBTRANSDTITEMNOTE"))
        'ListArray.Add(IIf(ItemRecord.Item("MBTRANSDTITEMNOTE") = Nothing, False, True))
        'ListArray.Add(IIf(ItemRecord.Item("MBTRANSDTISTAKEAWAY") = 0, False, True))
        'ListArray.Add(ItemRecord.Item("MBTRANSDTUID"))
        'ListArray.Add(ItemRecord.Item("MBTRANSDTITEMSTAT"))
        'ListArray.Add(ItemRecord.Item("INVENLEVEL"))
        'ListArray.Add(ItemRecord.Item("MBTRANSDTITEMMEASUNITDESC"))
        'ListArray.Add(ItemRecord.Item("MBTRANSDTUID"))
        'ListArray.Add(ItemRecord.Item("MBTRANSDTLISTNOTE"))
        'ListArray.Add(ItemRecord.Item("MBTRANSDTLISTNOTEUID"))
        'ListArray.Add(ItemRecord.Item("MBTRANSDTUID"))
        'ListArray.Add(ItemRecord.Item("MBTRANSDTPARENTUID"))
        'ListArray.Add(IIf(IsDBNull(ItemRecord.Item("jmlMod")) = True, "0", ItemRecord.Item("jmlMod")))
        OrderListCollection.Add(ListArray)
      End While
    End With
  End Sub
  Public Sub refOrder()
    IdFromInvoiceList.Text = ""
    ItemMixFormCustomerDisplay = ""
    With OrderDetail
      .Rows.RemoveRange(1, .Rows.Count - 1)
    End With

    LabelDPVal.Text = "0"
    LblDiscountVal.Text = "0"
    LabelPBVal.Text = "0"
    LabelSCVal.Text = "0"
    LabelRoundVal.Text = "0"
    LabelTAVal.Text = "0"
    SubTotalTxt.Text = "0"
    lblTotalItem.Text = "0"
  End Sub
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
          If CheckDoubleEntry(CurrentRecord(0)) Then
            Exit Sub
          Else
            .AddItem(CurrentRecord(0) & vbTab & CurrentRecord(1) & vbTab & CurrentRecord(2) & vbTab & "" & vbTab & CurrentRecord(3) & vbTab & "")
            .Row = .Rows.Count - 1
          End If

          
        Next
       
      End If
      .Redraw = True
    End With
  End Sub


End Class