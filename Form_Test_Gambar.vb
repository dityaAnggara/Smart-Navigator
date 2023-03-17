Imports System.IO

Public Class Form_Test_Gambar

  Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click

    'TextBox1.Text = BrowserPicForCust.SelectedPath
    If BrowserPicForCust.ShowDialog = Windows.Forms.DialogResult.OK Then
      For Each listFiles As String In Directory.GetFiles(BrowserPicForCust.SelectedPath)
        ListView1.Items.Add(Path.GetFileName(listFiles))
        ListBox1.Items.Add(listFiles)
      Next
    End If

  End Sub


  Private Sub Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button2.Click
    
    'ListBox1.SetSelected(1, True)
    'PictureBox1.Image = Image.FromFile(ListBox1.SelectedItem.ToString())
    'Dim x As Integer
    'For x = ListBox1.SelectedIndex - 1 To 0 Step -1
    '  ListBox1.Items.RemoveAt(x)
    'Next x
    'MessageBox.Show(ListBox1.Items.Count.ToString)
  End Sub

  
  'Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
  '  Me.ListBox1.Items.Clear()
  '  Me.PictureBox1.ImageLocation = " "
  '  For Each foundImage As String In My.Computer.FileSystem.GetFiles("C:\Users\Public\Pictures\Sample Pictures")
  '    Me.ListBox1.Items.Add(foundImage)
  '  Next
  'End Sub

  'Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
  '  Me.PictureBox1.ImageLocation = Me.ListBox1.SelectedItem
  '  PictureBox1.Image = Image.FromFile(Me.ListBox1.SelectedItem.ToString())
  'End Sub

  
  Private Sub listbox1_selectedindexchanged(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged
    picturebox1.image = image.fromfile(listbox1.selecteditem.tostring())
  End Sub

  Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
    If ListBox1.Items.Count <= 0 Then Exit Sub
    If ListBox1.SelectedIndex < ListBox1.Items.Count - 1 Then
      ListBox1.SetSelected(ListBox1.SelectedIndex + 1, True)
      PictureBox1.Image = Image.FromFile(ListBox1.SelectedItem.ToString())
    Else
      ListBox1.SetSelected(0, True)
    End If

    'If ListBox1.Items.Count > 0 Then
    '  For td As Integer = 1 To ListBox1.Items.Count - 1
    '    ListBox1.SetSelected(td, True)
    '    PictureBox1.Image = Image.FromFile(ListBox1.SelectedItem.ToString())
    '  Next
    'End If
    
  End Sub
End Class