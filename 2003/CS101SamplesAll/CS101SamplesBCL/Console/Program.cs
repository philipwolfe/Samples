using System;
using System.Collections.Generic;
using System.Text;

namespace ConsoleSample
{
	class Program
	{
		static void Main(string[] args)
		{
            try
            {               
			    Console.WriteLine("Hello and welcome to the new Console in Visual Studio 2005");
			    Console.WriteLine();

			    # region Title

			    Console.WriteLine("The default title of the Console window is the path to this executable");
			    Console.Write("Please enter the new Title for the Console Window:");
			    Console.Title = Console.ReadLine();

			    Console.WriteLine();
			    Console.WriteLine();

			    # endregion Title

			    # region Size

			    Console.WriteLine("You can now change the size of the Window");
			    Console.WriteLine();

			    int newHeight;
			    int newWidth;

			    Console.Write("Enter the Height in Pixels(40 is a good value):");
			    try
			    {
				    newHeight = Int32.Parse(Console.ReadLine());
			    }
			    catch
			    {
				    Console.WriteLine("You entered an incorrect value. I will set the height to 40 for you");
				    newHeight = 40;
			    }
			    Console.WriteLine();

			    Console.Write("Enter the Width in Pixels (100 is a good value):");
			    try
			    {
				    newWidth = Int32.Parse(Console.ReadLine());
			    }
			    catch
			    {
				    Console.WriteLine("You entered an incorrect value. I will set the width to 100 for you");
				    newWidth = 100;
			    }

			    // Make sure the window is not set larger than possible
                if (newHeight > Console.LargestWindowHeight)
                {
                    newHeight = Console.LargestWindowHeight;
                    Console.WriteLine("Height is larger than console allows - defaulting to maximum value");
                }

                if (newWidth > Console.LargestWindowWidth)
                {
                    newWidth = Console.LargestWindowWidth;
                    Console.WriteLine("Width is larger than console allows - defaulting to maximum value");
                }

			    Console.WindowHeight = newHeight;
			    Console.WindowWidth = newWidth;

			    Console.Write("New window size is: " + Console.WindowHeight + " x " + Console.WindowWidth);
			    Console.WriteLine();
			    Console.WriteLine("Press Enter to continue");
			    Console.ReadLine();

			    Console.Clear();

			    # endregion Size

			    # region Color

			    Console.WriteLine("You can also change the Background and Foreground colors of the Console using one of the following color values:");
			    Console.WriteLine();

			    foreach (string colorName in Enum.GetNames(typeof(ConsoleColor)))
			    {
				    Console.Write(colorName + ", ");
			    }

			    Console.WriteLine();

			    Console.Write("Enter the new Background Color:");
			    try
			    {
				    string newBackgroundColor = Console.ReadLine();
				    Console.BackgroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), newBackgroundColor, true);
			    }
			    catch
			    {
                    Console.WriteLine("You entered an incorrect color choice. I will set the background to Green for you");
				    Console.BackgroundColor = ConsoleColor.Green;
			    }

			    Console.Write("Enter the new Foreground Color:");

			    try
			    {
				    string newForegroundColor = Console.ReadLine();
				    Console.ForegroundColor = (ConsoleColor)Enum.Parse(typeof(ConsoleColor), newForegroundColor, true);
			    }
			    catch
			    {
                    Console.WriteLine("You entered an incorrect color choice. I will set the foregound to Yellow for you");
				    Console.ForegroundColor = ConsoleColor.Yellow;
                    // allow the user to see this before we clear the screen
                    Console.WriteLine("Press Enter to continue");
                    Console.ReadLine();
                }

			    Console.Clear();
			    Console.WriteLine("You can see how the new colors are applied");
			    Console.WriteLine();
			    Console.WriteLine("Press Enter to continue");
			    Console.ReadLine();
			    Console.BackgroundColor = ConsoleColor.Black;
			    Console.ForegroundColor = ConsoleColor.White;
			    Console.Clear();

			    # endregion Color

			    # region Buffer

			    Console.WriteLine("In addition to the Window size you can also change the buffer size");
			    Console.WriteLine("The buffer size can not be smaller than the window size");

			    int newBufferWidth;
			    int newBufferHeight;

			    Console.Write("Enter the new buffer height: ");
			    try
			    {
				    newBufferHeight = Int16.Parse(Console.ReadLine());
			    }
			    catch
			    {
				    Console.WriteLine("You entered an incorrect value. I will set the buffer height to 50 for you");
				    newBufferHeight = 50;
			    }


			    Console.Write("Enter the new buffer width: ");
			    try
			    {
				    newBufferWidth = Int16.Parse(Console.ReadLine());
			    }
			    catch
			    {
				    Console.WriteLine("You entered an incorrect value. I will set the buffer width to 120 for you");
				    newBufferWidth = 120;
			    }

			    if (newBufferWidth < Console.WindowWidth)
				    newBufferWidth = Console.WindowWidth;

			    if (newBufferHeight < Console.WindowHeight)
				    newBufferHeight = Console.WindowHeight;

			    Console.SetBufferSize(newBufferWidth, newBufferHeight);

			    Console.Write("New Buffer size is: " + Console.BufferWidth + " x " + Console.BufferHeight);

			    Console.WriteLine();
			    Console.WriteLine("Press Enter to continue");
			    Console.ReadLine();

			    Console.Clear();

			    Console.WindowWidth = 120;
			    Console.WindowHeight = 40;
			    Console.BufferWidth = 120;
			    Console.BufferHeight = 40;


			    Console.WriteLine("@@@@@@@@@@");
			    Console.WriteLine("@@@@@@@@@@");
			    Console.WriteLine("@@@@@@@@@@");
			    Console.WriteLine("@@@@@@@@@@");
			    Console.WriteLine("@@@@@@@@@@");

			    Console.WriteLine("You can also move part of the buffer");
			    Console.WriteLine("The area above is a 10 x 5 matrix");
			    Console.WriteLine("We will move it from the top left to the bottom right");

			    Console.WriteLine();
			    Console.WriteLine("Press Enter to continue");
			    Console.ReadLine();


			    Console.MoveBufferArea(0, 0, 10, 5, Console.BufferWidth - 10, Console.BufferHeight - 5);

			    Console.WriteLine();
			    Console.WriteLine("Press Enter to continue");
			    Console.ReadLine();

			    Console.Clear();


			    # endregion Buffer

			    # region Cursor

			    Console.SetWindowSize(120, 40);

			    Console.WriteLine("With the new Console class you can also change the cursor postions, size and make the cursor invisible");
			    Console.WriteLine();
			    Console.WriteLine("The beginning of this line is at Left = " + Console.CursorLeft + " Top = " + Console.CursorTop);
			    Console.WriteLine();
			    Console.WriteLine("Press Enter to move the cursor to Left = 20, top = 20");
			    Console.ReadLine();
			    Console.CursorLeft = 20;
			    Console.CursorTop = 20;
			    Console.Write("The beginning of this line is at Left = " + Console.CursorLeft + " Top = " + Console.CursorTop);
			    Console.WriteLine();
			    Console.WriteLine();
			    Console.WriteLine("Press Enter to continue");
			    Console.ReadLine();

			    Console.Clear();

			    Console.WriteLine("Adjusting the Cursor size and visibility");
			    Console.WriteLine();
			    Console.WriteLine("The cursor size is now = " + Console.CursorSize);
			    Console.WriteLine();

			    int newCursorSize;

			    Console.Write("Enter the new cursor size: ");
			    try
			    {
				    newCursorSize = Int32.Parse(Console.ReadLine());
			    }
			    catch
			    {
				    Console.WriteLine("You entered an incorrect value. I will set the cursor size to 50 for you");
				    newCursorSize = 50;
			    }

			    if (newCursorSize <= 0 || newCursorSize > 100)
			    {
				    Console.WriteLine("The cursor size must be between 1 and 100. I will set the cursor size to 50 for you");
				    newCursorSize = 50;
			    }

			    Console.CursorSize = newCursorSize;
			    Console.WriteLine();
			    Console.WriteLine("The cursor size is now = " + Console.CursorSize);
			    Console.WriteLine();
                Console.WriteLine("Press Enter to continue");
                Console.ReadLine();
                
                Console.Clear();

			    Console.WriteLine("The cursor can be made invisible");
			    Console.CursorVisible = false;
			    Console.WriteLine();
			    Console.WriteLine("Press Enter to continue");
			    Console.ReadLine();

			    Console.WriteLine("And visible again");
			    Console.CursorVisible = true;

			    Console.WriteLine();
			    Console.WriteLine("Press Enter to continue");
			    Console.ReadLine();
			    Console.Clear();

			    Console.Clear();

			    # endregion Cursor

			    # region Beep

			    Console.WriteLine("Adjusting the Beep frequency and duration");
			    Console.WriteLine();

			    int frequency;
			    int duration;

			    Console.Write("Enter a frequency value between 37 and 32767: ");
			    try
			    {
				    frequency = Int32.Parse(Console.ReadLine());

				    if (frequency < 37 | frequency > 32767)
				    {
					    Console.WriteLine("You entered an incorrect value. I will set the frequency to 1000 for you");
					    frequency = 1000;
				    }

			    }
			    catch
			    {
				    Console.WriteLine("You entered an incorrect value. I will set the frequency to 1000 for you");
				    frequency = 1000;
			    }
			    Console.WriteLine();

			    Console.Write("Enter a duration in milliseconds (1000 = 1 second): ");
			    try
			    {
				    duration = Int32.Parse(Console.ReadLine());
			    }
			    catch
			    {
				    Console.WriteLine("You entered an incorrect value. I will set the duration to 500 for you");
				    duration = 500;
			    }

			    Console.Beep(frequency, duration);

			    Console.WriteLine();
			    Console.WriteLine("Press Enter to continue");
			    Console.ReadLine();

			    Console.Clear();


			    # endregion Beep

			    Console.WriteLine();
			    Console.WriteLine("Press Enter to end this demo");
			    Console.ReadLine();
            }
            catch (ApplicationException ex)
            {
                String msg = "Application error:" + ex.Message;
                Console.WriteLine(msg);
            }
        }

		static void Console_CancelKeyPress(object sender, ConsoleCancelEventArgs e)
		{
			Console.WriteLine("Now CTRL+C is used as the cancel key");
			Console.ReadLine();
			e.Cancel = true;
		}
	}
}
