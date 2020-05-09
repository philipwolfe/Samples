using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XSLQueryBuilderApp
{
	/// <summary>
	/// Summary description for FormInputParamView.
	/// </summary>
	public class FormInputParamView : System.Windows.Forms.Form
	{
		public CommandParam viewedParam;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.TextBox txtLabel;
		private System.Windows.Forms.Label lblLabel;
		private System.Windows.Forms.GroupBox grpSection;
		private System.Windows.Forms.RadioButton radData;
		private System.Windows.Forms.RadioButton radProfile;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.Label lblType;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormInputParamView()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
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
			this.lblType = new System.Windows.Forms.Label();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.lblName = new System.Windows.Forms.Label();
			this.txtLabel = new System.Windows.Forms.TextBox();
			this.lblLabel = new System.Windows.Forms.Label();
			this.grpSection = new System.Windows.Forms.GroupBox();
			this.radProfile = new System.Windows.Forms.RadioButton();
			this.radData = new System.Windows.Forms.RadioButton();
			this.txtName = new System.Windows.Forms.TextBox();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.grpSection.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblType
			// 
			this.lblType.Location = new System.Drawing.Point(27, 168);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(40, 23);
			this.lblType.TabIndex = 2;
			this.lblType.Text = "Type :";
			// 
			// cmbType
			// 
			this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbType.Items.AddRange(new object[] {
														 "varChar",
														 "integer",
														 "double"});
			this.cmbType.Location = new System.Drawing.Point(63, 168);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(152, 21);
			this.cmbType.TabIndex = 3;
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(24, 131);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(48, 23);
			this.lblName.TabIndex = 5;
			this.lblName.Text = "Name :";
			// 
			// txtLabel
			// 
			this.txtLabel.Location = new System.Drawing.Point(64, 24);
			this.txtLabel.Name = "txtLabel";
			this.txtLabel.Size = new System.Drawing.Size(152, 20);
			this.txtLabel.TabIndex = 9;
			this.txtLabel.Text = "";
			// 
			// lblLabel
			// 
			this.lblLabel.Location = new System.Drawing.Point(24, 24);
			this.lblLabel.Name = "lblLabel";
			this.lblLabel.Size = new System.Drawing.Size(40, 23);
			this.lblLabel.TabIndex = 8;
			this.lblLabel.Text = "Label :";
			// 
			// grpSection
			// 
			this.grpSection.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.radProfile,
																					 this.radData});
			this.grpSection.Location = new System.Drawing.Point(16, 56);
			this.grpSection.Name = "grpSection";
			this.grpSection.Size = new System.Drawing.Size(224, 64);
			this.grpSection.TabIndex = 10;
			this.grpSection.TabStop = false;
			this.grpSection.Text = "Appear in Section :";
			// 
			// radProfile
			// 
			this.radProfile.Location = new System.Drawing.Point(136, 24);
			this.radProfile.Name = "radProfile";
			this.radProfile.Size = new System.Drawing.Size(56, 24);
			this.radProfile.TabIndex = 1;
			this.radProfile.Text = "Profile";
			// 
			// radData
			// 
			this.radData.Checked = true;
			this.radData.Location = new System.Drawing.Point(40, 24);
			this.radData.Name = "radData";
			this.radData.Size = new System.Drawing.Size(64, 24);
			this.radData.TabIndex = 0;
			this.radData.TabStop = true;
			this.radData.Text = "Data";
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(64, 131);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(152, 20);
			this.txtName.TabIndex = 11;
			this.txtName.Text = "";
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(32, 224);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 12;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(152, 224);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 13;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FormInputParamView
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(258, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.btnOK,
																		  this.txtName,
																		  this.grpSection,
																		  this.txtLabel,
																		  this.lblLabel,
																		  this.lblName,
																		  this.cmbType,
																		  this.lblType});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormInputParamView";
			this.ShowInTaskbar = false;
			this.Text = "Input Parameter";
			this.Load += new System.EventHandler(this.FormInputParamView_Load);
			this.grpSection.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormInputParamView_Load(object sender, System.EventArgs e)
		{
			if(viewedParam == null)
				viewedParam = new CommandParam();
			displayParamValues();
		}

		private void displayParamValues() 
		{
			txtLabel.Text = viewedParam.label;
			if(viewedParam.appearInData)
				radData.Checked = true;
			else
				radProfile.Checked = true;
			txtName.Text = viewedParam.name;
			cmbType.Text = viewedParam.type;
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(validateViewedFields()) 
			{
				saveViewedValues();
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		private bool validateViewedFields() 
		{
			bool result = false;

			do 
			{
				if("" == txtLabel.Text) 
				{
					MessageBox.Show("Label is missing. Please specify and try again");
					continue;
				}
				if("" == txtName.Text) 
				{
					MessageBox.Show("Name is missing. Please specify and try again");
					continue;
				}
				if("" == cmbType.Text) 
				{
					MessageBox.Show("Type is missing. Please specify and try again");
					continue;
				}
				result = true;
			} while(false);

			return result;
		}

		private void saveViewedValues() 
		{
			viewedParam.label = txtLabel.Text;
			viewedParam.appearInData = radData.Checked;
			viewedParam.name = txtName.Text;
			viewedParam.type = cmbType.Text;
		}
	}
}
