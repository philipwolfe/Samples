using System;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	public abstract class TrackSerializer: ITrackSerializer
	{
		public TrackSerializer()
		{
		}

		public abstract ITrack track 
		{
			get;
			set;
		}

		public void serialize(XmlTextWriter output) 
		{
			output.WriteAttributeString("id",id());
			output.WriteElementString("Label",track.label);
			output.WriteElementString("Pipe",track.pipe.ToString());
			output.WriteStartElement("DataAccessProvider");
			track.dataAccessProvider.serialize(output);
			output.WriteEndElement();
			serializeInternalTrackData(output);

		}
		
		protected abstract void serializeInternalTrackData(XmlTextWriter output);

		protected virtual string id() {return "Track";}

		public void load(XmlReaderEntityNavigator input) 
		{
			string savedLabel;

			input.moveToEntitiesBegin();
			track.label = input.getEntityContent();
			track.pipe = Int32.Parse(input.getEntityContent());
			track.dataAccessProvider = new DataAccessProvider();
			savedLabel = input.entitiesBoundLabel;
			input.entitiesBoundLabel = "DataAccessProvider";
			track.dataAccessProvider.load(input);
			input.entitiesBoundLabel = savedLabel;
			input.moveToNextEntity();
			loadInternalTrackData(input);
		}

		protected abstract void loadInternalTrackData(XmlReaderEntityNavigator input);
	}
}
