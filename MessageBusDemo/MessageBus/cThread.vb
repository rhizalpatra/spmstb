

#Region "Copyright (c) 2012 Chorus Consulting Ltd"
'// Copyright (c) 2012 Chorus Consulting Ltd
'// 
'// GNU General Public License Usage
'//
'// Chorus MessageBus is free software: you can use it and/or
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
'// If you wish to use the Chorus MessageBus and are unsure
'// whether the GNU General Public Usage license is appropriate
'// for your use, please contact Chorus Consulting Ltd at
'// <mail://info@chorusconsulting.co.uk>
'//
#End Region

Imports System.Threading

Namespace MessageBus

    '// /////////////////////////////////////////////////////
    '// Provides the thread to run the injector on each
    '// cSender class.
    '//
    Public Class cThread
        Inherits cBus

        Private WithEvents _BusLinkRef As cBusLink = oBusLink


        Private Shared iThreadCount As Long = 0

        '// Event fired to execute the thread's
        '// assigned processes.
        Public Event Run()

        '// Thread object provides the thread
        Private _Thread As New Thread(AddressOf RunThread)

        '// Signal object to block the thread
        '// when there are no messages to be delivered
        Private _Signal As New EventWaitHandle(False, EventResetMode.AutoReset)

        '// Flag to indicate thread has been stopped
        Private bThreadStopped As Boolean = False

        '// Start the thread on creation of the object
        Public Sub New()
            _Thread.Start()
        End Sub

        '// Start called by owner to
        '// unblock this thread.
        Public Sub Start()
            
            If _Thread.ThreadState = ThreadState.Unstarted Then _Thread.Start()

            SyncLock Me
                _Signal.Set()
            End SyncLock
        End Sub

        '// Stop called by owner to close
        '// down thread
        Public Sub StopThread()
            bThreadStopped = True
            _Signal.Set()

        End Sub

        '// Method executed by the thread. This is
        '// a repeated loop until the bus is stopped
        Private Sub RunThread()
            Do
                '// The signal blocks the thread until
                '// it is released by the Start method
                _Signal.WaitOne()

                If bThreadStopped Then

                    Exit Sub
                End If

                '// Raise the thread event that will
                '// do the work.
                RaiseEvent Run()

            Loop
        End Sub

        Private Sub _BusLinkRef_StopBus() Handles _BusLinkRef.StopBus
            StopThread()

        End Sub
    End Class

End Namespace