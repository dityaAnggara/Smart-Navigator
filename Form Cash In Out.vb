Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win

Imports NPOI.HSSF.UserModel
Imports NPOI.HPSF
Imports NPOI.POIFS.FileSystem
Imports System.IO

Public Class Form_Cash_In_Out

    Public Shared pubIdTrans As String = Nothing
    Dim Hour As String
    Dim Minute As String
    Dim Second As String
    Dim strConn2 As String = Nothing

#Region "Pajak"

    Private Sub unPost(ByVal idRsv As String, ByVal idMB As String, ByVal idPay As String)
        Dim tmpNumTransFounded As String = Nothing

        'PBTRANS
        'tmpNumTransFounded = getNotaNumber2("SELECT PBTRANSNO FROM PBTRANS WHERE PBTRANSUID='" & .Item(rowSel, "idpb") & "'")
        'SET UNPOST PBTRANS
        MyDatabase.MyAdapter("UPDATE PBTRANS SET ISFISCAL='0' WHERE PBTRANSUID='" & idPay & "'")
        'If tmpNumTransFounded <> Nothing Then
        MyDatabase.MyAdapter2(strConn2, "DELETE FROM PBTRANS WHERE PBTRANSUID='" & idPay & "'")
        'End If

        'MBTRANS
        'tmpNumTransFounded = getNotaNumber2("SELECT MBTRANSNO FROM MBTRANS WHERE MBTRANSUID='" & .Item(rowSel, "idmb") & "'")
        'SET UNPOST MBTRANS
        MyDatabase.MyAdapter("UPDATE MBTRANS SET ISFISCAL='0' WHERE MBTRANSUID='" & idMB & "'")
        'If tmpNumTransFounded <> Nothing Then
        MyDatabase.MyAdapter2(strConn2, "DELETE FROM MBTRANS WHERE MBTRANSUID='" & idMB & "'")
        'End If

        If idRsv <> Nothing Then
            'SET UNPOST RSVTRANS
            MyDatabase.MyAdapter("UPDATE RSVTRANS SET ISFISCAL='0' WHERE RSVTRANSUID='" & idRsv & "'")
            'tmpNumTransFounded = getNotaNumber2("SELECT RSVTRANSNO FROM RSVTRANS WHERERSVTRANSUID='" & .Item(rowSel, "idrsv") & "'")
            'If tmpNumTransFounded <> Nothing Then
            MyDatabase.MyAdapter2(strConn2, "DELETE FROM RSVTRANS WHERE RSVTRANSUID='" & idRsv & "'")
            'End If
        End If
    End Sub

    Private Function getFieldList(ByVal TableName As String) As String
        Dim tmpList As String = Nothing
        Dim rs As FbDataReader
        rs = MyDatabase.MyReader("SELECT f.rdb$field_name AS NamaField FROM rdb$relation_fields f JOIN rdb$relations r ON f.rdb$relation_name = r.rdb$relation_name AND r.rdb$view_blr is null AND (r.rdb$system_flag is null or r.rdb$system_flag = 0) WHERE f.rdb$relation_name='" & TableName & "'")
        While rs.Read()
            tmpList = tmpList & Trim(IIf(IsDBNull(rs(0)) = True, "NULL", rs(0))) & ","
        End While
        rs = Nothing
        If Trim(tmpList) <> "" Then
            tmpList = Strings.Left(tmpList, Len(tmpList) - 1)
        End If
        Return tmpList
    End Function

    Private Function AutoIDNumber3(ByVal Database2 As String, ByVal ModuleTypeID As String, ByVal TableCheck As String, ByVal FieldCheck As String, Optional ByVal FixedFormat As Boolean = False, Optional ByVal Filter As String = Nothing, Optional ByVal partCode As String = Nothing) As String
        Dim Generate As String, Query As String = Nothing, TMPRecord As FbDataReader
        Dim JCODE As String = Nothing, TMPCheck As FbDataReader

        Query = "SELECT MODULETYPEJURNALCODE FROM MODULETYPE WHERE MODULETYPEID='" & ModuleTypeID & "'"
        TMPCheck = MyDatabase.MyReader2(Database2, Query)
        TMPCheck.Read()
        JCODE = TMPCheck.Item("MODULETYPEJURNALCODE")

        If FixedFormat Then
            Generate = Nothing
        Else
            If partCode <> Nothing Then
                Generate = partCode
            Else
                Generate = Format(Now.Month, "00") & Mid(Now.Year, 3)
            End If
        End If

        If IsNothing(Filter) Then
            Query = "SELECT MAX(" & ReplacePetik(FieldCheck) & ")AS LASTNO FROM " & ReplacePetik(TableCheck) & " WHERE " & FieldCheck & " like '" & JCODE & "-" & Generate & "%'"
        Else
            Query = "SELECT MAX(" & ReplacePetik(FieldCheck) & ")AS LASTNO FROM " & ReplacePetik(TableCheck) & " WHERE " & FieldCheck & " like '" & JCODE & Generate & "%' " & Filter
        End If

        TMPRecord = MyDatabase.MyReader2(Database2, Query)
        TMPRecord.Read()

        If IsDBNull(TMPRecord.Item("LASTNO")) Then
            If Generate = Nothing Then
                Return JCODE & "-" & "00001"
            Else
                Return JCODE & "-" & Generate & "-" & "00001"
            End If
        Else
            If Generate = Nothing Then
                Dim Result As String, Fixed As Long
                Result = TMPRecord.Item("LASTNO")
                Fixed = Mid(Result, Len(JCODE) + Len(Generate) + 3) + 1
                Return JCODE & "-" & Format(Fixed, "00000")
            Else
                Dim Result As String, Fixed As Long
                Result = TMPRecord.Item("LASTNO")
                Fixed = Mid(Result, Len(JCODE) + Len(Generate) + 3) + 1
                Return JCODE & "-" & Generate & "-" & Format(Fixed, "00000")
            End If
        End If

        TMPRecord = Nothing
        TMPCheck = Nothing
    End Function

    Private Function getValueToInsert(ByVal strSQL As String, Optional ByVal TransCode As String = "", Optional ByVal colNum As Integer = -1, Optional ByVal partCode As String = Nothing) As String
        Dim tmpList As String = Nothing
        Try
            Dim tmpCode As String = ""
            Dim rs As FbDataReader
            rs = MyDatabase.MyReader(strSQL)

            If rs.Read = False Then
                Return Nothing
            Else
                If Trim(TransCode) <> "" Then
                    Dim tmpData As String = Nothing
                    Dim col1 As Integer = 0, col2 As Integer = 0
                    If TransCode = "MB" Then
                        col1 = InStr(rs("MBTRANSNO"), "-")
                        tmpData = Mid(rs("MBTRANSNO"), col1 + 1, 4)
                        tmpCode = AutoIDNumber3(strConn2, "2202", "MBTRANS", "MBTRANSNO", , , tmpData)
                    ElseIf TransCode = "RSV" Then
                        col1 = InStr(rs("RSVTRANSNO"), "-")
                        tmpData = Mid(rs("RSVTRANSNO"), col1 + 1, 4)
                        tmpCode = AutoIDNumber3(strConn2, "2201", "RSVTRANS", "RSVTRANSNO", , , tmpData)
                    ElseIf TransCode = "PAY" Then
                        col1 = InStr(rs("PBTRANSNO"), "-")
                        tmpData = Mid(rs("PBTRANSNO"), col1 + 1, 4)
                        tmpCode = AutoIDNumber3(strConn2, "2206", "PBTRANS", "PBTRANSNO", , , tmpData)
                    End If
                End If
                For i As Integer = 0 To 1000
                    If colNum = i Then
                        tmpList = tmpList & "'" & tmpCode & "',"
                    Else
                        If IsDate(rs(i)) = True Then
                            If TransCode = "RSV" Then
                                If i = 7 Then
                                    tmpList = tmpList & "'" & Format(rs(i), "yyyy/MM/dd") & "',"
                                ElseIf i = 8 Then
                                    tmpList = tmpList & "'" & Format(rs(i), "HH:mm:ss") & "',"
                                Else
                                    tmpList = tmpList & "'" & Format(rs(i), "yyyy/MM/dd HH:mm:ss") & "',"
                                End If
                            Else
                                tmpList = tmpList & "'" & Format(rs(i), "yyyy/MM/dd HH:mm:ss") & "',"
                            End If
                        ElseIf IsDBNull(rs(i)) = True Then
                            tmpList = tmpList & "NULL,"
                        ElseIf IsNumeric(rs(i)) = True Then
                            tmpList = tmpList & "'" & Replace(rs(i), ",", "") & "',"
                        Else
                            tmpList = tmpList & "'" & Replace(rs(i), "'", "''") & "',"
                        End If
                    End If
                Next
            End If
            rs = Nothing
            Return tmpList
        Catch ex As Exception
            If Trim(tmpList) <> "" Then
                tmpList = Strings.Left(tmpList, Len(tmpList) - 1)
            End If
            Return tmpList
        End Try
    End Function

    Private Sub fillData(ByVal idRsv As String, ByVal idMB As String, ByVal idPay As String)
        Dim tmpFieldList As String = Nothing, tmpValField As String = Nothing
        Dim tmpFieldList2 As String = Nothing, tmpValField2 As String = Nothing
        Dim INVENADDEDFIELD_ok As Boolean = False
        Dim INVENLINKEDACC_ok As Boolean = False

        Dim rs As FbDataReader
        Dim rs2 As FbDataReader

        'RSVTRANS
        If idRsv <> Nothing Then
            If jmlRowDB2("SELECT COUNT(*) FROM RSVTRANS WHERE RSVTRANSUID='" & idRsv & "'") = 0 Then
                tmpFieldList = getFieldList("RSVTRANS")
                tmpValField = getValueToInsert("SELECT * FROM RSVTRANS WHERE RSVTRANSUID='" & idRsv & "'", "RSV", 1)
                MyDatabase.MyAdapter2(strConn2, "INSERT INTO RSVTRANS (" & tmpFieldList & ") VALUES (" & tmpValField & ")")

                'SET TO FISCAL
                MyDatabase.MyAdapter("UPDATE RSVTRANS SET ISFISCAL='1' WHERE RSVTRANSUID='" & idRsv & "'")

                'RSVTRANSDT
                tmpFieldList = getFieldList("RSVTRANSDT")
                rs = MyDatabase.MyReader("SELECT * FROM RSVTRANSDT WHERE RSVTRANSUID='" & idRsv & "'")
                While rs.Read()
                    tmpValField = getValueToInsert("SELECT * FROM RSVTRANSDT WHERE RSVTRANSDTUID='" & rs(0) & "'")
                    MyDatabase.MyAdapter2(strConn2, "INSERT INTO RSVTRANSDT (" & tmpFieldList & ") VALUES (" & tmpValField & ")")

                    'RSVTRANSDTDETAIL
                    rs2 = MyDatabase.MyReader("SELECT * FROM RSVTRANSDTDETAIL WHERE RSVTRANSDTUID='" & rs("RSVTRANSDTUID") & "'")
                    While rs2.Read() = True
                        tmpValField2 = getValueToInsert("SELECT * FROM RSVTRANSDTDETAIL WHERE RSVTRANSDTDETAILUID='" & rs2("RSVTRANSDTDETAILUID") & "'")
                        MyDatabase.MyAdapter2(strConn2, "INSERT INTO RSVTRANSDTDETAIL (" & tmpFieldList2 & ") VALUES (" & tmpValField2 & ")")
                    End While
                    rs2 = Nothing

                End While
                rs = Nothing

                'RSVTRANSTABLELIST
                tmpFieldList = getFieldList("RSVTRANSTABLELIST")
                rs = MyDatabase.MyReader("SELECT * FROM RSVTRANSTABLELIST WHERE RSVTRANSUID='" & idRsv & "'")
                While rs.Read() = True
                    tmpValField = getValueToInsert("SELECT * FROM RSVTRANSTABLELIST WHERE RSVTRANSDTTABLELISTUID='" & rs("RSVTRANSDTTABLELISTUID") & "'")
                    MyDatabase.MyAdapter2(strConn2, "INSERT INTO RSVTRANSTABLELIST (" & tmpFieldList & ") VALUES (" & tmpValField & ")")
                End While
                rs = Nothing
                'MyDatabase.MyAdapter2(strConn2, "UPDATE SALESTRANSREG SET SALESTRANSREGTRANSSTAT=1 WHERE SALESTRANSREGTRANSUID='" & idRsv & "'")

            End If
        End If

        'MBTRANS
        If jmlRowDB2("SELECT COUNT(*) FROM MBTRANS WHERE MBTRANSUID='" & idMB & "'") = 0 Then
            tmpFieldList = getFieldList("MBTRANS")
            tmpValField = getValueToInsert("SELECT * FROM MBTRANS WHERE MBTRANSUID='" & idMB & "'", "MB", 1)
            MyDatabase.MyAdapter2(strConn2, "INSERT INTO MBTRANS (" & tmpFieldList & ") VALUES (" & tmpValField & ")")

            'SET TO FISCAL
            MyDatabase.MyAdapter("UPDATE MBTRANS SET ISFISCAL='1' WHERE MBTRANSUID='" & idMB & "'")

            'MBTRANSDT  
            tmpFieldList = getFieldList("MBTRANSDT")
            tmpFieldList2 = getFieldList("MBTRANSDTDETAIL")
            rs = MyDatabase.MyReader("SELECT * FROM MBTRANSDT WHERE MBTRANSUID='" & idMB & "'")
            While rs.Read()
                tmpValField = getValueToInsert("SELECT * FROM MBTRANSDT WHERE MBTRANSDTUID='" & rs(0) & "'")
                MyDatabase.MyAdapter2(strConn2, "INSERT INTO MBTRANSDT (" & tmpFieldList & ") VALUES (" & tmpValField & ")")

                'MBTRANSDTDETAIL
                rs2 = MyDatabase.MyReader("SELECT * FROM MBTRANSDTDETAIL WHERE MBTRANSDTUID='" & rs("MBTRANSDTUID") & "'")
                While rs2.Read = True
                    tmpValField2 = getValueToInsert("SELECT * FROM MBTRANSDTDETAIL WHERE MBTRANSDTDETAILUID='" & rs2("MBTRANSDTDETAILUID") & "'")
                    MyDatabase.MyAdapter2(strConn2, "INSERT INTO MBTRANSDTDETAIL (" & tmpFieldList2 & ") VALUES (" & tmpValField2 & ")")
                End While
                rs2 = Nothing
            End While
            rs = Nothing

            'MBTRANSTABLELIST
            tmpFieldList = getFieldList("MBTRANSTABLELIST")
            rs = MyDatabase.MyReader("SELECT * FROM MBTRANSTABLELIST WHERE MBTRANSUID='" & idMB & "'")
            While rs.Read() = True
                tmpValField = getValueToInsert("SELECT * FROM MBTRANSTABLELIST WHERE MBTRANSDTTABLELISTUID='" & rs("MBTRANSDTTABLELISTUID") & "'")
                MyDatabase.MyAdapter2(strConn2, "INSERT INTO MBTRANSTABLELIST (" & tmpFieldList & ") VALUES (" & tmpValField & ")")
            End While
            rs = Nothing
            'MyDatabase.MyAdapter2(strConn2, "UPDATE SALESTRANSREG SET SALESTRANSREGTRANSSTAT=1 WHERE SALESTRANSREGTRANSUID='" & idMB & "'")
        End If

        'PAYMENT
        If jmlRowDB2("SELECT COUNT(*) FROM PBTRANS WHERE PBTRANSUID='" & idPay & "'") = 0 Then
            tmpFieldList = getFieldList("PBTRANS")
            tmpValField = getValueToInsert("SELECT * FROM PBTRANS WHERE PBTRANSUID='" & idPay & "'", "PAY", 1)
            MyDatabase.MyAdapter2(strConn2, "INSERT INTO PBTRANS (" & tmpFieldList & ") VALUES (" & tmpValField & ")")

            'SET TO FISCAL
            MyDatabase.MyAdapter("UPDATE PBTRANS SET ISFISCAL='1' WHERE PBTRANSUID='" & idPay & "'")

            tmpFieldList = getFieldList("PBTRANSDT")
            rs = MyDatabase.MyReader("SELECT * FROM PBTRANSDT WHERE PBTRANSUID='" & idPay & "'")
            While rs.Read() = True
                tmpValField = getValueToInsert("SELECT * FROM PBTRANSDT WHERE PBTRANSDTUID='" & rs("PBTRANSDTUID") & "'")
                MyDatabase.MyAdapter2(strConn2, "INSERT INTO PBTRANSDT (" & tmpFieldList & ") VALUES (" & tmpValField & ")")
            End While
            rs = Nothing
            'MyDatabase.MyAdapter2(strConn2, "UPDATE SALESTRANSREG SET SALESTRANSREGTRANSSTAT=1 WHERE SALESTRANSREGTRANSUID='" & idPay & "'")
        End If
        rs = Nothing
    End Sub

    Private Function isTableExist(ByVal tableName As String) As Boolean
        Try
            Dim rs As FbDataReader
            rs = MyDatabase.MyReader2(strConn2, "SELECT COUNT(*) FROM " & tableName & "")
            'do nothing
            rs = Nothing
            rs = MyDatabase.MyReader("SELECT COUNT(*) FROM " & tableName & "")
            'do nothing
            rs = Nothing
            Return True
        Catch ex As Exception
            Return False
        End Try
    End Function

    Private Function jmlRowDB2(ByVal strSQL As String) As Integer
        Dim rs As FbDataReader
        rs = MyDatabase.MyReader2(strConn2, strSQL)
        rs.Read()
        Return rs(0)
        rs = Nothing
    End Function


#End Region


#Region "Variable Reference"
    Dim myDetailStringArray As String
    Dim paymentFormStatus As FormStatusLib
    Dim SaveStatus As Boolean = False
    Dim TransactionUID As String = GetTransactionCode(SelectedTable.TableUID)
    Public MBTransUID As String = Nothing
    Dim tvPBTransUID As String
    Dim tvMBTransUID As String
    Dim tvCustUID As String
    Dim tvTableUID As String

    Dim oldPaymentVal As Decimal = 0

    'Ardian - Down Payment Reservasi
    Public ParentOBJForm As Object
    Public IsReservation As Boolean
    Public IsNewReservation As Boolean
    Public IsNewEditReservation As Boolean
    Public DPTransUID As String = Nothing
    Dim CurrDate As Date
    Public Paid As Decimal = 0
    Dim ExitIsRefundable As Boolean = False
    Dim foundDefaultPayment As Boolean = False

    Structure ReservasiLib
        Dim GrandTotal As String
        Dim NewReservationUID As String
        Dim ReservationUID As String
        Dim ReservationNumber As String
        Dim CustUID As String
        Dim CustName As String
        Dim CustList As String
        Dim TableList As String
        Dim TableUID As String
        Dim DP As String
    End Structure
    Public ReservasiInfo As ReservasiLib

    Dim UserPermition As New UserPermitionLib
    Dim ListCollection As New Collection
    Dim FormStatus As FormStatusLib

    Dim t As Integer = 0
    Dim FileDatabase2 As String = Nothing
    Dim Shift As String = GetShift()

#End Region

#Region "Initialize & Object Function"

    Private Sub BasicInitialize()
        Hour = Now.Hour
        Minute = Now.Minute
        Second = Now.Second
        CurrDate = Now.Date
        ReservationTime.Value = Now
        DateLabel.Text = Format(PaymentDate.Value, "dddd , dd MMMM yyyy")
        TimeLabel.Text = Format(ReservationTime.Value, "HH:mm:ss")
        Dim PC As String = GetPayPrintCounter(TransactionUID)
        PrintCounter.Text = CDec(PC) + 1

        Call PaymentTypeInitialize()
        PaymentNo.Text = AutoIDNumber(IIf(Me.Text = "Cash In", "2501", "2502"), "PBTRANS", "PBTRANSNO")
        cmdList.Text = Me.Text & " List"
        Call CheckPermission(UserInformation.UserTypeUID, True)
        'If foundDefaultPayment Then
        '    DBInitialize()
        'Else
        '    ShowMessage(Me, "Silakan tentukan default pembayaran pada data master 'Payment Type' !")
        '    Me.Close()
        'End If

    End Sub

    Private Function GetPayPrintCounter(ByVal PAYUID As String) As String
        Dim ItemRecord As FbDataReader
        ItemRecord = MyDatabase.MyReader("SELECT * FROM PBTRANS WHERE PBTRANSMBTRANSUID = '" & PAYUID & "'")

        While ItemRecord.Read
            If CDec(ItemRecord.Item("PRINTCOUNTER")) > 0 Then
                Return ItemRecord.Item("PRINTCOUNTER")
            Else
                Return "0"
            End If
        End While

        Return "0"
    End Function

    Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)
        Dim TMPRecord As FbDataReader
        If Me.Text = "Cash In" Then
            TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2501'")
        Else
            TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2502'")
        End If

        While TMPRecord.Read()
            UserPermition.PermitionInitialize(TMPRecord.Item("USERCATCREATEACCESS"), TMPRecord.Item("USERCATEDITACCESS"), TMPRecord.Item("USERCATDELETEACCESS"), TMPRecord.Item("USERCATREADACCESS"), TMPRecord.Item("USERCATPRINTACCESS"), TMPRecord.Item("USERCATCHANGEDATEACCESS"), TMPRecord.Item("USERCATCHANGETIMEACCESS"), TMPRecord.Item("USERCATMODIFIEDORDERAFTERDUMPED"))
        End While

        With UserPermition
            If Not .ReadAccess Then
                ShowMessage(Me, "Maaf, anda tidak mempunyai akses terhadap form ini !" & vbNewLine & "Silakan hubungi administrator anda.")
                Me.Close()
            End If

            If .CreateAccess = False Then
                BTNSave.Enabled = False
                BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Silver
            Else
                BTNSave.Enabled = True
                BTNSave.VisualStyle = C1Input.VisualStyle.Office2007Blue
            End If

            If .ChangeDateAccess = False Then
                VirtualDate.Enabled = False
                VirtualDate.VisualStyle = C1Input.VisualStyle.Office2007Silver
            Else
                VirtualDate.Enabled = True
                VirtualDate.VisualStyle = C1Input.VisualStyle.Office2007Blue
            End If

            If .ChangeTimeAccess = False Then
                VirtualTime.Enabled = False
                VirtualTime.VisualStyle = C1Input.VisualStyle.Office2007Silver
            Else
                VirtualTime.Enabled = True
                VirtualTime.VisualStyle = C1Input.VisualStyle.Office2007Blue
            End If


            FormStatus = FormStatusLib.OpenAndLock
            Call OBJControlHandler(Me, FormStatus)
        End With

    End Sub

    Private Sub fillForm()
        Dim rs As FbDataReader
        Dim strSQL As String = "SELECT PBTRANSDT.*,PBTRANSDESC,PBTRANSNO FROM PBTRANS INNER JOIN PBTRANSDT ON PBTRANS.PBTRANSUID=PBTRANSDT.PBTRANSUID WHERE PBTRANS.PBTRANSUID='" & pubIdTrans & "'"
        rs = MyDatabase.MyReader(strSQL)
        If rs.Read() = False Then Exit Sub
        For i As Integer = 1 To PaymentType1.ListCount - 1
            PaymentType1.SelectedIndex = i
            If UCase(Trim(PaymentType1.Columns(1).Text)).ToString = UCase(Trim(rs("PAYMENTTYPEUID"))).ToString Then Exit For
        Next
        If CDec(rs("PBTRANSDTSUBVAL")) < 0 Then
            Payment1.Text = CDec(rs("PBTRANSDTSUBVAL")) * (-1)
        Else
            Payment1.Text = rs("PBTRANSDTSUBVAL")
        End If
        txtKeterangan.Text = rs("PBTRANSDESC")
        PaymentNo.Text = rs("PBTRANSNO")
        BTNNew.Visible = True : BTNCancel.Visible = False
        rs = Nothing
    End Sub

    Private Sub Focus_PaymentType(ByVal paymentType As String, ByVal paymentTypeName As String)
        Select Case paymentType
            Case "PaymentType1"
                PaymentType1.SelectedIndex = PaymentType1.FindStringExact(paymentTypeName)
            Case "PaymentType2"
                PaymentType2.SelectedIndex = PaymentType2.FindStringExact(paymentTypeName)
            Case "PaymentType3"
                PaymentType3.SelectedIndex = PaymentType3.FindStringExact(paymentTypeName)
            Case "PaymentType4"
                PaymentType4.SelectedIndex = PaymentType4.FindStringExact(paymentTypeName)
            Case "PaymentType5"
                PaymentType5.SelectedIndex = PaymentType5.FindStringExact(paymentTypeName)
        End Select

    End Sub

    Private Sub PaymentTypeInitialize()

        Dim TMPRecord As FbDataReader
        Dim isPaymentRefundable As String
        Try
            TMPRecord = MyDatabase.MyReader("SELECT * FROM PAYMENTTYPE WHERE (PAYMENTTYPEACTV IS NULL OR PAYMENTTYPEACTV = 0 ) AND ISCREDITCARDORCHEQUE='0' ORDER BY PAYMENTTYPENAME")

            PaymentType1.HoldFields() : PaymentType1.AddItem("* None;;;") : PaymentType1.SelectedIndex = 0
            'PaymentType2.HoldFields() : PaymentType2.AddItem("* None;;;") : PaymentType2.SelectedIndex = 0
            'PaymentType3.HoldFields() : PaymentType3.AddItem("* None;;;") : PaymentType3.SelectedIndex = 0
            'PaymentType4.HoldFields() : PaymentType4.AddItem("* None;;;") : PaymentType4.SelectedIndex = 0
            'PaymentType5.HoldFields() : PaymentType5.AddItem("* None;;;") : PaymentType5.SelectedIndex = 0

            While TMPRecord.Read()

                If IsDBNull(TMPRecord.Item("PAYMENTTYPEISREFUNDABLE")) = True Then
                    isPaymentRefundable = "0"
                Else
                    isPaymentRefundable = CStr(TMPRecord.Item("PAYMENTTYPEISREFUNDABLE"))
                End If

                PaymentType1.AddItem(TMPRecord.Item("PAYMENTTYPENAME") & ";" & TMPRecord.Item("PAYMENTTYPEUID") & ";" & TMPRecord.Item("ISCREDITCARDORCHEQUE") & ";" & isPaymentRefundable)
                'PaymentType2.AddItem(TMPRecord.Item("PAYMENTTYPENAME") & ";" & TMPRecord.Item("PAYMENTTYPEUID") & ";" & TMPRecord.Item("ISCREDITCARDORCHEQUE") & ";" & isPaymentRefundable)
                'PaymentType3.AddItem(TMPRecord.Item("PAYMENTTYPENAME") & ";" & TMPRecord.Item("PAYMENTTYPEUID") & ";" & TMPRecord.Item("ISCREDITCARDORCHEQUE") & ";" & isPaymentRefundable)
                'PaymentType4.AddItem(TMPRecord.Item("PAYMENTTYPENAME") & ";" & TMPRecord.Item("PAYMENTTYPEUID") & ";" & TMPRecord.Item("ISCREDITCARDORCHEQUE") & ";" & isPaymentRefundable)
                'PaymentType5.AddItem(TMPRecord.Item("PAYMENTTYPENAME") & ";" & TMPRecord.Item("PAYMENTTYPEUID") & ";" & TMPRecord.Item("ISCREDITCARDORCHEQUE") & ";" & isPaymentRefundable)
                If CInt(TMPRecord.Item("PAYMENTTYPEDEFAULT")) = 1 Then foundDefaultPayment = True
            End While

        Catch ex As Exception

        End Try

        TMPRecord = Nothing
    End Sub

    Private Sub PaymentTypeBehaviour(ByVal paymentType As String)
        Select Case paymentType
            Case "PaymentType1"
                If PaymentType1.SelectedIndex > 0 Then
                    Payment1.Enabled = True
                    VirtualCalculator1.Enabled = True
                    If PaymentType1.Columns(2).Text = "1" Then
                        CardInfo1.Visible = True
                        CardOwner1.Focus()
                    Else
                        CardInfo1.Visible = False
                    End If
                    Payment1.Text = CDec(Payment1.Text) + CDec(RestTxt.Text)
                Else
                    Payment1.Text = "0"
                    CardOwner1.Text = ""
                    CardNumber1.Text = ""
                    BankName1.Text = ""
                    Payment1.Enabled = False
                    VirtualCalculator1.Enabled = False
                    CardInfo1.Visible = False
                End If
            Case "PaymentType2"
                If PaymentType2.SelectedIndex > 0 Then
                    Payment2.Enabled = True
                    VirtualCalculator2.Enabled = True
                    If PaymentType2.Columns(2).Text = "1" Then
                        CardInfo2.Visible = True
                        CardOwner2.Focus()
                    Else
                        CardInfo2.Visible = False
                    End If
                    Payment2.Text = CDec(Payment2.Text) + CDec(RestTxt.Text)
                Else
                    Payment2.Text = "0"
                    CardOwner2.Text = ""
                    CardNumber2.Text = ""
                    BankName2.Text = ""
                    Payment2.Enabled = False
                    VirtualCalculator2.Enabled = False
                    CardInfo2.Visible = False
                End If
            Case "PaymentType3"
                If PaymentType3.SelectedIndex > 0 Then
                    Payment3.Enabled = True
                    VirtualCalculator3.Enabled = True
                    If PaymentType3.Columns(2).Text = "1" Then
                        CardInfo3.Visible = True
                        CardOwner3.Focus()
                    Else
                        CardInfo3.Visible = False
                    End If
                    Payment3.Text = CDec(Payment3.Text) + CDec(RestTxt.Text)
                Else
                    Payment3.Text = "0"
                    CardOwner3.Text = ""
                    CardNumber3.Text = ""
                    BankName3.Text = ""
                    Payment3.Enabled = False
                    VirtualCalculator3.Enabled = False
                    CardInfo3.Visible = False
                End If
            Case "PaymentType4"
                If PaymentType4.SelectedIndex > 0 Then
                    Payment4.Enabled = True
                    VirtualCalculator4.Enabled = True
                    If PaymentType4.Columns(2).Text = "1" Then
                        CardInfo4.Visible = True
                        CardOwner4.Focus()
                    Else
                        CardInfo4.Visible = False
                    End If
                    Payment4.Text = CDec(Payment4.Text) + CDec(RestTxt.Text)
                Else
                    Payment4.Text = "0"
                    CardOwner4.Text = ""
                    CardNumber4.Text = ""
                    BankName4.Text = ""
                    Payment4.Enabled = False
                    VirtualCalculator4.Enabled = False
                    CardInfo4.Visible = False
                End If
            Case "PaymentType5"
                If PaymentType5.SelectedIndex > 0 Then
                    Payment5.Enabled = True
                    VirtualCalculator5.Enabled = True
                    If PaymentType5.Columns(2).Text = "1" Then
                        CardInfo5.Visible = True
                        CardOwner5.Focus()
                    Else
                        CardInfo5.Visible = False
                    End If
                    Payment5.Text = CDec(Payment5.Text) + CDec(RestTxt.Text)
                Else
                    Payment5.Text = "0"
                    CardOwner5.Text = ""
                    CardNumber5.Text = ""
                    BankName5.Text = ""
                    Payment5.Enabled = False
                    VirtualCalculator5.Enabled = False
                    CardInfo5.Visible = False
                End If
        End Select
    End Sub

    Private Function GetTransactionCode(ByVal TableUID As String)
        If IsReservation = True Then
            Return Nothing
            Exit Function
        End If

        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT TABLEMBTRANSUID FROM TABLELIST WHERE TABLELISTUID = '" & TableUID & "'")
        If TMPRecord.Read() Then
            If IsDBNull(TMPRecord.Item("TABLEMBTRANSUID")) Then
                Return Nothing
            Else
                Return TMPRecord.Item("TABLEMBTRANSUID")
            End If
        End If
        Return Nothing
    End Function

    Private Sub UpdateIsRefundable(ByVal ISPBTRANSUID As String, ByVal Deviation As Decimal)
        Dim TMPRecord As FbDataReader
        Dim Query As String
        Dim PaymentValue As Decimal
        Dim ISPBTRANSDTUID As String

        Query = "SELECT * FROM PBTRANS P LEFT OUTER JOIN PBTRANSDT PDT ON PDT.PBTRANSUID=P.PBTRANSUID LEFT OUTER JOIN PAYMENTTYPE PT ON PT.PAYMENTTYPEUID=PDT.PAYMENTTYPEUID WHERE P.PBTRANSMODULETYPEID='2206' AND PT.PAYMENTTYPEISREFUNDABLE=1 AND P.PBTRANSUID='" & ISPBTRANSUID & "'"
        TMPRecord = MyDatabase.MyReader(Query)

        If TMPRecord.Read() Then
            ISPBTRANSDTUID = TMPRecord.Item("PBTRANSDTUID")
            PaymentValue = CDec(TMPRecord.Item("PBTRANSDTSUBVAL")) - Deviation

            Query = "UPDATE PBTRANSDT SET PBTRANSDTSUBVAL='" & PaymentValue & "' WHERE PBTRANSDTUID='" & ISPBTRANSDTUID & "'"
            Call MyDatabase.MyAdapter(Query)

            'If t = 1 Then
            '    Query = "UPDATE PBTRANSDT SET PBTRANSDTSUBVAL='" & PaymentValue & "' WHERE PBTRANSDTUID='" & ISPBTRANSDTUID & "'"
            '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            'End If
        Else
            ShowMessage(Me, "Maaf, tipe pembayaran yang anda pilih adalah non-refundable, silakan pastikan jumlah pembayaran sama dengan jumlah bill tagihan !")
            ExitIsRefundable = True

            Exit Sub
        End If
    End Sub

    Private Sub SaveDetailNewPB(ByVal inputPBTransUID As String)
        Dim Query As String = Nothing
        Dim LastDtID As String
        If PaymentType1.SelectedIndex > 0 Then
            LastDtID = AutoUID()
            Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                      "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType1.Columns(1).Text & "','" & ReplacePetik(CardNumber1.Text) & "','" & ReplacePetik(CardOwner1.Text) & "','" & ReplacePetik(BankName1.Text) & "','" & CDbl(Payment1.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            Call MyDatabase.MyAdapter(Query)

            'If t = 1 Then
            '    Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
            '         "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType1.Columns(1).Text & "','" & ReplacePetik(CardNumber1.Text) & "','" & ReplacePetik(CardOwner1.Text) & "','" & ReplacePetik(BankName1.Text) & "','" & CDbl(Payment1.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            'End If
        End If

        If PaymentType2.SelectedIndex > 0 Then
            LastDtID = AutoUID()
            Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                      "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType2.Columns(1).Text & "','" & ReplacePetik(CardNumber2.Text) & "','" & ReplacePetik(CardOwner2.Text) & "','" & ReplacePetik(BankName2.Text) & "','" & CDbl(Payment2.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            Call MyDatabase.MyAdapter(Query)

            '31 Jan 2013 susilo, data pajak baru akan disimpan jika no transaksi ini di klik
            'If t = 1 Then
            '    Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
            '               "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType2.Columns(1).Text & "','" & ReplacePetik(CardNumber2.Text) & "','" & ReplacePetik(CardOwner2.Text) & "','" & ReplacePetik(BankName2.Text) & "','" & CDbl(Payment2.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            'End If
        End If

        If PaymentType3.SelectedIndex > 0 Then
            LastDtID = AutoUID()
            Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                      "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType3.Columns(1).Text & "','" & ReplacePetik(CardNumber3.Text) & "','" & ReplacePetik(CardOwner3.Text) & "','" & ReplacePetik(BankName3.Text) & "','" & CDbl(Payment3.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            Call MyDatabase.MyAdapter(Query)

            '31 Jan 2013 susilo, data pajak baru akan disimpan jika no transaksi ini di klik
            'If t = 1 Then
            '    Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
            '               "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType3.Columns(1).Text & "','" & ReplacePetik(CardNumber3.Text) & "','" & ReplacePetik(CardOwner3.Text) & "','" & ReplacePetik(BankName3.Text) & "','" & CDbl(Payment3.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            'End If
        End If

        If PaymentType4.SelectedIndex > 0 Then
            LastDtID = AutoUID()
            Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                      "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType4.Columns(1).Text & "','" & ReplacePetik(CardNumber4.Text) & "','" & ReplacePetik(CardOwner4.Text) & "','" & ReplacePetik(BankName4.Text) & "','" & CDbl(Payment4.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            Call MyDatabase.MyAdapter(Query)

            '31 Jan 2013 susilo, data pajak baru akan disimpan jika no transaksi ini di klik
            'If t = 1 Then
            '    Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
            '                "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType4.Columns(1).Text & "','" & ReplacePetik(CardNumber4.Text) & "','" & ReplacePetik(CardOwner4.Text) & "','" & ReplacePetik(BankName4.Text) & "','" & CDbl(Payment4.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            'End If
        End If

        If PaymentType5.SelectedIndex > 0 Then
            LastDtID = AutoUID()
            Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                      "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType5.Columns(1).Text & "','" & ReplacePetik(CardNumber5.Text) & "','" & ReplacePetik(CardOwner5.Text) & "','" & ReplacePetik(BankName5.Text) & "','" & CDbl(Payment5.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            Call MyDatabase.MyAdapter(Query)

            '31 Jan 2013 susilo, data pajak baru akan disimpan jika no transaksi ini di klik
            'If t = 1 Then
            '    Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
            '            "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType5.Columns(1).Text & "','" & ReplacePetik(CardNumber5.Text) & "','" & ReplacePetik(CardOwner5.Text) & "','" & ReplacePetik(BankName5.Text) & "','" & CDbl(Payment5.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            '    Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            'End If
        End If
    End Sub

    Private Sub SaveDetailExistingPB(ByVal inputPBTransUID As String)

        Dim LastDtID As String
        Dim Query As String = ""
        Dim itemToDel As String = ""


        'Dim TMPRecord As FbDataReader
        'TMPRecord = MyDatabase.MyReader("SELECT PBTransDtUID FROM PBTransDt WHERE PBTransUID = '" & inputPBTransUID & "'")
        'While TMPRecord.Read
        '    If DoesItemExistInGrid(TMPRecord.Item("PBTransDtUID")) = False Then
        '        itemToDel = itemToDel & MY_DELIMITER & TMPRecord.Item("PBTransDtUID")
        '    End If
        'End While

        ''Hapus item DB yang tidak ada di Grid
        'If Len(Trim(itemToDel)) > 0 Then
        '    arrayDetailToBeDeleted = Split(itemToDel, MY_DELIMITER)
        '    For i = 0 To UBound(arrayDetailToBeDeleted)
        '        If Len(Trim(CStr(arrayDetailToBeDeleted(i)))) > 0 Then
        '            Call MyDatabase.MyAdapter("DELETE FROM PBTRANSDT WHERE PBTRANSDTUID = '" & arrayDetailToBeDeleted(i) & "'")
        '        End If
        '    Next
        'End If

        If PaymentType1.SelectedIndex > 0 Then
            LastDtID = AutoUID()

            'If Len(Trim(Label_PBTRANSDTUID1.Text)) = 0 Then
            Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                      "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType1.Columns(1).Text & "','" & ReplacePetik(CardNumber1.Text) & "','" & ReplacePetik(CardOwner1.Text) & "','" & ReplacePetik(BankName1.Text) & "','" & IIf(Me.Text = "Cash In", CDbl(Payment1.Text), CDbl(Payment1.Text) * (-1)) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            Call MyDatabase.MyAdapter(Query)
            'Else
            '    Query = "UPDATE PBTRANSDT SET  PAYMENTTYPEUID = '" & PaymentType1.Columns(1).Text & "', VISAORCHEQUENUMBER ='" & ReplacePetik(CardNumber1.Text) & "', VISAORCHEQUENAME ='" & ReplacePetik(CardOwner1.Text) & "', VISAORCHEQUEBANKNAME ='" & ReplacePetik(BankName1.Text) & "', PBTRANSDTSUBVAL='" & CDbl(Payment1.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSDTUID ='" & Label_PBTRANSDTUID1.Text & "'"
            '    Call MyDatabase.MyAdapter(Query)
            'End If

            '31 Jan 2013 susilo, data pajak baru akan disimpan jika no transaksi ini di klik
            'If t = 1 Then
            '    If Len(Trim(Label_PBTRANSDTUID1.Text)) = 0 Then
            '        Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
            '                  "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType1.Columns(1).Text & "','" & ReplacePetik(CardNumber1.Text) & "','" & ReplacePetik(CardOwner1.Text) & "','" & ReplacePetik(BankName1.Text) & "','" & CDbl(Payment1.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            '        Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            '    Else
            '        Query = "UPDATE PBTRANSDT SET  PAYMENTTYPEUID = '" & PaymentType1.Columns(1).Text & "', VISAORCHEQUENUMBER ='" & ReplacePetik(CardNumber1.Text) & "', VISAORCHEQUENAME ='" & ReplacePetik(CardOwner1.Text) & "', VISAORCHEQUEBANKNAME ='" & ReplacePetik(BankName1.Text) & "', PBTRANSDTSUBVAL='" & CDbl(Payment1.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSDTUID ='" & Label_PBTRANSDTUID1.Text & "'"
            '        Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            '    End If
            'End If
        End If

        Exit Sub

        If PaymentType2.SelectedIndex > 0 Then
            LastDtID = AutoUID()

            If Len(Trim(Label_PBTRANSDTUID2.Text)) = 0 Then
                Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                          "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType2.Columns(1).Text & "','" & ReplacePetik(CardNumber2.Text) & "','" & ReplacePetik(CardOwner2.Text) & "','" & ReplacePetik(BankName2.Text) & "','" & CDbl(Payment2.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
                Call MyDatabase.MyAdapter(Query)
            Else
                Query = "UPDATE PBTRANSDT SET  PAYMENTTYPEUID = '" & PaymentType2.Columns(1).Text & "', VISAORCHEQUENUMBER ='" & ReplacePetik(CardNumber2.Text) & "', VISAORCHEQUENAME ='" & ReplacePetik(CardOwner2.Text) & "', VISAORCHEQUEBANKNAME ='" & ReplacePetik(BankName2.Text) & "', PBTRANSDTSUBVAL='" & CDbl(Payment2.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSDTUID ='" & Label_PBTRANSDTUID2.Text & "'"
                Call MyDatabase.MyAdapter(Query)
            End If

            '31 Jan 2013 susilo, data pajak baru akan disimpan jika no transaksi ini di klik
            'If t = 1 Then
            '    If Len(Trim(Label_PBTRANSDTUID1.Text)) = 0 Then
            '        Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
            '                   "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType2.Columns(1).Text & "','" & ReplacePetik(CardNumber2.Text) & "','" & ReplacePetik(CardOwner2.Text) & "','" & ReplacePetik(BankName2.Text) & "','" & CDbl(Payment2.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            '        Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            '    Else
            '        Query = "UPDATE PBTRANSDT SET  PAYMENTTYPEUID = '" & PaymentType2.Columns(1).Text & "', VISAORCHEQUENUMBER ='" & ReplacePetik(CardNumber2.Text) & "', VISAORCHEQUENAME ='" & ReplacePetik(CardOwner2.Text) & "', VISAORCHEQUEBANKNAME ='" & ReplacePetik(BankName2.Text) & "', PBTRANSDTSUBVAL='" & CDbl(Payment2.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSDTUID ='" & Label_PBTRANSDTUID2.Text & "'"
            '        Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            '    End If
            'End If
        End If

        If PaymentType3.SelectedIndex > 0 Then
            LastDtID = AutoUID()

            If Len(Trim(Label_PBTRANSDTUID3.Text)) = 0 Then
                Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                          "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType3.Columns(1).Text & "','" & ReplacePetik(CardNumber3.Text) & "','" & ReplacePetik(CardOwner3.Text) & "','" & ReplacePetik(BankName3.Text) & "','" & CDbl(Payment3.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
                Call MyDatabase.MyAdapter(Query)
            Else
                Query = "UPDATE PBTRANSDT SET  PAYMENTTYPEUID = '" & PaymentType3.Columns(1).Text & "', VISAORCHEQUENUMBER ='" & ReplacePetik(CardNumber3.Text) & "', VISAORCHEQUENAME ='" & ReplacePetik(CardOwner3.Text) & "', VISAORCHEQUEBANKNAME ='" & ReplacePetik(BankName3.Text) & "', PBTRANSDTSUBVAL='" & CDbl(Payment3.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSDTUID ='" & Label_PBTRANSDTUID3.Text & "'"
                Call MyDatabase.MyAdapter(Query)
            End If

            '31 Jan 2013 susilo, data pajak baru akan disimpan jika no transaksi ini di klik
            'If t = 1 Then
            '    If Len(Trim(Label_PBTRANSDTUID1.Text)) = 0 Then
            '        Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
            '               "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType3.Columns(1).Text & "','" & ReplacePetik(CardNumber3.Text) & "','" & ReplacePetik(CardOwner3.Text) & "','" & ReplacePetik(BankName3.Text) & "','" & CDbl(Payment3.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            '        Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            '    Else
            '        Query = "UPDATE PBTRANSDT SET  PAYMENTTYPEUID = '" & PaymentType3.Columns(1).Text & "', VISAORCHEQUENUMBER ='" & ReplacePetik(CardNumber3.Text) & "', VISAORCHEQUENAME ='" & ReplacePetik(CardOwner3.Text) & "', VISAORCHEQUEBANKNAME ='" & ReplacePetik(BankName3.Text) & "', PBTRANSDTSUBVAL='" & CDbl(Payment3.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSDTUID ='" & Label_PBTRANSDTUID3.Text & "'"
            '        Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            '    End If
            'End If
        End If

        If PaymentType4.SelectedIndex > 0 Then
            LastDtID = AutoUID()

            If Len(Trim(Label_PBTRANSDTUID4.Text)) = 0 Then
                Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                          "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType4.Columns(1).Text & "','" & ReplacePetik(CardNumber4.Text) & "','" & ReplacePetik(CardOwner4.Text) & "','" & ReplacePetik(BankName4.Text) & "','" & CDbl(Payment4.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
                Call MyDatabase.MyAdapter(Query)
            Else
                Query = "UPDATE PBTRANSDT SET  PAYMENTTYPEUID = '" & PaymentType4.Columns(1).Text & "', VISAORCHEQUENUMBER ='" & ReplacePetik(CardNumber4.Text) & "', VISAORCHEQUENAME ='" & ReplacePetik(CardOwner4.Text) & "', VISAORCHEQUEBANKNAME ='" & ReplacePetik(BankName4.Text) & "', PBTRANSDTSUBVAL='" & CDbl(Payment4.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSDTUID ='" & Label_PBTRANSDTUID4.Text & "'"
                Call MyDatabase.MyAdapter(Query)
            End If

            '31 Jan 2013 susilo, data pajak baru akan disimpan jika no transaksi ini di klik
            'If t = 1 Then
            '    If Len(Trim(Label_PBTRANSDTUID1.Text)) = 0 Then
            '        Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
            '                "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType4.Columns(1).Text & "','" & ReplacePetik(CardNumber4.Text) & "','" & ReplacePetik(CardOwner4.Text) & "','" & ReplacePetik(BankName4.Text) & "','" & CDbl(Payment4.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            '        Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            '    Else
            '        Query = "UPDATE PBTRANSDT SET  PAYMENTTYPEUID = '" & PaymentType4.Columns(1).Text & "', VISAORCHEQUENUMBER ='" & ReplacePetik(CardNumber4.Text) & "', VISAORCHEQUENAME ='" & ReplacePetik(CardOwner4.Text) & "', VISAORCHEQUEBANKNAME ='" & ReplacePetik(BankName4.Text) & "', PBTRANSDTSUBVAL='" & CDbl(Payment4.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSDTUID ='" & Label_PBTRANSDTUID4.Text & "'"
            '        Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            '    End If
            'End If
        End If

        If PaymentType5.SelectedIndex > 0 Then
            LastDtID = AutoUID()

            If Len(Trim(Label_PBTRANSDTUID5.Text)) = 0 Then
                Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
                          "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType5.Columns(1).Text & "','" & ReplacePetik(CardNumber5.Text) & "','" & ReplacePetik(CardOwner5.Text) & "','" & ReplacePetik(BankName5.Text) & "','" & CDbl(Payment5.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
                Call MyDatabase.MyAdapter(Query)
            Else
                Query = "UPDATE PBTRANSDT SET  PAYMENTTYPEUID = '" & PaymentType5.Columns(1).Text & "', VISAORCHEQUENUMBER ='" & ReplacePetik(CardNumber5.Text) & "', VISAORCHEQUENAME ='" & ReplacePetik(CardOwner5.Text) & "', VISAORCHEQUEBANKNAME ='" & ReplacePetik(BankName5.Text) & "', PBTRANSDTSUBVAL='" & CDbl(Payment5.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSDTUID ='" & Label_PBTRANSDTUID5.Text & "'"
                Call MyDatabase.MyAdapter(Query)
            End If

            '31 Jan 2013 susilo, data pajak baru akan disimpan jika no transaksi ini di klik
            'If t = 1 Then
            '    If Len(Trim(Label_PBTRANSDTUID1.Text)) = 0 Then
            '        Query = "INSERT INTO PBTRANSDT (PBTRANSDTUID, PBTRANSUID, PAYMENTTYPEUID, VISAORCHEQUENUMBER, VISAORCHEQUENAME, VISAORCHEQUEBANKNAME, PBTRANSDTSUBVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME) " & _
            '                     "VALUES ('" & LastDtID & "','" & inputPBTransUID & "','" & PaymentType5.Columns(1).Text & "','" & ReplacePetik(CardNumber5.Text) & "','" & ReplacePetik(CardOwner5.Text) & "','" & ReplacePetik(BankName5.Text) & "','" & CDbl(Payment5.Text) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "')"
            '        Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            '    Else
            '        Query = "UPDATE PBTRANSDT SET  PAYMENTTYPEUID = '" & PaymentType5.Columns(1).Text & "', VISAORCHEQUENUMBER ='" & ReplacePetik(CardNumber5.Text) & "', VISAORCHEQUENAME ='" & ReplacePetik(CardOwner5.Text) & "', VISAORCHEQUEBANKNAME ='" & ReplacePetik(BankName5.Text) & "', PBTRANSDTSUBVAL='" & CDbl(Payment5.Text) & "', MODIFIEDUSER='" & UserInformation.UserName & "', MODIFIEDDATETIME ='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSDTUID ='" & Label_PBTRANSDTUID5.Text & "'"
            '        Call MyDatabase.MyAdapter2(FileDatabase2, Query)
            '    End If
            'End If
        End If

    End Sub

    Private Function DoesItemExistInGrid(ByVal inputPBTransDtUid As String) As Boolean
        Dim retval As Boolean = False

        If PaymentType1.SelectedIndex > 0 Then
            If Label_PBTRANSDTUID1.Text = inputPBTransDtUid Then
                retval = True
            End If
        End If
        If PaymentType2.SelectedIndex > 0 Then
            If Label_PBTRANSDTUID2.Text = inputPBTransDtUid Then
                retval = True
            End If
        End If
        If PaymentType3.SelectedIndex > 0 Then
            If Label_PBTRANSDTUID3.Text = inputPBTransDtUid Then
                retval = True
            End If
        End If
        If PaymentType4.SelectedIndex > 0 Then
            If Label_PBTRANSDTUID4.Text = inputPBTransDtUid Then
                retval = True
            End If
        End If
        If PaymentType5.SelectedIndex > 0 Then
            If Label_PBTRANSDTUID5.Text = inputPBTransDtUid Then
                retval = True
            End If
        End If
        DoesItemExistInGrid = retval
    End Function

    Private Sub ShowMakeBillPaymentPreview(Optional ByVal Nota As Boolean = False)

        Dim OBJNew As New Form_Print_Preview
        Dim Query As String = Nothing

        Make_Bill_Payment.TransactionUID = TransactionUID
        publicUseChange = True
        publicPayment1 = Payment1.Text
        publicPayment2 = Payment2.Text
        publicPayment3 = Payment3.Text
        publicPayment4 = Payment4.Text
        publicPayment5 = Payment5.Text
        publicPaymentChange = ChangeTxt.Text
        publicPaymentRest = RestTxt.Text

        '18 Juni 2012 - Weird, query palsu, buat pancingan aja
        Query = "SELECT * FROM POSPREF "

        OBJNew.Name = "Form_Print_Preview"
        OBJNew.RPTTitle = "Payment"
        OBJNew.RPTDocument = New Make_Bill_Payment
        OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
        OBJNew.VersiNota = Nota
        OBJNew.ShowDialog()

    End Sub

    
#End Region

#Region "Form Control Function"

    Private Sub Form_Payment_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New System.Drawing.Point(MainPage.Location.X + 220, MainPage.Location.Y + 210)
        Me.Cursor = Cursors.Default
        Call BasicInitialize()
        PrintCounter.Text = "1"
    End Sub

    Private Sub VirtualKeyCO(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKeyCO1.Click, VirtualKeyCO2.Click, VirtualKeyCO3.Click, VirtualKeyCO4.Click, VirtualKeyCO5.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        Select Case sender.name
            Case "VirtualKeyCO1"
                VirtuKey.OBJBind(CardOwner1, False)
            Case "VirtualKeyCO2"
                VirtuKey.OBJBind(CardOwner2, False)
            Case "VirtualKeyCO3"
                VirtuKey.OBJBind(CardOwner3, False)
            Case "VirtualKeyCO4"
                VirtuKey.OBJBind(CardOwner4, False)
            Case "VirtualKeyCO5"
                VirtuKey.OBJBind(CardOwner5, False)
        End Select
        VirtuKey.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VirtualKeyCN(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKeyCN1.Click, VirtualKeyCN2.Click, VirtualKeyCN3.Click, VirtualKeyCN4.Click, VirtualKeyCN5.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        Select Case sender.name
            Case "VirtualKeyCN1"
                VirtuKey.OBJBind(CardNumber1, False)
            Case "VirtualKeyCN2"
                VirtuKey.OBJBind(CardNumber2, False)
            Case "VirtualKeyCN3"
                VirtuKey.OBJBind(CardNumber3, False)
            Case "VirtualKeyCN4"
                VirtuKey.OBJBind(CardNumber4, False)
            Case "VirtualKeyCN5"
                VirtuKey.OBJBind(CardNumber5, False)
        End Select
        VirtuKey.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VirtualKeyBN(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKeyBN1.Click, VirtualKeyBN2.Click, VirtualKeyBN3.Click, VirtualKeyBN4.Click, VirtualKeyBN5.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        Select Case sender.name
            Case "VirtualKeyBN1"
                VirtuKey.OBJBind(BankName1, False)
            Case "VirtualKeyBN2"
                VirtuKey.OBJBind(BankName2, False)
            Case "VirtualKeyBN3"
                VirtuKey.OBJBind(BankName3, False)
            Case "VirtualKeyBN4"
                VirtuKey.OBJBind(BankName4, False)
            Case "VirtualKeyBN5"
                VirtuKey.OBJBind(BankName5, False)
        End Select
        VirtuKey.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click


        ExitIsRefundable = False
        Dim Query As String = Nothing

        If CDec(Payment1.Text) <> 0 Then
            If PaymentType1.SelectedIndex = 0 Then
                ShowMessage("Me", "Silakan pilih tipe kas !")
                MainArea.SelectedTab = PaymentType
                PaymentType1.Focus()
                Exit Sub
            End If
        End If

        
        If CDec(Payment1.Text) = 0 Then
            ShowMessage(Me, "Maaf, jumlah tidak boleh nol !")
            Payment1.Focus()
            Exit Sub
        End If        

        Dim TotalPaidDownPayment As Double = CDbl(Payment1.Text) ' + CDbl(Payment2.Text) + CDbl(Payment3.Text) + CDbl(Payment4.Text) + CDbl(Payment5.Text)        

        Me.Cursor = Cursors.WaitCursor        
        If BTNNew.Visible = False Then
            Dim LastID = AutoUID()
            PaymentNo.Text = AutoIDNumber(IIf(Me.Text = "Cash In", "2501", "2502"), "PBTRANS", "PBTRANSNO")
            Query = "INSERT INTO PBTRANS (PBTRANSUID, PBTRANSNO,PBTRANSSTAT,PBTRANSDATE, PBTRANSDEPTUID, PBTRANSMODULETYPEID, PBTRANSSHIFTNO, PBTRANSRSVTRANSUID, PBTRANSMBTRANSUID, PBTRANSCUSTUID, PBTRANSCUSTNAME, PBTRANSTABLELISTUID, PBTRANSTOTVAL, CREATEDUSER, MODIFIEDUSER, CREATEDDATETIME, MODIFIEDDATETIME,PRINTCOUNTER,ISFISCAL,PBTRANSDESC) " & _
                       "VALUES ('" & LastID & "','" & PaymentNo.Text & "',0,'" & Format(PaymentDate.Value, "dd.MM.yyyy") & ", " & Format(ReservationTime.Value, "HH:mm:ss") & "','" & DeptInfo.DeptUID & "','" & IIf(Me.Text = "Cash In", "2501", "2502") & "','" & Shift & "',NULL,NULL,NULL,'" & ReplacePetik(Me.Text) & "',NULL,'" & IIf(Me.Text = "Cash In", CDbl(Payment1.Text), CDbl(Payment1.Text) * (-1)) & "','" & UserInformation.UserName & "','" & UserInformation.UserName & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "','" & PrintCounter.Text & "','" & t & "','" & ReplacePetik(txtKeterangan.Text) & "')"
            Call MyDatabase.MyAdapter(Query)

            Call SaveDetailExistingPB(LastID)
        Else
            Query = "UPDATE PBTRANS SET PBTRANSDATE='" & Format(PaymentDate.Value, "dd.MM.yyyy") & ", " & Format(ReservationTime.Value, "HH:mm:ss") & "',PBTRANSDEPTUID='" & DeptInfo.DeptUID & "',PBTRANSMODULETYPEID='" & IIf(Me.Text = "Cash In", "2501", "2502") & "',PBTRANSTOTVAL='" & IIf(Me.Text = "Cash In", CDbl(Payment1.Text), CDbl(Payment1.Text) * (-1)) & "',PBTRANSDESC='" & ReplacePetik(txtKeterangan.Text) & "',MODIFIEDUSER='" & ReplacePetik(UserInformation.UserName) & "',MODIFIEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSUID='" & pubIdTrans & "'"
            Call MyDatabase.MyAdapter(Query)

            Query = "UPDATE PBTRANSDT SET PAYMENTTYPEUID='" & PaymentType1.Columns(1).Text & "',PBTRANSDTSUBVAL='" & IIf(Me.Text = "Cash In", CDbl(Payment1.Text), CDbl(Payment1.Text) * (-1)) & "',MODIFIEDUSER='" & ReplacePetik(UserInformation.UserName) & "',MODIFIEDDATETIME='" & Format(Now, "dd.MM.yyyy, HH:mm:ss") & "' WHERE PBTRANSUID='" & pubIdTrans & "'"
            Call MyDatabase.MyAdapter(Query)
        End If
        Call ShowPrintPreview(True)
        Me.Cursor = Cursors.Default
        Call BTNNew_Click(BTNNew, e)

    End Sub

    Private Sub ShowPrintPreview(Optional ByVal Nota As Boolean = False)
        Dim OBJNew As New Form_Print_Preview
        Dim Query As String

        'Query = "SELECT a.MBTRANSUID, a.MBTRANSNO, a.MBTRANSDATE, a.MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME, a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID, a.MBTRANSRSVTRANSUID, a.MBTRANSSUBVAL, a.MBTRANSDISCPERC, a.MBTRANSDISCVAL, a.MBTRANSTAXVAL1, a.MBTRANSTAXVAL2, a.MBTRANSDPVAL, a.MBTRANSTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT,a.CREATEDUSER, a.MODIFIEDUSER,a.MODIFIEDDATETIME, b.TABLELISTNAME,(SELECT CUSTNO FROM CUST WHERE CUSTUID = a.MBTRANSCUSTUID) AS CUSTNO, (SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = a.MBTRANSSERVICETYPEUID ) AS SERVICENAME " & _
        '        "FROM MBTRANS a LEFT JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE MBTRANSUID = '" & TransactionUID & "'"
        Dim tipeBayar As String = ""
        tipeBayar = IIf(Me.Text = "Cash In", "Cash In", "Cash Out")
        Query = "SELECT A.*,PAYMENTTYPENAME,'" & tipeBayar & "' AS TipeBayar FROM PBTRANS A INNER JOIN PBTRANSDT B ON A.PBTRANSUID=B.PBTRANSUID INNER JOIN PAYMENTTYPE C ON B.PAYMENTTYPEUID=C.PAYMENTTYPEUID WHERE A.PBTRANSNO='" & PaymentNo.Text & "'"


        OBJNew.Name = "Form_Print_Preview"
        OBJNew.RPTTitle = "Cash In"

        'Dim CashInOut As New Cash_In_Out
        If PrefInfo.printSize = "58" Then
            OBJNew.RPTDocument = New Cash_In_Out58
        Else
            OBJNew.RPTDocument = New Cash_In_Out
        End If
        OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
        OBJNew.VersiNota = Nota
        OBJNew.ShowDialog()
    End Sub

    Private Function CheckAdaPembayaranRefundable() As Boolean

        CheckAdaPembayaranRefundable = False

        If CDec(Payment1.Text) <> 0 Then
            If PaymentType1.Columns(3).Text = "1" Then CheckAdaPembayaranRefundable = True
        End If

        If CDec(Payment2.Text) <> 0 Then
            If PaymentType2.Columns(3).Text = "1" Then CheckAdaPembayaranRefundable = True
        End If

        If CDec(Payment3.Text) <> 0 Then
            If PaymentType3.Columns(3).Text = "1" Then CheckAdaPembayaranRefundable = True
        End If

        If CDec(Payment4.Text) <> 0 Then
            If PaymentType4.Columns(3).Text = "1" Then CheckAdaPembayaranRefundable = True
        End If

        If CDec(Payment5.Text) <> 0 Then
            If PaymentType5.Columns(3).Text = "1" Then CheckAdaPembayaranRefundable = True
        End If

    End Function

    Private Sub BTNCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNCancel.Click

        Me.Close()
    End Sub

    Private Sub Control_KeyPress(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyPressEventArgs) Handles Payment1.KeyPress, Payment2.KeyPress, Payment3.KeyPress, Payment4.KeyPress, Payment5.KeyPress
        sender.selectionstart = Len(sender.text)
    End Sub

    Private Sub PaymentTXTChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Payment1.TextChanged, Payment2.TextChanged, Payment3.TextChanged, Payment4.TextChanged, Payment5.TextChanged
        If IsNumeric(Payment1.Text) = False Then
            Payment1.Text = "0"
            Exit Sub
        End If
        If IsNumeric(Payment2.Text) = False Then
            Payment2.Text = "0"
            Exit Sub
        End If
        If IsNumeric(Payment3.Text) = False Then
            Payment3.Text = "0"
            Exit Sub
        End If
        If IsNumeric(Payment4.Text) = False Then
            Payment4.Text = "0"
            Exit Sub
        End If
        If IsNumeric(Payment5.Text) = False Then
            Payment5.Text = "0"
            Exit Sub
        End If

        If Payment1.Text = "" Then
            Payment1.Text = "0"
        End If
        If Payment2.Text = "" Then
            Payment2.Text = "0"
        End If
        If Payment3.Text = "" Then
            Payment3.Text = "0"
        End If
        If Payment4.Text = "" Then
            Payment4.Text = "0"
        End If
        If Payment5.Text = "" Then
            Payment5.Text = "0"
        End If

        If GrandTotalTxt.Text = "" Then
            GrandTotalTxt.Text = "0"
        End If
        If PaidTxt.Text = "" Then
            PaidTxt.Text = "0"
        End If
        If RestTxt.Text = "" Then
            RestTxt.Text = "0"
        End If

        Dim Retotal As Double = 0
        Retotal = CDbl(Payment1.Text) + CDbl(Payment2.Text) + CDbl(Payment3.Text) + CDbl(Payment4.Text) + CDbl(Payment5.Text) + Paid
        PaidTxt.Value = FormatNumber(Retotal, 0)

        Payment1.Text = FormatNumber(Payment1.Text, 0)
        Payment2.Text = FormatNumber(Payment2.Text, 0)
        Payment3.Text = FormatNumber(Payment3.Text, 0)
        Payment4.Text = FormatNumber(Payment4.Text, 0)
        Payment5.Text = FormatNumber(Payment5.Text, 0)

        If CDbl(GrandTotalTxt.Text) > CDbl(PaidTxt.Text) Then
            Dim Rest As Double
            Rest = CDbl(GrandTotalTxt.Text) - CDbl(PaidTxt.Text)

            RestTxt.Value = FormatNumber(Rest, 0)
            ChangeTxt.Value = 0
        Else
            Dim Change As Double
            Change = CDbl(PaidTxt.Text) - CDbl(GrandTotalTxt.Text)

            ChangeTxt.Value = FormatNumber(Change, 0)
            RestTxt.Value = 0
        End If

    End Sub

    Private Sub PaymentType_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PaymentType1.TextChanged, PaymentType2.TextChanged, PaymentType3.TextChanged, PaymentType4.TextChanged, PaymentType5.TextChanged

        PaymentTypeBehaviour(sender.name)

        Select Case sender.name
            Case "PaymentType1"
                If CardInfo1.Visible = True Then CardOwner1.Focus()
            Case "PaymentType2"
                If CardInfo2.Visible = True Then CardOwner2.Focus()
            Case "PaymentType3"
                If CardInfo3.Visible = True Then CardOwner3.Focus()
            Case "PaymentType4"
                If CardInfo4.Visible = True Then CardOwner4.Focus()
            Case "PaymentType5"
                If CardInfo5.Visible = True Then CardOwner5.Focus()
        End Select

    End Sub

    Private Sub VirtualCalculator1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualCalculator1.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        VirtuCalculator.OBJBind(Payment1)
        VirtuCalculator.showMoney = True
        VirtuCalculator.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VirtualCalculator2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualCalculator2.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        VirtuCalculator.OBJBind(Payment2)
        VirtuCalculator.showMoney = True
        VirtuCalculator.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VirtualCalculator3_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VirtualCalculator3.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        VirtuCalculator.OBJBind(Payment3)
        VirtuCalculator.showMoney = True
        VirtuCalculator.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VirtualCalculator4_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VirtualCalculator4.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        VirtuCalculator.OBJBind(Payment4)
        VirtuCalculator.showMoney = True
        VirtuCalculator.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub VirtualCalculator5_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles VirtualCalculator5.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuCalculator As New Form_Virtual_Calculator
        VirtuCalculator.OBJBind(Payment5)
        VirtuCalculator.showMoney = True
        VirtuCalculator.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Form_Payment_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        If e.KeyCode = Keys.F2 Then
            Call OpenCashDrawer()
        End If
    End Sub


#End Region

    Private Sub VirtualDate_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualDate.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtualDate As New Form_Virtual_Date
        VirtualDate.Name = "Form_Virtual_Date"
        VirtualDate.Text = "Please Select Date"
        VirtualDate.ParentOBJForm = Me
        VirtualDate.publicChosenDate = CurrDate

        VirtualDate.ShowDialog()

        PaymentDate.Text = VirtualDate.publicChosenDate
        CurrDate = VirtualDate.publicChosenDate
        DateLabel.Text = Format(PaymentDate.Value, "dddd , dd MMMM yyyy")
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub Payment1_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles Payment1.KeyUp, Payment2.KeyUp, Payment3.KeyUp, Payment4.KeyUp, Payment5.KeyUp
        sender.selectionstart = Len(sender.text)
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
                       "LEFT OUTER JOIN TableList tlist ON mb.RSVTRANSTABLELISTUID = tlist.TableListUID " & _
                       "LEFT OUTER JOIN PaymentType pType ON pbdt.PaymentTypeUID = pType.PaymentTypeUID WHERE pb.PBTRANSNO='" & inputPBTransNo & "'"

        'rs = strSQL.ExecuteReader
        rs = MyDatabase.MyReader(strSQL)
        rowNum = 0
        While rs.Read() = True

            If IsDBNull(rs("TrNo")) Then Exit Sub

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

    Private Function DecodeCardReader(ByVal inputString As String) As String

        On Error GoTo decodeError

        Dim retVal As String = ""
        Dim tmpString As String, jenisKartu As String = "", noKartu As String = "", pemilikKartu As String = "", indexPos As Integer
        Dim arrayData

        indexPos = InStr(inputString, "%B")
        If indexPos > 0 Then inputString = Mid(inputString, indexPos, Len(inputString))

        If Strings.Left(inputString, 2) = "%B" Then
            tmpString = Mid(inputString, 3, Len(inputString))
            arrayData = Split(tmpString, "^")
            If UBound(arrayData) >= 2 Then
                If CStr(Mid(arrayData(0), 1, 1)) = "1" Then
                    jenisKartu = "JCB"
                ElseIf CStr(Mid(arrayData(0), 1, 1)) = "2" Then
                    jenisKartu = "JCB"
                ElseIf CStr(Mid(arrayData(0), 1, 1)) = "3" Then
                    jenisKartu = "AMERICAN EXPRESS"
                ElseIf CStr(Mid(arrayData(0), 1, 1)) = "4" Then
                    jenisKartu = "VISA"
                ElseIf CStr(Mid(arrayData(0), 1, 1)) = "5" Then
                    jenisKartu = "MASTERCARD"
                ElseIf CStr(Mid(arrayData(0), 1, 1)) = "6" Then
                    jenisKartu = "DISCOVER"
                End If
                noKartu = Trim(arrayData(0))
                pemilikKartu = Trim(arrayData(1))
                If Mid(pemilikKartu, 1, 1) = "/" Then pemilikKartu = Mid(pemilikKartu, 2, Len(pemilikKartu))
                If Strings.Right(pemilikKartu, 1) = "/" Then pemilikKartu = Strings.Left(pemilikKartu, Len(pemilikKartu) - 1)
            End If
            retVal = jenisKartu & MY_DELIMITER & noKartu & MY_DELIMITER & pemilikKartu
        End If

        DecodeCardReader = retVal

        Exit Function

decodeError:

        DecodeCardReader = ""

    End Function

    Private Sub CardDetail_KeyUp(ByVal sender As Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles CardOwner1.KeyUp, CardOwner2.KeyUp, CardOwner3.KeyUp, CardOwner4.KeyUp, CardOwner5.KeyUp, CardNumber1.KeyUp, CardNumber2.KeyUp, CardNumber3.KeyUp, CardNumber4.KeyUp, CardNumber5.KeyUp, BankName1.KeyUp, BankName2.KeyUp, BankName3.KeyUp, BankName4.KeyUp, BankName5.KeyUp

        Dim arrayData
        Dim readCard As String = ""

        If e.KeyCode = 13 Then
            If sender.name = "CardOwner1" Or sender.name = "CardNumber1" Or sender.name = "BankName1" Then
                If sender.name = "CardOwner1" Then
                    readCard = DecodeCardReader(CardOwner1.Text)
                ElseIf sender.name = "CardNumber1" Then
                    readCard = DecodeCardReader(CardNumber1.Text)
                ElseIf sender.name = "BankName1" Then
                    readCard = DecodeCardReader(BankName1.Text)
                End If
                If Len(Trim(readCard)) > 0 Then
                    arrayData = Split(readCard, MY_DELIMITER)
                    CardOwner1.Text = CStr(arrayData(2))
                    CardNumber1.Text = CStr(arrayData(1))
                    BankName1.Text = CStr(arrayData(0))
                    GrandTotalTxt.Focus()
                End If
            ElseIf sender.name = "CardOwner2" Or sender.name = "CardNumber2" Or sender.name = "BankName2" Then
                If sender.name = "CardOwner2" Then
                    readCard = DecodeCardReader(CardOwner2.Text)
                ElseIf sender.name = "CardNumber2" Then
                    readCard = DecodeCardReader(CardNumber2.Text)
                ElseIf sender.name = "BankName2" Then
                    readCard = DecodeCardReader(BankName2.Text)
                End If
                If Len(Trim(readCard)) > 0 Then
                    arrayData = Split(readCard, MY_DELIMITER)
                    CardOwner2.Text = CStr(arrayData(2))
                    CardNumber2.Text = CStr(arrayData(1))
                    BankName2.Text = CStr(arrayData(0))
                    GrandTotalTxt.Focus()
                End If
            ElseIf sender.name = "CardOwner3" Or sender.name = "CardNumber3" Or sender.name = "BankName3" Then
                If sender.name = "CardOwner3" Then
                    readCard = DecodeCardReader(CardOwner3.Text)
                ElseIf sender.name = "CardNumber3" Then
                    readCard = DecodeCardReader(CardNumber3.Text)
                ElseIf sender.name = "BankName3" Then
                    readCard = DecodeCardReader(BankName3.Text)
                End If
                If Len(Trim(readCard)) > 0 Then
                    arrayData = Split(readCard, MY_DELIMITER)
                    CardOwner3.Text = CStr(arrayData(2))
                    CardNumber3.Text = CStr(arrayData(1))
                    BankName3.Text = CStr(arrayData(0))
                    GrandTotalTxt.Focus()
                End If
            ElseIf sender.name = "CardOwner4" Or sender.name = "CardNumber4" Or sender.name = "BankName4" Then
                If sender.name = "CardOwner4" Then
                    readCard = DecodeCardReader(CardOwner4.Text)
                ElseIf sender.name = "CardNumber4" Then
                    readCard = DecodeCardReader(CardNumber4.Text)
                ElseIf sender.name = "BankName4" Then
                    readCard = DecodeCardReader(BankName4.Text)
                End If
                If Len(Trim(readCard)) > 0 Then
                    arrayData = Split(readCard, MY_DELIMITER)
                    CardOwner4.Text = CStr(arrayData(2))
                    CardNumber4.Text = CStr(arrayData(1))
                    BankName4.Text = CStr(arrayData(0))
                    GrandTotalTxt.Focus()
                End If
            ElseIf sender.name = "CardOwner5" Or sender.name = "CardNumber5" Or sender.name = "BankName5" Then
                If sender.name = "CardOwner5" Then
                    readCard = DecodeCardReader(CardOwner5.Text)
                ElseIf sender.name = "CardNumber5" Then
                    readCard = DecodeCardReader(CardNumber5.Text)
                ElseIf sender.name = "BankName5" Then
                    readCard = DecodeCardReader(BankName5.Text)
                End If
                If Len(Trim(readCard)) > 0 Then
                    arrayData = Split(readCard, MY_DELIMITER)
                    CardOwner5.Text = CStr(arrayData(2))
                    CardNumber5.Text = CStr(arrayData(1))
                    BankName5.Text = CStr(arrayData(0))
                    GrandTotalTxt.Focus()
                End If
            End If
        End If

    End Sub
   
    Private Sub VirtualKey_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles VirtualKey.Click
        Me.Cursor = Cursors.WaitCursor
        Dim VirtuKey As New VirtualKey
        VirtuKey.OBJBind(txtKeterangan, False)
        VirtuKey.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub cmdList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdList.Click
        Me.Cursor = Cursors.WaitCursor
        pubIdTrans = Nothing
        Dim OBJNew As New Form_Cash_In_Out_List
        OBJNew.Name = "Form_Cash_In_Out_List"
        OBJNew.Text = Me.Text & " List"
        OBJNew.ShowDialog()
        Me.Cursor = Cursors.Default
        If pubIdTrans = Nothing Then Exit Sub
        Call fillForm()
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
        TimeLabel.Text = Format(ReservationTime.Value, "hh:mm:ss tt")
        Me.Cursor = Cursors.Default

    End Sub

    Private Sub BTNNew_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNNew.Click
        PaymentNo.Text = AutoIDNumber(IIf(Me.Text = "Cash In", "2501", "2502"), "PBTRANS", "PBTRANSNO")
        BTNNew.Visible = False : BTNCancel.Visible = True
        PaymentType1.SelectedIndex = -1
        txtKeterangan.Text = Nothing
        Payment1.Text = 0
        PrintCounter.Text = "1"
    End Sub
End Class