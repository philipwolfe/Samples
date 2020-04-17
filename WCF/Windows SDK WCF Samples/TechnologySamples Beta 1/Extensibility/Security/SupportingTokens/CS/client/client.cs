
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;

using System.ServiceModel.Channels;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;

namespace Microsoft.ServiceModel.Samples.SupportingTokens
{
    //Client implementation code.
    class Client
    {
        static void Main()
        {
            // Create the custom binding and an endpoint address for the service.
            Binding multipleTokensBinding = BindingHelper.CreateMultiFactorAuthenticationBinding();
            EndpointAddress serviceAddress = new EndpointAddress("http://localhost/servicemodelsamples/service.svc");

            Console.WriteLine("Username authentication required.");
            Console.WriteLine("Provide a valid machine or domain account. [domain\\user]");
            Console.WriteLine("   Enter username:");
            string username = Console.ReadLine();
            Console.WriteLine("   Enter password:");
            string password = "";
            ConsoleKeyInfo info = Console.ReadKey(true);
            while (info.Key != ConsoleKey.Enter)
            {
                if (info.Key != ConsoleKey.Backspace)
                {
                    if (info.KeyChar != '\0')
                    {
                        password += info.KeyChar;
                    }
                    info = Console.ReadKey(true);
                }
                else if (info.Key == ConsoleKey.Backspace)
                {
                    if (password != "")
                    {
                        password = password.Substring(0, password.Length - 1);

                    }
                    info = Console.ReadKey(true);
                }
            }

            for (int i = 0; i < password.Length; i++)
                Console.Write("*");

            Console.WriteLine();

            try
            {
                // Create a proxy with the previously create binding and endpoint address
                using (ChannelFactory<IEchoService> channelFactory = new ChannelFactory<IEchoService>(multipleTokensBinding, serviceAddress))
                {
                    // configure the username credentials, the client certificate and the server certificate on the channel factory 
                    channelFactory.Credentials.UserName.UserName = username;
                    channelFactory.Credentials.UserName.Password = password;

                    channelFactory.Credentials.ClientCertificate.SetCertificate("CN=Alice", StoreLocation.CurrentUser, StoreName.My);
                    channelFactory.Credentials.ServiceCertificate.SetDefaultCertificate("CN=localhost", StoreLocation.LocalMachine, StoreName.My);

                    using (IEchoService proxy = channelFactory.CreateChannel())
                    {
                        Console.WriteLine("Echo service returned: {0}", proxy.Echo());
                    }

                }
            }
            catch (CommunicationException e)
            {
                // if there is a fault then print it out
                FaultException fe = null;
                Exception tmp = e;
                while (tmp != null)
                {
                    fe = tmp as FaultException;
                    if (fe != null)
                    {
                        break;
                    }
                    tmp = tmp.InnerException;
                }
                if (fe != null)
                {
                    Console.WriteLine("The server sent back a fault: {0}", fe.CreateMessageFault().Reason.GetMatchingTranslation().Text);
                }
                else
                {
                    Console.WriteLine("The request failed with exception: {0}", e);
                }
            }
            catch (TimeoutException)
            {
                Console.WriteLine("The request timed out");
            }
            catch (Exception e)
            {
                Console.WriteLine("The request failed with unexpected exception: {0}", e);
            }

            Console.WriteLine();
            Console.WriteLine("Press <ENTER> to terminate client.");
            Console.ReadLine();
        }
    }
}
