imports System
imports System.Collections
imports System.Configuration.Install
imports System.Diagnostics
imports System.Messaging
imports System.ComponentModel

public class <RunInstaller(true)> ProjectInstaller: Inherits Installer

    private mqInstaller As MessageQueueInstaller
    private elInstaller As EventLogInstaller

    public Sub New()
        MyBase.New()
        
        mqInstaller = new MessageQueueInstaller()

        mqInstaller.Authenticate = true
        mqInstaller.EncryptionRequired = EncryptionRequired.Body
        mqInstaller.Label = "InstallersSample"
        mqInstaller.Path = ".\InstallersSample"
        mqInstaller.Transactional = false
        mqInstaller.UseJournalQueue = true

        Installers.Add(mqInstaller)

        elInstaller = new EventLogInstaller()

        elInstaller.Log = "InstallersSample"
        elInstaller.Source = "InstallersSample"

        Installers.Add(elInstaller)
    end sub 
end class 
