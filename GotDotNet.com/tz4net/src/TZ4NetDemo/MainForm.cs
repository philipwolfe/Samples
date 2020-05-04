using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace TZ4NetDemo
{
	/// <summary>
	/// Summary description for MainForm.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.ImageList imageList1;
		private System.Windows.Forms.ToolBar toolBar1;
		private System.Windows.Forms.ToolBarButton toolBarButton1;
		private System.Windows.Forms.ToolBarButton toolBarButton2;
		private System.Windows.Forms.ToolBarButton toolBarButton3;
		private System.Windows.Forms.ToolBarButton toolBarButton4;
		private System.ComponentModel.IContainer components;

		public MainForm()
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

		private Form OpenForm(Type formType) 
		{
			Form child = (Form)Activator.CreateInstance(formType);
			child.MdiParent = this;
			child.Show();
			return child;
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(MainForm));
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.imageList1 = new System.Windows.Forms.ImageList(this.components);
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.SuspendLayout();
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2,
																					  this.menuItem3,
																					  this.menuItem4,
																					  this.menuItem5});
			this.menuItem1.Text = "&File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "New &Converter";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.Text = "New &Generator";
			this.menuItem3.Click += new System.EventHandler(this.menuItem3_Click);
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 2;
			this.menuItem4.Text = "-";
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 3;
			this.menuItem5.Text = "E&xit";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// imageList1
			// 
			this.imageList1.ImageSize = new System.Drawing.Size(16, 16);
			this.imageList1.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageList1.ImageStream")));
			this.imageList1.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// toolBar1
			// 
			this.toolBar1.Appearance = System.Windows.Forms.ToolBarAppearance.Flat;
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {
																						this.toolBarButton1,
																						this.toolBarButton2,
																						this.toolBarButton3,
																						this.toolBarButton4});
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ImageList = this.imageList1;
			this.toolBar1.Location = new System.Drawing.Point(0, 0);
			this.toolBar1.Name = "toolBar1";
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(792, 28);
			this.toolBar1.TabIndex = 1;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			// 
			// toolBarButton1
			// 
			this.toolBarButton1.ImageIndex = 1;
			this.toolBarButton1.Tag = "ConverterForm";
			this.toolBarButton1.ToolTipText = "Add New Converter";
			// 
			// toolBarButton2
			// 
			this.toolBarButton2.ImageIndex = 2;
			this.toolBarButton2.Tag = "GeneratorForm";
			this.toolBarButton2.ToolTipText = "Add New Generator";
			// 
			// toolBarButton3
			// 
			this.toolBarButton3.Style = System.Windows.Forms.ToolBarButtonStyle.Separator;
			// 
			// toolBarButton4
			// 
			this.toolBarButton4.ImageIndex = 3;
			this.toolBarButton4.Tag = "Exit";
			this.toolBarButton4.ToolTipText = "Exit";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(792, 553);
			this.Controls.Add(this.toolBar1);
			this.IsMdiContainer = true;
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "TZ4Net Demo";
			this.ResumeLayout(false);

		}
		#endregion

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			string tag = e.Button.Tag as string;
			if (tag == "ConverterForm") 
			{
				OpenForm(typeof(ConverterForm));
			} 
			else if (tag == "GeneratorForm") 
			{
				OpenForm(typeof(GeneratorForm));
			} 
			else if (tag == "Exit") 
			{
				this.Close();
			} 
			else 
			{
				System.Diagnostics.Trace.Assert(false, string.Format("Unknown tag ({0}).", tag));
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			OpenForm(typeof(ConverterForm));
		}

		private void menuItem3_Click(object sender, System.EventArgs e)
		{
			OpenForm(typeof(GeneratorForm));
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	}
}
