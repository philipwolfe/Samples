Imports System
Imports System.Collections
Imports System.Text
Imports System.IO
Imports System.Net
Imports System.Net.Sockets
Imports System.Threading
Imports System.Windows.Forms

Namespace UsingSockets
End Namespace 'UsingSockets
Public Class Form1
    _

    ' The .NET 2.0 socket enhancements include an asynchronous Connect method and a Disconnect method
    ' to allow a socket to be re-used without the overhead of creating a new socket.  The following example uses these
    ' new features to create a socket pool to allow worker threads to rapidly search URL's and retrieve
    ' their home page content.  The new features go hand-in-hand as a disconnected socket can only
    ' be re-used by issuing an asynchronous connect.

    ' Total number of sockets in the pool
    Private Shared SOCKET_POOL_SIZE As Integer = 10

    ' Total number of worker threads
    Private Shared NUMBER_WORKER_THREADS As Integer = 3

    ' Flag to continue thread run
    Public Shared runThreads As Boolean = True

    ' Index into URL list, incremented be each thread
    Private Shared currentURLCounter As Integer = 0

    Private Shared socketPool As New ArrayList(SOCKET_POOL_SIZE)
    Private Shared urlList As New ArrayList()

    ' Delegate to allow cross-thread update of UI safely
    Delegate Sub InvokeControl(ByVal [text] As String)
    Private Shared _invokeControl As InvokeControl

    ' Spins up a number of sockets to send data via TCP
    ' socketPool is the ArrayList to be populated with Socket objects
    Private Sub SpinUpSocketPool(ByVal socketPool As ArrayList)
        Dim i As Integer
        For i = 0 To SOCKET_POOL_SIZE - 1
            socketPool.Add(New Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp))
        Next i
    End Sub 'SpinUpSocketPool
    ' Create a list of URL's by appending a counter to the searchURL
    ' pointing at a handy list of known sequential URL's
    Private Sub CreateURLList()
        Dim i As Integer
        For i = 1 To 100
            urlList.Add(("http://www.a" + i.ToString() + ".com"))
        Next i
    End Sub 'CreateURLList

    ' Thread event notifier for asynchronous connects
    Public Shared allDone As New ManualResetEvent(False)


    ' .NET 2.0 callback that handles the completion of the prior asynchronous 
    ' connect call. The socket is passed contained in the IAsyncResult param via 
    ' the last paramater of Socket.BeginConnect().
    ' ar is the state-containing object
    Public Sub ConnectCallback(ByVal ar As IAsyncResult)
        allDone.Set()
        Dim s As Socket = CType(ar.AsyncState, Socket)
        Try
            s.EndConnect(ar)
        Catch
        End Try
    End Sub 'ConnectCallback

    ' Lock the socket pool and find a non-connected socket, then connect it.
    ' server is The address to connect the socket to
    ' returns the connected socket
    Private Function ConnectSocket(ByVal server As String) As Socket
        Dim s As Socket = Nothing
        ' Get host related information.
        UpdateText("Trying " + server)
        While runThreads
            SyncLock socketPool
                Dim i As Integer
                For i = 0 To SOCKET_POOL_SIZE - 1
                    s = CType(socketPool(i), Socket)
                    If Not s.Connected Then
                        allDone.Reset()
                        Try
                            s.BeginConnect(server, 80, New AsyncCallback(AddressOf ConnectCallback), s)
                        Catch
                        End Try
                        ' possible unknown host
                        ' wait here until the connect finishes.  The callback 
                        ' sets allDone.
                        allDone.WaitOne()
                        Return s
                    End If
                Next i
                UpdateText("Out of Sockets!, waiting...")
                Monitor.Wait(socketPool)
                UpdateText("Socket added to pool, trying recycled socket")
            End SyncLock
        End While
        Return Nothing
    End Function 'ConnectSocket


    '/ Request the home page content for the specified server.
    '/ server is the address from which to retrieve data
    Private Sub SocketSendReceive(ByVal server As String)
        Dim request As String = "GET / HTTP/1.1" + ControlChars.Cr + ControlChars.Lf + "Host: " + server + ControlChars.Cr + ControlChars.Lf + "Connection: Close" + ControlChars.Cr + ControlChars.Lf + ControlChars.Cr + ControlChars.Lf
        Dim bytesSent As [Byte]() = Encoding.ASCII.GetBytes(request)
        Dim bytesReceived(256) As [Byte]

        ' Create a socket connection asynchronously with the specified server and port.
        Dim s As Socket = ConnectSocket(server)

        If s Is Nothing Or Not s.Connected Then
            UpdateText("Failed to connect socket to " + server)
            Return
        End If
        UpdateText("Socket Connected to " + server)
        ' Send request to the server.
        s.Send(bytesSent, bytesSent.Length, 0)

        ' Receive the server home page content.
        Dim bytes As Integer = 0
        Dim page As String = ""

        ' The following will block until the page contents are retrieved
        Do
            bytes = s.Receive(bytesReceived, bytesReceived.Length, 0)
            page = page + Encoding.ASCII.GetString(bytesReceived, 0, bytes)
        Loop While bytes > 0

        ' Use the .NET 2.0 Disconnect method to place the socket back in circulation
        s.Shutdown(SocketShutdown.Both)
        s.Disconnect(True) ' boolean true as argument allows socket reuse
        ' Notify any waiter on the socket pool that a socket has become available
        SyncLock socketPool
            Monitor.Pulse(socketPool)
        End SyncLock

        UpdateText("Retrieved " + page.Length.ToString() + " bytes from " + server)
    End Sub 'SocketSendReceive


    '/ Per-thread method to take next URL from list, incrementing the index into
    '/ the URL list.
    Public Sub Search()
        Dim url As String = Nothing
        While runThreads
            SyncLock urlList
                If currentURLCounter = urlList.Count Then
                    Return
                End If
                url = CType(urlList(currentURLCounter), [String])
                currentURLCounter = currentURLCounter + 1
            End SyncLock
            SocketSendReceive(url)
        End While
    End Sub 'Search

    ' In order to safely update the UI across threads, a delegate with this method is
    ' called using Control.Invoke
    Private Shared Sub InvokeUIThread(ByVal [text] As String)
        form1.listBox1.Items.Add([text])
    End Sub 'InvokeUIThread

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        ' Create the delegate using the method to update the UI
        _invokeControl = New InvokeControl(AddressOf InvokeUIThread)

        CreateURLList()
        SpinUpSocketPool(socketPool)
        Dim threads(NUMBER_WORKER_THREADS) As Thread
        Dim count As Integer
        For count = 1 To threads.Length - 1
            threads(count) = New Thread(New ThreadStart(AddressOf Search))
            threads(count).Start()
        Next count
    End Sub
    Private Sub UpdateText(ByVal [text] As String)
        Try
            listBox1.Invoke(_invokeControl, [text])
        Catch
        End Try
    End Sub 'UpdateText
    Private Sub button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles button1.Click
        runThreads = False
        Application.Exit()
    End Sub

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        runThreads = False
    End Sub
End Class 'Program
