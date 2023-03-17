Imports System
Imports C1.Win
Imports System.Windows.Forms
Imports System.Threading
Imports System.Globalization
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports FirebirdSql.Data.FirebirdClient
Imports System.Text
Imports System.Security.Cryptography
' R25_2013_06_04_MIKO
Public Class Form_Check_In_Room

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
    Dim prosesHitungBonusHour As Boolean = False
    Dim paxVal As String
    Dim tmpBolehFree As String = Nothing

#End Region

#Region "Initialize & Object Function"

    Private Function getDefaultHarga() As String
        getDefaultHarga = "0"
        Dim idCatTable As String = TableCombo.Columns(3).Text
        Dim rs As FbDataReader
        Dim tmpJamInput As Date = Nothing, tmpJamAwal As Date = Nothing, tmpJamAkhir As Date = Nothing
        Dim tmpDayType As String = CurrentDate.Value.DayOfWeek + 1
        'If PrefInfo.RentDayType .ToString = "1" Then
        If CInt(Strings.Left(Format(CurrentDate.Value, "HH:mm"), 2)) > 0 And CInt(Strings.Left(Format(CurrentDate.Value, "HH:mm"), 2)) <= 5 Then
            tmpDayType = CStr(CInt(tmpDayType) - 1)
        End If
        'ElseIf PrefInfo.RentDayType .ToString = "2" Then
        'tmpDayType = 8
        'ElseIf PrefInfo.RentDayType .ToString = "3" Then
        'tmpDayType = 9
        'End If

        rs = MyDatabase.MyReader("SELECT TABLELISTCATDT.* FROM TABLELISTCAT INNER JOIN TABLELISTCATDT ON TABLELISTCAT.TABLELISTCATUID=TABLELISTCATDT.TABLELISTCATUID WHERE TABLELISTCAT.TABLELISTCATUID='" & idCatTable & "' AND TABLELISTCATDTDAYTYPE='" & tmpDayType & "'")
        While rs.Read()
            tmpJamAwal = CDate("2013/01/01 " & Format(CDate(rs("TABLELISTCATDTSTARTHR")), "HH:mm:ss"))
            If CInt(Strings.Left(Format(tmpJamAwal, "HH:mm"), 2)) > 0 And CInt(Strings.Left(Format(tmpJamAwal, "HH:mm"), 2)) <= 5 Then
                tmpJamAwal = tmpJamAwal.AddDays(1)
            End If
            tmpJamAkhir = CDate("2013/01/01 " & Format(CDate(rs("TABLELISTCATDTENDHR")), "HH:mm:ss"))
            If CInt(Strings.Left(Format(tmpJamAkhir, "HH:mm"), 2)) > 0 And CInt(Strings.Left(Format(tmpJamAkhir, "HH:mm"), 2)) <= 5 Then
                tmpJamAkhir = tmpJamAkhir.AddDays(1)
            End If
            tmpJamInput = CDate("2013/01/01 " & Format(CDate(CurrentDate.Value), "HH:mm:ss"))
            'If DeptInfo.roomFreePassAfterRent = "0" Then
            ' tmpJamInput = tmpJamInput.AddHours(CDbl(txtFreeHour.Text))
            ' End If
            If CInt(Strings.Left(Format(tmpJamInput, "HH:mm"), 2)) > 0 And CInt(Strings.Left(Format(tmpJamInput, "HH:mm"), 2)) <= 5 Then
                tmpJamInput = tmpJamInput.AddDays(1)
            End If
            'If Format(CDate(rs("TABLELISTCATDTSTARTHR")), "HH:mm:ss") <= Format(CDate(CurrentDate.Value), "HH:mm:ss") And Format(CDate(rs("TABLELISTCATDTENDHR")), "HH:mm:ss") >= Format(CDate(CurrentDate.Value), "HH:mm:ss") Then
            '    Return rs("TABLELISTCATDTPRICE")
            'End If

            If tmpJamAwal <= tmpJamInput And tmpJamInput <= tmpJamAkhir Then
                Return rs("TABLELISTCATDTPRICE")
            End If
        End While
        rs = Nothing
    End Function

    Private Sub ShowPrintPreview(Optional ByVal Nota As Boolean = False)
        Dim OBJNew As New Form_Print_Preview
        Dim Query As String
        Query = "SELECT MBTRANS.*," & _
        "(MBTRANSPAXVAL+MBTRANSPAXVAL3+MBTRANSPAXVAL5+MBTRANSPAXVAL2+MBTRANSPAXVAL4+MBTRANSPAXVAL6) AS totalMale," & _
        "(MBTRANSPAXVAL2+MBTRANSPAXVAL4+MBTRANSPAXVAL6) AS totalFemale," & _
        "(SELECT CUSTNO || '    ' || MBTRANSCUSTNAME FROM CUST WHERE CUSTUID=MBTRANSCUSTUID) AS nmCust, " & _
        "TABLELISTNAME,TABLELISTCATNAME," & _
        "(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID=MBTRANSSERVICETYPEUID) AS nmService," & _
        "'" & getDefaultHarga() & "' AS DefaultHarga,MBTRANSSTARTRENTHOURS+MBTRANSADDITIONALRENTHOURS AS ttlSewa," & _
        "(MBTRANSFREEHOURS)+MBTRANSLENGTHFREEMINUTES+MBTRANSBONUSMINUTES AS ttlMenit,dateadd((MBTRANS.MBTRANSSTARTRENTHOURS)+(MBTRANS.MBTRANSADDITIONALRENTHOURS)+(MBTRANS.MBTRANSFREEHOURS)+MBTRANS.MBTRANSLENGTHFREEMINUTES+MBTRANSBONUSMINUTES  minute to (CAST(CAST(MBTRANS.MBTRANSDATE AS DATE) || ' ' || MBTRANS.MBTRANSSTARTTIME AS timestamp))) AS jamHabis FROM MBTRANS INNER JOIN TABLELIST ON MBTRANSTABLELISTUID=TABLELISTUID INNER JOIN TABLELISTCAT ON TABLELIST.TABLELISTCATUID=TABLELISTCAT.TABLELISTCATUID WHERE MBTRANSUID='" & CurrentUID & "'"
        OBJNew.Name = "Form_Print_Preview"
        OBJNew.RPTTitle = "Check In"
        OBJNew.RPTDocument = New CheckIn
        OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
        OBJNew.VersiNota = Nota
        OBJNew.ShowDialog()

    End Sub

    Private Sub GetDefaultValue()

        TransactionNo.Text = AutoIDNumber("2202", "MBTRANS", "MBTRANSNO")
        TransactionNo.Text = "  -"

        Hour = Now.Hour
        Minute = Now.Minute
        Second = Now.Second
        CurrDate = Now.Date
        DateLabel.Text = Format(CurrentDate.Value, "dddd , dd MMMM yyyy")
        TimeLabel.Text = Format(CurrentTime.Value, "hh:mm:ss tt")
        lblEndHour.Text = TimeLabel.Text

    End Sub

    'Private Function encryptMD5(ByVal SourceText As String) As String
    '    'Create an encoding object to ensure the encoding standard for the source text
    '    Dim Ue As New UnicodeEncoding()
    '    'Retrieve a byte array based on the source text
    '    Dim ByteSourceText() As Byte = Ue.GetBytes(SourceText)
    '    'Instantiate an MD5 Provider object
    '    Dim Md5 As New MD5CryptoServiceProvider()
    '    'Compute the hash value from the source
    '    Dim ByteHash() As Byte = Md5.ComputeHash(ByteSourceText)
    '    'And convert it to String format for return
    '    Return Convert.ToBase64String(ByteHash).ToLower
    'End Function
    Private Function encryptMD5(ByVal strData As String) As String

        Dim objMD5 As New System.Security.Cryptography.MD5CryptoServiceProvider
        Dim arrData() As Byte
        Dim arrHash() As Byte

        ' first convert the string to bytes (using UTF8 encoding for unicode characters)
        arrData = System.Text.Encoding.UTF8.GetBytes(UCase(strData))

        ' hash contents of this byte array
        arrHash = objMD5.ComputeHash(arrData)

        ' thanks objects
        objMD5 = Nothing

        ' return formatted hash
        Return ByteArrayToString(arrHash)

    End Function

    ' utility function to convert a byte array into a hex string
    Private Function ByteArrayToString(ByVal arrInput() As Byte) As String

        Dim strOutput As New System.Text.StringBuilder(arrInput.Length)

        For i As Integer = 0 To arrInput.Length - 1
            strOutput.Append(arrInput(i).ToString("X2"))
        Next

        Return strOutput.ToString().ToLower

    End Function

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
        If PrefInfo.AllowMoveRoom = "1" Then
            TMPRecord = MyDatabase.MyReader("SELECT a.RSVTRANSUID, a.RSVTRANSNO, a.RSVTRANSDATE, a.RSVTRANSRESERVEDDATE, a.RSVTRANSRESERVEDTIME, a.RSVTRANSPAXVAL, (SELECT CUSTCATUID FROM CUST WHERE CUSTUID = a.RSVTRANSCUSTUID)AS CUSTCATUID ,a.RSVTRANSCUSTUID, a.RSVTRANSCUSTNAME, a.RSVTRANSSERVICETYPEUID, a.RSVTRANSDPVAL, a.RSVTRANSSTAT,a.RSVTRANSUSEDPMULTIPLE,a.RSVTRANSUSEDPVAL FROM " & _
                                            "RSVTRANS a " & _
                                            "WHERE (a.RSVTRANSUSEDPMULTIPLE='1' AND (RSVTRANSDPVAL-IIF(RSVTRANSUSEDPVAL IS NULL,0,RSVTRANSUSEDPVAL))>0 ) OR  (a.RSVTRANSRESERVEDDATE =  '" & Format(CurrentDate.Value, "dd.MM.yyyy") & "' AND a.RSVTRANSSTAT='0') ORDER BY a.RSVTRANSNO")
        Else
            'TMPRecord = MyDatabase.MyReader("SELECT a.RSVTRANSUID, a.RSVTRANSNO, a.RSVTRANSDATE, a.RSVTRANSRESERVEDDATE, a.RSVTRANSRESERVEDTIME, a.RSVTRANSPAXVAL, (SELECT CUSTCATUID FROM CUST WHERE CUSTUID = a.RSVTRANSCUSTUID)AS CUSTCATUID ,a.RSVTRANSCUSTUID, a.RSVTRANSCUSTNAME, a.RSVTRANSSERVICETYPEUID, a.RSVTRANSDPVAL, a.RSVTRANSSTAT,a.RSVTRANSUSEDPMULTIPLE,a.DPUSE FROM " & _
            '                                "(SELECT a.*,IIF((SELECT SUM(MBTRANSDPVAL) FROM MBTRANS WHERE MBTRANSRSVTRANSUID=RSVTRANSUID) IS NULL,0,(SELECT SUM(MBTRANSDPVAL) FROM MBTRANS WHERE MBTRANSRSVTRANSUID=RSVTRANSUID)) AS DPUSE FROM RSVTRANS a INNER JOIN TABLELIST b ON a.RSVTRANSTABLELISTUID = b.TABLELISTUID WHERE b.IMAGE NOT IN ('9','10')) a " & _
            '                                "WHERE (a.RSVTRANSUSEDPMULTIPLE='1' AND (RSVTRANSDPVAL-DPUSE)>0 ) OR  (a.RSVTRANSRESERVEDDATE =  '" & Format(CurrentDate.Value, "dd.MM.yyyy") & "' AND a.RSVTRANSSTAT='0') ORDER BY a.RSVTRANSNO")
            TMPRecord = MyDatabase.MyReader("SELECT a.RSVTRANSUID, a.RSVTRANSNO, a.RSVTRANSDATE, a.RSVTRANSRESERVEDDATE, a.RSVTRANSRESERVEDTIME, a.RSVTRANSPAXVAL, (SELECT CUSTCATUID FROM CUST WHERE CUSTUID = a.RSVTRANSCUSTUID)AS CUSTCATUID ,a.RSVTRANSCUSTUID, a.RSVTRANSCUSTNAME, a.RSVTRANSSERVICETYPEUID, a.RSVTRANSDPVAL, a.RSVTRANSSTAT,a.RSVTRANSUSEDPMULTIPLE,a.RSVTRANSUSEDPVAL FROM " & _
                                            "RSVTRANS a INNER JOIN TABLELIST b ON a.RSVTRANSTABLELISTUID = b.TABLELISTUID WHERE b.IMAGE NOT IN ('9','10') AND " & _
                                            "(a.RSVTRANSUSEDPMULTIPLE='1' AND (RSVTRANSDPVAL-IIF(RSVTRANSUSEDPVAL IS NULL,0,RSVTRANSUSEDPVAL))>0 ) OR  (a.RSVTRANSRESERVEDDATE =  '" & Format(CurrentDate.Value, "dd.MM.yyyy") & "' AND a.RSVTRANSSTAT='0') ORDER BY a.RSVTRANSNO")
        End If
        'Else
        ''TMPRecord = MyDatabase.MyReader("SELECT a.RSVTRANSUID, a.RSVTRANSNO, a.RSVTRANSDATE, a.RSVTRANSRESERVEDDATE, a.RSVTRANSRESERVEDTIME, a.RSVTRANSPAXVAL, (SELECT CUSTCATUID FROM CUST WHERE CUSTUID = a.RSVTRANSCUSTUID)AS CUSTCATUID ,a.RSVTRANSCUSTUID, a.RSVTRANSCUSTNAME, a.RSVTRANSSERVICETYPEUID, a.RSVTRANSDPVAL, a.RSVTRANSSTAT FROM RSVTRANS a INNER JOIN TABLELIST b ON a.RSVTRANSTABLELISTUID = b.TABLELISTUID WHERE b.IMAGE NOT IN ('9','10') AND (a.RSVTRANSSTAT IS NULL OR a.RSVTRANSSTAT = 0 ) AND a.RSVTRANSRESERVEDDATE =  '" & Format(CurrentDate.Value, "dd.MM.yyyy") & "' ORDER BY RSVTRANSNO")
        'If PrefInfo.AllowMoveRoom = "1" Then
        '    TMPRecord = MyDatabase.MyReader("SELECT a.RSVTRANSUID, a.RSVTRANSNO, a.RSVTRANSDATE, a.RSVTRANSRESERVEDDATE, a.RSVTRANSRESERVEDTIME, a.RSVTRANSPAXVAL, (SELECT CUSTCATUID FROM CUST WHERE CUSTUID = a.RSVTRANSCUSTUID)AS CUSTCATUID ,a.RSVTRANSCUSTUID, a.RSVTRANSCUSTNAME, a.RSVTRANSSERVICETYPEUID, a.RSVTRANSDPVAL, a.RSVTRANSSTAT FROM RSVTRANS a WHERE (a.RSVTRANSSTAT IS NULL OR a.RSVTRANSSTAT = 0 ) AND a.RSVTRANSRESERVEDDATE =  '" & Format(CurrentDate.Value, "dd.MM.yyyy") & "' ORDER BY RSVTRANSNO")
        'Else
        '    TMPRecord = MyDatabase.MyReader("SELECT a.RSVTRANSUID, a.RSVTRANSNO, a.RSVTRANSDATE, a.RSVTRANSRESERVEDDATE, a.RSVTRANSRESERVEDTIME, a.RSVTRANSPAXVAL, (SELECT CUSTCATUID FROM CUST WHERE CUSTUID = a.RSVTRANSCUSTUID)AS CUSTCATUID ,a.RSVTRANSCUSTUID, a.RSVTRANSCUSTNAME, a.RSVTRANSSERVICETYPEUID, a.RSVTRANSDPVAL, a.RSVTRANSSTAT FROM RSVTRANS a INNER JOIN TABLELIST b ON a.RSVTRANSTABLELISTUID = b.TABLELISTUID WHERE (b.IMAGE='9' OR b.IMAGE='10') AND (a.RSVTRANSSTAT IS NULL OR a.RSVTRANSSTAT = 0 ) AND a.RSVTRANSRESERVEDDATE =  '" & Format(CurrentDate.Value, "dd.MM.yyyy") & "' ORDER BY RSVTRANSNO")
        'End If
        'End If

        While TMPRecord.Read()
            'If PrefInfo.ALLOWUSEMULTIRESRV = "1" Then
            '    If TMPRecord.Item("RSVTRANSUSEDPMULTIPLE") = "1" Then
            '        If CDec(TMPRecord.Item("RSVTRANSDPVAL")) > CDec(TMPRecord.Item("DPUSE")) Then
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
        FindReservation.VisualStyle = IIf(FindReservation.Enabled = True, C1Input.VisualStyle.Office2007Blue, C1Input.VisualStyle.Office2007Silver)
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
            FindReservation.VisualStyle = IIf(FindReservation.Enabled = True, C1Input.VisualStyle.Office2007Blue, C1Input.VisualStyle.Office2007Silver)
        Catch ex As Exception
        End Try
        TMPRecord = Nothing
    End Sub

    Private Function GetFreeMnt() As String
        If CustomerList.ListCount = 0 Or prosesHitungBonusHour = False Then Return ""
        If TableCombo.Columns(4).Text = "0" Then Return ""
        Dim idCatCust As String = CustomerList.Columns(2).Text
        Dim tglData As Date = CurrentDate.Value.Date
        Dim lamaSewa As Integer = CInt(txtJam.Text) + CInt(txtTambahan.Text)
        Dim rs As FbDataReader
        Dim isOK As Boolean = False
        rs = MyDatabase.MyReader("SELECT BONUSHOURUID,VALUETIMES,VALIDTIMES,BONUSHOURCONDITION,BONUSHOURTYPE FROM BONUSHOUR INNER JOIN CUSTCAT ON BONUSHOURUID=CUSTCATBONUSMINUTESUID WHERE CUSTCATUID='" & idCatCust & "' AND BONUSHOURCONDITION<='" & lamaSewa & "' AND BONUSHOURSTARTDATE<='" & tglData & "' AND BONUSHOURENDDATE>='" & tglData & "' AND BONUSHOURACTV='0'")
        If rs.Read Then
            If IsDBNull(rs("BONUSHOURTYPE").ToString) = True Then
                If CInt(rs("BONUSHOURCONDITION")) <= CInt(txtJam.Text) Then
                    isOK = True
                End If
            Else
                If rs("BONUSHOURTYPE").ToString = "0" Then
                    If CInt(rs("BONUSHOURCONDITION")) <= CInt(txtJam.Text) Then
                        isOK = True
                    End If
                ElseIf rs("BONUSHOURTYPE").ToString = "1" Then
                    If CInt(rs("BONUSHOURCONDITION")) <= CInt(txtTambahan.Text) Then
                        isOK = True
                    End If
                Else
                    If CInt(rs("BONUSHOURCONDITION")) <= lamaSewa Then
                        isOK = True
                    End If
                End If
            End If
            If isOK = True Then
                Return rs(0).ToString & "$@$" & rs(1).ToString & "$@$" & rs(2).ToString & "$@$" & rs(3).ToString & "$@$" & rs(4).ToString
            Else
                Return ""
            End If
        Else
            Return ""
        End If
        rs = Nothing
    End Function

    Private Sub fillGridBonusHour()
        Dim rs As FbDataReader
        Dim tmpGetFreeMnt As String = GetFreeMnt()
        If tmpGetFreeMnt = "" Then
            'no action
            With grdMaster
                .Redraw = False
                .Rows.Count = 1
                .Redraw = True
            End With
            txtBonusMinutes.Text = "0"
        Else
            Dim arrData() As String
            arrData = Split(tmpGetFreeMnt, "$@$")
            Dim idBonusHour As String = Trim(arrData(0))
            Dim nilaiBonus As String = Trim(arrData(1))
            Dim isKelipatan As String = Trim(arrData(2))
            Dim syaratBonus As String = Trim(arrData(3))
            Dim bonustype As String = Trim(arrData(4))
            'CurrentDate.Value = Now
            'DateLabel.Text = Format(CurrentDate.Value, "dddd , dd MMMM yyyy")
            'TimeLabel.Text = Format(CurrentDate.Value, "hh:mm:ss tt")
            Dim idHari As Integer = 0
            'If PrefInfo.RentDayType  = "1" Then
            idHari = CInt(CDate(CurrentDate.Value).DayOfWeek + 1)
            If CInt(Format(CurrentDate.Value, "HH")) >= 0 And CInt(Format(CurrentDate.Value, "HH")) < 9 Then
                idHari = IIf(idHari - 1 = 0, 7, idHari - 1)
            End If
            'ElseIf PrefInfo.RentDayType  = "2" Then
            'idHari = 8
            'Else
            'idHari = 9
            ' End If

            rs = MyDatabase.MyReader("SELECT BONUSHOURDT.* FROM BONUSHOURDT WHERE BONUSHOURUID='" & idBonusHour & "' AND BONUSHOURDTDAYTYPE='" & idHari & "'")
            With grdMaster
                .Redraw = False
                .Rows.Count = 1
                While rs.Read = True
                    .AddItem("")
                    .Cols("jammulai").Item(.Rows.Count - 1) = IIf(CDate(rs("BONUSHOURDTSTARTHR")).Hour >= 0 And CDate(rs("BONUSHOURDTSTARTHR")).Hour <= 8, DateAdd(DateInterval.Day, 1, CDate(rs("BONUSHOURDTSTARTHR"))), CDate(rs("BONUSHOURDTSTARTHR")))
                    .Cols("jamsampai").Item(.Rows.Count - 1) = IIf(CDate(rs("BONUSHOURDTENDHR")).Hour >= 0 And CDate(rs("BONUSHOURDTENDHR")).Hour <= 8, DateAdd(DateInterval.Day, 1, CDate(rs("BONUSHOURDTENDHR"))), CDate(rs("BONUSHOURDTENDHR")))
                    '.Cols("harga").Item(.Rows.Count - 1) = rs("TABLELISTCATDTPRICE")
                    '.Cols("mincount").Item(.Rows.Count - 1) = rs("TABLELISTCATDTISMINCOUNT")
                End While
                .Redraw = True
            End With
            rs = Nothing
            Dim tmpFound As Integer = 0
            Dim tmpJmlJam As Integer = 0
            tmpJmlJam = IIf(bonustype = "0", CInt(txtJam.Text), IIf(bonustype = "1", CInt(txtTambahan.Text), CInt(txtJam.Text) + CInt(txtTambahan.Text)))
            With grdMaster
                For j As Integer = 0 To tmpJmlJam - 1
                    Dim tmpJam As String = CStr(Format(DateAdd(DateInterval.Hour, j, CurrentDate.Value), "hh:mm:ss tt"))
                    For i As Integer = 1 To .Rows.Count - 1
                        Dim tmpTtanggalJam As Date = IIf(CDate(CDate(.Cols("jammulai").Item(i)).Date & " " & tmpJam).Hour >= 0 And CDate(CDate(.Cols("jammulai").Item(i)).Date & " " & tmpJam).Hour <= 8, DateAdd(DateInterval.Day, 1, CDate(CDate(.Cols("jammulai").Item(i)).Date & " " & tmpJam)), CDate(CDate(.Cols("jammulai").Item(i)).Date & " " & tmpJam))
                        'If CDate(.Cols("jammulai").Item(i)) <= CDate(CDate(.Cols("jammulai").Item(i)).Date & " " & tmpJam) And CDate(.Cols("jamsampai").Item(i)) >= CDate(CDate(.Cols("jammulai").Item(i)).Date & " " & tmpJam) Then
                        'MsgBox(tmpTtanggalJam.Hour)
                        If CDate(.Cols("jammulai").Item(i)) <= tmpTtanggalJam And CDate(.Cols("jamsampai").Item(i)) >= tmpTtanggalJam Then
                            tmpFound = tmpFound + 1
                            Exit For
                        End If
                    Next
                Next
            End With
            If tmpFound < CInt(syaratBonus) Then
                txtBonusMinutes.Text = "0"
            Else
                Dim nilaiKelipatan As Integer = 1
                If isKelipatan = "1" Then
                    nilaiKelipatan = Fix(tmpFound / CInt(syaratBonus))
                    tmpFound = nilaiKelipatan
                Else
                    tmpFound = 1
                End If
                txtBonusMinutes.Text = FormatNumber(tmpFound * CInt(nilaiBonus), 0)
            End If
        End If
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

        txtJam.Enabled = False : cmdUpRent.Enabled = False : cmdUpRent.VisualStyle = C1Input.VisualStyle.Office2007Silver : cmdDownRent.Enabled = False : cmdDownRent.VisualStyle = C1Input.VisualStyle.Office2007Silver
        txtTambahan.Enabled = False : cmdUpTambahan.Enabled = False : cmdUpTambahan.VisualStyle = C1Input.VisualStyle.Office2007Silver : cmdDownTambahan.Enabled = False : cmdDownTambahan.VisualStyle = C1Input.VisualStyle.Office2007Silver
        txtFree.Enabled = False : cmdUpFree.Enabled = False : cmdUpFree.VisualStyle = C1Input.VisualStyle.Office2007Silver : cmdDownFree.Enabled = False : cmdDownFree.VisualStyle = C1Input.VisualStyle.Office2007Silver
        txtFreeHour.Enabled = False : cmdUpHour.Enabled = False : cmdUpHour.VisualStyle = C1Input.VisualStyle.Office2007Silver : cmdDownHour.Enabled = False : cmdDownHour.VisualStyle = C1Input.VisualStyle.Office2007Silver

        TotalVisitor.Enabled = False
        txtFemaleKid.Enabled = False : VirtualCalculator2.Enabled = False : VirtualCalculator2.VisualStyle = C1Input.VisualStyle.Office2007Silver
        txtMaleAdult.Enabled = False : VirtualCalculator3.Enabled = False : VirtualCalculator3.VisualStyle = C1Input.VisualStyle.Office2007Silver
        txtFemaleAdult.Enabled = False : VirtualCalculator4.Enabled = False : VirtualCalculator4.VisualStyle = C1Input.VisualStyle.Office2007Silver
        txtMale50.Enabled = False : VirtualCalculator5.Enabled = False : VirtualCalculator5.VisualStyle = C1Input.VisualStyle.Office2007Silver
        txtFemale50.Enabled = False : VirtualCalculator6.Enabled = False : VirtualCalculator6.VisualStyle = C1Input.VisualStyle.Office2007Silver

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
                CustomerList.AddItem(TMPRecord.Item("CUSTNAME") & ";" & TMPRecord.Item("CUSTUID") & ";" & TMPRecord.Item("CUSTCATUID"))
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
            If PrefInfo.AllowMoveRoom = "1" Then
                TMPRecord = MyDatabase.MyReader("SELECT T.*,TC.TABLELISTCATPAX,TC.TABLELISTCATISBONUSMINUTE FROM TABLELIST T LEFT JOIN TABLELISTCAT TC ON T.TABLELISTCATUID=TC.TABLELISTCATUID LEFT OUTER JOIN FLOORNO F ON T.FLOORNOUID=F.FLOORNOUID WHERE  F.FLOORDEPTUID ='" & DeptInfo.DeptUID & "' AND (TABLELISTACTV IS NULL OR TABLELISTACTV = 0 ) ORDER BY TABLELISTNAME")
            Else
                TMPRecord = MyDatabase.MyReader("SELECT T.*,TC.TABLELISTCATPAX,TC.TABLELISTCATISBONUSMINUTE FROM TABLELIST T LEFT JOIN TABLELISTCAT TC ON T.TABLELISTCATUID=TC.TABLELISTCATUID LEFT OUTER JOIN FLOORNO F ON T.FLOORNOUID=F.FLOORNOUID WHERE  F.FLOORDEPTUID ='" & DeptInfo.DeptUID & "' AND (T.IMAGE='9' OR T.IMAGE='10') AND (TABLELISTACTV IS NULL OR TABLELISTACTV = 0 ) ORDER BY TABLELISTNAME")
            End If
            TableCombo.ClearItems()
            TableCombo.HoldFields()
            TableCombo.SuspendBinding()
            While TMPRecord.Read()
                TableCombo.AddItem(TMPRecord.Item("TABLELISTNAME") & ";" & TMPRecord.Item("TABLELISTUID") & ";" & IIf(IsDBNull(TMPRecord.Item("TABLELISTCATPAX")), "", TMPRecord.Item("TABLELISTCATPAX")) & ";" & IIf(IsDBNull(TMPRecord.Item("TABLELISTCATUID")), "", TMPRecord.Item("TABLELISTCATUID")) & ";" & IIf(IsDBNull(TMPRecord.Item("TABLELISTCATISBONUSMINUTE")), "", TMPRecord.Item("TABLELISTCATISBONUSMINUTE")) & ";" & TMPRecord.Item("IMAGE").ToString)
            End While

            TableCombo.ResumeBinding()
            TableCombo.TopIndex = TableCombo.FindString(SelectedTable.TableUID, 0, 1)
            TableCombo.SelectedIndex = TableCombo.FindString(SelectedTable.TableUID, 0, 1)
            Application.DoEvents()
            Call effectSelOfTable()
        Catch ex As Exception
        End Try
        TMPRecord = Nothing
    End Sub

    Private Sub CheckPermission(ByVal TypeUID As String, ByVal NewOrEdit As Boolean)

        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2202'")
        While TMPRecord.Read()
            'UserPermition.PermitionInitialize(TMPRecord.Item("USERCATCREATEACCESS"), TMPRecord.Item("USERCATEDITACCESS"), TMPRecord.Item("USERCATDELETEACCESS"), TMPRecord.Item("USERCATREADACCESS"), TMPRecord.Item("USERCATPRINTACCESS"), TMPRecord.Item("USERCATCHANGEDATEACCESS"), TMPRecord.Item("USERCATCHANGETIMEACCESS"), TMPRecord.Item("USERCATMODIFIEDORDERAFTERDUMPED"), TMPRecord.Item("USERCATISFREEGIVENONCHECKIN"), TMPRecord.Item("USERCATMOVETABLEOVERCHECKIN"))
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
            If CheckInFormStatus = FormStatusLib.OpenAndEdit Then
                Dim arrPermission() As String = Split(isAllowToAccess(UserInformation.UserTypeUID), ",")
                If arrPermission(1) = "false" Then
                    'TableCombo.Enabled = True
                    TableCombo.ReadOnly = True
                Else
                    'TableCombo.Enabled = False
                    TableCombo.ReadOnly = False
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
        paxVal = TableCombo.Columns(2).Text
    End Sub
    Public Sub BringServiceInfo(ByVal ServiceTypeUID As String)
        Dim CurrServ As Integer = ServiceList.FindString(Trim(ServiceTypeUID), 0, 1)
        ServiceList.SelectedIndex = CurrServ
    End Sub

    Public Sub CheckInInitialize(ByVal MBTransTableListUID As String)

        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM MBTRANS LEFT OUTER JOIN TABLELIST ON MBTRANS.MBTRANSUID = TABLELIST.TABLEMBTRANSUID WHERE TABLELISTUID = '" & MBTransTableListUID & "'")

        While TMPRecord.Read
            ReservationList.Enabled = False
            CurrentUID = TMPRecord.Item("MBTRANSUID")
            TransactionNo.Text = TMPRecord.Item("MBTRANSNO")

            CurrentDate.Value = TMPRecord.Item("MBTRANSDATE")
            dtOldDate.Value = TMPRecord.Item("MBTRANSDATE")
            CurrDate = TMPRecord.Item("MBTRANSDATE")
            DateLabel.Text = Format(CurrentDate.Value, "dddd , dd MMMM yyyy")
            TimeLabel.Text = Format(CurrentDate.Value, "hh:mm:ss tt")

            ReservationList.SelectedIndex = 0
            TableBack = TMPRecord.Item("MBTRANSTABLELISTUID")

            If Not IsDBNull(TMPRecord.Item("MBTRANSRSVTRANSUID")) Then
                RsvBack = TMPRecord.Item("MBTRANSRSVTRANSUID")
                Call EditReservationInitialize(TMPRecord.Item("MBTRANSRSVTRANSUID"))
            End If

            Call BringCustInfo(TMPRecord.Item("MBTRANSCUSTUID"))
            Call BringTableInfo(TMPRecord.Item("MBTRANSTABLELISTUID"))
            Call BringServiceInfo(TMPRecord.Item("MBTRANSSERVICETYPEUID"))
            If IsDBNull(TMPRecord("MBTRANSSTARTRENTHOURS")) = False Then
                txtJam.Text = TMPRecord("MBTRANSSTARTRENTHOURS")
                txtTambahan.Text = TMPRecord("MBTRANSADDITIONALRENTHOURS")
                txtFree.Text = TMPRecord("MBTRANSLENGTHFREEMINUTES")
                txtFreeHour.Text = TMPRecord("MBTRANSFREEHOURS")
                txtBonusMinutes.Text = TMPRecord("MBTRANSBONUSMINUTES")
              
            Else
                txtJam.Text = "0" 'TMPRecord("MBTRANSSTARTRENTHOURS")
                txtTambahan.Text = "0" ' TMPRecord("MBTRANSADDITIONALRENTHOURS")
                txtFree.Text = "0" 'TMPRecord("MBTRANSLENGTHFREEMINUTES")
                txtFreeHour.Text = "0" 'TMPRecord("MBTRANSFREEHOURS")
                txtBonusMinutes.Text = "0" 'TMPRecord("MBTRANSBONUSMINUTES")
            End If
            txtJamInv.Text = txtJam.Text
            txtTambahanInv.Text = txtTambahan.Text
            txtFreeInv.Text = txtFree.Text
            txtFreeHourInv.Text = txtFreeHour.Text
            Call fillTotalHour()

            CustName.Text = TMPRecord.Item("MBTRANSCUSTNAME")
            TotalVisitor.Text = TMPRecord.Item("MBTRANSPAXVAL")
            txtFemaleKid.Text = IIf(IsDBNull(TMPRecord("MBTRANSPAXVAL2")) = True, 0, TMPRecord("MBTRANSPAXVAL2"))
            txtMaleAdult.Text = IIf(IsDBNull(TMPRecord("MBTRANSPAXVAL3")) = True, 0, TMPRecord("MBTRANSPAXVAL3"))
            txtFemaleAdult.Text = IIf(IsDBNull(TMPRecord("MBTRANSPAXVAL4")) = True, 0, TMPRecord("MBTRANSPAXVAL4"))
            txtMale50.Text = IIf(IsDBNull(TMPRecord("MBTRANSPAXVAL5")) = True, 0, TMPRecord("MBTRANSPAXVAL5"))
            txtFemale50.Text = IIf(IsDBNull(TMPRecord("MBTRANSPAXVAL6")) = True, 0, TMPRecord("MBTRANSPAXVAL6"))

            If TMPRecord.Item("ISBILLED").ToString = "1" Then
                CustomerList.Enabled = False
                FindCust.Enabled = False : FindCust.VisualStyle = C1Input.VisualStyle.Office2007Silver
                CustName.Enabled = False
                VirtualKey.Enabled = False : VirtualKey.VisualStyle = C1Input.VisualStyle.Office2007Silver
                ServiceList.Enabled = False
            End If
            If TMPRecord.Item("ISROOMBILLED").ToString = "1" Then
                GroupBox.Enabled = False
                GroupBox2.Enabled = False
                GroupBox1.Enabled = False
            End If
            If (TMPRecord.Item("MBTRANSSTAT") > 1) Then
                Call LockFormOnUsedStatus()
            Else

            End If
        End While
        TMPRecord = Nothing
    End Sub

    Private Sub SimpanNewCheckIn()
        Dim Query As String = Nothing
        Dim LastID = AutoUID()        
        TransactionNo.Text = AutoIDNumber("2202", "MBTRANS", "MBTRANSNO")

        If ReservationList.SelectedIndex > 0 Then
            Dim TMPRecord As FbDataReader
            Dim RSVUID As String = Nothing
            'Query = "SELECT * FROM RSVTRANS WHERE RSVTRANSUID LIKE '" & ReservationList.Columns(1).Text & "'"
            'TMPRecord = MyDatabase.MyReader(Query)
            'TMPRecord.Read()

            RSVUID = ReservationList.Columns(1).Text
            Query = "UPDATE RSVTRANS SET RSVTRANSSTAT = '1' WHERE RSVTRANSUID LIKE '" & RSVUID & "'"
            Call MyDatabase.MyAdapter(Query)
            CurrentUID = LastID
            Query = "INSERT INTO MBTRANS (MBTRANSUID,MBTRANSNO,MBTRANSDATE,MBTRANSDEPTUID,MBTRANSMODULETYPEID,MBTRANSSHIFTNO,MBTRANSPAXVAL,MBTRANSCUSTUID,MBTRANSCUSTNAME,MBTRANSTABLELISTUID,MBTRANSSERVICETYPEUID,MBTRANSRSVTRANSUID,MBTRANSDPVAL,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,ISROOMBILLED ,ISBILLED,ISFISCAL," & _
                     "MBTRANSSTARTTIME,MBTRANSSTARTRENTHOURS,MBTRANSADDITIONALRENTHOURS,MBTRANSFREEHOURS,MBTRANSLENGTHFREEMINUTES,MBTRANSROOMSUBVAL,MBTRANSROOMDISCPERC,MBTRANSROOMDISCVAL,MBTRANSROOMTAXVAL1,MBTRANSROOMTAXVAL2,MBTRANSROOMTOTVAL,MBTRANSPAXVAL2,MBTRANSPAXVAL3,MBTRANSPAXVAL4,MBTRANSPAXVAL5,MBTRANSPAXVAL6,MBTRANSOVERPAXVALUE,MBTRANSBONUSMINUTES,PRINTCOUNTER) " & _
                 "VALUES('" & LastID & "','" & TransactionNo.Text & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2202','" & Shift & "','" & TotalVisitor.Text & "','" & CustomerList.Columns(1).Text & "','" & ReplacePetik(CustName.Text) & "','" & TableCombo.Columns(1).Text & "','" & ServiceList.Columns(1).Text & "'," & IIf(ReservationList.SelectedIndex > 0, "'" & ReservationList.Columns(1).Text & "'", "NULL") & "," & IIf(ReservationList.SelectedIndex > 0, "'" & ReservationList.Columns(6).Text & "'", "'0'") & ",'" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',0,0,0," & _
                 "'" & Format(IIf(Format(Now, "mm") = "00", Now.AddMinutes(1), Now), "HH:mm:ss") & "','" & CInt(txtJam.Text) & "','" & CInt(txtTambahan.Text) & "','" & CInt(txtFreeHour.Text) & "','" & CInt(txtFree.Text) & "',0,0,0,0,0,0,'" & CInt(txtFemaleKid.Text) & "','" & CInt(txtMaleAdult.Text) & "','" & CInt(txtFemaleAdult.Text) & "','" & CInt(txtMale50.Text) & "','" & CInt(txtFemale50.Text) & "','0','" & CInt(txtBonusMinutes.Text) & "','1')"
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
            'Query = "INSERT INTO MBTRANS(MBTRANSUID,MBTRANSNO,MBTRANSDATE,MBTRANSDEPTUID, MBTRANSMODULETYPEID,MBTRANSSHIFTNO,MBTRANSPAXVAL,MBTRANSCUSTUID,MBTRANSCUSTNAME,MBTRANSTABLELISTUID,MBTRANSSERVICETYPEUID,MBTRANSRSVTRANSUID,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,ISBILLED,ISFISCAL) " & _
            '    "VALUES('" & LastID & "','" & TransactionNo.Text & "','" & Format(CurrentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2202','" & Shift & "','" & TotalVisitor.Text & "','" & CustomerList.Columns(1).Text & "','" & ReplacePetik(CustName.Text) & "','" & TableCombo.Columns(1).Text & "','" & ServiceList.Columns(1).Text & "'," & IIf(ReservationList.SelectedIndex > 0, "'" & ReservationList.Columns(1).Text & "'", "NULL") & ",'" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',0,0)"
            'Call MyDatabase.MyAdapter(Query)

            CurrentUID = LastID
            Query = "INSERT INTO MBTRANS (MBTRANSUID,MBTRANSNO,MBTRANSDATE,MBTRANSDEPTUID,MBTRANSMODULETYPEID,MBTRANSSHIFTNO,MBTRANSPAXVAL,MBTRANSCUSTUID,MBTRANSCUSTNAME,MBTRANSTABLELISTUID,MBTRANSSERVICETYPEUID,MBTRANSRSVTRANSUID,MBTRANSDPVAL,CREATEDUSER,MODIFIEDUSER,CREATEDDATETIME,MODIFIEDDATETIME,ISROOMBILLED,ISBILLED,ISFISCAL," & _
                     "MBTRANSSTARTTIME,MBTRANSSTARTRENTHOURS,MBTRANSADDITIONALRENTHOURS,MBTRANSFREEHOURS,MBTRANSLENGTHFREEMINUTES,MBTRANSROOMSUBVAL,MBTRANSROOMDISCPERC,MBTRANSROOMDISCVAL,MBTRANSROOMTAXVAL1,MBTRANSROOMTAXVAL2,MBTRANSROOMTOTVAL,MBTRANSPAXVAL2,MBTRANSPAXVAL3,MBTRANSPAXVAL4,MBTRANSPAXVAL5,MBTRANSPAXVAL6,MBTRANSOVERPAXVALUE,MBTRANSBONUSMINUTES,PRINTCOUNTER) " & _
                 "VALUES('" & CurrentUID & "','" & TransactionNo.Text & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & DeptInfo.DeptUID & "','2202','" & Shift & "','" & TotalVisitor.Text & "','" & CustomerList.Columns(1).Text & "','" & ReplacePetik(CustName.Text) & "','" & TableCombo.Columns(1).Text & "','" & ServiceList.Columns(1).Text & "'," & IIf(ReservationList.SelectedIndex > 0, "'" & ReservationList.Columns(1).Text & "'", "NULL") & "," & IIf(ReservationList.SelectedIndex > 0, "'" & ReservationList.Columns(6).Text & "'", "'0'") & ",'" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "',0,0,0," & _
                 "'" & Format(Now, "HH:mm:ss") & "','" & CInt(txtJam.Text) & "','" & CInt(txtTambahan.Text) & "','" & CInt(txtFreeHour.Text) & "','" & CInt(txtFree.Text) & "',0,0,0,0,0,0,'" & CInt(txtFemaleKid.Text) & "','" & CInt(txtMaleAdult.Text) & "','" & CInt(txtFemaleAdult.Text) & "','" & CInt(txtMale50.Text) & "','" & CInt(txtFemale50.Text) & "','0','" & CInt(txtBonusMinutes.Text) & "','1')"
            Call MyDatabase.MyAdapter(Query)

            Query = "INSERT INTO MBTRANSTABLELIST(MBTRANSDTTABLELISTUID,MBTRANSUID,MBTRANSTABLELISTUID) VALUES('" & AutoUID() & "','" & LastID & "','" & TableCombo.GetItemText(TableCombo.SelectedIndex, 1) & "')"
            Call MyDatabase.MyAdapter(Query)

        End If
        'Dim tmpRCPTID3 As String = encryptMD5(TableCombo.Columns(0).Text & "_" & CStr(Format(CurrentDate.Value, "yyyy_MM_dd")) & "_MIKO")
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
                        Call ShowPrintPreviewFNB(True)
                    End If
                    If PrefInfo.UseKitchenPrintOut = "1" Then
                        Call toPrint()
                    End If
                    Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET PRINT=0 WHERE MBTRANSUID ='" & CurrentUID & "'")
                End If
            End If
        End If

        'Update MBTrans
        Query = "UPDATE MBTRANS SET MBTRANSDATE ='" & Format(CurrentDate.Value, "dd.MM.yyyy, HH:mm:ss") & "',MBTRANSDEPTUID='" & DeptInfo.DeptUID & "',MBTRANSPAXVAL='" & TotalVisitor.Text & "',MBTRANSCUSTUID='" & CustomerList.Columns(1).Text & "',MBTRANSCUSTNAME='" & ReplacePetik(CustName.Text) & "',MBTRANSTABLELISTUID='" & TableCombo.Columns(1).Text & "',MBTRANSSERVICETYPEUID='" & ServiceList.Columns(1).Text & "',MBTRANSRSVTRANSUID=" & IIf(ReservationList.SelectedIndex > 0, "'" & ReservationList.Columns(1).Text & "'", "NULL") & ",MBTRANSDPVAL='" & IIf(ReservationList.Columns(6).Text = "", 0, ReservationList.Columns(6).Text) & "',MODIFIEDUSER='" & UserInformation.UserName & "',MODIFIEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "'," & _
                "MBTRANSSTARTRENTHOURS='" & CInt(txtJam.Text) & "',MBTRANSADDITIONALRENTHOURS='" & CInt(txtTambahan.Text) & "',MBTRANSFREEHOURS='" & CInt(txtFreeHour.Text) & "',MBTRANSLENGTHFREEMINUTES='" & CInt(txtFree.Text) & "',MBTRANSPAXVAL2='" & CInt(txtFemaleKid.Text) & "',MBTRANSPAXVAL3='" & CInt(txtMaleAdult.Text) & "',MBTRANSPAXVAL4='" & CInt(txtFemaleAdult.Text) & "',MBTRANSPAXVAL5='" & CInt(txtMale50.Text) & "',MBTRANSPAXVAL6='" & CInt(txtFemale50.Text) & "',MBTRANSOVERPAXVALUE=0,MBTRANSBONUSMINUTES='" & CInt(txtBonusMinutes.Text) & "' WHERE MBTransUID='" & MBTransUID & "'"
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
            'Dim tmpRCPTID3 As String = encryptMD5(TableCombo.Columns(0).Text & "_" & CStr(Format(CurrentDate.Value, "yyyy_MM_dd")) & "_MIKO")
            Query = "UPDATE TABLELIST SET TABLEMBTRANSUID = '" & MBTransUID & "' WHERE TABLELISTUID LIKE '" & TableCombo.GetItemText(TableCombo.SelectedIndex, 1) & "'"
            Call MyDatabase.MyAdapter(Query)
            'Else
            '    Dim tmpRCPTID3 As String = encryptMD5(TableCombo.Columns(0).Text & "_" & CStr(Format(Now.Date, "yyyy_MM_dd")) & "_MIKO")
            '    Query = "UPDATE TABLELIST SET RCPTID3=IIF(RCPTID3 IS NULL,'" & tmpRCPTID3 & "',RCPTID3) WHERE TABLELISTUID LIKE '" & TableCombo.GetItemText(TableCombo.SelectedIndex, 1) & "'"
            '    Call MyDatabase.MyAdapter(Query)
        End If
    End Sub
#End Region

#Region "Form Control Function"

    Private Sub Form_Check_In_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New System.Drawing.Point(MainPage.Location.X + 200, MainPage.Location.Y + 44)
        'Me.Location = New System.Drawing.Point(MainPage.Location.X + 270, MainPage.Location.Y + 44 + 90)
        Me.Text = "Check In - Table " & Replace(SelectedTable.TableName, vbNewLine, " ")

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
            txtTambahan.Enabled = False : cmdUpTambahan.Enabled = False : cmdUpTambahan.VisualStyle = C1Input.VisualStyle.Office2007Silver : cmdDownTambahan.VisualStyle = C1Input.VisualStyle.Office2007Silver
            txtFree.Enabled = False : cmdUpFree.Enabled = False : cmdUpFree.VisualStyle = C1Input.VisualStyle.Office2007Silver : cmdDownFree.Enabled = False : cmdDownFree.VisualStyle = C1Input.VisualStyle.Office2007Silver
            cmdFreeMnt.Enabled = False : cmdFreeMnt.VisualStyle = C1Input.VisualStyle.Office2007Silver
            BTNPrint.Visible = False
        ElseIf CheckInFormStatus = FormStatusLib.OpenAndEdit Then
            Call CheckPermission(UserInformation.UserTypeUID, True)
            Call CheckInInitialize(SelectedTable.TableUID)
            txtJam.Enabled = False : cmdUpRent.Enabled = False : cmdUpRent.VisualStyle = C1Input.VisualStyle.Office2007Silver : cmdDownRent.Enabled = False : cmdDownRent.VisualStyle = C1Input.VisualStyle.Office2007Silver
            cmdFreeMnt.Enabled = True : cmdFreeMnt.VisualStyle = C1Input.VisualStyle.Office2007Blue
            BTNPrint.Visible = True
        End If
        Call effectSelOfTable()
        prosesHitungBonusHour = True
    End Sub

    Private Function isAllowToAccess(ByVal userCatID As String) As String
        Dim rs As FbDataReader
        rs = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID='" & userCatID & "'  AND USERCATMODULETYPEID='2202'")
        If rs.Read = False Then
            isAllowToAccess = "false,false"
        Else
            If IsDBNull(rs("USERCATISFREEGIVENONCHECKIN")) = True Then
                isAllowToAccess = "false,"
            Else
                isAllowToAccess = IIf(rs("USERCATISFREEGIVENONCHECKIN").ToString = "0", "false", "true") & ","
            End If
            If IsDBNull(rs("USERCATMOVETABLEOVERCHECKIN")) = True Then
                isAllowToAccess = isAllowToAccess & "false"
            Else
                isAllowToAccess = isAllowToAccess & IIf(rs("USERCATMOVETABLEOVERCHECKIN").ToString = "0", "false", "true")
            End If
        End If
        rs = Nothing
    End Function

    Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click

        If TableCombo.SelectedIndex = -1 Then
            ShowMessage(Me, "Silakan pilih meja terlebih dahulu !")
            TableCombo.Focus()
            Exit Sub
        End If

        If CInt(txtJam.Text) + CInt(txtTambahan.Text) + CInt(txtFreeHour.Text) = 0 And (TableCombo.Columns(5).Text = "9" Or TableCombo.Columns(5).Text = "10") Then
            ShowMessage(Me, "Silakan jumlah jam sewa terlebih dahulu !")
            txtJam.Focus()
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
        If CInt(txtFree.Text) > 15 Then
            ShowMessage(Me, "Maaf, jumlah free minutes tidak boleh lebih besar dari 15 menit !", True)
            txtFree.Text = "0" : txtFree.Focus()
            Exit Sub
        End If
        If CLng(TotalVisitor.Text) + CLng(txtFemaleKid.Text) + CLng(txtMaleAdult.Text) + CLng(txtFemaleAdult.Text) + CLng(txtMale50.Text) + CLng(txtFemale50.Text) < 1 Then
            ShowMessage(Me, "Silakan isikan jumlah customer yang datang !")
            txtMaleAdult.Focus()
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
            'Call MainPage.reReadDataTable(TableCombo.Columns(1).Text)
            Call MainPage.TableClickInfo(selectedObject, myEvent)
            Me.Cursor = Cursors.Default
            Me.Close()
            Exit Sub
        ElseIf CheckInFormStatus = FormStatusLib.OpenAndNew Then
            If totalRow("MBTRANS") >= CInt(getRealVal("—˜›‡…")) And pubIsDemo = True Then
                Me.Cursor = Cursors.Default
                ShowMessage(Me, "Maaf, data ini tidak dapat disimpan karena versi demo telah habis !", True)
                Exit Sub
            End If
            Me.Cursor = Cursors.WaitCursor
            Call SimpanNewCheckIn()

            Me.Cursor = Cursors.WaitCursor
            If ReservationList.SelectedIndex > 0 Then
                If totalRow("RSVTRANSDT WHERE RSVTRANSUID='" & ReservationList.Columns(1).Text & "'") > 0 Then
                    If PrefInfo.PrintMakeOrder.ToString = "1" Then
                        Call ShowPrintPreviewFNB(True)
                    End If
                    If PrefInfo.UseKitchenPrintOut = "1" Then
                        Call toPrint()
                    End If
                End If
            End If
            Me.Cursor = Cursors.Default

            Call MainPage.TableReset(True)
            'Call MainPage.reReadDataTable(TableCombo.Columns(1).Text)
            Call MainPage.TableClickInfo(selectedObject, myEvent)
            Me.Cursor = Cursors.Default
            If ShowQuestion(Me, "Apakah anda akan mencetak nota Check In ?", True) = True Then
                Call ShowPrintPreview(True)
            End If
            Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET PRINT=0 WHERE MBTRANSUID ='" & CurrentUID & "'")
            Me.Close()
            End If

    End Sub

    Private Sub ShowPrintPreviewFNB(Optional ByVal Nota As Boolean = False, Optional ByVal printerName As String = "")
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
                    Call ShowPrintPreviewFNB(True, selPrinterName)
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
                Call ShowPrintPreviewFNB(True, selPrinterName)
            End If
        End While
        Me.Cursor = Cursors.Default
        rs = Nothing
    End Sub

    Private Sub TotalVisitor_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles TotalVisitor.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        TotalVisitor.SelectionStart = Len(TotalVisitor.Text)
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
        'Call fillGridBonusHour()
    End Sub

    Private Sub VirtualKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKey.Click

        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(CustName, False)
        VirtuKey.ShowDialog()
        CustName.Text = Strings.Left(CustName.Text, 40)
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub ReservationList_Change(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReservationList.TextChanged
        With ReservationList.Columns
            If ReservationList.SelectedIndex > 0 Then
                CustomerList.SelectedIndex = CustomerList.FindString(.Item(7).Text, 0, 1)
                CustName.Text = .Item(8).Text
                ServiceList.SelectedIndex = ServiceList.FindString(.Item(9).Text, 0, 1)
                TotalVisitor.Text = .Item(5).Text
            Else
                If CheckInFormStatus = FormStatusLib.OpenAndEdit Then Exit Sub
                CustomerList.SelectedIndex = -1
                CustName.Text = Nothing
                TotalVisitor.Text = "1"
                txtJam.Text = "0"
                txtTambahan.Text = "0"
                txtFree.Text = "0"
                lblTotalHour.Text = "0 Hours"
                lblEndHour.Text = TimeLabel.Text
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
        Else
            If paxVal = Nothing Then Exit Sub
            If CInt(TableCombo.Columns(2).Text) < CInt(paxVal) Then
                ShowMessage(Me, "Maaf, anda tidak bisa mengganti room yang lebih kecil !", True)
                Call BringTableInfo(TableBack)
                Exit Sub
            End If
        End If        
        'Call fillGridBonusHour()
        Call effectSelOfTable()
        Call fillTotalHour()
    End Sub

    Private Sub effectSelOfTable()
        If TableCombo.Columns(5).Text.ToString = "9" Or TableCombo.Columns(5).Text.ToString = "10" Then            
            If CheckInFormStatus = FormStatusLib.OpenAndNew Then
                Label9.Enabled = True : txtJam.Enabled = True : Label17.Enabled = True : cmdUpRent.Enabled = True : cmdDownRent.Enabled = True
                cmdUpRent.VisualStyle = C1Input.VisualStyle.Office2007Blue : cmdDownRent.VisualStyle = C1Input.VisualStyle.Office2007Blue
                Label10.Enabled = False : txtTambahan.Enabled = False : Label1.Enabled = False : cmdUpTambahan.Enabled = False : cmdDownTambahan.Enabled = False
                cmdUpTambahan.VisualStyle = C1Input.VisualStyle.Office2007Silver : cmdDownTambahan.VisualStyle = C1Input.VisualStyle.Office2007Silver
            Else
                Label9.Enabled = False : txtJam.Enabled = False : Label17.Enabled = False : cmdUpRent.Enabled = False : cmdDownRent.Enabled = False
                cmdUpRent.VisualStyle = C1Input.VisualStyle.Office2007Silver : cmdDownRent.VisualStyle = C1Input.VisualStyle.Office2007Silver
                Label10.Enabled = True : txtTambahan.Enabled = True : Label1.Enabled = True : cmdUpTambahan.Enabled = True : cmdDownTambahan.Enabled = True
                cmdUpTambahan.VisualStyle = C1Input.VisualStyle.Office2007Blue : cmdDownTambahan.VisualStyle = C1Input.VisualStyle.Office2007Blue
            End If
            Label20.Enabled = True : txtFreeHour.Enabled = True : Label21.Enabled = True : cmdUpHour.Enabled = True : cmdDownHour.Enabled = True
            cmdUpHour.VisualStyle = C1Input.VisualStyle.Office2007Blue : cmdDownHour.VisualStyle = C1Input.VisualStyle.Office2007Blue
            Label19.Enabled = True : lblTotalHour.Enabled = True : Label16.Enabled = True : lblEndHour.Enabled = True
        Else
            txtJam.Text = "0" : txtTambahan.Text = "0" : txtFreeHour.Text = "0"
            Label9.Enabled = False : txtJam.Enabled = False : Label17.Enabled = False : cmdUpRent.Enabled = False : cmdDownRent.Enabled = False
            cmdUpRent.VisualStyle = C1Input.VisualStyle.Office2007Silver : cmdDownRent.VisualStyle = C1Input.VisualStyle.Office2007Silver
            Label10.Enabled = False : txtTambahan.Enabled = False : Label1.Enabled = False : cmdUpTambahan.Enabled = False : cmdDownTambahan.Enabled = False
            cmdUpTambahan.VisualStyle = C1Input.VisualStyle.Office2007Silver : cmdDownTambahan.VisualStyle = C1Input.VisualStyle.Office2007Silver
            Label20.Enabled = False : txtFreeHour.Enabled = False : Label21.Enabled = False : cmdUpHour.Enabled = False : cmdDownHour.Enabled = False
            cmdUpHour.VisualStyle = C1Input.VisualStyle.Office2007Silver : cmdDownHour.VisualStyle = C1Input.VisualStyle.Office2007Silver
            Label19.Enabled = False : lblTotalHour.Enabled = False : Label16.Enabled = False : lblEndHour.Enabled = False
        End If
    End Sub

    Private Function CheckApakahTableSudahTerisi() As Boolean
        Me.Text = "Customer Check In - Table " & TableCombo.GetItemText(TableCombo.SelectedIndex, "Table Name")

        Dim TMPCheck As FbDataReader
        TMPCheck = MyDatabase.MyReader("SELECT * FROM TABLELIST WHERE TABLELISTUID = '" & TableCombo.GetItemText(TableCombo.SelectedIndex, "Table UID") & "'")
        While TMPCheck.Read
            If Not IsDBNull(TMPCheck.Item("TABLEMBTRANSUID")) Then

                ShowMessage(Me, "Maaf, meja '" & TableCombo.GetItemText(TableCombo.SelectedIndex, "Table Name") & "' saat ini sedang digunakan, silakan pilih meja yang lain !")
                Dim TMPCombo As FbDataReader
                'TMPCombo = MyDatabase.MyReader("SELECT TABLELIST.*,TABLELISTCATPAX FROM TABLELIST INNER JOIN TABLELISTCAT ON TABLELIST.TABLELISTCATUID=TABLELISTCAT.TABLELISTCATUID WHERE TABLEMBTRANSUID IS NULL ORDER BY TABLELISTNAME")
                If PrefInfo.AllowMoveRoom = "1" Then
                    TMPCombo = MyDatabase.MyReader("SELECT T.*,TC.TABLELISTCATPAX,TC.TABLELISTCATISBONUSMINUTE FROM TABLELIST T LEFT JOIN TABLELISTCAT TC ON T.TABLELISTCATUID=TC.TABLELISTCATUID LEFT OUTER JOIN FLOORNO F ON T.FLOORNOUID=F.FLOORNOUID WHERE  F.FLOORDEPTUID ='" & DeptInfo.DeptUID & "' AND (TABLELISTACTV IS NULL OR TABLELISTACTV = 0 ) ORDER BY TABLELISTNAME")
                Else
                    TMPCombo = MyDatabase.MyReader("SELECT T.*,TC.TABLELISTCATPAX,TC.TABLELISTCATISBONUSMINUTE FROM TABLELIST T LEFT JOIN TABLELISTCAT TC ON T.TABLELISTCATUID=TC.TABLELISTCATUID LEFT OUTER JOIN FLOORNO F ON T.FLOORNOUID=F.FLOORNOUID WHERE  F.FLOORDEPTUID ='" & DeptInfo.DeptUID & "' AND (T.IMAGE='9' OR T.IMAGE='10') AND (TABLELISTACTV IS NULL OR TABLELISTACTV = 0 ) ORDER BY TABLELISTNAME")
                End If
                TableCombo.ClearItems()
                TableCombo.HoldFields()

                While TMPCombo.Read()
                    TableCombo.AddItem(TMPCombo.Item("TABLELISTNAME") & ";" & TMPCombo.Item("TABLELISTUID") & ";" & TMPCombo.Item("TABLELISTCATPAX"))
                End While
                TMPCombo = Nothing
                Return True
            End If
        End While
    End Function

    Private Sub ReservationLoadTable(Optional ByVal LoadNOW As Boolean = False)
        If LoadNOW Then
            If CheckInFormStatus = FormStatusLib.OpenAndNew Then
                Dim TMPTableRsv As FbDataReader
                TMPTableRsv = MyDatabase.MyReader("SELECT RSVTRANSTABLELISTUID,RSVTRANSRENTHOUR FROM RSVTRANS WHERE RSVTRANSUID LIKE '" & ReservationList.Columns(1).Text & "'")
                TMPTableRsv.Read()

                Dim CurTable As Integer = TableCombo.FindString(Trim(TMPTableRsv.Item("RSVTRANSTABLELISTUID")), 0, 1)
                TableCombo.SelectedIndex = CurTable
                txtJam.Text = TMPTableRsv("RSVTRANSRENTHOUR")
                TMPTableRsv = Nothing
                Call fillTotalHour()
            End If
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

    Private Sub VirtualCalculator_Click(ByVal sender As System.Object, ByVal e As System.EventArgs)

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
        VirtualDate.isCancel = False
        VirtualDate.publicChosenDate = CurrDate

        VirtualDate.ShowDialog()
        If VirtualDate.isCancel = True Then Me.Cursor = Cursors.Default : Exit Sub
        CurrentDate.Text = VirtualDate.publicChosenDate
        CurrDate = VirtualDate.publicChosenDate
        DateLabel.Text = Format(CurrentDate.Value, "dddd , dd MMMM yyyy")

        Call ReservationInitialize()
        VirtualDate.Close()
        Me.Cursor = Cursors.Default

    End Sub
#End Region

    Private Sub txtJam_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtJam.GotFocus

    End Sub

    Private Sub txtJam_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtJam.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        txtJam.SelectionStart = Len(txtJam.Text)
    End Sub

    Private Sub txtJam_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtJam.LostFocus
        If IsNumeric(txtJam.Text) = False Then txtJam.Text = 0 : Call fillTotalHour() : Exit Sub
        Call fillTotalHour()
        txtJam.Text = FormatNumber(txtJam.Text, 0, , , TriState.True)
    End Sub

    Private Sub txtTambahan_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtTambahan.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        txtTambahan.SelectionStart = Len(txtTambahan.Text)
    End Sub

    Private Sub txtTambahan_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtTambahan.KeyUp

    End Sub

    Private Sub txtTambahan_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtTambahan.LostFocus
        If IsNumeric(txtTambahan.Text) = False Then txtTambahan.Text = 0 : Call fillTotalHour() : Exit Sub
        Call fillTotalHour()
        txtTambahan.Text = FormatNumber(txtTambahan.Text, 0, , , TriState.True)
    End Sub

    Private Sub txtFree_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFree.KeyPress
        'e.Handled = True
        'Dim arrPermission() As String = Split(isAllowToAccess(UserInformation.UserTypeUID), ",")

        'If arrPermission(0) = "false" Then
        '    Dim OBJNew As New Form_User_Authorize_Dialog
        '    OBJNew.Name = "Form_User_Authorize_Dialog"
        '    OBJNew.ParentOBJForm = Me
        '    OBJNew.NeedAuthorizationForMakeBill = True
        '    OBJNew.ShowDialog()

        '    If Authorize = False Then Exit Sub

        '    Dim TMPRecordAuthorize As FbDataReader
        '    TMPRecordAuthorize = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2202'")
        '    While TMPRecordAuthorize.Read()
        '        UserPermition.PermitionInitialize(TMPRecordAuthorize.Item("USERCATCREATEACCESS"), TMPRecordAuthorize.Item("USERCATEDITACCESS"), TMPRecordAuthorize.Item("USERCATDELETEACCESS"), TMPRecordAuthorize.Item("USERCATREADACCESS"), TMPRecordAuthorize.Item("USERCATPRINTACCESS"), TMPRecordAuthorize.Item("USERCATCHANGEDATEACCESS"), TMPRecordAuthorize.Item("USERCATCHANGETIMEACCESS"), TMPRecordAuthorize.Item("USERCATMODIFIEDORDERAFTERDUMPED"), IIf(IsDBNull(TMPRecordAuthorize("USERCATISFREEGIVENONCHECKIN")) = True, False, TMPRecordAuthorize("USERCATISFREEGIVENONCHECKIN")), IIf(IsDBNull(TMPRecordAuthorize("USERCATMOVETABLEOVERCHECKIN")) = True, False, TMPRecordAuthorize("USERCATMOVETABLEOVERCHECKIN")))
        '    End While

        '    With UserPermition
        '        If .AllowFreeTime Then
        '            Authorize = True
        '        Else
        '            ShowMessage(Me, "Maaf, anda tidak mempunyai akses untuk manambah atau mengurangi free room !")
        '            UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
        '            Call MainPage.StatusBarInitialize()

        '            FormStatus = FormStatusLib.OpenAndLock
        '            Call OBJControlHandler(Me, FormStatus)

        '            Exit Sub
        '        End If
        '    End With
        'End If
        'e.Handled = False
        'If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
        '    e.Handled = True
        'End If
        'If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
        '    e.Handled = False
        'End If
        'txtFree.SelectionStart = Len(txtFree.Text)
    End Sub

    Private Sub txtFree_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFree.LostFocus
        If Authorize = True Then
            Authorize = False
            UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
            Call MainPage.StatusBarInitialize()
        End If
        'If IsNumeric(txtFree.Text) = False Then txtFree.Text = 0 : Exit Sub
        'txtFree.Text = FormatNumber(txtFree.Text, 0, , , TriState.True)
    End Sub

    Private Sub txtFemaleKid_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFemaleKid.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        txtFemaleKid.SelectionStart = Len(txtFemaleKid.Text)
    End Sub

    Private Sub txtFemaleKid_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFemaleKid.LostFocus
        If IsNumeric(txtFemaleKid.Text) = False Then txtFemaleKid.Text = 0 : Exit Sub
        txtFemaleKid.Text = FormatNumber(txtFemaleKid.Text, 0, , , TriState.True)
    End Sub

    Private Sub txtMaleAdult_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMaleAdult.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        txtMaleAdult.SelectionStart = Len(txtMaleAdult.Text)
    End Sub

    Private Sub txtMaleAdult_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMaleAdult.LostFocus
        If IsNumeric(txtMaleAdult.Text) = False Then txtMaleAdult.Text = 0 : Exit Sub
        txtMaleAdult.Text = FormatNumber(txtMaleAdult.Text, 0, , , TriState.True)
    End Sub

    Private Sub txtFemaleAdult_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFemaleAdult.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        txtFemaleAdult.SelectionStart = Len(txtFemaleAdult.Text)
    End Sub

    Private Sub txtFemaleAdult_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFemaleAdult.LostFocus
        If IsNumeric(txtFemaleAdult.Text) = False Then txtFemaleAdult.Text = 0 : Exit Sub
        txtFemaleAdult.Text = FormatNumber(txtFemaleAdult.Text, 0, , , TriState.True)
    End Sub

    Private Sub txtMale50_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtMale50.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        txtMale50.SelectionStart = Len(txtMale50.Text)
    End Sub

    Private Sub txtMale50_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtMale50.LostFocus
        If IsNumeric(txtMale50.Text) = False Then txtMale50.Text = 0 : Exit Sub
        txtMale50.Text = FormatNumber(txtMale50.Text, 0, , , TriState.True)
    End Sub

    Private Sub txtFemale50_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFemale50.KeyPress
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        txtFemale50.SelectionStart = Len(txtFemale50.Text)
    End Sub

    Private Sub txtFemale50_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFemale50.LostFocus
        If IsNumeric(txtFemale50.Text) = False Then txtFemale50.Text = 0 : Exit Sub
        txtFemale50.Text = FormatNumber(txtFemale50.Text, 0, , , TriState.True)
    End Sub

    Private Sub VirtualCalculator_Click_1(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualCalculator.Click, VirtualCalculator2.Click, VirtualCalculator3.Click, VirtualCalculator4.Click, VirtualCalculator5.Click, VirtualCalculator6.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        If sender.name = "VirtualCalculator" Then
            VirtuCalculator.OBJBind(TotalVisitor)
        ElseIf sender.name = "VirtualCalculator2" Then
            VirtuCalculator.OBJBind(txtFemaleKid)
        ElseIf sender.name = "VirtualCalculator3" Then
            VirtuCalculator.OBJBind(txtMaleAdult)
        ElseIf sender.name = "VirtualCalculator4" Then
            VirtuCalculator.OBJBind(txtFemaleAdult)
        ElseIf sender.name = "VirtualCalculator5" Then
            VirtuCalculator.OBJBind(txtMale50)
        ElseIf sender.name = "VirtualCalculator6" Then
            VirtuCalculator.OBJBind(txtFemale50)
        End If
        VirtuCalculator.ShowDialog()
        If sender.name = "VirtualCalculator" Then
            If CInt(TotalVisitor.Text) > 100 Then
                ShowMessage(Me, "Maaf jumlah yang Anda masukkan tidak valid !", True)
                TotalVisitor.Text = "0"
                TotalVisitor.Focus()
            End If
        ElseIf sender.name = "VirtualCalculator2" Then
            If CInt(txtFemaleKid.Text) > 100 Then
                ShowMessage(Me, "Maaf jumlah yang Anda masukkan tidak valid !", True)
                txtFemaleKid.Text = "0"
                txtFemaleKid.Focus()
            End If
        ElseIf sender.name = "VirtualCalculator3" Then
            If CInt(txtMaleAdult.Text) > 100 Then
                ShowMessage(Me, "Maaf jumlah yang Anda masukkan tidak valid !", True)
                txtMaleAdult.Text = "0"
                txtMaleAdult.Focus()
            End If
        ElseIf sender.name = "VirtualCalculator4" Then
            If CInt(txtFemaleAdult.Text) > 100 Then
                ShowMessage(Me, "Maaf jumlah yang Anda masukkan tidak valid !", True)
                txtFemaleAdult.Text = "0"
                txtFemaleAdult.Focus()
            End If
        ElseIf sender.name = "VirtualCalculator5" Then
            If CInt(txtMale50.Text) > 100 Then
                ShowMessage(Me, "Maaf jumlah yang Anda masukkan tidak valid !", True)
                txtMale50.Text = "0"
                txtMale50.Focus()
            End If
        ElseIf sender.name = "VirtualCalculator6" Then
            If CInt(txtFemale50.Text) > 100 Then
                ShowMessage(Me, "Maaf jumlah yang Anda masukkan tidak valid !", True)
                txtFemale50.Text = "0"
                txtFemale50.Focus()
            End If
        End If
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub TotalVisitor_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles TotalVisitor.LostFocus
        If IsNumeric(TotalVisitor.Text) = False Then TotalVisitor.Text = 0 : Exit Sub
        TotalVisitor.Text = FormatNumber(TotalVisitor.Text, 0, , , TriState.True)
    End Sub

    Private Sub txtJam_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtJam.TextChanged
        If IsNumeric(txtJam.Text) = False Or Trim(txtJam.Text) = "" Then txtJam.Text = 0
        ' Call fillGridBonusHour()
        Call fillTotalHour()
    End Sub

    Private Sub fillTotalHour()
        If IsNumeric(txtJam.Text) = False Or Trim(txtJam.Text) = "" Then txtJam.Text = 0
        If IsNumeric(txtTambahan.Text) = False Or Trim(txtTambahan.Text) = "" Then txtTambahan.Text = 0
        If IsNumeric(txtFree.Text) = False Or Trim(txtFree.Text) = "" Then txtFree.Text = 0
        If IsNumeric(txtFreeHour.Text) = False Or Trim(txtFreeHour.Text) = "" Then txtFreeHour.Text = 0
        If IsNumeric(txtBonusMinutes.Text) = False Or Trim(txtBonusMinutes.Text) = "" Then txtBonusMinutes.Text = 0
        Dim tmpTotalMenit As Integer = CDec(txtJam.Text) + CDec(txtTambahan.Text) + CDec(txtFreeHour.Text)
        Dim tmpSisaMenit As Integer = 0
        Dim fixTotal As Integer = 0
        If tmpTotalMenit > 0 Then
            fixTotal = Fix(tmpTotalMenit / 60)
            tmpSisaMenit = tmpTotalMenit - (fixTotal * 60)
        End If
        lblTotalHour.Text = FormatNumber(fixTotal, 0).ToString & " Hours" & IIf(tmpSisaMenit > 0, " " & tmpSisaMenit.ToString & " Minutes", "")
        Dim tmpJam As Date
        tmpJam = CurrentDate.Value
        lblEndHour.Text = Format(DateAdd(DateInterval.Minute, tmpTotalMenit, tmpJam), "hh:mm:ss tt")
    End Sub

    Private Sub txtTambahan_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTambahan.TextChanged
        If IsNumeric(txtTambahan.Text) = True And IsNumeric(txtTambahanInv.Text) = True Then
            If CInt(txtTambahanInv.Text) > CInt(txtTambahan.Text) Then
                ShowMessage(Me, "Maaf, anda tidak dapat memasukkan jumlah jam kurang dari jumlah jam awal !", True)
                txtTambahan.Text = txtTambahanInv.Text
                txtTambahan.Focus()
            End If
        End If
        If IsNumeric(txtTambahan.Text) = False Or Trim(txtTambahan.Text) = "" Then txtTambahan.Text = 0
        'Call fillGridBonusHour()
        Call fillTotalHour()
    End Sub

    Private Sub cmdUpRent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpRent.Click, cmdUpTambahan.Click, cmdUpHour.Click
        Dim arrPermission() As String
        If tmpBolehFree = "1" Then
            arrPermission = Split("true", "false")
        Else
            arrPermission = Split(isAllowToAccess(UserInformation.UserTypeUID), ",")
        End If

        If sender.tag = "3" Or sender.tag = "4" Then
            If arrPermission(0) = "false" Then
                Dim OBJNew As New Form_User_Authorize_Dialog
                OBJNew.Name = "Form_User_Authorize_Dialog"
                OBJNew.ParentOBJForm = Me
                OBJNew.NeedAuthorizationForMakeBill = True
                OBJNew.ShowDialog()

                If Authorize = False Then Exit Sub

                Dim TMPRecordAuthorize As FbDataReader
                TMPRecordAuthorize = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2202'")
                While TMPRecordAuthorize.Read()
                    UserPermition.PermitionInitialize(TMPRecordAuthorize.Item("USERCATCREATEACCESS"), TMPRecordAuthorize.Item("USERCATEDITACCESS"), TMPRecordAuthorize.Item("USERCATDELETEACCESS"), TMPRecordAuthorize.Item("USERCATREADACCESS"), TMPRecordAuthorize.Item("USERCATPRINTACCESS"), TMPRecordAuthorize.Item("USERCATCHANGEDATEACCESS"), TMPRecordAuthorize.Item("USERCATCHANGETIMEACCESS"), TMPRecordAuthorize.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
                    tmpBolehFree = TMPRecordAuthorize.Item("USERCATISFREEGIVENONCHECKIN").ToString
                End While

                With UserPermition
                    If tmpBolehFree = "1" Then
                        Authorize = True
                    Else
                        ShowMessage(Me, "Maaf, anda tidak mempunyai akses untuk manambah atau mengurangi free room !")
                        UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
                        Call MainPage.StatusBarInitialize()

                        FormStatus = FormStatusLib.OpenAndLock
                        Call OBJControlHandler(Me, FormStatus)

                        Exit Sub
                    End If
                End With
            End If
        End If
        If sender.tag = "1" Then
            txtJam.Text = CStr(CInt(txtJam.Text) + CInt(PrefInfo.POSPREFMINUTEVAL))
        ElseIf sender.tag = "2" Then
            txtTambahan.Text = CStr(CInt(txtTambahan.Text) + CInt(PrefInfo.POSPREFMINUTEVAL))
        ElseIf sender.tag = "4" Then
            txtFreeHour.Text = CStr(CInt(txtFreeHour.Text) + CInt(PrefInfo.POSPREFMINUTEVAL))
        End If
        If sender.tag = "3" Or sender.tag = "4" Then
            If Authorize = True Then
                Authorize = False
                UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
                Call MainPage.StatusBarInitialize()
            End If
        End If
    End Sub

    Private Sub cmdDownRent_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDownRent.Click, cmdDownTambahan.Click, cmdDownHour.Click
        Dim arrPermission() As String
        If tmpBolehFree = "1" Then
            arrPermission = Split("true", "false")
        Else
            arrPermission = Split(isAllowToAccess(UserInformation.UserTypeUID), ",")
        End If
        If sender.tag = "3" Or sender.tag = "4" Then
            If arrPermission(0) = "false" Then
                Dim OBJNew As New Form_User_Authorize_Dialog
                OBJNew.Name = "Form_User_Authorize_Dialog"
                OBJNew.ParentOBJForm = Me
                OBJNew.NeedAuthorizationForMakeBill = True
                OBJNew.ShowDialog()

                If Authorize = False Then Exit Sub

                Dim TMPRecordAuthorize As FbDataReader
                TMPRecordAuthorize = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2202'")
                While TMPRecordAuthorize.Read()
                    Application.DoEvents()
                    UserPermition.PermitionInitialize(TMPRecordAuthorize.Item("USERCATCREATEACCESS"), TMPRecordAuthorize.Item("USERCATEDITACCESS"), TMPRecordAuthorize.Item("USERCATDELETEACCESS"), TMPRecordAuthorize.Item("USERCATREADACCESS"), TMPRecordAuthorize.Item("USERCATPRINTACCESS"), TMPRecordAuthorize.Item("USERCATCHANGEDATEACCESS"), TMPRecordAuthorize.Item("USERCATCHANGETIMEACCESS"), TMPRecordAuthorize.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
                End While

                With UserPermition
                    If TMPRecordAuthorize.Item("USERCATMOVETABLEOVERCHECKIN").ToString = "1" Then
                        Authorize = True
                    Else
                        ShowMessage(Me, "Maaf, anda tidak mempunyai akses untuk manambah atau mengurangi free room !")
                        UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
                        Call MainPage.StatusBarInitialize()

                        FormStatus = FormStatusLib.OpenAndLock
                        Call OBJControlHandler(Me, FormStatus)

                        Exit Sub
                    End If
                End With
            End If
        End If
        If sender.tag = "1" Then
            If CInt(txtJam.Text) = 0 Then Exit Sub
            txtJam.Text = CStr(CInt(txtJam.Text) - CInt(PrefInfo.POSPREFMINUTEVAL))
        ElseIf sender.tag = "2" Then
            If CInt(txtTambahan.Text) = 0 Then Exit Sub
            If cmdUpRent.Enabled = False Then
                If CInt(txtTambahanInv.Text) > CInt(txtTambahan.Text) - CInt(PrefInfo.POSPREFMINUTEVAL) Then Exit Sub
            End If
            txtTambahan.Text = CStr(CInt(txtTambahan.Text) - CInt(PrefInfo.POSPREFMINUTEVAL))
        ElseIf sender.tag = "3" Then
            If CInt(txtFree.Text) = 0 Then Exit Sub
            If cmdUpRent.Enabled = False Then
                If CInt(txtFreeInv.Text) > CInt(txtFree.Text) - 1 Then Exit Sub
            End If
            txtFree.Text = CStr(CInt(txtFree.Text) - 1)
        ElseIf sender.tag = "4" Then
            If CInt(txtFreeHour.Text) = 0 Then Exit Sub
            If cmdUpRent.Enabled = False Then
                If CInt(txtFreeHourInv.Text) > CInt(txtFreeHour.Text) - CInt(PrefInfo.POSPREFMINUTEVAL) Then txtFreeHour.Text = txtFreeHourInv.Text : Exit Sub
            End If
            txtFreeHour.Text = CStr(CInt(txtFreeHour.Text) - CInt(PrefInfo.POSPREFMINUTEVAL))
        End If
        If sender.tag = "3" Or sender.tag = "4" Then
            If Authorize = True Then
                Authorize = False
                UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
                Call MainPage.StatusBarInitialize()
            End If
        End If
    End Sub

    Private Sub txtFreeHour_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles txtFreeHour.KeyPress
        e.Handled = True
        Dim arrPermission() As String = Split(isAllowToAccess(UserInformation.UserTypeUID), ",")
        If sender.tag = "3" Or sender.tag = "4" Then
            If arrPermission(0) = "false" Then

                Dim OBJNew As New Form_User_Authorize_Dialog
                OBJNew.Name = "Form_User_Authorize_Dialog"
                OBJNew.ParentOBJForm = Me
                OBJNew.NeedAuthorizationForMakeBill = True
                OBJNew.ShowDialog()

                If Authorize = False Then Exit Sub

                Dim arrPermission2() As String = Split(isAllowToAccess(UserInformation.UserTypeUID), ",")

                With UserPermition
                    If arrPermission2(0) = "false" Then
                        ShowMessage(Me, "Maaf, anda tidak mempunyai akses untuk manambah atau mengurangi free room !")
                        UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
                        Call MainPage.StatusBarInitialize()

                        FormStatus = FormStatusLib.OpenAndLock
                        Call OBJControlHandler(Me, FormStatus)

                        Exit Sub
                    Else
                        Authorize = True
                    End If
                End With
            End If
        End If
        e.Handled = False
        If (Microsoft.VisualBasic.Asc(e.KeyChar) < 48) Or (Microsoft.VisualBasic.Asc(e.KeyChar) > 57) Then
            e.Handled = True
        End If
        If (Microsoft.VisualBasic.Asc(e.KeyChar) = 8) Then
            e.Handled = False
        End If
        txtFreeHour.SelectionStart = Len(txtFreeHour.Text)
    End Sub

    Private Sub txtFreeHour_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtFreeHour.LostFocus
        If Authorize = True Then
            Authorize = False
            UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
            Call MainPage.StatusBarInitialize()
        End If
    End Sub

    Private Sub txtFreeHour_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFreeHour.TextChanged
        If IsNumeric(txtFreeHour.Text) = True And IsNumeric(txtFreeHourInv.Text) = True Then
            If CInt(txtFreeHourInv.Text) > CInt(txtFreeHour.Text) Then
                ShowMessage(Me, "Maaf, anda tidak dapat memasukkan jumlah jam kurang dari jumlah jam awal !", True)
                txtFreeHour.Text = txtFreeHourInv.Text
                txtFreeHour.Focus()
            End If
        End If
        If IsNumeric(txtFreeHour.Text) = False Or Trim(txtFreeHour.Text) = "" Then txtFreeHour.Text = 0
        Call fillTotalHour()
    End Sub

    Private Sub cmdFreeMnt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdFreeMnt.Click
        'Dim arrPermission() As String = Split(isAllowToAccess(UserInformation.UserTypeUID), ",")
        'If arrPermission(0) = "false" Then
        '    Dim OBJNew As New Form_User_Authorize_Dialog
        '    OBJNew.Name = "Form_User_Authorize_Dialog"
        '    OBJNew.ParentOBJForm = Me
        '    OBJNew.NeedAuthorizationForMakeBill = True
        '    OBJNew.ShowDialog()

        '    If Authorize = False Then Exit Sub

        '    Dim TMPRecordAuthorize As FbDataReader
        '    TMPRecordAuthorize = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2202'")
        '    While TMPRecordAuthorize.Read()
        '        UserPermition.PermitionInitialize(TMPRecordAuthorize.Item("USERCATCREATEACCESS"), TMPRecordAuthorize.Item("USERCATEDITACCESS"), TMPRecordAuthorize.Item("USERCATDELETEACCESS"), TMPRecordAuthorize.Item("USERCATREADACCESS"), TMPRecordAuthorize.Item("USERCATPRINTACCESS"), TMPRecordAuthorize.Item("USERCATCHANGEDATEACCESS"), TMPRecordAuthorize.Item("USERCATCHANGETIMEACCESS"), TMPRecordAuthorize.Item("USERCATMODIFIEDORDERAFTERDUMPED"), IIf(IsDBNull(TMPRecordAuthorize.Item("USERCATISFREEGIVENONCHECKIN")) = True, False, TMPRecordAuthorize.Item("USERCATISFREEGIVENONCHECKIN")), IIf(IsDBNull(TMPRecordAuthorize.Item("USERCATMOVETABLEOVERCHECKIN")) = True, False, TMPRecordAuthorize.Item("USERCATMOVETABLEOVERCHECKIN")))
        '    End While

        '    With UserPermition
        '        If .AllowFreeTime Then
        '            Authorize = True
        '        Else
        '            ShowMessage(Me, "Maaf, anda tidak mempunyai akses untuk manambah atau mengurangi free room !")
        '            UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
        '            Call MainPage.StatusBarInitialize()

        '            FormStatus = FormStatusLib.OpenAndLock
        '            Call OBJControlHandler(Me, FormStatus)

        '            Exit Sub
        '        End If
        '    End With
        'End If
        'Me.Cursor = Cursors.WaitCursor
        'Dim VirtuCalculator As New Form_Virtual_Calculator
        'VirtuCalculator.OBJBind(txtFree)
        'VirtuCalculator.ShowDialog()
        'Me.Cursor = Cursors.Default        
        'If Authorize = True Then
        '    Authorize = False
        '    UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
        '    Call MainPage.StatusBarInitialize()
        'End If
        Dim arrPermission() As String
        If tmpBolehFree = "1" Then
            arrPermission = Split("true", "false")
        Else
            arrPermission = Split(isAllowToAccess(UserInformation.UserTypeUID), ",")
        End If

        If sender.tag = "3" Or sender.tag = "4" Then
            If arrPermission(0) = "false" Then
                Dim OBJNew As New Form_User_Authorize_Dialog
                OBJNew.Name = "Form_User_Authorize_Dialog"
                OBJNew.ParentOBJForm = Me
                OBJNew.NeedAuthorizationForMakeBill = True
                OBJNew.ShowDialog()

                If Authorize = False Then Exit Sub

                Dim TMPRecordAuthorize As FbDataReader
                TMPRecordAuthorize = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & UserInformation.UserTypeUID & "' AND USERCATMODULETYPEID = '2202'")
                While TMPRecordAuthorize.Read()
                    UserPermition.PermitionInitialize(TMPRecordAuthorize.Item("USERCATCREATEACCESS"), TMPRecordAuthorize.Item("USERCATEDITACCESS"), TMPRecordAuthorize.Item("USERCATDELETEACCESS"), TMPRecordAuthorize.Item("USERCATREADACCESS"), TMPRecordAuthorize.Item("USERCATPRINTACCESS"), TMPRecordAuthorize.Item("USERCATCHANGEDATEACCESS"), TMPRecordAuthorize.Item("USERCATCHANGETIMEACCESS"), TMPRecordAuthorize.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
                    tmpBolehFree = TMPRecordAuthorize.Item("USERCATISFREEGIVENONCHECKIN").ToString
                End While

                With UserPermition
                    If tmpBolehFree = "1" Then
                        Authorize = True
                    Else
                        ShowMessage(Me, "Maaf, anda tidak mempunyai akses untuk manambah atau mengurangi free room !")
                        UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
                        Call MainPage.StatusBarInitialize()

                        FormStatus = FormStatusLib.OpenAndLock
                        Call OBJControlHandler(Me, FormStatus)

                        Exit Sub
                    End If
                End With
            End If
        End If
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        VirtuCalculator.OBJBind(txtFreeHour)
        VirtuCalculator.ShowDialog()
        Me.Cursor = Cursors.Default
        If CInt(txtFreeHourInv.Text) > CInt(txtFreeHour.Text) Then
            ShowMessage(Me, "Maaf, nilai yang Anda masukkan tidak boleh lebih kecil dari nilai lama !")
            txtFreeHour.Text = txtFreeHourInv.Text
        End If
        If Authorize = True Then
            Authorize = False
            UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
            Call MainPage.StatusBarInitialize()
        End If
        If sender.tag = "3" Or sender.tag = "4" Then
            If Authorize = True Then
                Authorize = False
                UserInformation.UserInitialize(UUID, UName, UOrderPoint, UTypeUID)
                Call MainPage.StatusBarInitialize()
            End If
        End If
    End Sub

    Private Sub BTNPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPrint.Click
        MyDatabase.MyAdapter("UPDATE MBTRANS SET PRINTCOUNTER=PRINTCOUNTER+1 WHERE MBTRANSUID='" & CurrentUID & "'")
        Call ShowPrintPreview(True)
    End Sub

    Private Sub txtBonusMinutes_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtBonusMinutes.TextChanged
        Call fillTotalHour()
    End Sub

    Private Sub txtFree_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtFree.TextChanged
        If IsNumeric(txtFree.Text) = True And IsNumeric(txtFreeInv.Text) = True Then
            If CInt(txtFreeInv.Text) > CInt(txtFree.Text) Then
                ShowMessage(Me, "Maaf, anda tidak dapat memasukkan jumlah jam kurang dari jumlah jam awal !", True)
                txtFree.Text = txtFreeInv.Text
                txtFree.Focus()
            End If
        End If
        If IsNumeric(txtFree.Text) = False Or Trim(txtFree.Text) = "" Then txtFree.Text = 0
        Call fillTotalHour()
    End Sub

    Private Sub txtBarcode_GotFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.GotFocus
        txtBarcode.Text = ""
    End Sub

    Private Sub txtBarcode_KeyDown(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles txtBarcode.KeyDown
        If e.KeyCode <> Keys.Return Then Exit Sub
        If (totalRow("SALESPROMOREG WHERE SALESPROMOREGPROMOGENERATEDNO='" & ReplacePetik(txtBarcode.Text) & "' AND SALESPROMOREGUSAGETRANSUID IS NOT NULL") > 0 Or totalRow("SALESPROMOREG WHERE SALESPROMOREGPROMOGENERATEDNO='" & ReplacePetik(txtBarcode.Text) & "' AND SALESPROMOREGPROMOEXPIREDDATE>'" & Format(Now.Date, "yyyy/MM/dd") & "' AND SALESPROMOREGPROMOEXPIREDDATE IS NOT NULL") > 0 Or totalRow("SALESPROMOREG WHERE SALESPROMOREGPROMOGENERATEDNO='" & ReplacePetik(txtBarcode.Text) & "'") = 0) And Trim(txtBarcode.Text) <> "" Then
            ShowMessage(Me, "Maaf, Data gift Anda tidak ditemukan atau gift sudah terpakai !")
            Exit Sub
        End If
        Dim tmpIDMBTrans As String = txtBarcode.Text
        If ShowQuestion(Me, "Apakah Anda serius melakukan transaksi penukaran Gift ?", True) = vbNo Then txtBarcode.Focus() : Exit Sub
        MyDatabase.MyAdapter("UPDATE SALESPROMOREG SET SALESPROMOREGUSAGETRANSUID='" & CurrentUID & "' WHERE SALESPROMOREGPROMOGENERATEDNO='" & ReplacePetik(tmpIDMBTrans) & "'")
        txtBarcode.Focus()
    End Sub

    Private Sub txtBarcode_LostFocus(ByVal sender As Object, ByVal e As System.EventArgs) Handles txtBarcode.LostFocus
        If Trim(txtBarcode.Text) = "" Then txtBarcode.Text = "Type Barcode Here"
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