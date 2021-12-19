using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Threading;

namespace FreeThread
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private Thread[] oThreads = new Thread[6];
		//private ThreadStart[] oThreadStart;
		private string[] strThreadState = new string[]{"","","","","",""};	
		private const string STARTED = "Started";
		private const string STOPPED = "Stopped";
		private const string FINISHED = "Finished";
		private System.Windows.Forms.Button Button1;
		private System.Windows.Forms.ProgressBar ProgressBar2;
		private System.Windows.Forms.ProgressBar ProgressBar3;
		private System.Windows.Forms.ProgressBar ProgressBar1;
		private System.Windows.Forms.Button Button5;
		private System.Windows.Forms.Button Button6;
		private System.Windows.Forms.Button Button2;
		private System.Windows.Forms.Button Button3;
		private System.Windows.Forms.Button Button4;
		private System.Windows.Forms.ProgressBar ProgressBar4;
		private System.Windows.Forms.ProgressBar ProgressBar5;
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

			 //Initialize the ProgressBars
			ProgressBar1.Minimum = 1;
			ProgressBar1.Maximum = 50;
			ProgressBar2.Minimum = 1;
			ProgressBar2.Maximum = 50;
			ProgressBar3.Minimum = 1;
			ProgressBar3.Maximum = 50;
			ProgressBar4.Minimum = 1;
			ProgressBar4.Maximum = 50;
			ProgressBar5.Minimum = 1;
			ProgressBar5.Maximum = 50;
		}

		private void ThreadState(int ThreadName, System.Windows.Forms.Button TheButton)
		{
			
			switch (strThreadState[ThreadName])
			{
				case STARTED:
					strThreadState[ThreadName] = STOPPED;
					TheButton.Text = "Resume";
					oThreads[ThreadName].Suspend();
					break;
				case STOPPED:
					strThreadState[ThreadName] = STARTED;
					TheButton.Text = "Suspend";
					oThreads[ThreadName].Resume();
					break;
				case FINISHED:
					//do nothing			
					break;
			}
		}

		internal void NewThread()
		//internal void NewThread(Thread oThread, System.Windows.Forms.ProgressBar oProgressBar, Random oRandom, int i)
		{					
			Thread oThread;        
			System.Windows.Forms.ProgressBar oProgressBar = new System.Windows.Forms.ProgressBar();
			Random oRandom;
			
			//Get a reference to myself
			//We will use this later to get the name of the thread        
			oThread = System.Threading.Thread.CurrentThread;


			//Create an instance of a Random object
			//We are seeding the random number generator with
			//The thread number + the current second, which will
			//Give each thread a different sequence of random numbers
			oRandom = new Random(System.Convert.ToInt16(oThread.Name) + System.DateTime.Now.Second);

			//Using the thread's name we get a reference to the
			//ProgressBar it is responsible for updating			
			switch (oThread.Name) 
			{
				case "1":
					oProgressBar = ProgressBar1;
					break;
				case "2":
					oProgressBar = ProgressBar2;
					break;
				case "3":
					oProgressBar = ProgressBar3;
					break;
				case "4":
					oProgressBar = ProgressBar4;
					break;
				case "5":
					oProgressBar = ProgressBar5;			
					break;
			}

			
			for (int j = 1;j < 50; j++)
			{
				//Update the ProgressBar
				oProgressBar.Value = j;
			
				//Sleep a random number of milliseconds
				//NextDouble will return the next random
				//Number in the sequence
				System.Threading.Thread.Sleep(Convert.ToInt32(oRandom.NextDouble()) * 1000);
			}

			//Mark the thread as "finished"
			strThreadState[Convert.ToInt16(oThread.Name)] = FINISHED;
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
			this.components = new System.ComponentModel.Container();
			this.ProgressBar2 = new System.Windows.Forms.ProgressBar();
			this.ProgressBar3 = new System.Windows.Forms.ProgressBar();
			this.ProgressBar1 = new System.Windows.Forms.ProgressBar();
			this.Button5 = new System.Windows.Forms.Button();
			this.Button6 = new System.Windows.Forms.Button();
			this.Button1 = new System.Windows.Forms.Button();
			this.Button2 = new System.Windows.Forms.Button();
			this.Button3 = new System.Windows.Forms.Button();
			this.Button4 = new System.Windows.Forms.Button();
			this.ProgressBar4 = new System.Windows.Forms.ProgressBar();
			this.ProgressBar5 = new System.Windows.Forms.ProgressBar();
			this.ProgressBar2.Location = new System.Drawing.Point(16, 104);
			this.ProgressBar2.Size = new System.Drawing.Size(128, 23);
			this.ProgressBar2.TabIndex = 1;
			this.ProgressBar3.Location = new System.Drawing.Point(16, 152);
			this.ProgressBar3.Size = new System.Drawing.Size(128, 23);
			this.ProgressBar3.TabIndex = 2;
			this.ProgressBar1.Location = new System.Drawing.Point(16, 64);
			this.ProgressBar1.Size = new System.Drawing.Size(128, 23);
			this.ProgressBar1.TabIndex = 0;
			this.Button5.Location = new System.Drawing.Point(152, 192);
			this.Button5.Size = new System.Drawing.Size(64, 23);
			this.Button5.TabIndex = 9;
			this.Button5.Text = "Suspend";
			this.Button5.Click += new System.EventHandler(this.Button5_Click);
			this.Button6.Location = new System.Drawing.Point(152, 232);
			this.Button6.Size = new System.Drawing.Size(64, 23);
			this.Button6.TabIndex = 10;
			this.Button6.Text = "Suspend";
			this.Button6.Click += new System.EventHandler(this.Button6_Click);
			this.Button1.Location = new System.Drawing.Point(16, 16);
			this.Button1.Size = new System.Drawing.Size(88, 32);
			this.Button1.TabIndex = 5;
			this.Button1.Text = "StartThreads";
			this.Button1.Click += new System.EventHandler(this.Button1_Click);
			this.Button2.Location = new System.Drawing.Point(152, 64);
			this.Button2.Size = new System.Drawing.Size(64, 23);
			this.Button2.TabIndex = 6;
			this.Button2.Text = "Suspend";
			this.Button2.Click += new System.EventHandler(this.Button2_Click);
			this.Button3.Location = new System.Drawing.Point(152, 104);
			this.Button3.Size = new System.Drawing.Size(64, 23);
			this.Button3.TabIndex = 7;
			this.Button3.Text = "Suspend";
			this.Button3.Click += new System.EventHandler(this.Button3_Click);
			this.Button4.Location = new System.Drawing.Point(152, 152);
			this.Button4.Size = new System.Drawing.Size(64, 23);
			this.Button4.TabIndex = 8;
			this.Button4.Text = "Suspend";
			this.Button4.Click += new System.EventHandler(this.Button4_Click);
			this.ProgressBar4.Location = new System.Drawing.Point(16, 192);
			this.ProgressBar4.Size = new System.Drawing.Size(128, 23);
			this.ProgressBar4.TabIndex = 3;
			this.ProgressBar5.Location = new System.Drawing.Point(16, 232);
			this.ProgressBar5.Size = new System.Drawing.Size(128, 23);
			this.ProgressBar5.TabIndex = 4;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(296, 285);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Button4,
																		  this.Button3,
																		  this.ProgressBar1,
																		  this.ProgressBar3,
																		  this.Button2,
																		  this.ProgressBar2,
																		  this.ProgressBar5,
																		  this.ProgressBar4,
																		  this.Button6,
																		  this.Button5,
																		  this.Button1});
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

		private void Button1_Click(object sender, System.EventArgs e)
		{  
			for (int i = 0;i <= 5; i++)
			{      
				//clear any existing threads (if the start button was clicked more than once)
				oThreads[i] = null;

				//Create a ThreadStart object, passing the address of NewThread             
				oThreads[i] = new Thread(new ThreadStart(NewThread));

				//Starting the thread invokes the ThreadStart delegate
				oThreads[i].Name = i.ToString();
				strThreadState[i] = STARTED;

				oThreads[i].Start();
			}
		}

		private void Button2_Click(object sender, System.EventArgs e)
		{
			ThreadState(1, this.Button2);
		}

		private void Button3_Click(object sender, System.EventArgs e)
		{
			ThreadState(2, this.Button3);
		}

		private void Button4_Click(object sender, System.EventArgs e)
		{
			ThreadState(3, this.Button4);
		}

		private void Button5_Click(object sender, System.EventArgs e)
		{
			ThreadState(4, this.Button5);
		}

		private void Button6_Click(object sender, System.EventArgs e)
		{
			ThreadState(5, this.Button6);
		}
	}
}
