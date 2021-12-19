using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

namespace SysTraySample
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class Form1 : System.Windows.Forms.Form
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;
  
		//notifyicon icons
		private Icon mSmileIcon = new Icon("face02.ico");
		private Icon mFrownIcon = new Icon("face04.ico");
		private bool mSmileDisplayed;
		private System.Windows.Forms.NotifyIcon NotifyIcon;
		private ContextMenu notifyiconMnu;
		
		public Form1()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
			
			//this form isn't used directly so hide it immediately
			this.Hide();
			this.Visible=false;
			
			//setup the tray icon
			Initializenotifyicon();
			}

		private void Initializenotifyicon()
		{
			//setup the default icon		
			NotifyIcon = new System.Windows.Forms.NotifyIcon();
			NotifyIcon.Icon = mSmileIcon;
			NotifyIcon.Text = "Right Click for the menu";
			NotifyIcon.Visible = true;
			mSmileDisplayed = true;

			//Insert all MenuItem objects into an array and add them to
			//the context menu simultaneously
			MenuItem[] mnuItms = new MenuItem[4];
			//mnuItms[0] = new MenuItem("Show Form...", new EventHandler(this.ShowFormSelect));
			mnuItms[0] = new MenuItem();
			mnuItms[0].Text = "Show Form...";
			mnuItms[0].Click += new System.EventHandler(this.ShowFormSelect);
			mnuItms[0].DefaultItem = true;
			
			mnuItms[1] = new MenuItem();
			mnuItms[1].Text = "Toggle Image";
			mnuItms[1].Click += new System.EventHandler(this.ToggleImageSelect);

			mnuItms[2] = new MenuItem("-");

			mnuItms[3] = new MenuItem();
			mnuItms[3].Text = "Exit";
			mnuItms[3].Click += new System.EventHandler(this.ExitSelect);

			notifyiconMnu = new ContextMenu(mnuItms);
			NotifyIcon.ContextMenu = notifyiconMnu;
		
		}

		public void ShowFormSelect(object sender, System.EventArgs e)
		{
			//Display the settings dialog			
			SettingsForms frmSettings = new SettingsForms();
			frmSettings.ShowDialog();
		}

		public void ToggleImageSelect(object sender, System.EventArgs e)
		{
		//called when the user selects the 'Toggle Image' context menu

			//determine which icon is currently visible and switch it
			if (mSmileDisplayed)
			{
				//called when the user selects the 'Show Form' context menu
				NotifyIcon.Icon = mFrownIcon;
				NotifyIcon.Text = "Sad";
				mSmileDisplayed = false;
			}
			else
			{
				NotifyIcon.Icon = mSmileIcon;
				NotifyIcon.Text = "Happy";
				mSmileDisplayed = true;
			}

		}

		public void ExitSelect(object sender, System.EventArgs e)
			//called when the user selects the 'Exit' context menu
		{
			//hide the tray icon
			NotifyIcon.Visible = false;

			//close up
			this.Close();
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
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.components = new System.ComponentModel.Container();
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(104, 19);
			this.ControlBox = false;
			this.Enabled = false;
			this.MaximizeBox = false;
			this.MinimizeBox = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
			this.Opacity = 0;
			this.ShowInTaskbar = false;
			this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
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
	}
}
