Imports MessageBusDemo.MessageBus




Public Class MainForm

    Private Sub btnNewReceiver_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnNewReceiver.Click
        Dim oMR As MessageReceiver = New MessageReceiver
        oMR.Show()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim oMS As New MessageSender

        oMS.Show()

        oMS.INIT()

    End Sub

    Private Sub btnExit_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnExit.Click
        cBus.StopBusNow()

        'MsgBox("Bus has been stopped")

        End
    End Sub

    Private Sub btnStatsRequest_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStatsRequest.Click
        StatsForm.Show()

    End Sub


    Private Sub btnStart10Senders_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnStart10Senders.Click
        Dim ix As Integer
        For ix = 1 To 10
            Dim oFm As MessageSender
            oFm = New MessageSender
            oFm.INIT()
            oFm.Show()

            oFm.cmbInterval.Text = 0.1
            oFm.Setname(oFm.Text)
            oFm.StartTimer()
        Next
    End Sub

    Private Sub MainForm_FormClosing(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles Me.FormClosing

        MessageBus.cBus.StopBusNow()

    End Sub

    Private oClock As New cClock

    Private Sub MainForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub btnFormulas_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnFormulas.Click
        TrackerForm.Show()
        TrackerForm.Focus()
    End Sub
    Private Sub OpenNewFollower(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOpenFollower.Click
        Dim oFF As New FollowerForm
        oFF.Show()

    End Sub
End Class
