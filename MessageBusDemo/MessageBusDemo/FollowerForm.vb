
#Region "Copyright (c) 2012 Chorus Consulting Ltd"
'// Copyright (c) 2012 Chorus Consulting Ltd
'// 
'// GNU General Public License Usage
'//
'// Chorus MessageBusDemo is free software: you can use it and/or
'// redistribute it and/or modify it under the terms of the
'// GNU General Public License, version 3, as published
'// by the Free Software Foundation.
'//
'// Chorus MessageBus is distributed WITHOUT ANY WARRANTY, 
'// and without any implied warranty of MERCHANTABILITY or
'// FITNESS FOR A PARTICULAR PURPOSE. 
'//
'// See the GNU General Public License for more
'// details at <http://www.gnu.org/licenses/>.
'//
'// If you wish to use the Chorus MessageBusDemo and are unsure
'// whether the GNU General Public Usage license is appropriate
'// for your use, please contact Chorus Consulting Ltd at
'// <mail://info@chorusconsulting.co.uk>
'//
#End Region

Public Class FollowerForm

    Private WithEvents oMMRec As New MessageBus.cReceiver
    Private WithEvents oTimeRec As New MessageBus.cReceiver

    Private WithEvents oGuiThread As Timer

    Public Sub New()

        ' This call is required by the Windows Form Designer.
        InitializeComponent()

        '// Connect up the two message receivers.
        oMMRec.Filter = New MessageBus.cTypeEquals("M").And_(New MessageBus.cRoleEquals("MM"))
        oMMRec.Connect()
        oTimeRec.Filter = New MessageBus.cRoleEquals("CLOCK").And_(New MessageBus.cTypeEquals("TIME"))
        oTimeRec.Connect()
        oGuiThread = MainForm.GUIThread
        Dim oS As New MessageBus.cSender("FF")

        oS.SendMessage(New cClockSyncRequest)

    End Sub



    Private Sub oMMRec_MessageReceived(ByVal oMessage As MessageBus.cMessage) Handles oMMRec.MessageReceived
        Dim iX As Integer, iY As Integer
        Dim sP() As String
        sP = oMessage.Content.Split("|")
        iX = CInt(sP(0))
        iY = CInt(sP(1))
        pbFollower.Left = iX
        pbFollower.Top = iY

    End Sub



    Private Sub oGuiThread_Tick(ByVal sender As Object, ByVal e As System.EventArgs) Handles oGuiThread.Tick
        oMMRec.DeliverWaitingMessages()
        oTimeRec.DeliverWaitingMessages()

    End Sub

    Private Sub FollowerForm_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

    End Sub

    Private Sub oTimeRec_MessageReceived(ByVal oMessage As MessageBus.cMessage) Handles oTimeRec.MessageReceived
        Dim oTM As cClockMessage
        oTM = oMessage
        Select Case oTM.TickType
            Case "H"
                lblH.Text = oTM.TickValue
            Case "M"
                lblM.Text = oTM.TickValue
            Case "S"
                lblS.Text = oTM.TickValue
            Case "T"
                lblT.Text = oTM.TickValue

        End Select
    End Sub
End Class