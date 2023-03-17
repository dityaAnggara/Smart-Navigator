<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Popup_Jumlah
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
        Me.dtabUtama = New C1.Win.C1Command.C1DockingTab
        Me.txtJumlah = New System.Windows.Forms.TextBox
        Me.cmdTambah = New C1.Win.C1Input.C1Button
        Me.cmdKurang = New C1.Win.C1Input.C1Button
        Me.Panel1 = New System.Windows.Forms.Panel
        Me.cmdOK = New C1.Win.C1Input.C1Button
        Me.cmdBatal = New C1.Win.C1Input.C1Button
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
        Me.dtabUtama.Size = New System.Drawing.Size(315, 122)
        Me.dtabUtama.TabAreaSpacing = 3
        Me.dtabUtama.TabIndex = 249
        Me.dtabUtama.TabSizeMode = C1.Win.C1Command.TabSizeModeEnum.Fit
        Me.dtabUtama.TabsSpacing = 5
        Me.dtabUtama.TabStyle = C1.Win.C1Command.TabStyleEnum.Office2007
        Me.dtabUtama.VisualStyle = C1.Win.C1Command.VisualStyle.Office2007Blue
        Me.dtabUtama.VisualStyleBase = C1.Win.C1Command.VisualStyle.Office2007Blue
        '
        'txtJumlah
        '
        Me.txtJumlah.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtJumlah.Location = New System.Drawing.Point(5, 4)
        Me.txtJumlah.MaxLength = 3
        Me.txtJumlah.Name = "txtJumlah"
        Me.txtJumlah.Size = New System.Drawing.Size(110, 29)
        Me.txtJumlah.TabIndex = 250
        Me.txtJumlah.Text = "1"
        Me.txtJumlah.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'cmdTambah
        '
        Me.cmdTambah.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdTambah.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdTambah.Location = New System.Drawing.Point(5, 43)
        Me.cmdTambah.Name = "cmdTambah"
        Me.cmdTambah.Size = New System.Drawing.Size(52, 60)
        Me.cmdTambah.TabIndex = 251
        Me.cmdTambah.Text = "+"
        Me.cmdTambah.UseVisualStyleBackColor = True
        Me.cmdTambah.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'cmdKurang
        '
        Me.cmdKurang.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdKurang.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdKurang.Location = New System.Drawing.Point(63, 43)
        Me.cmdKurang.Name = "cmdKurang"
        Me.cmdKurang.Size = New System.Drawing.Size(52, 60)
        Me.cmdKurang.TabIndex = 252
        Me.cmdKurang.Text = "-"
        Me.cmdKurang.UseVisualStyleBackColor = True
        Me.cmdKurang.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Panel1
        '
        Me.Panel1.BackColor = System.Drawing.Color.AliceBlue
        Me.Panel1.Controls.Add(Me.cmdOK)
        Me.Panel1.Controls.Add(Me.cmdBatal)
        Me.Panel1.Controls.Add(Me.txtJumlah)
        Me.Panel1.Controls.Add(Me.cmdKurang)
        Me.Panel1.Controls.Add(Me.cmdTambah)
        Me.Panel1.Location = New System.Drawing.Point(7, 8)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(307, 114)
        Me.Panel1.TabIndex = 253
        '
        'cmdOK
        '
        Me.cmdOK.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOK.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdOK.Location = New System.Drawing.Point(227, 43)
        Me.cmdOK.Name = "cmdOK"
        Me.cmdOK.Size = New System.Drawing.Size(73, 60)
        Me.cmdOK.TabIndex = 254
        Me.cmdOK.Text = "OK"
        Me.cmdOK.UseVisualStyleBackColor = True
        Me.cmdOK.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'cmdBatal
        '
        Me.cmdBatal.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBatal.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft
        Me.cmdBatal.Location = New System.Drawing.Point(126, 43)
        Me.cmdBatal.Name = "cmdBatal"
        Me.cmdBatal.Size = New System.Drawing.Size(95, 60)
        Me.cmdBatal.TabIndex = 254
        Me.cmdBatal.Text = "Cancel"
        Me.cmdBatal.UseVisualStyleBackColor = True
        Me.cmdBatal.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Form_Popup_Jumlah
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(322, 128)
        Me.ControlBox = False
        Me.Controls.Add(Me.Panel1)
        Me.Controls.Add(Me.dtabUtama)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Popup_Jumlah"
        Me.ShowIcon = False
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Quantity"
        CType(Me.dtabUtama, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel1.ResumeLayout(False)
        Me.Panel1.PerformLayout()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents dtabUtama As C1.Win.C1Command.C1DockingTab
    Friend WithEvents txtJumlah As System.Windows.Forms.TextBox
    Friend WithEvents cmdTambah As C1.Win.C1Input.C1Button
    Friend WithEvents cmdKurang As C1.Win.C1Input.C1Button
    Friend WithEvents Panel1 As System.Windows.Forms.Panel
    Friend WithEvents cmdOK As C1.Win.C1Input.C1Button
    Friend WithEvents cmdBatal As C1.Win.C1Input.C1Button
End Class
