using System;
using System.Windows.Forms;


namespace Microsoft.Workflow.Samples.WorkflowManager
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Form docReviewForm = new HostForm.DocReviewForm();//runtime host
            docReviewForm.Show();
            Application.Run(new WorkflowManager());//master shell
        }
    }
}