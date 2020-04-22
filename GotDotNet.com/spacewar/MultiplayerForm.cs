using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace SpaceWar
{
	/// <summary>
	/// Summary description for MultiplayerForm.
	/// </summary>
	public class MultiplayerForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button ok;
		private System.Windows.Forms.Button cancel;
		public System.Windows.Forms.TextBox hostName;
		private System.Windows.Forms.Label label1;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public MultiplayerForm()
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
			this.hostName = new System.Windows.Forms.TextBox();
			this.ok = new System.Windows.Forms.Button();
			this.cancel = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// hostName
			// 
			this.hostName.Location = new System.Drawing.Point(120, 16);
			this.hostName.Name = "hostName";
			this.hostName.Size = new System.Drawing.Size(128, 20);
			this.hostName.TabIndex = 3;
			this.hostName.Text = "ericgu7";
			// 
			// ok
			// 
			this.ok.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.ok.Location = new System.Drawing.Point(32, 48);
			this.ok.Name = "ok";
			this.ok.TabIndex = 1;
			this.ok.Text = "OK";
			// 
			// cancel
			// 
			this.cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.cancel.Location = new System.Drawing.Point(160, 48);
			this.cancel.Name = "cancel";
			this.cancel.TabIndex = 4;
			this.cancel.Text = "Cancel";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 16);
			this.label1.Name = "label1";
			this.label1.TabIndex = 5;
			this.label1.Text = "Connect To:";
			// 
			// MultiplayerForm
			// 
			this.AcceptButton = this.ok;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.cancel;
			this.ClientSize = new System.Drawing.Size(264, 86);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label1,
																		  this.cancel,
																		  this.ok,
																		  this.hostName});
			this.Name = "MultiplayerForm";
			this.Text = "Multiplayer";
			this.ResumeLayout(false);

		}
		#endregion
	}
}
