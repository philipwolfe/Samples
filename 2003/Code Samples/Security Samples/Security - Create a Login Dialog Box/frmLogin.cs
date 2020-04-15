using System;
using System.Windows.Forms;
using System.Threading;
using System.Security.Principal;

public class frmLogin: System.Windows.Forms.Form {

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmLogin());
	}


#region " Windows Form Designer generated code "

    public frmLogin() 
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
    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.TextBox txtUserName;
    private System.Windows.Forms.TextBox txtPassword;
    private System.Windows.Forms.Button btnCancel;
    private System.Windows.Forms.CheckBox chkAdministratorAccount;
    private System.Windows.Forms.Button btnOK;

    private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmLogin));
		this.Label1 = new System.Windows.Forms.Label();
		this.Label2 = new System.Windows.Forms.Label();
		this.txtUserName = new System.Windows.Forms.TextBox();
		this.txtPassword = new System.Windows.Forms.TextBox();
		this.btnOK = new System.Windows.Forms.Button();
		this.btnCancel = new System.Windows.Forms.Button();
		this.chkAdministratorAccount = new System.Windows.Forms.CheckBox();
		this.SuspendLayout();
		// 
		// Label1
		// 
		this.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription");
		this.Label1.AccessibleName = resources.GetString("Label1.AccessibleName");
		this.Label1.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label1.Anchor")));
		this.Label1.AutoSize = ((bool)(resources.GetObject("Label1.AutoSize")));
		this.Label1.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label1.Dock")));
		this.Label1.Enabled = ((bool)(resources.GetObject("Label1.Enabled")));
		this.Label1.Font = ((System.Drawing.Font)(resources.GetObject("Label1.Font")));
		this.Label1.Image = ((System.Drawing.Image)(resources.GetObject("Label1.Image")));
		this.Label1.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label1.ImageAlign")));
		this.Label1.ImageIndex = ((int)(resources.GetObject("Label1.ImageIndex")));
		this.Label1.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label1.ImeMode")));
		this.Label1.Location = ((System.Drawing.Point)(resources.GetObject("Label1.Location")));
		this.Label1.Name = "Label1";
		this.Label1.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label1.RightToLeft")));
		this.Label1.Size = ((System.Drawing.Size)(resources.GetObject("Label1.Size")));
		this.Label1.TabIndex = ((int)(resources.GetObject("Label1.TabIndex")));
		this.Label1.Text = resources.GetString("Label1.Text");
		this.Label1.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label1.TextAlign")));
		this.Label1.Visible = ((bool)(resources.GetObject("Label1.Visible")));
		// 
		// Label2
		// 
		this.Label2.AccessibleDescription = resources.GetString("Label2.AccessibleDescription");
		this.Label2.AccessibleName = resources.GetString("Label2.AccessibleName");
		this.Label2.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("Label2.Anchor")));
		this.Label2.AutoSize = ((bool)(resources.GetObject("Label2.AutoSize")));
		this.Label2.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("Label2.Dock")));
		this.Label2.Enabled = ((bool)(resources.GetObject("Label2.Enabled")));
		this.Label2.Font = ((System.Drawing.Font)(resources.GetObject("Label2.Font")));
		this.Label2.Image = ((System.Drawing.Image)(resources.GetObject("Label2.Image")));
		this.Label2.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label2.ImageAlign")));
		this.Label2.ImageIndex = ((int)(resources.GetObject("Label2.ImageIndex")));
		this.Label2.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("Label2.ImeMode")));
		this.Label2.Location = ((System.Drawing.Point)(resources.GetObject("Label2.Location")));
		this.Label2.Name = "Label2";
		this.Label2.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("Label2.RightToLeft")));
		this.Label2.Size = ((System.Drawing.Size)(resources.GetObject("Label2.Size")));
		this.Label2.TabIndex = ((int)(resources.GetObject("Label2.TabIndex")));
		this.Label2.Text = resources.GetString("Label2.Text");
		this.Label2.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("Label2.TextAlign")));
		this.Label2.Visible = ((bool)(resources.GetObject("Label2.Visible")));
		// 
		// txtUserName
		// 
		this.txtUserName.AccessibleDescription = resources.GetString("txtUserName.AccessibleDescription");
		this.txtUserName.AccessibleName = resources.GetString("txtUserName.AccessibleName");
		this.txtUserName.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtUserName.Anchor")));
		this.txtUserName.AutoSize = ((bool)(resources.GetObject("txtUserName.AutoSize")));
		this.txtUserName.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtUserName.BackgroundImage")));
		this.txtUserName.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtUserName.Dock")));
		this.txtUserName.Enabled = ((bool)(resources.GetObject("txtUserName.Enabled")));
		this.txtUserName.Font = ((System.Drawing.Font)(resources.GetObject("txtUserName.Font")));
		this.txtUserName.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtUserName.ImeMode")));
		this.txtUserName.Location = ((System.Drawing.Point)(resources.GetObject("txtUserName.Location")));
		this.txtUserName.MaxLength = ((int)(resources.GetObject("txtUserName.MaxLength")));
		this.txtUserName.Multiline = ((bool)(resources.GetObject("txtUserName.Multiline")));
		this.txtUserName.Name = "txtUserName";
		this.txtUserName.PasswordChar = ((char)(resources.GetObject("txtUserName.PasswordChar")));
		this.txtUserName.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtUserName.RightToLeft")));
		this.txtUserName.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtUserName.ScrollBars")));
		this.txtUserName.Size = ((System.Drawing.Size)(resources.GetObject("txtUserName.Size")));
		this.txtUserName.TabIndex = ((int)(resources.GetObject("txtUserName.TabIndex")));
		this.txtUserName.Text = resources.GetString("txtUserName.Text");
		this.txtUserName.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtUserName.TextAlign")));
		this.txtUserName.Visible = ((bool)(resources.GetObject("txtUserName.Visible")));
		this.txtUserName.WordWrap = ((bool)(resources.GetObject("txtUserName.WordWrap")));
		// 
		// txtPassword
		// 
		this.txtPassword.AccessibleDescription = resources.GetString("txtPassword.AccessibleDescription");
		this.txtPassword.AccessibleName = resources.GetString("txtPassword.AccessibleName");
		this.txtPassword.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("txtPassword.Anchor")));
		this.txtPassword.AutoSize = ((bool)(resources.GetObject("txtPassword.AutoSize")));
		this.txtPassword.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("txtPassword.BackgroundImage")));
		this.txtPassword.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("txtPassword.Dock")));
		this.txtPassword.Enabled = ((bool)(resources.GetObject("txtPassword.Enabled")));
		this.txtPassword.Font = ((System.Drawing.Font)(resources.GetObject("txtPassword.Font")));
		this.txtPassword.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("txtPassword.ImeMode")));
		this.txtPassword.Location = ((System.Drawing.Point)(resources.GetObject("txtPassword.Location")));
		this.txtPassword.MaxLength = ((int)(resources.GetObject("txtPassword.MaxLength")));
		this.txtPassword.Multiline = ((bool)(resources.GetObject("txtPassword.Multiline")));
		this.txtPassword.Name = "txtPassword";
		this.txtPassword.PasswordChar = ((char)(resources.GetObject("txtPassword.PasswordChar")));
		this.txtPassword.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("txtPassword.RightToLeft")));
		this.txtPassword.ScrollBars = ((System.Windows.Forms.ScrollBars)(resources.GetObject("txtPassword.ScrollBars")));
		this.txtPassword.Size = ((System.Drawing.Size)(resources.GetObject("txtPassword.Size")));
		this.txtPassword.TabIndex = ((int)(resources.GetObject("txtPassword.TabIndex")));
		this.txtPassword.Text = resources.GetString("txtPassword.Text");
		this.txtPassword.TextAlign = ((System.Windows.Forms.HorizontalAlignment)(resources.GetObject("txtPassword.TextAlign")));
		this.txtPassword.Visible = ((bool)(resources.GetObject("txtPassword.Visible")));
		this.txtPassword.WordWrap = ((bool)(resources.GetObject("txtPassword.WordWrap")));
		// 
		// btnOK
		// 
		this.btnOK.AccessibleDescription = resources.GetString("btnOK.AccessibleDescription");
		this.btnOK.AccessibleName = resources.GetString("btnOK.AccessibleName");
		this.btnOK.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnOK.Anchor")));
		this.btnOK.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnOK.BackgroundImage")));
		this.btnOK.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnOK.Dock")));
		this.btnOK.Enabled = ((bool)(resources.GetObject("btnOK.Enabled")));
		this.btnOK.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnOK.FlatStyle")));
		this.btnOK.Font = ((System.Drawing.Font)(resources.GetObject("btnOK.Font")));
		this.btnOK.Image = ((System.Drawing.Image)(resources.GetObject("btnOK.Image")));
		this.btnOK.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnOK.ImageAlign")));
		this.btnOK.ImageIndex = ((int)(resources.GetObject("btnOK.ImageIndex")));
		this.btnOK.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnOK.ImeMode")));
		this.btnOK.Location = ((System.Drawing.Point)(resources.GetObject("btnOK.Location")));
		this.btnOK.Name = "btnOK";
		this.btnOK.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnOK.RightToLeft")));
		this.btnOK.Size = ((System.Drawing.Size)(resources.GetObject("btnOK.Size")));
		this.btnOK.TabIndex = ((int)(resources.GetObject("btnOK.TabIndex")));
		this.btnOK.Text = resources.GetString("btnOK.Text");
		this.btnOK.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnOK.TextAlign")));
		this.btnOK.Visible = ((bool)(resources.GetObject("btnOK.Visible")));
		this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
		// 
		// btnCancel
		// 
		this.btnCancel.AccessibleDescription = resources.GetString("btnCancel.AccessibleDescription");
		this.btnCancel.AccessibleName = resources.GetString("btnCancel.AccessibleName");
		this.btnCancel.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("btnCancel.Anchor")));
		this.btnCancel.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("btnCancel.BackgroundImage")));
		this.btnCancel.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("btnCancel.Dock")));
		this.btnCancel.Enabled = ((bool)(resources.GetObject("btnCancel.Enabled")));
		this.btnCancel.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("btnCancel.FlatStyle")));
		this.btnCancel.Font = ((System.Drawing.Font)(resources.GetObject("btnCancel.Font")));
		this.btnCancel.Image = ((System.Drawing.Image)(resources.GetObject("btnCancel.Image")));
		this.btnCancel.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnCancel.ImageAlign")));
		this.btnCancel.ImageIndex = ((int)(resources.GetObject("btnCancel.ImageIndex")));
		this.btnCancel.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("btnCancel.ImeMode")));
		this.btnCancel.Location = ((System.Drawing.Point)(resources.GetObject("btnCancel.Location")));
		this.btnCancel.Name = "btnCancel";
		this.btnCancel.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("btnCancel.RightToLeft")));
		this.btnCancel.Size = ((System.Drawing.Size)(resources.GetObject("btnCancel.Size")));
		this.btnCancel.TabIndex = ((int)(resources.GetObject("btnCancel.TabIndex")));
		this.btnCancel.Text = resources.GetString("btnCancel.Text");
		this.btnCancel.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("btnCancel.TextAlign")));
		this.btnCancel.Visible = ((bool)(resources.GetObject("btnCancel.Visible")));
		this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
		// 
		// chkAdministratorAccount
		// 
		this.chkAdministratorAccount.AccessibleDescription = resources.GetString("chkAdministratorAccount.AccessibleDescription");
		this.chkAdministratorAccount.AccessibleName = resources.GetString("chkAdministratorAccount.AccessibleName");
		this.chkAdministratorAccount.Anchor = ((System.Windows.Forms.AnchorStyles)(resources.GetObject("chkAdministratorAccount.Anchor")));
		this.chkAdministratorAccount.Appearance = ((System.Windows.Forms.Appearance)(resources.GetObject("chkAdministratorAccount.Appearance")));
		this.chkAdministratorAccount.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("chkAdministratorAccount.BackgroundImage")));
		this.chkAdministratorAccount.CheckAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAdministratorAccount.CheckAlign")));
		this.chkAdministratorAccount.Dock = ((System.Windows.Forms.DockStyle)(resources.GetObject("chkAdministratorAccount.Dock")));
		this.chkAdministratorAccount.Enabled = ((bool)(resources.GetObject("chkAdministratorAccount.Enabled")));
		this.chkAdministratorAccount.FlatStyle = ((System.Windows.Forms.FlatStyle)(resources.GetObject("chkAdministratorAccount.FlatStyle")));
		this.chkAdministratorAccount.Font = ((System.Drawing.Font)(resources.GetObject("chkAdministratorAccount.Font")));
		this.chkAdministratorAccount.Image = ((System.Drawing.Image)(resources.GetObject("chkAdministratorAccount.Image")));
		this.chkAdministratorAccount.ImageAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAdministratorAccount.ImageAlign")));
		this.chkAdministratorAccount.ImageIndex = ((int)(resources.GetObject("chkAdministratorAccount.ImageIndex")));
		this.chkAdministratorAccount.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("chkAdministratorAccount.ImeMode")));
		this.chkAdministratorAccount.Location = ((System.Drawing.Point)(resources.GetObject("chkAdministratorAccount.Location")));
		this.chkAdministratorAccount.Name = "chkAdministratorAccount";
		this.chkAdministratorAccount.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("chkAdministratorAccount.RightToLeft")));
		this.chkAdministratorAccount.Size = ((System.Drawing.Size)(resources.GetObject("chkAdministratorAccount.Size")));
		this.chkAdministratorAccount.TabIndex = ((int)(resources.GetObject("chkAdministratorAccount.TabIndex")));
		this.chkAdministratorAccount.Text = resources.GetString("chkAdministratorAccount.Text");
		this.chkAdministratorAccount.TextAlign = ((System.Drawing.ContentAlignment)(resources.GetObject("chkAdministratorAccount.TextAlign")));
		this.chkAdministratorAccount.Visible = ((bool)(resources.GetObject("chkAdministratorAccount.Visible")));
		// 
		// frmLogin
		// 
		this.AcceptButton = this.btnOK;
		this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");
		this.AccessibleName = resources.GetString("$this.AccessibleName");
		this.AutoScaleBaseSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScaleBaseSize")));
		this.AutoScroll = ((bool)(resources.GetObject("$this.AutoScroll")));
		this.AutoScrollMargin = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMargin")));
		this.AutoScrollMinSize = ((System.Drawing.Size)(resources.GetObject("$this.AutoScrollMinSize")));
		this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
		this.ClientSize = ((System.Drawing.Size)(resources.GetObject("$this.ClientSize")));
		this.Controls.Add(this.chkAdministratorAccount);
		this.Controls.Add(this.btnCancel);
		this.Controls.Add(this.btnOK);
		this.Controls.Add(this.txtPassword);
		this.Controls.Add(this.txtUserName);
		this.Controls.Add(this.Label2);
		this.Controls.Add(this.Label1);
		this.Enabled = ((bool)(resources.GetObject("$this.Enabled")));
		this.Font = ((System.Drawing.Font)(resources.GetObject("$this.Font")));
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.ImeMode = ((System.Windows.Forms.ImeMode)(resources.GetObject("$this.ImeMode")));
		this.Location = ((System.Drawing.Point)(resources.GetObject("$this.Location")));
		this.MaximumSize = ((System.Drawing.Size)(resources.GetObject("$this.MaximumSize")));
		this.MinimumSize = ((System.Drawing.Size)(resources.GetObject("$this.MinimumSize")));
		this.Name = "frmLogin";
		this.RightToLeft = ((System.Windows.Forms.RightToLeft)(resources.GetObject("$this.RightToLeft")));
		this.StartPosition = ((System.Windows.Forms.FormStartPosition)(resources.GetObject("$this.StartPosition")));
		this.Text = resources.GetString("$this.Text");
		this.ResumeLayout(false);

	}

#endregion

    int intLoginAttempts;


    private void btnCancel_Click(object sender, System.EventArgs e) 
	{
        Application.Exit();

    }

    private void btnOK_Click(object sender, System.EventArgs e) 
	{
        // Instantiate a custom Users class

        Users objUser = new Users();
        GenericPrincipal GenPrincipal;
        string strName = txtUserName.Text;
        string strPassword = txtPassword.Text;

        // Check for Windows Administrator.  Administrator can bypass
        // custom security system.

		if (chkAdministratorAccount.Checked) 
		{

			if (objUser.IsAdministrator()) 
			{

				// Display the Users Name (Windows or Generic)

				MessageBox.Show(Thread.CurrentPrincipal.Identity.Name + 
					" has logged in successfully!","Login Successful",
					MessageBoxButtons.OK, MessageBoxIcon.Information);

				// Show Main Form

				frmMain Main = new frmMain();
				Main.ShowDialog();

				// Hide the Login Form

				this.Close();
			}
			else 
			{

				// Increment login attempts

				intLoginAttempts += 1;

				MessageBox.Show("User not an Administrator.  Please provide a User Name and Password.", this.Text,
					MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

			}
		}
		else 
		{

			// Check that the login exists

			if (objUser.IsLogin(strName, strPassword)) 
			{
				GenPrincipal = objUser.GetLogin(strName, strPassword);
				Thread.CurrentPrincipal = GenPrincipal;

				// Display the Users Name (Windows or Generic)

				MessageBox.Show(Thread.CurrentPrincipal.Identity.Name + 
					" has logged in successfully!", "Login Successful",
					MessageBoxButtons.OK,MessageBoxIcon.Information);

				// Show Main Form

				frmMain Main = new frmMain();

				Main.ShowDialog();

				// Hide the Login Form

				this.Close();
			}
			else 
			{
				// Increment login attempts
				intLoginAttempts += 1;
				// After the 3 attempts quit the application
				if (intLoginAttempts >= 3) 
				{

					MessageBox.Show("Too many failed login attempts",this.Text,
						MessageBoxButtons.OK,MessageBoxIcon.Exclamation);
					Application.Exit();
				}
				else 
				{

					MessageBox.Show("User Name not found.  Please try again", this.Text,
							MessageBoxButtons.OK,MessageBoxIcon.Exclamation);

				}

				}

			}

			}

		}

