using System;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	public class DeleteTrackSerializer:SQLTrackSerializer
	{

		private DeleteTrack _track;
		private FieldsSerializer fieldsSerializer;

		public DeleteTrackSerializer()
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
				if(value is DeleteTrack)
					_track = (DeleteTrack)value;
				else
					_track = null;

			}
		}

		protected override void serializeInternalTrackData(XmlTextWriter output) 
		{
			base.serializeInternalTrackData(output);
			output.WriteElementString("BindProfile",_track.bindProfile.ToString());
			output.WriteStartElement("ProfileFields");
			fieldsSerializer.serialize(output,_track.profileFields);
			output.WriteEndElement();
		}

		protected override string id() {return "DeleteTrack";}

		protected override void loadInternalTrackData(XmlReaderEntityNavigator input) 
		{
			string savedLabel;

			base.loadInternalTrackData(input);
			_track.bindProfile = Boolean.Parse(input.getEntityContent());
			savedLabel = input.entitiesBoundLabel;
			input.entitiesBoundLabel = "ProfileFields";
			fieldsSerializer.load(input,_track.profileFields);
			input.entitiesBoundLabel = savedLabel;
		}

	}
}
