using System;
using System.Text;
using System.Runtime.InteropServices;


namespace Ashraf
{
	/// <summary>
	/// Provides very simple static methods for text encryption and decryption.
	/// Written By: Mohammad Ashraful Alam [ joy_csharp@hotmail.com ]
	/// Last Update: Mar 24, 2006
	/// </summary>
	public class SimpleEncryption
	{
		/// <summary>
		/// Encrypts the password.
		/// </summary>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		public static string EncryptPassword(string password)
		{
			System.Diagnostics.Trace.WriteLine("ENCRYPT " + password);

			DataProtector dp = new DataProtector(Store.Machine);
			return Convert.ToBase64String(dp.Encrypt(System.Text.Encoding.ASCII.GetBytes(password), null));
		}

		/// <summary>
		/// Decrypts the password.
		/// </summary>
		/// <param name="password">The password.</param>
		/// <returns></returns>
		public static string DecryptPassword(string password)
		{
			DataProtector dp = new DataProtector(Store.Machine);
			string clearText = System.Text.Encoding.ASCII.GetString(dp.Decrypt(Convert.FromBase64String(password), null));
			System.Diagnostics.Trace.WriteLine("DECRYPT " + clearText);
			return clearText;
		}
	}

		internal enum Store {Machine = 1, User};

		/// <summary>
		/// The DSAPI wrapper
		/// To be released as part of the Microsoft Configuration Building Block
		/// Provides support methods for cryptography.
		/// </summary>
		internal class DataProtector 
		{
		
			#region Constants
			static private IntPtr NullPtr = ((IntPtr)((int)(0)));
			private const int CRYPTPROTECT_UI_FORBIDDEN = 0x1;
			private const int CRYPTPROTECT_LOCAL_MACHINE = 0x4;
			private Store store;
			#endregion

			#region P/Invoke structures
			[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
				internal struct DATA_BLOB 
			{
				public int cbData;
				public IntPtr pbData;
			}

			[StructLayout(LayoutKind.Sequential, CharSet=CharSet.Unicode)]
				internal struct CRYPTPROTECT_PROMPTSTRUCT 
			{
				public int cbSize;
				public int dwPromptFlags;
				public IntPtr hwndApp;
				public String szPrompt;
			}
			#endregion

			#region External methods
			[DllImport("Crypt32.dll", SetLastError=true, CharSet=CharSet.Auto)]
			private static extern bool CryptProtectData(
				ref DATA_BLOB pDataIn, 
				String szDataDescr, 
				ref DATA_BLOB pOptionalEntropy,
				IntPtr pvReserved, 
				ref CRYPTPROTECT_PROMPTSTRUCT 
				pPromptStruct, 
				int dwFlags, 
				ref DATA_BLOB pDataOut);

			[DllImport("Crypt32.dll", SetLastError=true, CharSet=CharSet.Auto)]
			private static extern bool CryptUnprotectData(
				ref DATA_BLOB pDataIn, 
				String szDataDescr, 
				ref DATA_BLOB pOptionalEntropy, 
				IntPtr pvReserved, 
				ref CRYPTPROTECT_PROMPTSTRUCT 
				pPromptStruct, 
				int dwFlags, 
				ref DATA_BLOB pDataOut);
		
			[DllImport("kernel32.dll", CharSet=CharSet.Auto)]
			private unsafe static extern int FormatMessage(int dwFlags, 
				ref IntPtr lpSource, 
				int dwMessageId,
				int dwLanguageId, 
				ref String lpBuffer, 
				int nSize,
				IntPtr *Arguments);
			#endregion

			#region Constructor
			public DataProtector(Store tempStore) 
			{
				store = tempStore;
			}
			#endregion

			#region Public methods
			public byte[] Encrypt(byte[] plainText, byte[] optionalEntropy) 
			{
				bool retVal = false;

				DATA_BLOB plainTextBlob = new DATA_BLOB();
				DATA_BLOB cipherTextBlob = new DATA_BLOB();
				DATA_BLOB entropyBlob = new DATA_BLOB();

				CRYPTPROTECT_PROMPTSTRUCT prompt = new CRYPTPROTECT_PROMPTSTRUCT();
				InitPromptstruct(ref prompt);

				int dwFlags;
				try 
				{
					try 
					{
						int bytesSize = plainText.Length;
						plainTextBlob.pbData = Marshal.AllocHGlobal(bytesSize);
						if(IntPtr.Zero == plainTextBlob.pbData) 
						{
							throw new Exception("Unable to allocate plaintext buffer.");
						}
						plainTextBlob.cbData = bytesSize;
						Marshal.Copy(plainText, 0, plainTextBlob.pbData, bytesSize);
					}
					catch(Exception ex) 
					{
						throw new Exception("Exception marshalling data. " + ex.Message);
					}
					if(Store.Machine == store) 
					{
						//Using the machine store, should be providing entropy.
						dwFlags = CRYPTPROTECT_LOCAL_MACHINE|CRYPTPROTECT_UI_FORBIDDEN;
						//Check to see if the entropy is null
						if(null == optionalEntropy) 
						{
							//Allocate something
							optionalEntropy = new byte[0];
						}
						try 
						{
							int bytesSize = optionalEntropy.Length;
							entropyBlob.pbData = Marshal.AllocHGlobal(optionalEntropy.Length);
							if(IntPtr.Zero == entropyBlob.pbData) 
							{
								throw new Exception("Unable to allocate entropy data buffer.");
							}
							Marshal.Copy(optionalEntropy, 0, entropyBlob.pbData, bytesSize);
							entropyBlob.cbData = bytesSize;
						}
						catch(Exception ex) 
						{
							throw new Exception("Exception entropy marshalling data. " + ex.Message);
						}
					}
					else 
					{
						//Using the user store
						dwFlags = CRYPTPROTECT_UI_FORBIDDEN;
					}
					retVal = CryptProtectData( ref plainTextBlob, "", ref entropyBlob, 
						IntPtr.Zero, ref prompt, dwFlags, ref cipherTextBlob);
					if(false == retVal) 
					{
						throw new Exception("Encryption failed. " + GetErrorMessage(Marshal.GetLastWin32Error()));
					}
				}
				catch(Exception ex) 
				{
					throw new Exception("Exception encrypting. " + ex.Message);
				}
				byte[] cipherText = new byte[cipherTextBlob.cbData];
				Marshal.Copy(cipherTextBlob.pbData, cipherText, 0, cipherTextBlob.cbData);
				return cipherText;
			}

			public byte[] Decrypt(byte[] cipherText, byte[] optionalEntropy) 
			{
				bool retVal = false;
				DATA_BLOB plainTextBlob = new DATA_BLOB();
				DATA_BLOB cipherBlob = new DATA_BLOB();
				CRYPTPROTECT_PROMPTSTRUCT prompt = new CRYPTPROTECT_PROMPTSTRUCT();
				InitPromptstruct(ref prompt);
				try 
				{
					try 
					{
						int cipherTextSize = cipherText.Length;
						cipherBlob.pbData = Marshal.AllocHGlobal(cipherTextSize);
						if(IntPtr.Zero == cipherBlob.pbData) 
						{
							throw new Exception("Unable to allocate cipherText buffer.");
						}
						cipherBlob.cbData = cipherTextSize;
						Marshal.Copy(cipherText, 0, cipherBlob.pbData, cipherBlob.cbData);
					}
					catch(Exception ex) 
					{
						throw new Exception("Exception marshalling data. " + ex.Message);
					}
					DATA_BLOB entropyBlob = new DATA_BLOB();
					int dwFlags;
					if(Store.Machine == store) 
					{
						//Using the machine store, should be providing entropy.
						dwFlags = CRYPTPROTECT_LOCAL_MACHINE|CRYPTPROTECT_UI_FORBIDDEN;
						//Check to see if the entropy is null
						if(null == optionalEntropy) 
						{
							//Allocate something
							optionalEntropy = new byte[0];
						}
						try 
						{
							int bytesSize = optionalEntropy.Length;
							entropyBlob.pbData = Marshal.AllocHGlobal(bytesSize);
							if(IntPtr.Zero == entropyBlob.pbData) 
							{
								throw new Exception("Unable to allocate entropy buffer.");
							}
							entropyBlob.cbData = bytesSize;
							Marshal.Copy(optionalEntropy, 0, entropyBlob.pbData, bytesSize);
						}
						catch(Exception ex) 
						{
							throw new Exception("Exception entropy marshalling data. " + ex.Message);
						}
					}
					else 
					{
						//Using the user store
						dwFlags = CRYPTPROTECT_UI_FORBIDDEN;
					}
					retVal = CryptUnprotectData(ref cipherBlob, null, ref 
						entropyBlob, 
						IntPtr.Zero, ref prompt, dwFlags, 
						ref plainTextBlob);
					if(false == retVal) 
					{
						throw new Exception("Decryption failed. " + GetErrorMessage(Marshal.GetLastWin32Error()));
					}
					//Free the blob and entropy.
					if(IntPtr.Zero != cipherBlob.pbData) 
					{
						Marshal.FreeHGlobal(cipherBlob.pbData);
					}
					if(IntPtr.Zero != entropyBlob.pbData) 
					{
						Marshal.FreeHGlobal(entropyBlob.pbData);
					}
				}
				catch(Exception ex) 
				{
					throw new Exception("Exception decrypting. " + ex.Message);
				}
				byte[] plainText = new byte[plainTextBlob.cbData];
				Marshal.Copy(plainTextBlob.pbData, plainText, 0, plainTextBlob.cbData);
				return plainText;
			}
			#endregion

			#region Private methods
			private void InitPromptstruct(ref CRYPTPROTECT_PROMPTSTRUCT ps) 
			{
				ps.cbSize = Marshal.SizeOf(typeof(CRYPTPROTECT_PROMPTSTRUCT));
				ps.dwPromptFlags = 0;
				ps.hwndApp = NullPtr;
				ps.szPrompt = null;
			}

			private unsafe static String GetErrorMessage(int errorCode) 
			{
				int FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
				int FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
				int FORMAT_MESSAGE_FROM_SYSTEM  = 0x00001000;
				int messageSize = 255;
				String lpMsgBuf = "";
				int dwFlags = FORMAT_MESSAGE_ALLOCATE_BUFFER | 
					FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS;
				IntPtr ptrlpSource = new IntPtr();
				IntPtr prtArguments = new IntPtr();
				int retVal = FormatMessage(dwFlags, ref ptrlpSource, errorCode, 0, 
					ref lpMsgBuf, messageSize, &prtArguments);
				if(0 == retVal) 
				{
					throw new Exception("Failed to format message for error code " + errorCode + ". ");
				}
				return lpMsgBuf;
			}
			#endregion

		}

}
