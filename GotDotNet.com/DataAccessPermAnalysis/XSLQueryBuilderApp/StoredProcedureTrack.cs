using System;
using System.Collections;

namespace XSLQueryBuilderApp
{
	public class StoredProcedureTrack : Track
	{

		public CommandParam returnParam;
		public ArrayList inputParams;
		public string text;
		public bool retrieveMode;

		public StoredProcedureTrack():this(""){}
		
		public StoredProcedureTrack(string iLabel)
			:base(iLabel) 
		{
			inputParams = new ArrayList();
			returnParam = null;
			text = "";
			retrieveMode = false;
		}

		public override void accept(ITrackVisitor visitor) 
		{
			visitor.visit(this);
		}
	}
}
