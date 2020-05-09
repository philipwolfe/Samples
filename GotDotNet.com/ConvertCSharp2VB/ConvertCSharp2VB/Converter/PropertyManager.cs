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
	//Property Manager class 
	//----------------------------------------------------------------------------------
	public class PropertyManager: BaseManager
	{
		private string ReturnValueToken = "";
		private string PropertyModifiersToken = "";
		private string PropertyNameToken = "";
		private string GetBlockToken = "";
		private string SetBlockToken = "";
		private string PropertyParameterToken = "() ";

		public string GetBlock(string tcLine, string tcBlock)
		{
			this.GetBlankToken(tcLine);
			this.BuildPropertyDeclaration(tcLine);

			StringBuilder GetSb = new StringBuilder();
			StringBuilder SetSb = new StringBuilder();
			//check if get exists
			//extract the get block
			string[] aText = tcBlock.Split('\r');
			for(int i=0; i< aText.Length; i++)
			{
				string lcStr = aText[i].Trim();

				//Handle the get block creation
				if(lcStr.StartsWith("get"))
				{
					int nStartBr = 0;
					int nEndBr = 0;
					for(int j=i+1; j< aText.Length; j++)
					{
						GetSb.Append(aText[j] + "\n");

						if(aText[j].Trim().StartsWith("{"))
							nStartBr++;

						if(aText[j].Trim().StartsWith("}"))
							nEndBr++;

						if(nStartBr != 0 && nEndBr != 0 && nStartBr-nEndBr == 0)
						{
							//we are done at this point
							break;
						}
					}
					break;
				}
			}

			for(int i=0; i< aText.Length; i++)
			{
				string lcStr = aText[i].Trim();

				//Handle the get block creation
				if(lcStr.StartsWith("set"))
				{
					int nStartBr = 0;
					int nEndBr = 0;
					for(int j=i+1; j< aText.Length; j++)
					{
						SetSb.Append(aText[j] + "\n");

						if(aText[j].Trim().StartsWith("{"))
							nStartBr++;

						if(aText[j].Trim().StartsWith("}"))
							nEndBr++;

						if(nStartBr != 0 && nEndBr != 0 && nStartBr-nEndBr == 0)
						{
							//we are done at this point
							break;
						}
					}
					break;
				}

			}


			this.GetBlockToken = this.ExtractBlock(GetSb.ToString(), "{", "}");
			this.SetBlockToken = this.ExtractBlock(SetSb.ToString(), "{", "}");
			return this.Execute();
		}

		private void BuildPropertyDeclaration(string tcLine)
		{
			// the last word in this line is the name of the property
			tcLine = ReplaceManager.GetSingledSpacedString(tcLine).Trim();

			if(tcLine.EndsWith(")"))
			{
				int nEnd = tcLine.IndexOf("(");
				this.PropertyParameterToken = this.ExtractBlock(tcLine, "(", ")");
				FieldManager fm = new FieldManager();
				this.PropertyParameterToken = "(" + fm.GetConvertedExpression(this.PropertyParameterToken) + ") ";
				this.PropertyParameterToken = this.PropertyParameterToken.Replace("Dim ", "");
				tcLine = tcLine.Substring(0, nEnd).Trim();
			}

			int npos = tcLine.LastIndexOf(" ");
			this.PropertyNameToken = tcLine.Substring(npos + 1);
			string cDefinition = tcLine.Substring(0, npos).Trim();

			cDefinition = ReplaceManager.HandleModifiers(cDefinition);

			//A property has to return a value
			cDefinition = cDefinition.Trim();
			npos = cDefinition.LastIndexOf(" ");
			this.ReturnValueToken = "As " + cDefinition.Substring(npos).Trim();
			cDefinition = cDefinition.Substring(0, npos);

			this.PropertyModifiersToken = cDefinition;
		}

		private string Execute()
		{
			string lcRetVal;

			// Check if we have to update the PropertyModifiersToken for ReadOnly or WriteOnly
			if((this.GetBlockToken.Trim().Length > 0) && (this.SetBlockToken.Trim().Length == 0))
			{
				this.PropertyModifiersToken += " ReadOnly";
			}
			else if((this.SetBlockToken.Trim().Length > 0) && (this.GetBlockToken.Trim().Length == 0))
			{
				this.PropertyModifiersToken += " WriteOnly";
			}

			// Create the starting point for the property declaration
			lcRetVal = this.BlankToken + this.PropertyModifiersToken + " Property " + this.PropertyNameToken + this.PropertyParameterToken + this.ReturnValueToken + "\n";
			
			// Add the get block if it exists
			if(this.GetBlockToken.Trim().Length > 0)
			{
				lcRetVal += this.BlankToken + "	" + "Get " + "\n" + this.GetBlockToken + "\n" + this.BlankToken + "	End Get" + "\n";
			}

			// Add the set block if it exists
			if(this.SetBlockToken.Trim().Length > 0)
			{
				lcRetVal += this.BlankToken + "	" + "Set " + "(ByVal Value " + this.ReturnValueToken + ") \n" + this.SetBlockToken + "\n" + this.BlankToken + "	End Set" + "\n";
			}

			// Complete the declaration and return the updated property
			lcRetVal += this.BlankToken + "End Property" + "\n";
			return lcRetVal;
		}

	}
}
