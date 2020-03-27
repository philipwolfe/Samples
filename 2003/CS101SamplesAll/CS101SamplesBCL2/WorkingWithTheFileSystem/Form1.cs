using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;
using Microsoft.VisualBasic;

namespace WorkingWithTheFileSystem {
    public partial class Form1 : Form {

        #region Declarations

        // Initial folder paths.
        private string sourcePath = Path.GetFullPath(@"..\..\DemoDataOne");
        private string destPath = Path.GetFullPath(@"..\..\DemoDataTwo");

        #endregion

        #region Constructor

        public Form1() {
            InitializeComponent();
        }

        #endregion

        #region Event Procedures

        private void Form1_Load(object sender, EventArgs e) {
            // Initialize list box tags.
            sourceListBox.Tag = string.Empty;
            destListBox.Tag = String.Empty;

            // Load file lists with initial working folders.
            LoadFileList(sourceListBox, sourcePath);
            LoadFileList(destListBox, destPath);

            if (sourceListBox.Items.Count > 0) {
                sourceListBox.SelectedIndex = 0;
            }
        }

        private void browseLeft_Click(object sender, EventArgs e) {
            // FolderBrowserDialog lets the user select a folder.
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;

            if (sourcePathTextBox.Text.Trim().Length == 0) {
                fbd.SelectedPath = sourcePath;
            }
            else {
                fbd.SelectedPath = sourcePathTextBox.Text.Trim();
            }

            if (fbd.ShowDialog(this) == DialogResult.OK) {
                LoadFileList(sourceListBox, fbd.SelectedPath);
            }
        }

        private void browseRight_Click(object sender, EventArgs e) {
            // FolderBrowserDialog lets the user select a folder.
            FolderBrowserDialog fbd = new FolderBrowserDialog();
            fbd.ShowNewFolderButton = false;

            if (destPathTextBox.Text.Trim().Length == 0) {
                fbd.SelectedPath = destPath;
            }
            else {
                fbd.SelectedPath = destPathTextBox.Text.Trim();
            }

            if (fbd.ShowDialog(this) == DialogResult.OK) {
                LoadFileList(destListBox, fbd.SelectedPath);
            }
        }

        private void sourceListBox_SelectedIndexChanged(object sender, EventArgs e) {
            HandleButtons();
        }

        private void closeButton_Click(object sender, EventArgs e) {
            this.Close();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e) {
            this.Close();
        }

        #endregion

        #region File Action Procedures

        private void copyButton_Click(object sender, EventArgs e) {
            string sourceFilePath = Path.Combine(sourceListBox.Tag.ToString(),
                sourceListBox.SelectedItem.ToString());
            string destFilePath = Path.Combine(destListBox.Tag.ToString(),
                sourceListBox.SelectedItem.ToString());

            // The Exists method makes it easy to determine whether the 
            // file's already there.
            if (File.Exists(destFilePath)) {
                if (!Confirm("OK to overwrite?")) {
                    return;
                }
            }

            // Copy the file. The "true" parameter means "overwrite if necessary."            
            File.Copy(sourceFilePath, destFilePath, true);
            LoadFileList(destListBox);
        }

        private void moveButton_Click(object sender, EventArgs e) {
            string sourceFilePath = Path.Combine(sourceListBox.Tag.ToString(),
                sourceListBox.SelectedItem.ToString());
            string destFilePath = Path.Combine(destListBox.Tag.ToString(),
                sourceListBox.SelectedItem.ToString());

            // Unlike File.Copy, File.Move has no boolean parameter to permit
            // overwriting the destination file, so if the file already exists,
            // you have to delete it before executing the move.
            if (File.Exists(destFilePath)) {
                if (Confirm("OK to overwrite?")) {
                    File.Delete(destFilePath);
                }
                else {
                    return;
                }
            }

            // Move the file to the new location. You can choose to give it a new
            // name in the new folder. For example, you can move "C:\MyFile.txt"
            // to "D:\MyBrandNewFile.txt."            
            File.Move(sourceFilePath, destFilePath);

            LoadFileList(destListBox);
            LoadFileList(sourceListBox);
        }

        private void deleteButton_Click(object sender, EventArgs e) {
            string sourceFilePath = Path.Combine(sourceListBox.Tag.ToString(),
                sourceListBox.SelectedItem.ToString());

            // File deletion is easy. Just call the File.Delete method.
            if (Confirm("Are you sure?")) {
                File.Delete(sourceFilePath);
                LoadFileList(sourceListBox);
            }
        }

        private void fileInfoButton_Click(object sender, EventArgs e) {
            string selectedFile = sourceListBox.SelectedItem.ToString();
            string selectedFilePath = Path.Combine(
                sourceListBox.Tag.ToString(),
                selectedFile);

            // Unlike the File class, you must create an instance of the FileInfo 
            // class in order to access its properties and methods. You need this 
            // class to get information such as file length, creation date and time, 
            // and last modified time date and time.
            FileInfo fi = new FileInfo(selectedFilePath);
            string fileInformation = String.Format("File Info for {1}{0}" +
                "  Size: {2} bytes{0}" +
                "  Created: {3}{0}" +
                "  Last modified: {4}{0}" +
                "  Location: {5}{0}",
                Environment.NewLine, selectedFile, fi.Length, fi.CreationTime,
                fi.LastWriteTime, fi.DirectoryName);
            ShowInfoMessage(fileInformation);
        }

        private void createButton_Click(object sender, EventArgs e) {
            string newFileName = Interaction.InputBox("New file name",
                "Create File", String.Empty, this.Left + 225, this.Top + 100);

            if (newFileName.Length > 0) {
                // Create the file. Using the "using" statement ensures that the
                // handle representing the new file is released, so you can delete
                // or move it if you choose to. 
                using (FileStream fs =
                    File.Create(Path.Combine(sourceListBox.Tag.ToString(), newFileName)))

                    // Load up the modified file list.
                    LoadFileList(sourceListBox);
            }
        }

        private void openButton_Click(object sender, EventArgs e) {
            string sourceFilePath = Path.Combine(sourceListBox.Tag.ToString(),
                sourceListBox.SelectedItem.ToString());

            try {
                // The File.OpenText method lets you open a text file for reading.
                // The StreamReader class provides a means for reading a stream of bytes 
                // from a file. The ReadToEnd method gets all bytes from the current 
                // position to the end.
                string result;
                using (StreamReader sr = File.OpenText(sourceFilePath))
                result = sr.ReadToEnd();

                // Display the content in a second form.
                Form2 frm = new Form2();
                frm.contentTextBox.Text = result;
                frm.ShowDialog(this);
            }
            catch (Exception ex) {
                ShowInfoMessage(ex.Message);
            }
        }

        private void LoadFileList(ListBox lb) {
            string selectedPath = lb.Tag.ToString();
            LoadFileList(lb, selectedPath);
        }

        private void LoadFileList(ListBox lb, string selectedPath) {

            lb.Items.Clear();
            lb.Tag = selectedPath;

            // The static/shared GetFiles method of the Directory class returns an 
            // array containing all the files in the specified folder.
            string[] allFiles = Directory.GetFiles(selectedPath);
            foreach (string fl in allFiles) {
                lb.Items.Add(Path.GetFileName(fl));
            }

            sourcePathTextBox.Text = sourceListBox.Tag.ToString();
            destPathTextBox.Text = destListBox.Tag.ToString();
            HandleButtons();
        }

        #endregion

        #region Utility Procedures

        private bool Confirm(string msg) {
            if (MessageBox.Show(msg, "Confirm", MessageBoxButtons.YesNo,
                MessageBoxIcon.Question) == DialogResult.Yes) {
                return true;
            }
            else {
                return false;
            }
        }

        private void HandleButtons() {
            // Enable buttons only when a file is selected.
            bool fileIsSelected = sourceListBox.SelectedIndex >= 0;
            copyButton.Enabled = fileIsSelected;
            moveButton.Enabled = fileIsSelected;
            deleteButton.Enabled = fileIsSelected;
            fileInfoButton.Enabled = fileIsSelected;
            openButton.Enabled = fileIsSelected;
        }

        private void ShowInfoMessage(string msg) {
            MessageBox.Show(msg, "Info", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        #endregion

    }
}
