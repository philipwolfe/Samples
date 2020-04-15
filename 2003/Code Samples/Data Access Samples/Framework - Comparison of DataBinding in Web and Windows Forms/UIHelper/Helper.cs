//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Data;
using System.Collections;

	public class UI
	{
	
		// This function inserts an option into the top row of a DataTable. if you want 
		// the additional option to appear at the top of the list well the data to
		// appear in alphabetical order it must be pre-sorted. Creating and sorting a 
		// DataView after the option is added may cause the additional option to not 
		// appear at the top. Thus, the data should be sorted at the SQL Server tier.

		public static DataSet AddOption(DataSet ds,string strDisplayField ,string strValueField , ref string strnewOptionText ,string strnewOptionValue ) 
		{
			DataTable dt;
			DataRow drnew;
			dt = ds.Tables[0];
			drnew = dt.NewRow();
			drnew[strDisplayField] = strnewOptionText;
			drnew[strValueField] = strnewOptionValue;
			dt.Rows.InsertAt(drnew, 0);
			dt.AcceptChanges();
			return ds;
		}

		// This function inserts an option into the top position of an ArrayList. See further 
		// comments, above.

		public static ArrayList AddOption(ArrayList arl ,Object objnewOption) 
		{
			arl.Insert(0, objnewOption);
			return arl;
		}
	}
