using System;

namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// The BaseAGIScript provides some convinience methods to make it easier to
	/// write custom AGIScripts.<br/>
	/// Just extend it by your own AGIScripts.
	/// </summary>
	public abstract class BaseAGIScript : IAGIScript
	{
		#region Answer()
		/// <summary>
		/// Answers the channel.
		/// </summary>
		protected internal virtual void Answer()
		{
			this.Channel.Answer();
		}
		#endregion
		#region Hangup()
		/// <summary>
		/// Hangs the channel up.
		/// </summary>
		protected internal virtual void Hangup()
		{
			this.Channel.Hangup();
		}
		#endregion
		#region AutoHangup
		/// <summary>
		/// Cause the channel to automatically hangup at the given number of seconds in the future.<br/>
		/// 0 disables the autohangup feature.
		/// </summary>
		virtual protected internal void SetAutoHangup(int time)
		{
			this.Channel.SetAutoHangup(time);
		}
		#endregion
		#region SetCallerId
		/// <summary>
		/// Sets the caller id on the current channel.<br/>
		/// The raw caller id to set, for example "John Doe<1234>".
		/// </summary>
		virtual protected internal void SetCallerId(string callerId)
		{
			this.Channel.SetCallerId(callerId);
		}
		#endregion
		#region PlayMusicOnHold()
		/// <summary>
		/// Plays music on hold from the default music on hold class.
		/// </summary>
		protected internal virtual void PlayMusicOnHold()
		{
			this.Channel.PlayMusicOnHold();
		}
		#endregion
		#region PlayMusicOnHold(string musicOnHoldClass)
		/// <summary>
		/// Plays music on hold from the given music on hold class.
		/// </summary>
		/// <param name="musicOnHoldClass">the music on hold class to play music from as configures in Asterisk's <code><musiconhold.conf/code>.</param>
		protected internal virtual void PlayMusicOnHold(string musicOnHoldClass)
		{
			this.Channel.PlayMusicOnHold(musicOnHoldClass);
		}
		#endregion
		#region StopMusicOnHold()
		/// <summary>
		/// Stops playing music on hold.
		/// </summary>
		protected internal virtual void StopMusicOnHold()
		{
			this.Channel.StopMusicOnHold();
		}
		#endregion
		#region GetChannelStatus
		/// <summary>
		/// Returns the status of the channel.<br/>
		/// Return values:
		/// <ul>
		/// <li>0 Channel is down and available
		/// <li>1 Channel is down, but reserved
		/// <li>2 Channel is off hook
		/// <li>3 Digits (or equivalent) have been dialed
		/// <li>4 Line is ringing
		/// <li>5 Remote end is ringing
		/// <li>6 Line is up
		/// <li>7 Line is busy
		/// </ul>
		/// 
		/// </summary>
		/// <returns> the status of the channel.
		/// </returns>
		virtual protected internal int GetChannelStatus()
		{
			return this.Channel.GetChannelStatus();
		}
		#endregion
		#region GetData(string file)
		/// <summary>
		/// Plays the given file and waits for the user to enter DTMF digits until he
		/// presses '#'. The user may interrupt the streaming by starting to enter
		/// digits.
		/// </summary>
		/// <param name="file">the name of the file to play</param>
		/// <returns> a String containing the DTMF the user entered</returns>
		protected internal virtual string GetData(string file)
		{
			return this.Channel.GetData(file);
		}
		#endregion
		#region GetData(string file, int timeout)
		/// <summary>
		/// Plays the given file and waits for the user to enter DTMF digits until he
		/// presses '#' or the timeout occurs. The user may interrupt the streaming
		/// by starting to enter digits.
		/// </summary>
		/// <param name="file">the name of the file to play</param>
		/// <param name="timeout">the timeout to wait for user input.<br/>
		/// 0 means standard timeout value, -1 means "ludicrous time"
		/// (essentially never times out).</param>
		/// <returns> a String containing the DTMF the user entered</returns>
		protected internal virtual string GetData(string file, int timeout)
		{
			return this.Channel.GetData(file, timeout);
		}
		#endregion
		#region GetData(string file, int timeout, int maxDigits)
		/// <summary>
		/// Plays the given file and waits for the user to enter DTMF digits until he
		/// presses '#' or the timeout occurs or the maximum number of digits has
		/// been entered. The user may interrupt the streaming by starting to enter
		/// digits.
		/// </summary>
		/// <param name="file">the name of the file to play</param>
		/// <param name="timeout">the timeout to wait for user input.<br/>
		/// 0 means standard timeout value, -1 means "ludicrous time"
		/// (essentially never times out).</param>
		/// <param name="maxDigits">the maximum number of digits the user is allowed to enter</param>
		/// <returns> a String containing the DTMF the user entered</returns>
		protected internal virtual string GetData(string file, int timeout, int maxDigits)
		{
			return this.Channel.GetData(file, timeout, maxDigits);
		}
		#endregion
		#region GetOption(string file, string escapeDigits)
		/// <summary>
		/// Plays the given file, and waits for the user to press one of the given
		/// digits. If none of the esacpe digits is pressed while streaming the file
		/// it waits for the default timeout of 5 seconds still waiting for the user
		/// to press a digit.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="escapeDigits">contains the digits that the user is expected to press.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal virtual char GetOption(string file, string escapeDigits)
		{
			return this.Channel.GetOption(file, escapeDigits);
		}
		#endregion
		#region GetOption(string file, string escapeDigits, int timeout)
		/// <summary>
		/// Plays the given file, and waits for the user to press one of the given
		/// digits. If none of the esacpe digits is pressed while streaming the file
		/// it waits for the specified timeout still waiting for the user to press a
		/// digit.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="escapeDigits">contains the digits that the user is expected to press.</param>
		/// <param name="timeout">the timeout in seconds to wait if none of the defined esacpe digits was presses while streaming.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal virtual char GetOption(string file, string escapeDigits, int timeout)
		{
			return this.Channel.GetOption(file, escapeDigits, timeout);
		}
		#endregion
		#region Exec(string application)
		/// <summary>
		/// Executes the given command.
		/// </summary>
		/// <param name="application">the name of the application to execute, for example "Dial".</param>
		/// <returns> the return code of the application of -2 if the application was not found.</returns>
		protected internal virtual int Exec(string application)
		{
			return this.Channel.Exec(application);
		}
		#endregion
		#region Exec(string application, string options)
		/// <summary>
		/// Executes the given command.
		/// </summary>
		/// <param name="application">the name of the application to execute, for example "Dial".</param>
		/// <param name="options">the parameters to pass to the application, for example "SIP/123".</param>
		/// <returns> the return code of the application of -2 if the application was not found.</returns>
		protected internal virtual int Exec(string application, string options)
		{
			return this.Channel.Exec(application, options);
		}
		#endregion
		#region SetContext
		/// <summary>
		/// Sets the context for continuation upon exiting the application.
		/// </summary>
		virtual protected internal void SetContext(string context)
		{
			this.Channel.SetContext(context);
		}
		#endregion
		#region SetExtension
		/// <summary>
		/// Sets the extension for continuation upon exiting the application.
		/// </summary>
		virtual protected internal void SetExtension(string extension)
		{
			this.Channel.SetExtension(extension);
		}
		#endregion
		#region SetPriority
		/// <summary>
		/// Sets the priority for continuation upon exiting the application.
		/// </summary>
		virtual protected internal void SetPriority(int priority)
		{
			this.Channel.SetPriority(priority);
		}
		#endregion
		#region StreamFile(string file)
		/// <summary>
		/// Plays the given file.
		/// </summary>
		/// <param name="file">name of the file to play.</param>
		protected internal virtual void StreamFile(string file)
		{
			this.Channel.StreamFile(file);
		}
		#endregion
		#region StreamFile(string file, string escapeDigits)
		/// <summary>
		/// Plays the given file and allows the user to escape by pressing one of the given digit.
		/// </summary>
		/// <param name="file">name of the file to play.</param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal virtual char StreamFile(string file, string escapeDigits)
		{
			return this.Channel.StreamFile(file, escapeDigits);
		}
		#endregion
		#region SayDigits(string digits)
		/// <summary>
		/// Says the given digit string.
		/// </summary>
		/// <param name="digits">the digit string to say.</param>
		protected internal virtual void SayDigits(string digits)
		{
			this.Channel.SayDigits(digits);
		}
		#endregion
		#region SayDigits(string digits, string escapeDigits)
		/// <summary>
		/// Says the given number, returning early if any of the given DTMF number
		/// are received on the channel.
		/// </summary>
		/// <param name="digits">the digit string to say.</param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal virtual char SayDigits(string digits, string escapeDigits)
		{
			return this.Channel.SayDigits(digits, escapeDigits);
		}
		#endregion
		#region SayNumber(string number)
		/// <summary>
		/// Says the given number.
		/// </summary>
		/// <param name="number">the number to say.</param>
		protected internal virtual void SayNumber(string number)
		{
			this.Channel.SayNumber(number);
		}
		#endregion
		#region SayNumber(string number, string escapeDigits)
		/// <summary>
		/// Says the given number, returning early if any of the given DTMF number
		/// are received on the channel.
		/// </summary>
		/// <param name="number">the number to say.</param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal virtual char SayNumber(string number, string escapeDigits)
		{
			return this.Channel.SayNumber(number, escapeDigits);
		}
		#endregion
		#region SayPhonetic(string text)
		/// <summary>
		/// Says the given character string with phonetics.
		/// </summary>
		/// <param name="text">the text to say.</param>
		protected internal virtual void SayPhonetic(string text)
		{
			this.Channel.SayPhonetic(text);
		}
		#endregion
		#region SayPhonetic(string text, string escapeDigits)
		/// <summary>
		/// Says the given character string with phonetics, returning early if any of
		/// the given DTMF number are received on the channel.
		/// </summary>
		/// <param name="text">the text to say.</param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal virtual char SayPhonetic(string text, string escapeDigits)
		{
			return this.Channel.SayPhonetic(text, escapeDigits);
		}
		#endregion
		#region SayAlpha(string text)
		/// <summary>
		/// Says the given character string.
		/// </summary>
		/// <param name="text">the text to say.</param>
		protected internal virtual void  SayAlpha(string text)
		{
			this.Channel.SayAlpha(text);
		}
		#endregion
		#region SayAlpha(string text, string escapeDigits)
		/// <summary>
		/// Says the given character string, returning early if any of the given DTMF
		/// number are received on the channel.
		/// </summary>
		/// <param name="text">the text to say.</param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal virtual char SayAlpha(string text, string escapeDigits)
		{
			return this.Channel.SayAlpha(text, escapeDigits);
		}
		#endregion
		#region SayTime(long time)
		/// <summary>
		/// Says the given time.
		/// </summary>
		/// <param name="time">the time to say in seconds since 00:00:00 on January 1, 1970.</param>
		protected internal virtual void SayTime(long time)
		{
			this.Channel.SayTime(time);
		}
		#endregion
		#region SayTime(long time, string escapeDigits)
		/// <summary>
		/// Says the given time, returning early if any of the given DTMF number are
		/// received on the channel.
		/// </summary>
		/// <param name="time">the time to say in seconds since 00:00:00 on January 1, 1970.</param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal virtual char SayTime(long time, string escapeDigits)
		{
			return this.Channel.SayTime(time, escapeDigits);
		}
		#endregion
		#region GetVariable(string name)
		/// <summary>
		/// Returns the value of the given channel variable.
		/// </summary>
		/// <param name="name">the name of the variable to retrieve.</param>
		/// <returns> the value of the given variable or <code>null</code> if not set.</returns>
		protected internal virtual string GetVariable(string name)
		{
			return this.Channel.GetVariable(name);
		}
		#endregion
		#region SetVariable(string name, string value_Renamed)
		/// <summary>
		/// Sets the value of the given channel variable to a new value.
		/// </summary>
		/// <param name="name">the name of the variable to retrieve.</param>
		/// <param name="val">the new value to set.</param>
		protected internal virtual void SetVariable(string name, string val)
		{
			this.Channel.SetVariable(name, val);
		}
		#endregion
		#region WaitForDigit(int timeout)
		/// <summary>
		/// Waits up to 'timeout' milliseconds to receive a DTMF digit.
		/// </summary>
		/// <param name="timeout">timeout the milliseconds to wait for the channel to receive a DTMF digit, -1 will wait forever.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal virtual char WaitForDigit(int timeout)
		{
			return this.Channel.WaitForDigit(timeout);
		}
		#endregion

		#region SendCommand(Command.AGICommand command)
		/// <summary>
		/// Sends the given command to the channel attached to the current thread.
		/// </summary>
		/// <param name="command">the command to send to Asterisk</param>
		/// <returns> the reply received from Asterisk</returns>
		/// <throws>  AGIException if the command could not be processed properly </throws>
		private AGIReply SendCommand(Command.AGICommand command)
		{
			return this.Channel.SendCommand(command);
		}
		#endregion
		private AGIChannel Channel
		{
			get
			{
				AGIChannel channel = AGIConnectionHandler.Channel;
				if (channel == null)
				{
					throw new SystemException("Trying to send command from an invalid thread");
				}
				return channel;
			}
		}
		public abstract void  Service(AGIRequest param1, AGIChannel param2);
	}
}
