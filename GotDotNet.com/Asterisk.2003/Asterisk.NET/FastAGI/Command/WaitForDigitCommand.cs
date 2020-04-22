using System;

namespace Asterisk.NET.FastAGI.Command
{

	#region Class - WaitForDigitCommand
	/// <summary>
	/// Waits up to 'timeout' milliseconds for channel to receive a DTMF digit.<br/>
	/// Returns -1 on channel failure, 0 if no digit is received in the timeout, or
	/// the numerical value of the ascii of the digit if one is received. Use -1 for
	/// the timeout value if you desire the call to block indefinitely.
	/// </summary>
	public class WaitForDigitCommand : AGICommand
	{
		#region Variables
		/// <summary> The milliseconds to wait for the channel to receive a DTMF digit.</summary>
		private int timeout;
		#endregion

		#region Timeout
		/// <summary>
		/// Get/Set the milliseconds to wait for the channel to receive a DTMF digit.
		/// </summary>
		virtual public int Timeout
		{
			get { return timeout; }
			set { this.timeout = value; }
		}
		#endregion

		#region Constructor - WaitForDigitCommand()
		/// <summary>
		/// Creates a new WaitForDigitCommand with a default timeout of -1 which blocks the channel indefinitely.
		/// </summary>
		public WaitForDigitCommand()
		{
			this.timeout = - 1;
		}
		#endregion
		#region Constructor - WaitForDigitCommand(int timeout)
		/// <summary>
		/// Creates a new WaitForDigitCommand.
		/// </summary>
		/// <param name="timeout">the milliseconds to wait for the channel to receive a DTMF digit.</param>
		public WaitForDigitCommand(int timeout)
		{
			this.timeout = timeout;
		}
		#endregion

		#region BuildCommand
		public override string BuildCommand()
		{
			return "WAIT FOR DIGIT " + timeout;
		}
		#endregion
	}
	#endregion
}