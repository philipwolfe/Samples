Imports System
Imports System.Diagnostics
Imports System.Threading

Namespace PrInfo

    Module PrInfo

        Public Sub Main()

            Dim args As String()
            Dim appName As String
            args = Environment.GetCommandLineArgs()
            appName = args(0)
        
            If (args.Length <> 3 And (args.Length <> 2 Or args(1) <> "e")) Then
                Console.WriteLine("Usage: ")
                Console.WriteLine("    " + appName + " e: Enumerate processes")
                Console.WriteLine("    " + appName + " <command> <process_id>")
                Console.WriteLine("")
                Console.WriteLine("         <command> =")
                Console.WriteLine("            i: Show process info")
                Console.WriteLine("            c: Close")
                Console.WriteLine("            k: Kill")
                Console.WriteLine("            p: show curent priority")
                Exit Sub
            End If

            Dim command As String
            command = args(1)
        
            If (command = "e") Then
                Dim processes() As Process
                processes = Process.GetProcesses()

                Dim process As Process
                Dim i As Integer
                For i = 0 To processes.length - 1
                    process = processes(i)
                    Console.WriteLine(CStr(process.Id) + "    : " + process.ProcessName)
                Next
            Else
                Dim processid As int32
                processid = Int32.FromString(args(2))
                Dim process As Process
                process = Process.GetProcessById(processid)
            
                Select Case (command)
                    Case "c"
                        process.CloseMainWindow()
                    case "k":
                        process.Kill()
                    case "p":
                        Console.WriteLine("Priority: " + CStr(process.PriorityClass))
                    case "i":
                        Console.WriteLine("Priority Class         :{0}", CStr(process.PriorityClass))
                        Console.WriteLine("Handle Count           :{0}", process.HandleCount)
                        Console.WriteLine("Main Window Title      :{0}", process.MainWindowTitle)
                        Console.WriteLine("Min Working Set        :{0}", process.MinWorkingSet)
                        Console.WriteLine("Max Working Set        :{0}", process.MaxWorkingSet)
                        Console.WriteLine("Paged Memory Size      :{0}", process.PagedMemorySize)
                        Console.WriteLine("Peak Paged Memory Size :{0}", process.PeakPagedMemorySize)
                End Select
            End If
        End Sub
    End Module
End Namespace
