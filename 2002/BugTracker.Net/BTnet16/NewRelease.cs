////////////////////////////////////////////////////////////
///
/// This code is copyright (c) 2002, by Michael G. Lehman
/// It may be used for no charge for non-commerical purposes
/// including education and training uses.
/// 
/// For commercial distribution or licensing please contact
/// http://www.mikelehman.com
/// 
/// I provide software development and consulting services
/// and am always looking for new clients.
/// 
////////////////////////////////////////////////////////////
using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;


namespace com.mikelehman.bugtracker
{
	////////////////////////////////////////////////////////////
	/// <summary>
	/// Dialog box that gathers information about a new RELEASE
	/// and saves it to the database
	/// </summary>
	////////////////////////////////////////////////////////////
	public class NewRelease : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button cancelButton;
		private System.ComponentModel.Container components = null;

		private System.Data.OleDb.OleDbDataAdapter myDataAdapter;
		private DataSet myDataSet;
		private System.Windows.Forms.TextBox txtVersion;
		private System.Windows.Forms.TextBox txtDescription;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.DateTimePicker dtpDeadline;
		private Hashtable myProps;

		////////////////////////////////////////////////////////////
		/// <summary>
		/// 
		/// </summary>
		/// <param name="personDA"></param>
		/// <param name="personDS"></param>
		////////////////////////////////////////////////////////////
		public NewRelease(System.Data.OleDb.OleDbDataAdapter releaseDA, DataSet releaseDS, Hashtable props)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			myDataAdapter = releaseDA;
			myDataSet = releaseDS;
			myProps = props;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		////////////////////////////////////////////////////////////
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
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.txtName = new System.Windows.Forms.TextBox();
			this.txtVersion = new System.Windows.Forms.TextBox();
			this.txtDescription = new System.Windows.Forms.TextBox();
			this.OKBtn = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.label4 = new System.Windows.Forms.Label();
			this.dtpDeadline = new System.Windows.Forms.DateTimePicker();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(50, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Name:";
			this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 40);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(50, 23);
			this.label2.TabIndex = 0;
			this.label2.Text = "Version:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(16, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(64, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Description:";
			this.label3.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// txtName
			// 
			this.txtName.Location = new System.Drawing.Point(96, 8);
			this.txtName.Name = "txtName";
			this.txtName.Size = new System.Drawing.Size(168, 20);
			this.txtName.TabIndex = 1;
			this.txtName.Text = "";
			// 
			// txtVersion
			// 
			this.txtVersion.Location = new System.Drawing.Point(96, 40);
			this.txtVersion.Name = "txtVersion";
			this.txtVersion.Size = new System.Drawing.Size(168, 20);
			this.txtVersion.TabIndex = 2;
			this.txtVersion.Text = "";
			// 
			// txtDescription
			// 
			this.txtDescription.Location = new System.Drawing.Point(96, 72);
			this.txtDescription.Name = "txtDescription";
			this.txtDescription.Size = new System.Drawing.Size(352, 20);
			this.txtDescription.TabIndex = 3;
			this.txtDescription.Text = "";
			// 
			// OKBtn
			// 
			this.OKBtn.Location = new System.Drawing.Point(144, 144);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.TabIndex = 4;
			this.OKBtn.Text = "OK";
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(272, 144);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 6;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(16, 104);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 23);
			this.label4.TabIndex = 0;
			this.label4.Text = "Deadline:";
			this.label4.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// dtpDeadline
			// 
			this.dtpDeadline.Location = new System.Drawing.Point(96, 104);
			this.dtpDeadline.Name = "dtpDeadline";
			this.dtpDeadline.TabIndex = 4;
			// 
			// NewRelease
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(480, 174);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.dtpDeadline,
																		  this.OKBtn,
																		  this.txtName,
																		  this.label1,
																		  this.label2,
																		  this.label3,
																		  this.txtVersion,
																		  this.txtDescription,
																		  this.cancelButton,
																		  this.label4});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewRelease";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New Release";
			this.ResumeLayout(false);

		}
		#endregion

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle the cancel button (hide ourselves, do nothing
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void CancelButton_Click(object sender, System.EventArgs e)
		{
			this.Hide();		
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle the OK button.
		/// Validate input and save to database
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void OKBtn_Click(object sender, System.EventArgs e)
		{
			DataRow dr;

			if (txtName.Text == "")
			{
				MessageBox.Show("You must supply a name");
				return;
			}
			dr = myDataSet.Tables["BT_RELEASE"].NewRow();
			dr["releaseOID"] = myProps["RELEASEPFX"] + DateTime.Now.Ticks.ToString();
			dr["name"] = txtName.Text;
			dr["version"] = txtVersion.Text;
			dr["description"] = txtDescription.Text;
			dr["deadlineTimestamp"] = this.dtpDeadline.Value;
			dr["creationTimestamp"] = DateTime.Now;
			dr["extra1"] = "OPEN";
			BTExec.getSingleton().exec("add.release",BTXML.rowToXML(dr));
			this.Hide();
		}
	}
}
////////////////////////////////////////////////////////////
///
/// This code is copyright (c) 2002, by Michael G. Lehman
/// It may be used for no charge for non-commerical purposes
/// including education and training uses.
/// 
/// For commercial distribution or licensing please contact
/// http://www.mikelehman.com
/// 
/// I provide software development and consulting services
/// and am always looking for new clients.
/// 
////////////////////////////////////////////////////////////
