'-----------------------------------------------------------------------
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
'-----------------------------------------------------------------------
'  StringWalker class: this string encapsulates string operations in order
'  to provide easy methods that handle surrogates and combining characters
' --------------------------------------------------------------------------

Imports System
Imports System.Runtime.Serialization
Imports System.Globalization
Imports System.Text

Namespace Microsoft.Samples.StringWalker
    <Serializable()> _
    Public Class StringWalkerException
        Inherits Exception

        Public Sub New()
            MyBase.New()
        End Sub

        Public Sub New(ByVal message As String)
            MyBase.New(message)
        End Sub


        Public Sub New(ByVal message As String, ByVal innerException As Exception)
            MyBase.New(message, innerException)
        End Sub

        Protected Sub New(ByVal info As SerializationInfo, ByVal context As StreamingContext)
            MyBase.New(info, context)
        End Sub

    End Class

    Public Class StringWalker
        ' private members
        Private myString As String = String.Empty
        Private myIndex() As Integer
        Private myPos As Integer

        ' public property

        Public ReadOnly Property Length() As Integer
            Get
                If myIndex Is Nothing Then
                    Return 0
                Else
                    Return myIndex.Length
                End If
            End Get
        End Property

        ' constructor
        Public Sub New(ByVal input As String)
            Initialize(input)
        End Sub 'New

        ' ToString overriden method
        Public Overrides Function ToString() As String
            Return myString
        End Function 'ToString

        ' "easy" walking methods: GetFirst, GetNext, GetPrev, GetLast, Get
        ' these are basically wrapper around the GetSubString method
        Public Function GetFirst(ByRef input As String) As Boolean
            myPos = 0
            Return GetElement(myPos, input)
        End Function 'GetFirst

        Public Function GetLast(ByRef input As String) As Boolean
            myPos = Length - 1
            Return GetElement(myPos, input)
        End Function 'GetLast

        Public Function GetNext(ByRef input As String) As Boolean
            myPos = myPos + 1
            Return GetElement(myPos, input)
        End Function 'GetNext

        Public Function GetPrevious(ByRef input As String) As Boolean
            myPos = myPos - 1
            Return GetElement(myPos, input)
        End Function 'GetPrev

        Public Function GetElement(ByVal index As Integer, ByRef input As String) As Boolean
            Return 0 <> GetSubString(index, 1, input)
        End Function 'Get

        ' GetSubString method
        Public Function GetSubString(ByVal index As Integer, ByVal count As Integer, ByRef input As String) As Integer
            ' check for index within bounds and non zero count
            If 1 <= count And 0 <= index And index < Length Then
                Try
                    Dim lastindex As Integer = index + count

                    ' if we are past the last char, then we get the string
                    ' up to the last char and return the actual count
                    If lastindex > Length - 1 Then
                        input = myString.Substring(myIndex(index))
                        Return Length - index
                    Else
                        input = myString.Substring(myIndex(index), myIndex(lastindex) - myIndex(index))
                        Return count
                    End If
                Catch ' catch all and throw our exception
                    Throw (New StringWalkerException())
                End Try
            End If
            input = String.Empty
            Return 0
        End Function 'GetSubString

        ' Insert, Remove: both methods return true if the operation was succesful and false otherwise
        ' Insert: inserts a string at the specified position
        Public Function Insert(ByVal index As Integer, ByVal input As String) As Boolean
            If 0 <= index And index <= Length Then
                Try
                    If index = Length Then
                        Initialize(myString.Insert(myString.Length, input))
                    Else
                        Initialize(myString.Insert(myIndex(index), input))
                    End If
                    Return True
                Catch ' catch all and throw our exception
                    Throw (New StringWalkerException())
                End Try
            End If
            Return False
        End Function 'Insert

        ' Remove: removes the specified number of text elements starting at the specified position
        Public Function Remove(ByVal index As Integer, ByVal count As Integer) As Boolean
            If count > 0 And 0 <= index And index < Length Then
                Try
                    Dim idxLast As Integer = index + count
                    Dim charcount As Integer

                    If idxLast < Length Then
                        charcount = myIndex(idxLast) - myIndex(index)
                    Else
                        charcount = myString.Length - myIndex(index)
                    End If

                    Initialize(myString.Remove(myIndex(index), charcount))
                    Return True
                Catch ' catch all and throw our exception
                    Throw (New StringWalkerException())
                End Try
            End If
            Return False
        End Function 'Remove

        ' IndexOf: 
        Public Function IndexOf(ByVal input As String, ByVal index As Integer) As Integer
            If 0 <= index And index < Length Then
                Try
                    ' try and find the input string in the current string
                    Dim position As Integer = myIndex(index)
                    Dim foundAt As Integer = myString.IndexOf(input, position)

                    ' if the string is found, then we need to see if it
                    ' can be matched to a text element index.
                    If -1 <> foundAt Then
                        Dim i As Integer
                        For i = 0 To myIndex.Length - 1
                            If myIndex(i) = foundAt Then
                                Return i
                            End If
                        Next i
                    End If
                Catch ' catch all and throw our exception
                    Throw (New StringWalkerException())
                End Try
            End If
            Return -1
        End Function 'IndexOf

        ' private initialization method
        Private Sub Initialize(ByVal input As String)
            Try
                myPos = 0
                myString = input
                myIndex = StringInfo.ParseCombiningCharacters(myString)

            Catch ' catch all and throw our exception
                Throw (New StringWalkerException())
            End Try
        End Sub 'Initialize

    End Class 'StringWalker
End Namespace