using System;
using System.Drawing;

namespace Tetris.NET
{
	/// <summary>
	/// Summary description for Blocks.
	/// </summary>
	public class Block
	{
		public Block()
		{
			//
			// TODO: Add constructor logic here
			//
		}
// Block defined as offsets from start (lart character back from start)
// 0 - Left
// 1 - Down
// 2 - Right
// 3 - Up

public Color BlockCol;
public int CurX;
public int CurY;
private int[,] BlockMatrix = {{0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}};

		public void Create()
		{
			System.Random randomNumber = new System.Random();

			int intBlockType;
			intBlockType = randomNumber.Next() % 7;

			switch (intBlockType)
			{
				case 0:
					BlockCol = Color.Blue;
					BlockMatrix[1, 0] = 1;
					BlockMatrix[1, 1] = 1;
					BlockMatrix[1, 2] = 1;
					BlockMatrix[1, 3] = 1;
					break;
				case 1:
					BlockCol = Color.Red;
					BlockMatrix[2, 1] = 1;
					BlockMatrix[1, 1] = 1;
					BlockMatrix[1, 2] = 1;
					BlockMatrix[2, 2] = 1;
					break;
				case 2:
					BlockCol = Color.Green;
					BlockMatrix[1, 0] = 1;
					BlockMatrix[1, 1] = 1;
					BlockMatrix[1, 2] = 1;
					BlockMatrix[2, 0] = 1;
					break;
				case 3:
					BlockCol = Color.Yellow;
					BlockMatrix[1, 0] = 1;
					BlockMatrix[1, 1] = 1;
					BlockMatrix[1, 2] = 1;
					BlockMatrix[2, 2] = 1;
					break;
				case 4:
					BlockCol = Color.Purple;
					BlockMatrix[1, 0] = 1;
					BlockMatrix[1, 1] = 1;
					BlockMatrix[2, 1] = 1;
					BlockMatrix[2, 2] = 1;
					break;
				case 5:
					BlockCol = Color.DarkSalmon;
					BlockMatrix[1, 1] = 1;
					BlockMatrix[1, 2] = 1;
					BlockMatrix[2, 1] = 1;
					BlockMatrix[2, 0] = 1;
					break;
				case 6:
					BlockCol = Color.YellowGreen;
					BlockMatrix[1, 1] = 1;
					BlockMatrix[1, 2] = 1;
					BlockMatrix[1, 0] = 1;
					BlockMatrix[2, 1] = 1;
					break;
			}

		}

		public void Rotate()
		{
			int[,] TempMatrix= {{0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}, {0, 0, 0, 0}};

			int q; 
			int w;
			for (q = 0;q<=3;q++)
			{
				for (w = 0; w<=3;w++)
				{
					TempMatrix[q, w] = BlockMatrix[w, 3 - q];
				}
			}
			BlockMatrix = TempMatrix;
		}

		public void Unrotate()
		{
			int q;
			for (q = 1;q<= 3;q++)
			{
				Rotate();
			}
		}

		public string ReturnBlock()
		{
			//Return String with block coordinates delimited by //#//
			int q;
			int w;
			string ReturnString = "";

			for (q = 0;q<=3;q++)
			{
				for (w = 0;w<=3;w++)
				{
					if (BlockMatrix[q, w] == 1)
					{

						if (ReturnString != "")
						{
							ReturnString = ReturnString + "#";
						}

						ReturnString += (q + CurX).ToString() + "," + (w + CurY).ToString();

					}
				}
			}

			return ReturnString;
		}

		public void MoveLeft()
		{
			CurX = CurX - 1;
		}

		public void MoveRight()
		{
			CurX = CurX + 1;
		}

		public void MoveDown()
		{
			CurY = CurY + 1;
		}

	}
}
