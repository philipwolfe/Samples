//==========================================================================
//  File:		math.cs
//
//--------------------------------------------------------------------------
//  This file is part of the Microsoft .Net Framework SDK Samples.
//
//  Copyright (C) 2000 Microsoft Corporation.  All rights reserved.
//==========================================================================
using System;
using Samples.Math.Parser;

public class Math 
{

	public String GetResult(int arg1, Char op, int arg2)
	{
		switch(op)
		{
			case '+':
				return String.Format("Result: {0:####}", arg1 + arg2);
			case '-':
				return String.Format("Result: {0:####}", arg1 - arg2);
			case '*':
				return String.Format("Result: {0:####}", arg1 * arg2);
			case '/':
				return String.Format("Result: {0:####}", arg1 / arg2);
			default:
				return "Invalid operator: "+ op;
		}
	}



	public static void Main(string[] args)
	{

		while (true)
		{
			Console.WriteLine("Enter a simple formula. Ex: 4+4: (or q to quit)");
			String formula = Console.ReadLine();

			if (formula == "q") break;

			// parse the formula and get the arguments
			Parser p = new Parser();
			try
			{
				Arguments a = p.Parse(formula);
				// do the calc and print the results
				Math m = new Math();
				Console.WriteLine(m.GetResult(a.Arg1.ToInt32(), a.Op, a.Arg2.ToInt32()));
			}
			catch (Exception e)
			{
				Console.WriteLine(e.Message);
			}


		}

	}

}