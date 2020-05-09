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

namespace com.mikelehman.bugtracker
{
	/// <summary>
	/// Summary description for BTXML.
	/// </summary>
	public class BTXML
	{
		private static System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();


		////////////////////////////////////////////////////////////
		/// <summary>
		/// Null constructor for BTXML class
		/// </summary>
		////////////////////////////////////////////////////////////
		public BTXML()
		{
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Convert a DataRow object into an MLBT XML string
		/// </summary>
		/// <param name="dr">A DataRow object</param>
		/// <returns>an MLBT XML string</returns>
		////////////////////////////////////////////////////////////
		public static string rowToXML(DataRow dr)
		{
			MemoryStream ms;
			XmlTextWriter xtw;
			int i;

			ms = new MemoryStream();
			xtw = new XmlTextWriter(ms, enc);

			xtw.Formatting = Formatting.Indented;
			xtw.Indentation = 4;
			xtw.IndentChar = ' ';
			xtw.WriteStartDocument(false);
			//
			// we write an enclosing element of <MLBT></MLBT>
			//
			xtw.WriteStartElement("MLBT");
			xtw.WriteAttributeString("version",com.mikelehman.bugtracker.Version.number);

			xtw.WriteStartElement(dr.Table.TableName);
			i = 0;
			foreach(Object x in dr.ItemArray)
			{
				if (x != System.DBNull.Value && x.ToString().Length > 0)
				{
					xtw.WriteStartElement(dr.Table.Columns[i].ColumnName);
					if (x != System.DBNull.Value)
					{
						xtw.WriteString(x.ToString());
					}
					xtw.WriteEndElement();
				}
				i++;
			}
			xtw.WriteEndElement();
			xtw.WriteEndElement();
			xtw.Flush();
			ms.Flush();
			ms.Close();
			return (enc.GetString(ms.ToArray()));

		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Convert an MLBT XML string
		/// into an ArrayList of BTDataItem objects
		/// </summary>
		/// <param name="xd">MLBT data in string form</param>
		/// <returns>ArrayList of BTDataItem objects</returns>
		////////////////////////////////////////////////////////////
		public static ArrayList getDataFromXML(string xd)
		{
			StringReader ss;
			XmlTextReader xtr;
			string version;
			ArrayList results;
			BTDataItem di;
			string nm;
			string vl;

			results = new ArrayList();
			ss = new StringReader(xd);
			xtr = new XmlTextReader(ss);

			while (xtr.Read() &&!(xtr.NodeType == XmlNodeType.Element))
				;

			version = xtr.GetAttribute("version");
			//Console.WriteLine("Version= "+version);

			while (xtr.Read() &&!(xtr.NodeType == XmlNodeType.Element))
				;

			xtr.Read();

			while(xtr.Read() && xtr.NodeType != XmlNodeType.Element)
				;
			while(true)
			{
				if (xtr.NodeType == XmlNodeType.Element)
				{
					nm = xtr.Name;
					xtr.Read();
					if (xtr.NodeType == XmlNodeType.Text)
						vl = xtr.ReadString();
					else
						vl = "";
					di = new BTDataItem(nm,vl);
					results.Add(di);
				}
				xtr.Read();
				if (xtr.NodeType == XmlNodeType.EndElement)
					break;
			}

			return(results);
		}
	
	}
}
