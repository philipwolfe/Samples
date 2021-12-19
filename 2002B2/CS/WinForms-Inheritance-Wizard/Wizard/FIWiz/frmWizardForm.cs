using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace FIWiz
{
	/// <summary>
	/// Summary description for frmWizardForm.
	/// </summary>
	public class frmWizardForm : System.Windows.Forms.Form
	{
		protected System.Windows.Forms.Button btnCancel;
		protected System.Windows.Forms.Button btnBack;
		protected System.Windows.Forms.Button btnFinish;
		protected System.Windows.Forms.Button btnNext;

		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public frmWizardForm()
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
		public override void Dispose()
		{
			if(components != null)
			{
				components.Dispose();
			}
			base.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnBack = new System.Windows.Forms.Button();
			this.btnNext = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.btnFinish = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// btnBack
			// 
			this.btnBack.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnBack.Location = new System.Drawing.Point(120, 232);
			this.btnBack.Name = "btnBack";
			this.btnBack.TabIndex = 2;
			this.btnBack.Text = "<< Back";
			this.btnBack.Click += new System.EventHandler(this.btnBack_Click);
			// 
			// btnNext
			// 
			this.btnNext.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnNext.Location = new System.Drawing.Point(196, 232);
			this.btnNext.Name = "btnNext";
			this.btnNext.TabIndex = 4;
			this.btnNext.Text = "Next >>";
			this.btnNext.Click += new System.EventHandler(this.btnNext_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnCancel.Location = new System.Drawing.Point(36, 232);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 1;
			this.btnCancel.Text = "Cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// btnFinish
			// 
			this.btnFinish.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
			this.btnFinish.Location = new System.Drawing.Point(280, 232);
			this.btnFinish.Name = "btnFinish";
			this.btnFinish.TabIndex = 3;
			this.btnFinish.Text = "Finish";
			this.btnFinish.Click += new System.EventHandler(this.btnFinish_Click);
			// 
			// frmWizardForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(376, 273);
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnCancel,
																		  this.btnBack,
																		  this.btnFinish,
																		  this.btnNext});
			this.Name = "frmWizardForm";
			this.Text = "frmWizardForm";
			this.ResumeLayout(false);

		}
		#endregion
		[STAThread]
		static void Main() 
		{
			Application.Run(new frmWizardForm());
		}

		protected virtual void btnCancel_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		protected virtual void btnBack_Click(object sender, System.EventArgs e)
		{

		}

		protected virtual void btnNext_Click(object sender, System.EventArgs e)
		{

		}

		protected virtual void btnFinish_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

	}
}
