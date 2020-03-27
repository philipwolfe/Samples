using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace OnlineAddressBookCsharpClient
{
	/// <summary>
	/// Summary description for changeWSUrl.
	/// </summary>
	public class changeWSUrl : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox newUrlTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button changeUrlButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		/// 
		public string m_newurl;
		private System.ComponentModel.Container components = null;

		public changeWSUrl(string oldurl)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			m_newurl=oldurl;
			this.newUrlTextBox.Text=oldurl;
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
			this.changeUrlButton = new System.Windows.Forms.Button();
			this.label1 = new System.Windows.Forms.Label();
			this.newUrlTextBox = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// changeUrlButton
			// 
			this.changeUrlButton.Location = new System.Drawing.Point(176, 152);
			this.changeUrlButton.Name = "changeUrlButton";
			this.changeUrlButton.Size = new System.Drawing.Size(96, 32);
			this.changeUrlButton.TabIndex = 3;
			this.changeUrlButton.Text = "Change";
			this.changeUrlButton.Click += new System.EventHandler(this.changeUrlButton_Click);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(24, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(184, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Modify the url if you want to";
			// 
			// newUrlTextBox
			// 
			this.newUrlTextBox.Location = new System.Drawing.Point(136, 108);
			this.newUrlTextBox.Name = "newUrlTextBox";
			this.newUrlTextBox.Size = new System.Drawing.Size(216, 20);
			this.newUrlTextBox.TabIndex = 0;
			this.newUrlTextBox.Text = "";
			// 
			// changeWSUrl
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(432, 237);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.changeUrlButton,
																		  this.label1,
																		  this.newUrlTextBox});
			this.Name = "changeWSUrl";
			this.Text = "changeWSUrl";
			this.ResumeLayout(false);

		}
		#endregion

		private void changeUrlButton_Click(object sender, System.EventArgs e)
		{
			m_newurl=newUrlTextBox.Text;
			this.Close();
		}
	}
}
