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
using System.Data;

namespace com.mikelehman.bugtracker
{
	////////////////////////////////////////////////////////////
	/// <summary>
	/// Dialog to pick the "active" Release
	/// </summary>
	////////////////////////////////////////////////////////////
	public class BTReleasePicker : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button okBtn;
		private System.Windows.Forms.Button cancelBtn;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private static ArrayList releaseList;
		private static ArrayList releaseNameList;
		private static int selection;
		private System.Windows.Forms.ComboBox cbRelease;

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Pick Release dialog
		/// </summary>
		////////////////////////////////////////////////////////////
		public BTReleasePicker(DataTable releaseDT)
		{
			InitializeComponent();
			selection = -1;
			fillComboBox(releaseDT);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Fiil in the combo box with our string
		/// </summary>
		////////////////////////////////////////////////////////////
		private void fillComboBox(DataTable releaseDT)
		{
			releaseList = new ArrayList();
			releaseNameList = new ArrayList();

			foreach(DataRow dr in releaseDT.Rows)
			{
				releaseList.Add(dr["releaseOID"] as string);
				releaseNameList.Add(dr["name"] as string);
				cbRelease.Items.Add(dr["name"] as string);
			}

			if (releaseList.Count > 0)
				cbRelease.SelectedIndex = 0;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Get the selected item index
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public static string getSelectionOID()
		{
			if (selection == -1)
				return("");
			else
				return(releaseList[selection] as string);
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
			this.cbRelease = new System.Windows.Forms.ComboBox();
			this.okBtn = new System.Windows.Forms.Button();
			this.cancelBtn = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbRelease
			// 
			this.cbRelease.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
			this.cbRelease.Location = new System.Drawing.Point(32, 8);
			this.cbRelease.Name = "cbRelease";
			this.cbRelease.Size = new System.Drawing.Size(234, 21);
			this.cbRelease.TabIndex = 0;
			this.cbRelease.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.cbRelease_KeyPress);
			// 
			// okBtn
			// 
			this.okBtn.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okBtn.Location = new System.Drawing.Point(32, 48);
			this.okBtn.Name = "okBtn";
			this.okBtn.TabIndex = 1;
			this.okBtn.Text = "OK";
			this.okBtn.Click += new System.EventHandler(this.okBtn_Click);
			// 
			// cancelBtn
			// 
			this.cancelBtn.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelBtn.Location = new System.Drawing.Point(191, 48);
			this.cancelBtn.Name = "cancelBtn";
			this.cancelBtn.TabIndex = 1;
			this.cancelBtn.Text = "Cancel";
			this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
			// 
			// BTReleasePicker
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 77);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.okBtn,
																		  this.cbRelease,
																		  this.cancelBtn});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BTReleasePicker";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Move Bug to what Release?";
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
		/// Handle OK button, selection  = cbRelease.selectionValue, exit
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void okBtn_Click(object sender, System.EventArgs e)
		{
			selection = cbRelease.SelectedIndex;
			this.Hide();
		}

		private void cbRelease_KeyPress(object sender, System.Windows.Forms.KeyPressEventArgs e)
		{
			if (e.KeyChar == '\x0d')
				okBtn_Click(null,null);
		}

	}
}
