//-----------------------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//-----------------------------------------------------------------------------
namespace Microsoft.Samples.SendSmtpMail
{
    using System;
    using System.Activities;
    using System.Collections.Generic;
    using System.Net.Mail;  

    // Sample client console application. You need an operational
    // SMTP server to run this sample
    class Program
    {
        static void Main(string[] args)
        {
            WorkflowInvoker.Invoke(CreateSendMailSampleWF());

            Console.ReadKey();
        }

        // Show how to send an email using SendMail activity. If you want to 
        // use an html template for the body, uncomment and set BodyTemplateFilePath property. 
        // If you want to configure a drop path for debug, uncomment and 
        // set TestDropPath property.
        static WorkflowElement CreateSendMailSampleWF()
        {
            string emailFromAddress = "john.doe@contoso.com";

            IDictionary<string, string> tokens = new Dictionary<string, string>();
            tokens.Add("@name", "John Doe" );
            tokens.Add("@date", DateTime.Now.ToString() );
            tokens.Add("@server", "localhost");            

            return new SendMail
            {  
                 To = new InArgument<MailAddressCollection>(new MailAddressCollection() { new MailAddress("someone@contoso.com") }),
                 From = new MailAddress(emailFromAddress),
                 Subject = "Test email",
                 Body = "Hello @name. This is a test email. Current date is @date",
                 Host = "localhost",
                 Port = 25,
                 Tokens = new InArgument<IDictionary<string,string>>(tokens),
                 // BodyTemplateFilePath = <you sample path>\Templates\MailTemplateBody.htm", 
                 // TestDropPath = <you sample path>\TestMailDropPath",
                 TestMailTo = new MailAddress(emailFromAddress)
            };
        }
    }
}