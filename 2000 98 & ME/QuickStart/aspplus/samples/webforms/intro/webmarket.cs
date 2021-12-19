using System;
using System.Collections;

namespace WebMarket {

   public class ProductItem {

      public String productID;
      public String description;
      public double price;
      public String imageUrl;

      public String ProductId {
         get {
            return productID;
         }
      }

      public String Description {
         get {
            return description;
         }
      }

      public double Price {
         get {
            return price;
         }
      }

      public String ImageUrl {
         get {
            return imageUrl;
         }
      }

      public ProductItem(String productID, String description, double price, String imageUrl) {
        this.productID = productID;
        this.description = description;
        this.price = price;
        this.imageUrl = imageUrl;
      } 
   }

   public class InventoryDB {

      public IList GetProducts(String category) {

         ArrayList items = new ArrayList();

         if (category == "Milk") {
            items.Add(new ProductItem("10000", "Chocolate City Milk", 2.00, "/quickstart/aspplus/images/milk5.gif"));
            items.Add(new ProductItem("10001", "Bessie Brand 2% Milk", 1.19, "/quickstart/aspplus/images/milk1.gif"));
            items.Add(new ProductItem("10002", "Funny Farms Milk", 1.29, "/quickstart/aspplus/images/milk4.gif"));
            items.Add(new ProductItem("10003", "Marigold Whole Milk", 1.39, "/quickstart/aspplus/images/milk6.gif"));
         } 
         else if (category == "Cereal") {
            items.Add(new ProductItem("20000", "Fruity Pops", 4.07, "/quickstart/aspplus/images/cereal7.gif"));
            items.Add(new ProductItem("20001", "U.F.O.s Cereal", 3.34, "/quickstart/aspplus/images/cereal3.gif"));
            items.Add(new ProductItem("20002", "Healthy Grains", 3.78, "/quickstart/aspplus/images/cereal1.gif"));
            items.Add(new ProductItem("20003", "Super Sugar Strike", 4.17, "/quickstart/aspplus/images/cereal6.gif"));
         } 
         else if (category == "Soda") {
            items.Add(new ProductItem("30000", "Purple Rain", 1.10, "/quickstart/aspplus/images/soda5.gif"));
            items.Add(new ProductItem("30001", "Extreme Orange", 0.89, "/quickstart/aspplus/images/soda6.gif"));
            items.Add(new ProductItem("30002", "Kona Diet Cola", 1.10, "/quickstart/aspplus/images/soda7.gif"));
            items.Add(new ProductItem("30003", "Fizzy Fizzing Drink", 1.05, "/quickstart/aspplus/images/soda8.gif"));
         } 

         return items;
      }
   }
}