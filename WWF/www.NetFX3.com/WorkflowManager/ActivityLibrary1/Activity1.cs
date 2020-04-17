using System;
using System.Diagnostics;
using System.Windows.Forms;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;

namespace ActivityLibrary1
{
    public partial class Activity1 : SequenceActivity
    {
        public Activity1()
        {
            InitializeComponent();
        }

        private string name = string.Empty;
        public string UserName
        {
            get { return this.name; }
            set { this.name = value; }
        }

        protected override ActivityExecutionStatus Execute(ActivityExecutionContext executionContext)
        {
            if (!string.IsNullOrEmpty(UserName))
                MessageBox.Show("Hi, " + UserName);

            return base.Execute(executionContext);
        }

        private void callCode_ExecuteCode(object sender, EventArgs e)
        {
            Debug.WriteLine("from the call code activity");
        }
    }
}