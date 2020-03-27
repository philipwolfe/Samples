using System;
using System.Collections.Generic;
using System.Text;

namespace AnonymousMethods
{
    /*
     * A simple class that stores a name and price for an item.
     */ 
    class GroceryItem
    {
        private string _item = null;
        private decimal _price = 0;

        public GroceryItem(){}
        public GroceryItem(string item, decimal price)
        {
            _item = item;
            _price = price;
        }

        public string ITEM
        {
            get { return this._item; }
        }

        public decimal PRICE
        {
            get { return this._price; }
        }
    }
}
