//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).


using System;
using System.Windows.Forms;

public class frmAbout: System.Windows.Forms.Form 
{

	#region " Windows Form Designer generated code "

	public frmAbout () 
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

	private System.Windows.Forms.PictureBox pbIcon;
	private System.Windows.Forms.Label lblTitle;
	private System.Windows.Forms.Label lblVersion;
	private System.Windows.Forms.Label lblDescription;
	private System.Windows.Forms.Button cmdOK;
	private System.Windows.Forms.Label lblCopyright;
	private System.Windows.Forms.Label label1;
	private System.Windows.Forms.Label label2;
	private System.Windows.Forms.Button button1;
	private System.Windows.Forms.Label label3;
	private System.Windows.Forms.Label label4;
	private System.Windows.Forms.Label label5;
	private System.Windows.Forms.PictureBox pictureBox1;
	private System.Windows.Forms.Label lblCodebase;
	private void InitializeComponent() 
	{
		this.pbIcon = new System.Windows.Forms.PictureBox();
		this.lblTitle = new System.Windows.Forms.Label();
		this.lblVersion = new System.Windows.Forms.Label();
		this.lblDescription = new System.Windows.Forms.Label();
		this.cmdOK = new System.Windows.Forms.Button();
		this.lblCopyright = new System.Windows.Forms.Label();
		this.lblCodebase = new System.Windows.Forms.Label();
		this.label1 = new System.Windows.Forms.Label();
		this.label2 = new System.Windows.Forms.Label();
		this.button1 = new System.Windows.Forms.Button();
		this.label3 = new System.Windows.Forms.Label();
		this.label4 = new System.Windows.Forms.Label();
		this.label5 = new System.Windows.Forms.Label();
		this.pictureBox1 = new System.Windows.Forms.PictureBox();
		this.SuspendLayout();
		// 
		// pbIcon
		// 
		this.pbIcon.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.pbIcon.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.pbIcon.Enabled = false;
		this.pbIcon.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.pbIcon.Location = new System.Drawing.Point(220, 116);
		this.pbIcon.Name = "pbIcon";
		this.pbIcon.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.pbIcon.Size = new System.Drawing.Size(0, 0);
		this.pbIcon.TabIndex = 0;
		this.pbIcon.TabStop = false;
		this.pbIcon.Visible = false;
		// 
		// lblTitle
		// 
		this.lblTitle.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.lblTitle.Enabled = false;
		this.lblTitle.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblTitle.Location = new System.Drawing.Point(220, 116);
		this.lblTitle.Name = "lblTitle";
		this.lblTitle.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.lblTitle.Size = new System.Drawing.Size(0, 0);
		this.lblTitle.TabIndex = 0;
		this.lblTitle.Visible = false;
		// 
		// lblVersion
		// 
		this.lblVersion.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.lblVersion.Enabled = false;
		this.lblVersion.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblVersion.Location = new System.Drawing.Point(220, 116);
		this.lblVersion.Name = "lblVersion";
		this.lblVersion.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.lblVersion.Size = new System.Drawing.Size(0, 0);
		this.lblVersion.TabIndex = 0;
		this.lblVersion.Visible = false;
		// 
		// lblDescription
		// 
		this.lblDescription.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.lblDescription.Enabled = false;
		this.lblDescription.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblDescription.Location = new System.Drawing.Point(220, 116);
		this.lblDescription.Name = "lblDescription";
		this.lblDescription.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.lblDescription.Size = new System.Drawing.Size(0, 0);
		this.lblDescription.TabIndex = 0;
		this.lblDescription.Visible = false;
		// 
		// cmdOK
		// 
		this.cmdOK.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.cmdOK.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.cmdOK.Enabled = false;
		this.cmdOK.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
		this.cmdOK.ImageIndex = 0;
		this.cmdOK.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdOK.Location = new System.Drawing.Point(220, 116);
		this.cmdOK.Name = "cmdOK";
		this.cmdOK.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.cmdOK.Size = new System.Drawing.Size(0, 0);
		this.cmdOK.TabIndex = 0;
		this.cmdOK.Visible = false;
		// 
		// lblCopyright
		// 
		this.lblCopyright.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.lblCopyright.Enabled = false;
		this.lblCopyright.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblCopyright.Location = new System.Drawing.Point(220, 116);
		this.lblCopyright.Name = "lblCopyright";
		this.lblCopyright.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.lblCopyright.Size = new System.Drawing.Size(0, 0);
		this.lblCopyright.TabIndex = 0;
		this.lblCopyright.Visible = false;
		// 
		// lblCodebase
		// 
		this.lblCodebase.Anchor = System.Windows.Forms.AnchorStyles.None;
		this.lblCodebase.Enabled = false;
		this.lblCodebase.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblCodebase.Location = new System.Drawing.Point(220, 116);
		this.lblCodebase.Name = "lblCodebase";
		this.lblCodebase.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.lblCodebase.Size = new System.Drawing.Size(0, 0);
		this.lblCodebase.TabIndex = 0;
		this.lblCodebase.Visible = false;
		// 
		// label1
		// 
		this.label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.label1.Location = new System.Drawing.Point(68, 125);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(360, 64);
		this.label1.TabIndex = 13;
		this.label1.Text = "Application Codebase";
		// 
		// label2
		// 
		this.label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.label2.Location = new System.Drawing.Point(68, 53);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(360, 23);
		this.label2.TabIndex = 12;
		this.label2.Text = "Application Copyright";
		// 
		// button1
		// 
		this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
		this.button1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.button1.Location = new System.Drawing.Point(348, 197);
		this.button1.Name = "button1";
		this.button1.TabIndex = 11;
		this.button1.Text = "OK";
		// 
		// label3
		// 
		this.label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.label3.Location = new System.Drawing.Point(68, 77);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(360, 46);
		this.label3.TabIndex = 10;
		this.label3.Text = "Application Description";
		// 
		// label4
		// 
		this.label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.label4.Location = new System.Drawing.Point(68, 37);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(360, 23);
		this.label4.TabIndex = 9;
		this.label4.Text = "Application Version";
		// 
		// label5
		// 
		this.label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.label5.Location = new System.Drawing.Point(68, 13);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(360, 23);
		this.label5.TabIndex = 8;
		this.label5.Text = "Application Title";
		// 
		// pictureBox1
		// 
		this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
		this.pictureBox1.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.pictureBox1.Location = new System.Drawing.Point(12, 13);
		this.pictureBox1.Name = "pictureBox1";
		this.pictureBox1.Size = new System.Drawing.Size(32, 32);
		this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
		this.pictureBox1.TabIndex = 7;
		this.pictureBox1.TabStop = false;
		// 
		// frmAbout
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(440, 232);
		this.Controls.Add(this.label1);
		this.Controls.Add(this.label2);
		this.Controls.Add(this.button1);
		this.Controls.Add(this.label3);
		this.Controls.Add(this.label4);
		this.Controls.Add(this.label5);
		this.Controls.Add(this.pictureBox1);
		this.Controls.Add(this.lblCodebase);
		this.Controls.Add(this.lblCopyright);
		this.Controls.Add(this.cmdOK);
		this.Controls.Add(this.lblDescription);
		this.Controls.Add(this.lblVersion);
		this.Controls.Add(this.lblTitle);
		this.Controls.Add(this.pbIcon);
		this.Enabled = false;
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
		this.MaximizeBox = false;
		this.MinimizeBox = false;
		this.Name = "frmAbout";
		this.RightToLeft = System.Windows.Forms.RightToLeft.No;
		this.ShowInTaskbar = false;
		this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
		this.ResumeLayout(false);
		this.Load +=new EventHandler(frmAbout_Load);
	}

	#endregion

	// Note: Because this form is opened by frmMain using the ShowDialog command, we simply set the
	// DialogResult property of cmdOK to OK which causes the form to close when clicked.

	private void frmAbout_Load(object sender, System.EventArgs e) 
	{
		try 
		{
			// Set this Form's Text + Icon properties by using values from the parent form
			this.Text = "About " + this.Owner.Text;
			this.Icon = this.Owner.Icon;
			// Set this Form's Picture Box's image using the parent's icon 
			// However, we need to convert it to a Bitmap since the Picture Box Control
			// will not accept a raw Icon.
			this.pbIcon.Image = this.Owner.Icon.ToBitmap();
			// Set the labels identitying the Title, Version, and Description by
			// reading Assembly meta-data originally entered in the AssemblyInfo.cs file
			// using the AssemblyInfo class defined in the same file
			AssemblyInfo ainfo = new AssemblyInfo();
			this.lblTitle.Text = ainfo.Title;
			this.lblVersion.Text = string.Format("Version {0}", ainfo.Version);
			this.lblCopyright.Text = ainfo.Copyright;
			this.lblDescription.Text = ainfo.Description;
			this.lblCodebase.Text = ainfo.CodeBase;
		} 
		catch(System.Exception exp) 
		{
			// This catch will trap any unexpected error.
			MessageBox.Show(exp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
	}
}

