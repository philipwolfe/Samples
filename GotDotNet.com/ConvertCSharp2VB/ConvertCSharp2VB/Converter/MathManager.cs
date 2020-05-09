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
	//++ and -- Manager class 
	//----------------------------------------------------------------------------------
	public class MathManager:BaseManager
	{
		private string ExpressionBlock = "";
		private string VariableBlock = "";
		private string DeclarationBlock = "";
		private string PaddingBlock = "";

		private void Initialize()
		{
			this.ExpressionBlock = "";
			this.VariableBlock = "";
			this.DeclarationBlock = "";
			this.PaddingBlock = "";
		}

		public string GetBlock(string tcLine)
		{
			// Initialize the properties
			this.Initialize();

			this.GetBlankToken(tcLine);

			//Check if the operation is ++ or --
			int npos;
			tcLine = ReplaceManager.GetSingledSpacedString(tcLine);

			// Check for an equal sign in the variable block and if so, then this is the declaration
			int nEqualsPosition = tcLine.IndexOf("=");
			if(nEqualsPosition > 0)
			{
				// Capture the declaration
				string lcDeclaration = tcLine.Substring(0, nEqualsPosition);
				
				// Fix the declaration by passing it to the appropriate handler
				FieldManager fm = new FieldManager();
				this.DeclarationBlock = fm.GetConvertedExpression(lcDeclaration).Replace(";", "") + " = " ;

				tcLine = tcLine.Substring(nEqualsPosition + 1).Trim();
			}
			
			// Verify that the expression has atleast a ++ or --
			npos = tcLine.IndexOf("++");
			if(npos < 0 )
			{
				npos = tcLine.IndexOf("--");
				if(npos < 0)
				{
					return tcLine;
				}
				else
				{
					this.ExpressionBlock = "- 1";
				}
			}
			else
			{
				this.ExpressionBlock = "+ 1";
			}

			//best case scenario
			//Determine the expression part and update the variable block
			if(npos != 0)
			{
				//between this and the previous whitespace
				this.VariableBlock = tcLine.Substring(0, npos);
			}
			else
			{
				// Begin by removing the semicolon
				tcLine = tcLine.Replace(";", "").Trim();
			
				// Check if there is extra space at the end left
				int nBlankPos = tcLine.IndexOf(" ");
				if(nBlankPos > 0)
				{
					// Extract all the padding and store it seperately
					this.PaddingBlock = tcLine.Substring(nBlankPos);
					tcLine = tcLine.Substring(0, nBlankPos);
				}
				this.VariableBlock = tcLine.Replace("++", "").Replace("--", "").Trim();

			}

			// Update the declaration
			if(this.DeclarationBlock.Length == 0)
			{
				this.DeclarationBlock = this.VariableBlock + " = ";
			}

			return this.Execute();
		}

		private string Execute()
		{
			string lcRetVal;
			lcRetVal = this.BlankToken + this.DeclarationBlock.Trim() + " " + this.VariableBlock.Trim() + " " + this.ExpressionBlock + this.PaddingBlock + "\r";

			return lcRetVal;
		}
	}
}
