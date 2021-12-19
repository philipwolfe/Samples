
namespace BusinessLayer 
{
using System;
using System.Data;
using System.Data.SQL;
using DataLayer;

  public class BusObj 
  {
    private DataObj data;

    public BusObj() 
    {
      data = new DataObj("server=localhost;uid=sa;pwd=;database=grocertogo");
    }

    public DataView GetCategories() 
    {
       return data.GetCategories();
    }

    public DataView GetProductsForCategory(String category, int customerid) 
    {
       DataView view = data.GetProductsForCategory(category);

       double discount = 0;
       if ((customerid >= 25)&&(customerid < 50))
       {
         discount = .50; 
       }
       else if ((customerid >= 50)&&(customerid < 75))
       {
         discount = 1.00; 
       }
       else if ((customerid >= 75)&&(customerid < 100))
       {
         discount = 1.50; 
       }

       for (int i=0; i<view.Count; i++)
       {
         view[i]["UnitPrice"] = Double.Parse(view[i]["UnitPrice"].ToString()) - discount;
       }

       return view;
    }
  }

}