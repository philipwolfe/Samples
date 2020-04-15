using System.ComponentModel;

using System.Configuration.Install;

[RunInstaller(true)] public class ProjectInstaller:System.Configuration.Install.Installer
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

	internal System.ServiceProcess.ServiceProcessInstaller WatchMSMQServiceProcessInstaller ;

	internal  System.ServiceProcess.ServiceInstaller WatchMSMQInstaller;

	private void InitializeComponent() {
		this.WatchMSMQServiceProcessInstaller = new System.ServiceProcess.ServiceProcessInstaller();
		this.WatchMSMQInstaller = new System.ServiceProcess.ServiceInstaller();
		// 
		// WatchMSMQServiceProcessInstaller
		// 
		this.WatchMSMQServiceProcessInstaller.Account = System.ServiceProcess.ServiceAccount.LocalSystem;
		this.WatchMSMQServiceProcessInstaller.Password = null;
		this.WatchMSMQServiceProcessInstaller.Username = null;
		// 
		// WatchMSMQInstaller
		// 
		this.WatchMSMQInstaller.DisplayName = "C# How-To Watch MSMQ";
		this.WatchMSMQInstaller.ServiceName = "WatchMSMQ";
		this.WatchMSMQInstaller.ServicesDependedOn = new string[] {
																	  "MSMQ"};
		this.WatchMSMQInstaller.AfterInstall += new System.Configuration.Install.InstallEventHandler(this.WatchMSMQInstaller_AfterInstall);
		// 
		// ProjectInstaller
		// 
		this.Installers.AddRange(new System.Configuration.Install.Installer[] {
																				  this.WatchMSMQInstaller,
																				  this.WatchMSMQServiceProcessInstaller});

	}

#endregion

	private void WatchMSMQInstaller_AfterInstall(object sender, System.Configuration.Install.InstallEventArgs e)
	{
	
	}

}

