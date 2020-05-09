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
	public class RemoteObjectsControl : System.Windows.Forms.UserControl, ISnapinLink
	{
		#region private members
		BaseNode mobjContextNode = null;
		private System.Windows.Forms.ColumnHeader columnHeaderEndpoint;
		private System.Windows.Forms.ListView listViewRemoteObjects;
		private System.Windows.Forms.ImageList imageListRemoteObjects;
		private System.Windows.Forms.ColumnHeader columnHeaderMode;
		private System.Windows.Forms.ColumnHeader columnHeaderAssembly;
		private System.Windows.Forms.ColumnHeader columnHeaderRemoteObject;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.Panel panel;
		private System.ComponentModel.IContainer components;
		#endregion

		#region constructor
		public RemoteObjectsControl()
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
			System.Resources.ResourceManager resources = new System.Resources.ResourceManager(typeof(RemoteObjectsControl));
			this.panel = new System.Windows.Forms.Panel();
			this.label = new System.Windows.Forms.Label();
			this.listViewRemoteObjects = new System.Windows.Forms.ListView();
			this.columnHeaderRemoteObject = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderMode = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderEndpoint = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderAssembly = new System.Windows.Forms.ColumnHeader();
			this.imageListRemoteObjects = new System.Windows.Forms.ImageList(this.components);
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.panel.SuspendLayout();
			this.SuspendLayout();
			// 
			// panel
			// 
			this.panel.Controls.AddRange(new System.Windows.Forms.Control[] {
																																				this.label,
																																				this.listViewRemoteObjects,
																																				this.splitter1});
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(492, 324);
			this.panel.TabIndex = 0;
			this.panel.Paint += new System.Windows.Forms.PaintEventHandler(this.panel_Paint);
			// 
			// label
			// 
			this.label.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label.Location = new System.Drawing.Point(6, 10);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(526, 20);
			this.label.TabIndex = 35;
			this.label.Text = "Host Processes";
			// 
			// listViewRemoteObjects
			// 
			this.listViewRemoteObjects.AllowColumnReorder = true;
			this.listViewRemoteObjects.BackColor = System.Drawing.Color.Gainsboro;
			this.listViewRemoteObjects.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewRemoteObjects.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																																														this.columnHeaderRemoteObject,
																																														this.columnHeaderMode,
																																														this.columnHeaderEndpoint,
																																														this.columnHeaderAssembly});
			this.listViewRemoteObjects.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewRemoteObjects.GridLines = true;
			this.listViewRemoteObjects.LargeImageList = this.imageListRemoteObjects;
			this.listViewRemoteObjects.Location = new System.Drawing.Point(0, 40);
			this.listViewRemoteObjects.Name = "listViewRemoteObjects";
			this.listViewRemoteObjects.Size = new System.Drawing.Size(492, 284);
			this.listViewRemoteObjects.SmallImageList = this.imageListRemoteObjects;
			this.listViewRemoteObjects.TabIndex = 0;
			this.listViewRemoteObjects.View = System.Windows.Forms.View.Details;
			this.listViewRemoteObjects.ItemActivate += new System.EventHandler(this.imageListRemoteObjects_ItemActivate);
			this.listViewRemoteObjects.MouseUp += new System.Windows.Forms.MouseEventHandler(this.imageListRemoteObjects_MouseUp);
			// 
			// columnHeaderRemoteObject
			// 
			this.columnHeaderRemoteObject.Text = "Remote Object";
			this.columnHeaderRemoteObject.Width = 200;
			// 
			// columnHeaderMode
			// 
			this.columnHeaderMode.Text = "Mode";
			this.columnHeaderMode.Width = 100;
			// 
			// columnHeaderEndpoint
			// 
			this.columnHeaderEndpoint.Text = "Endpoint";
			this.columnHeaderEndpoint.Width = 100;
			// 
			// columnHeaderAssembly
			// 
			this.columnHeaderAssembly.Text = "Assembly";
			this.columnHeaderAssembly.Width = 500;
			// 
			// imageListRemoteObjects
			// 
			this.imageListRemoteObjects.ColorDepth = System.Windows.Forms.ColorDepth.Depth8Bit;
			this.imageListRemoteObjects.ImageSize = new System.Drawing.Size(16, 16);
			this.imageListRemoteObjects.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListRemoteObjects.ImageStream")));
			this.imageListRemoteObjects.TransparentColor = System.Drawing.Color.Transparent;
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(492, 40);
			this.splitter1.TabIndex = 19;
			this.splitter1.TabStop = false;
			// 
			// RemoteObjectsControl
			// 
			this.AllowDrop = true;
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.panel});
			this.Name = "RemoteObjectsControl";
			this.Size = new System.Drawing.Size(492, 324);
			this.DragEnter += new System.Windows.Forms.DragEventHandler(this.RemoteObjectsControl_DragEnter);
			this.DragDrop += new System.Windows.Forms.DragEventHandler(this.RemoteObjectsControl_DragDrop);
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

				//---label 
				BaseNode parent = mobjContextNode.Snapin.FindNodeByHScope(mobjContextNode.ParentHScopeItem);
				label.Text = parent.DisplayName + ": " + mobjContextNode.DisplayName;
			
				listViewRemoteObjects.View = View.Details;
						
				//---the host process config file
				string strConfigFilePath = Convert.ToString(mobjContextNode.Tag) + ".config";

				//---populate ViewList
				InsertServiceSectionToViewList(strConfigFilePath);
				
				Trace.WriteLine(strConfigFilePath);
			}
		}		
		#endregion

		#region Service Config  to the View List
		private void InsertServiceSectionToViewList(string strConfigFilePath) 
		{
			//---appSettings data
			DataSet ds = new DataSet("Service");

			//---call scanner to obtain the service innerxml text
			ConfigFileAgent cfa = new ConfigFileAgent();
			string strServiceOuterXml = cfa.GetServiceOuterXml(strConfigFilePath);
	
			if(strServiceOuterXml != null) 
			{	
				//---populate dataset
				ds.ReadXml(new StringReader(strServiceOuterXml));	

				//---cleanup view list
				listViewRemoteObjects.Items.Clear();

				//---populate view list
				listViewRemoteObjects.BeginUpdate();
				if(ds.Tables.Contains("wellknown")) 
				{
					foreach(DataRow dr in ds.Tables["wellknown"].Rows) 
					{
						string[] strType = Convert.ToString(dr["type"]).Split(new char[]{','}, 2);
						ListViewItem lwi = new ListViewItem(strType[0], 0);		
						lwi.SubItems.Add(Convert.ToString(dr["mode"]));
						lwi.SubItems.Add(Convert.ToString(dr["objectUri"]));
						lwi.SubItems.Add(strType[1]);
						listViewRemoteObjects.Items.Add(lwi);
					}
				}

				if(ds.Tables.Contains("activated"))
				{
					foreach(DataRow dr in ds.Tables["activated"].Rows) 
					{
						string[] strType = Convert.ToString(dr["type"]).Split(new char[]{','}, 2);
						ListViewItem lwi = new ListViewItem(strType[0], 0);		
						lwi.SubItems.Add("activated");
						lwi.SubItems.Add(" ");
					  lwi.SubItems.Add(strType[1]);
						listViewRemoteObjects.Items.Add(lwi);
					}	
				}
				listViewRemoteObjects.EndUpdate();	
			}		
		}
		#endregion

		#region Events
		private void imageListRemoteObjects_MouseUp(object sender, System.Windows.Forms.MouseEventArgs e)
		{
			Trace.WriteLine("imageListRemoteObjects_MouseUp");		
		}

		private void imageListRemoteObjects_ItemActivate(object sender, System.EventArgs e)
		{
			Trace.WriteLine("imageListRemoteObjects_ItemActivate");
		} 

		private void RemoteObjectsControl_DragDrop(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop) == true) 
			{
				//---only one file at the time
				string[] strFiles=(string[])e.Data.GetData(DataFormats.FileDrop);
				string strAssemblyPath = strFiles[0];

				//---select the remote object from this assembly
				try
				{
					ArrayList strRemoteObjects = new ArrayList();

					Assembly asm = Assembly.LoadFrom(strAssemblyPath);
					foreach(Module m in asm.GetModules())
					{
						foreach(Type t in m.GetTypes()) 
						{
							if(t.IsMarshalByRef == true) 
							{
								strRemoteObjects.Add(t.FullName + ", " + asm.FullName);
							}
						}
					}

					if(strRemoteObjects.Count == 0) 
					{
						string strErrMsg = string.Format("The assembly {0} doesn't have a remote object.", strAssemblyPath);
						throw new Exception(strErrMsg);
					}
					else 
					{
						Trace.WriteLine(string.Format("Drag & Drop: Assembly={0}, numberOfObjects={1}", strAssemblyPath, strRemoteObjects.Count));

						//---insert to the object form and user will decide the next step
						string strConfigFilePath = Convert.ToString(mobjContextNode.Tag)+ ".config";
						ObjectForm formOBJ = new ObjectForm(mobjContextNode, strRemoteObjects, strConfigFilePath);
						formOBJ.Show();
						formOBJ.OnTextChanged(this, null);
					}
				}
				catch(Exception ex) 
				{
					MessageBox.Show(ex.Message, "Remote Objects", MessageBoxButtons.OK, MessageBoxIcon.Warning);
				}				
			}	
		}

		private void RemoteObjectsControl_DragEnter(object sender, System.Windows.Forms.DragEventArgs e)
		{
			if(e.Data.GetDataPresent(DataFormats.FileDrop))
			{
				string[] strFiles=(string[])e.Data.GetData(DataFormats.FileDrop);
				FileInfo fi = new FileInfo(strFiles[0]);
				if((fi.Extension == ".exe" || fi.Extension == ".dll") && strFiles.Length == 1)
					e.Effect=DragDropEffects.Copy|DragDropEffects.Scroll;
				else
					e.Effect=DragDropEffects.None;
			}
		}

		private void panel_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			listViewRemoteObjects.Refresh();
		}
		#endregion		
	}
}