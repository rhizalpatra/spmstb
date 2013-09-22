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

    ''' <summary>
    ''' Receives messages from the bus and delivers
    ''' them through the MessageReceived event
    ''' </summary>
    Public Class cReceiver
        Inherits cBus

        '// //////////////////////////////////////
        '// Id generator for all cReceiver objects
        Private Shared _oRecId As New cIDGenerator

        '// //////////////////////////////////////
        '// Event used to deliver a message to the
        '// message handler function
        Public Event MessageReceived(ByVal oMessage As cMessage)

        '// //////////////////////////////////////
        '// Event used to indicate the bus has stopped,
        '// used to ensure orderly shutdown of the bus
        Public Event Stopped()
        Public ReadOnly Property IsStopped() As Boolean
            Get
                Return BusStopped
            End Get
        End Property


        '// //////////////////////////////////////
        '// Message queue holding the messages
        '// waiting to be delivered
        Private _MQueue As New System.Collections.Generic.Queue(Of cMessage)


        '// ///////////////////////////////////////////
        '// Filter set by the recipient to select
        '// messages. Fileter can be by specific role(s),
        '// subjects(s) or type(s) or using more specialised
        '// filters. Filters can be changed at any time. The
        '// default no filter allows all messages through.
        Public Filter As cFilter = Nothing

        '// //////////////////////////////////////////
        '// Reference to the single global buslink
        '// so that the receiver can pick up published
        '// messages from the bus
        Private WithEvents _BusLinkRef As cBusLink

        '// Flag to indicate that this object has been
        '// finalised and is closing.
        Private _Closing As Boolean = False
        Private _RaiseStopEvent As Boolean = False

        '// /////////////////////////////////////////
        '// Unique identifier of this receiver object
        Private _ID As Long

        '// /////////////////////////////////////////
        '// Counts of number of messages received
        '// and delivered
        Private _BCount As Long = 0 ' Messages from the Bus
        Private _RCount As Long = 0 ' Messages received onto the queue  
        Private _DCount As Long = 0 ' Messages delivered to the worker


        '// //////////////////////////////////
        '// Constructor
        Public Sub New()
            _ID = _oRecId.NextID


        End Sub

        '// ///////////////////////////////////
        '// Establishes connection to the bus so that
        '// message delivery can start
        Public Sub Connect()

            '// /////////////////////////////////////////
            '// Set the buslink variable to refer to the
            '// shared buslink so that it delivers
            '// messages through the event handler
            _BusLinkRef = oBusLink
            '// NOTE: oBus is a direct reference to
            '// the protected shared class member.

        End Sub


        '// ////////////////////////////////////////
        '// Breaks the connection with the bus
        '// so that messages are no longer
        '// received.
        Public Sub Disconnect()
            _BusLinkRef = Nothing
        End Sub


        '// /////////////////////////////////
        '// Accessor methods for the readonly
        '// properties
        Public ReadOnly Property BCount() As Long
            '// Bus message count
            Get
                Return _BCount
            End Get
        End Property

        Public ReadOnly Property RCount() As Long
            '// Received message count
            Get
                Return _RCount
            End Get
        End Property

        Public ReadOnly Property DCount() As Long
            '// Delivered message count
            Get
                Return _DCount
            End Get
        End Property

        Public ReadOnly Property QCount() As Long
            '// Queued (waiting) message count
            Get
                If _MQueue IsNot Nothing Then
                    Return _MQueue.Count
                Else
                    Return 0
                End If

            End Get
        End Property

        Public ReadOnly Property ID() As Long
            '// Unique ID number of this receiver
            Get
                Return _ID
            End Get
        End Property


        Public Function MessagesWaiting() As Boolean
            '// Helper property returns true if there 
            '// are messages waiting
            Return QCount > 0
        End Function

#Region "Message arrival"

        '// //////////////////////////////////
        '// This method handles the new message
        '// event from the bus. The message is
        '// queued for delivery.
        Private Sub oBusLink_NewMessage( _
                ByVal oMessage As cMessage _
                ) Handles _BusLinkRef.NewMessage

            '// Discard message if closing, or the bus has stopped
            If _Closing Then Exit Sub
            If BusStopped Then Exit Sub

            _BCount += 1

            '// ////////////////////////////
            '// Check against the filter.
            '// The message must be included by the filter
            '// otherwise it will not be delivered.

            Select Case True
                Case Filter Is Nothing, Filter.bInclude(oMessage)

                    '// ///////////////////////////////
                    '// New message has passed the filter, so
                    '// add it to the message queue waiting
                    '// for delivery to the worker process.
                    AddToQueue(oMessage)
            End Select


        End Sub


        '// ////////////////////////////////
        '// Method used to add messages
        '// to the message queue when they arrive
        '// from the message bus.
        Private Sub AddToQueue(ByVal oMessage As cMessage)

            '// ////////////////////////////////////////////
            '// Check if the queue exists - if not, then
            '// exit without adding a message.
            If _MQueue Is Nothing Then Exit Sub

            '// ////////////////////////////////////////////
            '// Check if closing or stopped, if so exit
            If BusStopped Then Exit Sub
            If _Closing Then Exit Sub

            Dim bStartDelivery As Boolean

            '// ////////////////////////////////////////////
            '// SyncLock the queue to guarantee exclusive
            '// access, then add the message
            SyncLock _MQueue
                _RCount += 1

                _MQueue.Enqueue(oMessage)

                '// ////////////////////////////////////////////////
                '// We start the delivery thread if async AND
                '// this is the first message in the queue
                bStartDelivery = _AsyncMode And _MQueue.Count = 1

            End SyncLock

            '// //////////////////////////////
            '// Check if we need to start the delivery thread
            '// which we do only in async mode and if this is
            '// the first message in the queue
            If bStartDelivery Then
                _DeliveryThread.Start()
            End If

        End Sub

#End Region

#Region "Message delivery"

        '// ////////////////////////////////
        '//
        '//  Message delivery can be made in these
        '//  ways:
        '//  * Asynchronously on a provided thread 
        '//     - call StartAsync to enable this
        '//     - messages are delivered through MessageReceived event
        '//
        '//  * By a call from the worker thread 
        '//     - use GetNextMessage to retrieve the message
        '//
        '//  GetNextMessage returns the next
        '//  message as the function result. 
        '//  It returns Nothing if 
        '//  there is no message in the queue
        '//
        '// ////////////////////////////////

        '// Delivery thread is used with asynch delivery only
        Private WithEvents _DeliveryThread As cThread = Nothing

        Private _AsyncMode As Boolean = False


        '////////////////////////////////////
        '// Starts Asynchronous delivery through the NewMessage event.
        '// Called by the creator/owner to initiate a new thread delivering
        '// messages from this receiver.
        Public Sub StartAsync()

            '// Do nothing if closing, stopped or already in asyinc mode.
            If _Closing Then Exit Sub
            If BusStopped Then Exit Sub
            If _AsyncMode Then Exit Sub

            _AsyncMode = True

            '// Create and start the delivery thread.
            If _DeliveryThread Is Nothing Then _DeliveryThread = New cThread

            _DeliveryThread.Start()

        End Sub


        '// ///////////////////////////////////////////////
        '// Picks up the next message from the queue
        '// if any and returns it. Returns Nothing
        '// if there is no message.
        Public Function GetNextMessage() As cMessage

            '// Do not return anything if closing or stopped
            If _Closing Then Return Nothing
            If BusStopped Then Return Nothing

            Dim oM As cMessage

            '// Lock the queue and get the next message
            SyncLock _MQueue
                If _MQueue.Count > 0 Then
                    oM = _MQueue.Dequeue
                    _DCount += 1
                Else
                    oM = Nothing
                End If
            End SyncLock

            '// Return the message (if any)
            Return oM
        End Function


        '// ///////////////////////////////////////////////
        '// This event handler is called when the thread runs
        '// - only when messages are waiting to be delivered in
        '// async mode
        Private Sub _DeliveryThread_Run() Handles _DeliveryThread.Run

            DeliverWaitingMessages()

        End Sub


        '// ///////////////////////////////////////////////
        '// Delivers all the messages in the incoming
        '// message queue using the MessageReceived event
        Public Sub DeliverWaitingMessages()

            '// Raise the stop event if the bus has been stopped
            If BusStopped Then

                '// Inform the delivery thread
                If _RaiseStopEvent Then
                    RaiseEvent Stopped()
                    _RaiseStopEvent = False
                End If

                Exit Sub
            End If

            '// Do nothing if closing
            If _Closing Then Exit Sub

            '// The queue may be nothing , so simply
            '// exit and try again on the cycle
            If _MQueue Is Nothing Then Exit Sub


            Dim oM As cMessage

            '// Retrieve all the messages and deliver them
            '// using the message received event.
            Do

                '// Lock the queue before dequeuing the message
                SyncLock _MQueue
                    If _MQueue.Count > 0 Then
                        oM = _MQueue.Dequeue
                    Else
                        oM = Nothing
                    End If

                End SyncLock


                '// ///////
                '// After releasing the lock we
                '// can deliver the message.

                If oM IsNot Nothing Then
                    _DCount += 1
                    RaiseEvent MessageReceived(oM)
                End If

                '// If the queue was not empty then loop back for the
                '// next message
            Loop Until oM Is Nothing



        End Sub

#End Region

#Region "Stats Report"

        '////////////////////////////////////////////////
        '// This sub simply publishes a message of
        '// stats about this receiver.
        Public Sub StatsReport()
            If BusStopped Then Exit Sub

            Dim sRpt As String
            sRpt = "Report from Receiver #" & Me.ID
            sRpt &= "|BUS=" & _BCount
            sRpt &= "|REC=" & _RCount
            sRpt &= "|DEL=" & _DCount
            sRpt &= "|Q=" & _MQueue.Count
            sRpt &= "|Closing=" & _Closing

            Dim s As New cSender("Receiver#" & ID)
            s.SendNewMessage("STATS", "STATS", Content:=sRpt)
            s.Flush()
            s = Nothing



        End Sub



#End Region


        '// ///////////////////////////////////
        '// Handler for the stopbus event. Do
        '// not deliver any more messages once the
        '// bus has been stopped.
        Private Sub oBusLinkRef_StopBus() Handles _BusLinkRef.StopBus
            _Closing = True

            '_DeliveryTimer = Nothing
            _AsyncMode = False

            _RaiseStopEvent = True


        End Sub

        '// ////////////////////////////////////
        '// Finalise to tidy up resources when being disposed
        Protected Overrides Sub Finalize()
            If _DeliveryThread IsNot Nothing Then _DeliveryThread.StopThread()
            _Closing = True
            _AsyncMode = False
            _MQueue = Nothing


            MyBase.Finalize()
        End Sub

    End Class

End Namespace