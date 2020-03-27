Imports System
Imports System.Collections.Generic
Imports System.ComponentModel
Imports System.Data
Imports System.Drawing
Imports System.Text
Imports System.Threading
Imports System.Windows.Forms
Imports System.Net

 _
Class Form1
    Dim t As Thread
    ' 
    ' Direct the server to stop processing and exit the app
    ' 
    Private Sub button1_Click(ByVal sender As Object, ByVal e As EventArgs) Handles button1.Click
        runServer = False
        t.Abort()
    End Sub 'button1_Click


    ' Once the form is loaded, start a thread to spin up HttpListener
    ' We need to run a separate thread to co-exist with windows forms
    Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
        ' Create the listener and direct it to localhost requests on port 8080
        t = New Thread(New ThreadStart(AddressOf Start))
        t.Start()
    End Sub 'Form1_Load

    ' Thread method to create the listener and direct it to localhost requests on port 8080
    Private Sub Start()
        AsynchronousListener(New String() {"http://localhost:8080/"})
    End Sub 'Start

    ' Flag indicating the server should continue processing requests.
    Public Shared runServer As Boolean = True

    ' Delegate to allow cross-thread update of UI safely
    Delegate Sub InvokeControl(ByVal [text] As String)

    Private Shared listener As HttpListener

    ' Asynchronous HTTP listener.  Instantiates and starts the HttpListener class,
    ' adds the prefix URI's to listen for, and enters the asynchronous processing loop
    ' until the runServer flag is set false.
    ' Param name prefixes is the URI prefix array to which the server responds
    Public Sub AsynchronousListener(ByVal prefixes() As String)
        ' spin up listener
        listener = New HttpListener()
        ' add URI prefixes to listen for
        Dim s As String
        For Each s In prefixes
            listener.Prefixes.Add(s)
        Next s
        listener.Start()
        ' Create the delegate using the method to update the UI
        Dim _invokeControl As New InvokeControl(AddressOf InvokeUIThread)

        listBox1.Invoke(_invokeControl, "Entering request processing loop")
        While runServer
            Dim result As IAsyncResult = listener.BeginGetContext(New AsyncCallback(AddressOf AsynchronousListenerCallback), listener)
            ' intermediate work can go on here while waiting for the asynchronous callback
            ' an asynchronous wait handle is used to prevent this thread from terminating
            ' while waiting for the asynchronous operation to complete.
            listBox1.Invoke(_invokeControl, "Waiting for asyncronous request processing.")
            result.AsyncWaitHandle.WaitOne()
            listBox1.Invoke(_invokeControl, "Asynchronous request processed.")
        End While
        ' If the runServer flag gets set to false, stop the server and close the listener.
        listener.Close()
    End Sub 'AsynchronousListener

    '/ In order to safely update the UI across threads, a delegate with this method is
    '/ called using Control.Invoke
    Private Shared Sub InvokeUIThread(ByVal [text] As String)
        form1.listBox1.Items.Add([text])
    End Sub 'InvokeUIThread

    ' Method called back when a client connects.  BeginGetContext contains the AsynchCallback delegate
    ' for this method.
    ' param name result is the state object containing the HttpListener instance
    Public Sub AsynchronousListenerCallback(ByVal result As IAsyncResult)
        Try
            Dim listener As HttpListener = CType(result.AsyncState, HttpListener)
            ' Call EndGetContext to signal the completion of the asynchronous operation.
            Dim context As HttpListenerContext = listener.EndGetContext(result)
            Dim request As HttpListenerRequest = context.Request
            ' Get the response object to send our confirmation.
            Dim response As HttpListenerResponse = context.Response
            ' Construct a minimal response string.
            Dim responseString As String = "<HTML><BODY><H1>You have contacted an HttpListener web server</H1></BODY></HTML>"
            Dim buffer As Byte() = System.Text.Encoding.UTF8.GetBytes(responseString)
            ' Get the response OutputStream and write the response to it.
            response.ContentLength64 = buffer.Length
            ' Identify the content type.
            response.ContentType = "text/html"
            Dim output As System.IO.Stream = response.OutputStream
            output.Write(buffer, 0, buffer.Length)
            ' Properly flush and close the output stream
            output.Flush()
            output.Close()
        Catch ex As Exception
            Application.Exit()
        End Try
    End Sub 'AsynchronousListenerCallback

    Private Sub Form1_FormClosing(ByVal sender As System.Object, ByVal e As System.Windows.Forms.FormClosingEventArgs) Handles MyBase.FormClosing
        runServer = False
        t.Abort()
    End Sub
End Class 'Form1 
