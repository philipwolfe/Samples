/*+==========================================================================
  File:      HelloUser.cs

  Summary:   Sample that uses IsolatedStorage (indirectly by using UserName).
 
  Classes:   HelloUser

  Functions: Main
             
  Author:    Shajan Dasan (shajand@microsoft.com)

  Date:      21 July 2000

----------------------------------------------------------------------------
  This file is part of the Microsoft .NET Samples.

  Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
==========================================================================+*/

using System;
using Sample;

class HelloUser
{
    public static void Main(String[] args)
    {
	// Get the user name using the public API provided by UserName.exe
        Console.WriteLine("Hello " + UserName.GetUserName());
    }
}

