using System;

namespace Asterisk.NET.Manager.Action
{
	/// <summary>
	/// The GetVarAction queries for a channel variable.
	/// </summary>
	public class GetVarAction : AbstractManagerAction
	{
		private string channel;
		private string varName;

		/// <summary>
		/// Get the name of this action, i.e. "GetVar".
		/// </summary>
		override public string Action
		{
			get { return "GetVar"; }
		}
		/// <summary>
		/// Get/Set the name of the channel.
		/// </summary>
		virtual public string Channel
		{
			get { return this.channel; }
			set { this.channel = value; }
		}
		/// <summary>
		/// Get/Set the name of the variable to query.
		/// </summary>
		virtual public string Variable
		{
			get { return this.varName; }
			set { this.varName = value; }
		}
	}
}