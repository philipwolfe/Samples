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
	/// <summary>
	/// Dialog box that creates new users.
	/// </summary>
	public class NewUser : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtName;
		private System.Windows.Forms.TextBox txtEmail;
		private System.Windows.Forms.TextBox txtPhone;
		private System.Windows.Forms.Button OKBtn;
		private System.Windows.Forms.Button cancelButton;
		private System.ComponentModel.Container components = null;

		private System.Data.OleDb.OleDbDataAdapter myDataAdapter;
		private DataSet myDataSet;
		private Hashtable myProps;

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Constructor for adding a new user
		/// </summary>
		/// <param name="personDA"></param>
		/// <param name="personDS"></param>
		////////////////////////////////////////////////////////////
		public NewUser(System.Data.OleDb.OleDbDataAdapter personDA, DataSet personDS, Hashtable props)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			myDataAdapter = personDA;
			myDataSet = personDS;
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
			this.txtEmail = new System.Windows.Forms.TextBox();
			this.txtPhone = new System.Windows.Forms.TextBox();
			this.OKBtn = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
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
			this.label2.Text = "E-mail:";
			this.label2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 72);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(50, 23);
			this.label3.TabIndex = 0;
			this.label3.Text = "Phone:";
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
			// txtEmail
			// 
			this.txtEmail.Location = new System.Drawing.Point(96, 40);
			this.txtEmail.Name = "txtEmail";
			this.txtEmail.Size = new System.Drawing.Size(168, 20);
			this.txtEmail.TabIndex = 2;
			this.txtEmail.Text = "";
			// 
			// txtPhone
			// 
			this.txtPhone.Location = new System.Drawing.Point(96, 72);
			this.txtPhone.Name = "txtPhone";
			this.txtPhone.Size = new System.Drawing.Size(168, 20);
			this.txtPhone.TabIndex = 3;
			this.txtPhone.Text = "";
			// 
			// OKBtn
			// 
			this.OKBtn.Location = new System.Drawing.Point(56, 112);
			this.OKBtn.Name = "OKBtn";
			this.OKBtn.TabIndex = 4;
			this.OKBtn.Text = "OK";
			this.OKBtn.Click += new System.EventHandler(this.OKBtn_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.Location = new System.Drawing.Point(184, 112);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 5;
			this.cancelButton.Text = "Cancel";
			this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
			// 
			// NewUser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(320, 150);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.OKBtn,
																		  this.txtName,
																		  this.label1,
																		  this.label2,
																		  this.label3,
																		  this.txtEmail,
																		  this.txtPhone,
																		  this.cancelButton});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "NewUser";
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "New User";
			this.ResumeLayout(false);

		}
		#endregion

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle Cancel button.  (hide ourselves, do nothing)
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
		/// Handle OK button.
		/// Validate input.
		/// Save to database
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
			dr = myDataSet.Tables["BT_PERSON"].NewRow();
			dr["personOID"] = txtEmail.Text + "-1";
			dr["name"] = txtName.Text;
			dr["email"] = txtEmail.Text;
			dr["phone"] = txtPhone.Text;
			BTExec.getSingleton().exec("add.person",BTXML.rowToXML(dr));
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
