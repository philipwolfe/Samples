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
	//Try-Catch-Finally Manager class 
	//----------------------------------------------------------------------------------
	public class TryCatchFinallyManager: BaseManager
	{
		private string TryBlockToken = "";
		private string CatchBlockToken = "";
		private string FinallyBlockToken = "";
		private string CatchToken = "";

		public string GetBlock(string tcTryBlock, string tcCatchBlock, string tcFinallyBlock)
		{
			this.GetBlankToken(tcTryBlock);

			//remove the try from the start of the block
			if(tcTryBlock.Trim().StartsWith("try"))
			{
				int npos = tcTryBlock.IndexOf("try");
				tcTryBlock = tcTryBlock.Substring(npos + "try".Length);
			}
			this.TryBlockToken = this.GetCurrentBlock(tcTryBlock);
			if(this.TryBlockToken.Length > 0)
				this.TryBlockToken = "Try" + "\r\n" + this.TryBlockToken;

			this.CatchBlockToken = tcCatchBlock;

			//remove the finally from the start of the block
			if(tcFinallyBlock.Trim().StartsWith("finally"))
			{
				int npos = tcFinallyBlock.IndexOf("finally");
				tcFinallyBlock = tcFinallyBlock.Substring(npos + "finally".Length);
			}

			this.FinallyBlockToken = this.GetCurrentBlock(tcFinallyBlock);
			if(this.FinallyBlockToken.Trim().Length > 0)
				this.FinallyBlockToken = "Finally" + "\r\n" + this.FinallyBlockToken;

			return this.Build();
		}

		private void GetCatchToken(string tcCatchToken)
		{
			string sCatchToken = ReplaceManager.GetSingledSpacedString(tcCatchToken).Trim();
			int npos = sCatchToken.IndexOf(" ");

			if(npos > 0)
			{
				FieldManager fm = new FieldManager();
				this.CatchToken = "Catch " + fm.GetConvertedExpression(sCatchToken.Substring(npos) + ";");
			}
			else
			{
				this.CatchToken = "Catch";
			}
		}

		private string Build()
		{
			string cRetVal = this.BlankToken + this.TryBlockToken;

			if(this.CatchBlockToken.Length > 0)
				cRetVal += "\r\n" + this.BlankToken + this.CatchBlockToken ;

			if(this.FinallyBlockToken.Length > 0)
				cRetVal += "\r\n" + this.BlankToken + this.FinallyBlockToken ;

			cRetVal += "\r\n" + this.BlankToken + "End Try";
			return cRetVal ;
		}

	}
}
