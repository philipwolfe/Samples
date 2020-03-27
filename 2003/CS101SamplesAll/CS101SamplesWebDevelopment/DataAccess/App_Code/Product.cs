using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Microsoft.Samples.Web.DataAccess
{
	/// <summary>
	/// Summary description for Product
	/// </summary>
	public class Product
	{
		public Product()
		{
		}

		private int _productId;
		public int ProductId
		{
			get { return _productId; }
			set { _productId = value; }
		}

		private string _name;
		public string Name
		{
			get { return _name; }
			set { _name = value; }
		}

		private string _productNumber;
		public string ProductNumber
		{
			get { return _productNumber; }
			set { _productNumber = value; }
		}

		private int _reorderPoint;
		public int ReorderPoint
		{
			get { return _reorderPoint; }
			set { _reorderPoint = value; }
		}

		private decimal _standardCost;
		public decimal StandardCost
		{
			get { return _standardCost; }
			set { _standardCost = value; }
		}

		private decimal _listPrice;
		public decimal ListPrice
		{
			get { return _listPrice; }
			set { _listPrice = value; }
		}
	}
}
