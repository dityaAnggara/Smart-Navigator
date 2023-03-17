Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class Make_Bill_Payment58
    Public Shared TransactionUID As String = ""

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim DataPoint As New DataSet
        Dim SubItem = New ActiveReport3
        Dim Query As String

        SubItem = New Payment58
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

        SubItem = Nothing

        Dim myMakeBill As New Make_Bill58
        If MainPage.InvoiceApplication = True Then
            myMakeBill.SelectedTableName = ""
        Else
            myMakeBill.SelectedTableName = "TABLE : " & SelectedTable.TableName
        End If
        myMakeBill.ShowPreSettledBill = False
        myMakeBill.BillTableTxt.Visible = True

        Query = "SELECT a.MBTRANSUID, a.MBTRANSNO, a.MBTRANSDATE, a.MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME," & _
                "a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID, a.MBTRANSRSVTRANSUID, a.MBTRANSSUBVAL," & _
                "a.MBTRANSDISCPERC, a.MBTRANSDISCVAL, a.MBTRANSTAXVAL1, a.MBTRANSTAXVAL2, a.MBTRANSDPVAL," & _
                "a.MBTRANSTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT,a.CREATEDUSER," & _
                "a.MODIFIEDUSER,a.MODIFIEDDATETIME, b.TABLELISTNAME," & _
                "(SELECT CUSTNO FROM CUST WHERE CUSTUID = a.MBTRANSCUSTUID) AS CUSTNO," & _
                "(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = a.MBTRANSSERVICETYPEUID ) AS SERVICENAME," & _
                "(SELECT SUM((M.MBTRANSDTITEMPRICE * M.MBTRANSDTITEMQTY)-M.MBTRANSDTITEMDISCVAL1-M.MBTRANSDTITEMDISCVAL2) FROM MBTRANSDT M LEFT OUTER JOIN INVEN I ON I.INVENUID=M.MBTRANSDTITEMUID LEFT OUTER JOIN INVENCAT IC ON IC.INVENCATUID=I.INVENCATUID WHERE M.MBTRANSDTITEMSTAT > -1 AND IC.INVENCATSUBCATEGORYID=1 AND M.MBTRANSUID=a.MBTRANSUID) AS SUBTOTALFOOD," & _
                "(SELECT SUM((M.MBTRANSDTITEMPRICE * M.MBTRANSDTITEMQTY)-M.MBTRANSDTITEMDISCVAL1-M.MBTRANSDTITEMDISCVAL2) FROM MBTRANSDT M LEFT OUTER JOIN INVEN I ON I.INVENUID=M.MBTRANSDTITEMUID LEFT OUTER JOIN INVENCAT IC ON IC.INVENCATUID=I.INVENCATUID WHERE M.MBTRANSDTITEMSTAT > -1 AND IC.INVENCATSUBCATEGORYID=2 AND M.MBTRANSUID=a.MBTRANSUID) AS SUBTOTALBEVERAGE," & _
                "(SELECT SUM((M.MBTRANSDTITEMPRICE * M.MBTRANSDTITEMQTY)-M.MBTRANSDTITEMDISCVAL1-M.MBTRANSDTITEMDISCVAL2) FROM MBTRANSDT M LEFT OUTER JOIN INVEN I ON I.INVENUID=M.MBTRANSDTITEMUID LEFT OUTER JOIN INVENCAT IC ON IC.INVENCATUID=I.INVENCATUID WHERE M.MBTRANSDTITEMSTAT > -1 AND IC.INVENCATSUBCATEGORYID=3 AND M.MBTRANSUID=a.MBTRANSUID) AS SUBTOTALMENUETC " & _
                "FROM MBTRANS a LEFT OUTER JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE a.MBTRANSUID = '" & TransactionUID & "'"

        DataPoint = MyDatabase.MyAdapter(Query)

        Me.SubReport1.Report = myMakeBill
        Me.SubReport1.Report.DataSource = DataPoint
        Me.SubReport1.Report.DataMember = DataPoint.Tables(0).TableName

        myMakeBill = Nothing

    End Sub

    Private Sub Make_Bill_Payment_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        publicUseChange = False
        publicPayment1 = ""
        publicPayment2 = ""
        publicPayment3 = ""
        publicPayment4 = ""
        publicPayment5 = ""
        publicPaymentChange = ""
        publicPaymentRest = ""
    End Sub

    Private Sub Make_Bill_Payment_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        If CDec(publicPaymentRest) = 0 Then
            txtChange.Text = FormatNumber(CDec(publicPaymentChange), DijitKoma)
            Label1.Text = "Change"
        Else
            txtChange.Text = FormatNumber(CDec(publicPaymentRest), DijitKoma)
            Label1.Text = "Rest"
        End If
    End Sub
End Class
