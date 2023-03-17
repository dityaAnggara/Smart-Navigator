Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports FirebirdSql.Data.FirebirdClient

Public Class Reservation58
    Private Function GETTableName(ByVal TransUID As String) As String
        Dim Result As String = ""
        Dim TMPResult As FbDataReader
        TMPResult = MyDatabase.MyReader("SELECT a.RSVTRANSTABLELISTUID, (SELECT TABLELISTNAME FROM TABLELIST WHERE TABLELISTUID = a.RSVTRANSTABLELISTUID) FROM RSVTRANSTABLELIST a WHERE RSVTRANSUID='" & TransUID & "'")
        While TMPResult.Read()
            Result = Result & "," & TMPResult("TABLELISTNAME")
        End While
        If Trim(Result) = "" Then
            Return ""
        Else
            Return "TABLE : " & Mid(Result, 2, Len(Result))
        End If
    End Function

    Private Sub Reservation_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Me.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF")
        If PrefInfo.invNota = "1" Then ReservationNoLabel.Visible = False
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

        TransactionDateLabel.Value = "DATE : " & Format(TransactionDateLabel.Value, "dd/MM/yyyy HH:mm")
        ReservationNoLabel.Value = "NO : " & ReservationNoLabel.Value
        ReservationPaxLabel.Value = "PAX : " & ReservationPaxLabel.Value

        ReservationTimeLabel.Value = Format(ReservationTimeLabel.Value, "HH:mm")
        ReservationDateLabel.Value = "RSV DATE : " & Format(ReservationDateLabel.Value, "dd/MM/yyyy") & " " & ReservationTimeLabel.Value

        CurrentDateLabel.Value = Format(Now, "dd/MM/yyyy HH:mm")
        ReservationPrintUserLabel.Value = UserInformation.UserName & "     " & CurrentDateLabel.Value

        ReservationTableText.Value = GETTableName(TransactionUID.Value)
        ReservationPrinterCounterLabel.Value = "PRINT : " & ReservationPrinterCounterLabel.Value
        ReservationCreatedUserLabel.Value = "OP : " & ReservationCreatedUserLabel.Value

        Dim GrandTotal As Decimal = 0
        GrandTotal = Val(ReservationSubTotalLabel.Text) - Val(ReservationDownPaymentLabel.Text)

        ReservationSubTotalLabel.Value = FormatNumber(ReservationSubTotalLabel.Text, DijitKoma, , , TriState.True)
        ReservationDownPaymentLabel.Value = FormatNumber(ReservationDownPaymentLabel.Text, DijitKoma, , , TriState.True)
        ReservationTotalNetLabel.Value = FormatNumber(GrandTotal, DijitKoma, , , TriState.True)

        Dim DataPoint As New DataSet
        Dim SubItem = New ActiveReport3
        Dim Query As String

        SubItem = New Reservation_Sub_Item58

        Query = "SELECT a.RSVTRANSDTITEMNAME, a.RSVTRANSDTITEMQTY, a.RSVTRANSDTITEMPRICE, b.RSVTRANSDTITEMNAME AS DETAILITEM,b.RSVTRANSDTITEMQTY AS DETAILQTY " & _
                "FROM RSVTRANSDT a LEFT OUTER JOIN RSVTRANSDTDETAIL b ON b.RSVTRANSDTUID=a.RSVTRANSDTUID " & _
                "WHERE a.RSVTRANSUID ='" & TransactionUID.Text & "'"

        DataPoint = MyDatabase.MyAdapter(Query)

        Me.SubReport1.Report = SubItem
        Me.SubReport1.Report.DataSource = DataPoint
        Me.SubReport1.Report.DataMember = DataPoint.Tables(0).TableName

        ' # -----------------------------------------------------------

        SubItem = New Reservation_Sub_Payment58
        Query = "SELECT a.PBTRANSRSVTRANSUID,a.PBTRANSNO,a.PBTRANSDATE,b.PAYMENTTYPEUID, a.PBTRANSCUSTUID, a.PBTRANSTOTVAL, b.VISAORCHEQUENUMBER, b.VISAORCHEQUENAME, b.VISAORCHEQUEBANKNAME, b.PBTRANSDTSUBVAL, a.PBTRANSDESC, a.PBTRANSSTAT, c.PAYMENTTYPENAME " & _
                "FROM PBTRANS a LEFT JOIN PBTRANSDT b ON a.PBTransUID = b.PBTransUID " & _
                "LEFT JOIN PAYMENTTYPE c ON b.PAYMENTTYPEUID = c.PAYMENTTYPEUID WHERE PBTRANSSTAT <> -1 AND PBTRANSRSVTRANSUID = '" & TransactionUID.Text & "' ORDER BY a.PBTRANSNO,c.PAYMENTTYPENAME"

        DataPoint = MyDatabase.MyAdapter(Query)

        Me.SubReport2.Report = SubItem
        Me.SubReport2.Report.DataSource = DataPoint
        Me.SubReport2.Report.DataMember = DataPoint.Tables(0).TableName

        If PrefInfo.Footer = "" Then
            FooterText.Visible = False
        Else
            FooterText.Text = PrefInfo.Footer
        End If
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        CompanyNameText.Value = CompanyInformation.CompanyName
        CompanyAddressText.Value = CompanyInformation.Address & ", " & CompanyInformation.City
        If pubIsDemo = True Then
            CompanyPhoneText.Value = "=Demo Version="
        Else
            CompanyPhoneText.Value = "Phone : " & CompanyInformation.Phone & "    Fax : " & CompanyInformation.Fax
        End If
    End Sub

End Class
