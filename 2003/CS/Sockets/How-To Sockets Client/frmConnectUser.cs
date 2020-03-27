using System;
using System.Windows.Forms;

public class frmConnectUser : System.Windows.Forms.Form 
{

#region " Windows Form Designer generated code "

    public frmConnectUser() 
	{
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
    private System.Windows.Forms.Button btnLogin;
	public System.Windows.Forms.TextBox txtUserLogin;

    private System.Windows.Forms.Label lblInstructions;

    private void InitializeComponent() {
		this.btnLogin = new System.Windows.Forms.Button();
		this.txtUserLogin = new System.Windows.Forms.TextBox();
		this.lblInstructions = new System.Windows.Forms.Label();
		this.SuspendLayout();
		// 
		// btnLogin
		// 
		this.btnLogin.DialogResult = System.Windows.Forms.DialogResult.Cancel;
		this.btnLogin.Location = new System.Drawing.Point(68, 137);
		this.btnLogin.Name = "btnLogin";
		this.btnLogin.Size = new System.Drawing.Size(129, 42);
		this.btnLogin.TabIndex = 0;
		this.btnLogin.Text = "&Login";
		// 
		// txtUserLogin
		// 
		this.txtUserLogin.Location = new System.Drawing.Point(17, 94);
		this.txtUserLogin.Name = "txtUserLogin";
		this.txtUserLogin.Size = new System.Drawing.Size(239, 20);
		this.txtUserLogin.TabIndex = 1;
		this.txtUserLogin.Text = "";
		// 
		// lblInstructions
		// 
		this.lblInstructions.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.lblInstructions.ForeColor = System.Drawing.Color.FromArgb(((System.Byte)(0)), ((System.Byte)(0)), ((System.Byte)(192)));
		this.lblInstructions.Location = new System.Drawing.Point(17, 17);
		this.lblInstructions.Name = "lblInstructions";
		this.lblInstructions.Size = new System.Drawing.Size(256, 69);
		this.lblInstructions.TabIndex = 2;
		this.lblInstructions.Text = "Please enter a unique name to log into the chat utility.  if login name already e" +
			"xists you will be returned to this dialog to attempt another name.";
		// 
		// frmConnectUser
		// 
		this.AcceptButton = this.btnLogin;
		this.AccessibleDescription = "Connect User Form";
		this.AccessibleName = "Connect User Form";
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.CancelButton = this.btnLogin;
		this.ClientSize = new System.Drawing.Size(289, 193);
		this.Controls.Add(this.lblInstructions);
		this.Controls.Add(this.txtUserLogin);
		this.Controls.Add(this.btnLogin);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmConnectUser";
		this.Text = "Connect User";
		this.ResumeLayout(false);

	}

#endregion

}

