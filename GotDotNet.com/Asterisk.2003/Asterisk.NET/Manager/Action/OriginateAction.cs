using System;
using System.Collections;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The OriginateAction generates an outgoing call to the extension in the given
	/// context with the given priority or to a given application with optional
	/// parameters.<br/>
	/// If you want to connect to an extension use the properties context, exten and
	/// priority. If you want to connect to an application use the properties
	/// application and data if needed. Note that no call detail record will be
	/// written when directly connecting to an application, so it may be better to
	/// connect to an extension that starts the application you wish to connect to.<br/>
	/// The response to this action is sent when the channel has been answered and
	/// asterisk starts connecting it to the given extension. So be careful not to
	/// choose a too short timeout when waiting for the response.<br/>
	/// If you set async to <code>true</code> Asterisk reports an OriginateSuccess-
	/// and OriginateFailureEvents. The action id of these events equals the action
	/// id of this OriginateAction.
	/// </summary>
	/// <seealso cref="Asterisk.NET.Manager.Event.OriginateSuccessEvent" />
	/// <seealso cref="Asterisk.NET.Manager.Event.OriginateFailureEvent" />
	public class OriginateAction : AbstractManagerAction, IEventGeneratingAction
	{
		private string channel;
		private string exten;
		private string context;
		private int priority;
		private long timeout;
		private string callerId;
		private bool callingPres;
		private IDictionary variables;
		private string account;
		private string application;
		private string data;
		private bool async;

		#region Action
		/// <summary>
		/// Get the name of this action, i.e. "Originate".
		/// </summary>
		override public string Action
		{
			get { return "Originate"; }
		}
		#endregion
		#region Account
		/// <summary>
		/// Get/Set the account code to use for the originated call.
		/// The account code is included in the call detail record generated for this call and will be used for billing.
		/// </summary>
		virtual public string Account
		{
			get { return account; }
			set { this.account = value; }
		}
		#endregion
		#region CallerId
		/// <summary>
		/// Get/Set the caller id to set on the outgoing channel.
		/// </summary>
		virtual public string CallerId
		{
			get { return callerId; }
			set { this.callerId = value; }
		}
		#endregion
		#region CallingPres
		/// <summary>
		/// Get/Set <code>true</code> if Caller ID presentation is set on the outgoing channel.
		/// </summary>
		virtual public bool CallingPres
		{
			get { return callingPres; }
			set { this.callingPres = value; }
		}
		#endregion
		#region Channel
		/// <summary>
		/// Get/Set Channel on which to originate the call (The same as you specify in the Dial application command)<br/>
		/// This property is required.
		/// </summary>
		virtual public string Channel
		{
			get { return channel; }
			set { this.channel = value; }
		}
		#endregion
		#region Context
		/// <summary>
		/// Get/Set the name of the context of the extension to connect to.
		/// If you set the context you also have to set the exten and priority properties.
		/// </summary>
		virtual public string Context
		{
			get { return context; }
			set { this.context = value; }
		}
		#endregion
		#region Exten
		/// <summary>
		/// Get/Ser the extension to connect to.
		/// If you set the extension you also have to set the context and priority properties.
		/// </summary>
		virtual public string Exten
		{
			get { return exten; }
			set { this.exten = value; }
		}
		#endregion
		#region Priority
		/// <summary>
		/// Get /Set the priority of the extension to connect to.
		/// If you set the priority you also have to set the context and exten properties.
		/// </summary>
		virtual public int Priority
		{
			get { return priority; }
			set { this.priority = value; }
		}
		#endregion
		#region Application
		/// <summary>
		/// Get/Set Application to use on connect (use Data for parameters)
		/// </summary>
		virtual public string Application
		{
			get { return application; }
			set { this.application = value; }
		}
		#endregion
		#region Data
		/// <summary>
		/// Get/Set the parameters to pass to the application.
		/// Data if Application parameter is user
		/// </summary>
		/// <summary> Sets the parameters to pass to the application.</summary>
		virtual public string Data
		{
			get { return data; }
			set { this.data = value; }
		}
		#endregion

		#region Async
		/// <summary>
		/// Get/Set <code>true</code> if this is a fast origination.<br/>
		/// For the origination to be asynchronous (allows multiple calls to be generated without waiting for a response).<br/>
		/// Will send OriginateSuccess- and OriginateFailureEvents.
		/// </summary>
		virtual public bool Async
		{
			get { return async; }
			set { this.async = value; }
		}
		#endregion
		#region ActionCompleteEventClass
		virtual public Type ActionCompleteEventClass
		{
			get { return typeof(Event.OriginateEvent); }
		}
		#endregion
		#region Timeout
		/// <summary>
		/// Get/Set the timeout for the origination.<br/>
		/// The channel must be answered within this time, otherwise the origination
		/// is considered to have failed and an OriginateFailureEvent is generated.<br/>
		/// If not set, Asterisk assumes a default value of 30000 meaning 30 seconds.
		/// </summary>
		public virtual long Timeout
		{
			get { return timeout; }
			set { this.timeout = value; }
		}
		#endregion

		#region Variable
		/// <summary>
		/// Get/Set the variables to set on the originated call.<br/>
		/// Variable assignments are of the form "VARNAME=VALUE". You can specify
		/// multiple variable assignments separated by the '|' character.<br/>
		/// Example: "VAR1=abc|VAR2=def" sets the channel variables VAR1 to "abc" and VAR2 to "def".
		/// </summary>
		virtual public string Variable
		{
			get { return Utils.ICollectionSupport.JoinVariables(variables, "|"); }
			set { variables = Utils.ICollectionSupport.ParseVariables(variables, value, "|"); }
		}
		#endregion

		#region GetVariables()
		/// <summary>
		/// Get the variables dictionary to set on the originated call.
		/// </summary>
		virtual public IDictionary GetVariables()
		{
			return variables;
		}
		#endregion
		#region SetVariables(IDictionary vars)
		/// <summary>
		/// Set the variables dictionary to set on the originated call.
		/// </summary>
		virtual public void SetVariables(IDictionary vars)
		{
			this.variables = vars;
		}
		#endregion
		#region SetVariable(string name, string val)
		/// <summary>
		/// Sets a variable dictionary on the originated call. Replaces any existing variable with the same name.
		/// </summary>
		public virtual void SetVariable(string name, string val)
		{
			if (variables == null)
				variables = new Hashtable();
			if (variables.Contains(name))
				variables[name] = val;
			else
				variables.Add(name, val);
		}
		#endregion
		#region GetVariable(string name, string val)
		/// <summary>
		/// Gets a variable on the originated call. Replaces any existing variable with the same name.
		/// </summary>
		public virtual string GetVariable(string name)
		{
			return variables[name].ToString();
		}
		#endregion
	}
}