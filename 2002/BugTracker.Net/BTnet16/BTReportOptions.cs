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

namespace com.mikelehman.bugtracker
{
	////////////////////////////////////////////////////////////
	/// <summary>
	/// Get Filter options for bug report
	/// </summary>
	////////////////////////////////////////////////////////////
	public class BTReportOptions : System.Windows.Forms.Form
	{
		private System.Windows.Forms.CheckBox cbOpenBugs;
		private System.Windows.Forms.CheckBox cbClosedBugs;
		private System.Windows.Forms.CheckBox cbLaterBugs;
		private System.Windows.Forms.CheckBox cbOKBugs;
		private System.Windows.Forms.CheckBox cbIgnoreBugs;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button okButton;
		private System.Windows.Forms.Button cancelButton;
		private System.ComponentModel.Container components = null;

		protected static bool doOpenBugs;
		protected static bool doClosedBugs;
		protected static bool doLaterBugs;
		protected static bool doOKBugs;
		protected static bool doIgnoreBugs;


		////////////////////////////////////////////////////////////
		/// <summary>
		/// Return state of flag
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public static bool getDoOpenBugs()
		{
			return(doOpenBugs);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Return state of flag
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public static bool getDoClosedBugs()
		{
			return(doClosedBugs);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Return state of flag
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public static bool getDoLaterBugs()
		{
			return(doLaterBugs);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Return state of flag
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public static bool getDoOKBugs()
		{
			return(doOKBugs);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Return state of flag
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public static bool getDoIgnoreBugs()
		{
			return(doIgnoreBugs);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Default constructor
		/// </summary>
		////////////////////////////////////////////////////////////
		public BTReportOptions()
		{
			InitializeComponent();
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
			this.cbOpenBugs = new System.Windows.Forms.CheckBox();
			this.cbClosedBugs = new System.Windows.Forms.CheckBox();
			this.cbLaterBugs = new System.Windows.Forms.CheckBox();
			this.cbOKBugs = new System.Windows.Forms.CheckBox();
			this.cbIgnoreBugs = new System.Windows.Forms.CheckBox();
			this.label1 = new System.Windows.Forms.Label();
			this.okButton = new System.Windows.Forms.Button();
			this.cancelButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// cbOpenBugs
			// 
			this.cbOpenBugs.Checked = true;
			this.cbOpenBugs.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbOpenBugs.Location = new System.Drawing.Point(58, 42);
			this.cbOpenBugs.Name = "cbOpenBugs";
			this.cbOpenBugs.Size = new System.Drawing.Size(176, 24);
			this.cbOpenBugs.TabIndex = 0;
			this.cbOpenBugs.Text = "Show &OPEN Bugs";
			this.cbOpenBugs.CheckedChanged += new System.EventHandler(this.cbChanged);
			// 
			// cbClosedBugs
			// 
			this.cbClosedBugs.Location = new System.Drawing.Point(58, 74);
			this.cbClosedBugs.Name = "cbClosedBugs";
			this.cbClosedBugs.Size = new System.Drawing.Size(176, 24);
			this.cbClosedBugs.TabIndex = 0;
			this.cbClosedBugs.Text = "Show &CLOSED Bugs";
			// 
			// cbLaterBugs
			// 
			this.cbLaterBugs.Location = new System.Drawing.Point(58, 106);
			this.cbLaterBugs.Name = "cbLaterBugs";
			this.cbLaterBugs.Size = new System.Drawing.Size(176, 24);
			this.cbLaterBugs.TabIndex = 0;
			this.cbLaterBugs.Text = "Show &LATER Bugs";
			// 
			// cbOKBugs
			// 
			this.cbOKBugs.Checked = true;
			this.cbOKBugs.CheckState = System.Windows.Forms.CheckState.Checked;
			this.cbOKBugs.Location = new System.Drawing.Point(58, 138);
			this.cbOKBugs.Name = "cbOKBugs";
			this.cbOKBugs.Size = new System.Drawing.Size(176, 24);
			this.cbOKBugs.TabIndex = 0;
			this.cbOKBugs.Text = "Show OK To& Fix Bugs";
			// 
			// cbIgnoreBugs
			// 
			this.cbIgnoreBugs.Location = new System.Drawing.Point(58, 170);
			this.cbIgnoreBugs.Name = "cbIgnoreBugs";
			this.cbIgnoreBugs.Size = new System.Drawing.Size(176, 24);
			this.cbIgnoreBugs.TabIndex = 0;
			this.cbIgnoreBugs.Text = "Show &IGNORE Bugs";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(14, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(264, 23);
			this.label1.TabIndex = 1;
			this.label1.Text = "Select the types of bugs to show on the bug report:";
			// 
			// okButton
			// 
			this.okButton.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.okButton.Location = new System.Drawing.Point(32, 208);
			this.okButton.Name = "okButton";
			this.okButton.TabIndex = 2;
			this.okButton.Text = "OK";
			this.okButton.Click += new System.EventHandler(this.okButton_Click);
			// 
			// cancelButton
			// 
			this.cancelButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancelButton.Location = new System.Drawing.Point(184, 208);
			this.cancelButton.Name = "cancelButton";
			this.cancelButton.TabIndex = 3;
			this.cancelButton.Text = "Cancel";
			// 
			// BTReportOptions
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(292, 237);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.cancelButton,
																		  this.okButton,
																		  this.label1,
																		  this.cbOpenBugs,
																		  this.cbClosedBugs,
																		  this.cbLaterBugs,
																		  this.cbOKBugs,
																		  this.cbIgnoreBugs});
			this.Name = "BTReportOptions";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
			this.Text = "Bug Report Options...";
			this.ResumeLayout(false);

		}
		#endregion

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle a click on a checkbox
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void cbChanged(object sender, System.EventArgs e)
		{
			doOpenBugs = this.cbOpenBugs.Checked;
			doClosedBugs = this.cbClosedBugs.Checked;
			doLaterBugs = this.cbLaterBugs.Checked;
			doOKBugs = this.cbOKBugs.Checked;
			doIgnoreBugs = this.cbIgnoreBugs.Checked;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Handle the OK button, get state of checkboxes
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		////////////////////////////////////////////////////////////
		private void okButton_Click(object sender, System.EventArgs e)
		{
			cbChanged(null,null);
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
