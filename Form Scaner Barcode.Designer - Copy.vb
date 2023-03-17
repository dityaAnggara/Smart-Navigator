<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Scaner_Barcode
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Scaner_Barcode))
        Me.dtabUtama = New C1.Win.C1Command.C1DockingTab
        Me.txtBarcode = New System.Windows.Forms.TextBox
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.cmdClose = New C1.Win.C1Input.C1Button
        Me.VirtualKey = New C1.Win.C1Input.C1Button
        CType(Me.dtabUtama, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel1.SuspendLayout()
        Me.SuspendLayout()
        '
        'dtabUtama
        '
        Me.dtabUtama.Indent = 61
        Me.dtabUtama.Location = New System.Drawing.Point(3, 4)
        Me.dtabUtama.Name = "dtabUtama"
        Me.dtabUtama.Padding = New System.Drawing.Point(8, 5)
        Me.dtabUtama.SelectedTabBold = True
        Me.dtabUtama.Size = New System.Drawing.Size(477, 98)
        Me.dtabUtama.TabAreaSpacing = 3
        Me.dtabUtama.TabIndex = 249
        Me.dtabUtama.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.dtabUtama.TabsSpacing = 5
        Me.dtabUtama.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.dtabUtama.VisualStyle = C1.Win.C1Command.VisualStyle.Office2007Blue
        Me.dtabUtama.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
        '
        'txtBarcode
        '
        Me.txtBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtBarcode.Location = New System.Drawing.Point(5, 4)
        Me.txtBarcode.MaxLength = 0
        Me.txtBarcode.Name = "txtBarcode"
        Me.txtBarcode.Size = New System.Drawing.Size(401, 29)
        Me.txtBarcode.TabIndex = 250
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.txtBarcode)
        Me.Panel1.Location = New System.Drawing.Point(7, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(409, 37)
        Me.Panel1.TabIndex = 253
        '
        'cmdClose
        '
        Me.cmdClose.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdClose.Image = CType(resources.GetObject("cmdClose.Image"), System.Drawing.Image)
        Me.cmdClose.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdClose.Location = New System.Drawing.Point(12, 51)
        Me.cmdClose.Name = "cmdClose"
        Me.cmdClose.Size = New System.Drawing.Size(123, 42)
        Me.cmdClose.TabIndex = 254
        Me.cmdClose.Text = "Close"
        Me.cmdClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdClose.UseVisualStyleBackColor = True
        Me.cmdClose.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'VirtualKey
        '
        Me.VirtualKey.Image = CType(resources.GetObject("VirtualKey.Image"), System.Drawing.Image)
        Me.VirtualKey.Location = New System.Drawing.Point(419, 12)
        Me.VirtualKey.Name = "VirtualKey"
        Me.VirtualKey.Size = New System.Drawing.Size(50, 33)
        Me.VirtualKey.TabIndex = 255
        Me.VirtualKey.UseVisualStyleBackColor = True
        Me.VirtualKey.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Form_Scaner_Barcode
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(478, 101)
        Me.ControlBox = False
        Me.Controls.Add(Me.VirtualKey)
        Me.Controls.Add(Me.cmdClose)
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dtabUtama)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Scaner_Barcode"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.Text = "Barcode"
        CType(Me.dtabUtama, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtabUtama As C1.Win.C1Command.C1DockingTab
    Friend WithEvents txtBarcode As System.Windows.Forms.TextBox
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cmdClose As C1.Win.C1Input.C1Button
    Friend WithEvents VirtualKey As C1.Win.C1Input.C1Button
End Class
