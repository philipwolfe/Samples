using System;
using System.Xml;
using System.Configuration;

namespace MMModule
{
	
	public struct PathConfig
	{
		public string fullPath;
		public string[] extensions;
		public bool checkCreate;
		public bool checkChange;
		public bool checkRename;
	}

	public class MWatcherConfigHandler : IConfigurationSectionHandler
	{
		public MWatcherConfigHandler()
		{			
		}

		private string TranslatePath(string path)
		{						
			if(path.StartsWith("~/"))
			{
				path = path.Replace("~/", System.Web.HttpRuntime.AppDomainAppPath);
			}
			path = path.Replace("/", "\\");
			return path;
		}

		#region IConfigurationSectionHandler Members

		public object Create(object parent, object configContext, System.Xml.XmlNode section)
		{
			System.Collections.ArrayList paths = new System.Collections.ArrayList();
			foreach(XmlNode node in  section.SelectNodes("path"))
			{
				PathConfig pc;
				pc.fullPath = TranslatePath(node.Attributes["value"].Value);
				pc.extensions = node.Attributes["extensions"].Value.Split(';');
				
				if(node.Attributes["restartOnCreate"] != null && node.Attributes["restartOnCreate"].Value == "false")
					pc.checkCreate = false;
				else
					pc.checkCreate = true;

				if(node.Attributes["restartOnRename"] != null && node.Attributes["restartOnRename"].Value == "false")
					pc.checkRename = false;
				else
					pc.checkRename = true;

				if(node.Attributes["restartOnChange"] != null && node.Attributes["restartOnChange"].Value == "false")
					pc.checkChange = false;
				else
					pc.checkChange = true;

				paths.Add(pc);
			}
			
			return paths.ToArray(typeof(PathConfig));
		}

		#endregion
	}
}
