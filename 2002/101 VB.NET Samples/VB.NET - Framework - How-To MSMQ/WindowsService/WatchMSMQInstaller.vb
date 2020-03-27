Imports System.ComponentModel
Imports System.Configuration.Install

<RunInstaller(True)> Public Class ProjectInstaller
    Inherits System.Configuration.Install.Installer

#Region " Component Designer generated code "

    Public Sub New()
        MyBase.New()

        'This call is required by the Component Designer.
        InitializeComponent()

        'Add any initialization after the InitializeComponent() call

    End Sub

    'Installer overrides dispose to clean up the component list.
    Protected Overloads Overrides Sub Dispose(ByVal disposing As Boolean)
        If disposing Then
            If Not (components Is Nothing) Then
                components.Dispose()
            End If
        End If
        MyBase.Dispose(disposing)
    End Sub

    'Required by the Component Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Component Designer
    'It can be modified using the Component Designer.  
    'Do not modify it using the code editor.
	Friend WithEvents WatchMSMQServiceProcessInstaller As System.ServiceProcess.ServiceProcessInstaller
	Friend WithEvents WatchMSMQInstaller As System.ServiceProcess.ServiceInstaller
	<System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
		Me.WatchMSMQServiceProcessInstaller = New System.ServiceProcess.ServiceProcessInstaller()
		Me.WatchMSMQInstaller = New System.ServiceProcess.ServiceInstaller()
		'
		'WatchMSMQServiceProcessInstaller
		'
		Me.WatchMSMQServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem
		Me.WatchMSMQServiceProcessInstaller.Password = Nothing
		Me.WatchMSMQServiceProcessInstaller.Username = Nothing
		'
		'WatchMSMQInstaller
		'
		Me.WatchMSMQInstaller.DisplayName = "VB.NET How-To Watch MSMQ"
		Me.WatchMSMQInstaller.ServiceName = "WatchMSMQ"
		Me.WatchMSMQInstaller.ServicesDependedOn = New String() {"MSMQ"}
		'
		'ProjectInstaller
		'
		Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.WatchMSMQInstaller, Me.WatchMSMQServiceProcessInstaller})

	End Sub

#End Region

End Class
