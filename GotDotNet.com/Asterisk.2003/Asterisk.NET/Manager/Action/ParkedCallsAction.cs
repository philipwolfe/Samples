using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The ParkedCallsAction requests a list of all currently parked calls.<br/>
	/// For each active channel a ParkedCallEvent is generated. After all parked
	/// calls have been reported a ParkedCallsCompleteEvent is generated.
	/// </summary>
	/// <seealso cref="Asterisk.NET.Manager.Event.ParkedCallEvent"/>
	/// <seealso cref="Asterisk.NET.Manager.Event.ParkedCallsCompleteEvent"/>
	public class ParkedCallsAction : AbstractManagerAction, IEventGeneratingAction
	{
		/// <summary> Get the name of this action, i.e. "ParkedCalls".</summary>
		override public string Action
		{
			get { return "ParkedCalls"; }
		}
		virtual public Type ActionCompleteEventClass
		{
			get { return typeof(Event.ParkedCallsCompleteEvent); }
		}
		
		/// <summary>
		/// Creates a new ParkedCallsAction.
		/// </summary>
		public ParkedCallsAction()
		{
		}
	}
}