using System;
using System.Collections;

namespace XSLQueryBuilderApp
{
	public class DeleteTrack:SQLTrack,IProfileableTrack
	{
		private bool _bindProfile;
		private ArrayList _profileFields;

		public DeleteTrack():this(""){}
		
		public DeleteTrack(string iLabel)
			:base(iLabel)

		{
			_profileFields = new ArrayList();
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

		public override void accept(ITrackVisitor visitor) 
		{
			visitor.visit(this);
		}
	}
}
