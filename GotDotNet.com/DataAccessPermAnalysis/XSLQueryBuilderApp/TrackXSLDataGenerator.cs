using System;

namespace XSLQueryBuilderApp
{
	public class TrackXSLDataGenerator:ITrackVisitor
	{
		public XSLTextWriter output;

		private RetrieveTrackWriter retrieveWriter;
		private UpdateTrackWriter updateWriter;
		private InsertTrackWriter insertWriter;
		private DeleteTrackWriter deleteWriter;
		private SPTrackWriter spWriter;

		public TrackXSLDataGenerator()
		{
			output = null;
			retrieveWriter = new RetrieveTrackWriter();
			updateWriter = new UpdateTrackWriter();
			insertWriter = new InsertTrackWriter();
			deleteWriter = new DeleteTrackWriter();
			spWriter = new SPTrackWriter();
		}

		public void visit(RetrieveTrack track) 
		{
			writeTrack(track,retrieveWriter);
		}

		public void visit(UpdateTrack track) 
		{
			writeTrack(track,updateWriter);
		}

		public void visit(InsertTrack track) 
		{
			writeTrack(track,insertWriter);
		}

		public void visit(DeleteTrack track) 
		{
			writeTrack(track,deleteWriter);
		}

		public void visit(StoredProcedureTrack track) 
		{
			writeTrack(track,spWriter);
		}

		private void writeTrack(ITrack trackToWrite,ITrackWriter writer) 
		{
			writer.output = output;
			writer.track = trackToWrite;
			writer.write();
		}
	}
}
