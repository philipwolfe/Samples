using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using ConvertCSharp2VB;
using System.IO;

namespace ConvertCSharp2VB_Offline
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		private System.Windows.Forms.LinkLabel lblAuthorSite;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button cmdLoad;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TextBox txtCSharp;
		private System.Windows.Forms.TabPage tabPage2;
		private System.Windows.Forms.TextBox txtVB;
		private System.Windows.Forms.Button cmdConvert;
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
			this.lblAuthorSite = new System.Windows.Forms.LinkLabel();
			this.label1 = new System.Windows.Forms.Label();
			this.cmdLoad = new System.Windows.Forms.Button();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.txtCSharp = new System.Windows.Forms.TextBox();
			this.tabPage2 = new System.Windows.Forms.TabPage();
			this.txtVB = new System.Windows.Forms.TextBox();
			this.cmdConvert = new System.Windows.Forms.Button();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.tabPage2.SuspendLayout();
			this.SuspendLayout();
			// 
			// lblAuthorSite
			// 
			this.lblAuthorSite.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.lblAuthorSite.AutoSize = true;
			this.lblAuthorSite.Location = new System.Drawing.Point(134, 434);
			this.lblAuthorSite.Name = "lblAuthorSite";
			this.lblAuthorSite.Size = new System.Drawing.Size(137, 13);
			this.lblAuthorSite.TabIndex = 16;
			this.lblAuthorSite.TabStop = true;
			this.lblAuthorSite.Text = "http://www.KamalPatel.net";
			this.lblAuthorSite.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.lblAuthorSite_LinkClicked);
			// 
			// label1
			// 
			this.label1.Anchor = System.Windows.Forms.AnchorStyles.Bottom;
			this.label1.AutoSize = true;
			this.label1.Location = new System.Drawing.Point(134, 418);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(447, 13);
			this.label1.TabIndex = 15;
			this.label1.Text = "Send questions, comments, suggestions and bugs to Kamal Patel (kppatel@yahoo.com)" +
				"";
			// 
			// cmdLoad
			// 
			this.cmdLoad.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left);
			this.cmdLoad.Location = new System.Drawing.Point(8, 422);
			this.cmdLoad.Name = "cmdLoad";
			this.cmdLoad.TabIndex = 14;
			this.cmdLoad.Text = "&Load File";
			this.cmdLoad.Click += new System.EventHandler(this.cmdLoad_Click);
			// 
			// tabControl1
			// 
			this.tabControl1.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.tabPage1,
																					  this.tabPage2});
			this.tabControl1.Location = new System.Drawing.Point(8, 6);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(704, 408);
			this.tabControl1.TabIndex = 13;
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.txtCSharp});
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(696, 382);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "C# Code for Conversion";
			// 
			// txtCSharp
			// 
			this.txtCSharp.AcceptsReturn = true;
			this.txtCSharp.AcceptsTab = true;
			this.txtCSharp.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.txtCSharp.AutoSize = false;
			this.txtCSharp.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtCSharp.Location = new System.Drawing.Point(8, 8);
			this.txtCSharp.MaxLength = 327670;
			this.txtCSharp.Multiline = true;
			this.txtCSharp.Name = "txtCSharp";
			this.txtCSharp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtCSharp.Size = new System.Drawing.Size(680, 368);
			this.txtCSharp.TabIndex = 1;
			this.txtCSharp.Text = "";
			this.txtCSharp.WordWrap = false;
			// 
			// tabPage2
			// 
			this.tabPage2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.txtVB});
			this.tabPage2.Location = new System.Drawing.Point(4, 22);
			this.tabPage2.Name = "tabPage2";
			this.tabPage2.Size = new System.Drawing.Size(696, 382);
			this.tabPage2.TabIndex = 1;
			this.tabPage2.Text = "Generated VB .NET Code";
			this.tabPage2.Visible = false;
			// 
			// txtVB
			// 
			this.txtVB.AcceptsReturn = true;
			this.txtVB.AcceptsTab = true;
			this.txtVB.Anchor = (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
				| System.Windows.Forms.AnchorStyles.Left) 
				| System.Windows.Forms.AnchorStyles.Right);
			this.txtVB.AutoSize = false;
			this.txtVB.BackColor = System.Drawing.SystemColors.Desktop;
			this.txtVB.Font = new System.Drawing.Font("Lucida Console", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.txtVB.ForeColor = System.Drawing.SystemColors.HighlightText;
			this.txtVB.Location = new System.Drawing.Point(8, 8);
			this.txtVB.MaxLength = 327670;
			this.txtVB.Multiline = true;
			this.txtVB.Name = "txtVB";
			this.txtVB.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.txtVB.Size = new System.Drawing.Size(680, 368);
			this.txtVB.TabIndex = 2;
			this.txtVB.Text = "";
			this.txtVB.WordWrap = false;
			// 
			// cmdConvert
			// 
			this.cmdConvert.Anchor = (System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right);
			this.cmdConvert.Location = new System.Drawing.Point(624, 422);
			this.cmdConvert.Name = "cmdConvert";
			this.cmdConvert.Size = new System.Drawing.Size(80, 24);
			this.cmdConvert.TabIndex = 12;
			this.cmdConvert.Text = "&Convert";
			this.cmdConvert.Click += new System.EventHandler(this.cmdConvert_Click);
			// 
			// Form1
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(720, 453);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.lblAuthorSite,
																		  this.label1,
																		  this.cmdLoad,
																		  this.tabControl1,
																		  this.cmdConvert});
			this.Name = "Form1";
			this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
			this.Text = "Convert C# to VB .NET";
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.tabPage2.ResumeLayout(false);
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

		/// <summary>
		/// Converts the C# source code to VB .NET
		/// </summary>
		/// <param name="sender"></param>
		/// <param name="e"></param>
		private void cmdConvert_Click(object sender, System.EventArgs e)
		{
			//Convert the C# source to VB .NET
			CSharpToVBConverter o = new CSharpToVBConverter();
			this.txtVB.Text = o.Execute(this.txtCSharp.Text);

			//Change the Page in the Tab Control so we can see the changes
			this.tabControl1.SelectedTab = this.tabControl1.TabPages[1];
		
		}

		/// <summary>
		/// Loads the FileDialog and prompts to open a file
		/// </summary>
		/// <returns></returns>
		private string GetFile()
		{	
			string lcFile = "";	
			string lcFilter = "C# Files (*.cs)|*.cs|All files (*.*)|*.*" ;	
			//int lnFilterIndex = 2;	
			//string lcTitle = "Open";

			//Create the OpenFileDialog (note that the FileDialog class is an abstract and cannot be used directly)	
			OpenFileDialog ofd = new OpenFileDialog();		
			ofd.Filter = lcFilter;

			//Specify the default settings for the FileDialog	
			ofd.RestoreDirectory = true;	
			ofd.InitialDirectory = System.IO.Directory.GetCurrentDirectory();	

			//Show the dialog and if the user selects a file return the file name	
			if(ofd.ShowDialog() != DialogResult.Cancel)	
			{		
				//Get the name of the file		
				lcFile = ofd.FileName;	
			}	
			
			//Return the name of the file	
			return lcFile;
		}

		/// <summary>
		/// Receives a file as a parameter and converts it to a string
		/// </summary>
		/// <param name="cFileName"></param>
		/// <returns></returns>
		public string FileToStr(string cFileName)
		{	
			//Create a StreamReader and open the file	
			StreamReader oReader = System.IO.File.OpenText(cFileName);	

			//Read all the contents of the file in a string	
			string lcString = oReader.ReadToEnd();	
			
			//Close the StreamReader and return the string	
			oReader.Close();	
			return lcString;
		}

		private void lblAuthorSite_LinkClicked(object sender, System.Windows.Forms.LinkLabelLinkClickedEventArgs e)
		{
			System.Diagnostics.Process.Start("http://www.KamalPatel.net");
		}

		private void cmdLoad_Click(object sender, System.EventArgs e)
		{
			// Get the file and load its contents
			string cFile = "";
			cFile = this.GetFile();
			if(cFile.Length > 0)
				this.txtCSharp.Text = this.FileToStr(cFile);
		}

	}
}
