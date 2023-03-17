Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class Payment 

    Private Sub Payment_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        If PrefInfo.invNota = "1" Then PaymentNoLabel.Visible = False
        Me.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF")
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        Dim DataPoint As New DataSet
        Dim SubItem = New ActiveReport3
        Dim Query As String

        SubItem = New Payment_Sub_Payment

        Query = "SELECT PBDT.PBTRANSDTUID, PBDT.PBTRANSUID, PBDT.PAYMENTTYPEUID, P.PAYMENTTYPENAME, " & _
        "P.ISCREDITCARDORCHEQUE, PBDT.VISAORCHEQUENUMBER, PBDT.VISAORCHEQUENAME, " & _
        "PBDT.VISAORCHEQUEBANKNAME, PBDT.PBTRANSDTSUBVAL " & _
        "FROM PBTRANSDT PBDT LEFT OUTER JOIN PAYMENTTYPE P ON PBDT.PAYMENTTYPEUID = P.PAYMENTTYPEUID " & _
        "WHERE PBDT.PBTRANSUID ='" & Label35.Text & "'"

        DataPoint = MyDatabase.MyAdapter(Query)

        Me.SubReport2.Report = SubItem
        Me.SubReport2.Report.DataSource = DataPoint
        Me.SubReport2.Report.DataMember = DataPoint.Tables(0).TableName

    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        PaymentNoLabel.Value = "NO : " & PaymentNoLabel.Value
        PaymentCreatedDateLabel.Value = Format(PaymentCreatedDateLabel.Value, "dd/MM/yyyy hh:mm tt")
    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        If Len(Trim(PaymentTableLabel.Value)) > 0 Or MainPage.InvoiceApplication = False Then
            PaymentTableLabel.Value = "TABLE : " & PaymentTableLabel.Value
        Else
            PaymentTableLabel.Value = ""
        End If
        PaymentPrinterCounterLabel.Value = "NO PRINT : " & PaymentPrinterCounterLabel.Value
    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
        PaymentPrintUserLabel.Value = IIf(pubIsDemo = True, "Demo Version", UserInformation.UserName)
        CurrentDateLabel.Value = Format(Now, "dd/MM/yyyy hh:mm tt")
    End Sub
End Class
