/*----------------------------------------------------------------------
	Author:		Kamal Patel
	Date:		Feb 26 2002 AD
	Version:	1.2
	Copyright:	(c) Kamal Patel, All rights reserved.
	Email:		kppatel@yahoo.com
	URL:		http://www.KamalPatel.net
-----------------------------------------------------------------------*/
using System;

namespace ConvertCSharp2VB
{
	//----------------------------------------------------------------------------------
	//ForEach Manager class 
	//----------------------------------------------------------------------------------
	public class ForEachManager:BaseManager
	{
		private string DeclarationToken = "";
		private string ConditionToken = "";
		private string ForEachBlockToken = "";

		public string GetBlock(string tcForEachCondition, string tcForEachBlock)
		{
			this.GetBlankToken(tcForEachCondition);
			this.GetCondition(tcForEachCondition);

			//Check if a semicolon comes before a { 
			//--Check if the foreach block ends with a semicolon
			//if(tcForEachBlock.TrimEnd().EndsWith(";"))
			int nLength = tcForEachCondition.Length;
			int nBrPos = tcForEachBlock.IndexOf("{", nLength);
			int nColonPos = tcForEachBlock.IndexOf(";", nLength);
			if((nColonPos < nBrPos) || ((nColonPos>0) && (nBrPos == -1)))
			{
				//int nStart = tcForEachBlock.LastIndexOf(")");
				//int nEnd = tcForEachBlock.LastIndexOf(";");
				this.ForEachBlockToken= tcForEachBlock.Substring(nLength + 1, (nColonPos - nLength));
			}
			else
			{
				this.ForEachBlockToken= this.ExtractBlock(tcForEachBlock, "{", "}");
			}

			return this.Execute();
		}

		private void GetCondition(string tcLine)
		{
			string lcStr = this.ExtractBlock(tcLine,"(", ")");
			lcStr = ReplaceManager.GetSingledSpacedString(lcStr);

			//We assume that there will not be any spaces in between quotes and parenthesis when GetSingledSpaceString
			string[] aStr = lcStr.Split(' ');
			if(aStr.Length > 3)
			{
				//The first word in this is a declaration of the second word
				//foreach(              String x in MyArrayList             )
				FieldManager fm = new FieldManager();
				this.DeclarationToken = this.BlankToken + fm.GetConvertedExpression(aStr[0] + " " + aStr[1] + ";") + "\n";
		
				//Build the ConditionToken
				int npos = lcStr.IndexOf(" ");
				this.ConditionToken = lcStr.Substring(npos).Trim();
			}
			else
			{
				this.ConditionToken = lcStr.Trim();
			}

			this.ConditionToken = this.ConditionToken.Replace(" in ", " In ");
		}

		private string Execute()
		{
			string cRetVal = "";
			cRetVal += this.DeclarationToken;
			cRetVal += this.BlankToken + "For Each " + this.ConditionToken + "\n";
			cRetVal += this.ForEachBlockToken;
			cRetVal += "\n" + this.BlankToken + "Next";

			return cRetVal;
		}
	}
}
