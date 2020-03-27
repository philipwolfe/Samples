using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Security.Cryptography;

namespace EncryptingDecryptingData {
    public partial class Form1 : Form {

        #region Declarations

        // The default work location.
        private string workFolder = Path.GetFullPath(@"..\..\DemoData");

        // The default file to read from.
        private string m_clearFileName = "Data.txt";

        // The files with your public/private key pair. In production, you would guard
        // your key extremely carefully. Best practice would be to store your key pair
        // in a key container, not in an XML file.
        private string m_sendersKeyFileName = @"..\..\SendersKey.xml";

        // The file with the receiver's public key. You will use this key to encrypt
        // data that only the receiver can decrypt, using his private key.
        string m_rsaKeyString = string.Empty;

        #endregion

        #region Constructor

        public Form1() {
            InitializeComponent();
            if (File.Exists(m_sendersKeyFileName)) {
                m_rsaKeyString = ReadRSAKeysFromXmlFile(m_sendersKeyFileName);
            }
            else {
                string msg = "Symmetrical key file not found. Create?";
                if (MessageBox.Show(msg, "Missing File", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.OK) {
                    WriteRSAKeysToXmlFile(new RSACryptoServiceProvider(),
                        m_sendersKeyFileName);
                }
            }
        }

        #endregion

        #region Event Procedures

        private void Form1_Load(object sender, EventArgs e) {
            workFolderTextBox.Text = workFolder;
            clearFileTextBox.Text = m_clearFileName;
            SetFileNames();
        }

        private void loadClearDataButton_Click(object sender, EventArgs e) {
            string fileToRead = SetFilePath(clearFileTextBox.Text.Trim());

            if (File.Exists(fileToRead)) {
                StreamReader sr = new StreamReader(fileToRead, Encoding.UTF7);
                String clearData = sr.ReadToEnd();
                sr.Close();

                clearDataTextBox.Text = clearData;
            }
            else {
                MessageBox.Show("File does not exist.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void loadDecryptedDataButton_Click(object sender, EventArgs e) {
            string fileToRead = SetFilePath(decryptedFileTextBox.Text.Trim());

            if (File.Exists(fileToRead)) {
                StreamReader sr = new StreamReader(fileToRead, Encoding.UTF7);
                String clearData = sr.ReadToEnd();
                sr.Close();

                clearDataTextBox.Text = clearData;
            }
            else {
                MessageBox.Show("File does not exist.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void encryptButton_Click(object sender, EventArgs e) {
            string fileToRead = SetFilePath(clearFileTextBox.Text);
            string fileToWrite = SetFilePath(encryptedFileTextBox.Text);

            if (File.Exists(fileToRead)) {
                if (OkToWriteFile(fileToWrite)) {
                    EncryptFile(fileToRead, fileToWrite);
                    MessageBox.Show("Encryption successful", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else {
                MessageBox.Show("File does not exist.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void decryptButton_Click(object sender, EventArgs e) {
            string fileToRead = SetFilePath(encryptedFileTextBox.Text);
            string fileToWrite = SetFilePath(decryptedFileTextBox.Text);

            if (File.Exists(fileToRead)) {
                if (OkToWriteFile(fileToWrite)) {
                    DecryptFile(fileToRead, fileToWrite,
                       fileToRead + ".keyandiv");
                    MessageBox.Show("Decryption successful", "Success",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else {
                MessageBox.Show("File does not exist.", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

        private void clearFileTextBox_TextChanged(object sender, EventArgs e) {
            SetFileNames();
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        #endregion

        #region Encryption Procedures

        private bool EncryptFile(string inputFile, string outputFile) {
            RijndaelManaged myRijndael = new RijndaelManaged();
            myRijndael.KeySize = 192;
            myRijndael.GenerateKey();
            myRijndael.GenerateIV();

            // Prepare file streams and crypto stream.
            FileStream fsIn = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            FileStream fsOut = new FileStream(outputFile, FileMode.Create, FileAccess.Write);
            CryptoStream myCryptoStream = new CryptoStream(fsOut,
                myRijndael.CreateEncryptor(myRijndael.Key,
                myRijndael.IV), CryptoStreamMode.Write);

            // Prepare variables.
            int bufferSize = 4096; // number of bytes to read at a time.
            byte[] buffer = new byte[bufferSize];
            long inputFileSize = new FileInfo(inputFile).Length;
            int bytesRead = 0;
            long totalBytesRead = 0;

            // Read a block at a time until end of file.
            while (totalBytesRead < inputFileSize) {
                bytesRead = fsIn.Read(buffer, 0, bufferSize);
                myCryptoStream.Write(buffer, 0, bytesRead);
                totalBytesRead += (long)bytesRead;
            }

            // Clean up.
            myCryptoStream.FlushFinalBlock();
            myCryptoStream.Close();
            fsIn.Close();
            fsOut.Close();

            // Encrypt the key and vector asymmetrically, and write them to a file 
            // based on the name of the file being encrypted.
            byte[] encryptedKeyAndIV = EncryptKeyAndIV(myRijndael.Key, myRijndael.IV);
            fsOut = new FileStream(outputFile + ".keyandiv", FileMode.Create, FileAccess.Write);
            fsOut.Write(encryptedKeyAndIV, 0, encryptedKeyAndIV.Length);
            fsOut.Close();

            return true;
        }

        private bool DecryptFile(string inputFile, string outputFile, string encryptedKeyFile) {
            FileStream sr = new FileStream(encryptedKeyFile, FileMode.Open, FileAccess.Read);

            // Encrypted key and IV are both 128-byte arrays.
            byte[] symKey = new byte[128];
            byte[] symIV = new byte[128];

            sr.Read(symKey, 0, 128);
            sr.Read(symIV, 0, 128);
            sr.Close();

            DecryptKeyAndIV(ref symKey, ref symIV);

            RijndaelManaged myRijndael = new RijndaelManaged();
            myRijndael.Key = symKey;
            myRijndael.IV = symIV;

            // Prepare file stream and crypto stream.
            FileStream fsIn = new FileStream(inputFile, FileMode.Open, FileAccess.Read);
            CryptoStream myCryptoStream = new CryptoStream(fsIn,
                myRijndael.CreateDecryptor(myRijndael.Key,
                myRijndael.IV), CryptoStreamMode.Read);

            StreamWriter sw = new StreamWriter(outputFile, false, Encoding.UTF8);
            sw.Write(new StreamReader(myCryptoStream).ReadToEnd());

            // Clean up.
            sw.Flush();
            sw.Close();
            fsIn.Close();
            myCryptoStream.Close();

            return true;
        }

        // Encrypt the symmetric key and initialization vector. You use asymmetric
        // encryption to encrypt the symmetric key and vector, since asymmetric
        // encryption does not require a shared key.
        //
        // Typically, you encrypt the main document symmetrically, then encrypt the
        // symmetric key and vector using the recipient's public key. The recipient
        // can decrypt the key and IV using their private key, which is available
        // to no-one else.
        //
        // In this sample, the sender's public and private keys are used for both
        // encryption and decryption.
        private byte[] EncryptKeyAndIV(byte[] key, byte[] iv) {
            RSACryptoServiceProvider rsaProv = new RSACryptoServiceProvider();

            // Get the asymmetric key information from an XML file.
            rsaProv.FromXmlString(m_rsaKeyString);

            MemoryStream ms = new MemoryStream();
            byte[] encryptedKey = rsaProv.Encrypt(key, false);
            ms.Write(encryptedKey, 0, encryptedKey.Length);

            byte[] encryptedIV = rsaProv.Encrypt(iv, false);
            ms.Write(encryptedIV, 0, encryptedIV.Length);

            return ms.ToArray();
        }

        // Decrypt the symmetric key and IV. They will then be used to decrypt
        // the main document.
        private bool DecryptKeyAndIV(ref byte[] key, ref byte[] iv) {
            RSACryptoServiceProvider rsaProv = new RSACryptoServiceProvider();

            // Get the asymmetric key information from an XML file.
            rsaProv.FromXmlString(m_rsaKeyString);

            key = rsaProv.Decrypt(key, false);
            iv = rsaProv.Decrypt(iv, false);

            return true;
        }

        #endregion

        #region RSAKeyManagement

        // In this region you'll see how you can save and retrieve the keys from an
        // RSACryptoServiceProvider. This NOT the optimum way to do it, it's done
        // here simply for convenience. You should use a key container. See the
        // documentation for more.
        //
        // There's no user interface in this sample for these functions.

        private bool WriteRSAKeysToXmlFile(RSACryptoServiceProvider rsaProv, string xmlFileToWrite) {
            string rsaKeyString = rsaProv.ToXmlString(true);

            StreamWriter sw = new StreamWriter(xmlFileToWrite);
            sw.Write(rsaKeyString);
            sw.Close();

            return true;
        }

        private string ReadRSAKeysFromXmlFile(string xmlFileToRead) {
            StreamReader sr = File.OpenText(xmlFileToRead);
            string rsaKeyString = sr.ReadToEnd();
            sr.Close();

            return rsaKeyString;
        }

        #endregion

        #region Utility Functions

        private void SetFileNames() {
            string fileName = Path.GetFileNameWithoutExtension(clearFileTextBox.Text.Trim());
            string fileExt = Path.GetExtension(clearFileTextBox.Text.Trim());

            encryptedFileTextBox.Text = fileName + "_encrypted." + fileExt;
            decryptedFileTextBox.Text = fileName + "_decrypted." + fileExt;
        }

        private string SetFilePath(string fileName) {
            return Path.Combine(workFolder, fileName);
        }

        private bool OkToWriteFile(string filePath) {
            if (File.Exists(filePath.Trim())) {
                string fileName = Path.GetFileName(filePath);
                string msg = "OK to overwrite " + fileName + "?";
                if (MessageBox.Show(msg, "Replace?", MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question) == DialogResult.Yes) {
                    return true;
                }
                else
                    return false;
            }
            else {
                return true;
            }
        }

        #endregion

    }
}
