
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Microsoft.ServiceModel.Samples
{
	static class client
	{
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main()
		{
			Application.EnableVisualStyles();
			Application.Run(new Form1());
		}
	}
}