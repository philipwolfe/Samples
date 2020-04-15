//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Collections;
using System.Collections.Specialized;
using System.Windows.Forms;

public class frmMain: System.Windows.Forms.Form 
{
	// These Custom events ared used to notify the Forms class
	// when the user cancels a Save during the Form_Closing event or
	// when they chose Exit from the File menu.

	public event System.EventHandler SaveWhileClosingCancelled;
	public event System.EventHandler ExitApplication;

	private bool m_Dirty = false;
	private bool m_ClosingComplete = false;

	private string m_DocumentName;
	private string m_FileName;
	
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

		// The title for the Form will be set differenly in this
		// How-to than others you might look at.
		// this.Text = ainfo.Title
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

	private System.Windows.Forms.StatusBar sbDocInfo;

	private System.Windows.Forms.TextBox txtData;

	private System.Windows.Forms.MenuItem mnuNew;

	private System.Windows.Forms.MenuItem mnuSave;

	private System.Windows.Forms.MenuItem MenuItem2;

	private System.Windows.Forms.MenuItem mnuClose;

	private System.Windows.Forms.MenuItem MenuItem1;

	private void InitializeComponent() 
	{
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuNew = new System.Windows.Forms.MenuItem();
		this.mnuClose = new System.Windows.Forms.MenuItem();
		this.MenuItem1 = new System.Windows.Forms.MenuItem();
		this.mnuSave = new System.Windows.Forms.MenuItem();
		this.MenuItem2 = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.sbDocInfo = new System.Windows.Forms.StatusBar();
		this.txtData = new System.Windows.Forms.TextBox();
		this.SuspendLayout();
		// 
		// mnuMain
		// 
		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuFile,
																				this.mnuHelp});
		// 
		// mnuFile
		// 
		this.mnuFile.Index = 0;
		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuNew,
																				this.mnuClose,
																				this.MenuItem1,
																				this.mnuSave,
																				this.MenuItem2,
																				this.mnuExit});
		this.mnuFile.Text = "&File";
		// 
		// mnuNew
		// 
		this.mnuNew.Index = 0;
		this.mnuNew.Shortcut = System.Windows.Forms.Shortcut.CtrlN;
		this.mnuNew.Text = "&New";
		this.mnuNew.Click += new System.EventHandler(this.mnuNew_Click);
		// 
		// mnuClose
		// 
		this.mnuClose.Index = 1;
		this.mnuClose.Text = "&Close";
		this.mnuClose.Click += new System.EventHandler(this.mnuClose_Click);
		// 
		// MenuItem1
		// 
		this.MenuItem1.Index = 2;
		this.MenuItem1.Text = "-";
		// 
		// mnuSave
		// 
		this.mnuSave.Index = 3;
		this.mnuSave.Shortcut = System.Windows.Forms.Shortcut.CtrlS;
		this.mnuSave.Text = "&Save";
		this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
		// 
		// MenuItem2
		// 
		this.MenuItem2.Index = 4;
		this.MenuItem2.Text = "-";
		// 
		// mnuExit
		// 
		this.mnuExit.Index = 5;
		this.mnuExit.Text = "E&xit";
		this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
		// 
		// mnuHelp
		// 
		this.mnuHelp.Index = 1;
		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuAbout});
		this.mnuHelp.Text = "&Help";
		// 
		// mnuAbout
		// 
		this.mnuAbout.Index = 0;
		this.mnuAbout.Text = "Text Comes from AssemblyInfo";
		this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
		// 
		// sbDocInfo
		// 
		this.sbDocInfo.Location = new System.Drawing.Point(0, 213);
		this.sbDocInfo.Name = "sbDocInfo";
		this.sbDocInfo.Size = new System.Drawing.Size(458, 22);
		this.sbDocInfo.TabIndex = 0;
		this.sbDocInfo.Text = "Ready";
		// 
		// txtData
		// 
		this.txtData.Dock = System.Windows.Forms.DockStyle.Fill;
		this.txtData.Location = new System.Drawing.Point(0, 0);
		this.txtData.Multiline = true;
		this.txtData.Name = "txtData";
		this.txtData.ScrollBars = System.Windows.Forms.ScrollBars.Both;
		this.txtData.Size = new System.Drawing.Size(458, 213);
		this.txtData.TabIndex = 1;
		this.txtData.Text = "";
		this.txtData.TextChanged += new System.EventHandler(this.txtData_TextChanged);
		// 
		// frmMain
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(458, 235);
		this.Controls.Add(this.txtData);
		this.Controls.Add(this.sbDocInfo);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.MaximizeBox = false;
		this.Menu = this.mnuMain;
		this.Name = "frmMain";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Title is set a load time";
		this.Closing += new System.ComponentModel.CancelEventHandler(this.frmMain_Closing);
		this.ResumeLayout(false);

	}
	#endregion

	#region " Standard Menu Code "
	// This code simply shows the About form.
	private void mnuAbout_Click(object sender, System.EventArgs e) 
	{
		// Open the About form in Dialog Mode
		frmAbout frm = new frmAbout();
		frm.ShowDialog(this);
		frm.Dispose();
	}
	#endregion

	public bool ClosingComplete
	{
		get {
			return m_ClosingComplete;
		}
	}

	public string DocumentName
	{
		get {
			return m_DocumentName;
		}
	}

	public bool Dirty
	{
		// This property is used in order to determine if
		// we need to save our data before we close the form.
		get {
			return m_Dirty;
		}

		set {
			if (value) 
			{
				if (!this.Text.EndsWith("*")) 
				{
					this.Text = this.Text + "*";
					this.sbDocInfo.Text = "Changes need to be saved.";
				}
			}
			else 
			{
				this.sbDocInfo.Text = "Ready";

				// Remove the *
				this.Text = this.Text.Substring(0, (this.Text.Length));
			}
			m_Dirty = value;
		}
	}

	public string FileName
	{
		get {
			return m_FileName;
		}
		set {
			m_FileName = value;
			m_DocumentName = System.IO.Path.GetFileNameWithoutExtension(m_FileName);
			this.Text = this.DocumentName;
		}
	}

	private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e) 
	{
		try 
		{
			// Set our ClosingComplete property to true
			// to let the Forms class know it can remove 
			// us from its collection
			m_ClosingComplete = true;

			if (this.Dirty)
			{
				// Ask the use to Save (Yes), not Save (No), or Stop the closing (Cancel)
				string strDocTitle;

				if (this.Text.EndsWith("*"))
				{
					strDocTitle = this.Text.Substring(0, this.Text.Length);
				}
				else
				{
					strDocTitle = this.Text;
				}

				string strMsg = string.Format("Do you want to save {0}?", strDocTitle);

				switch(MessageBox.Show(strMsg, "Closing", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Exclamation, MessageBoxDefaultButton.Button1))
				{
					case DialogResult.Yes:
					{
						// Save the document
						this.SaveDocument();
						break;
					}
					case DialogResult.No:
					{	
						// Don't save the document just exit
						// Put your code here
						break;
					}
					case DialogResult.Cancel:
					{
						// Stop the form from closing.
						e.Cancel = true;

						// if the user cancel's the close, we need to keep
						// our form in the main Forms collection
						m_ClosingComplete = false;

						// Raise an event to stop the application 
						// from closing any other open documents
						SaveWhileClosingCancelled(this, null);
						break;
					}
				}
			}
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void mnuExit_Click(object sender, System.EventArgs e) 
	{
		// Exit the application
		ExitApplication(this, null);
	}

	private void mnuNew_Click(object sender, System.EventArgs e)
	{
		// Create a new document instnace
		Forms.newForm();
	}

	private void mnuSave_Click(object sender, System.EventArgs e)
	{
		this.SaveDocument();
	}

	private void mnuClose_Click(object sender, System.EventArgs e) 
	{
		this.Close();
	}

	private void txtData_TextChanged(object sender, System.EventArgs e)
	{
		// if the data is changed, set the form's dirty property to true
		this.Dirty = true;
	}

	private void SaveDocument()
	{
		// This code DOES NOT perform any file I/O. 
		try 
		{
			// Check to see if the document is dirty
			if (this.Dirty)
			{
				// Check to see if we have a file (document) name already
				if (this.FileName != null) 
				{
					// Save the existing document to the file
				}
				else 
				{
					// We don't have a file name, ask for one.
					// See the Common Dialog How-to for an example of
					// Use the Save Common Dialog
					// We're going to create a file name based upon the document
					// title and the current application's directory
					this.FileName = AppDomain.CurrentDomain.BaseDirectory + "Saved" + this.Text;
				}

				// Once the document has been saved, reset the dirty bit
				this.Dirty = false;
			}
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}

public class Forms
{
	// Internal Collection to manage list of document forms.
	// Other forms such the About form will not be in 
	// this list, only frmMain which is our 'document' screen.
	private static ListDictionary m_Forms = new ListDictionary();
	
	// Internal counter for use in creating a default title
	// for each new form
	private static int m_FormsCreated = 0;

	// This property is used in order to determine if
	// we need to stop application shutdown if the user
	// clicks the cancel button on the Save document
	// dialog displayed by forms that have dirty content.
	private static bool m_CancelExit = false;

	// Used to check if a shutdown is in progress
	private static bool m_ShutdownInProgress = false;

	// Number of forms currently loaded
	public static int Count
	{
		get {
			return m_Forms.Count;
		}
	}

	public static void Main()
	{
		// Open the first document window
		try 
		{
			Forms.newForm();
		}
		catch (Exception) 
		{
			// if we get here, we're in trouble.
			MessageBox.Show("Sorry, we were unable to load a document. Good Bye.", "Application Main", MessageBoxButtons.OK, MessageBoxIcon.Error);
			Application.Exit();
		}

		// Set the main thread to run outside the control
		// of a particular form so that closing one document
		// does not terminate the whole process.
		Application.Run();
	}

	public static void newForm()
	{
		try 
		{
			Forms.m_FormsCreated++;
			frmMain frm = new frmMain();
			frm.Text = "Document" + Forms.m_FormsCreated.ToString();
			m_Forms.Add(Forms.m_FormsCreated, frm);
			// Hook the new form's Closed event so that we know when
			// the they close the document window
			frm.Closed += new System.EventHandler(Forms.frmMain_Closed);

			// Hook the custom SaveWhileClosingCancelled so that we know if the
			// use clicks the Cancel button when prompted to save a dirty document.
			frm.SaveWhileClosingCancelled += new System.EventHandler(Forms.frmMain_SaveWhileClosingCancelled);

			// Hook the custom ExitApplication so that we know if a user wants to 
			// shut down the application by selecting the Exit menu item from a document form.
			frm.ExitApplication += new System.EventHandler(Forms.frmMain_ExitApplication);

			// Make the form visible
			frm.Show();
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
			if (Forms.Count == 0)
			{
				// Rethrow the error to Main so
				// we can shut down the process
				throw exp;
			}
		}
	}

	private static void FormClosed(frmMain frm)
	{
		// Remove the form that has closed from the internal collection.
		m_Forms.Remove(frm.GetHashCode().ToString());

		// if we have no more forms, shut down the process.
		if (m_Forms.Count == 0)
		{
			Application.Exit();
		}
	}

	public static void ExitApp()
	{
		try 
		{
			m_ShutdownInProgress = true;

			// Shutdown once all the forms have been closed.
			frmMain frm;

			// Loop through the collection stepping backwards
			// one form at a time, asking each form to close
			// itself. Only ask form's that are dirty that way
			// if the user says Cancel, we won't close open forms.
			//for(int i = m_Forms.Count; i > 0; i--)
			for (int i = 1; i < m_Forms.Count; i++ )

			{
				frm = (frmMain) m_Forms[i];

				if (frm.Dirty)
				{
					frm.Close();
				}

				// Check our internal flag in case
				// the user wants to stop the shutdown.
				if (m_CancelExit == true) 
				{
					m_CancelExit = false;
					return;
				}
			}

			// Now close any of documents that aren't dirty.
			// At this point no other windows will cancel
			// the shutdown.
			if (m_Forms.Count > 0)
			{
				for(int i = m_Forms.Count; i > 0; i--)
				{
					frm = (frmMain) m_Forms[i];
					frm.Close();
				}
			}
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);

			// Bug out if we get an error here
			Application.Exit();
		}
		finally
		{
			m_ShutdownInProgress = false;
		}
	}

	private static void frmMain_Closed(object sender, System.EventArgs e)
	{
		try 
		{
			// We catch this event when a form has finished closing.
			frmMain frm = (frmMain) sender;

			// Remove our event handlers we added when the form was created.
			frm.Closed -= new System.EventHandler(Forms.frmMain_Closed);
			frm.SaveWhileClosingCancelled -= new System.EventHandler(Forms.frmMain_SaveWhileClosingCancelled);
			frm.ExitApplication -= new System.EventHandler(Forms.frmMain_ExitApplication);

			// Call our function to clean up
			Forms.FormClosed(frm);
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private static void frmMain_SaveWhileClosingCancelled(object sender, System.EventArgs e)
	{
		// This event will be caught if the user clicks cancel
		// when asked to save a dirty document.
		if (m_ShutdownInProgress)
		{
			// Only change our internal value if
			// we're actually in the process of shutting down.
			Forms.m_CancelExit = true;
		}
	}

	private static void frmMain_ExitApplication(object sender, System.EventArgs e)
	{
		// This event will be caught if the user clicks the
		// Exit menu command.
		Forms.ExitApp();
	}
}