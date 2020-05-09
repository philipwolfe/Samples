using System;
using System.Collections;


namespace XSLQueryBuilderApp
{

	public class RetrieveTrack : SQLTrack,IProfileableTrack
	{
		public bool paramRetrieve;
		public bool intersect;
		public bool noMerge;
		private bool _bindProfile;
		private ArrayList _mainTablePK;
		private ArrayList _dataFields;
		private ArrayList _profileFields;

		public RetrieveTrack():this(""){}
		public RetrieveTrack(string iLabel)
			:base(iLabel)
		{
			paramRetrieve = false;
			intersect = false;
			noMerge = false;
			bindProfile = false;
			_mainTablePK = new ArrayList();
			_dataFields = new ArrayList();
			_profileFields = new ArrayList();
		}

		public ArrayList dataFields
		{
			get 
			{
				return _dataFields;
			}
		}

		public ArrayList profileFields 
		{
			get 
			{
				return _profileFields;
			}
		}

		public bool bindProfile 
		{
			get 
			{
				return _bindProfile;
			}

			set 
			{
				_bindProfile = value;
			}
		}


		public ArrayList mainTablePK 
		{
			get 
			{
				return _mainTablePK;
			}
		}

		public override void accept(ITrackVisitor visitor) 
		{
			visitor.visit(this);
		}
	}
}
