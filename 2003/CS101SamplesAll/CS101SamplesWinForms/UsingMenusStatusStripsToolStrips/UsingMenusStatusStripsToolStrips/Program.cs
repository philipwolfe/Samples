#region Using directives

using System;
using System.Collections.Generic;
using System.Windows.Forms;

#endregion

namespace Samples
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
			try
			{
				Application.EnableVisualStyles();
				Application.SetCompatibleTextRenderingDefault(false);
				Application.Run(new UsingMenusStatusStripsToolStrips.MainForm());
			}
			catch (System.Exception ex)
			{
				MessageBox.Show(ex.Message, "Unexpected error");
			}
		}
    }
}