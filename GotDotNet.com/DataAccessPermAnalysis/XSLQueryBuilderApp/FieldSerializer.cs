using System;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	public class FieldSerializer:IFieldVisitor
	{
		public XmlTextWriter output;
		public XmlReaderEntityNavigator input;
		public bool serializeMode;
		private PDOClassFactory pdoClassFactory;

		public FieldSerializer()
		{
			serializeMode = true;
			pdoClassFactory = PDOClassFactory.getClassFactory();
		}

		public void visit(UnTypedField field) 
		{
			if(serializeMode)
				serialize(field);
			else
				load(field);
		}

		private void serialize(UnTypedField field) 
		{
			serializeTypeID("UnTypedField");
			serializeCommonProperties(field);
		}

		private void serializeTypeID(string typeID) 
		{
			output.WriteAttributeString("id",typeID);
		}

		private void serializeCommonProperties(IField field) 
		{
			output.WriteElementString("Label",field.label);
			output.WriteElementString("FieldNane",field.fieldName);
			output.WriteElementString("TableName",field.tableName);
			output.WriteElementString("Nullable",field.nullable.ToString());
			if(field.fieldReference != null) 
			{
				output.WriteStartElement("FieldReference");
				output.WriteStartElement("Field");
				field.fieldReference.accept(this);
				output.WriteEndElement();
				output.WriteElementString("ConnectionFieldName",field.connectionFieldName);
				output.WriteEndElement();
			}
		}

		private void load(UnTypedField field) 
		{
			input.moveToEntitiesBegin();
			loadCommonProperties(field);
		}

		private void loadCommonProperties(IField field) 
		{
			IField fieldReference;
			string connectionFieldName;
			string savedLabel;

			field.label = input.getEntityContent();
			field.fieldName = input.getEntityContent();
			field.tableName = input.getEntityContent();
			field.nullable = Boolean.Parse(input.getEntityContent());
			if(!input.isEntitiesEnd()) 
			{
				savedLabel = input.entitiesBoundLabel;
				input.entitiesBoundLabel = "FieldReference";
				input.moveToEntitiesBegin();
				fieldReference = pdoClassFactory.createField(input.getEntityAttribute("id"));
				input.entitiesBoundLabel = "Field";
				fieldReference.accept(this);
				input.entitiesBoundLabel = "FieldReference";
				input.moveToNextEntity();
				connectionFieldName = input.getEntityContent();
				input.entitiesBoundLabel = savedLabel;
				field.setFieldReference(fieldReference,connectionFieldName);
			}
		}

		public void visit(StringField field) 
		{
			if(serializeMode)
				serialize(field);
			else
				load(field);
		}

		private void serialize(StringField field) 
		{
			serializeTypeID("StringField");
			serializeCommonProperties(field);
		}

		private void load(StringField field) 
		{
			input.moveToEntitiesBegin();
			loadCommonProperties(field);
		}

		public void visit(DateField field) 
		{
			if(serializeMode)
				serialize(field);
			else
				load(field);
		}

		private void serialize(DateField field) 
		{
			serializeTypeID("DateField");
			output.WriteElementString("DatePattern",field.datePattern);
			serializeCommonProperties(field);
		}

		private void load(DateField field) 
		{
			input.moveToEntitiesBegin();
			field.datePattern = input.getEntityContent();
			loadCommonProperties(field);
		}

		public void visit(NumberField field) 
		{
			if(serializeMode)
				serialize(field);
			else
				load(field);
		}

		private void serialize(NumberField field) 
		{
			serializeTypeID("NumberField");
			output.WriteElementString("Ordinal",field.ordinal.ToString());
			serializeCommonProperties(field);
		}

		private void load(NumberField field) 
		{
			input.moveToEntitiesBegin();
			field.ordinal = Boolean.Parse(input.getEntityContent());
			loadCommonProperties(field);
		}
	}
}
