Imports System
Imports C1.Win
Imports System.Windows.Forms
Imports System.Threading
Imports System.Globalization
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports FirebirdSql.Data.FirebirdClient

Public Class Form_Check_In

#Region "Variable Reference"
    Dim CurrentUID As String = Nothing
    Dim RsvBack As String = Nothing
    Dim TableBack As String = Nothing
    Dim CheckInFormStatus As FormStatusLib
    Dim UpdateID As String = Nothing
    Dim KitchenSplitOrder As String = "0"

    Dim UserPermition As New UserPermitionLib
    Dim FormStatus As FormStatusLib

    Dim Hour As String
    Dim Minute As String
    Dim Second As String
    Dim CurrDate As Date
    Dim Shift As String = GetShift()
#End Region

#Region "Initialize & Object Function"

    Private Sub GetDefaultValue()
        TotalVisitor.Text = 1
        TransactionNo.Text = AutoIDNumber("2202", "MBTRANS", "MBTRANSNO")
        TransactionNo.Text = "  -"

        Hour = Now.Hour
        Minute = Now.Minute
        Second = Now.Second
        CurrDate = Now.Date
        DateLabel.Text = Format(CurrentDate.Value, "dddd , dd MMMM yyyy")
        TimeLabel.Text = Format(CurrentTime.Value, "hh:mm:ss tt")

    End Sub

    Private Sub BasicInitialize()
        Call ReservationInitialize()
        Call CustomerInitialize()
        Call ServiceInitialize()
        Call TableInitialize()
    End Sub

    Private Sub ReservationInitialize()
        Dim TMPRecord As FbDataReader

        ReservationList.ClearItems()
        ReservationList.HoldFields()
        ReservationList.SuspendBinding()
        ReservationList.AddItem("* No Reservation;;;;;;;;* No Reservation;")
        'If PrefInfo.ALLOWUSEMULTIRESRV = "1" Then
        TMPRecord = MyDatabase.MyReader("SELECT a.RSVTRANSUID, a.RSVTRANSNO, a.RSVTRANSDATE, a.RSVTRANSRESERVEDDATE, a.RSVTRANSRESERVEDTIME, a.RSVTRANSPAXVAL, (SELECT CUSTCATUID FROM CUST WHERE CUSTUID = a.RSVTRANSCUSTUID)AS CUSTCATUID ,a.RSVTRANSCUSTUID, a.RSVTRANSCUSTNAME, a.RSVTRANSSERVICETYPEUID, a.RSVTRANSDPVAL, a.RSVTRANSSTAT,a.RSVTRANSUSEDPMULTIPLE,a.RSVTRANSUSEDPVAL FROM " & _
                                            "RSVTRANS a " & _
                                            "WHERE (a.RSVTRANSUSEDPMULTIPLE='1' AND (RSVTRANSDPVAL-IIF(RSVTRANSUSEDPVAL IS NULL,0,RSVTRANSUSEDPVAL))>0 ) OR  (a.RSVTRANSRESERVEDDATE =  '" & Format(CurrentDate.Value, "dd.MM.yyyy") & "' AND a.RSVTRANSSTAT='0') ORDER BY a.RSVTRANSNO")
        'Else
        '    TMPRecord = MyDatabase.MyReader("SELECT a.RSVTRANSUID, a.RSVTRANSNO, a.RSVTRANSDATE, a.RSVTRANSRESERVEDDATE, a.RSVTRANSRESERVEDTIME, a.RSVTRANSPAXVAL, (SELECT CUSTCATUID FROM CUST WHERE CUSTUID = a.RSVTRANSCUSTUID)AS CUSTCATUID ,a.RSVTRANSCUSTUID, a.RSVTRANSCUSTNAME, a.RSVTRANSSERVICETYPEUID, a.RSVTRANSDPVAL, a.RSVTRANSSTAT FROM RSVTRANS a INNER JOIN TABLELIST b ON a.RSVTRANSTABLELISTUID = b.TABLELISTUID WHERE b.IMAGE NOT IN ('9','10') AND (a.RSVTRANSSTAT IS NULL OR a.RSVTRANSSTAT = 0 ) AND a.RSVTRANSRESERVEDDATE =  '" & Format(CurrentDate.Value, "dd.MM.yyyy") & "' ORDER BY RSVTRANSNO")
        'End If

        While TMPRecord.Read()
            'If PrefInfo.ALLOWUSEMULTIRESRV = "1" Then
            '    If TMPRecord.Item("RSVTRANSUSEDPMULTIPLE") = "1" Then
            '        If CDec(TMPRecord.Item("RSVTRANSDPVAL")) > CDec(TMPRecord.Item("RSVTRANSUSEDPVAL")) Then
            '            ReservationList.AddItem(TMPRecord.Item("RSVTRANSNO") & ";" & TMPRecord.Item("RSVTRANSUID") & ";" & FormatDateTime(TMPRecord.Item("RSVTRANSDATE"), DateFormat.ShortDate) & ";" & TMPRecord.Item("RSVTRANSRESERVEDDATE") & ";" & TMPRecord.Item("RSVTRANSRESERVEDTIME") & ";" & TMPRecord.Item("RSVTRANSPAXVAL") & ";" & TMPRecord.Item("RSVTRANSDPVAL") & ";" & TMPRecord.Item("RSVTRANSCUSTUID") & ";" & TMPRecord.Item("RSVTRANSCUSTNAME") & ";" & TMPRecord.Item("RSVTRANSSERVICETYPEUID"))
            '        End If
            '    Else
            '        If IsDBNull(TMPRecord.Item("RSVTRANSSTAT")) = False Then
            '            If TMPRecord.Item("RSVTRANSSTAT") = "0" Then
            '                ReservationList.AddItem(TMPRecord.Item("RSVTRANSNO") & ";" & TMPRecord.Item("RSVTRANSUID") & ";" & FormatDateTime(TMPRecord.Item("RSVTRANSDATE"), DateFormat.ShortDate) & ";" & TMPRecord.Item("RSVTRANSRESERVEDDATE") & ";" & TMPRecord.Item("RSVTRANSRESERVEDTIME") & ";" & TMPRecord.Item("RSVTRANSPAXVAL") & ";" & TMPRecord.Item("RSVTRANSDPVAL") & ";" & TMPRecord.Item("RSVTRANSCUSTUID") & ";" & TMPRecord.Item("RSVTRANSCUSTNAME") & ";" & TMPRecord.Item("RSVTRANSSERVICETYPEUID"))
            '            End If
            '        Else
            '            ReservationList.AddItem(TMPRecord.Item("RSVTRANSNO") & ";" & TMPRecord.Item("RSVTRANSUID") & ";" & FormatDateTime(TMPRecord.Item("RSVTRANSDATE"), DateFormat.ShortDate) & ";" & TMPRecord.Item("RSVTRANSRESERVEDDATE") & ";" & TMPRecord.Item("RSVTRANSRESERVEDTIME") & ";" & TMPRecord.Item("RSVTRANSPAXVAL") & ";" & TMPRecord.Item("RSVTRANSDPVAL") & ";" & TMPRecord.Item("RSVTRANSCUSTUID") & ";" & TMPRecord.Item("RSVTRANSCUSTNAME") & ";" & TMPRecord.Item("RSVTRANSSERVICETYPEUID"))
            '        End If
            '    End If
            'Else
            ReservationList.AddItem(TMPRecord.Item("RSVTRANSNO") & ";" & TMPRecord.Item("RSVTRANSUID") & ";" & FormatDateTime(TMPRecord.Item("RSVTRANSDATE"), DateFormat.ShortDate) & ";" & TMPRecord.Item("RSVTRANSRESERVEDDATE") & ";" & TMPRecord.Item("RSVTRANSRESERVEDTIME") & ";" & TMPRecord.Item("RSVTRANSPAXVAL") & ";" & TMPRecord.Item("RSVTRANSDPVAL") & ";" & TMPRecord.Item("RSVTRANSCUSTUID") & ";" & TMPRecord.Item("RSVTRANSCUSTNAME") & ";" & TMPRecord.Item("RSVTRANSSERVICETYPEUID"))
            'End If
        End While

        ReservationList.ResumeBinding()
        FindReservation.Enabled = ReservationList.ListCount > 1
        TMPRecord = Nothing

    End Sub

    Private Sub EditReservationInitialize(ByVal MBTransRsvTransUID As String)
        Dim TMPRecord As FbDataReader
        Try
            TMPRecord = MyDatabase.MyReader("SELECT a.RSVTRANSUID, a.RSVTRANSNO, a.RSVTRANSDATE, a.RSVTRANSRESERVEDDATE, a.RSVTRANSRESERVEDTIME, a.RSVTRANSPAXVAL, (SELECT CUSTCATUID FROM CUST WHERE CUSTUID = a.RSVTRANSCUSTUID)AS CUSTCATUID ,a.RSVTRANSCUSTUID, a.RSVTRANSCUSTNAME, a.RSVTRANSSERVICETYPEUID, a.RSVTRANSDPVAL, a.RSVTRANSSTAT FROM RSVTRANS a WHERE a.RSVTRANSUID='" & MBTransRsvTransUID & "' AND a.RSVTRANSRESERVEDDATE ='" & Format(CurrentDate.Value, "dd.MM.yyyy") & "'")

            While TMPRecord.Read()
                ReservationList.AddItem(TMPRecord.Item("RSVTRANSNO") & ";" & TMPRecord.Item("RSVTRANSUID") & ";" & FormatDateTime(TMPRecord.Item("RSVTRANSDATE"), DateFormat.ShortDate) & ";" & TMPRecord.Item("RSVTRANSRESERVEDDATE") & ";" & TMPRecord.Item("RSVTRANSRESERVEDTIME") & ";" & TMPRecord.Item("RSVTRANSPAXVAL") & ";" & TMPRecord.Item("RSVTRANSDPVAL") & ";" & TMPRecord.Item("RSVTRANSCUSTUID") & ";" & TMPRecord.Item("RSVTRANSCUSTNAME") & ";" & TMPRecord.Item("RSVTRANSSERVICETYPEUID"))
                BringRSVInfo(TMPRecord.Item("RSVTRANSUID"))
            End While

            FindReservation.Enabled = ReservationList.ListCount > 1
        Catch ex As Exception
        End Try
        TMPRecord = Nothing
    End Sub

    Private Sub LockFormOnUsedStatus()
        ReservationList.Enabled = False
        ReservationList.VisualStyle = C1Input.VisualStyle.Office2007Silver

        FindReservation.Enabled = False
        FindReservation.VisualStyle = C1Input.VisualStyle.Office2007Silver

        CustomerList.Enabled = False
        CustomerList.VisualStyle = C1Input.VisualStyle.Office2007Silver

        FindCust.Enabled = False
        FindCust.VisualStyle = C1Input.VisualStyle.Office2007Silver

        CustName.Enabled = False

        VirtualKey.Enabled = False
        VirtualKey.VisualStyle = C1Input.VisualStyle.Office2007Silver

        TableCombo.Enabled = False
        TableCombo.VisualStyle = C1Input.VisualStyle.Office2007Silver

        ServiceList.Enabled = False
        ServiceList.VisualStyle = C1Input.VisualStyle.Office2007Silver

        TotalVisitor.Enabled = False

        VirtualCalculator.Enabled = False
        VirtualCalculator.VisualStyle = C1Input.VisualStyle.Office2007Silver

        BTNSave.Enabled = False
        BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver

        VirtualDate.Enabled = False
        VirtualDate.VisualStyle = C1Input.VisualStyle.Office2007Silver

    End Sub

    Private Sub CustomerInitialize()

        Dim defaultIndex As Long = -1, curIndex As Long = -1
        Dim TMPRecord As FbDataReader
        Try
            TMPRecord = MyDatabase.MyReader("SELECT CUSTISDFT,CUSTUID, CUSTNAME, CUSTADDR1, CUSTCATUID, (SELECT CUSTCATNAME FROM CUSTCAT WHERE CUSTCATUID = CUST.CUSTCATUID) FROM CUST ORDER BY CUSTNAME")

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

        Dim defaultIndex As Long = -1, curIndex As Long = -1
        Dim TMPRecord As FbDataReader
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
        Try
      TMPRecord = MyDatabase.MyReader("SELECT * FROM TABLELIST T LEFT OUTER JOIN FLOORNO F ON T.FLOORNOUID=F.FLOORNOUID WHERE T.IMAGE NOT IN ('9','10','5','6','7','8') AND F.FLOORDEPTUID ='" & DeptInfo.DeptUID & "' OR F.FLOORDEPTUID = '0' AND (TABLELISTACTV IS NULL OR TABLELISTACTV = 0 ) ORDER BY TABLELISTNAME")
            TableCombo.ClearItems()
            TableCombo.HoldFields()
            TableCombo.SuspendBinding()
            While TMPRecord.Read()
                TableCombo.AddItem(TMPRecord.Item("TABLELISTNAME") & ";" & TMPRecord.Item("TABLELISTUID"))
            End While

            TableCombo.ResumeBinding()
            TableCombo.SelectedIndex = TableCombo.FindString(SelectedTable.TableUID, 0, 1)
        Catch ex As Exception
        End Try
        TMPRecord = Nothing
    End Sub

    Private Sub CheckPermission(ByVal TypeUID As String, ByVal NewOrEdit As Boolean)

        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2202'")
        While TMPRecord.Read()
            UserPermition.PermitionInitialize(TMPRecord.Item("USERCATCREATEACCESS"), TMPRecord.Item("USERCATEDITACCESS"), TMPRecord.Item("USERCATDELETEACCESS"), TMPRecord.Item("USERCATREADACCESS"), TMPRecord.Item("USERCATPRINTACCESS"), TMPRecord.Item("USERCATCHANGEDATEACCESS"), TMPRecord.Item("USERCATCHANGETIMEACCESS"), TMPRecord.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
        End While

        With UserPermition
            If Not .ReadAccess Then
                MainPage.BTNCheckIn.Enabled = False
                MainPage.BTNCheckIn.VisualStyle = C1Input.VisualStyle.Office2007Silver

                ShowMessage(Me, "Maaf, anda tidak mempunyai akses terhadap form ini !" & vbNewLine & "Silakan hubungi administrator anda.")
                Me.Close()
            End If

            If NewOrEdit = True Then
                If .EditAccess Then
                    'RSStatus.Text = " View record "
                    BTNSave.Enabled = True
                    BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Blue
                Else
                    'RSStatus.Text = " Lock record "
                    FormStatus = FormStatusLib.OpenAndLock
                    Call OBJControlHandler(Me, FormStatus)
                    BTNSave.Enabled = False
                    BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver
                End If
            Else
                If .CreateAccess Then
                    'RSStatus.Text = " View record "
                    BTNSave.Enabled = True
                    BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Blue
                Else
                    'ShowMessage(Me, "Sorry, You are not allowed to create data !" & vbNewLine & "Please Contact Your Administrator.")
                    'Me.Close()
                    'RSStatus.Text = " Lock record "
                    BTNSave.Enabled = False
                    BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver
                End If
            End If

            If .ChangeDateAccess Then
                VirtualDate.Enabled = True
                VirtualDate.VisualStyle = C1Input.VisualStyle.Office2007Blue
            Else
                VirtualDate.Enabled = False
                VirtualDate.VisualStyle = C1Input.VisualStyle.Office2007Silver
            End If

            If .ChangeTimeAccess Then
                CurrentTime.Enabled = True
            Else
                CurrentTime.Enabled = False
            End If

        End With
    End Sub
    Public Sub BringCustInfo(ByVal CustUID As String)
        Dim CurrCust As Integer = CustomerList.FindString(CustUID, 0, 1)
        CustomerList.SelectedIndex = CurrCust
    End Sub

    Public Sub BringRSVInfo(ByVal RSVUID As String)
        Dim CurrRSV As Integer = ReservationList.FindString(RSVUID, 0, 1)
        ReservationList.SelectedIndex = CurrRSV
    End Sub
    Public Sub BringTableInfo(ByVal TableListUID As String)
        Dim CurrTable As Integer = TableCombo.FindString(Trim(TableListUID), 0, 1)
        TableCombo.SelectedIndex = CurrTable
    End Sub
    Public Sub BringServiceInfo(ByVal ServiceTypeUID As String)
        Dim CurrServ As Integer = ServiceList.FindString(Trim(ServiceTypeUID), 0, 1)
        ServiceList.SelectedIndex = CurrServ
    End Sub

    Public Sub CheckInInitialize(ByVal MBTransTableListUID As String)
        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM MBTRANS LEFT OUTER JOIN TABLELIST ON MBTRANS.MBTRANSUID = TABLELIST.TABLEMBTRANSUID WHERE TABLELISTUID = '" & MBTransTableListUID & "'")

        While TMPRecord.Read
            CurrentUID = TMPRecord.Item("MBTRANSUID")
            TransactionNo.Text = TMPRecord.Item("MBTRANSNO")

            CurrentDate.Value = TMPRecord.Item("MBTRANSDATE")
            dtOldDate.Value = TMPRecord.Item("MBTRANSDATE")
            DateLabel.Text = Format(CurrentDate.Value, "dddd , dd MMMM yyyy")
            TimeLabel.Text = Format(CurrentDate.Value, "hh:mm:ss tt")

            ReservationList.SelectedIndex = 0
            TableBack = TMPRecord.Item("MBTRANSTABLELISTUID")

            If Not IsDBNull(TMPRecord.Item("MBTRANSRSVTRANSUID")) Then
                RsvBack = TMPRecord.Item("MBTRANSRSVTRANSUID")
                Call EditReservationInitialize(TMPRecord.Item("MBTRANSRSVTRANSUID"))
            End If

            BringCustInfo(TMPRecord.Item("MBTRANSCUSTUID"))
            BringTableInfo(TMPRecord.Item("MBTRANSTABLELISTUID"))
            BringServiceInfo(TMPRecord.Item("MBTRANSSERVICETYPEUID"))

            CustName.Text = TMPRecord.Item("MBTRANSCUSTNAME")
            TotalVisitor.Text = TMPRecord.Item("MBTRANSPAXVAL")

            If (TMPRecord.Item("MBTRANSSTAT") > 1) Or (TMPRecord.Item("ISBILLED") = 1) Then
                LockFormOnUsedStatus()
            End If

        End While
    End Sub

    Private Sub SimpanNewCheckIn()
        Dim Query As String = Nothing
        Dim LastID = AutoUID()
        CurrentUID = LastID.ToString
        TransactionNo.Text = AutoIDNumber("2202", "MBTRANS", "MBTRANSNO")
        Shift = GetShift()
        If ReservationList.SelectedIndex > 0 Then
            Dim TMPRecord As FbDataReader
            Dim RSVUID As String = Nothing
            'Query = "SELECT * FROM RSVTRANS WHERE RSVTRANSUID LIKE '" & ReservationList.Columns(1).Text & "'"
            'TMPRecord = MyDatabase.MyReader(Query)
            'TMPRecord.Read()

            RSVUID = ReservationList.Columns(1).Text
            Query = "UPDATE RSVTRANS SET RSVTRANSSTAT = '1' WHERE RSVTRANSUID LIKE '" & RSVUID & "'"
            Call MyDatabase.MyAdapter(Query)
         
            Query = "INSERT INTO MBTRANS(MBTRANSUID,MBTRANSNO,MBTRANSDATE,MBTRANSDEPTUID,MBTRANSMODULETYPEID,MBTRANSSHIFTNO,MBTRANSPAXVAL,MBTRANSCUSTUID,MBTRANSCUSTNAME,MBTRANSTABLELISTUID,MBTRANSSERVICETYPEUID,MBTRANSRSVTRANSUID,MBTRANSDPVAL,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,ISBILLED,ISFISCAL) " & _
            "VALUES('" & LastID & "','" & TransactionNo.Text & "','" & Format(CurrentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2202','" & Shift & "','" & TotalVisitor.Text & "','" & CustomerList.Columns(1).Text & "','" & ReplacePetik(CustName.Text) & "','" & TableCombo.Columns(1).Text & "','" & ServiceList.Columns(1).Text & "'," & IIf(ReservationList.SelectedIndex > 0, "'" & ReservationList.Columns(1).Text & "'", "NULL") & ",'" & ReservationList.Columns(6).Text & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',0,0)"
            Call MyDatabase.MyAdapter(Query)

            TMPRecord = MyDatabase.MyReader("SELECT A.*, B.INVENLEVEL FROM RSVTRANSDT A, INVEN B WHERE A.RSVTRANSDTITEMUID=B.INVENUID AND A.RSVTRANSUID LIKE '" & RSVUID & "'")
            While TMPRecord.Read
                Dim DetailUID As String = AutoUID()

                Query = "INSERT INTO MBTRANSDT(MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,MBTRANSDTRSVTRANSUID,PRINT) " & _
                            "VALUES('" & DetailUID & "','" & LastID & "','" & TMPRecord.Item("RSVTRANSDTITEMUID") & "','" & ReplacePetik(TMPRecord.Item("RSVTRANSDTITEMNAME")) & "','" & ReplacePetik(TMPRecord.Item("RSVTRANSDTITEMMEASUNITDESC")) & "','" & TMPRecord.Item("RSVTRANSDTITEMQTY") & "','" & TMPRecord.Item("RSVTRANSDTITEMPRICE") & "','" & TMPRecord.Item("RSVTRANSDTSUBVAL") & "','" & ReplacePetik(TMPRecord.Item("RSVTRANSDTITEMNOTE")) & "','" & TMPRecord.Item("RSVTRANSDTISTAKEAWAY") & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & RSVUID & "','1')"
                Call MyDatabase.MyAdapter(Query)

                'Dim ItemRecord As FbDataReader

                'ItemRecord = MyDatabase.MyReader("SELECT * FROM INVEN WHERE INVENUID = '" & TMPRecord.Item("RSVTRANSDTITEMUID") & "'")
                'ItemRecord.Read()

                If CInt(TMPRecord.Item("INVENLEVEL")) = 3 Then

                    Dim ItemDetail As FbDataReader
                    'ItemDetail = MyDatabase.MyReader("SELECT DT.*,I.INVENNAME  FROM INVENDT DT LEFT OUTER JOIN INVEN I ON DT.INVENDTITEMUID = I.INVENUID WHERE DT.INVENUID='" & TMPRecord.Item("RSVTRANSDTITEMUID") & "'")
                    'While ItemDetail.Read
                    '    Query = "INSERT INTO MBTRANSDTDETAIL (MBTRANSDTDETAILUID,MBTRANSDTUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTITEMSTAT,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME) " & _
                    '    "VALUES('" & AutoUID() & "','" & DetailUID & "','" & ItemDetail("INVENDTITEMUID") & "','" & ReplacePetik(ItemDetail("INVENNAME")) & "','" & ReplacePetik(ItemDetail("ITEMMEASUNITDESC")) & "','" & ItemDetail("ITEMQTY") * TMPRecord.Item("RSVTRANSDTITEMQTY") & "','" & TMPRecord.Item("RSVTRANSDTITEMPRICE") & "','" & TMPRecord.Item("RSVTRANSDTITEMPRICE") * TMPRecord.Item("RSVTRANSDTITEMQTY") & "','" & ReplacePetik(TMPRecord.Item("RSVTRANSDTITEMNOTE")) & "','0','" & TMPRecord.Item("RSVTRANSDTISTAKEAWAY") & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "')"
                    '    Call MyDatabase.MyAdapter(Query)
                    'End While

                    ItemDetail = MyDatabase.MyReader("SELECT a.* FROM RSVTRANSDTDETAIL a WHERE a.RSVTRANSDTUID='" & TMPRecord.Item("RSVTRANSDTUID") & "'")
                    While ItemDetail.Read
                        Query = "INSERT INTO MBTRANSDTDETAIL (MBTRANSDTDETAILUID,MBTRANSDTUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTITEMSTAT,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME) " & _
                        "VALUES('" & AutoUID() & "','" & DetailUID & "','" & ItemDetail("RSVTRANSDTITEMUID") & "','" & ReplacePetik(ItemDetail("RSVTRANSDTITEMNAME")) & "','" & ReplacePetik(ItemDetail("RSVTRANSDTITEMMEASUNITDESC")) & "','" & ItemDetail("RSVTRANSDTITEMQTY") & "','0','0','" & ReplacePetik(TMPRecord("RSVTRANSDTITEMNOTE")) & "','0','" & TMPRecord("RSVTRANSDTISTAKEAWAY") & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "')"
                        Call MyDatabase.MyAdapter(Query)
                    End While
                End If

                'ItemRecord = Nothing
            End While

            Query = "INSERT INTO MBTRANSTABLELIST(MBTRANSDTTABLELISTUID,MBTRANSUID,MBTRANSTABLELISTUID) VALUES('" & AutoUID() & "','" & LastID & "','" & TableCombo.GetItemText(TableCombo.SelectedIndex, 1) & "')"
            Call MyDatabase.MyAdapter(Query)

        Else
            Query = "INSERT INTO MBTRANS(MBTRANSUID,MBTRANSNO,MBTRANSDATE,MBTRANSDEPTUID, MBTRANSMODULETYPEID,MBTRANSSHIFTNO,MBTRANSPAXVAL,MBTRANSCUSTUID,MBTRANSCUSTNAME,MBTRANSTABLELISTUID,MBTRANSSERVICETYPEUID,MBTRANSRSVTRANSUID,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,ISBILLED,ISFISCAL) " & _
                "VALUES('" & LastID & "','" & TransactionNo.Text & "','" & Format(CurrentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2202','" & Shift & "','" & TotalVisitor.Text & "','" & CustomerList.Columns(1).Text & "','" & ReplacePetik(CustName.Text) & "','" & TableCombo.Columns(1).Text & "','" & ServiceList.Columns(1).Text & "'," & IIf(ReservationList.SelectedIndex > 0, "'" & ReservationList.Columns(1).Text & "'", "NULL") & ",'" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',0,0)"
            Call MyDatabase.MyAdapter(Query)

            Query = "INSERT INTO MBTRANSTABLELIST(MBTRANSDTTABLELISTUID,MBTRANSUID,MBTRANSTABLELISTUID) VALUES('" & AutoUID() & "','" & LastID & "','" & TableCombo.GetItemText(TableCombo.SelectedIndex, 1) & "')"
            Call MyDatabase.MyAdapter(Query)

        End If

        Query = "UPDATE TABLELIST SET TABLEMBTRANSUID = '" & LastID & "' WHERE TABLELISTUID LIKE '" & TableCombo.GetItemText(TableCombo.SelectedIndex, 1) & "'"
        Call MyDatabase.MyAdapter(Query)        

    End Sub

    Private Sub InsertDetailOrderDariReservasi()
        Dim Query As String = Nothing
        Dim TMPRecord As FbDataReader

        TMPRecord = MyDatabase.MyReader("SELECT A.*, B.INVENLEVEL FROM RSVTRANSDT A, INVEN B WHERE A.RSVTRANSDTITEMUID=B.INVENUID AND A.RSVTRANSUID LIKE '" & ReservationList.Columns(1).Text & "'")

        While TMPRecord.Read
            Dim DetaillUID As String = AutoUID()

            Query = "INSERT INTO MBTRANSDT(MBTRANSDTUID,MBTRANSUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,MBTRANSDTRSVTRANSUID,PRINT) " & _
                        "VALUES('" & DetaillUID & "','" & CurrentUID & "','" & TMPRecord.Item("RSVTRANSDTITEMUID") & "','" & ReplacePetik(TMPRecord.Item("RSVTRANSDTITEMNAME")) & "','" & ReplacePetik(TMPRecord.Item("RSVTRANSDTITEMMEASUNITDESC")) & "','" & TMPRecord.Item("RSVTRANSDTITEMQTY") & "','" & TMPRecord.Item("RSVTRANSDTITEMPRICE") & "','" & TMPRecord.Item("RSVTRANSDTSUBVAL") & "','" & ReplacePetik(TMPRecord.Item("RSVTRANSDTITEMNOTE")) & "','" & TMPRecord.Item("RSVTRANSDTISTAKEAWAY") & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & TMPRecord.Item("RSVTRANSUID") & "','1')"
            Call MyDatabase.MyAdapter(Query)

            'Dim ItemRecord As FbDataReader
            Dim ItemDetailUID As String = DetaillUID

            'ItemRecord = MyDatabase.MyReader("SELECT * FROM INVEN WHERE INVENUID = '" & TMPRecord.Item("RSVTRANSDTITEMUID") & "'")
            'ItemRecord.Read()

            If CInt(TMPRecord.Item("INVENLEVEL")) = 3 Then
                Dim ItemDetail As FbDataReader
                ItemDetail = MyDatabase.MyReader("SELECT a.* FROM RSVTRANSDTDETAIL a WHERE a.RSVTRANSDTUID='" & TMPRecord.Item("RSVTRANSDTUID") & "'")

                'ItemDetail = MyDatabase.MyReader("SELECT DT.*,I.INVENNAME  FROM INVENDT DT LEFT OUTER JOIN INVEN I ON DT.INVENDTITEMUID = I.INVENUID WHERE DT.INVENUID='" & TMPRecord.Item("RSVTRANSDTITEMUID") & "'")
                While ItemDetail.Read
                    'Query = "INSERT INTO MBTRANSDTDETAIL (MBTRANSDTDETAILUID,MBTRANSDTUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTITEMSTAT,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME) " & _
                    '"VALUES ('" & AutoUID() & "','" & ItemDetailUID & "','" & ItemDetail("INVENDTITEMUID") & "','" & ReplacePetik(ItemDetail("INVENNAME")) & "','" & ReplacePetik(ItemDetail("ITEMMEASUNITDESC")) & "','" & ItemDetail("ITEMQTY") * TMPRecord.Item("RSVTRANSDTITEMQTY") & "','" & TMPRecord.Item("RSVTRANSDTITEMPRICE") & "','" & TMPRecord.Item("RSVTRANSDTITEMPRICE") * TMPRecord.Item("RSVTRANSDTITEMQTY") & "','" & ReplacePetik(TMPRecord.Item("RSVTRANSDTITEMNOTE")) & "','0','" & TMPRecord.Item("RSVTRANSDTISTAKEAWAY") & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "')"

                    Query = "INSERT INTO MBTRANSDTDETAIL (MBTRANSDTDETAILUID,MBTRANSDTUID,MBTRANSDTITEMUID,MBTRANSDTITEMNAME,MBTRANSDTITEMMEASUNITDESC,MBTRANSDTITEMQTY,MBTRANSDTITEMPRICE,MBTRANSDTSUBVAL,MBTRANSDTITEMNOTE,MBTRANSDTITEMSTAT,MBTRANSDTISTAKEAWAY,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME) " & _
                    "VALUES('" & AutoUID() & "','" & ItemDetailUID & "','" & ItemDetail("RSVTRANSDTITEMUID") & "','" & ReplacePetik(ItemDetail("RSVTRANSDTITEMNAME")) & "','" & ReplacePetik(ItemDetail("RSVTRANSDTITEMMEASUNITDESC")) & "','" & ItemDetail("RSVTRANSDTITEMQTY") & "','0','0','" & ReplacePetik(TMPRecord("RSVTRANSDTITEMNOTE")) & "','0','" & TMPRecord("RSVTRANSDTISTAKEAWAY") & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "','" & Format(Now, "MM/dd/yyyy, HH:mm:ss") & "')"

                    Call MyDatabase.MyAdapter(Query)
                End While
            End If

            'ItemRecord = Nothing
        End While
    End Sub

    Private Sub SimpanExistingCheckIn(ByVal MBTransUID As String)
        Dim Query As String = Nothing

        If RsvBack <> ReservationList.Columns(1).Text Then
            'Update Old Transaction Status
            Query = "UPDATE RSVTRANS SET RSVTRANSSTAT = '0' WHERE RSVTRANSUID LIKE '" & RsvBack & "'"
            Call MyDatabase.MyAdapter(Query)

            If ReservationList.SelectedIndex > 0 Then
                'Upate New Transaction Status
                Query = "UPDATE RSVTRANS SET RSVTRANSSTAT = '1' WHERE RSVTRANSUID LIKE '" & ReservationList.Columns(1).Text & "'"
                Call MyDatabase.MyAdapter(Query)
                Call InsertDetailOrderDariReservasi()
                If totalRow("RSVTRANSDT WHERE RSVTRANSUID='" & ReservationList.Columns(1).Text & "'") > 0 Then
                    If PrefInfo.PrintMakeOrder.ToString = "1" Then
                        Call ShowPrintPreview(True)
                    End If
                    If PrefInfo.UseKitchenPrintOut = "1" Then
                        Call toPrint()
                    End If
                    Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET PRINT=0 WHERE MBTRANSUID ='" & CurrentUID & "'")
                End If
            End If
        End If

        'Update MBTrans
        Query = "UPDATE MBTRANS SET MBTRANSDATE ='" & Format(CurrentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "',MBTRANSDEPTUID='" & DeptInfo.DeptUID & "',MBTRANSPAXVAL='" & TotalVisitor.Text & "',MBTRANSCUSTUID='" & CustomerList.Columns(1).Text & "',MBTRANSCUSTNAME='" & ReplacePetik(CustName.Text) & "',MBTRANSTABLELISTUID='" & TableCombo.Columns(1).Text & "',MBTRANSSERVICETYPEUID='" & ServiceList.Columns(1).Text & "',MBTRANSRSVTRANSUID=" & IIf(ReservationList.SelectedIndex > 0, "'" & ReservationList.Columns(1).Text & "'", "NULL") & ",MBTRANSDPVAL='" & IIf(ReservationList.Columns(6).Text = "", 0, ReservationList.Columns(6).Text) & "',MODIFIEDUSER='" & UserInformation.UserName & "',MODIFIEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE MBTransUID='" & MBTransUID & "'"
        Call MyDatabase.MyAdapter(Query)

        'Update MBTransTableList
        Query = "UPDATE MBTRANSTABLELIST SET MBTRANSTABLELISTUID='" & TableCombo.GetItemText(TableCombo.SelectedIndex, 1) & "' WHERE MBTRANSUID='" & MBTransUID & "'"
        Call MyDatabase.MyAdapter(Query)

        'Update Tablelist
        If TableBack <> TableCombo.GetItemText(TableCombo.SelectedIndex, 1) Then
            'Old Table
            Query = "UPDATE TABLELIST SET TABLEMBTRANSUID = NULL WHERE TABLELISTUID LIKE '" & TableBack & "'"
            Call MyDatabase.MyAdapter(Query)

            'New Table
            Query = "UPDATE TABLELIST SET TABLEMBTRANSUID = '" & MBTransUID & "' WHERE TABLELISTUID LIKE '" & TableCombo.GetItemText(TableCombo.SelectedIndex, 1) & "'"
            Call MyDatabase.MyAdapter(Query)
        End If
    End Sub
#End Region

#Region "Form Control Function"

    Private Sub Form_Check_In_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        Me.Location = New System.Drawing.Point(MainPage.Location.X + 270, MainPage.Location.Y + 44 + 90)
        Me.Text = "Check In - Table " & SelectedTable.TableName

        Me.Cursor = Cursors.Default
        Call BasicInitialize()

        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT COUNT(*) AS DATAEXISTS FROM MBTRANS LEFT OUTER JOIN TABLELIST ON MBTRANS.MBTRANSUID = TABLELIST.TABLEMBTRANSUID WHERE TABLELISTUID= '" & SelectedTable.TableUID & "'")

        While TMPRecord.Read
            If TMPRecord.Item("DATAEXISTS") = 0 Then
                Call GetDefaultValue()
                CheckInFormStatus = FormStatusLib.OpenAndNew
                cmdBarcode.Visible = False
            Else
                CheckInFormStatus = FormStatusLib.OpenAndEdit
                If PrefInfo.useBarcodeGift = "1" Then cmdBarcode.Visible = True Else cmdBarcode.Visible = False
            End If
        End While

        If CheckInFormStatus = FormStatusLib.OpenAndNew Then
            Call CheckPermission(UserInformation.UserTypeUID, False)
        ElseIf CheckInFormStatus = FormStatusLib.OpenAndEdit Then
            Call CheckPermission(UserInformation.UserTypeUID, True)
            Call CheckInInitialize(SelectedTable.TableUID)
        End If

    End Sub

    Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click

        If TableCombo.SelectedIndex = -1 Then
            ShowMessage(Me, "Silakan pilih meja terlebih dahulu !")
            TableCombo.Focus()
            Exit Sub
        End If

        If CustomerList.SelectedIndex = -1 Then
            ShowMessage(Me, "Silakan pilih customer terlebih dahulu !")
            CustomerList.Focus()
            Exit Sub
        End If

        If ServiceList.SelectedIndex = -1 Then
            ShowMessage(Me, "Silakah pilih tipe servis terlebih dahulu !")
            ServiceList.Focus()
            Exit Sub
        End If

        If CustName.Text = Nothing Then
            ShowMessage(Me, "Silakan isikan nama kontak customer !")
            CustName.Focus()
            Exit Sub
        End If

        If CLng(TotalVisitor.Text) < 1 Then
            ShowMessage(Me, "Silakan isikan jumlah customer yang datang !")
            TotalVisitor.Focus()
            Exit Sub
        End If

        If CheckInFormStatus = FormStatusLib.OpenAndNew Then
            If CheckApakahTableSudahTerisi() = True Then
                Exit Sub
            End If
        End If

        If CheckInFormStatus = FormStatusLib.OpenAndEdit Then
            If TableCombo.Columns(1).Text <> TableBack Then
                If CheckApakahTableSudahTerisi() = True Then
                    Exit Sub
                End If
            End If
        End If

        If CheckInFormStatus = FormStatusLib.OpenAndEdit Then
            Me.Cursor = Cursors.WaitCursor
            Call SimpanExistingCheckIn(CurrentUID)
            Call MainPage.TableReset(True)
            Call MainPage.TableClickInfo(selectedObject, myEvent)
            Me.Cursor = Cursors.Default
            Me.Close()
            Exit Sub
        ElseIf CheckInFormStatus = FormStatusLib.OpenAndNew Then
      'If totalRow("MBTRANS") >= CInt(getRealVal("—˜›‡…")) And pubIsDemo = True Then
      '    ShowMessage(Me, "Maaf, data ini tidak dapat disimpan karena versi demo telah habis !", True)
      '    Exit Sub
      'End If
            Me.Cursor = Cursors.WaitCursor
            Call SimpanNewCheckIn()
            Me.Cursor = Cursors.WaitCursor
            If ReservationList.SelectedIndex > 0 Then
                'ReservationList.Columns(1).Text
                If totalRow("RSVTRANSDT WHERE RSVTRANSUID='" & ReservationList.Columns(1).Text & "'") > 0 Then
                    If PrefInfo.PrintMakeOrder.ToString = "1" Then
                        Call ShowPrintPreview(True)
                    End If
                    If PrefInfo.UseKitchenPrintOut = "1" Then
                        Call toPrint()
                    End If
                    Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET PRINT=0 WHERE MBTRANSUID ='" & CurrentUID & "'")
                End If
            End If
            Me.Cursor = Cursors.Default

            Call MainPage.TableReset(True)
            Call MainPage.TableClickInfo(selectedObject, myEvent)
            Me.Cursor = Cursors.Default
            Me.Close()
        End If

    End Sub

    Private Sub ShowPrintPreview(Optional ByVal Nota As Boolean = False, Optional ByVal printerName As String = "")
        Form_Print_Preview.Close()
        Dim OBJNew As New Form_Print_Preview
        Dim Query As String

        Query = "SELECT a.MBTRANSUID, a.MBTRANSNO, a.MBTRANSDATE, a.MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME, a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID,(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = a.MBTRANSSERVICETYPEUID) AS MBTRANSSERVICETYPENAME, a.MBTRANSRSVTRANSUID, a.MBTRANSSUBVAL, a.MBTRANSDISCPERC, a.MBTRANSDISCVAL, a.MBTRANSTAXVAL1, a.MBTRANSTAXVAL2, a.MBTRANSDPVAL, a.MBTRANSTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT, a.MODIFIEDUSER, b.TABLELISTNAME " & _
                 "FROM MBTRANS a LEFT JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE MBTRANSUID = '" & CurrentUID & "'"
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
                 "FROM MBTRANS a LEFT JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE MBTRANSUID = '" & CurrentUID & "'"
        OBJNew.Printer = printerName
        OBJNew.Name = "Form_Print_Preview"
        OBJNew.RPTTitle = "Make Order"
        OBJNew.RPTDocument = New Make_Order_Split
        OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
        OBJNew.VersiNota = Nota
        OBJNew.ShowDialog()
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

    Private Sub toPrint()
        Dim rs As FbDataReader, selPrinterName As String = ""
        rs = MyDatabase.MyReader("SELECT DISTINCT(INVENKITCHENUID) AS KodeKitchen FROM INVEN A INNER JOIN " & _
                                "(SELECT IIF(B.MBTRANSDTITEMUID IS NULL,A.MBTRANSDTITEMUID,B.MBTRANSDTITEMUID) AS KodeBarang FROM MBTRANSDT A LEFT JOIN MBTRANSDTDETAIL B ON A.MBTRANSDTUID=B.MBTRANSDTUID WHERE A.PRINT=1 AND MBTRANSUID='" & CurrentUID & "') B " & _
                                "ON A.INVENUID=B.KodeBarang")
        While rs.Read = True
            selPrinterName = GetPrinterName(rs("KodeKitchen"))
            If Len(Trim(selPrinterName)) > 0 Then
                If KitchenSplitOrder = "0" Then
                    Make_Order.pubHarusCetakNotes = True
                    Make_Order.pubQueryLap = "SELECT B.* FROM INVEN A INNER JOIN " & _
                                            "(" & _
                                            "SELECT a.MBTRANSDTISTAKEAWAY, a.MBTRANSDTITEMNOTE, a.MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang, a.MBTRANSDTITEMNAME, a.MBTRANSDTITEMQTY,b.MBTRANSDTITEMNAME AS DETAILITEM,b.MBTRANSDTITEMQTY AS DETAILQTY " & _
                                            "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
                                            "WHERE MBTRANSUID ='" & CurrentUID & "' AND a.PRINT=1 " & _
                                            ") B ON A.INVENUID=B.KodeBarang WHERE INVENKITCHENUID='" & Trim(rs("KodeKitchen")) & "'"
                    'selPrinterName = GetPrinterName(rs("KodeKitchen"))

                    'If Len(Trim(selPrinterName)) > 0 Then
                    Call ShowPrintPreview(True, selPrinterName)
                Else
                    Dim rs2 As FbDataReader = MyDatabase.MyReader("SELECT B.MBTRANSDTUID,B.MBTRANSDTITEMQTY FROM INVEN A INNER JOIN " & _
                                            "(" & _
                                            "SELECT a.MBTRANSDTISTAKEAWAY, a.MBTRANSDTITEMNOTE,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTUID,b.MBTRANSDTDETAILUID) AS MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang,a.MBTRANSDTITEMQTY,b.MBTRANSDTITEMNAME AS DETAILITEM,b.MBTRANSDTITEMQTY AS DETAILQTY " & _
                                            "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
                                            "WHERE MBTRANSUID ='" & CurrentUID & "' AND a.PRINT=1 " & _
                                            ") B ON A.INVENUID=B.KodeBarang WHERE INVENKITCHENUID='" & Trim(rs("KodeKitchen")) & "'")
                    While rs2.Read = True
                        For i As Integer = 1 To CInt(rs2("MBTRANSDTITEMQTY"))
                            Make_Order_Split.pubHarusCetakNotes = True
                            Make_Order_Split.pubQueryLap = "SELECT B.* FROM INVEN A INNER JOIN " & _
                                                    "(" & _
                                                    "SELECT a.MBTRANSDTISTAKEAWAY, a.MBTRANSDTITEMNOTE,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTUID,b.MBTRANSDTDETAILUID) AS MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang, IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMNAME,a.MBTRANSDTITEMNAME || ' - ' || b.MBTRANSDTITEMNAME) AS MBTRANSDTITEMNAME, a.MBTRANSDTITEMQTY,b.MBTRANSDTITEMNAME AS DETAILITEM,b.MBTRANSDTITEMQTY AS DETAILQTY " & _
                                                    "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
                                                    "WHERE MBTRANSUID ='" & CurrentUID & "' AND a.PRINT=1 " & _
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

    Private Sub PrintOutDel()
        If PrefInfo.UseKitchenPrintOut <> "1" Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        Make_Order.pubQueryLap = ""
        Dim rs As FbDataReader, selPrinterName As String
        rs = MyDatabase.MyReader("SELECT DISTINCT(INVENKITCHENUID) AS KodeKitchen FROM INVEN A INNER JOIN " & _
                                "(SELECT IIF(B.MBTRANSDTITEMUID IS NULL,A.MBTRANSDTITEMUID,B.MBTRANSDTITEMUID) AS KodeBarang FROM MBTRANSDT A LEFT JOIN MBTRANSDTDETAIL B ON A.MBTRANSDTUID=B.MBTRANSDTUID WHERE a.MBTRANSUID='" & CurrentUID & "') B " & _
                                "ON A.INVENUID=B.KodeBarang")
        While rs.Read = True
            Make_Order.pubHarusCetakNotes = True
            Make_Order.pubQueryLap = "SELECT B.*,MBTRANSDTITEMQTY*(-1) AS MBTRANSDTITEMQTY,'Reservation Is Cancelled' AS MBTRANSDTITEMNOTE FROM INVEN A INNER JOIN " & _
                                    "(" & _
                                    "SELECT a.MBTRANSDTUID,IIF(b.MBTRANSDTITEMUID IS NULL,a.MBTRANSDTITEMUID,b.MBTRANSDTITEMUID) AS KodeBarang, a.MBTRANSDTITEMNAME,b.MBTRANSDTITEMNAME AS DETAILITEM,(b.MBTRANSDTITEMQTY/a.MBTRANSDTITEMQTY)*-1*a.MBTRANSDTITEMQTY AS DETAILQTY,a.MBTRANSDTITEMQTY " & _
                                    "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID  " & _
                                    "WHERE a.MBTRANSUID ='" & CurrentUID & "' " & _
                                    ") B ON A.INVENUID=B.KodeBarang WHERE INVENKITCHENUID='" & Trim(rs("KodeKitchen")) & "'"
            selPrinterName = GetPrinterName(rs("KodeKitchen"))
            If Len(Trim(selPrinterName)) > 0 Then
                Call ShowPrintPreview(True, selPrinterName)
            End If
        End While
        Me.Cursor = Cursors.Default
        rs = Nothing
    End Sub

    Private Sub TotalVisitor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TotalVisitor.KeyPress
        TotalVisitor.SelectionStart = Len(TotalVisitor.Text)
    End Sub

    Private Sub TotalVisitor_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TotalVisitor.TextChanged
        If IsNumeric(TotalVisitor.Text) = False Then
            TotalVisitor.Text = "1"
            Exit Sub
        Else
            If CDec(TotalVisitor.Text) > 999 Or CDec(TotalVisitor.Text) < 0 Then TotalVisitor.Text = "1"
            TotalVisitor.Text = FormatNumber(TotalVisitor.Text, 0)
        End If
    End Sub

    Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancel.Click
        Call MainPage.TableClickInfo(selectedObject, myEvent)
        Me.Close()
    End Sub

    Private Sub CustomerList_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles CustomerList.Change
        If CustomerList.SelectedIndex = -1 Then
            CustName.Text = Nothing
        Else
            CustName.Text = CustomerList.Columns(0).Text
        End If
    End Sub

    Private Sub VirtualKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKey.Click

        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(CustName, False)
        VirtuKey.ShowDialog()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ReservationList_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReservationList.Change
        With ReservationList.Columns
            If ReservationList.SelectedIndex > 0 Then
                CustomerList.SelectedIndex = CustomerList.FindString(.Item(7).Text, 0, 1)
                CustName.Text = .Item(8).Text
                ServiceList.SelectedIndex = ServiceList.FindString(.Item(9).Text, 0, 1)
                TotalVisitor.Text = .Item(5).Text
            Else
                CustomerList.SelectedIndex = -1
                CustName.Text = Nothing
                TotalVisitor.Text = 1
            End If
            Call ReservationLoadTable(ReservationList.SelectedIndex > 0)
        End With
    End Sub

    Private Sub ReservationList_TextChanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReservationList.TextChanged
        Dim Query As String = Nothing
        Dim LastID = AutoUID()
        Dim RSVUID As String = Nothing
        Dim TMPDel As DataSet
        Dim TMPBack As DataSet
        Dim counter As Integer

        If ReservationList.SelectedIndex > -1 Then
            Query = "SELECT * FROM RSVTRANS WHERE RSVTRANSUID LIKE '" & RsvBack & "'"
            TMPBack = MyDatabase.MyAdapter(Query)
            If TMPBack.Tables(0).Rows.Count > 0 Then
                If RsvBack <> Nothing And ReservationList.Columns(1).Text <> RsvBack Then
                    If ShowQuestion(Me, "Semua menu yang belum diproses akan terhapus secara otomatis. Lanjutkan ?") = True Then
                        Me.Cursor = Cursors.WaitCursor
                        Call PrintOutDel()
                        RSVUID = TMPBack.Tables(0).Rows(0).Item("RSVTRANSUID")

                        Query = "SELECT * FROM MBTRANSDT LEFT OUTER JOIN MBTRANS ON MBTRANS.MBTRANSUID = MBTRANSDT.MBTRANSUID WHERE MBTRANSRSVTRANSUID LIKE '" & RSVUID & "'"
                        TMPDel = MyDatabase.MyAdapter(Query)
                        For counter = 0 To TMPDel.Tables(0).Rows.Count - 1
                            If CInt(TMPDel.Tables(0).Rows(counter).Item("MBTRANSDTITEMSTAT")) > 0 Then
                                If ReservationList.Columns(1).Text <> RsvBack Then
                                    ShowMessage(Me, "Maaf, menu '" & TMPDel.Tables(0).Rows(counter).Item("MBTRANSDTITEMNAME") & "' tidak dapat dihapus, karena menu yang dipesan telah diproses !")
                                    'Exit Sub
                                End If
                            Else
                                Query = "UPDATE MBTRANSDT SET DELETEDUSER='" & UserInformation.UserName & "' WHERE MBTRANSDTITEMSTAT = '0' AND MBTRANSUID = '" & TMPDel.Tables(0).Rows(counter).Item("MBTRANSUID") & "'"
                                Call MyDatabase.MyAdapter(Query)

                                'Anjo - 28 Okt, Deleting detail dihandle oleh trigger
                                'Query = "DELETE FROM MBTRANSDTDETAIL WHERE MBTRANSDTITEMSTAT = '0' AND MBTRANSDTUID = '" & TMPDel.Tables(0).Rows(counter).Item("MBTRANSDTUID") & "'"
                                'Call MyDatabase.MyAdapter(Query)

                                Query = "DELETE FROM MBTRANSDT WHERE MBTRANSDTITEMSTAT = '0' AND MBTRANSUID = '" & TMPDel.Tables(0).Rows(counter).Item("MBTRANSUID") & "'"
                                Call MyDatabase.MyAdapter(Query)
                            End If
                        Next
                        Query = "UPDATE RSVTRANS SET RSVTRANSSTAT = '0' WHERE RSVTRANSUID LIKE '" & RSVUID & "'"
                        Call MyDatabase.MyAdapter(Query)

                        Query = "UPDATE MBTRANS SET MBTRANSRSVTRANSUID=NULL,MBTRANSDPVAL = '0' WHERE MBTRANSRSVTRANSUID LIKE '" & RSVUID & "'"
                        Call MyDatabase.MyAdapter(Query)


                        ShowMessage(Me, "Semua menu yang belum diproses telah berhasil dihapus !")
                        TMPBack = Nothing

                        BTNCancel.Enabled = False
                        BTNCancel.VisualStyle = C1Input.VisualStyle.Office2007Silver
                        Me.Cursor = Cursors.Default
                    End If
                End If
            End If
        End If
    End Sub

    Private Sub TableCombo_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles TableCombo.Change
        If CheckInFormStatus = FormStatusLib.OpenAndNew Then
            If CheckApakahTableSudahTerisi() = True Then
                Exit Sub
            End If
        End If
    End Sub

    Private Function CheckApakahTableSudahTerisi() As Boolean
        If TableCombo.SelectedIndex > -1 Then
            Me.Text = "Customer Check In - Table " & TableCombo.GetItemText(TableCombo.SelectedIndex, "Table Name")

            Dim TMPCheck As FbDataReader
            TMPCheck = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLELISTUID = '" & TableCombo.GetItemText(TableCombo.SelectedIndex, "Table UID") & "'")
            While TMPCheck.Read
                If Not IsDBNull(TMPCheck.Item("TABLEMBTRANSUID")) Then

                    ShowMessage(Me, "Maaf, meja '" & TableCombo.GetItemText(TableCombo.SelectedIndex, "Table Name") & "' saat ini sedang digunakan, silakan pilih meja yang lain !")
                    Dim TMPCombo As FbDataReader
                    TMPCombo = MyDatabase.MyReader("SELECT * FROM TABLELIST T LEFT OUTER JOIN FLOORNO F ON T.FLOORNOUID=F.FLOORNOUID WHERE T.IMAGE NOT IN ('9','10') AND F.FLOORDEPTUID ='" & DeptInfo.DeptUID & "' AND (TABLELISTACTV IS NULL OR TABLELISTACTV = 0 ) ORDER BY TABLELISTNAME")

                    TableCombo.ClearItems()
                    TableCombo.HoldFields()

                    While TMPCombo.Read()
                        TableCombo.AddItem(TMPCombo.Item("TABLELISTNAME") & ";" & TMPCombo.Item("TABLELISTUID"))
                    End While
                    TMPCombo = Nothing
                    Return True
                End If
            End While
        End If
    End Function

    Private Sub ReservationLoadTable(Optional ByVal LoadNOW As Boolean = False)

        If LoadNOW Then
            Dim TMPTableRsv As FbDataReader
            TMPTableRsv = MyDatabase.MyReader("SELECT RSVTRANSTABLELISTUID FROM RSVTRANS WHERE RSVTRANSUID LIKE '" & ReservationList.Columns(1).Text & "'")
            TMPTableRsv.Read()

            Dim CurTable As Integer = TableCombo.FindString(Trim(TMPTableRsv.Item("RSVTRANSTABLELISTUID")), 0, 1)
            TableCombo.SelectedIndex = CurTable
            TMPTableRsv = Nothing
        Else
            TableCombo.SelectedIndex = TableCombo.FindString(SelectedTable.TableUID, 0, 1)
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

    Private Sub FindReservation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindReservation.Click

        Me.Cursor = Cursors.WaitCursor
        Dim CustDialog As New Form_Reservation_Pick
        CustDialog.Name = "Form_Reservation_Pick"
        CustDialog.ParentOBJForm = Me
        CustDialog.ShowDialog()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub VirtualCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualCalculator.Click

        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        VirtuCalculator.OBJBind(TotalVisitor)
        VirtuCalculator.ShowDialog()
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub VirtualDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualDate.Click

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

        Call ReservationInitialize()
        Me.Cursor = Cursors.Default

    End Sub
#End Region

    Private Sub txtBarcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.GotFocus
        txtBarcode.Text = ""
    End Sub

    Private Sub txtBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode <> Keys.Return Then Exit Sub
        If Trim(txtBarcode.Text) = "" Then Exit Sub
        If totalRow("SALESPROMOREG WHERE SALESPROMOREGPROMOGENERATEDNO='" & ReplacePetik(txtBarcode.Text) & "'") = 0 Then
            ShowMessage(Me, "Maaf, Data gift Anda tidak ditemukan !")
            Exit Sub
        ElseIf totalRow("SALESPROMOREG WHERE SALESPROMOREGPROMOGENERATEDNO='" & ReplacePetik(txtBarcode.Text) & "' AND SALESPROMOREGUSAGETRANSUID IS NOT NULL") > 0 Then
            ShowMessage(Me, "Maaf, Data gift sudah terpakai !")
            Exit Sub
        ElseIf totalRow("SALESPROMOREG WHERE SALESPROMOREGPROMOGENERATEDNO='" & ReplacePetik(txtBarcode.Text) & "' AND SALESPROMOREGPROMOEXPIREDDATE<'" & Format(Now.Date, "yyyy/MM/dd") & "' AND SALESPROMOREGPROMOEXPIREDDATE IS NOT NULL") > 0 Then
            ShowMessage(Me, "Maaf, Data gift Anda sudah expired !")
            Exit Sub
        End If
        Dim tmpIDMBTrans As String = txtBarcode.Text
        If ShowQuestion(Me, "Konfirmasi atas transaksi penukaran Gift ?", True) = False Then txtBarcode.Focus() : Exit Sub
        MyDatabase.MyAdapter("UPDATE SALESPROMOREG SET SALESPROMOREGUSAGETRANSUID='" & CurrentUID & "' WHERE SALESPROMOREGPROMOGENERATEDNO='" & ReplacePetik(tmpIDMBTrans) & "'")
        txtBarcode.Focus()
    End Sub

    Private Sub txtBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.LostFocus
        If Trim(txtBarcode.Text) = "" Then txtBarcode.Text = "Type Barcode Here"
    End Sub

    Private Sub txtBarcode_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBarcode.TextChanged

    End Sub

    Private Sub cmdBarcode_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBarcode.Click
        Me.Cursor = Cursors.WaitCursor
        Dim formBarcode As New Form_Scaner_Barcode
        formBarcode.Name = "Barcode"
        formBarcode.mbTransUID = CurrentUID
        formBarcode.dateTrans = dtOldDate.Value
        formBarcode.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub
End Class