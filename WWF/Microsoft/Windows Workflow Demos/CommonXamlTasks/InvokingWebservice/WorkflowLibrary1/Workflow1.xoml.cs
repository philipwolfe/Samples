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
	public partial class Workflow1 : SequentialWorkflowActivity
	{
        private string personName;

        public string PersonName
        {
            get { return personName; }
            set { personName = value; }
        }

        private string wsResults;

        public string WSResults
        {
            get { return wsResults; }
            set { wsResults = value; }
        }

        private void WSInvoked(object sender, InvokeWebServiceEventArgs e)
        {

        }

        private void WSInvoking(object sender, InvokeWebServiceEventArgs e)
        {

        }
	}
}
