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

namespace WorkflowTestHost
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
            System.Workflow.ComponentModel.ActivityBind activitybind1 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.ComponentModel.ActivityBind activitybind2 = new System.Workflow.ComponentModel.ActivityBind();
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.writeLine1 = new CustomActivities.WriteLine();
            this.writeLine2 = new CustomActivities.WriteLine();
            this.writeLine5 = new CustomActivities.WriteLine();
            this.delayActivity2 = new System.Workflow.Activities.DelayActivity();
            this.writeLine4 = new CustomActivities.WriteLine();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.writeLine3 = new CustomActivities.WriteLine();
            this.faultHandlerActivity3 = new System.Workflow.ComponentModel.FaultHandlerActivity();
            this.faultHandlerActivity2 = new System.Workflow.ComponentModel.FaultHandlerActivity();
            this.sequenceActivity3 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity2 = new System.Workflow.Activities.SequenceActivity();
            this.sequenceActivity1 = new System.Workflow.Activities.SequenceActivity();
            this.faultHandlersActivity2 = new System.Workflow.ComponentModel.FaultHandlersActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.writeLine7 = new CustomActivities.WriteLine();
            this.writeLine6 = new CustomActivities.WriteLine();
            this.partialCompletionActivity1 = new CustomActivities.PartialCompletionActivity();
            this.retryActivity1 = new CustomActivities.RetryActivity();
            this.Activity1 = new CustomActivities.ConditionalChildrenActivity();
            // 
            // writeLine1
            // 
            this.writeLine1.Name = "writeLine1";
            activitybind1.Name = "faultHandlerActivity3";
            activitybind1.Path = "Fault.Message";
            this.writeLine1.SetBinding(CustomActivities.WriteLine.OutputTextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind1)));
            // 
            // writeLine2
            // 
            this.writeLine2.Name = "writeLine2";
            activitybind2.Name = "faultHandlerActivity2";
            activitybind2.Path = "Fault.Message";
            this.writeLine2.SetBinding(CustomActivities.WriteLine.OutputTextProperty, ((System.Workflow.ComponentModel.ActivityBind)(activitybind2)));
            // 
            // writeLine5
            // 
            this.writeLine5.Name = "writeLine5";
            this.writeLine5.OutputText = "Three";
            // 
            // delayActivity2
            // 
            this.delayActivity2.Name = "delayActivity2";
            this.delayActivity2.TimeoutDuration = System.TimeSpan.Parse("00:00:05");
            // 
            // writeLine4
            // 
            this.writeLine4.Name = "writeLine4";
            this.writeLine4.OutputText = "Two";
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:02");
            // 
            // writeLine3
            // 
            this.writeLine3.Name = "writeLine3";
            this.writeLine3.OutputText = "One";
            // 
            // faultHandlerActivity3
            // 
            this.faultHandlerActivity3.Activities.Add(this.writeLine1);
            this.faultHandlerActivity3.FaultType = typeof(System.Exception);
            this.faultHandlerActivity3.Name = "faultHandlerActivity3";
            // 
            // faultHandlerActivity2
            // 
            this.faultHandlerActivity2.Activities.Add(this.writeLine2);
            this.faultHandlerActivity2.FaultType = typeof(System.ApplicationException);
            this.faultHandlerActivity2.Name = "faultHandlerActivity2";
            // 
            // sequenceActivity3
            // 
            this.sequenceActivity3.Activities.Add(this.delayActivity2);
            this.sequenceActivity3.Activities.Add(this.writeLine5);
            this.sequenceActivity3.Name = "sequenceActivity3";
            // 
            // sequenceActivity2
            // 
            this.sequenceActivity2.Activities.Add(this.delayActivity1);
            this.sequenceActivity2.Activities.Add(this.writeLine4);
            this.sequenceActivity2.Name = "sequenceActivity2";
            // 
            // sequenceActivity1
            // 
            this.sequenceActivity1.Activities.Add(this.writeLine3);
            this.sequenceActivity1.Name = "sequenceActivity1";
            // 
            // faultHandlersActivity2
            // 
            this.faultHandlersActivity2.Activities.Add(this.faultHandlerActivity2);
            this.faultHandlersActivity2.Activities.Add(this.faultHandlerActivity3);
            this.faultHandlersActivity2.Name = "faultHandlersActivity2";
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            ruleconditionreference1.ConditionName = "Condition1";
            // 
            // writeLine7
            // 
            this.writeLine7.Name = "writeLine7";
            this.writeLine7.OutputText = "World";
            this.writeLine7.SetValue(CustomActivities.ConditionalChildrenActivity.WhenConditionProperty, ruleconditionreference1);
            // 
            // writeLine6
            // 
            this.writeLine6.Name = "writeLine6";
            this.writeLine6.OutputText = "Hello";
            // 
            // partialCompletionActivity1
            // 
            this.partialCompletionActivity1.Activities.Add(this.sequenceActivity1);
            this.partialCompletionActivity1.Activities.Add(this.sequenceActivity2);
            this.partialCompletionActivity1.Activities.Add(this.sequenceActivity3);
            this.partialCompletionActivity1.Enabled = false;
            this.partialCompletionActivity1.Name = "partialCompletionActivity1";
            this.partialCompletionActivity1.RequiredCompletions = 2;
            // 
            // retryActivity1
            // 
            this.retryActivity1.Activities.Add(this.codeActivity1);
            this.retryActivity1.Activities.Add(this.faultHandlersActivity2);
            this.retryActivity1.CurrentRetryAttempt = 0;
            this.retryActivity1.Name = "retryActivity1";
            this.retryActivity1.RetryCount = 1;
            this.retryActivity1.RetryInterval = System.TimeSpan.Parse("00:00:10");
            // 
            // Activity1
            // 
            this.Activity1.Activities.Add(this.writeLine6);
            this.Activity1.Activities.Add(this.writeLine7);
            this.Activity1.Enabled = false;
            this.Activity1.Name = "Activity1";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.Activity1);
            this.Activities.Add(this.retryActivity1);
            this.Activities.Add(this.partialCompletionActivity1);
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

		}

		#endregion

        private CustomActivities.WriteLine writeLine1;
        private CustomActivities.WriteLine writeLine2;
        private FaultHandlerActivity faultHandlerActivity3;
        private FaultHandlerActivity faultHandlerActivity2;
        private SequenceActivity sequenceActivity3;
        private SequenceActivity sequenceActivity2;
        private SequenceActivity sequenceActivity1;
        private FaultHandlersActivity faultHandlersActivity2;
        private CodeActivity codeActivity1;
        private CustomActivities.PartialCompletionActivity partialCompletionActivity1;
        private CustomActivities.WriteLine writeLine5;
        private DelayActivity delayActivity2;
        private CustomActivities.WriteLine writeLine4;
        private DelayActivity delayActivity1;
        private CustomActivities.WriteLine writeLine3;
        private CustomActivities.WriteLine writeLine7;
        private CustomActivities.WriteLine writeLine6;
        private CustomActivities.ConditionalChildrenActivity Activity1;
        private CustomActivities.RetryActivity retryActivity1;













































    }
}
