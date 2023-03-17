<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Reservation_Sub_Payment 
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
    Private WithEvents Detail1 As DataDynamics.ActiveReports.Detail
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Reservation_Sub_Payment))
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.NomorLabel = New DataDynamics.ActiveReports.Label
        Me.PaymentTotalLabel = New DataDynamics.ActiveReports.Label
        Me.BankNameLabel = New DataDynamics.ActiveReports.Label
        Me.CheqName = New DataDynamics.ActiveReports.Label
        Me.CheqNumber = New DataDynamics.ActiveReports.Label
        Me.PaymentTypeLabel = New DataDynamics.ActiveReports.TextBox
        Me.CheqNumberLabel = New DataDynamics.ActiveReports.TextBox
        Me.CheqNameLabel = New DataDynamics.ActiveReports.TextBox
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.PaymentNoText = New DataDynamics.ActiveReports.TextBox
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.NomorLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentTotalLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.BankNameLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheqName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheqNumber, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentTypeLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheqNumberLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CheqNameLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PaymentNoText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Detail1
        '
        Me.Detail1.CanShrink = True
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.NomorLabel, Me.PaymentTotalLabel, Me.BankNameLabel, Me.CheqName, Me.CheqNumber, Me.PaymentTypeLabel, Me.CheqNumberLabel, Me.CheqNameLabel})
        Me.Detail1.Height = 0.75!
        Me.Detail1.Name = "Detail1"
        '
        'NomorLabel
        '
        Me.NomorLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.NomorLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.NomorLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.NomorLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.NomorLabel.Border.RightColor = System.Drawing.Color.Black
        Me.NomorLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.NomorLabel.Border.TopColor = System.Drawing.Color.Black
        Me.NomorLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.NomorLabel.Height = 0.1875!
        Me.NomorLabel.HyperLink = Nothing
        Me.NomorLabel.Left = 0.0625!
        Me.NomorLabel.Name = "NomorLabel"
        Me.NomorLabel.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
            "-family: Microsoft Sans Serif; "
        Me.NomorLabel.Text = "-"
        Me.NomorLabel.Top = 0.0!
        Me.NomorLabel.Width = 0.3125!
        '
        'PaymentTotalLabel
        '
        Me.PaymentTotalLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.PaymentTotalLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentTotalLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.PaymentTotalLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentTotalLabel.Border.RightColor = System.Drawing.Color.Black
        Me.PaymentTotalLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentTotalLabel.Border.TopColor = System.Drawing.Color.Black
        Me.PaymentTotalLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentTotalLabel.DataField = "PBTRANSDTSUBVAL"
        Me.PaymentTotalLabel.Height = 0.1875!
        Me.PaymentTotalLabel.HyperLink = Nothing
        Me.PaymentTotalLabel.Left = 1.3125!
        Me.PaymentTotalLabel.Name = "PaymentTotalLabel"
        Me.PaymentTotalLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.PaymentTotalLabel.Text = "-"
        Me.PaymentTotalLabel.Top = 0.0!
        Me.PaymentTotalLabel.Width = 1.125!
        '
        'BankNameLabel
        '
        Me.BankNameLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.BankNameLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BankNameLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.BankNameLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BankNameLabel.Border.RightColor = System.Drawing.Color.Black
        Me.BankNameLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BankNameLabel.Border.TopColor = System.Drawing.Color.Black
        Me.BankNameLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.BankNameLabel.DataField = "VISAORCHEQUEBANKNAME"
        Me.BankNameLabel.Height = 0.1875!
        Me.BankNameLabel.HyperLink = Nothing
        Me.BankNameLabel.Left = 0.375!
        Me.BankNameLabel.Name = "BankNameLabel"
        Me.BankNameLabel.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
            "amily: Microsoft Sans Serif; "
        Me.BankNameLabel.Text = "-"
        Me.BankNameLabel.Top = 0.1875!
        Me.BankNameLabel.Visible = False
        Me.BankNameLabel.Width = 2.0625!
        '
        'CheqName
        '
        Me.CheqName.Border.BottomColor = System.Drawing.Color.Black
        Me.CheqName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqName.Border.LeftColor = System.Drawing.Color.Black
        Me.CheqName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqName.Border.RightColor = System.Drawing.Color.Black
        Me.CheqName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqName.Border.TopColor = System.Drawing.Color.Black
        Me.CheqName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqName.Height = 0.1875!
        Me.CheqName.HyperLink = Nothing
        Me.CheqName.Left = 0.375!
        Me.CheqName.Name = "CheqName"
        Me.CheqName.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
            "amily: Microsoft Sans Serif; "
        Me.CheqName.Text = "-"
        Me.CheqName.Top = 0.5625!
        Me.CheqName.Visible = False
        Me.CheqName.Width = 0.9375!
        '
        'CheqNumber
        '
        Me.CheqNumber.Border.BottomColor = System.Drawing.Color.Black
        Me.CheqNumber.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqNumber.Border.LeftColor = System.Drawing.Color.Black
        Me.CheqNumber.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqNumber.Border.RightColor = System.Drawing.Color.Black
        Me.CheqNumber.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqNumber.Border.TopColor = System.Drawing.Color.Black
        Me.CheqNumber.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqNumber.DataField = "VISAORCHEQUENUMBER"
        Me.CheqNumber.Height = 0.1875!
        Me.CheqNumber.HyperLink = Nothing
        Me.CheqNumber.Left = 0.375!
        Me.CheqNumber.Name = "CheqNumber"
        Me.CheqNumber.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
            "amily: Microsoft Sans Serif; "
        Me.CheqNumber.Text = "-"
        Me.CheqNumber.Top = 0.375!
        Me.CheqNumber.Visible = False
        Me.CheqNumber.Width = 0.9375!
        '
        'PaymentTypeLabel
        '
        Me.PaymentTypeLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.PaymentTypeLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentTypeLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.PaymentTypeLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentTypeLabel.Border.RightColor = System.Drawing.Color.Black
        Me.PaymentTypeLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentTypeLabel.Border.TopColor = System.Drawing.Color.Black
        Me.PaymentTypeLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentTypeLabel.DataField = "PAYMENTTYPENAME"
        Me.PaymentTypeLabel.Height = 0.1875!
        Me.PaymentTypeLabel.Left = 0.375!
        Me.PaymentTypeLabel.Name = "PaymentTypeLabel"
        Me.PaymentTypeLabel.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Microsoft Sans" & _
            " Serif; "
        Me.PaymentTypeLabel.Text = "-"
        Me.PaymentTypeLabel.Top = 0.0!
        Me.PaymentTypeLabel.Width = 0.9375!
        '
        'CheqNumberLabel
        '
        Me.CheqNumberLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.CheqNumberLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqNumberLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.CheqNumberLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqNumberLabel.Border.RightColor = System.Drawing.Color.Black
        Me.CheqNumberLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqNumberLabel.Border.TopColor = System.Drawing.Color.Black
        Me.CheqNumberLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqNumberLabel.DataField = "VISAORCHEQUENUMBER"
        Me.CheqNumberLabel.Height = 0.1875!
        Me.CheqNumberLabel.Left = 1.3125!
        Me.CheqNumberLabel.Name = "CheqNumberLabel"
        Me.CheqNumberLabel.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Microsoft Sans" & _
            " Serif; "
        Me.CheqNumberLabel.Text = "-"
        Me.CheqNumberLabel.Top = 0.375!
        Me.CheqNumberLabel.Width = 1.125!
        '
        'CheqNameLabel
        '
        Me.CheqNameLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.CheqNameLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqNameLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.CheqNameLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqNameLabel.Border.RightColor = System.Drawing.Color.Black
        Me.CheqNameLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqNameLabel.Border.TopColor = System.Drawing.Color.Black
        Me.CheqNameLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.CheqNameLabel.DataField = "VISAORCHEQUENAME"
        Me.CheqNameLabel.Height = 0.1875!
        Me.CheqNameLabel.Left = 1.3125!
        Me.CheqNameLabel.Name = "CheqNameLabel"
        Me.CheqNameLabel.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Microsoft Sans" & _
            " Serif; "
        Me.CheqNameLabel.Text = "-"
        Me.CheqNameLabel.Top = 0.5625!
        Me.CheqNameLabel.Width = 1.125!
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.PaymentNoText, Me.Label1})
        Me.GroupHeader1.DataField = "PBTRANSNO"
        Me.GroupHeader1.Height = 0.2!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'PaymentNoText
        '
        Me.PaymentNoText.Border.BottomColor = System.Drawing.Color.Black
        Me.PaymentNoText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentNoText.Border.LeftColor = System.Drawing.Color.Black
        Me.PaymentNoText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentNoText.Border.RightColor = System.Drawing.Color.Black
        Me.PaymentNoText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentNoText.Border.TopColor = System.Drawing.Color.Black
        Me.PaymentNoText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.PaymentNoText.DataField = "PBTRANSNO"
        Me.PaymentNoText.Height = 0.1875!
        Me.PaymentNoText.Left = 0.0625!
        Me.PaymentNoText.Name = "PaymentNoText"
        Me.PaymentNoText.Style = "ddo-char-set: 0; text-align: left; font-size: 8.25pt; font-family: Microsoft Sans" & _
            " Serif; "
        Me.PaymentNoText.Text = "-"
        Me.PaymentNoText.Top = 0.0!
        Me.PaymentNoText.Width = 1.1875!
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
        Me.Label1.DataField = "PBTRANSDATE"
        Me.Label1.Height = 0.1875!
        Me.Label1.HyperLink = Nothing
        Me.Label1.Left = 1.25!
        Me.Label1.Name = "Label1"
        Me.Label1.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.Label1.Text = "-"
        Me.Label1.Top = 0.0!
        Me.Label1.Width = 1.1875!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Reservation_Sub_Payment
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.5!
        Me.ScriptLanguage = "VB.NET"
        Me.Sections.Add(Me.GroupHeader1)
        Me.Sections.Add(Me.Detail1)
        Me.Sections.Add(Me.GroupFooter1)
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Arial; font-style: normal; text-decoration: none; font-weight: norma" & _
                    "l; font-size: 10pt; color: Black; ", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 16pt; font-weight: bold; ", "Heading1", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-family: Times New Roman; font-size: 14pt; font-weight: bold; font-style: ita" & _
                    "lic; ", "Heading2", "Normal"))
        Me.StyleSheet.Add(New DDCssLib.StyleSheetRule("font-size: 13pt; font-weight: bold; ", "Heading3", "Normal"))
        CType(Me.NomorLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentTotalLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.BankNameLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheqName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheqNumber, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentTypeLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheqNumberLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CheqNameLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PaymentNoText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents NomorLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents PaymentTotalLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents BankNameLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents CheqName As DataDynamics.ActiveReports.Label
    Friend WithEvents CheqNumber As DataDynamics.ActiveReports.Label
    Friend WithEvents PaymentTypeLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CheqNumberLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CheqNameLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents PaymentNoText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
End Class 
