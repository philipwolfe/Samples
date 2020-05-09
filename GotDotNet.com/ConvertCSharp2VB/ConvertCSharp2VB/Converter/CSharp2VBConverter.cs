/*----------------------------------------------------------------------
	Author:		Kamal Patel
	Date:		Feb 26 2002 AD
	Desc:		Receives C# source code as a parameter and converts
				it to VB .NET 
	Version:	1.2
	Copyright:	(c) Kamal Patel
				Please read the copyright notice in Copyright.doc
	Email:		kppatel@yahoo.com
	URL:		http://www.KamalPatel.net
-----------------------------------------------------------------------*/

using System;
using System.Text.RegularExpressions;
using System.Text;
using System.Collections;

namespace ConvertCSharp2VB
{

	/// <summary>
	/// Converts a C# source code block to VB.Net code block
	/// </summary>
	public class CSharpToVBConverter
	{
		private string[] Modifiers;
		private string[] DataTypes;
		private string[] MethodModifiers = {"new","public", "protected", "internal", "private", "static", "virtual", "abstract", "override", "sealed", "extern", "void"};
		private ArrayList Stack = new ArrayList();
		private static int nStackCounter = -1;
		private string TokenStarter = "<" + "__" ;
		private string TokenEnder = "__" + ">" ;
		private string BlankLineToken = "<__0__>";
		private string EndOfAssignedArray = " _ 'CSharp2VBArray";

		public CSharpToVBConverter()
		{
			//Create the Modifiers collection
			Modifiers = new string[7];
			Modifiers[0] = "internal";
			Modifiers[1] = "new";
			Modifiers[2] = "private";
			Modifiers[3] = "protected";
			Modifiers[4] = "public";
			Modifiers[5] = "readonly";
			Modifiers[6] = "static";

			//Create the DataTypes collection
			DataTypes = new string[15];
			DataTypes[0] = "sbyte";
			DataTypes[1] = "short";
			DataTypes[2] = "int";
			DataTypes[3] = "long";
			DataTypes[4] = "byte";
			DataTypes[5] = "ushort";
			DataTypes[6] = "unit";
			DataTypes[7] = "ulong";
			DataTypes[8] = "float";
			DataTypes[9] = "double";
			DataTypes[10] = "decimal";
			DataTypes[11] = "bool";
			DataTypes[12] = "char";
			DataTypes[13] = "object";
			DataTypes[14] = "string";
		}


		/// <summary>
		/// Receives a C# code block in string format as a parameter and converts it into VB.Net code
		/// </summary>
		/// <param name="tcText"></param>
		/// <returns></returns>
		public string Execute(string tcText)
		{
			string lcText = "";

			//Reset the stack count
			CSharpToVBConverter.nStackCounter = -1;


			//Startup work, Initialization and break the lines for visibility
			tcText = this.FixLines(this.HandleBlankLines(tcText));				//blank lines
			tcText = this.FixLines(this.PushQuotesToStack(tcText, "\""));		//double quotes
			tcText = this.FixLines(this.PushQuotesToStack(tcText, "\'"));		//single quotes
			tcText = this.FixLines(this.PushCommentsToStack(tcText));		//comments
			tcText = this.FixLines(this.HandleLineBreakDown(tcText));

			//Multi-Line comments
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.HandleMultiLineComments(tcText));
			}
			catch
			{
				tcText = "'Error: Converting Multi-Line comments \r\n" + lcText;
			}

			//Attributes (Also handles casting conversions)
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.HandleAttributes(tcText));
			}
			catch
			{
				tcText = "'Error: Converting Attributes \r\n" + lcText;
			}

			//return tcText;
			////////////////////////////////////////////////////////////////////////
			///Loops
			////////////////////////////////////////////////////////////////////////
			
			//ForEach Loop
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.CommonHandler(tcText, "foreach", 0));
			}
			catch
			{
				tcText = "'Error: Converting For Each-Loops \r\n" + lcText;
			}

			//Do Loop
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.CommonHandler(tcText, "do", 0));
			}
			catch
			{
				tcText = "'Error: Converting Do-While Loops \r\n" + lcText;
			}

			//while-until
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.CommonHandler(tcText, "while", 0));
			}
			catch
			{
				tcText = "'Error: Converting While-Loops \r\n" + lcText;
			}
			
			//For Loop
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.HandleForBlocks(tcText));
			}
			catch
			{
				tcText = "'Error: Converting For-Loops \r\n" + lcText;
			}

			////////////////////////////////////////////////////////////////////////
			///Conditional Blocks
			////////////////////////////////////////////////////////////////////////
			//Try-Catch-Finally
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.HandleTryCatchFinally(tcText));
			}
			catch
			{
				tcText = "'Error: Converting Try-Catch-Finally Blocks \r\n" + lcText;
			}

			//Catch
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.CommonHandler(tcText, "catch", 1));
			}
			catch
			{
				tcText = "'Error: Converting Catch bolcks in Try-Catch-Finally \r\n" + lcText;
			}

			//If-Else-End If Blocks 
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.HandleIfBlock(tcText));
			}
			catch
			{
				tcText = "'Error: Converting If-Else-End If Blocks \r\n" + lcText;
			}

			//Switch Blocks
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.CommonHandler(tcText, "switch", 0));
			}
			catch
			{
				tcText = "'Error: Converting Switch Blocks \r\n" + lcText;
			}

	
			////////////////////////////////////////////////////////////////////////
			///classes, structs, enums, namespaces, properties
			////////////////////////////////////////////////////////////////////////
			//structs
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.CommonHandler(tcText, "struct ", 1));
			}
			catch
			{
				tcText = "'Error: Converting Structures \r\n" + lcText;
			}

			//Classes
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.CommonHandler(tcText, "class ", 1));
			}
			catch
			{
				tcText = "'Error: Converting Classes \r\n" + lcText;
			}

			//Interfaces
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.CommonHandler(tcText, "interface ", 1));
			}
			catch
			{
				tcText = "'Error: Converting Interfaces \r\n" + lcText;
			}

			//Enumerators
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.CommonHandler(tcText, "enum", 1));
			}
			catch
			{
				tcText = "'Error: Converting Enumerators \r\n" + lcText;
			}

			//Namespaces
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.CommonHandler(tcText, "namespace", 0));
			}
			catch
			{
				tcText = "'Error: Converting Namespaces \r\n" + lcText;
			}

			////////////////////////////////////////////////////////////////////////
			///Math operations, declarations and methods
			////////////////////////////////////////////////////////////////////////
			// Object++ to Object = Object + 1
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.HandleMathOperations(tcText));			//Has to be before declarations
			}
			catch
			{
				tcText = "'Error: Converting Math operations Object++ to Object = Object + 1 \r\n" + lcText;
			}
	
			// Declarations and Fields
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.HandleDeclaration(tcText));
			}
			catch
			{
				tcText = "'Error: Converting Declarations and Fields \r\n" + lcText;
			}
	
			// Conditional Operator ?:
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.HandleConditionalOperator(tcText));
			}
			catch
			{
				tcText = "'Error: Converting Conditional operator ?: \r\n" + lcText;
			}

			// Methods, Functions and Constructors
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.HandleMethod(tcText));
			}
			catch
			{
				tcText = "'Error: Converting Methods, Functions and Constructors \r\n" + lcText;
			}
	

			//Properties
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.HandleProperties(tcText));				//Has to be after methods, classes and structs 
			}
			catch
			{
				tcText = "'Error: Converting Properties \r\n" + lcText;
			}

			//Case Blocks (Moved after methods and properties)
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.CommonHandler(tcText, "case", 0));
			}
			catch
			{
				tcText = "'Error: Converting Case Blocks \r\n" + lcText;
			}

			//Handle casting
			try
			{
				lcText = tcText;
				tcText = this.FixLines(this.HandleCasting(tcText));
			}
			catch
			{
				tcText = "'Error: Converting Casting from C# to VB.Net \r\n" + lcText;
			}

			//Ground work and cleanup
			tcText = this.HandleReplacements(tcText);
			tcText = this.FixLines(this.PopQuotesFromStack(tcText));
			tcText = this.HandlePostReplacements(tcText);
			tcText = tcText.TrimEnd() + "\r\n\r\n" + this.GetFooter();
			return tcText;
		}

		protected string FixLines(string tcText)
		{
			tcText = tcText.Replace("\r", "");
			return tcText.Replace("\n", "\r\n");
		}

		
		/// <summary>
		/// Called by HandleLineBreakDown() method so moving the brackets on next line is common
		/// </summary>
		/// <param name="tsb"></param>
		/// <param name="tcString"></param>
		/// <param name="tcBlankToken"></param>
		protected void HandleBrakets(ref StringBuilder tsb, string tcString, string tcBlankToken)
		{
			tsb.Append(tcBlankToken);
			string lcString = tcString.Trim();
			for(int j=0; j<lcString.Length; j++)
			{
				if(lcString[j] == '{' || lcString[j] == '}')
				{
					tsb.Append("\n" + tcBlankToken + lcString[j].ToString() + "\n");
					if(lcString[j] == '{')
						tsb.Append(tcBlankToken + "	");
				}
				else
				{
					tsb.Append(lcString[j]);
				}
			}


		}
		
		/// <summary>
		/// Returns a new token number 
		/// </summary>
		/// <returns></returns>
		protected string GetNewToken()
		{
			// Get the new token 
			CSharpToVBConverter.nStackCounter = CSharpToVBConverter.nStackCounter + 1;
			return this.TokenStarter + nStackCounter.ToString() + this.TokenEnder;
		}

		/// <summary>
		/// Handles the blank lines by adding a token.
		/// Later on when the real tokens are poped it will be taken care of
		/// </summary>
		/// <param name="tcString"></param>
		/// <returns></returns>
		private string HandleBlankLines(string tcText)
		{
			//get the first token the 0th one
			string cToken = this.GetNewToken();
			//this.BlankLineToken = cToken;
			string cOriginal = " ";

			MappingToken o = new MappingToken();
			o.cOriginal = cOriginal;
			o.cToken = cToken;
			this.Stack.Add(o);

			StringBuilder sb = new StringBuilder();
			string[] aText = tcText.Split('\n');
			string lcStr;

			for(int i =0; i < aText.Length; i++)
			{
				lcStr = aText[i].Trim();
				if(lcStr.Length == 0)
				{
					aText[i] = cToken;
				}

				sb.Append(aText[i] + "\n");
			}
			return sb.ToString();
		}


		/// <summary>
		/// Pops all the quotes tokens from the stack
		/// </summary>
		/// <param name="tcText"></param>
		/// <returns></returns>
		/// <todo>
		/// Escape charactes should be handled appropriately at a later time
		/// </todo>
		private string PopQuotesFromStack(string tcText)
		{
			StringBuilder sb = new StringBuilder();
			string[] aText = tcText.Split('\n');
			string lcStr;

			for(int i =0; i < aText.Length; i++)
			{
				lcStr = aText[i].Trim();

				if(this.IsHandled(lcStr))
				{
					sb.Append(aText[i]+ "\n");
					continue;
				}

				//Handle the double quotes first
				int nStart = aText[i].IndexOf("<__");
				if(nStart < 0)
				{
					//no quotes
					sb.Append(aText[i]+ "\n");
					continue;
				}
				
				int nEnd = aText[i].IndexOf("__>", nStart+1);
				if(nEnd < 0)
				{
					//no quotes
					sb.Append(aText[i]+ "\n");
					continue;
				}

				string cTokenNo = aText[i].Substring(nStart + 3, nEnd-(nStart+3));
				string cOriginal = ((MappingToken)this.Stack[int.Parse(cTokenNo)]).cOriginal;
				aText[i] = aText[i].Substring(0, nStart) + cOriginal + aText[i].Substring(nEnd+3);

				i--;
				continue;

			}
			return sb.ToString();
		}


		/// <summary>
		/// Locate the quoted strings and push them on the stack
		/// </summary>
		/// <param name="tcText"></param>
		/// <param name="tcCheckString"></param>
		/// <returns></returns>
		/// <todo>
		/// Escape charactes should be handled appropriately at a later time
		/// </todo>
		private string PushQuotesToStack(string tcText, string tcCheckString)
		{
			StringBuilder sb = new StringBuilder();
			string[] aText = tcText.Split('\n');
			string lcStr;

			for(int i =0; i < aText.Length; i++)
			{
				lcStr = aText[i].Trim();

				if(this.IsHandled(lcStr))
				{
					sb.Append(aText[i]+ "\n");
					continue;
				}

				//Handle the double quotes first
				int nStart = aText[i].IndexOf(tcCheckString);
				if(nStart < 0)
				{
					//no quotes
					sb.Append(aText[i]+ "\n");
					continue;
				}
				
				int nEnd = aText[i].IndexOf(tcCheckString, nStart+1);
				if(nEnd < 0)
				{
					//no quotes
					sb.Append(aText[i]+ "\n");
					continue;
				}

				string cOriginal = aText[i].Substring(nStart, nEnd-nStart+1);
				string cToken = this.GetNewToken();
				aText[i] = aText[i].Substring(0, nStart) + cToken + aText[i].Substring(nEnd+1);

				//Fix the original string to be double quotes as VB does not support
				//single quotes
				if(tcCheckString == "\'")
				{
					cOriginal = cOriginal.Replace("\'", "\"") + "c";
				}

				MappingToken o = new MappingToken();
				o.cOriginal = cOriginal;
				o.cToken = cToken;
				this.Stack.Add(o);
				i--;
				continue;

			}

			return sb.ToString();
		}

		private string PushCommentsToStack(string tcText)
		{
			StringBuilder sb = new StringBuilder();
			string[] aText = tcText.Split('\n');
			string lcStr;

			for(int i =0; i < aText.Length; i++)
			{
				lcStr = aText[i].Trim();

				//Handle the comments
				int nStart = aText[i].IndexOf("//");
				if(nStart < 0)
				{
					sb.Append(aText[i]+ "\n");
					continue;
				}
				
				string cOriginal = "'" + aText[i].Substring(nStart + 2);
				string cToken = this.GetNewToken();
				aText[i] = aText[i].Substring(0, nStart) + cToken ;
				sb.Append(aText[i]+ "\n");

				MappingToken o = new MappingToken();
				o.cOriginal = cOriginal;
				o.cToken = cToken;
				this.Stack.Add(o);
				//i--; do this once for a line only
				continue;

			}
			return sb.ToString();
		}

		/// <summary>
		/// Handles the breakdown of lines so the spacing is maintained as c#
		/// allows to have multiple statements in a single line
		/// </summary>
		/// <param name="tcText"></param>
		/// <returns></returns>
		private string HandleLineBreakDown(string tcText)
		{
			StringBuilder sb = new StringBuilder();
			string[] aText = tcText.Split('\n');
			BaseManager b = new BaseManager();
			string lcStr;

			for(int i =0; i<aText.Length; i++)
			{
				lcStr = aText[i].Trim();

				if(this.IsHandled(lcStr))
				{
					sb.Append(aText[i]+ "\n");
					continue;
				}

				if(lcStr.StartsWith("{") && lcStr.Length == 1)
				{
					sb.Append(aText[i] + "\n");
					continue;
				}

				if(lcStr.StartsWith("}") && lcStr.Length == 1)
				{
					sb.Append(aText[i] + "\n");
					continue;
				}

				if(lcStr.IndexOf("}") >= 0 || lcStr.IndexOf("}") >= 0)
				{
					//if the line contains the tokens while or until then ignore the line
					if((lcStr.IndexOf("while") > 0) || lcStr.IndexOf("until") >0)
					{
						sb.Append(aText[i] + "\n");
						continue;
					}

					//Handle it appropriately
					b.GetBlankToken(aText[i]);
					this.HandleBrakets(ref sb, aText[i], b.BlankToken);
					sb.Append("\n");
					continue;
				}
				else if(lcStr.EndsWith("{"))
				{
					//break it down into two lines
					b.GetBlankToken(aText[i]);
					this.HandleBrakets(ref sb, aText[i], b.BlankToken);
					sb.Append("\n");
					continue;
				}
				else
				{
					sb.Append(aText[i] + "\n");
				}

			}
			return sb.ToString();
		}


		/// <summary>
		/// Handles the namespace declaration
		/// </summary>
		/// <param name="tcText"></param>
		/// <returns></returns>
		private string HandleReplacements(string tcText)
		{
			tcText = Regex.Replace(tcText, "using ", "Imports ");
			tcText = Regex.Replace(tcText, "==", "=");

			this.ReplaceTypes(ref tcText, "bool", "Boolean");
			this.ReplaceTypes(ref tcText, "byte", "Byte");
			this.ReplaceTypes(ref tcText, "char", "Char");
			this.ReplaceTypes(ref tcText, "decimal", "Decimal");
			this.ReplaceTypes(ref tcText, "double", "Double");
			this.ReplaceTypes(ref tcText, "float", "single");
			this.ReplaceTypes(ref tcText, "int", "Integer");
			this.ReplaceTypes(ref tcText, "long", "Long");
			this.ReplaceTypes(ref tcText, "object", "Object");
			this.ReplaceTypes(ref tcText, "short", "Short");
			this.ReplaceTypes(ref tcText, "string", "String");
			this.ReplaceTypes(ref tcText, "sbyte", "System.SByte");
			this.ReplaceTypes(ref tcText, "uint", "System.UInt32");
			this.ReplaceTypes(ref tcText, "ulong", "System.UInt64");
			this.ReplaceTypes(ref tcText, "ushort", "System.UInt16");
			this.ReplaceTypes(ref tcText, "this", "Me");
			this.ReplaceTypes(ref tcText, "base", "MyBase");


			tcText = Regex.Replace(tcText, "true", "True");
			tcText = Regex.Replace(tcText, "false", "False");
			tcText = Regex.Replace(tcText, "typeof", "Type.GetType");
			tcText = Regex.Replace(tcText, "public ", "Public ");
			tcText = Regex.Replace(tcText, "///", "'--");
			tcText = Regex.Replace(tcText, "//", "'");
			tcText = Regex.Replace(tcText, "new", "New");
			tcText = Regex.Replace(tcText, "try", "Try");
			tcText = Regex.Replace(tcText, "catch", "Catch");
			tcText = Regex.Replace(tcText, "finally", "Finally");
			tcText = Regex.Replace(tcText, "return", "Return");
			tcText = Regex.Replace(tcText, "throw ", "Throw ");
			tcText = Regex.Replace(tcText, "!=", "<>");
			tcText = Regex.Replace(tcText, "! =", "<>");
			tcText = Regex.Replace(tcText, ";", "");
			tcText = Regex.Replace(tcText, "goto", "GoTo");
			tcText = tcText.Replace("[", "(");
			tcText = tcText.Replace("]", ")");
			tcText = tcText.Replace(">>", ">");
			tcText = tcText.Replace("<<", "<");
			tcText = tcText.Replace(" || ", " Or ");
			tcText = tcText.Replace(" && ", " And ");


			// tcText = tcText.Replace("ref ", "");		//remove any calls where we pass by reference because vb takes care of it
			// tcText = tcText.Replace("out ", "");		//remove any calls where we pass by reference because vb takes care of it
			this.ReplaceTypes(ref tcText, "ref", "");
			this.ReplaceTypes(ref tcText, "out", "");

			//tcText = Regex.Replace(tcText, "#region Windows Form Designer generated code", "#Region \"Windows Form Designer generated code\"");
			//tcText = Regex.Replace(tcText, "#region Web Form Designer generated code",  "#Region \"Web Form Designer generated code\"");
			//tcText = Regex.Replace(tcText, "#region ([a-Z]*)", "#Region \"$1");
			tcText = Regex.Replace(tcText, "#endregion", "#End Region");
			tcText = Regex.Replace(tcText, "null", "Nothing");
			tcText = Regex.Replace(tcText, "!", "Not ");
			tcText = this.FixLines(this.FixArrays(tcText));
			tcText = this.FixLines(this.HandleExits(tcText));

			return tcText;

		}

		// Handle the post replacements after all the strings have been popped out of the stack
		private string HandlePostReplacements(string tcText)
		{
			// Handle removing the @ symbol from strings
			// (@\"([^\"])) : Look for any combination of the @ symbol followed by a double quote. Make sure that it is not followed by another bouble quote
			// \"$2 : As we have two groups in the above condition. Add a double quote and leave the second group as is
			tcText = Regex.Replace(tcText, "(@\"([^\"]))", "\"$2");

			// Handle the #region blocks
			// ^#region ((\\w*\\s*)*) : Look for a pattern that begins with #region followed by any number of words or spaces
			// #Region \"$1\" : Replace it with quotes around the string and add the #Region in the beginning
			tcText = Regex.Replace(tcText, "^#region ((\\w*\\s*)*)", "#Region \"$1\"");

			// Handle Decimal.Remainder
			// =([a-zA-Z0-9 \\.\\(\\)]*)[%]([a-zA-Z0-9 \\.\\(\\)]*): Look for a pattern that begins with = followed by another number of characters including spaces, digits, characters, (, ) or dots. Then followed by a percent and then again followed by characters, spaces, dots or parenthesis.
			// = Decimal.Remainder($1, $2) : Replace with Decimal.Remainder()
			tcText = Regex.Replace(tcText, "=([a-zA-Z0-9 \\.\\(\\)]*)[%]([a-zA-Z0-9 \\.\\(\\)]*)", "= Decimal.Remainder($1, $2)");

			return tcText;
		}


		private string FixArrays(string tcText)
		{
			StringBuilder sb = new StringBuilder();
			string[] aText = tcText.Split('\r');
			for(int i = 0; i < aText.Length; i++)
			{
				if(aText[i].EndsWith(this.EndOfAssignedArray))
				{
					StringBuilder s = new StringBuilder();
					aText[i] = aText[i].Replace(this.EndOfAssignedArray, "");
					s.Append(aText[i] + " ");
					i++;

					do
					{
						s.Append(aText[i].Trim());
						if(aText[i].Trim().IndexOf("}") >= 0)
						{
							break;
						}
						i++;
					}while(true);

					sb.Append(s.ToString() + "\r");
				}
				else
				{
					sb.Append(aText[i] + "\r");
				}
			}
			return sb.ToString();

		}


		/// <summary>
		/// Looks for specific patters for the exit loop and fixes the ONE that we passed
		/// </summary>
		/// <param name="aText"></param>
		/// <param name="nStart"></param>
		private void FixExit(ref string[] aText, int nStart)
		{
			string lcCurrent = "";
			for(int i = nStart; i > 0; i--)
			{

				lcCurrent = aText[i].TrimStart();
				//Sub,Function,Property,Do,For,While,Select,Try
				if(lcCurrent.IndexOf("Sub ") >= 0)
				{
					aText[nStart] = aText[nStart].Replace("break", "Exit Sub");
					break;
				}
				else if(lcCurrent.IndexOf("Function ") >=0)
				{
					aText[nStart] = aText[nStart].Replace("break", "Exit Function");
					break;
				}
				else if(lcCurrent.IndexOf("Property ") >= 0)
				{
					aText[nStart] = aText[nStart].Replace("break", "Exit Property");
					break;
				}
				else if(lcCurrent.StartsWith("Do ") == true)
				{
					aText[nStart] = aText[nStart].Replace("break", "Exit Do");
					break;
				}
				else if(lcCurrent.StartsWith("For ") == true)
				{
					aText[nStart] = aText[nStart].Replace("break", "Exit For");
					break;
				}
				else if(lcCurrent.StartsWith("While ") == true)
				{
					aText[nStart] = aText[nStart].Replace("break", "Exit While");
					break;
				}
				else
				{
					//nothing
				}
			}

		}

		/// <summary>
		/// Handles all the exits by looking for specific keywords and then handing the exit appropriately
		/// </summary>
		/// <param name="tcText"></param>
		/// <returns></returns>
		private string HandleExits(string tcText)
		{
			StringBuilder sb = new StringBuilder();
			string[] aText = tcText.Split('\r');

			for(int i = 0; i < aText.Length; i++)
			{
				if(aText[i].Trim() == "break")
				{
					// we found a customer. Now we pass this to the appropriate handle to fix it
					this.FixExit(ref aText, i);
				}
				sb.Append(aText[i] + "\r");
			}
			return sb.ToString();
		}


		/// <summary>
		/// Returns the footer that is added to the end of the generated VB.Net code
		/// </summary>
		/// <returns></returns>
		private string GetFooter()
		{
			string lcFooter = "";
			lcFooter += "'----------------------------------------------------------------\r\n"; 
			lcFooter += "' Converted from C# to VB .NET using CSharpToVBConverter(1.2).\r\n";
			lcFooter += "' Developed by: Kamal Patel (http://www.KamalPatel.net) \r\n" ;
			lcFooter += "'----------------------------------------------------------------\r\n"; 
			return lcFooter;
		}

		
		/// <summary>
		/// Handles multi line comments by commenting each line
		/// </summary>
		/// <param name="tcText"></param>
		/// <returns></returns>
		protected string HandleMultiLineComments(string tcText)
		{
			string[] aText = tcText.Split('\r');
	
			//Loop through each line of the string 
			int i;
			bool lStart = false;
			for(i = 0; i < aText.Length; i++)
			{
				//start making the changes when we encounter the symbol "/*"
				if(lStart)
				{
					//Make the change and continue
					aText[i] = "// " + aText[i].Replace("\n", "") + "\n";


					//Maybe we are at the end point so check for terminator
					if(aText[i].IndexOf("*/") >= 0)
					{
						//locate the actual end point
						int nEndPt = aText[i].IndexOf("*/");
						aText[i] = aText[i].Substring(0, nEndPt + 2) + "\n" + aText[i].Substring(nEndPt +2);

						lStart = false;
					}
				}
				else
				{
					//Make the check here
					if(aText[i].Trim().StartsWith("//") == false && aText[i].IndexOf("/*") >=0)
					{
						lStart = true;
						aText[i] = aText[i].Replace("/*", "");

						//decrement the value of i so it gets picked up
						i--;
					}
				}

			}

			return this.Build(ref aText);
		}

		public void ReplaceTypes(ref string tcText, string tcOld, string tcNew)
		{

			tcText = tcText.Replace(" " + tcOld + " ", " " + tcNew + " ");
			tcText = tcText.Replace("	" + tcOld + " ", "	" + tcNew + " ");
			tcText = tcText.Replace("(" + tcOld + ")", "(" + tcNew + ")");
			tcText = tcText.Replace("(" + tcOld + " ", "(" + tcNew + " ");
			tcText = tcText.Replace("\n" + tcOld + " ", "\n" + tcNew + " ");
			tcText = tcText.Replace(tcOld + ".", tcNew + ".");
			tcText = tcText.Replace(" " + tcOld + "(", " " + tcNew + "(");
			tcText = tcText.Replace("	" + tcOld + "(", "	" + tcNew + "(");
			tcText = tcText.Replace(" " + tcOld + "\r", " " + tcNew + "\r");
			tcText = tcText.Replace("	" + tcOld + "\r", "	" + tcNew + "\r");
			tcText = tcText.Replace(" " + tcOld + "\n", " " + tcNew + "\n");
			tcText = tcText.Replace("	" + tcOld + "\n", "	" + tcNew + "\n");
			tcText = tcText.Replace(" " + tcOld + ";", " " + tcNew + ";");
			tcText = tcText.Replace("	" + tcOld + ";", "	" + tcNew + ";");
			tcText = tcText.Replace("=" + tcOld + "(", "=" + tcNew + "(");
			tcText = tcText.Replace(" " + tcOld + "(", " " + tcNew + "(");
			tcText = tcText.Replace("=" + tcOld + "[", "=" + tcNew + "[");
			tcText = tcText.Replace(" " + tcOld + "[", " " + tcNew + "[");
			tcText = tcText.Replace(" " + tcOld + ")", " " + tcNew + ")");
			tcText = tcText.Replace("," + tcOld + ")", "," + tcNew + ")");
		}




		/// <summary>
		/// Handles all the attributes
		/// </summary>
		/// <param name="tcText"></param>
		/// <returns></returns>
		protected string HandleAttributes(string tcText)
		{
			//Search for a pattern where the line begins with [ and ends with ]
			string[] aText = tcText.Split('\r');
	
			//Loop through each line of the string 
			int i;
			for(i = 0; i < aText.Length; i++)
			{
				//this.HandleCasting(ref aText[i]);

				//When we find the line starting with [ symbol we begin
				if(aText[i].Trim().StartsWith("["))
				{
					//Locate the ending position
					for(int j=i; j<aText.Length; j++)
					{
						if(aText[j].Trim().EndsWith("]"))
						{
							//we have a match for an attribute
							//Change the [ to < and ] to >
							int npos = aText[i].IndexOf("[");
							aText[i] = aText[i].Substring(0, npos) + "<<" + aText[i].Substring(npos+1);
							
							npos = aText[j].IndexOf("]");
							aText[j] = aText[j].Substring(0, npos) + ">> _ " + aText[j].Substring(npos+1);
							break;
						}

					}
				}
			}

			return this.Build(ref aText);
		}

		/// <summary>
		/// Handles all the math operations such as ++ and replaces them with VB version
		/// </summary>
		/// <param name="tcText"></param>
		/// <returns></returns>
		protected string HandleMathOperations(string tcText)
		{
			string[] aText = tcText.Split('\r');
			MathManager mm = new MathManager();

			//Loop through each line of the string 
			int i;
			for(i = 0; i < aText.Length; i++)
			{
				if(this.IsHandled(aText[i]))
					continue;

				//Check if we can find the pattern
				if(aText[i].IndexOf("++") >= 0 || aText[i].IndexOf("--") >=0)
				{
					if(aText[i].Trim().StartsWith("for"))
						continue;

					aText[i] = mm.GetBlock(aText[i] + "\r\n");
				}
			}

			return this.Build(ref aText);
		}

		/// <summary>
		/// Handles all the conditional operators that contain the pattern ?:
		/// </summary>
		/// <param name="tcText"></param>
		/// <returns></returns>
		protected string HandleConditionalOperator(string tcText)
		{
			string[] aText = tcText.Split('\r');

			//Loop through each line of the string 
			int i;
			for(i = 0; i < aText.Length; i++)
			{
				if(this.IsHandled(aText[i]))
					continue;

				//Check if we can find the pattern
				if(aText[i].IndexOf("?") >= 0 || aText[i].IndexOf(":") >=0)
				{
					string lcSearchPattern;
					string lcReplacePattern;

					// Check if the pattern begins with the word return
					if(aText[i].Trim().StartsWith("return"))
					{
						lcSearchPattern = "([ ]*return[ ]*)([a-zA-Z0-9 \\.\\(\\)]*)[?]([a-zA-Z0-9 \\.\\(\\)]*)[:]([a-zA-Z0-9 \\.\\(\\)]*)";
						lcReplacePattern = "$1 IIf($2, $3, $4)";
					}
					else
					{
						lcSearchPattern = "([a-zA-Z0-9 \\.\\(\\)]*)[=]([a-zA-Z0-9 \\.\\(\\)]*)[?]([a-zA-Z0-9 \\.\\(\\)]*)[:]([a-zA-Z0-9 \\.\\(\\)]*)";
						lcReplacePattern = "$1= IIf($2, $3, $4)";
					}

					// Apply the pattern update
					string lcResult = Regex.Replace(aText[i], lcSearchPattern, lcReplacePattern);
					aText[i] = lcResult + "\r\n";
				}
			}

			return this.Build(ref aText);
		}

		protected bool IsNextCharValidVariable(string tcLine, int tnStart)
		{
			//quick and dirty for now
			if((tcLine.Trim().EndsWith(";") || (tcLine.Trim().EndsWith(")"))))
			{
				tcLine = tcLine.Replace(") ", ")");
			}

			//Check if this is the last character in the string
			if(tnStart == tcLine.Length)
				return false;

			//if the next character is a space then simply ignore it
			char lcNextChar = tcLine[tnStart + 1];

			int nAscii = (int)lcNextChar;
			if((nAscii == 95) || (nAscii == 40) || (nAscii >= 65 && nAscii <= 90) || (nAscii >= 97 && nAscii <= 122))
			{
				return true;
			}
			else
			{
				return false;
			}
		}
		
		public string HandleCasting(string tcText)
		{
			StringBuilder sb = new StringBuilder();
			string[] aText = tcText.Split('\n');

			for(int i =0; i<aText.Length; i++)
			{
				if(aText[i].IndexOf("(") > 0)
					this.GetFixedCasting(ref aText[i]);

				sb.Append(aText[i] + "\n");
			}
			return sb.ToString();
		}

		protected void GetFixedCasting(ref string tcLine)
		{
			int nStart = -1;
			do
			{
				int npos = tcLine.IndexOf("(", nStart + 1);

				nStart = npos;
				if(npos < 0)
					break;

				tcLine = tcLine.Replace("( ", "(");
				tcLine = tcLine.Replace(" )", ")");

				//Make sure that the next character after the open bracket is a valid variable beginner
				if(IsNextCharValidVariable(tcLine, nStart) == true)
				{
					// we either have an _ or [A-Z] or [a-z]
					//Now check if the closing bracket exists
					int nCloseParen = tcLine.IndexOf(")", nStart + 1);
					if (nCloseParen < 0)
						break;

					//refine the position of nStart based on the position of the closing bracket
					nStart = tcLine.Substring(0, nCloseParen).LastIndexOf("(");
					npos = nStart;

					//Get the position of the first space and see if the space is not before the close paren
					int nSpacePos = tcLine.IndexOf(" ", nStart + 1);
					if((nSpacePos == -1) || (nSpacePos > nCloseParen))
					{
						if(IsNextCharValidVariable(tcLine, nCloseParen) == true)
						{
							string lcVariable = "";
							int nEndLocation = -1;
							//bool lLoopUntilClose = false;
							bool lfound = false;
							int nOpenBr = 0, nClosedBr = 0;

							//new logic to determine end point in a cast
							for(int i=nCloseParen + 1; i<tcLine.Length; i++)
							{
								switch(tcLine[i])
								{
									case ';':
									{
										//if we encounter a semicolon we are done
										lfound = true;
										break;
									}
									case ')':
									{
										nClosedBr++;
										break;
									}
									case '(':
									{
										nOpenBr++;
										break;
									}
								}

								//Check the status
								if(lfound == false)
								{
									//check the brackt counts and update the flag
									if(nClosedBr > nOpenBr)
									{
										lfound = true;
									}
									else
										continue;
								}

								if(lfound)
								{
									// we hit the mark
									nEndLocation = i - 1;
									break;
								}

							}

							if(lfound == true)
							{
								lcVariable = tcLine.Substring(nCloseParen +1, (nEndLocation - nCloseParen )).Trim();
								string cCandidate = tcLine;
								string one = tcLine.Substring(0, npos) ;
								string two = "CType(" + lcVariable + ", " ;
								string three = tcLine.Substring(npos + 1, (nCloseParen - (npos+1)));
								if((three.Trim().StartsWith("(")) && (three.Trim().EndsWith(")")))
								{
									three = three.TrimStart().Substring(1) ;
								}
								else
								{
									three += ")";
								}

								string four = tcLine.Substring(nEndLocation + 1).TrimStart();
								// [Leave these comments here for now]
								//cCandidate = tcLine.Substring(0, npos) + 
								//	"CType(" + lcVariable + ", " + tcLine.Substring(npos + 1, (nCloseParen - npos -1)) + " )" +
								//	tcLine.Substring(nEndLocation) ;
								/*if(one.TrimEnd().EndsWith("(") && three.StartsWith(")"))
								{
									one = one.Substring(0, one.Length -1);
									three = three.Substring(1);
								}*/
								cCandidate = one + two + three + four;
								tcLine = cCandidate ;
							}
						}
					}
					else
					{
						break;
					}
				}

			} while(true);

		}



		/// <summary>
		/// Handles all the calls for for blocks
		/// </summary>
		/// <param name="tcText"></param>
		/// <returns></returns>
		private string HandleForBlocks(string tcText)
		{
			string[] aText = tcText.Split('\r');

			//Loop through the array and look for for block
			int i;
			for(i=0; i< aText.Length; i++)
			{
				string lcCurrent = aText[i];
				int nEnd = i;
				bool lHandled = false;
				StringBuilder sb = new StringBuilder();
				string cBlock = "";
				int j = 0;
				string cForLine = "";

				if(lcCurrent.Trim().StartsWith("for"))
				{
					int nOpenedBr = 0;
					int nClosedBr = 0;
					cForLine = lcCurrent;
					int nBrPos = 0;
					bool ColonChecked = false;
					int nColonPos;
					int nRightPos = 0;
					//Loop through the block and locate the first {

					for(j=i+1; j<aText.Length; j++)
					{
						if(this.IsHandled(aText[j]))
						{
							sb.Append(aText[j] + "\n");
							continue;
						}

						//locate the position of a semicolon
						if(ColonChecked == false)
						{

							if(aText[j].StartsWith("for"))
							{
								nRightPos = aText[j].LastIndexOf(")");
								nColonPos = aText[j].IndexOf(";", nRightPos);
								nBrPos = aText[j].IndexOf("{", nRightPos);
							}
							else
							{
								nColonPos = aText[j].IndexOf(";");
								nBrPos = aText[j].IndexOf("{");
							}

							if(nBrPos>nColonPos)
							{
								//update the flag and don't come in this loop again
								ColonChecked = true;
							}
							else if(nColonPos > nBrPos)
							{
								//Get the value from here itself and break out of here
								sb.Append(aText[j]);
								lHandled = true;
								nEnd = j;
								cBlock = sb.ToString();
								break;
							}
							else 
							{
								//nothing
							}
						}

						if(lHandled == false)
						{
							//locate the ending of the block
							if(aText[j].IndexOf("{") > 0)
								nOpenedBr += 1;
			
							if(aText[j].IndexOf("}") > 0)
								nClosedBr += 1;
		
							sb.Append(aText[j]);

							if(nOpenedBr != 0 && nClosedBr!=0)
							{
								if(nOpenedBr-nClosedBr == 0)
								{
									nEnd = j;
									cBlock = sb.ToString();
									break;
								}
							}
						}

					}

					ForBlockManager fbm = new ForBlockManager();
					string cRetVal = fbm.GetForBlock(this, cForLine, cBlock);
					this.UpdateIfBlock(ref aText, cRetVal, i, j);
				}
			}

			return this.Build(ref aText);
		}

		protected string Build(ref string[] taText)
		{
			StringBuilder s = new StringBuilder();
			for(int i=0; i<taText.Length; i++)
			{
				s.Append(taText[i]);
			}

			return s.ToString();
		}

		protected string GetErrLine()
		{
			return "'----- Error occured when converting -----'\n";
		}


		/// <summary>
		/// Returns a bool indicating if the current line is a method or not
		/// </summary>
		/// <param name="tcLine"></param>
		/// <returns></returns>
		private bool IsMethod(string tcLine)
		{
			//Logic to determine if the line is a method beginner
			// Rule 0. If the item is an indexer return back
			// Rule 1. The last character of the method is a closing parenthesis
			// Rule 2. Currently we use that the method HAS to begin with one of the method modifier
			// Rule 3. Check if [ is before ( because chances are that it is an array declaration
	
			tcLine = ReplaceManager.GetSingledSpacedString(tcLine);

			if((tcLine.StartsWith("Default ")) || (tcLine.StartsWith("While ")) || (tcLine.StartsWith("Select ")))
				return false;

			bool llRetVal = false;

			//Discard simple method calls e.g. "MyMethod.DoMethod(Para1, Para2);" as they will have semicolon as the last character
			//e.g. Object o = new Object();
			if(tcLine.EndsWith(")"))
			{
				//Check if [ exists
				if(tcLine.IndexOf("[") >= 0)
				{
					//different check
					if(tcLine.IndexOf("(") < tcLine.IndexOf("["))
					{
						llRetVal = true;
					}
				}
				else
				{
					llRetVal = true;
				}
			}
			return llRetVal;
		}

		
		/// <summary>
		/// Handles the calls for all methods
		/// </summary>
		/// <param name="tcText"></param>
		/// <returns></returns>
		private string HandleMethod(string tcText)
		{
			string[] aText = tcText.Split('\r');
	
			//Loop through each line of the string and check if the string is a class
			int i;
			for(i = 0; i < aText.Length; i++)
			{
				//stop only when we encounter an a method
				string lcCurrent = aText[i];

				if(this.IsHandled(lcCurrent))
					continue;

				//Unline others it is difficult to determine if the line is a method or not
				//IsMethod() determines that process
				if(this.IsMethod(lcCurrent))
				{
					int nStartBr = 0;
					int nEndBr = 0;
					int j;
					int nEnd = i;
					string cRetVal = "";
					StringBuilder sb = new StringBuilder();
					bool lHandled = false;
					for(j= i; j<aText.Length; j++)
					{
						sb.Append(aText[j]);

						if(this.IsHandled(aText[j]))
						{
							continue;
						}

						if(aText[j].IndexOf("{") > 0)
							nStartBr++;

						if(aText[j].IndexOf("}") > 0)
							nEndBr++;


						if(nStartBr !=0 && nEndBr !=0)
						{
							if(nStartBr-nEndBr == 0)
							{
								//we reached the end
								nEnd = j;
								lHandled = true;
								break;
							}
						}
					}
					if(lHandled == true)
					{
						//Pass the call to the appropriate manager to handle it
						MethodBlockManager mbm = new MethodBlockManager();
						cRetVal = mbm.GetMethodBlock(lcCurrent, sb.ToString());
						//Update the string
						this.UpdateIfBlock(ref aText, cRetVal, i, nEnd);
					}

				}
			}

			return this.Build(ref aText);
		}


		/// <summary>
		/// Returns a bool indicating if the current line is a property or not
		/// </summary>
		/// <param name="tcLine"></param>
		/// <returns></returns>
		private bool IsProperty(string tcLine)
		{
			//Logic to determine if the line is a method beginner
			// Rule 0. If the line begins with "Default " then it is an indexer
			// Rule 1. The last character of the property is NOT a closing parenthesis
			// Rule 2. Currently we use that the property HAS to begin with one of the method modifier
			// Rule 3. Check for properties after methods are checked so that way properties are handled properly
	
			tcLine = ReplaceManager.GetSingledSpacedString(tcLine);
			if(tcLine.StartsWith("Default "))
				return true;

			//Discard simple method calls e.g. "MyMethod.DoMethod(Para1, Para2);" as they will have semicolon as the last character
			//e.g. Object o = new Object();
			if(tcLine.EndsWith(")") == false && tcLine.EndsWith(";") == false && tcLine.EndsWith("=") == false)
			{
				for(int i=0; i < this.MethodModifiers.Length; i++)
				{
					if(tcLine.StartsWith(this.MethodModifiers[i]))
					{
						if(tcLine.IndexOf("enum") <0 && tcLine.IndexOf("interface") <0 && tcLine.IndexOf("struct") < 0 && tcLine.IndexOf("class") <0)
						{
							return true;
						}
					}
				}
			}
			return false;
		}


		/// <summary>
		/// Handles all the properties
		/// </summary>
		/// <param name="tcText"></param>
		/// <returns></returns>
		private string HandleProperties(string tcText)
		{
			string[] aText = tcText.Split('\r');
	
			//Loop through each line of the string and check if the string is a class
			int i;
			for(i = 0; i < aText.Length; i++)
			{
				//stop only when we encounter an a method
				string lcCurrent = aText[i];

				//Unline others it is difficult to determine if the line is a method or not
				//IsMethod() determines that process
				if(this.IsProperty(lcCurrent))
				{
					int nStartBr = 0;
					int nEndBr = 0;
					int j;
					int nEnd = i;
					string cRetVal = "";
					StringBuilder sb = new StringBuilder();
					for(j= i; j<aText.Length; j++)
					{
						sb.Append(aText[j] + "\r\n");

						if(this.IsHandled(aText[j]))
						{
							continue;
						}

						if(aText[j].IndexOf("{") > 0)
							nStartBr++;

						if(aText[j].IndexOf("}") > 0)
							nEndBr++;


						if(nStartBr !=0 && nEndBr !=0)
						{
							if(nStartBr-nEndBr == 0)
							{
								//we reached the end
								nEnd = j;
								break;
							}
						}
					}
					//Pass the call to the appropriate manager to handle it
					PropertyManager pm = new PropertyManager();
					cRetVal = pm.GetBlock(lcCurrent, sb.ToString());

					//Update the string
					this.UpdateIfBlock(ref aText, cRetVal, i, nEnd);
				}
			}

			return this.Build(ref aText);
		}


		/// <summary>
		/// Receives a string, search value and mode to search for as parameters and 
		/// returns a bool specifying if the condition was successful
		/// </summary>
		/// <param name="tcStr"></param>
		/// <param name="tcSearch"></param>
		/// <param name="tnType"></param>
		/// <returns></returns>
		protected bool CheckIfFound(string tcStr, string tcSearch, int tnType)
		{
			if(tnType == 0)
			{
				//If type is 0 check for starts with
				return tcStr.Trim().StartsWith(tcSearch);
			}
			else
			{
				//search for a contains in the string
				return tcStr.Trim().IndexOf(tcSearch) >=0 ;
			}
		}

		
		/// <summary>
		/// Common handler that receives the string to handle and handles it the generic
		/// way. Supports a third parameter tnType that specifies if the string should be
		/// searched for "begins with " or "contains"
		/// </summary>
		/// <param name="tcText"></param>
		/// <param name="cSearch"></param>
		/// <param name="tnType"></param>
		/// <returns></returns>
		private string CommonHandler(string tcText, string cSearch, int tnType)
		{
			string[] aText = tcText.Split('\r');
	
			//Loop through each line of the string and check if the string is a class
			int i;
			for(i = 0; i < aText.Length; i++)
			{
				//stop only when we encounter an a class
				string lcCurrent = aText[i];

				if(this.IsHandled(lcCurrent))
					continue;

				//Check if the line does not have any brackets
				//if(lcCurrent.Trim().IndexOf(cSearch) >= 0)
				if(this.CheckIfFound(lcCurrent, cSearch, tnType))
				{
					int nStartBr = 0;
					int nEndBr = 0;
					int j;
					int nEnd = i;
					string cRetVal = "";
					StringBuilder sb = new StringBuilder();
					bool ColonChecked = false;
					int nColonPos = 0;
					int nBrPos = 0;
					for(j= i; j<aText.Length; j++)
					{
						sb.Append(aText[j]);

						if(this.IsHandled(aText[j]))
						{
							continue;
						}

						//kamal
						//locate the position of a semicolon
						if(ColonChecked == false)
						{
							nColonPos = aText[j].IndexOf(";");
							nBrPos = aText[j].IndexOf("{");

							if(nBrPos>nColonPos)
							{
								//update the flag and don't come in this loop again
								ColonChecked = true;
							}
							else if(nColonPos > nBrPos)
							{
								//Get the value from here itself and break out of here
								nEnd = j;
								break;
							}
							else 
							{
								//nothing;
							}

							//make sure that we check this out
							if(aText[j].IndexOf("{") > 0)
								nStartBr++;

							if(aText[j].IndexOf("}") > 0)
								nEndBr++;

						}
						else
						{
							if(aText[j].IndexOf("{") > 0)
								nStartBr++;

							if(aText[j].IndexOf("}") > 0)
								nEndBr++;


							if(nStartBr !=0 && nEndBr !=0)
							{
								if(nStartBr-nEndBr == 0)
								{
									//we reached the end
									nEnd = j;
									break;
								}
							}
						}
					}

					//Pass the call to the appropriate manager to handle it
					//Cheat for now instead of using a delegate
					switch(cSearch.Trim())
					{
						case "class":
						{
							ClassBlockManager bm = new ClassBlockManager();
							cRetVal = bm.GetClassBlock(lcCurrent, sb.ToString());
							break;
						}
						case "struct":
						{
							StructureBlockManager sm = new StructureBlockManager();
							cRetVal = sm.GetBlock(lcCurrent, sb.ToString());
							break;
						}
						case "interface":
						{
							InterfaceBlockManager im = new InterfaceBlockManager();
							cRetVal = im.GetBlock(lcCurrent, sb.ToString());
							break;
						}
						case "namespace":
						{
							NameSpaceManager bm = new NameSpaceManager();
							cRetVal = bm.GetNameSpaceBlock(lcCurrent, sb.ToString());
							break;
						}
						case "foreach":
						{
							ForEachManager bm = new ForEachManager();
							cRetVal = bm.GetBlock(lcCurrent, sb.ToString());
							break;
						}
						case "do":
						{
							if(!ReplaceManager.IsNextCharValid(lcCurrent, "do"))
								continue;

							DoWhileManager bm = new DoWhileManager();
							cRetVal = bm.GetBlock(this, lcCurrent, sb.ToString());
							break;
						}
						case "while":
						{
							WhileManager bm = new WhileManager();
							cRetVal = bm.GetBlock(this, lcCurrent, sb.ToString());
							break;
						}
						case "switch":
						{
							SwitchManager sm = new SwitchManager();
							cRetVal = sm.GetBlock(lcCurrent, sb.ToString());
							break;
						}
						case "case":
						{
							CaseManager cm = new CaseManager();
							cRetVal = cm.GetBlock(lcCurrent, sb.ToString());
							break;
						}
						case "catch":
						{
							CatchManager cm = new CatchManager();
							cRetVal = cm.GetBlock(lcCurrent, sb.ToString());
							break;
						}
						case "enum":
						{
							EnumManager em = new EnumManager();
							cRetVal = em.GetBlock(lcCurrent, sb.ToString());
							break;
						}
						default:
							break;
					}

					//Update the string
					this.UpdateIfBlock(ref aText, cRetVal, i, nEnd);
				}
			}

			return this.Build(ref aText);
		}

		
		/// <summary>
		/// Designed for common tasks and returns the first available block of code
		/// Used heavily by try-case-finally, if-endif, switch-case
		/// </summary>
		/// <param name="aText"></param>
		/// <param name="nCurrent"></param>
		/// <param name="cSearchFor"></param>
		/// <param name="nFoundAt"></param>
		/// <returns></returns>
		private string GetBlock(ref string[] aText, ref int nCurrent, string cSearchFor, ref int nFoundAt, ref string tcNextStartWith)
		{
			StringBuilder sb = new StringBuilder();

			//scan further to check if there is a catch block
			for(int k=nCurrent; k<aText.Length; k++)
			{
				if(this.IsHandled(aText[k]))
				{
					continue;
				}

				int nStartBr = 0;
				int nEndBr = 0;
				int nColonPos = 0;
				int nBrPos = 0;
				bool ColonChecked = false;

				if(aText[k].Trim().StartsWith(cSearchFor))
				{
					nFoundAt = k;
					for(int l=k; l<aText.Length; l++)
					{
						sb.Append(aText[l] + "\r\n");

						//Removed this line because if a throw was on the same line it broke
						//if(this.IsHandled(aText[l]))
						if(aText[l].Trim().StartsWith("//") == true)
						{
							continue;
						}

						//locate the position of a semicolon
						if(ColonChecked == false)
						{
							nColonPos = aText[l].IndexOf(";");
							nBrPos = aText[l].IndexOf("{");

							if(nBrPos>nColonPos)
							{
								//update the flag and don't come in this loop again
								ColonChecked = true;
							}
							else if(nColonPos > nBrPos)
							{
								//Get the value from here itself and break out of here
								tcNextStartWith = ";";
								nCurrent = l;
								return sb.ToString();
							}
							else 
							{
								//nothing;
							}

						}


						if(aText[l].IndexOf("{") >= 0)
							nStartBr++;

						if(aText[l].IndexOf("}") >= 0)
							nEndBr++;

						if(nStartBr !=0 && nEndBr !=0)
						{
							if(nStartBr-nEndBr == 0)
							{
								nCurrent = l;
								tcNextStartWith = "}";
								return sb.ToString();
							}
						}
					}
					//
				}
			}
			return "";
		}


		/// <summary>
		/// Returns a bool indicating if a specified word is following another word.
		/// Used to determine patterns in code blocks
		/// </summary>
		/// <param name="tcSearchIn"></param>
		/// <param name="nStart"></param>
		/// <param name="tcAfter"></param>
		/// <param name="tcSearchFor"></param>
		/// <returns></returns>
		private bool IsImmediatelyAfter(ref string[] tcSearchIn, ref int nStart, string tcAfter, string tcSearchFor)
		{
			for(int i= nStart; i<tcSearchIn.Length; i++)
			{
				//Ignore blank and comment lines
				if(tcSearchIn[i].Trim().Length == 0)
					continue;


				//Locate the startpoint and if unless we find it continue
				if(tcSearchIn[i].Trim().StartsWith("//") == false)
				{
					//locate the position of the tcAfter string
					int nStartAfter = tcSearchIn[i].IndexOf(tcAfter);
					if(nStartAfter < 0)
						break;

					//Just in case the starting next search is on the same line
					if(tcSearchIn[i].IndexOf(tcSearchFor,nStartAfter) > 0)
					{
						nStart = i;
						return true;
					}

					for(int j= i+1; j < tcSearchIn.Length; j++)
					{
						//Ignore blank and comment lines
						if(tcSearchIn[j].Trim().Length == 0)
							continue;

						if(tcSearchIn[j].Trim().StartsWith(this.BlankLineToken) == true)
							continue;

						//Locate the startpoint and if unless we find it continue
						if(tcSearchIn[j].Trim().StartsWith("//") == false)
						{
							bool lFound = tcSearchIn[j].Trim().StartsWith(tcSearchFor);
							if(lFound == true)
								nStart = j;
							return lFound;
						}
					}

				}
			}

			return false;
		}

		
		/// <summary>
		/// Handles all the if blocks
		/// </summary>
		/// <param name="tcText"></param>
		/// <returns></returns>
		private string HandleIfBlock(string tcText)
		{
			string[] aText = tcText.Split('\r');
	
			int i;
			for(i = 0; i < aText.Length; i++)
			{
				string lcCurrent = aText[i];
				string cRetVal = "";

				if(this.IsHandled(lcCurrent))
					continue;


				//Check if the line does not have any brackets
				if(lcCurrent.Trim().StartsWith("if"))
				{
					string cIfBlock = "";
					ArrayList aElseBlock = new ArrayList();
					string cIfLine = "";
					int nStartPos = i;
					int nFoundAt = 0;
					int nCurrent = i;
					string cElseBlock = "";
					string cElseLine = "";
					string cNextStartWith = "";
					cIfBlock = this.GetBlock(ref aText, ref nCurrent, "if", ref nFoundAt, ref cNextStartWith);
					cIfLine = aText[nFoundAt];

					do 
					{
						if(this.IsImmediatelyAfter(ref aText, ref nCurrent, cNextStartWith, "else"))
						{
							cElseBlock = this.GetBlock(ref aText, ref nCurrent, "else", ref nFoundAt, ref cNextStartWith);
							cElseLine = aText[nFoundAt];
							ElseBlockToken o = new ElseBlockToken();
							o.ElseLine = cElseLine;
							o.ElseBlock = cElseBlock;
							aElseBlock.Add(o);
						}
						else
						{
							break;
						}
					}while(true);
			
					IfBlockManager tm = new IfBlockManager();
					cRetVal = tm.GetIfBlock(this, cIfBlock, cIfLine, aElseBlock);

					//Update the string
					this.UpdateIfBlock(ref aText, cRetVal, nStartPos, nCurrent);
				}
			}

			return this.Build(ref aText);
		}
		

		/// <summary>
		/// Handles ann try-catch-finally blocks
		/// </summary>
		/// <param name="tcText"></param>
		/// <returns></returns>
		private string HandleTryCatchFinally(string tcText)
		{
			string[] aText = tcText.Split('\r');
	
			//Loop through each line of the string and check if the string is a class
			int i;
			for(i = 0; i < aText.Length; i++)
			{
				//stop only when we encounter an a class
				string lcCurrent = aText[i];
				string cRetVal = "";

				if(this.IsHandled(lcCurrent))
					continue;


				//Check if the line does not have any brackets
				if(lcCurrent.Trim().StartsWith("try"))
				{
					string cTryBlock = "";
					string cFinallyBlock = "";
					string cCatchBlock = "";
					string cCatchLine = "";
					int nStartPos = i;
					int nFoundAt = 0;
					int nCurrent = i;
					string cNextStartWith = "";
					cTryBlock = this.GetBlock(ref aText, ref nCurrent, "try", ref nFoundAt, ref cNextStartWith);
			
					do
					{
						if(this.IsImmediatelyAfter(ref aText, ref nCurrent, cNextStartWith, "catch"))
						{
							cCatchBlock += this.GetBlock(ref aText, ref nCurrent, "catch", ref nFoundAt, ref cNextStartWith);
							cCatchLine = aText[nFoundAt];
						}
						else
						{
							break;
						}
					} while(true);

					if(this.IsImmediatelyAfter(ref aText, ref nCurrent, cNextStartWith, "finally"))
					{
						cFinallyBlock = this.GetBlock(ref aText, ref nCurrent, "finally", ref nFoundAt, ref cNextStartWith);
					}

			
					TryCatchFinallyManager tm = new TryCatchFinallyManager();
					//cRetVal = tm.GetBlock(cTryBlock, cCatchLine, cCatchBlock, cFinallyBlock);
					cRetVal = tm.GetBlock(cTryBlock, cCatchBlock, cFinallyBlock);

					//Update the string
					this.UpdateIfBlock(ref aText, cRetVal, nStartPos, nCurrent );
				}
			}

			return this.Build(ref aText);
		}

		
		/// <summary>
		/// Common method that is used by all the Handlers to update the block
		/// </summary>
		/// <param name="aDest"></param>
		/// <param name="cSource"></param>
		/// <param name="nCurrent"></param>
		/// <param name="nEnd"></param>
		private void UpdateIfBlock(ref string[] aDest, string cSource, int nCurrent, int nEnd)
		{
			//Change the contents of aText
			string[] aRetVal = cSource.Split('\n');

			for(int i=nCurrent; i <= nEnd; i++)
			{
				try
				{
					aDest[i] = "";
				}
				catch
				{
					// ignore since we are simply blanking the items. We WILL hit
					// this place if the source code has compilation problems due to
					// incorrect number of open and closed braces
				}
			}

			int r;
			int nCount = 0;
			for(r=0; r< aRetVal.Length; r++)
			{
				if(aRetVal[r].Trim().Length > 0)
				{
					//Check if we have hit the max limit
					if(nCount == (nEnd - nCurrent + 1))
					{
						//keep adding it on the same line
						aDest[nCurrent + nCount -1] = aDest[nCurrent + nCount -1] + "\n" + aRetVal[r];
					}
					else
					{
						aDest[nCurrent + nCount] = "\n" + aRetVal[r];
						nCount++;
					}
				}
			}
		}


		/// <summary>
		/// Returns a bool to the handlers specifing if the line is handled or not
		/// </summary>
		/// <param name="tcLine"></param>
		/// <returns></returns>
		private bool IsHandled(string tcLine)
		{
			//return false;
			bool lHandled = false;

			//If the line is empty ignore it
			if(tcLine.Trim().Length == 0)
			{
				lHandled = true;
			}

			//If the line is a comment then handle it
			if(tcLine.Trim().StartsWith("//"))
			{
				lHandled = true;
			}

			if(tcLine.Trim().StartsWith("using"))
				lHandled = true;

			if(tcLine.Trim().StartsWith("throw"))
				lHandled = true;

			//if(tcLine.Trim() == this.BlankLineToken)
			//	lHandled = true;

			return lHandled;

		}


		/// <summary>
		/// Handles when the appropriate declarations should be called
		/// </summary>
		/// <param name="tcText"></param>
		/// <returns></returns>
		private string HandleDeclaration(string tcText)
		{
			StringBuilder sb = new StringBuilder();
			string[] aText = tcText.Split('\n');
			bool llHandled;

			//Loop through each line of the string and check if the left of the string is a datatype
			for(int i = 0; i < aText.Length; i++)
			{
				llHandled = false;
				string lcCurrent = aText[i];


				//special condition if the line has a += then ignore conversion
				if((this.IsHandled(lcCurrent) == false) && lcCurrent.IndexOf("+=") < 0)
				{
					//Check if the line does not have any brackets
					if((lcCurrent.IndexOf(";") > 0) || lcCurrent.Trim().EndsWith("]") || ((lcCurrent.IndexOf("[") > 0) && (lcCurrent.Trim().EndsWith("="))))
					{
						//Fixed the converter so there is only one method
						if(llHandled == false)
						{
							string lcStr = lcCurrent.Trim();
							string lcStr1 = ReplaceManager.GetSingledSpacedString(lcStr);

							//handle array assignmenets
							if((lcStr1.IndexOf("new ") > 0) && (lcStr1.EndsWith("];")))
							{
								lcCurrent = lcCurrent.Replace(";", " {};");
								lcStr = lcCurrent;
							}

 


							int nPos = lcStr.IndexOf('=');

							//extract everything before an equals sign
							if(nPos > 0)
							{
								lcStr = lcStr.Substring(0, nPos).Trim();
							}

							//Split the string with a space
							//lcStr = lcStr.Replace("=", " = ");
							lcStr = ReplaceManager.GetSingledSpacedString(lcStr);

							//Remove the last semicolon and trim up the string
							if(lcStr.EndsWith(";"))
							{
								lcStr = lcStr.Substring(0, lcStr.Length-1).Trim();
							}

							//remove any modifiers from the string
							for(int q=0; q<ReplaceManager.Modifiers.Length; q++)
							{
								if(lcStr.StartsWith(ReplaceManager.Modifiers[q]))
								{
									lcStr = lcStr.Substring(ReplaceManager.Modifiers[q].Length + 1);
									q=0;
								}
							}

							lcStr = lcStr.Trim();

							string[] acheck = lcStr.Split(' ');
							if(acheck.Length == 2)
							{
								//we found a match
								llHandled = true;
								FieldManager fm = new FieldManager();
								lcCurrent = fm.GetConvertedExpression(lcCurrent);
							}
						}
					}
				}
				sb.Append(lcCurrent + "\n");
			}

			return sb.ToString();
		}
	}
}