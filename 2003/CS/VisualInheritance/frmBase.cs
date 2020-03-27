//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Data;

public class frmBase: System.Windows.Forms.Form {

    // Initialize constants for connecting to the database
    // and displaying a connection error to the user.

    protected const string SQL_CONNECTION_STRING = "Server=localhost;" + 
		"DataBase=Northwind;Integrated Security=SSPI";

    protected const string MSDE_CONNECTION_STRING = @"Server=(local)\NetSDK;" +
        "DataBase=Northwind;Integrated Security=SSPI";

    protected const string CONNECTION_ERROR_MSG = "To run this sample, you must have SQL " +
		"or MSDE with the Northwind database installed.  For " + 
        "instructions on installing MSDE, view the ReadMe file.";

    static bool DidPreviouslyConnect = false;
    protected bool DidCreateTable = false;
    static string connectionstring = SQL_CONNECTION_STRING;

#region " Windows Form Designer generated code "

    public frmBase () {

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

    protected System.Windows.Forms.Label lblTitle;

    protected System.Windows.Forms.Button btnClose;

    private System.Windows.Forms.PictureBox PictureBox1;

    protected System.Windows.Forms.Label lblProtected;

    private System.Windows.Forms.Label lblPrivate;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmBase));

        this.lblTitle = new System.Windows.Forms.Label();

        this.btnClose = new System.Windows.Forms.Button();

        this.PictureBox1 = new System.Windows.Forms.PictureBox();

        this.lblProtected = new System.Windows.Forms.Label();

        this.lblPrivate = new System.Windows.Forms.Label();

        this.SuspendLayout();

        //

        //lblTitle

        //

        this.lblTitle.AccessibleDescription = resources.GetString("lblTitle.AccessibleDescription");

        this.lblTitle.AccessibleName = resources.GetString("lblTitle.AccessibleName");

        this.lblTitle.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblTitle.Anchor");

        this.lblTitle.AutoSize = (bool) resources.GetObject("lblTitle.AutoSize");

        this.lblTitle.BackColor = System.Drawing.SystemColors.Control;

        this.lblTitle.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblTitle.Dock");

        this.lblTitle.Enabled = (bool) resources.GetObject("lblTitle.Enabled");

        this.lblTitle.Font = (System.Drawing.Font) resources.GetObject("lblTitle.Font");

        this.lblTitle.ForeColor = System.Drawing.SystemColors.ControlText;

        this.lblTitle.Image = (System.Drawing.Image) resources.GetObject("lblTitle.Image");

        this.lblTitle.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblTitle.ImageAlign");

        this.lblTitle.ImageIndex = (int) resources.GetObject("lblTitle.ImageIndex");

        this.lblTitle.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblTitle.ImeMode");

        this.lblTitle.Location = (System.Drawing.Point) resources.GetObject("lblTitle.Location");

        this.lblTitle.Name = "lblTitle";

        this.lblTitle.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblTitle.RightToLeft");

        this.lblTitle.Size = (System.Drawing.Size) resources.GetObject("lblTitle.Size");

        this.lblTitle.TabIndex = (int) resources.GetObject("lblTitle.TabIndex");

        this.lblTitle.Text = resources.GetString("lblTitle.Text");

        this.lblTitle.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblTitle.TextAlign");

        this.lblTitle.Visible = (bool) resources.GetObject("lblTitle.Visible");

        //

        //btnClose

        //

        this.btnClose.AccessibleDescription = resources.GetString("btnClose.AccessibleDescription");

        this.btnClose.AccessibleName = resources.GetString("btnClose.AccessibleName");

        this.btnClose.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnClose.Anchor");

        this.btnClose.BackColor = System.Drawing.SystemColors.Control;

        this.btnClose.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnClose.BackgroundImage");

        this.btnClose.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnClose.Dock");

        this.btnClose.Enabled = (bool) resources.GetObject("btnClose.Enabled");

        this.btnClose.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnClose.FlatStyle");

        this.btnClose.Font = (System.Drawing.Font) resources.GetObject("btnClose.Font");

        this.btnClose.ForeColor = System.Drawing.SystemColors.ControlText;

        this.btnClose.Image = (System.Drawing.Image) resources.GetObject("btnClose.Image");

        this.btnClose.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnClose.ImageAlign");

        this.btnClose.ImageIndex = (int) resources.GetObject("btnClose.ImageIndex");

        this.btnClose.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnClose.ImeMode");

        this.btnClose.Location = (System.Drawing.Point) resources.GetObject("btnClose.Location");

        this.btnClose.Name = "btnClose";

        this.btnClose.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnClose.RightToLeft");

        this.btnClose.Size = (System.Drawing.Size) resources.GetObject("btnClose.Size");

        this.btnClose.TabIndex = (int) resources.GetObject("btnClose.TabIndex");

        this.btnClose.Text = resources.GetString("btnClose.Text");

        this.btnClose.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnClose.TextAlign");

        this.btnClose.Visible = (bool) resources.GetObject("btnClose.Visible");

        //

        //PictureBox1

        //

        this.PictureBox1.AccessibleDescription = resources.GetString("PictureBox1.AccessibleDescription");

        this.PictureBox1.AccessibleName = resources.GetString("PictureBox1.AccessibleName");

        this.PictureBox1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("PictureBox1.Anchor");

        this.PictureBox1.BackgroundImage = (System.Drawing.Image) resources.GetObject("PictureBox1.BackgroundImage");

        this.PictureBox1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("PictureBox1.Dock");

        this.PictureBox1.Enabled = (bool) resources.GetObject("PictureBox1.Enabled");

        this.PictureBox1.Font = (System.Drawing.Font) resources.GetObject("PictureBox1.Font");

        this.PictureBox1.Image = (System.Drawing.Bitmap) resources.GetObject("PictureBox1.Image");

        this.PictureBox1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("PictureBox1.ImeMode");

        this.PictureBox1.Location = (System.Drawing.Point) resources.GetObject("PictureBox1.Location");

        this.PictureBox1.Name = "PictureBox1";

        this.PictureBox1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("PictureBox1.RightToLeft");

        this.PictureBox1.Size = (System.Drawing.Size) resources.GetObject("PictureBox1.Size");

        this.PictureBox1.SizeMode = (System.Windows.Forms.PictureBoxSizeMode) resources.GetObject("PictureBox1.SizeMode");

        this.PictureBox1.TabIndex = (int) resources.GetObject("PictureBox1.TabIndex");

        this.PictureBox1.TabStop = false;

        this.PictureBox1.Text = resources.GetString("PictureBox1.Text");

        this.PictureBox1.Visible = (bool) resources.GetObject("PictureBox1.Visible");

        //

        //lblProtected

        //

        this.lblProtected.AccessibleDescription = resources.GetString("lblProtected.AccessibleDescription");

        this.lblProtected.AccessibleName = resources.GetString("lblProtected.AccessibleName");

        this.lblProtected.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblProtected.Anchor");

        this.lblProtected.AutoSize = (bool) resources.GetObject("lblProtected.AutoSize");

        this.lblProtected.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblProtected.Dock");

        this.lblProtected.Enabled = (bool) resources.GetObject("lblProtected.Enabled");

        this.lblProtected.Font = (System.Drawing.Font) resources.GetObject("lblProtected.Font");

        this.lblProtected.Image = (System.Drawing.Image) resources.GetObject("lblProtected.Image");

        this.lblProtected.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblProtected.ImageAlign");

        this.lblProtected.ImageIndex = (int) resources.GetObject("lblProtected.ImageIndex");

        this.lblProtected.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblProtected.ImeMode");

        this.lblProtected.Location = (System.Drawing.Point) resources.GetObject("lblProtected.Location");

        this.lblProtected.Name = "lblProtected";

        this.lblProtected.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblProtected.RightToLeft");

        this.lblProtected.Size = (System.Drawing.Size) resources.GetObject("lblProtected.Size");

        this.lblProtected.TabIndex = (int) resources.GetObject("lblProtected.TabIndex");

        this.lblProtected.Text = resources.GetString("lblProtected.Text");

        this.lblProtected.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblProtected.TextAlign");

        this.lblProtected.Visible = (bool) resources.GetObject("lblProtected.Visible");

        //

        //lblPrivate

        //

        this.lblPrivate.AccessibleDescription = resources.GetString("lblPrivate.AccessibleDescription");

        this.lblPrivate.AccessibleName = resources.GetString("lblPrivate.AccessibleName");

        this.lblPrivate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblPrivate.Anchor");

        this.lblPrivate.AutoSize = (bool) resources.GetObject("lblPrivate.AutoSize");

        this.lblPrivate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblPrivate.Dock");

        this.lblPrivate.Enabled = (bool) resources.GetObject("lblPrivate.Enabled");

        this.lblPrivate.Font = (System.Drawing.Font) resources.GetObject("lblPrivate.Font");

        this.lblPrivate.Image = (System.Drawing.Image) resources.GetObject("lblPrivate.Image");

        this.lblPrivate.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblPrivate.ImageAlign");

        this.lblPrivate.ImageIndex = (int) resources.GetObject("lblPrivate.ImageIndex");

        this.lblPrivate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblPrivate.ImeMode");

        this.lblPrivate.Location = (System.Drawing.Point) resources.GetObject("lblPrivate.Location");

        this.lblPrivate.Name = "lblPrivate";

        this.lblPrivate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblPrivate.RightToLeft");

        this.lblPrivate.Size = (System.Drawing.Size) resources.GetObject("lblPrivate.Size");

        this.lblPrivate.TabIndex = (int) resources.GetObject("lblPrivate.TabIndex");

        this.lblPrivate.Text = resources.GetString("lblPrivate.Text");

        this.lblPrivate.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblPrivate.TextAlign");

        this.lblPrivate.Visible = (bool) resources.GetObject("lblPrivate.Visible");

        //

        //frmBase

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblPrivate, this.lblProtected, this.PictureBox1, this.btnClose, this.lblTitle});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

        this.MaximizeBox = false;

        this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

        this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

        this.Name = "frmBase";

        this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

        this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

        this.Text = resources.GetString("$this.Text");

        this.Visible = (bool) resources.GetObject("$this.Visible");

        this.ResumeLayout(false);

		base.Load +=new EventHandler(frmBase_Load);

    }

#endregion

    // Creates a connection to the database and uses a SqlDataAdapter
    // object to fill a DataSet.


    protected DataSet GetDataSource()
		{
        
        // Display a status message saying that we're attempting to connect.
        // This only needs to be done the very first time a connection is
        // attempted.  After we've determined that MSDE or SQL Server is
        // installed, this message no longer needs to be displayed.

        frmStatus frmStatusMessage = new frmStatus();
		DataSet dsProducts = null;

        if (!DidPreviouslyConnect) {

            frmStatusMessage.Show("Connecting to SQL Server");

        }

        // Attempt to connect to the local SQL server instance, and a local
        // MSDE installation (with Northwind).  

        bool IsConnecting = true;

        while (IsConnecting)
			{
            try {
                // The SqlConnection class allows you to communicate with SQL Server.
                // The constructor accepts a connection string an argument.  This
                // connection string uses Integrated Security, which means that you 
                // must have a login in SQL Server, or be part of the Administrators
                // group for this to work.

                SqlConnection cnNorthwind = new SqlConnection(connectionstring);

                // The SqlDataAdapter is used to move data between SQL Server, 
                // and a DataSet.

                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT ProductID, ProductName, UnitPrice, UnitsInStock " +
                    "FROM products", cnNorthwind);

                dsProducts = new DataSet();

                // Populate the Dataset with the information from the products
                // table.  Since a Dataset can hold multiple result sets, it's
                // a good idea to "name" the result set when you populate the
                // DataSet.  In this case, the result set is named "Products".

                da.Fill(dsProducts, "Products");

                // Data has been successfully retrieved, so break out of the loop
                // and close the status form.

                IsConnecting = false;
                DidPreviouslyConnect = true;
                frmStatusMessage.Close();

           } catch
			{
                if (connectionstring == SQL_CONNECTION_STRING) {

                    // Couldn't connect to SQL Server.  Now try MSDE.

                    connectionstring = MSDE_CONNECTION_STRING;
                    frmStatusMessage.Show("Connecting to MSDE");
					}
                else {

                    // Unable to connect to SQL Server or MSDE

                    frmStatusMessage.Close();
                    MessageBox.Show("To run this sample, you must have SQL " +
                        "or MSDE with the Northwind database installed.  For " + 
                        "instructions on installing MSDE, view the ReadMe file.",
                        "Connection Problem", MessageBoxButtons.OK, 
                        MessageBoxIcon.Error);
					Application.Exit();
                }
				
            }
			
        }
		
        frmStatusMessage.Close();
		return dsProducts;
    }

    private void frmBase_Load(object sender, System.EventArgs e)
	{

    }

}

