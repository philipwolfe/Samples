using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Security; //  For SecureString
using System.Text.RegularExpressions;
using System.Runtime.InteropServices; //  For the Marshal class

namespace UsingSecureString
{
    public partial class Form1 : Form
    {
        SecureString password = new SecureString();

        public Form1()
        {
            InitializeComponent();

            ToolTip myToolTip = new ToolTip();

            //  Set up the ToolTip text for the Button and Checkbox.
            myToolTip.SetToolTip(PasswordTextBox, "Type Password Slowly");
            myToolTip.SetToolTip(LoginButton, "Click to login");
            myToolTip.SetToolTip(VerifyButton, "Click to Verify Password");

        }

        //  KeyUp Event
        //  This sample has a limitation on how fast keys can be accepted.  This is because the KeyUp event
        //  uses the Text property of the control to determine the last key typed.  If more KeyUp events occur before 
        //  the Text value is updated, the password will have multiple '*' values instead of typed characters.  
        //  To remove this limitation, handle each key event and translate the KeyCode into the actual char 
        //  accounting for the shift key and place this char in the password variable.  The intent here is to 
        //  demonstrate how to insert chars securely into a SecureString, not to write production code to 
        //  handle multiple events occurring before the Text property is updated.
        private void PasswordTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            //  Use the IsReadOnly method to test whether an instance of SecureString is read-only.
            if (password.IsReadOnly())
            {
                //  Dispose of the old instance and create a new instance to basically start 
                //  over because once password is read only (by clicking the Login button) it can not be modified
                password.Dispose();
                //  zero out the current password in memory
                password = new SecureString();
            }
            //  Get value of char typed into textbox
            if ((PasswordTextBox.Text != String.Empty))
            {
                if (((e.KeyCode != Keys.Back) && (e.KeyCode != Keys.Delete)))
                {
                    //  Get lastchar only char only
                    char ch = PasswordTextBox.Text.ToCharArray()[PasswordTextBox.Text.Length - 1];
                    password.AppendChar(ch);
                    PasswordTextBox.Text = PasswordTextBox.Text.Replace(".", "*");
                    PasswordTextBox.SelectionStart = PasswordTextBox.Text.Length;
                }
            }
        }

        // There will be situations where the user will type a char and then type the backspace key and continue 
        // or completely clear out the text and start over, so handle this change here
        private void PasswordTextBox_TextChanged(object sender, EventArgs e)
        {
            //  Use the IsReadOnly method to test whether an instance of SecureString is read-only.
            if (password.IsReadOnly())
            {
                //  Dispose of the old instance and create a new instance to basically start 
                //  over because once password is read only (by clicking the Login button) it can not be modified
                password.Dispose();  //  zero out the current password in memory
                password = new SecureString();
            }
            //  See if there is a difference in lengths between the TextBox and the password
            if ((PasswordTextBox.Text.Length != password.Length))
            {
                if ((PasswordTextBox.Text == String.Empty))
                {
                    //  user cleared textbox, so clear password as well
                    password.Clear(); 
                }
                else if ((PasswordTextBox.Text.Length < password.Length))
                {
                    //  Remove last char...assuming only last char removed with backspace key
                    password.RemoveAt((password.Length - 1));
                }
            }
        }

        private void LoginButton_Click(object sender, EventArgs e)
        {
            //  Use the MakeReadOnly method to make the value of the instance immutable (read-only). 
            //  After the value is marked as read-only, any further attempt to modify it 
            //  throws an InvalidOperationException. 
            //  The effect of invoking MakeReadOnly is permanent because no means is 
            //  provided to make the secure string modifiable again. 
            password.MakeReadOnly();
        }

        private void VerifyButton_Click(object sender, EventArgs e)
        {
            IntPtr bstr =Marshal.SecureStringToBSTR(password);
            try
            {
                //  Get password.  As soon as the password is assigned to the Label's text property the
                //  password is no longer secure because there are now unencrypted copies of the string in memory.
                //  In this sample, we are unsecuring our password by displaying it in order to verify it was 
                //  set correctly.
                PasswordVerifyLabel.Text = Marshal.PtrToStringBSTR(bstr);
            }
            finally
            {
                //  Zero out memory of bstr for security...don't want any extra copy laying around in memory
                Marshal.ZeroFreeBSTR(bstr);
            }
        }
    }
}