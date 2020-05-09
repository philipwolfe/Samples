using System;

namespace XSLQueryBuilderApp
{
	public interface ISQLTrack:ITrack
	{
		string mainTable 
		{
			get;
			set;
		}

	}
}
