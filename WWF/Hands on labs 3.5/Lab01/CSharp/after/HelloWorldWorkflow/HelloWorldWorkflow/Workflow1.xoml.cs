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

namespace HelloWorldWorkflow
{
    public partial class Workflow1 : SequentialWorkflowActivity
    {
        private void codeActivity1_CodeHandler(object sender, EventArgs e)
        {
            System.Windows.Forms.MessageBox.Show(FirstName + " " + LastName);
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
