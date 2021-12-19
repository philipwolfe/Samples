Imports System
Imports System.IO
Imports System.Threading
Imports System.Text
Imports System.ServiceProcess
Imports System.Diagnostics
Module WinServiceMain
    Private Const MyName As String = "WinService" 'service name
    Private Const DirPath As String = "C:\" 'where to watch for files
    Public Sub Main()
        Dim TheService As New WinService()
        TheService.AutoLog = True
        ServiceBase.Run(TheService)
    End Sub

    Public Class WinService : Inherits ServiceBase
        'Write service events to the event log
        Private ELog As EventLog = New EventLog("", ".", MyName)

        'service worker thread
        Private T As Threading.Thread

        Public Sub New()
            MyBase.New()
            'this service can be paused and continued
            Me.CanPauseAndContinue = True
            'MyName is the service name
            Me.ServiceName = MyName

        End Sub
        Public Sub StartWorkerThread()
            Dim Mon As New MonitorFiles()
            'create a new thread
            'mon.StartMonitor is the thread start function
            T = New Threading.Thread(New Threading.ThreadStart(AddressOf Mon.StartMonitor))
            T.Start()
            ELog.WriteEntry("Worker thread started")
        End Sub
        Protected Overrides Sub OnStart(ByVal args() As String)
            ELog.WriteEntry("WinService service started")
            StartWorkerThread()
        End Sub
        Protected Overrides Sub OnStop()
            ELog.WriteEntry("WinService service stopped")
            StopThread()
            MyBase.Dispose()
        End Sub
        Protected Overrides Sub OnPause()
            ELog.WriteEntry("Attempting to interrupt worker thread")
            StopThread()
        End Sub
        Protected Overrides Sub OnContinue()
            ELog.WriteEntry("Attempting to start worker thread")
            StartWorkerThread()
        End Sub
        Private Sub StopThread()
            'first interrupt it if its
            'sleeping
            T.Interrupt()
            'stop it
            T.Suspend()
            'wait for it to stop
            T.Join()
            'kill the object reference
            T = Nothing
            ELog.WriteEntry("Worker thread stopped successfully")
        End Sub
    End Class
    '___________________________________________________________________________________________    
    Private Class MonitorFiles

        Private ELog As EventLog = New EventLog("", ".", MyName)
        Public Sub OnFileRename(ByVal source As Object, ByVal e As RenamedEventArgs)
            'log event
            ELog.WriteEntry("File rename event received for file: " & e.FullPath)
        End Sub
        Public Sub OnFileEvent(ByVal source As Object, ByVal e As FileSystemEventArgs)
            'log event
            ELog.WriteEntry("File event received for file: " & e.FullPath)
        End Sub
        Public Sub StartMonitor()
            'this is the start function for 
            'the worker thread
            'create the file system watcher
            'set the filter
            'set the event handlers via delegates
            'tell it to start watching the folders
            Dim Fw As New FileSystemWatcher()
            Dim result As WaitForChangedResult
            Fw.Path = DirPath

            Fw.IncludeSubdirectories = True
            Fw.Filter = "*.*"
            AddHandler Fw.Created, New FileSystemEventHandler(AddressOf Me.OnFileEvent)
            AddHandler Fw.Changed, New FileSystemEventHandler(AddressOf Me.OnFileEvent)
            AddHandler Fw.Deleted, New FileSystemEventHandler(AddressOf Me.OnFileEvent)
            AddHandler Fw.Renamed, New RenamedEventHandler(AddressOf Me.OnFileRename)

            Fw.EnableRaisingEvents = True
            ELog.WriteEntry("Monitoring changes in " & DirPath)
            Try
                Do
                    'this will put the thread in 
                    'a WaitSleepJoin state waiting for notifications
                    result = Fw.WaitForChanged(WatcherChangeTypes.All)
                Loop
            Catch e As Exception
                'note, stopping the thread
                'throws a System.Threading.ThreadStopException
                'this is fine and is expected whenever you stop
                'or pause the service
                ELog.WriteEntry("An exception occurred while monitoring changes. Exception is: " & e.ToString())
            Finally
                'stop monitoring the directory
                Fw.EnableRaisingEvents = False
                ELog.WriteEntry("Monitoring stopped")
            End Try
        End Sub
    End Class
    '___________________________________________________________________________________________
End Module