using System;
namespace Asterisk.NET.FastAGI.Command
{
	
	/// <summary> Plays the given file, allowing playback to be interrupted by the given
	/// digits, if any.<br/>
	/// If offset is provided then the audio will seek to sample offset before play
	/// starts.<br/>
	/// Returns 0 if playback completes without a digit being pressed, or the ASCII
	/// numerical value of the digit if one was pressed, or -1 on error or if the
	/// channel was disconnected. <br/>
	/// Remember, the file extension must not be included in the filename.
	/// 
	/// </summary>
	public class StreamFileCommand : AGICommand
	{
		/// <summary> Returns the name of the file to stream.
		/// 
		/// </summary>
		/// <returns> the name of the file to stream.
		/// </returns>
		/// <summary> Sets the name of the file to stream.
		/// 
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.
		/// </param>
		virtual public string File
		{
			get
			{
				return file;
			}
			set
			{
				this.file = value;
			}
		}
		/// <summary> Returns the digits that allow the user to interrupt this command.
		/// 
		/// </summary>
		/// <returns> the digits that allow the user to interrupt this command.
		/// </returns>
		/// <summary> Sets the digits that allow the user to interrupt this command.
		/// 
		/// </summary>
		/// <param name="escapeDigits">the digits that allow the user to interrupt this
		/// command or <code>null</code> for none.
		/// </param>
		virtual public string EscapeDigits
		{
			get
			{
				return escapeDigits;
			}
			
			set
			{
				this.escapeDigits = value;
			}
		}
		/// <summary> Returns the offset samples to skip before streaming.
		/// 
		/// </summary>
		/// <returns> the offset samples to skip before streaming.
		/// </returns>
		/// <summary> Sets the offset samples to skip before streaming.
		/// 
		/// </summary>
		/// <param name="offset">the offset samples to skip before streaming.
		/// </param>
		virtual public int Offset
		{
			get
			{
				return offset;
			}
			
			set
			{
				this.offset = value;
			}
			
		}
		
		/// <summary> The name of the file to stream.</summary>
		private string file;
		
		/// <summary> When one of these digits is pressed while streaming the command returns.</summary>
		private string escapeDigits;
		
		/// <summary> The offset samples to skip before streaming.</summary>
		private int offset;
		
		/// <summary> Creates a new StreamFileCommand, streaming from the beginning.
		/// 
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.
		/// </param>
		public StreamFileCommand(string file)
		{
			this.file = file;
			this.escapeDigits = null;
			this.offset = - 1;
		}
		
		/// <summary> Creates a new StreamFileCommand, streaming from the beginning.
		/// 
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.
		/// </param>
		/// <param name="escapeDigits">contains the digits that allow the user to interrupt
		/// this command.
		/// </param>
		public StreamFileCommand(string file, string escapeDigits)
		{
			this.file = file;
			this.escapeDigits = escapeDigits;
			this.offset = - 1;
		}
		
		/// <summary> Creates a new StreamFileCommand, streaming from the given offset.
		/// 
		/// </summary>
		/// <param name="file">the name of the file to stream, must not include extension.
		/// </param>
		/// <param name="escapeDigits">contains the digits that allow the user to interrupt
		/// this command. Maybe <code>null</code> if you don't want the
		/// user to interrupt.
		/// </param>
		/// <param name="offset">the offset samples to skip before streaming.
		/// </param>
		public StreamFileCommand(string file, string escapeDigits, int offset)
		{
			this.file = file;
			this.escapeDigits = escapeDigits;
			this.offset = offset;
		}
		
		public override string BuildCommand()
		{
			return "STREAM FILE " + EscapeAndQuote(file) + " " + EscapeAndQuote(escapeDigits) + (offset < 0?"":" " + offset);
		}
	}
}