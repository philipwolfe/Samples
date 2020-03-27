Option Strict On

Imports System.ServiceProcess

Public Class VB_NET_HowTo_TimeTrackerService
    Inherits System.ServiceProcess.ServiceBase

    ' Declare the variables that will be used to contain the various
    '   required DateTime and TimeSpan objects
    Private timeStart As DateTime ' Used to note the start time of the service
    Private timeEnd As DateTime ' ' Used to note the end time of the service
    Private timeElapsed As New TimeSpan(0) ' Initialize to 0
    ' Used to calculate difference between timeEnd and TimeStart
    Private timeDifference As TimeSpan
    Private isPaused As Boolean = False ' Notes whether the service is paused


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
        '   ServicesToRun = New System.ServiceProcess.ServiceBase () {New VB_NET_HowTo_TimeTrackerService, New MySecondUserService}
        '
        ServicesToRun = New System.ServiceProcess.ServiceBase() {New VB_NET_HowTo_TimeTrackerService()}

        System.ServiceProcess.ServiceBase.Run(ServicesToRun)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    ' NOTE: The following procedure is required by the Component Designer
    ' It can be modified using the Component Designer.  
    ' Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        '
        'VB_NET_HowTo_TimeTrackerService
        '
        Me.CanPauseAndContinue = True
        Me.CanShutdown = True
        Me.ServiceName = "VB_NET_HowTo_TimeTrackerService"

    End Sub

#End Region

    ' OnContinue occurs when the user asks a paused Service to continue. In order 
    '   for this method to be called the CanPauseAndContinue property must be 
    '   set to True. (It is False by default.)
    Protected Overrides Sub OnContinue()
        ' Begin measuring the elapsed time. This means setting the
        '   timeStart back to the current time, and resetting isPaused
        '   to False
        If isPaused Then
            timeStart = DateTime.Now
        End If
        isPaused = False

        EventLog.WriteEntry("VB.NET How-To Service Continued at " + _
            DateTime.Now().ToString())
    End Sub

    ' OnPause occurs when the user asks a running Service to pause. In order 
    '   for this method to be called the CanPauseAndContinue property must be 
    '   set to True. (It is False by default.)
    Protected Overrides Sub OnPause()
        ' Save the time that's elapsed so far in timeElapsed,
        '   and wait for the user to either Stop the service or 
        '   resume it.
        timeEnd = DateTime.Now()
        If Not isPaused Then
            timeDifference = timeEnd.Subtract(timeStart)
            timeElapsed = timeElapsed.Add(timeDifference)
        End If
        isPaused = True

        EventLog.WriteEntry("VB.NET How-To Service was Paused at " + _
            DateTime.Now().ToString())
    End Sub

    ' OnShutdown occurs when the computer is powered off and the 
    '   Service has not been stopped. In order for this method to be called
    '   the CanShutdown property must be set to True. (It is False by default.)
    Protected Overrides Sub OnShutdown()
        ' Treat the service as being stopped.
        Me.OnStop()
    End Sub

    ' OnStart is called whenever the service is started.
    Protected Overrides Sub OnStart(ByVal args() As String)
        ' Add code here to start your service. This method should set things
        ' in motion so your service can do its work.

        ' Reset timeElapsed to zero. This is necessary since the used can
        '   call Restart without pausing or stopping the service
        timeElapsed = New TimeSpan(0)

        ' Initialize the Start time
        timeStart = DateTime.Now()
        isPaused = False

        EventLog.WriteEntry("The VB.NET How-To Service was Started at " + _
            timeStart.ToString())

    End Sub

    ' OnStop is called whenever the service is stopped.
    Protected Overrides Sub OnStop()
        ' Add code here to perform any tear-down necessary to stop your service.

        ' Calculate the necessary times. If the Service is not currently paused
        '   the timeElapsed must be changed to consider the time its been
        '   running since a start or continue.
        timeEnd = DateTime.Now()
        If Not isPaused Then
            timeDifference = timeEnd.Subtract(timeStart)
            timeElapsed = timeElapsed.Add(timeDifference)
        End If

        EventLog.WriteEntry("The VB.NET How-To Service was Stopped at " + _
            timeEnd.ToString())
        EventLog.WriteEntry("The VB.NET How-To ran for a total time of " + _
            timeElapsed.ToString())
    End Sub


End Class
