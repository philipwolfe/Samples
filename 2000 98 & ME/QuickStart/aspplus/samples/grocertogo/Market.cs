using System;
using System.Data;
using System.Data.SQL;
using System.Collections;

namespace Market
{
   public class InventoryDB 
   {
      public DataTable GetProducts(int categoryID) {

          SQLConnection sqlConnection = new SQLConnection("server=localhost;uid=sa;pwd=;database=grocertogo");
          SQLDataSetCommand sqlAdapter1 = new SQLDataSetCommand("Select * from Products where categoryid=" + categoryID, sqlConnection);

          DataSet products = new DataSet();
          sqlAdapter1.FillDataSet(products, "products");

          return products.Tables[0];
      }

      public DataRow GetProduct(int productID) {

          SQLConnection sqlConnection = new SQLConnection("server=localhost;uid=sa;pwd=;database=grocertogo");

          SQLDataSetCommand sqlAdapter1 = new SQLDataSetCommand("Select * from Products where productID=" + productID, sqlConnection);
          DataSet product = new DataSet();
          sqlAdapter1.FillDataSet(product, "product");

          return product.Tables[0].Rows[0];
      }

      public DataTable GetProductCalories(int productID) {

          SQLConnection sqlConnection = new SQLConnection("server=localhost;uid=sa;pwd=;database=grocertogo");

          SQLDataSetCommand sqlAdapter1 = new SQLDataSetCommand("Select * from ProductDetails where productID=" + productID, sqlConnection);
          DataSet details = new DataSet();
          sqlAdapter1.FillDataSet(details, "details");

          return details.Tables[0];
      }
   }

   public class OrderItem 
   {
      public int productID;
      public int quantity;
      public String name;
      public double price;

      public OrderItem(int productID, String name, double price, int quantity)
      {
         this.productID = productID;
         this.quantity = quantity;
         this.name = name;
         this.price = price;
      } 

      public int ProductID
      {
         get { return ProductID; }
      }

      public int Quantity
      {
         get { return quantity; }
         set { quantity=value; }
      }

      public String Name
      {
         get { return name; }
      }

      public double Price
      {
         get { return price; }
      }

      public double Total 
      {
         get { return quantity * price; }
      }

   }

   public class OrderList  
   {
      private Hashtable orders    = new Hashtable();
      private double    taxRate   = 0.08;

      public double SubTotal 
      {
         get 
         { 
            if (orders.Count == 0)
               return 0.0;

            double subTotal = 0;

            IEnumerator items = orders.Values.GetEnumerator();

            while(items.MoveNext()) {

               subTotal += ((OrderItem) items.Current).Price * ((OrderItem) items.Current).Quantity;
            }
            
            return subTotal;
         }
      }

      public double TaxRate 
      {
         get { return taxRate; }
         set { taxRate = value; }
      }

      public double Tax 
      {
         get { return SubTotal * taxRate; }
      }

      public double Total 
      {
         get { return SubTotal * (1 + taxRate); }
      }

      public ICollection Values {
         get {
            return orders.Values;
         }
      }

      public OrderItem this[String name] {
         get {
            return (OrderItem) orders[name];
         }
      }

      public void Add(OrderItem value)
      {
         if (orders[value.Name] == null) {
            orders.Add(value.Name, value);
         }
         else
         {
            OrderItem oI = (OrderItem)orders[value.Name]; 
            oI.Quantity = oI.Quantity + 1;
         }
      }

      public void ClearCart() {
         orders.Clear();
      }
   }
}


