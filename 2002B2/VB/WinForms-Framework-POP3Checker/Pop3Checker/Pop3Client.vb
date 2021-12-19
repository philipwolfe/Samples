Imports System.Net.Sockets
Imports System.Text
Imports Microsoft.VisualBasic

'Stores account-wide information, including number of messages
'and number of bytes these messages consume on the server.
Public Structure Pop3AccountSummary
    Public MessageCount As Integer
    Public TotalBytes As Integer
End Structure

'Manages simple interaction with a POP3 server.
'Following is a sample telnet session with a POP3 server called "server.domain"
'where the user name is "gmb", the password is "dmbsjuz05",
'and the account has 20 messages consuming 35000 bytes.
'
''telnet server.domain 110
'----------------------------------------------------------------------------------
'+OK Microsoft Exchange 2000 POP3 server version 6.0.4417.0 (server.domain) ready.
'user gmb
'+OK
'pass dmbsjuz05
'+OK User successfully logged on.
'stat
'+OK 20 35000
'quit
'+OK Microsoft Exchange 2000 POP3 server version 6.0.4417.0 signing off.
'----------------------------------------------------------------------------------
'Connection to host lost.
Public Class Pop3Client
    'Defaults
    Private Const mcBufferLength As Integer = 32
    Private Const mcMaxReadRetries As Integer = 15
    Private Const mcReadPause As Integer = 1000
    Private Const mcDefaultConnectionTimeout As Integer = 30
    Private Const mcDefaultHostPort As Integer = 110
    
    'Connection state possibilities
    Public Enum ConnectionStates
        Disconnected = 0
        Connected = 1
        Authenticated = 2
    End Enum
    
    Private mHostName As String
    Private mHostPort As Integer = mcDefaultHostPort
    Private mUserName As String
    Private mUserPassword As String
    Private mConnectionTimeout As Integer = mcDefaultConnectionTimeout
    Private mFriendlyName As String
    Private mClient As TCPClient
    Private mStream As NetworkStream
    Private mBuffer() As Byte
    Private mConnectionMessage As String
    Private mConnectionState As ConnectionStates
    Private mAccountSummary As Pop3AccountSummary
    
#Region " Constructors "
    'Pattern: Members are set with specified arguments.
    Public Sub New( _
        ByVal hstName As String, _
        ByVal usrName As String, ByVal usrPwd As String _
    )
        mHostName = hstName
        mUserName = usrName
        mUserPassword = usrPwd
    End Sub

    Public Sub New( _
        ByVal hstName As String, _
        ByVal usrName As String, ByVal usrPwd As String, _
        ByVal hstPort As Integer _
    )
        mHostName = hstName
        mHostPort = hstPort
        mUserName = usrName
        mUserPassword = usrPwd
    End Sub

    Public Sub New( _
        ByVal hstName As String, _
        ByVal usrName As String, ByVal usrPwd As String, _
        ByVal hstPort As Integer, _
        ByVal connTimeout As Integer _
    )
        mHostName = hstName
        mHostPort = hstPort
        mUserName = usrName
        mUserPassword = usrPwd
        mConnectionTimeout = connTimeout
    End Sub
#End Region
    
    'Destruct not implemented as of Beta 1 according to documentation.
    'Otherwise, we would've used that, but this works, too.
    Protected Overrides Sub Finalize()
        Quit()
        Disconnect()
    End Sub
    
    'Sends a string to mStream as bytes. Returns number of sent bytes.
    Private Function Send(ByVal msg As String) As Integer
        Dim buf() As Byte = Encoding.ASCII.GetBytes(msg)
        Try
            mStream.Write(buf, 0, buf.Length)
            Return msg.Length
        catch
            Return 0
        End Try
    End Function
    
    'Receives pieces of message from mStream and concatenates them
    'into a string, which is returned.
    Private Function Receive() As String
        Dim msg As String = "", buf(mcBufferLength) As Byte, bytes As Integer
        Dim retries As Integer, done As Boolean
        Do Until done Or retries = mcMaxReadRetries
            If mStream.CanRead() Then
                mStream.Read(buf, 0, buf.Length)
                msg = msg + Encoding.ASCII.GetString(buf)
                done = Not mStream.DataAvailable
            Else
                retries = retries + 1
                System.Threading.Thread.Sleep(mcReadPause)
            End If
        Loop
        Return msg
    End Function
    
    'Return true if response indicates success; otherwise, return false.
    'POP3 responses begin with "+" or "-" if sent command succeeds
    'or fails, respectively.
    Private Function IsOkay(ByVal msg As String) As Boolean
        Return msg.Substring(0, 1) = "+"
    End Function
    
    'Attempt to connect to POP3 server within mConnectionTimeout window.
    'Populate mConnectionMessage with initial welcome message.
    'Set mConnectionState and return true if connected and
    'welcome message indicates success
    '[response begins with "+" -- see IsOkay()].
    'Otherwise, return false.
    Public Function Connect() As Boolean
        Dim succeeded As Boolean
        If mConnectionState = ConnectionStates.Disconnected Then
            Try
                Dim connTimeout As Integer = mConnectionTimeout * 1000
                mClient = New TCPClient()
                mClient.ReceiveTimeout = connTimeout
                mClient.SendTimeout = connTimeout
                mClient.Connect(mHostName, mHostPort)
                mConnectionState = ConnectionStates.Connected
                mStream = mClient.GetStream()
                Dim rec As String = Receive()
                If IsOkay(rec) Then
                    mConnectionMessage = rec
                    succeeded = True
                Else
                    Quit()
                End If
            Catch exp As Exception
                MsgBox(exp.Message)
            End Try
        End If
        If succeeded Then
            Return True
        Else
            'Just in case we connected, but the welcome message indicates failure,
            'we should disconnect.
            Disconnect()
            Return False
        End If
    End Function
    
    'Closes any open resources and sets mConnectionState.
    Public Function Disconnect() As Boolean
        If mConnectionState <> ConnectionStates.Disconnected Then
            mStream.Close()
            mClient.Close()
            mConnectionState = ConnectionStates.Disconnected
            Return True
        End If
    End Function
    
    'Send "user" (mUserName) and "pass" (mPassword) to server.
    'Change mConnectionState and return true if all responses indicate success;
    'return false otherwise.
    Public Function Authenticate() As Boolean
        If mConnectionState = ConnectionStates.Connected Then
            Dim msg As String = "user " + mUserName + ControlChars.CrLf
            If Send(msg) = msg.Length And IsOkay(Receive()) Then
                msg = "pass " + mUserPassword + ControlChars.CrLf
                If Send(msg) = msg.Length And IsOkay(Receive()) Then
                    mConnectionState = ConnectionStates.Authenticated
                    Return True
                End If
            End If
        End If
    End Function
    
    'Send "quit" request. Return true if response indicate success;
    'return false otherwise.
    Public Function Quit() As Boolean
        If _
            mConnectionState = ConnectionStates.Authenticated Or _
            mConnectionState = ConnectionStates.Connected _
        Then
            Dim msg As String = "quit" + ControlChars.CrLf
            If Send(msg) = msg.Length Then
                Return IsOkay(Receive())
            End If
        End If
    End Function
    
    
    'Send "stat" request. Populate mAccountSummary structure if all
    'responses indicated success; return false otherwise.
    Public Function GetAccountSummary() As Pop3AccountSummary
        If mConnectionState = ConnectionStates.Authenticated Then
            Dim msg As String = "stat" + ControlChars.CrLf
            If Send(msg) = msg.Length Then
                Dim rec As String = Receive()
                If IsOkay(rec) Then
                    Dim strArr() As String = rec.Split(" ".ToCharArray)
                    If strArr.Length = 3 Then
                        mAccountSummary.MessageCount = Convert.ToInt32(strArr(1))
                        mAccountSummary.TotalBytes = Convert.ToInt32(strArr(2))
                        Return mAccountSummary
                    End If
                End If
            End If
        End If
    End Function
    
#Region " Read-only properties "
    
    'Pattern: Read-only properties return member values.
    
    Public ReadOnly Property AccountSummary() As Pop3AccountSummary
        Get
            Return mAccountSummary
        End Get
    End Property
    
    Public ReadOnly Property ConnectionState() As ConnectionStates
        Get
            Return mConnectionState
        End Get
    End Property
    
    Public ReadOnly Property ConnectionMessage() As String
        Get
            Return mConnectionMessage
        End Get
    End Property
    
#End Region
End Class