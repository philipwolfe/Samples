using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace XSLQueryBuilderApp
{
	public class FormDeleteTrackUI : XSLQueryBuilderApp.FormSQLTrackUI
	{
		private DeleteTrack _track;
		private ArrayList profileFields;
		private System.Windows.Forms.Button btnEditProfileFields;
		private System.Windows.Forms.CheckBox chkBindProfile;
		private System.ComponentModel.IContainer components = null;

		public FormDeleteTrackUI()
		{
			// This call is required by the Windows Form Designer.
			InitializeComponent();

			// TODO: Add any initialization after the InitializeComponent call
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
			this.chkBindProfile = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// txtMainTable
			// 
			this.txtMainTable.Visible = true;
			// 
			// btnEditProfileFields
			// 
			this.btnEditProfileFields.Location = new System.Drawing.Point(112, 144);
			this.btnEditProfileFields.Name = "btnEditProfileFields";
			this.btnEditProfileFields.Size = new System.Drawing.Size(112, 23);
			this.btnEditProfileFields.TabIndex = 52;
			this.btnEditProfileFields.Text = "Edit Profile Fields...";
			this.btnEditProfileFields.Click += new System.EventHandler(this.btnEditProfileFields_Click);
			// 
			// chkBindProfile
			// 
			this.chkBindProfile.Location = new System.Drawing.Point(112, 175);
			this.chkBindProfile.Name = "chkBindProfile";
			this.chkBindProfile.TabIndex = 62;
			this.chkBindProfile.Text = "Bind Profile";
			// 
			// FormDeleteTrackUI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(354, 375);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkBindProfile,
																		  this.txtMainTable,
																		  this.btnEditProfileFields});
			this.Name = "FormDeleteTrackUI";
			this.Text = "Delete Track";
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
				if(value is DeleteTrack)
					_track = (DeleteTrack)value;
				else
					_track = null;
			}
		}	
	
		protected override void setupTrackValuesToView() 
		{
			base.setupTrackValuesToView();
			chkBindProfile.Checked = _track.bindProfile;
			profileFields = (ArrayList)_track.profileFields.Clone();
		}

		protected override void onDataAccessProviderSet() 
		{
			bool bShouldEnableFields = isMainTableSet() && dataAccessProvider.resolved;

			base.onDataAccessProviderSet();
			btnEditProfileFields.Enabled = bShouldEnableFields;
		}

		private bool isMainTableSet() 
		{
			return txtMainTable.Text != "";
		}

		protected override void onMainTableSet() 
		{
			base.onMainTableSet();
			btnEditProfileFields.Enabled = dataAccessProvider.resolved;
		}

		protected override void onMainTableReset() 
		{
			base.onMainTableReset();
			profileFields.Clear();
		}

		protected override void saveViewToTrackValues() 
		{
			base.saveViewToTrackValues();
			_track.bindProfile = chkBindProfile.Checked;
			_track.profileFields.Clear();
			_track.profileFields.AddRange(profileFields);
		}

		private void btnEditProfileFields_Click(object sender, System.EventArgs e)
		{
			FormFieldsView fieldsView = new FormFieldsView();

			fieldsView.allowReferencingFields = false;
			fieldsView.dataAccessProvider = dataAccessProvider;
			fieldsView.fieldsMainTableName = txtMainTable.Text;
			fieldsView.fieldsList = profileFields;
			fieldsView.ShowDialog(this);			
		}


	}
}

