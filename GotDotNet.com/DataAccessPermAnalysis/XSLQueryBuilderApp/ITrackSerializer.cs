using System;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	public interface ITrackSerializer
	{

		ITrack track 
		{
			get;
			set;
		}

		void serialize(XmlTextWriter output);
		void load(XmlReaderEntityNavigator input);
	}
}
