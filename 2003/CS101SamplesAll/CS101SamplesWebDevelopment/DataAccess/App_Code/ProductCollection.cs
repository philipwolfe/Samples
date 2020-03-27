using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Collections;

namespace Microsoft.Samples.Web.DataAccess
{
	/// <summary>
	/// Summary description for ProductCollection
	/// </summary>
	public class ProductCollection : CollectionBase
	{
		public ProductCollection()
		{
		}

		public Product Item(int index)
		{
			return (Product)List[index];
		}

		public int Add(Product product)
		{
			return List.Add(product);
		}
	}
}