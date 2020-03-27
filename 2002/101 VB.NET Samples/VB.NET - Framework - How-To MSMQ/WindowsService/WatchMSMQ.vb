Imports System.ServiceProcess
Imports System.Messaging
Imports System.Threading

Public Class WatchMSMQ
	Inherits System.ServiceProcess.ServiceBase

	' Needed to re-hook the queue
	' in case we're paused.
	Private m_Path As String

#Region " Component Designer generated code "

	Public Sub New()
		MyBase.New()

		' This call is required by the Component Designer.
		InitializeComponent()

		' Add any initialization after the InitializeComponent() call
		Me.m_Path = Me.qOrders.Path
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
		ServicesToRun = New System.ServiceProcess.ServiceBase() {New WatchMSMQ()}

		System.ServiceProcess.ServiceBase.Run(ServicesToRun)
	End Sub

	'Required by the Component Designer
	Private components As System.ComponentModel.IContainer

	' NOTE: The following procedure is required by the Component Designer
	' It can be modified using the Component Designer.  
	' Do not modify it using the code editor.
	Friend WithEvents qOrders As System.Messaging.MessageQueue

	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Dim configurationAppSettings As System.Configuration.AppSettingsReader = New System.Configuration.AppSettingsReader()
		Me.qOrders = New System.Messaging.MessageQueue()
		'
		'qOrders
		'
		Me.qOrders.Formatter = New System.Messaging.XmlMessageFormatter(New String() {"Server.MSMQOrders,Server"})
		Me.qOrders.Path = CType(configurationAppSettings.GetValue("msmqOrders.Path", GetType(System.String)), String)
		'
		'WatchMSMQ
		'
		Me.CanHandlePowerEvent = True
		Me.CanPauseAndContinue = True
		Me.CanShutdown = True
		Me.ServiceName = "WatchMSMQ"

	End Sub

#End Region

	Protected Overrides Sub OnStart(ByVal args() As String)
		' Add code here to start your service. This method should set things
		' in motion so your service can do its work.
		Try
			Me.HookQueue()
		Catch exp As MessageQueueException
			Me.EventLog.WriteEntry(exp.Message)
		Catch exp As Exception
			Me.EventLog.WriteEntry(exp.Message)
		End Try
	End Sub

	Protected Overrides Sub OnStop()
		' Add code here to perform any tear-down necessary to stop your service.
		UnhookQueue()
	End Sub

	Protected Overrides Sub OnContinue()
		HookQueue()
	End Sub

	Protected Overrides Sub OnPause()
		UnhookQueue()
	End Sub

	Protected Overrides Function OnPowerEvent(ByVal powerStatus As System.ServiceProcess.PowerBroadcastStatus) As Boolean

	End Function

	Protected Overrides Sub OnShutdown()
		UnhookQueue()
	End Sub

	Private Sub HookQueue()
		Try
			' This is necessary since we unhook
			' when we are stopped.
			If Me.qOrders Is Nothing Then
				Me.qOrders = New System.Messaging.MessageQueue(Me.m_Path)
			End If

			' Start waiting for messages to arrive.
			Me.qOrders.BeginReceive()

		Catch exp As MessageQueueException
			Me.EventLog.WriteEntry(exp.Message)
		Catch exp As Exception
			Me.EventLog.WriteEntry(exp.Message)
		End Try
	End Sub

	Private Sub UnhookQueue()
		Try
			With Me.qOrders
				.Close()
				.Dispose()
			End With

			Me.qOrders = Nothing

		Catch exp As MessageQueueException
			Me.EventLog.WriteEntry(exp.Message)
		Catch exp As Exception
			Me.EventLog.WriteEntry(exp.Message)
		End Try
	End Sub

	Private Sub qOrders_ReceiveCompleted(ByVal sender As System.Object, ByVal e As System.Messaging.ReceiveCompletedEventArgs) Handles qOrders.ReceiveCompleted
		' This event fires when a message is received.
		Try
			' Get the message
			Dim m As Message
			m = qOrders.EndReceive(e.AsyncResult)

			' Cast the message body to an object instance
			Dim o As Server.MSMQOrders
			o = CType(m.Body, Server.MSMQOrders)

			' If we did the following line of code:

			' o.Process()

			' our listening thread would be blocked until 
			' it finished. Instead will use the built-in
			' CLR Thread Pool.
			' Note that our MSMQOrders.Process method has to match
			' expected signature defined by the QueueUserWorkItem method.
			' See the documenation for more information.

			ThreadPool.QueueUserWorkItem(AddressOf o.Process)

			' Now continue listening for messages
			Me.qOrders.BeginReceive()

		Catch exp As MessageQueueException
			Me.EventLog.WriteEntry(exp.Message)
		Catch exp As Exception
			Me.EventLog.WriteEntry(exp.Message)
		End Try
	End Sub
End Class
