//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
//using HowTo.ImplementRoleBasedSecurityInEnterpriseServices;

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
		//This call is required by the Windows Form Designer.
		InitializeComponent();
		//Add any initialization after the InitializeComponent() call
		// So that we only need to set the title of the application once,
		// we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
		// to read the AssemblyTitle attribute.
		AssemblyInfo ainfo = new AssemblyInfo();
		this.Text = ainfo.Title;
        this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);
        SetupTips();
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

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.TabControl TabControl1;

    private System.Windows.Forms.TabPage pgeModifyData;

    private System.Windows.Forms.TabPage pgeTips;

    private System.Windows.Forms.GroupBox GroupBox1;

    private System.Windows.Forms.Label Label7;

    private System.Windows.Forms.Label Label8;

    private System.Windows.Forms.Button btnAddSupplier;

    private System.Windows.Forms.TextBox txtPhone;

    private System.Windows.Forms.TextBox txtCompanyName;

    private System.Windows.Forms.TextBox txtTips;

    private System.Windows.Forms.Button btnDeleteSupplier;

    private System.Windows.Forms.Label Label2;

    private System.Windows.Forms.Button btnUpdateSupplier;

    private System.Windows.Forms.Button btnGetSuppliers;

    private System.Windows.Forms.TextBox txtSupplierID1;

    private System.Windows.Forms.StatusBar sbrStatus;

    private System.Windows.Forms.GroupBox GroupBox3;

    private System.Windows.Forms.Label Label5;

    private System.Windows.Forms.Label Label4;

    private System.Windows.Forms.Label Label3;

    private System.Windows.Forms.Button btnAddProduct;

    private System.Windows.Forms.TextBox txtUnitPrice;

    private System.Windows.Forms.TextBox txtProductName;

    private System.Windows.Forms.Button btnDeleteProduct;

    private System.Windows.Forms.Button btnGetProducts;

    private System.Windows.Forms.Button btnUpdateProduct;

    private System.Windows.Forms.Label Label6;

    private System.Windows.Forms.TextBox txtProductID;

    private System.Windows.Forms.TextBox txtSupplierID2;

    private void InitializeComponent() {
		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));
		this.mnuMain = new System.Windows.Forms.MainMenu();
		this.mnuFile = new System.Windows.Forms.MenuItem();
		this.mnuExit = new System.Windows.Forms.MenuItem();
		this.mnuHelp = new System.Windows.Forms.MenuItem();
		this.mnuAbout = new System.Windows.Forms.MenuItem();
		this.Label1 = new System.Windows.Forms.Label();
		this.TabControl1 = new System.Windows.Forms.TabControl();
		this.pgeModifyData = new System.Windows.Forms.TabPage();
		this.GroupBox3 = new System.Windows.Forms.GroupBox();
		this.Label6 = new System.Windows.Forms.Label();
		this.txtProductID = new System.Windows.Forms.TextBox();
		this.btnUpdateProduct = new System.Windows.Forms.Button();
		this.btnGetProducts = new System.Windows.Forms.Button();
		this.btnDeleteProduct = new System.Windows.Forms.Button();
		this.Label5 = new System.Windows.Forms.Label();
		this.Label4 = new System.Windows.Forms.Label();
		this.Label3 = new System.Windows.Forms.Label();
		this.btnAddProduct = new System.Windows.Forms.Button();
		this.txtUnitPrice = new System.Windows.Forms.TextBox();
		this.txtSupplierID2 = new System.Windows.Forms.TextBox();
		this.txtProductName = new System.Windows.Forms.TextBox();
		this.GroupBox1 = new System.Windows.Forms.GroupBox();
		this.btnGetSuppliers = new System.Windows.Forms.Button();
		this.Label2 = new System.Windows.Forms.Label();
		this.txtSupplierID1 = new System.Windows.Forms.TextBox();
		this.btnUpdateSupplier = new System.Windows.Forms.Button();
		this.btnDeleteSupplier = new System.Windows.Forms.Button();
		this.Label7 = new System.Windows.Forms.Label();
		this.Label8 = new System.Windows.Forms.Label();
		this.btnAddSupplier = new System.Windows.Forms.Button();
		this.txtPhone = new System.Windows.Forms.TextBox();
		this.txtCompanyName = new System.Windows.Forms.TextBox();
		this.pgeTips = new System.Windows.Forms.TabPage();
		this.txtTips = new System.Windows.Forms.TextBox();
		this.sbrStatus = new System.Windows.Forms.StatusBar();
		this.TabControl1.SuspendLayout();
		this.pgeModifyData.SuspendLayout();
		this.GroupBox3.SuspendLayout();
		this.GroupBox1.SuspendLayout();
		this.pgeTips.SuspendLayout();
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
		// Label1
		// 
		this.Label1.AutoSize = true;
		this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.Label1.Location = new System.Drawing.Point(16, 16);
		this.Label1.Name = "Label1";
		this.Label1.Size = new System.Drawing.Size(419, 22);
		this.Label1.TabIndex = 0;
		this.Label1.Text = "Implement Role-Based Security in Enterprise Services";
		// 
		// TabControl1
		// 
		this.TabControl1.Controls.Add(this.pgeModifyData);
		this.TabControl1.Controls.Add(this.pgeTips);
		this.TabControl1.Location = new System.Drawing.Point(16, 48);
		this.TabControl1.Name = "TabControl1";
		this.TabControl1.SelectedIndex = 0;
		this.TabControl1.Size = new System.Drawing.Size(576, 328);
		this.TabControl1.TabIndex = 1;
		this.TabControl1.TabStop = false;
		// 
		// pgeModifyData
		// 
		this.pgeModifyData.Controls.Add(this.GroupBox3);
		this.pgeModifyData.Controls.Add(this.GroupBox1);
		this.pgeModifyData.Location = new System.Drawing.Point(4, 22);
		this.pgeModifyData.Name = "pgeModifyData";
		this.pgeModifyData.Size = new System.Drawing.Size(568, 302);
		this.pgeModifyData.TabIndex = 0;
		this.pgeModifyData.Text = "Modify Data";
		// 
		// GroupBox3
		// 
		this.GroupBox3.Controls.Add(this.Label6);
		this.GroupBox3.Controls.Add(this.txtProductID);
		this.GroupBox3.Controls.Add(this.btnUpdateProduct);
		this.GroupBox3.Controls.Add(this.btnGetProducts);
		this.GroupBox3.Controls.Add(this.btnDeleteProduct);
		this.GroupBox3.Controls.Add(this.Label5);
		this.GroupBox3.Controls.Add(this.Label4);
		this.GroupBox3.Controls.Add(this.Label3);
		this.GroupBox3.Controls.Add(this.btnAddProduct);
		this.GroupBox3.Controls.Add(this.txtUnitPrice);
		this.GroupBox3.Controls.Add(this.txtSupplierID2);
		this.GroupBox3.Controls.Add(this.txtProductName);
		this.GroupBox3.Location = new System.Drawing.Point(28, 144);
		this.GroupBox3.Name = "GroupBox3";
		this.GroupBox3.Size = new System.Drawing.Size(516, 136);
		this.GroupBox3.TabIndex = 2;
		this.GroupBox3.TabStop = false;
		this.GroupBox3.Text = "Products";
		// 
		// Label6
		// 
		this.Label6.AutoSize = true;
		this.Label6.Location = new System.Drawing.Point(16, 96);
		this.Label6.Name = "Label6";
		this.Label6.Size = new System.Drawing.Size(58, 16);
		this.Label6.TabIndex = 6;
		this.Label6.Text = "Product ID";
		// 
		// txtProductID
		// 
		this.txtProductID.Location = new System.Drawing.Point(104, 96);
		this.txtProductID.Name = "txtProductID";
		this.txtProductID.Size = new System.Drawing.Size(152, 20);
		this.txtProductID.TabIndex = 7;
		this.txtProductID.Text = "";
		this.txtProductID.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
		// 
		// btnUpdateProduct
		// 
		this.btnUpdateProduct.Enabled = false;
		this.btnUpdateProduct.Location = new System.Drawing.Point(392, 24);
		this.btnUpdateProduct.Name = "btnUpdateProduct";
		this.btnUpdateProduct.Size = new System.Drawing.Size(104, 23);
		this.btnUpdateProduct.TabIndex = 9;
		this.btnUpdateProduct.Text = "Update P&roduct";
		this.btnUpdateProduct.Click += new System.EventHandler(this.btnUpdateProduct_Click);
		// 
		// btnGetProducts
		// 
		this.btnGetProducts.Location = new System.Drawing.Point(280, 24);
		this.btnGetProducts.Name = "btnGetProducts";
		this.btnGetProducts.Size = new System.Drawing.Size(104, 23);
		this.btnGetProducts.TabIndex = 8;
		this.btnGetProducts.Text = "G&et Products";
		this.btnGetProducts.Click += new System.EventHandler(this.btnGetProducts_Click);
		// 
		// btnDeleteProduct
		// 
		this.btnDeleteProduct.Enabled = false;
		this.btnDeleteProduct.Location = new System.Drawing.Point(392, 64);
		this.btnDeleteProduct.Name = "btnDeleteProduct";
		this.btnDeleteProduct.Size = new System.Drawing.Size(104, 23);
		this.btnDeleteProduct.TabIndex = 11;
		this.btnDeleteProduct.Text = "De&lete Product";
		this.btnDeleteProduct.Click += new System.EventHandler(this.btnDeleteProduct_Click);
		// 
		// Label5
		// 
		this.Label5.AutoSize = true;
		this.Label5.Location = new System.Drawing.Point(16, 72);
		this.Label5.Name = "Label5";
		this.Label5.Size = new System.Drawing.Size(53, 16);
		this.Label5.TabIndex = 4;
		this.Label5.Text = "Unit Price";
		// 
		// Label4
		// 
		this.Label4.AutoSize = true;
		this.Label4.Location = new System.Drawing.Point(16, 48);
		this.Label4.Name = "Label4";
		this.Label4.Size = new System.Drawing.Size(60, 16);
		this.Label4.TabIndex = 2;
		this.Label4.Text = "Supplier ID";
		// 
		// Label3
		// 
		this.Label3.AutoSize = true;
		this.Label3.Location = new System.Drawing.Point(16, 24);
		this.Label3.Name = "Label3";
		this.Label3.Size = new System.Drawing.Size(76, 16);
		this.Label3.TabIndex = 0;
		this.Label3.Text = "Product Name";
		// 
		// btnAddProduct
		// 
		this.btnAddProduct.Enabled = false;
		this.btnAddProduct.Location = new System.Drawing.Point(280, 64);
		this.btnAddProduct.Name = "btnAddProduct";
		this.btnAddProduct.Size = new System.Drawing.Size(104, 23);
		this.btnAddProduct.TabIndex = 10;
		this.btnAddProduct.Text = "Add &Product";
		this.btnAddProduct.Click += new System.EventHandler(this.btnAddProduct_Click);
		// 
		// txtUnitPrice
		// 
		this.txtUnitPrice.Location = new System.Drawing.Point(104, 72);
		this.txtUnitPrice.Name = "txtUnitPrice";
		this.txtUnitPrice.Size = new System.Drawing.Size(152, 20);
		this.txtUnitPrice.TabIndex = 5;
		this.txtUnitPrice.Text = "";
		this.txtUnitPrice.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
		// 
		// txtSupplierID2
		// 
		this.txtSupplierID2.Location = new System.Drawing.Point(104, 48);
		this.txtSupplierID2.Name = "txtSupplierID2";
		this.txtSupplierID2.Size = new System.Drawing.Size(152, 20);
		this.txtSupplierID2.TabIndex = 3;
		this.txtSupplierID2.Text = "";
		this.txtSupplierID2.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
		// 
		// txtProductName
		// 
		this.txtProductName.Location = new System.Drawing.Point(104, 24);
		this.txtProductName.Name = "txtProductName";
		this.txtProductName.Size = new System.Drawing.Size(152, 20);
		this.txtProductName.TabIndex = 1;
		this.txtProductName.Text = "";
		this.txtProductName.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
		// 
		// GroupBox1
		// 
		this.GroupBox1.Controls.Add(this.btnGetSuppliers);
		this.GroupBox1.Controls.Add(this.Label2);
		this.GroupBox1.Controls.Add(this.txtSupplierID1);
		this.GroupBox1.Controls.Add(this.btnUpdateSupplier);
		this.GroupBox1.Controls.Add(this.btnDeleteSupplier);
		this.GroupBox1.Controls.Add(this.Label7);
		this.GroupBox1.Controls.Add(this.Label8);
		this.GroupBox1.Controls.Add(this.btnAddSupplier);
		this.GroupBox1.Controls.Add(this.txtPhone);
		this.GroupBox1.Controls.Add(this.txtCompanyName);
		this.GroupBox1.Location = new System.Drawing.Point(28, 27);
		this.GroupBox1.Name = "GroupBox1";
		this.GroupBox1.Size = new System.Drawing.Size(516, 109);
		this.GroupBox1.TabIndex = 0;
		this.GroupBox1.TabStop = false;
		this.GroupBox1.Text = "Suppliers";
		// 
		// btnGetSuppliers
		// 
		this.btnGetSuppliers.Location = new System.Drawing.Point(280, 24);
		this.btnGetSuppliers.Name = "btnGetSuppliers";
		this.btnGetSuppliers.Size = new System.Drawing.Size(104, 23);
		this.btnGetSuppliers.TabIndex = 6;
		this.btnGetSuppliers.Text = "&Get Suppliers";
		this.btnGetSuppliers.Click += new System.EventHandler(this.btnGetSuppliers_Click);
		// 
		// Label2
		// 
		this.Label2.AutoSize = true;
		this.Label2.Location = new System.Drawing.Point(16, 72);
		this.Label2.Name = "Label2";
		this.Label2.Size = new System.Drawing.Size(60, 16);
		this.Label2.TabIndex = 4;
		this.Label2.Text = "Supplier ID";
		// 
		// txtSupplierID1
		// 
		this.txtSupplierID1.Location = new System.Drawing.Point(104, 72);
		this.txtSupplierID1.Name = "txtSupplierID1";
		this.txtSupplierID1.Size = new System.Drawing.Size(152, 20);
		this.txtSupplierID1.TabIndex = 5;
		this.txtSupplierID1.Text = "";
		this.txtSupplierID1.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
		// 
		// btnUpdateSupplier
		// 
		this.btnUpdateSupplier.Enabled = false;
		this.btnUpdateSupplier.Location = new System.Drawing.Point(392, 24);
		this.btnUpdateSupplier.Name = "btnUpdateSupplier";
		this.btnUpdateSupplier.Size = new System.Drawing.Size(104, 23);
		this.btnUpdateSupplier.TabIndex = 7;
		this.btnUpdateSupplier.Text = "&Update Supplier";
		this.btnUpdateSupplier.Click += new System.EventHandler(this.btnUpdateSupplier_Click);
		// 
		// btnDeleteSupplier
		// 
		this.btnDeleteSupplier.Enabled = false;
		this.btnDeleteSupplier.Location = new System.Drawing.Point(392, 64);
		this.btnDeleteSupplier.Name = "btnDeleteSupplier";
		this.btnDeleteSupplier.Size = new System.Drawing.Size(104, 23);
		this.btnDeleteSupplier.TabIndex = 9;
		this.btnDeleteSupplier.Text = "&Delete Supplier";
		this.btnDeleteSupplier.Click += new System.EventHandler(this.btnDeleteSupplier_Click);
		// 
		// Label7
		// 
		this.Label7.AutoSize = true;
		this.Label7.Location = new System.Drawing.Point(16, 48);
		this.Label7.Name = "Label7";
		this.Label7.Size = new System.Drawing.Size(37, 16);
		this.Label7.TabIndex = 2;
		this.Label7.Text = "Phone";
		// 
		// Label8
		// 
		this.Label8.AutoSize = true;
		this.Label8.Location = new System.Drawing.Point(16, 24);
		this.Label8.Name = "Label8";
		this.Label8.Size = new System.Drawing.Size(86, 16);
		this.Label8.TabIndex = 0;
		this.Label8.Text = "Company Name";
		// 
		// btnAddSupplier
		// 
		this.btnAddSupplier.Enabled = false;
		this.btnAddSupplier.Location = new System.Drawing.Point(280, 64);
		this.btnAddSupplier.Name = "btnAddSupplier";
		this.btnAddSupplier.Size = new System.Drawing.Size(104, 23);
		this.btnAddSupplier.TabIndex = 8;
		this.btnAddSupplier.Text = "&Add Supplier";
		this.btnAddSupplier.Click += new System.EventHandler(this.btnAddSupplier_Click);
		// 
		// txtPhone
		// 
		this.txtPhone.Location = new System.Drawing.Point(104, 48);
		this.txtPhone.Name = "txtPhone";
		this.txtPhone.Size = new System.Drawing.Size(152, 20);
		this.txtPhone.TabIndex = 3;
		this.txtPhone.Text = "";
		this.txtPhone.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
		// 
		// txtCompanyName
		// 
		this.txtCompanyName.Location = new System.Drawing.Point(104, 24);
		this.txtCompanyName.Name = "txtCompanyName";
		this.txtCompanyName.Size = new System.Drawing.Size(152, 20);
		this.txtCompanyName.TabIndex = 1;
		this.txtCompanyName.Text = "";
		this.txtCompanyName.TextChanged += new System.EventHandler(this.textBoxes_TextChanged);
		// 
		// pgeTips
		// 
		this.pgeTips.Controls.Add(this.txtTips);
		this.pgeTips.Location = new System.Drawing.Point(4, 22);
		this.pgeTips.Name = "pgeTips";
		this.pgeTips.Size = new System.Drawing.Size(568, 302);
		this.pgeTips.TabIndex = 1;
		this.pgeTips.Text = "Tips";
		// 
		// txtTips
		// 
		this.txtTips.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
			| System.Windows.Forms.AnchorStyles.Left) 
			| System.Windows.Forms.AnchorStyles.Right)));
		this.txtTips.BorderStyle = System.Windows.Forms.BorderStyle.None;
		this.txtTips.Location = new System.Drawing.Point(8, 8);
		this.txtTips.Multiline = true;
		this.txtTips.Name = "txtTips";
		this.txtTips.ReadOnly = true;
		this.txtTips.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
		this.txtTips.Size = new System.Drawing.Size(552, 288);
		this.txtTips.TabIndex = 0;
		this.txtTips.Text = "";
		// 
		// sbrStatus
		// 
		this.sbrStatus.Font = new System.Drawing.Font("Microsoft Sans Serif", 8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
		this.sbrStatus.Location = new System.Drawing.Point(0, 381);
		this.sbrStatus.Name = "sbrStatus";
		this.sbrStatus.Size = new System.Drawing.Size(610, 22);
		this.sbrStatus.SizingGrip = false;
		this.sbrStatus.TabIndex = 2;
		// 
		// frmMain
		// 
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.ClientSize = new System.Drawing.Size(610, 403);
		this.Controls.Add(this.sbrStatus);
		this.Controls.Add(this.TabControl1);
		this.Controls.Add(this.Label1);
		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
		this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
		this.MaximizeBox = false;
		this.Menu = this.mnuMain;
		this.Name = "frmMain";
		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
		this.Text = "Title Comes from Assembly Info";
		this.TabControl1.ResumeLayout(false);
		this.pgeModifyData.ResumeLayout(false);
		this.GroupBox3.ResumeLayout(false);
		this.GroupBox1.ResumeLayout(false);
		this.pgeTips.ResumeLayout(false);
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
	private void mnuExit_Click(object sender, System.EventArgs e) {
		// Close the current form
		this.Close();
	}

#endregion

#region " Utility functions ";

    private void AddTip(string strTip)
	{
        txtTips.Text += strTip + Environment.NewLine;
    }

    private void AddTip2(string strTip)
	{
        txtTips.Text += strTip + Environment.NewLine + Environment.NewLine;
    }

    private void SetupTips()
	{
        txtTips.Clear();
        AddTip2("To add a Supplier, enter a Company Name and Phone. To update, enter a Company Name, Phone and ID. To delete, only an ID is needed. Working with Products is similar.");
        AddTip2("while testing, remember to Refresh all Components in the COM+ Explorer after you've made structural changes to your component. In some cases you may need to delete the application from the COM+ Explorer if you modify its structure. The next time it is executed, it will get reinstalled.");
    }

#endregion

    private void btnAddProduct_Click(object sender, System.EventArgs e) 
	{
		try 
		{
			Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			Product oProduct = new Product();
			string strProductName;
			int intSupplierID;
			Decimal decUnitPrice;

			strProductName = txtProductName.Text.Trim();
			intSupplierID = Convert.ToInt32(txtSupplierID2.Text.Trim());
			decUnitPrice = Convert.ToDecimal(txtUnitPrice.Text.Trim());
			oProduct.AddProduct(strProductName, intSupplierID, decUnitPrice);
			sbrStatus.Text = "Added product: " + strProductName;
		}
		catch( Exception exp )
		{
			MessageBox.Show(exp.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
		}
        finally
		{
            Cursor.Current = System.Windows.Forms.Cursors.Default;
        }
    }

    private void btnAddSupplier_Click(object sender, System.EventArgs e) 
	{
		try 
		{
			Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			Supplier oSupplier = new Supplier();
			string strCompanyName;
			string strPhone;

			strCompanyName = txtCompanyName.Text.Trim();
			strPhone = txtPhone.Text.Trim();
			oSupplier.AddSupplier(strCompanyName, strPhone);
			sbrStatus.Text = "Added supplier: " + strCompanyName;
		}
		catch( Exception exp )
		{
			MessageBox.Show(exp.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
		}
        finally
		{
            Cursor.Current = System.Windows.Forms.Cursors.Default;
        }
    }

    private void btnDeleteProduct_Click(object sender, System.EventArgs e) 
	{
		try
		{
			Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			Product oProduct = new Product();
			int intID;

			intID = Convert.ToInt32(txtProductID.Text.Trim());
			oProduct.DeleteProduct(intID);
			sbrStatus.Text = "Deleted product: " + intID;
		}
		catch( Exception exp )
		{
			MessageBox.Show(exp.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
		}
        finally
		{
            Cursor.Current = System.Windows.Forms.Cursors.Default;
        }
    }

    private void btnDeleteSupplier_Click(object sender, System.EventArgs e) 
	{
		try
		{
			Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			Supplier oSupplier = new Supplier();
			int intID;

			intID = Convert.ToInt32(txtSupplierID1.Text.Trim());
			oSupplier.DeleteSupplier(intID);
			sbrStatus.Text = "Deleted supplier: " + intID;
		}
		catch( Exception exp )
		{
			MessageBox.Show(exp.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
		}
        finally
		{
            Cursor.Current = System.Windows.Forms.Cursors.Default;
        }
    }

    private void btnGetProducts_Click(object sender, System.EventArgs e) 
	{
		try
		{
			Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			Product oProduct = new Product();
			oProduct.GetProducts();
			sbrStatus.Text = "Got list of products";
		}
		catch( Exception exp )
		{
			MessageBox.Show(exp.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
		}
        finally
		{
            Cursor.Current = System.Windows.Forms.Cursors.Default;
        }
    }

    private void btnGetSuppliers_Click(object sender, System.EventArgs e) 
	{
		try 
		{
			Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			Supplier oSupplier = new Supplier();
			oSupplier.GetSuppliers();
			sbrStatus.Text = "Got list of suppliers";
		}
		catch( Exception exp )
		{
			MessageBox.Show(exp.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
		}
        finally
		{
            Cursor.Current = System.Windows.Forms.Cursors.Default;
        }
    }

    private void btnUpdateProduct_Click(object sender, System.EventArgs e) 
	{
		try
		{
			Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			Product oProduct = new Product();
			string strProductName;
			int intSupplierID;
			Decimal decUnitPrice;
			int intProductID;

			strProductName = txtProductName.Text.Trim();
			intSupplierID = Convert.ToInt32(txtSupplierID2.Text.Trim());
			decUnitPrice = Convert.ToDecimal(txtUnitPrice.Text.Trim());
			intProductID = Convert.ToInt32(txtProductID.Text.Trim());
			oProduct.UpdateProduct(intProductID, strProductName,
				intSupplierID, decUnitPrice);
			sbrStatus.Text = "Updated product: " + intProductID;
		}
		catch( Exception exp )
		{
			MessageBox.Show(exp.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
		}
        finally
		{
            Cursor.Current = System.Windows.Forms.Cursors.Default;
        }
    }

    private void btnUpdateSupplier_Click(object sender, System.EventArgs e) 
	{
		try
		{
			Cursor.Current = System.Windows.Forms.Cursors.WaitCursor;
			Supplier oSupplier = new Supplier();
			string strCompanyName;
			string strPhone;
			int intID;

			strCompanyName = txtCompanyName.Text.Trim();
			strPhone = txtPhone.Text.Trim();
			intID = Convert.ToInt32(txtSupplierID1.Text.Trim());
			oSupplier.UpdateSupplier(intID, strCompanyName, strPhone);
			sbrStatus.Text = "Updated supplier: " + strCompanyName;
		}
		catch( Exception exp )
		{
			MessageBox.Show(exp.ToString(), this.Text, MessageBoxButtons.OK, MessageBoxIcon.None);
		}
        finally
		{
            Cursor.Current = System.Windows.Forms.Cursors.Default;
        }
    }

    private void textBoxes_TextChanged(object sender, System.EventArgs e)  //txtCompanyName.TextChanged, txtPhone.TextChanged, txtSupplierID1.TextChanged, txtProductName.TextChanged, txtSupplierID2.TextChanged, txtUnitPrice.TextChanged, txtProductID.TextChanged;
	{
        btnAddSupplier.Enabled = txtCompanyName.Text.Trim().Length != 0 &&
            txtPhone.Text.Trim().Length != 0;

        btnUpdateSupplier.Enabled = btnAddSupplier.Enabled &&
			txtSupplierID1.Text.Trim().Length != 0;

        btnDeleteSupplier.Enabled = txtSupplierID1.Text.Trim().Length != 0;

        btnAddProduct.Enabled = txtProductName.Text.Trim().Length != 0 &&
            txtSupplierID2.Text.Trim().Length != 0 &&
            txtUnitPrice.Text.Trim().Length != 0;

        btnUpdateProduct.Enabled = btnAddProduct.Enabled &&
            txtProductID.Text.Trim().Length != 0;
        btnDeleteProduct.Enabled = txtProductID.Text.Trim().Length != 0;
    }
}

