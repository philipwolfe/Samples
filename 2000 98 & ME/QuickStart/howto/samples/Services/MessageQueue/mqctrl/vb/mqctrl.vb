Imports System
Imports System.Messaging

Public Class MQCtrl
    Public Shared Sub  Main()
        Dim appName As String = Environment.GetCommandLineArgs()(0)

        if(Environment.GetCommandLineArgs().Length <> 4) then
            Console.WriteLine("Usage: ")
            Console.WriteLine("    " + appName +" <queue> <command> <value>")
            Console.WriteLine("")
            Console.WriteLine("        <Command> =")
            Console.WriteLine("            l: change label")
            Console.WriteLine("            s: change queue size")
            Console.WriteLine("            j: change journal size")
            Exit Sub
        End if
        
        Dim mqPath As String = ".\" + Environment.GetCommandLineArgs()(1)
        if(Not MessageQueue.Exists(mqPath)) then
            Console.WriteLine("The queue " + mqPath + " does not exist")
            Exit Sub
        End if
        
        Dim mq As MessageQueue = new MessageQueue(mqPath)

    Dim command As String = Environment.GetCommandLineArgs()(2)
    Dim value As String = Environment.GetCommandLineArgs()(3)
        if(command = "l") then
            mq.Label = value
        elseif(command = "s") then
            mq.MaximumQueueSize = Int32.FromString(value)
        else if(command = "j") then
            mq.MaximumJournalSize = Int32.FromString(value)
        end if
    end sub
end class