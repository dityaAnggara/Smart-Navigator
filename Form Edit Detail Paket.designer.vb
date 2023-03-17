<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Edit_Detail_Paket
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Edit_Detail_Paket))
        Me.ImageList = New System.Windows.Forms.ImageList(Me.components)
        Me.Tooltip = New C1.Win.C1SuperTooltip.C1SuperTooltip(Me.components)
        Me.InputBoxs = New System.Windows.Forms.GroupBox
        Me.C1Button2 = New C1.Win.C1Input.C1Button
        Me.C1Button1 = New C1.Win.C1Input.C1Button
        Me.Label3 = New System.Windows.Forms.Label
        Me.REMOVEButton = New C1.Win.C1Input.C1Button
        Me.ADDButton = New C1.Win.C1Input.C1Button
        Me.MenuDetail = New C1.Win.C1FlexGrid.C1FlexGrid
        Me.InvenNameTxt = New System.Windows.Forms.TextBox
        Me.Label2 = New System.Windows.Forms.Label
        Me.InvenNoTxt = New System.Windows.Forms.TextBox
        Me.Label1 = New System.Windows.Forms.Label
        Me.IMG = New System.Windows.Forms.OpenFileDialog
        Me.BTNSave = New C1.Win.C1Input.C1Button
        Me.BTNReset = New C1.Win.C1Input.C1Button
        Me.InputBoxs.SuspendLayout()
        CType(Me.MenuDetail, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'ImageList
        '
        Me.ImageList.ImageStream = CType(resources.GetObject("ImageList.ImageStream"), System.Windows.Forms.ImageListStreamer)
        Me.ImageList.TransparentColor = System.Drawing.Color.Transparent
        Me.ImageList.Images.SetKeyName(0, "New")
        Me.ImageList.Images.SetKeyName(1, "Save")
        Me.ImageList.Images.SetKeyName(2, "Edit")
        Me.ImageList.Images.SetKeyName(3, "Cancel")
        Me.ImageList.Images.SetKeyName(4, "Void")
        Me.ImageList.Images.SetKeyName(5, "Print")
        Me.ImageList.Images.SetKeyName(6, "List")
        Me.ImageList.Images.SetKeyName(7, "First")
        Me.ImageList.Images.SetKeyName(8, "Back")
        Me.ImageList.Images.SetKeyName(9, "Next")
        Me.ImageList.Images.SetKeyName(10, "Last")
        Me.ImageList.Images.SetKeyName(11, "Refresh")
        Me.ImageList.Images.SetKeyName(12, "Exit")
        '
        'Tooltip
        '
        Me.Tooltip.Font = New System.Drawing.Font("Tahoma", 8.0!)
        Me.Tooltip.IsBalloon = True
        '
        'InputBoxs
        '
        Me.InputBoxs.Controls.Add(Me.C1Button2)
        Me.InputBoxs.Controls.Add(Me.C1Button1)
        Me.InputBoxs.Controls.Add(Me.Label3)
        Me.InputBoxs.Controls.Add(Me.REMOVEButton)
        Me.InputBoxs.Controls.Add(Me.ADDButton)
        Me.InputBoxs.Controls.Add(Me.MenuDetail)
        Me.InputBoxs.Controls.Add(Me.InvenNameTxt)
        Me.InputBoxs.Controls.Add(Me.Label2)
        Me.InputBoxs.Controls.Add(Me.InvenNoTxt)
        Me.InputBoxs.Controls.Add(Me.Label1)
        Me.InputBoxs.Location = New System.Drawing.Point(8, 12)
        Me.InputBoxs.Name = "InputBoxs"
        Me.InputBoxs.Size = New System.Drawing.Size(701, 391)
        Me.InputBoxs.TabIndex = 70
        Me.InputBoxs.TabStop = False
        '
        'C1Button2
        '
        Me.C1Button2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Button2.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button2.Location = New System.Drawing.Point(610, 344)
        Me.C1Button2.Name = "C1Button2"
        Me.C1Button2.Size = New System.Drawing.Size(60, 38)
        Me.C1Button2.TabIndex = 118
        Me.C1Button2.Text = "-"
        Me.C1Button2.UseVisualStyleBackColor = True
        Me.C1Button2.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'C1Button1
        '
        Me.C1Button1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Button1.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.C1Button1.Location = New System.Drawing.Point(610, 302)
        Me.C1Button1.Name = "C1Button1"
        Me.C1Button1.Size = New System.Drawing.Size(60, 36)
        Me.C1Button1.TabIndex = 117
        Me.C1Button1.Text = "+"
        Me.C1Button1.UseVisualStyleBackColor = True
        Me.C1Button1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(6, 80)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(92, 13)
        Me.Label3.TabIndex = 116
        Me.Label3.Text = "Paket Component"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'REMOVEButton
        '
        Me.REMOVEButton.Image = CType(resources.GetObject("REMOVEButton.Image"), System.Drawing.Image)
        Me.REMOVEButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.REMOVEButton.Location = New System.Drawing.Point(610, 166)
        Me.REMOVEButton.Name = "REMOVEButton"
        Me.REMOVEButton.Size = New System.Drawing.Size(60, 55)
        Me.REMOVEButton.TabIndex = 11
        Me.REMOVEButton.Text = "Remove"
        Me.REMOVEButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.REMOVEButton.UseVisualStyleBackColor = True
        Me.REMOVEButton.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'ADDButton
        '
        Me.ADDButton.Image = CType(resources.GetObject("ADDButton.Image"), System.Drawing.Image)
        Me.ADDButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.ADDButton.Location = New System.Drawing.Point(610, 105)
        Me.ADDButton.Name = "ADDButton"
        Me.ADDButton.Size = New System.Drawing.Size(60, 55)
        Me.ADDButton.TabIndex = 10
        Me.ADDButton.Text = "Add"
        Me.ADDButton.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.ADDButton.UseVisualStyleBackColor = True
        Me.ADDButton.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'MenuDetail
        '
        Me.MenuDetail.AllowEditing = False
        Me.MenuDetail.ColumnInfo = resources.GetString("MenuDetail.ColumnInfo")
        Me.MenuDetail.Location = New System.Drawing.Point(9, 105)
        Me.MenuDetail.Name = "MenuDetail"
        Me.MenuDetail.Rows.Count = 1
        Me.MenuDetail.Rows.DefaultSize = 17
        Me.MenuDetail.SelectionMode = C1.Win.C1FlexGrid.SelectionModeEnum.Row
        Me.MenuDetail.Size = New System.Drawing.Size(595, 277)
        Me.MenuDetail.TabIndex = 7
        Me.MenuDetail.VisualStyle = C1.Win.C1FlexGrid.VisualStyle.Office2007Blue
        '
        'InvenNameTxt
        '
        Me.InvenNameTxt.Location = New System.Drawing.Point(82, 45)
        Me.InvenNameTxt.MaxLength = 40
        Me.InvenNameTxt.Name = "InvenNameTxt"
        Me.InvenNameTxt.ReadOnly = True
        Me.InvenNameTxt.Size = New System.Drawing.Size(268, 20)
        Me.InvenNameTxt.TabIndex = 1
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(13, 48)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(66, 13)
        Me.Label2.TabIndex = 83
        Me.Label2.Text = "Paket Name"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'InvenNoTxt
        '
        Me.InvenNoTxt.Location = New System.Drawing.Point(82, 17)
        Me.InvenNoTxt.MaxLength = 14
        Me.InvenNoTxt.Name = "InvenNoTxt"
        Me.InvenNoTxt.ReadOnly = True
        Me.InvenNoTxt.Size = New System.Drawing.Size(268, 20)
        Me.InvenNoTxt.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 20)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(55, 13)
        Me.Label1.TabIndex = 5
        Me.Label1.Text = "Paket No."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'IMG
        '
        Me.IMG.Filter = "Picture File|*.PNG;*.JPG"
        Me.IMG.Title = "Picture Browser"
        '
        'BTNSave
        '
        Me.BTNSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSave.Image = CType(resources.GetObject("BTNSave.Image"), System.Drawing.Image)
        Me.BTNSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNSave.Location = New System.Drawing.Point(331, 421)
        Me.BTNSave.Name = "BTNSave"
        Me.BTNSave.Size = New System.Drawing.Size(186, 43)
        Me.BTNSave.TabIndex = 72
        Me.BTNSave.Text = "Save"
        Me.BTNSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNSave.UseVisualStyleBackColor = True
        Me.BTNSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNReset
        '
        Me.BTNReset.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNReset.Image = CType(resources.GetObject("BTNReset.Image"), System.Drawing.Image)
        Me.BTNReset.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNReset.Location = New System.Drawing.Point(523, 421)
        Me.BTNReset.Name = "BTNReset"
        Me.BTNReset.Size = New System.Drawing.Size(186, 43)
        Me.BTNReset.TabIndex = 71
        Me.BTNReset.Text = "Close"
        Me.BTNReset.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNReset.UseVisualStyleBackColor = True
        Me.BTNReset.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Edit_Detail_Paket
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(718, 476)
        Me.Controls.Add(Me.BTNSave)
        Me.Controls.Add(Me.BTNReset)
        Me.Controls.Add(Me.InputBoxs)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Edit_Detail_Paket"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Paket List"
        Me.InputBoxs.ResumeLayout(False)
        Me.InputBoxs.PerformLayout()
        CType(Me.MenuDetail, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents ImageList As System.Windows.Forms.ImageList
    Friend WithEvents Tooltip As C1.Win.C1SuperTooltip.C1SuperTooltip
    Friend WithEvents InputBoxs As System.Windows.Forms.GroupBox
    Friend WithEvents InvenNameTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents InvenNoTxt As System.Windows.Forms.TextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents MenuDetail As C1.Win.C1FlexGrid.C1FlexGrid
    Friend WithEvents ADDButton As C1.Win.C1Input.C1Button
    Friend WithEvents REMOVEButton As C1.Win.C1Input.C1Button
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents IMG As System.Windows.Forms.OpenFileDialog
    Friend WithEvents C1Button1 As C1.Win.C1Input.C1Button
    Friend WithEvents C1Button2 As C1.Win.C1Input.C1Button
    Friend WithEvents BTNSave As C1.Win.C1Input.C1Button
    Friend WithEvents BTNReset As C1.Win.C1Input.C1Button
End Class
