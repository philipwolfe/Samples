//=============================================================================
//	The Remoting Management Console.
//	(C) Copyright 2003, Roman Kiss (rkiss@pathcom.com)
//	All rights reserved.
//	The code and information is provided "as-is" without waranty of any kind,
//	either expresed or implied.
//
//  Note:	
//	This software using the 3rd party library for MMC (www.ironringsoftware.com)
//-----------------------------------------------------------------------------
//	History:
//		03/31/2003	Roman Kiss				Initial Revision
//=============================================================================
//

using System;
using Ironring.Management.MMC;
using System.Runtime.InteropServices;

namespace RKiss.RemotingManagement
{
	/// <summary>
	/// TestAbout is an About class derivative that provides MMC with info about our snapin.
	/// It requires the AboutSnapin attribute to associate it with a snapin base class.
	/// Provide enbedded image names to override the defaults.
	/// </summary>
	[Guid("25A43E53-5F27-4462-AE4F-960BA24213A5"),	AboutSnapin(typeof(RemotingManagement))]
	public class RemotingManagementAbout : About
	{
		public RemotingManagementAbout()
		{
			Description = "This snapin controls the remoting host processes (windows services)";
		}
	}
}
