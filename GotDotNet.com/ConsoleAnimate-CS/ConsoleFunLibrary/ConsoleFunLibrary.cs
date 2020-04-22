using System;
using System.Drawing;

namespace System
{
	
    #region Base Classes
    // This class defines a point in a matrix representing an object
    public struct MatrixPoint
    {
        private int x;
        private int y;
        private bool on;

        public int X
        {
            get
            {
                return x;
            }
            set
            {
                // TO DO
                // We can throw an exception in here if x is bigger than a specific numbe and smaller than 0
                x = value;
            }
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                // TO DO
                // We can throw an exception in here if y is bigger than a specific numbe and smaller than 0
                y = value;
            }
        }

        public bool ON
        {
            get
            {
                return on;
            }
            set
            {
                on = value;
            }
        }
    }

    public interface IConsoleFunMatrixGenerator
    {
        // This function is responsible for generating the points that represent the object passed.
        // We can have as many generator as we need to generate different type of objects.
        // TextGenerator can be used for generating matrices based on unicode characters.
        // EmoticonsGenerator can be used for generating matrices for Emoticons.
        // The returned array is organized line by line, So to get the dimension u should follow the first line till y = 1.
        MatrixPoint [] GenerateMatrix( Object matrixSource );
    }

    public interface IConsoleFunEffect
    {
        // This function is used by the console to intialize the drawing.
        // if this function returned true then there is a frame after that to draw.
        bool InitializeAnimation( );

        // This function is used by the console to draw a frame.
        // If this function returned true then it will be called again to draw another frame.
        bool DrawFrame ();

		void SetPoints( MatrixPoint[] points );
    }
    #endregion

    #region Implementation
    /// <summary>
    /// Summary description for Class1.
    /// </summary>
    public class ConsoleFun
    {
        public ConsoleFun ()
        {
        }

        // This method is responsible for calling the effect class to execute the animation, and it will sleep for
        // the amount of betweenFramesTime between each frame.
        public static void Animate (IConsoleFunEffect effectObject, int betweenFramesTime)
        {
            if (effectObject.InitializeAnimation ())
            {
                do
                {
                    System.Threading.Thread.Sleep (betweenFramesTime);
                } while (effectObject.DrawFrame ());
            }
        }

        public static void Draw (MatrixPoint[] points, int x, int y, ConsoleColor defaultColor)
        {
			for (int i = 0; i < points.GetLength(0); i++)
			{
				try
				{
					Console.SetCursorPosition(x + points[i].X, y + points[i].Y);
					if (points[i].ON)
					{
						Console.ForegroundColor = defaultColor;
						Console.Write("*");
					}
				}
				catch
				{
				}
			}
        }
    }

    public class StringMatrixGenerator : IConsoleFunMatrixGenerator
    {
        private Font characterFont = null;
        private ConsoleColor characterColor = default(ConsoleColor);

        public StringMatrixGenerator()
        {
            characterFont = new Font ( "Ariel", 10.0F );
        }

        public MatrixPoint[] GenerateMatrix ( Object text )
        {
            string textString = text.ToString ();

            // Creating the Bitmap that represent the text.
            Bitmap textBmp = new Bitmap ( 1, 1 );
            Graphics textGraphic = Graphics.FromImage (textBmp );
            SolidBrush drawBrush = new SolidBrush( Color.Black );
            SizeF textSize = textGraphic.MeasureString (textString, characterFont);
            int stringHeight = (int) textSize.Height;
            int stringWidth = (int)textSize.Width;
            textBmp = null;
            textBmp = new Bitmap (stringWidth, stringHeight);
            textGraphic = Graphics.FromImage ( textBmp );
            
            SolidBrush fillBrush = new SolidBrush (Color.White);
            textGraphic.FillRectangle (fillBrush, 0, 0, stringWidth, stringHeight );

            textGraphic.DrawString (textString, characterFont, drawBrush, 0, 0); 
            //textBmp.Save (@"C:\tempimage.bmp", System.Drawing.Imaging.ImageFormat.Bmp);

			Color color = Color.FromArgb( 220, 220, 220);

            MatrixPoint[] points = new MatrixPoint[stringWidth * stringHeight];
            for (int i = 0; i < stringHeight; i++)
            {
                for (int j = 0; j < stringWidth; j++)
                {
                    points[i * stringWidth + j] = new MatrixPoint ();
                    points[i * stringWidth + j].X = j;
                    points[i * stringWidth + j].Y = i;
                    Color pixelColor = textBmp.GetPixel (j, i);
                    if ( pixelColor.ToArgb() >= color.ToArgb() )
                        points[i * stringWidth + j].ON = false;
                    else
                        points[i * stringWidth + j].ON = true;
                }
            }
            
            return points;
        }

        public Font CharacterFont
        {
            get
            {
                return characterFont;
            }
            set
            {
                characterFont = null;
                characterFont = value;
            }
        }
        public ConsoleColor CharacterColor
        {
            get
            {
                return characterColor;
            }
            set
            {
                // TO Do : An Exception can be thrown here if the value is not a valid color.
                characterColor = value;
            }
        }
    }
    public class FadeToDefaultEffect : IConsoleFunEffect
    {
        private int frames = 5;
        private MatrixPoint [] points = null;
        private int matrixWidth = 0;
        private int matrixHeight = 0;
        private int currentFrame = 0; // Zero based
        private int startX = 0;
        private int startY = 0;
        private ConsoleColor defaultColor = ConsoleColor.Green;
        private int fadingFactor = 0;

        public bool InitializeAnimation ()
        {
            if (frames == 0)
                return false;

            matrixWidth = GetWidth ();
            matrixHeight = points.GetLength (0) / matrixWidth;

            currentFrame = 0;
            fadingFactor = ( (defaultColor - ConsoleColor.Black) / frames ) +1;

            return true;
        }

        public bool DrawFrame ()
        {
            // Calculate the fading of the color.
            ConsoleColor currentColor = ConsoleColor.Green - fadingFactor * currentFrame;
            if (currentColor < 0)
                currentColor = ConsoleColor.Black;

            currentFrame++;

            for (int i = 0; i < points.GetLength (0); i++)
            {
				try
				{
					Console.SetCursorPosition (startX + points[i].X, startY + points[i].Y);
					if (points[i].ON)
					{
						Console.ForegroundColor = defaultColor;
						Console.Write ("*");
					}
					else
					{
						Console.ForegroundColor = currentColor;
						Console.Write ("*");
					}
				}
				catch
				{
				}
            }

            if ( frames >= currentFrame+1 )
                return true;

            return false;
        }

        public int Frames
        {
            get
            {
                return frames;
            }
            set
            {
                frames = value;
            }
        }


        public MatrixPoint [] Points
        {
            set
            {
                // To Do :  can not change this if Initialize Animation already started.
                points = value;
            }
        }


		public void SetPoints(MatrixPoint[] points)
		{
			Points = points;
		}


        // This function returns the width of the matrix.
        // TO DO : Can this function be a static in the consoleFunEffect.
        // TO Do : Error handling and Exceptions in here and also in the whole design.
        private int GetWidth ()
        {
            if ( null == points )
                throw new NullReferenceException( "Points are equel to null." );

            for (int i = 0; i < points.GetLength (0); i++)
            {
                if ( points[i].Y == 1 )
                    return i;
            }

            return -1;
        }
    }
    public class TopToDownEffect : IConsoleFunEffect
    {
        private int frames = 5;
        private MatrixPoint[] points = null;
        private int matrixWidth = 0;
        private int matrixHeight = 0;
        private int currentFrame = 0; // Zero based
        private int startX = 0;
        private int startY = 0;
        private ConsoleColor defaultColor = ConsoleColor.Green;
        private int movingFactor = 0;

        public bool InitializeAnimation ()
        {
            if (frames == 0)
                return false;

            matrixWidth = GetWidth ();
            matrixHeight = points.GetLength (0) / matrixWidth;
            currentFrame = 0;
            movingFactor = (matrixHeight / frames) +1;

            return true;
        }

        public bool DrawFrame ()
        {
            // Calculate the Starting render line
            int renderLine = matrixHeight - ( ( currentFrame +1) * movingFactor);

            if (renderLine < 0)
                renderLine = 0;

            currentFrame++;
            for (int i = 0; i < points.GetLength (0); i++)
            {
                if (points[i].Y >= renderLine)
                {
					try
					{
						Console.SetCursorPosition(startX + points[i].X, startY + points[i].Y - renderLine);
						if (points[i].ON)
						{
							Console.ForegroundColor = defaultColor;
							Console.Write("*");
						}
						else
						{
							Console.ForegroundColor = default(ConsoleColor);
							Console.Write("*");
						}
					}
					catch
					{
					}
                }
            }

            if (frames >= currentFrame + 1)
                return true;

            return false;
        }

        public int Frames
        {
            get
            {
                return frames;
            }
            set
            {
                frames = value;
            }
        }

        public MatrixPoint[] Points
        {
            set
            {
                // To Do :  can not change this if Initialize Animation already started.
                points = value;
            }
        }

		public void SetPoints(MatrixPoint[] points)
		{
			Points = points;
		}


        // This function returns the width of the matrix.
        // TO DO : Can this function be a static in the consoleFunEffect.
        // TO Do : Error handling and Exceptions in here and also in the whole design.
        private int GetWidth ()
        {
            if (null == points)
                throw new NullReferenceException ("Points are equel to null.");

            for (int i = 0; i < points.GetLength (0); i++)
            {
                if (points[i].Y == 1)
                    return i;
            }

            return -1;
        }
    }
    public class OutInEffect : IConsoleFunEffect
    {
        private int frames = 5;
        private MatrixPoint[] points = null;
        private int matrixWidth = 0;
        private int matrixHeight = 0;
        private int currentFrame = 0; // Zero based
        private int startX = 0;
        private int startY = 0;
        private ConsoleColor defaultColor = ConsoleColor.Green;
        private int movingHorizontalFactor = 0;
        private int movingVerticalFactor = 0;

        public bool InitializeAnimation ()
        {
            if (frames == 0)
                return false;

            matrixWidth = GetWidth ();
            matrixHeight = points.GetLength (0) / matrixWidth;
            currentFrame = 0;
            movingHorizontalFactor = (matrixWidth / frames) /2 +1;
            movingVerticalFactor = (matrixHeight / frames) / 2 + 1;
            return true;
        }

        public bool DrawFrame ()
        {
            // Calculate the Starting render line
            int topLine = movingVerticalFactor * currentFrame +1;
            int bottomLine = matrixHeight -topLine +1;
            int leftLine = movingHorizontalFactor * currentFrame +1;
            int rightLine = matrixWidth - leftLine +1;

            currentFrame++;
            for (int i = 0; i < points.GetLength (0); i++)
            {
                if  ( ((points[i].Y <= topLine) && (points[i].X <= leftLine))
                    || ((points[i].Y <= topLine) && (points[i].X >= rightLine))
                    || ((points[i].Y >= bottomLine) && (points[i].X >= rightLine))
                    || ((points[i].Y >= bottomLine) && (points[i].X <= leftLine)) )
                {
					try
					{
						Console.SetCursorPosition(startX + points[i].X, startY + points[i].Y);
						if (points[i].ON)
						{
							Console.ForegroundColor = defaultColor;
							Console.Write("*");
						}
						else
						{
                            Console.ForegroundColor = default(ConsoleColor);
                            Console.Write("*");
						}
					}
					catch
					{
					}
                }
            }

            if (frames >= currentFrame + 1)
                return true;

            return false;
        }

        public int Frames
        {
            get
            {
                return frames;
            }
            set
            {
                frames = value;
            }
        }

        public MatrixPoint[] Points
        {
            set
            {
                // To Do :  can not change this if Initialize Animation already started.
                points = value;
            }
        }

		public void SetPoints(MatrixPoint[] points)
		{
			Points = points;
		}


        // This function returns the width of the matrix.
        // TO DO : Can this function be a static in the consoleFunEffect.
        // TO Do : Error handling and Exceptions in here and also in the whole design.
        private int GetWidth ()
        {
            if (null == points)
                throw new NullReferenceException ("Points are equel to null.");

            for (int i = 0; i < points.GetLength (0); i++)
            {
                if (points[i].Y == 1)
                    return i;
            }

            return -1;
        }
    }
    public class RandomEffect : IConsoleFunEffect
    {
        private int frames = 5;
        private MatrixPoint[] points = null;
        private int matrixWidth = 0;
        private int matrixHeight = 0;
        private int currentFrame = 0; // Zero based
        private int startX = 0;
        private int startY = 0;
        private ConsoleColor defaultColor = ConsoleColor.Green;
        private int [] randomArray = null;
        private int pointsPerFrame = 0;

        public bool InitializeAnimation ()
        {
            if (frames == 0)
                return false;

            matrixWidth = GetWidth ();
            matrixHeight = points.GetLength (0) / matrixWidth;
            currentFrame = 0;

            // Building the Random Array
            bool done = false;
            System.Random randomGenerator = new Random ( System.Environment.TickCount );
            randomArray = new int[points.GetLength(0)];
            for ( int i=0; i<points.GetLength (0); i++)
            {
                randomArray[i] = -1;
            }

            int randomValue;
            for (int i = 0; i < points.GetLength (0); i++)
            {
                do
                {
                    done = false;
                    randomValue = randomGenerator.Next (points.GetLength (0));
                    if (randomArray[randomValue] == -1)
                    {
                        randomArray[randomValue] = i;
                        done = true;
                    }
                } while (!done);

            }

            pointsPerFrame = points.GetLength (0) / frames +1;

            return true;
        }

        public bool DrawFrame ()
        {
            int startPoint = currentFrame *pointsPerFrame;
            int endPoint = startPoint + pointsPerFrame;

            if (endPoint >= points.GetLength(0))
                endPoint = points.GetLength (0) -1;

            currentFrame++;
            
            for (int i = startPoint; i < endPoint; i++)
            {
				try
				{
					Console.SetCursorPosition(startX + points[randomArray[i]].X, startY + points[randomArray[i]].Y);
					if (points[randomArray[i]].ON)
					{
						Console.ForegroundColor = defaultColor;
						Console.Write("*");
					}
					else
					{
                        Console.ForegroundColor = default(ConsoleColor);
                        Console.Write("*");
					}
				}
				catch
				{
				}
            }

            if (frames >= currentFrame + 1)
                return true;

            return false;
        }

        public int Frames
        {
            get
            {
                return frames;
            }
            set
            {
                frames = value;
            }
        }

        public MatrixPoint[] Points
        {
            set
            {
                // To Do :  can not change this if Initialize Animation already started.
                points = value;
            }
        }

		public void SetPoints(MatrixPoint[] points)
		{
			Points = points;
		}


        // This function returns the width of the matrix.
        // TO DO : Can this function be a static in the consoleFunEffect.
        // TO Do : Error handling and Exceptions in here and also in the whole design.
        private int GetWidth ()
        {
            if (null == points)
                throw new NullReferenceException ("Points are equel to null.");

            for (int i = 0; i < points.GetLength (0); i++)
            {
                if (points[i].Y == 1)
                    return i;
            }

            return -1;
        }
    }
    #endregion
}
