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
	public class InstallClassRegAsm: Installer
	{
		public InstallClassRegAsm() :base()
		{
		}

		#region Install
		//---Override the 'Install' method.
		public override void Install(IDictionary savedState)
		{
			base.Install(savedState);

			//---the assembly to register
			string strAssemblyFile = base.Context.Parameters["name"].ToString();

			//---checkpoint 
			Trace.WriteLine(string.Format("Install {0}", strAssemblyFile));

			//---load assembly 
			Assembly objAsm = Assembly.LoadFrom(strAssemblyFile);
			
			//---action
			RegistrationServices  objRS = new RegistrationServices();
			objRS.RegisterAssembly(objAsm, AssemblyRegistrationFlags.SetCodeBase);		
		}
		#endregion

		#region Uninstall
		//---Override the 'Uninstall' method.
		public override void Uninstall(IDictionary savedState)
		{
			base.Uninstall(savedState);

			//---the assembly to register
			string strAssemblyFile = base.Context.Parameters["name"].ToString();

			//---checkpoint 
			Trace.WriteLine(string.Format("Uninstall {0}", strAssemblyFile));

			//---load assembly 
			Assembly objAsm = Assembly.LoadFrom(strAssemblyFile);
	
			//---action
			RegistrationServices  objRS = new RegistrationServices();
			objRS.UnregisterAssembly(objAsm);	
		}
		#endregion
	}
}
