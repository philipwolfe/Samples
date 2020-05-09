using System;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	public class RetrieveTrackSerializer:SQLTrackSerializer
	{
		private RetrieveTrack _track;
		private FieldsSerializer fieldsSerializer;

		public RetrieveTrackSerializer()
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
				if(value is RetrieveTrack)
					_track = (RetrieveTrack)value;
				else
					_track = null;

			}
		}

		protected override void serializeInternalTrackData(XmlTextWriter output) 
		{
			base.serializeInternalTrackData(output);
			output.WriteElementString("ParemRetrieve",_track.paramRetrieve.ToString());
			output.WriteElementString("Intersect",_track.intersect.ToString());
			output.WriteElementString("NoMerge",_track.noMerge.ToString());
			output.WriteElementString("BindProfile",_track.bindProfile.ToString());
			output.WriteStartElement("MainTablePK");
			foreach(string pkPart in _track.mainTablePK)
				output.WriteElementString("PKPart",pkPart);
			output.WriteEndElement();
			output.WriteStartElement("DataFields");
			fieldsSerializer.serialize(output,_track.dataFields);
			output.WriteEndElement();
			output.WriteStartElement("ProfileFields");
			fieldsSerializer.serialize(output,_track.profileFields);
			output.WriteEndElement();
		}

		protected override string id() {return "RetrieveTrack";}


		protected override void loadInternalTrackData(XmlReaderEntityNavigator input) 
		{
			string savedLabel;

			base.loadInternalTrackData(input);
			savedLabel = input.entitiesBoundLabel;
			_track.paramRetrieve = Boolean.Parse(input.getEntityContent());
			_track.intersect = Boolean.Parse(input.getEntityContent());
			_track.noMerge = Boolean.Parse(input.getEntityContent());
			_track.bindProfile = Boolean.Parse(input.getEntityContent());
			input.entitiesBoundLabel = "MainTablePK";
			input.moveToEntitiesBegin();
			while(!input.isEntitiesEnd())
				_track.mainTablePK.Add(input.getEntityContent());
			input.entitiesBoundLabel = savedLabel;
			input.moveToNextEntity();
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
