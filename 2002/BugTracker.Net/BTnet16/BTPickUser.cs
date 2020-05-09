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
using System.IO;

namespace com.mikelehman.bugtracker
{
	////////////////////////////////////////////////////////////
	/// <summary>
	/// Dialog to pick the "active" user
	/// </summary>
	////////////////////////////////////////////////////////////
	public class BTPickUser : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ComboBox cbUser;
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button cancelBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private static ArrayList userList;
		private System.Windows.Forms.CheckBox cbRemember;
		private static int selection;
		private static bool remember;

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Pick user dialog
		/// </summary>
		////////////////////////////////////////////////////////////
		public BTPickUser()
		{
			InitializeComponent();
			selection = -1;
			remember = false;
			fillComboBox();
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Fiil in the combo box with our string
		/// </summary>
		////////////////////////////////////////////////////////////
		private void fillComboBox()
		{
			foreach(string s in userList)
			{
				cbUser.Items.Add(s);
			}
			if (userList.Count > 0)
				cbUser.SelectedIndex = 1;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Set the list of users we should display
		/// </summary>
		/// <param name="uList"></param>
		////////////////////////////////////////////////////////////
		public static void setUserList(ArrayList uList)
		{
			userList = uList;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Get the selected item index
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public static int getSelection()
		{
			return(selection);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Accessor for static "REMEMBER" flag
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public static bool getRemember()
		{
			return(remember);
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
			this.cbUser = new System.Windows.Forms.ComboBox();
			this.okBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.cbRemember = new System.Windows.Forms.CheckBox();
			this.SuspendLayout();
			// 
			// cbUser
			// 
			this.cbUser.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbUser.Location = new System.Drawing.Point(32, 8);
			this.cbUser.Name = "cbUser";
			this.cbUser.Size = new System.Drawing.Size(234, 21);
			this.cbUser.TabIndex = 0;
			this.cbUser.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbUser_KeyPress);
			// 
			// okBtn
			// 
			this.okBtn.Location = new System.Drawing.Point(32, 64);
			this.okBtn.Name = "okBtn";
			this.okBtn.TabIndex = 1;
			this.okBtn.Text = "OK";
			this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.Location = new System.Drawing.Point(191, 64);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.TabIndex = 1;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// cbRemember
			// 
			this.cbRemember.Location = new System.Drawing.Point(77, 40);
			this.cbRemember.Name = "cbRemember";
			this.cbRemember.Size = new System.Drawing.Size(138, 24);
			this.cbRemember.TabIndex = 2;
			this.cbRemember.Text = "Remember my choice";
			// 
			// BTPickUser
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 93);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cbRemember,
																		  this.okBtn,
																		  this.cbUser,
																		  this.cancelBtn});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BTPickUser";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Select Active User...";
			this.ResumeLayout(false);

		}
		#endregion

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle cancel button, selection= null, exit
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void cancelBtn_Click(object sender, System.EventArgs e)
		{
			selection = -1;
			this.Hide();
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle OK button, selection  = cbUser.selectionValue, exit
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void okBtn_Click(object sender, System.EventArgs e)
		{
			selection = cbUser.SelectedIndex;
			remember = cbRemember.Checked;
			this.Hide();
		}

		private void cbUser_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == '\x0d')
				okBtn_Click(null,null);
		}

	}
}
