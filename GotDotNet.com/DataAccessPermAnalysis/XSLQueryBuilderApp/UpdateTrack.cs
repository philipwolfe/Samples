using System;
using System.Collections;

namespace XSLQueryBuilderApp
{
	public class UpdateTrack:SQLTrack,IProfileableTrack
	{

		private bool _bindProfile;
		private ArrayList _dataFields;
		private ArrayList _profileFields;

		public UpdateTrack():this(""){}
		
		public UpdateTrack(string iLabel)
			:base(iLabel)

		{
			_profileFields = new ArrayList();
			_dataFields = new ArrayList();
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
