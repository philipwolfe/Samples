using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;


namespace XSLQueryBuilderApp
{
	public class FormInsertTrackUI : XSLQueryBuilderApp.FormSQLTrackUI
	{
		private InsertTrack _track;
		private ArrayList dataFields;
		private System.Windows.Forms.Button btnEditDataFields;
		private System.ComponentModel.IContainer components = null;

		public FormInsertTrackUI()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

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

		#region Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnEditDataFields = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// txtMainTable
			// 
			this.txtMainTable.Visible = true;
			// 
			// btnEditDataFields
			// 
			this.btnEditDataFields.Enabled = false;
			this.btnEditDataFields.Location = new System.Drawing.Point(112, 144);
			this.btnEditDataFields.Name = "btnEditDataFields";
			this.btnEditDataFields.Size = new System.Drawing.Size(112, 23);
			this.btnEditDataFields.TabIndex = 49;
			this.btnEditDataFields.Text = "Edit Data Fields...";
			this.btnEditDataFields.Click += new System.EventHandler(this.btnEditDataFields_Click);
			// 
			// FormInsertTrackUI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(350, 371);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtMainTable,
																		  this.btnEditDataFields});
			this.Name = "FormInsertTrackUI";
			this.Text = "Insert Track";
			this.ResumeLayout(false);

		}
		#endregion
	
		
		public override  ISQLTrack sqlTrack 
		{
			get 
			{
				return _track;
			}
			set 
			{
				if(value is InsertTrack)
					_track = (InsertTrack)value;
				else
					_track = null;
			}
		}	
	
		protected override void setupTrackValuesToView() 
		{
			base.setupTrackValuesToView();
			dataFields = (ArrayList)_track.dataFields.Clone();
		}

		protected override void onDataAccessProviderSet() 
		{
			bool bShouldEnableFields = isMainTableSet() && dataAccessProvider.resolved;
			
			base.onDataAccessProviderSet();
			btnEditDataFields.Enabled = bShouldEnableFields;
		}

		private bool isMainTableSet() 
		{
			return txtMainTable.Text != "";
		}

		protected override void onMainTableSet() 
		{
			base.onMainTableSet();
			btnEditDataFields.Enabled = dataAccessProvider.resolved;
		}

		protected override void onMainTableReset() 
		{
			base.onMainTableReset();
			dataFields.Clear();
		}

		protected override void saveViewToTrackValues() 
		{
			base.saveViewToTrackValues();
			_track.dataFields.Clear();
			_track.dataFields.AddRange(dataFields);
		}

		private void btnEditDataFields_Click(object sender, System.EventArgs e)
		{
			FormFieldsView fieldsView = new FormFieldsView();

			fieldsView.allowReferencingFields = true;
			fieldsView.dataAccessProvider = dataAccessProvider;
			fieldsView.fieldsMainTableName = txtMainTable.Text;
			fieldsView.fieldsList = dataFields;
			fieldsView.ShowDialog(this);					
		}

	}
}

