using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace XSLQueryBuilderApp
{
	public class FormUpdateTrackUI : XSLQueryBuilderApp.FormSQLTrackUI
	{
		private UpdateTrack _track;
		private ArrayList dataFields;
		private ArrayList profileFields;
		private System.Windows.Forms.Button btnEditProfileFields;
		private System.Windows.Forms.Button btnEditDataFields;
		private System.Windows.Forms.CheckBox chkBindProfile;
		private System.ComponentModel.IContainer components = null;

		public FormUpdateTrackUI()
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
			this.btnEditProfileFields = new System.Windows.Forms.Button();
			this.btnEditDataFields = new System.Windows.Forms.Button();
			this.chkBindProfile = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// txtMainTable
			// 
			this.txtMainTable.Visible = true;
			// 
			// btnEditProfileFields
			// 
			this.btnEditProfileFields.Enabled = false;
			this.btnEditProfileFields.Location = new System.Drawing.Point(48, 160);
			this.btnEditProfileFields.Name = "btnEditProfileFields";
			this.btnEditProfileFields.Size = new System.Drawing.Size(112, 23);
			this.btnEditProfileFields.TabIndex = 52;
			this.btnEditProfileFields.Text = "Edit Profile Fields...";
			this.btnEditProfileFields.Click += new System.EventHandler(this.btnEditProfileFields_Click);
			// 
			// btnEditDataFields
			// 
			this.btnEditDataFields.Enabled = false;
			this.btnEditDataFields.Location = new System.Drawing.Point(192, 160);
			this.btnEditDataFields.Name = "btnEditDataFields";
			this.btnEditDataFields.Size = new System.Drawing.Size(112, 23);
			this.btnEditDataFields.TabIndex = 53;
			this.btnEditDataFields.Text = "Edit Data Fields...";
			this.btnEditDataFields.Click += new System.EventHandler(this.btnEditDataFields_Click);
			// 
			// chkBindProfile
			// 
			this.chkBindProfile.Location = new System.Drawing.Point(48, 192);
			this.chkBindProfile.Name = "chkBindProfile";
			this.chkBindProfile.TabIndex = 63;
			this.chkBindProfile.Text = "Bind Profile";
			// 
			// FormUpdateTrackUI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(354, 375);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkBindProfile,
																		  this.txtMainTable,
																		  this.btnEditDataFields,
																		  this.btnEditProfileFields});
			this.Name = "FormUpdateTrackUI";
			this.Text = "Update Track";
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
				if(value is UpdateTrack)
					_track = (UpdateTrack)value;
				else
					_track = null;
			}
		}	
	
		protected override void setupTrackValuesToView() 
		{
			base.setupTrackValuesToView();
			chkBindProfile.Checked = _track.bindProfile;
			profileFields = (ArrayList)_track.profileFields.Clone();
			dataFields = (ArrayList)_track.dataFields.Clone();
		}

		protected override void onDataAccessProviderSet() 
		{
			bool bShouldEnableFields = isMainTableSet() && dataAccessProvider.resolved;

			base.onDataAccessProviderSet();
			btnEditProfileFields.Enabled = bShouldEnableFields;
			btnEditDataFields.Enabled = bShouldEnableFields;
		}

		private bool isMainTableSet() 
		{
			return txtMainTable.Text != "";
		}

		protected override void onMainTableSet() 
		{
			base.onMainTableSet();
			btnEditProfileFields.Enabled = dataAccessProvider.resolved;
			btnEditDataFields.Enabled = dataAccessProvider.resolved;
		}

		protected override void onMainTableReset() 
		{
			base.onMainTableReset();
			profileFields.Clear();
			dataFields.Clear();
		}

		protected override void saveViewToTrackValues() 
		{
			base.saveViewToTrackValues();
			_track.bindProfile = chkBindProfile.Checked;
			_track.profileFields.Clear();
			_track.profileFields.AddRange(profileFields);
			_track.dataFields.Clear();
			_track.dataFields.AddRange(dataFields);
		}

		private void btnEditProfileFields_Click(object sender, System.EventArgs e)
		{
			showFieldsEditingDialog(profileFields,false);		
		}

		private void btnEditDataFields_Click(object sender, System.EventArgs e)
		{
			showFieldsEditingDialog(dataFields,true);		
		}

		private void showFieldsEditingDialog(ArrayList fields,bool allowReferencingFields) 
		{
			FormFieldsView fieldsView = new FormFieldsView();

			fieldsView.allowReferencingFields = allowReferencingFields;
			fieldsView.dataAccessProvider = dataAccessProvider;
			fieldsView.fieldsMainTableName = txtMainTable.Text;
			fieldsView.fieldsList = fields;
			fieldsView.ShowDialog(this);	
		}
	}
}

