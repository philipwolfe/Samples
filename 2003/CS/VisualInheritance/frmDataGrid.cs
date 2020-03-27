//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Data;
using System;
using System.Windows.Forms;
using System.Drawing;

public class frmDataGrid: frmBase
{

#region " Windows Form Designer generated code "

    public frmDataGrid () {

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

    private System.Windows.Forms.DataGrid dgProducts;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDataGrid));

        this.dgProducts = new System.Windows.Forms.DataGrid();

        ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).BeginInit();

        this.SuspendLayout();

        //

        //lblProtected

        //

        this.lblProtected.Visible = (bool) resources.GetObject("lblProtected.Visible");

        //

        //dgProducts

        //

        this.dgProducts.AccessibleDescription = resources.GetString("dgProducts.AccessibleDescription");

        this.dgProducts.AccessibleName = resources.GetString("dgProducts.AccessibleName");

        this.dgProducts.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("dgProducts.Anchor");

        this.dgProducts.BackgroundColor = System.Drawing.SystemColors.ActiveBorder;

        this.dgProducts.BackgroundImage = (System.Drawing.Image) resources.GetObject("dgProducts.BackgroundImage");

        this.dgProducts.CaptionFont = (System.Drawing.Font) resources.GetObject("dgProducts.CaptionFont");

        this.dgProducts.CaptionText = resources.GetString("dgProducts.CaptionText");

        this.dgProducts.DataMember = string.Empty;

        this.dgProducts.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("dgProducts.Dock");

        this.dgProducts.Enabled = (bool) resources.GetObject("dgProducts.Enabled");

        this.dgProducts.Font = (System.Drawing.Font) resources.GetObject("dgProducts.Font");

        this.dgProducts.HeaderForeColor = System.Drawing.SystemColors.ControlText;

        this.dgProducts.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("dgProducts.ImeMode");

        this.dgProducts.Location = (System.Drawing.Point) resources.GetObject("dgProducts.Location");

        this.dgProducts.Name = "dgProducts";

        this.dgProducts.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("dgProducts.RightToLeft");

        this.dgProducts.Size = (System.Drawing.Size) resources.GetObject("dgProducts.Size");

        this.dgProducts.TabIndex = (int) resources.GetObject("dgProducts.TabIndex");

        this.dgProducts.Visible = (bool) resources.GetObject("dgProducts.Visible");

        //

        //frmDataGrid

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblProtected, this.dgProducts});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

        this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

        this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

        this.Name = "frmDataGrid";

        this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

        this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

        this.Text = resources.GetString("$this.Text");

        this.Visible = (bool) resources.GetObject("$this.Visible");

        ((System.ComponentModel.ISupportInitialize)(this.dgProducts)).EndInit();

        this.ResumeLayout(false);

		base.Load +=new System.EventHandler(frmDataGrid_Load);
		base.btnClose.Click +=new EventHandler(btnClose_Click);

    }

#endregion

    // the Close button click event.

    private void btnClose_Click(object sender, System.EventArgs e) 
		//btnClose.Click;
		{

        this.Close();

    }

    // the Form load event, which displays the data in the DataGrid.

    private void frmDataGrid_Load(object sender, System.EventArgs e)
	{

            dgProducts.CaptionText = "Northwind Products";
            dgProducts.DataSource = GetDataSource().Tables[0];

        // Use a table style object to apply custom formatting to the DataGrid.

        DataGridTableStyle dgTableStyle1 = new DataGridTableStyle();

            dgTableStyle1.AlternatingBackColor = Color.Lavender;
            dgTableStyle1.BackColor = Color.WhiteSmoke;
            dgTableStyle1.ForeColor = Color.MidnightBlue;
            dgTableStyle1.GridLineColor = Color.Gainsboro;
            dgTableStyle1.GridLineStyle = System.Windows.Forms.DataGridLineStyle.None;
            dgTableStyle1.HeaderBackColor = Color.MidnightBlue;
            dgTableStyle1.HeaderFont = new Font("Tahoma", (float)8.0, FontStyle.Bold);
            dgTableStyle1.HeaderForeColor = Color.WhiteSmoke;
            dgTableStyle1.LinkColor = Color.Teal;

            // Do not forget to set the MappingName property. 
            // Without this, the DataGridTableStyle properties
            // and any associated DataGridColumnStyle objects
            // will have no effect.

            dgTableStyle1.MappingName = "Products";
            dgTableStyle1.SelectionBackColor = Color.CadetBlue;
            dgTableStyle1.SelectionForeColor = Color.WhiteSmoke;

        // Use column style objects to apply formatting specific to each column.

        DataGridTextBoxColumn grdColStyle1 = new DataGridTextBoxColumn();

        grdColStyle1.HeaderText = "ID#";
        grdColStyle1.MappingName = "ProductID";
        grdColStyle1.Width = 50;

        DataGridTextBoxColumn grdColStyle2 = new DataGridTextBoxColumn();
        grdColStyle2.HeaderText = "Name";
        grdColStyle2.MappingName = "ProductName";
        grdColStyle2.Width = 225;
        
        DataGridTextBoxColumn grdColStyle3 = new DataGridTextBoxColumn();
        grdColStyle3.HeaderText = "Price";
        grdColStyle3.MappingName = "UnitPrice";
        grdColStyle3.Width = 70;

        DataGridTextBoxColumn grdColStyle4 = new DataGridTextBoxColumn();
        grdColStyle4.HeaderText = "# in Stock";
        grdColStyle4.MappingName = "UnitsInStock";
        grdColStyle4.Width = 70;

        // Add the column style objects to the tables style's column styles 
        // collection. if you fail to do this the column styles will not apply.

        dgTableStyle1.GridColumnStyles.AddRange(new DataGridColumnStyle[]
            {grdColStyle1, grdColStyle2, grdColStyle3, grdColStyle4});

        // Add the table style object to the DataGrid's table styles collection.
        // Again, failure to add the style to the collection will cause the style
        // to not take effect.

        dgProducts.TableStyles.Add(dgTableStyle1);

        // Set the Form's title in the inherited Label control.

        lblTitle.Text = "Inherited Form with DataGrid";

    }

}

