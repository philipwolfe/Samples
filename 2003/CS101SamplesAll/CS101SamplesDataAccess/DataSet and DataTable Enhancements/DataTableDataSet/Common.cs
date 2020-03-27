using System;
using System.Collections.Generic;
using System.Text;
using System.Data;

namespace DataTableDataSet
{
	class Common
	{
        /// <summary>
        /// This method creates the DataSet table if it doesn't exist.
        /// If it does exist, it clears the data that is stored in the table
        /// </summary>
        /// <param name="myDataSet"></param>
        /// <returns></returns>
		public DataSet CreateMyTable(DataSet myDataSet)
		{
			int i = 0;
            for (i = 0; i < myDataSet.Tables.Count; i++)
			{
                if (myDataSet.Tables[i].TableName == "MyTable")
				{
			        myDataSet.Tables["MyTable"].Clear();
                    myDataSet.Tables.Remove("MyTable");
				}
			}
			
			        myDataSet.Tables.Add("MyTable");
                    myDataSet.Tables["MyTable"].Columns.Add("ID", Type.GetType("System.Int32"));
                    myDataSet.Tables["MyTable"].Columns["ID"].Unique = true;
                    myDataSet.Tables["MyTable"].Columns.Add("IntegerValue1", Type.GetType("System.Int32"));

			    return myDataSet;
		}

        /// <summary>
        /// This method creates a table that is used in the DataView example.
        /// It checks to see if the table exists.  If it does exist, it just 
        /// clears the data from the table.
        /// </summary>
        /// <param name="myDataSet"></param>
        /// <returns></returns>
        public DataSet CreateMyDataViewTable(DataSet myDataSet)
		{
			bool tableExists = false;
			int i = 0;
            for (i = 0; i < myDataSet.Tables.Count; i++)
			{
                if (myDataSet.Tables[i].TableName == "MyDataViewTable")
				{
					tableExists = true;
				}
			}

			if (!tableExists)
			{
                myDataSet.Tables.Add("MyDataViewTable");
                myDataSet.Tables["MyDataViewTable"].Columns.Add("ID", Type.GetType("System.Int32"));
                myDataSet.Tables["MyDataViewTable"].Columns["ID"].Unique = true;
                myDataSet.Tables["MyDataViewTable"].Columns.Add("IntegerValue1", Type.GetType("System.Int32"));
                myDataSet.Tables["MyDataViewTable"].Columns.Add("IntegerValue2", Type.GetType("System.Int32"));
                myDataSet.Tables["MyDataViewTable"].Columns.Add("IntegerValue3", Type.GetType("System.Int32"));

			
			}
			else
			{
                myDataSet.Clear();
			}

            return myDataSet;
		}
	}
}
