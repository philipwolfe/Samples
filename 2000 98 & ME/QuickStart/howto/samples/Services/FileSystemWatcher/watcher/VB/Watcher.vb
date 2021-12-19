Imports System
Imports System.Reflection
Imports System.Diagnostics
Imports System.IO
Imports System.Threading

Namespace Watcher

    Module Watcher

        Public Sub Main()
            Dim args As String()
            Dim appName As String
            args = Environment.GetCommandLineArgs()
            appName = args(0)

            If (args.Length <> 2) Then
                Console.WriteLine("Usage: " + appname + "<directory>")

            Else
                Dim watcher As FileSystemWatcher
                watcher = New FileSystemWatcher
                watcher.Path = args(1)
                watcher.Target = WatcherTarget.File
                watcher.ChangedFilter = ChangedFilters.Attributes BitOr ChangedFilters.LastAccess BitOr ChangedFilters.LastWrite BitOr ChangedFilters.Security BitOr ChangedFilters.Size
        
                AddHandler watcher.Changed, AddressOf OnChanged
                AddHandler watcher.Created, AddressOf OnChanged
                AddHandler watcher.Deleted, AddressOf OnChanged
                AddHandler watcher.Renamed, AddressOf OnRenamed
        
                watcher.Enabled = True
            End If

            Console.WriteLine("Press Enter to quit the sample")
            Console.WriteLine()
            Console.ReadLine()
        End Sub

        Public Sub OnChanged(ByVal source As Object, ByVal e As FileSystemEventArgs)
            Dim change As String
            Select e.ChangeType
                Case WatcherChangeTypes.Changed: change = "Changed"
                Case WatcherChangeTypes.Created: change = "Created"
                Case WatcherChangeTypes.Deleted: change = "Deleted"
            End Select
                 
            Console.WriteLine("File: {0} {1}", e.FullPath, change)
        End Sub
    
        Public Sub OnRenamed(ByVal source As Object, ByVal e As RenamedEventArgs)
            Console.WriteLine("File: {0} Renamed to {1}", e.OldFullPath, e.FullPath)
        End Sub

    End Module

End Namespace
