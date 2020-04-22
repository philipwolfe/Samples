using System;
using System.Text;
using System.Collections;

namespace Asterisk.NET.Manager.Response
{
	/// <summary>
	/// Represents a response received from the Asterisk server as the result of a
	/// previously sent ManagerAction.<br/>
	/// The response can be linked with the action that caused it by looking the
	/// action id attribute that will match the action id of the corresponding
	/// action.
	/// </summary>
	public class ManagerResponse
	{
		private DateTime dateReceived;
		private string actionId;
		private string response;
		private string message;
		private string uniqueId;
		private IDictionary attributes;

		/// <summary>
		/// Returns a Map with all attributes of this response.<br/>
		/// The keys are all lower case!
		/// </summary>
		virtual public IDictionary Attributes
		{
			get { return attributes; }
			set { this.attributes = value; }
		}
		/// <summary>
		/// Get/Set the point in time this response was received from the asterisk server.
		/// </summary>
		virtual public DateTime DateReceived
		{
			get { return dateReceived; }
			set { this.dateReceived = value; }
		}
		/// <summary>
		/// Get/Set the action id received with this response referencing the action that generated this response.
		/// </summary>
		virtual public string ActionId
		{
			get { return actionId; }
			set { this.actionId = value; }
		}
		/// <summary>
		/// Get/Set the message received with this response.<br/>
		/// The content depends on the action that generated this response.
		/// </summary>
		virtual public string Message
		{
			get { return message; }
			set { this.message = value; }
		}
		/// <summary>
		/// Get/Set the value of the "Response:" line.<br/>
		/// This typically a String like "Success" or "Error" but depends on the action that generated this response.
		/// </summary>
		virtual public string Response
		{
			get { return response; }
			set { this.response = value; }
		}
		/// <summary>
		/// Get/Set the unique id received with this response.<br/>
		/// The unique id is used to keep track of channels created by the action sent, for example an OriginateAction.
		/// </summary>
		virtual public string UniqueId
		{
			get { return uniqueId; }
			set { this.uniqueId = value; }
		}
		
		/// <summary>
		/// Returns the value of the attribute with the given key.<br/>
		/// This is particulary important when a response contains special 
		/// attributes that are dependent on the action that has been sent.<br/>
		/// An example of this is the response to the GetVarAction.
		/// It contains the value of the channel variable as an attribute
		/// stored under the key of the variable name.<br/>
		/// Example:
		/// <pre>
		/// GetVarAction action = new GetVarAction();
		/// action.setChannel("SIP/1310-22c3");
		/// action.setVariable("ALERT_INFO");
		/// ManagerResponse response = connection.SendAction(action);
		/// String alertInfo = response.getAttribute("ALERT_INFO");
		/// </pre>
		/// As all attributes are internally stored in lower case the key is
		/// automatically converted to lower case before lookup.
		/// </summary>
		/// <param name="key">the key to lookup.</param>
		/// <returns> the value of the attribute stored under this key or
		/// <code>null</code> if there is no such attribute.
		/// </returns>
		public virtual string GetAttribute(string key)
		{
			return (string) attributes[key.ToLower()];
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(GetType().FullName);
			sb.Append(": actionId='" + ActionId);
			sb.Append("'; message='" + Message);
			sb.Append("'; response='" + Response);
			sb.Append("'; uniqueId='" + UniqueId);
			sb.Append("'; systemHashcode=" + this.GetHashCode());
			return sb.ToString();
		}
	}
}
