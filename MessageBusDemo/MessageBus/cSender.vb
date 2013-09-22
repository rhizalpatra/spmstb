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

Namespace MessageBus

    Public Class cSender
        Inherits cBus

        '// //////////////////////////////////////////
        '// Queue of messages waiting to be injected
        '// into the message bus. Each sender has its
        '// own private injector queue
        Private _oMsgQ As New System.Collections.Generic.Queue(Of cMessage)

        '// /////////////////////////////////////////
        '// Reference to the global BusLink instance, used
        '// only to pick up the BusStopped event published
        '// by the bus when stopped.
        Private WithEvents oMyBusLink As cBusLink

        '// /////////////////////////////////////////
        '// Event to inform owner the bus has stopped
        Public Event Stopped()

        '// Sender role, used to identify the sender and
        '// provide the key for filtering messages
        '// at the receiver.
        Private _Role As String
        Public ReadOnly Property Role() As String
            Get
                Return _Role
            End Get
        End Property

#Region "Construct and destruct"

        '// //////////////////////////////////////////
        '// Constructor with role (mandatory)
        Public Sub New(ByVal sRole As String)
            _Role = sRole


            '// Set the reference to the buslink to the 
            '// shared instance of the single buslink. We
            '// need this reference to pick up the stop event
            oMyBusLink = oBusLink

        End Sub


        '// //////////////////////////////////////////////
        '// This method is called when the bus is closed down
        Private Sub oBusLink_StopBus() Handles oMyBusLink.StopBus

            SyncLock _oMsgQ
                RaiseEvent Stopped()
            End SyncLock

        End Sub


#End Region

#Region "Sending messages"

        '// /////////////////////////////////////////
        '// Method used by worker thread to place a 
        '// new default cMessage object on the injector
        '// queue.
        Public Function SendNewMessage(ByVal Type As String, _
                                       ByVal Subj As String, _
                                       Optional ByVal Ref As String = "", _
                                       Optional ByVal Content As String = "") As cMessage
            If BusStopped Then Return Nothing

            Dim oM As New cMessage(_Role, Type, Subj, Ref, Content)
            SendMessage(oM)
            Return oM

        End Function

        '// //////////////////////////////////////////
        '// Method used by worker thread to place message 
        '// object on the injector queue. 
        Public Sub SendMessage(ByVal pMessage As cMessage)

            If BusStopped Then Exit Sub

            '// We do not allow Nothing to be sent
            If pMessage Is Nothing Then
                '// Do nothing
                '// We could throw an error here
            Else

                SyncLock _oMsgQ
                    _oMsgQ.Enqueue(pMessage)

                    '// Start the thread only if
                    '// one message on the queue.
                    If _oMsgQ.Count = 1 Then
                        _oInjectorThread.Start()
                    End If

                End SyncLock

            End If
        End Sub

        '// ////////////////////////////////////////
        '// Holds up the caller thread until all the messages
        '// have been injected into the bus
        Public Sub Flush()
            Do Until _oMsgQ.Count = 0
                Threading.Thread.Sleep(2)
            Loop

        End Sub

#End Region

#Region "Message Injector"

        '// //////////////////////////////////////////
        '// Functions run by the thread for injecting messages
        '// into the bus. The thread runs only when at
        '// least one message is waiting in the injector queue.
        Private WithEvents _oInjectorThread As New cThread

        '// //////////////////////////////////////////
        '// Injector Thread fires Run event to place 
        '// messages on the queue
        Private Sub _oInjectorThread_Run() Handles _oInjectorThread.Run

            InjectMessagesNow()

        End Sub

        '// ///////////////////////////////////////////
        '// When the injector thread runs, this function
        '// is called to push all the queued messages into
        '// the bus.
        Private Sub InjectMessagesNow()
            Dim oM As cMessage

            '// Loop until all messages in the 
            '// queue have been injected into the
            '// bus.
            Do
                '// Check if stopped flag was set while
                '// going round loop.
                If BusStopped Then Exit Sub

                '// Get the next message off the
                '// injector queue
                SyncLock _oMsgQ
                    If _oMsgQ.Count > 0 Then
                        oM = _oMsgQ.Dequeue()
                    Else
                        oM = Nothing
                    End If

                    '// Release the lock so that the worker
                    '// process can add new messages to 
                    '// the queue while we are publishing
                    '// this message on the bus
                End SyncLock

                If oM Is Nothing Then
                    '// Queue is empty, so finish the
                    '// loop
                    Exit Do
                End If

                '// Now we have got the message, we can
                '// send it using the single global 
                '// cBusLink which is instantiated in the
                '// base class cBus.

                SyncLock oBusLink
                    oBusLink.PublishMessage(oM)
                End SyncLock

            Loop

        End Sub

#End Region


        Protected Overrides Sub Finalize()
            '// Close down the injector thread
            _oInjectorThread.StopThread()


            MyBase.Finalize()
        End Sub
    End Class

End Namespace