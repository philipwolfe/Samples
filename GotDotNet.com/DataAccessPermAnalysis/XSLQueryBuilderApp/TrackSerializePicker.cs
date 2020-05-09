using System;
using System.Xml;
using XBLIP.XmlUtil;

namespace XSLQueryBuilderApp
{
	public class TrackSerializePicker:ITrackVisitor
	{
		public XmlTextWriter output;
		public XmlReaderEntityNavigator input;
		public bool serializeMode;

		private RetrieveTrackSerializer retrieveSerializer;
		private UpdateTrackSerializer updateSerializer;
		private InsertTrackSerializer insertSerializer;
		private DeleteTrackSerializer deleteSerializer;
		private SPTrackSerializer spSerializer;
		
		public TrackSerializePicker()
		{
			retrieveSerializer = new RetrieveTrackSerializer();
			updateSerializer = new UpdateTrackSerializer();
			insertSerializer = new InsertTrackSerializer();
			deleteSerializer = new DeleteTrackSerializer();
			spSerializer = new SPTrackSerializer();

			serializeMode = true;
		}

		public void visit(RetrieveTrack track) 
		{
			serializeTrack(track,retrieveSerializer);
		}

		public void visit(UpdateTrack track) 
		{
			serializeTrack(track,updateSerializer);
		}

		public void visit(InsertTrack track) 
		{
			serializeTrack(track,insertSerializer);
		}

		public void visit(DeleteTrack track) 
		{
			serializeTrack(track,deleteSerializer);
		}

		public void visit(StoredProcedureTrack track) 
		{
			serializeTrack(track,spSerializer);
		}

		private void serializeTrack(ITrack track,ITrackSerializer serializer) 
		{
			serializer.track = track;
			if(serializeMode)
				serializer.serialize(output);
			else
				serializer.load(input);
		}
	}
}
