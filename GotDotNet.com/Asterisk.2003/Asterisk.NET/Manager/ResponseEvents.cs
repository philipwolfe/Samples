using System.Collections;
using Asterisk.NET.Manager.Response;
using Asterisk.NET.Manager.Event;

namespace Asterisk.NET.Manager
{
	/// <summary>
	/// Implementation of the ResponseEvents interface.
	/// </summary>
	public class ResponseEvents : IResponseEvents
	{
		private ManagerResponse response;
		private ArrayList events;
		private bool complete;

		virtual public ManagerResponse Response
		{
			get { return response; }
		}
		virtual public ArrayList Events
		{
			get { return events; }
		}
		/// <summary>
		/// Indicats if all events have been received.
		/// </summary>
		virtual public bool Complete
		{
			get { return complete; }
			set { this.complete = value; }
		}
		/// <summary>
		/// Sets the ManagerResponse received.
		/// </summary>
		virtual public ManagerResponse Repsonse
		{
			set { this.response = value; }
		}
		
		/// <summary> Creates a new instance.</summary>
		public ResponseEvents()
		{
			this.events = new ArrayList();
			this.complete = false;
		}
		
		/// <summary>
		/// Adds a ResponseEvent that has been received.
		/// </summary>
		/// <param name="e">the ResponseEvent that has been received.</param>
		public virtual void AddEvent(ResponseEvent e)
		{
			lock (events)
			{
				events.Add(e);
			}
		}
	}
}