using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Configuration;
using System.Text;
using System.Windows.Forms;

namespace ClientConfiguration
{
    public partial class Form1 : Form
    {

        public Form1()
        {
            InitializeComponent();

			// Add a setting at runtime.
            PrepareSettings();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DisplayUser();
            LoadSettings();
        }

        public void DisplayUser()
        {
            System.Security.Principal.WindowsIdentity currentUser = System.Security.Principal.WindowsIdentity.GetCurrent();
            userIdentityTextBox.Text = currentUser.Name;
        }

		// Typically, Application and User settings will be 
		// defined at design time, in which case they are
		// accessible via the strongly typed Settings class.
		// But, it is possible to add settings programmatically,
		// though they will not be saved with the 
        // Properties.Settings.Default.Properties.Save method call.
		public void PrepareSettings()
		{
            // For dynamically added setings, make sure the setting doesn't 
            // exist already, for future proofing.
            if ( Properties.Settings.Default.Properties["comboBoxDefaultSetting"] == null)
			{
				// Create a new setting.
				SettingsProperty comboBoxDefaultSetting = new SettingsProperty("comboBoxDefaultSetting");
				comboBoxDefaultSetting.PropertyType = typeof(String);
				comboBoxDefaultSetting.DefaultValue = "Ipsum";
				Properties.Settings.Default.Properties.Add(comboBoxDefaultSetting);
			}
		}

		public void LoadSettings()
		{
			// Retrieve and set the location of the ToolStrips
            ToolStripManager.LoadSettings(this);

			// userBoolSetting was defined at design time using the Settings Designer window.
			// So its value is available via the Settings class.
			// Note the setting value is a boolean.  Settings in 
			// Visual Studio 2005 are strongly typed, and support custom types and objects.
			this.checkBox1.Checked = Properties.Settings.Default.userBoolSetting;

			// comboBoxDefaultSetting was defined above, dynamically,
			// and so it is not available in the Settings class.
			// Must use Settings.Properties
			this.comboBox1.SelectedIndex = this.comboBox1.FindStringExact(ClientConfiguration.Properties.Settings.Default.Properties["comboBoxDefaultSetting"].DefaultValue.ToString());

            this.userStringTextBox.Text = Properties.Settings.Default.userStringSetting;
            this.userIntNumPicker.Value = Properties.Settings.Default.userIntSetting;

            this.appStringTextBox.Text = Properties.Settings.Default.appStringSetting;
            this.appIntNumPicker.Value = Properties.Settings.Default.appIntSetting;
		}

		public void SaveSettings()
		{
			// Save the location of the ToolStrips
            ToolStripManager.SaveSettings(this);

			// Save changed settings
			Properties.Settings.Default.Save();
		}

		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			SaveSettings();
		}

		private void saveUserPrefsButton_Click(object sender, EventArgs e)
		{
			SaveSettings();
		}

        private void setCheckBox1DefaultButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.userBoolSetting = checkBox1.Checked;
        }

        private void setUserStringDefaultButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.userStringSetting = userStringTextBox.Text;
        }

        private void setUserIntDefaultButton_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.userIntSetting = (int) userIntNumPicker.Value;
        }

		private void setComboBoxDefaultButton_Click(object sender, EventArgs e)
		{
			// This setting was added at runtime, so its is not a Property the in Settings wrapper.
			// Must use the wrapper Properties 
			Properties.Settings.Default.Properties["comboBoxDefaultSetting"].DefaultValue = comboBox1.Text;
		}

		private void newToolStripButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("The New button was clicked.", this.Text);
		}

		private void openToolStripButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("The Open button was clicked.", this.Text);
		}

		private void saveToolStripButton_Click(object sender, EventArgs e)
		{
			MessageBox.Show("The Save button was clicked.", this.Text);
		}
    }
}