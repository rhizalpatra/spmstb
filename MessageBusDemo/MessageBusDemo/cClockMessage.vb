
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

Public Class cClockMessage
    Inherits MessageBus.cMessage
    Public TickValue As Integer
    Public TickType As String

    Public Sub New(ByVal pTV As Integer, ByVal pTT As String)
        TickValue = pTV
        TickType = pTT
        Me._SenderRole = "CLOCK"
        Me._Type = "TIME"
    End Sub
End Class
