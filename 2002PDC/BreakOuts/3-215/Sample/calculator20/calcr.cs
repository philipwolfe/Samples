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
   public class Calc
   {
		//
		// In this version, I've changed the signature of this method to cause
		// the call to fail at runtime.
		//
		public String GetResult()
		{
			return "Invalid";
		}

   }

}