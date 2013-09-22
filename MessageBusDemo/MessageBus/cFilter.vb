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
    ''' The filter base class is used to implement
    ''' message filtering on incoming messages
    ''' at each receiver. Filters can be grouped in
    ''' AND and OR groups - the message is
    ''' included if it matches all filters in the
    ''' AND group or any filter in the OR group.
    ''' </summary>
    Public MustInherit Class cFilter
        Inherits cBus

        '// A collection of filters which this filter must AND
        '// with to allow the message through
        Private oAnds As New System.Collections.Generic.List(Of cFilter)

        '// A collection of filters which this filter must OR
        '// with to allow the message through
        Private oOrs As New System.Collections.Generic.List(Of cFilter)

        '// Check if the message is included by this filter
        Public Function bInclude(ByVal oMessage As cMessage) As Boolean
            Dim bResult As Boolean

            '// First, test this filter alone
            bResult = bMatches(oMessage)
            Dim oFF As cFilter

            '// If this filter matches, then check all the
            '// ANDs to see if they also match
            If bResult Then
                For Each oFF In oAnds
                    bResult = oFF.bMatches(oMessage)

                    '// As soon as we find the first failure to
                    '// match we know the result is a non-match
                    '// for this filter and all its ANDs
                    If Not bResult Then Exit For
                Next
            End If

            '// If all the ANDS were true, then the whole result 
            '// is true regardless of the OR result.
            If bResult Then Return True

            '// The ANDs did not match, so now
            '// we find if any one OR matches, and if so 
            '// the result is true
            For Each oFF In oOrs
                bResult = oFF.bInclude(oMessage)
                If bResult Then Return True
            Next oFF

            '// No match on any of the ORS, so
            '// the message does not match this filter
            Return False

        End Function

        '// ///////////////////////////////////
        '// This method must be overridden in child
        '// classes to implement the matching test.
        Protected MustOverride Function bMatches( _
            ByVal omessage As cMessage) As Boolean

        '// ///////////////////////////////////
        '// These methods add a given filter to the
        '// ANDs or ORs collections to build filtering
        '// logic.
        Public Function And_(ByVal oFilter As cFilter) As cFilter
            oAnds.Add(oFilter)
            Return Me
        End Function
        Public Function Or_(ByVal ofilter As cFilter) As cFilter
            oOrs.Add(ofilter)
            Return Me
        End Function
        Public Function Or_Not(ByVal ofilter As cFilter) As cFilter
            oOrs.Add(Not_(ofilter))
            Return Me
        End Function
        Public Function And_Not(ByVal oFilter As cFilter) As cFilter
            oAnds.Add(Not_(oFilter))
            Return Me
        End Function
        '//
        '// ///////////////////////////////////////


        '// ///////////////////////////////////////
        '// Class and function to provide negation
        '// of a filter condition
        Private Class cNot
            Inherits cFilter
            Private oNotFilter As cFilter
            Public Sub New(ByVal oFilter As cFilter)
                oNotFilter = oFilter
            End Sub
            Protected Overrides Function bMatches(ByVal omessage As cMessage) As Boolean
                Return Not oNotFilter.bMatches(omessage)
            End Function
        End Class

        Private Function Not_(ByVal oFilter As cFilter) As cFilter
            Return New cNot(oFilter)
        End Function
        '//
        '// /////////////////////////////////////////////

    End Class

#Region "Filter implementations"

    '// /////////////////////////////////////////
    '// Derived specialised classes for implementing
    '// different specific filters.
    Public Class cTypeContains
        Inherits cFilter

        Public FilterString As String
        Public Sub New(ByVal sFilter As String)
            FilterString = sFilter
        End Sub

        Protected Overrides Function bMatches( _
            ByVal oMessage As cMessage) As Boolean

            Return oMessage.Type.Contains(FilterString)
        End Function

    End Class

    Public Class cTypeEquals
        Inherits cFilter

        Public FilterString As String
        Public Sub New(ByVal sFilter As String)
            FilterString = sFilter
        End Sub

        Protected Overrides Function bMatches( _
            ByVal oMessage As cMessage) As Boolean

            Return oMessage.Type = FilterString
        End Function

    End Class


    Public Class cRoleContains
        Inherits cFilter
        Public FilterString As String
        Public Sub New(ByVal sFilter As String)
            FilterString = sFilter
        End Sub

        Protected Overrides Function bMatches( _
            ByVal oMessage As cMessage) As Boolean

            Return oMessage.SenderRole.Contains(FilterString)
        End Function
    End Class

    Public Class cRoleEquals
        Inherits cFilter
        Public FilterString As String
        Public Sub New(ByVal sFilter As String)
            FilterString = sFilter
        End Sub

        Protected Overrides Function bMatches( _
            ByVal oMessage As cMessage) As Boolean

            Return oMessage.SenderRole = FilterString
        End Function
    End Class

    Public Class cSubjectContains
        Inherits cFilter
        Public FilterString As String
        Public Sub New(ByVal sFilter As String)
            FilterString = sFilter
        End Sub

        Protected Overrides Function bMatches( _
            ByVal oMessage As cMessage) As Boolean

            Return oMessage.Subject.Contains(FilterString)
        End Function
    End Class

    Public Class cSubjectEquals
        Inherits cFilter
        Public FilterString As String
        Public Sub New(ByVal sFilter As String)
            FilterString = sFilter
        End Sub

        Protected Overrides Function bMatches( _
            ByVal oMessage As cMessage) As Boolean

            Return oMessage.Subject = FilterString
        End Function
    End Class

    Public Class cRoleTypeSubjectFilter
        Inherits cFilter
        Public sRole As String = ""
        Public sType As String = ""
        Public sSubject As String = ""


        Protected Overrides Function bMatches( _
            ByVal oMessage As cMessage) As Boolean

            Return oMessage.Type = sType _
                    And oMessage.SenderRole = sRole _
                    And oMessage.Subject = sSubject
        End Function

    End Class
    '//
    '///////////////////////////////////////////////

#End Region

End Namespace
