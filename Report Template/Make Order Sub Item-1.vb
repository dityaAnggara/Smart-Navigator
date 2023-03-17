Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document 

Public Class Make_Order_Sub_Item 

    Dim mIsPrintNote As String = "False"
    Dim iRow As Long = 0
    Public Shared publicMustPrintNotes As Boolean = False

    Private Sub Detail1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Detail1.Format
       
        If Label1.Text = "" Then
            Label1.Visible = False
            TextBox1.Visible = False
            Detail1.Height = 0
        Else
            Label1.Visible = True
            TextBox1.Visible = True
            Detail1.Height = 0.2
        End If
        If PrefInfo.PRINTQUANTITYDETAILPACKET = "0" Then
            Label1.Visible = False
        End If
        If Me.iRow Mod 2 = 1 Then
            Me.Detail1.BackColor = Color.White
        Else
            Me.Detail1.BackColor = Color.White
            'Me.Detail1.BackColor = Color.AliceBlue
        End If
        Me.iRow = Me.iRow + 1
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format

        If txtTA.Text = "1" Then
            txtTakeAway.Visible = True
        Else
            txtTakeAway.Visible = False
        End If

        If mIsPrintNote = "True" Then
            If Trim(txtNoteHidden.Text) = "" Then
                txtNote.Visible = False
                GroupHeader1.Height = 0.198
            Else
                txtNote.Text = "NOTES : " & txtNoteHidden.Text
                txtNote.Visible = True
                GroupHeader1.Height = 0.375
            End If
        Else
            txtNote.Visible = False
            GroupHeader1.Height = 0.198
        End If

    End Sub

    Private Sub Make_Order_Sub_Item_ReportEnd(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportEnd

        publicMustPrintNotes = False

    End Sub

    Private Sub Make_Order_Sub_Item_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart

        If PrefInfo.PrintMakeOrderNotes = "0" Then
            mIsPrintNote = "False"
        Else
            mIsPrintNote = "True"
        End If

        If mIsPrintNote = "False" Then
            If publicMustPrintNotes = True Then mIsPrintNote = "True"
        End If

    End Sub
End Class
