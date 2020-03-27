//Copyright (C) 2000 Microsoft Corporation.  All rights reserved.

namespace CSnet
{
	using System;

	/// <summary>
	///    CSnetClient exposes a Main static member function, which
	///    is the entry point into the CSharp client.
	/// </summary>
	public class CSnetClient
	{
		public CSnetClient()
		{
			// no special construction required for this object
		}

		public static int Main(string[] args)
		{
			try 
			{
				netJEPost pJEPost = new netJEPost();					// Create a MGLPost object
				pJEPost.OpenTransaction("JE Soda cost overrun");	// Open a transaction
				pJEPost.AddEntry("111212", (float) 98.72);					// Add a couple of Entries
				pJEPost.AddEntry("111213", (float) -98.72);
				pJEPost.Commit();									// commit the transaction
			}
			catch(Exception e) 
			{
				Console.WriteLine("Exception " + e.Message);
			}
			return 0;
		}
	}
}
