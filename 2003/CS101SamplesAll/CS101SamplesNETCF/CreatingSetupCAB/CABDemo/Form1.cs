using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32; // For Registry Classes

namespace CreatingSetupCAB
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            // Display the OK button for closing the application.
            MinimizeBox = false;
        }
        
        // The purpose of this click event is to verify that the values placed
        // in the registry by the CAB Setup program are actually in the registry.
        // The registry values are read and displayed on the form.
        private void ReadRegistryButton_Click(object sender, EventArgs e)
        {
            // Registry path
            const string regPath = @"SOFTWARE\CABDemo";
            RegistryKey appKey = null;
            try
            {
                // Get current setting from the registry
                appKey = Registry.CurrentUser.OpenSubKey(regPath, false);
                if (appKey == null)
                {
                    // Registry SubKey does not exist...is the sample being run in the emulator?
                    MessageLabel.Text = "No Info in Registry.";
                    VersionLabel.Text = "No Info in Registry.";
                    throw new Exception("Registry Sub Key does not exist.  You must install the CAB file and run this sample from a physical device.");
                }
                MessageLabel.Text = (string) appKey.GetValue("Message");
                VersionLabel.Text = (string) appKey.GetValue("Version");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (appKey != null)
                    appKey.Close();
            }
        }

    }
}