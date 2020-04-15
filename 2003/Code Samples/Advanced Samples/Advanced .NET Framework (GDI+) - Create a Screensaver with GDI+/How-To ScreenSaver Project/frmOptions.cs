using System;
using System.Windows.Forms;
using System.IO;

public class frmOptions : System.Windows.Forms.Form 
{
#region " Windows Form Designer generated code "
    public frmOptions() {
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
    private System.Windows.Forms.Button btnOK;

    private System.Windows.Forms.Button btnCancel;

    private System.Windows.Forms.CheckBox chkTransparent;

    private System.Windows.Forms.RadioButton optRectangles;

    private System.Windows.Forms.RadioButton optEllipses;

    private System.Windows.Forms.Label Label1;

    private System.Windows.Forms.ComboBox cboSpeed;

    private System.Windows.Forms.GroupBox grpShapes;

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmOptions));

        this.btnOK = new System.Windows.Forms.Button();

        this.btnCancel = new System.Windows.Forms.Button();

        this.chkTransparent = new System.Windows.Forms.CheckBox();

        this.grpShapes = new System.Windows.Forms.GroupBox();

        this.optEllipses = new System.Windows.Forms.RadioButton();

        this.optRectangles = new System.Windows.Forms.RadioButton();

        this.cboSpeed = new System.Windows.Forms.ComboBox();

        this.Label1 = new System.Windows.Forms.Label();

        this.grpShapes.SuspendLayout();

        this.SuspendLayout();

        //

        //btnOK

        //

        this.btnOK.AccessibleDescription = resources.GetString("btnOK.AccessibleDescription");

        this.btnOK.AccessibleName = resources.GetString("btnOK.AccessibleName");

        this.btnOK.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnOK.Anchor");

        this.btnOK.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnOK.BackgroundImage");

        this.btnOK.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnOK.Dock");

        this.btnOK.Enabled = (bool) resources.GetObject("btnOK.Enabled");

        this.btnOK.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnOK.FlatStyle");

        this.btnOK.Font = (System.Drawing.Font) resources.GetObject("btnOK.Font");

        this.btnOK.Image = (System.Drawing.Image) resources.GetObject("btnOK.Image");

        this.btnOK.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnOK.ImageAlign");

        this.btnOK.ImageIndex = (int) resources.GetObject("btnOK.ImageIndex");

        this.btnOK.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnOK.ImeMode");

        this.btnOK.Location = (System.Drawing.Point) resources.GetObject("btnOK.Location");

        this.btnOK.Name = "btnOK";

        this.btnOK.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnOK.RightToLeft");

        this.btnOK.Size = (System.Drawing.Size) resources.GetObject("btnOK.Size");

        this.btnOK.TabIndex = (int) resources.GetObject("btnOK.TabIndex");

        this.btnOK.Text = resources.GetString("btnOK.Text");

        this.btnOK.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnOK.TextAlign");

        this.btnOK.Visible = (bool) resources.GetObject("btnOK.Visible");

		this.btnOK.Click += new EventHandler(btnOK_Click);

        //

        //btnCancel

        //

        this.btnCancel.AccessibleDescription = resources.GetString("btnCancel.AccessibleDescription");

        this.btnCancel.AccessibleName = resources.GetString("btnCancel.AccessibleName");

        this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("btnCancel.Anchor");

        this.btnCancel.BackgroundImage = (System.Drawing.Image) resources.GetObject("btnCancel.BackgroundImage");

        this.btnCancel.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("btnCancel.Dock");

        this.btnCancel.Enabled = (bool) resources.GetObject("btnCancel.Enabled");

        this.btnCancel.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("btnCancel.FlatStyle");

        this.btnCancel.Font = (System.Drawing.Font) resources.GetObject("btnCancel.Font");

        this.btnCancel.Image = (System.Drawing.Image) resources.GetObject("btnCancel.Image");

        this.btnCancel.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCancel.ImageAlign");

        this.btnCancel.ImageIndex = (int) resources.GetObject("btnCancel.ImageIndex");

        this.btnCancel.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("btnCancel.ImeMode");

        this.btnCancel.Location = (System.Drawing.Point) resources.GetObject("btnCancel.Location");

        this.btnCancel.Name = "btnCancel";

        this.btnCancel.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("btnCancel.RightToLeft");

        this.btnCancel.Size = (System.Drawing.Size) resources.GetObject("btnCancel.Size");

        this.btnCancel.TabIndex = (int) resources.GetObject("btnCancel.TabIndex");

        this.btnCancel.Text = resources.GetString("btnCancel.Text");

        this.btnCancel.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("btnCancel.TextAlign");

        this.btnCancel.Visible = (bool) resources.GetObject("btnCancel.Visible");

		this.btnCancel.Click += new EventHandler(btnCancel_Click);

        //

        //chkTransparent

        //

        this.chkTransparent.AccessibleDescription = resources.GetString("chkTransparent.AccessibleDescription");

        this.chkTransparent.AccessibleName = resources.GetString("chkTransparent.AccessibleName");

        this.chkTransparent.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("chkTransparent.Anchor");

        this.chkTransparent.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("chkTransparent.Appearance");

        this.chkTransparent.BackgroundImage = (System.Drawing.Image) resources.GetObject("chkTransparent.BackgroundImage");

        this.chkTransparent.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkTransparent.CheckAlign");

        this.chkTransparent.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("chkTransparent.Dock");

        this.chkTransparent.Enabled = (bool) resources.GetObject("chkTransparent.Enabled");

        this.chkTransparent.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("chkTransparent.FlatStyle");

        this.chkTransparent.Font = (System.Drawing.Font) resources.GetObject("chkTransparent.Font");

        this.chkTransparent.Image = (System.Drawing.Image) resources.GetObject("chkTransparent.Image");

        this.chkTransparent.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkTransparent.ImageAlign");

        this.chkTransparent.ImageIndex = (int) resources.GetObject("chkTransparent.ImageIndex");

        this.chkTransparent.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("chkTransparent.ImeMode");

        this.chkTransparent.Location = (System.Drawing.Point) resources.GetObject("chkTransparent.Location");

        this.chkTransparent.Name = "chkTransparent";

        this.chkTransparent.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("chkTransparent.RightToLeft");

        this.chkTransparent.Size = (System.Drawing.Size) resources.GetObject("chkTransparent.Size");

        this.chkTransparent.TabIndex = (int) resources.GetObject("chkTransparent.TabIndex");

        this.chkTransparent.Text = resources.GetString("chkTransparent.Text");

        this.chkTransparent.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("chkTransparent.TextAlign");

        this.chkTransparent.Visible = (bool) resources.GetObject("chkTransparent.Visible");

        //

        //grpShapes

        //

        this.grpShapes.AccessibleDescription = resources.GetString("grpShapes.AccessibleDescription");

        this.grpShapes.AccessibleName = resources.GetString("grpShapes.AccessibleName");

        this.grpShapes.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("grpShapes.Anchor");

        this.grpShapes.BackgroundImage = (System.Drawing.Image) resources.GetObject("grpShapes.BackgroundImage");

        this.grpShapes.Controls.AddRange(new System.Windows.Forms.Control[] {this.optEllipses, this.optRectangles});

        this.grpShapes.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("grpShapes.Dock");

        this.grpShapes.Enabled = (bool) resources.GetObject("grpShapes.Enabled");

        this.grpShapes.Font = (System.Drawing.Font) resources.GetObject("grpShapes.Font");

        this.grpShapes.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("grpShapes.ImeMode");

        this.grpShapes.Location = (System.Drawing.Point) resources.GetObject("grpShapes.Location");

        this.grpShapes.Name = "grpShapes";

        this.grpShapes.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("grpShapes.RightToLeft");

        this.grpShapes.Size = (System.Drawing.Size) resources.GetObject("grpShapes.Size");

        this.grpShapes.TabIndex = (int) resources.GetObject("grpShapes.TabIndex");

        this.grpShapes.TabStop = false;

        this.grpShapes.Text = resources.GetString("grpShapes.Text");

        this.grpShapes.Visible = (bool) resources.GetObject("grpShapes.Visible");

        //

        //optEllipses

        //

        this.optEllipses.AccessibleDescription = resources.GetString("optEllipses.AccessibleDescription");

        this.optEllipses.AccessibleName = resources.GetString("optEllipses.AccessibleName");

        this.optEllipses.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optEllipses.Anchor");

        this.optEllipses.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optEllipses.Appearance");

        this.optEllipses.BackgroundImage = (System.Drawing.Image) resources.GetObject("optEllipses.BackgroundImage");

        this.optEllipses.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optEllipses.CheckAlign");

        this.optEllipses.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optEllipses.Dock");

        this.optEllipses.Enabled = (bool) resources.GetObject("optEllipses.Enabled");

        this.optEllipses.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optEllipses.FlatStyle");

        this.optEllipses.Font = (System.Drawing.Font) resources.GetObject("optEllipses.Font");

        this.optEllipses.Image = (System.Drawing.Image) resources.GetObject("optEllipses.Image");

        this.optEllipses.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optEllipses.ImageAlign");

        this.optEllipses.ImageIndex = (int) resources.GetObject("optEllipses.ImageIndex");

        this.optEllipses.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optEllipses.ImeMode");

        this.optEllipses.Location = (System.Drawing.Point) resources.GetObject("optEllipses.Location");

        this.optEllipses.Name = "optEllipses";

        this.optEllipses.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optEllipses.RightToLeft");

        this.optEllipses.Size = (System.Drawing.Size) resources.GetObject("optEllipses.Size");

        this.optEllipses.TabIndex = (int) resources.GetObject("optEllipses.TabIndex");

        this.optEllipses.Text = resources.GetString("optEllipses.Text");

        this.optEllipses.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optEllipses.TextAlign");

        this.optEllipses.Visible = (bool) resources.GetObject("optEllipses.Visible");

        //

        //optRectangles

        //

        this.optRectangles.AccessibleDescription = resources.GetString("optRectangles.AccessibleDescription");

        this.optRectangles.AccessibleName = resources.GetString("optRectangles.AccessibleName");

        this.optRectangles.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("optRectangles.Anchor");

        this.optRectangles.Appearance = (System.Windows.Forms.Appearance) resources.GetObject("optRectangles.Appearance");

        this.optRectangles.BackgroundImage = (System.Drawing.Image) resources.GetObject("optRectangles.BackgroundImage");

        this.optRectangles.CheckAlign = (System.Drawing.ContentAlignment) resources.GetObject("optRectangles.CheckAlign");

        this.optRectangles.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("optRectangles.Dock");

        this.optRectangles.Enabled = (bool) resources.GetObject("optRectangles.Enabled");

        this.optRectangles.FlatStyle = (System.Windows.Forms.FlatStyle) resources.GetObject("optRectangles.FlatStyle");

        this.optRectangles.Font = (System.Drawing.Font) resources.GetObject("optRectangles.Font");

        this.optRectangles.Image = (System.Drawing.Image) resources.GetObject("optRectangles.Image");

        this.optRectangles.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("optRectangles.ImageAlign");

        this.optRectangles.ImageIndex = (int) resources.GetObject("optRectangles.ImageIndex");

        this.optRectangles.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("optRectangles.ImeMode");

        this.optRectangles.Location = (System.Drawing.Point) resources.GetObject("optRectangles.Location");

        this.optRectangles.Name = "optRectangles";

        this.optRectangles.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("optRectangles.RightToLeft");

        this.optRectangles.Size = (System.Drawing.Size) resources.GetObject("optRectangles.Size");

        this.optRectangles.TabIndex = (int) resources.GetObject("optRectangles.TabIndex");

        this.optRectangles.Text = resources.GetString("optRectangles.Text");

        this.optRectangles.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("optRectangles.TextAlign");

        this.optRectangles.Visible = (bool) resources.GetObject("optRectangles.Visible");

        //

        //cboSpeed

        //

        this.cboSpeed.AccessibleDescription = resources.GetString("cboSpeed.AccessibleDescription");

        this.cboSpeed.AccessibleName = resources.GetString("cboSpeed.AccessibleName");

        this.cboSpeed.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("cboSpeed.Anchor");

        this.cboSpeed.BackgroundImage = (System.Drawing.Image) resources.GetObject("cboSpeed.BackgroundImage");

        this.cboSpeed.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("cboSpeed.Dock");

        this.cboSpeed.Enabled = (bool) resources.GetObject("cboSpeed.Enabled");

        this.cboSpeed.Font = (System.Drawing.Font) resources.GetObject("cboSpeed.Font");

        this.cboSpeed.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("cboSpeed.ImeMode");

        this.cboSpeed.IntegralHeight = (bool) resources.GetObject("cboSpeed.IntegralHeight");

        this.cboSpeed.ItemHeight = (int) resources.GetObject("cboSpeed.ItemHeight");

        this.cboSpeed.Items.AddRange(new Object[] {resources.GetString("cboSpeed.Items.Items"), resources.GetString("cboSpeed.Items.Items1"), resources.GetString("cboSpeed.Items.Items2")});

        this.cboSpeed.Location = (System.Drawing.Point) resources.GetObject("cboSpeed.Location");

        this.cboSpeed.MaxDropDownItems = (int) resources.GetObject("cboSpeed.MaxDropDownItems");

        this.cboSpeed.MaxLength = (int) resources.GetObject("cboSpeed.MaxLength");

        this.cboSpeed.Name = "cboSpeed";

        this.cboSpeed.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("cboSpeed.RightToLeft");

        this.cboSpeed.Size = (System.Drawing.Size) resources.GetObject("cboSpeed.Size");

        this.cboSpeed.TabIndex = (int) resources.GetObject("cboSpeed.TabIndex");

        this.cboSpeed.Text = resources.GetString("cboSpeed.Text");

        this.cboSpeed.Visible = (bool) resources.GetObject("cboSpeed.Visible");

        //

        //Label1

        //

        this.Label1.AccessibleDescription = resources.GetString("Label1.AccessibleDescription");

        this.Label1.AccessibleName = resources.GetString("Label1.AccessibleName");

        this.Label1.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("Label1.Anchor");

        this.Label1.AutoSize = (bool) resources.GetObject("Label1.AutoSize");

        this.Label1.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("Label1.Dock");

        this.Label1.Enabled = (bool) resources.GetObject("Label1.Enabled");

        this.Label1.Font = (System.Drawing.Font) resources.GetObject("Label1.Font");

        this.Label1.Image = (System.Drawing.Image) resources.GetObject("Label1.Image");

        this.Label1.ImageAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label1.ImageAlign");

        this.Label1.ImageIndex = (int) resources.GetObject("Label1.ImageIndex");

        this.Label1.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("Label1.ImeMode");

        this.Label1.Location = (System.Drawing.Point) resources.GetObject("Label1.Location");

        this.Label1.Name = "Label1";

        this.Label1.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("Label1.RightToLeft");

        this.Label1.Size = (System.Drawing.Size) resources.GetObject("Label1.Size");

        this.Label1.TabIndex = (int) resources.GetObject("Label1.TabIndex");

        this.Label1.Text = resources.GetString("Label1.Text");

        this.Label1.TextAlign = (System.Drawing.ContentAlignment) resources.GetObject("Label1.TextAlign");

        this.Label1.Visible = (bool) resources.GetObject("Label1.Visible");

        //

        //frmOptions

        //

        this.AccessibleDescription = resources.GetString("$this.AccessibleDescription");

        this.AccessibleName = resources.GetString("$this.AccessibleName");

        this.Anchor = (System.Windows.Forms.AnchorStyles) resources.GetObject("$this.Anchor");

        this.AutoScaleBaseSize = (System.Drawing.Size) resources.GetObject("$this.AutoScaleBaseSize");

        this.AutoScroll = (bool) resources.GetObject("$this.AutoScroll");

        this.AutoScrollMargin = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMargin");

        this.AutoScrollMinSize = (System.Drawing.Size) resources.GetObject("$this.AutoScrollMinSize");

        this.BackgroundImage = (System.Drawing.Image) resources.GetObject("$this.BackgroundImage");

        this.ClientSize = (System.Drawing.Size) resources.GetObject("$this.ClientSize");

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label1, this.cboSpeed, this.grpShapes, this.chkTransparent, this.btnCancel, this.btnOK});

        this.Dock = (System.Windows.Forms.DockStyle) resources.GetObject("$this.Dock");

        this.Enabled = (bool) resources.GetObject("$this.Enabled");

        this.Font = (System.Drawing.Font) resources.GetObject("$this.Font");

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

        this.ImeMode = (System.Windows.Forms.ImeMode) resources.GetObject("$this.ImeMode");

        this.Location = (System.Drawing.Point) resources.GetObject("$this.Location");

        this.MaximumSize = (System.Drawing.Size) resources.GetObject("$this.MaximumSize");

        this.MinimumSize = (System.Drawing.Size) resources.GetObject("$this.MinimumSize");

        this.Name = "frmOptions";

        this.RightToLeft = (System.Windows.Forms.RightToLeft) resources.GetObject("$this.RightToLeft");

        this.StartPosition = (System.Windows.Forms.FormStartPosition) resources.GetObject("$this.StartPosition");

        this.Text = resources.GetString("$this.Text");

        this.Visible = (bool) resources.GetObject("$this.Visible");

        this.grpShapes.ResumeLayout(false);

        this.ResumeLayout(false);

		this.Load += new EventHandler(frmOptions_Load);

    }

#endregion

    // This code just closes the form, when the user decides to Cancel.

    private void btnCancel_Click(object sender, System.EventArgs e) 
	{
        this.Close();
    }

    // This code changes the values in the Options object to the new user
    //   selected values, and saves it to disk.
    private void btnOK_Click(object sender, System.EventArgs e)
	{
		Options myOptions = new Options();
		if (this.optEllipses.Checked )
		{
			myOptions.Shape = "Ellipses";
		}
		else 
		{
			myOptions.Shape = "Rectangles";
		}
        myOptions.IsTransparent = this.chkTransparent.Checked;
        myOptions.Speed = this.cboSpeed.Text;
        // Save the options to disk.
        myOptions.SaveOptions();
        // Close this object.
        this.Close();
    }
    // This code loads the current user defined options and sets the UI elements
    //   in this form to their proper values.
    private void frmOptions_Load(object sender, System.EventArgs e) 
	{
        // Load the options file.  Recall that the load method will
        //   always return an options object, even if the file doesn't
        //   currently exist
        Options myOptions = new Options();
        myOptions.LoadOptions();
        this.cboSpeed.Text = myOptions.Speed;
        this.chkTransparent.Checked = myOptions.IsTransparent;
		if (myOptions.Shape == "Ellipses") 
		{
			this.optEllipses.Checked = true;
		}
		else 
		{
			this.optRectangles.Checked = true;
		}
    }
}

