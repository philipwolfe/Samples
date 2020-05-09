using System;
using System.Collections;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	public class FieldsSerializer
	{
		private FieldSerializer fieldSerializer;

		public FieldsSerializer()
		{
			fieldSerializer = new FieldSerializer();
		}

		public void serialize(XmlTextWriter output,ArrayList fields) 
		{
			fieldSerializer.serializeMode = true;
			fieldSerializer.output = output;
			foreach(IField field in fields) 
			{
				output.WriteStartElement("Field");
				field.accept(fieldSerializer);
				output.WriteEndElement();
			}
		}

		public void load(XmlReaderEntityNavigator input,ArrayList fields) 
		{
			PDOClassFactory pdoClassFactory = PDOClassFactory.getClassFactory();
			IField field;
			string savedLabel = input.entitiesBoundLabel;

			fieldSerializer.serializeMode = false;
			fieldSerializer.input = input;
			if(input.moveToEntitiesBegin()) 
			{
				while(!input.isEntitiesEnd()) 
				{
					field = pdoClassFactory.createField(input.getEntityAttribute("id"));
					input.entitiesBoundLabel = "Field";
					field.accept(fieldSerializer);
					fields.Add(field);
					input.entitiesBoundLabel = savedLabel;
					input.moveToNextEntity();
				}
			}
		}
	}
}
