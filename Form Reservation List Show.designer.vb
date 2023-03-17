<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Reservation_List_Show
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Reservation_List_Show))
        Me.TableList = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BTNMoveDown = New C1.Win.C1Input.C1Button
        Me.BTNMoveUp = New C1.Win.C1Input.C1Button
        Me.BTNVoid = New C1.Win.C1Input.C1Button
        Me.BTNEdit = New C1.Win.C1Input.C1Button
        Me.BTNClose = New C1.Win.C1Input.C1Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.BTNView = New C1.Win.C1Input.C1Button
        Me.Status = New C1.Win.C1Input.C1Label
        Me.LabelStatus = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.VirtualDateToDate = New C1.Win.C1Input.C1Button
        Me.ToDateLabel = New System.Windows.Forms.Label
        Me.ToDate = New System.Windows.Forms.DateTimePicker
        Me.VirtualDateFromDate = New C1.Win.C1Input.C1Button
        Me.FromDateLabel = New System.Windows.Forms.Label
        Me.FromDate = New System.Windows.Forms.DateTimePicker
        Me.Label2 = New System.Windows.Forms.Label
        Me.tmrSize = New System.Windows.Forms.Timer(Me.components)
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.Status, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'TableList
        '
        Me.TableList.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
        Me.TableList.AllowEditing = False
        Me.TableList.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
                    Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.TableList.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.FixedSingle
        Me.TableList.ColumnInfo = resources.GetString("TableList.ColumnInfo")
        Me.TableList.ExtendLastCol = True
        Me.TableList.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
        Me.TableList.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TableList.Location = New System.Drawing.Point(5, 111)
        Me.TableList.Name = "TableList"
        Me.TableList.Rows.Count = 1
        Me.TableList.Rows.DefaultSize = 19
        Me.TableList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.TableList.Size = New System.Drawing.Size(371, 0)
        Me.TableList.StyleInfo = resources.GetString("TableList.StyleInfo")
        Me.TableList.TabIndex = 13
        Me.TableList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTNMoveDown)
        Me.GroupBox2.Controls.Add(Me.BTNMoveUp)
        Me.GroupBox2.Controls.Add(Me.BTNVoid)
        Me.GroupBox2.Controls.Add(Me.BTNEdit)
        Me.GroupBox2.Controls.Add(Me.BTNClose)
        Me.GroupBox2.Location = New System.Drawing.Point(643, 609)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1008, 69)
        Me.GroupBox2.TabIndex = 14
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Visible = False
        '
        'BTNMoveDown
        '
        Me.BTNMoveDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveDown.Image = CType(resources.GetObject("BTNMoveDown.Image"), System.Drawing.Image)
        Me.BTNMoveDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveDown.Location = New System.Drawing.Point(583, 17)
        Me.BTNMoveDown.Name = "BTNMoveDown"
        Me.BTNMoveDown.Size = New System.Drawing.Size(145, 41)
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
        Me.BTNMoveUp.Location = New System.Drawing.Point(432, 17)
        Me.BTNMoveUp.Name = "BTNMoveUp"
        Me.BTNMoveUp.Size = New System.Drawing.Size(145, 41)
        Me.BTNMoveUp.TabIndex = 82
        Me.BTNMoveUp.Text = "Up"
        Me.BTNMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNMoveUp.UseVisualStyleBackColor = True
        Me.BTNMoveUp.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNVoid
        '
        Me.BTNVoid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNVoid.Image = CType(resources.GetObject("BTNVoid.Image"), System.Drawing.Image)
        Me.BTNVoid.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNVoid.Location = New System.Drawing.Point(163, 17)
        Me.BTNVoid.Name = "BTNVoid"
        Me.BTNVoid.Size = New System.Drawing.Size(145, 41)
        Me.BTNVoid.TabIndex = 15
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
        Me.BTNEdit.Location = New System.Drawing.Point(12, 17)
        Me.BTNEdit.Name = "BTNEdit"
        Me.BTNEdit.Size = New System.Drawing.Size(145, 41)
        Me.BTNEdit.TabIndex = 14
        Me.BTNEdit.Text = "Edit"
        Me.BTNEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNEdit.UseVisualStyleBackColor = True
        Me.BTNEdit.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
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
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTNView)
        Me.GroupBox1.Controls.Add(Me.Status)
        Me.GroupBox1.Controls.Add(Me.LabelStatus)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.VirtualDateToDate)
        Me.GroupBox1.Controls.Add(Me.ToDateLabel)
        Me.GroupBox1.Controls.Add(Me.ToDate)
        Me.GroupBox1.Controls.Add(Me.VirtualDateFromDate)
        Me.GroupBox1.Controls.Add(Me.FromDateLabel)
        Me.GroupBox1.Controls.Add(Me.FromDate)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Location = New System.Drawing.Point(5, 5)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(371, 100)
        Me.GroupBox1.TabIndex = 15
        Me.GroupBox1.TabStop = False
        '
        'BTNView
        '
        Me.BTNView.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNView.Image = CType(resources.GetObject("BTNView.Image"), System.Drawing.Image)
        Me.BTNView.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNView.Location = New System.Drawing.Point(264, 12)
        Me.BTNView.Name = "BTNView"
        Me.BTNView.Size = New System.Drawing.Size(102, 69)
        Me.BTNView.TabIndex = 132
        Me.BTNView.Text = "View"
        Me.BTNView.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNView.UseVisualStyleBackColor = True
        Me.BTNView.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Status
        '
    Me.Status.Image = Global.PrimeRESTO.My.Resources.Resources._NOTHING
        Me.Status.Location = New System.Drawing.Point(651, 15)
        Me.Status.Name = "Status"
        Me.Status.Size = New System.Drawing.Size(31, 32)
        Me.Status.TabIndex = 131
        Me.Status.Tag = Nothing
        Me.Status.Value = ""
        '
        'LabelStatus
        '
        Me.LabelStatus.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelStatus.Location = New System.Drawing.Point(687, 22)
        Me.LabelStatus.Name = "LabelStatus"
        Me.LabelStatus.Size = New System.Drawing.Size(115, 23)
        Me.LabelStatus.TabIndex = 130
        Me.LabelStatus.Text = "Not Used"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(22, 60)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 129
        Me.Label4.Text = "End Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VirtualDateToDate
        '
        Me.VirtualDateToDate.Image = CType(resources.GetObject("VirtualDateToDate.Image"), System.Drawing.Image)
        Me.VirtualDateToDate.Location = New System.Drawing.Point(208, 51)
        Me.VirtualDateToDate.Name = "VirtualDateToDate"
        Me.VirtualDateToDate.Size = New System.Drawing.Size(50, 30)
        Me.VirtualDateToDate.TabIndex = 128
        Me.VirtualDateToDate.UseVisualStyleBackColor = True
        Me.VirtualDateToDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ToDateLabel
        '
        Me.ToDateLabel.AutoSize = True
        Me.ToDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToDateLabel.Location = New System.Drawing.Point(82, 62)
        Me.ToDateLabel.Name = "ToDateLabel"
        Me.ToDateLabel.Size = New System.Drawing.Size(75, 16)
        Me.ToDateLabel.TabIndex = 127
        Me.ToDateLabel.Text = "1 May 2010"
        Me.ToDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToDate
        '
        Me.ToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ToDate.Location = New System.Drawing.Point(531, 19)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(24, 22)
        Me.ToDate.TabIndex = 126
        '
        'VirtualDateFromDate
        '
        Me.VirtualDateFromDate.Image = CType(resources.GetObject("VirtualDateFromDate.Image"), System.Drawing.Image)
        Me.VirtualDateFromDate.Location = New System.Drawing.Point(208, 12)
        Me.VirtualDateFromDate.Name = "VirtualDateFromDate"
        Me.VirtualDateFromDate.Size = New System.Drawing.Size(50, 30)
        Me.VirtualDateFromDate.TabIndex = 125
        Me.VirtualDateFromDate.UseVisualStyleBackColor = True
        Me.VirtualDateFromDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'FromDateLabel
        '
        Me.FromDateLabel.AutoSize = True
        Me.FromDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FromDateLabel.Location = New System.Drawing.Point(82, 22)
        Me.FromDateLabel.Name = "FromDateLabel"
        Me.FromDateLabel.Size = New System.Drawing.Size(75, 16)
        Me.FromDateLabel.TabIndex = 123
        Me.FromDateLabel.Text = "1 May 2010"
        Me.FromDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FromDate
        '
        Me.FromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FromDate.Location = New System.Drawing.Point(208, 20)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(31, 22)
        Me.FromDate.TabIndex = 120
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(19, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 121
        Me.Label2.Text = "Start Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'tmrSize
        '
        Me.tmrSize.Enabled = True
        Me.tmrSize.Interval = 20
        '
        'Button1
        '
        Me.Button1.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Button1.Location = New System.Drawing.Point(331, 617)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(89, 21)
        Me.Button1.TabIndex = 84
        Me.Button1.Text = "Button1"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Form_Reservation_List_Show
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(383, 0)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.TableList)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Reservation_List_Show"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Reservation List"
        Me.TopMost = True
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.Status, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents TableList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNClose As C1.Win.C1Input.C1Button
    Friend WithEvents BTNEdit As C1.Win.C1Input.C1Button
    Friend WithEvents BTNVoid As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveDown As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveUp As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents VirtualDateFromDate As C1.Win.C1Input.C1Button
    Friend WithEvents FromDateLabel As System.Windows.Forms.Label
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents VirtualDateToDate As C1.Win.C1Input.C1Button
    Friend WithEvents ToDateLabel As System.Windows.Forms.Label
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Status As C1.Win.C1Input.C1Label
    Friend WithEvents LabelStatus As System.Windows.Forms.Label
    Friend WithEvents BTNView As C1.Win.C1Input.C1Button
    Friend WithEvents tmrSize As System.Windows.Forms.Timer
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
