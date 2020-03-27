using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Ink;

namespace InkEnabledTextBox
{
    public partial class Form1 : Form
    {
        InkOverlay inkOverlay;
        bool isDisposed;

        public Form1()
        {
            InitializeComponent();

            //Initialize inkOverlay and associate it with textBox1
            inkOverlay = new InkOverlay(textBox1);
            inkOverlay.Enabled = true;

            //Turn off timer until the pen rises and a Stroke is added
            inkOverlay.CursorDown += delegate(object sender, InkCollectorCursorDownEventArgs e)
            {
                timer1.Stop();
            };

            //Recognition occurs when timer1.Interval (5 seconds) passes without a new Stroke being added
            inkOverlay.Stroke += delegate(object sender, InkCollectorStrokeEventArgs e)
            {
                timer1.Start();
            };

            //A timer is used to allow multiple strokes / words to be added prior to a recognition attempt
            timer1.Tick += delegate(object sender, EventArgs e)
            {
                try
                {
                    //Is there ink to recognize?
                    if (inkOverlay.Ink.Strokes == null || inkOverlay.Ink.Strokes.Count == 0)
                    {
                        return;
                    }
                    //Retrieve the default recognizer
                    Recognizers recognizers = new Recognizers();
                    Recognizer recognizer = recognizers.GetDefaultRecognizer();

                    //Recognition is done with a recognition context
                    RecognizerContext context = recognizer.CreateRecognizerContext();
                    //Add current ink to the context
                    context.Strokes = inkOverlay.Ink.Strokes;
                    //Stop ink collection for context
                    context.EndInkInput();

                    //Perform recognition
                    RecognitionStatus status;
                    RecognitionResult result = context.Recognize(out status);
                    if (status == RecognitionStatus.NoError)
                    {
                        string topString = result.TopString;
                        
                        //Replace or, if no selection, append at cursor
                        textBox1.SelectedText += topString;
                    }
                }
                finally
                {
                    //Clear the ink
                    inkOverlay.Ink.DeleteStrokes();
                    //Redraw the textbox
                    textBox1.Invalidate();

                    //Timer has done its job until more ink added
                    timer1.Stop();
                }
            };
        }
    }
}