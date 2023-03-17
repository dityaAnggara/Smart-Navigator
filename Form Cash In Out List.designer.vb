<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Cash_In_Out_List
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Cash_In_Out_List))
        Me.BTNDelete = New C1.Win.C1Input.C1Button
        Me.TableList = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.BTNEdit = New C1.Win.C1Input.C1Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.BTNMoveDown = New C1.Win.C1Input.C1Button
        Me.BTNMoveUp = New C1.Win.C1Input.C1Button
        Me.BTNViewNotes = New C1.Win.C1Input.C1Button
        Me.BTNPrint = New C1.Win.C1Input.C1Button
        Me.BTNClose = New C1.Win.C1Input.C1Button
        Me.VirtualDateToDate = New C1.Win.C1Input.C1Button
        Me.VirtualDateFromDate = New C1.Win.C1Input.C1Button
        Me.ToDate = New System.Windows.Forms.DateTimePicker
        Me.FromDate = New System.Windows.Forms.DateTimePicker
        Me.Label4 = New System.Windows.Forms.Label
        Me.ToDateLabel = New System.Windows.Forms.Label
        Me.FromDateLabel = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.VirtualKey2 = New C1.Win.C1Input.C1Button
        Me.Label1 = New System.Windows.Forms.Label
        Me.FindNo = New System.Windows.Forms.TextBox
        Me.BTNSearch = New C1.Win.C1Input.C1Button
        Me.VirtualKey1 = New C1.Win.C1Input.C1Button
        Me.FindName = New System.Windows.Forms.TextBox
        Me.Label11 = New System.Windows.Forms.Label
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
        Me.BTNDelete.Text = "Void"
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
        Me.TableList.Location = New System.Drawing.Point(5, 102)
        Me.TableList.Name = "TableList"
        Me.TableList.Rows.Count = 1
        Me.TableList.Rows.DefaultSize = 19
        Me.TableList.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
        Me.TableList.Size = New System.Drawing.Size(1008, 508)
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
        Me.BTNMoveDown.Visible = False
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
        Me.BTNMoveUp.Visible = False
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
        Me.BTNViewNotes.Visible = False
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
        'VirtualDateToDate
        '
        Me.VirtualDateToDate.Image = CType(resources.GetObject("VirtualDateToDate.Image"), System.Drawing.Image)
        Me.VirtualDateToDate.Location = New System.Drawing.Point(523, 12)
        Me.VirtualDateToDate.Name = "VirtualDateToDate"
        Me.VirtualDateToDate.Size = New System.Drawing.Size(58, 32)
        Me.VirtualDateToDate.TabIndex = 158
        Me.VirtualDateToDate.UseVisualStyleBackColor = True
        Me.VirtualDateToDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'VirtualDateFromDate
        '
        Me.VirtualDateFromDate.Image = CType(resources.GetObject("VirtualDateFromDate.Image"), System.Drawing.Image)
        Me.VirtualDateFromDate.Location = New System.Drawing.Point(238, 12)
        Me.VirtualDateFromDate.Name = "VirtualDateFromDate"
        Me.VirtualDateFromDate.Size = New System.Drawing.Size(58, 32)
        Me.VirtualDateFromDate.TabIndex = 157
        Me.VirtualDateFromDate.UseVisualStyleBackColor = True
        Me.VirtualDateFromDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ToDate
        '
        Me.ToDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.ToDate.Location = New System.Drawing.Point(535, 17)
        Me.ToDate.Name = "ToDate"
        Me.ToDate.Size = New System.Drawing.Size(24, 22)
        Me.ToDate.TabIndex = 156
        '
        'FromDate
        '
        Me.FromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.FromDate.Location = New System.Drawing.Point(250, 17)
        Me.FromDate.Name = "FromDate"
        Me.FromDate.Size = New System.Drawing.Size(25, 22)
        Me.FromDate.TabIndex = 155
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(308, 22)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(52, 13)
        Me.Label4.TabIndex = 154
        Me.Label4.Text = "End Date"
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'ToDateLabel
        '
        Me.ToDateLabel.AutoSize = True
        Me.ToDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.ToDateLabel.Location = New System.Drawing.Point(360, 20)
        Me.ToDateLabel.Name = "ToDateLabel"
        Me.ToDateLabel.Size = New System.Drawing.Size(75, 16)
        Me.ToDateLabel.TabIndex = 153
        Me.ToDateLabel.Text = "1 May 2010"
        Me.ToDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FromDateLabel
        '
        Me.FromDateLabel.AutoSize = True
        Me.FromDateLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FromDateLabel.Location = New System.Drawing.Point(92, 20)
        Me.FromDateLabel.Name = "FromDateLabel"
        Me.FromDateLabel.Size = New System.Drawing.Size(75, 16)
        Me.FromDateLabel.TabIndex = 152
        Me.FromDateLabel.Text = "1 May 2010"
        Me.FromDateLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(30, 22)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(55, 13)
        Me.Label2.TabIndex = 151
        Me.Label2.Text = "Start Date"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VirtualKey2
        '
        Me.VirtualKey2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualKey2.Image = CType(resources.GetObject("VirtualKey2.Image"), System.Drawing.Image)
        Me.VirtualKey2.Location = New System.Drawing.Point(238, 50)
        Me.VirtualKey2.Name = "VirtualKey2"
        Me.VirtualKey2.Size = New System.Drawing.Size(58, 32)
        Me.VirtualKey2.TabIndex = 145
        Me.VirtualKey2.UseVisualStyleBackColor = True
        Me.VirtualKey2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(302, 59)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(60, 13)
        Me.Label1.TabIndex = 150
        Me.Label1.Text = "Description"
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'FindNo
        '
        Me.FindNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FindNo.Location = New System.Drawing.Point(95, 53)
        Me.FindNo.Name = "FindNo"
        Me.FindNo.Size = New System.Drawing.Size(137, 26)
        Me.FindNo.TabIndex = 144
        '
        'BTNSearch
        '
        Me.BTNSearch.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSearch.Image = CType(resources.GetObject("BTNSearch.Image"), System.Drawing.Image)
        Me.BTNSearch.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNSearch.Location = New System.Drawing.Point(600, 22)
        Me.BTNSearch.Name = "BTNSearch"
        Me.BTNSearch.Size = New System.Drawing.Size(82, 48)
        Me.BTNSearch.TabIndex = 148
        Me.BTNSearch.Text = "Find"
        Me.BTNSearch.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNSearch.UseVisualStyleBackColor = True
        Me.BTNSearch.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'VirtualKey1
        '
        Me.VirtualKey1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualKey1.Image = CType(resources.GetObject("VirtualKey1.Image"), System.Drawing.Image)
        Me.VirtualKey1.Location = New System.Drawing.Point(523, 50)
        Me.VirtualKey1.Name = "VirtualKey1"
        Me.VirtualKey1.Size = New System.Drawing.Size(58, 32)
        Me.VirtualKey1.TabIndex = 147
        Me.VirtualKey1.UseVisualStyleBackColor = True
        Me.VirtualKey1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'FindName
        '
        Me.FindName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.FindName.Location = New System.Drawing.Point(369, 53)
        Me.FindName.Name = "FindName"
        Me.FindName.Size = New System.Drawing.Size(148, 26)
        Me.FindName.TabIndex = 146
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label11.Location = New System.Drawing.Point(13, 58)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(83, 13)
        Me.Label11.TabIndex = 149
        Me.Label11.Text = "Transaction No."
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Form_Cash_In_Out_List
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(1018, 697)
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
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.TableList)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Cash_In_Out_List"
        Me.ShowInTaskbar = False
        Me.Text = "Cash In List"
        CType(Me.TableList, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

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
    Friend WithEvents VirtualDateToDate As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualDateFromDate As C1.Win.C1Input.C1Button
    Friend WithEvents ToDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents FromDate As System.Windows.Forms.DateTimePicker
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents ToDateLabel As System.Windows.Forms.Label
    Friend WithEvents FromDateLabel As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents VirtualKey2 As C1.Win.C1Input.C1Button
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents FindNo As System.Windows.Forms.TextBox
    Friend WithEvents BTNSearch As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualKey1 As C1.Win.C1Input.C1Button
    Friend WithEvents FindName As System.Windows.Forms.TextBox
    Friend WithEvents Label11 As System.Windows.Forms.Label
End Class
