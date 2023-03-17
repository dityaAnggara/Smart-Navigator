<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Payment 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Payment))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.PaymentCreatedDateLabel = New DataDynamics.ActiveReports.Label
        Me.PaymentTableLabel = New DataDynamics.ActiveReports.Label
        Me.PaymentPrinterCounterLabel = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.SubReport2 = New DataDynamics.ActiveReports.SubReport
        Me.Label35 = New DataDynamics.ActiveReports.Label
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.PaymentNoLabel = New DataDynamics.ActiveReports.Label
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.CurrentDateLabel = New DataDynamics.ActiveReports.Label
        Me.PaymentPrintUserLabel = New DataDynamics.ActiveReports.TextBox
        Me.Line4 = New DataDynamics.ActiveReports.Line
        CType(Me.PaymentCreatedDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentTableLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentPrinterCounterLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentNoLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrentDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentPrintUserLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Height = 0.0!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'PaymentCreatedDateLabel
        '
        Me.PaymentCreatedDateLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.PaymentCreatedDateLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentCreatedDateLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.PaymentCreatedDateLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentCreatedDateLabel.Border.RightColor = System.Drawing.Color.Black
        Me.PaymentCreatedDateLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentCreatedDateLabel.Border.TopColor = System.Drawing.Color.Black
        Me.PaymentCreatedDateLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentCreatedDateLabel.DataField = "PBTRANSDATE"
        Me.PaymentCreatedDateLabel.Height = 0.1875!
        Me.PaymentCreatedDateLabel.HyperLink = Nothing
        Me.PaymentCreatedDateLabel.Left = 1.25!
        Me.PaymentCreatedDateLabel.Name = "PaymentCreatedDateLabel"
        Me.PaymentCreatedDateLabel.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
            "s Serif; "
        Me.PaymentCreatedDateLabel.Text = "-"
        Me.PaymentCreatedDateLabel.Top = 0.0!
        Me.PaymentCreatedDateLabel.Width = 1.1875!
        '
        'PaymentTableLabel
        '
        Me.PaymentTableLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.PaymentTableLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentTableLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.PaymentTableLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentTableLabel.Border.RightColor = System.Drawing.Color.Black
        Me.PaymentTableLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentTableLabel.Border.TopColor = System.Drawing.Color.Black
        Me.PaymentTableLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentTableLabel.DataField = "SELECTEDTABLELISTNAME"
        Me.PaymentTableLabel.Height = 0.1875!
        Me.PaymentTableLabel.HyperLink = Nothing
        Me.PaymentTableLabel.Left = 0.0625!
        Me.PaymentTableLabel.Name = "PaymentTableLabel"
        Me.PaymentTableLabel.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
            "amily: Microsoft Sans Serif; "
        Me.PaymentTableLabel.Text = "-"
        Me.PaymentTableLabel.Top = 0.0!
        Me.PaymentTableLabel.Width = 1.3125!
        '
        'PaymentPrinterCounterLabel
        '
        Me.PaymentPrinterCounterLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.PaymentPrinterCounterLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentPrinterCounterLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.PaymentPrinterCounterLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentPrinterCounterLabel.Border.RightColor = System.Drawing.Color.Black
        Me.PaymentPrinterCounterLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentPrinterCounterLabel.Border.TopColor = System.Drawing.Color.Black
        Me.PaymentPrinterCounterLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentPrinterCounterLabel.DataField = "PRINTCOUNTER"
        Me.PaymentPrinterCounterLabel.Height = 0.1875!
        Me.PaymentPrinterCounterLabel.HyperLink = Nothing
        Me.PaymentPrinterCounterLabel.Left = 1.375!
        Me.PaymentPrinterCounterLabel.Name = "PaymentPrinterCounterLabel"
        Me.PaymentPrinterCounterLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.PaymentPrinterCounterLabel.Text = "-"
        Me.PaymentPrinterCounterLabel.Top = 0.0!
        Me.PaymentPrinterCounterLabel.Width = 1.0625!
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
        Me.Line1.Top = 0.1979167!
        Me.Line1.Width = 2.375!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 2.4375!
        Me.Line1.Y1 = 0.1979167!
        Me.Line1.Y2 = 0.1979167!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.SubReport2, Me.Label35})
        Me.Detail1.Height = 0.1979167!
        Me.Detail1.Name = "Detail1"
        '
        'SubReport2
        '
        Me.SubReport2.Border.BottomColor = System.Drawing.Color.Black
        Me.SubReport2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport2.Border.LeftColor = System.Drawing.Color.Black
        Me.SubReport2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport2.Border.RightColor = System.Drawing.Color.Black
        Me.SubReport2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport2.Border.TopColor = System.Drawing.Color.Black
        Me.SubReport2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.SubReport2.CloseBorder = False
        Me.SubReport2.Height = 0.1875!
        Me.SubReport2.Left = 0.0!
        Me.SubReport2.Name = "SubReport2"
        Me.SubReport2.Report = Nothing
        Me.SubReport2.ReportName = "SubReport2"
        Me.SubReport2.Top = 0.0!
        Me.SubReport2.Width = 2.5!
        '
        'Label35
        '
        Me.Label35.Border.BottomColor = System.Drawing.Color.Black
        Me.Label35.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label35.Border.LeftColor = System.Drawing.Color.Black
        Me.Label35.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label35.Border.RightColor = System.Drawing.Color.Black
        Me.Label35.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label35.Border.TopColor = System.Drawing.Color.Black
        Me.Label35.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label35.DataField = "PBTRANSUID"
        Me.Label35.Height = 0.1875!
        Me.Label35.HyperLink = Nothing
        Me.Label35.Left = 0.0!
        Me.Label35.Name = "Label35"
        Me.Label35.Style = "text-align: center; "
        Me.Label35.Text = "UID"
        Me.Label35.Top = 0.0!
        Me.Label35.Visible = False
        Me.Label35.Width = 0.375!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'PaymentNoLabel
        '
        Me.PaymentNoLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.PaymentNoLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentNoLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.PaymentNoLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentNoLabel.Border.RightColor = System.Drawing.Color.Black
        Me.PaymentNoLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentNoLabel.Border.TopColor = System.Drawing.Color.Black
        Me.PaymentNoLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentNoLabel.DataField = "PBTRANSNO"
        Me.PaymentNoLabel.Height = 0.1875!
        Me.PaymentNoLabel.HyperLink = Nothing
        Me.PaymentNoLabel.Left = 0.0625!
        Me.PaymentNoLabel.Name = "PaymentNoLabel"
        Me.PaymentNoLabel.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Microsoft Sans" & _
            " Serif; "
        Me.PaymentNoLabel.Text = "-"
        Me.PaymentNoLabel.Top = 0.0!
        Me.PaymentNoLabel.Width = 1.1875!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.PaymentNoLabel, Me.PaymentCreatedDateLabel})
        Me.GroupHeader1.DataField = "PBTRANSNO"
        Me.GroupHeader1.Height = 0.2!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.PaymentTableLabel, Me.PaymentPrinterCounterLabel, Me.Line1})
        Me.ReportHeader1.Height = 0.2!
        Me.ReportHeader1.Name = "ReportHeader1"
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.CurrentDateLabel, Me.PaymentPrintUserLabel, Me.Line4})
        Me.ReportFooter1.Height = 0.2708333!
        Me.ReportFooter1.Name = "ReportFooter1"
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
        Me.CurrentDateLabel.Top = 0.03!
        Me.CurrentDateLabel.Width = 1.25!
        '
        'PaymentPrintUserLabel
        '
        Me.PaymentPrintUserLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.PaymentPrintUserLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentPrintUserLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.PaymentPrintUserLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentPrintUserLabel.Border.RightColor = System.Drawing.Color.Black
        Me.PaymentPrintUserLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentPrintUserLabel.Border.TopColor = System.Drawing.Color.Black
        Me.PaymentPrintUserLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentPrintUserLabel.Height = 0.1875!
        Me.PaymentPrintUserLabel.Left = 0.0625!
        Me.PaymentPrintUserLabel.Name = "PaymentPrintUserLabel"
        Me.PaymentPrintUserLabel.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Microsoft Sans" & _
            " Serif; "
        Me.PaymentPrintUserLabel.Text = "-"
        Me.PaymentPrintUserLabel.Top = 0.03!
        Me.PaymentPrintUserLabel.Width = 1.125!
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
        Me.Line4.Top = 0.0!
        Me.Line4.Width = 2.375!
        Me.Line4.X1 = 0.0625!
        Me.Line4.X2 = 2.4375!
        Me.Line4.Y1 = 0.0!
        Me.Line4.Y2 = 0.0!
        '
        'Payment
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.5!
        Me.Sections.Add(Me.ReportHeader1)
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.Sections.Add(Me.ReportFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.PaymentCreatedDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentTableLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentPrinterCounterLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label35, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentNoLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrentDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentPrintUserLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents SubReport2 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents Label35 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents PaymentCreatedDateLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents PaymentTableLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents PaymentPrinterCounterLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents PaymentNoLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents CurrentDateLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents PaymentPrintUserLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
End Class
