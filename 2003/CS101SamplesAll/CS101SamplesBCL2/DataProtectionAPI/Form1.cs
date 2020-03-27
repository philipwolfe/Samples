using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Security.Cryptography;
using System.IO;

namespace DataProtectionAPI
{
    public partial class Form1 : Form
    {
        // Store the encrypted memory here so it can be decrypted with the Decrypt button
        private byte[] secureData;

        // Value stored for efficient binary file read
        private int secureDataByteCount;

        // Store optional encryption entropy here for use in decryption process
        private byte[] entropy;

        // Constructor...Init entropy and SelectedIndex which forces change event
        public Form1()
        {
            InitializeComponent();

            //  Create some random entropy for later use
            entropy = CreateRandomEntropy();
            EncryptedDestinationComboBox.SelectedIndex = 0; //  Init to Memory Type
            DecryptButton.Enabled = false;
        }

        //  ProtectData
        //  Call the ProtectedData.Protect method to create an encrypted byte array and 
        //  store the encrpyted result in a file.  Also alert user
        //  to any exception that might be thrown by displaying an error message
        private byte[] ProtectData(byte[] data)
        {
            byte[] bytes = null;
            try
            {
                //  Get an encrypted copy of the data
                bytes = ProtectedData.Protect(data, entropy, DataProtectionScope.CurrentUser);
                //  Create and write to file
                FileStream stream = new FileStream(WriteFileTextBox.Text, FileMode.OpenOrCreate);
                try
                {
                    //  Write the encrypted data to a stream.
                    if ((stream.CanWrite && !(bytes == null)))
                    {
                        stream.Write(bytes, 0, bytes.Length);
                    }
                }
                finally
                {
                    stream.Close();
                }
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("The userData parameter is a null reference(Nothing in Visual Basic.");
            }
            catch (CryptographicException)
            {
                MessageBox.Show("The cryptographic protection failed.");
            }
            catch (PlatformNotSupportedException)
            {
                MessageBox.Show("The operating system does not support this method. " +
                    "This method can be used only with Microsoft Windows 2000 or later operating systems.");
            }
            catch (OutOfMemoryException)
            {
                MessageBox.Show("The system ran out of memory while encrypting the data.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return bytes;
        }

        //  ProtectMemory
        //  Call the ProtectedMemory.Protect method to encrypt a byte array. Also alert user
        //  to any exception that might be thrown by displaying an error message
        private byte[] ProtectMemory(byte[] data)
        {
            try
            {
                //  Data must be in multiples of 16 bytes so pad with spaces at end that 
                //  can be trimmed during decryption
                int i;
                int extraBytes = 0;
                int len = data.Length;
                if (((len % 16)!= 0))
                {
                    extraBytes = (16 - (len % 16));
                }

                if ((extraBytes != 0))
                {

                    byte[] tmp = new byte[len + extraBytes];
                    Array.Copy(data, 0, tmp, 0, data.Length);
                    data = tmp;
                    for (i = len; i < (len + extraBytes); i++)
                    {
                        data[i] = 32; //  ascii value for space
                    }
                }
                ProtectedMemory.Protect(data, MemoryProtectionScope.SameProcess);
            }
            catch (CryptographicException) 
            {
                MessageBox.Show("UserData must be 16 bytes in length or in multiples of 16 bytes.");
            }
            catch (PlatformNotSupportedException) 
            {
                MessageBox.Show("The operating system does not support this method. " + 
                    "This method can be used only with Microsoft Windows 2000 or later operating systems.");
            }
            catch (Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            return data;
        }

        //  UnprotectData
        //  Call the ProtectedData.Unprotect method to decrypt the class member
        //  variable secureData created by the Protect Method.  Also alert user
        //  to any exception that might be thrown by displaying an error message
        private byte[] UnprotectData(int byteCount)
        {
            byte[] bytes = null;
            byte[] buffer = new byte[byteCount];
            try
            {
                //  Read from the stream and decrypt the data.
                //  Open the file.
                FileStream stream = new FileStream(WriteFileTextBox.Text, FileMode.Open);
                try
                {
                    //  Read the encrypted data from a stream.
                    if (stream.CanRead)
                    {
                        stream.Read(buffer, 0, byteCount);
                    }
                    else
                    {
                        throw new IOException("Could not read the stream.");
                    }
                }
                finally
                {
                    stream.Close();
                }
                //  Decrypt the data.
                bytes = ProtectedData.Unprotect(buffer, entropy, DataProtectionScope.CurrentUser);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("The encryptedData parameter is a null reference(Nothing in Visual Basic).");
            }
            catch (CryptographicException)
            {
                MessageBox.Show("The cryptographic protection failed.");
            }
            catch (PlatformNotSupportedException)
            {
                MessageBox.Show("The operating system does not support this method. " +
                    "This method can be used only with Microsoft Windows 2000 or later operating systems.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return bytes;
        }

        //  UnprotectMemory
        //  Call the ProtectedMemory.Unprotect method to decrypt the class member
        //  variable secureData created by the ProtectMemory Method.  Also alert user
        //  to any exception that might be thrown by displaying an error message
        private byte[] UnprotectMemory(byte[] bytes)
        {
            try
            {
                //  Decrypt the data.
                ProtectedMemory.Unprotect(bytes, MemoryProtectionScope.SameProcess);
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("The encryptedData parameter is a null reference(Nothing in Visual Basic).");
            }
            catch (CryptographicException)
            {
                MessageBox.Show("The cryptographic protection failed.");
            }
            catch (PlatformNotSupportedException)
            {
                MessageBox.Show("The operating system does not support this method. " +
                    "This method can be used only with Microsoft Windows 2000 or later operating systems.");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return bytes;
        }

        //  BytesToString
        //  Helper function that converts a byte array into its ascii value equivalent.
        //  Returns a string of ascii character values separated by a spaces
        private string BytesToString(byte[] bytes)
        {
            int i;
            StringBuilder builder = new StringBuilder();
            for (i = 0; i < bytes.Length; i++)
            {
                builder.Append(bytes[i] + " ");
            }
            return builder.ToString();
        }

        private byte[] CreateRandomEntropy()
        {
            byte[] entropy = new byte[16];

            //  Create a new instance of the RNGCryptoServiceProvider.
            //  Fill the array with a random value and return
            RNGCryptoServiceProvider RNG = new RNGCryptoServiceProvider();
            RNG.GetBytes(entropy);
            return entropy;
        }

        private void EncryptButton_Click(object sender, EventArgs e)
        {
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            byte[] bytes = encoding.GetBytes(DataTextBox.Text);

            //  Show raw bytes in text box
            RawBytesTextBox.Text = BytesToString(bytes);
            if ((EncryptedDestinationComboBox.SelectedIndex == 1))
            {
                //  Encrypt to File
                secureData = ProtectData(bytes);
                secureDataByteCount = secureData.Length;
            }
            else
            {
                //  Encrypt to Memory
                secureData = ProtectMemory(bytes);
            }
            //  Show encrypted bytes in TextBox
            EncryptedBytesTextBox.Text = BytesToString(secureData);
            DecryptButton.Enabled = true;
        }

        private void DecryptButton_Click(object sender, EventArgs e)
        {
            byte[] bytes;
            if ((EncryptedDestinationComboBox.SelectedIndex == 1))
            {
                //  Decrypt File
                bytes = UnprotectData(secureDataByteCount);
            }
            else
            {
                //  Decrypt Memory
                bytes = UnprotectMemory(secureData);
            }
            System.Text.ASCIIEncoding encoding = new System.Text.ASCIIEncoding();
            VerifyTextBox.Text = encoding.GetString(bytes).TrimEnd();
            //  Trim padding
            DecryptButton.Enabled = false;
        }

        private void EncryptedDestinationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (EncryptedDestinationComboBox.SelectedIndex == 0)
            {
                WriteFileTextBox.Visible = false;
                FileNameLabel.Visible = false;
            }
            else
            {
                WriteFileTextBox.Visible = true;
                FileNameLabel.Visible = true;
            }
        }
    }
}