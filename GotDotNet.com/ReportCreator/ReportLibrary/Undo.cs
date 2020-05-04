using System;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region Undo
	public class Undo
	{
		#region class variables
		int pos;
		int Capacity;
		StringList Buf;
		#endregion

		#region class methods
		public void Clear()
		{
			Buf.Clear();
			for(int i=0;i<Capacity;i++)
				Buf.AddObject("",null);
			pos=0;
		}

		public string GetUndo()
		{
			string freturn="";
			if(CanUndo())
			{
				pos=GetPos(pos-1);
				freturn=Buf.GetString(pos);
			}
			return freturn;
		}

		public string GetRedo()
		{
			string freturn="";
			if(CanRedo())
			{
				pos=GetPos(pos+1);
				freturn=Buf.GetString(pos);
			}
			return freturn;
		}

		public void Add(string s)
		{
			pos=GetPos(pos+1);
			Buf.InsertString(pos,s);
			Buf.InsertObject(pos,-1);
			
			Buf.InsertString(GetPos(pos+1),"");
		}

		int GetPos(int p)
		{
			while(p<0)
				p=p+Capacity;
			while(p>=Capacity)
				p=p-Capacity;
			return p;
		}

		public bool CanUndo()
		{
			return (Buf.GetObject(GetPos(pos-1))!=null);
		}

		public bool CanRedo()
		{
			return (Buf.GetObject(GetPos(pos+1))!=null);
		}
		#endregion

		#region constructor
		public Undo(int UndoLimit)
		{
			Buf=new StringList("Undo.Buf");
			pos=0;
			Capacity=UndoLimit;
			for(int i=0;i<Capacity;i++)
				Buf.AddObject("",null);
		}
		#endregion	
	}
	#endregion
}
