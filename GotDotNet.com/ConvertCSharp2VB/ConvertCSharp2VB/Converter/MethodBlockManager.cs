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
	//----------------------------------------------------------------------------------
	//Method Manager class 
	//----------------------------------------------------------------------------------
	public class MethodBlockManager: BaseManager
	{
		private string MethodBlockToken = "";
		private string MethodModifiersToken = "";
		private string MethodNameToken = "";
		private string ParameterToken = "";
		private string MethodType = "Function";
		private string ReturnValueToken = "";
		private string MethodParentToken = "";

		public string GetMethodBlock(string tcMethodLine, string tcMethodBlock)
		{
			if(this.ValidateBlock(tcMethodBlock)== false)
			{
				//return without doing anything
				return tcMethodBlock;
			}

			this.GetBlankToken(tcMethodLine);
			this.BuildMethodDeclaration(tcMethodLine);

			this.MethodBlockToken = this.ExtractBlock(tcMethodBlock, "{", "}");
			return this.Execute();
		}

		private bool ValidateBlock(string tcMethodBlock)
		{
			//Rule 1: if a >> is before a ; or { then it is an attribute
			//Rule 2: The first trimmed character of the block has to be a {
			// Only support block methods for now
			int nSignPos = tcMethodBlock.IndexOf(">>");
			if(nSignPos > 0)
			{
				int nBrPos = tcMethodBlock.IndexOf("{");
				if(nBrPos > nSignPos)
					return false;

				int nColonPos = tcMethodBlock.IndexOf(";");
				if(nColonPos > nSignPos)
					return false;
			}

			return tcMethodBlock.Trim().EndsWith("}") ;
		}
		private void BuildMethodDeclaration(string tcLine)
		{
			//Locate the position of a colon and if we find it then break the method line and parent
			int nColon = tcLine.IndexOf(":");
			if(nColon > 0)
			{
				this.MethodParentToken = tcLine.Substring(nColon + 1);
				tcLine = tcLine.Substring(0, nColon);

				//fix the MethodParentToken first [COMMENTED FOR NOW. NOT SURE IF REQUIRED]
				//string lcParameters = this.GetParameters(this.MethodParentToken);
				//int nEndPos = this.MethodParentToken.IndexOf("(");
				//this.MethodParentToken = this.MethodParentToken.Substring(0, nEndPos) + lcParameters;
			}


			//Break the method call into two parts
			// 1. Method definition
			// 2. Parameters passed

			// Let us get the parameters
			tcLine = ReplaceManager.GetSingledSpacedString(tcLine).Trim();
			int nOpenParen = 0;
			int nClosedParen = 0;
			string cParameters = "";
			string cDefinition = tcLine;
			int k;

			for(int i=tcLine.Length; 0<i; i--)
			{
				k = i - 1;
				if(tcLine[k] == ')')
					nClosedParen++;

				if(tcLine[k] == '(')
					nOpenParen++;
		
				if(nOpenParen !=0 && nClosedParen !=0)
				{
					if(nOpenParen - nClosedParen == 0)
					{
						//Create the two seperate strings and exit out
						cDefinition = tcLine.Substring(0, k);
						cParameters = tcLine.Substring(k).Trim();
						break;
					}
				}
			}

			this.ParameterToken = this.GetParameters(cParameters);

			//split the definition and if the length is two then add a private modifier as default
			cDefinition = ReplaceManager.GetSingledSpacedString(cDefinition); //safety purposes

			//Check for any modifiers in this string and if so then handle them


			string[] cTemp = cDefinition.Split(' ');
			if(cTemp.Length == 2)
			{
				//add a private modifier
				cDefinition = "private " + cDefinition;
			}


			//If we find a void in the definition part it is a Sub else a Function
			//In VB Sub do not return a value and Functions do return a value
			if(cDefinition.IndexOf("void ") >= 0)
			{
				this.MethodType = "Sub";
			}

			cDefinition = " " + cDefinition.Trim() + " ";
			cDefinition = ReplaceManager.HandleModifiers(cDefinition);

			//The last word will always be the name of the method
			cDefinition = cDefinition.Trim();
			int npos = cDefinition.LastIndexOf(" ");
			this.MethodNameToken = cDefinition.Substring(npos).Trim();
			cDefinition = cDefinition.Substring(0, npos);

			//In this case the second last value will be the return value datatype of the method
			if(this.MethodType != "Sub")
			{
				npos = cDefinition.LastIndexOf(" ");
				if(npos >=0)
				{
					this.ReturnValueToken = " As " + cDefinition.Substring(npos).Trim();
					cDefinition = cDefinition.Substring(0, npos);
				}
			}
	
			//if(cDefinition.Length > 0)
			if(npos > 0)
			{
				this.MethodModifiersToken = cDefinition.Substring(0, npos) + " " ;
			}
		}

		private string GetParameters(string tcString)
		{
			string cParameters;
			//Remove the paramthesis from the parameters
			cParameters = this.ExtractBlock(tcString, "(", ")");
			string lcRetVal = "()";
			if(cParameters.Length > 0)
			{
				//split the string on commas
				string[] aParams = cParameters.Split(',');
				FieldManager fm = new FieldManager();
				StringBuilder sParams = new StringBuilder();
				string cParam = "";
				string cTypeCast = "";
				for(int j = 0; j<aParams.Length; j++)
				{
					cParam = aParams[j].Trim();
					if((cParam.IndexOf("ref ")>= 0) || (cParam.IndexOf("out ")>= 0))
					{
						cTypeCast = "ByRef";
						cParam = cParam.Replace("ref ", "");
						cParam = cParam.Replace("out ", "");
					}
					else
					{
						cTypeCast = "ByVal";
					}

					if(j>0){sParams.Append(", ");}

					cParam = fm.GetConvertedExpression(cParam + ";").Trim();
					cParam = cTypeCast + cParam.Replace("Dim", "");
					sParams.Append(cParam);
				}
				lcRetVal = "(" + sParams.ToString() + ")" ;
			}
			return lcRetVal;
		}

		private string Execute()
		{
			string lcRetVal;
			lcRetVal = this.BlankToken + this.MethodModifiersToken + this.MethodType + " " + this.MethodNameToken + this.ParameterToken + this.ReturnValueToken;
			if(this.MethodParentToken.Length > 0)
				lcRetVal += " : " + this.MethodParentToken;

			lcRetVal += this.MethodBlockToken + "\r\n" + this.BlankToken + "End " + this.MethodType + "\r\n";
			return lcRetVal;
		}

	}
}
