<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Make_Bill_Room_Gift
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Make_Bill_Room_Gift))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.txtJumlah = New DataDynamics.ActiveReports.TextBox
        Me.txtNamaGift = New DataDynamics.ActiveReports.TextBox
        Me.Barcode1 = New DataDynamics.ActiveReports.Barcode
        Me.txtBarcodeSupport = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.txtExpiredDate = New DataDynamics.ActiveReports.TextBox
        CType(Me.txtJumlah, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtNamaGift, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtBarcodeSupport, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.txtExpiredDate, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Height = 0.0!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.txtJumlah, Me.txtNamaGift, Me.Barcode1, Me.txtBarcodeSupport, Me.txtExpiredDate})
        Me.Detail1.Height = 0.188!
        Me.Detail1.Name = "Detail1"
        '
        'txtJumlah
        '
        Me.txtJumlah.Border.BottomColor = System.Drawing.Color.Black
        Me.txtJumlah.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJumlah.Border.LeftColor = System.Drawing.Color.Black
        Me.txtJumlah.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJumlah.Border.RightColor = System.Drawing.Color.Black
        Me.txtJumlah.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJumlah.Border.TopColor = System.Drawing.Color.Black
        Me.txtJumlah.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtJumlah.DataField = "SALESPROMOREGPROMOQTY"
        Me.txtJumlah.Height = 0.1875!
        Me.txtJumlah.Left = 0.0625!
        Me.txtJumlah.Name = "txtJumlah"
        Me.txtJumlah.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; vertical-align: middle; "
        Me.txtJumlah.Text = "123"
        Me.txtJumlah.Top = 0.0!
        Me.txtJumlah.Width = 0.25!
        '
        'txtNamaGift
        '
        Me.txtNamaGift.Border.BottomColor = System.Drawing.Color.Black
        Me.txtNamaGift.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNamaGift.Border.LeftColor = System.Drawing.Color.Black
        Me.txtNamaGift.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNamaGift.Border.RightColor = System.Drawing.Color.Black
        Me.txtNamaGift.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNamaGift.Border.TopColor = System.Drawing.Color.Black
        Me.txtNamaGift.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtNamaGift.DataField = "PROMONAME"
        Me.txtNamaGift.Height = 0.1875!
        Me.txtNamaGift.Left = 0.3125!
        Me.txtNamaGift.Name = "txtNamaGift"
        Me.txtNamaGift.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; vertical-align: middle; "
        Me.txtNamaGift.Text = "Gantungan Kunci"
        Me.txtNamaGift.Top = 0.0!
        Me.txtNamaGift.Width = 1.4375!
        '
        'Barcode1
        '
        Me.Barcode1.AutoSize = False
        Me.Barcode1.Border.BottomColor = System.Drawing.Color.Black
        Me.Barcode1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Barcode1.Border.LeftColor = System.Drawing.Color.Black
        Me.Barcode1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Barcode1.Border.RightColor = System.Drawing.Color.Black
        Me.Barcode1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Barcode1.Border.TopColor = System.Drawing.Color.Black
        Me.Barcode1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Barcode1.CaptionPosition = DataDynamics.ActiveReports.BarCodeCaptionPosition.Below
        Me.Barcode1.DataField = "SALESPROMOREGPROMOGENERATEDNO"
        Me.Barcode1.Font = New System.Drawing.Font("Arial Narrow", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Barcode1.Height = 0.375!
        Me.Barcode1.Left = 0.0625!
        Me.Barcode1.Name = "Barcode1"
        Me.Barcode1.Text = "Barcode1"
        Me.Barcode1.Top = 0.1875!
        Me.Barcode1.Width = 2.375!
        '
        'txtBarcodeSupport
        '
        Me.txtBarcodeSupport.Border.BottomColor = System.Drawing.Color.Black
        Me.txtBarcodeSupport.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarcodeSupport.Border.LeftColor = System.Drawing.Color.Black
        Me.txtBarcodeSupport.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarcodeSupport.Border.RightColor = System.Drawing.Color.Black
        Me.txtBarcodeSupport.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarcodeSupport.Border.TopColor = System.Drawing.Color.Black
        Me.txtBarcodeSupport.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtBarcodeSupport.DataField = "PROMOISBARCODESUPPORT"
        Me.txtBarcodeSupport.Height = 0.1875!
        Me.txtBarcodeSupport.Left = 0.4375!
        Me.txtBarcodeSupport.Name = "txtBarcodeSupport"
        Me.txtBarcodeSupport.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; vertical-align: middle; "
        Me.txtBarcodeSupport.Text = "2"
        Me.txtBarcodeSupport.Top = 0.8125!
        Me.txtBarcodeSupport.Visible = False
        Me.txtBarcodeSupport.Width = 0.3125!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1})
        Me.ReportHeader1.Height = 0.1979167!
        Me.ReportHeader1.Name = "ReportHeader1"
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
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.0625!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 8.25pt; font-f" & _
            "amily: Microsoft Sans Serif; "
        Me.Label1.Text = "FREE GIFT"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 2.375!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.02083333!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'txtExpiredDate
        '
        Me.txtExpiredDate.Border.BottomColor = System.Drawing.Color.Black
        Me.txtExpiredDate.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtExpiredDate.Border.LeftColor = System.Drawing.Color.Black
        Me.txtExpiredDate.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtExpiredDate.Border.RightColor = System.Drawing.Color.Black
        Me.txtExpiredDate.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtExpiredDate.Border.TopColor = System.Drawing.Color.Black
        Me.txtExpiredDate.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.txtExpiredDate.DataField = "SALESPROMOREGPROMOEXPIREDDATE"
        Me.txtExpiredDate.Height = 0.1875!
        Me.txtExpiredDate.Left = 1.75!
        Me.txtExpiredDate.Name = "txtExpiredDate"
        Me.txtExpiredDate.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Arial Narrow; " & _
            "vertical-align: middle; "
        Me.txtExpiredDate.Text = "Exp 20/12/2015"
        Me.txtExpiredDate.Top = 0.0!
        Me.txtExpiredDate.Width = 0.6875!
        '
        'Make_Bill_Room_Gift
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
        CType(Me.txtJumlah, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtNamaGift, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtBarcodeSupport, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.txtExpiredDate, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents txtJumlah As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNamaGift As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Barcode1 As DataDynamics.ActiveReports.Barcode
    Friend WithEvents txtBarcodeSupport As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtExpiredDate As DataDynamics.ActiveReports.TextBox
End Class
