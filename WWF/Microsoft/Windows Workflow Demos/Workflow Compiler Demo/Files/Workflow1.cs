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

namespace WorkflowLibrary1
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}

        private int x;

        public int X
        {
            get { return x; }
            set { x = value; }
        }
	
        private void CoinFlip_ExecuteCode(object sender, EventArgs e)
        {
            x = new Random().Next(1, 3);
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Heads");
        }

        private void codeActivity2_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Tails");
        }
	}

}
