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
using System.Data;

namespace com.mikelehman.bugtracker
{
	////////////////////////////////////////////////////////////
	/// <summary>
	/// Simple report class that generates an HTML report
	/// of bugs for a given release (or all releases).
	/// It returns the report as a string.  Most clients
	/// simply save that to a file and start it to launch
	/// the "default" browser.
	/// </summary>
	////////////////////////////////////////////////////////////
	public class BTBugReport
	{
		protected static string report;		// HTML string
		protected DataTable releases;		// one or more DataRows defining a release
		protected DataRow release;			// the release we're workingo n
		protected DataRow user;				// so we can get the user's name for the report
		string releaseOID;

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Initialize HTML report
		/// </summary>
		////////////////////////////////////////////////////////////
		public BTBugReport(DataTable releases, DataRow user, string releaseOID)
		{
			this.releases = releases;
			this.user = user;
			this.releaseOID = releaseOID;
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Generate the whole bug report as an HTML string
		/// </summary>
		/// <returns></returns>
		////////////////////////////////////////////////////////////
		public string getReport()
		{	
			DataRow dr;

			report = "";
			generateHeader();
			
			dr = releases.Rows.Find(releaseOID);

			if(dr != null)
			{
				generateReleaseReport(dr);
			}

			generateFooter();
			return(report);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Generate report header
		/// </summary>
		////////////////////////////////////////////////////////////
		protected void generateHeader()
		{
			report = "";
			writeTag("HTML");
			writeTag("BODY");
			writeTag("H2");
			writeTag("FONT color=#FF0000");
			write("Mike Lehman's BugTracker.net " + Version.number);
			writeTag("BR");
			writeTag("FONT color=#000000");
			writeTag("H3");
			if (user != null && user["name"] != null)
			{
				write("Bug report for: " + user["name"]+ " on "+DateTime.Now.ToString());
			}
			else
			{
				write("Bug report on "+DateTime.Now.ToString());
			}

			writeTag("BR");
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Generate report footer
		/// </summary>
		////////////////////////////////////////////////////////////
		protected void generateFooter()
		{
			writeTag("BR");
			writeTag("HR");
			writeTag("CENTER");
			writeTag("FONT color=#ff0000 size=small");
			write("Report prepared by Mike Lehman's BugTracker.net " + Version.number);
			writeTag("/BODY");
			writeTag("/HTML");
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Generate report sections for one release
		/// </summary>
		/// <param name="release"></param>
		////////////////////////////////////////////////////////////
		protected void generateReleaseReport(DataRow release)
		{
			this.release = release;

			if (BTReportOptions.getDoOpenBugs())
				this.generateFilteredBugReport("OPEN");

			if (BTReportOptions.getDoOKBugs())
				this.generateFilteredBugReport("OK2FIX");

			if (BTReportOptions.getDoLaterBugs())
				this.generateFilteredBugReport("LATER");

			if (BTReportOptions.getDoIgnoreBugs())
				this.generateFilteredBugReport("IGNORE");

			if (BTReportOptions.getDoClosedBugs())
				this.generateFilteredBugReport("CLOSED");


		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Generate a table with bugs for a given status
		/// in the current release
		/// </summary>
		/// <param name="bugStatus"></param>
		////////////////////////////////////////////////////////////
		private void generateFilteredBugReport(string bugStatus)
		{
			DataTable bugs;
			int bugCount;

			bugCount = 0;

			write(bugStatus+" Bugs:");
			writeTag("BR");
			writeTag("HR");

			writeTag("BOLD"); 
			write("Release:  ");
			writeTag("/BOLD");
			write((string)release["description"]); 

			writeTag("TABLE border=\"2\" cellpadding=\"3\" cellspacing=\"3\" Align=\"center\" width=\"80%\"");
			
			writeTag("TR");
			writeTag("TH"); write("  Priority  "); writeTag("/TH");
			writeTag("TH"); write("  Severity  "); writeTag("/TH");
			writeTag("TH"); write("  Status  "); writeTag("/TH");
			writeTag("TH"); write("Description"); writeTag("/TH");
			writeTag("/TR");

			bugs = BTnetMain.getInstance().getBugTableFromRelease((string)release["releaseOID"]);
			foreach(DataRow bug in bugs.Rows)
			{
				if (((string)bug["status"]) == bugStatus)
				{
					writeTag("TR");
					writeTag("TD"); write(bug["priority"]); writeTag("/TD");
					writeTag("TD"); write(bug["severity"]); writeTag("/TD");
					writeTag("TD"); write(bug["status"]); writeTag("/TD");
					writeTag("TD"); write(processDescription((string)bug["description"])); 
					if (bugStatus == "CLOSED")
					{
						writeTag("BR");
						writeTag("HR");
						write("<FONT color=#0000FF");
						write("Resolution: ");
						writeTag("BR");
						write(processDescription((string)bug["resolution"]));
						write("</FONT>");
					}
					writeTag("/TD");
					writeTag("/TR");
					bugCount++;
				}
			}
			writeTag("BR");
			writeTag("/TABLE");
			writeTag("BOLD"); write(bugCount.ToString()+ " " + bugStatus + " bugs"); writeTag("/BOLD"); writeTag("BR");
			writeTag("HR");

		}

		/// <summary>
		/// Format a bug description so that
		/// the newlines are converted to < BR > and
		/// the whole thing is wordwrapped at 120 chars/line
		/// </summary>
		/// <param name="desc"></param>
		/// <returns></returns>
		private string processDescription(string desc)
		{
			string results;
			int col;

			results = "<FONT size=2>";
			col = 1;

			foreach(char ch in desc)
			{
				if (ch == '\n')
				{
					col = 1;
					results += "<BR>";
				}
				else
				{
					col++;
					if (col > 120)
					{
						results += ch;
						results += "<BR>";
						col=1;
					}
					else
						results += ch;
				}
			}

			results += "</FONT>";
			return(results);
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Utility method for "writing" to the HTML string
		/// </summary>
		/// <param name="s"></param>
		////////////////////////////////////////////////////////////
		protected void write(Object s)
		{
			if (s == System.DBNull.Value)
				return;

			report += s + "\n";
		}

		////////////////////////////////////////////////////////////
		/// <summary>
		/// Utility method for writing a Tag to the HTML string
		/// </summary>
		/// <param name="s"></param>
		////////////////////////////////////////////////////////////
		protected void writeTag(string s)
		{
			report += "<" + s + ">\n";
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
