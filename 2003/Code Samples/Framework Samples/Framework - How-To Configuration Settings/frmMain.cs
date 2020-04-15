//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Windows.Forms;
using System.Configuration;
using System.Collections;
using System.Collections.Specialized;
using System.Xml;

public class frmMain: System.Windows.Forms.Form 
{
	// Sorts the name of our configuration file.
	private string mstrCFGFile;

	// From the System.Collections Namespace.
	// Note the version returned by 
	// ConfigurationSettings.AppSettings is
	// read-only even though instances of
	// Specialized.NameValueCollection can be 
	// read-write.
	private NameValueCollection mAppSet;

	// Custom class to work with app settings
	private AppSettings mcustAppSettings;

	// Individual setting
	private AppSetting mcustAppSet;

#region " Windows Form Designer generated code "

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
	}

	//Form overrides dispose to clean up the component list.
	protected override void Dispose(bool disposing) 
	{
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
	private System.Windows.Forms.TabControl tabOptions;
	private System.Windows.Forms.TabPage pgeAS;
	private System.Windows.Forms.TabPage pgeCustom;
	private System.Windows.Forms.Label lblValue;
	private System.Windows.Forms.TextBox txtKey;
	private System.Windows.Forms.Button cmdReadValue;
	private System.Windows.Forms.Button cmdListByIndex;
	private System.Windows.Forms.Button cmdListByKey;
	private System.Windows.Forms.ListBox lstSettings;
	private System.Windows.Forms.Button cmdLoadAS;
	private System.Windows.Forms.Button cmdLoadCfg;
	private System.Windows.Forms.CheckBox chkAutoSave;
	private System.Windows.Forms.Button cmdListAllSettings;
	private System.Windows.Forms.ListView lvSettings;
	private System.Windows.Forms.ColumnHeader chKey;
	private System.Windows.Forms.ColumnHeader chValue;
	private System.Windows.Forms.TextBox txtSettingKey;
	private System.Windows.Forms.Label lblSettingKey;
	private System.Windows.Forms.Label lblSettingValue;
	private System.Windows.Forms.TextBox txtSettingValue;
	private System.Windows.Forms.Button cmdAddnew;
	private System.Windows.Forms.Button cmdUpdate;
	private System.Windows.Forms.Button cmdSave;
	private System.Windows.Forms.Button cmdUnload;

	private void InitializeComponent() 
	{
		System.Configuration.AppSettingsReader configurationAppSettings = new System.Configuration.AppSettingsReader();

		System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(frmMain));

		this.mnuMain = new System.Windows.Forms.MainMenu();

		this.mnuFile = new System.Windows.Forms.MenuItem();

		this.mnuExit = new System.Windows.Forms.MenuItem();

		this.mnuHelp = new System.Windows.Forms.MenuItem();

		this.mnuAbout = new System.Windows.Forms.MenuItem();

		this.tabOptions = new System.Windows.Forms.TabControl();

		this.pgeAS = new System.Windows.Forms.TabPage();

		this.lblValue = new System.Windows.Forms.Label();

		this.txtKey = new System.Windows.Forms.TextBox();

		this.cmdReadValue = new System.Windows.Forms.Button();

		this.cmdListByIndex = new System.Windows.Forms.Button();

		this.cmdListByKey = new System.Windows.Forms.Button();

		this.lstSettings = new System.Windows.Forms.ListBox();

		this.cmdLoadAS = new System.Windows.Forms.Button();

		this.pgeCustom = new System.Windows.Forms.TabPage();

		this.cmdUnload = new System.Windows.Forms.Button();

		this.cmdSave = new System.Windows.Forms.Button();

		this.cmdUpdate = new System.Windows.Forms.Button();

		this.cmdAddnew = new System.Windows.Forms.Button();

		this.lblSettingValue = new System.Windows.Forms.Label();

		this.txtSettingValue = new System.Windows.Forms.TextBox();

		this.lblSettingKey = new System.Windows.Forms.Label();

		this.txtSettingKey = new System.Windows.Forms.TextBox();

		this.lvSettings = new System.Windows.Forms.ListView();

		this.chKey = new System.Windows.Forms.ColumnHeader();

		this.chValue = new System.Windows.Forms.ColumnHeader();

		this.cmdListAllSettings = new System.Windows.Forms.Button();

		this.chkAutoSave = new System.Windows.Forms.CheckBox();

		this.cmdLoadCfg = new System.Windows.Forms.Button();

		this.tabOptions.SuspendLayout();

		this.pgeAS.SuspendLayout();

		this.pgeCustom.SuspendLayout();

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
		this.mnuExit.Click += new EventHandler(mnuExit_Click);
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
		this.mnuAbout.Click += new EventHandler(mnuAbout_Click);
		//

		//tabOptions

		//

		this.tabOptions.Controls.AddRange(new System.Windows.Forms.Control[] {this.pgeAS, this.pgeCustom});

		this.tabOptions.Location = new System.Drawing.Point(8, 8);

		this.tabOptions.Name = "tabOptions";

		this.tabOptions.SelectedIndex = 0;

		this.tabOptions.Size = new System.Drawing.Size(456, 256);

		this.tabOptions.TabIndex = 0;

		//

		//pgeAS

		//

		this.pgeAS.Controls.AddRange(new System.Windows.Forms.Control[] {this.lblValue, this.txtKey, this.cmdReadValue, this.cmdListByIndex, this.cmdListByKey, this.lstSettings, this.cmdLoadAS});

		this.pgeAS.Location = new System.Drawing.Point(4, 22);

		this.pgeAS.Name = "pgeAS";

		this.pgeAS.Size = new System.Drawing.Size(448, 230);

		this.pgeAS.TabIndex = 0;

		this.pgeAS.Text = "AppSettings";

		//

		//lblValue

		//

		this.lblValue.Location = new System.Drawing.Point(8, 169);

		this.lblValue.Name = "lblValue";

		this.lblValue.Size = new System.Drawing.Size(120, 48);

		this.lblValue.TabIndex = 6;

		this.lblValue.Text = (string) configurationAppSettings.GetValue("lblValue.Text", Type.GetType("System.String")).ToString();

		//

		//txtKey

		//

		this.txtKey.Location = new System.Drawing.Point(8, 137);

		this.txtKey.Name = "txtKey";

		this.txtKey.Size = new System.Drawing.Size(120, 20);

		this.txtKey.TabIndex = 5;

		this.txtKey.Text = "";

		//

		//cmdReadValue

		//

		this.cmdReadValue.Enabled = false;

		this.cmdReadValue.Location = new System.Drawing.Point(8, 105);

		this.cmdReadValue.Name = "cmdReadValue";

		this.cmdReadValue.Size = new System.Drawing.Size(120, 23);

		this.cmdReadValue.TabIndex = 4;

		this.cmdReadValue.Text = "&Read Value";
		this.cmdReadValue.Click += new EventHandler(cmdReadValue_Click);

		//

		//cmdListByIndex

		//

		this.cmdListByIndex.Enabled = false;

		this.cmdListByIndex.Location = new System.Drawing.Point(8, 73);

		this.cmdListByIndex.Name = "cmdListByIndex";

		this.cmdListByIndex.Size = new System.Drawing.Size(120, 23);

		this.cmdListByIndex.TabIndex = 3;

		this.cmdListByIndex.Text = "List By &Index";
		this.cmdListByIndex.Click += new EventHandler(cmdListByIndex_Click);
		//

		//cmdListByKey

		//

		this.cmdListByKey.Enabled = false;

		this.cmdListByKey.Location = new System.Drawing.Point(8, 41);

		this.cmdListByKey.Name = "cmdListByKey";

		this.cmdListByKey.Size = new System.Drawing.Size(120, 23);

		this.cmdListByKey.TabIndex = 2;

		this.cmdListByKey.Text = "List By &Key";
		this.cmdListByKey.Click += new EventHandler(cmdListByKey_Click);
		//

		//lstSettings

		//

		this.lstSettings.Location = new System.Drawing.Point(136, 9);

		this.lstSettings.Name = "lstSettings";

		this.lstSettings.Size = new System.Drawing.Size(304, 212);

		this.lstSettings.TabIndex = 0;

		//

		//cmdLoadAS

		//

		this.cmdLoadAS.Location = new System.Drawing.Point(8, 9);

		this.cmdLoadAS.Name = "cmdLoadAS";

		this.cmdLoadAS.Size = new System.Drawing.Size(120, 23);

		this.cmdLoadAS.TabIndex = 1;

		this.cmdLoadAS.Text = "&Load AppSettings";
		this.cmdLoadAS.Click += new EventHandler(cmdLoadAS_Click);
		//

		//pgeCustom

		//

		this.pgeCustom.Controls.AddRange(new System.Windows.Forms.Control[] {this.cmdUnload, this.cmdSave, this.cmdUpdate, this.cmdAddnew, this.lblSettingValue, this.txtSettingValue, this.lblSettingKey, this.txtSettingKey, this.lvSettings, this.cmdListAllSettings, this.chkAutoSave, this.cmdLoadCfg});

		this.pgeCustom.Location = new System.Drawing.Point(4, 22);

		this.pgeCustom.Name = "pgeCustom";

		this.pgeCustom.Size = new System.Drawing.Size(448, 230);

		this.pgeCustom.TabIndex = 1;

		this.pgeCustom.Text = "Custom";

		//

		//cmdUnload

		//

		this.cmdUnload.Enabled = false;

		this.cmdUnload.Location = new System.Drawing.Point(8, 200);

		this.cmdUnload.Name = "cmdUnload";

		this.cmdUnload.Size = new System.Drawing.Size(140, 23);

		this.cmdUnload.TabIndex = 11;

		this.cmdUnload.Text = "&Unload";
		this.cmdUnload.Click += new EventHandler(cmdUnload_Click);
		//

		//cmdSave

		//

		this.cmdSave.Enabled = false;

		this.cmdSave.Location = new System.Drawing.Point(8, 168);

		this.cmdSave.Name = "cmdSave";

		this.cmdSave.Size = new System.Drawing.Size(140, 23);

		this.cmdSave.TabIndex = 5;

		this.cmdSave.Text = "&Save";
		this.cmdSave.Click += new EventHandler(cmdSave_Click);
		//

		//cmdUpdate

		//

		this.cmdUpdate.Enabled = false;

		this.cmdUpdate.Location = new System.Drawing.Point(8, 136);

		this.cmdUpdate.Name = "cmdUpdate";

		this.cmdUpdate.Size = new System.Drawing.Size(140, 23);

		this.cmdUpdate.TabIndex = 4;

		this.cmdUpdate.Text = "&Update";
		this.cmdUpdate.Click += new EventHandler(cmdUpdate_Click);
		//

		//cmdAddnew

		//

		this.cmdAddnew.Enabled = false;

		this.cmdAddnew.Location = new System.Drawing.Point(8, 104);

		this.cmdAddnew.Name = "cmdAddnew";

		this.cmdAddnew.Size = new System.Drawing.Size(140, 23);

		this.cmdAddnew.TabIndex = 3;

		this.cmdAddnew.Text = "&Add new Pair";
		this.cmdAddnew.Click += new EventHandler(cmdAddnew_Click);
		//

		//lblSettingValue

		//

		this.lblSettingValue.Location = new System.Drawing.Point(152, 200);

		this.lblSettingValue.Name = "lblSettingValue";

		this.lblSettingValue.Size = new System.Drawing.Size(50, 23);

		this.lblSettingValue.TabIndex = 9;

		this.lblSettingValue.Text = "&Value";

		//

		//txtSettingValue

		//

		this.txtSettingValue.Location = new System.Drawing.Point(208, 200);

		this.txtSettingValue.Name = "txtSettingValue";

		this.txtSettingValue.Size = new System.Drawing.Size(232, 20);

		this.txtSettingValue.TabIndex = 10;

		this.txtSettingValue.Text = "";

		//

		//lblSettingKey

		//

		this.lblSettingKey.Location = new System.Drawing.Point(152, 176);

		this.lblSettingKey.Name = "lblSettingKey";

		this.lblSettingKey.Size = new System.Drawing.Size(50, 23);

		this.lblSettingKey.TabIndex = 7;

		this.lblSettingKey.Text = "&Key";

		//

		//txtSettingKey

		//

		this.txtSettingKey.Location = new System.Drawing.Point(208, 176);

		this.txtSettingKey.Name = "txtSettingKey";

		this.txtSettingKey.Size = new System.Drawing.Size(232, 20);

		this.txtSettingKey.TabIndex = 8;

		this.txtSettingKey.Text = "";

		//

		//lvSettings

		//

		this.lvSettings.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {this.chKey, this.chValue});

		this.lvSettings.FullRowSelect = true;

		this.lvSettings.Location = new System.Drawing.Point(152, 8);

		this.lvSettings.MultiSelect = false;

		this.lvSettings.Name = "lvSettings";

		this.lvSettings.Size = new System.Drawing.Size(288, 160);

		this.lvSettings.Sorting = System.Windows.Forms.SortOrder.Ascending;

		this.lvSettings.TabIndex = 6;

		this.lvSettings.View = System.Windows.Forms.View.Details;
		this.lvSettings.SelectedIndexChanged += new EventHandler(lvSettings_SelectedIndexChanged);
		//

		//chKey

		//

		this.chKey.Text = "Key";

		this.chKey.Width = 100;

		//

		//chValue

		//

		this.chValue.Text = "Value";

		this.chValue.Width = 175;

		//

		//cmdListAllSettings

		//

		this.cmdListAllSettings.Enabled = false;

		this.cmdListAllSettings.Location = new System.Drawing.Point(8, 72);

		this.cmdListAllSettings.Name = "cmdListAllSettings";

		this.cmdListAllSettings.Size = new System.Drawing.Size(140, 23);

		this.cmdListAllSettings.TabIndex = 2;

		this.cmdListAllSettings.Text = "&List All Settings";
		this.cmdListAllSettings.Click += new EventHandler(cmdListAllSettings_Click);
		

		//

		//chkAutoSave

		//

		this.chkAutoSave.Location = new System.Drawing.Point(8, 40);

		this.chkAutoSave.Name = "chkAutoSave";

		this.chkAutoSave.Size = new System.Drawing.Size(140, 23);

		this.chkAutoSave.TabIndex = 1;

		this.chkAutoSave.Text = "&Enable AutoSave?";
		
		//

		//cmdLoadCfg

		//

		this.cmdLoadCfg.Location = new System.Drawing.Point(8, 8);

		this.cmdLoadCfg.Name = "cmdLoadCfg";

		this.cmdLoadCfg.Size = new System.Drawing.Size(140, 23);

		this.cmdLoadCfg.TabIndex = 0;

		this.cmdLoadCfg.Text = "Load &Config";
		this.cmdLoadCfg.Click += new EventHandler(cmdLoadCfg_Click);
		//

		//frmMain

		//

		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);

		this.ClientSize = new System.Drawing.Size(474, 275);

		this.Controls.AddRange(new System.Windows.Forms.Control[] {this.tabOptions});

		this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;

		this.Icon = (System.Drawing.Icon) resources.GetObject("$this.Icon");

		this.MaximizeBox = false;

		this.Menu = this.mnuMain;

		this.Name = "frmMain";

		this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;

		this.Text = "Title Comes from Assembly Info";

		this.tabOptions.ResumeLayout(false);

		this.pgeAS.ResumeLayout(false);

		this.pgeCustom.ResumeLayout(false);

		this.ResumeLayout(false);
		this.Load += new EventHandler(frmMain_Load);
	}
#endregion

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new frmMain());
	}

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

	private void cmdLoadAS_Click(object sender, System.EventArgs e)
	{
		// Access the application settings that were
		// loaded at start time.
		mAppSet = ConfigurationSettings.AppSettings;

		MessageBox.Show("Applicaton Settings have been loaded.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);

		this.cmdListByIndex.Enabled = true;
		this.cmdListByKey.Enabled = true;
		this.cmdReadValue.Enabled = true;

		// The settings are loaded once per app domain.
		// So, there's no point in trying again.
		this.cmdLoadAS.Enabled = false;
	}

	private void cmdListByKey_Click(object sender, System.EventArgs e)
	{
		// This routine lists the items by getting
		// a list of keys and then accessing the items
		// by key.
		if (mAppSet != null) 
		{
			this.lstSettings.Items.Clear();
			string[] keys = mAppSet.AllKeys;
			
			foreach(string key in keys)
			{
				this.lstSettings.Items.Add(key + ": " + mAppSet[key]);
			}
		}
	}

	private void cmdListByIndex_Click(object sender, System.EventArgs e) 
	{
		// This routine lists the items using
		// an index number.
		if (mAppSet != null) 
		{
			this.lstSettings.Items.Clear();
			for(int i = 0; i < mAppSet.Count; i++)
			{
				this.lstSettings.Items.Add(mAppSet.GetKey(i) + ": " + mAppSet[i]);
			}
		}
	}

	private void cmdReadValue_Click(object sender, System.EventArgs e)
	{
		this.lblValue.Text = mAppSet[this.txtKey.Text];
	}

	private void frmMain_Load(object sender, System.EventArgs e) 
	{
		// Each application domain in a process can have
		// a configuration file.
		// Windows Forms applications by default have
		// one appdomain and one configuration file.

		AppDomain ad = AppDomain.CurrentDomain;

		this.mstrCFGFile = ad.SetupInformation.ConfigurationFile;
	}

	private void cmdLoadCfg_Click(object sender, System.EventArgs e)
	{
		// This function uses a custom AppSettings instance to load
		// the configuration file settings.
		try 
		{
			bool blnAutoSave;

			if (this.chkAutoSave.CheckState == CheckState.Checked)
			{
				blnAutoSave = true;
			}
			else 
			{
				blnAutoSave = false;
			}

			if (mcustAppSettings != null)
			{
				mcustAppSettings.Dispose();
				mcustAppSettings = null;
			}

			mcustAppSettings = new AppSettings(this.mstrCFGFile, blnAutoSave);

			if (this.lvSettings.Items.Count > 0)
			{
				this.lvSettings.Items.Clear();
			}

			this.cmdAddnew.Enabled = true;
			this.cmdListAllSettings.Enabled = true;
			this.cmdUpdate.Enabled = true;
			this.cmdSave.Enabled = true;
			this.cmdUnload.Enabled = true;
		}
		catch (Exception exp)
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void cmdListAllSettings_Click(object sender, System.EventArgs e) 
	{
		this.ListCustomSettings();
	}

	private void lvSettings_SelectedIndexChanged(object sender, System.EventArgs e)
	{
		// Put the current selected key/value pair's values
		// into the appropriate text boxes.
		if (this.lvSettings.SelectedItems.Count == 1)
		{
			this.txtSettingKey.Text = this.lvSettings.SelectedItems[0].SubItems[0].Text;
			this.txtSettingValue.Text = this.lvSettings.SelectedItems[0].SubItems[1].Text;
		}
	}

	private void cmdAddnew_Click(object sender, System.EventArgs e)
	{
		// Add a new item to the collection
		try 
		{
			if (this.txtSettingKey.Text == string.Empty)
			{
				MessageBox.Show("You must enter a value for the key.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.txtSettingKey.Select();
				return;
			}

			if (this.txtSettingValue.Text == string.Empty)
			{
				MessageBox.Show("You must enter a value for the value field.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.txtSettingValue.Select();
				return;
			}

			mcustAppSet = new AppSetting(this.txtSettingKey.Text, this.txtSettingValue.Text);
			mcustAppSettings.Add(mcustAppSet);

			this.ListCustomSettings();

			MessageBox.Show("new setting added.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		catch (Exception exp)
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void ListCustomSettings()
	{
		// list all the settings and put them
		// in the list view control
		if (mcustAppSettings != null)
		{
			try 
			{
				this.lvSettings.Items.Clear();
				
				foreach(AppSetting mcustAppSet in mcustAppSettings)
				{
					ListViewItem item = this.lvSettings.Items.Add(mcustAppSet.Key);
					item.SubItems.Add(mcustAppSet.Value);
				}
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}

	private void frmMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
	{
		this.UnloadConfigSettings(true);
	}

	private void cmdUpdate_Click(object sender, System.EventArgs e) 
	{
		// Update an existing item.
		try 
		{
			if (this.txtSettingKey.Text == string.Empty)
			{
				MessageBox.Show("You must enter a value for the key.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.txtSettingKey.Select();
				return;
			}

			if (this.txtSettingValue.Text == string.Empty)
			{
				MessageBox.Show("You must enter a value for the value field.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
				this.txtSettingValue.Select();
				return;
			}

			mcustAppSet = new AppSetting(this.txtSettingKey.Text, this.txtSettingValue.Text);
			mcustAppSettings.Update(mcustAppSet);

			this.ListCustomSettings();

			MessageBox.Show("Existing setting updated.", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
		}
		catch (Exception exp)
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}

	private void cmdSave_Click(object sender, System.EventArgs e) 
	{
		// Save any changes.
		if (mcustAppSettings != null) 
		{
			try 
			{
				mcustAppSettings.Save();
				MessageBox.Show("Configuration file saved..", this.Text, MessageBoxButtons.OK, MessageBoxIcon.Information);
			}
			catch (Exception exp)
			{
				MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
	}

	private void cmdUnload_Click(object sender, System.EventArgs e)
	{
		this.UnloadConfigSettings(false);
	}

	private void UnloadConfigSettings(bool FormClosing)
	{
		// Correctly unload the configuration file
		// by calling its Dispose method and releasing the 
		// object reference.
		try 
		{
			if (mcustAppSettings != null)
			{
				mcustAppSettings.Dispose();
				mcustAppSettings = null;

				if (!FormClosing) 
				{
					this.lvSettings.Items.Clear();
					this.txtSettingKey.Text = string.Empty;
					this.txtSettingValue.Text = string.Empty;
					this.cmdListAllSettings.Enabled = false;
					this.cmdAddnew.Enabled = false;
					this.cmdUpdate.Enabled = false;
					this.cmdSave.Enabled = false;
					this.cmdLoadCfg.Select();
					this.cmdUnload.Enabled = false;
				}
			}
		}
		catch (Exception exp)
		{
			MessageBox.Show(exp.Message, exp.Source, MessageBoxButtons.OK, MessageBoxIcon.Error);
		}
	}
}

public class AppSetting
{
	// This class maps the name/value pairs
	// the parent setting will be set
	// if the user ask for an AppSetting 
	// via the AppSettings instance.
	// This allows us to update the
	// configuration file if changes are made.
	private AppSettings mParent;
	private string mstrKey;
	private string mstrValue;

	public string Key
	{
		get {
			return mstrKey;
		}
		set {
			this.UpdateParent();
			mstrKey = value;
		}
	}

	public string Value
	{
		get {
			return mstrValue;
		}
		set {
			this.UpdateParent();
			mstrValue = value;
		}
	}

	private void UpdateParent()
	{
		if (this.mParent != null)
		{
			this.mParent.Update(this);
		}
	}

	public AppSetting(): this(string.Empty, string.Empty)
	{
	}

	public AppSetting(string Key, string Value): this(Key, Value, null)
	{
	}

	internal AppSetting(string Key, string Value, AppSettings Parent)
	{
		this.mstrKey = Key;
		this.mstrValue = Value;
		this.mParent = Parent;
	}
}

public class AppSettings: IEnumerable, IDisposable
{
	// This classes wraps access to the configuration//appSettings
	// section of the config file specified when an instance is created.
	// XPath expressions are used to find values when requested.
	// In addition, the class supports enumeration by implementing
	// IEnumerable and providing a private Iterator which implements
	// IEnumerator.

	private XmlDocument cfg = new XmlDocument();
	private XmlNode xAS;

	private string mstrFileName;
	private bool mblnAutoSave;
	private bool mblnDirty;
	private AppSetting[] maItems;
	private bool mblnDisposing;
	private bool mblnDisposed;
	private const string APPSETTINGS_ELEMENT = "configuration//appSettings";
	private const string NEWELEMENT = "add";
	private const string XPATH_KEY_ADD = "//add";
	private const string XPATH_KEY_ADD_KEY = "//add[@key='{0}']";
	
	public AppSettings(string ConfigFile):this(ConfigFile, false)
	{
	}

	public AppSettings(string ConfigFile, bool AutoSave)
	{	

		if (ConfigFile.Length == 0)
		{
			throw new ArgumentNullException("You must pass in a valid file name.");
		}
		else 
		{
			if (System.IO.File.Exists(ConfigFile)) 
			{
				try 
				{
					cfg.Load(ConfigFile);
				}
				catch (Exception exp)
				{
					throw new System.IO.FileLoadException("The file name specified could not be loaded. Please see InnerException for more information", exp);
				}

				// Get the main appSettings element
				// so we can add new settings
				xAS = cfg.SelectSingleNode(APPSETTINGS_ELEMENT);

				if (xAS == null)
				{
					throw new ConfigurationException("The file specified, while a valid XML document, is not a valid configuration file.");
				}

				// if we get this far we need to
				// store the file name for any changes
				mstrFileName = ConfigFile;
				this.AutoSave = AutoSave;
			}
			else 
			{
				throw new System.IO.FileNotFoundException(string.Format("The file name specified {0} does not exist.", ConfigFile));
			}
		}
	}

	public void Dispose()
	{
		this.mblnDisposing = true;

		if (this.Dirty)
		{
			this.Save();
		}

		this.mblnDisposed = true;
		this.mblnDisposing = false;
		GC.SuppressFinalize(this);
	}

	~AppSettings()
	{
		if (this.Dirty)
		{
			if (!this.mblnDisposed) {
				if (!this.mblnDisposing) {
					this.Dispose();
				}
			}
		}
	}

	public bool AutoSave
	{
		get 
		{
			return this.mblnAutoSave;
		}
		set 
		{
			this.mblnAutoSave = value;
		}
	}

	public bool Dirty
	{
		get {
			return this.mblnDirty;
		}
	}

	public void Add(AppSetting newSetting)
	{
		XmlElement newElem;
		XmlAttribute newAttr;

		newElem = cfg.CreateElement(NEWELEMENT);
		newAttr = cfg.CreateAttribute("key");

		newAttr.Value = newSetting.Key;
		newElem.Attributes.Append(newAttr);
		
		newAttr = cfg.CreateAttribute("value");
		newAttr.Value = newSetting.Value;

		newElem.Attributes.Append(newAttr);
		xAS.AppendChild(newElem);

		this.mblnDirty = true;

		if (this.AutoSave)
		{
			this.Save();
		}
	}

	public AppSetting Add(string Key, string Value)
	{
		AppSetting newSetting = new AppSetting(Key, Value, this);
		this.Add(newSetting);
		return newSetting;
	}

	public AppSetting Item(string Key)
	{
		XmlNode xNode;
		string strSearch = XPATH_KEY_ADD_KEY;

		xNode = xAS.SelectSingleNode(string.Format(strSearch, Key));

		if (xNode == null) 
		{
			throw new ArgumentOutOfRangeException("Key", Key, "The item you wanted to update does not exists.");
		}
		else 
		{
			AppSetting las = new AppSetting();
			las.Key = Key;
			las.Value = xNode.Attributes.Item(1).Value;

			return las;
		}
	}

	public void RemoveByKey(AppSetting Setting)
	{
		XmlNode xNode;
		string strSearch = XPATH_KEY_ADD_KEY;

		xNode = xAS.SelectSingleNode(string.Format(strSearch, Setting.Key));

		if (xNode != null)
		{

		}

		this.mblnDirty = true;

		if (this.AutoSave)
		{
			this.Save();
		}
	}

	public void RemoveByKey(string Key)
	{

	}

	public AppSetting Update(string Key, string Value)
	{
		AppSetting newSetting = new AppSetting(Key, Value, this);
		this.Update(newSetting);
		return newSetting;
	}

	public void Update(AppSetting newSetting)
	{
		XmlNode xNode;
		string strSearch = XPATH_KEY_ADD_KEY;

		xNode = xAS.SelectSingleNode(string.Format(strSearch, newSetting.Key));

		if (xNode == null)
		{
			throw new ArgumentOutOfRangeException("Key", newSetting.Key, "The item you wanted to update does not exists.");
		}
		else 
		{
			xNode.Attributes.Item(1).Value = newSetting.Value;
		}

		this.mblnDirty = true;

		if (this.AutoSave) 
		{
			this.Save();
		}
	}

	public void Save()
	{
		// We don't have a try catch here so
		// that if we fail, it will bounce up
		// to our caller.
		cfg.Save(this.mstrFileName);
		this.mblnDirty = false;
	}

	private AppSetting[] GetAllItems()
	{
		XmlNodeList xNodeList;
		XmlAttributeCollection atts;
		xNodeList = xAS.SelectNodes(XPATH_KEY_ADD);

		AppSetting[] asa = new AppSetting[xNodeList.Count];
		AppSetting asi;

		int i = -1;

		foreach(XmlNode xNode in xNodeList)
		{
			i += 1;

			atts = xNode.Attributes;
			asi = new AppSetting(atts.Item(0).Value, atts.Item(1).Value, this);
			asa[i] = asi;
		}

		return asa;
	}

	public System.Collections.IEnumerator GetEnumerator() 
	{
		this.maItems = this.GetAllItems();
		return new Iterator(this.maItems);
	}

	private class Iterator: IEnumerator
	{
		// This private class exposes the necessary
		// functions so that For..Each will work.
		private AppSetting[] mData;
		private int Index = -1;

		public Iterator(AppSetting[] Keys)
		{
			mData = Keys;
		}

		public object Current
		{
			get {
				return mData[Index];
			}
		}

		public bool MoveNext()
		{
			Index += 1;

			if (Index <= (mData.Length - 1)) 
			{
				return true;
			}
			else
			{
				return false;
			}
		}

		public void Reset()
		{
			Index = -1;
		}
	}
}
