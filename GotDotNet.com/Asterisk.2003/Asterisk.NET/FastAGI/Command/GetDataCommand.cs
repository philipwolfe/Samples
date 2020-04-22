using System;
namespace Asterisk.NET.FastAGI.Command
{
	/// <summary>
	/// Stream the given file, and recieve DTMF data. The user may interrupt the streaming by starting to enter digits.<br/>
	/// Returns the digits recieved from the channel at the other end.<br/>
	/// Input ends when the timeout is reached, the maximum number of digits is read or the user presses #.
	/// </summary>
	public class GetDataCommand : AGICommand
	{
		private const int DEFAULT_MAX_DIGITS = 1024;
		private const int DEFAULT_TIMEOUT = 0;

		/// <summary> The name of the file to stream.</summary>
		private string file;
		/// <summary> The timeout to wait for data.<br/>
		/// 0 means standard timeout value, -1 means "ludicrous time" (essentially never times out).
		/// </summary>
		private int timeout;
		/// <summary> The maximum number of digits to read.<br/>
		/// Must be in [1..1024].
		/// </summary>
		private int maxDigits;

		/// <summary>
		/// Get/Set the name of the file to stream. Must not include extension.
		/// </summary>
		virtual public string File
		{
			get { return file; }
			set { this.file = value; }
		}
		/// <summary>
		/// Get/Set the timeout to wait for data. 0 means standard timeout value, -1 means "ludicrous time" (essentially never times out).
		/// </summary>
		virtual public int Timeout
		{
			get { return timeout; }
			set { this.timeout = value; }
		}
		/// <summary>
		/// Get/Set the maximum number of digits to read. The maximum number of digits to read. Must be in [1..1024].
		/// </summary>
		/// <throws>  IllegalArgumentException if maxDigits is not in [1..1024] </throws>
		virtual public int MaxDigits
		{
			get { return maxDigits; }
			set
			{
				if (value < 1 || value > 1024)
					throw new ArgumentException("maxDigits must be in [1..1024]");
				this.maxDigits = value;
			}
		}
		
		/// <summary> Creates a new GetDataCommand with default timeout and maxDigits set to
		/// 1024.
		/// 
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.
		/// </param>
		public GetDataCommand(string file)
		{
			this.file = file;
			this.timeout = DEFAULT_TIMEOUT;
			this.maxDigits = DEFAULT_MAX_DIGITS;
		}
		
		/// <summary>
		/// Creates a new GetDataCommand with the given timeout and maxDigits set to 1024.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="timeout">the timeout to wait for data.<br/>
		/// 0 means standard timeout value, -1 means "ludicrous time" (essentially never times out).
		/// </param>
		public GetDataCommand(string file, int timeout)
		{
			this.file = file;
			this.timeout = timeout;
			this.maxDigits = DEFAULT_MAX_DIGITS;
		}
		
		/// <summary>
		/// Creates a new GetDataCommand with the given timeout and maxDigits.
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.</param>
		/// <param name="timeout">the timeout to wait for data.<br/>
		/// 0 means standard timeout value, -1 means "ludicrous time" (essentially never times out).
		/// </param>
		/// <param name="maxDigits">the maximum number of digits to read.<br/>
		/// Must be in [1..1024].
		/// </param>
		/// <throws>  IllegalArgumentException if maxDigits is not in [1..1024] </throws>
		public GetDataCommand(string file, int timeout, int maxDigits)
		{
			this.file = file;
			this.timeout = timeout;
			this.MaxDigits = maxDigits;
		}
		
		public override string BuildCommand()
		{
			if (maxDigits == DEFAULT_MAX_DIGITS)
			{
				if (timeout == DEFAULT_TIMEOUT)
					return "GET DATA " + EscapeAndQuote(file);
				else
					return "GET DATA " + EscapeAndQuote(file) + " " + timeout;
			}
			return "GET DATA " + EscapeAndQuote(file) + " " + timeout + " " + maxDigits;
		}
	}
}