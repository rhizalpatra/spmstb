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
    ''' The message to be sent on the bus.
    ''' </summary>
    ''' <remarks>Messages are invariate - once 
    ''' created they cannot be amended. This is
    ''' to ensure that the same message can be 
    ''' delivered to multiple destinations. However
    ''' this is not necessarily the case with 
    ''' the content, so care must be exercised 
    ''' if the content is modified in a multi-
    ''' thread environment!</remarks>
    Public Class cMessage
        Inherits cBus

        '// /////////////////////////////////
        '// This class is a container for allocating message
        '// unique message ids to each mec
        Private Shared _oMsgID As New cIDGenerator

        '// Properties of the message, accessible to derived
        '// classes
        Protected _SenderRole As String = ""
        Protected _SenderRef As String = ""
        Protected _Subject As String = ""
        Protected _Type As String = ""
        Protected _Content As String = ""

        '// Message ID is private, it cannot be changed, 
        '// even by derived classes
        Private _MsgID As Long



        '// /////////////////////////////
        '// Default constructor used only for
        '// derived classes
        Protected Sub New()
            _MsgID = _oMsgID.NextID
        End Sub



        '// /////////////////////////////
        '// Public constructor requires key message
        '// properties to be supplied. The message
        '// cannot be modified thereafter.
        Public Sub New(ByVal SenderRole As String, _
                       ByVal Type As String, _
                       ByVal Subject As String, _
                       Optional ByVal SenderRef As String = "", _
                       Optional ByVal Content As String = "")
            _SenderRole = SenderRole
            _Subject = Subject
            _Type = Type
            _Content = Content
            _SenderRef = SenderRef
            _MsgID = _oMsgID.NextID

        End Sub




        '// /////////////////////////////////////////////////
        '// Property accessors - all read-only so values
        '// cannot be changed by any recipient.
        Public ReadOnly Property SenderRole() As String
            Get
                Return _SenderRole
            End Get
        End Property
        Public ReadOnly Property SenderRef() As String
            Get
                Return _SenderRef
            End Get
        End Property
        Public ReadOnly Property Subject() As String
            Get
                Return _Subject
            End Get
        End Property
        Public ReadOnly Property Type() As String
            Get
                Return _Type
            End Get
        End Property
        Public ReadOnly Property MsgID() As Long
            Get
                Return _MsgID
            End Get
        End Property
        Public ReadOnly Property Content() As String
            Get
                Return _Content
            End Get
        End Property
        '//
        '////////////////////////////


    End Class



End Namespace