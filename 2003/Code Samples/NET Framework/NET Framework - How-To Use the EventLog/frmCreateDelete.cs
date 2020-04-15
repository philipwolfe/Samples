using System;
using System.Windows.Forms;
using System.Diagnostics;

public class frmCreateDelete:System.Windows.Forms.Form 
{

#region " Windows Form Designer generated code "

    public frmCreateDelete() 
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

    private System.Windows.Forms.Label lblLogFileToDelete;

    private System.Windows.Forms.Label lblLogFileToCreate;

    private System.Windows.Forms.TextBox txtLogNameToDelete;

    private System.Windows.Forms.TextBox txtLogNameToCreate;

    private System.Windows.Forms.Button btnDeleteLog;

    private System.Windows.Forms.Button btnCreateLog;

    private void InitializeComponent() 
	{
        this.lblLogFileToDelete = new System.Windows.Forms.Label();

        this.lblLogFileToCreate = new System.Windows.Forms.Label();

        this.txtLogNameToDelete = new System.Windows.Forms.TextBox();

        this.txtLogNameToCreate = new System.Windows.Forms.TextBox();

        this.btnDeleteLog = new System.Windows.Forms.Button();

        this.btnCreateLog = new System.Windows.Forms.Button();

        this.SuspendLayout();

        //

        //lblLogFileToDelete

        //

        this.lblLogFileToDelete.AccessibleDescription = "Name of log to delete label";

        this.lblLogFileToDelete.AccessibleName = "Delete Log Label";

        this.lblLogFileToDelete.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblLogFileToDelete.Location = new System.Drawing.Point(240, 32);

        this.lblLogFileToDelete.Name = "lblLogFileToDelete";

        this.lblLogFileToDelete.Size = new System.Drawing.Size(168, 23);

        this.lblLogFileToDelete.TabIndex = 4;

        this.lblLogFileToDelete.Text = "Name of Log to D&elete:";

        //

        //lblLogFileToCreate

        //

        this.lblLogFileToCreate.AccessibleDescription = "Name of log to create label";

        this.lblLogFileToCreate.AccessibleName = "Create Log Label";

        this.lblLogFileToCreate.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblLogFileToCreate.Location = new System.Drawing.Point(32, 32);

        this.lblLogFileToCreate.Name = "lblLogFileToCreate";

        this.lblLogFileToCreate.Size = new System.Drawing.Size(160, 23);

        this.lblLogFileToCreate.TabIndex = 1;

        this.lblLogFileToCreate.Text = "Name of Log to C&reate:";

        //

        //txtLogNameToDelete

        //

        this.txtLogNameToDelete.AccessibleDescription = "Name of log to delete";

        this.txtLogNameToDelete.AccessibleName = "Delete Log Name";

        this.txtLogNameToDelete.Location = new System.Drawing.Point(240, 56);

        this.txtLogNameToDelete.Name = "txtLogNameToDelete";

        this.txtLogNameToDelete.Size = new System.Drawing.Size(176, 20);

        this.txtLogNameToDelete.TabIndex = 5;

        this.txtLogNameToDelete.Text = "";

        //

        //txtLogNameToCreate

        //

        this.txtLogNameToCreate.AccessibleDescription = "Name of Log to Create";

        this.txtLogNameToCreate.AccessibleName = "Create Log Name";

        this.txtLogNameToCreate.Location = new System.Drawing.Point(32, 56);

        this.txtLogNameToCreate.Name = "txtLogNameToCreate";

        this.txtLogNameToCreate.Size = new System.Drawing.Size(168, 20);

        this.txtLogNameToCreate.TabIndex = 2;

        this.txtLogNameToCreate.Text = "";

        //

        //btnDeleteLog

        //

        this.btnDeleteLog.AccessibleDescription = "Click to delete the log";

        this.btnDeleteLog.AccessibleName = "Delete Log Button";

        this.btnDeleteLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnDeleteLog.Location = new System.Drawing.Point(240, 96);

        this.btnDeleteLog.Name = "btnDeleteLog";

        this.btnDeleteLog.Size = new System.Drawing.Size(176, 23);

        this.btnDeleteLog.TabIndex = 6;

        this.btnDeleteLog.Text = "&Delete an Event Log";
		this.btnDeleteLog.Click +=new EventHandler(cmdDeleteLog_Click);

        //

        //btnCreateLog

        //

        this.btnCreateLog.AccessibleDescription = "Click to create the log";

        this.btnCreateLog.AccessibleName = "Create Log Button";

        this.btnCreateLog.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnCreateLog.Location = new System.Drawing.Point(32, 96);

        this.btnCreateLog.Name = "btnCreateLog";

        this.btnCreateLog.Size = new System.Drawing.Size(168, 23);

        this.btnCreateLog.TabIndex = 3;

        this.btnCreateLog.Text = "&Create an Event Log";
		this.btnCreateLog.Click +=new EventHandler(cmdCreateLog_Click);
        //

        //frmCreateDelete

        //

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

        this.ClientSize = new System.Drawing.Size(448, 158);

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblLogFileToDelete, this.lblLogFileToCreate, this.txtLogNameToDelete, this.txtLogNameToCreate, this.btnDeleteLog, this.btnCreateLog});

        this.Name = "frmCreateDelete";

        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

        this.Text = "Create and Delete a Custom Log";

        this.ResumeLayout(false);

    }

#endregion

    private void cmdCreateLog_Click(object sender, System.EventArgs e)
	{
        EventLog ev = new EventLog();

		try 
		{

			//Next check for the existence of the log that the user wants to create.

			if (! EventLog.Exists(txtLogNameToCreate.Text)) 
			{
				// if the event source is already registered we want to delete it 
				// before recreating it on the call to CreateEventSource

				if (EventLog.SourceExists("How-To Use the EventLog"))
				{
					EventLog.DeleteEventSource("How-To Use the EventLog");

				}

				EventLog.CreateEventSource("How-To Use the EventLog", txtLogNameToCreate.Text);
			}
			else 
			{

				MessageBox.Show("Log :" + txtLogNameToCreate.Text + " already exists.","Log Exists",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

			}

		} 
		catch( Exception ex )
		{
			MessageBox.Show("Unable to Create Event Log, the message was: " + ex.Message + " This may be due to a lack of appropriate permissions.","An Exception was thrown",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		}
		finally
		{
			//Close the log.

			ev.Close();
		}

        //You can also create an event log using the code below.
        //Once you create an event log object that is passed your custom log name the 
        //first time you write an entry to the log the log is created.  One benefit of this
        //approach is that the need for the existence check is not necessary.
        //if the log exists the code will write to the log and if a log by that name 
        //does not exist the log is created automatically prior to the write. 
        //The downside of this approach is that it is not clear that the log will 
        //will be created if necessary in the above code.
        //ev2 new EventLog(txtLogNameToCreate.Text, System.Environment.MachineName, _
        //"How-To Use the EventLog")
        //ev2.WriteEntry("test message")
        //ev2.Close()

    }

    private void cmdDeleteLog_Click(object sender, System.EventArgs e) 
	{
        System.Diagnostics.EventLog ev =new System.Diagnostics.EventLog();

		try 
		{

			if (EventLog.Exists(txtLogNameToDelete.Text))
			{

				//Next call the delete method of the log that the user wants to delete.

				EventLog.Delete(txtLogNameToDelete.Text);
			}
			else 
			{

				MessageBox.Show("Log " + txtLogNameToDelete.Text + " does not exist, therefore it can! be deleted.","Log Does not Exist",MessageBoxButtons.OK,MessageBoxIcon.Error);
			}

		} 
		catch( Exception ex )
		{
			MessageBox.Show("Unable to delete event log, the message was: " + ex.Message + " this may be due to a lack of appropriate permissions.","An Exception was thrown",MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
		}
		finally
		{
			ev.Close();
		}

    }

}

