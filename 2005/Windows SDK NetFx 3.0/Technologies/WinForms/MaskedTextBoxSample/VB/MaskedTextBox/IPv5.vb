 '---------------------------------------------------------------------
'  This file is part of the Microsoft .NET Framework SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------

Imports System
Imports System.Globalization

'<summary>
' Summary description for IPv5.
'</summary>

Public Class IPv5

    ' property fields
    Private firstByteValue As Integer
    Private secondByteValue As Integer
    Private thirdByteValue As Integer
    Private fourthByteValue As Integer

    Public Sub New()

    End Sub 'New

    Public Sub New(ByVal ip As String)

    End Sub 'New

    Public Sub New(ByVal firstByte As Integer, ByVal secondByte As Integer, ByVal thirdByte As Integer, ByVal fourthByte As Integer)

        firstByteValue = firstByte
        secondByteValue = secondByte
        thirdByteValue = thirdByte
        fourthByteValue = fourthByte

    End Sub 'New

    Public Shared ReadOnly Property InvalidIPv5() As IPv5

        Get
            Return New IPv5(0, 0, 0, 0)
        End Get

    End Property

    ' properties

    Public Property FirstByte() As Integer

        Get
            Return firstByteValue
        End Get
        Set(ByVal value As Integer)
            firstByteValue = value
        End Set

    End Property

    Public Property SecondByte() As Integer

        Get
            Return secondByteValue
        End Get
        Set(ByVal value As Integer)
            secondByteValue = value
        End Set

    End Property

    Public Property ThirdByte() As Integer

        Get
            Return thirdByteValue
        End Get
        Set(ByVal value As Integer)
            thirdByteValue = value
        End Set

    End Property

    Public Property FourthByte() As Integer

        Get
            Return fourthByteValue
        End Get
        Set(ByVal value As Integer)
            fourthByteValue = value
        End Set

    End Property

    ' Methods
    Public Shared Function Parse(ByVal s As String) As IPv5

        Dim bytes(3) As Integer

        ' Remove any spaces in the string
        s = s.Replace(" ", "")

        ' Split the string into byte strings
        Dim strBytes As String() = s.Split(New Char() {"."c})

        Try
            Dim byteIndex As Integer = 0
            Dim strByte As String
            For Each strByte In strBytes
                ' Try to parse to an integer
                bytes(byteIndex) = Integer.Parse(strByte)

                ' Check bounds
                ' Verify that the last byte is within the valid range 
                ' (1 - 255 for the first three bytes, 0 - 255 for the last byte)
                If bytes(byteIndex) > 255 OrElse (bytes(byteIndex) < 1 AndAlso byteIndex < 3) Then
                    Throw New ArgumentException(String.Format(CultureInfo.CurrentCulture, "The provided string {0} is not a valid IPv5 IP address", s))
                End If
                byteIndex += 1
            Next strByte

        Catch
            Throw New ArgumentException(String.Format(CultureInfo.CurrentCulture, "The provided string {0} is not a valid IPv5 IP address", s))
        End Try

        Return New IPv5(bytes(0), bytes(1), bytes(2), bytes(3))

    End Function 'Parse

    Public Overrides Function ToString() As String

        Return String.Format(CultureInfo.CurrentCulture, "{0}.{1}.{2}.{3}", firstByteValue.ToString(CultureInfo.CurrentCulture), secondByteValue.ToString(CultureInfo.CurrentCulture), thirdByteValue.ToString(CultureInfo.CurrentCulture), fourthByteValue.ToString(CultureInfo.CurrentCulture))

    End Function 'ToString

End Class 'IPv5 