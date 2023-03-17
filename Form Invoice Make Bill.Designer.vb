<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Invoice_Make_Bill
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form_Invoice_Make_Bill))
        Me.GroupBox = New System.Windows.Forms.GroupBox
        Me.txtRoundingInvisible = New System.Windows.Forms.TextBox
        Me.cmdCalcRounding = New C1.Win.C1Input.C1Button
        Me.lblSetelahRounding = New C1.Win.C1Input.C1Label
        Me.Label7 = New System.Windows.Forms.Label
        Me.lblRounding = New C1.Win.C1Input.C1Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Tax = New C1.Win.C1Input.C1Label
        Me.Tax2 = New C1.Win.C1Input.C1Label
        Me.Tax1 = New C1.Win.C1Input.C1Label
        Me.Tax2ValTxt = New C1.Win.C1Input.C1Label
        Me.Tax1ValTxt = New C1.Win.C1Input.C1Label
        Me.Tax2Check = New System.Windows.Forms.CheckBox
        Me.Tax1Check = New System.Windows.Forms.CheckBox
        Me.Tax2Txt = New C1.Win.C1Input.C1Label
        Me.Tax2Label = New System.Windows.Forms.Label
        Me.VirtualKey = New C1.Win.C1Input.C1Button
        Me.CustName = New System.Windows.Forms.TextBox
        Me.TotalItemTxt = New C1.Win.C1Input.C1Label
        Me.TotalTxt = New C1.Win.C1Input.C1Label
        Me.DPtxt = New C1.Win.C1Input.C1Label
        Me.Tax1Txt = New C1.Win.C1Input.C1Label
        Me.DiscountTxt = New C1.Win.C1Input.C1Label
        Me.SubTotalTxt = New C1.Win.C1Input.C1Label
        Me.Label15 = New System.Windows.Forms.Label
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.Tax1Label = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.BillNo = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.TextBox1 = New System.Windows.Forms.TextBox
        Me.C1Combo3 = New C1.Win.C1List.C1Combo
        Me.Label11 = New System.Windows.Forms.Label
        Me.Label13 = New System.Windows.Forms.Label
        Me.Label10 = New System.Windows.Forms.Label
        Me.C1Combo2 = New C1.Win.C1List.C1Combo
        Me.Label14 = New System.Windows.Forms.Label
        Me.BTNCancel = New C1.Win.C1Input.C1Button
        Me.BTNSave = New C1.Win.C1Input.C1Button
        Me.Label9 = New System.Windows.Forms.Label
        Me.C1NumericEdit1 = New C1.Win.C1Input.C1NumericEdit
        Me.Label4 = New System.Windows.Forms.Label
        Me.C1Combo1 = New C1.Win.C1List.C1Combo
        Me.BTNDiscount = New C1.Win.C1Input.C1Button
        Me.cmdBarcode = New C1.Win.C1Input.C1Button
        Me.dtOldDate = New System.Windows.Forms.DateTimePicker
        Me.GroupBox.SuspendLayout()
        CType(Me.lblSetelahRounding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.lblRounding, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tax, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tax2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tax1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tax2ValTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tax1ValTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tax2Txt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalItemTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TotalTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DPtxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.Tax1Txt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DiscountTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SubTotalTxt, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Combo3, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Combo2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1NumericEdit1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'GroupBox
        '
        Me.GroupBox.Controls.Add(Me.dtOldDate)
        Me.GroupBox.Controls.Add(Me.txtRoundingInvisible)
        Me.GroupBox.Controls.Add(Me.cmdCalcRounding)
        Me.GroupBox.Controls.Add(Me.lblSetelahRounding)
        Me.GroupBox.Controls.Add(Me.Label7)
        Me.GroupBox.Controls.Add(Me.lblRounding)
        Me.GroupBox.Controls.Add(Me.Label2)
        Me.GroupBox.Controls.Add(Me.Tax)
        Me.GroupBox.Controls.Add(Me.Tax2)
        Me.GroupBox.Controls.Add(Me.Tax1)
        Me.GroupBox.Controls.Add(Me.Tax2ValTxt)
        Me.GroupBox.Controls.Add(Me.Tax1ValTxt)
        Me.GroupBox.Controls.Add(Me.Tax2Check)
        Me.GroupBox.Controls.Add(Me.Tax1Check)
        Me.GroupBox.Controls.Add(Me.Tax2Txt)
        Me.GroupBox.Controls.Add(Me.Tax2Label)
        Me.GroupBox.Controls.Add(Me.VirtualKey)
        Me.GroupBox.Controls.Add(Me.CustName)
        Me.GroupBox.Controls.Add(Me.TotalItemTxt)
        Me.GroupBox.Controls.Add(Me.TotalTxt)
        Me.GroupBox.Controls.Add(Me.DPtxt)
        Me.GroupBox.Controls.Add(Me.Tax1Txt)
        Me.GroupBox.Controls.Add(Me.DiscountTxt)
        Me.GroupBox.Controls.Add(Me.SubTotalTxt)
        Me.GroupBox.Controls.Add(Me.Label15)
        Me.GroupBox.Controls.Add(Me.Label12)
        Me.GroupBox.Controls.Add(Me.Label8)
        Me.GroupBox.Controls.Add(Me.Tax1Label)
        Me.GroupBox.Controls.Add(Me.Label6)
        Me.GroupBox.Controls.Add(Me.Label5)
        Me.GroupBox.Controls.Add(Me.BillNo)
        Me.GroupBox.Controls.Add(Me.Label3)
        Me.GroupBox.Controls.Add(Me.Label1)
        Me.GroupBox.Location = New System.Drawing.Point(8, 4)
        Me.GroupBox.Name = "GroupBox"
        Me.GroupBox.Size = New System.Drawing.Size(401, 508)
        Me.GroupBox.TabIndex = 107
        Me.GroupBox.TabStop = False
        '
        'txtRoundingInvisible
        '
        Me.txtRoundingInvisible.Location = New System.Drawing.Point(264, 462)
        Me.txtRoundingInvisible.Name = "txtRoundingInvisible"
        Me.txtRoundingInvisible.Size = New System.Drawing.Size(36, 20)
        Me.txtRoundingInvisible.TabIndex = 149
        Me.txtRoundingInvisible.Text = "0"
        Me.txtRoundingInvisible.Visible = False
        '
        'cmdCalcRounding
        '
        Me.cmdCalcRounding.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdCalcRounding.Image = CType(resources.GetObject("cmdCalcRounding.Image"), System.Drawing.Image)
        Me.cmdCalcRounding.Location = New System.Drawing.Point(338, 460)
        Me.cmdCalcRounding.Name = "cmdCalcRounding"
        Me.cmdCalcRounding.Size = New System.Drawing.Size(49, 31)
        Me.cmdCalcRounding.TabIndex = 148
        Me.cmdCalcRounding.UseVisualStyleBackColor = True
        Me.cmdCalcRounding.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'lblSetelahRounding
        '
        Me.lblSetelahRounding.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.lblSetelahRounding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblSetelahRounding.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblSetelahRounding.ForeColor = System.Drawing.Color.Maroon
        Me.lblSetelahRounding.Location = New System.Drawing.Point(124, 455)
        Me.lblSetelahRounding.Name = "lblSetelahRounding"
        Me.lblSetelahRounding.Size = New System.Drawing.Size(263, 42)
        Me.lblSetelahRounding.TabIndex = 146
        Me.lblSetelahRounding.Tag = Nothing
        Me.lblSetelahRounding.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblSetelahRounding.Value = "0"
        Me.lblSetelahRounding.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(15, 469)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(105, 13)
        Me.Label7.TabIndex = 147
        Me.Label7.Text = "Total After Rounding"
        Me.Label7.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'lblRounding
        '
        Me.lblRounding.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.lblRounding.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.lblRounding.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblRounding.ForeColor = System.Drawing.Color.Maroon
        Me.lblRounding.Location = New System.Drawing.Point(124, 407)
        Me.lblRounding.Name = "lblRounding"
        Me.lblRounding.Size = New System.Drawing.Size(264, 42)
        Me.lblRounding.TabIndex = 144
        Me.lblRounding.Tag = Nothing
        Me.lblRounding.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.lblRounding.Value = "0"
        Me.lblRounding.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(15, 422)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(53, 13)
        Me.Label2.TabIndex = 145
        Me.Label2.Text = "Rounding"
        Me.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Tax
        '
    Me.Tax.Image = Global.PrimeRESTO.My.Resources.Resources._NOTHING
    Me.Tax.ImageAlign = System.Drawing.ContentAlignment.TopCenter
    Me.Tax.Location = New System.Drawing.Point(241, 9)
    Me.Tax.Name = "Tax"
    Me.Tax.Size = New System.Drawing.Size(35, 35)
    Me.Tax.TabIndex = 125
    Me.Tax.Tag = Nothing
    Me.Tax.TextAlign = System.Drawing.ContentAlignment.BottomCenter
    Me.Tax.Value = ""
    Me.Tax.Visible = False
    '
    'Tax2
    '
    Me.Tax2.Image = Global.PrimeRESTO.My.Resources.Resources.OK
    Me.Tax2.Location = New System.Drawing.Point(89, 229)
    Me.Tax2.Name = "Tax2"
    Me.Tax2.Size = New System.Drawing.Size(31, 32)
    Me.Tax2.TabIndex = 123
    Me.Tax2.Tag = Nothing
    Me.Tax2.Value = ""
    '
    'Tax1
    '
    Me.Tax1.Image = Global.PrimeRESTO.My.Resources.Resources.OK
        Me.Tax1.Location = New System.Drawing.Point(89, 181)
        Me.Tax1.Name = "Tax1"
        Me.Tax1.Size = New System.Drawing.Size(31, 32)
        Me.Tax1.TabIndex = 122
        Me.Tax1.Tag = Nothing
        Me.Tax1.Value = ""
        '
        'Tax2ValTxt
        '
        Me.Tax2ValTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Tax2ValTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tax2ValTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tax2ValTxt.ForeColor = System.Drawing.Color.Maroon
        Me.Tax2ValTxt.Location = New System.Drawing.Point(124, 224)
        Me.Tax2ValTxt.Name = "Tax2ValTxt"
        Me.Tax2ValTxt.Size = New System.Drawing.Size(264, 40)
        Me.Tax2ValTxt.TabIndex = 121
        Me.Tax2ValTxt.Tag = Nothing
        Me.Tax2ValTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Tax2ValTxt.Value = "0"
        Me.Tax2ValTxt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Tax1ValTxt
        '
        Me.Tax1ValTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Tax1ValTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tax1ValTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tax1ValTxt.ForeColor = System.Drawing.Color.Maroon
        Me.Tax1ValTxt.Location = New System.Drawing.Point(124, 178)
        Me.Tax1ValTxt.Name = "Tax1ValTxt"
        Me.Tax1ValTxt.Size = New System.Drawing.Size(264, 40)
        Me.Tax1ValTxt.TabIndex = 120
        Me.Tax1ValTxt.Tag = Nothing
        Me.Tax1ValTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Tax1ValTxt.Value = "0"
        Me.Tax1ValTxt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Tax2Check
        '
        Me.Tax2Check.AutoSize = True
        Me.Tax2Check.Location = New System.Drawing.Point(97, 238)
        Me.Tax2Check.Name = "Tax2Check"
        Me.Tax2Check.Size = New System.Drawing.Size(15, 14)
        Me.Tax2Check.TabIndex = 119
        Me.Tax2Check.UseVisualStyleBackColor = True
        '
        'Tax1Check
        '
        Me.Tax1Check.AutoSize = True
        Me.Tax1Check.Location = New System.Drawing.Point(100, 190)
        Me.Tax1Check.Name = "Tax1Check"
        Me.Tax1Check.Size = New System.Drawing.Size(15, 14)
        Me.Tax1Check.TabIndex = 118
        Me.Tax1Check.UseVisualStyleBackColor = True
        '
        'Tax2Txt
        '
        Me.Tax2Txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Tax2Txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tax2Txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tax2Txt.ForeColor = System.Drawing.Color.Maroon
        Me.Tax2Txt.Location = New System.Drawing.Point(57, 229)
        Me.Tax2Txt.Name = "Tax2Txt"
        Me.Tax2Txt.Size = New System.Drawing.Size(31, 32)
        Me.Tax2Txt.TabIndex = 116
        Me.Tax2Txt.Tag = Nothing
        Me.Tax2Txt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Tax2Txt.Value = "0"
        Me.Tax2Txt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Tax2Label
        '
        Me.Tax2Label.AutoSize = True
        Me.Tax2Label.Location = New System.Drawing.Point(17, 239)
        Me.Tax2Label.Name = "Tax2Label"
        Me.Tax2Label.Size = New System.Drawing.Size(34, 13)
        Me.Tax2Label.TabIndex = 117
        Me.Tax2Label.Text = "Tax 2"
        Me.Tax2Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'VirtualKey
        '
        Me.VirtualKey.Image = CType(resources.GetObject("VirtualKey.Image"), System.Drawing.Image)
        Me.VirtualKey.Location = New System.Drawing.Point(338, 50)
        Me.VirtualKey.Name = "VirtualKey"
        Me.VirtualKey.Size = New System.Drawing.Size(50, 32)
        Me.VirtualKey.TabIndex = 115
        Me.VirtualKey.UseVisualStyleBackColor = True
        Me.VirtualKey.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'CustName
        '
        Me.CustName.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CustName.Location = New System.Drawing.Point(124, 53)
        Me.CustName.MaxLength = 40
        Me.CustName.Name = "CustName"
        Me.CustName.Size = New System.Drawing.Size(208, 26)
        Me.CustName.TabIndex = 114
        '
        'TotalItemTxt
        '
        Me.TotalItemTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.TotalItemTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalItemTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalItemTxt.ForeColor = System.Drawing.Color.Maroon
        Me.TotalItemTxt.Location = New System.Drawing.Point(124, 362)
        Me.TotalItemTxt.Name = "TotalItemTxt"
        Me.TotalItemTxt.Size = New System.Drawing.Size(264, 40)
        Me.TotalItemTxt.TabIndex = 9
        Me.TotalItemTxt.Tag = Nothing
        Me.TotalItemTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TotalItemTxt.Value = "0"
        Me.TotalItemTxt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'TotalTxt
        '
        Me.TotalTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.TotalTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.TotalTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.TotalTxt.ForeColor = System.Drawing.Color.Maroon
        Me.TotalTxt.Location = New System.Drawing.Point(124, 316)
        Me.TotalTxt.Name = "TotalTxt"
        Me.TotalTxt.Size = New System.Drawing.Size(264, 40)
        Me.TotalTxt.TabIndex = 8
        Me.TotalTxt.Tag = Nothing
        Me.TotalTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.TotalTxt.Value = "0"
        Me.TotalTxt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'DPtxt
        '
        Me.DPtxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.DPtxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DPtxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DPtxt.ForeColor = System.Drawing.Color.Maroon
        Me.DPtxt.Location = New System.Drawing.Point(124, 270)
        Me.DPtxt.Name = "DPtxt"
        Me.DPtxt.Size = New System.Drawing.Size(264, 40)
        Me.DPtxt.TabIndex = 7
        Me.DPtxt.Tag = Nothing
        Me.DPtxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DPtxt.Value = "0"
        Me.DPtxt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Tax1Txt
        '
        Me.Tax1Txt.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.Tax1Txt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Tax1Txt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Tax1Txt.ForeColor = System.Drawing.Color.Maroon
        Me.Tax1Txt.Location = New System.Drawing.Point(57, 181)
        Me.Tax1Txt.Name = "Tax1Txt"
        Me.Tax1Txt.Size = New System.Drawing.Size(31, 32)
        Me.Tax1Txt.TabIndex = 6
        Me.Tax1Txt.Tag = Nothing
        Me.Tax1Txt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.Tax1Txt.Value = "0"
        Me.Tax1Txt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'DiscountTxt
        '
        Me.DiscountTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.DiscountTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.DiscountTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DiscountTxt.ForeColor = System.Drawing.Color.Maroon
        Me.DiscountTxt.Location = New System.Drawing.Point(124, 133)
        Me.DiscountTxt.Name = "DiscountTxt"
        Me.DiscountTxt.Size = New System.Drawing.Size(264, 40)
        Me.DiscountTxt.TabIndex = 5
        Me.DiscountTxt.Tag = Nothing
        Me.DiscountTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.DiscountTxt.Value = "0"
        Me.DiscountTxt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'SubTotalTxt
        '
        Me.SubTotalTxt.BackColor = System.Drawing.Color.FromArgb(CType(CType(234, Byte), Integer), CType(CType(242, Byte), Integer), CType(CType(251, Byte), Integer))
        Me.SubTotalTxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.SubTotalTxt.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SubTotalTxt.ForeColor = System.Drawing.Color.Maroon
        Me.SubTotalTxt.Location = New System.Drawing.Point(124, 87)
        Me.SubTotalTxt.Name = "SubTotalTxt"
        Me.SubTotalTxt.Size = New System.Drawing.Size(264, 40)
        Me.SubTotalTxt.TabIndex = 4
        Me.SubTotalTxt.Tag = Nothing
        Me.SubTotalTxt.TextAlign = System.Drawing.ContentAlignment.MiddleRight
        Me.SubTotalTxt.Value = "0"
        Me.SubTotalTxt.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Location = New System.Drawing.Point(17, 375)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(54, 13)
        Me.Label15.TabIndex = 111
        Me.Label15.Text = "Total Item"
        Me.Label15.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(17, 329)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(31, 13)
        Me.Label12.TabIndex = 109
        Me.Label12.Text = "Total"
        Me.Label12.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(17, 100)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(46, 13)
        Me.Label8.TabIndex = 105
        Me.Label8.Text = "Subtotal"
        Me.Label8.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Tax1Label
        '
        Me.Tax1Label.AutoSize = True
        Me.Tax1Label.Location = New System.Drawing.Point(17, 191)
        Me.Tax1Label.Name = "Tax1Label"
        Me.Tax1Label.Size = New System.Drawing.Size(34, 13)
        Me.Tax1Label.TabIndex = 102
        Me.Tax1Label.Text = "Tax 1"
        Me.Tax1Label.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(17, 145)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(49, 13)
        Me.Label6.TabIndex = 100
        Me.Label6.Text = "Discount"
        Me.Label6.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(17, 283)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(79, 13)
        Me.Label5.TabIndex = 97
        Me.Label5.Text = "Down Payment"
        Me.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BillNo
        '
        Me.BillNo.AutoSize = True
        Me.BillNo.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BillNo.ForeColor = System.Drawing.Color.FromArgb(CType(CType(192, Byte), Integer), CType(CType(0, Byte), Integer), CType(CType(0, Byte), Integer))
        Me.BillNo.Location = New System.Drawing.Point(122, 18)
        Me.BillNo.Name = "BillNo"
        Me.BillNo.Size = New System.Drawing.Size(112, 16)
        Me.BillNo.TabIndex = 14
        Me.BillNo.Text = "MB-0908-00001"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(15, 58)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(51, 13)
        Me.Label3.TabIndex = 13
        Me.Label3.Text = "Customer"
        Me.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(15, 18)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 13)
        Me.Label1.TabIndex = 6
        Me.Label1.Text = "No."
        Me.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(122, 201)
        Me.TextBox1.Multiline = True
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.TextBox1.Size = New System.Drawing.Size(198, 45)
        Me.TextBox1.TabIndex = 114
        '
        'C1Combo3
        '
        Me.C1Combo3.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.C1Combo3.AlternatingRows = True
        Me.C1Combo3.AutoCompletion = True
        Me.C1Combo3.AutoDropDown = True
        Me.C1Combo3.Caption = ""
        Me.C1Combo3.CaptionHeight = 17
        Me.C1Combo3.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.C1Combo3.ColumnCaptionHeight = 17
        Me.C1Combo3.ColumnFooterHeight = 17
        Me.C1Combo3.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.C1Combo3.ContentHeight = 15
        Me.C1Combo3.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.C1Combo3.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.C1Combo3.EditorBackColor = System.Drawing.SystemColors.Window
        Me.C1Combo3.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.C1Combo3.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.C1Combo3.EditorHeight = 15
        Me.C1Combo3.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Combo3.Images.Add(CType(resources.GetObject("C1Combo3.Images"), System.Drawing.Image))
        Me.C1Combo3.ItemHeight = 15
        Me.C1Combo3.Location = New System.Drawing.Point(122, 79)
        Me.C1Combo3.MatchEntryTimeout = CType(100, Long)
        Me.C1Combo3.MaxDropDownItems = CType(5, Short)
        Me.C1Combo3.MaxLength = 32767
        Me.C1Combo3.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.C1Combo3.Name = "C1Combo3"
        Me.C1Combo3.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1Combo3.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.C1Combo3.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1Combo3.Size = New System.Drawing.Size(198, 21)
        Me.C1Combo3.TabIndex = 115
        Me.C1Combo3.Text = "Choose here ..."
        Me.C1Combo3.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.C1Combo3.PropBag = resources.GetString("C1Combo3.PropBag")
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(15, 201)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(0, 13)
        Me.Label11.TabIndex = 113
        Me.Label11.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Location = New System.Drawing.Point(15, 81)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(0, 13)
        Me.Label13.TabIndex = 112
        Me.Label13.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(15, 141)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(0, 13)
        Me.Label10.TabIndex = 116
        Me.Label10.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'C1Combo2
        '
        Me.C1Combo2.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.C1Combo2.AlternatingRows = True
        Me.C1Combo2.AutoCompletion = True
        Me.C1Combo2.AutoDropDown = True
        Me.C1Combo2.Caption = ""
        Me.C1Combo2.CaptionHeight = 17
        Me.C1Combo2.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.C1Combo2.ColumnCaptionHeight = 17
        Me.C1Combo2.ColumnFooterHeight = 17
        Me.C1Combo2.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.C1Combo2.ContentHeight = 15
        Me.C1Combo2.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.C1Combo2.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.C1Combo2.EditorBackColor = System.Drawing.SystemColors.Window
        Me.C1Combo2.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.C1Combo2.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.C1Combo2.EditorHeight = 15
        Me.C1Combo2.ExtendRightColumn = True
        Me.C1Combo2.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Combo2.Images.Add(CType(resources.GetObject("C1Combo2.Images"), System.Drawing.Image))
        Me.C1Combo2.ItemHeight = 15
        Me.C1Combo2.Location = New System.Drawing.Point(122, 141)
        Me.C1Combo2.MatchEntryTimeout = CType(100, Long)
        Me.C1Combo2.MaxDropDownItems = CType(5, Short)
        Me.C1Combo2.MaxLength = 32767
        Me.C1Combo2.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.C1Combo2.Name = "C1Combo2"
        Me.C1Combo2.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1Combo2.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.C1Combo2.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1Combo2.Size = New System.Drawing.Size(198, 21)
        Me.C1Combo2.TabIndex = 117
        Me.C1Combo2.Text = "Choose here ..."
        Me.C1Combo2.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.C1Combo2.PropBag = resources.GetString("C1Combo2.PropBag")
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Location = New System.Drawing.Point(15, 51)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(0, 13)
        Me.Label14.TabIndex = 111
        Me.Label14.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'BTNCancel
        '
        Me.BTNCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNCancel.Image = CType(resources.GetObject("BTNCancel.Image"), System.Drawing.Image)
        Me.BTNCancel.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNCancel.Location = New System.Drawing.Point(314, 518)
        Me.BTNCancel.Name = "BTNCancel"
        Me.BTNCancel.Size = New System.Drawing.Size(94, 41)
        Me.BTNCancel.TabIndex = 109
        Me.BTNCancel.Text = "Close"
        Me.BTNCancel.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNCancel.UseVisualStyleBackColor = True
        Me.BTNCancel.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'BTNSave
        '
        Me.BTNSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNSave.Image = CType(resources.GetObject("BTNSave.Image"), System.Drawing.Image)
        Me.BTNSave.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNSave.Location = New System.Drawing.Point(212, 518)
        Me.BTNSave.Name = "BTNSave"
        Me.BTNSave.Size = New System.Drawing.Size(95, 41)
        Me.BTNSave.TabIndex = 108
        Me.BTNSave.Text = "Save"
        Me.BTNSave.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNSave.UseVisualStyleBackColor = True
        Me.BTNSave.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(15, 171)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(0, 13)
        Me.Label9.TabIndex = 118
        Me.Label9.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'C1NumericEdit1
        '
        Me.C1NumericEdit1.BackColor = System.Drawing.Color.White
        Me.C1NumericEdit1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        '
        '
        '
        Me.C1NumericEdit1.Calculator.BackColor = System.Drawing.Color.FromArgb(CType(CType(227, Byte), Integer), CType(CType(239, Byte), Integer), CType(CType(255, Byte), Integer))
        Me.C1NumericEdit1.Calculator.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.C1NumericEdit1.Calculator.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        Me.C1NumericEdit1.DataType = GetType(Double)
        Me.C1NumericEdit1.EmptyAsNull = True
        Me.C1NumericEdit1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1NumericEdit1.Location = New System.Drawing.Point(122, 171)
        Me.C1NumericEdit1.Name = "C1NumericEdit1"
        Me.C1NumericEdit1.NullText = "1"
        Me.C1NumericEdit1.Size = New System.Drawing.Size(100, 18)
        Me.C1NumericEdit1.TabIndex = 119
        Me.C1NumericEdit1.Tag = Nothing
        Me.C1NumericEdit1.VisibleButtons = C1.Win.C1Input.DropDownControlButtonFlags.DropDown
        Me.C1NumericEdit1.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(15, 111)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(0, 13)
        Me.Label4.TabIndex = 120
        Me.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft
        '
        'C1Combo1
        '
        Me.C1Combo1.AddItemSeparator = Global.Microsoft.VisualBasic.ChrW(59)
        Me.C1Combo1.AlternatingRows = True
        Me.C1Combo1.AutoCompletion = True
        Me.C1Combo1.AutoDropDown = True
        Me.C1Combo1.Caption = ""
        Me.C1Combo1.CaptionHeight = 17
        Me.C1Combo1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal
        Me.C1Combo1.ColumnCaptionHeight = 17
        Me.C1Combo1.ColumnFooterHeight = 17
        Me.C1Combo1.ComboStyle = C1.Win.C1List.ComboStyleEnum.DropdownList
        Me.C1Combo1.ContentHeight = 15
        Me.C1Combo1.DataMode = C1.Win.C1List.DataModeEnum.AddItem
        Me.C1Combo1.DeadAreaBackColor = System.Drawing.Color.Empty
        Me.C1Combo1.EditorBackColor = System.Drawing.SystemColors.Window
        Me.C1Combo1.EditorFont = New System.Drawing.Font("Microsoft Sans Serif", 8.25!)
        Me.C1Combo1.EditorForeColor = System.Drawing.SystemColors.WindowText
        Me.C1Combo1.EditorHeight = 15
        Me.C1Combo1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.C1Combo1.Images.Add(CType(resources.GetObject("C1Combo1.Images"), System.Drawing.Image))
        Me.C1Combo1.ItemHeight = 15
        Me.C1Combo1.Location = New System.Drawing.Point(122, 49)
        Me.C1Combo1.MatchEntryTimeout = CType(100, Long)
        Me.C1Combo1.MaxDropDownItems = CType(5, Short)
        Me.C1Combo1.MaxLength = 32767
        Me.C1Combo1.MouseCursor = System.Windows.Forms.Cursors.Default
        Me.C1Combo1.Name = "C1Combo1"
        Me.C1Combo1.RowDivider.Color = System.Drawing.Color.DarkGray
        Me.C1Combo1.RowDivider.Style = C1.Win.C1List.LineStyleEnum.None
        Me.C1Combo1.RowSubDividerColor = System.Drawing.Color.DarkGray
        Me.C1Combo1.Size = New System.Drawing.Size(198, 21)
        Me.C1Combo1.TabIndex = 121
        Me.C1Combo1.Text = "Choose here ..."
        Me.C1Combo1.VisualStyle = C1.Win.C1List.VisualStyle.Office2007Blue
        Me.C1Combo1.PropBag = resources.GetString("C1Combo1.PropBag")
        '
        'BTNDiscount
        '
        Me.BTNDiscount.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BTNDiscount.Image = CType(resources.GetObject("BTNDiscount.Image"), System.Drawing.Image)
        Me.BTNDiscount.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.BTNDiscount.Location = New System.Drawing.Point(8, 518)
        Me.BTNDiscount.Name = "BTNDiscount"
        Me.BTNDiscount.Size = New System.Drawing.Size(95, 41)
        Me.BTNDiscount.TabIndex = 110
        Me.BTNDiscount.Text = "Discount"
        Me.BTNDiscount.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNDiscount.UseVisualStyleBackColor = True
        Me.BTNDiscount.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'cmdBarcode
        '
        Me.cmdBarcode.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.cmdBarcode.Image = CType(resources.GetObject("cmdBarcode.Image"), System.Drawing.Image)
        Me.cmdBarcode.ImageAlign = System.Drawing.ContentAlignment.TopCenter
        Me.cmdBarcode.Location = New System.Drawing.Point(111, 518)
        Me.cmdBarcode.Name = "cmdBarcode"
        Me.cmdBarcode.Size = New System.Drawing.Size(95, 41)
        Me.cmdBarcode.TabIndex = 151
        Me.cmdBarcode.Text = "Scan Barcode"
        Me.cmdBarcode.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.cmdBarcode.UseVisualStyleBackColor = True
        Me.cmdBarcode.VisualStyleBaseStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        '
        'dtOldDate
        '
        Me.dtOldDate.CalendarTrailingForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.dtOldDate.CustomFormat = "dddd, dd MMMM, yyyy"
        Me.dtOldDate.Enabled = False
        Me.dtOldDate.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.dtOldDate.Location = New System.Drawing.Point(290, 17)
        Me.dtOldDate.Name = "dtOldDate"
        Me.dtOldDate.Size = New System.Drawing.Size(22, 22)
        Me.dtOldDate.TabIndex = 153
        Me.dtOldDate.Visible = False
        '
        'Form_Invoice_Make_Bill
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.Color.AliceBlue
        Me.ClientSize = New System.Drawing.Size(416, 568)
        Me.ControlBox = False
        Me.Controls.Add(Me.cmdBarcode)
        Me.Controls.Add(Me.GroupBox)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.C1Combo3)
        Me.Controls.Add(Me.Label11)
        Me.Controls.Add(Me.Label13)
        Me.Controls.Add(Me.Label10)
        Me.Controls.Add(Me.C1Combo2)
        Me.Controls.Add(Me.Label14)
        Me.Controls.Add(Me.BTNCancel)
        Me.Controls.Add(Me.BTNSave)
        Me.Controls.Add(Me.Label9)
        Me.Controls.Add(Me.C1NumericEdit1)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.C1Combo1)
        Me.Controls.Add(Me.BTNDiscount)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog
        Me.KeyPreview = True
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "Form_Invoice_Make_Bill"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.Manual
        Me.Text = "Invoice - Make Bill"
        Me.GroupBox.ResumeLayout(False)
        Me.GroupBox.PerformLayout()
        CType(Me.lblSetelahRounding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.lblRounding, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tax, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tax2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tax1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tax2ValTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tax1ValTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tax2Txt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalItemTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TotalTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DPtxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.Tax1Txt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DiscountTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.SubTotalTxt, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Combo3, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Combo2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1NumericEdit1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.C1Combo1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents GroupBox As System.Windows.Forms.GroupBox
    Friend WithEvents Tax2 As C1.Win.C1Input.C1Label
    Friend WithEvents Tax1 As C1.Win.C1Input.C1Label
    Friend WithEvents Tax2ValTxt As C1.Win.C1Input.C1Label
    Friend WithEvents Tax1ValTxt As C1.Win.C1Input.C1Label
    Friend WithEvents Tax2Check As System.Windows.Forms.CheckBox
    Friend WithEvents Tax1Check As System.Windows.Forms.CheckBox
    Friend WithEvents Tax2Txt As C1.Win.C1Input.C1Label
    Friend WithEvents Tax2Label As System.Windows.Forms.Label
    Friend WithEvents TotalItemTxt As C1.Win.C1Input.C1Label
    Friend WithEvents TotalTxt As C1.Win.C1Input.C1Label
    Friend WithEvents DPtxt As C1.Win.C1Input.C1Label
    Friend WithEvents Tax1Txt As C1.Win.C1Input.C1Label
    Friend WithEvents DiscountTxt As C1.Win.C1Input.C1Label
    Friend WithEvents SubTotalTxt As C1.Win.C1Input.C1Label
    Friend WithEvents Label15 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents Tax1Label As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents BillNo As System.Windows.Forms.Label
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
    Friend WithEvents C1Combo3 As C1.Win.C1List.C1Combo
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents Label13 As System.Windows.Forms.Label
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents C1Combo2 As C1.Win.C1List.C1Combo
    Friend WithEvents Label14 As System.Windows.Forms.Label
    Friend WithEvents BTNCancel As C1.Win.C1Input.C1Button
    Friend WithEvents BTNSave As C1.Win.C1Input.C1Button
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents C1NumericEdit1 As C1.Win.C1Input.C1NumericEdit
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents C1Combo1 As C1.Win.C1List.C1Combo
    Friend WithEvents BTNDiscount As C1.Win.C1Input.C1Button
    Friend WithEvents Tax As C1.Win.C1Input.C1Label
    Friend WithEvents VirtualKey As C1.Win.C1Input.C1Button
    Friend WithEvents CustName As System.Windows.Forms.TextBox
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents txtRoundingInvisible As System.Windows.Forms.TextBox
    Friend WithEvents cmdCalcRounding As C1.Win.C1Input.C1Button
    Friend WithEvents lblSetelahRounding As C1.Win.C1Input.C1Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents lblRounding As C1.Win.C1Input.C1Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents cmdBarcode As C1.Win.C1Input.C1Button
    Friend WithEvents dtOldDate As System.Windows.Forms.DateTimePicker
End Class
