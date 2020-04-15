using System;
using System.Windows.Forms;
using System.Diagnostics;
using System.Collections;

public class frmModules : System.Windows.Forms.Form 
{

#region " Windows Form Designer generated code "

	public frmModules() 
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

	private System.Windows.Forms.StatusBar sbInfo;

	private System.Windows.Forms.ListView lvModules;

	private System.Windows.Forms.ColumnHeader chModName;

	private System.Windows.Forms.MainMenu mnuMain;

	private System.Windows.Forms.MenuItem mnuFile;

	private System.Windows.Forms.MenuItem mnuClose;

	private System.Windows.Forms.ListView lvModDetail;

	private System.Windows.Forms.ColumnHeader chItem;

	private System.Windows.Forms.ColumnHeader chValue;

	private System.Windows.Forms.Splitter splVert;

	private void InitializeComponent() {

		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmModules));

		this.sbInfo = new System.Windows.Forms.StatusBar();

		this.lvModules = new System.Windows.Forms.ListView();

		this.chModName = new System.Windows.Forms.ColumnHeader();

		this.mnuMain = new System.Windows.Forms.MainMenu();

		this.mnuFile = new System.Windows.Forms.MenuItem();

		this.mnuClose = new System.Windows.Forms.MenuItem();

		this.lvModDetail = new System.Windows.Forms.ListView();

		this.chItem = new System.Windows.Forms.ColumnHeader();

		this.chValue = new System.Windows.Forms.ColumnHeader();

		this.splVert = new System.Windows.Forms.Splitter();

		this.SuspendLayout();

		//

		//sbInfo

		//

		this.sbInfo.Location = new System.Drawing.Point(0, 195);

		this.sbInfo.Name = "sbInfo";

		this.sbInfo.Size = new System.Drawing.Size(927, 22);

		this.sbInfo.TabIndex = 0;

		this.sbInfo.Text = "Ready";

		//

		//lvModules

		//

		this.lvModules.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.chModName});

		this.lvModules.Dock = System.Windows.Forms.DockStyle.Left;

		this.lvModules.FullRowSelect = true;

		this.lvModules.MultiSelect = false;

		this.lvModules.Name = "lvModules";

		this.lvModules.Size = new System.Drawing.Size(184, 195);

		this.lvModules.Sorting = System.Windows.Forms.SortOrder.Ascending;

		this.lvModules.TabIndex = 1;

		this.lvModules.View = System.Windows.Forms.View.Details;
		this.lvModules.SelectedIndexChanged += new EventHandler(lvModules_SelectedIndexChanged);

		//

		//chModName

		//

		this.chModName.Text = "Module Name";

		this.chModName.Width = 150;

		//

		//mnuMain

		//

		this.mnuMain.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuFile});

		//

		//mnuFile

		//

		this.mnuFile.Index = 0;

		this.mnuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {this.mnuClose});

		this.mnuFile.Text = "&File";

		//

		//mnuClose

		//

		this.mnuClose.Index = 0;

		this.mnuClose.Text = "&Close";
		this.mnuClose.Click += new EventHandler(mnuClose_Click);

		//

		//lvModDetail

		//

		this.lvModDetail.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.chItem, this.chValue});

		this.lvModDetail.Dock = System.Windows.Forms.DockStyle.Fill;

		this.lvModDetail.FullRowSelect = true;

		this.lvModDetail.Location = new System.Drawing.Point(184, 0);

		this.lvModDetail.MultiSelect = false;

		this.lvModDetail.Name = "lvModDetail";

		this.lvModDetail.Size = new System.Drawing.Size(743, 195);

		this.lvModDetail.TabIndex = 2;

		this.lvModDetail.View = System.Windows.Forms.View.Details;

		//

		//chItem

		//

		this.chItem.Text = "Item";

		this.chItem.Width = 150;

		//

		//chValue

		//

		this.chValue.Text = "Value";

		this.chValue.Width = 570;

		//

		//splVert

		//

		this.splVert.Location = new System.Drawing.Point(184, 0);

		this.splVert.Name = "splVert";

		this.splVert.Size = new System.Drawing.Size(3, 195);

		this.splVert.TabIndex = 3;

		this.splVert.TabStop = false;

		//

		//frmModules

		//

		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

		this.ClientSize = new System.Drawing.Size(927, 217);

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.splVert, this.lvModDetail, this.lvModules, this.sbInfo});

		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

		this.Menu = this.mnuMain;

		this.Name = "frmModules";

		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;

		this.Text = "Module Detail";

		this.ResumeLayout(false);

	}

#endregion

	private Process m_ParentProcess;

	private ListView.ListViewItemCollection mits;

	private ArrayList mcolModules = new ArrayList();

	public Process ParentProcess
	{
		get {
			return ParentProcess;
		}
		set
		{
			m_ParentProcess = value;

			if (m_ParentProcess == null) 
			{
				mcolModules = null;
			}

		}

	}

	private void EnumModules()
	{
		try 
		{
			this.lvModules.Items.Clear();
			
			if (!(mcolModules == null)) 
			{
				mcolModules = new ArrayList();
			}
			//ProcessModule m;
			foreach(ProcessModule m in m_ParentProcess.Modules)
			{
				this.lvModules.Items.Add(m.ModuleName);
				try 
				{
					mcolModules.Add(m.ModuleName);
				}
				catch (Exception exp) 
				{
					MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
				}
			}
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	public void RefreshModules()
	{
		this.sbInfo.Text = "Process = " + m_ParentProcess.ProcessName;
		this.lvModDetail.Items.Clear();
		EnumModules();
	}

	private void mnuClose_Click(object sender, System.EventArgs e)
	{
		this.Hide();
	}

	private void EnumModule(ProcessModule m)
	{
		this.lvModDetail.Items.Clear();
		mits = this.lvModDetail.Items;
		try 
		{
			AddNameValuePair("Base Address", m.BaseAddress.ToInt32().ToString("x").ToLower());
			AddNameValuePair("Entry Point Address", m.EntryPointAddress.ToInt32().ToString("x").ToLower());
			AddNameValuePair("File Name", m.FileName);
			AddNameValuePair("File Version", m.FileVersionInfo.FileVersion.ToString());
			AddNameValuePair("File Description", m.FileVersionInfo.FileDescription);
			AddNameValuePair("Memory Size", m.ModuleMemorySize.ToString("N0"));
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void AddNameValuePair(string Item ,string voidItem )
	{
			mits.Add(Item).SubItems.Add(voidItem);
	}

	private void lvModules_SelectedIndexChanged(object sender, System.EventArgs e) 
	{
		try 
		{
			ListView lv = ((ListView) sender);
			if (lv.SelectedItems.Count == 1) 
			{
				string strMod  = lv.SelectedItems[0].Text;
				ProcessModule m  = ((ProcessModule) (mcolModules[Convert.ToInt32(strMod)]));
				EnumModule(m);
			}
		}
		catch (Exception exp) 
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}

