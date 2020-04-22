using System;
using System.Text;
using System.Collections;

namespace Asterisk.NET.Manager
{
	public class Originate
	{
		private string channel;
		private string exten;
		private string context;
		private int priority;
		private long timeout;
		private string callerId;
		private IDictionary variables;
		private string account;
		private string application;
		private string data;

		#region Account
		/// <summary>
		/// Get/Set the account code to use for the originated call.
		/// The account code is included in the call detail record generated for this
		/// call and will be used for billing.
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
		#region Channel
		/// <summary>
		/// Get/Set the name of the channel to connect to the outgoing call.
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
		/// Get/Set the extension to connect to.
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
		/// Get/Set the priority of the extension to connect to. If you set the priority
		/// you also have to set the context and exten properties.
		/// </summary>
		virtual public int Priority
		{
			get { return priority; }
			set { this.priority = value; }
		}
		#endregion
		#region Application
		/// <summary>
		/// Get/Set the name of the application to connect to.
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
		/// </summary>
		virtual public string Data
		{
			get { return data; }
			set { this.data = value; }
		}
		#endregion
		#region Timeout
		/// <summary>
		/// Get/Set the timeout for the origination (in milliseconds) for the origination.<br/>
		/// The channel must be answered within this time, otherwise the origination
		/// is considered to have failed and an OriginateFailureEvent is generated.<br/>
		/// If not set, a default value of 30000 is asumed meaning 30 seconds.
		/// </summary>
		virtual public long Timeout
		{
			get { return timeout; }
			set { this.timeout = value; }
		}
		#endregion

		#region Variable
		/// <summary>
		/// Get/Set the variables to set on the originated call in native asterisk format.<br/>
		/// Example: "VAR1=abc|VAR2=def".
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
			if(variables.Contains(name))
				variables[name] = val;
			else
				variables.Add(name, val);
		}
		#endregion
		#region GetVariable(string name)
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