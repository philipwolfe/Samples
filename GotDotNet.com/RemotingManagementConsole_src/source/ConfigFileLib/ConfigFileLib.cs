//=============================================================================
//	The Remoting Management Console.
//	(C) Copyright 2003, Roman Kiss (rkiss@pathcom.com)
//	All rights reserved.
//	The code and information is provided "as-is" without waranty of any kind,
//	either expresed or implied.
//
//-----------------------------------------------------------------------------
//	History:
//		03/31/2003	Roman Kiss				Initial Revision
//=============================================================================
//

#region references
using System;
using System.Diagnostics;
using System.Collections;
using System.IO;
using System.Text;
using System.Xml;
using System.Xml.XPath;
#endregion

namespace RKiss.RemotingManagement
{
	
	public class ConfigFileAgent
	{
		#region constructor
		public ConfigFileAgent()
		{
		}	
		#endregion

		#region helpers
		public string GetPathToMachineConfigFile() 
		{
			string strMachineConfigFile = string.Format(@"{0}\Microsoft.NET\Framework\v{1}.{2}.{3}\CONFIG\machine.config",
				Environment.GetEnvironmentVariable("windir"),
				Environment.Version.Major,
				Environment.Version.Minor,
				Environment.Version.Build);
			
			return strMachineConfigFile;
		}

		public bool IsExist(string strXPath, string strConfigFile) 
		{
			//---checkpoint
			Trace.WriteLine(string.Format("IsExist: xpath = {0}, configfile = {1}", strXPath, strConfigFile));

			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);

			//---query all 
			XmlNode node = doc.DocumentElement.SelectSingleNode(strXPath);

			return node == null ? false : true;
		}

		public string OutputXmlLayout(string strSource) 
		{
			string strOutputXmlLayout = null;
			StringWriter sw = null;
			XmlTextWriter tw = null;

			try 
			{
				//---prepare formatter
				StringBuilder sb = new  StringBuilder();
				sw = new StringWriter(sb);
				tw = new XmlTextWriter(sw);
				tw.Indentation = 3;
				tw.Formatting = Formatting.Indented;

				//---load xml formatted text from source such as file or string
				XmlDocument doc = new XmlDocument();
	
				try 
				{
					//---string
					doc.LoadXml(strSource);
				}
				catch(Exception ex) 
				{
					//---file
					doc.Load(strSource);
				}

				//---save to the writer
				doc.Save(tw);
				tw.Flush();
				strOutputXmlLayout = sb.ToString();

				//---manualy removeing a xml declaration
				strOutputXmlLayout = strOutputXmlLayout.Remove(0, strOutputXmlLayout.IndexOf("?>", 0) + 2);

			}
			catch(Exception ex) 
			{
			}
			finally 
			{ 
				//---cleanup
				if(tw != null)
					tw.Close();
				if(sw != null)
					sw.Close();
			}
		
			return strOutputXmlLayout;
		}

		public void GetProviders(string strProviderName, string strProviderType, ref ArrayList objProviders, string strConfigFile) 
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/channelSinkProviders/{0}", 
				strProviderName, strProviderType);

			//---checkpoint
			Trace.WriteLine(string.Format("GetProviders: xpath = {0}, configfile = {1}", strXPath, strConfigFile));

			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);

			//---query all 
			XmlNode node = doc.DocumentElement.SelectSingleNode(strXPath);

			if(node != null)
			{
				foreach(XmlNode n in node.ChildNodes) 
				{
					if(n.Name.ToLower() == strProviderType) 
					{
						XmlAttribute attr = (XmlAttribute)n.Attributes.GetNamedItem("id");
						if(attr != null)
							objProviders.Add(attr.Value);
					}
				}
			}
			else 
			{
				string strErrMsg = string.Format("GetProviders: No access for xpath = {0}, configfile = {1}", strXPath, strConfigFile);
				Trace.WriteLine(strErrMsg);
			}	
		}

		public void GetChannels(ref ArrayList objChannels, string strConfigFile) 
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/channels");

			//---checkpoint
			Trace.WriteLine(string.Format("GetProviders: xpath = {0}, configfile = {1}", strXPath, strConfigFile));

			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);

			//---query all 
			XmlNode node = doc.DocumentElement.SelectSingleNode(strXPath);

			if(node != null)
			{
				foreach(XmlNode n in node.ChildNodes) 
				{
					if(n.Name.ToLower() == "channel") 
					{
						XmlAttribute attr = (XmlAttribute)n.Attributes.GetNamedItem("id");
						if(attr != null)
							objChannels.Add(attr.Value);
					}
				}
			}
			else 
			{
				string strErrMsg = string.Format("GetProviders: No access for xpath = {0}, configfile = {1}", strXPath, strConfigFile);
				Trace.WriteLine(strErrMsg);
			}	
		}

		public void GetRemotingConfigSections(ref ArrayList objSections, string strConfigFile) 
		{
			//---path
			//string strXPath = string.Format("/configuration/[not(system.runtime.remoting or appSettings or system.web or system.net or configSections)]");
			string strXPath = string.Format("/configuration");

			//---checkpoint
			Trace.WriteLine(string.Format("GetRemotingConfigSections: xpath = {0}, configfile = {1}", strXPath, strConfigFile));

			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);

			//---query all 
			XmlNode node = doc.DocumentElement.SelectSingleNode(strXPath);

			if(node != null)
			{
				foreach(XmlNode n in node.ChildNodes) 
				{
					if(n.Name != "system.runtime.remoting" && n.Name !=  "appSettings" && n.Name != "configSections" && n.Name != "#comment") 
					{
						objSections.Add(n.Name);
					}
				}
			}
			else 
			{
				string strErrMsg = string.Format("GetRemotingConfigSections: No access for xpath = {0}, configfile = {1}", strXPath, strConfigFile);
				Trace.WriteLine(strErrMsg);
			}	
		}

		public string GetOuterXml(string strXPath, string strConfigFile) 
		{
			//---checkpoint
			Trace.WriteLine(string.Format("GetOuterXml: xpath = {0}, configfile = {1}", strXPath, strConfigFile));

			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);

			//---query all 
			XmlNode node = doc.DocumentElement.SelectSingleNode(strXPath);

			if(node != null)
			{
				return node.OuterXml;
			}
			else 
			{
				string strErrMsg = string.Format("GetOuterXml: No access for xpath = {0}, configfile = {1}", strXPath, strConfigFile);
				Trace.WriteLine(strErrMsg);
			}	

			return null;
		}

		public void RemoveOuterXml(string strXPath, string strConfigFile) 
		{
			//---checkpoint
			Trace.WriteLine(string.Format("RemoveOuterXml: xpath = {0}, configfile = {1}", strXPath, strConfigFile));

			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);

			//---query all 
			XmlNode node = doc.DocumentElement.SelectSingleNode(strXPath);

			if(node != null)
			{
				node.ParentNode.RemoveChild(node);
			}
			else 
			{
				string strErrMsg = string.Format("RemoveOuterXml: No access for xpath = {0}, configfile = {1}", strXPath, strConfigFile);
				Trace.WriteLine(strErrMsg);
				return;
			}	

			doc.Save(strConfigFile);
		}

		public void MoveUpOuterXml(string strXPath, string strConfigFile) 
		{
			//---checkpoint
			Trace.WriteLine(string.Format("RemoveOuterXml: xpath = {0}, configfile = {1}", strXPath, strConfigFile));

			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);

			//---query all 
			XmlNode node = doc.DocumentElement.SelectSingleNode(strXPath);

			if(node != null)
			{
				XmlNode clone = node.Clone();
				XmlNode parent = node.ParentNode;
				int numberOfNode = parent.ChildNodes.Count;
				for(int ii = 0; ii < parent.ChildNodes.Count; ii++)
				{
					if(node.Equals(parent.ChildNodes[ii]))
					{
						if(ii == 0) 
							parent.InsertAfter(clone, parent.ChildNodes[numberOfNode - 1]);
						else 
							parent.InsertBefore(clone, parent.ChildNodes[ii - 1]);
					}
				}

				parent.RemoveChild(node);
			}
			else 
			{
				string strErrMsg = string.Format("RemoveOuterXml: No access for xpath = {0}, configfile = {1}", strXPath, strConfigFile);
				Trace.WriteLine(strErrMsg);
				return;
			}	

			doc.Save(strConfigFile);
		}

		public void InsertInnerXml(string strXPath, string strOuterName, string strNewInnerXml, string strConfigFile) 
		{
			//---checkpoint
			Trace.WriteLine(string.Format("InsertInnerXml: xpath = {0}, innerxml={1}, configfile = {2}", strXPath, strNewInnerXml, strConfigFile));
	
			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);

			//---query all 
			XmlNode node = doc.DocumentElement.SelectSingleNode(strXPath + "/" + strOuterName);

			if(node != null)
			{
				//---merge innerxml
				string innerxml = node.InnerXml;
				node.InnerXml = innerxml + strNewInnerXml;
			}
			else 
			{	
				//---create new section and insert it to the parent node
				node = doc.DocumentElement.SelectSingleNode(strXPath);
				if(node != null)
				{
					XmlNode sp = doc.CreateElement(strOuterName);
					sp.InnerXml = strNewInnerXml;
					node.AppendChild(sp);
				}
				else 
				{
					//---fatal error
					string strErrMsg = string.Format("InsertInnerXml: Can't insert {0} into the {1}, configfile={2}",
							strNewInnerXml, strXPath, strConfigFile);
					Trace.WriteLine(strErrMsg);
					return;
				}
			}	
	
			doc.Save(strConfigFile);		
		}

		public void ReplaceInnerXml(string strXPath, string strNewInnerXml, string strConfigFile) 
		{
			//---checkpoint
			Trace.WriteLine(string.Format("ReplaceInnerXml: xpath = {0}, innerxml = {1}, configfile = {2}", strXPath, strNewInnerXml, strConfigFile));

			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);

			//---query all 
			XmlNode node = doc.DocumentElement.SelectSingleNode(strXPath);

			if(node != null)
			{
				XmlNode parent = node.ParentNode;
				parent.RemoveChild(node);
				parent.InnerXml = parent.InnerXml + strNewInnerXml;
			}
			else 
			{
				string strErrMsg = string.Format("ReplaceInnerXml: No access for xpath = {0}, configfile = {1}", strXPath, strConfigFile);
				Trace.WriteLine(strErrMsg);
				return;
			}	

			doc.Save(strConfigFile);
		}

		public void ReplaceInnerXml(string strXPath, string strOuterName, string strNewInnerXml, string strConfigFile, bool bFirstChild) 
		{
			//---checkpoint
			Trace.WriteLine(string.Format("ReplaceInnerXml: xpath = {0}, innerxml = {1}, configfile = {2}", strXPath, strNewInnerXml, strConfigFile));
	
			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);

			//---query child
			XmlNode node = doc.DocumentElement.SelectSingleNode(strXPath + "/" + strOuterName);

			XmlNode parent = null;
			if(node != null)
			{
				parent = node.ParentNode;
				parent.RemoveChild(node);
			}
			else 
			{
				//---query parent
				parent = doc.DocumentElement.SelectSingleNode(strXPath);
			}

			if(bFirstChild)
				parent.InnerXml = strNewInnerXml + parent.InnerXml;
			else 
				parent.InnerXml = parent.InnerXml + strNewInnerXml;
	
			doc.Save(strConfigFile);				
		}

		public void CreateOuterName(string strXPath, string strOuterName, string strConfigFile) 
		{
			//---checkpoint
			Trace.WriteLine(string.Format("CreateOuterName: xpath = {0}, configfile = {1}", strXPath, strConfigFile));
	
			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);

			//---query all 
			XmlNode node = doc.DocumentElement.SelectSingleNode(strXPath + "/" + strOuterName);

			if(node == null)
			{
				//---create new section
				node = doc.DocumentElement.SelectSingleNode(strXPath);
				if(node != null)
				{
					XmlNode sp = doc.CreateElement(strOuterName);
					node.AppendChild(sp);
				}
				else 
				{
					//---fatal error
					string strErrMsg = string.Format("CreateOuterName: Can't create {0} into the {1}, configfile={2}",
						strOuterName, strXPath, strConfigFile);
					Trace.WriteLine(strErrMsg);
					return;
				}
			}	
	
			doc.Save(strConfigFile);				
		}
		#endregion

		#region appSettings section
		public string GetAppSettings(string strConfigFile) 
		{ 
			string strAppSettingsInnerXml = null;
	
			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);

			//---query all 
			XmlElement root = doc.DocumentElement;
			XmlNode node = root.SelectSingleNode("/configuration/appSettings");

			if(node != null && node.ChildNodes.Count > 0)
			{
				strAppSettingsInnerXml = node.InnerXml;
			}
		
			return strAppSettingsInnerXml;
		}

		public void SetAppSettings(string strAppSettings, string strConfigFile) 
		{ 
			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);

			//---query all 
			XmlElement root = doc.DocumentElement;
			XmlNode node = root.SelectSingleNode("/configuration/appSettings");

			if(node != null)
			{
				node.InnerXml = strAppSettings;
				doc.Save(strConfigFile);
			}	
		}
		#endregion

		#region service section
		public void InsertRemoteObject(string strServiceElement, string strConfigFile) 
		{
			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);
	
			//---insert
			XmlElement root = doc.DocumentElement;
			XmlNode service = root.SelectSingleNode("/configuration/system.runtime.remoting/application/service");
			service.InnerXml = service.InnerXml + strServiceElement;
			
			//---save
			doc.Save(strConfigFile);
		}

		public string GetRemoteObject(string strRemoteObjectType, string strConfigFile) 
		{ 
			string strServiceElement = null;

			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);
	
			//---find 
			XmlElement root = doc.DocumentElement;
			XmlNode service = root.SelectSingleNode("/configuration/system.runtime.remoting/application/service");
			for(int ii=0; ii<service.ChildNodes.Count; ii++) 
			{
				string elem = service.ChildNodes[ii].OuterXml;
				if(elem.IndexOf(strRemoteObjectType) >= 0) 
				{
					strServiceElement = elem;
					break;
				}
			}		
			
			return strServiceElement;
		}

		public string GetServiceOuterXml(string strConfigFile) 
		{ 
			string strServiceOuterXml = null;
	
			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);

			//---query all 
			XmlElement root = doc.DocumentElement;
			XmlNode node = root.SelectSingleNode("/configuration/system.runtime.remoting/application/service");

			if(node != null && node.ChildNodes.Count > 0)
			{
				strServiceOuterXml = node.OuterXml;
			}
		
			return strServiceOuterXml;
		}

		public void UpdateRemoteObject(string strRemoteObjectType, string strServiceElement, string strConfigFile) 
		{
			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);
	
			//---find and update
			XmlElement root = doc.DocumentElement;
			XmlNode service = root.SelectSingleNode("/configuration/system.runtime.remoting/application/service");
			for(int ii=0; ii<service.ChildNodes.Count; ii++) 
			{
				string elem = service.ChildNodes[ii].OuterXml;
				if(elem.IndexOf(strRemoteObjectType) >= 0) 
				{
					service.RemoveChild(service.ChildNodes[ii]);
					service.InnerXml = service.InnerXml + strServiceElement;
					break;
				}
			}		
	
			//---save
			doc.Save(strConfigFile);
		}

		public void RemoveRemoteObject(string strRemoteObjectType, string strConfigFile) 
		{
			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strConfigFile);
	
			//---find and remove
			XmlElement root = doc.DocumentElement;
			XmlNode service = root.SelectSingleNode("/configuration/system.runtime.remoting/application/service");
			for(int ii=0; ii<service.ChildNodes.Count; ii++) 
			{
				string elem = service.ChildNodes[ii].OuterXml;
				if(elem.IndexOf(strRemoteObjectType) >= 0) 
				{
					service.RemoveChild(service.ChildNodes[ii]);
					break;
				}
			}		
	
			//---save
			doc.Save(strConfigFile);
		}
		#endregion

		#region channels section
		public string GetChannels(string strConfigFile) 
		{ 
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels");
		
			return GetOuterXml(strXPath, strConfigFile);
		}

		public string GetChannel(string strChannelName, string strConfigFile) 
		{ 
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels/channel[@ref=\"{0}\" or @id=\"{0}\" or @name=\"{0}\"]", strChannelName);

			return GetOuterXml(strXPath, strConfigFile);
		}

		public void InsertChannel(string strChannelElement, string strConfigFile) 
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application");

			InsertInnerXml(strXPath, "channels", strChannelElement, strConfigFile); 
		}

		public void RemoveChannel(string strChannelName, string strConfigFile) 
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels/channel[@ref=\"{0}\" or @id=\"{0}\" or @name=\"{0}\"]", strChannelName);
	
			RemoveOuterXml(strXPath, strConfigFile); 
		}

		public void UpdateChannel(string strChannelName, string strChannelElement, string strConfigFile) 
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels/channel[@ref=\"{0}\" or @id=\"{0}\" or @name=\"{0}\"]", strChannelName);

			ReplaceInnerXml(strXPath, strChannelElement, strConfigFile);
		}	
		#endregion
		
		#region providers section
		public string GetServerChannelSinks(string strChannelName, string strConfigFile) 
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels/channel[@ref=\"{0}\" or @id=\"{0}\" or @name=\"{0}\"]/serverProviders", strChannelName);
			
			return GetOuterXml(strXPath, strConfigFile);
		}

		public string GetClientChannelSinks(string strChannelName, string strConfigFile) 
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels/channel[@ref=\"{0}\" or @id=\"{0}\" or @name=\"{0}\"]/clientProviders", strChannelName);
			
			return GetOuterXml(strXPath, strConfigFile);
		}

		public void RemoveClientSink(string strChannelName, string strTypeProvider, string strSinkName, string strConfigFile)
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels/channel[@ref=\"{0}\" or @id=\"{0}\" or @name=\"{0}\"]/clientProviders/{1}[@ref=\"{2}\" or @id=\"{2}\" or @name=\"{2}\"]",
				strChannelName, strTypeProvider, strSinkName);

			RemoveOuterXml(strXPath, strConfigFile); 
		}

		public void RemoveServerSink(string strChannelName, string strTypeProvider, string strSinkName, string strConfigFile)
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels/channel[@ref=\"{0}\" or @id=\"{0}\" or @name=\"{0}\"]/serverProviders/{1}[@ref=\"{2}\" or @id=\"{2}\" or @name=\"{2}\"]",
				strChannelName, strTypeProvider, strSinkName);

			RemoveOuterXml(strXPath, strConfigFile); 
		}

		public void InsertClientSink(string strChannelName, string strSinkElement, string strConfigFile)
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels/channel[@ref=\"{0}\" or @id=\"{0}\" or @name=\"{0}\"]", strChannelName);
		
			InsertInnerXml(strXPath, "clientProviders", strSinkElement, strConfigFile);	
		}

		public void InsertServerSink(string strChannelName, string strSinkElement, string strConfigFile)
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels/channel[@ref=\"{0}\" or @id=\"{0}\" or @name=\"{0}\"]", strChannelName);
		
			InsertInnerXml(strXPath, "serverProviders", strSinkElement, strConfigFile);	
		}	

		public string GetServerSink(string strChannelName, string strTypeProvider, string strSinkName, string strConfigFile)
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels/channel[@ref=\"{0}\" or @id=\"{0}\" or @name=\"{0}\"]/serverProviders/{1}[@ref=\"{2}\" or @id=\"{2}\" or @name=\"{2}\"]",
				strChannelName, strTypeProvider, strSinkName);

			return GetOuterXml(strXPath, strConfigFile); 
		}

		public string GetClientSink(string strChannelName, string strTypeProvider, string strSinkName, string strConfigFile)
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels/channel[@ref=\"{0}\" or @id=\"{0}\" or @name=\"{0}\"]/clientProviders/{1}[@ref=\"{2}\" or @id=\"{2}\" or @name=\"{2}\"]",
				strChannelName, strTypeProvider, strSinkName);

			return GetOuterXml(strXPath, strConfigFile); 
		}

		public void UpdateServerSink(string strChannelName, string strTypeProvider, string strSinkName, string strSinkElement, string strConfigFile)
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels/channel[@ref=\"{0}\" or @id=\"{0}\" or @name=\"{0}\"]/serverProviders/{1}[@ref=\"{2}\" or @id=\"{2}\" or @name=\"{2}\"]",
				strChannelName, strTypeProvider, strSinkName);
		
			ReplaceInnerXml(strXPath, strSinkElement, strConfigFile);	
		}

		public void UpdateClientSink(string strChannelName, string strTypeProvider, string strSinkName, string strSinkElement, string strConfigFile)
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels/channel[@ref=\"{0}\" or @id=\"{0}\" or @name=\"{0}\"]/clientProviders/{1}[@ref=\"{2}\" or @id=\"{2}\" or @name=\"{2}\"]",
				strChannelName, strTypeProvider, strSinkName);
		
			ReplaceInnerXml(strXPath, strSinkElement, strConfigFile);	
		}

		public void MoveUpClientSink(string strChannelName, string strTypeProvider, string strSinkName, string strConfigFile)
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels/channel[@ref=\"{0}\" or @id=\"{0}\" or @name=\"{0}\"]/clientProviders/{1}[@ref=\"{2}\" or @id=\"{2}\" or @name=\"{2}\"]",
				strChannelName, strTypeProvider, strSinkName);

			MoveUpOuterXml(strXPath, strConfigFile); 
		}

		public void MoveUpServerSink(string strChannelName, string strTypeProvider, string strSinkName, string strConfigFile)
		{
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/channels/channel[@ref=\"{0}\" or @id=\"{0}\" or @name=\"{0}\"]/serverProviders/{1}[@ref=\"{2}\" or @id=\"{2}\" or @name=\"{2}\"]",
				strChannelName, strTypeProvider, strSinkName);

			MoveUpOuterXml(strXPath, strConfigFile); 
		}
		#endregion

		#region ConfigSettings section
		public string GetSectionOuterXml(string strConfigFile)
		{
			//---I have a problem to setup properly filter pattern
			//---path
			//string strXPath = string.Format("/configuration/[not(system.runtime.remoting or appSettings or system.web or system.net or configSections)]");
			string strXPath = string.Format("/configuration/[configSections]");
		
			return GetOuterXml(strXPath, strConfigFile);
		}

		public string GetRemotingConfigSection(string strSectionName, string strConfigFile)
		{
			//---path
			string strXPath = string.Format("/configuration/{0}", strSectionName);
		
			return GetOuterXml(strXPath, strConfigFile);
		}

		public void UpdateRemotingConfigSection(string strSectionName, string strSectionElement, string strConfigFile) 
		{
			//---path
			string strXPath = string.Format("/configuration");

			ReplaceInnerXml(strXPath, strSectionName, strSectionElement, strConfigFile, true); 
		}	


		#endregion

		#region application channels
		public string GetApplicationChannels(string strConfigFile) 
		{ 
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/channels");
		
			return GetOuterXml(strXPath, strConfigFile);
		}

		public void UpdateApplicationChannels(string strSectionElement, string strConfigFile) 
		{ 
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting");
		
			ReplaceInnerXml(strXPath, "channels", strSectionElement, strConfigFile, false); 
		}

		public string GetApplicationSinks(string strSectionName, string strConfigFile) 
		{ 
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/channelSinkProviders/{0}", strSectionName);
		
			return GetOuterXml(strXPath, strConfigFile);
		}

		public void UpdateApplicationSinks(string strSectionName, string strSectionElement, string strConfigFile) 
		{ 
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting");
	
			CreateOuterName(strXPath, "channelSinkProviders", strConfigFile);
			ReplaceInnerXml(strXPath + "/channelSinkProviders", strSectionName, strSectionElement, strConfigFile, false); 
		}
		#endregion

		#region Lifetime
		public string GetLifetime(string strConfigFile) 
		{ 
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application/lifetime");
		
			return GetOuterXml(strXPath, strConfigFile);
		}

		public void UpdateLifetime(string strSectionElement, string strConfigFile) 
		{ 
			//---path
			string strXPath = string.Format("/configuration/system.runtime.remoting/application");
		
			ReplaceInnerXml(strXPath, "lifetime", strSectionElement, strConfigFile, true); 
		}
		#endregion
	}
}
