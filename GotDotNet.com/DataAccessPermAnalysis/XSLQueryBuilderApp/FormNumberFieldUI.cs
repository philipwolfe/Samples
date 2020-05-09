using System;
using System.Collections;
using System.ComponentModel;
using System.Drawing;

using System.Windows.Forms;


namespace XSLQueryBuilderApp
{
	public class FormNumberFieldUI : FormFieldUI
	{

		private NumberField _field;
		private System.Windows.Forms.CheckBox chkOrdinal;
		private System.ComponentModel.IContainer components = null;

		public FormNumberFieldUI()
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
			this.chkOrdinal = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// chkOrdinal
			// 
			this.chkOrdinal.Location = new System.Drawing.Point(48, 88);
			this.chkOrdinal.Name = "chkOrdinal";
			this.chkOrdinal.TabIndex = 4;
			this.chkOrdinal.Text = "ordinal";
			// 
			// FormNumberFieldUI
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(294, 208);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.chkOrdinal});
			this.Name = "FormNumberFieldUI";
			this.Text = "Number Field";
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
				if(value is NumberField) 
					_field = (NumberField)value;
				else
					_field = null;

			}
		}

		protected override void setupFieldValuesToView() 
		{
			base.setupFieldValuesToView();
			chkOrdinal.Checked = _field.ordinal;
		}

		protected override void saveViewToFieldValues() 
		{
			base.saveViewToFieldValues();
			_field.ordinal = chkOrdinal.Checked;
		}
	}
}

