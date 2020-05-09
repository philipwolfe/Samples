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

namespace ConvertCSharp2VB
{
	//----------------------------------------------------------------------------------
	//Class Manager class 
	//----------------------------------------------------------------------------------
	public class ClassBlockManager: BaseManager
	{
		protected string ClassBlockToken = "";
		protected string ClassDeclarationToken = "";
		protected string ImplementationDeclationToken = "";
		protected string ClassNameToken = "";

		public string GetClassBlock(string tcClassDeclaration, string tcClassBlock)
		{
			this.GetBlankToken(tcClassDeclaration);
			this.BuildClassDeclaration(tcClassDeclaration);

			this.ClassBlockToken = this.ExtractBlock(tcClassBlock, "{", "}");

			// A class block can have constructors and we need to handle them
			this.HandleConstructors();

			return this.Execute();
		}

		private void HandleConstructors()
		{
			//this.ClassBlockToken = this.ClassBlockToken.Replace(this.ClassNameToken, " void New");
			// Loop through each line in the class block and determine if a constructor exists
			string[] aLines = this.ClassBlockToken.Split('\n');
			StringBuilder sb = new StringBuilder();
			for(int i=0; i< aLines.Length; i++)
			{
				if((aLines[i].Trim().EndsWith(")")) && (aLines[i].IndexOf(this.ClassNameToken) >= 0))
				{
					//A candidate to check for the class name
					//Make sure that it not a destructor
					if(aLines[i].IndexOf("~") >=0)
					{
						aLines[i] = aLines[i].Replace(this.ClassNameToken, " void Finalize");
						aLines[i] = aLines[i].Replace("~", "");

					}
					else
					{
						aLines[i] = aLines[i].Replace(this.ClassNameToken, " void New");
					}

					int nColon = aLines[i].IndexOf(":");
					if(nColon > 0)
					{
						aLines[i] = aLines[i].Substring(0, nColon) + aLines[i].Substring(nColon).Replace("base", "MyBase.New");
					}
				}
				else
				{
					//check if it is not an indexer
					if(aLines[i].TrimEnd().EndsWith("]") && (aLines[i].IndexOf(" this") >=0))
					{
						//we have found an indexer
						//1. Replace the this with "Item"
						aLines[i] = aLines[i].Replace(" this", " Item");

						//2. Replace the starting and ending [] with ()
						int npos = aLines[i].IndexOf("[");
						int nend = aLines[i].LastIndexOf("]");
						aLines[i] = aLines[i].Substring(0, npos) + "(" + aLines[i].Substring(npos + 1, (nend-npos-1)) + ")";

						//3. We fix and create the indexer 
						BaseManager bm = new BaseManager();
						bm.GetBlankToken(aLines[i]);
						aLines[i] = bm.BlankToken + "Default " + aLines[i].Trim();
					}

				}
				sb.Append(aLines[i] + "\n");
			}
			this.ClassBlockToken = sb.ToString();
		}

		private void BuildClassDeclaration(string tcline)
		{
			tcline = tcline.Replace(":", " : ");
			tcline = ReplaceManager.GetSingledSpacedString(tcline);

			string cCurrent = "";
			string cParent = "";

			//Check if a colon exists and create the two strings
			int npos = tcline.IndexOf(":");
			if(npos>0)
			{
				cCurrent = tcline.Substring(0, npos-1);
				cParent = tcline.Substring(npos).Trim(); // we assumed that the class is declared in one line FOR NOW
			}
			else
			{
				cCurrent = tcline;
				cParent = "";
			}

			//Build the class part
			cCurrent = ReplaceManager.HandleTypes(cCurrent);
			this.ClassDeclarationToken = cCurrent.Trim();

			//Extract the class name here
			int nClassPos = this.ClassDeclarationToken.LastIndexOf(" ");
			this.ClassNameToken = this.ClassDeclarationToken.Substring(nClassPos + 1);


			cParent = cParent.Replace(":", "").Trim();
	
			//Build the inheritence part
			if(cParent.Length == 0)
				return;

			string[] aParent = cParent.Split(',');
			for(int i = 0; i< aParent.Length; i++)
			{
				string cParentClass = aParent[i].Trim();
				string cImplementation = " Inherits ";

				//Could not figure out how we could differentiate between a class and an interface
				if(cParentClass[0] == 'i' || cParentClass[0] == 'I')
				{
					cImplementation = " Implements ";
				}

				this.ImplementationDeclationToken += "\n" + ((Char)9).ToString() + cImplementation + cParentClass ;
			}
		}

		protected virtual string Execute()
		{
			string lcRetVal;
			lcRetVal = this.BlankToken + this.ClassDeclarationToken + this.ImplementationDeclationToken;
			lcRetVal += this.ClassBlockToken + "\r\n" + this.BlankToken + "End Class" + "\r\n";
			return lcRetVal;
		}

	}
}
