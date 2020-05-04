using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using Windows.Forms.Reports.ReportLibrary;
using Windows.Forms.Reports.Export;

namespace Windows.Forms.Reports.View
{
	#region PdfExportDlg
	public class PdfExportDlg : System.Windows.Forms.Form
	{
		#region class variables
		public UserRep Rep;
		public string FileName;
		public int FromPage;
		public int ToPage;
		public string Author;
		public DateTime CreationDate;
		public string Creator;
		public string KeyWords;
		public DateTime ModDate;
		public string Subject;
		public string Title;
		public SDPageMode NonFullScreenPageMode;
		public SDPageLayout PageLayout;
		public SDPageMode PageMode;
		public bool HideToolbar;
		public bool	HideMenubar;
		public bool	HideWindowUI;
		public bool	FitWindow;
		public bool	CenterWindow;

		private System.Windows.Forms.Button Cancel;
		private System.Windows.Forms.Button OK;
		private System.Windows.Forms.Button button1;
		private System.Windows.Forms.TextBox txtToPage;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.TextBox txtFromPage;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.TextBox txtFileName;
		private System.Windows.Forms.Label label1;
		public System.Windows.Forms.SaveFileDialog saveFileDialog1;
		private System.Windows.Forms.Panel panel1;
		private System.Windows.Forms.DateTimePicker dtCreationdate;
		private System.Windows.Forms.Label label4;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.TextBox txtAuthor;
		private System.Windows.Forms.Label label5;
		private System.Windows.Forms.Label label6;
		private System.Windows.Forms.TextBox txtCreator;
		private System.Windows.Forms.TextBox txtKeywords;
		private System.Windows.Forms.Label label7;
		private System.Windows.Forms.Label label8;
		private System.Windows.Forms.DateTimePicker dtmodDate;
		private System.Windows.Forms.TextBox txtSubject;
		private System.Windows.Forms.Label label9;
		private System.Windows.Forms.TextBox txtTitle;
		private System.Windows.Forms.Label label10;
		private System.Windows.Forms.Panel panel3;
		private System.Windows.Forms.Label label11;
		private System.Windows.Forms.ComboBox cmbnonfullscreenpagemode;
		private System.Windows.Forms.ComboBox cmbpagelayout;
		private System.Windows.Forms.Label label12;
		private System.Windows.Forms.ComboBox cmbpagemode;
		private System.Windows.Forms.Label label13;
		private System.Windows.Forms.CheckBox cbHideToolbar;
		private System.Windows.Forms.CheckBox cbHideMenubar;
		private System.Windows.Forms.CheckBox cbHideWindowUI;
		private System.Windows.Forms.CheckBox cbFitWindow;
		private System.Windows.Forms.CheckBox cbCenterWindow;

		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public PdfExportDlg()
		{
			InitializeComponent();
			SDPageMode[] nonfullscreenpagemode=(SDPageMode[])Enum.GetValues(typeof(SDPageMode));
			for(int i=0;i<nonfullscreenpagemode.Length;i++)
			{
				SDPageMode a=(SDPageMode)nonfullscreenpagemode[i];
				cmbnonfullscreenpagemode.Items.Add(a);
			}

			SDPageLayout[] pagelayout=(SDPageLayout[])Enum.GetValues(typeof(SDPageLayout));
			for(int i=0;i<pagelayout.Length;i++)
			{
				SDPageLayout a=(SDPageLayout)nonfullscreenpagemode[i];
				cmbpagelayout.Items.Add(a);
			}

			SDPageMode[] pagemode=(SDPageMode[])Enum.GetValues(typeof(SDPageMode));
			for(int i=0;i<pagemode.Length;i++)
			{
				SDPageMode a=(SDPageMode)pagemode[i];
				cmbpagemode.Items.Add(a);
			}
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
			this.Cancel = new System.Windows.Forms.Button();
			this.OK = new System.Windows.Forms.Button();
			this.button1 = new System.Windows.Forms.Button();
			this.txtToPage = new System.Windows.Forms.TextBox();
			this.label3 = new System.Windows.Forms.Label();
			this.txtFromPage = new System.Windows.Forms.TextBox();
			this.label2 = new System.Windows.Forms.Label();
			this.txtFileName = new System.Windows.Forms.TextBox();
			this.label1 = new System.Windows.Forms.Label();
			this.saveFileDialog1 = new System.Windows.Forms.SaveFileDialog();
			this.panel1 = new System.Windows.Forms.Panel();
			this.dtCreationdate = new System.Windows.Forms.DateTimePicker();
			this.label4 = new System.Windows.Forms.Label();
			this.panel2 = new System.Windows.Forms.Panel();
			this.txtTitle = new System.Windows.Forms.TextBox();
			this.label10 = new System.Windows.Forms.Label();
			this.txtSubject = new System.Windows.Forms.TextBox();
			this.label9 = new System.Windows.Forms.Label();
			this.label8 = new System.Windows.Forms.Label();
			this.dtmodDate = new System.Windows.Forms.DateTimePicker();
			this.txtKeywords = new System.Windows.Forms.TextBox();
			this.label7 = new System.Windows.Forms.Label();
			this.txtCreator = new System.Windows.Forms.TextBox();
			this.label6 = new System.Windows.Forms.Label();
			this.label5 = new System.Windows.Forms.Label();
			this.txtAuthor = new System.Windows.Forms.TextBox();
			this.panel3 = new System.Windows.Forms.Panel();
			this.cbCenterWindow = new System.Windows.Forms.CheckBox();
			this.cbFitWindow = new System.Windows.Forms.CheckBox();
			this.cbHideWindowUI = new System.Windows.Forms.CheckBox();
			this.cbHideMenubar = new System.Windows.Forms.CheckBox();
			this.cbHideToolbar = new System.Windows.Forms.CheckBox();
			this.cmbpagemode = new System.Windows.Forms.ComboBox();
			this.label13 = new System.Windows.Forms.Label();
			this.cmbpagelayout = new System.Windows.Forms.ComboBox();
			this.label12 = new System.Windows.Forms.Label();
			this.cmbnonfullscreenpagemode = new System.Windows.Forms.ComboBox();
			this.label11 = new System.Windows.Forms.Label();
			this.panel1.SuspendLayout();
			this.panel2.SuspendLayout();
			this.panel3.SuspendLayout();
			this.SuspendLayout();
			// 
			// Cancel
			// 
			this.Cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.Cancel.Location = new System.Drawing.Point(216, 416);
			this.Cancel.Name = "Cancel";
			this.Cancel.TabIndex = 17;
			this.Cancel.Text = "Cancel";
			// 
			// OK
			// 
			this.OK.DialogResult = System.Windows.Forms.DialogResult.OK;
			this.OK.Location = new System.Drawing.Point(128, 416);
			this.OK.Name = "OK";
			this.OK.TabIndex = 16;
			this.OK.Text = "OK";
			this.OK.Click += new System.EventHandler(this.OK_Click);
			// 
			// button1
			// 
			this.button1.Location = new System.Drawing.Point(320, 24);
			this.button1.Name = "button1";
			this.button1.Size = new System.Drawing.Size(24, 20);
			this.button1.TabIndex = 15;
			this.button1.Text = "...";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			// 
			// txtToPage
			// 
			this.txtToPage.Location = new System.Drawing.Point(248, 56);
			this.txtToPage.Name = "txtToPage";
			this.txtToPage.Size = new System.Drawing.Size(40, 20);
			this.txtToPage.TabIndex = 14;
			this.txtToPage.Text = "";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(192, 56);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(56, 24);
			this.label3.TabIndex = 13;
			this.label3.Text = "To Page";
			// 
			// txtFromPage
			// 
			this.txtFromPage.Location = new System.Drawing.Point(128, 56);
			this.txtFromPage.Name = "txtFromPage";
			this.txtFromPage.Size = new System.Drawing.Size(40, 20);
			this.txtFromPage.TabIndex = 12;
			this.txtFromPage.Text = "";
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(64, 56);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(80, 24);
			this.label2.TabIndex = 11;
			this.label2.Text = "From Page";
			// 
			// txtFileName
			// 
			this.txtFileName.Location = new System.Drawing.Point(64, 24);
			this.txtFileName.Name = "txtFileName";
			this.txtFileName.Size = new System.Drawing.Size(256, 20);
			this.txtFileName.TabIndex = 10;
			this.txtFileName.Text = "";
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(64, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(64, 16);
			this.label1.TabIndex = 9;
			this.label1.Text = "File Name:";
			// 
			// saveFileDialog1
			// 
			this.saveFileDialog1.FileName = "Default";
			// 
			// panel1
			// 
			this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.label3,
																				 this.txtFromPage,
																				 this.txtToPage,
																				 this.txtFileName,
																				 this.label2,
																				 this.button1,
																				 this.label1});
			this.panel1.Location = new System.Drawing.Point(16, 8);
			this.panel1.Name = "panel1";
			this.panel1.Size = new System.Drawing.Size(392, 96);
			this.panel1.TabIndex = 18;
			// 
			// dtCreationdate
			// 
			this.dtCreationdate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtCreationdate.Location = new System.Drawing.Point(128, 24);
			this.dtCreationdate.Name = "dtCreationdate";
			this.dtCreationdate.Size = new System.Drawing.Size(136, 20);
			this.dtCreationdate.TabIndex = 19;
			// 
			// label4
			// 
			this.label4.Location = new System.Drawing.Point(8, 8);
			this.label4.Name = "label4";
			this.label4.Size = new System.Drawing.Size(48, 16);
			this.label4.TabIndex = 20;
			this.label4.Text = "Author";
			// 
			// panel2
			// 
			this.panel2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel2.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.txtTitle,
																				 this.label10,
																				 this.txtSubject,
																				 this.label9,
																				 this.label8,
																				 this.dtmodDate,
																				 this.txtKeywords,
																				 this.label7,
																				 this.txtCreator,
																				 this.label6,
																				 this.label5,
																				 this.txtAuthor,
																				 this.label4,
																				 this.dtCreationdate});
			this.panel2.Location = new System.Drawing.Point(16, 112);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(392, 152);
			this.panel2.TabIndex = 21;
			// 
			// txtTitle
			// 
			this.txtTitle.Location = new System.Drawing.Point(280, 72);
			this.txtTitle.Name = "txtTitle";
			this.txtTitle.TabIndex = 32;
			this.txtTitle.Text = "";
			// 
			// label10
			// 
			this.label10.Location = new System.Drawing.Point(280, 56);
			this.label10.Name = "label10";
			this.label10.Size = new System.Drawing.Size(48, 16);
			this.label10.TabIndex = 31;
			this.label10.Text = "Title";
			// 
			// txtSubject
			// 
			this.txtSubject.Location = new System.Drawing.Point(128, 120);
			this.txtSubject.Name = "txtSubject";
			this.txtSubject.TabIndex = 30;
			this.txtSubject.Text = "";
			// 
			// label9
			// 
			this.label9.Location = new System.Drawing.Point(128, 104);
			this.label9.Name = "label9";
			this.label9.Size = new System.Drawing.Size(48, 16);
			this.label9.TabIndex = 29;
			this.label9.Text = "Subject";
			// 
			// label8
			// 
			this.label8.Location = new System.Drawing.Point(128, 56);
			this.label8.Name = "label8";
			this.label8.Size = new System.Drawing.Size(72, 16);
			this.label8.TabIndex = 28;
			this.label8.Text = "Mod Date";
			// 
			// dtmodDate
			// 
			this.dtmodDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
			this.dtmodDate.Location = new System.Drawing.Point(128, 72);
			this.dtmodDate.Name = "dtmodDate";
			this.dtmodDate.Size = new System.Drawing.Size(136, 20);
			this.dtmodDate.TabIndex = 27;
			// 
			// txtKeywords
			// 
			this.txtKeywords.Location = new System.Drawing.Point(8, 72);
			this.txtKeywords.Name = "txtKeywords";
			this.txtKeywords.TabIndex = 26;
			this.txtKeywords.Text = "";
			// 
			// label7
			// 
			this.label7.Location = new System.Drawing.Point(8, 56);
			this.label7.Name = "label7";
			this.label7.Size = new System.Drawing.Size(56, 16);
			this.label7.TabIndex = 25;
			this.label7.Text = "Keywords";
			// 
			// txtCreator
			// 
			this.txtCreator.Location = new System.Drawing.Point(280, 24);
			this.txtCreator.Name = "txtCreator";
			this.txtCreator.TabIndex = 24;
			this.txtCreator.Text = "";
			// 
			// label6
			// 
			this.label6.Location = new System.Drawing.Point(280, 8);
			this.label6.Name = "label6";
			this.label6.Size = new System.Drawing.Size(48, 16);
			this.label6.TabIndex = 23;
			this.label6.Text = "Creator";
			// 
			// label5
			// 
			this.label5.Location = new System.Drawing.Point(128, 8);
			this.label5.Name = "label5";
			this.label5.Size = new System.Drawing.Size(72, 16);
			this.label5.TabIndex = 22;
			this.label5.Text = "Creation date";
			// 
			// txtAuthor
			// 
			this.txtAuthor.Location = new System.Drawing.Point(8, 24);
			this.txtAuthor.Name = "txtAuthor";
			this.txtAuthor.TabIndex = 21;
			this.txtAuthor.Text = "";
			// 
			// panel3
			// 
			this.panel3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.panel3.Controls.AddRange(new System.Windows.Forms.Control[] {
																				 this.cbCenterWindow,
																				 this.cbFitWindow,
																				 this.cbHideWindowUI,
																				 this.cbHideMenubar,
																				 this.cbHideToolbar,
																				 this.cmbpagemode,
																				 this.label13,
																				 this.cmbpagelayout,
																				 this.label12,
																				 this.cmbnonfullscreenpagemode,
																				 this.label11});
			this.panel3.Location = new System.Drawing.Point(16, 272);
			this.panel3.Name = "panel3";
			this.panel3.Size = new System.Drawing.Size(392, 128);
			this.panel3.TabIndex = 22;
			// 
			// cbCenterWindow
			// 
			this.cbCenterWindow.Location = new System.Drawing.Point(272, 80);
			this.cbCenterWindow.Name = "cbCenterWindow";
			this.cbCenterWindow.TabIndex = 35;
			this.cbCenterWindow.Text = "Center Window";
			// 
			// cbFitWindow
			// 
			this.cbFitWindow.Location = new System.Drawing.Point(144, 96);
			this.cbFitWindow.Name = "cbFitWindow";
			this.cbFitWindow.Size = new System.Drawing.Size(88, 24);
			this.cbFitWindow.TabIndex = 34;
			this.cbFitWindow.Text = "Fit Window";
			// 
			// cbHideWindowUI
			// 
			this.cbHideWindowUI.Location = new System.Drawing.Point(144, 72);
			this.cbHideWindowUI.Name = "cbHideWindowUI";
			this.cbHideWindowUI.TabIndex = 33;
			this.cbHideWindowUI.Text = "Hide WindowUI";
			// 
			// cbHideMenubar
			// 
			this.cbHideMenubar.Location = new System.Drawing.Point(0, 96);
			this.cbHideMenubar.Name = "cbHideMenubar";
			this.cbHideMenubar.Size = new System.Drawing.Size(96, 24);
			this.cbHideMenubar.TabIndex = 32;
			this.cbHideMenubar.Text = "Hide Menubar";
			// 
			// cbHideToolbar
			// 
			this.cbHideToolbar.Location = new System.Drawing.Point(0, 72);
			this.cbHideToolbar.Name = "cbHideToolbar";
			this.cbHideToolbar.Size = new System.Drawing.Size(88, 24);
			this.cbHideToolbar.TabIndex = 31;
			this.cbHideToolbar.Text = "Hide Toolbar";
			// 
			// cmbpagemode
			// 
			this.cmbpagemode.Location = new System.Drawing.Point(272, 16);
			this.cmbpagemode.Name = "cmbpagemode";
			this.cmbpagemode.Size = new System.Drawing.Size(112, 21);
			this.cmbpagemode.TabIndex = 29;
			// 
			// label13
			// 
			this.label13.Location = new System.Drawing.Point(272, 0);
			this.label13.Name = "label13";
			this.label13.Size = new System.Drawing.Size(80, 16);
			this.label13.TabIndex = 28;
			this.label13.Text = "Page mode";
			// 
			// cmbpagelayout
			// 
			this.cmbpagelayout.Location = new System.Drawing.Point(144, 16);
			this.cmbpagelayout.Name = "cmbpagelayout";
			this.cmbpagelayout.Size = new System.Drawing.Size(104, 21);
			this.cmbpagelayout.TabIndex = 27;
			// 
			// label12
			// 
			this.label12.Location = new System.Drawing.Point(144, 0);
			this.label12.Name = "label12";
			this.label12.Size = new System.Drawing.Size(142, 16);
			this.label12.TabIndex = 26;
			this.label12.Text = "Page layout";
			// 
			// cmbnonfullscreenpagemode
			// 
			this.cmbnonfullscreenpagemode.Location = new System.Drawing.Point(0, 16);
			this.cmbnonfullscreenpagemode.Name = "cmbnonfullscreenpagemode";
			this.cmbnonfullscreenpagemode.Size = new System.Drawing.Size(121, 21);
			this.cmbnonfullscreenpagemode.TabIndex = 25;
			// 
			// label11
			// 
			this.label11.Name = "label11";
			this.label11.Size = new System.Drawing.Size(142, 16);
			this.label11.TabIndex = 24;
			this.label11.Text = "Non full screen page mode";
			// 
			// PdfExportDlg
			// 
			this.AcceptButton = this.OK;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CancelButton = this.Cancel;
			this.ClientSize = new System.Drawing.Size(416, 446);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.panel3,
																		  this.panel2,
																		  this.panel1,
																		  this.Cancel,
																		  this.OK});
			this.Name = "PdfExportDlg";
			this.ShowInTaskbar = false;
			this.Text = "Pdf Export Properties";
			this.Load += new System.EventHandler(this.PdfExportDlg_Load);
			this.panel1.ResumeLayout(false);
			this.panel2.ResumeLayout(false);
			this.panel3.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region class methods
		private void button1_Click(object sender, System.EventArgs e)
		{
			saveFileDialog1.FileName=FileName;
			if(saveFileDialog1.ShowDialog()==DialogResult.OK)
			{
				FileName=saveFileDialog1.FileName;
				txtFileName.Text=FileName;
			}
		}

		private void OK_Click(object sender, System.EventArgs e)
		{
			if(Convert.ToInt32(txtToPage.Text)<Convert.ToInt32(txtFromPage.Text))
				throw new Exception("The 'From' value can not be greater than 'To' value");
			FromPage=Convert.ToInt32(txtFromPage.Text);
			ToPage=Convert.ToInt32(txtToPage.Text);
			Author=txtAuthor.Text;
			CreationDate=dtCreationdate.Value;
			Creator=txtCreator.Text;
			KeyWords=txtKeywords.Text;
			ModDate=dtmodDate.Value;
			Subject=txtSubject.Text;
			Title=txtTitle.Text;
			NonFullScreenPageMode=(SDPageMode)cmbnonfullscreenpagemode.SelectedItem;
			PageLayout=(SDPageLayout)cmbpagelayout.SelectedItem;
			PageMode=(SDPageMode)cmbpagemode.SelectedItem;
			HideToolbar=cbHideToolbar.Checked;
			HideMenubar=cbHideMenubar.Checked;
			HideWindowUI=cbHideWindowUI.Checked;
			FitWindow=cbFitWindow.Checked;
			CenterWindow=cbCenterWindow.Checked;
		}

		private void PdfExportDlg_Load(object sender, System.EventArgs e)
		{
			FileName="Default.pdf";
			txtFileName.Text=FileName;
			txtFromPage.Text="1";
			txtToPage.Text=((int)(Rep.Pagecnt-1)).ToString();
			Author="";
			CreationDate=DateTime.Now;
			Creator=Application.ProductName;
			KeyWords="";
			ModDate=DateTime.Now;
			Subject="";
			Title=Rep.Title;
			NonFullScreenPageMode=SDPageMode.UseNone;
			PageLayout=SDPageLayout.SinglePage;
			PageMode=SDPageMode.UseNone;
			HideToolbar=false;
			HideMenubar=false;
			HideWindowUI=false;
			FitWindow=false;
			CenterWindow=false;
			txtAuthor.Text=Author;
			dtCreationdate.Value=CreationDate;
			txtCreator.Text=Creator;
			txtKeywords.Text=KeyWords;
			dtmodDate.Value=ModDate;
			txtSubject.Text=Subject;
			txtTitle.Text=Title;
			cmbnonfullscreenpagemode.SelectedItem=NonFullScreenPageMode;
			cmbpagelayout.SelectedItem=PageLayout;
			cmbpagemode.SelectedItem=PageMode;
			cbHideToolbar.Checked=HideToolbar;
			cbHideMenubar.Checked=HideMenubar;
			cbHideWindowUI.Checked=HideWindowUI;
			cbFitWindow.Checked=FitWindow;
			cbCenterWindow.Checked=CenterWindow;
		}
		#endregion
	}
	#endregion
}
