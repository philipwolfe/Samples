using System;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Text;

namespace Microsoft.Samples.Web.DataAccess
{
	/// <summary>
	/// Summary description for ProductLogic
	/// </summary>
	public class ProductLogic
	{
		public ProductLogic()
		{
		}

		public ProductCollection GetAllProducts()
		{
			ProductCollection coll = null;
			SqlDataReader rdr = null;
			string connectString = GetConnectionString();
			string sqlStatement = GetSqlStatement();
			SqlConnection cnn = new SqlConnection(connectString);
			SqlCommand cmd = new SqlCommand(sqlStatement, cnn);

			try
			{
				cnn.Open();
				rdr = cmd.ExecuteReader();

				if (rdr.HasRows)
				{
					coll = new ProductCollection();
					while (rdr.Read())
					{
						// Create a new Product object and set its properties
						Product product = new Product();
						product.ListPrice = Convert.ToDecimal(rdr["ListPrice"]);
						product.Name = Convert.ToString(rdr["Name"]);
						product.ProductId = Convert.ToInt32(rdr["ProductID"]);
						product.ProductNumber = Convert.ToString(rdr["ProductNumber"]);
						product.ReorderPoint = Convert.ToInt32(rdr["ReorderPoint"]);
						product.StandardCost = Convert.ToDecimal(rdr["StandardCost"]);

						// Add the Product object to the collection
						coll.Add(product);
					}
				}
			}
			catch (SqlException ex)
			{
				// Do something more meaningful
				throw;
			}
			finally
			{
				// Close the SqlDataReader
				if (rdr.IsClosed == false)
				{
					rdr.Close();
				}

				// Close the SqlConnection
				if (cnn.State == ConnectionState.Open)
				{
					cnn.Close();
				}
			}
			return coll;
		}

		private string GetSqlStatement()
		{
			StringBuilder sb = new StringBuilder();
			sb.Append("SELECT [ProductID], [Name], [ProductNumber], [ReorderPoint], [StandardCost], [ListPrice] ");
			sb.Append("FROM [Production].[Product]");
			return sb.ToString();
		}

		private string GetConnectionString()
		{
			// Build a connnection string to the AdventureWorks database
			SqlConnectionStringBuilder connectStringBuilder = new SqlConnectionStringBuilder();
			connectStringBuilder.DataSource = @"(local)\SQLEXPRESS";
			connectStringBuilder.AttachDBFilename = @"C:\Program Files\Microsoft SQL Server\MSSQL.1\MSSQL\Data\AdventureWorks_Data.mdf";
			connectStringBuilder.IntegratedSecurity = true;
			return connectStringBuilder.ConnectionString;
		}
	}
}