//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Diagnostics;
using System.Threading;

public class MSMQOrders
{

	// We might use Properties for a 'real' application

	public int Number;
	public string Customer;
	public DateTime RequiredBy;
	public void Process(Object State)
	{

		// Write out a trace to know that the message has been processed.

		Trace.WriteLine(Number + " - " + Customer + " - " + RequiredBy);

		// Put the thread to sleep to simulate doing some real
		// work like writing the information to the database.

		Thread.Sleep(2000);
	

	}

}

