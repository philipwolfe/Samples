using System;

namespace HelperUtilities.Utils
{
	/// <summary>
	/// This class conatins the utility methods which returns the corresponding friendly text for any given object, regarding the corresponding data-type.
	/// These methods are useful when we bind data to any control.
	/// Date Written: 02-11-2005
	/// Written By: Mohammad Ashraful Alam [ joy_csharp@hotmail.com ]
	/// Last Update: Mar 24, 2006
	/// </summary>
	public class TypeText
	{
		/// <summary>
		/// Formats a bool object as Yes/No string.
		/// If the object is dbnull then it returns an empty string. 
		/// This method is useful when we bind data to any control.
		/// Date Written: 02-11-2005
		/// </summary>
		/// <param name="o">The object that contains the data</param>
		/// <returns>Yes/No format of the passed object, if this is db null returns empty</returns>
		public static string FormatBoolObject(object o)
		{
			bool Val;
			if ( ! Convert.IsDBNull(o))
			{
				
				try
				{
					Val = bool.Parse(o.ToString());
					if (Val)return "Yes";
					else return "No";
				}
				catch(Exception e){}

			}
			
			return string.Empty;
		}

		/// <summary>
		/// Formats a double item to two degree presitions.
		/// This method is useful when we bind data to any control.
		/// Date Written: 02-11-2005
		/// </summary>
		/// <param name="o">The object that contains the data</param>
		/// <returns>the double format of the passed object, if this is db null returns empty</returns>
		public static string FormatDoubleObject(object o)
		{
			double Val = 0;
			
			try
			{
				if ( ! Convert.IsDBNull(o))
				{
					Val = double.Parse(o.ToString());
				}
			}
			
			catch (Exception e){}
			
			return Val.ToString("0.00");
		}

		/// <summary>
		/// Formats a datetime item to short date string. 
		/// If the object is not a dbnull then it returns the shorst format of the passed object.
		/// Ex. MM/DD/YYYY
		/// This method is useful when we bind data to any control.
		/// Date Written: 02-11-2005
		/// </summary>
		/// <param name="o">The object that contains the data</param>
		/// <returns>the short format of the passed date time, if this is db null returns empty</returns>
		public static string FormatToShortDate(object o)
		{
			DateTime Val;
			if ( ! Convert.IsDBNull(o) )
			{
				try
				{
					Val = DateTime.Parse(o.ToString());
					return Val.ToShortDateString();
				}
				catch(Exception e){}
			}
			
			return string.Empty;
		}

		#region Test / Sampler Code 
		
		/// <summary>
		/// This is the tester class of the current parent class, which contains the sample code snippets to use this class properly in the real-world scenaris.
		/// </summary>
		/// <remarks>This class should NOT be present in the class doc.</remarks>
		class Tester
		{
		
		}

		#endregion
	}
}
