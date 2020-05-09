using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

using System.Diagnostics;
using Microsoft.Win32.Security;

namespace WhoIsProcUI
{
	/// <summary>
	/// Summary description for Form1.
	/// </summary>
	public class MainForm : System.Windows.Forms.Form
	{
		private System.Windows.Forms.ListView listView1;
		private System.Windows.Forms.ColumnHeader columnHeader1;
		private System.Windows.Forms.ColumnHeader columnHeader2;
		private System.Windows.Forms.ColumnHeader columnHeader3;
		private System.Windows.Forms.MainMenu mainMenu1;
		private System.Windows.Forms.MenuItem menuItem1;
		private System.Windows.Forms.MenuItem menuItem2;
		private System.Windows.Forms.MenuItem menuItem3;
		private System.Windows.Forms.MenuItem menuItem4;
		private System.Windows.Forms.ColumnHeader columnHeader9;
		private System.Windows.Forms.ColumnHeader columnHeader10;
		private System.Windows.Forms.ColumnHeader columnHeader11;
		private System.Windows.Forms.ColumnHeader columnHeader13;
		private System.Windows.Forms.ColumnHeader columnHeader14;
		private System.Windows.Forms.StatusBar statusBar1;
		private System.Windows.Forms.Timer timer1;
		private System.Windows.Forms.MenuItem menuItem5;
		private System.Windows.Forms.MenuItem menuItem6;
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

		#region Windows Form Designer generated code
		/// <summary>
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			this.listView1 = new System.Windows.Forms.ListView();
			this.columnHeader1 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader2 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader3 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader9 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader10 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader11 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader13 = new System.Windows.Forms.ColumnHeader();
			this.columnHeader14 = new System.Windows.Forms.ColumnHeader();
			this.mainMenu1 = new System.Windows.Forms.MainMenu();
			this.menuItem1 = new System.Windows.Forms.MenuItem();
			this.menuItem2 = new System.Windows.Forms.MenuItem();
			this.menuItem3 = new System.Windows.Forms.MenuItem();
			this.menuItem4 = new System.Windows.Forms.MenuItem();
			this.statusBar1 = new System.Windows.Forms.StatusBar();
			this.timer1 = new System.Windows.Forms.Timer(this.components);
			this.menuItem5 = new System.Windows.Forms.MenuItem();
			this.menuItem6 = new System.Windows.Forms.MenuItem();
			this.SuspendLayout();
			// 
			// listView1
			// 
			this.listView1.AllowColumnReorder = true;
			this.listView1.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																						this.columnHeader1,
																						this.columnHeader2,
																						this.columnHeader3,
																						this.columnHeader9,
																						this.columnHeader10,
																						this.columnHeader11,
																						this.columnHeader13,
																						this.columnHeader14});
			this.listView1.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listView1.FullRowSelect = true;
			this.listView1.MultiSelect = false;
			this.listView1.Name = "listView1";
			this.listView1.Size = new System.Drawing.Size(776, 496);
			this.listView1.TabIndex = 0;
			this.listView1.View = System.Windows.Forms.View.Details;
			this.listView1.DoubleClick += new System.EventHandler(this.listView1_DoubleClick);
			this.listView1.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView1_ColumnClick);
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
			this.menuItem2.Text = "&Exit";
			this.menuItem2.Click += new System.EventHandler(this.menuItem2_Click);
			// 
			// menuItem3
			// 
			this.menuItem3.Index = 1;
			this.menuItem3.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																					  this.menuItem4,
																					  this.menuItem6,
																					  this.menuItem5});
			this.menuItem3.Text = "&View";
			// 
			// menuItem4
			// 
			this.menuItem4.Index = 0;
			this.menuItem4.Shortcut = System.Windows.Forms.Shortcut.F5;
			this.menuItem4.Text = "&Refresh";
			this.menuItem4.Click += new System.EventHandler(this.menuItem4_Click);
			// 
			// statusBar1
			// 
			this.statusBar1.Location = new System.Drawing.Point(0, 496);
			this.statusBar1.Name = "statusBar1";
			this.statusBar1.Size = new System.Drawing.Size(776, 22);
			this.statusBar1.TabIndex = 2;
			this.statusBar1.Text = "Ready.";
			// 
			// timer1
			// 
			this.timer1.Enabled = true;
			this.timer1.Interval = 1000;
			this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
			// 
			// menuItem5
			// 
			this.menuItem5.Index = 2;
			this.menuItem5.Text = "&Process Info";
			this.menuItem5.Click += new System.EventHandler(this.menuItem5_Click);
			// 
			// menuItem6
			// 
			this.menuItem6.Index = 1;
			this.menuItem6.Text = "-";
			// 
			// MainForm
			// 
			this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
			this.ClientSize = new System.Drawing.Size(776, 518);
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																		  this.listView1,
																		  this.statusBar1});
			this.Menu = this.mainMenu1;
			this.Name = "MainForm";
			this.Text = "Who is process";
			this.Resize += new System.EventHandler(this.MainForm_Resize);
			this.ResumeLayout(false);

		}
		#endregion

		private ProcessItem GetSelectedItem()
		{
			if (listView1.SelectedItems.Count == 0)
				return null;

			return (ProcessItem)listView1.SelectedItems[0].Tag;
		}
		/// <summary>
		/// 
		/// </summary>
		private void RefreshView()
		{
			//ClearView();

			//lock(listView1)
			{
				ProcessItem selItem = GetSelectedItem();
				using(ListViewRefreshHelper lv = new ListViewRefreshHelper(listView1))
				{
					int lvItem = 0;
					foreach(System.Diagnostics.Process p in System.Diagnostics.Process.GetProcesses())
					{
						using(p)
						{
							AccessToken at = AccessTokenProcess.TryOpenToken(p.Id, TokenAccessType.TOKEN_QUERY);

							using(at)
							{
								ProcessItem pi = new ProcessItem(p);

								ListViewItem item = listView1.Items.Add(p.ProcessName); 
								item.Tag = pi;

								if ((selItem != null) && (pi.Equals(selItem)))
									item.Selected = true;

								// PID
								item.SubItems.Add(p.Id.ToString());
								// User Name
								item.SubItems.Add((at != null ? at.User.CanonicalName : ""));
								// Session ID
								item.SubItems.Add((at != null ? at.TerminalServicesSessionId.ToString() : ""));
								// CPU Time
								TimeSpan cpuTime = p.TotalProcessorTime;
								item.SubItems.Add(string.Format("{0}:{1:#00}:{2:#00}", 
									(int)cpuTime.TotalHours, 
									cpuTime.Minutes,
									cpuTime.Seconds));
								// Working set
								item.SubItems.Add(string.Format("{0} K", (p.WorkingSet + 1023)/ 1024));
								// VM Size
								//item.SubItems.Add(string.Format("{0} K", (p.VirtualMemorySize + 1023)/ 1024));
								// Thread count
								item.SubItems.Add(string.Format("{0}", p.Threads.Count));
								// Handle count
								item.SubItems.Add(string.Format("{0}", p.HandleCount));
							}
						}
						lvItem++;
					}
				}
			}
		}
		private void listView1_ColumnClick(object sender, System.Windows.Forms.ColumnClickEventArgs e)
		{
			//lock(listView1)
			{
				ListViewItemComparer.SortListView(listView1, e.Column);
			}
		}

		private void menuItem4_Click(object sender, System.EventArgs e)
		{
			RefreshView();	
		}

		private void timer1_Tick(object sender, System.EventArgs e)
		{
			if (this.WindowState != FormWindowState.Minimized)
			{
				RefreshView();
				GC.Collect(0);
			}
		}

		private void MainForm_Resize(object sender, System.EventArgs e)
		{
			if (this.WindowState == FormWindowState.Minimized)
			{
				this.timer1.Enabled = false;
			}
			else
			{
				RefreshView();
				this.timer1.Enabled = true;
			}
		}

		private void CreateProcessForm(int pid)
		{
			try
			{
				if (components == null)
					components = new Container();

				foreach(Component c in components.Components)
				{
					ProcessInfoForm pif = c as ProcessInfoForm;
					if (pif != null)
					{
						if (pif.Pid == pid)
						{
							if (pif.WindowState == FormWindowState.Minimized)
								pif.WindowState = FormWindowState.Normal;
							pif.Activate();
							return;
						}
					}
				}
				ProcessInfoForm npif = new ProcessInfoForm();
				try
				{
					npif.SetProcess(pid);
					npif.Show();
					components.Add(npif);
					npif.Disposed += new EventHandler(npif_Disposed);
				}
				catch
				{
					npif.Dispose();
					throw;
				}
			}
			catch(Exception e)
			{
				MessageBox.Show(this, 
					string.Format("Error creating form for process {0}: {1}", pid, e.Message));
			}
		}

		private void listView1_DoubleClick(object sender, System.EventArgs e)
		{
			if (listView1.SelectedItems.Count < 1)
			{
				MessageBox.Show(this, 
					"Please select a process in the list.",
					"Error", MessageBoxButtons.OK, MessageBoxIcon.Information);
				return;
			}

			ProcessItem pi = (ProcessItem)listView1.SelectedItems[0].Tag;
			CreateProcessForm(pi.Pid);
		}

		private void npif_Disposed(object sender, EventArgs e)
		{
			ProcessInfoForm pif = sender as ProcessInfoForm;
			if (pif != null)
			{
				components.Remove(pif);
			}
		}

		private void menuItem2_Click(object sender, System.EventArgs e)
		{
			Application.Exit();
		}

		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main() 
		{
			Application.Run(new MainForm());
		}

		private void menuItem5_Click(object sender, System.EventArgs e)
		{
			listView1_DoubleClick(sender, e);		
		}
	}
}
