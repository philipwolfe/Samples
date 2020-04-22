namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A HangupEvent is triggered when a channel is hung up.<br/>
	/// It is implemented in <code>channel.c</code>
	/// </summary>
	public class HangupEvent:ChannelEvent
	{
		private int cause;
		private string causeTxt;
		
		/// <summary>
		/// Get/Set the cause of the hangup.
		/// </summary>
		virtual public int Cause
		{
			get { return cause; }
			set { this.cause = value; }
		}
		/// <summary>
		/// Get/Set the textual representation of the hangup cause.
		/// </summary>
		virtual public string CauseTxt
		{
			get { return causeTxt; }
			set { this.causeTxt = value; }
		}
		
		public HangupEvent(object source)
			: base(source)
		{
		}
	}
}