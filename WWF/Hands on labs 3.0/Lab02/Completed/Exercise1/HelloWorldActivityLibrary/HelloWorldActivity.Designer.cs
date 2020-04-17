//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace HelloWorldActivityLibrary
{
	public partial class HelloWorldActivity
	{
		#region Activity Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
			this.CanModifyActivities = true;
			this.writeWorld = new System.Workflow.Activities.CodeActivity();
			this.writeHello = new System.Workflow.Activities.CodeActivity();
			// 
			// writeWorld
			// 
			this.writeWorld.Name = "writeWorld";
			this.writeWorld.ExecuteCode += new System.EventHandler(this.writeWorld_ExecuteCode);
			// 
			// writeHello
			// 
			this.writeHello.Name = "writeHello";
			this.writeHello.ExecuteCode += new System.EventHandler(this.writeHello_ExecuteCode);
			// 
			// HelloWorldActivity
			// 
			this.Activities.Add(this.writeHello);
			this.Activities.Add(this.writeWorld);
			this.Name = "HelloWorldActivity";
			this.CanModifyActivities = false;

		}

		#endregion

		private CodeActivity writeWorld;
		private CodeActivity writeHello;

	}
}
