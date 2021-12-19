Imports System
Imports System.Diagnostics
Imports System.Threading

Namespace ProcessDemo

    Module ProcessDemo

        Public Sub Main()
            Dim args As String()
            Dim appName As String
            args = Environment.GetCommandLineArgs()
            appName = args(0)
        
            If (args.Length <> 2) Then
                Console.WriteLine("Usage: " + appName + " <executable>")
                Exit Sub
            End If

            Dim executableFilename As String
            executableFilename = args(1)

            Dim process As Process
            process = New Process
            process.StartInfo.FileName = executableFilename
            process.Start()
        
            process.WaitForInputIdle()
        
            Thread.Sleep(1000)
            If (Not process.CloseMainWindow()) Then
                process.Kill()
            End If

        End Sub

    End Module

End Namespace
