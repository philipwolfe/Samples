using System;
using System.Windows.Forms;

public class frmStatus : System.Windows.Forms.Form {

#region " Windows Form Designer generated code "

    public frmStatus() 
	{
       //This call is required by the Windows Form Designer.
        InitializeComponent();
        //Add any initialization after the InitializeComponent() call
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
    private System.Windows.Forms.Label lblStatus;

    private void InitializeComponent() 
	{
        this.lblStatus = new System.Windows.Forms.Label();
        this.SuspendLayout();

        //
        //lblStatus
        //

        this.lblStatus.Dock = System.Windows.Forms.DockStyle.Fill;
        this.lblStatus.Name = "lblStatus";
        this.lblStatus.Size = new System.Drawing.Size(192, 77);
        this.lblStatus.TabIndex = 0;
        this.lblStatus.Text = "Label1";
        this.lblStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;

        //
        //frmStatus
        //

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
        this.ClientSize = new System.Drawing.Size(192, 77);
        this.ControlBox = false;
        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblStatus});
        this.MaximizeBox = false;
        this.MinimizeBox = false;
        this.Name = "frmStatus";
        this.ShowInTaskbar = false;
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Status";
        this.ResumeLayout(false);
    }

#endregion

    public void Show(string Message)
	{
        lblStatus.Text = Message;
        this.Show();
        Application.DoEvents();
    }

}

