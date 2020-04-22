namespace Asterisk.NET.Manager.Event
{
	/// <summary>
	/// A CdrEvent is triggered when a call detail record is generated, usually at the end of a call.<br/>
	/// To enable CdrEvents you have to add <code>enabled = yes</code> to the general section in
	/// <code>cdr_manager.conf</code>.<br/>
	/// This event is implemented in <code>cdr/cdr_manager.c</code>
	/// </summary>
	public class CdrEvent : ManagerEvent
	{
		private string accountCode;
		private string src;
		private string destination;
		private string destinationContext;
		private string callerId;
		private string channel;
		private string destinationChannel;
		private string lastApplication;
		private string lastData;
		private string startTime;
		private string answerTime;
		private string endTime;
		private int duration;
		private int billableSeconds;
		private string disposition;
		private string amaFlags;
		private string uniqueId;
		private string userField;

		virtual public string AccountCode
		{
			get { return accountCode; }
			set { this.accountCode = value; }
		}
		virtual public string Src
		{
			get { return src; }
			set { this.src = value; }
		}
		virtual public string Destination
		{
			get { return destination; }
			set { this.destination = value; }
		}
		virtual public string DestinationContext
		{
			get { return destinationContext; }
			set { this.destinationContext = value; }
		}
		virtual public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		virtual public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		virtual public string DestinationChannel
		{
			get { return destinationChannel; }
			set { this.destinationChannel = value; }
		}
		virtual public string LastApplication
		{
			get { return lastApplication; }
			set { this.lastApplication = value; }
		}
		virtual public string LastData
		{
			get { return lastData; }
			set { this.lastData = value; }
		}
		virtual public string StartTime
		{
			get { return startTime; }
			set { this.startTime = value; }
		}
		virtual public string AnswerTime
		{
			get { return answerTime; }
			set { this.answerTime = value; }
		}
		virtual public string EndTime
		{
			get { return endTime; }
			set { this.endTime = value; }
		}
		virtual public int Duration
		{
			get { return duration; }
			set { this.duration = value; }
		}
		virtual public int BillableSeconds
		{
			get { return billableSeconds; }
			set { this.billableSeconds = value; }
		}
		virtual public string Disposition
		{
			get { return disposition; }
			set { this.disposition = value; }
		}
		virtual public string AmaFlags
		{
			get { return amaFlags; }
			set { this.amaFlags = value; }
		}
		virtual public string UniqueId
		{
			get { return uniqueId; }
			set { this.uniqueId = value; }
		}
		virtual public string UserField
		{
			get { return userField; }
			set { this.userField = value; }
		}
		
		public CdrEvent(object source)
			: base(source)
		{
		}
	}
}