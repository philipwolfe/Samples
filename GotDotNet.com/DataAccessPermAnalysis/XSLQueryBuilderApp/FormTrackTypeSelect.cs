using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace XSLQueryBuilderApp
{
	/// <summary>
	/// Summary description for FormTrackTypeSelect.
	/// </summary>
	public class FormTrackTypeSelect : System.Windows.Forms.Form
	{
		private string _resultTrackType;

		private System.Windows.Forms.Panel pnlTrackTypes;
		private System.Windows.Forms.Button btnOK;
		private System.Windows.Forms.Button btnCancel;
		private System.Windows.Forms.RadioButton radRetrieve;
		private System.Windows.Forms.RadioButton radInsert;
		private System.Windows.Forms.RadioButton radDelete;
		private System.Windows.Forms.RadioButton radUpdate;
		private System.Windows.Forms.RadioButton radSP;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public FormTrackTypeSelect()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			_resultTrackType = "RetrieveTrack";
		}


		public string resultTrackType 
		{
			get 
			{
				return _resultTrackType;
			}
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
			this.pnlTrackTypes = new System.Windows.Forms.Panel();
			this.radSP = new System.Windows.Forms.RadioButton();
			this.radUpdate = new System.Windows.Forms.RadioButton();
			this.radDelete = new System.Windows.Forms.RadioButton();
			this.radInsert = new System.Windows.Forms.RadioButton();
			this.radRetrieve = new System.Windows.Forms.RadioButton();
			this.btnOK = new System.Windows.Forms.Button();
			this.btnCancel = new System.Windows.Forms.Button();
			this.pnlTrackTypes.SuspendLayout();
			this.SuspendLayout();
			// 
			// pnlTrackTypes
			// 
			this.pnlTrackTypes.Controls.AddRange(new System.Windows.Forms.Control[] {
																						this.radSP,
																						this.radUpdate,
																						this.radDelete,
																						this.radInsert,
																						this.radRetrieve});
			this.pnlTrackTypes.Location = new System.Drawing.Point(32, 24);
			this.pnlTrackTypes.Name = "pnlTrackTypes";
			this.pnlTrackTypes.Size = new System.Drawing.Size(248, 160);
			this.pnlTrackTypes.TabIndex = 0;
			// 
			// radSP
			// 
			this.radSP.Location = new System.Drawing.Point(24, 119);
			this.radSP.Name = "radSP";
			this.radSP.Size = new System.Drawing.Size(136, 24);
			this.radSP.TabIndex = 4;
			this.radSP.Tag = "SPTrack";
			this.radSP.Text = "Stored Procedure";
			this.radSP.CheckedChanged += new System.EventHandler(this.radTrackType_CheckedChanged);
			// 
			// radUpdate
			// 
			this.radUpdate.Location = new System.Drawing.Point(120, 72);
			this.radUpdate.Name = "radUpdate";
			this.radUpdate.TabIndex = 3;
			this.radUpdate.Tag = "UpdateTrack";
			this.radUpdate.Text = "Update";
			this.radUpdate.CheckedChanged += new System.EventHandler(this.radTrackType_CheckedChanged);
			// 
			// radDelete
			// 
			this.radDelete.Location = new System.Drawing.Point(24, 72);
			this.radDelete.Name = "radDelete";
			this.radDelete.Size = new System.Drawing.Size(64, 24);
			this.radDelete.TabIndex = 2;
			this.radDelete.Tag = "DeleteTrack";
			this.radDelete.Text = "Delete";
			this.radDelete.CheckedChanged += new System.EventHandler(this.radTrackType_CheckedChanged);
			// 
			// radInsert
			// 
			this.radInsert.Location = new System.Drawing.Point(120, 24);
			this.radInsert.Name = "radInsert";
			this.radInsert.Size = new System.Drawing.Size(88, 24);
			this.radInsert.TabIndex = 1;
			this.radInsert.Tag = "InsertTrack";
			this.radInsert.Text = "Insert";
			this.radInsert.CheckedChanged += new System.EventHandler(this.radTrackType_CheckedChanged);
			// 
			// radRetrieve
			// 
			this.radRetrieve.Checked = true;
			this.radRetrieve.Location = new System.Drawing.Point(24, 24);
			this.radRetrieve.Name = "radRetrieve";
			this.radRetrieve.Size = new System.Drawing.Size(72, 24);
			this.radRetrieve.TabIndex = 0;
			this.radRetrieve.TabStop = true;
			this.radRetrieve.Tag = "RetrieveTrack";
			this.radRetrieve.Text = "Retrieve";
			this.radRetrieve.CheckedChanged += new System.EventHandler(this.radTrackType_CheckedChanged);
			// 
			// btnOK
			// 
			this.btnOK.Location = new System.Drawing.Point(48, 208);
			this.btnOK.Name = "btnOK";
			this.btnOK.TabIndex = 1;
			this.btnOK.Text = "OK";
			this.btnOK.Click += new System.EventHandler(this.btnOK_Click);
			// 
			// btnCancel
			// 
			this.btnCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.btnCancel.Location = new System.Drawing.Point(192, 208);
			this.btnCancel.Name = "btnCancel";
			this.btnCancel.TabIndex = 2;
			this.btnCancel.Text = "cancel";
			this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
			// 
			// FormTrackTypeSelect
			// 
			this.AcceptButton = this.btnOK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.btnCancel;
			this.ClientSize = new System.Drawing.Size(314, 255);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnCancel,
																		  this.btnOK,
																		  this.pnlTrackTypes});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
			this.Name = "FormTrackTypeSelect";
			this.ShowInTaskbar = false;
			this.Text = "Select a Track Type";
			this.pnlTrackTypes.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void btnOK_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.OK;
			Close();
		}

		private void btnCancel_Click(object sender, System.EventArgs e)
		{
			DialogResult = DialogResult.Cancel;
			Close();
		}

		private void radTrackType_CheckedChanged(object sender, System.EventArgs e) 
		{
			_resultTrackType = (string)((RadioButton)sender).Tag;
		}

	}
}
