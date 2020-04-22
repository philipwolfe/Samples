using System;
using System.Collections;

namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// Reply received in response to an AGICommand.<br/>
	/// The AGIReply contains information about success or failure of the execution
	/// of an AGICommand and - depending on the command sent - additional information
	/// returned, for example the value of a variable requested by a
	/// GetVariableCommand.
	/// </summary>
	/// <seealso cref="FastAGI.Command.AGICommand"/>
	public interface IAGIReply
	{
		/// <summary>
		/// Get the first line of the raw reply.
		/// </summary>
		string FirstLine
		{
			get;
		}
		/// <summary>
		/// Get a List containing the lines of the raw reply.
		/// </summary>
		IList Lines
		{
			get;
		}

		/// <summary>
		/// Returns the return code (the result as int).
		/// </summary>
		/// <returns>the return code or -1 if the result is not an int.</returns>
		int ResultCode
		{
			get;
		}

		/// <summary>
		/// Returns the return code as character.
		/// </summary>
		/// <returns>the return code as character.</returns>
		char ResultCodeAsChar
		{
			get;
		}

		/// <summary>
		/// Returns the text in parenthesis contained in this reply.<br/>
		/// The meaning of this property depends on the command sent. Sometimes it
		/// contains a flag like "timeout" or "hangup" or - in case of the
		/// GetVariableCommand - the value of the variable.
		/// </summary>
		/// <returns>the text in the parenthesis or <code>null</code> if not set.</returns>
		string Extra
		{
			get;
		}
		
		/// <summary>
		/// Returns the result, that is the part directly following the "result=" string.
		/// </summary>
		/// <returns>the result.</returns>
		string GetResult();

		/// <summary>
		/// Returns the status code.<br/>
		/// Supported status codes are:
		/// <ul>
		/// <li>200 Success
		/// <li>510 Invalid or unknown command
		/// <li>520 Invalid command syntax
		/// </ul>
		/// </summary>
		/// <returns>the status code.</returns>
		int GetStatus();

		/// <summary>
		/// Returns an additional attribute contained in the reply.<br/>
		/// For example the reply to the StreamFileCommand contains an additional
		/// endpos attribute indicating the frame where the playback was stopped.
		/// This can be retrieved by calling getAttribute("endpos") on the
		/// corresponding reply.
		/// </summary>
		/// <param name="name">the name of the attribute to retrieve. The name is case insensitive.</param>
		/// <returns> the value of the attribute or <code>null</code> if it is not set.</returns>
		string GetAttribute(string name);
		
		/// <summary>
		/// Returns the synopsis of the command sent if Asterisk expected a different
		/// syntax (getStatus() == SC_INVALID_COMMAND_SYNTAX).
		/// </summary>
		/// <returns>the synopsis of the command sent, <code>null</code> if there were no syntax errors.</returns>
		string GetSynopsis();
		
		/// <summary>
		/// Returns the usage of the command sent if Asterisk expected a different
		/// syntax (getStatus() == SC_INVALID_COMMAND_SYNTAX).
		/// </summary>
		/// <returns>the usage of the command sent, <code>null</code> if there were no syntax errors.</returns>
		string GetUsage();
	}
}