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
    ''' The cBus class is the base class of all the
    ''' messagebus classes. It holds the singleton
    ''' buslink that publishes messages through an
    ''' event. 
    ''' </summary>
    Public Class cBus

        '// ///////////////////////////////////////
        ''' <summary>
        ''' The BusLink class is used only
        ''' as the means of propagating a 
        ''' message from senders to all receivers.
        ''' </summary>
        Protected Class cBusLink
            '// Event published with new message
            Public Event NewMessage(ByVal oMessage As cMessage)

            '// Event published when bus is stopped
            Public Event StopBus()

            '// Flag to indicate that the bus has been
            '// stopped. Provides orderly shutdown
            Private BusStopped As Boolean = False


            '// Method to publish a message
            Public Sub PublishMessage(ByVal oMessage As cMessage)
                If BusStopped Then Exit Sub
                RaiseEvent NewMessage(oMessage)
            End Sub

            '// Method to stop the bus
            Public Sub StopBusNow()
                BusStopped = True
                RaiseEvent StopBus()
            End Sub
        End Class

        '// Global shared single instance of cBusLink
        '// used to send messages to all receivers
        Protected Shared oBusLink As New cBusLink

        '// Global shared flag indicating the bus has
        '// been stopped
        Protected Shared BusStopped As Boolean = False


        '// ///////////////////////////////////////
        '// ID generator is used by other classes to 
        '// generate unique sequence numbers
        Protected Class cIDGenerator
            Private _ID As Long = 0
            Public Function NextID() As Long
                _ID += 1
                Return _ID
            End Function
        End Class


        '// ////////////////////////////////////
        '// Public method to stop the bus before
        '// closedown. Ensures orderly closedown.
        Public Shared Sub StopBusNow()
            BusStopped = True

            oBusLink.StopBusNow()
        End Sub

    End Class

End Namespace