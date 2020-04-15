//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.Diagnostics;
using System.IO;
using System.Data.SqlClient;
using System;
using System.Data;
using System.Windows.Forms;

public class frmMain: System.Windows.Forms.Form {

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

#region " Windows Form Designer generated code "

    public frmMain() {

        //This call is required by the Windows Form Designer.
        InitializeComponent();
        //Add any initialization after the InitializeComponent() call
    }

    //Form overrides dispose to clean up the component list.

    protected override void Dispose(bool disposing) {

		if (disposing) 
		{
			if (components != null) 
			{
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
    private System.Windows.Forms.ListBox lstProcessesAddItem;
    private System.Windows.Forms.TabControl TabControl1;
    private System.Windows.Forms.TabPage TabPage1;
    private System.Windows.Forms.Button btnFill1;
    private System.Windows.Forms.Label lblFileName1;
    private System.Windows.Forms.TabPage TabPage2;
    private System.Windows.Forms.Label lblFileName2;
    private System.Windows.Forms.Button btnFill2;
    private System.Windows.Forms.ListBox lstProcessesDataSource;
    private System.Windows.Forms.TabPage TabPage3;
    private System.Windows.Forms.Label lblFileInfo;
    private System.Windows.Forms.ListBox lstFiles;
    private System.Windows.Forms.TabPage TabPage4;
    private System.Windows.Forms.ListBox lstMultiSelect;
    private System.Windows.Forms.Label Label1;
    private System.Windows.Forms.ComboBox cboSelectionMode;
    private System.Windows.Forms.Button btnFill3;
    private System.Windows.Forms.Button btnFill4;
    private System.Windows.Forms.ListBox lstSelected;
    private System.Windows.Forms.TabPage TabPage5;
    private System.Windows.Forms.Label Label2;
    private System.Windows.Forms.ComboBox cboDropDownStyle;
    private System.Windows.Forms.ComboBox cboDemo;
    private System.Windows.Forms.Label Label3;
    private System.Windows.Forms.NumericUpDown nudDropDownWidth;
    private System.Windows.Forms.Button btnFill5;
    private System.Windows.Forms.Label Label4;
    private System.Windows.Forms.NumericUpDown nudDropDownItems;
    private System.Windows.Forms.Label lblResults;
    private System.Windows.Forms.Label Label5;
    private System.Windows.Forms.ListBox lstSelectedItems;
    //

    private void InitializeComponent() {

        System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

        this.mnuMain = new System.Windows.Forms.MainMenu();

        this.mnuFile = new System.Windows.Forms.MenuItem();

        this.mnuExit = new System.Windows.Forms.MenuItem();

        this.mnuHelp = new System.Windows.Forms.MenuItem();

        this.mnuAbout = new System.Windows.Forms.MenuItem();

        this.lstProcessesAddItem = new System.Windows.Forms.ListBox();

        this.TabControl1 = new System.Windows.Forms.TabControl();

        this.TabPage1 = new System.Windows.Forms.TabPage();

        this.lblFileName1 = new System.Windows.Forms.Label();

        this.btnFill1 = new System.Windows.Forms.Button();

        this.TabPage3 = new System.Windows.Forms.TabPage();

        this.lblFileInfo = new System.Windows.Forms.Label();

        this.btnFill3 = new System.Windows.Forms.Button();

        this.lstFiles = new System.Windows.Forms.ListBox();

        this.TabPage4 = new System.Windows.Forms.TabPage();

        this.lstSelectedItems = new System.Windows.Forms.ListBox();

        this.lstSelected = new System.Windows.Forms.ListBox();

        this.btnFill4 = new System.Windows.Forms.Button();

        this.cboSelectionMode = new System.Windows.Forms.ComboBox();

        this.Label1 = new System.Windows.Forms.Label();

        this.lstMultiSelect = new System.Windows.Forms.ListBox();

        this.TabPage2 = new System.Windows.Forms.TabPage();

        this.lblFileName2 = new System.Windows.Forms.Label();

        this.btnFill2 = new System.Windows.Forms.Button();

        this.lstProcessesDataSource = new System.Windows.Forms.ListBox();

        this.TabPage5 = new System.Windows.Forms.TabPage();

        this.Label5 = new System.Windows.Forms.Label();

        this.lblResults = new System.Windows.Forms.Label();

        this.nudDropDownItems = new System.Windows.Forms.NumericUpDown();

        this.Label4 = new System.Windows.Forms.Label();

        this.btnFill5 = new System.Windows.Forms.Button();

        this.nudDropDownWidth = new System.Windows.Forms.NumericUpDown();

        this.Label3 = new System.Windows.Forms.Label();

        this.Label2 = new System.Windows.Forms.Label();

        this.cboDropDownStyle = new System.Windows.Forms.ComboBox();

        this.cboDemo = new System.Windows.Forms.ComboBox();

        this.TabControl1.SuspendLayout();

        this.TabPage1.SuspendLayout();

        this.TabPage3.SuspendLayout();

        this.TabPage4.SuspendLayout();

        this.TabPage2.SuspendLayout();

        this.TabPage5.SuspendLayout();

        ((System.ComponentModel.ISupportInitialize)(this.nudDropDownItems)).BeginInit();
        ((System.ComponentModel.ISupportInitialize)(this.nudDropDownWidth)).BeginInit();
        this.SuspendLayout();

        //

        //mnuMain

        //

        this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile, this.mnuHelp});

        //

        //mnuFile

        //

        this.mnuFile.Index = 0;

        this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuExit});

        this.mnuFile.Text = "&File";

        //

        //mnuExit

        //

        this.mnuExit.Index = 0;

        this.mnuExit.Text = "E&xit";

        //

        //mnuHelp

        //

        this.mnuHelp.Index = 1;

        this.mnuHelp.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuAbout});

        this.mnuHelp.Text = "&Help";

        //

        //mnuAbout

        //

        this.mnuAbout.Index = 0;

        this.mnuAbout.Text = "Text Comes from AssemblyInfo";

        //

        //lstProcessesAddItem

        //

        this.lstProcessesAddItem.Location = new System.Drawing.Point(8, 8);

        this.lstProcessesAddItem.Name = "lstProcessesAddItem";

        this.lstProcessesAddItem.Size = new System.Drawing.Size(232, 173);

        this.lstProcessesAddItem.TabIndex = 0;

        //

        //TabControl1

        //

        this.TabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {this.TabPage1, this.TabPage3, this.TabPage4, this.TabPage2, this.TabPage5});

        this.TabControl1.ItemSize = new System.Drawing.Size(59, 18);

        this.TabControl1.Location = new System.Drawing.Point(8, 8);

        this.TabControl1.Name = "TabControl1";

        this.TabControl1.SelectedIndex = 0;

        this.TabControl1.Size = new System.Drawing.Size(528, 264);

        this.TabControl1.TabIndex = 1;

        //

        //TabPage1

        //

        this.TabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblFileName1, this.btnFill1, this.lstProcessesAddItem});

        this.TabPage1.Location = new System.Drawing.Point(4, 22);

        this.TabPage1.Name = "TabPage1";

        this.TabPage1.Size = new System.Drawing.Size(520, 238);

        this.TabPage1.TabIndex = 0;

        this.TabPage1.Text = "Add Items";

        //

        //lblFileName1

        //

        this.lblFileName1.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblFileName1.Location = new System.Drawing.Point(8, 184);

        this.lblFileName1.Name = "lblFileName1";

        this.lblFileName1.Size = new System.Drawing.Size(504, 48);

        this.lblFileName1.TabIndex = 2;

        //

        //btnFill1

        //

        this.btnFill1.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnFill1.Location = new System.Drawing.Point(250, 8);

        this.btnFill1.Name = "btnFill1";

        this.btnFill1.TabIndex = 1;

        this.btnFill1.Text = "Fill";

        //

        //TabPage3

        //

        this.TabPage3.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblFileInfo, this.btnFill3, this.lstFiles});

        this.TabPage3.Location = new System.Drawing.Point(4, 22);

        this.TabPage3.Name = "TabPage3";

        this.TabPage3.Size = new System.Drawing.Size(520, 238);

        this.TabPage3.TabIndex = 2;

        this.TabPage3.Text = "Bind to DataTable";

        //

        //lblFileInfo

        //

        this.lblFileInfo.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblFileInfo.Location = new System.Drawing.Point(8, 208);

        this.lblFileInfo.Name = "lblFileInfo";

        this.lblFileInfo.Size = new System.Drawing.Size(504, 23);

        this.lblFileInfo.TabIndex = 8;

        //

        //btnFill3

        //

        this.btnFill3.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnFill3.Location = new System.Drawing.Point(250, 8);

        this.btnFill3.Name = "btnFill3";

        this.btnFill3.TabIndex = 7;

        this.btnFill3.Text = "Fill";

        //

        //lstFiles

        //

        this.lstFiles.Location = new System.Drawing.Point(8, 8);

        this.lstFiles.Name = "lstFiles";

        this.lstFiles.Size = new System.Drawing.Size(232, 186);

        this.lstFiles.TabIndex = 6;

        //

        //TabPage4

        //

        this.TabPage4.Controls.AddRange(new System.Windows.Forms.Control[] {this.lstSelectedItems, this.lstSelected, this.btnFill4, this.cboSelectionMode, this.Label1, this.lstMultiSelect});

        this.TabPage4.Location = new System.Drawing.Point(4, 22);

        this.TabPage4.Name = "TabPage4";

        this.TabPage4.Size = new System.Drawing.Size(520, 238);

        this.TabPage4.TabIndex = 3;

        this.TabPage4.Text = "Selection Mode";

        //

        //lstSelectedItems

        //

        this.lstSelectedItems.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        this.lstSelectedItems.Location = new System.Drawing.Point(320, 64);

        this.lstSelectedItems.Name = "lstSelectedItems";

        this.lstSelectedItems.SelectionMode = System.Windows.Forms.SelectionMode.None;

        this.lstSelectedItems.Size = new System.Drawing.Size(192, 106);

        this.lstSelectedItems.TabIndex = 10;

        //

        //lstSelected

        //

        this.lstSelected.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;

        this.lstSelected.Location = new System.Drawing.Point(250, 64);

        this.lstSelected.Name = "lstSelected";

        this.lstSelected.SelectionMode = System.Windows.Forms.SelectionMode.None;

        this.lstSelected.Size = new System.Drawing.Size(64, 106);

        this.lstSelected.TabIndex = 9;

        //

        //btnFill4

        //

        this.btnFill4.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnFill4.Location = new System.Drawing.Point(250, 8);

        this.btnFill4.Name = "btnFill4";

        this.btnFill4.TabIndex = 8;

        this.btnFill4.Text = "Fill";

        //

        //cboSelectionMode

        //

        this.cboSelectionMode.ItemHeight = 13;

        this.cboSelectionMode.Items.AddRange(new Object[] {"One", "MultiSimple", "MultiExtended"});

        this.cboSelectionMode.Location = new System.Drawing.Point(8, 176);

        this.cboSelectionMode.Name = "cboSelectionMode";

        this.cboSelectionMode.Size = new System.Drawing.Size(232, 21);

        this.cboSelectionMode.TabIndex = 4;

        //

        //Label1

        //

        this.Label1.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label1.Location = new System.Drawing.Point(250, 40);

        this.Label1.Name = "Label1";

        this.Label1.TabIndex = 3;

        this.Label1.Text = "You selected:";

        //

        //lstMultiSelect

        //

        this.lstMultiSelect.Location = new System.Drawing.Point(8, 8);

        this.lstMultiSelect.Name = "lstMultiSelect";

        this.lstMultiSelect.SelectionMode = System.Windows.Forms.SelectionMode.MultiSimple;

        this.lstMultiSelect.Size = new System.Drawing.Size(232, 160);

        this.lstMultiSelect.TabIndex = 1;

        //

        //TabPage2

        //

        this.TabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblFileName2, this.btnFill2, this.lstProcessesDataSource});

        this.TabPage2.Location = new System.Drawing.Point(4, 22);

        this.TabPage2.Name = "TabPage2";

        this.TabPage2.Size = new System.Drawing.Size(520, 238);

        this.TabPage2.TabIndex = 1;

        this.TabPage2.Text = "Bind to Array";

        //

        //lblFileName2

        //

        this.lblFileName2.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblFileName2.Location = new System.Drawing.Point(8, 184);

        this.lblFileName2.Name = "lblFileName2";

        this.lblFileName2.Size = new System.Drawing.Size(504, 48);

        this.lblFileName2.TabIndex = 5;

        //

        //btnFill2

        //

        this.btnFill2.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnFill2.Location = new System.Drawing.Point(250, 8);

        this.btnFill2.Name = "btnFill2";

        this.btnFill2.TabIndex = 4;

        this.btnFill2.Text = "Fill";

        //

        //lstProcessesDataSource

        //

        this.lstProcessesDataSource.Location = new System.Drawing.Point(8, 8);

        this.lstProcessesDataSource.Name = "lstProcessesDataSource";

        this.lstProcessesDataSource.Size = new System.Drawing.Size(232, 173);

        this.lstProcessesDataSource.TabIndex = 3;

        //

        //TabPage5

        //

        this.TabPage5.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label5, this.lblResults, this.nudDropDownItems, this.Label4, this.btnFill5, this.nudDropDownWidth, this.Label3, this.Label2, this.cboDropDownStyle, this.cboDemo});

        this.TabPage5.Location = new System.Drawing.Point(4, 22);

        this.TabPage5.Name = "TabPage5";

        this.TabPage5.Size = new System.Drawing.Size(520, 238);

        this.TabPage5.TabIndex = 4;

        this.TabPage5.Text = "ComboBox";

        //

        //Label5

        //

        this.Label5.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label5.Location = new System.Drawing.Point(256, 136);

        this.Label5.Name = "Label5";

        this.Label5.Size = new System.Drawing.Size(120, 23);

        this.Label5.TabIndex = 8;

        this.Label5.Text = "Selected Value";

        this.Label5.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        //

        //lblResults

        //

        this.lblResults.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

        this.lblResults.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.lblResults.Location = new System.Drawing.Point(384, 136);

        this.lblResults.Name = "lblResults";

        this.lblResults.Size = new System.Drawing.Size(48, 23);

        this.lblResults.TabIndex = 9;

        //

        //nudDropDownItems

        //

        this.nudDropDownItems.Location = new System.Drawing.Point(384, 104);

        this.nudDropDownItems.Maximum = new Decimal(new int[] {20, 0, 0, 0});

        this.nudDropDownItems.Minimum = new Decimal(new int[] {2, 0, 0, 0});

        this.nudDropDownItems.Name = "nudDropDownItems";

        this.nudDropDownItems.Size = new System.Drawing.Size(64, 20);

        this.nudDropDownItems.TabIndex = 7;

        this.nudDropDownItems.Value = new Decimal(new int[] {20, 0, 0, 0});

        //

        //Label4

        //

        this.Label4.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label4.Location = new System.Drawing.Point(256, 104);

        this.Label4.Name = "Label4";

        this.Label4.Size = new System.Drawing.Size(120, 23);

        this.Label4.TabIndex = 6;

        this.Label4.Text = "MaxDropDownItems";

        this.Label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        //

        //btnFill5

        //

        this.btnFill5.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.btnFill5.Location = new System.Drawing.Point(250, 8);

        this.btnFill5.Name = "btnFill5";

        this.btnFill5.TabIndex = 1;

        this.btnFill5.Text = "Fill";

        //

        //nudDropDownWidth

        //

        this.nudDropDownWidth.Location = new System.Drawing.Point(384, 72);

        this.nudDropDownWidth.Maximum = new Decimal(new int[] {400, 0, 0, 0});

        this.nudDropDownWidth.Minimum = new Decimal(new int[] {50, 0, 0, 0});

        this.nudDropDownWidth.Name = "nudDropDownWidth";

        this.nudDropDownWidth.Size = new System.Drawing.Size(64, 20);

        this.nudDropDownWidth.TabIndex = 5;

        this.nudDropDownWidth.Value = new Decimal(new int[] {100, 0, 0, 0});

        //

        //Label3

        //

        this.Label3.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label3.Location = new System.Drawing.Point(256, 72);

        this.Label3.Name = "Label3";

        this.Label3.Size = new System.Drawing.Size(120, 23);

        this.Label3.TabIndex = 4;

        this.Label3.Text = "DropDownWidth";

        this.Label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        //

        //Label2

        //

        this.Label2.ImeMode = System.Windows.Forms.ImeMode.NoControl;

        this.Label2.Location = new System.Drawing.Point(256, 40);

        this.Label2.Name = "Label2";

        this.Label2.Size = new System.Drawing.Size(120, 23);

        this.Label2.TabIndex = 2;

        this.Label2.Text = "DropDownStyle";

        this.Label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;

        //

        //cboDropDownStyle

        //

        this.cboDropDownStyle.ItemHeight = 13;

        this.cboDropDownStyle.Location = new System.Drawing.Point(384, 40);

        this.cboDropDownStyle.Name = "cboDropDownStyle";

        this.cboDropDownStyle.Size = new System.Drawing.Size(96, 21);

        this.cboDropDownStyle.TabIndex = 3;

        //

        //cboDemo

        //

        this.cboDemo.DropDownWidth = 200;

        this.cboDemo.ItemHeight = 13;

        this.cboDemo.Location = new System.Drawing.Point(8, 8);

        this.cboDemo.MaxDropDownItems = 10;

        this.cboDemo.Name = "cboDemo";

        this.cboDemo.Size = new System.Drawing.Size(200, 21);

        this.cboDemo.TabIndex = 0;

        //

        //frmMain

        //

        this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

        this.ClientSize = new System.Drawing.Size(546, 275);

        this.Controls.AddRange(new System.Windows.Forms.Control[] {this.TabControl1});

        this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

        this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");
        this.MaximizeBox = false;
        this.Menu = this.mnuMain;
        this.Name = "frmMain";
        this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
        this.Text = "Title Comes from Assembly Info";

        this.TabControl1.ResumeLayout(false);

        this.TabPage1.ResumeLayout(false);

        this.TabPage3.ResumeLayout(false);

        this.TabPage4.ResumeLayout(false);

        this.TabPage2.ResumeLayout(false);

        this.TabPage5.ResumeLayout(false);

        ((System.ComponentModel.ISupportInitialize)(this.nudDropDownItems)).EndInit();

        ((System.ComponentModel.ISupportInitialize)(this.nudDropDownWidth)).EndInit();

        this.ResumeLayout(false);

		this.mnuAbout.Click +=new EventHandler(mnuAbout_Click);
		this.mnuExit.Click +=new EventHandler(mnuExit_Click);
		this.btnFill1.Click +=new EventHandler(btnFill1_Click);
		this.lstProcessesAddItem.SelectedIndexChanged +=new EventHandler(lstProcessesAddItem_SelectedIndexChanged);
		this.btnFill2.Click +=new EventHandler(btnFill2_Click);
		this.btnFill3.Click +=new EventHandler(btnFill3_Click);
		this.btnFill4.Click +=new EventHandler(btnFill4_Click);
		this.btnFill5.Click +=new EventHandler(btnFill5_Click);
		this.lstFiles.SelectedIndexChanged +=new EventHandler(lstFiles_SelectedIndexChanged);
		this.cboSelectionMode.SelectedIndexChanged +=new EventHandler(cboSelectionMode_SelectedIndexChanged);
		this.lstMultiSelect.SelectedIndexChanged +=new EventHandler(lstMultiSelect_SelectedIndexChanged);
		this.cboDemo.SelectedIndexChanged +=new EventHandler(cboDemo_SelectedIndexChanged);
		this.cboDropDownStyle.SelectedIndexChanged +=new EventHandler(cboDropDownStyle_SelectedIndexChanged);
		this.nudDropDownItems.ValueChanged +=new EventHandler(nudDropDownItems_ValueChanged);
		this.nudDropDownWidth.ValueChanged +=new EventHandler(nudDropDownWidth_ValueChanged);
		this.TabControl1.SelectedIndexChanged +=new EventHandler(TabControl1_SelectedIndexChanged);
    }

#endregion

#region " Standard Menu Code "

    // This code simply shows the About form.

    private void mnuAbout_Click(object sender, System.EventArgs e) {

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

#region " Form Load "

    private void frmMain_Load(object sender, System.EventArgs e) {

        // So that we only need to set the title of the application once,
        // we use the AssemblyInfo class (defined in the AssemblyInfo.cs file)
        // to read the AssemblyTitle attribute.
        AssemblyInfo ainfo = new AssemblyInfo();
        this.Text = ainfo.Title;
        this.mnuAbout.Text = string.Format("&About {0} ...", ainfo.Title);
        LoadValues();
    }
    private void LoadValues()
	{

        cboDropDownStyle.DataSource = System.Enum.GetNames(typeof(ComboBoxStyle));
        // Handle properties of cboDemo.
        nudDropDownWidth.Value = cboDemo.DropDownWidth;
        nudDropDownWidth.Minimum = cboDemo.Width;
        nudDropDownWidth.Maximum = cboDemo.Width * 2;
        nudDropDownItems.Value = cboDemo.MaxDropDownItems;
    }

#endregion

#region " Code for Add Items tab ";

    private void btnFill1_Click(object sender, System.EventArgs e) 
	{

        AddItems();

    }

    private void AddItems()
	{

        // You can add items individually to a list or combo box.
        // Because you can add any type of object, it's up to you to determine
        // which property of the object is to be displayed. set {the 
        // DisplayMember property to indicate the name of the property to display.
        // In this case, set the DisplayMember property to display the ProcessName
        // property.
        // ValueMember property only works if you specify the DataSource
        // property of the control.

        try 
		{
            // Remove existing items from the control.
            lstProcessesAddItem.Items.Clear();
            // Fill the control. Indicate which member of 
            // the items added to the list box should be
            // displayed.
            lstProcessesAddItem.DisplayMember = "ProcessName";

            foreach(Process prc in Process.GetProcesses() )
				{
                lstProcessesAddItem.Items.Add(prc);
            }

            lstProcessesAddItem.Sorted = true;
			
       } 
		catch(Exception exp)
		{

            MessageBox.Show(exp.Message, this.Text);

        }

    }

    private void lstProcessesAddItem_SelectedIndexChanged(object sender, System.EventArgs e) 
	{
        // Because you haven't set the DataSource property of the control, you can't
        // retrieve the SelectedValue property. Instead, use the SelectedItem property,'
        // and display the property you want.

        try {
            lblFileName1.Text = ((Process)lstProcessesAddItem.SelectedItem).MainModule.FileName;
       } 
		catch
		{
            // In this case, do nothing if an exception occurs.

            lblFileName1.Text = string.Empty;

        }

    }

#endregion

#region " Code for Bind To Array tab ";

    private void btnFill2_Click(object sender, System.EventArgs e) 
			
	{
        BindToArray();

    }

    private void BindToArray()
		{
        // Binding to an array is simpler -- just set the 
        // DataSource property of the control. In this case, you 
        // can also set the ValueMember property:

        try {
                lstProcessesDataSource.ValueMember = "MainModule";
                lstProcessesDataSource.DisplayMember = "ProcessName";
                lstProcessesDataSource.DataSource = Process.GetProcesses();
       } catch(Exception exp)
			{
            MessageBox.Show(exp.Message, this.Text);
        }

    }

    private void lstProcessesDataSource_SelectedIndexChanged(object sender, System.EventArgs e) 
		//lstProcessesDataSource.SelectedIndexChanged;
		{
        // Because the ValueMember property was set to MainModule
        // you can retrieve the SelectedValue property of the 
        // control. 

        try 
			{
            lblFileName2.Text = ((ProcessModule) lstProcessesDataSource.SelectedValue).FileName;
			} 
		catch
			{
            // In this case, do nothing if an exception occurs.
            lblFileName2.Text = string.Empty;
        }

    }

#endregion

#region " Code for Bind to DataTable tab ";

    private void btnFill3_Click(object sender, System.EventArgs e) 
		{
        // Bind a ListBox to a DataTable containing information about files. 
        // This could just easily come from a real data source (such SQL Server).
        //  In addition, you can bind a ListBox or ComboBox to many other 
        // data sources -- see the IList interface in Help.

        try {
            DataTable dt = FillTable(@"C:\");
            if (dt != null) {
                    lstFiles.DisplayMember = "FileName";
                    lstFiles.ValueMember = "Length";
                    lstFiles.DataSource = dt;
            }

       } catch(Exception exp)
		{
            MessageBox.Show(exp.Message, this.Text);
        }

    }

    private DataTable FillTable(string Path)
		{

        // Build a DataTable filled with information
        // about files on your hard drive. 

        DataTable dt = new DataTable();
        DataRow dr;

        try {
            dt.Columns.Add("FileName", typeof(System.String));
            dt.Columns.Add("Length", typeof(System.Int64));

            // The DirectoryInfo class comes from the System.IO namespace.
            DirectoryInfo di = new DirectoryInfo(Path);

            // Load the DataTable with all files 
            // that aren't marked with System and/or Hidden attributes,
            // just to show that you can.

            foreach(FileInfo fi in di.GetFiles())
				{

                if ((fi.Attributes & (FileAttributes.Hidden | FileAttributes.System)) == 0)
					{
                    dr = dt.NewRow();
                    dr["FileName"] = fi.Name;
                    dr["Length"] = fi.Length;
                    dt.Rows.Add(dr);
                }
            }
       } 
		catch(Exception exp)
			{

            MessageBox.Show(exp.Message, this.Text);

        }

        return dt;

    }

    private void lstFiles_SelectedIndexChanged(object sender, System.EventArgs e) 
	{
        // Display information about the selected file.

        // The ValueMember property is set to the Length field in the 

        // DataTable filling the control.

        lblFileInfo.Text = "Length: " + lstFiles.SelectedValue.ToString();

    }

#endregion

#region " Code for Selection Mode tab ";

    private void btnFill4_Click(object sender, System.EventArgs e) 
	{
        FillSelectionMode();

    }

    private void FillSelectionMode()
	{
        try {
            DirectoryInfo di = new DirectoryInfo(@"C:\");
                lstMultiSelect.DisplayMember = "Name";
                lstMultiSelect.ValueMember = "Length";
                lstMultiSelect.DataSource = di.GetFiles();
                // Initialize the combo box containing the 
                // different selection modes:
                cboSelectionMode.Text = lstMultiSelect.SelectionMode.ToString();

            

       } 
		catch( Exception exp)
		{
            MessageBox.Show(exp.Message, this.Text);

        }

    }

    private void cboSelectionMode_SelectedIndexChanged(object sender, System.EventArgs e) 
	{
        // Allow the user to select from one of the selection modes:

        // One, MultipleSimple, MultipleExtended

        try {

            lstMultiSelect.ClearSelected();
            lstMultiSelect.SelectionMode = (SelectionMode)(System.Enum.Parse(typeof(SelectionMode), cboSelectionMode.Text));
       } catch( Exception exp)
		{
            MessageBox.Show(exp.Message, this.Text);
        }

    }

    private void lstMultiSelect_SelectedIndexChanged(object sender, System.EventArgs e) 
{
        // Display a list of selected indices.
        // The SelectedIndices property returns a SelectedIndexCollection
        // object. Use its CopyTo method to copy the items to 
        // an array, so you can bind the list to a ListBox control.
        try {
            int[] aIndices = new int[lstMultiSelect.SelectedIndices.Count];
            lstMultiSelect.SelectedIndices.CopyTo(aIndices, 0);
            lstSelected.DataSource = aIndices;
            // Demonstrate how to "walk" the selected items list.
                lstSelectedItems.Items.Clear();
                // Begin/EndUpdate turn off/on display of the control
                // you're adding items. Just makes the update "cleaner".
                lstSelectedItems.BeginUpdate();
                foreach(FileInfo fi in lstMultiSelect.SelectedItems)
{
                    lstSelectedItems.Items.Add(fi.Name);
                }
                lstSelectedItems.EndUpdate();
            
       } catch
{

            lstSelected.DataSource = null;

        }

    }

#endregion

#region " Code for ComboBox tab";

    protected const string SQL_CONNECTION_STRING =
        "Server=localhost;" + 
        "DataBase=Northwind;" + 
        "Integrated Security=SSPI";

    protected const string MSDE_CONNECTION_STRING  =
        @"Server=(local)\NetSDK;DataBase=Northwind;Integrated Security=SSPI";

    protected DataSet dsProducts = new DataSet();
    protected DataView dvProducts;
    protected const string CAPTION_TITLE = "Bind Data to a ComboBox";
    protected const string DEFAULT_SORT = "ProductName ASC";
    protected const MessageBoxButtons CAPTION_BUTTON = MessageBoxButtons.OK;
	protected const MessageBoxIcon CAPTION_ICON = MessageBoxIcon.Information;
    protected const string PRODUCT_TABLE_NAME = "Products";

	

    private void btnFill5_Click(object sender, System.EventArgs e) 
		{
        BindToDataSet();
    }

    private void BindToDataSet()
		{

        try {

            LoadData();
            cboDemo.DataSource = dvProducts;
            cboDemo.DisplayMember = "ProductName";
            cboDemo.ValueMember = "ProductID";
            lblResults.Text = "";
       } catch(Exception exp)
			{
            MessageBox.Show(exp.Message, this.Text);
        }

    }

    private void cboDemo_SelectedIndexChanged(object sender, System.EventArgs e) 
		{
        lblResults.Text = cboDemo.SelectedValue.ToString();
    }

    private void cboDropDownStyle_SelectedIndexChanged(object sender, System.EventArgs e) 
		{
        // Retrieve the enumerated value from the combo box, 
        // parsing the text in the combo box.

        cboDemo.DropDownStyle = (ComboBoxStyle)(System.Enum.Parse(typeof(ComboBoxStyle), cboDropDownStyle.Text));
    }

    private void nudDropDownItems_ValueChanged(object sender, System.EventArgs e) 
		{

        cboDemo.MaxDropDownItems = (int)(nudDropDownItems.Value);

    }

    private void nudDropDownWidth_ValueChanged(object sender, System.EventArgs e) 
		{

        cboDemo.DropDownWidth = (int)(nudDropDownWidth.Value);

    }

    private void LoadData()
	{

        string strConnection = SQL_CONNECTION_STRING;

        // Display a status message saying that we're attempting to connect to SQL Server.
        // This only needs to be done the very first time a connection is
        // attempted.  After we've determined that MSDE or SQL Server is
        // installed, this message no longer needs to be displayed.

        frmStatus frmStatusMessage = new frmStatus();
        frmStatusMessage.Show("Connecting to SQL Server");

        // Attempt to connect first to the local SQL server instance, 
        // if that is not successful try a local
        // MSDE installation (with the Northwind DB).  

        bool IsConnecting = true;

        while (IsConnecting)
			{

            try {

                // The SqlConnection class allows you to communicate with SQL Server.
                // The constructor accepts a connection string an argument.  This
                // connection string uses Integrated Security, which means that you 
                // must have a login in to SQL Server, or be part of the Administrators
                // group on your local machine for this to work. No password or user id is 
                // included in this type of string.

                SqlConnection northwindConnection = new SqlConnection(strConnection);

                // The SqlDataAdapter is used to populate a Dataset 

                SqlDataAdapter ProductAdapter = new SqlDataAdapter(
                    "SELECT * "
                    + "FROM products",
                    northwindConnection);

                // Populate the Dataset with the information from the products
                // table.  Since a Dataset can hold multiple result sets, it's
                // a good idea to "name" the result set when you populate the
                // DataSet.  In this case, the result set is named "Products".

                ProductAdapter.Fill(dsProducts, PRODUCT_TABLE_NAME);

                //create the dataview; use a constructor to specify
                // the sort, filter criteria for performance purposes

                 dvProducts = new DataView(dsProducts.Tables["products"], "", DEFAULT_SORT, DataViewRowState.OriginalRows);

                // Data has been retrieved successfully  
                // Signal to break out of the loop by setting isConnecting to false.

                IsConnecting = false;

                //Handle the situation where a connection attempt has failed

           } catch
				{

                if (strConnection == SQL_CONNECTION_STRING) {

                    // Couldn't connect to SQL Server.  Now try MSDE.

                    strConnection = MSDE_CONNECTION_STRING;
                    frmStatusMessage.Show("Connecting to MSDE");
					}
                else {

                    // Unable to connect to SQL Server or MSDE

                    frmStatusMessage.Close();
                    MessageBox.Show("To run this sample, you must have SQL " + 
                    "or MSDE with the Northwind database installed.  For " + 
                    "instructions on installing MSDE, view  Readthis.", 
                     CAPTION_TITLE, CAPTION_BUTTON, CAPTION_ICON);
                    //quit the program; could not connect to either SQL Server 
                    Application.Exit();

                }

            }

        }

        frmStatusMessage.Close();

    }

#endregion

#region "Code for the tab control ";

    private void TabControl1_SelectedIndexChanged(object sender, System.EventArgs e) 
		{
        // Make sure the selected items list is cleared when 
        // you leave the tab -- otherwise, because the SelectionMode
        // is set to null, things get ugly when you renavigate
        // back to the same page.

        lstSelected.DataSource = null;

    }

#endregion

}

