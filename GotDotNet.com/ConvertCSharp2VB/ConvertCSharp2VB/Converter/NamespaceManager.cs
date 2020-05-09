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
	//Namespace Manager class 
	//----------------------------------------------------------------------------------
	public class NameSpaceManager: BaseManager
	{
		public string GetNameSpaceBlock(string tcNameSpace, string tcBlock)
		{
			this.GetBlankToken(tcNameSpace);
			string lcRetVal;
			lcRetVal = this.BlankToken + tcNameSpace.Trim().Replace("namespace", "Namespace") + "\r\n";
			lcRetVal += this.ExtractBlock(tcBlock, "{", "}") ;
			lcRetVal += "\r\n" + this.BlankToken + "End Namespace" + "\r\n";
			return lcRetVal;
		}
	}
}
