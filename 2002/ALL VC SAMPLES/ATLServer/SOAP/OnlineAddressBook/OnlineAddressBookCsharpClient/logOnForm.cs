using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace OnlineAddressBookCsharpClient
{
	/// <summary>
	/// Summary description for logOnForm.
	/// </summary>
	public class logOnForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox emailTextBox;
		private System.Windows.Forms.TextBox passwordTextBox;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Button logOnButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private OnlineAddressBookServer.OnlineAddressBookWSService m_OAWS;

		public logOnForm(ref OnlineAddressBookServer.OnlineAddressBookWSService OAWS)
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			m_OAWS=OAWS;
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
			this.emailTextBox = new System.Windows.Forms.TextBox();
			this.passwordTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.label2 = new System.Windows.Forms.Label();
			this.logOnButton = new System.Windows.Forms.Button();
			this.SuspendLayout();
			// 
			// emailTextBox
			// 
			this.emailTextBox.Location = new System.Drawing.Point(112, 28);
			this.emailTextBox.Name = "emailTextBox";
			this.emailTextBox.Size = new System.Drawing.Size(136, 20);
			this.emailTextBox.TabIndex = 0;
			this.emailTextBox.Text = "";
			// 
			// passwordTextBox
			// 
			this.passwordTextBox.Location = new System.Drawing.Point(112, 68);
			this.passwordTextBox.Name = "passwordTextBox";
			this.passwordTextBox.PasswordChar = '*';
			this.passwordTextBox.Size = new System.Drawing.Size(136, 20);
			this.passwordTextBox.TabIndex = 1;
			this.passwordTextBox.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 2;
			this.label1.Text = "Email";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(72, 24);
			this.label2.TabIndex = 3;
			this.label2.Text = "Password";
			// 
			// logOnButton
			// 
			this.logOnButton.Location = new System.Drawing.Point(104, 112);
			this.logOnButton.Name = "logOnButton";
			this.logOnButton.Size = new System.Drawing.Size(72, 32);
			this.logOnButton.TabIndex = 4;
			this.logOnButton.Text = "Log On";
			this.logOnButton.Click += new System.EventHandler(this.logOnButton_Click);
			// 
			// logOnForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(264, 157);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.logOnButton,
																		  this.label2,
																		  this.label1,
																		  this.passwordTextBox,
																		  this.emailTextBox});
			this.Name = "logOnForm";
			this.Text = "logOnForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void logOnButton_Click(object sender, System.EventArgs e)
		{
			try
			{
				m_OAWS.LogOn(emailTextBox.Text,passwordTextBox.Text);
				MessageBox.Show("You were Logged On Successfully", "wooop");
				this.Dispose();
			}
			catch(System.Web.Services.Protocols.SoapException ex)
			{
				if(ex.Detail!=null)
				System.Windows.Forms.MessageBox.Show(this,ex.Detail.InnerText);

			}

		}
	}
}
