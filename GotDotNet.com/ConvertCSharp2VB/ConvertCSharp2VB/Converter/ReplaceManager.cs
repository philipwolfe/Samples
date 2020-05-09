/*----------------------------------------------------------------------
	Author:		Kamal Patel
	Date:		Feb 26 2002 AD
	Version:	1.2
	Copyright:	(c) Kamal Patel, All rights reserved.
	Email:		kppatel@yahoo.com
	URL:		http://www.KamalPatel.net
-----------------------------------------------------------------------*/

using System;
using System.Text;

namespace ConvertCSharp2VB
{
	/// <summary>
	/// Exposes static method that help in the replacement process
	/// </summary>
	public class ReplaceManager
	{
		public static string[] Modifiers = {"internal", "new", "private", "protected", "public", "readonly", "static"};

		public static string HandleModifiers(string tcString)
		{
			tcString = tcString.Replace("new ", "Shadows ");
			tcString = tcString.Replace("static ", "Shared ");
			tcString = tcString.Replace("virtual ", "Overridable ");
			tcString = tcString.Replace("sealed ", "NotOverridable ");
			tcString = tcString.Replace("abstract ", "MustOverride ");
			tcString = tcString.Replace("override ", "Overrides ");
			tcString = tcString.Replace("public ", "Public ");
			tcString = tcString.Replace("protected ", "Protected ");
			tcString = tcString.Replace("internal ", "Friend ");
			tcString = tcString.Replace("private ", "Private ");
			tcString = tcString.Replace("void ", " ");
			tcString = tcString.Replace("readonly ", "ReadOnly ");
			tcString = tcString.Replace("volatile ", "<Volatile_Not_Supported> ");
			tcString = tcString.Replace("operator ", "<Operator_Overloading_Not_Supported> ");
			tcString = tcString.Replace("explicit ", "<Explicit_Not_Supported> ");
			tcString = tcString.Replace("implicit ", "<Implicit_Not_Supported> ");
			return tcString;
		}

		public static string HandleTypes(string tcString)
		{
			tcString = tcString.Replace("class", "Class");
			tcString = tcString.Replace("struct", "Structure");
			tcString = tcString.Replace("interface", "Interface");
			tcString = tcString.Replace("enum", "Enum");
			tcString = tcString.Replace("public ", "Public ");
			tcString = tcString.Replace("protected ", "Protected ");
			tcString = tcString.Replace("internal ", "Friend ");
			tcString = tcString.Replace("private ", "Private ");
			tcString = tcString.Replace("new ", "Shadows ");
			tcString = tcString.Replace("abstract ", "MustInherit ");
			tcString = tcString.Replace("sealed ", "NonInheritable ");

			return tcString;
		}

		public static string HandleExpression(string tcExpression)
		{
			// Get a single spaced version of the expression
			tcExpression = ReplaceManager.GetSingledSpacedString(tcExpression);

			// Remove any extra blank spaces from front and back
			tcExpression = tcExpression.Trim();

			// Special handling required for " is " keyword
			int nPos = tcExpression.IndexOf(" is ");
			if(nPos > 0 )
			{
				tcExpression = "TypeOf " + tcExpression.Substring(0, nPos) + tcExpression.Substring(nPos);
				tcExpression = tcExpression.Replace(" is ", " Is ");
			}

			// Special handling required for null
			if (tcExpression.EndsWith("null"))
			{
				// Check if it is a valid null
				string lcExpression = tcExpression.Replace("!=", "!= ");
				lcExpression = lcExpression.Replace("==", "== ");
				if(lcExpression.EndsWith(" null"))
				{
					tcExpression = lcExpression;
					tcExpression = tcExpression.Replace(" null", " Nothing");

					// Handle positive/negative pattern
					if(tcExpression.IndexOf("!=") > 0)
					{
						tcExpression = tcExpression.Replace("!=", " Is ");
						tcExpression = "Not " + tcExpression;
					}
					else
					{
						tcExpression = tcExpression.Replace("==", " Is ");
					}

					// Get the single line version of this string
					tcExpression = ReplaceManager.GetSingledSpacedString(tcExpression);
				}
			}

			return tcExpression;
		}

		public static string HandleDataTypes(string tcString)
		{
			return tcString;
		}

		/// <summary>
		/// Receives a string as a parameter and returns a single spaced string
		/// </summary>
		/// <param name="tcLine"></param>
		/// <returns></returns>
		public static string GetSingledSpacedString(string tcLine)
		{
			StringBuilder sb = new StringBuilder();

			//fix the line so there is not space between any square brackets
			// take a chance for now
			tcLine = tcLine.Replace(" [", "[");
			tcLine = tcLine.Replace(" ;", ";");
			tcLine = tcLine.Replace(" ,", ",");

			string[] aRetVal = tcLine.Split(null);
			for(int i=0; i<aRetVal.Length; i++)
			{
				if(aRetVal[i].Trim().Length > 0)
				{
					sb.Append(aRetVal[i]);
					if(aRetVal[i].EndsWith(",") == false)
					{
						sb.Append(" ");
					}
				}
			}

			//If there is any spacing between an open bracket and the method/expression then remove it.
			sb.Replace(" (", "(");

			return sb.ToString().TrimEnd();
		}

		public static bool IsNextCharValid(string tcLine, string tcCheck)
		{
			tcLine = tcLine.Trim();
			int nLength = tcCheck.Length;
			bool lValid = false;

			if(tcLine == tcCheck)
				lValid = true;
			else
			{
				//make sure that the next character after is is either a space or { 
				int npos = tcLine.IndexOf(tcCheck);
				if((tcLine[npos + nLength + 1] == ' ') || (tcLine[npos+3] == '	') || (tcLine[npos+3] == '{'))
				{
					lValid = true;
				}
			}
			return lValid;
		}
	}
}