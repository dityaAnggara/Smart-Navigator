<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Reservation_Rent
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Reservation_Rent))
        Me.GroupBox = New System.Windows.Forms.GroupBox
        Me.Print = New C1.Win.C1Input.C1Label
        Me.PrintCounter = New System.Windows.Forms.Label
        Me.Tax = New C1.Win.C1Input.C1Label
        Me.VirtualCurrentDate = New C1.Win.C1Input.C1Button
        Me.DateLabel = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.ReservationNo = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.CurrentDate = New System.Windows.Forms.DateTimePicker
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.lblTotalFood = New System.Windows.Forms.Label
        Me.DPTxt = New System.Windows.Forms.Label
        Me.BalanceDueTxt = New System.Windows.Forms.Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.lblHargaRoom = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Label18 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblEndHour = New System.Windows.Forms.Label
        Me.txtHour = New System.Windows.Forms.TextBox
        Me.cmdVirtualJam = New C1.Win.C1Input.C1Button
        Me.VirtualDate = New C1.Win.C1Input.C1Button
        Me.ReservationDateLabel = New System.Windows.Forms.Label
        Me.VirtualTime = New C1.Win.C1Input.C1Button
        Me.ReservationTimeLabel = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.ReservationTime = New System.Windows.Forms.DateTimePicker
        Me.ReservationDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.chkUseMultipleDP = New System.Windows.Forms.CheckBox
        Me.TotalVisitor = New System.Windows.Forms.TextBox
        Me.VirtualCalculator = New C1.Win.C1Input.C1Button
        Me.ServiceList = New C1.Win.C1List.C1Combo
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.TableCombo = New C1.Win.C1List.C1Combo
        Me.Label12 = New System.Windows.Forms.Label
        Me.FindCust = New C1.Win.C1Input.C1Button
        Me.VirtualKey = New C1.Win.C1Input.C1Button
        Me.CustName = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.CustomerList = New C1.Win.C1List.C1Combo
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BTNMoveDown = New C1.Win.C1Input.C1Button
        Me.BTNMoveUp = New C1.Win.C1Input.C1Button
        Me.TableList = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.Virtual2Key = New C1.Win.C1Input.C1Button
        Me.Note = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.BTNDownpayment = New C1.Win.C1Input.C1Button
        Me.BTNMakeOrder = New C1.Win.C1Input.C1Button
        Me.BTNList = New C1.Win.C1Input.C1Button
        Me.BTNCancel = New C1.Win.C1Input.C1Button
        Me.BTNSave = New C1.Win.C1Input.C1Button
        Me.BTNPrintOrder = New C1.Win.C1Input.C1Button
        Me.lblSisaDP = New System.Windows.Forms.Label
        Me.Label19 = New System.Windows.Forms.Label
        Me.GroupBox.SuspendLayout()
        CType(Me.Print, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tax, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox5.SuspendLayout()
        CType(Me.ServiceList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox6.SuspendLayout()
        CType(Me.TableCombo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox
        '
        Me.GroupBox.Controls.Add(Me.Print)
        Me.GroupBox.Controls.Add(Me.PrintCounter)
        Me.GroupBox.Controls.Add(Me.Tax)
        Me.GroupBox.Controls.Add(Me.VirtualCurrentDate)
        Me.GroupBox.Controls.Add(Me.DateLabel)
        Me.GroupBox.Controls.Add(Me.Label4)
        Me.GroupBox.Controls.Add(Me.ReservationNo)
        Me.GroupBox.Controls.Add(Me.Label1)
        Me.GroupBox.Controls.Add(Me.CurrentDate)
        Me.GroupBox.Location = New System.Drawing.Point(8, 2)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(400, 66)
        Me.GroupBox.TabIndex = 0
        Me.GroupBox.TabStop = False
        '
        'Print
        '
        Me.Print.Image = CType(resources.GetObject("Print.Image"), System.Drawing.Image)
        Me.Print.Location = New System.Drawing.Point(283, 14)
        Me.Print.Name = "Print"
        Me.Print.Size = New System.Drawing.Size(20, 20)
        Me.Print.TabIndex = 128
        Me.Print.Tag = Nothing
        Me.Print.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Print.Value = ""
        '
        'PrintCounter
        '
        Me.PrintCounter.AutoSize = True
        Me.PrintCounter.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PrintCounter.Location = New System.Drawing.Point(301, 17)
        Me.PrintCounter.Name = "PrintCounter"
        Me.PrintCounter.Size = New System.Drawing.Size(22, 16)
        Me.PrintCounter.TabIndex = 127
        Me.PrintCounter.Text = "10"
        Me.PrintCounter.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Tax
        '
        Me.Tax.Image = CType(resources.GetObject("Tax.Image"), System.Drawing.Image)
        Me.Tax.Location = New System.Drawing.Point(247, 8)
        Me.Tax.Name = "Tax"
        Me.Tax.Size = New System.Drawing.Size(30, 30)
        Me.Tax.TabIndex = 126
        Me.Tax.Tag = Nothing
        Me.Tax.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Tax.Value = ""
        Me.Tax.Visible = False
        '
        'VirtualCurrentDate
        '
        Me.VirtualCurrentDate.Image = CType(resources.GetObject("VirtualCurrentDate.Image"), System.Drawing.Image)
        Me.VirtualCurrentDate.Location = New System.Drawing.Point(335, 30)
        Me.VirtualCurrentDate.Name = "VirtualCurrentDate"
        Me.VirtualCurrentDate.Size = New System.Drawing.Size(50, 30)
        Me.VirtualCurrentDate.TabIndex = 111
        Me.VirtualCurrentDate.UseVisualStyleBackColor = True
        Me.VirtualCurrentDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'DateLabel
        '
        Me.DateLabel.AutoSize = True
        Me.DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateLabel.Location = New System.Drawing.Point(122, 42)
        Me.DateLabel.Name = "DateLabel"
        Me.DateLabel.Size = New System.Drawing.Size(75, 16)
        Me.DateLabel.TabIndex = 108
        Me.DateLabel.Text = "1 May 2010"
        Me.DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 44)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 106
        Me.Label4.Text = "Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ReservationNo
        '
        Me.ReservationNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservationNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.ReservationNo.Location = New System.Drawing.Point(122, 16)
        Me.ReservationNo.Name = "ReservationNo"
        Me.ReservationNo.Size = New System.Drawing.Size(158, 16)
        Me.ReservationNo.TabIndex = 14
        Me.ReservationNo.Text = "RSV0906230001"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 16)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "No."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CurrentDate
        '
        Me.CurrentDate.CalendarTrailingForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CurrentDate.CustomFormat = "dd.MM.yyyy, HH:mm:ss"
        Me.CurrentDate.Enabled = False
        Me.CurrentDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentDate.Location = New System.Drawing.Point(365, 36)
        Me.CurrentDate.Name = "CurrentDate"
        Me.CurrentDate.Size = New System.Drawing.Size(20, 22)
        Me.CurrentDate.TabIndex = 0
        Me.CurrentDate.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.lblSisaDP)
        Me.GroupBox2.Controls.Add(Me.Label19)
        Me.GroupBox2.Controls.Add(Me.DPTxt)
        Me.GroupBox2.Controls.Add(Me.BalanceDueTxt)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.lblHargaRoom)
        Me.GroupBox2.Controls.Add(Me.lblTotalFood)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 441)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(400, 97)
        Me.GroupBox2.TabIndex = 4
        Me.GroupBox2.TabStop = False
        '
        'lblTotalFood
        '
        Me.lblTotalFood.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalFood.ForeColor = System.Drawing.Color.Maroon
        Me.lblTotalFood.Location = New System.Drawing.Point(15, 33)
        Me.lblTotalFood.Name = "lblTotalFood"
        Me.lblTotalFood.Size = New System.Drawing.Size(213, 22)
        Me.lblTotalFood.TabIndex = 19
        Me.lblTotalFood.Text = "0"
        Me.lblTotalFood.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblTotalFood.Visible = False
        '
        'DPTxt
        '
        Me.DPTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DPTxt.ForeColor = System.Drawing.Color.Maroon
        Me.DPTxt.Location = New System.Drawing.Point(143, 42)
        Me.DPTxt.Name = "DPTxt"
        Me.DPTxt.Size = New System.Drawing.Size(242, 17)
        Me.DPTxt.TabIndex = 16
        Me.DPTxt.Text = "0"
        Me.DPTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'BalanceDueTxt
        '
        Me.BalanceDueTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BalanceDueTxt.ForeColor = System.Drawing.Color.Maroon
        Me.BalanceDueTxt.Location = New System.Drawing.Point(143, 16)
        Me.BalanceDueTxt.Name = "BalanceDueTxt"
        Me.BalanceDueTxt.Size = New System.Drawing.Size(242, 17)
        Me.BalanceDueTxt.TabIndex = 15
        Me.BalanceDueTxt.Text = "0"
        Me.BalanceDueTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label15.ForeColor = System.Drawing.Color.Maroon
        Me.Label15.Location = New System.Drawing.Point(15, 44)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(117, 15)
        Me.Label15.TabIndex = 10
        Me.Label15.Text = "DOWN PAYMENT"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label13.ForeColor = System.Drawing.Color.Maroon
        Me.Label13.Location = New System.Drawing.Point(15, 18)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(77, 15)
        Me.Label13.TabIndex = 8
        Me.Label13.Text = "SUBTOTAL"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblHargaRoom
        '
        Me.lblHargaRoom.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHargaRoom.ForeColor = System.Drawing.Color.Maroon
        Me.lblHargaRoom.Location = New System.Drawing.Point(15, 0)
        Me.lblHargaRoom.Name = "lblHargaRoom"
        Me.lblHargaRoom.Size = New System.Drawing.Size(228, 18)
        Me.lblHargaRoom.TabIndex = 18
        Me.lblHargaRoom.Text = "0"
        Me.lblHargaRoom.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblHargaRoom.Visible = False
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Label18)
        Me.GroupBox3.Controls.Add(Me.Label17)
        Me.GroupBox3.Controls.Add(Me.Label16)
        Me.GroupBox3.Controls.Add(Me.lblEndHour)
        Me.GroupBox3.Controls.Add(Me.txtHour)
        Me.GroupBox3.Controls.Add(Me.cmdVirtualJam)
        Me.GroupBox3.Controls.Add(Me.VirtualDate)
        Me.GroupBox3.Controls.Add(Me.ReservationDateLabel)
        Me.GroupBox3.Controls.Add(Me.VirtualTime)
        Me.GroupBox3.Controls.Add(Me.ReservationTimeLabel)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Controls.Add(Me.ReservationTime)
        Me.GroupBox3.Controls.Add(Me.ReservationDate)
        Me.GroupBox3.Controls.Add(Me.Label2)
        Me.GroupBox3.Location = New System.Drawing.Point(8, 69)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(400, 129)
        Me.GroupBox3.TabIndex = 1
        Me.GroupBox3.TabStop = False
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Enabled = False
        Me.Label18.Location = New System.Drawing.Point(15, 93)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(30, 13)
        Me.Label18.TabIndex = 117
        Me.Label18.Text = "Rent"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Enabled = False
        Me.Label17.Location = New System.Drawing.Point(111, 93)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(30, 13)
        Me.Label17.TabIndex = 116
        Me.Label17.Text = "Mnts"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Enabled = False
        Me.Label16.Location = New System.Drawing.Point(167, 93)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 115
        Me.Label16.Text = "End Hour"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEndHour
        '
        Me.lblEndHour.AutoSize = True
        Me.lblEndHour.Enabled = False
        Me.lblEndHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndHour.Location = New System.Drawing.Point(226, 93)
        Me.lblEndHour.Name = "lblEndHour"
        Me.lblEndHour.Size = New System.Drawing.Size(97, 16)
        Me.lblEndHour.TabIndex = 114
        Me.lblEndHour.Text = "00 : 00 : 00 : AM"
        Me.lblEndHour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtHour
        '
        Me.txtHour.BackColor = System.Drawing.Color.White
        Me.txtHour.Enabled = False
        Me.txtHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHour.Location = New System.Drawing.Point(56, 87)
        Me.txtHour.MaxLength = 3
        Me.txtHour.Name = "txtHour"
        Me.txtHour.Size = New System.Drawing.Size(50, 26)
        Me.txtHour.TabIndex = 113
        Me.txtHour.Text = "0"
        Me.txtHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdVirtualJam
        '
        Me.cmdVirtualJam.Enabled = False
        Me.cmdVirtualJam.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdVirtualJam.Image = CType(resources.GetObject("cmdVirtualJam.Image"), System.Drawing.Image)
        Me.cmdVirtualJam.Location = New System.Drawing.Point(335, 85)
        Me.cmdVirtualJam.Name = "cmdVirtualJam"
        Me.cmdVirtualJam.Size = New System.Drawing.Size(50, 32)
        Me.cmdVirtualJam.TabIndex = 112
        Me.cmdVirtualJam.UseVisualStyleBackColor = True
        Me.cmdVirtualJam.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Silver
        '
        'VirtualDate
        '
        Me.VirtualDate.Image = CType(resources.GetObject("VirtualDate.Image"), System.Drawing.Image)
        Me.VirtualDate.Location = New System.Drawing.Point(335, 12)
        Me.VirtualDate.Name = "VirtualDate"
        Me.VirtualDate.Size = New System.Drawing.Size(50, 30)
        Me.VirtualDate.TabIndex = 110
        Me.VirtualDate.UseVisualStyleBackColor = True
        Me.VirtualDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ReservationDateLabel
        '
        Me.ReservationDateLabel.AutoSize = True
        Me.ReservationDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservationDateLabel.Location = New System.Drawing.Point(122, 19)
        Me.ReservationDateLabel.Name = "ReservationDateLabel"
        Me.ReservationDateLabel.Size = New System.Drawing.Size(75, 16)
        Me.ReservationDateLabel.TabIndex = 109
        Me.ReservationDateLabel.Text = "1 May 2010"
        Me.ReservationDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VirtualTime
        '
        Me.VirtualTime.Image = CType(resources.GetObject("VirtualTime.Image"), System.Drawing.Image)
        Me.VirtualTime.Location = New System.Drawing.Point(335, 47)
        Me.VirtualTime.Name = "VirtualTime"
        Me.VirtualTime.Size = New System.Drawing.Size(50, 30)
        Me.VirtualTime.TabIndex = 95
        Me.VirtualTime.UseVisualStyleBackColor = True
        Me.VirtualTime.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ReservationTimeLabel
        '
        Me.ReservationTimeLabel.AutoSize = True
        Me.ReservationTimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservationTimeLabel.Location = New System.Drawing.Point(122, 54)
        Me.ReservationTimeLabel.Name = "ReservationTimeLabel"
        Me.ReservationTimeLabel.Size = New System.Drawing.Size(97, 16)
        Me.ReservationTimeLabel.TabIndex = 107
        Me.ReservationTimeLabel.Text = "00 : 00 : 00 : AM"
        Me.ReservationTimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 55)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(90, 13)
        Me.Label3.TabIndex = 109
        Me.Label3.Text = "Reservation Time"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ReservationTime
        '
        Me.ReservationTime.CalendarTrailingForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ReservationTime.CustomFormat = "hh:mm:ss tt"
        Me.ReservationTime.Enabled = False
        Me.ReservationTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservationTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.ReservationTime.Location = New System.Drawing.Point(349, 55)
        Me.ReservationTime.Name = "ReservationTime"
        Me.ReservationTime.ShowUpDown = True
        Me.ReservationTime.Size = New System.Drawing.Size(36, 22)
        Me.ReservationTime.TabIndex = 1
        Me.ReservationTime.Visible = False
        '
        'ReservationDate
        '
        Me.ReservationDate.CalendarTrailingForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.ReservationDate.CustomFormat = "dd.MM.yyyy, HH:mm:ss"
        Me.ReservationDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservationDate.Location = New System.Drawing.Point(359, 17)
        Me.ReservationDate.Name = "ReservationDate"
        Me.ReservationDate.Size = New System.Drawing.Size(20, 22)
        Me.ReservationDate.TabIndex = 0
        Me.ReservationDate.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(90, 13)
        Me.Label2.TabIndex = 106
        Me.Label2.Text = "Reservation Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(15, 49)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(0, 13)
        Me.Label6.TabIndex = 121
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 109)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(0, 13)
        Me.Label5.TabIndex = 118
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 79)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(0, 13)
        Me.Label7.TabIndex = 123
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(0, 13)
        Me.Label8.TabIndex = 125
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.Label7)
        Me.GroupBox4.Controls.Add(Me.Label6)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 164)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(335, 165)
        Me.GroupBox4.TabIndex = 74
        Me.GroupBox4.TabStop = False
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.chkUseMultipleDP)
        Me.GroupBox5.Controls.Add(Me.TotalVisitor)
        Me.GroupBox5.Controls.Add(Me.VirtualCalculator)
        Me.GroupBox5.Controls.Add(Me.ServiceList)
        Me.GroupBox5.Controls.Add(Me.Label9)
        Me.GroupBox5.Controls.Add(Me.Label10)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 339)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(400, 102)
        Me.GroupBox5.TabIndex = 3
        Me.GroupBox5.TabStop = False
        '
        'chkUseMultipleDP
        '
        Me.chkUseMultipleDP.AutoSize = True
        Me.chkUseMultipleDP.Location = New System.Drawing.Point(214, 69)
        Me.chkUseMultipleDP.Name = "chkUseMultipleDP"
        Me.chkUseMultipleDP.Size = New System.Drawing.Size(84, 17)
        Me.chkUseMultipleDP.TabIndex = 97
        Me.chkUseMultipleDP.Text = "Use Multiple"
        Me.chkUseMultipleDP.UseVisualStyleBackColor = True
        '
        'TotalVisitor
        '
        Me.TotalVisitor.BackColor = System.Drawing.Color.White
        Me.TotalVisitor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalVisitor.Location = New System.Drawing.Point(84, 66)
        Me.TotalVisitor.MaxLength = 3
        Me.TotalVisitor.Name = "TotalVisitor"
        Me.TotalVisitor.Size = New System.Drawing.Size(50, 26)
        Me.TotalVisitor.TabIndex = 96
        Me.TotalVisitor.Text = "1"
        Me.TotalVisitor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'VirtualCalculator
        '
        Me.VirtualCalculator.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualCalculator.Image = CType(resources.GetObject("VirtualCalculator.Image"), System.Drawing.Image)
        Me.VirtualCalculator.Location = New System.Drawing.Point(143, 63)
        Me.VirtualCalculator.Name = "VirtualCalculator"
        Me.VirtualCalculator.Size = New System.Drawing.Size(50, 32)
        Me.VirtualCalculator.TabIndex = 95
        Me.VirtualCalculator.UseVisualStyleBackColor = True
        Me.VirtualCalculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ServiceList
        '
        Me.ServiceList.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.ServiceList.AlternatingRows = True
        Me.ServiceList.AutoCompletion = True
        Me.ServiceList.AutoDropDown = True
        Me.ServiceList.AutoSize = False
        Me.ServiceList.Caption = ""
        Me.ServiceList.CaptionHeight = 17
        Me.ServiceList.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.ServiceList.ColumnCaptionHeight = 17
        Me.ServiceList.ColumnFooterHeight = 17
        Me.ServiceList.ColumnWidth = 100
        Me.ServiceList.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.ServiceList.ContentHeight = 34
        Me.ServiceList.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.ServiceList.DeadAreaBackColor = System.Drawing.Color.White
        Me.ServiceList.EditorBackColor = System.Drawing.SystemColors.Window
        Me.ServiceList.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ServiceList.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.ServiceList.EditorHeight = 34
        Me.ServiceList.ExtendRightColumn = True
        Me.ServiceList.Images.Add(CType(resources.GetObject("ServiceList.Images"), System.Drawing.Image))
        Me.ServiceList.ItemHeight = 30
        Me.ServiceList.Location = New System.Drawing.Point(84, 17)
        Me.ServiceList.MatchEntryTimeout = CType(100, Long)
        Me.ServiceList.MaxDropDownItems = CType(10, Short)
        Me.ServiceList.MaxLength = 32767
        Me.ServiceList.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.ServiceList.Name = "ServiceList"
        Me.ServiceList.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.ServiceList.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.ServiceList.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.ServiceList.Size = New System.Drawing.Size(242, 40)
        Me.ServiceList.TabIndex = 0
        Me.ServiceList.Text = "Choose here ..."
        Me.ServiceList.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.ServiceList.PropBag = resources.GetString("ServiceList.PropBag")
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 70)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 92
        Me.Label9.Text = "Visitor"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 28)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(43, 13)
        Me.Label10.TabIndex = 9
        Me.Label10.Text = "Service"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.TableCombo)
        Me.GroupBox6.Controls.Add(Me.Label12)
        Me.GroupBox6.Controls.Add(Me.FindCust)
        Me.GroupBox6.Controls.Add(Me.VirtualKey)
        Me.GroupBox6.Controls.Add(Me.CustName)
        Me.GroupBox6.Controls.Add(Me.Label11)
        Me.GroupBox6.Controls.Add(Me.CustomerList)
        Me.GroupBox6.Location = New System.Drawing.Point(8, 198)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(400, 141)
        Me.GroupBox6.TabIndex = 2
        Me.GroupBox6.TabStop = False
        '
        'TableCombo
        '
        Me.TableCombo.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.TableCombo.AlternatingRows = True
        Me.TableCombo.AutoCompletion = True
        Me.TableCombo.AutoDropDown = True
        Me.TableCombo.AutoSize = False
        Me.TableCombo.Caption = ""
        Me.TableCombo.CaptionHeight = 17
        Me.TableCombo.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.TableCombo.ColumnCaptionHeight = 17
        Me.TableCombo.ColumnFooterHeight = 17
        Me.TableCombo.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.TableCombo.ContentHeight = 34
        Me.TableCombo.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.TableCombo.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.TableCombo.EditorBackColor = System.Drawing.SystemColors.Window
        Me.TableCombo.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.TableCombo.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.TableCombo.EditorHeight = 34
        Me.TableCombo.ExtendRightColumn = True
        Me.TableCombo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableCombo.Images.Add(CType(resources.GetObject("TableCombo.Images"), System.Drawing.Image))
        Me.TableCombo.ItemHeight = 30
        Me.TableCombo.Location = New System.Drawing.Point(84, 91)
        Me.TableCombo.MatchEntryTimeout = CType(100, Long)
        Me.TableCombo.MaxDropDownItems = CType(10, Short)
        Me.TableCombo.MaxLength = 32767
        Me.TableCombo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.TableCombo.Name = "TableCombo"
        Me.TableCombo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.TableCombo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.TableCombo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.TableCombo.Size = New System.Drawing.Size(242, 40)
        Me.TableCombo.TabIndex = 94
        Me.TableCombo.Text = "Choose here ..."
        Me.TableCombo.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.TableCombo.PropBag = resources.GetString("TableCombo.PropBag")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(15, 105)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 93
        Me.Label12.Text = "Table"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FindCust
        '
        Me.FindCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FindCust.ForeColor = System.Drawing.Color.DarkRed
        Me.FindCust.Image = CType(resources.GetObject("FindCust.Image"), System.Drawing.Image)
        Me.FindCust.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.FindCust.Location = New System.Drawing.Point(335, 17)
        Me.FindCust.Name = "FindCust"
        Me.FindCust.Size = New System.Drawing.Size(50, 40)
        Me.FindCust.TabIndex = 1
        Me.FindCust.Text = "Find"
        Me.FindCust.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.FindCust.UseVisualStyleBackColor = True
        Me.FindCust.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'VirtualKey
        '
        Me.VirtualKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualKey.Image = CType(resources.GetObject("VirtualKey.Image"), System.Drawing.Image)
        Me.VirtualKey.Location = New System.Drawing.Point(335, 62)
        Me.VirtualKey.Name = "VirtualKey"
        Me.VirtualKey.Size = New System.Drawing.Size(50, 32)
        Me.VirtualKey.TabIndex = 3
        Me.VirtualKey.UseVisualStyleBackColor = True
        Me.VirtualKey.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'CustName
        '
        Me.CustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustName.Location = New System.Drawing.Point(84, 61)
        Me.CustName.MaxLength = 40
        Me.CustName.Name = "CustName"
        Me.CustName.Size = New System.Drawing.Size(242, 26)
        Me.CustName.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 30)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 91
        Me.Label11.Text = "Customer"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CustomerList
        '
        Me.CustomerList.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CustomerList.AlternatingRows = True
        Me.CustomerList.AutoCompletion = True
        Me.CustomerList.AutoDropDown = True
        Me.CustomerList.AutoSize = False
        Me.CustomerList.Caption = ""
        Me.CustomerList.CaptionHeight = 17
        Me.CustomerList.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CustomerList.ColumnCaptionHeight = 17
        Me.CustomerList.ColumnFooterHeight = 17
        Me.CustomerList.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CustomerList.ContentHeight = 34
        Me.CustomerList.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.CustomerList.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CustomerList.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CustomerList.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CustomerList.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CustomerList.EditorHeight = 34
        Me.CustomerList.ExtendRightColumn = True
        Me.CustomerList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerList.Images.Add(CType(resources.GetObject("CustomerList.Images"), System.Drawing.Image))
        Me.CustomerList.ItemHeight = 30
        Me.CustomerList.Location = New System.Drawing.Point(84, 17)
        Me.CustomerList.MatchEntryTimeout = CType(100, Long)
        Me.CustomerList.MaxDropDownItems = CType(10, Short)
        Me.CustomerList.MaxLength = 32767
        Me.CustomerList.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CustomerList.Name = "CustomerList"
        Me.CustomerList.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CustomerList.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CustomerList.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CustomerList.Size = New System.Drawing.Size(242, 40)
        Me.CustomerList.TabIndex = 0
        Me.CustomerList.Text = "Choose here ..."
        Me.CustomerList.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.CustomerList.PropBag = resources.GetString("CustomerList.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTNMoveDown)
        Me.GroupBox1.Controls.Add(Me.BTNMoveUp)
        Me.GroupBox1.Controls.Add(Me.TableList)
        Me.GroupBox1.Location = New System.Drawing.Point(414, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(263, 621)
        Me.GroupBox1.TabIndex = 12
        Me.GroupBox1.TabStop = False
        '
        'BTNMoveDown
        '
        Me.BTNMoveDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveDown.Image = CType(resources.GetObject("BTNMoveDown.Image"), System.Drawing.Image)
        Me.BTNMoveDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveDown.Location = New System.Drawing.Point(134, 576)
        Me.BTNMoveDown.Name = "BTNMoveDown"
        Me.BTNMoveDown.Size = New System.Drawing.Size(116, 37)
        Me.BTNMoveDown.TabIndex = 7
        Me.BTNMoveDown.Text = "Down"
        Me.BTNMoveDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNMoveDown.UseVisualStyleBackColor = True
        Me.BTNMoveDown.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNMoveUp
        '
        Me.BTNMoveUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveUp.Image = CType(resources.GetObject("BTNMoveUp.Image"), System.Drawing.Image)
        Me.BTNMoveUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveUp.Location = New System.Drawing.Point(13, 576)
        Me.BTNMoveUp.Name = "BTNMoveUp"
        Me.BTNMoveUp.Size = New System.Drawing.Size(115, 37)
        Me.BTNMoveUp.TabIndex = 6
        Me.BTNMoveUp.Text = "Up"
        Me.BTNMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNMoveUp.UseVisualStyleBackColor = True
        Me.BTNMoveUp.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'TableList
        '
        Me.TableList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.TableList.AllowEditing = False
        Me.TableList.AutoResize = False
        Me.TableList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.TableList.ColumnInfo = resources.GetString("TableList.ColumnInfo")
        Me.TableList.ExtendLastCol = True
        Me.TableList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.TableList.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableList.Location = New System.Drawing.Point(13, 19)
        Me.TableList.Name = "TableList"
        Me.TableList.Rows.Count = 0
        Me.TableList.Rows.DefaultSize = 26
        Me.TableList.Rows.Fixed = 0
        Me.TableList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.TableList.Size = New System.Drawing.Size(237, 540)
        Me.TableList.StyleInfo = resources.GetString("TableList.StyleInfo")
        Me.TableList.TabIndex = 0
        Me.TableList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.Virtual2Key)
        Me.GroupBox7.Controls.Add(Me.Note)
        Me.GroupBox7.Controls.Add(Me.Label14)
        Me.GroupBox7.Location = New System.Drawing.Point(8, 544)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(400, 77)
        Me.GroupBox7.TabIndex = 5
        Me.GroupBox7.TabStop = False
        '
        'Virtual2Key
        '
        Me.Virtual2Key.Image = CType(resources.GetObject("Virtual2Key.Image"), System.Drawing.Image)
        Me.Virtual2Key.Location = New System.Drawing.Point(335, 19)
        Me.Virtual2Key.Name = "Virtual2Key"
        Me.Virtual2Key.Size = New System.Drawing.Size(50, 44)
        Me.Virtual2Key.TabIndex = 9
        Me.Virtual2Key.UseVisualStyleBackColor = True
        Me.Virtual2Key.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Note
        '
        Me.Note.Location = New System.Drawing.Point(56, 19)
        Me.Note.MaxLength = 256
        Me.Note.Multiline = True
        Me.Note.Name = "Note"
        Me.Note.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.Note.Size = New System.Drawing.Size(270, 44)
        Me.Note.TabIndex = 0
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(15, 29)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(30, 13)
        Me.Label14.TabIndex = 8
        Me.Label14.Text = "Note"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTNDownpayment
        '
        Me.BTNDownpayment.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNDownpayment.Image = CType(resources.GetObject("BTNDownpayment.Image"), System.Drawing.Image)
        Me.BTNDownpayment.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNDownpayment.Location = New System.Drawing.Point(8, 629)
        Me.BTNDownpayment.Name = "BTNDownpayment"
        Me.BTNDownpayment.Size = New System.Drawing.Size(197, 41)
        Me.BTNDownpayment.TabIndex = 6
        Me.BTNDownpayment.Text = "Down Payment"
        Me.BTNDownpayment.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNDownpayment.UseVisualStyleBackColor = True
        Me.BTNDownpayment.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNMakeOrder
        '
        Me.BTNMakeOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMakeOrder.Image = CType(resources.GetObject("BTNMakeOrder.Image"), System.Drawing.Image)
        Me.BTNMakeOrder.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMakeOrder.Location = New System.Drawing.Point(211, 629)
        Me.BTNMakeOrder.Name = "BTNMakeOrder"
        Me.BTNMakeOrder.Size = New System.Drawing.Size(197, 41)
        Me.BTNMakeOrder.TabIndex = 7
        Me.BTNMakeOrder.Text = "Make Order"
        Me.BTNMakeOrder.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNMakeOrder.UseVisualStyleBackColor = True
        Me.BTNMakeOrder.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNList
        '
        Me.BTNList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNList.Image = CType(resources.GetObject("BTNList.Image"), System.Drawing.Image)
        Me.BTNList.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNList.Location = New System.Drawing.Point(8, 676)
        Me.BTNList.Name = "BTNList"
        Me.BTNList.Size = New System.Drawing.Size(400, 41)
        Me.BTNList.TabIndex = 8
        Me.BTNList.Text = "Reservation List"
        Me.BTNList.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNList.UseVisualStyleBackColor = True
        Me.BTNList.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNCancel
        '
        Me.BTNCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCancel.Image = CType(resources.GetObject("BTNCancel.Image"), System.Drawing.Image)
        Me.BTNCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNCancel.Location = New System.Drawing.Point(414, 676)
        Me.BTNCancel.Name = "BTNCancel"
        Me.BTNCancel.Size = New System.Drawing.Size(263, 41)
        Me.BTNCancel.TabIndex = 11
        Me.BTNCancel.Text = "Close"
        Me.BTNCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNCancel.UseVisualStyleBackColor = True
        Me.BTNCancel.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNSave
        '
        Me.BTNSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSave.ForeColor = System.Drawing.Color.Maroon
        Me.BTNSave.Image = CType(resources.GetObject("BTNSave.Image"), System.Drawing.Image)
        Me.BTNSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNSave.Location = New System.Drawing.Point(414, 629)
        Me.BTNSave.Name = "BTNSave"
        Me.BTNSave.Size = New System.Drawing.Size(129, 41)
        Me.BTNSave.TabIndex = 10
        Me.BTNSave.Text = "Save"
        Me.BTNSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNSave.UseVisualStyleBackColor = True
        Me.BTNSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNPrintOrder
        '
        Me.BTNPrintOrder.Enabled = False
        Me.BTNPrintOrder.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNPrintOrder.Image = CType(resources.GetObject("BTNPrintOrder.Image"), System.Drawing.Image)
        Me.BTNPrintOrder.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNPrintOrder.Location = New System.Drawing.Point(548, 629)
        Me.BTNPrintOrder.Name = "BTNPrintOrder"
        Me.BTNPrintOrder.Size = New System.Drawing.Size(129, 41)
        Me.BTNPrintOrder.TabIndex = 70
        Me.BTNPrintOrder.Text = "Print Order"
        Me.BTNPrintOrder.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNPrintOrder.UseVisualStyleBackColor = True
        Me.BTNPrintOrder.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Silver
        '
        'lblSisaDP
        '
        Me.lblSisaDP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSisaDP.ForeColor = System.Drawing.Color.Maroon
        Me.lblSisaDP.Location = New System.Drawing.Point(143, 71)
        Me.lblSisaDP.Name = "lblSisaDP"
        Me.lblSisaDP.Size = New System.Drawing.Size(242, 17)
        Me.lblSisaDP.TabIndex = 21
        Me.lblSisaDP.Text = "0"
        Me.lblSisaDP.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSisaDP.Visible = False
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label19.ForeColor = System.Drawing.Color.Maroon
        Me.Label19.Location = New System.Drawing.Point(15, 73)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(92, 15)
        Me.Label19.TabIndex = 20
        Me.Label19.Text = "REMAINS DP"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label19.Visible = False
        '
        'Form_Reservation_Rent
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(686, 722)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.BTNPrintOrder)
        Me.Controls.Add(Me.BTNDownpayment)
        Me.Controls.Add(Me.BTNMakeOrder)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox6)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.BTNList)
        Me.Controls.Add(Me.BTNCancel)
        Me.Controls.Add(Me.BTNSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox)
        Me.Controls.Add(Me.GroupBox7)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.Location = New System.Drawing.Point(0, 53)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Reservation_Rent"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Reservation"
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        CType(Me.Print, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tax, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.ServiceList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.TableCombo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox7.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents ReservationNo As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNCancel As C1.Win.C1Input.C1Button
    Friend WithEvents BTNSave As C1.Win.C1Input.C1Button
    Friend WithEvents BTNList As C1.Win.C1Input.C1Button
    Friend WithEvents CurrentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents ReservationTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents ReservationDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents ServiceList As C1.Win.C1List.C1Combo
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents FindCust As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualKey As C1.Win.C1Input.C1Button
    Friend WithEvents CustName As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents CustomerList As C1.Win.C1List.C1Combo
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents TableList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents BTNMakeOrder As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents Note As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BTNDownpayment As C1.Win.C1Input.C1Button
    Friend WithEvents Virtual2Key As C1.Win.C1Input.C1Button
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents BalanceDueTxt As System.Windows.Forms.Label
    Friend WithEvents DPTxt As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TableCombo As C1.Win.C1List.C1Combo
    Friend WithEvents VirtualTime As C1.Win.C1Input.C1Button
    Friend WithEvents DateLabel As System.Windows.Forms.Label
    Friend WithEvents ReservationTimeLabel As System.Windows.Forms.Label
    Friend WithEvents ReservationDateLabel As System.Windows.Forms.Label
    Friend WithEvents VirtualDate As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualCalculator As C1.Win.C1Input.C1Button
    Friend WithEvents TotalVisitor As System.Windows.Forms.TextBox
    Friend WithEvents BTNMoveDown As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveUp As C1.Win.C1Input.C1Button
    Friend WithEvents Tax As C1.Win.C1Input.C1Label
    Friend WithEvents VirtualCurrentDate As C1.Win.C1Input.C1Button
    Friend WithEvents Print As C1.Win.C1Input.C1Label
    Friend WithEvents PrintCounter As System.Windows.Forms.Label
    Friend WithEvents BTNPrintOrder As C1.Win.C1Input.C1Button
    Friend WithEvents txtHour As System.Windows.Forms.TextBox
    Friend WithEvents cmdVirtualJam As C1.Win.C1Input.C1Button
    Friend WithEvents lblEndHour As System.Windows.Forms.Label
    Friend WithEvents lblHargaRoom As System.Windows.Forms.Label
    Friend WithEvents lblTotalFood As System.Windows.Forms.Label
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents chkUseMultipleDP As System.Windows.Forms.CheckBox
    Friend WithEvents lblSisaDP As System.Windows.Forms.Label
    Friend WithEvents Label19 As System.Windows.Forms.Label
End Class
