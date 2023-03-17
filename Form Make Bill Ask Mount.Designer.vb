<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Make_Bill_Ask_Mount
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Make_Bill_Ask_Mount))
        Me.MountValueTxt = New C1.Win.C1Input.C1NumericEdit
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BTNClose = New C1.Win.C1Input.C1Button
        Me.BTNOK = New C1.Win.C1Input.C1Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.LabelPercent = New System.Windows.Forms.Label
        CType(Me.MountValueTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'MountValueTxt
        '
        Me.MountValueTxt.AutoSize = False
        Me.MountValueTxt.BackColor = System.Drawing.Color.White
        Me.MountValueTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.MountValueTxt.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.MountValueTxt.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.MountValueTxt.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.MountValueTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.MountValueTxt.Location = New System.Drawing.Point(91, 20)
        Me.MountValueTxt.MaxLength = 20
        Me.MountValueTxt.Name = "MountValueTxt"
        Me.MountValueTxt.Size = New System.Drawing.Size(242, 28)
        Me.MountValueTxt.TabIndex = 2
        Me.MountValueTxt.Tag = Nothing
        Me.MountValueTxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        Me.MountValueTxt.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.MountValueTxt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(10, 25)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(73, 13)
        Me.Label2.TabIndex = 11
        Me.Label2.Text = "Amount Value"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(325, 31)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(20, 16)
        Me.Label1.TabIndex = 73
        Me.Label1.Text = "%"
        '
        'BTNClose
        '
        Me.BTNClose.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTNClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNClose.Image = CType(resources.GetObject("BTNClose.Image"), System.Drawing.Image)
        Me.BTNClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNClose.Location = New System.Drawing.Point(213, 67)
        Me.BTNClose.Name = "BTNClose"
        Me.BTNClose.Size = New System.Drawing.Size(120, 40)
        Me.BTNClose.TabIndex = 75
        Me.BTNClose.Tag = ""
        Me.BTNClose.Text = "Cancel"
        Me.BTNClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNClose.UseVisualStyleBackColor = True
        Me.BTNClose.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNOK
        '
        Me.BTNOK.Cursor = System.Windows.Forms.Cursors.Hand
        Me.BTNOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNOK.Image = CType(resources.GetObject("BTNOK.Image"), System.Drawing.Image)
        Me.BTNOK.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNOK.Location = New System.Drawing.Point(89, 67)
        Me.BTNOK.Name = "BTNOK"
        Me.BTNOK.Size = New System.Drawing.Size(120, 40)
        Me.BTNOK.TabIndex = 74
        Me.BTNOK.Tag = ""
        Me.BTNOK.Text = "OK"
        Me.BTNOK.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNOK.UseVisualStyleBackColor = True
        Me.BTNOK.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.LabelPercent)
        Me.GroupBox1.Controls.Add(Me.BTNClose)
        Me.GroupBox1.Controls.Add(Me.BTNOK)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.MountValueTxt)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(385, 125)
        Me.GroupBox1.TabIndex = 76
        Me.GroupBox1.TabStop = False
        '
        'LabelPercent
        '
        Me.LabelPercent.AutoSize = True
        Me.LabelPercent.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelPercent.Location = New System.Drawing.Point(338, 21)
        Me.LabelPercent.Name = "LabelPercent"
        Me.LabelPercent.Size = New System.Drawing.Size(37, 24)
        Me.LabelPercent.TabIndex = 76
        Me.LabelPercent.Text = "(%)"
        Me.LabelPercent.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Form_Make_Bill_Ask_Mount
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(414, 143)
        Me.ControlBox = False
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.Label1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Make_Bill_Ask_Mount"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Ask Amount"
        CType(Me.MountValueTxt, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents MountValueTxt As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTNClose As C1.Win.C1Input.C1Button
    Friend WithEvents BTNOK As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents LabelPercent As System.Windows.Forms.Label
End Class
