//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Drawing;

public class frmImage: System.Windows.Forms.Form {

#region " Windows Form Designer generated code "

	public frmImage() {
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

	private System.Windows.Forms.PictureBox picImage;
	private System.Windows.Forms.MainMenu mnuMain;
	private System.Windows.Forms.MenuItem mnuFile;
	private System.Windows.Forms.MenuItem mnuClose;
	private System.Windows.Forms.MenuItem mnuView;

	private System.Windows.Forms.MenuItem mnuZoom50;

	private System.Windows.Forms.MenuItem mnuZoom100;

	private System.Windows.Forms.MenuItem mnuZoom200;

	private System.Windows.Forms.MenuItem mnuStretch;

	private System.Windows.Forms.SaveFileDialog sdlgImage;

	private System.Windows.Forms.MenuItem mnuSave;

	private void InitializeComponent() {

		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmImage));

		this.picImage = new System.Windows.Forms.PictureBox();

		this.mnuMain = new System.Windows.Forms.MainMenu();

		this.mnuFile = new System.Windows.Forms.MenuItem();

		this.mnuClose = new System.Windows.Forms.MenuItem();

		this.mnuView = new System.Windows.Forms.MenuItem();

		this.mnuZoom50 = new System.Windows.Forms.MenuItem();

		this.mnuZoom100 = new System.Windows.Forms.MenuItem();

		this.mnuZoom200 = new System.Windows.Forms.MenuItem();

		this.mnuStretch = new System.Windows.Forms.MenuItem();

		this.sdlgImage = new System.Windows.Forms.SaveFileDialog();

		this.mnuSave = new System.Windows.Forms.MenuItem();

		this.SuspendLayout();

		//

		//picImage

		//

		this.picImage.Dock = System.Windows.Forms.DockStyle.Fill;

		this.picImage.Name = "picImage";

		this.picImage.Size = new System.Drawing.Size(224, 197);

		this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;

		this.picImage.TabIndex = 0;

		this.picImage.TabStop = false;

		//

		//mnuMain

		//

		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuView});

		//

		//mnuFile

		//

		this.mnuFile.Index = 0;

		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuSave, this.mnuClose});

		this.mnuFile.Text = "&File";

		//

		//mnuClose

		//

		this.mnuClose.Index = 1;

		this.mnuClose.Text = "&Close";

		//

		//mnuView

		//

		this.mnuView.Index = 1;

		this.mnuView.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuZoom50, this.mnuZoom100, this.mnuZoom200, this.mnuStretch});

		this.mnuView.Text = "&View";

		//

		//mnuZoom50

		//

		this.mnuZoom50.Index = 0;

		this.mnuZoom50.RadioCheck = true;

		this.mnuZoom50.Text = "50%";

		//

		//mnuZoom100

		//

		this.mnuZoom100.Index = 1;

		this.mnuZoom100.RadioCheck = true;

		this.mnuZoom100.Text = "100%";

		//

		//mnuZoom200

		//

		this.mnuZoom200.Index = 2;

		this.mnuZoom200.RadioCheck = true;

		this.mnuZoom200.Text = "200%";

		//

		//mnuStretch

		//

		this.mnuStretch.Index = 3;

		this.mnuStretch.RadioCheck = true;

		this.mnuStretch.Text = "Stretch";

		//

		//sdlgImage

		//

		this.sdlgImage.FileName = "doc1";

		this.sdlgImage.Title = "Save Image";

		//

		//mnuSave

		//

		this.mnuSave.Index = 0;

		this.mnuSave.Text = "&Save As...";

		//

		//frmImage

		//

		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

		this.ClientSize = new System.Drawing.Size(224, 197);

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.picImage});

		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

		this.Menu = this.mnuMain;

		this.Name = "frmImage";

		this.Text = "Image";

		this.ResumeLayout(false);

		this.Load +=new EventHandler(frmImage_Load);

		this.mnuClose.Click +=new EventHandler(mnuClose_Click);
		this.mnuSave.Click +=new EventHandler(mnuSave_Click);
		this.mnuZoom100.Click +=new EventHandler(mnuZoom100_Click);
		this.mnuZoom200.Click +=new EventHandler(mnuZoom200_Click);
		this.mnuZoom50.Click +=new EventHandler(mnuZoom50_Click);
		this.mnuStretch.Click +=new EventHandler(mnuStretch_Click);
		this.mnuZoom100.Click +=new EventHandler(HandleZoom);
		this.mnuZoom200.Click +=new EventHandler(HandleZoom);
		this.mnuZoom50.Click +=new EventHandler(HandleZoom);
		this.mnuStretch.Click +=new EventHandler(HandleZoom);
		

	}

#endregion

	private Size ClientSizeOriginal;

	public Image image
		{

		// public write-only property
		// allows parent form to set the 
		// image for this form without knowing
		// anything about the layout of the form.

		set
		{
			try 
			{

				picImage.Image = value;
			}
			catch (Exception exp) 
			{

				MessageBox.Show(exp.Message, this.Text);

			}

		}

	}

	private void frmImage_Load(object sender, System.EventArgs e)
	{

		// Store away the original client size, for later use.

		ClientSizeOriginal = this.ClientSize;

	}

	private void mnuClose_Click(object sender, System.EventArgs e) 
		{

		this.Close();

	}

	private void mnuSave_Click(object sender, System.EventArgs e) 
		{
		// Save the image in one of the available image formats.
		System.Drawing.Imaging.ImageFormat fmt = null;

		try 
		{
			sdlgImage.Filter = "Bitmap (*.bmp)|*.bmp|JPEG (*.jpg, *.jpeg)|*.jpg;*.jpeg|GIF (*.gif)|*.gif|TIFF (*.tif, *.tiff)|*.tif;*.tiff|PNG (*.png)|*.png";
			sdlgImage.AddExtension = true;
			sdlgImage.OverwritePrompt = true;
			sdlgImage.CheckPathExists = true;
			sdlgImage.ValidateNames = true;
			sdlgImage.Title = "Save Image";
			if (sdlgImage.ShowDialog() == DialogResult.OK) 
			{
				Bitmap bmp = new Bitmap(picImage.Image);
				
				switch(sdlgImage.FilterIndex)
				{
					case 1:
					{
						fmt = System.Drawing.Imaging.ImageFormat.Bmp;
						break;
					}
					case 2:
					{
						fmt = System.Drawing.Imaging.ImageFormat.Jpeg;
						break;
					}
					case 3:
					{
						fmt = System.Drawing.Imaging.ImageFormat.Gif;
						break;
					}
					case 4:
					{
						fmt = System.Drawing.Imaging.ImageFormat.Tiff;
						break;
					}
					case 5:
					{
						fmt = System.Drawing.Imaging.ImageFormat.Png;
						break;		
					}
				}

				bmp.Save(sdlgImage.FileName, fmt);

			}
		}
		catch (Exception exp) 
		{

			MessageBox.Show(exp.Message, "Saving Image");

		}

	}

	private void mnuStretch_Click(object sender, System.EventArgs e) 
		{
		this.FormBorderStyle = FormBorderStyle.Sizable;

	}

	private void mnuZoom50_Click(object sender, System.EventArgs e) 
		{

		SetClientSize(50);

	}

	private void mnuZoom100_Click(object sender, System.EventArgs e) 
		{

		SetClientSize(100);

	}

	private void mnuZoom200_Click(object sender, System.EventArgs e) 
		{

		SetClientSize(200);

	}

	private void HandleZoom(object sender, System.EventArgs e) 
	{
		// Handle the checks on the menu items.
		// Turn off all checks.

		mnuZoom50.Checked = false;
		mnuZoom100.Checked = false;
		mnuZoom200.Checked = false;
		mnuStretch.Checked = false;
		// Turn on the one check that's required.
		((MenuItem)(sender)).Checked = true;
	}

	private void SetClientSize(double intPercent)
		{

		// Given a percentage (50, 100, or 200, in this example)
		// set the size of the form based on its original size.

		this.FormBorderStyle = FormBorderStyle.FixedSingle;

		this.ClientSize = new Size(Convert.ToInt32((intPercent / 100) * ClientSizeOriginal.Width), 
			Convert.ToInt32((intPercent / 100) * ClientSizeOriginal.Height));

	}

}

