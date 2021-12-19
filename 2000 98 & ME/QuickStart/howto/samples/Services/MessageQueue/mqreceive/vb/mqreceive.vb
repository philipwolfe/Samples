Imports System
Imports System.Messaging

Class MQReceive
    public Shared Sub Main()
                Dim appName As String= Environment.GetCommandLineArgs()(0)
                Dim queuePath As String= Environment.GetCommandLineArgs()(1)


                if(Environment.GetCommandLineArgs().Length <> 2) then
                        Console.WriteLine("Usage: " + appName +" <queue>")
                        Exit Sub
                end if

                Dim mqPath As String = ".\" + queuePath

                if(Not MessageQueue.Exists(mqPath)) then
                        Console.WriteLine("The queue '" + mqPath + "' does not exist!")
                        Exit Sub
                end if

                Dim mq As MessageQueue = new MessageQueue(mqPath)
                Dim formatter As XmlMessageFormatter = CType(mq.Formatter,XmlMessageFormatter)
                formatter.TargetTypeNames = new String(){"System.String"}

                Try
                        Dim m As Message = mq.Receive(new TimeSpan(0,0,3))
                        Console.WriteLine("Message: " + CStr(m.Body))
                Catch e As MessageQueueException
                        Console.WriteLine("There are no messages in the queue")
                        Exit Sub
                Catch e As InvalidOperationException
                        Console.WriteLine("The message removed from the queue is not a string")
                        Exit Sub
                End Try
     End Sub
End Class