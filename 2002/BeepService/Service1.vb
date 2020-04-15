Imports System.ServiceProcess

'-- This is a very simple Windows Service application that beeps once
'   every five seconds. To install this, you have to open a command
'   prompt in the BeepService\bin directory and type:
'
'       InstallUtil beepservice.exe
'
'   Then go into the Services MMC console and start the BeepService. 
'   To uninstall type:
'
'       InstallUtil /u beepservice.exe
'
'   from the same directory. It must be stopped before you can uninstall.

Public Class Service1
    Inherits System.ServiceProcess.ServiceBase

#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        ' This call is required by the Component Designer.
        InitializeComponent()

        ' Add any initialization after the InitializeComponent() call

    End Sub

    'UserService overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    ' The main entry point for the process
    <MTAThread()> _
    Shared Sub Main()
        Dim ServicesToRun() As System.ServiceProcess.ServiceBase

        ' More than one NT Service may run within the same process. To add
        ' another service to this process, change the following line to
        ' create a second service object. For example,
        '
        '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1, New MySecondUserService}
        '
        ServicesToRun = New System.ServiceProcess.ServiceBase () {New Service1}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  
    ' Do not modify it using the code editor.
    Friend WithEvents Timer1 As System.Timers.Timer
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.Timer1 = New System.Timers.Timer()
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).BeginInit()
        '
        'Timer1
        '
        Me.Timer1.Interval = 5000
        '
        'Service1
        '
        Me.ServiceName = "Service1"
        CType(Me.Timer1, System.ComponentModel.ISupportInitialize).EndInit()

    End Sub

#End Region

    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.
        Timer1.Enabled = True
    End Sub

    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.
        Timer1.Enabled = False
    End Sub

    Private Sub Timer1_Elapsed(ByVal sender As System.Object, ByVal e As System.Timers.ElapsedEventArgs) Handles Timer1.Elapsed
        Beep()
    End Sub

End Class
