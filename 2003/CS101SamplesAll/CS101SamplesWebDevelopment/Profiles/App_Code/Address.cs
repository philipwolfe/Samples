using System;
using System.Data;
using System.Configuration;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;

namespace Samples.Web.Profiles
{
	/// <summary>
	/// Summary description for Address
	/// </summary>
	[Serializable]
	public class Address
	{
		private string _street;
		private string _city;
		private string _state;
		private string _zip;

		public Address()
		{
		}

		public string Street
		{
			get
			{
				return _street;
			}
			set
			{
				_street = value;
			}
		}

		public string City
		{
			get
			{
				return _city;
			}
			set
			{
				_city = value;
			}
		}

		public string State
		{
			get
			{
				return _state;
			}
			set
			{
				_state = value;
			}
		}

		public string ZipCode
		{
			get
			{
				return _zip;
			}
			set
			{
				_zip = value;
			}
		}
	}
}
