<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Pop_Up_Open_Menu
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
        Me.cmdOpenMenu = New C1.Win.C1Input.C1Button
        Me.cmdEditPaket = New C1.Win.C1Input.C1Button
        Me.SuspendLayout()
        '
        'cmdOpenMenu
        '
        Me.cmdOpenMenu.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdOpenMenu.Location = New System.Drawing.Point(12, 12)
        Me.cmdOpenMenu.Name = "cmdOpenMenu"
        Me.cmdOpenMenu.Size = New System.Drawing.Size(311, 60)
        Me.cmdOpenMenu.TabIndex = 10
        Me.cmdOpenMenu.Tag = ""
        Me.cmdOpenMenu.Text = "Edit Open Menu"
        Me.cmdOpenMenu.UseVisualStyleBackColor = True
        Me.cmdOpenMenu.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'cmdEditPaket
        '
        Me.cmdEditPaket.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdEditPaket.Location = New System.Drawing.Point(12, 78)
        Me.cmdEditPaket.Name = "cmdEditPaket"
        Me.cmdEditPaket.Size = New System.Drawing.Size(311, 60)
        Me.cmdEditPaket.TabIndex = 11
        Me.cmdEditPaket.Tag = ""
        Me.cmdEditPaket.Text = "Edit Detail Packet"
        Me.cmdEditPaket.UseVisualStyleBackColor = True
        Me.cmdEditPaket.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Form_Pop_Up_Open_Menu
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(334, 145)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdEditPaket)
        Me.Controls.Add(Me.cmdOpenMenu)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Name = "Form_Pop_Up_Open_Menu"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents cmdOpenMenu As C1.Win.C1Input.C1Button
    Friend WithEvents cmdEditPaket As C1.Win.C1Input.C1Button
End Class
