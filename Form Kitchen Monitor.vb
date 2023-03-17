Imports System
Imports C1.Win
Imports C1.Win.C1FlexGrid
Imports System.Windows.Forms
Imports System.Threading
Imports System.Globalization
Imports System.Security.Permissions
Imports System.Runtime.InteropServices
Imports FirebirdSql.Data.FirebirdClient

Public Class Form_Kitchen_Monitor

#Region "Variable Reference"

    Private Declare Function GetLastInputInfo Lib "User32.dll" (ByRef lastInput As LASTINPUTINFO) As Boolean

    Public Structure LASTINPUTINFO

        Public cbSize As Int32
        Public dwTime As Int32

    End Structure

    Public KitchenMonitorInvoice As Boolean = False
    Dim UserPermition As New UserPermitionLib
    Dim ListCollection As New Collection
    Dim DumpCollection As New Collection
    Dim FormStatus As FormStatusLib
    Dim HeaderName As String = Nothing
    Dim Sort As String = Nothing
    Dim SelectTable As String = Nothing
    Dim PrintUID1 As String = Nothing
    Dim PrintUID2 As String = Nothing
    Dim PrintUID As String = Nothing
    Dim listUID As String, oldListUID As String
    Dim detectedUserAction As Boolean = False

    Dim timerTick As Integer = 0

#End Region

#Region "Initialize & Object Function"

    Private Sub BasicInitialize()

        listUID = ""

        If KitchenList.Text = "Choose here ..." Then Exit Sub

        Me.Cursor = Cursors.WaitCursor
        If HeaderName = Nothing Then
            HeaderName = "TABLELISTNAME"
        End If

        If Sort = Nothing Then
            Sort = "ASC"
        End If

        Dim TMPRecord As FbDataReader
        Dim Query As String

        With ListDetail
            .Rows.Count = 1
            .Refresh()
            .Redraw = False
            .Styles("Normal").WordWrap = True

            'Query = "SELECT MB.MBTRANSCUSTNAME, MB.MBTRANSUID,I.INVENNO,DT.MBTRANSDTUID AS PAKETUID,T.TABLELISTNAME," & _
            '        "CASE I.INVENLEVEL WHEN 3 THEN DET.MBTRANSDTDETAILUID ELSE DT.MBTRANSDTUID END AS MBTRANSDTUID," & _
            '        "CASE I.INVENLEVEL WHEN 3 THEN II.INVENKITCHENUID ELSE I.INVENKITCHENUID END AS INVENKITCHENUID," & _
            '        "CASE I.INVENLEVEL WHEN 3 THEN DET.MBTRANSDTITEMQTY ELSE DT.MBTRANSDTITEMQTY END AS MBTRANSDTITEMQTY," & _
            '        "CASE I.INVENLEVEL WHEN 3 THEN I.INVENNAME|| '-' ||DET.MBTRANSDTITEMNAME ELSE DT.MBTRANSDTITEMNAME END AS MBTRANSDTITEMNAME," & _
            '        "CASE I.INVENLEVEL WHEN 3 THEN DET.MBTRANSDTITEMSTAT ELSE DT.MBTRANSDTITEMSTAT END AS MBTRANSDTITEMSTAT," & _
            '        "CASE I.INVENLEVEL WHEN 3 THEN DT.MBTRANSDTITEMNOTE ELSE DT.MBTRANSDTITEMNOTE END AS MBTRANSDTITEMNOTE," & _
            '        "CASE I.INVENLEVEL WHEN 3 THEN DT.MBTRANSDTISTAKEAWAY ELSE DT.MBTRANSDTISTAKEAWAY END AS MBTRANSDTISTAKEAWAY," & _
            '        "CASE I.INVENLEVEL WHEN 3 THEN '1' ELSE '0' END AS STATUS,DT.CREATEDDATETIME,DT.MODIFIEDUSER " & _
            '        "FROM MBTRANSDT DT LEFT OUTER JOIN MBTRANSDTDETAIL DET ON DT.MBTRANSDTUID=DET.MBTRANSDTUID " & _
            '        "LEFT OUTER JOIN INVEN I ON I.INVENUID = DT.MBTRANSDTITEMUID " & _
            '        "LEFT OUTER JOIN INVEN II ON II.INVENUID = DET.MBTRANSDTITEMUID " & _
            '        "LEFT OUTER JOIN MBTRANS MB ON MB.MBTRANSUID=DT.MBTRANSUID " & _
            '        "LEFT OUTER JOIN TABLELIST T ON MB.MBTRANSTABLELISTUID=T.TABLELISTUID " & _
            '        "WHERE (DT.MBTRANSDTITEMSTAT=0 AND I.INVENKITCHENUID ='" & KitchenList.Columns(1).Text & "') OR (DET.MBTRANSDTITEMSTAT = 0 AND II.INVENKITCHENUID ='" & KitchenList.Columns(1).Text & "') " & _
            '        "AND MB.MBTRANSDEPTUID='" & DeptInfo.DeptUID & "' ORDER BY " & HeaderName & " " & Sort & ""

            Query = "SELECT * FROM " & _
                    "( " & _
                    "SELECT  A.MBTRANSCUSTNAME, " & _
                    "A.MBTRANSUID, " & _
                    "D.INVENNO," & _
                    "C.MBTRANSDTDETAILUID AS PAKETUID," & _
                    "E.TABLELISTNAME," & _
                    "MBTRANSDTDETAILUID AS MBTRANSDTUID," & _
                    "D.INVENKITCHENUID AS INVENKITCHENUID," & _
                    "C.MBTRANSDTITEMQTY AS MBTRANSDTITEMQTY," & _
                    "B.MBTRANSDTITEMNAME || '-' || C.MBTRANSDTITEMNAME AS MBTRANSDTITEMNAME," & _
                    "C.MBTRANSDTITEMSTAT AS MBTRANSDTITEMSTAT," & _
                    "B.MBTRANSDTITEMNOTE AS MBTRANSDTITEMNOTE," & _
                    "B.MBTRANSDTISTAKEAWAY AS MBTRANSDTISTAKEAWAY,'1' AS STATUS," & _
                    "B.CREATEDDATETIME, B.MODIFIEDUSER,B.MBTRANSDTPARENTUID,B.MBTRANSDTLISTNOTE " & _
                    "FROM MBTRANS A LEFT OUTER JOIN TABLELIST E ON A.MBTRANSTABLELISTUID=E.TABLELISTUID " & _
                    "INNER JOIN MBTRANSDT B ON A.MBTRANSUID=B.MBTRANSUID " & _
                    "INNER JOIN MBTRANSDTDETAIL C ON B.MBTRANSDTUID=C.MBTRANSDTUID AND C.MBTRANSDTITEMSTAT=0 " & _
                    "INNER JOIN INVEN D ON C.MBTRANSDTITEMUID=D.INVENUID AND D.INVENKITCHENUID ='" & KitchenList.Columns(1).Text & "' " & _
                    "WHERE A.MBTRANSDEPTUID='" & DeptInfo.DeptUID & "' " & _
                    "UNION ALL " & _
                    "SELECT  MB.MBTRANSCUSTNAME, " & _
                    "MB.MBTRANSUID, " & _
                    "I.INVENNO, " & _
                    "DT.MBTRANSDTUID AS PAKETUID," & _
                    "T.TABLELISTNAME," & _
                    "DT.MBTRANSDTUID AS MBTRANSDTUID," & _
                    "I.INVENKITCHENUID AS INVENKITCHENUID," & _
                    "DT.MBTRANSDTITEMQTY AS MBTRANSDTITEMQTY," & _
                    "DT.MBTRANSDTITEMNAME AS MBTRANSDTITEMNAME," & _
                    "DT.MBTRANSDTITEMSTAT AS MBTRANSDTITEMSTAT," & _
                    "DT.MBTRANSDTITEMNOTE AS MBTRANSDTITEMNOTE," & _
                    "DT.MBTRANSDTISTAKEAWAY AS MBTRANSDTISTAKEAWAY,'0' AS STATUS," & _
                    "DT.CREATEDDATETIME, DT.MODIFIEDUSER,DT.MBTRANSDTPARENTUID,DT.MBTRANSDTLISTNOTE " & _
                    "FROM MBTRANS MB LEFT OUTER JOIN TABLELIST T ON MB.MBTRANSTABLELISTUID=T.TABLELISTUID " & _
                    "JOIN MBTRANSDT DT ON MB.MBTRANSUID=DT.MBTRANSUID AND DT.MBTransDtItemStat = 0 " & _
                    "INNER JOIN INVEN I ON I.INVENUID = DT.MBTRANSDTITEMUID AND I.INVENKITCHENUID ='" & KitchenList.Columns(1).Text & "' AND I.INVENLEVEL<>'3' " & _
                    "WHERE MB.MBTRANSDEPTUID='" & DeptInfo.DeptUID & "' " & _
                    ") AS Tbl1 ORDER BY " & HeaderName & " " & Sort & ""

            'Anjo - 8 okt 2011 : dun need this anymore, since paket has no invenkitchenuid
            'Query = "SELECT * FROM (" & Query & ") WHERE INVENKITCHENUID='" & KitchenList.Columns(1).Text & "'"

            TMPRecord = MyDatabase.MyReader(Query)

            Dim i As Integer = 0, selTableName As String
            While TMPRecord.Read
                i = i + 1

                Dim modifiedNote As String
                modifiedNote = TMPRecord("MBTRANSDTITEMNOTE")
                If Len(modifiedNote) > 3 Then
                    If Asc(Mid(modifiedNote, 1, 1)) = 9 And Asc(Mid(modifiedNote, 2, 1)) = 32 And Asc(Mid(modifiedNote, 3, 1)) = 9 Then
                        modifiedNote = Mid(modifiedNote, 4, Len(modifiedNote))
                    End If
                End If

                If KitchenMonitorInvoice Then
                    selTableName = ""
                Else
                    selTableName = IIf(IsDBNull(TMPRecord("TABLELISTNAME")) = True, "", TMPRecord("TABLELISTNAME"))
                End If
                Dim parentName As String = Nothing
                If IsDBNull(TMPRecord("MBTRANSDTPARENTUID")) = False Then
                    parentName = getNameParent(TMPRecord("MBTRANSDTPARENTUID"))
                End If
                Dim modItemName As String = Nothing
                Dim jmlModItemNote As Integer = 0
                If IsDBNull(TMPRecord("MBTRANSDTLISTNOTE")) = False Then
                    If Trim(TMPRecord("MBTRANSDTLISTNOTE")) <> "" Then
                        If InStr(TMPRecord("MBTRANSDTLISTNOTE"), MY_SUB_DELIMITER) <> 0 Then
                            Dim arrData() As String = Split(TMPRecord("MBTRANSDTLISTNOTE"), MY_SUB_DELIMITER)
                            jmlModItemNote = UBound(arrData)
                            For j As Integer = 0 To UBound(arrData)
                                modItemName = modItemName & vbNewLine & "   +" & arrData(j)
                            Next
                        Else
                            modItemName = vbNewLine & "   +" & TMPRecord("MBTRANSDTLISTNOTE")
                            jmlModItemNote = 1
                        End If
                    End If
                End If
                If TMPRecord("STATUS") = "1" Then
                    '.AddItem(vbTab & TMPRecord("MBTRANSDTUID") & vbTab & TMPRecord("MBTRANSUID") & vbTab & GETTableName(TMPRecord("MBTRANSUID")) & vbTab & FormatDateTime(TMPRecord("CREATEDDATETIME"), DateFormat.LongTime) & vbTab & TMPRecord("MODIFIEDUSER") & vbTab & TMPRecord("MBTRANSDTITEMQTY") & vbTab & TMPRecord("MBTRANSDTITEMNAME") & vbTab & modifiedNote & vbTab & TMPRecord("MBTRANSDTISTAKEAWAY") & vbTab & TMPRecord("PAKETUID") & vbTab & TMPRecord("MBTRANSCUSTNAME"))
                    .AddItem(vbTab & TMPRecord("MBTRANSDTUID") & vbTab & TMPRecord("MBTRANSUID") & vbTab & selTableName & vbTab & FormatDateTime(TMPRecord("CREATEDDATETIME"), DateFormat.LongTime) & vbTab & TMPRecord("MODIFIEDUSER") & vbTab & TMPRecord("MBTRANSDTITEMQTY") & vbTab & parentName & TMPRecord("MBTRANSDTITEMNAME") & modItemName & vbTab & modifiedNote & vbTab & TMPRecord("MBTRANSDTISTAKEAWAY") & vbTab & TMPRecord("PAKETUID") & vbTab & TMPRecord("MBTRANSCUSTNAME"))

                    If Len(Trim(listUID)) < 20000 Then
                        listUID = listUID & TMPRecord("MBTRANSDTUID")
                    End If

                Else
                    '.AddItem(vbTab & TMPRecord("MBTRANSDTUID") & vbTab & TMPRecord("MBTRANSUID") & vbTab & GETTableName(TMPRecord("MBTRANSUID")) & vbTab & FormatDateTime(TMPRecord("CREATEDDATETIME"), DateFormat.LongTime) & vbTab & TMPRecord("MODIFIEDUSER") & vbTab & TMPRecord("MBTRANSDTITEMQTY") & vbTab & TMPRecord("MBTRANSDTITEMNAME") & vbTab & modifiedNote & vbTab & TMPRecord("MBTRANSDTISTAKEAWAY") & vbTab & "NOTHING" & vbTab & TMPRecord("MBTRANSCUSTNAME"))
                    .AddItem(vbTab & TMPRecord("MBTRANSDTUID") & vbTab & TMPRecord("MBTRANSUID") & vbTab & selTableName & vbTab & FormatDateTime(TMPRecord("CREATEDDATETIME"), DateFormat.LongTime) & vbTab & TMPRecord("MODIFIEDUSER") & vbTab & TMPRecord("MBTRANSDTITEMQTY") & vbTab & parentName & TMPRecord("MBTRANSDTITEMNAME") & modItemName & vbTab & modifiedNote & vbTab & TMPRecord("MBTRANSDTISTAKEAWAY") & vbTab & "NOTHING" & vbTab & TMPRecord("MBTRANSCUSTNAME"))                    
                    If Len(Trim(listUID)) < 20000 Then
                        listUID = listUID & TMPRecord("MBTRANSDTUID")
                    End If

                End If
                If modItemName = "" Then
                    .Rows(i).Height = 40
                Else
                    .Rows(i).Height = 40 + (10 * (jmlModItemNote + 1))
                End If
            End While : MyDatabase.ConnectionDatabase.Close()

            .Redraw = True
        End With

        'Dim NewStyle As CellStyle
        'NewStyle = ListDetail.Styles.Add("Click")
        'NewStyle.BackColor = Color.LightCoral

        'For i As Integer = 0 To ListDetail.Rows.Count - 1
        '    If ListDetail.Item(i, 1) = SelectTable Then
        '        ListDetail.Item(i, 0) = True
        '        ListDetail.Rows(i).Style = ListDetail.Styles("Click")
        '    End If
        'Next


        'ListCollection = DBListCollection("SELECT * FROM MBTRANSDT WHERE MBTRANSDTITEMSTAT IS NULL OR MBTRANSDTITEMSTAT=0")
        'FormStatus = OBJControlInitialize(ListCollection)
        'Call OBJControlHandler(Me, FormStatus)
        'Call CheckPermission(UserInformation.UserTypeUID, IIf(ListCollection.Count > 0, True, False))

        'Call CheckPermission(UserInformation.UserTypeUID, True)

        If oldListUID <> listUID Then
            If detectedUserAction = True Then
                detectedUserAction = False
            Else
                Call SoundWavAlert()
            End If
            oldListUID = listUID
        Else
            detectedUserAction = False
        End If

        Me.Cursor = Cursors.Default

    End Sub

    Private Function getNameParent(ByVal idParent As String) As String
        Dim rs As FbDataReader
        rs = MyDatabase.MyReader("SELECT MBTRANSDTITEMNAME FROM MBTRANSDT WHERE MBTRANSDTUID='" & idParent & "'")
        If rs.Read() = True Then Return rs("MBTRANSDTITEMNAME") & " -> +" Else Return Nothing
        rs = Nothing
    End Function

    Private Sub SoundWavAlert()

        'Dim Sound As New System.Media.SoundPlayer()
        'Sound.SoundLocation = "D:\tmp\start.wav"

        'Sound.Load()
        'Sound.Play()

        If PrefInfo.SoundKitchenAlert = True Then
            Call My.Computer.Audio.Play(My.Resources.Kring, AudioPlayMode.Background)
        End If

    End Sub

    Private Function CheckMenuPaket(ByVal MBTRANSDTDETAILUID As String) As Boolean
        Dim TMPCheck As FbDataReader
        TMPCheck = MyDatabase.MyReader("SELECT COUNT(*) AS MENUPAKET FROM MBTRANSDTDETAIL WHERE MBTRANSDTDETAILUID = '" & MBTRANSDTDETAILUID & "'")
        TMPCheck.Read()

        If TMPCheck.Item("MENUPAKET") > 0 Then
            Return True
        Else
            Return False
        End If

        TMPCheck = Nothing
    End Function

    Private Sub RestorePaketStatus(ByVal MBTRANSDTUID As String)

        Dim TMPCheck As FbDataReader
        Dim foundDumped As Boolean = False
        Dim query As String

        TMPCheck = MyDatabase.MyReader("SELECT * FROM MBTRANSDT WHERE MBTransDTUID='" & MBTRANSDTUID & "'")
        While TMPCheck.Read
            'Apabila order sudah di-cancel tdk perlu melakukan restore
            If TMPCheck.Item("MBTRANSDTITEMSTAT") = -1 Then Exit Sub
        End While

        TMPCheck = MyDatabase.MyReader("SELECT COUNT(*) AS TOTALDUMPED FROM MBTRANSDTDETAIL WHERE MBTRANSDTITEMSTAT=1 AND MBTRANSDTUID = '" & MBTRANSDTUID & "'")
        While TMPCheck.Read()
            If TMPCheck.Item("TOTALDUMPED") > 0 Then foundDumped = True
        End While : MyDatabase.ConnectionDatabase.Close()

        If foundDumped = False Then
            Query = "UPDATE MBTRANSDT SET MBTRANSDTITEMSTAT =0 WHERE MBTRANSDTUID = '" & MBTRANSDTUID & "'"
            Call MyDatabase.MyAdapter(Query)
        End If

    End Sub

    Private Sub CheckPaket(ByVal MBTRANSDTUID As String)

        Dim TMPCheck As FbDataReader
        Dim Query As String
        Dim Count As Integer = 0
        Dim CountDump As Integer = 0

        TMPCheck = MyDatabase.MyReader("SELECT * FROM MBTRANSDTDETAIL WHERE MBTRANSDTUID = '" & MBTRANSDTUID & "'")
        While TMPCheck.Read()
            Count = Count + 1
            If TMPCheck.Item("MBTRANSDTITEMSTAT") = "1" Then
                CountDump = CountDump + 1
            End If
        End While : MyDatabase.ConnectionDatabase.Close()

        If Count = CountDump Then
            Query = "UPDATE MBTRANSDT SET MBTRANSDTITEMSTAT =1 WHERE MBTRANSDTUID = '" & MBTRANSDTUID & "'"
            Call MyDatabase.MyAdapter(Query)
        End If

    End Sub

    Private Sub CheckPermission(ByVal TypeUID As String, ByVal DataExist As Boolean)
        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM USERCATDT WHERE USERCATUID = '" & TypeUID & "' AND USERCATMODULETYPEID = '2204'")
        While TMPRecord.Read()
            UserPermition.PermitionInitialize(TMPRecord.Item("USERCATCREATEACCESS"), TMPRecord.Item("USERCATEDITACCESS"), TMPRecord.Item("USERCATDELETEACCESS"), TMPRecord.Item("USERCATREADACCESS"), TMPRecord.Item("USERCATPRINTACCESS"))
        End While : MyDatabase.ConnectionDatabase.Close()

        With UserPermition
            If Not .ReadAccess Then
                ShowMessage(Me, "Maaf, anda tidak mempunyai akses terhadap form ini !" & vbNewLine & "Silakan hubungi administrator anda.")
                Me.Close()
            End If
            'If Not .EditAccess Then
            '    BTNDump.Enabled = False : BTNDump.VisualStyle = C1Input.VisualStyle.Office2007Silver
            '    BTNUndo.Enabled = False : BTNUndo.VisualStyle = C1Input.VisualStyle.Office2007Silver
            '    BTNPrint.Enabled = False : BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Silver
            'End If
            'If Not .PrintAccess Then
            '    BTNDump.Enabled = False : BTNDump.VisualStyle = C1Input.VisualStyle.Office2007Silver
            '    BTNUndo.Enabled = False : BTNUndo.VisualStyle = C1Input.VisualStyle.Office2007Silver
            '    BTNPrint.Enabled = False : BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Silver
            'End If

            'If .EditAccess Then
            '    If ListCollection.Count > 0 Then
            '        BTNDump.Enabled = True : BTNDump.VisualStyle = C1Input.VisualStyle.Office2007Blue
            '        BTNUndo.Enabled = True : BTNUndo.VisualStyle = C1Input.VisualStyle.Office2007Blue
            '    Else
            '        BTNDump.Enabled = True : BTNDump.VisualStyle = C1Input.VisualStyle.Office2007Blue
            '        BTNUndo.Enabled = True : BTNUndo.VisualStyle = C1Input.VisualStyle.Office2007Blue
            '    End If
            'ElseIf .PrintAccess Then
            '    BTNPrint.Enabled = True : BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Blue
            'Else
            '    FormStatus = FormStatusLib.OpenAndLock
            '    Call OBJControlHandler(Me, FormStatus)
            'End If

            If Not .EditAccess Then
                BTNDump.Enabled = False : BTNDump.VisualStyle = C1Input.VisualStyle.Office2007Silver
                BTNUndo.Enabled = False : BTNUndo.VisualStyle = C1Input.VisualStyle.Office2007Silver
                BTNPrint.Enabled = False : BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Silver
            Else
                BTNDump.Enabled = True : BTNDump.VisualStyle = C1Input.VisualStyle.Office2007Blue
                BTNUndo.Enabled = True : BTNUndo.VisualStyle = C1Input.VisualStyle.Office2007Blue
                BTNPrint.Enabled = True : BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Blue
            End If

        End With
    End Sub
    Private Sub ShowPrintPreview(ByVal Dump As Boolean, ByVal PrintUID1 As String, ByVal PrintUID2 As String, ByVal PrintUID As String)
        Dim OBJNew As New Form_Print_Preview
        Dim Query As String = Nothing

        If Dump = False Then
            Query = "SELECT M.MBTRANSCUSTNAME,M.MBTRANSUID,T.TABLELISTNAME,MB.MBTRANSDTUID,MB.MBTRANSDTITEMNOTE,MB.MBTRANSDTISTAKEAWAY," & _
                    "IIF(MB.MBTRANSDTPARENTUID IS NULL,MB.MBTRANSDTITEMNAME||ASCII_CHAR(13),(SELECT MODITEM.MBTRANSDTITEMNAME||' -> + '||MB.MBTRANSDTITEMNAME FROM MBTRANSDT MODITEM WHERE MODITEM.MBTRANSDTUID=MB.MBTRANSDTPARENTUID))||IIF(MB.MBTRANSDTLISTNOTE IS NULL OR TRIM(MB.MBTRANSDTLISTNOTE)='','','+'||REPLACE(MB.MBTRANSDTLISTNOTE,'^#@$^',ASCII_CHAR(13)||'+')) AS MBTRANSDTITEMNAME,MB.MBTRANSDTITEMQTY,MB.MBTRANSDTITEMPRICE, MB.CREATEDDATETIME, " & _
                    "MD.MBTRANSDTITEMNAME AS MENUPAKET,MD.MBTRANSDTITEMQTY AS QTYPAKET " & _
                    "FROM MBTRANSDT MB " & _
                    "LEFT OUTER JOIN MBTRANS M ON M.MBTRANSUID=MB.MBTRANSUID " & _
                    "LEFT OUTER JOIN MBTRANSDTDETAIL MD ON MD.MBTRANSDTUID=MB.MBTRANSDTUID " & _
                    "LEFT OUTER JOIN TABLELIST T ON M.MBTRANSTABLELISTUID=T.TABLELISTUID " & _
                    "WHERE (" & PrintUID & ") " & _
                    "AND M.MBTRANSDEPTUID='" & DeptInfo.DeptUID & "' "
        Else
            If CheckMenuPaket(ListDetail.Item(ListDetail.Row, 1)) = True Then
                PrintUID = "MD.MBTRANSDTDETAILUID='" & ListDetail.Item(ListDetail.Row, 1) & "'"
            Else
                PrintUID = "MB.MBTRANSDTUID='" & ListDetail.Item(ListDetail.Row, 1) & "'"
            End If

            Query = "SELECT M.MBTRANSCUSTNAME,M.MBTRANSUID,T.TABLELISTNAME,MB.MBTRANSDTUID,MB.MBTRANSDTITEMNOTE,MB.MBTRANSDTISTAKEAWAY," & _
                    "IIF(MB.MBTRANSDTPARENTUID IS NULL,MB.MBTRANSDTITEMNAME||ASCII_CHAR(13),(SELECT MODITEM.MBTRANSDTITEMNAME||' -> + '||MB.MBTRANSDTITEMNAME FROM MBTRANSDT MODITEM WHERE MODITEM.MBTRANSDTUID=MB.MBTRANSDTPARENTUID))||ASCII_CHAR(13)||IIF(MB.MBTRANSDTLISTNOTE IS NULL OR TRIM(MB.MBTRANSDTLISTNOTE)='','','+'||REPLACE(MB.MBTRANSDTLISTNOTE,'^#@$^',ASCII_CHAR(13)||'+')) AS MBTRANSDTITEMNAME,MB.MBTRANSDTITEMQTY,MB.MBTRANSDTITEMPRICE, MB.CREATEDDATETIME, " & _
                    "MD.MBTRANSDTITEMNAME AS MENUPAKET,MD.MBTRANSDTITEMQTY AS QTYPAKET " & _
                    "FROM MBTRANSDT MB " & _
                    "LEFT OUTER JOIN MBTRANS M ON M.MBTRANSUID=MB.MBTRANSUID " & _
                    "LEFT OUTER JOIN MBTRANSDTDETAIL MD ON MD.MBTRANSDTUID=MB.MBTRANSDTUID " & _
                    "LEFT OUTER JOIN TABLELIST T ON M.MBTRANSTABLELISTUID=T.TABLELISTUID " & _
                    "WHERE " & PrintUID & " AND MB.MBTRANSDTITEMSTAT= 1 " & _
                    "AND M.MBTRANSDEPTUID='" & DeptInfo.DeptUID & "' "
        End If

        OBJNew.Name = "Form_Print_Preview"
        OBJNew.RPTTitle = "Kitchen_List"
        OBJNew.RPTDocument = New Kitchen_List
        OBJNew.DataPoint = MyDatabase.MyAdapter(Query)
        OBJNew.VersiNota = True
        OBJNew.ShowDialog()

    End Sub

    Private Sub KitchenInitialize()
        Dim TMPRecord As FbDataReader
        TMPRecord = MyDatabase.MyReader("SELECT * FROM KITCHEN WHERE KITCHENACTV IS NULL OR KITCHENACTV = 0 ORDER BY KITCHENNAME")

        KitchenList.ClearItems()
        KitchenList.HoldFields()
        While TMPRecord.Read
            KitchenList.AddItem(vbTab & TMPRecord("KITCHENNAME") & ";" & TMPRecord("KITCHENUID"))
        End While : MyDatabase.ConnectionDatabase.Close()
        KitchenList.SelectedIndex = -1

    End Sub

    Private Function GETTableName(ByVal TransUID As String) As String

        If KitchenMonitorInvoice = True Then Return Nothing

        Dim TMPResult As FbDataReader
        TMPResult = MyDatabase.MyReader("SELECT a.MBTRANSTABLELISTUID, (select TABLELISTNAME FROM TABLELIST WHERE TABLELISTUID = a.MBTRANSTABLELISTUID) FROM MBTRANS a WHERE MBTRANSUID='" & TransUID & "'")
        TMPResult.Read()

        If Not IsDBNull(TMPResult("TABLELISTNAME")) Then
            Return TMPResult("TABLELISTNAME")
        Else
            Return Nothing
        End If
    End Function

#End Region

#Region "Form Control Function"

    Private Sub Form_Kitchen_Monitor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Me.Location = New System.Drawing.Point(MainPage.Location.X, MainPage.Location.Y + 44)
        Me.Cursor = Cursors.Default
        Call KitchenInitialize()
        ListDetail.Rows(0).Height = 30

        'ListCollection = DBListCollection("SELECT * FROM MBTRANSDT WHERE MBTRANSDTITEMSTAT IS NULL OR MBTRANSDTITEMSTAT=0")
        'FormStatus = OBJControlInitialize(ListCollection)
        'Call OBJControlHandler(Me, FormStatus)
        'Call CheckPermission(UserInformation.UserTypeUID, IIf(ListCollection.Count > 0, True, False))

        Call CheckPermission(UserInformation.UserTypeUID, True)

    End Sub

    Private Sub ListDetail_AfterSort(ByVal sender As Object, ByVal e As C1.Win.C1FlexGrid.SortColEventArgs) Handles ListDetail.AfterSort
        Dim X As Integer = Nothing
        Dim Y As Integer = Nothing
        X = e.Col
        Y = e.Order

        If X = 3 Then
            HeaderName = "TABLELISTNAME"
        ElseIf X = 4 Then
            HeaderName = "CREATEDDATETIME"
        ElseIf X = 5 Then
            HeaderName = "MODIFIEDUSER"
        ElseIf X = 6 Then
            HeaderName = "MBTRANSDTITEMQTY"
        ElseIf X = 7 Then
            HeaderName = "MBTRANSDTITEMNAME"
        ElseIf X = 8 Then
            HeaderName = "MBTRANSDTITEMNOTE"
        ElseIf X = 9 Then
            HeaderName = "MBTRANSDTISTAKEAWAY"
        ElseIf X = 11 Then
            HeaderName = "MBTRANSCUSTNAME"
        End If

        If Y = 1 Then
            Sort = "ASC"
        Else
            Sort = "DESC"
        End If

        detectedUserAction = True

    End Sub

    Private Sub ListDetail_MouseDown(ByVal sender As Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles ListDetail.MouseDown
        'If ListDetail.Rows.Count > 1 Then
        '    Dim NewStyle As CellStyle
        '    NewStyle = ListDetail.Styles.Add("Click")
        '    NewStyle.BackColor = Color.LightCoral

        '    For i As Integer = 0 To ListDetail.Rows.Count - 1
        '        ListDetail.Item(i, 0) = False
        '        ListDetail.Rows(i).Style = Nothing
        '    Next
        '    ListDetail.Item(ListDetail.Row, 0) = True
        '    ListDetail.Rows(ListDetail.Row).Style = ListDetail.Styles("Click")

        '    SelectTable = ListDetail.Item(ListDetail.Row, 1)
        'End If

        If ListDetail.Rows.Count > 1 Then
            ListDetail.Item(ListDetail.Row, 0) = Not ListDetail.Item(ListDetail.Row, 0)

            With ListDetail
                Dim NewStyle As CellStyle
                NewStyle = .Styles.Add("Click")
                NewStyle.BackColor = Color.LightCoral

                For i As Integer = 0 To .Rows.Count - 1
                    If .Item(i, 0) = True Then
                        .Rows(i).Style = .Styles("Click")
                    Else
                        .Rows(i).Style = Nothing
                    End If
                Next
            End With
        End If
    End Sub

    Private Sub ListDetail_Click(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListDetail.Click
        If ListDetail.Rows.Count > 1 Then
            If BTNDump.Enabled = False Then
                BTNPrint.Enabled = False
                BTNPrint.VisualStyle = C1Input.VisualStyle.Office2007Silver
                Exit Sub
            End If
            BTNPrint.Enabled = True
            BTNPrint.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Blue
        End If
    End Sub

    Private Sub ListDetail_DoubleClick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ListDetail.DoubleClick
        If ListDetail.Rows.Count > 1 Then
            Dim NewStyle As CellStyle
            NewStyle = ListDetail.Styles.Add("Click")
            NewStyle.BackColor = Color.LightCoral

            For i As Integer = 0 To ListDetail.Rows.Count - 1
                ListDetail.Item(i, 0) = False
                ListDetail.Rows(i).Style = Nothing
            Next
            ListDetail.Item(ListDetail.Row, 0) = True
            ListDetail.Rows(ListDetail.Row).Style = ListDetail.Styles("Click")

            SelectTable = ListDetail.Item(ListDetail.Row, 1)
        End If

        BTNDump_Click(sender, e)
    End Sub

    Private Sub BTNClose_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNClose.Click
        Me.Close()
    End Sub

    Private Sub KitchenList_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles KitchenList.TextChanged
        If KitchenList.SelectedIndex < 0 Then Exit Sub
        Me.Cursor = Cursors.WaitCursor
        detectedUserAction = True
        Call BasicInitialize()
        Me.Cursor = Cursors.Default
    End Sub

    Private Sub BTNPrint_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNPrint.Click
        Me.Cursor = Cursors.WaitCursor
        If ListDetail.Rows.Count < 2 Then
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Maaf, tidak ada data untuk dicetak !", True)
            BTNPrint.Enabled = False
            BTNPrint.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Silver            
            Exit Sub
        End If

        If ListDetail.Row < 1 Then
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Silakan pilih item terlebih dahulu !", True)
            BTNPrint.Enabled = False
            BTNPrint.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Silver
            Exit Sub
        End If

        PrintUID = Nothing
        PrintUID1 = Nothing
        PrintUID2 = Nothing
        Dim ItemUID1 As String = Nothing
        Dim ItemUID2 As String = Nothing
        Dim ItemUID As String = Nothing

        With ListDetail
            For i As Integer = 0 To .Rows.Count - 1
                If .Item(i, 0) = True Then
                    DataUID.AddItem(vbTab & .Item(i, 1) & vbTab & .Item(i, 7) & vbTab & .Item(i, 10))

                    If PrintUID = Nothing Then
                        If CheckMenuPaket(.Item(i, 1)) = True Then
                            PrintUID = "MD.MBTRANSDTDETAILUID='" & .Item(i, 1) & "'"
                        Else
                            PrintUID = "MB.MBTRANSDTUID='" & .Item(i, 1) & "'"
                        End If
                    Else
                        If CheckMenuPaket(.Item(i, 1)) = True Then
                            ItemUID = "MD.MBTRANSDTDETAILUID='" & .Item(i, 1) & "'"
                        Else
                            ItemUID = "MB.MBTRANSDTUID='" & .Item(i, 1) & "'"
                        End If
                        PrintUID = PrintUID & " OR " & ItemUID
                    End If
                End If
            Next
        End With

        If DataUID.Rows.Count > 1 Then
            Call ShowPrintPreview(False, PrintUID1, PrintUID2, PrintUID)
        Else
            Me.Cursor = Cursors.Default
            ShowMessage(Me, "Maaf, tidak ada data untuk dicetak !", True)
            BTNPrint.Enabled = False
            BTNPrint.VisualStyle = C1.Win.C1Input.VisualStyle.Office2007Silver

            Exit Sub
        End If

        Me.Cursor = Cursors.Default
        If ShowQuestion(Me, "Proses item yang dipilih ?", True) = True Then
            detectedUserAction = True
            Me.Cursor = Cursors.WaitCursor
            For i As Integer = 0 To DataUID.Rows.Count - 1
                If DataUID.Item(i, 3) <> "NOTHING" Then
                    Dim Query As String = Nothing
                    Dim QueryDetail As String = Nothing

                    Query = "UPDATE MBTRANSDTDETAIL SET MBTRANSDTITEMSTAT =1 WHERE MBTRANSDTITEMSTAT <> -1 AND MBTRANSDTDETAILUID = '" & DataUID.Item(i, 1) & "'"

                    QueryDetail = "SELECT DET.MBTRANSDTDETAILUID,DT.MBTRANSUID,DT.MBTRANSUID,DET.CREATEDDATETIME,DET.MODIFIEDUSER,DET.MBTRANSDTITEMQTY,DET.MBTRANSDTITEMNAME,DET.MBTRANSDTITEMNOTE,DET.MBTRANSDTISTAKEAWAY,DET.MBTRANSDTUID FROM MBTRANSDT DT " & _
                        "LEFT OUTER JOIN MBTRANSDTDETAIL DET ON DT.MBTRANSDTUID=DET.MBTRANSDTUID " & _
                        "WHERE DET.MBTRANSDTDETAILUID = '" & DataUID.Item(i, 1) & "'"

                    Dim TMPDetail As FbDataReader
                    Dim MBTRANSDTUID As String = Nothing
                    TMPDetail = MyDatabase.MyReader(QueryDetail)
                    BTNUndo.Enabled = True
                    While TMPDetail.Read
                        MBTRANSDTUID = TMPDetail.Item("MBTRANSDTUID")

                        Dim DataRecord As New ArrayList
                        For z As Integer = 0 To TMPDetail.FieldCount - 1
                            DataRecord.Add(TMPDetail.Item(z))
                        Next
                        DumpCollection.Add(DataRecord)
                    End While : MyDatabase.ConnectionDatabase.Close()
                    TMPDetail = Nothing

                    Call MyDatabase.MyAdapter(Query)
                    Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMSTAT =1 WHERE MBTRANSDTITEMSTAT <> -1 AND MBTRANSDTUID = '" & MBTRANSDTUID & "'")
                    'Call CheckPaket(MBTRANSDTUID)

                    GoTo Ex
                End If

                Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMSTAT =1 WHERE MBTRANSDTITEMSTAT <> -1 AND MBTRANSDTUID = '" & DataUID.Item(i, 1) & "'")

                Dim TMPRecord As FbDataReader
                TMPRecord = MyDatabase.MyReader("SELECT MBTRANSDTUID,MBTRANSUID,MBTRANSUID,CREATEDDATETIME,MODIFIEDUSER,MBTRANSDTITEMQTY,MBTRANSDTITEMNAME,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,MBTRANSDTUID FROM MBTRANSDT WHERE MBTRANSDTUID = '" & DataUID.Item(i, 1) & "'")
                BTNUndo.Enabled = True
                While TMPRecord.Read
                    Dim DataRecord As New ArrayList
                    For x As Integer = 0 To TMPRecord.FieldCount - 1
                        DataRecord.Add(TMPRecord.Item(x))
                    Next
                    DumpCollection.Add(DataRecord)
                End While : MyDatabase.ConnectionDatabase.Close()
                TMPRecord = Nothing
Ex:
            Next

            DataUID.Rows.Count = 1
            Call BasicInitialize()
            Me.Cursor = Cursors.Default

        Else
            Me.Cursor = Cursors.WaitCursor
            With ListDetail
                For i As Integer = 0 To .Rows.Count - 1
                    .Item(i, 0) = False
                Next
            End With

            DataUID.Rows.Count = 1
            Call BasicInitialize()
            Me.Cursor = Cursors.Default
        End If

    End Sub

    Private Sub BTNDump_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNDump.Click

        detectedUserAction = True

        With ListDetail
            If .Row > 0 Then
                Dim Query As String = Nothing
                If ShowQuestion(Me, "Proses item '" & .Item(.Row, 7) & "' ?", True) = True Then
                    Me.Cursor = Cursors.WaitCursor
                    If .Item(.Row, 10) <> "NOTHING" Then
                        Query = "UPDATE MBTRANSDTDETAIL SET MBTRANSDTITEMSTAT=1 WHERE MBTRANSDTITEMSTAT <> -1 AND MBTRANSDTDETAILUID = '" & .Item(.Row, 1) & "'"

                        Dim QueryDetail As String = "SELECT DET.MBTRANSDTDETAILUID,DT.MBTRANSUID,DT.MBTRANSUID,DET.CREATEDDATETIME,DET.MODIFIEDUSER,DET.MBTRANSDTITEMQTY,DET.MBTRANSDTITEMNAME,DET.MBTRANSDTITEMNOTE,DET.MBTRANSDTISTAKEAWAY,DET.MBTRANSDTUID FROM MBTRANSDT DT " & _
                            "LEFT OUTER JOIN MBTRANSDTDETAIL DET ON DT.MBTRANSDTUID=DET.MBTRANSDTUID " & _
                            "WHERE DET.MBTRANSDTDETAILUID = '" & .Item(.Row, 1) & "'"

                        Dim TMPDetail As FbDataReader
                        Dim MBTRANSDTUID As String = Nothing
                        TMPDetail = MyDatabase.MyReader(QueryDetail)
                        BTNUndo.Enabled = True
                        While TMPDetail.Read
                            MBTRANSDTUID = TMPDetail.Item("MBTRANSDTUID")

                            Dim DataRecord As New ArrayList
                            For i As Integer = 0 To TMPDetail.FieldCount - 1
                                DataRecord.Add(TMPDetail.Item(i))
                            Next
                            DumpCollection.Add(DataRecord)
                        End While : MyDatabase.ConnectionDatabase.Close()
                        TMPDetail = Nothing

                        Call MyDatabase.MyAdapter(Query)
                        Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMSTAT=1 WHERE MBTRANSDTITEMSTAT<> -1 AND MBTRANSDTUID = '" & MBTRANSDTUID & "'")

                        If PrefInfo.PrintKitchenMonitor = 1 Then
                            Call ShowPrintPreview(True, Nothing, Nothing, Nothing)
                        End If

                        .RemoveItem(.Row)
                        'Call CheckPaket(MBTRANSDTUID)
                        Me.Cursor = Cursors.Default
                        Exit Sub
                    End If

                    Query = "UPDATE MBTRANSDT SET MBTRANSDTITEMSTAT=1 WHERE MBTRANSDTITEMSTAT <> -1 AND MBTRANSDTUID = '" & .Item(.Row, 1) & "'"

                    Dim TMPRecord As FbDataReader
                    TMPRecord = MyDatabase.MyReader("SELECT MBTRANSDTUID,MBTRANSUID,MBTRANSUID,CREATEDDATETIME,MODIFIEDUSER,MBTRANSDTITEMQTY,MBTRANSDTITEMNAME,MBTRANSDTITEMNOTE,MBTRANSDTISTAKEAWAY,MBTRANSDTUID FROM MBTRANSDT WHERE MBTRANSDTUID = '" & .Item(.Row, 1) & "'")
                    BTNUndo.Enabled = True
                    While TMPRecord.Read
                        Dim DataRecord As New ArrayList
                        For i As Integer = 0 To TMPRecord.FieldCount - 1
                            DataRecord.Add(TMPRecord.Item(i))
                        Next
                        DumpCollection.Add(DataRecord)
                    End While : MyDatabase.ConnectionDatabase.Close()
                    TMPRecord = Nothing
                Else
                    Me.Cursor = Cursors.Default
                    Exit Sub
                End If

                Call MyDatabase.MyAdapter(Query)

                If PrefInfo.PrintKitchenMonitor = 1 Then
                    Call ShowPrintPreview(True, Nothing, Nothing, Nothing)
                End If
                .RemoveItem(.Row)
                Me.Cursor = Cursors.Default
            End If
        End With
    End Sub
    Private Sub BTNViewNotes_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNViewNotes.Click
        With ListDetail
            If .Row > 0 Then
                Dim OBJNew As New Form_View_Notes
                OBJNew.Name = "Form_View_Notes"
                OBJNew.ParentOBJForm = Me
                OBJNew.NotesTxt.Text = .Item(.Row, 8)
                OBJNew.ShowDialog()
            End If
        End With
    End Sub
    Private Sub BTNUndo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNUndo.Click

        detectedUserAction = True

        Dim MBDTUID As String = Nothing
        Dim MBDETAIL As String = Nothing

        If DumpCollection.Count = 0 Then
            ShowMessage(Me, "Maaf, tidak ada data untuk diundo !", True)
            BTNUndo.Enabled = False
            Exit Sub
        End If

        Dim CurrentRecord As New ArrayList
        With ListDetail
            If Not IsNothing(DumpCollection) Then
                CurrentRecord = DumpCollection(DumpCollection.Count)
                MBDTUID = CurrentRecord(0)
                MBDETAIL = CurrentRecord(9)

                If KitchenMonitorInvoice = False Then
                    Dim TMPHeader As FbDataReader
                    TMPHeader = MyDatabase.MyReader("SELECT * FROM MBTrans WHERE MBTransUID = '" & CurrentRecord(1) & "'")
                    TMPHeader.Read()
                    If Not IsDBNull(TMPHeader.Item("ISBILLED")) Then
                        If TMPHeader.Item("ISBILLED") = 1 Then
                            ShowMessage(Me, "Maaf, anda tidak dapat melakukan proses undo, karena meja '" & GETTableName(CurrentRecord(2)) & "' sudah dibuatkan bill tagihan !")
                            BTNUndo.Enabled = False
                            Exit Sub
                        End If
                    End If
                End If

                .AddItem(vbTab & CurrentRecord(0) & vbTab & CurrentRecord(1) & vbTab & GETTableName(CurrentRecord(2)) & vbTab & FormatDateTime(CurrentRecord(3), DateFormat.LongTime) & vbTab & CurrentRecord(4) & vbTab & CurrentRecord(5) & vbTab & CurrentRecord(6) & vbTab & CurrentRecord(7) & vbTab & CurrentRecord(8))
                .Rows(.Rows.Count - 1).Height = 50

                DumpCollection.Remove(DumpCollection.Count)
                ''UPDATE MBTRANSDTDETAIL - MENU DETAIL FROM PAKET''
                Call MyDatabase.MyAdapter("UPDATE MBTRANSDTDETAIL SET MBTRANSDTITEMSTAT=0 WHERE MBTRANSDTITEMSTAT <> -1 AND MBTRANSDTDETAILUID = '" & MBDTUID & "'")
                ''UPDATE MBTRANSDT - PAKET''
                'Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMSTAT =0 WHERE MBTRANSDTUID = '" & MBDETAIL & "'")
                Call RestorePaketStatus(MBDETAIL)

                ''UPDATE MBTRANSDT - MENU''
                Call MyDatabase.MyAdapter("UPDATE MBTRANSDT SET MBTRANSDTITEMSTAT=0 WHERE MBTRANSDTITEMSTAT <> -1 AND MBTRANSDTUID = '" & MBDTUID & "'")
                Call BasicInitialize()

                Exit Sub
            Else
                ShowMessage(Me, "Maaf, tidak ada data untuk diundo !", True)
                Exit Sub
            End If
        End With

    End Sub

    Private Sub FocusMove(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNMoveUp.Click, BTNMoveDown.Click

        With ListDetail
            If .Rows.Count > 1 Then
                Select Case sender.name
                    Case "BTNMoveUp"
                        If .Row > 1 Then .Row = .Row - 1
                    Case "BTNMoveDown"
                        If .Row < .Rows.Count - 1 Then .Row = .Row + 1
                End Select
            End If
        End With
    End Sub
#End Region
    Private Function GetIdleTime() As Long

        Dim systemUptime As Integer
        Dim lastInputTicks As Integer
        Dim idleTicks As Integer

        systemUptime = Environment.TickCount
        lastInputTicks = 0
        idleTicks = 0

        Dim myLast As LASTINPUTINFO
        myLast.cbSize = CUInt(Marshal.SizeOf(myLast))
        myLast.dwTime = 0

        If GetLastInputInfo(myLast) Then
            lastInputTicks = CInt(myLast.dwTime)
            idleTicks = systemUptime - lastInputTicks
        End If

        'lblSystemUptime.Text = Convert.ToString(systemUptime / 1000) & " seconds"
        'lblIdleTime.Text = Fix(Convert.ToString(IdleTicks / 1000)) & " seconds"
        'lblLastInput.Text = "At second " & Convert.ToString(LastInputTicks / 1000)

        GetIdleTime = CLng(Fix(Convert.ToString(idleTicks / 1000)))

    End Function

    Private Sub TimerRefresh_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TimerRefresh.Tick
        Dim idleTimeRefresh As Long = CLng(PrefInfo.RefreshKitchenMonitor) '10 disini adalah 10 detik

        'Ardian - Refresh Kitchen Monitor
        If idleTimeRefresh = 0 Then
            Exit Sub
        Else
            If GetIdleTime() > idleTimeRefresh Then
                timerTick = timerTick + 1
                If timerTick >= idleTimeRefresh Then
                    timerTick = 0
                    For Each myForm In My.Application.OpenForms
                        If myForm.Name = "Form_Sign_In" Then
                            'do nothing
                        ElseIf myForm.Name = "Kitchen_Monitor" Then
                            Try
                                Call BasicInitialize()
                            Catch ex As Exception
                                'Do nothing
                                Exit Sub
                            End Try
                        End If
                    Next
                End If
            Else
                timerTick = 0
                Exit Sub
            End If
        End If

    End Sub

    Private Sub BTNRefresh_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BTNRefresh.Click
        DataUID.Rows.Count = 1
        Call BasicInitialize()
    End Sub
End Class