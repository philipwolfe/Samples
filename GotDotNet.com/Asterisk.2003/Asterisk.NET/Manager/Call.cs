using System;
using System.Text;

namespace Asterisk.NET.Manager
{
	public class Call
	{
		private string uniqueId;
		private int reason;
		private Channel channel;

		private DateTime startTime;
		private DateTime endTime = DateTime.MinValue;

		virtual public string UniqueId
		{
			get { return uniqueId; }
			set { this.uniqueId = value; }
		}
		virtual public Channel Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		virtual public int Reason
		{
			get { return reason; }
			set { this.reason = value; }
		}
		virtual public DateTime StartTime
		{
			get { return startTime; }
			set { this.startTime = value; }
		}
		virtual public DateTime EndTime
		{
			get { return endTime; }
			set { this.endTime = value; }
		}
		public Call()
		{
			startTime = DateTime.Now;
		}
		
		/// <summary>
		/// Return the duration of the call in milliseconds. If the call is has not
		/// ended, the duration so far is calculated.
		/// </summary>
		public virtual long CalcDuration()
		{
			DateTime compTime;
			if (endTime != DateTime.MinValue)
				compTime = endTime;
			else
				compTime = DateTime.Now;
			return (compTime.Ticks - startTime.Ticks) / 10000;
		}
		
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(GetType().FullName);
			sb.Append(": uniqueId=" + UniqueId);
			sb.Append("; reason=" + Reason);
			sb.Append("; startTime=" + StartTime.ToString("r"));
			sb.Append("; endTime=" + EndTime.ToString("r"));
			sb.Append("; systemHashcode=" + this.GetHashCode());
			return sb.ToString();
		}
	}
}