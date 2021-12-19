Imports System
Imports System.Messaging
Imports System.Threading

Class MQReceive
    Public Shared Sub Main()
        Dim appName As String = Environment.GetCommandLineArgs()(0)

        if(Environment.GetCommandLineArgs().Length <> 2) then
            Console.WriteLine("Usage: " + appName +" <queue>")
            Exit Sub
        End if

        Dim mqPath As String = ".\" + Environment.GetCommandLineArgs()(1)

        if(Not MessageQueue.Exists(mqPath))then
            Console.WriteLine("The queue '" + mqPath + "' does not exist!")
        Else
            Dim mq As MessageQueue = new MessageQueue(mqPath)
            Dim formatter As XmlMessageFormatter = CType(mq.Formatter,XmlMessageFormatter)
            formatter.TargetTypeNames = new String(){"System.String"}

            AddHandler mq.ReceiveCompleted, AddressOf OnReceiveCompleted
            mq.BeginReceive()
        End if

        Console.WriteLine("Press Enter to quit the sample")
        Console.ReadLine()
    end sub

    Public Shared Sub OnReceiveCompleted(source As Object, asyncResult As ReceiveAsyncEventArgs)
        Dim mq As MessageQueue = CType(source,MessageQueue)
        Dim m As Message = mq.EndReceive(asyncResult.AsyncResult)
        Console.WriteLine("Message: " + CStr(m.Body))
        mq.BeginReceive()
    end sub
end class