using System;
using System.Windows.Forms;
using System.Security;
using System.Diagnostics;

public class frmWrite:System.Windows.Forms.Form 
{

    private System.Diagnostics.EventLogEntryType entryType = EventLogEntryType.Information;

#region " Windows Form Designer generated code "

    public frmWrite() 
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

    private System.Windows.Forms.Label lblEventID;

    private System.Windows.Forms.TextBox txtEventID;

    private System.Windows.Forms.Button btnWriteEntry;

    private System.Windows.Forms.GroupBox groEventEntry;

    private System.Windows.Forms.RadioButton rdoError;

    private System.Windows.Forms.RadioButton rdoWarning;

    private System.Windows.Forms.RadioButton rdoInfo;

    private System.Windows.Forms.TextBox txtEntry;

    private System.Windows.Forms.Label lblEntryText;

    private void InitializeComponent() 
	{

        this.lblEventID = new System.Windows.Forms.Label();

        this.txtEventID = new System.Windows.Forms.TextBox();

        this.btnWriteEntry = new System.Windows.Forms.Button();

        this.groEventEntry = new System.Windows.Forms.GroupBox();

        this.rdoError = new System.Windows.Forms.RadioButton();

        this.rdoWarning = new System.Windows.Forms.RadioButton();

        this.rdoInfo = new System.Windows.Forms.RadioButton();

        this.txtEntry = new System.Windows.Forms.TextBox();

        this.lblEntryText = new System.Windows.Forms.Label();

        this.groEventEntry.SuspendLayout();

        this.SuspendLayout();

        //

        //lblEventID

        //

        this.lblEventID.AccessibleDescription = "Label for Event ID";

        this.lblEventID.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblEventID.Location = new System.Drawing.Point(16, 80);

        this.lblEventID.Name = "lblEventID";

        this.lblEventID.Size = new System.Drawing.Size(176, 16);

        this.lblEventID.TabIndex = 3;

        this.lblEventID.Text = "E&vent ID:";

        //

        //txtEventID

        //

        this.txtEventID.AccessibleDescription = "Type the event ID";

        this.txtEventID.AccessibleName = "Event ID";

        this.txtEventID.Location = new System.Drawing.Point(16, 96);

        this.txtEventID.Name = "txtEventID";

        this.txtEventID.Size = new System.Drawing.Size(176, 20);

        this.txtEventID.TabIndex = 4;

        this.txtEventID.Text = "";

        //

        //btnWriteEntry

        //

        this.btnWriteEntry.AccessibleDescription = "Click to write the entery to the application event log";

        this.btnWriteEntry.AccessibleName = "Write Button";

        this.btnWriteEntry.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnWriteEntry.Location = new System.Drawing.Point(168, 152);

        this.btnWriteEntry.Name = "btnWriteEntry";

        this.btnWriteEntry.Size = new System.Drawing.Size(232, 23);

        this.btnWriteEntry.TabIndex = 6;

        this.btnWriteEntry.Text = "&Write an Entry to the Application Event Log";
		this.btnWriteEntry.Click +=new EventHandler(cmdWriteEntry_Click);

        //

        //groEventEntry

        //

        this.groEventEntry.AccessibleDescription = "Event Log Entry type option box";

        this.groEventEntry.AccessibleName = "Log type Option Box";

        this.groEventEntry.Controls.AddRange(new System.Windows.Forms.Control[] {this.rdoError, this.rdoWarning, this.rdoInfo});

        this.groEventEntry.Location = new System.Drawing.Point(224, 16);

        this.groEventEntry.Name = "groEventEntry";

        this.groEventEntry.Size = new System.Drawing.Size(176, 120);

        this.groEventEntry.TabIndex = 5;

        this.groEventEntry.TabStop = false;

        this.groEventEntry.Text = "Eve&nt Log Entry Type:";

        //

        //rdoError

        //

        this.rdoError.AccessibleDescription = "Error event option";

        this.rdoError.AccessibleName = "Error Event Option";

        this.rdoError.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.rdoError.Location = new System.Drawing.Point(16, 88);

        this.rdoError.Name = "rdoError";

        this.rdoError.Size = new System.Drawing.Size(152, 24);

        this.rdoError.TabIndex = 2;

        this.rdoError.Text = "E&rror";
		this.rdoError.Click +=new EventHandler(rdo_Click);

        //

        //rdoWarning

        //

        this.rdoWarning.AccessibleDescription = "Warning event option";

        this.rdoWarning.AccessibleName = "Warning Event Option";

        this.rdoWarning.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.rdoWarning.Location = new System.Drawing.Point(16, 56);

        this.rdoWarning.Name = "rdoWarning";

        this.rdoWarning.Size = new System.Drawing.Size(152, 24);

        this.rdoWarning.TabIndex = 1;

        this.rdoWarning.Text = "W&arning";
		this.rdoWarning.Click +=new EventHandler(rdo_Click);

        //

        //rdoInfo

        //

        this.rdoInfo.AccessibleDescription = "Informational event option";

        this.rdoInfo.AccessibleName = "Informational Event Option";

        this.rdoInfo.Checked = true;

        this.rdoInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.rdoInfo.Location = new System.Drawing.Point(16, 24);

        this.rdoInfo.Name = "rdoInfo";

        this.rdoInfo.Size = new System.Drawing.Size(152, 24);

        this.rdoInfo.TabIndex = 0;

        this.rdoInfo.TabStop = true;

        this.rdoInfo.Text = "&Informational";
		this.rdoInfo.Click +=new EventHandler(rdo_Click);

        //

        //txtEntry

        //

        this.txtEntry.AccessibleDescription = "Type the Entry Text";

        this.txtEntry.AccessibleName = "Entry Text";

        this.txtEntry.Location = new System.Drawing.Point(16, 32);

        this.txtEntry.Name = "txtEntry";

        this.txtEntry.Size = new System.Drawing.Size(176, 20);

        this.txtEntry.TabIndex = 2;

        this.txtEntry.Text = "";

        //

        //lblEntryText

        //

        this.lblEntryText.AccessibleDescription = "Label for Entry Text";

        this.lblEntryText.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblEntryText.Location = new System.Drawing.Point(16, 16);

        this.lblEntryText.Name = "lblEntryText";

        this.lblEntryText.Size = new System.Drawing.Size(176, 23);

        this.lblEntryText.TabIndex = 1;

        this.lblEntryText.Text = "&Entry Text:";

        //

        //frmWrite

        //

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

        this.ClientSize = new System.Drawing.Size(432, 198);

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblEventID, this.txtEventID, this.btnWriteEntry, this.groEventEntry, this.txtEntry, this.lblEntryText});

        this.Name = "frmWrite";

        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

        this.Text = "Write to the Event Log";

        this.groEventEntry.ResumeLayout(false);

        this.ResumeLayout(false);

    }

#endregion
	public bool IsNumeric(string val)
	{
		try
		{
			double result = 0;
			return Double.TryParse(val, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.CurrentInfo, out result);
		}
		catch
		{
			return false;
		}
	}
    private void cmdWriteEntry_Click(object sender, System.EventArgs e)
	{
    

		try 
		{

			if (IsNumeric(txtEventID.Text)) 
			{

				// When writing to an event log you need to pass the machine name where 
				// the log resides.  Here the MachineName DATA_TYPE_HERE of the Environment class 
				// is used to determine the name of the local machine.  Assuming you have 
				// the appropriate permissions it is also easy to write to event logs on 
				// other machines.
				// The first entry is the name of the log you want to write to.  The second 
				// parameter is the machine name.  In this case it is the local machine name.
				// The third parameter is the source of the event.  Commonly this is set equal
				// to the name of the application that is writing the event.

				EventLog ev = new EventLog("Application", System.Environment.MachineName,"How-To Use the Event Log");

				// The first argument to WriteEntry is the text of the message.  The second 
				// argument is the type of entry you want to create (Warning, Information, etc.)
				// The third is the eventID of the event.  The user could use this to look up 
				// further information in a help file.

				ev.WriteEntry(txtEntry.Text, entryType, Convert.ToInt32(txtEventID.Text));

				ev.Close();

				MessageBox.Show("Entry written to the event log","frmWrite",MessageBoxButtons.OK,MessageBoxIcon.Information);
			}
			else 
			{

				// The EventID was not numeric

				MessageBox.Show("Value entered into EventID textbox must be numeric","Event ID Entry Error",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

			}
		}

		catch(SecurityException secEx)
		{

			MessageBox.Show("Error writing to the event log: this may be due to a lack of appropriate permissions." + Environment.NewLine + secEx.Message,"Lack of Permissions",MessageBoxButtons.OK,MessageBoxIcon.Error);

		} 
		catch(Exception ex )
		{
			MessageBox.Show("Error accessing logs on the local machine." + Environment.NewLine + ex.Message,"Error accessing logs.",MessageBoxButtons.OK,MessageBoxIcon.Error);

		}

    }

    private void rdo_Click(object sender, System.EventArgs e)
	{

        // This event procedure handles the click event for all the radio buttons in 
        // the group box on the form.  In the event handler, we know which radio 
        // button was clicked because it is passed in the "sender" argument.
        // This comes in a generic object, however, and must be cast back to a
        // radio button so that you can access the name property.

        RadioButton rdo  = (RadioButton) sender;

        switch(rdo.Name)
		{

            case "rdoError":

                entryType = EventLogEntryType.Error;
				break;

            case "rdoWarning":

                entryType = EventLogEntryType.Warning;
				break;
            case "rdoInfo":

                entryType = EventLogEntryType.Information;
				break;
            default: 

                //if a radio button is not clicked an assertion is raised.
                Debug.Assert(false, "User selected an event log type that is not currently handled");
				break;
        }

    }

}

