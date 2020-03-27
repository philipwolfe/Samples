Option Strict On

Imports System.ComponentModel
Imports System.Configuration.Install

' The installer must be created in order for the service to be installed
'   as a service in the operating system. You can add an installer to the
'   project by simply right-clicking on the project palette and 
'   selecting "Add Installer".
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
    Friend WithEvents myServiceProcessInstaller As System.ServiceProcess.ServiceProcessInstaller
    Friend WithEvents myWindowsServiceInstaller As System.ServiceProcess.ServiceInstaller
    <System.Diagnostics.DebuggerStepThrough()> Private Sub InitializeComponent()
        Me.myServiceProcessInstaller = New System.ServiceProcess.ServiceProcessInstaller()
        Me.myWindowsServiceInstaller = New System.ServiceProcess.ServiceInstaller()
        '
        'myServiceProcessInstaller
        '
        Me.myServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem
        Me.myServiceProcessInstaller.Password = Nothing
        Me.myServiceProcessInstaller.Username = Nothing
        '
        'myWindowsServiceInstaller
        '
        Me.myWindowsServiceInstaller.ServiceName = "VB_NET_HowTo_TimeTrackerService"
        '
        'ProjectInstaller
        '
        Me.Installers.AddRange(New System.Configuration.Install.Installer() {Me.myServiceProcessInstaller, Me.myWindowsServiceInstaller})

    End Sub

#End Region

End Class
