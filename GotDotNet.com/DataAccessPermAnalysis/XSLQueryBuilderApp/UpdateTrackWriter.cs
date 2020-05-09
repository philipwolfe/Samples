using System;

namespace XSLQueryBuilderApp
{
	public class UpdateTrackWriter:TrackWriter
	{

		private UpdateTrack _track;
		private string mainTableShortName;
		private NonJoinProfileWriter profileWriter;
		private FieldTypeConversion typeConvertor;

		public UpdateTrackWriter():this(null) {}
		public UpdateTrackWriter(XSLTextWriter iOutput):base(iOutput)
		{
			profileWriter = new NonJoinProfileWriter();
			typeConvertor = new FieldTypeConversion();
			typeConvertor.getMode = false;
		}

		public override ITrack track
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

		protected override void writeTrackBody() 
		{
			if(_track.bindProfile)
				writeBVQQuery();
			else
				writeSimpleQuery();
		}

		private void writeBVQQuery() 
		{
			BVQEncapsulationWriter encapsulationWriter = new BVQEncapsulationWriter();

			encapsulationWriter.output = output;
			encapsulationWriter.profileableTrack = _track;
			encapsulationWriter.writeBVQHeader("");
			writeSimpleQuery();
			encapsulationWriter.writeBVQFooter();
		}

		private void writeSimpleQuery() 
		{
			generateMainTableShortName();
			typeConvertor.output = output;
			writeUpdateSetSection();
			writeDataFieldsUpdateSection();
			writeUpdateProfileSection();
		}

		private void generateMainTableShortName() 
		{
			ShortNamesGenerator generator = ShortNamesGenerator.getGenerator();

			generator.reset();
			mainTableShortName = generator.generateShortName(_track.mainTable);
		}

		private void writeUpdateSetSection() 
		{
			output.WriteStartTextElement();
			output.WriteString(
				"UPDATE " + _track.mainTable + " " + mainTableShortName +
				" SET \n");
			output.WriteEndTextElement();
		}

		private void writeDataFieldsUpdateSection() 
		{
			output.WriteStartForEachClause();
			output.WriteString("Request/Data/*");
			output.WriteEndAttribute();
			output.WriteStartIfClause();
			output.WriteString("position()!=1");
			output.WriteEndAttribute();
			output.WriteString(",");
			output.WriteEndIfClause();
			output.WriteStartChooseElement();
			writeDataFields();
			output.WriteEndChooseElement();
			output.WriteEndForEachClause();
		}

		private void writeDataFields() 
		{
			foreach(IField field in _track.dataFields) 
				writeDataField(field);
		}

		private void writeDataField(IField field) 
		{
			output.WriteStartWhenClause();
			output.WriteString("self::" + field.label);
			output.WriteEndAttribute();
			if(field.nullable) 
				writeNullableDataField(field);
			else
				writeDataFieldSet(field);
			output.WriteEndWhenClause();
		}

		private void writeNullableDataField(IField field) 
		{
			output.WriteStartChooseElement();
			output.WriteStartWhenClause();
			output.WriteString("@type='null'");
			output.WriteEndAttribute();
			output.WriteString(mainTableShortName + "." + field.fieldName + " = null");
			output.WriteEndWhenClause();
			output.WriteStartOtherwiseElement();
			writeDataFieldSet(field);
			output.WriteEndOtherwiseElement();
			output.WriteEndChooseElement();
		}

		private void writeDataFieldSet(IField field) 
		{
			output.WriteTextElement(mainTableShortName + "." + field.fieldName + " = ");
			typeConvertor.fieldValuePath = ".";
			field.accept(typeConvertor);
		}

		private void writeUpdateProfileSection() 
		{
			profileWriter.mainTableLabel = mainTableShortName;
			profileWriter.profileableTrack = _track;
			profileWriter.output = output;
			profileWriter.writeProfile();
		}


	}
}
