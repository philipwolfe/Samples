using System.Security;
using System.Windows.Forms;
using System.Diagnostics;
using System;

public class frmRead:System.Windows.Forms.Form 
{

    // Stores the name of the log that the user wants to view.

    private string logType  = "";

#region " Windows Form Designer generated code "

    public frmRead() 
	{

        //This call is required by the Windows Form Designer.

        InitializeComponent();

        //Add any initialization after the InitializeComponent() call
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

    private System.Windows.Forms.ListBox lstEntryType;

    private System.Windows.Forms.Button btnViewLogEntries;

    private System.Windows.Forms.Label lblEntryType;

    private System.Windows.Forms.RichTextBox rchEventLogOutput;

    private void InitializeComponent() 
	{

        this.lstEntryType = new System.Windows.Forms.ListBox();

        this.btnViewLogEntries = new System.Windows.Forms.Button();

        this.lblEntryType = new System.Windows.Forms.Label();

        this.rchEventLogOutput = new System.Windows.Forms.RichTextBox();

        this.SuspendLayout();

        //

        //lstEntryType

        //

        this.lstEntryType.AccessibleDescription = "List of logs";

        this.lstEntryType.AccessibleName = "Log List";

        this.lstEntryType.Location = new System.Drawing.Point(16, 40);

        this.lstEntryType.Name = "lstEntryType";

        this.lstEntryType.Size = new System.Drawing.Size(184, 43);

        this.lstEntryType.TabIndex = 2;
		this.lstEntryType.SelectedIndexChanged +=new EventHandler(lstEntryType_SelectedIndexChanged);

        //

        //btnViewLogEntries

        //

        this.btnViewLogEntries.AccessibleDescription = "View Button";

        this.btnViewLogEntries.AccessibleName = "View Button";

        this.btnViewLogEntries.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnViewLogEntries.Location = new System.Drawing.Point(16, 96);

        this.btnViewLogEntries.Name = "btnViewLogEntries";

        this.btnViewLogEntries.Size = new System.Drawing.Size(184, 23);

        this.btnViewLogEntries.TabIndex = 3;

        this.btnViewLogEntries.Text = "&View Log Entries";
		this.btnViewLogEntries.Click +=new EventHandler(cmdViewLogEntries_Click);

        //

        //lblEntryType

        //

        this.lblEntryType.AccessibleDescription = "Choose a log label";

        this.lblEntryType.AccessibleName = "log label";

        this.lblEntryType.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblEntryType.Location = new System.Drawing.Point(16, 16);

        this.lblEntryType.Name = "lblEntryType";

        this.lblEntryType.Size = new System.Drawing.Size(184, 23);

        this.lblEntryType.TabIndex = 1;

        this.lblEntryType.Text = "&Choose a Log:";

        //

        //rchEventLogOutput

        //

        this.rchEventLogOutput.AccessibleDescription = "Contents of log";

        this.rchEventLogOutput.AccessibleName = "Log Contents";

        this.rchEventLogOutput.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right);

        this.rchEventLogOutput.Location = new System.Drawing.Point(216, 40);

        this.rchEventLogOutput.Name = "rchEventLogOutput";

        this.rchEventLogOutput.ReadOnly = true;

        this.rchEventLogOutput.Size = new System.Drawing.Size(488, 392);

        this.rchEventLogOutput.TabIndex = 4;

        this.rchEventLogOutput.Text = "";

        //

        //frmRead

        //

        this.AccessibleDescription = "Form for reading the event log";

        this.AccessibleName = "Form Read";

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

        this.ClientSize = new System.Drawing.Size(720, 446);

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lstEntryType, this.btnViewLogEntries, this.lblEntryType, this.rchEventLogOutput});

        this.Name = "frmRead";

        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

        this.Text = "Read from the Event Log";
		this.Load +=new EventHandler(frmRead_Load);

        this.ResumeLayout(false);

    }

#endregion

    private void cmdViewLogEntries_Click(object sender, System.EventArgs e) 
	{
        try 
		{
            const int ENTRIES_TO_DISPLAY  = 10;

            // In this case the EventLog constructor is passed a string variable for the log name.
            // This is because the user of the application can choose which log they wish to view 
            // from the listbox on the form.

            EventLog ev = new EventLog(logType, System.Environment.MachineName,"How-To Use the EventLog");

           

            rchEventLogOutput.Text = "Event log entries (maximum of 10), newest to oldest" + Environment.NewLine + Environment.NewLine;

            int LastLogToShow  = ev.Entries.Count - ENTRIES_TO_DISPLAY;

            if (LastLogToShow < 0) 
			{
                LastLogToShow = 0;
            }

            // Display the last 10 records in the chosen log 

            int i;
			
			for(i =ev.Entries.Count - 1;i>=LastLogToShow;LastLogToShow++)
			{
            //For i = ev.Entries.Count - 1 To LastLogToShow Step -1;

                EventLogEntry CurrentEntry  = ev.Entries[i];

                rchEventLogOutput.Text += "Event ID : " + CurrentEntry.EventID + Environment.NewLine;

                rchEventLogOutput.Text += "Entry Type : " + CurrentEntry.EntryType.ToString() + Environment.NewLine;

                rchEventLogOutput.Text += "Message : " + CurrentEntry.Message + Environment.NewLine + Environment.NewLine;

            }

            // You could also simply loop through all of the entries in the log using
            // the entries collection and the code below.
            // foreach(entry In ev.Entries
            // Next

       } 
		catch( SecurityException secEx )
			{

            MessageBox.Show("Error reading an event log: this may be due to a lack of appropriate permissions." + Environment.NewLine + secEx.Message,"Lack of Permissions",MessageBoxButtons.OK,MessageBoxIcon.Error);
			} 
		catch( Exception ex )
			{

            MessageBox.Show("Error accessing logs on the local machine." + Environment.NewLine + ex.Message,"Error accessing logs.",MessageBoxButtons.OK,MessageBoxIcon.Error);
			
		}

    }

    private void lstEntryType_SelectedIndexChanged(object sender, System.EventArgs e)
	{

        // Store the log that the user selected in the ListBox
        logType = (string) lstEntryType.Items[lstEntryType.SelectedIndex];
    }

    private void frmRead_Load(object sender, System.EventArgs e)
	{

        try 
		{

            
            foreach(EventLog CurrentLog in EventLog.GetEventLogs())
			{
                lstEntryType.Items.Add(CurrentLog.LogDisplayName);
            }

            lstEntryType.SelectedIndex = 0;

       } 
		catch(SecurityException secEx )
		{
            MessageBox.Show("Error reading an event log: this may be due to a lack of appropriate permissions." + Environment.NewLine + secEx.Message,"Lack of Permissions",MessageBoxButtons.OK,MessageBoxIcon.Error);

		} 
		catch(Exception ex )
		{

            MessageBox.Show("Error accessing logs on the local machine." + Environment.NewLine + ex.Message,"Error accessing logs.",MessageBoxButtons.OK,MessageBoxIcon.Error);

        }

    }

}

