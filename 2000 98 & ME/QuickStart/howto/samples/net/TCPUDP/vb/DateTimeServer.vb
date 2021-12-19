Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class DateTimeServer
    Public Shared Sub temp()
        System.Console.WriteLine("hello")
        Console.Writeline("Hello\n")
    End Sub
    
    Public Shared Sub Main()
        Dim now As Date
        Dim strDateLine As String
        Dim ASCII As Encoding = Encoding.ASCII
        
        Dim tcpl As New TCPListener(13) 'listen on port 13
        
        tcpl.Start()
        
        Console.WriteLine("Waiting for clients to connect")
        Console.WriteLine("Press Ctrl+c to Quit...")
        
        While (True)
            ' Accept will block until someone connects
            Dim s As Socket = tcpl.Accept()
            
            ' Get the current date and time then concatenate it
            ' into a string
            now = DateTime.Now
            strDateLine = now.ToShortDateString() + " " + now.ToLongTimeString()
            
            ' Convert the string to a Byte Array and send it
            Dim byteDateLine() As Byte = ASCII.GetBytes(strDateLine.ToCharArray())
            s.Send(byteDateLine, byteDateLine.Length, 0)
            Console.WriteLine("Sent " + strDateLine)
        End While
    End Sub
End Class