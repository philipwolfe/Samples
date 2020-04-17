//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Samples.Indigo.Client
{
	static class Program
	{
		static void Main()
		{
            using (SampleServerProxy proxy = new SampleServerProxy())
			{
				Console.WriteLine("Calling Echo(string):");
				Console.WriteLine("Server responds: {0}", proxy.Echo("Simple hello"));

				Console.WriteLine();
				Console.WriteLine("Calling BigEcho(string[]):");
				string[] messages = new string[64];
				for (int i = 0; i < 64; i++)
				{
					messages[i] = "Hello " + i;
				}

				Console.WriteLine("Server responds: {0}", proxy.BigEcho(messages));
                                Console.ReadLine();
			}
		}
	}
}
