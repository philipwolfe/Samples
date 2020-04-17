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
using System.Collections;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

public partial class Controls_FilterControl : System.Web.UI.UserControl
{
	private ListItem NoFilterListItem = new ListItem("No Filter");

	protected void Page_Load(object sender, EventArgs e)
	{

	}

	public void Initialise(DataColumn[] filterColumns)
	{
		Hashtable hashTable = new Hashtable(filterColumns.Length);

		this.dropDownList.Items.Add(NoFilterListItem);

		foreach (DataColumn column in filterColumns)
		{
			this.dropDownList.Items.Add(new ListItem(column.Caption, column.ColumnName));

			//We only care if the datatype is some special like a string, dateTime or bool
			if (column.DataType == typeof(string) ||
					column.DataType == typeof(DateTime) ||
					column.DataType == typeof(Boolean))
			{
				hashTable[column.ColumnName] = column.DataType;
			}
		}

		this.ColumnDataTypeHashtable = hashTable;
	}

	private Hashtable ColumnDataTypeHashtable
	{
		get
		{
			object obj = this.ViewState["columnDataTypeHashtable"];

			if (obj != null &&
					obj is Hashtable)
			{
				return (Hashtable)obj;
			}
			else
			{
				return new Hashtable();
			}
		}
		set
		{
			this.ViewState["columnDataTypeHashtable"] = value;
		}
	}

	public string FilterExpression
	{
		get
		{
			string filterExpression = string.Empty;

			if (!this.dropDownList.SelectedItem.Equals(this.NoFilterListItem))
			{
				string selectedColumn = this.dropDownList.SelectedValue;
				string filterText = this.filterTextBox.Text.Trim();
				object obj = this.ColumnDataTypeHashtable[selectedColumn];

				if (obj == null)
				{
					filterExpression = string.Format("{0} = {1}",
							selectedColumn,
							filterText);
				}
				else
				{
					if (obj == typeof(string))
					{
						filterExpression = string.Format("{0} = '{1}'",
								selectedColumn,
								filterText);
					}
					else if (obj == typeof(bool))
					{
						filterExpression = string.Format("{0} = {1}",
								selectedColumn,
								Convert.ToBoolean(filterText) ? "TRUE" : "FALSE");
					}
					else if (obj == typeof(DateTime))
					{
						DateTime date;

						if (DateTime.TryParse(filterText, out date))
						{
							//Between statement not supported
							filterExpression = string.Format("({0} >= '{1}') AND ({0} <= '{2}')",
									selectedColumn,
									date.Date,
									date.Date.AddDays(1).AddMilliseconds(-1));
						}
						else
						{
							JavascriptHelper.Alert(this.Page, "Filter date is not in the correct format", "FilterTextError");
						}
					}
				}
			}

			return filterExpression;
		}
	}

	protected void button_Click(object sender, EventArgs e)
	{
		this.OnFilterChanged();
	}

	public event EventHandler<FilterChangedEventArgs> FilterChanged;

	private void OnFilterChanged()
	{
		if (this.FilterChanged != null)
		{
			this.FilterChanged(this, new FilterChangedEventArgs(this.FilterExpression));
		}
	}
}

public class FilterChangedEventArgs : EventArgs
{
	string filterExpression;

	public string FilterExpression
	{
		get { return filterExpression; }
		set { filterExpression = value; }
	}

	public FilterChangedEventArgs(string filterExpression)
		: base()
	{
		this.filterExpression = filterExpression;
	}
}