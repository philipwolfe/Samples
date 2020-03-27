using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace OnlineAddressBookCsharpClient
{
	/// <summary>
	/// Summary description for newAccountForm.
	/// </summary>
	public class newAccountForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.TextBox emailTextBox;
		private System.Windows.Forms.TextBox firstNameTextBox;
		private System.Windows.Forms.TextBox lastNameTextBox;
		private System.Windows.Forms.TextBox password1TextBox;
		private System.Windows.Forms.TextBox password2TextBox;
		private System.Windows.Forms.Button createAccountButton;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		private OnlineAddressBookServer.OnlineAddressBookWSService m_OAWS;

		public newAccountForm(ref OnlineAddressBookServer.OnlineAddressBookWSService OAWS)
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
			this.password2TextBox = new System.Windows.Forms.TextBox();
			this.lastNameTextBox = new System.Windows.Forms.TextBox();
			this.emailTextBox = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.firstNameTextBox = new System.Windows.Forms.TextBox();
			this.label4 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.createAccountButton = new System.Windows.Forms.Button();
			this.password1TextBox = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// password2TextBox
			// 
			this.password2TextBox.Location = new System.Drawing.Point(200, 156);
			this.password2TextBox.Name = "password2TextBox";
			this.password2TextBox.PasswordChar = '*';
			this.password2TextBox.Size = new System.Drawing.Size(168, 20);
			this.password2TextBox.TabIndex = 9;
			this.password2TextBox.Text = "";
			// 
			// lastNameTextBox
			// 
			this.lastNameTextBox.Location = new System.Drawing.Point(200, 92);
			this.lastNameTextBox.Name = "lastNameTextBox";
			this.lastNameTextBox.Size = new System.Drawing.Size(168, 20);
			this.lastNameTextBox.TabIndex = 7;
			this.lastNameTextBox.Text = "";
			// 
			// emailTextBox
			// 
			this.emailTextBox.Location = new System.Drawing.Point(200, 28);
			this.emailTextBox.Name = "emailTextBox";
			this.emailTextBox.Size = new System.Drawing.Size(168, 20);
			this.emailTextBox.TabIndex = 5;
			this.emailTextBox.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(32, 32);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(80, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "Email:";
			// 
			// firstNameTextBox
			// 
			this.firstNameTextBox.Location = new System.Drawing.Point(200, 60);
			this.firstNameTextBox.Name = "firstNameTextBox";
			this.firstNameTextBox.Size = new System.Drawing.Size(168, 20);
			this.firstNameTextBox.TabIndex = 6;
			this.firstNameTextBox.Text = "";
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(32, 128);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(64, 16);
			this.label4.TabIndex = 3;
			this.label4.Text = "Password:";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(32, 160);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(120, 24);
			this.label5.TabIndex = 4;
			this.label5.Text = "Password Confirmation:";
			// 
			// createAccountButton
			// 
			this.createAccountButton.Location = new System.Drawing.Point(168, 208);
			this.createAccountButton.Name = "createAccountButton";
			this.createAccountButton.Size = new System.Drawing.Size(72, 24);
			this.createAccountButton.TabIndex = 10;
			this.createAccountButton.Text = "Create";
			this.createAccountButton.Click += new System.EventHandler(this.createAccountButton_Click);
			// 
			// password1TextBox
			// 
			this.password1TextBox.Location = new System.Drawing.Point(200, 124);
			this.password1TextBox.Name = "password1TextBox";
			this.password1TextBox.PasswordChar = '*';
			this.password1TextBox.Size = new System.Drawing.Size(168, 20);
			this.password1TextBox.TabIndex = 8;
			this.password1TextBox.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(32, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(88, 16);
			this.label2.TabIndex = 1;
			this.label2.Text = "First Name:";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(32, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 16);
			this.label3.TabIndex = 2;
			this.label3.Text = "Last Name:";
			// 
			// newAccountForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(472, 277);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.createAccountButton,
																		  this.password2TextBox,
																		  this.password1TextBox,
																		  this.lastNameTextBox,
																		  this.firstNameTextBox,
																		  this.emailTextBox,
																		  this.label5,
																		  this.label4,
																		  this.label3,
																		  this.label2,
																		  this.label1});
			this.Name = "newAccountForm";
			this.Text = "newAccountForm";
			this.ResumeLayout(false);

		}
		#endregion

		private void createAccountButton_Click(object sender, System.EventArgs e)
		{

			if(password1TextBox.Text==password2TextBox.Text)
				try
				{
					m_OAWS.CreateAccount(emailTextBox.Text,password1TextBox.Text,firstNameTextBox.Text,lastNameTextBox.Text);
					MessageBox.Show("New Account Created Successfully, now log on using the file menu");
					this.Dispose();
				}
				catch(System.Web.Services.Protocols.SoapException ex)
				{
					System.Windows.Forms.MessageBox.Show(this,ex.Detail.InnerText);

				}

			else
				System.Windows.Forms.MessageBox.Show(this,"Password and Password Confirmation do not match");
		}
	}
}
