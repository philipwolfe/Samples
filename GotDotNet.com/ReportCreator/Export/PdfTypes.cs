using System;
using System.Reflection;
using System.Collections;
using System.Text;
using System.IO;
using Windows.Forms.Reports.ReportLibrary;

namespace Windows.Forms.Reports.Export
{
	#region ApplicationException
	public class EPdfInvalidOperation:ApplicationException
	{
		public EPdfInvalidOperation(string Message)
			:base(Message)
		{
		}
	}

	public class EPdfInvalidValue:ApplicationException
	{
		public EPdfInvalidValue(string Message)
			:base(Message)
		{
		}
	}
	#endregion

	#region enums
	public enum PdfAlignment
	{
		LeftJustify,RightJustify,Center
	}

	public enum PdfObjectType
	{
		DirectObject, IndirectObject, VirtualObject
	}
	#endregion

	#region PdfDictionary
	public class PdfDictionary:PdfObject
	{
		#region class variables
		ArrayList FArray;
		PdfObjectMgr FObjectMgr;
		#endregion

		#region constructor
		public PdfDictionary(PdfObjectMgr AObjectMgr)
		{
			FArray=new ArrayList();
			FObjectMgr=AObjectMgr;
		}
		#endregion

		#region class methods
		public PdfBoolean PdfBooleanByName(string AKey)
		{
			return (PdfBoolean)ValueByName(AKey);
		}

		public void AddInternalItem(string AKey,PdfObject AValue)
		{
			PdfDictionaryElement FItem;
			PdfVirtualObject FTmpObject;

			RemoveItem(AKey);
			if(AValue.ObjectType==PdfObjectType.DirectObject)
			{
				FItem=new PdfDictionaryElement(AKey,AValue);
				FItem=FItem.CreateAsInternal(AKey,AValue);
			}
			else
			{
				FTmpObject=new PdfVirtualObject(AValue.ObjectNumber);
				FItem=new PdfDictionaryElement(AKey,AValue);
				FItem=FItem.CreateAsInternal(AKey,AValue);
			}
			FArray.Add(FItem);
		}

		public PdfReal PdfRealByName(string AKey)
		{
			return (PdfReal)ValueByName(AKey);
		}

		public PdfDictionary PdfDictionaryByName(string AKey)
		{
			return (PdfDictionary)ValueByName(AKey);
		}

		protected override void InternalWriteStream(MemoryStream AStream)
		{
			PdfDictionaryElement FElement;

			Generic.WriteString("<<"+"\r\n",AStream);
			for(int i=0;i<FArray.Count;i++)
			{
				FElement=this[i];
				if(!FElement.IsInternal)
				{
					FElement.FKey.WriteToStream(AStream);
					Generic.WriteString(" ",AStream);
					FElement.FValue.WriteToStream(AStream);
					Generic.WriteString("\r\n",AStream);
				}
			}
			Generic.WriteString(">>",AStream);
		}

		public PdfObject ValueByName(string AKey)
		{
			int i;
			PdfDictionaryElement FElement;

			for(i=0;i<FArray.Count;i++)
			{
				FElement=this[i];
				if(FElement.Key==AKey)
				{
					if(FElement.Value.ObjectType==PdfObjectType.VirtualObject)
					{
						if(FObjectMgr!=null)
							return FObjectMgr.GetObject(FElement.Value.ObjectNumber);
						else
							return null;
					}
					return FElement.Value;
				}				
			}
			return null;
		}

		public PdfText PdfTextByName(string AKey)
		{
			return (PdfText)ValueByName(AKey);
		}

		public PdfName PdfNameByName(string AKey)
		{
			return (PdfName)ValueByName(AKey);
		}

		public PdfArray PdfArrayByName(string AKey)
		{
			return (PdfArray)ValueByName(AKey);
		}

		public PdfNumber PdfNumberByName(string AKey)
		{
			return (PdfNumber)ValueByName(AKey);
		}

		public void AddItem(string AKey,PdfObject AValue)
		{
			PdfDictionaryElement FItem;
			PdfVirtualObject FTmpObject;
			RemoveItem(AKey);			
			if(AValue.ObjectType==PdfObjectType.DirectObject)
				FItem=new PdfDictionaryElement(AKey,AValue);
			else
			{
				FTmpObject=new PdfVirtualObject(AValue.ObjectNumber);
				FItem=new PdfDictionaryElement(AKey,FTmpObject);
			}
			FArray.Add(FItem);			
		}

		public void RemoveItem(String AKey)
		{
			int i;
			PdfDictionaryElement FElement;
			for(i=0;i<FArray.Count;i++)
			{
				FElement=this[i];
				if(FElement.Key==AKey)
				{
					FArray.Remove(FElement);
					break;
				}
			}
		}
		#endregion

		#region class properties
		public PdfObjectMgr ObjectMgr
		{
			get
			{
				return FObjectMgr;
			}
		}

		public PdfDictionaryElement this[int index]
		{
			get
			{
				return  (PdfDictionaryElement)FArray[index];
			}
		}
		#endregion	
	}
	#endregion

	#region PdfObject
	public class PdfObject
	{
		#region class variables
		int FGenerationNumber;
		public PdfObjectType FObjectType;
		public int FObjectNumber;
		#endregion

		#region class properties
		public int ObjectNumber
		{
			get
			{
				return FObjectNumber;
			}
		}

		public int GenerationNumber
		{
			get 
			{
				return FGenerationNumber;
			}
		}

		public PdfObjectType ObjectType
		{
			get
			{
				return FObjectType;
			}
		}
		#endregion

		#region constructor
		public PdfObject()
		{
			FObjectNumber=-1;
			FGenerationNumber=0;
		}
		#endregion

		#region class methods
		public void SetObjectNumber(int Value)
		{
			FObjectNumber=Value;
			if (Value>0)
				FObjectType=PdfObjectType.IndirectObject;
			else
				FObjectType=PdfObjectType.DirectObject;
		}

		public void WriteValueToStream(MemoryStream AStream)
		{
			string S;

			if(FObjectType!=PdfObjectType.IndirectObject)
				throw (new EPdfInvalidOperation("internal error wrong object type"));
			S=FObjectNumber.ToString()+" "+FGenerationNumber.ToString()+
				" obj"+"\r\n";
			Generic.WriteString(S,AStream);
			InternalWriteStream(AStream);
			S="\r\n"+"endobj"+"\r\n";
			Generic.WriteString(S,AStream);
		}

		protected virtual void InternalWriteStream(MemoryStream AStream)
		{
		}

		public void WriteToStream(MemoryStream AStream)
		{
			string S;

			if(FObjectType==PdfObjectType.DirectObject)
				InternalWriteStream(AStream);
			else
			{
				S=FObjectNumber.ToString()+" "+
					FGenerationNumber.ToString()+" R";
				Generic.WriteString(S,AStream);
			}
		}
		#endregion
	}
	#endregion

	#region PdfStream
	public class PdfStream:PdfObject
	{
		#region class variables
		PdfDictionary FAttributes;
		MemoryStream FStream;
		#endregion

		#region constructor
		public PdfStream(PdfObjectMgr AObjectMgr)
		{
			FAttributes=new PdfDictionary(AObjectMgr);
			FAttributes.AddItem("Length",new PdfNumber());
			FAttributes.AddItem("Filter",new PdfArray(AObjectMgr));
			FStream=new MemoryStream();
		}
		#endregion

		#region class properties
		public PdfDictionary Attributes
		{
			get
			{
				return FAttributes;
			}
		}

		public MemoryStream Stream
		{
			get
			{
				return FStream;
			}
		}
		#endregion

		#region class methods
		protected override void InternalWriteStream(MemoryStream AStream)
		{
			PdfNumber FLength;
			PdfArray FFilter;
			MemoryStream TmpStream;

			FLength=FAttributes.PdfNumberByName("Length");
			FFilter=(PdfArray)FAttributes.ValueByName("Filter");

			TmpStream=new MemoryStream();
			DeflaterOutputStream s=null;
			if(FFilter.FindName("FlateDecode")!=null)
			{
				s=new DeflaterOutputStream(TmpStream);
				byte[] bytedata=FStream.ToArray();
				s.Write(bytedata,0,bytedata.Length);
				s.Finish();
			}
			else
			{
				FStream.WriteTo(TmpStream);
			}
			
			FLength.Value=TmpStream.Length;
			FAttributes.WriteToStream(AStream);
			Generic.WriteString("\r\n"+"stream"+"\r\n",AStream);
			
			TmpStream.WriteTo(AStream);
			if(s!=null)
				s.Close();
			Generic.WriteString("\n"+"endstream",AStream);
		}
		#endregion	
	}
	#endregion

	#region PdfObjectMgr
	public abstract class PdfObjectMgr
	{
		public abstract void AddObject(PdfObject AObject);
		public abstract PdfObject GetObject(int ObjectId);
	}
	#endregion

	#region PdfDictionaryElement
	public class PdfDictionaryElement
	{
		#region class variables
		public PdfName FKey;
		public PdfObject FValue;
		bool FIsInternal;
		#endregion

		#region class properties
		public bool IsInternal
		{
			get
			{
				return FIsInternal;
			}
		}

		public PdfObject Value
		{
			get
			{
				return FValue;
			}
		}

		public string Key
		{
			get
			{
				return FKey.Value;
			}
		}
		#endregion

		#region constructor
		public PdfDictionaryElement(string AKey,PdfObject AValue)
		{
			FKey=new PdfName();
			FKey.Value=AKey;
			FValue=AValue;
			FIsInternal=false;
		}
		#endregion

		#region class methods
		public PdfDictionaryElement CreateAsInternal(string AKey,PdfObject AValue)
		{
			PdfDictionaryElement pe=new PdfDictionaryElement(AKey,AValue);
			FIsInternal=true;
			return pe;
		}
		#endregion
	}
	#endregion

	#region PdfVirtualObject
	public class PdfVirtualObject:PdfObject
	{
		#region constructor
		public PdfVirtualObject(int AObjectID)
		{
			FObjectNumber=AObjectID;
			FObjectType=PdfObjectType.VirtualObject;
		}
		#endregion
	}
	#endregion

	#region PdfName
	public class PdfName:PdfObject
	{
		#region class variables
		string FValue;
		#endregion

		#region class properties
		public string Value
		{
			get
			{
				return FValue;
			}
			set
			{
				FValue=value;
			}
		}
		#endregion

		#region constructor
		public PdfName()
		{
		}

		public PdfName(string AValue)
		{
			Value=AValue;
		}
		#endregion

		#region class methods
		protected override void InternalWriteStream(MemoryStream AStream)
		{
			string S;
			S="/"+EscapeName(FValue);
			Generic.WriteString(S,AStream);
		}

		private string EscapeName(string s)
		{
			string Value="";
			char[] EscapeChars=new char[11]
			{
				'%','(',')','<','>','[',']','{','}','/','#'
			};
			for(int i=0;i<s.Length;i++)
			{
				if(Array.IndexOf(EscapeChars,s[i])!=-1|33>Convert.ToInt32(s[i])|126<Convert.ToInt32(s[i]))
				{
					if (s[i] <= '\u0010')
					{
						Value= Value+"#0"+ string.Format("{0:X}", (byte) (s[i]));
					}
					else
					{
						Value= Value+'#'+ string.Format("{0:X}", (byte) (s[i]));
					} 
				}
				else 
					Value=Value+s[i];
			
			}
			return Value;
		}
		#endregion
	}
	#endregion

	#region PdfNumber
	public class PdfNumber:PdfObject
	{
		#region class variables
		long FValue;
		#endregion

		#region constructor
		public PdfNumber(long AValue)
		{
			Value=AValue;
		}

		public PdfNumber()
		{
		}
		#endregion

		#region class properties
		public long Value
		{
			get
			{
				return FValue;
			}
			set
			{
				FValue=value;
			}
		}
		#endregion

		#region class methods
		protected override void InternalWriteStream(MemoryStream AStream)
		{
			Generic.WriteString(FValue.ToString(),AStream);
		}
		#endregion
	}
	#endregion

	#region PdfArray
	public class PdfArray:PdfObject
	{
		#region class variables
		ArrayList FArray;
		PdfObjectMgr FObjectMgr;
		#endregion

		#region constructor
		public PdfArray(PdfObjectMgr AObjectMgr,int[]AArray)
		{
			FArray=new ArrayList();
			FObjectMgr=AObjectMgr;
			for(int i=0;i<AArray.Length;i++)
				AddItem(new PdfNumber(AArray[i]));
		}

		public PdfArray(PdfObjectMgr AObjectMgr)
		{
			FArray=new ArrayList();
			FObjectMgr=AObjectMgr;
		}
		#endregion

		#region class methods
		public PdfName FindName(string AName)
		{
			PdfName Freturn;
			Freturn=null;
			for(int i=0;i<ItemCount;i++)
			{
				if(this[i] is PdfName)
				{
					if(((PdfName)this[i]!=null)&&(((PdfName)this[i]).Value==AName))
					{
						Freturn=(PdfName)this[i];
						return Freturn;
					}
				}
			}
			return Freturn;
		}

		protected override void InternalWriteStream(MemoryStream AStream)
		{
			PdfObject Fobject;
			Generic.WriteString("[",AStream);
			for(int i=0;i<FArray.Count;i++)
			{
				Fobject=(PdfObject)FArray[i];
				Fobject.WriteToStream(AStream);
				Generic.WriteString(" ",AStream);
			}
			Generic.WriteString("]",AStream);
		}

		public void AddItem(PdfObject AItem)
		{
			PdfVirtualObject TmpObject;

			if(FArray.IndexOf(AItem)>=0)
				return;
			if(AItem.ObjectType==PdfObjectType.DirectObject)
				FArray.Add(AItem);
			else
			{
				TmpObject=new PdfVirtualObject(AItem.ObjectNumber);
				FArray.Add(TmpObject);
			}
		}
		#endregion

		#region class properties
		public PdfObject this[int index]
		{
			get
			{
				PdfObject FObject;
				FObject=(PdfObject)FArray[index];
				if(FObject.ObjectType==PdfObjectType.VirtualObject)
				{
					if(FObjectMgr!=null)
						return FObjectMgr.GetObject(FObject.ObjectNumber);
					else
						return null;
				}
				else return FObject;
			}
		}

		public int ItemCount
		{
			get
			{
				return FArray.Count;
			}
		}
		#endregion	
	}
	#endregion

	#region PdfText
	public class PdfText:PdfObject
	{
		#region class variables
		string FValue;
		#endregion

		#region constructor
		public PdfText(string AValue)
		{
			Value=AValue;
		}
		#endregion

		#region class properties
		public string Value
		{
			get
			{
				return FValue;
			}
			set
			{
				FValue=value;
			}
		}
		#endregion
	
		#region class methods
		protected override void InternalWriteStream(MemoryStream AStream)
		{
			string S;
			S="("+Generic.EscapeText(FValue)+")";
			Generic.WriteString(S,AStream);
		}
		#endregion
	}
	#endregion

	#region PdfBoolean
	public class PdfBoolean:PdfObject
	{
		#region class variables
		bool FValue;
		#endregion

		#region class properties
		public bool Value
		{
			get
			{
				return FValue;
			}
			set
			{
				FValue=value;
			}
		}
		#endregion

		#region class methods
		protected override void InternalWriteStream(MemoryStream AStream)
		{
			if(Value)
				Generic.WriteString("true",AStream);
			else
				Generic.WriteString("false",AStream);
		}
		#endregion

		#region constructor
		public PdfBoolean(bool AValue)
		{
			Value=AValue;
		}
		#endregion
	}
	#endregion

	#region PdfReal
	public class PdfReal:PdfObject
	{
		#region class variables
		double FValue;
		#endregion

		#region constructor
		public PdfReal(double AValue)
		{
			Value=AValue;
		}
		#endregion

		#region class properties
		public double Value
		{
			get
			{
				return FValue;
			}
			set
			{
				FValue=value;
			}
		}
		#endregion

		#region class methods
		protected override void InternalWriteStream(MemoryStream AStream)
		{
			string s=FValue.ToString().Replace(',','.');
			Generic.WriteString(s,AStream);
		}
		#endregion
	}
	#endregion

	#region PdfNull
	public class PdfNull:PdfObject
	{
		protected override void InternalWriteStream(MemoryStream AStream)
		{
			Generic.WriteString("null",AStream);
		}
	}
	#endregion

	#region PdfRect
	public class PdfRect
	{
		public float Left,Right,Top,Bottom;
	}
	#endregion

	#region PdfXObject
	public class PdfXObject:PdfStream
	{
		public PdfXObject(PdfObjectMgr AObjectMgr):base(AObjectMgr)
		{
		}
	}
	#endregion

	#region PdfImage
	public class PdfImage:PdfXObject
	{
		public PdfImage(PdfObjectMgr AObjectMgr):base(AObjectMgr)
		{
		}	
	}
	#endregion

	#region PdfBinary
	public class PdfBinary:PdfObject
	{
		#region class variables
		MemoryStream FStream;
		#endregion
		
		#region class properties
		public MemoryStream Stream
		{
			get
			{
				return FStream;
			}
		}
		#endregion

		#region constructor
		public PdfBinary()
		{
			FStream=new MemoryStream();
		}
		#endregion

		#region class methods
		protected override void InternalWriteStream(MemoryStream AStream)
		{
			FStream.WriteTo(AStream);
		}
		#endregion
	}
	#endregion
}
