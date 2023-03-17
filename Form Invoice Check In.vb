Imports System
Imports C1.Win
Imports System.Windows.Forms
Imports System.Threading
Imports System.Globalization
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports FirebirdSql.Data.FirebirdClient

Public Class Form_Invoice_Check_In

#Region "Variable Reference"
    Dim CurrentUID As String = Nothing
    Dim RsvBack As String = Nothing
    Dim TableBack As String = Nothing
    Dim CheckInFormStatus As FormStatusLib
    Dim UpdateID As String = Nothing

    Dim UserPermition As New UserPermitionLib
    Dim FormStatus As FormStatusLib
    Public ParentOBJForm As Object
    Public OKStatus As Boolean = False
    Public selectedCustUID As String
    Public pubRSVUID As String
    Public publicAllowChangeDate As Boolean = False

    Dim Hour As String
    Dim Minute As String
    Dim Second As String
    Dim CurrDate As Date
    Dim Shift As String = Nothing
#End Region

#Region "Initialize & Object Function"

    Private Sub GetDefaultValue()
        TotalVisitor.Text = 1

        Hour = Now.Hour
        Minute = Now.Minute
        Second = Now.Second
        CurrDate = Now.Date

    End Sub

    Private Sub BasicInitialize()
        Call GetDefaultValue()
        Call ReservationInitialize()
        Call CustomerInitialize()
        Call ServiceInitialize()

        TimeLabel.Text = Format(Now, "hh:mm:ss tt")
    End Sub

    Private Sub LockFormOnUsedStatus()
        CustomerList.Enabled = False
        CustomerList.VisualStyle = C1Input.VisualStyle.Office2007Silver

        FindCust.Enabled = False
        FindCust.VisualStyle = C1Input.VisualStyle.Office2007Silver

        CustName.Enabled = False

        VirtualKey.Enabled = False
        VirtualKey.VisualStyle = C1Input.VisualStyle.Office2007Silver

        ServiceList.Enabled = False
        ServiceList.VisualStyle = C1Input.VisualStyle.Office2007Silver

        TotalVisitor.Enabled = False

        VirtualCalculator.Enabled = False
        VirtualCalculator.VisualStyle = C1Input.VisualStyle.Office2007Silver

        VirtualDate.Enabled = False
        VirtualDate.VisualStyle = C1Input.VisualStyle.Office2007Silver

    End Sub

    Private Sub CustomerInitialize()

        Dim defaultIndex As Long = -1, curIndex As Long = -1
        Dim TMPRecord As FbDataReader
        Try
            TMPRecord = MyDatabase.MyReader("SELECT CUSTUID, CUSTNAME, CUSTADDR1, CUSTCATUID, (SELECT CUSTCATNAME FROM CUSTCAT WHERE CUSTCATUID = CUST.CUSTCATUID) FROM CUST ORDER BY CUSTNAME")
            CustomerList.ClearItems()
            CustomerList.HoldFields()
            While TMPRecord.Read()
                curIndex = curIndex + 1
                CustomerList.AddItem(TMPRecord.Item("CUSTNAME") & ";" & TMPRecord.Item("CUSTUID"))
                If CStr(selectedCustUID) = CStr(TMPRecord.Item("CUSTUID")) Then
                    defaultIndex = curIndex
                End If
            End While

        Catch ex As Exception
        End Try
        TMPRecord = Nothing
        CustomerList.SelectedIndex = defaultIndex

    End Sub

    Private Sub ServiceInitialize()
        Dim TMPRecord As FbDataReader
        Dim TMPRecordDefault As FbDataReader
        Dim IndexService As Integer = -1
        Try
            TMPRecord = MyDatabase.MyReader("SELECT * FROM SERVICETYPE WHERE SERVICETYPEACTV IS NULL OR SERVICETYPEACTV = 0 ORDER BY SERVICETYPENAME")

            ServiceList.HoldFields()
            While TMPRecord.Read()
                ServiceList.AddItem(TMPRecord.Item("SERVICETYPENAME") & ";" & TMPRecord.Item("SERVICETYPEUID"))
            End While
            If MainPage.InvoiceApplication = True Then
                TMPRecordDefault = MyDatabase.MyReader("SELECT * FROM SERVICETYPE WHERE SERVICETYPEACTV IS NULL AND SERVICETYPEDEFAULT = 1 OR SERVICETYPEACTV = 0 AND SERVICETYPEDEFAULT = 1 ORDER BY SERVICETYPENAME")
                TMPRecordDefault.Read()

                IndexService = ServiceList.FindString(Trim(TMPRecordDefault.Item("SERVICETYPENAME")), 0, 0)
                ServiceList.SelectedIndex = IndexService
            Else
                IndexService = ServiceList.FindString(Trim(ServiceList.Text), 0, 0)
                ServiceList.SelectedIndex = IndexService
            End If
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
                    RSStatus.Text = " View record "
                Else
                    RSStatus.Text = " Lock record "
                    FormStatus = FormStatusLib.OpenAndLock
                    Call OBJControlHandler(Me, FormStatus)
                End If
            Else
                If .CreateAccess Then
                    RSStatus.Text = " View record "
                Else
                    'ShowMessage(Me, "Sorry, You are not allowed to create data !" & vbNewLine & "Please Contact Your Administrator.")
                    'Me.Close()
                    RSStatus.Text = " Lock record "
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

    Public Sub BringServiceInfo(ByVal ServiceTypeUID As String)
        Dim CurrServ As Integer = ServiceList.FindString(Trim(ServiceTypeUID), 0, 1)
        ServiceList.SelectedIndex = CurrServ
    End Sub

    Public Sub BringRSVInfo(ByVal RSVUID As String)
        Dim CurrRSV As Integer = ReservationList.FindString(RSVUID, 0, 1)
        ReservationList.SelectedIndex = CurrRSV
    End Sub

#End Region

#Region "Form Control Function"

    Private Sub Form_Invoice_Check_In_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        If screenWidth < 1024 Then
            'Me.Width = 327
            Me.Location = New System.Drawing.Point(0, 0)
            Dim origWidth As Integer = Me.Width
            Dim origHeight As Integer = Me.Height
            Me.Width = screenWidth
            Dim fSize As New SizeF((Me.Width / origWidth), (Me.Height / origHeight))
            GroupBox4.Scale(fSize)
            GroupBox1.Scale(fSize)
            GroupBox.Scale(fSize)
            GroupBox2.Scale(fSize)
            BTNOk.Scale(fSize)
            BTNCancel.Scale(fSize)
        Else
            Me.Location = New System.Drawing.Point(MainPage.Location.X + 270, MainPage.Location.Y + 44 + 100)
        End If
        Me.Cursor = Cursors.Default

        Call BasicInitialize()
        CheckInFormStatus = FormStatusLib.OpenAndEdit
        If publicAllowChangeDate = True Then
            VirtualDate.Visible = True
            VirtualDate.VisualStyle = C1Input.VisualStyle.Office2007Blue
        Else
            VirtualDate.Enabled = False
            VirtualDate.VisualStyle = C1Input.VisualStyle.Office2007Silver
        End If

    End Sub

    Private Sub BTNOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNOk.Click
        If CustomerList.SelectedIndex = -1 Then
            ShowMessage(Me, "Silakan pilih nama customer terlebih dahulu !")
            CustomerList.Focus()
            Exit Sub
        End If

        If ServiceList.SelectedIndex = -1 Then
            ShowMessage(Me, "Silakan pilih tipe servis terlebih dahulu !")
            ServiceList.Focus()
            Exit Sub
        End If

        If CustName.Text = Nothing Then
            ShowMessage(Me, "Silakan isikan nama kontak customer !")
            CustName.Focus()
            Exit Sub
        End If

        If IsNumeric(TotalVisitor.Text) = False Then
            ShowMessage(Me, "Silakan isikan jumlah customer yang datang !")
            Exit Sub
        End If

        If CLng(TotalVisitor.Text) < 1 Then
            ShowMessage(Me, "Silakan isikan jumlah customer yang datang !")
            Exit Sub
        End If

        OKStatus = True
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
            If CDec(TotalVisitor.Text) > 999 Or CDec(TotalVisitor.Text) < 0 Then TotalVisitor.Text = "1"
            TotalVisitor.Text = FormatNumber(TotalVisitor.Text, 0)
        End If
    End Sub

    Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancel.Click
        OKStatus = False
        Me.Close()
    End Sub

    Private Sub CustomerList_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles CustomerList.Change
        If pubRSVUID <> Nothing Then Exit Sub
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

    Private Sub FindCust_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindCust.Click
        Me.Cursor = Cursors.WaitCursor
        Dim CustDialog As New Form_Customer_Pick
        CustDialog.Name = "Form_Customer_Pick"
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
        DateLabel.Text = Format(CurrentDate.Value, "dd MMMM yyyy")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub ReservationInitialize()
        Dim TMPRecord As FbDataReader

        ReservationList.ClearItems()
        ReservationList.HoldFields()
        ReservationList.SuspendBinding()
        ReservationList.AddItem("* No Reservation;;;;;;;;* No Reservation;")
        If pubRSVUID = Nothing Then
            TMPRecord = MyDatabase.MyReader("SELECT a.RSVTRANSUID, a.RSVTRANSNO, a.RSVTRANSDATE, a.RSVTRANSRESERVEDDATE, a.RSVTRANSRESERVEDTIME, a.RSVTRANSPAXVAL, (SELECT CUSTCATUID FROM CUST WHERE CUSTUID = a.RSVTRANSCUSTUID)AS CUSTCATUID ,a.RSVTRANSCUSTUID, a.RSVTRANSCUSTNAME, a.RSVTRANSSERVICETYPEUID, a.RSVTRANSDPVAL, a.RSVTRANSSTAT FROM RSVTRANS a WHERE a.RSVTRANSDEPTUID='" & UserInformation.UserDeptUID & "' AND (a.RSVTRANSSTAT IS NULL OR a.RSVTRANSSTAT = 0 ) AND a.RSVTRANSRESERVEDDATE =  '" & Format(CurrentDate.Value, "dd.MM.yyyy") & "' ORDER BY RSVTRANSNO")
        Else
            TMPRecord = MyDatabase.MyReader("SELECT a.RSVTRANSUID, a.RSVTRANSNO, a.RSVTRANSDATE, a.RSVTRANSRESERVEDDATE, a.RSVTRANSRESERVEDTIME, a.RSVTRANSPAXVAL, (SELECT CUSTCATUID FROM CUST WHERE CUSTUID = a.RSVTRANSCUSTUID)AS CUSTCATUID ,a.RSVTRANSCUSTUID, a.RSVTRANSCUSTNAME, a.RSVTRANSSERVICETYPEUID, a.RSVTRANSDPVAL, a.RSVTRANSSTAT FROM RSVTRANS a WHERE a.RSVTRANSUID='" & pubRSVUID & "' OR ((a.RSVTRANSSTAT IS NULL OR a.RSVTRANSSTAT = 0 ) AND a.RSVTRANSRESERVEDDATE =  '" & Format(CurrentDate.Value, "dd.MM.yyyy") & "' AND a.RSVTRANSDEPTUID='" & UserInformation.UserDeptUID & "') ORDER BY RSVTRANSNO")
        End If
        While TMPRecord.Read()
            ReservationList.AddItem(TMPRecord.Item("RSVTRANSNO") & ";" & TMPRecord.Item("RSVTRANSUID") & ";" & FormatDateTime(TMPRecord.Item("RSVTRANSDATE"), DateFormat.ShortDate) & ";" & TMPRecord.Item("RSVTRANSRESERVEDDATE") & ";" & TMPRecord.Item("RSVTRANSRESERVEDTIME") & ";" & TMPRecord.Item("RSVTRANSPAXVAL") & ";" & TMPRecord.Item("RSVTRANSDPVAL") & ";" & TMPRecord.Item("RSVTRANSCUSTUID") & ";" & TMPRecord.Item("RSVTRANSCUSTNAME") & ";" & TMPRecord.Item("RSVTRANSSERVICETYPEUID"))
        End While

        ReservationList.ResumeBinding()
        If pubRSVUID <> Nothing Then
            ReservationList.SelectedIndex = ReservationList.FindString(pubRSVUID, 0, 1)
        Else
            ReservationList.SelectedIndex = 0
        End If
        FindReservation.Enabled = ReservationList.ListCount > 1
        TMPRecord = Nothing

    End Sub


#End Region

    Private Sub FindReservation_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles FindReservation.Click
        Me.Cursor = Cursors.WaitCursor
        Dim CustDialog As New Form_Reservation_Pick
        CustDialog.Name = "Form_Reservation_Pick"
        CustDialog.ParentOBJForm = Me
        CustDialog.ShowDialog()
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
        End With
    End Sub

    Private Sub ReservationList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReservationList.TextChanged
        Dim Query As String = Nothing
        Dim LastID = AutoUID()
        Dim RSVUID As String = Nothing
        Dim TMPDel As DataSet
        Dim TMPBack As DataSet
        Dim counter As Integer

        If ReservationList.SelectedIndex > -1 And pubRSVUID <> Nothing Then
            Query = "SELECT * FROM RSVTRANS WHERE RSVTRANSUID LIKE '" & pubRSVUID & "'"
            TMPBack = MyDatabase.MyAdapter(Query)
            If TMPBack.Tables(0).Rows.Count > 0 Then
                If ReservationList.Columns(1).Text <> pubRSVUID Then
                    If ShowQuestion(Me, "Semua menu yang belum diproses akan terhapus secara otomatis. Lanjutkan ?") = True Then
                        Me.Cursor = Cursors.WaitCursor
                        RSVUID = TMPBack.Tables(0).Rows(0).Item("RSVTRANSUID")
                        pubRSVUID = Nothing                        
                        Query = "SELECT * FROM MBTRANSDT LEFT OUTER JOIN MBTRANS ON MBTRANS.MBTRANSUID = MBTRANSDT.MBTRANSUID WHERE MBTRANSRSVTRANSUID LIKE '" & RSVUID & "'"
                        TMPDel = MyDatabase.MyAdapter(Query)
                        For counter = 0 To TMPDel.Tables(0).Rows.Count - 1
                            If CInt(TMPDel.Tables(0).Rows(counter).Item("MBTRANSDTITEMSTAT")) > 0 Then
                                If ReservationList.Columns(1).Text <> RSVUID Then
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

    Public Sub CheckInInitialize(ByVal MBTransTableListUID As String)
        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM MBTRANS WHERE MBTRANSRSVTRANSUID = '" & MBTransTableListUID & "'")

        While TMPRecord.Read
            CurrentUID = TMPRecord.Item("MBTRANSUID")
            TransactionNo.Text = TMPRecord.Item("MBTRANSNO")

            CurrentDate.Value = TMPRecord.Item("MBTRANSDATE")
            DateLabel.Text = Format(CurrentDate.Value, "dddd , dd MMMM yyyy")
            TimeLabel.Text = Format(CurrentDate.Value, "hh:mm:ss tt")

            ReservationList.SelectedIndex = 0
            TableBack = TMPRecord.Item("MBTRANSTABLELISTUID")

            If Not IsDBNull(TMPRecord.Item("MBTRANSRSVTRANSUID")) Then
                RsvBack = TMPRecord.Item("MBTRANSRSVTRANSUID")
            End If

            BringCustInfo(TMPRecord.Item("MBTRANSCUSTUID"))            
            BringServiceInfo(TMPRecord.Item("MBTRANSSERVICETYPEUID"))

            CustName.Text = TMPRecord.Item("MBTRANSCUSTNAME")
            TotalVisitor.Text = TMPRecord.Item("MBTRANSPAXVAL")

            'If (TMPRecord.Item("MBTRANSSTAT") > 1) Or (TMPRecord.Item("ISBILLED") = 1) Then
            '    Call LockFormOnUsedStatus()
            'End If

        End While
    End Sub

    Private Sub CustomerList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CustomerList.TextChanged

    End Sub
End Class