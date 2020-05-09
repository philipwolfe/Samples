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
	//Switch-case Manager class 
	//----------------------------------------------------------------------------------
	public class SwitchManager:BaseManager
	{
		private string SwitchExpressionToken = "";
		private string SwitchBlock = "";
		
		public string GetBlock(string tcSwitchLine, string tcSwitchBlock)
		{
			this.GetBlankToken(tcSwitchLine);
			this.SwitchExpressionToken = this.ExtractBlock(tcSwitchLine, "(", ")");

			//Pass the switchblock as is back 
			this.SwitchBlock = this.ExtractBlock(tcSwitchBlock, "{", "}").Replace("default", "case Else");

			return this.Execute();
		}

		private string Execute()
		{
			string lcRetVal = "";
			lcRetVal = this.BlankToken + "Select Case " + this.SwitchExpressionToken + "\n";
			lcRetVal += this.SwitchBlock + "\n";
			lcRetVal += this.BlankToken + "End Select" + "\n";
			return lcRetVal;
		}
	}
}
