/*----------------------------------------------------------------------
	Author:		Kamal Patel
	Date:		Feb 26 2002 AD
	Version:	1.2
	Copyright:	(c) Kamal Patel, All rights reserved.
	Email:		kppatel@yahoo.com
	URL:		http://www.KamalPatel.net
-----------------------------------------------------------------------*/
using System;
using System.Text;
using System.Collections;

namespace ConvertCSharp2VB
{
	//----------------------------------------------------------------------------------
	//Field Manager class to managing fields
	//----------------------------------------------------------------------------------
	public class FieldManager:BaseManager
	{
		private string ModifierToken = "";
		private string VariableToken = "";
		private string AssignmentToken = "";
		private string DataTypeToken = "";
		private ArrayList Stack = new ArrayList();
		private int StackCount = -1;
		private ArrayList CommaSeperatedDeclarations = new ArrayList();
		private System.Collections.Queue ModifersQueue = new System.Collections.Queue();

		protected string CheckTokens(string tcLine, char tcStart, char tcEnd)
		{
			for(int i=0; i< tcLine.Length; i++)
			{
				if(tcLine[i] == tcStart)
				{
					int nPrStart = 1;
					int nPrEnd = 0;
					
					//we have a starting point so we go ahead and loop until we find the appropriate ending point
					for(int j=i+1; j<tcLine.Length; j++)
					{
						if(tcLine[j] == tcStart) nPrStart++;
						if(tcLine[j] == tcEnd) nPrEnd++;

						if(nPrStart != 0 && nPrEnd != 0 && nPrStart-nPrEnd == 0)
						{

							//at this point we found our block of start and end points
							//Get a new token for the block and update the block
							MappingToken m = new MappingToken();
							
							// Get the new token 
							this.StackCount = this.StackCount + 1;

							m.cOriginal = tcLine.Substring(i, j-i + 1);
							m.cToken =  tcStart.ToString() + "__" + this.StackCount.ToString() + "__" + tcEnd.ToString();

							this.Stack.Add(m);

							//update tcLine
							tcLine = tcLine.Substring(0, i) + m.cToken + tcLine.Substring(j+1);
							break;
						}
					}

				}
			}

			return tcLine;
		}

		private string PopTokens(string tcText)
		{
			if(this.StackCount == -1)
				return tcText;

			//Since it is a line we can afford to loop through the arraylost and do replace
			foreach(MappingToken o in this.Stack)
			{
				tcText = tcText.Replace(o.cToken, o.cOriginal);
			}

			return tcText;
		}

		private void ExtractModifiers(ref string tcLine)
		{
			tcLine = tcLine.Trim();
			//Check if the line begins with any of the variable modifiers
			for (int j =0; j< ReplaceManager.Modifiers.Length; j++)
			{
				if(tcLine.StartsWith(ReplaceManager.Modifiers[j]))
				{
					this.ModifersQueue.Enqueue(ReplaceManager.Modifiers[j]);
					tcLine = tcLine.Substring(ReplaceManager.Modifiers[j].Length + 1);
					j = 0; //reset the search
				}
			}

			this.UpdateModifierToken();
		}

		private void UpdateModifierToken()
		{
			IEnumerator ie = this.ModifersQueue.GetEnumerator();
			while(ie.MoveNext())
			{
				this.ModifierToken += ReplaceManager.HandleModifiers(((string)ie.Current) + " ");
			}
		}

		public string GetConvertedExpression(string tcLine)
		{
			this.GetBlankToken(tcLine);

			this.ExtractModifiers(ref tcLine);

			//Leave the spaces in the front but fix the line
			tcLine = this.BlankToken + ReplaceManager.GetSingledSpacedString(tcLine);
			tcLine = tcLine.Replace("==", "=");
			tcLine = tcLine.Replace("=", " = ");

			//Add the appropriate token to the parenthesis in this string
			tcLine = this.CheckTokens(tcLine, '(', ')');
			tcLine = this.CheckTokens(tcLine, '[', ']');


			if(this.valid(tcLine) == true)
			{
				return this.PopTokens(tcLine);
			}

			//If there is no spaces in the expression return as is
			if(tcLine.Trim().IndexOf(' ') < 0)
				return this.PopTokens(tcLine);


			if(this.ModifierToken.Trim().Length == 0)
			{
				this.ModifierToken = "Dim ";
			}

			this.GetDataType(tcLine);
			return this.PopTokens(this.Build());
		}

		private bool valid(string tcLine)
		{
			bool lValid = false;

			//If the line is a return statement then handle it
			if(tcLine.Trim().StartsWith("return"))
			{
				lValid = true;
			}

			if(tcLine.Trim().ToLower().StartsWith("while"))
			{
				lValid = true;
			}

			if(tcLine.Trim().ToLower().StartsWith("do"))
			{
				lValid = ReplaceManager.IsNextCharValid(tcLine, "do");
			}

			if(tcLine.Trim().ToLower().StartsWith("loop"))
			{
				lValid = true;
			}

			return lValid;
		}

		private void GetDataType(string tcLine)
		{
			string lcLine = tcLine.Trim();
			//locate the first space
			int npos = lcLine.IndexOf(' ');
			this.DataTypeToken = lcLine.Substring(0, npos);

			//TODO: Add code here to add the comma seperated items into the new stack
			int nComma = lcLine.IndexOf(",");
			if(nComma >=0)
			{
				//Handle the primary first
				lcLine = lcLine.Substring(0, nComma);

				string[] aStr = tcLine.Split(',');
				for(int i =1; i< aStr.Length; i++) //skip the first one
				{
					this.CommaSeperatedDeclarations.Add(this.BlankToken + this.DataTypeToken + " " + aStr[i].Trim());
				}
			}

			//Get the variable part now
			int npos1 = lcLine.IndexOf(' ', npos+1);
			if(npos1 < 0)
			{
				//this is a simple declaration without an expression
				lcLine = lcLine.Replace(';', ' ');
				this.VariableToken = lcLine.Substring(npos + 1).Trim();
			}
			else
			{
				this.VariableToken = lcLine.Substring(npos + 1, npos1 - npos - 1);
				this.GetExpressionToken(lcLine);
			}

		}


		private void GetExpressionToken(string tcLine)
		{

			//Check if there is an assignment
			int nPos = tcLine.IndexOf('=');
			if(nPos > 0)
			{
				this.AssignmentToken = " " + tcLine.Substring(nPos).Trim();
			}
			else
			{
				this.AssignmentToken = "";
			}

			//check if it is an array 
			if(this.DataTypeToken.IndexOf('[') > 0)
			{
				//In this case check if we need to add an extra parenthesis around the declaration
				int npos = tcLine.IndexOf(";");
				if(npos == -1)
				{
					// add an underscore
					this.AssignmentToken += " _ 'CSharp2VBArray";
				}
			}

			//Remove semicolons
			this.AssignmentToken = this.AssignmentToken.Replace(';', ' ');
		}

		private string Build()
		{
			//check if the datatype token is an array
			int npos = this.DataTypeToken.IndexOf('[');
			if(npos > 0)
			{
				this.VariableToken = this.VariableToken + this.DataTypeToken.Substring(npos);
				this.DataTypeToken = this.DataTypeToken.Substring(0, npos);
			}
			//Leave the semi colun purposefully so the property handler does not pick it up
			string lcRetVal= "";
			lcRetVal += this.BlankToken + this.ModifierToken ;
			lcRetVal += this.VariableToken + " As " + this.DataTypeToken + this.AssignmentToken + ";";

			foreach(string s in this.CommaSeperatedDeclarations)
			{
				FieldManager fm = new FieldManager();
				fm.ModifierToken = "," ;
				lcRetVal = lcRetVal + fm.GetConvertedExpression(s).Trim();
			}
			return lcRetVal;
		}

	}
}
