Imports FirebirdSql.Data.FirebirdClient
Imports C1.Win
Imports C1.Win.C1FlexGrid

Public Class Form_Detail_Menu
    Public idBarang As String = ""
    Public nmMenu As String = ""
    Public harga As String = ""
    Public meas As String = ""
    Public dftItem As String = ""
    Public itemEdit As String
    Public ukuran As String
    Public idSML As String
    Public idDetailSML As String
    Public jmlItem As String = ""
    Public Shared jmlRow As Integer

    Dim tmpItem As String = ""
    Dim arrSML() As String
    Dim arrMOD() As String
    Dim arrDtMod() As String
    Dim SUB_DEL As String = "|#|", DEL_DATA As String = "#|#"
    Dim jmlHalSML As Integer = 0, jmlHalMod As Integer = 0, jmlHalDtMod As Integer = 0
    Dim currPageSML As Integer = -1, currPageMod As Integer = -1, currPageDtMod As Integer = -1
    Dim currSMLSel As String = "", currModSel As String = ""

    Private Sub Form_Detail_Menu_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        grdDtMod.Rows.Count = 1
        Dim tmpArr() As String = Nothing
        Dim rs As FbDataReader
        Dim tmpInven As String = ""
        Dim tmpJmlRow As Integer = 0
        Dim tmpHarga As Double
        rs = MyDatabase.MyReader("SELECT A.INVENUID,A.INVENSIZE,A.INVENNAME,A.INVENDFTPRICELISTLVL,C.* FROM INVEN A INNER JOIN INVENPRICELIST C ON A.INVENUID=C.INVENUID WHERE INVENPARENTUID='" & idBarang & "' ORDER BY INVENDISPLAYORDER ASC")
        While rs.Read = True
            Select Case CInt(rs("INVENDFTPRICELISTLVL"))
                Case 1 : tmpHarga = rs("INVENPRICELISTLVL1")
                Case 2 : tmpHarga = rs("INVENPRICELISTLVL2")
                Case 3 : tmpHarga = rs("INVENPRICELISTLVL3")
                Case 4 : tmpHarga = rs("INVENPRICELISTLVL4")
                Case 5 : tmpHarga = rs("INVENPRICELISTLVL5")
                Case 6 : tmpHarga = rs("INVENPRICELISTLVL6")
                Case 7 : tmpHarga = rs("INVENPRICELISTLVL7")
                Case 8 : tmpHarga = rs("INVENPRICELISTLVL8")
                Case 9 : tmpHarga = rs("INVENPRICELISTLVL9")
                Case 10 : tmpHarga = rs("INVENPRICELISTLVL10")
                Case Else : tmpHarga = "0"
            End Select
            tmpInven = tmpInven & rs("INVENUID") & MY_SUB_DELIMITER & rs("INVENNAME") & MY_SUB_DELIMITER & tmpHarga.ToString & SUB_DEL & rs("INVENSIZE") & DEL_DATA
            tmpJmlRow += 1
        End While
        rs = Nothing
        For Each objButton As Object In gbSML.Controls
            If TypeOf objButton Is C1Input.C1Button Then
                If objButton.name = "cmdSML1" Or objButton.name = "cmdSML2" Or objButton.name = "cmdSML3" Then
                    objButton.text = "-"
                    objButton.tag = "-"
                End If
                objButton.VisualStyle = C1Input.VisualStyle.Office2007Silver
                objButton.Enabled = False
            End If
        Next
        If tmpInven <> "" Then
            arrSML = Split(tmpInven, DEL_DATA)
            jmlHalSML = IIf(tmpJmlRow Mod 3 = 0, tmpJmlRow / 3, Fix(tmpJmlRow / 3) + 1)
            Call fillButtonSML(True)
            lblSML.Text = cmdSML1.Text
            tmpArr = Split(cmdSML1.Tag, MY_SUB_DELIMITER)
            idBarang = tmpArr(0)
            nmMenu = tmpArr(1)
            If Trim(harga) = "" Then harga = tmpArr(2)
        End If

        For Each objButton As Object In gbMod.Controls
            If TypeOf objButton Is C1Input.C1Button Then
                If objButton.name = "cmdMod1" Or objButton.name = "cmdMod2" Or objButton.name = "cmdMod3" Then
                    objButton.text = "-"
                    objButton.tag = "-"
                End If
                objButton.VisualStyle = C1Input.VisualStyle.Office2007Silver
                objButton.Enabled = False
            End If
        Next

        If tmpInven <> "" Then
            tmpArr = Split(cmdSML1.Tag, MY_SUB_DELIMITER)
            Call getDataMod(tmpArr(0))
        Else
            Call getDataMod(idBarang)
        End If
        For Each objButton As Object In gbModDt.Controls
            If TypeOf objButton Is C1Input.C1Button Then
                If IsNumeric(Mid(objButton.name, Len(objButton.name), 1)) = True Then
                    objButton.text = "-"
                    objButton.tag = "-"
                End If
                objButton.VisualStyle = C1Input.VisualStyle.Office2007Silver
                objButton.Enabled = False
            End If
        Next
        If jmlHalMod > 0 Then
            Call fillButtonMOD(True)
            Call getDataModDt(cmdMod1.Tag)
            Call fillButtonDtMod(True)
        End If

        If itemEdit <> "" Then
            tmpArr = Split(itemEdit, vbNewLine & "   +")
            Dim tmpArrDetail() As String = Split(idDetailSML, MY_DELIMITER)
            With grdDtMod
                For i As Integer = 1 To UBound(tmpArr)
                    Dim arrMOD() As String = Split(tmpArrDetail(i - 1), MY_SUB_DELIMITER)
                    If Trim(arrMOD(1)) <> "NULL" Then
                        .AddItem(vbTab & arrMOD(0) & vbTab & IIf(Mid(arrMOD(4), 1, 1) = "+", Mid(arrMOD(4), 2), arrMOD(4)) & vbTab & arrMOD(1) & vbTab & arrMOD(2) & vbTab & arrMOD(3) & vbTab & arrMOD(5) & vbTab & "test") 'arrMOD(6))
                        .Rows(.Rows.Count - 1).Height = 45
                    End If
                Next
            End With
            lblSML.Text = ukuran
            idBarang = idSML
        End If
    End Sub

    Private Sub getDataMod(ByVal idMenu As String)
        currSMLSel = idMenu
        Dim tmpIven As String = ""
        Dim tmpJmlRow As Integer = 0
        jmlHalMod = 0
        arrMOD = Nothing
        Dim rs As FbDataReader
        rs = MyDatabase.MyReader("SELECT A.* FROM ITEMMOD A INNER JOIN INVENITEMMOD B ON A.ITEMMODUID=B.ITEMMODUID WHERE B.INVENUID='" & idMenu & "' ORDER BY ITEMMODNAME ASC") 'AND A.ITEMMODACTV=1
        While rs.Read = True
            tmpIven = tmpIven & rs("ITEMMODUID") & SUB_DEL & rs("ITEMMODNAME") & DEL_DATA
            tmpJmlRow += 1
        End While
        rs = Nothing

        If tmpIven <> "" Then
            arrMOD = Split(tmpIven, DEL_DATA)
            jmlHalMod = IIf(tmpJmlRow Mod 3 = 0, tmpJmlRow / 3, Fix(tmpJmlRow / 3) + 1)
        End If
    End Sub

    Private Sub fillButtonMOD(ByVal isNext As Boolean)
        Dim i As Integer = 0
        Dim arrSMLDetail() As String
        Dim isCmdDownDisabled As Boolean = False
        If isNext = True Then currPageMod += 1 Else currPageMod -= 1
        For Each objButton As Object In gbMod.Controls
            If TypeOf objButton Is C1Input.C1Button Then
                If objButton.name = "cmdMod1" Then
                    arrSMLDetail = Split(arrMOD(currPageMod * 3 + 0), SUB_DEL)
                    objButton.VisualStyle = C1Input.VisualStyle.Office2007Blue
                    objButton.Enabled = True
                    objButton.text = Replace(arrSMLDetail(1), "&", "&&")
                    objButton.tag = arrSMLDetail(0)
                End If
                If objButton.name = "cmdMod2" Then
                    If UBound(arrMOD) >= currPageMod * 3 + 1 Then
                        arrSMLDetail = Split(arrMOD(currPageMod * 3 + 1), SUB_DEL)
                        If Trim(arrSMLDetail(0)) <> "" Then
                            objButton.VisualStyle = C1Input.VisualStyle.Office2007Blue
                            objButton.Enabled = True
                            objButton.text = Replace(arrSMLDetail(1), "&", "&&")
                            objButton.tag = arrSMLDetail(0)
                        Else
                            objButton.VisualStyle = C1Input.VisualStyle.Office2007Silver
                            objButton.Enabled = False
                            objButton.text = "-"
                            objButton.tag = "-"
                            isCmdDownDisabled = True
                        End If
                    Else
                        objButton.VisualStyle = C1Input.VisualStyle.Office2007Silver
                        objButton.Enabled = False
                        objButton.text = "-"
                        objButton.tag = "-"
                        isCmdDownDisabled = True
                    End If
                End If
                If objButton.name = "cmdMod3" Then
                    If UBound(arrMOD) >= currPageMod * 3 + 2 Then
                        arrSMLDetail = Split(arrMOD(currPageMod * 3 + 2), SUB_DEL)
                        If Trim(arrSMLDetail(0)) <> "" Then
                            objButton.VisualStyle = C1Input.VisualStyle.Office2007Blue
                            objButton.Enabled = True
                            objButton.text = Replace(arrSMLDetail(1), "&", "&&")
                            objButton.tag = arrSMLDetail(0)
                        Else
                            objButton.VisualStyle = C1Input.VisualStyle.Office2007Silver
                            objButton.Enabled = False
                            objButton.text = "-"
                            objButton.tag = "-"
                            isCmdDownDisabled = True
                        End If
                    Else
                        objButton.VisualStyle = C1Input.VisualStyle.Office2007Silver
                        objButton.Enabled = False
                        objButton.text = "-"
                        objButton.tag = "-"
                        isCmdDownDisabled = True
                    End If
                End If
            End If
        Next
        If currPageMod = 0 Then
            cmdBackMod.VisualStyle = C1Input.VisualStyle.Office2007Silver
            cmdBackMod.Enabled = False
        Else
            cmdBackMod.VisualStyle = C1Input.VisualStyle.Office2007Blue
            cmdBackMod.Enabled = True
        End If
        If isCmdDownDisabled = True Then
            cmdNextMod.VisualStyle = C1Input.VisualStyle.Office2007Silver
            cmdNextMod.Enabled = False
            Exit Sub
        End If
        If currPageMod + 1 >= jmlHalMod Then
            cmdNextMod.VisualStyle = C1Input.VisualStyle.Office2007Silver
            cmdNextMod.Enabled = False
        Else
            cmdNextMod.VisualStyle = C1Input.VisualStyle.Office2007Blue
            cmdNextMod.Enabled = True
        End If
    End Sub

    Private Sub fillButtonSML(ByVal isNext As Boolean)
        Dim i As Integer = 0
        Dim arrSMLDetail() As String
        Dim isCmdDownDisabled As Boolean = False
        If isNext = True Then currPageSML += 1 Else currPageSML -= 1
        For Each objButton As Object In gbSML.Controls
            If TypeOf objButton Is C1Input.C1Button Then
                If objButton.name = "cmdSML1" Then
                    arrSMLDetail = Split(arrSML(currPageSML * 3 + 0), SUB_DEL)
                    objButton.VisualStyle = C1Input.VisualStyle.Office2007Blue
                    objButton.Enabled = True
                    objButton.text = Replace(arrSMLDetail(1), "&", "&&")
                    objButton.tag = arrSMLDetail(0)
                End If
                If objButton.name = "cmdSML2" Then
                    If UBound(arrSML) >= currPageSML * 3 + 1 Then
                        arrSMLDetail = Split(arrSML(currPageSML * 3 + 1), SUB_DEL)
                        If Trim(arrSMLDetail(0)) <> "" Then
                            objButton.VisualStyle = C1Input.VisualStyle.Office2007Blue
                            objButton.Enabled = True
                            objButton.text = Replace(arrSMLDetail(1), "&", "&&")
                            objButton.tag = arrSMLDetail(0)
                        Else
                            objButton.VisualStyle = C1Input.VisualStyle.Office2007Silver
                            objButton.Enabled = False
                            objButton.text = "-"
                            objButton.tag = "-"
                            isCmdDownDisabled = True
                        End If
                    Else
                        objButton.VisualStyle = C1Input.VisualStyle.Office2007Silver
                        objButton.Enabled = False
                        objButton.text = "-"
                        objButton.tag = "-"
                        isCmdDownDisabled = True
                    End If
                End If
                If objButton.name = "cmdSML3" Then
                    If UBound(arrSML) >= currPageSML * 3 + 2 Then
                        arrSMLDetail = Split(arrSML(currPageSML * 3 + 2), SUB_DEL)
                        If Trim(arrSMLDetail(0)) <> "" Then
                            objButton.VisualStyle = C1Input.VisualStyle.Office2007Blue
                            objButton.Enabled = True
                            objButton.text = Replace(arrSMLDetail(1), "&", "&&")
                            objButton.tag = arrSMLDetail(0)
                        Else
                            objButton.VisualStyle = C1Input.VisualStyle.Office2007Silver
                            objButton.Enabled = False
                            objButton.text = "-"
                            objButton.tag = "-"
                            isCmdDownDisabled = True
                        End If
                    Else
                        objButton.VisualStyle = C1Input.VisualStyle.Office2007Silver
                        objButton.Enabled = False
                        objButton.text = "-"
                        objButton.tag = "-"
                        isCmdDownDisabled = True
                    End If
                End If
            End If
        Next
        If currPageSML = 0 Then
            cmdUpSML.VisualStyle = C1Input.VisualStyle.Office2007Silver
            cmdUpSML.Enabled = False
        Else
            cmdUpSML.VisualStyle = C1Input.VisualStyle.Office2007Blue
            cmdUpSML.Enabled = True
        End If
        If isCmdDownDisabled = True Then
            cmdDownSML.VisualStyle = C1Input.VisualStyle.Office2007Silver
            cmdDownSML.Enabled = False
            Exit Sub
        End If
        If currPageSML + 1 >= jmlHalSML Then
            cmdDownSML.VisualStyle = C1Input.VisualStyle.Office2007Silver
            cmdDownSML.Enabled = False
        Else
            cmdDownSML.VisualStyle = C1Input.VisualStyle.Office2007Blue
            cmdDownSML.Enabled = True
        End If
    End Sub

    Private Sub cmdBatal_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBatal.Click
        currPageSML = -1 : currPageMod = -1 : currPageDtMod = -1
        Me.Close()
    End Sub

    Private Sub cmdDownSML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdDownSML.Click
        Call fillButtonSML(True)
    End Sub

    Private Sub cmdUpSML_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdUpSML.Click
        Call fillButtonSML(False)
    End Sub

    Private Sub cmdSML1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdSML1.Click, cmdSML2.Click, cmdSML3.Click
        If currSMLSel = CStr(sender.tag) Then Exit Sub
        Dim tmpArr() As String
        lblSML.Text = sender.text
        grdDtMod.Rows.Count = 1
        currPageMod = -1
        For Each objButton As Object In gbMod.Controls
            If TypeOf objButton Is C1Input.C1Button Then
                If objButton.name = "cmdMod1" Or objButton.name = "cmdMod2" Or objButton.name = "cmdMod3" Then
                    objButton.text = "-"
                    objButton.tag = "-"
                End If
                objButton.VisualStyle = C1Input.VisualStyle.Office2007Silver
                objButton.Enabled = False
            End If
        Next

        tmpArr = Split(sender.Tag, MY_SUB_DELIMITER)
        idBarang = tmpArr(0)
        nmMenu = tmpArr(1)
        harga = tmpArr(2)
        Call getDataMod(tmpArr(0))

        If jmlHalMod > 0 Then
            Call fillButtonMOD(True)
            Call getDataModDt(cmdMod1.Tag)
            Call fillButtonDtMod(True)
        Else
            For i As Integer = 1 To 15
                For Each objButton As Object In gbModDt.Controls
                    If TypeOf objButton Is C1Input.C1Button And CStr(objButton.name) = "cmdModDt" & CStr(i) Then                        
                        objButton.text = "-"
                        objButton.tag = "-"
                        objButton.VisualStyle = C1Input.VisualStyle.Office2007Silver
                        objButton.Enabled = False
                        Exit For
                    End If
                Next
            Next
        End If
    End Sub

    Private Sub cmdNextMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextMod.Click
        Call fillButtonMOD(True)
    End Sub

    Private Sub cmdBackMod_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackMod.Click
        Call fillButtonMOD(False)
    End Sub

    Private Sub cmdMod1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdMod1.Click, cmdMod2.Click, cmdMod3.Click
        Call getDataModDt(sender.tag)
        Call fillButtonDtMod(True)
    End Sub

    Private Sub getDataModDt(ByVal idMod As String)
        currModSel = idMod
        Dim tmpIven As String = ""
        Dim tmpJmlRow As Integer = 0
        currPageDtMod = -1
        jmlHalDtMod = 0
        arrDtMod = Nothing
        Dim rs As FbDataReader
        rs = MyDatabase.MyReader("SELECT ITEMMODDTUID,ITEMMODDTDESC,ITEMMODDTTYPE,IIF(ITEMMODDTITEMUID IS NULL,'-',ITEMMODDTITEMUID) AS ITEMMODDTITEMUID,IIF(INVENMEASUNITDESC IS NULL,'-',INVENMEASUNITDESC) AS INVENMEASUNITDESC FROM ITEMMODDT LEFT JOIN INVEN ON ITEMMODDTITEMUID=INVENUID WHERE ITEMMODUID='" & idMod & "' ORDER BY ITEMMODDTDESC ASC") 'AND A.ITEMMODACTV=1
        While rs.Read = True
            tmpIven = tmpIven & rs("ITEMMODDTUID") & SUB_DEL & rs("ITEMMODDTDESC") & SUB_DEL & rs("ITEMMODDTTYPE") & SUB_DEL & rs("ITEMMODDTITEMUID") & SUB_DEL & rs("INVENMEASUNITDESC") & DEL_DATA
            tmpJmlRow += 1
        End While
        rs = Nothing

        If tmpIven <> "" Then            
            arrDtMod = Split(tmpIven, DEL_DATA)
            jmlHalDtMod = IIf(tmpJmlRow Mod 15 = 0, tmpJmlRow / 15, Fix(tmpJmlRow / 15) + 1)
        End If
    End Sub

    Private Sub fillButtonDtMod(ByVal isNext As Boolean)
        Dim arrSMLDetail() As String = Nothing
        Dim isCmdDownDisabled As Boolean = False
        If isNext = True Then currPageDtMod += 1 Else currPageDtMod -= 1
        For i As Integer = 1 To 15
            For Each objButton As Object In gbModDt.Controls
                If TypeOf objButton Is C1Input.C1Button And CStr(objButton.name) = "cmdModDt" & CStr(i) Then
                    If UBound(arrDtMod) >= currPageDtMod * 15 + (i - 1) Then                        
                        arrSMLDetail = Split(arrDtMod(currPageDtMod * 15 + (i - 1)), SUB_DEL)
                        If Trim(arrSMLDetail(0)) <> "" Then
                            objButton.VisualStyle = C1Input.VisualStyle.Office2007Blue
                            objButton.Enabled = True
                            objButton.text = Replace(arrSMLDetail(1), "&", "&&")
                            objButton.tag = arrSMLDetail(0) & MY_SUB_DELIMITER & arrSMLDetail(2) & MY_SUB_DELIMITER & arrSMLDetail(3) & MY_SUB_DELIMITER & arrSMLDetail(4)
                        Else
                            objButton.text = "-"
                            objButton.tag = "-"
                            objButton.VisualStyle = C1Input.VisualStyle.Office2007Silver
                            objButton.Enabled = False
                            isCmdDownDisabled = True
                        End If
                    Else
                        objButton.text = "-"
                        objButton.tag = "-"
                        objButton.VisualStyle = C1Input.VisualStyle.Office2007Silver
                        objButton.Enabled = False
                        isCmdDownDisabled = True
                    End If
                    Exit For
                End If
            Next
        Next
        If currPageDtMod = 0 Then
            cmdBackModDt.VisualStyle = C1Input.VisualStyle.Office2007Silver
            cmdBackModDt.Enabled = False
        Else
            cmdBackModDt.VisualStyle = C1Input.VisualStyle.Office2007Blue
            cmdBackModDt.Enabled = True
        End If
        If isCmdDownDisabled = True Then
            cmdNextModDt.VisualStyle = C1Input.VisualStyle.Office2007Silver
            cmdNextModDt.Enabled = False
            Exit Sub
        End If
        If currPageDtMod + 1 >= jmlHalDtMod Then
            cmdNextModDt.VisualStyle = C1Input.VisualStyle.Office2007Silver
            cmdNextModDt.Enabled = False
        Else
            cmdNextModDt.VisualStyle = C1Input.VisualStyle.Office2007Blue
            cmdNextModDt.Enabled = True
        End If
    End Sub

    Private Sub cmdModDt1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdModDt1.Click, cmdModDt2.Click, cmdModDt3.Click, cmdModDt4.Click, cmdModDt5.Click, cmdModDt6.Click, cmdModDt7.Click, cmdModDt8.Click, cmdModDt9.Click, cmdModDt10.Click, cmdModDt11.Click, cmdModDt12.Click, cmdModDt13.Click, cmdModDt14.Click, cmdModDt15.Click
        With grdDtMod
            'If isModDtExist(currModSel) = True Then Exit Sub
            Dim arrData() As String = Split(sender.tag, MY_SUB_DELIMITER)
            .AddItem(vbTab & arrData(0) & vbTab & sender.text & vbTab & currModSel & vbTab & arrData(1) & vbTab & arrData(2) & vbTab & arrData(3))
            .Rows(.Rows.Count - 1).Height = 45
        End With
    End Sub

    Private Function isModDtExist(ByVal idDetail As String) As Boolean
        Dim i As Integer
        With grdDtMod
            For i = 1 To .Rows.Count - 1
                If idDetail = CStr(.Item(i, "modid")) Then Return True
            Next
        End With
    End Function

    Private Sub cmdNextModDt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdNextModDt.Click
        Call fillButtonDtMod(True)
    End Sub

    Private Sub cmdBackModDt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdBackModDt.Click
        Call fillButtonDtMod(False)
    End Sub

    Private Sub cmdRemove_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdRemove.Click
        With grdDtMod
            If .Rows.Count = 1 Then Exit Sub
            Dim msgForm As New Form_Message_Box_Question
            msgForm.Name = "Form_Message_Box_Question"
            msgForm.QuestionLabel.Text = "Apakah Anda akan menghapus modifier '" & .Item(.Row, "nama") & "' dari daftar ?"
            msgForm.ShowDialog()
            If msgForm.Yes = False Then Exit Sub
            .RemoveItem(.Row)
        End With
    End Sub

    Private Sub BTNOK_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmdOK.Click
        currPageSML = -1 : currPageMod = -1 : currPageDtMod = -1
        Dim tmpJmlText As Integer = 0
        Dim tmpDetail As String = ""
        With grdDtMod
            For i As Integer = 1 To .Rows.Count - 1
                tmpDetail = tmpDetail & Trim(.Item(i, "id")) & MY_SUB_DELIMITER & Trim(.Item(i, "modid")) & MY_SUB_DELIMITER & Trim(.Item(i, "tipe")) & MY_SUB_DELIMITER & Trim(.Item(i, "kodebarang")) & MY_SUB_DELIMITER & Trim(.Item(i, "nama")) & MY_SUB_DELIMITER & Trim(.Item(i, "satuan")) & MY_SUB_DELIMITER & Trim(.Item(i, "iddetail")) & MY_DELIMITER
                If CStr(.Item(i, "tipe")) = "0" Then
                    nmMenu = nmMenu & vbNewLine & "   +" & .Item(i, "nama")               
                    tmpJmlText += 1
                End If
            Next
            jmlRow = tmpJmlText
        End With
        Dim tmpTotalHarga As Decimal = 0
        tmpTotalHarga = CDec(IIf(jmlItem = "", "1", jmlItem)) * CDec(harga)
        dftItem = vbTab & idBarang & vbTab & IIf(jmlItem = "", "1", jmlItem) & vbTab & nmMenu & vbTab & harga & vbTab & tmpTotalHarga & vbTab & vbTab & vbTab & vbTab & vbTab & vbTab & "2" & vbTab & meas & vbTab & tmpDetail
        Me.Close()
    End Sub


End Class