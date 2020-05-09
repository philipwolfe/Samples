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
using System.Configuration.Install;
using System.Collections;
using System.Collections.Specialized;
using System.ServiceProcess;
using System.Diagnostics;
using System.IO;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.Reflection;
using System.Threading;
using System.Text;
#endregion

namespace RKiss.RemotingManagement
{
	
	public class WinServiceAgent : MarshalByRefObject
	{
		#region constructor
		public WinServiceAgent()
		{		
		}
		#endregion

		#region control functions
		public void Start(string strServiceName) 
		{
			foreach(ServiceController sc in ServiceController.GetServices()) 
			{
				if(sc.ServiceName == strServiceName) 
				{
					sc.Start();
					break;
				}
			}
		}

		public void Start(string strServiceName, string[] args) 
		{
			foreach(ServiceController sc in ServiceController.GetServices()) 
			{
				if(sc.ServiceName == strServiceName) 
				{
					sc.Start(args);
					break;
				}
			}
		}

		public void Stop(string strServiceName)
		{
			foreach(ServiceController sc in ServiceController.GetServices()) 
			{
				if(sc.ServiceName == strServiceName) 
				{
					//if(sc.CanStop)
						sc.Stop();
					break;
				}
			}
		}

		public ServiceControllerStatus Status(string strServiceName) 
		{
			foreach(ServiceController sc in ServiceController.GetServices()) 
			{
				if(sc.ServiceName == strServiceName) 
				{
					return sc.Status;
				}
			}
			
			throw new Exception(string.Format("The service {0} is not installed.", strServiceName));
		}

		public bool Exists(string strServiceName) 
		{
			foreach(ServiceController sc in ServiceController.GetServices()) 
			{
				if(sc.ServiceName == strServiceName) 
				{
					return true;
				}
			}	
			return false;
		}
		#endregion

		#region get functions
		public string GetPathToExecutable(string strServiceName) 
		{
			string strExecPath = "";

			//---properties
			Microsoft.Win32.RegistryKey  system, currentControlSet, services, service; 

			foreach(ServiceController sc in ServiceController.GetServices()) 
			{
				if(sc.ServiceName == strServiceName) 
				{
					//---Open the HKEY_LOCAL_MACHINE\Services\CurrentControlSet\Services\<ServiceName>
					system = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("System");
					currentControlSet = system.OpenSubKey("CurrentControlSet");
					services = currentControlSet.OpenSubKey("Services");
					service = services.OpenSubKey(strServiceName);
					strExecPath = Convert.ToString(service.GetValue("ImagePath"));

					break;
				}
			}

			return strExecPath;
		}

		public string GetServiceName(string strAssemblyPath) 
		{
			string strServiceName = null;
			string strAssemblyPathName  = strAssemblyPath.ToLower();
	
			//---properties
			Microsoft.Win32.RegistryKey  system, currentControlSet, services, service; 

			//---Open the HKEY_LOCAL_MACHINE\Services\CurrentControlSet\Services\
			system = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("System");
			currentControlSet = system.OpenSubKey("CurrentControlSet");
			services = currentControlSet.OpenSubKey("Services");

			//---find the service for this executable file
			foreach(ServiceController sc in ServiceController.GetServices()) 
			{				
				service = services.OpenSubKey(sc.ServiceName);
				string strExecPath = Convert.ToString(service.GetValue("ImagePath")).ToLower();
			
				if(strAssemblyPathName == strExecPath) 
				{
					strServiceName = sc.ServiceName;
					break;
				}
			}

			return strServiceName;
		}

		public string GetProcessesInnerXml() 
		{
			string strProcessesInnerXml = null;

			//---properties
			Microsoft.Win32.RegistryKey  system, currentControlSet, services, service; 

			//---Open the HKEY_LOCAL_MACHINE\Services\CurrentControlSet\Services\<ServiceName>
			system = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("System");
			currentControlSet = system.OpenSubKey("CurrentControlSet");
			services = currentControlSet.OpenSubKey("Services");

			StringBuilder sb = new StringBuilder();

			foreach(ServiceController sc in ServiceController.GetServices()) 
			{
				string strServiceName = sc.DisplayName;
				string strStatus = sc.Status.ToString();
				service = services.OpenSubKey(strServiceName);

				if(service != null) 
				{
					string strExecPath = Convert.ToString(service.GetValue("ImagePath"));
					string strHostProcessConfigFile = strExecPath + ".config";

					if(File.Exists(strHostProcessConfigFile) == true) 
					{
						string strStartMode = Enum.GetName(typeof(ServiceStartMode), service.GetValue("Start"));
						string strDesc = Convert.ToString(service.GetValue("Description"));

						sb.AppendFormat("<process name=\"{0}\" status=\"{1}\" start=\"{2}\" description=\"{3}\" imagepath=\"{4}\" />", 
							strServiceName, strStatus, strStartMode, strDesc, strExecPath);
					}		
				}
			}

			if(sb.Length > 0)
				strProcessesInnerXml = sb.ToString();

			return strProcessesInnerXml;
		}	

		public string GetProcessInnerXml(string strServiceName) 
		{
			//---properties
			Microsoft.Win32.RegistryKey  system, currentControlSet, services, service; 
			string strProcessInnerXml = null;
			StringBuilder sb = new StringBuilder();

			foreach(ServiceController sc in ServiceController.GetServices()) 
			{
				if(sc.ServiceName == strServiceName) 
				{
					//---Open the HKEY_LOCAL_MACHINE\Services\CurrentControlSet\Services\<ServiceName>
					system = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("System");
					currentControlSet = system.OpenSubKey("CurrentControlSet");
					services = currentControlSet.OpenSubKey("Services");
					service = services.OpenSubKey(strServiceName);
					string strExecPath = Convert.ToString(service.GetValue("ImagePath"));
					string strStartMode = Enum.GetName(typeof(ServiceStartMode), service.GetValue("Start"));
					string strDesc = Convert.ToString(service.GetValue("Description"));

					sb.AppendFormat("<process name=\"{0}\" start=\"{1}\" description=\"{2}\" imagepath=\"{3}\" />", 
						strServiceName, strStartMode, strDesc, strExecPath);

					break;
				}
			}
			
			if(sb.Length > 0)
				strProcessInnerXml = sb.ToString();

			return strProcessInnerXml;
		}	
		#endregion

		#region set functions
		public void SetServiceProperties(string strServiceName, ServiceStartMode eStartMode, string strDescription) 
		{
			//---properties
			Microsoft.Win32.RegistryKey  system, currentControlSet, services, service; 

			foreach(ServiceController sc in ServiceController.GetServices()) 
			{
				if(sc.ServiceName == strServiceName) 
				{
					//---Open the HKEY_LOCAL_MACHINE\Services\CurrentControlSet\Services\<ServiceName>
					system = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("System");
					currentControlSet = system.OpenSubKey("CurrentControlSet");
					services = currentControlSet.OpenSubKey("Services");
					service = services.OpenSubKey(strServiceName, true);
					//
					service.SetValue("Start", Convert.ToInt32(eStartMode));
					service.SetValue("Description", strDescription);			
					break;
				}
			}
		}
		#endregion

		#region create functions
		public string Create(string strServiceName, string strServiceDesc, bool bStartAutomatic, bool bTrayIcon, string strAssemblyName) 
		{
			string strAssemblyFile = null;

			//--- create service ---
			ServiceSrcCode ssc = new ServiceSrcCode();
			string strServiceSrcCode = ssc.GetSrcCodeForService(strServiceName, strServiceDesc, bStartAutomatic, bTrayIcon);
			string strOutputAssembly = string.Format(@"{0}.exe", strAssemblyName);

			// assembly compilation.
			string[] strArrayReferences = {
					"System.dll", 
					"System.Data.dll", 
					"System.Runtime.Remoting.dll",
					"System.ServiceProcess.dll", 
					"System.Configuration.Install.dll"}; 
			CompilerParameters cp = new CompilerParameters();
			cp.ReferencedAssemblies.AddRange(strArrayReferences);
			cp.GenerateExecutable = true;
			cp.GenerateInMemory = false; 
			cp.OutputAssembly = strOutputAssembly; 
			cp.WarningLevel = 4;
			cp.IncludeDebugInformation = false; 
			ICodeCompiler icc = new CSharpCodeProvider().CreateCompiler();
			CompilerResults cr = icc.CompileAssemblyFromSource(cp, strServiceSrcCode);

			if(cr.Errors.Count > 0)
			{
				foreach(string s in cr.Output) 
				{
					Trace.WriteLine(s);
				}
				throw new Exception(string.Format("Build failed: {0} errors", cr.Errors.Count)); 

			}
			//cr.TempFiles.KeepFiles = true;
			strAssemblyFile = cp.OutputAssembly;
			
			return strAssemblyFile;
		}

		public void CreateHostProcessConfigFile(string strPathToExecutable) 
		{		
			//---config file template
			string strPathToConfigFile = AppDomain.CurrentDomain.SetupInformation.ApplicationBase + "HostProcessTemplate.exe.config";
		
			//---create config file	
			FileInfo configFI = new FileInfo(strPathToConfigFile);
			configFI.CopyTo(strPathToExecutable + ".config", false);		
			
		}
		#endregion

		#region installation functions
		public void Install(string strPathToExecutable) 
		{
			IDictionary mySavedState = new Hashtable();
			AssemblyInstaller myAssemblyInstaller = null;

			try 
			{
				//---use commmit/rolback 
				FileInfo fi = new FileInfo(strPathToExecutable);
				myAssemblyInstaller = new AssemblyInstaller(strPathToExecutable, null);
				myAssemblyInstaller.UseNewContext = true;
				myAssemblyInstaller.Install(mySavedState);
				myAssemblyInstaller.Commit( mySavedState );
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("WinServiceAgent.Install error = {0}", ex.Message));
				if(myAssemblyInstaller != null)
					myAssemblyInstaller.Rollback(mySavedState);

				throw ex;
			}
		}

		public void Uninstall(string strPathToExecutable) 
		{
			//---no commmit/rolback 
			IDictionary mySavedState = new Hashtable();
			AssemblyInstaller myAssemblyInstaller = null;

			try 
			{		
				FileInfo fi = new FileInfo(strPathToExecutable);

				myAssemblyInstaller = new AssemblyInstaller(strPathToExecutable, null);
				myAssemblyInstaller.UseNewContext = true;
				myAssemblyInstaller.Uninstall(null);
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("WinServiceAgent.Uninstall error = {0}", ex.Message));
				throw ex;
			}
		}

		public void Install(string strPathToExecutable, bool bCreateConfigFile) 
		{
			Install(strPathToExecutable);

			if(bCreateConfigFile == true) 
				CreateHostProcessConfigFile(strPathToExecutable);
		}
		#endregion
		
	}
}

