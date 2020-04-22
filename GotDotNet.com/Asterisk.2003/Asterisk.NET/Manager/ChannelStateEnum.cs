using System.Collections;

namespace Asterisk.NET.Manager
{
	/// <summary>
	/// Enumeration that represents the state of a channel.
	/// </summary>
	public class ChannelStateEnum
	{
		private static IDictionary literals = new Hashtable();
		private string state;

		public static readonly ChannelStateEnum Down = new ChannelStateEnum("Down");
		public static readonly ChannelStateEnum Off_Hook = new ChannelStateEnum("OffHook");
		public static readonly ChannelStateEnum Dialing = new ChannelStateEnum("Dialing");
		public static readonly ChannelStateEnum Ring = new ChannelStateEnum("Ring");
		public static readonly ChannelStateEnum Ringing = new ChannelStateEnum("Ringing");
		public static readonly ChannelStateEnum Up = new ChannelStateEnum("Up");
		public static readonly ChannelStateEnum Busy = new ChannelStateEnum("Busy");
		public static readonly ChannelStateEnum Rsrvd = new ChannelStateEnum("Rsrvd");
		public static readonly ChannelStateEnum Hungup = new ChannelStateEnum("Hungup");
		
		private ChannelStateEnum(string state)
		{
			this.state = state;
			literals[state] = this;
		}
		
		public static ChannelStateEnum GetEnum(string state)
		{
			return (ChannelStateEnum) literals[state];
		}
		
		public override string ToString()
		{
			return state;
		}
	}
}