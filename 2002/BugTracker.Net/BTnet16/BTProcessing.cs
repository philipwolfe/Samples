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
	/// Progress dialog for imports
	/// </summary>
	////////////////////////////////////////////////////////////
	public class BTProcessing : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label txtProgress;
		private System.ComponentModel.Container components = null;

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Dialog constructor
		/// </summary>
		////////////////////////////////////////////////////////////
		public BTProcessing()
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
			this.txtProgress = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// txtProgress
			// 
			this.txtProgress.ForeColor = System.Drawing.Color.Firebrick;
			this.txtProgress.Location = new System.Drawing.Point(48, 16);
			this.txtProgress.Name = "txtProgress";
			this.txtProgress.Size = new System.Drawing.Size(232, 23);
			this.txtProgress.TabIndex = 0;
			// 
			// BTProcessing
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(328, 54);
			this.ControlBox = false;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.txtProgress});
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.Name = "BTProcessing";
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Importing...";
			this.TopMost = true;
			this.ResumeLayout(false);

		}
		#endregion

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Set the status string in the dialog
		/// </summary>
		/// <param name="s"></param>
		////////////////////////////////////////////////////////////
		public void setStatus(string s)
		{
			txtProgress.Text = s;
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
