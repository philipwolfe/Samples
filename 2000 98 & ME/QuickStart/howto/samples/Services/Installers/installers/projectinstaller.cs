using System;
using System.Collections;
using System.Configuration.Install;
using System.Diagnostics;
using System.Messaging;
using System.ComponentModel;

[RunInstaller(true)]
public class ProjectInstaller: Installer {

    private MessageQueueInstaller mqInstaller;
    private EventLogInstaller elInstaller;

    public ProjectInstaller() {

        mqInstaller = new MessageQueueInstaller();

        mqInstaller.Authenticate = true;
        mqInstaller.EncryptionRequired = EncryptionRequired.Body;
        mqInstaller.Label = "InstallersSample";
        mqInstaller.Path = ".\\InstallersSample";
        mqInstaller.Transactional = false;
        mqInstaller.UseJournalQueue = true;

        Installers.Add(mqInstaller);

        elInstaller = new EventLogInstaller();

        elInstaller.Log = "InstallersSample";
        elInstaller.Source = "InstallersSample";

        Installers.Add(elInstaller);
    }
}    
