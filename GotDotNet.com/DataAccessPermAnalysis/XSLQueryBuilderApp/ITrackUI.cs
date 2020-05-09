using System;

namespace XSLQueryBuilderApp
{
	public interface ITrackUI:IPDOUI
	{
		ITrack track 
		{
			get;
			set;
		}
	}
}
