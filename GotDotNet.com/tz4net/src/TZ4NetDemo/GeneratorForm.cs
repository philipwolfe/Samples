using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using TZ4Net;

namespace TZ4NetDemo
{
	/// <summary>
	/// Summary description for GeneratorForm.
	/// </summary>
	public class GeneratorForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox textBox1;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.TextBox textBox2;
		private System.Windows.Forms.Button button2;
		private System.Windows.Forms.GroupBox groupBox2;
		private System.Windows.Forms.Button button3;
		private System.Windows.Forms.RichTextBox richTextBox1;
		private System.Windows.Forms.TextBox textBox3;
		private System.Windows.Forms.GroupBox groupBox3;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;

		public GeneratorForm()
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
				if(components != null)
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
			this.button1 = new System.Windows.Forms.Button();
			this.textBox1 = new System.Windows.Forms.TextBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.textBox2 = new System.Windows.Forms.TextBox();
			this.button2 = new System.Windows.Forms.Button();
			this.groupBox2 = new System.Windows.Forms.GroupBox();
			this.button3 = new System.Windows.Forms.Button();
			this.richTextBox1 = new System.Windows.Forms.RichTextBox();
			this.textBox3 = new System.Windows.Forms.TextBox();
			this.groupBox3 = new System.Windows.Forms.GroupBox();
			this.SuspendLayout();
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(48, 184);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(64, 24);
			this.button1.TabIndex = 1;
			this.button1.Text = "Select...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// textBox1
			// 
			this.textBox1.Location = new System.Drawing.Point(120, 184);
			this.textBox1.Name = "textBox1";
			this.textBox1.Size = new System.Drawing.Size(344, 20);
			this.textBox1.TabIndex = 2;
			this.textBox1.Text = "";
			// 
			// groupBox1
			// 
			this.groupBox1.Location = new System.Drawing.Point(32, 160);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(448, 56);
			this.groupBox1.TabIndex = 0;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "zoneinfo root directory (folder that contains zoneinfo files to be imported)";
			// 
			// textBox2
			// 
			this.textBox2.Location = new System.Drawing.Point(120, 248);
			this.textBox2.Name = "textBox2";
			this.textBox2.Size = new System.Drawing.Size(344, 20);
			this.textBox2.TabIndex = 5;
			this.textBox2.Text = "";
			// 
			// button2
			// 
			this.button2.Location = new System.Drawing.Point(48, 248);
			this.button2.Name = "button2";
			this.button2.Size = new System.Drawing.Size(64, 24);
			this.button2.TabIndex = 4;
			this.button2.Text = "Select...";
			this.button2.Click += new System.EventHandler(this.button2_Click);
			// 
			// groupBox2
			// 
			this.groupBox2.Location = new System.Drawing.Point(32, 224);
			this.groupBox2.Name = "groupBox2";
			this.groupBox2.Size = new System.Drawing.Size(448, 56);
			this.groupBox2.TabIndex = 3;
			this.groupBox2.TabStop = false;
			this.groupBox2.Text = "TZ4Net project directory (destination folder for zoneinfo.resources file)";
			// 
			// button3
			// 
			this.button3.Location = new System.Drawing.Point(32, 288);
			this.button3.Name = "button3";
			this.button3.Size = new System.Drawing.Size(64, 23);
			this.button3.TabIndex = 7;
			this.button3.Text = "Generate";
			this.button3.Click += new System.EventHandler(this.button3_Click);
			// 
			// richTextBox1
			// 
			this.richTextBox1.Location = new System.Drawing.Point(32, 312);
			this.richTextBox1.Name = "richTextBox1";
			this.richTextBox1.ScrollBars = System.Windows.Forms.RichTextBoxScrollBars.Vertical;
			this.richTextBox1.Size = new System.Drawing.Size(448, 108);
			this.richTextBox1.TabIndex = 8;
			this.richTextBox1.Text = "";
			this.richTextBox1.WordWrap = false;
			// 
			// textBox3
			// 
			this.textBox3.AcceptsReturn = true;
			this.textBox3.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBox3.Location = new System.Drawing.Point(48, 24);
			this.textBox3.Multiline = true;
			this.textBox3.Name = "textBox3";
			this.textBox3.ReadOnly = true;
			this.textBox3.Size = new System.Drawing.Size(424, 120);
			this.textBox3.TabIndex = 9;
			this.textBox3.Text = @"This release contains tzdata2006a.tar.gz version of zoneinfo files.To upgrade the files with the new version, execute the following commands on your GNU/Linux or similar host:
	mkdir tz
	cd tz
	wget 'ftp://elsie.nci.nih.gov/pub/tz*.tar.gz'
	gzip -dc tzcode*.tar.gz | tar -xf -
	gzip -dc tzdata*.tar.gz | tar -xf -
	make TOPDIR=$HOME/tzdir install
and update the etc folder of this solution with the new content.";
			// 
			// groupBox3
			// 
			this.groupBox3.Location = new System.Drawing.Point(32, 8);
			this.groupBox3.Name = "groupBox3";
			this.groupBox3.Size = new System.Drawing.Size(448, 144);
			this.groupBox3.TabIndex = 10;
			this.groupBox3.TabStop = false;
			this.groupBox3.Text = "Note:";
			// 
			// GeneratorForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(512, 437);
			this.Controls.Add(this.textBox3);
			this.Controls.Add(this.textBox2);
			this.Controls.Add(this.textBox1);
			this.Controls.Add(this.richTextBox1);
			this.Controls.Add(this.button3);
			this.Controls.Add(this.button2);
			this.Controls.Add(this.groupBox2);
			this.Controls.Add(this.button1);
			this.Controls.Add(this.groupBox1);
			this.Controls.Add(this.groupBox3);
			this.Name = "GeneratorForm";
			this.ShowInTaskbar = false;
			this.Text = "GeneratorForm";
			this.Load += new System.EventHandler(this.GeneratorForm_Load);
			this.ResumeLayout(false);

		}
		#endregion

		private string GetFolder() 
		{
			FolderPicker folderPicker = null;
			Cursor oldCursor = this.Cursor;
			this.Cursor = Cursors.WaitCursor;
			DialogResult res = DialogResult.Cancel;
			try 
			{
				folderPicker = new FolderPicker();
				folderPicker.StartPosition = FormStartPosition.CenterParent;
				res = folderPicker.ShowDialog(this);
			} 
			finally 
			{
				this.Cursor = oldCursor;
			}
			if (res == DialogResult.OK)
			{
				return folderPicker.Info.FullName;
			} 
			else 
			{
				return null;
			}
		}

		private void OnValueChanged(object sender, EventArgs e) 
		{
			this.Text = string.Format("'{0}' resource generator", this.textBox1.Text);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			string folder = GetFolder();
			if (folder != null) 
			{
				this.textBox1.Text = folder;
				OnValueChanged(sender, e);
			}
		}

		private void button2_Click(object sender, System.EventArgs e)
		{
			string folder = GetFolder();
			if (folder != null) 
			{
				this.textBox2.Text = folder;
				OnValueChanged(sender, e);
			}
		}

		private void GeneratorForm_Load(object sender, System.EventArgs e)
		{
			this.textBox1.Text = new DirectoryInfo(".\\..\\..\\..\\..\\etc\\zoneinfo").FullName;
			this.textBox2.Text = new DirectoryInfo(".\\..\\..\\..\\TZ4Net").FullName;
			OnValueChanged(sender, e);
		}

		private void button3_Click(object sender, System.EventArgs e)
		{
			ZoneInfoResGen.Added += new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Added);
			ZoneInfoResGen.Skipped += new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Skipped);
			ZoneInfoResGen.Generated += new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Generated);
			this.richTextBox1.Clear();
			try 
			{
				ZoneInfoResGen.Generate(this.textBox1.Text, this.textBox2.Text);
			} 
			finally 
			{
				ZoneInfoResGen.Added -= new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Added);
				ZoneInfoResGen.Skipped -= new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Skipped);
				ZoneInfoResGen.Generated -= new ZoneInfoResGenUpdateHandler(ZoneInfoResGen_Generated);
			}

		}

		private void WriteLine(string text) 
		{ 
			this.richTextBox1.Focus();
			this.richTextBox1.AppendText(string.Format("{0}\n", text));
			this.richTextBox1.Select(richTextBox1.Text.Length, 0);
			this.richTextBox1.ScrollToCaret();
		}

		private void ZoneInfoResGen_Added(object sender, ZoneInfoResGenUpdateArgs args) 
		{
			WriteLine(string.Format("Added resource: {0} ({1} bytes).", args.FileName, new FileInfo(args.FileName).Length));
		}

		private void ZoneInfoResGen_Skipped(object sender, ZoneInfoResGenUpdateArgs args) 
		{
			WriteLine(string.Format("Skipped file: {0}. 'TZif' signature not found.", args.FileName));
		}

		private void ZoneInfoResGen_Generated(object sender, ZoneInfoResGenUpdateArgs args) 
		{
			WriteLine(string.Format("Generated resource file: {0} ({1} bytes).", args.FileName, new FileInfo(args.FileName).Length));
		}
	}
}
