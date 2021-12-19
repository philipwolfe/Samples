//===========================================================================
//	File:		CDODataProvider.cs
//
//	Summary:	Interacts with a COM component (CDO.DLL) via
//				late-binding, since it contains all dispinterfaces.
//
//---------------------------------------------------------------------------
//	Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
//===========================================================================
using System;
using System.Reflection;
using System.Threading;

public class CDODataProvider
{
	object currentSession; // MAPI.Session
	Type t;

	//
	// CreateNewSession
	//
	public Object CreateNewSession()
	{
		//
		// Step 1 - Set apartment model
		//
		Thread.CurrentThread.ApartmentState = ApartmentState.STA;

		//
		// Step 2 - Create instance
		//

		t = Type.GetTypeFromProgID("MAPI.Session");
		if (t == null)
		{
			throw new Exception("Unable to find ProgID \"MAPI.Session\".  CDO.DLL needs to be registered for this sample.");
		}

		currentSession = Activator.CreateInstance(t);

		//
		// NOTE: All of the interfaces in CDO.DLL are dispinterfaces, so we can only call them via late-binding.
		//

		//
		// Step 3 - Logon
		//

		Object [] args = new Object[7];
		args[0] = Missing.Value;	// ProfileName
		args[1] = Missing.Value;	// ProfilePassword
		args[2] = Missing.Value;	// ShowDialog
		args[3] = Missing.Value;	// NewSession
		args[4] = Missing.Value;	// ParentWindow
		args[5] = Missing.Value;	// NoMail
		args[6] = Missing.Value;	// ProfileInfo

		t.InvokeMember("Logon", BindingFlags.InvokeMethod, null, currentSession, args);

		return currentSession;
	}

	//
	// GetMessageInfo
	//
	public string [] GetMessageInfo(object message)
	{
		object sender;
		object senderName;
		object received;

		string [] messageInfo = new string[3];
		object [] args = new object[1];

		// Get the sender's name
		sender = message.GetType().InvokeMember("Sender", BindingFlags.GetProperty, null, message, null);
		senderName = sender.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, sender, null);
		messageInfo[0] = senderName.ToString();

		// Get the subject
		messageInfo[1] = (string)message.GetType().InvokeMember("Subject", BindingFlags.GetProperty, null, message, null);

		// Get the received date/time
		received = message.GetType().InvokeMember("TimeReceived", BindingFlags.GetProperty, null, message, null);
		messageInfo[2] = received.ToString();

		return messageInfo;
	}

	//
	// GetMessageDetails
	//
	public string [] GetMessageDetails(object message)
	{
		object recipients; 	// MAPI.Recipients
		object recipient;
		object recipientName;
		object recipientType;

		object [] args = new object[1];
		string [] details = new string[4];
		int count;

		// Get the message text
		details[0] = (string)message.GetType().InvokeMember("Text", BindingFlags.GetProperty, null, message, null);

		// Get the recipient(s)
		recipients = message.GetType().InvokeMember("Recipients", BindingFlags.GetProperty, null, message, null);
		count = (int)recipients.GetType().InvokeMember("Count", BindingFlags.GetProperty, null, recipients, null);
			
		details[1] = "";
		details[2] = "";

		for (int i = 1; i <= count; i++)
		{
			// Get the recipient's name
			args[0] = i;
			recipient = recipients.GetType().InvokeMember("", BindingFlags.GetProperty, null, recipients, args);
			if (recipient != null)
			{
				recipientName = recipient.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, recipient, null);

				// Figure out if the recipient was on the To: or Cc:/Bcc: line

				recipientType = recipient.GetType().InvokeMember("Type", BindingFlags.GetProperty, null, recipient, null);

				if ((int)recipientType == 1) // CdoTo
				{
					if (details[1] == "")
						details[1] = (string)recipientName;
					else
						details[1] = details[1] + "; " + (string)recipientName;
				}
				else if ((int)recipientType == 2) // CdoCc
				{
					if (details[2] == "")
						details[2] = (string)recipientName;
					else
						details[2] = details[1] + "; " + (string)recipientName;
				}
				else // CdoBcc
				{
					if (details[2] == "")
						details[2] = "<BCC: " + (string)recipientName + ">";
					else
						details[2] = details[1] + "; " + "<BCC: " + (string)recipientName + ">";
				}
			}
		}

		// Get the sent date/time
		DateTime sent = (DateTime)message.GetType().InvokeMember("TimeSent", BindingFlags.GetProperty, null, message, null);
		details[3] = sent.ToString();

		return details;
	}

	//
	// Logoff
	//
	public void Logoff()
	{
		t.InvokeMember("Logoff", BindingFlags.InvokeMethod, null, currentSession, null);
	}
}