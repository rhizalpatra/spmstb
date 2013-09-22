Public Class MessageSender
    Private Shared _SenderID As Long


    Private WithEvents oSender As MessageBus.cSender = Nothing
    Private WithEvents _RepeatTimer As New System.Timers.Timer


    Private Sub btnOneMessage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnOneMessage.Click
        SendOneMessage()
    End Sub

    Private _SentCount As Long = 0
    Private Sub SendOneMessage()

        oSender.SendNewMessage(txtMsgType.Text, "#" & _SentCount, "", txtMessage.Text)
        _SentCount += 1

    End Sub

    Private Sub btnSetName_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnSetName.Click
        If txtSenderName.Text.Length = 0 Then
            Exit Sub
        End If
        Setname(txtSenderName.Text)
    End Sub
    Public Sub Setname(ByVal sName As String)

        oSender = New MessageBus.cSender(sName)
        btnSetName.Visible = False
        btnOneMessage.Enabled = True
        chkRepeat.Enabled = True

    End Sub

    Private Sub chkRepeat_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkRepeat.CheckedChanged
        If chkRepeat.Checked Then
            StartTimer()
        Else
            EndTimer()
        End If
    End Sub

    Public Sub StartTimer()
        If _RepeatTimer.Enabled Then Exit Sub
        _RepeatTimer.Interval = CDbl(cmbInterval.Text) * 1000
        _RepeatTimer.Enabled = True
        lblRunningLight.BackColor = Color.LightGreen
        chkRepeat.Text = "STOP"
    End Sub
    Public Sub EndTimer()
        If Not _RepeatTimer.Enabled Then Exit Sub
        _RepeatTimer.Enabled = False
        lblRunningLight.BackColor = Color.LightPink
        chkRepeat.Text = "RUN"
    End Sub
    Private Sub _RepeatTimer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles _RepeatTimer.Elapsed
        SendOneMessage()
    End Sub

    Private Sub cmbInterval_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cmbInterval.SelectedIndexChanged
        _RepeatTimer.Interval = CDbl(cmbInterval.Text) * 1000
    End Sub

    Private Sub MessageSender_FormClosed(ByVal sender As Object, ByVal e As System.Windows.Forms.FormClosedEventArgs) Handles Me.FormClosed
        _RepeatTimer.Enabled = False


    End Sub

    Private Sub MessageSender_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        INIT()
    End Sub
    Public Sub INIT()
        Static bINIT As Boolean = False
        If bINIT Then Exit Sub

        bINIT = True

        _SenderID += 1
        Text = "Message sender #" & _SenderID
        txtSenderName.Text = "#" & _SenderID

    End Sub
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        lblSentCount.Text = _SentCount
    End Sub

    Protected Overrides Sub Finalize()
        _RepeatTimer.Enabled = False
        _RepeatTimer = Nothing

        MyBase.Finalize()
    End Sub

    Private Sub oSender_Stopped() Handles oSender.Stopped
        _RepeatTimer.Enabled = False

        lblRunningLight.BackColor = Color.Gray
        Me.chkRepeat.Enabled = False
        Me.chkRepeat.Text = "Bus stopped"

    End Sub
End Class