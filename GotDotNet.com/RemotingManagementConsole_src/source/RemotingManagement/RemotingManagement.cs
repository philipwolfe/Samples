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
using System.ComponentModel.Design.Serialization;
using System.Runtime.InteropServices;
using Ironring.Management.MMC;
using System.Drawing;
using System.Data;
using System.IO;
using System.Xml;
using System.Collections;
using System.ServiceProcess;
using System.Windows.Forms.ComponentModel;
#endregion


namespace RKiss.RemotingManagement
{
	
	[
	SnapinIn("RemotingManagement", "rkiss@pathcom.com", "1.0.0.0"),
	ProgId("RKiss.RemotingManagement"),
	Guid("D61EB29B-6371-49b9-9629-5E6B3685C1CD")
	]
	public class RemotingManagement : SnapinBase
	{
		#region private members
		protected ImageList mSharedResultViewImages;
		private Hashtable mWS = new Hashtable();
		private EventLog mEventLog = new EventLog();


		private int intOpenFolderImage = 0;
		private int intCloseFolderImage = 0;
		private int intHostProcessImage = 0;
		private int intObjectServicesImage = 0;
		private int intRemoteObjectImage = 0;
		private int intChannelFolderImage = 0;
		private int intXmlTreeImage = 0;
		private int intLifetimeImage = 0;
		private int intSinksImage = 0;
		private int intSingleSinkImage = 0;
		private int intSectionImage = 0;
		#endregion

		#region constructor
		public RemotingManagement()
		{
			try
			{
				Trace.WriteLine("RemotingManagement constructor start ...");

				//---common properties
				intCloseFolderImage = AddImage("RKiss.RemotingManagement.images.clsdfold.ico");
				intOpenFolderImage = AddImage("RKiss.RemotingManagement.images.openfold.ico");
				intChannelFolderImage = AddImage("RKiss.RemotingManagement.images.Channel.ico");
				intHostProcessImage = AddImage("RKiss.RemotingManagement.images.Process.ico");
				intRemoteObjectImage = AddImage("RKiss.RemotingManagement.images.Object.ico");
				intXmlTreeImage = AddImage("RKiss.RemotingManagement.images.XMLTree.ico");
				intLifetimeImage = AddImage("RKiss.RemotingManagement.images.TIMER.ICO");
				intSinksImage = AddImage("RKiss.RemotingManagement.images.Sinks.ico");
				intSingleSinkImage = AddImage("RKiss.RemotingManagement.images.SingleSink.ico");
				intSectionImage = AddImage("RKiss.RemotingManagement.images.Section.ico");
				intObjectServicesImage = AddImage("RKiss.RemotingManagement.images.ObjectServices.ico");

				//
				FormNode rootnode = new FormNode(this);
				rootnode.ControlType = Type.GetType("RKiss.RemotingManagement.RemotingManagementControl");
				rootnode.DisplayName = "Remoting Host Processes";
				//rootnode.ClosedImageIndex = intRemotingManagementToolImage;
				//rootnode.OpenImageIndex = intRemoteObjectsFolderImage;
			
				rootnode.AddNewMenuItem(new MenuItem("Process", "Add new windows service host process", new MenuCommandHandler(MenuHandlerNewProcess)));
				base.RootNode = rootnode;
				
				//---events
				rootnode.OnSelectScopeEvent += new NodeNotificationHandler(OnSelectEvent_HostProcesses);
				rootnode.OnRefreshEvent += new NodeNotificationHandler(OnRefreshEvent_Root);
				rootnode.OnContextHelpEvent += new NodeNotificationHandler(OnContextHelp_Root);

				//---this is a Drag&Drop notification
				rootnode.OnUserEvent += new NodeNotificationHandler(OnUserEvent_HostProcess);

				//---do it
				HostProcessScanner(false);

				Trace.WriteLine("RemotingManagement constructor done");
				
			}
			catch(Exception e)
			{
				System.Diagnostics.Debug.WriteLine("Initialization exception - " + e.ToString());
			}
		}

		private void OnContextHelp_Root(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnSelectEvent: sender={0}", selNode.DisplayName));
			
			//---call help index
			HelpForm objHF = new HelpForm();
			objHF.Show();
		}

		private void OnRefreshEvent_Root(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;
			string strServiceName = selNode.DisplayName;
			object strExecPath = selNode.Tag;

			//---checkpoint
			Trace.WriteLine(string.Format("OnRefreshEvent: sender={0}", selNode.DisplayName));

			try 
			{
				//---destroy all children 
				selNode.Snapin.ConsoleNameSpace.DeleteItem((uint)selNode.HScopeItem, 0);

				//---recreate process node
				HostProcessScanner(true);
	
				//---scope
				selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.HScopeItem);
				selNode.Snapin.ResultViewConsole.Expand(selNode.HScopeItem, 1);
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("OnRefreshEvent_Root - failed, error = {0}", ex.Message));
			}				
		}
		#endregion

		#region HostProcess
		private void HostProcessScanner(bool bRefresh) 
		{
			
			//---properties
			Microsoft.Win32.RegistryKey  system, currentControlSet, services, service; 

			//---Open the HKEY_LOCAL_MACHINE\Services\CurrentControlSet\Services\<ServiceName>
			system = Microsoft.Win32.Registry.LocalMachine.OpenSubKey("System");
			currentControlSet = system.OpenSubKey("CurrentControlSet");
			services = currentControlSet.OpenSubKey("Services");

			foreach(ServiceController sc in ServiceController.GetServices()) 
			{
				string strServiceName = sc.DisplayName;
				service = services.OpenSubKey(strServiceName);

				Trace.WriteLine(string.Format("HostProcess Scanner: {0}", strServiceName));

				if(service != null) 
				{
					string strExecPath = Convert.ToString(service.GetValue("ImagePath"));
					string strHostProcessConfigFile = strExecPath + ".config";

					if(File.Exists(strHostProcessConfigFile) == true) 
					{
						//bool bRunning = (sc.Status == ServiceControllerStatus.Running) ? true : false;
						BaseNode node = CreateProcessNodeTree(null, strServiceName, strExecPath);
						if(bRefresh) 
						{
							node.Insert(base.RootNode);
						}
						else
							base.RootNode.AddChild(node);						
					}		
				}
			}
		}	

		protected BaseNode CreateProcessNodeTree(BaseNode parentNode, string nodeName, object nodeTag)
		{
			Trace.WriteLine(string.Format("CreateProcessNodeTree: {0}", nodeName));

			FormNode node = new FormNode(this);
			node.ControlType = Type.GetType("RKiss.RemotingManagement.HostProcessControl");
			node.DisplayName = nodeName;	
			node.Tag = nodeTag;
			node.OpenImageIndex = intHostProcessImage;
			node.ClosedImageIndex = intHostProcessImage;
	
			//---events
			node.OnSelectScopeEvent += new NodeNotificationHandler(OnSelectEvent_HostProcess);
			node.OnRefreshEvent += new NodeNotificationHandler(OnRefreshEvent_HostProcess);
			node.OnDeleteEvent += new NodeNotificationHandler(OnDeleteEvent_HostProcess);
			node.OnQueryPropertiesEvent += new NodeNotificationHandler(OnQueryProperties_HostProcess);
			node.OnContextHelpEvent += new NodeNotificationHandler(OnContextHelp_HostProcess);

			//---this is a post-process notification from the user form
			node.OnUserEvent += new NodeNotificationHandler(OnUserEvent_HostProcess);

			//---task menu
			node.AddTaskMenuItem(new MenuItem("Stop", "Stop this host process", new MenuCommandHandler(MenuHandlerProcessStop)));
			node.AddTaskMenuItem(new MenuItem("Restart", "Restart this host process", new MenuCommandHandler(MenuHandlerProcessRestart)));
			node.AddTaskMenuItem(new MenuItem("Start", "Start this host process", new MenuCommandHandler(MenuHandlerProcessStart)));

			//---inset node
			if(parentNode != null)
			{			
				parentNode.AddChild(node);
			}

			//---my children
			CreateHostProcessNodes(node, false); 

			return node;
		}

		private void OnContextHelp_HostProcess(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnSelectEvent: sender={0}", selNode.DisplayName));
			
			//---call help index
			HelpForm objHF = new HelpForm();
			objHF.Show();
		}

		private void OnSelectEvent_HostProcesses(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnSelectEvent: sender={0}", selNode.DisplayName));
	
			//---ask snap-in for the following buttons		
			IConsoleVerb icv;       
			selNode.Snapin.ResultViewConsole.QueryConsoleVerb(out icv);
			icv.SetVerbState(MMC_VERB.REFRESH, MMC_BUTTON_STATE.ENABLED, 1);
		
			//---status text
			selNode.Snapin.ResultViewConsole.SetStatusText("The windows services to host remoting objects connected via channels");
		}

		protected void CreateHostProcessNodes(BaseNode parentNode, bool bRefresh) 
		{
			try 
			{
				//---childs
				CreateLifetimeNodeTree(parentNode, "lifetime", bRefresh);
				RemoteObjects(parentNode, "RemoteObjects", bRefresh);
				Channels(parentNode, "Channels", bRefresh);
				AppSettings(parentNode, "AppSettings", bRefresh);
				ConfigSections(parentNode, "ConfigSections", bRefresh);	
			}
			catch(Exception ex) 
			{
				Trace.WriteLine("CreateHostProcessNodes failed: " + ex.Message);
			}
		}

		protected void MenuHandlerNewProcess(object sender, BaseNode arg)
		{
			HostProcessForm formHP = new HostProcessForm(arg, null);		
			formHP.Show();
		}
	
		private void OnRefreshEvent_HostProcess(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;
			string strServiceName = selNode.DisplayName;
			object strExecPath = selNode.Tag;

			//---checkpoint
			Trace.WriteLine(string.Format("OnRefreshEvent: sender={0}", selNode.DisplayName));

			try 
			{
				//---destroy all children 
				selNode.Snapin.ConsoleNameSpace.DeleteItem((uint)selNode.HScopeItem, 0);

				//---get the process status
				WinServiceAgent wsa = new WinServiceAgent();
				wsa.Status(strServiceName);

				//---recreate process node
				CreateHostProcessNodes(selNode, true);
	
				//---scope
				selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.HScopeItem);
				selNode.Snapin.ResultViewConsole.Expand(selNode.HScopeItem, 1);
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("OnRefreshEvent_HostProcess - failed, error = {0}", ex.Message));
			}				
		}

		private void OnUserEvent_HostProcess(object sender, NodeEventArgs args)
		{	
			try 
			{
				//---inputs
				BaseNode parentNode = sender as BaseNode;
				NameValueArgs nva = args as NameValueArgs;
				string strCheckpoint = nva.Key;
				string strHostProcessName = Convert.ToString(nva.Val);

				//---checkpoint
				Trace.WriteLine(string.Format("User Event: sender={0}, checkpoint={1}, val={2}", parentNode.DisplayName, strCheckpoint, strHostProcessName));
			
				//---action		
				BaseNode node = CreateProcessNodeTree(null, strHostProcessName, parentNode.Tag);
				node.Insert(parentNode);		

				//---expand new process
				node.Snapin.ResultViewConsole.SelectScopeItem(node.HScopeItem);
				node.Snapin.ConsoleNameSpace.Expand((uint)node.HScopeItem);	
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("OnUserEvent_HostProcess - failed, error = {0}", ex.Message));
			}
		}

		private void OnSelectEvent_HostProcess(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnSelectEvent: sender={0}", selNode.DisplayName));
	
			//---ask snap-in for the following buttons		
			IConsoleVerb icv;       
			selNode.Snapin.ResultViewConsole.QueryConsoleVerb(out icv);
			icv.SetVerbState(MMC_VERB.REFRESH, MMC_BUTTON_STATE.ENABLED, 1);
			icv.SetVerbState(MMC_VERB.PROPERTIES, MMC_BUTTON_STATE.ENABLED, 1);
			icv.SetVerbState(MMC_VERB.DELETE, MMC_BUTTON_STATE.ENABLED, 1);

			//---status text
			selNode.Snapin.ResultViewConsole.SetStatusText("The windows service to host remoting objects based on their configuration in the config file.");

			//---process status
			try 
			{
				WinServiceAgent wsa = new WinServiceAgent();
				ServiceControllerStatus status = wsa.Status(selNode.DisplayName);

				if(status == ServiceControllerStatus.Running) 
				{
					selNode.GetMenuItem(CCM.INSERTIONALLOWED_TASK, "Start").Visible = false;
					selNode.GetMenuItem(CCM.INSERTIONALLOWED_TASK, "Stop").Visible = true;
					selNode.GetMenuItem(CCM.INSERTIONALLOWED_TASK, "Restart").Visible = true;
				}
				else 
				{
					selNode.GetMenuItem(CCM.INSERTIONALLOWED_TASK, "Start").Visible = true;
					selNode.GetMenuItem(CCM.INSERTIONALLOWED_TASK, "Stop").Visible = false;
					selNode.GetMenuItem(CCM.INSERTIONALLOWED_TASK, "Restart").Visible = false;
				}
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("OnSelectEvent: service status = {0}", ex.Message));
			}
		}

		protected void OnQueryProperties_HostProcess(object sender, NodeEventArgs e)
		{
			BaseNode selNode = sender as BaseNode;
		
			//---checkpoint
			Trace.WriteLine(string.Format("OnQueryProperties: sender={0}", selNode.DisplayName));

			//---action
			HostProcessForm formHP = new HostProcessForm(selNode, selNode.DisplayName);
			formHP.Show();
		}

		protected void OnDeleteEvent_HostProcess(object sender, NodeEventArgs e)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnDeleteEvent: sender={0}", selNode.DisplayName));

			//---delete node and its children
			selNode.Snapin.ConsoleNameSpace.DeleteItem((uint)selNode.HScopeItem, 1);

			try 
			{
				//---unistall service	
				WinServiceAgent wsa = new WinServiceAgent();
				wsa.Uninstall(Convert.ToString(selNode.Tag));	
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("OnDeleteEvent: uninstall process {0} failed, error={1}", selNode.DisplayName, ex.Message));
			}
			finally 
			{
				//---set scope to the root
				selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.Snapin.RootNode.HScopeItem);
			}
		}

		protected void MenuHandlerProcessStart(object sender, BaseNode arg)
		{
			BaseNode selNode = arg;

			//---status
			selNode.Snapin.ResultViewConsole.SetStatusText("The process is starting ...");

			//---call progress controller
		  ProgressForm pf = new ProgressForm("start", selNode.DisplayName);
			pf.ShowDialog();
			
			//---set scope (refreshing)
			selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.HScopeItem);		
		}

		protected void MenuHandlerProcessStop(object sender, BaseNode arg)
		{
			BaseNode selNode = arg;

			//---set scope (refreshing)
			selNode.Snapin.ResultViewConsole.SetStatusText("The process is stoping ...");

			//---call progress controller
			ProgressForm pf = new ProgressForm("stop", selNode.DisplayName);
			pf.ShowDialog();

			//---set scope (refreshing)
			selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.HScopeItem);		
		}

		protected void MenuHandlerProcessRestart(object sender, BaseNode arg)
		{
			BaseNode selNode = arg;

			//---set scope (refreshing)
			selNode.Snapin.ResultViewConsole.SetStatusText("The process is restarting ...");

			//---call progress controller
			ProgressForm pf = new ProgressForm("restart", selNode.DisplayName);
			pf.ShowDialog();
	
			//---set scope (refreshing)
			selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.HScopeItem);		
		}
		#endregion
		
		#region Lifetime
		protected BaseNode CreateLifetimeNodeTree(BaseNode parentNode, string nodeName, bool bRefresh)
		{
			FormNode node = new FormNode(this);
			node.ControlType = Type.GetType("RKiss.RemotingManagement.PropertiesControl");
			node.DisplayName = nodeName;	
			node.Tag = parentNode.Tag;
			node.OpenImageIndex =  intLifetimeImage;
			node.ClosedImageIndex = intLifetimeImage;

			//---add/insert this node
			if(bRefresh)
				node.Insert(parentNode);
			else
				parentNode.AddChild(node);

			node.OnSelectScopeEvent += new NodeNotificationHandler(OnSelectEvent_Lifetime);
			node.OnQueryPropertiesEvent += new NodeNotificationHandler(OnQueryProperties_Lifetime);

			//---this is a post-process notification from the user form
			node.OnUserEvent += new NodeNotificationHandler(OnUserEvent_Lifetime);

			return node;
		}

		private void OnSelectEvent_Lifetime(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnSelectEvent: sender={0}", selNode.DisplayName));
	
			//---ask snap-in for the following buttons		
			IConsoleVerb icv;       
			selNode.Snapin.ResultViewConsole.QueryConsoleVerb(out icv);
			icv.SetVerbState(MMC_VERB.PROPERTIES, MMC_BUTTON_STATE.ENABLED, 1);

			//---status text
			selNode.Snapin.ResultViewConsole.SetStatusText("The lifetime properties of the remote singleton and activated objects in the application.");
		}

		protected void OnQueryProperties_Lifetime(object sender, NodeEventArgs e)
		{
			BaseNode selNode = sender as BaseNode;
		
			//---checkpoint
			Trace.WriteLine(string.Format("OnQueryProperties: sender={0}", selNode.DisplayName));

			//---action
			LifetimeForm formLT = new LifetimeForm(selNode, selNode.DisplayName, Convert.ToString(selNode.Tag) + ".config");
			formLT.Show();
		}

		private void OnUserEvent_Lifetime(object sender, NodeEventArgs args)
		{
			try 
			{
				//---inputs
				BaseNode node = sender as BaseNode;
				NameValueArgs nva = args as NameValueArgs;
				string strCheckpoint = nva.Key;
				string strLifetimeName = Convert.ToString(nva.Val);

				//---checkpoint
				Trace.WriteLine(string.Format("User Event: sender={0}, checkpoint={1}, val={2}", node.DisplayName, strCheckpoint, strLifetimeName));

				//---refresh and set scope 
				node.Snapin.ResultViewConsole.SelectScopeItem(node.HScopeItem);			
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("OnUserEvent_Lifetime - failed, error = {0}", ex.Message));
			}
		}
		#endregion

		#region RemoteObjects 
		protected BaseNode RemoteObjects(BaseNode parentNode, string childName, bool bRefresh)
		{
			Trace.WriteLine(string.Format("RemotingObjectScanner: {0}", parentNode));

			FormNode node = new FormNode(this);
			node.ControlType = Type.GetType("RKiss.RemotingManagement.RemoteObjectsControl");
			node.DisplayName = childName;
			node.Tag = parentNode.Tag;
			node.OpenImageIndex = intObjectServicesImage;
			node.ClosedImageIndex = intObjectServicesImage;
			node.AddNewMenuItem(new MenuItem("Remote Object", "Add new remote object to the host process.", new MenuCommandHandler(MenuHandlerNewObject)));
		
			//---events
			node.OnSelectScopeEvent += new NodeNotificationHandler(OnSelectEvent_RemoteObjects);
			node.OnRefreshEvent += new NodeNotificationHandler(OnRefreshEvent_RemoteObjects);

			//---this is a post-process notification from the user form
			node.OnUserEvent += new NodeNotificationHandler(OnUserEvent_NewObject);

			//---add/insert this node
			if(bRefresh)
				node.Insert(parentNode);
			else
				parentNode.AddChild(node);

			//---the host process config file
			string strConfigFilePath = Convert.ToString(node.Tag) + ".config";

			//---create RemoteObjects Node and its children
			RemoteObjectScanner(node, false, strConfigFilePath);
 
			return node;
		}

		protected void RemoteObjectScanner(BaseNode parentNode, bool bRefresh, string strConfigFilePath)
		{
			try 
			{
				//---scanner
				ConfigFileAgent cfa = new ConfigFileAgent();
				string strServiceOuterXml = cfa.GetServiceOuterXml(strConfigFilePath);

				if(strServiceOuterXml != null) 
				{
					XmlDocument doc = new XmlDocument();
					doc.Load(new StringReader(strServiceOuterXml));

					XmlNode root = doc.DocumentElement.SelectSingleNode("/service");

					if(root != null && root.ChildNodes.Count > 0) 
					{
						//---pickup one by one and create its node
						foreach(XmlNode n in root.ChildNodes) 
						{		
							string elementName = n.Name.ToLower();
							if(elementName == "wellknown" || elementName == "activated") 
							{
								foreach(XmlAttribute a in n.Attributes)
								{
									if(a.Name.ToLower() == "type")	
									{											
										BaseNode node = CreateObjectNodeTree(null, a.Value.Split(',')[0].Trim(), parentNode.Tag);
										if(bRefresh) 
										{
											node.Insert(parentNode);
											node.Snapin.ResultViewConsole.Expand(node.HScopeItem, 1);
										}
										else
											parentNode.AddChild(node);
										break;
									}
								}	
							}
						}	
					}
				}
			}
			catch(Exception ex) 
			{
				string strErr = string.Format("RemotingObjectScanner failed in the {0}, error={1}", strConfigFilePath, ex.Message); 
				Trace.WriteLine(strErr);

				throw new Exception(strErr, ex);
			}
			finally
			{				
			}
		}

		private void OnSelectEvent_RemoteObjects(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnSelectEvent: sender={0}", selNode.DisplayName));
	
			//---ask snap-in for the following buttons		
			IConsoleVerb icv;       
			selNode.Snapin.ResultViewConsole.QueryConsoleVerb(out icv);
			icv.SetVerbState(MMC_VERB.REFRESH, MMC_BUTTON_STATE.ENABLED, 1);

			//---status text
			selNode.Snapin.ResultViewConsole.SetStatusText("The Remote objects hosted by this process");
		}

		private void OnRefreshEvent_RemoteObjects(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnRefreshEvent: sender={0}, {1}, {2}", selNode.DisplayName, selNode.OpenImageIndex, selNode.ClosedImageIndex));

			//---destroy all children 
			selNode.Snapin.ConsoleNameSpace.DeleteItem((uint)selNode.HScopeItem, 0);

			//---config file
			string strConfigFilePath = Convert.ToString(selNode.Tag) + ".config"; 

			//---recreate them again		
			RemoteObjectScanner(selNode, true, strConfigFilePath);

			//---scope
			selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.HScopeItem);
			selNode.Snapin.ResultViewConsole.Expand(selNode.HScopeItem, 1);
		}

		private void OnUserEvent_NewObject(object sender, NodeEventArgs args)
		{
			try 
			{
				//---inputs
				BaseNode parentNode = sender as BaseNode;
				NameValueArgs nva = args as NameValueArgs;
				string strCheckpoint = nva.Key;
				string strRemoteObjectName = Convert.ToString(nva.Val);

				//---checkpoint
				Trace.WriteLine(string.Format("User Event: sender={0}, checkpoint={1}, val={2}", parentNode.DisplayName, strCheckpoint, strRemoteObjectName));
			
				//---action		
				BaseNode node = CreateObjectNodeTree(null, strRemoteObjectName, parentNode.Tag);
				parentNode.Snapin.ResultViewConsole.Expand(parentNode.HScopeItem, 1);
				node.Insert(parentNode);

				//---set scope on this node 
				parentNode.Snapin.ResultViewConsole.SelectScopeItem(parentNode.HScopeItem);
				parentNode.Snapin.ResultViewConsole.Expand(parentNode.HScopeItem, 1);
			
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("OnUserEvent_NewObject - failed, error = {0}", ex.Message));
			}
		}

		protected void MenuHandlerNewObject(object sender, BaseNode arg)
		{
			string strPathToCongif = Convert.ToString(arg.Tag) + ".config";
			ObjectForm formOBJ = new ObjectForm(arg, null, strPathToCongif);
			formOBJ.Show();
		}

		protected BaseNode CreateObjectNodeTree(BaseNode parentNode, string nodeName, object nodeTag)
		{
			FormNode node = new FormNode(this);
			node.ControlType = Type.GetType("RKiss.RemotingManagement.PropertiesControl");
			node.DisplayName = nodeName;	
			node.Tag = nodeTag;
			node.OpenImageIndex = intRemoteObjectImage;
			node.ClosedImageIndex = intRemoteObjectImage;

			if(parentNode != null)
			{
				parentNode.AddChild(node);
			}

			node.OnSelectScopeEvent += new NodeNotificationHandler(OnSelectEvent_Object);
			node.OnDeleteEvent += new NodeNotificationHandler(OnDeleteEvent_Object);
			node.OnQueryPropertiesEvent += new NodeNotificationHandler(OnQueryProperties_Object);

			//---this is a post-process notification from the user form
			node.OnUserEvent += new NodeNotificationHandler(OnUserEvent_Object);

			return node;
		}

		protected void OnDeleteEvent_Object(object sender, NodeEventArgs e)
		{
			BaseNode selNode = sender as BaseNode;
			ConfigFileAgent cfa = new ConfigFileAgent();
			cfa.RemoveRemoteObject(selNode.DisplayName, Convert.ToString(selNode.Tag) + ".config");			
				
			selNode.Snapin.ConsoleNameSpace.DeleteItem((uint)selNode.HScopeItem, 1);
			selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.ParentHScopeItem);
		}

		private void OnSelectEvent_Object(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnSelectEvent: sender={0}", selNode.DisplayName));
	
			//---ask snap-in for the following buttons		
			IConsoleVerb icv;       
			selNode.Snapin.ResultViewConsole.QueryConsoleVerb(out icv);
			icv.SetVerbState(MMC_VERB.REFRESH, MMC_BUTTON_STATE.ENABLED, 1);
			icv.SetVerbState(MMC_VERB.PROPERTIES, MMC_BUTTON_STATE.ENABLED, 1);
			icv.SetVerbState(MMC_VERB.DELETE, MMC_BUTTON_STATE.ENABLED, 1);

			//---status text
			selNode.Snapin.ResultViewConsole.SetStatusText("The remote object published by this host process.");
		}

		protected void OnQueryProperties_Object(object sender, NodeEventArgs e)
		{
			BaseNode selNode = sender as BaseNode;
		
			//---checkpoint
			Trace.WriteLine(string.Format("OnQueryProperties: sender={0}", selNode.DisplayName));

			//---action
			ObjectForm formOBJ = new ObjectForm(selNode, selNode.DisplayName, Convert.ToString(selNode.Tag) + ".config");
			formOBJ.Show();
		}

		private void OnUserEvent_Object(object sender, NodeEventArgs args)
		{
			try 
			{
				//---inputs
				BaseNode parentNode = sender as BaseNode;
				NameValueArgs nva = args as NameValueArgs;
				string strCheckpoint = nva.Key;
				string strRemoteObjectName = Convert.ToString(nva.Val);

				//---checkpoint				
				Trace.WriteLine(string.Format("User Event: sender={0}, checkpoint={1}, val={2}", parentNode.DisplayName, strCheckpoint, strRemoteObjectName));
				
				//---set scope on this node 
				parentNode.Snapin.ResultViewConsole.SelectScopeItem(parentNode.ParentHScopeItem);
				parentNode.Snapin.ResultViewConsole.Expand(parentNode.ParentHScopeItem, 1);			
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("OnUserEvent_Object - failed, error = {0}", ex.Message));
			}
		}
		#endregion

		#region Channels
		protected BaseNode Channels(BaseNode parentNode, string childName, bool bRefresh)
		{
			FormNode node = new FormNode(this);
			node.ControlType = Type.GetType("RKiss.RemotingManagement.ChannelsControl");
			node.DisplayName = childName;
			node.Tag = parentNode.Tag;
			node.OpenImageIndex = intChannelFolderImage;
			node.ClosedImageIndex = intChannelFolderImage;
			node.AddNewMenuItem(new MenuItem("Remoting channel", "Add new channel to the host process", new MenuCommandHandler(MenuHandlerNewChannel)));
		
			//---events
			node.OnSelectScopeEvent += new NodeNotificationHandler(OnSelectEvent_Channels);
			node.OnRefreshEvent += new NodeNotificationHandler(OnRefreshEvent_Channels);
			node.OnUserEvent += new NodeNotificationHandler(OnUserEvent_NewChannel);

			//---add/insert this node
			if(bRefresh)
				node.Insert(parentNode);
			else
				parentNode.AddChild(node);

			//---config file
			string strConfigFilePath = Convert.ToString(node.Tag) + ".config"; 

			//---create all children based on the config file contains
			RemotingChannelScanner(node, strConfigFilePath, false);

			return node;
		}

		private void RemotingChannelScanner(BaseNode parent, string strConfigFilePath, bool bRefresh)
		{
			//---scanner
			try 
			{
				//---get the channels from the config file			
				ConfigFileAgent cfa = new ConfigFileAgent();
				string strChannelsOuterXml = cfa.GetChannels(strConfigFilePath);

				if(strChannelsOuterXml != null) 
				{
					XmlDocument doc = new XmlDocument();
					doc.Load(new StringReader(strChannelsOuterXml));

					XmlNode root = doc.DocumentElement.SelectSingleNode("/channels");

					if(root != null && root.ChildNodes.Count > 0) 
					{
						//---pickup one by one and create its node
						foreach(XmlNode n in root.ChildNodes) 
						{		
							string elementName = n.Name.ToLower();
							if(elementName == "channel") 
							{
								//---find the name of the channel
								XmlAttribute attr = (XmlAttribute)n.Attributes.GetNamedItem("name");
								if(attr == null) 
								{
									attr = (XmlAttribute)n.Attributes.GetNamedItem("ref");
									if(attr == null) 
										attr = (XmlAttribute)n.Attributes.GetNamedItem("id");
								}

								if(attr != null) 
								{
									//---create channel node
									BaseNode node = CreateChannelNodeTree(null, attr.Value, parent.Tag);
									if(bRefresh) 
									{
										node.Insert(parent);
										node.Snapin.ResultViewConsole.Expand(node.HScopeItem, 1);
									}
									else
										parent.AddChild(node);
								}						
							}	
						}
					}	
				}
			}
			catch(Exception ex) 
			{
				string strErr = string.Format("RemotingChannelScanner failed in the {0}, error={1}", strConfigFilePath, ex.Message); 
				Trace.WriteLine(strErr);

				throw new Exception(strErr, ex);
			}
			finally
			{				
			}	
		}

		private void OnSelectEvent_Channels(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnSelectEvent: sender={0}, {1}, {2}", selNode.DisplayName, selNode.OpenImageIndex, selNode.ClosedImageIndex));
	
			//---ask snap-in for the following buttons		
			IConsoleVerb icv;       
			selNode.Snapin.ResultViewConsole.QueryConsoleVerb(out icv);
			icv.SetVerbState(MMC_VERB.REFRESH, MMC_BUTTON_STATE.ENABLED, 1);
			
			//---status text
			selNode.Snapin.ResultViewConsole.SetStatusText("The remoting channels registered by this process.");
		}

		private void OnRefreshEvent_Channels(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnRefreshEvent: sender={0}, {1}, {2}", selNode.DisplayName, selNode.OpenImageIndex, selNode.ClosedImageIndex));

			//---destroy all children 
			selNode.Snapin.ConsoleNameSpace.DeleteItem((uint)selNode.HScopeItem, 0);

			//---config file
			string strConfigFilePath = Convert.ToString(selNode.Tag) + ".config"; 

			//---recreate them again		
			RemotingChannelScanner(selNode, strConfigFilePath, true);

			//---scope
			selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.HScopeItem);
			selNode.Snapin.ResultViewConsole.Expand(selNode.HScopeItem, 1);
		}

		private void OnUserEvent_NewChannel(object sender, NodeEventArgs args)
		{
			if(sender is BaseNode) 
			{	
				try 
				{
					//---inputs
					BaseNode parentNode = sender as BaseNode;
					NameValueArgs nva = args as NameValueArgs;
					string strCheckpoint = nva.Key;
					string strNodeDisplayName = Convert.ToString(nva.Val);

					//---checkpoint
					Trace.WriteLine(string.Format("User Event: sender={0}, checkpoint={1}, val={2}", parentNode.DisplayName, strCheckpoint, strNodeDisplayName));
			
					//---create new channel node
					BaseNode node = CreateChannelNodeTree(null, strNodeDisplayName, parentNode.Tag);		
					parentNode.Snapin.ResultViewConsole.Expand(parentNode.HScopeItem, 1);
				
					//---insert this node into the tree
					node.Insert(parentNode);

					//---expand new process
					node.Snapin.ResultViewConsole.SelectScopeItem(node.HScopeItem);
					node.Snapin.ConsoleNameSpace.Expand((uint)node.HScopeItem);	
							
				}
				catch(Exception ex) 
				{
					Trace.WriteLine(string.Format("OnUserEvent_Channels error = {0}", ex.Message));
				}
			}
		}

		protected void MenuHandlerNewChannel(object sender, BaseNode arg)
		{
			string strPathToConfigFile = Convert.ToString(arg.Tag) + ".config";

			ChannelForm cf = new ChannelForm(arg, null, strPathToConfigFile);
			cf.Show();
		}

		protected BaseNode CreateChannelNodeTree(BaseNode parentNode, string nodeName, object nodeTag)
		{
			FormNode node = new FormNode(this);
			node.ControlType = Type.GetType("RKiss.RemotingManagement.PropertiesControl");
			node.DisplayName = nodeName;	
			node.Tag = nodeTag;
			node.OpenImageIndex = intChannelFolderImage;
			node.ClosedImageIndex = intChannelFolderImage;

			//---events
			node.OnSelectScopeEvent += new NodeNotificationHandler(OnSelectEvent_Channel);
			node.OnDeleteEvent += new NodeNotificationHandler(OnDeleteEvent_Channel);
			node.OnQueryPropertiesEvent += new NodeNotificationHandler(OnQueryProperties_Channel);
		
			//---this is a post-process notification from the user form
			node.OnUserEvent += new NodeNotificationHandler(OnUserEvent_UpdateChannel);

			if(parentNode != null)
			{
				parentNode.AddChild(node);
			}

			ServerProviders(node, "serverSinks", node.Tag);
			ClientProviders(node, "clientSinks", node.Tag);

			return node;
		}

		protected void OnDeleteEvent_Channel(object sender, NodeEventArgs e)
		{
			BaseNode selNode = sender as BaseNode;
			string strPathToConfigFile = Convert.ToString(selNode.Tag) + ".config";

			try 
			{			
				//---call agent
				ConfigFileAgent cfa = new ConfigFileAgent();
				cfa.RemoveChannel(selNode.DisplayName, strPathToConfigFile);	
				
				//---scope
				selNode.Snapin.ConsoleNameSpace.DeleteItem((uint)selNode.HScopeItem, 1);
				selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.ParentHScopeItem);
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("OnDeleteEvent_Channel error = {0}", ex.Message));
			}
		}

		private void OnUserEvent_UpdateChannel(object sender, NodeEventArgs args)
		{
			if(sender is BaseNode) 
			{	
				try 
				{
					//---inputs
					BaseNode node = sender as BaseNode;
					NameValueArgs nva = args as NameValueArgs;
					string strCheckpoint = nva.Key;
					string strNodeDisplayName = Convert.ToString(nva.Val);

					//---checkpoint
					Trace.WriteLine(string.Format("User Event: sender={0}, checkpoint={1}, val={2}", node.DisplayName, strCheckpoint, strNodeDisplayName));
			
					//---update name
					node.DisplayName = strNodeDisplayName;	
			
					//---refresh node
					node.Snapin.ResultViewConsole.SelectScopeItem(node.HScopeItem);
				}
				catch(Exception ex) 
				{
					Trace.WriteLine(string.Format("OnUserEvent_Channel error = {0}", ex.Message));
				}
			}
		}

		private void OnSelectEvent_Channel(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnSelectEvent: sender={0}, {1}, {2}", selNode.DisplayName, selNode.OpenImageIndex, selNode.ClosedImageIndex));
	
			//---ask snap-in for the following buttons		
			IConsoleVerb icv;       
			selNode.Snapin.ResultViewConsole.QueryConsoleVerb(out icv);
			icv.SetVerbState(MMC_VERB.PROPERTIES, MMC_BUTTON_STATE.ENABLED, 1);
			icv.SetVerbState(MMC_VERB.DELETE, MMC_BUTTON_STATE.ENABLED, 1);

			//---status text
			selNode.Snapin.ResultViewConsole.SetStatusText("The communication channel.");
		}

		protected void OnQueryProperties_Channel(object sender, NodeEventArgs e)
		{
			BaseNode selNode = sender as BaseNode;
			string strPathToConfigFile = Convert.ToString(selNode.Tag) + ".config";
		
			//---checkpoint
			Trace.WriteLine(string.Format("OnQueryProperties_Channel: sender={0}", selNode.DisplayName));

			//---action
			ChannelForm formChannel = new ChannelForm(selNode, selNode.DisplayName, strPathToConfigFile);
			formChannel.Show();
		}
		#endregion

		#region Providers
		#region ServerProviders Scanner
		protected BaseNode ServerProviders(BaseNode parentNode, string nodeName, object nodeTag)
		{
			FormNode node = new FormNode(this);
			node.ControlType = Type.GetType("RKiss.RemotingManagement.ChannelSinkProvidersControl");
			node.DisplayName = nodeName;	
			node.Tag = nodeTag;
			node.OpenImageIndex = intSinksImage;
			node.ClosedImageIndex = intSinksImage;
			node.AddNewMenuItem(new MenuItem("Formatter Sink", "Add new server formatter sink to the channel", new MenuCommandHandler(MenuHandlerNewFormatterSink)));
			node.AddNewMenuItem(new MenuItem("Provider Sink", "Add new server provider sink to the channel", new MenuCommandHandler(MenuHandlerNewProviderSink)));

			//---refresh node
			node.OnSelectScopeEvent += new NodeNotificationHandler(OnSelectEvent_Providers);
			node.OnRefreshEvent += new NodeNotificationHandler(OnRefreshEvent_Providers);

			//---this is a post-process notification from the user form
			node.OnUserEvent += new NodeNotificationHandler(OnUserEvent_NewSink);

			//---add/insert this node
			if(parentNode != null)
			{
				parentNode.AddChild(node);
			}

			//---channel name
			string strChannelName = parentNode.DisplayName;

			//--config file scanner
			ServerProvidersScanner(node, strChannelName, false);

			return node;
		}

		protected void ServerProvidersScanner(BaseNode node, string strChannelName, bool bRefresh)
		{
			//---config file
			string strConfigFilePath = Convert.ToString(node.Tag) + ".config";

			//---scann config file for server sinks
			try 
			{
				//---get the channels from the config file			
				ConfigFileAgent cfa = new ConfigFileAgent();
				string strServerChannelSinksOuterXml = cfa.GetServerChannelSinks(strChannelName, strConfigFilePath);

				//---we have to walk through xml text because all sinks in the channel are in the order
				if(strServerChannelSinksOuterXml != null) 
				{
					XmlDocument doc = new XmlDocument();
					doc.Load(new StringReader(strServerChannelSinksOuterXml));

					XmlElement root = doc.DocumentElement;
					XmlNode providers = root.SelectSingleNode("/serverProviders");

					if(providers != null && providers.ChildNodes.Count > 0) 
					{
						//---pickup one by one and create its node
						foreach(XmlNode n in providers.ChildNodes) 
						{		
							string providerType = n.Name.ToLower();
							if(providerType == "formatter" || providerType == "provider") 
							{
								//---find the name of the sink
								XmlAttribute attr = (XmlAttribute)n.Attributes.GetNamedItem("name");
								if(attr == null) 
								{
									attr = (XmlAttribute)n.Attributes.GetNamedItem("ref");
									if(attr == null) 
										attr = (XmlAttribute)n.Attributes.GetNamedItem("id");
								}
								if(attr != null) 
								{
									//---create sink node
									CreateSinkNodeTree(node, providerType + " " + attr.Value, node.Tag, bRefresh);
								}
							}
						}	
					}
				}
			}
			catch(Exception ex) 
			{
				string strErr = string.Format("ServerProvidersScanner scanner failed in the {0}, error={1}", strConfigFilePath, ex.Message); 
				Trace.WriteLine(strErr);

				throw new Exception(strErr, ex);
			}
			finally
			{				
			}
		}
		#endregion

		#region ClientProviders Scanner
		protected BaseNode ClientProviders(BaseNode parentNode, string nodeName, object nodeTag)
		{
			FormNode node = new FormNode(this);
			node.ControlType = Type.GetType("RKiss.RemotingManagement.ChannelSinkProvidersControl");
			node.DisplayName = nodeName;
			node.Tag = nodeTag;
			node.OpenImageIndex = intSinksImage;
			node.ClosedImageIndex = intSinksImage;
			node.AddNewMenuItem(new MenuItem("Formatter Sink", "Add new server formatter sink to the channel", new MenuCommandHandler(MenuHandlerNewFormatterSink)));
			node.AddNewMenuItem(new MenuItem("Provider Sink", "Add new server provider sink to the channel", new MenuCommandHandler(MenuHandlerNewProviderSink)));

			//---refresh node
			node.OnSelectScopeEvent += new NodeNotificationHandler(OnSelectEvent_Providers);
			node.OnRefreshEvent += new NodeNotificationHandler(OnRefreshEvent_Providers);

			//---this is a post-process notification from the user form
			node.OnUserEvent += new NodeNotificationHandler(OnUserEvent_NewSink);

			//---add/insert this node
			if(parentNode != null)
			{
				parentNode.AddChild(node);
			}

			//---channel name
			string strChannelName = parentNode.DisplayName;

			//---config file scanner
			ClientProvidersScanner(node, strChannelName, false);

			return node;
		}

		protected void ClientProvidersScanner(BaseNode node, string strChannelName, bool bRefresh)
		{
			//---config file
			string strConfigFilePath = Convert.ToString(node.Tag) + ".config";

			//---scann config file for server sinks
			try 
			{
				//---get the channels from the config file			
				ConfigFileAgent cfa = new ConfigFileAgent();
				string strClientChannelSinksOuterXml = cfa.GetClientChannelSinks(strChannelName, strConfigFilePath);

				//---we have to walk through xml text because all sinks in the channel are in the order
				if(strClientChannelSinksOuterXml != null) 
				{
					XmlDocument doc = new XmlDocument();
					doc.Load(new StringReader(strClientChannelSinksOuterXml));

					XmlElement root = doc.DocumentElement;
					XmlNode providers = root.SelectSingleNode("/clientProviders");

					if(providers != null && providers.ChildNodes.Count > 0) 
					{
						//---pickup one by one and create its node
						foreach(XmlNode n in providers.ChildNodes) 
						{		
							string providerType = n.Name.ToLower();
							if(providerType == "formatter" || providerType == "provider") 
							{
								//---find the name of the sink
								XmlAttribute attr = (XmlAttribute)n.Attributes.GetNamedItem("name");
								if(attr == null) 
								{
									attr = (XmlAttribute)n.Attributes.GetNamedItem("ref");
									if(attr == null) 
										attr = (XmlAttribute)n.Attributes.GetNamedItem("id");
								}
								if(attr != null) 
								{
									//---create sink node
									CreateSinkNodeTree(node, providerType + " " + attr.Value, node.Tag, bRefresh);
								}
							}
						}	
					}
				}
			}
			catch(Exception ex) 
			{
				string strErr = string.Format("ServerProvidersScanner scanner failed in the {0}, error={1}", strConfigFilePath, ex.Message); 
				Trace.WriteLine(strErr);

				throw new Exception(strErr, ex);
			}
			finally
			{				
			}
		}

		private void OnSelectEvent_Providers(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnSelectEvent: sender={0}, {1}, {2}", selNode.DisplayName, selNode.OpenImageIndex, selNode.ClosedImageIndex));
	
			//---ask snap-in for the following buttons		
			IConsoleVerb icv;       
			selNode.Snapin.ResultViewConsole.QueryConsoleVerb(out icv);
			icv.SetVerbState(MMC_VERB.REFRESH, MMC_BUTTON_STATE.ENABLED, 1);
		
			//---status text
			selNode.Snapin.ResultViewConsole.SetStatusText("The channel sinks.");
		}

		private void OnRefreshEvent_Providers(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;
			string strProviders = selNode.DisplayName;

			//---checkpoint
			Trace.WriteLine(string.Format("OnRefreshEvent: sender={0}, {1}, {2}", selNode.DisplayName, selNode.OpenImageIndex, selNode.ClosedImageIndex));

			//---destroy all children 
			selNode.Snapin.ConsoleNameSpace.DeleteItem((uint)selNode.HScopeItem, 0);

			//---channel name
			string strChannelName = selNode.Snapin.FindNodeByHScope(selNode.ParentHScopeItem).DisplayName;

			//---switcher
			if(strProviders == "serverSinks") 
				ServerProvidersScanner(selNode, strChannelName, true);
			else if(strProviders == "clientSinks") 
				ClientProvidersScanner(selNode, strChannelName, true);
			else
				throw new Exception("Wrong parent node = " + selNode);

			//---scope
			selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.HScopeItem);
			selNode.Snapin.ResultViewConsole.Expand(selNode.HScopeItem, 1);
		}

		#endregion

		#region Provider Sink
		protected BaseNode CreateSinkNodeTree(BaseNode parentNode, string nodeName, object nodeTag, bool bRefresh)
		{
			Trace.WriteLine("CreateSinkNodeTree = " + nodeName);

			FormNode node = new FormNode(this);
			node.ControlType = Type.GetType("RKiss.RemotingManagement.PropertiesControl");
			node.DisplayName = nodeName;	
			node.Tag = nodeTag;
			node.OpenImageIndex = intSingleSinkImage;
			node.ClosedImageIndex = intSingleSinkImage;
			node.AddTopMenuItem(new MenuItem("MoveUp", "Move up (circulate) the sink in the channel sink", new MenuCommandHandler(MenuHandlerMoveUpSink)));

			node.OnSelectScopeEvent += new NodeNotificationHandler(OnSelectEvent_Sink);
			node.OnQueryPropertiesEvent += new NodeNotificationHandler(OnQueryProperties_Sink);
		  node.OnDeleteEvent += new NodeNotificationHandler(OnDeleteEvent_Sink);

			//---this is a post-process notification from the user form
			node.OnUserEvent += new NodeNotificationHandler(OnUserEvent_UpdateSink);

			//---add/insert this node
			if(parentNode != null) 
			{
				if(bRefresh)
					node.Insert(parentNode);
				else
					parentNode.AddChild(node);
			}

			return node;
		}

		protected void MenuHandlerNewFormatterSink(object sender, BaseNode arg)
		{
			string strPathToConfigFile = Convert.ToString(arg.Tag) + ".config";

			SinkForm cf = new SinkForm(arg, "formatter", null, strPathToConfigFile);
			cf.Show();
		}
		
		protected void MenuHandlerMoveUpSink(object sender, BaseNode arg)
		{
			BaseNode selNode = arg;
			string strPathToConfigFile = Convert.ToString(selNode.Tag) + ".config";

			try 
			{			
				//---call agent
				ConfigFileAgent cfa = new ConfigFileAgent();

				//---split the node name
				string[] nodeName = selNode.DisplayName.Split(' ');			
				string strTypeProvider = nodeName[0];
				string strSinkName = nodeName[1];
		
				//---parent node
				BaseNode sinksNode = selNode.Snapin.FindNodeByHScope(selNode.ParentHScopeItem);
				string strProviders = sinksNode.DisplayName;

				//---grand parent node
				BaseNode channelNode = selNode.Snapin.FindNodeByHScope(sinksNode.ParentHScopeItem);
				string strChannelName = channelNode.DisplayName;

				Trace.WriteLine(string.Format("MenuHandlerMoveUpSink: channel={0}, providers={1}, node={2}, type={3}",
					strChannelName, strProviders, selNode.DisplayName, strTypeProvider));
			
				//---switcher
				if(strProviders == "serverSinks") 
					cfa.MoveUpServerSink(strChannelName, strTypeProvider, strSinkName, strPathToConfigFile);	
				else if(strProviders == "clientSinks") 
					cfa.MoveUpClientSink(strChannelName, strTypeProvider, strSinkName, strPathToConfigFile);
				else
					throw new Exception("Wrong parent node = " + sinksNode);
				
				//---refresh sinks
				OnRefreshEvent_Providers(selNode.Snapin.FindNodeByHScope(sinksNode.HScopeItem), null);
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("MenuHandlerMoveUpSink error = {0}", ex.Message));
			}		
		}

		protected void MenuHandlerNewProviderSink(object sender, BaseNode arg)
		{
			string strPathToConfigFile = Convert.ToString(arg.Tag) + ".config";

			SinkForm cf = new SinkForm(arg, "provider", null, strPathToConfigFile);
			cf.Show();
		}

		private void OnSelectEvent_Sink(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnSelectEvent: sender={0}, {1}, {2}", selNode.DisplayName, selNode.OpenImageIndex, selNode.ClosedImageIndex));
	
			//---ask snap-in for the following buttons		
			IConsoleVerb icv;       
			selNode.Snapin.ResultViewConsole.QueryConsoleVerb(out icv);
			icv.SetVerbState(MMC_VERB.PROPERTIES, MMC_BUTTON_STATE.ENABLED, 1);
			icv.SetVerbState(MMC_VERB.DELETE, MMC_BUTTON_STATE.ENABLED, 1);

			/* doesn't work properly for the parentNode.NumChildren
			//---moveup memu 
			BaseNode parentNode = selNode.Snapin.FindNodeByHScope(selNode.ParentHScopeItem);
			selNode.GetMenuItem(CCM.INSERTIONALLOWED_TOP, "MoveUp").Visible = parentNode.NumChildren > 1 ? true : false;
			*/
		
			//---status text
			selNode.Snapin.ResultViewConsole.SetStatusText("The channel sink.");
		}

		private void OnUserEvent_NewSink(object sender, NodeEventArgs args)
		{
			if(sender is BaseNode) 
			{	
				try 
				{
					//---inputs
					BaseNode parentNode = sender as BaseNode;
					NameValueArgs nva = args as NameValueArgs;
					string strCheckpoint = nva.Key;
					string strNodeDisplayName = Convert.ToString(nva.Val);

					//---checkpoint
					Trace.WriteLine(string.Format("User Event: sender={0}, checkpoint={1}, val={2}", parentNode.DisplayName, strCheckpoint, strNodeDisplayName));
					
					//---action	
					BaseNode node = CreateSinkNodeTree(null, strNodeDisplayName, parentNode.Tag, true);

					//---insert this node into the tree
					node.Insert(parentNode);

					//---expand new process
					node.Snapin.ResultViewConsole.SelectScopeItem(node.HScopeItem);
					node.Snapin.ConsoleNameSpace.Expand((uint)node.HScopeItem);	
				}
				catch(Exception ex) 
				{
					Trace.WriteLine(string.Format("OnUserEvent_NewSink error = {0}", ex.Message));
				}
			}
		}

		private void OnUserEvent_UpdateSink(object sender, NodeEventArgs args)
		{
			if(sender is BaseNode) 
			{	
				try 
				{
					//---inputs
					BaseNode node = sender as BaseNode;
					NameValueArgs nva = args as NameValueArgs;
					string strCheckpoint = nva.Key;
					string strNodeDisplayName = Convert.ToString(nva.Val);

					//---checkpoint
					Trace.WriteLine(string.Format("User Event: sender={0}, checkpoint={1}, val={2}", node.DisplayName, strCheckpoint, strNodeDisplayName));

					//---update name
					node.DisplayName = strNodeDisplayName;	
			
					//---refresh node
					node.Snapin.ResultViewConsole.SelectScopeItem(node.HScopeItem);
				}
				catch(Exception ex) 
				{
					Trace.WriteLine(string.Format("OnUserEvent_UpdateSink error = {0}", ex.Message));
				}
			}
		}

		protected void OnQueryProperties_Sink(object sender, NodeEventArgs e)
		{
			BaseNode selNode = sender as BaseNode;
			string strPathToConfigFile = Convert.ToString(selNode.Tag) + ".config";
		
			//---checkpoint
			Trace.WriteLine(string.Format("OnQueryProperties_Sink: sender={0}", selNode.DisplayName));
		
			//---split the node name
			string[] nodeName = selNode.DisplayName.Split(' ');			
			string strTypeProvider = nodeName[0];
			string strSinkName = nodeName[1];
		
			//---action
			SinkForm formChannel = new SinkForm(selNode, strTypeProvider, strSinkName, strPathToConfigFile);
			formChannel.Show();
		}

		protected void OnDeleteEvent_Sink(object sender, NodeEventArgs e)
		{
			BaseNode selNode = sender as BaseNode;
			string strPathToConfigFile = Convert.ToString(selNode.Tag) + ".config";

			try 
			{			
				//---call agent
				ConfigFileAgent cfa = new ConfigFileAgent();

				//---split the node name
				string[] nodeName = selNode.DisplayName.Split(' ');			
				string strTypeProvider = nodeName[0];
				string strSinkName = nodeName[1];
		
				//---parent node
				BaseNode sinksNode = selNode.Snapin.FindNodeByHScope(selNode.ParentHScopeItem);
				string strProviders = sinksNode.DisplayName;

				//---grand parent node
				BaseNode channelNode = selNode.Snapin.FindNodeByHScope(sinksNode.ParentHScopeItem);
				string strChannelName = channelNode.DisplayName;

				Trace.WriteLine(string.Format("OnDeleteEvent_Sink: channel={0}, providers={1}, node={2}, type={3}",
					strChannelName, strProviders, selNode.DisplayName, strTypeProvider));
			
				//---switcher
				if(strProviders == "serverSinks") 
				{
					cfa.RemoveServerSink(strChannelName, strTypeProvider, strSinkName, strPathToConfigFile);	
				}
				else 
				if(strProviders == "clientSinks") 
				{
					cfa.RemoveClientSink(strChannelName, strTypeProvider, strSinkName, strPathToConfigFile);
				}
				else
					throw new Exception("Wrong parent node = " + sinksNode);
				
				//---scope
				selNode.Snapin.ConsoleNameSpace.DeleteItem((uint)selNode.HScopeItem, 1);
				selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.ParentHScopeItem);
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("OnDeleteEvent_Sink error = {0}", ex.Message));
			}
		}
		#endregion
		#endregion

		#region AppSettings
		//*****************************************************************************
		//	PARENT NODE:	AppSettings
		//  SCANNER:			ConfigSectionScanner
		//	EVENTS:				OnSelectEvent, OnRefreshEvent
		//*****************************************************************************
		protected BaseNode AppSettings(BaseNode parentNode, string childName, bool bRefresh)
		{			
			FormNode node = new FormNode(this);
			node.ControlType = Type.GetType("RKiss.RemotingManagement.AppSettingsControl");
			node.DisplayName = childName;
			node.Tag = parentNode.Tag;
			node.OpenImageIndex =  intSectionImage;
			node.ClosedImageIndex = intSectionImage;
			
			//---events
			node.OnSelectScopeEvent += new NodeNotificationHandler(OnSelectEvent_AppSettings);
			node.OnRefreshEvent += new NodeNotificationHandler(OnRefreshEvent_AppSettings);
	
			//---add/insert this node
			if(bRefresh)
				node.Insert(parentNode);
			else
				parentNode.AddChild(node);

			return node;
		}

		private void OnSelectEvent_AppSettings(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnSelectEvent: sender={0}, {1}, {2}", selNode.DisplayName, selNode.OpenImageIndex, selNode.ClosedImageIndex));
	
			//---ask snap-in for the following buttons		
			IConsoleVerb icv;       
			selNode.Snapin.ResultViewConsole.QueryConsoleVerb(out icv);
			icv.SetVerbState(MMC_VERB.REFRESH, MMC_BUTTON_STATE.ENABLED, 1);
			
			//---status text
			selNode.Snapin.ResultViewConsole.SetStatusText("The application settings (key/value).");
		}

		private void OnRefreshEvent_AppSettings(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnRefreshEvent: sender={0}, {1}, {2}", selNode.DisplayName, selNode.OpenImageIndex, selNode.ClosedImageIndex));

			//---scope
			selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.ParentHScopeItem);
			selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.HScopeItem);
		}
		#endregion

		#region ConfigSections
		#region parent node
		//*****************************************************************************
		//	PARENT NODE:	ConfigSections
		//  SCANNER:			ConfigSectionScanner
		//	EVENTS:				OnSelectEvent, OnDeleteEvent, OnUserEvent, OnRefreshEvent
		//	MENU:					MenuHandlerNewConfigSections, 
		//*****************************************************************************
		protected BaseNode ConfigSections(BaseNode parentNode, string childName, bool bRefresh)
		{
			FormNode node = new FormNode(this);
			node.ControlType = Type.GetType("RKiss.RemotingManagement.ConfigSectionsControl");
			node.DisplayName = childName;	
			node.Tag = parentNode.Tag;
			node.OpenImageIndex =  intXmlTreeImage;
			node.ClosedImageIndex = intXmlTreeImage;
			node.AddNewMenuItem(new MenuItem("Group/Section", "Add new config group or section into the config file.", new MenuCommandHandler(MenuHandlerNewConfigSections)));
			
			//---events
			node.OnSelectScopeEvent += new NodeNotificationHandler(OnSelectEvent_ConfigSections);
			node.OnRefreshEvent += new NodeNotificationHandler(OnRefreshEvent_ConfigSections);

			//---this is a post-process notification from the user form
			node.OnUserEvent += new NodeNotificationHandler(OnUserEvent_ConfigSections);
			
			//---config file
			string strConfigFilePath = Convert.ToString(node.Tag) + ".config";

			//---scann config file for config sections 
			ConfigSectionScanner(node, strConfigFilePath, false);
 
			//---add/insert this node
			if(bRefresh)
				node.Insert(parentNode);
			else
				parentNode.AddChild(node);

			return node;
		}

		protected void ConfigSectionScanner(BaseNode parentNode, string strConfigFilePath, bool bRefresh)
		{		
			try 
			{
				//---list of the sections in the config file
				ArrayList objSections = new ArrayList();

				//---get the channels from the config file			
				ConfigFileAgent cfa = new ConfigFileAgent();
				cfa.GetRemotingConfigSections(ref objSections, strConfigFilePath);

				//---walk through the collection of all sections
				for(int ii=0; ii<objSections.Count; ii++) 
				{
					string strSectionName = Convert.ToString(objSections[ii]);
					CreateConfigSectionNodeTree(parentNode, strSectionName, bRefresh);	
				}
			}
			catch(Exception ex) 
			{
				string strErr = string.Format("ConfigSectionScanner scanner failed in the {0}, error={1}", strConfigFilePath, ex.Message); 
				Trace.WriteLine(strErr);

				throw new Exception(strErr, ex);
			}
			finally
			{				
			}
		}

		protected void MenuHandlerNewConfigSections(object sender, BaseNode arg)
		{	
			ConfigSectionForm formCS = new ConfigSectionForm(arg);
			formCS.Show();			
		}

		private void OnSelectEvent_ConfigSections(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnSelectEvent: sender={0}, {1}, {2}", selNode.DisplayName, selNode.OpenImageIndex, selNode.ClosedImageIndex));
	
			//---ask snap-in for the following buttons		
			IConsoleVerb icv;       
			selNode.Snapin.ResultViewConsole.QueryConsoleVerb(out icv);
			icv.SetVerbState(MMC_VERB.REFRESH, MMC_BUTTON_STATE.ENABLED, 1);
			
			//---status text
			selNode.Snapin.ResultViewConsole.SetStatusText("The host process configuration sections.");
		}

		private void OnRefreshEvent_ConfigSections(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnRefreshEvent: sender={0}, {1}, {2}", selNode.DisplayName, selNode.OpenImageIndex, selNode.ClosedImageIndex));

			//---destroy all children 
			selNode.Snapin.ConsoleNameSpace.DeleteItem((uint)selNode.HScopeItem, 0);

			//---config file
			string strConfigFilePath = Convert.ToString(selNode.Tag) + ".config"; 

			//---recreate them again	
			ConfigSectionScanner(selNode, strConfigFilePath, true);

			//---scope
			selNode.Snapin.ResultViewConsole.Expand(selNode.HScopeItem, 1);
			selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.HScopeItem);
		}

		private void OnUserEvent_ConfigSections(object sender, NodeEventArgs args)
		{
			if(sender is BaseNode) 
			{	
				try 
				{
					//---inputs
					BaseNode node = sender as BaseNode;
					NameValueArgs nva = args as NameValueArgs;
					string strCheckpoint = nva.Key;
					string strNodeDisplayName = Convert.ToString(nva.Val);

					//---checkpoint
					Trace.WriteLine(string.Format("User Event: sender={0}, checkpoint={1}, val={2}", node.DisplayName, strCheckpoint, strNodeDisplayName));

					//---refresh node
					node.OnRefresh();
				}
				catch(Exception ex) 
				{
					Trace.WriteLine(string.Format("OnUserEvent_UpdateSink error = {0}", ex.Message));
				}
			}
		}
		#endregion

		#region child node
		//*****************************************************************************
		//	NODE:		ConfigSection
		//	EVENTS: OnSelectEvent, OnDeleteEvent, OnUserEvent
		//*****************************************************************************
		protected BaseNode CreateConfigSectionNodeTree(BaseNode parentNode, string childName, bool bRefresh)
		{
			FormNode node = new FormNode(this);
			node.ControlType = Type.GetType("RKiss.RemotingManagement.ConfigSectionControl");
			node.DisplayName = childName;	
			node.Tag = parentNode.Tag;		
			node.OpenImageIndex = intSectionImage;
			node.ClosedImageIndex = intSectionImage;

			//---events
			node.OnSelectScopeEvent += new NodeNotificationHandler(OnSelectEvent_ConfigSection);
			node.OnDeleteEvent += new NodeNotificationHandler(OnDeleteEvent_ConfigSection);

			//---this is a post-process notification from the user form
			node.OnUserEvent += new NodeNotificationHandler(OnUserEvent_ConfigSection);

			//---add/insert this node
			if(bRefresh)
				node.Insert(parentNode);
			else
				parentNode.AddChild(node);
			
			return node;
		}

		private void OnSelectEvent_ConfigSection(object sender, NodeEventArgs args)
		{
			BaseNode selNode = sender as BaseNode;

			//---checkpoint
			Trace.WriteLine(string.Format("OnSelectEvent: sender={0}, {1}, {2}", selNode.DisplayName, selNode.OpenImageIndex, selNode.ClosedImageIndex));
	
			//---ask snap-in for the following buttons		
			IConsoleVerb icv;       
			selNode.Snapin.ResultViewConsole.QueryConsoleVerb(out icv);
			icv.SetVerbState(MMC_VERB.DELETE, MMC_BUTTON_STATE.ENABLED, 1);
			
			//---status text
			selNode.Snapin.ResultViewConsole.SetStatusText("The host process configuration sections.");
		}

		private void OnDeleteEvent_ConfigSection(object sender, NodeEventArgs args)
		{		
			BaseNode selNode = sender as BaseNode;
			string strPathToConfigFile = Convert.ToString(selNode.Tag) + ".config";

			try 
			{			
				//---call agent
				ConfigFileAgent cfa = new ConfigFileAgent();
				cfa.RemoveOuterXml("/configuration/" + selNode.DisplayName, strPathToConfigFile);	
				
				//---scope
				selNode.Snapin.ConsoleNameSpace.DeleteItem((uint)selNode.HScopeItem, 1);
				selNode.Snapin.ResultViewConsole.SelectScopeItem(selNode.ParentHScopeItem);
			}
			catch(Exception ex) 
			{
				Trace.WriteLine(string.Format("OnDeleteEvent_Channel error = {0}", ex.Message));
			}
		}

		private void OnUserEvent_ConfigSection(object sender, NodeEventArgs args)
		{
			if(sender is BaseNode) 
			{	
				try 
				{
					//---inputs
					BaseNode node = sender as BaseNode;
					NameValueArgs nva = args as NameValueArgs;
					string strCheckpoint = nva.Key;
					string strNodeDisplayName = Convert.ToString(nva.Val);

					//---checkpoint
					Trace.WriteLine(string.Format("User Event: sender={0}, checkpoint={1}, val={2}", node.DisplayName, strCheckpoint, strNodeDisplayName));

					//---update name
					node.DisplayName = strNodeDisplayName;
					
					//---scope
					node.Snapin.ResultViewConsole.SelectScopeItem(node.HScopeItem);
				}
				catch(Exception ex) 
				{
					Trace.WriteLine(string.Format("OnUserEvent_UpdateSink error = {0}", ex.Message));
				}
			}
		}	
		#endregion
		#endregion

	}
}

