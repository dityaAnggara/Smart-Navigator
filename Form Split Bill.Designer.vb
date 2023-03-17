<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Split_Bill
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Split_Bill))
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.BTNMoveDown2 = New C1.Win.C1Input.C1Button
        Me.BTNMoveUp2 = New C1.Win.C1Input.C1Button
        Me.TableList = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.CustomerType1 = New C1.Win.C1List.C1Combo
        Me.CustomerList1 = New C1.Win.C1List.C1Combo
        Me.Label12 = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.CustName = New System.Windows.Forms.Label
        Me.CustType = New System.Windows.Forms.Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.PAXTxt = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.TableNameTxt = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.CustomerType2 = New C1.Win.C1List.C1Combo
        Me.CustomerList2 = New C1.Win.C1List.C1Combo
        Me.Label14 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.Spliter1 = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.BTNMoveDown = New C1.Win.C1Input.C1Button
        Me.BTNMoveUp = New C1.Win.C1Input.C1Button
        Me.BTNCancel1 = New C1.Win.C1Input.C1Button
        Me.BTNMoveTo1 = New C1.Win.C1Input.C1Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.GroupBox = New System.Windows.Forms.GroupBox
        Me.FindCust = New C1.Win.C1Input.C1Button
        Me.CustomerList = New C1.Win.C1List.C1Combo
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TableCombo = New C1.Win.C1List.C1Combo
        Me.VirtualKey = New C1.Win.C1Input.C1Button
        Me.CustNametxt = New System.Windows.Forms.TextBox
        Me.PAX2txt = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.BTNCancel = New C1.Win.C1Input.C1Button
        Me.BTNSave = New C1.Win.C1Input.C1Button
        Me.GroupBox5.SuspendLayout()
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerType1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerList1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.CustomerType2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.CustomerList2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.Spliter1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox.SuspendLayout()
        CType(Me.CustomerList, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TableCombo, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.BTNMoveDown2)
        Me.GroupBox5.Controls.Add(Me.BTNMoveUp2)
        Me.GroupBox5.Controls.Add(Me.TableList)
        Me.GroupBox5.Location = New System.Drawing.Point(8, 153)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(305, 461)
        Me.GroupBox5.TabIndex = 0
        Me.GroupBox5.TabStop = False
        '
        'BTNMoveDown2
        '
        Me.BTNMoveDown2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveDown2.Image = CType(resources.GetObject("BTNMoveDown2.Image"), System.Drawing.Image)
        Me.BTNMoveDown2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveDown2.Location = New System.Drawing.Point(152, 410)
        Me.BTNMoveDown2.Name = "BTNMoveDown2"
        Me.BTNMoveDown2.Size = New System.Drawing.Size(91, 43)
        Me.BTNMoveDown2.TabIndex = 7
        Me.BTNMoveDown2.Text = "Down"
        Me.BTNMoveDown2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNMoveDown2.UseVisualStyleBackColor = True
        Me.BTNMoveDown2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNMoveUp2
        '
        Me.BTNMoveUp2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveUp2.Image = CType(resources.GetObject("BTNMoveUp2.Image"), System.Drawing.Image)
        Me.BTNMoveUp2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveUp2.Location = New System.Drawing.Point(55, 410)
        Me.BTNMoveUp2.Name = "BTNMoveUp2"
        Me.BTNMoveUp2.Size = New System.Drawing.Size(91, 43)
        Me.BTNMoveUp2.TabIndex = 6
        Me.BTNMoveUp2.Text = "Up"
        Me.BTNMoveUp2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNMoveUp2.UseVisualStyleBackColor = True
        Me.BTNMoveUp2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'TableList
        '
        Me.TableList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.TableList.AllowEditing = False
        Me.TableList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.TableList.ColumnInfo = resources.GetString("TableList.ColumnInfo")
        Me.TableList.ExtendLastCol = True
        Me.TableList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.TableList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableList.Location = New System.Drawing.Point(8, 14)
        Me.TableList.Name = "TableList"
        Me.TableList.Rows.Count = 1
        Me.TableList.Rows.DefaultSize = 19
        Me.TableList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.TableList.Size = New System.Drawing.Size(288, 388)
        Me.TableList.StyleInfo = resources.GetString("TableList.StyleInfo")
        Me.TableList.TabIndex = 0
        Me.TableList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'CustomerType1
        '
        Me.CustomerType1.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CustomerType1.AlternatingRows = True
        Me.CustomerType1.AutoCompletion = True
        Me.CustomerType1.AutoDropDown = True
        Me.CustomerType1.AutoSize = False
        Me.CustomerType1.Caption = ""
        Me.CustomerType1.CaptionHeight = 17
        Me.CustomerType1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CustomerType1.ColumnCaptionHeight = 17
        Me.CustomerType1.ColumnFooterHeight = 17
        Me.CustomerType1.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CustomerType1.ContentHeight = 34
        Me.CustomerType1.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.CustomerType1.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CustomerType1.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CustomerType1.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CustomerType1.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CustomerType1.EditorHeight = 34
        Me.CustomerType1.ExtendRightColumn = True
        Me.CustomerType1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerType1.Images.Add(CType(resources.GetObject("CustomerType1.Images"), System.Drawing.Image))
        Me.CustomerType1.ItemHeight = 30
        Me.CustomerType1.Location = New System.Drawing.Point(63, 19)
        Me.CustomerType1.MatchEntryTimeout = CType(100, Long)
        Me.CustomerType1.MaxDropDownItems = CType(10, Short)
        Me.CustomerType1.MaxLength = 32767
        Me.CustomerType1.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CustomerType1.Name = "CustomerType1"
        Me.CustomerType1.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CustomerType1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CustomerType1.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CustomerType1.Size = New System.Drawing.Size(171, 40)
        Me.CustomerType1.TabIndex = 0
        Me.CustomerType1.Text = "Choose here ..."
        Me.CustomerType1.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.CustomerType1.PropBag = resources.GetString("CustomerType1.PropBag")
        '
        'CustomerList1
        '
        Me.CustomerList1.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CustomerList1.AlternatingRows = True
        Me.CustomerList1.AutoCompletion = True
        Me.CustomerList1.AutoDropDown = True
        Me.CustomerList1.AutoSize = False
        Me.CustomerList1.Caption = ""
        Me.CustomerList1.CaptionHeight = 17
        Me.CustomerList1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CustomerList1.ColumnCaptionHeight = 17
        Me.CustomerList1.ColumnFooterHeight = 17
        Me.CustomerList1.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CustomerList1.ContentHeight = 34
        Me.CustomerList1.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.CustomerList1.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CustomerList1.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CustomerList1.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CustomerList1.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CustomerList1.EditorHeight = 34
        Me.CustomerList1.Enabled = False
        Me.CustomerList1.ExtendRightColumn = True
        Me.CustomerList1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerList1.Images.Add(CType(resources.GetObject("CustomerList1.Images"), System.Drawing.Image))
        Me.CustomerList1.ItemHeight = 30
        Me.CustomerList1.Location = New System.Drawing.Point(63, 69)
        Me.CustomerList1.MatchEntryTimeout = CType(100, Long)
        Me.CustomerList1.MaxDropDownItems = CType(10, Short)
        Me.CustomerList1.MaxLength = 32767
        Me.CustomerList1.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CustomerList1.Name = "CustomerList1"
        Me.CustomerList1.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CustomerList1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CustomerList1.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CustomerList1.Size = New System.Drawing.Size(227, 40)
        Me.CustomerList1.TabIndex = 1
        Me.CustomerList1.Text = "Choose here ..."
        Me.CustomerList1.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.CustomerList1.PropBag = resources.GetString("CustomerList1.PropBag")
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(6, 33)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 95
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.CustName)
        Me.GroupBox1.Controls.Add(Me.CustType)
        Me.GroupBox1.Controls.Add(Me.Label7)
        Me.GroupBox1.Controls.Add(Me.PAXTxt)
        Me.GroupBox1.Controls.Add(Me.Label5)
        Me.GroupBox1.Controls.Add(Me.TableNameTxt)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(305, 145)
        Me.GroupBox1.TabIndex = 16
        Me.GroupBox1.TabStop = False
        '
        'CustName
        '
        Me.CustName.AutoSize = True
        Me.CustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustName.ForeColor = System.Drawing.Color.Maroon
        Me.CustName.Location = New System.Drawing.Point(109, 83)
        Me.CustName.Name = "CustName"
        Me.CustName.Size = New System.Drawing.Size(118, 16)
        Me.CustName.TabIndex = 105
        Me.CustName.Text = "Customer Name"
        '
        'CustType
        '
        Me.CustType.AutoSize = True
        Me.CustType.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustType.ForeColor = System.Drawing.Color.Black
        Me.CustType.Location = New System.Drawing.Point(109, 52)
        Me.CustType.Name = "CustType"
        Me.CustType.Size = New System.Drawing.Size(73, 16)
        Me.CustType.TabIndex = 103
        Me.CustType.Text = "MEMBER"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 56)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(51, 13)
        Me.Label7.TabIndex = 102
        Me.Label7.Text = "Customer"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'PAXTxt
        '
        Me.PAXTxt.AutoSize = True
        Me.PAXTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PAXTxt.ForeColor = System.Drawing.Color.Black
        Me.PAXTxt.Location = New System.Drawing.Point(109, 114)
        Me.PAXTxt.Name = "PAXTxt"
        Me.PAXTxt.Size = New System.Drawing.Size(16, 16)
        Me.PAXTxt.TabIndex = 101
        Me.PAXTxt.Text = "0"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(15, 115)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 100
        Me.Label5.Text = "Visitor"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableNameTxt
        '
        Me.TableNameTxt.AutoSize = True
        Me.TableNameTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableNameTxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TableNameTxt.Location = New System.Drawing.Point(108, 18)
        Me.TableNameTxt.Name = "TableNameTxt"
        Me.TableNameTxt.Size = New System.Drawing.Size(100, 20)
        Me.TableNameTxt.TabIndex = 99
        Me.TableNameTxt.Text = "MEJA V.I.P"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(15, 22)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 98
        Me.Label8.Text = "Current Table"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'CustomerType2
        '
        Me.CustomerType2.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CustomerType2.AlternatingRows = True
        Me.CustomerType2.AutoCompletion = True
        Me.CustomerType2.AutoDropDown = True
        Me.CustomerType2.AutoSize = False
        Me.CustomerType2.Caption = ""
        Me.CustomerType2.CaptionHeight = 17
        Me.CustomerType2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CustomerType2.ColumnCaptionHeight = 17
        Me.CustomerType2.ColumnFooterHeight = 17
        Me.CustomerType2.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CustomerType2.ContentHeight = 34
        Me.CustomerType2.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.CustomerType2.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CustomerType2.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CustomerType2.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CustomerType2.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CustomerType2.EditorHeight = 34
        Me.CustomerType2.ExtendRightColumn = True
        Me.CustomerType2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerType2.Images.Add(CType(resources.GetObject("CustomerType2.Images"), System.Drawing.Image))
        Me.CustomerType2.ItemHeight = 30
        Me.CustomerType2.Location = New System.Drawing.Point(63, 19)
        Me.CustomerType2.MatchEntryTimeout = CType(100, Long)
        Me.CustomerType2.MaxDropDownItems = CType(10, Short)
        Me.CustomerType2.MaxLength = 32767
        Me.CustomerType2.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CustomerType2.Name = "CustomerType2"
        Me.CustomerType2.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CustomerType2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CustomerType2.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CustomerType2.Size = New System.Drawing.Size(171, 40)
        Me.CustomerType2.TabIndex = 0
        Me.CustomerType2.Text = "Choose here ..."
        Me.CustomerType2.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.CustomerType2.PropBag = resources.GetString("CustomerType2.PropBag")
        '
        'CustomerList2
        '
        Me.CustomerList2.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.CustomerList2.AlternatingRows = True
        Me.CustomerList2.AutoCompletion = True
        Me.CustomerList2.AutoDropDown = True
        Me.CustomerList2.AutoSize = False
        Me.CustomerList2.Caption = ""
        Me.CustomerList2.CaptionHeight = 17
        Me.CustomerList2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.CustomerList2.ColumnCaptionHeight = 17
        Me.CustomerList2.ColumnFooterHeight = 17
        Me.CustomerList2.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.CustomerList2.ContentHeight = 34
        Me.CustomerList2.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.CustomerList2.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.CustomerList2.EditorBackColor = System.Drawing.SystemColors.Window
        Me.CustomerList2.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.CustomerList2.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.CustomerList2.EditorHeight = 34
        Me.CustomerList2.Enabled = False
        Me.CustomerList2.ExtendRightColumn = True
        Me.CustomerList2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustomerList2.Images.Add(CType(resources.GetObject("CustomerList2.Images"), System.Drawing.Image))
        Me.CustomerList2.ItemHeight = 30
        Me.CustomerList2.Location = New System.Drawing.Point(63, 69)
        Me.CustomerList2.MatchEntryTimeout = CType(100, Long)
        Me.CustomerList2.MaxDropDownItems = CType(10, Short)
        Me.CustomerList2.MaxLength = 32767
        Me.CustomerList2.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CustomerList2.Name = "CustomerList2"
        Me.CustomerList2.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CustomerList2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CustomerList2.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CustomerList2.Size = New System.Drawing.Size(227, 40)
        Me.CustomerList2.TabIndex = 1
        Me.CustomerList2.Text = "Choose here ..."
        Me.CustomerList2.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.CustomerList2.PropBag = resources.GetString("CustomerList2.PropBag")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(6, 33)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(31, 13)
        Me.Label14.TabIndex = 100
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.BackColor = System.Drawing.Color.FromArgb(CType(CType(255, Byte), Integer), CType(CType(255, Byte), Integer), CType(CType(192, Byte), Integer))
        Me.Label2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(31, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(26, 27)
        Me.Label2.TabIndex = 1
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.Spliter1)
        Me.GroupBox3.Controls.Add(Me.BTNMoveDown)
        Me.GroupBox3.Controls.Add(Me.BTNMoveUp)
        Me.GroupBox3.Location = New System.Drawing.Point(376, 153)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(305, 461)
        Me.GroupBox3.TabIndex = 4
        Me.GroupBox3.TabStop = False
        '
        'Spliter1
        '
        Me.Spliter1.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.Spliter1.AllowEditing = False
        Me.Spliter1.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.Spliter1.ColumnInfo = resources.GetString("Spliter1.ColumnInfo")
        Me.Spliter1.ExtendLastCol = True
        Me.Spliter1.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.Spliter1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Spliter1.Location = New System.Drawing.Point(8, 15)
        Me.Spliter1.Name = "Spliter1"
        Me.Spliter1.Rows.Count = 1
        Me.Spliter1.Rows.DefaultSize = 19
        Me.Spliter1.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.Spliter1.Size = New System.Drawing.Size(288, 387)
        Me.Spliter1.StyleInfo = resources.GetString("Spliter1.StyleInfo")
        Me.Spliter1.TabIndex = 0
        Me.Spliter1.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'BTNMoveDown
        '
        Me.BTNMoveDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveDown.Image = CType(resources.GetObject("BTNMoveDown.Image"), System.Drawing.Image)
        Me.BTNMoveDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveDown.Location = New System.Drawing.Point(156, 410)
        Me.BTNMoveDown.Name = "BTNMoveDown"
        Me.BTNMoveDown.Size = New System.Drawing.Size(91, 43)
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
        Me.BTNMoveUp.Location = New System.Drawing.Point(59, 410)
        Me.BTNMoveUp.Name = "BTNMoveUp"
        Me.BTNMoveUp.Size = New System.Drawing.Size(91, 43)
        Me.BTNMoveUp.TabIndex = 6
        Me.BTNMoveUp.Text = "Up"
        Me.BTNMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNMoveUp.UseVisualStyleBackColor = True
        Me.BTNMoveUp.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNCancel1
        '
        Me.BTNCancel1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCancel1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNCancel1.Location = New System.Drawing.Point(322, 373)
        Me.BTNCancel1.Name = "BTNCancel1"
        Me.BTNCancel1.Size = New System.Drawing.Size(47, 41)
        Me.BTNCancel1.TabIndex = 1
        Me.BTNCancel1.Text = "<<"
        Me.BTNCancel1.UseVisualStyleBackColor = True
        Me.BTNCancel1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNMoveTo1
        '
        Me.BTNMoveTo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveTo1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveTo1.Location = New System.Drawing.Point(322, 326)
        Me.BTNMoveTo1.Name = "BTNMoveTo1"
        Me.BTNMoveTo1.Size = New System.Drawing.Size(47, 41)
        Me.BTNMoveTo1.TabIndex = 1
        Me.BTNMoveTo1.Text = ">>"
        Me.BTNMoveTo1.UseVisualStyleBackColor = True
        Me.BTNMoveTo1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(318, 304)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(56, 13)
        Me.Label3.TabIndex = 22
        Me.Label3.Text = "MOVE TO"
        '
        'GroupBox
        '
        Me.GroupBox.Controls.Add(Me.FindCust)
        Me.GroupBox.Controls.Add(Me.CustomerList)
        Me.GroupBox.Controls.Add(Me.Label4)
        Me.GroupBox.Controls.Add(Me.Label1)
        Me.GroupBox.Controls.Add(Me.TableCombo)
        Me.GroupBox.Controls.Add(Me.VirtualKey)
        Me.GroupBox.Controls.Add(Me.CustNametxt)
        Me.GroupBox.Controls.Add(Me.PAX2txt)
        Me.GroupBox.Location = New System.Drawing.Point(375, 2)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(305, 145)
        Me.GroupBox.TabIndex = 23
        Me.GroupBox.TabStop = False
        '
        'FindCust
        '
        Me.FindCust.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FindCust.Image = CType(resources.GetObject("FindCust.Image"), System.Drawing.Image)
        Me.FindCust.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.FindCust.Location = New System.Drawing.Point(256, 12)
        Me.FindCust.Name = "FindCust"
        Me.FindCust.Size = New System.Drawing.Size(40, 40)
        Me.FindCust.TabIndex = 25
        Me.FindCust.Text = "Find"
        Me.FindCust.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.FindCust.UseVisualStyleBackColor = True
        Me.FindCust.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
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
        Me.CustomerList.Location = New System.Drawing.Point(68, 12)
        Me.CustomerList.MatchEntryTimeout = CType(100, Long)
        Me.CustomerList.MaxDropDownItems = CType(10, Short)
        Me.CustomerList.MaxLength = 32767
        Me.CustomerList.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.CustomerList.Name = "CustomerList"
        Me.CustomerList.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.CustomerList.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.CustomerList.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.CustomerList.Size = New System.Drawing.Size(181, 40)
        Me.CustomerList.TabIndex = 24
        Me.CustomerList.Text = "Choose here ..."
        Me.CustomerList.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.CustomerList.PropBag = resources.GetString("CustomerList.PropBag")
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(7, 25)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(51, 13)
        Me.Label4.TabIndex = 105
        Me.Label4.Text = "Customer"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(5, 105)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 26)
        Me.Label1.TabIndex = 95
        Me.Label1.Text = "Destination" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "    Table"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight
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
        Me.TableCombo.Location = New System.Drawing.Point(68, 96)
        Me.TableCombo.MatchEntryTimeout = CType(100, Long)
        Me.TableCombo.MaxDropDownItems = CType(10, Short)
        Me.TableCombo.MaxLength = 32767
        Me.TableCombo.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.TableCombo.Name = "TableCombo"
        Me.TableCombo.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.TableCombo.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.TableCombo.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.TableCombo.Size = New System.Drawing.Size(181, 40)
        Me.TableCombo.TabIndex = 4
        Me.TableCombo.Text = "Choose here ..."
        Me.TableCombo.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.TableCombo.PropBag = resources.GetString("TableCombo.PropBag")
        '
        'VirtualKey
        '
        Me.VirtualKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualKey.Image = CType(resources.GetObject("VirtualKey.Image"), System.Drawing.Image)
        Me.VirtualKey.Location = New System.Drawing.Point(256, 58)
        Me.VirtualKey.Name = "VirtualKey"
        Me.VirtualKey.Size = New System.Drawing.Size(40, 30)
        Me.VirtualKey.TabIndex = 3
        Me.VirtualKey.UseVisualStyleBackColor = True
        Me.VirtualKey.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'CustNametxt
        '
        Me.CustNametxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustNametxt.Location = New System.Drawing.Point(68, 61)
        Me.CustNametxt.Name = "CustNametxt"
        Me.CustNametxt.Size = New System.Drawing.Size(181, 26)
        Me.CustNametxt.TabIndex = 2
        '
        'PAX2txt
        '
        Me.PAX2txt.AutoSize = True
        Me.PAX2txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.PAX2txt.ForeColor = System.Drawing.Color.Black
        Me.PAX2txt.Location = New System.Drawing.Point(255, 67)
        Me.PAX2txt.Name = "PAX2txt"
        Me.PAX2txt.Size = New System.Drawing.Size(16, 16)
        Me.PAX2txt.TabIndex = 109
        Me.PAX2txt.Text = "1"
        Me.PAX2txt.Visible = False
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.Label11.Location = New System.Drawing.Point(111, 15)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(84, 16)
        Me.Label11.TabIndex = 107
        Me.Label11.Text = "MEJA V.I.P"
        '
        'BTNCancel
        '
        Me.BTNCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCancel.Image = CType(resources.GetObject("BTNCancel.Image"), System.Drawing.Image)
        Me.BTNCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNCancel.Location = New System.Drawing.Point(542, 621)
        Me.BTNCancel.Name = "BTNCancel"
        Me.BTNCancel.Size = New System.Drawing.Size(140, 41)
        Me.BTNCancel.TabIndex = 8
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
        Me.BTNSave.Location = New System.Drawing.Point(396, 621)
        Me.BTNSave.Name = "BTNSave"
        Me.BTNSave.Size = New System.Drawing.Size(140, 41)
        Me.BTNSave.TabIndex = 7
        Me.BTNSave.Text = "Save"
        Me.BTNSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNSave.UseVisualStyleBackColor = True
        Me.BTNSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Form_Split_Bill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(689, 670)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTNCancel1)
        Me.Controls.Add(Me.GroupBox)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.BTNMoveTo1)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTNCancel)
        Me.Controls.Add(Me.BTNSave)
        Me.Controls.Add(Me.GroupBox5)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Split_Bill"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Split Bill"
        Me.GroupBox5.ResumeLayout(False)
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerType1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerList1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.CustomerType2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.CustomerList2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        CType(Me.Spliter1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        CType(Me.CustomerList, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TableCombo, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNCancel As C1.Win.C1Input.C1Button
    Friend WithEvents BTNSave As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents BTNMoveTo1 As C1.Win.C1Input.C1Button
    Friend WithEvents TableList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Spliter1 As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BTNCancel1 As C1.Win.C1Input.C1Button
    Friend WithEvents PAXTxt As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents TableNameTxt As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents CustName As System.Windows.Forms.Label
    Friend WithEvents CustType As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents CustomerType1 As C1.Win.C1List.C1Combo
    Friend WithEvents CustomerList1 As C1.Win.C1List.C1Combo
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents CustomerType2 As C1.Win.C1List.C1Combo
    Friend WithEvents CustomerList2 As C1.Win.C1List.C1Combo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableCombo As C1.Win.C1List.C1Combo
    Friend WithEvents VirtualKey As C1.Win.C1Input.C1Button
    Friend WithEvents CustNametxt As System.Windows.Forms.TextBox
    Friend WithEvents PAX2txt As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BTNMoveDown2 As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveUp2 As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveDown As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveUp As C1.Win.C1Input.C1Button
    Friend WithEvents FindCust As C1.Win.C1Input.C1Button
    Friend WithEvents CustomerList As C1.Win.C1List.C1Combo
End Class
