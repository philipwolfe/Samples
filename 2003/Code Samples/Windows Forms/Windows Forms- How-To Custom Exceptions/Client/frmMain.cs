//Copyright (C) 2002 Microsoft Corporation
//All rights reserved
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).
// using for external assembly that defines
// a Customer class, and three custom exception classes.
// Note the reference required via the References folder.
using System;
//using SomeCompany.CRMSystem;

using System.Windows.Forms;

public class frmMain: System.Windows.Forms.Form 
{

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

	#region " Windows Form Designer generated code "

	public frmMain () 
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

		if (disposing) 
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
	private System.Windows.Forms.Button cmdDelete;
	private System.Windows.Forms.Button cmdUntrapped;
	private System.Windows.Forms.Button cmdEdit;
	private System.Windows.Forms.CheckBox chkGET;

	private void InitializeComponent() 
	{

		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.cmdEdit = new System.Windows.Forms.Button();
		this.cmdDelete = new System.Windows.Forms.Button();
		this.cmdUntrapped = new System.Windows.Forms.Button();
		this.chkGET = new System.Windows.Forms.CheckBox();
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
		//
		//cmdEdit
		//
		this.cmdEdit.Location = new System.Drawing.Point(8, 8);
		this.cmdEdit.Name = "cmdEdit";
		this.cmdEdit.Size = new System.Drawing.Size(150, 23);
		this.cmdEdit.TabIndex = 0;
		this.cmdEdit.Text = "&Edit Customer";
		//
		//cmdDelete
		//
		this.cmdDelete.Location = new System.Drawing.Point(8, 40);
		this.cmdDelete.Name = "cmdDelete";
		this.cmdDelete.Size = new System.Drawing.Size(150, 23);
		this.cmdDelete.TabIndex = 1;
		this.cmdDelete.Text = "&Delete Customer";
		//
		//cmdUntrapped
		//
		this.cmdUntrapped.Location = new System.Drawing.Point(8, 72);
		this.cmdUntrapped.Name = "cmdUntrapped";
		this.cmdUntrapped.Size = new System.Drawing.Size(150, 23);
		this.cmdUntrapped.TabIndex = 2;
		this.cmdUntrapped.Text = "&Untrapped Local Error";
		//

		//chkGET
		//
		this.chkGET.Location = new System.Drawing.Point(8, 104);
		this.chkGET.Name = "chkGET";
		this.chkGET.Size = new System.Drawing.Size(208, 24);
		this.chkGET.TabIndex = 3;
		this.chkGET.Text = "&Turn on Global Exception Trap";
		//
		//frmMain
		//
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(394, 131);
		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.chkGET, this.cmdUntrapped, this.cmdDelete, this.cmdEdit});
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
		this.MaximizeBox = false;
		this.Menu = this.mnuMain;
		this.Name = "frmMain";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Title Comes from Assembly Info";
		this.ResumeLayout(false);

		this.chkGET.CheckedChanged +=new System.EventHandler(chkGET_CheckedChanged);
		this.cmdEdit.Click += new System.EventHandler(cmdEdit_Click);
		this.cmdDelete.Click +=new System.EventHandler(cmdDelete_Click);
		this.cmdUntrapped.Click +=new System.EventHandler(cmdUntrapped_Click);
	}

	#endregion

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

	private void chkGET_CheckedChanged(object sender, System.EventArgs e)
	{
		CheckBox ctl = (CheckBox) sender;
		if (ctl.CheckState == CheckState.Checked) 
		{
			// Turn on our own global exception handler.
			// Note just like the Windows Forms handler, we won't
			// see ours in the debugger by default.
			Application.ThreadException += new System.Threading.ThreadExceptionEventHandler(OnThreadException);
		}
		else 
		{
			// Turn our handler off and revert back to the Windows Forms default.
			Application.ThreadException -= new System.Threading.ThreadExceptionEventHandler(OnThreadException);
		}
	}
	private void cmdEdit_Click(object sender, System.EventArgs e)
	{
		Customer c;
		try 
			{
			int i = 14213;
			c = Customer.EditCustomer(i);
			// do work if we get a valid customer back
			}
		catch (CustomerNotFoundException exp)
			{
			MessageBox.Show(exp.Message, exp.AppSource, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		catch (CustomerException exp)
			{
			MessageBox.Show(exp.Message, exp.AppSource, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}		
		catch (Exception exp)
			{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
	}

	private void cmdDelete_Click(object sender, System.EventArgs e)
	{
		try 
		{
			int i = 14213;
			Customer.DeleteCustomer(i);
			// We'll never see this, bt just for completeness.
			MessageBox.Show(string.Format("Customer Id {0} was deleted.", i), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		catch (CustomerNotDeletedException exp) 
		{
			Customer c;
			c = exp.CustomerInfo;
			// We can now do something more interesting with
			// the customer if we wanted to.
			MessageBox.Show(exp.Message, exp.AppSource, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		catch (CustomerException exp)
		{
			MessageBox.Show(exp.Message, exp.AppSource, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
		catch (Exception exp)
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void cmdUntrapped_Click(object sender, System.EventArgs e)
	{
		// Normally an untrapped error in Visual Basic 6.0
		// and earlier would result in a quick MessageBox and then
		// our process shutting down.
		// Windows Forms however have injected a top-level error 
		// catch between the CLR and our code.
		// Whether or not you see their dialog depends upon three things:
		// 1) == there an active debugger?
		// 2) Do you have your own exception handler in place?
		// 3) Have you turned JIT debugging on (set to true) in your App's config file.?
		// if an untrapped error occurs and you answered no to the
		// above questions, then you will see the Windows Forms dialgo
		// which gives the user a chance to Continue or Quit.
		// To see thier handler, you need to run the compiled code.
		short i = 1234;
		short j = 0;
		short k = -1;
		k = Convert.ToInt16(i / j);
		// Note that you will never see the MsgBox statement below
		MessageBox.Show("Your reults are: " + k.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
	}


	internal void OnThreadException(object sender ,System.Threading.ThreadExceptionEventArgs t)
{
		// At this point you should be able to figure out what to do.
		// You could log the error, show a messagebox, send an e-mail.
		// The real key is to evaluate the exception you received
		// using code like below.
		// Note you should be careful. if you have an untrapped exception here,
		// you will see the JIT debugging dialog, NOT the Windows Forms handler.
		// Uncomment the line below to see.
		// throw new ArgumentException("Oops! I did it again!")
		Exception exp = t.Exception;
		if (exp is CustomerException) 
		{
			// Check for any CustomerExceptions
		} 
		else if (exp is ApplicationException) 
		{
			// Check for any possible application exception
		} 
		else if (exp is ArithmeticException) 
		{
			// You should see this dialog if you ran the
			// code in cmdUntrapped_Click.
			// Uncomment this line to verify.
			// MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error)
		} 
		else if (exp is SystemException) 
		{
			// Check for any possible system exception
		}
		else 
		{
			// Finally just plain old System.Exception
		}
		string strMsg;
		strMsg = string.Format("We're sorry, an untrapped error occurred.{0}The error message was:{0}{1}", Environment.NewLine, exp.Message);
		MessageBox.Show(strMsg, "Global Exception Trap", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
	}
}
