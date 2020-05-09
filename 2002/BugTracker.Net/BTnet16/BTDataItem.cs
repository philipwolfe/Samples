////////////////////////////////////////////////////////////
///
/// This code is copyright (c) 2002, by Michael G. Lehman
/// It may be used for no charge for non-commerical purposes
/// including education and training uses.
/// 
/// For commercial distribution or licensing please contact
/// http://www.mikelehman.com
/// 
/// I provide software development and consulting services
/// and am always looking for new clients.
/// 
////////////////////////////////////////////////////////////
using System;

namespace com.mikelehman.bugtracker
{
	////////////////////////////////////////////////////////////
	/// <summary>
	/// Item to hold multivalued results from
	/// XML reading
	/// </summary>
	////////////////////////////////////////////////////////////
	public class BTDataItem
	{
		protected string name;
		protected string val;

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Parameterless constructor
		/// </summary>
		////////////////////////////////////////////////////////////
		public BTDataItem()
		{
			name = null;
			val = null;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Constructor that initializes values
		/// </summary>
		/// <param name="n">name of BTDataItem</param>
		/// <param name="v">value of BTDataItem</param>
		////////////////////////////////////////////////////////////
		public BTDataItem(string n, string v)
		{
			name = n;
			val = v;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Retrieve name member
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public string getName()
		{
			return(name);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Retrieve value member
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public string getValue()
		{
			return(val);
		}

	}
}
////////////////////////////////////////////////////////////
///
/// This code is copyright (c) 2002, by Michael G. Lehman
/// It may be used for no charge for non-commerical purposes
/// including education and training uses.
/// 
/// For commercial distribution or licensing please contact
/// http://www.mikelehman.com
/// 
/// I provide software development and consulting services
/// and am always looking for new clients.
/// 
////////////////////////////////////////////////////////////
