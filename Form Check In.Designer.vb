<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Check_In
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Check_In))
        Me.GroupBox = New System.Windows.Forms.GroupBox
        Me.Label12 = New System.Windows.Forms.Label
        Me.TableCombo = New C1.Win.C1List.C1Combo
        Me.FindCust = New C1.Win.C1Input.C1Button
        Me.VirtualKey = New C1.Win.C1Input.C1Button
        Me.CustName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CustomerList = New C1.Win.C1List.C1Combo
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.VirtualDate = New C1.Win.C1Input.C1Button
        Me.DateLabel = New System.Windows.Forms.Label
        Me.TimeLabel = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CurrentTime = New System.Windows.Forms.DateTimePicker
        Me.CurrentDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.TotalVisitor = New System.Windows.Forms.TextBox
        Me.VirtualCalculator = New C1.Win.C1Input.C1Button
        Me.ServiceList = New C1.Win.C1List.C1Combo
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.ReservationList = New C1.Win.C1List.C1Combo
        Me.TransactionNo = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.FindReservation = New C1.Win.C1Input.C1Button
        Me.Label5 = New System.Windows.Forms.Label
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.TableList = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.BTNCancel = New C1.Win.C1Input.C1Button
        Me.BTNSave = New C1.Win.C1Input.C1Button
        Me.txtBarcode = New System.Windows.Forms.TextBox
        Me.cmdBarcode = New C1.Win.C1Input.C1Button
        Me.dtOldDate = New System.Windows.Forms.DateTimePicker
        Me.GroupBox.SuspendLayout()
        CType(Me.TableCombo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.ServiceList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ReservationList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox
        '
        Me.GroupBox.Controls.Add(Me.Label12)
        Me.GroupBox.Controls.Add(Me.TableCombo)
        Me.GroupBox.Controls.Add(Me.FindCust)
        Me.GroupBox.Controls.Add(Me.VirtualKey)
        Me.GroupBox.Controls.Add(Me.CustName)
        Me.GroupBox.Controls.Add(Me.Label6)
        Me.GroupBox.Controls.Add(Me.CustomerList)
        Me.GroupBox.Location = New System.Drawing.Point(8, 182)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(400, 149)
        Me.GroupBox.TabIndex = 2
        Me.GroupBox.TabStop = False
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(14, 106)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(34, 13)
        Me.Label12.TabIndex = 95
        Me.Label12.Text = "Table"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.TableCombo.Location = New System.Drawing.Point(84, 99)
        Me.TableCombo.MatchEntryTimeout = CType(100, Long)
        Me.TableCombo.MaxDropDownItems = CType(10, Short)
        Me.TableCombo.MaxLength = 32767
        Me.TableCombo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.TableCombo.Name = "TableCombo"
        Me.TableCombo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.TableCombo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.TableCombo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.TableCombo.Size = New System.Drawing.Size(245, 40)
        Me.TableCombo.TabIndex = 4
        Me.TableCombo.Text = "Choose here ..."
        Me.TableCombo.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.TableCombo.PropBag = resources.GetString("TableCombo.PropBag")
        '
        'FindCust
        '
        Me.FindCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
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
        Me.VirtualKey.Image = CType(resources.GetObject("VirtualKey.Image"), System.Drawing.Image)
        Me.VirtualKey.Location = New System.Drawing.Point(335, 65)
        Me.VirtualKey.Name = "VirtualKey"
        Me.VirtualKey.Size = New System.Drawing.Size(50, 26)
        Me.VirtualKey.TabIndex = 3
        Me.VirtualKey.UseVisualStyleBackColor = True
        Me.VirtualKey.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'CustName
        '
        Me.CustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustName.Location = New System.Drawing.Point(84, 65)
        Me.CustName.MaxLength = 40
        Me.CustName.Name = "CustName"
        Me.CustName.Size = New System.Drawing.Size(245, 26)
        Me.CustName.TabIndex = 2
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(14, 29)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(51, 13)
        Me.Label6.TabIndex = 91
        Me.Label6.Text = "Customer"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.CustomerList.Size = New System.Drawing.Size(245, 40)
        Me.CustomerList.TabIndex = 0
        Me.CustomerList.Text = "Choose here ..."
        Me.CustomerList.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.CustomerList.PropBag = resources.GetString("CustomerList.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtOldDate)
        Me.GroupBox1.Controls.Add(Me.VirtualDate)
        Me.GroupBox1.Controls.Add(Me.DateLabel)
        Me.GroupBox1.Controls.Add(Me.TimeLabel)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CurrentTime)
        Me.GroupBox1.Controls.Add(Me.CurrentDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 100)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(400, 81)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'VirtualDate
        '
        Me.VirtualDate.Image = CType(resources.GetObject("VirtualDate.Image"), System.Drawing.Image)
        Me.VirtualDate.Location = New System.Drawing.Point(335, 12)
        Me.VirtualDate.Name = "VirtualDate"
        Me.VirtualDate.Size = New System.Drawing.Size(50, 30)
        Me.VirtualDate.TabIndex = 111
        Me.VirtualDate.UseVisualStyleBackColor = True
        Me.VirtualDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'DateLabel
        '
        Me.DateLabel.AutoSize = True
        Me.DateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateLabel.Location = New System.Drawing.Point(88, 19)
        Me.DateLabel.Name = "DateLabel"
        Me.DateLabel.Size = New System.Drawing.Size(75, 16)
        Me.DateLabel.TabIndex = 97
        Me.DateLabel.Text = "1 May 2010"
        Me.DateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TimeLabel
        '
        Me.TimeLabel.AutoSize = True
        Me.TimeLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TimeLabel.Location = New System.Drawing.Point(88, 50)
        Me.TimeLabel.Name = "TimeLabel"
        Me.TimeLabel.Size = New System.Drawing.Size(97, 16)
        Me.TimeLabel.TabIndex = 96
        Me.TimeLabel.Text = "00 : 00 : 00 : AM"
        Me.TimeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 51)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(30, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Time"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CurrentTime
        '
        Me.CurrentTime.CalendarTrailingForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CurrentTime.CustomFormat = "hh:mm:ss tt"
        Me.CurrentTime.Enabled = False
        Me.CurrentTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.CurrentTime.Location = New System.Drawing.Point(372, 52)
        Me.CurrentTime.Name = "CurrentTime"
        Me.CurrentTime.ShowUpDown = True
        Me.CurrentTime.Size = New System.Drawing.Size(22, 22)
        Me.CurrentTime.TabIndex = 1
        Me.CurrentTime.Visible = False
        '
        'CurrentDate
        '
        Me.CurrentDate.CalendarTrailingForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CurrentDate.CustomFormat = "dddd, dd MMMM, yyyy"
        Me.CurrentDate.Enabled = False
        Me.CurrentDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentDate.Location = New System.Drawing.Point(372, 19)
        Me.CurrentDate.Name = "CurrentDate"
        Me.CurrentDate.Size = New System.Drawing.Size(22, 22)
        Me.CurrentDate.TabIndex = 0
        Me.CurrentDate.Visible = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 21)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 6
        Me.Label2.Text = "Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.TotalVisitor)
        Me.GroupBox2.Controls.Add(Me.VirtualCalculator)
        Me.GroupBox2.Controls.Add(Me.ServiceList)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 335)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(400, 101)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'TotalVisitor
        '
        Me.TotalVisitor.BackColor = System.Drawing.Color.White
        Me.TotalVisitor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalVisitor.Location = New System.Drawing.Point(83, 64)
        Me.TotalVisitor.MaxLength = 3
        Me.TotalVisitor.Name = "TotalVisitor"
        Me.TotalVisitor.Size = New System.Drawing.Size(50, 26)
        Me.TotalVisitor.TabIndex = 98
        Me.TotalVisitor.Text = "1"
        Me.TotalVisitor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'VirtualCalculator
        '
        Me.VirtualCalculator.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualCalculator.Image = CType(resources.GetObject("VirtualCalculator.Image"), System.Drawing.Image)
        Me.VirtualCalculator.Location = New System.Drawing.Point(142, 62)
        Me.VirtualCalculator.Name = "VirtualCalculator"
        Me.VirtualCalculator.Size = New System.Drawing.Size(50, 32)
        Me.VirtualCalculator.TabIndex = 97
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
        Me.ServiceList.Size = New System.Drawing.Size(301, 40)
        Me.ServiceList.TabIndex = 0
        Me.ServiceList.Text = "Choose here ..."
        Me.ServiceList.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.ServiceList.PropBag = resources.GetString("ServiceList.PropBag")
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(13, 70)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(35, 13)
        Me.Label7.TabIndex = 92
        Me.Label7.Text = "Visitor"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(13, 29)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(43, 13)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "Service"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.ReservationList)
        Me.GroupBox4.Controls.Add(Me.TransactionNo)
        Me.GroupBox4.Controls.Add(Me.Label8)
        Me.GroupBox4.Controls.Add(Me.FindReservation)
        Me.GroupBox4.Controls.Add(Me.Label5)
        Me.GroupBox4.Location = New System.Drawing.Point(8, 2)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(400, 97)
        Me.GroupBox4.TabIndex = 0
        Me.GroupBox4.TabStop = False
        '
        'ReservationList
        '
        Me.ReservationList.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.ReservationList.AlternatingRows = True
        Me.ReservationList.AutoCompletion = True
        Me.ReservationList.AutoDropDown = True
        Me.ReservationList.AutoSize = False
        Me.ReservationList.Caption = ""
        Me.ReservationList.CaptionHeight = 17
        Me.ReservationList.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.ReservationList.ColumnCaptionHeight = 17
        Me.ReservationList.ColumnFooterHeight = 17
        Me.ReservationList.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.ReservationList.ContentHeight = 34
        Me.ReservationList.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.ReservationList.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.ReservationList.EditorBackColor = System.Drawing.SystemColors.Window
        Me.ReservationList.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.ReservationList.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.ReservationList.EditorHeight = 34
        Me.ReservationList.ExtendRightColumn = True
        Me.ReservationList.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ReservationList.Images.Add(CType(resources.GetObject("ReservationList.Images"), System.Drawing.Image))
        Me.ReservationList.ItemHeight = 30
        Me.ReservationList.Location = New System.Drawing.Point(85, 44)
        Me.ReservationList.MatchEntryTimeout = CType(100, Long)
        Me.ReservationList.MaxDropDownItems = CType(10, Short)
        Me.ReservationList.MaxLength = 32767
        Me.ReservationList.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.ReservationList.Name = "ReservationList"
        Me.ReservationList.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.ReservationList.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.ReservationList.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.ReservationList.Size = New System.Drawing.Size(245, 40)
        Me.ReservationList.TabIndex = 96
        Me.ReservationList.Text = "Choose here ..."
        Me.ReservationList.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.ReservationList.PropBag = resources.GetString("ReservationList.PropBag")
        '
        'TransactionNo
        '
        Me.TransactionNo.AutoSize = True
        Me.TransactionNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TransactionNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TransactionNo.Location = New System.Drawing.Point(81, 18)
        Me.TransactionNo.Name = "TransactionNo"
        Me.TransactionNo.Size = New System.Drawing.Size(0, 16)
        Me.TransactionNo.TabIndex = 95
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 19)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(24, 13)
        Me.Label8.TabIndex = 94
        Me.Label8.Text = "No."
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FindReservation
        '
        Me.FindReservation.Enabled = False
        Me.FindReservation.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FindReservation.Image = CType(resources.GetObject("FindReservation.Image"), System.Drawing.Image)
        Me.FindReservation.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.FindReservation.Location = New System.Drawing.Point(335, 44)
        Me.FindReservation.Name = "FindReservation"
        Me.FindReservation.Size = New System.Drawing.Size(50, 40)
        Me.FindReservation.TabIndex = 1
        Me.FindReservation.Text = "Find"
        Me.FindReservation.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.FindReservation.UseVisualStyleBackColor = True
        Me.FindReservation.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 57)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(64, 13)
        Me.Label5.TabIndex = 91
        Me.Label5.Text = "Reservation"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.TableList)
        Me.GroupBox5.Location = New System.Drawing.Point(414, 1)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(263, 420)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        '
        'TableList
        '
        Me.TableList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.TableList.AllowEditing = False
        Me.TableList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.TableList.ColumnInfo = resources.GetString("TableList.ColumnInfo")
        Me.TableList.ExtendLastCol = True
        Me.TableList.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableList.Location = New System.Drawing.Point(11, 16)
        Me.TableList.Name = "TableList"
        Me.TableList.Rows.Count = 0
        Me.TableList.Rows.DefaultSize = 26
        Me.TableList.Rows.Fixed = 0
        Me.TableList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.TableList.Size = New System.Drawing.Size(241, 393)
        Me.TableList.StyleInfo = resources.GetString("TableList.StyleInfo")
        Me.TableList.TabIndex = 0
        Me.TableList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'BTNCancel
        '
        Me.BTNCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCancel.Image = CType(resources.GetObject("BTNCancel.Image"), System.Drawing.Image)
        Me.BTNCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNCancel.Location = New System.Drawing.Point(312, 447)
        Me.BTNCancel.Name = "BTNCancel"
        Me.BTNCancel.Size = New System.Drawing.Size(95, 41)
        Me.BTNCancel.TabIndex = 6
        Me.BTNCancel.Text = "Close"
        Me.BTNCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNCancel.UseVisualStyleBackColor = True
        Me.BTNCancel.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNSave
        '
        Me.BTNSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSave.Image = CType(resources.GetObject("BTNSave.Image"), System.Drawing.Image)
        Me.BTNSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNSave.Location = New System.Drawing.Point(211, 447)
        Me.BTNSave.Name = "BTNSave"
        Me.BTNSave.Size = New System.Drawing.Size(95, 41)
        Me.BTNSave.TabIndex = 5
        Me.BTNSave.Text = "Save"
        Me.BTNSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNSave.UseVisualStyleBackColor = True
        Me.BTNSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'txtBarcode
        '
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarcode.Location = New System.Drawing.Point(8, 456)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(48, 20)
        Me.txtBarcode.TabIndex = 7
        Me.txtBarcode.Text = "Type Barcode Here"
        Me.txtBarcode.Visible = False
        '
        'cmdBarcode
        '
        Me.cmdBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBarcode.Image = CType(resources.GetObject("cmdBarcode.Image"), System.Drawing.Image)
        Me.cmdBarcode.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdBarcode.Location = New System.Drawing.Point(8, 447)
        Me.cmdBarcode.Name = "cmdBarcode"
        Me.cmdBarcode.Size = New System.Drawing.Size(95, 41)
        Me.cmdBarcode.TabIndex = 8
        Me.cmdBarcode.Text = "Scan Barcode"
        Me.cmdBarcode.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdBarcode.UseVisualStyleBackColor = True
        Me.cmdBarcode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'dtOldDate
        '
        Me.dtOldDate.CalendarTrailingForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dtOldDate.CustomFormat = "dddd, dd MMMM, yyyy"
        Me.dtOldDate.Enabled = False
        Me.dtOldDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtOldDate.Location = New System.Drawing.Point(276, 12)
        Me.dtOldDate.Name = "dtOldDate"
        Me.dtOldDate.Size = New System.Drawing.Size(22, 22)
        Me.dtOldDate.TabIndex = 112
        Me.dtOldDate.Visible = False
        '
        'Form_Check_In
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(415, 497)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdBarcode)
        Me.Controls.Add(Me.txtBarcode)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.BTNCancel)
        Me.Controls.Add(Me.BTNSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Check_In"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Customer Check In"
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        CType(Me.TableCombo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.ServiceList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        CType(Me.ReservationList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents CustomerList As C1.Win.C1List.C1Combo
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents CurrentDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents CurrentTime As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents BTNSave As C1.Win.C1Input.C1Button
    Friend WithEvents BTNCancel As C1.Win.C1Input.C1Button
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents ServiceList As C1.Win.C1List.C1Combo
    Friend WithEvents CustName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents FindReservation As C1.Win.C1Input.C1Button
    Friend WithEvents TransactionNo As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents VirtualKey As C1.Win.C1Input.C1Button
    Friend WithEvents FindCust As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents TableList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents TableCombo As C1.Win.C1List.C1Combo
    Friend WithEvents ReservationList As C1.Win.C1List.C1Combo
    Friend WithEvents DateLabel As System.Windows.Forms.Label
    Friend WithEvents TimeLabel As System.Windows.Forms.Label
    Friend WithEvents TotalVisitor As System.Windows.Forms.TextBox
    Friend WithEvents VirtualCalculator As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualDate As C1.Win.C1Input.C1Button
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents cmdBarcode As C1.Win.C1Input.C1Button
    Friend WithEvents dtOldDate As System.Windows.Forms.DateTimePicker
End Class
