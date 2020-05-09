using System;

namespace XSLQueryBuilderApp
{
	public abstract class SQLTrack:Track,ISQLTrack
	{

		protected string _mainTable;

		public SQLTrack():this(""){}
		public SQLTrack(string iLabel):base(iLabel){}

		public string mainTable 
		{
			get 
			{
				return _mainTable;
			}

			set 
			{
				_mainTable = value;
			}
		}


	}
}
