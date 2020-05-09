using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data.OleDb;

using System.Windows.Forms;


namespace XSLQueryBuilderApp
{
	public class FormRetrieveTrackUI : XSLQueryBuilderApp.FormSQLTrackUI
	{
		private const string PK_RETRIEVE_QUERY = 
			@"	SELECT column_name 
				FROM user_cons_columns 
				WHERE constraint_name = 
					(SELECT constraint_name 
					FROM user_constraints 
					WHERE table_name = ?
					AND constraint_type = 'P'
					)
			";
		private RetrieveTrack _track;
		private ArrayList dataFields;
		private ArrayList profileFields;
		private System.Windows.Forms.Button btnEditDataFields;
		private System.Windows.Forms.Button btnEditProfileFields;
		private System.Windows.Forms.CheckBox chkParamRetrieve;
		private System.Windows.Forms.CheckBox chkIntersect;
		private System.Windows.Forms.CheckBox chkNoMerge;
		private System.Windows.Forms.CheckBox chkBindProfile;
		private System.ComponentModel.IContainer components = null;

		public FormRetrieveTrackUI()
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
			this.btnEditProfileFields = new System.Windows.Forms.Button();
			this.chkParamRetrieve = new System.Windows.Forms.CheckBox();
			this.chkIntersect = new System.Windows.Forms.CheckBox();
			this.chkNoMerge = new System.Windows.Forms.CheckBox();
			this.chkBindProfile = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// txtMainTable
			// 
			this.txtMainTable.Visible = true;
			// 
			// btnEditDataFields
			// 
			this.btnEditDataFields.Enabled = false;
			this.btnEditDataFields.Location = new System.Drawing.Point(192, 160);
			this.btnEditDataFields.Name = "btnEditDataFields";
			this.btnEditDataFields.Size = new System.Drawing.Size(112, 23);
			this.btnEditDataFields.TabIndex = 55;
			this.btnEditDataFields.Text = "Edit Data Fields...";
			this.btnEditDataFields.Click += new System.EventHandler(this.btnEditDataFields_Click);
			// 
			// btnEditProfileFields
			// 
			this.btnEditProfileFields.Enabled = false;
			this.btnEditProfileFields.Location = new System.Drawing.Point(48, 160);
			this.btnEditProfileFields.Name = "btnEditProfileFields";
			this.btnEditProfileFields.Size = new System.Drawing.Size(112, 23);
			this.btnEditProfileFields.TabIndex = 54;
			this.btnEditProfileFields.Text = "Edit Profile Fields...";
			this.btnEditProfileFields.Click += new System.EventHandler(this.btnEditProfileFields_Click);
			// 
			// chkParamRetrieve
			// 
			this.chkParamRetrieve.Location = new System.Drawing.Point(8, 264);
			this.chkParamRetrieve.Name = "chkParamRetrieve";
			this.chkParamRetrieve.Size = new System.Drawing.Size(136, 24);
			this.chkParamRetrieve.TabIndex = 56;
			this.chkParamRetrieve.Text = "Parameter Retrieve";
			// 
			// chkIntersect
			// 
			this.chkIntersect.Location = new System.Drawing.Point(144, 264);
			this.chkIntersect.Name = "chkIntersect";
			this.chkIntersect.Size = new System.Drawing.Size(72, 24);
			this.chkIntersect.TabIndex = 57;
			this.chkIntersect.Text = "Intersect";
			// 
			// chkNoMerge
			// 
			this.chkNoMerge.Location = new System.Drawing.Point(224, 264);
			this.chkNoMerge.Name = "chkNoMerge";
			this.chkNoMerge.TabIndex = 58;
			this.chkNoMerge.Text = "No Merge";
			// 
			// chkBindProfile
			// 
			this.chkBindProfile.Location = new System.Drawing.Point(50, 192);
			this.chkBindProfile.Name = "chkBindProfile";
			this.chkBindProfile.TabIndex = 61;
			this.chkBindProfile.Text = "Bind Profile";
			// 
			// FormRetrieveTrackUI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(354, 375);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkBindProfile,
																		  this.chkNoMerge,
																		  this.chkIntersect,
																		  this.chkParamRetrieve,
																		  this.btnEditDataFields,
																		  this.btnEditProfileFields,
																		  this.txtMainTable});
			this.Name = "FormRetrieveTrackUI";
			this.Text = "Retrieve Track";
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
				if(value is RetrieveTrack)
					_track = (RetrieveTrack)value;
				else
					_track = null;
			}
		}	
	
		protected override void setupTrackValuesToView() 
		{
			base.setupTrackValuesToView();
			profileFields = (ArrayList)_track.profileFields.Clone();
			dataFields = (ArrayList)_track.dataFields.Clone();
			chkParamRetrieve.Checked = _track.paramRetrieve;
			chkBindProfile.Checked = _track.bindProfile;
			chkIntersect.Checked = _track.intersect;
			chkNoMerge.Checked = _track.noMerge;
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
			if(_track.mainTable != txtMainTable.Text)
				saveSelectedMainTablePK();
			base.saveViewToTrackValues();
			_track.profileFields.Clear();
			_track.profileFields.AddRange(profileFields);
			_track.dataFields.Clear();
			_track.dataFields.AddRange(dataFields);
			_track.paramRetrieve = chkParamRetrieve.Checked;
			_track.bindProfile = chkBindProfile.Checked;
			_track.intersect = chkIntersect.Checked;
			_track.noMerge = chkNoMerge.Checked;
		}

		private void saveSelectedMainTablePK() 
		{
			OleDbCommand pkRetrieve = new OleDbCommand();
			OleDbParameter tableNameParam = new OleDbParameter("tableName",OleDbType.VarChar);
			OleDbDataReader reader;
		
			_track.mainTablePK.Clear();
			pkRetrieve.Connection = dataAccessProvider.getOpenConnection();
			pkRetrieve.CommandText = PK_RETRIEVE_QUERY;
			tableNameParam.Value = txtMainTable.Text;
			pkRetrieve.Parameters.Add(tableNameParam);
			reader = pkRetrieve.ExecuteReader();
			while(reader.Read()) 
				_track.mainTablePK.Add(reader.GetString(0));

			reader.Close();
		}

		private void btnEditProfileFields_Click(object sender, System.EventArgs e)
		{
			showFieldsEditingDialog(profileFields);		
		}

		private void btnEditDataFields_Click(object sender, System.EventArgs e)
		{
			showFieldsEditingDialog(dataFields);		
		}

		private void showFieldsEditingDialog(ArrayList fields) 
		{
			FormFieldsView fieldsView = new FormFieldsView();

			fieldsView.allowReferencingFields = false;
			fieldsView.dataAccessProvider = dataAccessProvider;
			fieldsView.fieldsMainTableName = txtMainTable.Text;
			fieldsView.fieldsList = fields;
			fieldsView.ShowDialog(this);	
		}
	}
}

