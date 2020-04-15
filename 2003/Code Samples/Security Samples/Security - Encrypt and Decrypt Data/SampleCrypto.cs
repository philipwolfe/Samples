//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System.IO;
using System.Security.Cryptography;
using System.Threading;
using System;
using System.Diagnostics;

class SampleCrypto
{

    // This routine creates a new symmetric algorithm object of the chosen type.

    public SampleCrypto(string strCryptoName)
	{
        // The shared Create method of the abstract symmetric algorithm base class
        // implements a factory design for the creation of its concrete classes.
        crpSym = SymmetricAlgorithm.Create(strCryptoName);
        // Initialize the byte arrays to the proper length for the 
        // instantiated crypto class.
        ReDimByteArrays();

    }

    private byte[] abytIV;
    private byte[] abytKey;
    private byte[] abytSalt;
    private SymmetricAlgorithm crpSym;
    private string strPassword = string.Empty;
    private string strSaltIVFile = string.Empty;
    private string strSourceFile = string.Empty;

    public string Password
	{
        get {
            return strPassword;
        }
        set {
            strPassword = value;
        }
    }

    public string SaltIVFile
	{
        get {

            return strSaltIVFile;

        }

        set {

			if (File.Exists(value)) 
			{
				strSaltIVFile = value;
			}
			else 
			{
				throw new FileNotFoundException("The SaltIV .dat file for the " +
					"selected crypto type was not found. Before encrypting or " +
				"decrypting you must create this file.");

			}

        }

    }

    public string SourceFileName
	{
        get {

            return strSourceFile;

        }

        set {

			if (File.Exists(value)) 
			{

				strSourceFile = value;
			}
			else 
			{

				throw new FileNotFoundException(value + " does not exist.");

			}

        }

    }

    // This routine creates a .dat file containing the salt and IV.

    public bool CreateSaltIVFile(string strSaveToPath)
	{
        // Initialize the byte arrays to the proper length for the 
        // instantiated crypto class.

        ReDimByteArrays();

        // Create a Filestream object to write the salt and IV to a file.

        FileStream fsKey = new FileStream(strSaveToPath, FileMode.OpenOrCreate, 
            FileAccess.Write);

        // Generate a random "salt" value. These random bytes are appended to the
        // password before the key derivation, making what a "Dictionary
        // Attack" much more difficult. The concept is similar to the use of an IV.

        RandomNumberGenerator rng = RandomNumberGenerator.Create();

        rng.GetBytes(abytSalt);

        PasswordDeriveBytes pdb = new PasswordDeriveBytes(strPassword, abytSalt);

        // Get the same amount of bytes the current abytKey length set in 
        // ReDimByteArrays().

        abytKey = pdb.GetBytes(abytKey.Length);

        // Generate a new random IV.

        crpSym.GenerateIV();
        abytIV = crpSym.IV;

		try 
		{
			fsKey.Write(abytSalt, 0, abytSalt.Length);
			fsKey.Write(abytIV, 0, abytIV.Length);
			strSaltIVFile = strSaveToPath;
			return true;

		} 
		catch( Exception exp)
		{
			throw new Exception(exp.Message);
		}
        finally
		{
            fsKey.Close();

        }

    }

    // This routine decrypts a file.

    public void DecryptFile()
	{
        // if the password is an empty string assume the user has not checked the 
        // "Advanced" CheckBox or has not entered a password and thus is not using
        // a password-derived key. In such a case the symmetric algorithm object 
        // will just use its default values.

        if (strPassword != "") {

            OpenSaltIVFileAndSetKeyIV();

        }

        // Create a FileStream object to read back the encrypted file.

        FileStream fsCipherText = new FileStream(strSourceFile, FileMode.Open, FileAccess.Read);

        // Create a FileStream object to write to the temp file.

        FileStream fsPlainText = new FileStream("temp.dat", FileMode.Create, FileAccess.Write);

        // Read in the encrypted file and decrypt.

        CryptoStream csDecrypted = new CryptoStream(fsCipherText, crpSym.CreateDecryptor(), 
            CryptoStreamMode.Read);

        // Create a StreamWriter to write to the temp file.

        StreamWriter swWriter = new StreamWriter(fsPlainText);

        // Read the decrypted stream into a StreamReader.

        StreamReader srReader = new StreamReader(csDecrypted);

		try 
		{

			// Write out the decrypted stream.

			swWriter.Write(srReader.ReadToEnd());

		} 
		catch( CryptographicException expCrypto)
		{
			throw new CryptographicException();
		}
        finally
		{
            // Close and clean up.

            swWriter.Close();
            csDecrypted.Close();

        }

        SwapFiles(true);

    }

    // This routine encrypts a file.

    public void EncryptFile()
	{
        // if the password is an empty string assume the user has not checked the 
        // "Advanced" CheckBox and thus is not using a password-derived key. In such
        // a case the symmetric algorithm object will just its default values.

        if (strPassword != "") {

            OpenSaltIVFileAndSetKeyIV();

        }

        // Create a FileStream object to read in the source file.

        FileStream fsInput = new FileStream(strSourceFile, FileMode.Open, FileAccess.Read);

        // Create a byte array from the FileStream object by reading in the 
        // source file.

        byte[] abytInput = new byte[Convert.ToInt32(fsInput.Length)];
        fsInput.Read(abytInput, 0, Convert.ToInt32(fsInput.Length));
        fsInput.Close();

        // Create a FileStream object to write to a temp file.

        FileStream fsCipherText = new FileStream("temp.dat", FileMode.Create, FileAccess.Write);
        fsCipherText.SetLength(0);

        // Create a Crypto Stream that transforms the file stream using the chosen 
        // encryption and writes it to the output FileStream object.

        CryptoStream csEncrypted = new CryptoStream(fsCipherText, crpSym.CreateEncryptor(), 
            CryptoStreamMode.Write);

        // Pass in the unencrypted source file byte array and write out 
        // the encrypted bytes to the temp.dat file. Thus, the logic flow is:
        // abytInput ----> Encryption ----> fsCipherText.

        csEncrypted.Write(abytInput, 0, abytInput.Length);

        // When the bytes are all written it's important to indicate to the crypto 
        // stream that you are through using it, and thus to finish processing any 
        // bytes remaining in the buffer used by the crypto stream. Typically this 
        // involves padding the last output block to a complete multiple of the crypto 
        // object's block size (for Rijndael this is 16 bytes, or 128 bits), 
        // encrypting it, and then writing this final block to the memory stream.

        csEncrypted.FlushFinalBlock();

        // Clean up. There is no need to call fsCipherText.Close() because closing the
        // crypto stream automatically encloses the stream that was passed into it.

        csEncrypted.Close();

        SwapFiles(false);

    }

    // This routine opens the .dat file, reads in the salt and IV, and then
    // sets the crypto object's key and IV.

    private void OpenSaltIVFileAndSetKeyIV()
	{
        // Initialize the byte arrays to the proper length for the 
        // instantiated crypto class.

        ReDimByteArrays();

        // Create a Filestream object to read in the contents of the .dat file
        // that contains the salt and IV.

        FileStream fsKey = new FileStream(strSaltIVFile, FileMode.Open, FileAccess.Read);
        fsKey.Read(abytSalt, 0, abytSalt.Length);
        fsKey.Read(abytIV, 0, abytIV.Length);
        fsKey.Close();

        // Derive the key from the salted password.

        PasswordDeriveBytes pdb = new PasswordDeriveBytes(strPassword, abytSalt);

        // Get the same amount of bytes the current abytKey length set in 

        // ReDimByteArrays().

        abytKey = pdb.GetBytes(abytKey.Length);

        // if the current crypto class is TripleDES, check to make sure the key being 
        // used is not listed among the Weak Keys (i.e., keys known to have been 
        // successfully attacked).

        if (crpSym.GetType() == typeof(TripleDESCryptoServiceProvider)) 
		{

            // To access the IsWeakKey method you have to cast the SymmetricAlgorithm
            // variable type to the TripleDES base class or 
            // TripleDESCryptoServiceProvider.

            TripleDES tdes = (TripleDES) crpSym;
			
            if (TripleDES.IsWeakKey(abytKey)) {

                throw new Exception("The current key is listed a Weak Key. " + 
                    "You should generate a different key before proceeding further.");

            }

        }

        // Assign the byte arrays to the Key and IV properties of the instantiated
        // symmetric crypto class. 

        crpSym.Key = abytKey;
        crpSym.IV = abytIV;

    }

    // This routine redimensions the byte arrays to the proper length for the 
    // instantiated crypto class.

    private void ReDimByteArrays()
	{

        // For demo/info purposes only, write out the legal key sizes.

        Debug.WriteLine(crpSym.GetType().ToString() + " legal key sizes in bits:");

        foreach(KeySizes myKeySizes in crpSym.LegalKeySizes)
		{
                Debug.WriteLine("Max=" + myKeySizes.MaxSize + " bits " + 
                    "(" + (myKeySizes.MaxSize / 8) + " bytes)");

                Debug.WriteLine("Min=" + myKeySizes.MinSize + " bits " + 
                   "(" + (myKeySizes.MinSize / 8) + " bytes)");

                Debug.WriteLine("Skip=" + myKeySizes.SkipSize + " bits " + 
                   "(" + (myKeySizes.SkipSize / 8) + " bytes)");
        }

		if (crpSym.GetType() == typeof(System.Security.Cryptography.RijndaelManaged)) 
		{

			// The Key byte array size was retrieved via the LegalKeySizes property 
			// of the crypto object. See the Debug.WriteLine statements that follow. 
			// Keep in mind that the array size is always one more than the upper 
			// bound, which you use to initialize the array. So the Resizes are 
			// 1 less than the legal key sizes acquired above.

			abytKey = new byte[31];

			// A good rule-of-thumb is to make the salt 1/2 the length of the key. For
			// more information on what "salt" is, see SetKeyIVAndSaveToFile().

			abytSalt = new byte[15];

			// There is no "LegalIVSizes" property like there is for key sizes. 

			// Therefore, to figure out the valid IV byte array length you can do the

			// following:

			//       crpSym.GenerateIV()

			//       abytIV = crpSym.IV

			//       Debug.WriteLine("Valid abytIV.Length=" + abytIV.Length.ToString()

			abytIV = new byte[15];
		}
		else 
		{
			abytKey = new byte[23];
			abytSalt = new byte[11];
			abytIV = new byte[7];
		}

    }

    // This helper routine copies the temp file contents to the source file
    // during encryption and decryption.

    private void SwapFiles(bool UseFileAccessWait)
	{

        if (UseFileAccessWait) 
		{

            WaitForExclusiveAccess(strSourceFile);

        }

        // Replace the source file with the temp file and delete the temp file.

        File.Copy("temp.dat", strSourceFile, true);
        File.Delete("temp.dat");

    }

    // This helper routine is needed to gain access to a file that has recently
    // been read from. It is used only after decryption.

    private void WaitForExclusiveAccess(string fullPath)
	{
        while (true)
		{
            try {
                FileStream fs = new FileStream(fullPath, FileMode.Append, 
                    FileAccess.Write, FileShare.None);
                fs.Close();
                return;

           } catch
			{
                Thread.Sleep(300);

            }

        }

    }

}

