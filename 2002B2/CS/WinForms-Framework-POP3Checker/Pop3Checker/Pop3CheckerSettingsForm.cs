using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;

namespace Pop3Checker
{
	/// <summary>
	/// Summary description for Pop3CheckerSettingsForm.
	/// </summary>
	public class Pop3CheckerSettingsForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.Label HostNameLabel;
		private System.Windows.Forms.TextBox UserNameEntry;
		private System.Windows.Forms.Button OKAction;
		private System.Windows.Forms.NumericUpDown HostPortEntry;
		private System.Windows.Forms.NumericUpDown RefreshIntervalEntry;
		private System.Windows.Forms.GroupBox MiscellaneousGroup;
		private System.Windows.Forms.NumericUpDown ConnectionTimeoutEntry;
		private System.Windows.Forms.TextBox UserPasswordEntry;
		private System.Windows.Forms.Label UserPasswordLabel;
		private System.Windows.Forms.TextBox HostNameEntry;
		private System.Windows.Forms.Label RefreshIntervalLabel;
		private System.Windows.Forms.Label ConnectionTimeoutLabel;
		private System.Windows.Forms.GroupBox UserGroup;
		private System.Windows.Forms.Label UserNameLabel;
		private System.Windows.Forms.Label HostPortLabel;
		private System.Windows.Forms.Button ApplyAction;
		private System.Windows.Forms.Button CancelAction;
		private System.Windows.Forms.GroupBox HostGroup;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components;

		//Defaults
		private const int mcDefaultConnectionTimeout = 30;
		private const int mcDefaultRefreshInterval = 600;
		private const int mcDefaultHostPort = 110;
		private const string mcApplicationName = "POP3 Checker";

		public Pop3CheckerSettingsForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();

			//Set up form's controls with default values.
			InitializeSettings();
		}

		/// <summary>
		/// Clean up any resources being used.
		/// </summary>
		public override void Dispose()
		{
			base.Dispose();
			components.Dispose();
		}

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.HostNameLabel = new System.Windows.Forms.Label();
			this.UserNameEntry = new System.Windows.Forms.TextBox();
			this.OKAction = new System.Windows.Forms.Button();
			this.HostPortEntry = new System.Windows.Forms.NumericUpDown();
			this.RefreshIntervalEntry = new System.Windows.Forms.NumericUpDown();
			this.MiscellaneousGroup = new System.Windows.Forms.GroupBox();
			this.ConnectionTimeoutEntry = new System.Windows.Forms.NumericUpDown();
			this.UserPasswordEntry = new System.Windows.Forms.TextBox();
			this.UserPasswordLabel = new System.Windows.Forms.Label();
			this.HostNameEntry = new System.Windows.Forms.TextBox();
			this.RefreshIntervalLabel = new System.Windows.Forms.Label();
			this.ConnectionTimeoutLabel = new System.Windows.Forms.Label();
			this.UserGroup = new System.Windows.Forms.GroupBox();
			this.UserNameLabel = new System.Windows.Forms.Label();
			this.HostPortLabel = new System.Windows.Forms.Label();
			this.ApplyAction = new System.Windows.Forms.Button();
			this.CancelAction = new System.Windows.Forms.Button();
			this.HostGroup = new System.Windows.Forms.GroupBox();
			((System.ComponentModel.ISupportInitialize)(this.HostPortEntry)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.RefreshIntervalEntry)).BeginInit();
			((System.ComponentModel.ISupportInitialize)(this.ConnectionTimeoutEntry)).BeginInit();
			this.HostNameLabel.AutoSize = true;
			this.HostNameLabel.Location = new System.Drawing.Point(8, 20);
			this.HostNameLabel.Size = new System.Drawing.Size(64, 13);
			this.HostNameLabel.TabIndex = 0;
			this.HostNameLabel.Text = "&Host Name:";
			this.UserNameEntry.Location = new System.Drawing.Point(92, 16);
			this.UserNameEntry.Size = new System.Drawing.Size(172, 20);
			this.UserNameEntry.TabIndex = 1;
			this.UserNameEntry.Text = "";
			this.OKAction.Location = new System.Drawing.Point(8, 248);
			this.OKAction.TabIndex = 3;
			this.OKAction.Text = "OK";
			this.OKAction.Click += new System.EventHandler(this.OKAction_Click);
			this.HostPortEntry.Location = new System.Drawing.Point(72, 44);
			this.HostPortEntry.Maximum = new System.Decimal(new int[] {65536,
																		  0,
																		  0,
																		  0});
			this.HostPortEntry.Size = new System.Drawing.Size(72, 20);
			this.HostPortEntry.TabIndex = 3;
			this.RefreshIntervalEntry.Increment = new System.Decimal(new int[] {300,
																				   0,
																				   0,
																				   0});
			this.RefreshIntervalEntry.Location = new System.Drawing.Point(164, 44);
			this.RefreshIntervalEntry.Maximum = new System.Decimal(new int[] {3600,
																				 0,
																				 0,
																				 0});
			this.RefreshIntervalEntry.Size = new System.Drawing.Size(72, 20);
			this.RefreshIntervalEntry.TabIndex = 3;
			this.RefreshIntervalEntry.Value = new System.Decimal(new int[] {1800,
																			   0,
																			   0,
																			   0});
			this.MiscellaneousGroup.Controls.AddRange(new System.Windows.Forms.Control[] {this.RefreshIntervalEntry,
																							 this.ConnectionTimeoutEntry,
																							 this.RefreshIntervalLabel,
																							 this.ConnectionTimeoutLabel});
			this.MiscellaneousGroup.Location = new System.Drawing.Point(8, 164);
			this.MiscellaneousGroup.Size = new System.Drawing.Size(276, 76);
			this.MiscellaneousGroup.TabIndex = 2;
			this.MiscellaneousGroup.TabStop = false;
			this.MiscellaneousGroup.Text = "Miscellaneous";
			this.ConnectionTimeoutEntry.Increment = new System.Decimal(new int[] {30,
																					 0,
																					 0,
																					 0});
			this.ConnectionTimeoutEntry.Location = new System.Drawing.Point(164, 16);
			this.ConnectionTimeoutEntry.Maximum = new System.Decimal(new int[] {300,
																				   0,
																				   0,
																				   0});
			this.ConnectionTimeoutEntry.Minimum = new System.Decimal(new int[] {30,
																				   0,
																				   0,
																				   0});
			this.ConnectionTimeoutEntry.Size = new System.Drawing.Size(72, 20);
			this.ConnectionTimeoutEntry.TabIndex = 1;
			this.ConnectionTimeoutEntry.Value = new System.Decimal(new int[] {30,
																				 0,
																				 0,
																				 0});
			this.UserPasswordEntry.Location = new System.Drawing.Point(92, 44);
			this.UserPasswordEntry.Size = new System.Drawing.Size(172, 20);
			this.UserPasswordEntry.TabIndex = 3;
			this.UserPasswordEntry.Text = "";
			this.UserPasswordLabel.AutoSize = true;
			this.UserPasswordLabel.Location = new System.Drawing.Point(8, 48);
			this.UserPasswordLabel.Size = new System.Drawing.Size(84, 13);
			this.UserPasswordLabel.TabIndex = 2;
			this.UserPasswordLabel.Text = "User Pass&word:";
			this.HostNameEntry.Location = new System.Drawing.Point(72, 16);
			this.HostNameEntry.Size = new System.Drawing.Size(192, 20);
			this.HostNameEntry.TabIndex = 1;
			this.HostNameEntry.Text = "";
			this.RefreshIntervalLabel.AutoSize = true;
			this.RefreshIntervalLabel.Location = new System.Drawing.Point(8, 48);
			this.RefreshIntervalLabel.Size = new System.Drawing.Size(138, 13);
			this.RefreshIntervalLabel.TabIndex = 2;
			this.RefreshIntervalLabel.Text = "Seconds &between Checks:";
			this.ConnectionTimeoutLabel.AutoSize = true;
			this.ConnectionTimeoutLabel.Location = new System.Drawing.Point(8, 20);
			this.ConnectionTimeoutLabel.Size = new System.Drawing.Size(160, 13);
			this.ConnectionTimeoutLabel.TabIndex = 0;
			this.ConnectionTimeoutLabel.Text = "&Seconds to Wait for Response:";
			this.UserGroup.Controls.AddRange(new System.Windows.Forms.Control[] {this.UserPasswordLabel,
																					this.UserPasswordEntry,
																					this.UserNameEntry,
																					this.UserNameLabel});
			this.UserGroup.Location = new System.Drawing.Point(8, 84);
			this.UserGroup.Size = new System.Drawing.Size(276, 76);
			this.UserGroup.TabIndex = 1;
			this.UserGroup.TabStop = false;
			this.UserGroup.Text = "User";
			this.UserNameLabel.AutoSize = true;
			this.UserNameLabel.Location = new System.Drawing.Point(8, 20);
			this.UserNameLabel.Size = new System.Drawing.Size(64, 13);
			this.UserNameLabel.TabIndex = 0;
			this.UserNameLabel.Text = "&User Name:";
			this.HostPortLabel.AutoSize = true;
			this.HostPortLabel.Location = new System.Drawing.Point(8, 48);
			this.HostPortLabel.Size = new System.Drawing.Size(54, 13);
			this.HostPortLabel.TabIndex = 2;
			this.HostPortLabel.Text = "Host &Port:";
			this.ApplyAction.Location = new System.Drawing.Point(208, 248);
			this.ApplyAction.TabIndex = 5;
			this.ApplyAction.Text = "&Apply";
			this.ApplyAction.Click += new System.EventHandler(this.ApplyAction_Click);
			this.CancelAction.DialogResult = System.Windows.Forms.DialogResult.Cancel;
			this.CancelAction.Location = new System.Drawing.Point(108, 248);
			this.CancelAction.TabIndex = 4;
			this.CancelAction.Text = "Cancel";
			this.CancelAction.Click += new System.EventHandler(this.CancelAction_Click);
			this.HostGroup.Controls.AddRange(new System.Windows.Forms.Control[] {this.HostPortEntry,
																					this.HostPortLabel,
																					this.HostNameEntry,
																					this.HostNameLabel});
			this.HostGroup.Location = new System.Drawing.Point(8, 4);
			this.HostGroup.Size = new System.Drawing.Size(276, 76);
			this.HostGroup.TabIndex = 0;
			this.HostGroup.TabStop = false;
			this.HostGroup.Text = "Host";
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(290, 279);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {this.CancelAction,
																		  this.ApplyAction,
																		  this.UserGroup,
																		  this.OKAction,
																		  this.HostGroup,
																		  this.MiscellaneousGroup});
			this.Text = "POP3 Checker Settings";
			((System.ComponentModel.ISupportInitialize)(this.HostPortEntry)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.RefreshIntervalEntry)).EndInit();
			((System.ComponentModel.ISupportInitialize)(this.ConnectionTimeoutEntry)).EndInit();

		}
		#endregion

		private void OKAction_Click(object sender, System.EventArgs e)
		{
			SaveSettings();
			this.Close();
		}

		private void CancelAction_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}

		private void ApplyAction_Click(object sender, System.EventArgs e)
		{
			SaveSettings();
		}

		public string HostName
		{
			get
			{
				return this.HostNameEntry.Text;
			}
		}

		public string UserName
		{
			get
			{
				return this.UserNameEntry.Text;
			}
		}

		public string UserPassword
		{
			get
			{
				return this.UserPasswordEntry.Text;
			}
		}

		public int HostPort
		{
			get
			{
				return Convert.ToInt32(this.HostPortEntry.Value);
			}
		}

		public int ConnectionTimeout
		{
			get
			{
				return Convert.ToInt32(this.ConnectionTimeoutEntry.Value);
			}
		}

		public int RefreshInterval
		{
			get
			{
				return Convert.ToInt32(this.RefreshIntervalEntry.Value);
			}
		}

		//Initialize form's controls with default values.
		public void InitializeSettings()
		{
			this.HostPortEntry.Value = Convert.ToDecimal(mcDefaultHostPort);
			this.UserNameEntry.Text = SystemInformation.UserName;
			this.ConnectionTimeoutEntry.Value = Convert.ToDecimal(mcDefaultConnectionTimeout);
			this.RefreshIntervalEntry.Value = Convert.ToDecimal(mcDefaultRefreshInterval);
		}

		//Attempts to retrieve settings from the registry and copy them to the form's controls.
		//Returns success.
		public bool LoadSettings()
		{
			bool failed=false;
			Microsoft.Win32.RegistryKey key = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", true).OpenSubKey(mcApplicationName, true);
			if (key == null)
			{
				failed = true;
			}
			else
			{
				object val;
				//Pattern: Attempt to get a registry value via its key and set
				//an object variable to the value. Check if the returned value
				//is nothing, which probably means the registry key is not present.
				//If it is nothing, indicate failure. Otherwise, set a form control
				//to the value.

				val = key.GetValue("Host Name");
		
				if (val == null)
				{
					failed = true;
				}
				else
				{
					this.HostNameEntry.Text = val.ToString();
				}
		
				val = key.GetValue("Host Port");

				if (val == null)
				{
					failed = true;
				}
				else	
				{
					this.HostPortEntry.Text = val.ToString();
				}
		
				val = key.GetValue("User Name");
				if (val ==null)
				{
					failed = true;
				}
				else
				{
					this.UserNameEntry.Text = val.ToString();
				}
				val = key.GetValue("User Password");
				if (val == null)
				{
					failed = true;
				}
				else
				{
					this.UserPasswordEntry.Text = val.ToString();
				}
		
				val = key.GetValue("Connection Timeout");
				if (val == null)
				{
					failed = true;
				}
				else
				{
					this.ConnectionTimeoutEntry.Text = val.ToString();
				}
				val = key.GetValue("Refresh Interval");
				if (val == null)
				{
					failed = true;
				}
				else
				{
					this.RefreshIntervalEntry.Text = val.ToString();
				}

				return !failed;
			}
			return false;
		}

		//Saves settings from the form's controls to the registry.
		public void SaveSettings()
		{
			//Cache the parent key because we'll need it twice if our key is not present.
			Microsoft.Win32.RegistryKey parentKey = Microsoft.Win32.Registry.CurrentUser.OpenSubKey("Software", true);
			Microsoft.Win32.RegistryKey key = parentKey.OpenSubKey(mcApplicationName, true);

			if (key == null)
			{
				key = parentKey.CreateSubKey(mcApplicationName);
			}
			key.SetValue("Host Name", this.HostNameEntry.Text);
			key.SetValue("Host Port", this.HostPortEntry.Text);
			key.SetValue("User Name", this.UserNameEntry.Text);
			key.SetValue("User Password", this.UserPasswordEntry.Text);
			key.SetValue("Connection Timeout", this.ConnectionTimeoutEntry.Text);
			key.SetValue("Refresh Interval", this.RefreshIntervalEntry.Text);

		}
	}
}
