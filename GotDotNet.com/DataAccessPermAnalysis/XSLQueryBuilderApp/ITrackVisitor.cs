using System;

namespace XSLQueryBuilderApp
{
	public interface ITrackVisitor
	{
		void visit(RetrieveTrack track);
		void visit(UpdateTrack track);
		void visit(InsertTrack track);
		void visit(DeleteTrack track);
		void visit(StoredProcedureTrack track);
	}
}
