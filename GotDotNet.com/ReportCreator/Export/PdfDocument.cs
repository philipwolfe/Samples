using System;
using System.ComponentModel;
using System.Collections;
using System.Text;
using System.Drawing;
using System.IO;

namespace Windows.Forms.Reports.Export
{
	#region PdfDoc
	public class PdfDoc
	{
		#region class variables
		bool FHasDoc;
		PdfCanvas FCanvas;
		short FDefaultPageWidth;
		short FDefaultPageHeight;
		PdfInfo FInfo;
		PdfCatalog FRoot;
		bool FUseOutlines;
		PdfOutlineRoot FOutlineRoot; 
		public PdfXRef FXRef;
		PdfHeader FHeader;
		PdfTrailer FTrailer;
		ArrayList FFontList;
		PdfArray FXObjectList;
		public ArrayList FObjectList;
		PdfDictionary FCurrentPages;
		#endregion

		#region constructor
		public PdfDoc()
		{
			FHasDoc=false;
			FCanvas=new PdfCanvas(this);
			FDefaultPageWidth=Generic.PDF_DEFAULT_PAGE_WIDTH;
			FDefaultPageHeight=Generic.PDF_DEFAULT_PAGE_HEIGHT;
			FInfo=null;
			FRoot=null;
		}
		#endregion

		#region class properties
		public PdfCanvas Canvas
		{
			get
			{
				if(!HasDoc)
					throw (new EPdfInvalidOperation("GetCanvas --Document is null"));
				return FCanvas;
			}
		}

		public short DefaultPageWidth
		{
			get
			{
				return FDefaultPageWidth;
			}
			set
			{
				FDefaultPageWidth=value;
			}
		}

		public short DefaultPageHeight
		{
			get
			{
				return FDefaultPageHeight;
			}
			set
			{
				FDefaultPageHeight=value;
			}
		}

		public PdfOutlineRoot OutlineRoot
		{
			get
			{
				if(!HasDoc)
					throw(new EPdfInvalidOperation("GetOutlineRoot --document is null.."));
				if(!UseOutlines)
					throw(new EPdfInvalidOperation("'GetOutlineRoot --not use outline mode.."));
				return FOutlineRoot;
			}
		}

		public bool HasDoc
		{
			get
			{
				return FHasDoc;
			}
		}

		public PdfCatalog Root
		{
			get
			{
				if(!HasDoc)
					throw (new EPdfInvalidOperation("GetRoot --this method can not use this state.."));
				return FRoot;
			}
		}

		public PdfInfo Info
		{
			get
			{
				if(!HasDoc)
					throw (new EPdfInvalidOperation("GetInfo --this method can not use this state.."));
				if(FInfo==null)
					CreateInfo();
				return FInfo;
			}
		}

		public bool UseOutlines
		{
			get{return FUseOutlines;}
			set{FUseOutlines=value;}
		}
		#endregion

		#region class methods
		public void SaveToStream(MemoryStream AStream)
		{
			PdfNumber pdfnumber;

			if((!HasDoc)||(FCanvas.Page==null))
				throw (new EPdfInvalidOperation("SaveToStream --there is no document to save."));

			FInfo.ModDate=DateTime.Now;
			FRoot.SaveOpenAction();

			if(UseOutlines)
				FOutlineRoot.Save();

			FHeader.WriteToStream(AStream);			
			for(int i=1;i<FXRef.ItemCount;i++)
			{
				FXRef[i].ByteOffset=AStream.Length;				
				FXRef[i].Value.WriteValueToStream(AStream);				
				FTrailer.XRefAddress=AStream.Length;
			}			
			FXRef.WriteToStream(AStream);
			pdfnumber=FTrailer.Attributes.PdfNumberByName("Size");
			pdfnumber.Value=FXRef.ItemCount;
			FTrailer.WriteToStream(AStream);
		}

		public void SetVirtualMode()
		{
			NewDoc();
			AddPage();
			FCanvas.FIsVirtual=true;
		}

		public PdfDestination CreateDestination()
		{
			PdfDestination fdest;
			fdest=new PdfDestination(this);
			FObjectList.Add(fdest);
			return fdest;
		}

		public PdfXObject GetXObject(string AName)
		{
			PdfXObject FXObject;
			PdfXObject Freturn;
			PdfName Fname;

			Freturn=null;
			for(int i=0;i<FXObjectList.ItemCount;i++)
			{
				FXObject=(PdfXObject)FXObjectList[i];
				Fname=(PdfName)FXObject.Attributes.ValueByName("Name");
				if(Fname.Value==AName)
				{
					Freturn=FXObject;
					break;
				}
			}
			return Freturn;
		}

		public void AddXObject(string AName,PdfXObject AXObject)
		{
			if(GetXObject(AName)!=null)
				throw (new Exception(string.Format("AddImage --the image named {0} is already exists..",AName)));
			if((AXObject==null)||(AXObject.Attributes==null)||
				(Generic.GetTypeOf(AXObject.Attributes)!="XObject")||
				(AXObject.Attributes.PdfNameByName("Subtype").Value!="Image"))
				throw(new Exception("AddImage --the image is not valid TPdfImage.."));
			FXRef.AddObject(AXObject);
			RegisterXobject(AXObject,AName);
		}

		public void RegisterXobject(PdfXObject AObject,string AName)
		{
			if(AObject==null)
				throw(new EPdfInvalidValue("RegisterXObject --AObject is null"));
			if(Generic.GetTypeOf(AObject.Attributes)!="XObject")
				throw(new EPdfInvalidValue("RegisterXObject --not XObject"));
			if(AObject.ObjectType!=PdfObjectType.IndirectObject)
				FXRef.AddObject(AObject);
			if(AObject.Attributes.ValueByName("Name")==null)
			{
				if(GetXObject(AName)!=null)
					throw(new EPdfInvalidValue(string.Format("RegisterXObject --duplicate name: {0}",AName)));
				FXObjectList.AddItem(AObject);
				AObject.Attributes.AddItem("Name",new PdfName(AName));
			}
		}

		public PdfDictionary CreateAnnotation(PdfAnnotationSubType AType,PdfRect ARect)
		{
			PdfDictionary FAnnotation;
			PdfArray FArray;
			PdfDictionary FPage;

			if(!HasDoc)
				throw new EPdfInvalidOperation("CreateAnnotation --document is null.");
			
			FAnnotation=new PdfDictionary(FXRef);
			FXRef.AddObject(FAnnotation);
			FAnnotation.AddItem("Type",new PdfName("Annot"));
			FAnnotation.AddItem("Subtype",new PdfName(Generic.PDF_ANNOTATION_TYPE_NAMES[(int)AType]));
			
			FArray=new PdfArray(null);
			FArray.AddItem(new PdfReal(ARect.Left));
			FArray.AddItem(new PdfReal(ARect.Top));
			FArray.AddItem(new PdfReal(ARect.Right));
			FArray.AddItem(new PdfReal(ARect.Bottom));

			FAnnotation.AddItem("Rect",FArray);

			FPage=FCanvas.Page;
			FArray=FPage.PdfArrayByName("Annots");
			if(FArray==null)
			{
				FArray=new PdfArray(null);
				FPage.AddItem("Annots",FArray);
			}
			FArray.AddItem(FAnnotation);
			return FAnnotation;
		}

		public PdfFont GetFont(string FontName)
		{
			PdfFont FFont;
			int i;

			if(!HasDoc)
				throw (new EPdfInvalidOperation("GetFont --document is null."));
			for(i=0;i<FFontList.Count;i++)
			{
				FFont=(PdfFont)FFontList[i];
				if(FFont.Name==FontName)
				{
					return FFont;
				}
			}
			return CreateFont(FontName);
		}

		protected PdfFont CreateFont(string FontName)
		{
			PdfFont pdffont;			
			if (!CheckClass(FontName))
				throw (new Exception("CreateFont --InvalidFontName:"+FontName));
			pdffont=FindClass(FontName);
			string s=FFontList.Count.ToString();
			pdffont.Data.AddItem("Name",new PdfName("F"+s));
			
			FFontList.Add(pdffont);
			return pdffont;
		}

		public bool CheckClass(string s)
		{		
			if((s=="Arial")|(s=="FixedWidth")|(s=="Times-Roman")|
				(s=="FixedWidth-Bold")|(s=="Arial-Bold")|(s=="Times-Bold")|
				(s=="FixedWidth-Italic")|(s=="Arial-Italic")|(s=="Times-Italic")|
				(s=="FixedWidth-BoldItalic")|(s=="Arial-BoldItalic")|(s=="Times-BoldItalic"))
				return true;			
			else 
				return false;
		}

		public PdfFont FindClass(string s)
		{
			if(s=="Arial")
				return new PdfArial(FXRef,s);
			if(s=="FixedWidth")
				return new PdfFixedWidth(FXRef,s);
			if(s=="Times-Roman")
				return new PdfTimesRoman(FXRef,s);
			if(s=="FixedWidth-Bold")
				return new PdfFixedWidthBold(FXRef,s);
			if(s=="Arial-Bold")
				return new PdfArialBold(FXRef,s);
			if(s=="Times-Bold")
				return new PdfTimesBold(FXRef,s);
			if(s=="FixedWidth-Italic")
				return new PdfFixedWidthItalic(FXRef,s);
			if(s=="Arial-Italic")
				return new PdfArialItalic(FXRef,s);
			if(s=="Times-Italic")
				return new PdfTimesItalic(FXRef,s);
			if(s=="FixedWidth-BoldItalic")
				return new PdfFixedWidthBoldItalic(FXRef,s);
			if(s=="Arial-BoldItalic")
				return new PdfArialBoldItalic(FXRef,s);
			if(s=="Times-BoldItalic")
				return new PdfTimesBoldItalic(FXRef,s);
			else return null;
		}

		public void AddPage()
		{
			PdfDictionary FPage;
			PdfArray FMediaBox;
			PdfStream FContents;
			PdfDictionary FResources;
			PdfArray FProcSet;
			PdfDictionary FFontArray;
			PdfDictionary FXObjectArray;
			PdfArray FFilter;

			if(FCurrentPages==null)
				throw (new EPdfInvalidOperation("AddPage --current pages null."));
			FPage=new PdfDictionary(FXRef);
			FXRef.AddObject(FPage);

			Generic.Pages_AddKids(FCurrentPages,FPage);

			FPage.AddItem("Type",new PdfName("Page"));
			FPage.AddItem("Parent",FCurrentPages);

			FMediaBox=new PdfArray(FXRef);
			FMediaBox.AddItem(new PdfNumber(0));
			FMediaBox.AddItem(new PdfNumber(0));
			FMediaBox.AddItem(new PdfNumber(DefaultPageWidth));
			FMediaBox.AddItem(new PdfNumber(DefaultPageHeight));
			FPage.AddItem("MediaBox",FMediaBox);

			FResources=new PdfDictionary(FXRef);
			FPage.AddItem("Resources",FResources);

			FFontArray=new PdfDictionary(FXRef);
			FResources.AddItem("Font",FFontArray);

			FXObjectArray=new PdfDictionary(FXRef);
			FResources.AddItem("XObject",FXObjectArray);

			FProcSet=new PdfArray(FXRef);
			FProcSet.AddItem(new PdfName("PDF"));
			FProcSet.AddItem(new PdfName("Text"));
			FProcSet.AddItem(new PdfName("ImageC"));
			FResources.AddItem("ProcSet",FProcSet);

			FContents=new PdfStream(FXRef);
			FXRef.AddObject(FContents);

			FFilter=FContents.Attributes.PdfArrayByName("Filter");
			FFilter.AddItem(new PdfName("FlateDecode"));

			FPage.AddItem("Contents",FContents);

			FCanvas.SetPage(FPage);
		}

		public void NewDoc()
		{
			FreeDoc();
			FXRef=new PdfXRef();
			FHeader=new PdfHeader();
			FTrailer=new PdfTrailer(FXRef);
			FFontList=new ArrayList();
			FXObjectList=new PdfArray(FXRef);
			FObjectList=new ArrayList();

			FRoot=new PdfCatalog();
			FRoot.Data=CreateCatalog();
			FObjectList.Add(FRoot);
			if (UseOutlines)
				CreateOutlines();

			CreateInfo();
			FInfo.CreationDate=DateTime.Now;
			
			FCurrentPages=CreatePages(null);
			FRoot.Pages=FCurrentPages;
			FHasDoc=true;
		}

		public void FreeDoc()
		{
			if(FHasDoc)
			{
				FInfo=null;
				FRoot=null;
				FOutlineRoot=null;
				FHasDoc=false;
			}
		}

		protected PdfDictionary CreateCatalog()
		{
			PdfDictionary FDictionary=new PdfDictionary(FXRef);
			FXRef.AddObject(FDictionary);
			FDictionary.AddItem("Type",new PdfName("Catalog"));
			FTrailer.Attributes.AddItem("Root",FDictionary);
			return FDictionary;
		}

		protected void CreateOutlines()
		{
			FOutlineRoot=new PdfOutlineRoot(this);
			FRoot.Data.AddItem("Outlines",FOutlineRoot.Data);
		}

		protected void CreateInfo()
		{
			PdfDictionary FInfoDictionary;
			FInfoDictionary=new PdfDictionary(FXRef);
			FXRef.AddObject(FInfoDictionary);
			FInfoDictionary.AddItem("Producer",new PdfText(Generic.PdfCreator_VERSION_TEXT));
			FTrailer.Attributes.AddItem("Info",FInfoDictionary);
			FInfo=new PdfInfo();
			FInfo.Data=FInfoDictionary;
			FObjectList.Add(FInfo);
		}

		protected PdfDictionary CreatePages(PdfDictionary Parent)
		{
			PdfDictionary ADictionary=new PdfDictionary(FXRef);
			FXRef.AddObject(ADictionary);
			ADictionary.AddItem("Type",new PdfName("Pages"));
			ADictionary.AddItem("Kids",new PdfArray(FXRef));
			ADictionary.AddItem("Count",new PdfNumber(0));

			if((Parent!=null)&&(Generic.GetTypeOf(Parent)=="Pages"))
				Generic.Pages_AddKids(Parent,ADictionary);
			else
				FRoot.Pages=ADictionary;
			return ADictionary;
		}
		#endregion	
	}
	#endregion

	#region enums
	public enum PdfAnnotationSubType
	{
		asTextNotes,asLink
	}

	public enum TextRenderingMode
	{
		Fill,Stroke,FillThenStroke,Invisible,FillClipping,
		StrokeClipping,FillStrokeClipping,Clipping
	}
	#endregion

	#region PdfCanvas
	public class PdfCanvas
	{
		#region class variables
		PdfDoc FPdfDoc;
		PdfDictionary FPage;
        PdfStream FContents;
		PdfCanvasAttribute FAttr;
		public bool FIsVirtual;
		#endregion

		#region constructor
		public PdfCanvas(PdfDoc APdfDoc)
		{
			FPdfDoc=APdfDoc;
			FPage=null;
			FContents=null;
			FAttr=new PdfCanvasAttribute();
			FIsVirtual=false;
		}
		#endregion

		#region class methods
		public void DrawXObject(float X,float Y,float AWidth,float AHeight,string AXObjectName)
		{
			PdfXObject Xobject;
			PdfDictionary FXObjectList;

			Xobject=FPdfDoc.GetXObject(AXObjectName);
			if(Xobject==null)
				throw(new EPdfInvalidValue(string.Format("DrawXObject --XObject not found: {s}",AXObjectName)));
			FXObjectList=Generic.Page_GetResources(FPage,"XObject");
			if(FXObjectList.ValueByName(AXObjectName)==null)
				FXObjectList.AddItem(AXObjectName,Xobject);
			GSave();
			Concat(AWidth,0,0,AHeight,X,Y);
			ExecuteXObject(Xobject.Attributes.PdfNameByName("Name").Value);
			GRestore();
		}

		public void Concat(float a,float b,float c,float d,float e,float f)
		{
			string S;
			S=Generic.FloatToStrR(a)+" "+
				Generic.FloatToStrR(b)+" "+
				Generic.FloatToStrR(c)+" "+
				Generic.FloatToStrR(d)+" "+
				Generic.FloatToStrR(e)+" "+
				Generic.FloatToStrR(f)+" cm"+(char)10;
			WriteString(S);
		}

		public void ExecuteXObject(string XObject)
		{
			string S;
			S="/"+XObject+" Do"+(char)10;
			WriteString(S);
		}

		public void DrawXObjectEx(float X,float Y,float AWidth,float AHeight,
			float ClipX,float ClipY,float ClipWidth,float ClipHeight,
			string AXObjectName)
		{
			PdfXObject XObject;
			PdfDictionary FXObjectList;

			XObject=FPdfDoc.GetXObject(AXObjectName);
			if(XObject==null)
				throw(new EPdfInvalidValue(string.Format("DrawXObjectEx --XObject not found: {s}",AXObjectName)));
			FXObjectList=Generic.Page_GetResources(FPage,"XObject");
			if(FXObjectList.ValueByName(AXObjectName)==null)
				FXObjectList.AddItem(AXObjectName,XObject);

			GSave();
			Rect(ClipX,ClipY,ClipWidth,ClipHeight);
			Clip();
			NewPath();
			Concat(AWidth,0,0,AHeight,X,Y);
			ExecuteXObject(XObject.Attributes.PdfNameByName("Name").Value);
			GRestore();
		}

		public void Rect(float X,float Y,float Width,float Height)
		{
			string S;
			S=Generic.FloatToStrR(X)+" "+
				Generic.FloatToStrR(Y)+" "+
				Generic.FloatToStrR(Width)+" "+
				Generic.FloatToStrR(Height)+" re"+(char)10;
			WriteString(S);
		}

		public void SetHorizantalScaling(short hScaling)
		{
			if(FAttr.HorizantalScaling==hScaling)
				return;
			FAttr.HorizantalScaling=hScaling;
			WriteString(hScaling.ToString()+" Tz"+(char)10);
		}

		public void SetTextRenderingMode(TextRenderingMode mode)
		{
			int i=(int)mode;
			WriteString(i.ToString()+" Tr"+(char)10);
		}

		public void SetTextRise(short rise)
		{
			WriteString(rise.ToString()+" Ts"+(char)10);
		}

		public void TextOut(float X,float Y,string Text)
		{
			BeginText();
			MoveTextPoint(X,Y);
			ShowText(Text);
			EndText();
		}

		public void TextRect(PdfRect ARect,string Text,PdfAlignment Alignment,bool Clipping)
		{
			double TmpWidth;
			double XPos=0;
			
			TmpWidth=TextWidth(Text);
			switch(Alignment)
			{
				case PdfAlignment.Center:
					XPos=Math.Round((ARect.Right-ARect.Left-TmpWidth)/2);
					break;
				case PdfAlignment.RightJustify:
					XPos=ARect.Right-ARect.Left-Math.Round(TmpWidth);
					break;
				case PdfAlignment.LeftJustify:
					XPos=0;
					break;
			}
			if(Clipping)
			{
				GSave();
				MoveTo(ARect.Left,ARect.Top);
				LineTo(ARect.Left,ARect.Bottom);
				LineTo(ARect.Right,ARect.Bottom);
				LineTo(ARect.Right,ARect.Top);
				ClosePath();
				Clip();
				NewPath();
			}
			BeginText();
			MoveTextPoint(ARect.Left+XPos,ARect.Top-FAttr.FontSize*0.85);
			ShowText(Text);
			EndText();
			if(Clipping)
				GRestore();
		}

		public void GSave()
		{
			WriteString("q"+(char)10);
		}

		public void MoveTo(float x,float y)
		{
			string S;
			S=Generic.FloatToStrR(x)+" "+Generic.FloatToStrR(y)+" m"+(char)10;
			WriteString(S);
		}

		public void LineTo(float x,float y)
		{
			string S;
			S=Generic.FloatToStrR(x)+" "+Generic.FloatToStrR(y)+" l"+(char)10;
			WriteString(S);
		}

		public void ClosePath()
		{
			WriteString("h"+(char)10);
		}

		public void Clip()
		{
			WriteString("W"+(char)10);
		}

		public void NewPath()
		{
			WriteString("n"+(char)10);
		}

		public void BeginText()
		{
			WriteString("BT"+(char)10);
		}

		public void MoveTextPoint(double tx,double ty)
		{
			string S;
			S=Generic.FloatToStrR(tx)+" "+
				Generic.FloatToStrR(ty)+" Td"+(char)10;
			WriteString(S);
		}

		public void ShowText(string S)
		{
			string FString;
			FString="("+Generic.EscapeText(S)+")";
			WriteString(FString+" Tj"+(char)10);
		}

		public void EndText()
		{
			WriteString("ET"+(char)10);
		}

		public void GRestore()
		{
			WriteString("Q"+(char)10);
		}

		public void SetLeading(float leading)
		{
			if(FAttr.Leading==leading)
				return;
			WriteString(Generic.FloatToStrR(leading)+" TL"+(char)10);
		}

		public string GetNextWord(string S,ref int Index)
		{
			int ln,i;
			string FResult;

			FResult="";
			ln=S.Length;						
			for(i=Index;i<ln;i++)
			{
				if(i!=0)
				{
					if(((S[i]==(char)10)&(S[i-1]==(char)13))|(S[i]==' '))
					{
						FResult=S.Substring(Index,i-(Index-1));
						Index=i+1;
						break;
					}
					else if(i>ln-2)
					{
						FResult=S.Substring(Index,i-(Index-1));
						Index=i+1;
						break;
					}
				}
				else if(ln==1)
				{
					FResult=S;
					Index=i+1;
					break;
				}
			}
			return FResult;
		}

		public void MultilineTextRect(PdfRect ARect,string Text,bool WordWrap)
		{
			int i;
			string S1, S2;
			float XPos, YPos;
			float tmpXPos;
			float tmpWidth;
			int ln;
			bool ForceReturn;
			string FText;

			YPos=ARect.Top-FAttr.FontSize*0.85F;
			XPos=ARect.Left;
			FText=Text;

			BeginText();

			MoveTextPoint(XPos,YPos);
			i=0;
			S2=GetNextWord(FText,ref i);
			XPos=XPos+TextWidth(S2);
			if((S2!="")&&(S2[S2.Length-1]==' '))
				XPos=XPos+FAttr.WordSpace;
			while(i<FText.Length)
			{
				ln=S2.Length-1;
				if((ln>=2)&&(S2[ln]==(char)10)&&(S2[ln-1]==(char)13))
				{
					S2=S2.Substring(0,ln-1);
					ForceReturn=true;
				}
				else
					ForceReturn=false;
				S1=GetNextWord(FText,ref i);
				tmpWidth=TextWidth(S1);
				tmpXPos=XPos+tmpWidth;

				if((WordWrap)&(tmpXPos>ARect.Right)|(ForceReturn))
				{
					if(S2!="")
						InternalShowText(S2,ARect.Right-ARect.Left);
					S2="";
					MoveToNextLine();
					ARect.Top=ARect.Top-FAttr.Leading;
					if(ARect.Top<ARect.Bottom+FAttr.FontSize)
						break;
					XPos=ARect.Left;
				}
				XPos=XPos+tmpWidth;
				if((S1[S1.Length-1]==' ')&&(S1.Length>0))
					XPos=XPos+FAttr.WordSpace;
				S2=S2+S1;
			}
			if(S2!="")
				InternalShowText(S2,ARect.Right-ARect.Left);
			EndText();
		}

		void InternalShowText(string S,float AWidth)
		{
			int i;
			i=MeasureText(S,AWidth);
			S=S.Substring(0,i);
			ShowText(S);
		}

		public int MeasureText(string Text,float AWidth)
		{
			return FAttr.MeasureText(Text,AWidth);
		}

		public void MoveToNextLine()
		{
			WriteString("T*"+(char)10);
		}

		public void SetDash(byte[] aaray,byte phase)
		{
			string S;

			S="[";
			if((aaray.Length>=0)&&(aaray[0]!=0))
				for(int i=0;i<aaray.Length;i++)
					S=S+aaray[i].ToString()+" ";
			S=S+"]"+phase.ToString()+" d"+(char)10;
			WriteString(S);
		}

		public void Ellipse(float X,float Y,float Width,float Height)
		{
			MoveTo(X,Y+Height/2);
			
			CurveToC(X,Y+Height/2-Height/2*11/20,
				X+Width/2-Width/2*11/20,
				Y,X+Width/2,Y);

			CurveToC(X+Width/2+Width/2*11/20,
				Y,
				X+Width,
				Y+Height/2-Height/2*11/20,
				X+Width,
				Y+Height/2);

			CurveToC(X+Width,
				Y+Height/2+Height/2*11/20,
				X+Width/2+Width/2*11/20,
				Y+Height,
				X+Width/2,
				Y+Height);

			CurveToC(X+Width/2-Width/2*11/20,
				Y+Height,
				X,
				Y+Height/2+Height/2*11/20,
				X,
				Y+Height/2);
		}

		public void CurveToC(float x1,float y1,float x2,float y2,float x3,float y3)
		{
			string S;
			S=Generic.FloatToStrR(x1)+" "+
				Generic.FloatToStrR(y1)+" "+
				Generic.FloatToStrR(x2)+" "+
				Generic.FloatToStrR(y2)+" "+
				Generic.FloatToStrR(x3)+" "+
				Generic.FloatToStrR(y3)+" c"+(char)10;
			WriteString(S);
		}

		public void SetCharSpace(float charSpace)
		{
			if(FAttr.CharSpace==charSpace)
				return;
			FAttr.SetCharSpace(charSpace);
			if(Contents!=null)
				WriteString(Generic.FloatToStrR(charSpace)+" Tc"+(char)10);
		}

		public float TextWidth(string Text)
		{
			return FAttr.TextWidth(Text);
		}

		public void SetRGBFillColor(Color Value)
		{
			string S;
			S=GetColorStr(Value)+" rg"+(char)10;
			WriteString(S);
		}

		public void SetRGBStrokeColor(Color Value)
		{
			string S;
			S=GetColorStr(Value)+" RG"+(char)10;
			WriteString(S);
		}

		public void SetLineWidth(float linewidth)
		{
			string S;
			S=Generic.FloatToStrR(linewidth)+" w"+(char)10;
			WriteString(S);
		}

		public void ClosePathFillStroke()
		{
			WriteString("b"+(char)10);
		}

		public void Fill()
		{
			WriteString("f"+(char)10);
		}

		public void Stroke()
		{
			WriteString("S"+(char)10);
		}

		public void ClosePathStroke()
		{
			WriteString("s"+(char)10);
		}

		string GetColorStr(Color Color)
		{
			byte[] X=new byte[3];
			X[0]=Color.R;
			X[1]=Color.G;
			X[2]=Color.B;			
			double x0=(double)X[0]/255;
			double x1=(double)X[1]/255;
			double x2=(double)X[2]/255;
			return Generic.FloatToStrR(x0)+" "+Generic.FloatToStrR(x1)+" "+
				Generic.FloatToStrR(x2);
		}

		public void SetWordSpace(float wordSpace)
		{
			if(FAttr.WordSpace==wordSpace)
				return;
			FAttr.SetWordSpace(wordSpace);
			if(Contents!=null)
				WriteString(Generic.FloatToStrR(wordSpace)+" Tw"+(char)10);
		}

		public void SetFont(string AName,float ASize)
		{
			PdfFont FFont;
			PdfDictionary FFontList;
			string FFontName;

			FFont=FPdfDoc.GetFont(AName);
			if((FAttr.Font==FFont)&&(FAttr.FontSize==ASize))
				return;
			FFontList=Generic.Page_GetResources(FPage,"Font");
			
			FFontName=FFont.Data.PdfNameByName("Name").Value;
			
			if(FFontList.ValueByName(FFontName)==null)
				FFontList.AddItem(FFontName,FFont.Data);
			if(FContents!=null)
				SetFontAndSize("/"+FFontName,ASize);
			FAttr.Font=FFont;
			FAttr.FontSize=ASize;
		}
			
		public void SetFontAndSize(string fontname,float size)
		{
			string S;
			S=fontname+" "+Generic.FloatToStrR(size)+" Tf"+(char)10;
			WriteString(S);
		}

		private void WriteString(string S)
		{
			if((!FIsVirtual)&&(FContents!=null))
				Generic.WriteString(S,FContents.Stream);
		}

		public void SetPage(PdfDictionary APage)
		{
			PdfName AFont;

			if(FPage!=null)
			{
				FPage.AddInternalItem("_Font",new PdfName(FAttr.Font.Name));
				FPage.AddInternalItem("_Font_Size",new PdfReal(FAttr.FontSize));
				FPage.AddInternalItem("_Word_Space",new PdfReal(FAttr.WordSpace));
				FPage.AddInternalItem("_Char_Space",new PdfReal(FAttr.CharSpace));
				FPage.AddInternalItem("_HScalling",new PdfNumber(FAttr.HorizantalScaling));
				FPage.AddInternalItem("_Leading",new PdfReal(FAttr.Leading));
			}
			FPage=APage;
			FContents=(PdfStream)FPage.ValueByName("Contents");
			AFont=Page.PdfNameByName("_Font");
			if(AFont!=null)
			{
				FAttr.Font=FPdfDoc.GetFont(AFont.Value);
				FAttr.FontSize=(float)FPage.PdfNumberByName("_Font_Size").Value;
				FAttr.WordSpace=(float)FPage.PdfRealByName("_Word_Space").Value;
				FAttr.CharSpace=(float)FPage.PdfRealByName("_Char_Space").Value;
				FAttr.HorizantalScaling=(short)FPage.PdfNumberByName("_HScalling").Value;
				FAttr.Leading=FPage.PdfNumberByName("_Leading").Value;
			}
			else
			{
				FAttr.Font=null;
				SetFont(Generic.PDF_DEFAULT_FONT,Generic.PDF_DEFAULT_FONT_SIZE);
				FAttr.CharSpace=0;
				FAttr.WordSpace=0;
				FAttr.HorizantalScaling=100;
				FAttr.Leading=0;				
			}
		}
		#endregion

		#region class properties
		public PdfDoc Doc
		{
			get
			{
				if(FPdfDoc!=null)
					return FPdfDoc;
				else
					throw (new EPdfInvalidOperation("ERROR: GetDoc document is null."));
			}
		}

		public PdfCanvasAttribute Attribute
		{
			get
			{
				return FAttr;
			}
		}

		public PdfStream Contents
		{
			get
			{
				return FContents;
			}
		}

		public long PageHeight
		{
			get
			{
				PdfArray FMediaBox;
				PdfNumber Fnumber;				
				FMediaBox=(PdfArray)Page.ValueByName("MediaBox");
				Fnumber=(PdfNumber)FMediaBox[3];
				if(FMediaBox!=null)
					return Fnumber.Value;
				else
					return FPdfDoc.DefaultPageHeight;
			}
			set
			{
				PdfArray FmediaBox;				
				FmediaBox=(PdfArray)Page.ValueByName("MediaBox");
				PdfNumber Fnumber=(PdfNumber)FmediaBox[3];
				if(FmediaBox!=null)
					Fnumber.Value=value;
				else
					throw (new EPdfInvalidOperation("Can not change height of this page.."));
			}
		}

		public long PageWidth
		{
			get
			{
				PdfArray FMediaBox;
				FMediaBox=(PdfArray)Page.ValueByName("MediaBox");
				PdfNumber Fnumber=(PdfNumber)FMediaBox[2];
				if(FMediaBox!=null)
					return Fnumber.Value;
				else
					return FPdfDoc.DefaultPageWidth;
			}
			set
			{
				PdfArray FMediaBox;
				FMediaBox=(PdfArray)Page.ValueByName("MediaBox");
				PdfNumber Fnumber=(PdfNumber)FMediaBox[2];
				if(FMediaBox!=null)
					Fnumber.Value=value;
				else
					throw (new EPdfInvalidOperation("Can not change width of this page.."));
			}
		}

		public PdfDictionary Page
		{
			get
			{
				if(FPage!=null)
					return FPage;
				else
					throw (new EPdfInvalidOperation("GetPage --the Page is null"));
			}
		}
		#endregion	
	}
	#endregion

	#region PdfCanvasAttribute
	public class PdfCanvasAttribute
	{
		#region class variables
		PdfFont FFont;
		float FFontSize;
		float FWordSpace;
		float FCharSpace;
		short FHorizantalScaling;
		float FLeading;
		#endregion

		#region class properties
		public PdfFont Font
		{
			get
			{
				return FFont;
			}
			set
			{
				FFont=value;
			}
		}

		public float FontSize
		{
			get
			{
				return FFontSize;
			}
			set
			{
				FFontSize=value;
			}
		}

		public float WordSpace
		{
			get
			{
				return FWordSpace;
			}
			set
			{
				if(value<0)
					throw (new EPdfInvalidValue("SetWordSpace --invalid word space"));
				if(value!=FWordSpace)
					FWordSpace=value;
			}
		}

		public float CharSpace
		{
			get
			{
				return FCharSpace;
			}
			set
			{
				if((value<Generic.PDF_MIN_CHARSPACE)||(value>Generic.PDF_MAX_CHARSPACE))
					throw (new EPdfInvalidValue("SetCharSpace --invalid char space"));
				if(value!=FCharSpace)
					FCharSpace=value;
			}
		}

		public short HorizantalScaling
		{
			get
			{
				return FHorizantalScaling;
			}
			set
			{
				if((value<Generic.PDF_MIN_HORIZONTALSCALING)||
					(value>Generic.PDF_MAX_HORIZONTALSCALING))
					throw (new EPdfInvalidValue("SetHorizontalScaling --invalid font size"));
				if(value!=FHorizantalScaling)
					FHorizantalScaling=value;
			}
		}

		public float Leading
		{
			get
			{
				return FLeading;
			}
			set
			{
				if((value<0)||(value>Generic.PDF_MAX_LEADING))
					throw (new EPdfInvalidValue("SetLeading --invalid font size"));
				if(value!=FLeading)
					FLeading=value;
			}
		}
		#endregion

		#region class methods
		public void SetWordSpace(float Value)
		{
			if(Value<0)
				throw (new EPdfInvalidValue("SetWordSpace --invalid word space"));
			if(Value!=FWordSpace)
				FWordSpace=Value;
		}

		public void SetCharSpace(float Value)
		{
			if((Value<Generic.PDF_MIN_CHARSPACE)||(Value>Generic.PDF_MAX_CHARSPACE))
				throw (new EPdfInvalidValue("SetCharSpace --invalid char space"));
			if(Value!=FCharSpace)
				FCharSpace=Value;
		}

		public float TextWidth(string Text)
		{
			char ch;
			float tmpWidth;
			float FReturn;

			FReturn=0;
			for(int i=0;i<Text.Length;i++)
			{
				ch=Text[i];
				tmpWidth=FFont.GetCharWidth(Text,i)*FFontSize/1000;
				if(FHorizantalScaling!=100)
					tmpWidth=tmpWidth*FHorizantalScaling/100;
				if(tmpWidth>0)
					tmpWidth=tmpWidth+FCharSpace;
				else
					tmpWidth=0;
				if((ch==' ')&&(FWordSpace>0)&&(i!=Text.Length))
					tmpWidth=tmpWidth+FWordSpace;
                FReturn=FReturn+tmpWidth;
			}
			return FReturn-FCharSpace;
		}

		public int MeasureText(string Text,float Width)
		{
			char ch;
			float tmpWidth;
			float tmpTotalWidth;
			int FReturn;

            FReturn=0;
			tmpTotalWidth=0;

			for(int i=0;i<Text.Length;i++)
			{
				ch=Text[i];
				tmpWidth=FFont.GetCharWidth(Text,i)*FFontSize/1000;
				if(FHorizantalScaling!=100)
					tmpWidth=tmpWidth*FHorizantalScaling/100;
				if(tmpWidth>0)
					tmpWidth=tmpWidth+FCharSpace;
				else
					tmpWidth=0;
				if((ch==' ')&&(FWordSpace>0)&&(i!=Text.Length-1))
					tmpWidth=tmpWidth+FWordSpace;
				tmpTotalWidth=tmpTotalWidth+tmpWidth;
				if(tmpTotalWidth>Width)
					break;
				FReturn++;
			}
			return FReturn;
		}
		#endregion
	}
	#endregion

	#region PdfInfo
	public class PdfInfo:PdfDictionaryWrapper
	{
		#region class properties
		public DateTime CreationDate
		{
			get
			{
				if(FData.ValueByName("CreationDate")!=null)
				{
					try
					{
						return Generic.PdfDateToDateTime(FData.PdfTextByName("CreationDate").Value);
					}
					catch
					{
						return System.DateTime.MinValue;
					}
				}
				else
					return DateTime.MinValue;				
			}
			set
			{
				FData.AddItem("CreationDate",new PdfText(Generic.DateTimeToPdfDate(value)));
			}
		}

		public string Author
		{
			get
			{
				if(FData.ValueByName("Author")!=null)
					return FData.PdfTextByName("Author").Value;
				else
					return "";
			}
			set
			{
				FData.AddItem("Author",new PdfText(value));
			}
		}

		public string Creator
		{
			get
			{
				if(FData.ValueByName("Creator")!=null)
					return FData.PdfTextByName("Creator").Value;
				else
					return "";
			}
			set
			{
				FData.AddItem("Creator",new PdfText(value));
			}
		}

		public string Keywords
		{
			get
			{
				if(FData.ValueByName("Keywords")!=null)
					return FData.PdfTextByName("Keywords").Value;
				else
					return "";
			}
			set
			{
				FData.AddItem("Keywords",new PdfText(value));
			}
		}

		public DateTime ModDate
		{
			get
			{
				if(FData.ValueByName("ModDate")!=null)
				{
					try
					{
						return Generic.PdfDateToDateTime(FData.PdfTextByName("ModDate").Value);
					}
					catch
					{
						return DateTime.MinValue;
					}
				}
				else
					return DateTime.MinValue;
			}
			set
			{
				FData.AddItem("ModDate",new PdfText(Generic.DateTimeToPdfDate(value)));
			}
		}

		public string Subject
		{
			get
			{
				if(FData.ValueByName("Subject")!=null)
					return FData.PdfTextByName("Subject").Value;
				else
					return "";
			}
			set
			{
				FData.AddItem("Subject",new PdfText(value));
			}
		}

		public string Title
		{
			get
			{
				if(FData.ValueByName("Title")!=null)
					return FData.PdfTextByName("Title").Value;
				else
					return "";
			}
			set
			{
				FData.AddItem("Title",new PdfText(value));
			}
		}
		#endregion
	}
	#endregion

	#region PdfDictionaryWrapper
	public class PdfDictionaryWrapper
	{
		#region class variables
		protected PdfDictionary FData;
		#endregion

		#region class properties
		public PdfDictionary Data
		{
			get
			{
				return FData;
			}
			set
			{
				SetData(value);
			}
		}
		#endregion

		#region class methods
		public virtual void SetData(PdfDictionary Value)
		{
			FData=Value;
		}
		#endregion
	}
	#endregion

	#region PdfCatalog
	public class PdfCatalog:PdfDictionaryWrapper
	{
		#region class variables
		PdfDestination FOpenAction;
		#endregion

		#region class properties
		public PdfDestination OpenAction
		{
			get
			{
				return FOpenAction;
			}
			set
			{
				FOpenAction=value;
			}
		}

		public SDViewerPreference ViewerPreference
		{
			get
			{
				PdfDictionary FDictionary;
				PdfBoolean FValue;
				SDViewerPreference FViewerPreference=new SDViewerPreference();

				FDictionary=(PdfDictionary)FData.ValueByName("ViewerPreference");

				FValue=FData.PdfBooleanByName("HideToolbar");
				if((FValue!=null)||(FValue.Value))
					FViewerPreference.HideToolbar=true;

				FValue=FData.PdfBooleanByName("HideMenubar");
				if((FValue!=null)||(FValue.Value))
					FViewerPreference.HideMenubar=true;

				FValue=FData.PdfBooleanByName("HideWindowUI");
				if((FValue!=null)||(FValue.Value))
					FViewerPreference.HideWindowUI=true;

				FValue=FData.PdfBooleanByName("FitWindow");
				if((FValue!=null)||(FValue.Value))
					FViewerPreference.FitWindow=true;
				
				FValue=FData.PdfBooleanByName("CenterWindow");
				if((FValue!=null)||(FValue.Value))
					FViewerPreference.CenterWindow=true;

				return FViewerPreference;
			}
			set
			{
				PdfDictionary FDictionary;
				FDictionary=(PdfDictionary)FData.ValueByName("ViewerPreferences");

				if((FDictionary==null)&((value.HideToolbar==true)||(value.HideMenubar==true)||
					(value.HideWindowUI==true)||(value.FitWindow==true)||(value.CenterWindow==true)))
				{
					FDictionary=new PdfDictionary(Data.ObjectMgr);
					FData.AddItem("ViewerPreferences",FDictionary);
				}
				
				if(value.HideToolbar==true)
					FDictionary.AddItem("HideToolbar",new PdfBoolean(true));				

				if(value.HideMenubar==true)
					FDictionary.AddItem("HideMenubar",new PdfBoolean(true));
								
				
				if(value.HideWindowUI==true)
					FDictionary.AddItem("HideWindowUI",new PdfBoolean(true));
				

				if(value.FitWindow==true)
					FDictionary.AddItem("FitWindow",new PdfBoolean(true));
				
				
				if(value.CenterWindow==true)
					FDictionary.AddItem("CenterWindow",new PdfBoolean(true));
				
			}
		}

		public PdfDictionary Pages
		{
			get
			{
				PdfDictionary ADictionary;
				ADictionary=(PdfDictionary)FData.ValueByName("Pages");
				if(ADictionary==null)
					throw(new EPdfInvalidOperation("GetPages --page object is null.."));
				return ADictionary;
			}
			set
			{
				if(Generic.GetTypeOf(value)=="Pages")
					FData.AddItem("Pages",value);
			}
		}

		public SDPageMode PageMode
		{
			get
			{
				PdfName FPageMode;
				string S;
				int i;
				
				FPageMode=(PdfName)FData.ValueByName("PageMode");				
				S=FPageMode.Value;
				for(i=0;i<Generic.PDF_PAGE_MODE_NAMES.Length;i++)
					if(Generic.PDF_PAGE_MODE_NAMES[i]==S)
					{
						return (SDPageMode)i;
					}
				
				return SDPageMode.UseNone;
			}
			set
			{
				PdfName FPageMode;

				FPageMode=(PdfName)FData.ValueByName("PageMode");
				if(FPageMode==null)
					FData.AddItem("PageMode",new PdfName(Generic.PDF_PAGE_MODE_NAMES[(int)value]));
				else
					FPageMode.Value=Generic.PDF_PAGE_MODE_NAMES[(int)value];
			}
		}

		public SDPageLayout PageLayout
		{
			get
			{
				PdfName FPageLayout;
				string S;
				int i;

				FPageLayout=(PdfName)FData.ValueByName("PageLayout");
				S=FPageLayout.Value;
				for(i=0;i<Generic.PDF_PAGE_LAYOUT_NAMES.Length;i++)
					if(Generic.PDF_PAGE_LAYOUT_NAMES[i]==S)
						return (SDPageLayout)i;
				return SDPageLayout.SinglePage;
			}
			set
			{
				PdfName FPageLayout;

				FPageLayout=(PdfName)FData.ValueByName("PageLayout");
				if(FPageLayout==null)
					FData.AddItem("PageLayout",new PdfName(Generic.PDF_PAGE_LAYOUT_NAMES[(int)value]));
				else
					FPageLayout.Value=Generic.PDF_PAGE_LAYOUT_NAMES[(int)value];
			}
		}

		public SDPageMode NonFullScreenPageMode
		{
			get
			{
				PdfDictionary FDictionary;
				PdfName FPageMode;
				string S;
				int i;

				FDictionary=(PdfDictionary)FData.ValueByName("NonFullScreenPageMode");
				FPageMode=(PdfName)FDictionary.ValueByName("NonFullScreenPageMode");
				S=FPageMode.Value;
				for(i=0;i<Generic.PDF_PAGE_MODE_NAMES.Length;i++)
					if(Generic.PDF_PAGE_MODE_NAMES[i]==S)
						return (SDPageMode)i;
				return SDPageMode.UseNone;
			}
			set
			{
				PdfDictionary FDictionary;
				PdfName FPageMode;

				FDictionary=(PdfDictionary)FData.ValueByName("ViewerPreferences");
				if(FDictionary==null)
				{
					FDictionary=new PdfDictionary(Data.ObjectMgr);
					Data.AddItem("ViewerPreferences",FDictionary);
				}
				if((value==SDPageMode.FullScreen)||(value==SDPageMode.UseNone))
					FDictionary.RemoveItem("NonFullScreenPageMode");
				else
				{
					FPageMode=(PdfName)FDictionary.ValueByName("NonFullScreenPageMode");
					if(FPageMode==null)
						FDictionary.AddItem("NonFullScreenPageMode",new PdfName(Generic.PDF_PAGE_MODE_NAMES[(int)value]));
					else
						FPageMode.Value=Generic.PDF_PAGE_MODE_NAMES[(int)value];
				}
			}
		}
		#endregion

		#region class methods
		public void SaveOpenAction()
		{
			if(FOpenAction==null)
				FData.RemoveItem("OpenAction");
			else
				FData.AddItem("OpenAction",FOpenAction.GetValue());
		}
		#endregion
	}
	#endregion

	#region PdfOutlineRoot
	public class PdfOutlineRoot:PdfOutlineEntry
	{
		#region constructor
		public PdfOutlineRoot(PdfDoc ADoc)
		{
			FCount=0;
			FDoc=ADoc;
			FOpened=true;
			Data=new PdfDictionary(ADoc.FXRef);
			ADoc.FXRef.AddObject(Data);
			Data.AddItem("Type",new PdfName("Outlines"));
			FDoc.FObjectList.Add(this);
		}
		#endregion

		#region class methods
		public override void Save()
		{
			if(Opened)
				Data.AddItem("Count",new PdfNumber(FCount));
			else
				Data.AddItem("Count",new PdfNumber(-FCount));
			if(FFirst!=null)
			{
				Data.AddItem("First",FFirst.Data);
				FFirst.Save();
			}
			if(FLast!=null)
				Data.AddInternalItem("Last",FLast.Data);
		}
		#endregion
	}
	#endregion

	#region PdfOutlineEntry
	public class PdfOutlineEntry:PdfDictionaryWrapper
	{
		#region class variables
		protected int FCount;
		protected PdfDoc FDoc;
		protected bool FOpened;
		Object FReference;
		protected PdfOutlineEntry FFirst;
		protected PdfOutlineEntry FLast;
		protected string FTitle;
		protected PdfDestination FDest;
		protected PdfOutlineEntry FNext;
		protected PdfOutlineEntry FPrev;
		protected PdfOutlineEntry FParent;
		#endregion

		#region class properties
		public PdfDestination Dest
		{
			get
			{
				return FDest;
			}
			set
			{
				FDest=value;
			}		
		}

		public PdfOutlineEntry First
		{
			get
			{
				return FFirst;
			}
		}

		public PdfOutlineEntry Last
		{
			get
			{
				return FLast;
			}
		}

		public PdfOutlineEntry Next
		{
			get
			{
				return FNext;
			}
		}

		public PdfOutlineEntry Prev
		{
			get
			{
				return FPrev;
			}
		}

		public string Title
		{
			get
			{
				return FTitle;
			}
			set
			{
				FTitle=value;
			}
		}

		public PdfOutlineEntry Parent
		{
			get
			{
				return FParent;
			}
		}

		public PdfDoc Doc
		{
			get
			{
				return FDoc;
			}
		}

		public Object Reference
		{
			get
			{
				return FReference;
			}
			set
			{
				FReference=value;
			}
		}

		public bool Opened
		{
			get
			{
				return FOpened;
			}
			set
			{
				FOpened=value;
			}
		}
		#endregion

		#region class methods
		public PdfOutlineEntry AddChild()
		{
			PdfOutlineEntry tmpEntry;
			PdfOutlineEntry FReturn;
			FCount++;
			tmpEntry=Parent;
			while(tmpEntry!=null)
			{
				tmpEntry.FCount++;
				tmpEntry=tmpEntry.Parent;
			}
			FReturn=CreateEntry(this);
			if(FFirst==null)
				FFirst=FReturn;
			if(FLast!=null)
				FLast.FNext=FReturn;
			FReturn.FPrev=FLast;
			FLast=FReturn;
			return FReturn;
		}

		public virtual void Save()
		{
			if(Opened)
				Data.AddItem("Count",new PdfNumber(FCount));
			else
				Data.AddItem("Count",new PdfNumber(-FCount));
			Data.AddItem("Title",new PdfText(FTitle));
			if(FDest!=null)
				Data.AddItem("Dest",FDest.GetValue());
			if(FFirst!=null)
			{
				Data.AddItem("First",FFirst.Data);
				FFirst.Save();
			}
			if(FLast!=null)
				Data.AddItem("Last",FLast.Data);
			if(FPrev!=null)
				Data.AddItem("Prev",FPrev.Data);
			if(FNext!=null)
			{
				Data.AddItem("Next",FNext.Data);
				FNext.Save();
			}
		}
	
		public PdfOutlineEntry CreateEntry(PdfOutlineEntry AParent)
		{
			PdfOutlineEntry FReturn;
			if(AParent==null)
				throw new Exception("CreateEntry --invalid parent.");
			FReturn=new PdfOutlineEntry();
			FReturn.FParent=AParent;
			FReturn.FCount=0;
			FReturn.FDoc=AParent.Doc;
			FReturn.Data=new PdfDictionary(FDoc.FXRef);
			FDoc.FXRef.AddObject(FReturn.Data);
			FDoc.FObjectList.Add(FReturn);
			return FReturn;
		}
		#endregion	
	}
	#endregion

	#region PdfXRef
	public class PdfXRef:PdfObjectMgr
	{
		#region class variables
		ArrayList FXRefEntries;
		#endregion

		#region constructor
		public PdfXRef()
		{
			PdfXRefEntry RootEntry;
			FXRefEntries=new ArrayList();
			RootEntry=new PdfXRefEntry(null);
			RootEntry.GenerationNumber=Generic.PDF_MAX_GENERATION_NUM;
			FXRefEntries.Add(RootEntry);
		}
		#endregion

		#region class methods
		public void WriteToStream(MemoryStream Astream)
		{
			string S;
			int Count;

			Count=FXRefEntries.Count;
			S="xref"+"\r\n"+"0 "+Count.ToString()+
				"\r\n";
			for(int i=0;i<Count;i++)
				S=S+this[i].AsString+"\r\n";
			Generic.WriteString(S,Astream);
		}

		public override void AddObject(PdfObject AObject)
		{
			int ObjectNumber;
			PdfXRefEntry XRefEntry;

			if(AObject.ObjectType!=PdfObjectType.DirectObject)
				throw (new EPdfInvalidOperation("AddObject --wrong object type."));
			XRefEntry=new PdfXRefEntry(AObject);
			ObjectNumber=FXRefEntries.Add(XRefEntry);
			AObject.SetObjectNumber(ObjectNumber);
		}

		private PdfXRefEntry GetItem(int ObjectId)
		{
			return (PdfXRefEntry)FXRefEntries[ObjectId];
		}

		public override PdfObject GetObject(int ObjectId)
		{
			return GetItem(ObjectId).Value;
		}
		#endregion

		#region class properties
		public int ItemCount
		{
			get
			{
				return FXRefEntries.Count;
			}
		}

		public PdfXRefEntry this[int ObjectID]
		{
			get
			{
				return (PdfXRefEntry)FXRefEntries[ObjectID];
			}
		}
		#endregion	
	}
	#endregion

	#region PdfXRefEntry
	public class PdfXRefEntry
	{
		#region class variables
		long FByteOffset;
		string FEntryType;
		int FGenerationNumber;
		PdfObject FValue;
		#endregion

		#region constructor
		public PdfXRefEntry(PdfObject AValue)
		{
			FByteOffset=-1;
			if(AValue!=null)
			{
				FEntryType=Generic.PDF_IN_USE_ENTRY;
				FGenerationNumber=AValue.GenerationNumber;
				FValue=AValue;
			}
			else
			{
				FEntryType=Generic.PDF_FREE_ENTRY;
				FGenerationNumber=0;
			}
		}
		#endregion

		#region class properties
		public int GenerationNumber
		{
			get
			{
				return FGenerationNumber;
			}
			set
			{
				FGenerationNumber=value;
			}
		}

		public PdfObject Value
		{
			get
			{
				return FValue;
			}
		}

		public long ByteOffset
		{
			get
			{
				return FByteOffset;
			}
			set
			{
				FByteOffset=value;
			}
		}

		public string AsString
		{
			get
			{
				return FormatIntToString(FByteOffset,10)+
					" "+FormatIntToString(FGenerationNumber,5)+
					" "+FEntryType;
			}
		}
		#endregion

		#region class methods
		string FormatIntToString(long Value,long Len)
		{
			string S;
			string R;
			long i,j;

			R="";
			if(Value<0)
				S="0";
			else
				S=Value.ToString();
			i=Len-S.Length;
			for(j=0;j<i;j++)
				R=R+"0";
			return R+S;
		}
		#endregion
	}
	#endregion

	#region PdfHeader
	public class PdfHeader
	{
		#region class methods
		public void WriteToStream(MemoryStream AStream)
		{
			Generic.WriteString("%PDF-1.2 "+"\r\n",AStream);
		}
		#endregion
	}
	#endregion

	#region PdfTrailer
	public class PdfTrailer
	{
		#region class variables
		PdfDictionary FAttributes ;
		long FXRefAddress;
		#endregion

		#region constructor
		public PdfTrailer(PdfObjectMgr AObjectMgr)
		{
			FAttributes=new PdfDictionary(AObjectMgr);
			FAttributes.AddItem("Size",new PdfNumber(0));			
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

		public long XRefAddress
		{
			get
			{
				return FXRefAddress;
			}
			set
			{
				FXRefAddress=value;
			}
		}
		#endregion

		#region class methods
		public void WriteToStream(MemoryStream AStream)
		{
			Generic.WriteString("trailer"+"\r\n",AStream);
			FAttributes.WriteToStream(AStream);
			Generic.WriteString("\r\n"+"startxref"+"\r\n",AStream);
			Generic.WriteString(FXRefAddress.ToString()+"\r\n",AStream);
			Generic.WriteString("%%EOF"+"\r\n",AStream);
		}
		#endregion
	}
	#endregion

	#region PdfFont
	public class PdfFont:PdfDictionaryWrapper
	{
		#region class variables
		string FName;
		#endregion

		#region class properties
		public string Name
		{
			get
			{
				return FName;
			}
		}
		#endregion

		#region class methods
		protected void AddStrElements(PdfDictionary ADic,
			PDF_STR_TBL[] ATable)
		{
			for(int i=0;i<ATable.Length;i++)
				ADic.AddItem(ATable[i].Key,new PdfName(ATable[i].Val));
		}

		protected void AddIntElements(PdfDictionary Adic,
			PDF_INT_TBL[] ATable)
		{
			for(int i=0;i<ATable.Length;i++)
				Adic.AddItem(ATable[i].Key,new PdfNumber(ATable[i].Val));
		}

		public virtual int GetCharWidth(string AText,int APos)
		{
			return 0;
		}
		#endregion

		#region constructor
		public PdfFont(PdfXRef AXref,string AName)
		{
			FName=AName;
		}
		#endregion

		#region structs
		public struct PDF_STR_TBL
		{
			public string Key;
			public string Val;
		}

		public struct PDF_INT_TBL
		{
			public string Key;
			public int Val;
		}
		#endregion	
	}
	#endregion

	#region PdfDestination
	public class PdfDestination
	{
		#region class variables
		PdfDoc FDoc;
		PdfDictionary FPage;
		PdfDestinationType FType;
		long[] FValues=new long[4];
		float FZoom;
		Object FReference;
		#endregion

		#region class methods
		public PdfDestination(PdfDoc APdfDoc)
		{
			FDoc=APdfDoc;
			if((FDoc==null)||(!FDoc.HasDoc))
				throw(new EPdfInvalidOperation("TPdfDestination --cannot destination object."));
			FPage=FDoc.Canvas.Page;
			for(int i=0;i<4;i++)
				FValues[i]=0;
			FZoom=1;
		}

		public PdfArray GetValue()
		{
			const int DEST_MAX_VALUE = 100;
			PdfArray FArray;

			FArray=new PdfArray(FDoc.FXRef);
			FArray.AddItem(FPage);
			FArray.AddItem(new PdfName(Generic.PDF_DESTINATION_TYPE_NAMES[(int)FType]));
			switch(FType)
			{
				case PdfDestinationType.XYZ:
					if(FValues[0]>=-DEST_MAX_VALUE)
						FArray.AddItem(new PdfNumber(Left));
					else
						FArray.AddItem(new PdfNull());
					if(FValues[1]>=-DEST_MAX_VALUE)
						FArray.AddItem(new PdfNumber(Top));
					else
						FArray.AddItem(new PdfNull());
					if(FZoom<0)
						FZoom=0;
					FArray.AddItem(new PdfReal(FZoom));
					break;

				case PdfDestinationType.FitR:
					if(FValues[0]>=-DEST_MAX_VALUE)
						FArray.AddItem(new PdfNumber(Left));
					else
						FArray.AddItem(new PdfNull());
					if(FValues[1]>=-DEST_MAX_VALUE)
						FArray.AddItem(new PdfNumber(Bottom));
					else
						FArray.AddItem(new PdfNull());
					if(FValues[2]>=0)
						FArray.AddItem(new PdfNumber(Right));
					else
						FArray.AddItem(new PdfNull());
					if(FValues[3]>=0)
						FArray.AddItem(new PdfNumber(Top));
					else
						FArray.AddItem(new PdfNull());
					break;

				case PdfDestinationType.FitH:
					goto case PdfDestinationType.FitBH;
				case PdfDestinationType.FitBH:
					if(FValues[1]>=-DEST_MAX_VALUE)
						FArray.AddItem(new PdfNumber(Top));
					else
						FArray.AddItem(new PdfNull());
					break;

				case PdfDestinationType.FitV:
					goto case PdfDestinationType.FitBV;
				case PdfDestinationType.FitBV:
					if(FValues[0]>=-DEST_MAX_VALUE)
						FArray.AddItem(new PdfNumber(Left));
					else
						FArray.AddItem(new PdfNull());
					break;
			}
			return FArray;
		}
		#endregion

		#region class properties
		public PdfDestinationType DestinationType
		{
			get
			{
				return FType;
			}
			set
			{
				FType=value;
			}
		}

		public Object Reference
		{
			get
			{
				return FReference;
			}
			set
			{
				FReference=value;
			}
		}

		public long PageHeight
		{
			get
			{
				PdfArray FMediaBox;
				PdfNumber fnumber;

				FMediaBox=FPage.PdfArrayByName("MediaBox");
				if(FMediaBox!=null)
				{
					fnumber=(PdfNumber)FMediaBox[3];
					return fnumber.Value;
				}
				else
				{
					return FDoc.DefaultPageHeight;
				}
			}
		}

		public float Zoom
		{
			get
			{
				return FZoom;
			}
			set
			{
				if(value!=FZoom)
				{
					if(value<0)
						throw(new EPdfInvalidValue("Zoom property cannot set to under 0."));
					else
					{
						if(value>Generic.PDF_MAX_ZOOMSIZE)
							throw(new EPdfInvalidValue(string.Format("Zoom property cannot set to over {0}",Generic.PDF_MAX_ZOOMSIZE)));
						else
							FZoom=value;
					}
				}
			}
		}

		public PdfDoc Doc
		{
			get
			{
				return FDoc;
			}
		}

		public long Left
		{
			get
			{
				return FValues[0];
			}
			set
			{
				FValues[0]=value;
			}
		}

		public long Top
		{
			get
			{
				return FValues[1];
			}
			set
			{
				FValues[1]=value;
			}
		}

		public long Right
		{
			get
			{
				return FValues[2];
			}
			set
			{
				FValues[2]=value;
			}
		}

		public long Bottom
		{
			get
			{
				return FValues[3];
			}
			set
			{
				FValues[3]=value;
			}
		}
		#endregion
	}
	#endregion
}
