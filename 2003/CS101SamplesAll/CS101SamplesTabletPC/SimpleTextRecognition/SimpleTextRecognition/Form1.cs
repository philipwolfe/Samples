using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Microsoft.Ink;

namespace SimpleTextRecognition
{
	public partial class Form1 : Form
	{
		//Ink collecting object
		InkOverlay inkOverlay;

		//Active recognizer
		Recognizer activeRecognizer;

		public Form1()
		{
			InitializeComponent();

			//Gather ink on the panel
			inkOverlay = new InkOverlay(panel1);
			//Activate ink-gathering
			inkOverlay.Enabled = true;

			//Get all the installed recognizers
			Recognizers recognizers = new Recognizers();

			//Get the default recognizer 
			Recognizer defaultReco = recognizers.GetDefaultRecognizer();
			activeRecognizer = defaultReco;
			AddRecognizerToMenu(defaultReco, true);

			//Recognizer.Equals() and Recognizer.GetHashCode() don't generate comparable values
			//so have to make our own
			string defaultRecoId = defaultReco.Vendor + defaultReco.Name;

			//Iterate over all recognizers, including the default one
			foreach(Recognizer recognizer in recognizers)
			{
				string recognizerId = recognizer.Vendor + recognizer.Name;
				//Don't add the default recognizer again
				if(recognizerId != defaultRecoId)
				{
					AddRecognizerToMenu(recognizer, false);
				}
			}
		}

		void AddRecognizerToMenu(Recognizer recognizer, bool selected)
		{
			//Create a new menu item for the recognizer
			ToolStripMenuItem recognizerSelector = new ToolStripMenuItem(recognizer.Name);

			//Initialize whether it's checked or not and behavior
			recognizerSelector.CheckOnClick = true;
			recognizerSelector.Checked = selected;

			//Handle the click event
			recognizerSelector.Click += delegate(object sender, EventArgs e) { 
				//Note behavir relies on capturing outer-variable "recognizer" 
				activeRecognizer = recognizer; 
				//Clear checks
				foreach(ToolStripMenuItem item in recognizersToolStripMenuItem.DropDownItems)
				{
					item.Checked = false;
				}

				//Check the newly selected one
				recognizerSelector.Checked = true;
			};

			//Add new menu item to menu
			recognizersToolStripMenuItem.DropDownItems.Add(recognizerSelector);
		}

		private void exitToolStripMenuItem_Click(object sender, EventArgs e)
		{
			Application.Exit();
		}

		private void clearToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Clear the last-recognized text (if any)
			listBox1.Items.Clear();

			//Clear the ink
			inkOverlay.Ink.DeleteStrokes();

			//Redraw the screen
			panel1.Invalidate();
		}

		private void recognizeToolStripMenuItem_Click(object sender, EventArgs e)
		{
			//Clear previously recognized text (if any)
			listBox1.Items.Clear();

			//Create a recognition context
			RecognizerContext context = activeRecognizer.CreateRecognizerContext();

			//Recognize all the ink 
			context.Strokes = inkOverlay.Ink.Strokes;

			//That's it for the ink we'll recognize this time
			context.EndInkInput();

			//Recognizer will throw an exception if called with no Strokes
			if(context.Strokes == null || context.Strokes.Count == 0)
			{
				return;
			}

			//Note the use of an "out" variable for status
			RecognitionStatus status;
			RecognitionResult result = context.Recognize(out status);
			
			//If no error
			if(status == RecognitionStatus.NoError)
			{
				//Most likely string
				string topString = result.TopString;
				listBox1.Items.Add(topString);

				//Sometimes, you'll want to see alternates (will include TopString as first result)
				foreach(RecognitionAlternate alternate in result.GetAlternatesFromSelection())
				{
					string alternateString = alternate.ToString();
					listBox1.Items.Add(alternateString);
				}
			}

			//Probably enough to require scrolling, so enable listBox1
			listBox1.Enabled = true;
		}
	}
}