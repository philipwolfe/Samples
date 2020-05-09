using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XSLQueryBuilderApp
{
	/// <summary>
	/// Summary description for FormPreferences.
	/// </summary>
	public class FormPreferences : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblEncoding;
		private System.Windows.Forms.TextBox txtEncoding;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.TextBox txtTemplatesLibPath;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormPreferences()
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
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.lblEncoding = new System.Windows.Forms.Label();
			this.txtEncoding = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.txtTemplatesLibPath = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(40, 208);
			this.btnOK.Name = "btnOK";
			this.btnOK.Size = new System.Drawing.Size(80, 24);
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(168, 208);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.Size = new System.Drawing.Size(80, 24);
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// lblEncoding
			// 
			this.lblEncoding.Location = new System.Drawing.Point(24, 56);
			this.lblEncoding.Name = "lblEncoding";
			this.lblEncoding.Size = new System.Drawing.Size(64, 16);
			this.lblEncoding.TabIndex = 2;
			this.lblEncoding.Text = "Encoding :";
			// 
			// txtEncoding
			// 
			this.txtEncoding.Location = new System.Drawing.Point(96, 56);
			this.txtEncoding.Name = "txtEncoding";
			this.txtEncoding.Size = new System.Drawing.Size(152, 20);
			this.txtEncoding.TabIndex = 3;
			this.txtEncoding.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 104);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 16);
			this.label1.TabIndex = 4;
			this.label1.Text = "Templates Library Path:";
			// 
			// txtTemplatesLibPath
			// 
			this.txtTemplatesLibPath.Location = new System.Drawing.Point(32, 128);
			this.txtTemplatesLibPath.Name = "txtTemplatesLibPath";
			this.txtTemplatesLibPath.Size = new System.Drawing.Size(224, 20);
			this.txtTemplatesLibPath.TabIndex = 5;
			this.txtTemplatesLibPath.Text = "";
			// 
			// FormPreferences
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(292, 266);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtTemplatesLibPath,
																		  this.label1,
																		  this.txtEncoding,
																		  this.lblEncoding,
																		  this.btnCancel,
																		  this.btnOK});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormPreferences";
			this.ShowInTaskbar = false;
			this.Text = "Preferences";
			this.Load += new System.EventHandler(this.FormPreferences_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormPreferences_Load(object sender, System.EventArgs e)
		{
			PreferencesStorage storage = PreferencesStorage.getStorage();

			txtEncoding.Text = storage.encoding;
			txtTemplatesLibPath.Text = storage.templatesLibraryPath;
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			PreferencesStorage storage = PreferencesStorage.getStorage();

			storage.encoding = txtEncoding.Text;
			storage.templatesLibraryPath = txtTemplatesLibPath.Text;

			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}
	}
}
