//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).


using System;
using System.Windows.Forms;
using System.Threading; // Namespace for Thread class

public class frmMain : System.Windows.Forms.Form
{

#region " Windows Form Designer generated code "

	public frmMain()
	{
		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call
		// So that we only need to set the title of the application once,
		// we use the AssemblyInfo class (defined in the AssemblyInfo.vb file)
		// to read the AssemblyTitle attribute.

		AssemblyInfo ainfo = new AssemblyInfo();

		this.Text = ainfo.Title;
		this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);
	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing)
	{
		if(disposing)
		{
			if (components != null) 
			{
				components.Dispose();
			}
		}

		base.Dispose(disposing);
	}

	//Required by the Windows Form Designer
	private System.ComponentModel.IContainer components = null;

	//NOTE: The following procedure is required by the Windows Form Designer
	//It can be modified using the Windows Form Designer.  
	//Do not modify it using the code editor.
	private System.Windows.Forms.MainMenu mnuMain;
	private System.Windows.Forms.MenuItem mnuFile;
	private System.Windows.Forms.MenuItem mnuExit;
	private System.Windows.Forms.MenuItem mnuHelp;
	private System.Windows.Forms.MenuItem mnuAbout;
	private System.Windows.Forms.GroupBox grpLongRunningTask;
    private System.Windows.Forms.Button cmdSameThread;
    private System.Windows.Forms.Button cmdWorkerPoolThread;
    private System.Windows.Forms.Button cmdRunOnnewWin32Thread;
    private System.Windows.Forms.Label lblThreadID;

	private void InitializeComponent()
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.grpLongRunningTask = new System.Windows.Forms.GroupBox();
		this.cmdRunOnnewWin32Thread = new System.Windows.Forms.Button();
		this.cmdWorkerPoolThread = new System.Windows.Forms.Button();
		this.cmdSameThread = new System.Windows.Forms.Button();
		this.lblThreadID = new System.Windows.Forms.Label();
		this.grpLongRunningTask.SuspendLayout();
		this.SuspendLayout();

		//
		//mnuMain
		//
		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] { this.mnuFile, this.mnuHelp});
		//
		//mnuFile
		//
		this.mnuFile.Index = 0;
		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuExit});
		this.mnuFile.Text = "&File";
		//
		//mnuExit
		//
		this.mnuExit.Index = 0;
		this.mnuExit.Text = "E&xit";
		this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
		//
		//mnuHelp
		//
		this.mnuHelp.Index = 1;
		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuAbout});
		this.mnuHelp.Text = "&Help";
		//
		//mnuAbout
		//
		this.mnuAbout.Index = 0;
		this.mnuAbout.Text = "Text Comes from AssemblyInfo";
		this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
		//
		//grpLongRunningTask
		//
		this.grpLongRunningTask.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmdRunOnnewWin32Thread, this.cmdWorkerPoolThread, this.cmdSameThread});
		this.grpLongRunningTask.Location = new System.Drawing.Point(16, 56);
		this.grpLongRunningTask.Name = "grpLongRunningTask";
		this.grpLongRunningTask.Size = new System.Drawing.Size(232, 144);
		this.grpLongRunningTask.TabIndex = 3;
		this.grpLongRunningTask.TabStop = false;
		this.grpLongRunningTask.Text = "Execute a long-running task";
		//
		//cmdRunOnnewWin32Thread
		//
		this.cmdRunOnnewWin32Thread.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdRunOnnewWin32Thread.Location = new System.Drawing.Point(16, 96);
		this.cmdRunOnnewWin32Thread.Name = "cmdRunOnnewWin32Thread";
		this.cmdRunOnnewWin32Thread.Size = new System.Drawing.Size(200, 23);
		this.cmdRunOnnewWin32Thread.TabIndex = 5;
		this.cmdRunOnnewWin32Thread.Text = "Run on &new Win32 thread";
		this.cmdRunOnnewWin32Thread.Click += new System.EventHandler(this.cmdRunOnNewWin32Thread_Click);
		//
		//cmdWorkerPoolThread
		//
		this.cmdWorkerPoolThread.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdWorkerPoolThread.Location = new System.Drawing.Point(16, 64);
		this.cmdWorkerPoolThread.Name = "cmdWorkerPoolThread";
		this.cmdWorkerPoolThread.Size = new System.Drawing.Size(200, 23);
		this.cmdWorkerPoolThread.TabIndex = 4;
		this.cmdWorkerPoolThread.Text = "Run on &worker pool thread";
		this.cmdWorkerPoolThread.Click += new System.EventHandler(this.cmdWorkerPoolThread_Click);
		//
		//cmdSameThread
		//
		this.cmdSameThread.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdSameThread.Location = new System.Drawing.Point(16, 32);
		this.cmdSameThread.Name = "cmdSameThread";
		this.cmdSameThread.Size = new System.Drawing.Size(200, 23);
		this.cmdSameThread.TabIndex = 3;
		this.cmdSameThread.Text = "Run on &same thread";
		this.cmdSameThread.Click += new System.EventHandler(this.cmdSameThread_Click);
		//
		//lblThreadID
		//
		this.lblThreadID.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblThreadID.Location = new System.Drawing.Point(16, 16);
		this.lblThreadID.Name = "lblThreadID";
		this.lblThreadID.Size = new System.Drawing.Size(240, 24);
		this.lblThreadID.TabIndex = 4;
		this.lblThreadID.Text = "This window is being serviced by thread: ";
		//
		//frmMain
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(266, 235);
		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblThreadID, this.grpLongRunningTask});
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.Menu = this.mnuMain;
		this.Name = "frmMain";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Title Comes from Assembly Info";
		this.grpLongRunningTask.ResumeLayout(false);
		this.ResumeLayout(false);
		this.Load += new EventHandler(this.frmMain_Load);
	}
#endregion

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

#region " Standard Menu Code "
	// <System.Diagnostics.DebuggerStepThrough()> has been added to some procedures since they are
	// not the focus of the demo. Remove them if you wish to debug the procedures.
	// This code simply shows the About form.

	private void mnuAbout_Click(object sender, System.EventArgs e)
	{
		// Open the About form in Dialog Mode
		frmAbout frm = new frmAbout();

		frm.ShowDialog(this);
		frm.Dispose();
	}

	// This code will close the form.
	private void mnuExit_Click(object sender, System.EventArgs e)
	{
		// Close the current form
		this.Close();
	}

#endregion

    private void frmMain_Load(object sender, System.EventArgs e)
	{
        //Display the main thread for the application 
        lblThreadID.Text += AppDomain.GetCurrentThreadId().ToString();
    }

    private void cmdSameThread_Click(object sender, System.EventArgs e)
	{
        //Run the task on the same thread that is managing the frmMain window.
		TheLongRunningTask();
    }

    //To run the task on a worker pool thread, you can use an asynchronous
    //invocation on a delegate. For this example, we'll declare a delegate
    //named TaskDelegate, and call it asynchronously. The signature of the
    //delegate declaration must match the method (TheLongRunningTask) exactly.
    delegate void TaskDelegate();

    private void cmdWorkerPoolThread_Click(object sender, System.EventArgs e)
	{
        //To run the task an a thread from the worker pool, create an instance
        //of a delegate whose signature matches the method that will be called,
        //then call BeginInvoke on that delegate. For this example, the arguments
        //and return value of BeginInvoke are unneeded. This technique is sometimes
        //referred to as "Fire and Forget".

        TaskDelegate td = new TaskDelegate(new ThreadStart(TheLongRunningTask));
        td.BeginInvoke(null, null); // Runs on a worker thread from the pool
    }

    private void cmdRunOnNewWin32Thread_Click(object sender, System.EventArgs e)
	{
        //To run the task on a newly created OS thread (rather than a tread from the
        //thread pool), create a new instance of a managed thread. The constructor 
        //takes the address of a subroutine with no arguments.
        Thread t = new Thread(new ThreadStart(TheLongRunningTask));  // Creates the new thread
        t.Start(); // Begins the execution of the new thread
    }

    private void TheLongRunningTask()
	{
        //This method simulates some long-running task. To represent the work in 
        //progress, a form with a progress bar will display during its execution.
        //The method displays the form, then updates the progress bar every half
        //second for 5 seconds. After simulating the task, the form is taken down.

		frmTaskProgress f = new frmTaskProgress();

		f.Show();
		f.Refresh();	   // Refresh causes an instant (non-posted) display of the label.

        //Slowly increment the progress bar
        int i;

        for(i = 1; i < 10; i++)
		{
            f.prgTaskProgress.Value += 10;
			Thread.Sleep(500); // half-second delay
		}

        //Remove the form after the "task" finishes
		f.Hide();
		f.Dispose();
	}
}

