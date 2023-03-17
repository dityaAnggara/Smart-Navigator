Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class Make_Payment_Change
    Public Shared TransactionUID As String = ""

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim DataPoint As New DataSet
        Dim SubItem = New ActiveReport3
        Dim Query As String

        SubItem = New Payment
        Query = "SELECT PB.PBTRANSUID, PB.PBTRANSNO, PB.PBTRANSDATE, PB.PBTRANSMBTRANSUID, PB.PBTRANSMODULETYPEID, " & _
        "MB.MBTRANSNO, MB.MBTRANSDATE, MB.MBTRANSSUBVAL,MB.MBTRANSPAXVAL,PB.PBTRANSCUSTUID, " & _
        "C.CUSTNAME AS SELECTEDCUSTNAME, PB.PBTRANSCUSTNAME, PB.PBTRANSTABLELISTUID, T.TABLELISTNAME AS SELECTEDTABLELISTNAME, " & _
        "PB.PBTRANSTOTVAL AS PAY,PB.PRINTCOUNTER,PB.ISFISCAL,PB.CREATEDUSER,PB.MODIFIEDUSER " & _
        "FROM PBTRANS PB " & _
        "LEFT OUTER JOIN MBTRANS MB ON PB.PBTRANSMBTRANSUID = MB.MBTRANSUID " & _
        "LEFT OUTER JOIN TABLELIST T ON T.TABLELISTUID=PB.PBTRANSTABLELISTUID " & _
        "LEFT OUTER JOIN CUST C ON C.CUSTUID=PB.PBTRANSCUSTUID " & _
        "WHERE PB.PBTRANSSTAT <> -1 AND PB.PBTRANSMODULETYPEID='2206' AND PB.PBTRANSMBTRANSUID = '" & TransactionUID & "'"

        DataPoint = MyDatabase.MyAdapter(Query)

        Me.SubReport2.Report = SubItem
        Me.SubReport2.Report.DataSource = DataPoint
        Me.SubReport2.Report.DataMember = DataPoint.Tables(0).TableName
    End Sub

    Private Sub Make_Payment_Change_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        publicUseChange = False
        publicPayment1 = ""
        publicPayment2 = ""
        publicPayment3 = ""
        publicPayment4 = ""
        publicPayment5 = ""
        publicPaymentChange = ""
        publicPaymentRest = ""
    End Sub

    Private Sub Make_Payment_Change_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        If CDec(publicPaymentRest) = 0 Then
            txtChange.Text = FormatNumber(CDec(publicPaymentChange), DijitKoma)
            Label1.Text = "Change"
        Else
            txtChange.Text = FormatNumber(CDec(publicPaymentRest), DijitKoma)
            Label1.Text = "Rest"
        End If
    End Sub

End Class
