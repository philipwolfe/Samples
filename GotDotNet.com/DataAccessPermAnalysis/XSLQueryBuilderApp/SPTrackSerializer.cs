using System;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	public class SPTrackSerializer:TrackSerializer
	{
		StoredProcedureTrack _track;

		public SPTrackSerializer()
		{
		}

		public override ITrack track 
		{
			get 
			{
				return _track;
			}

			set 
			{
				if(value is StoredProcedureTrack)
					_track = (StoredProcedureTrack)value;
				else
					_track = null;
			}
		}

		protected override void serializeInternalTrackData(XmlTextWriter output) 
		{
			output.WriteElementString("Text",_track.text);
			output.WriteElementString("RetrieveMode",_track.retrieveMode.ToString());
			output.WriteStartElement("InputParams");
			foreach(CommandParam param in _track.inputParams)
				serializeParam("Param",param,output);
			output.WriteEndElement();
			if(_track.returnParam != null)
				serializeParam("ReturnParam",_track.returnParam,output);
		}

		private void serializeParam(string tagLabel,CommandParam param,XmlTextWriter output) 
		{
			output.WriteStartElement(tagLabel);
			output.WriteElementString("Label",param.label);
			output.WriteElementString("AppearInData",param.appearInData.ToString());
			output.WriteElementString("Type",param.type);
			output.WriteElementString("Name",param.name);
			output.WriteElementString("Size",param.size.ToString());
			output.WriteEndElement();
		}

		protected override string id() {return "SPTrack";}

		protected override void loadInternalTrackData(XmlReaderEntityNavigator input) 
		{
			string savedLabel;

			_track.text = input.getEntityContent();
			_track.retrieveMode = Boolean.Parse(input.getEntityContent());
			savedLabel = input.entitiesBoundLabel;
			input.entitiesBoundLabel = "InputParams";
			input.moveToEntitiesBegin();
			while(!input.isEntitiesEnd()) 
			{
				input.entitiesBoundLabel = "Param";
				input.moveToEntitiesBegin();
				_track.inputParams.Add(loadParam(input));
				input.entitiesBoundLabel = "InputParams";
				input.moveToNextEntity();
			}
			input.entitiesBoundLabel = savedLabel;
			input.moveToNextEntity();
			if(!input.isEntitiesEnd()) 
			{
				input.entitiesBoundLabel  = "ReturnParam";
				input.moveToEntitiesBegin();
				_track.returnParam = loadParam(input);
			}
			input.entitiesBoundLabel = savedLabel;
		}

		private CommandParam loadParam(XmlReaderEntityNavigator input) 
		{
			CommandParam param = new CommandParam();
			string savedLabel = input.entitiesBoundLabel;

			param.label = input.getEntityContent();
			param.appearInData = Boolean.Parse(input.getEntityContent());
			param.type = input.getEntityContent();
			param.name = input.getEntityContent();
			param.size = Int32.Parse(input.getEntityContent());

			return param;
		}
	}
}
