<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Make_Order58
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Make_Order58))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.CompanyNameText = New DataDynamics.ActiveReports.TextBox
        Me.CompanyAddressText = New DataDynamics.ActiveReports.TextBox
        Me.CompanyPhoneText = New DataDynamics.ActiveReports.TextBox
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.SubReport1 = New DataDynamics.ActiveReports.SubReport
        Me.MakeOrderTransactionDateLabel = New DataDynamics.ActiveReports.Label
        Me.MakeOrderTableLabel = New DataDynamics.ActiveReports.Label
        Me.MakeOrderPaxLabel = New DataDynamics.ActiveReports.Label
        Me.Label33 = New DataDynamics.ActiveReports.Label
        Me.CurrentDateLabel = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.MakeOrderModifiedUserLabel = New DataDynamics.ActiveReports.TextBox
        Me.MakeOrderPrintUserLabel = New DataDynamics.ActiveReports.TextBox
        Me.MakeOrderTransNoLabel = New DataDynamics.ActiveReports.Label
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        CType(Me.CompanyNameText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyAddressText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyPhoneText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MakeOrderTransactionDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MakeOrderTableLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MakeOrderPaxLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrentDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MakeOrderModifiedUserLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MakeOrderPrintUserLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.MakeOrderTransNoLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2, Me.CompanyNameText, Me.CompanyAddressText, Me.CompanyPhoneText})
        Me.PageHeader1.Height = 0.315!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.Line2.Top = 0.25!
        Me.Line2.Width = 1.8125!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 1.875!
        Me.Line2.Y1 = 0.25!
        Me.Line2.Y2 = 0.25!
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
        Me.CompanyNameText.Top = 0.0!
        Me.CompanyNameText.Width = 1.8125!
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
        Me.CompanyAddressText.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Microsoft Sa" & _
            "ns Serif; "
        Me.CompanyAddressText.Text = "Company Address"
        Me.CompanyAddressText.Top = 0.25!
        Me.CompanyAddressText.Visible = False
        Me.CompanyAddressText.Width = 1.8125!
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
        Me.CompanyPhoneText.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Microsoft Sa" & _
            "ns Serif; "
        Me.CompanyPhoneText.Text = "Company Phone/Fax"
        Me.CompanyPhoneText.Top = 0.4375!
        Me.CompanyPhoneText.Visible = False
        Me.CompanyPhoneText.Width = 2.25!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line3, Me.SubReport1, Me.MakeOrderTransactionDateLabel, Me.MakeOrderTableLabel, Me.MakeOrderPaxLabel, Me.Label33, Me.CurrentDateLabel, Me.Line1, Me.MakeOrderModifiedUserLabel, Me.MakeOrderPrintUserLabel, Me.MakeOrderTransNoLabel})
        Me.Detail1.Height = 1.22!
        Me.Detail1.Name = "Detail1"
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
        Me.Line3.Top = 0.59375!
        Me.Line3.Width = 1.8175!
        Me.Line3.X1 = 0.0625!
        Me.Line3.X2 = 1.88!
        Me.Line3.Y1 = 0.59375!
        Me.Line3.Y2 = 0.59375!
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
        Me.SubReport1.Height = 0.3125!
        Me.SubReport1.Left = 0.0625!
        Me.SubReport1.Name = "SubReport1"
        Me.SubReport1.Report = Nothing
        Me.SubReport1.ReportName = "SubReport1"
        Me.SubReport1.Top = 0.625!
        Me.SubReport1.Width = 1.875!
        '
        'MakeOrderTransactionDateLabel
        '
        Me.MakeOrderTransactionDateLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.MakeOrderTransactionDateLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderTransactionDateLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.MakeOrderTransactionDateLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderTransactionDateLabel.Border.RightColor = System.Drawing.Color.Black
        Me.MakeOrderTransactionDateLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderTransactionDateLabel.Border.TopColor = System.Drawing.Color.Black
        Me.MakeOrderTransactionDateLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderTransactionDateLabel.DataField = "MBTRANSDATE"
        Me.MakeOrderTransactionDateLabel.Height = 0.1875!
        Me.MakeOrderTransactionDateLabel.HyperLink = Nothing
        Me.MakeOrderTransactionDateLabel.Left = 1.0!
        Me.MakeOrderTransactionDateLabel.Name = "MakeOrderTransactionDateLabel"
        Me.MakeOrderTransactionDateLabel.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
            "s Serif; "
        Me.MakeOrderTransactionDateLabel.Text = "-"
        Me.MakeOrderTransactionDateLabel.Top = 0.1875!
        Me.MakeOrderTransactionDateLabel.Visible = False
        Me.MakeOrderTransactionDateLabel.Width = 0.875!
        '
        'MakeOrderTableLabel
        '
        Me.MakeOrderTableLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.MakeOrderTableLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderTableLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.MakeOrderTableLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderTableLabel.Border.RightColor = System.Drawing.Color.Black
        Me.MakeOrderTableLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderTableLabel.Border.TopColor = System.Drawing.Color.Black
        Me.MakeOrderTableLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderTableLabel.DataField = "TABLELISTNAME"
        Me.MakeOrderTableLabel.Height = 0.1875!
        Me.MakeOrderTableLabel.HyperLink = Nothing
        Me.MakeOrderTableLabel.Left = 0.0625!
        Me.MakeOrderTableLabel.Name = "MakeOrderTableLabel"
        Me.MakeOrderTableLabel.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
            "-family: Microsoft Sans Serif; "
        Me.MakeOrderTableLabel.Text = "-"
        Me.MakeOrderTableLabel.Top = 0.0!
        Me.MakeOrderTableLabel.Width = 1.8125!
        '
        'MakeOrderPaxLabel
        '
        Me.MakeOrderPaxLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.MakeOrderPaxLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderPaxLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.MakeOrderPaxLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderPaxLabel.Border.RightColor = System.Drawing.Color.Black
        Me.MakeOrderPaxLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderPaxLabel.Border.TopColor = System.Drawing.Color.Black
        Me.MakeOrderPaxLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderPaxLabel.DataField = "MBTRANSPAXVAL"
        Me.MakeOrderPaxLabel.Height = 0.1875!
        Me.MakeOrderPaxLabel.HyperLink = Nothing
        Me.MakeOrderPaxLabel.Left = 0.0625!
        Me.MakeOrderPaxLabel.Name = "MakeOrderPaxLabel"
        Me.MakeOrderPaxLabel.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
        Me.MakeOrderPaxLabel.Text = "-"
        Me.MakeOrderPaxLabel.Top = 0.375!
        Me.MakeOrderPaxLabel.Width = 0.6875!
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
        Me.Label33.Left = 0.0625!
        Me.Label33.Name = "Label33"
        Me.Label33.Style = "ddo-char-set: 0; text-align: center; font-size: 9pt; "
        Me.Label33.Text = "UID"
        Me.Label33.Top = 0.6770833!
        Me.Label33.Visible = False
        Me.Label33.Width = 0.375!
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
        Me.CurrentDateLabel.Left = 0.9375!
        Me.CurrentDateLabel.Name = "CurrentDateLabel"
        Me.CurrentDateLabel.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
            "s Serif; vertical-align: top; "
        Me.CurrentDateLabel.Text = "-"
        Me.CurrentDateLabel.Top = 1.0!
        Me.CurrentDateLabel.Width = 0.9375!
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
        Me.Line1.Top = 0.96875!
        Me.Line1.Width = 1.8175!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 1.88!
        Me.Line1.Y1 = 0.96875!
        Me.Line1.Y2 = 0.96875!
        '
        'MakeOrderModifiedUserLabel
        '
        Me.MakeOrderModifiedUserLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.MakeOrderModifiedUserLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderModifiedUserLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.MakeOrderModifiedUserLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderModifiedUserLabel.Border.RightColor = System.Drawing.Color.Black
        Me.MakeOrderModifiedUserLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderModifiedUserLabel.Border.TopColor = System.Drawing.Color.Black
        Me.MakeOrderModifiedUserLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderModifiedUserLabel.DataField = "MODIFIEDUSER"
        Me.MakeOrderModifiedUserLabel.Height = 0.1875!
        Me.MakeOrderModifiedUserLabel.Left = 0.75!
        Me.MakeOrderModifiedUserLabel.Name = "MakeOrderModifiedUserLabel"
        Me.MakeOrderModifiedUserLabel.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
            "s Serif; "
        Me.MakeOrderModifiedUserLabel.Text = "-"
        Me.MakeOrderModifiedUserLabel.Top = 0.375!
        Me.MakeOrderModifiedUserLabel.Width = 1.125!
        '
        'MakeOrderPrintUserLabel
        '
        Me.MakeOrderPrintUserLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.MakeOrderPrintUserLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderPrintUserLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.MakeOrderPrintUserLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderPrintUserLabel.Border.RightColor = System.Drawing.Color.Black
        Me.MakeOrderPrintUserLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderPrintUserLabel.Border.TopColor = System.Drawing.Color.Black
        Me.MakeOrderPrintUserLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderPrintUserLabel.DataField = "MODIFIEDUSER"
        Me.MakeOrderPrintUserLabel.Height = 0.1875!
        Me.MakeOrderPrintUserLabel.Left = 0.0625!
        Me.MakeOrderPrintUserLabel.Name = "MakeOrderPrintUserLabel"
        Me.MakeOrderPrintUserLabel.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Microsoft Sans" & _
            " Serif; "
        Me.MakeOrderPrintUserLabel.Text = "-"
        Me.MakeOrderPrintUserLabel.Top = 1.0!
        Me.MakeOrderPrintUserLabel.Width = 0.875!
        '
        'MakeOrderTransNoLabel
        '
        Me.MakeOrderTransNoLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.MakeOrderTransNoLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderTransNoLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.MakeOrderTransNoLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderTransNoLabel.Border.RightColor = System.Drawing.Color.Black
        Me.MakeOrderTransNoLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderTransNoLabel.Border.TopColor = System.Drawing.Color.Black
        Me.MakeOrderTransNoLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.MakeOrderTransNoLabel.DataField = "MBTRANSNO"
        Me.MakeOrderTransNoLabel.Height = 0.1875!
        Me.MakeOrderTransNoLabel.HyperLink = Nothing
        Me.MakeOrderTransNoLabel.Left = 0.0625!
        Me.MakeOrderTransNoLabel.Name = "MakeOrderTransNoLabel"
        Me.MakeOrderTransNoLabel.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
        Me.MakeOrderTransNoLabel.Text = "-"
        Me.MakeOrderTransNoLabel.Top = 0.1875!
        Me.MakeOrderTransNoLabel.Width = 1.8125!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'Make_Order58
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.033!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.CompanyNameText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyAddressText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyPhoneText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MakeOrderTransactionDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MakeOrderTableLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MakeOrderPaxLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label33, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrentDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MakeOrderModifiedUserLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MakeOrderPrintUserLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.MakeOrderTransNoLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents SubReport1 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents MakeOrderTransactionDateLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents MakeOrderTransNoLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents MakeOrderTableLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents MakeOrderPaxLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents Label33 As DataDynamics.ActiveReports.Label
    Friend WithEvents CurrentDateLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents CompanyNameText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyAddressText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyPhoneText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents MakeOrderModifiedUserLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents MakeOrderPrintUserLabel As DataDynamics.ActiveReports.TextBox
End Class
