using System;
namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// The AbstractAGIScript provides some convinience methods to make it easier to write custom AGIScripts.<br/>
	/// Just extend it by your own AGIScripts.<br/>
	/// </summary>
	/// <seealso cref="FastAGI.BaseAGIScript} instead"/>
	public abstract class AbstractAGIScript : IAGIScript
	{
		/// <summary>
		/// Answers the channel.
		/// </summary>
		protected internal virtual void Answer(AGIChannel channel)
		{
			channel.Answer();
		}
		
		/// <summary> Hangs the channel up.</summary>
		protected internal virtual void Hangup(AGIChannel channel)
		{
			channel.Hangup();
		}
		
		/// <summary>
		/// Cause the channel to automatically hangup at the given number of seconds in the future.
		/// </summary>
		/// <param name="time">the number of seconds before this channel is automatically hung up.<br/>
		/// 0 disables the autohangup feature.
		/// </param>
		protected internal virtual void SetAutoHangup(AGIChannel channel, int time)
		{
			channel.SetAutoHangup(time);
		}
		
		/// <summary>
		/// Sets the caller id on the current channel.
		/// </summary>
		/// <param name="callerId">the raw caller id to set, for example "John Doe<1234>".</param>
		protected internal virtual void  setCallerId(AGIChannel channel, string callerId)
		{
			channel.SetCallerId(callerId);
		}
		
		/// <summary>
		/// Plays music on hold from the default music on hold class.
		/// </summary>
		protected internal virtual void PlayMusicOnHold(AGIChannel channel)
		{
			channel.PlayMusicOnHold();
		}
		
		/// <summary>
		/// Plays music on hold from the given music on hold class.
		/// </summary>
		/// <param name="musicOnHoldClass">the music on hold class to play music from as configures in Asterisk's <code><musiconhold.conf/code>.</param>
		protected internal virtual void PplayMusicOnHold(AGIChannel channel, string musicOnHoldClass)
		{
			channel.PlayMusicOnHold(musicOnHoldClass);
		}
		
		/// <summary>
		/// Stops playing music on hold.
		/// </summary>
		protected internal virtual void StopMusicOnHold(AGIChannel channel)
		{
			channel.StopMusicOnHold();
		}

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
		/// </summary>
		/// <returns> the status of the channel.</returns>
		protected internal virtual int GetChannelStatus(AGIChannel channel)
		{
			return channel.GetChannelStatus();
		}
		
		/// <summary>
		/// Plays the given file and waits for the user to enter DTMF digits until he
		/// presses '#'. The user may interrupt the streaming by starting to enter
		/// digits.
		/// </summary>
		/// <param name="file">the name of the file to play</param>
		/// <returns> a String containing the DTMF the user entered</returns>
		protected internal virtual string GetData(AGIChannel channel, string file)
		{
			return channel.GetData(file);
		}
		
		/// <summary>
		/// Plays the given file and waits for the user to enter DTMF digits until he
		/// presses '#' or the timeout occurs. The user may interrupt the streaming
		/// by starting to enter digits.
		/// </summary>
		/// <param name="file">the name of the file to play</param>
		/// <param name="timeout">the timeout to wait for user input.<br/>
		/// 0 means standard timeout value, -1 means "ludicrous time" (essentially never times out).</param>
		/// <returns> a String containing the DTMF the user entered</returns>
		protected internal virtual string GetData(AGIChannel channel, string file, int timeout)
		{
			return channel.GetData(file, timeout);
		}
		
		/// <summary>
		/// Plays the given file and waits for the user to enter DTMF digits until he
		/// presses '#' or the timeout occurs or the maximum number of digits has
		/// been entered. The user may interrupt the streaming by starting to enter
		/// digits.
		/// </summary>
		/// <param name="file">the name of the file to play</param>
		/// <param name="timeout">the timeout to wait for user input.<br/>
		/// 0 means standard timeout value, -1 means "ludicrous time"
		/// (essentially never times out).
		/// </param>
		/// <param name="maxDigits">the maximum number of digits the user is allowed to enter</param>
		/// <returns> a String containing the DTMF the user entered</returns>
		protected internal virtual string GetData(AGIChannel channel, string file, int timeout, int maxDigits)
		{
			return channel.GetData(file, timeout, maxDigits);
		}
		
		/// <summary>
		/// Plays the given file, and waits for the user to press one of the given
		/// digits. If none of the esacpe digits is pressed while streaming the file
		/// it waits for the default timeout of 5 seconds still waiting for the user
		/// to press a digit.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="escapeDigits">contains the digits that the user is expected to press.</param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed.</returns>
		protected internal virtual char GetOption(AGIChannel channel, string file, string escapeDigits)
		{
			return channel.GetOption(file, escapeDigits);
		}
		
		/// <summary>
		/// Plays the given file, and waits for the user to press one of the given
		/// digits. If none of the esacpe digits is pressed while streaming the file
		/// it waits for the specified timeout still waiting for the user to press a
		/// digit.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension. </param>
		/// <param name="escapeDigits">contains the digits that the user is expected to press. </param>
		/// <param name="timeout">the timeout in seconds to wait if none of the defined esacpe digits was presses while streaming. </param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed. </returns>
		protected internal virtual char GetOption(AGIChannel channel, string file, string escapeDigits, int timeout)
		{
			return channel.GetOption(file, escapeDigits, timeout);
		}
		
		/// <summary>
		/// Executes the given command.
		/// </summary>
		/// <param name="application">the name of the application to execute, for example "Dial". </param>
		/// <returns> the return code of the application of -2 if the application was not found. </returns>
		protected internal virtual int Exec(AGIChannel channel, string application)
		{
			return channel.Exec(application);
		}
		
		/// <summary>
		/// Executes the given command.
		/// </summary>
		/// <param name="application">the name of the application to execute, for example "Dial". </param>
		/// <param name="options">the parameters to pass to the application, for example "SIP/123". </param>
		/// <returns> the return code of the application of -2 if the application was not found. </returns>
		protected internal virtual int Exec(AGIChannel channel, string application, string options)
		{
			return channel.Exec(application, options);
		}
		
		/// <summary>
		/// Executes the given command.
		/// </summary>
		/// <param name="application">the name of the application to execute, for example "Dial". </param>
		/// <returns> the return code of the application of -2 if the application was not found. </returns>
		/// <seealso cref="exec(AGIChannel, String)} instead" />
		protected internal virtual int ExecCommand(AGIChannel channel, string application)
		{
			return channel.Exec(application);
		}
		
		/// <summary>
		/// Executes the given command.
		/// </summary>
		/// <param name="application">the name of the application to execute, for example "Dial". </param>
		/// <param name="options">the parameters to pass to the application, for example "SIP/123". </param>
		/// <returns> the return code of the application of -2 if the application was not found. </returns>
		/// <seealso cref="exec(AGIChannel, String, String)} instead" />
		protected internal virtual int ExecCommand(AGIChannel channel, string application, string options)
		{
			return channel.Exec(application, options);
		}
		
		/// <summary>
		/// Sets the context for continuation upon exiting the application.
		/// </summary>
		/// <param name="context">the context for continuation upon exiting the application. </param>
		protected internal virtual void SetContext(AGIChannel channel, string context)
		{
			channel.SetContext(context);
		}
		
		/// <summary>
		/// Sets the extension for continuation upon exiting the application.
		/// </summary>
		/// <param name="extension">the extension for continuation upon exiting the application. </param>
		protected internal virtual void SetExtension(AGIChannel channel, string extension)
		{
			channel.SetExtension(extension);
		}
		
		/// <summary>
		/// Sets the priority for continuation upon exiting the application.
		/// </summary>
		/// <param name="priority">the priority for continuation upon exiting the application. </param>
		protected internal virtual void SetPriority(AGIChannel channel, int priority)
		{
			channel.SetPriority(priority);
		}
		
		/// <summary>
		/// Plays the given file.
		/// </summary>
		/// <param name="file">name of the file to play. </param>
		protected internal virtual void StreamFile(AGIChannel channel, string file)
		{
			channel.StreamFile(file);
		}
		
		/// <summary>
		/// Plays the given file and allows the user to escape by pressing one of the given digit.
		/// </summary>
		/// <param name="file">name of the file to play. </param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow theuser to escape. </param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed. </returns>
		protected internal virtual char StreamFile(AGIChannel channel, string file, string escapeDigits)
		{
			return channel.StreamFile(file, escapeDigits);
		}
		
		/// <summary>
		/// Says the given digit string.
		/// </summary>
		/// <param name="digits">the digit string to say. </param>
		protected internal virtual void SayDigits(AGIChannel channel, string digits)
		{
			channel.SayDigits(digits);
		}
		
		/// <summary>
		/// Says the given number, returning early if any of the given DTMF number
		/// are received on the channel.
		/// </summary>
		/// <param name="digits">the digit string to say. </param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape. </param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed. </returns>
		protected internal virtual char SayDigits(AGIChannel channel, string digits, string escapeDigits)
		{
			return channel.SayDigits(digits, escapeDigits);
		}
		
		/// <summary>
		/// Says the given number.
		/// </summary>
		/// <param name="number">the number to say.</param>
		protected internal virtual void SayNumber(AGIChannel channel, string number)
		{
			channel.SayNumber(number);
		}
		
		/// <summary>
		/// Says the given number, returning early if any of the given DTMF number
		/// are received on the channel.
		/// </summary>
		/// <param name="number">the number to say. </param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape. </param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed. </returns>
		protected internal virtual char SayNumber(AGIChannel channel, string number, string escapeDigits)
		{
			return channel.SayNumber(number, escapeDigits);
		}
		
		/// <summary>
		/// Says the given character string with phonetics.
		/// </summary>
		/// <param name="text">the text to say. </param>
		protected internal virtual void SayPhonetic(AGIChannel channel, string text)
		{
			channel.SayPhonetic(text);
		}
		
		/// <summary>
		/// Says the given character string with phonetics, returning early if any of
		/// the given DTMF number are received on the channel.
		/// </summary>
		/// <param name="text">the text to say. </param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape. </param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed. </returns>
		protected internal virtual char SayPhonetic(AGIChannel channel, string text, string escapeDigits)
		{
			return channel.SayPhonetic(text, escapeDigits);
		}
		
		/// <summary>
		/// Says the given character string.
		/// </summary>
		/// <param name="text">the text to say. </param>
		protected internal virtual void SayAlpha(AGIChannel channel, string text)
		{
			channel.SayAlpha(text);
		}
		
		/// <summary>
		/// Says the given character string, returning early if any of the given DTMF
		/// number are received on the channel.
		/// </summary>
		/// <param name="text">the text to say. </param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape. </param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed. </returns>
		protected internal virtual char SayAlpha(AGIChannel channel, string text, string escapeDigits)
		{
			return channel.SayAlpha(text, escapeDigits);
		}
		
		/// <summary>
		/// Says the given time.
		/// </summary>
		/// <param name="time">the time to say in seconds since 00:00:00 on January 1, 1970.</param>
		protected internal virtual void SayTime(AGIChannel channel, long time)
		{
			channel.SayTime(time);
		}

		/// <summary>
		/// Says the given time, returning early if any of the given DTMF number are
		/// received on the channel.
		/// </summary>
		/// <param name="time">the time to say in seconds since 00:00:00 on January 1, 1970. </param>
		/// <param name="escapeDigits">a String containing the DTMF digits that allow the user to escape. </param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed. </returns>
		protected internal virtual char SayTime(AGIChannel channel, long time, string escapeDigits)
		{
			return channel.SayTime(time, escapeDigits);
		}
		
		/// <summary>
		/// Returns the value of the given channel variable.
		/// </summary>
		/// <param name="name">the name of the variable to retrieve. </param>
		/// <returns> the value of the given variable or <code>null</code> if not set. </returns>
		protected internal virtual string GetVariable(AGIChannel channel, string name)
		{
			return channel.GetVariable(name);
		}
		
		/// <summary>
		/// Sets the value of the given channel variable to a new value.
		/// </summary>
		/// <param name="name">the name of the variable to retrieve. </param>
		/// <param name="val">the new value to set. </param>
		protected internal virtual void SetVariable(AGIChannel channel, string name, string val)
		{
			channel.SetVariable(name, val);
		}
		
		/// <summary>
		/// Waits up to 'timeout' milliseconds to receive a DTMF digit.
		/// </summary>
		/// <param name="timeout">timeout the milliseconds to wait for the channel to receive a DTMF digit, -1 will wait forever. </param>
		/// <returns> the DTMF digit pressed or 0x0 if none was pressed. </returns>
		protected internal virtual char waitForDigit(AGIChannel channel, int timeout)
		{
			return channel.WaitForDigit(timeout);
		}
		public abstract void Service(AGIRequest param1, AGIChannel param2);
	}
}
