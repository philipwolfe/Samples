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
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;
using System.Data.OleDb;
using System.Xml;
using System.IO;

namespace com.mikelehman.bugtracker
{
	////////////////////////////////////////////////////////////
	/// <summary>
	/// BTExec takes XML payloads and "executes"
	/// them against the database.
	/// 
	/// In this way, we can handle our local transactions
	/// and also, eventually, handle local playback of
	/// "remote" transactions.
	/// </summary>
	////////////////////////////////////////////////////////////
	public class BTExec
	{
		protected static BTExec singleton = null;
		protected System.Data.OleDb.OleDbDataAdapter personDA;
		protected DataSet personDS;
		protected System.Data.OleDb.OleDbDataAdapter releaseDA;
		protected DataSet releaseDS;
		protected System.Data.OleDb.OleDbDataAdapter bugDA;
		protected DataSet bugDS;
		protected Hashtable props;

		public BTExec(System.Data.OleDb.OleDbDataAdapter personDA,
			          DataSet personDS,
			          System.Data.OleDb.OleDbDataAdapter releaseDA,
			          DataSet releaseDS,
			          System.Data.OleDb.OleDbDataAdapter bugDA,
			          DataSet bugDS,
					  Hashtable props)
		{
			this.personDA = personDA;
			this.personDS = personDS;
			this.releaseDA = releaseDA;
			this.releaseDS = releaseDS;
			this.bugDA = bugDA;
			this.bugDS = bugDS;
			this.props = props;
			singleton = this;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Get the single instance of our class.
		/// So we can call it from anywhere without
		/// having to allocate a new one each time
		/// </summary>
		/// <returns>Reference to singleton instance of BTExec</returns>
		////////////////////////////////////////////////////////////
		public static BTExec getSingleton()
		{
			if (singleton == null)
				MessageBox.Show("Call to BTExec.getSingleton() before constructor called!");
			return(singleton);
		}

		public void exec(string command, string xml)
		{
			exec(command,xml,true);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Perform the requested operation give the
		/// XML data.
		/// 
		/// So far, we support:
		///		add.person
		///		add.release
		///		add.bug
		///		resolve.bug
		/// </summary>
		/// <param name="command">Command string (see docs)</param>
		/// <param name="xml">a DataRow as XML (see BTXML.cs)</param>
		////////////////////////////////////////////////////////////
		public void exec(string command, string xml, bool record)
		{
			ArrayList items;

			//Console.WriteLine(xml);

			if (record)
				BTnetMain.session.addTransaction(new BTTransaction(command,xml));

			items = BTXML.getDataFromXML(xml);

			switch(command)
			{
				case "add.person":
						AddPerson(items, false);
						break;

				case "add.release":
						AddRelease(items, false);
						break;

				case "update.person":
						UpdatePerson(items);
						break;

				case "update.release":
						UpdateRelease(items);
						break;

				case "add.bug":
						AddBug(items,false);
						break;

				case "resolve.bug":
						ResolveBug(items);
						break;

				case "update.bug.data":
						UpdateBugData(items);
						break;
			}
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Add a person to our database
		/// </summary>
		/// <param name="items"></param>
		////////////////////////////////////////////////////////////
		protected void AddPerson(ArrayList items, bool forceAdd)
		{
			DataRow dr;
			BTDataItem xdi;

			xdi = getDataItem("personOID",items);
			if (xdi != null)
			{
				dr = personDS.Tables["BT_PERSON"].Rows.Find(xdi.getValue());
				if (dr != null)
				{
					UpdatePerson(items);
					return;
				}
			}



			dr = personDS.Tables["BT_PERSON"].NewRow();
			dr.BeginEdit();
			foreach(BTDataItem di in items)
			{
				dr[di.getName()] = di.getValue();
			}
			dr.EndEdit();
			personDS.Tables["BT_PERSON"].Rows.Add(dr);
			System.Data.OleDb.OleDbCommandBuilder oCB = new System.Data.OleDb.OleDbCommandBuilder(personDA);
			personDA.InsertCommand= oCB.GetInsertCommand();
			personDA.Update(personDS,"BT_PERSON");
			personDS.AcceptChanges();

		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Add a row to our Release table
		/// </summary>
		/// <param name="items"></param>
		////////////////////////////////////////////////////////////
		protected void AddRelease(ArrayList items, bool forceAdd)
		{
			DataRow dr;
			BTDataItem xdi;

			xdi = getDataItem("releaseOID",items);
			if (xdi != null)
			{
				dr = releaseDS.Tables["BT_RELEASE"].Rows.Find(xdi.getValue());
				if (dr != null && !forceAdd)
				{
					UpdateRelease(items);
					return;
				}
			}


			dr = releaseDS.Tables["BT_RELEASE"].NewRow();
			dr.BeginEdit();
			dr["releaseOID"] = props["RELEASEPFX"] + DateTime.Now.Ticks.ToString();
			foreach(BTDataItem di in items)
			{
				dr[di.getName()] = di.getValue();
			}
			dr.EndEdit();
			releaseDS.Tables["BT_RELEASE"].Rows.Add(dr);
			System.Data.OleDb.OleDbCommandBuilder oCB = new System.Data.OleDb.OleDbCommandBuilder(releaseDA);
			releaseDA.InsertCommand= oCB.GetInsertCommand();
			releaseDA.Update(releaseDS,"BT_RELEASE");
			releaseDS.AcceptChanges();

		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Add a row to our BUG table in the database
		/// </summary>
		/// <param name="items"></param>
		////////////////////////////////////////////////////////////
		protected void AddBug(ArrayList items, bool forceAdd)
		{
			DataRow dr;
			BTDataItem xdi;

			xdi = getDataItem("bugOID",items);
			if (xdi != null)
			{
				dr = bugDS.Tables["BT_BUG"].Rows.Find(xdi.getValue());
				if (dr != null && !forceAdd)
				{
					//
					// we don't allow updating a bug that exists
					//
					//ResolveBug(items,false);
					return;
				}
			}


			try
			{
				dr = bugDS.Tables["BT_BUG"].NewRow();
				dr.BeginEdit();

				foreach(BTDataItem di in items)
				{
					if (dr.Table.Columns[di.getName()].DataType.Name == "DateTime")
						dr[di.getName()] = DateTime.Parse(di.getValue());
					else
						dr[di.getName()] = di.getValue();
				}
				dr.EndEdit();
				bugDS.Tables["BT_BUG"].Rows.Add(dr);
				System.Data.OleDb.OleDbCommandBuilder oCB = new System.Data.OleDb.OleDbCommandBuilder(bugDA);
				bugDA.InsertCommand= oCB.GetInsertCommand();
				bugDA.Update(bugDS,"BT_BUG");
				bugDS.AcceptChanges();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Update a row in the BUG table
		/// </summary>
		/// <param name="items"></param>
		////////////////////////////////////////////////////////////
		protected void ResolveBug(ArrayList items)
		{
			DataRow dr;
			BTDataItem xdi;
			string bugOID;

			try
			{
				bugOID = "";
				xdi = getDataItem("bugOID",items);
				if (xdi != null)
					bugOID = xdi.getValue();

				if (bugOID == "")
				{
					AddBug(items,true);
					xdi = getDataItem("bugOID",items);
					if (xdi != null)
						bugOID = xdi.getValue();
					else
					{
						MessageBox.Show("Bad JUJU, couldn't add bug!");
						return;
					}
				}


				dr = bugDS.Tables["BT_BUG"].Rows.Find(bugOID);
				if (dr == null)
				{
					AddBug(items,true);
					return;
				}

				dr.BeginEdit();

				foreach(BTDataItem di in items)
				{
					if (dr.Table.Columns[di.getName()].DataType.Name == "DateTime")
						dr[di.getName()] = DateTime.Parse(di.getValue());
					else
						dr[di.getName()] = di.getValue();
				}
				dr.EndEdit();
				System.Data.OleDb.OleDbCommandBuilder oCB = new System.Data.OleDb.OleDbCommandBuilder(bugDA);
				bugDA.UpdateCommand= oCB.GetUpdateCommand();
				bugDA.Update(bugDS,"BT_BUG");
				bugDS.AcceptChanges();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Update a person in our database
		/// </summary>
		/// <param name="items"></param>
		////////////////////////////////////////////////////////////
		protected void UpdatePerson(ArrayList items)
		{
			DataRow dr;
			BTDataItem xdi;
			string personOID;

			try
			{
				personOID = "";
				xdi = getDataItem("personOID",items);
				if (xdi != null)
					personOID = xdi.getValue();

				if (personOID == "")
				{
					AddPerson(items, true);
					return;
				}

				dr = personDS.Tables["BT_PERSON"].Rows.Find(personOID);
				if (dr == null)
				{
					AddPerson(items,true);
					return;
				}

				dr.BeginEdit();

				foreach(BTDataItem di in items)
				{
					if (dr.Table.Columns[di.getName()].DataType.Name == "DateTime")
						dr[di.getName()] = DateTime.Parse(di.getValue());
					else
						dr[di.getName()] = di.getValue();
				}
				dr.EndEdit();
				System.Data.OleDb.OleDbCommandBuilder oCB = new System.Data.OleDb.OleDbCommandBuilder(personDA);
				personDA.UpdateCommand= oCB.GetUpdateCommand();
				personDA.Update(personDS,"BT_PERSON");
				personDS.AcceptChanges();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Add a row to our Release table
		/// </summary>
		/// <param name="items"></param>
		////////////////////////////////////////////////////////////
		protected void UpdateRelease(ArrayList items)
		{
			DataRow dr;
			BTDataItem xdi;
			string releaseOID;

			try
			{
				releaseOID = "";
				xdi = getDataItem("releaseOID",items);
				if (xdi != null)
					releaseOID = xdi.getValue();

				if (releaseOID == "")
				{
					AddRelease(items,true);
					return;
				}

				dr = releaseDS.Tables["BT_RELEASE"].Rows.Find(releaseOID);
				if (dr == null)
				{
					AddRelease(items,true);
					return;
				}

				dr.BeginEdit();

				foreach(BTDataItem di in items)
				{
					if (dr.Table.Columns[di.getName()].DataType.Name == "DateTime")
						dr[di.getName()] = DateTime.Parse(di.getValue());
					else
						dr[di.getName()] = di.getValue();
				}

				dr.EndEdit();
				System.Data.OleDb.OleDbCommandBuilder oCB = new System.Data.OleDb.OleDbCommandBuilder(releaseDA);
				releaseDA.UpdateCommand= oCB.GetUpdateCommand();
				releaseDA.Update(releaseDS,"BT_RELEASE");
				releaseDS.AcceptChanges();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Update a row in the BUG table
		/// </summary>
		/// <param name="items"></param>
		////////////////////////////////////////////////////////////
		protected void UpdateBugData(ArrayList items)
		{
			DataRow dr;
			BTDataItem xdi;
			string bugOID;

			try
			{
				bugOID = "";
				xdi = getDataItem("bugOID",items);
				if (xdi != null)
					bugOID = xdi.getValue();

				if (bugOID == "")
				{
					AddBug(items,true);
					xdi = getDataItem("bugOID",items);
					if (xdi != null)
						bugOID = xdi.getValue();
					else
					{
						MessageBox.Show("Error:  couldn't add bug!");
						return;
					}
				}


				dr = bugDS.Tables["BT_BUG"].Rows.Find(bugOID);
				if (dr == null)
				{
					AddBug(items,true);
					return;
				}

				dr.BeginEdit();

				foreach(BTDataItem di in items)
				{
					if (dr.Table.Columns[di.getName()].DataType.Name == "DateTime")
						dr[di.getName()] = DateTime.Parse(di.getValue());
					else
						dr[di.getName()] = di.getValue();
				}
				dr.EndEdit();
				System.Data.OleDb.OleDbCommandBuilder oCB = new System.Data.OleDb.OleDbCommandBuilder(bugDA);
				bugDA.UpdateCommand= oCB.GetUpdateCommand();
				bugDA.Update(bugDS,"BT_BUG");
				bugDS.AcceptChanges();
			}
			catch(Exception e)
			{
				Console.WriteLine(e.ToString());
			}
		}


		////////////////////////////////////////////////////////////
		/// <summary>
		/// Find a specifically named item in an BTDataItem list
		/// </summary>
		/// <param name="name"></param>
		/// <param name="items"></param>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		private BTDataItem getDataItem(string name, ArrayList items)
		{
			foreach(BTDataItem di in items)
			{
				if (di.getName() == name)
					return(di);
			}
			return(null);
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
