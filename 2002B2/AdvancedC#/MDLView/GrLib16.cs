namespace MdlView
{
	using System;
	using System.IO;

	/// <summary>
	/// Structure for storing details about the edge of a textured triangle
	/// </summary>
	internal struct EdgeScan
	{
		internal int direction;
		internal int remainingScans;
		internal int currentEnd;
		internal double sourceX, sourceY, sourceStepX, sourceStepY;
		internal int destX;
		internal int destXIntStep;
		internal int destXDirection;
		internal int destXErrTerm;
		internal int destXAdjUp;
		internal int destXAdjDown;
	}

	/// <summary>
	/// Class that contains methods and properties for manipulating graphic primitives in 16-bit color
	/// </summary>
	public class GrLib16
	{
		internal short[,] pal16;
		private int currentIndex;
		private int fpaletteCount;
		private int SCREEN_WIDTH;
		private int HALF_SCREEN_WIDTH;
		private int clipMinX, clipMaxX, clipMinY, clipMaxY;
		
		public GrLib16()
	    {
			// Support up to 4 -> 256 color palettes
			pal16 = new short[4, 256];
			fpaletteCount = 0;
			currentIndex = 0;
	    }

		/// <summary>
		/// Property that sets the current palette, used when different meshes have different palettes
		/// </summary>
		/// <remarks>
		/// Quake 2 models are loaded from two .md2 files, each with it's own associated .pcx.  I believe
		/// that, in general, these have the same palette.  However, I've run across a few that don't, so 
		/// this property allows us to still display correctly.  There will have to be some sort of palette
		/// combining done if you want to add support for 8-bit color modes.
		/// </remarks>
		public int paletteIndex
		{
			get
			{
				return currentIndex;
			}
			set
			{
				if (value <= fpaletteCount)
					currentIndex = value;
			}
		}

		/// <summary>
		/// Property that returns and sets the current number of loaded palettes
		/// </summary>
		public int paletteCount
		{
			get
			{
				return fpaletteCount;
			}
			set
			{
				if (fpaletteCount < 4)
					fpaletteCount = value;
			}
		}

		/// <summary>
		/// Sets the screen width in bytes and an internal variable that holds the screen width in shorts
		/// </summary>
		/// <param name="newSize">Contains the size of the screen in bytes</param>
		public void SetSWidth(int newSize)
		{
			SCREEN_WIDTH = newSize;
			HALF_SCREEN_WIDTH = SCREEN_WIDTH / 2;
		}

		/// <summary>
		/// Loads a streamed 256-color palette into an internal structure for later indexing
		/// </summary>
		/// <param name="palette">Contains a 768 (3 * 256) byte 256-color palette given as Red, Green, Blue intensities</param>
		/// <remarks>
		/// This is used for Quake 2 files, streamed from the .pcx skins
		/// </remarks>
		public bool MakePal(byte[] palette)
		{
			int palIndex;

			for(palIndex = 0; palIndex < 256; palIndex++)
			{
				// Notice that we store this palette into Pal16 @ currentIndex, set by the paletteIndex property
				pal16[currentIndex, palIndex] = (short)((palette[palIndex * 3 + 2] >> 3) |
					((palette[palIndex * 3 + 1] >> 3) << 6) |
					((palette[palIndex * 3] >> 3) << 11));
			}

			return true;
		}

		/// <summary>
		/// Loads a 256-color palette from a file
		/// </summary>
		/// <param name="filename">The path and filename of a file that contains a binary Red, Gree, Blue 256-color palette</param>
		/// <remarks>
		/// This is used for Quake I files.  Quake I only has one palette, and the .mdls don't actually contain it, so I added a pal.bin file that has the correct intensities in it.
		/// </remarks>
		public bool MakePal(string filename)
		{
			int palIndex;

			FileInfo fileHandle = new FileInfo(filename);

			if (!fileHandle.Exists)
			{
				return false;
			}
			
			BinaryReader inFile = null;
	
			try
			{
				inFile = new BinaryReader(fileHandle.OpenRead());
				byte[] buffer = new byte[(int)fileHandle.Length];

				buffer = inFile.ReadBytes((int)fileHandle.Length); 

				for(palIndex = 0; palIndex < 256; palIndex++)
				{
					// Notice that we store this palette into Pal16 @ currentIndex, set by the paletteIndex property
					pal16[currentIndex, palIndex] = (short)((buffer[palIndex * 3 + 2] >> 3) |
						((buffer[palIndex * 3 + 1] >> 3) << 6) |
						((buffer[palIndex * 3] >> 3) << 11));
				}
			}
			finally
			{
				inFile.Close();
			}

			return true;
		}

		/// <summary>
		/// Draws a 16-bit horizontal line in a given color
		/// </summary>
		/// <param name="x1">Starting x offset of line</param>
		/// <param name="y1">Starting y offset of line</param>
		/// <param name="xAdvance">Either 1, or -1; if line is being drawn forward or backward</param>
		/// <param name="runLength">The length of the line in pixels</param>
		/// <param name="color">The color of the line</param>
		/// <param name="ddPtr">A pointer to the surface that we're drawing to</param>
		private unsafe void DrawHorizontalRun(ref int x1, ref int y1, int xAdvance, int runLength, short color, short* ddPtr)
		{
			int count;

			ddPtr += y1 * HALF_SCREEN_WIDTH;
			for (count = 0; count < runLength; count++)
			{
				*(ddPtr + x1) = color;
				x1 += xAdvance;
			}
			y1++;
		}

		/// <summary>
		/// Draws a vertical line
		/// </summary>
		/// <param name="x1">Starting x offset of line</param>
		/// <param name="y1">Starting y offset of line</param>
		/// <param name="xAdvance">How far to advance the x offset after the line has been drawn</param>
		/// <param name="runLength">Length of the line</param>
		/// <param name="color">The color of the line</param>
		/// <param name="ddPtr">A pointer to the surface that we're drawing to</param>
		private unsafe void DrawVerticalRun(ref int x1, ref int y1, int xAdvance, int runLength, short color, short* ddPtr)
		{
			int count;
		
			ddPtr += x1;
			for (count = 0; count < runLength; count++)
			{
				*(ddPtr + y1 * HALF_SCREEN_WIDTH) = color;
				y1++;
			}
			x1 += xAdvance;
		}

		/// <summary>
		/// Draws a line by using a run-slice algorithm
		/// </summary>
		/// <param name="x1">Contains the x offset of the first point</param>
		/// <param name="y1">Contains the y offset of the first point</param>
		/// <param name="x2">Contains the x offset of the second point</param>
		/// <param name="y2">Contains the y offset of the second point</param>
		/// <param name="color">Contains the color of the line (red, green, blue)</param>
		/// <param name="ddOffset">An integer specifying the address of the screen buffer</param>
		/// <remarks>
		/// The color paramater doesn't reference any of the palettes.  Therefore if you
		/// want correct distribution of red, green, and blue you'll need to know how you're video
		/// card is set up.  For instance, there are two popular formats that I know about.  The one 
		/// used for the palettes in this sample have 6 bits for red, 5 for green, and 5 for blue.  I 
		/// think the other uses 5 bits for red, 6 for green, and 5 for blue (can't go wrong with blue!).
		/// </remarks>
		public unsafe void LineDraw(int x1, int y1, int x2, int y2, short color, int ddOffset)
		{
			//TODO: Give credit to... Abarash? LaMonte? 
			short* ddPtr = (short*)ddOffset;
			int adjUp, adjDown, errorTerm, temp, xAdvance, xDelta, yDelta, wholeStep,
				initialPixelCount, finalPixelCount, index, runLength;

			
			if (y1 > y2)
			{
				temp = y1;
				y1 = y2;
				y2 = temp;
				temp = x1;
				x1 = x2;
				x2 = temp;
			}

			/* Line Clipping -
				This clipping algorithm is very basic.  Essentially we check to see if we can trivially reject
				line segments (if they are outside of the clip plane).  If they need to be clipped, we simutaneously 
				solve the parametric equations of both the line and the clip edge. */
			
			// y1 or y2 is outside of the clipping plane, we don't need to draw the line
			if ((y1 > clipMaxY) || (y2 < clipMinY)) return;
			// x1 && x2 are outside of the clipping plane, we don't need to draw the line
			if (((x1 > clipMaxX) && (x2 > clipMaxX)) || ((x1 < clipMinX) && (x2 < clipMinX))) return;

			if (y2 > clipMaxY)
			{
				x2 = (int)(x1 + (x2 - x1) * ((float)(clipMaxY - y1) / (y2 - y1)));
				y2 = clipMaxY;
			}
			if (y1 < clipMinY)
			{
				x1 = (int)(x1 + (x2 - x1) * ((float)(clipMinY - y1) / (y2 - y1)));
				y1 = clipMinY;
			}
			if (x1 > clipMaxX)
			{
				y1 = (int)(y1 + (y2 - y1) * ((float)(clipMaxX - x1) / (x2 - x1)));
				x1 = clipMaxX;
			}
			else
			{
				if (x2 > clipMaxX)
				{
					y2 = (int)(y1 + (y2 - y1) * ((float)(clipMaxX - x1) / (x2 - x1)));
					x2 = clipMaxX;
				}
			}
			if (x1 < clipMinX)
			{
				y1 = (int)(y1 + (y2 - y1) * ((float)(clipMinX - x1) / (x2 - x1)));
				x1 = clipMinX;
			}
			else
			{
				if (x2 < clipMinX)
				{
					y2 = (int)(y1 + (y2 - y1) * ((float)(clipMinX - x1) / (x2 - x1)));
					x2 = clipMinX;
				}
			}

			// End of clipping

			xDelta = x2 - x1;

			if (xDelta < 0) 
			{
				xAdvance = -1;
				xDelta = -xDelta;
			}
			else
				xAdvance = 1;

			yDelta = y2 - y1;


			// No change in X (Vertical Line)
			if (xDelta == 0)
			{
				ddPtr += x1;
				for (index = y1; index <= y1 + yDelta; index++)
					*(ddPtr + index * HALF_SCREEN_WIDTH) = color;
				return;
			}

			// No change in Y (Horizontal Line)
			if (yDelta == 0)
			{
				ddPtr += y1 * HALF_SCREEN_WIDTH;
				for (index = 0; index <= xDelta; index++)
				{
					*(ddPtr + x1) = color;
					x1 += xAdvance;
				}
				return;
			}

			// Diagonal line
			if (xDelta == yDelta)
			{
				for (index = 0; index <= xDelta; index++)
				{
					*(ddPtr + y1 * HALF_SCREEN_WIDTH + x1) = color;
					x1 += xAdvance;
					y1++;
				}
				return;
			}

			if (xDelta >= yDelta)
			{
				wholeStep = xDelta / yDelta;

				adjUp = (xDelta % yDelta) * 2;
				adjDown = yDelta * 2;

				errorTerm = (xDelta % yDelta) - (yDelta * 2);

				initialPixelCount = (wholeStep / 2) + 1;
				finalPixelCount = initialPixelCount;

				if ((adjUp == 0) && ((wholeStep & 0x01) == 0)) 
					initialPixelCount--;

				if ((wholeStep & 0x01) != 0) 
					errorTerm += yDelta;

				DrawHorizontalRun(ref x1, ref y1, xAdvance, initialPixelCount, color, ddPtr);

				for (index = 0; index < (yDelta - 1); index++)
				{
					runLength = wholeStep;

					errorTerm += adjUp;

					if (errorTerm > 0)
					{
						runLength++;
						errorTerm -= adjDown;
					}

					DrawHorizontalRun(ref x1, ref y1, xAdvance, runLength, color, ddPtr);
				}

				DrawHorizontalRun(ref x1, ref y1, xAdvance, finalPixelCount, color, ddPtr);
			}
			else
			{
				wholeStep = yDelta / xDelta;

				adjUp = (yDelta % xDelta) * 2;
				adjDown = xDelta * 2;

				errorTerm = (yDelta % xDelta) - (xDelta * 2);

				initialPixelCount = (wholeStep / 2) + 1;
				finalPixelCount = initialPixelCount;

				if ((adjUp == 0) && ((wholeStep & 0x01) == 0)) 
					initialPixelCount--;

				if ((wholeStep & 0x01) != 0) 
					errorTerm += xDelta;

				DrawVerticalRun(ref x1, ref y1, xAdvance, initialPixelCount, color, ddPtr);

				for (index = 0; index < (xDelta - 1); index++)
				{
					runLength = wholeStep;

					errorTerm += adjUp;

					if (errorTerm > 0)
					{
						runLength++;
						errorTerm -= adjDown;
					}

					DrawVerticalRun(ref x1, ref y1, xAdvance, runLength, color, ddPtr);
				}

				DrawVerticalRun(ref x1, ref y1, xAdvance, finalPixelCount, color, ddPtr);
			}
		}


		/// <summary>
		/// Sets up a single edge of a triangle based off the information stored in the face description
		/// </summary>
		/// <param name="edge">An EdgeScan structure that will hold info about the edge</param>
		/// <param name="faceObject">The face description</param>
		/// <param name="startVert">An index to the starting vertex (0, 1, or 2)</param>
		/// <param name="maxVert">The final vertex (0, 1, or 2)</param>
		private bool SetUpEdge(ref EdgeScan edge, object faceObject, int startVert, int maxVert) 
		{
			Face face = (Face)faceObject;
			int nextVert, destXWidth;
			double destYHeight;
			bool done = false;

			while (!done)
			{
				if (startVert == maxVert) 
					return false;

				nextVert = startVert + edge.direction;
				if (nextVert > 2)
				{
					nextVert = 0;
				}
				else
					if (nextVert < 0)
						nextVert = 2;
				
				edge.remainingScans = face.triVerts[nextVert].y - face.triVerts[startVert].y;
				if (edge.remainingScans != 0) 
				{
					destYHeight = edge.remainingScans;
					edge.currentEnd = nextVert;
					edge.sourceX = face.skinVerts[startVert].x;
					edge.sourceY = face.skinVerts[startVert].y;
					edge.sourceStepX = (face.skinVerts[nextVert].x - edge.sourceX) / destYHeight;
					edge.sourceStepY = (face.skinVerts[nextVert].y - edge.sourceY) / destYHeight;
					edge.destX = face.triVerts[startVert].x;
					destXWidth = face.triVerts[nextVert].x - face.triVerts[startVert].x;
					if (destXWidth < 0)
					{
						edge.destXDirection = -1;
						destXWidth = -destXWidth;
						edge.destXErrTerm = 1 - edge.remainingScans;
						edge.destXIntStep = -(destXWidth / edge.remainingScans);
					}
					else
					{
						edge.destXDirection = 1;
						edge.destXErrTerm = 0;
						edge.destXIntStep = destXWidth / edge.remainingScans;
					}
					edge.destXAdjUp = destXWidth % edge.remainingScans;
					edge.destXAdjDown = edge.remainingScans;
					done = true;
				}
				startVert = nextVert;
			}
			return true;
		}

		/// <summary>
		/// Steps down an edge, incrementing X & Y
		/// </summary>
		/// <param name="edge">The edge to step</param>
		/// <param name="faceObject">The face description</param>
		/// <param name="maxVert">The final vertex (0, 1, or 2)</param>
		private bool StepEdge(ref EdgeScan edge, object faceObject, int maxVert)
		{
			edge.remainingScans--;

			if (edge.remainingScans == 0) 
				if (!SetUpEdge(ref edge, faceObject, edge.currentEnd, maxVert))
				{
					return false;
				}
				else
					return true;
			
			edge.sourceX += edge.sourceStepX;
			edge.sourceY += edge.sourceStepY;
			edge.destX += edge.destXIntStep;
			edge.destXErrTerm += edge.destXAdjUp;
			if (edge.destXErrTerm > 0)
			{
				edge.destX += edge.destXDirection;
				edge.destXErrTerm -= edge.destXAdjDown;
			}

			return true;
		}

		/// <summary>
		/// Draws a horizontal line between two edges
		/// </summary>
		/// <param name="leftEdge">The left edge of the polygon</param>
		/// <param name="rightEdge">The right edge of the polygon</param>
		/// <param name="ddPtr">A pointer to the surface we are drawing to</param>
		/// <param name="tWidth">The width of the texture</param>
		/// <param name="textureMap">The texture we are applying to the polygon</param>
		/// <param name="destY">The y offset for the line</param>
		private unsafe void ScanOutLine(EdgeScan leftEdge, EdgeScan rightEdge, short* ddPtr, int tWidth, byte[] textureMap, int destY)
		{
			double sourceX, sourceY, destWidth, sourceStepX, sourceStepY;
			int destX, destXMax, count;

			destX = leftEdge.destX;
			destXMax = rightEdge.destX;

			if ((destXMax <= clipMinX) || (destX > clipMaxX)) 
				return;

			if ((destXMax - destX) <= 0) 
				return;

			sourceX = leftEdge.sourceX;
			sourceY = leftEdge.sourceY;

			destWidth = destXMax - destX;
			sourceStepX = (rightEdge.sourceX - sourceX) / destWidth;
			sourceStepY = (rightEdge.sourceY - sourceY) / destWidth;

			sourceX += (sourceStepX / 2);
			sourceY += (sourceStepY / 2);

			if (destXMax > clipMaxX)
				destXMax = clipMaxX;

			if (destX < clipMinX)
			{
				sourceX += (sourceStepX * (clipMinX - destX));
				sourceY += (sourceStepY * (clipMinX - destX));
				destX = clipMinX;
			}

			for (count = destX; count < destXMax; count++)
			{
				*(ddPtr + destY * HALF_SCREEN_WIDTH + count) = 
					pal16[currentIndex, textureMap[(int)sourceY * tWidth + (int)sourceX]];
				sourceX += sourceStepX;
				sourceY += sourceStepY;
			}
		}

		/// <summary>
		/// Draw a textured triangle
		/// </summary>
		/// <param name="DDOffset"> The Offset into the surface buffer</param>
		/// <param name="TextureMap"> The TextureMap to use</param>
		/// <param name="TWidth"> The Width to use</param>
		/// <param name="faceObject"> The face object</param>
		public unsafe void DrawTexTriangle(int ddOffset, byte[] textureMap, int tWidth, object faceObject)
		{
			// TODO: Give credit to Abarash?
			short* ddPtr = (short*)ddOffset;
			
			Face face = (Face)faceObject;
			bool done = false;
			int minY, maxY, minVert, maxVert, destY;
			int count;
			EdgeScan leftEdge = new EdgeScan();
			EdgeScan rightEdge = new EdgeScan();
			
			minY = 2147483647;
			maxY = -2147483647;
			minVert = 0;
			maxVert = 0;
			
			for (count = 0; count < 3; count++)
			{
				if (face.triVerts[count].y < minY)
				{
					minY = face.triVerts[count].y;
					minVert = count;
				}
				if (face.triVerts[count].y > maxY)
				{
					maxY = face.triVerts[count].y;
					maxVert = count;
				}
			}

			if (minY >= maxY) 
				return;

			destY = minY;

			leftEdge.direction = -1;
			SetUpEdge(ref leftEdge, faceObject, minVert, maxVert);
			rightEdge.direction = 1;
			SetUpEdge(ref rightEdge, faceObject, minVert, maxVert);

			while (!done) 
			{
				if (destY >= clipMaxY)
					return;

				if (destY >= clipMinY)
					ScanOutLine(leftEdge, rightEdge, ddPtr, tWidth, textureMap, destY);

				if (!StepEdge(ref leftEdge, faceObject, maxVert))
					return;

				if (!StepEdge(ref rightEdge, faceObject, maxVert))
					return;

				destY++;
			}
		}
		
		/// <summary>
		/// Sets the restrictive clipping plane
		/// </summary>
		/// <param name="minX">Left side of box</param>
		/// <param name="minY">Top of box</param>
		/// <param name="maxX">Right side of box</param>
		/// <param name="maxY">Bottom of box</param>
		public void SetClipPlane(int minX, int minY, int maxX, int maxY)
		{
			clipMinX = minX;
			clipMinY = minY;
			clipMaxX = maxX;
			clipMaxY = maxY;
		}

	}
}
