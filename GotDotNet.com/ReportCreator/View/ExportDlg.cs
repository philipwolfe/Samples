using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Windows.Forms.Reports.ReportLibrary;

namespace Windows.Forms.Reports.View
{
	#region ExportDlg
	public class ExportDlg : System.Windows.Forms.Form
	{
		#region class variables
		public UserRep Rep;
		public string FileName;
		public int FromPage;
		public int ToPage;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Button Cancel;
		public System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.TextBox txtFromPage;
		private System.Windows.Forms.TextBox txtToPage;
		
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public ExportDlg()
		{
			InitializeComponent();
		}
		#endregion

		#region destructor
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
		#endregion

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFromPage = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtToPage = new System.Windows.Forms.TextBox();
			this.button1 = new System.Windows.Forms.Button();
			this.OK = new System.Windows.Forms.Button();
			this.Cancel = new System.Windows.Forms.Button();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(8, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 0;
			this.label1.Text = "File Name:";
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(8, 32);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(256, 20);
			this.txtFileName.TabIndex = 1;
			this.txtFileName.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(8, 64);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 24);
			this.label2.TabIndex = 2;
			this.label2.Text = "From Page";
			// 
			// txtFromPage
			// 
			this.txtFromPage.Location = new System.Drawing.Point(96, 64);
			this.txtFromPage.Name = "txtFromPage";
			this.txtFromPage.Size = new System.Drawing.Size(40, 20);
			this.txtFromPage.TabIndex = 3;
			this.txtFromPage.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(8, 96);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(80, 24);
			this.label3.TabIndex = 4;
			this.label3.Text = "To Page";
			// 
			// txtToPage
			// 
			this.txtToPage.Location = new System.Drawing.Point(96, 96);
			this.txtToPage.Name = "txtToPage";
			this.txtToPage.Size = new System.Drawing.Size(40, 20);
			this.txtToPage.TabIndex = 5;
			this.txtToPage.Text = "";
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(264, 32);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 20);
			this.button1.TabIndex = 6;
			this.button1.Text = "...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// OK
			// 
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Location = new System.Drawing.Point(32, 128);
			this.OK.Name = "OK";
			this.OK.TabIndex = 7;
			this.OK.Text = "OK";
			this.OK.Click += new System.EventHandler(this.OK_Click);
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(152, 128);
			this.Cancel.Name = "Cancel";
			this.Cancel.TabIndex = 8;
			this.Cancel.Text = "Cancel";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileName = "Default";
			// 
			// ExportDlg
			// 
			this.AcceptButton = this.OK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.Cancel;
			this.ClientSize = new System.Drawing.Size(296, 166);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.Cancel,
																		  this.OK,
																		  this.button1,
																		  this.txtToPage,
																		  this.label3,
																		  this.txtFromPage,
																		  this.label2,
																		  this.txtFileName,
																		  this.label1});
			this.Name = "ExportDlg";
			this.ShowInTaskbar = false;
			this.Text = "ExportDlg";
			this.Load += new System.EventHandler(this.ExportDlg_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region class methods
		private void ExportDlg_Load(object sender, System.EventArgs e)
		{
			txtFileName.Text=FileName;
			txtFromPage.Text="1";
			txtToPage.Text=((int)(Rep.Pagecnt-1)).ToString();
		}

		private void OK_Click(object sender, System.EventArgs e)
		{
			if(Convert.ToInt32(txtToPage.Text)<Convert.ToInt32(txtFromPage.Text))
				throw new Exception("The 'From' value can not be greater than 'To' value");
			FromPage=Convert.ToInt32(txtFromPage.Text);
			ToPage=Convert.ToInt32(txtToPage.Text);
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			saveFileDialog1.FileName=FileName;
			if(saveFileDialog1.ShowDialog()==DialogResult.OK)
			{
				FileName=saveFileDialog1.FileName;
				txtFileName.Text=FileName;
			}
		}
		#endregion
	}
	#endregion
}
