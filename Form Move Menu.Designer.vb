<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Move_Menu
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Move_Menu))
        Me.BTNClose = New C1.Win.C1Input.C1Button
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.BTNMoveDown3 = New C1.Win.C1Input.C1Button
        Me.BTNMoveUp3 = New C1.Win.C1Input.C1Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.TableList = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.TableNameTxt = New System.Windows.Forms.Label
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label8 = New System.Windows.Forms.Label
        Me.BTNSave = New C1.Win.C1Input.C1Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BTNMoveDown = New C1.Win.C1Input.C1Button
        Me.BTNMoveUp = New C1.Win.C1Input.C1Button
        Me.CurrentList = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.BTNMoveDown2 = New C1.Win.C1Input.C1Button
        Me.BTNMoveUp2 = New C1.Win.C1Input.C1Button
        Me.MoveList = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.Label3 = New System.Windows.Forms.Label
        Me.BTNMove = New C1.Win.C1Input.C1Button
        Me.BTNCancel = New C1.Win.C1Input.C1Button
        Me.GroupBox5.SuspendLayout()
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.CurrentList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox3.SuspendLayout()
        CType(Me.MoveList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BTNClose
        '
        Me.BTNClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNClose.Image = CType(resources.GetObject("BTNClose.Image"), System.Drawing.Image)
        Me.BTNClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNClose.Location = New System.Drawing.Point(896, 647)
        Me.BTNClose.Name = "BTNClose"
        Me.BTNClose.Size = New System.Drawing.Size(114, 41)
        Me.BTNClose.TabIndex = 6
        Me.BTNClose.Text = "Close"
        Me.BTNClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNClose.UseVisualStyleBackColor = True
        Me.BTNClose.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.BTNMoveDown3)
        Me.GroupBox5.Controls.Add(Me.BTNMoveUp3)
        Me.GroupBox5.Controls.Add(Me.Label1)
        Me.GroupBox5.Controls.Add(Me.TableList)
        Me.GroupBox5.Location = New System.Drawing.Point(774, 2)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(236, 632)
        Me.GroupBox5.TabIndex = 4
        Me.GroupBox5.TabStop = False
        '
        'BTNMoveDown3
        '
        Me.BTNMoveDown3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveDown3.Image = CType(resources.GetObject("BTNMoveDown3.Image"), System.Drawing.Image)
        Me.BTNMoveDown3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveDown3.Location = New System.Drawing.Point(122, 581)
        Me.BTNMoveDown3.Name = "BTNMoveDown3"
        Me.BTNMoveDown3.Size = New System.Drawing.Size(95, 41)
        Me.BTNMoveDown3.TabIndex = 99
        Me.BTNMoveDown3.Text = "Down"
        Me.BTNMoveDown3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNMoveDown3.UseVisualStyleBackColor = True
        Me.BTNMoveDown3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNMoveUp3
        '
        Me.BTNMoveUp3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveUp3.Image = CType(resources.GetObject("BTNMoveUp3.Image"), System.Drawing.Image)
        Me.BTNMoveUp3.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveUp3.Location = New System.Drawing.Point(21, 581)
        Me.BTNMoveUp3.Name = "BTNMoveUp3"
        Me.BTNMoveUp3.Size = New System.Drawing.Size(95, 41)
        Me.BTNMoveUp3.TabIndex = 98
        Me.BTNMoveUp3.Text = "Up"
        Me.BTNMoveUp3.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNMoveUp3.UseVisualStyleBackColor = True
        Me.BTNMoveUp3.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(90, 13)
        Me.Label1.TabIndex = 97
        Me.Label1.Text = "Destination Table"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TableList
        '
        Me.TableList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.TableList.AllowEditing = False
        Me.TableList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.TableList.ColumnInfo = resources.GetString("TableList.ColumnInfo")
        Me.TableList.ExtendLastCol = True
        Me.TableList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.TableList.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableList.Location = New System.Drawing.Point(8, 35)
        Me.TableList.Name = "TableList"
        Me.TableList.Rows.Count = 0
        Me.TableList.Rows.DefaultSize = 26
        Me.TableList.Rows.Fixed = 0
        Me.TableList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.TableList.Size = New System.Drawing.Size(220, 538)
        Me.TableList.StyleInfo = resources.GetString("TableList.StyleInfo")
        Me.TableList.TabIndex = 0
        Me.TableList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'TableNameTxt
        '
        Me.TableNameTxt.AutoSize = True
        Me.TableNameTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableNameTxt.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.TableNameTxt.Location = New System.Drawing.Point(88, 19)
        Me.TableNameTxt.Name = "TableNameTxt"
        Me.TableNameTxt.Size = New System.Drawing.Size(84, 16)
        Me.TableNameTxt.TabIndex = 97
        Me.TableNameTxt.Text = "MEJA V.I.P"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.TableNameTxt)
        Me.GroupBox1.Controls.Add(Me.Label8)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 2)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(760, 48)
        Me.GroupBox1.TabIndex = 10
        Me.GroupBox1.TabStop = False
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(8, 20)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(71, 13)
        Me.Label8.TabIndex = 96
        Me.Label8.Text = "Current Table"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTNSave
        '
        Me.BTNSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSave.Image = CType(resources.GetObject("BTNSave.Image"), System.Drawing.Image)
        Me.BTNSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNSave.Location = New System.Drawing.Point(775, 647)
        Me.BTNSave.Name = "BTNSave"
        Me.BTNSave.Size = New System.Drawing.Size(115, 41)
        Me.BTNSave.TabIndex = 5
        Me.BTNSave.Text = "Save"
        Me.BTNSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNSave.UseVisualStyleBackColor = True
        Me.BTNSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTNMoveDown)
        Me.GroupBox2.Controls.Add(Me.BTNMoveUp)
        Me.GroupBox2.Controls.Add(Me.CurrentList)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Location = New System.Drawing.Point(8, 50)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(349, 584)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'BTNMoveDown
        '
        Me.BTNMoveDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveDown.Image = CType(resources.GetObject("BTNMoveDown.Image"), System.Drawing.Image)
        Me.BTNMoveDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveDown.Location = New System.Drawing.Point(178, 533)
        Me.BTNMoveDown.Name = "BTNMoveDown"
        Me.BTNMoveDown.Size = New System.Drawing.Size(95, 41)
        Me.BTNMoveDown.TabIndex = 83
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
        Me.BTNMoveUp.Location = New System.Drawing.Point(77, 533)
        Me.BTNMoveUp.Name = "BTNMoveUp"
        Me.BTNMoveUp.Size = New System.Drawing.Size(95, 41)
        Me.BTNMoveUp.TabIndex = 82
        Me.BTNMoveUp.Text = "Up"
        Me.BTNMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNMoveUp.UseVisualStyleBackColor = True
        Me.BTNMoveUp.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'CurrentList
        '
        Me.CurrentList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.CurrentList.AllowEditing = False
        Me.CurrentList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.CurrentList.ColumnInfo = resources.GetString("CurrentList.ColumnInfo")
        Me.CurrentList.ExtendLastCol = True
        Me.CurrentList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.CurrentList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentList.Location = New System.Drawing.Point(7, 36)
        Me.CurrentList.Name = "CurrentList"
        Me.CurrentList.Rows.Count = 1
        Me.CurrentList.Rows.DefaultSize = 19
        Me.CurrentList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.CurrentList.Size = New System.Drawing.Size(336, 489)
        Me.CurrentList.StyleInfo = resources.GetString("CurrentList.StyleInfo")
        Me.CurrentList.TabIndex = 0
        Me.CurrentList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(8, 20)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(83, 13)
        Me.Label2.TabIndex = 97
        Me.Label2.Text = "All Current Items"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.BTNMoveDown2)
        Me.GroupBox3.Controls.Add(Me.BTNMoveUp2)
        Me.GroupBox3.Controls.Add(Me.MoveList)
        Me.GroupBox3.Controls.Add(Me.Label3)
        Me.GroupBox3.Location = New System.Drawing.Point(420, 50)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(348, 584)
        Me.GroupBox3.TabIndex = 3
        Me.GroupBox3.TabStop = False
        '
        'BTNMoveDown2
        '
        Me.BTNMoveDown2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveDown2.Image = CType(resources.GetObject("BTNMoveDown2.Image"), System.Drawing.Image)
        Me.BTNMoveDown2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveDown2.Location = New System.Drawing.Point(178, 533)
        Me.BTNMoveDown2.Name = "BTNMoveDown2"
        Me.BTNMoveDown2.Size = New System.Drawing.Size(95, 41)
        Me.BTNMoveDown2.TabIndex = 85
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
        Me.BTNMoveUp2.Location = New System.Drawing.Point(77, 533)
        Me.BTNMoveUp2.Name = "BTNMoveUp2"
        Me.BTNMoveUp2.Size = New System.Drawing.Size(95, 41)
        Me.BTNMoveUp2.TabIndex = 84
        Me.BTNMoveUp2.Text = "Up"
        Me.BTNMoveUp2.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNMoveUp2.UseVisualStyleBackColor = True
        Me.BTNMoveUp2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'MoveList
        '
        Me.MoveList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.MoveList.AllowEditing = False
        Me.MoveList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.MoveList.ColumnInfo = resources.GetString("MoveList.ColumnInfo")
        Me.MoveList.ExtendLastCol = True
        Me.MoveList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.MoveList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MoveList.Location = New System.Drawing.Point(8, 36)
        Me.MoveList.Name = "MoveList"
        Me.MoveList.Rows.Count = 1
        Me.MoveList.Rows.DefaultSize = 19
        Me.MoveList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.MoveList.Size = New System.Drawing.Size(334, 489)
        Me.MoveList.StyleInfo = resources.GetString("MoveList.StyleInfo")
        Me.MoveList.TabIndex = 0
        Me.MoveList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(8, 20)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(73, 13)
        Me.Label3.TabIndex = 98
        Me.Label3.Text = "Item To Move"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTNMove
        '
        Me.BTNMove.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMove.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMove.Location = New System.Drawing.Point(363, 278)
        Me.BTNMove.Name = "BTNMove"
        Me.BTNMove.Size = New System.Drawing.Size(51, 53)
        Me.BTNMove.TabIndex = 1
        Me.BTNMove.Text = ">>"
        Me.BTNMove.UseVisualStyleBackColor = True
        Me.BTNMove.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNCancel
        '
        Me.BTNCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNCancel.Location = New System.Drawing.Point(363, 337)
        Me.BTNCancel.Name = "BTNCancel"
        Me.BTNCancel.Size = New System.Drawing.Size(51, 53)
        Me.BTNCancel.TabIndex = 2
        Me.BTNCancel.Text = "<<"
        Me.BTNCancel.UseVisualStyleBackColor = True
        Me.BTNCancel.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Form_Move_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.ControlBox = False
        Me.Controls.Add(Me.BTNCancel)
        Me.Controls.Add(Me.BTNMove)
        Me.Controls.Add(Me.GroupBox3)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.BTNClose)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.BTNSave)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Move_Menu"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Move Menu"
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.CurrentList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        CType(Me.MoveList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BTNClose As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TableList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents TableNameTxt As System.Windows.Forms.Label
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents BTNSave As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents CurrentList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents MoveList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents BTNMove As C1.Win.C1Input.C1Button
    Friend WithEvents BTNCancel As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveDown As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveUp As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveDown3 As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveUp3 As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveDown2 As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveUp2 As C1.Win.C1Input.C1Button
End Class
