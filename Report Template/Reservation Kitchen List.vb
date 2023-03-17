Imports DataDynamics.ActiveReports
Imports DataDynamics.ActiveReports.Document
Imports FirebirdSql.Data.FirebirdClient

Public Class Reservation_Kitchen_List 

    Private Sub Reservation_Kitchen_List_ReportStart(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.ReportStart
        If PrefInfo.invNota = "1" Then ReservationNoLabel.Visible = False
        Me.SetLicense("RGN,RGN Warez Group,DD-APN-30-C01339,W44SSM949SWJ449HSHMF")
    End Sub

    Private Sub ReportHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReportHeader1.Format
        CompanyNameText.Value = CompanyInformation.CompanyName
        CompanyAddressText.Value = CompanyInformation.Address & ", " & CompanyInformation.City
        CompanyPhoneText.Value = "Phone : " & CompanyInformation.Phone & "    Fax : " & CompanyInformation.Fax
    End Sub

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

    Private Function GETTableName(ByVal TransUID As String) As String

        Dim Result As String = ""
        Dim TMPResult As FbDataReader
        TMPResult = MyDatabase.MyReader("SELECT a.RSVTRANSTABLELISTUID, (SELECT TABLELISTNAME FROM TABLELIST WHERE TABLELISTUID = a.RSVTRANSTABLELISTUID) FROM RSVTRANSTABLELIST a WHERE RSVTRANSUID='" & TransUID & "'")
        While TMPResult.Read()
            Result = Result & "," & TMPResult("TABLELISTNAME")
        End While

        GETTableName = "TABLE : " & Mid(Result, 2, Len(Result))

    End Function

    Private Sub GroupHeader1_Format(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles GroupHeader1.Format
        No.Text = CDec(No.Text) + 1
        If No.Text = 1 Then
            ReservationNoLabel.Value = "RSV : " & ReservationNoLabel.Value
            ReservationPaxLabel.Value = "PAX : " & ReservationPaxLabel.Value
            TransactionDateLabel.Value = Format(TransactionDateLabel.Value, "dd/MM/yyyy hh:mm tt")

            ReservationDateLabel.Value = "RSV DATE : " & Format(ReservationDateLabel.Value, "dd/MM/yyyy")
            ReservationTimeLabel.Value = "TIME : " & Format(ReservationTimeLabel.Value, "hh:mm tt")

            ReservationTableText.Value = GETTableName(TransactionUID.Value)
            ReservationPrinterCounterLabel.Value = "NO PRINT : " & ReservationPrinterCounterLabel.Value
            ReservationCreatedUserLabel.Value = "OP : " & ReservationCreatedUserLabel.Value
        End If

        If KitchenItemNotes.Text = "" Then
            GroupHeader1.Height = 0.2
            KitchenItemNotes.Value = ""
            KitchenItemNotes.Visible = False
        Else
            GroupHeader1.Height = 0.39
            KitchenItemNotes.Value = "NOTES : " & KitchenItemNotes.Value
            KitchenItemNotes.Visible = True
        End If

        If KitchenTakeAway.Text = "1" Then
            KitchenTakeAway.Text = "T.A"
        Else
            KitchenTakeAway.Text = ""
        End If

        If KitchenItemName.Text = "" Then
            GroupHeader1.Height = 0.7
        End If
    End Sub
End Class
