namespace VideoPlayer
{
	using System;
	using System.Drawing;
	using System.Collections;
	using System.ComponentModel;
	using System.WinForms;
	using System.Data;
	using QuartzTypeLib;

	/// <summary>
	/// Simple VideoLauncher Win Form application.
	/// </summary>
	public class VideoLauncher : System.WinForms.Form
	{
		/// <summary> 
		///    Required designer variable
		/// </summary>
		private System.ComponentModel.Container components;

		private System.WinForms.OpenFileDialog openDlg;
		private System.WinForms.MenuItem menuItem4;
		private System.WinForms.MenuItem exitMenuItem;
		private System.WinForms.MenuItem openMenuItem;
		private System.WinForms.MenuItem menuItem1;
		private System.WinForms.MainMenu mainMenu1;

		private IMediaControl mediaControl;

		/// <summary>
		/// Constructor for the form.
		/// </summary>
		public VideoLauncher()
		{
			InitializeComponent();
		}

		/// <summary>
		///    Clean up any resources being used
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
			components.Dispose();
		}

		/// <summary>
		///    Required method for Designer support - do not modify
		///    the contents of this method with the code editor
		/// </summary>
		private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.menuItem4 = new System.WinForms.MenuItem();
		this.exitMenuItem = new System.WinForms.MenuItem();
		this.openMenuItem = new System.WinForms.MenuItem();
		this.mainMenu1 = new System.WinForms.MainMenu();
		this.menuItem1 = new System.WinForms.MenuItem();
		this.openDlg = new System.WinForms.OpenFileDialog();
		
		//@design this.TrayLargeIcon = true;
		//@design this.TrayHeight = 250;
		this.Text = "VideoPlayer Launcher";
		this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
		this.Menu = mainMenu1;
		this.ClientSize = new System.Drawing.Size(248, 89);
		
		menuItem4.Text = "-";
		menuItem4.Index = 1;
		
		exitMenuItem.Text = "Exit";
		exitMenuItem.Index = 2;
		exitMenuItem.Click += new System.EventHandler(exitMenuItem_Click);
		
		openMenuItem.Text = "Open...";
		openMenuItem.Index = 0;
		openMenuItem.Click += new System.EventHandler(openMenuItem_Click);
		
		//@design mainMenu1.SetLocation(new System.Drawing.Point(72, 7));
		mainMenu1.MenuItems.All = new System.WinForms.MenuItem[] {menuItem1};
		
		menuItem1.Text = "File";
		menuItem1.Index = 0;
		menuItem1.MenuItems.All = new System.WinForms.MenuItem[] {openMenuItem,
			menuItem4,
			exitMenuItem};
		
		//@design openDlg.SetLocation(new System.Drawing.Point(7, 7));
		openDlg.Filter = "AVI Files|*.avi";
	}

		/// <summary>
		/// Handle the Exit Menu Item Click
		/// </summary>
		/// <param name="sender"> The sender of the event </param>
		/// <param name="e"> The parameters for the event</param>
		protected void exitMenuItem_Click(object sender, System.EventArgs e)
		{
			if ( mediaControl != null )
			{
				mediaControl.Stop();
			}

			Application.Exit();
		}

		/// <summary>
		/// Handle the Open Menu Item click
		/// </summary>
		/// <param name="sender"> The sender of the event</param>
		/// <param name="e"> The parameters for the event</param>
		protected void openMenuItem_Click(object sender, System.EventArgs e)
		{
			if (openDlg.ShowDialog() == System.WinForms.DialogResult.OK)
			{
				if ( mediaControl != null )
				{
					mediaControl.Stop();
				}

				//
				// Create the Manager and get the Media interface
				//
				FilgraphManager mgr  = new FilgraphManager();

				mediaControl = (IMediaControl)mgr;

				mediaControl.RenderFile(openDlg.FileName);

				mediaControl.Run();
			}	
		}

		/// <summary>
		/// Main application point 
		/// </summary>
		public static void Main() 
		{
			Application.Run(new VideoLauncher());
		}
	}
}
