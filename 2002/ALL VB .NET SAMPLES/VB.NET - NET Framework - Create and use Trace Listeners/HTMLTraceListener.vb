Option Strict On

Imports System
Imports System.IO

' This class was created to output trace messages to an HTML file using tags

Public Class HTMLTraceListener
    Inherits System.Diagnostics.TextWriterTraceListener

    ' Use constructor from TextWriterTraceListener to write to a stream
    Public Sub New(ByVal stream As Stream)
        MyBase.New(stream)
    End Sub

    Public Sub WriteHeader(ByVal Title As String)
        ' New method to add a title to the top of the HTML document
        Writer.WriteLine("<head>")
        Writer.WriteLine("<title>" & Title & "</title>")
        Writer.WriteLine("</head>")
        Writer.WriteLine("<H2>" & Title & "</H2>")
        Writer.WriteLine("<P><HR>")

    End Sub

    Protected Overloads Overrides Sub WriteIndent()
        ' Override WriteIndent to handle indention in an HTML document
        ' using &nbsp; for a space
        Dim i As Integer
        Dim j As Integer

        If IndentLevel > 0 Then
            For i = 1 To IndentLevel
                For j = 1 To IndentSize
                    Writer.Write("&nbsp;")
                Next j
            Next i
        End If

    End Sub

    Public Overloads Overrides Sub WriteLine(ByVal message As String)
        ' Override WriteLine Method to add tags to output message
        Writer.Write("<B>" & Now() & " - ")

        If NeedIndent Then
            WriteIndent()
        End If

        Writer.WriteLine(message & "</B><BR>")
    End Sub

End Class
