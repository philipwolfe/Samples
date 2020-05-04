using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace BE.pinvoke2006
{
    public partial class UploadForm : Form
    {
        public UploadForm()
        {
            InitializeComponent();
        }

        void UpdateContributeButton()
        {
            contributeButton.Enabled = usernameTextBox.Text.Length != 0 && signaturesTextBox.Text.Length != 0;
        }

        private void usernameTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateContributeButton();
        }

        private void signaturesTextBox_TextChanged(object sender, EventArgs e)
        {
            UpdateContributeButton();
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void contributeButton_Click(object sender, EventArgs e)
        {
            Program.ConstributeSignatures(usernameTextBox.Text, signaturesTextBox.Text);
        }
    }
}