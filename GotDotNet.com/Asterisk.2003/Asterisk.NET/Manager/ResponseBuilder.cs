using System.Collections;
using Asterisk.NET.Manager.Response;

namespace Asterisk.NET.Manager
{
	/// <summary>
	/// Default implementation of the ResponseBuilder interface.
	/// </summary>
	/// <seealso cref="Manager.Response.ManagerResponse" />
	public class ResponseBuilder
	{
		/// <summary>
		/// Constructs an instance of ManagerResponse based on a map of attributes.
		/// </summary>
		/// <param name="attributes">the attributes and their values. The keys of this map must be all lower case.</param>
		/// <returns>the response with the given attributes.</returns>
		public virtual ManagerResponse BuildResponse(IDictionary attributes)
		{
			ManagerResponse response;
			string responseType = ((string) attributes["response"]);

			// determine type
			if (responseType.ToLower() == "error")
				response = new ManagerError();
			else if (attributes.Contains("challenge"))
			{
				ChallengeResponse challengeResponse = new ChallengeResponse();
				challengeResponse.Challenge = ((string) attributes["challenge"]);
				response = challengeResponse;
			}
			else if (attributes.Contains("mailbox") && attributes.Contains("waiting"))
			{
				MailboxStatusResponse mailboxStatusResponse = new MailboxStatusResponse();
				mailboxStatusResponse.Mailbox = ((string) attributes["mailbox"]);
				if ((string) attributes["waiting"] == "1")
					mailboxStatusResponse.Waiting = true;
				else
					mailboxStatusResponse.Waiting = false;
				response = mailboxStatusResponse;
			}
			else if (attributes.Contains("mailbox") && attributes.Contains("newmessages") && attributes.Contains("oldmessages"))
			{
				MailboxCountResponse mailboxCountResponse = new MailboxCountResponse();
				mailboxCountResponse.Mailbox = ((string) attributes["mailbox"]);
				mailboxCountResponse.NewMessages = int.Parse((string) attributes["newmessages"]);
				mailboxCountResponse.OldMessages = int.Parse((string) attributes["oldmessages"]);
				response = mailboxCountResponse;
			}
			else if (attributes.Contains("exten") && attributes.Contains("context") && attributes.Contains("hint") && attributes.Contains("status"))
			{
				ExtensionStateResponse extensionStateResponse = new ExtensionStateResponse();
				extensionStateResponse.Exten = ((string) attributes["exten"]);
				extensionStateResponse.Context = ((string) attributes["context"]);
				extensionStateResponse.Hint = ((string) attributes["hint"]);
				extensionStateResponse.Status = int.Parse((string) attributes["status"]);
				response = extensionStateResponse;
			}
			else
				response = new ManagerResponse();

			// fill known attributes
			response.Response = responseType;
			
			// clone this map as it is reused by the ManagerReader
			response.Attributes = new Hashtable(attributes);
			
			if (attributes.Contains("actionid"))
				response.ActionId = ((string) attributes["actionid"]);
			if (attributes.Contains("message"))
				response.Message = ((string) attributes["message"]);
			if (attributes.Contains("uniqueid"))
				response.UniqueId = ((string) attributes["uniqueid"]);
	
			return response;
		}
	}
}