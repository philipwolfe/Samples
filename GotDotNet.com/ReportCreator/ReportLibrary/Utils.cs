using System;
using System.Collections;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;

namespace Windows.Forms.Reports.ReportLibrary
{
	#region List
	public class List:ArrayList
	{
		#region class variables
		public string Desc;
		public static ArrayList ListList=new ArrayList();
		#endregion

		#region constructor
		public List(string ADesc)
		{
			Desc=ADesc;
			ListList.Add(this);
		}
		#endregion

		#region class methods
		public void Move(int CurIndex,int NewIndex)
		{
			object o1=this[CurIndex];
			object o2=this[NewIndex];
			RemoveAt(NewIndex);
			Insert(NewIndex,o1);
			RemoveAt(CurIndex);
			Insert(CurIndex,o2);
		}
		#endregion
	}
	#endregion

	#region StringList
	public class StringList
	{
		#region class variables
		public string Desc;
		EventHandler[] evnt=new EventHandler[1];
		ArrayList FStringList;
		ArrayList FObjectList;
		public bool FSorted;
		public bool FDuplicate;
		#endregion

		#region class events
		public event EventHandler Change
		{
			add
			{
				if(evnt[0]==null)
					evnt[0]=value;
			}
			remove
			{
				if(evnt[0]==value)
					evnt[0]=null;
			}
		}
		#endregion
		
		#region class properties
		public bool Duplicate
		{
			get
			{
				return FDuplicate;
			}
			set
			{
				FDuplicate=value;
				if(value==false)
				{
					IgnoreDuplicate();
					OnChange();
				}
			}
		}

		public bool Sorted
		{
			get
			{
				return FSorted;
			}
			set
			{
				FSorted=value;
				if(value==true)
				{
					Sort();
					OnChange();
				}
			}
		}
		#endregion

		#region class methods
		public string GetString(int index)
		{			
			return (string)FStringList[index];			
		}

		public void SetString(int index,string Value)
		{
			FStringList[index]=Value;
			FObjectList[index]=null;
		}

		public void InsertObject(int index,Object Value)
		{
			if(FObjectList.Count>0)
			{
				FObjectList.Insert(index,Value);
			}
			else
			{
				FObjectList.Add(Value);
			}
			
			if(Sorted==true)
				Sort();
			if(Duplicate==false)
				IgnoreDuplicate();
			OnChange();
		}

		public void InsertString(int index,string Value)
		{
			if(FStringList.Count>0)
			{
				FStringList.Insert(index,Value);
				FObjectList.Insert(index,null);
			}
			else
			{
				FStringList.Insert(0,Value);
				FObjectList.Insert(0,null);
			}
			
			if(Sorted==true)
				Sort();
			if(Duplicate==false)
				IgnoreDuplicate();
			OnChange();
		}

		public void AddRange(string[] Value)
		{
			for(int i=0;i<Value.Length;i++)
			{
				FStringList.Add(Value[i]);
				FObjectList.Add(null);
			}
			OnChange();
		}

		public Object GetObject(int index)
		{
			try
			{
				return FObjectList[index];
			}
			catch
			{
				return null;
			}
		}

		void Sort()
		{
			string[] sa=(string[])FStringList.ToArray(typeof(string));
			Object[] Ob=(Object[])FObjectList.ToArray(typeof(Object));
			FObjectList.Clear();
			FStringList.Sort();
			for(int i=0;i<sa.Length;i++)
			{
				for(int y=0;y<FStringList.Count;y++)
				{
					if((string)FStringList[i]==sa[y])
						FObjectList.Add(Ob[y]);
				}
			}
		}

		public void AddObject(string s,Object O)
		{
			FStringList.Add(s);
			FObjectList.Add(O);
			if(Sorted==true)
				Sort();
			if(Duplicate==false)
				IgnoreDuplicate();
			OnChange();
		}

		public void AddObjectNoChange(string s,Object O)
		{
			FStringList.Add(s);
			FObjectList.Add(O);
		}

		public void Add(string s)
		{
			AddObject(s,null);
		}

		public void AddStrings(StringList st)
		{			
			FStringList.AddRange(st.FStringList);
			FObjectList.AddRange(st.FObjectList);
			
			if(Sorted==true)
				Sort();
			if(Duplicate==false)
				IgnoreDuplicate();
			OnChange();
		}

		public void AddStringsNoChange(StringList st)
		{
			FStringList.AddRange(st.FStringList);
			FObjectList.AddRange(st.FObjectList);
		}

		public void Clear()
		{
			FStringList.Clear();
			FObjectList.Clear();
			OnChange();
		}

		public void RemoveAt(int index)
		{
			FStringList.RemoveAt(index);
			FObjectList.RemoveAt(index);
			if(Sorted==true)
				Sort();
			if(Duplicate==false)
				IgnoreDuplicate();
			OnChange();
		}

		public int IndexOf(string Value)
		{
			int freturn=FStringList.IndexOf(Value);
			return freturn;
		}

		public int Count
		{
			get
			{
				return FStringList.Count;
			}
		}

		public void IgnoreDuplicate()
		{
			for(int i=0;i<FStringList.Count;i++)
			{
				for(int y=i+1;y<FStringList.Count;y++)
				{
					if((string)FStringList[i]==(string)FStringList[y])
					{
						FStringList.RemoveAt(i);
						FObjectList.RemoveAt(i);						
					}
				}
			}
		}

		public string GetCommaText()
		{
			string[] sa=(string[])FStringList.ToArray(typeof(string));
			StringWriter sw=new StringWriter();
			for(int i=0;i<sa.Length;i++)
			{
				if(i!=0)
					sw.Write("\\,"+sa[i]);
				else
					sw.Write(sa[i]);
			}
			StringReader sr=new StringReader(sw.ToString());
			string s=sr.ReadToEnd();
			return s;
		}

		public void SetCommaText(string Value)
		{
			FStringList.Clear();
			int p=Value.IndexOf("\\,");
			
			if(p==-1)
			{
				FStringList.Add(Value);
				FObjectList.Add(null);
			}
			else
			{
				string t=Value.Substring(0,p);
				string r=Value.Substring(p+2,Value.Length-p-2);
				while(p!=-1)
				{
					FStringList.Add(t);
					FObjectList.Add(null);
					p=r.IndexOf("\\,");
					if(p==-1)
					{
						FStringList.Add(r);
						FObjectList.Add(null);
						return;
					}
					t=r.Substring(0,p);
					r=r.Substring(p+2,r.Length-p-2);
				}
			}
			OnChange();
		}

		public string GetText()
		{			
			string[] sa=(string[])FStringList.ToArray(typeof(string));
			int y=sa.Length;
			StringWriter sw=new StringWriter();
			for(int i=0;i<y;i++)
			{
				sw.WriteLine(sa[i]);
			}
			StringReader sr=new StringReader(sw.ToString());
			string s=sr.ReadToEnd();
			return s;
		}

		public void SetText(string Value)
		{
			FStringList.Clear();
			int i=0;
			int y=0;
			if(Value=="")
			{
				Value=Value+"\r\n";
			}

			if(Value[Value.Length-1]!='\n')
				Value=Value+"\r\n";

			while(y<Value.Length)
			{
				y=Value.IndexOf("\r\n",i);
				if(y!=-1)
				{
					FStringList.Add(Value.Substring(i,y-i));
					FObjectList.Add(null);
					i=y+2;
				}
				if(i>=Value.Length)
					break;
			}
			OnChange();
		}

		public void LoadFromFile(string AFileName)
		{
			string s;
			Clear();
			StreamReader sr=new StreamReader((Stream)File.OpenRead(AFileName));
			sr.BaseStream.Seek(0,SeekOrigin.Begin);
			while(sr.Peek()>-1)
			{
				s=sr.ReadLine();
				Add(s);
			}
			sr.Close();
		}

		public void LoadFromStream(FileStream AStream)
		{
			string s;
			StreamReader sr=new StreamReader(AStream);
			sr.BaseStream.Seek(0,SeekOrigin.Begin);
			while(sr.Peek()>-1)
			{
				s=sr.ReadLine();
				FStringList.Add(s);
				FObjectList.Add(null);
			}
			sr.Close();
		}

		public void SaveToFile(string AFileName)
		{
			StreamWriter sw=new StreamWriter(AFileName);
			sw.Write("<?xml version='1.0'?>\r\n");
			sw.Write(GetText());
			sw.Flush();
			sw.Close();
		}

		public void SaveToStream(FileStream Astream)
		{
			StreamWriter sw=new StreamWriter(Astream);
			sw.Write("<?xml version='1.0'?>\r\n");
			sw.Write(GetText());
			sw.Flush();
			sw.Close();
		}

		public int IndexOfObject(object Value)
		{
			int freturn=FObjectList.IndexOf(Value);
			return freturn;
		}

		public string[] ToStrings()
		{
			string[] sa=(string[])FStringList.ToArray(typeof(string));
			return sa;
		}

		public void SetStrings(string[] Value)
		{
			Clear();
			for(int i=0;i<Value.Length;i++)
			{
				Add(Value[i]);
			}
			OnChange();
		}

		public void SetValue(string Name,string Value)
		{
			int i=IndexOfName(Name);
			if(Value!="")
			{
				if(i<0)
				{
					i=Count;
					Add("");
				}
				Put(i,Name+"="+Value);
			}
			else if(i>=0)
				RemoveAt(i);
		}

		public void Put(int index,string S)
		{
			Object TempObject;
			TempObject=GetObject(index);
			RemoveAt(index);
			InsertAll(index,S,TempObject);
		}

		public int IndexOfName(string Name)
		{
			int P;
			string S;
			for(int i=0;i<Count;i++)
			{
				S=GetString(i);
				P=S.IndexOf("=");
				if((P!=-1)&&(string.Compare(S.Substring(0,P),Name)==0))
					return i;
			}
			return -1;
		}

		public void InsertAll(int index,string S,Object Value)
		{
			if(FObjectList.Count>0)
			{
				FObjectList.Insert(index,Value);
				FStringList.Insert(index,S);
			}
			else
			{
				FObjectList.Insert(0,Value);
				FStringList.Insert(0,S);
			}
			
			if(Sorted==true)
				Sort();
			if(Duplicate==false)
				IgnoreDuplicate();
			OnChange();
		}

		public string GetValue(string Name)
		{
			int i=IndexOfName(Name);
			if(i!=-1)
			{
				string s=GetString(i);
				int p=s.IndexOf("=");
				return s.Substring(p+1);
			}
			else
				return "";
		}

		public void OnChange()
		{
			if(evnt[0]!=null)
				evnt[0](this,EventArgs.Empty);
		}
		#endregion

		#region constructor
		public StringList(string ADesc)
		{
			Desc=ADesc;
			Generic.ListStringList.Add(this);
			FStringList=new ArrayList();
			FObjectList=new ArrayList();
			FSorted=false;
			FDuplicate=true;
		}
		#endregion	
	}
	#endregion
}
