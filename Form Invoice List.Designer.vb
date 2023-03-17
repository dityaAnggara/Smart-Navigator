<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Invoice_List
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Invoice_List))
    Me.VirtualKey2 = New C1.Win.C1Input.C1Button
    Me.Label1 = New System.Windows.Forms.Label
    Me.BTNSearch = New C1.Win.C1Input.C1Button
    Me.BTNMoveUp = New C1.Win.C1Input.C1Button
    Me.BTNMoveDown = New C1.Win.C1Input.C1Button
    Me.Label11 = New System.Windows.Forms.Label
    Me.TableList = New C1.Win.C1FlexGrid.C1FlexGrid
    Me.FindNo = New System.Windows.Forms.TextBox
    Me.VirtualKey1 = New C1.Win.C1Input.C1Button
    Me.FindName = New System.Windows.Forms.TextBox
    Me.GroupBox2 = New System.Windows.Forms.GroupBox
    Me.BTNVoid = New C1.Win.C1Input.C1Button
    Me.BTNClose = New C1.Win.C1Input.C1Button
    Me.BTNEdit = New C1.Win.C1Input.C1Button
    Me.Label4 = New System.Windows.Forms.Label
    Me.ToDateLabel = New System.Windows.Forms.Label
    Me.FromDateLabel = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.VirtualDateToDate = New C1.Win.C1Input.C1Button
    Me.VirtualDateFromDate = New C1.Win.C1Input.C1Button
    Me.ToDate = New System.Windows.Forms.DateTimePicker
    Me.FromDate = New System.Windows.Forms.DateTimePicker
    Me.Panel1 = New System.Windows.Forms.Panel
    CType(Me.TableList, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBox2.SuspendLayout()
    Me.Panel1.SuspendLayout()
    Me.SuspendLayout()
    '
    'VirtualKey2
    '
    Me.VirtualKey2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.VirtualKey2.Image = CType(resources.GetObject("VirtualKey2.Image"), System.Drawing.Image)
    Me.VirtualKey2.Location = New System.Drawing.Point(229, 47)
    Me.VirtualKey2.Name = "VirtualKey2"
    Me.VirtualKey2.Size = New System.Drawing.Size(58, 32)
    Me.VirtualKey2.TabIndex = 118
    Me.VirtualKey2.UseVisualStyleBackColor = True
    Me.VirtualKey2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label1.Location = New System.Drawing.Point(293, 56)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(62, 13)
    Me.Label1.TabIndex = 125
    Me.Label1.Text = "Cust. Name"
    Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'BTNSearch
    '
    Me.BTNSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BTNSearch.Image = CType(resources.GetObject("BTNSearch.Image"), System.Drawing.Image)
    Me.BTNSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BTNSearch.Location = New System.Drawing.Point(584, 26)
    Me.BTNSearch.Name = "BTNSearch"
    Me.BTNSearch.Size = New System.Drawing.Size(88, 42)
    Me.BTNSearch.TabIndex = 121
    Me.BTNSearch.Text = "Find"
    Me.BTNSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BTNSearch.UseVisualStyleBackColor = True
    Me.BTNSearch.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'BTNMoveUp
    '
    Me.BTNMoveUp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BTNMoveUp.Image = CType(resources.GetObject("BTNMoveUp.Image"), System.Drawing.Image)
    Me.BTNMoveUp.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BTNMoveUp.Location = New System.Drawing.Point(16, 16)
    Me.BTNMoveUp.Name = "BTNMoveUp"
    Me.BTNMoveUp.Size = New System.Drawing.Size(90, 41)
    Me.BTNMoveUp.TabIndex = 2
    Me.BTNMoveUp.Text = "Up"
    Me.BTNMoveUp.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BTNMoveUp.UseVisualStyleBackColor = True
    Me.BTNMoveUp.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'BTNMoveDown
    '
    Me.BTNMoveDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BTNMoveDown.Image = CType(resources.GetObject("BTNMoveDown.Image"), System.Drawing.Image)
    Me.BTNMoveDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BTNMoveDown.Location = New System.Drawing.Point(112, 16)
    Me.BTNMoveDown.Name = "BTNMoveDown"
    Me.BTNMoveDown.Size = New System.Drawing.Size(90, 41)
    Me.BTNMoveDown.TabIndex = 3
    Me.BTNMoveDown.Text = "Down"
    Me.BTNMoveDown.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BTNMoveDown.UseVisualStyleBackColor = True
    Me.BTNMoveDown.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'Label11
    '
    Me.Label11.AutoSize = True
    Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label11.Location = New System.Drawing.Point(4, 55)
    Me.Label11.Name = "Label11"
    Me.Label11.Size = New System.Drawing.Size(83, 13)
    Me.Label11.TabIndex = 124
    Me.Label11.Text = "Transaction No."
    Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
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
    Me.TableList.Location = New System.Drawing.Point(7, 94)
    Me.TableList.Name = "TableList"
    Me.TableList.Rows.Count = 1
    Me.TableList.Rows.DefaultSize = 18
    Me.TableList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
    Me.TableList.Size = New System.Drawing.Size(1005, 498)
    Me.TableList.StyleInfo = resources.GetString("TableList.StyleInfo")
    Me.TableList.TabIndex = 122
    Me.TableList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
    '
    'FindNo
    '
    Me.FindNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FindNo.Location = New System.Drawing.Point(92, 50)
    Me.FindNo.Name = "FindNo"
    Me.FindNo.Size = New System.Drawing.Size(132, 26)
    Me.FindNo.TabIndex = 117
    '
    'VirtualKey1
    '
    Me.VirtualKey1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.VirtualKey1.Image = CType(resources.GetObject("VirtualKey1.Image"), System.Drawing.Image)
    Me.VirtualKey1.Location = New System.Drawing.Point(514, 47)
    Me.VirtualKey1.Name = "VirtualKey1"
    Me.VirtualKey1.Size = New System.Drawing.Size(58, 32)
    Me.VirtualKey1.TabIndex = 120
    Me.VirtualKey1.UseVisualStyleBackColor = True
    Me.VirtualKey1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'FindName
    '
    Me.FindName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FindName.Location = New System.Drawing.Point(360, 50)
    Me.FindName.Name = "FindName"
    Me.FindName.Size = New System.Drawing.Size(148, 26)
    Me.FindName.TabIndex = 119
    '
    'GroupBox2
    '
    Me.GroupBox2.Controls.Add(Me.BTNVoid)
    Me.GroupBox2.Controls.Add(Me.BTNClose)
    Me.GroupBox2.Controls.Add(Me.BTNEdit)
    Me.GroupBox2.Controls.Add(Me.BTNMoveDown)
    Me.GroupBox2.Controls.Add(Me.BTNMoveUp)
    Me.GroupBox2.Location = New System.Drawing.Point(7, 616)
    Me.GroupBox2.Name = "GroupBox2"
    Me.GroupBox2.Size = New System.Drawing.Size(1005, 69)
    Me.GroupBox2.TabIndex = 123
    Me.GroupBox2.TabStop = False
    '
    'BTNVoid
    '
    Me.BTNVoid.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BTNVoid.Image = CType(resources.GetObject("BTNVoid.Image"), System.Drawing.Image)
    Me.BTNVoid.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BTNVoid.Location = New System.Drawing.Point(545, 16)
    Me.BTNVoid.Name = "BTNVoid"
    Me.BTNVoid.Size = New System.Drawing.Size(145, 41)
    Me.BTNVoid.TabIndex = 17
    Me.BTNVoid.Text = "Void"
    Me.BTNVoid.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BTNVoid.UseVisualStyleBackColor = True
    Me.BTNVoid.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'BTNClose
    '
    Me.BTNClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BTNClose.Image = CType(resources.GetObject("BTNClose.Image"), System.Drawing.Image)
    Me.BTNClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BTNClose.Location = New System.Drawing.Point(847, 16)
    Me.BTNClose.Name = "BTNClose"
    Me.BTNClose.Size = New System.Drawing.Size(145, 41)
    Me.BTNClose.TabIndex = 16
    Me.BTNClose.Text = "Close"
    Me.BTNClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BTNClose.UseVisualStyleBackColor = True
    Me.BTNClose.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'BTNEdit
    '
    Me.BTNEdit.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BTNEdit.Image = CType(resources.GetObject("BTNEdit.Image"), System.Drawing.Image)
    Me.BTNEdit.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BTNEdit.Location = New System.Drawing.Point(696, 16)
    Me.BTNEdit.Name = "BTNEdit"
    Me.BTNEdit.Size = New System.Drawing.Size(145, 41)
    Me.BTNEdit.TabIndex = 15
    Me.BTNEdit.Text = "Edit"
    Me.BTNEdit.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BTNEdit.UseVisualStyleBackColor = True
    Me.BTNEdit.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(293, 17)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(52, 13)
    Me.Label4.TabIndex = 131
    Me.Label4.Text = "End Date"
    Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'ToDateLabel
    '
    Me.ToDateLabel.AutoSize = True
    Me.ToDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToDateLabel.Location = New System.Drawing.Point(364, 15)
    Me.ToDateLabel.Name = "ToDateLabel"
    Me.ToDateLabel.Size = New System.Drawing.Size(75, 16)
    Me.ToDateLabel.TabIndex = 128
    Me.ToDateLabel.Text = "1 May 2010"
    Me.ToDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'FromDateLabel
    '
    Me.FromDateLabel.AutoSize = True
    Me.FromDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FromDateLabel.Location = New System.Drawing.Point(89, 15)
    Me.FromDateLabel.Name = "FromDateLabel"
    Me.FromDateLabel.Size = New System.Drawing.Size(75, 16)
    Me.FromDateLabel.TabIndex = 127
    Me.FromDateLabel.Text = "1 May 2010"
    Me.FromDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(8, 15)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(55, 13)
    Me.Label2.TabIndex = 126
    Me.Label2.Text = "Start Date"
    Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
    '
    'VirtualDateToDate
    '
    Me.VirtualDateToDate.Image = CType(resources.GetObject("VirtualDateToDate.Image"), System.Drawing.Image)
    Me.VirtualDateToDate.Location = New System.Drawing.Point(514, 7)
    Me.VirtualDateToDate.Name = "VirtualDateToDate"
    Me.VirtualDateToDate.Size = New System.Drawing.Size(58, 32)
    Me.VirtualDateToDate.TabIndex = 135
    Me.VirtualDateToDate.UseVisualStyleBackColor = True
    Me.VirtualDateToDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'VirtualDateFromDate
    '
    Me.VirtualDateFromDate.Image = CType(resources.GetObject("VirtualDateFromDate.Image"), System.Drawing.Image)
    Me.VirtualDateFromDate.Location = New System.Drawing.Point(229, 8)
    Me.VirtualDateFromDate.Name = "VirtualDateFromDate"
    Me.VirtualDateFromDate.Size = New System.Drawing.Size(58, 32)
    Me.VirtualDateFromDate.TabIndex = 134
    Me.VirtualDateFromDate.UseVisualStyleBackColor = True
    Me.VirtualDateFromDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'ToDate
    '
    Me.ToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.ToDate.Location = New System.Drawing.Point(532, 12)
    Me.ToDate.Name = "ToDate"
    Me.ToDate.Size = New System.Drawing.Size(24, 22)
    Me.ToDate.TabIndex = 133
    '
    'FromDate
    '
    Me.FromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.FromDate.Location = New System.Drawing.Point(247, 12)
    Me.FromDate.Name = "FromDate"
    Me.FromDate.Size = New System.Drawing.Size(25, 22)
    Me.FromDate.TabIndex = 132
    '
    'Panel1
    '
    Me.Panel1.Controls.Add(Me.VirtualDateToDate)
    Me.Panel1.Controls.Add(Me.VirtualDateFromDate)
    Me.Panel1.Controls.Add(Me.ToDate)
    Me.Panel1.Controls.Add(Me.FromDate)
    Me.Panel1.Controls.Add(Me.Label4)
    Me.Panel1.Controls.Add(Me.ToDateLabel)
    Me.Panel1.Controls.Add(Me.FromDateLabel)
    Me.Panel1.Controls.Add(Me.Label2)
    Me.Panel1.Controls.Add(Me.VirtualKey2)
    Me.Panel1.Controls.Add(Me.Label1)
    Me.Panel1.Controls.Add(Me.BTNSearch)
    Me.Panel1.Controls.Add(Me.Label11)
    Me.Panel1.Controls.Add(Me.FindNo)
    Me.Panel1.Controls.Add(Me.VirtualKey1)
    Me.Panel1.Controls.Add(Me.FindName)
    Me.Panel1.Location = New System.Drawing.Point(4, 4)
    Me.Panel1.Name = "Panel1"
    Me.Panel1.Size = New System.Drawing.Size(679, 85)
    Me.Panel1.TabIndex = 136
    '
    'Form_Invoice_List
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.AliceBlue
    Me.ClientSize = New System.Drawing.Size(1024, 700)
    Me.ControlBox = False
    Me.Controls.Add(Me.Panel1)
    Me.Controls.Add(Me.TableList)
    Me.Controls.Add(Me.GroupBox2)
    Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Form_Invoice_List"
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.Text = "Invoice List"
    CType(Me.TableList, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBox2.ResumeLayout(False)
    Me.Panel1.ResumeLayout(False)
    Me.Panel1.PerformLayout()
    Me.ResumeLayout(False)

  End Sub
    Friend WithEvents VirtualKey2 As C1.Win.C1Input.C1Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTNSearch As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveUp As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveDown As C1.Win.C1Input.C1Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TableList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents FindNo As System.Windows.Forms.TextBox
    Friend WithEvents VirtualKey1 As C1.Win.C1Input.C1Button
    Friend WithEvents FindName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNEdit As C1.Win.C1Input.C1Button
    Friend WithEvents BTNClose As C1.Win.C1Input.C1Button
    Friend WithEvents BTNVoid As C1.Win.C1Input.C1Button
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToDateLabel As System.Windows.Forms.Label
    Friend WithEvents FromDateLabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents VirtualDateToDate As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualDateFromDate As C1.Win.C1Input.C1Button
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
End Class
