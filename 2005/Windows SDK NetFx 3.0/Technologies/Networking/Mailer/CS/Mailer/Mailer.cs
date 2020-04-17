//---------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//---------------------------------------------------------------------

using System;
using System.Net.Mail;

namespace Microsoft.Samples.Mailer
{

	// Mailer sends an e-mail.  
	// It will authenticate using Windows authentication if the server
    // (i.e. Exchange) requests it.
	static class Mailer
	{
        enum MailMessagePart
        {
            From,
            To,
            Subject,
            Message
        }

		static void Main(string[] args)
		{
			if (args.Length < 4)
			{	
				Console.WriteLine(
                    "Expected: mailer.exe [from] [to] [subject] [message]");
				return;
			}

			// Set mailServerName to be the name of the mail server
			// you wish to use to deliver this message
            string mailServerName = "smtphost";
			string from = args[(int) MailMessagePart.From];
			string to = args[(int) MailMessagePart.To];
			string subject = args[(int) MailMessagePart.Subject];
			string body = args[(int) MailMessagePart.Message];

            try
            {
                // MailMessage is used to represent the e-mail being sent
                using (MailMessage message = 
                    new MailMessage(from, to, subject, body))
                {

                    // SmtpClient is used to send the e-mail
					SmtpClient mailClient = new SmtpClient(mailServerName);

					// UseDefaultCredentials tells the mail client to use the 
                    // Windows credentials of the account (i.e. user account) 
                    // being used to run the application
                    mailClient.UseDefaultCredentials = true;

                    // Send delivers the message to the mail server
                    mailClient.Send(message);
                }
                Console.WriteLine("Message sent.");
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
            }
            catch (SmtpException ex)
            {
                Console.WriteLine(ex.Message);
            }
		}
	}
}
