//=============================================================================
//	The Remoting Management Console.
//	(C) Copyright 2003, Roman Kiss (rkiss@pathcom.com)
//	All rights reserved.
//	The code and information is provided "as-is" without waranty of any kind,
//	either expresed or implied.
//
//-----------------------------------------------------------------------------
//	History:
//		03/31/2003	Roman Kiss				Initial Revision
//=============================================================================
//

#region references
using System;
using System.Text;
#endregion

namespace RKiss.RemotingManagement
{
	
	public class ServiceSrcCode
	{
		#region windows service template text
		const string strSrcTmplService = "namespace RemotingHostService" + 
			"{ " +
				"using System;" + 
				"using System.Collections;" +
				"using System.ComponentModel;" +
				"using System.Data;" +
				"using System.Diagnostics;" +
				"using System.ServiceProcess;" +
				"using System.Runtime.Remoting;" +
				"using System.Runtime.Remoting.Channels;" +
				"using System.Threading;" +
				"public class Service : ServiceBase" + 
			  "{" +
					"private Container components = null;" +
					"public Service()" +
					"{"+
						"components = new Container();" +
						"this.ServiceName = \"SERVICE_NAME\";" +
					"}" +
					"static void Main()" +
					"{" + 
						"ServiceBase[] ServicesToRun;" +
						"ServicesToRun = new ServiceBase[] { new Service() };" +
						"Run(ServicesToRun);" +
					"}" +
					"protected override void Dispose(bool disposing)" +
					"{" +
						"if(disposing) { if(components != null) components.Dispose(); }" +
						"base.Dispose(disposing);"+
					"}" +
					"protected override void OnStart(string[] args)" +
					"{" +
						"if(args.Length == 1) Thread.Sleep(Convert.ToInt32(args[0]));" +	
						"RemotingConfiguration.Configure(AppDomain.CurrentDomain.SetupInformation.ConfigurationFile);" +
					"}" +
					"protected override void OnStop()" +
					"{" +
						"foreach(IChannel objChannel in ChannelServices.RegisteredChannels)" + 	
							"ChannelServices.UnregisterChannel(objChannel);" +
					"}" +
				"}\r\n" +
				"[RunInstaller(true)]" +
				"public class ProjectInstaller : System.Configuration.Install.Installer" +
				"{" +
					"private ServiceProcessInstaller serviceProcessInstaller1;" +
					"private ServiceInstaller serviceInstaller1;" +
					"public ProjectInstaller() {InitializeComponent();}" +
					"private void InitializeComponent()" +
					"{" +
						"this.serviceProcessInstaller1 = new ServiceProcessInstaller();" +
						"this.serviceInstaller1 = new ServiceInstaller();"+
						"this.serviceProcessInstaller1.Account = ServiceAccount.LocalSystem;" +
						"this.serviceInstaller1.ServiceName = \"SERVICE_NAME\"; " +
						"this.serviceInstaller1.StartType = SERVICE_START;" +
						"this.Installers.AddRange(new System.Configuration.Install.Installer[]{this.serviceProcessInstaller1,	this.serviceInstaller1});" +
					"}" + 
					"public override void Install(IDictionary stateServer)" +
					"{" +
						"Microsoft.Win32.RegistryKey  system, currentControlSet, services, service;" +
						"base.Install(stateServer);" +
						"system = Microsoft.Win32.Registry.LocalMachine.OpenSubKey(\"System\");" +
						"currentControlSet = system.OpenSubKey(\"CurrentControlSet\");" +
						"services = currentControlSet.OpenSubKey(\"Services\");" +
						"service = services.OpenSubKey(this.serviceInstaller1.ServiceName, true);" +
						"service.SetValue(\"Description\", \"SERVICE_DESCRIPTION\");" +
						"SERVICE_TRAYICON" +
					"}" +
				"}" +
			"}";
		#endregion

		#region constructor
		public ServiceSrcCode()
		{
		}
		#endregion

		#region get source code
		public string GetSrcCodeForService(string strServiceName, string strServiceDesc, bool bStartAutomatic, bool bTrayIcon) 
		{
			string strServiceStart = bStartAutomatic ? "ServiceStartMode.Automatic" : "ServiceStartMode.Manual";
			string strServiceTrayIcon = bTrayIcon ? "service.SetValue(\"Type\", 272);" : "";
			
			//modify template
			StringBuilder sb = new StringBuilder(strSrcTmplService);
			sb.Replace("SERVICE_NAME", strServiceName);
			sb.Replace("SERVICE_DESCRIPTION", strServiceDesc);
			sb.Replace("SERVICE_START", strServiceStart);
			sb.Replace("SERVICE_TRAYICON", strServiceTrayIcon);

			string strSource = sb.ToString();
			int intLen = strSource.Length;

			return strSource;
		}
		#endregion
	}
}
