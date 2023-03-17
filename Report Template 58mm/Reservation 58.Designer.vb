<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class Reservation58
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(Reservation58))
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.ReservationCustNoLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationDateLabel = New DataDynamics.ActiveReports.Label
        Me.CurrentDateLabel = New DataDynamics.ActiveReports.Label
        Me.TransactionDateLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationPaxLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationTimeLabel = New DataDynamics.ActiveReports.Label
        Me.Label16 = New DataDynamics.ActiveReports.Label
        Me.Label20 = New DataDynamics.ActiveReports.Label
        Me.Label21 = New DataDynamics.ActiveReports.Label
        Me.SubReport1 = New DataDynamics.ActiveReports.SubReport
        Me.ReservationSubTotalLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationDownPaymentLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationTotalNetLabel = New DataDynamics.ActiveReports.Label
        Me.SubReport2 = New DataDynamics.ActiveReports.SubReport
        Me.TransactionUID = New DataDynamics.ActiveReports.Label
        Me.ReservationServiceNameLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationPrinterCounterLabel = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.Line4 = New DataDynamics.ActiveReports.Line
        Me.Line3 = New DataDynamics.ActiveReports.Line
        Me.ReservationTableText = New DataDynamics.ActiveReports.TextBox
        Me.ReservationCustomerNameText = New DataDynamics.ActiveReports.TextBox
        Me.ReservationCreatedUserLabel = New DataDynamics.ActiveReports.TextBox
        Me.FooterText = New DataDynamics.ActiveReports.TextBox
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.ReservationNoLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationPrintUserLabel = New DataDynamics.ActiveReports.TextBox
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.CompanyPhoneText = New DataDynamics.ActiveReports.TextBox
        Me.CompanyNameText = New DataDynamics.ActiveReports.TextBox
        Me.CompanyAddressText = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        CType(Me.ReservationCustNoLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrentDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationPaxLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationTimeLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationSubTotalLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationDownPaymentLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationTotalNetLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionUID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationServiceNameLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationPrinterCounterLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationTableText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationCustomerNameText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationCreatedUserLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FooterText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationNoLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationPrintUserLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyPhoneText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyNameText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyAddressText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Line2.Top = 0.5625!
        Me.Line2.Width = 1.8125!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 1.875!
        Me.Line2.Y1 = 0.5625!
        Me.Line2.Y2 = 0.5625!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.ReservationNoLabel, Me.ReservationCustNoLabel, Me.ReservationDateLabel, Me.CurrentDateLabel, Me.TransactionDateLabel, Me.ReservationPaxLabel, Me.ReservationTimeLabel, Me.Label16, Me.Label20, Me.Label21, Me.SubReport1, Me.ReservationSubTotalLabel, Me.ReservationDownPaymentLabel, Me.ReservationTotalNetLabel, Me.SubReport2, Me.TransactionUID, Me.ReservationServiceNameLabel, Me.ReservationPrinterCounterLabel, Me.Line1, Me.Line4, Me.Line3, Me.ReservationTableText, Me.ReservationCustomerNameText, Me.ReservationCreatedUserLabel, Me.FooterText, Me.Line5, Me.ReservationPrintUserLabel})
        Me.Detail1.Height = 3.15625!
        Me.Detail1.Name = "Detail1"
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
        Me.ReservationCustNoLabel.Top = 0.75!
        Me.ReservationCustNoLabel.Width = 0.5!
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
        Me.ReservationDateLabel.Top = 1.125!
        Me.ReservationDateLabel.Width = 1.8125!
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
        Me.CurrentDateLabel.Left = 1.0!
        Me.CurrentDateLabel.Name = "CurrentDateLabel"
        Me.CurrentDateLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Lucida Console; vertical-align: top; "
        Me.CurrentDateLabel.Text = "-"
        Me.CurrentDateLabel.Top = 2.4375!
        Me.CurrentDateLabel.Visible = False
        Me.CurrentDateLabel.Width = 0.875!
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
        Me.TransactionDateLabel.Left = 0.0625!
        Me.TransactionDateLabel.Name = "TransactionDateLabel"
        Me.TransactionDateLabel.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
            "amily: Microsoft Sans Serif; "
        Me.TransactionDateLabel.Text = "-"
        Me.TransactionDateLabel.Top = 0.375!
        Me.TransactionDateLabel.Width = 1.8125!
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
        Me.ReservationPaxLabel.Top = 0.5625!
        Me.ReservationPaxLabel.Width = 0.5!
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
        Me.ReservationTimeLabel.Top = 1.125!
        Me.ReservationTimeLabel.Visible = False
        Me.ReservationTimeLabel.Width = 0.4375!
        '
        'Label16
        '
        Me.Label16.Border.BottomColor = System.Drawing.Color.Black
        Me.Label16.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Border.LeftColor = System.Drawing.Color.Black
        Me.Label16.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Border.RightColor = System.Drawing.Color.Black
        Me.Label16.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Border.TopColor = System.Drawing.Color.Black
        Me.Label16.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label16.Height = 0.1875!
        Me.Label16.HyperLink = Nothing
        Me.Label16.Left = 0.0625!
        Me.Label16.Name = "Label16"
        Me.Label16.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.Label16.Text = "Sub Total : "
        Me.Label16.Top = 1.8125!
        Me.Label16.Width = 0.8125!
        '
        'Label20
        '
        Me.Label20.Border.BottomColor = System.Drawing.Color.Black
        Me.Label20.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label20.Border.LeftColor = System.Drawing.Color.Black
        Me.Label20.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label20.Border.RightColor = System.Drawing.Color.Black
        Me.Label20.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label20.Border.TopColor = System.Drawing.Color.Black
        Me.Label20.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label20.Height = 0.1875!
        Me.Label20.HyperLink = Nothing
        Me.Label20.Left = 0.0625!
        Me.Label20.Name = "Label20"
        Me.Label20.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.Label20.Text = "DP : "
        Me.Label20.Top = 2.0!
        Me.Label20.Width = 0.8125!
        '
        'Label21
        '
        Me.Label21.Border.BottomColor = System.Drawing.Color.Black
        Me.Label21.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Border.LeftColor = System.Drawing.Color.Black
        Me.Label21.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Border.RightColor = System.Drawing.Color.Black
        Me.Label21.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Border.TopColor = System.Drawing.Color.Black
        Me.Label21.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label21.Height = 0.1875!
        Me.Label21.HyperLink = Nothing
        Me.Label21.Left = 0.0625!
        Me.Label21.Name = "Label21"
        Me.Label21.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.Label21.Text = "Total (Net) : "
        Me.Label21.Top = 2.1875!
        Me.Label21.Width = 0.8125!
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
        Me.SubReport1.CanShrink = False
        Me.SubReport1.CloseBorder = False
        Me.SubReport1.Height = 0.375!
        Me.SubReport1.Left = 0.0!
        Me.SubReport1.Name = "SubReport1"
        Me.SubReport1.Report = Nothing
        Me.SubReport1.ReportName = ""
        Me.SubReport1.Top = 1.375!
        Me.SubReport1.Width = 2.0!
        '
        'ReservationSubTotalLabel
        '
        Me.ReservationSubTotalLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationSubTotalLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationSubTotalLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationSubTotalLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationSubTotalLabel.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationSubTotalLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationSubTotalLabel.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationSubTotalLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationSubTotalLabel.DataField = "RSVTRANSSUBVAL"
        Me.ReservationSubTotalLabel.Height = 0.1875!
        Me.ReservationSubTotalLabel.HyperLink = Nothing
        Me.ReservationSubTotalLabel.Left = 0.875!
        Me.ReservationSubTotalLabel.Name = "ReservationSubTotalLabel"
        Me.ReservationSubTotalLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 9pt; font-fam" & _
            "ily: Microsoft Sans Serif; "
        Me.ReservationSubTotalLabel.Text = "-"
        Me.ReservationSubTotalLabel.Top = 1.8125!
        Me.ReservationSubTotalLabel.Width = 1.0!
        '
        'ReservationDownPaymentLabel
        '
        Me.ReservationDownPaymentLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationDownPaymentLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationDownPaymentLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationDownPaymentLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationDownPaymentLabel.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationDownPaymentLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationDownPaymentLabel.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationDownPaymentLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationDownPaymentLabel.DataField = "RSVTRANSDPVAL"
        Me.ReservationDownPaymentLabel.Height = 0.1875!
        Me.ReservationDownPaymentLabel.HyperLink = Nothing
        Me.ReservationDownPaymentLabel.Left = 0.875!
        Me.ReservationDownPaymentLabel.Name = "ReservationDownPaymentLabel"
        Me.ReservationDownPaymentLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 9pt; font-fam" & _
            "ily: Microsoft Sans Serif; "
        Me.ReservationDownPaymentLabel.Text = "-"
        Me.ReservationDownPaymentLabel.Top = 2.0!
        Me.ReservationDownPaymentLabel.Width = 1.0!
        '
        'ReservationTotalNetLabel
        '
        Me.ReservationTotalNetLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationTotalNetLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationTotalNetLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationTotalNetLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationTotalNetLabel.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationTotalNetLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationTotalNetLabel.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationTotalNetLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationTotalNetLabel.Height = 0.1875!
        Me.ReservationTotalNetLabel.HyperLink = Nothing
        Me.ReservationTotalNetLabel.Left = 0.875!
        Me.ReservationTotalNetLabel.Name = "ReservationTotalNetLabel"
        Me.ReservationTotalNetLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 9pt; font-fam" & _
            "ily: Microsoft Sans Serif; "
        Me.ReservationTotalNetLabel.Text = "-"
        Me.ReservationTotalNetLabel.Top = 2.1875!
        Me.ReservationTotalNetLabel.Width = 1.0!
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
        Me.SubReport2.ReportName = "SubReport2"
        Me.SubReport2.Top = 2.625!
        Me.SubReport2.Width = 2.0!
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
        Me.TransactionUID.Left = 0.125!
        Me.TransactionUID.Name = "TransactionUID"
        Me.TransactionUID.Style = "text-align: center; "
        Me.TransactionUID.Text = "UID"
        Me.TransactionUID.Top = 2.6875!
        Me.TransactionUID.Visible = False
        Me.TransactionUID.Width = 0.375!
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
        Me.ReservationServiceNameLabel.Left = 1.375!
        Me.ReservationServiceNameLabel.Name = "ReservationServiceNameLabel"
        Me.ReservationServiceNameLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.ReservationServiceNameLabel.Text = "-"
        Me.ReservationServiceNameLabel.Top = 0.9375!
        Me.ReservationServiceNameLabel.Width = 0.5!
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
        Me.ReservationPrinterCounterLabel.Left = 0.0625!
        Me.ReservationPrinterCounterLabel.Name = "ReservationPrinterCounterLabel"
        Me.ReservationPrinterCounterLabel.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
            "amily: Microsoft Sans Serif; "
        Me.ReservationPrinterCounterLabel.Text = "-"
        Me.ReservationPrinterCounterLabel.Top = 0.9375!
        Me.ReservationPrinterCounterLabel.Width = 0.75!
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
        Me.Line1.Top = 1.34!
        Me.Line1.Width = 1.8125!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 1.875!
        Me.Line1.Y1 = 1.34!
        Me.Line1.Y2 = 1.34!
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
        Me.Line4.Top = 2.4375!
        Me.Line4.Width = 1.8125!
        Me.Line4.X1 = 0.0625!
        Me.Line4.X2 = 1.875!
        Me.Line4.Y1 = 2.4375!
        Me.Line4.Y2 = 2.4375!
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
        Me.Line3.Top = 1.78!
        Me.Line3.Width = 1.8125!
        Me.Line3.X1 = 0.0625!
        Me.Line3.X2 = 1.875!
        Me.Line3.Y1 = 1.78!
        Me.Line3.Y2 = 1.78!
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
        Me.ReservationTableText.Width = 1.8125!
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
        Me.ReservationCustomerNameText.Height = 0.1875!
        Me.ReservationCustomerNameText.Left = 0.5625!
        Me.ReservationCustomerNameText.Name = "ReservationCustomerNameText"
        Me.ReservationCustomerNameText.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
            "amily: Microsoft Sans Serif; "
        Me.ReservationCustomerNameText.Text = "-"
        Me.ReservationCustomerNameText.Top = 0.75!
        Me.ReservationCustomerNameText.Width = 1.3125!
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
        Me.ReservationCreatedUserLabel.Height = 0.1875!
        Me.ReservationCreatedUserLabel.Left = 0.5625!
        Me.ReservationCreatedUserLabel.Name = "ReservationCreatedUserLabel"
        Me.ReservationCreatedUserLabel.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
            "amily: Microsoft Sans Serif; "
        Me.ReservationCreatedUserLabel.Text = "-"
        Me.ReservationCreatedUserLabel.Top = 0.5625!
        Me.ReservationCreatedUserLabel.Width = 1.3125!
        '
        'FooterText
        '
        Me.FooterText.Border.BottomColor = System.Drawing.Color.Black
        Me.FooterText.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FooterText.Border.LeftColor = System.Drawing.Color.Black
        Me.FooterText.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FooterText.Border.RightColor = System.Drawing.Color.Black
        Me.FooterText.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FooterText.Border.TopColor = System.Drawing.Color.Black
        Me.FooterText.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.FooterText.Height = 0.1875!
        Me.FooterText.Left = 0.0625!
        Me.FooterText.Name = "FooterText"
        Me.FooterText.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
            "-family: Microsoft Sans Serif; "
        Me.FooterText.Text = "-"
        Me.FooterText.Top = 2.9375!
        Me.FooterText.Width = 1.8125!
        '
        'Line5
        '
        Me.Line5.Border.BottomColor = System.Drawing.Color.Black
        Me.Line5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line5.Border.LeftColor = System.Drawing.Color.Black
        Me.Line5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line5.Border.RightColor = System.Drawing.Color.Black
        Me.Line5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line5.Border.TopColor = System.Drawing.Color.Black
        Me.Line5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line5.Height = 0.0!
        Me.Line5.Left = 0.0625!
        Me.Line5.LineWeight = 3.0!
        Me.Line5.Name = "Line5"
        Me.Line5.Top = 2.9!
        Me.Line5.Width = 1.8125!
        Me.Line5.X1 = 0.0625!
        Me.Line5.X2 = 1.875!
        Me.Line5.Y1 = 2.9!
        Me.Line5.Y2 = 2.9!
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
        Me.ReservationNoLabel.Width = 1.8125!
        '
        'ReservationPrintUserLabel
        '
        Me.ReservationPrintUserLabel.Border.BottomColor = System.Drawing.Color.Black
        Me.ReservationPrintUserLabel.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationPrintUserLabel.Border.LeftColor = System.Drawing.Color.Black
        Me.ReservationPrintUserLabel.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationPrintUserLabel.Border.RightColor = System.Drawing.Color.Black
        Me.ReservationPrintUserLabel.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationPrintUserLabel.Border.TopColor = System.Drawing.Color.Black
        Me.ReservationPrintUserLabel.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.ReservationPrintUserLabel.Height = 0.1875!
        Me.ReservationPrintUserLabel.Left = 0.0625!
        Me.ReservationPrintUserLabel.Name = "ReservationPrintUserLabel"
        Me.ReservationPrintUserLabel.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
            "amily: Microsoft Sans Serif; "
        Me.ReservationPrintUserLabel.Text = "-"
        Me.ReservationPrintUserLabel.Top = 2.4375!
        Me.ReservationPrintUserLabel.Width = 1.8125!
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.CompanyPhoneText, Me.Line2, Me.CompanyNameText, Me.CompanyAddressText})
        Me.PageHeader1.Height = 0.59375!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.CompanyPhoneText.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 9pt; font-fa" & _
            "mily: Microsoft Sans Serif; "
        Me.CompanyPhoneText.Text = "Company Phone/Fax"
        Me.CompanyPhoneText.Top = 0.375!
        Me.CompanyPhoneText.Width = 1.8125!
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
        Me.CompanyNameText.Height = 0.1875!
        Me.CompanyNameText.Left = 0.0625!
        Me.CompanyNameText.Name = "CompanyNameText"
        Me.CompanyNameText.Style = "ddo-char-set: 0; text-align: center; font-weight: bold; font-size: 11.25pt; font-" & _
            "family: Microsoft Sans Serif; "
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
        Me.CompanyAddressText.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 9pt; font-fa" & _
            "mily: Microsoft Sans Serif; "
        Me.CompanyAddressText.Text = "Company Address"
        Me.CompanyAddressText.Top = 0.1875!
        Me.CompanyAddressText.Width = 1.8125!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'Reservation58
        '
        Me.MasterReport = False
        Me.PageSettings.PaperHeight = 11.0!
        Me.PageSettings.PaperWidth = 8.5!
        Me.PrintWidth = 2.06425!
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
        Me.UserData = ""
        CType(Me.ReservationCustNoLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrentDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationPaxLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationTimeLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label16, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label20, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label21, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationSubTotalLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationDownPaymentLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationTotalNetLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionUID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationServiceNameLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationPrinterCounterLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationTableText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationCustomerNameText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationCreatedUserLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FooterText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationNoLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationPrintUserLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyPhoneText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyNameText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyAddressText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub
    Friend WithEvents Line2 As DataDynamics.ActiveReports.Line
    Friend WithEvents ReservationNoLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationDateLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents CurrentDateLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents TransactionDateLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationPaxLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationTimeLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents Line1 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label16 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label20 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label21 As DataDynamics.ActiveReports.Label
    Friend WithEvents SubReport1 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents ReservationSubTotalLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationDownPaymentLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationTotalNetLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents Line3 As DataDynamics.ActiveReports.Line
    Friend WithEvents Line4 As DataDynamics.ActiveReports.Line
    Friend WithEvents SubReport2 As DataDynamics.ActiveReports.SubReport
    Friend WithEvents TransactionUID As DataDynamics.ActiveReports.Label
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    Friend WithEvents ReservationCustNoLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationServiceNameLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationPrinterCounterLabel As DataDynamics.ActiveReports.Label
    Friend WithEvents ReservationTableText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyNameText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyAddressText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents CompanyPhoneText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReservationCustomerNameText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReservationCreatedUserLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents ReservationPrintUserLabel As DataDynamics.ActiveReports.TextBox
    Friend WithEvents FooterText As DataDynamics.ActiveReports.TextBox
    Friend WithEvents Line5 As DataDynamics.ActiveReports.Line
End Class
