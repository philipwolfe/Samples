Namespace ConsoleSample

    Module Module1

        Sub Main()

            Console.WriteLine("Hello and welcome to the new Console in Visual Studio 2005")
            Console.WriteLine()

            ' Title
            Console.WriteLine("The default title of the Console window is the path to this executable")
            Console.Write("Please enter the new Title for the Console Window:")
            Console.Title = Console.ReadLine
            Console.WriteLine()
            Console.WriteLine()


            ' Size
            Console.WriteLine("You can now change the size of the Window")
            Console.WriteLine()

            Dim newHeight As Integer
            Dim newWidth As Integer

            Console.Write("Enter the Height in Pixels(40 is a good value):")
            Try
                newHeight = Int32.Parse(Console.ReadLine)
            Catch ex As Exception
                Console.WriteLine("You entered an incorrect value. I will set the height to 40 for you")
                newHeight = 40
            End Try


            Console.WriteLine()
            Console.Write("Enter the Width in Pixels (100 is a good value):")
            Try
                newWidth = Int32.Parse(Console.ReadLine)
            Catch ex As Exception
                Console.WriteLine("You entered an incorrect value. I will set the width to 100 for you")
                newWidth = 100
            End Try


            If newHeight > Console.LargestWindowHeight Then
                newHeight = Console.LargestWindowHeight
                Console.WriteLine("Height is larger than console allows - defaulting to maximum value")
            End If

            If newWidth > Console.LargestWindowWidth Then
                newWidth = Console.LargestWindowWidth
                Console.WriteLine("Width is larger than console allows - defaulting to maximum value")
            End If

            Console.WindowHeight = newHeight
            Console.WindowWidth = newWidth
            Console.Write("New window size is: " + Console.WindowHeight.ToString() + " x " + Console.WindowWidth.ToString())
            Console.WriteLine()
            Console.WriteLine("Press Enter to continue")
            Console.ReadLine()
            Console.Clear()


            ' Color
            Console.WriteLine("You can also change the Background and Foreground colors of the Console using one of the following color values:")
            Console.WriteLine()

            For Each colorName As String In System.Enum.GetNames(GetType(ConsoleColor))
                Console.Write(colorName + ", ")
            Next

            Console.WriteLine()


            Console.Write("Enter the new Background Color:")
            Try
                Dim newBackgroundColor As String = Console.ReadLine
                Console.BackgroundColor = CType(System.Enum.Parse(GetType(ConsoleColor), newBackgroundColor, True), ConsoleColor)
            Catch ex As Exception
                Console.WriteLine("You entered an incorrect color choice. I will set the background to Green for you")
                Console.BackgroundColor = ConsoleColor.Green
            End Try


            Console.Write("Enter the new Foreground Color:")
            Try
                Dim newForegroundColor As String = Console.ReadLine
                Console.ForegroundColor = CType(System.Enum.Parse(GetType(ConsoleColor), newForegroundColor, True), ConsoleColor)
            Catch ex As Exception
                Console.WriteLine("You entered an incorrect color choice. I will set the foregound to Yellow for you")
                Console.ForegroundColor = ConsoleColor.Yellow
                Console.WriteLine("Press Enter to continue")

                Console.ReadLine()
            End Try


            Console.Clear()
            Console.WriteLine("You can see how the new colors are applied")
            Console.WriteLine()


            Console.WriteLine("Press Enter to continue")
            Console.ReadLine()
            Console.BackgroundColor = ConsoleColor.Black
            Console.ForegroundColor = ConsoleColor.White
            Console.Clear()


            ' Buffer
            Console.WriteLine("In addition to the Window size you can also change the buffer size")
            Console.WriteLine("The buffer size can not be smaller than the window size")

            Dim newBufferHeight As Integer
            Dim newBufferWidth As Integer

            Console.Write("Enter the new buffer height: ")
            Try
                newBufferHeight = Int16.Parse(Console.ReadLine)
            Catch ex As Exception
                Console.WriteLine("You entered an incorrect value. I will set the buffer height to 50 for you")
                newBufferHeight = 50
            End Try


            Console.Write("Enter the new buffer width: ")
            Try
                newBufferWidth = Int16.Parse(Console.ReadLine)
            Catch ex As Exception
                Console.WriteLine("You entered an incorrect value. I will set the buffer width to 120 for you")
                newBufferWidth = 120
            End Try

            If newBufferWidth < Console.WindowWidth Then
                newBufferWidth = Console.WindowWidth
            End If

            If newBufferHeight < Console.WindowHeight Then
                newBufferHeight = Console.WindowHeight
            End If

            Console.SetBufferSize(newBufferWidth, newBufferHeight)
            Console.Write("New Buffer size is: " + Console.BufferWidth.ToString() + " x " + Console.BufferHeight.ToString())
            Console.WriteLine()
            Console.WriteLine("Press Enter to continue")
            Console.ReadLine()
            Console.Clear()


            Console.WindowWidth = 120
            Console.WindowHeight = 40
            Console.BufferWidth = 120
            Console.BufferHeight = 40
            Console.WriteLine("@@@@@@@@@@")
            Console.WriteLine("@@@@@@@@@@")
            Console.WriteLine("@@@@@@@@@@")
            Console.WriteLine("@@@@@@@@@@")
            Console.WriteLine("@@@@@@@@@@")
            Console.WriteLine("You can also move part of the buffer")
            Console.WriteLine("The area above is a 10 x 5 matrix")
            Console.WriteLine("We will move it from the top left to the bottom right")
            Console.WriteLine()
            Console.WriteLine("Press Enter to continue")
            Console.ReadLine()


            Console.MoveBufferArea(0, 0, 10, 5, Console.BufferWidth - 10, Console.BufferHeight - 5)
            Console.WriteLine()
            Console.WriteLine("Press Enter to continue")
            Console.ReadLine()
            Console.Clear()


            ' Cursor
            Console.SetWindowSize(120, 40)
            Console.WriteLine("With the new Console class you can also change the cursor postions, size and make the cursor invisible")
            Console.WriteLine()
            Console.WriteLine("The beginning of this line is at Left = " + Console.CursorLeft.ToString() + " Top = " + Console.CursorTop.ToString())
            Console.WriteLine()
            Console.WriteLine("Press Enter to move the cursor to Left = 20, top = 20")
            Console.ReadLine()
            Console.CursorLeft = 20
            Console.CursorTop = 20
            Console.Write("The beginning of this line is at Left = " + Console.CursorLeft.ToString() + " Top = " + Console.CursorTop.ToString())
            Console.WriteLine()
            Console.WriteLine()
            Console.WriteLine("Press Enter to continue")
            Console.ReadLine()
            Console.Clear()
            Console.WriteLine("Adjusting the Cursor size and visibility")
            Console.WriteLine()
            Console.WriteLine("The cursor size is now = " + Console.CursorSize.ToString())
            Console.WriteLine()
            Console.Write("Enter the new cursor size: ")

            Dim newCursorSize As Integer

            Try
                newCursorSize = Int32.Parse(Console.ReadLine)
            Catch ex As Exception
                Console.WriteLine("You entered an incorrect value. I will set the cursor size to 50 for you")
                newCursorSize = 50
            End Try

            If newCursorSize <= 0 Or newCursorSize > 100 Then
                Console.WriteLine("The cursor size must be between 1 and 100. I will set the cursor size to 50 for you")
                newCursorSize = 50
            End If

            Console.WriteLine()
            Console.WriteLine("Press Enter to continue")
            Console.ReadLine()
            Console.Clear()

            Console.CursorSize = newCursorSize
            Console.WriteLine()
            Console.WriteLine("The cursor size is now = " + Console.CursorSize.ToString())

            Console.WriteLine()
            Console.WriteLine("Press Enter to continue")
            Console.ReadLine()
            Console.Clear()

            Console.WriteLine("The cursor can be made invisible")
            Console.CursorVisible = False
            Console.WriteLine()
            Console.WriteLine("Press Enter to continue")
            Console.ReadLine()

            Console.WriteLine("And visible again")
            Console.CursorVisible = True

            Console.WriteLine()
            Console.WriteLine("Press Enter to continue")
            Console.ReadLine()
            Console.Clear()

            'Beep
            Console.WriteLine("Adjusting the Beep frequency and duration")
            Console.WriteLine()

            Dim frequency As Integer
            Dim duration As Integer

            Console.Write("Enter a frequency value between 37 and 32767: ")
            Try
                frequency = Int32.Parse(Console.ReadLine)

                If frequency < 37 Or frequency > 32767 Then
                    Console.WriteLine("You entered an incorrect value. I will set the frequency to 1000 for you")
                    frequency = 1000
                End If

            Catch ex As Exception
                Console.WriteLine("You entered an incorrect value. I will set the frequency to 1000 for you")
                frequency = 1000
            End Try
            Console.WriteLine()


            Console.Write("Enter a duration in milliseconds (1000 = 1 second): ")
            Try
                duration = Int32.Parse(Console.ReadLine)
            Catch ex As Exception
                Console.WriteLine("You entered an incorrect value. I will set the duration to 500 for you")
                duration = 500
            End Try

            Console.Beep(frequency, duration)


            Console.WriteLine()
            Console.WriteLine("Press Enter to end this demo")
            Console.ReadLine()



        End Sub

    End Module


End Namespace