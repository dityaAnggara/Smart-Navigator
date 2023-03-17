<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Create_New_Cust
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Create_New_Cust))
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.cmbKategori = New C1.Win.C1List.C1Combo
        Me.txtTelp = New System.Windows.Forms.TextBox
        Me.txtAlamat = New System.Windows.Forms.TextBox
        Me.txtNamaCustomer = New System.Windows.Forms.TextBox
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.BTNSave = New C1.Win.C1Input.C1Button
        Me.BTNClose = New C1.Win.C1Input.C1Button
        Me.GroupBox1.SuspendLayout()
        CType(Me.cmbKategori, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.cmbKategori)
        Me.GroupBox1.Controls.Add(Me.txtTelp)
        Me.GroupBox1.Controls.Add(Me.txtAlamat)
        Me.GroupBox1.Controls.Add(Me.txtNamaCustomer)
        Me.GroupBox1.Controls.Add(Me.Label4)
        Me.GroupBox1.Controls.Add(Me.Label3)
        Me.GroupBox1.Controls.Add(Me.Label2)
        Me.GroupBox1.Controls.Add(Me.Label1)
        Me.GroupBox1.Location = New System.Drawing.Point(13, 7)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(440, 238)
        Me.GroupBox1.TabIndex = 0
        Me.GroupBox1.TabStop = False
        '
        'cmbKategori
        '
        Me.cmbKategori.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.cmbKategori.AlternatingRows = True
        Me.cmbKategori.AutoCompletion = True
        Me.cmbKategori.AutoDropDown = True
        Me.cmbKategori.Caption = ""
        Me.cmbKategori.CaptionHeight = 17
        Me.cmbKategori.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.cmbKategori.ColumnCaptionHeight = 17
        Me.cmbKategori.ColumnFooterHeight = 17
        Me.cmbKategori.ColumnHeaders = False
        Me.cmbKategori.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.cmbKategori.ContentHeight = 24
        Me.cmbKategori.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.cmbKategori.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.cmbKategori.EditorBackColor = System.Drawing.SystemColors.Window
        Me.cmbKategori.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKategori.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.cmbKategori.EditorHeight = 24
        Me.cmbKategori.ExtendRightColumn = True
        Me.cmbKategori.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmbKategori.Images.Add(CType(resources.GetObject("cmbKategori.Images"), System.Drawing.Image))
        Me.cmbKategori.ItemHeight = 45
        Me.cmbKategori.Location = New System.Drawing.Point(165, 182)
        Me.cmbKategori.MatchEntryTimeout = CType(100, Long)
        Me.cmbKategori.MaxDropDownItems = CType(5, Short)
        Me.cmbKategori.MaxLength = 32767
        Me.cmbKategori.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.cmbKategori.Name = "cmbKategori"
        Me.cmbKategori.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.cmbKategori.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.cmbKategori.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.cmbKategori.Size = New System.Drawing.Size(258, 30)
        Me.cmbKategori.TabIndex = 18
        Me.cmbKategori.Text = "Choose here ..."
        Me.cmbKategori.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.cmbKategori.PropBag = resources.GetString("cmbKategori.PropBag")
        '
        'txtTelp
        '
        Me.txtTelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtTelp.Location = New System.Drawing.Point(165, 127)
        Me.txtTelp.MaxLength = 14
        Me.txtTelp.Name = "txtTelp"
        Me.txtTelp.Size = New System.Drawing.Size(258, 29)
        Me.txtTelp.TabIndex = 17
        '
        'txtAlamat
        '
        Me.txtAlamat.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtAlamat.Location = New System.Drawing.Point(165, 80)
        Me.txtAlamat.MaxLength = 80
        Me.txtAlamat.Name = "txtAlamat"
        Me.txtAlamat.Size = New System.Drawing.Size(258, 29)
        Me.txtAlamat.TabIndex = 16
        '
        'txtNamaCustomer
        '
        Me.txtNamaCustomer.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.txtNamaCustomer.Location = New System.Drawing.Point(165, 28)
        Me.txtNamaCustomer.MaxLength = 40
        Me.txtNamaCustomer.Name = "txtNamaCustomer"
        Me.txtNamaCustomer.Size = New System.Drawing.Size(258, 29)
        Me.txtNamaCustomer.TabIndex = 15
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(14, 182)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(73, 20)
        Me.Label4.TabIndex = 14
        Me.Label4.Text = "Category"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.Location = New System.Drawing.Point(14, 133)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(39, 20)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Telp"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(14, 80)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(68, 20)
        Me.Label2.TabIndex = 12
        Me.Label2.Text = "Address"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(14, 26)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(128, 20)
        Me.Label1.TabIndex = 11
        Me.Label1.Text = "Customer Name "
        '
        'BTNSave
        '
        Me.BTNSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSave.Image = CType(resources.GetObject("BTNSave.Image"), System.Drawing.Image)
        Me.BTNSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNSave.Location = New System.Drawing.Point(137, 261)
        Me.BTNSave.Name = "BTNSave"
        Me.BTNSave.Size = New System.Drawing.Size(92, 43)
        Me.BTNSave.TabIndex = 4
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
        Me.BTNClose.Location = New System.Drawing.Point(237, 261)
        Me.BTNClose.Name = "BTNClose"
        Me.BTNClose.Size = New System.Drawing.Size(92, 43)
        Me.BTNClose.TabIndex = 5
        Me.BTNClose.Text = "Close"
        Me.BTNClose.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNClose.UseVisualStyleBackColor = True
        Me.BTNClose.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Form_Create_New_Cust
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(465, 325)
        Me.Controls.Add(Me.BTNSave)
        Me.Controls.Add(Me.BTNClose)
        Me.Controls.Add(Me.GroupBox1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Create_New_Cust"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Create New Customer"
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.cmbKategori, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents cmbKategori As C1.Win.C1List.C1Combo
    Friend WithEvents txtTelp As System.Windows.Forms.TextBox
    Friend WithEvents txtAlamat As System.Windows.Forms.TextBox
    Friend WithEvents txtNamaCustomer As System.Windows.Forms.TextBox
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents BTNSave As C1.Win.C1Input.C1Button
    Friend WithEvents BTNClose As C1.Win.C1Input.C1Button
End Class
