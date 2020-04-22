namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AlarmEvent is triggered when a Zap channel leaves alarm state.<br/>
	/// It is implemented in <code>channels/chan_zap.c</code>
	/// </summary>
	public class AlarmClearEvent : ManagerEvent
	{
		/// <summary> The number of the zap channel that left alarm state.</summary>
		private int channel;
		
		/// <summary>
		/// Get/Set the number of the zap channel that left alarm state.
		/// </summary>
		virtual public int Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		
		public AlarmClearEvent(object source)
			: base(source)
		{
		}
	}
}