using System;
using System.Xml;



namespace RemotingManagementSample
{

	public class RemotingObjectSample : MarshalByRefObject, InterfaceSample
	{

		public RemotingObjectSample() 
		{
		}

		public string Echo(string strMsg) 
		{
			return "This is an Echo message: " + strMsg;
		}

		public string GetOuterXml(string strXPath, string strPathToConfigFile) 
		{
			//---retrieve
			XmlDocument doc = new XmlDocument();
			doc.Load(strPathToConfigFile);

			//---query all 
			XmlNode node = doc.DocumentElement.SelectSingleNode(strXPath);

			return node.OuterXml;
		}
	}
}
