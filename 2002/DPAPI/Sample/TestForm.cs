using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Text;
using Dpapi;

namespace Sample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.TextBox SecretText;
		private System.Windows.Forms.Button Encrypt;
		private System.Windows.Forms.TextBox DecryptResults;
		private System.Windows.Forms.CheckBox UseEntropy;
		private System.Windows.Forms.TextBox EntropyText;
		private System.Windows.Forms.Button Decrypt;
		private System.Windows.Forms.TextBox CipherText;
		private System.Windows.Forms.Label CipherLabel;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

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
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
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
			this.SecretText = new System.Windows.Forms.TextBox();
			this.Encrypt = new System.Windows.Forms.Button();
			this.DecryptResults = new System.Windows.Forms.TextBox();
			this.Decrypt = new System.Windows.Forms.Button();
			this.CipherLabel = new System.Windows.Forms.Label();
			this.CipherText = new System.Windows.Forms.TextBox();
			this.UseEntropy = new System.Windows.Forms.CheckBox();
			this.EntropyText = new System.Windows.Forms.TextBox();
			this.SuspendLayout();
			// 
			// SecretText
			// 
			this.SecretText.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.SecretText.Location = new System.Drawing.Point(104, 16);
			this.SecretText.Name = "SecretText";
			this.SecretText.Size = new System.Drawing.Size(400, 20);
			this.SecretText.TabIndex = 0;
			this.SecretText.Text = "Secret user, password, and connection string!";
			// 
			// Encrypt
			// 
			this.Encrypt.Location = new System.Drawing.Point(16, 16);
			this.Encrypt.Name = "Encrypt";
			this.Encrypt.TabIndex = 1;
			this.Encrypt.Text = "Encrypt";
			this.Encrypt.Click += new System.EventHandler(this.Encrypt_Click);
			// 
			// DecryptResults
			// 
			this.DecryptResults.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.DecryptResults.Location = new System.Drawing.Point(104, 128);
			this.DecryptResults.Name = "DecryptResults";
			this.DecryptResults.Size = new System.Drawing.Size(400, 20);
			this.DecryptResults.TabIndex = 2;
			this.DecryptResults.Text = "";
			// 
			// Decrypt
			// 
			this.Decrypt.Location = new System.Drawing.Point(16, 128);
			this.Decrypt.Name = "Decrypt";
			this.Decrypt.TabIndex = 3;
			this.Decrypt.Text = "Decrypt";
			this.Decrypt.Click += new System.EventHandler(this.Decrypt_Click);
			// 
			// CipherLabel
			// 
			this.CipherLabel.Location = new System.Drawing.Point(16, 96);
			this.CipherLabel.Name = "CipherLabel";
			this.CipherLabel.Size = new System.Drawing.Size(72, 16);
			this.CipherLabel.TabIndex = 4;
			this.CipherLabel.Text = "Cipher Text:";
			this.CipherLabel.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			// 
			// CipherText
			// 
			this.CipherText.Anchor = ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.CipherText.Location = new System.Drawing.Point(104, 96);
			this.CipherText.Name = "CipherText";
			this.CipherText.ReadOnly = true;
			this.CipherText.Size = new System.Drawing.Size(400, 20);
			this.CipherText.TabIndex = 5;
			this.CipherText.Text = "";
			// 
			// UseEntropy
			// 
			this.UseEntropy.Location = new System.Drawing.Point(16, 56);
			this.UseEntropy.Name = "UseEntropy";
			this.UseEntropy.Size = new System.Drawing.Size(72, 24);
			this.UseEntropy.TabIndex = 6;
			this.UseEntropy.Text = "Entropy";
			this.UseEntropy.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
			this.UseEntropy.CheckedChanged += new System.EventHandler(this.UseEntropy_CheckedChanged);
			// 
			// EntropyText
			// 
			this.EntropyText.Enabled = false;
			this.EntropyText.Location = new System.Drawing.Point(104, 56);
			this.EntropyText.Name = "EntropyText";
			this.EntropyText.TabIndex = 7;
			this.EntropyText.Text = "entropy";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 174);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.EntropyText,
																		  this.UseEntropy,
																		  this.CipherText,
																		  this.CipherLabel,
																		  this.Decrypt,
																		  this.DecryptResults,
																		  this.Encrypt,
																		  this.SecretText});
			this.Name = "Form1";
			this.Text = "Data Protection API Test Form";
			this.ResumeLayout(false);

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

		// To make this sample easy to install and view, a Winform was used with TextBox's.
		// Instead of reading from a TextBox, in a Web Application, the connection string could be read with:
		// ConfigurationSettings.AppSettings["connectionString"];
		private void Encrypt_Click(object sender, System.EventArgs e)
		{
			// when a machine store is used, entropy can be used for further security
			byte[] entropy = new byte[0];
			if (UseEntropy.Checked)
			{
				entropy = Encoding.Unicode.GetBytes(EntropyText.Text);
			}

			DataProtector dp = new DataProtector(Store.MachineStore);
			byte[] dataToEncrypt = Encoding.Unicode.GetBytes(SecretText.Text);

			try
			{
				CipherText.Text = Convert.ToBase64String(dp.Encrypt(dataToEncrypt, entropy));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		
		}

		private void Decrypt_Click(object sender, System.EventArgs e)
		{
			byte[] entropy = new byte[0];
			if (UseEntropy.Checked)
			{
				entropy = Encoding.Unicode.GetBytes(EntropyText.Text);
			}

			DataProtector dp = new DataProtector(Store.MachineStore);
			byte[] dataToDecrypt = Convert.FromBase64String(CipherText.Text);
			
			try
			{
				DecryptResults.Text = Encoding.Unicode.GetString(dp.Decrypt(dataToDecrypt, entropy));
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.Message);
			}
		
		}

		private void UseEntropy_CheckedChanged(object sender, System.EventArgs e)
		{
			EntropyText.Enabled = UseEntropy.Checked;
		}

	}
}
