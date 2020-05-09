using System;
using System.Collections;

namespace XSLQueryBuilderApp
{
	public interface IProfileableTrack:ITrack
	{

		ArrayList profileFields 
		{
			get;
		}

		bool bindProfile 
		{
			get;
			set;
		}
	}
}
