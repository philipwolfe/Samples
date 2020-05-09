using System;

namespace XSLQueryBuilderApp
{
	public interface ITrackWriter
	{
		XSLTextWriter output 
		{
			get;
			set;
		}

		ITrack track 
		{
			get;
			set;
		}
		void write();
	}
}
