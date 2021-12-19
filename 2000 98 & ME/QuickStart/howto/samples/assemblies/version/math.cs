//==========================================================================
//  File:		math.cs
//
//--------------------------------------------------------------------------
//  This file is part of the Microsoft .Net Framework SDK Samples.
//
//  Copyright (C) 2000 Microsoft Corporation.  All rights reserved.
//==========================================================================
using System;
using Samples.Math.Calculator;
using Samples.Math.Parser;

public class Math 
{

	public static void Main(string[] args)
	{

		while (true)
		{
			Console.WriteLine("Enter Formula: (or q to quit)");
			String formula = Console.ReadLine();

			if (formula == "q") break;

			// parse the formula and get the arguments
			Parser p = new Parser();
			Arguments a = p.Parse(formula);

			// do the calc and print the results
			Calc c = new Calc();
			Console.WriteLine(c.GetResult(a.Arg1.ToInt32(), a.Op, a.Arg2.ToInt32()));
		}

	}

}