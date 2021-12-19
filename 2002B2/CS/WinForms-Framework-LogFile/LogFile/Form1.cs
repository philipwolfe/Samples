using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;

namespace LogFile
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Button btnLog;
		private System.Windows.Forms.TextBox txtLog;
		private System.Windows.Forms.TextBox txtMessage;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

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
			if(components != null)
				components.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.Label1 = new System.Windows.Forms.Label();
			this.Label2 = new System.Windows.Forms.Label();
			this.btnLog = new System.Windows.Forms.Button();
			this.txtLog = new System.Windows.Forms.TextBox();
			this.txtMessage = new System.Windows.Forms.TextBox();
			this.Label1.Location = new System.Drawing.Point(16, 8);
			this.Label1.Size = new System.Drawing.Size(480, 24);
			this.Label1.TabIndex = 1;
			this.Label1.Text = "Enter a message in the text box below and press the log button to write to the lo" +
				"g.txt file.";
			this.Label2.Location = new System.Drawing.Point(16, 80);
			this.Label2.Size = new System.Drawing.Size(480, 24);
			this.Label2.TabIndex = 5;
			this.Label2.Text = "Log File Dump:";
			this.Label2.Visible = false;
			this.btnLog.Location = new System.Drawing.Point(168, 40);
			this.btnLog.TabIndex = 0;
			this.btnLog.Text = "Log";
			this.btnLog.Click += new System.EventHandler(this.btnLog_Click);
			this.txtLog.Location = new System.Drawing.Point(16, 112);
			this.txtLog.Multiline = true;
			this.txtLog.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtLog.Size = new System.Drawing.Size(472, 160);
			this.txtLog.TabIndex = 4;
			this.txtLog.Text = "";
			this.txtMessage.Location = new System.Drawing.Point(16, 40);
			this.txtMessage.Size = new System.Drawing.Size(136, 20);
			this.txtMessage.TabIndex = 2;
			this.txtMessage.Text = "Test Message";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 285);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.txtMessage,
																		  this.txtLog,
																		  this.Label2,
																		  this.Label1,
																		  this.btnLog});
			this.Text = "Form1";

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

		private void btnLog_Click(object sender, System.EventArgs e)
		{
			//create the log file
			FileStream fs = new FileStream("log.txt", FileMode.OpenOrCreate, FileAccess.Write);

			// create a Char writer 
			StreamWriter  w = new StreamWriter(fs);
			w.BaseStream.Seek(0, SeekOrigin.End); // set the file pointer to the end

			//log the new message
			Log(txtMessage.Text, w);

			//close the writer and underlying file  
			w.Close(); 
			txtLog.Text = DumpLog("log.txt");
		}

		public void Log(string logMessage, StreamWriter w)
		{
			//Write the new entry to the log file    
			w.WriteLine();
			w.Write("Log Entry : ");
			w.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(), DateTime.Now.ToLongDateString());
			w.WriteLine("  :");
			w.WriteLine("  :{0}", logMessage);
			w.WriteLine("-------------------------------");
			w.Flush();  // update underlying file
		}

		public string DumpLog(string filename)
		{
			FileStream fs = new FileStream(filename, FileMode.OpenOrCreate, FileAccess.Read);

			StreamReader r = new StreamReader(fs); // create a Char reader
			r.BaseStream.Seek(0, SeekOrigin.Begin); // set the file pointer to the beginning

			//read the contents of the log file

			string s = "";		

			//Read the contents of the log file
			string line;
			while ((line = r.ReadLine()) != null)
			{	
				s += line + "\r\n";
			}

			//close the log file
			r.Close();

			//return the contens of the log file
			return s;
		}
	}
}
