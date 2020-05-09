using System;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	public class InsertTrackSerializer:SQLTrackSerializer
	{

		private InsertTrack _track;
		private FieldsSerializer fieldsSerializer;

		public InsertTrackSerializer()
		{
			fieldsSerializer = new FieldsSerializer();
		}

		public override ISQLTrack sqlTrack 
		{
			get 
			{
				return _track;
			}
			set 
			{
				if(value is InsertTrack)
					_track = (InsertTrack)value;
				else
					_track = null;

			}
		}

		protected override void serializeInternalTrackData(XmlTextWriter output) 
		{
			base.serializeInternalTrackData(output);
			output.WriteStartElement("DataFields");
			fieldsSerializer.serialize(output,_track.dataFields);
			output.WriteEndElement();
		}

		protected override string id() {return "InsertTrack";}

		protected override void loadInternalTrackData(XmlReaderEntityNavigator input) 
		{
			string savedLabel;

			base.loadInternalTrackData(input);
			savedLabel = input.entitiesBoundLabel;
			input.entitiesBoundLabel = "DataFields";
			fieldsSerializer.load(input,_track.dataFields);
			input.entitiesBoundLabel = savedLabel;
		}

	}
}
