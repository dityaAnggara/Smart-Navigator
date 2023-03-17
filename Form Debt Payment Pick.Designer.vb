<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Debt_Payment_Pick
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Debt_Payment_Pick))
        Me.Label1 = New System.Windows.Forms.Label
        Me.FindNo = New System.Windows.Forms.TextBox
        Me.FindName = New System.Windows.Forms.TextBox
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BTNMoveDown = New C1.Win.C1Input.C1Button
        Me.BTNMoveUp = New C1.Win.C1Input.C1Button
        Me.BTNOK = New C1.Win.C1Input.C1Button
        Me.BTNCancel = New C1.Win.C1Input.C1Button
        Me.Label11 = New System.Windows.Forms.Label
        Me.TableList = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.VirtualKey2 = New C1.Win.C1Input.C1Button
        Me.BTNSearch = New C1.Win.C1Input.C1Button
        Me.VirtualKey1 = New C1.Win.C1Input.C1Button
        Me.VirtualDateToDate = New C1.Win.C1Input.C1Button
        Me.VirtualDateFromDate = New C1.Win.C1Input.C1Button
        Me.ToDate = New System.Windows.Forms.DateTimePicker
        Me.FromDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.ToDateLabel = New System.Windows.Forms.Label
        Me.FromDateLabel = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.GroupBox2.SuspendLayout()
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(297, 56)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(62, 13)
        Me.Label1.TabIndex = 116
        Me.Label1.Text = "Cust. Name"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FindNo
        '
        Me.FindNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FindNo.Location = New System.Drawing.Point(90, 50)
        Me.FindNo.Name = "FindNo"
        Me.FindNo.Size = New System.Drawing.Size(137, 26)
        Me.FindNo.TabIndex = 108
        '
        'FindName
        '
        Me.FindName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FindName.Location = New System.Drawing.Point(364, 50)
        Me.FindName.Name = "FindName"
        Me.FindName.Size = New System.Drawing.Size(148, 26)
        Me.FindName.TabIndex = 110
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.BTNMoveDown)
        Me.GroupBox2.Controls.Add(Me.BTNMoveUp)
        Me.GroupBox2.Controls.Add(Me.BTNOK)
        Me.GroupBox2.Controls.Add(Me.BTNCancel)
        Me.GroupBox2.Location = New System.Drawing.Point(7, 594)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(672, 69)
        Me.GroupBox2.TabIndex = 114
        Me.GroupBox2.TabStop = False
        '
        'BTNMoveDown
        '
        Me.BTNMoveDown.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNMoveDown.Image = CType(resources.GetObject("BTNMoveDown.Image"), System.Drawing.Image)
        Me.BTNMoveDown.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNMoveDown.Location = New System.Drawing.Point(167, 16)
        Me.BTNMoveDown.Name = "BTNMoveDown"
        Me.BTNMoveDown.Size = New System.Drawing.Size(145, 41)
        Me.BTNMoveDown.TabIndex = 3
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
        Me.BTNMoveUp.Location = New System.Drawing.Point(16, 16)
        Me.BTNMoveUp.Name = "BTNMoveUp"
        Me.BTNMoveUp.Size = New System.Drawing.Size(145, 41)
        Me.BTNMoveUp.TabIndex = 2
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
        Me.BTNOK.Location = New System.Drawing.Point(361, 16)
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
        Me.BTNCancel.Location = New System.Drawing.Point(512, 16)
        Me.BTNCancel.Name = "BTNCancel"
        Me.BTNCancel.Size = New System.Drawing.Size(145, 41)
        Me.BTNCancel.TabIndex = 1
        Me.BTNCancel.Text = "Close"
        Me.BTNCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNCancel.UseVisualStyleBackColor = True
        Me.BTNCancel.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(8, 55)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 115
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
        Me.TableList.Location = New System.Drawing.Point(7, 91)
        Me.TableList.Name = "TableList"
        Me.TableList.Rows.Count = 1
        Me.TableList.Rows.DefaultSize = 18
        Me.TableList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.TableList.Size = New System.Drawing.Size(672, 500)
        Me.TableList.StyleInfo = resources.GetString("TableList.StyleInfo")
        Me.TableList.TabIndex = 113
        Me.TableList.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'VirtualKey2
        '
        Me.VirtualKey2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualKey2.Image = CType(resources.GetObject("VirtualKey2.Image"), System.Drawing.Image)
        Me.VirtualKey2.Location = New System.Drawing.Point(233, 47)
        Me.VirtualKey2.Name = "VirtualKey2"
        Me.VirtualKey2.Size = New System.Drawing.Size(58, 32)
        Me.VirtualKey2.TabIndex = 109
        Me.VirtualKey2.UseVisualStyleBackColor = True
        Me.VirtualKey2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNSearch
        '
        Me.BTNSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSearch.Image = CType(resources.GetObject("BTNSearch.Image"), System.Drawing.Image)
        Me.BTNSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNSearch.Location = New System.Drawing.Point(595, 19)
        Me.BTNSearch.Name = "BTNSearch"
        Me.BTNSearch.Size = New System.Drawing.Size(82, 48)
        Me.BTNSearch.TabIndex = 112
        Me.BTNSearch.Text = "Find"
        Me.BTNSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNSearch.UseVisualStyleBackColor = True
        Me.BTNSearch.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'VirtualKey1
        '
        Me.VirtualKey1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualKey1.Image = CType(resources.GetObject("VirtualKey1.Image"), System.Drawing.Image)
        Me.VirtualKey1.Location = New System.Drawing.Point(518, 47)
        Me.VirtualKey1.Name = "VirtualKey1"
        Me.VirtualKey1.Size = New System.Drawing.Size(58, 32)
        Me.VirtualKey1.TabIndex = 111
        Me.VirtualKey1.UseVisualStyleBackColor = True
        Me.VirtualKey1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'VirtualDateToDate
        '
        Me.VirtualDateToDate.Image = CType(resources.GetObject("VirtualDateToDate.Image"), System.Drawing.Image)
        Me.VirtualDateToDate.Location = New System.Drawing.Point(518, 9)
        Me.VirtualDateToDate.Name = "VirtualDateToDate"
        Me.VirtualDateToDate.Size = New System.Drawing.Size(58, 32)
        Me.VirtualDateToDate.TabIndex = 143
        Me.VirtualDateToDate.UseVisualStyleBackColor = True
        Me.VirtualDateToDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'VirtualDateFromDate
        '
        Me.VirtualDateFromDate.Image = CType(resources.GetObject("VirtualDateFromDate.Image"), System.Drawing.Image)
        Me.VirtualDateFromDate.Location = New System.Drawing.Point(233, 9)
        Me.VirtualDateFromDate.Name = "VirtualDateFromDate"
        Me.VirtualDateFromDate.Size = New System.Drawing.Size(58, 32)
        Me.VirtualDateFromDate.TabIndex = 142
        Me.VirtualDateFromDate.UseVisualStyleBackColor = True
        Me.VirtualDateFromDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ToDate
        '
        Me.ToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ToDate.Location = New System.Drawing.Point(530, 14)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(24, 22)
        Me.ToDate.TabIndex = 141
        '
        'FromDate
        '
        Me.FromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FromDate.Location = New System.Drawing.Point(245, 14)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(25, 22)
        Me.FromDate.TabIndex = 140
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(303, 19)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 139
        Me.Label4.Text = "End Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToDateLabel
        '
        Me.ToDateLabel.AutoSize = True
        Me.ToDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToDateLabel.Location = New System.Drawing.Point(355, 17)
        Me.ToDateLabel.Name = "ToDateLabel"
        Me.ToDateLabel.Size = New System.Drawing.Size(75, 16)
        Me.ToDateLabel.TabIndex = 138
        Me.ToDateLabel.Text = "1 May 2010"
        Me.ToDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FromDateLabel
        '
        Me.FromDateLabel.AutoSize = True
        Me.FromDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FromDateLabel.Location = New System.Drawing.Point(87, 17)
        Me.FromDateLabel.Name = "FromDateLabel"
        Me.FromDateLabel.Size = New System.Drawing.Size(75, 16)
        Me.FromDateLabel.TabIndex = 137
        Me.FromDateLabel.Text = "1 May 2010"
        Me.FromDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(25, 19)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 136
        Me.Label2.Text = "Start Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Form_Debt_Payment_Pick
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(686, 670)
        Me.ControlBox = False
        Me.Controls.Add(Me.VirtualDateToDate)
        Me.Controls.Add(Me.VirtualDateFromDate)
        Me.Controls.Add(Me.ToDate)
        Me.Controls.Add(Me.FromDate)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.ToDateLabel)
        Me.Controls.Add(Me.FromDateLabel)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.VirtualKey2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.FindNo)
        Me.Controls.Add(Me.BTNSearch)
        Me.Controls.Add(Me.VirtualKey1)
        Me.Controls.Add(Me.FindName)
        Me.Controls.Add(Me.GroupBox2)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TableList)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Debt_Payment_Pick"
        Me.ShowInTaskbar = False
        Me.Text = "Customer List"
        Me.GroupBox2.ResumeLayout(False)
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents BTNOK As C1.Win.C1Input.C1Button
    Friend WithEvents BTNCancel As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualKey2 As C1.Win.C1Input.C1Button
    Friend WithEvents BTNMoveUp As C1.Win.C1Input.C1Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FindNo As System.Windows.Forms.TextBox
    Friend WithEvents BTNSearch As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualKey1 As C1.Win.C1Input.C1Button
    Friend WithEvents FindName As System.Windows.Forms.TextBox
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents BTNMoveDown As C1.Win.C1Input.C1Button
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents TableList As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents VirtualDateToDate As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualDateFromDate As C1.Win.C1Input.C1Button
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToDateLabel As System.Windows.Forms.Label
    Friend WithEvents FromDateLabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
End Class
