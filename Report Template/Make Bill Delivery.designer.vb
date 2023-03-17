<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Make_Bill_Delivery
    Inherits DataDynamics.ActiveReports.ActiveReport3

    'Form overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
        End If
        MyBase.Dispose(disposing)
    End Sub

    'NOTE: The following procedure is required by the ActiveReports Designer
    'It can be modified using the ActiveReports Designer.
    'Do not modify it using the code editor.
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Make_Bill_Delivery))
    Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
    Me.BillTableTxt = New DataDynamics.ActiveReports.TextBox
    Me.Detail1 = New DataDynamics.ActiveReports.Detail
    Me.SubReport1 = New DataDynamics.ActiveReports.SubReport
    Me.Label33 = New DataDynamics.ActiveReports.Label
    Me.LabelTotalDisc = New DataDynamics.ActiveReports.Label
    Me.BillTotalDiscLabel = New DataDynamics.ActiveReports.Label
    Me.BillNoLabel = New DataDynamics.ActiveReports.Label
    Me.TransactionDateLabel = New DataDynamics.ActiveReports.Label
    Me.BillPaxLabel = New DataDynamics.ActiveReports.Label
    Me.Line3 = New DataDynamics.ActiveReports.Line
    Me.Line4 = New DataDynamics.ActiveReports.Line
    Me.Line1 = New DataDynamics.ActiveReports.Line
    Me.BillCreatedUserLabel = New DataDynamics.ActiveReports.TextBox
    Me.BillCustNoLabel = New DataDynamics.ActiveReports.TextBox
    Me.BillCustNameLabel = New DataDynamics.ActiveReports.TextBox
    Me.BillServiceNameLabel = New DataDynamics.ActiveReports.TextBox
    Me.LineSubTotalMenu = New DataDynamics.ActiveReports.Line
    Me.LabelSubTotalBeverage = New DataDynamics.ActiveReports.TextBox
    Me.LabelSubTotalFoods = New DataDynamics.ActiveReports.TextBox
    Me.LabelSubTotalMenuEtc = New DataDynamics.ActiveReports.TextBox
    Me.SubTotalBeverage = New DataDynamics.ActiveReports.TextBox
    Me.SubTotalFood = New DataDynamics.ActiveReports.TextBox
    Me.SubTotalMenuEtc = New DataDynamics.ActiveReports.TextBox
    Me.Label1 = New DataDynamics.ActiveReports.Label
    Me.Label2 = New DataDynamics.ActiveReports.Label
    Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
    Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
    Me.Line2 = New DataDynamics.ActiveReports.Line
    Me.CompanyNameText = New DataDynamics.ActiveReports.TextBox
    Me.CompanyAddressText = New DataDynamics.ActiveReports.TextBox
    Me.CompanyPhoneText = New DataDynamics.ActiveReports.TextBox
    Me.HeaderMsg = New DataDynamics.ActiveReports.TextBox
    Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
    Me.LabelSubTotal = New DataDynamics.ActiveReports.Label
    Me.LabelPPN = New DataDynamics.ActiveReports.Label
    Me.LabelDP = New DataDynamics.ActiveReports.Label
    Me.LabelSC = New DataDynamics.ActiveReports.Label
    Me.LabelTotalNet = New DataDynamics.ActiveReports.Label
    Me.BillSubTotalLabel = New DataDynamics.ActiveReports.Label
    Me.BillPPNLabel = New DataDynamics.ActiveReports.Label
    Me.BillDPLabel = New DataDynamics.ActiveReports.Label
    Me.TotalNetLabel = New DataDynamics.ActiveReports.Label
    Me.BillSCLabel = New DataDynamics.ActiveReports.Label
    Me.Line6 = New DataDynamics.ActiveReports.Line
    Me.CurrentDateLabel = New DataDynamics.ActiveReports.Label
    Me.BillPrintUserLabel = New DataDynamics.ActiveReports.TextBox
    Me.FooterMsg = New DataDynamics.ActiveReports.TextBox
    Me.RoundLabel = New DataDynamics.ActiveReports.Label
    CType(Me.BillTableTxt, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.Label33, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.LabelTotalDisc, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.BillTotalDiscLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.BillNoLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TransactionDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.BillPaxLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.BillCreatedUserLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.BillCustNoLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.BillCustNameLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.BillServiceNameLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.LabelSubTotalBeverage, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.LabelSubTotalFoods, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.LabelSubTotalMenuEtc, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SubTotalBeverage, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SubTotalFood, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.SubTotalMenuEtc, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.CompanyNameText, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.CompanyAddressText, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.CompanyPhoneText, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.HeaderMsg, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.LabelSubTotal, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.LabelPPN, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.LabelDP, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.LabelSC, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.LabelTotalNet, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.BillSubTotalLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.BillPPNLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.BillDPLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TotalNetLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.BillSCLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.CurrentDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.BillPrintUserLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.FooterMsg, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.RoundLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
    '
    'PageHeader1
    '
    Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.BillTableTxt})
    Me.PageHeader1.Height = 0.19375!
    Me.PageHeader1.Name = "PageHeader1"
    '
    'BillTableTxt
    '
    Me.BillTableTxt.Border.BottomColor = System.Drawing.Color.Black
    Me.BillTableTxt.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillTableTxt.Border.LeftColor = System.Drawing.Color.Black
    Me.BillTableTxt.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillTableTxt.Border.RightColor = System.Drawing.Color.Black
    Me.BillTableTxt.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillTableTxt.Border.TopColor = System.Drawing.Color.Black
    Me.BillTableTxt.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillTableTxt.Height = 0.1875!
    Me.BillTableTxt.Left = 0.06!
    Me.BillTableTxt.Name = "BillTableTxt"
    Me.BillTableTxt.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
        "-family: Microsoft Sans Serif; "
    Me.BillTableTxt.Text = "-"
    Me.BillTableTxt.Top = 0.0!
    Me.BillTableTxt.Width = 2.375!
    '
    'Detail1
    '
    Me.Detail1.ColumnSpacing = 0.0!
    Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubReport1, Me.Label33, Me.LabelTotalDisc, Me.BillTotalDiscLabel, Me.BillNoLabel, Me.TransactionDateLabel, Me.BillPaxLabel, Me.Line3, Me.Line4, Me.Line1, Me.BillCreatedUserLabel, Me.BillCustNoLabel, Me.BillCustNameLabel, Me.BillServiceNameLabel, Me.LineSubTotalMenu, Me.LabelSubTotalBeverage, Me.LabelSubTotalFoods, Me.LabelSubTotalMenuEtc, Me.SubTotalBeverage, Me.SubTotalFood, Me.SubTotalMenuEtc, Me.Label1, Me.Label2})
    Me.Detail1.Height = 1.5625!
    Me.Detail1.Name = "Detail1"
    '
    'SubReport1
    '
    Me.SubReport1.Border.BottomColor = System.Drawing.Color.Black
    Me.SubReport1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubReport1.Border.LeftColor = System.Drawing.Color.Black
    Me.SubReport1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubReport1.Border.RightColor = System.Drawing.Color.Black
    Me.SubReport1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubReport1.Border.TopColor = System.Drawing.Color.Black
    Me.SubReport1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubReport1.CloseBorder = False
    Me.SubReport1.Height = 0.25!
    Me.SubReport1.Left = 0.0!
    Me.SubReport1.Name = "SubReport1"
    Me.SubReport1.Report = Nothing
    Me.SubReport1.ReportName = "SubReport1"
    Me.SubReport1.Top = 1.010417!
    Me.SubReport1.Width = 2.5!
    '
    'Label33
    '
    Me.Label33.Border.BottomColor = System.Drawing.Color.Black
    Me.Label33.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Label33.Border.LeftColor = System.Drawing.Color.Black
    Me.Label33.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Label33.Border.RightColor = System.Drawing.Color.Black
    Me.Label33.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Label33.Border.TopColor = System.Drawing.Color.Black
    Me.Label33.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Label33.DataField = "MBTRANSUID"
    Me.Label33.Height = 0.1875!
    Me.Label33.HyperLink = Nothing
    Me.Label33.Left = 0.125!
    Me.Label33.Name = "Label33"
    Me.Label33.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Arial; "
    Me.Label33.Text = "UID"
    Me.Label33.Top = 1.072917!
    Me.Label33.Visible = False
    Me.Label33.Width = 0.375!
    '
    'LabelTotalDisc
    '
    Me.LabelTotalDisc.Border.BottomColor = System.Drawing.Color.Black
    Me.LabelTotalDisc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelTotalDisc.Border.LeftColor = System.Drawing.Color.Black
    Me.LabelTotalDisc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelTotalDisc.Border.RightColor = System.Drawing.Color.Black
    Me.LabelTotalDisc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelTotalDisc.Border.TopColor = System.Drawing.Color.Black
    Me.LabelTotalDisc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelTotalDisc.Height = 0.1875!
    Me.LabelTotalDisc.HyperLink = Nothing
    Me.LabelTotalDisc.Left = 0.0625!
    Me.LabelTotalDisc.Name = "LabelTotalDisc"
    Me.LabelTotalDisc.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.LabelTotalDisc.Text = "Total Discount : "
    Me.LabelTotalDisc.Top = 1.322917!
    Me.LabelTotalDisc.Width = 1.125!
    '
    'BillTotalDiscLabel
    '
    Me.BillTotalDiscLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.BillTotalDiscLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillTotalDiscLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.BillTotalDiscLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillTotalDiscLabel.Border.RightColor = System.Drawing.Color.Black
    Me.BillTotalDiscLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillTotalDiscLabel.Border.TopColor = System.Drawing.Color.Black
    Me.BillTotalDiscLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillTotalDiscLabel.DataField = "MBTRANSDISCVAL"
    Me.BillTotalDiscLabel.Height = 0.1875!
    Me.BillTotalDiscLabel.HyperLink = Nothing
    Me.BillTotalDiscLabel.Left = 1.1875!
    Me.BillTotalDiscLabel.Name = "BillTotalDiscLabel"
    Me.BillTotalDiscLabel.Style = "color: Black; ddo-char-set: 0; text-align: right; font-weight: normal; font-size:" & _
        " 8.25pt; font-family: Microsoft Sans Serif; "
    Me.BillTotalDiscLabel.Text = "-"
    Me.BillTotalDiscLabel.Top = 1.322917!
    Me.BillTotalDiscLabel.Width = 1.25!
    '
    'BillNoLabel
    '
    Me.BillNoLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.BillNoLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillNoLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.BillNoLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillNoLabel.Border.RightColor = System.Drawing.Color.Black
    Me.BillNoLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillNoLabel.Border.TopColor = System.Drawing.Color.Black
    Me.BillNoLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillNoLabel.DataField = "MBTRANSNO"
    Me.BillNoLabel.Height = 0.1875!
    Me.BillNoLabel.HyperLink = Nothing
    Me.BillNoLabel.Left = 0.0625!
    Me.BillNoLabel.Name = "BillNoLabel"
    Me.BillNoLabel.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
    Me.BillNoLabel.Text = "-"
    Me.BillNoLabel.Top = 0.0!
    Me.BillNoLabel.Width = 1.13!
    '
    'TransactionDateLabel
    '
    Me.TransactionDateLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.TransactionDateLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TransactionDateLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.TransactionDateLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TransactionDateLabel.Border.RightColor = System.Drawing.Color.Black
    Me.TransactionDateLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TransactionDateLabel.Border.TopColor = System.Drawing.Color.Black
    Me.TransactionDateLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TransactionDateLabel.DataField = "MBTRANSDATE"
    Me.TransactionDateLabel.Height = 0.1875!
    Me.TransactionDateLabel.HyperLink = Nothing
    Me.TransactionDateLabel.Left = 1.1875!
    Me.TransactionDateLabel.Name = "TransactionDateLabel"
    Me.TransactionDateLabel.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.TransactionDateLabel.Text = "-"
    Me.TransactionDateLabel.Top = 0.0!
    Me.TransactionDateLabel.Width = 1.25!
    '
    'BillPaxLabel
    '
    Me.BillPaxLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.BillPaxLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillPaxLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.BillPaxLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillPaxLabel.Border.RightColor = System.Drawing.Color.Black
    Me.BillPaxLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillPaxLabel.Border.TopColor = System.Drawing.Color.Black
    Me.BillPaxLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillPaxLabel.DataField = "MBTRANSPAXVAL"
    Me.BillPaxLabel.Height = 0.1875!
    Me.BillPaxLabel.HyperLink = Nothing
    Me.BillPaxLabel.Left = 0.0625!
    Me.BillPaxLabel.Name = "BillPaxLabel"
    Me.BillPaxLabel.Style = "text-align: left; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.BillPaxLabel.Text = "-"
    Me.BillPaxLabel.Top = 0.1875!
    Me.BillPaxLabel.Width = 1.125!
    '
    'Line3
    '
    Me.Line3.Border.BottomColor = System.Drawing.Color.Black
    Me.Line3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line3.Border.LeftColor = System.Drawing.Color.Black
    Me.Line3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line3.Border.RightColor = System.Drawing.Color.Black
    Me.Line3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line3.Border.TopColor = System.Drawing.Color.Black
    Me.Line3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line3.Height = 0.0!
    Me.Line3.Left = 0.0625!
    Me.Line3.LineWeight = 2.0!
    Me.Line3.Name = "Line3"
    Me.Line3.Top = 0.96875!
    Me.Line3.Width = 2.375!
    Me.Line3.X1 = 0.0625!
    Me.Line3.X2 = 2.4375!
    Me.Line3.Y1 = 0.96875!
    Me.Line3.Y2 = 0.96875!
    '
    'Line4
    '
    Me.Line4.Border.BottomColor = System.Drawing.Color.Black
    Me.Line4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line4.Border.LeftColor = System.Drawing.Color.Black
    Me.Line4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line4.Border.RightColor = System.Drawing.Color.Black
    Me.Line4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line4.Border.TopColor = System.Drawing.Color.Black
    Me.Line4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line4.Height = 0.0!
    Me.Line4.Left = 0.0625!
    Me.Line4.LineWeight = 2.0!
    Me.Line4.Name = "Line4"
    Me.Line4.Top = 1.541667!
    Me.Line4.Width = 2.375!
    Me.Line4.X1 = 0.0625!
    Me.Line4.X2 = 2.4375!
    Me.Line4.Y1 = 1.541667!
    Me.Line4.Y2 = 1.541667!
    '
    'Line1
    '
    Me.Line1.Border.BottomColor = System.Drawing.Color.Black
    Me.Line1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line1.Border.LeftColor = System.Drawing.Color.Black
    Me.Line1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line1.Border.RightColor = System.Drawing.Color.Black
    Me.Line1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line1.Border.TopColor = System.Drawing.Color.Black
    Me.Line1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line1.Height = 0.0!
    Me.Line1.Left = 0.0625!
    Me.Line1.LineWeight = 2.0!
    Me.Line1.Name = "Line1"
    Me.Line1.Top = 1.291667!
    Me.Line1.Width = 2.375!
    Me.Line1.X1 = 0.0625!
    Me.Line1.X2 = 2.4375!
    Me.Line1.Y1 = 1.291667!
    Me.Line1.Y2 = 1.291667!
    '
    'BillCreatedUserLabel
    '
    Me.BillCreatedUserLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.BillCreatedUserLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillCreatedUserLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.BillCreatedUserLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillCreatedUserLabel.Border.RightColor = System.Drawing.Color.Black
    Me.BillCreatedUserLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillCreatedUserLabel.Border.TopColor = System.Drawing.Color.Black
    Me.BillCreatedUserLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillCreatedUserLabel.DataField = "CREATEDUSER"
    Me.BillCreatedUserLabel.Height = 0.1875!
    Me.BillCreatedUserLabel.Left = 1.1875!
    Me.BillCreatedUserLabel.Name = "BillCreatedUserLabel"
    Me.BillCreatedUserLabel.Style = "text-align: right; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.BillCreatedUserLabel.Text = "-"
    Me.BillCreatedUserLabel.Top = 0.1875!
    Me.BillCreatedUserLabel.Width = 1.25!
    '
    'BillCustNoLabel
    '
    Me.BillCustNoLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.BillCustNoLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillCustNoLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.BillCustNoLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillCustNoLabel.Border.RightColor = System.Drawing.Color.Black
    Me.BillCustNoLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillCustNoLabel.Border.TopColor = System.Drawing.Color.Black
    Me.BillCustNoLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillCustNoLabel.DataField = "CUSTNO"
    Me.BillCustNoLabel.Height = 0.1875!
    Me.BillCustNoLabel.Left = 0.0625!
    Me.BillCustNoLabel.Name = "BillCustNoLabel"
    Me.BillCustNoLabel.Style = "text-align: left; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.BillCustNoLabel.Text = "-"
    Me.BillCustNoLabel.Top = 0.375!
    Me.BillCustNoLabel.Width = 0.625!
    '
    'BillCustNameLabel
    '
    Me.BillCustNameLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.BillCustNameLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillCustNameLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.BillCustNameLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillCustNameLabel.Border.RightColor = System.Drawing.Color.Black
    Me.BillCustNameLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillCustNameLabel.Border.TopColor = System.Drawing.Color.Black
    Me.BillCustNameLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillCustNameLabel.DataField = "MBTRANSCUSTNAME"
    Me.BillCustNameLabel.Height = 0.1875!
    Me.BillCustNameLabel.Left = 0.6875!
    Me.BillCustNameLabel.Name = "BillCustNameLabel"
    Me.BillCustNameLabel.Style = "text-align: center; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.BillCustNameLabel.Text = "-"
    Me.BillCustNameLabel.Top = 0.375!
    Me.BillCustNameLabel.Width = 1.0!
    '
    'BillServiceNameLabel
    '
    Me.BillServiceNameLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.BillServiceNameLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillServiceNameLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.BillServiceNameLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillServiceNameLabel.Border.RightColor = System.Drawing.Color.Black
    Me.BillServiceNameLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillServiceNameLabel.Border.TopColor = System.Drawing.Color.Black
    Me.BillServiceNameLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillServiceNameLabel.DataField = "SERVICENAME"
    Me.BillServiceNameLabel.Height = 0.1875!
    Me.BillServiceNameLabel.Left = 1.6875!
    Me.BillServiceNameLabel.Name = "BillServiceNameLabel"
    Me.BillServiceNameLabel.Style = "text-align: right; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.BillServiceNameLabel.Text = "-"
    Me.BillServiceNameLabel.Top = 0.375!
    Me.BillServiceNameLabel.Width = 0.75!
    '
    'LineSubTotalMenu
    '
    Me.LineSubTotalMenu.Border.BottomColor = System.Drawing.Color.Black
    Me.LineSubTotalMenu.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LineSubTotalMenu.Border.LeftColor = System.Drawing.Color.Black
    Me.LineSubTotalMenu.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LineSubTotalMenu.Border.RightColor = System.Drawing.Color.Black
    Me.LineSubTotalMenu.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LineSubTotalMenu.Border.TopColor = System.Drawing.Color.Black
    Me.LineSubTotalMenu.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LineSubTotalMenu.Height = 0.0!
    Me.LineSubTotalMenu.Left = 0.0625!
    Me.LineSubTotalMenu.LineWeight = 2.0!
    Me.LineSubTotalMenu.Name = "LineSubTotalMenu"
    Me.LineSubTotalMenu.Top = 2.135417!
    Me.LineSubTotalMenu.Width = 2.375!
    Me.LineSubTotalMenu.X1 = 0.0625!
    Me.LineSubTotalMenu.X2 = 2.4375!
    Me.LineSubTotalMenu.Y1 = 2.135417!
    Me.LineSubTotalMenu.Y2 = 2.135417!
    '
    'LabelSubTotalBeverage
    '
    Me.LabelSubTotalBeverage.Border.BottomColor = System.Drawing.Color.Black
    Me.LabelSubTotalBeverage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotalBeverage.Border.LeftColor = System.Drawing.Color.Black
    Me.LabelSubTotalBeverage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotalBeverage.Border.RightColor = System.Drawing.Color.Black
    Me.LabelSubTotalBeverage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotalBeverage.Border.TopColor = System.Drawing.Color.Black
    Me.LabelSubTotalBeverage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotalBeverage.Height = 0.188!
    Me.LabelSubTotalBeverage.Left = 0.0625!
    Me.LabelSubTotalBeverage.Name = "LabelSubTotalBeverage"
    Me.LabelSubTotalBeverage.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.LabelSubTotalBeverage.Text = "Sub Total Beverage : "
    Me.LabelSubTotalBeverage.Top = 1.572917!
    Me.LabelSubTotalBeverage.Width = 1.125!
    '
    'LabelSubTotalFoods
    '
    Me.LabelSubTotalFoods.Border.BottomColor = System.Drawing.Color.Black
    Me.LabelSubTotalFoods.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotalFoods.Border.LeftColor = System.Drawing.Color.Black
    Me.LabelSubTotalFoods.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotalFoods.Border.RightColor = System.Drawing.Color.Black
    Me.LabelSubTotalFoods.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotalFoods.Border.TopColor = System.Drawing.Color.Black
    Me.LabelSubTotalFoods.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotalFoods.Height = 0.188!
    Me.LabelSubTotalFoods.Left = 0.0625!
    Me.LabelSubTotalFoods.Name = "LabelSubTotalFoods"
    Me.LabelSubTotalFoods.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.LabelSubTotalFoods.Text = "Sub Total Food : "
    Me.LabelSubTotalFoods.Top = 1.760417!
    Me.LabelSubTotalFoods.Width = 1.125!
    '
    'LabelSubTotalMenuEtc
    '
    Me.LabelSubTotalMenuEtc.Border.BottomColor = System.Drawing.Color.Black
    Me.LabelSubTotalMenuEtc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotalMenuEtc.Border.LeftColor = System.Drawing.Color.Black
    Me.LabelSubTotalMenuEtc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotalMenuEtc.Border.RightColor = System.Drawing.Color.Black
    Me.LabelSubTotalMenuEtc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotalMenuEtc.Border.TopColor = System.Drawing.Color.Black
    Me.LabelSubTotalMenuEtc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotalMenuEtc.Height = 0.188!
    Me.LabelSubTotalMenuEtc.Left = 0.0625!
    Me.LabelSubTotalMenuEtc.Name = "LabelSubTotalMenuEtc"
    Me.LabelSubTotalMenuEtc.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.LabelSubTotalMenuEtc.Text = "Sub Total Menu Etc. : "
    Me.LabelSubTotalMenuEtc.Top = 1.947917!
    Me.LabelSubTotalMenuEtc.Width = 1.125!
    '
    'SubTotalBeverage
    '
    Me.SubTotalBeverage.Border.BottomColor = System.Drawing.Color.Black
    Me.SubTotalBeverage.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubTotalBeverage.Border.LeftColor = System.Drawing.Color.Black
    Me.SubTotalBeverage.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubTotalBeverage.Border.RightColor = System.Drawing.Color.Black
    Me.SubTotalBeverage.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubTotalBeverage.Border.TopColor = System.Drawing.Color.Black
    Me.SubTotalBeverage.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubTotalBeverage.DataField = "SUBTOTALBEVERAGE"
    Me.SubTotalBeverage.Height = 0.188!
    Me.SubTotalBeverage.Left = 1.1875!
    Me.SubTotalBeverage.Name = "SubTotalBeverage"
    Me.SubTotalBeverage.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.SubTotalBeverage.Text = "-"
    Me.SubTotalBeverage.Top = 1.572917!
    Me.SubTotalBeverage.Width = 1.25!
    '
    'SubTotalFood
    '
    Me.SubTotalFood.Border.BottomColor = System.Drawing.Color.Black
    Me.SubTotalFood.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubTotalFood.Border.LeftColor = System.Drawing.Color.Black
    Me.SubTotalFood.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubTotalFood.Border.RightColor = System.Drawing.Color.Black
    Me.SubTotalFood.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubTotalFood.Border.TopColor = System.Drawing.Color.Black
    Me.SubTotalFood.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubTotalFood.DataField = "SUBTOTALFOOD"
    Me.SubTotalFood.Height = 0.1875!
    Me.SubTotalFood.Left = 1.1875!
    Me.SubTotalFood.Name = "SubTotalFood"
    Me.SubTotalFood.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.SubTotalFood.Text = "-"
    Me.SubTotalFood.Top = 1.760417!
    Me.SubTotalFood.Width = 1.25!
    '
    'SubTotalMenuEtc
    '
    Me.SubTotalMenuEtc.Border.BottomColor = System.Drawing.Color.Black
    Me.SubTotalMenuEtc.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubTotalMenuEtc.Border.LeftColor = System.Drawing.Color.Black
    Me.SubTotalMenuEtc.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubTotalMenuEtc.Border.RightColor = System.Drawing.Color.Black
    Me.SubTotalMenuEtc.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubTotalMenuEtc.Border.TopColor = System.Drawing.Color.Black
    Me.SubTotalMenuEtc.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.SubTotalMenuEtc.DataField = "SUBTOTALMENUETC"
    Me.SubTotalMenuEtc.Height = 0.1875!
    Me.SubTotalMenuEtc.Left = 1.1875!
    Me.SubTotalMenuEtc.Name = "SubTotalMenuEtc"
    Me.SubTotalMenuEtc.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.SubTotalMenuEtc.Text = "-"
    Me.SubTotalMenuEtc.Top = 1.947917!
    Me.SubTotalMenuEtc.Width = 1.25!
    '
    'Label1
    '
    Me.Label1.Border.BottomColor = System.Drawing.Color.Black
    Me.Label1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Label1.Border.LeftColor = System.Drawing.Color.Black
    Me.Label1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Label1.Border.RightColor = System.Drawing.Color.Black
    Me.Label1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Label1.Border.TopColor = System.Drawing.Color.Black
    Me.Label1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Label1.DataField = "Alamat"
    Me.Label1.Height = 0.1875!
    Me.Label1.HyperLink = Nothing
    Me.Label1.Left = 0.0625!
    Me.Label1.Name = "Label1"
    Me.Label1.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
    Me.Label1.Text = "-"
    Me.Label1.Top = 0.5625!
    Me.Label1.Width = 2.375!
    '
    'Label2
    '
    Me.Label2.Border.BottomColor = System.Drawing.Color.Black
    Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Label2.Border.LeftColor = System.Drawing.Color.Black
    Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Label2.Border.RightColor = System.Drawing.Color.Black
    Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Label2.Border.TopColor = System.Drawing.Color.Black
    Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Label2.Height = 0.1875!
    Me.Label2.HyperLink = Nothing
    Me.Label2.Left = 0.0625!
    Me.Label2.Name = "Label2"
    Me.Label2.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
    Me.Label2.Text = "-"
    Me.Label2.Top = 0.75!
    Me.Label2.Width = 2.375!
    '
    'PageFooter1
    '
    Me.PageFooter1.Height = 0.0!
    Me.PageFooter1.Name = "PageFooter1"
    '
    'ReportHeader1
    '
    Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2, Me.CompanyNameText, Me.CompanyAddressText, Me.CompanyPhoneText, Me.HeaderMsg})
    Me.ReportHeader1.Height = 1.03125!
    Me.ReportHeader1.Name = "ReportHeader1"
    '
    'Line2
    '
    Me.Line2.Border.BottomColor = System.Drawing.Color.Black
    Me.Line2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line2.Border.LeftColor = System.Drawing.Color.Black
    Me.Line2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line2.Border.RightColor = System.Drawing.Color.Black
    Me.Line2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line2.Border.TopColor = System.Drawing.Color.Black
    Me.Line2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line2.Height = 0.0!
    Me.Line2.Left = 0.0625!
    Me.Line2.LineWeight = 3.0!
    Me.Line2.Name = "Line2"
    Me.Line2.Top = 0.75!
    Me.Line2.Width = 2.375!
    Me.Line2.X1 = 0.0625!
    Me.Line2.X2 = 2.4375!
    Me.Line2.Y1 = 0.75!
    Me.Line2.Y2 = 0.75!
    '
    'CompanyNameText
    '
    Me.CompanyNameText.Border.BottomColor = System.Drawing.Color.Black
    Me.CompanyNameText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CompanyNameText.Border.LeftColor = System.Drawing.Color.Black
    Me.CompanyNameText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CompanyNameText.Border.RightColor = System.Drawing.Color.Black
    Me.CompanyNameText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CompanyNameText.Border.TopColor = System.Drawing.Color.Black
    Me.CompanyNameText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CompanyNameText.Height = 0.25!
    Me.CompanyNameText.Left = 0.0625!
    Me.CompanyNameText.Name = "CompanyNameText"
    Me.CompanyNameText.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 12pt; font-fam" & _
        "ily: Microsoft Sans Serif; "
    Me.CompanyNameText.Text = "Company Name"
    Me.CompanyNameText.Top = 0.0625!
    Me.CompanyNameText.Width = 2.375!
    '
    'CompanyAddressText
    '
    Me.CompanyAddressText.Border.BottomColor = System.Drawing.Color.Black
    Me.CompanyAddressText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CompanyAddressText.Border.LeftColor = System.Drawing.Color.Black
    Me.CompanyAddressText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CompanyAddressText.Border.RightColor = System.Drawing.Color.Black
    Me.CompanyAddressText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CompanyAddressText.Border.TopColor = System.Drawing.Color.Black
    Me.CompanyAddressText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CompanyAddressText.Height = 0.1875!
    Me.CompanyAddressText.Left = 0.0625!
    Me.CompanyAddressText.Name = "CompanyAddressText"
    Me.CompanyAddressText.Style = "text-align: center; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.CompanyAddressText.Text = "Company Address"
    Me.CompanyAddressText.Top = 0.3125!
    Me.CompanyAddressText.Width = 2.375!
    '
    'CompanyPhoneText
    '
    Me.CompanyPhoneText.Border.BottomColor = System.Drawing.Color.Black
    Me.CompanyPhoneText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CompanyPhoneText.Border.LeftColor = System.Drawing.Color.Black
    Me.CompanyPhoneText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CompanyPhoneText.Border.RightColor = System.Drawing.Color.Black
    Me.CompanyPhoneText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CompanyPhoneText.Border.TopColor = System.Drawing.Color.Black
    Me.CompanyPhoneText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CompanyPhoneText.Height = 0.1875!
    Me.CompanyPhoneText.Left = 0.0625!
    Me.CompanyPhoneText.Name = "CompanyPhoneText"
    Me.CompanyPhoneText.Style = "text-align: center; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.CompanyPhoneText.Text = "Company Phone/Fax"
    Me.CompanyPhoneText.Top = 0.5!
    Me.CompanyPhoneText.Width = 2.375!
    '
    'HeaderMsg
    '
    Me.HeaderMsg.Border.BottomColor = System.Drawing.Color.Black
    Me.HeaderMsg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.HeaderMsg.Border.LeftColor = System.Drawing.Color.Black
    Me.HeaderMsg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.HeaderMsg.Border.RightColor = System.Drawing.Color.Black
    Me.HeaderMsg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.HeaderMsg.Border.TopColor = System.Drawing.Color.Black
    Me.HeaderMsg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.HeaderMsg.Height = 0.1875!
    Me.HeaderMsg.Left = 0.0625!
    Me.HeaderMsg.Name = "HeaderMsg"
    Me.HeaderMsg.Style = "text-align: center; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.HeaderMsg.Text = Nothing
    Me.HeaderMsg.Top = 0.8125!
    Me.HeaderMsg.Width = 2.375!
    '
    'ReportFooter1
    '
    Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.LabelSubTotal, Me.LabelPPN, Me.LabelDP, Me.LabelSC, Me.LabelTotalNet, Me.BillSubTotalLabel, Me.BillPPNLabel, Me.BillDPLabel, Me.TotalNetLabel, Me.BillSCLabel, Me.Line6, Me.CurrentDateLabel, Me.BillPrintUserLabel, Me.FooterMsg, Me.RoundLabel})
    Me.ReportFooter1.Height = 1.864583!
    Me.ReportFooter1.Name = "ReportFooter1"
    '
    'LabelSubTotal
    '
    Me.LabelSubTotal.Border.BottomColor = System.Drawing.Color.Black
    Me.LabelSubTotal.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotal.Border.LeftColor = System.Drawing.Color.Black
    Me.LabelSubTotal.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotal.Border.RightColor = System.Drawing.Color.Black
    Me.LabelSubTotal.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotal.Border.TopColor = System.Drawing.Color.Black
    Me.LabelSubTotal.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSubTotal.Height = 0.1875!
    Me.LabelSubTotal.HyperLink = Nothing
    Me.LabelSubTotal.Left = 0.0625!
    Me.LabelSubTotal.Name = "LabelSubTotal"
    Me.LabelSubTotal.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.LabelSubTotal.Text = "Sub Total : "
    Me.LabelSubTotal.Top = 0.0625!
    Me.LabelSubTotal.Width = 1.125!
    '
    'LabelPPN
    '
    Me.LabelPPN.Border.BottomColor = System.Drawing.Color.Black
    Me.LabelPPN.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelPPN.Border.LeftColor = System.Drawing.Color.Black
    Me.LabelPPN.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelPPN.Border.RightColor = System.Drawing.Color.Black
    Me.LabelPPN.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelPPN.Border.TopColor = System.Drawing.Color.Black
    Me.LabelPPN.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelPPN.Height = 0.1875!
    Me.LabelPPN.HyperLink = Nothing
    Me.LabelPPN.Left = 0.0625!
    Me.LabelPPN.Name = "LabelPPN"
    Me.LabelPPN.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.LabelPPN.Text = ""
    Me.LabelPPN.Top = 0.4375!
    Me.LabelPPN.Width = 1.125!
    '
    'LabelDP
    '
    Me.LabelDP.Border.BottomColor = System.Drawing.Color.Black
    Me.LabelDP.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelDP.Border.LeftColor = System.Drawing.Color.Black
    Me.LabelDP.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelDP.Border.RightColor = System.Drawing.Color.Black
    Me.LabelDP.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelDP.Border.TopColor = System.Drawing.Color.Black
    Me.LabelDP.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelDP.Height = 0.1875!
    Me.LabelDP.HyperLink = Nothing
    Me.LabelDP.Left = 0.0625!
    Me.LabelDP.Name = "LabelDP"
    Me.LabelDP.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.LabelDP.Text = "DP : "
    Me.LabelDP.Top = 0.625!
    Me.LabelDP.Width = 1.125!
    '
    'LabelSC
    '
    Me.LabelSC.Border.BottomColor = System.Drawing.Color.Black
    Me.LabelSC.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSC.Border.LeftColor = System.Drawing.Color.Black
    Me.LabelSC.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSC.Border.RightColor = System.Drawing.Color.Black
    Me.LabelSC.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSC.Border.TopColor = System.Drawing.Color.Black
    Me.LabelSC.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelSC.Height = 0.1875!
    Me.LabelSC.HyperLink = Nothing
    Me.LabelSC.Left = 0.0625!
    Me.LabelSC.Name = "LabelSC"
    Me.LabelSC.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.LabelSC.Text = ""
    Me.LabelSC.Top = 0.25!
    Me.LabelSC.Width = 1.125!
    '
    'LabelTotalNet
    '
    Me.LabelTotalNet.Border.BottomColor = System.Drawing.Color.Black
    Me.LabelTotalNet.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelTotalNet.Border.LeftColor = System.Drawing.Color.Black
    Me.LabelTotalNet.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelTotalNet.Border.RightColor = System.Drawing.Color.Black
    Me.LabelTotalNet.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelTotalNet.Border.TopColor = System.Drawing.Color.Black
    Me.LabelTotalNet.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.LabelTotalNet.Height = 0.1875!
    Me.LabelTotalNet.HyperLink = Nothing
    Me.LabelTotalNet.Left = 0.0625!
    Me.LabelTotalNet.Name = "LabelTotalNet"
    Me.LabelTotalNet.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.LabelTotalNet.Text = "Total (Net) : "
    Me.LabelTotalNet.Top = 0.8125!
    Me.LabelTotalNet.Width = 1.125!
    '
    'BillSubTotalLabel
    '
    Me.BillSubTotalLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.BillSubTotalLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillSubTotalLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.BillSubTotalLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillSubTotalLabel.Border.RightColor = System.Drawing.Color.Black
    Me.BillSubTotalLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillSubTotalLabel.Border.TopColor = System.Drawing.Color.Black
    Me.BillSubTotalLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillSubTotalLabel.DataField = "MBTRANSSUBVAL"
    Me.BillSubTotalLabel.Height = 0.1875!
    Me.BillSubTotalLabel.HyperLink = Nothing
    Me.BillSubTotalLabel.Left = 1.1875!
    Me.BillSubTotalLabel.Name = "BillSubTotalLabel"
    Me.BillSubTotalLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
        "family: Microsoft Sans Serif; "
    Me.BillSubTotalLabel.Text = "-"
    Me.BillSubTotalLabel.Top = 0.0625!
    Me.BillSubTotalLabel.Width = 1.25!
    '
    'BillPPNLabel
    '
    Me.BillPPNLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.BillPPNLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillPPNLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.BillPPNLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillPPNLabel.Border.RightColor = System.Drawing.Color.Black
    Me.BillPPNLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillPPNLabel.Border.TopColor = System.Drawing.Color.Black
    Me.BillPPNLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillPPNLabel.DataField = "MBTransTaxVal2"
    Me.BillPPNLabel.Height = 0.1875!
    Me.BillPPNLabel.HyperLink = Nothing
    Me.BillPPNLabel.Left = 1.1875!
    Me.BillPPNLabel.Name = "BillPPNLabel"
    Me.BillPPNLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
        "family: Microsoft Sans Serif; "
    Me.BillPPNLabel.Text = "-"
    Me.BillPPNLabel.Top = 0.4375!
    Me.BillPPNLabel.Width = 1.25!
    '
    'BillDPLabel
    '
    Me.BillDPLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.BillDPLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillDPLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.BillDPLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillDPLabel.Border.RightColor = System.Drawing.Color.Black
    Me.BillDPLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillDPLabel.Border.TopColor = System.Drawing.Color.Black
    Me.BillDPLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillDPLabel.DataField = "MBTRANSDPVAL"
    Me.BillDPLabel.Height = 0.1875!
    Me.BillDPLabel.HyperLink = Nothing
    Me.BillDPLabel.Left = 1.1875!
    Me.BillDPLabel.Name = "BillDPLabel"
    Me.BillDPLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
        "family: Microsoft Sans Serif; "
    Me.BillDPLabel.Text = "-"
    Me.BillDPLabel.Top = 0.625!
    Me.BillDPLabel.Width = 1.25!
    '
    'TotalNetLabel
    '
    Me.TotalNetLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.TotalNetLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TotalNetLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.TotalNetLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TotalNetLabel.Border.RightColor = System.Drawing.Color.Black
    Me.TotalNetLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TotalNetLabel.Border.TopColor = System.Drawing.Color.Black
    Me.TotalNetLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TotalNetLabel.DataField = "MBTransTotVal"
    Me.TotalNetLabel.Height = 0.1875!
    Me.TotalNetLabel.HyperLink = Nothing
    Me.TotalNetLabel.Left = 1.1875!
    Me.TotalNetLabel.Name = "TotalNetLabel"
    Me.TotalNetLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 9.75pt; font-" & _
        "family: Microsoft Sans Serif; "
    Me.TotalNetLabel.Text = "-"
    Me.TotalNetLabel.Top = 0.8125!
    Me.TotalNetLabel.Width = 1.25!
    '
    'BillSCLabel
    '
    Me.BillSCLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.BillSCLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillSCLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.BillSCLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillSCLabel.Border.RightColor = System.Drawing.Color.Black
    Me.BillSCLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillSCLabel.Border.TopColor = System.Drawing.Color.Black
    Me.BillSCLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillSCLabel.DataField = "MBTransTaxVal1"
    Me.BillSCLabel.Height = 0.1875!
    Me.BillSCLabel.HyperLink = Nothing
    Me.BillSCLabel.Left = 1.1875!
    Me.BillSCLabel.Name = "BillSCLabel"
    Me.BillSCLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
        "family: Microsoft Sans Serif; "
    Me.BillSCLabel.Text = "-"
    Me.BillSCLabel.Top = 0.25!
    Me.BillSCLabel.Width = 1.25!
    '
    'Line6
    '
    Me.Line6.Border.BottomColor = System.Drawing.Color.Black
    Me.Line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line6.Border.LeftColor = System.Drawing.Color.Black
    Me.Line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line6.Border.RightColor = System.Drawing.Color.Black
    Me.Line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line6.Border.TopColor = System.Drawing.Color.Black
    Me.Line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.Line6.Height = 0.0!
    Me.Line6.Left = 0.0625!
    Me.Line6.LineWeight = 2.0!
    Me.Line6.Name = "Line6"
    Me.Line6.Top = 1.0625!
    Me.Line6.Width = 2.375!
    Me.Line6.X1 = 0.0625!
    Me.Line6.X2 = 2.4375!
    Me.Line6.Y1 = 1.0625!
    Me.Line6.Y2 = 1.0625!
    '
    'CurrentDateLabel
    '
    Me.CurrentDateLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.CurrentDateLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CurrentDateLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.CurrentDateLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CurrentDateLabel.Border.RightColor = System.Drawing.Color.Black
    Me.CurrentDateLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CurrentDateLabel.Border.TopColor = System.Drawing.Color.Black
    Me.CurrentDateLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.CurrentDateLabel.Height = 0.1875!
    Me.CurrentDateLabel.HyperLink = Nothing
    Me.CurrentDateLabel.Left = 1.1875!
    Me.CurrentDateLabel.Name = "CurrentDateLabel"
    Me.CurrentDateLabel.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; vertical-align: top; "
    Me.CurrentDateLabel.Text = "-"
    Me.CurrentDateLabel.Top = 1.125!
    Me.CurrentDateLabel.Width = 1.25!
    '
    'BillPrintUserLabel
    '
    Me.BillPrintUserLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.BillPrintUserLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillPrintUserLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.BillPrintUserLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillPrintUserLabel.Border.RightColor = System.Drawing.Color.Black
    Me.BillPrintUserLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillPrintUserLabel.Border.TopColor = System.Drawing.Color.Black
    Me.BillPrintUserLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.BillPrintUserLabel.DataField = "MODIFIEDUSER"
    Me.BillPrintUserLabel.Height = 0.1875!
    Me.BillPrintUserLabel.Left = 0.0625!
    Me.BillPrintUserLabel.Name = "BillPrintUserLabel"
    Me.BillPrintUserLabel.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Microsoft Sans" & _
        " Serif; "
    Me.BillPrintUserLabel.Text = "-"
    Me.BillPrintUserLabel.Top = 1.125!
    Me.BillPrintUserLabel.Width = 1.13!
    '
    'FooterMsg
    '
    Me.FooterMsg.Border.BottomColor = System.Drawing.Color.Black
    Me.FooterMsg.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.FooterMsg.Border.LeftColor = System.Drawing.Color.Black
    Me.FooterMsg.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.FooterMsg.Border.RightColor = System.Drawing.Color.Black
    Me.FooterMsg.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.FooterMsg.Border.TopColor = System.Drawing.Color.Black
    Me.FooterMsg.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.FooterMsg.Height = 0.1875!
    Me.FooterMsg.Left = 0.0625!
    Me.FooterMsg.Name = "FooterMsg"
    Me.FooterMsg.Style = "text-align: center; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.FooterMsg.Text = Nothing
    Me.FooterMsg.Top = 1.375!
    Me.FooterMsg.Width = 2.375!
    '
    'RoundLabel
    '
    Me.RoundLabel.Border.BottomColor = System.Drawing.Color.Black
    Me.RoundLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.RoundLabel.Border.LeftColor = System.Drawing.Color.Black
    Me.RoundLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.RoundLabel.Border.RightColor = System.Drawing.Color.Black
    Me.RoundLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.RoundLabel.Border.TopColor = System.Drawing.Color.Black
    Me.RoundLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.RoundLabel.DataField = "MBTRANSROUNDINGVAL"
    Me.RoundLabel.Height = 0.1979167!
    Me.RoundLabel.HyperLink = Nothing
    Me.RoundLabel.Left = 0.75!
    Me.RoundLabel.Name = "RoundLabel"
    Me.RoundLabel.Style = ""
    Me.RoundLabel.Text = ""
    Me.RoundLabel.Top = 1.625!
    Me.RoundLabel.Width = 1.0!
    '
    'Make_Bill_Delivery
    '
    Me.MasterReport = False
    Me.PageSettings.PaperHeight = 11.0!
    Me.PageSettings.PaperWidth = 8.5!
    Me.PrintWidth = 2.5!
    Me.ScriptLanguage = "VB.NET"
    Me.Sections.Add(Me.ReportHeader1)
    Me.Sections.Add(Me.PageHeader1)
    Me.Sections.Add(Me.Detail1)
    Me.Sections.Add(Me.PageFooter1)
    Me.Sections.Add(Me.ReportFooter1)
    Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                "l; font-size: 10pt; color: Black; ", "Normal"))
    Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
    Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                "lic; ", "Heading2", "Normal"))
    Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
    CType(Me.BillTableTxt, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.Label33, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.LabelTotalDisc, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.BillTotalDiscLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.BillNoLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.TransactionDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.BillPaxLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.BillCreatedUserLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.BillCustNoLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.BillCustNameLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.BillServiceNameLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.LabelSubTotalBeverage, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.LabelSubTotalFoods, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.LabelSubTotalMenuEtc, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SubTotalBeverage, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SubTotalFood, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.SubTotalMenuEtc, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.CompanyNameText, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.CompanyAddressText, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.CompanyPhoneText, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.HeaderMsg, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.LabelSubTotal, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.LabelPPN, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.LabelDP, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.LabelSC, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.LabelTotalNet, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.BillSubTotalLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.BillPPNLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.BillDPLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.TotalNetLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.BillSCLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.CurrentDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.BillPrintUserLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.FooterMsg, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.RoundLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

  End Sub
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents SubReport1 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label33 As DataDynamics.ActiveReports.Label
    Friend WithEvents LabelTotalDisc As DataDynamics.ActiveReports.Label
    Friend WithEvents BillTotalDiscLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents BillNoLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents TransactionDateLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents BillPaxLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents BillCreatedUserLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents BillCustNoLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents BillCustNameLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents BillServiceNameLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LineSubTotalMenu As DataDynamics.ActiveReports.Line
    Friend WithEvents LabelSubTotalBeverage As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelSubTotalFoods As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelSubTotalMenuEtc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SubTotalBeverage As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SubTotalFood As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SubTotalMenuEtc As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents CompanyNameText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyAddressText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyPhoneText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelSubTotal As DataDynamics.ActiveReports.Label
    Friend WithEvents LabelPPN As DataDynamics.ActiveReports.Label
    Friend WithEvents LabelDP As DataDynamics.ActiveReports.Label
    Friend WithEvents LabelSC As DataDynamics.ActiveReports.Label
    Friend WithEvents LabelTotalNet As DataDynamics.ActiveReports.Label
    Friend WithEvents BillSubTotalLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents BillPPNLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents BillDPLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents TotalNetLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents BillSCLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents CurrentDateLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents BillPrintUserLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents BillTableTxt As DataDynamics.ActiveReports.TextBox
    Friend WithEvents HeaderMsg As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FooterMsg As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
  Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
  Friend WithEvents RoundLabel As DataDynamics.ActiveReports.Label
End Class
