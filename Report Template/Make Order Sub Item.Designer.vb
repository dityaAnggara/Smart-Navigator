<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Make_Order_Sub_Item 
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
    Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Make_Order_Sub_Item))
    Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
    Me.Detail1 = New DataDynamics.ActiveReports.Detail
    Me.Label1 = New DataDynamics.ActiveReports.Label
    Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
    Me.ItemQty = New DataDynamics.ActiveReports.Label
    Me.ItemName = New DataDynamics.ActiveReports.TextBox
    Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
    Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
    Me.txtNote = New DataDynamics.ActiveReports.TextBox
    Me.txtTakeAway = New DataDynamics.ActiveReports.TextBox
    Me.txtTA = New DataDynamics.ActiveReports.TextBox
    Me.txtNoteHidden = New DataDynamics.ActiveReports.TextBox
    Me.SubReport1 = New DataDynamics.ActiveReports.SubReport
    Me.txtParentUID = New DataDynamics.ActiveReports.TextBox
    Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
    CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ItemQty, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ItemName, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtNote, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtTakeAway, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtTA, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtNoteHidden, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.txtParentUID, System.ComponentModel.ISupportInitialize).BeginInit()
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
    Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label1, Me.TextBox1})
    Me.Detail1.Height = 0.1979167!
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
    Me.Label1.Left = 0.4375!
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
    Me.TextBox1.Left = 0.6875!
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Microsoft S" & _
        "ans Serif; "
    Me.TextBox1.Text = "-"
    Me.TextBox1.Top = 0.0!
    Me.TextBox1.Width = 1.75!
    '
    'ItemQty
    '
    Me.ItemQty.Border.BottomColor = System.Drawing.Color.Black
    Me.ItemQty.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.ItemQty.Border.LeftColor = System.Drawing.Color.Black
    Me.ItemQty.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.ItemQty.Border.RightColor = System.Drawing.Color.Black
    Me.ItemQty.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.ItemQty.Border.TopColor = System.Drawing.Color.Black
    Me.ItemQty.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.ItemQty.DataField = "MBTRANSDTITEMQTY"
    Me.ItemQty.Height = 0.1875!
    Me.ItemQty.HyperLink = Nothing
    Me.ItemQty.Left = 0.0625!
    Me.ItemQty.Name = "ItemQty"
    Me.ItemQty.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Microsoft Sa" & _
        "ns Serif; "
    Me.ItemQty.Text = "-"
    Me.ItemQty.Top = 0.0!
    Me.ItemQty.Width = 0.375!
    '
    'ItemName
    '
    Me.ItemName.Border.BottomColor = System.Drawing.Color.Black
    Me.ItemName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.ItemName.Border.LeftColor = System.Drawing.Color.Black
    Me.ItemName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.ItemName.Border.RightColor = System.Drawing.Color.Black
    Me.ItemName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.ItemName.Border.TopColor = System.Drawing.Color.Black
    Me.ItemName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.ItemName.DataField = "MBTRANSDTITEMLISTNOTE"
    Me.ItemName.Height = 0.1875!
    Me.ItemName.Left = 0.4375!
    Me.ItemName.Name = "ItemName"
    Me.ItemName.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
    Me.ItemName.Text = Nothing
    Me.ItemName.Top = 0.0!
    Me.ItemName.Width = 1.6875!
    '
    'PageFooter1
    '
    Me.PageFooter1.Height = 0.0!
    Me.PageFooter1.Name = "PageFooter1"
    '
    'GroupHeader1
    '
    Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ItemName, Me.ItemQty, Me.txtNote, Me.txtTakeAway, Me.txtTA, Me.txtNoteHidden, Me.SubReport1, Me.txtParentUID})
    Me.GroupHeader1.DataField = "MBTRANSDTUID"
    Me.GroupHeader1.Height = 0.3854167!
    Me.GroupHeader1.Name = "GroupHeader1"
    '
    'txtNote
    '
    Me.txtNote.Border.BottomColor = System.Drawing.Color.Black
    Me.txtNote.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtNote.Border.LeftColor = System.Drawing.Color.Black
    Me.txtNote.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtNote.Border.RightColor = System.Drawing.Color.Black
    Me.txtNote.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtNote.Border.TopColor = System.Drawing.Color.Black
    Me.txtNote.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtNote.Height = 0.1875!
    Me.txtNote.Left = 0.4375!
    Me.txtNote.Name = "txtNote"
    Me.txtNote.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
    Me.txtNote.Text = Nothing
    Me.txtNote.Top = 0.1875!
    Me.txtNote.Width = 1.6875!
    '
    'txtTakeAway
    '
    Me.txtTakeAway.Border.BottomColor = System.Drawing.Color.Black
    Me.txtTakeAway.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtTakeAway.Border.LeftColor = System.Drawing.Color.Black
    Me.txtTakeAway.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtTakeAway.Border.RightColor = System.Drawing.Color.Black
    Me.txtTakeAway.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtTakeAway.Border.TopColor = System.Drawing.Color.Black
    Me.txtTakeAway.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtTakeAway.Height = 0.1875!
    Me.txtTakeAway.Left = 2.125!
    Me.txtTakeAway.Name = "txtTakeAway"
    Me.txtTakeAway.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Microsoft Sa" & _
        "ns Serif; "
    Me.txtTakeAway.Text = "T.A"
    Me.txtTakeAway.Top = 0.0!
    Me.txtTakeAway.Width = 0.25!
    '
    'txtTA
    '
    Me.txtTA.Border.BottomColor = System.Drawing.Color.Black
    Me.txtTA.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtTA.Border.LeftColor = System.Drawing.Color.Black
    Me.txtTA.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtTA.Border.RightColor = System.Drawing.Color.Black
    Me.txtTA.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtTA.Border.TopColor = System.Drawing.Color.Black
    Me.txtTA.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtTA.DataField = "MBTRANSDTISTAKEAWAY"
    Me.txtTA.Height = 0.125!
    Me.txtTA.Left = 0.0625!
    Me.txtTA.Name = "txtTA"
    Me.txtTA.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.txtTA.Text = Nothing
    Me.txtTA.Top = 0.25!
    Me.txtTA.Visible = False
    Me.txtTA.Width = 0.3125!
    '
    'txtNoteHidden
    '
    Me.txtNoteHidden.Border.BottomColor = System.Drawing.Color.Black
    Me.txtNoteHidden.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtNoteHidden.Border.LeftColor = System.Drawing.Color.Black
    Me.txtNoteHidden.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtNoteHidden.Border.RightColor = System.Drawing.Color.Black
    Me.txtNoteHidden.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtNoteHidden.Border.TopColor = System.Drawing.Color.Black
    Me.txtNoteHidden.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtNoteHidden.DataField = "MBTRANSDTITEMNOTE"
    Me.txtNoteHidden.Height = 0.125!
    Me.txtNoteHidden.Left = 2.1875!
    Me.txtNoteHidden.Name = "txtNoteHidden"
    Me.txtNoteHidden.Style = "ddo-char-set: 0; text-align: right; font-size: 8.25pt; font-family: Microsoft San" & _
        "s Serif; "
    Me.txtNoteHidden.Text = Nothing
    Me.txtNoteHidden.Top = 0.25!
    Me.txtNoteHidden.Visible = False
    Me.txtNoteHidden.Width = 0.3125!
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
    Me.SubReport1.Height = 0.0!
    Me.SubReport1.Left = 0.4375!
    Me.SubReport1.Name = "SubReport1"
    Me.SubReport1.Report = Nothing
    Me.SubReport1.ReportName = "SubReport1"
    Me.SubReport1.Top = 0.1875!
    Me.SubReport1.Width = 1.875!
    '
    'txtParentUID
    '
    Me.txtParentUID.Border.BottomColor = System.Drawing.Color.Black
    Me.txtParentUID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtParentUID.Border.LeftColor = System.Drawing.Color.Black
    Me.txtParentUID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtParentUID.Border.RightColor = System.Drawing.Color.Black
    Me.txtParentUID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtParentUID.Border.TopColor = System.Drawing.Color.Black
    Me.txtParentUID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
    Me.txtParentUID.DataField = "MBTRANSDTUID"
    Me.txtParentUID.Height = 0.125!
    Me.txtParentUID.Left = 2.0!
    Me.txtParentUID.Name = "txtParentUID"
    Me.txtParentUID.Style = ""
    Me.txtParentUID.Text = "TextBox2"
    Me.txtParentUID.Top = 0.125!
    Me.txtParentUID.Visible = False
    Me.txtParentUID.Width = 0.4375!
    '
    'GroupFooter1
    '
    Me.GroupFooter1.Height = 0.0!
    Me.GroupFooter1.Name = "GroupFooter1"
    '
    'Make_Order_Sub_Item
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
    CType(Me.ItemQty, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ItemName, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtNote, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtTakeAway, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtTA, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtNoteHidden, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.txtParentUID, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

  End Sub
    Friend WithEvents ItemQty As DataDynamics.ActiveReports.Label
    Friend WithEvents ItemName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNote As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTakeAway As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtTA As DataDynamics.ActiveReports.TextBox
    Friend WithEvents txtNoteHidden As DataDynamics.ActiveReports.TextBox
    Friend WithEvents SubReport1 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents txtParentUID As DataDynamics.ActiveReports.TextBox
End Class
