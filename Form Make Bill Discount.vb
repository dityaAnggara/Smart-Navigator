Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win.C1FlexGrid

Public Class Form_Make_Bill_Discount

#Region "Variable Reference"
  Public ParentOBJForm As Object
  Public Total As Double
  Dim x As Integer = 0
  Dim y As Integer = 0
  Public TransactionUID As String = Nothing
  Public Invoice As Boolean = False
  'Dim CustInfo As New ArrayList
  'Dim CustOrderInfo As New ArrayList
  Dim screenHeight As Integer = Screen.PrimaryScreen.Bounds.Height
  Dim CustOrderDetail As New Collection
  Public originalDiscVal As Decimal
  Public ChangeAccount As Boolean = False

  Private Enum DiscByAmountLib
    ByPercentage = 1
    ByDollarOffEachItem = 2
    ByDollarOffAllItem = 3
    ByATargetPrice = 4
  End Enum

  Structure DiscGenerateResultLib
    Dim NewPriceAfterDisc As Decimal
    Dim DiscItemCount As Decimal
    Dim DiscountValue As Decimal
  End Structure

  Dim TMPNewDiscListCollection As New Collection
  Dim LimitDiscount As Integer = 0
  Public SwitchUserAccess As Boolean = False
  Public AskMountValue As Decimal = 0
#End Region

#Region "Initialize & Object Function"

  Dim VIsSaveOk As Boolean = True

  Private Sub BasicInitialize(Optional ByVal Reset As Boolean = False)
    If Invoice = False Then
      TransactionUID = GetTransactionCode(SelectedTable.TableUID)
    End If

    Dim TMPCheck As FbDataReader
    Dim TransactionDate As Date
    TMPCheck = MyDatabase.MyReader("SELECT * FROM MBTRANS WHERE MBTRANSUID = '" & TransactionUID & "'")
    While TMPCheck.Read
      TransactionDate = TMPCheck.Item("MBTRANSDATE")
    End While

    'Anjo - 31 Okt , The following is ignored, tidak tau apa gunanya
    'CustOrderInfo = GetCustOrderInfo(TransactionUID)
    'CustInfo = GetCustInfo(CustOrderInfo(7))
    CustOrderDetail = DBListCollection("SELECT * FROM MBTRANSDT WHERE MBTRANSUID = '" & TransactionUID & "' AND MBTransDtItemStat <> -1 ORDER BY MBTransDtItemPrice ASC")

    Call InitializeItemList(Reset)
    Call DiscountFilter(TransactionDate)
    If Not Reset Then Call ReinitializeDiscList()

  End Sub

  Private Sub ReinitializeDiscList()
    Dim CurrentRecord As New ArrayList
    TMPNewDiscListCollection = ParentOBJForm.TMPDiscListCollection

    With ItemList
      If Not IsNothing(TMPNewDiscListCollection) Then
        For i As Integer = 1 To TMPNewDiscListCollection.Count
          CurrentRecord = TMPNewDiscListCollection(i)
          Dim CurPos As Integer = CInt(CurrentRecord(0))
          For j As Integer = 1 To CurrentRecord.Count - 1
            .Item(CurPos, j - 1) = CurrentRecord(j)
          Next
        Next
      End If
    End With

  End Sub

  Private Function GetTransactionCode(ByVal TableUID As String) As String
    Dim TMPRecord As FbDataReader
    TMPRecord = MyDatabase.MyReader("SELECT TABLEMBTRANSUID FROM TABLELIST WHERE TABLELISTUID = '" & TableUID & "'")
    TMPRecord.Read()

    If IsDBNull(TMPRecord.Item("TABLEMBTRANSUID")) Then
      Return Nothing
    Else
      Return TMPRecord.Item("TABLEMBTRANSUID")
    End If

  End Function

  'Private Function GetCustOrderInfo(ByVal TransUID As String) As ArrayList
  '    Dim TMPRecord As FbDataReader
  '    Dim TMPArray As New ArrayList
  '    TMPRecord = MyDatabase.MyReader("SELECT * FROM MBTRANS WHERE MBTRANSUID = '" & TransUID & "'")
  '    TMPRecord.Read()

  '    If IsDBNull(TMPRecord.Item("MBTRANSNO")) Then
  '        Return Nothing
  '    Else
  '        For i As Integer = 0 To TMPRecord.FieldCount - 1
  '            TMPArray.Add(TMPRecord.Item(i))
  '        Next

  '        Return TMPArray
  '    End If

  'End Function

  'Private Function GetCustInfo(ByVal CustUID As String) As ArrayList
  '    Dim TMPRecord As FbDataReader
  '    Dim TMPArray As New ArrayList
  '    TMPRecord = MyDatabase.MyReader("SELECT a.CUSTUID, a.CUSTNO, a.CUSTNAME, a.CUSTCATUID , (SELECT CUSTCATNAME FROM CUSTCAT WHERE CUSTCATUID = a.CUSTCATUID) FROM CUST a WHERE CUSTUID ='" & CustUID & "'")
  '    TMPRecord.Read()

  '    If IsDBNull(TMPRecord.Item("CUSTCATNAME")) Then
  '        Return Nothing
  '    Else
  '        For i As Integer = 0 To TMPRecord.FieldCount - 1
  '            TMPArray.Add(TMPRecord.Item(i))
  '        Next
  '        Return TMPArray
  '    End If

  'End Function

  Private Function GetDiscInfo(ByVal DiscUID As String) As String
    Dim TMPRecord As FbDataReader
    Dim TMPArray As New ArrayList

    TMPRecord = MyDatabase.MyReader("SELECT * FROM MBTRANSDT MB LEFT OUTER JOIN DISC D ON MB.MBTRANSDTITEMDISCUID1 = D.DISCUID WHERE MBTRANSDTITEMDISCUID1='" & DiscUID & "'")
    TMPRecord.Read()
    If IsDBNull(TMPRecord.Item("DISCNAME")) Then
      Return Nothing
    Else
      Dim DiscountName As String = TMPRecord.Item("DISCNAME")
      Return DiscountName
    End If
  End Function
  Private Function GetDisc2Info(ByVal DiscUID As String) As String
    Dim TMPRecord As FbDataReader
    Dim TMPArray As New ArrayList

    TMPRecord = MyDatabase.MyReader("SELECT * FROM MBTRANSDT MB LEFT OUTER JOIN DISC D ON MB.MBTRANSDTITEMDISCUID2 = D.DISCUID WHERE MBTRANSDTITEMDISCUID2='" & DiscUID & "'")
    TMPRecord.Read()
    If IsDBNull(TMPRecord.Item("DISCNAME")) Then
      Return Nothing
    Else
      Dim DiscountName As String = TMPRecord.Item("DISCNAME")
      Return DiscountName
    End If
  End Function

  Private Sub InitializeItemList(Optional ByVal Reset As Boolean = False)
    With ItemList
      .Rows.Count = 1 : .Rows.Fixed = 1 : .Rows(0).Height = 30
      .AllowMerging = AllowMergingEnum.Free
      .Rows(0).AllowMerging = True
      .Cols(2).AllowMerging = True
      .Cols(3).AllowMerging = True

      For i As Integer = 1 To CustOrderDetail.Count
        Dim DataArray As New ArrayList
        DataArray = CustOrderDetail(i)
        For j As Integer = 1 To 2
          Try
            If Reset = False Then
              If j = 1 Then
                .AddItem(DataArray(0) & vbTab & DataArray(2) & vbTab & DataArray(3) & vbTab & DataArray(5) & vbTab & IIf(DataArray(6) = "", Nothing, DataArray(6)) & vbTab & GetDiscInfo(DataArray(6)) & vbTab & IIf(j = 1, DataArray(10), Nothing) & vbTab & Nothing & vbTab & Nothing & vbTab & DataArray(5) & vbTab & DataArray(7) / DataArray(5) & vbTab & DataArray(5) * (DataArray(7) / DataArray(5)))
                .Rows(.Rows.Count - 1).Height = 30
              End If
              If j = 2 Then
                If DataArray(9) = 0 Then
                  GoTo Reset
                  Exit For
                End If
                .AddItem(DataArray(0) & vbTab & DataArray(2) & vbTab & DataArray(3) & vbTab & DataArray(5) & vbTab & IIf(DataArray(8) = "", Nothing, DataArray(8)) & vbTab & GetDisc2Info(DataArray(8)) & vbTab & Nothing & vbTab & Nothing & vbTab & Nothing & vbTab & DataArray(5) & vbTab & DataArray(9) / DataArray(5) & vbTab & DataArray(5) * (DataArray(9) / DataArray(5)))
                .Rows(.Rows.Count - 1).Height = 30
              End If
            End If

            If Reset = True Then
Reset:
              .AddItem(DataArray(0) & vbTab & DataArray(2) & vbTab & DataArray(3) & vbTab & DataArray(5) & vbTab & vbTab & vbTab & IIf(j = 1, DataArray(10), Nothing))
              .Rows(.Rows.Count - 1).Height = 30
            End If

          Catch ex As Exception
            .AddItem(DataArray(0) & vbTab & DataArray(2) & vbTab & DataArray(3) & vbTab & DataArray(5) & vbTab & vbTab & vbTab & IIf(j = 1, DataArray(10), Nothing))
            .Rows(.Rows.Count - 1).Height = 30
          End Try
        Next
        .AddItem(vbTab & vbTab & vbTab & vbTab & vbTab)
        .Rows(.Rows.Count - 1).Visible = False
      Next

      Call InitializeItemToDisc(True)
    End With
  End Sub

  Private Sub DiscountFilter(ByVal Time As Date)
    Dim TMPRecord As FbDataReader
    TMPRecord = MyDatabase.MyReader("SELECT * FROM DISC WHERE DISCACTV='0' ORDER BY DISCNAME")
    With DiscountList
      .Redraw = False
      .Rows.Count = 1 : .Rows.Fixed = 1 : .Rows(0).Height = 30
      ' Check Date & Daytime expired
      While TMPRecord.Read()
        If (Now.Date >= TMPRecord.Item("DISCSTARTDATE") And Now.Date <= TMPRecord.Item("DISCENDDATE")) Then
          Dim MSGFeedback As String = ValidTime(Time, TMPRecord.Item("DISCUID"))
          If IsNothing(MSGFeedback) Then
            .AddItem(TMPRecord.Item("DISCUID") & vbTab & TMPRecord.Item("DISCNAME") & vbTab & False & vbTab & False)
            .Rows(.Rows.Count - 1).Height = 60
          Else
            .AddItem(TMPRecord.Item("DISCUID") & vbTab & TMPRecord.Item("DISCNAME") & vbTab & True & vbTab & False & vbTab & "This discount is only valid from the hours of " & MSGFeedback & " ! ")
            .Rows(.Rows.Count - 1).Visible = False
          End If
        Else
          .AddItem(TMPRecord.Item("DISCUID") & vbTab & TMPRecord.Item("DISCNAME") & vbTab & True & vbTab & False & vbTab & "This discount is only valid from the date of " & TMPRecord.Item("DISCSTARTDATE") & " to " & TMPRecord.Item("DISCENDDATE") & " ! ")
          .Rows(.Rows.Count - 1).Visible = False
        End If
      End While
      .Redraw = True
    End With
    TMPRecord = Nothing
  End Sub

  Private Function ValidTime(ByVal Time As Date, ByVal DiscUID As String) As String
    Dim TMPCheck As FbDataReader
    Dim Result As String = "Unknown to Unknown"
    Dim Day As String = Now.DayOfWeek
    If Day = "0" Then
      Day = "7"
    End If

    TMPCheck = MyDatabase.MyReader("SELECT * FROM DISCDATETIME WHERE DISCUID = '" & DiscUID & "' AND DISCDATETIMEDAYTYPEID ='" & Day & "'")
    While TMPCheck.Read
      Try
        Result = FormatDateTime(TMPCheck.Item("DISCSTARTTIME"), DateFormat.LongTime) & " to " & FormatDateTime(TMPCheck.Item("DISCENDTIME"), DateFormat.LongTime)
        If FormatDateTime(TMPCheck.Item("DISCSTARTTIME"), DateFormat.LongTime) < FormatDateTime(TMPCheck.Item("DISCENDTIME"), DateFormat.LongTime) Then
          If CDate(Time.TimeOfDay.ToString) >= FormatDateTime(TMPCheck.Item("DISCSTARTTIME"), DateFormat.LongTime) And CDate(Time.TimeOfDay.ToString) <= FormatDateTime(TMPCheck.Item("DISCENDTIME"), DateFormat.LongTime) Then
            Result = Nothing
            Exit While
          End If
        Else
          If CDate(Time.TimeOfDay.ToString) >= FormatDateTime(TMPCheck.Item("DISCSTARTTIME"), DateFormat.LongTime) And CDate(Time.TimeOfDay.ToString) <= FormatDateTime(TMPCheck.Item("DISCENDTIME"), DateFormat.LongTime) Then
            Result = Nothing
            Exit While
          End If
        End If
      Catch ex As Exception
        Result = "Unknown to Unknown"
      End Try
    End While
    Return Result
  End Function

  Private Function CheckServiceType(ByVal DiscUID As String) As Boolean
    Dim TMPRecord As FbDataReader
    Dim Result As Boolean = False
    TMPRecord = MyDatabase.MyReader("SELECT DISCSERVICETYPEUID FROM DISC WHERE DISCUID = '" & DiscUID & "'")
    While TMPRecord.Read
      'Try
      If Trim(TMPRecord.Item("DISCSERVICETYPEUID")) = "NULL" Then
        Return True
        Exit Function
      End If

      Dim TMPCheck As FbDataReader
      TMPCheck = MyDatabase.MyReader("SELECT MBTRANSSERVICETYPEUID FROM MBTRANS WHERE MBTRANSUID = '" & TransactionUID & "'")
      While TMPCheck.Read
        If Trim(TMPRecord.Item("DISCSERVICETYPEUID")) = Trim(TMPCheck.Item("MBTRANSSERVICETYPEUID")) Then
          Result = True
          Exit While
        End If
      End While
      'Catch ex As Exception
      'Result = False
      'End Try
    End While
    Return Result
  End Function

  Private Function CheckCategoryType(ByVal DiscUID As String) As Boolean
    Dim TMPRecord As FbDataReader
    Dim Result As Boolean = False
    TMPRecord = MyDatabase.MyReader("SELECT DISCCUSTCATUID FROM DISC WHERE DISCUID = '" & DiscUID & "'")
    While TMPRecord.Read
      If Trim(TMPRecord.Item("DISCCUSTCATUID")) = "NULL" Then
        Return True
        Exit Function
      End If

      Dim TMPCheck As FbDataReader
      TMPCheck = MyDatabase.MyReader("SELECT A.CUSTCATUID FROM CUST A, MBTRANS B WHERE A.CUSTUID=B.MBTRANSCUSTUID AND B.MBTRANSUID='" & TransactionUID & "'")
      While TMPCheck.Read
        If Trim(TMPRecord.Item("DISCCUSTCATUID")) = Trim(TMPCheck.Item("CUSTCATUID")) Then
          Result = True
          Exit While
        End If
      End While
    End While
    Return Result
  End Function

  Private Function GetServiceName(ByVal DiscUID As String) As String
    Dim TMPRecord As FbDataReader
    Dim Result As String = "Unknown"
    TMPRecord = MyDatabase.MyReader("SELECT a.DISCUID, a.DISCSERVICETYPEUID, (SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = a.DISCSERVICETYPEUID ) AS ServiceName FROM DISC a WHERE a.DISCUID = '" & DiscUID & "'")
    While TMPRecord.Read
      Try
        Result = TMPRecord.Item("ServiceName")
      Catch ex As Exception
        Result = "Unknown"
      End Try
    End While
    Return Result
  End Function

  Private Function GetCustomerCategoryName(ByVal DiscUID As String) As String
    Dim TMPRecord As FbDataReader
    Dim Result As String = "Unknown"
    TMPRecord = MyDatabase.MyReader("SELECT a.DISCUID, a.DISCCUSTCATUID, (SELECT CUSTCATNAME FROM CUSTCAT WHERE CUSTCATUID=a.DISCCUSTCATUID) AS CategoryName FROM DISC a WHERE a.DISCUID='" & DiscUID & "'")
    While TMPRecord.Read
      Try
        Result = TMPRecord.Item("CategoryName")
      Catch ex As Exception
        Result = "Unknown"
      End Try
    End While
    Return Result
  End Function

  Private Function CantCombine(ByVal DiscUID As String) As Boolean
    Dim TMPRecord As FbDataReader
    Dim Result As Boolean = False
    TMPRecord = MyDatabase.MyReader("SELECT DISCISCOMBINED FROM DISC WHERE DISCUID ='" & DiscUID & "'")
    While TMPRecord.Read
      Try

        If TMPRecord.Item("DISCISCOMBINED") = "1" Then
          Result = True
          Exit While
        End If

      Catch ex As Exception
        Result = False
      End Try
    End While
    Return Result
  End Function

  Private Sub InitializeItemToDisc(Optional ByVal LockAll As Boolean = True)
    With ItemList
      If LockAll Then
        For i As Integer = 1 To .Rows.Count - 1
          .Item(i, 7) = True
        Next
      End If

      Dim NewStyle As CellStyle
      NewStyle = .Styles.Add("InvalidDisc")
      NewStyle.BackColor = Color.LightCoral

      For i As Integer = 1 To .Rows.Count - 1
        If .Item(i, 7) = True Then
          .Rows(i).Style = .Styles("InvalidDisc")
        Else
          .Rows(i).Style = Nothing
        End If
      Next
    End With
  End Sub

  Private Function FindSelectedRow(ByVal OBJList As Object) As Integer
    Dim PosRow As Long = -1
    Try
      For i As Integer = 1 To OBJList.Rows.Count - 1
        If Mid(OBJList.Item(i, IIf(OBJList.name = "DiscountList", 1, 2)), 1, 3) = "=> " Then
          PosRow = i
          Exit For
        End If
      Next
    Catch ex As Exception
      PosRow = -1
    End Try
    Return PosRow
  End Function

  Private Function CheckValidUser(ByVal DiscUID As String) As Boolean
    Dim TMPRecord As FbDataReader
    Dim Result As Boolean = False
    TMPRecord = MyDatabase.MyReader("SELECT DISCUSERCATUID FROM DISCUSERCATACCESS WHERE DISCUID = '" & DiscUID & "'")
    While TMPRecord.Read
      Try
        If Trim(TMPRecord.Item("DISCUSERCATUID")) = Trim(UserInformation.UserTypeUID) Then
          Result = True
          Exit While
        End If
      Catch ex As Exception
        Result = False
      End Try
    End While
    Return Result
  End Function

  Private Function ExistDiscCount(ByVal DiscUID As String) As Decimal
    Dim Result As Decimal = 0
    With ItemList
      For i As Integer = 1 To .Rows.Count - 1
        If Trim(.Item(i, 4)) = Trim(DiscUID) Then
          Result = Result + .Item(i, 9)
        End If
      Next
    End With
    Return Result
  End Function

  Private Function DiscountGenerateAnyProduct(ByVal DiskAmountType As DiscByAmountLib, ByVal MaxLimit As Decimal, ByVal OriginalPrice As Decimal, ByVal Qty As Decimal, ByVal DiscValue As Decimal, ByVal TotQty As Decimal) As DiscGenerateResultLib
    Dim GetPricePerItem As Decimal = OriginalPrice
    Dim ItemToDiscCount As Decimal = IIf(MaxLimit = 0, Qty, IIf(Qty >= MaxLimit, MaxLimit, Qty))
    Dim DiscItemValue As Decimal = 0
    Dim DiscGenerateresult As New DiscGenerateResultLib
    Dim TotalPriceDiscountedItems As Decimal = 0
    Dim TotalPriceIsNotDiscountedItems As Decimal = 0

    Select Case CInt(DiskAmountType)
      Case "1" ' A Percent
        Dim Result As Double = 0
        Result = (GetPricePerItem * DiscValue) / 100
        DiscItemValue = Result
        TotalPriceDiscountedItems = Result * ItemToDiscCount

      Case "2" ' Dollar off each item
        DiscItemValue = DiscValue
        TotalPriceDiscountedItems = DiscValue * ItemToDiscCount

      Case "3" ' Dollar off all item
        DiscItemValue = DiscValue / TotQty
        TotalPriceDiscountedItems = DiscItemValue * ItemToDiscCount

      Case "4" ' A target price
        If DiscValue > GetPricePerItem Then
          DiscItemValue = GetPricePerItem
          TotalPriceDiscountedItems = DiscItemValue * ItemToDiscCount
        Else
          DiscItemValue = GetPricePerItem - DiscValue
          TotalPriceDiscountedItems = DiscItemValue * ItemToDiscCount
        End If
    End Select

    If Qty >= ItemToDiscCount Then
      TotalPriceIsNotDiscountedItems = 0 '(Qty - ItemToDiscCount) * GetPricePerItem
    Else
      TotalPriceIsNotDiscountedItems = 0
    End If

    DiscGenerateresult.DiscountValue = DiscItemValue
    'If CInt(DiskAmountType) = "4" Then
    '    DiscGenerateresult.DiscItemCount = 1
    'Else
    '    DiscGenerateresult.DiscItemCount = ItemToDiscCount
    'End If
    DiscGenerateresult.DiscItemCount = ItemToDiscCount
    DiscGenerateresult.NewPriceAfterDisc = TotalPriceDiscountedItems + TotalPriceIsNotDiscountedItems

    Return DiscGenerateresult
  End Function

  Private Function DiscountGenerateSpecificProduct(ByVal DiskAmountType As DiscByAmountLib, ByVal MaxLimit As Decimal, ByVal OriginalPrice As Decimal, ByVal Qty As Decimal, ByVal DISCUID As String, ByVal ItemUID As String, ByVal TotQty As Decimal, Optional ByVal IsAskMount As Decimal = 0) As DiscGenerateResultLib
    Dim GetPricePerItem As Decimal = OriginalPrice
    Dim ItemToDiscCount As Decimal = IIf(MaxLimit = 0, Qty, IIf(Qty >= MaxLimit, MaxLimit, Qty))
    Dim DiscItemValue As Decimal = 0
    Dim DiscGenerateresult As New DiscGenerateResultLib
    Dim TotalPriceDiscountedItems As Decimal = 0
    Dim TotalPriceIsNotDiscountedItems As Decimal = 0
    Dim DiscValue As Decimal = 0

    If IsAskMount > 0 Then
      DiscValue = IsAskMount
    Else
      Dim TMPRecord As FbDataReader
      TMPRecord = MyDatabase.MyReader("SELECT PRODUCTDISCPERC FROM DISCPRODUCTTODISC WHERE DISCUID ='" & DISCUID & "' AND PRODUCTUID='" & ItemUID & "'")
      While TMPRecord.Read
        DiscValue = TMPRecord.Item("PRODUCTDISCPERC")
      End While
    End If

    Select Case CInt(DiskAmountType)
      Case "1" ' A Percent
        Dim Result As Double = 0
        Result = (GetPricePerItem * DiscValue) / 100
        DiscItemValue = Result
        TotalPriceDiscountedItems = Result * ItemToDiscCount

      Case "2" ' Dollar off each item
        DiscItemValue = DiscValue
        TotalPriceDiscountedItems = DiscValue * ItemToDiscCount

      Case "3" ' Dollar off all item
        DiscItemValue = DiscValue / TotQty
        TotalPriceDiscountedItems = DiscItemValue * ItemToDiscCount

      Case "4" ' A target price
        If DiscValue > GetPricePerItem Then
          DiscItemValue = GetPricePerItem
          TotalPriceDiscountedItems = DiscItemValue * ItemToDiscCount
        Else
          DiscItemValue = GetPricePerItem - DiscValue
          TotalPriceDiscountedItems = DiscItemValue * ItemToDiscCount
        End If

    End Select

    If Qty > ItemToDiscCount Then
      TotalPriceIsNotDiscountedItems = 0 '(Qty - ItemToDiscCount) * GetPricePerItem
    Else
      TotalPriceIsNotDiscountedItems = 0
    End If

    DiscGenerateresult.DiscountValue = DiscItemValue
    'If CInt(DiskAmountType) = "3" Then
    '    DiscGenerateresult.DiscItemCount = ItemToDiscCount '1
    'Else
    '    DiscGenerateresult.DiscItemCount = ItemToDiscCount
    'End If
    DiscGenerateresult.DiscItemCount = ItemToDiscCount
    DiscGenerateresult.NewPriceAfterDisc = TotalPriceDiscountedItems + TotalPriceIsNotDiscountedItems

    Return DiscGenerateresult
  End Function

  Private Function DiscountGenerateQuantity(ByVal DiskAmountType As DiscByAmountLib, ByVal DISCUID As String, ByVal MaxLimit As Integer, ByVal OriginalPrice As Decimal, ByVal Qty As Long, ByVal DiscValue As Decimal) As DiscGenerateResultLib
    Dim GetPricePerItem As Decimal = OriginalPrice
    Dim ItemToDiscCount As Long = IIf(MaxLimit = 0, Qty, IIf(Qty >= MaxLimit, MaxLimit, Qty))
    Dim DiscItemValue As Decimal = 0
    Dim DiscGenerateresult As New DiscGenerateResultLib
    Dim TotalPriceDiscountedItems As Decimal = 0
    Dim TotalPriceIsNotDiscountedItems As Decimal = 0

    Dim QTYBuy As Integer = 0
    Dim QTYGet As Integer = 0
    Dim Bayar As Decimal = 0
    Dim BayarPlus As Decimal = 0
    Dim Gratis As Decimal = 0
    Dim TMPRecord As FbDataReader
    TMPRecord = MyDatabase.MyReader("SELECT DISCQTYBUY, DISCQTYGET FROM DISC WHERE DISCUID ='" & DISCUID & "'")
    While TMPRecord.Read
      QTYBuy = CInt(TMPRecord.Item("DISCQTYBUY"))
      QTYGet = CInt(TMPRecord.Item("DISCQTYGET"))
      Bayar = Fix(Qty / (QTYBuy + QTYGet)) * QTYBuy
      If Qty Mod (QTYBuy + QTYGet) <= QTYBuy Then
        BayarPlus = Qty Mod (QTYBuy + QTYGet)
      Else
        BayarPlus = QTYBuy
      End If
      Gratis = Qty - Bayar - BayarPlus
    End While

    If Gratis > ItemToDiscCount Then Gratis = ItemToDiscCount

    Select Case CInt(DiskAmountType)
      Case "1" ' A Percent
        Dim Result As Double = 0
        Result = (GetPricePerItem * DiscValue) / 100
        DiscItemValue = Result
        TotalPriceDiscountedItems = DiscItemValue * Gratis

      Case "2" ' Dollar off each item
        DiscItemValue = DiscValue
        TotalPriceDiscountedItems = DiscValue * Gratis

      Case "3" ' Dollar off all item
        DiscItemValue = DiscValue * Gratis
        TotalPriceDiscountedItems = (GetPricePerItem - DiscValue) * Gratis

      Case "4" ' A target price
        If DiscValue > GetPricePerItem Then
          DiscItemValue = GetPricePerItem
          TotalPriceDiscountedItems = DiscItemValue * Gratis
        Else
          DiscItemValue = GetPricePerItem - DiscValue
          TotalPriceDiscountedItems = DiscItemValue * Gratis
        End If

    End Select

    If Qty > Gratis Then
      TotalPriceIsNotDiscountedItems = 0 '(Qty - Gratis) * GetPricePerItem
    Else
      TotalPriceIsNotDiscountedItems = 0
    End If

    DiscGenerateresult.DiscountValue = DiscItemValue
    If CInt(DiskAmountType) = "4" Then
      DiscGenerateresult.DiscItemCount = Gratis
    Else
      DiscGenerateresult.DiscItemCount = Gratis
    End If
    DiscGenerateresult.NewPriceAfterDisc = TotalPriceDiscountedItems + TotalPriceIsNotDiscountedItems

    Return DiscGenerateresult
  End Function
  'Added By Rudy 13 Sept 2011
  Private Function DiscountGenerateQuantityLow(ByVal DiskAmountType As DiscByAmountLib, ByVal DISCUID As String, ByVal MaxLimit As Decimal, ByVal OriginalPrice As Decimal, ByVal Qty As Decimal, ByVal DiscValue As Decimal) As DiscGenerateResultLib
    Dim GetPricePerItem As Decimal = OriginalPrice
    Dim ItemToDiscCount As Decimal = IIf(MaxLimit = 0, Qty, IIf(Qty >= MaxLimit, MaxLimit, Qty))
    Dim DiscItemValue As Decimal = 0
    Dim DiscGenerateresult As New DiscGenerateResultLib
    Dim TotalPriceDiscountedItems As Decimal = 0
    Dim TotalPriceIsNotDiscountedItems As Decimal = 0

    Select Case CInt(DiskAmountType)
      Case "1" ' A Percent
        Dim Result As Double = 0
        Result = (GetPricePerItem * DiscValue) / 100
        DiscItemValue = Result
        TotalPriceDiscountedItems = DiscItemValue * Qty

      Case "2" ' Dollar off each item
        DiscItemValue = DiscValue
        TotalPriceDiscountedItems = DiscValue * Qty

      Case "3" ' Dollar off all item
        DiscItemValue = DiscValue * Qty
        TotalPriceDiscountedItems = (GetPricePerItem - DiscValue) * Qty

      Case "4" ' A target price
        If DiscValue > GetPricePerItem Then
          DiscItemValue = GetPricePerItem
          TotalPriceDiscountedItems = DiscItemValue * Qty
        Else
          DiscItemValue = GetPricePerItem - DiscValue
          TotalPriceDiscountedItems = DiscItemValue * Qty
        End If

    End Select

    If Qty > Qty Then
      TotalPriceIsNotDiscountedItems = 0 '(Qty - Gratis) * GetPricePerItem
    Else
      TotalPriceIsNotDiscountedItems = 0
    End If

    DiscGenerateresult.DiscountValue = DiscItemValue
    If CInt(DiskAmountType) = "4" Then
      DiscGenerateresult.DiscItemCount = Qty
    Else
      DiscGenerateresult.DiscItemCount = Qty
    End If
    DiscGenerateresult.NewPriceAfterDisc = TotalPriceDiscountedItems + TotalPriceIsNotDiscountedItems

    Return DiscGenerateresult
  End Function

  Private Function DiscountGenerateCombination(ByVal DiskAmountType As DiscByAmountLib, ByVal MaxLimit As Decimal, ByVal OriginalPrice As Decimal, ByVal Qty As Decimal, ByVal DISCUID As String, ByVal ItemUID As String, Optional ByVal IsAskMount As Decimal = 0) As DiscGenerateResultLib
    Dim GetPricePerItem As Decimal = OriginalPrice
    Dim ItemToDiscCount As Decimal = IIf(MaxLimit = 0, Qty, IIf(Qty >= MaxLimit, MaxLimit, Qty))
    Dim DiscItemValue As Decimal = 0
    Dim DiscGenerateresult As New DiscGenerateResultLib
    Dim TotalPriceDiscountedItems As Decimal = 0
    Dim TotalPriceIsNotDiscountedItems As Decimal = 0
    Dim DiscValue As Decimal = 0

    If IsAskMount <> 0 Then
      DiscValue = IsAskMount
    Else
      Dim TMPRecord As FbDataReader
      TMPRecord = MyDatabase.MyReader("SELECT PRODUCTDISCPERC FROM DISCPRODUCTTODISC WHERE DISCUID ='" & DISCUID & "' AND PRODUCTUID='" & ItemUID & "'")
      While TMPRecord.Read
        DiscValue = TMPRecord.Item("PRODUCTDISCPERC")
      End While
    End If

    Select Case CInt(DiskAmountType)
      Case "1" ' A Percent
        Dim Result As Double = 0
        Result = (GetPricePerItem * DiscValue) / 100
        DiscItemValue = Result
        TotalPriceDiscountedItems = DiscItemValue * ItemToDiscCount

      Case "2" ' Dollar off each item
        DiscItemValue = DiscValue
        TotalPriceDiscountedItems = DiscItemValue * ItemToDiscCount

      Case "3" ' Dollar off all item
        DiscItemValue = DiscValue * Qty
        TotalPriceDiscountedItems = (GetPricePerItem - DiscValue) * Qty

      Case "4" ' A target price
        If DiscValue > GetPricePerItem Then
          DiscItemValue = GetPricePerItem
          TotalPriceDiscountedItems = DiscItemValue * ItemToDiscCount
        Else
          DiscItemValue = GetPricePerItem - DiscValue
          TotalPriceDiscountedItems = DiscItemValue * ItemToDiscCount
        End If

    End Select

    If Qty > ItemToDiscCount Then
      TotalPriceIsNotDiscountedItems = 0 '(Qty - ItemToDiscCount) * GetPricePerItem
    Else
      TotalPriceIsNotDiscountedItems = 0
    End If

    DiscGenerateresult.DiscountValue = DiscItemValue
    If CInt(DiskAmountType) = "3" Then
      DiscGenerateresult.DiscItemCount = ItemToDiscCount
    Else
      DiscGenerateresult.DiscItemCount = ItemToDiscCount
    End If
    DiscGenerateresult.NewPriceAfterDisc = TotalPriceDiscountedItems + TotalPriceIsNotDiscountedItems

    Return DiscGenerateresult
  End Function

  Private Sub FocusMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMoveUp.MouseDown, BTNMoveDown.MouseDown
    With ItemList
      If .Rows.Count > -1 Then
        Select Case sender.name
          Case "BTNMoveUp"
            If .Row > 3 Then .Row = .Row - 3
          Case "BTNMoveDown"
            If .Row < .Rows.Count - 3 Then .Row = .Row + 3
        End Select
      End If
    End With
  End Sub

  Private Sub FocusMove1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMoveUp1.MouseDown, BTNMoveDown1.MouseDown
    With DiscountList
      If .Rows.Count > -1 Then
        Select Case sender.name
          Case "BTNMoveUp1"
            If .Row > 1 Then .Row = .Row - 1
          Case "BTNMoveDown1"
            If .Row < .Rows.Count - 1 Then .Row = .Row + 1
        End Select
      End If
    End With
  End Sub

  Private Function GetTotalItemDipilih() As Decimal

    Dim totalDipilih As Decimal = 0
    With ItemList
      For q As Integer = 1 To .Rows.Count - 1 Step 2
        If Mid(.Item(q, 2), 1, 3) = "=> " Then
          totalDipilih = totalDipilih + CDec(.Item(q, 3))
        End If
      Next
    End With

    GetTotalItemDipilih = totalDipilih

  End Function
#End Region

#Region "Form Control Function"

  Private Sub Form_Make_Bill_Discount_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
    If screenWidth < 1024 Then
      AllDiscount.Visible = False
      LabelAllDiscount.Visible = False
      BTNMoveDown.Visible = False
      BTNMoveDown1.Visible = False
      BTNMoveUp.Visible = False
      BTNMoveUp1.Visible = False
      AllDiscount.Visible = False
      AllItem.Visible = False
      LabelAllDiscount.Visible = False
      LabelSelectAll.Visible = False
      cmdSelectAllDiscount.Visible = True
      cmdSelectAllItem.Visible = True
      Me.Left = 0
      Me.Top = (screenHeight / 2) - (Me.Height / 2)
      Dim origWidth As Integer = Me.Width
      Dim origHeight As Integer = Me.Height
      Me.Width = screenWidth
      Me.Height = Me.Height + 10
      Dim fSize As New SizeF((Me.Width / 1024), (Me.Height / origHeight))
      GroupBox.Scale(fSize)
      GroupBox1.Scale(fSize)
      GroupBox2.Scale(fSize)
    Else
      Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 44)
    End If
    ItemList.Styles("Normal").WordWrap = True
    DiscountList.Styles("Normal").WordWrap = True

    Call BasicInitialize()
    If PrefInfo.VIsAutoDisc = True Then
      Me.MinimizeBox = True
      Me.WindowState = FormWindowState.Minimized
      Me.Hide()
      If VUIDAutoDisc <> "" Then
        Call AutoDiscCalc(VUIDAutoDisc, sender, e)
        If VIsSaveOk = False Then Me.Close()
      Else
        Me.Close()
      End If
      
    End If
  End Sub

  Private Sub AutoDiscCalc(ByVal DiscUID As String, ByVal sender As System.Object, ByVal e As System.EventArgs)
    For i As Integer = 1 To DiscountList.Rows.Count - 1
      If DiscUID = DiscountList.Item(i, 0) Then
        DiscountList.Row = i
        Call DiscountList_Click(sender, e)
        Call SelectAllItem2Disc()
        Call BTNApply_Click(sender, e)
        Call BTNSave_Click(sender, e)
        i = DiscountList.Rows.Count
      End If
    Next

  End Sub

  Private Sub DiscountList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DiscountList.Click
    VIsSaveOk = False
    x = 0
    AllItem.Image = My.Resources._NOTHING

    ItemList.Row = Nothing
    With DiscountList
      If .Row <= 0 Then Exit Sub
      ' Reset Selection Disc & Item
      For i As Integer = 1 To ItemList.Rows.Count - 1
        ItemList.Item(i, 2) = Replace(ItemList.Item(i, 2), "=> ", Nothing)
      Next
      For i As Integer = 1 To DiscountList.Rows.Count - 1
        DiscountList.Item(i, 1) = Replace(DiscountList.Item(i, 1), "=> ", Nothing)
      Next

      ' Block All Item For Temporary
      Call InitializeItemToDisc(True)

      ' Filter Discount Code Here
      If .Item(.Row, 2) = True Then
        ShowMessage(Me, .Item(.Row, 4), True)
        ItemList.Row = Nothing
        Exit Sub
      Else
        Dim TMPCheck As FbDataReader
        TMPCheck = MyDatabase.MyReader("SELECT * FROM DISC WHERE DISCUID LIKE '" & .Item(.Row, 0) & "'")
        While TMPCheck.Read
          ' Check Purchase Limit
          If CDec(Me.ParentOBJForm.TotalPrice) >= CDec(TMPCheck.Item("DISCPURCHMINAMT")) Then
            LimitDiscount = CInt(TMPCheck.Item("DISCLIMIT"))

            ' Check Service type
            If CheckServiceType(.Item(.Row, 0)) = True Then

              'Check Customer Category 
              If CheckCategoryType(.Item(.Row, 0)) = True Then

                ' Check Combinated Indicator
                If CantCombine(.Item(.Row, 0)) Then
                  For j As Integer = 1 To ItemList.Rows.Count - 1
                    If Len(ItemList.Item(j, 4)) > 0 And ItemList.Item(j, 4) <> .Item(.Row, 0) Then
                      'ShowMessage(Me, "Maaf, diskon ini tidak dapat digabungkan dengan diskon yang lain !", True)
                      .Item(.Row, 3) = True
                      ItemList.Row = Nothing
                      Exit Sub
                    End If
                  Next
                Else
                  For j As Integer = 1 To ItemList.Rows.Count - 1
                    If ItemList.Item(j, 8) = True Then
                      ShowMessage(Me, "Maaf, kombinasi diskon sudah ada !", True)
                      ItemList.Row = Nothing
                      Exit Sub
                    End If
                  Next
                End If

                ' Check Products List To Disc
                Dim FoundProductToDisc As Boolean = False
                Dim TMPProduct As FbDataReader
                TMPProduct = MyDatabase.MyReader("SELECT * FROM DISCPRODUCTTODISC WHERE DISCUID ='" & .Item(.Row, 0) & "'")
                While TMPProduct.Read
                  With ItemList
                    For i As Integer = 1 To .Rows.Count - 1
                      If Trim(TMPProduct.Item("PRODUCTUID")) = Trim(.Item(i, 1)) Then
                        FoundProductToDisc = True
                        Exit While
                      End If
                    Next
                  End With
                End While

                TMPProduct = Nothing
                If FoundProductToDisc Or CStr(TMPCheck.Item("DISCTYPEOPTID")) = "1" Then

                  ' Filter By Discount Type
                  Select Case CStr(TMPCheck.Item("DISCTYPEOPTID"))
                    Case "1" ' Any Products Type
                      ' Enabled all items
                      For i As Integer = 1 To ItemList.Rows.Count - 1
                        ItemList.Item(i, 7) = False
                      Next

                    Case "2", "3" ' Specific Product & Quantity Type
                      ' Enabled items that are listed
                      TMPProduct = MyDatabase.MyReader("SELECT * FROM DISCPRODUCTTODISC WHERE DISCUID ='" & .Item(.Row, 0) & "'")
                      While TMPProduct.Read
                        With ItemList
                          For i As Integer = 1 To .Rows.Count - 1
                            If Trim(TMPProduct.Item("PRODUCTUID")) = Trim(.Item(i, 1)) Then
                              .Item(i, 7) = False
                            End If
                          Next
                        End With
                      End While

                    Case "4" ' Combination Type
                      ' Check Required List To Disc
                      Dim FoundProductRequired As Boolean = False
                      Dim TMPRequired As FbDataReader
                      TMPRequired = MyDatabase.MyReader("SELECT * FROM DISCREQUIREDPRODUCT WHERE DISCUID ='" & .Item(.Row, 0) & "'")
                      While TMPRequired.Read
                        With ItemList
                          Select Case CStr(TMPCheck.Item("DISCREQUIREDPRODUCTISANY"))
                            Case "0" ' All Product in The Required List
                              FoundProductRequired = False
                              For i As Integer = 1 To .Rows.Count - 1
                                If Trim(TMPRequired.Item("PRODUCTUID")) = Trim(.Item(i, 1)) Then
                                  FoundProductRequired = True
                                  Exit For
                                End If
                              Next
                              If Not FoundProductRequired Then Exit While
                            Case "1" ' Any Product in The Required List
                              For i As Integer = 1 To .Rows.Count - 1
                                If Trim(TMPRequired.Item("PRODUCTUID")) = Trim(.Item(i, 1)) Then
                                  FoundProductRequired = True
                                  Exit While
                                End If
                              Next
                          End Select
                        End With
                      End While

                      If FoundProductRequired Then
                        ' Enabled items that are listed
                        TMPProduct = MyDatabase.MyReader("SELECT * FROM DISCPRODUCTTODISC WHERE DISCUID ='" & .Item(.Row, 0) & "'")
                        While TMPProduct.Read
                          With ItemList
                            For i As Integer = 1 To .Rows.Count - 1
                              If Trim(TMPProduct.Item("PRODUCTUID")) = Trim(.Item(i, 1)) Then
                                .Item(i, 7) = False
                              End If
                            Next
                          End With
                        End While
                      Else
                        If CStr(TMPCheck.Item("DISCREQUIREDPRODUCTISANY")) = "0" Then
                          ShowMessage(Me, "Maaf, diskon hanya berlaku apabila semua item yang harus dipesan ada dalam tagihan !", True)
                          ItemList.Row = Nothing
                        Else
                          ShowMessage(Me, "Maaf, diskon hanya berlaku apabila semua item yang harus dipesan ada dalam tagihan !", True)
                          ItemList.Row = Nothing
                        End If
                        .Item(.Row, 3) = True
                        Exit Sub
                      End If

                  End Select

                Else
                  ShowMessage(Me, "Maaf, diskon hanya berlaku apabila menu yang didiskon ada dalam tagihan !", True)
                  .Item(.Row, 3) = True
                  ItemList.Row = Nothing
                  Exit Sub
                End If
              Else
                ShowMessage(Me, "Maaf, diskon hanya berlaku untuk category customer '" & GetCustomerCategoryName(.Item(.Row, 0)) & "'", True)
                .Item(.Row, 3) = True
                ItemList.Row = Nothing
                Exit Sub
              End If
            Else
              ShowMessage(Me, "Maaf, diskon hanya berlaku untuk tipe servis '" & GetServiceName(.Item(.Row, 0)) & "'", True)
              .Item(.Row, 3) = True
              ItemList.Row = Nothing
              Exit Sub
            End If

          Else
            ShowMessage(Me, "Maaf, diskon hanya berlaku untuk pembelian minimal " & FormatNumber(TMPCheck.Item("DISCPURCHMINAMT"), 0, TriState.True, TriState.True, TriState.True) & " !", True)
            .Item(.Row, 3) = True
            ItemList.Row = Nothing
            Exit Sub
          End If

        End While

        If Mid(DiscountList.Item(DiscountList.Row, 1), 1, 3) <> "=> " Then DiscountList.Item(DiscountList.Row, 1) = "=> " & DiscountList.Item(DiscountList.Row, 1)
        Call InitializeItemToDisc(False)

      End If
    End With
    VIsSaveOk = True
  End Sub

  Private Sub ItemList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ItemList.Click
    With ItemList
      If .Row <= 0 Then Exit Sub
      'For i As Integer = 1 To .Rows.Count - 1
      '    .Item(i, 2) = Replace(.Item(i, 2), "=> ", Nothing)
      'Next

      ' Check the existence of discount 
      If FindSelectedRow(DiscountList) <= 0 Then
        If PrefInfo.VIsAutoDisc = False Then ShowMessage(Me, "Silakan pilih tipe diskon terlebih dahulu !", True)
        ItemList.Row = Nothing
        Exit Sub
      End If

      ' Get Selection Current Position
      Dim iRow1 As Integer, iRow2 As Integer
      iRow1 = IIf(.Selection.r1 = 0, 1, .Selection.r1)
      iRow2 = IIf(.Selection.r2 >= .Rows.Count, .Rows.Count - 1, .Selection.r2)

      ' Fixed Start Position
      If iRow1 Mod 3 <> 1 Then
        If iRow1 <= 3 Then
          iRow1 = 1
        Else
          iRow1 = iRow1 - 1
        End If
      End If

      ' Fixed End Position
      If iRow2 Mod 3 <> 2 Then
        If iRow2 <= 3 Then
          iRow2 = 2
        Else
          iRow2 = iRow2 + 1
        End If
      End If

      ' Generate Selection Item position
      Dim FindValidItem As Boolean = False
      Dim ClearBypass As Boolean = False
      For i As Integer = iRow1 To iRow2
        If i Mod 3 = 2 Then
          i = i - 1
        ElseIf i Mod 3 = 0 Then
          i = i + 1
        End If

        ' Only apply to the valid item
        If i >= .Rows.Count Then Exit For
        If .Item(i, 7) = False Then
          If Mid(.Item(i, 2), 1, 3) <> "=> " Then
            FindValidItem = True
            For j As Integer = 0 To 1
              .Item(i + j, 2) = "=> " & .Item(i + j, 2)
            Next
          Else
            ClearBypass = True
            For j As Integer = 0 To 1
              .Item(i + j, 2) = Replace(.Item(i, 2), "=> ", Nothing)
            Next
          End If
        End If
        i = i + 2
      Next

      If ClearBypass Then Exit Sub
      If Not FindValidItem Then
        ShowMessage(Me, "Maaf, item ini tidak termasuk dalam diskon '" & Replace(DiscountList.Item(FindSelectedRow(DiscountList), 1), "=> ", Nothing) & "'", True)
        ItemList.Row = Nothing
        Exit Sub
      End If

    End With
  End Sub

  Private Function CheckAdaDiskonDipakaiUlang() As Boolean

    Dim selectedNamaDiskon As String = Mid(DiscountList.Item(FindSelectedRow(DiscountList), 1), 4, 1000)
    With ItemList
      For counter As Integer = 1 To .Rows.Count - 1 Step 3
        If Len(.Item(counter, 2)) > 3 Then
          If Mid(.Item(counter, 2), 1, 3) = "=> " Then
            If .Item(counter, 5) = selectedNamaDiskon Or .Item(counter + 1, 5) = selectedNamaDiskon Then CheckAdaDiskonDipakaiUlang = True : Exit Function
          End If
        End If
      Next
    End With

    CheckAdaDiskonDipakaiUlang = False

  End Function

  Private Sub BTNApply_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNApply.Click
    VIsSaveOk = False
    Me.Cursor = Cursors.WaitCursor
    If FindSelectedRow(DiscountList) <= 0 Then
      Me.Cursor = Cursors.Default
      If PrefInfo.VIsAutoDisc = False Then ShowMessage(Me, "Silakan pilih tipe diskon terlebih dahulu !", True)
      ItemList.Row = Nothing
      Exit Sub
    ElseIf FindSelectedRow(ItemList) <= 0 Then
      Me.Cursor = Cursors.Default
      If PrefInfo.VIsAutoDisc = False Then ShowMessage(Me, "Silakan pilih item yang akan didiskon terlebih dahulu !", True)
      ItemList.Row = Nothing
      Exit Sub
    ElseIf CheckAdaDiskonDipakaiUlang() Then
      Me.Cursor = Cursors.Default
      ShowMessage(Me, "Maaf, diskon yang sama tidak dapat digunakan 2x untuk item yang sama !", True)
      ItemList.Row = Nothing
      Exit Sub
    Else
      'Changed by Andy - 1April2011. Reader sering closed
      Dim TMPCheck As DataSet
      TMPCheck = MyDatabase.MyAdapter("SELECT * FROM DISC WHERE DISCUID ='" & DiscountList.Item(FindSelectedRow(DiscountList), 0) & "'")
      With ItemList
        If TMPCheck.Tables(0).Rows.Count > 0 Then
          ' Check Valid Account to access
          If Not CheckValidUser(DiscountList.Item(FindSelectedRow(DiscountList), 0)) Then
            Me.Cursor = Cursors.Default
            If ShowQuestion(Me, "Maaf, anda tidak mempunyai akses terhadap diskon ini !" & vbNewLine & "Silakan login sebagai user lain agar diskon dapat ditambahkan. Lanjutkan ?", True) = False Then Exit Sub
            Me.Cursor = Cursors.WaitCursor
            'Dim CustDialog As New Form_Make_Bill_User
            'SwitchUserAccess = False

            'CustDialog.Name = "Form_Make_Bill_User"
            'CustDialog.ParentOBJForm = Me
            'CustDialog.DiscUID = DiscountList.Item(DiscountList.Row, 0)
            'CustDialog.ShowDialog()

            UUID = UserInformation.UserUID
            UName = UserInformation.UserName
            UOrderPoint = UserInformation.UserOrderPoint
            UTypeUID = UserInformation.UserTypeUID
            UDeptUID = UserInformation.UserDeptUID
            'Dim OBJNew As New Form_Sign_In
            'OBJNew.Name = "Form_Sign_In"
            'OBJNew.Cancel.Visible = False
            'OBJNew.BTNClose.Visible = True
            'OBJNew.BTNClose.Location = New System.Drawing.Point(408, 117)
            'OBJNew.ShowDialog()

            Dim OBJNew As New Form_Log_In
            OBJNew.Name = "Form_Log_In"
            OBJNew.BTNQuit.Visible = False
            OBJNew.ShowDialog()

            Call MainPage.StatusBarInitialize()
            ChangeAccount = True

            Call BTNApply_Click(sender, e)

            If ChangeAccount = True Then
              ChangeAccount = False
              UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, , UDeptUID)
              Call MainPage.StatusBarInitialize()
            End If

            If Not SwitchUserAccess Then Me.Cursor = Cursors.Default : Exit Sub
          End If

          ' All Discount Applied is Here !
          Dim DiscountMaxLimit As Integer = TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")

          ' Check Max Disc Limit Before Process
          If CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")) > 0 And ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)) >= CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")) Then
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Maaf, diskon ini hanya dapat digunakan " & TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT") & "x untuk setiap transaksi !", True)
            ItemList.Row = Nothing
            Exit Sub
          End If
          ' Filter By Discount Type
          Select Case CStr(TMPCheck.Tables(0).Rows(0).Item("DISCTYPEOPTID"))
            Case "1" ' Any Product
              ' Check Ask Mount Checked
              If TMPCheck.Tables(0).Rows(0).Item("DISCISASKAMOUNT") Then
                Dim AskDialog As New Form_Make_Bill_Ask_Mount
                AskDialog.Name = "Form_Make_Bill_Ask_Mount"
                AskDialog.ParentOBJForm = Me
                AskDialog.isPercentValue = CStr(TMPCheck.Tables(0).Rows(0).Item("DISCAMTOPTID")) = "1"
                AskDialog.ShowDialog()
                If AskMountValue < 0 Then
                  Me.Cursor = Cursors.Default
                  ShowMessage(Me, "Diskon telah berhasil dibatalkan !", True)
                  ItemList.Row = Nothing
                  Exit Sub
                End If
              Else
                AskMountValue = CDec(TMPCheck.Tables(0).Rows(0).Item("DISCAMT"))
                If AskMountValue < 0 Then
                  Me.Cursor = Cursors.Default
                  ShowMessage(Me, "Maaf, nilai diskon tidak boleh lebih kecil dari nol !", True)
                  ItemList.Row = Nothing
                  Exit Sub
                End If
              End If

              ' Variable
              Dim ApplyCancelled As Boolean
              Dim DiscLimitCount As Decimal = 0
              Dim existDiscCountItem As Decimal = 0
              Dim totQty As Decimal

              For q As Integer = 1 To .Rows.Count - 1
                If Mid(.Item(q, 2), 1, 3) = "=> " Then
                  totQty = totQty + .Item(q, 3)
                  q = q + 1
                End If
              Next

              For i As Integer = 1 To .Rows.Count - 1
                ' Check Max Disc Limit in Process
                If CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")) > 0 And ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)) >= CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")) Then Me.Cursor = Cursors.Default : Exit Sub

                If Mid(.Item(i, 2), 1, 3) = "=> " Then

                  ' Check Row Position of Discount
                  ApplyCancelled = False
                  If i Mod 3 = 1 Then
                    If Len(.Item(i, 4)) > 0 Then i = i + 1
                  End If
                  If i Mod 3 = 2 Then
                    If Len(.Item(i, 4)) > 0 Then
                      ApplyCancelled = True
                    End If
                  End If
                  If i Mod 3 = 0 Then
                    ApplyCancelled = True
                  End If

                  If i Mod 3 = 2 Then
                    If .Item(i - 1, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0) Then
                      Me.Cursor = Cursors.Default
                      ShowMessage(Me, "Maaf, program diskon ini hanya dapat digunakan 1x saja !", True)
                      ItemList.Row = Nothing
                      Exit Sub
                    End If
                  End If

                  ' Filter By Amount Is
                  If Not ApplyCancelled Then
                    Dim CurrentPrice As Decimal = IIf(i Mod 3 = 1, .Item(i, 6), .Item(i - 1, 6))
                    .Item(i, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0)
                    .Item(i, 5) = Replace(DiscountList.Item(FindSelectedRow(DiscountList), 1), "=> ", Nothing)

                    ' Generate New Discount
                    Dim NewGenerateValue As New DiscGenerateResultLib
                    If TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT") = 0 Then
                      NewGenerateValue = DiscountGenerateAnyProduct(Val(TMPCheck.Tables(0).Rows(0).Item("DISCAMTOPTID")), CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")), CurrentPrice, .Item(i, 3), AskMountValue, totQty)
                    Else
                      NewGenerateValue = DiscountGenerateAnyProduct(Val(TMPCheck.Tables(0).Rows(0).Item("DISCAMTOPTID")), CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")) - ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)), CurrentPrice, .Item(i, 3), AskMountValue, totQty)
                    End If

                    'If .Item(i, 6) <= 0 Then .Item(i, 6) = CurrentPrice
                    If AskMountValue > 0 Then
                      .Item(i, 10) = NewGenerateValue.DiscountValue
                    Else
                      .Item(i, 10) = NewGenerateValue.DiscountValue
                    End If

                    .Item(i, 11) = NewGenerateValue.NewPriceAfterDisc
                    .Item(i, 9) = NewGenerateValue.DiscItemCount

                    If CantCombine(DiscountList.Item(DiscountList.Row, 0)) Then
                      .Item(i, 8) = True
                    End If

                    ' Jump to Next Row Position
                    If i Mod 3 = 1 Then
                      i = i + 2
                    Else
                      i = i + 1
                    End If
                  Else
                    Me.Cursor = Cursors.Default
                    ShowMessage(Me, "Maaf, program diskon ini hanya dapat digunakan maksimum 2x !", True)
                  End If
                End If
              Next

            Case "2" ' Specific Product
              ' Check Ask Mount Checked
              If TMPCheck.Tables(0).Rows(0).Item("DISCISASKAMOUNT") Then

                Dim AskDialog As New Form_Make_Bill_Ask_Mount
                AskDialog.Name = "Form_Make_Bill_Ask_Mount"
                AskDialog.ParentOBJForm = Me
                AskDialog.isPercentValue = CStr(TMPCheck.Tables(0).Rows(0).Item("DISCAMTOPTID")) = "1"
                AskDialog.ShowDialog()
                If AskMountValue < 0 Then
                  Me.Cursor = Cursors.Default
                  ShowMessage(Me, "Diskon telah berhasil dibatalkan !", True)
                  ItemList.Row = Nothing
                  Exit Sub
                End If
              Else
                AskMountValue = CDec(TMPCheck.Tables(0).Rows(0).Item("DISCAMT"))
                If AskMountValue < 0 Then
                  Me.Cursor = Cursors.Default
                  ShowMessage(Me, "Maaf, nilai diskon tidak boleh lebih kecil dari nol !", True)
                  ItemList.Row = Nothing
                  Exit Sub
                End If
              End If

              ' Variable
              Dim ApplyCancelled As Boolean
              Dim DiscLimitCount As Decimal = 0
              Dim totQty As Decimal

              For q As Integer = 1 To .Rows.Count - 1
                If Mid(.Item(q, 2), 1, 3) = "=> " Then
                  totQty = totQty + .Item(q, 3)
                  q = q + 1
                End If
              Next

              For i As Integer = 1 To .Rows.Count - 1
                ' Check Max Disc Limit in Process
                If CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")) > 0 And ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)) >= CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")) Then Me.Cursor = Cursors.Default : Exit Sub

                If Mid(.Item(i, 2), 1, 3) = "=> " Then
                  ' Check Row Position of Discount
                  ApplyCancelled = False
                  If i Mod 3 = 1 Then
                    If Len(.Item(i, 4)) > 0 Then i = i + 1
                  End If
                  If i Mod 3 = 2 Then
                    If Len(.Item(i, 4)) > 0 Then
                      ApplyCancelled = True
                    End If
                  End If
                  If i Mod 3 = 0 Then
                    ApplyCancelled = True
                  End If

                  If i Mod 3 = 2 Then
                    If .Item(i - 1, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0) Then
                      Me.Cursor = Cursors.Default
                      ShowMessage(Me, "Maaf, diskon ini hanya dapat digunakan 1x saja !", True)
                      ItemList.Row = Nothing
                      Exit Sub
                    End If
                  End If

                  ' Filter By Amount Is
                  If Not ApplyCancelled Then
                    Dim CurrentPrice As Decimal = IIf(i Mod 3 = 1, .Item(i, 6), .Item(i - 1, 6))
                    .Item(i, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0)
                    .Item(i, 5) = Replace(DiscountList.Item(FindSelectedRow(DiscountList), 1), "=> ", Nothing)

                    ' Generate New Discount
                    Dim NewGenerateValue As New DiscGenerateResultLib
                    If TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT") = 0 Then
                      NewGenerateValue = DiscountGenerateSpecificProduct(Val(TMPCheck.Tables(0).Rows(0).Item("DISCAMTOPTID")), CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")), CurrentPrice, .Item(i, 3), DiscountList.Item(FindSelectedRow(DiscountList), 0), .Item(i, 1), totQty, AskMountValue)
                    Else
                      NewGenerateValue = DiscountGenerateSpecificProduct(Val(TMPCheck.Tables(0).Rows(0).Item("DISCAMTOPTID")), CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")) - ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)), CurrentPrice, .Item(i, 3), DiscountList.Item(FindSelectedRow(DiscountList), 0), .Item(i, 1), totQty, AskMountValue)
                    End If

                    'If .Item(i, 6) <= 0 Then .Item(i, 6) = CurrentPrice
                    If AskMountValue > 0 Then
                      .Item(i, 10) = NewGenerateValue.DiscountValue
                    Else
                      .Item(i, 10) = NewGenerateValue.DiscountValue
                    End If
                    .Item(i, 11) = NewGenerateValue.NewPriceAfterDisc
                    .Item(i, 9) = NewGenerateValue.DiscItemCount

                    ' Jump to Next Row Position
                    If i Mod 3 = 1 Then
                      i = i + 2
                    Else
                      i = i + 1
                    End If
                  Else
                    Me.Cursor = Cursors.Default
                    ShowMessage(Me, "Maaf, program diskon ini hanya dapat digunakan maksimum 2x !", True)
                  End If
                End If
              Next

            Case "3" ' Quantity
              ' Check Ask Mount Checked
              If TMPCheck.Tables(0).Rows(0).Item("DISCISASKAMOUNT") Then
                Dim AskDialog As New Form_Make_Bill_Ask_Mount
                AskDialog.Name = "Form_Make_Bill_Ask_Mount"
                AskDialog.ParentOBJForm = Me
                AskDialog.isPercentValue = CStr(TMPCheck.Tables(0).Rows(0).Item("DISCAMTOPTID")) = "1"
                AskDialog.ShowDialog()
                If AskMountValue < 0 Then
                  Me.Cursor = Cursors.Default
                  ShowMessage(Me, "Diskon telah berhasil dibatalkan !", True)
                  ItemList.Row = Nothing
                  Exit Sub
                End If
              Else
                AskMountValue = CDec(TMPCheck.Tables(0).Rows(0).Item("DISCAMT"))
                If AskMountValue < 0 Then
                  Me.Cursor = Cursors.Default
                  ShowMessage(Me, "Maaf, nilai diskon tidak boleh lebih kecil dari nol !", True)
                  ItemList.Row = Nothing
                  Exit Sub
                End If
              End If

              ' Variable
              Dim ApplyCancelled As Boolean
              Dim DiscLimitCount As Integer = 0
              ' Added By Rudy 13 Sept 2011
              Dim DISCUID As String = DiscountList.Item(FindSelectedRow(DiscountList), 0)
              Dim SelectedQty As Decimal = GetTotalItemDipilih()
              Dim ItemToDiscCount As Decimal = IIf(CDec(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")) = 0, SelectedQty, IIf(SelectedQty >= CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")), CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")), SelectedQty))
              Dim QTYBuy As Decimal = 0
              Dim QTYGet As Decimal = 0
              Dim Bayar As Decimal = 0
              Dim BayarPlus As Decimal = 0
              Dim Gratis As Decimal = 0
              Dim Counter As Decimal = 0

              Dim TMPRecord As FbDataReader
              TMPRecord = MyDatabase.MyReader("SELECT DISCQTYBUY, DISCQTYGET FROM DISC WHERE DISCUID ='" & DISCUID & "'")
              While TMPRecord.Read
                QTYBuy = CDec(TMPRecord.Item("DISCQTYBUY"))
                QTYGet = CDec(TMPRecord.Item("DISCQTYGET"))
                If QTYBuy + QTYGet = 0 Then
                  Bayar = 0 'Fix(SelectedQty / (QTYBuy + QTYGet)) * QTYBuy
                  BayarPlus = 0
                Else
                  Bayar = Fix(SelectedQty / (QTYBuy + QTYGet)) * QTYBuy
                  If SelectedQty Mod (QTYBuy + QTYGet) <= QTYBuy Then
                    BayarPlus = SelectedQty Mod (QTYBuy + QTYGet)
                  Else
                    BayarPlus = QTYBuy
                  End If
                End If
                Gratis = SelectedQty - Bayar - BayarPlus
              End While

              If Gratis > ItemToDiscCount Then Gratis = ItemToDiscCount

              For i As Integer = 1 To .Rows.Count - 1
                ' Check Max Disc Limit in Process
                If CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")) > 0 And ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)) >= CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")) Then Me.Cursor = Cursors.Default : Exit Sub

                If Mid(.Item(i, 2), 1, 3) = "=> " Then
                  ' Check Row Position of Discount
                  ApplyCancelled = False
                  If i Mod 3 = 1 Then
                    If Len(.Item(i, 4)) > 0 Then i = i + 1
                  End If
                  If i Mod 3 = 2 Then
                    If Len(.Item(i, 4)) > 0 Then
                      ApplyCancelled = True
                    End If
                  End If
                  If i Mod 3 = 0 Then
                    ApplyCancelled = True
                  End If

                  If i Mod 3 = 2 Then
                    If .Item(i - 1, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0) Then
                      Me.Cursor = Cursors.Default
                      ShowMessage(Me, "Maaf, program diskon ini hanya dapat digunakan 1x saja ", True)
                      ItemList.Row = Nothing
                      Exit Sub
                    End If
                  End If

                  ' Filter By Amount Is
                  If Not ApplyCancelled Then
                    Dim CurrentPrice As Decimal = IIf(i Mod 3 = 1, .Item(i, 6), .Item(i - 1, 6))
                    .Item(i, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0)
                    .Item(i, 5) = Replace(DiscountList.Item(FindSelectedRow(DiscountList), 1), "=> ", Nothing)

                    ' Added By Rudy
                    If Gratis > .Item(i, 3) Then Counter = .Item(i, 3)
                    If Gratis <= .Item(i, 3) Then Counter = Gratis


                    ' Generate New Discount
                    Dim NewGenerateValue As New DiscGenerateResultLib
                    If TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT") = 0 Then
                      NewGenerateValue = DiscountGenerateQuantityLow(Val(TMPCheck.Tables(0).Rows(0).Item("DISCAMTOPTID")), DiscountList.Item(FindSelectedRow(DiscountList), 0), CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")), CurrentPrice, Counter, AskMountValue)
                    Else
                      NewGenerateValue = DiscountGenerateQuantityLow(Val(TMPCheck.Tables(0).Rows(0).Item("DISCAMTOPTID")), DiscountList.Item(FindSelectedRow(DiscountList), 0), CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")) - ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)), CurrentPrice, Counter, AskMountValue)
                    End If
                    'Added By Rudy 13 Sept 2011
                    If (Gratis - .Item(i, 3)) <= 0 Then
                      Gratis = 0
                    Else
                      Gratis = Gratis - .Item(i, 3)
                    End If

                    'If .Item(i, 6) <= 0 Then .Item(i, 6) = CurrentPrice
                    If AskMountValue > 0 Then
                      .Item(i, 10) = NewGenerateValue.DiscountValue
                    Else
                      .Item(i, 10) = NewGenerateValue.DiscountValue
                    End If
                    .Item(i, 11) = NewGenerateValue.NewPriceAfterDisc
                    .Item(i, 9) = NewGenerateValue.DiscItemCount


                    ' Jump to Next Row Position
                    If i Mod 3 = 1 Then
                      i = i + 2
                    Else
                      i = i + 1
                    End If
                  Else
                    Me.Cursor = Cursors.Default
                    ShowMessage(Me, "Maaf, program diskon ini hanya dapat digunakan maksimum 2x !", True)
                  End If
                End If
              Next

            Case "4" ' Combination
              ' Check Ask Mount Checked
              If TMPCheck.Tables(0).Rows(0).Item("DISCISASKAMOUNT") Then
                Dim AskDialog As New Form_Make_Bill_Ask_Mount
                AskDialog.Name = "Form_Make_Bill_Ask_Mount"
                AskDialog.ParentOBJForm = Me
                AskDialog.isPercentValue = CStr(TMPCheck.Tables(0).Rows(0).Item("DISCAMTOPTID")) = "1"
                AskDialog.ShowDialog()
                If AskMountValue < 0 Then
                  Me.Cursor = Cursors.Default
                  ShowMessage(Me, "Diskon ini telah berhasil dibatalkan !", True)
                  ItemList.Row = Nothing
                  Exit Sub
                End If
              Else
                AskMountValue = CDec(TMPCheck.Tables(0).Rows(0).Item("DISCAMT"))
                If AskMountValue < 0 Then
                  Me.Cursor = Cursors.Default
                  ShowMessage(Me, "Maaf, nilai diskon tidak boleh lebih kecil dari nol !", True)
                  ItemList.Row = Nothing
                  Exit Sub
                End If
              End If

              ' Variable
              Dim ApplyCancelled As Boolean
              Dim DiscLimitCount As Integer = 0

              For i As Integer = 1 To .Rows.Count - 1
                ' Check Max Disc Limit in Process
                If CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")) > 0 And ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)) >= CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")) Then Me.Cursor = Cursors.Default : Exit Sub

                If Mid(.Item(i, 2), 1, 3) = "=> " Then
                  ' Check Row Position of Discount
                  ApplyCancelled = False
                  If i Mod 3 = 1 Then
                    If Len(.Item(i, 4)) > 0 Then i = i + 1
                  End If
                  If i Mod 3 = 2 Then
                    If Len(.Item(i, 4)) > 0 Then
                      ApplyCancelled = True
                    End If
                  End If
                  If i Mod 3 = 0 Then
                    ApplyCancelled = True
                  End If

                  If i Mod 3 = 2 Then
                    If .Item(i - 1, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0) Then
                      Me.Cursor = Cursors.Default
                      ShowMessage(Me, "Maaf, program diskon ini hanya dapat digunakan 1x saja !", True)
                      ItemList.Row = Nothing
                      Exit Sub
                    End If
                  End If

                  ' Filter By Amount Is
                  If Not ApplyCancelled Then
                    Dim CurrentPrice As Decimal = IIf(i Mod 3 = 1, .Item(i, 6), .Item(i - 1, 6))
                    .Item(i, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0)
                    .Item(i, 5) = Replace(DiscountList.Item(FindSelectedRow(DiscountList), 1), "=> ", Nothing)


                    ' Generate New Discount
                    Dim NewGenerateValue As New DiscGenerateResultLib
                    If TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT") = 0 Then
                      NewGenerateValue = DiscountGenerateCombination(Val(TMPCheck.Tables(0).Rows(0).Item("DISCAMTOPTID")), CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")), CurrentPrice, .Item(i, 3), DiscountList.Item(FindSelectedRow(DiscountList), 0), .Item(i, 1), AskMountValue)
                    Else
                      NewGenerateValue = DiscountGenerateCombination(Val(TMPCheck.Tables(0).Rows(0).Item("DISCAMTOPTID")), CInt(TMPCheck.Tables(0).Rows(0).Item("DISCLIMIT")) - ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)), CurrentPrice, .Item(i, 3), DiscountList.Item(FindSelectedRow(DiscountList), 0), .Item(i, 1), AskMountValue)
                    End If

                    'If .Item(i, 6) <= 0 Then .Item(i, 6) = CurrentPrice
                    If AskMountValue > 0 Then
                      .Item(i, 10) = NewGenerateValue.DiscountValue
                    Else
                      .Item(i, 10) = NewGenerateValue.DiscountValue
                    End If
                    .Item(i, 11) = NewGenerateValue.NewPriceAfterDisc
                    .Item(i, 9) = NewGenerateValue.DiscItemCount

                    ' Jump to Next Row Position
                    If i Mod 3 = 1 Then
                      i = i + 2
                    Else
                      i = i + 1
                    End If
                  Else
                    Me.Cursor = Cursors.Default
                    ShowMessage(Me, "Maaf, progam diskon ini hanya dapat digunakan maksimum 2x !", True)
                  End If
                End If
              Next
          End Select
        End If
      End With

      ' uncheck all item
      For i As Integer = 1 To ItemList.Rows.Count - 1
        ItemList.Item(i, 2) = Replace(ItemList.Item(i, 2), "=> ", Nothing)
      Next
      ItemList.Row = Nothing

      x = 0
      AllItem.Image = My.Resources._NOTHING

      'Dim TMPCheck As FbDataReader
      'TMPCheck = MyDatabase.MyReader("SELECT * FROM DISC WHERE DISCUID ='" & DiscountList.Item(FindSelectedRow(DiscountList), 0) & "'")
      'With ItemList
      '    While TMPCheck.Read

      '        ' Check Valid Account to access
      '        If Not CheckValidUser(DiscountList.Item(FindSelectedRow(DiscountList), 0)) Then
      '            If ShowQuestion(Me, "Maaf, anda tidak mempunyai akses terhadap diskon ini !" & vbNewLine & "Silakan login sebagai user lain agar diskon dapat ditambahkan. Lanjutkan ?", True) = False Then Exit Sub

      '            'Dim CustDialog As New Form_Make_Bill_User
      '            'SwitchUserAccess = False

      '            'CustDialog.Name = "Form_Make_Bill_User"
      '            'CustDialog.ParentOBJForm = Me
      '            'CustDialog.DiscUID = DiscountList.Item(DiscountList.Row, 0)
      '            'CustDialog.ShowDialog()

      '            UUID = UserInformation.UserUID
      '            UName = UserInformation.UserName
      '            UOrderPoint = UserInformation.UserOrderPoint
      '            UTypeUID = UserInformation.UserTypeUID

      '            'Dim OBJNew As New Form_Sign_In
      '            'OBJNew.Name = "Form_Sign_In"
      '            'OBJNew.Cancel.Visible = False
      '            'OBJNew.BTNClose.Visible = True
      '            'OBJNew.BTNClose.Location = New System.Drawing.Point(408, 117)
      '            'OBJNew.ShowDialog()

      '            Dim OBJNew As New Form_Log_In
      '            OBJNew.Name = "Form_Log_In"
      '            OBJNew.BTNQuit.Visible = False
      '            OBJNew.ShowDialog()

      '            Call MainPage.StatusBarInitialize()
      '            ChangeAccount = True

      '            Call BTNApply_Click(sender, e)

      '            If ChangeAccount = True Then
      '                ChangeAccount = False
      '                UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID,udeptuid)
      '                Call MainPage.StatusBarInitialize()
      '            End If

      '            If Not SwitchUserAccess Then Exit Sub
      '        End If

      '        ' All Discount Applied is Here !
      '        Dim DiscountMaxLimit As Integer = TMPCheck.Item("DISCLIMIT")

      '        ' Check Max Disc Limit Before Process
      '        If CInt(TMPCheck.Item("DISCLIMIT")) > 0 And ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)) >= CInt(TMPCheck.Item("DISCLIMIT")) Then
      '            ShowMessage(Me, "Maaf, diskon ini hanya dapat digunakan " & TMPCheck.Item("DISCLIMIT") & "x untuk setiap transaksi !", True)
      '            ItemList.Row = Nothing
      '            Exit Sub
      '        End If

      '        ' Filter By Discount Type
      '        Select Case CStr(TMPCheck.Item("DISCTYPEOPTID"))
      '            Case "1" ' Any Product
      '                ' Check Ask Mount Checked
      '                If TMPCheck.Item("DISCISASKAMOUNT") Then
      '                    Dim AskDialog As New Form_Make_Bill_Ask_Mount
      '                    AskDialog.Name = "Form_Make_Bill_Ask_Mount"
      '                    AskDialog.ParentOBJForm = Me
      '                    AskDialog.isPercentValue = CStr(TMPCheck.Item("DISCAMTOPTID")) = "1"
      '                    AskDialog.ShowDialog()
      '                    If AskMountValue < 0 Then
      '                        ShowMessage(Me, "Diskon telah berhasil dibatalkan !", True)
      '                        ItemList.Row = Nothing
      '                        Exit Sub
      '                    End If
      '                Else
      '                    AskMountValue = CDec(TMPCheck.Item("DISCAMT"))
      '                    If AskMountValue < 0 Then
      '                        ShowMessage(Me, "Maaf, nilai diskon tidak boleh lebih kecil dari nol !", True)
      '                        ItemList.Row = Nothing
      '                        Exit Sub
      '                    End If
      '                End If

      '                ' Variable
      '                Dim ApplyCancelled As Boolean
      '                Dim DiscLimitCount As Integer = 0
      '                Dim existDiscCountItem As Integer = 0
      '                Dim totQty As Decimal

      '                For q As Integer = 1 To .Rows.Count - 1
      '                    If Mid(.Item(q, 2), 1, 3) = "=> " Then
      '                        totQty = totQty + .Item(q, 3)
      '                        q = q + 1
      '                    End If
      '                Next

      '                For i As Integer = 1 To .Rows.Count - 1
      '                    ' Check Max Disc Limit in Process
      '                    If CInt(TMPCheck.Item("DISCLIMIT")) > 0 And ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)) >= CInt(TMPCheck.Item("DISCLIMIT")) Then Exit Sub

      '                    If Mid(.Item(i, 2), 1, 3) = "=> " Then

      '                        ' Check Row Position of Discount
      '                        ApplyCancelled = False
      '                        If i Mod 3 = 1 Then
      '                            If Len(.Item(i, 4)) > 0 Then i = i + 1
      '                        End If
      '                        If i Mod 3 = 2 Then
      '                            If Len(.Item(i, 4)) > 0 Then
      '                                ApplyCancelled = True
      '                            End If
      '                        End If
      '                        If i Mod 3 = 0 Then
      '                            ApplyCancelled = True
      '                        End If

      '                        If i Mod 3 = 2 Then
      '                            If .Item(i - 1, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0) Then
      '                                ShowMessage(Me, "Maaf, program diskon ini hanya dapat digunakan 1x saja !", True)
      '                                ItemList.Row = Nothing
      '                                Exit Sub
      '                            End If
      '                        End If

      '                        ' Filter By Amount Is
      '                        If Not ApplyCancelled Then
      '                            Dim CurrentPrice As Decimal = IIf(i Mod 3 = 1, .Item(i, 6), .Item(i - 1, 6))
      '                            .Item(i, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0)
      '                            .Item(i, 5) = Replace(DiscountList.Item(FindSelectedRow(DiscountList), 1), "=> ", Nothing)

      '                            ' Generate New Discount
      '                            Dim NewGenerateValue As New DiscGenerateResultLib
      '                            If TMPCheck.Item("DISCLIMIT") = 0 Then
      '                                NewGenerateValue = DiscountGenerateAnyProduct(Val(TMPCheck.Item("DISCAMTOPTID")), CInt(TMPCheck.Item("DISCLIMIT")), CurrentPrice, .Item(i, 3), AskMountValue, totQty)
      '                            Else
      '                                NewGenerateValue = DiscountGenerateAnyProduct(Val(TMPCheck.Item("DISCAMTOPTID")), CInt(TMPCheck.Item("DISCLIMIT")) - ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)), CurrentPrice, .Item(i, 3), AskMountValue, totQty)
      '                            End If

      '                            'If .Item(i, 6) <= 0 Then .Item(i, 6) = CurrentPrice
      '                            If AskMountValue > 0 Then
      '                                .Item(i, 10) = NewGenerateValue.DiscountValue
      '                            Else
      '                                .Item(i, 10) = NewGenerateValue.DiscountValue
      '                            End If

      '                            .Item(i, 11) = NewGenerateValue.NewPriceAfterDisc
      '                            .Item(i, 9) = NewGenerateValue.DiscItemCount

      '                            If CantCombine(DiscountList.Item(DiscountList.Row, 0)) Then
      '                                .Item(i, 8) = True
      '                            End If

      '                            ' Jump to Next Row Position
      '                            If i Mod 3 = 1 Then
      '                                i = i + 2
      '                            Else
      '                                i = i + 1
      '                            End If
      '                        Else
      '                            ShowMessage(Me, "Maaf, program diskon ini hanya dapat digunakan maksimum 2x !", True)
      '                        End If
      '                    End If
      '                Next

      '            Case "2" ' Specific Product
      '                ' Check Ask Mount Checked
      '                If TMPCheck.Item("DISCISASKAMOUNT") Then

      '                    Dim AskDialog As New Form_Make_Bill_Ask_Mount
      '                    AskDialog.Name = "Form_Make_Bill_Ask_Mount"
      '                    AskDialog.ParentOBJForm = Me
      '                    AskDialog.isPercentValue = CStr(TMPCheck.Item("DISCAMTOPTID")) = "1"
      '                    AskDialog.ShowDialog()
      '                    If AskMountValue < 0 Then
      '                        ShowMessage(Me, "Diskon telah berhasil dibatalkan !", True)
      '                        ItemList.Row = Nothing
      '                        Exit Sub
      '                    End If
      '                Else
      '                    AskMountValue = CDec(TMPCheck.Item("DISCAMT"))
      '                    If AskMountValue < 0 Then
      '                        ShowMessage(Me, "Maaf, nilai diskon tidak boleh lebih kecil dari nol !", True)
      '                        ItemList.Row = Nothing
      '                        Exit Sub
      '                    End If
      '                End If

      '                ' Variable
      '                Dim ApplyCancelled As Boolean
      '                Dim DiscLimitCount As Integer = 0
      '                Dim totQty As Decimal

      '                For q As Integer = 1 To .Rows.Count - 1
      '                    If Mid(.Item(q, 2), 1, 3) = "=> " Then
      '                        totQty = totQty + .Item(q, 3)
      '                        q = q + 1
      '                    End If
      '                Next

      '                For i As Integer = 1 To .Rows.Count - 1
      '                    ' Check Max Disc Limit in Process
      '                    If CInt(TMPCheck.Item("DISCLIMIT")) > 0 And ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)) >= CInt(TMPCheck.Item("DISCLIMIT")) Then Exit Sub

      '                    If Mid(.Item(i, 2), 1, 3) = "=> " Then
      '                        ' Check Row Position of Discount
      '                        ApplyCancelled = False
      '                        If i Mod 3 = 1 Then
      '                            If Len(.Item(i, 4)) > 0 Then i = i + 1
      '                        End If
      '                        If i Mod 3 = 2 Then
      '                            If Len(.Item(i, 4)) > 0 Then
      '                                ApplyCancelled = True
      '                            End If
      '                        End If
      '                        If i Mod 3 = 0 Then
      '                            ApplyCancelled = True
      '                        End If

      '                        If i Mod 3 = 2 Then
      '                            If .Item(i - 1, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0) Then
      '                                ShowMessage(Me, "Maaf, diskon ini hanya dapat digunakan 1x saja !", True)
      '                                ItemList.Row = Nothing
      '                                Exit Sub
      '                            End If
      '                        End If

      '                        ' Filter By Amount Is
      '                        If Not ApplyCancelled Then
      '                            Dim CurrentPrice As Decimal = IIf(i Mod 3 = 1, .Item(i, 6), .Item(i - 1, 6))
      '                            .Item(i, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0)
      '                            .Item(i, 5) = Replace(DiscountList.Item(FindSelectedRow(DiscountList), 1), "=> ", Nothing)

      '                            ' Generate New Discount
      '                            Dim NewGenerateValue As New DiscGenerateResultLib
      '                            If TMPCheck.Item("DISCLIMIT") = 0 Then
      '                                NewGenerateValue = DiscountGenerateSpecificProduct(Val(TMPCheck.Item("DISCAMTOPTID")), CInt(TMPCheck.Item("DISCLIMIT")), CurrentPrice, .Item(i, 3), DiscountList.Item(FindSelectedRow(DiscountList), 0), .Item(i, 1), totQty, AskMountValue)
      '                            Else
      '                                NewGenerateValue = DiscountGenerateSpecificProduct(Val(TMPCheck.Item("DISCAMTOPTID")), CInt(TMPCheck.Item("DISCLIMIT")) - ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)), CurrentPrice, .Item(i, 3), DiscountList.Item(FindSelectedRow(DiscountList), 0), .Item(i, 1), totQty, AskMountValue)
      '                            End If

      '                            'If .Item(i, 6) <= 0 Then .Item(i, 6) = CurrentPrice
      '                            If AskMountValue > 0 Then
      '                                .Item(i, 10) = NewGenerateValue.DiscountValue
      '                            Else
      '                                .Item(i, 10) = NewGenerateValue.DiscountValue
      '                            End If
      '                            .Item(i, 11) = NewGenerateValue.NewPriceAfterDisc
      '                            .Item(i, 9) = NewGenerateValue.DiscItemCount

      '                            ' Jump to Next Row Position
      '                            If i Mod 3 = 1 Then
      '                                i = i + 2
      '                            Else
      '                                i = i + 1
      '                            End If
      '                        Else
      '                            ShowMessage(Me, "Maaf, program diskon ini hanya dapat digunakan maksimum 2x !", True)
      '                        End If
      '                    End If
      '                Next

      '            Case "3" ' Quantity
      '                ' Check Ask Mount Checked
      '                If TMPCheck.Item("DISCISASKAMOUNT") Then
      '                    Dim AskDialog As New Form_Make_Bill_Ask_Mount
      '                    AskDialog.Name = "Form_Make_Bill_Ask_Mount"
      '                    AskDialog.ParentOBJForm = Me
      '                    AskDialog.isPercentValue = CStr(TMPCheck.Item("DISCAMTOPTID")) = "1"
      '                    AskDialog.ShowDialog()
      '                    If AskMountValue < 0 Then
      '                        ShowMessage(Me, "Diskon telah berhasil dibatalkan !", True)
      '                        ItemList.Row = Nothing
      '                        Exit Sub
      '                    End If
      '                Else
      '                    AskMountValue = CDec(TMPCheck.Item("DISCAMT"))
      '                    If AskMountValue < 0 Then
      '                        ShowMessage(Me, "Maaf, nilai diskon tidak boleh lebih kecil dari nol !", True)
      '                        ItemList.Row = Nothing
      '                        Exit Sub
      '                    End If
      '                End If

      '                ' Variable
      '                Dim ApplyCancelled As Boolean
      '                Dim DiscLimitCount As Integer = 0

      '                For i As Integer = 1 To .Rows.Count - 1
      '                    ' Check Max Disc Limit in Process
      '                    If CInt(TMPCheck.Item("DISCLIMIT")) > 0 And ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)) >= CInt(TMPCheck.Item("DISCLIMIT")) Then Exit Sub

      '                    If Mid(.Item(i, 2), 1, 3) = "=> " Then
      '                        ' Check Row Position of Discount
      '                        ApplyCancelled = False
      '                        If i Mod 3 = 1 Then
      '                            If Len(.Item(i, 4)) > 0 Then i = i + 1
      '                        End If
      '                        If i Mod 3 = 2 Then
      '                            If Len(.Item(i, 4)) > 0 Then
      '                                ApplyCancelled = True
      '                            End If
      '                        End If
      '                        If i Mod 3 = 0 Then
      '                            ApplyCancelled = True
      '                        End If

      '                        If i Mod 3 = 2 Then
      '                            If .Item(i - 1, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0) Then
      '                                ShowMessage(Me, "Maaf, program diskon ini hanya dapat digunakan 1x saja ", True)
      '                                ItemList.Row = Nothing
      '                                Exit Sub
      '                            End If
      '                        End If

      '                        ' Filter By Amount Is
      '                        If Not ApplyCancelled Then
      '                            Dim CurrentPrice As Decimal = IIf(i Mod 3 = 1, .Item(i, 6), .Item(i - 1, 6))
      '                            .Item(i, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0)
      '                            .Item(i, 5) = Replace(DiscountList.Item(FindSelectedRow(DiscountList), 1), "=> ", Nothing)


      '                            ' Generate New Discount
      '                            Dim NewGenerateValue As New DiscGenerateResultLib
      '                            If TMPCheck.Item("DISCLIMIT") = 0 Then
      '                                NewGenerateValue = DiscountGenerateQuantity(Val(TMPCheck.Item("DISCAMTOPTID")), DiscountList.Item(FindSelectedRow(DiscountList), 0), CInt(TMPCheck.Item("DISCLIMIT")), CurrentPrice, .Item(i, 3), AskMountValue)
      '                            Else
      '                                NewGenerateValue = DiscountGenerateQuantity(Val(TMPCheck.Item("DISCAMTOPTID")), DiscountList.Item(FindSelectedRow(DiscountList), 0), CInt(TMPCheck.Item("DISCLIMIT")) - ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)), CurrentPrice, .Item(i, 3), AskMountValue)
      '                            End If

      '                            'If .Item(i, 6) <= 0 Then .Item(i, 6) = CurrentPrice
      '                            If AskMountValue > 0 Then
      '                                .Item(i, 10) = NewGenerateValue.DiscountValue
      '                            Else
      '                                .Item(i, 10) = NewGenerateValue.DiscountValue
      '                            End If
      '                            .Item(i, 11) = NewGenerateValue.NewPriceAfterDisc
      '                            .Item(i, 9) = NewGenerateValue.DiscItemCount


      '                            ' Jump to Next Row Position
      '                            If i Mod 3 = 1 Then
      '                                i = i + 2
      '                            Else
      '                                i = i + 1
      '                            End If
      '                        Else
      '                            ShowMessage(Me, "Maaf, program diskon ini hanya dapat digunakan maksimum 2x !", True)
      '                        End If
      '                    End If
      '                Next

      '            Case "4" ' Combination
      '                ' Check Ask Mount Checked
      '                If TMPCheck.Item("DISCISASKAMOUNT") Then
      '                    Dim AskDialog As New Form_Make_Bill_Ask_Mount
      '                    AskDialog.Name = "Form_Make_Bill_Ask_Mount"
      '                    AskDialog.ParentOBJForm = Me
      '                    AskDialog.isPercentValue = CStr(TMPCheck.Item("DISCAMTOPTID")) = "1"
      '                    AskDialog.ShowDialog()
      '                    If AskMountValue < 0 Then
      '                        ShowMessage(Me, "Diskon ini telah berhasil dibatalkan !", True)
      '                        ItemList.Row = Nothing
      '                        Exit Sub
      '                    End If
      '                Else
      '                    AskMountValue = CDec(TMPCheck.Item("DISCAMT"))
      '                    If AskMountValue < 0 Then
      '                        ShowMessage(Me, "Maaf, nilai diskon tidak boleh lebih kecil dari nol !", True)
      '                        ItemList.Row = Nothing
      '                        Exit Sub
      '                    End If
      '                End If

      '                ' Variable
      '                Dim ApplyCancelled As Boolean
      '                Dim DiscLimitCount As Integer = 0

      '                For i As Integer = 1 To .Rows.Count - 1
      '                    ' Check Max Disc Limit in Process
      '                    If CInt(TMPCheck.Item("DISCLIMIT")) > 0 And ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)) >= CInt(TMPCheck.Item("DISCLIMIT")) Then Exit Sub

      '                    If Mid(.Item(i, 2), 1, 3) = "=> " Then
      '                        ' Check Row Position of Discount
      '                        ApplyCancelled = False
      '                        If i Mod 3 = 1 Then
      '                            If Len(.Item(i, 4)) > 0 Then i = i + 1
      '                        End If
      '                        If i Mod 3 = 2 Then
      '                            If Len(.Item(i, 4)) > 0 Then
      '                                ApplyCancelled = True
      '                            End If
      '                        End If
      '                        If i Mod 3 = 0 Then
      '                            ApplyCancelled = True
      '                        End If

      '                        If i Mod 3 = 2 Then
      '                            If .Item(i - 1, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0) Then
      '                                ShowMessage(Me, "Maaf, program diskon ini hanya dapat digunakan 1x saja !", True)
      '                                ItemList.Row = Nothing
      '                                Exit Sub
      '                            End If
      '                        End If

      '                        ' Filter By Amount Is
      '                        If Not ApplyCancelled Then
      '                            Dim CurrentPrice As Decimal = IIf(i Mod 3 = 1, .Item(i, 6), .Item(i - 1, 6))
      '                            .Item(i, 4) = DiscountList.Item(FindSelectedRow(DiscountList), 0)
      '                            .Item(i, 5) = Replace(DiscountList.Item(FindSelectedRow(DiscountList), 1), "=> ", Nothing)


      '                            ' Generate New Discount
      '                            Dim NewGenerateValue As New DiscGenerateResultLib
      '                            If TMPCheck.Item("DISCLIMIT") = 0 Then
      '                                NewGenerateValue = DiscountGenerateCombination(Val(TMPCheck.Item("DISCAMTOPTID")), CInt(TMPCheck.Item("DISCLIMIT")), CurrentPrice, .Item(i, 3), DiscountList.Item(FindSelectedRow(DiscountList), 0), .Item(i, 1), AskMountValue)
      '                            Else
      '                                NewGenerateValue = DiscountGenerateCombination(Val(TMPCheck.Item("DISCAMTOPTID")), CInt(TMPCheck.Item("DISCLIMIT")) - ExistDiscCount(DiscountList.Item(FindSelectedRow(DiscountList), 0)), CurrentPrice, .Item(i, 3), DiscountList.Item(FindSelectedRow(DiscountList), 0), .Item(i, 1), AskMountValue)
      '                            End If

      '                            'If .Item(i, 6) <= 0 Then .Item(i, 6) = CurrentPrice
      '                            If AskMountValue > 0 Then
      '                                .Item(i, 10) = NewGenerateValue.DiscountValue
      '                            Else
      '                                .Item(i, 10) = NewGenerateValue.DiscountValue
      '                            End If
      '                            .Item(i, 11) = NewGenerateValue.NewPriceAfterDisc
      '                            .Item(i, 9) = NewGenerateValue.DiscItemCount

      '                            ' Jump to Next Row Position
      '                            If i Mod 3 = 1 Then
      '                                i = i + 2
      '                            Else
      '                                i = i + 1
      '                            End If
      '                        Else
      '                            ShowMessage(Me, "Maaf, progam diskon ini hanya dapat digunakan maksimum 2x !", True)
      '                        End If
      '                    End If
      '                Next

      '        End Select

      '    End While
      'End With

      '' uncheck all item
      'For i As Integer = 1 To ItemList.Rows.Count - 1
      '    ItemList.Item(i, 2) = Replace(ItemList.Item(i, 2), "=> ", Nothing)
      'Next
      'ItemList.Row = Nothing

      'x = 0
      'AllItem.Image = My.Resources._NOTHING
    End If
    Me.Cursor = Cursors.Default
    VIsSaveOk = True
  End Sub

  Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click
    VIsSaveOk = False
    If ChangeAccount = True Then
      ChangeAccount = False
      UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, UDeptUID)
      Call MainPage.StatusBarInitialize()
    End If

    With ItemList
      Dim TotalDisc As Decimal = 0
      For i As Integer = 1 To .Rows.Count - 1
        If Len(.Item(i, 0)) > 0 Then
          Dim TMPArraylist As New ArrayList
          TMPArraylist.Add(i)
          For j As Integer = 0 To .Cols.Count - 1
            TMPArraylist.Add(.Item(i, j))
          Next
          TotalDisc = TotalDisc + (.Item(i, 9) * .Item(i, 10))
          TMPNewDiscListCollection.Add(TMPArraylist)
        End If
      Next

      Me.ParentOBJForm.TMPDiscListCollection = TMPNewDiscListCollection
      Me.ParentOBJForm.FinalDisc = TotalDisc
      VIsSaveOk = True
      Me.Close()
    End With
  End Sub

  Private Sub BTNClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClear.Click
    If ShowQuestion(Me, "Reset semua diskon ?", True) = True Then
      DiscountList.Rows.Count = 1
      ItemList.Rows.Count = 1

      y = 0
      AllDiscount.Image = My.Resources._NOTHING
      x = 0
      AllItem.Image = My.Resources._NOTHING

      Call BasicInitialize(True)
    End If
  End Sub

  Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancel.Click
    If ChangeAccount = True Then
      ChangeAccount = False
      UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID, UDeptUID)
      Call MainPage.StatusBarInitialize()
    End If

    Me.ParentOBJForm.FinalDisc = originalDiscVal
    Me.Close()
  End Sub

  Private Sub AllItem_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AllItem.MouseDown, LabelSelectAll.MouseDown
    Call SelectAllItem2Disc()
  End Sub

  Private Sub SelectAllItem2Disc()
    If FindSelectedRow(DiscountList) <= 0 Then
      If PrefInfo.VIsAutoDisc = False Then ShowMessage(Me, "Silakan pilih tipe diskon terlebih dahulu !", True)
      Exit Sub
    End If

    If x = 0 Then
      x = 1
      AllItem.Image = My.Resources.OK
    Else
      x = 0
      AllItem.Image = My.Resources._NOTHING
    End If

    If x = 1 Then
      For i As Integer = 1 To ItemList.Rows.Count - 1
        ItemList.Item(i, 2) = Replace(ItemList.Item(i, 2), "=> ", Nothing)
      Next

      With ItemList
        Dim NewStyle As CellStyle
        NewStyle = .Styles.Add("InvalidDisc")
        NewStyle.BackColor = Color.LightCoral

        For i As Integer = 1 To .Rows.Count - 1
          If .Item(i, 7) = False Then
            ItemList.Item(i, 2) = "=> " & ItemList.Item(i, 2)
          End If
        Next
      End With
    Else
      For i As Integer = 1 To ItemList.Rows.Count - 1
        ItemList.Item(i, 2) = Replace(ItemList.Item(i, 2), "=> ", Nothing)
      Next
    End If

  End Sub

  Private Sub AllDiscount_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles AllDiscount.MouseDown, LabelAllDiscount.MouseDown
    If y = 0 Then
      y = 1
      AllDiscount.Image = My.Resources.OK
    Else
      y = 0
      AllDiscount.Image = My.Resources._NOTHING
    End If
    With DiscountList
      Dim NewStyle As CellStyle
      NewStyle = .Styles.Add("InvalidDisc")
      NewStyle.BackColor = Color.LightCoral

      For i As Integer = 1 To .Rows.Count - 1
        If .Item(i, 2) = True Then
          If y = 1 Then
            .Rows(i).Height = 60
            .Rows(i).Visible = True
            .Rows(i).Style = .Styles("InvalidDisc")
          Else
            .Rows(i).Visible = False
          End If
        End If
      Next

    End With
  End Sub

#End Region

  Private Sub LabelSelectAll_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelSelectAll.Click

  End Sub

  Private Sub cmdSelectAllItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAllItem.Click
    If FindSelectedRow(DiscountList) <= 0 Then
      If PrefInfo.VIsAutoDisc = False Then ShowMessage(Me, "Silakan pilih tipe diskon terlebih dahulu !", True)
      Exit Sub
    End If

    If x = 0 Then
      x = 1
      AllItem.Image = My.Resources.OK
      cmdSelectAllItem.Text = "Unselect All Item"
    Else
      x = 0
      AllItem.Image = My.Resources._NOTHING
      cmdSelectAllItem.Text = "Select All Item"
    End If

    If x = 1 Then
      For i As Integer = 1 To ItemList.Rows.Count - 1
        ItemList.Item(i, 2) = Replace(ItemList.Item(i, 2), "=> ", Nothing)
      Next

      With ItemList
        Dim NewStyle As CellStyle
        NewStyle = .Styles.Add("InvalidDisc")
        NewStyle.BackColor = Color.LightCoral

        For i As Integer = 1 To .Rows.Count - 1
          If .Item(i, 7) = False Then
            ItemList.Item(i, 2) = "=> " & ItemList.Item(i, 2)
          End If
        Next
      End With
    Else
      For i As Integer = 1 To ItemList.Rows.Count - 1
        ItemList.Item(i, 2) = Replace(ItemList.Item(i, 2), "=> ", Nothing)
      Next
    End If
  End Sub

  Private Sub LabelAllDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles LabelAllDiscount.Click

  End Sub

  Private Sub cmdSelectAllDiscount_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSelectAllDiscount.Click
    If y = 0 Then
      y = 1
      AllDiscount.Image = My.Resources.OK
      cmdSelectAllDiscount.Text = "Unselect All Discount"
    Else
      y = 0
      AllDiscount.Image = My.Resources._NOTHING
      cmdSelectAllDiscount.Text = "Select All Discount"
    End If
    With DiscountList
      Dim NewStyle As CellStyle
      NewStyle = .Styles.Add("InvalidDisc")
      NewStyle.BackColor = Color.LightCoral

      For i As Integer = 1 To .Rows.Count - 1
        If .Item(i, 2) = True Then
          If y = 1 Then
            .Rows(i).Height = 60
            .Rows(i).Visible = True
            .Rows(i).Style = .Styles("InvalidDisc")
          Else
            .Rows(i).Visible = False
          End If
        End If
      Next

    End With
  End Sub
End Class