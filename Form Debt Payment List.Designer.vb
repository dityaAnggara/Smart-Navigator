<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Debt_Payment_List
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Debt_Payment_List))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BTNMoveDown = New C1.Win.C1Input.C1Button
        Me.BTNMoveUp = New C1.Win.C1Input.C1Button
        Me.TableList = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BTNOK = New C1.Win.C1Input.C1Button
        Me.BTNNew = New C1.Win.C1Input.C1Button
        Me.BTNVoid = New C1.Win.C1Input.C1Button
        Me.BTNEdit = New C1.Win.C1Input.C1Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTNMoveDown)
        Me.GroupBox1.Controls.Add(Me.BTNMoveUp)
        Me.GroupBox1.Controls.Add(Me.TableList)
        Me.GroupBox1.Location = New System.Drawing.Point(10, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(666, 582)
        Me.GroupBox1.TabIndex = 22
        Me.GroupBox1.TabStop = False
        '
        'BTNMoveDown
        '
        Me.BTNMoveDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveDown.Image = CType(resources.GetObject("BTNMoveDown.Image"), System.Drawing.Image)
        Me.BTNMoveDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveDown.Location = New System.Drawing.Point(339, 528)
        Me.BTNMoveDown.Name = "BTNMoveDown"
        Me.BTNMoveDown.Size = New System.Drawing.Size(145, 41)
        Me.BTNMoveDown.TabIndex = 6
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
        Me.BTNMoveUp.Location = New System.Drawing.Point(188, 528)
        Me.BTNMoveUp.Name = "BTNMoveUp"
        Me.BTNMoveUp.Size = New System.Drawing.Size(145, 41)
        Me.BTNMoveUp.TabIndex = 5
        Me.BTNMoveUp.Text = "Up"
        Me.BTNMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNMoveUp.UseVisualStyleBackColor = True
        Me.BTNMoveUp.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'TableList
        '
        Me.TableList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.TableList.AllowEditing = False
        Me.TableList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.TableList.ColumnInfo = resources.GetString("TableList.ColumnInfo")
        Me.TableList.ExtendLastCol = True
        Me.TableList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.TableList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableList.Location = New System.Drawing.Point(13, 17)
        Me.TableList.Name = "TableList"
        Me.TableList.Rows.Count = 1
        Me.TableList.Rows.DefaultSize = 18
        Me.TableList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.TableList.Size = New System.Drawing.Size(644, 499)
        Me.TableList.StyleInfo = resources.GetString("TableList.StyleInfo")
        Me.TableList.TabIndex = 6
        Me.TableList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTNOK)
        Me.GroupBox2.Controls.Add(Me.BTNNew)
        Me.GroupBox2.Controls.Add(Me.BTNVoid)
        Me.GroupBox2.Controls.Add(Me.BTNEdit)
        Me.GroupBox2.Location = New System.Drawing.Point(10, 593)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(666, 69)
        Me.GroupBox2.TabIndex = 21
        Me.GroupBox2.TabStop = False
        '
        'BTNOK
        '
        Me.BTNOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNOK.Image = CType(resources.GetObject("BTNOK.Image"), System.Drawing.Image)
        Me.BTNOK.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNOK.Location = New System.Drawing.Point(512, 17)
        Me.BTNOK.Name = "BTNOK"
        Me.BTNOK.Size = New System.Drawing.Size(145, 41)
        Me.BTNOK.TabIndex = 4
        Me.BTNOK.Text = "Close"
        Me.BTNOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNOK.UseVisualStyleBackColor = True
        Me.BTNOK.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNNew
        '
        Me.BTNNew.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNNew.Image = CType(resources.GetObject("BTNNew.Image"), System.Drawing.Image)
        Me.BTNNew.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNNew.Location = New System.Drawing.Point(14, 17)
        Me.BTNNew.Name = "BTNNew"
        Me.BTNNew.Size = New System.Drawing.Size(145, 41)
        Me.BTNNew.TabIndex = 1
        Me.BTNNew.Text = "New"
        Me.BTNNew.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNNew.UseVisualStyleBackColor = True
        Me.BTNNew.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNVoid
        '
        Me.BTNVoid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNVoid.Image = CType(resources.GetObject("BTNVoid.Image"), System.Drawing.Image)
        Me.BTNVoid.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNVoid.Location = New System.Drawing.Point(316, 17)
        Me.BTNVoid.Name = "BTNVoid"
        Me.BTNVoid.Size = New System.Drawing.Size(145, 41)
        Me.BTNVoid.TabIndex = 3
        Me.BTNVoid.Text = "Void"
        Me.BTNVoid.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNVoid.UseVisualStyleBackColor = True
        Me.BTNVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNEdit
        '
        Me.BTNEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNEdit.Image = CType(resources.GetObject("BTNEdit.Image"), System.Drawing.Image)
        Me.BTNEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNEdit.Location = New System.Drawing.Point(165, 17)
        Me.BTNEdit.Name = "BTNEdit"
        Me.BTNEdit.Size = New System.Drawing.Size(145, 41)
        Me.BTNEdit.TabIndex = 2
        Me.BTNEdit.Text = "Edit"
        Me.BTNEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNEdit.UseVisualStyleBackColor = True
        Me.BTNEdit.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Form_Debt_Payment_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(686, 670)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Debt_Payment_List"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Payment Rest List"
        Me.GroupBox1.ResumeLayout(False)
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BTNOK As C1.Win.C1Input.C1Button
    Friend WithEvents BTNNew As C1.Win.C1Input.C1Button
    Friend WithEvents BTNVoid As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNMoveDown As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveUp As C1.Win.C1Input.C1Button
    Friend WithEvents TableList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents BTNEdit As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
End Class
