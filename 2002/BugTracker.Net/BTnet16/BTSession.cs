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
using NZlib.GZip;

namespace com.mikelehman.bugtracker
{
	////////////////////////////////////////////////////////////
	/// <summary>
	/// BTSession manages accumulating XML transactions
	/// and writing them to a .MLBT file
	/// 
	/// An .MLBT file can be sent by e-mail to another MLBT
	/// user and opened to synchronize two MLBT databases.
	/// In this way, multiple users can share the same
	/// "virtual" bugbase
	/// </summary>
	////////////////////////////////////////////////////////////
	public class BTSession
	{
		protected StreamWriter mlbtFile;
		protected ArrayList transactions;
		protected ArrayList updates;
		private const string TRANSACTION_SEPARATOR = "#$%^&*TRANSACTION";
		private const string FILE_OPEN_MARKER = "MLBT version=\"2.0\"";
		private const string FILE_END_MARKER = "/MLBT version=\"2.0\"";
		private const string TRANSACTION_TYPE_MARKER = "TRANSACTION-TYPE";
		private const string TRANSACTION_DATA_MARKER = "TRANSACTION-DATA";

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Constructor for a BTSession
		/// Allocates update and transaction ArrayLists
		/// </summary>
		////////////////////////////////////////////////////////////
		public BTSession()
		{
			updates = new ArrayList();
			transactions = new ArrayList();
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Return number of transactions recorded in this session
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public int getTransactionCount()
		{
			return(transactions.Count);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Add a new transaction to this session
		/// </summary>
		/// <param name="trans"></param>
		////////////////////////////////////////////////////////////
		public void addTransaction(BTTransaction trans)
		{
			transactions.Add(trans);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Add an "update" transaction to this session.
		/// We always record update transactions for all "people" and
		/// "release" records since they are very small and every
		/// "bug" record requires one and if you get cross-sent
		/// .mlbt files you might miss one.
		/// </summary>
		/// <param name="trans"></param>
		////////////////////////////////////////////////////////////
		public void addUpdate(BTTransaction trans)
		{
			updates.Add(trans);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Write the transactions to a .mlbt file.
		/// A .mlbt file is a collection of XML data objects
		/// which is then zipped and Base64 encoded for small
		/// transmission size.
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public bool saveTransactions()
		{
			DateTime now;
			string transString;
			string zipString;
			now = DateTime.Now;

			try
			{
				mlbtFile = new StreamWriter(
					fixName(BTnetMain.getOwnerName()) + "-" + 
					(now.Month < 10 ? "0":"") + now.Month.ToString() + 
					(now.Day < 10 ? "0":"") + now.Day.ToString() + 
					(now.Year < 10 ? "0":"") + now.Year.ToString() + "_" +
					(now.Hour < 10 ? "0":"") + now.Hour.ToString() + 
					(now.Minute < 10 ? "0":"") + now.Minute.ToString() +
					(now.Second< 10 ? "0":"") + now.Second.ToString() + ".mlbt");

				transString = "";

				transString += FILE_OPEN_MARKER + "\n";

				foreach(BTTransaction trans in updates)
				{
					transString += TRANSACTION_TYPE_MARKER + "\n";
					transString += trans.getType() + "\n";
					transString += TRANSACTION_DATA_MARKER + "\n";
					transString += trans.getXML() + "\n";
					transString += TRANSACTION_SEPARATOR + "\n";
				}

				foreach(BTTransaction trans in transactions)
				{
					transString += TRANSACTION_TYPE_MARKER + "\n";
					transString += trans.getType() + "\n";
					transString += TRANSACTION_DATA_MARKER + "\n";
					transString += trans.getXML() + "\n";
					transString += TRANSACTION_SEPARATOR + "\n";
				}
				transString += FILE_END_MARKER + "\n";
				zipString = generateBase64ZippedString(transString);
				mlbtFile.Write(zipString);
				mlbtFile.Close();

				
				return(true);
			}
			catch(Exception e)
			{
				MessageBox.Show("EXCEPTION WHILE SAVING: " + "\r\n" + e.StackTrace);
				return(false);
			}
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Close the session (i.e. save the transactions if
		/// there are any stored)
		/// </summary>
		////////////////////////////////////////////////////////////
		public void close()
		{
			if (transactions.Count > 0)
				saveTransactions();
		}


		////////////////////////////////////////////////////////////
		/// <summary>
		/// Read a .mlbt file into memory, unzip it and
		/// execute the transaction therein
		/// </summary>
		/// <param name="fileName"></param>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public bool loadMLBTfile(string fileName,BTProcessing btp)
		{
			string xmlString;
			StreamReader docReader;
			string[] lines;
			int i;
			string line;
			string transType;
			string transData;
			bool headerSeen;
			int lastLine;
			int transactionCount;

			try
			{
				docReader = new StreamReader(fileName);
				xmlString = docReader.ReadToEnd();
				xmlString = getRawStringFromBase64ZippedString(xmlString,1000000);
				docReader.Close();
			}
			catch(Exception e)
			{
				MessageBox.Show("EXCEPTION WHILE LOADING: " + "\r\n" + e.StackTrace);
				return(false);
			}


			transactionCount = 0;
			lines = xmlString.Split('\n');
			i = 0;
			lastLine = -1;
			transType = "";
			headerSeen = false;
			while(i < lines.Length)
			{
				if (i == lastLine)
					break;

				line = lines[i];
				lastLine = i;
				if (line.StartsWith(FILE_OPEN_MARKER))
				{
					//Console.WriteLine("FILE OPEN MARKER FOUND");
					headerSeen = true;
					i++;
					continue;
				}

				if (line.StartsWith(FILE_END_MARKER) && headerSeen)
				{
					//Console.WriteLine("FILE END MARKER FOUND");
					return(true);
				}

				if (line.StartsWith(TRANSACTION_TYPE_MARKER) && headerSeen)
				{
					transType = lines[++i];
					i++;
					continue;
				}

				if (line.StartsWith(TRANSACTION_DATA_MARKER) && headerSeen)
				{
					i++;
					transData = "";
					while(!lines[i].StartsWith(TRANSACTION_SEPARATOR))
					{
						transData += lines[i++] + "\n";
					}
					i++;
					btp.setStatus("Transaction: "+transactionCount.ToString() + " : " + transType);
					transactionCount++;
					Application.DoEvents();
					//Console.WriteLine("Executing transaction: " + transType + " with data: " + "\n" + transData);
					BTExec.getSingleton().exec(transType,transData,false);
					continue;
				}
			}
			return(true);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Take in a string, zip it and return the Base64 encoding
		/// of the zipped data
		/// </summary>
		/// <param name="input"></param>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		string generateBase64ZippedString(string input)
		{
			System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
			MemoryStream ms;
			Stream s;
			byte[] buffer;
			byte[] buffer2;
			string result;

			ms = new MemoryStream();
			s = new GZipOutputStream(ms);
			buffer = enc.GetBytes(input);
			s.Write(buffer,0,buffer.Length);
			s.Flush();
			s.Close();
			ms.Flush();
			ms.Close();

			buffer2 = ms.ToArray();

			result = System.Convert.ToBase64String(buffer2);
			return(result);
		}

		///////////////////////////////////////////////////////////
		/// <summary>
		/// Convert a string in base64 characters that has been
		/// "zipped" back into it's original "whole" self
		/// </summary>
		/// <param name="input">base64 string representing zip stream</param>
		/// <param name="size">length of ORIGINAL string</param>
		/// <returns>original string</returns>
		///////////////////////////////////////////////////////////
		string getRawStringFromBase64ZippedString(string input, int size)
		{
			System.Text.UTF8Encoding enc = new System.Text.UTF8Encoding();
			byte[] buffer;
			MemoryStream ms;
			byte[] buffer2;
			Stream s;
			string result;
			int offset;
			int readResult;

			buffer = System.Convert.FromBase64String(input);
	
			ms = new MemoryStream(buffer);
			s = new GZipInputStream(ms);
		   
			buffer2 = new byte[size];

			offset = 0;
			readResult = 0;
			while(readResult >= 0)
			{
				readResult = s.Read(buffer2,offset,size);
				if (readResult > 0)
					offset += readResult;
			}
			s.Close();
			ms.Close();

			result = enc.GetString(buffer2);
			return(result);
		}

		///////////////////////////////////////////////////////////
		/// <summary>
		/// Turn any special characters or blanks into "-"
		/// so we can use it as a file name
		/// </summary>
		/// <param name="name"></param>
		/// <returns></returns>
		///////////////////////////////////////////////////////////
		private string fixName(string name)
		{
			string result;

			result = "";
			foreach (char ch in name)
			{
				if (char.IsLetterOrDigit(ch))
					result = result + ch;
				else if (ch == ' ')
					result = result + "_";
				else
					result = result + "-";
			}
			return (result);
		}			
	}
}
