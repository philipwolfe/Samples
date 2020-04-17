///
///This sample is provided as is with no warranties implied or granted whatsoever.  
///Use this code at your own risk.  
///
///Matt Milner
///http://www.pluralsight.com/matt/
///

using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace StateTrackingSample
{
	public sealed partial class Workflow1: StateMachineWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}

        bool iterationFlag = false;

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Initial state executing");
        }

        private void codeActivity2_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Second state executing");
        }

        private void codeActivity3_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Executing second state intializer" );
        }

        private void codeActivity4_ExecuteCode(object sender, EventArgs e)
        {
            iterationFlag = true;
        }

        private void DelayIntialized(object sender, EventArgs e)
        {
            Console.WriteLine("Initial state delay initialized");
        }
	}

}
