//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

#region Using directives

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Configuration;
using System.Globalization;

#endregion

namespace Microsoft.Samples.CustomTraceListener
{
	// This class is a simple trace creating program
	// It is meant to simulate an application that fires trace events
	// The various buttons produce trace events of various event types
	// The random button randomly selects an event type based on the
	// relative weightings found in the config file
	partial class Form1 : Form
	{
		#region Static Fields
		// This is the trace source that will create the events
		static TraceSource TS = new TraceSource("myTS");
		// Here's a random number generator that will be used to create
		// random events
		static Random myRandGen = new Random();
		// This field records the number of events to fire at once
		static byte numEvents = 1;

		// These fields store the probabilities of each event type for
		// use when the random button is clicked
		static byte Prob_Critical;
		static byte Prob_Error;
		static byte Prob_Warning;
		static byte Prob_Information;
		static byte Prob_Transfer;
		static byte Prob_Start;
		static byte Prob_Stop;
		static byte Prob_Suspend;
		static byte Prob_Resume;
		#endregion

		public Form1()
		{
			InitializeComponent();
		}

		private void Form1_Load(object sender, EventArgs e)
		{
			#region Reading Configuration Settings
			// We read the probabilities from the configuration file when the
			// form is loaded
			AppSettingsReader myReader = new AppSettingsReader();
			Prob_Critical = (byte)myReader.GetValue("Prob_Critical", typeof(byte));
			Prob_Error = (byte)myReader.GetValue("Prob_Error", typeof(byte));
			Prob_Warning = (byte)myReader.GetValue("Prob_Warning", typeof(byte));
			Prob_Information = (byte)myReader.GetValue("Prob_Information", typeof(byte));
			Prob_Transfer = (byte)myReader.GetValue("Prob_Transfer", typeof(byte));
			Prob_Start = (byte)myReader.GetValue("Prob_Start", typeof(byte));
			Prob_Stop = (byte)myReader.GetValue("Prob_Stop", typeof(byte));
			Prob_Suspend = (byte)myReader.GetValue("Prob_Suspend", typeof(byte));
			Prob_Resume = (byte)myReader.GetValue("Prob_Resume", typeof(byte));
			#endregion
		}

		// This method creates a random string of random length 
		// (with a maximum specified by the user). This is used to create
		// random messages for our generated trace events.
		private static string RandomString(int MaxLength)
		{
			// We start with an empty string
			string output = "";
			// And repeat adding a random character up to MaxLength times
			for (int i = 0; i < myRandGen.Next(MaxLength + 1); i++)
			{
				// Each character is from characters value 32 to 127
				char newChar = (char)(myRandGen.Next(32, 127));
				// But we won't allow ;'s because they could interfere with delimited
				// list trace listeners. We'll replace all ;s with *s
				output += newChar == ';' ? '*' : newChar;
			}
			return output;
		}

		// Each of the following methods fires trace events with event types specified
		// by the user. The event ID and message are randomly generated.
		private void CriticalBtn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < numEvents; i++)
			{
				TS.TraceEvent(TraceEventType.Critical, myRandGen.Next(256), RandomString(1000));
			}
		}

		private void ErrorBtn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < numEvents; i++)
			{
				TS.TraceEvent(TraceEventType.Error, myRandGen.Next(256), RandomString(1000));
			}
		}

		private void WarningBtn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < numEvents; i++)
			{
				TS.TraceEvent(TraceEventType.Warning, myRandGen.Next(256), RandomString(1000));
			}
		}

		private void InformationBtn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < numEvents; i++)
			{
				TS.TraceEvent(TraceEventType.Information, myRandGen.Next(256), RandomString(1000));
			}
		}

		private void VerboseBtn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < numEvents; i++)
			{
				TS.TraceEvent(TraceEventType.Verbose, myRandGen.Next(256), RandomString(1000));
			}
		}

		private void ResumeBtn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < numEvents; i++)
			{
				TS.TraceEvent(TraceEventType.Resume, myRandGen.Next(256), RandomString(1000));
			}
		}

		private void RandomBtn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < numEvents; i++)
			{
				TS.TraceEvent(RandomEventType(), myRandGen.Next(256), RandomString(1000));
			}
		}

		private void StartBtn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < numEvents; i++)
			{
				TS.TraceEvent(TraceEventType.Start, myRandGen.Next(256), RandomString(1000));
			}
		}

		private void StopBtn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < numEvents; i++)
			{
				TS.TraceEvent(TraceEventType.Stop, myRandGen.Next(256), RandomString(1000));
			}
		}

		private void SuspendBtn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < numEvents; i++)
			{
				TS.TraceEvent(TraceEventType.Suspend, myRandGen.Next(256), RandomString(1000));
			}
		}

		private void TransferBtn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < numEvents; i++)
			{
				TS.TraceEvent(TraceEventType.Transfer, myRandGen.Next(256), RandomString(1000));
			}
		}

		private void FailBtn_Click(object sender, EventArgs e)
		{
			for (int i = 0; i < numEvents; i++)
			{
				Trace.Fail(RandomString(1000));
			}
		}

		// Trace sources should always be flushed when they're done being used.
		// So, we're sure to flush and close our source as the form closes.
		private void Form1_FormClosing(object sender, FormClosingEventArgs e)
		{
			TS.Flush();
			TS.Close();
		}

		// We want to track how many times the user want the trace events to occur.
		private void NumEventsTxtBox_TextChanged(object sender, EventArgs e)
		{
			byte newNumEvents;
			if (byte.TryParse(NumEventsTxtBox.Text, out newNumEvents))
			{
				numEvents = newNumEvents;
			}
			else
			{
				NumEventsTxtBox.Text = numEvents.ToString(NumberFormatInfo.InvariantInfo);
			}
		}

		// This method randomly picks an event type based on the probabilities
		// that were retrieved from the config files.
		private TraceEventType RandomEventType()
		{
			int value = myRandGen.Next(100) + 1;

			if (value <= Prob_Critical) return TraceEventType.Critical;
			else if (value <= (Prob_Critical + Prob_Error)) return TraceEventType.Error;
			else if (value <= (Prob_Critical + Prob_Error + Prob_Warning)) return TraceEventType.Warning;
			else if (value <= (Prob_Critical + Prob_Error + Prob_Warning + Prob_Information)) return TraceEventType.Information;
			else if (value <= (Prob_Critical + Prob_Error + Prob_Warning + Prob_Information + Prob_Transfer)) return TraceEventType.Transfer;
			else if (value <= (Prob_Critical + Prob_Error + Prob_Warning + Prob_Information + Prob_Transfer + Prob_Start)) return TraceEventType.Start;
			else if (value <= (Prob_Critical + Prob_Error + Prob_Warning + Prob_Information + Prob_Transfer + Prob_Start + Prob_Stop)) return TraceEventType.Stop;
			else if (value <= (Prob_Critical + Prob_Error + Prob_Warning + Prob_Information + Prob_Transfer + Prob_Start + Prob_Stop + Prob_Suspend)) return TraceEventType.Suspend;
			else if (value <= (Prob_Critical + Prob_Error + Prob_Warning + Prob_Information + Prob_Transfer + Prob_Start + Prob_Stop + Prob_Suspend + Prob_Resume)) return TraceEventType.Resume;
			else return TraceEventType.Verbose;
		}
	}
}