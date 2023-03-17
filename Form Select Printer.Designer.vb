<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Select_Printer
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Select_Printer))
        Me.chkLocalPrinter = New System.Windows.Forms.CheckBox
        Me.chkKitchenPrinter = New System.Windows.Forms.CheckBox
        Me.BTNNo = New C1.Win.C1Input.C1Button
        Me.BTNYes = New C1.Win.C1Input.C1Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.picBoxKitchen = New System.Windows.Forms.PictureBox
        Me.picBoxLocal = New System.Windows.Forms.PictureBox
        Me.picBoxKitchenOff = New System.Windows.Forms.PictureBox
        Me.picBoxKitchenOn = New System.Windows.Forms.PictureBox
        Me.picBoxLocalOn = New System.Windows.Forms.PictureBox
        Me.picBoxLocalOff = New System.Windows.Forms.PictureBox
        Me.GroupBox1.SuspendLayout()
        CType(Me.picBoxKitchen, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxLocal, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxKitchenOff, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxKitchenOn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxLocalOn, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.picBoxLocalOff, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'chkLocalPrinter
        '
        Me.chkLocalPrinter.AutoSize = True
        Me.chkLocalPrinter.Checked = True
        Me.chkLocalPrinter.CheckState = System.Windows.Forms.CheckState.Checked
        Me.chkLocalPrinter.Location = New System.Drawing.Point(114, 217)
        Me.chkLocalPrinter.Name = "chkLocalPrinter"
        Me.chkLocalPrinter.Size = New System.Drawing.Size(85, 17)
        Me.chkLocalPrinter.TabIndex = 0
        Me.chkLocalPrinter.Text = "Local Printer"
        Me.chkLocalPrinter.UseVisualStyleBackColor = True
        Me.chkLocalPrinter.Visible = False
        '
        'chkKitchenPrinter
        '
        Me.chkKitchenPrinter.AutoSize = True
        Me.chkKitchenPrinter.Location = New System.Drawing.Point(229, 217)
        Me.chkKitchenPrinter.Name = "chkKitchenPrinter"
        Me.chkKitchenPrinter.Size = New System.Drawing.Size(95, 17)
        Me.chkKitchenPrinter.TabIndex = 1
        Me.chkKitchenPrinter.Text = "Kitchen Printer"
        Me.chkKitchenPrinter.UseVisualStyleBackColor = True
        Me.chkKitchenPrinter.Visible = False
        '
        'BTNNo
        '
        Me.BTNNo.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTNNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNNo.Image = CType(resources.GetObject("BTNNo.Image"), System.Drawing.Image)
        Me.BTNNo.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNNo.Location = New System.Drawing.Point(20, 135)
        Me.BTNNo.Name = "BTNNo"
        Me.BTNNo.Size = New System.Drawing.Size(123, 38)
        Me.BTNNo.TabIndex = 3
        Me.BTNNo.Tag = ""
        Me.BTNNo.Text = "No"
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
        Me.BTNYes.Location = New System.Drawing.Point(149, 135)
        Me.BTNYes.Name = "BTNYes"
        Me.BTNYes.Size = New System.Drawing.Size(139, 38)
        Me.BTNYes.TabIndex = 2
        Me.BTNYes.Tag = ""
        Me.BTNYes.Text = "Yes"
        Me.BTNYes.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNYes.UseVisualStyleBackColor = True
        Me.BTNYes.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Controls.Add(Me.picBoxKitchen)
        Me.GroupBox1.Controls.Add(Me.picBoxLocal)
        Me.GroupBox1.Controls.Add(Me.picBoxKitchenOff)
        Me.GroupBox1.Controls.Add(Me.picBoxKitchenOn)
        Me.GroupBox1.Controls.Add(Me.picBoxLocalOn)
        Me.GroupBox1.Controls.Add(Me.picBoxLocalOff)
        Me.GroupBox1.Controls.Add(Me.BTNNo)
        Me.GroupBox1.Controls.Add(Me.chkLocalPrinter)
        Me.GroupBox1.Controls.Add(Me.BTNYes)
        Me.GroupBox1.Controls.Add(Me.chkKitchenPrinter)
        Me.GroupBox1.Location = New System.Drawing.Point(12, 8)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(309, 192)
        Me.GroupBox1.TabIndex = 4
        Me.GroupBox1.TabStop = False
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label2.Location = New System.Drawing.Point(164, 24)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(116, 15)
        Me.Label2.TabIndex = 133
        Me.Label2.Text = "Kitchen Print-Out"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ForeColor = System.Drawing.Color.DodgerBlue
        Me.Label1.Location = New System.Drawing.Point(34, 24)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(89, 15)
        Me.Label1.TabIndex = 132
        Me.Label1.Text = "Local Printer"
        '
        'picBoxKitchen
        '
        Me.picBoxKitchen.Image = CType(resources.GetObject("picBoxKitchen.Image"), System.Drawing.Image)
        Me.picBoxKitchen.Location = New System.Drawing.Point(169, 43)
        Me.picBoxKitchen.Name = "picBoxKitchen"
        Me.picBoxKitchen.Size = New System.Drawing.Size(102, 68)
        Me.picBoxKitchen.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picBoxKitchen.TabIndex = 131
        Me.picBoxKitchen.TabStop = False
        '
        'picBoxLocal
        '
        Me.picBoxLocal.Image = CType(resources.GetObject("picBoxLocal.Image"), System.Drawing.Image)
        Me.picBoxLocal.Location = New System.Drawing.Point(47, 43)
        Me.picBoxLocal.Name = "picBoxLocal"
        Me.picBoxLocal.Size = New System.Drawing.Size(64, 64)
        Me.picBoxLocal.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picBoxLocal.TabIndex = 130
        Me.picBoxLocal.TabStop = False
        '
        'picBoxKitchenOff
        '
        Me.picBoxKitchenOff.Image = CType(resources.GetObject("picBoxKitchenOff.Image"), System.Drawing.Image)
        Me.picBoxKitchenOff.Location = New System.Drawing.Point(114, 249)
        Me.picBoxKitchenOff.Name = "picBoxKitchenOff"
        Me.picBoxKitchenOff.Size = New System.Drawing.Size(102, 68)
        Me.picBoxKitchenOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picBoxKitchenOff.TabIndex = 129
        Me.picBoxKitchenOff.TabStop = False
        '
        'picBoxKitchenOn
        '
        Me.picBoxKitchenOn.Image = CType(resources.GetObject("picBoxKitchenOn.Image"), System.Drawing.Image)
        Me.picBoxKitchenOn.Location = New System.Drawing.Point(229, 249)
        Me.picBoxKitchenOn.Name = "picBoxKitchenOn"
        Me.picBoxKitchenOn.Size = New System.Drawing.Size(102, 68)
        Me.picBoxKitchenOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picBoxKitchenOn.TabIndex = 128
        Me.picBoxKitchenOn.TabStop = False
        '
        'picBoxLocalOn
        '
        Me.picBoxLocalOn.Image = CType(resources.GetObject("picBoxLocalOn.Image"), System.Drawing.Image)
        Me.picBoxLocalOn.Location = New System.Drawing.Point(439, 249)
        Me.picBoxLocalOn.Name = "picBoxLocalOn"
        Me.picBoxLocalOn.Size = New System.Drawing.Size(64, 64)
        Me.picBoxLocalOn.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picBoxLocalOn.TabIndex = 127
        Me.picBoxLocalOn.TabStop = False
        '
        'picBoxLocalOff
        '
        Me.picBoxLocalOff.Image = CType(resources.GetObject("picBoxLocalOff.Image"), System.Drawing.Image)
        Me.picBoxLocalOff.Location = New System.Drawing.Point(353, 249)
        Me.picBoxLocalOff.Name = "picBoxLocalOff"
        Me.picBoxLocalOff.Size = New System.Drawing.Size(64, 64)
        Me.picBoxLocalOff.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize
        Me.picBoxLocalOff.TabIndex = 126
        Me.picBoxLocalOff.TabStop = False
        '
        'Form_Select_Printer
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(331, 211)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Select_Printer"
        Me.ShowIcon = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Select Printer Destination"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.picBoxKitchen, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxLocal, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxKitchenOff, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxKitchenOn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxLocalOn, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.picBoxLocalOff, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents chkLocalPrinter As System.Windows.Forms.CheckBox
    Friend WithEvents chkKitchenPrinter As System.Windows.Forms.CheckBox
    Friend WithEvents BTNNo As C1.Win.C1Input.C1Button
    Friend WithEvents BTNYes As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents picBoxLocalOff As System.Windows.Forms.PictureBox
    Friend WithEvents picBoxKitchenOff As System.Windows.Forms.PictureBox
    Friend WithEvents picBoxKitchenOn As System.Windows.Forms.PictureBox
    Friend WithEvents picBoxLocalOn As System.Windows.Forms.PictureBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents picBoxKitchen As System.Windows.Forms.PictureBox
    Friend WithEvents picBoxLocal As System.Windows.Forms.PictureBox
End Class
