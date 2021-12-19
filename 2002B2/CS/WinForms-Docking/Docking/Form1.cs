using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace Docking
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		///    Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;
		protected internal System.Windows.Forms.Button button1;
		protected internal System.Windows.Forms.ToolBarButton toolBarButton6;
		protected internal System.Windows.Forms.ToolBarButton toolBarButton5;
		protected internal System.Windows.Forms.ToolBarButton toolBarButton4;
		protected internal System.Windows.Forms.ToolBarButton toolBarButton3;
		protected internal System.Windows.Forms.ToolBarButton toolBarButton2;
		protected internal System.Windows.Forms.ToolBarButton toolBarButton1;
		protected internal System.Windows.Forms.ToolBar toolBar1;
		protected internal System.Windows.Forms.StatusBarPanel statusBarPanel2;
		protected internal System.Windows.Forms.StatusBarPanel statusBarPanel1;
		protected internal System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.StatusBar StatusBar1;    

		private System.Collections.Hashtable d;

		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

            //Set up hashtable with DockStyle values
            d = new System.Collections.Hashtable();
            d.Add("Left", DockStyle.Left);
            d.Add("Right", DockStyle.Right);
            d.Add("Top", DockStyle.Top);
            d.Add("Bottom", DockStyle.Bottom);
            d.Add("None", DockStyle.None);
            d.Add("Fill", DockStyle.Fill);
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
			if(components != null)
				components.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.toolBarButton5 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton4 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton6 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton1 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton3 = new System.Windows.Forms.ToolBarButton();
			this.toolBarButton2 = new System.Windows.Forms.ToolBarButton();
			this.button1 = new System.Windows.Forms.Button();
			this.StatusBar1 = new System.Windows.Forms.StatusBar();
			this.toolBar1 = new System.Windows.Forms.ToolBar();
			this.toolBarButton5.Text = "None";
			this.toolBarButton4.Text = "Bottom";
			this.toolBarButton6.Text = "Fill";
			this.toolBarButton1.Text = "Left";
			this.toolBarButton3.Text = "Top";
			this.toolBarButton2.Text = "Right";
			this.button1.BackColor = System.Drawing.SystemColors.Desktop;
			this.button1.Location = new System.Drawing.Point(168, 168);
			this.button1.Size = new System.Drawing.Size(176, 56);
			this.button1.TabIndex = 3;
			this.button1.Text = "button1\n(click to set Dock to DockStyle.None)";
			this.button1.Click += new System.EventHandler(this.button1_Click);
			this.StatusBar1.BackColor = System.Drawing.SystemColors.Control;
			this.StatusBar1.Location = new System.Drawing.Point(0, 358);
			this.StatusBar1.Size = new System.Drawing.Size(520, 20);
			this.StatusBar1.TabIndex = 2;
			this.StatusBar1.Text = "Use the ToolBar buttons to change the button1.Dock property and then resize the f" +
				"orm";
			this.toolBar1.Buttons.AddRange(new System.Windows.Forms.ToolBarButton[] {this.toolBarButton1,
																						this.toolBarButton2,
																						this.toolBarButton3,
																						this.toolBarButton4,
																						this.toolBarButton5,
																						this.toolBarButton6});
			this.toolBar1.ButtonSize = new System.Drawing.Size(40, 36);
			this.toolBar1.DropDownArrows = true;
			this.toolBar1.ShowToolTips = true;
			this.toolBar1.Size = new System.Drawing.Size(520, 39);
			this.toolBar1.TabIndex = 2;
			this.toolBar1.ButtonClick += new System.Windows.Forms.ToolBarButtonClickEventHandler(this.toolBar1_ButtonClick);
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(520, 378);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.StatusBar1,
																		  this.toolBar1,
																		  this.button1});
			this.Text = "Docking";

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

		private void toolBar1_ButtonClick(object sender, System.Windows.Forms.ToolBarButtonClickEventArgs e)
		{
			button1.Dock = (DockStyle) d[e.Button.Text];
			if (e.Button.Text == "None")
				button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
		}

		private void button1_Click(object sender, System.EventArgs e)
		{
			button1.Dock = DockStyle.None;
			button1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right | AnchorStyles.Left;
		}
	}
}
