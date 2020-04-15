//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional 
//(or greater).

using System;
using System.Diagnostics;
using System.Windows.Forms;
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

    private System.Windows.Forms.Button cmdTraceToOutput;

    private System.Windows.Forms.Button cmdTraceToEventLog;

    private System.Windows.Forms.Button cmdTraceToFile;

    private System.Windows.Forms.Button cmdTraceToHTML;

    private void InitializeComponent() 
	{
        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.cmdTraceToOutput = new System.Windows.Forms.Button();

        this.cmdTraceToEventLog = new System.Windows.Forms.Button();

        this.cmdTraceToFile = new System.Windows.Forms.Button();

        this.cmdTraceToHTML = new System.Windows.Forms.Button();

        this.SuspendLayout();

        //

        //mnuMain

        //

        this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuHelp});

        this.mnuMain.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("mnuMain.RightToLeft");

        //

        //mnuFile

        //

        this.mnuFile.Enabled = (bool) resources.GetObject("mnuFile.Enabled");

        this.mnuFile.Index = 0;

        this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuExit});

        this.mnuFile.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuFile.Shortcut");

        this.mnuFile.ShowShortcut = (bool) resources.GetObject("mnuFile.ShowShortcut");

        this.mnuFile.Text = resources.GetString("mnuFile.Text");

        this.mnuFile.Visible = (bool) resources.GetObject("mnuFile.Visible");

        //

        //mnuExit

        //

        this.mnuExit.Enabled = (bool) resources.GetObject("mnuExit.Enabled");

        this.mnuExit.Index = 0;

        this.mnuExit.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuExit.Shortcut");

        this.mnuExit.ShowShortcut = (bool) resources.GetObject("mnuExit.ShowShortcut");

        this.mnuExit.Text = resources.GetString("mnuExit.Text");

        this.mnuExit.Visible = (bool) resources.GetObject("mnuExit.Visible");

        //

        //mnuHelp

        //

        this.mnuHelp.Enabled = (bool) resources.GetObject("mnuHelp.Enabled");

        this.mnuHelp.Index = 1;

        this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuAbout});

        this.mnuHelp.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuHelp.Shortcut");

        this.mnuHelp.ShowShortcut = (bool) resources.GetObject("mnuHelp.ShowShortcut");

        this.mnuHelp.Text = resources.GetString("mnuHelp.Text");

        this.mnuHelp.Visible = (bool) resources.GetObject("mnuHelp.Visible");

        //

        //mnuAbout

        //

        this.mnuAbout.Enabled = (bool) resources.GetObject("mnuAbout.Enabled");

        this.mnuAbout.Index = 0;

        this.mnuAbout.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuAbout.Shortcut");

        this.mnuAbout.ShowShortcut = (bool) resources.GetObject("mnuAbout.ShowShortcut");

        this.mnuAbout.Text = resources.GetString("mnuAbout.Text");

        this.mnuAbout.Visible = (bool) resources.GetObject("mnuAbout.Visible");

        //

        //cmdTraceToOutput

        //

        this.cmdTraceToOutput.AccessibleDescription = resources.GetString("cmdTraceToOutput.AccessibleDescription");

        this.cmdTraceToOutput.AccessibleName = resources.GetString("cmdTraceToOutput.AccessibleName");

        this.cmdTraceToOutput.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cmdTraceToOutput.Anchor");

        this.cmdTraceToOutput.BackgroundImage = (System.Drawing.Image) resources.GetObject("cmdTraceToOutput.BackgroundImage");

        this.cmdTraceToOutput.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cmdTraceToOutput.Dock");

        this.cmdTraceToOutput.Enabled = (bool) resources.GetObject("cmdTraceToOutput.Enabled");

        this.cmdTraceToOutput.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("cmdTraceToOutput.FlatStyle");

        this.cmdTraceToOutput.Font = (System.Drawing.Font) resources.GetObject("cmdTraceToOutput.Font");

        this.cmdTraceToOutput.Image = (System.Drawing.Image) resources.GetObject("cmdTraceToOutput.Image");

        this.cmdTraceToOutput.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("cmdTraceToOutput.ImageAlign");

        this.cmdTraceToOutput.ImageIndex = (int) resources.GetObject("cmdTraceToOutput.ImageIndex");

        this.cmdTraceToOutput.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cmdTraceToOutput.ImeMode");

        this.cmdTraceToOutput.Location = (System.Drawing.Point) resources.GetObject("cmdTraceToOutput.Location");

        this.cmdTraceToOutput.Name = "cmdTraceToOutput";

        this.cmdTraceToOutput.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cmdTraceToOutput.RightToLeft");

        this.cmdTraceToOutput.Size = (System.Drawing.Size) resources.GetObject("cmdTraceToOutput.Size");

        this.cmdTraceToOutput.TabIndex = (int) resources.GetObject("cmdTraceToOutput.TabIndex");

        this.cmdTraceToOutput.Text = resources.GetString("cmdTraceToOutput.Text");

        this.cmdTraceToOutput.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("cmdTraceToOutput.TextAlign");

        this.cmdTraceToOutput.Visible = (bool) resources.GetObject("cmdTraceToOutput.Visible");

        //

        //cmdTraceToEventLog

        //

        this.cmdTraceToEventLog.AccessibleDescription = resources.GetString("cmdTraceToEventLog.AccessibleDescription");

        this.cmdTraceToEventLog.AccessibleName = resources.GetString("cmdTraceToEventLog.AccessibleName");

        this.cmdTraceToEventLog.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cmdTraceToEventLog.Anchor");

        this.cmdTraceToEventLog.BackgroundImage = (System.Drawing.Image) resources.GetObject("cmdTraceToEventLog.BackgroundImage");

        this.cmdTraceToEventLog.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cmdTraceToEventLog.Dock");

        this.cmdTraceToEventLog.Enabled = (bool) resources.GetObject("cmdTraceToEventLog.Enabled");

        this.cmdTraceToEventLog.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("cmdTraceToEventLog.FlatStyle");

        this.cmdTraceToEventLog.Font = (System.Drawing.Font) resources.GetObject("cmdTraceToEventLog.Font");

        this.cmdTraceToEventLog.Image = (System.Drawing.Image) resources.GetObject("cmdTraceToEventLog.Image");

        this.cmdTraceToEventLog.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("cmdTraceToEventLog.ImageAlign");

        this.cmdTraceToEventLog.ImageIndex = (int) resources.GetObject("cmdTraceToEventLog.ImageIndex");

        this.cmdTraceToEventLog.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cmdTraceToEventLog.ImeMode");

        this.cmdTraceToEventLog.Location = (System.Drawing.Point) resources.GetObject("cmdTraceToEventLog.Location");

        this.cmdTraceToEventLog.Name = "cmdTraceToEventLog";

        this.cmdTraceToEventLog.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cmdTraceToEventLog.RightToLeft");

        this.cmdTraceToEventLog.Size = (System.Drawing.Size) resources.GetObject("cmdTraceToEventLog.Size");

        this.cmdTraceToEventLog.TabIndex = (int) resources.GetObject("cmdTraceToEventLog.TabIndex");

        this.cmdTraceToEventLog.Text = resources.GetString("cmdTraceToEventLog.Text");

        this.cmdTraceToEventLog.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("cmdTraceToEventLog.TextAlign");

        this.cmdTraceToEventLog.Visible = (bool) resources.GetObject("cmdTraceToEventLog.Visible");

        //

        //cmdTraceToFile

        //

        this.cmdTraceToFile.AccessibleDescription = resources.GetString("cmdTraceToFile.AccessibleDescription");

        this.cmdTraceToFile.AccessibleName = resources.GetString("cmdTraceToFile.AccessibleName");

        this.cmdTraceToFile.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cmdTraceToFile.Anchor");

        this.cmdTraceToFile.BackgroundImage = (System.Drawing.Image) resources.GetObject("cmdTraceToFile.BackgroundImage");

        this.cmdTraceToFile.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cmdTraceToFile.Dock");

        this.cmdTraceToFile.Enabled = (bool) resources.GetObject("cmdTraceToFile.Enabled");

        this.cmdTraceToFile.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("cmdTraceToFile.FlatStyle");

        this.cmdTraceToFile.Font = (System.Drawing.Font) resources.GetObject("cmdTraceToFile.Font");

        this.cmdTraceToFile.Image = (System.Drawing.Image) resources.GetObject("cmdTraceToFile.Image");

        this.cmdTraceToFile.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("cmdTraceToFile.ImageAlign");

        this.cmdTraceToFile.ImageIndex = (int) resources.GetObject("cmdTraceToFile.ImageIndex");

        this.cmdTraceToFile.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cmdTraceToFile.ImeMode");

        this.cmdTraceToFile.Location = (System.Drawing.Point) resources.GetObject("cmdTraceToFile.Location");

        this.cmdTraceToFile.Name = "cmdTraceToFile";

        this.cmdTraceToFile.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cmdTraceToFile.RightToLeft");

        this.cmdTraceToFile.Size = (System.Drawing.Size) resources.GetObject("cmdTraceToFile.Size");

        this.cmdTraceToFile.TabIndex = (int) resources.GetObject("cmdTraceToFile.TabIndex");

        this.cmdTraceToFile.Text = resources.GetString("cmdTraceToFile.Text");

        this.cmdTraceToFile.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("cmdTraceToFile.TextAlign");

        this.cmdTraceToFile.Visible = (bool) resources.GetObject("cmdTraceToFile.Visible");

        //

        //cmdTraceToHTML

        //

        this.cmdTraceToHTML.AccessibleDescription = resources.GetString("cmdTraceToHTML.AccessibleDescription");

        this.cmdTraceToHTML.AccessibleName = resources.GetString("cmdTraceToHTML.AccessibleName");

        this.cmdTraceToHTML.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cmdTraceToHTML.Anchor");

        this.cmdTraceToHTML.BackgroundImage = (System.Drawing.Image) resources.GetObject("cmdTraceToHTML.BackgroundImage");

        this.cmdTraceToHTML.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cmdTraceToHTML.Dock");

        this.cmdTraceToHTML.Enabled = (bool) resources.GetObject("cmdTraceToHTML.Enabled");

        this.cmdTraceToHTML.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("cmdTraceToHTML.FlatStyle");

        this.cmdTraceToHTML.Font = (System.Drawing.Font) resources.GetObject("cmdTraceToHTML.Font");

        this.cmdTraceToHTML.Image = (System.Drawing.Image) resources.GetObject("cmdTraceToHTML.Image");

        this.cmdTraceToHTML.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("cmdTraceToHTML.ImageAlign");

        this.cmdTraceToHTML.ImageIndex = (int) resources.GetObject("cmdTraceToHTML.ImageIndex");

        this.cmdTraceToHTML.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cmdTraceToHTML.ImeMode");

        this.cmdTraceToHTML.Location = (System.Drawing.Point) resources.GetObject("cmdTraceToHTML.Location");

        this.cmdTraceToHTML.Name = "cmdTraceToHTML";

        this.cmdTraceToHTML.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cmdTraceToHTML.RightToLeft");

        this.cmdTraceToHTML.Size = (System.Drawing.Size) resources.GetObject("cmdTraceToHTML.Size");

        this.cmdTraceToHTML.TabIndex = (int) resources.GetObject("cmdTraceToHTML.TabIndex");

        this.cmdTraceToHTML.Text = resources.GetString("cmdTraceToHTML.Text");

        this.cmdTraceToHTML.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("cmdTraceToHTML.TextAlign");

        this.cmdTraceToHTML.Visible = (bool) resources.GetObject("cmdTraceToHTML.Visible");

        //

        //frmMain

        //

        this.AccessibleDescription = (string) resources.GetObject("$this.AccessibleDescription");

        this.AccessibleName = (string) resources.GetObject("$this.AccessibleName");

        this.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("$this.Anchor");

        this.AutoScaleBaseSize = (System.Drawing.Size) resources.GetObject("$this.AutoScaleBaseSize");

        this.AutoScroll = (bool) resources.GetObject("$this.AutoScroll");

        this.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMargin");

        this.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMinSize");

        this.BackgroundImage = (System.Drawing.Image) resources.GetObject("$this.BackgroundImage");

        this.ClientSize = (System.Drawing.Size) resources.GetObject("$this.ClientSize");

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmdTraceToHTML, this.cmdTraceToFile, this.cmdTraceToEventLog, this.cmdTraceToOutput});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

        this.MaximizeBox = false;

        this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

        this.Menu = this.mnuMain;

        this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

        this.Name = "frmMain";

        this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

        this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

        this.Text = resources.GetString("$this.Text");

        this.Visible = (bool) resources.GetObject("$this.Visible");

        this.ResumeLayout(false);
		this.cmdTraceToEventLog.Click += new EventHandler(cmdTraceToEventLog_Click);
		this.cmdTraceToFile.Click += new EventHandler(cmdTraceToFile_Click);
		this.cmdTraceToHTML.Click += new EventHandler(cmdTraceToHTML_Click);
		this.cmdTraceToOutput.Click += new EventHandler(cmdTraceToOutput_Click);
		this.mnuExit.Click += new EventHandler(mnuExit_Click);
		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);
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

    private void cmdTraceToEventLog_Click(object sender, System.EventArgs e) 
	{
        // This void demonstrates how to create and add a trace 
        // listener that sends messages to the application
        // event log.  This should be used sparingly due to the 
        // resources it uses to write to the event log.
        // Create an EventLog instance and assign it a source.
        EventLog myLog = new EventLog();
        myLog.Source = this.Text;

		// Create a trace listener for the application event log.
        EventLogTraceListener tlEventLog = new EventLogTraceListener(myLog);
        Trace.Listeners.Clear();

		// Add the event log trace listener to the collection.
        Trace.Listeners.Add(tlEventLog);

        // Write output to the event log.
        Trace.WriteLine("This is a test of event log tracing");
    }

    private void cmdTraceToFile_Click(object sender, System.EventArgs e)
	{
        // This sub shows how to add a trace listener that sends 
        // the trace output to a text file called TraceOutput.txt.
        // This file is created in the same folder the EXE which 
        // is usually the bin folder where the project is saved.
		// Create a file for output named TraceOutput.txt.

		System.IO.Stream traceFile = File.Create("TraceOutput.txt");

        // some variables to display in trace output
        string ProductType = "Computer";
        int Price = 2000;

        // Create an instance of the text writer trace listener to 
        // output to a text file
        TextWriterTraceListener tlTextFile = new TextWriterTraceListener(traceFile);

        // Clear the listeners collection
        Trace.Listeners.Clear();
        Trace.Listeners.Add(tlTextFile);

        // WriteLine will output a mesaage and will issue a carriage 
        // return line feed
        Trace.WriteLine("******  Trace Output to File ******");
        Trace.WriteLine("Trace output for " + this.Text);
        Trace.WriteLine(string.Empty);

        // This will indent all lines until Unindent is called
        Trace.Indent();
        Trace.WriteLine("This line is indented");
        Trace.WriteLine("Product Type = " + ProductType);
        Trace.WriteLine("Price = $" + Price);

		// WriteLineif is a condition way of sending messages to the trace
        // when the first argument evaluates to true
        Trace.WriteLineIf(Price > 1800, "Price > $1800");
        Trace.Unindent();

        // Flush and close the output.
        tlTextFile.Flush();
        tlTextFile.Close();

		// Show text file output
        System.Diagnostics.Process.Start("Notepad.exe", "TraceOutput.txt");
    }

    private void cmdTraceToHTML_Click(object sender, System.EventArgs e) 
	{
        // This sub shows how to add a custom trace listener that 
        // sends the trace output to a HTML file called TraceOutputHTML.htm
        // This file is created in the same folder your EXE which 
        // is usually the bin folder under where the project is saved.

		// Create a file for output named TraceOutputHTML.htm
        System.IO.Stream traceFile = File.Create("TraceOutputHTML.htm");
        
        // some variables to display in trace output
        string ProductType = "Computer";
        int Price = 2000;
        
        // Create an instance of the text writer trace listener to 
        // output to a text file
        HTMLTraceListener tlHTMLFile = new HTMLTraceListener(traceFile);
        tlHTMLFile.WriteHeader("HTML Trace Output Example for " + this.Text);

        // Clear the listeners collection
        Trace.Listeners.Clear();
        Trace.Listeners.Add(tlHTMLFile);

        // This will indent all lines until Unindent is called
        Trace.Indent();
        Trace.WriteLine("This line is indented");
        Trace.Unindent();
        Trace.WriteLine("Product Type = " + ProductType);
        Trace.WriteLine("Price = $" + Price);

        // WriteLineif is a condition way of sending messages to the trace
        // when the first argument evaluates to true
        Trace.WriteLineIf(Price > 1800, "Price > $1800");

        // Flush and close the output.
        tlHTMLFile.Flush();
        tlHTMLFile.Close();

        // Launch default browser to show file output
        System.Diagnostics.Process.Start("TraceOutputHTML.htm");
    }

    private void cmdTraceToOutput_Click(object sender, System.EventArgs e)
	{
        // This sub shows how to use the default trace listener that 
        // sends the trace output to the Output window in the IDE.  
        // It also shows how to readd the default trace listener if the 
		// trace listeners collection has been cleared. The default trace 
        // listener by default is added to the trace listeners collection.
        // some variables to display in trace output

        string ProductType = "Computer";
        int Price = 2000;
        
        // Create instance of the default trace listener
        DefaultTraceListener tlDefault = new DefaultTraceListener();

        // Clear all trace listeners from the collection
        Trace.Listeners.Clear();

        // Add the default listener to the collection
        Trace.Listeners.Add(tlDefault);

        // WriteLine will output a mesaage and will issue a 
        // carriage return line feed
        Trace.WriteLine("******  Trace OutPut Start  ******");
        Trace.WriteLine("Output window trace information");

        // This will indent all lines until Unindent is called
        Trace.Indent();
        Trace.WriteLine("This line is indented");
        Trace.WriteLine("Product Type = " + ProductType);
        Trace.WriteLine("Price = $" + Price);

        // WriteLineif is a condition way of sending messages to the trace
        // when the first argument evaluates to true
        Trace.WriteLineIf(Price > 1800, "Price > $1800");
        Trace.Unindent();
        Trace.WriteLine("******   Trace Output End   ******");
    }
}