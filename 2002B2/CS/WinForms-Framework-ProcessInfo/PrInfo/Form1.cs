using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Diagnostics;

namespace PrInfo
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnGetProcessByID;
		private System.Windows.Forms.Button btnGetProcessList;
		private System.Windows.Forms.TextBox txtProcessID;
		/// <summary>
		/// Required designer variable.
		/// </summary>

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnGetProcessByID = new System.Windows.Forms.Button();
			this.btnGetProcessList = new System.Windows.Forms.Button();
			this.txtProcessID = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnGetProcessByID
			// 
			this.btnGetProcessByID.Location = new System.Drawing.Point(16, 64);
			this.btnGetProcessByID.Name = "btnGetProcessByID";
			this.btnGetProcessByID.Size = new System.Drawing.Size(144, 23);
			this.btnGetProcessByID.TabIndex = 4;
			this.btnGetProcessByID.Text = "Get Info for Process ID ->";
			this.btnGetProcessByID.Click += new System.EventHandler(this.btnGetProcessByID_Click);
			// 
			// btnGetProcessList
			// 
			this.btnGetProcessList.Location = new System.Drawing.Point(16, 16);
			this.btnGetProcessList.Name = "btnGetProcessList";
			this.btnGetProcessList.Size = new System.Drawing.Size(216, 23);
			this.btnGetProcessList.TabIndex = 0;
			this.btnGetProcessList.Text = "Click Me First to get the Processes List";
			this.btnGetProcessList.Click += new System.EventHandler(this.btnGetProcessList_Click);
			// 
			// txtProcessID
			// 
			this.txtProcessID.Location = new System.Drawing.Point(168, 64);
			this.txtProcessID.Name = "txtProcessID";
			this.txtProcessID.Size = new System.Drawing.Size(120, 20);
			this.txtProcessID.TabIndex = 5;
			this.txtProcessID.Text = "";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 133);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtProcessID,
																		  this.btnGetProcessByID,
																		  this.btnGetProcessList});
			this.Name = "Form1";
			this.Text = "Form1";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		private void btnGetProcessList_Click(object sender, System.EventArgs e)
		{
			string s = "";
			Process[] processes;

			//get the list of current processes
			processes = System.Diagnostics.Process.GetProcesses();

			//grab some basic information for each process
			Process process;
			for (int i = 0;i <= processes.Length - 1; i++)
			{
				process = processes[i];
				s = s + Convert.ToString(process.Id) + "    : " + process.ProcessName + "\r\n";
			}

			//display the process information to the user
			System.Windows.Forms.MessageBox.Show(s);

			//default the textbox value to the first process id - for the GetByID button
			txtProcessID.Text = processes[0].Id.ToString();
		}

		private void btnGetProcessByID_Click(object sender, System.EventArgs e)
		{
			try
			{
				string s = "";
				System.Int32 processid ;
				Process process;

				// Retrieve additional information about a specific process
				processid = Int32.Parse(txtProcessID.Text);
				process = System.Diagnostics.Process.GetProcessById(processid);

				s = s + "Priority Class         :" + Convert.ToString(process.PriorityClass) + "\r\n";
				s = s + "Handle Count           :" + process.HandleCount + "\r\n";
				s = s + "Main Window Title      :" + process.MainWindowTitle + "\r\n";
				s = s + "Min Working Set        :" + process.MinWorkingSet.ToString() + "\r\n";
				s = s + "Max Working Set        :" + process.MaxWorkingSet.ToString() + "\r\n";
				s = s + "Paged Memory Size      :" + process.PagedMemorySize + "\r\n";
				s = s + "Peak Paged Memory Size :" + process.PeakPagedMemorySize + "\r\n";

				System.Windows.Forms.MessageBox.Show(s);

			}
			catch
			{
				System.Windows.Forms.MessageBox.Show("Invalid Process ID");
			}
		}
	}
}
