using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace XSLQueryBuilderApp
{
	public class FormDateFieldUI : XSLQueryBuilderApp.FormFieldUI
	{
		private DateField _field;
		private System.Windows.Forms.Label lblPattern;
		private System.Windows.Forms.TextBox txtPattern;
		private System.ComponentModel.IContainer components = null;

		public FormDateFieldUI()
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
			this.lblPattern = new System.Windows.Forms.Label();
			this.txtPattern = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// lblPattern
			// 
			this.lblPattern.Location = new System.Drawing.Point(11, 72);
			this.lblPattern.Name = "lblPattern";
			this.lblPattern.Size = new System.Drawing.Size(72, 23);
			this.lblPattern.TabIndex = 4;
			this.lblPattern.Text = "date pattern:";
			// 
			// txtPattern
			// 
			this.txtPattern.Location = new System.Drawing.Point(88, 72);
			this.txtPattern.Name = "txtPattern";
			this.txtPattern.Size = new System.Drawing.Size(168, 20);
			this.txtPattern.TabIndex = 5;
			this.txtPattern.Text = "";
			// 
			// FormDateFieldUI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(294, 208);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtPattern,
																		  this.lblPattern});
			this.Name = "FormDateFieldUI";
			this.Text = "Date Field";
			this.ResumeLayout(false);

		}
		#endregion

		public override IField field 
		{
			get 
			{
				return _field;
			}

			set 
			{
				if(value is DateField) 
					_field = (DateField)value;
				else
					_field = null;

			}
		}

		protected override void setupFieldValuesToView() 
		{
			base.setupFieldValuesToView();
			txtPattern.Text = _field.datePattern;
		}

		protected override void saveViewToFieldValues() 
		{
			base.saveViewToFieldValues();
			_field.datePattern = txtPattern.Text;
		}	

		protected override bool validateViewValues() 
		{	
			bool result = base.validateViewValues();

			if(result) 
			{
				if("" == txtPattern.Text) 
				{
					MessageBox.Show("Date Field date pattern is missing, please type a pattern and try again");
					result = false;
				} 
				else 
					result = true;
			}

			return result;
		}
	}
}

