
using System.Data;
using System.Data.SqlClient;
using System;
using System.Windows.Forms;

public class frmMain:System.Windows.Forms.Form 
{
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}


    protected const string SQL_CONNECTION_STRING  = "Server=localhost;" + "DataBase=Northwind;" + "Integrated Security=SSPI;Connect Timeout=5";

    protected const string MSDE_CONNECTION_STRING  = @"Server=(local)\VSDotNet;" + "DataBase=Northwind;" + "Integrated Security=SSPI;Connect Timeout=5";

    private string Connectionstring  = SQL_CONNECTION_STRING;

    private bool HasConnected  = false;

    private string Mode  = "Update";

#region " Windows Form Designer generated code "

    public frmMain() 
	{    

        //This call is required by the Windows Form Designer.

        InitializeComponent();

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

    internal System.Windows.Forms.TextBox txtProductID;

    private System.Windows.Forms.TextBox txtProductName;

    private System.Windows.Forms.TextBox txtUnitPrice;

    private System.Windows.Forms.TextBox txtUnitsOnOrder;

    private System.Windows.Forms.TextBox txtUnitsInStock;

    private System.Windows.Forms.TextBox txtReorderLevel;

    private System.Windows.Forms.TextBox txtQtyPerUnit;

    private System.Windows.Forms.ComboBox cbSuppliers;

    private System.Windows.Forms.ComboBox cbCategories;

    private System.Windows.Forms.ListBox lstProducts;

    private System.Windows.Forms.Label lblProductID;

    private System.Windows.Forms.Label lblProductName;

    private System.Windows.Forms.Label lblSuppliers;

    private System.Windows.Forms.Label lblCategories;

    private System.Windows.Forms.Label lblUnitPrice;

    private System.Windows.Forms.Label lblUnitsInStock;

    private System.Windows.Forms.Label lblUnitsOnOrder;

    private System.Windows.Forms.Label lblReorderLevel;

    private System.Windows.Forms.Label lblQtyPerUnit;

    private System.Windows.Forms.GroupBox gbHorvRule;

    private System.Windows.Forms.Button btnAdd;

    private System.Windows.Forms.Button btnUpdate;

    private System.Windows.Forms.Button btnDelete;

    private System.Windows.Forms.Label lblProductList;

    private System.Windows.Forms.CheckBox chkDiscontinued;

    private System.Windows.Forms.MainMenu mnuMain;
	
    private System.Windows.Forms.MenuItem MenuItem1;

    private System.Windows.Forms.MenuItem MenuItem4;

    private System.Windows.Forms.MenuItem mnuExit ;

    private System.Windows.Forms.MenuItem mnuAbout ;

    private System.Windows.Forms.Button btnRefresh;

    private void InitializeComponent() 
	{

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.txtProductID = new System.Windows.Forms.TextBox();

        this.txtProductName = new System.Windows.Forms.TextBox();

        this.txtUnitPrice = new System.Windows.Forms.TextBox();

        this.txtUnitsOnOrder = new System.Windows.Forms.TextBox();

        this.txtUnitsInStock = new System.Windows.Forms.TextBox();

        this.txtReorderLevel = new System.Windows.Forms.TextBox();

        this.txtQtyPerUnit = new System.Windows.Forms.TextBox();

        this.cbSuppliers = new System.Windows.Forms.ComboBox();

        this.cbCategories = new System.Windows.Forms.ComboBox();

        this.chkDiscontinued = new System.Windows.Forms.CheckBox();

        this.lstProducts = new System.Windows.Forms.ListBox();

        this.lblProductID = new System.Windows.Forms.Label();

        this.lblProductName = new System.Windows.Forms.Label();

        this.lblSuppliers = new System.Windows.Forms.Label();

        this.lblCategories = new System.Windows.Forms.Label();

        this.lblUnitPrice = new System.Windows.Forms.Label();

        this.lblUnitsInStock = new System.Windows.Forms.Label();

        this.lblUnitsOnOrder = new System.Windows.Forms.Label();

        this.lblReorderLevel = new System.Windows.Forms.Label();

        this.lblQtyPerUnit = new System.Windows.Forms.Label();

        this.gbHorvRule = new System.Windows.Forms.GroupBox();

        this.btnAdd = new System.Windows.Forms.Button();

        this.btnUpdate = new System.Windows.Forms.Button();

        this.btnDelete = new System.Windows.Forms.Button();

        this.lblProductList = new System.Windows.Forms.Label();

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.MenuItem1 = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.MenuItem4 = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.btnRefresh = new System.Windows.Forms.Button();

        this.SuspendLayout();

        //

        //txtProductID

        //

        this.txtProductID.AccessibleDescription = (string) resources.GetObject("txtProductID.AccessibleDescription");

        this.txtProductID.AccessibleName = (string) resources.GetObject("txtProductID.AccessibleName");

        this.txtProductID.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtProductID.Anchor");

        this.txtProductID.AutoSize = (bool) resources.GetObject("txtProductID.AutoSize");

        this.txtProductID.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtProductID.BackgroundImage");

        this.txtProductID.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtProductID.Dock");

        this.txtProductID.Enabled = (bool) resources.GetObject("txtProductID.Enabled");

        this.txtProductID.Font = (System.Drawing.Font) resources.GetObject("txtProductID.Font");

        this.txtProductID.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtProductID.ImeMode");

        this.txtProductID.Location = (System.Drawing.Point) resources.GetObject("txtProductID.Location");

        this.txtProductID.MaxLength = (int) resources.GetObject("txtProductID.MaxLength");

        this.txtProductID.Multiline = (bool) resources.GetObject("txtProductID.Multiline");

        this.txtProductID.Name = "txtProductID";

        this.txtProductID.PasswordChar = (char) resources.GetObject("txtProductID.PasswordChar");

        this.txtProductID.ReadOnly = true;

        this.txtProductID.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtProductID.RightToLeft");

        this.txtProductID.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtProductID.ScrollBars");

        this.txtProductID.Size = (System.Drawing.Size) resources.GetObject("txtProductID.Size");

        this.txtProductID.TabIndex = (int) resources.GetObject("txtProductID.TabIndex");

        this.txtProductID.Text = resources.GetString("txtProductID.Text");

        this.txtProductID.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtProductID.TextAlign");

        this.txtProductID.Visible = (bool) resources.GetObject("txtProductID.Visible");

        this.txtProductID.WordWrap = (bool) resources.GetObject("txtProductID.WordWrap");

        //

        //txtProductName

        //

        this.txtProductName.AccessibleDescription = resources.GetString("txtProductName.AccessibleDescription");

        this.txtProductName.AccessibleName = resources.GetString("txtProductName.AccessibleName");

        this.txtProductName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtProductName.Anchor");

        this.txtProductName.AutoSize = (bool) resources.GetObject("txtProductName.AutoSize");

        this.txtProductName.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtProductName.BackgroundImage");

        this.txtProductName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtProductName.Dock");

        this.txtProductName.Enabled = (bool) resources.GetObject("txtProductName.Enabled");

        this.txtProductName.Font = (System.Drawing.Font) resources.GetObject("txtProductName.Font");

        this.txtProductName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtProductName.ImeMode");

        this.txtProductName.Location = (System.Drawing.Point) resources.GetObject("txtProductName.Location");

        this.txtProductName.MaxLength = (int) resources.GetObject("txtProductName.MaxLength");

        this.txtProductName.Multiline = (bool) resources.GetObject("txtProductName.Multiline");

        this.txtProductName.Name = "txtProductName";

        this.txtProductName.PasswordChar = (char) resources.GetObject("txtProductName.PasswordChar");

        this.txtProductName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtProductName.RightToLeft");

        this.txtProductName.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtProductName.ScrollBars");

        this.txtProductName.Size = (System.Drawing.Size) resources.GetObject("txtProductName.Size");

        this.txtProductName.TabIndex = (int) resources.GetObject("txtProductName.TabIndex");

        this.txtProductName.Text = resources.GetString("txtProductName.Text");

        this.txtProductName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtProductName.TextAlign");

        this.txtProductName.Visible = (bool) resources.GetObject("txtProductName.Visible");

        this.txtProductName.WordWrap = (bool) resources.GetObject("txtProductName.WordWrap");

        //

        //txtUnitPrice

        //

        this.txtUnitPrice.AccessibleDescription = resources.GetString("txtUnitPrice.AccessibleDescription");

        this.txtUnitPrice.AccessibleName = resources.GetString("txtUnitPrice.AccessibleName");

        this.txtUnitPrice.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtUnitPrice.Anchor");

        this.txtUnitPrice.AutoSize = (bool) resources.GetObject("txtUnitPrice.AutoSize");

        this.txtUnitPrice.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtUnitPrice.BackgroundImage");

        this.txtUnitPrice.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtUnitPrice.Dock");

        this.txtUnitPrice.Enabled = (bool) resources.GetObject("txtUnitPrice.Enabled");

        this.txtUnitPrice.Font = (System.Drawing.Font) resources.GetObject("txtUnitPrice.Font");

        this.txtUnitPrice.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtUnitPrice.ImeMode");

        this.txtUnitPrice.Location = (System.Drawing.Point) resources.GetObject("txtUnitPrice.Location");

        this.txtUnitPrice.MaxLength = (int) resources.GetObject("txtUnitPrice.MaxLength");

        this.txtUnitPrice.Multiline = (bool) resources.GetObject("txtUnitPrice.Multiline");

        this.txtUnitPrice.Name = "txtUnitPrice";

        this.txtUnitPrice.PasswordChar = (char) resources.GetObject("txtUnitPrice.PasswordChar");

        this.txtUnitPrice.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtUnitPrice.RightToLeft");

        this.txtUnitPrice.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtUnitPrice.ScrollBars");

        this.txtUnitPrice.Size = (System.Drawing.Size) resources.GetObject("txtUnitPrice.Size");

        this.txtUnitPrice.TabIndex = (int) resources.GetObject("txtUnitPrice.TabIndex");

        this.txtUnitPrice.Text = resources.GetString("txtUnitPrice.Text");

        this.txtUnitPrice.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtUnitPrice.TextAlign");

        this.txtUnitPrice.Visible = (bool) resources.GetObject("txtUnitPrice.Visible");

        this.txtUnitPrice.WordWrap = (bool) resources.GetObject("txtUnitPrice.WordWrap");

        //

        //txtUnitsOnOrder

        //

        this.txtUnitsOnOrder.AccessibleDescription = resources.GetString("txtUnitsOnOrder.AccessibleDescription");

        this.txtUnitsOnOrder.AccessibleName = resources.GetString("txtUnitsOnOrder.AccessibleName");

        this.txtUnitsOnOrder.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtUnitsOnOrder.Anchor");

        this.txtUnitsOnOrder.AutoSize = (bool) resources.GetObject("txtUnitsOnOrder.AutoSize");

        this.txtUnitsOnOrder.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtUnitsOnOrder.BackgroundImage");

        this.txtUnitsOnOrder.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtUnitsOnOrder.Dock");

        this.txtUnitsOnOrder.Enabled = (bool) resources.GetObject("txtUnitsOnOrder.Enabled");

        this.txtUnitsOnOrder.Font = (System.Drawing.Font) resources.GetObject("txtUnitsOnOrder.Font");

        this.txtUnitsOnOrder.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtUnitsOnOrder.ImeMode");

        this.txtUnitsOnOrder.Location = (System.Drawing.Point) resources.GetObject("txtUnitsOnOrder.Location");

        this.txtUnitsOnOrder.MaxLength = (int) resources.GetObject("txtUnitsOnOrder.MaxLength");

        this.txtUnitsOnOrder.Multiline = (bool) resources.GetObject("txtUnitsOnOrder.Multiline");

        this.txtUnitsOnOrder.Name = "txtUnitsOnOrder";

        this.txtUnitsOnOrder.PasswordChar = (char) resources.GetObject("txtUnitsOnOrder.PasswordChar");

        this.txtUnitsOnOrder.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtUnitsOnOrder.RightToLeft");

        this.txtUnitsOnOrder.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtUnitsOnOrder.ScrollBars");

        this.txtUnitsOnOrder.Size = (System.Drawing.Size) resources.GetObject("txtUnitsOnOrder.Size");

        this.txtUnitsOnOrder.TabIndex = (int) resources.GetObject("txtUnitsOnOrder.TabIndex");

        this.txtUnitsOnOrder.Text = resources.GetString("txtUnitsOnOrder.Text");

        this.txtUnitsOnOrder.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtUnitsOnOrder.TextAlign");

        this.txtUnitsOnOrder.Visible = (bool) resources.GetObject("txtUnitsOnOrder.Visible");

        this.txtUnitsOnOrder.WordWrap = (bool) resources.GetObject("txtUnitsOnOrder.WordWrap");

        //

        //txtUnitsInStock

        //

        this.txtUnitsInStock.AccessibleDescription = resources.GetString("txtUnitsInStock.AccessibleDescription");

        this.txtUnitsInStock.AccessibleName = resources.GetString("txtUnitsInStock.AccessibleName");

        this.txtUnitsInStock.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtUnitsInStock.Anchor");

        this.txtUnitsInStock.AutoSize = (bool) resources.GetObject("txtUnitsInStock.AutoSize");

        this.txtUnitsInStock.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtUnitsInStock.BackgroundImage");

        this.txtUnitsInStock.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtUnitsInStock.Dock");

        this.txtUnitsInStock.Enabled = (bool) resources.GetObject("txtUnitsInStock.Enabled");

        this.txtUnitsInStock.Font = (System.Drawing.Font) resources.GetObject("txtUnitsInStock.Font");

        this.txtUnitsInStock.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtUnitsInStock.ImeMode");

        this.txtUnitsInStock.Location = (System.Drawing.Point) resources.GetObject("txtUnitsInStock.Location");

        this.txtUnitsInStock.MaxLength = (int) resources.GetObject("txtUnitsInStock.MaxLength");

        this.txtUnitsInStock.Multiline = (bool) resources.GetObject("txtUnitsInStock.Multiline");

        this.txtUnitsInStock.Name = "txtUnitsInStock";

        this.txtUnitsInStock.PasswordChar = (char) resources.GetObject("txtUnitsInStock.PasswordChar");

        this.txtUnitsInStock.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtUnitsInStock.RightToLeft");

        this.txtUnitsInStock.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtUnitsInStock.ScrollBars");

        this.txtUnitsInStock.Size = (System.Drawing.Size) resources.GetObject("txtUnitsInStock.Size");

        this.txtUnitsInStock.TabIndex = (int) resources.GetObject("txtUnitsInStock.TabIndex");

        this.txtUnitsInStock.Text = resources.GetString("txtUnitsInStock.Text");

        this.txtUnitsInStock.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtUnitsInStock.TextAlign");

        this.txtUnitsInStock.Visible = (bool) resources.GetObject("txtUnitsInStock.Visible");

        this.txtUnitsInStock.WordWrap = (bool) resources.GetObject("txtUnitsInStock.WordWrap");

        //

        //txtReorderLevel

        //

        this.txtReorderLevel.AccessibleDescription = resources.GetString("txtReorderLevel.AccessibleDescription");

        this.txtReorderLevel.AccessibleName = resources.GetString("txtReorderLevel.AccessibleName");

        this.txtReorderLevel.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtReorderLevel.Anchor");

        this.txtReorderLevel.AutoSize = (bool) resources.GetObject("txtReorderLevel.AutoSize");

        this.txtReorderLevel.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtReorderLevel.BackgroundImage");

        this.txtReorderLevel.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtReorderLevel.Dock");

        this.txtReorderLevel.Enabled = (bool) resources.GetObject("txtReorderLevel.Enabled");

        this.txtReorderLevel.Font = (System.Drawing.Font) resources.GetObject("txtReorderLevel.Font");

        this.txtReorderLevel.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtReorderLevel.ImeMode");

        this.txtReorderLevel.Location = (System.Drawing.Point) resources.GetObject("txtReorderLevel.Location");

        this.txtReorderLevel.MaxLength = (int) resources.GetObject("txtReorderLevel.MaxLength");

        this.txtReorderLevel.Multiline = (bool) resources.GetObject("txtReorderLevel.Multiline");

        this.txtReorderLevel.Name = "txtReorderLevel";

        this.txtReorderLevel.PasswordChar = (char) resources.GetObject("txtReorderLevel.PasswordChar");

        this.txtReorderLevel.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtReorderLevel.RightToLeft");

        this.txtReorderLevel.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtReorderLevel.ScrollBars");

        this.txtReorderLevel.Size = (System.Drawing.Size) resources.GetObject("txtReorderLevel.Size");

        this.txtReorderLevel.TabIndex = (int) resources.GetObject("txtReorderLevel.TabIndex");

        this.txtReorderLevel.Text = resources.GetString("txtReorderLevel.Text");

        this.txtReorderLevel.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtReorderLevel.TextAlign");

        this.txtReorderLevel.Visible = (bool) resources.GetObject("txtReorderLevel.Visible");

        this.txtReorderLevel.WordWrap = (bool) resources.GetObject("txtReorderLevel.WordWrap");

        //

        //txtQtyPerUnit

        //

        this.txtQtyPerUnit.AccessibleDescription = resources.GetString("txtQtyPerUnit.AccessibleDescription");

        this.txtQtyPerUnit.AccessibleName = resources.GetString("txtQtyPerUnit.AccessibleName");

        this.txtQtyPerUnit.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtQtyPerUnit.Anchor");

        this.txtQtyPerUnit.AutoSize = (bool) resources.GetObject("txtQtyPerUnit.AutoSize");

        this.txtQtyPerUnit.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtQtyPerUnit.BackgroundImage");

        this.txtQtyPerUnit.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtQtyPerUnit.Dock");

        this.txtQtyPerUnit.Enabled = (bool) resources.GetObject("txtQtyPerUnit.Enabled");

        this.txtQtyPerUnit.Font = (System.Drawing.Font) resources.GetObject("txtQtyPerUnit.Font");

        this.txtQtyPerUnit.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtQtyPerUnit.ImeMode");

        this.txtQtyPerUnit.Location = (System.Drawing.Point) resources.GetObject("txtQtyPerUnit.Location");

        this.txtQtyPerUnit.MaxLength = (int) resources.GetObject("txtQtyPerUnit.MaxLength");

        this.txtQtyPerUnit.Multiline = (bool) resources.GetObject("txtQtyPerUnit.Multiline");

        this.txtQtyPerUnit.Name = "txtQtyPerUnit";

        this.txtQtyPerUnit.PasswordChar = (char) resources.GetObject("txtQtyPerUnit.PasswordChar");

        this.txtQtyPerUnit.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtQtyPerUnit.RightToLeft");

        this.txtQtyPerUnit.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtQtyPerUnit.ScrollBars");

        this.txtQtyPerUnit.Size = (System.Drawing.Size) resources.GetObject("txtQtyPerUnit.Size");

        this.txtQtyPerUnit.TabIndex = (int) resources.GetObject("txtQtyPerUnit.TabIndex");

        this.txtQtyPerUnit.Text = resources.GetString("txtQtyPerUnit.Text");

        this.txtQtyPerUnit.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtQtyPerUnit.TextAlign");

        this.txtQtyPerUnit.Visible = (bool) resources.GetObject("txtQtyPerUnit.Visible");

        this.txtQtyPerUnit.WordWrap = (bool) resources.GetObject("txtQtyPerUnit.WordWrap");

        //

        //cbSuppliers

        //

        this.cbSuppliers.AccessibleDescription = resources.GetString("cbSuppliers.AccessibleDescription");

        this.cbSuppliers.AccessibleName = resources.GetString("cbSuppliers.AccessibleName");

        this.cbSuppliers.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cbSuppliers.Anchor");

        this.cbSuppliers.BackgroundImage = (System.Drawing.Image) resources.GetObject("cbSuppliers.BackgroundImage");

        this.cbSuppliers.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cbSuppliers.Dock");

        this.cbSuppliers.Enabled = (bool) resources.GetObject("cbSuppliers.Enabled");

        this.cbSuppliers.Font = (System.Drawing.Font) resources.GetObject("cbSuppliers.Font");

        this.cbSuppliers.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cbSuppliers.ImeMode");

        this.cbSuppliers.IntegralHeight = (bool) resources.GetObject("cbSuppliers.IntegralHeight");

        this.cbSuppliers.ItemHeight = (int) resources.GetObject("cbSuppliers.ItemHeight");

        this.cbSuppliers.Location = (System.Drawing.Point) resources.GetObject("cbSuppliers.Location");

        this.cbSuppliers.MaxDropDownItems = (int) resources.GetObject("cbSuppliers.MaxDropDownItems");

        this.cbSuppliers.MaxLength = (int) resources.GetObject("cbSuppliers.MaxLength");

        this.cbSuppliers.Name = "cbSuppliers";

        this.cbSuppliers.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cbSuppliers.RightToLeft");

        this.cbSuppliers.Size = (System.Drawing.Size) resources.GetObject("cbSuppliers.Size");

        this.cbSuppliers.TabIndex = (int) resources.GetObject("cbSuppliers.TabIndex");

        this.cbSuppliers.Text = resources.GetString("cbSuppliers.Text");

        this.cbSuppliers.Visible = (bool) resources.GetObject("cbSuppliers.Visible");

        //

        //cbCategories

        //

        this.cbCategories.AccessibleDescription = resources.GetString("cbCategories.AccessibleDescription");

        this.cbCategories.AccessibleName = resources.GetString("cbCategories.AccessibleName");

        this.cbCategories.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cbCategories.Anchor");

        this.cbCategories.BackgroundImage = (System.Drawing.Image) resources.GetObject("cbCategories.BackgroundImage");

        this.cbCategories.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cbCategories.Dock");

        this.cbCategories.Enabled = (bool) resources.GetObject("cbCategories.Enabled");

        this.cbCategories.Font = (System.Drawing.Font) resources.GetObject("cbCategories.Font");

        this.cbCategories.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cbCategories.ImeMode");

        this.cbCategories.IntegralHeight = (bool) resources.GetObject("cbCategories.IntegralHeight");

        this.cbCategories.ItemHeight = (int) resources.GetObject("cbCategories.ItemHeight");

        this.cbCategories.Location = (System.Drawing.Point) resources.GetObject("cbCategories.Location");

        this.cbCategories.MaxDropDownItems = (int) resources.GetObject("cbCategories.MaxDropDownItems");

        this.cbCategories.MaxLength = (int) resources.GetObject("cbCategories.MaxLength");

        this.cbCategories.Name = "cbCategories";

        this.cbCategories.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cbCategories.RightToLeft");

        this.cbCategories.Size = (System.Drawing.Size) resources.GetObject("cbCategories.Size");

        this.cbCategories.TabIndex = (int) resources.GetObject("cbCategories.TabIndex");

        this.cbCategories.Text = resources.GetString("cbCategories.Text");

        this.cbCategories.Visible = (bool) resources.GetObject("cbCategories.Visible");

        //

        //chkDiscontinued

        //

        this.chkDiscontinued.AccessibleDescription = resources.GetString("chkDiscontinued.AccessibleDescription");

        this.chkDiscontinued.AccessibleName = resources.GetString("chkDiscontinued.AccessibleName");

        this.chkDiscontinued.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkDiscontinued.Anchor");

        this.chkDiscontinued.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkDiscontinued.Appearance");

        this.chkDiscontinued.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkDiscontinued.BackgroundImage");

        this.chkDiscontinued.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkDiscontinued.CheckAlign");

        this.chkDiscontinued.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkDiscontinued.Dock");

        this.chkDiscontinued.Enabled = (bool) resources.GetObject("chkDiscontinued.Enabled");

        this.chkDiscontinued.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkDiscontinued.FlatStyle");

        this.chkDiscontinued.Font = (System.Drawing.Font) resources.GetObject("chkDiscontinued.Font");

        this.chkDiscontinued.Image = (System.Drawing.Image) resources.GetObject("chkDiscontinued.Image");

        this.chkDiscontinued.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkDiscontinued.ImageAlign");

        this.chkDiscontinued.ImageIndex = (int) resources.GetObject("chkDiscontinued.ImageIndex");

        this.chkDiscontinued.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkDiscontinued.ImeMode");

        this.chkDiscontinued.Location = (System.Drawing.Point) resources.GetObject("chkDiscontinued.Location");

        this.chkDiscontinued.Name = "chkDiscontinued";

        this.chkDiscontinued.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkDiscontinued.RightToLeft");

        this.chkDiscontinued.Size = (System.Drawing.Size) resources.GetObject("chkDiscontinued.Size");

        this.chkDiscontinued.TabIndex = (int) resources.GetObject("chkDiscontinued.TabIndex");

        this.chkDiscontinued.Text = resources.GetString("chkDiscontinued.Text");

        this.chkDiscontinued.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkDiscontinued.TextAlign");

        this.chkDiscontinued.Visible = (bool) resources.GetObject("chkDiscontinued.Visible");

        //

        //lstProducts

        //

        this.lstProducts.AccessibleDescription = resources.GetString("lstProducts.AccessibleDescription");

        this.lstProducts.AccessibleName = resources.GetString("lstProducts.AccessibleName");

        this.lstProducts.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lstProducts.Anchor");

        this.lstProducts.BackgroundImage = (System.Drawing.Image) resources.GetObject("lstProducts.BackgroundImage");

        this.lstProducts.ColumnWidth = (int) resources.GetObject("lstProducts.ColumnWidth");

        this.lstProducts.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lstProducts.Dock");

        this.lstProducts.Enabled = (bool) resources.GetObject("lstProducts.Enabled");

        this.lstProducts.Font = (System.Drawing.Font) resources.GetObject("lstProducts.Font");

        this.lstProducts.HorizontalExtent = (int) resources.GetObject("lstProducts.HorizontalExtent");

        this.lstProducts.HorizontalScrollbar = (bool) resources.GetObject("lstProducts.HorizontalScrollbar");

        this.lstProducts.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lstProducts.ImeMode");

        this.lstProducts.IntegralHeight = (bool) resources.GetObject("lstProducts.IntegralHeight");

        this.lstProducts.ItemHeight = (int) resources.GetObject("lstProducts.ItemHeight");

        this.lstProducts.Location = (System.Drawing.Point) resources.GetObject("lstProducts.Location");

        this.lstProducts.Name = "lstProducts";

        this.lstProducts.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lstProducts.RightToLeft");

        this.lstProducts.ScrollAlwaysVisible = (bool) resources.GetObject("lstProducts.ScrollAlwaysVisible");

        this.lstProducts.Size = (System.Drawing.Size) resources.GetObject("lstProducts.Size");

        this.lstProducts.TabIndex = (int) resources.GetObject("lstProducts.TabIndex");

        this.lstProducts.Visible = (bool) resources.GetObject("lstProducts.Visible");

		this.lstProducts.SelectedIndexChanged+=new EventHandler(lstProducts_SelectedIndexChanged);

        //

        //lblProductID

        //

        this.lblProductID.AccessibleDescription = (string) resources.GetObject("lblProductID.AccessibleDescription");

        this.lblProductID.AccessibleName = (string) resources.GetObject("lblProductID.AccessibleName");

        this.lblProductID.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblProductID.Anchor");

        this.lblProductID.AutoSize = (bool) resources.GetObject("lblProductID.AutoSize");

        this.lblProductID.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblProductID.Dock");

        this.lblProductID.Enabled = (bool) resources.GetObject("lblProductID.Enabled");

        this.lblProductID.Font = (System.Drawing.Font) resources.GetObject("lblProductID.Font");

        this.lblProductID.Image = (System.Drawing.Image) resources.GetObject("lblProductID.Image");

        this.lblProductID.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblProductID.ImageAlign");

        this.lblProductID.ImageIndex = (int) resources.GetObject("lblProductID.ImageIndex");

        this.lblProductID.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblProductID.ImeMode");

        this.lblProductID.Location = (System.Drawing.Point) resources.GetObject("lblProductID.Location");

        this.lblProductID.Name = "lblProductID";

        this.lblProductID.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblProductID.RightToLeft");

        this.lblProductID.Size = (System.Drawing.Size) resources.GetObject("lblProductID.Size");

        this.lblProductID.TabIndex = (int) resources.GetObject("lblProductID.TabIndex");

        this.lblProductID.Text = resources.GetString("lblProductID.Text");

        this.lblProductID.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblProductID.TextAlign");

        this.lblProductID.Visible = (bool) resources.GetObject("lblProductID.Visible");

        //

        //lblProductName

        //

        this.lblProductName.AccessibleDescription = (string) resources.GetObject("lblProductName.AccessibleDescription");

        this.lblProductName.AccessibleName = (string) resources.GetObject("lblProductName.AccessibleName");

        this.lblProductName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblProductName.Anchor");

        this.lblProductName.AutoSize = (bool) resources.GetObject("lblProductName.AutoSize");

        this.lblProductName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblProductName.Dock");

        this.lblProductName.Enabled = (bool) resources.GetObject("lblProductName.Enabled");

        this.lblProductName.Font = (System.Drawing.Font) resources.GetObject("lblProductName.Font");

        this.lblProductName.Image = (System.Drawing.Image) resources.GetObject("lblProductName.Image");

        this.lblProductName.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblProductName.ImageAlign");

        this.lblProductName.ImageIndex = (int) resources.GetObject("lblProductName.ImageIndex");

        this.lblProductName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblProductName.ImeMode");

        this.lblProductName.Location = (System.Drawing.Point) resources.GetObject("lblProductName.Location");

        this.lblProductName.Name = "lblProductName";

        this.lblProductName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblProductName.RightToLeft");

        this.lblProductName.Size = (System.Drawing.Size) resources.GetObject("lblProductName.Size");

        this.lblProductName.TabIndex = (int) resources.GetObject("lblProductName.TabIndex");

        this.lblProductName.Text = resources.GetString("lblProductName.Text");

        this.lblProductName.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblProductName.TextAlign");

        this.lblProductName.Visible = (bool) resources.GetObject("lblProductName.Visible");

        //

        //lblSuppliers

        //

        this.lblSuppliers.AccessibleDescription = (string) resources.GetObject("lblSuppliers.AccessibleDescription");

        this.lblSuppliers.AccessibleName = (string) resources.GetObject("lblSuppliers.AccessibleName");

        this.lblSuppliers.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblSuppliers.Anchor");

        this.lblSuppliers.AutoSize = (bool) resources.GetObject("lblSuppliers.AutoSize");

        this.lblSuppliers.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblSuppliers.Dock");

        this.lblSuppliers.Enabled = (bool) resources.GetObject("lblSuppliers.Enabled");

        this.lblSuppliers.Font = (System.Drawing.Font) resources.GetObject("lblSuppliers.Font");

        this.lblSuppliers.Image = (System.Drawing.Image) resources.GetObject("lblSuppliers.Image");

        this.lblSuppliers.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblSuppliers.ImageAlign");

        this.lblSuppliers.ImageIndex = (int) resources.GetObject("lblSuppliers.ImageIndex");

        this.lblSuppliers.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblSuppliers.ImeMode");

        this.lblSuppliers.Location = (System.Drawing.Point) resources.GetObject("lblSuppliers.Location");

        this.lblSuppliers.Name = "lblSuppliers";

        this.lblSuppliers.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblSuppliers.RightToLeft");

        this.lblSuppliers.Size = (System.Drawing.Size) resources.GetObject("lblSuppliers.Size");

        this.lblSuppliers.TabIndex = (int) resources.GetObject("lblSuppliers.TabIndex");

        this.lblSuppliers.Text = resources.GetString("lblSuppliers.Text");

        this.lblSuppliers.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblSuppliers.TextAlign");

        this.lblSuppliers.Visible = (bool) resources.GetObject("lblSuppliers.Visible");

        //

        //lblCategories

        //

        this.lblCategories.AccessibleDescription = (string) resources.GetObject("lblCategories.AccessibleDescription");

        this.lblCategories.AccessibleName = (string) resources.GetObject("lblCategories.AccessibleName");

        this.lblCategories.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblCategories.Anchor");

        this.lblCategories.AutoSize = (bool) resources.GetObject("lblCategories.AutoSize");

        this.lblCategories.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblCategories.Dock");

        this.lblCategories.Enabled = (bool) resources.GetObject("lblCategories.Enabled");

        this.lblCategories.Font = (System.Drawing.Font) resources.GetObject("lblCategories.Font");

        this.lblCategories.Image = (System.Drawing.Image) resources.GetObject("lblCategories.Image");

        this.lblCategories.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblCategories.ImageAlign");

        this.lblCategories.ImageIndex = (int) resources.GetObject("lblCategories.ImageIndex");

        this.lblCategories.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblCategories.ImeMode");

        this.lblCategories.Location = (System.Drawing.Point) resources.GetObject("lblCategories.Location");

        this.lblCategories.Name = "lblCategories";

        this.lblCategories.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblCategories.RightToLeft");

        this.lblCategories.Size = (System.Drawing.Size) resources.GetObject("lblCategories.Size");

        this.lblCategories.TabIndex = (int) resources.GetObject("lblCategories.TabIndex");

        this.lblCategories.Text = resources.GetString("lblCategories.Text");

        this.lblCategories.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblCategories.TextAlign");

        this.lblCategories.Visible = (bool) resources.GetObject("lblCategories.Visible");

        //

        //lblUnitPrice

        //

        this.lblUnitPrice.AccessibleDescription = (string) resources.GetObject("lblUnitPrice.AccessibleDescription");

        this.lblUnitPrice.AccessibleName = (string) resources.GetObject("lblUnitPrice.AccessibleName");

        this.lblUnitPrice.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblUnitPrice.Anchor");

        this.lblUnitPrice.AutoSize = (bool) resources.GetObject("lblUnitPrice.AutoSize");

        this.lblUnitPrice.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblUnitPrice.Dock");

        this.lblUnitPrice.Enabled = (bool) resources.GetObject("lblUnitPrice.Enabled");

        this.lblUnitPrice.Font = (System.Drawing.Font) resources.GetObject("lblUnitPrice.Font");

        this.lblUnitPrice.Image = (System.Drawing.Image) resources.GetObject("lblUnitPrice.Image");

        this.lblUnitPrice.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblUnitPrice.ImageAlign");

        this.lblUnitPrice.ImageIndex = (int) resources.GetObject("lblUnitPrice.ImageIndex");

        this.lblUnitPrice.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblUnitPrice.ImeMode");

        this.lblUnitPrice.Location = (System.Drawing.Point) resources.GetObject("lblUnitPrice.Location");

        this.lblUnitPrice.Name = "lblUnitPrice";

        this.lblUnitPrice.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblUnitPrice.RightToLeft");

        this.lblUnitPrice.Size = (System.Drawing.Size) resources.GetObject("lblUnitPrice.Size");

        this.lblUnitPrice.TabIndex = (int) resources.GetObject("lblUnitPrice.TabIndex");

        this.lblUnitPrice.Tag = string.Empty;

        this.lblUnitPrice.Text = resources.GetString("lblUnitPrice.Text");

        this.lblUnitPrice.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblUnitPrice.TextAlign");

        this.lblUnitPrice.Visible = (bool) resources.GetObject("lblUnitPrice.Visible");

        //

        //lblUnitsInStock

        //

        this.lblUnitsInStock.AccessibleDescription = (string) resources.GetObject("lblUnitsInStock.AccessibleDescription");

        this.lblUnitsInStock.AccessibleName = (string) resources.GetObject("lblUnitsInStock.AccessibleName");

        this.lblUnitsInStock.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblUnitsInStock.Anchor");

        this.lblUnitsInStock.AutoSize = (bool) resources.GetObject("lblUnitsInStock.AutoSize");

        this.lblUnitsInStock.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblUnitsInStock.Dock");

        this.lblUnitsInStock.Enabled = (bool) resources.GetObject("lblUnitsInStock.Enabled");

        this.lblUnitsInStock.Font = (System.Drawing.Font) resources.GetObject("lblUnitsInStock.Font");

        this.lblUnitsInStock.Image = (System.Drawing.Image) resources.GetObject("lblUnitsInStock.Image");

        this.lblUnitsInStock.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblUnitsInStock.ImageAlign");

        this.lblUnitsInStock.ImageIndex = (int) resources.GetObject("lblUnitsInStock.ImageIndex");

        this.lblUnitsInStock.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblUnitsInStock.ImeMode");

        this.lblUnitsInStock.Location = (System.Drawing.Point) resources.GetObject("lblUnitsInStock.Location");

        this.lblUnitsInStock.Name = "lblUnitsInStock";

        this.lblUnitsInStock.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblUnitsInStock.RightToLeft");

        this.lblUnitsInStock.Size = (System.Drawing.Size) resources.GetObject("lblUnitsInStock.Size");

        this.lblUnitsInStock.TabIndex = (int) resources.GetObject("lblUnitsInStock.TabIndex");

        this.lblUnitsInStock.Text = resources.GetString("lblUnitsInStock.Text");

        this.lblUnitsInStock.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblUnitsInStock.TextAlign");

        this.lblUnitsInStock.Visible = (bool) resources.GetObject("lblUnitsInStock.Visible");

        //

        //lblUnitsOnOrder

        //

        this.lblUnitsOnOrder.AccessibleDescription = (string) resources.GetObject("lblUnitsOnOrder.AccessibleDescription");

        this.lblUnitsOnOrder.AccessibleName = (string) resources.GetObject("lblUnitsOnOrder.AccessibleName");

        this.lblUnitsOnOrder.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblUnitsOnOrder.Anchor");

        this.lblUnitsOnOrder.AutoSize = (bool) resources.GetObject("lblUnitsOnOrder.AutoSize");

        this.lblUnitsOnOrder.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblUnitsOnOrder.Dock");

        this.lblUnitsOnOrder.Enabled = (bool) resources.GetObject("lblUnitsOnOrder.Enabled");

        this.lblUnitsOnOrder.Font = (System.Drawing.Font) resources.GetObject("lblUnitsOnOrder.Font");

        this.lblUnitsOnOrder.Image = (System.Drawing.Image) resources.GetObject("lblUnitsOnOrder.Image");

        this.lblUnitsOnOrder.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblUnitsOnOrder.ImageAlign");

        this.lblUnitsOnOrder.ImageIndex = (int) resources.GetObject("lblUnitsOnOrder.ImageIndex");

        this.lblUnitsOnOrder.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblUnitsOnOrder.ImeMode");

        this.lblUnitsOnOrder.Location = (System.Drawing.Point) resources.GetObject("lblUnitsOnOrder.Location");

        this.lblUnitsOnOrder.Name = "lblUnitsOnOrder";

        this.lblUnitsOnOrder.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblUnitsOnOrder.RightToLeft");

        this.lblUnitsOnOrder.Size = (System.Drawing.Size) resources.GetObject("lblUnitsOnOrder.Size");

        this.lblUnitsOnOrder.TabIndex = (int) resources.GetObject("lblUnitsOnOrder.TabIndex");

        this.lblUnitsOnOrder.Text = resources.GetString("lblUnitsOnOrder.Text");

        this.lblUnitsOnOrder.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblUnitsOnOrder.TextAlign");

        this.lblUnitsOnOrder.Visible = (bool) resources.GetObject("lblUnitsOnOrder.Visible");

        //

        //lblReorderLevel

        //

        this.lblReorderLevel.AccessibleDescription = (string) resources.GetObject("lblReorderLevel.AccessibleDescription");

        this.lblReorderLevel.AccessibleName = (string) resources.GetObject("lblReorderLevel.AccessibleName");

        this.lblReorderLevel.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblReorderLevel.Anchor");

        this.lblReorderLevel.AutoSize = (bool) resources.GetObject("lblReorderLevel.AutoSize");

        this.lblReorderLevel.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblReorderLevel.Dock");

        this.lblReorderLevel.Enabled = (bool) resources.GetObject("lblReorderLevel.Enabled");

        this.lblReorderLevel.Font = (System.Drawing.Font) resources.GetObject("lblReorderLevel.Font");

        this.lblReorderLevel.Image = (System.Drawing.Image) resources.GetObject("lblReorderLevel.Image");

        this.lblReorderLevel.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblReorderLevel.ImageAlign");

        this.lblReorderLevel.ImageIndex = (int) resources.GetObject("lblReorderLevel.ImageIndex");

        this.lblReorderLevel.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblReorderLevel.ImeMode");

        this.lblReorderLevel.Location = (System.Drawing.Point) resources.GetObject("lblReorderLevel.Location");

        this.lblReorderLevel.Name = "lblReorderLevel";

        this.lblReorderLevel.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblReorderLevel.RightToLeft");

        this.lblReorderLevel.Size = (System.Drawing.Size) resources.GetObject("lblReorderLevel.Size");

        this.lblReorderLevel.TabIndex = (int) resources.GetObject("lblReorderLevel.TabIndex");

        this.lblReorderLevel.Text = resources.GetString("lblReorderLevel.Text");

        this.lblReorderLevel.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblReorderLevel.TextAlign");

        this.lblReorderLevel.Visible = (bool) resources.GetObject("lblReorderLevel.Visible");

        //

        //lblQtyPerUnit

        //

        this.lblQtyPerUnit.AccessibleDescription = (string) resources.GetObject("lblQtyPerUnit.AccessibleDescription");

        this.lblQtyPerUnit.AccessibleName = (string) resources.GetObject("lblQtyPerUnit.AccessibleName");

        this.lblQtyPerUnit.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblQtyPerUnit.Anchor");

        this.lblQtyPerUnit.AutoSize = (bool) resources.GetObject("lblQtyPerUnit.AutoSize");

        this.lblQtyPerUnit.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblQtyPerUnit.Dock");

        this.lblQtyPerUnit.Enabled = (bool) resources.GetObject("lblQtyPerUnit.Enabled");

        this.lblQtyPerUnit.Font = (System.Drawing.Font) resources.GetObject("lblQtyPerUnit.Font");

        this.lblQtyPerUnit.Image = (System.Drawing.Image) resources.GetObject("lblQtyPerUnit.Image");

        this.lblQtyPerUnit.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblQtyPerUnit.ImageAlign");

        this.lblQtyPerUnit.ImageIndex = (int) resources.GetObject("lblQtyPerUnit.ImageIndex");

        this.lblQtyPerUnit.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblQtyPerUnit.ImeMode");

        this.lblQtyPerUnit.Location = (System.Drawing.Point) resources.GetObject("lblQtyPerUnit.Location");

        this.lblQtyPerUnit.Name = "lblQtyPerUnit";

        this.lblQtyPerUnit.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblQtyPerUnit.RightToLeft");

        this.lblQtyPerUnit.Size = (System.Drawing.Size) resources.GetObject("lblQtyPerUnit.Size");

        this.lblQtyPerUnit.TabIndex = (int) resources.GetObject("lblQtyPerUnit.TabIndex");

        this.lblQtyPerUnit.Text = resources.GetString("lblQtyPerUnit.Text");

        this.lblQtyPerUnit.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblQtyPerUnit.TextAlign");

        this.lblQtyPerUnit.Visible = (bool) resources.GetObject("lblQtyPerUnit.Visible");

        //

        //gbHorvRule

        //

        this.gbHorvRule.AccessibleDescription = (string) resources.GetObject("gbHorvRule.AccessibleDescription");

        this.gbHorvRule.AccessibleName = (string) resources.GetObject("gbHorvRule.AccessibleName");

        this.gbHorvRule.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("gbHorvRule.Anchor");

        this.gbHorvRule.BackgroundImage = (System.Drawing.Image) resources.GetObject("gbHorvRule.BackgroundImage");

        this.gbHorvRule.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("gbHorvRule.Dock");

        this.gbHorvRule.Enabled = (bool) resources.GetObject("gbHorvRule.Enabled");

        this.gbHorvRule.Font = (System.Drawing.Font) resources.GetObject("gbHorvRule.Font");

        this.gbHorvRule.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("gbHorvRule.ImeMode");

        this.gbHorvRule.Location = (System.Drawing.Point) resources.GetObject("gbHorvRule.Location");

        this.gbHorvRule.Name = "gbHorvRule";

        this.gbHorvRule.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("gbHorvRule.RightToLeft");

        this.gbHorvRule.Size = (System.Drawing.Size) resources.GetObject("gbHorvRule.Size");

        this.gbHorvRule.TabIndex = (int) resources.GetObject("gbHorvRule.TabIndex");

        this.gbHorvRule.TabStop = false;

        this.gbHorvRule.Text = resources.GetString("gbHorvRule.Text");

        this.gbHorvRule.Visible = (bool) resources.GetObject("gbHorvRule.Visible");

        //

        //btnAdd

        //

        this.btnAdd.AccessibleDescription = resources.GetString("btnAdd.AccessibleDescription");

        this.btnAdd.AccessibleName = resources.GetString("btnAdd.AccessibleName");

        this.btnAdd.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnAdd.Anchor");

        this.btnAdd.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnAdd.BackgroundImage");

        this.btnAdd.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnAdd.Dock");

        this.btnAdd.Enabled = (bool) resources.GetObject("btnAdd.Enabled");

        this.btnAdd.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnAdd.FlatStyle");

        this.btnAdd.Font = (System.Drawing.Font) resources.GetObject("btnAdd.Font");

        this.btnAdd.Image = (System.Drawing.Image) resources.GetObject("btnAdd.Image");

        this.btnAdd.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnAdd.ImageAlign");

        this.btnAdd.ImageIndex = (int) resources.GetObject("btnAdd.ImageIndex");

        this.btnAdd.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnAdd.ImeMode");

        this.btnAdd.Location = (System.Drawing.Point) resources.GetObject("btnAdd.Location");

        this.btnAdd.Name = "btnAdd";

        this.btnAdd.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnAdd.RightToLeft");

        this.btnAdd.Size = (System.Drawing.Size) resources.GetObject("btnAdd.Size");

        this.btnAdd.TabIndex = (int) resources.GetObject("btnAdd.TabIndex");

        this.btnAdd.Text = resources.GetString("btnAdd.Text");

        this.btnAdd.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnAdd.TextAlign");

        this.btnAdd.Visible = (bool) resources.GetObject("btnAdd.Visible");

		this.btnAdd.Click+=new EventHandler(btnAdd_Click);

        //

        //btnUpdate

        //

        this.btnUpdate.AccessibleDescription = resources.GetString("btnUpdate.AccessibleDescription");

        this.btnUpdate.AccessibleName = resources.GetString("btnUpdate.AccessibleName");

        this.btnUpdate.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnUpdate.Anchor");

        this.btnUpdate.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnUpdate.BackgroundImage");

        this.btnUpdate.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnUpdate.Dock");

        this.btnUpdate.Enabled = (bool) resources.GetObject("btnUpdate.Enabled");

        this.btnUpdate.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnUpdate.FlatStyle");

        this.btnUpdate.Font = (System.Drawing.Font) resources.GetObject("btnUpdate.Font");

        this.btnUpdate.Image = (System.Drawing.Image) resources.GetObject("btnUpdate.Image");

        this.btnUpdate.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnUpdate.ImageAlign");

        this.btnUpdate.ImageIndex = (int) resources.GetObject("btnUpdate.ImageIndex");

        this.btnUpdate.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnUpdate.ImeMode");

        this.btnUpdate.Location = (System.Drawing.Point) resources.GetObject("btnUpdate.Location");

        this.btnUpdate.Name = "btnUpdate";

        this.btnUpdate.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnUpdate.RightToLeft");

        this.btnUpdate.Size = (System.Drawing.Size) resources.GetObject("btnUpdate.Size");

        this.btnUpdate.TabIndex = (int) resources.GetObject("btnUpdate.TabIndex");

        this.btnUpdate.Text = resources.GetString("btnUpdate.Text");

        this.btnUpdate.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnUpdate.TextAlign");

        this.btnUpdate.Visible = (bool) resources.GetObject("btnUpdate.Visible");
		
		this.btnUpdate.Click+=new EventHandler(btnUpdate_Click);
        //

        //btnDelete

        //

        this.btnDelete.AccessibleDescription = resources.GetString("btnDelete.AccessibleDescription");

        this.btnDelete.AccessibleName = resources.GetString("btnDelete.AccessibleName");

        this.btnDelete.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnDelete.Anchor");

        this.btnDelete.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnDelete.BackgroundImage");

        this.btnDelete.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnDelete.Dock");

        this.btnDelete.Enabled = (bool) resources.GetObject("btnDelete.Enabled");

        this.btnDelete.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnDelete.FlatStyle");

        this.btnDelete.Font = (System.Drawing.Font) resources.GetObject("btnDelete.Font");

        this.btnDelete.Image = (System.Drawing.Image) resources.GetObject("btnDelete.Image");

        this.btnDelete.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDelete.ImageAlign");

        this.btnDelete.ImageIndex = (int) resources.GetObject("btnDelete.ImageIndex");

        this.btnDelete.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnDelete.ImeMode");

        this.btnDelete.Location = (System.Drawing.Point) resources.GetObject("btnDelete.Location");

        this.btnDelete.Name = "btnDelete";

        this.btnDelete.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnDelete.RightToLeft");

        this.btnDelete.Size = (System.Drawing.Size) resources.GetObject("btnDelete.Size");

        this.btnDelete.TabIndex = (int) resources.GetObject("btnDelete.TabIndex");

        this.btnDelete.Text = resources.GetString("btnDelete.Text");

        this.btnDelete.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnDelete.TextAlign");

        this.btnDelete.Visible = (bool) resources.GetObject("btnDelete.Visible");

		this.btnDelete.Click+=new EventHandler(btnDelete_Click);

        //

        //lblProductList

        //

        this.lblProductList.AccessibleDescription = (string) resources.GetObject("lblProductList.AccessibleDescription");

        this.lblProductList.AccessibleName = (string) resources.GetObject("lblProductList.AccessibleName");

        this.lblProductList.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblProductList.Anchor");

        this.lblProductList.AutoSize = (bool) resources.GetObject("lblProductList.AutoSize");

        this.lblProductList.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblProductList.Dock");

        this.lblProductList.Enabled = (bool) resources.GetObject("lblProductList.Enabled");

        this.lblProductList.Font = (System.Drawing.Font) resources.GetObject("lblProductList.Font");

        this.lblProductList.Image = (System.Drawing.Image) resources.GetObject("lblProductList.Image");

        this.lblProductList.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblProductList.ImageAlign");

        this.lblProductList.ImageIndex = (int) resources.GetObject("lblProductList.ImageIndex");

        this.lblProductList.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblProductList.ImeMode");

        this.lblProductList.Location = (System.Drawing.Point) resources.GetObject("lblProductList.Location");

        this.lblProductList.Name = "lblProductList";

        this.lblProductList.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblProductList.RightToLeft");

        this.lblProductList.Size = (System.Drawing.Size) resources.GetObject("lblProductList.Size");

        this.lblProductList.TabIndex = (int) resources.GetObject("lblProductList.TabIndex");

        this.lblProductList.Text = resources.GetString("lblProductList.Text");

        this.lblProductList.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblProductList.TextAlign");

        this.lblProductList.Visible = (bool) resources.GetObject("lblProductList.Visible");

        //

        //mnuMain

        //

        this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.MenuItem1, this.MenuItem4});

       // this.mnuMain.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("mnuMain.RightToLeft");

	
        //

        //MenuItem1

        //

        this.MenuItem1.Enabled = (bool) resources.GetObject("MenuItem1.Enabled");

        this.MenuItem1.Index = 0;

        this.MenuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuExit});

        this.MenuItem1.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem1.Shortcut");

        this.MenuItem1.ShowShortcut = (bool) resources.GetObject("MenuItem1.ShowShortcut");

        this.MenuItem1.Text = resources.GetString("MenuItem1.Text");

        this.MenuItem1.Visible = (bool) resources.GetObject("MenuItem1.Visible");

        //

        //mnuExit

        //

        this.mnuExit.Enabled = (bool) resources.GetObject("mnuExit.Enabled");

        this.mnuExit.Index = 0;

        this.mnuExit.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuExit.Shortcut");

        this.mnuExit.ShowShortcut = (bool) resources.GetObject("mnuExit.ShowShortcut");

        this.mnuExit.Text = resources.GetString("mnuExit.Text");

        this.mnuExit.Visible = (bool) resources.GetObject("mnuExit.Visible");

		this.mnuExit.Click+=new EventHandler(mnuExit_Click);

        //

        //MenuItem4

        //

        this.MenuItem4.Enabled = (bool) resources.GetObject("MenuItem4.Enabled");

        this.MenuItem4.Index = 1;

        this.MenuItem4.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuAbout});

        this.MenuItem4.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("MenuItem4.Shortcut");

        this.MenuItem4.ShowShortcut = (bool) resources.GetObject("MenuItem4.ShowShortcut");

        this.MenuItem4.Text = resources.GetString("MenuItem4.Text");

        this.MenuItem4.Visible = (bool) resources.GetObject("MenuItem4.Visible");

        //

        //mnuAbout

        //

        this.mnuAbout.Enabled = (bool) resources.GetObject("mnuAbout.Enabled");

        this.mnuAbout.Index = 0;

        this.mnuAbout.Shortcut = (System.Windows.Forms.Shortcut) resources.GetObject("mnuAbout.Shortcut");

        this.mnuAbout.ShowShortcut = (bool) resources.GetObject("mnuAbout.ShowShortcut");

        this.mnuAbout.Text = resources.GetString("mnuAbout.Text");

        this.mnuAbout.Visible = (bool) resources.GetObject("mnuAbout.Visible");

		this.mnuAbout.Click+=new EventHandler(mnuAbout_Click);

        //

        //btnRefresh

        //

        this.btnRefresh.AccessibleDescription = resources.GetString("btnRefresh.AccessibleDescription");

        this.btnRefresh.AccessibleName = resources.GetString("btnRefresh.AccessibleName");

        this.btnRefresh.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnRefresh.Anchor");

        this.btnRefresh.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnRefresh.BackgroundImage");

        this.btnRefresh.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnRefresh.Dock");

        this.btnRefresh.Enabled = (bool) resources.GetObject("btnRefresh.Enabled");

        this.btnRefresh.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnRefresh.FlatStyle");

        this.btnRefresh.Font = (System.Drawing.Font) resources.GetObject("btnRefresh.Font");

        this.btnRefresh.Image = (System.Drawing.Image) resources.GetObject("btnRefresh.Image");

        this.btnRefresh.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRefresh.ImageAlign");

        this.btnRefresh.ImageIndex = (int) resources.GetObject("btnRefresh.ImageIndex");

        this.btnRefresh.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnRefresh.ImeMode");

        this.btnRefresh.Location = (System.Drawing.Point) resources.GetObject("btnRefresh.Location");

        this.btnRefresh.Name = "btnRefresh";

        this.btnRefresh.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnRefresh.RightToLeft");

        this.btnRefresh.Size = (System.Drawing.Size) resources.GetObject("btnRefresh.Size");

        this.btnRefresh.TabIndex = (int) resources.GetObject("btnRefresh.TabIndex");

        this.btnRefresh.Text = resources.GetString("btnRefresh.Text");

        this.btnRefresh.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnRefresh.TextAlign");

        this.btnRefresh.Visible = (bool) resources.GetObject("btnRefresh.Visible");

		this.btnRefresh.Click+=new EventHandler(btnRefresh_Click);

        //

        //frmMain

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnRefresh, this.lblProductList, this.btnDelete, this.btnUpdate, this.btnAdd, this.gbHorvRule, this.lblQtyPerUnit, this.lblReorderLevel, this.lblUnitsOnOrder, this.lblUnitsInStock, this.lblUnitPrice, this.lblCategories, this.lblSuppliers, this.lblProductName, this.lblProductID, this.lstProducts, this.chkDiscontinued, this.cbCategories, this.cbSuppliers, this.txtQtyPerUnit, this.txtReorderLevel, this.txtUnitsInStock, this.txtUnitsOnOrder, this.txtUnitPrice, this.txtProductName, this.txtProductID});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

        this.MaximizeBox = false;

        this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

        this.Menu = this.mnuMain;

        this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

        this.Name = "frmMain";

        this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

        this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

        this.Text = resources.GetString("$this.Text");

        this.Visible = (bool) resources.GetObject("$this.Visible");

		this.Load+=new EventHandler(frmDataEntry_Load);

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

    private void btnAdd_Click(object sender, System.EventArgs e)
	{

        ClearForm();
        Mode = "Add";
        btnDelete.Enabled = false;
        btnAdd.Enabled = false;

    }

    private void btnDelete_Click(object sender, System.EventArgs e)
	{

        DeleteProduct();

    }

    private void btnUpdate_Click(object sender, System.EventArgs e)
	{

        // Check mode to determine action

		if (Mode == "Add")
		{

			AddProduct();
		}
		else 
		{

			UpdateProduct();

		}

    }

    private void frmDataEntry_Load(object sender,System.EventArgs e) 
	{

        // Populate all the list and combo boxes used on the form

        PopulateCategoryCombo();
        PopulateSupplierCombo();
        PopulateProductList();

    }

    private void lstProducts_SelectedIndexChanged(object sender,System.EventArgs e) 
	{
        PopulateForm();

        btnDelete.Enabled = true;

        btnAdd.Enabled = true;

        Mode = "Update";
    }

    private void AddProduct()
	{

        // This sub is used to add a product record to the database
        // when the user clicks the Update button and the mode is set
        // to ADD
        // Validate form values.

        if (IsValidForm()==false)
		{
            return;
        }

        SqlConnection cnSQL;

        SqlCommand cmSQL;

        string strSQL;
        string ProductName  = txtProductName.Text;

        try 
		{

            // Build Insert statement to insert new product into the products table
			string Discontinued;

			if (chkDiscontinued.Checked)
			{
				Discontinued="1";
								}
			else
			{
				Discontinued="0";
			}

            strSQL = "INSERT Products VALUES (" + 
                     PrepareStr(ProductName) + "," + 
                     ((ListItem) cbSuppliers.Items[cbSuppliers.SelectedIndex]).ID + "," +
					 ((ListItem) cbCategories.Items[cbCategories.SelectedIndex]).ID + "," +	
                     PrepareStr(txtQtyPerUnit.Text) + "," + 
                     txtUnitPrice.Text + "," + 
                     txtUnitsInStock.Text + "," + 
                     txtUnitsOnOrder.Text + "," + 
                     txtReorderLevel.Text + "," + 
					 Discontinued + ")";
					
            cnSQL = new SqlConnection(Connectionstring);

            cnSQL.Open();

            cmSQL = new SqlCommand(strSQL, cnSQL);

            cmSQL.ExecuteNonQuery();

            // Close and Clean up objects

            cnSQL.Close();

            cmSQL.Dispose();

            cnSQL.Dispose();

            // Refresh Product List

            PopulateProductList();

            FindProductByName(lstProducts, ProductName);

		} 
		catch(SqlException Exp) 
		{
            MessageBox.Show(Exp.Message, "SQL Error");

		} 
		catch(Exception Exp)
		{
            MessageBox.Show(Exp.Message, "General Error");
        }

    }

    private void ClearForm()
	{

        // Clear the data entry form.

        txtProductID.Text = string.Empty;

        txtProductName.Text = string.Empty;

        txtQtyPerUnit.Text = string.Empty;

        txtUnitPrice.Text = "0.00";

        txtUnitsInStock.Text = "0";

        txtUnitsOnOrder.Text = "0";

        txtReorderLevel.Text = "0";

        chkDiscontinued.Checked = false;

        cbSuppliers.SelectedIndex = -1;

        cbCategories.SelectedIndex = -1;

    }

    private void DeleteProduct()
	{

        // This sub is used to delete the product record from the database
        // when the user clicks the delete button

        SqlConnection cnSQL;

        SqlCommand cmSQL;

        string strSQL;

        int intRowsAffected;

        try 
		{

            // Build Delete statement to delete the current product from table

            strSQL = "DELETE FROM Products " +
                     "WHERE ProductID = " + Convert.ToInt32(txtProductID.Text);

            cnSQL = new SqlConnection(Connectionstring);

            cnSQL.Open();

            cmSQL = new SqlCommand(strSQL, cnSQL);

            intRowsAffected = cmSQL.ExecuteNonQuery();

            if (intRowsAffected != 1)
			{

                MessageBox.Show("Delete Failed. Product ID " + txtProductID.Text +
                       " not found.","Delete");
            }

            // Close and Clean up objects

            cnSQL.Close();

            cmSQL.Dispose();

            cnSQL.Dispose();

            PopulateProductList();

       } 
		catch( SqlException e) 
		{
            MessageBox.Show(e.Message, "SQL Error");

       } 
		catch( Exception e)
		{
            MessageBox.Show(e.Message,"General Error");

        }

    }

    private void FindItemByID(ComboBox cbCombo , string strID )
	{

        // This sub is used to find an Item in a combobox and
        // set the selected index of the combo box to that item

        bool bFound=false;

        ListItem ListItem;

        int ItemCount;

        ListItem = new ListItem();

        ItemCount = 0;

        while (bFound==false | ItemCount <= cbCombo.Items.Count - 1)
		{

            ListItem = (ListItem) cbCombo.Items[ItemCount];

            if (ListItem.ID == System.Convert.ToInt32(strID)) 
			{
                cbCombo.SelectedIndex = ItemCount;

                bFound = true;

            }

            ItemCount += 1;

        }

        if (bFound==false) 
		{

            cbCombo.SelectedIndex = -1;

        }

    }

    private void FindProductByName(ListBox lbList , string strValue )
	{

        // This sub is used to find a Product in the product
        // list box and set the selected index of the list box
        // to that item

        bool bIsFound=false;

        ListItem ListItem;

        int ItemCount;

        ListItem = new ListItem();

        ItemCount = 0;

        // Loop through the list until the item is found

        while (bIsFound==false & ItemCount <= lbList.Items.Count - 1)
		{
            ListItem = (ListItem) lbList.Items[ItemCount];

            if (ListItem.Value == strValue)
			{

                lbList.SelectedIndex = ItemCount;

                bIsFound = true;

            }

            ItemCount += 1;

        }

        if (bIsFound==false) 
		{

            lbList.SelectedIndex = 0;
        }

    }
	
	public bool IsNumeric(string val)
	{
		try
		{
			double result = 0;
			return Double.TryParse(val, System.Globalization.NumberStyles.Any, System.Globalization.NumberFormatInfo.CurrentInfo, out result);
		}
		catch
		{
			return false;
		}
	}

    private bool IsValidForm() 
	{

        // Check to make sure each field has a valid value

	
	if (txtProductName.Text == "" | 
			txtQtyPerUnit.Text == "" | 
			txtUnitPrice.Text == "" | 
			txtUnitsInStock.Text == "" | 
			txtUnitsOnOrder.Text == "" | 
			txtReorderLevel.Text == "" | 
			cbCategories.SelectedIndex == -1 | 
			cbSuppliers.SelectedIndex == -1 | 
			IsNumeric(txtUnitPrice.Text)==false | 
			IsNumeric(txtUnitsInStock.Text)==false | 
			IsNumeric(txtUnitsOnOrder.Text)==false | 
			IsNumeric(txtReorderLevel.Text)==false) 
		{

			MessageBox.Show("Please enter a valid value for each field.", this.Text);

			return false;
		}
		else 
		{

			return true;

		}

    }

    private void PopulateCategoryCombo()
	{

        // This procedure populates the list box on the
        // form with a list of Categories from the
        // Northwind database.

        SqlConnection cnSQL;

        SqlCommand cmSQL;

        SqlDataReader drSQL;
		
        string strSQL;

        ListItem objListItem;

        // Display a status message box saying that we are attempting to connect.
        // This only needs to be done the first time a connection is attempted.
        // After we have determined that MSDE or SQL Server is installed, this 
        // message no longer needs to be displayed

        frmStatus frmStatusMessage = new frmStatus();

        if (HasConnected==false) 
		{

            frmStatusMessage.Show("Connecting to SQL Server");

        }

        // Attempt to connect to SQL server or MSDE

        bool IsConnecting = true;

        while (IsConnecting)
		{
            try 
			{
                // Build Select statement to query Category Name from the Categories
                // table.

                strSQL = "SELECT CategoryID, CategoryName FROM Categories";
                cnSQL = new SqlConnection(Connectionstring);
                cnSQL.Open();
                cmSQL = new SqlCommand(strSQL, cnSQL);
                drSQL = cmSQL.ExecuteReader();
                cbCategories.Items.Clear();

                // Loop through the result set and add the category 
                // names to the combo box.

				while (drSQL.Read())
				{
					objListItem = new ListItem(drSQL["CategoryName"].ToString(),
						Convert.ToInt32(drSQL["CategoryID"]));
			
					cbCategories.Items.Add(objListItem);

				}

                IsConnecting = false;
                HasConnected = true;

                // Close and Clean up objects

                drSQL.Close();
                cnSQL.Close();
                cmSQL.Dispose();
                cnSQL.Dispose();

           } 
			catch(SqlException e)
			{

				if (Connectionstring ==SQL_CONNECTION_STRING)
				{

					// Couldn't connect to SQL server. Now try MSDE
					Connectionstring = MSDE_CONNECTION_STRING;
					frmStatusMessage.Show("Connecting to MSDE");
				}
				else 
				{

					// Unable to connect to SQL Server or MSDE

					frmStatusMessage.Close();
					MessageBox.Show("To run this sample you must have SQL Server ot MSDE with " + 
									"the Northwind database installed.  For instructions on " + 
									"installing MSDE, view the Readme file.",  
									"SQL Server/MSDE not found");

					// Quit program if neither connection method was successful.

					Application.Exit();					
				}

           } 
			catch(Exception e)
			{
                MessageBox.Show(e.Message,"General Error");
            }

            frmStatusMessage.Close();

        }

    }

    private void PopulateForm()
	{

        SqlConnection cnSQL;

        SqlCommand cmSQL;

        SqlDataReader drSQL;

        string strSQL;

        ListItem objListItem;

        string strID;

        try 
		{

            // Get Primary Key from Listbox
            objListItem = (ListItem) lstProducts.SelectedItem;

            // Build Select statement to query product information from the products
            // table 

            strSQL = "SELECT ProductID, " + 

                     "       ProductName, " +

                     "       QuantityPerUnit, " +

                     "       UnitPrice, " + 

                     "       UnitsInStock, " + 

                     "       UnitsOnOrder, " + 

                     "       ReorderLevel, " + 

                     "       Discontinued, " + 

                     "       SupplierID, " + 

                     "       CategoryID " + 

                     "FROM Products " + 

                     "WHERE ProductID = " + objListItem.ID;

            cnSQL = new SqlConnection(Connectionstring);
            cnSQL.Open();
            cmSQL = new SqlCommand(strSQL, cnSQL);
            drSQL = cmSQL.ExecuteReader();

            if (drSQL.Read())
			{
                // Populate form with the data

                txtProductID.Text = drSQL["ProductID"].ToString();

                txtProductName.Text = drSQL["ProductName"].ToString();

                txtQtyPerUnit.Text = drSQL["QuantityPerUnit"].ToString();

                txtUnitPrice.Text = drSQL["UnitPrice"].ToString();

                txtUnitsInStock.Text = drSQL["UnitsInStock"].ToString();

                txtUnitsOnOrder.Text = drSQL["UnitsOnOrder"].ToString();

                txtReorderLevel.Text = drSQL["ReorderLevel"].ToString();

                chkDiscontinued.Checked = (bool) drSQL["Discontinued"];

                strID = drSQL["SupplierID"].ToString();

                FindItemByID(cbSuppliers, strID);

                strID = drSQL["CategoryID"].ToString();

                FindItemByID(cbCategories, strID);

            }

            // Close and Clean up objects

            drSQL.Close();
            cnSQL.Close();
            cmSQL.Dispose();
            cnSQL.Dispose();

       } 
		catch(SqlException e)
		{
            MessageBox.Show(e.Message,  "SQL Error");

       } 
		catch(Exception e)
		{
            MessageBox.Show(e.Message, "General Error");
        }

    }

    private void PopulateProductList()
	{

        // This procedure populates the list box on the
        // form with a list of available products from the
        // Northwind database.

        SqlConnection cnSQL;

        SqlCommand cmSQL;

        SqlDataReader drSQL;

        string strSQL;

        ListItem objListItem;

        try 
		{

            // Build Select statement to query product names from the products
            // table.

            strSQL = "SELECT ProductName, ProductID FROM Products";
            cnSQL = new SqlConnection(Connectionstring);
            cnSQL.Open();
            cmSQL = new SqlCommand(strSQL, cnSQL);
            drSQL = cmSQL.ExecuteReader();
            lstProducts.Items.Clear();

            // Loop through the result set using the datareader class.  
            // The datareader is used here because all that is needed 
            // is a forward only cursor which is more efficient.             

			while (drSQL.Read())
			{

				objListItem = new ListItem(drSQL["ProductName"].ToString(),
					Convert.ToInt32(drSQL["ProductID"]));

				lstProducts.Items.Add(objListItem);

			}

            if (lstProducts.Items.Count > 0)
			{
                lstProducts.SetSelected(0, true);
            }

            // Close and Clean up objects

            drSQL.Close();
            cnSQL.Close();
            cmSQL.Dispose();
            cnSQL.Dispose();

		} 
		catch(SqlException e)
		{

            MessageBox.Show(e.Message, "SQL Error");
		} 
		catch(Exception e)
		{
            MessageBox.Show(e.Message,  "General Error");
        }

    }

    private void PopulateSupplierCombo()
	{

        // This procedure populates the supplier combo box
        // on the form with a list of available Suppliers 
        // from the Northwind database.

        SqlConnection cnSQL;
        SqlCommand cmSQL;
		SqlDataReader drSQL;

        string strSQL;

        ListItem objListItem;

		try 
		{

			// Build Select statement to query Suppliers Name from the Suppliers
			// table.

			strSQL = "SELECT SupplierID, CompanyName FROM Suppliers";
			cnSQL = new SqlConnection(Connectionstring);
			cnSQL.Open();
			cmSQL = new SqlCommand(strSQL, cnSQL);
			drSQL = cmSQL.ExecuteReader();
			cbSuppliers.Items.Clear();

			// Loop through the result set and add the supplier names to the combo
			// box.

			while (drSQL.Read())
			{
				objListItem = new ListItem(drSQL["CompanyName"].ToString(),
					System.Convert.ToInt32(drSQL["SupplierID"]));

			cbSuppliers.Items.Add(objListItem);

			}

            // Close and Clean up objects

            drSQL.Close();
            cnSQL.Close();
            cmSQL.Dispose();
            cnSQL.Dispose();

       } 
		catch(SqlException e)
		{
            MessageBox.Show(e.Message, "SQL Error");

		} 
		catch(Exception e)
		{
            MessageBox.Show(e.Message, "General Error");

        }

    }

    private string PrepareStr(string strValue )
	{

        // This function accepts a string and creates a string that can
        // be used in a SQL statement by adding single quotes around
        // it and handling empty values.

        if (strValue.Trim() == "") 						
		{

			return "NULL";
		}
        else 
		{

            return "'" + strValue.Trim() + "'";
        }
    }

    private void UpdateProduct()
	{

        // This sub is used to update and existing record with values
        // from the form.

        SqlConnection cnSQL;
        SqlCommand cmSQL;
        string strSQL;
        int intRowsAffected;

        // Validate form values.

        if (IsValidForm()==false)
		{

            return;

		}

        try 
		{

            // Build update statement to update product table with data
            // on form.
			
			string Discontinued;

			if (chkDiscontinued.Checked)
			{
				Discontinued="1";
			}
			else
			{
				Discontinued="0";
			}
            strSQL = "UPDATE Products SET" + 
                     " ProductName = " + PrepareStr(txtProductName.Text) + 
                     " ,QuantityPerUnit = " + PrepareStr(txtQtyPerUnit.Text) + 
                     " ,UnitPrice = " + txtUnitPrice.Text + 
                     " ,UnitsInStock = " + txtUnitsInStock.Text + 
                     " ,UnitsOnOrder = " + txtUnitsOnOrder.Text + 
                     " ,ReorderLevel = " + txtReorderLevel.Text + 
					" ,SupplierID = " +  ((ListItem) cbSuppliers.Items[cbSuppliers.SelectedIndex]).ID  +	
                     " ,CategoryID = " + ((ListItem) cbCategories.Items[cbCategories.SelectedIndex]).ID +	
                     " ,Discontinued = " + Discontinued + " " + 
					"WHERE ProductID = " + Convert.ToInt32(txtProductID.Text);
			
            cnSQL = new SqlConnection(Connectionstring);
            cnSQL.Open();
            cmSQL = new SqlCommand(strSQL, cnSQL);
            intRowsAffected = cmSQL.ExecuteNonQuery();

            if (intRowsAffected != 1)
			{
                MessageBox.Show("Update Failed.", "Update");
            }

            // Close and Clean up objects

            cnSQL.Close();
            cmSQL.Dispose();
            cnSQL.Dispose();

			} 
			catch(SqlException e)
			{
            
			MessageBox.Show(e.Message, "SQL Error");
			
			} 
			catch(Exception e)
			{

            MessageBox.Show(e.Message, "General Error");

        }

    }

    private void btnRefresh_Click(object sender, System.EventArgs e)
	{

        PopulateCategoryCombo();
        PopulateSupplierCombo();
        PopulateProductList();

    }

}

