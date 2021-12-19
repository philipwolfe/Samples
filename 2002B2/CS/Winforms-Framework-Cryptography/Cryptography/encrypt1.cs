using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Security.Cryptography;
using Microsoft.VisualBasic;

namespace Winforms_Cryptography
{
	/// <summary>
	/// Summary description for encrypt1.
	/// </summary>
	public class Encrypt
	{
		byte [] symkey = new byte[8];
		byte [] symIV = new byte[8];
		public Encrypt()
		{
			//
			// TODO: Add constructor logic here
			//
		}
		public bool GenerateKeyFromPassPhrase(string phrase )
		{

			try
			{

				// change the pass phrase into a form we can use
				int i; 
				int len;
				Char[] charPhrase = phrase.ToCharArray();
				len = charPhrase.GetLength(0);
				// convert to byte array -  discard upper byte since is usually 0 in Eng.
				Byte[] binPhrase = new Byte[len];
				for(i = 0;i<= (len - 1);i++)
				{
					binPhrase[i] = Convert.ToByte((charPhrase[i]));  // truncate char value
				}

				//do the hash operation 
				SHA1CryptoServiceProvider SHAProvider = new SHA1CryptoServiceProvider();
				SHAProvider.ComputeHash(binPhrase);

				// use the low 64-bits for the key value 
				for(i = 0;i<=7;i++)
				{
					symkey[i] = SHAProvider.Hash[i];
				}

				for(i = 8;i<=15;i++)
				{
					symIV[i - 8] = SHAProvider.Hash[i];
				}

				return true;
			}
			catch(Exception e )
			{
				Console.WriteLine(e);
				return false;
			}
		}
		public void EncryptData(string inName, string outName){


			try
			{

				// Open the input and output files
				FileStream fileIn = new FileStream(inName, FileMode.Open, FileAccess.Read);

				FileStream fileOut = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
				fileOut.SetLength(0);
				
				// setup up variable to help with read
				Byte[] Bin = new Byte[1024]; 
				int len;
				long filelen = fileIn.Length;
	
				// Crypto specific code starts here 
				// create the DESProvider encryptor
				DESCryptoServiceProvider DESProvider = new DESCryptoServiceProvider();

				ICryptoTransform cryptTransform = DESProvider.CreateEncryptor(symkey, symIV);
				CryptoStream DESEncrypt = new CryptoStream(fileIn, cryptTransform, CryptoStreamMode.Read);
				do
				{
					len = DESEncrypt.Read(Bin, 0, 1024);
					fileOut.Write(Bin, 0, len);
					Console.WriteLine("Processed {0} bytes, {1} bytes total", len, filelen);
				} while (len > 0);

				// Crypto specific code ends here 
				fileOut.Close();
				fileIn.Close();
			}
			catch (Exception e) 
			{ 
				Console.WriteLine(e);
			}
		}
		public void  DecryptData(string inName , string outName)
		{
			try
			{
				// Open the input and output files
				FileStream fileIn = new FileStream(inName, FileMode.Open, FileAccess.Read);

				FileStream fileOut = new FileStream(outName, FileMode.OpenOrCreate, FileAccess.Write);
				fileOut.SetLength(0);

				// setup up variable to help with read
				Byte [] Bin = new Byte[1024];
				int len;
				long filelen = fileIn.Length;
				// Crypto specific code starts here 
				// create the DESProvider encryptor and the SymmetricStreamEncryptor obj 
				DESCryptoServiceProvider DESProvider = new DESCryptoServiceProvider();

				ICryptoTransform cryptTransform  = DESProvider.CreateDecryptor(symkey, symIV);
				CryptoStream DESDecrypt = new CryptoStream(fileIn, cryptTransform, CryptoStreamMode.Read);

				do
				{
					len = DESDecrypt.Read(Bin, 0, 1024);
					fileOut.Write(Bin, 0, len);
					Console.WriteLine("Processed {0} bytes, {1} bytes total", len, filelen);
				} while( len > 0);

				// Crypto specific code ends here 
				fileOut.Close();
				fileIn.Close();
			}
			catch(Exception e)
			{
				Console.WriteLine(e);
			}
		}
	}
}