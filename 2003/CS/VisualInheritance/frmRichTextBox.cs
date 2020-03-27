//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Text;
using System;
using System.Data;

public class frmRichTextBox:frmBase
{

#region " Windows Form Designer generated code "

    public frmRichTextBox() {

        

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

    private System.Windows.Forms.RichTextBox rtbProducts;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmRichTextBox));

        this.rtbProducts = new System.Windows.Forms.RichTextBox();

        this.SuspendLayout();

        //

        //lblProtected

        //

        this.lblProtected.Visible = (bool) resources.GetObject("lblProtected.Visible");

        //

        //rtbProducts

        //

        this.rtbProducts.AccessibleDescription = resources.GetString("rtbProducts.AccessibleDescription");

        this.rtbProducts.AccessibleName = resources.GetString("rtbProducts.AccessibleName");

        this.rtbProducts.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("rtbProducts.Anchor");

        this.rtbProducts.AutoSize = (bool) resources.GetObject("rtbProducts.AutoSize");

        this.rtbProducts.BackgroundImage = (System.Drawing.Image) resources.GetObject("rtbProducts.BackgroundImage");

        this.rtbProducts.BulletIndent = (int) resources.GetObject("rtbProducts.BulletIndent");

        this.rtbProducts.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("rtbProducts.Dock");

        this.rtbProducts.Enabled = (bool) resources.GetObject("rtbProducts.Enabled");

        this.rtbProducts.Font = (System.Drawing.Font) resources.GetObject("rtbProducts.Font");

        this.rtbProducts.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("rtbProducts.ImeMode");

        this.rtbProducts.Location = (System.Drawing.Point) resources.GetObject("rtbProducts.Location");

        this.rtbProducts.MaxLength = (int) resources.GetObject("rtbProducts.MaxLength");

        this.rtbProducts.Multiline = (bool) resources.GetObject("rtbProducts.Multiline");

        this.rtbProducts.Name = "rtbProducts";

        this.rtbProducts.RightMargin = (int) resources.GetObject("rtbProducts.RightMargin");

        this.rtbProducts.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("rtbProducts.RightToLeft");

        this.rtbProducts.ScrollBars = (System.Windows.Forms.RichTextBoxScrollBars) resources.GetObject("rtbProducts.ScrollBars");

        this.rtbProducts.Size = (System.Drawing.Size) resources.GetObject("rtbProducts.Size");

        this.rtbProducts.TabIndex = (int) resources.GetObject("rtbProducts.TabIndex");

        this.rtbProducts.Text = resources.GetString("rtbProducts.Text");

        this.rtbProducts.Visible = (bool) resources.GetObject("rtbProducts.Visible");

        this.rtbProducts.WordWrap = (bool) resources.GetObject("rtbProducts.WordWrap");

        this.rtbProducts.ZoomFactor = (float) resources.GetObject("rtbProducts.ZoomFactor");

        //

        //frmRichTextBox

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblProtected, this.rtbProducts});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

        this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

        this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

        this.Name = "frmRichTextBox";

        this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

        this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

        this.Text = resources.GetString("$this.Text");

        this.Visible = (bool) resources.GetObject("$this.Visible");

        this.ResumeLayout(false);
		
		base.Load +=new System.EventHandler(frmRichTextBox_Load);
		base.btnClose.Click +=new EventHandler(btnClose_Click);
    }

#endregion

    // the Close button click event.

    private void btnClose_Click(object sender, System.EventArgs e) 
		//btnClose.Click;
		{
        this.Close();

    }

    // the Form load event.

    private void frmRichTextBox_Load(object sender, System.EventArgs e)
	{

        // Get a DataSet

        DataSet ds = GetDataSource();

        // Instead of traditional string concatenation, use the new stringBuilder
        // class which is optimized for concatenation it can modify the buffer
        // instead of having to make a copy of the string for each concatenation.
        StringBuilder sb =  new StringBuilder();

        // Set the first row of column headers.

        sb.Append("=======================================================");

        sb.Append(Environment.NewLine);

        sb.Append("ID");

        sb.Append("\t");

        sb.Append("Name");

        sb.Append(Environment.NewLine);

        sb.Append("=======================================================");

        sb.Append(Environment.NewLine);

        // Loop through the rows in the Dataset and append them using the 

        // stringBuilder.

        foreach(DataRow dr in ds.Tables[0].Rows)
			{

            sb.Append(dr["ProductID"]);

            sb.Append("\t");

            sb.Append(dr["ProductName"]);

            sb.Append(Environment.NewLine);

        }

        // Convert the contents of the stringBuilder object to Text for display

        // in the RichTextBox.

        rtbProducts.Text = sb.ToString();

        // Set the Form's title in the inherited Label control.

        lblTitle.Text = "Inherited Form with RichTextBox";

    }

}

