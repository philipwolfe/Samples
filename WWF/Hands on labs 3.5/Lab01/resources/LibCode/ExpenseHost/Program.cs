//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Http;
using System.Runtime.Remoting.Channels.Tcp;


namespace ExpenseHost
{
	class Program
	{
		
		static void Main(string[] args)
		{

			RemotingConfiguration.Configure("ExpenseHost.exe.config");

			//TcpChannel chan = new TcpChannel(8085);
			//ChannelServices.RegisterChannel(chan);
			//RemotingConfiguration.RegisterWellKnownServiceType(typeof(ExpenseLocalServices.ExpenseRemoteService),
			//    "ExpenseRemoteService", WellKnownObjectMode.Singleton);

			System.Console.WriteLine("Hit <enter> to exit...");
			System.Console.ReadLine();
		}
	}
}
