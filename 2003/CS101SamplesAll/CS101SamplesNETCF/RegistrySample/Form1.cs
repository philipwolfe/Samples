using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using Microsoft.Win32;

namespace RegistrySample
{
    public partial class Form1 : Form
    {
        private const string regPath = @"SOFTWARE\RegistrySample";

        public Form1()
        {
            InitializeComponent();

             // Create the root key in the registry
            RegistryKey key = Registry.CurrentUser.CreateSubKey(regPath);
            key.Close(); // flush to file

            // Set Form to close instead of minimize
            MinimizeBox = false;

            // Show current state of registry at our regPath
            UpdateTreeView();
        }

        private RegistryKey GetRegKey(string keyName)
        {
            // If the KeyName is empty, then want the parent key only
            string subKeyName = regPath;
            if (keyName != string.Empty)
            {
                subKeyName = regPath + @"\" + keyName;
            }

            // Get key from registry based on subKeyName
            RegistryKey key = null;
            try
            {
                key = Registry.CurrentUser.OpenSubKey(subKeyName, true); // Open with write access
                if (key == null)
                    throw new Exception("Registry Sub Key '" + subKeyName + " does not exist.  Please create first before performing this task.");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
            return key;
        }

        // Create Registry Key
        private void CreateRegKey(string subKeyName, string name, string value)
        {
            RegistryKey key = null;
            RegistryKey subKey = null;
            try
            {
                key = Registry.CurrentUser.OpenSubKey(regPath, true);
                subKey = key.OpenSubKey(subKeyName, true); // Get SubKey if it exists

                // Create SubKey if it does not exist
                if (subKey == null)
                {
                    subKey = key.CreateSubKey(subKeyName);
                }

                // Only create value if there is a name
                if (name != String.Empty)
                {
                    subKey.SetValue(name, value);
                }
            }
            catch (Exception ex)
            {   
                MessageBox.Show("Error: " + ex.Message);
            }
            finally
            {
                if (key != null)
                    key.Close(); // flush to file
                if (subKey != null)
                    subKey.Close(); // flush to file
            }
        }

        // Change or create a value for this name under this subKeyName 
        private void UpdateRegKey(string subKeyName, string name, string value)
        {
            RegistryKey regKey = GetRegKey(subKeyName);

            if (regKey != null)
            {
                regKey.SetValue(name, value);
                regKey.Close(); // flush to file
            }
        }

        // Display the current state of the registry in the format of the TreeView
        private void UpdateTreeView()
        {
            // Get the RegistrySample Node (virtual rootNode as all nodes above are fixed and will not change)
            TreeNode rootNode = RegTreeView.Nodes[0].Nodes[0].Nodes[0];

            // Remove everything under the RegistrySample Node
            rootNode.Nodes.Clear();

            // Get root key from registry
            RegistryKey rootKey = Registry.CurrentUser.OpenSubKey(regPath, false);

            // Loop through subkeys and their values and place in the treeview
            int i, j;
            for (i = 0; i < rootKey.SubKeyCount; i++)
            {
                string subKeyName = rootKey.GetSubKeyNames()[i];
                RegistryKey subKey = rootKey.OpenSubKey(subKeyName);
                TreeNode subKeyNode = rootNode.Nodes.Add(subKeyName);

                // Loop through values for a subkey
                for (j = 0; j < subKey.GetValueNames().Length; j++)
                {
                    string valueName = subKey.GetValueNames()[j];
                    string nameValue = valueName + ": " + subKey.GetValue(valueName).ToString();
                    subKeyNode.Nodes.Add(nameValue);
                }
            }
            RegTreeView.ExpandAll(); // Expand treeview automatically
        }

        private void CreateButton_Click(object sender, EventArgs e)
        {
            CreateRegKey(KeyTextBox.Text, NameTextBox.Text, ValueTextBox.Text);
            UpdateTreeView();
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
           RegistryKey regKey = GetRegKey(string.Empty); // Get parent key of key that will be deleted
            if (regKey != null)
            {
                try
                {
                    // Delete the selected name / value if it exists
                    if (NameTextBox.Text != string.Empty)
                    {
                        RegistryKey subKey = GetRegKey(KeyTextBox.Text);
                        subKey.DeleteValue(NameTextBox.Text);
                    }
                    regKey.DeleteSubKey(KeyTextBox.Text); // Delete desired key
                    regKey.Close(); // flush to file
                }
                catch (UnauthorizedAccessException ex)
                {
                    // Catch here so program can run gracefully
                    // According to current documentation DeleteSubKey should delete keys without
                    // throwing an exception.  Catch this specific exception here and hope by release time
                    // the OpenSubKey(string, boolean) and DeleteSubKey(string) methods will work correctly.
                    MessageBox.Show("Error: " + ex.Message + "\n\rDelete and specifically RegistryKey.OpenSubKey(string, boolean) may not be supported until final release");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
                UpdateTreeView();
            }
        }

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            UpdateRegKey(KeyTextBox.Text, NameTextBox.Text, ValueTextBox.Text);
            UpdateTreeView();
        }
        
        private void RegTreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode node = RegTreeView.SelectedNode;

            // The name value pair were written by this application as "name: value" so we
            // should be able to split this string appropriately
            char[] splitChar = {':'};
            string[] nameValuePair = node.Text.Split(splitChar);
            
            if ((node.Nodes.Count == 0) && (nameValuePair.Length > 1))
            {
                // handle case where name / value is selected
                KeyTextBox.Text = node.Parent.Text;
                NameTextBox.Text = nameValuePair[0];
                ValueTextBox.Text = nameValuePair[1].Trim();
            }
            else
            {
                // SubKey was selected
                KeyTextBox.Text = node.Text;
                NameTextBox.Text = string.Empty;
                ValueTextBox.Text = string.Empty;
            }
        }
    }
}