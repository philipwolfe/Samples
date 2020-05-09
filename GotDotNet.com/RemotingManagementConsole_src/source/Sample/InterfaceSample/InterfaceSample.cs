using System;

namespace RemotingManagementSample
{
	public interface InterfaceSample
	{
		string Echo(string strMsg);
		string GetOuterXml(string strXPath, string strPathToConfigFile);
	}
}
