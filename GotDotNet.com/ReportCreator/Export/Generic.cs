using System;
using System.Text;
using System.Windows.Forms;
using System.Drawing;
using System.IO;

namespace Windows.Forms.Reports.Export
{
	#region Generic
	public class Generic
	{
		#region class variables
		public static string[] PDF_ANNOTATION_TYPE_NAMES=
		{
			"Text","Link","Sound","FreeText","Stamp","Square",
			"Circle","StrikeOut","Highlight","Underline","Ink",
			"FileAttachment","Popup"
		};

		public static int  MAX_IMAGE_NUMBER = 65535;
		public static int MIN_PANEL_SIZE = 10;
		public static Color PROTECT_AREA_COLOR=Color.FromArgb(200,200,200);

		public static int PDF_FONT_STD_CHARSET=32;
		public static int PDF_FONT_ITALIC=64;

		public static int LINE_PITCH=378;
		public static float  PDF_MAX_ZOOMSIZE = 10;

		public static string[] ITEM_FONT_NAMES=
	{
		"Courier New","Arial","Times New Roman"
	};
	
		public static string[] PDFFONT_CLASS_ITALIC_NAMES=
		{
			"FixedWidth-Italic","Arial-Italic","Times-Italic"
		};

		public static string[] PDFFONT_CLASS_BOLD_NAMES=
		{
			"FixedWidth-Bold","Arial-Bold","Times-Bold"
		};

		public static string[] PDFFONT_CLASS_BOLDITALIC_NAMES=
		{
			"FixedWidth-BoldItalic","Arial-BoldItalic","Times-BoldItalic"
		};

		public static string[] PDFFONT_CLASS_NAMES=
		{
			"FixedWidth","Arial","Times-Roman"
		};

		public static string PDF_DEFAULT_FONT ="Arial";
		public static float PDF_DEFAULT_FONT_SIZE = 9.75f;

		public static string[] PDF_DESTINATION_TYPE_NAMES=new string[8]
		{
			"XYZ","Fit","FitH","FitV","FitR","FitB","FitBH","FitBV"
		};
		public static int DEFAULT_MARGIN = 32;

		public static string[] PDF_PAGE_MODE_NAMES=
		{
			"UseNone","UseOutlines","UseThumbs","FullScreen"
		};

		public static string[] PDF_PAGE_LAYOUT_NAMES=
		{
			"SinglePage","OneColumn","TwoColumnLeft","TwoColumnRight"
		};

		public static float PDF_MIN_CHARSPACE = -30;
		public static float PDF_MAX_CHARSPACE = 300;
		public static short PDF_MIN_HORIZONTALSCALING = 10;
		public static short PDF_MAX_HORIZONTALSCALING = 300;
		public static float PDF_MAX_LEADING = 300;

		const short PDF_PAGE_WIDTH_A4 = 596;
		const short PDF_PAGE_HEIGHT_A4 = 842;

		public static short PDF_DEFAULT_PAGE_WIDTH = PDF_PAGE_WIDTH_A4;
		public static short PDF_DEFAULT_PAGE_HEIGHT = PDF_PAGE_HEIGHT_A4;
	
		public static string PDF_IN_USE_ENTRY = "n";
		public static string PDF_FREE_ENTRY = "f";
		public static int PDF_MAX_GENERATION_NUM = 65535;

		public static string PdfCreator_VERSION_TEXT="PdfCreator version 1.0";
		#endregion

		#region class methods
		static PdfImageCreator FindClass(string S)
		{
			if(S=="Pdf-Bitmap")
				return (PdfImageCreator)(new PdfBitmapImage());
			if(S=="Pdf-Jpeg")
				return (PdfImageCreator)(new PdfJpegImage());
			else
				return null;
		}
		public static string GetText(string[] Value)
		{
			string s="";
			int L=Value.GetLength(0);
			if(L!=0)
			{
				for(int i=0;i<L;i++)
				{
					if(i!=L-1)
						s=s+Value.GetValue(i).ToString()+"\r";
					else
						s=s+Value.GetValue(i).ToString();
				}	
				return s.Trim();
			}
			else return s;
		}

		public static string DrawGetText(string[] Value)
		{
			string s="";
			int L=Value.Length;
			if(L!=0)
			{
				for(int i=0;i<L;i++)
				{
					if(i!=L-1)
						s=s+Value.GetValue(i).ToString()+"\r\n";
					else
						s=s+Value.GetValue(i).ToString();
				}
				return s.Trim();
			}
			else return s;		
		}

		public static Rectangle GridPanelBounds(int ColCount,int RowCount,int X,int Y,int Width,int Height)
		{
			int tmpWidth=(int)(Width/ColCount);
			int tmpHeight=(int)(Height/RowCount);
			return new Rectangle(X,Y,tmpWidth,tmpHeight);
		}

		public static PdfImage CreatePdfImage(Bitmap ABitmap,string ImageClassName)
		{
			PdfImageCreator Pdfimagecreator;

			Pdfimagecreator=FindClass(ImageClassName);
			if(Pdfimagecreator==null)
				throw new Exception(string.Format("AddImage --InvalidImageClassName:{0}",ImageClassName));
			return Pdfimagecreator.CreateImage(ABitmap);
		}

		public static System.Drawing.Drawing2D.DashStyle PenStyleToDashStyle(int ps)
		{
			System.Drawing.Drawing2D.DashStyle ds;
			ds=System.Drawing.Drawing2D.DashStyle.Solid;
			switch(ps)
			{
				case 0:
					ds=System.Drawing.Drawing2D.DashStyle.Dash;
					break;
				case 1:
					ds=System.Drawing.Drawing2D.DashStyle.DashDot;
					break;
				case 2:
					ds=System.Drawing.Drawing2D.DashStyle.DashDotDot;
					break;
				case 3:
					ds=System.Drawing.Drawing2D.DashStyle.Dot;
					break;
				case 4:
					ds=System.Drawing.Drawing2D.DashStyle.Solid;
					break;
			}
			return ds;
		}

		public static PdfFont.PDF_STR_TBL[] String_Table()
		{
			PdfFont.PDF_STR_TBL s1;
			PdfFont.PDF_STR_TBL s2;
			PdfFont.PDF_STR_TBL s3;

			s1.Key="Type";
			s1.Val="Font";
			s2.Key="Subtype";
			s2.Val="Type1";
			s3.Key="Encoding";
			s3.Val="WinAnsiEncoding";

			PdfFont.PDF_STR_TBL[] TYPE1_FONT_STR_TABLE={s1,s2,s3};
			return TYPE1_FONT_STR_TABLE;
		}

		public static PdfFont.PDF_INT_TBL[] Int_Table()
		{
			PdfFont.PDF_INT_TBL i1;
			PdfFont.PDF_INT_TBL i2;

			i1.Key="FirstChar";
			i1.Val=32;
			i2.Key="LastChar";
			i2.Val=255;

			PdfFont.PDF_INT_TBL[] TYPE1_FONT_INT_TABLE={i1,i2};
			return TYPE1_FONT_INT_TABLE;
		}

		public static PdfFont.PDF_STR_TBL[] Script_String_Table()
		{
			PdfFont.PDF_STR_TBL s1;
			PdfFont.PDF_STR_TBL s2;
			PdfFont.PDF_STR_TBL s3;

			s1.Key="Type";
			s1.Val="FontDescriptor";
			s2.Key="FontName";
			s2.Val="Type1";
			s3.Key="Encoding";
			s3.Val="WinAnsiEncoding";

			PdfFont.PDF_STR_TBL[] SCRIPT_DISC_STR_TABLE={s1,s2,s3};
			return SCRIPT_DISC_STR_TABLE;
		}

		public static PdfFont.PDF_INT_TBL[] Script_Int_Table()
		{
			PdfFont.PDF_INT_TBL i1;
			PdfFont.PDF_INT_TBL i2;
			PdfFont.PDF_INT_TBL i3;
			PdfFont.PDF_INT_TBL i4;
			PdfFont.PDF_INT_TBL i5;
			PdfFont.PDF_INT_TBL i6;
			PdfFont.PDF_INT_TBL i7;

			i1.Key="Ascent";
			i1.Val=758;
			i2.Key="CapHeight";
			i2.Val=758;
			i3.Key="Descent";
			i3.Val=-363;
			i4.Key="Flags";
			i4.Val=PDF_FONT_STD_CHARSET+PDF_FONT_ITALIC;
			i5.Key="ItalicAngle";
			i5.Val=0;
			i6.Key="StemV";
			i6.Val=78;
			i7.Key="MissingWidth";
			i7.Val=202;

			PdfFont.PDF_INT_TBL[] SCRIPT_DISC_INT_TABLE={i1,i2,i3,i4,i5,i6,i7};
			return SCRIPT_DISC_INT_TABLE;
		}

		public static int GetCharCount(string Text)
		{
			int FReturn;
			FReturn=0;
			for(int i=0;i<Text.Length;i++)
			{
				FReturn++;
			}
			return FReturn;
		}

		public static string StrToHex(string Value)
		{
			string freturn;
			freturn="";
			for(int i=0;i<Value.Length;i++)
			{
				freturn=freturn+string.Format("{0:X2}",Value[i]);
			}
			return freturn;
		}

		public static PdfRect PdfRect(float Left,float Top,float Right,float Bottom)
		{
			PdfRect freturn=new PdfRect();
			freturn.Left=Left;
			freturn.Top=Top;
			freturn.Right=Right;
			freturn.Bottom=Bottom;
			return freturn;
		}

		public static string EscapeText(string Value)
		{
			string EscapeChars="()\\"+(char)13+(char)10+(char)9+(char)8+(char)12;
			string ReplaceChars="()\\rntbf";
			bool flg;
			string S;

			if(Value==null)
				return "";
			else
			{
				S="";
				for(int i=0;i<Value.Length;i++)
				{
					flg=false;
					for(int j=0;j<EscapeChars.Length;j++)
						if(Value[i]==EscapeChars[j])
						{
							S=S+"\\"+ReplaceChars[j];
							flg=true;
							break;
						}
					if(!flg)
						S=S+Value[i];
				}
			}
			return S;
		}

		public static PdfDictionary Page_GetResources(PdfDictionary APage,string AName)
		{
			PdfDictionary FResources;

			FResources=APage.PdfDictionaryByName("Resources");
			return FResources.PdfDictionaryByName(AName);
		}

		public static string FloatToStrR(double Value)
		{
			string s=string.Format("{0:f2}",Value);
			s=s.Replace(',','.');
			s=s.Replace(".00","");
			if((s.Length>2)&&(s[s.Length-1]=='0')&&(s[s.Length-3]=='.'))
				s=s.Remove(s.Length-1,1);			
			return s;
		}

		public static void WriteString(string Value,MemoryStream AStream)
		{
			char[] ch=Value.ToCharArray();
			byte[]b=new byte[ch.Length];
			for(int i=0;i<ch.Length;i++)
				b[i]=(byte)ch[i];
			AStream.Write(b,0,b.Length);			
		}

		public static DateTime PdfDateToDateTime(string AText)
		{
			if(AText.Length!=16)
				throw(new FormatException(" "));
			string yy=AText.Substring(2,4);
			string MM=AText.Substring(6,2);
			string dd=AText.Substring(8,2);
			string HH=AText.Substring(10,2);
			string mm=AText.Substring(12,2);
			string ss=AText.Substring(14,2);
			
			return DateTime.Parse(yy+"."+MM+"."+dd+" "+HH+":"+mm+":"+ss);
		}

		public static string DateTimeToPdfDate(DateTime ADate)
		{						
			return String.Format("D:{0:yyyyMMddHHmmss}",ADate);
		}

		public static string GetTypeOf(PdfDictionary ADictionary)
		{
			PdfName Pdfname;

			Pdfname=ADictionary.PdfNameByName("Type");
			if(Pdfname!=null)
				return Pdfname.Value;
			else
				return "";
		}

		public static void Pages_AddKids(PdfDictionary AParent,PdfDictionary AKid)
		{
			PdfArray FKids;
		
			FKids=AParent.PdfArrayByName("Kids");
			FKids.AddItem(AKid);
			AParent.PdfNumberByName("Count").Value=FKids.ItemCount;
		}
		#endregion		
	}
	#endregion
}
