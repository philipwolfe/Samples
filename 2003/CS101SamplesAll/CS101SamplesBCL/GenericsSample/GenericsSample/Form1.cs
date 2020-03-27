using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Diagnostics;

namespace GenericsSample
{
	public partial class Form1 : Form
	{
		public Form1()
		{
			InitializeComponent();

			// Create the two lists
			_unsafeList = new ArrayList();
			_safeList = new List<Order>();

			// Load in the sample objects
			LoadObjects();
		}

		private void LoadObjects()
		{
			// Load in a set of order objects
			this.masterObjectList.Items.Add(new Order(1, DateTime.Now, 200));
			this.masterObjectList.Items.Add(new Order(2, DateTime.Now, 200));
			this.masterObjectList.Items.Add(new Order(3, DateTime.Now, 200));
			this.masterObjectList.Items.Add(new Order(4, DateTime.Now, 200));

			// and a number of other types
			string aString = "test String";
			int anInt = 2;
			long aLong = 300;
			float aFloat = 300.00f;
			object anObject = new Object();

			this.masterObjectList.Items.Add(aString);
			this.masterObjectList.Items.Add(anInt);
			this.masterObjectList.Items.Add(aLong);
			this.masterObjectList.Items.Add(aFloat);
			this.masterObjectList.Items.Add(anObject);
		}

		private void AddSafeList_Click(object sender, EventArgs e)
		{
			// try to add the object to the list and write the exception
			// to the log window
			// You have to cast the object to order for the code to even compile
			// hence the name compile type safety
			foreach (object o in masterObjectList.CheckedItems)
			{
				try
				{
					_safeList.Add((Order)o);


					this.safeObjectList.Items.Add(o);
				}
				catch ( Exception ex )
				{
					this.exceptionLog.Text += ex.Message + "\r\n";
				}
			}
		}

		private void AddUnsafeList_Click(object sender, EventArgs e)
		{
			// try to add the object to the list and write the exception
			// to the log window
			// here no casting is needed as everything in the list is an object
			foreach (object o in masterObjectList.CheckedItems)
			{
				try
				{
					_unsafeList.Add(o);
					
					this.unsafeObjectList.Items.Add(o);
				}
				catch (Exception ex)
				{
					this.exceptionLog.Text += ex.Message + "\r\n";
				}
			}
		}

		private void startSpeedTest_Click(object sender, EventArgs e)
		{
			// Add 10000 items to a list and then iterate over the list
			List<Order> newSafeList = new List<Order>();
			ArrayList newUnsafeList = new ArrayList();

			Stopwatch stopWatch = new Stopwatch();

			long loadSafeListMs;
			long loadUnsafeMs;
			long iterateSafeListMs;
			long iterateUnsafeListMs;

			stopWatch.Start();
			for (int i = 1; i < 100000; i++)
			{
				Order newOrder = new Order(i, DateTime.Now, i + 100);

				newSafeList.Add(newOrder);
			}
			stopWatch.Stop();
			loadSafeListMs = stopWatch.ElapsedMilliseconds;
			stopWatch.Reset();

			stopWatch.Start();
			for (int i = 1; i < 100000; i++)
			{
				Order newOrder = new Order(i, DateTime.Now, i + 100);

				newUnsafeList.Add(newOrder);
			}
			stopWatch.Stop();
			loadUnsafeMs = stopWatch.ElapsedMilliseconds;
			stopWatch.Reset();

			stopWatch.Start();
			IterateSafeList(newSafeList);
			stopWatch.Stop();
			iterateSafeListMs = stopWatch.ElapsedMilliseconds;
			stopWatch.Reset();

			stopWatch.Start();
			IterateUnsafeList(newUnsafeList);
			stopWatch.Stop();
			iterateUnsafeListMs = stopWatch.ElapsedMilliseconds;
			stopWatch.Reset();

			this.LoadSafeListMs.Text = loadSafeListMs.ToString();
			this.LoadUnsafeListMs.Text = loadUnsafeMs.ToString();
			this.iterateSafeListMs.Text = iterateSafeListMs.ToString();
			this.IterateUnsafeListMs.Text = iterateUnsafeListMs.ToString();
		}

		private void IterateSafeList(List<Order> list)
		{
			// No casting needed
			foreach (Order _order in list)
			{
				long _amount = _order.Amount;
				DateTime _orderDate = _order.Date;
				int orderID = _order.ID;
			}
		}

		private void IterateUnsafeList(ArrayList list)
		{
			// have to cast from object to order
			foreach (Object _object in list)
			{
				Order _order = _object as Order;

				if (_order != null)
				{
					long _amount = _order.Amount;
					DateTime _orderDate = _order.Date;
					int orderID = _order.ID;
				}
			}
		}


		private ArrayList _unsafeList;
		private List<Order> _safeList;
	}
}