<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Customer_Pick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Customer_Pick))
        Me.TableList = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BTNMoveDown = New C1.Win.C1Input.C1Button
        Me.BTNMoveUp = New C1.Win.C1Input.C1Button
        Me.BTNOK = New C1.Win.C1Input.C1Button
        Me.BTNCancel = New C1.Win.C1Input.C1Button
        Me.VirtualKey1 = New C1.Win.C1Input.C1Button
        Me.FindName = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
        Me.BTNSearch = New C1.Win.C1Input.C1Button
        Me.FindNo = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.VirtualKey2 = New C1.Win.C1Input.C1Button
        Me.Panel1 = New System.Windows.Forms.Panel
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
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
        Me.TableList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableList.Location = New System.Drawing.Point(5, 55)
        Me.TableList.Name = "TableList"
        Me.TableList.Rows.Count = 1
        Me.TableList.Rows.DefaultSize = 18
        Me.TableList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.TableList.Size = New System.Drawing.Size(676, 530)
        Me.TableList.StyleInfo = resources.GetString("TableList.StyleInfo")
        Me.TableList.TabIndex = 5
        Me.TableList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTNMoveDown)
        Me.GroupBox2.Controls.Add(Me.BTNMoveUp)
        Me.GroupBox2.Controls.Add(Me.BTNOK)
        Me.GroupBox2.Controls.Add(Me.BTNCancel)
        Me.GroupBox2.Location = New System.Drawing.Point(5, 590)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(676, 69)
        Me.GroupBox2.TabIndex = 17
        Me.GroupBox2.TabStop = False
        '
        'BTNMoveDown
        '
        Me.BTNMoveDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveDown.Image = CType(resources.GetObject("BTNMoveDown.Image"), System.Drawing.Image)
        Me.BTNMoveDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveDown.Location = New System.Drawing.Point(118, 17)
        Me.BTNMoveDown.Name = "BTNMoveDown"
        Me.BTNMoveDown.Size = New System.Drawing.Size(100, 41)
        Me.BTNMoveDown.TabIndex = 5
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
        Me.BTNMoveUp.Location = New System.Drawing.Point(11, 17)
        Me.BTNMoveUp.Name = "BTNMoveUp"
        Me.BTNMoveUp.Size = New System.Drawing.Size(100, 41)
        Me.BTNMoveUp.TabIndex = 4
        Me.BTNMoveUp.Text = "Up"
        Me.BTNMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNMoveUp.UseVisualStyleBackColor = True
        Me.BTNMoveUp.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNOK
        '
        Me.BTNOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNOK.Image = CType(resources.GetObject("BTNOK.Image"), System.Drawing.Image)
        Me.BTNOK.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNOK.Location = New System.Drawing.Point(369, 17)
        Me.BTNOK.Name = "BTNOK"
        Me.BTNOK.Size = New System.Drawing.Size(145, 41)
        Me.BTNOK.TabIndex = 0
        Me.BTNOK.Text = "OK"
        Me.BTNOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNOK.UseVisualStyleBackColor = True
        Me.BTNOK.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNCancel
        '
        Me.BTNCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCancel.Image = CType(resources.GetObject("BTNCancel.Image"), System.Drawing.Image)
        Me.BTNCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNCancel.Location = New System.Drawing.Point(521, 17)
        Me.BTNCancel.Name = "BTNCancel"
        Me.BTNCancel.Size = New System.Drawing.Size(145, 41)
        Me.BTNCancel.TabIndex = 1
        Me.BTNCancel.Text = "Cancel"
        Me.BTNCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNCancel.UseVisualStyleBackColor = True
        Me.BTNCancel.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'VirtualKey1
        '
        Me.VirtualKey1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualKey1.Image = CType(resources.GetObject("VirtualKey1.Image"), System.Drawing.Image)
        Me.VirtualKey1.Location = New System.Drawing.Point(495, 10)
        Me.VirtualKey1.Name = "VirtualKey1"
        Me.VirtualKey1.Size = New System.Drawing.Size(50, 32)
        Me.VirtualKey1.TabIndex = 3
        Me.VirtualKey1.UseVisualStyleBackColor = True
        Me.VirtualKey1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'FindName
        '
        Me.FindName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FindName.Location = New System.Drawing.Point(351, 13)
        Me.FindName.Name = "FindName"
        Me.FindName.Size = New System.Drawing.Size(139, 26)
        Me.FindName.TabIndex = 2
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(3, 19)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(51, 13)
        Me.Label11.TabIndex = 95
        Me.Label11.Text = "Cust. No."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTNSearch
        '
        Me.BTNSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSearch.Image = CType(resources.GetObject("BTNSearch.Image"), System.Drawing.Image)
        Me.BTNSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNSearch.Location = New System.Drawing.Point(592, 5)
        Me.BTNSearch.Name = "BTNSearch"
        Me.BTNSearch.Size = New System.Drawing.Size(84, 41)
        Me.BTNSearch.TabIndex = 4
        Me.BTNSearch.Text = "Find"
        Me.BTNSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNSearch.UseVisualStyleBackColor = True
        Me.BTNSearch.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'FindNo
        '
        Me.FindNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FindNo.Location = New System.Drawing.Point(55, 13)
        Me.FindNo.Name = "FindNo"
        Me.FindNo.Size = New System.Drawing.Size(139, 26)
        Me.FindNo.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(285, 19)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 98
        Me.Label1.Text = "Cust. Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VirtualKey2
        '
        Me.VirtualKey2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualKey2.Image = CType(resources.GetObject("VirtualKey2.Image"), System.Drawing.Image)
        Me.VirtualKey2.Location = New System.Drawing.Point(198, 11)
        Me.VirtualKey2.Name = "VirtualKey2"
        Me.VirtualKey2.Size = New System.Drawing.Size(50, 32)
        Me.VirtualKey2.TabIndex = 1
        Me.VirtualKey2.UseVisualStyleBackColor = True
        Me.VirtualKey2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Panel1
        '
        Me.Panel1.Controls.Add(Me.VirtualKey2)
        Me.Panel1.Controls.Add(Me.Label1)
        Me.Panel1.Controls.Add(Me.FindNo)
        Me.Panel1.Controls.Add(Me.BTNSearch)
        Me.Panel1.Controls.Add(Me.VirtualKey1)
        Me.Panel1.Controls.Add(Me.FindName)
        Me.Panel1.Controls.Add(Me.Label11)
        Me.Panel1.Location = New System.Drawing.Point(3, 2)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(679, 48)
        Me.Panel1.TabIndex = 99
        '
        'Form_Customer_Pick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(686, 670)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.TableList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Customer_Pick"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Customer List"
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNOK As C1.Win.C1Input.C1Button
    Friend WithEvents BTNCancel As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualKey1 As C1.Win.C1Input.C1Button
    Friend WithEvents FindName As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents BTNSearch As C1.Win.C1Input.C1Button
    Friend WithEvents FindNo As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents VirtualKey2 As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveDown As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveUp As C1.Win.C1Input.C1Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
