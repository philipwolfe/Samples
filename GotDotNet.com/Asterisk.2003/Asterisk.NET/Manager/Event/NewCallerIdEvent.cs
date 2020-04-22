using System;
namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A NewCallerIdEvent is triggered when the caller id of a channel changes.<br/>
	/// It is implemented in <code>channel.c</code>
	/// </summary>
	public class NewCallerIdEvent : ManagerEvent
	{
		/// <summary> The new Caller*ID.</summary>
		private string callerId;
		/// <summary> The new Caller*ID Name.</summary>
		private string callerIdName;
		/// <summary> The name of the channel.</summary>
		private string channel;
		/// <summary> The unique id of the channel.</summary>
		private string uniqueId;
		/// <summary> Callerid presentation/screening.</summary>
		private int cidCallingPres;
		private string cidCallingPresTxt;

		public NewCallerIdEvent(object source)
			: base(source)
		{
		}

		/// <summary>
		/// Get/Set the name of the channel.
		/// </summary>
		virtual public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set the unique id of the channel.
		/// </summary>
		virtual public string UniqueId
		{
			get { return uniqueId; }
			set { this.uniqueId = value; }
		}
		/// <summary>
		/// Get/Set the new caller id.
		/// </summary>
		virtual public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		/// <summary>
		/// Get/Set the new Caller*ID Name if set or "&lg;Unknown&gt;" if none has been set.
		/// </summary>
		virtual public string CallerIdName
		{
			get { return callerIdName; }
			set { this.callerIdName = value; }
		}
		/// <summary>
		/// Get the CallerId presentation/screening.
		/// </summary>
		virtual public int CidCallingPresNumeric
		{
			get { return cidCallingPres; }
		}
		
		/// <summary>
		/// Get/Sets the CallerId presentation/screening in the form "%d (%s)".
		/// </summary>
		public virtual string CidCallingPres
		{
			get
			{
				return cidCallingPres.ToString() + " (" + cidCallingPresTxt + ")";
			}
			set
			{
				string s = value;
				if (s == null || s.Length == 0)
					return;

				int spaceIdx = s.IndexOf(' ');
				if (spaceIdx <= 0)
					spaceIdx = s.Length;
				try
				{
					this.cidCallingPres = int.Parse(s.Substring(0, spaceIdx));
				}
				catch (FormatException)
				{
					return;
				}
				if (s.Length > spaceIdx + 3)
					this.cidCallingPresTxt = s.Substring(spaceIdx + 2, (s.Length - 1) - (spaceIdx + 2));
			}
		}
	}
}