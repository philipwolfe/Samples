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

namespace HideChildWorkflow
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}
        public static DependencyProperty CalledWorkflowInProperty = System.Workflow.ComponentModel.DependencyProperty.Register("CalledWorkflowIn", typeof(string), typeof(Workflow1));

        [Description("This is the description which appears in the Property Browser")]
        [Category("This is the category which will be displayed in the Property Browser")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string CalledWorkflowIn
        {
            get
            {
                return ((string)(base.GetValue(Workflow1.CalledWorkflowInProperty)));
            }
            set
            {
                base.SetValue(Workflow1.CalledWorkflowInProperty, value);
            }
        }
        public static DependencyProperty CalledWorkflowOutProperty = System.Workflow.ComponentModel.DependencyProperty.Register("CalledWorkflowOut", typeof(int), typeof(Workflow1));

        [Description("This is the description which appears in the Property Browser")]
        [Category("This is the category which will be displayed in the Property Browser")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public int CalledWorkflowOut
        {
            get
            {
                return ((int)(base.GetValue(Workflow1.CalledWorkflowOutProperty)));
            }
            set
            {
                base.SetValue(Workflow1.CalledWorkflowOutProperty, value);
            }
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Called workflow - it returned {0}", CalledWorkflowOut.ToString());
        }
	}

}
