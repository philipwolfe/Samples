using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Linq;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace PaymentWF
{
	public sealed partial class Checks: SequentialWorkflowActivity
	{
        public string checkText = "VOID";
        public decimal checkAmount = 0;

		public Checks()
		{
			InitializeComponent();
		}

        private void CheckLogic_ExecuteCode(object sender, EventArgs e)
        {
            checkText = en_US_Translation.NumToStr(checkAmount);
        }
	}

}
