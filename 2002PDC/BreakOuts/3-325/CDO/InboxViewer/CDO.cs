//===========================================================================
//	File:		CDO.cs
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
using System.WinForms;

public class CDO
{
	static object currentSession; 		// MAPI.Session
	static object messageCollection; 	// MAPI.Messages
	static Type t;
	static int numMessages;

	//
	// CreateNewSession
	//
	public static Object CreateNewSession()
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
			MessageBox.Show("Unable to find ProgID \"MAPI.Session\".  CDO.DLL needs to be registered for this sample.", "Cannot Use Collaborative Data Objects");
			return null;
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
	// FillInMessages
	//
	public static void FillInMessages(InboxViewerForm form)
	{
		object inbox;
		object message;
		object sender;
		object senderName;
		object itemType;
		object subject;
		object received;

		numMessages = 0;
		string [] subinfo = new string[3];

		form.Text = "C# Inbox Viewer - Populating ListView with messages.....";

		//
		// Get the messages from the inbox
		//
		inbox = t.InvokeMember("Inbox", BindingFlags.GetProperty, null, currentSession, null);
		messageCollection = inbox.GetType().InvokeMember("Messages", BindingFlags.GetProperty, null, inbox, null);

		//
		// Get the first message
		//
		message = messageCollection.GetType().InvokeMember("GetFirst", BindingFlags.InvokeMethod, null, messageCollection, null);

		while (message != null)
		{
			numMessages++;

			itemType = message.GetType().InvokeMember("Type", BindingFlags.GetProperty, null, message, null);

			if (itemType.Equals("IPM.Note"))
			{
				// Get the sender's name
				sender = message.GetType().InvokeMember("Sender", BindingFlags.GetProperty, null, message, null);
				senderName = sender.GetType().InvokeMember("Name", BindingFlags.GetProperty, null, sender, null);

				// Get the subject
				subject = message.GetType().InvokeMember("Subject", BindingFlags.GetProperty, null, message, null);
				subinfo[0] = subject.ToString();

				// Get the received date/time
				received = message.GetType().InvokeMember("TimeReceived", BindingFlags.GetProperty, null, message, null);
				subinfo[1] = received.ToString();

				subinfo[2] = numMessages.ToString();

				form.listView1.InsertItem(0, senderName.ToString(), 0, subinfo);

				// Let the window process other messages
				if (numMessages % 10 == 0)
					Application.DoEvents();
			}
			// Get the next message
			message = messageCollection.GetType().InvokeMember("GetNext", BindingFlags.InvokeMethod, null, messageCollection, null);
		}

		form.Text = "C# Inbox Viewer - " + numMessages.ToString() + " Messages";
	}

	//
	// GetMessageDetails
	//
	public static string [] GetMessageDetails(string indexString)
	{
		object message;		// MAPI.Message
		object recipients; 	// MAPI.Recipients
		object recipient;
		object recipientName;
		object recipientType;

		string [] details = new string[4];
		int count;

		int index = ((IConvertible)(indexString)).ToInt32();

		try
		{
			//
			// Get the requested message
			//
			object [] args = new object[1];
			args[0] = index;

			// Invoke the default property (Item)
			message = messageCollection.GetType().InvokeMember("", BindingFlags.GetProperty, null, messageCollection, args);

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
		}
		catch (Exception e)
		{
			MessageBox.Show("Caught Exception: " + e.ToString(), "Unexpected Exception");
		}

		return details;
	}

	//
	// Logoff
	//
	public static void Logoff()
	{
		t.InvokeMember("Logoff", BindingFlags.InvokeMethod, null, currentSession, null);
	}
}