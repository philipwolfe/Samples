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
using System.Xml;
using System.Reflection;
using Ironring.Management.MMC;
#endregion

namespace RKiss.RemotingManagement
{
	
	public class PropertiesControl : System.Windows.Forms.UserControl, ISnapinLink
	{
		#region private members
		private System.Windows.Forms.ListView listViewProperties;
		private System.Windows.Forms.ColumnHeader columnHeaderAttribute;
		private System.Windows.Forms.ColumnHeader columnHeaderValue;
		private System.ComponentModel.Container components = null;
		//
		private BaseNode mobjContextNode = null;
		private BaseNode mparent = null;
		private System.Windows.Forms.Splitter splitter1;
		private System.Windows.Forms.Label label;
		private System.Windows.Forms.Panel panel;
		string mstrPropertiesType = null;
		#endregion

		#region constructor
		public PropertiesControl()
		{
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
			this.listViewProperties = new System.Windows.Forms.ListView();
			this.columnHeaderAttribute = new System.Windows.Forms.ColumnHeader();
			this.columnHeaderValue = new System.Windows.Forms.ColumnHeader();
			this.splitter1 = new System.Windows.Forms.Splitter();
			this.label = new System.Windows.Forms.Label();
			this.panel = new System.Windows.Forms.Panel();
			this.SuspendLayout();
			// 
			// listViewProperties
			// 
			this.listViewProperties.BackColor = System.Drawing.Color.Gainsboro;
			this.listViewProperties.BorderStyle = System.Windows.Forms.BorderStyle.None;
			this.listViewProperties.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
																																												 this.columnHeaderAttribute,
																																												 this.columnHeaderValue});
			this.listViewProperties.Dock = System.Windows.Forms.DockStyle.Fill;
			this.listViewProperties.GridLines = true;
			this.listViewProperties.Location = new System.Drawing.Point(0, 40);
			this.listViewProperties.Name = "listViewProperties";
			this.listViewProperties.Size = new System.Drawing.Size(578, 340);
			this.listViewProperties.TabIndex = 1;
			this.listViewProperties.View = System.Windows.Forms.View.Details;
			// 
			// columnHeaderAttribute
			// 
			this.columnHeaderAttribute.Text = "Attribute";
			this.columnHeaderAttribute.Width = 100;
			// 
			// columnHeaderValue
			// 
			this.columnHeaderValue.Text = "Value";
			this.columnHeaderValue.Width = 500;
			// 
			// splitter1
			// 
			this.splitter1.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.splitter1.Dock = System.Windows.Forms.DockStyle.Top;
			this.splitter1.Name = "splitter1";
			this.splitter1.Size = new System.Drawing.Size(578, 40);
			this.splitter1.TabIndex = 2;
			this.splitter1.TabStop = false;
			// 
			// label
			// 
			this.label.BackColor = System.Drawing.Color.FromArgb(((System.Byte)(192)), ((System.Byte)(192)), ((System.Byte)(255)));
			this.label.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.818182F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((System.Byte)(0)));
			this.label.Location = new System.Drawing.Point(12, 10);
			this.label.Name = "label";
			this.label.Size = new System.Drawing.Size(546, 20);
			this.label.TabIndex = 23;
			this.label.Text = "Public and Private Channels";
			// 
			// panel
			// 
			this.panel.Dock = System.Windows.Forms.DockStyle.Fill;
			this.panel.Name = "panel";
			this.panel.Size = new System.Drawing.Size(578, 380);
			this.panel.TabIndex = 24;
			// 
			// PropertiesControl
			// 
			this.Controls.AddRange(new System.Windows.Forms.Control[] {
																																	this.listViewProperties,
																																	this.label,
																																	this.splitter1,
																																	this.panel});
			this.Name = "PropertiesControl";
			this.Size = new System.Drawing.Size(578, 380);
			this.Paint += new System.Windows.Forms.PaintEventHandler(this.PropertiesControl_Paint);
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
			
				listViewProperties.View = View.Details;
						
				//---the host process config file
				string strConfigFilePath = Convert.ToString(mobjContextNode.Tag) + ".config";

				//---parent node
				mparent = mobjContextNode.Snapin.FindNodeByHScope(mobjContextNode.ParentHScopeItem);
				mstrPropertiesType = mparent.DisplayName;

				//---label
				label.Text = mstrPropertiesType + ": ";

				//---populate ViewList
				InsertPropertiesToViewList(strConfigFilePath);
				
				Trace.WriteLine(strConfigFilePath);
			}
		}		
		#endregion

		#region Insert config file element into the View List
		private void InsertPropertiesToViewList(string strConfigFilePath) 
		{
			//---properties 
			string strOuterXml = null;

			//---call config file agent for help
			ConfigFileAgent cfa = new ConfigFileAgent();

			//---invoke the service based on the type 
			if(mstrPropertiesType == "Channels") 
			{
				label.Text +=  mobjContextNode.DisplayName + " ";
				string strChannelName = mobjContextNode.DisplayName;
				strOuterXml = cfa.GetChannel(strChannelName, strConfigFilePath);
			}
			else if(mstrPropertiesType == "RemoteObjects") 
			{
				label.Text +=  mobjContextNode.DisplayName + " ";
				string strRemoteObjectType = mobjContextNode.DisplayName;
				strOuterXml = cfa.GetRemoteObject(strRemoteObjectType, strConfigFilePath);
			}
			else if(mstrPropertiesType == "serverSinks") 
			{
				string strChannelName = mobjContextNode.Snapin.FindNodeByHScope(mparent.ParentHScopeItem).DisplayName;
				string strTypeProvider = mobjContextNode.DisplayName.Split(' ')[0]; 
				string strSinkName = mobjContextNode.DisplayName.Split(' ')[1]; 
				label.Text +=  strSinkName + " ";
				strOuterXml = cfa.GetServerSink(strChannelName, strTypeProvider, strSinkName, strConfigFilePath);
			}
			else if(mstrPropertiesType == "clientSinks") 
			{
				string strChannelName = mobjContextNode.Snapin.FindNodeByHScope(mparent.ParentHScopeItem).DisplayName;
				string strTypeProvider = mobjContextNode.DisplayName.Split(' ')[0]; 
				string strSinkName = mobjContextNode.DisplayName.Split(' ')[1]; 
				label.Text +=  strSinkName + " ";
				strOuterXml = cfa.GetClientSink(strChannelName, strTypeProvider, strSinkName, strConfigFilePath);
			}
			else 
			{
				if(mobjContextNode.DisplayName == "lifetime") 
				{
					label.Text += mobjContextNode.DisplayName;
					strOuterXml = cfa.GetLifetime(strConfigFilePath);
				}
			}

	
			if(strOuterXml != null) 
			{	
				//---retrieve an element from the config file		
				XmlDocument doc = new XmlDocument();
				doc.Load(new StringReader(strOuterXml));
				XmlNode node = doc.FirstChild;

				//---populate view list
				listViewProperties.BeginUpdate();

				//---cleanup view list
				listViewProperties.Items.Clear();

				if(node != null) 
				{
					//---label
					label.Text +=  node.Name;

					//---walk trough all attributes
					foreach(XmlAttribute attr in node.Attributes) 
					{
						ListViewItem lwi = new ListViewItem(attr.Name);	
						lwi.SubItems.Add(attr.Value);		
						listViewProperties.Items.Add(lwi);
					}			
				}

				listViewProperties.EndUpdate();
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

		private void PropertiesControl_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
		{
			listViewProperties.Refresh();
		}
		#endregion		
	}
}
