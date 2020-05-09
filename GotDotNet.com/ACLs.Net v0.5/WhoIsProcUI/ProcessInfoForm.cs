using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Reflection;

using System.Diagnostics;
using Microsoft.Win32.Security;

namespace WhoIsProcUI
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class ProcessInfoForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.TabControl tabControl1;
		private System.Windows.Forms.TabPage tabPage1;
		private System.Windows.Forms.TabPage pageGroups;
		private System.Windows.Forms.ColumnHeader columnHeader4;
		private System.Windows.Forms.ColumnHeader columnHeader5;
		private System.Windows.Forms.ColumnHeader columnHeader6;
		private System.Windows.Forms.ListView lvProcessGroups;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.ColumnHeader columnHeader7;
		private System.Windows.Forms.ColumnHeader columnHeader8;
		private System.Windows.Forms.ListView lvProcessPrivileges;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.Container components = null;
		private System.Windows.Forms.ColumnHeader columnHeader12;
		private System.Windows.Forms.ColumnHeader columnHeader15;
		private System.Windows.Forms.ColumnHeader columnHeader16;
		private System.Windows.Forms.TabPage pageTokenInfo;
		private System.Windows.Forms.ListView _lv;

		private Process _process;
		public ProcessInfoForm()
		{
			//
			// Required for Windows Form Designer support
			//
			InitializeComponent();
		}

		public void SetProcess(int pid)
		{
			_process = Process.GetProcessById(pid);
			if (components == null)
				components = new System.ComponentModel.Container();

			components.Add(_process);
			this.Text = string.Format("Process Info #{0}", _process.Id);
			using(AccessTokenProcess at = new AccessTokenProcess(_process.Id, TokenAccessType.TOKEN_QUERY))
			{

			}
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.tabControl1 = new System.Windows.Forms.TabControl();
			this.pageTokenInfo = new System.Windows.Forms.TabPage();
			this.tabPage1 = new System.Windows.Forms.TabPage();
			this.lvProcessPrivileges = new System.Windows.Forms.ListView();
			this.columnHeader7 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader8 = new System.Windows.Forms.ColumnHeader();
			this.pageGroups = new System.Windows.Forms.TabPage();
			this.lvProcessGroups = new System.Windows.Forms.ListView();
			this.columnHeader4 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader5 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader6 = new System.Windows.Forms.ColumnHeader();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this._lv = new System.Windows.Forms.ListView();
			this.columnHeader12 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader15 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader16 = new System.Windows.Forms.ColumnHeader();
			this.tabControl1.SuspendLayout();
			this.tabPage1.SuspendLayout();
			this.pageGroups.SuspendLayout();
			this.SuspendLayout();
			// 
			// columnHeader1
			// 
			this.columnHeader1.Text = "Name";
			this.columnHeader1.Width = 89;
			// 
			// columnHeader2
			// 
			this.columnHeader2.Text = "PID";
			this.columnHeader2.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			// 
			// columnHeader3
			// 
			this.columnHeader3.Text = "User name";
			this.columnHeader3.Width = 150;
			// 
			// columnHeader9
			// 
			this.columnHeader9.Text = "Session ID";
			this.columnHeader9.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader9.Width = 70;
			// 
			// columnHeader10
			// 
			this.columnHeader10.Text = "CPU Time";
			this.columnHeader10.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader10.Width = 88;
			// 
			// columnHeader11
			// 
			this.columnHeader11.Text = "Working Set";
			this.columnHeader11.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader11.Width = 85;
			// 
			// columnHeader13
			// 
			this.columnHeader13.Text = "Thread Count";
			this.columnHeader13.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader13.Width = 85;
			// 
			// columnHeader14
			// 
			this.columnHeader14.Text = "Handle Count";
			this.columnHeader14.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader14.Width = 87;
			// 
			// splitter1
			// 
			this.splitter1.Cursor = System.Windows.Forms.Cursors.HSplit;
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Location = new System.Drawing.Point(0, 200);
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(776, 3);
			this.splitter1.TabIndex = 1;
			this.splitter1.TabStop = false;
			// 
			// tabControl1
			// 
			this.tabControl1.Controls.AddRange(new System.Windows.Forms.Control[] {
																					  this.pageTokenInfo,
																					  this.tabPage1,
																					  this.pageGroups});
			this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControl1.Location = new System.Drawing.Point(0, 203);
			this.tabControl1.Name = "tabControl1";
			this.tabControl1.SelectedIndex = 0;
			this.tabControl1.Size = new System.Drawing.Size(776, 315);
			this.tabControl1.TabIndex = 2;
			// 
			// pageTokenInfo
			// 
			this.pageTokenInfo.Location = new System.Drawing.Point(4, 22);
			this.pageTokenInfo.Name = "pageTokenInfo";
			this.pageTokenInfo.Size = new System.Drawing.Size(768, 289);
			this.pageTokenInfo.TabIndex = 2;
			this.pageTokenInfo.Text = "Access Token Info";
			// 
			// tabPage1
			// 
			this.tabPage1.Controls.AddRange(new System.Windows.Forms.Control[] {
																				   this.lvProcessPrivileges});
			this.tabPage1.Location = new System.Drawing.Point(4, 22);
			this.tabPage1.Name = "tabPage1";
			this.tabPage1.Size = new System.Drawing.Size(768, 289);
			this.tabPage1.TabIndex = 0;
			this.tabPage1.Text = "Privileges";
			// 
			// lvProcessPrivileges
			// 
			this.lvProcessPrivileges.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																								  this.columnHeader7,
																								  this.columnHeader8});
			this.lvProcessPrivileges.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvProcessPrivileges.Location = new System.Drawing.Point(0, 0);
			this.lvProcessPrivileges.Name = "lvProcessPrivileges";
			this.lvProcessPrivileges.Size = new System.Drawing.Size(768, 289);
			this.lvProcessPrivileges.TabIndex = 0;
			this.lvProcessPrivileges.View = System.Windows.Forms.View.Details;
			this.lvProcessPrivileges.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvProcessPrivileges_ColumnClick);
			// 
			// columnHeader7
			// 
			this.columnHeader7.Text = "Name";
			this.columnHeader7.Width = 187;
			// 
			// columnHeader8
			// 
			this.columnHeader8.Text = "Status";
			this.columnHeader8.Width = 201;
			// 
			// pageGroups
			// 
			this.pageGroups.Controls.AddRange(new System.Windows.Forms.Control[] {
																					 this.lvProcessGroups});
			this.pageGroups.Location = new System.Drawing.Point(4, 22);
			this.pageGroups.Name = "pageGroups";
			this.pageGroups.Size = new System.Drawing.Size(768, 289);
			this.pageGroups.TabIndex = 1;
			this.pageGroups.Text = "Groups";
			// 
			// lvProcessGroups
			// 
			this.lvProcessGroups.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																							  this.columnHeader4,
																							  this.columnHeader5,
																							  this.columnHeader6});
			this.lvProcessGroups.Dock = System.Windows.Forms.DockStyle.Fill;
			this.lvProcessGroups.Location = new System.Drawing.Point(0, 0);
			this.lvProcessGroups.Name = "lvProcessGroups";
			this.lvProcessGroups.Size = new System.Drawing.Size(768, 289);
			this.lvProcessGroups.TabIndex = 0;
			this.lvProcessGroups.View = System.Windows.Forms.View.Details;
			this.lvProcessGroups.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.lvProcessGroups_ColumnClick);
			this.lvProcessGroups.SelectedIndexChanged += new System.EventHandler(this.lvProcessGroups_SelectedIndexChanged);
			// 
			// columnHeader4
			// 
			this.columnHeader4.Text = "Name";
			this.columnHeader4.Width = 266;
			// 
			// columnHeader5
			// 
			this.columnHeader5.Text = "SID";
			this.columnHeader5.Width = 297;
			// 
			// columnHeader6
			// 
			this.columnHeader6.Text = "Attributes";
			this.columnHeader6.Width = 179;
			// 
			// mainMenu1
			// 
			this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem1,
																					  this.menuItem3});
			// 
			// menuItem1
			// 
			this.menuItem1.Index = 0;
			this.menuItem1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem2});
			this.menuItem1.Text = "&File";
			// 
			// menuItem2
			// 
			this.menuItem2.Index = 0;
			this.menuItem2.Text = "&Close";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem4});
			this.menuItem3.Text = "&View";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 0;
			this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.menuItem4.Text = "&Refresh";
			// 
			// _lv
			// 
			this._lv.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																				  this.columnHeader12,
																				  this.columnHeader15,
																				  this.columnHeader16});
			this._lv.Dock = System.Windows.Forms.DockStyle.Top;
			this._lv.FullRowSelect = true;
			this._lv.Location = new System.Drawing.Point(0, 0);
			this._lv.Name = "_lv";
			this._lv.Size = new System.Drawing.Size(776, 200);
			this._lv.TabIndex = 1;
			this._lv.View = System.Windows.Forms.View.Details;
			this._lv.SelectedIndexChanged += new System.EventHandler(this._lv_SelectedIndexChanged);
			// 
			// columnHeader12
			// 
			this.columnHeader12.Text = "Process ID";
			this.columnHeader12.Width = 108;
			// 
			// columnHeader15
			// 
			this.columnHeader15.Text = "Thread ID";
			this.columnHeader15.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
			this.columnHeader15.Width = 97;
			// 
			// columnHeader16
			// 
			this.columnHeader16.Text = "Impersonating";
			this.columnHeader16.Width = 154;
			// 
			// ProcessInfoForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(776, 518);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.tabControl1,
																		  this.splitter1,
																		  this._lv});
			this.Menu = this.mainMenu1;
			this.Name = "ProcessInfoForm";
			this.Text = "Process Info";
			this.Load += new System.EventHandler(this.Form1_Load);
			this.tabControl1.ResumeLayout(false);
			this.tabPage1.ResumeLayout(false);
			this.pageGroups.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		private void ClearView()
		{
			_lv.Items.Clear();
			ClearTokenView();
		}
		private void ClearTokenView()
		{
			lvProcessGroups.Items.Clear();
			lvProcessPrivileges.Items.Clear();
			pageTokenInfo.Controls.Clear();
		}
		private void NormalizeListViewColumnWidths(ListView lv)
		{
			foreach(ColumnHeader ch in lv.Columns)
			{
				ch.Width = -1;
				//ch.Width += 2; // Bug in XP LV: it's sometimes just a little bit too small
			}
		}
		private void RefreshView()
		{
			ClearView();

			_lv.Items.Add(_process.Id.ToString());

			foreach(ProcessThread t in _process.Threads)
			{
				using(t)
				{
					ListViewItem lvi = new ListViewItem("");
					lvi.SubItems.Add(t.Id.ToString());
					lvi.SubItems.Add(AccessTokenThread.HasToken(t.Id).ToString());
					lvi.Tag = t.Id;
					_lv.Items.Add(lvi);
				}
			}

			_lv.Items[0].Selected = true;
		}
		private void AddTokenProperty(string name, object obj, string propName)
		{
			try
			{
				int dotIndex = propName.IndexOf(".");
				string p1Name = propName;
				string remainName = "";
				if (dotIndex >= 0)
				{
					p1Name = propName.Substring(0, dotIndex);
					remainName = propName.Substring(dotIndex + 1);
				}

				PropertyInfo pi = obj.GetType().GetProperty(p1Name);
				object value = pi.GetValue(obj, null);
				if (remainName != "")
					AddTokenProperty(name, value, remainName);
				else
					AddTokenProperty(name, value);
			}
			catch(Exception e)
			{
				while(e.InnerException != null)
					e = e.InnerException;
				AddTokenProperty(name, "<" + e.Message + ">");
			}
		}
		private void AddTokenProperty(string name, object value)
		{
			int maxY = 0;
			foreach(Control c in pageTokenInfo.Controls)
			{
				if (c.Bottom >= maxY)
					maxY = c.Bottom;
			}

			Label label = new Label();
			label.Top = maxY + 1;
			label.Width = 120;
			label.Text = name;
			label.TextAlign = ContentAlignment.MiddleLeft;
			label.Height = pageTokenInfo.Font.Height + 4;

			pageTokenInfo.Controls.Add(label);

			Label label2 = new Label();
			label2.Top = maxY + 1;
			label2.Left = label.Left + label.Width + 2;
			label2.Width = 10;
			label2.Text = ":";
			label2.TextAlign = ContentAlignment.MiddleCenter;
			label2.Height = pageTokenInfo.Font.Height + 4;

			pageTokenInfo.Controls.Add(label2);

			TextBox textbox = new TextBox();
			textbox.Text = value.ToString();
			textbox.Top = maxY + 1;
			textbox.Width = 300;
			textbox.Left = label2.Left + label2.Width + 2;
			textbox.Height = label.Height;
			textbox.ReadOnly = true;

			pageTokenInfo.Controls.Add(textbox);
		}
		
		private void RefreshTokenView(AccessToken at)
		{
			try
			{
				pageTokenInfo.SuspendLayout();
				try
				{
					AddTokenProperty("User Name", at, "User.CanonicalName");
					AddTokenProperty("User SID", at, "User.SidString");
					AddTokenProperty("Session Id", at, "TerminalServicesSessionId");
					AddTokenProperty("Login Id", at, "Source.Luid.Value");
					AddTokenProperty("Token Type", at, "TokenType");
					if (at.TokenType == TokenType.TokenImpersonation)
					{
						AddTokenProperty("Impersonation Level", at, "ImpersonationLevel");
					}
					AddTokenProperty("Restricted", at, "IsRestricted");
					AddTokenProperty("Owner", at, "Owner.CanonicalName");
					AddTokenProperty("PrimaryGroup", at, "PrimaryGroup.CanonicalName");
				}
				finally
				{
					pageTokenInfo.ResumeLayout(false);
				}

				lvProcessGroups.BeginUpdate();
				try
				{
					foreach(TokenGroup grp in at.Groups)
					{
						ListViewItem item = new ListViewItem(grp.Sid.CanonicalName);
						item.SubItems.Add(grp.Sid.SidString);
						item.SubItems.Add(grp.Attributes.ToString());
						lvProcessGroups.Items.Add(item);
					}

					NormalizeListViewColumnWidths(lvProcessGroups);
				}
				finally
				{
					lvProcessGroups.EndUpdate();
				}

				lvProcessPrivileges.BeginUpdate();
				try
				{
					foreach(TokenPrivilege priv in at.Privileges)
					{
						ListViewItem item = new ListViewItem(priv.Name);
						item.SubItems.Add(priv.Attributes.ToString());
						lvProcessPrivileges.Items.Add(item);
					}

					NormalizeListViewColumnWidths(lvProcessPrivileges);
				}
				finally
				{
					lvProcessPrivileges.EndUpdate();
				}
			}
			catch(Exception e)
			{
				MessageBox.Show(this, e.Message);
			}
		}

		private void Form1_Load(object sender, System.EventArgs e)
		{
			RefreshView();
		}

		private void _lv_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			ClearTokenView();

			if (_lv.SelectedItems.Count <= 0)
				return;

			AccessToken at = null;
			try
			{
				if (_lv.SelectedItems[0].Index == 0)
				{
					at = AccessTokenProcess.TryOpenToken(_process.Id,
							TokenAccessType.TOKEN_QUERY | TokenAccessType.TOKEN_QUERY_SOURCE);

					if (at == null)
						at = AccessTokenProcess.TryOpenToken(_process.Id, TokenAccessType.TOKEN_QUERY);
				}
				else
				{
					int threadId = (int)_lv.SelectedItems[0].Tag;
					if (AccessTokenThread.HasToken(threadId))
					{
						at = AccessTokenThread.TryOpenToken(threadId, 
							TokenAccessType.TOKEN_QUERY | TokenAccessType.TOKEN_QUERY_SOURCE);
						if (at == null)
							at = AccessTokenThread.TryOpenToken(threadId, TokenAccessType.TOKEN_QUERY);
					}
					else
					{
						Label label = new Label();
						label.Top = 10;
						label.Left = 10;
						label.Width = 400;
						label.Text = string.Format("Thread {0} is not currently impersonating", threadId);
						label.TextAlign = ContentAlignment.MiddleLeft;
						label.Height = pageTokenInfo.Font.Height + 4;

						pageTokenInfo.Controls.Add(label);

					}
				}
			}
			catch(Exception ex)
			{
				MessageBox.Show(this, "Error opening token: " + ex.Message);
				this.Close();
			}
			if (at != null)
			{
				using(at)
				{
					RefreshTokenView(at);
				}
			}
		}

		private void lvProcessPrivileges_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			ListViewItemComparer.SortListView(lvProcessPrivileges, e.Column);
		}

		private void lvProcessGroups_SelectedIndexChanged(object sender, System.EventArgs e)
		{
		
		}

		private void lvProcessGroups_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			ListViewItemComparer.SortListView(lvProcessGroups, e.Column);

		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			this.Close();
		}
	
		public int Pid
		{
			get
			{
				return _process.Id;
			}
		}
	}
}
