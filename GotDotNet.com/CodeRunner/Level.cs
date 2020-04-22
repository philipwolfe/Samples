//#define DEBUGLEVELS

using System;
using System.IO;
using System.Collections;

namespace CodeRunner
{
	public class Level
	{
		private static string m_strPuzzleFile = Constants.APP_DIR + @"Levels\Original.pzl";
		//private string m_strPuzzleFile = "Champion.pzl";

		public Level()
		{
		}

#if !DEBUGLEVELS
		// reads an SCL file
		public int GetLevelCount()
		{
			//open the file as a binary stream
			string strFile = m_strPuzzleFile;
			FileStream fil = System.IO.File.OpenRead( strFile );
			
			//determine if we have the appropriate number of levels
			fil.Seek(0x66, System.IO.SeekOrigin.Current);
			int nLevels = fil.ReadByte();

			fil.Close();

			return nLevels;
		}

		public void SetLevelFile(string strLevelFile)
		{
			m_strPuzzleFile = strLevelFile;
		}

		public void LoadLevel(int nLevel)
		{
			m_nLevel = nLevel;

			//determine if we have the appropriate number of levels
			if (nLevel>GetLevelCount())
				throw new Exception("Invalid level number.");
			
			//open the file as a binary stream
			string strFile = m_strPuzzleFile;
			FileStream fil = System.IO.File.OpenRead( strFile );
			
			// skip the header
			fil.Seek(112, System.IO.SeekOrigin.Current);

			int nCount = 0;
			long lBufferlen;
			do
			{
				// length of compressed puzzle
				lBufferlen = (fil.ReadByte()) + (fil.ReadByte() * 256);
				fil.ReadByte(); fil.ReadByte();
				int nPuzzlenum = fil.ReadByte();
				fil.ReadByte();

				nCount++;
				if (nCount<nLevel)
					fil.Seek(lBufferlen, System.IO.SeekOrigin.Current);
			} while (nCount<nLevel);
			
			fil.ReadByte();  //01
			fil.ReadByte();  //00

			int nBufferlen = (int)lBufferlen-2;

			// read the entire stream
			byte [] bufPuzzle = new byte[nBufferlen];
			fil.Read(bufPuzzle, 0, (int)nBufferlen);
			
			// decompress the buffer stream using RLL
			byte [] largeBuffer = new byte[10000];
			int nDecodeLen = DecompressRLLBuffer( bufPuzzle, nBufferlen, ref largeBuffer );

			TranslateBufferIntoLevel(ref largeBuffer);

			fil.Close();
		}

		private int DecompressRLLBuffer( byte[] inThin, long lLength, ref byte[] largeBuffer )
		{
			int nPos = 0;
			int nRetPos = 0;
			while (nPos<lLength)
			{
				//read header
				byte nHeader = inThin[nPos++];
				
				//if we have a string
				if (nHeader!=0)
				{
					if (nHeader==0xFF)
					{
						int nStrLen = inThin[nPos++];
						for (int n=0; n<nStrLen; n++)
							largeBuffer[nRetPos++] = inThin[nPos++];
					}
					else
					{
						// the header bit is the repeat bit
						byte nRepeat = nHeader;
						byte nChar = inThin[nPos++];
						for (int n=0; n<(int)nRepeat; n++)
							largeBuffer[nRetPos++] = nChar;
					}
				}
			}

			return nRetPos;
		}

		private void TranslateBufferIntoLevel(ref byte[] largeBuffer)
		{
			m_lstMonks = new ArrayList();
			m_lstGold = new ArrayList();
			m_aGrid = new Element[Constants.BOARD_HEIGHT,Constants.BOARD_WIDTH];

			// first, map the grid
			for (int y=0; y<Constants.BOARD_HEIGHT; y++)
			{
				for (int x=0; x<Constants.BOARD_WIDTH; x++)
				{
					byte b1, b2, b8, b9;
					GetBits( ref largeBuffer, x, y, out b1, out b2, out b8, out b9 );

					if (b8==1 && b9==1)
						m_aGrid[y, x] = Element.Brick;
					else if (b8==2 && b9==6)
						m_aGrid[y, x] = Element.Trick;
					else if (b8==6 && b9==1)
						m_aGrid[y, x] = Element.Rope;
					else if (b8==1 && b9==2)
						m_aGrid[y, x] = Element.Stone;
					else if (b8==5 && b9==1)
						m_aGrid[y, x] = Element.Ladder;
					else if (b8==5 && b9==2)
						m_aGrid[y, x] = Element.Escape;
					else if (b1==4 && b2==1)
					{
						Vector vecGold = new Vector();
						vecGold.XPos = x;
						vecGold.YPos = y;
						AddGold(vecGold);
					}
				}
			}

			// add the hero
			m_posHero.XPos = (int)largeBuffer[0x1EA6]-1;
			m_posHero.YPos = (int)largeBuffer[0x1EA7]-1;

			// add the monks
			int nMonkCount = (int)largeBuffer[0x1EAC];
			for (int n=0; n<nMonkCount; n++)
			{
				Vector vecMonk = new Vector();
				vecMonk.XPos = (int)largeBuffer[0x1eb1 + (6*n)]-1;
				vecMonk.YPos = (int)largeBuffer[0x1eb1 + (6*n) + 1]-1;
				AddMonk(vecMonk);
			}
		}

		private void GetBits(ref byte[] largeBuffer, int x, int y, out byte b1, out byte b2, out byte b8, out byte b9)
		{
			int nOffset = 0x11b;
			int nLayerSize = 30 * 18;

			b1 = largeBuffer[nOffset + (0 * nLayerSize) + ((x+1) * 18) + y];
			b2 = largeBuffer[nOffset + (1 * nLayerSize) + ((x+1) * 18) + y];
			b8 = largeBuffer[nOffset + (7 * nLayerSize) + ((x+1) * 18) + y];
			b9 = largeBuffer[nOffset + (8 * nLayerSize) + ((x+1) * 18) + y];
		}
#endif


		#region Old Code
#if DEBUGLEVELS
		public int GetLevelCount()
		{
			return 1;
		}
			
		public void SetLevelFile(string strLevelFile)
		{
		}
			
		public void LoadLevel(int nLevel)
		{
			m_nLevel = nLevel;

			//open the file
			string strFile = Constants.APP_DIR + @"Levels\Level" + nLevel.ToString() + ".map";
			StreamReader fil = System.IO.File.OpenText( strFile );
			
			//create a new array to contain the types
			m_aGrid = new Element[Constants.BOARD_HEIGHT,Constants.BOARD_WIDTH];

			//read the file for the grid
			for (int y=0; y<Constants.BOARD_HEIGHT; y++)
			{
				string strRow = fil.ReadLine();
				for (int x=0; x<Constants.BOARD_WIDTH; x++)
				{
					switch (strRow[x])
					{
						case 'B': m_aGrid[y,x] = Element.Brick; break;
						case 'L': m_aGrid[y,x] = Element.Ladder; break;
						case 'R': m_aGrid[y,x] = Element.Rope; break;
						case 'S': m_aGrid[y,x] = Element.Stone; break;
						case 'T': m_aGrid[y,x] = Element.Trick; break;
						case 'G': m_aGrid[y,x] = Element.Escape; break;
						default:
							m_aGrid[y,x] = Element.None; break;
					}
				}
			}
			
			//read the start positions for the hero, monks and gold
			m_lstMonks = new ArrayList();
			m_lstGold = new ArrayList();

			string strPos;
			do
			{
				strPos = fil.ReadLine();
				if (strPos!=null && strPos.Length>4)
				{
					switch (strPos.Substring(0,4))
					{
						case "Hero": m_posHero = GetVector(strPos.Substring(5)); break;
						case "Monk": AddMonk( GetVector(strPos.Substring(5)) ); break;
						case "Gold": AddGold( GetVector(strPos.Substring(5)) ); break;
					}
				}
			} while (strPos!=null);
		}

		private Vector GetVector(string strPosition)
		{
			int nComma = strPosition.IndexOf(',');
			string strLeft = strPosition.Substring(0,nComma);
			string strRight = strPosition.Substring(nComma+1);

			Vector vPos = Utility.MakeVector(Int32.Parse(strLeft)-1, Int32.Parse(strRight)-1);
			return vPos;
		}
#endif
		#endregion

		public int LevelNumber
		{
			get { return m_nLevel; }
		}

		public bool IsPositionBlocked(Vector pos)
		{
			if (pos.XPos<0 || pos.XPos>=Constants.BOARD_WIDTH ||
				pos.YPos<0 || pos.YPos>=Constants.BOARD_HEIGHT)
				return true;

			Element at = GetAt(pos.XPos, pos.YPos);
			if (at==Element.Stone || at==Element.Trick)
				return true;

			if (at==Element.Brick)
			{
				// if there's a hole at that position
				if (Game.FindHoleAt(pos)!=-1)
					return false;

				return true;
			}

			return false;
		}

		public bool IsPositionStable(Vector pos)
		{
			int x=pos.XPos; int y=pos.YPos;
			
			Element elAt = this.GetAt(x, y);
			Element elBelow;
			if (y==Constants.BOARD_HEIGHT-1)
				elBelow = Element.Brick;
			else
				elBelow = this.GetAt(x, y+1);

			if ((elAt==Element.None || elAt==Element.Escape || (elAt==Element.Brick && Game.FindHoleAt(pos)!=-1)) && 
				(elBelow!=Element.None && elBelow!=Element.Rope && elBelow!=Element.Trick))
				return true;
			
			if (elAt==Element.Ladder || elAt==Element.Rope)
				return true;

			return false;
		}
		
		public Element GetAt(int XPos, int YPos)
		{
			return m_aGrid[YPos, XPos];			
		}

		public void SetAt(int XPos, int YPos, Element nVal)
		{
			m_aGrid[YPos, XPos] = nVal;
		}

		// starting positions
		public Vector HeroPosition { get { return m_posHero; } }
		public int MonkCount { get { return m_lstMonks.Count; } }
		public Vector MonkPosition(int nIndex) { return (Vector)m_lstMonks[nIndex]; }
		public int GoldCount { get { return m_lstGold.Count; } }
		public Vector GoldPosition(int nIndex) { return (Vector)m_lstGold[nIndex]; }

		// internal implementation
		private void AddMonk(Vector pos)
		{
			m_lstMonks.Add(pos);
		}

		private void AddGold(Vector pos)
		{
			m_lstGold.Add(pos);
		}

		// grid
		private Element[,] m_aGrid;

		// starting positions
		private Vector m_posHero = new Vector();
		private ArrayList m_lstMonks;
		private ArrayList m_lstGold;

		int m_nLevel;
	}
}
