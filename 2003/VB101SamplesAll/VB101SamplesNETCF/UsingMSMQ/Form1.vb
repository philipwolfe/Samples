Option Strict On

Imports System.Messaging ' For MSMQ

Public Class Form1
    ' The name of the Queue on the device we will be sending / receiving messages to
    Private Const queName As String = ".\private$\destq"

    Private Sub Form1_Load(ByVal sender As Object, ByVal e As System.EventArgs) Handles MyBase.Load
        Dim msmqInit As MSMQInitializer = New MSMQInitializer()
        Try
            ' Write the necessary MSMQ files to the windows directory on the device and
            ' start the message queue
            MessageBox.Show(msmqInit.Init())
            StatusBar1.Text = String.Empty
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    ' Place a new message in the queue
    Private Sub SendMessage(ByVal msg As String)
        Try
            Cursor.Current = Cursors.WaitCursor
            If Not MessageQueue.Exists(queName) Then
                MessageQueue.Create(queName)
            End If

            ' Create MessageQueue instance
            Dim mq As MessageQueue = New MessageQueue(queName)

            ' Create Message
            Dim m As Message = New Message
            m.Label = "msg"
            m.Body = msg

            ' Send Message
            mq.Send(m)
            mq.Close()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Sub

    ' Receive the next message in the queue
    Private Function GetNextMessage() As String
        Dim msg As String = String.Empty
        Try
            Cursor.Current = Cursors.WaitCursor
            If Not MessageQueue.Exists(queName) Then
                Throw New Exception("Message Que " & queName & " Does Not Exist.  Send a Message to Create")
            End If

            ' Create MessageQueue instance
            Dim mq As MessageQueue = New MessageQueue(queName)
            Dim m As Message

            ' Create Formatter for string message
            mq.Formatter = New XmlMessageFormatter(New Type() {GetType(String)})

            ' Peek at message for 2 seconds
            Dim ts As New TimeSpan(0, 0, 2)
            m = mq.Peek(ts) ' prevent deadlock by checking for only 2 secs
            If Not m Is Nothing Then
                m = mq.Receive(ts) ' prevent deadlock by checking for only 2 secs
                mq.Close()
                msg = CStr(m.Body)
            End If
            Return msg
        Catch ex As MessageQueueException
            MessageBox.Show("Queue Empty or Unavailable: " & ex.Message)
            Return msg
        Catch ex As Exception
            MessageBox.Show(ex.Message)
            Return msg
        Finally
            Cursor.Current = Cursors.Default
        End Try
    End Function

    ' Send the string in the SendTextBox control as a string message to the queue
    Private Sub SendButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SendButton.Click
        StatusBar1.Text = "Sending Message..."
        StatusBar1.Update() ' Force text to be updated
        SendMessage(SendTextBox.Text)
        SendTextBox.Text = String.Empty ' Clear textbox to show message was sent
        StatusBar1.Text = "Sending Message...Complete"
    End Sub

    ' Receive the next message in the queue and place in the ReceivedListBox at the end
    Private Sub ReceiveButton_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ReceiveButton.Click
        StatusBar1.Text = "Receiving Message..."
        StatusBar1.Update() ' Force text to be updated
        Dim msg As String = GetNextMessage()
        StatusBar1.Text = "Receiving Message...Complete"

        ' Only add non empty messages
        If msg <> String.Empty Then
            ReceivedListBox.Items.Add(msg)
        End If
    End Sub
End Class
