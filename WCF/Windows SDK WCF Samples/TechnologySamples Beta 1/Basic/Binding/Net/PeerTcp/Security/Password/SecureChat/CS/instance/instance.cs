
//  Copyright (c) Microsoft Corporation.  All Rights Reserved.

using System;
using System.ServiceModel.Channels;
using System.Configuration;
using System.Security;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.ServiceModel;


// Multi-party chat application using Peer Channel (a multi-party channel)
// If you are unfamiliar with new concepts used in this sample, refer to the WCF Basic\GettingStarted sample.

namespace Microsoft.ServiceModel.Samples
{
    // Chat service contract
    // Applying [PeerBehavior] attribute on the service contract enables retrieval of PeerNode from IClientChannel.
    [ServiceContract(Namespace = "http://Microsoft.ServiceModel.Samples", CallbackContract = typeof(IChat))]
    public interface IChat
    {
        [OperationContract(IsOneWay = true)]
        void Join(string member);

        [OperationContract(IsOneWay = true)]
        void Chat(string member, string msg);

        [OperationContract(IsOneWay = true)]
        void Leave(string member);
    }

    public interface IChatChannel : IChat, IClientChannel
    {
    }

    public class ChatApp : IChat
    {
        // Host the chat instance within this EXE console application.
        public static void Main(string[] args)
        {

            if (args.Length != 1)
            {
                Console.WriteLine("please specify a password");
                return;
            }
            // Get the memberId from configuration
            string member = ConfigurationManager.AppSettings["member"];

            // Construct InstanceContext to handle messages on callback interface. 
            // An instance of ChatApp is created and passed to the InstanceContext.
            InstanceContext site = new InstanceContext(new ChatApp());

            // Create the participant with the given endpoint configuration
            // Each participant opens a duplex channel to the mesh
            // participant is an instance of the chat application that has opened a channel to the mesh
            NetPeerTcpBinding binding = new NetPeerTcpBinding("SecureChatBinding");

            ChannelFactory<IChatChannel> cf = new DuplexChannelFactory<IChatChannel>(site, "SecureChatEndpoint");

            //for PeerAuthenticationMode.Password, you need to specify a password
            cf.Credentials.Peer.MeshPassword = args[0];
            IChatChannel participant = cf.CreateChannel();

            // Retrieve the PeerNode associated with the participant and register for online/offline events
            // PeerNode represents a node in the mesh. Mesh is the named collection of connected nodes.
            IOnlineStatus ostat = participant.GetProperty<IOnlineStatus>();
            ostat.Online += new EventHandler(OnOnline);
            ostat.Offline += new EventHandler(OnOffline);

            Console.WriteLine("{0} is ready", member);
            Console.WriteLine("Press <ENTER> to send the chat message.");
            // Announce self to other participants
            participant.Join(member);
            Console.ReadLine();
            participant.Chat(member, "Hi there - I am chatting");
            Console.WriteLine("Press <ENTER> to terminate this instance of chat.");
            Console.ReadLine();
            // Leave the mesh and close the proxy
            participant.Leave(member);

            ((IChannel)participant).Close();
            cf.Close();
        }

        // IChat implementation
        public void Join(string member)
        {
            Console.WriteLine("{0} joined", member);
        }

        public void Chat(string member, string msg)
        {
            Console.WriteLine("[{0}] {1}", member, msg);
        }

        public void Leave(string member)
        {
            Console.WriteLine("[{0} left]", member);
        }

        // PeerNode event handlers
        static void OnOnline(object sender, EventArgs e)
        {
            Console.WriteLine("** Online");
        }

        static void OnOffline(object sender, EventArgs e)
        {
            Console.WriteLine("** Offline");
        }

        static internal X509Certificate2 GetCertificate(StoreName storeName, StoreLocation storeLocation, string key, X509FindType findType)
        {
            X509Certificate2 result;

            X509Store store = new X509Store(storeName, storeLocation);
            store.Open(OpenFlags.ReadOnly);
            try
            {
                X509Certificate2Collection matches;
                matches = store.Certificates.Find(findType, key, false);
                if (matches.Count > 1)
                    throw new InvalidOperationException(String.Format("More than one certificate with key '{0}' found in the store.", key));
                if (matches.Count == 0)
                    throw new InvalidOperationException(String.Format("No certificates with key '{0}' found in the store.", key));
                result = matches[0];
            }
            finally
            {
                store.Close();
            }

            return result;
        }

    }
}
