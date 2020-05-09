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
	//For condition Manager class 
	//----------------------------------------------------------------------------------
	public class ForBlockManager : BaseManager
	{
		private string DeclarationToken = "";
		private string BeginConditionToken = "";
		private string EndConditionToken = "";
		private string IncrementToken = "";
		private string ForBlockToken = "";
		private string WhileBlockToken = "";
		private object oParent ;


		private string Execute()
		{
			string cRetVal = "";
			cRetVal += this.DeclarationToken;
			cRetVal += this.BlankToken + "For " + this.BeginConditionToken + " To " + this.EndConditionToken + this.IncrementToken + "\n";
			cRetVal += this.ForBlockToken;
			cRetVal += this.BlankToken + "Next";

			string lcText = cRetVal;
			lcText = lcText.Replace("\n", "<newline/>");
			lcText = lcText.Replace("\r", "<carriagereturn/>");

			return cRetVal;
		}

		public string GetForBlock(object toSender, string tcForCondition, string tcForBlock)
		{
			this.oParent = toSender;
			this.GetBlankToken(tcForBlock);
			this.ForBlockToken = this.GetCurrentBlock(tcForBlock);
			this.GetExpressions(tcForCondition);
			if(this.WhileBlockToken.Trim().Length == 0)
			{
				return this.Execute();
			}
			else
			{
				return this.WhileBlockToken;
			}
		}

		private void GetExpressions(string tcExp)
		{
			//Remove the extra items
			int npos = tcExp.IndexOf("(");
			string lcExp = tcExp.Substring(npos+1);
			npos = lcExp.LastIndexOf(")");
			lcExp = lcExp.Substring(0, npos).Trim();

			//split the string
			string[] aExp = lcExp.Split(';');
	
			//Build the expressions
			string cBegin = aExp[0];

			if(cBegin.Trim().Length == 0)
			{
				//in this case this is a while block and not a for block
				if(aExp[1].Trim() == "")
					aExp[1] = "true";
				string lcWhileLine = this.BlankToken  + "while(" + aExp[1] + ")";
				string lcWhileBlockToken = this.BlankToken  + "{\n" + this.ForBlockToken + "\n" + this.BlankToken + "	" + aExp[2] + "\n" + this.BlankToken  + "}";
				WhileManager wm = new WhileManager();
				this.WhileBlockToken = wm.GetBlock(this.oParent, lcWhileLine, lcWhileLine + lcWhileBlockToken);
				return;
			}

			cBegin = cBegin.Replace("=", " = ");
			cBegin = cBegin.Replace("  ", " ");
			string[] aBegin = cBegin.Split(null);
			if(aBegin[1].StartsWith("=") == false)
			{
				//Extract the declaration
				this.DeclarationToken = "\n" + this.BlankToken + "Dim " + aBegin[1] + " As " + aBegin[0] ;
				int nSpace = cBegin.IndexOf(" ");
				cBegin = cBegin.Substring(nSpace);
			}
			this.BeginConditionToken = cBegin;

			//Get the end condition token
			string lcEndCondition = aExp[1];
			npos = lcEndCondition.IndexOf(">");
			if(npos >0)
			{
				this.EndConditionToken = lcEndCondition.Substring(npos + 1);
			}
			else
			{
				npos = lcEndCondition.IndexOf("<");
				if(npos >0)
				{
					this.EndConditionToken = lcEndCondition.Substring(npos + 1);
				}
				else
				{
					this.EndConditionToken = lcEndCondition.Trim();
				}
			}


			//check if there is an equals sign in the condition
			if(lcEndCondition.IndexOf("=") == -1)
			{
				//add a -1 at the end
				this.EndConditionToken += "- 1 ";
			}

			this.EndConditionToken = this.EndConditionToken.Replace("=", "");
			this.EndConditionToken = this.EndConditionToken.Replace("!","");


			//Get the incrementer
			string lcIncrement = aExp[2];
			if(lcIncrement.IndexOf("++") > 0)
			{
				npos = lcIncrement.IndexOf("+");
				lcIncrement = " Step " + lcIncrement.Substring(0, npos) + " + 1";
			}
			else
			{
				if(lcIncrement.IndexOf("--") > 0)
				{
					npos = lcIncrement.IndexOf("-");
					lcIncrement = " Step " + lcIncrement.Substring(0, npos) + " - 1";
				}
				else
				{
					lcIncrement = " Step " + lcIncrement.Trim();
				}
			}
			this.IncrementToken = lcIncrement;

		}
	}
}
