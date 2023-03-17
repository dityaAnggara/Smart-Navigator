<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Public Class CheckIn
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
        Dim resources As System.Resources.ResourceManager = New System.Resources.ResourceManager(GetType(CheckIn))
        Me.Line2 = New DataDynamics.ActiveReports.Line
        Me.Detail1 = New DataDynamics.ActiveReports.Detail
        Me.Label3 = New DataDynamics.ActiveReports.Label
        Me.Label2 = New DataDynamics.ActiveReports.Label
        Me.Label1 = New DataDynamics.ActiveReports.Label
        Me.lblLamaSewa = New DataDynamics.ActiveReports.Label
        Me.lblJamCheckOut = New DataDynamics.ActiveReports.Label
        Me.ReservationPrintUserLabel = New DataDynamics.ActiveReports.TextBox
        Me.lblHargaPerJam = New DataDynamics.ActiveReports.Label
        Me.ReservationNoLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationDateLabel = New DataDynamics.ActiveReports.Label
        Me.CurrentDateLabel = New DataDynamics.ActiveReports.Label
        Me.TransactionDateLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationPaxLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationTimeLabel = New DataDynamics.ActiveReports.Label
        Me.TransactionUID = New DataDynamics.ActiveReports.Label
        Me.ReservationServiceNameLabel = New DataDynamics.ActiveReports.Label
        Me.ReservationPrinterCounterLabel = New DataDynamics.ActiveReports.Label
        Me.Line1 = New DataDynamics.ActiveReports.Line
        Me.ReservationTableText = New DataDynamics.ActiveReports.TextBox
        Me.ReservationCustomerNameText = New DataDynamics.ActiveReports.TextBox
        Me.ReservationCreatedUserLabel = New DataDynamics.ActiveReports.TextBox
        Me.FooterText = New DataDynamics.ActiveReports.TextBox
        Me.Line5 = New DataDynamics.ActiveReports.Line
        Me.Line6 = New DataDynamics.ActiveReports.Line
        Me.Label5 = New DataDynamics.ActiveReports.Label
        Me.Label6 = New DataDynamics.ActiveReports.Label
        Me.lblNamaTable = New DataDynamics.ActiveReports.Label
        Me.lblNamaKategoriTable = New DataDynamics.ActiveReports.Label
        Me.Label4 = New DataDynamics.ActiveReports.Label
        Me.lblPaxFemale = New DataDynamics.ActiveReports.Label
        Me.lblShift = New DataDynamics.ActiveReports.Label
        Me.PageHeader1 = New DataDynamics.ActiveReports.PageHeader
        Me.CompanyNameText = New DataDynamics.ActiveReports.TextBox
        Me.CompanyAddressText = New DataDynamics.ActiveReports.TextBox
        Me.CompanyPhoneText = New DataDynamics.ActiveReports.TextBox
        Me.PageFooter1 = New DataDynamics.ActiveReports.PageFooter
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblLamaSewa, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblJamCheckOut, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationPrintUserLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblHargaPerJam, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationNoLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CurrentDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionDateLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationPaxLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationTimeLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TransactionUID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationServiceNameLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationPrinterCounterLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationTableText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationCustomerNameText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.ReservationCreatedUserLabel, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.FooterText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNamaTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblNamaKategoriTable, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblPaxFemale, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblShift, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyNameText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyAddressText, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CompanyPhoneText, System.ComponentModel.ISupportInitialize).BeginInit()
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
        Me.Line2.Top = 0.65625!
        Me.Line2.Width = 2.375!
        Me.Line2.X1 = 0.0625!
        Me.Line2.X2 = 2.4375!
        Me.Line2.Y1 = 0.65625!
        Me.Line2.Y2 = 0.65625!
        '
        'Detail1
        '
        Me.Detail1.ColumnSpacing = 0.0!
        Me.Detail1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Label3, Me.Label2, Me.Label1, Me.lblLamaSewa, Me.lblJamCheckOut, Me.ReservationPrintUserLabel, Me.lblHargaPerJam, Me.ReservationNoLabel, Me.ReservationDateLabel, Me.CurrentDateLabel, Me.TransactionDateLabel, Me.ReservationPaxLabel, Me.ReservationTimeLabel, Me.TransactionUID, Me.ReservationServiceNameLabel, Me.ReservationPrinterCounterLabel, Me.Line1, Me.ReservationTableText, Me.ReservationCustomerNameText, Me.ReservationCreatedUserLabel, Me.FooterText, Me.Line5, Me.Line6, Me.Label5, Me.Label6, Me.lblNamaTable, Me.lblNamaKategoriTable, Me.Label4, Me.lblPaxFemale, Me.lblShift})
        Me.Detail1.Height = 3.53125!
        Me.Detail1.Name = "Detail1"
        '
        'Label3
        '
        Me.Label3.Border.BottomColor = System.Drawing.Color.Black
        Me.Label3.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.LeftColor = System.Drawing.Color.Black
        Me.Label3.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.RightColor = System.Drawing.Color.Black
        Me.Label3.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Border.TopColor = System.Drawing.Color.Black
        Me.Label3.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label3.Height = 0.1875!
        Me.Label3.HyperLink = Nothing
        Me.Label3.Left = 0.0625!
        Me.Label3.Name = "Label3"
        Me.Label3.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
            "-family: Microsoft Sans Serif; vertical-align: middle; "
        Me.Label3.Text = "BOOKING CANNOT BE CANCELLED"
        Me.Label3.Top = 2.0!
        Me.Label3.Width = 2.375!
        '
        'Label2
        '
        Me.Label2.Border.BottomColor = System.Drawing.Color.Black
        Me.Label2.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.LeftColor = System.Drawing.Color.Black
        Me.Label2.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.RightColor = System.Drawing.Color.Black
        Me.Label2.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Border.TopColor = System.Drawing.Color.Black
        Me.Label2.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label2.Height = 0.1875!
        Me.Label2.HyperLink = Nothing
        Me.Label2.Left = 0.0625!
        Me.Label2.Name = "Label2"
        Me.Label2.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
            "-family: Microsoft Sans Serif; vertical-align: middle; "
        Me.Label2.Text = "NOT OUT SIDE FOOD & DRINK ALLOWED"
        Me.Label2.Top = 1.8125!
        Me.Label2.Width = 2.375!
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
        Me.Label1.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
            "-family: Microsoft Sans Serif; "
        Me.Label1.Text = "THANK YOU FOR COMING"
        Me.Label1.Top = 1.625!
        Me.Label1.Width = 2.375!
        '
        'lblLamaSewa
        '
        Me.lblLamaSewa.Border.BottomColor = System.Drawing.Color.Black
        Me.lblLamaSewa.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblLamaSewa.Border.LeftColor = System.Drawing.Color.Black
        Me.lblLamaSewa.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblLamaSewa.Border.RightColor = System.Drawing.Color.Black
        Me.lblLamaSewa.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblLamaSewa.Border.TopColor = System.Drawing.Color.Black
        Me.lblLamaSewa.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblLamaSewa.DataField = "ttlMenit"
        Me.lblLamaSewa.Height = 0.1875!
        Me.lblLamaSewa.HyperLink = Nothing
        Me.lblLamaSewa.Left = 0.0625!
        Me.lblLamaSewa.Name = "lblLamaSewa"
        Me.lblLamaSewa.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Microsoft S" & _
            "ans Serif; "
        Me.lblLamaSewa.Text = "-"
        Me.lblLamaSewa.Top = 1.3125!
        Me.lblLamaSewa.Width = 1.3125!
        '
        'lblJamCheckOut
        '
        Me.lblJamCheckOut.Border.BottomColor = System.Drawing.Color.Black
        Me.lblJamCheckOut.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblJamCheckOut.Border.LeftColor = System.Drawing.Color.Black
        Me.lblJamCheckOut.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblJamCheckOut.Border.RightColor = System.Drawing.Color.Black
        Me.lblJamCheckOut.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblJamCheckOut.Border.TopColor = System.Drawing.Color.Black
        Me.lblJamCheckOut.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblJamCheckOut.DataField = "jamHabis"
        Me.lblJamCheckOut.Height = 0.1875!
        Me.lblJamCheckOut.HyperLink = Nothing
        Me.lblJamCheckOut.Left = 1.375!
        Me.lblJamCheckOut.Name = "lblJamCheckOut"
        Me.lblJamCheckOut.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.lblJamCheckOut.Text = "-"
        Me.lblJamCheckOut.Top = 1.3125!
        Me.lblJamCheckOut.Width = 1.0625!
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
        Me.ReservationPrintUserLabel.Top = 3.0625!
        Me.ReservationPrintUserLabel.Width = 1.25!
        '
        'lblHargaPerJam
        '
        Me.lblHargaPerJam.Border.BottomColor = System.Drawing.Color.Black
        Me.lblHargaPerJam.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblHargaPerJam.Border.LeftColor = System.Drawing.Color.Black
        Me.lblHargaPerJam.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblHargaPerJam.Border.RightColor = System.Drawing.Color.Black
        Me.lblHargaPerJam.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblHargaPerJam.Border.TopColor = System.Drawing.Color.Black
        Me.lblHargaPerJam.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblHargaPerJam.DataField = "DefaultHarga"
        Me.lblHargaPerJam.Height = 0.1875!
        Me.lblHargaPerJam.HyperLink = Nothing
        Me.lblHargaPerJam.Left = 0.0625!
        Me.lblHargaPerJam.Name = "lblHargaPerJam"
        Me.lblHargaPerJam.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Microsoft S" & _
            "ans Serif; "
        Me.lblHargaPerJam.Text = "-"
        Me.lblHargaPerJam.Top = 0.9375!
        Me.lblHargaPerJam.Width = 1.625!
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
        Me.ReservationNoLabel.DataField = "MBTRANSNO"
        Me.ReservationNoLabel.Height = 0.1875!
        Me.ReservationNoLabel.HyperLink = Nothing
        Me.ReservationNoLabel.Left = 0.0625!
        Me.ReservationNoLabel.Name = "ReservationNoLabel"
        Me.ReservationNoLabel.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Microsoft S" & _
            "ans Serif; "
        Me.ReservationNoLabel.Text = "-"
        Me.ReservationNoLabel.Top = 0.75!
        Me.ReservationNoLabel.Width = 0.9375!
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
        Me.ReservationDateLabel.DataField = "ttlSewa"
        Me.ReservationDateLabel.Height = 0.1875!
        Me.ReservationDateLabel.HyperLink = Nothing
        Me.ReservationDateLabel.Left = 0.0625!
        Me.ReservationDateLabel.Name = "ReservationDateLabel"
        Me.ReservationDateLabel.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Microsoft S" & _
            "ans Serif; "
        Me.ReservationDateLabel.Text = "-"
        Me.ReservationDateLabel.Top = 1.125!
        Me.ReservationDateLabel.Width = 1.3125!
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
        Me.CurrentDateLabel.Left = 1.3125!
        Me.CurrentDateLabel.Name = "CurrentDateLabel"
        Me.CurrentDateLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; vertical-align: top; "
        Me.CurrentDateLabel.Text = "-"
        Me.CurrentDateLabel.Top = 3.0625!
        Me.CurrentDateLabel.Width = 1.125!
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
        Me.TransactionDateLabel.DataField = "MBTRANSDATE"
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
        Me.ReservationPaxLabel.DataField = "totalMale"
        Me.ReservationPaxLabel.Height = 0.1875!
        Me.ReservationPaxLabel.HyperLink = Nothing
        Me.ReservationPaxLabel.Left = 0.375!
        Me.ReservationPaxLabel.Name = "ReservationPaxLabel"
        Me.ReservationPaxLabel.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Microsoft S" & _
            "ans Serif; "
        Me.ReservationPaxLabel.Text = "10 MALE"
        Me.ReservationPaxLabel.Top = 0.1875!
        Me.ReservationPaxLabel.Width = 0.9375!
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
        Me.ReservationTimeLabel.DataField = "MBTRANSSTARTTIME"
        Me.ReservationTimeLabel.Height = 0.1875!
        Me.ReservationTimeLabel.HyperLink = Nothing
        Me.ReservationTimeLabel.Left = 1.375!
        Me.ReservationTimeLabel.Name = "ReservationTimeLabel"
        Me.ReservationTimeLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.ReservationTimeLabel.Text = "-"
        Me.ReservationTimeLabel.Top = 1.125!
        Me.ReservationTimeLabel.Width = 1.0625!
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
        Me.TransactionUID.DataField = "MBTRANSUID"
        Me.TransactionUID.Height = 0.1875!
        Me.TransactionUID.HyperLink = Nothing
        Me.TransactionUID.Left = 0.125!
        Me.TransactionUID.Name = "TransactionUID"
        Me.TransactionUID.Style = "text-align: center; "
        Me.TransactionUID.Text = "UID"
        Me.TransactionUID.Top = 3.125!
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
        Me.ReservationServiceNameLabel.DataField = "nmService"
        Me.ReservationServiceNameLabel.Height = 0.1875!
        Me.ReservationServiceNameLabel.HyperLink = Nothing
        Me.ReservationServiceNameLabel.Left = 1.3125!
        Me.ReservationServiceNameLabel.Name = "ReservationServiceNameLabel"
        Me.ReservationServiceNameLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.ReservationServiceNameLabel.Text = "-"
        Me.ReservationServiceNameLabel.Top = 0.9375!
        Me.ReservationServiceNameLabel.Width = 1.125!
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
        Me.ReservationPrinterCounterLabel.Left = 1.4375!
        Me.ReservationPrinterCounterLabel.Name = "ReservationPrinterCounterLabel"
        Me.ReservationPrinterCounterLabel.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.ReservationPrinterCounterLabel.Text = "-"
        Me.ReservationPrinterCounterLabel.Top = 0.375!
        Me.ReservationPrinterCounterLabel.Width = 1.0!
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
        Me.Line1.Top = 2.25!
        Me.Line1.Width = 2.375!
        Me.Line1.X1 = 0.0625!
        Me.Line1.X2 = 2.4375!
        Me.Line1.Y1 = 2.25!
        Me.Line1.Y2 = 2.25!
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
        Me.ReservationCustomerNameText.DataField = "nmCust"
        Me.ReservationCustomerNameText.Height = 0.1875!
        Me.ReservationCustomerNameText.Left = 1.0!
        Me.ReservationCustomerNameText.Name = "ReservationCustomerNameText"
        Me.ReservationCustomerNameText.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
            "-family: Microsoft Sans Serif; "
        Me.ReservationCustomerNameText.Text = "-"
        Me.ReservationCustomerNameText.Top = 0.75!
        Me.ReservationCustomerNameText.Width = 1.4375!
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
        Me.ReservationCreatedUserLabel.Left = 0.0625!
        Me.ReservationCreatedUserLabel.Name = "ReservationCreatedUserLabel"
        Me.ReservationCreatedUserLabel.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
            "amily: Microsoft Sans Serif; "
        Me.ReservationCreatedUserLabel.Text = "-"
        Me.ReservationCreatedUserLabel.Top = 0.5625!
        Me.ReservationCreatedUserLabel.Width = 1.375!
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
        Me.FooterText.Top = 3.3125!
        Me.FooterText.Width = 2.375!
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
        Me.Line5.Top = 3.03125!
        Me.Line5.Width = 2.375!
        Me.Line5.X1 = 0.0625!
        Me.Line5.X2 = 2.4375!
        Me.Line5.Y1 = 3.03125!
        Me.Line5.Y2 = 3.03125!
        '
        'Line6
        '
        Me.Line6.Border.BottomColor = System.Drawing.Color.Black
        Me.Line6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line6.Border.LeftColor = System.Drawing.Color.Black
        Me.Line6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line6.Border.RightColor = System.Drawing.Color.Black
        Me.Line6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line6.Border.TopColor = System.Drawing.Color.Black
        Me.Line6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Line6.Height = 0.0!
        Me.Line6.Left = 0.0625!
        Me.Line6.LineWeight = 2.0!
        Me.Line6.Name = "Line6"
        Me.Line6.Top = 1.5625!
        Me.Line6.Width = 2.375!
        Me.Line6.X1 = 0.0625!
        Me.Line6.X2 = 2.4375!
        Me.Line6.Y1 = 1.5625!
        Me.Line6.Y2 = 1.5625!
        '
        'Label5
        '
        Me.Label5.Border.BottomColor = System.Drawing.Color.Black
        Me.Label5.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.LeftColor = System.Drawing.Color.Black
        Me.Label5.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.RightColor = System.Drawing.Color.Black
        Me.Label5.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Border.TopColor = System.Drawing.Color.Black
        Me.Label5.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label5.Height = 0.1875!
        Me.Label5.HyperLink = Nothing
        Me.Label5.Left = 1.25!
        Me.Label5.Name = "Label5"
        Me.Label5.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
            "amily: Microsoft Sans Serif; "
        Me.Label5.Text = "SINCERELY,"
        Me.Label5.Top = 2.3125!
        Me.Label5.Width = 1.1875!
        '
        'Label6
        '
        Me.Label6.Border.BottomColor = System.Drawing.Color.Black
        Me.Label6.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.LeftColor = System.Drawing.Color.Black
        Me.Label6.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.RightColor = System.Drawing.Color.Black
        Me.Label6.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Border.TopColor = System.Drawing.Color.Black
        Me.Label6.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label6.Height = 0.1875!
        Me.Label6.HyperLink = Nothing
        Me.Label6.Left = 1.25!
        Me.Label6.Name = "Label6"
        Me.Label6.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
            "amily: Microsoft Sans Serif; "
        Me.Label6.Text = "(________________)"
        Me.Label6.Top = 2.8125!
        Me.Label6.Width = 1.1875!
        '
        'lblNamaTable
        '
        Me.lblNamaTable.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNamaTable.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNamaTable.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNamaTable.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNamaTable.Border.RightColor = System.Drawing.Color.Black
        Me.lblNamaTable.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNamaTable.Border.TopColor = System.Drawing.Color.Black
        Me.lblNamaTable.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNamaTable.DataField = "TABLELISTNAME"
        Me.lblNamaTable.Height = 0.1875!
        Me.lblNamaTable.HyperLink = Nothing
        Me.lblNamaTable.Left = 0.0!
        Me.lblNamaTable.Name = "lblNamaTable"
        Me.lblNamaTable.Style = "text-align: center; "
        Me.lblNamaTable.Text = "UID"
        Me.lblNamaTable.Top = 0.0!
        Me.lblNamaTable.Visible = False
        Me.lblNamaTable.Width = 0.375!
        '
        'lblNamaKategoriTable
        '
        Me.lblNamaKategoriTable.Border.BottomColor = System.Drawing.Color.Black
        Me.lblNamaKategoriTable.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNamaKategoriTable.Border.LeftColor = System.Drawing.Color.Black
        Me.lblNamaKategoriTable.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNamaKategoriTable.Border.RightColor = System.Drawing.Color.Black
        Me.lblNamaKategoriTable.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNamaKategoriTable.Border.TopColor = System.Drawing.Color.Black
        Me.lblNamaKategoriTable.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblNamaKategoriTable.DataField = "TABLELISTCATNAME"
        Me.lblNamaKategoriTable.Height = 0.1875!
        Me.lblNamaKategoriTable.HyperLink = Nothing
        Me.lblNamaKategoriTable.Left = 0.375!
        Me.lblNamaKategoriTable.Name = "lblNamaKategoriTable"
        Me.lblNamaKategoriTable.Style = "text-align: center; "
        Me.lblNamaKategoriTable.Text = "UID"
        Me.lblNamaKategoriTable.Top = 0.0!
        Me.lblNamaKategoriTable.Visible = False
        Me.lblNamaKategoriTable.Width = 0.4375!
        '
        'Label4
        '
        Me.Label4.Border.BottomColor = System.Drawing.Color.Black
        Me.Label4.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.LeftColor = System.Drawing.Color.Black
        Me.Label4.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.RightColor = System.Drawing.Color.Black
        Me.Label4.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Border.TopColor = System.Drawing.Color.Black
        Me.Label4.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.Label4.Height = 0.1875!
        Me.Label4.HyperLink = Nothing
        Me.Label4.Left = 0.0625!
        Me.Label4.Name = "Label4"
        Me.Label4.Style = "ddo-char-set: 0; text-align: left; font-weight: normal; font-size: 8.25pt; font-f" & _
            "amily: Microsoft Sans Serif; "
        Me.Label4.Text = "PAX :"
        Me.Label4.Top = 0.1875!
        Me.Label4.Width = 0.3125!
        '
        'lblPaxFemale
        '
        Me.lblPaxFemale.Border.BottomColor = System.Drawing.Color.Black
        Me.lblPaxFemale.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPaxFemale.Border.LeftColor = System.Drawing.Color.Black
        Me.lblPaxFemale.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPaxFemale.Border.RightColor = System.Drawing.Color.Black
        Me.lblPaxFemale.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPaxFemale.Border.TopColor = System.Drawing.Color.Black
        Me.lblPaxFemale.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblPaxFemale.DataField = "totalFemale"
        Me.lblPaxFemale.Height = 0.1875!
        Me.lblPaxFemale.HyperLink = Nothing
        Me.lblPaxFemale.Left = 0.375!
        Me.lblPaxFemale.Name = "lblPaxFemale"
        Me.lblPaxFemale.Style = "ddo-char-set: 0; font-weight: normal; font-size: 8.25pt; font-family: Microsoft S" & _
            "ans Serif; "
        Me.lblPaxFemale.Text = "10 FEMALE"
        Me.lblPaxFemale.Top = 0.375!
        Me.lblPaxFemale.Visible = False
        Me.lblPaxFemale.Width = 0.6875!
        '
        'lblShift
        '
        Me.lblShift.Border.BottomColor = System.Drawing.Color.Black
        Me.lblShift.Border.BottomStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblShift.Border.LeftColor = System.Drawing.Color.Black
        Me.lblShift.Border.LeftStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblShift.Border.RightColor = System.Drawing.Color.Black
        Me.lblShift.Border.RightStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblShift.Border.TopColor = System.Drawing.Color.Black
        Me.lblShift.Border.TopStyle = DataDynamics.ActiveReports.BorderLineStyle.None
        Me.lblShift.DataField = "MBTRANSSHIFTNO"
        Me.lblShift.Height = 0.1875!
        Me.lblShift.HyperLink = Nothing
        Me.lblShift.Left = 1.4375!
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Style = "ddo-char-set: 0; text-align: right; font-weight: normal; font-size: 8.25pt; font-" & _
            "family: Microsoft Sans Serif; "
        Me.lblShift.Text = "-"
        Me.lblShift.Top = 0.5625!
        Me.lblShift.Width = 1.0!
        '
        'PageHeader1
        '
        Me.PageHeader1.Controls.AddRange(New DataDynamics.ActiveReports.ARControl() {Me.Line2, Me.CompanyNameText, Me.CompanyAddressText, Me.CompanyPhoneText})
        Me.PageHeader1.Height = 0.7!
        Me.PageHeader1.Name = "PageHeader1"
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
        Me.CompanyAddressText.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
            "-family: Microsoft Sans Serif; "
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
        Me.CompanyPhoneText.Style = "ddo-char-set: 0; text-align: center; font-weight: normal; font-size: 8.25pt; font" & _
            "-family: Microsoft Sans Serif; "
        Me.CompanyPhoneText.Text = "Company Phone/Fax"
        Me.CompanyPhoneText.Top = 0.4375!
        Me.CompanyPhoneText.Width = 2.375!
        '
        'PageFooter1
        '
        Me.PageFooter1.Height = 0.0!
        Me.PageFooter1.Name = "PageFooter1"
        '
        'CheckIn
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
        Me.UserData = ""
        CType(Me.Label3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblLamaSewa, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblJamCheckOut, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationPrintUserLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblHargaPerJam, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationNoLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CurrentDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionDateLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationPaxLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationTimeLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TransactionUID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationServiceNameLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationPrinterCounterLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationTableText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationCustomerNameText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.ReservationCreatedUserLabel, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.FooterText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label5, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label6, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNamaTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblNamaKategoriTable, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Label4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblPaxFemale, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblShift, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyNameText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyAddressText, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CompanyPhoneText, System.ComponentModel.ISupportInitialize).EndInit()
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
    Friend WithEvents TransactionUID As DataDynamics.ActiveReports.Label
    Private WithEvents PageHeader1 As DataDynamics.ActiveReports.PageHeader
    Private WithEvents PageFooter1 As DataDynamics.ActiveReports.PageFooter
    Friend WithEvents lblHargaPerJam As DataDynamics.ActiveReports.Label
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
    Friend WithEvents lblLamaSewa As DataDynamics.ActiveReports.Label
    Friend WithEvents lblJamCheckOut As DataDynamics.ActiveReports.Label
    Friend WithEvents Line6 As DataDynamics.ActiveReports.Line
    Friend WithEvents Label1 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label2 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label3 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label5 As DataDynamics.ActiveReports.Label
    Friend WithEvents Label6 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNamaTable As DataDynamics.ActiveReports.Label
    Friend WithEvents lblNamaKategoriTable As DataDynamics.ActiveReports.Label
    Friend WithEvents Label4 As DataDynamics.ActiveReports.Label
    Friend WithEvents lblPaxFemale As DataDynamics.ActiveReports.Label
    Friend WithEvents lblShift As DataDynamics.ActiveReports.Label
End Class
