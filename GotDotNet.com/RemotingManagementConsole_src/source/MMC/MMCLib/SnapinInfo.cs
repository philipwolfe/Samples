using System;

namespace Ironring.Management.MMC
{
	/// <summary>
	/// Custom attribute applied to snapin classes.  The presence of this 
	/// attribute identifies it to the snapin registration utility and 
	/// associates attribute required during snapin installation to the 
	/// registry.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class SnapinInAttribute : System.Attribute
	{
        /// <summary>
        /// The name
        /// </summary>
        protected string m_name;

        /// <summary>
        /// The company name
        /// </summary>
        protected string m_provider;
        
        /// <summary>
        /// the snapin version
        /// </summary>
        protected string m_version;

        /// <summary>
        /// Standalon boolean
        /// </summary>
        protected bool m_standAlone;


        ///////////////////////////////////////////////////////////////////////
        ///
        /// Implementaiton
        ///
        

        /// <summary>
        /// Default ctor initialize to begnin values
        /// </summary>
		public SnapinInAttribute()
		{
			m_name = "unknown";
			m_provider = "unknown";
			m_standAlone = true;
			m_version = null;
		}

        /// <summary>
        /// Overloaded ctor initializes all fields
        /// </summary>
        /// <param name="namestring"></param>
        /// <param name="provider"></param>
        /// <param name="standAlone"></param>
		public SnapinInAttribute(string namestring, string provider)
		{
			m_name = namestring;
			m_provider = provider;
			m_standAlone = true;
			m_version = null;
		}

		/// <summary>
		/// Overloaded ctor initializes all fields
		/// </summary>
		/// <param name="namestring"></param>
		/// <param name="provider"></param>
		/// <param name="standAlone"></param>
		public SnapinInAttribute(string namestring, string provider, string version)
		{
			m_name = namestring;
			m_provider = provider;
			m_standAlone = true;
			m_version = version;
		}


		/// <summary>
		/// Overloaded ctor initializes all fields
		/// </summary>
		/// <param name="namestring"></param>
		/// <param name="provider"></param>
		/// <param name="standAlone"></param>
		public SnapinInAttribute(string namestring, string provider, string version, bool standAlone)
		{
			m_name = namestring;
			m_provider = provider;
			m_version = version;
			m_standAlone = standAlone;
		}

        /// <summary>
        /// The name
        /// </summary>
		public string Namestring
		{
			get { return m_name;  }
			set { m_name = value; }

		}

        /// <summary>
        /// StandAlone
        /// </summary>
		public bool StandAlone
		{
			get { return m_standAlone; }
			set { m_standAlone = value; }
		}

        /// <summary>
        /// Provider
        /// </summary>
		public string Provider
		{
			get { return m_provider; }
			set { m_provider = value; }
		}

        /// <summary>
        /// Version
        /// </summary>
		public string Version
		{
			get { return m_version; }
		}
		
	}


	/// <summary>
    /// Custom attribute applied to snapin about classes.  The presence 
    /// of this attribute identifies it to the snapin registration utility and 
    /// associates attribute required during snapin installation to the 
    /// registry.
    /// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class AboutSnapinAttribute : System.Attribute
	{
        /// <summary>
        /// The type of the snapin we refer to.  we can pull data from 
        /// the type by reflection
        /// </summary>
        protected Type m_SnapinType;

        /// <summary>
        /// Ctor
        /// </summary>
        /// <param name="type"></param>
        public AboutSnapinAttribute(Type type)
		{
			m_SnapinType = type;
		}

        /// <summary>
        /// Get the Type the snapin is based on
        /// </summary>
		public Type SnapinType
		{
			get { return m_SnapinType; }
		}
	}
}





