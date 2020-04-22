using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The AgentsAction requests the state of all agents.<br/>
	/// For each agent an AgentsEvent is generated. After the state of all agents has been reported an AgentsCompleteEvent is generated.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	/// <seealso cref="Asterisk.NET.Manager.Event.AgentsEvent" />
	/// <seealso cref="Asterisk.NET.Manager.Event.AgentsCompleteEvent" />
	public class AgentsAction : AbstractManagerAction, IEventGeneratingAction
	{
		/// <summary>
		/// Get the name of this action, i.e. "Agents".
		/// </summary>
		override public string Action
		{
			get { return "Agents"; }
		}
		virtual public Type ActionCompleteEventClass
		{
			get { return typeof(Event.AgentsCompleteEvent); }
		}
	
		/// <summary>
		/// Creates a new AgentsAction.
		/// </summary>
		public AgentsAction()
		{
		}
	}
}