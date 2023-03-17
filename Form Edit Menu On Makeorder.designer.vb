<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Edit_menu_On_MakeOrder
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Edit_menu_On_MakeOrder))
        Me.GroupBox = New System.Windows.Forms.GroupBox
        Me.cmdSimpan = New C1.Win.C1Input.C1Button
        Me.cmdKeyboardNamaMenu = New C1.Win.C1Input.C1Button
        Me.txtNamaMenu = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.txtHarga = New System.Windows.Forms.TextBox
        Me.cmdCalcPrice = New C1.Win.C1Input.C1Button
        Me.QuantityLabel = New System.Windows.Forms.Label
        Me.BTNNo = New C1.Win.C1Input.C1Button
        Me.BTNYes = New C1.Win.C1Input.C1Button
        Me.GroupBox.SuspendLayout()
        Me.SuspendLayout()
        '
        'GroupBox
        '
        Me.GroupBox.Controls.Add(Me.cmdSimpan)
        Me.GroupBox.Controls.Add(Me.cmdKeyboardNamaMenu)
        Me.GroupBox.Controls.Add(Me.txtNamaMenu)
        Me.GroupBox.Controls.Add(Me.Label1)
        Me.GroupBox.Controls.Add(Me.txtHarga)
        Me.GroupBox.Controls.Add(Me.cmdCalcPrice)
        Me.GroupBox.Controls.Add(Me.QuantityLabel)
        Me.GroupBox.Controls.Add(Me.BTNNo)
        Me.GroupBox.Controls.Add(Me.BTNYes)
        Me.GroupBox.Location = New System.Drawing.Point(10, 6)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(550, 200)
        Me.GroupBox.TabIndex = 9
        Me.GroupBox.TabStop = False
        '
        'cmdSimpan
        '
        Me.cmdSimpan.Cursor = System.Windows.Forms.Cursors.Hand
        Me.cmdSimpan.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdSimpan.Image = CType(resources.GetObject("cmdSimpan.Image"), System.Drawing.Image)
        Me.cmdSimpan.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdSimpan.Location = New System.Drawing.Point(117, 133)
        Me.cmdSimpan.Name = "cmdSimpan"
        Me.cmdSimpan.Size = New System.Drawing.Size(162, 44)
        Me.cmdSimpan.TabIndex = 104
        Me.cmdSimpan.Text = "Save"
        Me.cmdSimpan.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdSimpan.UseVisualStyleBackColor = True
        Me.cmdSimpan.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'cmdKeyboardNamaMenu
        '
        Me.cmdKeyboardNamaMenu.Image = CType(resources.GetObject("cmdKeyboardNamaMenu.Image"), System.Drawing.Image)
        Me.cmdKeyboardNamaMenu.Location = New System.Drawing.Point(484, 15)
        Me.cmdKeyboardNamaMenu.Name = "cmdKeyboardNamaMenu"
        Me.cmdKeyboardNamaMenu.Size = New System.Drawing.Size(52, 31)
        Me.cmdKeyboardNamaMenu.TabIndex = 103
        Me.cmdKeyboardNamaMenu.UseVisualStyleBackColor = True
        Me.cmdKeyboardNamaMenu.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'txtNamaMenu
        '
        Me.txtNamaMenu.BackColor = System.Drawing.Color.White
        Me.txtNamaMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaMenu.Location = New System.Drawing.Point(133, 19)
        Me.txtNamaMenu.MaxLength = 40
        Me.txtNamaMenu.Name = "txtNamaMenu"
        Me.txtNamaMenu.Size = New System.Drawing.Size(345, 26)
        Me.txtNamaMenu.TabIndex = 102
        '
        'Label1
        '
        Me.Label1.BackColor = System.Drawing.Color.AliceBlue
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.Label1.Location = New System.Drawing.Point(22, 22)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(105, 25)
        Me.Label1.TabIndex = 101
        Me.Label1.Text = "Menu Name"
        '
        'txtHarga
        '
        Me.txtHarga.BackColor = System.Drawing.Color.White
        Me.txtHarga.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtHarga.Location = New System.Drawing.Point(133, 67)
        Me.txtHarga.MaxLength = 3
        Me.txtHarga.Name = "txtHarga"
        Me.txtHarga.Size = New System.Drawing.Size(146, 26)
        Me.txtHarga.TabIndex = 100
        Me.txtHarga.Text = "1"
        Me.txtHarga.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdCalcPrice
        '
        Me.cmdCalcPrice.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCalcPrice.Image = CType(resources.GetObject("cmdCalcPrice.Image"), System.Drawing.Image)
        Me.cmdCalcPrice.Location = New System.Drawing.Point(285, 63)
        Me.cmdCalcPrice.Name = "cmdCalcPrice"
        Me.cmdCalcPrice.Size = New System.Drawing.Size(50, 32)
        Me.cmdCalcPrice.TabIndex = 99
        Me.cmdCalcPrice.UseVisualStyleBackColor = True
        Me.cmdCalcPrice.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'QuantityLabel
        '
        Me.QuantityLabel.BackColor = System.Drawing.Color.AliceBlue
        Me.QuantityLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.QuantityLabel.ForeColor = System.Drawing.Color.FromArgb(CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer), CType(CType(64, Byte), Integer))
        Me.QuantityLabel.Location = New System.Drawing.Point(22, 70)
        Me.QuantityLabel.Name = "QuantityLabel"
        Me.QuantityLabel.Size = New System.Drawing.Size(93, 25)
        Me.QuantityLabel.TabIndex = 3
        Me.QuantityLabel.Text = "Price"
        '
        'BTNNo
        '
        Me.BTNNo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTNNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNNo.Image = CType(resources.GetObject("BTNNo.Image"), System.Drawing.Image)
        Me.BTNNo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNNo.Location = New System.Drawing.Point(298, 133)
        Me.BTNNo.Name = "BTNNo"
        Me.BTNNo.Size = New System.Drawing.Size(143, 44)
        Me.BTNNo.TabIndex = 1
        Me.BTNNo.Tag = ""
        Me.BTNNo.Text = "Cancel"
        Me.BTNNo.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNNo.UseVisualStyleBackColor = True
        Me.BTNNo.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNYes
        '
        Me.BTNYes.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTNYes.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNYes.Image = CType(resources.GetObject("BTNYes.Image"), System.Drawing.Image)
        Me.BTNYes.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNYes.Location = New System.Drawing.Point(236, 215)
        Me.BTNYes.Name = "BTNYes"
        Me.BTNYes.Size = New System.Drawing.Size(105, 38)
        Me.BTNYes.TabIndex = 0
        Me.BTNYes.Tag = ""
        Me.BTNYes.Text = "Yes"
        Me.BTNYes.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNYes.UseVisualStyleBackColor = True
        Me.BTNYes.Visible = False
        Me.BTNYes.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Form_Edit_menu_On_MakeOrder
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(572, 217)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Edit_menu_On_MakeOrder"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Input Price"
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents QuantityLabel As System.Windows.Forms.Label
    Friend WithEvents BTNNo As C1.Win.C1Input.C1Button
    Friend WithEvents BTNYes As C1.Win.C1Input.C1Button
    Friend WithEvents txtHarga As System.Windows.Forms.TextBox
    Friend WithEvents cmdCalcPrice As C1.Win.C1Input.C1Button
    Friend WithEvents txtNamaMenu As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents cmdKeyboardNamaMenu As C1.Win.C1Input.C1Button
    Friend WithEvents cmdSimpan As C1.Win.C1Input.C1Button
End Class
