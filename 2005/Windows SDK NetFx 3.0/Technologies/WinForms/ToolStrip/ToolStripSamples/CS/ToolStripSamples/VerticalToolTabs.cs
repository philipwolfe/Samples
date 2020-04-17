//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
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
//---------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Collections;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Data;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Reflection;
using System.CodeDom;
using System.CodeDom.Compiler;
using Microsoft.CSharp;
using System.IO;
using System.Collections.ObjectModel;

namespace Microsoft.Samples.Windows.Forms.ToolStripSamples
{
	partial class VerticalToolTabsForm : Form
	{
		// Fields
		Collection<IToolWindow> _toolWindows;

		public VerticalToolTabsForm()
		{
			InitializeComponent();

			// Initialize fields
			_toolWindows = new Collection<IToolWindow>();

			this.splitter1.BackColor = ProfessionalColors.RaftingContainerGradientEnd;
		}

		private void FindWindows()
		{
			// Clear out the collection
			_toolWindows.Clear();

			// Use reflection to look for types
			foreach (Type t in Assembly.GetExecutingAssembly().GetTypes())
			{
				if (t.GetInterface("IToolWindow") != null)
				{
					// Try the empty constructor
					if (t.GetConstructor(new Type[0]) != null)
					{
						_toolWindows.Add((IToolWindow)Activator.CreateInstance(t));
					}
					else
					{
						_toolWindows.Add((IToolWindow)Activator.CreateInstance(t, new object[] { this.richTextBox1 }));
					}
				}
			}

			// Add toolwindows to each ToolWindowHost
			foreach (Control c in this.Controls)
			{
				ToolWindowHost host = c as ToolWindowHost;
				if (host != null)
				{
					foreach (IToolWindow tw in _toolWindows)
					{
						host.AddToolWindow(tw);
						host.ShowToolWindow(tw);
					}
				}
			}
		}

		private void MainForm_Load(object sender, EventArgs e)
		{
			FindWindows();
		}
	}
}