//-----------------------------------------------------------------------
//  This file is part of the Microsoft .nET SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AnD InFORMATIOn ARE PROVIDED AS IS WITHOUT WARRAnTY OF AnY
//KInD, EITHER EXPRESSED OR IMPLIED, InCLUDInG BUT nOT LIMITED TO THE
//IMPLIED WARRAnTIES OF MERCHAnTABILITY AnD/OR FITnESS FOR A
//PARTICULAR PURPOSE.
//-----------------------------------------------------------------------

using System;
using System.Collections;

namespace Microsoft.Samples.Globalization.Culture
{
	/// <summary>
	/// Constants required for the application.
	/// </summary>
	sealed class Constants
	{
		private Constants()
		{
		}

		public const Int64 LongNumber = 123456789;
		public const char CharHyphen = '-';
		public const string Hyphen = "-";
		public const string Comma = ",";
		public const string Space = " ";
		public const string Dot = ".";
		public const string Slash = "/";
		public const string SemiColon = ";";
		public const string NumberFormat = "n";
		public const string CurrencyFormat = "C";
		public const string ShortDateFormat = "d";
		public const string LongDateFormat = "D";
		public const string TimeFormat = "T";
		public const string Dollar = "$";
		public const string Minus = "-";
		public const string SampleNumber = "1.1";

		public static string[] PositiveFormat = { "{0}{1}", "{1}{0}", "{0} {1}", "{1} {0}" };

		public static string[] NegativeFormat = { "({0}{1})", "-{0}{1}", "{0}-{1}", "{0}{1}-", 
												"({1}{0})", "-{1}{0}", "{1}-{0}", "{1}{0}-", 
												"-{1} {0}", "-{0} {1}", "{1} {0}-", "{0} {1}-", 
												"{0} -{1}", "{1}- {0}", "({0} {1})", "({1} {0})"};

		public static object[] NumberGroupFormats = { "123456789", "123,456,789",
												"12,34,56,789" };
		public static object[] ShortDateFormats = { "M/d/yyyy", "M/d/yy", "MM/dd/yy",
												"MM/dd/yyyy" };
		public static object[] TimeFormats = { "h:mm:ss tt", "hh:mm:ss tt", "H:mm:ss", 
												"HH:mm:ss" };
		public static object[] LongDateFormats = { "dddd, MMMM dd, yyyy", 
												"MMMM dd, yyyy", "dddd, dd MMMM, yyyy", 
												"dd MMMM, yyyy" };

		public const string SuccessMessage = "Registered.";
		public const string ErrorNeutralCulture = "Neutral cultures cannot be parsed.";
		public const string ErrorFileFound = "\".nlp\" file already exists.";
		public const string ErrorInvalidName = "Invalid name.";

		/**
		 * Reusing the PositiveFormat strings for both currency and number
		 * Replaces the characters and returns the string format
		 */
		public static string[] GetNumberFormat(bool positive, string currencySymbol, string type)
		{
			string[] str = null;

			//Retrieve from positive or negative list
			str = (positive == true) ? PositiveFormat : NegativeFormat;
			string[] stringList = new string[str.Length];
			for (int i = 0; i < str.Length; ++i)
			{
				//Temp string for replacement for retaining the original string 
				stringList[i] = String.Format(str[i], currencySymbol, type);
			}
			return stringList;

		}
	}
}
