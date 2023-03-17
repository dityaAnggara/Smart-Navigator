<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form_Test_Gambar
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
    Me.Button1 = New System.Windows.Forms.Button
    Me.TextBox1 = New System.Windows.Forms.TextBox
    Me.Button2 = New System.Windows.Forms.Button
    Me.BrowserPicForCust = New System.Windows.Forms.FolderBrowserDialog
    Me.PictureBox1 = New System.Windows.Forms.PictureBox
    Me.ImageList1 = New System.Windows.Forms.ImageList(Me.components)
    Me.ListView1 = New System.Windows.Forms.ListView
    Me.ListBox1 = New System.Windows.Forms.ListBox
    Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
    Me.SuspendLayout()
    '
    'Button1
    '
    Me.Button1.Location = New System.Drawing.Point(315, 27)
    Me.Button1.Name = "Button1"
    Me.Button1.Size = New System.Drawing.Size(32, 23)
    Me.Button1.TabIndex = 0
    Me.Button1.Text = "....."
    Me.Button1.UseVisualStyleBackColor = True
    '
    'TextBox1
    '
    Me.TextBox1.Location = New System.Drawing.Point(12, 30)
    Me.TextBox1.Name = "TextBox1"
    Me.TextBox1.Size = New System.Drawing.Size(297, 20)
    Me.TextBox1.TabIndex = 1
    '
    'Button2
    '
    Me.Button2.Location = New System.Drawing.Point(354, 27)
    Me.Button2.Name = "Button2"
    Me.Button2.Size = New System.Drawing.Size(75, 23)
    Me.Button2.TabIndex = 2
    Me.Button2.Text = "Regist"
    Me.Button2.UseVisualStyleBackColor = True
    '
    'BrowserPicForCust
    '
    Me.BrowserPicForCust.RootFolder = System.Environment.SpecialFolder.MyComputer
    '
    'PictureBox1
    '
    Me.PictureBox1.Location = New System.Drawing.Point(7, 105)
    Me.PictureBox1.Name = "PictureBox1"
    Me.PictureBox1.Size = New System.Drawing.Size(805, 310)
    Me.PictureBox1.TabIndex = 3
    Me.PictureBox1.TabStop = False
    '
    'ImageList1
    '
    Me.ImageList1.ColorDepth = System.Windows.Forms.ColorDepth.Depth32Bit
    Me.ImageList1.ImageSize = New System.Drawing.Size(80, 80)
    Me.ImageList1.TransparentColor = System.Drawing.Color.Transparent
    '
    'ListView1
    '
    Me.ListView1.Location = New System.Drawing.Point(451, 12)
    Me.ListView1.Name = "ListView1"
    Me.ListView1.Size = New System.Drawing.Size(361, 87)
    Me.ListView1.TabIndex = 4
    Me.ListView1.UseCompatibleStateImageBehavior = False
    Me.ListView1.View = System.Windows.Forms.View.SmallIcon
    '
    'ListBox1
    '
    Me.ListBox1.FormattingEnabled = True
    Me.ListBox1.Location = New System.Drawing.Point(135, 57)
    Me.ListBox1.Name = "ListBox1"
    Me.ListBox1.Size = New System.Drawing.Size(294, 30)
    Me.ListBox1.TabIndex = 5
    '
    'Timer1
    '
    Me.Timer1.Enabled = True
    Me.Timer1.Interval = 1000
    '
    'Form_Test_Gambar
    '
    Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
    Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
    Me.ClientSize = New System.Drawing.Size(824, 427)
    Me.Controls.Add(Me.ListBox1)
    Me.Controls.Add(Me.PictureBox1)
    Me.Controls.Add(Me.Button2)
    Me.Controls.Add(Me.TextBox1)
    Me.Controls.Add(Me.Button1)
    Me.Controls.Add(Me.ListView1)
    Me.Name = "Form_Test_Gambar"
    Me.Text = "Form_Test_Gambar"
    CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
    Me.ResumeLayout(False)
    Me.PerformLayout()

  End Sub
  Friend WithEvents Button1 As System.Windows.Forms.Button
  Friend WithEvents TextBox1 As System.Windows.Forms.TextBox
  Friend WithEvents Button2 As System.Windows.Forms.Button
  Friend WithEvents BrowserPicForCust As System.Windows.Forms.FolderBrowserDialog
  Friend WithEvents PictureBox1 As System.Windows.Forms.PictureBox
  Friend WithEvents ImageList1 As System.Windows.Forms.ImageList
  Friend WithEvents ListView1 As System.Windows.Forms.ListView
  Friend WithEvents ListBox1 As System.Windows.Forms.ListBox
  Friend WithEvents Timer1 As System.Windows.Forms.Timer
End Class
