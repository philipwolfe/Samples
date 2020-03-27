using System;
using System.ComponentModel;
using System.Configuration.Install;

[RunInstaller(true)] public class ProjectInstaller : System.Configuration.Install.Installer
{
#region " Component Designer generated code ";

    public ProjectInstaller() 
	{
        //This call is required by the Component Designer.
        InitializeComponent();
        //Add any initialization after the InitializeComponent() call
    }

    //Installer overrides dispose to clean up the component list.
    protected override void Dispose(bool disposing) {
        if (disposing) {
            if (components != null) {
                components.Dispose();
            }
        }
        base.Dispose(disposing);
    }
    //Required by the Component Designer
    private System.ComponentModel.IContainer components = null;
    //NOTE: The following procedure is required by the Component Designer
    //It can be modified using the Component Designer.  
    //Do not modify it using the code editor.
    internal System.ServiceProcess.ServiceProcessInstaller myServiceProcessInstaller;
    internal System.ServiceProcess.ServiceInstaller myWindowsServiceInstaller;

    private void InitializeComponent() {

        this.myServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();

        this.myWindowsServiceInstaller = new System.ServiceProcess.ServiceInstaller();

        //

        //myServiceProcessInstaller

        //

        this.myServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;

        this.myServiceProcessInstaller.Password = null;

        this.myServiceProcessInstaller.Username = null;

        //

        //myWindowsServiceInstaller

        //

        this.myWindowsServiceInstaller.ServiceName = "C#_NET_HowTo_TimeTrackerService";

        //

        //ProjectInstaller

        //

        this.Installers.AddRange(new System.Configuration.Install.Installer[] {this.myServiceProcessInstaller, this.myWindowsServiceInstaller});

    }

#endregion

}

