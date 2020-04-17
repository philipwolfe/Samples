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
using System.Collections.Generic;
using System.Text;
using System.Windows.Forms;

namespace Microsoft.Samples.Windows.Forms.ToolStripSamples
{
	public delegate void ToolWindowEventHandler(object sender, ConvertEventArgs e);

	class ToolWindowEventArgs : EventArgs
	{
		// Property fields
		private IToolWindow _toolWindow;

		public ToolWindowEventArgs(IToolWindow toolWindow)
		{
			_toolWindow = toolWindow;
		}

		// Properties
		public IToolWindow ToolWindow
		{
			get
			{
				return _toolWindow;
			}
		}
	}
}
