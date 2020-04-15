//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Data;

public class DataGridControl : System.Windows.Forms.UserControl
{
#region " Windows Form Designer generated code "

    public DataGridControl() 
	{
        //This call is required by the Windows Form Designer.
        InitializeComponent();
        //Add any initialization after the InitializeComponent() call
    }

    //UserControl1 overrides dispose to clean up the component list.
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
    internal System.Windows.Forms.DataGrid dgData;

    private void InitializeComponent() {

        this.dgData = new System.Windows.Forms.DataGrid();

        ((System.ComponentModel.ISupportInitialize) (this.dgData)).BeginInit();

        this.SuspendLayout();

        //

        //dgData

        //

        this.dgData.AllowNavigation = false;

        this.dgData.DataMember = string.Empty;

        this.dgData.Dock = System.Windows.Forms.DockStyle.Fill;

        this.dgData.HeaderForeColor = System.Drawing.SystemColors.ControlText;

        this.dgData.Name = "dgData";

        this.dgData.ReadOnly = true;

        this.dgData.Size = new System.Drawing.Size(584, 150);

        this.dgData.TabIndex = 0;

        //

        //DataGridControl

        //

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.dgData});

        this.Name = "DataGridControl";

        this.Size = new System.Drawing.Size(584, 150);

        ((System.ComponentModel.ISupportInitialize) (this.dgData)).EndInit();

        this.ResumeLayout(false);

    }

#endregion

    protected string m_FileName;

    public string FileName
	{
        // Read/Write FileName property for use by
        // data access procedures.
        get {
            // Read FileName
            return m_FileName;
        }
        set {
            // Write FileName
            m_FileName = value;
        }
    }

    public void BindCustomers()
	{
        // Access the DataAccessComponent directly,
        // populate the DataGrid with the results.
        // Hides the details from the developer using
        // this control.  if a new object was created 
        // this code could change without affecting 
        // any apps that use this control.
        DataTable dtCustomers;
        // Instantiate the data access object
        Business oBusiness = new Business();
        // Pass the filename to open
        oBusiness.FileName = m_FileName;
        // Get a DataTable containing the customers
        // in the file
        dtCustomers = oBusiness.GetCustomers();
        // Display results
        dgData.SetDataBinding(dtCustomers, "");
    }
}

