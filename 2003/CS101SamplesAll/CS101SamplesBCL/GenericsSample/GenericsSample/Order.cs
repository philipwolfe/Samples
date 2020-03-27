using System;
using System.Collections.Generic;
using System.Text;

namespace GenericsSample
{
	class Order
	{
		public Order(int orderID, DateTime orderDate, long orderAmount)
		{
			this._orderID = orderID;
			this._orderDate = orderDate;
			this._orderAmount = orderAmount;
		}

		public int ID
		{
			get { return _orderID; }
			set { _orderID = value; }
		}

		public DateTime Date
		{
			get { return _orderDate; }
			set { _orderDate = value; }
		}

		public long Amount
		{
			get { return _orderAmount; }
			set { _orderAmount = value; }
		}

		public override string ToString()
		{
			return String.Format ( "{0}, {1}, {2}", _orderID, _orderDate, _orderAmount );
		}


		private int _orderID;
		private DateTime _orderDate;
		private long _orderAmount;
	}
}
