Imports System
Imports System.ComponentModel
Imports System.Drawing
Imports System.Windows.Forms
Imports System.IO
Imports System.Security
Imports System.Security.Cryptography
Imports Microsoft.VisualBasic

Public Class StoreCryptoStream
    Inherits CryptoStream

    Shared tag() As Byte = {Convert.ToByte("["c), Convert.ToByte("E"c), Convert.ToByte("n"c), CByte("c"c), CByte("]"c), &H20, &H20, &H20}
    Dim fs As FileStream

    '////////////////////////////////////////////////////////////////
    '// Constructor
    Public Sub new(ByVal bEncrypt As Boolean, ByVal fout As FileStream)
        MyBase.new()
        fs = fout
        If bEncrypt Then
            fs.Write(tag, 0, 8)
        End If
    End Sub

    Public Overloads Sub CloseStream()
        fs.Close()

    End Sub


    Public Overloads Sub CloseStream(ByVal obj As Object)
        fs.Close()

    End Sub

    Public Sub SetSink(ByVal pstm As CryptoStream)

    End Sub

    Public Sub SetSource(ByVal co As CryptographicObject)

    End Sub

    Public Function GetSink() As CryptoStream
        Return Nothing
    End Function

    '////////////////////////////////////////////////////////////////
    '// Write routines just copy output ot the target file
    Public Overloads Sub Write(ByVal bin() As Byte)
        Dim len As Integer = bin.GetLength(0)
        Write(bin, 0, len)
    End Sub

    Public Overloads Sub write(ByVal bin() As Byte, ByVal start As Integer, ByVal len As Integer) Implements ICryptoStream.Write
        fs.Write(bin, start, len)
    End Sub



End Class
