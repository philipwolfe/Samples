using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The HangupAction causes the pbx to hang up a given channel.
	/// </summary>
	public class HangupAction : AbstractManagerAction
	{
		private string channel;

		/// <summary>
		/// Get the name of this action, i.e. "Hangup".
		/// </summary>
		override public string Action
		{
			get { return "Hangup"; }
		}
		/// <summary>
		/// Get/Set the channel to hangup.
		/// </summary>
		virtual public string Channel
		{
			get { return this.channel; }
			set { this.channel = value; }
		}
	}
}