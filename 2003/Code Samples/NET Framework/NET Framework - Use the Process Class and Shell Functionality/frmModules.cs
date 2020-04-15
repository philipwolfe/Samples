using System;
using System.Windows.Forms;
using System.Text;
using System.Diagnostics;

public class frmModules: System.Windows.Forms.Form {

    private int _processID;

#region " Windows Form Designer generated code "

    public frmModules() {

        

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

    private System.Windows.Forms.RichTextBox rchText;

    private void InitializeComponent() {

        this.rchText = new System.Windows.Forms.RichTextBox();

        this.SuspendLayout();

        //

        //rchText

        //

        this.rchText.Anchor = (((System.Windows.Forms.AnchorStyles.Top 
					| System.Windows.Forms.AnchorStyles.Bottom) 
                    | System.Windows.Forms.AnchorStyles.Left) 
                    | System.Windows.Forms.AnchorStyles.Right);

        this.rchText.Location = new System.Drawing.Point(16, 16);

        this.rchText.Name = "rchText";

        this.rchText.Size = new System.Drawing.Size(264, 232);

        this.rchText.TabIndex = 0;

        this.rchText.Text = string.Empty;

        //

        //frmModules

        //

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

        this.ClientSize = new System.Drawing.Size(292, 266);

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.rchText});

        this.Name = "frmModules";

        this.Text = "Loaded Modules:";

        this.ResumeLayout(false);

		this.Load +=new EventHandler(frmModules_Load);

    }

#endregion

    public int ProcessID
	{

        get {

            return (_processID);

        }

        set
{

            _processID = value;

        }

    }

    private void frmModules_Load(object sender, System.EventArgs e)
	{

        // Takes the string of modules built up by the btnModules_Click event procedure in 

        // frmTaskManager and displays into the user in the RichTextBox

        Process ProcessInfo = Process.GetProcessById(ProcessID);

        ProcessModuleCollection modl = ProcessInfo.Modules;

        StringBuilder strMod = new StringBuilder();

		foreach(ProcessModule proMod in modl)
		{
			strMod.Append("Module Name: " + proMod.ModuleName + Environment.NewLine);

		}

        rchText.Text = strMod.ToString();

    }

}

