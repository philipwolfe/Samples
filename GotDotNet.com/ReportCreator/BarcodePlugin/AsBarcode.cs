//Author Serdar Dirican (serdardirican@hotmail.com)
//Thanks for Andreas Schmidt (a_j_schmidt@rocketmail.com)

using System;
using System.ComponentModel;
using System.Drawing;

namespace Windows.Forms.Reports.BarcodePlugin
{
	#region AsBarcode
	public class AsBarcode:Component
	{
		#region class variables
		char[,] table_2_5=
			{
				{'0', '0', '1', '1', '0'},
		{'1', '0', '0', '0', '1'},
		{'0', '1', '0', '0', '1'},
		{'1', '1', '0', '0', '0'},
		{'0', '0', '1', '0', '1'},
		{'1', '0', '1', '0', '0'},
		{'0', '1', '1', '0', '0'},
		{'0', '0', '0', '1', '1'},
		{'1', '0', '0', '1', '0'},
		{'0', '1', '0', '1', '0'}
			};

		static Code39[] table_39=new Code39[44];

		string[] code39x=
			{
				"%U", "$A", "$B", "$C", "$D", "$E", "$F", "$G",
				"$H", "$I", "$J", "$K", "$L", "$M", "$N", "$O",
				"$P", "$Q", "$R", "$S", "$T", "$U", "$V", "$W",
				"$X", "$Y", "$Z", "%A", "%B", "%C", "%D", "%E",
				" ", "/A", "/B", "/C", "/D", "/E", "/F", "/G",
				"/H", "/I", "/J", "/K", "/L", "/M", "/N", "/O",
				"0",  "1",  "2",  "3",  "4",  "5",  "6",  "7",
				"8",  "9", "/Z", "%F", "%G", "%H", "%I", "%J",
				"%V",  "A",  "B",  "C",  "D",  "E",  "F",  "G",
				"H",  "I",  "J",  "K",  "L",  "M",  "N",  "O",
				"P",  "Q",  "R",  "S",  "T",  "U",  "V",  "W",
				"X",  "Y",  "Z", "%K", "%L", "%M", "%N", "%O",
				"%W", "+A", "+B", "+C", "+D", "+E", "+F", "+G",
				"+H", "+I", "+J", "+K", "+L", "+M", "+N", "+O",
				"+P", "+Q", "+R", "+S", "+T", "+U", "+V", "+W",
				"+X", "+Y", "+Z", "%P", "%Q", "%R", "%S", "%T"
			};

		static Code_128[] table_128=new Code_128[103];

		static Code93[] table_93=new Code93[47];

		static string[] code93x=
			{
				"]U", "[A", "[B", "[C", "[D", "[E", "[F", "[G",
				"[H", "[I", "[J", "[K", "[L", "[M", "[N", "[O",
				"[P", "[Q", "[R", "[S", "[T", "[U", "[V", "[W",
				"[X", "[Y", "[Z", "]A", "]B", "]C", "]D", "]E",
				" ", "{A", "{B", "{C", "{D", "{E", "{F", "{G",
				"{H", "{I", "{J", "{K", "{L", "{M", "{N", "{O",
				"0",  "1",  "2",  "3",  "4",  "5",  "6",  "7",
				"8",  "9", "{Z", "]F", "]G", "]H", "]I", "]J",
				"]V",  "A",  "B",  "C",  "D",  "E",  "F",  "G",
				"H",  "I",  "J",  "K",  "L",  "M",  "N",  "O",
				"P",  "Q",  "R",  "S",  "T",  "U",  "V",  "W",
				"X",  "Y",  "Z", "]K", "]L", "]M", "]N", "]O",
				"]W", "}A", "}B", "}C", "}D", "}E", "}F", "}G",
				"}H", "}I", "}J", "}K", "}L", "}M", "}N", "}O",
				"}P", "}Q", "}R", "}S", "}T", "}U", "}V", "}W",
				"}X", "}Y", "}Z", "]P", "]Q", "]R", "]S", "]T"
			};

		static string[] table_MSI=
			{
				"51515151" ,    //"0"
				"51515160" ,    //"1"
				"51516051" ,    //"2"
				"51516060" ,    //"3"
				"51605151" ,    //"4"
				"51605160" ,    //"5"
				"51606051" ,    //"6"
				"51606060" ,    //"7"
				"60515151" ,    //"8"
				"60515160"      //"9"
			};

		static string[] table_PostNet=
			{
				"5151A1A1A1" ,    //"0"
				"A1A1A15151" ,    //"1"
				"A1A151A151" ,    //"2"
				"A1A15151A1" ,    //"3"
				"A151A1A151" ,    //"4"
				"A151A151A1" ,    //"5"
				"A15151A1A1" ,    //"6"
				"51A1A1A151" ,    //"7"
				"51A1A151A1" ,    //"8"
				"51A151A1A1"      //"9"
			};

		static Codabar[] table_cb=new Codabar[20];

		static string[] table_EAN_C=
			{
				"7150" ,    // 0 
				"6160" ,    // 1 
				"6061" ,    // 2 
				"5350" ,    // 3 
				"5071" ,    // 4 
				"5170" ,    // 5 
				"5053" ,    // 6 
				"5251" ,    // 7 
				"5152" ,    // 8 
				"7051"      // 9 
			};

		static string[] table_EAN_A=
			{
				"2605",    // 0 
				"1615",    // 1 
				"1516",    // 2 
				"0805",    // 3 
				"0526",    // 4 
				"0625",    // 5 
				"0508",    // 6 
				"0706",    // 7 
				"0607",    // 8 
				"2506"     // 9 
			};

		static string[] table_EAN_B=
			{
				"0517",    // 0 
				"0616",    // 1 
				"1606",    // 2 
				"0535",    // 3 
				"1705",    // 4 
				"0715",    // 5 
				"3505",    // 6 
				"1525",    // 7 
				"2515",    // 8 
				"1507"     // 9 
			};

		static char[,] table_ParityEAN13=
			{
				{'A', 'A', 'A', 'A', 'A', 'A'},    // 0 
				{'A', 'A', 'B', 'A', 'B', 'B'},    // 1 
				{'A', 'A', 'B', 'B', 'A', 'B'},    // 2 
				{'A', 'A', 'B', 'B', 'B', 'A'},    // 3 
				{'A', 'B', 'A', 'A', 'B', 'B'},    // 4 
				{'A', 'B', 'B', 'A', 'A', 'B'},    // 5 
				{'A', 'B', 'B', 'B', 'A', 'A'},    // 6 
				{'A', 'B', 'A', 'B', 'A', 'B'},    // 7 
				{'A', 'B', 'A', 'B', 'B', 'A'},    // 8 
				{'A', 'B', 'B', 'A', 'B', 'A'}	   // 9 
			};

		static char[,] table_UPC_E0=
			{
				{'E', 'E', 'E', 'o', 'o', 'o' },    // 0 
				{'E', 'E', 'o', 'E', 'o', 'o' },    // 1 
				{'E', 'E', 'o', 'o', 'E', 'o' },    // 2 
				{'E', 'E', 'o', 'o', 'o', 'E' },    // 3 
				{'E', 'o', 'E', 'E', 'o', 'o' },    // 4 
				{'E', 'o', 'o', 'E', 'E', 'o' },    // 5 
				{'E', 'o', 'o', 'o', 'E', 'E' },    // 6 
				{'E', 'o', 'E', 'o', 'E', 'o' },    // 7 
				{'E', 'o', 'E', 'o', 'o', 'E' },    // 8 
				{'E', 'o', 'o', 'E', 'o', 'E' }     // 9 
			};

		double FAngle;
		double FRatio;
		int FModul;
		BarcodeType FTyp;
		bool FCheckSum;
		CheckSumMethod FCheckSumMethod;
		BarcodeOption FShowText;
		Color FColor;
		Color FColorBar;
		Color FForeColor;
		int FHeight;
		int FLeft;
		string FText;
		int FTop;
		sbyte[] modules=new sbyte[4];
		Font FShowTextFont;
		ShowTextPosition FShowTextPosition;
		static Data[] BCData=new Data[23];
		#endregion

		#region class events
		public event EventHandler Change;
		#endregion

		#region constructor
		public AsBarcode()
		{
			FAngle=0;
			FRatio=2;
			FModul=1;
			FTyp=BarcodeType.Code_2_5_interleaved;
			FCheckSum=false;
			FCheckSumMethod=CheckSumMethod.Modulo10;
			FShowText=BarcodeOption.None;
			FColor=Color.White;
			FColorBar=Color.Black;
			FShowTextFont=new Font("Arial",8.25F);
			FShowTextPosition=ShowTextPosition.TopLeft;
			FForeColor=SystemColors.ControlText;
			CreateData();
		}
		#endregion

		#region class methods
		void MakeModules()
		{
			switch(Typ)
			{
				case BarcodeType.Code_2_5_interleaved:
					goto case BarcodeType.CodeUPC_Supp5;
				case BarcodeType.Code_2_5_industrial:
					goto case BarcodeType.CodeUPC_Supp5;
				case BarcodeType.Code39:
					goto case BarcodeType.CodeUPC_Supp5;
				case BarcodeType.CodeEAN8:
					goto case BarcodeType.CodeUPC_Supp5;
				case BarcodeType.CodeEAN13:
					goto case BarcodeType.CodeUPC_Supp5;
				case BarcodeType.Code39Extended:
					goto case BarcodeType.CodeUPC_Supp5;
				case BarcodeType.CodeCodabar:
					goto case BarcodeType.CodeUPC_Supp5;
				case BarcodeType.CodeUPC_A:
					goto case BarcodeType.CodeUPC_Supp5;
				case BarcodeType.CodeUPC_E0:
					goto case BarcodeType.CodeUPC_Supp5;
				case BarcodeType.CodeUPC_E1:
					goto case BarcodeType.CodeUPC_Supp5;
				case BarcodeType.CodeUPC_Supp2:
					goto case BarcodeType.CodeUPC_Supp5;
				case BarcodeType.CodeUPC_Supp5:
					if(Ratio<2)
						Ratio=2;
					if(Ratio>3)
						Ratio=3;
					break;
				case BarcodeType.Code_2_5_matrix:
					if(Ratio<2.25)
						Ratio=2.25;
					if(Ratio>3.0)
						Ratio=3;
					break;
			}
			modules[0]=(sbyte)FModul;
			modules[1]=(sbyte)(FModul*FRatio);
			modules[2]=(sbyte)(modules[1]*3/2);
			modules[3]=(sbyte)(modules[1]*2);
		}

		public void DrawBarcode(Graphics gr)
		{
			string data;
			
			data=MakeData();
			DoLines(data,gr);
			if(FShowText!=BarcodeOption.None)
				DrawText(gr);
		}

		public void DrawText(Graphics gr)
		{
			int PosX, PosY;
			Font font;
			Brush brush;

			font=ShowTextFont;
			brush=new SolidBrush(ForeColor);
			PosX=FLeft;
			PosY=FTop;
			if((ShowTextPosition==ShowTextPosition.TopLeft)||(ShowTextPosition==ShowTextPosition.BottomLeft))
				PosX=FLeft;
			else
			{
				if((ShowTextPosition==ShowTextPosition.TopRight)||(ShowTextPosition==ShowTextPosition.BottomRight))
				{
					PosX=FLeft+Width-(int)gr.MeasureString(Text,font).Width;
				}
				else
				{
					if((ShowTextPosition==ShowTextPosition.TopCenter)||(ShowTextPosition==ShowTextPosition.BottomCenter))
					{
						PosX=FLeft+(Width-(int)gr.MeasureString(Text,font).Width)/2;
					}
				}
			}

			if((ShowTextPosition==ShowTextPosition.TopLeft)||(ShowTextPosition==ShowTextPosition.TopCenter)||(ShowTextPosition==ShowTextPosition.TopRight))
				PosY=FTop;
			else
			{
				if((ShowTextPosition==ShowTextPosition.BottomLeft)||(ShowTextPosition==ShowTextPosition.BottomCenter)||(ShowTextPosition==ShowTextPosition.BottomRight))
				{
					PosY=FTop+Height-(int)gr.MeasureString(Text,font).Height;
				}
			}

			if(FShowText==BarcodeOption.Code)
			{
				gr.FillRectangle(new SolidBrush(Color.White),new Rectangle(PosX,PosY,(int)gr.MeasureString(Text,font).Width,(int)gr.MeasureString(Text,font).Height));
				gr.DrawString(Text,font,brush,PosX,PosY);
			}
			if(FShowText==BarcodeOption.Typ)
			{
				gr.DrawString(GetTypText(),font,brush,FLeft,FTop-(font.Height*2.5F));
			}
			if(FShowText==BarcodeOption.Both)
			{
				gr.FillRectangle(new SolidBrush(Color.White),new Rectangle(PosX,PosY,(int)gr.MeasureString(Text,font).Width,(int)gr.MeasureString(Text,font).Height));
				gr.DrawString(Text,font,brush,PosX,PosY);
				gr.DrawString(GetTypText(),font,brush,FLeft,FTop-(font.Height*2.5F));
			}
		}

		string GetTypText()
		{
			return BCData[(int)FTyp].Name;
		}

		void DoLines(string data,Graphics gr)
		{
			BarLineType lt;
			int xadd;
			int width, height;
			Point a,b,c,d,orgin;
			double alpha;
			Pen pen;
			Brush brush;

			xadd=0;
			orgin=new Point(FLeft,FTop);
			alpha=FAngle/180*Math.PI;
			orgin=TranslateQuad2D(alpha,orgin,new Point(this.Width,this.Height));

			for(int i=0;i<data.Length;i++)
			{
				OneBarProps(data[i],out width,out lt);
				if((lt==BarLineType.black)||(lt==BarLineType.black_half))
				{
					pen=new Pen(FColorBar);
				}
				else
				{
					pen=new Pen(FColor);
				}
				brush=new SolidBrush(pen.Color);
				if(lt==BarLineType.black_half)
					height=FHeight*2/5;
				else
					height=FHeight;

				a=new Point(xadd,0);

				b=new Point(xadd,height);

				c=new Point(xadd+width-1,height);

				d=new Point(xadd+width-1,0);

				a=Translate2D(Rotate2D(a,alpha),orgin);
				b=Translate2D(Rotate2D(b,alpha),orgin);
				c=Translate2D(Rotate2D(c,alpha),orgin);
				d=Translate2D(Rotate2D(d,alpha),orgin);

				Point[] curvePoints=
					{
						a,b,c,d
					};
				gr.DrawPolygon(pen,curvePoints);
				gr.FillPolygon(brush,curvePoints);
				xadd=xadd+width;
			}
		}

		Point Rotate2D(Point p,double alpha)
		{
			double sinus,cosinus;
			Point freturn;
			sinus=Math.Sin(alpha);
			cosinus=Math.Cos(alpha);
			freturn=new Point((int)(p.X*cosinus+p.Y*sinus),(int)(-p.X*sinus+p.Y*cosinus));
			return freturn;
		}

		Point TranslateQuad2D(double alpha,Point orgin,Point point)
		{
			double alphacos;
			double alphasin;
			Point moveby;

			alphasin=Math.Sin(alpha);
			alphacos=Math.Cos(alpha);
			if(alphasin>=0)
			{
				if(alphacos>=0)
				{
					moveby=new Point(0,(int)(alphasin*point.X));
				}
				else
				{
					moveby=new Point((int)-(alphacos*point.X),(int)(alphasin*point.X-alphacos*point.Y));
				}
			}
			else
			{
				if(alphacos>=0)
				{
					moveby=new Point(-(int)(alphasin*point.Y),0);
				}
				else
				{
					moveby=new Point(-(int)(alphacos*point.X)-(int)(alphasin*point.Y),-(int)(alphacos*point.Y));
				}
			}
			return Translate2D(orgin,moveby);
		}

		Point Translate2D(Point a,Point b)
		{
			Point freturn;
			freturn=new Point(a.X+b.X,a.Y+b.Y);
			return freturn;
		}

		string Code_2_5_matrix()
		{
			string freturn="705050";
			char c;

			for(int i=0;i<FText.Length;i++)
			{
				for(int j=0;j<5;j++)
				{
					if(table_2_5[Convert.ToInt32(FText[i].ToString()),j]=='1')
						c='1';
					else
						c='0';
					if(j%2==0)
						c=(char)((int)c+5);
					freturn=freturn+c.ToString();
				}
				freturn=freturn+"0";
			}
			return freturn+"70505";
		}

		string Code_2_5_industrial()
		{
			string freturn="606050";
			for(int i=0;i<FText.Length;i++)
			{
				for(int j=0;j<5;j++)
				{
					if(table_2_5[Convert.ToInt32(FText[i].ToString()),j]=='1')
						freturn=freturn+"60";
					else
						freturn=freturn+"50";
				}
			}
			return freturn+"605060";
		}

		string Code_2_5_interleaved()
		{
			char c;
			string freturn="5050";

			for(int i=0;i<FText.Length;i++)
			{
				for(int j=0;j<5;j++)
				{
					if(i+1==FText.Length)
						break;
					if(table_2_5[Convert.ToInt32(FText[i].ToString()),j]=='1')
						c='6';
					else
						c='5';
					freturn=freturn+c.ToString();					
					
					if(table_2_5[Convert.ToInt32(FText[i+1].ToString()),j]=='1')
						c='1';
					else
						c='0';
					freturn=freturn+c.ToString();
					
				}
				i++;
			}
			return freturn+"605";
		}

		string Code_39()
		{
			int idx,checksum;
			string freturn;
			checksum=0;
			Createtable_39();
			freturn=table_39[FindIdx('*')].data+"0";
			for(int i=0;i<FText.Length;i++)
			{
				idx=FindIdx(FText[i]);
				if(idx<0)
					continue;
				freturn=freturn+table_39[idx].data+"0";
				checksum=checksum+table_39[idx].chk;
			}
			if(FCheckSum)
			{
				checksum=checksum%43;
				for(int i=0;i<table_39.Length;i++)
				{
					if(checksum==table_39[i].chk)
					{
						freturn=freturn+table_39[i].data+"0";
						break;
					}
				}
			}
			return freturn+table_39[FindIdx('*')].data;
		}

		int FindIdx(char z)
		{
			for(int i=0;i<table_39.Length;i++)
			{
				if(z==table_39[i].c)
				{
					return i;
				}
			}
			return -1;
		}

		void Createtable_39()
		{
			table_39[0].c='0';table_39[0].data="505160605";table_39[0].chk=0;
			table_39[1].c='1'; table_39[1].data="605150506"; table_39[1].chk=1 ;
			table_39[2].c='2'; table_39[2].data="506150506"; table_39[2].chk=2 ;
			table_39[3].c='3'; table_39[3].data="606150505"; table_39[3].chk=3 ;
			table_39[4].c='4'; table_39[4].data="505160506"; table_39[4].chk=4 ;
			table_39[5].c='5'; table_39[5].data="605160505"; table_39[5].chk=5 ;
			table_39[6].c='6'; table_39[6].data="506160505"; table_39[6].chk=6 ;
			table_39[7].c='7'; table_39[7].data="505150606"; table_39[7].chk=7 ;
			table_39[8].c='8'; table_39[8].data="605150605"; table_39[8].chk=8 ;
			table_39[9].c='9'; table_39[9].data="506150605"; table_39[9].chk=9 ;
			table_39[10].c='A'; table_39[10].data="605051506"; table_39[10].chk=10;
			table_39[11].c='B'; table_39[11].data="506051506"; table_39[11].chk=11;
			table_39[12].c='C'; table_39[12].data="606051505"; table_39[12].chk=12;
			table_39[13].c='D'; table_39[13].data="505061506"; table_39[13].chk=13;
			table_39[14].c='E'; table_39[14].data="605061505"; table_39[14].chk=14;
			table_39[15].c='F'; table_39[15].data="506061505"; table_39[15].chk=15;
			table_39[16].c='G'; table_39[16].data="505051606"; table_39[16].chk=16;
			table_39[17].c='H'; table_39[17].data="605051605"; table_39[17].chk=17;
			table_39[18].c='I'; table_39[18].data="506051605"; table_39[18].chk=18;
			table_39[19].c='J'; table_39[19].data="505061605"; table_39[19].chk=19;
			table_39[20].c='K'; table_39[20].data="605050516"; table_39[20].chk=20;
			table_39[21].c='L'; table_39[21].data="506050516"; table_39[21].chk=21;
			table_39[22].c='M'; table_39[22].data="606050515"; table_39[22].chk=22;
			table_39[23].c='N'; table_39[23].data="505060516"; table_39[23].chk=23;
			table_39[24].c='O'; table_39[24].data="605060515"; table_39[24].chk=24;
			table_39[25].c='P'; table_39[25].data="506060515"; table_39[25].chk=25;
			table_39[26].c='Q'; table_39[26].data="505050616"; table_39[26].chk=26;
			table_39[27].c='R'; table_39[27].data="605050615"; table_39[27].chk=27;
			table_39[28].c='S'; table_39[28].data="506050615"; table_39[28].chk=28;
			table_39[29].c='T'; table_39[29].data="505060615"; table_39[29].chk=29;
			table_39[30].c='U'; table_39[30].data="615050506"; table_39[30].chk=30;
			table_39[31].c='V'; table_39[31].data="516050506"; table_39[31].chk=31;
			table_39[32].c='W'; table_39[32].data="616050505"; table_39[32].chk=32;
			table_39[33].c='X'; table_39[33].data="515060506"; table_39[33].chk=33;
			table_39[34].c='Y'; table_39[34].data="615060505"; table_39[34].chk=34;
			table_39[35].c='Z'; table_39[35].data="516060505"; table_39[35].chk=35;
			table_39[36].c='-'; table_39[36].data="515050606"; table_39[36].chk=36;
			table_39[37].c='.'; table_39[37].data="615050605"; table_39[37].chk=37;
			table_39[38].c=' '; table_39[38].data="516050605"; table_39[38].chk=38;
			table_39[39].c='*'; table_39[39].data="515060605"; table_39[39].chk=0 ;
			table_39[40].c='$'; table_39[40].data="515151505"; table_39[40].chk=39;
			table_39[41].c='/'; table_39[41].data="515150515"; table_39[41].chk=40;
			table_39[42].c='+'; table_39[42].data="515051515"; table_39[42].chk=41;
			table_39[43].c='%'; table_39[43].data="505151515"; table_39[43].chk=42;
		}

		string Code_39Extended()
		{
			string freturn;
			string Save=FText;
			FText="";
			for(int i=0;i<Save.Length;i++)
			{
				if((int)(Save[i])<=127)
				{
					FText=FText+code39x[(int)(Save[i])];
				}
			}
			freturn=Code_39();
			FText=Save;
			return freturn;
		}

		string Code_128()
		{
			int j, idx;
			string startcode;
			int checksum;
			int codeword_pos;
			string freturn;

			string StartA="211412";
			string StartB="211214";
			string StartC="211232";
			string Stop="2331112";

			switch(FTyp)
			{
				case BarcodeType.Code128A:
				case BarcodeType.CodeEAN128A:
					checksum=103;
					startcode=StartA;
					break;
				case BarcodeType.Code128B:
				case BarcodeType.CodeEAN128B:
					checksum=104;
					startcode=StartB;
					break;
				case BarcodeType.Code128C:
				case BarcodeType.CodeEAN128C:
					checksum=105;
					startcode=StartC;
					break;
				default:
					throw new Exception(string.Format("{0}",GetType().ToString())+" wrong BarcodeType in Code_128");
			}
			freturn=startcode;
			codeword_pos=1;
			Createtable_128();
			switch(FTyp)
			{
				case BarcodeType.CodeEAN128A:
				case BarcodeType.CodeEAN128B:
				case BarcodeType.CodeEAN128C:
					freturn=freturn+table_128[102].data;
					checksum=checksum+102*codeword_pos;
					codeword_pos++;
					if(FCheckSum)
						FText=DoCheckSumming(FText);
					break;
			}
			if((FTyp==BarcodeType.Code128C)||(FTyp==BarcodeType.CodeEAN128C))
			{
				if(FText.Length%2!=0)
					FText="0"+FText;
				if(FText.Length!=0)
					for(int i=0;i<(FText.Length/2);i++)
					{
						j=(i*2)+1;
						idx=Find_Code128C(FText.Substring(j-1,2));
						if(idx<0)
							idx=Find_Code128C("00");
						freturn=freturn+table_128[idx].data;
						checksum=checksum+idx*codeword_pos;
						codeword_pos++;
					}
			}
			else
			{
				for(int i=0;i<FText.Length;i++)
				{
					idx=Find_Code128AB(FText[i]);
					if(idx<0)
						idx=Find_Code128AB(' ');
					freturn=freturn+table_128[idx].data;
					checksum=checksum+idx*codeword_pos;
					codeword_pos++;
				}
			}

			checksum=checksum%103;
			freturn=freturn+table_128[checksum].data;
			freturn=freturn+Stop;
			freturn=convert(freturn);
			return freturn;
		}

		string convert(string s)
		{
			int v;
			string freturn="";
			for(int i=0;i<s.Length;i++)
			{
				v=(int)s[i]-1;
				if(i%2==0)
					v=v+5;
				freturn=freturn+(char)v;
			}
			return freturn;
		}

		int Find_Code128AB(char c)
		{
			char v;
			for(int i=0;i<table_128.Length;i++)
			{
				if(FTyp==BarcodeType.Code128A)
					v=table_128[i].a;
				else
					v=table_128[i].b;
				if(c==v)
				{
					return i;
				}
			}
			return -1;
		}

		int Find_Code128C(string c)
		{
			for(int i=0;i<table_128.Length;i++)
			{
				if(table_128[i].c==c)
				{
					return i;
				}
			}
			return -1;
		}

		string DoCheckSumming(string data)
		{
			switch(FCheckSumMethod)
			{
				case CheckSumMethod.None:
					return data;
				case CheckSumMethod.Modulo10:
					return CheckSumModulo10(data);
				default:
					return data;
			}
		}

		static string CheckSumModulo10(string data)
		{
			int fak,sum;
			sum=0;
			fak=data.Length;
			for(int i=0;i<data.Length;i++)
			{
				if(fak%2==0)
					sum=sum+(int)data[i]*1;
				else
					sum=sum+(int)data[i]*3;
				fak--;
			}
			if(sum%10==0)
				return data+"0";
			else
				return data+((int)(10-(sum%10))).ToString();
		}

		void Createtable_128()
		{
			table_128[0].a=' '; table_128[0].b=' '; table_128[0].c="00"; table_128[0].data="212222" ;
			table_128[1].a='!'; table_128[1].b='!'; table_128[1].c="01"; table_128[1].data="222122" ;
			table_128[2].a='\"'; table_128[2].b='\"'; table_128[2].c="02"; table_128[2].data="222221" ;
			table_128[3].a='#'; table_128[3].b='#'; table_128[3].c="03"; table_128[3].data="121223" ;
			table_128[4].a='$'; table_128[4].b='$'; table_128[4].c="04"; table_128[4].data="121322" ;
			table_128[5].a='%'; table_128[5].b='%'; table_128[5].c="05"; table_128[5].data="131222" ;
			table_128[6].a='&'; table_128[6].b='&'; table_128[6].c="06"; table_128[6].data="122213" ;
			table_128[7].a='\''; table_128[7].b='\''; table_128[7].c="07"; table_128[7].data="122312" ;
			table_128[8].a=(char)0; table_128[8].b=(char)0; table_128[8].c="08"; table_128[8].data="132212" ;
			table_128[9].a=(char)0; table_128[9].b=(char)0; table_128[9].c="09"; table_128[9].data="221213" ;
			table_128[10].a='*'; table_128[10].b='*'; table_128[10].c="10"; table_128[10].data="221312" ;
			table_128[11].a='+'; table_128[11].b='+'; table_128[11].c="11"; table_128[11].data="231212" ;
			table_128[12].a=';'; table_128[12].b=';'; table_128[12].c="12"; table_128[12].data="112232" ; 
			table_128[13].a='-'; table_128[13].b='-'; table_128[13].c="13"; table_128[13].data="122132" ;
			table_128[14].a='.'; table_128[14].b='.'; table_128[14].c="14"; table_128[14].data="122231" ;
			table_128[15].a='/'; table_128[15].b='/'; table_128[15].c="15"; table_128[15].data="113222" ;
			table_128[16].a='0'; table_128[16].b='0'; table_128[16].c="16"; table_128[16].data="123122" ;
			table_128[17].a='1'; table_128[17].b='1'; table_128[17].c="17"; table_128[17].data="123221" ;
			table_128[18].a='2'; table_128[18].b='2'; table_128[18].c="18"; table_128[18].data="223211" ;
			table_128[19].a='3'; table_128[19].b='3'; table_128[19].c="19"; table_128[19].data="221132" ;
			table_128[20].a='4'; table_128[20].b='4'; table_128[20].c="20"; table_128[20].data="221231" ;
			table_128[21].a='5'; table_128[21].b='5'; table_128[21].c="21"; table_128[21].data="213212" ;
			table_128[22].a='6'; table_128[22].b='6'; table_128[22].c="22"; table_128[22].data="223112" ;
			table_128[23].a='7'; table_128[23].b='7'; table_128[23].c="23"; table_128[23].data="312131" ;
			table_128[24].a='8'; table_128[24].b='8'; table_128[24].c="24"; table_128[24].data="311222" ;
			table_128[25].a='9'; table_128[25].b='9'; table_128[25].c="25"; table_128[25].data="321122" ;
			table_128[26].a='='; table_128[26].b='='; table_128[26].c="26"; table_128[26].data="321221" ;
			table_128[27].a=';'; table_128[27].b=';'; table_128[27].c="27"; table_128[27].data="312212" ;
			table_128[28].a='<'; table_128[28].b='<'; table_128[28].c="28"; table_128[28].data="322112" ;
			table_128[29].a='='; table_128[29].b='='; table_128[29].c="29"; table_128[29].data="322211" ;
			table_128[30].a='>'; table_128[30].b='>'; table_128[30].c="30"; table_128[30].data="212123" ;
			table_128[31].a='?'; table_128[31].b='?'; table_128[31].c="31"; table_128[31].data="212321" ;
			table_128[32].a='@'; table_128[32].b='@'; table_128[32].c="32"; table_128[32].data="232121" ;
			table_128[33].a='A'; table_128[33].b='A'; table_128[33].c="33"; table_128[33].data="111323" ;
			table_128[34].a='B'; table_128[34].b='B'; table_128[34].c="34"; table_128[34].data="131123" ;
			table_128[35].a='C'; table_128[35].b='C'; table_128[35].c="35"; table_128[35].data="131321" ;
			table_128[36].a='D'; table_128[36].b='D'; table_128[36].c="36"; table_128[36].data="112313" ;
			table_128[37].a='E'; table_128[37].b='E'; table_128[37].c="37"; table_128[37].data="132113" ;
			table_128[38].a='F'; table_128[38].b='F'; table_128[38].c="38"; table_128[38].data="132311" ;
			table_128[39].a='G'; table_128[39].b='G'; table_128[39].c="39"; table_128[39].data="211313" ;
			table_128[40].a='H'; table_128[40].b='H'; table_128[40].c="40"; table_128[40].data="231113" ;
			table_128[41].a='I'; table_128[41].b='I'; table_128[41].c="41"; table_128[41].data="231311" ;
			table_128[42].a='J'; table_128[42].b='J'; table_128[42].c="42"; table_128[42].data="112133" ;
			table_128[43].a='K'; table_128[43].b='K'; table_128[43].c="43"; table_128[43].data="112331" ;
			table_128[44].a='L'; table_128[44].b='L'; table_128[44].c="44"; table_128[44].data="132131" ;
			table_128[45].a='M'; table_128[45].b='M'; table_128[45].c="45"; table_128[45].data="113123" ;
			table_128[46].a='N'; table_128[46].b='N'; table_128[46].c="46"; table_128[46].data="113321" ;
			table_128[47].a='O'; table_128[47].b='O'; table_128[47].c="47"; table_128[47].data="133121" ;
			table_128[48].a='P'; table_128[48].b='P'; table_128[48].c="48"; table_128[48].data="313121" ;
			table_128[49].a='Q'; table_128[49].b='Q'; table_128[49].c="49"; table_128[49].data="211331" ;
			table_128[50].a='R'; table_128[50].b='R'; table_128[50].c="50"; table_128[50].data="231131" ;
			table_128[51].a='S'; table_128[51].b='S'; table_128[51].c="51"; table_128[51].data="213113" ;
			table_128[52].a='T'; table_128[52].b='T'; table_128[52].c="52"; table_128[52].data="213311" ;
			table_128[53].a='U'; table_128[53].b='U'; table_128[53].c="53"; table_128[53].data="213131" ;
			table_128[54].a='V'; table_128[54].b='V'; table_128[54].c="54"; table_128[54].data="311123" ;
			table_128[55].a='W'; table_128[55].b='W'; table_128[55].c="55"; table_128[55].data="311321" ;
			table_128[56].a='X'; table_128[56].b='X'; table_128[56].c="56"; table_128[56].data="331121" ;
			table_128[57].a='Y'; table_128[57].b='Y'; table_128[57].c="57"; table_128[57].data="312113" ;
			table_128[58].a='Z'; table_128[58].b='Z'; table_128[58].c="58"; table_128[58].data="312311" ;
			table_128[59].a='['; table_128[59].b='['; table_128[59].c="59"; table_128[59].data="332111" ;
			table_128[60].a='\\'; table_128[60].b='\\'; table_128[60].c="60"; table_128[60].data="314111" ;
			table_128[61].a=']'; table_128[61].b=']'; table_128[61].c="61"; table_128[61].data="221411" ;
			table_128[62].a='^'; table_128[62].b='^'; table_128[62].c="62"; table_128[62].data="431111" ;
			table_128[63].a='_'; table_128[63].b='_'; table_128[63].c="63"; table_128[63].data="111224" ;
			table_128[64].a=' '; table_128[64].b='`'; table_128[64].c="64"; table_128[64].data="111422" ;
			table_128[65].a=' '; table_128[65].b='a'; table_128[65].c="65"; table_128[65].data="121124" ;
			table_128[66].a=' '; table_128[66].b='b'; table_128[66].c="66"; table_128[66].data="121421" ;
			table_128[67].a=' '; table_128[67].b='c'; table_128[67].c="67"; table_128[67].data="141122" ;
			table_128[68].a=' '; table_128[68].b='d'; table_128[68].c="68"; table_128[68].data="141221" ;
			table_128[69].a=' '; table_128[69].b='e'; table_128[69].c="69"; table_128[69].data="112214" ;
			table_128[70].a=' '; table_128[70].b='f'; table_128[70].c="70"; table_128[70].data="112412" ;
			table_128[71].a=' '; table_128[71].b='g'; table_128[71].c="71"; table_128[71].data="122114" ;
			table_128[72].a=' '; table_128[72].b='h'; table_128[72].c="72"; table_128[72].data="122411" ;
			table_128[73].a=' '; table_128[73].b='i'; table_128[73].c="73"; table_128[73].data="142112" ;
			table_128[74].a=' '; table_128[74].b='j'; table_128[74].c="74"; table_128[74].data="142211" ;
			table_128[75].a=' '; table_128[75].b='k'; table_128[75].c="75"; table_128[75].data="241211" ;
			table_128[76].a=' '; table_128[76].b='l'; table_128[76].c="76"; table_128[76].data="221114" ;
			table_128[77].a=' '; table_128[77].b='m'; table_128[77].c="77"; table_128[77].data="413111" ;
			table_128[78].a=' '; table_128[78].b='n'; table_128[78].c="78"; table_128[78].data="241112" ;
			table_128[79].a=' '; table_128[79].b='o'; table_128[79].c="79"; table_128[79].data="134111" ;
			table_128[80].a=' '; table_128[80].b='p'; table_128[80].c="80"; table_128[80].data="111242" ;
			table_128[81].a=' '; table_128[81].b='q'; table_128[81].c="81"; table_128[81].data="121142" ;
			table_128[82].a=' '; table_128[82].b='r'; table_128[82].c="82"; table_128[82].data="121241" ;
			table_128[83].a=' '; table_128[83].b='s'; table_128[83].c="83"; table_128[83].data="114212" ;
			table_128[84].a=' '; table_128[84].b='t'; table_128[84].c="84"; table_128[84].data="124112" ;
			table_128[85].a=' '; table_128[85].b='u'; table_128[85].c="85"; table_128[85].data="124211" ;
			table_128[86].a=' '; table_128[86].b='v'; table_128[86].c="86"; table_128[86].data="411212" ;
			table_128[87].a=' '; table_128[87].b='w'; table_128[87].c="87"; table_128[87].data="421112" ;
			table_128[88].a=' '; table_128[88].b='x'; table_128[88].c="88"; table_128[88].data="421211" ;
			table_128[89].a=' '; table_128[89].b='y'; table_128[89].c="89"; table_128[89].data="212141" ;
			table_128[90].a=' '; table_128[90].b='z'; table_128[90].c="90"; table_128[90].data="214121" ;
			table_128[91].a=' '; table_128[91].b='{'; table_128[91].c="91"; table_128[91].data="412121" ;
			table_128[92].a=' '; table_128[92].b='|'; table_128[92].c="92"; table_128[92].data="111143" ;
			table_128[93].a=' '; table_128[93].b='}'; table_128[93].c="93"; table_128[93].data="111341" ;
			table_128[94].a=' '; table_128[94].b='~'; table_128[94].c="94"; table_128[94].data="131141" ;
			table_128[95].a=' '; table_128[95].b=' '; table_128[95].c="95"; table_128[95].data="114113" ;
			table_128[96].a=' '; table_128[96].b=' '; table_128[96].c="96"; table_128[96].data="114311" ;
			table_128[97].a=' '; table_128[97].b=' '; table_128[97].c="97"; table_128[97].data="411113" ;
			table_128[98].a=' '; table_128[98].b=' '; table_128[98].c="98"; table_128[98].data="411311" ;
			table_128[99].a=' '; table_128[99].b=' '; table_128[99].c="99"; table_128[99].data="113141" ;
			table_128[100].a=' '; table_128[100].b=' '; table_128[100].c="  "; table_128[100].data="114131" ;
			table_128[101].a=' '; table_128[101].b=' '; table_128[101].c="  "; table_128[101].data="311141" ;
			table_128[102].a=' '; table_128[102].b=' '; table_128[102].c="  "; table_128[102].data="411131" ;    
		}

		string Code_93()
		{
			int idx, checkC, checkK,weightC, weightK;
			string freturn="111141";
			Createtable_93();
			for(int i=0;i<FText.Length;i++)
			{
				idx=Find_Code93(FText[i]);
				if(idx<0)
					throw new Exception(string.Format("{0} Code93 bad Data",FText));
				freturn=freturn+table_93[idx].data;
			}
			checkC=0;
			checkK=0;
			weightC=1;
			weightK=2;
			for(int i=FText.Length-1;i>-1;i--)
			{
				idx=Find_Code93(FText[i]);
				checkC=checkC+(idx*weightC);
				checkK=checkK+(idx*weightK);
				weightC++;
				if(weightC>20)
					weightC=1;
				weightK++;
				if(weightK>15)
					weightC=1;
			}
			checkK=checkK+checkC;
			checkC=checkC%47;
			checkK=checkK%47;
			freturn=freturn+table_93[checkC].data+table_93[checkK].data;
			freturn=freturn+"1111411";
			freturn=convert(freturn);
			return freturn;
		}

		int Find_Code93(char c)
		{	
			for(int i=0;i<table_93.Length;i++)
			{
				if(c==table_93[i].c)
				{
					return i;
				}
			}
			return -1;
		}

		void Createtable_93()
		{
			table_93[0].c='0'; table_93[0].data="131112"  ;
			table_93[1].c='1'; table_93[1].data="111213"  ;
			table_93[2].c='2'; table_93[2].data="111312"  ;
			table_93[3].c='3'; table_93[3].data="111411"  ;
			table_93[4].c='4'; table_93[4].data="121113"  ;
			table_93[5].c='5'; table_93[5].data="121212"  ;
			table_93[6].c='6'; table_93[6].data="121311"  ;
			table_93[7].c='7'; table_93[7].data="111114"  ;
			table_93[8].c='8'; table_93[8].data="131211"  ;
			table_93[9].c='9'; table_93[9].data="141111"  ;
			table_93[10].c='A'; table_93[10].data="211113"  ;
			table_93[11].c='B'; table_93[11].data="211212"  ;
			table_93[12].c='C'; table_93[12].data="211311"  ;
			table_93[13].c='D'; table_93[13].data="221112"  ;
			table_93[14].c='E'; table_93[14].data="221211"  ;
			table_93[15].c='F'; table_93[15].data="231111"  ;
			table_93[16].c='G'; table_93[16].data="112113"  ;
			table_93[17].c='H'; table_93[17].data="112212"  ;
			table_93[18].c='I'; table_93[18].data="112311"  ;
			table_93[19].c='J'; table_93[19].data="122112"  ;
			table_93[20].c='K'; table_93[20].data="132111"  ;
			table_93[21].c='L'; table_93[21].data="111123"  ;
			table_93[22].c='M'; table_93[22].data="111222"  ;
			table_93[23].c='N'; table_93[23].data="111321"  ;
			table_93[24].c='O'; table_93[24].data="121122"  ;
			table_93[25].c='P'; table_93[25].data="131121"  ;
			table_93[26].c='Q'; table_93[26].data="212112"  ;
			table_93[27].c='R'; table_93[27].data="212211"  ;
			table_93[28].c='S'; table_93[28].data="211122"  ;
			table_93[29].c='T'; table_93[29].data="211221"  ;
			table_93[30].c='U'; table_93[30].data="221121"  ;
			table_93[31].c='V'; table_93[31].data="222111"  ;
			table_93[32].c='W'; table_93[32].data="112122"  ;
			table_93[33].c='X'; table_93[33].data="112221"  ;
			table_93[34].c='Y'; table_93[34].data="122121"  ;
			table_93[35].c='Z'; table_93[35].data="123111"  ;
			table_93[36].c='-'; table_93[36].data="121131"  ;
			table_93[37].c='.'; table_93[37].data="311112"  ;
			table_93[38].c=' '; table_93[38].data="311211"  ;
			table_93[39].c='$'; table_93[39].data="321111"  ;
			table_93[40].c='/'; table_93[40].data="112131"  ;
			table_93[41].c='+'; table_93[41].data="113121"  ;
			table_93[42].c='%'; table_93[42].data="211131"  ;
			table_93[43].c='['; table_93[43].data="121221"  ;   
			table_93[44].c=']'; table_93[44].data="312111"  ;   
			table_93[45].c='{'; table_93[45].data="311121"  ;   
			table_93[46].c='}'; table_93[46].data="122211"  ; 
		}

		string Code_93Extended()
		{
			string save,freturn;
			save=FText;
			FText="";
			for(int i=0;i<save.Length;i++)
			{
				if((int)save[i]<=127)
					FText=FText+code93x[(int)save[i]];
			}
			freturn=Code_93();
			FText=save;
			return freturn;
		}

		string Code_MSI()
		{
			int  check_even, check_odd, checksum;
			string freturn="60";
			check_even=0;
			check_odd=0;
			for(int i=0;i<FText.Length;i++)
			{
				if(i%2==0)
					check_odd=check_odd*10+(int)FText[i];
				else
					check_even=check_even+(int)FText[i];
				freturn=freturn+table_MSI[Convert.ToInt32(FText[i].ToString())];
			}
			checksum=sum(check_odd*2)+check_even;
			checksum=checksum%10;
			if(checksum>0)
				checksum=10-checksum;
			freturn=freturn+table_MSI[Convert.ToInt32(((char)((int)'0'+checksum)).ToString())];
			return freturn+"515";
		}

		int sum(int x)
		{
			int sum=0;
			while(x>0)
			{
				sum=sum+(x%10);
				x=x/10;
			}
			return sum;
		}

		string Code_PostNet()
		{
			string freturn="51";
			for(int i=0;i<FText.Length;i++)
			{
				freturn=freturn+table_PostNet[Convert.ToInt32(FText[i].ToString())];
			}
			return freturn+"5";
		}

		string SetLen(byte PI)
		{
			string freturn;
			freturn=FText;
			while(freturn.Length<PI)
				freturn="0"+freturn;
			return freturn;
		}

		string Code_Codabar()
		{
			int idx;
			string freturn;

			CreateTable_cb();
			freturn=table_cb[Find_Codabar('A')].data+"0";
			for(int i=0;i<FText.Length;i++)
			{
				idx=Find_Codabar(FText[i]);
				freturn=freturn+table_cb[idx].data+"0";
			}
			return freturn+table_cb[Find_Codabar('B')].data;
		}

		int Find_Codabar(char c)
		{
			for(int i=0;i<table_cb.Length;i++)
			{
				if(c==table_cb[i].c)
				{
					return i;
				}
			}
			return -1;
		}

		void CreateTable_cb()
		{
			table_cb[0].c='1'; table_cb[0].data="5050615"  ;
			table_cb[1].c='2'; table_cb[1].data="5051506"  ;
			table_cb[2].c='3'; table_cb[2].data="6150505"  ;
			table_cb[3].c='4'; table_cb[3].data="5060515"  ;
			table_cb[4].c='5'; table_cb[4].data="6050515"  ;
			table_cb[5].c='6'; table_cb[5].data="5150506"  ;
			table_cb[6].c='7'; table_cb[6].data="5150605"  ;
			table_cb[7].c='8'; table_cb[7].data="5160505"  ;
			table_cb[8].c='9'; table_cb[8].data="6051505"  ;
			table_cb[9].c='0'; table_cb[9].data="5050516"  ;
			table_cb[10].c='-'; table_cb[10].data="5051605"  ;
			table_cb[11].c='$'; table_cb[11].data="5061505"  ;
			table_cb[12].c='='; table_cb[12].data="6050606"  ;
			table_cb[13].c='/'; table_cb[13].data="6060506"  ;
			table_cb[14].c='.'; table_cb[14].data="6060605"  ;
			table_cb[15].c='+'; table_cb[15].data="5060606"  ;
			table_cb[16].c='A'; table_cb[16].data="5061515"  ;
			table_cb[17].c='B'; table_cb[17].data="5151506"  ;
			table_cb[18].c='C'; table_cb[18].data="5051516"  ;
			table_cb[19].c='D'; table_cb[19].data="5051615"  ;
		}

		string Code_EAN8()
		{
			string tmp;
			string freturn;
			if(FCheckSum)
			{
				tmp=SetLen(7);
				tmp=DoCheckSumming(tmp.Substring(tmp.Length-7,7));
			}
			else
				tmp=SetLen(8);
			if(tmp.Length!=8)
				throw new Exception("Invalid Text length (EAN8)");
			freturn="505";
			for(int i=0;i<4;i++)
				freturn=freturn+table_EAN_A[Convert.ToInt32(tmp[i].ToString())];
			freturn=freturn+"05050";
			for(int i=4;i<8;i++)
				freturn=freturn+table_EAN_C[Convert.ToInt32(tmp[i].ToString())];
			return freturn+"505";
		}

		string Code_UPC_A()
		{
			string tmp,freturn;
			FText=SetLen(12);
			tmp="";
			if(FCheckSum)
				tmp=DoCheckSumming(FText.Substring(0,11));
			if(FCheckSum)
				FText=tmp;
			else
				tmp=FText;
			freturn="505";
			for(int i=0;i<6;i++)
				freturn=freturn+table_EAN_A[Convert.ToInt32(tmp[i].ToString())];
			freturn=freturn+"05050";
			for(int i=6;i<12;i++)
				freturn=freturn+table_EAN_C[Convert.ToInt32(tmp[i].ToString())];
			return freturn+"505";
		}

		string Code_EAN13()
		{
			string tmp;
			string freturn;
			int LK;

			if(FCheckSum)
			{
				tmp=SetLen(12);
				tmp=DoCheckSumming(tmp);
			}
			else
				tmp=SetLen(13);
			if(tmp.Length!=13)
				throw new Exception("Invalid Text length (EAN13)");
			LK=Convert.ToInt32(tmp[0].ToString());
			tmp=tmp.Substring(1,12);
			freturn="505";
			for(int i=0;i<6;i++)
			{
				switch(table_ParityEAN13[LK,i])
				{
					case 'A':
						freturn=freturn+table_EAN_A[Convert.ToInt32(tmp[i].ToString())];
						break;
					case 'B':
						freturn=freturn+table_EAN_B[Convert.ToInt32(tmp[i].ToString())];
						break;
					case 'C':
						freturn=freturn+table_EAN_C[Convert.ToInt32(tmp[i].ToString())];
						break;
				}
			}
			freturn=freturn+"05050";
			for(int i=6;i<12;i++)
				freturn=freturn+table_EAN_C[Convert.ToInt32(tmp[i].ToString())];
			return freturn+"505";
		}

		void OneBarProps(char code,out int Width,out BarLineType lt)
		{
			switch(code)
			{
				case '0':
					Width=modules[0];
					lt=BarLineType.white;
					break;
				case '1':
					Width=modules[1];
					lt=BarLineType.white;
					break;
				case '2':
					Width=modules[2];
					lt=BarLineType.white;
					break;
				case '3':
					Width=modules[3];
					lt=BarLineType.white;
					break;

				case '5':
					Width=modules[0];
					lt=BarLineType.black;
					break;
				case '6':
					Width=modules[1];
					lt=BarLineType.black;
					break;
				case '7':
					Width=modules[2];
					lt=BarLineType.black;
					break;
				case '8':
					Width=modules[3];
					lt=BarLineType.black;
					break;

				case 'A':
					Width=modules[0];
					lt=BarLineType.black_half;
					break;
				case 'B':
					Width=modules[1];
					lt=BarLineType.black_half;
					break;
				case 'C':
					Width=modules[2];
					lt=BarLineType.black_half;
					break;
				case 'D':
					Width=modules[3];
					lt=BarLineType.black_half;
					break;
				default:
					throw new Exception("Internal error");
			}
		}

		protected string MakeData()
		{
			MakeModules();
			if(FText!=null)
			{
				if(BCData[(int)Typ].Num)
				{
				
					FText=FText.Trim();
					for(int i=0;i<FText.Length;i++)
						if((FText[i]>'9')||(FText[i]<'0'))					
							throw new Exception("Barcode must be numeric");
				
				}
				switch(Typ)
				{
					case BarcodeType.Code_2_5_interleaved:
						return Code_2_5_interleaved();
					case BarcodeType.Code_2_5_industrial:
						return Code_2_5_industrial();
					case BarcodeType.Code_2_5_matrix:
						return Code_2_5_matrix();
					case BarcodeType.Code39:
						return Code_39();
					case BarcodeType.Code39Extended:
						return Code_39Extended();
					case BarcodeType.Code128A:
						goto case BarcodeType.CodeEAN128C;
					case BarcodeType.Code128B:
						goto case BarcodeType.CodeEAN128C;
					case BarcodeType.Code128C:
						goto case BarcodeType.CodeEAN128C;
					case BarcodeType.CodeEAN128A:
						goto case BarcodeType.CodeEAN128C;
					case BarcodeType.CodeEAN128B:
						goto case BarcodeType.CodeEAN128C;
					case BarcodeType.CodeEAN128C:
						return Code_128();
					case BarcodeType.Code93:
						return Code_93();
					case BarcodeType.Code93Extended:
						return Code_93Extended();
					case BarcodeType.CodeMSI:
						return Code_MSI();
					case BarcodeType.CodePostNet:
						return Code_PostNet();
					case BarcodeType.CodeCodabar:
						return Code_Codabar();
					case BarcodeType.CodeEAN8:
						return Code_EAN8();
					case BarcodeType.CodeEAN13:
						return Code_EAN13();
					case BarcodeType.CodeUPC_A:
						return Code_UPC_A();
					case BarcodeType.CodeUPC_E0:
						return Code_UPC_E0();
					case BarcodeType.CodeUPC_E1:
						return Code_UPC_E1();
					case BarcodeType.CodeUPC_Supp2:
						return Code_Supp2();
					case BarcodeType.CodeUPC_Supp5:
						return Code_Supp5();
					default:
						throw new Exception("wrong BarcodeType");
				}
			}
			return "";
		}

		string Code_Supp5()
		{
			string tmp,freturn;
			char c;

			FText=SetLen(5);
			tmp=GetSupp(FText.Substring(0,5)+"0");
			c=tmp[5];
			if(FCheckSum)
				FText=tmp;
			else
				tmp=FText;
			freturn="506";
			for(int i=0;i<5;i++)
			{
				if(table_UPC_E0[Convert.ToInt32(c.ToString()),(6-5)+i]=='E')
				{
					for(int j=0;j<4;j++)
						freturn=freturn+table_EAN_C[Convert.ToInt32(tmp[i].ToString())][3-j].ToString();
				}
				else
				{
					freturn=freturn+table_EAN_A[Convert.ToInt32(tmp[i].ToString())];
				}
				if(i<4)
					freturn=freturn+"05";
			}
			return freturn;
		}

		string Code_Supp2()
		{
			string tmp,mS,freturn;
			int i;

			FText=SetLen(2);
			i=Convert.ToInt32(FText);
			mS="";
			switch (i%4)
			{
				case 3:
					mS="EE";
					break;
				case 2:
					mS="Eo";
					break;
				case 1:
					mS="oE";
					break;
				case 0:
					mS="oo";
					break;
			}
			tmp=GetSupp(FText.Substring(0,2)+"0");
			if(FCheckSum)
				FText=tmp;
			else
				tmp=FText;
			freturn="506";
			for(i=0;i<2;i++)
			{
				if(mS[i]=='E')
				{
					for(int j=0;j<4;j++)
						freturn=freturn+table_EAN_C[Convert.ToInt32(tmp[i].ToString())][3-j].ToString();
				}
				else
				{
					freturn=freturn+table_EAN_A[Convert.ToInt32(tmp[i].ToString())];
				}
				if(i<1)
					freturn=freturn+"05";
			}
			return freturn;
		}

		string GetSupp(string Nr)
		{
			int fak,sum;
			string tmp;

			sum=0;
			tmp=Nr.Substring(0,Nr.Length-1);
			fak=tmp.Length;
			for(int i=0;i<tmp.Length;i++)
			{
				if(fak%2==0)
					sum=sum+(Convert.ToInt32(tmp[i].ToString())*9);
				else
					sum=sum+(Convert.ToInt32(tmp[i].ToString())*3);
				fak--;
			}
			sum=((sum%10)%10)%10;
			return tmp+sum.ToString();
		}

		string Code_UPC_E1()
		{
			string tmp,freturn;
			char c;

			FText=SetLen(7);
			tmp=DoCheckSumming(FText.Substring(0,6));
			c=tmp[6];
			if(FCheckSum)
				FText=tmp;
			else
				tmp=FText;
			freturn="505";
			for(int i=0;i<6;i++)
			{
				if(table_UPC_E0[Convert.ToInt32(c.ToString()),i]=='E')
				{	
					freturn=freturn+table_EAN_A[Convert.ToInt32(tmp[i].ToString())];
				}
				else
				{
					for(int j=0;j<4;j++)
						freturn=freturn+table_EAN_C[Convert.ToInt32(tmp[i].ToString())][3-j].ToString();
				}
			}
			return freturn+"050505";
		}

		string Code_UPC_E0()
		{
			string tmp,freturn;
			char c;

			FText=SetLen(7);
			tmp=DoCheckSumming(FText.Substring(0,6));
			c=tmp[6];
			if(FCheckSum)
				FText=tmp;
			else
				tmp=FText;
			freturn="505";
			for(int i=0;i<6;i++)
			{
				if(table_UPC_E0[Convert.ToInt32(c.ToString()),i]=='E')
				{
					for(int j=0;j<4;j++)
						freturn=freturn+table_EAN_C[Convert.ToInt32(tmp[i].ToString())][3-j].ToString();
				}
				else
				{
					freturn=freturn+table_EAN_A[Convert.ToInt32(tmp[i].ToString())];
				}
			}
			return freturn+"050505";
		}

		protected void DoChange()
		{
			if(Change!=null)
				Change(this,EventArgs.Empty);
		}

		void CreateData()
		{
			BCData[0].Name="2_5_interleaved";
			BCData[0].Num=true;
			BCData[1].Name="2_5_industrial";
			BCData[1].Num=true;
			BCData[2].Name="2_5_matrix";
			BCData[2].Num=true;
			BCData[3].Name="Code39";
			BCData[3].Num=false;
			BCData[4].Name="Code39 Extended";
			BCData[4].Num=false;
			BCData[5].Name="Code128A";
			BCData[5].Num=false;
			BCData[6].Name="Code128B";
			BCData[6].Num=false;
			BCData[7].Name="Code128C";
			BCData[7].Num=true;
			BCData[8].Name="Code93";
			BCData[8].Num=false;
			BCData[9].Name="Code93 Extended";
			BCData[9].Num=false;
			BCData[10].Name="MSI";
			BCData[10].Num=true;
			BCData[11].Name="PostNet";
			BCData[11].Num=true;
			BCData[12].Name="Codebar";
			BCData[12].Num=false;
			BCData[13].Name="EAN8";
			BCData[13].Num=true;
			BCData[14].Name="EAN13";
			BCData[14].Num=true;
			BCData[15].Name="UPC_A";
			BCData[15].Num=true;
			BCData[16].Name="UPC_E0";
			BCData[16].Num=true;
			BCData[17].Name="UPC_E1";         
			BCData[17].Num=true;
			BCData[18].Name="UPC Supp2";
			BCData[18].Num=true;
			BCData[19].Name="UPC Supp5";
			BCData[19].Num=true;
			BCData[20].Name="EAN128A";
			BCData[20].Num=false;
			BCData[21].Name="EAN128B";
			BCData[21].Num=false;
			BCData[22].Name="EAN128C";
			BCData[22].Num=true;
		}
		#endregion

		#region class properties
		[DefaultValue(false)]
		public bool CheckSum
		{
			get
			{
				return FCheckSum;
			}
			set
			{
				if(value!=FCheckSum)
				{
					FCheckSum=value;
					DoChange();
				}
			}
		}

		[DefaultValue(CheckSumMethod.Modulo10)]
		public CheckSumMethod CheckSumMethod
		{
			get
			{
				return FCheckSumMethod;
			}
			set
			{
				FCheckSumMethod=value;
			}
		}

		public Color Color
		{
			get
			{
				return FColor;
			}
			set
			{
				FColor=value;
			}
		}

		public Color ColorBar
		{
			get
			{
				return FColorBar;
			}
			set
			{
				FColorBar=value;
			}
		}

		public int Height
		{
			get
			{
				return FHeight;
			}
			set
			{
				if(value!=FHeight)
				{
					FHeight=value;
					DoChange();
				}
			}
		}

		public int Left
		{
			get
			{
				return FLeft;
			}
			set
			{
				if(value!=FLeft)
				{
					FLeft=value;
					DoChange();
				}
			}
		}

		public int Modul
		{
			get
			{
				return FModul;
			}
			set
			{
				if((value>=1)&&(value<50))
				{
					FModul=value;
					DoChange();
				}
			}
		}

		public double Ratio
		{
			get
			{
				return FRatio;
			}
			set
			{
				if(value!=FRatio)
				{
					FRatio=value;
					DoChange();
				}
			}
		}

		[DefaultValue(BarcodeOption.None)]
		public BarcodeOption ShowText
		{
			get
			{
				return FShowText;
			}
			set
			{
				if(value!=FShowText)
				{
					FShowText=value;
					DoChange();
				}
			}
		}

		public Font ShowTextFont
		{
			get
			{
				return FShowTextFont;
			}
			set
			{
				FShowTextFont=value;
				DoChange();
			}
		}

		public ShowTextPosition ShowTextPosition
		{
			get
			{
				return FShowTextPosition;
			}
			set
			{
				if(value!=FShowTextPosition)
				{
					FShowTextPosition=value;
					DoChange();
				}
			}
		}

		public string Text
		{
			get
			{
				return FText;
			}
			set
			{
				if(value!=FText)
				{
					FText=value;
					DoChange();
				}
			}
		}

		public int Top
		{
			get
			{
				return FTop;
			}
			set
			{
				if(value!=FTop)
				{
					FTop=value;
					DoChange();
				}
			}
		}

		[DefaultValue(BarcodeType.Code_2_5_interleaved)]
		public BarcodeType Typ
		{
			get
			{
				return FTyp;
			}
			set
			{
				if(value!=FTyp)
				{
					FTyp=value;
					DoChange();
				}
			}
		}

		public int Width
		{
			get
			{
				string data;
				int freturn=0;
				int w;
				BarLineType lt;

				data=MakeData();
				for(int i=0;i<data.Length;i++)
				{
					OneBarProps(data[i],out w,out lt);
					freturn=freturn+w;
				}
				return freturn;
			}
			set
			{
				string data;
				int w,wtotal;
				BarLineType lt;
				wtotal=0;

				data=MakeData();
				for(int i=0;i<data.Length;i++)
				{
					OneBarProps(data[i],out w,out lt);
					wtotal=wtotal+w;
				}
				if(wtotal>0)
					Modul=((FModul*value)/wtotal);
			}
		}

		public Color ForeColor
		{
			get
			{
				return FForeColor;
			}
			set
			{
				FForeColor=value;
			}
		}

		public double Angle
		{
			get
			{
				return FAngle;
			}
			set
			{
				if(value!=FAngle)
				{
					FAngle=value;
					DoChange();
				}
			}
		}
		#endregion
	}
	#endregion

	#region enums
	public enum BarcodeType
	{
		Code_2_5_interleaved,
		Code_2_5_industrial,
		Code_2_5_matrix,
		Code39,
		Code39Extended,
		Code128A,
		Code128B,
		Code128C,
		Code93,
		Code93Extended,
		CodeMSI,
		CodePostNet,
		CodeCodabar,
		CodeEAN8,
		CodeEAN13,
		CodeUPC_A,
		CodeUPC_E0,
		CodeUPC_E1,
		CodeUPC_Supp2,    // UPC 2 digit supplemental
		CodeUPC_Supp5,    // UPC 5 digit supplemental 
		CodeEAN128A,
		CodeEAN128B,
		CodeEAN128C
	}

	public enum CheckSumMethod
	{
		None,Modulo10
	}

	// black_half means a black line with 2/5 height (used for PostNet)
	internal enum BarLineType
	{
		white, black, black_half
	}

	//Type of text to show 
	public enum BarcodeOption
	{
		None,Code,Typ,Both
	}

	public enum ShowTextPosition
	{
		TopLeft,
		TopRight,
		TopCenter,
		BottomLeft,
		BottomRight,
		BottomCenter
	}
	#endregion

	#region structs
	struct Data
	{
		public string Name;
		public bool Num;
	}
	struct Code39
	{
		public char c;
		public string data;
		public sbyte chk;
	}

	struct Code_128
	{
		public char a,b;
		public string c,data;
	}

	struct Code93
	{
		public char c;
		public string data;
	}

	struct Codabar
	{
		public char c;
		public string data;
	}
	#endregion
}
