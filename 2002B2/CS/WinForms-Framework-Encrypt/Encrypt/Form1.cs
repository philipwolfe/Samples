using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Security;
using System.Security.Cryptography;
using System.IO;


namespace Encrypt
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button btnEncrypt;
		
		private byte[] symkey = new byte[8];
		private byte[] symIV = new byte[8] ;
		private string passPhrase = "YourDog123";
		private string inputFileName = "input.txt";
		private string encrypedFileName = "encrypted.txt";
		private string deencrypedFileName = "decrypted.txt";
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
			this.btnEncrypt = new System.Windows.Forms.Button();
			this.btnEncrypt.Location = new System.Drawing.Point(32, 16);
			this.btnEncrypt.Size = new System.Drawing.Size(152, 32);
			this.btnEncrypt.TabIndex = 0;
			this.btnEncrypt.Text = "Encrypt";
			this.btnEncrypt.Click += new System.EventHandler(this.btnEncrypt_Click);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(227, 56);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.btnEncrypt});
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

		private void btnEncrypt_Click(object sender, System.EventArgs e)
		{
		MessageBox.Show("Creating Key", "Encrypt");
        //fills in symKey and symIV arrays
        GenerateKeyFromPassPhrase(passPhrase);

        MessageBox.Show("Encrypting " + inputFileName + " in the \"\\Debug\\bin\" directory for Encrypt", "Encrypt");
        EncryptData(inputFileName, encrypedFileName);
        MessageBox.Show("Decrypting to file " + encrypedFileName, "Encrypt");
        DecryptData(encrypedFileName, deencrypedFileName);
		}

		public bool GenerateKeyFromPassPhrase(String phrase )
		 {
			 // change the pass phrase into a form we can use
			int i;
			int len ;
			char [] charPhrase = phrase.ToCharArray();
			 len = charPhrase.GetLength(0);
			 // convert to byte array -  discard upper byte since is usually 0 in Eng.
			 byte [] bytePhrase  = new byte[len];
			for( i = 0;i<=(len - 1);i++)
			{
				bytePhrase[i] = Convert.ToByte(charPhrase[i]);  //' truncate char value
			}

			 //do the hash operation 
			SHA1CryptoServiceProvider SHAProvider = new SHA1CryptoServiceProvider();
			SHAProvider.ComputeHash(bytePhrase);

			// use the low 64-bits for the key value
			// Generate key and initialization vector based on passcodce.
			// In symmetric encryption,
			// Both users must have the same key in order to 
			// encrypt/decrypt
			for(i = 0;i<= 7;i++)
			{
				symkey[i] = SHAProvider.Hash[i];
			}

			 for(i = 8;i<=15;i++)
			 { 
				 symIV[i - 8] = SHAProvider.Hash[i];
			 }

			 return true;
		 }
		/////////////////////////////////////////////////////////////
		// Encrypt/Decrypt Data
		public void EncryptData(String inName, String outName)
		{
			// Open the input and output files
			FileStream fileIn = new FileStream(inName, FileMode.OpenOrCreate, FileAccess.Read);

			FileStream fileOut = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
			fileOut.SetLength(0);

			// setup up variable to help with read
			byte[] bin = new byte[4096];
			long readLen = 8;
			int len;

			DESCryptoServiceProvider DESProvider = new DESCryptoServiceProvider();
			ICryptoTransform CryptTransform = DESProvider.CreateEncryptor(symkey, symIV);
			CryptoStream DESEncrypt = new CryptoStream(fileIn, CryptTransform, CryptoStreamMode.Read);

			// Read data from file. When data moves into CrytptoStream, it is 
			// automatically encrypted using the algorithm specified by provider
			do
			{
				len = DESEncrypt.Read(bin, 0, 4096);
				// Write encrypted data to output file
				fileOut.Write(bin, 0, len);
				readLen += len;
				Console.WriteLine("Processed {0} bytes, {1} bytes total", len, readLen);
			} while(len > 0);

			fileIn.Close();
			fileOut.Close();
		}
		public void DecryptData(string inName, string outName)
		{
//			try
//			{

				//' Open the input and output files
				FileStream fileIn = new FileStream(inName, FileMode.Open, FileAccess.Read);

				FileStream fileOut= new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
				fileOut.SetLength(0);

				//' setup up variable to help with read
				byte[] bin = new byte[4096];
				long readLen = 8;
				int len;

				DESCryptoServiceProvider DESProvider = new DESCryptoServiceProvider();

				ICryptoTransform CryptTransform = DESProvider.CreateDecryptor(symkey, symIV);
				CryptoStream DESDecrypt = new CryptoStream(fileIn, CryptTransform, CryptoStreamMode.Read);

				//' Reverse of encryption. When data is read from file into CryptoStream
				//' it is automatically decrypted.
				do
				{
					len = DESDecrypt.Read(bin, 0, 4096);
					//' Write descrypted code to file
					fileOut.Write(bin, 0, len);
					readLen += len;
					Console.WriteLine("Processed {0} bytes, {1} bytes total", len, readLen);
				}while( len > 0);

					fileIn.Close();
				fileOut.Close();
//			}
//			catch (Exception e)
//			{
//				Console.WriteLine(e);
//			}
	}

	}
}
