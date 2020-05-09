using System;
using System.Collections;
using System.Xml;
using System.Windows.Forms;

namespace XSLQueryBuilderApp
{
	public class QueryXSLBuilder
	{
		public Query query;
		private XSLTextWriter output;
		private TrackXSLDataGenerator trackDataGenerator;

		public QueryXSLBuilder():this(null){}
		public QueryXSLBuilder(Query iQuery)
		{
			query = iQuery;
			trackDataGenerator = new TrackXSLDataGenerator();
		}

		public void generateQueryXSL(string filename) 
		{
			output = new XSLTextWriter(
				filename,
				System.Text.Encoding.GetEncoding(PreferencesStorage.getStorage().encoding)
				);
			output.Formatting = Formatting.Indented;
			writeHeader();
			trackDataGenerator.output = output;
			foreach(Track queryTrack in query.tracks) 
				queryTrack.accept(trackDataGenerator);
			writeFooter();

			output.Close();
		}

		private void writeHeader() 
		{
			output.WriteStartDocument(true);
			output.WriteStartStylesheetElement();
			output.WriteOutputOmitXMLElement();
			writeReferencedTypeTemplates();
			output.WriteStartMatchTemplate("/");
		}

		private void writeReferencedTypeTemplates() 
		{
			Hashtable referencedTemplates =	collectTypeTemplatesFromTracks();
			string templatesLibraryPath = PreferencesStorage.getStorage().templatesLibraryPath;
			
			if("" == templatesLibraryPath)
				templatesLibraryPath = Application.StartupPath;

			foreach(string templateName in referencedTemplates.Values)
				output.WriteIncludeElement(templatesLibraryPath +  "\\General\\TypeTemplates\\" + templateName + ".xsl");
		}

		private Hashtable collectTypeTemplatesFromTracks() 
		{
			Hashtable referencedTemplates = new Hashtable();
			FieldProfileTemplateAdvisor templateAdvisor = new FieldProfileTemplateAdvisor();

			foreach(Track track in query.tracks) 
				if(track is IProfileableTrack) 
					templateAdvisor.collectProfileTypeTemplates(referencedTemplates,(IProfileableTrack)track);

			return referencedTemplates;
		}

		private void writeFooter() 
		{
			output.WriteEndMatchTemplate();
			output.WriteEndStylesheetElement();
			output.WriteEndDocument();
		}


	}
}
