using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XSLQueryBuilderApp
{
	public class FormFieldUI : System.Windows.Forms.Form,IFieldUI
	{
		private IField _field;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.Label lblLabel;
		private System.Windows.Forms.TextBox txtLabel;
		private System.ComponentModel.Container components = null;

		public FormFieldUI()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

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
			this.txtLabel = new System.Windows.Forms.TextBox();
			this.lblLabel = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// btnOK
			// 
			this.btnOK.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.btnOK.Location = new System.Drawing.Point(40, 152);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 0;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(176, 152);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// txtLabel
			// 
			this.txtLabel.Location = new System.Drawing.Point(88, 32);
			this.txtLabel.Name = "txtLabel";
			this.txtLabel.Size = new System.Drawing.Size(168, 20);
			this.txtLabel.TabIndex = 2;
			this.txtLabel.Text = "";
			// 
			// lblLabel
			// 
			this.lblLabel.Location = new System.Drawing.Point(48, 32);
			this.lblLabel.Name = "lblLabel";
			this.lblLabel.Size = new System.Drawing.Size(40, 23);
			this.lblLabel.TabIndex = 3;
			this.lblLabel.Text = "label:";
			// 
			// FormFieldUI
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(292, 206);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblLabel,
																		  this.txtLabel,
																		  this.btnCancel,
																		  this.btnOK});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormFieldUI";
			this.ShowInTaskbar = false;
			this.Text = "Simple Field";
			this.Load += new System.EventHandler(this.FormFieldUI_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private void FormFieldUI_Load(object sender, System.EventArgs e)
		{
			setupFieldValuesToView();
		}

		protected virtual void setupFieldValuesToView() 
		{
			if( field!= null ) 
			{
				txtLabel.Text = field.label;
			}
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			if(validateViewValues()) {
				saveViewToFieldValues();
				DialogResult = DialogResult.OK;
				Close();
			}
		}

		protected virtual bool validateViewValues() 
		{
			bool result;

			if("" == txtLabel.Text) 
			{
				MessageBox.Show("Field label is missing, please type one and try again");
				result = false;
			} 
			else 
				result = true;

			return result;
		}

		protected virtual void saveViewToFieldValues() 
		{
			field.label = txtLabel.Text;
		}	

		public virtual IField field
		{
			get 
			{
				return _field;
			}

			set 
			{
				_field = value;
			}
		}
	}
}
