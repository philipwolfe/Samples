using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using Microsoft.VisualBasic;


namespace Winforms_Cryptography
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnGenRdm;
		private System.Windows.Forms.TextBox txtoriginal;
		private System.Windows.Forms.TextBox txtpasscode;
		private System.Windows.Forms.Button Encrypt;
		private System.Windows.Forms.TextBox txtinputtext;
		private System.Windows.Forms.Button Decrypt;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Label Label4;
		private System.Windows.Forms.TextBox txtencryptedtext;
		private System.Windows.Forms.Label Label2;
		private System.Windows.Forms.Label Label1;
		private System.Windows.Forms.Label Label3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

		public Form1()
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
		public override void Dispose()
		{
			base.Dispose();
			if(components != null)
				components.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.btnGenRdm = new System.Windows.Forms.Button();
			this.txtoriginal = new System.Windows.Forms.TextBox();
			this.txtpasscode = new System.Windows.Forms.TextBox();
			this.Encrypt = new System.Windows.Forms.Button();
			this.txtinputtext = new System.Windows.Forms.TextBox();
			this.Decrypt = new System.Windows.Forms.Button();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.Label4 = new System.Windows.Forms.Label();
			this.txtencryptedtext = new System.Windows.Forms.TextBox();
			this.Label2 = new System.Windows.Forms.Label();
			this.Label1 = new System.Windows.Forms.Label();
			this.Label3 = new System.Windows.Forms.Label();
			this.btnGenRdm.Location = new System.Drawing.Point(308, 28);
			this.btnGenRdm.Size = new System.Drawing.Size(132, 24);
			this.btnGenRdm.TabIndex = 15;
			this.btnGenRdm.Text = "Generate Passcode";
			this.btnGenRdm.Click += new System.EventHandler(this.btnGenRdm_Click);
			this.txtoriginal.Location = new System.Drawing.Point(160, 348);
			this.txtoriginal.Multiline = true;
			this.txtoriginal.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtoriginal.Size = new System.Drawing.Size(512, 80);
			this.txtoriginal.TabIndex = 9;
			this.txtoriginal.Text = "";
			this.txtpasscode.Location = new System.Drawing.Point(160, 32);
			this.txtpasscode.Size = new System.Drawing.Size(136, 20);
			this.txtpasscode.TabIndex = 8;
			this.txtpasscode.Text = "";
			this.Encrypt.Location = new System.Drawing.Point(352, 176);
			this.Encrypt.TabIndex = 1;
			this.Encrypt.Text = "Encrypt";
			this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
			this.txtinputtext.Location = new System.Drawing.Point(160, 88);
			this.txtinputtext.Multiline = true;
			this.txtinputtext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtinputtext.Size = new System.Drawing.Size(512, 68);
			this.txtinputtext.TabIndex = 0;
			this.txtinputtext.Text = "";
			this.Decrypt.Location = new System.Drawing.Point(352, 292);
			this.Decrypt.TabIndex = 3;
			this.Decrypt.Text = "Decrypt";
			this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
			this.statusBar1.BackColor = System.Drawing.SystemColors.Control;
			this.statusBar1.Location = new System.Drawing.Point(0, 468);
			this.statusBar1.Size = new System.Drawing.Size(683, 20);
			this.statusBar1.TabIndex = 16;
			this.Label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.Label4.Location = new System.Drawing.Point(32, 352);
			this.Label4.Size = new System.Drawing.Size(112, 48);
			this.Label4.TabIndex = 10;
			this.Label4.Text = "Original Input Text";
			this.Label4.Visible = false;
			this.txtencryptedtext.Location = new System.Drawing.Point(160, 216);
			this.txtencryptedtext.Multiline = true;
			this.txtencryptedtext.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.txtencryptedtext.Size = new System.Drawing.Size(512, 68);
			this.txtencryptedtext.TabIndex = 2;
			this.txtencryptedtext.Text = "";
			this.Label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.Label2.Location = new System.Drawing.Point(32, 92);
			this.Label2.Size = new System.Drawing.Size(96, 20);
			this.Label2.TabIndex = 5;
			this.Label2.Text = "Input Text";
			this.Label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.Label1.Location = new System.Drawing.Point(32, 216);
			this.Label1.Size = new System.Drawing.Size(88, 36);
			this.Label1.TabIndex = 4;
			this.Label1.Text = "Encrypted Text";
			this.Label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
			this.Label3.Location = new System.Drawing.Point(32, 32);
			this.Label3.TabIndex = 7;
			this.Label3.Text = "Passcode";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(683, 488);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.Label2,
																		  this.Label1,
																		  this.statusBar1,
																		  this.txtencryptedtext,
																		  this.Label4,
																		  this.Decrypt,
																		  this.txtinputtext,
																		  this.Encrypt,
																		  this.btnGenRdm,
																		  this.txtpasscode,
																		  this.txtoriginal,
																		  this.Label3});
			this.Text = "Form1";

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}
		private void btnGenRdm_Click(object sender, System.EventArgs e)
		{
			Random randomNumber = new Random();

			txtpasscode.Text = randomNumber.Next().ToString();
			statusBar1.Text = "You have chosen to Randomly generate a passcode";
		}
		private void Decrypt_Click(object sender, System.EventArgs e)
		{
			//'Read the contents of the file we just created and output it to the textbox
			if (txtencryptedtext.Text == "")
			{
				statusBar1.Text = "You have no characters to decrypt";
				MessageBox.Show("You have no characters to decrypt");
				return;
			}

			statusBar1.Text = "Decrypting characters to readable text...";

			Encrypt decryptor = new Encrypt();
			decryptor.GenerateKeyFromPassPhrase(txtpasscode.Text);
			decryptor.DecryptData("output.txt", "input.txt");

			StreamReader streamRead = File.OpenText("input.txt");
			while (streamRead.Peek() != -1)
			   {
				   txtoriginal.Text += streamRead.ReadLine();
			   }
			streamRead.Close();
		}
		private void Encrypt_Click(object sender, System.EventArgs e)
		{
			//write the contents of the text boxes to a file    
			if( txtinputtext.Text == "")
			{
				MessageBox.Show("You must enter some text in the input text field");
				return;
			}

			if( txtpasscode.Text == "")
			{
				MessageBox.Show("You must enter some text in the input Passcode field");
				return;
			}

			txtencryptedtext.Text = "";
			txtoriginal.Text = "";

			StreamWriter streamWrite  = File.CreateText("input.txt");
			streamWrite.Write(txtinputtext.Text);
			streamWrite.Close();

			streamWrite = File.CreateText("output.txt");
			streamWrite.Write("");
			streamWrite.Close();

			statusBar1.Text = "Encrypting Input Text...";
			Encrypt encryptor = new Encrypt();
			encryptor.GenerateKeyFromPassPhrase(txtpasscode.Text);
			encryptor.EncryptData("input.txt", "output.txt");

			//show the encrypted text
			StreamReader streamRead = File.OpenText("output.txt");
			while( streamRead.Peek() != -1)
			{
				txtencryptedtext.Text += streamRead.ReadLine() + "\n";
			}
			streamRead.Close();
		}
	}
}
