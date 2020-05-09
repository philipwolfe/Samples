using System;
using System.Collections;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	public class Query
	{
		ArrayList _tracks;


		public Query()
		{	
			_tracks = new ArrayList();
		}

		public ArrayList tracks 
		{
			get 
			{
				return _tracks;
			}
		}

		public void serialize(XmlTextWriter output) 
		{
			TrackSerializePicker serializerPicker = new TrackSerializePicker();

			serializerPicker.output = output;
			output.WriteStartElement("Query");
			foreach(Track track in tracks) 
			{
				output.WriteStartElement("Track");
				track.accept(serializerPicker);
				output.WriteEndElement();
			}
			output.WriteEndElement();
		}

		public void serialize(string filename) 
		{
			XmlTextWriter output = new XmlTextWriter(
				filename,
				System.Text.Encoding.GetEncoding(PreferencesStorage.getStorage().encoding)
				);
			output.WriteStartDocument(true);
			serialize(output);
			output.WriteEndDocument();
			output.Close();
		}

		public void load(XmlReaderEntityNavigator input) 
		{
			PDOClassFactory pdoClassFactory;
			TrackSerializePicker serializerPicker;
			ITrack track;

			if(input.moveToEntitiesBegin())  
			{
				pdoClassFactory = PDOClassFactory.getClassFactory();
				serializerPicker = new TrackSerializePicker();
				serializerPicker.serializeMode = false;
				serializerPicker.input = input;
				while(!input.isEntitiesEnd())
				{
					track = pdoClassFactory.createTrack(input.getEntityAttribute("id"));
					input.entitiesBoundLabel = "Track";
					track.accept(serializerPicker);
					_tracks.Add(track);
					input.entitiesBoundLabel = "Query";
					input.moveToNextEntity();
				}
			}
				
		}

		public void load(string filename) 
		{
			XmlTextReader input = new XmlTextReader(filename);
			load(new XmlReaderEntityNavigator(input,"Query"));
			input.Close();
		}

	}
}
