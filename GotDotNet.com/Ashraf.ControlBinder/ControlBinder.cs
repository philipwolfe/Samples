using System;
using System.Data;
using System.Collections;
using System.Web.UI.WebControls;

namespace Ashraf
{
	/// <summary>
	/// This class contains a utility class that facititates the control binding, considering data-table, collections, country list, state list etc. 
	/// Written By: Mohammad Ashraful Alam [ joy_csharp@hotmail.com ]
	/// Last Update: Mar 24, 2006
	/// </summary>
	public class ControlBinder
	{
		#region DropdownList Control Binder
		
		#region DataTable Related Binding
		
		/// <summary>
		/// Binds the drop down.
		/// </summary>
		/// <param name="ddl">The DDL.</param>
		/// <param name="dt">The dt.</param>
		/// <param name="dataTextField">The data text field.</param>
		/// <param name="dataValueField">The data value field.</param>
		public static void BindDropDown(System.Web.UI.WebControls.DropDownList ddl, DataTable dt, string dataTextField, string dataValueField)
		{
			ControlBinder.BindDropDown(ddl, dt, dataTextField, dataValueField, TopField.NoTopField);
		}
		
		/// <summary>
		/// Binds a dropdown considering DataTable. 
		/// Inserts an extra filed at the start labling as "All"/ "None" depending on the value of the passed parameter, with the value "-1"
		/// </summary>
		/// <param name="ddl">the dropdownlist control</param>
		/// <param name="dt">the data table that will be used as the data-source</param>
		/// <param name="dataTextField">the field of the datasource, which will be used to display</param>
		/// <param name="dataValueField">the field of the datasource, which will be used to store value in each datalist item</param>
		/// <param name="topField">the text which should be inserted and shown as the first element of the dropdownlist</param>
		public static void BindDropDown(System.Web.UI.WebControls.DropDownList ddl, DataTable dt, string dataTextField, string dataValueField, TopField topField)
		{
			ddl.Items.Clear();
			
			if ( topField != TopField.NoTopField) 
				AddToDropDown(ddl, topField.ToString(), "-1");
			
			foreach( DataRow dr in dt.Rows)
			{
				AddToDropDown(ddl, dr[dataTextField].ToString(), dr[dataValueField].ToString());
			}
			
			//SortDropDown(ddl, true);
		}

		#endregion

		#region Collection Related Binding

		/// <summary>
		/// Binds a dropdown considering a collection datasource.
		/// </summary>
		/// <param name="ddl">the dropdownlist control</param>
		/// <param name="cb">The cb.</param>
		/// <param name="dataTextField">the field of the datasource, which will be used to display</param>
		/// <param name="dataValueField">the field of the datasource, which will be used to store value in each datalist item</param>
		public static void BindDropDown(DropDownList ddl, CollectionBase cb , string dataTextField, string dataValueField)
		{
			ControlBinder.BindDropDown(ddl, cb, dataTextField, dataValueField, TopField.NoTopField );
		}
		
		/// <summary>
		/// Binds a dropdown considering a collection datasource.
		/// Inserts an extra filed at the start labling as "All"/ "None" depending on the value of the passed parameter, with the value "-1"
		/// </summary>
		/// <param name="ddl">the dropdownlist control</param>
		/// <param name="cb">The cb.</param>
		/// <param name="dataTextField">the field of the datasource, which will be used to display</param>
		/// <param name="dataValueField">the field of the datasource, which will be used to store value in each datalist item</param>
		/// <param name="topField">the text which should be inserted and shown as the first element of the dropdownlist</param>
		public static void BindDropDown(DropDownList ddl, CollectionBase cb , string dataTextField, string dataValueField, TopField topField)
		{
			ddl.Items.Clear();
			ddl.DataSource = cb;
			ddl.DataTextField = dataTextField;
			ddl.DataValueField = dataValueField;
			ddl.DataBind();
			
			if ( topField != TopField.NoTopField) 
			{
				ListItem item = new ListItem();
				item.Text = topField.ToString();
				item.Value = "-1";
				ddl.Items.Insert(0, item);//added to first
			}
		}

		#endregion

		#region Special Data Binding

		
		/// <summary>
		/// Binds all the countries in the provided dropdownlist.
		/// Date written: 06-01-2005
		/// </summary>
		/// <param name="ddl">The DDL.</param>
		public static void BindCountryList( DropDownList ddl )
		{
			BindCountryList(ddl, TopField.NoTopField );
		}

		/// <summary>
		/// Binds all the countries in the provided dropdownlist.
		/// Date written: 06-01-2005
		/// </summary>
		/// <param name="ddl">The DDL.</param>
		/// <param name="topField">The top field.</param>
		public static void BindCountryList( DropDownList ddl, TopField topField  )
		{
			//binding country dropdown control
			ddl.Items.Clear(); 
			
			//add the 'None'/'All' item first
			if ( topField != TopField.NoTopField ) 
				AddToDropDown(ddl, topField.ToString(), "-1"); 
			
			//ddl.Items.Add("--Country--");
            ddl.Items.Add("Afghanistan");
            ddl.Items.Add("Albania");
            ddl.Items.Add("Algeria");
            ddl.Items.Add("Andorra");
            ddl.Items.Add("Angola");
            ddl.Items.Add("Antigua and Barbuda");
            ddl.Items.Add("Argentina");
            ddl.Items.Add("Armenia");
            ddl.Items.Add("Australia");
            ddl.Items.Add("Austria");
            ddl.Items.Add("Azerbaijan");
            ddl.Items.Add("Bahamas");
            ddl.Items.Add("Bahrain");
            ddl.Items.Add("Bangladesh");
            ddl.Items.Add("Barbados");
            ddl.Items.Add("Belarus");
            ddl.Items.Add("Belgium");
            ddl.Items.Add("Belize");
            ddl.Items.Add("Benin");
            ddl.Items.Add("Bhutan");
            ddl.Items.Add("Bolivia");
            ddl.Items.Add("Bosnia and Herzegovina");
            ddl.Items.Add("Botswana");
            ddl.Items.Add("Brazil");
            ddl.Items.Add("Brunei");
            ddl.Items.Add("Bulgaria");
            ddl.Items.Add("Burkina Faso");
            ddl.Items.Add("Burundi");
            ddl.Items.Add("Cambodia");
            ddl.Items.Add("Cameroon");
            ddl.Items.Add("Canada");
            ddl.Items.Add("Cape Verde");
            ddl.Items.Add("Central African Republic");
            ddl.Items.Add("Chad");
            ddl.Items.Add("Chile");
            ddl.Items.Add("China");
            ddl.Items.Add("Colombia");
            ddl.Items.Add("Comoros");
            ddl.Items.Add("Congo (Brazzaville)");
            ddl.Items.Add("Congo, Democratic Republic of the");
            ddl.Items.Add("Costa Rica");
            ddl.Items.Add("Croatia");
            ddl.Items.Add("Cuba");
            ddl.Items.Add("Cyprus");
            ddl.Items.Add("Czech Republic");
            ddl.Items.Add("Cote dIvoire");
            ddl.Items.Add("Denmark");
            ddl.Items.Add("Djibouti");
            ddl.Items.Add("Dominica");
            ddl.Items.Add("Dominican Republic");
            ddl.Items.Add("East Timor");
            ddl.Items.Add("Ecuador");
            ddl.Items.Add("Egypt");
            ddl.Items.Add("El Salvador");
            ddl.Items.Add("Equatorial Guinea");
            ddl.Items.Add("Eritrea");
            ddl.Items.Add("Estonia");
            ddl.Items.Add("Ethiopia");
            ddl.Items.Add("Fiji");
            ddl.Items.Add("Finland");
            ddl.Items.Add("France");
            ddl.Items.Add("Gabon");
            ddl.Items.Add("Gambia, The");
            ddl.Items.Add("Georgia");
            ddl.Items.Add("Germany");
            ddl.Items.Add("Ghana");
            ddl.Items.Add("Greece");
            ddl.Items.Add("Grenada");
            ddl.Items.Add("Guatemala");
            ddl.Items.Add("Guinea-Bissau");
            ddl.Items.Add("Guyana");
            ddl.Items.Add("Haiti");
            ddl.Items.Add("Honduras");
            ddl.Items.Add("Hungary");
            ddl.Items.Add("Iceland");
            ddl.Items.Add("India");
            ddl.Items.Add("Indonesia");
            ddl.Items.Add("Iran");
            ddl.Items.Add("Iraq");
            ddl.Items.Add("Ireland");
            ddl.Items.Add("Israel");
            ddl.Items.Add("Italy");
            ddl.Items.Add("Jamaica");
            ddl.Items.Add("Japan");
            ddl.Items.Add("Jordan");
            ddl.Items.Add("Kazakhstan");
            ddl.Items.Add("Kenya");
            ddl.Items.Add("Kiribati");
            ddl.Items.Add("Korea, North");
            ddl.Items.Add("Korea, South");
            ddl.Items.Add("Kuwait");
            ddl.Items.Add("Kyrgyzstan");
            ddl.Items.Add("Laos");
            ddl.Items.Add("Latvia");
            ddl.Items.Add("Lebanon");
            ddl.Items.Add("Lesotho");
            ddl.Items.Add("Liberia");
            ddl.Items.Add("Libya");
            ddl.Items.Add("Liechtenstein");
            ddl.Items.Add("Lithuania");
            ddl.Items.Add("Luxembourg");
            ddl.Items.Add("Macedonia");
            ddl.Items.Add("Madagascar");
            ddl.Items.Add("Malawi");
            ddl.Items.Add("Malaysia");
            ddl.Items.Add("Maldives");
            ddl.Items.Add("Mali");
            ddl.Items.Add("Malta");
            ddl.Items.Add("Marshall Islands");
            ddl.Items.Add("Mauritania");
            ddl.Items.Add("Mauritius");
            ddl.Items.Add("Mexico");
            ddl.Items.Add("Micronesia");
            ddl.Items.Add("Moldova");
            ddl.Items.Add("Monaco");
            ddl.Items.Add("Mongolia");
            ddl.Items.Add("Morocco");
            ddl.Items.Add("Mozambique");
            ddl.Items.Add("Myanmar");
            ddl.Items.Add("Namibia");
            ddl.Items.Add("Nauru");
            ddl.Items.Add("Nepal");
            ddl.Items.Add("Netherlands");
            ddl.Items.Add("New Zealand");
            ddl.Items.Add("Nicaragua");
            ddl.Items.Add("Niger");
            ddl.Items.Add("Nigeria");
            ddl.Items.Add("Norway");
            ddl.Items.Add("Oman");
            ddl.Items.Add("Pakistan");
            ddl.Items.Add("Palau");
            ddl.Items.Add("Panama");
            ddl.Items.Add("Papua New Guinea");
            ddl.Items.Add("Paraguay");
            ddl.Items.Add("Peru");
            ddl.Items.Add("Philippines");
            ddl.Items.Add("Poland");
            ddl.Items.Add("Portugal");
            ddl.Items.Add("Qatar");
            ddl.Items.Add("Romania");
            ddl.Items.Add("Russia");
            ddl.Items.Add("Rwanda");
            ddl.Items.Add("Saint Kitts and Nevis");
            ddl.Items.Add("Saint Lucia");
            ddl.Items.Add("Saint Vincent and The Grenadines");
            ddl.Items.Add("Samoa");
            ddl.Items.Add("San Marino");
            ddl.Items.Add("Sao Tome and Principe");
            ddl.Items.Add("Saudi Arabia");
            ddl.Items.Add("Senegal");
            ddl.Items.Add("Serbia and Montenegro");
            ddl.Items.Add("Seychelles");
            ddl.Items.Add("Sierra Leone");
            ddl.Items.Add("Singapore");
            ddl.Items.Add("Slovakia");
            ddl.Items.Add("Slovenia");
            ddl.Items.Add("Solomon Islands");
            ddl.Items.Add("Somalia");
            ddl.Items.Add("South Africa");
            ddl.Items.Add("Spain");
            ddl.Items.Add("Sri Lanka");
            ddl.Items.Add("Sudan");
            ddl.Items.Add("Suriname");
            ddl.Items.Add("Swaziland");
            ddl.Items.Add("Sweden");
            ddl.Items.Add("Switzerland");
            ddl.Items.Add("Syria");
            ddl.Items.Add("Taiwan");
            ddl.Items.Add("Tajikistan");
            ddl.Items.Add("Tanzania");
            ddl.Items.Add("Thailand");
            ddl.Items.Add("Togo");
            ddl.Items.Add("Tonga");
            ddl.Items.Add("Trinidad and Tobago");
            ddl.Items.Add("Tunisia");
            ddl.Items.Add("Turkey");
            ddl.Items.Add("Turkmenistan");
            ddl.Items.Add("Tuvalu");
            ddl.Items.Add("Uganda");
            ddl.Items.Add("Ukraine");
            ddl.Items.Add("United Arab Emirates");
            ddl.Items.Add("United Kingdom");
            ddl.Items.Add("United States");
            ddl.Items.Add("Uruguay");
            ddl.Items.Add("Uzbekistan");
            ddl.Items.Add("Vanuatu");
            ddl.Items.Add("Vatican City");
            ddl.Items.Add("Venezuela");
            ddl.Items.Add("Vietnam");
            ddl.Items.Add("Western Sahara");
            ddl.Items.Add("Yemen");
            ddl.Items.Add("Zambia");
            ddl.Items.Add("Zimbabwe");

		}
		
		/// <summary>
		/// Binds the USA States to dropdown.
		/// Date written: 05-01-2005
		/// </summary>
		/// <param name="ddl">The DDL.</param>
		public static void BindUSAStateToDropdown( DropDownList ddl )
		{
			BindUSAStateToDropdown(ddl, TopField.NoTopField );
		}
		
		/// <summary>
		/// Binds the USA States to dropdown.
		/// Date written: 05-01-2005
		/// </summary>
		/// <param name="ddl">The DDL.</param>
		/// <param name="topField">The top field.</param>
		public static void BindUSAStateToDropdown( DropDownList ddl, TopField topField )
		{
			//binding states dropdown control
			ddl.Items.Clear(); 
			//add the 'None'/'All' item first
			if ( topField != TopField.NoTopField) 
				//ddl.Items.Add(new ListItem(topField.ToString(), "-1")); 
				AddToDropDown(ddl, topField.ToString(), "-1");
			
			for (short i=0; i<51; i++) 
				AddToDropDown(ddl,AllUSAStates(i), AllUSAStates(i)); 
			
		}

		static string AllUSAStates(int wh) 
		{ 
			string [] bStates = 
			{
				"AK","AL","AR","AZ","CA",	// 1 
				"CO","CT","DC","DE","FL",	// 2 
				"GA","HI","IA","ID","IL",	// 3 
				"IN","KS","KY","LA","MA",	// 4 
				"ME","MD","MI","MN","MO",	// 5 
				"MS","MT","NC","ND","NE",	// 6 
				"NH","NJ","NM","NV","NY",	// 7 
				"OH","OK","OR","PA","RI",	// 8 
				"SC","SD","TN","TX","UT",	// 9 
				"VA","VT","WA","WI","WV",	//10 
				"WY"};						//11 
			if (wh>=0 && wh<51) return bStates[wh]; 
			return null; 
		} 
		
		#endregion
		
		#region Other Related Methods

		/// <summary>
		/// Adds an item to the given drop down list 
		/// </summary>
		/// <param name="ddl"></param>
		/// <param name="DataTextField"></param>
		/// <param name="DataValueField"></param>
		public static void AddToDropDown(System.Web.UI.WebControls.DropDownList ddl, string DataTextField, string DataValueField)
		{
			System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem();
			item.Text = DataTextField;
			item.Value = DataValueField;
			ddl.Items.Insert(ddl.Items.Count, item);//added to last
			
		}
		
		/// <summary>
		/// Sorts all the list items, except the first item.
		/// NOT PROPERLY TESTED.
		/// </summary>
		/// <param name="ddl"></param>
		static void SortDropDown(System.Web.UI.WebControls.DropDownList ddl)
		{
			//sorts all item except the first.
		
			System.Collections.SortedList sl = new System.Collections.SortedList();

			
			//getting the values in sorted order
			for(int i = 1; i < ddl.Items.Count; i++)//staring from the second item
			{
				if (!sl.ContainsKey(ddl.Items[i].Text))
					sl.Add(ddl.Items[i].Text, ddl.Items[i].Value.ToString());
			}
			
			//getting the list
			System.Collections.IList IL = sl.GetValueList();			
			
			//forming the dropdown control with listed values
			for (int i = 0; i < sl.Count; i++)
			{
				System.Web.UI.WebControls.ListItem item = new System.Web.UI.WebControls.ListItem();
					
				item.Text = sl.GetKey(i).ToString();
				item.Value = IL[i].ToString();
					
				ddl.Items.RemoveAt(i + 1);
				ddl.Items.Insert(i + 1, item);
			}			
		}
		
		#endregion

		#endregion 

		#region Test / Sampler Code 
		
		/// <summary>
		/// This is the tester class of the current parent class, which contains the sample code snippets to use this class properly in the real-world scenaris.
		/// </summary>
		/// <remarks>This class should NOT be present in the class doc.</remarks>
		class Tester
		{
			Tester()
			{
				//UIL.ControlBinder.BindDropDown(this.ddlCustomerSource, dt, "CustomerSourceName","CustomerSourceID", HelperUtilities.TopField.None);
			}
		}

		#endregion
	}
}
