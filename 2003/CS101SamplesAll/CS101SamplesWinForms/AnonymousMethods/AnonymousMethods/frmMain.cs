using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace AnonymousMethods
{
    public partial class frmMain : Form
    {
        private List<GroceryItem> groceryList = new List<GroceryItem>();

        public frmMain()
        {
            InitializeComponent();
            cmbFilter.SelectedIndex = 0;
            cmbSort.SelectedIndex = 0;
        }

        private void UpdateGrid(List<GroceryItem> list)
        {
            int c=1;
            decimal total=0;
            dataGridView1.Rows.Clear();
            list.ForEach(delegate(GroceryItem item)
            {
                dataGridView1.Rows.Add(new object[] { c++, item.ITEM, String.Format("{0:c}",item.PRICE)});
                total += item.PRICE;
            });
            lblTotal.Text = String.Format("{0:c}",total);
        }

        private void Sort(string op)
        {
            List<GroceryItem> matches = new List<GroceryItem>();
            //get a copy of all GroceryItems in groceryList
            matches = groceryList.FindAll(delegate(GroceryItem item)
            {
               return item != null;
            });

            //sort by the user selected GroceryItem property
            matches.Sort(delegate(GroceryItem item1, GroceryItem item2)
            {
                if (op == "Price")
                    return Comparer<decimal>.Default.Compare(item1.PRICE, item2.PRICE);
                else
                    return Comparer<string>.Default.Compare(item1.ITEM, item2.ITEM);

            });
            UpdateGrid(matches);
        }

        private void PriceFilter(string op, decimal price)
        {
            List<GroceryItem> matches = new List<GroceryItem>();
            if (op == ">")
            {
                //An anonymous method removes the need for a seperate 
                //method and delegate declaration.  Instead everything is
                //located within the PriceFilter method body and inline 
                //with the FindAll Method.
                matches = groceryList.FindAll(delegate(GroceryItem item)
               {
                   return item.PRICE > price;
               });
            }
            else if (op == "<")
            {
                matches = groceryList.FindAll(delegate(GroceryItem item)
                {
                    return item.PRICE < price;
                });
            }
            else if (op == "=")
            {
                matches = groceryList.FindAll(delegate(GroceryItem item)
                {
                    return item.PRICE == price;
                });
            }
            UpdateGrid(matches);
        }
        #region Events

        private void frmMain_Load(object sender, EventArgs e)
        {
            GroceryItem[] items = new GroceryItem[]{
                new GroceryItem("Yogurt",Convert.ToDecimal(2.95)),
                new GroceryItem("Carrots",Convert.ToDecimal(1.55)),
                new GroceryItem("Celery",Convert.ToDecimal(0.99)),
                new GroceryItem("Rice",Convert.ToDecimal(5.39)),
                new GroceryItem("Bread",Convert.ToDecimal(3.95)),
                new GroceryItem("Milk",Convert.ToDecimal(3.95)),
                new GroceryItem("Soda",Convert.ToDecimal(1.99)),
                new GroceryItem("Cheese",Convert.ToDecimal(5.99)),
                new GroceryItem("Paper Towels",Convert.ToDecimal(4.55))
            };
            groceryList.AddRange(items);
            UpdateGrid(groceryList);
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbName.Text.Length > 0 && tbPrice.Text.Length > 0)
            {
                groceryList.Add(new GroceryItem(tbName.Text, Convert.ToDecimal(tbPrice.Text)));
                UpdateGrid(groceryList);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            if (tbFilterPrice.Text.Length > 0)
            {
                decimal d = Convert.ToDecimal(tbFilterPrice.Text);
                PriceFilter(cmbFilter.Text, d);
            }
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            UpdateGrid(groceryList);
        }

        private void btnSort_Click(object sender, EventArgs e)
        {
            Sort(cmbSort.Text);
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        #endregion
    }
}