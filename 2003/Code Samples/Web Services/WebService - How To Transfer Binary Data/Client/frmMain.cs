//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.IO;
using System;
using System.Windows.Forms;
using System.Drawing;
using HowTo.WebServiceGraphics.GraphicsServer;

public class frmMain: System.Windows.Forms.Form {

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

#region " Windows Form Designer generated code "

	public frmMain () {
		
		//This call is required by the Windows Form Designer.
		InitializeComponent();
		//Add any initialization after the InitializeComponent() call
		// So that we only need to set the title of the application once,
		// we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
		// to read the AssemblyTitle attribute.
		AssemblyInfo ainfo = new AssemblyInfo();
		this.Text = ainfo.Title;
		this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);
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

	private System.Windows.Forms.MainMenu mnuMain;
	private System.Windows.Forms.MenuItem mnuFile;
	private System.Windows.Forms.MenuItem mnuExit;
	private System.Windows.Forms.MenuItem mnuHelp;
	private System.Windows.Forms.MenuItem mnuAbout;
    private System.Windows.Forms.PictureBox picImage;
    private System.Windows.Forms.Label lblSize;
    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.Label lblPixelFormat;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.Label lblImageSize;
    private System.Windows.Forms.Label Label4;
    private System.Windows.Forms.Label lblResolution;
    private System.Windows.Forms.ListBox lstImages;
    private System.Windows.Forms.Button btnDisplay;
    private System.Windows.Forms.Button btnRetrieve;
	private System.Windows.Forms.MenuItem mnuAboutWS;

	private void InitializeComponent() {

		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

		this.mnuMain = new System.Windows.Forms.MainMenu();

		this.mnuFile = new System.Windows.Forms.MenuItem();

		this.mnuExit = new System.Windows.Forms.MenuItem();

		this.mnuHelp = new System.Windows.Forms.MenuItem();

		this.mnuAbout = new System.Windows.Forms.MenuItem();

		this.btnRetrieve = new System.Windows.Forms.Button();

		this.lstImages = new System.Windows.Forms.ListBox();

		this.lblSize = new System.Windows.Forms.Label();

		this.picImage = new System.Windows.Forms.PictureBox();

		this.Label1 = new System.Windows.Forms.Label();

		this.Label2 = new System.Windows.Forms.Label();

		this.lblPixelFormat = new System.Windows.Forms.Label();

		this.Label3 = new System.Windows.Forms.Label();

		this.lblImageSize = new System.Windows.Forms.Label();

		this.Label4 = new System.Windows.Forms.Label();

		this.lblResolution = new System.Windows.Forms.Label();

		this.btnDisplay = new System.Windows.Forms.Button();

		this.mnuAboutWS = new System.Windows.Forms.MenuItem();

		this.SuspendLayout();

		//

		//mnuMain

		//

		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuHelp});

		//

		//mnuFile

		//

		this.mnuFile.Index = 0;

		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuExit});

		this.mnuFile.Text = "&File";

		//

		//mnuExit

		//

		this.mnuExit.Index = 0;

		this.mnuExit.Text = "E&xit";

		//

		//mnuHelp

		//

		this.mnuHelp.Index = 1;

		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuAbout, this.mnuAboutWS});

		this.mnuHelp.Text = "&Help";

		//

		//mnuAbout

		//

		this.mnuAbout.Index = 0;

		this.mnuAbout.Text = "Text Comes from AssemblyInfo";

		//

		//btnRetrieve

		//

		this.btnRetrieve.Location = new System.Drawing.Point(8, 8);

		this.btnRetrieve.Name = "btnRetrieve";

		this.btnRetrieve.Size = new System.Drawing.Size(112, 24);

		this.btnRetrieve.TabIndex = 0;

		this.btnRetrieve.Text = "Retrieve Images";

		//

		//lstImages

		//

		this.lstImages.Location = new System.Drawing.Point(8, 40);

		this.lstImages.Name = "lstImages";

		this.lstImages.Size = new System.Drawing.Size(112, 160);

		this.lstImages.TabIndex = 1;

		//

		//lblSize

		//

		this.lblSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

		this.lblSize.Location = new System.Drawing.Point(264, 112);

		this.lblSize.Name = "lblSize";

		this.lblSize.Size = new System.Drawing.Size(104, 24);

		this.lblSize.TabIndex = 2;

		this.lblSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//picImage

		//

		this.picImage.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

		this.picImage.Location = new System.Drawing.Point(128, 40);

		this.picImage.Name = "picImage";

		this.picImage.Size = new System.Drawing.Size(96, 64);

		this.picImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.AutoSize;

		this.picImage.TabIndex = 3;

		this.picImage.TabStop = false;

		//

		//Label1

		//

		this.Label1.Location = new System.Drawing.Point(128, 112);

		this.Label1.Name = "Label1";

		this.Label1.Size = new System.Drawing.Size(136, 23);

		this.Label1.TabIndex = 4;

		this.Label1.Text = "Size (bytes)";

		this.Label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

		//

		//Label2

		//

		this.Label2.Location = new System.Drawing.Point(128, 136);

		this.Label2.Name = "Label2";

		this.Label2.Size = new System.Drawing.Size(136, 23);

		this.Label2.TabIndex = 6;

		this.Label2.Text = "Pixel Format";

		this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

		//

		//lblPixelFormat

		//

		this.lblPixelFormat.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

		this.lblPixelFormat.Location = new System.Drawing.Point(264, 136);

		this.lblPixelFormat.Name = "lblPixelFormat";

		this.lblPixelFormat.Size = new System.Drawing.Size(104, 24);

		this.lblPixelFormat.TabIndex = 5;

		this.lblPixelFormat.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//Label3

		//

		this.Label3.Location = new System.Drawing.Point(128, 160);

		this.Label3.Name = "Label3";

		this.Label3.Size = new System.Drawing.Size(136, 23);

		this.Label3.TabIndex = 8;

		this.Label3.Text = "Size (pixels)";

		this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

		//

		//lblImageSize

		//

		this.lblImageSize.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

		this.lblImageSize.Location = new System.Drawing.Point(264, 160);

		this.lblImageSize.Name = "lblImageSize";

		this.lblImageSize.Size = new System.Drawing.Size(104, 24);

		this.lblImageSize.TabIndex = 7;

		this.lblImageSize.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//Label4

		//

		this.Label4.Location = new System.Drawing.Point(128, 184);

		this.Label4.Name = "Label4";

		this.Label4.Size = new System.Drawing.Size(136, 23);

		this.Label4.TabIndex = 10;

		this.Label4.Text = "Resolution (pixels/inch)";

		this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

		//

		//lblResolution

		//

		this.lblResolution.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

		this.lblResolution.Location = new System.Drawing.Point(264, 184);

		this.lblResolution.Name = "lblResolution";

		this.lblResolution.Size = new System.Drawing.Size(104, 24);

		this.lblResolution.TabIndex = 9;

		this.lblResolution.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;

		//

		//btnDisplay

		//

		this.btnDisplay.Enabled = false;

		this.btnDisplay.Location = new System.Drawing.Point(128, 8);

		this.btnDisplay.Name = "btnDisplay";

		this.btnDisplay.Size = new System.Drawing.Size(96, 24);

		this.btnDisplay.TabIndex = 11;

		this.btnDisplay.Text = "Display Image";

		//

		//mnuAboutWS

		//

		this.mnuAboutWS.Index = 1;

		this.mnuAboutWS.Text = "About &Web Service . . .";

		//

		//frmMain

		//

		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

		this.ClientSize = new System.Drawing.Size(370, 211);

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnDisplay, this.Label4, this.lblResolution, this.Label3, this.lblImageSize, this.Label2, this.lblPixelFormat, this.Label1, this.picImage, this.lblSize, this.lstImages, this.btnRetrieve});

		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

		this.MaximizeBox = false;

		this.Menu = this.mnuMain;

		this.Name = "frmMain";

		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

		this.Text = "Title Comes from Assembly Info";

		this.ResumeLayout(false);

	
		this.btnDisplay.Click +=new EventHandler(btnDisplay_Click);
		this.btnRetrieve.Click +=new EventHandler(btnRetrieve_Click);
		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.mnuAboutWS.Click +=new EventHandler(mnuAboutWS_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
		this.lstImages.SelectedIndexChanged +=new EventHandler(lstImages_SelectedIndexChanged);
		this.picImage.DoubleClick +=new EventHandler(picImage_DoubleClick);
	}

#endregion

#region " Standard Menu Code "

	// This code simply shows the About form.

	private void mnuAbout_Click(object sender, System.EventArgs e) {

		// Open the About form in Dialog Mode

		frmAbout frm = new frmAbout();

		frm.ShowDialog(this);

		frm.Dispose();

	}

	// This code will close the form.

	private void mnuExit_Click(object sender, System.EventArgs e) {

		// Close the current form

		this.Close();

	}

	// This code will get the About string from the Web Service

	private void mnuAboutWS_Click(object sender, System.EventArgs e) 
		//mnuAboutWS.Click;
	{

		try 
		{
			ImageService imgsvc = new ImageService();
			MessageBox.Show(imgsvc.About(), this.Text,MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		catch (Exception exp) 
		{

			MessageBox.Show(exp.Message, this.Text);

		}

	}

#endregion

	private ImageInfo[] maInfo;

	private void btnDisplay_Click(object sender, System.EventArgs e) 
	{
		DisplayImage();

	}

	private void btnRetrieve_Click(object sender, System.EventArgs e) 
	{
		ImageService imgsvc = null;

		try 
		{

			// Turn on the hourglass cursor. 
			this.Cursor = Cursors.WaitCursor;
			// Retrieve array of information
			// about available images.
			imgsvc = new ImageService();
			maInfo = imgsvc.Browse();
			// Clear the list, then fill it in.
			lstImages.Items.Clear();
			// Because the Web Service proxy class defines
			// the elements of the ImageInfo structure simple
			// fields, you can't simply bind the ListBox to 
			// the array, supplying the DisplayMember property.
			foreach(ImageInfo info in maInfo)
			{
				lstImages.Items.Add(info.Name);
			}
		}
		catch (Exception Exp)
		{
			MessageBox.Show(Exp.Message, this.Text);
		}
		finally
		{

			// Turn off the hourglass cursor.
			// Apparently, this isn't required -- when
			// you leave the procedure, it goes back to
			// normal. But it's a good idea to put it back 
			// when you're done.
			this.Cursor = Cursors.Default;
			imgsvc.Dispose();
		}

	}

	private void lstImages_SelectedIndexChanged(object sender, System.EventArgs e) 
	{
		ImageService imgsvc = null;
		ImageInfo Info;

		// Display information about the selected image.

		try 
		{
			imgsvc = new ImageService();
			Info = maInfo[lstImages.SelectedIndex];
			lblSize.Text = Info.Size.ToString();
			lblPixelFormat.Text = Info.PixelFormat.ToString();
			lblResolution.Text = string.Format("{0} x {1}", Info.HorizontalResolution, Info.VerticalResolution);
			lblImageSize.Text = string.Format("{0} x {1}", Info.Width, Info.Height);
			picImage.Image = GetImage(Info.Thumbnail);
			btnDisplay.Enabled = true;
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, this.Text);
		}
			finally
		{
			imgsvc.Dispose();
		}

	}

	private void picImage_DoubleClick(object sender, System.EventArgs e) 
	{
		DisplayImage();

	}

	private void DisplayImage()
	{
		frmImage frm;
		ImageService imgsvc = null;
		Bitmap bmp;
		string strName;

		// Display information about the selected image.
		try 
		{
			imgsvc = new ImageService();
			strName = maInfo[lstImages.SelectedIndex].Name;
			bmp = GetImage(imgsvc.GetImage(strName));
			// Create a new image form instance.
			frm = new frmImage();
			frm.Text = strName;
			frm.image = bmp;
			frm.ClientSize = new Size(bmp.Width, bmp.Height);
			frm.Show();
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, this.Text);
		}
		finally
		{
			imgsvc.Dispose();
		}

	}

	private Bitmap GetImage(byte[] abyt)
{

		// Given an array of bytes, return an actual Bitmap
		// object. This requires creating a new MemoryStream
		// object based on the array of bytes, and then 
		// creating a new bitmap based on the memory stream.
		Bitmap btm = null;

		try 
		{
			btm = new Bitmap(new MemoryStream(abyt));
			return btm;
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, this.Text);
			return btm;
		}

	}

}

