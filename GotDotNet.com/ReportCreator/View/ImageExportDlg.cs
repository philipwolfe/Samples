using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Windows.Forms.Reports.ReportLibrary;
using System.IO;
using Windows.Forms.Reports.Export;

namespace Windows.Forms.Reports.View
{
	#region ExportDlg
	public class ImageExportDlg : System.Windows.Forms.Form
	{
		#region class variables
		public UserRep Rep;
		public string FileName;
		public int FromPage;
		public int ToPage;
		ImageType FImageType;
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
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label4;
		
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public ImageExportDlg()
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
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label4 = new System.Windows.Forms.Label();
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
			// comboBox1
			// 
			this.comboBox1.Items.AddRange(new object[] {
														   "bmp",
														   "emf",
														   "gif",
														   "jpg",
														   "png",
														   "tiff",
														   "wmf"});
			this.comboBox1.Location = new System.Drawing.Point(160, 80);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(121, 21);
			this.comboBox1.TabIndex = 9;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(160, 64);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(100, 16);
			this.label4.TabIndex = 10;
			this.label4.Text = "Image type";
			// 
			// ImageExportDlg
			// 
			this.AcceptButton = this.OK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.Cancel;
			this.ClientSize = new System.Drawing.Size(296, 166);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.label4,
																		  this.comboBox1,
																		  this.Cancel,
																		  this.OK,
																		  this.button1,
																		  this.txtToPage,
																		  this.label3,
																		  this.txtFromPage,
																		  this.label2,
																		  this.txtFileName,
																		  this.label1});
			this.Name = "ImageExportDlg";
			this.ShowInTaskbar = false;
			this.Text = "ExportDlg";
			this.Load += new System.EventHandler(this.ExportDlg_Load);
			this.ResumeLayout(false);

		}
		#endregion

		#region class methods
		private void ExportDlg_Load(object sender, System.EventArgs e)
		{
			comboBox1.SelectedIndex=0;
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

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			FileInfo fi=new FileInfo(FileName);
			FileName=fi.FullName.Remove(fi.FullName.Length-fi.Extension.Length,fi.Extension.Length);
			ImageType=(ImageType)comboBox1.SelectedIndex;
			switch(ImageType)
			{
				case ImageType.bmp:
					FileName=FileName+".bmp";
					saveFileDialog1.Filter="BMP Files (*.BMP)|*.BMP";
					break;
				case ImageType.emf:
					FileName=FileName+".emf";
					saveFileDialog1.Filter="EMF Files (*.EMF)|*.EMF";
					break;
				case ImageType.gif:
					FileName=FileName+".gif";
					saveFileDialog1.Filter="GIF Files (*.GIF)|*.GIF";
					break;
				case ImageType.jpg:
					FileName=FileName+".jpg";
					saveFileDialog1.Filter="JPG Files (*.JPG)|*.JPG";
					break;
				case ImageType.png:
					FileName=FileName+".png";
					saveFileDialog1.Filter="PNG Files (*.PNG)|*.PNG";
					break;
				case ImageType.tiff:
					FileName=FileName+".tiff";
					saveFileDialog1.Filter="TIFF Files (*.TIFF)|*.TIFF";
					break;
				case ImageType.wmf:
					FileName=FileName+".wmf";
					saveFileDialog1.Filter="WMF Files (*.WMF)|*.WMF";
					break;
			}
			txtFileName.Text=FileName;
		}
		#endregion	

		#region class properties
		public ImageType ImageType
		{
			get
			{
				return FImageType;
			}
			set
			{
				FImageType=value;
			}
		}
		#endregion
	}
	#endregion
}
