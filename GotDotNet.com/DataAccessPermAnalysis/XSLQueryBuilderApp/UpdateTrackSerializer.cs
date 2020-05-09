using System;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{

	public class UpdateTrackSerializer:SQLTrackSerializer
	{
		private UpdateTrack _track;
		private FieldsSerializer fieldsSerializer;
		
		public UpdateTrackSerializer()
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
				if(value is UpdateTrack)
					_track = (UpdateTrack)value;
				else
					_track = null;

			}
		}

		protected override void serializeInternalTrackData(XmlTextWriter output) 
		{
			base.serializeInternalTrackData(output);
			output.WriteElementString("BindProfile",_track.bindProfile.ToString());
			output.WriteStartElement("DataFields");
			fieldsSerializer.serialize(output,_track.dataFields);
			output.WriteEndElement();
			output.WriteStartElement("ProfileFields");
			fieldsSerializer.serialize(output,_track.profileFields);
			output.WriteEndElement();
		}

		protected override string id() {return "UpdateTrack";}

		protected override void loadInternalTrackData(XmlReaderEntityNavigator input) 
		{
			string savedLabel;

			base.loadInternalTrackData(input);
			_track.bindProfile = Boolean.Parse(input.getEntityContent());
			savedLabel = input.entitiesBoundLabel;
			input.entitiesBoundLabel = "DataFields";
			fieldsSerializer.load(input,_track.dataFields);
			input.entitiesBoundLabel = savedLabel;
			input.moveToNextEntity();
			input.entitiesBoundLabel = "ProfileFields";
			fieldsSerializer.load(input,_track.profileFields);
			input.entitiesBoundLabel = savedLabel;
		}
	}
}
