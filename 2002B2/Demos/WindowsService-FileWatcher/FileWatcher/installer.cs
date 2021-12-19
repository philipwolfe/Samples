using System;
using System.Collections;
using System.Configuration.Install;
using System.ServiceProcess;
using System.ServiceProcess.Design;
using System.ComponentModel;


	/// <summary>
	/// Summary description for Component1.
	/// </summary>
	[RunInstaller(true)]
	public class ProjectInstaller : Installer
	{
		System.ServiceProcess.ServiceInstaller serviceInstaller;
		System.ServiceProcess.ServiceProcessInstaller processInstaller;
		
		public ProjectInstaller() 
		{
			serviceInstaller = new System.ServiceProcess.ServiceInstaller();
			processInstaller = new System.ServiceProcess.ServiceProcessInstaller();
			//Service will run under System Account
			serviceInstaller.ServiceName = "WinService";
			//Service will have Start Type of Manual
			serviceInstaller.StartType = ServiceStartMode.Manual;

			Installers.Add(serviceInstaller);
			Installers.Add(processInstaller);

		}
		#region Component Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
		}
		#endregion
	}
