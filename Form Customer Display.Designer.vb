<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Custm_Display_MakeBill
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Custm_Display_MakeBill))
    Me.OrderDetail = New C1.Win.C1FlexGrid.C1FlexGrid
    Me.TimerCustDisplay = New System.Windows.Forms.Timer(Me.components)
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.GroupBoxSBITM = New System.Windows.Forms.GroupBox
    Me.SubTotalTxt = New System.Windows.Forms.Label
    Me.Label16 = New System.Windows.Forms.Label
    Me.lblTotalItem = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.TimerPicture = New System.Windows.Forms.Timer(Me.components)
    Me.GroupMakeBill = New System.Windows.Forms.GroupBox
    Me.LabelTAVal = New System.Windows.Forms.Label
    Me.LabelRoundVal = New System.Windows.Forms.Label
    Me.LabelDPVal = New System.Windows.Forms.Label
    Me.LabelPBVal = New System.Windows.Forms.Label
    Me.LabelTOTAKH = New System.Windows.Forms.Label
    Me.LabelROUND = New System.Windows.Forms.Label
    Me.LabelDP = New System.Windows.Forms.Label
    Me.LabelPB = New System.Windows.Forms.Label
    Me.LabelSCVal = New System.Windows.Forms.Label
    Me.LabelSC = New System.Windows.Forms.Label
    Me.LblDiscountVal = New System.Windows.Forms.Label
    Me.LabelDiscount = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.IdFromInvoiceList = New System.Windows.Forms.TextBox
    Me.LabelTest = New System.Windows.Forms.Label
    Me.TextBox2 = New System.Windows.Forms.TextBox
    Me.ListPictureCustDispl = New System.Windows.Forms.ListBox
    CType(Me.OrderDetail, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupBoxSBITM.SuspendLayout()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.GroupMakeBill.SuspendLayout()
    Me.SuspendLayout()
    '
    'OrderDetail
    '
    Me.OrderDetail.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
    Me.OrderDetail.AllowEditing = False
    Me.OrderDetail.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None
    Me.OrderDetail.ColumnInfo = resources.GetString("OrderDetail.ColumnInfo")
    Me.OrderDetail.ExtendLastCol = True
    Me.OrderDetail.FocusRect = C1.Win.C1FlexGrid.FocusRectEnum.None
    Me.OrderDetail.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.OrderDetail.Location = New System.Drawing.Point(12, 33)
    Me.OrderDetail.Name = "OrderDetail"
    Me.OrderDetail.Rows.Count = 1
    Me.OrderDetail.Rows.DefaultSize = 18
    Me.OrderDetail.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
    Me.OrderDetail.Size = New System.Drawing.Size(488, 265)
    Me.OrderDetail.StyleInfo = resources.GetString("OrderDetail.StyleInfo")
    Me.OrderDetail.TabIndex = 1
    Me.OrderDetail.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
    '
    'TimerCustDisplay
    '
    Me.TimerCustDisplay.Enabled = True
    Me.TimerCustDisplay.Interval = 1
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(211, 70)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(100, 20)
    Me.TextBox1.TabIndex = 2
    Me.TextBox1.Visible = False
    '
    'GroupBoxSBITM
    '
    Me.GroupBoxSBITM.Controls.Add(Me.SubTotalTxt)
    Me.GroupBoxSBITM.Controls.Add(Me.Label16)
    Me.GroupBoxSBITM.Controls.Add(Me.lblTotalItem)
    Me.GroupBoxSBITM.Controls.Add(Me.Label2)
    Me.GroupBoxSBITM.Location = New System.Drawing.Point(12, 304)
    Me.GroupBoxSBITM.Name = "GroupBoxSBITM"
    Me.GroupBoxSBITM.Size = New System.Drawing.Size(488, 74)
    Me.GroupBoxSBITM.TabIndex = 3
    Me.GroupBoxSBITM.TabStop = False
    '
    'SubTotalTxt
    '
    Me.SubTotalTxt.BackColor = System.Drawing.Color.AliceBlue
    Me.SubTotalTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.SubTotalTxt.ForeColor = System.Drawing.Color.Maroon
    Me.SubTotalTxt.Location = New System.Drawing.Point(302, 39)
    Me.SubTotalTxt.Name = "SubTotalTxt"
    Me.SubTotalTxt.Size = New System.Drawing.Size(167, 26)
    Me.SubTotalTxt.TabIndex = 197
    Me.SubTotalTxt.Text = "0"
    Me.SubTotalTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label16
    '
    Me.Label16.AutoSize = True
    Me.Label16.BackColor = System.Drawing.Color.AliceBlue
    Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label16.ForeColor = System.Drawing.Color.Maroon
    Me.Label16.Location = New System.Drawing.Point(329, 16)
    Me.Label16.Name = "Label16"
    Me.Label16.Size = New System.Drawing.Size(77, 15)
    Me.Label16.TabIndex = 196
    Me.Label16.Text = "SUBTOTAL"
    '
    'lblTotalItem
    '
    Me.lblTotalItem.BackColor = System.Drawing.Color.AliceBlue
    Me.lblTotalItem.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.lblTotalItem.ForeColor = System.Drawing.Color.Maroon
    Me.lblTotalItem.Location = New System.Drawing.Point(6, 39)
    Me.lblTotalItem.Name = "lblTotalItem"
    Me.lblTotalItem.Size = New System.Drawing.Size(83, 26)
    Me.lblTotalItem.TabIndex = 195
    Me.lblTotalItem.Text = "0"
    Me.lblTotalItem.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.BackColor = System.Drawing.Color.AliceBlue
    Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label2.ForeColor = System.Drawing.Color.Maroon
    Me.Label2.Location = New System.Drawing.Point(18, 16)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(40, 15)
    Me.Label2.TabIndex = 194
    Me.Label2.Text = "ITEM"
    '
    'PictureBox1
    '
    Me.PictureBox1.Location = New System.Drawing.Point(506, 12)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(841, 706)
    Me.PictureBox1.TabIndex = 4
    Me.PictureBox1.TabStop = False
    '
    'TimerPicture
    '
    Me.TimerPicture.Enabled = True
    Me.TimerPicture.Interval = 1000
    '
    'GroupMakeBill
    '
    Me.GroupMakeBill.Controls.Add(Me.LabelTAVal)
    Me.GroupMakeBill.Controls.Add(Me.LabelRoundVal)
    Me.GroupMakeBill.Controls.Add(Me.LabelDPVal)
    Me.GroupMakeBill.Controls.Add(Me.LabelPBVal)
    Me.GroupMakeBill.Controls.Add(Me.LabelTOTAKH)
    Me.GroupMakeBill.Controls.Add(Me.LabelROUND)
    Me.GroupMakeBill.Controls.Add(Me.LabelDP)
    Me.GroupMakeBill.Controls.Add(Me.LabelPB)
    Me.GroupMakeBill.Controls.Add(Me.LabelSCVal)
    Me.GroupMakeBill.Controls.Add(Me.LabelSC)
    Me.GroupMakeBill.Controls.Add(Me.LblDiscountVal)
    Me.GroupMakeBill.Controls.Add(Me.LabelDiscount)
    Me.GroupMakeBill.Controls.Add(Me.Label3)
    Me.GroupMakeBill.Location = New System.Drawing.Point(12, 384)
    Me.GroupMakeBill.Name = "GroupMakeBill"
    Me.GroupMakeBill.Size = New System.Drawing.Size(488, 334)
    Me.GroupMakeBill.TabIndex = 5
    Me.GroupMakeBill.TabStop = False
    '
    'LabelTAVal
    '
    Me.LabelTAVal.BackColor = System.Drawing.Color.AliceBlue
    Me.LabelTAVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabelTAVal.ForeColor = System.Drawing.Color.Maroon
    Me.LabelTAVal.Location = New System.Drawing.Point(302, 271)
    Me.LabelTAVal.Name = "LabelTAVal"
    Me.LabelTAVal.Size = New System.Drawing.Size(167, 26)
    Me.LabelTAVal.TabIndex = 205
    Me.LabelTAVal.Text = "0"
    Me.LabelTAVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabelRoundVal
    '
    Me.LabelRoundVal.BackColor = System.Drawing.Color.AliceBlue
    Me.LabelRoundVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabelRoundVal.ForeColor = System.Drawing.Color.Maroon
    Me.LabelRoundVal.Location = New System.Drawing.Point(302, 233)
    Me.LabelRoundVal.Name = "LabelRoundVal"
    Me.LabelRoundVal.Size = New System.Drawing.Size(167, 26)
    Me.LabelRoundVal.TabIndex = 203
    Me.LabelRoundVal.Text = "0"
    Me.LabelRoundVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabelDPVal
    '
    Me.LabelDPVal.BackColor = System.Drawing.Color.AliceBlue
    Me.LabelDPVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabelDPVal.ForeColor = System.Drawing.Color.Maroon
    Me.LabelDPVal.Location = New System.Drawing.Point(302, 178)
    Me.LabelDPVal.Name = "LabelDPVal"
    Me.LabelDPVal.Size = New System.Drawing.Size(167, 26)
    Me.LabelDPVal.TabIndex = 202
    Me.LabelDPVal.Text = "0"
    Me.LabelDPVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabelPBVal
    '
    Me.LabelPBVal.BackColor = System.Drawing.Color.AliceBlue
    Me.LabelPBVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabelPBVal.ForeColor = System.Drawing.Color.Maroon
    Me.LabelPBVal.Location = New System.Drawing.Point(302, 137)
    Me.LabelPBVal.Name = "LabelPBVal"
    Me.LabelPBVal.Size = New System.Drawing.Size(167, 26)
    Me.LabelPBVal.TabIndex = 201
    Me.LabelPBVal.Text = "0"
    Me.LabelPBVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabelTOTAKH
    '
    Me.LabelTOTAKH.AutoSize = True
    Me.LabelTOTAKH.BackColor = System.Drawing.Color.AliceBlue
    Me.LabelTOTAKH.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabelTOTAKH.ForeColor = System.Drawing.Color.Maroon
    Me.LabelTOTAKH.Location = New System.Drawing.Point(18, 282)
    Me.LabelTOTAKH.Name = "LabelTOTAKH"
    Me.LabelTOTAKH.Size = New System.Drawing.Size(94, 15)
    Me.LabelTOTAKH.TabIndex = 204
    Me.LabelTOTAKH.Text = "TOTAL AKHIR"
    '
    'LabelROUND
    '
    Me.LabelROUND.AutoSize = True
    Me.LabelROUND.BackColor = System.Drawing.Color.AliceBlue
    Me.LabelROUND.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabelROUND.ForeColor = System.Drawing.Color.Maroon
    Me.LabelROUND.Location = New System.Drawing.Point(18, 241)
    Me.LabelROUND.Name = "LabelROUND"
    Me.LabelROUND.Size = New System.Drawing.Size(81, 15)
    Me.LabelROUND.TabIndex = 203
    Me.LabelROUND.Text = "ROUNDING"
    '
    'LabelDP
    '
    Me.LabelDP.AutoSize = True
    Me.LabelDP.BackColor = System.Drawing.Color.AliceBlue
    Me.LabelDP.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabelDP.ForeColor = System.Drawing.Color.Maroon
    Me.LabelDP.Location = New System.Drawing.Point(17, 189)
    Me.LabelDP.Name = "LabelDP"
    Me.LabelDP.Size = New System.Drawing.Size(26, 15)
    Me.LabelDP.TabIndex = 202
    Me.LabelDP.Text = "DP"
    '
    'LabelPB
    '
    Me.LabelPB.AutoSize = True
    Me.LabelPB.BackColor = System.Drawing.Color.AliceBlue
    Me.LabelPB.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabelPB.ForeColor = System.Drawing.Color.Maroon
    Me.LabelPB.Location = New System.Drawing.Point(18, 148)
    Me.LabelPB.Name = "LabelPB"
    Me.LabelPB.Size = New System.Drawing.Size(25, 15)
    Me.LabelPB.TabIndex = 201
    Me.LabelPB.Text = "PB"
    '
    'LabelSCVal
    '
    Me.LabelSCVal.BackColor = System.Drawing.Color.AliceBlue
    Me.LabelSCVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabelSCVal.ForeColor = System.Drawing.Color.Maroon
    Me.LabelSCVal.Location = New System.Drawing.Point(302, 96)
    Me.LabelSCVal.Name = "LabelSCVal"
    Me.LabelSCVal.Size = New System.Drawing.Size(167, 26)
    Me.LabelSCVal.TabIndex = 200
    Me.LabelSCVal.Text = "0"
    Me.LabelSCVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabelSC
    '
    Me.LabelSC.AutoSize = True
    Me.LabelSC.BackColor = System.Drawing.Color.AliceBlue
    Me.LabelSC.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabelSC.ForeColor = System.Drawing.Color.Maroon
    Me.LabelSC.Location = New System.Drawing.Point(18, 107)
    Me.LabelSC.Name = "LabelSC"
    Me.LabelSC.Size = New System.Drawing.Size(25, 15)
    Me.LabelSC.TabIndex = 199
    Me.LabelSC.Text = "SC"
    '
    'LblDiscountVal
    '
    Me.LblDiscountVal.BackColor = System.Drawing.Color.AliceBlue
    Me.LblDiscountVal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LblDiscountVal.ForeColor = System.Drawing.Color.Maroon
    Me.LblDiscountVal.Location = New System.Drawing.Point(302, 61)
    Me.LblDiscountVal.Name = "LblDiscountVal"
    Me.LblDiscountVal.Size = New System.Drawing.Size(167, 26)
    Me.LblDiscountVal.TabIndex = 198
    Me.LblDiscountVal.Text = "0"
    Me.LblDiscountVal.TextAlign = System.Drawing.ContentAlignment.MiddleRight
    '
    'LabelDiscount
    '
    Me.LabelDiscount.AutoSize = True
    Me.LabelDiscount.BackColor = System.Drawing.Color.AliceBlue
    Me.LabelDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.LabelDiscount.ForeColor = System.Drawing.Color.Maroon
    Me.LabelDiscount.Location = New System.Drawing.Point(18, 69)
    Me.LabelDiscount.Name = "LabelDiscount"
    Me.LabelDiscount.Size = New System.Drawing.Size(77, 15)
    Me.LabelDiscount.TabIndex = 197
    Me.LabelDiscount.Text = "DISCOUNT"
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.BackColor = System.Drawing.Color.AliceBlue
    Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label3.ForeColor = System.Drawing.Color.Maroon
    Me.Label3.Location = New System.Drawing.Point(141, 16)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(200, 24)
    Me.Label3.TabIndex = 196
    Me.Label3.Text = "Invoice - Bill Section"
    '
    'IdFromInvoiceList
    '
    Me.IdFromInvoiceList.Location = New System.Drawing.Point(12, 7)
    Me.IdFromInvoiceList.Name = "IdFromInvoiceList"
    Me.IdFromInvoiceList.Size = New System.Drawing.Size(100, 20)
    Me.IdFromInvoiceList.TabIndex = 6
    '
    'LabelTest
    '
    Me.LabelTest.BackColor = System.Drawing.Color.Gainsboro
    Me.LabelTest.Location = New System.Drawing.Point(133, 4)
    Me.LabelTest.Name = "LabelTest"
    Me.LabelTest.Size = New System.Drawing.Size(43, 23)
    Me.LabelTest.TabIndex = 7
    '
    'TextBox2
    '
    Me.TextBox2.Location = New System.Drawing.Point(231, 6)
    Me.TextBox2.Name = "TextBox2"
    Me.TextBox2.Size = New System.Drawing.Size(100, 20)
    Me.TextBox2.TabIndex = 8
    '
    'ListPictureCustDispl
    '
    Me.ListPictureCustDispl.FormattingEnabled = True
    Me.ListPictureCustDispl.Location = New System.Drawing.Point(797, 115)
    Me.ListPictureCustDispl.Name = "ListPictureCustDispl"
    Me.ListPictureCustDispl.Size = New System.Drawing.Size(120, 95)
    Me.ListPictureCustDispl.TabIndex = 9
    '
    'Form_Custm_Display_MakeBill
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.AliceBlue
    Me.ClientSize = New System.Drawing.Size(1350, 730)
    Me.ControlBox = False
    Me.Controls.Add(Me.TextBox2)
    Me.Controls.Add(Me.LabelTest)
    Me.Controls.Add(Me.IdFromInvoiceList)
    Me.Controls.Add(Me.GroupMakeBill)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.GroupBoxSBITM)
    Me.Controls.Add(Me.OrderDetail)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.ListPictureCustDispl)
    Me.MaximizeBox = False
    Me.MinimizeBox = False
    Me.Name = "Form_Custm_Display_MakeBill"
    Me.ShowIcon = False
    Me.ShowInTaskbar = False
    Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
    Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
    CType(Me.OrderDetail, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupBoxSBITM.ResumeLayout(False)
    Me.GroupBoxSBITM.PerformLayout()
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.GroupMakeBill.ResumeLayout(False)
    Me.GroupMakeBill.PerformLayout()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Public WithEvents OrderDetail As C1.Win.C1FlexGrid.C1FlexGrid
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents TimerCustDisplay As System.Windows.Forms.Timer
  Friend WithEvents GroupBoxSBITM As System.Windows.Forms.GroupBox
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents lblTotalItem As System.Windows.Forms.Label
  Friend WithEvents Label16 As System.Windows.Forms.Label
  Friend WithEvents SubTotalTxt As System.Windows.Forms.Label
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents TimerPicture As System.Windows.Forms.Timer
  Friend WithEvents GroupMakeBill As System.Windows.Forms.GroupBox
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents LabelDiscount As System.Windows.Forms.Label
  Friend WithEvents LblDiscountVal As System.Windows.Forms.Label
  Friend WithEvents LabelSC As System.Windows.Forms.Label
  Friend WithEvents LabelSCVal As System.Windows.Forms.Label
  Friend WithEvents LabelDP As System.Windows.Forms.Label
  Friend WithEvents LabelPB As System.Windows.Forms.Label
  Friend WithEvents LabelROUND As System.Windows.Forms.Label
  Friend WithEvents LabelTOTAKH As System.Windows.Forms.Label
  Friend WithEvents LabelPBVal As System.Windows.Forms.Label
  Friend WithEvents LabelDPVal As System.Windows.Forms.Label
  Friend WithEvents LabelTAVal As System.Windows.Forms.Label
  Friend WithEvents LabelRoundVal As System.Windows.Forms.Label
  Friend WithEvents IdFromInvoiceList As System.Windows.Forms.TextBox
  Friend WithEvents LabelTest As System.Windows.Forms.Label
  Friend WithEvents TextBox2 As System.Windows.Forms.TextBox
  Friend WithEvents ListPictureCustDispl As System.Windows.Forms.ListBox
End Class
