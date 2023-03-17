Imports DataDynamics.ActiveReports 
Imports DataDynamics.ActiveReports.Document
Imports FirebirdSql.Data.FirebirdClient

Public Class Kitchen_List58
    Private Sub Kitchen_List_ReportStart(ByVal sender As Object, ByVal e As System.EventArgs) Handles Me.ReportStart
        Me.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF")
    End Sub

    Private Sub PageHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PageHeader1.Format
        KitchenPrintUserLabel.Value = UserInformation.UserName
        CurrentDateLabel.Value = Format(Now, "dd/MM/yyyy HH:mm")
        KitchenPrintUserLabel.Value = KitchenPrintUserLabel.Value & "  " & CurrentDateLabel.Value
    End Sub

    'Private Function GETTableName(ByVal TransUID As String) As String
    '    Dim TMPResult As FbDataReader
    '    TMPResult = MyDatabase.MyReader("SELECT a.MBTRANSTABLELISTUID, (select TABLELISTNAME FROM TABLELIST WHERE TABLELISTUID = a.MBTRANSTABLELISTUID) FROM MBTRANS a WHERE MBTRANSUID='" & TransUID & "'")
    '    TMPResult.Read()

    '    If Not IsDBNull(TMPResult("TABLELISTNAME")) Then
    '        Return TMPResult("TABLELISTNAME")
    '    Else
    '        Return Nothing
    '    End If
    'End Function

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
    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        CompanyNameText.Value = IIf(pubIsDemo = True, "=Demo Version=", CompanyInformation.CompanyName)
        'CompanyAddressText.Value = CompanyInformation.Address & ", " & CompanyInformation.City
        'CompanyPhoneText.Value = "Phone : " & CompanyInformation.Phone & "    Fax : " & CompanyInformation.Fax
    End Sub

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        'KitchenTable.Value = "TBL-" & KitchenTable.Value
        KitchenTable.Value = Mid(KitchenTable.Value, 1, 4)

        Label2.Text = Format(CDate(Label2.Text), "HH:mm")
        If KitchenItemNotes.Text = "" Then
            Detail1.Height = 0.2
            KitchenItemNotes.Value = ""
            KitchenItemNotes.Visible = False
        Else
            Detail1.Height = 0.39
            KitchenItemNotes.Value = "NOTES : " & KitchenItemNotes.Value
            KitchenItemNotes.Visible = True
        End If

        If KitchenTakeAway.Text = 1 Then
            KitchenTakeAway.Text = "T.A"
        Else
            KitchenTakeAway.Text = ""
        End If

        If KitchenTable.Text = "" Then
            KitchenTable.Text = "-"
            KitchenTable.Visible = False
        End If

        If KitchenItemName.Text = "" Then
            Detail1.Height = 0.7

            KitchenPrintUserLabel.Visible = True
            CurrentDateLabel.Visible = True
        End If
    End Sub

    Private Sub GroupHeader2_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader2.Format

        If MainPage.InvoiceApplication = False Then
            GroupHeader2.Height = 0
            GroupHeader2.Visible = False
        End If

    End Sub
End Class
