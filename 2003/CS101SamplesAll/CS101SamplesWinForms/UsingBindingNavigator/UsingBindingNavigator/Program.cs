using System;
using System.Collections.Generic;
using System.Windows.Forms;
using System.IO;

namespace UsingBindingNavigator
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

			try
			{
				if (!File.Exists(@"C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\AdventureWorks_Data.mdf"))
				{
					MessageBox.Show("You do not have the Adventure Works database installed", "Configuration Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
					return;
				}


				Application.Run(new Form1());
			}
			catch (ApplicationException ex)
			{
				MessageBox.Show(ex.Message, "Application Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}
}