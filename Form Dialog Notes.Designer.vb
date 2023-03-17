<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Dialog_Notes
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Dialog_Notes))
        Me.BTNSave = New C1.Win.C1Input.C1Button
        Me.BTNClose = New C1.Win.C1Input.C1Button
        Me.VirtualKey = New C1.Win.C1Input.C1Button
        Me.NotesTxt = New System.Windows.Forms.TextBox
        Me.BTNClear = New C1.Win.C1Input.C1Button
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.GroupBox1.SuspendLayout()
        Me.SuspendLayout()
        '
        'BTNSave
        '
        Me.BTNSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSave.Image = CType(resources.GetObject("BTNSave.Image"), System.Drawing.Image)
        Me.BTNSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNSave.Location = New System.Drawing.Point(323, 236)
        Me.BTNSave.Name = "BTNSave"
        Me.BTNSave.Size = New System.Drawing.Size(91, 43)
        Me.BTNSave.TabIndex = 3
        Me.BTNSave.Text = "Save"
        Me.BTNSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNSave.UseVisualStyleBackColor = True
        Me.BTNSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNClose
        '
        Me.BTNClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNClose.Image = CType(resources.GetObject("BTNClose.Image"), System.Drawing.Image)
        Me.BTNClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNClose.Location = New System.Drawing.Point(420, 236)
        Me.BTNClose.Name = "BTNClose"
        Me.BTNClose.Size = New System.Drawing.Size(91, 43)
        Me.BTNClose.TabIndex = 4
        Me.BTNClose.Text = "Close"
        Me.BTNClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNClose.UseVisualStyleBackColor = True
        Me.BTNClose.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'VirtualKey
        '
        Me.VirtualKey.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.VirtualKey.Image = CType(resources.GetObject("VirtualKey.Image"), System.Drawing.Image)
        Me.VirtualKey.Location = New System.Drawing.Point(459, 16)
        Me.VirtualKey.Name = "VirtualKey"
        Me.VirtualKey.Size = New System.Drawing.Size(50, 40)
        Me.VirtualKey.TabIndex = 2
        Me.VirtualKey.UseVisualStyleBackColor = True
        Me.VirtualKey.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'NotesTxt
        '
        Me.NotesTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.NotesTxt.Location = New System.Drawing.Point(11, 16)
        Me.NotesTxt.Multiline = True
        Me.NotesTxt.Name = "NotesTxt"
        Me.NotesTxt.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.NotesTxt.Size = New System.Drawing.Size(438, 213)
        Me.NotesTxt.TabIndex = 0
        '
        'BTNClear
        '
        Me.BTNClear.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNClear.Image = CType(resources.GetObject("BTNClear.Image"), System.Drawing.Image)
        Me.BTNClear.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNClear.Location = New System.Drawing.Point(11, 235)
        Me.BTNClear.Name = "BTNClear"
        Me.BTNClear.Size = New System.Drawing.Size(91, 43)
        Me.BTNClear.TabIndex = 6
        Me.BTNClear.Text = "Clear"
        Me.BTNClear.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNClear.UseVisualStyleBackColor = True
        Me.BTNClear.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.BTNClear)
        Me.GroupBox1.Controls.Add(Me.BTNClose)
        Me.GroupBox1.Controls.Add(Me.NotesTxt)
        Me.GroupBox1.Controls.Add(Me.BTNSave)
        Me.GroupBox1.Controls.Add(Me.VirtualKey)
        Me.GroupBox1.Location = New System.Drawing.Point(8, 3)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(520, 287)
        Me.GroupBox1.TabIndex = 7
        Me.GroupBox1.TabStop = False
        '
        'Dialog_Notes
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(538, 298)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Dialog_Notes"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Dialog Notes"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents BTNSave As C1.Win.C1Input.C1Button
    Friend WithEvents BTNClose As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualKey As C1.Win.C1Input.C1Button
    Friend WithEvents NotesTxt As System.Windows.Forms.TextBox
    Friend WithEvents BTNClear As C1.Win.C1Input.C1Button
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
End Class
