//==========================================================================
//  File:		calcr.cs
//
//--------------------------------------------------------------------------
//  This file is part of the Microsoft NGWS Samples.
//
//  Copyright (C) 2000 Microsoft Corporation.  All rights reserved.
//==========================================================================
using System;

namespace PDCDemo.VersionAndDeploy.Calculator
{

   public class InvalidFormulaException : ApplicationException { }

   public class Calc
   {
		public String GetResult(int arg1, Char op, int arg2)
		{
			switch(op)
			{
				case '+':
					return String.Format("{0:####}", arg1 + arg2);
				case '-':
					return String.Format("{0:####}", arg1 - arg2);
				case '/':
					return String.Format("{0:####}", arg1 / arg2);
				default:
					throw new InvalidFormulaException();
			}
		}

   }

}