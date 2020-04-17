using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;

namespace CustomActivities
{
	public partial class WriteLine: Activity
	{
        public static DependencyProperty OutputTextProperty = System.Workflow.ComponentModel.DependencyProperty.Register("OutputText", typeof(string), typeof(WriteLine));

        [Category("Output")]
        [Browsable(true)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        public string OutputText
        {
            get
            {
                return ((string)(base.GetValue(WriteLine.OutputTextProperty)));
            }
            set
            {
                base.SetValue(WriteLine.OutputTextProperty, value);
            }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            Console.WriteLine(OutputText);
            return ActivityExecutionStatus.Closed;
        }
	}
}
