using System;
using System.Collections;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	public class AccessProvidersStorage
	{

		private Hashtable _providers;
		private static AccessProvidersStorage singleton;

		private AccessProvidersStorage()
		{
			_providers = new Hashtable();
		}

		public Hashtable providers 
		{
			get 
			{
				return _providers;
			}
		}

		public static AccessProvidersStorage getStorage() 
		{
			if(singleton == null)
				singleton = new AccessProvidersStorage();
			return singleton;
		}

		public void serialize(XmlTextWriter output) 
		{
			foreach(DataAccessProvider provider in _providers.Values) 
			{
				output.WriteStartElement("DataAccessProvider");
				provider.serialize(output);
				output.WriteEndElement();
			}
		}

		public void load(XmlReaderEntityNavigator input) 
		{
			DataAccessProvider provider;
			string savedLabel = input.entitiesBoundLabel;

			input.moveToEntitiesBegin();
			while(!input.isEntitiesEnd()) 
			{
				provider = new DataAccessProvider();
				input.entitiesBoundLabel = "DataAccessProvider";
				provider.load(input);
				input.entitiesBoundLabel = savedLabel;
				input.moveToNextEntity();
				_providers.Add(provider.label,provider);
			}
		}
	}
}
