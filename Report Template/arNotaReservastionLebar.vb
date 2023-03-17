Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 
Imports FirebirdSql.Data.FirebirdClient

Public Class arNotaReservationLebar    
    Private Sub arNotaReservationLebar_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Me.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF")
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format       
        txtTanggal.Text = Format(Now.Date, "dd-MM-yyyy")
        Dim rs As FbDataReader
        rs = MyDatabase.MyReader("SELECT FIRST 1 B.PBTRANSDTSUBVAL FROM PBTRANS A INNER JOIN PBTRANSDT B ON A.PBTRANSUID=B.PBTRANSUID WHERE A.PBTRANSRSVTRANSUID='" & txtIDReservasi.Text & "' ORDER BY B.CREATEDDATETIME DESC")
        If rs.Read = True Then
            txtNilaiUM.Text = FormatNumber(rs(0), 0)
            txtTerbilang.Text = Terbilang(CDbl(rs(0)))
        Else
            txtNilaiUM.Text = "0"
            txtTerbilang.Text = "Nol Rupiah"
        End If
        rs = Nothing
        txtTanggalReservasi.Text = Format(txtTanggalReservasi.Text, "dddd / dd-MM-yyyy")
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim DataPoint As New DataSet
        Dim SubItem = New ActiveReport3
        Dim Query As String

        SubItem = New Reservation_Sub_Item_Lebar

        Query = "SELECT a.RSVTRANSDTITEMNAME, a.RSVTRANSDTITEMQTY, a.RSVTRANSDTITEMPRICE, b.RSVTRANSDTITEMNAME AS DETAILITEM,b.RSVTRANSDTITEMQTY AS DETAILQTY " & _
                "FROM RSVTRANSDT a LEFT OUTER JOIN RSVTRANSDTDETAIL b ON b.RSVTRANSDTUID=a.RSVTRANSDTUID " & _
                "WHERE RSVTRANSUID ='" & txtIDReservasi.Text & "'"

        DataPoint = MyDatabase.MyAdapter(Query)

        Me.SubReport1.Report = SubItem
        Me.SubReport1.Report.DataSource = DataPoint
        Me.SubReport1.Report.DataMember = DataPoint.Tables(0).TableName
    End Sub

#Region "Function-Function"
    Private Function getTotalRowPayment(ByVal idReservasi As String) As Integer
        Dim rs As FbDataReader
        rs = MyDatabase.MyReader("SELECT COUNT(PBTRANSDATE) FROM PBTRANS WHERE PBTRANSRSVTRANSUID='" & idReservasi & "' AND DELETEDDATETIME IS NULL")
        If rs.Read = True Then
            Return CInt(rs(0))
        Else
            Return 0
        End If
        rs = Nothing
    End Function
    Private Function Terbilang(ByVal Angka As Double) As String
        Dim strAngka, strDiurai, Urai, Tbl1, Tbl2 As String
        Dim x, y, z As Short
        Dim arrBelasan() As String = {"SEPULUH ", "SEBELAS ", _
            "DUA BELAS ", "TIGA BELAS ", "EMPAT BELAS ", _
            "LIMA BELAS ", "ENAM BELAS ", "TUJUH BELAS ", _
            "DELAPAN BELAS ", "SEMBILAN BELAS "}
        Dim arrSatuan() As String = {"DUA ", "TIGA ", "EMPAT ", _
            "LIMA ", "ENAM ", "TUJUH ", "DELAPAN ", "SEMBILAN "}
        Urai = ""
        'Angka yang akan dibuat terbilang dibulatkan dulu Jika ada desimalnya

        Angka = Math.Round(Angka)

        'Angka tipe Double diubah menjadi string Dihilangkan spasi dikiri atau kanan angka jika ada
        strAngka = Trim(CStr(Angka))

        'Perulangan While ...End While akan mengevaluasi angka satu per satu dan dimulai dari angka paling kiri
        'x menunjukkan iterasi ke berapa dimulai dari 1

        While (x < Len(strAngka))
            x += 1
            strDiurai = Mid(strAngka, x, 1)

            'y menunjukkan angka yang sedang dievaluasi
            y += Val(strDiurai)

            'z menunjukkan posisi digit ke berapa
            z = Len(strAngka) - x + 1

            ' Jika yang dievaluasi angka 1
            If Val(strDiurai) = 1 Then
                If (z = 1 Or z = 7 Or z = 10 Or z = 13) Then
                    Tbl1 = "SATU "
                ElseIf (z = 4) Then
                    If (x = 1) Then
                        Tbl1 = "SE"
                    Else
                        Tbl1 = "SATU "
                    End If
                ElseIf (z = 2 Or z = 5 Or z = 8 Or z = 11 Or z = 14) Then
                    'Ditambahkan iterasi angka berikutnya
                    x += 1
                    strDiurai = Mid(strAngka, x, 1)
                    z = Len(strAngka) - x + 1
                    Tbl2 = ""
                    Tbl1 = arrBelasan(Val(strDiurai))
                Else
                    Tbl1 = "SE"
                End If
                'Yang dievaluasi angka 2 sampai 9
            ElseIf Val(strDiurai) > 1 And Val(strDiurai) < 10 Then
                Tbl1 = arrSatuan((Val(strDiurai)) - 2)
            Else
                Tbl1 = ""
            End If

            If (Val(strDiurai) > 0) Then
                If (z = 2 Or z = 5 Or z = 8 Or z = 11 Or _
                        z = 14) Then
                    Tbl2 = "PULUH "
                ElseIf (z = 3 Or z = 6 Or z = 9 Or z = 12 _
                        Or z = 15) Then
                    Tbl2 = "RATUS "
                Else
                    Tbl2 = ""
                End If
            Else
                Tbl2 = ""
            End If

            If (y > 0) Then
                Select Case z
                    Case 4
                        Tbl2 &= "RIBU "
                        y = 0
                    Case 7
                        Tbl2 &= "JUTA "
                        y = 0
                    Case 10
                        Tbl2 &= "MILYAR "
                        y = 0
                    Case 13
                        Tbl2 &= "TRILYUN "
                        y = 0
                End Select
            End If
            Urai = Urai & Tbl1 & Tbl2
        End While

        Terbilang = Urai & "RUPIAH"
    End Function
#End Region

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        CompanyNameText.Value = CompanyInformation.CompanyName
        CompanyAddressText.Value = CompanyInformation.Address & ", " & CompanyInformation.City
        CompanyPhoneText.Value = IIf(pubIsDemo = True, "=== Demo Version ===", "Phone : " & CompanyInformation.Phone & "    Fax : " & CompanyInformation.Fax)
        txtNomorDP.Text = getTotalRowPayment(txtIDReservasi.Text).ToString
        txtNomorDP.Text = "DP " & txtNomorDP.Text
    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        Label32.Text = UserInformation.UserName
        lblTglCetak.Value = Format(Now, "dd MMMM yyyy HH:mm:ss")
    End Sub
End Class
