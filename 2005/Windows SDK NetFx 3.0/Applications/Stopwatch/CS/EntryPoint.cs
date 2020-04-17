//-----------------------------------------------------------------------
//  This file is part of the Microsoft .NET SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//-----------------------------------------------------------------------
using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;

[assembly: CLSCompliant(true)]
[assembly: ComVisible(false)]

namespace Microsoft.Samples.StopWatchCS
{
	static class EntryPoint
	{
		[STAThread]
		static void Main()
		{
			Application.Run(new FormMain());
		}
	}
}
