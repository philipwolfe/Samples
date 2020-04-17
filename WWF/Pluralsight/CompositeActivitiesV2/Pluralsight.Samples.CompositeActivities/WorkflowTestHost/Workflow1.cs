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

namespace WorkflowTestHost
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
        private int throwIndicator = 0;

		public Workflow1()
		{
			InitializeComponent();
		}

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {

            if (throwIndicator++ < 2)
            {
                Console.WriteLine("Code activity, throwing exception");
                throw new ApplicationException("code activity exception");
            }
            else
            {
                Console.WriteLine("Code activity, NOT throwing");
            }

        }

        private void codeActivity2_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Please reach me on retry");
        }

        private void codeActivity3_ExecuteCode(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error handler on sequence");
            Console.ResetColor();
        }
	}

}
