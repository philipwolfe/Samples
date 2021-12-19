//===========================================================================
//	File:		EventSrc.cs
//
//	Summary:	Fire events from managed code
//				Demonstrate bridging managed event model with COM event model.
//
//---------------------------------------------------------------------------
//	Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
//===========================================================================

namespace EventSource
{
	using System;
	using System.Runtime.InteropServices;

	public delegate void ClickDelegate(int x, int y);
	public delegate void ResizeDelegate();
	public delegate void PulseDelegate();

	//Define the event interface
	//It has to be DispInterface for VB6    
	[GuidAttribute("1A585C4D-3371-48dc-AF8A-AFFECC1B0967") ]
	[InterfaceTypeAttribute(ComInterfaceType.InterfaceIsIDispatch)]
	public interface ButtonEvents
	{
		void Click(int x, int y);
		void Resize();
		void Pulse();
	}

	//This is necessary
	//To attribute the class so it can have an event interface 
	[ComSourceInterfaces("EventSource.ButtonEvents")]
	public class Button
	{
		public event ClickDelegate Click;
		public event ResizeDelegate Resize;
		public event PulseDelegate Pulse;
		
		public Button()
		{
			Object o = Type.GetType("EventSource.ButtonEvents");
			if (o != null)
				Console.WriteLine("Event Type Loaded");
			else
				Console.WriteLine("Failed to load the event type");

		}

		public void CauseClickEvent(int x, int y)
		{ 
			Click(x, y);
		}

		public void CauseResizeEvent()
		{ 
			Resize();
		}

		public void CausePulse()
		{
			Pulse();
		}

	}

}


