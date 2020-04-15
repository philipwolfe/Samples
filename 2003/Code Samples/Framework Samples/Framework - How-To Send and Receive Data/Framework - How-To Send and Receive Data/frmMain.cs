// Copyright (C) 2002 Microsoft Corporation
// All rights reserved.
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
// EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
// MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
// Requires the Trial or Release version of Visual Studio .NET Professional 2003 (or greater).

using System;
using System.IO; //' Used to work with Streams;
using System.Windows.Forms;
using System.Net; //' Used for client-side of HTTP communication;
using System.Drawing;

public class frmMain : System.Windows.Forms.Form 
{

	

#region " Windows Form Designer generated code "

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

	public frmMain() 
	{
		// This call is required by the Windows Form Designer.
		InitializeComponent();
		// Add any initialization after the InitializeComponent() call
		// So that we only need to set the title of the application once,
		// we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
		// to read the AssemblyTitle attribute.
		AssemblyInfo ainfo = new AssemblyInfo();
		this.Text = ainfo.Title;
		this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);
	}

	// Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing) {
		if (disposing) {
			if (components != null) {
				components.Dispose();
			}
		}
		base.Dispose(disposing);
	}
	// Required by the Windows Form Designer
	private System.ComponentModel.IContainer components = null;
	// NOTE: The following procedure is required by the Windows Form Designer
	// It can be modified using the Windows Form Designer.  
	// Do not modify it using the code editor.
	private System.Windows.Forms.MainMenu mnuMain;

	private System.Windows.Forms.MenuItem mnuFile;

	private System.Windows.Forms.MenuItem mnuExit;

	private System.Windows.Forms.MenuItem mnuHelp;

	private System.Windows.Forms.MenuItem mnuAbout;

	private System.Windows.Forms.Button cmdSendFileData;

	private System.Windows.Forms.Button cmdReceiveDataFile;

	private System.Windows.Forms.Button cmdReceiveImageFile;

	private System.Windows.Forms.PictureBox picDownloadImage;

	private System.Windows.Forms.TextBox txtDataPassed;

	private System.Windows.Forms.Label lblDataToPass;

	private System.Windows.Forms.GroupBox grpSendFiles;

	private System.Windows.Forms.GroupBox grpPassText;

	private System.Windows.Forms.Button cmdPassText;

	private System.Windows.Forms.Label lblDataReturned;

	private System.Windows.Forms.TextBox txtDataReturned;

	private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.grpSendFiles = new System.Windows.Forms.GroupBox();
		this.cmdReceiveImageFile = new System.Windows.Forms.Button();
		this.cmdReceiveDataFile = new System.Windows.Forms.Button();
		this.cmdSendFileData = new System.Windows.Forms.Button();
		this.picDownloadImage = new System.Windows.Forms.PictureBox();
		this.grpPassText = new System.Windows.Forms.GroupBox();
		this.lblDataReturned = new System.Windows.Forms.Label();
		this.txtDataReturned = new System.Windows.Forms.TextBox();
		this.lblDataToPass = new System.Windows.Forms.Label();
		this.txtDataPassed = new System.Windows.Forms.TextBox();
		this.cmdPassText = new System.Windows.Forms.Button();
		this.grpSendFiles.SuspendLayout();
		this.grpPassText.SuspendLayout();
		this.SuspendLayout();
		// 
		// mnuMain
		// 
		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuFile,
																				this.mnuHelp});
		// 
		// mnuFile
		// 
		this.mnuFile.Index = 0;
		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuExit});
		this.mnuFile.Text = "&File";
		// 
		// mnuExit
		// 
		this.mnuExit.Index = 0;
		this.mnuExit.Text = "E&xit";
		this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
		// 
		// mnuHelp
		// 
		this.mnuHelp.Index = 1;
		this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																				this.mnuAbout});
		this.mnuHelp.Text = "&Help";
		// 
		// mnuAbout
		// 
		this.mnuAbout.Index = 0;
		this.mnuAbout.Text = "Text Comes from AssemblyInfo";
		this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
		// 
		// grpSendFiles
		// 
		this.grpSendFiles.Controls.Add(this.cmdReceiveImageFile);
		this.grpSendFiles.Controls.Add(this.cmdReceiveDataFile);
		this.grpSendFiles.Controls.Add(this.cmdSendFileData);
		this.grpSendFiles.Location = new System.Drawing.Point(16, 16);
		this.grpSendFiles.Name = "grpSendFiles";
		this.grpSendFiles.Size = new System.Drawing.Size(232, 120);
		this.grpSendFiles.TabIndex = 0;
		this.grpSendFiles.TabStop = false;
		this.grpSendFiles.Text = "S&ending and Receiving data files";
		// 
		// cmdReceiveImageFile
		// 
		this.cmdReceiveImageFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdReceiveImageFile.Location = new System.Drawing.Point(16, 88);
		this.cmdReceiveImageFile.Name = "cmdReceiveImageFile";
		this.cmdReceiveImageFile.Size = new System.Drawing.Size(200, 24);
		this.cmdReceiveImageFile.TabIndex = 3;
		this.cmdReceiveImageFile.Text = "Receiving &Image using HTTP";
		this.cmdReceiveImageFile.Click += new System.EventHandler(this.cmdReceiveImageFile_Click);
		// 
		// cmdReceiveDataFile
		// 
		this.cmdReceiveDataFile.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdReceiveDataFile.Location = new System.Drawing.Point(16, 56);
		this.cmdReceiveDataFile.Name = "cmdReceiveDataFile";
		this.cmdReceiveDataFile.Size = new System.Drawing.Size(200, 24);
		this.cmdReceiveDataFile.TabIndex = 2;
		this.cmdReceiveDataFile.Text = "Receiving &Data in file using HTTP";
		this.cmdReceiveDataFile.Click += new System.EventHandler(this.cmdReceiveDataFile_Click);
		// 
		// cmdSendFileData
		// 
		this.cmdSendFileData.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdSendFileData.Location = new System.Drawing.Point(16, 24);
		this.cmdSendFileData.Name = "cmdSendFileData";
		this.cmdSendFileData.Size = new System.Drawing.Size(200, 24);
		this.cmdSendFileData.TabIndex = 1;
		this.cmdSendFileData.Text = "&Send Data in file using HTTP";
		this.cmdSendFileData.Click += new System.EventHandler(this.cmdSendFileData_Click);
		// 
		// picDownloadImage
		// 
		this.picDownloadImage.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.picDownloadImage.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.picDownloadImage.Location = new System.Drawing.Point(280, 24);
		this.picDownloadImage.Name = "picDownloadImage";
		this.picDownloadImage.Size = new System.Drawing.Size(136, 112);
		this.picDownloadImage.TabIndex = 5;
		this.picDownloadImage.TabStop = false;
		// 
		// grpPassText
		// 
		this.grpPassText.Controls.Add(this.lblDataReturned);
		this.grpPassText.Controls.Add(this.txtDataReturned);
		this.grpPassText.Controls.Add(this.lblDataToPass);
		this.grpPassText.Controls.Add(this.txtDataPassed);
		this.grpPassText.Controls.Add(this.cmdPassText);
		this.grpPassText.Location = new System.Drawing.Point(16, 144);
		this.grpPassText.Name = "grpPassText";
		this.grpPassText.Size = new System.Drawing.Size(400, 216);
		this.grpPassText.TabIndex = 4;
		this.grpPassText.TabStop = false;
		this.grpPassText.Text = "P&assing data directly";
		// 
		// lblDataReturned
		// 
		this.lblDataReturned.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblDataReturned.Location = new System.Drawing.Point(16, 144);
		this.lblDataReturned.Name = "lblDataReturned";
		this.lblDataReturned.Size = new System.Drawing.Size(152, 16);
		this.lblDataReturned.TabIndex = 8;
		this.lblDataReturned.Text = "Data &Returned";
		// 
		// txtDataReturned
		// 
		this.txtDataReturned.Location = new System.Drawing.Point(16, 160);
		this.txtDataReturned.Multiline = true;
		this.txtDataReturned.Name = "txtDataReturned";
		this.txtDataReturned.ReadOnly = true;
		this.txtDataReturned.Size = new System.Drawing.Size(360, 48);
		this.txtDataReturned.TabIndex = 9;
		this.txtDataReturned.Text = "";
		// 
		// lblDataToPass
		// 
		this.lblDataToPass.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.lblDataToPass.Location = new System.Drawing.Point(16, 64);
		this.lblDataToPass.Name = "lblDataToPass";
		this.lblDataToPass.Size = new System.Drawing.Size(152, 16);
		this.lblDataToPass.TabIndex = 6;
		this.lblDataToPass.Text = "Data to &Pass";
		// 
		// txtDataPassed
		// 
		this.txtDataPassed.Location = new System.Drawing.Point(16, 80);
		this.txtDataPassed.Multiline = true;
		this.txtDataPassed.Name = "txtDataPassed";
		this.txtDataPassed.Size = new System.Drawing.Size(360, 48);
		this.txtDataPassed.TabIndex = 7;
		this.txtDataPassed.Text = "<type data here>";
		// 
		// cmdPassText
		// 
		this.cmdPassText.ImeMode = System.Windows.Forms.ImeMode.NoControl;
		this.cmdPassText.Location = new System.Drawing.Point(16, 24);
		this.cmdPassText.Name = "cmdPassText";
		this.cmdPassText.Size = new System.Drawing.Size(200, 24);
		this.cmdPassText.TabIndex = 5;
		this.cmdPassText.Text = "Pass &Text Using HTTP";
		this.cmdPassText.Click += new System.EventHandler(this.cmdPassText_Click);
		// 
		// frmMain
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(434, 379);
		this.Controls.Add(this.grpPassText);
		this.Controls.Add(this.picDownloadImage);
		this.Controls.Add(this.grpSendFiles);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.MaximizeBox = false;
		this.Menu = this.mnuMain;
		this.Name = "frmMain";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Title Comes from Assembly Info";
		this.grpSendFiles.ResumeLayout(false);
		this.grpPassText.ResumeLayout(false);
		this.ResumeLayout(false);

	}

#endregion

#region " Standard Menu Code "

	// This code simply shows the About form.
	private void mnuAbout_Click(object sender, System.EventArgs e) 
	{
		// Open the About form in Dialog Mode
		frmAbout frm = new frmAbout();
		frm.ShowDialog(this);
		frm.Dispose();
	}

	// This code will close the form.
	private void mnuExit_Click(object sender, System.EventArgs e) 
	{
		// Close the current form
		this.Close();
	}

#endregion
	

	private void cmdPassText_Click(object sender, System.EventArgs e) 
	{
		// This method sends and receives text to/from a website. Some text 
		// is streamed in both directions using the RequestStream of the 
		// WebRequest class and the ResponseStream of the WebResponse class, 
		// Respectively. The stream access is wrapped in try {/catch blocks 
		// to ensure timely release of the resources.
		WebRequest req = null;
		WebResponse rsp = null;

		try 
		{
			// Setup the WebRequest instance
			req = WebRequest.Create("http://localhost/SendAndReceiveDataWebPages/PassText.aspx");
			// Use POST since we' re sending data
			req.Method = "POST";
			// Wrap the request stream with a text-based writer
			StreamWriter sw = new StreamWriter(req.GetRequestStream());
			// Write the text from the textbox into the stream
			sw.WriteLine(txtDataPassed.Text);
			sw.Close();
			// Send the text to the webserver
			rsp = req.GetResponse();
			// Wrap the response stream with a text-based reader
			StreamReader sr = new StreamReader(rsp.GetResponseStream());
			// Read the returned text into a textbox
			txtDataReturned.Text = sr.ReadLine();
			MessageBox.Show("Passing text completed successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		catch (Exception exp) 
		{
			// Will catch any error that we're not explicitly trapping.
			MessageBox.Show(exp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
		}
		finally
		{
			try 
			{
				// Guarantee the streams will be closed
				if ( req != null) req.GetRequestStream().Close();				
				if ( rsp != null) rsp.GetResponseStream().Close();				
			}
			catch{
				// Eat the error if we get one
			}
		}
	}

	private void cmdReceiveDataFile_Click(object sender, System.EventArgs e) 
	{
		// This method requests and receives an XML file from a website.
		// The file is streamed back to this method, which copies the contents
		// into a local file named ReceivedXMLFile.xml. The contents are streamed
		// using the ResponseStream of the WebResponse class. The stream access
		// is wrapped in try {/catch blocks to ensure timely release of the 
		// resources.
        string strMsg = "In order to run this part of the sample, you must adjust the security settings" + 
        " for the physical directory that contains the ASPX files." + Environment.NewLine + Environment.NewLine +
        "Please see the Readthis.htm file for more information." + Environment.NewLine + 
        "Also see the source code (for the procedure cmdReceiveImageFile_Click) to remove this warning after the security settings have been adjusted.";
        
		FileStream fs = null;    //' To access the local file;
        WebRequest req;
        StreamReader sr;

		try 
		{
			// This sets up the Request instance
            req = WebRequest.Create("http://localhost/SendAndReceiveDataWebPages/ReceiveData.aspx");
            // Use a GET since no data is being sent to the web server
            req.Method = "GET";
            // This causes the round-trip
            WebResponse rsp = req.GetResponse();
			try 
			{
				// Open the file to stream in the content
				fs = new FileStream("ReceivedXMLFile.xml", FileMode.Create);
				// Copy the content from the response stream to the file.
				CopyData(rsp.GetResponseStream(), fs);
			}
			catch( Exception exp)
			{
				// Will catch any error that we're not explicitly trapping.
				MessageBox.Show(exp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
            finally
			{
                // Guarantee the streams will be closed
                if (rsp != null)  rsp.GetResponseStream().Close();
                if (fs != null)  fs.Close();
            }
            MessageBox.Show("Receive of data file completed successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		catch( Exception exp)
		{
            // Will catch any error that we're not explicitly trapping.
            MessageBox.Show(exp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }

    private void cmdReceiveImageFile_Click(object sender, System.EventArgs e) 
	{
        // This method requests and receives an image from a website. The file 
        // is streamed back to this method, which copies the contents into a 
        // MemoryStream, then associates the MemoryStream with a PictureBox on 
        // the form. The contents are streamed using the ResponseStream of the 
        // WebResponse class. The stream access is wrapped in try {/catch blocks 
        // to ensure timely release of the resources.
        string strMsg = "In order to run this part of the sample, you must adjust the security settings" + 
         " for the physical directory that contains the ASPX files." + Environment.NewLine + Environment.NewLine + 
         "Please see the Readthis.htm file for more information." + Environment.NewLine + 
         "Also see the source code (for the procedure cmdReceiveImageFile_Click) to remove this warning after the security settings have been adjusted.";
        
		WebRequest req = null;   //' used to get the stream back from the server;
       MemoryStream ms = null;   //' used to move the image into the PictureBox;
			
        try 
		{
            // You could use the following line listed below *IF* you knew the name + location
            // of the image. The example provided here has the server 'pick' the image.
            // req = WebRequest.Create("http://localhost/vDir1/mypic.jpg")
            // This creates the WebRequest object
            req = WebRequest.Create("http://localhost/SendAndReceiveDataWebPages/ReceiveImage.aspx");
            // Use a GET since we' re not sending any data
            req.Method = "GET";
            // ObjRef to get the server's response.
            WebResponse rsp = null;

			try 
			{
				// This causes the round-trip to retrieve the image.
				rsp = req.GetResponse();
				// Create a MemoryStream to hold the image
				ms = new MemoryStream();
				
				// Copy the streamed image into the MemoryStream
				CopyData(rsp.GetResponseStream(), ms);
				// Load the image into the PictureBox
				picDownloadImage.Image = Image.FromStream(ms);
				
				MessageBox.Show("Image file received successfully!", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch( Exception exp)
			{
				// Will catch any error that we're not explicitly trapping.
				MessageBox.Show(exp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
			}
			finally
			{
				// Guarantee the streams will be closed
				if ( ms != null) ms.Close();
				if ( rsp != null) rsp.GetResponseStream().Close();
			}
		} 
		catch( Exception exp)
		{
            // Will catch any error that we're not explicitly trapping.
            MessageBox.Show(exp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Stop);
        }
    }

    private void cmdSendFileData_Click(object sender, System.EventArgs e) 
	{
        // This method takes a local file named datafile.txt and sends its 
        // contents via a WebRequest to a website. The contents are sent via
        // HTTP using the Request stream of the WebRequest object. The file
        // is accessed using a FileStream.
        string strMsg = "In order to run this part of the sample, you must adjust the security settings" + 
         " for the physical directory that contains the ASPX files." + Environment.NewLine + Environment.NewLine +
         "Please see the Readthis.htm file for more information." + Environment.NewLine + 
         "Also see the source code (for the procedure cmdSendFileData_Click) to remove this warning after the security settings have been adjusted.";

        FileStream fs = null;    //' To access the local file;
        WebRequest req = null;    //' Reference to the Webrequest;
        // Wrap the stream access in a try {/Finally block to guarantee a timely 
        // release of the stream resources.

		try 
		{
			// Access the file
			fs = new FileStream("..//..//DataFile.txt", FileMode.Open);
			// Create the WebRequest instance
			req = WebRequest.Create("http://localhost/SendAndReceiveDataWebPages/SendData.aspx");
			// Use POST since we're sending content in the body.
			req.Method = "POST";
			// Copy from the file into the RequestStream
			CopyData(fs, req.GetRequestStream());
		} 
		catch( Exception exp)
		{
			MessageBox.Show(exp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
			return;
		}
        finally
		{
            try
			{
                // Guarantee the streams will be closed
                if (req != null)  req.GetRequestStream().Close();
                if (fs != null)  fs.Close();
            } 
			catch
			{
                // Eat the error if we get one
            }
        }

        WebResponse rsp = null;

		try
		{
			// This actually sends the data to the Web Server
			rsp = req.GetResponse();
			if (Convert.ToDouble(rsp.Headers["Content-Length"]) == 0) 
			{
				MessageBox.Show("Data Sent Sucessfully.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
		}
		catch( Exception exp)
		{
			MessageBox.Show(exp.Message, this.Text, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
        finally
		{
            try
			{
                if ( rsp != null) rsp.Close();
            }
			catch{ 
            }
        }
    }

    private  void CopyData(Stream FromStream, Stream ToStream)
	{
        // This routine copies content from one stream to another, regardless
        // of the media represented by the stream.
        // This will track the # bytes read from the FromStream
        int intBytesRead;
        // The maximum size of each read
        const int intSize = 4096;
        Byte[] bytes = new Byte[intSize];
        // Read the first bit of content, then write and read all the content
        // From the FromStream to the ToStream.
        intBytesRead = FromStream.Read(bytes, 0, intSize);

        while (intBytesRead > 0)
		{
            ToStream.Write(bytes, 0, intBytesRead);
            intBytesRead = FromStream.Read(bytes, 0, intSize);
        }
		
    }
}

