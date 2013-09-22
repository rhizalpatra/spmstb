Public Class MessageReceiver

    Private WithEvents oRec As New MessageBus.cReceiver()

    Private bOutputmessages As Boolean

    Private _RoleFilter As New MessageBus.cRoleContains("")
    Private _TypeFilter As New MessageBus.cTypeContains("")
    Private _SubjFilter As New MessageBus.cSubjectContains("")

    Private _iListCount As Long = 0



    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call.
        
    End Sub


    Private Sub MessageReceiver_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        bOutputmessages = Me.chkShowMsgs.Checked

        Me.Text = "Message receiver #" & oRec.ID

        '// Set the filters - the message must match the three filters, type, role and subject
        oRec.Filter = New MessageBus.cTypeContains("RPT")

        oRec.Filter.Or_(_RoleFilter.And_(_TypeFilter).And_(_SubjFilter))



        '// Connect to the bus
        oRec.Connect()

    End Sub


    Private _iMCount As Long
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        '// ////////////////////////
        '// Timer1 uses the GUI thread, so it
        '// can write to the form controls.
        oRec.DeliverWaitingMessages()

    End Sub

    Private Sub ProcessMessage(ByVal oMessage As MessageBus.cMessage) Handles oRec.MessageReceived

        _iMCount += 1


        If bOutputmessages Then
            _iListCount += 1
            Me.ListBox1.Items.Add("[" & _iListCount & "] Type=" & oMessage.Type & ": SenderRole:" & oMessage.SenderRole & ", Subject=" & oMessage.Subject & ", Text=" & oMessage.Content)
            ListBox1.TopIndex = ListBox1.Items.Count - 1
        End If


        Select Case oMessage.Type.ToUpper
            Case "RPT"
                oRec.StatsReport()

        End Select

    End Sub

    Private Sub BusStopped() Handles oRec.Stopped
        Me.ListBox1.Items.Add("Bus stopped")
        ListBox1.TopIndex = ListBox1.Items.Count - 1
        ListBox1.BackColor = Color.LightGray

        '// Turn of the timer
        Me.Timer1.Enabled = False

    End Sub

    Private Sub txtSRFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtSRFilter.TextChanged
        _RoleFilter.FilterString = txtSRFilter.Text
    End Sub

    Private Sub txtTFilter_TextChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles txtTFilter.TextChanged
        _TypeFilter.FilterString = txtTFilter.Text
    End Sub

    Private Sub txtSFilter_TextChanged(ByVal sender As Object, ByVal e As EventArgs) Handles txtSFilter.TextChanged
        _SubjFilter.FilterString = txtSFilter.Text
    End Sub

    Private Sub btnClear_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnClear.Click
        ListBox1.Items.Clear()
    End Sub

    Private Sub chkShowMsgs_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles chkShowMsgs.CheckedChanged
        bOutputmessages = chkShowMsgs.Checked
        If Not bOutputmessages Then _iListCount = 0

    End Sub



    Private Sub oRec_Stopped() Handles oRec.Stopped

    End Sub

    Protected Overrides Sub Finalize()
        Me.Timer1.Enabled = False
        Me.Timer1 = Nothing

        MyBase.Finalize()
    End Sub

    Private Sub btnReceiveForInterval_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnReceiveForInterval.Click
        _iListCount = 0
        bOutputmessages = True
        ReceiveIntervalTimer.Enabled = True

    End Sub

    Private Sub ReceiveIntervalTimer_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles ReceiveIntervalTimer.Tick
        ReceiveIntervalTimer.Enabled = False
        bOutputmessages = False

    End Sub

    Private Sub ListBox1_SelectedIndexChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ListBox1.SelectedIndexChanged

    End Sub
End Class