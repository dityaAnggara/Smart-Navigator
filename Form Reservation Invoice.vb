Imports System
Imports C1.Win
Imports C1.Win.C1FlexGrid
Imports System.Windows.Forms
Imports System.Threading
Imports System.Globalization
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports FirebirdSql.Data.FirebirdClient
Imports DataDynamics.ActiveReports

Imports NPOI.HSSF.UserModel
Imports NPOI.HPSF
Imports NPOI.POIFS.FileSystem
Imports System.IO

Public Class Form_Reservation_Invoice

#Region "Variable Reference"
    Dim CurrentUID As String = Nothing
    Dim FormEditStatus As Boolean = False
    Public OrderListCollection As New Collection
    Public PriceDetailCollection As New Collection
    Public colOrderDetailPaket As New Collection
    Public DPDetailCollection As New Collection
    Public DPValue As Decimal = 0

    Dim NewID As String = AutoUID()
    Dim OriOrderList As New Collection
    Dim OriPriceDetail As New Collection
    Dim DPDetail As New Collection

    Dim UserPermition As New UserPermitionLib
    Dim ListCollection As New Collection
    Dim FormStatus As FormStatusLib
    Dim SaveStatus As Boolean = False
    Dim DPExist As Decimal = 0

    Dim Hour As String
    Dim Minute As String
    Dim Second As String
    Dim RDate As Date
    Dim CurrDate As Date

    Dim t As Integer = 0
    Dim FileDatabase2 As String = Nothing
    Dim Shift As String = GetShift()

#End Region

#Region "Initialize & Object Function"

    Private Sub BasicInitialize()

        Call CustomerInitialize()
        Call ServiceInitialize()
        'Call TableInitialize()

        ReservationNo.Text = AutoIDNumber("2201", "RSVTRANS", "RSVTRANSNO")
        ReservationDate.Value = Now.Date

        Hour = Now.Hour
        Minute = Now.Minute
        Second = Now.Second
        RDate = Now.Date
        CurrDate = Now.Date
        ReservationTime.Text = Hour & ":" & Minute & ":" & Second

        ReservationTimeLabel.Text = Format(ReservationTime.Value, "hh:mm:ss tt")
        ReservationDateLabel.Text = Format(ReservationDate.Value, "dddd , dd MMMM yyyy")
        DateLabel.Text = Format(CurrentDate.Value, "dddd , dd MMMM yyyy")

        'Susilo, 21 Nov 2013. Reservation untuk non table service tidak perlu ada table
        'Dim FindPos As Integer = TableList.FindRow(SelectedTable.TableUID, 0, 1, True, False, True)
        'TableList.Item(FindPos, 0) = True

        'With TableList
        '    .Redraw = False
        '    Dim NewStyle As CellStyle
        '    NewStyle = .Styles.Add("Click")
        '    NewStyle.BackColor = Color.LightCoral

        '    For i As Integer = 0 To .Rows.Count - 1
        '        If .Item(i, 0) = True Then
        '            .Rows(i).Style = .Styles("Click")
        '        Else
        '            .Rows(i).Style = Nothing
        '        End If
        '    Next
        '    .Redraw = True
        'End With

        TotalVisitor.Text = 1
        DPTxt.Text = 0

        Dim PC As String = GETRSVPrintCounter(CurrentUID)
        PrintCounter.Text = CDec(PC) + 1

        Call CheckPermission(UserInformation.UserTypeUID, True)

    End Sub

    Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)

        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2201'")
        While TMPRecord.Read()
            UserPermition.PermitionInitialize(TMPRecord.Item("USERCATCREATEACCESS"), TMPRecord.Item("USERCATEDITACCESS"), TMPRecord.Item("USERCATDELETEACCESS"), TMPRecord.Item("USERCATREADACCESS"), TMPRecord.Item("USERCATPRINTACCESS"), TMPRecord.Item("USERCATCHANGEDATEACCESS"), TMPRecord.Item("USERCATCHANGETIMEACCESS"), TMPRecord.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
        End While

        With UserPermition
            If Not .ReadAccess Then
                ShowMessage(Me, "Maaf, anda tidak mempunyai akses terhadap form ini !" & vbNewLine & "Silakan hubungi administrator anda.")
                Me.Close()
            End If

            If Not .CreateAccess Then
                BTNSave.Enabled = False
                BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver
            Else
                BTNSave.Enabled = True
                BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Blue
            End If

            If Not .EditAccess Then
                BTNSave.Enabled = False
                BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver
            Else
                BTNSave.Enabled = True
                BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Blue
            End If

            If Not .ChangeDateAccess Then
                VirtualCurrentDate.Enabled = False
                VirtualCurrentDate.VisualStyle = C1Input.VisualStyle.Office2007Silver
            Else
                VirtualCurrentDate.Enabled = True
                VirtualCurrentDate.VisualStyle = C1Input.VisualStyle.Office2007Blue
            End If

        End With

    End Sub

    Private Sub CustomerInitialize(Optional ByVal Search As String = Nothing)

        Dim defaultIndex As Long = -1, curIndex As Long = -1
        Dim TMPRecord As FbDataReader
        Try
            TMPRecord = MyDatabase.MyReader("SELECT CUSTISDFT, CUSTUID, CUSTNAME, CUSTADDR1, CUSTCATUID FROM CUST ORDER BY CUSTNAME")

            CustomerList.ClearItems()
            CustomerList.HoldFields()
            CustomerList.SuspendBinding()

            While TMPRecord.Read()
                curIndex = curIndex + 1
                CustomerList.AddItem(TMPRecord.Item("CUSTNAME") & ";" & TMPRecord.Item("CUSTUID"))
                If IsDBNull(TMPRecord.Item("CUSTISDFT")) = False Then
                    If CStr(TMPRecord.Item("CUSTISDFT")) = "1" Then defaultIndex = curIndex
                End If
            End While

            CustomerList.ResumeBinding()

        Catch ex As Exception

        End Try

        CustomerList.SelectedIndex = defaultIndex
        TMPRecord = Nothing

    End Sub

    Private Sub ServiceInitialize()

        Dim TMPRecord As FbDataReader
        Dim defaultIndex As Long = -1, curIndex As Long = -1

        Try
            TMPRecord = MyDatabase.MyReader("SELECT * FROM SERVICETYPE WHERE SERVICETYPEACTV IS NULL OR SERVICETYPEACTV = 0 ORDER BY SERVICETYPENAME")
            ServiceList.ClearItems()
            ServiceList.HoldFields()
            ServiceList.SuspendBinding()

            While TMPRecord.Read()
                curIndex = curIndex + 1
                ServiceList.AddItem(TMPRecord.Item("SERVICETYPENAME") & ";" & TMPRecord.Item("SERVICETYPEUID"))
                If IsDBNull(TMPRecord.Item("SERVICETYPEDEFAULT")) = False Then
                    If CStr(TMPRecord.Item("SERVICETYPEDEFAULT")) = "1" Then defaultIndex = curIndex
                End If
            End While

            ServiceList.ResumeBinding()
        Catch ex As Exception

        End Try

        ServiceList.SelectedIndex = defaultIndex
        TMPRecord = Nothing

    End Sub

    Private Sub TableInitialize()

        Dim TMPRecord As FbDataReader
        Dim curIndex As Integer = -1

        TableList.Redraw = False
        Try
            TMPRecord = MyDatabase.MyReader("SELECT * FROM TABLELIST T, FLOORNO F WHERE T.FLOORNOUID=F.FLOORNOUID AND F.FLOORDEPTUID ='" & DeptInfo.DeptUID & "' AND (TABLELISTACTV IS NULL OR TABLELISTACTV = 0) ORDER BY TABLELISTNAME")

            TableCombo.ClearItems()
            TableCombo.HoldFields()
            TableCombo.SuspendBinding()

            While TMPRecord.Read()
                curIndex = curIndex + 1
                TableList.AddItem(vbTab & TMPRecord.Item("TABLELISTUID") & vbTab & TMPRecord.Item("TABLELISTNAME"))
                TableList.Rows(curIndex).Height = 45
                TableCombo.AddItem(TMPRecord.Item("TABLELISTNAME") & ";" & TMPRecord.Item("TABLELISTUID"))
            End While

            TableCombo.ResumeBinding()
            TableCombo.SelectedIndex = TableCombo.FindString(SelectedTable.TableUID, 0, 1)

        Catch ex As Exception

        End Try

        TMPRecord = Nothing
        TableList.Redraw = True

    End Sub

    Public Sub BringCustInfo(ByVal CustUID As String)

        Dim CurCust As Integer = CustomerList.FindString(CustUID, 0, 1)
        CustomerList.SelectedIndex = CurCust

    End Sub

    Private Sub GetRSVOrder(ByVal RSVUID As String)

        'Item UID, QTY, Item, Price, Amount, TXTNotes, Order By, Notes, TA
        OrderListCollection.Clear()
        With OrderListCollection
            Dim ItemRecord As FbDataReader
            ItemRecord = MyDatabase.MyReader("SELECT A.*, B.INVENLEVEL FROM RSVTRANSDT A, INVEN B WHERE B.INVENUID=A.RSVTRANSDTITEMUID AND A.RSVTRANSUID = '" & RSVUID & "'")
            While ItemRecord.Read
                Dim ListArray As New ArrayList
                ListArray.Add(ItemRecord.Item("RSVTRANSDTITEMUID"))
                ListArray.Add(ItemRecord.Item("RSVTRANSDTITEMQTY"))
                ListArray.Add(ItemRecord.Item("RSVTRANSDTITEMNAME"))
                ListArray.Add(ItemRecord.Item("RSVTRANSDTITEMPRICE"))
                ListArray.Add(ItemRecord.Item("RSVTRANSDTITEMQTY") * ItemRecord.Item("RSVTRANSDTITEMPRICE"))
                ListArray.Add(ItemRecord.Item("RSVTRANSDTITEMNOTE"))
                ListArray.Add(ItemRecord.Item("RSVTRANSDTUID"))
                ListArray.Add(IIf(ItemRecord.Item("RSVTRANSDTITEMNOTE") = Nothing, False, True))
                ListArray.Add(IIf(ItemRecord.Item("RSVTRANSDTISTAKEAWAY") = 0, False, True))
                ListArray.Add(ItemRecord.Item("INVENLEVEL"))
                ListArray.Add(ItemRecord.Item("RSVTRANSDTITEMMEASUNITDESC"))
                ListArray.Add(ItemRecord.Item("RSVTRANSDTITEMMEASUNITDESC"))
                OrderListCollection.Add(ListArray)
                OriOrderList.Add(ListArray)
            End While
        End With

    End Sub

    Private Sub GetRSVDP(ByVal RSVUID As String)

        DPDetailCollection.Clear()
        With DPDetailCollection
            Dim ItemRecord As FbDataReader
            ItemRecord = MyDatabase.MyReader("SELECT * FROM PBTRANS WHERE PBTRANSRSVTRANSUID = '" & RSVUID & "'")
            While ItemRecord.Read
                Dim ListArray As New ArrayList
                ListArray.Add(ItemRecord.Item("PBTRANSUID"))
                ListArray.Add(ItemRecord.Item("PBTRANSNO"))
                ListArray.Add(ItemRecord.Item("PBTRANSDATE"))
                ListArray.Add(ItemRecord.Item("PBTRANSTOTVAL"))
                ListArray.Add(ItemRecord.Item("PBTRANSDESC"))
                DPDetailCollection.Add(ListArray)
                DPDetail.Add(ListArray)
            End While
        End With

    End Sub

    Private Sub GETRSVPrice(Optional ByVal RSVUID As String = Nothing)

        PriceDetailCollection.Clear()
        With PriceDetailCollection
            If RSVUID = Nothing Then
                PriceDetailCollection.Add("0") : OriPriceDetail.Add("0")
                PriceDetailCollection.Add("0") : OriPriceDetail.Add("0")
                PriceDetailCollection.Add("0") : OriPriceDetail.Add("0")
                PriceDetailCollection.Add("0") : OriPriceDetail.Add("0")
                PriceDetailCollection.Add("0") : OriPriceDetail.Add("0")
            Else
                Dim ItemRecord As FbDataReader
                ItemRecord = MyDatabase.MyReader("SELECT * FROM RSVTRANS WHERE RSVTRANSUID = '" & RSVUID & "'")
                While ItemRecord.Read
                    PriceDetailCollection.Add(ItemRecord.Item("RSVTRANSSUBVAL")) : OriPriceDetail.Add(ItemRecord.Item("RSVTRANSSUBVAL"))
                    PriceDetailCollection.Add(ItemRecord.Item("RSVTRANSTAXVAL1")) : OriPriceDetail.Add(ItemRecord.Item("RSVTRANSTAXVAL1"))
                    PriceDetailCollection.Add("0") : OriPriceDetail.Add("0")
                    PriceDetailCollection.Add(ItemRecord.Item("RSVTRANSTOTVAL")) : OriPriceDetail.Add(ItemRecord.Item("RSVTRANSTOTVAL"))
                End While
            End If
        End With

    End Sub

    Private Sub GETRSVTables(ByVal RSVUID As String)

        Dim ItemRecord As FbDataReader
        ItemRecord = MyDatabase.MyReader("SELECT * FROM RSVTRANSTABLELIST WHERE RSVTRANSUID = '" & RSVUID & "'")

        For i As Integer = 0 To TableList.Rows.Count - 1
            TableList.Item(i, 0) = False
        Next

        Dim NewStyle As CellStyle
        NewStyle = TableList.Styles.Add("Click")
        NewStyle.BackColor = Color.LightCoral

        While ItemRecord.Read
            For i As Integer = 0 To TableList.Rows.Count - 1
                If Trim(TableList.Item(i, 1)) = Trim(ItemRecord.Item("RSVTRANSTABLELISTUID")) Then
                    TableList.Item(i, 0) = True
                    TableList.Rows(i).Style = TableList.Styles("Click")
                End If
            Next
        End While

    End Sub

    Private Function GETRSVPrintCounter(ByVal RSVUID As String) As String

        Dim ItemRecord As FbDataReader
        ItemRecord = MyDatabase.MyReader("SELECT * FROM RSVTRANS WHERE RSVTRANSUID = '" & RSVUID & "'")

        While ItemRecord.Read
            If CDec(ItemRecord.Item("PRINTCOUNTER")) > 0 Then
                Return ItemRecord.Item("PRINTCOUNTER")
            Else
                Return "0"
            End If
        End While

        Return "0"

    End Function
    Private Sub ShowPrintPreviewPrintOrder(Optional ByVal Nota As Boolean = False)

        Dim OBJNew As New Form_Print_Preview
        Dim Query As String

        Query = "SELECT RSV.RSVTRANSUID, RSV.RSVTRANSNO, RSV.RSVTRANSDATE, RSV.RSVTRANSDEPTUID, RSV.RSVTRANSMODULETYPEID," & _
                "RSV.RSVTRANSSHIFTNO, RSV.RSVTRANSRESERVEDDATE, RSV.RSVTRANSRESERVEDTIME, RSV.RSVTRANSPAXVAL," & _
                "RSV.RSVTRANSCUSTUID, RSV.RSVTRANSCUSTNAME, RSV.RSVTRANSSERVICETYPEUID, RSV.RSVTRANSSUBVAL," & _
                "RSV.RSVTRANSTAXVAL1, RSV.RSVTRANSTAXVAL2, RSV.RSVTRANSDPVAL, RSV.RSVTRANSTOTVAL, RSV.RSVTRANSDESC," & _
                "RSV.RSVTRANSSTAT, RSV.PRINTCOUNTER, RSV.ISLOCKED, RSV.CREATEDUSER, RSV.MODIFIEDUSER, RSV.DELETEDUSER," & _
                "RSV.CREATEDDATETIME, RSV.MODIFIEDDATETIME, RSV.DELETEDDATETIME," & _
                "(SELECT CUSTNO FROM CUST WHERE CUSTUID = RSV.RSVTRANSCUSTUID) AS CUSTNO," & _
                "(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = RSV.RSVTRANSSERVICETYPEUID ) AS SERVICENAME," & _
                "RSVDT.*,RSVDTDT.RSVTRANSDTITEMNAME AS DETAILITEM,RSVDTDT.RSVTRANSDTITEMQTY AS DETAILQTY FROM RSVTRANS RSV " & _
                "LEFT OUTER JOIN RSVTRANSDT RSVDT ON RSV.RSVTRANSUID=RSVDT.RSVTRANSUID " & _
                "LEFT OUTER JOIN RSVTRANSDTDETAIL RSVDTDT ON RSVDTDT.RSVTRANSDTUID=RSVDT.RSVTRANSDTUID " & _
                "WHERE RSV.RSVTRANSUID = '" & CurrentUID & "'"

        OBJNew.Name = "Form_Print_Preview"
        OBJNew.RPTTitle = "Reservation_Kitchen_List"
        OBJNew.RPTDocument = New Reservation_Kitchen_List
        OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
        OBJNew.VersiNota = Nota
        OBJNew.ShowDialog()

    End Sub

    Private Sub ShowPrintPreview(Optional ByVal Nota As Boolean = False)

        Dim OBJNew As New Form_Print_Preview
        Dim Query As String
        If pubUsePrintLebarDiReserv = True Then
            If ShowQuestion(Me, "Apakah Anda akan menge-print dengan ukuran kertas lebar ?", True) = False Then
                Query = "SELECT RSVTRANSUID, RSVTRANSNO, RSVTRANSDATE, RSVTRANSDEPTUID, RSVTRANSMODULETYPEID, RSVTRANSSHIFTNO, RSVTRANSRESERVEDDATE, RSVTRANSRESERVEDTIME, RSVTRANSPAXVAL, RSVTRANSCUSTUID, RSVTRANSCUSTNAME, RSVTRANSSERVICETYPEUID, RSVTRANSSUBVAL, RSVTRANSTAXVAL1, RSVTRANSTAXVAL2, RSVTRANSDPVAL, RSVTRANSTOTVAL, RSVTRANSDESC, RSVTRANSSTAT, PRINTCOUNTER, ISLOCKED, CREATEDUSER, MODIFIEDUSER, DELETEDUSER, CREATEDDATETIME, MODIFIEDDATETIME, DELETEDDATETIME, (SELECT CUSTNO FROM CUST WHERE CUSTUID = RSVTRANSCUSTUID) AS CUSTNO, (SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = RSVTRANSSERVICETYPEUID ) AS SERVICENAME FROM RSVTRANS WHERE RSVTRANSUID = '" & CurrentUID & "'"
                OBJNew.Name = "Form_Print_Preview"
                OBJNew.RPTTitle = "Reservation Invoice"
                If PrefInfo.printSize = "58" Then
                    OBJNew.RPTDocument = New Reservation58
                Else
                    OBJNew.RPTDocument = New Reservation
                End If
            Else
                Query = "SELECT RSVTRANS.*, CUSTNO,CUSTADDR1,CUSTADDR2,CUSTTELP1,(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = RSVTRANSSERVICETYPEUID ) AS SERVICENAME,(SELECT TABLELISTNAME FROM TABLELIST WHERE TABLELISTUID=RSVTRANSTABLELISTUID) AS TABLELISTNAME,(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID=RSVTRANSSERVICETYPEUID) AS SERVICETYPENAME FROM RSVTRANS INNER JOIN CUST ON RSVTRANSCUSTUID=CUSTUID WHERE RSVTRANSUID = '" & CurrentUID & "'"
                OBJNew.Name = "Form_Print_Preview"
                OBJNew.RPTTitle = "Reservation"
                OBJNew.RPTDocument = New arNotaReservationLebar
            End If
        Else
            Query = "SELECT RSVTRANSUID, RSVTRANSNO, RSVTRANSDATE, RSVTRANSDEPTUID, RSVTRANSMODULETYPEID, RSVTRANSSHIFTNO, RSVTRANSRESERVEDDATE, RSVTRANSRESERVEDTIME, RSVTRANSPAXVAL, RSVTRANSCUSTUID, RSVTRANSCUSTNAME, RSVTRANSSERVICETYPEUID, RSVTRANSSUBVAL, RSVTRANSTAXVAL1, RSVTRANSTAXVAL2, RSVTRANSDPVAL, RSVTRANSTOTVAL, RSVTRANSDESC, RSVTRANSSTAT, PRINTCOUNTER, ISLOCKED, CREATEDUSER, MODIFIEDUSER, DELETEDUSER, CREATEDDATETIME, MODIFIEDDATETIME, DELETEDDATETIME, (SELECT CUSTNO FROM CUST WHERE CUSTUID = RSVTRANSCUSTUID) AS CUSTNO, (SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = RSVTRANSSERVICETYPEUID ) AS SERVICENAME FROM RSVTRANS WHERE RSVTRANSUID = '" & CurrentUID & "'"
            OBJNew.Name = "Form_Print_Preview"
            OBJNew.RPTTitle = "Reservation Invoice"
            If PrefInfo.printSize = "58" Then
                OBJNew.RPTDocument = New Reservation58
            Else
                OBJNew.RPTDocument = New Reservation
            End If
        End If
            OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
            OBJNew.VersiNota = Nota
            OBJNew.ShowDialog()

    End Sub

    Private Sub UnLockReservation()

        Tax.Visible = False
        TableList.Enabled = True
        TableCombo.Enabled = True
        ServiceList.Enabled = True
        TotalVisitor.Enabled = True
        CustName.Enabled = True
        CustomerList.Enabled = True
        Note.Enabled = True

        VirtualDate.Enabled = True
        VirtualDate.VisualStyle = C1Input.VisualStyle.Office2007Blue
        VirtualTime.Enabled = True
        VirtualTime.VisualStyle = C1Input.VisualStyle.Office2007Blue
        FindCust.Enabled = True
        FindCust.VisualStyle = C1Input.VisualStyle.Office2007Blue
        VirtualKey.Enabled = True
        VirtualKey.VisualStyle = C1Input.VisualStyle.Office2007Blue
        VirtualCalculator.Enabled = True
        VirtualCalculator.VisualStyle = C1Input.VisualStyle.Office2007Blue
        Virtual2Key.Enabled = True
        Virtual2Key.VisualStyle = C1Input.VisualStyle.Office2007Blue
        BTNMoveDown.Enabled = True
        BTNMoveDown.VisualStyle = C1Input.VisualStyle.Office2007Blue
        BTNMoveUp.Enabled = True
        BTNMoveUp.VisualStyle = C1Input.VisualStyle.Office2007Blue
        BTNSave.Enabled = True
        BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Blue
        BTNMakeOrder.Enabled = True
        BTNMakeOrder.VisualStyle = C1Input.VisualStyle.Office2007Blue
        BTNDownpayment.Enabled = True
        BTNDownpayment.VisualStyle = C1Input.VisualStyle.Office2007Blue
        BTNList.Enabled = True
        BTNList.VisualStyle = C1Input.VisualStyle.Office2007Blue

    End Sub

    Private Sub LockReservation()

        Tax.Visible = False
        TableList.Enabled = False
        TableCombo.Enabled = False
        ServiceList.Enabled = False
        TotalVisitor.Enabled = False
        CustName.Enabled = False
        CustomerList.Enabled = False
        Note.Enabled = False

        VirtualDate.Enabled = False
        VirtualDate.VisualStyle = C1Input.VisualStyle.Office2007Silver
        VirtualCurrentDate.Enabled = False
        VirtualCurrentDate.VisualStyle = C1Input.VisualStyle.Office2007Silver
        VirtualTime.Enabled = False
        VirtualTime.VisualStyle = C1Input.VisualStyle.Office2007Silver
        FindCust.Enabled = False
        FindCust.VisualStyle = C1Input.VisualStyle.Office2007Silver
        VirtualKey.Enabled = False
        VirtualKey.VisualStyle = C1Input.VisualStyle.Office2007Silver
        VirtualCalculator.Enabled = False
        VirtualCalculator.VisualStyle = C1Input.VisualStyle.Office2007Silver
        Virtual2Key.Enabled = False
        Virtual2Key.VisualStyle = C1Input.VisualStyle.Office2007Silver
        BTNMoveDown.Enabled = False
        BTNMoveDown.VisualStyle = C1Input.VisualStyle.Office2007Silver
        BTNMoveUp.Enabled = False
        BTNMoveUp.VisualStyle = C1Input.VisualStyle.Office2007Silver
        BTNSave.Enabled = False
        BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver
        BTNMakeOrder.Enabled = False
        BTNMakeOrder.VisualStyle = C1Input.VisualStyle.Office2007Silver
        'BTNDownpayment.Enabled = False
        'BTNDownpayment.VisualStyle = C1Input.VisualStyle.Office2007Silver
        BTNList.Enabled = True
        BTNList.VisualStyle = C1Input.VisualStyle.Office2007Blue

    End Sub

    Private Function CheckTimeReservation(ByVal DateReservation As Date, ByVal TableUID As String) As Boolean

        Dim TMPRecord As FbDataReader
        Dim Time As Integer = Nothing
        Dim TimeReservation As Integer = Nothing
        Dim CurrentTime As String = Nothing

        TMPRecord = MyDatabase.MyReader("SELECT RSVTRANSRESERVEDTIME FROM RSVTRANS WHERE RSVTRANSRESERVEDDATE = '" & DateReservation & "' AND RSVTRANSTABLELISTUID = '" & TableUID & "' AND RSVTRANSSTAT=0")
        While TMPRecord.Read
            CurrentTime = TMPRecord.Item("RSVTRANSRESERVEDTIME")
            Try
                TimeReservation = ReservationTimeLabel.Text.Substring(0, 2)
                Time = CurrentTime.Substring(9, 2)
            Catch ex As Exception
                Time = CurrentTime.Substring(9, 1)
                TimeReservation = ReservationTimeLabel.Text.Substring(0, 1)
            End Try

            If TimeReservation = Time Or TimeReservation < Time Then
                Return True
            End If
        End While

        Return False

    End Function

    Public Sub EditReservation(ByVal RsvUID As String)

        BTNPrintOrder.Enabled = False
        BTNPrintOrder.VisualStyle = C1Input.VisualStyle.Office2007Silver

        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM RSVTRANS WHERE RSVTRANSUID = '" & RsvUID & "'")
        While TMPRecord.Read
            CurrentUID = RsvUID
            ReservationNo.Text = TMPRecord.Item("RSVTRANSNO")
            CurrentDate.Value = TMPRecord.Item("RSVTRANSDATE")
            ReservationDate.Value = TMPRecord.Item("RSVTRANSRESERVEDDATE")
            ReservationTime.Value = TMPRecord.Item("RSVTRANSRESERVEDTIME")

            t = TMPRecord.Item("ISFISCAL")
            If t = 1 Then
                Tax.Visible = True
            End If

            ReservationTimeLabel.Text = Format(ReservationTime.Value, "hh:mm:ss tt")
            ReservationDateLabel.Text = Format(ReservationDate.Value, "dddd , dd MMMM yyyy")
            DateLabel.Text = Format(CurrentDate.Value, "dddd , dd MMMM yyyy")

            'Dim TMPRs As FbDataReader
            'TMPRs = MyDatabase.MyReader("SELECT * FROM CUST WHERE CUSTUID ='" & TMPRecord.Item("RSVTRANSCUSTUID") & "'")
            ''Modified By Rudy (30 Mar 2011)
            'While TMPRs.Read()

            Dim CurCust As Integer = CustomerList.FindString(Trim(TMPRecord.Item("RSVTRANSCUSTUID")), 0, 1)
            CustomerList.SelectedIndex = CurCust
            CustName.Text = TMPRecord.Item("RSVTRANSCUSTNAME")

            'End While
            'TMPRs = Nothing

            'Dim TMPTs As FbDataReader
            'TMPTs = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLELISTUID ='" & TMPRecord.Item("RSVTRANSTABLELISTUID") & "'")
            'Modified By Rudy (30 Mar 2011)
            'While TMPTs.Read()

            'Dim CurTable As Integer = TableCombo.FindString(Trim(TMPRecord.Item("RSVTRANSTABLELISTUID")), 0, 1)
            'TableCombo.SelectedIndex = CurTable

            'End While
            'TMPTs = Nothing

            Dim CurServ As Integer = ServiceList.FindString(Trim(TMPRecord.Item("RSVTRANSSERVICETYPEUID")), 0, 1)
            ServiceList.SelectedIndex = CurServ

            TotalVisitor.Text = TMPRecord.Item("RSVTRANSPAXVAL")

            BalanceDueTxt.Text = FormatNumber(TMPRecord.Item("RSVTRANSTOTVAL"), 0)
            DPTxt.Text = FormatNumber(TMPRecord.Item("RSVTRANSDPVAL"), 0)
            DPExist = CDec(DPTxt.Text)
            Note.Text = TMPRecord.Item("RSVTRANSDESC")

            If TMPRecord.Item("RSVTRANSSTAT") = 1 Then
                Call LockReservation()
            Else
                Call UnLockReservation()
            End If

            Dim PC As String = TMPRecord.Item("PRINTCOUNTER")
            PrintCounter.Text = CDec(PC) + 1
        End While

        FormEditStatus = True

        Call GetRSVOrder(CurrentUID)
        Call GetRSVDP(CurrentUID)
        Call GETRSVPrice(CurrentUID)
        'Call GETRSVTables(CurrentUID)

    End Sub

    Private Sub SimpanDetailNewRsv()

        Dim Query As String = Nothing
        Dim LastID As String = NewID

        CurrentUID = LastID

        ' Insert To Reservation
        If PriceDetailCollection.Count = 0 Then Call GETRSVPrice()
        Query = "INSERT INTO RSVTRANS(RSVTRANSUID,RSVTRANSNO,RSVTRANSDATE,RSVTRANSDEPTUID,RSVTRANSMODULETYPEID,RSVTRANSRESERVEDDATE,RSVTRANSRESERVEDTIME,RSVTRANSPAXVAL,RSVTRANSCUSTUID,RSVTRANSCUSTNAME,RSVTRANSTABLELISTUID,RSVTRANSSERVICETYPEUID,RSVTRANSSUBVAL,RSVTRANSDPVAL,RSVTRANSTOTVAL,RSVTRANSDESC,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME, MODIFIEDDATETIME,PRINTCOUNTER,ISFISCAL) " & _
                "VALUES('" & LastID & "','" & ReservationNo.Text & "','" & Format(CurrentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2201','" & Format(ReservationDate.Value, "dd.MM.yyyy") & "','" & FormatDateTime(ReservationTime.Value, DateFormat.ShortTime) & "','" & TotalVisitor.Text & "','" & CustomerList.Columns(1).Text & "','" & ReplacePetik(CustName.Text) & "',NULL,'" & ServiceList.Columns(1).Text & "','" & CDec(PriceDetailCollection(1)) & "','" & CDec(DPTxt.Text) & "','" & CDec(PriceDetailCollection(4)) & "','" & ReplacePetik(Note.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','1','" & t & "')"
        Call MyDatabase.MyAdapter(Query)

        ' Insert To Reservation Detail
        '/ Item UID, QTY, Item, Price, Amount, TXTNotes, Order By, Notes, TA
        'Dim ItemRecord As FbDataReader
        For i As Integer = 1 To OrderListCollection.Count
            Dim DetailUID As String = AutoUID()
            Dim ListArray As New ArrayList
            ListArray = OrderListCollection(i)

            'ItemRecord = MyDatabase.MyReader("SELECT * FROM INVEN WHERE INVENUID = '" & ListArray(0) & "'")
            'ItemRecord.Read()

            Query = "INSERT INTO RSVTRANSDT(RSVTRANSDTUID,RSVTRANSUID,RSVTRANSDTITEMUID,RSVTRANSDTITEMNAME,RSVTRANSDTITEMMEASUNITDESC,RSVTRANSDTITEMQTY,RSVTRANSDTITEMPRICE,RSVTRANSDTSUBVAL,RSVTRANSDTITEMNOTE,RSVTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME, MODIFIEDDATETIME) " & _
                        "VALUES('" & DetailUID & "','" & LastID & "','" & ListArray(0) & "','" & ReplacePetik(ListArray(2)) & "','" & ReplacePetik(ListArray(11)) & "','" & Val(ListArray(1)) & "','" & CDec(ListArray(3)) & "','" & CDec(ListArray(4)) & "','" & ReplacePetik(ListArray(5).ToString) & "','" & IIf(ListArray(8) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "')"
            Call MyDatabase.MyAdapter(Query)

            'Anjo - 27 Okt, Detail tidak perlu karena dihandle oleh trigger
            'If ItemRecord("INVENLEVEL") = 3 Then
            '    Dim ItemDetail As FbDataReader
            '    ItemDetail = MyDatabase.MyReader("SELECT DT.*,I.INVENNAME  FROM INVENDT DT LEFT OUTER JOIN INVEN I ON DT.INVENDTITEMUID = I.INVENUID WHERE DT.INVENUID='" & ListArray(0) & "'")
            '    While ItemDetail.Read
            '        Query = "INSERT INTO RSVTRANSDTDETAIL (RSVTRANSDTDETAILUID,RSVTRANSDTUID,RSVTRANSDTITEMUID,RSVTRANSDTITEMNAME,RSVTRANSDTITEMMEASUNITDESC,RSVTRANSDTITEMQTY,RSVTRANSDTITEMPRICE,RSVTRANSDTSUBVAL,RSVTRANSDTITEMNOTE,RSVTRANSDTITEMSTAT,RSVTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME) " & _
            '        "VALUES('" & AutoUID() & "','" & DetailUID & "','" & ItemDetail("INVENDTITEMUID") & "','" & ReplacePetik(ItemDetail("INVENNAME")) & "','" & ReplacePetik(ItemDetail("ITEMMEASUNITDESC")) & "','" & ItemDetail("ITEMQTY") * ListArray(1) & "','" & ListArray(3) & "','" & ListArray(4) & "','" & ReplacePetik(ListArray(5)) & "','0','" & IIf(ListArray(8) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "')"
            '        Call MyDatabase.MyAdapter(Query)
            '    End While
            'End If

            'ItemRecord = Nothing
        Next

        'Anjo - 27 Okt, The following is ignored
        'Update Down Payment Transaction Status To Printed
        'Query = "UPDATE PBTRANS SET PBTRANSSTAT = 1 WHERE PBTransStat <> -1 AND PBTRANSRSVTRANSUID = '" & LastID & "'"
        'Call MyDatabase.MyAdapter(Query)

        ' Insert To Reservation Table
        'susilo 21 Nov 2013, reservation table list tidak perlu table list
        'For i As Integer = 0 To TableList.Rows.Count - 1
        '    If TableList.Item(i, 0) = True Then
        '        Query = "INSERT INTO RSVTRANSTABLELIST(RSVTRANSDTTABLELISTUID,RSVTRANSUID,RSVTRANSTABLELISTUID) " & _
        '                "VALUES('" & AutoUID() & "','" & LastID & "','" & TableList.Item(i, 1) & "')"
        '        Call MyDatabase.MyAdapter(Query)
        '    End If
        'Next

    End Sub

    Private Sub SimpanDetailExistingRsv(ByVal InputRsvTransUID As String)
        'Dim ItemRecord As FbDataReader
        Dim RecordItem As FbDataReader

        Dim Query As String

        For i As Integer = 1 To OrderListCollection.Count
            Dim ListArray As New ArrayList
            ListArray = OrderListCollection(i)

            RecordItem = MyDatabase.MyReader("SELECT COUNT (*) FROM RSVTRANSDT WHERE RSVTRANSUID = '" & InputRsvTransUID & "' AND RSVTRANSDTITEMUID = '" & ListArray(0) & "'")
            While RecordItem.Read
                If CInt(RecordItem.Item(0)) > 0 Then
                    ' Update To Reservation Detail
                    Dim List As New ArrayList
                    List = OrderListCollection(i)
                    '/ Item UID, QTY, Item, Price, Amount, TXTNotes, Detail UID, Notes, TA

                    'ItemRecord = MyDatabase.MyReader("SELECT * FROM INVEN WHERE INVENUID = '" & List(0) & "'")
                    'ItemRecord.Read()

                    Query = "UPDATE RSVTRANSDT SET RSVTRANSDTITEMNAME='" & ReplacePetik(List(2)) & "',RSVTRANSDTITEMMEASUNITDESC='" & ReplacePetik(List(11)) & "',RSVTRANSDTITEMQTY='" & Val(List(1)) & "',RSVTRANSDTITEMPRICE='" & CDec(List(3)) & "',RSVTRANSDTSUBVAL='" & CDec(List(4)) & "',RSVTRANSDTITEMNOTE= '" & ReplacePetik(List(5).ToString) & "',RSVTRANSDTISTAKEAWAY='" & IIf(List(8) = True, 1, 0) & "',MODIFIEDUSER='" & UserInformation.UserName & "',MODIFIEDDATETIME='" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "' " & _
                            "WHERE RSVTRANSUID = '" & InputRsvTransUID & "' AND RSVTRANSDTITEMUID = '" & List(0) & "'"
                    Call MyDatabase.MyAdapter(Query)

                    'Query = "DELETE FROM RSVTRANSDTDETAIL WHERE RSVTRANSDTUID = '" & List(6) & "'"
                    'Call MyDatabase.MyAdapter(Query)

                    'If ItemRecord("INVENLEVEL") = 3 Then
                    '    Dim ItemDetail As FbDataReader
                    '    ItemDetail = MyDatabase.MyReader("SELECT DT.*,I.INVENNAME  FROM INVENDT DT LEFT OUTER JOIN INVEN I ON DT.INVENDTITEMUID = I.INVENUID WHERE DT.INVENUID='" & ListArray(0) & "'")
                    '    While ItemDetail.Read
                    '        Query = "INSERT INTO RSVTRANSDTDETAIL (RSVTRANSDTDETAILUID,RSVTRANSDTUID,RSVTRANSDTITEMUID,RSVTRANSDTITEMNAME,RSVTRANSDTITEMMEASUNITDESC,RSVTRANSDTITEMQTY,RSVTRANSDTITEMPRICE,RSVTRANSDTSUBVAL,RSVTRANSDTITEMNOTE,RSVTRANSDTITEMSTAT,RSVTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME) " & _
                    '        "VALUES('" & AutoUID() & "','" & List(6) & "','" & ItemDetail("INVENDTITEMUID") & "','" & ReplacePetik(ItemDetail("INVENNAME")) & "','" & ReplacePetik(ItemDetail("ITEMMEASUNITDESC")) & "','" & ItemDetail("ITEMQTY") * List(1) & "','" & List(3) & "','" & List(4) & "','" & ReplacePetik(List(5)) & "','0','" & IIf(List(8) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "')"
                    '        Call MyDatabase.MyAdapter(Query)
                    '    End While
                    'End If

                    'ItemRecord = Nothing
                Else
                    ' Insert To Reservation Detail
                    Dim List As New ArrayList
                    Dim DetailUID As String = AutoUID()
                    List = OrderListCollection(i)
                    '/ Item UID, QTY, Item, Price, Amount, TXTNotes, Order By, Notes, TA
                    'Dim ItemRecord As FbDataReader
                    'ItemRecord = MyDatabase.MyReader("SELECT * FROM INVEN WHERE INVENUID = '" & List(0) & "'")
                    'ItemRecord.Read()

                    Query = "INSERT INTO RSVTRANSDT(RSVTRANSDTUID,RSVTRANSUID,RSVTRANSDTITEMUID,RSVTRANSDTITEMNAME,RSVTRANSDTITEMMEASUNITDESC,RSVTRANSDTITEMQTY,RSVTRANSDTITEMPRICE,RSVTRANSDTSUBVAL,RSVTRANSDTITEMNOTE,RSVTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME, MODIFIEDDATETIME) " & _
                                "VALUES('" & DetailUID & "','" & CurrentUID & "','" & List(0) & "','" & ReplacePetik(List(2)) & "','" & ReplacePetik(List(11)) & "','" & Val(List(1)) & "','" & CDec(List(3)) & "','" & CDec(List(4)) & "','" & ReplacePetik(List(5).ToString) & "','" & IIf(List(8) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "')"
                    Call MyDatabase.MyAdapter(Query)

                    'If ItemRecord("INVENLEVEL") = 3 Then
                    '    Dim ItemDetail As FbDataReader
                    '    ItemDetail = MyDatabase.MyReader("SELECT DT.*,I.INVENNAME  FROM INVENDT DT LEFT OUTER JOIN INVEN I ON DT.INVENDTITEMUID = I.INVENUID WHERE DT.INVENUID='" & ListArray(0) & "'")
                    '    While ItemDetail.Read
                    '        Query = "INSERT INTO RSVTRANSDTDETAIL (RSVTRANSDTDETAILUID,RSVTRANSDTUID,RSVTRANSDTITEMUID,RSVTRANSDTITEMNAME,RSVTRANSDTITEMMEASUNITDESC,RSVTRANSDTITEMQTY,RSVTRANSDTITEMPRICE,RSVTRANSDTSUBVAL,RSVTRANSDTITEMNOTE,RSVTRANSDTITEMSTAT,RSVTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME) " & _
                    '        "VALUES('" & AutoUID() & "','" & DetailUID & "','" & ItemDetail("INVENDTITEMUID") & "','" & ReplacePetik(ItemDetail("INVENNAME")) & "','" & ReplacePetik(ItemDetail("ITEMMEASUNITDESC")) & "','" & ItemDetail("ITEMQTY") * List(1) & "','" & List(3) & "','" & List(4) & "','" & ReplacePetik(List(5)) & "','0','" & IIf(List(8) = True, 1, 0) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "')"
                    '        Call MyDatabase.MyAdapter(Query)
                    '    End While
                    'End If

                    'ItemRecord = Nothing
                End If
            End While
            RecordItem = Nothing
        Next
    End Sub

    Private Sub DeleteItemRsv(ByVal InputRsvTransUID As String)
        Dim RecordItem As FbDataReader
        Dim ArrayItem() As String
        Dim Delete As String = ""
        Const MY_DELIMITER = "~%^%$#$~"

        'Temukan Item Yang Ada Di DB Tapi Tidak Ada Di FlexGrid 
        RecordItem = MyDatabase.MyReader("SELECT * FROM RSVTRANSDT WHERE RSVTRANSUID = '" & InputRsvTransUID & "'")
        While RecordItem.Read
            If ItemExistInGrid(RecordItem.Item("RSVTRANSDTITEMUID")) = False Then Delete = Delete & MY_DELIMITER & RecordItem.Item("RSVTRANSDTITEMUID")
        End While

        'Hapus Item Yang Ada Di DB Tapi Tidak Ada Di FlexGrid
        If Len(Trim(Delete)) > 0 Then
            ArrayItem = Split(Delete, MY_DELIMITER)
            For i As Integer = 0 To UBound(ArrayItem)
                If Len(Trim(CStr(ArrayItem(i)))) > 0 Then
                    MyDatabase.MyAdapter("DELETE FROM RSVTRANSDT WHERE RSVTRANSDTITEMUID = '" & CStr(ArrayItem(i)) & "'")
                End If
            Next
        End If
    End Sub

    Private Function ItemExistInGrid(ByVal InputRSVTRANSDTITEMUID As String) As Boolean
        Dim R As Boolean = False
        Dim i As Integer

        For i = 1 To OrderListCollection.Count
            Dim ListArray As New ArrayList
            ListArray = OrderListCollection(i)

            If Trim(ListArray(0)) = Trim(InputRSVTRANSDTITEMUID) Then R = True
        Next

        ItemExistInGrid = R
    End Function

#End Region

#Region "Form Control Function"

    Private Sub Form_Reservation_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load

        Me.Location = New System.Drawing.Point(MainPage.Location.X + 260, MainPage.Location.Y + 44)
        Me.Cursor = Cursors.Default
        Call BasicInitialize()

    End Sub

    Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancel.Click

        'Ardian - Down Payment
        If SaveStatus = True Then
            Me.Close()
            Exit Sub
        End If

        If FormEditStatus Then
            If DPTxt.Text <> DPExist Then
                ShowMessage(Me, "Data pembayaran uang muka yang anda masukkan telah berhasil disimpan, walaupun anda batal mengedit data reservasi ini !")
                'If ShowQuestion(Me, "Ada pembayaran uang muka untuk reservasi '" & ReservationNo.Text & "'. Apakah anda ingin membatalkan reservasi ini ?") = True Then
                '    Call MyDatabase.MyAdapter("UPDATE PBTRANS SET DELETEDUSER='" & UserInformation.UserName & "',DELETEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSSTAT = 0 AND PBTRANSRSVTRANSUID = '" & CurrentUID & "'")
                '    Call MyDatabase.MyAdapter("DELETE FROM PBTRANS WHERE PBTRANSSTAT = 0 AND PBTRANSRSVTRANSUID = '" & CurrentUID & "'")
                '    Me.Close()
                'End If
            End If
            Me.Close()
        Else
            If DPTxt.Text <> "0" Then
                If ShowQuestion(Me, "Ada pembayaran uang muka untuk reservasi '" & ReservationNo.Text & "'. Apakah anda ingin membatalkan uang muka reservasi ini ?") = True Then
                    Call MyDatabase.MyAdapter("UPDATE PBTRANS SET DELETEDUSER='" & UserInformation.UserName & "',DELETEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSRSVTRANSUID = '" & NewID & "'")
                    Call MyDatabase.MyAdapter("DELETE FROM PBTRANS WHERE PBTRANSRSVTRANSUID = '" & NewID & "'")
                    Me.Close()
                End If
            Else
                Me.Close()
            End If
        End If
    End Sub

    Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click

        BTNCancel.Enabled = True
        BTNCancel.VisualStyle = C1Input.VisualStyle.Office2007Blue

        Dim Query As String = Nothing
        Dim LastID As String = NewID

        If CustomerList.SelectedIndex = -1 Then
            ShowMessage(Me, "Silakan pilih customer terlebih dahulu ")
            CustomerList.Focus()
            Exit Sub
        End If

        If Len(Trim(CustName.Text)) = 0 Then
            ShowMessage(Me, "Silakan isikan nama customer !")
            CustName.Focus()
            Exit Sub
        End If

        If TotalVisitor.Text < 1 Then
            ShowMessage(Me, "Silakan isikan jumlah customer yang datang !")
            TotalVisitor.Focus()
            Exit Sub
        End If

        'If TableCombo.SelectedIndex < 0 Then
        '    ShowMessage(Me, "Silakan pilih meja terlebih dahulu !")
        '    TableCombo.Focus()
        '    Exit Sub
        'End If

        If ServiceList.SelectedIndex = -1 Then
            ShowMessage(Me, "Silakan pilih tipe servis terlebih dahulu !")
            ServiceList.Focus()
            Exit Sub
        End If

        If Val(DPTxt.Text) < 0 Then
            DPTxt.Text = 0
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim PC As String

        If FormEditStatus Then
            PC = GETRSVPrintCounter(CurrentUID)

            ' Update To Reservation
            Query = "UPDATE RSVTRANS SET RSVTRANSTABLELISTUID =NULL, RSVTRANSSUBVAL ='" & CDec(PriceDetailCollection(1)) & "', RSVTRANSTOTVAL ='" & CDec(PriceDetailCollection(4)) & "', RSVTRANSDATE='" & Format(CurrentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "', RSVTRANSSHIFTNO='" & Shift & "', RSVTRANSRESERVEDDATE ='" & Format(ReservationDate.Value, "dd.MM.yyyy") & "', RSVTRANSRESERVEDTIME ='" & FormatDateTime(ReservationTime.Value, DateFormat.ShortTime) & "', RSVTRANSPAXVAL ='" & TotalVisitor.Text & "', RSVTRANSCUSTUID ='" & CustomerList.Columns(1).Text & "', RSVTRANSCUSTNAME='" & ReplacePetik(CustName.Text) & "', RSVTRANSSERVICETYPEUID='" & ServiceList.Columns(1).Text & "',RSVTRANSDPVAL='" & CDec(DPTxt.Text) & "', RSVTRANSDESC='" & ReplacePetik(Note.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "',PRINTCOUNTER='" & CDec(PC) + 1 & "' WHERE RSVTRANSUID = '" & CurrentUID & "'"
            Call MyDatabase.MyAdapter(Query)

            'Anjo 27 Okt - The following is ignored
            'Update Down Payment Transaction Status To Printed
            'Query = "UPDATE PBTRANS SET PBTRANSSTAT = 1 WHERE PBTransStat <> -1 AND PBTRANSRSVTRANSUID = '" & CurrentUID & "'"
            'Call MyDatabase.MyAdapter(Query)

            ' Remove Old Reservation Table 
            'susilo 21 Nov 2013, reservation non table service table tidak diperlukan
            'Query = "DELETE FROM RSVTRANSTABLELIST WHERE RSVTRANSUID = '" & CurrentUID & "'"
            'Call MyDatabase.MyAdapter(Query)

            'Insert To Reservation Table
            'susilo 21 Nov 2013, reservation non table service table tidak diperlukan
            'For i As Integer = 0 To TableList.Rows.Count - 1
            '    If TableList.Item(i, 0) = True Then
            '        Query = "INSERT INTO RSVTRANSTABLELIST(RSVTRANSDTTABLELISTUID,RSVTRANSUID,RSVTRANSTABLELISTUID) " & _
            '                "VALUES('" & AutoUID() & "','" & CurrentUID & "','" & TableList.Item(i, 1) & "')"
            '        Call MyDatabase.MyAdapter(Query)
            '    End If
            'Next

            Call DeleteItemRsv(CurrentUID)
            Call SimpanDetailExistingRsv(CurrentUID)
        Else

            If totalRow("RSVTRANS") >= CInt(getRealVal("—˜›‡…")) And pubIsDemo = True Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Maaf, data ini tidak dapat disimpan karena versi demo telah habis !", True)
                Exit Sub
            End If

            ReservationNo.Text = AutoIDNumber("2201", "RSVTRANS", "RSVTRANSNO")
            PC = 0
            Call SimpanDetailNewRsv()

            Dim myDataSet As DataSet
            myDataSet = MyDatabase.MyAdapter("SELECT PBTRANSNO FROM PBTRANS WHERE PBTRANSRSVTRANSUID='" & CurrentUID & "'")
            For counter As Integer = 0 To myDataSet.Tables(0).Rows.Count - 1
                Call GeneratePBTransFromReservationExcelFile("", myDataSet.Tables(0).Rows(counter).Item("PBTRANSNO"))
            Next

        End If

        'If t = 1 Then
        '    Query = "INSERT INTO RSVTRANS(RSVTRANSUID,RSVTRANSNO,RSVTRANSDATE,RSVTRANSDEPTUID,RSVTRANSMODULETYPEID,RSVTRANSSHIFTNO,RSVTRANSRESERVEDDATE,RSVTRANSRESERVEDTIME,RSVTRANSPAXVAL,RSVTRANSCUSTUID,RSVTRANSCUSTNAME,RSVTRANSTABLELISTUID,RSVTRANSSERVICETYPEUID,RSVTRANSSUBVAL,RSVTRANSDPVAL,RSVTRANSTOTVAL,RSVTRANSDESC,CREATEDUSER,MODIFIEDUSER,ISFISCAL) " & _
        '          "VALUES('" & LastID & "','" & AutoIDNumber2(FileDatabase2, "2201", "RSVTRANS", "RSVTRANSNO") & "','" & Format(CurrentDate.Value, "dd.MM.yyyy") & "','" & DeptInfo.DeptUID & "','2201','" & Shift & "','" & Format(ReservationDate.Value, "dd.MM.yyyy") & "','" & FormatDateTime(ReservationTime.Value, DateFormat.ShortTime) & "','" & TotalVisitor.Text & "','" & CustomerList.Columns(1).Text & "','" & ReplacePetik(CustName.Text) & "','" & TableCombo.Columns(1).Text & "','" & ServiceList.Columns(1).Text & "','" & CDec(PriceDetailCollection(1)) & "','" & CDec(DPTxt.Text) & "','" & CDec(PriceDetailCollection(4)) & "','" & ReplacePetik(Note.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & t & "')"
        '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)

        '    'Dim ItemRecordd As FbDataReader
        '    For i As Integer = 1 To OrderListCollection.Count
        '        Dim ListArray As New ArrayList
        '        ListArray = OrderListCollection(i)

        '        'ItemRecordd = MyDatabase.MyReader("SELECT * FROM INVEN WHERE INVENUID = '" & ListArray(0) & "'")
        '        'ItemRecordd.Read()

        '        Query = "INSERT INTO RSVTRANSDT(RSVTRANSDTUID,RSVTRANSUID,RSVTRANSDTITEMUID,RSVTRANSDTITEMNAME,RSVTRANSDTITEMMEASUNITDESC,RSVTRANSDTITEMQTY,RSVTRANSDTITEMPRICE,RSVTRANSDTSUBVAL,RSVTRANSDTITEMNOTE) " & _
        '                    "VALUES('" & AutoUID() & "','" & LastID & "','" & ListArray(0) & "','" & ReplacePetik(ListArray(2)) & "','" & ReplacePetik(ListArray(11)) & "','" & Val(ListArray(1)) & "','" & CDec(ListArray(3)) & "','" & CDec((ListArray(3) - ((ListArray(6) * ListArray(3)) / 100)) * ListArray(1)) & "','" & ReplacePetik(ListArray(5).ToString) & "')"
        '        Call MyDatabase.MyAdapter2(FileDatabase2, Query)
        '        'ItemRecordd = Nothing
        '    Next
        'Else
        '    Query = "DELETE FROM RSVTRANS WHERE RSVTRANSUID='" & CurrentUID & "'"
        '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
        'End If

        FormEditStatus = True

        Call ShowPrintPreview(True)
        Call LockReservation()

        BTNPrintOrder.Enabled = True
        BTNPrintOrder.VisualStyle = C1Input.VisualStyle.Office2007Blue

        SaveStatus = True
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BTNPrintOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPrintOrder.Click
        Me.Cursor = Cursors.WaitCursor
        Call ShowPrintPreviewPrintOrder(True)
        Me.Cursor = Cursors.Default
        Me.Close()
    End Sub

    Private Sub TotalVisitor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TotalVisitor.KeyPress
        TotalVisitor.SelectionStart = Len(TotalVisitor.Text)
    End Sub

    Private Sub TotalVisitor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalVisitor.TextChanged
        If IsNumeric(TotalVisitor.Text) = False Then
            TotalVisitor.Text = "1"
            Exit Sub
        Else
            TotalVisitor.Text = FormatNumber(TotalVisitor.Text, 0)
        End If
    End Sub

    Private Sub BTNMakeOrder_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMakeOrder.Click

        If CustomerList.SelectedIndex = -1 Then
            ShowMessage(Me, "Silakan pilih customer terlebih dahulu !")
            CustomerList.Focus()
            Exit Sub
        End If

        If CustName.Text = "" Then
            ShowMessage(Me, "Silakan isikan nama customer !")
            CustName.Focus()
            Exit Sub
        End If

        If TotalVisitor.Text < 1 Then
            ShowMessage(Me, "Silakan isikan jumlah customer yang datang !")
            TotalVisitor.Focus()
            Exit Sub
        End If
        'susilo 21 Nov 2013, reservation non table service table tidak diperlukan
        'If TableCombo.SelectedIndex < 0 Then
        '    ShowMessage(Me, "Silakan pilih meja terlebih dahulu !")
        '    TableCombo.Focus()
        '    Exit Sub
        'End If

        If ServiceList.SelectedIndex = -1 Then
            ShowMessage(Me, "Silakan pilih tipe servis terlebih dahulu !")
            ServiceList.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor

        If PrefInfo.ShowMenuImage = False Then
            Dim OBJNew As New Form_Reservation_Make_Order
            OBJNew.Name = "Reservation_Make_Order"
            With OBJNew.CustDetailInfo
                .ReservationNumber = ReservationNo.Text
                .CustUID = CustomerList.Columns(1).Text
            End With
            OBJNew.ParentOBJForm = Me
            OBJNew.ShowDialog()
        ElseIf PrefInfo.ShowMenuImage = True Then
            Dim OBJNew As New Form_Reservation_Make_Order_Image
            OBJNew.Name = "Reservation_Make_Order"
            With OBJNew.CustDetailInfo
                .ReservationNumber = ReservationNo.Text
                .CustUID = CustomerList.Columns(1).Text
            End With
            OBJNew.ParentOBJForm = Me
            OBJNew.ShowDialog()
        End If

        If PriceDetailCollection.Count > 0 Then
            BalanceDueTxt.Text = Format(CDec(PriceDetailCollection(4)), "#,##0")
        Else
            BalanceDueTxt.Text = "0"
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Sub TableList_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles TableList.MouseDown
        If TableList.Rows.Count > 0 Then
            TableList.Item(TableList.Row, 0) = Not TableList.Item(TableList.Row, 0)

            With TableList
                Dim NewStyle As CellStyle
                NewStyle = .Styles.Add("Click")
                NewStyle.BackColor = Color.LightCoral

                For i As Integer = 0 To .Rows.Count - 1
                    If .Item(i, 0) = True Then
                        .Rows(i).Style = .Styles("Click")
                    Else
                        .Rows(i).Style = Nothing
                    End If
                Next
            End With
        End If
    End Sub

    Private Sub BTNDownpayment_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNDownpayment.Click

        If CustomerList.SelectedIndex = -1 Then
            ShowMessage(Me, "Silakan pilih customer terlebih dahulu !")
            CustomerList.Focus()
            Exit Sub
        End If

        If Len(Trim(CustName.Text)) = 0 Then
            ShowMessage(Me, "Silakan isikan nama customer !")
            CustName.Focus()
            Exit Sub
        End If

        If TotalVisitor.Text < 1 Then
            ShowMessage(Me, "Silakan isikan jumlah customer yang datang !")
            TotalVisitor.Focus()
            Exit Sub
        End If

        'susilo 21 Nov 2013, reservation non table service tidak perlu table
        'If TableCombo.SelectedIndex < 0 Then
        '    ShowMessage(Me, "Silakan pilih meja terlebih dahulu !")
        '    TableCombo.Focus()
        '    Exit Sub
        'End If

        If ServiceList.SelectedIndex = -1 Then
            ShowMessage(Me, "Silakan pilih tipe servis terlebih dahulu !")
            ServiceList.Focus()
            Exit Sub
        End If

        Me.Cursor = Cursors.WaitCursor
        Dim OBJNew As New Form_Reservation_Down_Payment
        OBJNew.Name = "Form_Reservation_Down_Payment"

        With OBJNew
            .NewID = NewID
            .CurrentUID = CurrentUID
            .ReservationNumber = ReservationNo.Text
            .CustUID = CustomerList.Columns(1).Text
            .CustList = CustomerList.Text
            .GrandTotal = BalanceDueTxt.Text
            .CustName = CustName.Text
            'susilo 21 Nov 2013, reservation non table service tidak perlu table
            .TableUID = ""
            '.Table = TableCombo.Text
            '.TableUID = TableCombo.Columns(1).Text
            .DP = DPTxt.Text

            'Andy 21 August 2011 - jika button make order disabled, berarti Revervasi sudah
            'dibuatkan checkin dan sudah make bill. DP tidak boleh dirubah, karena sudah make bill
            If BTNMakeOrder.Enabled Then
                .LockDownPayment = False
            Else
                .LockDownPayment = True
            End If
        End With

        OBJNew.ParentOBJForm = Me

        If FormEditStatus = True Then
            OBJNew.TransactionUID = CurrentUID
            OBJNew.NewEditStatus = True
        Else
            OBJNew.TransactionUID = NewID
            OBJNew.NewEditStatus = False
        End If

        OBJNew.ShowDialog()

        If DPValue = 0 Then
            DPTxt.Text = "0"
        Else
            DPTxt.Text = Format(CDec(DPValue), "#,##0")
        End If

        If DPTxt.Text <> DPExist Then
            BTNList.Enabled = False
            BTNList.VisualStyle = C1Input.VisualStyle.Office2007Silver
        End If
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub CustomerList_Change(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerList.Change

        If CustomerList.SelectedIndex = -1 Then
            CustName.Text = Nothing
        Else
            CustName.Text = CustomerList.Columns(0).Text
        End If

    End Sub

    Private Sub FindCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindCust.Click

        Me.Cursor = Cursors.WaitCursor
        Dim CustDialog As New Form_Customer_Pick
        CustDialog.Name = "Form_Customer_Pick"
        CustDialog.ParentOBJForm = Me
        CustDialog.ShowDialog()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub VirtualKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKey.Click

        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(CustName, False)
        VirtuKey.ShowDialog()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub Virtual2Key_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Virtual2Key.Click

        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(Note, False)
        VirtuKey.ShowDialog()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub VirtualCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualCalculator.Click

        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        VirtuCalculator.OBJBind(TotalVisitor)
        VirtuCalculator.ShowDialog()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BTNList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNList.Click

        Me.Cursor = Cursors.WaitCursor
        Dim OBJNew As New Form_Reservation_List
        OBJNew.Name = "Form_Reservation_List"
        OBJNew.ParentOBJForm = Me
        OBJNew.ShowDialog()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub VirtualTime_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualTime.Click

        Me.Cursor = Cursors.WaitCursor
        Dim VirtualTime As New Form_Virtual_Time
        VirtualTime.Name = "Form_Virtual_Time"
        VirtualTime.Text = "Reservation Time"
        VirtualTime.ParentOBJForm = Me
        VirtualTime.LastHour = Hour
        VirtualTime.LastMinute = Minute
        VirtualTime.LastSecond = Second
        VirtualTime.ShowDialog()

        ReservationTime.Text = VirtualTime.NewTime
        Hour = VirtualTime.Hour.Text
        Minute = VirtualTime.Minute.Text
        Second = VirtualTime.Second.Text
        ReservationTimeLabel.Text = Format(ReservationTime.Value, "hh:mm:ss tt")
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub VirtualDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualDate.Click

        Me.Cursor = Cursors.WaitCursor
        Dim VirtualDate As New Form_Virtual_Date
        VirtualDate.Name = "Form_Virtual_Date"
        VirtualDate.Text = "Reservation Date"
        VirtualDate.ParentOBJForm = Me
        VirtualDate.publicChosenDate = RDate
        VirtualDate.ShowDialog()

        ReservationDate.Text = VirtualDate.publicChosenDate
        RDate = VirtualDate.publicChosenDate
        ReservationDateLabel.Text = Format(ReservationDate.Value, "dddd , dd MMMM yyyy")
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub VirtualCurrentDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualCurrentDate.Click

        Me.Cursor = Cursors.WaitCursor
        Dim VirtualDate As New Form_Virtual_Date
        VirtualDate.Name = "Form_Virtual_Date"
        VirtualDate.Text = "Current Date"
        VirtualDate.ParentOBJForm = Me
        VirtualDate.publicChosenDate = CurrDate

        VirtualDate.ShowDialog()

        CurrentDate.Text = VirtualDate.publicChosenDate
        CurrDate = VirtualDate.publicChosenDate
        DateLabel.Text = Format(CurrentDate.Value, "dddd , dd MMMM yyyy")
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub FocusMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMoveUp.Click, BTNMoveDown.Click

        With TableList
            If .Rows.Count > -1 Then
                Select Case sender.name
                    Case "BTNMoveUp"
                        If .Row > 0 Then .Row = .Row - 1
                    Case "BTNMoveDown"
                        If .Row < .Rows.Count - 1 Then .Row = .Row + 1
                End Select
            End If
        End With

    End Sub
    
    Private Sub Tax_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles Tax.MouseDown

        Dim Query As String = Nothing

        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM POSPREF")
        While TMPRecord.Read
            Try
                FileDatabase2 = TMPRecord.Item("POSPREFDATABASEPATH2")
            Catch ex As Exception
                ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
            End Try
        End While

        If t = 0 Then
            If CheckConnectionDB2(FileDatabase2) Then
                t = 1
                Tax.Visible = True
            Else
                ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
                t = 0
                Tax.Visible = False
            End If
        Else
            t = 0
            Tax.Visible = False
        End If

    End Sub

    Private Sub ReservationNo_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ReservationNo.MouseDown
        '31 Jan 2013 susilo, simpan data pajak semua sudah diisi di Payment
        'Dim Query As String = Nothing

        'Dim TMPRecord As FbDataReader
        'TMPRecord = MyDatabase.MyReader("SELECT * FROM POSPREF")
        'While TMPRecord.Read
        '    Try
        '        FileDatabase2 = TMPRecord.Item("POSPREFDATABASEPATH2")
        '    Catch ex As Exception
        '        ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
        '    End Try
        'End While

        'If t = 0 Then
        '    If CheckConnectionDB2(FileDatabase2) Then
        '        t = 1
        '        Tax.Visible = True
        '    Else
        '        ShowMessage(Me, "Maaf, file database 2 tidak ditemukan !")
        '        t = 0
        '        Tax.Visible = False
        '    End If
        'Else
        '    t = 0
        '    Tax.Visible = False
        'End If

    End Sub

    Private Sub TableCombo_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles TableCombo.Change

        If TableCombo.SelectedIndex > -1 Then
            For i As Integer = 0 To TableList.Rows.Count - 1
                TableList.Item(i, 0) = False
                TableList.Rows(i).Style = Nothing
            Next

            Dim FindPos As Integer = TableList.FindRow(TableCombo.Columns(1).Text, 0, 1, True, False, True)
            TableList.Item(FindPos, 0) = True

            With TableList
                Dim NewStyle As CellStyle
                NewStyle = .Styles.Add("Click")
                NewStyle.BackColor = Color.LightCoral

                For i As Integer = 0 To .Rows.Count - 1
                    If .Item(i, 0) = True Then
                        .Rows(i).Style = .Styles("Click")
                    Else
                        .Rows(i).Style = Nothing
                    End If
                Next
            End With
        End If
    End Sub

#End Region

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
    End Sub

    Private Sub GeneratePBTransFromReservationExcelFile(ByVal inputPBTransUID As String, ByVal inputPBTransNo As String)

        If PrefInfo.AutoGenerateExcelFile = "0" Then Exit Sub
        If Len(Trim(PrefInfo.AutoGenerateExcelFilePath)) = 0 Then Exit Sub
        If CheckFolderExist(PrefInfo.AutoGenerateExcelFilePath) = False Then Exit Sub

        Dim rs As FbDataReader
        Dim strSQL As String
        Dim rowNum As Integer
        Dim HSSFWorkbook As New HSSFWorkbook
        Dim fileName As String = inputPBTransNo
        Dim dsi As DocumentSummaryInformation = PropertySetFactory.CreateDocumentSummaryInformation()
        dsi.Company = "NAV"
        HSSFWorkbook.DocumentSummaryInformation = dsi

        Dim hssfSheet As HSSFSheet = HSSFWorkbook.CreateSheet("PAGE1")

        'strSQL = connDB.CreateCommand

        strSQL = "SELECT dept.DeptNo AS Entity, mb.RSVTRANSNO AS TrNo," & _
         "CASE WHEN pType.ISCREDITCARDORCHEQUE='0' THEN 'CASH' WHEN pType.ISCREDITCARDORCHEQUE='1' THEN 'CC' WHEN pType.ISCREDITCARDORCHEQUE='2' THEN 'DC' WHEN pType.ISCREDITCARDORCHEQUE='3' THEN 'PTG' WHEN pType.ISCREDITCARDORCHEQUE='4' THEN 'ENT' ELSE pType.PaymentTypeName END AS Tipe," & _
         "CASE WHEN pType.PaymentTypeEDCNumber IS NULL THEN '' ELSE pType.PaymentTypeEDCNumber END AS KodeMesin, pbdt.PBTransDtSubVal AS Amount " & _
                       "FROM PBTrans pb LEFT OUTER JOIN PBTransDt pbdt ON pb.PBTransUID = pbdt.PBTransUID  " & _
                       "LEFT OUTER JOIN RSVTRANS mb ON pb.PBTRANSRSVTRANSUID = mb.RSVTransUID " & _
                       "LEFT OUTER JOIN Dept dept ON pb.PBTransDeptUID = dept.DeptUID " & _
                       "LEFT OUTER JOIN Cust cust ON mb.RSVTRANSCUSTUID = cust.CustUID " & _
                       "LEFT OUTER JOIN CustCat custcat ON cust.CustCatUID = custcat.CustCatUID " & _
                       "LEFT OUTER JOIN PaymentType pType ON pbdt.PaymentTypeUID = pType.PaymentTypeUID WHERE pb.PBTRANSNO='" & inputPBTransNo & "'"

        'rs = strSQL.ExecuteReader
        rs = MyDatabase.MyReader(strSQL)
        rowNum = 0
        While rs.Read() = True
            Dim hssfRow As HSSFRow = hssfSheet.CreateRow(rowNum)

            Dim hssfCell As HSSFCell = hssfRow.CreateCell(0)

            'Create Currency Cell Style
            Dim CurrencyCellStyle As HSSFCellStyle = HSSFWorkbook.CreateCellStyle()
            Dim CurrencyDataFormat As HSSFDataFormat = HSSFWorkbook.CreateDataFormat()
            CurrencyCellStyle.DataFormat = CurrencyDataFormat.GetFormat("#,##0.0000")

            'Create Date Cell Style
            Dim DateCellStyle As HSSFCellStyle = HSSFWorkbook.CreateCellStyle()
            Dim DateDataFormat As HSSFDataFormat = HSSFWorkbook.CreateDataFormat()
            DateCellStyle.DataFormat = DateDataFormat.GetFormat("yyyy-mm-dd")

            'Create Time Cell Style
            Dim TimeCellStyle As HSSFCellStyle = HSSFWorkbook.CreateCellStyle()
            Dim TimeDataFormat As HSSFDataFormat = HSSFWorkbook.CreateDataFormat()
            TimeCellStyle.DataFormat = TimeDataFormat.GetFormat("HH:mm:ss")

            hssfCell.SetCellValue(rs("Entity"))

            hssfCell = hssfRow.CreateCell(1)
            hssfCell.SetCellValue(rs("TrNo"))

            hssfCell = hssfRow.CreateCell(2)
            hssfCell.SetCellValue(rs("Tipe"))

            hssfCell = hssfRow.CreateCell(3)
            hssfCell.SetCellValue(rs("KodeMesin"))

            hssfCell = hssfRow.CreateCell(4)
            hssfCell.SetCellValue(CDec(rs("Amount")))
            hssfCell.SetCellType(hssfCell.CELL_TYPE_NUMERIC)
            hssfCell.CellStyle = CurrencyCellStyle

            rowNum += 1
        End While
        rs.Close()

        Dim file As FileStream = New FileStream(PrefInfo.AutoGenerateExcelFilePath & "\" & fileName & ".xls", FileMode.Create)
        HSSFWorkbook.Write(file)
        file.Close()

    End Sub

    Private Sub ReservationNo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservationNo.Click

    End Sub
End Class