using System;
using System.Windows.Forms;
using System.Collections;
using System.Diagnostics;

public class frmTaskManager: System.Windows.Forms.Form {

	

#region " Windows Form Designer generated code "

    public frmTaskManager() {

        //This call is required by the Windows Form Designer.

        InitializeComponent();

        //Add any initialization after the InitializeComponent() call

    }

    //Form overrides dispose to clean up the component list.

    protected override void Dispose(bool disposing) {

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
    private System.Windows.Forms.Button btnModules;
    private System.Windows.Forms.TextBox txtTotalProcessorTime;
    private System.Windows.Forms.TextBox txtStartTime;
    private System.Windows.Forms.TextBox txtMinWorkingSet;
    private System.Windows.Forms.TextBox txtMaxWorkingSet;
    private System.Windows.Forms.TextBox txtNumberOfThreads;
    private System.Windows.Forms.TextBox txtPriority;
    private System.Windows.Forms.Label label7;
    private System.Windows.Forms.Label label6;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.ComboBox cboCurrentProcesses;

    private void InitializeComponent() {

        this.btnModules = new System.Windows.Forms.Button();

        this.txtTotalProcessorTime = new System.Windows.Forms.TextBox();

        this.txtStartTime = new System.Windows.Forms.TextBox();

        this.txtMinWorkingSet = new System.Windows.Forms.TextBox();

        this.txtMaxWorkingSet = new System.Windows.Forms.TextBox();

        this.txtNumberOfThreads = new System.Windows.Forms.TextBox();

        this.txtPriority = new System.Windows.Forms.TextBox();

        this.label7 = new System.Windows.Forms.Label();

        this.label6 = new System.Windows.Forms.Label();

        this.label5 = new System.Windows.Forms.Label();

        this.label4 = new System.Windows.Forms.Label();

        this.label3 = new System.Windows.Forms.Label();

        this.label2 = new System.Windows.Forms.Label();

        this.label1 = new System.Windows.Forms.Label();

        this.cboCurrentProcesses = new System.Windows.Forms.ComboBox();

        this.SuspendLayout();

        //

        //btnModules

        //

        this.btnModules.Location = new System.Drawing.Point(224, 272);

        this.btnModules.Name = "btnModules";

        this.btnModules.TabIndex = 14;

        this.btnModules.Text = "Modules";

        //

        //txtTotalProcessorTime

        //

        this.txtTotalProcessorTime.Location = new System.Drawing.Point(120, 224);

        this.txtTotalProcessorTime.Name = "txtTotalProcessorTime";

        this.txtTotalProcessorTime.Size = new System.Drawing.Size(184, 20);

        this.txtTotalProcessorTime.TabIndex = 13;

        this.txtTotalProcessorTime.Text = string.Empty;

        this.txtTotalProcessorTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

        //

        //txtStartTime

        //

        this.txtStartTime.Location = new System.Drawing.Point(120, 192);

        this.txtStartTime.Name = "txtStartTime";

        this.txtStartTime.Size = new System.Drawing.Size(184, 20);

        this.txtStartTime.TabIndex = 11;

        this.txtStartTime.Text = string.Empty;

        this.txtStartTime.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

        //

        //txtMinWorkingSet

        //

        this.txtMinWorkingSet.Location = new System.Drawing.Point(120, 160);

        this.txtMinWorkingSet.Name = "txtMinWorkingSet";

        this.txtMinWorkingSet.Size = new System.Drawing.Size(184, 20);

        this.txtMinWorkingSet.TabIndex = 9;

        this.txtMinWorkingSet.Text = string.Empty;

        this.txtMinWorkingSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

        //

        //txtMaxWorkingSet

        //

        this.txtMaxWorkingSet.Location = new System.Drawing.Point(120, 128);

        this.txtMaxWorkingSet.Name = "txtMaxWorkingSet";

        this.txtMaxWorkingSet.Size = new System.Drawing.Size(184, 20);

        this.txtMaxWorkingSet.TabIndex = 7;

        this.txtMaxWorkingSet.Text = string.Empty;

        this.txtMaxWorkingSet.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

        //

        //txtNumberOfThreads

        //

        this.txtNumberOfThreads.Location = new System.Drawing.Point(120, 96);

        this.txtNumberOfThreads.Name = "txtNumberOfThreads";

        this.txtNumberOfThreads.Size = new System.Drawing.Size(184, 20);

        this.txtNumberOfThreads.TabIndex = 5;

        this.txtNumberOfThreads.Text = string.Empty;

        this.txtNumberOfThreads.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

        //

        //txtPriority

        //

        this.txtPriority.Location = new System.Drawing.Point(120, 64);

        this.txtPriority.Name = "txtPriority";

        this.txtPriority.Size = new System.Drawing.Size(184, 20);

        this.txtPriority.TabIndex = 3;

        this.txtPriority.Text = string.Empty;

        this.txtPriority.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;

        //

        //label7

        //

        this.label7.Location = new System.Drawing.Point(8, 224);

        this.label7.Name = "label7";

        this.label7.Size = new System.Drawing.Size(104, 32);

        this.label7.TabIndex = 12;

        this.label7.Text = "Total Processor Time";

        //

        //label6

        //

        this.label6.Location = new System.Drawing.Point(8, 192);

        this.label6.Name = "label6";

        this.label6.TabIndex = 10;

        this.label6.Text = "Start Time";

        //

        //label5

        //

        this.label5.Location = new System.Drawing.Point(8, 160);

        this.label5.Name = "label5";

        this.label5.TabIndex = 8;

        this.label5.Text = "Min Working Set";

        //

        //label4

        //

        this.label4.Location = new System.Drawing.Point(8, 128);

        this.label4.Name = "label4";

        this.label4.TabIndex = 6;

        this.label4.Text = "Max Working Set";

        //

        //label3

        //

        this.label3.Location = new System.Drawing.Point(8, 96);

        this.label3.Name = "label3";

        this.label3.Size = new System.Drawing.Size(104, 23);

        this.label3.TabIndex = 4;

        this.label3.Text = "Number of Threads";

        //

        //label2

        //

        this.label2.Location = new System.Drawing.Point(8, 64);

        this.label2.Name = "label2";

        this.label2.TabIndex = 2;

        this.label2.Text = "Priority";

        //

        //label1

        //

        this.label1.Location = new System.Drawing.Point(8, 16);

        this.label1.Name = "label1";

        this.label1.Size = new System.Drawing.Size(104, 23);

        this.label1.TabIndex = 0;

        this.label1.Text = "Current Processes:";

        //

        //cboCurrentProcesses

        //

        this.cboCurrentProcesses.Location = new System.Drawing.Point(120, 16);

        this.cboCurrentProcesses.Name = "cboCurrentProcesses";

        this.cboCurrentProcesses.Size = new System.Drawing.Size(192, 21);

        this.cboCurrentProcesses.TabIndex = 1;

        //

        //frmTaskManager

        //

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

        this.ClientSize = new System.Drawing.Size(312, 318);

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnModules, this.txtTotalProcessorTime, this.txtStartTime, this.txtMinWorkingSet, this.txtMaxWorkingSet, this.txtNumberOfThreads, this.txtPriority, this.label7, this.label6, this.label5, this.label4, this.label3, this.label2, this.label1, this.cboCurrentProcesses});

        this.Name = "frmTaskManager";

        this.Text = "Simple Process Manager";

        this.ResumeLayout(false);

		this.Load +=new EventHandler(frmTaskManager_Load);
		this.btnModules.Click +=new EventHandler(btnModules_Click);
		this.cboCurrentProcesses.SelectedIndexChanged +=new EventHandler(cboCurrentProcesses_SelectedIndexChanged);

    }

#endregion

    // List of processes currently running

    ArrayList ProcessList = new ArrayList();

    private void btnModules_Click(object sender, System.EventArgs e) 
	{
        // Get the item that is currently selected in the combo box.  { all of the modules
        // for that process are displayed to the user via the richTextBox on frmModules.

        int ProcID;
        Int32 ProcessListIndex = cboCurrentProcesses.SelectedIndex;
        ProcID = Convert.ToInt32(ProcessList[ProcessListIndex]);
        frmModules frmMod = new frmModules();
        frmMod.ProcessID = ProcID;
        frmMod.Show();
    }

    private void frmTaskManager_Load(object sender, System.EventArgs e) 
	{

        try {

            // Loop through all the running process, and add them to the combo
            // box so that the user can select a process and see the information
            // for that process.

            foreach(Process ProcessInfo in Process.GetProcesses())
			{
                //Devenv is the Visual Studio Development Environment.  You will see one entry 
                //for each instance of the development environment that you have open.

                if ((ProcessInfo.ProcessName.ToLower() == "explorer") || 
					(ProcessInfo.ProcessName.ToLower() == "devenv")) 
				{
                    cboCurrentProcesses.Items.Add(ProcessInfo.ProcessName);
                    ProcessList.Add(ProcessInfo.Id);
                }

            }

            cboCurrentProcesses.SelectedIndex = 0;

            if (btnModules.Enabled == false) {

                btnModules.Enabled = true;

            }

       } catch(Exception exc)
		{

            MessageBox.Show("Unable to load process names:" + 
				Environment.NewLine + exc.Message + Environment.NewLine + 
				"Please choose another process.", 
                "frmTaskManager", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error);

            btnModules.Enabled = false;

        }

    }

    private void cboCurrentProcesses_SelectedIndexChanged(object sender, System.EventArgs e) 
	{
        Int32 ProcessID=0;

        try {

            // Retrieve the information for the process based on the item that the
            // user has selected in the combo box.

            Int32 ProcessListIndex = cboCurrentProcesses.SelectedIndex;
            ProcessID = Convert.ToInt32(ProcessList[ProcessListIndex]);
            Process ProcessInfo = Process.GetProcessById(ProcessID);

            //Information is displayed about the currently selected process.
            txtPriority.Text = ProcessInfo.BasePriority.ToString();
            txtNumberOfThreads.Text = ProcessInfo.Threads.Count.ToString();
            txtMaxWorkingSet.Text = ProcessInfo.MaxWorkingSet.ToString();
            txtMinWorkingSet.Text = ProcessInfo.MinWorkingSet.ToString();
            txtStartTime.Text = ProcessInfo.StartTime.ToLongTimeString();
            txtTotalProcessorTime.Text = ProcessInfo.TotalProcessorTime.ToString();

       } catch( Exception exc)
		{
            MessageBox.Show( 
                "Unable to retrieve information for ProcessID : " + ProcessID + Environment.NewLine + exc.Message, 
                "frmTaskManager", 
                MessageBoxButtons.OK, 
                MessageBoxIcon.Error);
        }

    }

}

