<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Daftar_Customer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Daftar_Customer))
        Me.InputBox = New System.Windows.Forms.GroupBox
        Me.ListDetail = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmdEdit = New C1.Win.C1Input.C1Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.BTNNew = New C1.Win.C1Input.C1Button
        Me.cmdClose = New C1.Win.C1Input.C1Button
        Me.txtCari = New System.Windows.Forms.TextBox
        Me.DataUID = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.KitchenList = New C1.Win.C1List.C1Combo
        Me.BTNClose = New C1.Win.C1Input.C1Button
        Me.BTNPrint = New C1.Win.C1Input.C1Button
        Me.TimerRefresh = New System.Windows.Forms.Timer(Me.components)
        Me.InputBox.SuspendLayout()
        CType(Me.ListDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        CType(Me.DataUID, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.KitchenList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'InputBox
        '
        Me.InputBox.Controls.Add(Me.ListDetail)
        Me.InputBox.Controls.Add(Me.GroupBox1)
        Me.InputBox.Controls.Add(Me.DataUID)
        Me.InputBox.Location = New System.Drawing.Point(12, 6)
        Me.InputBox.Name = "InputBox"
        Me.InputBox.Size = New System.Drawing.Size(993, 649)
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
        Me.ListDetail.Location = New System.Drawing.Point(13, 83)
        Me.ListDetail.Name = "ListDetail"
        Me.ListDetail.Rows.Count = 1
        Me.ListDetail.Rows.DefaultSize = 19
        Me.ListDetail.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.ListDetail.Size = New System.Drawing.Size(965, 551)
        Me.ListDetail.StyleInfo = resources.GetString("ListDetail.StyleInfo")
        Me.ListDetail.TabIndex = 116
        Me.ListDetail.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmdEdit)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.BTNNew)
        Me.GroupBox1.Controls.Add(Me.cmdClose)
        Me.GroupBox1.Controls.Add(Me.txtCari)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 11)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(961, 59)
        Me.GroupBox1.TabIndex = 115
        Me.GroupBox1.TabStop = False
        '
        'cmdEdit
        '
        Me.cmdEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEdit.Image = CType(resources.GetObject("cmdEdit.Image"), System.Drawing.Image)
        Me.cmdEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdEdit.Location = New System.Drawing.Point(556, 12)
        Me.cmdEdit.Name = "cmdEdit"
        Me.cmdEdit.Size = New System.Drawing.Size(113, 41)
        Me.cmdEdit.TabIndex = 145
        Me.cmdEdit.Text = "Edit"
        Me.cmdEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdEdit.UseVisualStyleBackColor = True
        Me.cmdEdit.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(23, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(84, 16)
        Me.Label1.TabIndex = 144
        Me.Label1.Text = "Search Here"
        '
        'BTNNew
        '
        Me.BTNNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNNew.Image = CType(resources.GetObject("BTNNew.Image"), System.Drawing.Image)
        Me.BTNNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNNew.Location = New System.Drawing.Point(675, 12)
        Me.BTNNew.Name = "BTNNew"
        Me.BTNNew.Size = New System.Drawing.Size(150, 41)
        Me.BTNNew.TabIndex = 143
        Me.BTNNew.Text = "Create New Customer"
        Me.BTNNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNNew.UseVisualStyleBackColor = True
        Me.BTNNew.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'cmdClose
        '
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdClose.Location = New System.Drawing.Point(831, 11)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(123, 42)
        Me.cmdClose.TabIndex = 142
        Me.cmdClose.Text = "Close"
        Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdClose.UseVisualStyleBackColor = True
        Me.cmdClose.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'txtCari
        '
        Me.txtCari.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtCari.Location = New System.Drawing.Point(113, 22)
        Me.txtCari.Name = "txtCari"
        Me.txtCari.Size = New System.Drawing.Size(280, 31)
        Me.txtCari.TabIndex = 0
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
        Me.DataUID.Location = New System.Drawing.Point(550, 517)
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
        'Form_Daftar_Customer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1018, 668)
        Me.ControlBox = False
        Me.Controls.Add(Me.InputBox)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Daftar_Customer"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Customers List"
        Me.InputBox.ResumeLayout(False)
        CType(Me.ListDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.DataUID, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.KitchenList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents InputBox As System.Windows.Forms.GroupBox
    Friend WithEvents BTNClose As C1.Win.C1Input.C1Button
    Friend WithEvents BTNPrint As C1.Win.C1Input.C1Button
    Friend WithEvents KitchenList As C1.Win.C1List.C1Combo
    Friend WithEvents TimerRefresh As System.Windows.Forms.Timer
    Friend WithEvents DataUID As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents txtCari As System.Windows.Forms.TextBox
    Friend WithEvents BTNNew As C1.Win.C1Input.C1Button
    Friend WithEvents cmdClose As C1.Win.C1Input.C1Button
    Friend WithEvents ListDetail As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdEdit As C1.Win.C1Input.C1Button
End Class
