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
	//Do-While Manager class 
	//----------------------------------------------------------------------------------
	public class DoWhileManager:BaseManager
	{
		private string ExpresionToken = "";
		private string DoWhileBlockToken = "";
		private object oParent;

		public string GetBlock(object toSender, string tcDoWhileCondition, string tcDoWhileBlock)
		{
			this.oParent = toSender;

			this.GetBlankToken(tcDoWhileCondition);
			string cCondition  = "";

			//The condition we get here is for the first line, we need to ignore this and pick one up from the last line
			if(tcDoWhileBlock.LastIndexOf("{") == -1)
			{
				//remove the try from the start of the block
				int npos = tcDoWhileBlock.IndexOf("do");
				tcDoWhileBlock = tcDoWhileBlock.Substring(npos + "do".Length);
				this.GetCondition(tcDoWhileBlock);
			}
			else
			{
				int nStart = tcDoWhileBlock.LastIndexOf("}");
				int nEnd = tcDoWhileBlock.LastIndexOf(";");

				cCondition = tcDoWhileBlock.Substring(nStart + 1, nEnd -nStart-1);
				this.GetCondition(cCondition);
				this.DoWhileBlockToken = this.ExtractBlock(tcDoWhileBlock, "{", "}");
			}


			return this.Execute();
		}

		private void GetCondition(string tcLine)
		{
			tcLine = ((ConvertCSharp2VB.CSharpToVBConverter)this.oParent).HandleCasting(tcLine);
			string lcStr = this.ExtractBlock(tcLine,"(", ")");
			lcStr = ReplaceManager.GetSingledSpacedString(lcStr);

			this.ExpresionToken = ReplaceManager.HandleExpression(lcStr);
		}

		private string Execute()
		{
			string cRetVal = "";
			cRetVal += this.BlankToken + "Do " + "\n";
			cRetVal += this.DoWhileBlockToken;
			cRetVal += "\n" + this.BlankToken + "Loop While " + this.ExpresionToken ;

			return cRetVal;
		}
	}
}
