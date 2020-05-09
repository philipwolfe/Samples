/*----------------------------------------------------------------------
	Author:		Kamal Patel
	Date:		Feb 26 2002 AD
	Version:	1.2
	Copyright:	(c) Kamal Patel, All rights reserved.
	Email:		kppatel@yahoo.com
	URL:		http://www.KamalPatel.net
-----------------------------------------------------------------------*/

using System;
using System.Collections;
using System.Text;

namespace ConvertCSharp2VB
{
	//----------------------------------------------------------------------------------
	//New If condition Manager class to managing fields
	//----------------------------------------------------------------------------------
	public class IfBlockManager:BaseManager
	{
		private string IfExpressionToken = "";
		private string IfBlockToken = "";
		private ArrayList ElseBlocks = new ArrayList();
		private object oParent ;

		public string GetIfBlock(object toSender, string tcIfBlock, string tcIfLine, ArrayList taElseBlocks)
		{
			this.oParent = toSender;
			this.GetBlankToken(tcIfLine);

			//Check if the if is ending on the same line
			if(tcIfLine.TrimEnd().EndsWith(";"))
			{
				//Update the if block by extracting the block from the condition
				int npos = tcIfBlock.IndexOf("(");
				int nStartBr = 0;
				int nEndBr = 0;
				for(int i=npos; i< tcIfBlock.Length; i++)
				{
					if(tcIfBlock[i] == '(')
						nStartBr ++;

					if(tcIfBlock[i] == ')')
						nEndBr ++;

					if(nStartBr == nEndBr)
					{
						npos = i;
						tcIfLine = tcIfLine.Substring(0, npos+1);
						break;
					}


				}

				tcIfBlock = "{" + this.BlankToken + "	" + tcIfBlock.Substring(npos + 1) + "}";
			}

			this.IfExpressionToken = this.GetExpression(tcIfLine);

			this.IfBlockToken = this.GetBlock(tcIfBlock);
			this.HandleElseBlocks(taElseBlocks);

			return this.Execute();
		}

		private void HandleElseBlocks(ArrayList taElseBlocks)
		{
			foreach(ElseBlockToken o in taElseBlocks)
			{
				ElseBlockToken oElse = new ElseBlockToken();
				string cElseLine = this.GetExpression(o.ElseLine);
				oElse.ElseBlock = this.GetBlock(o.ElseBlock);

				if(cElseLine.Trim() == "else")
				{
					oElse.ElseLine = "";
				}
				else
				{
					oElse.ElseLine = cElseLine;
				}

				this.ElseBlocks.Add(oElse);
			}
		}

		private string GetBlock(string tcBlock)
		{
			if(tcBlock.IndexOf("{") >=0 && tcBlock.IndexOf("}") >=0)
			{
				return this.ExtractBlock(tcBlock, "{", "}");
			}
			else
			{
				//single line conditions
				string[] lcStr = tcBlock.Trim().Split('\r');
				StringBuilder sb = new StringBuilder();
				for(int i = 1; i < lcStr.Length; i++)
				{
					sb.Append(lcStr[i]);
				}

				return sb.ToString();
			}
		}

		private string GetExpression(string tcLine)
		{
			tcLine = ((ConvertCSharp2VB.CSharpToVBConverter)this.oParent).HandleCasting(tcLine);
			//lcStr = this.ExtractBlock(lcStr,"(", ")");
			//lcStr = ReplaceManager.GetSingledSpacedString(lcStr);
			//return ReplaceManager.HandleExpression(lcStr);

			return ReplaceManager.HandleExpression(this.ExtractBlock(tcLine, "(", ")"));
		}

		private string Execute()
		{
			string lcRetVal = "";
			lcRetVal = this.BlankToken + "If " + this.IfExpressionToken + " Then" + "\n";
			lcRetVal += this.IfBlockToken + "\n";

			foreach(ElseBlockToken o in this.ElseBlocks)
			{
				lcRetVal += this.BlankToken + "Else " ;
				if(o.ElseLine.Trim().Length > 0)
				{
					lcRetVal += "If " + o.ElseLine + " Then " + "\n" ;
				}
				else
				{
					lcRetVal += "\n";
				}

				lcRetVal += o.ElseBlock + "\n";
			}
			lcRetVal += this.BlankToken + "End If" + "\n";
			return lcRetVal;
		}
	}
}
