Option Strict Off

'***********************************************************************
'* Class FractalForm
'* 
'* FractalForm is a Windows.Forms Form that displays a Fractal bitmap.
'* FractalForm implements the Task interface so that it can be run
'* as a background task by the ActiveTask form.
'* The form itself runs on the same thread that it is created from.
'* Method FractalCalc is run on the background thread to calculate the
'* fractal values.  After FractalCalc generates each row in the image
'* it calls back into the FractalDisplayLine method on the form's 
'* thread which then writes the values into the bitmap on the form.
'***********************************************************************
Public Class FractalForm
    Inherits System.Windows.Forms.Form
    Implements Task

    Event OnTaskComplete(ByVal Task As Task) Implements Task.OnTaskComplete
        
    '***********************************************************************
    '* FractalColors
    '* 
    '* A set of color constants.  The
    '* class has a Private constructor, to
    '* prevent instances being created.  All
    '* the class members are Shared.
    '***********************************************************************
    Public Class FractalColors
        ' No instance of this class can be
        ' created.
        Private Sub New()
            MyBase.New()
        End Sub
        Public Shared ReadOnly LightBlue As color = color.FromARGB(0, 255, 255)
        Public Shared ReadOnly Peach As Color = color.FromARGB(255, 204, 0)
        Public Shared ReadOnly PaleYellow As Color = color.FromARGB(255, 255, 153)
        Public Shared ReadOnly Yellow As Color = color.FromARGB(255, 255, 0)
        Public Shared ReadOnly Orange As Color = color.FromARGB(255, 153, 0)
        Public Shared ReadOnly MintGreen As Color = color.FromARGB(204, 255, 204)
        Public Shared ReadOnly DarkPurple As Color = color.FromARGB(153, 0, 204)
        Public Shared ReadOnly Magenta As Color = color.FromARGB(255, 0, 255)
        Public Shared ReadOnly DullBlue As Color = color.FromARGB(102, 204, 255)
        Public Shared ReadOnly Reddish As Color = color.FromARGB(255, 0, 102)
        Public Shared ReadOnly Lavender As Color = color.FromARGB(204, 204, 255)
    End Class

    'Required by the WFC Form Designer
    Private components As System.ComponentModel.Container
    Private picFractal As System.Windows.Forms.PictureBox

    ' Delegates for cross-thread callbacks.
    Public Delegate Sub FractalDisplayCallback(ByVal y As Integer, ByVal s As Integer, ByVal itCounts() As Integer)
    Public Delegate Sub FractalDoneCallback()

    ' Constants
    Private Const NOTCALCULATED = -2
    Private Const NOTELIMINATED = -1
    Private Const DEFAULTITERATIONS As Integer = 256

    Private m_incr As Double ' Increment for test points.
    ' Default starting point.
    Private m_rBase As Double = -2#
    Private m_iBase As Double = 2#
    Private m_rWidth As Double = 4#
    Private m_Iterations As Integer = DEFAULTITERATIONS
    Private m_ct As Integer
    Private m_bitmap As system.drawing.bitmap
    Private m_displayCallback As FractalDisplayCallback = New FractalDisplayCallback(AddressOf Me.Fractaldisplayline)
    Private m_PercentComplete As Integer
    Private m_Thread As Thread

    '***********************************************************************
    '* FractalForm Constructor
    '* 
    '* Create a new FractalForm of the specified height and using the 
    '* parameters in the fractal calculations.
    '***********************************************************************
    Public Sub New(ByVal height As Integer, ByVal FractalIterations As Integer, ByVal FractalX As Double, ByVal fractalY As Double, ByVal FractalWidth As Double)
        MyBase.New()

        'This call is required by the WFC Form Designer.
        InitializeComponent()

        ' Initialization 
        ' --------------
        ' The real and imaginary coordinates of the
        ' fractal image to be calculated.
        m_rbase = FractalX
        m_ibase = FractalY
        ' The width of the area of the imaginary plane
        ' for which the image is to be calculated.
        ' (The height will be the same.)
        m_rwidth = FractalWidth
        ' How many iterations of the fractal algorithm
        ' shoule be executed, before we give up and 
        ' regard a point as being in the Mandelbrot Set?
        m_iterations = FractalIterations

        ' Resize the form.  The input value "height"
        ' is the height (and width) of the client
        ' area, not of the entire form.
        Dim s As System.Drawing.Size = New Size(height, height)
        '            Me.ClientSize = s

        ' The following must be done after resizing:
        ' Create a bitmap for the fractal image.
        m_bitmap = New bitmap(s.width, s.height, system.drawing.imaging.PixelFormat.Format24bppRGB)
        ' Assign bitmap to form's background image.
        '            picFractal.SizeMode = Windows.Forms.PictureBoxSizeMode.AutoSize
        picFractal.SizeMode = Windows.Forms.PictureBoxSizeMode.StretchImage
        picFractal.Size = New Size(s.Width * 2, s.Height * 2)
        Me.ClientSize = picFractal.Size
        picFractal.Image = m_bitmap
        ' One point in the imaginary plane will be 
        ' evaluated for each pixel in the image.
        ' The pixels are numbered 0 to s.Width - 1.
        m_ct = s.width - 1
        ' The number of intervals between points is
        ' ONE FEWER than the number of pixels across
        ' (or down) the image.  Thus the horizontal
        ' (or vertical) distance between points 
        ' in the imaginary plane is calculated using
        ' m_ct (= s.Width - 1).
        m_incr = m_rwidth / m_ct

        Me.text = "Fractal"
        Me.Show()
    End Sub

    '***********************************************************************
    '* FractalCalc
    '* 
    '* Generates the values in the fractal image.
    '* Runs on the background thread.
    '* To display a different fractal type,
    '* override this Sub and change the
    '* way the points in a row are calculated.
    '***********************************************************************
    Sub FractalCalc() Implements Task.StartTask
        Dim x, y As Integer

        ' When the thread starts, retrieve current
        ' fractal coordinates.
        Dim rBase As Double = m_rBase
        Dim iBase As Double = m_iBase
        Dim incr As Double = m_incr
        Dim Iterations As Integer = m_Iterations
        Dim ct As Integer = m_ct

        ' Currently making only one pass.
        Dim s As Integer = 2 ' which pass are we on?

        Dim r As Double ' real part of the escape point
        Dim i As Double ' imaginary part of the escape point
        Dim r0 As Double ' Current test value (real part)
        Dim i0 As Double ' Current test value (imaginary part)

        Dim ItCounts(m_ct + 1) As Integer

        ' Squares of the real and imaginary parts of 
        ' the escape point
        Dim rsq As Double
        Dim isq As Double

        Dim qbc As Integer ' Escape test iteration counter
        'Me.Show()
        Try
            'System.Windows.Forms.Application.Run(Me)
            While s > 1
                s = CInt(s / 2)

                For Y = 0 To ct Step s
                    m_PercentComplete = CInt(100 * y / m_ct)
                    For X = 0 To ct Step s
                        ' If you were keeping the full array
                        ' and making multiple passes,
                        ' you'd have an If block here to test 
                        ' whether each point has been 
                        ' calculated on a prior pass.
                        'If ItCounts(X) = NOTCALCULATED Then

                        ' Set up the loop variables.

                        ' Real and imaginary parts of the next
                        ' point to be tested.
                        r0 = rBase + X * incr
                        i0 = iBase - Y * incr
                        ' Above: Why not speed things up slightly, by 
                        '   starting with a value for R0 and adding 
                        '   incr each time?  Because for incr << rBase,
                        '   rounding error could distort R0. 

                        ' The escape point starts out equal to 
                        ' the point to be tested.
                        r = r0 ' Real and imaginary
                        i = i0 ' parts for the test loop.
                
                        rsq = r * r ' Compute the starting squares.
                        isq = i * i
                
                        qbc = 0 ' Iteration count

                        ' Continue the loop while the length of the
                        ' vector representing the imaginary escape point
                        ' is less than a test radius, and the number of
                        ' iterations is still less than the cutoff.
                        While ((rsq + isq) < 4) And (qbc < Iterations)
                            ' Each time we pass the test, bump the 
                            ' iteration count.
                            qbc = qbc + 1
                            ' Calculate the next escape point.
                            i = 2 * r * i + i0
                            r = rsq - isq + r0
                            ' Generate the squares of the new escape
                            ' point, for use in the escape test and 
                            ' then in the calculation of the following
                            ' escape point.
                            rsq = r * r
                            isq = i * i
                        End While
                
                        If (rsq + isq) < 4 Then
                            ' If the test point didn't escape,
                            ' it may be part of the Mandelbrot
                            ' Set.  (And then again, it may not.)
                            ItCounts(X) = NOTELIMINATED
                        Else
                            ' Save the number of iterations it
                            ' took to escape, for use in the
                            ' color generator.
                            ItCounts(X) = qbc
                        End If
                    
                        'End If
                    Next
                    ' As each row is finished, call the
                    ' form's thread to display it.
                    Me.Invoke(m_displayCallback, New Object () {y, 0, ItCounts})
                    m_Thread.Sleep(50)
                Next
            End While
        Finally
            RaiseEvent OnTaskComplete(Me)
        End Try
    End Sub

    'Form overrides dispose to clean up the component list.
    Public Overloads Overrides Sub Dispose()
        MyBase.Dispose()
        components.Dispose()
    End Sub


    'NOTE: The following procedure is required by the WFC Form Designer
    'It can be modified using the WFC Form Designer.  
    'Do not modify it using the code editor.
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.picFractal = New System.Windows.Forms.PictureBox()

        Me.AutoScaleBaseSize = New System.Drawing.Size(5, 13)
        Me.Text = "Form1"
        '@design Me.TrayLargeIcon = True
        '@design Me.TrayHeight = 0

        picFractal.Location = New System.Drawing.Point(0, 0)
        picFractal.Size = New System.Drawing.Size(88, 72)
        picFractal.TabIndex = 0
        picFractal.TabStop = False
        picFractal.Text = "picFractal"

        Me.Controls.Add(picFractal)
    End Sub

    '***********************************************************************
    '* Property Thread
    '*
    '* Property that stores the thread associated with the task.
    '***********************************************************************
    Property Thread() As Thread Implements Task.Thread
        Get
            Return m_Thread
        End Get
        Set(ByVal Value As Thread)
            m_Thread = Value
        End Set
    End Property

    '***********************************************************************
    '* Property Name
    '*
    '* Returns the name of the task. 
    '***********************************************************************
    Property TaskName() As String Implements Task.TaskName
        Get
            Return "FractalForm"
        End Get
        Set(ByVal Value As String)

        End Set
    End Property


    '***********************************************************************
    '* PercentComplete
    '* 
    '* Returns the percentage of the fractal image that has been generated.
    '***********************************************************************
    Function PercentComplete() As Integer Implements Task.PercentComplete
        Return m_PercentComplete
    End Function

    '***********************************************************************
    '* Sub FractalDisplayLine
    '*
    '* After FractalCalc generates each row in the image
    '* it calls back into FractalDisplayLine on the form's 
    '* thread which then writes the values into the bitmap on the form.   
    '* Called from the background thread via the Form's Invoke method
    '* so that will run on the Form's main thread.
    '* 
    '***********************************************************************
    Private Sub FractalDisplayLine(ByVal y As Integer, ByVal s As Integer, ByVal itCounts() As Integer)
        Dim x As Integer

        Try
            SyncLock m_bitmap
                For x = 0 To m_ct
                    Dim itsBand As Integer = itCounts(x) \ 16
                    Dim itsStep As Integer = itCounts(x) Mod 16
                    If itsStep = NOTELIMINATED Then
                        m_bitmap.SetPixel(x, y, Color.Black)
                    Else
                        Select Case itsBand
                            Case 0
                                m_bitmap.SetPixel(x, y, ColorInRange(16, itsStep, Color.Blue, FractalColors.LightBlue))
                            Case 1
                                m_bitmap.SetPixel(x, y, ColorInRange(16, itsStep, FractalColors.LightBlue, FractalColors.Yellow))
                            Case 2
                                m_bitmap.SetPixel(x, y, ColorInRange(16, itsStep, FractalColors.Yellow, Color.Red))
                            Case 3
                                m_bitmap.SetPixel(x, y, ColorInRange(16, itsStep, Color.Red, FractalColors.Orange))
                            Case 4
                                m_bitmap.SetPixel(x, y, ColorInRange(16, itsStep, FractalColors.Orange, FractalColors.DullBlue))
                            Case 5
                                m_bitmap.SetPixel(x, y, ColorInRange(16, itsStep, FractalColors.DullBlue, FractalColors.Peach))
                            Case 6
                                m_bitmap.SetPixel(x, y, ColorInRange(16, itsStep, FractalColors.Peach, FractalColors.Reddish))
                            Case 7
                                m_bitmap.SetPixel(x, y, ColorInRange(16, itsStep, FractalColors.Reddish, FractalColors.Yellow))
                            Case 8
                                m_bitmap.SetPixel(x, y, ColorInRange(16, itsStep, FractalColors.Yellow, FractalColors.LightBlue))
                            Case 9
                                m_bitmap.SetPixel(x, y, ColorInRange(16, itsStep, FractalColors.LightBlue, FractalColors.PaleYellow))
                            Case 10
                                m_bitmap.SetPixel(x, y, ColorInRange(16, itsStep, FractalColors.PaleYellow, Color.Red))
                            Case 11
                                m_bitmap.SetPixel(x, y, ColorInRange(16, itsStep, Color.Red, FractalColors.DarkPurple))
                            Case 12
                                m_bitmap.SetPixel(x, y, ColorInRange(16, itsStep, FractalColors.DarkPurple, FractalColors.LightBlue))
                            Case 13
                                m_bitmap.SetPixel(x, y, ColorInRange(16, itsStep, FractalColors.LightBlue, Color.White))
                            Case Else
                                m_bitmap.SetPixel(x, y, Color.White)
                        End Select
                    End If
                Next
            End SyncLock

            'Me.text = "Calculating..." & CInt(100 * y / m_ct) & "%"
            'Me.refresh()
            ' New and cool!  In Frameworks, it's easy to
            ' repaint JUST the area you've changed!  To
            ' see the performance difference, comment out
            ' this line and uncomment Me.Refresh()!



            picFractal.Invalidate(New System.Drawing.Region(New Rectangle(0, 2 * y - 1, 2 * (m_ct + 1) + 1, 4)))
            Application.DoEvents() 'to improve responsiveness
        Catch
            Stop
        End Try
    End Sub

    '***********************************************************************
    '* ColorInRange
    '* 
    '* Returns the indexed color from a 
    '* graduated range of colors between two
    '* RGB endpoints.
    '*
    '* Steps = the number of colors in the 
    '*   range, including the starting color
    '*   but NOT the ending color.  (This
    '*   allows ranges to be stacked end-to-end.)
    '* Index = the color to be used.  The valid
    '*   range for Index is 0 to (Steps - 1).
    '* c1 = starting color.
    '* c2 = ending color.  (This value is never
    '*   returned -- see 'Steps' above.)
    '* 
    '* The calculation of the increments in the
    '* R, G, and B values is arranged to
    '* minimize property access into Color.
    '*
    '* To use a different algorithm,
    '* override this method and change the
    '* way the colors are calculated.
    '***********************************************************************
    Protected Overridable Function ColorInRange(ByVal Steps As Integer, ByVal Index As Integer, ByVal c1 As Color, ByVal c2 As Color) As Color
        If (Index < 0) Or (Index >= Steps) Then Throw New System.IndexOutOfRangeException("Index out of range in ColorInRange")
        ColorInRange = Color.FromArgb(CInt(CDbl((Steps - Index) * c1.R + c2.R * Index) / Steps), CInt(CDbl((Steps - Index) * c1.G + c2.G * Index) / Steps), CInt(CDbl((Steps - Index) * c1.B + c2.B * Index) / Steps))
    End Function

End Class
