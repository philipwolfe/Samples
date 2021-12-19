Imports System
Imports System.Diagnostics
Imports System.Threading
Imports System.Timers
Imports Microsoft.VisualBasic

Public Class PCRead
    Shared objectName As String 
    Shared counterName As String
    Shared instanceName As String
    Shared theCounter As PerformanceCounter

    Public Shared Sub Main()
        Dim appName as String = Environment.GetCommandLineArgs()(0)

        If ( Environment.GetCommandLineArgs().Length <> 4 And Environment.GetCommandLineArgs().Length <> 3 ) Then
            Console.WriteLine("Usage: " + appName + " <object> <counter> [<instance>]")
            Exit Sub
        End if

        objectName  = Environment.GetCommandLineArgs()(1)
        counterName  = Environment.GetCommandLineArgs()(2) 
        instanceName = ""
        If ( Environment.GetCommandLineArgs().Length = 4 ) Then
            instanceName = Environment.GetCommandLineArgs()(3)
        End If
        
        objectName = objectName.Trim()
        counterName = counterName.Trim()
        instanceName = instanceName.Trim()
        
        If ( Not PerformanceCounter.CategoryExists(objectName) ) Then
            Console.WriteLine("Object " + objectName + " does not exists!")
            Exit Sub
        End If

        If ( Not PerformanceCounter.Exists(objectName,counterName) ) Then
            Console.WriteLine("Counter " + counterName + " does not exists!")
            Exit Sub
        End If

        theCounter = new PerformanceCounter(objectName, counterName ,instanceName)

        Dim aTimer As System.Timers.Timer = new System.Timers.Timer()
        AddHandler aTimer.Tick, AddressOf OnTimer

        aTimer.Interval = 500
        aTimer.Enabled = true
        aTimer.AutoReset = false

        Console.WriteLine("Press 'q' to quit the sample")  
        while ( Console.Read()<>113) 
        End While
    End Sub

    Public Shared Sub OnTimer(source As Object, e As EventArgs)      
        Try
            Console.WriteLine("Current value =  " + theCounter.NextValue().ToString())
        Catch
            Console.WriteLine("Instance " + instanceName + " does not exist!")
            Exit Sub
        End Try

        Dim theTimer As System.Timers.Timer = CType(source,System.Timers.Timer)
        theTimer.Enabled = true
    End Sub
End Class