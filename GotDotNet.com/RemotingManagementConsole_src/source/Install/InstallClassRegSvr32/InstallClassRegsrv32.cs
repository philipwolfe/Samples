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
using System.Diagnostics;
using System.Collections;
using System.ComponentModel;
using System.Configuration.Install;
using System.Runtime.InteropServices;
using System.Reflection;
using System.IO;
#endregion


namespace RKiss.InstallClassLib
{
	//---Set 'RunInstaller' attribute to true.
	[RunInstaller(true)]
	public class InstallClassRegsrv32: Installer
	{
		public InstallClassRegsrv32() :base()
		{
		}

		#region Install
		//---Override the 'Install' method.
		public override void Install(IDictionary savedState)
		{
			base.Install(savedState);

			//---the com component
			string strComDllFile = base.Context.Parameters["name"].ToString();

			//---checkpoint 
			Trace.WriteLine(string.Format("Register {0}", strComDllFile));
			
			//---action
			Process installProcess = new Process();
			ProcessStartInfo installInfo = new ProcessStartInfo("regsvr32.exe");
			installInfo.Arguments = "/s " + strComDllFile;    
			installInfo.WindowStyle = ProcessWindowStyle.Hidden;
			installProcess.StartInfo = installInfo;

			//run
			installProcess.Start();
			installProcess.WaitForExit();			
				
		}
		#endregion

		#region Uninstall
		//---Override the 'Uninstall' method.
		public override void Uninstall(IDictionary savedState)
		{
			base.Uninstall(savedState);

			//---the com component
			string strComDllFile = base.Context.Parameters["name"].ToString();

			//---checkpoint 
			Trace.WriteLine(string.Format("Unregister {0}", strComDllFile));

			//---action
			Process installProcess = new Process();
			ProcessStartInfo installInfo = new ProcessStartInfo("regsvr32.exe");
			installInfo.Arguments = "/u /s " + strComDllFile;       
			installInfo.WindowStyle = ProcessWindowStyle.Hidden;
			installProcess.StartInfo = installInfo;

			//run
			installProcess.Start();
			installProcess.WaitForExit();
						
		}
		#endregion
	}
}

