Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports System.Drawing.Printing
Imports FirebirdSql.Data.FirebirdClient

Public Class Make_Bill_Room
    Public HSubItem As Double
    Public TotalDisc As Double
    Public ShowPreSettledBill As Boolean
    Public SelectedTableName As String

    Private Sub Make_Bill_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Me.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF")
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
        lblOverPax.Value = FormatNumber(lblOverPax.Value, 2)
        TransactionDateLabel.Value = Format(TransactionDateLabel.Value, "dd/MM/yyyy hh:mm tt")
        'If PrefInfo.isInvisibleCode = "1" Then
        '    BillNoLabel.Value = ""
        'Else
        BillNoLabel.Value = "NO : " & BillNoLabel.Value
        'End If
        BillPaxLabel.Value = "PAX : " & BillPaxLabel.Value
        BillTotalDiscLabel.Value = "-" & BillTotalDiscLabel.Value
        lblShiftNo.Text = "SHIFT : " & IIf(lblShiftNo.Text = "1" Or lblShiftNo.Text = "3", "1", "2")
        lblTotalFree.Value = "FREE : " & lblTotalFree.Value & " MINUTES"
        txtCheckINOut.Value = "CHECK IN/OUT : " & Format(txtCheckIn.Value, "HH:mm") & " - " & Format(txtCheckOut.Value, "HH:mm")
        CurrentDateLabel.Value = Format(Now, "dd/MM/yyyy hh:mm tt")
        BillPrintUserLabel.Value = UserInformation.UserName
        BillCreatedUserLabel.Value = "OP : " & BillCreatedUserLabel.Value

        If IsDBNull(BillTotalDiscLabel.Value) Then
            TotalDisc = BillTotalDiscLabel.Value
            BillTotalDiscLabel.Value = "0.00"
        Else
            TotalDisc = BillTotalDiscLabel.Value
            BillTotalDiscLabel.Value = FormatNumber(BillTotalDiscLabel.Text, DijitKoma, , , TriState.True)
        End If

        Dim DataPoint As New DataSet
        Dim SubItem = New ActiveReport3
        Dim Query As String

        SubItem = New Make_Bill_Sub_Item_Room

        Query = "SELECT B.* FROM MBTRANS A INNER JOIN MBTRANSROOMDT B ON A.MBTRANSUID=B.MBTRANSUID WHERE A.MBTRANSUID = '" & Label33.Text & "'"

        DataPoint = MyDatabase.MyAdapter(Query)

        Me.SubReport1.Report = SubItem
        Me.SubReport1.Report.DataSource = DataPoint
        Me.SubReport1.Report.DataMember = DataPoint.Tables(0).TableName

        LabelSC.Value = PrefInfo.RentTax1Name & " :"
        LabelPPN.Value = PrefInfo.RentTax2Name & " :"
    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        CompanyNameText.Value = DeptInfo.DepName
        CompanyAddressText.Value = DeptInfo.DeptAddress & ", " & DeptInfo.DeptCity
        CompanyPhoneText.Value = "Phone : " & DeptInfo.DeptPhone & "    Fax : " & DeptInfo.DeptFax
        If ShowPreSettledBill Then
            HeaderMsg.Text = "** PRE-SETTLED BILL **"
        Else
            '18 Juni 2012 : Weird, tidak tau kenapa kalo tanpa cara dibawah, table namenya tidak keluar
            If UCase(Strings.Left(SelectedTableName, 7)) = "TABLE :" Then
                HeaderMsg.Text = PrefInfo.Header & vbNewLine & vbNewLine & SelectedTableName
            Else
                HeaderMsg.Text = PrefInfo.Header
            End If
        End If
    End Sub

    Private Sub ReportFooter1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportFooter1.Format
    
        Dim GrandTotal As Decimal = 0

        GrandTotal = Val(BillSubTotalLabel.Text) + Val(TotalDisc) + Val(BillPPNLabel.Text) - Val(BillDPLabel.Text)

        BillTotalDiscLabel.Value = FormatNumber(BillTotalDiscLabel.Text, DijitKoma, , , TriState.True)
        BillDPLabel.Value = FormatNumber(BillDPLabel.Text, DijitKoma, , , TriState.True)
        TotalNetLabel.Value = FormatNumber(TotalNetLabel.Text, DijitKoma, , , TriState.True) 'FormatNumber(GrandTotal, 2, , , TriState.True)
        BillPPNLabel.Value = FormatNumber(BillPPNLabel.Text, DijitKoma)
        BillSCLabel.Value = FormatNumber(BillSCLabel.Text, DijitKoma)

        BillSubTotalLabel.Value = FormatNumber(CDec(BillSubTotalLabel.Text) + CDec(BillTotalDiscLabel.Text), DijitKoma, , , TriState.True)
        lblTotalFNB.Value = FormatNumber(lblTotalFNB.Value, DijitKoma)
        lblGrandTotal.Value = FormatNumber(lblGrandTotal.Value, DijitKoma)

        FooterMsg.Text = PrefInfo.Footer       

        If PrefInfo.RentTax1Active = True Then
            LabelSC.Visible = True : BillSCLabel.Visible = True
        Else
            LabelSC.Visible = False : BillSCLabel.Visible = False
        End If

        If PrefInfo.RentTax2Active = True Then
            LabelPPN.Visible = True : BillPPNLabel.Visible = True
        Else
            LabelPPN.Visible = False : BillPPNLabel.Visible = False
        End If
        
        LabelDP.Visible = True : BillDPLabel.Visible = True

        Dim rs As FbDataReader
        rs = MyDatabase.MyReader("SELECT COUNT(SALESPROMOREGPROMOUID) FROM SALESPROMOREG WHERE SALESPROMOREGTRANSUID= '" & Label33.Text & "'")
        If rs.Read() = True Then
            If CInt(rs(0)) = 0 Then
                SubReport2.Visible = False
            Else
                Dim DataPoint As New DataSet
                Dim SubItem = New ActiveReport3
                Dim Query As String

                SubItem = New Make_Bill_Room_Gift

                Query = "SELECT SALESPROMOREGPROMOQTY,PROMONAME,PROMOISBARCODESUPPORT,SALESPROMOREGPROMOGENERATEDNO,CAST(SALESPROMOREGPROMOEXPIREDDATE AS DATE) AS SALESPROMOREGPROMOEXPIREDDATE FROM SALESPROMOREG INNER JOIN PROMO ON SALESPROMOREGPROMOUID=PROMOUID WHERE  SALESPROMOREGTRANSUID= '" & Label33.Text & "'"

                DataPoint = MyDatabase.MyAdapter(Query)

                Me.SubReport2.Report = SubItem
                Me.SubReport2.Report.DataSource = DataPoint
                Me.SubReport2.Report.DataMember = DataPoint.Tables(0).TableName
            End If
        End If
            rs = Nothing
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        If BillTableTxt.Visible = False Then
            PageHeader1.Height = 0
        End If
    End Sub
End Class
