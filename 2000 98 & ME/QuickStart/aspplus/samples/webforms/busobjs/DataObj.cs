
namespace DataLayer 
{
using System;
using System.Data;
using System.Data.SQL;

  public class DataObj 
  {
    private String _connStr;

    public DataObj() 
    {
      _connStr = null;
    }

    public DataObj(String connStr) 
    {
      _connStr = connStr;
    }

    public String ConnectionString 
    {
      get 
      {
        return _connStr;
      }
      set 
      {
        _connStr = value;
      }
    }

    public DataView GetCategories() 
    {
      SQLConnection myConnection = new SQLConnection(_connStr);
      SQLDataSetCommand myCommand = new SQLDataSetCommand("select distinct CategoryName from Categories", myConnection);

      DataSet ds = new DataSet();
      myCommand.FillDataSet(ds, "Categories");

      return ds.Tables["Categories"].DefaultView;
    }

    public DataView GetProductsForCategory(String category) 
    {
      SQLConnection myConnection = new SQLConnection(_connStr);
      SQLDataSetCommand myCommand = new SQLDataSetCommand("select ProductName, ImagePath, UnitPrice, c.CategoryId  from Products p, Categories c where c.CategoryName='" + category + "' and p.CategoryId = c.CategoryId", myConnection);

      DataSet ds = new DataSet();
      myCommand.FillDataSet(ds, "Products");

      return ds.Tables["Products"].DefaultView;
    }
  }

}