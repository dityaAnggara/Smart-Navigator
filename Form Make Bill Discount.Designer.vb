<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Make_Bill_Discount
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Make_Bill_Discount))
    Me.GroupBox = New System.Windows.Forms.GroupBox
    Me.cmdSelectAllDiscount = New C1.Win.C1Input.C1Button
    Me.BTNMoveDown1 = New C1.Win.C1Input.C1Button
    Me.BTNMoveUp1 = New C1.Win.C1Input.C1Button
    Me.LabelAllDiscount = New System.Windows.Forms.Label
    Me.AllDiscount = New C1.Win.C1Input.C1Label
    Me.DiscountList = New C1.Win.C1FlexGrid.C1FlexGrid
    Me.GroupBox1 = New System.Windows.Forms.GroupBox
    Me.cmdSelectAllItem = New C1.Win.C1Input.C1Button
    Me.BTNMoveDown = New C1.Win.C1Input.C1Button
    Me.BTNMoveUp = New C1.Win.C1Input.C1Button
    Me.AllItem = New C1.Win.C1Input.C1Label
    Me.LabelSelectAll = New System.Windows.Forms.Label
    Me.ItemList = New C1.Win.C1FlexGrid.C1FlexGrid
    Me.GroupBox2 = New System.Windows.Forms.GroupBox
    Me.BTNClear = New C1.Win.C1Input.C1Button
    Me.BTNCancel = New C1.Win.C1Input.C1Button
    Me.BTNApply = New C1.Win.C1Input.C1Button
    Me.BTNSave = New C1.Win.C1Input.C1Button
    Me.GroupBox.SuspendLayout()
    CType(Me.AllDiscount, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.DiscountList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox1.SuspendLayout()
    CType(Me.AllItem, System.ComponentModel.ISupportInitialize).BeginInit()
    CType(Me.ItemList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.SuspendLayout()
    '
    'GroupBox
    '
    Me.GroupBox.Controls.Add(Me.cmdSelectAllDiscount)
    Me.GroupBox.Controls.Add(Me.BTNMoveDown1)
    Me.GroupBox.Controls.Add(Me.BTNMoveUp1)
    Me.GroupBox.Controls.Add(Me.LabelAllDiscount)
    Me.GroupBox.Controls.Add(Me.AllDiscount)
    Me.GroupBox.Controls.Add(Me.DiscountList)
    Me.GroupBox.Location = New System.Drawing.Point(8, 2)
    Me.GroupBox.Name = "GroupBox"
    Me.GroupBox.Size = New System.Drawing.Size(262, 682)
    Me.GroupBox.TabIndex = 1
    Me.GroupBox.TabStop = False
    '
    'cmdSelectAllDiscount
    '
    Me.cmdSelectAllDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cmdSelectAllDiscount.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.cmdSelectAllDiscount.Location = New System.Drawing.Point(8, 633)
    Me.cmdSelectAllDiscount.Name = "cmdSelectAllDiscount"
    Me.cmdSelectAllDiscount.Size = New System.Drawing.Size(244, 40)
    Me.cmdSelectAllDiscount.TabIndex = 13
    Me.cmdSelectAllDiscount.Text = "Select All Discount"
    Me.cmdSelectAllDiscount.UseVisualStyleBackColor = True
    Me.cmdSelectAllDiscount.Visible = False
    Me.cmdSelectAllDiscount.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'BTNMoveDown1
    '
    Me.BTNMoveDown1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BTNMoveDown1.Image = CType(resources.GetObject("BTNMoveDown1.Image"), System.Drawing.Image)
    Me.BTNMoveDown1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BTNMoveDown1.Location = New System.Drawing.Point(167, 630)
    Me.BTNMoveDown1.Name = "BTNMoveDown1"
    Me.BTNMoveDown1.Size = New System.Drawing.Size(85, 43)
    Me.BTNMoveDown1.TabIndex = 12
    Me.BTNMoveDown1.Text = "Down"
    Me.BTNMoveDown1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BTNMoveDown1.UseVisualStyleBackColor = True
    Me.BTNMoveDown1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'BTNMoveUp1
    '
    Me.BTNMoveUp1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BTNMoveUp1.Image = CType(resources.GetObject("BTNMoveUp1.Image"), System.Drawing.Image)
    Me.BTNMoveUp1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BTNMoveUp1.Location = New System.Drawing.Point(76, 630)
    Me.BTNMoveUp1.Name = "BTNMoveUp1"
    Me.BTNMoveUp1.Size = New System.Drawing.Size(85, 43)
    Me.BTNMoveUp1.TabIndex = 11
    Me.BTNMoveUp1.Text = "Up"
    Me.BTNMoveUp1.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BTNMoveUp1.UseVisualStyleBackColor = True
    Me.BTNMoveUp1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'LabelAllDiscount
    '
    Me.LabelAllDiscount.AutoSize = True
    Me.LabelAllDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabelAllDiscount.Location = New System.Drawing.Point(41, 644)
    Me.LabelAllDiscount.Name = "LabelAllDiscount"
    Me.LabelAllDiscount.Size = New System.Drawing.Size(33, 18)
    Me.LabelAllDiscount.TabIndex = 9
    Me.LabelAllDiscount.Text = "ALL"
    '
    'AllDiscount
    '
    Me.AllDiscount.Image = Global.PrimeRESTO.My.Resources.Resources._NOTHING
    Me.AllDiscount.Location = New System.Drawing.Point(8, 636)
    Me.AllDiscount.Name = "AllDiscount"
    Me.AllDiscount.Size = New System.Drawing.Size(31, 32)
    Me.AllDiscount.TabIndex = 9
    Me.AllDiscount.Tag = Nothing
    Me.AllDiscount.Value = ""
    '
    'DiscountList
    '
    Me.DiscountList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
    Me.DiscountList.AllowEditing = False
    Me.DiscountList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
    Me.DiscountList.ColumnInfo = resources.GetString("DiscountList.ColumnInfo")
    Me.DiscountList.ExtendLastCol = True
    Me.DiscountList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DiscountList.Location = New System.Drawing.Point(8, 14)
    Me.DiscountList.Name = "DiscountList"
    Me.DiscountList.Rows.Count = 1
    Me.DiscountList.Rows.DefaultSize = 18
    Me.DiscountList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
    Me.DiscountList.Size = New System.Drawing.Size(245, 607)
    Me.DiscountList.StyleInfo = resources.GetString("DiscountList.StyleInfo")
    Me.DiscountList.TabIndex = 3
    Me.DiscountList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
    '
    'GroupBox1
    '
    Me.GroupBox1.Controls.Add(Me.cmdSelectAllItem)
    Me.GroupBox1.Controls.Add(Me.BTNMoveDown)
    Me.GroupBox1.Controls.Add(Me.BTNMoveUp)
    Me.GroupBox1.Controls.Add(Me.AllItem)
    Me.GroupBox1.Controls.Add(Me.LabelSelectAll)
    Me.GroupBox1.Controls.Add(Me.ItemList)
    Me.GroupBox1.Location = New System.Drawing.Point(276, 2)
    Me.GroupBox1.Name = "GroupBox1"
    Me.GroupBox1.Size = New System.Drawing.Size(730, 620)
    Me.GroupBox1.TabIndex = 2
    Me.GroupBox1.TabStop = False
    '
    'cmdSelectAllItem
    '
    Me.cmdSelectAllItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.cmdSelectAllItem.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.cmdSelectAllItem.Location = New System.Drawing.Point(237, 574)
    Me.cmdSelectAllItem.Name = "cmdSelectAllItem"
    Me.cmdSelectAllItem.Size = New System.Drawing.Size(263, 40)
    Me.cmdSelectAllItem.TabIndex = 11
    Me.cmdSelectAllItem.Text = "Select All Item"
    Me.cmdSelectAllItem.UseVisualStyleBackColor = True
    Me.cmdSelectAllItem.Visible = False
    Me.cmdSelectAllItem.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'BTNMoveDown
    '
    Me.BTNMoveDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BTNMoveDown.Image = CType(resources.GetObject("BTNMoveDown.Image"), System.Drawing.Image)
    Me.BTNMoveDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BTNMoveDown.Location = New System.Drawing.Point(627, 569)
    Me.BTNMoveDown.Name = "BTNMoveDown"
    Me.BTNMoveDown.Size = New System.Drawing.Size(91, 43)
    Me.BTNMoveDown.TabIndex = 10
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
    Me.BTNMoveUp.Location = New System.Drawing.Point(530, 569)
    Me.BTNMoveUp.Name = "BTNMoveUp"
    Me.BTNMoveUp.Size = New System.Drawing.Size(91, 43)
    Me.BTNMoveUp.TabIndex = 9
    Me.BTNMoveUp.Text = "Up"
    Me.BTNMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BTNMoveUp.UseVisualStyleBackColor = True
    Me.BTNMoveUp.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'AllItem
    '
    Me.AllItem.Image = Global.PrimeRESTO.My.Resources.Resources._NOTHING
    Me.AllItem.Location = New System.Drawing.Point(12, 575)
    Me.AllItem.Name = "AllItem"
    Me.AllItem.Size = New System.Drawing.Size(31, 32)
    Me.AllItem.TabIndex = 8
    Me.AllItem.Tag = Nothing
    Me.AllItem.Value = ""
    '
    'LabelSelectAll
    '
    Me.LabelSelectAll.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabelSelectAll.Location = New System.Drawing.Point(47, 581)
    Me.LabelSelectAll.Name = "LabelSelectAll"
    Me.LabelSelectAll.Size = New System.Drawing.Size(115, 23)
    Me.LabelSelectAll.TabIndex = 7
    Me.LabelSelectAll.Text = "Select All Item"
    '
    'ItemList
    '
    Me.ItemList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
    Me.ItemList.AllowEditing = False
    Me.ItemList.AllowSorting = C1.Win.C1FlexGrid.AllowSortingEnum.None
    Me.ItemList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
    Me.ItemList.ColumnInfo = resources.GetString("ItemList.ColumnInfo")
    Me.ItemList.ExtendLastCol = True
    Me.ItemList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ItemList.Location = New System.Drawing.Point(6, 15)
    Me.ItemList.Name = "ItemList"
    Me.ItemList.Rows.Count = 1
    Me.ItemList.Rows.DefaultSize = 18
    Me.ItemList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
    Me.ItemList.Size = New System.Drawing.Size(718, 546)
    Me.ItemList.StyleInfo = resources.GetString("ItemList.StyleInfo")
    Me.ItemList.TabIndex = 2
    Me.ItemList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.BTNClear)
    Me.GroupBox2.Controls.Add(Me.BTNCancel)
    Me.GroupBox2.Controls.Add(Me.BTNApply)
    Me.GroupBox2.Controls.Add(Me.BTNSave)
    Me.GroupBox2.Location = New System.Drawing.Point(276, 622)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(730, 62)
    Me.GroupBox2.TabIndex = 9
    Me.GroupBox2.TabStop = False
    '
    'BTNClear
    '
    Me.BTNClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BTNClear.Image = CType(resources.GetObject("BTNClear.Image"), System.Drawing.Image)
    Me.BTNClear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BTNClear.Location = New System.Drawing.Point(188, 14)
    Me.BTNClear.Name = "BTNClear"
    Me.BTNClear.Size = New System.Drawing.Size(170, 40)
    Me.BTNClear.TabIndex = 10
    Me.BTNClear.Text = "Clear All Discount"
    Me.BTNClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BTNClear.UseVisualStyleBackColor = True
    Me.BTNClear.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'BTNCancel
    '
    Me.BTNCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BTNCancel.Image = CType(resources.GetObject("BTNCancel.Image"), System.Drawing.Image)
    Me.BTNCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BTNCancel.Location = New System.Drawing.Point(548, 14)
    Me.BTNCancel.Name = "BTNCancel"
    Me.BTNCancel.Size = New System.Drawing.Size(170, 40)
    Me.BTNCancel.TabIndex = 8
    Me.BTNCancel.Text = "Close"
    Me.BTNCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BTNCancel.UseVisualStyleBackColor = True
    Me.BTNCancel.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'BTNApply
    '
    Me.BTNApply.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BTNApply.Image = CType(resources.GetObject("BTNApply.Image"), System.Drawing.Image)
    Me.BTNApply.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BTNApply.Location = New System.Drawing.Point(12, 14)
    Me.BTNApply.Name = "BTNApply"
    Me.BTNApply.Size = New System.Drawing.Size(170, 40)
    Me.BTNApply.TabIndex = 8
    Me.BTNApply.Text = "Apply discount"
    Me.BTNApply.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BTNApply.UseVisualStyleBackColor = True
    Me.BTNApply.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'BTNSave
    '
    Me.BTNSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BTNSave.Image = CType(resources.GetObject("BTNSave.Image"), System.Drawing.Image)
    Me.BTNSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BTNSave.Location = New System.Drawing.Point(372, 14)
    Me.BTNSave.Name = "BTNSave"
    Me.BTNSave.Size = New System.Drawing.Size(170, 40)
    Me.BTNSave.TabIndex = 7
    Me.BTNSave.Text = "Save"
    Me.BTNSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BTNSave.UseVisualStyleBackColor = True
    Me.BTNSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'Form_Make_Bill_Discount
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.AliceBlue
    Me.ClientSize = New System.Drawing.Size(1018, 692)
    Me.ControlBox = False
    Me.Controls.Add(Me.GroupBox2)
    Me.Controls.Add(Me.GroupBox1)
    Me.Controls.Add(Me.GroupBox)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
    Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Form_Make_Bill_Discount"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Discount"
    Me.GroupBox.ResumeLayout(False)
    Me.GroupBox.PerformLayout()
    CType(Me.AllDiscount, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.DiscountList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox1.ResumeLayout(False)
    CType(Me.AllItem, System.ComponentModel.ISupportInitialize).EndInit()
    CType(Me.ItemList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.ResumeLayout(False)

  End Sub
    Friend WithEvents GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents DiscountList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ItemList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTNCancel As C1.Win.C1Input.C1Button
    Friend WithEvents BTNSave As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNApply As C1.Win.C1Input.C1Button
    Friend WithEvents BTNClear As C1.Win.C1Input.C1Button
    Friend WithEvents LabelSelectAll As System.Windows.Forms.Label
    Friend WithEvents AllItem As C1.Win.C1Input.C1Label
    Friend WithEvents AllDiscount As C1.Win.C1Input.C1Label
    Friend WithEvents LabelAllDiscount As System.Windows.Forms.Label
    Friend WithEvents BTNMoveDown As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveUp As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveDown1 As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveUp1 As C1.Win.C1Input.C1Button
    Friend WithEvents cmdSelectAllItem As C1.Win.C1Input.C1Button
    Friend WithEvents cmdSelectAllDiscount As C1.Win.C1Input.C1Button
End Class
