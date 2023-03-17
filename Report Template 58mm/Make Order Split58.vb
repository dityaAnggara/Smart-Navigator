Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports FirebirdSql.Data.FirebirdClient

Public Class Make_Order_Split58

    Public Shared pubQueryLap As String
    Public Shared pubHarusCetakNotes As Boolean = False

    Private Sub Make_Order_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd
        pubQueryLap = ""
    End Sub

    Private Sub Make_Order_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        'If PrefInfo.invNota = "1" Then MakeOrderTransNoLabel.Visible = False
        Me.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF")
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format


        If MainPage.InvoiceApplication = False Then
            MakeOrderTableLabel.Value = "TABLE : " & MakeOrderTableLabel.Value
        Else
            MakeOrderTableLabel.Value = "CUST : " & publicCustomerNameInvoiceApplication
        End If

        MakeOrderPrintUserLabel.Value = UserInformation.UserName
        CurrentDateLabel.Value = Format(Now, "dd/MM/yyyy JJ:mm")

        Dim DataPoint As New DataSet
        Dim SubItem = New ActiveReport3
        Dim Query As String

        SubItem = New Make_Order_Sub_Item_Split58
        'Query = "SELECT a.MBTRANSDTITEMNAME, a.MBTRANSDTITEMQTY FROM MBTRANSDT a WHERE MBTRANSUID ='" & Label33.Text & "' AND a.PRINT=1"
        If Trim(pubQueryLap) = "" Then
            Query = "SELECT a.MBTRANSDTISTAKEAWAY, a.MBTRANSDTITEMNOTE, a.MBTRANSDTUID, a.MBTRANSDTITEMNAME, a.MBTRANSDTITEMQTY,b.MBTRANSDTITEMNAME AS DETAILITEM,b.MBTRANSDTITEMQTY AS DETAILQTY " & _
                    "FROM MBTRANSDT a LEFT OUTER JOIN MBTRANSDTDETAIL b ON b.MBTRANSDTUID=a.MBTRANSDTUID " & _
                    "WHERE MBTRANSUID ='" & Label33.Text & "' AND a.PRINT=1"
            DataPoint = MyDatabase.MyAdapter(Query)
            Make_Order_Sub_Item_Split58.publicMustPrintNotes = False
        Else
            DataPoint = MyDatabase.MyAdapter(pubQueryLap)
            Make_Order_Sub_Item_Split58.publicMustPrintNotes = pubHarusCetakNotes
        End If

        Me.SubReport1.Report = SubItem
        Me.SubReport1.Report.DataSource = DataPoint
        Me.SubReport1.Report.DataMember = DataPoint.Tables(0).TableName

        'Anjo - 12 Jan 2012 : Dibawah ini dicomment semenjak ada kitchen print-out
        'Query = "UPDATE MBTRANSDT SET PRINT=0 WHERE MBTRANSUID ='" & Label33.Text & "'"
        'Call MyDatabase.MyAdapter(Query)
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        CompanyNameText.Value = IIf(pubIsDemo = True, "=Demo Version=", CompanyInformation.CompanyName)
        CompanyAddressText.Value = CompanyInformation.Address & ", " & CompanyInformation.City
        CompanyPhoneText.Value = "Phone : " & CompanyInformation.Phone & "    Fax : " & CompanyInformation.Fax
    End Sub

End Class
