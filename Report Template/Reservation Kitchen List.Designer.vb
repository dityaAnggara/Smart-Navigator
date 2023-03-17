<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Reservation_Kitchen_List 
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Reservation_Kitchen_List))
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.ReservationCustNoLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationNoLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationDateLabel = New DataDynamics.ActiveReports.Label
        Me.TransactionDateLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationPaxLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationTimeLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationServiceNameLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationPrinterCounterLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationTableText = New DataDynamics.ActiveReports.TextBox
        Me.ReservationCustomerNameText = New DataDynamics.ActiveReports.TextBox
        Me.ReservationCreatedUserLabel = New DataDynamics.ActiveReports.TextBox
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.TextBox1 = New DataDynamics.ActiveReports.TextBox
        Me.KitchenQty = New DataDynamics.ActiveReports.Label
        Me.TransactionUID = New DataDynamics.ActiveReports.Label
        Me.KitchenTakeAway = New DataDynamics.ActiveReports.Label
        Me.KitchenItemName = New DataDynamics.ActiveReports.TextBox
        Me.KitchenItemNotes = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        Me.ReportHeader1 = New DataDynamics.ActiveReports.ReportHeader
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.CompanyNameText = New DataDynamics.ActiveReports.TextBox
        Me.CompanyAddressText = New DataDynamics.ActiveReports.TextBox
        Me.CompanyPhoneText = New DataDynamics.ActiveReports.TextBox
        Me.ReportFooter1 = New DataDynamics.ActiveReports.ReportFooter
        Me.GroupHeader1 = New DataDynamics.ActiveReports.GroupHeader
        Me.No = New DataDynamics.ActiveReports.Label
        Me.GroupFooter1 = New DataDynamics.ActiveReports.GroupFooter
        CType(Me.ReservationCustNoLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationNoLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationPaxLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationTimeLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationServiceNameLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationPrinterCounterLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationTableText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationCustomerNameText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationCreatedUserLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KitchenQty, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionUID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KitchenTakeAway, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KitchenItemName, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KitchenItemNotes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyNameText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyAddressText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyPhoneText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.No, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReservationCustNoLabel, Me.ReservationNoLabel, Me.ReservationDateLabel, Me.TransactionDateLabel, Me.ReservationPaxLabel, Me.ReservationTimeLabel, Me.ReservationServiceNameLabel, Me.ReservationPrinterCounterLabel, Me.ReservationTableText, Me.ReservationCustomerNameText, Me.ReservationCreatedUserLabel, Me.Line3})
        Me.PageHeader1.Height = 1.0!
        Me.PageHeader1.Name = "PageHeader1"
        '
        'ReservationCustNoLabel
        '
        Me.ReservationCustNoLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationCustNoLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationCustNoLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationCustNoLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationCustNoLabel.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationCustNoLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationCustNoLabel.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationCustNoLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationCustNoLabel.DataField = "CUSTNO"
        Me.ReservationCustNoLabel.Height = 0.1875!
        Me.ReservationCustNoLabel.HyperLink = Nothing
        Me.ReservationCustNoLabel.Left = 0.0625!
        Me.ReservationCustNoLabel.Name = "ReservationCustNoLabel"
        Me.ReservationCustNoLabel.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Microsoft S" & _
            "ans Serif; "
        Me.ReservationCustNoLabel.Text = "-"
        Me.ReservationCustNoLabel.Top = 0.5625!
        Me.ReservationCustNoLabel.Width = 0.625!
        '
        'ReservationNoLabel
        '
        Me.ReservationNoLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationNoLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationNoLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationNoLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationNoLabel.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationNoLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationNoLabel.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationNoLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationNoLabel.DataField = "RSVTRANSNO"
        Me.ReservationNoLabel.Height = 0.1875!
        Me.ReservationNoLabel.HyperLink = Nothing
        Me.ReservationNoLabel.Left = 0.0625!
        Me.ReservationNoLabel.Name = "ReservationNoLabel"
        Me.ReservationNoLabel.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Microsoft S" & _
            "ans Serif; "
        Me.ReservationNoLabel.Text = "-"
        Me.ReservationNoLabel.Top = 0.1875!
        Me.ReservationNoLabel.Width = 1.25!
        '
        'ReservationDateLabel
        '
        Me.ReservationDateLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationDateLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationDateLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationDateLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationDateLabel.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationDateLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationDateLabel.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationDateLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationDateLabel.DataField = "RSVTRANSRESERVEDDATE"
        Me.ReservationDateLabel.Height = 0.1875!
        Me.ReservationDateLabel.HyperLink = Nothing
        Me.ReservationDateLabel.Left = 0.0625!
        Me.ReservationDateLabel.Name = "ReservationDateLabel"
        Me.ReservationDateLabel.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Microsoft S" & _
            "ans Serif; "
        Me.ReservationDateLabel.Text = "-"
        Me.ReservationDateLabel.Top = 0.75!
        Me.ReservationDateLabel.Width = 1.375!
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
        Me.TransactionDateLabel.DataField = "RSVTRANSDATE"
        Me.TransactionDateLabel.Height = 0.1875!
        Me.TransactionDateLabel.HyperLink = Nothing
        Me.TransactionDateLabel.Left = 1.3125!
        Me.TransactionDateLabel.Name = "TransactionDateLabel"
        Me.TransactionDateLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.TransactionDateLabel.Text = "-"
        Me.TransactionDateLabel.Top = 0.1875!
        Me.TransactionDateLabel.Width = 1.125!
        '
        'ReservationPaxLabel
        '
        Me.ReservationPaxLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationPaxLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationPaxLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationPaxLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationPaxLabel.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationPaxLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationPaxLabel.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationPaxLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationPaxLabel.DataField = "RSVTRANSPAXVAL"
        Me.ReservationPaxLabel.Height = 0.1875!
        Me.ReservationPaxLabel.HyperLink = Nothing
        Me.ReservationPaxLabel.Left = 0.0625!
        Me.ReservationPaxLabel.Name = "ReservationPaxLabel"
        Me.ReservationPaxLabel.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Microsoft S" & _
            "ans Serif; "
        Me.ReservationPaxLabel.Text = "-"
        Me.ReservationPaxLabel.Top = 0.375!
        Me.ReservationPaxLabel.Width = 0.625!
        '
        'ReservationTimeLabel
        '
        Me.ReservationTimeLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationTimeLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationTimeLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationTimeLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationTimeLabel.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationTimeLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationTimeLabel.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationTimeLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationTimeLabel.DataField = "RSVTRANSRESERVEDTIME"
        Me.ReservationTimeLabel.Height = 0.1875!
        Me.ReservationTimeLabel.HyperLink = Nothing
        Me.ReservationTimeLabel.Left = 1.4375!
        Me.ReservationTimeLabel.Name = "ReservationTimeLabel"
        Me.ReservationTimeLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.ReservationTimeLabel.Text = "-"
        Me.ReservationTimeLabel.Top = 0.75!
        Me.ReservationTimeLabel.Width = 1.0!
        '
        'ReservationServiceNameLabel
        '
        Me.ReservationServiceNameLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationServiceNameLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationServiceNameLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationServiceNameLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationServiceNameLabel.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationServiceNameLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationServiceNameLabel.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationServiceNameLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationServiceNameLabel.DataField = "SERVICENAME"
        Me.ReservationServiceNameLabel.Height = 0.1875!
        Me.ReservationServiceNameLabel.HyperLink = Nothing
        Me.ReservationServiceNameLabel.Left = 1.6875!
        Me.ReservationServiceNameLabel.Name = "ReservationServiceNameLabel"
        Me.ReservationServiceNameLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.ReservationServiceNameLabel.Text = "-"
        Me.ReservationServiceNameLabel.Top = 0.5625!
        Me.ReservationServiceNameLabel.Width = 0.75!
        '
        'ReservationPrinterCounterLabel
        '
        Me.ReservationPrinterCounterLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationPrinterCounterLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationPrinterCounterLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationPrinterCounterLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationPrinterCounterLabel.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationPrinterCounterLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationPrinterCounterLabel.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationPrinterCounterLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationPrinterCounterLabel.DataField = "PRINTCOUNTER"
        Me.ReservationPrinterCounterLabel.Height = 0.1875!
        Me.ReservationPrinterCounterLabel.HyperLink = Nothing
        Me.ReservationPrinterCounterLabel.Left = 1.6875!
        Me.ReservationPrinterCounterLabel.Name = "ReservationPrinterCounterLabel"
        Me.ReservationPrinterCounterLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.ReservationPrinterCounterLabel.Text = "-"
        Me.ReservationPrinterCounterLabel.Top = 0.375!
        Me.ReservationPrinterCounterLabel.Width = 0.75!
        '
        'ReservationTableText
        '
        Me.ReservationTableText.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationTableText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationTableText.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationTableText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationTableText.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationTableText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationTableText.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationTableText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationTableText.Height = 0.1875!
        Me.ReservationTableText.Left = 0.0625!
        Me.ReservationTableText.Name = "ReservationTableText"
        Me.ReservationTableText.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
            "-family: Microsoft Sans Serif; "
        Me.ReservationTableText.Text = "-"
        Me.ReservationTableText.Top = 0.0!
        Me.ReservationTableText.Width = 2.375!
        '
        'ReservationCustomerNameText
        '
        Me.ReservationCustomerNameText.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationCustomerNameText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationCustomerNameText.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationCustomerNameText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationCustomerNameText.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationCustomerNameText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationCustomerNameText.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationCustomerNameText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationCustomerNameText.DataField = "RSVTRANSCUSTNAME"
        Me.ReservationCustomerNameText.Height = 0.188!
        Me.ReservationCustomerNameText.Left = 0.6875!
        Me.ReservationCustomerNameText.Name = "ReservationCustomerNameText"
        Me.ReservationCustomerNameText.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
            "-family: Microsoft Sans Serif; "
        Me.ReservationCustomerNameText.Text = "-"
        Me.ReservationCustomerNameText.Top = 0.5625!
        Me.ReservationCustomerNameText.Width = 1.0!
        '
        'ReservationCreatedUserLabel
        '
        Me.ReservationCreatedUserLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationCreatedUserLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationCreatedUserLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationCreatedUserLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationCreatedUserLabel.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationCreatedUserLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationCreatedUserLabel.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationCreatedUserLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationCreatedUserLabel.DataField = "CREATEDUSER"
        Me.ReservationCreatedUserLabel.Height = 0.188!
        Me.ReservationCreatedUserLabel.Left = 0.6875!
        Me.ReservationCreatedUserLabel.Name = "ReservationCreatedUserLabel"
        Me.ReservationCreatedUserLabel.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
            "-family: Microsoft Sans Serif; "
        Me.ReservationCreatedUserLabel.Text = "-"
        Me.ReservationCreatedUserLabel.Top = 0.375!
        Me.ReservationCreatedUserLabel.Width = 1.0!
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
        Me.Line3.LineWeight = 3.0!
        Me.Line3.Name = "Line3"
        Me.Line3.Top = 0.96875!
        Me.Line3.Width = 2.375!
        Me.Line3.X1 = 0.0625!
        Me.Line3.X2 = 2.4375!
        Me.Line3.Y1 = 0.96875!
        Me.Line3.Y2 = 0.96875!
        '
        'Detail1
        '
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
        'KitchenQty
        '
        Me.KitchenQty.Border.BottomColor = System.Drawing.Color.Black
        Me.KitchenQty.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenQty.Border.LeftColor = System.Drawing.Color.Black
        Me.KitchenQty.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenQty.Border.RightColor = System.Drawing.Color.Black
        Me.KitchenQty.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenQty.Border.TopColor = System.Drawing.Color.Black
        Me.KitchenQty.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenQty.DataField = "RSVTRANSDTITEMQTY"
        Me.KitchenQty.Height = 0.1875!
        Me.KitchenQty.HyperLink = Nothing
        Me.KitchenQty.Left = 0.0625!
        Me.KitchenQty.Name = "KitchenQty"
        Me.KitchenQty.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Microsoft Sa" & _
            "ns Serif; "
        Me.KitchenQty.Text = "-"
        Me.KitchenQty.Top = 0.0!
        Me.KitchenQty.Width = 0.25!
        '
        'TransactionUID
        '
        Me.TransactionUID.Border.BottomColor = System.Drawing.Color.Black
        Me.TransactionUID.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TransactionUID.Border.LeftColor = System.Drawing.Color.Black
        Me.TransactionUID.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TransactionUID.Border.RightColor = System.Drawing.Color.Black
        Me.TransactionUID.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TransactionUID.Border.TopColor = System.Drawing.Color.Black
        Me.TransactionUID.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.TransactionUID.DataField = "RSVTRANSUID"
        Me.TransactionUID.Height = 0.1875!
        Me.TransactionUID.HyperLink = Nothing
        Me.TransactionUID.Left = 0.0625!
        Me.TransactionUID.Name = "TransactionUID"
        Me.TransactionUID.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
        Me.TransactionUID.Text = "UID"
        Me.TransactionUID.Top = 0.1875!
        Me.TransactionUID.Visible = False
        Me.TransactionUID.Width = 0.25!
        '
        'KitchenTakeAway
        '
        Me.KitchenTakeAway.Border.BottomColor = System.Drawing.Color.Black
        Me.KitchenTakeAway.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenTakeAway.Border.LeftColor = System.Drawing.Color.Black
        Me.KitchenTakeAway.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenTakeAway.Border.RightColor = System.Drawing.Color.Black
        Me.KitchenTakeAway.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenTakeAway.Border.TopColor = System.Drawing.Color.Black
        Me.KitchenTakeAway.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenTakeAway.DataField = "RSVTRANSDTISTAKEAWAY"
        Me.KitchenTakeAway.Height = 0.1875!
        Me.KitchenTakeAway.HyperLink = Nothing
        Me.KitchenTakeAway.Left = 2.0!
        Me.KitchenTakeAway.Name = "KitchenTakeAway"
        Me.KitchenTakeAway.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Microsoft Sa" & _
            "ns Serif; "
        Me.KitchenTakeAway.Text = "-"
        Me.KitchenTakeAway.Top = 0.0!
        Me.KitchenTakeAway.Width = 0.4375!
        '
        'KitchenItemName
        '
        Me.KitchenItemName.Border.BottomColor = System.Drawing.Color.Black
        Me.KitchenItemName.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenItemName.Border.LeftColor = System.Drawing.Color.Black
        Me.KitchenItemName.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenItemName.Border.RightColor = System.Drawing.Color.Black
        Me.KitchenItemName.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenItemName.Border.TopColor = System.Drawing.Color.Black
        Me.KitchenItemName.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenItemName.DataField = "RSVTRANSDTITEMNAME"
        Me.KitchenItemName.Height = 0.1875!
        Me.KitchenItemName.Left = 0.3125!
        Me.KitchenItemName.Name = "KitchenItemName"
        Me.KitchenItemName.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
        Me.KitchenItemName.Text = "-"
        Me.KitchenItemName.Top = 0.0!
        Me.KitchenItemName.Width = 1.6875!
        '
        'KitchenItemNotes
        '
        Me.KitchenItemNotes.Border.BottomColor = System.Drawing.Color.Black
        Me.KitchenItemNotes.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenItemNotes.Border.LeftColor = System.Drawing.Color.Black
        Me.KitchenItemNotes.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenItemNotes.Border.RightColor = System.Drawing.Color.Black
        Me.KitchenItemNotes.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenItemNotes.Border.TopColor = System.Drawing.Color.Black
        Me.KitchenItemNotes.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.KitchenItemNotes.DataField = "RSVTRANSDTITEMNOTE"
        Me.KitchenItemNotes.Height = 0.1875!
        Me.KitchenItemNotes.Left = 0.3125!
        Me.KitchenItemNotes.Name = "KitchenItemNotes"
        Me.KitchenItemNotes.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
        Me.KitchenItemNotes.Text = "-"
        Me.KitchenItemNotes.Top = 0.1875!
        Me.KitchenItemNotes.Width = 1.6875!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'ReportHeader1
        '
        Me.ReportHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2, Me.CompanyNameText, Me.CompanyAddressText, Me.CompanyPhoneText})
        Me.ReportHeader1.Height = 0.7!
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
        Me.Line2.Top = 0.65625!
        Me.Line2.Width = 2.375!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 2.4375!
        Me.Line2.Y1 = 0.65625!
        Me.Line2.Y2 = 0.65625!
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
        Me.CompanyAddressText.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Microsoft Sa" & _
            "ns Serif; "
        Me.CompanyAddressText.Text = "Company Address"
        Me.CompanyAddressText.Top = 0.25!
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
        Me.CompanyPhoneText.Style = "ddo-char-set: 0; text-align: center; font-size: 8.25pt; font-family: Microsoft Sa" & _
            "ns Serif; "
        Me.CompanyPhoneText.Text = "Company Phone/Fax"
        Me.CompanyPhoneText.Top = 0.4375!
        Me.CompanyPhoneText.Width = 2.375!
        '
        'ReportFooter1
        '
        Me.ReportFooter1.Height = 0.0!
        Me.ReportFooter1.Name = "ReportFooter1"
        '
        'GroupHeader1
        '
        Me.GroupHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.KitchenItemName, Me.KitchenTakeAway, Me.KitchenQty, Me.KitchenItemNotes, Me.TransactionUID, Me.No})
        Me.GroupHeader1.DataField = "RSVTRANSDTITEMNAME"
        Me.GroupHeader1.Height = 0.2!
        Me.GroupHeader1.Name = "GroupHeader1"
        '
        'No
        '
        Me.No.Border.BottomColor = System.Drawing.Color.Black
        Me.No.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.No.Border.LeftColor = System.Drawing.Color.Black
        Me.No.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.No.Border.RightColor = System.Drawing.Color.Black
        Me.No.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.No.Border.TopColor = System.Drawing.Color.Black
        Me.No.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.No.Height = 0.1875!
        Me.No.HyperLink = Nothing
        Me.No.Left = 2.0!
        Me.No.Name = "No"
        Me.No.Style = "ddo-char-set: 0; font-size: 8.25pt; font-family: Microsoft Sans Serif; "
        Me.No.Text = "0"
        Me.No.Top = 0.1875!
        Me.No.Visible = False
        Me.No.Width = 0.4375!
        '
        'GroupFooter1
        '
        Me.GroupFooter1.Height = 0.0!
        Me.GroupFooter1.Name = "GroupFooter1"
        '
        'Reservation_Kitchen_List
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
        CType(Me.ReservationCustNoLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationNoLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationPaxLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationTimeLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationServiceNameLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationPrinterCounterLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationTableText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationCustomerNameText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationCreatedUserLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TextBox1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KitchenQty, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionUID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KitchenTakeAway, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KitchenItemName, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KitchenItemNotes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyNameText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyAddressText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyPhoneText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.No, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents ReportHeader1 As DataDynamics.ActiveReports.ReportHeader
    Friend WithEvents ReportFooter1 As DataDynamics.ActiveReports.ReportFooter
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents CompanyNameText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyAddressText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyPhoneText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents KitchenQty As DataDynamics.ActiveReports.Label
    Friend WithEvents TransactionUID As DataDynamics.ActiveReports.Label
    Friend WithEvents KitchenTakeAway As DataDynamics.ActiveReports.Label
    Friend WithEvents KitchenItemName As DataDynamics.ActiveReports.TextBox
    Friend WithEvents KitchenItemNotes As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReservationCustNoLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationNoLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationDateLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents TransactionDateLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationPaxLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationTimeLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationServiceNameLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationPrinterCounterLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationTableText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReservationCustomerNameText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReservationCreatedUserLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents GroupHeader1 As DataDynamics.ActiveReports.GroupHeader
    Friend WithEvents GroupFooter1 As DataDynamics.ActiveReports.GroupFooter
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents TextBox1 As DataDynamics.ActiveReports.TextBox
    Friend WithEvents No As DataDynamics.ActiveReports.Label
End Class
