<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Kitchen_Monitor
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
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Kitchen_Monitor))
        Me.InputBox = New System.Windows.Forms.GroupBox
        Me.ListDetail = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.DataUID = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BTNRefresh = New C1.Win.C1Input.C1Button
        Me.BTNMoveDown = New C1.Win.C1Input.C1Button
        Me.BTNMoveUp = New C1.Win.C1Input.C1Button
        Me.BTNViewNotes = New C1.Win.C1Input.C1Button
        Me.BTNUndo = New C1.Win.C1Input.C1Button
        Me.BTNDump = New C1.Win.C1Input.C1Button
        Me.KitchenList = New C1.Win.C1List.C1Combo
        Me.BTNClose = New C1.Win.C1Input.C1Button
        Me.BTNPrint = New C1.Win.C1Input.C1Button
        Me.TimerRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.InputBox.SuspendLayout()
        CType(Me.ListDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DataUID, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.KitchenList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'InputBox
        '
        Me.InputBox.Controls.Add(Me.ListDetail)
        Me.InputBox.Controls.Add(Me.DataUID)
        Me.InputBox.Location = New System.Drawing.Point(-1, -7)
        Me.InputBox.Name = "InputBox"
        Me.InputBox.Size = New System.Drawing.Size(1026, 718)
        Me.InputBox.TabIndex = 67
        Me.InputBox.TabStop = False
        '
        'ListDetail
        '
        Me.ListDetail.AllowEditing = False
        Me.ListDetail.AutoClipboard = True
        Me.ListDetail.AutoResize = False
        Me.ListDetail.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.Light3D
        Me.ListDetail.ColumnInfo = resources.GetString("ListDetail.ColumnInfo")
        Me.ListDetail.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
        Me.ListDetail.ExtendLastCol = True
        Me.ListDetail.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.ListDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ListDetail.Location = New System.Drawing.Point(15, 18)
        Me.ListDetail.Name = "ListDetail"
        Me.ListDetail.Rows.Count = 1
        Me.ListDetail.Rows.DefaultSize = 19
        Me.ListDetail.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.ListDetail.Size = New System.Drawing.Size(996, 614)
        Me.ListDetail.StyleInfo = resources.GetString("ListDetail.StyleInfo")
        Me.ListDetail.TabIndex = 112
        Me.ListDetail.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'DataUID
        '
        Me.DataUID.AllowEditing = False
        Me.DataUID.AutoClipboard = True
        Me.DataUID.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None
        Me.DataUID.ColumnInfo = "4,1,0,0,0,115,Columns:0{Width:17;Visible:False;Style:""DataType:System.Boolean;Tex" & _
            "tAlign:CenterCenter;ImageAlign:CenterCenter;"";}" & Global.Microsoft.VisualBasic.ChrW(9) & "1{Width:143;}" & Global.Microsoft.VisualBasic.ChrW(9) & "2{Width:125;}" & Global.Microsoft.VisualBasic.ChrW(9)
        Me.DataUID.DrawMode = C1.Win.C1FlexGrid.DrawModeEnum.OwnerDraw
        Me.DataUID.ExtendLastCol = True
        Me.DataUID.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.DataUID.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DataUID.Location = New System.Drawing.Point(580, 525)
        Me.DataUID.Name = "DataUID"
        Me.DataUID.Rows.Count = 1
        Me.DataUID.Rows.DefaultSize = 23
        Me.DataUID.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.DataUID.Size = New System.Drawing.Size(409, 81)
        Me.DataUID.StyleInfo = resources.GetString("DataUID.StyleInfo")
        Me.DataUID.TabIndex = 113
        Me.DataUID.Visible = False
        Me.DataUID.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTNRefresh)
        Me.GroupBox2.Controls.Add(Me.BTNMoveDown)
        Me.GroupBox2.Controls.Add(Me.BTNMoveUp)
        Me.GroupBox2.Controls.Add(Me.BTNViewNotes)
        Me.GroupBox2.Controls.Add(Me.BTNUndo)
        Me.GroupBox2.Controls.Add(Me.BTNDump)
        Me.GroupBox2.Controls.Add(Me.KitchenList)
        Me.GroupBox2.Controls.Add(Me.BTNClose)
        Me.GroupBox2.Controls.Add(Me.BTNPrint)
        Me.GroupBox2.Location = New System.Drawing.Point(11, 631)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1002, 60)
        Me.GroupBox2.TabIndex = 68
        Me.GroupBox2.TabStop = False
        '
        'BTNRefresh
        '
        Me.BTNRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNRefresh.Image = CType(resources.GetObject("BTNRefresh.Image"), System.Drawing.Image)
        Me.BTNRefresh.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNRefresh.Location = New System.Drawing.Point(697, 12)
        Me.BTNRefresh.Name = "BTNRefresh"
        Me.BTNRefresh.Size = New System.Drawing.Size(95, 41)
        Me.BTNRefresh.TabIndex = 80
        Me.BTNRefresh.Text = "Refresh"
        Me.BTNRefresh.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNRefresh.UseVisualStyleBackColor = True
        Me.BTNRefresh.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNMoveDown
        '
        Me.BTNMoveDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveDown.Image = CType(resources.GetObject("BTNMoveDown.Image"), System.Drawing.Image)
        Me.BTNMoveDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveDown.Location = New System.Drawing.Point(493, 12)
        Me.BTNMoveDown.Name = "BTNMoveDown"
        Me.BTNMoveDown.Size = New System.Drawing.Size(95, 41)
        Me.BTNMoveDown.TabIndex = 79
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
        Me.BTNMoveUp.Location = New System.Drawing.Point(392, 12)
        Me.BTNMoveUp.Name = "BTNMoveUp"
        Me.BTNMoveUp.Size = New System.Drawing.Size(95, 41)
        Me.BTNMoveUp.TabIndex = 78
        Me.BTNMoveUp.Text = "Up"
        Me.BTNMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNMoveUp.UseVisualStyleBackColor = True
        Me.BTNMoveUp.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNViewNotes
        '
        Me.BTNViewNotes.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNViewNotes.Image = CType(resources.GetObject("BTNViewNotes.Image"), System.Drawing.Image)
        Me.BTNViewNotes.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNViewNotes.Location = New System.Drawing.Point(596, 12)
        Me.BTNViewNotes.Name = "BTNViewNotes"
        Me.BTNViewNotes.Size = New System.Drawing.Size(95, 41)
        Me.BTNViewNotes.TabIndex = 77
        Me.BTNViewNotes.Text = "View Notes"
        Me.BTNViewNotes.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNViewNotes.UseVisualStyleBackColor = True
        Me.BTNViewNotes.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNUndo
        '
        Me.BTNUndo.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNUndo.Image = CType(resources.GetObject("BTNUndo.Image"), System.Drawing.Image)
        Me.BTNUndo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNUndo.Location = New System.Drawing.Point(285, 12)
        Me.BTNUndo.Name = "BTNUndo"
        Me.BTNUndo.Size = New System.Drawing.Size(95, 41)
        Me.BTNUndo.TabIndex = 75
        Me.BTNUndo.Text = "Undo"
        Me.BTNUndo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNUndo.UseVisualStyleBackColor = True
        Me.BTNUndo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNDump
        '
        Me.BTNDump.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNDump.Image = CType(resources.GetObject("BTNDump.Image"), System.Drawing.Image)
        Me.BTNDump.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNDump.Location = New System.Drawing.Point(184, 12)
        Me.BTNDump.Name = "BTNDump"
        Me.BTNDump.Size = New System.Drawing.Size(95, 41)
        Me.BTNDump.TabIndex = 73
        Me.BTNDump.Text = "Dump"
        Me.BTNDump.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNDump.UseVisualStyleBackColor = True
        Me.BTNDump.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'KitchenList
        '
        Me.KitchenList.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.KitchenList.AlternatingRows = True
        Me.KitchenList.AutoCompletion = True
        Me.KitchenList.AutoDropDown = True
        Me.KitchenList.AutoSize = False
        Me.KitchenList.Caption = ""
        Me.KitchenList.CaptionHeight = 17
        Me.KitchenList.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.KitchenList.ColumnCaptionHeight = 17
        Me.KitchenList.ColumnFooterHeight = 17
        Me.KitchenList.ColumnWidth = 100
        Me.KitchenList.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.KitchenList.ContentHeight = 34
        Me.KitchenList.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.KitchenList.DeadAreaBackColor = System.Drawing.Color.White
        Me.KitchenList.EditorBackColor = System.Drawing.SystemColors.Window
        Me.KitchenList.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.KitchenList.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.KitchenList.EditorHeight = 34
        Me.KitchenList.ExtendRightColumn = True
        Me.KitchenList.Images.Add(CType(resources.GetObject("KitchenList.Images"), System.Drawing.Image))
        Me.KitchenList.ItemHeight = 30
        Me.KitchenList.Location = New System.Drawing.Point(7, 13)
        Me.KitchenList.MatchEntryTimeout = CType(100, Long)
        Me.KitchenList.MaxDropDownItems = CType(10, Short)
        Me.KitchenList.MaxLength = 32767
        Me.KitchenList.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.KitchenList.Name = "KitchenList"
        Me.KitchenList.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.KitchenList.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.KitchenList.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.KitchenList.Size = New System.Drawing.Size(171, 40)
        Me.KitchenList.TabIndex = 72
        Me.KitchenList.Text = "Choose here ..."
        Me.KitchenList.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.KitchenList.PropBag = resources.GetString("KitchenList.PropBag")
        '
        'BTNClose
        '
        Me.BTNClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNClose.Image = CType(resources.GetObject("BTNClose.Image"), System.Drawing.Image)
        Me.BTNClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNClose.Location = New System.Drawing.Point(901, 12)
        Me.BTNClose.Name = "BTNClose"
        Me.BTNClose.Size = New System.Drawing.Size(95, 41)
        Me.BTNClose.TabIndex = 70
        Me.BTNClose.Text = "Close"
        Me.BTNClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNClose.UseVisualStyleBackColor = True
        Me.BTNClose.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNPrint
        '
        Me.BTNPrint.Enabled = False
        Me.BTNPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNPrint.Image = CType(resources.GetObject("BTNPrint.Image"), System.Drawing.Image)
        Me.BTNPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNPrint.Location = New System.Drawing.Point(800, 12)
        Me.BTNPrint.Name = "BTNPrint"
        Me.BTNPrint.Size = New System.Drawing.Size(95, 41)
        Me.BTNPrint.TabIndex = 69
        Me.BTNPrint.Text = "Print"
        Me.BTNPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNPrint.UseVisualStyleBackColor = True
        Me.BTNPrint.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Silver
        '
        'TimerRefresh
        '
        Me.TimerRefresh.Enabled = True
        Me.TimerRefresh.Interval = 1000
        '
        'Form_Kitchen_Monitor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1024, 702)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.InputBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Kitchen_Monitor"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Kitchen Monitor"
        Me.InputBox.ResumeLayout(False)
        CType(Me.ListDetail, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DataUID, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.KitchenList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents InputBox As System.Windows.Forms.GroupBox
    Friend WithEvents ListDetail As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNClose As C1.Win.C1Input.C1Button
    Friend WithEvents BTNPrint As C1.Win.C1Input.C1Button
    Friend WithEvents KitchenList As C1.Win.C1List.C1Combo
    Friend WithEvents BTNDump As C1.Win.C1Input.C1Button
    Friend WithEvents BTNUndo As C1.Win.C1Input.C1Button
    Friend WithEvents BTNViewNotes As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveDown As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveUp As C1.Win.C1Input.C1Button
    Friend WithEvents TimerRefresh As System.Windows.Forms.Timer
    Friend WithEvents BTNRefresh As C1.Win.C1Input.C1Button
    Friend WithEvents DataUID As C1.Win.C1FlexGrid.C1FlexGrid
End Class
