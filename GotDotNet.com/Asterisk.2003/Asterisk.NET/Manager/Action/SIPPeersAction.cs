using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// Retrieves a list of all defined SIP peers.<br/>
	/// For each peer that is found a PeerEntryEvent is sent by Asterisk containing
	/// the details. When all peers have been reported a PeerlistCompleteEvent is sent.<br/>
	/// Available since Asterisk 1.2
	/// </summary>
	/// <seealso cref="Manager.event.PeerEntryEvent" />
	/// <seealso cref="Manager.event.PeerlistCompleteEvent" />
	public class SIPPeersAction : AbstractManagerAction, IEventGeneratingAction
	{
		override public string Action
		{
			get { return "SIPPeers"; }
		}
		virtual public Type ActionCompleteEventClass
		{
			get
			{
				return typeof(Event.PeerlistCompleteEvent);
			}
			
		}
		
		/// <summary>
		/// Creates a new SIPPeersAction.
		/// </summary>
		public SIPPeersAction()
		{
		}
	}
}