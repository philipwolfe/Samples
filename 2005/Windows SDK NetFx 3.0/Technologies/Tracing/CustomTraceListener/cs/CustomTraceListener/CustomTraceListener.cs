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
using System.Diagnostics;
using System.Security.Permissions;
using System.Globalization;

#endregion

namespace Microsoft.Samples.CustomTraceListener
{
	[HostProtection(Synchronization = true)]
	public class AudioTraceListener: TraceListener
	{
		#region Private Fields

		// This field will be used to remember whether or not we have loaded
		// the custom tone information contained in the config yet. The initial
		// value is, of course, false.
		private bool attributesLoaded = false;

		// These values represent the frequencies used to signal the indicated
		// event types. Also, there is a value that determines how many 
		// milliseconds each tone should sound for. All of these values are
		// initialized to a default value in case the user does not specify
		// a value for each one.
		private short FailFrequencyValue = 100;
		private short CriticalFrequencyValue = 300;
		private short ErrorFrequencyValue = 400;
		private short WarningFrequencyValue = 500;
		private short InformationFrequencyValue = 600;
		private short VerboseFrequencyValue = 700;
		private short SuspendFrequencyValue = 800;
		private short ResumeFrequencyValue = 800;
		private short StartFrequencyValue = 800;
		private short StopFrequencyValue = 800;
		private short TransferFrequencyValue = 800;
		private short ToneLengthValue = 250;

		#endregion

		#region Public Properties

		// These public properties correspond to the similarly named
		// fields above. These properties give the user the ability to
		// set and get the frequencies (and tone length) programatically.
		public short FailFrequency
		{
			get { 
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				return FailFrequencyValue; 
			}
			set {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; }
				FailFrequencyValue = value; 
			}
		}
		public short CriticalFrequency
		{
			get {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; }
				return CriticalFrequencyValue; 
			}
			set {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; }
				CriticalFrequencyValue = value; 
			}
		}
		public short ErrorFrequency
		{
			get {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				return ErrorFrequencyValue;
			}
			set {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				ErrorFrequencyValue = value;
			}
		}
		public short WarningFrequency
		{
			get {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				return WarningFrequencyValue;
			}
			set {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				WarningFrequencyValue = value;
			}
		}
		public short InformationFrequency
		{
			get {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				return InformationFrequencyValue;
			}
			set {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				InformationFrequencyValue = value;
			}
		}
		public short VerboseFrequency
		{
			get {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				return VerboseFrequencyValue;
			}
			set {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				VerboseFrequencyValue = value;
			}
		}
		public short SuspendFrequency
		{
			get {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				return SuspendFrequencyValue;
			}
			set {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				SuspendFrequencyValue = value;
			}
		}
		public short ResumeFrequency
		{
			get {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				return ResumeFrequencyValue;
			}
			set {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				ResumeFrequencyValue = value;
			}
		}
		public short StartFrequency
		{
			get {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				return StartFrequencyValue;
			}
			set {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				StartFrequencyValue = value;
			}
		}
		public short StopFrequency
		{
			get {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				return StopFrequencyValue;
			}
			set {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				StopFrequencyValue = value;
			}
		}
		public short TransferFrequency
		{
			get {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				return TransferFrequencyValue;
			}
			set {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				TransferFrequencyValue = value;
			}
		}
		public short ToneLength
		{
			get {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				return ToneLengthValue;
			}
			set {
				if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; } 
				ToneLengthValue = value;
			}
		}

		// This boolean property should be overridden by all custom listeners.
		// It indicates to the tracing system whether or not it is safe to not
		// lock while tracing an event with this listener. If the Trace.UseGlobalLock
		// property is set to false either programatically or in the trace section  
		// of the application's config file then only listeners with 
		// IsThreadSafe == false will lock while tracing an event. On the other hand, 
		// if UseGlobalLock == true, then a lock will be taken for each trace source
		// present to trace with each listeners it contains. This listener is thread
		// safe because we are willing to risk obscuring some sounds by having them
		// play simultaneously. Most listeners are not threadsafe.
		public override bool IsThreadSafe
		{
			get { return true; }
		}

		#endregion

		#region Constructors

		// These are the two constructors that are present on our base,
		// the trace listener. We simply call the base constructor in each
		// case.

		public AudioTraceListener(): base() { }

		public AudioTraceListener(string Name): base(Name) { }

		#endregion

		#region Overriden Methods

		// Any custom trace listener that can take custom attributes through a 
		// configuration file must override this method. The method should return
		// an array of strings that represents all of the names that are allowed
		// to appear in a configuration file under the definition of that listener 
		// type. If an attribute appears that is not either on this list or accepted by
		// a basic trace listener, then a configuration exception will be thrown when
		// the listener is created. Of course, this is only a list of all possible
		// attributes, not all required attributes. So, if only some or none of these
		// items appear in the configuration file, that will still be all right.
		protected override string[] GetSupportedAttributes()
		{
			return new string[] {	"CriticalFrequency", "ErrorFrequency", "WarningFrequency", "InformationFrequency",
									"VerboseFrequency", "SuspendFrequency", "ResumeFrequency", "StartFrequency",
									"StopFrequency", "TransferFrequency", "ToneLength", "FailFrequency" };
		}

		// Here we override the methods that handle TraceData calls to the listener.
		// The base trace listener would call WriteHeader, then write the data 
		// items, and then call WriteFooter. WriteHeader and WriteFooter would each
		// call write themselves. WriteHeader writes the source name, the event 
		// type, and the id. WriteFooter writes the information stored in the event
		// cache. Because of the way this system works, many more conventional
		// custom listeners do not need to override the TraceData methods.
  		public override void TraceData(TraceEventCache eventCache, string source, TraceEventType currentEventType, int id, object data)
		{
			if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; }
			PlayEventType(currentEventType);
		}

		public override void TraceData(TraceEventCache eventCache, string source, TraceEventType currentEventType, int id, params object[] data)
		{
			if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; }
			PlayEventType(currentEventType);
		}

		// Here we override the methods that handle TraceEvent calls to the listener.
		// The base trace listener would call WriteHeader, then write the message, 
		// and then call WriteFooter. WriteHeader and WriteFooter would each
		// call write themselves. WriteHeader writes the source name, the event 
		// type, and the id. WriteFooter writes the information stored in the event
		// cache. Because of the way this system works, many more conventional
		// custom listeners do not need to override the TraceData methods.
		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType currentEventType, int id, string format, params object[] args)
		{
			if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; }
			PlayEventType(currentEventType);
		}

		public override void TraceEvent(TraceEventCache eventCache, string source, TraceEventType currentEventType, int id, string message)
		{
			if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; }
			PlayEventType(currentEventType);
		}

		// This method is used if Trace.Assert or Trace.Fail causes a failure
		// while this listener is present in trace's listener collection. 
  		public override void Fail(string message, string detailMessage)
		{
			if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; }
			Console.Beep(FailFrequency, ToneLength * 2);
		}

		// Write is one of two methods that is abstract in the base trace listener
		// and therefore must be overridden. It is abstract because for many 
		// listeners, this is the method that defines the listeners output method.
		// This custom listener is unusual in that it does not make much use of the
		// Write method. More conventional listeners would override this method
		// instead of the TraceData and TraceEvent methods which ultimately just 
		// call this method. This listener's output, though, is very dependent on
		// the trace event's event type and therefore most of the work is done at
		// the TraceEvent and TraceData levels since this method no longer knows
		// what event type the message it's handling has come from.
		public override void Write(string message)
		{
			if (!attributesLoaded) { LoadAttributes(); attributesLoaded = true; }
			PlayEventType(TraceEventType.Information);
		}

		// WriteLine is the other abstract method that must be overridden in all
		// custom listeners. Typically, as in this case, its behavior will simply
		// depend on the Write method.
		public override void WriteLine(string message)
		{
			Write(message + "\n");
		}

		#endregion

		#region Private Methods

		private void PlayEventType(TraceEventType currentEventType)
		{
			#region Beep

			// Which beep is sounded depends on the event type so we simply
			// switch based on the event type and play the appropriate beep.
			// The tone frequency and length are determined by the appropriate
			// attributes of the listener.
			switch (currentEventType)
			{
				case TraceEventType.Critical:
					Console.Beep(CriticalFrequency, ToneLength);
					break;
				case TraceEventType.Error:
					Console.Beep(ErrorFrequency, ToneLength);
					break;
				case TraceEventType.Warning:
					Console.Beep(WarningFrequency, ToneLength);
					break;
				case TraceEventType.Information:
					Console.Beep(InformationFrequency, ToneLength);
					break;
				case TraceEventType.Verbose:
					Console.Beep(VerboseFrequency, ToneLength);
					break;
				case TraceEventType.Start:
					Console.Beep(StartFrequency, ToneLength);
					break;
				case TraceEventType.Stop:
					Console.Beep(StopFrequency, ToneLength);
					break;
				case TraceEventType.Resume:
					Console.Beep(ResumeFrequency, ToneLength);
					break;
				case TraceEventType.Suspend:
					Console.Beep(SuspendFrequency, ToneLength);
					break;
				case TraceEventType.Transfer:
					Console.Beep(TransferFrequency, ToneLength);
					break;
				default:
					Console.Beep(FailFrequency, ToneLength);
					break;
			}
			#endregion
		}

		private void LoadAttributes()
		{
			// This method actually reads the custom attributes' values from the
			// configuration file. We call this method the first time the attributes
			// are accessed. We do not do this when the listener is constructed because
			// the attributes will not yet have been read from the configuration file.
			// Any time one of the attributes is accessed, we check whether or not this
			// method has been called yet (stored in the attributesLoaded bool) and if
			// not we first call this method and flip the attributesLoaded boolean and
			// then proceed with accessing the attribute.

			if (Attributes.ContainsKey("CriticalFrequency")) CriticalFrequencyValue = short.Parse(Attributes["CriticalFrequency"], NumberFormatInfo.InvariantInfo);
			if (Attributes.ContainsKey("ErrorFrequency")) ErrorFrequencyValue = short.Parse(Attributes["ErrorFrequency"], NumberFormatInfo.InvariantInfo);
			if (Attributes.ContainsKey("WarningFrequency")) WarningFrequencyValue = short.Parse(Attributes["WarningFrequency"], NumberFormatInfo.InvariantInfo);
			if (Attributes.ContainsKey("InformationFrequency")) InformationFrequencyValue = short.Parse(Attributes["InformationFrequency"], NumberFormatInfo.InvariantInfo);
			if (Attributes.ContainsKey("VerboseFrequency")) VerboseFrequencyValue = short.Parse(Attributes["VerboseFrequency"], NumberFormatInfo.InvariantInfo);
			if (Attributes.ContainsKey("SuspendFrequency")) SuspendFrequencyValue = short.Parse(Attributes["SuspendFrequency"], NumberFormatInfo.InvariantInfo);
			if (Attributes.ContainsKey("ResumeFrequency")) ResumeFrequencyValue = short.Parse(Attributes["ResumeFrequency"], NumberFormatInfo.InvariantInfo);
			if (Attributes.ContainsKey("StartFrequency")) StartFrequencyValue = short.Parse(Attributes["StartFrequency"], NumberFormatInfo.InvariantInfo);
			if (Attributes.ContainsKey("StopFrequency")) StopFrequencyValue = short.Parse(Attributes["StopFrequency"], NumberFormatInfo.InvariantInfo);
			if (Attributes.ContainsKey("TransferFrequency")) TransferFrequencyValue = short.Parse(Attributes["TransferFrequency"], NumberFormatInfo.InvariantInfo);
			if (Attributes.ContainsKey("ToneLength")) { ToneLengthValue = short.Parse(Attributes["ToneLength"], NumberFormatInfo.InvariantInfo); }
		}

		#endregion

	}
}
