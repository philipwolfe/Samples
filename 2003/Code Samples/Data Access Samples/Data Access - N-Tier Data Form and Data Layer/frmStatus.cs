//Copyright (C) 2002 Microsoft Corporation

//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;

public class frmStatus:System.Windows.Forms.Form 
{

#region " Windows Form Designer generated code "

    public frmStatus() 
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

    private System.Windows.Forms.Label lblStatus;

    private void InitializeComponent() 
	{

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmStatus));
        this.lblStatus = new System.Windows.Forms.Label();
        this.SuspendLayout();

        //

        //lblStatus

        //

        this.lblStatus.AccessibleDescription = (string) resources.GetObject("lblStatus.AccessibleDescription");

        this.lblStatus.AccessibleName = (string) resources.GetObject("lblStatus.AccessibleName");

        this.lblStatus.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblStatus.Anchor");

        this.lblStatus.AutoSize = (bool) resources.GetObject("lblStatus.AutoSize");

        this.lblStatus.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblStatus.Dock");

        this.lblStatus.Enabled = (bool) resources.GetObject("lblStatus.Enabled");

        this.lblStatus.Font = (System.Drawing.Font) resources.GetObject("lblStatus.Font");

        this.lblStatus.Image = (System.Drawing.Image) resources.GetObject("lblStatus.Image");

        this.lblStatus.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblStatus.ImageAlign");

        this.lblStatus.ImageIndex = (int) resources.GetObject("lblStatus.ImageIndex");

        this.lblStatus.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblStatus.ImeMode");

        this.lblStatus.Location = (System.Drawing.Point) resources.GetObject("lblStatus.Location");

        this.lblStatus.Name = "lblStatus";

        this.lblStatus.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblStatus.RightToLeft");

        this.lblStatus.Size = (System.Drawing.Size) resources.GetObject("lblStatus.Size");

        this.lblStatus.TabIndex = (int) resources.GetObject("lblStatus.TabIndex");

        this.lblStatus.Text = resources.GetString("lblStatus.Text");

        this.lblStatus.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblStatus.TextAlign");

        this.lblStatus.Visible = (bool) resources.GetObject("lblStatus.Visible");

        //

        //frmStatus

        //

        this.AccessibleDescription = (string) resources.GetObject("$this.AccessibleDescription");

        this.AccessibleName = (string) resources.GetObject("$this.AccessibleName");

        this.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("$this.Anchor");

        this.AutoScaleBaseSize = (System.Drawing.Size) resources.GetObject("$this.AutoScaleBaseSize");

        this.AutoScroll = (bool) resources.GetObject("$this.AutoScroll");

        this.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMargin");

        this.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMinSize");

        this.BackgroundImage = (System.Drawing.Image) resources.GetObject("$this.BackgroundImage");

        this.ClientSize = (System.Drawing.Size) resources.GetObject("$this.ClientSize");

        this.ControlBox = false;

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblStatus});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

        this.MaximizeBox = false;

        this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

        this.MinimizeBox = false;

        this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

        this.Name = "frmStatus";

        this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

        this.ShowInTaskbar = false;

        this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

        this.Text = resources.GetString("$this.Text");

        this.Visible = (bool) resources.GetObject("$this.Visible");

        this.ResumeLayout(false);

    }

#endregion

    // This routine shows the Form with a message.

    public void Show(string Message)
	{
		
        lblStatus.Text = Message;
		
		try
		{
			this.Show();
		}
		catch(ObjectDisposedException e)
		{
			MessageBox.Show(e.Message);
		}

        //System.Threading.Thread.CurrentThread.Sleep(500);

       Application.DoEvents();

    }

}

