using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace XSLQueryBuilderApp
{
	public class FormSPTrackUI : XSLQueryBuilderApp.FormTrackUI
	{

		private StoredProcedureTrack _track;
		private ArrayList inputParams;
		private CommandParam returnParam;
		private System.Windows.Forms.Label lblSPName;
		private System.Windows.Forms.TextBox txtSPName;
		private System.Windows.Forms.Label lblReturnParameter;
		private System.Windows.Forms.TextBox txtReturnParameter;
		private System.Windows.Forms.Button btnSetReturn;
		private System.Windows.Forms.Button btnParameters;
		private System.Windows.Forms.GroupBox grpWriting;
		private System.Windows.Forms.RadioButton radRetrieve;
		private System.Windows.Forms.RadioButton radModify;
		private System.ComponentModel.IContainer components = null;

		public FormSPTrackUI()
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
			this.lblSPName = new System.Windows.Forms.Label();
			this.txtSPName = new System.Windows.Forms.TextBox();
			this.lblReturnParameter = new System.Windows.Forms.Label();
			this.txtReturnParameter = new System.Windows.Forms.TextBox();
			this.btnSetReturn = new System.Windows.Forms.Button();
			this.btnParameters = new System.Windows.Forms.Button();
			this.grpWriting = new System.Windows.Forms.GroupBox();
			this.radModify = new System.Windows.Forms.RadioButton();
			this.radRetrieve = new System.Windows.Forms.RadioButton();
			this.grpWriting.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblSPName
			// 
			this.lblSPName.Location = new System.Drawing.Point(8, 96);
			this.lblSPName.Name = "lblSPName";
			this.lblSPName.Size = new System.Drawing.Size(136, 23);
			this.lblSPName.TabIndex = 50;
			this.lblSPName.Text = "Stored Procedure Name :";
			// 
			// txtSPName
			// 
			this.txtSPName.Location = new System.Drawing.Point(136, 96);
			this.txtSPName.Name = "txtSPName";
			this.txtSPName.Size = new System.Drawing.Size(192, 20);
			this.txtSPName.TabIndex = 51;
			this.txtSPName.Text = "";
			// 
			// lblReturnParameter
			// 
			this.lblReturnParameter.Location = new System.Drawing.Point(8, 137);
			this.lblReturnParameter.Name = "lblReturnParameter";
			this.lblReturnParameter.Size = new System.Drawing.Size(104, 24);
			this.lblReturnParameter.TabIndex = 52;
			this.lblReturnParameter.Text = "Return Parameter :";
			// 
			// txtReturnParameter
			// 
			this.txtReturnParameter.Enabled = false;
			this.txtReturnParameter.Location = new System.Drawing.Point(112, 136);
			this.txtReturnParameter.Name = "txtReturnParameter";
			this.txtReturnParameter.ReadOnly = true;
			this.txtReturnParameter.Size = new System.Drawing.Size(152, 20);
			this.txtReturnParameter.TabIndex = 53;
			this.txtReturnParameter.Text = "";
			// 
			// btnSetReturn
			// 
			this.btnSetReturn.Location = new System.Drawing.Point(272, 135);
			this.btnSetReturn.Name = "btnSetReturn";
			this.btnSetReturn.Size = new System.Drawing.Size(64, 23);
			this.btnSetReturn.TabIndex = 54;
			this.btnSetReturn.Text = "Set...";
			this.btnSetReturn.Click += new System.EventHandler(this.btnSetReturn_Click);
			// 
			// btnParameters
			// 
			this.btnParameters.Location = new System.Drawing.Point(11, 184);
			this.btnParameters.Name = "btnParameters";
			this.btnParameters.Size = new System.Drawing.Size(104, 23);
			this.btnParameters.TabIndex = 55;
			this.btnParameters.Text = "Parameters...";
			this.btnParameters.Click += new System.EventHandler(this.btnParameters_Click);
			// 
			// grpWriting
			// 
			this.grpWriting.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.radModify,
																					 this.radRetrieve});
			this.grpWriting.Location = new System.Drawing.Point(144, 168);
			this.grpWriting.Name = "grpWriting";
			this.grpWriting.Size = new System.Drawing.Size(168, 56);
			this.grpWriting.TabIndex = 56;
			this.grpWriting.TabStop = false;
			this.grpWriting.Text = "Writing Style";
			// 
			// radModify
			// 
			this.radModify.Checked = true;
			this.radModify.Location = new System.Drawing.Point(16, 24);
			this.radModify.Name = "radModify";
			this.radModify.Size = new System.Drawing.Size(64, 24);
			this.radModify.TabIndex = 1;
			this.radModify.TabStop = true;
			this.radModify.Text = "Modify";
			// 
			// radRetrieve
			// 
			this.radRetrieve.Location = new System.Drawing.Point(88, 24);
			this.radRetrieve.Name = "radRetrieve";
			this.radRetrieve.Size = new System.Drawing.Size(72, 24);
			this.radRetrieve.TabIndex = 0;
			this.radRetrieve.Text = "Retrieve";
			// 
			// FormSPTrackUI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(354, 375);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.grpWriting,
																		  this.btnParameters,
																		  this.btnSetReturn,
																		  this.txtReturnParameter,
																		  this.lblReturnParameter,
																		  this.txtSPName,
																		  this.lblSPName});
			this.Name = "FormSPTrackUI";
			this.Text = "Stored Procedure Track";
			this.grpWriting.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		public override  ITrack track 
		{
			get 
			{
				return _track;
			}
			set 
			{
				if(value is StoredProcedureTrack)
					_track = (StoredProcedureTrack)value;
				else
					_track = null;
			}
		}	

		protected override void setupTrackValuesToView() 
		{
			base.setupTrackValuesToView();
			txtSPName.Text = _track.text;
			if(_track.retrieveMode) 
				radRetrieve.Checked = true;
			else
				radModify.Checked = true;
			inputParams = (ArrayList)_track.inputParams.Clone();
			if(_track.returnParam != null) 
			{
				returnParam = new CommandParam(_track.returnParam);
				txtReturnParameter.Text = returnParam.type;
			}
		}

		private void btnSetReturn_Click(object sender, System.EventArgs e)
		{
			FormReturnParamView returnParamView = new FormReturnParamView();

			returnParamView.viewedParam = returnParam;
			if(DialogResult.OK == returnParamView.ShowDialog(this)) 
			{
				returnParam = returnParamView.viewedParam;
				if(returnParam != null)
					txtReturnParameter.Text = returnParam.type;
			}
		}

		private void btnParameters_Click(object sender, System.EventArgs e)
		{
			FormInputParamsView inputParamsView = new FormInputParamsView();

			inputParamsView.viewedParams = inputParams;
			inputParamsView.ShowDialog(this);
		}

		protected override bool validateTrackDisplayContent() 
		{
			bool result = base.validateTrackDisplayContent();

			if(result) 
			{
				if("" == txtSPName.Text) 
				{
					MessageBox.Show("The Stored Procedure/Function name should be specified. Pleaze specify such and try again");
					result = false;
				} 
				else
					result = true;
			}

			return result;
		}

		protected override void saveViewToTrackValues() 
		{
			base.saveViewToTrackValues();
			_track.inputParams.Clear();
			_track.inputParams.AddRange(inputParams);
			_track.returnParam = returnParam;
			_track.text = txtSPName.Text;
			_track.retrieveMode = radRetrieve.Checked;
		}
	}
}

