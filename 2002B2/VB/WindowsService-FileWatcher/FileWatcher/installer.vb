Imports System
Imports System.Collections
Imports System.Configuration.Install
Imports System.ServiceProcess
Imports System.ServiceProcess.Design
Imports System.ComponentModel

<RunInstaller(True)> Public Class ProjectInstaller : Inherits Installer

    Private serviceInstaller As System.ServiceProcess.ServiceInstaller
    Private processInstaller As System.ServiceProcess.ServiceProcessInstaller

    Public Sub New()
        MyBase.New()


        processInstaller = New System.ServiceProcess.ServiceProcessInstaller()
        serviceInstaller = New System.ServiceProcess.ServiceInstaller()


        ' Service will have Start Type of Manual
        serviceInstaller.StartType = ServiceStartMode.Manual

        serviceInstaller.ServiceName = "WinService"

        Installers.Add(serviceInstaller)
        Installers.Add(processInstaller)
    End Sub
End Class
