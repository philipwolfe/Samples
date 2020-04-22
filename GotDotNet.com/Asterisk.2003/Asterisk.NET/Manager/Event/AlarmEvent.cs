namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// An AlarmEvent is triggered when a Zap channel enters or changes alarm state.<br/>
	/// It is implemented in <code>channels/chan_zap.c</code>
	/// </summary>
	public class AlarmEvent : ManagerEvent
	{
		private string alarm;
		private int channel;

		/// <summary>
		/// Get/Set the kind of alarm that happened.<br/>
		/// This may be one of
		/// <ul>
		/// <li>Red Alarm</li>
		/// <li>Yellow Alarm</li>
		/// <li>Blue Alarm</li>
		/// <li>Recovering</li>
		/// <li>Loopback</li>
		/// <li>Not Open</li>
		/// </ul>
		/// </summary>
		virtual public string Alarm
		{
			get { return alarm; }
			set { this.alarm = value; }
		}
		/// <summary>
		/// Get/Set the number of the channel the alarm occured on.
		/// </summary>
		virtual public int Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		
		public AlarmEvent(object source)
			: base(source)
		{
		}
	}
}