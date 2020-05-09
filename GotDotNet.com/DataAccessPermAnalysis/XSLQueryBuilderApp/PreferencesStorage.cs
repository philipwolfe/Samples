using System;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	public class PreferencesStorage
	{
		private const string DEFAULT_ENCODING = "Windows-1255";

		public string encoding;
		public string templatesLibraryPath;

		private static PreferencesStorage singleton;

		private PreferencesStorage()
		{
			encoding = DEFAULT_ENCODING;
		}

		public static PreferencesStorage getStorage() 
		{
			if(null == singleton)
				singleton = new PreferencesStorage();

			return singleton;

		}

		public void load(XmlReaderEntityNavigator input) 
		{
			encoding = input.getEntityContent();
			templatesLibraryPath = input.getEntityContent();
		}

		public void serialize(XmlTextWriter output) 
		{
			output.WriteElementString("Encoding",encoding);
			output.WriteElementString("TemplatesLibraryPath",templatesLibraryPath);
		}
	}
}
