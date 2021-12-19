using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.IO;

namespace csSnakeGame
{
	/// <summary>
	/// Summary description for clsSnake.
	/// </summary>
	public class clsSnake
	{
		private clsGridPoint mcGridSize;
		private PictureBox mcPic;
		private System.Collections.ArrayList mcQueuedMoves = new System.Collections.ArrayList();
		private System.Collections.ArrayList mcSnakeBody = new System.Collections.ArrayList();
		//private clsGridPoint mNextMove;
		private int miCellWidthPx;
		private int miCellHeightPx;
		private clsGridPoint mcNextMove; 
		private clsGridPoint mcHeadCell;
		private int mlSnakeLength;
		private Color mCellColor;
		private clsGridPoint mcFlyCell;
		private PictureBox mcFlyPic;

		private bool mbGameOver = false;
		private int mlScore = 0;

		public clsSnake(int lBoardWidth, int lBoardHeight, int lInitSnakeLength, System.Windows.Forms.PictureBox oPic, System.Windows.Forms.PictureBox oPicFly)
		{
			mCellColor = Color.FromArgb(58, 110, 165);
			mcGridSize = new clsGridPoint();
			mcGridSize.gridX = lBoardWidth;
			mcGridSize.gridY = lBoardHeight;
			mcFlyPic = oPicFly;
			mcPic = oPic;
			Graphics oGC;
			oGC = mcPic.CreateGraphics();
			oGC.Clear(mcPic.BackColor);
			oGC.Dispose();
			
			mlSnakeLength = lInitSnakeLength;
			
			miCellWidthPx = Convert.ToInt16(mcPic.ClientRectangle.Width / lBoardWidth);
			miCellHeightPx = Convert.ToInt16(mcPic.ClientRectangle.Height / lBoardHeight);
			
			mcHeadCell = new clsGridPoint();
			mcHeadCell.gridX = Convert.ToInt16(mcGridSize.gridX / 2);
			mcHeadCell.gridY = Convert.ToInt16(mcGridSize.gridY / 2);
			
			AddToSnakeBody(mcHeadCell.clone());
			
			createFly();
		}

		public int Score()
		{
			return mlScore;
		}
		public bool GameOver()
		{
			return mbGameOver;
		}
		private void createFly()
		{
			mcFlyCell = new clsGridPoint();
			System.Random rnd = new System.Random();
			
			do
			{
				mcFlyCell.gridX = Convert.ToInt16(Math.Round((rnd.NextDouble() * mcGridSize.gridX))) + 1;
				mcFlyCell.gridY = Convert.ToInt16(Math.Round((rnd.NextDouble() * mcGridSize.gridY))) + 1;
			}
			while (IsNotOccupied(mcFlyCell)==false || IsInBounds(mcFlyCell)==false);

			PaintSnakeCell(mcFlyCell, System.Drawing.Color.White, true);
		}

		private bool IsInBounds(clsGridPoint oPt)
		{
			bool bRet;
			bRet = true;
			if (oPt.gridX < 1) 
			{
				bRet = false;
			}
			if (oPt.gridY < 1) 
			{
				bRet = false;
			}
			if (oPt.gridX > mcGridSize.gridX) 
			{
				bRet = false;
			}
			if ( oPt.gridY > mcGridSize.gridY ) 
			{
				bRet = false;
			}
			return bRet;
		}

		private bool IsNotOccupied(clsGridPoint oPt)
		{
			//clsGridPoint cCell;
			bool bRet;
			bRet = true;
			foreach (clsGridPoint cCell in mcSnakeBody)
			{
				if (cCell.isEqualTo(oPt)) 
				{
					bRet = false;
				}
			}
			return bRet;
		}

		public void applyNextMove()
		{
			//Point cMovePt;
	
			if (mcQueuedMoves.Count > 0) 
			{
				mcNextMove = (clsGridPoint)(mcQueuedMoves[0]);
				mcQueuedMoves.RemoveAt(0);
			}
			mcHeadCell.offsetBy(mcNextMove);
			if (IsInBounds(mcHeadCell) == false)
			{
				mbGameOver = true;
			}
			if (IsNotOccupied(mcHeadCell) == false)
			{
				mbGameOver = true;
			}
			if (mbGameOver == false)
			{
				AddToSnakeBody(mcHeadCell.clone());

				//Clear end of snake
				clsGridPoint oPt;
				while (mcSnakeBody.Count > mlSnakeLength)
				{
					oPt = (clsGridPoint)(mcSnakeBody[0]);
					PaintSnakeCell(oPt, mcPic.BackColor, false);
					mcSnakeBody.RemoveAt(0);
				}
				// while (mcSnakeBody.Count > mlSnakeLength);

				int i;
				Color oThisColor;
				int iRed;
				int iGreen;
				int iBlue;
				//int iAlpha;
				iRed = mCellColor.R;
				iGreen = mCellColor.G;
				iBlue = mCellColor.B;
		
				for (i = mcSnakeBody.Count - 1; i >= 0; i--)
				{
					oThisColor = Color.FromArgb(iRed, iGreen, iBlue);
					PaintSnakeCell((clsGridPoint)(mcSnakeBody[i]), oThisColor, false);
					iBlue = Convert.ToInt16(iBlue * 0.95);
					iGreen = Convert.ToInt16(iGreen * 0.95);
					iRed = Convert.ToInt16(iRed * 0.95);
				}

				if (mcFlyCell.isEqualTo(mcHeadCell)) 
				{
					mlScore = mlScore + 1;
					createFly();
					mlSnakeLength = mlSnakeLength + 2;
					
					Beep(200,200);
				} 
			} 
		}

		[System.Runtime.InteropServices.DllImportAttribute("kernel32.dll")]
		public static extern int Beep(int freq, int duration);

		public void PaintSnake()
		{
			int i;
			clsGridPoint oPt;
			Color oThisColor = mCellColor;
			for (i = 0; i <= mcSnakeBody.Count - 1;i++)
			{				
				oPt = (clsGridPoint)(mcSnakeBody[i]);
				PaintSnakeCell(oPt, oThisColor, false);
			}
		}

		public string SnakeBodyDump()
		{
			int i;
			clsGridPoint oPt;
			string sOut = "";
			for (i = 0; i <= mcSnakeBody.Count - 1; i++)
			{
				oPt = (clsGridPoint)(mcSnakeBody[i]);
				sOut = sOut + oPt.debugText();
			}
			
			return sOut;
		}

		public string QueuedMovesDump()
		{
			int i;
			clsGridPoint oPt;
			string sOut = "";
			for (i = 0; i <= mcQueuedMoves.Count - 1; i++)
			{
				oPt = (clsGridPoint)(mcQueuedMoves[i]);
				sOut = sOut + oPt.debugText();
			}
			return sOut;
		}

		public void addMove(int deltaX, int deltaY)
		{
			clsGridPoint oPt = new clsGridPoint();
			oPt.gridX = deltaX;
			oPt.gridY = deltaY;
			mcQueuedMoves.Add(oPt);
		}


		private void AddToSnakeBody(clsGridPoint oPt)
		{
			mcSnakeBody.Add(oPt);
		}

		private void PaintSnakeCell(clsGridPoint oGridPt, Color oColor, bool bAsFly)
		{
			Graphics oGC;
			oGC = mcPic.CreateGraphics();		
			Rectangle oRect = new Rectangle((oGridPt.gridX - 1) * miCellWidthPx,(oGridPt.gridY - 1) * miCellHeightPx,miCellWidthPx, miCellHeightPx);
			Pen oPen = new Pen(oColor);
			
			oGC.FillRectangle(oPen.Brush, oRect);

			if (bAsFly==true)
			{
				Bitmap bug2 = new Bitmap(Environment.CurrentDirectory + Path.DirectorySeparatorChar + "Bitmap1.bmp");
				Image oFly = (System.Drawing.Image)(bug2);

				oGC.DrawImage(oFly, oRect);
			}

			oPen.Dispose();
			oGC.Dispose();
		}
	}

	public class clsGridPoint
	{
		private int miGridX;
		private int miGridY;

		public int gridX
		{
			get
			{
				return miGridX;
			}
			set
			{
				miGridX = value;
			}
		}

		
		public int gridY
		{
			get
			{
				return miGridY;
			}
			set
			{
				miGridY = value;
			}
		}

		public bool isEqualTo(clsGridPoint cPt)
		{
			if (this.gridX == cPt.gridX && this.gridY == cPt.gridY) 
			{
				return true;
			}
			return false;
		}

		public void offsetBy(clsGridPoint cPt)
		{
			miGridX = miGridX + cPt.gridX;
			miGridY = miGridY + cPt.gridY;
		}

		public clsGridPoint clone()
		{
			clsGridPoint cRet = new clsGridPoint();
			cRet.gridX = miGridX;
			cRet.gridY = miGridY;
			return cRet;
		}

		public string debugText()
		{
			return "(" + Convert.ToString(this.gridX) + "," + Convert.ToString(this.gridY) + ")";
		}
	}
}
