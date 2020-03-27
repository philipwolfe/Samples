using System;
using System.Windows.Forms;
using System.Data;
using System.Globalization;

public class frmDataEntry : System.Windows.Forms.Form 
{
    private DataTable dt = new DataTable("Names");

#region " Windows Form Designer generated code "

    public frmDataEntry() 
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

    private System.Windows.Forms.GroupBox GroupBox1;

    private System.Windows.Forms.Button cmdSave;

    private System.Windows.Forms.TextBox txtCity;

    private System.Windows.Forms.TextBox txtName;

    private System.Windows.Forms.Label lblCity;

    private System.Windows.Forms.Label lblName;

    private System.Windows.Forms.DataGrid grdPeople;

    private System.Windows.Forms.Label lblWelcome;

    private System.Windows.Forms.Button cmdQuit;

    private System.Windows.Forms.PictureBox PictureBox1;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmDataEntry));

        this.GroupBox1 = new System.Windows.Forms.GroupBox();

        this.cmdSave = new System.Windows.Forms.Button();

        this.txtCity = new System.Windows.Forms.TextBox();

        this.txtName = new System.Windows.Forms.TextBox();

        this.lblCity = new System.Windows.Forms.Label();

        this.lblName = new System.Windows.Forms.Label();

        this.grdPeople = new System.Windows.Forms.DataGrid();

        this.lblWelcome = new System.Windows.Forms.Label();

        this.cmdQuit = new System.Windows.Forms.Button();

        this.PictureBox1 = new System.Windows.Forms.PictureBox();

        this.GroupBox1.SuspendLayout();

        ((System.ComponentModel.ISupportInitialize) this.grdPeople).BeginInit();

        this.SuspendLayout();

        //

        //GroupBox1

        //

        this.GroupBox1.AccessibleDescription = (string) resources.GetObject("GroupBox1.AccessibleDescription");

        this.GroupBox1.AccessibleName = (string) resources.GetObject("GroupBox1.AccessibleName");

        this.GroupBox1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("GroupBox1.Anchor");

        this.GroupBox1.BackgroundImage = (System.Drawing.Image) resources.GetObject("GroupBox1.BackgroundImage");

        this.GroupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmdSave, this.txtCity, this.txtName, this.lblCity, this.lblName});

        this.GroupBox1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("GroupBox1.Dock");

        this.GroupBox1.Enabled = (bool) resources.GetObject("GroupBox1.Enabled");

        this.GroupBox1.Font = (System.Drawing.Font) resources.GetObject("GroupBox1.Font");

        this.GroupBox1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("GroupBox1.ImeMode");

        this.GroupBox1.Location = (System.Drawing.Point) resources.GetObject("GroupBox1.Location");

        this.GroupBox1.Name = "GroupBox1";

        this.GroupBox1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("GroupBox1.RightToLeft");

        this.GroupBox1.Size = (System.Drawing.Size) resources.GetObject("GroupBox1.Size");

        this.GroupBox1.TabIndex = (int) resources.GetObject("GroupBox1.TabIndex");

        this.GroupBox1.TabStop = false;

        this.GroupBox1.Text = resources.GetString("GroupBox1.Text");

        this.GroupBox1.Visible = (bool) resources.GetObject("GroupBox1.Visible");

        //

        //cmdSave

        //

        this.cmdSave.AccessibleDescription = (string) resources.GetObject("cmdSave.AccessibleDescription");

        this.cmdSave.AccessibleName = (string) resources.GetObject("cmdSave.AccessibleName");

        this.cmdSave.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cmdSave.Anchor");

        this.cmdSave.BackgroundImage = (System.Drawing.Image) resources.GetObject("cmdSave.BackgroundImage");

        this.cmdSave.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cmdSave.Dock");

        this.cmdSave.Enabled = (bool) resources.GetObject("cmdSave.Enabled");

        this.cmdSave.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("cmdSave.FlatStyle");

        this.cmdSave.Font = (System.Drawing.Font) resources.GetObject("cmdSave.Font");

        this.cmdSave.Image = (System.Drawing.Image) resources.GetObject("cmdSave.Image");

        this.cmdSave.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("cmdSave.ImageAlign");

        this.cmdSave.ImageIndex = (int) resources.GetObject("cmdSave.ImageIndex");

        this.cmdSave.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cmdSave.ImeMode");

        this.cmdSave.Location = (System.Drawing.Point) resources.GetObject("cmdSave.Location");

        this.cmdSave.Name = "cmdSave";

        this.cmdSave.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cmdSave.RightToLeft");

        this.cmdSave.Size = (System.Drawing.Size) resources.GetObject("cmdSave.Size");

        this.cmdSave.TabIndex = (int) resources.GetObject("cmdSave.TabIndex");

        this.cmdSave.Text = resources.GetString("cmdSave.Text");

        this.cmdSave.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("cmdSave.TextAlign");

        this.cmdSave.Visible = (bool) resources.GetObject("cmdSave.Visible");

		this.cmdSave.Click += new EventHandler(cmdSave_Click);

        //

        //txtCity

        //

        this.txtCity.AccessibleDescription = (string) resources.GetObject("txtCity.AccessibleDescription");

        this.txtCity.AccessibleName = (string) resources.GetObject("txtCity.AccessibleName");

        this.txtCity.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtCity.Anchor");

        this.txtCity.AutoSize = (bool) resources.GetObject("txtCity.AutoSize");

        this.txtCity.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtCity.BackgroundImage");

        this.txtCity.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtCity.Dock");

        this.txtCity.Enabled = (bool) resources.GetObject("txtCity.Enabled");

        this.txtCity.Font = (System.Drawing.Font) resources.GetObject("txtCity.Font");

        this.txtCity.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtCity.ImeMode");

        this.txtCity.Location = (System.Drawing.Point) resources.GetObject("txtCity.Location");

        this.txtCity.MaxLength = (int) resources.GetObject("txtCity.MaxLength");

        this.txtCity.Multiline = (bool) resources.GetObject("txtCity.Multiline");

        this.txtCity.Name = "txtCity";

        this.txtCity.PasswordChar = (char) resources.GetObject("txtCity.PasswordChar");

        this.txtCity.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtCity.RightToLeft");

        this.txtCity.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtCity.ScrollBars");

        this.txtCity.Size = (System.Drawing.Size) resources.GetObject("txtCity.Size");

        this.txtCity.TabIndex = (int) resources.GetObject("txtCity.TabIndex");

        this.txtCity.Text = resources.GetString("txtCity.Text");

        this.txtCity.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtCity.TextAlign");

        this.txtCity.Visible = (bool) resources.GetObject("txtCity.Visible");

        this.txtCity.WordWrap = (bool) resources.GetObject("txtCity.WordWrap");

        //

        //txtName

        //

        this.txtName.AccessibleDescription = (string) resources.GetObject("txtName.AccessibleDescription");

        this.txtName.AccessibleName = (string) resources.GetObject("txtName.AccessibleName");

        this.txtName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("txtName.Anchor");

        this.txtName.AutoSize = (bool) resources.GetObject("txtName.AutoSize");

        this.txtName.BackgroundImage = (System.Drawing.Image) resources.GetObject("txtName.BackgroundImage");

        this.txtName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("txtName.Dock");

        this.txtName.Enabled = (bool) resources.GetObject("txtName.Enabled");

        this.txtName.Font = (System.Drawing.Font) resources.GetObject("txtName.Font");

        this.txtName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("txtName.ImeMode");

        this.txtName.Location = (System.Drawing.Point) resources.GetObject("txtName.Location");

        this.txtName.MaxLength = (int) resources.GetObject("txtName.MaxLength");

        this.txtName.Multiline = (bool) resources.GetObject("txtName.Multiline");

        this.txtName.Name = "txtName";

        this.txtName.PasswordChar = (char) resources.GetObject("txtName.PasswordChar");

        this.txtName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("txtName.RightToLeft");

        this.txtName.ScrollBars = (System.Windows.Forms.ScrollBars) resources.GetObject("txtName.ScrollBars");

        this.txtName.Size = (System.Drawing.Size) resources.GetObject("txtName.Size");

        this.txtName.TabIndex = (int) resources.GetObject("txtName.TabIndex");

        this.txtName.Text = resources.GetString("txtName.Text");

        this.txtName.TextAlign = (System.Windows.Forms.HorizontalAlignment) resources.GetObject("txtName.TextAlign");

        this.txtName.Visible = (bool) resources.GetObject("txtName.Visible");

        this.txtName.WordWrap = (bool) resources.GetObject("txtName.WordWrap");

        //

        //lblCity

        //

        this.lblCity.AccessibleDescription = (string) resources.GetObject("lblCity.AccessibleDescription");

        this.lblCity.AccessibleName = (string) resources.GetObject("lblCity.AccessibleName");

        this.lblCity.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblCity.Anchor");

        this.lblCity.AutoSize = (bool) resources.GetObject("lblCity.AutoSize");

        this.lblCity.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblCity.Dock");

        this.lblCity.Enabled = (bool) resources.GetObject("lblCity.Enabled");

        this.lblCity.Font = (System.Drawing.Font) resources.GetObject("lblCity.Font");

        this.lblCity.Image = (System.Drawing.Image) resources.GetObject("lblCity.Image");

        this.lblCity.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblCity.ImageAlign");

        this.lblCity.ImageIndex = (int) resources.GetObject("lblCity.ImageIndex");

        this.lblCity.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblCity.ImeMode");

        this.lblCity.Location = (System.Drawing.Point) resources.GetObject("lblCity.Location");

        this.lblCity.Name = "lblCity";

        this.lblCity.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblCity.RightToLeft");

        this.lblCity.Size = (System.Drawing.Size) resources.GetObject("lblCity.Size");

        this.lblCity.TabIndex = (int) resources.GetObject("lblCity.TabIndex");

        this.lblCity.Text = resources.GetString("lblCity.Text");

        this.lblCity.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblCity.TextAlign");

        this.lblCity.Visible = (bool) resources.GetObject("lblCity.Visible");

        //

        //lblName

        //

        this.lblName.AccessibleDescription = (string) resources.GetObject("lblName.AccessibleDescription");

        this.lblName.AccessibleName = (string) resources.GetObject("lblName.AccessibleName");

        this.lblName.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblName.Anchor");

        this.lblName.AutoSize = (bool) resources.GetObject("lblName.AutoSize");

        this.lblName.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblName.Dock");

        this.lblName.Enabled = (bool) resources.GetObject("lblName.Enabled");

        this.lblName.Font = (System.Drawing.Font) resources.GetObject("lblName.Font");

        this.lblName.Image = (System.Drawing.Image) resources.GetObject("lblName.Image");

        this.lblName.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblName.ImageAlign");

        this.lblName.ImageIndex = (int) resources.GetObject("lblName.ImageIndex");

        this.lblName.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblName.ImeMode");

        this.lblName.Location = (System.Drawing.Point) resources.GetObject("lblName.Location");

        this.lblName.Name = "lblName";

        this.lblName.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblName.RightToLeft");

        this.lblName.Size = (System.Drawing.Size) resources.GetObject("lblName.Size");

        this.lblName.TabIndex = (int) resources.GetObject("lblName.TabIndex");

        this.lblName.Text = resources.GetString("lblName.Text");

        this.lblName.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblName.TextAlign");

        this.lblName.Visible = (bool) resources.GetObject("lblName.Visible");

        //

        //grdPeople

        //

        this.grdPeople.AccessibleDescription = (string) resources.GetObject("grdPeople.AccessibleDescription");

        this.grdPeople.AccessibleName = (string) resources.GetObject("grdPeople.AccessibleName");

        this.grdPeople.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grdPeople.Anchor");

        this.grdPeople.BackgroundImage = (System.Drawing.Image) resources.GetObject("grdPeople.BackgroundImage");

        this.grdPeople.CaptionFont = (System.Drawing.Font) resources.GetObject("grdPeople.CaptionFont");

        this.grdPeople.CaptionText = resources.GetString("grdPeople.CaptionText");

        this.grdPeople.ColumnHeadersVisible = false;

        this.grdPeople.DataMember = string.Empty;

        this.grdPeople.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("grdPeople.Dock");

        this.grdPeople.Enabled = (bool) resources.GetObject("grdPeople.Enabled");

        this.grdPeople.Font = (System.Drawing.Font) resources.GetObject("grdPeople.Font");

        this.grdPeople.HeaderForeColor = System.Drawing.SystemColors.ControlText;

        this.grdPeople.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("grdPeople.ImeMode");

        this.grdPeople.Location = (System.Drawing.Point) resources.GetObject("grdPeople.Location");

        this.grdPeople.Name = "grdPeople";

        this.grdPeople.PreferredColumnWidth = 90;

        this.grdPeople.ReadOnly = true;

        this.grdPeople.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("grdPeople.RightToLeft");

        this.grdPeople.RowHeadersVisible = false;

        this.grdPeople.Size = (System.Drawing.Size) resources.GetObject("grdPeople.Size");

        this.grdPeople.TabIndex = (int) resources.GetObject("grdPeople.TabIndex");

        this.grdPeople.TabStop = false;

        this.grdPeople.Visible = (bool) resources.GetObject("grdPeople.Visible");

        //

        //lblWelcome

        //

        this.lblWelcome.AccessibleDescription = (string) resources.GetObject("lblWelcome.AccessibleDescription");

        this.lblWelcome.AccessibleName = (string) resources.GetObject("lblWelcome.AccessibleName");

        this.lblWelcome.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("lblWelcome.Anchor");

        this.lblWelcome.AutoSize = (bool) resources.GetObject("lblWelcome.AutoSize");

        this.lblWelcome.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("lblWelcome.Dock");

        this.lblWelcome.Enabled = (bool) resources.GetObject("lblWelcome.Enabled");

        this.lblWelcome.Font = (System.Drawing.Font) resources.GetObject("lblWelcome.Font");

        this.lblWelcome.Image = (System.Drawing.Image) resources.GetObject("lblWelcome.Image");

        this.lblWelcome.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblWelcome.ImageAlign");

        this.lblWelcome.ImageIndex = (int) resources.GetObject("lblWelcome.ImageIndex");

        this.lblWelcome.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("lblWelcome.ImeMode");

        this.lblWelcome.Location = (System.Drawing.Point) resources.GetObject("lblWelcome.Location");

        this.lblWelcome.Name = "lblWelcome";

        this.lblWelcome.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("lblWelcome.RightToLeft");

        this.lblWelcome.Size = (System.Drawing.Size) resources.GetObject("lblWelcome.Size");

        this.lblWelcome.TabIndex = (int) resources.GetObject("lblWelcome.TabIndex");

        this.lblWelcome.Text = resources.GetString("lblWelcome.Text");

        this.lblWelcome.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("lblWelcome.TextAlign");

        this.lblWelcome.Visible = (bool) resources.GetObject("lblWelcome.Visible");

        //

        //cmdQuit

        //

        this.cmdQuit.AccessibleDescription = (string) resources.GetObject("cmdQuit.AccessibleDescription");

        this.cmdQuit.AccessibleName = (string) resources.GetObject("cmdQuit.AccessibleName");

        this.cmdQuit.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cmdQuit.Anchor");

        this.cmdQuit.BackgroundImage = (System.Drawing.Image) resources.GetObject("cmdQuit.BackgroundImage");

        this.cmdQuit.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cmdQuit.Dock");

        this.cmdQuit.Enabled = (bool) resources.GetObject("cmdQuit.Enabled");

        this.cmdQuit.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("cmdQuit.FlatStyle");

        this.cmdQuit.Font = (System.Drawing.Font) resources.GetObject("cmdQuit.Font");

        this.cmdQuit.Image = (System.Drawing.Image) resources.GetObject("cmdQuit.Image");

        this.cmdQuit.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("cmdQuit.ImageAlign");

        this.cmdQuit.ImageIndex = (int) resources.GetObject("cmdQuit.ImageIndex");

        this.cmdQuit.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cmdQuit.ImeMode");

        this.cmdQuit.Location = (System.Drawing.Point) resources.GetObject("cmdQuit.Location");

        this.cmdQuit.Name = "cmdQuit";

        this.cmdQuit.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cmdQuit.RightToLeft");

        this.cmdQuit.Size = (System.Drawing.Size) resources.GetObject("cmdQuit.Size");

        this.cmdQuit.TabIndex = (int) resources.GetObject("cmdQuit.TabIndex");

        this.cmdQuit.Text = resources.GetString("cmdQuit.Text");

        this.cmdQuit.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("cmdQuit.TextAlign");

        this.cmdQuit.Visible = (bool) resources.GetObject("cmdQuit.Visible");

		this.cmdQuit.Click += new EventHandler(cmdQuit_Click);

        //

        //PictureBox1

        //

        this.PictureBox1.AccessibleDescription = (string) resources.GetObject("PictureBox1.AccessibleDescription");

        this.PictureBox1.AccessibleName = (string) resources.GetObject("PictureBox1.AccessibleName");

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

        //frmDataEntry

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

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.PictureBox1, this.GroupBox1, this.grdPeople, this.lblWelcome, this.cmdQuit});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

        this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

        this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

        this.Name = "frmDataEntry";

        this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

        this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

        this.Text = resources.GetString("$this.Text");

        this.Visible = (bool) resources.GetObject("$this.Visible");

        this.GroupBox1.ResumeLayout(false);

        ((System.ComponentModel.ISupportInitialize) this.grdPeople).EndInit();

        this.ResumeLayout(false);

		this.Load += new EventHandler(frmDataEntry_Load);
    }

#endregion

    private void cmdQuit_Click(object sender, System.EventArgs e) 
	{
        this.Close();
    }

    private void cmdSave_Click(object sender, System.EventArgs e) 
	{
        DataRow myDataRow;
        // Creates a new Row from the DataTable
        myDataRow = dt.NewRow();
        // Fills in the data
        myDataRow["Name"] = txtName.Text;
        myDataRow["City"] = txtCity.Text;
        //  Adds the new Row to the people DataTable
        dt.Rows.Add(myDataRow);
    }

    private void frmDataEntry_Load(object sender, System.EventArgs e) 
	{
        // Create the schema for the table of names.
        dt.Columns.Add("Name");
        dt.Columns.Add("City");
        grdPeople.DataSource = dt;
    }
}

