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
using System.Collections;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using System.IO;
using System.Windows.Forms;

namespace com.mikelehman.bugtracker
{
	////////////////////////////////////////////////////////////
	/// <summary>
	/// A wrapper object holding a transaction type
	/// and the XML for a transaction
	/// </summary>
	////////////////////////////////////////////////////////////
	public class BTTransaction
	{
		protected string transactionType;
		protected string transactionXML;

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Constructor
		/// </summary>
		/// <param name="typ"></param>
		/// <param name="xml"></param>
		////////////////////////////////////////////////////////////
		public BTTransaction(string typ, string xml)
		{
			transactionType = typ;
			transactionXML = xml;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Accessor method for type
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public string getType()
		{
			return(transactionType);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Accessor method for xml data
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public string getXML()
		{
			return(transactionXML);
		}

	}
}
