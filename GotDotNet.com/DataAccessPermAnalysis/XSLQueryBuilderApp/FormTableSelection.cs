using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data.OleDb;

namespace XSLQueryBuilderApp
{
	public class FormTableSelection : System.Windows.Forms.Form
	{
		public DataAccessProvider dataAccessProvider;
		private string _selectedTable;
		private const string TABLES_RETRIEVE_QUERY = 
			@"SELECT ut.table_name
			 FROM	user_tables ut
			 ORDER BY ut.table_name
			";
		private System.Windows.Forms.ListBox lstTables;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.Button btnCancel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormTableSelection()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			_selectedTable = "";
			dataAccessProvider = null;
		}

		public string selectedTable 
		{
			get 
			{
				return _selectedTable;
			}
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if(components != null)
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
			this.lstTables = new System.Windows.Forms.ListBox();
			this.btnSelect = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// lstTables
			// 
			this.lstTables.Location = new System.Drawing.Point(16, 24);
			this.lstTables.Name = "lstTables";
			this.lstTables.Size = new System.Drawing.Size(240, 277);
			this.lstTables.TabIndex = 0;
			this.lstTables.DoubleClick += new System.EventHandler(this.lstTables_DoubleClick);
			this.lstTables.SelectedIndexChanged += new System.EventHandler(this.lstTables_SelectedIndexChanged);
			// 
			// btnSelect
			// 
			this.btnSelect.Enabled = false;
			this.btnSelect.Location = new System.Drawing.Point(24, 312);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(80, 23);
			this.btnSelect.TabIndex = 1;
			this.btnSelect.Text = "Select";
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(176, 312);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FormTableSelection
			// 
			this.AcceptButton = this.btnSelect;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(280, 349);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.btnSelect,
																		  this.lstTables});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormTableSelection";
			this.ShowInTaskbar = false;
			this.Text = "Select a Table";
			this.Load += new System.EventHandler(this.FormTableSelection_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormTableSelection_Load(object sender, System.EventArgs e)
		{
			loadTablesToList();
		}

		private void loadTablesToList() 
		{
			OleDbCommand tablesRetrieve = new OleDbCommand();
			OleDbConnection connection = dataAccessProvider.getOpenConnection();
			OleDbDataReader tablesListIterator;
		
			tablesRetrieve.CommandText = TABLES_RETRIEVE_QUERY;
			tablesRetrieve.Connection = connection;
			tablesListIterator = tablesRetrieve.ExecuteReader();

            while(tablesListIterator.Read())
				lstTables.Items.Add(tablesListIterator.GetString(0));
		}

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			onSelectionMade();
		}

		private void onSelectionMade() 
		{
			_selectedTable = lstTables.SelectedItem.ToString();
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void lstTables_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			btnSelect.Enabled = (lstTables.SelectedIndex != -1);
		}

		private void lstTables_DoubleClick(object sender, System.EventArgs e)
		{
			onSelectionMade();
		}

	}
}
