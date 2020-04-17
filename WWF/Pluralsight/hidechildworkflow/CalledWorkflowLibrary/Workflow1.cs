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

namespace CalledWorkflowLibrary
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}
        private int _outParameter;

        public int OutParameter
        {
            get { return _outParameter; }
            
        }

        public static DependencyProperty MyPropertyProperty = System.Workflow.ComponentModel.DependencyProperty.Register("MyProperty", typeof(string), typeof(Workflow1));


        [Description("An input/output parameter")]
        [Category("Misc")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string MyProperty
        {
            get
            {
                return ((string)(base.GetValue(Workflow1.MyPropertyProperty)));
            }
            set
            {
                base.SetValue(Workflow1.MyPropertyProperty, value);
            }
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("Called workflow Executing....");
            throw new Exception("Test");
            _outParameter = 567;//just an example
        }
	}

}
