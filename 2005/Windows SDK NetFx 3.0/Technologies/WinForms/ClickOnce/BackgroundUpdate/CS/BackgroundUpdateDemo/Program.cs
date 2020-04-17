using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Microsoft.Samples.Windows.Forms.ClickOnce.BackgroundUpdateDemo
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
            Application.Run(new BackgroundUpdateDemoForm());
        }
    }
}