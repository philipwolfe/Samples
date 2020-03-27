using System;
using System.Diagnostics;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace LaunchApp
{

    public partial class Form1 : Form
    {
        private StringCollection outputLines = new StringCollection();

        public Form1()
        {
            InitializeComponent();

            lvNativeImageCache.Columns[0].Width = 300;
            lvNativeImageCache.Columns[1].Width = 77;
            lvNativeImageCache.Columns[2].Width = 72;
            lvNativeImageCache.Columns[3].Width = 200;
        }

        private void btnInstall_Click(object sender, EventArgs e)
        {
            Cursor saveCursor = null;

            try
            {
                // Allow the user to browse for an assembly to install.
                OpenFileDialog fileDialog = new OpenFileDialog();
                fileDialog.Filter = "Executable Assemblies (*.exe)|*.exe|Class Library Assemblies (*.dll)|*.dll";
                fileDialog.CheckFileExists = true;
                fileDialog.CheckPathExists = true;
                fileDialog.DereferenceLinks = true;
                if (DialogResult.OK == fileDialog.ShowDialog())
                {
                    saveCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;

                    StringCollection output = NGenController.Run(NGenCommand.Install, fileDialog.FileName);

                    this.Cursor = saveCursor;

                    // Refresh the list of installed images if it was already visible.
                    if (lvNativeImageCache.Items != null && lvNativeImageCache.Items.Count > 0)
                        btnViewCache_Click(sender, e);
                }

            }
            catch (Exception)
            {
                if (saveCursor != null)
                    this.Cursor = saveCursor;
            }
        }

        /// <summary>
        /// Uninstalls the selected image in lvNativeImageCache from the Native Image Cache.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnUninstall_Click(object sender, EventArgs e)
        {
            Cursor saveCursor = null;

            try
            {

                // Iterate through the selected items and remove from the Native Image Cache.
                foreach (int i in lvNativeImageCache.SelectedIndices)
                {
                    string name = lvNativeImageCache.Items[i].SubItems[0].Text;

                    if (chkConfirm.Checked)
                    {
                        DialogResult result = MessageBox.Show(String.Format("Are you sure you want to remove {0} from the Native Image Cache?", name), "Confirm Remove", MessageBoxButtons.YesNo);
                        if (result == DialogResult.No)
                        {
                            continue;
                        }
                    }

                    saveCursor = this.Cursor;
                    this.Cursor = Cursors.WaitCursor;

                    StringCollection output = NGenController.Run(NGenCommand.Uninstall, name);

                    this.Cursor = saveCursor;
                }

                btnUninstall.Enabled = false;

                // Refresh the list of installed images.
                btnViewCache_Click(sender, e);

            }
            catch (Exception)
            {
                if (saveCursor != null)
                    this.Cursor = saveCursor;
            }
        }

        private void btnViewCache_Click(object sender, EventArgs e)
        {
            Cursor saveCursor = null;

            try
            {
                lvNativeImageCache.Items.Clear();

                saveCursor = this.Cursor;
                this.Cursor = Cursors.WaitCursor;

                StringCollection output = NGenController.Run(NGenCommand.Display, null);

                if (output != null)
                {
                    // Write out the native images to the listview.
                    ParseNGENOutput(output);
                }

                this.Cursor = saveCursor;
            }
            catch (Exception)
            {
                if (saveCursor != null)
                    this.Cursor = saveCursor;
            }
        }

        private void ParseNGENOutput(StringCollection ngenOutput)
        {
            if (ngenOutput == null)
                return;

            bool nativeImageSectionReached = false;

            foreach (string line in ngenOutput)
            {
                if (nativeImageSectionReached)
                {
                    if (line.Trim().Length > 0)
                    {
                        string[] assemblyNameParts = line.Split(new char[] { ',' });

                        if (assemblyNameParts.Length >= 4)
                        {
                            int index = assemblyNameParts[1].IndexOf("=");
                            assemblyNameParts[1] = assemblyNameParts[1].Substring(index + 1);

                            index = assemblyNameParts[2].IndexOf("=");
                            assemblyNameParts[2] = assemblyNameParts[2].Substring(index + 1);

                            index = assemblyNameParts[3].IndexOf("=");
                            assemblyNameParts[3] = assemblyNameParts[3].Substring(index + 1);

                            lvNativeImageCache.Items.Add(new ListViewItem(assemblyNameParts));
                        }
                    }
                }
                else
                {
                    nativeImageSectionReached = (String.Compare(line.Trim(), 0, "Native Images:", 0, 14) == 0);
                }                   
            }

            if (lvNativeImageCache.Items.Count > 1)
            {
                lvNativeImageCache.Sorting = SortOrder.Ascending;
                lvNativeImageCache.Sort();
            }
        }

        private void lvNativeImageCache_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnUninstall.Enabled = true;
        }
    }
}