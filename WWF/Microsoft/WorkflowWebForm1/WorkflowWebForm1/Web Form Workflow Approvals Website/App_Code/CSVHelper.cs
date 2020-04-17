//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;
using System.Collections.Generic;

public class CSVHelper
{
	/// <summary>
	/// Exports the given DataView to a CSV file
	/// </summary>
	/// <param name="page">The page making the request</param>
	/// <param name="dataTable">The DataView to convert</param>
	/// <param name="columns">The columns of the DataView to export</param>
	/// <param name="seperator">The string to seperate each value</param>
	/// <param name="fileName">The default file name for the CSV file</param>
	/// <param name="includeColumnNames">Indicates if the first line should be the column names</param>
	public static void Export(Page page, DataView dataView, string[] columns, string seperator, string fileName, bool includeColumnNames)
	{
		Export(page,
				CreateDataTable(dataView, columns),
				seperator,
				fileName,
				includeColumnNames);
	}

	/// <summary>
	/// Exports the given DataTable to a CSV file
	/// </summary>
	/// <param name="page">The page making the request</param>
	/// <param name="dataTable">The DataTable to convert</param>
	/// <param name="seperator">The string to seperate each value</param>
	/// <param name="fileName">The default file name for the CSV file</param>
	/// <param name="includeColumnNames">Indicates if the first line should be the column names</param>
	public static void Export(Page page, DataTable dataTable, string seperator, string fileName, bool includeColumnNames)
	{
		StringBuilder stringBuilder = new StringBuilder();

		if (includeColumnNames)
		{
			//Write the column names out for the first line
			for (int i = 0; i < dataTable.Columns.Count; i++)
			{
				stringBuilder.Append(dataTable.Columns[i].Caption);

				if (!i.Equals(dataTable.Columns.Count - 1))
				{
					stringBuilder.Append(seperator);
				}
			}

			stringBuilder.Append(Environment.NewLine);
		}

		//Write each of the values for each row
		foreach (DataRow dataRow in dataTable.Rows)
		{
			for (int i = 0; i < dataTable.Columns.Count; i++)
			{
				stringBuilder.Append(dataRow[i].ToString());

				if (!i.Equals(dataTable.Columns.Count - 1))
				{
					stringBuilder.Append(seperator);
				}
			}

			stringBuilder.Append(Environment.NewLine);
		}

		page.Response.ClearHeaders();
		page.Response.AppendHeader("Content-Disposition", string.Format("attachment; filename={0}", fileName));
		page.Response.AppendHeader("Content-Length", stringBuilder.Length.ToString());
		page.Response.ContentType = "text/csv";
		page.Response.Write(stringBuilder.ToString());
		page.Response.End();
	}

	/// <summary>
	/// Creates a DataTable from the selected DataView
	/// </summary>
	/// <param name="dataView">The DataView to create the table from</param>
	/// <param name="columns">The DataColumns to be used in the new DataTable</param>
	public static DataTable CreateDataTable(DataView dataView, string[] columns)
	{
		DataTable dataTable = new DataTable();

		DataColumn dataColumn = null;
		DataColumn newColumn = null;

		foreach (string column in columns)
		{
			if (column != null)
			{
				dataColumn = dataView.Table.Columns[column];

				newColumn = new DataColumn(dataColumn.ColumnName, dataColumn.DataType);
				newColumn.Caption = dataColumn.Caption;
				dataTable.Columns.Add(newColumn);
			}
		}


		DataRow dataRow = null;

		foreach (DataRowView dataRowView in dataView)
		{
			dataRow = dataTable.NewRow();

			foreach (string column in columns)
			{
				if (column != null)
					dataRow[column] = dataRowView[column];
			}

			dataTable.Rows.Add(dataRow);
		}

		return dataTable;
	}
}
