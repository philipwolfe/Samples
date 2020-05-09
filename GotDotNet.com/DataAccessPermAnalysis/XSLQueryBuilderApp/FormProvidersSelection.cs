using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XSLQueryBuilderApp
{
	/// <summary>
	/// Summary description for FormProvidersSelection.
	/// </summary>
	public class FormProvidersSelection : System.Windows.Forms.Form
	{
		private DataAccessProvider _resultProvider;

		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnSelect;
		private System.Windows.Forms.ListBox lstProviders;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormProvidersSelection()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			_resultProvider = null;
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

		public DataAccessProvider resultProvider 
		{
			get 
			{
				return _resultProvider;
			}
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnSelect = new System.Windows.Forms.Button();
			this.lstProviders = new System.Windows.Forms.ListBox();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(175, 312);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 5;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnSelect
			// 
			this.btnSelect.Enabled = false;
			this.btnSelect.Location = new System.Drawing.Point(23, 312);
			this.btnSelect.Name = "btnSelect";
			this.btnSelect.Size = new System.Drawing.Size(80, 23);
			this.btnSelect.TabIndex = 4;
			this.btnSelect.Text = "Select";
			this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
			// 
			// lstProviders
			// 
			this.lstProviders.Location = new System.Drawing.Point(15, 24);
			this.lstProviders.Name = "lstProviders";
			this.lstProviders.Size = new System.Drawing.Size(240, 277);
			this.lstProviders.TabIndex = 3;
			this.lstProviders.DoubleClick += new System.EventHandler(this.lstProviders_DoubleClick);
			this.lstProviders.SelectedIndexChanged += new System.EventHandler(this.lstProviders_SelectedIndexChanged);
			// 
			// FormProvidersSelection
			// 
			this.AcceptButton = this.btnSelect;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(278, 347);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.btnSelect,
																		  this.lstProviders});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormProvidersSelection";
			this.ShowInTaskbar = false;
			this.Text = "Select a Provider";
			this.Load += new System.EventHandler(this.FormProvidersSelection_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnSelect_Click(object sender, System.EventArgs e)
		{
			onSelectionMade();
		}

		private void onSelectionMade() 
		{
			_resultProvider = (DataAccessProvider)lstProviders.SelectedItem;
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void FormProvidersSelection_Load(object sender, System.EventArgs e)
		{
			loadProvidersToList();
		}

		private void loadProvidersToList() 
		{
			AccessProvidersStorage storage = AccessProvidersStorage.getStorage();

			foreach(DataAccessProvider provider in storage.providers.Values) 
				lstProviders.Items.Add(provider);
		}

		private void lstProviders_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			btnSelect.Enabled = (lstProviders.SelectedIndex != -1);
		}

		private void lstProviders_DoubleClick(object sender, System.EventArgs e)
		{
			onSelectionMade();
		}
	}
}
