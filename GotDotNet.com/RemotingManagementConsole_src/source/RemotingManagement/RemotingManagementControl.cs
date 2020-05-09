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
using System.Collections;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Windows.Forms;
using System.Diagnostics;
using System.Text;
using System.IO;
using System.Reflection;
using Ironring.Management.MMC;
#endregion

namespace RKiss.RemotingManagement
{
	public class RemotingManagementControl : System.Windows.Forms.UserControl, ISnapinLink
	{
		#region private members

		private System.Windows.Forms.ColumnHeader columnHeaderName;
		private System.Windows.Forms.ColumnHeader columnHeaderExecPath;
		private System.Windows.Forms.ColumnHeader columnHeaderStartType;
		private System.Windows.Forms.ColumnHeader columnHeaderDesc;
		private System.Windows.Forms.ImageList imageListHostProcesses;
		private System.Windows.Forms.ListView listViewHostProcesses;
		private System.ComponentModel.IContainer components;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.ColumnHeader columnHeaderStatus;
		private System.Windows.Forms.Panel panel;
		//
		BaseNode mobjContextNode = null;
		#endregion

		#region constructor
		public RemotingManagementControl()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RemotingManagementControl));
			this.panel = new System.Windows.Forms.Panel();
			this.label = new System.Windows.Forms.Label();
			this.listViewHostProcesses = new System.Windows.Forms.ListView();
			this.columnHeaderName = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderStatus = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderStartType = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderDesc = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderExecPath = new System.Windows.Forms.ColumnHeader();
			this.imageListHostProcesses = new System.Windows.Forms.ImageList(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel
			// 
			this.panel.AllowDrop = true;
			this.panel.Controls.AddRange(new System.Windows.Forms.Control[] {
																																				this.listViewHostProcesses,
																																				this.label,
																																				this.splitter1});
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(578, 290);
			this.panel.TabIndex = 0;
			this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
			// 
			// label
			// 
			this.label.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label.Location = new System.Drawing.Point(4, 8);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(526, 20);
			this.label.TabIndex = 34;
			this.label.Text = "Host Processes";
			// 
			// listViewHostProcesses
			// 
			this.listViewHostProcesses.AllowDrop = true;
			this.listViewHostProcesses.BackColor = System.Drawing.Color.Gainsboro;
			this.listViewHostProcesses.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewHostProcesses.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																																														this.columnHeaderName,
																																														this.columnHeaderStatus,
																																														this.columnHeaderStartType,
																																														this.columnHeaderDesc,
																																														this.columnHeaderExecPath});
			this.listViewHostProcesses.Cursor = System.Windows.Forms.Cursors.Default;
			this.listViewHostProcesses.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewHostProcesses.GridLines = true;
			this.listViewHostProcesses.LargeImageList = this.imageListHostProcesses;
			this.listViewHostProcesses.Location = new System.Drawing.Point(0, 40);
			this.listViewHostProcesses.Name = "listViewHostProcesses";
			this.listViewHostProcesses.Size = new System.Drawing.Size(578, 250);
			this.listViewHostProcesses.SmallImageList = this.imageListHostProcesses;
			this.listViewHostProcesses.TabIndex = 0;
			this.listViewHostProcesses.View = System.Windows.Forms.View.Details;
			this.listViewHostProcesses.DragDrop += new System.Windows.Forms.DragEventHandler(this.HostProcessesControl_DragDrop);
			this.listViewHostProcesses.DragEnter += new System.Windows.Forms.DragEventHandler(this.HostProcessesControl_DragEnter);
			// 
			// columnHeaderName
			// 
			this.columnHeaderName.Text = "Name";
			this.columnHeaderName.Width = 150;
			// 
			// columnHeaderStatus
			// 
			this.columnHeaderStatus.Text = "Status";
			this.columnHeaderStatus.Width = 65;
			// 
			// columnHeaderStartType
			// 
			this.columnHeaderStartType.Text = "Start type";
			// 
			// columnHeaderDesc
			// 
			this.columnHeaderDesc.Text = "Description";
			this.columnHeaderDesc.Width = 200;
			// 
			// columnHeaderExecPath
			// 
			this.columnHeaderExecPath.Text = "Path to excecutable";
			this.columnHeaderExecPath.Width = 500;
			// 
			// imageListHostProcesses
			// 
			this.imageListHostProcesses.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageListHostProcesses.ImageSize = new System.Drawing.Size(16, 16);
			this.imageListHostProcesses.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListHostProcesses.ImageStream")));
			this.imageListHostProcesses.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(578, 40);
			this.splitter1.TabIndex = 18;
			this.splitter1.TabStop = false;
			// 
			// RemotingManagementControl
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.panel});
			this.Name = "RemotingManagementControl";
			this.Size = new System.Drawing.Size(578, 290);
			this.panel.ResumeLayout(false);
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
			
				//---show details
				listViewHostProcesses.View = View.Details;

				//---populate ViewList
				InsertHostProcessesToViewList();			
			}
		}		
		#endregion

		#region Host Processes to the View List
		private void InsertHostProcessesToViewList() 
		{
			//---processes data
			DataSet ds = new DataSet("Process");

			//---call agent to obtain the process innerxml text
			WinServiceAgent wsa = new WinServiceAgent();
			string strProcessesInnerXml = wsa.GetProcessesInnerXml();
	
			if(strProcessesInnerXml != null) 
			{	
				//---populate dataset
				ds.ReadXml(new StringReader("<processes>" + strProcessesInnerXml + "</processes>"));	

				//---cleanup view list
				listViewHostProcesses.Items.Clear();

				//---populate view list
				listViewHostProcesses.BeginUpdate();
				if(ds.Tables.Contains("process")) 
				{
					foreach(DataRow dr in ds.Tables["process"].Rows) 
					{
						ListViewItem lwi = new ListViewItem(Convert.ToString(dr["name"]), 0);	
						lwi.SubItems.Add(Convert.ToString(dr["status"]));
						lwi.SubItems.Add(Convert.ToString(dr["start"]));
						lwi.SubItems.Add(Convert.ToString(dr["description"])); 
						lwi.SubItems.Add(Convert.ToString(dr["imagepath"]));
						listViewHostProcesses.Items.Add(lwi);
					}
				}
			}
			listViewHostProcesses.EndUpdate();
		}
		#endregion

		#region Events
		private void listViewHostProcesses_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Trace.WriteLine("listView1_MouseUp");	
		}

		private void HostProcessesControl_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop) == true) 
			{
				string[] strFiles=(string[])e.Data.GetData(DataFormats.FileDrop);

				//---only one file at the time
				string strPathToExecutable = strFiles[0];
				Trace.WriteLine(strFiles[0]);

				//---result
				string strProcessName = null;

				//---call agent to do it
				WinServiceAgent wsa = new WinServiceAgent();

				//---insert new host process based on this assembly
				try
				{				
					//---check if service is already inastalled
					strProcessName = wsa.GetServiceName(strPathToExecutable); 
					if(strProcessName != null) 
					{
						throw new Exception(string.Format("The process {0} is already installed.\r\nFile = {1}", strProcessName, strPathToExecutable));
					}
				
					try 
					{
						//---install service
						wsa.Install(strPathToExecutable);

						//---give me its service name
						strProcessName = wsa.GetServiceName(strPathToExecutable); 

						if(strProcessName != null) 
						{
							//---wakeup your handler to insert the new process node
							mobjContextNode.Tag = strPathToExecutable;
							mobjContextNode.OnUser("Drag&Drop_done", strProcessName);
						}
						else 
						{
							string strErrMsg = string.Format("The file {0}\r\nis not a service process, missing a service installer class.", strPathToExecutable);
							throw new Exception(strErrMsg);
						}
					}
					catch(Exception ex) 
					{
						//---this is a seriously error, uninstall service
						wsa.Uninstall(strPathToExecutable);
						throw ex;
					}

					try 
					{
						//---make the config file and also we need a little bit time after installation process.
						wsa.CreateHostProcessConfigFile(strPathToExecutable);
					}
					catch(Exception ex) 
					{
						//---this is only warning
						MessageBox.Show(ex.Message, "Host Processes", MessageBoxButtons.OK, MessageBoxIcon.Warning);
					}
				}
				catch(Exception ex) 
				{
					MessageBox.Show(ex.Message, "Host Processes", MessageBoxButtons.OK, MessageBoxIcon.Error);					
				}					
			}	
		}

		private void HostProcessesControl_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] strFiles=(string[])e.Data.GetData(DataFormats.FileDrop);
				FileInfo fi = new FileInfo(strFiles[0]);
				if(fi.Extension == ".exe" && strFiles.Length == 1)
					e.Effect=DragDropEffects.Copy|DragDropEffects.Scroll;
				else
					e.Effect=DragDropEffects.None;
			}
		}

		private void panel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			listViewHostProcesses.Refresh();		
		}
		#endregion		
	}
}


