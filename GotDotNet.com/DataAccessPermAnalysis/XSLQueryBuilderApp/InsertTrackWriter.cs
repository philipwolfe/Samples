using System;
using System.Collections;

namespace XSLQueryBuilderApp
{
	public class InsertTrackWriter:TrackWriter
	{

		private delegate void FieldMethod(IField field);
		private delegate void SeparationWriteMethod();

		private InsertTrack _track;
		private FieldMethod writeFieldNameMethod;
		private FieldMethod writeFieldValueGetMethod;
		private SeparationWriteMethod writeCommaStringMethod;
		private SeparationWriteMethod writeCommaElementMethod;
		private FieldTypeConversion typeConverter;

		public InsertTrackWriter():this(null) {}
		public InsertTrackWriter(XSLTextWriter iOutput):base(iOutput)
		{
			writeFieldNameMethod = new FieldMethod(writeFieldName);
			writeFieldValueGetMethod = new FieldMethod(writeFieldValueGet);
			writeCommaStringMethod = new SeparationWriteMethod(writeCommaString);
			writeCommaElementMethod = new SeparationWriteMethod(writeCommaElement);
			typeConverter = new FieldTypeConversion();
			typeConverter.getMode = false;
		}


		public override ITrack track
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

		protected override void writeTrackBody() 
		{
			typeConverter.output = output;
			writeInsertIntoSection();
			writeFieldsDeclarationSection();
			writeValuesSection();
		}

		private void writeInsertIntoSection() 
		{
			output.WriteTextElement("INSERT INTO " + _track.mainTable + "\n");
		}

		private void writeFieldsDeclarationSection() 
		{
			output.WriteStartTextElement();
			output.WriteString("(");
			writeFieldWithSeparation(writeFieldNameMethod,writeCommaStringMethod);
			output.WriteString(")\n");
			output.WriteEndTextElement();
		}


		private void writeFieldName(IField field) 
		{
			output.WriteString(field.fieldName);
		}

		private void writeCommaString() 
		{
			output.WriteString(",");
		}

		private void writeFieldWithSeparation(FieldMethod fieldWriteMethod,SeparationWriteMethod separationWriteMethod) 
		{
			IEnumerator enumerator = _track.dataFields.GetEnumerator();

			if(enumerator.MoveNext()) 
			{
				fieldWriteMethod((IField)enumerator.Current);
				while(enumerator.MoveNext()) 
				{
					separationWriteMethod();
					fieldWriteMethod((IField)enumerator.Current);
				}
			} 
		}

		private void writeValuesSection() 
		{
			output.WriteTextElement("values(\n");
			writeFieldWithSeparation(writeFieldValueGetMethod,writeCommaElementMethod);
			output.WriteTextElement(")\n");
		}

		private void writeCommaElement() 
		{
			output.WriteTextElement(",");
		}

		private void writeFieldValueGet(IField field) 
		{
			if(field.nullable)
				writeNullFieldGet(field);
			else
				writeNotNullFieldGet(field);
		}

		private void writeNullFieldGet(IField field) 
		{
			output.WriteStartChooseElement();
			output.WriteStartWhenClause();
			output.WriteString(getFieldPath(field));
			output.WriteEndAttribute();
			typeConverter.fieldValuePath = getFieldPath(field);			
			field.accept(typeConverter);
			output.WriteEndWhenClause();
			output.WriteStartOtherwiseElement();
			output.WriteString("null");
			output.WriteEndOtherwiseElement();
			output.WriteEndChooseElement();
		}

		private string getFieldPath(IField field) 
		{
			return "Request/Data/" + field.label;
		}

		private void writeNotNullFieldGet(IField field) 
		{
			typeConverter.fieldValuePath = getFieldPath(field);			
			field.accept(typeConverter);
		}
	}
	
}
