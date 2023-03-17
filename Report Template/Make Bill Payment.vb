Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports FirebirdSql.Data.FirebirdClient

Public Class Make_Bill_Payment
  Public Shared TransactionUID As String = ""
  Public Shared CheckSaldoPart As String = "False"
  Public Shared CardNo As String = ""
  Public Shared Tangg As String = ""

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
    Dim DataPoint As New DataSet
    Dim SubItem = New ActiveReport3
    Dim Query As String

    'If CheckSaldoPart = "True" Then
    '  Dim TMPRecord As FbDataReader
    '  Dim Ak As String
    '  TMPRecord = MyDatabase.MyReader("SELECT PB.PBTRANSMBTRANSUID AS PBUID,SUM(MBD.MBTRANSDTITEMQTY) AS Qty FROM CUST CT LEFT OUTER JOIN PBTRANSDT PBD ON CT.CUSTNO = PBD.VISAORCHEQUENUMBER LEFT OUTER JOIN PBTRANS PB ON PBD.PBTRANSUID = PB.PBTRANSUID LEFT OUTER JOIN MBTRANS MB ON PB.PBTRANSMBTRANSUID = MB.MBTRANSUID LEFT OUTER JOIN MBTRANSDT MBD ON MB.MBTRANSUID = MBD.MBTRANSUID LEFT OUTER JOIN PAYMENTTYPE PT ON PBD.PAYMENTTYPEUID = PT.PAYMENTTYPEUID WHERE CT.CUSTNO = '" & CardNo & "' AND PBD.MODIFIEDDATETIME BETWEEN '" & Tangg & ", 00:00:00' AND '" & Tangg & ", 23:59:59' GROUP BY PB.PBTRANSMBTRANSUID")

    '  While TMPRecord.Read()
    '    Ak = TMPRecord.Item("PBUID")
    '    SubItem = New Payment
    '    Query = "SELECT PB.PBTRANSUID, PB.PBTRANSNO, PB.PBTRANSDATE, PB.PBTRANSMBTRANSUID, PB.PBTRANSMODULETYPEID, " & _
    '    "MB.MBTRANSNO, MB.MBTRANSDATE, MB.MBTRANSSUBVAL,MB.MBTRANSPAXVAL,PB.PBTRANSCUSTUID, " & _
    '    "C.CUSTNAME AS SELECTEDCUSTNAME, PB.PBTRANSCUSTNAME, PB.PBTRANSTABLELISTUID, T.TABLELISTNAME AS SELECTEDTABLELISTNAME, " & _
    '    "PB.PBTRANSTOTVAL AS PAY,PB.PRINTCOUNTER,PB.ISFISCAL,PB.CREATEDUSER,PB.MODIFIEDUSER " & _
    '    "FROM PBTRANS PB " & _
    '    "LEFT OUTER JOIN MBTRANS MB ON PB.PBTRANSMBTRANSUID = MB.MBTRANSUID " & _
    '    "LEFT OUTER JOIN TABLELIST T ON T.TABLELISTUID=PB.PBTRANSTABLELISTUID " & _
    '    "LEFT OUTER JOIN CUST C ON C.CUSTUID=PB.PBTRANSCUSTUID " & _
    '    "WHERE PB.PBTRANSSTAT <> -1 AND PB.PBTRANSMODULETYPEID='2206' AND PB.PBTRANSMBTRANSUID = '" & Ak & "'"

    '    DataPoint = MyDatabase.MyAdapter(Query)

    '    Me.SubReport2.Report = SubItem
    '    Me.SubReport2.Report.DataSource = DataPoint
    '    Me.SubReport2.Report.DataMember = DataPoint.Tables(0).TableName

    '    SubItem = Nothing

    '    Dim myMakeBill As New Make_Bill
    '    If MainPage.InvoiceApplication = True Then
    '      myMakeBill.SelectedTableName = ""
    '    Else
    '      myMakeBill.SelectedTableName = "TABLE : " & SelectedTable.TableName
    '    End If
    '    myMakeBill.ShowPreSettledBill = False
    '    myMakeBill.BillTableTxt.Visible = True

    '    Query = "SELECT a.MBTRANSUID, a.MBTRANSNO, a.MBTRANSDATE, a.MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME," & _
    '            "a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID, a.MBTRANSRSVTRANSUID, a.MBTRANSSUBVAL," & _
    '            "a.MBTRANSDISCPERC, a.MBTRANSDISCVAL, a.MBTRANSTAXVAL1, a.MBTRANSTAXVAL2, IIF(a.MBTRANSROUNDINGVAL IS NULL,0,a.MBTRANSROUNDINGVAL) AS MBTRANSROUNDINGVAL, a.MBTRANSDPVAL," & _
    '            "a.MBTRANSTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT,a.CREATEDUSER," & _
    '            "a.MODIFIEDUSER,a.MODIFIEDDATETIME, b.TABLELISTNAME," & _
    '            "(SELECT CUSTNO FROM CUST WHERE CUSTUID = a.MBTRANSCUSTUID) AS CUSTNO," & _
    '            "(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = a.MBTRANSSERVICETYPEUID ) AS SERVICENAME," & _
    '            "(SELECT SUM((M.MBTRANSDTITEMPRICE * M.MBTRANSDTITEMQTY)-M.MBTRANSDTITEMDISCVAL1-M.MBTRANSDTITEMDISCVAL2) FROM MBTRANSDT M LEFT OUTER JOIN INVEN I ON I.INVENUID=M.MBTRANSDTITEMUID LEFT OUTER JOIN INVENCAT IC ON IC.INVENCATUID=I.INVENCATUID WHERE M.MBTRANSDTITEMSTAT > -1 AND IC.INVENCATSUBCATEGORYID=1 AND M.MBTRANSUID=a.MBTRANSUID) AS SUBTOTALFOOD," & _
    '            "(SELECT SUM((M.MBTRANSDTITEMPRICE * M.MBTRANSDTITEMQTY)-M.MBTRANSDTITEMDISCVAL1-M.MBTRANSDTITEMDISCVAL2) FROM MBTRANSDT M LEFT OUTER JOIN INVEN I ON I.INVENUID=M.MBTRANSDTITEMUID LEFT OUTER JOIN INVENCAT IC ON IC.INVENCATUID=I.INVENCATUID WHERE M.MBTRANSDTITEMSTAT > -1 AND IC.INVENCATSUBCATEGORYID=2 AND M.MBTRANSUID=a.MBTRANSUID) AS SUBTOTALBEVERAGE," & _
    '            "(SELECT SUM((M.MBTRANSDTITEMPRICE * M.MBTRANSDTITEMQTY)-M.MBTRANSDTITEMDISCVAL1-M.MBTRANSDTITEMDISCVAL2) FROM MBTRANSDT M LEFT OUTER JOIN INVEN I ON I.INVENUID=M.MBTRANSDTITEMUID LEFT OUTER JOIN INVENCAT IC ON IC.INVENCATUID=I.INVENCATUID WHERE M.MBTRANSDTITEMSTAT > -1 AND IC.INVENCATSUBCATEGORYID=3 AND M.MBTRANSUID=a.MBTRANSUID) AS SUBTOTALMENUETC " & _
    '            "FROM MBTRANS a LEFT OUTER JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE a.MBTRANSUID = '" & Ak & "'"

    '    DataPoint = MyDatabase.MyAdapter(Query)

    '    Me.SubReport1.Report = myMakeBill
    '    Me.SubReport1.Report.DataSource = DataPoint
    '    Me.SubReport1.Report.DataMember = DataPoint.Tables(0).TableName

    '    myMakeBill = Nothing
    '  End While
    'Else
    '  SubItem = New Payment
    '  Query = "SELECT PB.PBTRANSUID, PB.PBTRANSNO, PB.PBTRANSDATE, PB.PBTRANSMBTRANSUID, PB.PBTRANSMODULETYPEID, " & _
    '  "MB.MBTRANSNO, MB.MBTRANSDATE, MB.MBTRANSSUBVAL,MB.MBTRANSPAXVAL,PB.PBTRANSCUSTUID, " & _
    '  "C.CUSTNAME AS SELECTEDCUSTNAME, PB.PBTRANSCUSTNAME, PB.PBTRANSTABLELISTUID, T.TABLELISTNAME AS SELECTEDTABLELISTNAME, " & _
    '  "PB.PBTRANSTOTVAL AS PAY,PB.PRINTCOUNTER,PB.ISFISCAL,PB.CREATEDUSER,PB.MODIFIEDUSER " & _
    '  "FROM PBTRANS PB " & _
    '  "LEFT OUTER JOIN MBTRANS MB ON PB.PBTRANSMBTRANSUID = MB.MBTRANSUID " & _
    '  "LEFT OUTER JOIN TABLELIST T ON T.TABLELISTUID=PB.PBTRANSTABLELISTUID " & _
    '  "LEFT OUTER JOIN CUST C ON C.CUSTUID=PB.PBTRANSCUSTUID " & _
    '  "WHERE PB.PBTRANSSTAT <> -1 AND PB.PBTRANSMODULETYPEID='2206' AND PB.PBTRANSMBTRANSUID = '" & TransactionUID & "'"

    '  DataPoint = MyDatabase.MyAdapter(Query)

    '  Me.SubReport2.Report = SubItem
    '  Me.SubReport2.Report.DataSource = DataPoint
    '  Me.SubReport2.Report.DataMember = DataPoint.Tables(0).TableName

    '  SubItem = Nothing

    '  Dim myMakeBill As New Make_Bill
    '  If MainPage.InvoiceApplication = True Then
    '    myMakeBill.SelectedTableName = ""
    '  Else
    '    myMakeBill.SelectedTableName = "TABLE : " & SelectedTable.TableName
    '  End If
    '  myMakeBill.ShowPreSettledBill = False
    '  myMakeBill.BillTableTxt.Visible = True

    '  Query = "SELECT a.MBTRANSUID, a.MBTRANSNO, a.MBTRANSDATE, a.MBTRANSPAXVAL, a.MBTRANSCUSTUID, a.MBTRANSCUSTNAME," & _
    '          "a.MBTRANSTABLELISTUID, a.MBTRANSSERVICETYPEUID, a.MBTRANSRSVTRANSUID, a.MBTRANSSUBVAL," & _
    '          "a.MBTRANSDISCPERC, a.MBTRANSDISCVAL, a.MBTRANSTAXVAL1, a.MBTRANSTAXVAL2, IIF(a.MBTRANSROUNDINGVAL IS NULL,0,a.MBTRANSROUNDINGVAL) AS MBTRANSROUNDINGVAL, a.MBTRANSDPVAL," & _
    '          "a.MBTRANSTOTVAL, a.MBTRANSDESC, a.MBTRANSPAIDVAL, a.MBTRANSSTAT,a.CREATEDUSER," & _
    '          "a.MODIFIEDUSER,a.MODIFIEDDATETIME, b.TABLELISTNAME," & _
    '          "(SELECT CUSTNO FROM CUST WHERE CUSTUID = a.MBTRANSCUSTUID) AS CUSTNO," & _
    '          "(SELECT SERVICETYPENAME FROM SERVICETYPE WHERE SERVICETYPEUID = a.MBTRANSSERVICETYPEUID ) AS SERVICENAME," & _
    '          "(SELECT SUM((M.MBTRANSDTITEMPRICE * M.MBTRANSDTITEMQTY)-M.MBTRANSDTITEMDISCVAL1-M.MBTRANSDTITEMDISCVAL2) FROM MBTRANSDT M LEFT OUTER JOIN INVEN I ON I.INVENUID=M.MBTRANSDTITEMUID LEFT OUTER JOIN INVENCAT IC ON IC.INVENCATUID=I.INVENCATUID WHERE M.MBTRANSDTITEMSTAT > -1 AND IC.INVENCATSUBCATEGORYID=1 AND M.MBTRANSUID=a.MBTRANSUID) AS SUBTOTALFOOD," & _
    '          "(SELECT SUM((M.MBTRANSDTITEMPRICE * M.MBTRANSDTITEMQTY)-M.MBTRANSDTITEMDISCVAL1-M.MBTRANSDTITEMDISCVAL2) FROM MBTRANSDT M LEFT OUTER JOIN INVEN I ON I.INVENUID=M.MBTRANSDTITEMUID LEFT OUTER JOIN INVENCAT IC ON IC.INVENCATUID=I.INVENCATUID WHERE M.MBTRANSDTITEMSTAT > -1 AND IC.INVENCATSUBCATEGORYID=2 AND M.MBTRANSUID=a.MBTRANSUID) AS SUBTOTALBEVERAGE," & _
    '          "(SELECT SUM((M.MBTRANSDTITEMPRICE * M.MBTRANSDTITEMQTY)-M.MBTRANSDTITEMDISCVAL1-M.MBTRANSDTITEMDISCVAL2) FROM MBTRANSDT M LEFT OUTER JOIN INVEN I ON I.INVENUID=M.MBTRANSDTITEMUID LEFT OUTER JOIN INVENCAT IC ON IC.INVENCATUID=I.INVENCATUID WHERE M.MBTRANSDTITEMSTAT > -1 AND IC.INVENCATSUBCATEGORYID=3 AND M.MBTRANSUID=a.MBTRANSUID) AS SUBTOTALMENUETC " & _
    '          "FROM MBTRANS a LEFT OUTER JOIN TABLELIST b ON b.TABLELISTUID = a.MBTRANSTABLELISTUID WHERE a.MBTRANSUID = '" & TransactionUID & "'"

    '  DataPoint = MyDatabase.MyAdapter(Query)

    '  Me.SubReport1.Report = myMakeBill
    '  Me.SubReport1.Report.DataSource = DataPoint
    '  Me.SubReport1.Report.DataMember = DataPoint.Tables(0).TableName

    '  myMakeBill = Nothing
    'End If

    SubItem = New Payment
    Query = "select pb.pbtransuid, pb.pbtransno, pb.pbtransdate, pb.pbtransmbtransuid, pb.pbtransmoduletypeid, " & _
    "mb.mbtransno, mb.mbtransdate, mb.mbtranssubval,mb.mbtranspaxval,pb.pbtranscustuid, " & _
    "c.custname as selectedcustname, pb.pbtranscustname, pb.pbtranstablelistuid, t.tablelistname as selectedtablelistname, " & _
    "pb.pbtranstotval as pay,pb.printcounter,pb.isfiscal,pb.createduser,pb.modifieduser " & _
    "from pbtrans pb " & _
    "left outer join mbtrans mb on pb.pbtransmbtransuid = mb.mbtransuid " & _
    "left outer join tablelist t on t.tablelistuid=pb.pbtranstablelistuid " & _
    "left outer join cust c on c.custuid=pb.pbtranscustuid " & _
    "where pb.pbtransstat <> -1 and pb.pbtransmoduletypeid='2206' and pb.pbtransmbtransuid = '" & TransactionUID & "'"

    DataPoint = MyDatabase.MyAdapter(Query)

    Me.SubReport2.Report = SubItem
    Me.SubReport2.Report.DataSource = DataPoint
    Me.SubReport2.Report.DataMember = DataPoint.Tables(0).TableName

    SubItem = Nothing

    Dim mymakebill As New Make_Bill
    If MainPage.InvoiceApplication = True Then
      mymakebill.SelectedTableName = ""
    Else
      mymakebill.SelectedTableName = "table : " & SelectedTable.TableName
    End If
    mymakebill.ShowPreSettledBill = False
    mymakebill.BillTableTxt.Visible = True

    Query = "select a.mbtransuid, a.mbtransno, a.mbtransdate, a.mbtranspaxval, a.mbtranscustuid, a.mbtranscustname," & _
            "a.mbtranstablelistuid, a.mbtransservicetypeuid, a.mbtransrsvtransuid, a.mbtranssubval," & _
            "a.mbtransdiscperc, a.mbtransdiscval, a.mbtranstaxval1, a.mbtranstaxval2, iif(a.mbtransroundingval is null,0,a.mbtransroundingval) as mbtransroundingval, a.mbtransdpval," & _
            "a.mbtranstotval, a.mbtransdesc, a.mbtranspaidval, a.mbtransstat,a.createduser," & _
            "a.modifieduser,a.modifieddatetime, b.tablelistname," & _
            "(select custno from cust where custuid = a.mbtranscustuid) as custno," & _
            "(select servicetypename from servicetype where servicetypeuid = a.mbtransservicetypeuid ) as servicename," & _
            "(select sum((m.mbtransdtitemprice * m.mbtransdtitemqty)-m.mbtransdtitemdiscval1-m.mbtransdtitemdiscval2) from mbtransdt m left outer join inven i on i.invenuid=m.mbtransdtitemuid left outer join invencat ic on ic.invencatuid=i.invencatuid where m.mbtransdtitemstat > -1 and ic.invencatsubcategoryid=1 and m.mbtransuid=a.mbtransuid) as subtotalfood," & _
            "(select sum((m.mbtransdtitemprice * m.mbtransdtitemqty)-m.mbtransdtitemdiscval1-m.mbtransdtitemdiscval2) from mbtransdt m left outer join inven i on i.invenuid=m.mbtransdtitemuid left outer join invencat ic on ic.invencatuid=i.invencatuid where m.mbtransdtitemstat > -1 and ic.invencatsubcategoryid=2 and m.mbtransuid=a.mbtransuid) as subtotalbeverage," & _
            "(select sum((m.mbtransdtitemprice * m.mbtransdtitemqty)-m.mbtransdtitemdiscval1-m.mbtransdtitemdiscval2) from mbtransdt m left outer join inven i on i.invenuid=m.mbtransdtitemuid left outer join invencat ic on ic.invencatuid=i.invencatuid where m.mbtransdtitemstat > -1 and ic.invencatsubcategoryid=3 and m.mbtransuid=a.mbtransuid) as subtotalmenuetc " & _
            "from mbtrans a left outer join tablelist b on b.tablelistuid = a.mbtranstablelistuid where a.mbtransuid = '" & TransactionUID & "'"

    DataPoint = MyDatabase.MyAdapter(Query)

    Me.SubReport1.Report = mymakebill
    Me.SubReport1.Report.DataSource = DataPoint
    Me.SubReport1.Report.DataMember = DataPoint.Tables(0).TableName

    mymakebill = Nothing


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
    ElseIf CDec(publicPaymentRest) <= 0 Then
      txtChange.Visible = False
      Line1.Visible = False
      Label1.Visible = False
    Else
      txtChange.Text = FormatNumber(CDec(publicPaymentRest), DijitKoma)
      Label1.Text = "Rest"
        End If
    End Sub
End Class
