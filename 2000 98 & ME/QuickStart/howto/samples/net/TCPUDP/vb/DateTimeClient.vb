
Imports System
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Text

Public Class Client
    
    Public Shared Sub Main()
        Dim tcpc As New TCPClient()
        Dim read(35) As Byte
        Dim args As String() = Environment.GetCommandLineArgs()
        
        If (args.Length < 2) Then
            Console.WriteLine("Please specify a server name in the command line")
            Exit Sub
        End If
        
        Dim server As String = args(1)
        
        ' Verify that the server exists
        Try
            DNS.GetHostByName(server)
        Catch
            Console.WriteLine("Cannot find server: " + server)
            Exit Sub
        End Try
        
        
        ' Try to connect to the server
        If (tcpc.Connect(server, 13) = -1) Then
            Console.WriteLine("Cannot connect to server: " + server)
            Exit Sub
        End If
        
        ' Get the stream
        Dim s As Stream = tcpc.GetStream()
        
        ' Read the stream and convert it to ASII
        Dim bytes As Integer = s.Read(read, 0, read.Length)
        Dim Time As String = Encoding.ASCII.GetString(read)
        
        ' Display the data
        Console.WriteLine("Received " & bytes & " bytes")
        Console.WriteLine("Current date and time is: " & Time)
        
        tcpc.Close()
        
        ' Wait for user response to exit
        Console.WriteLine("Press Return to exit")
        Console.Read()
    End Sub
    
End Class
