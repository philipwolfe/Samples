using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Reflection;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace StateTrackingSample
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
            System.Workflow.Activities.Rules.RuleConditionReference ruleconditionreference1 = new System.Workflow.Activities.Rules.RuleConditionReference();
            this.setStateActivity3 = new System.Workflow.Activities.SetStateActivity();
            this.setStateActivity1 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivity4 = new System.Workflow.Activities.CodeActivity();
            this.ifElseBranchActivity2 = new System.Workflow.Activities.IfElseBranchActivity();
            this.ifElseBranchActivity1 = new System.Workflow.Activities.IfElseBranchActivity();
            this.codeActivity3 = new System.Workflow.Activities.CodeActivity();
            this.ifElseActivity1 = new System.Workflow.Activities.IfElseActivity();
            this.codeActivity2 = new System.Workflow.Activities.CodeActivity();
            this.delayActivity2 = new System.Workflow.Activities.DelayActivity();
            this.setStateActivity2 = new System.Workflow.Activities.SetStateActivity();
            this.codeActivity1 = new System.Workflow.Activities.CodeActivity();
            this.delayActivity1 = new System.Workflow.Activities.DelayActivity();
            this.stateInitializationActivity1 = new System.Workflow.Activities.StateInitializationActivity();
            this.eventDrivenActivity2 = new System.Workflow.Activities.EventDrivenActivity();
            this.eventDrivenActivity1 = new System.Workflow.Activities.EventDrivenActivity();
            this.CompletedState = new System.Workflow.Activities.StateActivity();
            this.SecondState = new System.Workflow.Activities.StateActivity();
            this.InitialState = new System.Workflow.Activities.StateActivity();
            // 
            // setStateActivity3
            // 
            this.setStateActivity3.Name = "setStateActivity3";
            this.setStateActivity3.TargetStateName = "CompletedState";
            // 
            // setStateActivity1
            // 
            this.setStateActivity1.Name = "setStateActivity1";
            this.setStateActivity1.TargetStateName = "InitialState";
            // 
            // codeActivity4
            // 
            this.codeActivity4.Name = "codeActivity4";
            this.codeActivity4.ExecuteCode += new System.EventHandler(this.codeActivity4_ExecuteCode);
            // 
            // ifElseBranchActivity2
            // 
            this.ifElseBranchActivity2.Activities.Add(this.setStateActivity3);
            this.ifElseBranchActivity2.Name = "ifElseBranchActivity2";
            // 
            // ifElseBranchActivity1
            // 
            this.ifElseBranchActivity1.Activities.Add(this.codeActivity4);
            this.ifElseBranchActivity1.Activities.Add(this.setStateActivity1);
            ruleconditionreference1.ConditionName = "IterationFlagCheck";
            this.ifElseBranchActivity1.Condition = ruleconditionreference1;
            this.ifElseBranchActivity1.Name = "ifElseBranchActivity1";
            // 
            // codeActivity3
            // 
            this.codeActivity3.Name = "codeActivity3";
            this.codeActivity3.ExecuteCode += new System.EventHandler(this.codeActivity3_ExecuteCode);
            // 
            // ifElseActivity1
            // 
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity1);
            this.ifElseActivity1.Activities.Add(this.ifElseBranchActivity2);
            this.ifElseActivity1.Name = "ifElseActivity1";
            // 
            // codeActivity2
            // 
            this.codeActivity2.Name = "codeActivity2";
            this.codeActivity2.ExecuteCode += new System.EventHandler(this.codeActivity2_ExecuteCode);
            // 
            // delayActivity2
            // 
            this.delayActivity2.Name = "delayActivity2";
            this.delayActivity2.TimeoutDuration = System.TimeSpan.Parse("00:00:02");
            // 
            // setStateActivity2
            // 
            this.setStateActivity2.Name = "setStateActivity2";
            this.setStateActivity2.TargetStateName = "SecondState";
            // 
            // codeActivity1
            // 
            this.codeActivity1.Name = "codeActivity1";
            this.codeActivity1.ExecuteCode += new System.EventHandler(this.codeActivity1_ExecuteCode);
            // 
            // delayActivity1
            // 
            this.delayActivity1.Name = "delayActivity1";
            this.delayActivity1.TimeoutDuration = System.TimeSpan.Parse("00:00:02");
            this.delayActivity1.InitializeTimeoutDuration += new System.EventHandler(this.DelayIntialized);
            // 
            // stateInitializationActivity1
            // 
            this.stateInitializationActivity1.Activities.Add(this.codeActivity3);
            this.stateInitializationActivity1.Name = "stateInitializationActivity1";
            // 
            // eventDrivenActivity2
            // 
            this.eventDrivenActivity2.Activities.Add(this.delayActivity2);
            this.eventDrivenActivity2.Activities.Add(this.codeActivity2);
            this.eventDrivenActivity2.Activities.Add(this.ifElseActivity1);
            this.eventDrivenActivity2.Name = "eventDrivenActivity2";
            // 
            // eventDrivenActivity1
            // 
            this.eventDrivenActivity1.Activities.Add(this.delayActivity1);
            this.eventDrivenActivity1.Activities.Add(this.codeActivity1);
            this.eventDrivenActivity1.Activities.Add(this.setStateActivity2);
            this.eventDrivenActivity1.Name = "eventDrivenActivity1";
            // 
            // CompletedState
            // 
            this.CompletedState.Name = "CompletedState";
            // 
            // SecondState
            // 
            this.SecondState.Activities.Add(this.eventDrivenActivity2);
            this.SecondState.Activities.Add(this.stateInitializationActivity1);
            this.SecondState.Name = "SecondState";
            // 
            // InitialState
            // 
            this.InitialState.Activities.Add(this.eventDrivenActivity1);
            this.InitialState.Name = "InitialState";
            // 
            // Workflow1
            // 
            this.Activities.Add(this.InitialState);
            this.Activities.Add(this.SecondState);
            this.Activities.Add(this.CompletedState);
            this.CompletedStateName = "CompletedState";
            this.DynamicUpdateCondition = null;
            this.InitialStateName = "InitialState";
            this.Name = "Workflow1";
            this.CanModifyActivities = false;

        }

        #endregion

        private IfElseBranchActivity ifElseBranchActivity2;
        private IfElseBranchActivity ifElseBranchActivity1;
        private IfElseActivity ifElseActivity1;
        private SetStateActivity setStateActivity1;
        private CodeActivity codeActivity4;
        private CodeActivity codeActivity1;
        private DelayActivity delayActivity1;
        private EventDrivenActivity eventDrivenActivity1;
        private CodeActivity codeActivity2;
        private DelayActivity delayActivity2;
        private SetStateActivity setStateActivity2;
        private EventDrivenActivity eventDrivenActivity2;
        private StateActivity CompletedState;
        private StateActivity SecondState;
        private SetStateActivity setStateActivity3;
        private StateInitializationActivity stateInitializationActivity1;
        private CodeActivity codeActivity3;
        private StateActivity InitialState;











    }
}
