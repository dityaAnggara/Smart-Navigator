Imports FirebirdSql.Data.FirebirdClient
Imports System.IO

Public Class Edit_Detail_Paket
    Public idMenu As String = ""
    Public idDetailReserv As String = ""
    Public formAsal As Form
    Private Sub BTNReset_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNReset.Click
        idMenu = ""
        Me.Close()
    End Sub

    Public Sub ADDItem(ByVal ItemList As ArrayList)
        With MenuDetail
            For i As Integer = 1 To .Rows.Count - 1
                If .Item(i, 1) = ItemList(0) Then
                    ShowMessage(Me, "Maaf, item yang anda tambahkan sudah ada dalam daftar !")
                    Exit Sub
                End If
            Next
            .AddItem(vbTab & ItemList(0) & vbTab & ItemList(2) & vbTab & ItemList(3) & vbTab & "1" & vbTab & ItemList(4))
            .Rows(.Rows.Count - 1).Height = 50
        End With
    End Sub

    Private Sub Edit_Detail_Paket_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.Load
        Dim rs As FbDataReader      
        rs = MyDatabase.MyReader("SELECT * FROM INVEN WHERE INVENUID='" & idMenu & "'")
        If rs.Read() = True Then
            InvenNoTxt.Text = rs("INVENNO")
            InvenNameTxt.Text = rs("INVENNAME")
        End If
        rs = Nothing
        Call MenuDetailInitialize(idMenu)
    End Sub

    Private Sub MenuDetailInitialize(ByVal MenuUID As String)
        Dim TMPRecord As FbDataReader
        Dim Query As String = Nothing
        'Query = "SELECT a.INVENDTUID, a.INVENUID,(SELECT INVENNAME FROM INVEN WHERE INVENUID = a.INVENDTITEMUID) AS INVENNAME, a.ITEMMEASUNITUID, a.ITEMSMALLMEASUNITUID, a.ITEMMEASUNITDESC, a.ITEMQTY, a.ITEMSMALLQTY, a.INVENDTITEMUID, (SELECT INVENCATNAME FROM INVENCAT WHERE INVENCATUID = (SELECT INVENCATUID FROM INVEN WHERE INVENUID = a.INVENDTITEMUID)) AS INVENCATNAME FROM INVENDT a ON a. WHERE INVENUID = '" & MenuUID & "'"
        Query = "SELECT RSVTRANSDTDETAIL.*,(SELECT INVENCATNAME FROM INVENCAT WHERE INVENCATUID = (SELECT INVENCATUID FROM INVEN WHERE INVENUID = RSVTRANSDTITEMUID)) AS INVENCATNAME FROM RSVTRANSDTDETAIL WHERE RSVTRANSDTUID='" & idDetailReserv & "'"
        TMPRecord = MyDatabase.MyReader(Query)
        With MenuDetail
            .Rows.Count = 1
            While TMPRecord.Read
                '.AddItem(vbTab & TMPRecord.Item("INVENDTITEMUID") & vbTab & TMPRecord.Item("INVENNAME") & vbTab & TMPRecord.Item("INVENCATNAME") & vbTab & TMPRecord.Item("ITEMQTY") & vbTab & TMPRecord.Item("ITEMMEASUNITDESC"))
                .AddItem(vbTab & TMPRecord.Item("RSVTRANSDTITEMUID") & vbTab & TMPRecord.Item("RSVTRANSDTITEMNAME") & vbTab & TMPRecord.Item("INVENCATNAME") & vbTab & TMPRecord.Item("RSVTRANSDTITEMQTY") & vbTab & TMPRecord.Item("RSVTRANSDTITEMMEASUNITDESC"))
                .Rows(.Rows.Count - 1).Height = 50
            End While : MyDatabase.ConnectionDatabase.Close()
        End With
    End Sub

    Private Sub ADDButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ADDButton.Click       
        Me.Cursor = Cursors.WaitCursor
        Dim OBJNew As New Master_List_Menu
        OBJNew.Name = "Master_List_Menu"
        OBJNew.ParentOBJForm = Me
        'OBJNew.ItemLevel = CategoryList.Columns(2).Text
        OBJNew.ShowDialog()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub C1Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button1.Click
        MenuDetail.Item(MenuDetail.Row, 4) = CInt(MenuDetail.Item(MenuDetail.Row, 4)) + 1
    End Sub

    Private Sub C1Button2_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles C1Button2.Click
        If CInt(MenuDetail.Item(MenuDetail.Row, 4)) - 1 <= 0 Then Exit Sub
        MenuDetail.Item(MenuDetail.Row, 4) = CInt(MenuDetail.Item(MenuDetail.Row, 4)) - 1
    End Sub

    Private Sub REMOVEButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles REMOVEButton.Click
        If MenuDetail.Row > 0 Then
            If ShowQuestion(Me, "Hapus item '" & MenuDetail.Item(MenuDetail.Row, 2) & "' dari daftar ?") = True Then
                MenuDetail.RemoveItem(MenuDetail.Row)
            End If
        Else
            ShowMessage(Me, "Silakan klik pada item terlebih dahulu, sebelum melakukan proses HAPUS !")
        End If
    End Sub

    Private Sub BTNSave_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNSave.Click
        If formAsal.Name = "Form_Reservation_Make_Order_Image" Then
            With Form_Reservation_Make_Order_Image
                For i As Integer = .colOrderDetailPaket.Count To 1 Step -1
                    Dim ListArray As New ArrayList
                    ListArray = .colOrderDetailPaket(i)
                    If ListArray(5) = idDetailReserv Then
                        .colOrderDetailPaket.Remove(i)
                    End If
                Next
            End With
            Dim colDetailpaket As New Collection
            With MenuDetail
                For i As Integer = 1 To .Rows.Count - 1
                    Dim tmpArr As New ArrayList
                    tmpArr.Add(.Item(i, 1))
                    tmpArr.Add(.Item(i, 2))
                    tmpArr.Add(.Item(i, 3))
                    tmpArr.Add(.Item(i, 4))
                    tmpArr.Add(.Item(i, 5))
                    tmpArr.Add(idDetailReserv)
                    Form_Reservation_Make_Order_Image.colOrderDetailPaket.Add(tmpArr)
                Next
            End With
        ElseIf formAsal.Name = "Form_Reservation_Make_Order" Then
            With Form_Reservation_Make_Order
                For i As Integer = .colOrderDetailPaket.Count To 1 Step -1
                    Dim ListArray As New ArrayList
                    ListArray = .colOrderDetailPaket(i)
                    If ListArray(5) = idDetailReserv Then
                        .colOrderDetailPaket.Remove(i)
                    End If
                Next
            End With            
            With MenuDetail
                For i As Integer = 1 To .Rows.Count - 1
                    Dim tmpArr As New ArrayList
                    tmpArr.Add(.Item(i, 1))
                    tmpArr.Add(.Item(i, 2))
                    tmpArr.Add(.Item(i, 3))
                    tmpArr.Add(.Item(i, 4))
                    tmpArr.Add(.Item(i, 5))
                    tmpArr.Add(idDetailReserv)
                    Form_Reservation_Make_Order.colOrderDetailPaket.Add(tmpArr)
                Next                
            End With
        End If
        Me.Close()
    End Sub
End Class