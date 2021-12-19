Imports System
Imports System.Messaging

Public Class MQSend	

    Shared Sub Main()

        Dim appName As String = Environment.GetCommandLineArgs()(0)
        Dim queuePath As String = Environment.GetCommandLineArgs()(1)
        Dim message As String = Environment.GetCommandLineArgs()(2)
        
        if(Environment.GetCommandLineArgs().Length <> 3) then
            Console.WriteLine("Usage: " + appName +" <queue> <message>")
            Exit Sub
        End if
                              
        Dim mqPath As String = ".\" + queuePath
        if( Not MessageQueue.Exists(mqPath)) then       
            MessageQueue.Create(mqPath)
        End if
		
        Dim mq As MessageQueue = new MessageQueue(mqPath)
        mq.Send(message)

    End Sub

End Class