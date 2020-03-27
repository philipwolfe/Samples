using System;
using System.Data;
using System.Data.Sql;
using System.Data.SqlTypes;
using Microsoft.SqlServer.Server;

[Serializable]
[Microsoft.SqlServer.Server.SqlUserDefinedType(Format.Native)]
public struct GeoCache : INullable
{
	/// <summary>
	/// This is an overloaded method that allows us to display the data stored
	/// in the user defined type.
	/// </summary>
	public override string ToString()
	{
		// Replace the followng code with your code
		if (this.m_Null)
			return null;
		else
			return this.LAT + ":" + this.LONG;
	}
	
	/// <summary>
	/// This method indicates whether the user defined type is null or not
	/// </summary>
	public bool IsNull
	{
		get
		{
			return m_Null;
		}
	}

	/// <summary>
	/// This creates a new instance of the user defined type
	/// </summary>
	public static GeoCache Null
	{
		get
		{
			GeoCache h = new GeoCache();
			h.m_Null = true;
			return h;
		}
	}

	/// <summary>
	/// This property handles access to the private longitude variable
	/// </summary>
	public double LONG
	{
		get
		{
			return m_longitude;
		}

		set
		{
			m_longitude = (double)value;
		}

	}

	/// <summary>
	/// This property handles access ot the private latitude variable
	/// </summary>
	public double LAT
	{
		get
		{
			return m_latitude;
		}
		set
		{
			m_latitude = (double)value;
		}
	}

	/// <summary>
	/// This method parses the values that are sent in and then
	/// sets the user defined type.
	/// </summary>
	public static GeoCache Parse(SqlString s)
	{
		if (s.IsNull)
			return Null;
		else
		{
			GeoCache u = new GeoCache();
			string str = s.ToString();
			string[] latlong = str.Split(",".ToCharArray());

			u.LAT = Double.Parse(latlong[0]);
			u.LONG = Double.Parse(latlong[1]);
			
			return u;
		}
	}

	
	// Private members
	private bool m_Null;
	private double m_longitude;
	private double m_latitude;
	
}


