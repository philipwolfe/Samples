using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;

namespace Asterisk.NET.FastAGI
{
	#region AGIReplyStatuses
	public enum AGIReplyStatuses
	{
		/// <summary>
		/// Status code (200) indicating Asterisk successfully processed the AGICommand.
		/// </summary>
		SC_SUCCESS = 200,
		/// <summary>
		/// Status code (510) indicating Asterisk was unable to process the
		/// AGICommand because there is no command with the given name available.
		/// </summary>
		SC_INVALID_OR_UNKNOWN_COMMAND = 510,
		/// <summary>
		/// Status code (520) indicating Asterisk was unable to process the
		/// AGICommand because the syntax used was not correct. This is most likely
		/// due to missing required parameters or additional parameters sent that are
		/// not understood.<br/>
		/// Ensure proper quoting of the parameters when you receive this status
		/// code.
		/// </summary>
		SC_INVALID_COMMAND_SYNTAX = 520
	}
	#endregion

	/// <summary>
	/// Default implementation of the AGIReply interface.
	/// </summary>
	public class AGIReply : IAGIReply
	{
		#region Constants
		private static Regex STATUS_PATTERN = new Regex("^(\\d{3})[ -]");
		private static Regex RESULT_PATTERN = new Regex("^200 result= *(\\S+)");
		private static Regex PARENTHESIS_PATTERN = new Regex("^200 result=\\S* +\\((.*)\\)");
		private static Regex ADDITIONAL_ATTRIBUTES_PATTERN = new Regex("^200 result=\\S* +(\\(.*\\) )?(.+)$");
		private static Regex ADDITIONAL_ATTRIBUTE_PATTERN = new Regex("(\\S+)=(\\S+)");
		private static Regex SYNOPSIS_PATTERN = new Regex("^\\s*Usage:\\s*(.*)\\s*$");
		private const string END_OF_PROPER_USAGE = "520 End of proper usage.";
		#endregion
		#region Variables
		private Match matcher;
		private IList lines;
		private string firstLine;
		/// <summary> The result, that is the part directly following the "result=" string.</summary>
		private string result;
		/// <summary> The status code.</summary>
		private int status;
		/// <summary>Additional attributes contained in this reply, for example endpos.</summary>
		private IDictionary attributes;
		/// <summary> The contents of the parenthesis.</summary>
		private string extra;
		/// <summary> In case of status == 520 (invalid command syntax) this attribute contains the synopsis of the command.</summary>
		private string synopsis;
		/// <summary> In case of status == 520 (invalid command syntax) this attribute contains the usage of the command.</summary>
		private string usage;
		private bool extraCreated;
		private bool synopsisCreated;
		private bool attributesCreated;
		private bool resultCreated;
		private bool statusCreated;
		#endregion

		#region Constructor - AGIReply()
		public AGIReply()
		{
		}
		#endregion
		#region Constructor - AGIReply(lines)
		public AGIReply(IList lines)
		{
			this.lines = lines;
			try
			{
				firstLine = ((string)lines[0]);
			}
			catch {}
		}
		#endregion

		#region FirstLine
		virtual public string FirstLine
		{
			get { return firstLine; }
		}
		#endregion
		#region Lines
		virtual public IList Lines
		{
			get { return lines; }
		}
		#endregion
		#region ResultCode
		/// <summary>
		/// Returns the return code (the result as int).
		/// </summary>
		/// <returns>the return code or -1 if the result is not an int.</returns>
		virtual public int ResultCode
		{
			get
			{
				string result;
				result = GetResult();
				if (result == null)
					return -1;
				try
				{
					return Int32.Parse(result);
				}
				catch
				{
					return -1;
				}
			}
		}
		#endregion
		#region ResultCodeAsChar
		/// <summary>
		/// Returns the return code as character.
		/// </summary>
		/// <returns>the return code as character.</returns>
		virtual public char ResultCodeAsChar
		{
			get
			{
				int resultCode;
				resultCode = ResultCode;
				if (resultCode < 0)
					return (char)(0x0);
				return (char)resultCode;
			}
		}
		#endregion
		#region Extra
		/// <summary>
		/// Returns the text in parenthesis contained in this reply.<br/>
		/// The meaning of this property depends on the command sent. Sometimes it
		/// contains a flag like "timeout" or "hangup" or - in case of the
		/// GetVariableCommand - the value of the variable.
		/// </summary>
		/// <returns>the text in the parenthesis or <code>null</code> if not set.</returns>
		virtual public string Extra
		{
			get
			{
				if (GetStatus() != (int)AGIReplyStatuses.SC_SUCCESS)
					return null;

				if (extraCreated)
					return extra;

				matcher = PARENTHESIS_PATTERN.Match(firstLine);
				if (matcher.Success)
					extra = matcher.Groups[1].Value;

				extraCreated = true;
				return extra;
			}
		}
		#endregion

		#region GetResult()
		/// <summary>
		/// Returns the result, that is the part directly following the "result=" string.
		/// </summary>
		/// <returns>the result.</returns>
		public virtual string GetResult()
		{
			if (resultCreated)
				return result;

			matcher = RESULT_PATTERN.Match(firstLine);
			if (matcher.Success)
				result = matcher.Groups[1].Value;

			resultCreated = true;
			return result;
		}
		#endregion
		#region GetStatus()
		/// <summary>
		/// Returns the status code.<br/>
		/// Supported status codes are:<br/>
		/// 200 Success<br/>
		/// 510 Invalid or unknown command<br/>
		/// 520 Invalid command syntax<br/>
		/// </summary>
		/// <returns>the status code.</returns>
		public virtual int GetStatus()
		{
			if (statusCreated)
				return status;

			matcher = STATUS_PATTERN.Match(firstLine);
			if (matcher.Success)
			{
				status = Int32.Parse(matcher.Groups[1].Value);
			}
			statusCreated = true;
			return status;
		}
		#endregion
		#region GetAttribute(name)
		/// <summary>
		/// Returns an additional attribute contained in the reply.<br/>
		/// For example the reply to the StreamFileCommand contains an additional
		/// endpos attribute indicating the frame where the playback was stopped.
		/// This can be retrieved by calling getAttribute("endpos") on the corresponding reply.
		/// </summary>
		/// <param name="name">the name of the attribute to retrieve. The name is case insensitive.</param>
		/// <returns>the value of the attribute or <code>null</code> if it is not set.</returns>
		public virtual string GetAttribute(string name)
		{
			if (GetStatus() != (int)AGIReplyStatuses.SC_SUCCESS)
				return null;

			if ("result".ToUpper().Equals(name.ToUpper()))
				return GetResult();

			if (!attributesCreated)
			{
				matcher = ADDITIONAL_ATTRIBUTES_PATTERN.Match(firstLine);
				if (matcher.Success)
				{
					string s;
					Match attributeMatcher;

					attributes = new Hashtable();
					s = matcher.Groups[2].Value;
					attributeMatcher = ADDITIONAL_ATTRIBUTE_PATTERN.Match(s);
					while (attributeMatcher.Success)
					{
						string key;
						string value_Renamed;

						key = attributeMatcher.Groups[1].Value;
						value_Renamed = attributeMatcher.Groups[2].Value;
						attributes[key.ToLower()] = value_Renamed;
					}
				}
				attributesCreated = true;
			}

			if (attributes == null || (attributes.Count == 0))
				return null;

			return (string)attributes[name.ToLower()];
		}
		#endregion
		#region GetSynopsis()
		/// <summary>
		/// Returns the synopsis of the command sent if Asterisk expected a different
		/// syntax (getStatus() == SC_INVALID_COMMAND_SYNTAX).
		/// </summary>
		/// <returns>the synopsis of the command sent, <code>null</code> if there were no syntax errors.</returns>
		public virtual string GetSynopsis()
		{
			if (GetStatus() != (int)AGIReplyStatuses.SC_INVALID_COMMAND_SYNTAX)
				return null;

			if (!synopsisCreated)
			{
				if (lines.Count > 1)
				{
					string secondLine;
					Match synopsisMatcher;

					secondLine = ((string)lines[1]);
					synopsisMatcher = SYNOPSIS_PATTERN.Match(secondLine);
					if (synopsisMatcher.Success)
						synopsis = synopsisMatcher.Groups[1].Value;
				}
				synopsisCreated = true;

				StringBuilder sbUsage = new StringBuilder();
				string line;
				for (int i = 2; i < lines.Count; i++)
				{
					line = ((string)lines[i]);
					if (line == END_OF_PROPER_USAGE)
						break;
					sbUsage.Append(line.Trim());
					sbUsage.Append(" ");
				}
				usage = sbUsage.ToString().Trim();
			}
			return synopsis;
		}
		#endregion
		#region GetUsage()
		/// <summary>
		/// Returns the usage of the command sent if Asterisk expected a different
		/// syntax (getStatus() == SC_INVALID_COMMAND_SYNTAX).
		/// </summary>
		/// <returns>
		/// the usage of the command sent,
		/// <code>null</code> if there were no syntax errors.
		/// </returns>
		public virtual string GetUsage()
		{
			return usage;
		}
		#endregion

		#region ToString()
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(GetType().FullName);
			sb.Append(": status='" + GetStatus() + "'");
			if (status == (int)AGIReplyStatuses.SC_SUCCESS)
			{
				sb.Append("; result='" + GetResult());
				sb.Append("'; extra='" + Extra);
				sb.Append("'; attributes=" + Utils.CollectionToString(attributes));
			}
			else if (status == (int)AGIReplyStatuses.SC_INVALID_COMMAND_SYNTAX)
				sb.Append("; synopsis='" + GetSynopsis() + "'");
			sb.Append("; systemHashcode=" + this.GetHashCode());
			return sb.ToString();
		}
		#endregion
	}
}
