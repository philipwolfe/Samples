//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Reflection;
using System.Text;
using System.IO;

public class frmMain: System.Windows.Forms.Form 
{

#region " Windows Form Designer generated code "
	public frmMain() 
	{
		//This call is required by the Windows Form Designer.
		InitializeComponent();

		//Add any initialization after the InitializeComponent() call

		// So that we only need to set the title of the application once,
		// we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
		// to read the AssemblyTitle attribute.

		AssemblyInfo ainfo = new AssemblyInfo();
		this.Text = ainfo.Title;
		this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);
	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing) 
	{
		if (disposing) {
			if (components != null) {
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
    private System.Windows.Forms.ListBox lstStackItems;
    private System.Windows.Forms.Button btnException;
    private System.Windows.Forms.Button btnStackTrace;
    private System.Windows.Forms.CheckBox chkIncludeSource;

	private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.lstStackItems = new System.Windows.Forms.ListBox();

        this.btnException = new System.Windows.Forms.Button();

        this.btnStackTrace = new System.Windows.Forms.Button();

        this.chkIncludeSource = new System.Windows.Forms.CheckBox();

        this.SuspendLayout();

        //

        //mnuMain

        //

        this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuHelp});

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
		this.mnuExit.Click += new EventHandler(mnuExit_Click);

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
		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);

        //

        //lstStackItems

        //

        this.lstStackItems.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.lstStackItems.IntegralHeight = false;

        this.lstStackItems.Location = new System.Drawing.Point(184, 8);

        this.lstStackItems.Name = "lstStackItems";

        this.lstStackItems.Size = new System.Drawing.Size(344, 160);

        this.lstStackItems.TabIndex = 5;

        //

        //btnException

        //

        this.btnException.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnException.Location = new System.Drawing.Point(8, 48);

        this.btnException.Name = "btnException";

        this.btnException.Size = new System.Drawing.Size(160, 32);

        this.btnException.TabIndex = 4;

        this.btnException.Text = "Test Exception Handling";
		this.btnException.Click += new EventHandler(btnException_Click);

        //

        //btnStackTrace

        //

        this.btnStackTrace.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnStackTrace.Location = new System.Drawing.Point(8, 8);

        this.btnStackTrace.Name = "btnStackTrace";

        this.btnStackTrace.Size = new System.Drawing.Size(160, 32);

        this.btnStackTrace.TabIndex = 3;

        this.btnStackTrace.Text = "Test Procedure Stack";
		this.btnStackTrace.Click += new EventHandler(btnStackTrace_Click);
        //

        //chkIncludeSource

        //

        this.chkIncludeSource.Location = new System.Drawing.Point(8, 88);

        this.chkIncludeSource.Name = "chkIncludeSource";

        this.chkIncludeSource.Size = new System.Drawing.Size(160, 24);

        this.chkIncludeSource.TabIndex = 6;

        this.chkIncludeSource.Text = "Include Source Info?";

        //

        //frmMain

        //

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

        this.ClientSize = new System.Drawing.Size(530, 198);

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.chkIncludeSource, this.lstStackItems, this.btnException, this.btnStackTrace});

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.MaximizeBox = false;

        this.Menu = this.mnuMain;

        this.MinimumSize = new System.Drawing.Size(536, 232);

        this.Name = "frmMain";

        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

        this.Text = "Title Comes from Assembly Info";

        this.ResumeLayout(false);
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
	// has been added to some procedures since they are
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

	private void btnException_Click(object sender, System.EventArgs e)
	{
		// You can pass an Exception object to the 
		// constructor of the StackTrace class. In that
		// case, you get information about the stack 
		// only within your code, leading up to the
		// exception. This example uses this particular
		// constructor to demonstrate using the StackTrace
		// class with an Exception object.

		try 
		{
			ProcException1(1, 2);
		}
		catch(Exception exp)
		{
			GetFullStackFrameInfo(new StackTrace(exp));
		}
	}

	// This Click event handler, along with ProcA and ProcB, 
	// allow the sample to demonstrate how you can work through
	// the stack frames at any point. In this case, the 
	// code uses the MethodInfo type to display information
	// about the current stack frame.

	private void btnStackTrace_Click(object sender, System.EventArgs e)
	{
		int x = 2;
		ProcA(1, ref x, "Hello");
	}

	private void GetFullStackFrameInfo(StackTrace st)
	{
		int fc = st.FrameCount;

		// Loop through the stack frame count, 
		// starting at the current
		// procedure. You must retrieve 
		// the frames by number, using the GetFrame
		// method.

		lstStackItems.Items.Clear();

		for(int i = 0; i < fc - 1; i++)
		{
			lstStackItems.Items.Add(GetStackFrameInfo(st.GetFrame(i)));
		}
	}

	private string GetStackFrameInfo(StackFrame sf) 
	{
		// return a string containing information about a single stack frame.
		string strParams;

		MethodInfo mi;
		Type typ;
		string strOut = string.Empty;

		mi = (MethodInfo) sf.GetMethod();

		// The following blocks don't trap all of 
		// the possible attributes you can retrieve
		// about a procedure. See the documentation
		// for the MethodInfo class for more info.

		if (mi.IsPrivate)
		{
			strOut += "private ";
		}
		else if ( mi.IsPublic )
		{
			strOut += "public ";
		} 
		else if ( mi.IsFamily ) 
		{
			strOut += "protected ";
		}
		else if ( mi.IsAssembly )
		{
			strOut += "internal ";
		}

		if ( mi.IsStatic ) 
		{
			strOut += "static ";
		}

		strOut += mi.Name + "(";
		
		ParameterInfo[] piList = sf.GetMethod().GetParameters();

		strParams = string.Empty;

		foreach(ParameterInfo pi in piList)
		{
			strParams += string.Format(", {0} {1} {2}", ((pi.ParameterType.IsByRef) ? "ByRef" : "ByVal"), pi.Name, pi.ParameterType.Name);
		}
		
		// Get rid of the first ", " if it exists.
		if (strParams.Length > 2) 
		{
			strOut += strParams.Substring(2);
		}

		// Get the procedure's return type, and append
		// it to the output string.
		typ = mi.ReturnType;
		strOut += ") " + typ.ToString();

		return strOut;
	}

	// ProcException1 through 4 allow the code to demonstrate
	// the stack trace when handling an exception.
	private void ProcException1(int x, int y)
	{
		ProcException2("Mike", 12);
	}

	private void ProcException2(string Name, long Size)
	{
		ProcException3();
	}

	private string ProcException3()
	{
		return ProcException4("mike@microsoft.com");
	}

	private string ProcException4(string EmailAddress)
	{
		throw new ArgumentException("This is a fake exception!");
	}

	private void ProcA(int Item1, ref int Item2, string Item3)
	{
		ProcB(string.Concat(Item1, Item2, Item3));
	}

	private void ProcB(string Name)
	{
		GetFullStackFrameInfo(new StackTrace());
	}
}
