using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Pop3Checker
{
	/// <summary>
	/// Summary description for Pop3CheckerHostForm.
	/// </summary>
	public class Pop3CheckerHostForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Timer RefreshTimer;
		private System.Windows.Forms.NotifyIcon TrayIcon;
		private System.ComponentModel.IContainer components;

		//TrayIcon status icons
		private Icon mNoMessagesIcon = new Icon("basket16.ico");
		private Icon mNewMessagesIcon = new Icon("newenv16.ico");

		//Pop3Client structure that holds number of messages
		private Pop3AccountSummary mAccountSummary;

		//Pop3CheckerSettingsForm properties for Pop3Client
		private string mHostName;
		private int mHostPort;
		private string mUserName;
		private string mUserPassword;
		private int mConnectionTimeout;
		private int mRefreshInterval;

		//Disables activity when processing previous commands.
		private bool mIsTrayIconDisabled;

		public Pop3CheckerHostForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//Host form is not used directly,
			//so it can be hidden immediately.
			this.Hide();

				//If settings were obtained, initialize app.
				//Otherwise, exit.
				if (GetSettings())
				{
					InitializeTrayIcon();
					if (GetAccountSummary())
					{
						//mAccountSummary info was obtained so change the TrayIcon//s status
						//and start the timer.
						UpdateTrayIcon();
						//mRefreshInterval is stored in seconds, so convert to milliseconds.
						RefreshTimer.Interval = mRefreshInterval * 1000;
						RefreshTimer.Enabled = true;
					}
				}
				else
				{
					this.Close();
				}
		}

		//Obtains settings from Pop3CheckerSettingsForm. If registry entries are
		//absent, it is assumed that this is the first time the app has been run.
		private bool GetSettings()
		{
			return GetSettings(true);
		}

		private bool GetSettings(bool alwaysShowDialog)
			//Optional ByVal alwaysShowDialog As Boolean = false
		{
			bool isConfigLoaded=false;
			Pop3CheckerSettingsForm settingsForm = new Pop3CheckerSettingsForm();
			string strMsg ="";
			if (alwaysShowDialog)
			{
				settingsForm.LoadSettings();
				settingsForm.ShowDialog();

				if (settingsForm.LoadSettings())
				{
					isConfigLoaded = true;
				}
				else
				{		
					strMsg +="It appears that this is the first time you have run ";
					strMsg +="POP3 Checker. Welcome." + "\r\n" + "\r\n";
					strMsg +="Please note that this version of POP3 Checker DOES ";
					strMsg +="NOT ENCRYPT your POP3 " + "account password IN ANY WAY.";
					strMsg +="\r\n" + "Your password is EASILY READABLE in the registry ";
					strMsg +="and in network traffic, so choose your settings carefully!" + "\r\n";
					strMsg +="\r\n" + "Next, the Settings dialog box will appear where you can ";
					strMsg +="customize POP3 Checker.";
					//Settings could not be loaded, so assume that the app has never been run before.
					MessageBox.Show(strMsg, "Welcome to POP3 Checker");
					settingsForm.ShowDialog();
				}
				//The next line will execute only after settingsForm has closed.
				//If settings are still unloadable, exit.
				if (settingsForm.LoadSettings())
				{
					isConfigLoaded = true;
				}
				else
				{
					MessageBox.Show("Some settings were not recorded in the registry so POP3 Checker will now close.", "Some Settings Not Made");
				}
			}

			//Settings were eventually loaded, so copy their contents
			//before settingsForm falls out of scope.
			if (isConfigLoaded)
			{
				ImportSettings(settingsForm);
			}

			return isConfigLoaded;
		}

		//Copies Pop3CheckerSettingsForm properties to local members.
		private void ImportSettings(Pop3CheckerSettingsForm settingsForm)
		{
			mHostName = settingsForm.HostName;
			mHostPort = settingsForm.HostPort;
			mUserName = settingsForm.UserName;
			mUserPassword = settingsForm.UserPassword;
			mConnectionTimeout = settingsForm.ConnectionTimeout;
			mRefreshInterval = settingsForm.RefreshInterval;
		}

		//Sets up TrayIcon and its context menu
		private void InitializeTrayIcon()
		{
			TrayIcon = new System.Windows.Forms.NotifyIcon();
			TrayIcon.Icon = mNoMessagesIcon;
			TrayIcon.Visible = true;
			//Insert all MenuItem objects into an array and add them to
			//the context menu simultaneously
			MenuItem[] mnuItms = new MenuItem[4];

			mnuItms[0] = new MenuItem();
			mnuItms[0].Text = "Check Now";
			mnuItms[0].Click += new System.EventHandler(this.CheckNowSelect);
			mnuItms[0].DefaultItem = true;

			mnuItms[1] = new MenuItem();
			mnuItms[1].Text = "Settings...";
			mnuItms[1].Click += new System.EventHandler(this.SettingsSelect);
			
			mnuItms[2] = new MenuItem("-");

			mnuItms[3] = new MenuItem();
			mnuItms[3].Text = "Exit";
			mnuItms[3].Click += new System.EventHandler(this.ExitSelect);

			ContextMenu  trayIconMnu = new ContextMenu(mnuItms);
			TrayIcon.ContextMenu = trayIconMnu;
		}

		//Instantiates Pop3Client to populate mAccountSummary
		private bool GetAccountSummary()
		{
			//mConnectionTimeout is stored in seconds, so convert to milliseconds.
			Pop3Client client = new Pop3Client(mHostName, mUserName, mUserPassword, mHostPort, mConnectionTimeout);
			bool failed=false;

			if (client.Connect())
			{
				if (client.Authenticate())
				{
					mAccountSummary = client.GetAccountSummary();
					//Explicitly quit and disconnect to free resources
					//sooner, but client//s Finalize also does this --
					//it just may do it later rather than sooner.
					client.Disconnect();
				}
				else
				{
					MessageBox.Show("Could not authenticate as " + mUserName + " with the specified password.", "Authentication Failed");
					failed = true;		
				}
			}
			else
			{
				MessageBox.Show("Could not connect to " + mHostName + " on port " + mHostPort.ToString() + ".", "Connection Failed");
				failed = true;
			}

			return !failed;
		}

	//Modifies icon and tooltip text to reflect mAccountSummary
		private void UpdateTrayIcon()
		{
			if (mAccountSummary.MessageCount == 0)
			{
				TrayIcon.Icon = mNoMessagesIcon;
				TrayIcon.Text = "No messages";
			}
			else
			{
				TrayIcon.Icon = mNewMessagesIcon;
				//Take care to use singular/plural tooltip text depending on message count
				if (mAccountSummary.MessageCount == 1)
				{
					TrayIcon.Text = mAccountSummary.MessageCount.ToString() + " message";
				}
				else
				{
					TrayIcon.Text = mAccountSummary.MessageCount.ToString() + " messages";
				}
			}
		}

		//Executes when "Check Now" menu item is selected from TrayIcon//s context menu.
		public void CheckNowSelect(object sender, System.EventArgs e)
		{
			RefreshTimer.Stop();
			if (GetAccountSummary())
			{
				UpdateTrayIcon();
				RefreshTimer.Start();
			}
		}

	/// <summary>
	/// Clean up any resources being used.
	/// </summary>
	public override void Dispose()
	{
		base.Dispose();
		components.Dispose();
	}

	/// <summary>
	/// The main entry point for the application.
	/// </summary>
	[STAThread]
	static void Main() 
	{
		Application.Run(new Pop3CheckerHostForm());
	}
		#region Windows Form Designer generated code
	/// <summary>
	/// Required method for Designer support - do not modify
	/// the contents of this method with the code editor.
	/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.RefreshTimer = new System.Windows.Forms.Timer(this.components);
			this.TrayIcon = new System.Windows.Forms.NotifyIcon();
			this.RefreshTimer.Tick += new System.EventHandler(this.RefreshTimer_Tick);
			this.TrayIcon.Text = "";
			this.TrayIcon.Visible = true;
			this.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
			this.AutoScale = false;
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.CausesValidation = false;
			this.ClientSize = new System.Drawing.Size(104, 38);
			this.ControlBox = false;
			this.Enabled = false;
			this.MaximizeBox = false;
			this.ShowInTaskbar = false;
			this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;

		}
		#endregion

	//Executes every mRefreshInterval seconds.
	private void RefreshTimer_Tick(object sender, System.EventArgs e)
	{
		//Handles RefreshTimer.Tick;
		RefreshTimer.Stop();
		if (GetAccountSummary())
		{
			UpdateTrayIcon();
			RefreshTimer.Start();
		}
	}

	private void TrayIcon_DoubleClick(object sender, System.EventArgs e)
	{
		RefreshTimer.Stop();
		if (GetAccountSummary())
		{
			UpdateTrayIcon();
			RefreshTimer.Start();
		}
	}

	//Executes when "Settings" menu item is selected from TrayIcon//s context menu.
	public void SettingsSelect(object sender, System.EventArgs e)
	{
		if (!mIsTrayIconDisabled)
		{
			mIsTrayIconDisabled = true;
			RefreshTimer.Stop();
			if (GetSettings(true))
			{
				if (GetAccountSummary())
				{
					UpdateTrayIcon();
					RefreshTimer.Interval = mRefreshInterval * 1000;
					RefreshTimer.Start();
				}
			}
			mIsTrayIconDisabled = false;
		}
	}

	//Executes when "Exit" menu item is selected from TrayIcon//s context menu.
	public void ExitSelect(object sender, System.EventArgs e)
	{
		RefreshTimer.Stop();
		TrayIcon.Visible = false;
		this.Close();
	}
}
}
