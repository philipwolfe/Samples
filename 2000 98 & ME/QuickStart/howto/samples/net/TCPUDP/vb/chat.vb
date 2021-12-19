Imports System
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Text

Public Class Chat
    Private Shared m_Client As UDPClient
    
    Private Shared ListenerPort As Integer = 8080
    Private Shared SenderPort As Integer = 8080
    Private Shared LocalPort As Integer
    Private Shared RemotePort As Integer
    
    Private Shared m_szHostName As String
    
    Private Shared m_GroupAddress As IPAddress
    Private Shared m_LocalHost As IPHostEntry
    Private Shared m_RemoteEP As IPEndPoint
    
    Private Shared m_Done As Boolean = False
    
    Public Shared Sub Usage()
        Console.WriteLine("UDP Multicast Chat Utility")
        Console.WriteLine("\nUsage:")
        Console.WriteLine("chat.exe")
    End Sub
    
    Public Shared Sub Main()
        LocalPort = SenderPort
        RemotePort = ListenerPort
        Dim args As String() = Environment.GetCommandLineArgs()
        
        If (args.Length > 1) Then
            ' print help message, as this utility doesnt take any arguments
            Usage()
            Exit Sub
        End If
        
        m_szHostName = DNS.GetHostName()
        m_LocalHost = DNS.GetHostByName(m_szHostName)
        
        Console.WriteLine("Local Port: {0}, Remote: {1}", LocalPort, RemotePort)
        Console.WriteLine("Initializing...")
        
        Initialize()
        Console.WriteLine("Starting Listener thread...")
        
        Dim t As Thread
        t = New Thread(AddressOf Listener)
        t.Start()
        
        Dim buffer() As Byte
        Dim ASCII As Encoding = Encoding.ASCII
        
        Dim m_ShuttingDown As Boolean = False
        
        While (Not (m_ShuttingDown))
            Dim s As String = Console.ReadLine()
            
            If (s.Length = 0) Then
                'continue()
            End If
            
            If (String.Compare(s, 0, "@", 0, 1) = 0) Then
                m_Done = True
                ' send a terminator to ourselves,
                ' so that the receiving thread can shut down
                s = m_szHostName & ":@"
                m_ShuttingDown = True
            Else
                s = m_szHostName + ":" & s
            End If
            
            ReDim buffer(s.Length + 1)
            
            ' send data to remote peer
            
            Dim len As Integer = ASCII.GetBytes(s.ToCharArray(), 0, s.Length, buffer, 0)
            Dim ecode As Integer = m_Client.Send(buffer, len, m_RemoteEP)
            
            If (ecode <= 0) Then Console.WriteLine("Error in send : " & ecode)
        End While
        
        t.Stop()
        t.Join()
        Console.WriteLine("Closing connection...")
        Terminate()
    End Sub 'Main
    
    
    Public Shared Sub Terminate()
        m_Client.DropMulticastGroup(m_GroupAddress)
    End Sub
    
    Public Shared Sub Initialize()
        ' instantiate UDPCLient
        m_Client = New UDPClient(LocalPort)
        
        ' Create an object for Multicast Group
        m_GroupAddress = New IPAddress("224.0.0.1")
        
        ' Join Group
        If (Not m_Client.JoinMulticastGroup(m_GroupAddress)) Then Console.WriteLine("Unable to join multicast group")
        
        ' Create Endpoint for peer
        m_RemoteEP = New IPEndPoint(m_GroupAddress, RemotePort)
        
    End Sub
    
    Public Shared Sub Listener()
        ' The listener waits for data to come
        ' and buffers it.
        
        Try
            Thread.Sleep(2000) ' make sure client2 is receiving
            Dim ASCII As Encoding = Encoding.ASCII
            
            While (Not m_Done)
                Dim endpoint As IPEndPoint
                Dim data() As Byte = m_Client.Receive((endpoint)) ' ByRef?
                
                Dim strData As String = ASCII.GetString(data)
                
                If strData.IndexOf(":@") > 0 Then
                    
                    ' we received a termination indication
                    ' now we have to decide if it is from
                    ' our main thread shutting down, or
                    ' from someone else
                    
                    Dim separators() As Char = {CChar(":")}
                    Dim vars() As String = strData.Split(separators)
                    
                    If (vars(0) = m_szHostName) Then
                        ' this is from ourselves, therefore we end now
                        Console.WriteLine("shutting down Listener thread...")
                        
                        ' this should have been done by main thread, but we
                        ' do it again for safety
                        m_Done = True
                    Else
                        ' this is from someone else
                        Console.WriteLine("{0} has left the conversation", vars(0))
                    End If
                Else
                    ' this is normal data received from others
                    ' as well as ourselves
                    ' check to see if it is from ourselves before
                    ' we print
                    If (strData.IndexOf(":") > 0) Then
                        Dim separators() As Char = {CChar(":")}
                        Dim vars() As String = strData.Split(separators)
                        
                        If (vars(0) <> m_szHostName) Then
                            Console.WriteLine(strData)
                        End If
                    End If
                End If
            End While
        Catch
            console.WriteLine(Environment.StackTrace)
            Exit Sub
        End Try
        Console.WriteLine("Listener thread finished...")
    End Sub
    
End Class

