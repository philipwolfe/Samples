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
	//Interface Manager class 
	//----------------------------------------------------------------------------------
	public class InterfaceBlockManager: ClassBlockManager
	{
		public string GetBlock(string tcDeclaration, string tcBlock)
		{
			return this.GetClassBlock(tcDeclaration, tcBlock);
		}

		protected override string Execute()
		{
			string lcRetVal;
			lcRetVal = this.BlankToken + this.ClassDeclarationToken + this.ImplementationDeclationToken;
			lcRetVal += this.ClassBlockToken + "\r\n" + this.BlankToken + "End Interface" + "\r\n";
			return lcRetVal;
		}

	}
}
