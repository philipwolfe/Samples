//---------------------------------------------------------------------
//  This file is part of the NetFx3.com web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------
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

namespace ActivityLibrary1
{
	public partial class Activity1
	{
		#region Activity Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.CanModifyActivities = true;
			this.callCode = new System.Workflow.Activities.CodeActivity();
			// 
			// callCode
			// 
			this.callCode.Name = "callCode";
			this.callCode.ExecuteCode += new System.EventHandler(this.callCode_ExecuteCode);
			// 
			// Activity1
			// 
			this.Activities.Add(this.callCode);
			this.Name = "Activity1";
			this.CanModifyActivities = false;

		}

		#endregion

		private CodeActivity callCode;





	}
}
