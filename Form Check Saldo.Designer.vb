<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Check_Saldo
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
    Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Check_Saldo))
    Me.TmrNFC = New System.Windows.Forms.Timer(Me.components)
    Me.DetailPurchase = New C1.Win.C1FlexGrid.C1FlexGrid
    Me.JmSld = New System.Windows.Forms.Label
    Me.lblSaldo = New System.Windows.Forms.Label
    Me.LblInfoKartu = New System.Windows.Forms.Label
    Me.Label1 = New System.Windows.Forms.Label
    Me.Label2 = New System.Windows.Forms.Label
    Me.Label3 = New System.Windows.Forms.Label
    Me.Label4 = New System.Windows.Forms.Label
    Me.btnVirtualFromDate = New C1.Win.C1Input.C1Button
    Me.btnVirtualFromDate1 = New C1.Win.C1Input.C1Button
    Me.dtFromDate = New System.Windows.Forms.DateTimePicker
    Me.ConvertDate1 = New System.Windows.Forms.TextBox
    Me.ConvertDate2 = New System.Windows.Forms.TextBox
    Me.BTNPrint = New C1.Win.C1Input.C1Button
    Me.BTNCancel = New C1.Win.C1Input.C1Button
    Me.dtEndDate = New System.Windows.Forms.DateTimePicker
    Me.TempCardno = New System.Windows.Forms.TextBox
    Me.Button1 = New System.Windows.Forms.Button
    Me.Label5 = New System.Windows.Forms.Label
    Me.Label6 = New System.Windows.Forms.Label
    Me.Button2 = New System.Windows.Forms.Button
    Me.TempCardScnd = New System.Windows.Forms.TextBox
    CType(Me.DetailPurchase, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'TmrNFC
    '
    Me.TmrNFC.Enabled = True
    Me.TmrNFC.Interval = 2000
    '
    'DetailPurchase
    '
    Me.DetailPurchase.AllowDragging = C1.Win.C1FlexGrid.AllowDraggingEnum.None
    Me.DetailPurchase.AllowResizing = C1.Win.C1FlexGrid.AllowResizingEnum.None
    Me.DetailPurchase.BorderStyle = C1.Win.C1FlexGrid.Util.BaseControls.BorderStyleEnum.None
    Me.DetailPurchase.ColumnInfo = resources.GetString("DetailPurchase.ColumnInfo")
    Me.DetailPurchase.ExtendLastCol = True
    Me.DetailPurchase.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.DetailPurchase.Location = New System.Drawing.Point(12, 186)
    Me.DetailPurchase.Name = "DetailPurchase"
    Me.DetailPurchase.Rows.Count = 1
    Me.DetailPurchase.Rows.DefaultSize = 18
    Me.DetailPurchase.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.RowRange
    Me.DetailPurchase.Size = New System.Drawing.Size(647, 344)
    Me.DetailPurchase.StyleInfo = resources.GetString("DetailPurchase.StyleInfo")
    Me.DetailPurchase.TabIndex = 137
    Me.DetailPurchase.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
    '
    'JmSld
    '
    Me.JmSld.AutoSize = True
    Me.JmSld.Location = New System.Drawing.Point(44, 85)
    Me.JmSld.Name = "JmSld"
    Me.JmSld.Size = New System.Drawing.Size(70, 13)
    Me.JmSld.TabIndex = 138
    Me.JmSld.Text = "Jumlah Saldo"
    '
    'lblSaldo
    '
    Me.lblSaldo.BackColor = System.Drawing.Color.AliceBlue
    Me.lblSaldo.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.lblSaldo.ForeColor = System.Drawing.Color.Red
    Me.lblSaldo.Location = New System.Drawing.Point(347, 84)
    Me.lblSaldo.Name = "lblSaldo"
    Me.lblSaldo.Size = New System.Drawing.Size(136, 30)
    Me.lblSaldo.TabIndex = 139
    Me.lblSaldo.Text = "-"
    Me.lblSaldo.TextAlign = System.Drawing.ContentAlignment.TopRight
    '
    'LblInfoKartu
    '
    Me.LblInfoKartu.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.LblInfoKartu.Location = New System.Drawing.Point(15, 9)
    Me.LblInfoKartu.Name = "LblInfoKartu"
    Me.LblInfoKartu.Size = New System.Drawing.Size(647, 55)
    Me.LblInfoKartu.TabIndex = 140
    '
    'Label1
    '
    Me.Label1.AutoSize = True
    Me.Label1.Location = New System.Drawing.Point(51, 141)
    Me.Label1.Name = "Label1"
    Me.Label1.Size = New System.Drawing.Size(63, 13)
    Me.Label1.TabIndex = 141
    Me.Label1.Text = "1 May 2010"
    '
    'Label2
    '
    Me.Label2.AutoSize = True
    Me.Label2.Location = New System.Drawing.Point(355, 138)
    Me.Label2.Name = "Label2"
    Me.Label2.Size = New System.Drawing.Size(63, 13)
    Me.Label2.TabIndex = 142
    Me.Label2.Text = "1 May 2010"
    Me.Label2.Visible = False
    '
    'Label3
    '
    Me.Label3.AutoSize = True
    Me.Label3.Location = New System.Drawing.Point(12, 140)
    Me.Label3.Name = "Label3"
    Me.Label3.Size = New System.Drawing.Size(33, 13)
    Me.Label3.TabIndex = 143
    Me.Label3.Text = "Date "
    '
    'Label4
    '
    Me.Label4.AutoSize = True
    Me.Label4.Location = New System.Drawing.Point(287, 138)
    Me.Label4.Name = "Label4"
    Me.Label4.Size = New System.Drawing.Size(52, 13)
    Me.Label4.TabIndex = 144
    Me.Label4.Text = "End Date"
    Me.Label4.Visible = False
    '
    'btnVirtualFromDate
    '
    Me.btnVirtualFromDate.Image = CType(resources.GetObject("btnVirtualFromDate.Image"), System.Drawing.Image)
    Me.btnVirtualFromDate.Location = New System.Drawing.Point(143, 132)
    Me.btnVirtualFromDate.Name = "btnVirtualFromDate"
    Me.btnVirtualFromDate.Size = New System.Drawing.Size(50, 30)
    Me.btnVirtualFromDate.TabIndex = 145
    Me.btnVirtualFromDate.UseVisualStyleBackColor = True
    Me.btnVirtualFromDate.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'btnVirtualFromDate1
    '
    Me.btnVirtualFromDate1.Image = CType(resources.GetObject("btnVirtualFromDate1.Image"), System.Drawing.Image)
    Me.btnVirtualFromDate1.Location = New System.Drawing.Point(449, 129)
    Me.btnVirtualFromDate1.Name = "btnVirtualFromDate1"
    Me.btnVirtualFromDate1.Size = New System.Drawing.Size(50, 30)
    Me.btnVirtualFromDate1.TabIndex = 146
    Me.btnVirtualFromDate1.UseVisualStyleBackColor = True
    Me.btnVirtualFromDate1.Visible = False
    Me.btnVirtualFromDate1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'dtFromDate
    '
    Me.dtFromDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.dtFromDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtFromDate.Location = New System.Drawing.Point(158, 133)
    Me.dtFromDate.Name = "dtFromDate"
    Me.dtFromDate.Size = New System.Drawing.Size(22, 22)
    Me.dtFromDate.TabIndex = 147
    Me.dtFromDate.Visible = False
    '
    'ConvertDate1
    '
    Me.ConvertDate1.Location = New System.Drawing.Point(461, 137)
    Me.ConvertDate1.Name = "ConvertDate1"
    Me.ConvertDate1.Size = New System.Drawing.Size(22, 20)
    Me.ConvertDate1.TabIndex = 150
    Me.ConvertDate1.Visible = False
    '
    'ConvertDate2
    '
    Me.ConvertDate2.Location = New System.Drawing.Point(461, 137)
    Me.ConvertDate2.Name = "ConvertDate2"
    Me.ConvertDate2.Size = New System.Drawing.Size(22, 20)
    Me.ConvertDate2.TabIndex = 151
    Me.ConvertDate2.Visible = False
    '
    'BTNPrint
    '
    Me.BTNPrint.Enabled = False
    Me.BTNPrint.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BTNPrint.Image = CType(resources.GetObject("BTNPrint.Image"), System.Drawing.Image)
    Me.BTNPrint.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BTNPrint.Location = New System.Drawing.Point(461, 536)
    Me.BTNPrint.Name = "BTNPrint"
    Me.BTNPrint.Size = New System.Drawing.Size(95, 31)
    Me.BTNPrint.TabIndex = 152
    Me.BTNPrint.Text = "Print"
    Me.BTNPrint.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BTNPrint.UseVisualStyleBackColor = True
    Me.BTNPrint.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'BTNCancel
    '
    Me.BTNCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.BTNCancel.Image = CType(resources.GetObject("BTNCancel.Image"), System.Drawing.Image)
    Me.BTNCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.BTNCancel.Location = New System.Drawing.Point(567, 536)
    Me.BTNCancel.Name = "BTNCancel"
    Me.BTNCancel.Size = New System.Drawing.Size(95, 31)
    Me.BTNCancel.TabIndex = 153
    Me.BTNCancel.Text = "Close"
    Me.BTNCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.BTNCancel.UseVisualStyleBackColor = True
    Me.BTNCancel.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
    '
    'dtEndDate
    '
    Me.dtEndDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.dtEndDate.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
    Me.dtEndDate.Location = New System.Drawing.Point(461, 133)
    Me.dtEndDate.Name = "dtEndDate"
    Me.dtEndDate.Size = New System.Drawing.Size(22, 22)
    Me.dtEndDate.TabIndex = 154
    Me.dtEndDate.Visible = False
    '
    'TempCardno
    '
    Me.TempCardno.Location = New System.Drawing.Point(370, 27)
    Me.TempCardno.Name = "TempCardno"
    Me.TempCardno.Size = New System.Drawing.Size(100, 20)
    Me.TempCardno.TabIndex = 156
    Me.TempCardno.Visible = False
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(370, 25)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(75, 23)
    Me.Button1.TabIndex = 157
    Me.Button1.Text = "Button1"
    Me.Button1.UseVisualStyleBackColor = True
    Me.Button1.Visible = False
    '
    'Label5
    '
    Me.Label5.AutoSize = True
    Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
    Me.Label5.Location = New System.Drawing.Point(12, 170)
    Me.Label5.Name = "Label5"
    Me.Label5.Size = New System.Drawing.Size(97, 13)
    Me.Label5.TabIndex = 158
    Me.Label5.Text = "Detail Purchase"
    '
    'Label6
    '
    Me.Label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
    Me.Label6.Location = New System.Drawing.Point(12, 533)
    Me.Label6.Name = "Label6"
    Me.Label6.Size = New System.Drawing.Size(436, 31)
    Me.Label6.TabIndex = 159
    Me.Label6.Text = "Note : Please Click to Payment Number section , to choose wich you gonna print, a" & _
        "nd then click Print button in the rigth ==>, By default it wil print all your tr" & _
        "ansaction per date."
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(347, 25)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(75, 23)
    Me.Button2.TabIndex = 160
    Me.Button2.Text = "Button2"
    Me.Button2.UseVisualStyleBackColor = True
    Me.Button2.Visible = False
    '
    'TempCardScnd
    '
    Me.TempCardScnd.Location = New System.Drawing.Point(541, 94)
    Me.TempCardScnd.Name = "TempCardScnd"
    Me.TempCardScnd.Size = New System.Drawing.Size(100, 20)
    Me.TempCardScnd.TabIndex = 161
    Me.TempCardScnd.Visible = False
    '
    'Form_Check_Saldo
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.BackColor = System.Drawing.Color.AliceBlue
    Me.ClientSize = New System.Drawing.Size(670, 573)
    Me.Controls.Add(Me.Label6)
    Me.Controls.Add(Me.Label5)
    Me.Controls.Add(Me.btnVirtualFromDate1)
    Me.Controls.Add(Me.btnVirtualFromDate)
    Me.Controls.Add(Me.dtEndDate)
    Me.Controls.Add(Me.BTNCancel)
    Me.Controls.Add(Me.BTNPrint)
    Me.Controls.Add(Me.ConvertDate2)
    Me.Controls.Add(Me.ConvertDate1)
    Me.Controls.Add(Me.dtFromDate)
    Me.Controls.Add(Me.Label4)
    Me.Controls.Add(Me.Label3)
    Me.Controls.Add(Me.Label2)
    Me.Controls.Add(Me.Label1)
    Me.Controls.Add(Me.LblInfoKartu)
    Me.Controls.Add(Me.lblSaldo)
    Me.Controls.Add(Me.JmSld)
    Me.Controls.Add(Me.DetailPurchase)
    Me.Controls.Add(Me.TempCardScnd)
    Me.Controls.Add(Me.TempCardno)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.Button2)
    Me.Name = "Form_Check_Saldo"
    Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
    Me.Text = "Form Check Saldo"
    CType(Me.DetailPurchase, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents TmrNFC As System.Windows.Forms.Timer
  Friend WithEvents DetailPurchase As C1.Win.C1FlexGrid.C1FlexGrid
  Friend WithEvents JmSld As System.Windows.Forms.Label
  Friend WithEvents lblSaldo As System.Windows.Forms.Label
  Friend WithEvents LblInfoKartu As System.Windows.Forms.Label
  Friend WithEvents Label1 As System.Windows.Forms.Label
  Friend WithEvents Label2 As System.Windows.Forms.Label
  Friend WithEvents Label3 As System.Windows.Forms.Label
  Friend WithEvents Label4 As System.Windows.Forms.Label
  Friend WithEvents btnVirtualFromDate As C1.Win.C1Input.C1Button
  Friend WithEvents btnVirtualFromDate1 As C1.Win.C1Input.C1Button
  Friend WithEvents dtFromDate As System.Windows.Forms.DateTimePicker
  Friend WithEvents ConvertDate1 As System.Windows.Forms.TextBox
  Friend WithEvents ConvertDate2 As System.Windows.Forms.TextBox
  Friend WithEvents BTNPrint As C1.Win.C1Input.C1Button
  Friend WithEvents BTNCancel As C1.Win.C1Input.C1Button
  Friend WithEvents dtEndDate As System.Windows.Forms.DateTimePicker
  Friend WithEvents TempCardno As System.Windows.Forms.TextBox
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents Label5 As System.Windows.Forms.Label
  Friend WithEvents Label6 As System.Windows.Forms.Label
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents TempCardScnd As System.Windows.Forms.TextBox
End Class
