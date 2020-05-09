using System;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	public interface ITrack
	{
		string label 
		{
			get;
			set;
		}
		
		int pipe 
		{
			get;
			set;
		}

		DataAccessProvider dataAccessProvider 
		{
			get;
			set;
		}

		string ToString();
		void accept(ITrackVisitor visitor);
	}
}
