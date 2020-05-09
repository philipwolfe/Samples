using System;

namespace XSLQueryBuilderApp
{
	public class SPTrackWriter: TrackWriter
	{
		private const string RETRIEVE_MODE_END =
			@"	</Result></Item></Response>";

		
		StoredProcedureTrack _track;

		public SPTrackWriter():this(null){}
		public SPTrackWriter(XSLTextWriter iOutput):base(iOutput)
			{}

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

		protected override void writeTrackBody() 
		{
			if(_track.retrieveMode) 
			{
				writeRetrieveStart();
				writeSPCall();
				writeRetrieveEnd();
			} else
				writeSPCall();


		}

		private void writeRetrieveStart() 
		{
			output.WriteTextElement("<Response id='");
			output.WriteValueOfElement("Request/@id");
			output.WriteTextElement("' action='");
			output.WriteValueOfElement("Request/@action");
			output.WriteTextElement("'><Item id='result'><Result> \n");
		}

		private void writeRetrieveEnd() 
		{
			output.WriteTextElement(" \n" + RETRIEVE_MODE_END);
		}

		private void writeSPCall() 
		{
			output.WriteStartTextElement();
			output.WriteString("DB_FUNC_START \n");
			output.WriteString("<Function type=\"procedure\">");
			output.WriteString(" \n");
			if(_track.returnParam != null) 
				writeReturnParam(_track.returnParam);
			output.WriteEndTextElement();
			foreach(CommandParam param in _track.inputParams)
				writeParam(param);
			output.WriteStartTextElement();
			output.WriteString("<Text>" + _track.text + "</Text>\n");
			output.WriteString("</Function>\n");
			output.WriteString("DB_FUNC_END");
			output.WriteEndTextElement();
		}

		private void writeReturnParam(CommandParam param) 
		{
			output.WriteString(
				"<Return type=\"" +
				param.type +
				"\" name=\"" +
				param.name +
				"\"" +
				("varChar" == param.type ? 
					" size=\"" + param.size + "\"": "") +
				"/>\n");
		}

		private void writeParam(CommandParam param) 
		{
			string valueOfPath;

			output.WriteTextElement(
				"<Param type=\"" +
				param.type +
				"\" name=\"" +
				param.name +
				"\">");
			if(param.appearInData) 
				valueOfPath = "Request/Data/" + param.label;
			else
				valueOfPath = "Request/Profile/" + param.label + "/Item";
			output.WriteValueOfElement(valueOfPath);
			output.WriteTextElement("</Param>");
		}
	}
}
