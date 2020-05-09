using System;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	public abstract class SQLTrackSerializer:TrackSerializer
	{
		public SQLTrackSerializer()
		{
		}

		public abstract ISQLTrack sqlTrack 
		{
			get;
			set;
		}

		public override ITrack track 
		{
			get 
			{
				return sqlTrack;
			}
			set 
			{
				if(value is ISQLTrack)
					sqlTrack = (ISQLTrack)value;
				else
					sqlTrack = null;
			}
		}

		protected override void serializeInternalTrackData(XmlTextWriter output) 
		{
			output.WriteElementString("MainTable",sqlTrack.mainTable);
		}

		protected override void loadInternalTrackData(XmlReaderEntityNavigator input) 
		{
			sqlTrack.mainTable = input.getEntityContent();
		}

	}
}
