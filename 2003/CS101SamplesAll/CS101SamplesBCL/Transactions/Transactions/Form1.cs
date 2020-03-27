using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

using System.Transactions;

namespace Transactions
{
	public partial class Form1 : Form
	{
        TransFile tFile;

        public Form1 ()
		{
			InitializeComponent();
            tFile = new TransFile (new Guid ("{67891A5C-3FE9-48af-AC8F-26B11D8DB035}"));

			Directory.SetCurrentDirectory(Application.StartupPath + @"\..\..\");
        }

		private void button1_Click(object sender, EventArgs e)
		{
			// first delete the test file
			if ( File.Exists ( @"ReadMeCopy.htm" ))
				File.Delete ( @"ReadMeCopy.htm" );

			//Then we start the transaction
			StartImplicitLocalTransaction();
		}

		void StartImplicitLocalTransaction()
		{
			TransactionInformation info;

			TransactionOptions transOptions = new TransactionOptions();
			transOptions.IsolationLevel = System.Transactions.IsolationLevel.ReadCommitted;
			transOptions.Timeout = new TimeSpan(0, 1, 0);

			// Create a transaction scope inside a using statement to protect it against unforseen actions
			// an "ambient" transaction is placed in the current call context
			// Everything inside the using block is in the transaction
			this.transDetails.Text += "\r\n\r\n";
			this.transDetails.Text += "-- Creation Transaction" + "\r\n";
			using (TransactionScope transScope = new TransactionScope(TransactionScopeOption.RequiresNew, transOptions))
			{
				this.transDetails.Text += "-- Inside Transaction Scope" + "\r\n";

				this.transDetails.Text += "-- Transaction Details" + "\r\n";
				this.transDetails.Text += "\tIsolation Level: " + Transaction.Current.IsolationLevel + "\r\n";
				info = Transaction.Current.TransactionInformation;

				this.transDetails.Text += "\tCreation Time: " + info.CreationTime.ToString() + "\r\n";
				this.transDetails.Text += "\tDistrubuted ID: " + info.DistributedIdentifier.ToString() + "\r\n";
				this.transDetails.Text += "\tLocal ID: " + info.LocalIdentifier + "\r\n";
				this.transDetails.Text += "\tStatus: " + info.Status.ToString() + "\r\n";



				// the data provider will detect the transaction and automatically enlist into it
				this.transDetails.Text += "-- Create SQL Connection" + "\r\n";
				using (SqlConnection connection = new SqlConnection(_connectionString1))
				{
					SqlCommand command = new SqlCommand(_sqlString, connection);
					this.transDetails.Text += "-- Open SQL Connection" + "\r\n";
					connection.Open();
					this.transDetails.Text += "-- Run Query SQL" + "\r\n";
					command.ExecuteNonQuery();
					this.transDetails.Text += "-- Close SQL Connection" + "\r\n";
					connection.Close();
				}
				//
				// Now you could use a COM+ component or use MSMQ in a transactional context
				// By creating a transaction file you can also copy some files in a transactional context
				tFile.Copy(@"ReadMe.htm", @"ReadMeCopy.htm");

				// If the previous statements all completed without exceptions then
				// the transaction is in a consitent state and can be comitted
				if (this.IsTransactionSuccess.Checked)
				{
					transScope.Complete();
					this.transDetails.Text += "-- Set Transaction as Complete" + "\r\n";
				}
				else
				{
					this.transDetails.Text += "-- Rollback Transaction" + "\r\n";
				}
			}
			// after leaving the using block Dispose will be called
			// on the transaction and the transaction will be comitted if it was set to complete

			System.Threading.Thread.Sleep(1000);

			this.transDetails.Text += "Has the file been copied? " + File.Exists(@"ReadMeCopy.htm");
		}

		private void ClearDetails_Click(object sender, EventArgs e)
		{
			this.transDetails.Text = "";
		}

		private string _connectionString1 = @"Server=.\SQLExpress;Database=AdventureWorks;Integrated Security=True";
		private string _sqlString = "select * from HumanResources.Employee";
	}
}