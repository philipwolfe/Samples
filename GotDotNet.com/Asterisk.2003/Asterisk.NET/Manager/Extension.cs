using System;
using System.Text;

namespace Asterisk.NET.Manager
{
	/// <summary>
	/// Represents an Asterisk dialplan entry.
	/// </summary>
	public class Extension
	{
		private DateTime date;
		private string context;
		private string extension;
		private int priority;
		private string application;
		private string appData;

		virtual public DateTime Date
		{
			get { return date; }
		}
		virtual public string Context
		{
			get { return context; }
		}
		virtual public int Priority
		{
			get { return priority; }
		}
		virtual public string Application
		{
			get { return application; }
		}
		virtual public string AppData
		{
			get { return appData; }
		}
		
		public Extension(DateTime date, string context, string extension, int priority)
			: this(date, context, extension, priority, null, null)
		{
		}

		public Extension(DateTime date, string context, string extension, int priority, string application, string appData)
		{
			this.date = date;
			this.context = context;
			this.extension = extension;
			this.priority = priority;
			this.application = application;
			this.appData = appData;
		}
		
		public virtual string GetExtension()
		{
			return extension;
		}
		
		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(GetType().FullName);
			sb.Append(": date='" + Date.ToString("r"));
			sb.Append("'; context='" + Context);
			sb.Append("'; extension='" + GetExtension());
			sb.Append("'; priority='" + Priority);
			sb.Append("'; application='" + Application);
			sb.Append("'; appData=" + AppData);
			sb.Append("; systemHashcode=" + this.GetHashCode());
			return sb.ToString();
		}
	}
}
