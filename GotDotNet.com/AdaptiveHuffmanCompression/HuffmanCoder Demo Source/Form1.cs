using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Text;

using Toub.IO;
using Toub.Compression;

namespace Toub.Demos
{
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnCompress;
		private System.Windows.Forms.Button btnDecompress;
		private System.Windows.Forms.Label label2;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//
			// TODO: Add any constructor code after InitializeComponent call
			//
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		protected override void Dispose( bool disposing )
		{
			if( disposing )
			{
				if (components != null) 
				{
					components.Dispose();
				}
			}
			base.Dispose( disposing );
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.btnCompress = new System.Windows.Forms.Button();
			this.btnDecompress = new System.Windows.Forms.Button();
			this.label2 = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(144, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "Compress a file:";
			// 
			// btnCompress
			// 
			this.btnCompress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnCompress.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnCompress.Location = new System.Drawing.Point(8, 32);
			this.btnCompress.Name = "btnCompress";
			this.btnCompress.Size = new System.Drawing.Size(80, 23);
			this.btnCompress.TabIndex = 1;
			this.btnCompress.Text = "Compress";
			this.btnCompress.Click += new System.EventHandler(this.btnCompress_Click);
			// 
			// btnDecompress
			// 
			this.btnDecompress.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
			this.btnDecompress.ForeColor = System.Drawing.SystemColors.Desktop;
			this.btnDecompress.Location = new System.Drawing.Point(8, 104);
			this.btnDecompress.Name = "btnDecompress";
			this.btnDecompress.Size = new System.Drawing.Size(80, 23);
			this.btnDecompress.TabIndex = 3;
			this.btnDecompress.Text = "Decompress";
			this.btnDecompress.Click += new System.EventHandler(this.btnDecompress_Click);
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label2.ForeColor = System.Drawing.SystemColors.Desktop;
			this.label2.Location = new System.Drawing.Point(8, 80);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(144, 23);
			this.label2.TabIndex = 2;
			this.label2.Text = "Decompress a file:";
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(170, 141);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.btnDecompress,
																		  this.label2,
																		  this.btnCompress,
																		  this.label1});
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
			this.Name = "Form1";
			this.Text = "Huffman Demo";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new Form1());
		}

		/* ================================================================================
		 * ================================================================================
		 * ================================================================================ */

		/// <summary>Compress a file.</summary>
		private void btnCompress_Click(object sender, System.EventArgs e)
		{
			// Show the open file dialog
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select a file to compress";
			ofd.Filter = "All Files (*.*)|*.*";
			if (ofd.ShowDialog() == DialogResult.OK) 
			{
				// Show the save file dialog
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Save the compressed file as";
				sfd.Filter = "Adaptive Huffman Demo Files (*.ahd)|*.ahd";
				sfd.DefaultExt = "ahd";
				if (sfd.ShowDialog() == DialogResult.OK) 
				{
					// Read in the file and write it out compressed
					using (FileStream input = new FileStream(ofd.FileName, FileMode.Open)) 
					{
						using (FileStream output = new FileStream(sfd.FileName, FileMode.Create))
						{
							AdaptiveHuffmanProvider.Compress(input, output);
						}
					}
				}
			}
		}

		/// <summary>Decompress a file.</summary>
		private void btnDecompress_Click(object sender, System.EventArgs e)
		{
			// Show the open file dialog
			OpenFileDialog ofd = new OpenFileDialog();
			ofd.Title = "Select a file to deccompress";
			ofd.Filter = "Adaptive Huffman Demo Files (*.ahd)|*.ahd";
			ofd.DefaultExt = "ahd";
			if (ofd.ShowDialog() == DialogResult.OK) 
			{
				// Show the save file dialog
				SaveFileDialog sfd = new SaveFileDialog();
				sfd.Title = "Save the decompressed file as";
				sfd.Filter = "All Files (*.*)|*.*";
				if (sfd.ShowDialog() == DialogResult.OK) 
				{
					// Read in the file and write it out decompressed
					using (FileStream input = new FileStream(ofd.FileName, FileMode.Open)) 
					{
						using (FileStream output = new FileStream(sfd.FileName, FileMode.Create))
						{
							AdaptiveHuffmanProvider.Decompress(input, output);
						}
					}
				}
			}
		}
	}
}
