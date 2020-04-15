//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;

public class frmControls : System.Windows.Forms.Form 
{
#region " Windows Form Designer generated code "

    public frmControls()
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
    private System.Windows.Forms.TextBox txtDockedBottom;

    private System.Windows.Forms.TextBox TextBox2;

    private System.Windows.Forms.TextBox TextBox1;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.TextBox txtCSZ;

    private System.Windows.Forms.TextBox txtAddress;

    private System.Windows.Forms.TextBox txtName;

    private void InitializeComponent() {

        this.txtDockedBottom = new System.Windows.Forms.TextBox();

        this.TextBox2 = new System.Windows.Forms.TextBox();

        this.TextBox1 = new System.Windows.Forms.TextBox();

        this.Label3 = new System.Windows.Forms.Label();

        this.Label2 = new System.Windows.Forms.Label();

        this.Label1 = new System.Windows.Forms.Label();

        this.txtCSZ = new System.Windows.Forms.TextBox();

        this.txtAddress = new System.Windows.Forms.TextBox();

        this.txtName = new System.Windows.Forms.TextBox();

        this.SuspendLayout();

        //

        //txtDockedBottom

        //

        this.txtDockedBottom.Dock = System.Windows.Forms.DockStyle.Bottom;

        this.txtDockedBottom.Location = new System.Drawing.Point(0, 165);

        this.txtDockedBottom.Multiline = true;

        this.txtDockedBottom.Name = "txtDockedBottom";

        this.txtDockedBottom.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;

        this.txtDockedBottom.Size = new System.Drawing.Size(568, 184);

        this.txtDockedBottom.TabIndex = 8;

        this.txtDockedBottom.Text = string.Empty;

        //

        //TextBox2

        //

        this.TextBox2.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);

        this.TextBox2.Location = new System.Drawing.Point(384, 128);

        this.TextBox2.Name = "TextBox2";

        this.TextBox2.Size = new System.Drawing.Size(56, 20);

        this.TextBox2.TabIndex = 6;

        this.TextBox2.Text = string.Empty;

        //

        //TextBox1

        //

        this.TextBox1.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);

        this.TextBox1.Location = new System.Drawing.Point(448, 128);

        this.TextBox1.Name = "TextBox1";

        this.TextBox1.Size = new System.Drawing.Size(104, 20);

        this.TextBox1.TabIndex = 7;

        this.TextBox1.Text = string.Empty;

        //

        //Label3

        //

        this.Label3.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);

        this.Label3.AutoSize = true;

        this.Label3.Location = new System.Drawing.Point(8, 128);

        this.Label3.Name = "Label3";

        this.Label3.Size = new System.Drawing.Size(78, 13);

        this.Label3.TabIndex = 4;

        this.Label3.Text = "City, State, Zip";

        //

        //Label2

        //

        this.Label2.AutoSize = true;

        this.Label2.Location = new System.Drawing.Point(8, 40);

        this.Label2.Name = "Label2";

        this.Label2.Size = new System.Drawing.Size(46, 13);

        this.Label2.TabIndex = 2;

        this.Label2.Text = "Address";

        //

        //Label1

        //

        this.Label1.AutoSize = true;

        this.Label1.Location = new System.Drawing.Point(8, 16);

        this.Label1.Name = "Label1";

        this.Label1.Size = new System.Drawing.Size(34, 13);

        this.Label1.TabIndex = 0;

        this.Label1.Text = "Name";

        //

        //txtCSZ

        //

        this.txtCSZ.Anchor = ((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
                    | System.Windows.Forms.AnchorStyles.Right);

        this.txtCSZ.Location = new System.Drawing.Point(88, 128);

        this.txtCSZ.Name = "txtCSZ";

        this.txtCSZ.Size = new System.Drawing.Size(288, 20);

        this.txtCSZ.TabIndex = 5;

        this.txtCSZ.Text = string.Empty;

        //

        //txtAddress

        //

        this.txtAddress.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                    | System.Windows.Forms.AnchorStyles.Left) 
                    | System.Windows.Forms.AnchorStyles.Right);

        this.txtAddress.Location = new System.Drawing.Point(88, 40);

        this.txtAddress.Multiline = true;

        this.txtAddress.Name = "txtAddress";

        this.txtAddress.Size = new System.Drawing.Size(464, 80);

        this.txtAddress.TabIndex = 3;

        this.txtAddress.Text = string.Empty;

        //

        //txtName

        //

        this.txtName.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left)
                    | System.Windows.Forms.AnchorStyles.Right);

        this.txtName.Location = new System.Drawing.Point(88, 16);

        this.txtName.Name = "txtName";

        this.txtName.Size = new System.Drawing.Size(464, 20);

        this.txtName.TabIndex = 1;

        this.txtName.Text = string.Empty;

        //

        //frmControls

        //

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

        this.ClientSize = new System.Drawing.Size(568, 349);

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.TextBox2, this.TextBox1, this.Label3, this.Label2, this.Label1, this.txtCSZ, this.txtAddress, this.txtName, this.txtDockedBottom});

        this.Name = "frmControls";

        this.Text = "Anchoring and Docked Controls";

        this.ResumeLayout(false);
		this.Load += new EventHandler(frmControls_Load);
    }

#endregion

    private void frmControls_Load(object sender, System.EventArgs e) 
	{
        txtDockedBottom.Text = "The Name textbox is anchored to the Top, Left and Right. It will automatically resize with the form, maintaining its relative position to those three points." + Environment.NewLine + Environment.NewLine;
        txtDockedBottom.Text += "The Address multiline textbox is anchored to the Top, Bottom, Left and Right. It will automatically resize all its dimensions with the form." + Environment.NewLine + Environment.NewLine;
        txtDockedBottom.Text += "The City textbox is anchored to the Bottom, Left and Right. The State and Zip textboxes are anchored to the Bottom and Right." + Environment.NewLine + Environment.NewLine;
        txtDockedBottom.Text += "This multiline text box is docked to the bottom of the form. It will maintain its original size and stay docked to the bottom when the form is resized. Docking " + "'" + "glues" + "'" + " a control to one or more edges of the form.";
    }
}

