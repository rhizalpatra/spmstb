
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

Imports MessageBusDemo.MessageBus
Imports System.Timers


Public Class cClock
    Dim WithEvents oTimer As New Timer(100)
    Dim tTime As Date = Now

    Dim oSender As New cSender("CLOCK")

    Dim WithEvents oRequestReceiver As New cReceiver()


    Dim nSec As Integer
    Dim nMin As Integer
    Dim nHour As Integer
    Dim nTenths As Integer


    Public Sub New()
        nSec = tTime.Second
        nMin = tTime.Minute
        nHour = tTime.Hour
        nTenths = tTime.Millisecond / 100
        If nTenths = 10 Then nTenths = 9
        ReportHour()
        ReportMin()
        ReportSec()
        ReportTenths()

        oTimer.Enabled = True

        oRequestReceiver.Filter = New cTypeEquals("SYNC").And_(New cSubjectEquals("REQUEST"))
        oRequestReceiver.StartAsync()
        oRequestReceiver.Connect()

    End Sub



    Private Sub oTimer_Elapsed(ByVal sender As Object, ByVal e As System.Timers.ElapsedEventArgs) Handles oTimer.Elapsed
        tTime = Now
        Dim nTS As Integer = tTime.Millisecond / 100
        If nTS = 10 Then nTS = 9

        If nTS <> nTenths Then
            nTenths = nTS
            ReportTenths()
        End If
        If tTime.Second <> nSec Then
            nSec = tTime.Second
            ReportSec()
        End If
        If tTime.Minute <> nMin Then
            nMin = tTime.Minute
            reportmin()
        End If
        If tTime.Hour <> nHour Then
            nHour = tTime.Hour
            reporthour()
        End If

    End Sub

    Private Sub ReportHour()
        oSender.SendMessage(New cClockMessage(nHour, "H"))
    End Sub
    Private Sub ReportMin()
        oSender.SendMessage(New cClockMessage(nMin, "M"))
    End Sub
    Private Sub ReportSec()
        oSender.SendMessage(New cClockMessage(nSec, "S"))
    End Sub
    Private Sub ReportTenths()
        oSender.SendMessage(New cClockMessage(nTenths, "T"))

    End Sub

    Private Sub oRequestReceiver_MessageReceived(ByVal oMessage As MessageBus.cMessage) Handles oRequestReceiver.MessageReceived

        ReportHour()
        ReportMin()
        ReportSec()
        ReportTenths()

    End Sub
End Class
