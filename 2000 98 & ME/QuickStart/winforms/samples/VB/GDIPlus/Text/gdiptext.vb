'//------------------------------------------------------------------------------
'/// <copyright from='1997' to='2001' company='Microsoft Corporation'>           
'///    Copyright (c) Microsoft Corporation. All Rights Reserved.                
'///       
'///    This source code is intended only as a supplement to Microsoft
'///    Development Tools and/or on-line documentation.  See these other
'///    materials for detailed information regarding Microsoft code samples.
'///
'/// </copyright>                                                                
'//------------------------------------------------------------------------------

Imports System
Imports System.WinForms
Imports System.IO
Imports System.Drawing
Imports System.Drawing.Drawing2D
Imports Microsoft.VisualBasic

namespace Microsoft.Samples.WinForms.VB.GDIPlus.GDIPText 

    public class TextSample
        Inherits System.WinForms.Form 

        private backgroundBrush As Brush 
        private textTextureBrush As Brush
        private titleFont As Font
        private textFont As Font
        private titleShadowBrush As Brush
        private flowedText1 As string = "I went down to the St James Infirmary," & ControlChars.Crlf & "Saw my baby there," & ControlChars.Crlf & "Stretched out on a long white table," & ControlChars.Crlf & "So sweet,so cold,so fair," & ControlChars.Crlf & "Let her go,let her go,God bless her," & ControlChars.Crlf & "Wherever she may be," & ControlChars.Crlf & "She can look this wide world over," & ControlChars.Crlf & "But she'll never find a sweet man like me," & ControlChars.Crlf & "When I die want you to dress me in straight lace shoes," & ControlChars.Crlf & "I wanna a boxback coat and a Stetson hat," & ControlChars.Crlf & "Put a twenty dollar gold piece on my watch chain," & ControlChars.Crlf & "So the boys'll know that I died standing up."
        private flowedText2 As string = "the sky seems full when you're in the cradle" & ControlChars.Crlf & "the rain will fall and wash your dreams" & ControlChars.Crlf & "stars are stars and they shine so hard..." & ControlChars.Crlf & "now spit out the sky because its empty" & ControlChars.Crlf & "and hollow and all your dreams are hanging out to dry" & ControlChars.Crlf & "stars are stars and they shine so cold..." & ControlChars.Crlf & "once i like crying twice i like laughter" & ControlChars.Crlf & "come tell me what i'm after"
        private japaneseFont As Font 
        private japaneseText As string = new string(new char(){CType(31169, Char),  CType(12398, Char),  CType(21517, Char),  CType(21069, Char),  CType(12399, Char),  CType(12463, Char),  CType(12522, Char),  CType(12473, Char),  CType(12391, Char),  CType(12377, Char),  CType(12290,Char)})
        private linearGradBrush As Brush
        private doJapaneseSample As boolean = true

        shared Sub Main()
            System.WinForms.Application.Run(new TextSample())
        End Sub

        public Sub New() 
            MyBase.New()
                                       
            SetStyle(ControlStyles.Opaque, true)

            '//Make sure we redraw on resize
            SetStyle(ControlStyles.ResizeRedraw,true)

            Me.Size = new Size(750, 500)
            Me.Text = "GDI+ Text Samples"

            '//Load the image to be used for the background from the exe's resource fork
            Dim backgroundImage As Image = new Bitmap(GetType(TextSample), "colorbars.jpg")

            '//Now create the brush we are going to use to paint the background
            backgroundBrush = new TextureBrush(backgroundImage)

            '//Load the image to be used for the textured text from the exe's resource fork
            Dim textImage As Image = new Bitmap(GetType(TextSample), "marble.jpg")
            textTextureBrush = new TextureBrush(textImage)

            '//Load the fonts we want to use
            me.Font = new Font("Times New Roman", 20)
            titleFont = new Font("Times New Roman", 60)
            textFont = new Font("Times New Roman", 11)

            '//Set up shadow brush - make it translucent
            titleShadowBrush = new SolidBrush(Color.FromARGB(70, Color.Black))

            '//Set up fonts and brushes for printing japanese text
            try 
                japaneseFont = new Font("MS Mincho", 36)
                linearGradBrush = new LinearGradientBrush(new Point(0, 0), new Point(0, 45), Color.Blue, Color.Red)
            catch ex as Exception 
                MessageBox.Show("The Japanese font MS Mincho needs be present to run the Japanese part of this sample" & ControlChars.Crlf & "" & ControlChars.Crlf & "" + ex.Message)
                doJapaneseSample = false
            end try

        End Sub

        protected overrides Sub OnPaint(e as PaintEventArgs) 
            Dim g As Graphics = e.Graphics

            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias

            '//Fill the background use the texture brush 
            '//and then apply a white wash 
            g.FillRectangle(backgroundBrush, ClientRectangle)
            g.FillRectangle(new SolidBrush(Color.FromARGB(180, Color.White)), ClientRectangle)

            '//Simple draw hello world
            g.DrawString("Hello World", me.Font, new SolidBrush(Color.Black), 10,10)

            '//Draw a textured string
            Dim titleText as String = "Graphics  Samples"
            g.DrawString(titleText, titleFont, titleShadowBrush, 15, 25)
            g.DrawString(titleText, titleFont, textTextureBrush, 10, 20)

            Dim textToDraw As String = "Hello Symetrical World"

            '//Use Measure string to display a string at the center of the window
            Dim windowCenter As Double = me.DisplayRectangle.Width/2             
            Dim stringSize As SizeF = e.Graphics.MeasureString(textToDraw, textFont)
            Dim startPos As Double = windowCenter-(stringSize.Width/2)
            g.DrawString(textToDraw, textFont, new SolidBrush(Color.Red), Ctype(startPos,Single), 10)

            '//Now draw a string flowed into a rectangle
            Dim rectangle1 As RectangleF = new RectangleF(20, 150, 250, 300) 
            g.FillRectangle(new SolidBrush(Color.Gainsboro), rectangle1)
            g.DrawString(flowedText1, textFont, new SolidBrush(Color.Blue), rectangle1)

            '//Draw more flowed text but this time center it
            Dim rectangle2 As RectangleF = new RectangleF(450, 150, 250, 300) 
            g.FillRectangle(new SolidBrush(Color.Gainsboro), rectangle2)
            Dim format As StringFormat = new StringFormat()
            format.Alignment=StringAlignment.Center
            g.DrawString(flowedText2, textFont, new SolidBrush(Color.Blue), rectangle2,format)

            '//Work out how many lines and characters we printed just now
            Dim characters As Integer = 0
            Dim lines As Integer = 0
            e.Graphics.MeasureString(flowedText2, textFont, rectangle2.Size, format, characters, lines)
            Dim whatRenderedText As string = "We printed " + Ctype(characters,string) + " characters and " + Ctype(lines,string) + " lines"
            e.Graphics.DrawString(whatRenderedText, textFont, new SolidBrush(Color.Black), 400,440)

            '//If we have the Japanese language pack draw some text in Japanese
            '//Rotate it to make life truly exciting
            if (doJapaneseSample) then
                g.RotateTransform(-30)
                g.TranslateTransform(-180, 300)
                g.DrawString(japaneseText, japaneseFont, linearGradBrush, 200, 140)
                g.ResetTransform()
            End If

        End Sub

    End Class
End Namespace
