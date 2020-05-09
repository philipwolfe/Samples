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
	//Enum Manager class 
	//----------------------------------------------------------------------------------
	public class EnumManager:BaseManager
	{
		private string EnumName = "";
		private string EnumReturnValue = "";
		private string EnumDeclarationToken = "";
		private string EnumBlock = "";
		
		public string GetBlock(string tcLine, string tcBlock)
		{
			this.GetBlankToken(tcLine);

			string cDeclaration = ReplaceManager.GetSingledSpacedString(tcLine);

			//Locate the colon in the enum and if so then the enum has a return type
			int npos = cDeclaration.LastIndexOf(":");
			if(npos > 0)
			{
				this.EnumReturnValue = "As " + cDeclaration.Substring(npos + 1).Trim();
				cDeclaration = cDeclaration.Substring(0, npos).Trim();
			}

			//handle the appropriate conversions
			cDeclaration = ReplaceManager.HandleTypes(cDeclaration);
			
			//The last word is the name of the enumeration
			npos = cDeclaration.IndexOf(" ");
			this.EnumName = cDeclaration.Substring(npos + 1);
			this.EnumDeclarationToken = cDeclaration.Substring(0, npos).Trim();

			//Replace any commas in the enum block with a next line + blank space
			this.EnumBlock = this.ExtractBlock(tcBlock, "{", "}").Replace(",", "\r\n" + this.BlankToken + "	");

			return this.Execute();
		}

		private string Execute()
		{
			string lcRetVal = "";
			lcRetVal = this.BlankToken + this.EnumDeclarationToken + " " + this.EnumName + " " + this.EnumReturnValue + "\n";
			lcRetVal += this.EnumBlock + "\n" ;
			lcRetVal += this.BlankToken + "End Enum\n" ;
			return lcRetVal;
		}
	}
}
