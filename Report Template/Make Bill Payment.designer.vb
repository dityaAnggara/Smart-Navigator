<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Make_Bill_Payment
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Make_Bill_Payment))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtChange = New DataDynamics.ActiveReports.TextBox
        Me.SubReport1 = New DataDynamics.ActiveReports.SubReport
        Me.SubReport2 = New DataDynamics.ActiveReports.SubReport
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        CType(Me.txtChange, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Height = 0.1!
        Me.PageHeader1.Name = "PageHeader1"
        Me.PageHeader1.Visible = False
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtChange, Me.SubReport1, Me.SubReport2, Me.Label1, Me.Line4, Me.Line1})
        Me.Detail1.Height = 1.427083!
        Me.Detail1.Name = "Detail1"
        '
        'txtChange
        '
        Me.txtChange.Border.BottomColor = System.Drawing.Color.Black
        Me.txtChange.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtChange.Border.LeftColor = System.Drawing.Color.Black
        Me.txtChange.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtChange.Border.RightColor = System.Drawing.Color.Black
        Me.txtChange.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtChange.Border.TopColor = System.Drawing.Color.Black
        Me.txtChange.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtChange.Height = 0.25!
        Me.txtChange.Left = 1.25!
        Me.txtChange.Name = "txtChange"
        Me.txtChange.Style = "ddo-char-set: 0; text-align: right; font-size: 12pt; font-family: Microsoft Sans " & _
            "Serif; "
        Me.txtChange.Text = "0.00"
        Me.txtChange.Top = 1.0625!
        Me.txtChange.Width = 1.1875!
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
        Me.SubReport1.Height = 0.6875!
        Me.SubReport1.Left = 0.0!
        Me.SubReport1.Name = "SubReport1"
        Me.SubReport1.Report = Nothing
        Me.SubReport1.ReportName = "SubReport1"
        Me.SubReport1.Top = 0.0!
        Me.SubReport1.Width = 6.0!
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
        Me.SubReport2.Height = 0.25!
        Me.SubReport2.Left = 0.0!
        Me.SubReport2.Name = "SubReport2"
        Me.SubReport2.Report = Nothing
        Me.SubReport2.ReportName = "SubReport1"
        Me.SubReport2.Top = 0.8125!
        Me.SubReport2.Width = 6.0!
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
        Me.Label1.Height = 0.25!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0625!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; font-size: 12pt; font-family: Microsoft Sans Serif; "
        Me.Label1.Text = "Change"
        Me.Label1.Top = 1.0625!
        Me.Label1.Width = 0.8125!
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
        Me.Line4.Top = 1.0625!
        Me.Line4.Width = 2.375!
        Me.Line4.X1 = 0.0625!
        Me.Line4.X2 = 2.4375!
        Me.Line4.Y1 = 1.0625!
        Me.Line4.Y2 = 1.0625!
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
        Me.Line1.Top = 1.28125!
        Me.Line1.Width = 2.375!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 2.4375!
        Me.Line1.Y1 = 1.28125!
        Me.Line1.Y2 = 1.28125!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.25!
        Me.PageFooter1.Name = "PageFooter1"
        Me.PageFooter1.Visible = False
        '
        'Make_Bill_Payment
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.txtChange, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents SubReport1 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents SubReport2 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents txtChange As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
End Class
