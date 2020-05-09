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
	//Case Manager class 
	//----------------------------------------------------------------------------------
	public class CaseManager:BaseManager
	{
		private string CaseExpressionToken = "";
		private string CaseBlock = "";
		
		public string GetBlock(string tcCaseLine, string tcCaseBlock)
		{
			this.GetBlankToken(tcCaseLine);
			this.CaseExpressionToken = ReplaceManager.HandleExpression(this.ExtractBlock(tcCaseLine, "case", ":"));

			//Check if the block does not complete in a single line
			if(tcCaseBlock.IndexOf("{") >=0)
			{
				this.CaseBlock = this.ExtractBlock(tcCaseBlock, "{", "}");
			}
			else
			{
				this.CaseBlock = this.ExtractBlock(tcCaseBlock, ":", ";");
			}

			return this.Execute();
		}

		private string Execute()
		{
			string lcRetVal = "";
			lcRetVal = this.BlankToken + "Case " + this.CaseExpressionToken + "\n";
			lcRetVal += this.CaseBlock + "\n";
			return lcRetVal;
		}

	}
}
