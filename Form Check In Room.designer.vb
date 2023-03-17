<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Check_In_Room
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Check_In_Room))
        Me.GroupBox = New System.Windows.Forms.GroupBox
        Me.grdMaster = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.Label12 = New System.Windows.Forms.Label
        Me.TableCombo = New C1.Win.C1List.C1Combo
        Me.FindCust = New C1.Win.C1Input.C1Button
        Me.VirtualKey = New C1.Win.C1Input.C1Button
        Me.CustName = New System.Windows.Forms.TextBox
        Me.Label6 = New System.Windows.Forms.Label
        Me.CustomerList = New C1.Win.C1List.C1Combo
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CurrentDate = New System.Windows.Forms.DateTimePicker
        Me.cmdFreeMnt = New C1.Win.C1Input.C1Button
        Me.Label24 = New System.Windows.Forms.Label
        Me.Label23 = New System.Windows.Forms.Label
        Me.txtBonusMinutes = New System.Windows.Forms.TextBox
        Me.Label22 = New System.Windows.Forms.Label
        Me.cmdDownHour = New C1.Win.C1Input.C1Button
        Me.cmdUpHour = New C1.Win.C1Input.C1Button
        Me.cmdDownFree = New C1.Win.C1Input.C1Button
        Me.ServiceList = New C1.Win.C1List.C1Combo
        Me.cmdUpFree = New C1.Win.C1Input.C1Button
        Me.cmdDownTambahan = New C1.Win.C1Input.C1Button
        Me.cmdUpTambahan = New C1.Win.C1Input.C1Button
        Me.cmdDownRent = New C1.Win.C1Input.C1Button
        Me.cmdUpRent = New C1.Win.C1Input.C1Button
        Me.Label20 = New System.Windows.Forms.Label
        Me.txtFreeInv = New System.Windows.Forms.TextBox
        Me.Label21 = New System.Windows.Forms.Label
        Me.txtJamInv = New System.Windows.Forms.TextBox
        Me.txtTambahanInv = New System.Windows.Forms.TextBox
        Me.txtFreeHour = New System.Windows.Forms.TextBox
        Me.Label19 = New System.Windows.Forms.Label
        Me.lblTotalHour = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label17 = New System.Windows.Forms.Label
        Me.txtFree = New System.Windows.Forms.TextBox
        Me.txtTambahan = New System.Windows.Forms.TextBox
        Me.Label16 = New System.Windows.Forms.Label
        Me.lblEndHour = New System.Windows.Forms.Label
        Me.txtJam = New System.Windows.Forms.TextBox
        Me.VirtualDate = New C1.Win.C1Input.C1Button
        Me.DateLabel = New System.Windows.Forms.Label
        Me.TimeLabel = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.CurrentTime = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.txtFreeHourInv = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.VirtualCalculator6 = New C1.Win.C1Input.C1Button
        Me.VirtualCalculator5 = New C1.Win.C1Input.C1Button
        Me.VirtualCalculator4 = New C1.Win.C1Input.C1Button
        Me.VirtualCalculator3 = New C1.Win.C1Input.C1Button
        Me.VirtualCalculator2 = New C1.Win.C1Input.C1Button
        Me.Label18 = New System.Windows.Forms.Label
        Me.txtFemale50 = New System.Windows.Forms.TextBox
        Me.txtMale50 = New System.Windows.Forms.TextBox
        Me.Label15 = New System.Windows.Forms.Label
        Me.VirtualCalculator = New C1.Win.C1Input.C1Button
        Me.txtFemaleAdult = New System.Windows.Forms.TextBox
        Me.txtFemaleKid = New System.Windows.Forms.TextBox
        Me.txtMaleAdult = New System.Windows.Forms.TextBox
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.TotalVisitor = New System.Windows.Forms.TextBox
        Me.Label7 = New System.Windows.Forms.Label
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
        Me.BTNPrint = New C1.Win.C1Input.C1Button
        Me.txtBarcode = New System.Windows.Forms.TextBox
        Me.cmdBarcode = New C1.Win.C1Input.C1Button
        Me.dtOldDate = New System.Windows.Forms.DateTimePicker
        Me.GroupBox.SuspendLayout()
        CType(Me.grdMaster, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TableCombo, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.ServiceList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox4.SuspendLayout()
        CType(Me.ReservationList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox
        '
        Me.GroupBox.Controls.Add(Me.grdMaster)
        Me.GroupBox.Controls.Add(Me.Label12)
        Me.GroupBox.Controls.Add(Me.TableCombo)
        Me.GroupBox.Controls.Add(Me.FindCust)
        Me.GroupBox.Controls.Add(Me.VirtualKey)
        Me.GroupBox.Controls.Add(Me.CustName)
        Me.GroupBox.Controls.Add(Me.Label6)
        Me.GroupBox.Controls.Add(Me.CustomerList)
        Me.GroupBox.Location = New System.Drawing.Point(9, 358)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(468, 149)
        Me.GroupBox.TabIndex = 2
        Me.GroupBox.TabStop = False
        '
        'grdMaster
        '
        Me.grdMaster.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.grdMaster.AllowEditing = False
        Me.grdMaster.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
        Me.grdMaster.ColumnInfo = resources.GetString("grdMaster.ColumnInfo")
        Me.grdMaster.KeyActionEnter = C1.Win.C1FlexGrid.KeyActionEnum.None
        Me.grdMaster.Location = New System.Drawing.Point(8, 19)
        Me.grdMaster.Name = "grdMaster"
        Me.grdMaster.Rows.Count = 1
        Me.grdMaster.Rows.DefaultSize = 17
        Me.grdMaster.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Cell
        Me.grdMaster.ShowSort = False
        Me.grdMaster.Size = New System.Drawing.Size(70, 33)
        Me.grdMaster.TabIndex = 151
        Me.grdMaster.Visible = False
        Me.grdMaster.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
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
        Me.TableCombo.Location = New System.Drawing.Point(90, 98)
        Me.TableCombo.MatchEntryTimeout = CType(100, Long)
        Me.TableCombo.MaxDropDownItems = CType(5, Short)
        Me.TableCombo.MaxLength = 32767
        Me.TableCombo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.TableCombo.Name = "TableCombo"
        Me.TableCombo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.TableCombo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.TableCombo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.TableCombo.Size = New System.Drawing.Size(245, 40)
        Me.TableCombo.TabIndex = 13
        Me.TableCombo.Text = "Choose here ..."
        Me.TableCombo.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.TableCombo.PropBag = resources.GetString("TableCombo.PropBag")
        '
        'FindCust
        '
        Me.FindCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FindCust.Image = CType(resources.GetObject("FindCust.Image"), System.Drawing.Image)
        Me.FindCust.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.FindCust.Location = New System.Drawing.Point(404, 19)
        Me.FindCust.Name = "FindCust"
        Me.FindCust.Size = New System.Drawing.Size(50, 40)
        Me.FindCust.TabIndex = 10
        Me.FindCust.Text = "Find"
        Me.FindCust.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.FindCust.UseVisualStyleBackColor = True
        Me.FindCust.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'VirtualKey
        '
        Me.VirtualKey.Image = CType(resources.GetObject("VirtualKey.Image"), System.Drawing.Image)
        Me.VirtualKey.Location = New System.Drawing.Point(403, 66)
        Me.VirtualKey.Name = "VirtualKey"
        Me.VirtualKey.Size = New System.Drawing.Size(50, 26)
        Me.VirtualKey.TabIndex = 12
        Me.VirtualKey.UseVisualStyleBackColor = True
        Me.VirtualKey.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'CustName
        '
        Me.CustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustName.Location = New System.Drawing.Point(90, 64)
        Me.CustName.MaxLength = 40
        Me.CustName.Name = "CustName"
        Me.CustName.Size = New System.Drawing.Size(245, 26)
        Me.CustName.TabIndex = 11
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
        Me.CustomerList.Location = New System.Drawing.Point(90, 16)
        Me.CustomerList.MatchEntryTimeout = CType(100, Long)
        Me.CustomerList.MaxDropDownItems = CType(10, Short)
        Me.CustomerList.MaxLength = 32767
        Me.CustomerList.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CustomerList.Name = "CustomerList"
        Me.CustomerList.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CustomerList.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CustomerList.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CustomerList.Size = New System.Drawing.Size(245, 40)
        Me.CustomerList.TabIndex = 9
        Me.CustomerList.Text = "Choose here ..."
        Me.CustomerList.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.CustomerList.PropBag = resources.GetString("CustomerList.PropBag")
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.dtOldDate)
        Me.GroupBox1.Controls.Add(Me.CurrentDate)
        Me.GroupBox1.Controls.Add(Me.cmdFreeMnt)
        Me.GroupBox1.Controls.Add(Me.Label24)
        Me.GroupBox1.Controls.Add(Me.Label23)
        Me.GroupBox1.Controls.Add(Me.txtBonusMinutes)
        Me.GroupBox1.Controls.Add(Me.Label22)
        Me.GroupBox1.Controls.Add(Me.cmdDownHour)
        Me.GroupBox1.Controls.Add(Me.cmdUpHour)
        Me.GroupBox1.Controls.Add(Me.cmdDownFree)
        Me.GroupBox1.Controls.Add(Me.ServiceList)
        Me.GroupBox1.Controls.Add(Me.cmdUpFree)
        Me.GroupBox1.Controls.Add(Me.cmdDownTambahan)
        Me.GroupBox1.Controls.Add(Me.cmdUpTambahan)
        Me.GroupBox1.Controls.Add(Me.cmdDownRent)
        Me.GroupBox1.Controls.Add(Me.cmdUpRent)
        Me.GroupBox1.Controls.Add(Me.Label20)
        Me.GroupBox1.Controls.Add(Me.txtFreeInv)
        Me.GroupBox1.Controls.Add(Me.Label21)
        Me.GroupBox1.Controls.Add(Me.txtJamInv)
        Me.GroupBox1.Controls.Add(Me.txtTambahanInv)
        Me.GroupBox1.Controls.Add(Me.txtFreeHour)
        Me.GroupBox1.Controls.Add(Me.Label19)
        Me.GroupBox1.Controls.Add(Me.lblTotalHour)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.Label10)
        Me.GroupBox1.Controls.Add(Me.Label9)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.Label17)
        Me.GroupBox1.Controls.Add(Me.txtFree)
        Me.GroupBox1.Controls.Add(Me.txtTambahan)
        Me.GroupBox1.Controls.Add(Me.Label16)
        Me.GroupBox1.Controls.Add(Me.lblEndHour)
        Me.GroupBox1.Controls.Add(Me.txtJam)
        Me.GroupBox1.Controls.Add(Me.VirtualDate)
        Me.GroupBox1.Controls.Add(Me.DateLabel)
        Me.GroupBox1.Controls.Add(Me.TimeLabel)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.CurrentTime)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 100)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(468, 258)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'CurrentDate
        '
        Me.CurrentDate.CalendarTrailingForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CurrentDate.CustomFormat = "dddd, dd MMMM, yyyy"
        Me.CurrentDate.Enabled = False
        Me.CurrentDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentDate.Location = New System.Drawing.Point(309, 19)
        Me.CurrentDate.Name = "CurrentDate"
        Me.CurrentDate.Size = New System.Drawing.Size(61, 22)
        Me.CurrentDate.TabIndex = 0
        Me.CurrentDate.Visible = False
        '
        'cmdFreeMnt
        '
        Me.cmdFreeMnt.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdFreeMnt.Image = CType(resources.GetObject("cmdFreeMnt.Image"), System.Drawing.Image)
        Me.cmdFreeMnt.Location = New System.Drawing.Point(384, 115)
        Me.cmdFreeMnt.Name = "cmdFreeMnt"
        Me.cmdFreeMnt.Size = New System.Drawing.Size(70, 27)
        Me.cmdFreeMnt.TabIndex = 150
        Me.cmdFreeMnt.Tag = "4"
        Me.cmdFreeMnt.UseVisualStyleBackColor = True
        Me.cmdFreeMnt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label24
        '
        Me.Label24.AutoSize = True
        Me.Label24.Location = New System.Drawing.Point(425, 184)
        Me.Label24.Name = "Label24"
        Me.Label24.Size = New System.Drawing.Size(25, 13)
        Me.Label24.TabIndex = 149
        Me.Label24.Text = "Mnt"
        Me.Label24.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label24.Visible = False
        '
        'Label23
        '
        Me.Label23.AutoSize = True
        Me.Label23.Location = New System.Drawing.Point(299, 185)
        Me.Label23.Name = "Label23"
        Me.Label23.Size = New System.Drawing.Size(77, 13)
        Me.Label23.TabIndex = 148
        Me.Label23.Text = "Bonus Minutes"
        Me.Label23.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label23.Visible = False
        '
        'txtBonusMinutes
        '
        Me.txtBonusMinutes.BackColor = System.Drawing.Color.White
        Me.txtBonusMinutes.Enabled = False
        Me.txtBonusMinutes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBonusMinutes.Location = New System.Drawing.Point(384, 178)
        Me.txtBonusMinutes.MaxLength = 3
        Me.txtBonusMinutes.Name = "txtBonusMinutes"
        Me.txtBonusMinutes.ReadOnly = True
        Me.txtBonusMinutes.Size = New System.Drawing.Size(39, 26)
        Me.txtBonusMinutes.TabIndex = 147
        Me.txtBonusMinutes.Text = "0"
        Me.txtBonusMinutes.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtBonusMinutes.Visible = False
        '
        'Label22
        '
        Me.Label22.AutoSize = True
        Me.Label22.Location = New System.Drawing.Point(17, 211)
        Me.Label22.Name = "Label22"
        Me.Label22.Size = New System.Drawing.Size(70, 13)
        Me.Label22.TabIndex = 146
        Me.Label22.Text = "Service Type"
        Me.Label22.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'cmdDownHour
        '
        Me.cmdDownHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDownHour.Location = New System.Drawing.Point(419, 115)
        Me.cmdDownHour.Name = "cmdDownHour"
        Me.cmdDownHour.Size = New System.Drawing.Size(35, 27)
        Me.cmdDownHour.TabIndex = 145
        Me.cmdDownHour.Tag = "4"
        Me.cmdDownHour.Text = "-"
        Me.cmdDownHour.UseVisualStyleBackColor = True
        Me.cmdDownHour.Visible = False
        Me.cmdDownHour.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'cmdUpHour
        '
        Me.cmdUpHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpHour.Location = New System.Drawing.Point(384, 115)
        Me.cmdUpHour.Name = "cmdUpHour"
        Me.cmdUpHour.Size = New System.Drawing.Size(35, 27)
        Me.cmdUpHour.TabIndex = 144
        Me.cmdUpHour.Tag = "4"
        Me.cmdUpHour.Text = "+"
        Me.cmdUpHour.UseVisualStyleBackColor = True
        Me.cmdUpHour.Visible = False
        Me.cmdUpHour.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'cmdDownFree
        '
        Me.cmdDownFree.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDownFree.Location = New System.Drawing.Point(418, 209)
        Me.cmdDownFree.Name = "cmdDownFree"
        Me.cmdDownFree.Size = New System.Drawing.Size(35, 29)
        Me.cmdDownFree.TabIndex = 143
        Me.cmdDownFree.Tag = "3"
        Me.cmdDownFree.Text = "-"
        Me.cmdDownFree.UseVisualStyleBackColor = True
        Me.cmdDownFree.Visible = False
        Me.cmdDownFree.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
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
        Me.ServiceList.Location = New System.Drawing.Point(91, 198)
        Me.ServiceList.MatchEntryTimeout = CType(100, Long)
        Me.ServiceList.MaxDropDownItems = CType(10, Short)
        Me.ServiceList.MaxLength = 32767
        Me.ServiceList.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.ServiceList.Name = "ServiceList"
        Me.ServiceList.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.ServiceList.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.ServiceList.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.ServiceList.Size = New System.Drawing.Size(187, 40)
        Me.ServiceList.TabIndex = 0
        Me.ServiceList.Text = "Choose here ..."
        Me.ServiceList.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.ServiceList.PropBag = resources.GetString("ServiceList.PropBag")
        '
        'cmdUpFree
        '
        Me.cmdUpFree.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpFree.Location = New System.Drawing.Point(382, 209)
        Me.cmdUpFree.Name = "cmdUpFree"
        Me.cmdUpFree.Size = New System.Drawing.Size(35, 29)
        Me.cmdUpFree.TabIndex = 142
        Me.cmdUpFree.Tag = "3"
        Me.cmdUpFree.Text = "+"
        Me.cmdUpFree.UseVisualStyleBackColor = True
        Me.cmdUpFree.Visible = False
        Me.cmdUpFree.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'cmdDownTambahan
        '
        Me.cmdDownTambahan.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDownTambahan.Location = New System.Drawing.Point(420, 79)
        Me.cmdDownTambahan.Name = "cmdDownTambahan"
        Me.cmdDownTambahan.Size = New System.Drawing.Size(35, 29)
        Me.cmdDownTambahan.TabIndex = 141
        Me.cmdDownTambahan.Tag = "2"
        Me.cmdDownTambahan.Text = "-"
        Me.cmdDownTambahan.UseVisualStyleBackColor = True
        Me.cmdDownTambahan.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'cmdUpTambahan
        '
        Me.cmdUpTambahan.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpTambahan.Location = New System.Drawing.Point(384, 79)
        Me.cmdUpTambahan.Name = "cmdUpTambahan"
        Me.cmdUpTambahan.Size = New System.Drawing.Size(35, 29)
        Me.cmdUpTambahan.TabIndex = 140
        Me.cmdUpTambahan.Tag = "2"
        Me.cmdUpTambahan.Text = "+"
        Me.cmdUpTambahan.UseVisualStyleBackColor = True
        Me.cmdUpTambahan.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'cmdDownRent
        '
        Me.cmdDownRent.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdDownRent.Location = New System.Drawing.Point(202, 82)
        Me.cmdDownRent.Name = "cmdDownRent"
        Me.cmdDownRent.Size = New System.Drawing.Size(35, 27)
        Me.cmdDownRent.TabIndex = 139
        Me.cmdDownRent.Tag = "1"
        Me.cmdDownRent.Text = "-"
        Me.cmdDownRent.UseVisualStyleBackColor = True
        Me.cmdDownRent.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'cmdUpRent
        '
        Me.cmdUpRent.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdUpRent.Location = New System.Drawing.Point(167, 82)
        Me.cmdUpRent.Name = "cmdUpRent"
        Me.cmdUpRent.Size = New System.Drawing.Size(35, 27)
        Me.cmdUpRent.TabIndex = 138
        Me.cmdUpRent.Tag = "1"
        Me.cmdUpRent.Text = "+"
        Me.cmdUpRent.UseVisualStyleBackColor = True
        Me.cmdUpRent.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label20
        '
        Me.Label20.AutoSize = True
        Me.Label20.Location = New System.Drawing.Point(252, 119)
        Me.Label20.Name = "Label20"
        Me.Label20.Size = New System.Drawing.Size(28, 13)
        Me.Label20.TabIndex = 137
        Me.Label20.Text = "Free"
        Me.Label20.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFreeInv
        '
        Me.txtFreeInv.Location = New System.Drawing.Point(-2, 48)
        Me.txtFreeInv.Name = "txtFreeInv"
        Me.txtFreeInv.Size = New System.Drawing.Size(26, 20)
        Me.txtFreeInv.TabIndex = 134
        Me.txtFreeInv.Visible = False
        '
        'Label21
        '
        Me.Label21.AutoSize = True
        Me.Label21.Location = New System.Drawing.Point(351, 121)
        Me.Label21.Name = "Label21"
        Me.Label21.Size = New System.Drawing.Size(30, 13)
        Me.Label21.TabIndex = 136
        Me.Label21.Text = "Mnts"
        Me.Label21.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtJamInv
        '
        Me.txtJamInv.Location = New System.Drawing.Point(-2, 67)
        Me.txtJamInv.Name = "txtJamInv"
        Me.txtJamInv.Size = New System.Drawing.Size(28, 20)
        Me.txtJamInv.TabIndex = 132
        Me.txtJamInv.Visible = False
        '
        'txtTambahanInv
        '
        Me.txtTambahanInv.Location = New System.Drawing.Point(-2, 96)
        Me.txtTambahanInv.Name = "txtTambahanInv"
        Me.txtTambahanInv.Size = New System.Drawing.Size(26, 20)
        Me.txtTambahanInv.TabIndex = 133
        Me.txtTambahanInv.Visible = False
        '
        'txtFreeHour
        '
        Me.txtFreeHour.BackColor = System.Drawing.Color.White
        Me.txtFreeHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFreeHour.Location = New System.Drawing.Point(309, 114)
        Me.txtFreeHour.MaxLength = 3
        Me.txtFreeHour.Name = "txtFreeHour"
        Me.txtFreeHour.Size = New System.Drawing.Size(40, 26)
        Me.txtFreeHour.TabIndex = 135
        Me.txtFreeHour.Tag = "4"
        Me.txtFreeHour.Text = "0"
        Me.txtFreeHour.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label19
        '
        Me.Label19.AutoSize = True
        Me.Label19.Location = New System.Drawing.Point(14, 126)
        Me.Label19.Name = "Label19"
        Me.Label19.Size = New System.Drawing.Size(57, 13)
        Me.Label19.TabIndex = 131
        Me.Label19.Text = "Total Rent"
        Me.Label19.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblTotalHour
        '
        Me.lblTotalHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTotalHour.Location = New System.Drawing.Point(92, 126)
        Me.lblTotalHour.Name = "lblTotalHour"
        Me.lblTotalHour.Size = New System.Drawing.Size(151, 16)
        Me.lblTotalHour.TabIndex = 130
        Me.lblTotalHour.Text = "0 Hours"
        Me.lblTotalHour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(272, 153)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(28, 13)
        Me.Label11.TabIndex = 129
        Me.Label11.Text = "Free"
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label11.Visible = False
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(249, 90)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(53, 13)
        Me.Label10.TabIndex = 128
        Me.Label10.Text = "Additional"
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 90)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(30, 13)
        Me.Label9.TabIndex = 127
        Me.Label9.Text = "Rent"
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(350, 155)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(30, 13)
        Me.Label4.TabIndex = 126
        Me.Label4.Text = "Mnts"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label4.Visible = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(350, 88)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(30, 13)
        Me.Label1.TabIndex = 125
        Me.Label1.Text = "Mnts"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label17
        '
        Me.Label17.AutoSize = True
        Me.Label17.Location = New System.Drawing.Point(132, 89)
        Me.Label17.Name = "Label17"
        Me.Label17.Size = New System.Drawing.Size(30, 13)
        Me.Label17.TabIndex = 124
        Me.Label17.Text = "Mnts"
        Me.Label17.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtFree
        '
        Me.txtFree.BackColor = System.Drawing.Color.White
        Me.txtFree.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFree.Location = New System.Drawing.Point(308, 148)
        Me.txtFree.MaxLength = 3
        Me.txtFree.Name = "txtFree"
        Me.txtFree.Size = New System.Drawing.Size(40, 26)
        Me.txtFree.TabIndex = 7
        Me.txtFree.Text = "0"
        Me.txtFree.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFree.Visible = False
        '
        'txtTambahan
        '
        Me.txtTambahan.BackColor = System.Drawing.Color.White
        Me.txtTambahan.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTambahan.Location = New System.Drawing.Point(308, 82)
        Me.txtTambahan.MaxLength = 3
        Me.txtTambahan.Name = "txtTambahan"
        Me.txtTambahan.Size = New System.Drawing.Size(40, 26)
        Me.txtTambahan.TabIndex = 5
        Me.txtTambahan.Text = "0"
        Me.txtTambahan.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Location = New System.Drawing.Point(15, 159)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(52, 13)
        Me.Label16.TabIndex = 119
        Me.Label16.Text = "End Hour"
        Me.Label16.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblEndHour
        '
        Me.lblEndHour.AutoSize = True
        Me.lblEndHour.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblEndHour.Location = New System.Drawing.Point(92, 159)
        Me.lblEndHour.Name = "lblEndHour"
        Me.lblEndHour.Size = New System.Drawing.Size(97, 16)
        Me.lblEndHour.TabIndex = 118
        Me.lblEndHour.Text = "00 : 00 : 00 : AM"
        Me.lblEndHour.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'txtJam
        '
        Me.txtJam.BackColor = System.Drawing.Color.White
        Me.txtJam.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJam.Location = New System.Drawing.Point(91, 82)
        Me.txtJam.MaxLength = 4
        Me.txtJam.Name = "txtJam"
        Me.txtJam.Size = New System.Drawing.Size(39, 26)
        Me.txtJam.TabIndex = 3
        Me.txtJam.Text = "0"
        Me.txtJam.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'VirtualDate
        '
        Me.VirtualDate.Image = CType(resources.GetObject("VirtualDate.Image"), System.Drawing.Image)
        Me.VirtualDate.Location = New System.Drawing.Point(404, 12)
        Me.VirtualDate.Name = "VirtualDate"
        Me.VirtualDate.Size = New System.Drawing.Size(50, 30)
        Me.VirtualDate.TabIndex = 2
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
        Me.Label3.Size = New System.Drawing.Size(29, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "Start"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CurrentTime
        '
        Me.CurrentTime.CalendarTrailingForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.CurrentTime.CustomFormat = "hh:mm:ss tt"
        Me.CurrentTime.Enabled = False
        Me.CurrentTime.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentTime.Format = System.Windows.Forms.DateTimePickerFormat.Time
        Me.CurrentTime.Location = New System.Drawing.Point(275, 51)
        Me.CurrentTime.Name = "CurrentTime"
        Me.CurrentTime.ShowUpDown = True
        Me.CurrentTime.Size = New System.Drawing.Size(112, 22)
        Me.CurrentTime.TabIndex = 1
        Me.CurrentTime.Visible = False
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
        'txtFreeHourInv
        '
        Me.txtFreeHourInv.Location = New System.Drawing.Point(-7, 222)
        Me.txtFreeHourInv.Name = "txtFreeHourInv"
        Me.txtFreeHourInv.Size = New System.Drawing.Size(26, 20)
        Me.txtFreeHourInv.TabIndex = 146
        Me.txtFreeHourInv.Visible = False
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.VirtualCalculator6)
        Me.GroupBox2.Controls.Add(Me.VirtualCalculator5)
        Me.GroupBox2.Controls.Add(Me.VirtualCalculator4)
        Me.GroupBox2.Controls.Add(Me.VirtualCalculator3)
        Me.GroupBox2.Controls.Add(Me.VirtualCalculator2)
        Me.GroupBox2.Controls.Add(Me.Label18)
        Me.GroupBox2.Controls.Add(Me.txtFemale50)
        Me.GroupBox2.Controls.Add(Me.txtMale50)
        Me.GroupBox2.Controls.Add(Me.Label15)
        Me.GroupBox2.Controls.Add(Me.VirtualCalculator)
        Me.GroupBox2.Controls.Add(Me.txtFemaleAdult)
        Me.GroupBox2.Controls.Add(Me.txtFemaleKid)
        Me.GroupBox2.Controls.Add(Me.txtMaleAdult)
        Me.GroupBox2.Controls.Add(Me.Label14)
        Me.GroupBox2.Controls.Add(Me.Label13)
        Me.GroupBox2.Controls.Add(Me.TotalVisitor)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 507)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(471, 59)
        Me.GroupBox2.TabIndex = 3
        Me.GroupBox2.TabStop = False
        '
        'VirtualCalculator6
        '
        Me.VirtualCalculator6.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualCalculator6.Image = CType(resources.GetObject("VirtualCalculator6.Image"), System.Drawing.Image)
        Me.VirtualCalculator6.Location = New System.Drawing.Point(404, 71)
        Me.VirtualCalculator6.Name = "VirtualCalculator6"
        Me.VirtualCalculator6.Size = New System.Drawing.Size(49, 26)
        Me.VirtualCalculator6.TabIndex = 24
        Me.VirtualCalculator6.UseVisualStyleBackColor = True
        Me.VirtualCalculator6.Visible = False
        Me.VirtualCalculator6.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'VirtualCalculator5
        '
        Me.VirtualCalculator5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualCalculator5.Image = CType(resources.GetObject("VirtualCalculator5.Image"), System.Drawing.Image)
        Me.VirtualCalculator5.Location = New System.Drawing.Point(404, 33)
        Me.VirtualCalculator5.Name = "VirtualCalculator5"
        Me.VirtualCalculator5.Size = New System.Drawing.Size(49, 26)
        Me.VirtualCalculator5.TabIndex = 22
        Me.VirtualCalculator5.UseVisualStyleBackColor = True
        Me.VirtualCalculator5.Visible = False
        Me.VirtualCalculator5.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'VirtualCalculator4
        '
        Me.VirtualCalculator4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualCalculator4.Image = CType(resources.GetObject("VirtualCalculator4.Image"), System.Drawing.Image)
        Me.VirtualCalculator4.Location = New System.Drawing.Point(275, 70)
        Me.VirtualCalculator4.Name = "VirtualCalculator4"
        Me.VirtualCalculator4.Size = New System.Drawing.Size(49, 26)
        Me.VirtualCalculator4.TabIndex = 20
        Me.VirtualCalculator4.UseVisualStyleBackColor = True
        Me.VirtualCalculator4.Visible = False
        Me.VirtualCalculator4.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'VirtualCalculator3
        '
        Me.VirtualCalculator3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualCalculator3.Image = CType(resources.GetObject("VirtualCalculator3.Image"), System.Drawing.Image)
        Me.VirtualCalculator3.Location = New System.Drawing.Point(275, 33)
        Me.VirtualCalculator3.Name = "VirtualCalculator3"
        Me.VirtualCalculator3.Size = New System.Drawing.Size(49, 26)
        Me.VirtualCalculator3.TabIndex = 18
        Me.VirtualCalculator3.UseVisualStyleBackColor = True
        Me.VirtualCalculator3.Visible = False
        Me.VirtualCalculator3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'VirtualCalculator2
        '
        Me.VirtualCalculator2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualCalculator2.Image = CType(resources.GetObject("VirtualCalculator2.Image"), System.Drawing.Image)
        Me.VirtualCalculator2.Location = New System.Drawing.Point(139, 70)
        Me.VirtualCalculator2.Name = "VirtualCalculator2"
        Me.VirtualCalculator2.Size = New System.Drawing.Size(49, 26)
        Me.VirtualCalculator2.TabIndex = 113
        Me.VirtualCalculator2.UseVisualStyleBackColor = True
        Me.VirtualCalculator2.Visible = False
        Me.VirtualCalculator2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label18
        '
        Me.Label18.AutoSize = True
        Me.Label18.Location = New System.Drawing.Point(350, 15)
        Me.Label18.Name = "Label18"
        Me.Label18.Size = New System.Drawing.Size(80, 13)
        Me.Label18.TabIndex = 112
        Me.Label18.Text = "=>50 Years Old"
        Me.Label18.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label18.Visible = False
        '
        'txtFemale50
        '
        Me.txtFemale50.BackColor = System.Drawing.Color.White
        Me.txtFemale50.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFemale50.Location = New System.Drawing.Point(348, 70)
        Me.txtFemale50.MaxLength = 3
        Me.txtFemale50.Name = "txtFemale50"
        Me.txtFemale50.Size = New System.Drawing.Size(50, 26)
        Me.txtFemale50.TabIndex = 23
        Me.txtFemale50.Text = "0"
        Me.txtFemale50.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFemale50.Visible = False
        '
        'txtMale50
        '
        Me.txtMale50.BackColor = System.Drawing.Color.White
        Me.txtMale50.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMale50.Location = New System.Drawing.Point(348, 33)
        Me.txtMale50.MaxLength = 3
        Me.txtMale50.Name = "txtMale50"
        Me.txtMale50.Size = New System.Drawing.Size(50, 26)
        Me.txtMale50.TabIndex = 21
        Me.txtMale50.Text = "0"
        Me.txtMale50.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMale50.Visible = False
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(11, 78)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(41, 13)
        Me.Label15.TabIndex = 107
        Me.Label15.Text = "Female"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label15.Visible = False
        '
        'VirtualCalculator
        '
        Me.VirtualCalculator.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualCalculator.Image = CType(resources.GetObject("VirtualCalculator.Image"), System.Drawing.Image)
        Me.VirtualCalculator.Location = New System.Drawing.Point(139, 19)
        Me.VirtualCalculator.Name = "VirtualCalculator"
        Me.VirtualCalculator.Size = New System.Drawing.Size(49, 26)
        Me.VirtualCalculator.TabIndex = 15
        Me.VirtualCalculator.UseVisualStyleBackColor = True
        Me.VirtualCalculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'txtFemaleAdult
        '
        Me.txtFemaleAdult.BackColor = System.Drawing.Color.White
        Me.txtFemaleAdult.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFemaleAdult.Location = New System.Drawing.Point(217, 70)
        Me.txtFemaleAdult.MaxLength = 3
        Me.txtFemaleAdult.Name = "txtFemaleAdult"
        Me.txtFemaleAdult.Size = New System.Drawing.Size(50, 26)
        Me.txtFemaleAdult.TabIndex = 19
        Me.txtFemaleAdult.Text = "0"
        Me.txtFemaleAdult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFemaleAdult.Visible = False
        '
        'txtFemaleKid
        '
        Me.txtFemaleKid.BackColor = System.Drawing.Color.White
        Me.txtFemaleKid.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtFemaleKid.Location = New System.Drawing.Point(80, 70)
        Me.txtFemaleKid.MaxLength = 3
        Me.txtFemaleKid.Name = "txtFemaleKid"
        Me.txtFemaleKid.Size = New System.Drawing.Size(50, 26)
        Me.txtFemaleKid.TabIndex = 16
        Me.txtFemaleKid.Text = "0"
        Me.txtFemaleKid.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtFemaleKid.Visible = False
        '
        'txtMaleAdult
        '
        Me.txtMaleAdult.BackColor = System.Drawing.Color.White
        Me.txtMaleAdult.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtMaleAdult.Location = New System.Drawing.Point(216, 32)
        Me.txtMaleAdult.MaxLength = 3
        Me.txtMaleAdult.Name = "txtMaleAdult"
        Me.txtMaleAdult.Size = New System.Drawing.Size(50, 26)
        Me.txtMaleAdult.TabIndex = 17
        Me.txtMaleAdult.Text = "0"
        Me.txtMaleAdult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.txtMaleAdult.Visible = False
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(224, 15)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(36, 13)
        Me.Label14.TabIndex = 100
        Me.Label14.Text = "Adults"
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label14.Visible = False
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(167, 3)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(27, 13)
        Me.Label13.TabIndex = 99
        Me.Label13.Text = "Kids"
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.Label13.Visible = False
        '
        'TotalVisitor
        '
        Me.TotalVisitor.BackColor = System.Drawing.Color.White
        Me.TotalVisitor.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalVisitor.Location = New System.Drawing.Point(80, 19)
        Me.TotalVisitor.MaxLength = 3
        Me.TotalVisitor.Name = "TotalVisitor"
        Me.TotalVisitor.Size = New System.Drawing.Size(50, 26)
        Me.TotalVisitor.TabIndex = 14
        Me.TotalVisitor.Text = "1"
        Me.TotalVisitor.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(11, 25)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(40, 13)
        Me.Label7.TabIndex = 92
        Me.Label7.Text = "Visitors"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
        Me.GroupBox4.Size = New System.Drawing.Size(468, 97)
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
        Me.ReservationList.Location = New System.Drawing.Point(91, 44)
        Me.ReservationList.MatchEntryTimeout = CType(100, Long)
        Me.ReservationList.MaxDropDownItems = CType(10, Short)
        Me.ReservationList.MaxLength = 32767
        Me.ReservationList.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.ReservationList.Name = "ReservationList"
        Me.ReservationList.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.ReservationList.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.ReservationList.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.ReservationList.Size = New System.Drawing.Size(296, 40)
        Me.ReservationList.TabIndex = 97
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
        Me.FindReservation.Location = New System.Drawing.Point(403, 44)
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
        Me.GroupBox5.Location = New System.Drawing.Point(499, 1)
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
        Me.BTNCancel.Location = New System.Drawing.Point(381, 585)
        Me.BTNCancel.Name = "BTNCancel"
        Me.BTNCancel.Size = New System.Drawing.Size(95, 41)
        Me.BTNCancel.TabIndex = 26
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
        Me.BTNSave.Location = New System.Drawing.Point(280, 585)
        Me.BTNSave.Name = "BTNSave"
        Me.BTNSave.Size = New System.Drawing.Size(95, 41)
        Me.BTNSave.TabIndex = 25
        Me.BTNSave.Text = "Save"
        Me.BTNSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNSave.UseVisualStyleBackColor = True
        Me.BTNSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNPrint
        '
        Me.BTNPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNPrint.Image = CType(resources.GetObject("BTNPrint.Image"), System.Drawing.Image)
        Me.BTNPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNPrint.Location = New System.Drawing.Point(6, 585)
        Me.BTNPrint.Name = "BTNPrint"
        Me.BTNPrint.Size = New System.Drawing.Size(95, 41)
        Me.BTNPrint.TabIndex = 147
        Me.BTNPrint.Text = "Print"
        Me.BTNPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNPrint.UseVisualStyleBackColor = True
        Me.BTNPrint.Visible = False
        Me.BTNPrint.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'txtBarcode
        '
        Me.txtBarcode.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.txtBarcode.Location = New System.Drawing.Point(22, 601)
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(161, 20)
        Me.txtBarcode.TabIndex = 148
        Me.txtBarcode.Text = "Type Barcode Here"
        Me.txtBarcode.Visible = False
        '
        'cmdBarcode
        '
        Me.cmdBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBarcode.Image = CType(resources.GetObject("cmdBarcode.Image"), System.Drawing.Image)
        Me.cmdBarcode.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdBarcode.Location = New System.Drawing.Point(107, 585)
        Me.cmdBarcode.Name = "cmdBarcode"
        Me.cmdBarcode.Size = New System.Drawing.Size(95, 41)
        Me.cmdBarcode.TabIndex = 149
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
        Me.dtOldDate.Location = New System.Drawing.Point(238, 14)
        Me.dtOldDate.Name = "dtOldDate"
        Me.dtOldDate.Size = New System.Drawing.Size(22, 22)
        Me.dtOldDate.TabIndex = 151
        Me.dtOldDate.Visible = False
        '
        'Form_Check_In_Room
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(488, 635)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdBarcode)
        Me.Controls.Add(Me.BTNPrint)
        Me.Controls.Add(Me.txtFreeHourInv)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox4)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.BTNCancel)
        Me.Controls.Add(Me.BTNSave)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox)
        Me.Controls.Add(Me.txtBarcode)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Check_In_Room"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Customer Check In"
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        CType(Me.grdMaster, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TableCombo, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.ServiceList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
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
    Friend WithEvents DateLabel As System.Windows.Forms.Label
    Friend WithEvents TimeLabel As System.Windows.Forms.Label
    Friend WithEvents TotalVisitor As System.Windows.Forms.TextBox
    Friend WithEvents VirtualDate As C1.Win.C1Input.C1Button
    Friend WithEvents Label16 As System.Windows.Forms.Label
    Friend WithEvents lblEndHour As System.Windows.Forms.Label
    Friend WithEvents txtJam As System.Windows.Forms.TextBox
    Friend WithEvents txtFree As System.Windows.Forms.TextBox
    Friend WithEvents txtTambahan As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label17 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents txtFemaleAdult As System.Windows.Forms.TextBox
    Friend WithEvents txtFemaleKid As System.Windows.Forms.TextBox
    Friend WithEvents txtMaleAdult As System.Windows.Forms.TextBox
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents VirtualCalculator As C1.Win.C1Input.C1Button
    Friend WithEvents txtMale50 As System.Windows.Forms.TextBox
    Friend WithEvents Label18 As System.Windows.Forms.Label
    Friend WithEvents txtFemale50 As System.Windows.Forms.TextBox
    Friend WithEvents VirtualCalculator6 As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualCalculator5 As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualCalculator4 As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualCalculator3 As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualCalculator2 As C1.Win.C1Input.C1Button
    Friend WithEvents Label19 As System.Windows.Forms.Label
    Friend WithEvents lblTotalHour As System.Windows.Forms.Label
    Friend WithEvents txtFreeInv As System.Windows.Forms.TextBox
    Friend WithEvents txtTambahanInv As System.Windows.Forms.TextBox
    Friend WithEvents txtJamInv As System.Windows.Forms.TextBox
    Friend WithEvents Label20 As System.Windows.Forms.Label
    Friend WithEvents Label21 As System.Windows.Forms.Label
    Friend WithEvents txtFreeHour As System.Windows.Forms.TextBox
    Friend WithEvents cmdDownTambahan As C1.Win.C1Input.C1Button
    Friend WithEvents cmdUpTambahan As C1.Win.C1Input.C1Button
    Friend WithEvents cmdDownRent As C1.Win.C1Input.C1Button
    Friend WithEvents cmdUpRent As C1.Win.C1Input.C1Button
    Friend WithEvents cmdDownFree As C1.Win.C1Input.C1Button
    Friend WithEvents cmdUpFree As C1.Win.C1Input.C1Button
    Friend WithEvents cmdDownHour As C1.Win.C1Input.C1Button
    Friend WithEvents cmdUpHour As C1.Win.C1Input.C1Button
    Friend WithEvents txtFreeHourInv As System.Windows.Forms.TextBox
    Friend WithEvents Label22 As System.Windows.Forms.Label
    Friend WithEvents Label23 As System.Windows.Forms.Label
    Friend WithEvents txtBonusMinutes As System.Windows.Forms.TextBox
    Friend WithEvents Label24 As System.Windows.Forms.Label
    Friend WithEvents cmdFreeMnt As C1.Win.C1Input.C1Button
    Friend WithEvents grdMaster As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTNPrint As C1.Win.C1Input.C1Button
    Friend WithEvents ReservationList As C1.Win.C1List.C1Combo
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents cmdBarcode As C1.Win.C1Input.C1Button
    Friend WithEvents dtOldDate As System.Windows.Forms.DateTimePicker
End Class
