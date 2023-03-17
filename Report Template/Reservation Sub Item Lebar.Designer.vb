<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Reservation_Sub_Item_Lebar
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Reservation_Sub_Item_Lebar))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.ReservationItemPriceLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationItemQtyLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationItemSubTotalPriceLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationItemName = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationItemPriceLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationItemQtyLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationItemSubTotalPriceLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationItemName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.CanShrink = True
        Me.PageHeader1.Height = 0.0!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.TextBox1})
        Me.Detail1.Height = 0.0!
        Me.Detail1.Name = "Detail1"
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
        Me.Label1.DataField = "DETAILQTY"
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 0.375!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
            "-family: Microsoft Sans Serif; "
        Me.Label1.Text = "-"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 0.25!
        '
        'TextBox1
        '
        Me.TextBox1.Border.BottomColor = System.Drawing.Color.Black
        Me.TextBox1.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.LeftColor = System.Drawing.Color.Black
        Me.TextBox1.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.RightColor = System.Drawing.Color.Black
        Me.TextBox1.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.Border.TopColor = System.Drawing.Color.Black
        Me.TextBox1.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TextBox1.DataField = "DETAILITEM"
        Me.TextBox1.Height = 0.1875!
        Me.TextBox1.Left = 0.625!
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Microsoft S" & _
            "ans Serif; "
        Me.TextBox1.Text = "-"
        Me.TextBox1.Top = 0.0!
        Me.TextBox1.Width = 1.8125!
        '
        'ReservationItemPriceLabel
        '
        Me.ReservationItemPriceLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationItemPriceLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemPriceLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationItemPriceLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemPriceLabel.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationItemPriceLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemPriceLabel.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationItemPriceLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemPriceLabel.DataField = "RSVTRANSDTITEMPRICE"
        Me.ReservationItemPriceLabel.Height = 0.1875!
        Me.ReservationItemPriceLabel.HyperLink = Nothing
        Me.ReservationItemPriceLabel.Left = 0.375!
        Me.ReservationItemPriceLabel.Name = "ReservationItemPriceLabel"
        Me.ReservationItemPriceLabel.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
            "amily: Microsoft Sans Serif; "
        Me.ReservationItemPriceLabel.Text = "-"
        Me.ReservationItemPriceLabel.Top = 0.1875!
        Me.ReservationItemPriceLabel.Visible = False
        Me.ReservationItemPriceLabel.Width = 1.25!
        '
        'ReservationItemQtyLabel
        '
        Me.ReservationItemQtyLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationItemQtyLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemQtyLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationItemQtyLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemQtyLabel.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationItemQtyLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemQtyLabel.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationItemQtyLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemQtyLabel.DataField = "RSVTRANSDTITEMQTY"
        Me.ReservationItemQtyLabel.Height = 0.1875!
        Me.ReservationItemQtyLabel.HyperLink = Nothing
        Me.ReservationItemQtyLabel.Left = 0.0625!
        Me.ReservationItemQtyLabel.Name = "ReservationItemQtyLabel"
        Me.ReservationItemQtyLabel.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
            "-family: Microsoft Sans Serif; "
        Me.ReservationItemQtyLabel.Text = "-"
        Me.ReservationItemQtyLabel.Top = 0.0!
        Me.ReservationItemQtyLabel.Width = 0.3125!
        '
        'ReservationItemSubTotalPriceLabel
        '
        Me.ReservationItemSubTotalPriceLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationItemSubTotalPriceLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemSubTotalPriceLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationItemSubTotalPriceLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemSubTotalPriceLabel.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationItemSubTotalPriceLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemSubTotalPriceLabel.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationItemSubTotalPriceLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemSubTotalPriceLabel.Height = 0.1875!
        Me.ReservationItemSubTotalPriceLabel.HyperLink = Nothing
        Me.ReservationItemSubTotalPriceLabel.Left = 1.625!
        Me.ReservationItemSubTotalPriceLabel.Name = "ReservationItemSubTotalPriceLabel"
        Me.ReservationItemSubTotalPriceLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.ReservationItemSubTotalPriceLabel.Text = "-"
        Me.ReservationItemSubTotalPriceLabel.Top = 0.0!
        Me.ReservationItemSubTotalPriceLabel.Visible = False
        Me.ReservationItemSubTotalPriceLabel.Width = 0.8125!
        '
        'ReservationItemName
        '
        Me.ReservationItemName.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationItemName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemName.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationItemName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemName.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationItemName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemName.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationItemName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationItemName.DataField = "RSVTRANSDTITEMNAME"
        Me.ReservationItemName.Height = 0.1875!
        Me.ReservationItemName.Left = 0.375!
        Me.ReservationItemName.Name = "ReservationItemName"
        Me.ReservationItemName.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Microsoft S" & _
            "ans Serif; "
        Me.ReservationItemName.Text = "-"
        Me.ReservationItemName.Top = 0.0!
        Me.ReservationItemName.Width = 2.0625!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReservationItemName, Me.ReservationItemPriceLabel, Me.ReservationItemQtyLabel, Me.ReservationItemSubTotalPriceLabel})
        Me.GroupHeader1.DataField = "RSVTRANSDTITEMNAME"
        Me.GroupHeader1.Height = 0.2!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Reservation_Sub_Item_Lebar
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.5!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.PageHeader1)
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.Sections.Add(Me.PageFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationItemPriceLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationItemQtyLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationItemSubTotalPriceLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationItemName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReservationItemQtyLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationItemPriceLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationItemSubTotalPriceLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationItemName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
End Class
