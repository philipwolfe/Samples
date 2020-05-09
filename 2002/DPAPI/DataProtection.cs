using System;
using System.Text;
using System.Runtime.InteropServices;

namespace Dpapi
{
	/// <summary>
	/// This is used to indicate whether Dpapi should be used in conjunction with the machine or user stores.
	/// </summary>
	public enum Store 
	{
		/// <summary>
		/// User independent store. Less secure but works well from ASP.Net
		/// </summary>
		MachineStore = 1, 
		/// <summary>
		/// User specific store. Machine and user affinity.
		/// </summary>
		UserStore
	};

	#region Custom Exception
	/// <summary>
	/// Exceptions specific to the <see cref="Dpapi.DataProtector"/> class.
	/// </summary>
	public class DataProtectorException : Exception
	{
		/// <summary>
		/// Initializes the exception.
		/// </summary>
		public DataProtectorException() : base()
		{
		}
		/// <summary>
		/// Initializes the exception.
		/// </summary>
		/// <param name="message">The cause of the exception.</param>
		public DataProtectorException(string message) : base(message)
		{
		}
		/// <summary>
		/// Initializes the exception.
		/// </summary>
		/// <param name="message">The cause of the exception.</param>
		/// <param name="innerException">The actual exception tha occured.</param>
		public DataProtectorException(string message, Exception innerException) : base(message, innerException)
		{
		}
	}

	#endregion

	/// <summary>
	/// Applications often need to store sensitive data like connection strings and user credentials. 
	/// This type of data should never be stored as plain text. The Data Protection API (part of the CryptoAPI) 
	/// has Encrypt and Decrypt to store encrypted data in the User or Machine store. 
	/// 
	/// One thing to note: The strings will still be on the managed heap as plain text during execution of these functions.
	/// </summary>
	public class DataProtector
	{

		#region DLL Imports

		/// <summary>
		/// Import of CryptoAPIs CryptProtectData. Parameters ripped from the SDK.
		/// </summary>
		[DllImport("Crypt32.dll", SetLastError=true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		private static extern bool CryptProtectData(
			ref DATA_BLOB pDataIn, 
			String szDataDescr, 
			ref DATA_BLOB pOptionalEntropy,
			IntPtr pvReserved, 
			ref CRYPTPROTECT_PROMPTSTRUCT pPromptStruct, 
			int dwFlags, 
			ref DATA_BLOB pDataOut);

		/// <summary>
		/// Import of CryptoAPIs CryptUnprotectData. Parameters ripped from the SDK.
		/// </summary>
		[DllImport("Crypt32.dll", SetLastError = true, CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		private static extern bool CryptUnprotectData(
			ref DATA_BLOB pDataIn, 
			String szDataDescr, 
			ref DATA_BLOB pOptionalEntropy, 
			IntPtr pvReserved, 
			ref CRYPTPROTECT_PROMPTSTRUCT pPromptStruct, 
			int dwFlags, 
			ref DATA_BLOB pDataOut);

		/// <summary>
		/// No framework equivalent of FormatMessage so it has to be imported.
		/// </summary>
		[DllImport("kernel32.dll", CharSet = System.Runtime.InteropServices.CharSet.Auto)]
		private unsafe static extern int FormatMessage(
			int dwFlags, 
			ref IntPtr lpSource, 
			int dwMessageId,
			int dwLanguageId, 
			ref String lpBuffer, int nSize, 
			IntPtr *Arguments);

		#endregion

		#region Structure Definitions and Constraints
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

		private const int CRYPTPROTECT_UI_FORBIDDEN = 0x1;
		private const int CRYPTPROTECT_LOCAL_MACHINE = 0x4;
		#endregion

		#region Constructor
		private Store _store;

		/// <summary>
		/// Initializes a new instance of <see cref='Dpapi.DataProtector'/> from a type of <see cref='Dpapi.Store'/>.
		/// </summary>
		/// <param name="store">A <see cref="Dpapi.Store"/> to initialize the DataProtector.</param>
		public DataProtector(Store store)
		{
			_store = store;
		}
		#endregion

		#region Encrypt and Decrypt

		/// <summary>
		/// Encrypts an array of bytes and returns the cipher text.
		/// </summary>
		/// <param name="plainText">Array of bytes to be encrypted.</param>
		/// <returns>Array of bytes with the cipher text needed later with <see cref="Dpapi.DataProtector.Decrypt"/></returns>
		/// <example>This example shows how to encrypt text.
		/// <code>
		///	DataProtector dp = new DataProtector(DataProtector.Store.MachineStore);
		///	byte[] dataToEncrypt = Encoding.Unicode.GetBytes("Secret user name, password, and connection string!");
		/// CipherText.Text = Convert.ToBase64String(dp.Encrypt(dataToEncrypt));
		/// </code>
		/// </example>
		public byte[] Encrypt(byte[] plainText)
		{
			return Encrypt(plainText, new byte[0]);
		}

		/// <summary>
		/// Encrypts an array of bytes with an entropy value for added security and returns the cipher text.
		/// </summary>
		/// <param name="plainText">Array of bytes to be encrypted.</param>
		/// <param name="entropyText">Optional Entropy value for further protection when using the machine store.</param>
		/// <returns>Array of bytes with the cipher text needed later with <see cref="Dpapi.DataProtector.Decrypt"/></returns>
		/// <example>This example shows how to encrypt text.
		/// <code>
		///	DataProtector dp = new DataProtector(DataProtector.Store.MachineStore);
		///	byte[] dataToEncrypt = Encoding.Unicode.GetBytes("Secret user name, password, and connection string!");
		/// CipherText.Text = Convert.ToBase64String(dp.Encrypt(dataToEncrypt, "entropy text"));
		/// </code>
		/// </example>
		public byte[] Encrypt(byte[] plainText, byte[] entropyText)
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
					if (plainTextBlob.pbData == IntPtr.Zero)
					{
						throw new OutOfMemoryException("Unable to allocate memory for buffer.");
					}
					plainTextBlob.cbData = bytesSize;
					Marshal.Copy(plainText, 0, plainTextBlob.pbData, bytesSize);
				}
				catch (Exception ex)
				{
					throw new Exception("Exception marshalling data.", ex);
				}
				
				if (_store == Store.MachineStore)
				{
					// MachineStore
					dwFlags = CRYPTPROTECT_LOCAL_MACHINE | CRYPTPROTECT_UI_FORBIDDEN;
					
					try
					{
						int bytesSize = entropyText.Length;
						entropyBlob.pbData = Marshal.AllocHGlobal(bytesSize);
						if (entropyBlob.pbData == IntPtr.Zero)
						{
							throw new OutOfMemoryException("Unable to allocate entropy data buffer.");
						}
						Marshal.Copy(entropyText, 0, entropyBlob.pbData, bytesSize);
						entropyBlob.cbData = bytesSize;
					}
					catch (Exception ex)
					{
						throw new Exception("Exception entropy marshalling data. ", ex);
					}
				}
				else
				{
					// UserStore
					dwFlags = CRYPTPROTECT_UI_FORBIDDEN;
				}
				retVal = CryptProtectData(ref plainTextBlob, null, ref entropyBlob, IntPtr.Zero, ref prompt, dwFlags, ref cipherTextBlob);
				if (!retVal)
				{
					throw new DataProtectorException("Encryption failed. " + GetErrorMessage(Marshal.GetLastWin32Error()));
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Exception encrypting.", ex);
			}
			byte[] cipherText = new byte[cipherTextBlob.cbData];
			Marshal.Copy(cipherTextBlob.pbData, cipherText, 0, cipherTextBlob.cbData);
			return cipherText;
		}

		/// <summary>
		/// Decrypts an array of bytes previously encrypted.
		/// </summary>
		/// <param name="cipherText">Cipher text from previous encryption.</param>
		/// <returns>Array of bytes containing the decrypted data.</returns>
		/// <example>This exmaple shows how to decrypt text.
		/// <code>
		///	DataProtector dp = new DataProtector(DataProtector.Store.MachineStore);
		/// byte[] dataToDecrypt = Convert.FromBase64String(CipherText.Text);
		/// DecryptResults.Text = Encoding.Unicode.GetString(dp.Decrypt(dataToDecrypt));
		/// </code>
		/// </example>
		public byte[] Decrypt(byte[] cipherText)
		{
			return Decrypt(cipherText, new byte[0]);
		}

		/// <summary>
		/// Decrypts an array of bytes previously encrypted along with an entropy value.
		/// </summary>
		/// <param name="cipherText">Cipher text from previous encryption.</param>
		/// <param name="entropyText">Optional Entropy value for further protection when using the machine store.</param>
		/// <returns>Array of bytes containing the decrypted data.</returns>
		/// <example>This exmaple shows how to decrypt text.
		/// <code>
		///	DataProtector dp = new DataProtector(DataProtector.Store.MachineStore);
		/// byte[] dataToDecrypt = Convert.FromBase64String(CipherText.Text);
		/// DecryptResults.Text = Encoding.Unicode.GetString(dp.Decrypt(dataToDecrypt, "entropy text"));
		/// </code>
		/// </example>
		public byte[] Decrypt(byte[] cipherText, byte[] entropyText)
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
					if (cipherBlob.pbData == IntPtr.Zero)
					{
						throw new OutOfMemoryException("Unable to allocate cipherText buffer.");
					}
					cipherBlob.cbData = cipherTextSize;	
					Marshal.Copy(cipherText, 0, cipherBlob.pbData, cipherBlob.cbData);
				}
				catch (Exception ex)
				{
					throw new Exception("Exception marshalling data.", ex);
				}
				DATA_BLOB entropyBlob = new DATA_BLOB();
				int dwFlags;

				if (_store == Store.MachineStore)
				{
					// MachineStore
					dwFlags = CRYPTPROTECT_LOCAL_MACHINE | CRYPTPROTECT_UI_FORBIDDEN;
					
					try
					{
						int bytesSize = entropyText.Length;
						entropyBlob.pbData = Marshal.AllocHGlobal(bytesSize);
						if (entropyBlob.pbData == IntPtr.Zero)
						{
							throw new OutOfMemoryException("Unable to allocate entropy buffer.");
						}
						entropyBlob.cbData = bytesSize;
						Marshal.Copy(entropyText, 0, entropyBlob.pbData, bytesSize);
					}
					catch (Exception ex)
					{
						throw new Exception("Exception entropy marshalling data. ",	ex);
					}
				}
				else
				{
					// UserStore
					dwFlags = CRYPTPROTECT_UI_FORBIDDEN;
				}
				retVal = CryptUnprotectData(ref cipherBlob, null, ref entropyBlob, IntPtr.Zero, ref prompt, dwFlags, ref plainTextBlob);
				if (!retVal)
				{
					throw new DataProtectorException("Decryption failed. " + GetErrorMessage(Marshal.GetLastWin32Error()));
				}
				
				//Free the blob and entropy.
				if (cipherBlob.pbData != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(cipherBlob.pbData);
				}
				if (entropyBlob.pbData != IntPtr.Zero)
				{
					Marshal.FreeHGlobal(entropyBlob.pbData);
				}
			}
			catch (Exception ex)
			{
				throw new Exception("Exception decrypting. ", ex);
			}
			byte[] plainText = new byte[plainTextBlob.cbData];
			Marshal.Copy(plainTextBlob.pbData, plainText, 0, plainTextBlob.cbData);
			return plainText;
		}
		#endregion

		#region Helper Functions
		private void InitPromptstruct(ref CRYPTPROTECT_PROMPTSTRUCT ps) 
		{
			ps.cbSize = Marshal.SizeOf(typeof(CRYPTPROTECT_PROMPTSTRUCT));
			ps.dwPromptFlags = 0;
			ps.hwndApp = IntPtr.Zero;
			ps.szPrompt = null;
		}

		/// <summary>
		/// move this to exception class
		/// </summary>
		/// <param name="errorCode"></param>
		/// <returns></returns>
		private unsafe static String GetErrorMessage(int errorCode)
		{
			int FORMAT_MESSAGE_ALLOCATE_BUFFER = 0x00000100;
			int FORMAT_MESSAGE_IGNORE_INSERTS = 0x00000200;
			int FORMAT_MESSAGE_FROM_SYSTEM  = 0x00001000;
			int messageSize = 255;
			String lpMsgBuf = "";
			int dwFlags = FORMAT_MESSAGE_ALLOCATE_BUFFER | FORMAT_MESSAGE_FROM_SYSTEM | FORMAT_MESSAGE_IGNORE_INSERTS;
			IntPtr ptrlpSource = new IntPtr();
			IntPtr prtArguments = new IntPtr();
			int retVal = FormatMessage(dwFlags, ref ptrlpSource, errorCode, 0, 
				ref lpMsgBuf, messageSize, &prtArguments);
			if(retVal == 0)
			{
				throw new Exception("Failed to format message for error code " + errorCode + ". ");
			}
			return lpMsgBuf;
		}

		#endregion

	}
}
