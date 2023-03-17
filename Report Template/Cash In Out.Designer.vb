<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Cash_In_Out
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
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Cash_In_Out))
    Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
    Me.Detail1 = New DataDynamics.ActiveReports.Detail
    Me.BillCreatedUserLabel = New DataDynamics.ActiveReports.TextBox
    Me.BillNoLabel = New DataDynamics.ActiveReports.Label
    Me.TransactionDateLabel = New DataDynamics.ActiveReports.Label
    Me.Line3 = New DataDynamics.ActiveReports.Line
    Me.txtKeterengan = New DataDynamics.ActiveReports.TextBox
    Me.Label1 = New DataDynamics.ActiveReports.Label
    Me.txtPaymentType = New DataDynamics.ActiveReports.TextBox
    Me.txtTipeTransaksi = New DataDynamics.ActiveReports.TextBox
    Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
    Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
    Me.Line2 = New DataDynamics.ActiveReports.Line
    Me.CompanyNameText = New DataDynamics.ActiveReports.TextBox
    Me.CompanyAddressText = New DataDynamics.ActiveReports.TextBox
    Me.CompanyPhoneText = New DataDynamics.ActiveReports.TextBox
    Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
    Me.TextBox2 = New DataDynamics.ActiveReports.TextBox
    Me.TextBox3 = New DataDynamics.ActiveReports.TextBox
    Me.TextBox4 = New DataDynamics.ActiveReports.TextBox
    Me.TextBox5 = New DataDynamics.ActiveReports.TextBox
    Me.Line1 = New DataDynamics.ActiveReports.Line
    CType(Me.BillCreatedUserLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.BillNoLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TransactionDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtKeterengan, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtPaymentType, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtTipeTransaksi, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.CompanyNameText, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.CompanyAddressText, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.CompanyPhoneText, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
    '
    'PageHeader1
    '
    Me.PageHeader1.Height = 0.1!
    Me.PageHeader1.Name = "PageHeader1"
    '
    'Detail1
    '
    Me.Detail1.ColumnSpacing = 0.0!
    Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.BillCreatedUserLabel, Me.BillNoLabel, Me.TransactionDateLabel, Me.Line3, Me.txtKeterengan, Me.Label1, Me.txtPaymentType, Me.txtTipeTransaksi})
    Me.Detail1.Height = 0.9583333!
    Me.Detail1.Name = "Detail1"
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
    Me.BillCreatedUserLabel.Left = 0.0625!
    Me.BillCreatedUserLabel.Name = "BillCreatedUserLabel"
    Me.BillCreatedUserLabel.Style = "text-align: left; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.BillCreatedUserLabel.Text = "-"
    Me.BillCreatedUserLabel.Top = 0.1875!
    Me.BillCreatedUserLabel.Width = 2.375!
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
    Me.BillNoLabel.DataField = "PBTRANSNO"
    Me.BillNoLabel.Height = 0.1875!
    Me.BillNoLabel.HyperLink = Nothing
    Me.BillNoLabel.Left = 0.0625!
    Me.BillNoLabel.Name = "BillNoLabel"
    Me.BillNoLabel.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
    Me.BillNoLabel.Text = "-"
    Me.BillNoLabel.Top = 0.0!
    Me.BillNoLabel.Width = 2.375!
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
    Me.TransactionDateLabel.DataField = "PBTRANSDATE"
    Me.TransactionDateLabel.Height = 0.1875!
    Me.TransactionDateLabel.HyperLink = Nothing
    Me.TransactionDateLabel.Left = 1.8125!
    Me.TransactionDateLabel.Name = "TransactionDateLabel"
    Me.TransactionDateLabel.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.TransactionDateLabel.Text = "-"
    Me.TransactionDateLabel.Top = 0.0!
    Me.TransactionDateLabel.Visible = False
    Me.TransactionDateLabel.Width = 0.625!
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
    Me.Line3.Top = 0.375!
    Me.Line3.Width = 2.375!
    Me.Line3.X1 = 0.0625!
    Me.Line3.X2 = 2.4375!
    Me.Line3.Y1 = 0.375!
    Me.Line3.Y2 = 0.375!
    '
    'txtKeterengan
    '
    Me.txtKeterengan.Border.BottomColor = System.Drawing.Color.Black
    Me.txtKeterengan.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtKeterengan.Border.LeftColor = System.Drawing.Color.Black
    Me.txtKeterengan.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtKeterengan.Border.RightColor = System.Drawing.Color.Black
    Me.txtKeterengan.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtKeterengan.Border.TopColor = System.Drawing.Color.Black
    Me.txtKeterengan.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtKeterengan.DataField = "PBTRANSDESC"
    Me.txtKeterengan.Height = 0.1875!
    Me.txtKeterengan.Left = 0.0625!
    Me.txtKeterengan.Name = "txtKeterengan"
    Me.txtKeterengan.Style = "text-align: left; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.txtKeterengan.Text = "-"
    Me.txtKeterengan.Top = 0.7604167!
    Me.txtKeterengan.Width = 1.5625!
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
    Me.Label1.DataField = "PBTRANSTOTVAL"
    Me.Label1.Height = 0.1875!
    Me.Label1.HyperLink = Nothing
    Me.Label1.Left = 1.625!
    Me.Label1.Name = "Label1"
    Me.Label1.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.Label1.Text = "-"
    Me.Label1.Top = 0.7604167!
    Me.Label1.Width = 0.8125!
    '
    'txtPaymentType
    '
    Me.txtPaymentType.Border.BottomColor = System.Drawing.Color.Black
    Me.txtPaymentType.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtPaymentType.Border.LeftColor = System.Drawing.Color.Black
    Me.txtPaymentType.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtPaymentType.Border.RightColor = System.Drawing.Color.Black
    Me.txtPaymentType.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtPaymentType.Border.TopColor = System.Drawing.Color.Black
    Me.txtPaymentType.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtPaymentType.DataField = "PAYMENTTYPENAME"
    Me.txtPaymentType.Height = 0.1875!
    Me.txtPaymentType.Left = 0.0625!
    Me.txtPaymentType.Name = "txtPaymentType"
    Me.txtPaymentType.Style = "text-align: left; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.txtPaymentType.Text = "-"
    Me.txtPaymentType.Top = 0.5729167!
    Me.txtPaymentType.Width = 2.375!
    '
    'txtTipeTransaksi
    '
    Me.txtTipeTransaksi.Border.BottomColor = System.Drawing.Color.Black
    Me.txtTipeTransaksi.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtTipeTransaksi.Border.LeftColor = System.Drawing.Color.Black
    Me.txtTipeTransaksi.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtTipeTransaksi.Border.RightColor = System.Drawing.Color.Black
    Me.txtTipeTransaksi.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtTipeTransaksi.Border.TopColor = System.Drawing.Color.Black
    Me.txtTipeTransaksi.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtTipeTransaksi.DataField = "TipeBayar"
    Me.txtTipeTransaksi.Height = 0.1875!
    Me.txtTipeTransaksi.Left = 0.0625!
    Me.txtTipeTransaksi.Name = "txtTipeTransaksi"
    Me.txtTipeTransaksi.Style = "text-align: left; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.txtTipeTransaksi.Text = "-"
    Me.txtTipeTransaksi.Top = 0.3854167!
    Me.txtTipeTransaksi.Width = 2.375!
    '
    'PageFooter1
    '
    Me.PageFooter1.Height = 0.0!
    Me.PageFooter1.Name = "PageFooter1"
    '
    'ReportHeader1
    '
    Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2, Me.CompanyNameText, Me.CompanyAddressText, Me.CompanyPhoneText})
    Me.ReportHeader1.Height = 0.7604167!
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
    'ReportFooter1
    '
    Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.TextBox2, Me.TextBox3, Me.TextBox4, Me.TextBox5, Me.Line1})
    Me.ReportFooter1.Height = 0.8541667!
    Me.ReportFooter1.Name = "ReportFooter1"
    '
    'TextBox2
    '
    Me.TextBox2.Border.BottomColor = System.Drawing.Color.Black
    Me.TextBox2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox2.Border.LeftColor = System.Drawing.Color.Black
    Me.TextBox2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox2.Border.RightColor = System.Drawing.Color.Black
    Me.TextBox2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox2.Border.TopColor = System.Drawing.Color.Black
    Me.TextBox2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox2.Height = 0.1875!
    Me.TextBox2.Left = 1.25!
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Style = "text-align: center; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.TextBox2.Text = "Approved By"
    Me.TextBox2.Top = 0.0625!
    Me.TextBox2.Width = 1.1875!
    '
    'TextBox3
    '
    Me.TextBox3.Border.BottomColor = System.Drawing.Color.Black
    Me.TextBox3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox3.Border.LeftColor = System.Drawing.Color.Black
    Me.TextBox3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox3.Border.RightColor = System.Drawing.Color.Black
    Me.TextBox3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox3.Border.TopColor = System.Drawing.Color.Black
    Me.TextBox3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox3.Height = 0.1875!
    Me.TextBox3.Left = 1.25!
    Me.TextBox3.Name = "TextBox3"
    Me.TextBox3.Style = "text-align: center; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.TextBox3.Text = "(. . . . . . . . . . )"
    Me.TextBox3.Top = 0.625!
    Me.TextBox3.Width = 1.1875!
    '
    'TextBox4
    '
    Me.TextBox4.Border.BottomColor = System.Drawing.Color.Black
    Me.TextBox4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox4.Border.LeftColor = System.Drawing.Color.Black
    Me.TextBox4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox4.Border.RightColor = System.Drawing.Color.Black
    Me.TextBox4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox4.Border.TopColor = System.Drawing.Color.Black
    Me.TextBox4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox4.Height = 0.1875!
    Me.TextBox4.Left = 0.0625!
    Me.TextBox4.Name = "TextBox4"
    Me.TextBox4.Style = "text-align: center; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.TextBox4.Text = "Received By"
    Me.TextBox4.Top = 0.0625!
    Me.TextBox4.Width = 1.1875!
    '
    'TextBox5
    '
    Me.TextBox5.Border.BottomColor = System.Drawing.Color.Black
    Me.TextBox5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox5.Border.LeftColor = System.Drawing.Color.Black
    Me.TextBox5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox5.Border.RightColor = System.Drawing.Color.Black
    Me.TextBox5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox5.Border.TopColor = System.Drawing.Color.Black
    Me.TextBox5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.TextBox5.Height = 0.1875!
    Me.TextBox5.Left = 0.0625!
    Me.TextBox5.Name = "TextBox5"
    Me.TextBox5.Style = "text-align: center; font-size: 8.25pt; font-family: MS Reference Sans Serif; "
    Me.TextBox5.Text = "(. . . . . . . . . . )"
    Me.TextBox5.Top = 0.625!
    Me.TextBox5.Width = 1.1875!
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
    Me.Line1.Top = 0.0!
    Me.Line1.Width = 2.375!
    Me.Line1.X1 = 0.0625!
    Me.Line1.X2 = 2.4375!
    Me.Line1.Y1 = 0.0!
    Me.Line1.Y2 = 0.0!
    '
    'Cash_In_Out
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
    CType(Me.BillCreatedUserLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.BillNoLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.TransactionDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtKeterengan, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtPaymentType, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtTipeTransaksi, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.CompanyNameText, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.CompanyAddressText, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.CompanyPhoneText, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.TextBox2, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.TextBox3, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.TextBox4, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.TextBox5, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

  End Sub
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents BillNoLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents TransactionDateLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents BillCreatedUserLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents CompanyNameText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyAddressText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyPhoneText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtKeterengan As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox2 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox3 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox4 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents TextBox5 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtPaymentType As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTipeTransaksi As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
End Class
