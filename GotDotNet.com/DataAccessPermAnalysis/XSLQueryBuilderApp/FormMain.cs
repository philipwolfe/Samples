using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using System.IO;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	public class FormMain : System.Windows.Forms.Form
	{

		private PDOUIPicker uiPicker;
		private PDOClassFactory pdoClassFactory;
		private QueryXSLBuilder queryXSLBuilder;

		private System.Windows.Forms.Button btnAdd;
		private System.Windows.Forms.ListBox listTracks;
		private System.Windows.Forms.Button btnRemove;
		private System.Windows.Forms.Button btnEdit;
		private System.Windows.Forms.Button btnGenerate;
		private System.Windows.Forms.SaveFileDialog saveFileDialog;
		private System.Windows.Forms.MenuItem menuFile;
		private System.Windows.Forms.MenuItem menuSave;
		private System.Windows.Forms.MainMenu mainMenu;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.MenuItem menuLoad;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuExit;
		private System.Windows.Forms.MenuItem menuNew;
		private System.Windows.Forms.MenuItem mnuOptions;
		private System.Windows.Forms.MenuItem mnuPreferences;
		private System.ComponentModel.Container components = null;

		public FormMain()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			uiPicker = new PDOUIPicker();
			pdoClassFactory = PDOClassFactory.getClassFactory();
			queryXSLBuilder = new QueryXSLBuilder();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnAdd = new System.Windows.Forms.Button();
			this.listTracks = new System.Windows.Forms.ListBox();
			this.btnRemove = new System.Windows.Forms.Button();
			this.btnEdit = new System.Windows.Forms.Button();
			this.btnGenerate = new System.Windows.Forms.Button();
			this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
			this.mainMenu = new System.Windows.Forms.MainMenu();
			this.menuFile = new System.Windows.Forms.MenuItem();
			this.menuNew = new System.Windows.Forms.MenuItem();
			this.menuLoad = new System.Windows.Forms.MenuItem();
			this.menuSave = new System.Windows.Forms.MenuItem();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuExit = new System.Windows.Forms.MenuItem();
			this.mnuOptions = new System.Windows.Forms.MenuItem();
			this.mnuPreferences = new System.Windows.Forms.MenuItem();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.SuspendLayout();
			// 
			// btnAdd
			// 
			this.btnAdd.Location = new System.Drawing.Point(296, 40);
			this.btnAdd.Name = "btnAdd";
			this.btnAdd.Size = new System.Drawing.Size(80, 23);
			this.btnAdd.TabIndex = 0;
			this.btnAdd.Text = "Add";
			this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
			// 
			// listTracks
			// 
			this.listTracks.Location = new System.Drawing.Point(56, 40);
			this.listTracks.Name = "listTracks";
			this.listTracks.Size = new System.Drawing.Size(224, 238);
			this.listTracks.TabIndex = 1;
			this.listTracks.DoubleClick += new System.EventHandler(this.listTracks_DoubleClick);
			// 
			// btnRemove
			// 
			this.btnRemove.Location = new System.Drawing.Point(296, 72);
			this.btnRemove.Name = "btnRemove";
			this.btnRemove.Size = new System.Drawing.Size(80, 23);
			this.btnRemove.TabIndex = 2;
			this.btnRemove.Text = "Remove";
			this.btnRemove.Click += new System.EventHandler(this.btnRemove_Click);
			// 
			// btnEdit
			// 
			this.btnEdit.Location = new System.Drawing.Point(296, 104);
			this.btnEdit.Name = "btnEdit";
			this.btnEdit.Size = new System.Drawing.Size(80, 23);
			this.btnEdit.TabIndex = 3;
			this.btnEdit.Text = "Edit";
			this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
			// 
			// btnGenerate
			// 
			this.btnGenerate.Location = new System.Drawing.Point(296, 208);
			this.btnGenerate.Name = "btnGenerate";
			this.btnGenerate.Size = new System.Drawing.Size(80, 23);
			this.btnGenerate.TabIndex = 4;
			this.btnGenerate.Text = "Generate";
			this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
			// 
			// saveFileDialog
			// 
			this.saveFileDialog.Title = "Save Generated XSL to";
			// 
			// mainMenu
			// 
			this.mainMenu.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuFile,
																					 this.mnuOptions});
			// 
			// menuFile
			// 
			this.menuFile.Index = 0;
			this.menuFile.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					 this.menuNew,
																					 this.menuLoad,
																					 this.menuSave,
																					 this.menuItem1,
																					 this.menuExit});
			this.menuFile.Text = "&File";
			// 
			// menuNew
			// 
			this.menuNew.Index = 0;
			this.menuNew.Text = "&New";
			this.menuNew.Click += new System.EventHandler(this.menuNew_Click);
			// 
			// menuLoad
			// 
			this.menuLoad.Index = 1;
			this.menuLoad.Text = "&Open";
			this.menuLoad.Click += new System.EventHandler(this.menuLoad_Click);
			// 
			// menuSave
			// 
			this.menuSave.Index = 2;
			this.menuSave.Text = "&Save";
			this.menuSave.Click += new System.EventHandler(this.menuSave_Click);
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 3;
			this.menuItem1.Text = "-";
			// 
			// menuExit
			// 
			this.menuExit.Index = 4;
			this.menuExit.Text = "&Exit";
			this.menuExit.Click += new System.EventHandler(this.menuExit_Click);
			// 
			// mnuOptions
			// 
			this.mnuOptions.Index = 1;
			this.mnuOptions.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.mnuPreferences});
			this.mnuOptions.Text = "&Options";
			// 
			// mnuPreferences
			// 
			this.mnuPreferences.Index = 0;
			this.mnuPreferences.Text = "&Preferences";
			this.mnuPreferences.Click += new System.EventHandler(this.mnuPreferences_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.Filter = "XML Files|*.xml";
			// 
			// FormMain
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(416, 325);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnGenerate,
																		  this.btnEdit,
																		  this.btnRemove,
																		  this.listTracks,
																		  this.btnAdd});
			this.Menu = this.mainMenu;
			this.Name = "FormMain";
			this.Text = "XSL Query Builder";
			this.Closing += new System.ComponentModel.CancelEventHandler(this.FormMain_Closing);
			this.Load += new System.EventHandler(this.FormMain_Load);
			this.ResumeLayout(false);

		}
		#endregion

		[STAThread]
		static void Main() 
		{
			Application.Run(new FormMain());
		}

		private void btnAdd_Click(object sender, System.EventArgs e)
		{
			FormTrackTypeSelect frmTypeSelect = new FormTrackTypeSelect();

			if(frmTypeSelect.ShowDialog(this) == DialogResult.OK) 
				showNewTrackWindowForType(frmTypeSelect.resultTrackType);
		}

		private void showNewTrackWindowForType(string trackType) 
		{
			ITrack newTrack;

			newTrack = pdoClassFactory.createTrack(trackType);
			newTrack.accept(uiPicker);
			
			if(uiPicker.uiResult == DialogResult.OK)
				listTracks.Items.Add(newTrack);
		}

		private void btnRemove_Click(object sender, System.EventArgs e)
		{
			if(listTracks.SelectedIndex != -1) 
				listTracks.Items.Remove(listTracks.Items[listTracks.SelectedIndex]);
		}

		private void btnEdit_Click(object sender, System.EventArgs e)
		{
			onTrackEdit();
		}

		private void onTrackEdit() 
		{
			ITrack selectedTrack;

			if(listTracks.SelectedIndex != -1) 
			{
				selectedTrack = (ITrack)listTracks.SelectedItem;
				selectedTrack.accept(uiPicker);
			
				if(uiPicker.uiResult == DialogResult.OK)
					refreshSelectedTrackLabel();
			}
		}

		private void refreshSelectedTrackLabel() 
		{
			listTracks.Items[listTracks.SelectedIndex] = listTracks.SelectedItem;
		}

		private void listTracks_DoubleClick(object sender, System.EventArgs e)
		{
			onTrackEdit();
		}

		private void btnGenerate_Click(object sender, System.EventArgs e)
		{
			if(listTracks.Items.Count > 0) {
				saveFileDialog.Filter = "XSL files|*.xsl";
				if(saveFileDialog.ShowDialog(this) == DialogResult.OK) 
				{

					queryXSLBuilder.query = getTracksQuery();
					queryXSLBuilder.generateQueryXSL(saveFileDialog.FileName);
					MessageBox.Show("Generate Done");
				}
			}
		}

		private Query getTracksQuery() 
		{
			Query query = new Query();
			
			query.tracks.AddRange(listTracks.Items);
			return query;
		}

		private void menuSave_Click(object sender, System.EventArgs e)
		{
			
			saveFileDialog.Filter = "XML files|*.xml";
			if(saveFileDialog.ShowDialog(this) == DialogResult.OK) 
			{
				getTracksQuery().serialize(saveFileDialog.FileName);
				MessageBox.Show("Save Done");
			}
		}

		private void menuExit_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void menuLoad_Click(object sender, System.EventArgs e)
		{
			Query query;

			if(openFileDialog.ShowDialog(this) == DialogResult.OK) 
			{
				query = new Query();
				query.load(openFileDialog.FileName);
				listTracks.Items.Clear();
				foreach(Track track in query.tracks)
					listTracks.Items.Add(track);
				MessageBox.Show("Load Done");
			}
		}

		private void menuNew_Click(object sender, System.EventArgs e)
		{
			listTracks.Items.Clear();
		}

		private void FormMain_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			saveSettings();
		}

		private void saveSettings() 
		{
			XmlTextWriter settingsWriter = 
				new XmlTextWriter(
					Application.StartupPath + "\\settings.xml",
					System.Text.Encoding.GetEncoding(PreferencesStorage.getStorage().encoding)
				);

			settingsWriter.WriteStartDocument(true);
			settingsWriter.WriteStartElement("Settings");
			PreferencesStorage.getStorage().serialize(settingsWriter);
			settingsWriter.WriteStartElement("DataAccessProviders");
			AccessProvidersStorage.getStorage().serialize(settingsWriter);
			settingsWriter.WriteEndElement();
			settingsWriter.WriteEndElement();
			settingsWriter.WriteEndDocument();
			settingsWriter.Close();

		}


		private void FormMain_Load(object sender, System.EventArgs e)
		{
			loadSettings();
			uiPicker.parentWindow = this;
		}

		private void loadSettings() 
		{
			XmlTextReader settingsReader;
			XmlReaderEntityNavigator input;

			string settingsFileName = Application.StartupPath + "\\settings.xml";
			if(fileExists(settingsFileName)) 
			{
				settingsReader = new XmlTextReader(settingsFileName);
				input =	new XmlReaderEntityNavigator(settingsReader,"Settings");
				input.moveToEntitiesBegin();
				PreferencesStorage.getStorage().load(input);
				input.entitiesBoundLabel = "DataAccessProviders";
				AccessProvidersStorage.getStorage().load(input);
				settingsReader.Close();
			}
		}
	
		private bool fileExists(string filename) 
		{
			FileInfo fInfo = new FileInfo(filename);

			return fInfo.Exists;
		}

		private void mnuPreferences_Click(object sender, System.EventArgs e)
		{
			FormPreferences frmPreferences = new FormPreferences();

			frmPreferences.ShowDialog(this);
		}
	}
}
