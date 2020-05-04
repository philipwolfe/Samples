using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data; 
using System.Data.OleDb;
using Windows.Forms.Reports.ReportLibrary;
using System.Diagnostics;
using Windows.Forms.Reports.Export;
using System.IO;

namespace Windows.Forms.Reports.View
{
	#region PreviewForm
	public class PreviewForm : System.Windows.Forms.Form
	{
		#region class variables
		RenderingMode FRenderingMode;
		Progress progress;
		PdfExport pdfExport1;
		bool Saved;
		string FindText;
		int FindCurrPage;
		int FindCurrband;
		int FindCurrCell;
		int FindPage;
		int Findband;
		int FindCell;
		bool Find;
		ArrayList FindList;
		bool MatchCase;
		bool FindUp;
		bool FindDown;

		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
		private System.Windows.Forms.MenuItem menuItem11;
		private System.Windows.Forms.MenuItem menuItem12;
		private System.Windows.Forms.MenuItem menuItem13;
		private System.Windows.Forms.MenuItem menuItem14;
		private System.Windows.Forms.MenuItem menuItem15;
		private System.Windows.Forms.Panel panel2;
		private System.Windows.Forms.NumericUpDown numericUpDown1;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ComboBox comboBox1;
		private System.Windows.Forms.Label label2;
		private Windows.Forms.Reports.Export.ImageExport imageExport1;
		private Windows.Forms.Reports.Export.HTMLExport htmlExport1;
		private Windows.Forms.Reports.Export.ExcelExport excelExport1;
		private System.Windows.Forms.MenuItem menuItem19;
		private System.Windows.Forms.MenuItem menuItem20;
		private Windows.Forms.Reports.ReportLibrary.StandartFileSystem standartFileSystem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.TreeView treeView1;
		public Windows.Forms.Reports.ReportLibrary.UserRep userRep;
		private System.Windows.Forms.MenuItem menuItem7;
		private System.Windows.Forms.MenuItem menuItem8;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.MenuItem menuItem9;
		private System.Windows.Forms.MenuItem menuItem10;
		private System.Windows.Forms.MenuItem menuItem16;
		private System.Windows.Forms.MenuItem menuItem17;
		private System.Windows.Forms.MenuItem menuItem18;
		private System.Windows.Forms.MenuItem menuItem21;
		private System.Windows.Forms.MenuItem menuItem22;
		private System.Windows.Forms.MenuItem menuItem23;
		private System.Windows.Forms.MenuItem menuItem24;
		private System.ComponentModel.Container components = null;
		#endregion

		#region constructor
		public PreviewForm()
		{
			InitializeComponent();
			Zoom[] zoom=(Zoom[])Enum.GetValues(typeof(Zoom));
			for(int i=0;i<zoom.Length;i++)
			{
				Zoom a=(Zoom)zoom[i];
				comboBox1.Items.Add(a);
			}
		}
		#endregion

		#region destructor
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
		#endregion

		#region Windows Form Designer generated code
		private void InitializeComponent()
		{
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem20 = new System.Windows.Forms.MenuItem();
			this.menuItem19 = new System.Windows.Forms.MenuItem();
			this.menuItem17 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem9 = new System.Windows.Forms.MenuItem();
			this.menuItem10 = new System.Windows.Forms.MenuItem();
			this.menuItem16 = new System.Windows.Forms.MenuItem();
			this.menuItem21 = new System.Windows.Forms.MenuItem();
			this.menuItem22 = new System.Windows.Forms.MenuItem();
			this.menuItem23 = new System.Windows.Forms.MenuItem();
			this.menuItem24 = new System.Windows.Forms.MenuItem();
			this.menuItem7 = new System.Windows.Forms.MenuItem();
			this.menuItem8 = new System.Windows.Forms.MenuItem();
			this.menuItem18 = new System.Windows.Forms.MenuItem();
			this.menuItem11 = new System.Windows.Forms.MenuItem();
			this.menuItem12 = new System.Windows.Forms.MenuItem();
			this.menuItem13 = new System.Windows.Forms.MenuItem();
			this.menuItem14 = new System.Windows.Forms.MenuItem();
			this.menuItem15 = new System.Windows.Forms.MenuItem();
			this.panel2 = new System.Windows.Forms.Panel();
			this.label2 = new System.Windows.Forms.Label();
			this.comboBox1 = new System.Windows.Forms.ComboBox();
			this.label1 = new System.Windows.Forms.Label();
			this.numericUpDown1 = new System.Windows.Forms.NumericUpDown();
			this.imageExport1 = new Windows.Forms.Reports.Export.ImageExport();
			this.userRep = new Windows.Forms.Reports.ReportLibrary.UserRep();
			this.standartFileSystem1 = new Windows.Forms.Reports.ReportLibrary.StandartFileSystem();
			this.htmlExport1 = new Windows.Forms.Reports.Export.HTMLExport();
			this.excelExport1 = new Windows.Forms.Reports.Export.ExcelExport();
			this.treeView1 = new System.Windows.Forms.TreeView();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel2.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).BeginInit();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem9,
																					  this.menuItem7,
																					  this.menuItem11});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem20,
																					  this.menuItem19,
																					  this.menuItem17,
																					  this.menuItem6,
																					  this.menuItem4,
																					  this.menuItem5,
																					  this.menuItem2,
																					  this.menuItem3});
			this.menuItem1.Text = "&File";
			// 
			// menuItem20
			// 
			this.menuItem20.Index = 0;
			this.menuItem20.Text = "&Open";
			this.menuItem20.Click += new System.EventHandler(this.menuItem20_Click);
			// 
			// menuItem19
			// 
			this.menuItem19.Index = 1;
			this.menuItem19.Text = "&Save";
			this.menuItem19.Click += new System.EventHandler(this.menuItem19_Click);
			// 
			// menuItem17
			// 
			this.menuItem17.Index = 2;
			this.menuItem17.Text = "-";
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 3;
			this.menuItem6.Text = "Page &Setup";
			this.menuItem6.Click += new System.EventHandler(this.menuItem6_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 4;
			this.menuItem4.Text = "Pre&view";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 5;
			this.menuItem5.Text = "&Print";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 6;
			this.menuItem2.Text = "-";
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 7;
			this.menuItem3.Text = "E&xit";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem9
			// 
			this.menuItem9.Index = 1;
			this.menuItem9.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem10,
																					  this.menuItem16,
																					  this.menuItem21});
			this.menuItem9.Text = "&Edit";
			// 
			// menuItem10
			// 
			this.menuItem10.Index = 0;
			this.menuItem10.Shortcut = System.Windows.Forms.Shortcut.CtrlF;
			this.menuItem10.Text = "&Find";
			this.menuItem10.Click += new System.EventHandler(this.menuItem10_Click);
			// 
			// menuItem16
			// 
			this.menuItem16.Index = 1;
			this.menuItem16.Shortcut = System.Windows.Forms.Shortcut.F3;
			this.menuItem16.Text = "Find &next";
			this.menuItem16.Click += new System.EventHandler(this.menuItem16_Click);
			// 
			// menuItem21
			// 
			this.menuItem21.Index = 2;
			this.menuItem21.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem22,
																					   this.menuItem23,
																					   this.menuItem24});
			this.menuItem21.Text = "Rendering mode";
			// 
			// menuItem22
			// 
			this.menuItem22.Checked = true;
			this.menuItem22.Index = 0;
			this.menuItem22.Text = "Normal";
			this.menuItem22.Click += new System.EventHandler(this.menuItem22_Click);
			// 
			// menuItem23
			// 
			this.menuItem23.Index = 1;
			this.menuItem23.Text = "Gray";
			this.menuItem23.Click += new System.EventHandler(this.menuItem23_Click);
			// 
			// menuItem24
			// 
			this.menuItem24.Index = 2;
			this.menuItem24.Text = "Black and white";
			this.menuItem24.Click += new System.EventHandler(this.menuItem24_Click);
			// 
			// menuItem7
			// 
			this.menuItem7.Index = 2;
			this.menuItem7.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem8,
																					  this.menuItem18});
			this.menuItem7.Text = "View";
			// 
			// menuItem8
			// 
			this.menuItem8.Checked = true;
			this.menuItem8.Index = 0;
			this.menuItem8.Text = "Hide BookMarks";
			this.menuItem8.Click += new System.EventHandler(this.menuItem8_Click);
			// 
			// menuItem18
			// 
			this.menuItem18.Checked = true;
			this.menuItem18.Index = 1;
			this.menuItem18.Text = "Pan";
			this.menuItem18.Click += new System.EventHandler(this.menuItem18_Click);
			// 
			// menuItem11
			// 
			this.menuItem11.Index = 3;
			this.menuItem11.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					   this.menuItem12,
																					   this.menuItem13,
																					   this.menuItem14,
																					   this.menuItem15});
			this.menuItem11.Text = "&Output";
			// 
			// menuItem12
			// 
			this.menuItem12.Index = 0;
			this.menuItem12.Text = "&HTML";
			this.menuItem12.Click += new System.EventHandler(this.menuItem12_Click);
			// 
			// menuItem13
			// 
			this.menuItem13.Index = 1;
			this.menuItem13.Text = "&Image";
			this.menuItem13.Click += new System.EventHandler(this.menuItem13_Click);
			// 
			// menuItem14
			// 
			this.menuItem14.Index = 2;
			this.menuItem14.Text = "E&xcel";
			this.menuItem14.Click += new System.EventHandler(this.menuItem14_Click);
			// 
			// menuItem15
			// 
			this.menuItem15.Index = 3;
			this.menuItem15.Text = "&Pdf";
			this.menuItem15.Click += new System.EventHandler(this.menuItem15_Click);
			// 
			// panel2
			// 
			this.panel2.Controls.Add(this.label2);
			this.panel2.Controls.Add(this.comboBox1);
			this.panel2.Controls.Add(this.label1);
			this.panel2.Controls.Add(this.numericUpDown1);
			this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
			this.panel2.Location = new System.Drawing.Point(0, 0);
			this.panel2.Name = "panel2";
			this.panel2.Size = new System.Drawing.Size(392, 32);
			this.panel2.TabIndex = 2;
			// 
			// label2
			// 
			this.label2.Location = new System.Drawing.Point(16, 8);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(56, 16);
			this.label2.TabIndex = 3;
			this.label2.Text = "Zoom";
			// 
			// comboBox1
			// 
			this.comboBox1.Location = new System.Drawing.Point(80, 8);
			this.comboBox1.Name = "comboBox1";
			this.comboBox1.Size = new System.Drawing.Size(104, 21);
			this.comboBox1.TabIndex = 2;
			this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(240, 8);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(56, 16);
			this.label1.TabIndex = 1;
			this.label1.Text = "Page";
			// 
			// numericUpDown1
			// 
			this.numericUpDown1.Location = new System.Drawing.Point(304, 8);
			this.numericUpDown1.Minimum = new System.Decimal(new int[] {
																		   1,
																		   0,
																		   0,
																		   0});
			this.numericUpDown1.Name = "numericUpDown1";
			this.numericUpDown1.Size = new System.Drawing.Size(80, 20);
			this.numericUpDown1.TabIndex = 0;
			this.numericUpDown1.Value = new System.Decimal(new int[] {
																		 1,
																		 0,
																		 0,
																		 0});
			this.numericUpDown1.ValueChanged += new System.EventHandler(this.numericUpDown1_ValueChanged);
			// 
			// imageExport1
			// 
			this.imageExport1.FileName = "Test";
			this.imageExport1.FromPage = 0;
			this.imageExport1.ImageType = Windows.Forms.Reports.Export.ImageType.bmp;
			this.imageExport1.ToPage = 0;
			this.imageExport1.UserRep = this.userRep;
			// 
			// userRep
			// 
			this.userRep.BackColor = System.Drawing.Color.PowderBlue;
			this.userRep.CurrBandIdx = -1;
			this.userRep.CurrCellIdx = -1;
			this.userRep.CurrPage = 0;
			this.userRep.Dock = System.Windows.Forms.DockStyle.Fill;
			this.userRep.FileSystem = this.standartFileSystem1;
			this.userRep.FocusedCellStyle = Windows.Forms.Reports.ReportLibrary.FocusedCellStyle.None;
			this.userRep.GridX = 0;
			this.userRep.GridY = 0;
			this.userRep.Gutter = 0;
			this.userRep.InEditing = false;
			this.userRep.LeftX = 0;
			this.userRep.Location = new System.Drawing.Point(160, 32);
			this.userRep.Name = "userRep";
			this.userRep.Options = Windows.Forms.Reports.ReportLibrary.RepOptions.Editing;
			this.userRep.Owner = this.userRep;
			this.userRep.Pan = true;
			this.userRep.SelectedCellStyle = Windows.Forms.Reports.ReportLibrary.SelectedCellStyle.Selected;
			this.userRep.ShowBandTitle = false;
			this.userRep.ShowMargins = false;
			this.userRep.Size = new System.Drawing.Size(232, 234);
			this.userRep.TabIndex = 5;
			this.userRep.Text = "userRep1";
			this.userRep.Title = null;
			this.userRep.TopY = 0;
			this.userRep.Units = Windows.Forms.Reports.ReportLibrary.Units.Pix;
			this.userRep.Zoom = Windows.Forms.Reports.ReportLibrary.Zoom.hundred;
			this.userRep.Progress += new Windows.Forms.Reports.ReportLibrary.ProgressEventHandler(this.userRep_Progress);
			// 
			// standartFileSystem1
			// 
			this.standartFileSystem1.DefaultExt = "SDR";
			this.standartFileSystem1.FileName = null;
			this.standartFileSystem1.Filter = "Reports (*.SDR)|*.SDR|All files (*.*)|*.*";
			this.standartFileSystem1.InitialDir = null;
			this.standartFileSystem1.MultiSelect = true;
			this.standartFileSystem1.Params = "SDR";
			this.standartFileSystem1.Title = null;
			// 
			// htmlExport1
			// 
			this.htmlExport1.FileName = "Test";
			this.htmlExport1.FromPage = 0;
			this.htmlExport1.ToPage = 0;
			this.htmlExport1.UserRep = this.userRep;
			// 
			// excelExport1
			// 
			this.excelExport1.FileName = "Test.xls";
			this.excelExport1.FromPage = 0;
			this.excelExport1.ToPage = 0;
			this.excelExport1.UserRep = this.userRep;
			// 
			// treeView1
			// 
			this.treeView1.Dock = System.Windows.Forms.DockStyle.Left;
			this.treeView1.ImageIndex = -1;
			this.treeView1.Location = new System.Drawing.Point(0, 32);
			this.treeView1.Name = "treeView1";
			this.treeView1.SelectedImageIndex = -1;
			this.treeView1.Size = new System.Drawing.Size(160, 234);
			this.treeView1.TabIndex = 4;
			this.treeView1.Visible = false;
			this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.SystemColors.Control;
			this.splitter1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
			this.splitter1.Location = new System.Drawing.Point(160, 32);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(3, 234);
			this.splitter1.TabIndex = 6;
			this.splitter1.TabStop = false;
			this.splitter1.SplitterMoved += new System.Windows.Forms.SplitterEventHandler(this.splitter1_SplitterMoved);
			// 
			// PreviewForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(392, 266);
			this.Controls.Add(this.splitter1);
			this.Controls.Add(this.userRep);
			this.Controls.Add(this.treeView1);
			this.Controls.Add(this.panel2);
			this.Cursor = System.Windows.Forms.Cursors.Default;
			this.Menu = this.mainMenu1;
			this.Name = "PreviewForm";
			this.Text = "Form1";
			this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
			this.Closing += new System.ComponentModel.CancelEventHandler(this.PreviewForm_Closing);
			this.Load += new System.EventHandler(this.PreviewForm_Load);
			this.panel2.ResumeLayout(false);
			((System.ComponentModel.ISupportInitialize)(this.numericUpDown1)).EndInit();
			this.ResumeLayout(false);

		}
		#endregion

		#region class methods
		private void PreviewForm_Load(object sender, System.EventArgs e)
		{
			comboBox1.SelectedItem=userRep.Zoom;
			numericUpDown1.Value=1;
			numericUpDown1.Maximum=userRep.Pagecnt-1;
			Text=userRep.Title;
			Saved=false;
			for(int i=0;i<userRep.NodeCollection.Count;i++)
			{
				treeView1.Nodes.Add((TreeNode)userRep.NodeCollection[i]);
			}
			FindList=new ArrayList();
			if(treeView1.Nodes.Count!=0)
				menuItem8_Click(this,EventArgs.Empty);
		}

		private void menuItem6_Click(object sender, System.EventArgs e)
		{
			userRep.SourceRep.PageSettings();
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			userRep.Preview();
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			userRep.Print();
		}

		private void menuItem12_Click(object sender, System.EventArgs e)
		{
			ExportDlg form=new ExportDlg();
			form.FileName="Default.html";
			form.Rep=userRep;
			form.Text="HTML Export Properties";
			form.saveFileDialog1.Filter="HTML Files (*.HTML)|*.HTML";
			if(form.ShowDialog()==DialogResult.OK)
			{
				htmlExport1.FromPage=form.FromPage;
				htmlExport1.ToPage=form.ToPage;
				htmlExport1.FileName=form.FileName;
				if(htmlExport1.FromPage==0)
					htmlExport1.FromPage=1;
				if(htmlExport1.ToPage==0)
					htmlExport1.ToPage=userRep.Pagecnt-1;
				form.Close();
				form.Dispose();	
				Refresh();
				htmlExport1.Execute();	
				FileInfo fi=new FileInfo(htmlExport1.FileName);
				Process Acro=Process.Start(fi.FullName.Remove(fi.FullName.Length-5,5)+((int)(htmlExport1.FromPage)).ToString()+fi.Extension);
			}
		}

		private void menuItem13_Click(object sender, System.EventArgs e)
		{
			ImageExportDlg form=new ImageExportDlg();
			form.FileName="Default.bmp";
			form.Rep=userRep;
			form.Text="Image Export Properties";
			if(form.ShowDialog()==DialogResult.OK)
			{
				imageExport1.FromPage=form.FromPage;
				imageExport1.ToPage=form.ToPage;
				imageExport1.FileName=form.FileName;
				imageExport1.ImageType=form.ImageType;
				if(imageExport1.FromPage==0)
					imageExport1.FromPage=1;
				if(imageExport1.ToPage==0)
					imageExport1.ToPage=userRep.Pagecnt-1;
				form.Close();
				form.Dispose();	
				Refresh();
				imageExport1.Execute();
				FileInfo fi=new FileInfo(imageExport1.FileName);
				Process Acro=Process.Start(fi.FullName.Remove(fi.FullName.Length-fi.Extension.Length,fi.Extension.Length)+((int)(imageExport1.FromPage)).ToString()+fi.Extension);
			}
		}

		private void menuItem14_Click(object sender, System.EventArgs e)
		{
			ExportDlg form=new ExportDlg();
			form.FileName="Default.xls";
			form.Rep=userRep;
			form.Text="Excel Export Properties";
			form.saveFileDialog1.Filter="XLS Files (*.XLS)|*.XLS";
			if(form.ShowDialog()==DialogResult.OK)
			{
				excelExport1.FromPage=form.FromPage;
				excelExport1.ToPage=form.ToPage;
				excelExport1.FileName=form.FileName;
				form.Close();
				form.Dispose();	
				Refresh();
				excelExport1.Execute();
			}
		}

		private void menuItem15_Click(object sender, System.EventArgs e)
		{
			pdfExport1=new PdfExport();
			pdfExport1.UserRep=userRep;
			PdfExportDlg form=new PdfExportDlg();
			form.Rep=userRep;
			form.saveFileDialog1.Filter="PDF Files (*.PDF)|*.PDF";
			if(form.ShowDialog()==DialogResult.OK)
			{
				pdfExport1.FromPage=form.FromPage;
				pdfExport1.ToPage=form.ToPage;
				pdfExport1.FileName=form.FileName;
				pdfExport1.Author=form.Author;
				pdfExport1.CreationDate=form.CreationDate;
				pdfExport1.Creator=form.Creator;
				pdfExport1.Keywords=form.KeyWords;
				pdfExport1.ModDate=form.ModDate;
				pdfExport1.Subject=form.Subject;
				pdfExport1.Title=form.Title;
				pdfExport1.NonFullScreenPageMode=form.NonFullScreenPageMode;
				pdfExport1.PageLayout=form.PageLayout;
				pdfExport1.PageMode=form.PageMode;
				pdfExport1.UseOutlines=true;
				pdfExport1.ViewerPreference.HideToolbar=form.HideToolbar;
				pdfExport1.ViewerPreference.HideMenubar=form.HideMenubar;
				pdfExport1.ViewerPreference.HideWindowUI=form.HideWindowUI;
				pdfExport1.ViewerPreference.FitWindow=form.FitWindow;
				pdfExport1.ViewerPreference.CenterWindow=form.CenterWindow;
				form.Close();
				form.Dispose();	
				Refresh();
				pdfExport1.Execute();
				Process Acro=Process.Start(pdfExport1.FileName);
			}
		}

		private void numericUpDown1_ValueChanged(object sender, System.EventArgs e)
		{
			if(userRep.SourceRep!=null)	
			{
				userRep.ShowPage((int)numericUpDown1.Value,false);
				userRep.SrcRep.RenderingMode=RenderingMode;
				userRep.Refresh();
			}
		}

		private void comboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			userRep.Zoom=(Zoom)comboBox1.SelectedIndex;
			userRep.Refresh();
		}

		private void menuItem19_Click(object sender, System.EventArgs e)
		{
			float oldzoomfactor=ReportLibrary.Generic.ZoomFactor;
			ReportLibrary.Generic.ZoomFactor=1;
			if(userRep.SourceRep.Save(userRep.FileSystem.FileName,userRep.FileSystem,userRep.Title))
				Saved=true;
			ReportLibrary.Generic.ZoomFactor=oldzoomfactor;
		}

		private void menuItem20_Click(object sender, System.EventArgs e)
		{
			Zoom oldzoom=userRep.Zoom;
			ReportLibrary.Generic.ZoomFactor=1;
			string message;
			if(userRep.Title!="")
				message = "Save "+userRep.Title+"?";
			else
				message = "Save report?";
			string caption = "Confirm";
			MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
			DialogResult result;
			if(!Saved)
			{
				result=MessageBox.Show(this, message, caption, buttons);
				if(result == DialogResult.Yes)
				{
					if(!userRep.SourceRep.Save(userRep.FileSystem.FileName,userRep.FileSystem,userRep.Title))
						return;
					else
						Saved=true;
				}
				if(result==DialogResult.Cancel)
				{
					return;
				}
			}
			if(userRep.SourceRep.Open(userRep.FileSystem,userRep))
			{
				Saved=true;
				userRep.CurrPage=0;
				userRep.NodeCollection.Clear();
				treeView1.Nodes.Clear();
				Text=userRep.Title;
				userRep.ShowPage(1,false);
				numericUpDown1.Value=1;
				numericUpDown1.Maximum=userRep.SourceRep.PageCount;
				userRep.Pagecnt=userRep.SourceRep.PageCount+1;		
			}
			userRep.Zoom=oldzoom;
			comboBox1.SelectedItem=oldzoom;
			Rep CurrRep=null;
			for(int i=0;i<userRep.SourceRep.RepList.Count;i++)
			{
				CurrRep=userRep.SourceRep.GetSrcRep(i);
				for(int idxband=0;idxband<CurrRep.BandCount;idxband++)
				{
					if(CurrRep.GetBand(idxband).NodeValue!="")
						userRep.AddNode(CurrRep.GetBand(idxband).NodeValue,CurrRep.GetBand(idxband).Node);
				}
			}
			for(int i=0;i<userRep.NodeCollection.Count;i++)
			{
				treeView1.Nodes.Add((TreeNode)userRep.NodeCollection[i]);
			}
			Refresh();
		}

		private void userRep_Progress(object sender, Windows.Forms.Reports.ReportLibrary.ProgressEventArgs arg)
		{
			switch(arg.Stage)
			{
				case ProgressStage.Starting:
					progress=new Progress();
					progress.AllowTransparency=false;
					progress.Show();
					progress.Refresh();
					break;
				case ProgressStage.Running:
					progress.progressBar1.Value=arg.PercentDone;
					break;
				case ProgressStage.Ending:
					progress.Dispose();
					break;
			}
		}

		public void ProgressStart(int AMax)
		{
			userRep.ProgressStart(AMax);
		}

		public void ProgressStep()
		{
			userRep.ProgressStep();
		}

		public void ProgressStop()
		{
			userRep.ProgressStop();
		}

		private void PreviewForm_Closing(object sender, System.ComponentModel.CancelEventArgs e)
		{
			string message;
			if(userRep.Title!="")
				message = "Save "+userRep.Title+"?";
			else
				message = "Save report?";
			string caption = "Confirm";
			MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
			DialogResult result;
			if(!Saved)
			{
				result=MessageBox.Show(this, message, caption, buttons);
				if(result == DialogResult.Yes)
				{
					if(userRep.SourceRep.Save(userRep.FileSystem.FileName,userRep.FileSystem,userRep.Title))
						e.Cancel=false;
					else
						e.Cancel=true;
				}
				if(result==DialogResult.No)
				{
					e.Cancel=false;
				}
				if(result==DialogResult.Cancel)
				{
					e.Cancel=true;
				}
			}
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			Close();
		}

		private void menuItem8_Click(object sender, System.EventArgs e)
		{
			menuItem8.Checked=!menuItem8.Checked;
			treeView1.Visible=!menuItem8.Checked;
			Refresh();
		}

		private void treeView1_AfterSelect(object sender, System.Windows.Forms.TreeViewEventArgs e)
		{
			ShowBookmark((int)e.Node.Tag,e.Node.Text);
		}

		void ShowBookmark(int Node,string Value)
		{
			Rep CurrRep=null;
			Band band;
			int firstband=0;
			int lastband=0;
			for(int page=1;page<userRep.Pagecnt;page++)
			{
				for(int i=0;i<userRep.SourceRep.RepList.Count;i++)
				{
					CurrRep=userRep.SourceRep.GetSrcRep(i);
					for(int idxband=0;idxband<CurrRep.BandCount;idxband++)
					{
						if(CurrRep.GetBand(idxband).Pageno==page)
							firstband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
						if(CurrRep.GetBand(idxband).Pageno==page+1)
						{
							lastband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
							break;
						}
					}
					if(lastband!=0)
						break;
				}
				if(page!=CurrRep.LastPage-1)
					lastband=lastband-1;
	
				int currband=0;
				for(int idxband=firstband;idxband<lastband+1;idxband++)
				{
					band=CurrRep.GetBand(idxband);

					if((band.Node==Node)&&(band.NodeValue==Value))
					{
						numericUpDown1.ValueChanged -=new EventHandler(numericUpDown1_ValueChanged);
						userRep.ClearSel();
						userRep.ShowPage(page,false);
						userRep.SrcRep.RenderingMode=RenderingMode;
						userRep.SrcRep.GetBand(currband).Selected=true;
						userRep.CurrBandIdx=currband;
						userRep.TopY=(int)userRep.SrcRep.GetTops(currband)+userRep.UserTop+(int)(userRep.TopMargin*ReportLibrary.Generic.ZoomFactor);
						userRep.Refresh();
						numericUpDown1.Value=page;
						numericUpDown1.ValueChanged+=new EventHandler(numericUpDown1_ValueChanged);
						return;
					}
					currband++;
				}
			}
		}

		private void splitter1_SplitterMoved(object sender, System.Windows.Forms.SplitterEventArgs e)
		{
			treeView1.Width=e.X;
		}

		private void menuItem10_Click(object sender, System.EventArgs e)
		{
			SearchDlg form=new SearchDlg();
			form.FindList.AddRange(FindList);
			if(form.ShowDialog()==DialogResult.OK)
			{
				FindText=form.Find;
				if(!form.ComboItem)
					FindList.Add(FindText);
				MatchCase=form.MatchCase;
				FindDown=form.Down;
				FindUp=form.Up;
				form.Dispose();
				FindCurrPage=(int)numericUpDown1.Value;
				FindCurrband=userRep.CurrBandIdx;
				FindCurrCell=userRep.CurrCellIdx;
				Find=false;
				if(FindDown)
					FindDownValue();
				if(FindUp)
					FindUpValue();
			}			
		}

		void FindUpValue()
		{
			string valueupper;
			string valuelower;
			string Value;
			Rep CurrRep;
			int firstband=0;
			int lastband=0;
			int bandcount=0;
			Rep oldrep=null;

			for(int page=1;page<(int)numericUpDown1.Value+1;page++)
			{
				CurrRep=userRep.SourceRep.FindRep(page);
				if(CurrRep!=oldrep)
				{
					oldrep=CurrRep;
					bandcount=0;
				}
				firstband=CurrRep.BandCount;
				for(int idxband=0;idxband<CurrRep.BandCount;idxband++)
				{
					if(CurrRep.GetBand(idxband).Pageno==page)
						firstband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
					if(idxband>=firstband)
						bandcount=bandcount+1;
					if(CurrRep.GetBand(idxband).Pageno==page+1)
					{
						break;
					}
				}
				if(page!=CurrRep.LastPage-1)
					bandcount=bandcount-1;
			}
			
			for(int idxcell=userRep.CurrCellIdx-1;idxcell>-1;idxcell--)
			{
				if((FindCurrPage==(int)numericUpDown1.Value)&&(FindCurrband==userRep.CurrBandIdx)&&(FindCurrCell==idxcell))
				{
					FindCurrPage=(int)numericUpDown1.Value;
					FindCurrband=userRep.CurrBandIdx;
					FindCurrCell=userRep.CurrCellIdx;
					if(Find)
					{
						MessageBox.Show("Find reached the starting point of the search.");
						Find=false;
						return;
					}
					if(!Find)
					{
						MessageBox.Show("The specified text was not found.");
						Find=false;
						return;
					}					
				}
				if(!MatchCase)
				{
					valueupper=userRep.SrcRep.GetBand(userRep.CurrBandIdx).GetCell(idxcell).Value.ToUpper();
					valuelower=userRep.SrcRep.GetBand(userRep.CurrBandIdx).GetCell(idxcell).Value.ToLower();				
					if((valueupper.IndexOf(FindText.ToUpper())!=-1)||(valuelower.IndexOf(FindText.ToLower())!=-1))
					{
						DoFind(userRep.CurrBandIdx,idxcell,(int)numericUpDown1.Value);			
						Find=true;
						return;
					}
				}
				else
				{
					Value=userRep.SrcRep.GetBand(userRep.CurrBandIdx).GetCell(idxcell).Value;	
					if(Value.IndexOf(FindText)!=-1)
					{
						DoFind(userRep.CurrBandIdx,idxcell,(int)numericUpDown1.Value);			
						Find=true;
						return;
					}
				}
			}

			for(int idxband=userRep.CurrBandIdx-1;idxband>-1;idxband--)
			{
				for(int idxcell=userRep.SrcRep.GetBand(idxband).CellCount-1;idxcell>-1;idxcell--)
				{
					if((FindCurrPage==(int)numericUpDown1.Value)&&(FindCurrband==idxband)&&(FindCurrCell==idxcell))
					{
						FindCurrPage=(int)numericUpDown1.Value;
						FindCurrband=userRep.CurrBandIdx;
						FindCurrCell=userRep.CurrCellIdx;
						if(Find)
						{
							MessageBox.Show("Find reached the starting point of the search.");
							Find=false;
							return;
						}
						if(!Find)
						{
							MessageBox.Show("The specified text was not found.");
							Find=false;
							return;
						}						
					}
					if(!MatchCase)
					{
						valueupper=userRep.SrcRep.GetBand(idxband).GetCell(idxcell).Value.ToUpper();
						valuelower=userRep.SrcRep.GetBand(idxband).GetCell(idxcell).Value.ToLower();
						if((valueupper.IndexOf(FindText.ToUpper())!=-1)||(valuelower.IndexOf(FindText.ToLower())!=-1))
						{
							DoFind(idxband,idxcell,(int)numericUpDown1.Value);			
							Find=true;
							return;
						}
					}
					else
					{
						Value=userRep.SrcRep.GetBand(idxband).GetCell(idxcell).Value;
						if(Value.IndexOf(FindText)!=-1)
						{
							DoFind(idxband,idxcell,(int)numericUpDown1.Value);			
							Find=true;
							return;
						}
					}
				}
			}
			bandcount=bandcount-userRep.SrcRep.BandCount;

			if((int)numericUpDown1.Value!=1)
			{
				for(int page=(int)numericUpDown1.Value-1;page>0;page--)
				{
					CurrRep=userRep.SourceRep.FindRep(page);
					if(CurrRep!=oldrep)
					{
						bandcount=0;
						oldrep=CurrRep;
					}
					for(int idxband=0;idxband<CurrRep.BandCount;idxband++)
					{
						if(CurrRep.GetBand(idxband).Pageno==page)
							firstband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
						if(CurrRep.GetBand(idxband).Pageno==page+1)
						{
							lastband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
							break;
						}
					}
					if(page!=CurrRep.LastPage-1)
						lastband=lastband-1;
					bandcount=bandcount-(lastband+1-firstband);
	
					for(int idxband=lastband;idxband>firstband-1;idxband--)
					{
						for(int idxcell=CurrRep.GetBand(idxband).CellCount-1;idxcell>-1;idxcell--)
						{
							if((FindCurrPage==page)&&(FindCurrband==idxband-bandcount)&&(FindCurrCell==idxcell))
							{
								FindCurrPage=(int)numericUpDown1.Value;
								FindCurrband=userRep.CurrBandIdx;
								FindCurrCell=userRep.CurrCellIdx;
								if(Find)
								{
									MessageBox.Show("Find reached the starting point of the search.");
									Find=false;
									return;
								}
								if(!Find)
								{
									MessageBox.Show("The specified text was not found.");
									Find=false;
									return;
								}							
							}
							if(!MatchCase)
							{
								valueupper=CurrRep.GetBand(idxband).GetCell(idxcell).Value.ToUpper();
								valuelower=CurrRep.GetBand(idxband).GetCell(idxcell).Value.ToLower();
								if((valueupper.IndexOf(FindText.ToUpper())!=-1)||(valuelower.IndexOf(FindText.ToLower())!=-1))
								{
									DoFind(idxband-bandcount,idxcell,page);			
									Find=true;
									return;
								}
							}
							else
							{
								Value=CurrRep.GetBand(idxband).GetCell(idxcell).Value;
								if(Value.IndexOf(FindText)!=-1)
								{
									DoFind(idxband-bandcount,idxcell,page);			
									Find=true;
									return;
								}
							}
						}
					}
				}
			}
	
			bandcount=0;
			for(int page=1;page<userRep.Pagecnt;page++)
			{
				CurrRep=userRep.SourceRep.FindRep(page);
				if(CurrRep!=oldrep)
				{
					bandcount=0;
					oldrep=CurrRep;
				}
				firstband=CurrRep.BandCount;
				for(int idxband=0;idxband<CurrRep.BandCount;idxband++)
				{
					if(CurrRep.GetBand(idxband).Pageno==page)
						firstband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
					if(idxband>=firstband)
						bandcount=bandcount+1;
					if(CurrRep.GetBand(idxband).Pageno==page+1)
					{
						break;
					}
				}
				if(page!=CurrRep.LastPage-1)
					bandcount=bandcount-1;
			}

			for(int page=userRep.Pagecnt-1;page>0;page--)
			{
				CurrRep=userRep.SourceRep.FindRep(page);
				if(CurrRep!=oldrep)
				{
					bandcount=0;
					oldrep=CurrRep;
				}
				for(int idxband=0;idxband<CurrRep.BandCount;idxband++)
				{
					if(CurrRep.GetBand(idxband).Pageno==page)
						firstband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
					if(CurrRep.GetBand(idxband).Pageno==page+1)
					{
						lastband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
						break;
					}
				}
				if(page!=CurrRep.LastPage-1)
					lastband=lastband-1;
				bandcount=bandcount-(lastband+1-firstband);
	
				for(int idxband=lastband;idxband>firstband-1;idxband--)
				{
					for(int idxcell=CurrRep.GetBand(idxband).CellCount-1;idxcell>-1;idxcell--)
					{
						if((FindCurrPage==page)&&(FindCurrband==idxband-bandcount)&&(FindCurrCell==idxcell))
						{
							FindCurrPage=(int)numericUpDown1.Value;
							FindCurrband=userRep.CurrBandIdx;
							FindCurrCell=userRep.CurrCellIdx;
							if(Find)
							{
								MessageBox.Show("Find reached the starting point of the search.");
								Find=false;
								return;
							}
							if(!Find)
							{
								MessageBox.Show("The specified text was not found.");
								Find=false;
								return;
							}							
						}
						if(!MatchCase)
						{
							valueupper=CurrRep.GetBand(idxband).GetCell(idxcell).Value.ToUpper();
							valuelower=CurrRep.GetBand(idxband).GetCell(idxcell).Value.ToLower();
							if((valueupper.IndexOf(FindText.ToUpper())!=-1)||(valuelower.IndexOf(FindText.ToLower())!=-1))
							{
								DoFind(idxband-bandcount,idxcell,page);
								Find=true;
								return;
							}
						}
						else
						{
							Value=CurrRep.GetBand(idxband).GetCell(idxcell).Value;
							if(Value.IndexOf(FindText)!=-1)
							{
								DoFind(idxband-bandcount,idxcell,page);
								Find=true;
								return;
							}
						}
					}
				}
			}
		}

		void FindDownValue()
		{
			string valueupper;
			string valuelower;
			string Value;
			Rep CurrRep;
			int firstband=0;
			int lastband=0;
			int bandcount=0;
			Rep oldrep=null;
			
			for(int page=1;page<(int)numericUpDown1.Value+1;page++)
			{
				CurrRep=userRep.SourceRep.FindRep(page);
				if(CurrRep!=oldrep)
				{
					oldrep=CurrRep;
					bandcount=0;
				}
				firstband=CurrRep.BandCount;
				for(int idxband=0;idxband<CurrRep.BandCount;idxband++)
				{
					if(CurrRep.GetBand(idxband).Pageno==page)
						firstband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
					if(idxband>=firstband)
						bandcount=bandcount+1;
					if(CurrRep.GetBand(idxband).Pageno==page+1)
					{
						break;
					}
				}
				if(page!=CurrRep.LastPage-1)
					bandcount=bandcount-1;
			}

			for(int idxcell=userRep.CurrCellIdx+1;idxcell<userRep.SrcRep.GetBand(userRep.CurrBandIdx).CellCount;idxcell++)
			{
				if((FindCurrPage==(int)numericUpDown1.Value)&&(FindCurrband==userRep.CurrBandIdx)&&(FindCurrCell==idxcell))
				{
					FindCurrPage=(int)numericUpDown1.Value;
					FindCurrband=userRep.CurrBandIdx;
					FindCurrCell=userRep.CurrCellIdx;
					if(Find)
					{
						MessageBox.Show("Find reached the starting point of the search.");
						Find=false;
						return;
					}
					if(!Find)
					{
						MessageBox.Show("The specified text was not found.");
						Find=false;
						return;
					}					
				}
				if(!MatchCase)
				{
					valueupper=userRep.SrcRep.GetBand(userRep.CurrBandIdx).GetCell(idxcell).Value.ToUpper();
					valuelower=userRep.SrcRep.GetBand(userRep.CurrBandIdx).GetCell(idxcell).Value.ToLower();				
					if((valueupper.IndexOf(FindText.ToUpper())!=-1)||(valuelower.IndexOf(FindText.ToLower())!=-1))
					{
						DoFind(userRep.CurrBandIdx,idxcell,(int)numericUpDown1.Value);			
						Find=true;
						return;
					}
				}
				else
				{
					Value=userRep.SrcRep.GetBand(userRep.CurrBandIdx).GetCell(idxcell).Value;	
					if(Value.IndexOf(FindText)!=-1)
					{
						DoFind(userRep.CurrBandIdx,idxcell,(int)numericUpDown1.Value);			
						Find=true;
						return;
					}
				}
			}

			for(int idxband=userRep.CurrBandIdx+1;idxband<userRep.SrcRep.BandCount;idxband++)
			{
				for(int idxcell=0;idxcell<userRep.SrcRep.GetBand(idxband).CellCount;idxcell++)
				{
					if((FindCurrPage==(int)numericUpDown1.Value)&&(FindCurrband==idxband)&&(FindCurrCell==idxcell))
					{
						FindCurrPage=(int)numericUpDown1.Value;
						FindCurrband=userRep.CurrBandIdx;
						FindCurrCell=userRep.CurrCellIdx;
						if(Find)
						{
							MessageBox.Show("Find reached the starting point of the search.");
							Find=false;
							return;
						}
						if(!Find)
						{
							MessageBox.Show("The specified text was not found.");
							Find=false;
							return;
						}						
					}
					if(!MatchCase)
					{
						valueupper=userRep.SrcRep.GetBand(idxband).GetCell(idxcell).Value.ToUpper();
						valuelower=userRep.SrcRep.GetBand(idxband).GetCell(idxcell).Value.ToLower();
						if((valueupper.IndexOf(FindText.ToUpper())!=-1)||(valuelower.IndexOf(FindText.ToLower())!=-1))
						{
							DoFind(idxband,idxcell,(int)numericUpDown1.Value);			
							Find=true;
							return;
						}
					}
					else
					{
						Value=userRep.SrcRep.GetBand(idxband).GetCell(idxcell).Value;
						if(Value.IndexOf(FindText)!=-1)
						{
							DoFind(idxband,idxcell,(int)numericUpDown1.Value);			
							Find=true;
							return;
						}
					}
				}
			}

			for(int page=(int)numericUpDown1.Value+1;page<userRep.Pagecnt;page++)
			{
				CurrRep=userRep.SourceRep.FindRep(page);
				if(CurrRep!=oldrep)
				{
					bandcount=0;
					oldrep=CurrRep;
				}
				for(int idxband=0;idxband<CurrRep.BandCount;idxband++)
				{
					if(CurrRep.GetBand(idxband).Pageno==page)
						firstband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
					if(CurrRep.GetBand(idxband).Pageno==page+1)
					{
						lastband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
						break;
					}
				}
				if(page!=CurrRep.LastPage-1)
					lastband=lastband-1;
	
				for(int idxband=firstband;idxband<lastband+1;idxband++)
				{
					for(int idxcell=0;idxcell<CurrRep.GetBand(idxband).CellCount;idxcell++)
					{
						if((FindCurrPage==page)&&(FindCurrband==idxband-bandcount)&&(FindCurrCell==idxcell))
						{
							FindCurrPage=(int)numericUpDown1.Value;
							FindCurrband=userRep.CurrBandIdx;
							FindCurrCell=userRep.CurrCellIdx;
							if(Find)
							{
								MessageBox.Show("Find reached the starting point of the search.");
								Find=false;
								return;
							}
							if(!Find)
							{
								MessageBox.Show("The specified text was not found.");
								Find=false;
								return;
							}							
						}
						if(!MatchCase)
						{
							valueupper=CurrRep.GetBand(idxband).GetCell(idxcell).Value.ToUpper();
							valuelower=CurrRep.GetBand(idxband).GetCell(idxcell).Value.ToLower();
							if((valueupper.IndexOf(FindText.ToUpper())!=-1)||(valuelower.IndexOf(FindText.ToLower())!=-1))
							{
								DoFind(idxband-bandcount,idxcell,page);			
								Find=true;
								return;
							}
						}
						else
						{
							Value=CurrRep.GetBand(idxband).GetCell(idxcell).Value;
							if(Value.IndexOf(FindText)!=-1)
							{
								DoFind(idxband-bandcount,idxcell,page);			
								Find=true;
								return;
							}
						}
					}
				}
				bandcount=bandcount+lastband+1-firstband;
			}	
		
			bandcount=0;
			for(int page=1;page<userRep.Pagecnt;page++)
			{
				CurrRep=userRep.SourceRep.FindRep(page);
				if(CurrRep!=oldrep)
				{
					bandcount=0;
					oldrep=CurrRep;
				}
				for(int idxband=0;idxband<CurrRep.BandCount;idxband++)
				{
					if(CurrRep.GetBand(idxband).Pageno==page)
						firstband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
					if(CurrRep.GetBand(idxband).Pageno==page+1)
					{
						lastband=CurrRep.IndexOfBand(CurrRep.GetBand(idxband));
						break;
					}
				}
				if(page!=CurrRep.LastPage-1)
					lastband=lastband-1;
	
				for(int idxband=firstband;idxband<lastband+1;idxband++)
				{
					for(int idxcell=0;idxcell<CurrRep.GetBand(idxband).CellCount;idxcell++)
					{
						if((FindCurrPage==page)&&(FindCurrband==idxband-bandcount)&&(FindCurrCell==idxcell))
						{
							FindCurrPage=(int)numericUpDown1.Value;
							FindCurrband=userRep.CurrBandIdx;
							FindCurrCell=userRep.CurrCellIdx;
							if(Find)
							{
								MessageBox.Show("Find reached the starting point of the search.");
								Find=false;
								return;
							}
							if(!Find)
							{
								MessageBox.Show("The specified text was not found.");
								Find=false;
								return;
							}							
						}
						if(!MatchCase)
						{
							valueupper=CurrRep.GetBand(idxband).GetCell(idxcell).Value.ToUpper();
							valuelower=CurrRep.GetBand(idxband).GetCell(idxcell).Value.ToLower();
							if((valueupper.IndexOf(FindText.ToUpper())!=-1)||(valuelower.IndexOf(FindText.ToLower())!=-1))
							{
								DoFind(idxband-bandcount,idxcell,page);
								Find=true;
								return;
							}
						}
						else
						{
							Value=CurrRep.GetBand(idxband).GetCell(idxcell).Value;
							if(Value.IndexOf(FindText)!=-1)
							{
								DoFind(idxband-bandcount,idxcell,page);
								Find=true;
								return;
							}
						}
					}
				}
				bandcount=bandcount+lastband+1-firstband;
			}
		}

		void DoFind(int idxband,int idxcell,int page)
		{
			userRep.ClearSel();
			numericUpDown1.ValueChanged -=new EventHandler(numericUpDown1_ValueChanged);
			userRep.ShowPage(page,false);	
			userRep.SrcRep.GetBand(idxband).GetCell(idxcell).Selected=true;
			userRep.CurrBandIdx=idxband;
			userRep.CurrCellIdx=idxcell;
			userRep.TopY=(int)userRep.SrcRep.GetTops(idxband)+userRep.UserTop+(int)(userRep.TopMargin*ReportLibrary.Generic.ZoomFactor);
			userRep.LeftX=(int)userRep.SrcRep.GetBand(idxband).GetLefts(idxcell)+userRep.UserLeft+(int)(userRep.LeftMargin*ReportLibrary.Generic.ZoomFactor);
			FindPage=page;
			Findband=idxband;
			FindCell=idxcell;
			numericUpDown1.Value=page;
			numericUpDown1.ValueChanged+=new EventHandler(numericUpDown1_ValueChanged);
			userRep.Refresh();
		}

		private void menuItem16_Click(object sender, System.EventArgs e)
		{
			if((FindPage!=(int)numericUpDown1.Value)||(Findband!=userRep.CurrBandIdx)||(FindCell!=userRep.CurrCellIdx))
			{
				FindCurrPage=(int)numericUpDown1.Value;
				FindCurrband=userRep.CurrBandIdx;
				FindCurrCell=userRep.CurrCellIdx;
			}
			if(FindDown)
				FindDownValue();
			if(FindUp)
				FindUpValue();
		}

		private void menuItem18_Click(object sender, System.EventArgs e)
		{
			menuItem18.Checked=!menuItem18.Checked;
			userRep.Pan=menuItem18.Checked;
		}

		private void menuItem22_Click(object sender, System.EventArgs e)
		{
			RenderingMode=RenderingMode.Normal;
			menuItem22.Checked=true;
			menuItem23.Checked=false;
			menuItem24.Checked=false;
			for(int i=0;i<userRep.SourceRep.RepList.Count;i++)
			{
				((Rep)userRep.SourceRep.RepList[i]).RenderingMode=RenderingMode;
			}
			userRep.SrcRep.RenderingMode=RenderingMode;
			userRep.Refresh();
		}

		private void menuItem23_Click(object sender, System.EventArgs e)
		{
			RenderingMode=RenderingMode.Gray;
			menuItem23.Checked=true;
			menuItem22.Checked=false;
			menuItem24.Checked=false;
			for(int i=0;i<userRep.SourceRep.RepList.Count;i++)
			{
				((Rep)userRep.SourceRep.RepList[i]).RenderingMode=RenderingMode;
			}
			userRep.SrcRep.RenderingMode=RenderingMode;
			userRep.Refresh();
		}

		private void menuItem24_Click(object sender, System.EventArgs e)
		{
			RenderingMode=RenderingMode.BlackAndWhite;
			menuItem24.Checked=true;
			menuItem23.Checked=false;
			menuItem22.Checked=false;
			for(int i=0;i<userRep.SourceRep.RepList.Count;i++)
			{
				((Rep)userRep.SourceRep.RepList[i]).RenderingMode=RenderingMode;
			}
			userRep.SrcRep.RenderingMode=RenderingMode;
			userRep.Refresh();
		}
		#endregion

		#region Class Properties
		RenderingMode RenderingMode
		{
			get
			{
				return FRenderingMode;
			}
			set
			{
				FRenderingMode=value;
			}
		}
		#endregion

	}
	#endregion	
}
