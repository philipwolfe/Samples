using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Transactions
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
                Application.Run(new Form1());
            }
            catch (ApplicationException ex)
            {
                MessageBox.Show(ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
		}
	}
}