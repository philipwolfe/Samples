/*+==========================================================================
  File:      AccountBalance.cs

  Summary:   Sample that uses IsolatedStorage (indirectly by using MinMax).
             The Account balances are input by the user and Min / Max values
             are cached by MinMax.dll in this applications isolated storage. 
             These values are preserved across invocation of this executable.
 
  Classes:   AccountingBalance

  Functions: Main
             
  Author:    Shajan Dasan (shajand@microsoft.com)

  Date:      21 July 2000

----------------------------------------------------------------------------
  This file is part of the Microsoft .NET Samples.

  Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
==========================================================================+*/

using System;
using Sample;

class AccountBalance
{
    // Command line options
    const String c_Reset = "/Reset";

    // Command line help
    const String c_Usage = 
        "Usage :\n\n" +
        "AccountBalance [" + c_Reset + "] [n1] [n2] ...[n]\n" +
        c_Reset + " : Clear history.";

    public static void Main(String[] args)
    {
        MinMax mm = new MinMax();
        int data;

        for (int i = 0; i < args.Length ; ++i)
        {
            if (String.Compare(args[i], c_Reset, true) == 0)
            {
                mm.Reset();
                return;
            }
            else
            {
                // Get the input account balance from command line

                try {
                    data = Int32.Parse(args[i]);
                } catch (Exception) {
                    Console.WriteLine(c_Usage);
                    return;
                }

		// Update MinMax values.
                mm.AddData(data);
            }
        }

        Console.WriteLine("Max account balance to date : " + mm.Max);
        Console.WriteLine("Min account balance to date : " + mm.Min);
    }
}

