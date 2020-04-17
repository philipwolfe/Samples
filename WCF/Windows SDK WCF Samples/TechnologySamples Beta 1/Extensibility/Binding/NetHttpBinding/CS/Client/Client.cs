using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;
using System.Text;

using Microsoft.Samples.Channels;

namespace Microsoft.ServiceModel.Samples.Client
{
    class Client
    {
        static void Main(string[] args)
        {
            string uri = "https://" + Environment.MachineName + ":8443/TestService/BinaryEncoderOverHTTPS";
            ServicePointManager.ServerCertificateValidationCallback = new RemoteCertificateValidationCallback(IgnoreSubjectNameMismatch);
            if (args.Length > 0)
            {
                uri = args[0];
            }
            EndpointAddress address = new EndpointAddress(uri);
            //NetHttpBinding binding = new NetHttpBinding(NetHttpSecurityMode.TransportCredentialOnly);
            NetHttpBinding binding = new NetHttpBinding();
            ChannelFactory<IEchoService> factory = new ChannelFactory<IEchoService>(binding, address);
            factory.Open();
            IEchoService service = factory.CreateChannel();
            Console.WriteLine(service.Echo(new string('a', 1024)));

            Console.WriteLine("called service successfully using binding in code");

            factory = new ChannelFactory<IEchoService>("EchoServer");
            //binding = new NetHttpBinding("netHttpBinding");
            //factory = new ChannelFactory<IEchoService>(binding);
            factory.Open();
            service = factory.CreateChannel();
            Console.WriteLine(service.Echo(new string('b', 1024)));
            Console.WriteLine("called service successfully using binding from config. Press enter to exit...");

            Console.ReadLine();
        }
        static bool IgnoreSubjectNameMismatch(object obj, X509Certificate certificate, X509Chain chain, SslPolicyErrors errors)
        {
            if (certificate == null)
            {
                return false;
            }
            return (errors == SslPolicyErrors.RemoteCertificateNameMismatch || errors == SslPolicyErrors.None);
        }
    }
}
