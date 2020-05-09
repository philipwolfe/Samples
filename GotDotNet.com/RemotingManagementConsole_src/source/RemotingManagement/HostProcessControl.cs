//=============================================================================
//	The Remoting Management Console.
//	(C) Copyright 2003, Roman Kiss (rkiss@pathcom.com)
//	All rights reserved.
//	The code and information is provided "as-is" without waranty of any kind,
//	either expresed or implied.
//
//  Note:	
//	This software using the 3rd party library for MMC (www.ironringsoftware.com)
//-----------------------------------------------------------------------------
//	History:
//		03/31/2003	Roman Kiss				Initial Revision
//=============================================================================
//

#region references
using System;
using System.Diagnostics;
using System.Reflection;
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Text;
using System.Xml;
using System.IO;
using Ironring.Management.MMC;
#endregion

namespace RKiss.RemotingManagement
{
	
	public class HostProcessControl : System.Windows.Forms.UserControl, ISnapinLink
	{
		#region private members
		private System.ComponentModel.IContainer components;	
		private System.Windows.Forms.TextBox textBoxConfigFile;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.TabControl tabControlHostProcess;
		private System.Windows.Forms.TabPage tabPageConfigFile;
		private System.Windows.Forms.TabPage tabPageEventLog;
		private System.Windows.Forms.ColumnHeader columnHeaderTimestampValue;
		private System.Windows.Forms.ColumnHeader columnHeaderId;
		private System.Windows.Forms.ColumnHeader columnHeaderMessage;
		private System.Windows.Forms.ListView listViewEventLog;
		private System.Windows.Forms.ImageList imageListEventLog;
		private System.Windows.Forms.ContextMenu contextMenuEventLog;
		private System.Windows.Forms.MenuItem menuItemRefresh;
		private System.Windows.Forms.MenuItem menuItemClearAll;
		private System.Windows.Forms.ToolTip toolTipEventLog;
		//
		private BaseNode mobjContextNode = null;
		private string mstrPathToConfigFile = null;
		private EventLog mEventLog = new EventLog();
		private System.Windows.Forms.TextBox textBoxMessage;
		private System.Windows.Forms.Splitter splitterMessage;
		private System.Windows.Forms.Panel panelTop;
		private string mstrHostProcessName = null;
		private string mstrHostAssemblyName = null;
		#endregion

		#region constructor
		public HostProcessControl()
		{
			// This call is required by the Windows.Forms Form Designer.
			InitializeComponent();
		}
		#endregion

		#region Clean up any resources being used.
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

		#region Component Designer generated code
		/// <summary> 
		/// Required method for Designer support - do not modify 
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			this.components = new System.ComponentModel.Container();
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(HostProcessControl));
			this.textBoxConfigFile = new System.Windows.Forms.TextBox();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panelTop = new System.Windows.Forms.Panel();
			this.tabControlHostProcess = new System.Windows.Forms.TabControl();
			this.tabPageEventLog = new System.Windows.Forms.TabPage();
			this.textBoxMessage = new System.Windows.Forms.TextBox();
			this.splitterMessage = new System.Windows.Forms.Splitter();
			this.listViewEventLog = new System.Windows.Forms.ListView();
			this.columnHeaderTimestampValue = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderId = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderMessage = new System.Windows.Forms.ColumnHeader();
			this.contextMenuEventLog = new System.Windows.Forms.ContextMenu();
			this.menuItemRefresh = new System.Windows.Forms.MenuItem();
			this.menuItemClearAll = new System.Windows.Forms.MenuItem();
			this.imageListEventLog = new System.Windows.Forms.ImageList(this.components);
			this.tabPageConfigFile = new System.Windows.Forms.TabPage();
			this.label = new System.Windows.Forms.Label();
			this.toolTipEventLog = new System.Windows.Forms.ToolTip(this.components);
			this.panelTop.SuspendLayout();
			this.tabControlHostProcess.SuspendLayout();
			this.tabPageEventLog.SuspendLayout();
			this.tabPageConfigFile.SuspendLayout();
			this.SuspendLayout();
			// 
			// textBoxConfigFile
			// 
			this.textBoxConfigFile.AcceptsReturn = true;
			this.textBoxConfigFile.BackColor = System.Drawing.Color.Gainsboro;
			this.textBoxConfigFile.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxConfigFile.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxConfigFile.Multiline = true;
			this.textBoxConfigFile.Name = "textBoxConfigFile";
			this.textBoxConfigFile.ReadOnly = true;
			this.textBoxConfigFile.ScrollBars = System.Windows.Forms.ScrollBars.Both;
			this.textBoxConfigFile.Size = new System.Drawing.Size(568, 420);
			this.textBoxConfigFile.TabIndex = 0;
			this.textBoxConfigFile.Text = "config file";
			this.textBoxConfigFile.WordWrap = false;
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(576, 40);
			this.splitter1.TabIndex = 17;
			this.splitter1.TabStop = false;
			// 
			// panelTop
			// 
			this.panelTop.Controls.AddRange(new System.Windows.Forms.Control[] {
																																					 this.tabControlHostProcess});
			this.panelTop.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panelTop.Location = new System.Drawing.Point(0, 40);
			this.panelTop.Name = "panelTop";
			this.panelTop.Size = new System.Drawing.Size(576, 446);
			this.panelTop.TabIndex = 19;
			this.panelTop.Paint += new System.Windows.Forms.PaintEventHandler(this.panelTop_Paint);
			// 
			// tabControlHostProcess
			// 
			this.tabControlHostProcess.Alignment = System.Windows.Forms.TabAlignment.Bottom;
			this.tabControlHostProcess.Controls.AddRange(new System.Windows.Forms.Control[] {
																																												this.tabPageEventLog,
																																												this.tabPageConfigFile});
			this.tabControlHostProcess.Dock = System.Windows.Forms.DockStyle.Fill;
			this.tabControlHostProcess.HotTrack = true;
			this.tabControlHostProcess.Name = "tabControlHostProcess";
			this.tabControlHostProcess.SelectedIndex = 0;
			this.tabControlHostProcess.Size = new System.Drawing.Size(576, 446);
			this.tabControlHostProcess.TabIndex = 0;
			this.tabControlHostProcess.SelectedIndexChanged += new System.EventHandler(this.tabControlHostProcess_SelectedIndexChanged);
			// 
			// tabPageEventLog
			// 
			this.tabPageEventLog.Controls.AddRange(new System.Windows.Forms.Control[] {
																																									this.textBoxMessage,
																																									this.splitterMessage,
																																									this.listViewEventLog});
			this.tabPageEventLog.Location = new System.Drawing.Point(4, 4);
			this.tabPageEventLog.Name = "tabPageEventLog";
			this.tabPageEventLog.Size = new System.Drawing.Size(568, 420);
			this.tabPageEventLog.TabIndex = 1;
			this.tabPageEventLog.Text = "EventLog";
			// 
			// textBoxMessage
			// 
			this.textBoxMessage.BackColor = System.Drawing.Color.Gainsboro;
			this.textBoxMessage.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.textBoxMessage.Dock = System.Windows.Forms.DockStyle.Fill;
			this.textBoxMessage.Location = new System.Drawing.Point(0, 375);
			this.textBoxMessage.Multiline = true;
			this.textBoxMessage.Name = "textBoxMessage";
			this.textBoxMessage.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
			this.textBoxMessage.Size = new System.Drawing.Size(568, 45);
			this.textBoxMessage.TabIndex = 4;
			this.textBoxMessage.Text = "";
			// 
			// splitterMessage
			// 
			this.splitterMessage.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitterMessage.Location = new System.Drawing.Point(0, 372);
			this.splitterMessage.MinExtra = 50;
			this.splitterMessage.MinSize = 0;
			this.splitterMessage.Name = "splitterMessage";
			this.splitterMessage.Size = new System.Drawing.Size(568, 3);
			this.splitterMessage.TabIndex = 5;
			this.splitterMessage.TabStop = false;
			// 
			// listViewEventLog
			// 
			this.listViewEventLog.BackColor = System.Drawing.Color.Gainsboro;
			this.listViewEventLog.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewEventLog.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																																											 this.columnHeaderTimestampValue,
																																											 this.columnHeaderId,
																																											 this.columnHeaderMessage});
			this.listViewEventLog.ContextMenu = this.contextMenuEventLog;
			this.listViewEventLog.Dock = System.Windows.Forms.DockStyle.Top;
			this.listViewEventLog.FullRowSelect = true;
			this.listViewEventLog.GridLines = true;
			this.listViewEventLog.HeaderStyle = System.Windows.Forms.ColumnHeaderStyle.Nonclickable;
			this.listViewEventLog.HideSelection = false;
			this.listViewEventLog.HoverSelection = true;
			this.listViewEventLog.MultiSelect = false;
			this.listViewEventLog.Name = "listViewEventLog";
			this.listViewEventLog.Size = new System.Drawing.Size(568, 372);
			this.listViewEventLog.SmallImageList = this.imageListEventLog;
			this.listViewEventLog.Sorting = System.Windows.Forms.SortOrder.Descending;
			this.listViewEventLog.TabIndex = 2;
			this.listViewEventLog.View = System.Windows.Forms.View.Details;
			this.listViewEventLog.ItemActivate += new System.EventHandler(this.listViewEventLog_ItemActivate);
			this.listViewEventLog.SelectedIndexChanged += new System.EventHandler(this.listViewEventLog_SelectedIndexChanged);
			// 
			// columnHeaderTimestampValue
			// 
			this.columnHeaderTimestampValue.Text = "Timestamp";
			this.columnHeaderTimestampValue.Width = 147;
			// 
			// columnHeaderId
			// 
			this.columnHeaderId.Text = "Id";
			this.columnHeaderId.Width = 50;
			// 
			// columnHeaderMessage
			// 
			this.columnHeaderMessage.Text = "Message";
			this.columnHeaderMessage.Width = 1000;
			// 
			// contextMenuEventLog
			// 
			this.contextMenuEventLog.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
																																												this.menuItemRefresh,
																																												this.menuItemClearAll});
			// 
			// menuItemRefresh
			// 
			this.menuItemRefresh.Index = 0;
			this.menuItemRefresh.Text = "Refresh";
			this.menuItemRefresh.Click += new System.EventHandler(this.menuItemRefresh_Click);
			// 
			// menuItemClearAll
			// 
			this.menuItemClearAll.Index = 1;
			this.menuItemClearAll.Text = "Clear All";
			this.menuItemClearAll.Click += new System.EventHandler(this.menuItemClearAll_Click);
			// 
			// imageListEventLog
			// 
			this.imageListEventLog.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageListEventLog.ImageSize = new System.Drawing.Size(16, 16);
			this.imageListEventLog.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListEventLog.ImageStream")));
			this.imageListEventLog.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// tabPageConfigFile
			// 
			this.tabPageConfigFile.Controls.AddRange(new System.Windows.Forms.Control[] {
																																										this.textBoxConfigFile});
			this.tabPageConfigFile.Location = new System.Drawing.Point(4, 4);
			this.tabPageConfigFile.Name = "tabPageConfigFile";
			this.tabPageConfigFile.Size = new System.Drawing.Size(568, 420);
			this.tabPageConfigFile.TabIndex = 0;
			this.tabPageConfigFile.Text = "ConfigFile";
			// 
			// label
			// 
			this.label.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label.Location = new System.Drawing.Point(8, 10);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(526, 20);
			this.label.TabIndex = 33;
			this.label.Text = "Host Process: ";
			// 
			// toolTipEventLog
			// 
			this.toolTipEventLog.AutoPopDelay = 15000;
			this.toolTipEventLog.InitialDelay = 200;
			this.toolTipEventLog.ReshowDelay = 100;
			this.toolTipEventLog.ShowAlways = true;
			// 
			// HostProcessControl
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.label,
																																	this.panelTop,
																																	this.splitter1});
			this.Name = "HostProcessControl";
			this.Size = new System.Drawing.Size(576, 486);
			this.panelTop.ResumeLayout(false);
			this.tabControlHostProcess.ResumeLayout(false);
			this.tabPageEventLog.ResumeLayout(false);
			this.tabPageConfigFile.ResumeLayout(false);
			this.ResumeLayout(false);

		}
		#endregion

		#region ISnapinLink
		public BaseNode ContextNode
		{
			get { return mobjContextNode;  }
			set 
			{ 
				//---initialize data grid
				mobjContextNode = value; 

				//---host process name
				mstrHostProcessName = mobjContextNode.DisplayName;

				//---label
				label.Text = "Host Process: " + mstrHostProcessName;

				//---path to the config file 
				mstrPathToConfigFile = Convert.ToString(mobjContextNode.Tag) + ".config";

				//---assembly name of the host process
				Assembly asm = Assembly.LoadFrom(Convert.ToString(mobjContextNode.Tag));
				mstrHostAssemblyName = asm.FullName.Split(',')[0].Trim();
					
				//---select tab
				tabControlHostProcess.SelectedIndex = 0;

				//---event log
				InitEventLogTab(false);
			}
		}		
		#endregion

		#region ConfigFile Tab
		private void InitConfigFileTab()
		{
			try 
			{
				//---show contents of the config file
				ConfigFileAgent cfa = new ConfigFileAgent();
				string strXml = cfa.OutputXmlLayout(mstrPathToConfigFile);		
	
				//---add line #
				int ii = 1;
				StringBuilder sb = new StringBuilder();
				string[] strArrayXml = strXml.Split(new Char[]{'\r','\n'});
				foreach(string s in strArrayXml) 
				{
					if(s == "") continue;
					sb.AppendFormat("\r\n{0,4:G}   {1}", ii++, s);
				}
				string strConfigFile = sb.ToString();

				//---show up
				textBoxConfigFile.Text = string.Format("path = {0}:\r\n\r\n{1}", mstrPathToConfigFile, strConfigFile);
			}
			catch(Exception ex) 
			{
				textBoxConfigFile.Text = ex.Message;
			}
		}
		#endregion

		#region EventLog Tab 
		private void InitEventLogTab(bool bClear) 
		{
			try 
			{
				//---cleanup listview
				listViewEventLog.Items.Clear();

				//---cleanup textBoxMessage
				textBoxMessage.Clear();

				//---Open the HKEY_LOCAL_MACHINE\Services\CurrentControlSet\Services\EventLog\<log>
				Microsoft.Win32.RegistryKey  system, currentControlSet, services, service;
				system = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("System");
				currentControlSet = system.OpenSubKey("CurrentControlSet");
				services = currentControlSet.OpenSubKey("Services");
				service = services.OpenSubKey("EventLog");

				//---walk through all of them (included custom event logs) and populate the listview
				foreach(EventLog el in EventLog.GetEventLogs()) 
				{				
					if(el.Log != "System" && el.Log != "Security") 
					{
						//---check for our host process name
						foreach(string source in service.OpenSubKey(el.Log).GetSubKeyNames()) 
						{
							if(source == mstrHostProcessName || source == mstrHostAssemblyName) 
							{
								if(bClear == false) 
								{
									//---walk through all entries 
									listViewEventLog.BeginUpdate();
									foreach(EventLogEntry ele in el.Entries) 
									{
										if(ele.Source == mstrHostProcessName || ele.Source == mstrHostAssemblyName)  
										{
											//---now, we have the message to populate the listview
											ListViewItem lwi = new ListViewItem(Convert.ToString(ele.TimeWritten));	
											lwi.ImageIndex = ele.EntryType == EventLogEntryType.Error ? 0 : 
												ele.EntryType == EventLogEntryType.Warning ? 1 : 2;
											lwi.SubItems.Add(Convert.ToString(ele.EventID));		
											lwi.SubItems.Add(ele.Message);		
											listViewEventLog.Items.Add(lwi);
										}
									}
									listViewEventLog.EndUpdate();

									//---select the last event entry
									if(listViewEventLog.Items.Count > 0)
										listViewEventLog.Items[0].Selected = true;
								}
								else 
									el.Clear();
							}
						}
					}
				}
				//--state
				menuItemClearAll.Visible = mEventLog.Entries.Count > 0 ? true : false;
				if(listViewEventLog.Items.Count > 0)
					listViewEventLog.Items[0].Selected = true;

				//---refresh controller
				listViewEventLog.Refresh();
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(ex.Message);
			}
		}

		private void tabControlHostProcess_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			if(tabControlHostProcess.SelectedTab.Name == "tabPageEventLog") 
				InitEventLogTab(false);
			else if(tabControlHostProcess.SelectedTab.Name == "tabPageConfigFile") 
				InitConfigFileTab();
		}

		private void menuItemClearAll_Click(object sender, System.EventArgs e)
		{
			string promptText = "Are you sure to delete all event entries?";
			if(MessageBox.Show(promptText, mstrHostProcessName, MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
			{
				return;
			}
	
			InitEventLogTab(true);
		}

		private void menuItemRefresh_Click(object sender, System.EventArgs e)
		{
			InitEventLogTab(false);
		}

		private void listViewEventLog_ItemActivate(object sender, System.EventArgs e)
		{
			//toolTipEventLog.SetToolTip(listViewEventLog, listViewEventLog.SelectedItems[0].SubItems[2].Text);
		}

		private void listViewEventLog_SelectedIndexChanged(object sender, System.EventArgs e)
		{
			
			//---message textbox
			if(listViewEventLog.SelectedItems.Count == 1) 
			{
				ListViewItem lvi = listViewEventLog.SelectedItems[0];
				textBoxMessage.Text = lvi.SubItems[2].Text;		
			}
		}

		private void panelTop_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			textBoxConfigFile.Refresh();
			tabControlHostProcess.Refresh();

		}
		#endregion
	}
}
