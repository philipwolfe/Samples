using System;
using System.Workflow.Activities;

namespace ActivityLibrary1
{
    public sealed partial class Workflow1 : SequentialWorkflowActivity
    {
        private string title = string.Empty;
        public string Title
        {
            get { return this.title; }
        }

        public Workflow1()
        {
            InitializeComponent();
        }

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {

        }

        protected override void Initialize(IServiceProvider provider)
        {
            base.Initialize(provider);
            this.title = GetWorklfowTitle();
        }

        private static Random rnd = new Random((int)DateTime.Now.Ticks);
        private string GetWorklfowTitle()
        {
            lock (rnd)
            {
                return differentTitles[rnd.Next(differentTitles.Length)];
            }
        }

        private static string[] differentTitles = new string[] 
                { "A custom WF for demo purposes (dynamically set in initialize)" , 
                    "Another Workflow for a demo", 
                    "Yet another workflow instance to be shown", 
                    "This workflow is again a different one", 
                    "Just a worklfow instance", 
                    "This is a workflow instance with a custom title", 
                    "How many workflows are there?",
                    "There are many workfows to be started...",
                    "There are many workflows to be completed as well...",
                    "The last workflow title there is."
                };
    }
}