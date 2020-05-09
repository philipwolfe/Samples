using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XSLQueryBuilderApp
{
	/// <summary>
	/// Summary description for FormReturnParamView.
	/// </summary>
	public class FormReturnParamView : System.Windows.Forms.Form
	{

		public CommandParam viewedParam;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Label lblName;
		private System.Windows.Forms.ComboBox cmbType;
		private System.Windows.Forms.Label lblType;
		private System.Windows.Forms.Label lblSize;
		private System.Windows.Forms.TextBox txtSize;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.RadioButton radNoReturn;
		private System.Windows.Forms.RadioButton radReturn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormReturnParamView()
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
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnOK = new System.Windows.Forms.Button();
			this.txtName = new System.Windows.Forms.TextBox();
			this.lblName = new System.Windows.Forms.Label();
			this.cmbType = new System.Windows.Forms.ComboBox();
			this.lblType = new System.Windows.Forms.Label();
			this.lblSize = new System.Windows.Forms.Label();
			this.txtSize = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.radReturn = new System.Windows.Forms.RadioButton();
			this.radNoReturn = new System.Windows.Forms.RadioButton();
			this.groupBox1.SuspendLayout();
			this.SuspendLayout();
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(232, 296);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 22;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(32, 296);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 21;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(152, 128);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(152, 20);
			this.txtName.TabIndex = 20;
			this.txtName.Text = "";
			// 
			// lblName
			// 
			this.lblName.Location = new System.Drawing.Point(112, 128);
			this.lblName.Name = "lblName";
			this.lblName.Size = new System.Drawing.Size(48, 23);
			this.lblName.TabIndex = 16;
			this.lblName.Text = "Name :";
			// 
			// cmbType
			// 
			this.cmbType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cmbType.Items.AddRange(new object[] {
														 "varChar",
														 "integer",
														 "double",
														 "recordSet"});
			this.cmbType.Location = new System.Drawing.Point(152, 168);
			this.cmbType.Name = "cmbType";
			this.cmbType.Size = new System.Drawing.Size(152, 21);
			this.cmbType.TabIndex = 15;
			this.cmbType.SelectedIndexChanged += new System.EventHandler(this.cmbType_SelectedIndexChanged);
			// 
			// lblType
			// 
			this.lblType.Location = new System.Drawing.Point(112, 168);
			this.lblType.Name = "lblType";
			this.lblType.Size = new System.Drawing.Size(40, 23);
			this.lblType.TabIndex = 14;
			this.lblType.Text = "Type :";
			// 
			// lblSize
			// 
			this.lblSize.Location = new System.Drawing.Point(120, 208);
			this.lblSize.Name = "lblSize";
			this.lblSize.Size = new System.Drawing.Size(40, 24);
			this.lblSize.TabIndex = 24;
			this.lblSize.Text = "Size :";
			// 
			// txtSize
			// 
			this.txtSize.Location = new System.Drawing.Point(152, 208);
			this.txtSize.Name = "txtSize";
			this.txtSize.ReadOnly = true;
			this.txtSize.Size = new System.Drawing.Size(80, 20);
			this.txtSize.TabIndex = 25;
			this.txtSize.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					this.radReturn,
																					this.radNoReturn});
			this.groupBox1.Location = new System.Drawing.Point(8, 8);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(360, 248);
			this.groupBox1.TabIndex = 26;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Return Parameter";
			// 
			// radReturn
			// 
			this.radReturn.Location = new System.Drawing.Point(32, 80);
			this.radReturn.Name = "radReturn";
			this.radReturn.Size = new System.Drawing.Size(168, 24);
			this.radReturn.TabIndex = 1;
			this.radReturn.Text = "Return Parameter Exists :";
			this.radReturn.Click += new System.EventHandler(this.radReturn_Click);
			// 
			// radNoReturn
			// 
			this.radNoReturn.Checked = true;
			this.radNoReturn.Location = new System.Drawing.Point(32, 32);
			this.radNoReturn.Name = "radNoReturn";
			this.radNoReturn.Size = new System.Drawing.Size(168, 24);
			this.radNoReturn.TabIndex = 0;
			this.radNoReturn.TabStop = true;
			this.radNoReturn.Text = "No Return Parameter";
			this.radNoReturn.Click += new System.EventHandler(this.radNoReturn_Click);
			// 
			// FormReturnParamView
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(386, 344);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtSize,
																		  this.lblSize,
																		  this.btnCancel,
																		  this.btnOK,
																		  this.txtName,
																		  this.lblName,
																		  this.cmbType,
																		  this.lblType,
																		  this.groupBox1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormReturnParamView";
			this.ShowInTaskbar = false;
			this.Text = "Return Parameter";
			this.Load += new System.EventHandler(this.FormReturnParamView_Load);
			this.groupBox1.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormReturnParamView_Load(object sender, System.EventArgs e)
		{
			if(null == viewedParam) 
			{
				txtName.ReadOnly = true;
				cmbType.Enabled = false;
				radNoReturn.Checked = true;
			} else
			{
				txtName.Text = viewedParam.name;
				cmbType.Text = viewedParam.type;
				if("varChar" == viewedParam.type) 
				{
					txtSize.Text = viewedParam.size.ToString();
					txtSize.ReadOnly = false;
				} 
				else
					txtSize.ReadOnly = true;
				radReturn.Checked = true;
			}
		}

		private void cmbType_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			txtSize.ReadOnly = ("varChar" != cmbType.Text);
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			bool closeOK;

			if(radNoReturn.Checked) 
			{
				viewedParam = null;
				closeOK = true;
			} 
			else 
			{
				closeOK = validateViewedFields();
				if(closeOK) 
					saveViewedValues();
			}
			if(closeOK) 
			{
				DialogResult = DialogResult.OK;
				Close();
			}
		}


		private bool validateViewedFields() 
		{
			bool result = false;

			do 
			{
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
				if("varChar" == cmbType.Text && "" == txtSize.Text) 
				{
					MessageBox.Show("When specifying the type \"varChar\" it is also required to specify size (max length of expected string result). please do so and try again");
					continue;
				}

				result = true;
			} while(false);

			return result;
		}

		private void saveViewedValues() 
		{
			if(null == viewedParam)
				viewedParam = new CommandParam();
			viewedParam.name = txtName.Text;
			viewedParam.type = cmbType.Text;
			if("varChar" == cmbType.Text) 
				viewedParam.size = Int32.Parse(txtSize.Text);
		}

		private void radNoReturn_Click(object sender, System.EventArgs e)
		{
			txtName.ReadOnly = true;
			cmbType.Enabled = false;
			txtSize.ReadOnly = true;
		}

		private void radReturn_Click(object sender, System.EventArgs e)
		{
			txtName.ReadOnly = false;
			cmbType.Enabled = true;
			txtSize.ReadOnly = ("varChar" != cmbType.Text);
		}	
	}
}
