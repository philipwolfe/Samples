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

namespace WorkflowLibrary1
{
	partial class Workflow1
	{
		#region Designer generated code
		
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
        [System.Diagnostics.DebuggerNonUserCode]
		private void InitializeComponent()
		{
            this.CanModifyActivities = true;
            this.delayActivity2 = new System.Workflow.Activities.DelayActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            // 
            // delayActivity2
            // 
            this.delayActivity2.Name = "delayActivity2";
            this.delayActivity2.TimeoutDuration = System.TimeSpan.Parse("00:00:02");
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:01");
            // 
            // Workflow1
            // 
            this.Activities.Add(this.delayActivity1);
            this.Activities.Add(this.codeActivity1);
            this.Activities.Add(this.delayActivity2);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private CodeActivity codeActivity1;
        private DelayActivity delayActivity2;
        private DelayActivity delayActivity1;


    }
}
