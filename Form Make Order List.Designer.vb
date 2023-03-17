<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Make_Order_List
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Make_Order_List))
        Me.BTNDelete = New C1.Win.C1Input.C1Button
        Me.TableList = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.BTNEdit = New C1.Win.C1Input.C1Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BTNMoveDown = New C1.Win.C1Input.C1Button
        Me.BTNMoveUp = New C1.Win.C1Input.C1Button
        Me.BTNViewNotes = New C1.Win.C1Input.C1Button
        Me.BTNPrint = New C1.Win.C1Input.C1Button
        Me.BTNClose = New C1.Win.C1Input.C1Button
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTNDelete
        '
        Me.BTNDelete.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNDelete.Image = CType(resources.GetObject("BTNDelete.Image"), System.Drawing.Image)
        Me.BTNDelete.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNDelete.Location = New System.Drawing.Point(12, 17)
        Me.BTNDelete.Name = "BTNDelete"
        Me.BTNDelete.Size = New System.Drawing.Size(145, 41)
        Me.BTNDelete.TabIndex = 15
        Me.BTNDelete.Text = "Delete"
        Me.BTNDelete.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNDelete.UseVisualStyleBackColor = True
        Me.BTNDelete.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'TableList
        '
        Me.TableList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.TableList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.TableList.ColumnInfo = resources.GetString("TableList.ColumnInfo")
        Me.TableList.ExtendLastCol = True
        Me.TableList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.TableList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableList.Location = New System.Drawing.Point(5, 9)
        Me.TableList.Name = "TableList"
        Me.TableList.Rows.Count = 1
        Me.TableList.Rows.DefaultSize = 19
        Me.TableList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.TableList.Size = New System.Drawing.Size(1008, 601)
        Me.TableList.StyleInfo = resources.GetString("TableList.StyleInfo")
        Me.TableList.TabIndex = 15
        Me.TableList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'BTNEdit
        '
        Me.BTNEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNEdit.Image = CType(resources.GetObject("BTNEdit.Image"), System.Drawing.Image)
        Me.BTNEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNEdit.Location = New System.Drawing.Point(163, 17)
        Me.BTNEdit.Name = "BTNEdit"
        Me.BTNEdit.Size = New System.Drawing.Size(145, 41)
        Me.BTNEdit.TabIndex = 14
        Me.BTNEdit.Text = "Edit"
        Me.BTNEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNEdit.UseVisualStyleBackColor = True
        Me.BTNEdit.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTNMoveDown)
        Me.GroupBox2.Controls.Add(Me.BTNMoveUp)
        Me.GroupBox2.Controls.Add(Me.BTNViewNotes)
        Me.GroupBox2.Controls.Add(Me.BTNPrint)
        Me.GroupBox2.Controls.Add(Me.BTNDelete)
        Me.GroupBox2.Controls.Add(Me.BTNEdit)
        Me.GroupBox2.Controls.Add(Me.BTNClose)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 615)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1008, 69)
        Me.GroupBox2.TabIndex = 16
        Me.GroupBox2.TabStop = False
        '
        'BTNMoveDown
        '
        Me.BTNMoveDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveDown.Image = CType(resources.GetObject("BTNMoveDown.Image"), System.Drawing.Image)
        Me.BTNMoveDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveDown.Location = New System.Drawing.Point(433, 17)
        Me.BTNMoveDown.Name = "BTNMoveDown"
        Me.BTNMoveDown.Size = New System.Drawing.Size(95, 41)
        Me.BTNMoveDown.TabIndex = 81
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
        Me.BTNMoveUp.Location = New System.Drawing.Point(332, 17)
        Me.BTNMoveUp.Name = "BTNMoveUp"
        Me.BTNMoveUp.Size = New System.Drawing.Size(95, 41)
        Me.BTNMoveUp.TabIndex = 80
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
        Me.BTNViewNotes.Location = New System.Drawing.Point(550, 17)
        Me.BTNViewNotes.Name = "BTNViewNotes"
        Me.BTNViewNotes.Size = New System.Drawing.Size(145, 41)
        Me.BTNViewNotes.TabIndex = 78
        Me.BTNViewNotes.Text = "View Notes"
        Me.BTNViewNotes.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNViewNotes.UseVisualStyleBackColor = True
        Me.BTNViewNotes.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNPrint
        '
        Me.BTNPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNPrint.Image = CType(resources.GetObject("BTNPrint.Image"), System.Drawing.Image)
        Me.BTNPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNPrint.Location = New System.Drawing.Point(701, 17)
        Me.BTNPrint.Name = "BTNPrint"
        Me.BTNPrint.Size = New System.Drawing.Size(145, 41)
        Me.BTNPrint.TabIndex = 16
        Me.BTNPrint.Text = "Print"
        Me.BTNPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNPrint.UseVisualStyleBackColor = True
        Me.BTNPrint.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNClose
        '
        Me.BTNClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNClose.Image = CType(resources.GetObject("BTNClose.Image"), System.Drawing.Image)
        Me.BTNClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNClose.Location = New System.Drawing.Point(852, 17)
        Me.BTNClose.Name = "BTNClose"
        Me.BTNClose.Size = New System.Drawing.Size(145, 41)
        Me.BTNClose.TabIndex = 13
        Me.BTNClose.Text = "Close"
        Me.BTNClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNClose.UseVisualStyleBackColor = True
        Me.BTNClose.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Form_Make_Order_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1018, 697)
        Me.Controls.Add(Me.TableList)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Make_Order_List"
        Me.ShowInTaskbar = False
        Me.Text = "Make Order List"
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BTNDelete As C1.Win.C1Input.C1Button
    Friend WithEvents TableList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTNEdit As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNClose As C1.Win.C1Input.C1Button
    Friend WithEvents BTNPrint As C1.Win.C1Input.C1Button
    Friend WithEvents BTNViewNotes As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveDown As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveUp As C1.Win.C1Input.C1Button
End Class
