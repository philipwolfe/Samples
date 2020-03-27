using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace CompressionSample
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            _zipUtil = new ZipUtil ( );

            this.openFileDialog1.FileName = "";
            this.saveFileDialog1.FileName = "";
        }

        private void BrowseDestination_Click ( object sender, EventArgs e )
        {
            this.saveFileDialog1.FileName = "";

            if ( this.saveFileDialog1.ShowDialog ( ) == DialogResult.OK )
                this.DestinationFile.Text = this.saveFileDialog1.FileName;
        }

        private void BrowseSource_Click ( object sender, EventArgs e )
        {
            if ( this.openFileDialog1.ShowDialog ( ) == DialogResult.OK )
            {
                this.SourceFile.Text = this.openFileDialog1.FileName;
                string newFileName = Path.GetFileNameWithoutExtension ( this.SourceFile.Text ) + ".zip";
                this.saveFileDialog1.FileName = newFileName;
            }
        }

        private void Compress_Click ( object sender, EventArgs e )
        {
            if ( this.SourceFile.Text.Length > 0 & this.DestinationFile.Text.Length > 0 )
            {
                _zipUtil.CompressFile ( this.SourceFile.Text, this.DestinationFile.Text );

                MessageBox.Show ( "Successfully compressed " + this.SourceFile.Text + " to " + this.DestinationFile.Text, "Compression Sample", MessageBoxButtons.OK, MessageBoxIcon.Information );

                this.DestinationFile.Text = "";
                this.SourceFile.Text = "";
            }
        }

        private void Decompress_Click ( object sender, EventArgs e )
        {
            if ( this.SourceFile.Text.Length > 0 & this.DestinationFile.Text.Length > 0 )
            {
                _zipUtil.DecompressFile ( this.SourceFile.Text, this.DestinationFile.Text );

                MessageBox.Show ( "Successfully decompressed " + this.SourceFile.Text + " to " + this.DestinationFile.Text, "Compression Sample", MessageBoxButtons.OK, MessageBoxIcon.Information );

                this.DestinationFile.Text = "";
                this.SourceFile.Text = "";
            }
        }

        // disable both buttons if there is no path for the source & destination files
        private void DestinationSource_TextChange(object sender, EventArgs e)
        {
            bool bEnabled = false;
            if (this.SourceFile.Text.Length > 0 & this.DestinationFile.Text.Length > 0)
            {
                bEnabled = true;
            }
            this.Decompress.Enabled = this.Compress.Enabled = bEnabled;
        }
       
        
        private ZipUtil _zipUtil;
    }
}