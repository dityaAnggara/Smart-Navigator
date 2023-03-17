Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports System.Drawing.Printing
Imports FirebirdSql.Data.FirebirdClient

Public Class Make_Bill58
    Public HSubItem As Double
    Public TotalDisc As Double
    Public ShowPreSettledBill As Boolean
    Public SelectedTableName As String

    Private Sub Make_Bill_PageEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.PageEnd
        'srLogo.Dispose()
    End Sub

    Private Sub Make_Bill_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        If PrefInfo.invNota = "1" Then BillNoLabel.Visible = False
        Me.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF")
    End Sub

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format

        If PrefInfo.PrintSubTotalCategory = 1 Then
            LabelSubTotalBeverage.Visible = True
            LabelSubTotalFoods.Visible = True
            LabelSubTotalMenuEtc.Visible = True
            SubTotalBeverage.Visible = True
            SubTotalFood.Visible = True
            SubTotalMenuEtc.Visible = True
            LineSubTotalMenu.Visible = True
            Detail1.Height = 1.948
        Else
            LabelSubTotalBeverage.Visible = False
            LabelSubTotalFoods.Visible = False
            LabelSubTotalMenuEtc.Visible = False
            SubTotalBeverage.Visible = False
            SubTotalFood.Visible = False
            SubTotalMenuEtc.Visible = False
            LineSubTotalMenu.Visible = False
            Detail1.Height = 1.2
        End If

        TransactionDateLabel.Value = Format(TransactionDateLabel.Value, "dd/MM/yyyy HH:mm")
        BillNoLabel.Value = "NO : " & BillNoLabel.Value
        BillPaxLabel.Value = "PAX : " & BillPaxLabel.Value
        BillTotalDiscLabel.Value = "-" & BillTotalDiscLabel.Value

        CurrentDateLabel.Value = Format(Now, "dd/MM/yyyy HH:mm")
        BillPrintUserLabel.Value = UserInformation.UserName
        BillCreatedUserLabel.Value = "OP : " & BillCreatedUserLabel.Value

        If BillPaxLabel.Text = "0" Then
            BillPaxLabel.Visible = False
        End If

        If IsDBNull(BillTotalDiscLabel.Value) Then
            TotalDisc = BillTotalDiscLabel.Value
            BillTotalDiscLabel.Value = FormatNumber(0, DijitKoma, , , TriState.True)
        Else
            TotalDisc = BillTotalDiscLabel.Value
            BillTotalDiscLabel.Value = FormatNumber(BillTotalDiscLabel.Text, DijitKoma, , , TriState.True)
        End If

        If IsDBNull(SubTotalFood.Value) Then
            SubTotalFood.Value = FormatNumber(0, DijitKoma, , , TriState.True)
        Else
            SubTotalFood.Value = FormatNumber(SubTotalFood.Text, DijitKoma, , , TriState.True)
        End If
        If IsDBNull(SubTotalBeverage.Value) Then
            SubTotalBeverage.Value = FormatNumber(0, DijitKoma, , , TriState.True)
        Else
            SubTotalBeverage.Value = FormatNumber(SubTotalBeverage.Text, DijitKoma, , , TriState.True)
        End If
        If IsDBNull(SubTotalMenuEtc.Value) Then
            SubTotalMenuEtc.Value = FormatNumber(0, DijitKoma, , , TriState.True)
        Else
            SubTotalMenuEtc.Value = FormatNumber(SubTotalMenuEtc.Text, DijitKoma, , , TriState.True)
        End If

        Dim DataPoint As New DataSet
        Dim SubItem = New ActiveReport3
        Dim Query As String

        SubItem = New Make_Bill_Sub_Item58
        'Query = "SELECT a.MBTRANSDTITEMNAME,SUM(a.MBTRANSDTITEMDISCVAL1) AS MBTRANSDTITEMDISCVAL1,SUM(a.MBTRANSDTITEMDISCVAL2) AS MBTRANSDTITEMDISCVAL2,D1.DISCNAME AS DISC1,D2.DISCNAME AS DISC2, SUM(a.MBTRANSDTITEMQTY) AS MBTRANSDTITEMQTY, a.MBTRANSDTITEMPRICE FROM MBTRANSDT a " & _
        '        "LEFT OUTER JOIN DISC D1 ON D1.DISCUID=A.MBTRANSDTITEMDISCUID1 " & _
        '        "LEFT OUTER JOIN DISC D2 ON D2.DISCUID=A.MBTRANSDTITEMDISCUID2 " & _
        '        "LEFT OUTER JOIN INVEN INV ON A.MBTRANSDTITEMUID=INV.INVENUID " & _
        '        "WHERE INV.INVENISPRINTED='1' AND a.MBTRANSDTITEMSTAT > -1 AND MBTRANSUID ='" & Label33.Text & "' " & _
        '        "GROUP BY a.MBTRANSDTITEMNAME,DISC1,DISC2,A.MBTRANSDTITEMPRICE ORDER BY a.MBTRANSDTITEMNAME ASC"

        'Anjo - 7 April 2012, Order pesanan di billing ditampilkan berdasar, food/beverages/etc, diikuti dengan menu berdasar alphabet
        Query = "SELECT a.MBTRANSDTITEMNAME,SUM(a.MBTRANSDTITEMDISCVAL1) AS MBTRANSDTITEMDISCVAL1,SUM(a.MBTRANSDTITEMDISCVAL2) AS MBTRANSDTITEMDISCVAL2,D1.DISCNAME AS DISC1,D2.DISCNAME AS DISC2, SUM(a.MBTRANSDTITEMQTY) AS MBTRANSDTITEMQTY, a.MBTRANSDTITEMPRICE FROM MBTRANSDT a " & _
                "LEFT OUTER JOIN DISC D1 ON D1.DISCUID=A.MBTRANSDTITEMDISCUID1 " & _
                "LEFT OUTER JOIN DISC D2 ON D2.DISCUID=A.MBTRANSDTITEMDISCUID2 " & _
                "LEFT OUTER JOIN INVEN INV ON A.MBTRANSDTITEMUID=INV.INVENUID " & _
                "LEFT OUTER JOIN INVENCAT INVCAT ON INV.INVENCATUID=INVCAT.INVENCATUID " & _
                "WHERE INV.INVENISPRINTED='1' AND a.MBTRANSDTITEMSTAT > -1 AND MBTRANSUID ='" & Label33.Text & "' " & _
                "GROUP BY INVCAT.INVENCATSUBCATEGORYID, a.MBTRANSDTITEMNAME,DISC1,DISC2,A.MBTRANSDTITEMPRICE ORDER BY INVCAT.INVENCATSUBCATEGORYID ASC,  a.MBTRANSDTITEMNAME ASC"

        'Query = "SELECT a.MBTRANSDTITEMNAME,K.KITCHENNAME,a.MBTRANSDTITEMDISCVAL1,a.MBTRANSDTITEMDISCVAL2,D1.DISCCODE AS DISC1,D2.DISCCODE AS DISC2, SUM(a.MBTRANSDTITEMQTY) AS MBTRANSDTITEMQTY, a.MBTRANSDTITEMPRICE FROM MBTRANSDT a " & _
        '        "LEFT OUTER JOIN DISC D1 ON D1.DISCUID=A.MBTRANSDTITEMDISCUID1 " & _
        '        "LEFT OUTER JOIN DISC D2 ON D2.DISCUID=A.MBTRANSDTITEMDISCUID2 " & _
        '        "LEFT OUTER JOIN INVEN I ON I.INVENUID=A.MBTRANSDTITEMUID " & _
        '        "LEFT OUTER JOIN KITCHEN K ON K.KITCHENUID=I.INVENKITCHENUID " & _
        '        "WHERE a.MBTRANSDTITEMSTAT > -1 AND MBTRANSUID ='" & Label33.Text & "' " & _
        '        "GROUP BY a.MBTRANSDTITEMNAME,K.KITCHENNAME,a.MBTRANSDTITEMDISCVAL1,a.MBTRANSDTITEMDISCVAL2,DISC1,DISC2,A.MBTRANSDTITEMPRICE ORDER BY K.KITCHENNAME "

        DataPoint = MyDatabase.MyAdapter(Query)

        Me.SubReport1.Report = SubItem
        Me.SubReport1.Report.DataSource = DataPoint
        Me.SubReport1.Report.DataMember = DataPoint.Tables(0).TableName

        LabelSC.Value = PrefInfo.Tax1Name & " :"
        LabelPPN.Value = PrefInfo.Tax2Name & " :"
    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format

        If PreferenceLib.PLogo = Nothing Then
            srLogo.Visible = False
            srLogo.Height = 0 : srLogo.Width = 0
        Else
            Dim srReport As New srBillLogo
            Me.srLogo.Report = srReport
            srLogo.Visible = True
        End If
        CompanyNameText.Value = CompanyInformation.CompanyName
        CompanyAddressText.Value = CompanyInformation.Address & ", " & CompanyInformation.City
        CompanyPhoneText.Value = IIf(pubIsDemo = True, "=Demo Version=", "Phone : " & CompanyInformation.Phone & "    Fax : " & CompanyInformation.Fax)
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
        'Dim GrandTotal As Decimal = 0
        'GrandTotal = Val(BillSubTotalLabel.Text) + Val(TotalDisc) + Val(BillPPNLabel.Text) + Val(BillSCLabel.Text) - Val(BillDPLabel.Text)

        'BillSubTotalLabel.Value = FormatNumber(CDec(BillSubTotalLabel.Text) + CDec(TotalDisc), DijitKoma, , , TriState.True)
        'BillTotalDiscLabel.Value = FormatNumber(BillTotalDiscLabel.Text, DijitKoma, , , TriState.True)
        'BillPPNLabel.Value = FormatNumber(Val(BillPPNLabel.Text), DijitKoma, , , TriState.True)
        'BillSCLabel.Value = FormatNumber(Val(BillSCLabel.Text), DijitKoma, , , TriState.True)
        'BillDPLabel.Value = FormatNumber(BillDPLabel.Text, DijitKoma, , , TriState.True)
        'TotalNetLabel.Value = FormatNumber(GrandTotal, DijitKoma, , , TriState.True)

        'FooterMsg.Text = PrefInfo.Footer

        'Harys - 8 Okt 2011
        Dim GrandTotal As Decimal = 0
        GrandTotal = Val(BillSubTotalLabel.Text) + Val(TotalDisc) + Val(BillPPNLabel.Text) + Val(BillSCLabel.Text) - Val(BillDPLabel.Text)

        BillSubTotalLabel.Value = FormatNumber(CDec(BillSubTotalLabel.Text) + CDec(TotalDisc), DijitKoma, , , TriState.True)
        BillTotalDiscLabel.Value = FormatNumber(BillTotalDiscLabel.Text, DijitKoma, , , TriState.True)
        BillPPNLabel.Value = FormatNumber(Val(BillPPNLabel.Text), DijitKoma, , , TriState.True)
        BillSCLabel.Value = FormatNumber(Val(BillSCLabel.Text), DijitKoma, , , TriState.True)
        BillDPLabel.Value = FormatNumber(BillDPLabel.Text, DijitKoma, , , TriState.True)
        TotalNetLabel.Value = FormatNumber(GrandTotal, DijitKoma, , , TriState.True)

        If ShowPreSettledBill Then
            FooterMsg.Text = "* THIS IS NOT A PROOF OF PAYMENT *"
        Else
            FooterMsg.Text = PrefInfo.Footer
        End If

        'Set location 
        If PrefInfo.Tax1Active = True Then
            LabelSC.Visible = True : BillSCLabel.Visible = True
        Else
            LabelSC.Visible = False : BillSCLabel.Visible = False
        End If

        If PrefInfo.Tax2Active = True Then
            LabelPPN.Visible = True : BillPPNLabel.Visible = True
        Else
            LabelPPN.Visible = False : BillPPNLabel.Visible = False
        End If

        If MainPage.InvoiceApplication = True Then
            LabelDP.Visible = True : BillDPLabel.Visible = True
        Else
            LabelDP.Visible = True : BillDPLabel.Visible = True
        End If

        If LabelSC.Visible = False And LabelPPN.Visible = False And LabelDP.Visible = False Then
            LabelTotalNet.Location = LabelSC.Location : TotalNetLabel.Location = BillSCLabel.Location
            Line6.X1 = 0.06 : Line6.X2 = 2.44 : Line6.Y1 = 0.5 : Line6.Y2 = 0.5
            BillPrintUserLabel.Location = New Drawing.PointF(0.063, 0.625)
            CurrentDateLabel.Location = New Drawing.PointF(1.188, 0.625)
            FooterMsg.Location = New Drawing.PointF(0.063, 0.813)
        ElseIf LabelSC.Visible = True And LabelPPN.Visible = False And LabelDP.Visible = False Then
            LabelTotalNet.Location = LabelPPN.Location : TotalNetLabel.Location = BillPPNLabel.Location
            Line6.X1 = 0.06 : Line6.X2 = 2.44 : Line6.Y1 = 0.69 : Line6.Y2 = 0.69
            BillPrintUserLabel.Location = New Drawing.PointF(0.063, 0.75)
            CurrentDateLabel.Location = New Drawing.PointF(1.188, 0.75)
            FooterMsg.Location = New Drawing.PointF(0.063, 1.063)
        ElseIf LabelSC.Visible = True And LabelPPN.Visible = True And LabelDP.Visible = False Then
            LabelTotalNet.Location = LabelDP.Location : TotalNetLabel.Location = BillDPLabel.Location
            Line6.X1 = 0.06 : Line6.X2 = 2.44 : Line6.Y1 = 0.88 : Line6.Y2 = 0.88
            BillPrintUserLabel.Location = New Drawing.PointF(0.063, 0.938)
            CurrentDateLabel.Location = New Drawing.PointF(1.188, 0.938)
            FooterMsg.Location = New Drawing.PointF(0.063, 1.188)
        ElseIf LabelSC.Visible = False And LabelPPN.Visible = True And LabelDP.Visible = True Then
            LabelPPN.Location = LabelSC.Location : BillPPNLabel.Location = BillSCLabel.Location
            LabelDP.Location = New Drawing.PointF(0.063, 0.438) : BillDPLabel.Location = New Drawing.PointF(1.188, 0.438)
            LabelTotalNet.Location = New Drawing.PointF(0.063, 0.625) : TotalNetLabel.Location = New Drawing.PointF(1.188, 0.625)
            Line6.X1 = 0.06 : Line6.X2 = 2.44 : Line6.Y1 = 0.88 : Line6.Y2 = 0.88
            BillPrintUserLabel.Location = New Drawing.PointF(0.063, 0.938)
            CurrentDateLabel.Location = New Drawing.PointF(1.188, 0.938)
            FooterMsg.Location = New Drawing.PointF(0.063, 1.188)
        ElseIf LabelSC.Visible = False And LabelPPN.Visible = False And LabelDP.Visible = True Then
            LabelDP.Location = LabelSC.Location : BillDPLabel.Location = BillSCLabel.Location
            LabelTotalNet.Location = LabelPPN.Location : TotalNetLabel.Location = BillPPNLabel.Location
            Line6.X1 = 0.06 : Line6.X2 = 2.44 : Line6.Y1 = 0.69 : Line6.Y2 = 0.69
            BillPrintUserLabel.Location = New Drawing.PointF(0.063, 0.75)
            CurrentDateLabel.Location = New Drawing.PointF(1.188, 0.75)
            FooterMsg.Location = New Drawing.PointF(0.063, 1.063)
        ElseIf LabelSC.Visible = True And LabelPPN.Visible = False And LabelDP.Visible = True Then
            LabelDP.Location = LabelPPN.Location : BillDPLabel.Location = BillPPNLabel.Location
            LabelTotalNet.Location = New Drawing.PointF(0.063, 0.625) : TotalNetLabel.Location = New Drawing.PointF(1.188, 0.625)
            Line6.X1 = 0.06 : Line6.X2 = 2.44 : Line6.Y1 = 0.88 : Line6.Y2 = 0.88
            BillPrintUserLabel.Location = New Drawing.PointF(0.063, 0.938)
            CurrentDateLabel.Location = New Drawing.PointF(1.188, 0.938)
            FooterMsg.Location = New Drawing.PointF(0.063, 1.188)
        ElseIf LabelSC.Visible = False And LabelPPN.Visible = True And LabelDP.Visible = False Then
            LabelPPN.Location = LabelSC.Location : BillPPNLabel.Location = BillSCLabel.Location
            LabelTotalNet.Location = New Drawing.PointF(0.063, 0.438) : TotalNetLabel.Location = New Drawing.PointF(1.188, 0.438)
            Line6.X1 = 0.06 : Line6.X2 = 2.44 : Line6.Y1 = 0.69 : Line6.Y2 = 0.69
            BillPrintUserLabel.Location = New Drawing.PointF(0.063, 0.75)
            CurrentDateLabel.Location = New Drawing.PointF(1.188, 0.75)
            FooterMsg.Location = New Drawing.PointF(0.063, 1.063)
        End If
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

                Query = "SELECT SALESPROMOREGPROMOQTY,PROMONAME FROM SALESPROMOREG INNER JOIN PROMO ON SALESPROMOREGPROMOUID=PROMOUID WHERE  SALESPROMOREGTRANSUID= '" & Label33.Text & "'"

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
