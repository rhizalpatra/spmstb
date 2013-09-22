Public Class StatsForm

    Private WithEvents oRec As New MessageBus.cReceiver()


    Private Sub btnRequestStats_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnRequestStats.Click
        Dim oS As New MessageBus.cSender("RPT")
        oS.SendNewMessage("RPT", "RPT")
        oS.Flush()

        oS = Nothing

    End Sub

    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim om As MessageBus.cMessage

        om = oRec.GetNextMessage
        If om IsNot Nothing Then

            Do Until om Is Nothing


                Dim ss() As String = om.Content.Split("|")
                Dim s As String
                For Each s In ss
                    Me.ListBox1.Items.Add(s)

                Next


                om = oRec.GetNextMessage

            Loop
            Me.ListBox1.TopIndex = Me.ListBox1.Items.Count - 1
        End If

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub

    Private Sub btnClearList_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClearList.Click
        Me.ListBox1.Items.Clear()

    End Sub


    Private Sub StatsForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        oRec.Filter = New MessageBus.cTypeContains("STATS")
        oRec.Connect()
        
    End Sub
End Class