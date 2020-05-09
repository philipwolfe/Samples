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
	//Catch Manager class 
	//----------------------------------------------------------------------------------
	public class CatchManager: BaseManager
	{
		private string CatchBlockToken = "";
		private string CatchToken = "";
		
		public string GetBlock(string tcCatchLine, string tcCatchBlock)
		{
			this.GetBlankToken(tcCatchLine);
			this.GetCatchToken(tcCatchLine);

			// the catch might not defined in brackets so extract the catch line from it
			tcCatchBlock = tcCatchBlock.Substring(tcCatchLine.Length);
			this.CatchBlockToken = this.GetCurrentBlock(tcCatchBlock);
			if(this.CatchBlockToken.Length > 0)
				this.CatchBlockToken = this.CatchToken + "\r\n" + this.CatchBlockToken;

			return this.Execute();
		}

		private void GetCatchToken(string tcCatchToken)
		{
			string sCatchToken = this.ExtractBlock(ReplaceManager.GetSingledSpacedString(tcCatchToken).Trim(), "(", ")").Trim();
			int npos = sCatchToken.IndexOf(" ");

			if(npos > 0)
			{
				FieldManager fm = new FieldManager();
				this.CatchToken = fm.GetConvertedExpression(sCatchToken + ";").Replace("Dim ", "Catch ");
			}
			else
			{
				this.CatchToken = "Catch";
			}
		}

		private string Execute()
		{
			string lcRetVal = "";
			if(this.CatchBlockToken.Length > 0)
				lcRetVal += "\r\n" + this.BlankToken + this.CatchBlockToken ;
			return lcRetVal;
		}

	}
}
