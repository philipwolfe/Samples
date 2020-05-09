using System;
using System.Collections;

namespace XSLQueryBuilderApp
{

	public class InsertTrack:SQLTrack
	{

		private ArrayList _dataFields;

		public InsertTrack():this(""){}
		
		public InsertTrack(string iLabel)
			:base(iLabel)

		{
			_dataFields = new ArrayList();
		}

		public ArrayList dataFields
		{
			get 
			{
				return _dataFields;
			}
		}

		public override void accept(ITrackVisitor visitor) 
		{
			visitor.visit(this);
		}
	}
}
