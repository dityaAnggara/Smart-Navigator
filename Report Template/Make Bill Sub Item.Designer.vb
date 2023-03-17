<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Make_Bill_Sub_Item
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Make_Bill_Sub_Item))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.BillItemQty = New DataDynamics.ActiveReports.Label
        Me.Label38 = New DataDynamics.ActiveReports.Label
        Me.BillItemPrice = New DataDynamics.ActiveReports.Label
        Me.BillItemDisc1 = New DataDynamics.ActiveReports.Label
        Me.BillItemDisc2 = New DataDynamics.ActiveReports.Label
        Me.BillItemName = New DataDynamics.ActiveReports.TextBox
        Me.LabelDisc1 = New DataDynamics.ActiveReports.TextBox
        Me.LabelDisc2 = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        CType(Me.BillItemQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BillItemPrice, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BillItemDisc1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BillItemDisc2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BillItemName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelDisc1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.LabelDisc2, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.BillItemQty, Me.Label38, Me.BillItemPrice, Me.BillItemDisc1, Me.BillItemDisc2, Me.BillItemName, Me.LabelDisc1, Me.LabelDisc2})
        Me.Detail1.Height = 0.57!
        Me.Detail1.Name = "Detail1"
        '
        'BillItemQty
        '
        Me.BillItemQty.Border.BottomColor = System.Drawing.Color.Black
        Me.BillItemQty.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemQty.Border.LeftColor = System.Drawing.Color.Black
        Me.BillItemQty.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemQty.Border.RightColor = System.Drawing.Color.Black
        Me.BillItemQty.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemQty.Border.TopColor = System.Drawing.Color.Black
        Me.BillItemQty.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemQty.DataField = "MBTRANSDTITEMQTY"
        Me.BillItemQty.Height = 0.1875!
        Me.BillItemQty.HyperLink = Nothing
        Me.BillItemQty.Left = 0.0625!
        Me.BillItemQty.Name = "BillItemQty"
        Me.BillItemQty.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Microsoft Sa" & _
            "ns Serif; "
        Me.BillItemQty.Text = "-"
        Me.BillItemQty.Top = 0.0!
        Me.BillItemQty.Width = 0.31!
        '
        'Label38
        '
        Me.Label38.Border.BottomColor = System.Drawing.Color.Black
        Me.Label38.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label38.Border.LeftColor = System.Drawing.Color.Black
        Me.Label38.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label38.Border.RightColor = System.Drawing.Color.Black
        Me.Label38.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label38.Border.TopColor = System.Drawing.Color.Black
        Me.Label38.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label38.DataField = "MBTRANSDTITEMPRICE"
        Me.Label38.Height = 0.1875!
        Me.Label38.HyperLink = Nothing
        Me.Label38.Left = 0.0625!
        Me.Label38.Name = "Label38"
        Me.Label38.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Microsoft Sa" & _
            "ns Serif; "
        Me.Label38.Text = "-"
        Me.Label38.Top = 0.1875!
        Me.Label38.Visible = False
        Me.Label38.Width = 0.3125!
        '
        'BillItemPrice
        '
        Me.BillItemPrice.Border.BottomColor = System.Drawing.Color.Black
        Me.BillItemPrice.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemPrice.Border.LeftColor = System.Drawing.Color.Black
        Me.BillItemPrice.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemPrice.Border.RightColor = System.Drawing.Color.Black
        Me.BillItemPrice.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemPrice.Border.TopColor = System.Drawing.Color.Black
        Me.BillItemPrice.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemPrice.Height = 0.1875!
        Me.BillItemPrice.HyperLink = Nothing
        Me.BillItemPrice.Left = 1.5!
        Me.BillItemPrice.Name = "BillItemPrice"
        Me.BillItemPrice.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
            "s Serif; "
        Me.BillItemPrice.Text = "-"
        Me.BillItemPrice.Top = 0.0!
        Me.BillItemPrice.Width = 0.9375!
        '
        'BillItemDisc1
        '
        Me.BillItemDisc1.Border.BottomColor = System.Drawing.Color.Black
        Me.BillItemDisc1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemDisc1.Border.LeftColor = System.Drawing.Color.Black
        Me.BillItemDisc1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemDisc1.Border.RightColor = System.Drawing.Color.Black
        Me.BillItemDisc1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemDisc1.Border.TopColor = System.Drawing.Color.Black
        Me.BillItemDisc1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemDisc1.DataField = "MBTRANSDTITEMDISCVAL1"
        Me.BillItemDisc1.Height = 0.1875!
        Me.BillItemDisc1.HyperLink = Nothing
        Me.BillItemDisc1.Left = 1.5!
        Me.BillItemDisc1.Name = "BillItemDisc1"
        Me.BillItemDisc1.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
            "s Serif; "
        Me.BillItemDisc1.Text = "-"
        Me.BillItemDisc1.Top = 0.1875!
        Me.BillItemDisc1.Visible = False
        Me.BillItemDisc1.Width = 0.9375!
        '
        'BillItemDisc2
        '
        Me.BillItemDisc2.Border.BottomColor = System.Drawing.Color.Black
        Me.BillItemDisc2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemDisc2.Border.LeftColor = System.Drawing.Color.Black
        Me.BillItemDisc2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemDisc2.Border.RightColor = System.Drawing.Color.Black
        Me.BillItemDisc2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemDisc2.Border.TopColor = System.Drawing.Color.Black
        Me.BillItemDisc2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemDisc2.DataField = "MBTRANSDTITEMDISCVAL2"
        Me.BillItemDisc2.Height = 0.1875!
        Me.BillItemDisc2.HyperLink = Nothing
        Me.BillItemDisc2.Left = 1.5!
        Me.BillItemDisc2.Name = "BillItemDisc2"
        Me.BillItemDisc2.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
            "s Serif; "
        Me.BillItemDisc2.Text = "-"
        Me.BillItemDisc2.Top = 0.375!
        Me.BillItemDisc2.Visible = False
        Me.BillItemDisc2.Width = 0.9375!
        '
        'BillItemName
        '
        Me.BillItemName.Border.BottomColor = System.Drawing.Color.Black
        Me.BillItemName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemName.Border.LeftColor = System.Drawing.Color.Black
        Me.BillItemName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemName.Border.RightColor = System.Drawing.Color.Black
        Me.BillItemName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemName.Border.TopColor = System.Drawing.Color.Black
        Me.BillItemName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BillItemName.DataField = "MBTRANSDTITEMNAME"
        Me.BillItemName.Height = 0.1875!
        Me.BillItemName.Left = 0.375!
        Me.BillItemName.Name = "BillItemName"
        Me.BillItemName.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
        Me.BillItemName.Text = "-"
        Me.BillItemName.Top = 0.0!
        Me.BillItemName.Width = 1.125!
        '
        'LabelDisc1
        '
        Me.LabelDisc1.Border.BottomColor = System.Drawing.Color.Black
        Me.LabelDisc1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelDisc1.Border.LeftColor = System.Drawing.Color.Black
        Me.LabelDisc1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelDisc1.Border.RightColor = System.Drawing.Color.Black
        Me.LabelDisc1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelDisc1.Border.TopColor = System.Drawing.Color.Black
        Me.LabelDisc1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelDisc1.DataField = "DISC1"
        Me.LabelDisc1.Height = 0.1875!
        Me.LabelDisc1.Left = 0.375!
        Me.LabelDisc1.Name = "LabelDisc1"
        Me.LabelDisc1.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
        Me.LabelDisc1.Text = "-"
        Me.LabelDisc1.Top = 0.1875!
        Me.LabelDisc1.Visible = False
        Me.LabelDisc1.Width = 1.125!
        '
        'LabelDisc2
        '
        Me.LabelDisc2.Border.BottomColor = System.Drawing.Color.Black
        Me.LabelDisc2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelDisc2.Border.LeftColor = System.Drawing.Color.Black
        Me.LabelDisc2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelDisc2.Border.RightColor = System.Drawing.Color.Black
        Me.LabelDisc2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelDisc2.Border.TopColor = System.Drawing.Color.Black
        Me.LabelDisc2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.LabelDisc2.DataField = "DISC2"
        Me.LabelDisc2.Height = 0.1875!
        Me.LabelDisc2.Left = 0.375!
        Me.LabelDisc2.Name = "LabelDisc2"
        Me.LabelDisc2.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
        Me.LabelDisc2.Text = "-"
        Me.LabelDisc2.Top = 0.375!
        Me.LabelDisc2.Visible = False
        Me.LabelDisc2.Width = 1.125!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'Make_Bill_Sub_Item
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.5!
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
        CType(Me.BillItemQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label38, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BillItemPrice, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BillItemDisc1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BillItemDisc2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BillItemName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelDisc1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.LabelDisc2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents BillItemQty As DataDynamics.ActiveReports.Label
    Friend WithEvents Label38 As DataDynamics.ActiveReports.Label
    Friend WithEvents BillItemPrice As DataDynamics.ActiveReports.Label
    Friend WithEvents BillItemDisc1 As DataDynamics.ActiveReports.Label
    Friend WithEvents BillItemDisc2 As DataDynamics.ActiveReports.Label
    Friend WithEvents BillItemName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelDisc1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents LabelDisc2 As DataDynamics.ActiveReports.TextBox
End Class
