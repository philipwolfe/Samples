namespace System.ServiceModel.Samples.CustomChannelsTester
{
    using System;
    using System.Collections.Generic;
    using System.Collections.ObjectModel;
    using System.Diagnostics;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Text;
    using System.Threading;
    using System.Xml;
    using System.Xml.Schema;
    using System.Xml.XPath;
    
    public class TestRunner
    {
        Thread serverThread = null, clientThread = null;


        public bool Run()
        {
            //validate and load test specs from XML file to Parameters
            Loader specLoader = new Loader();
            specLoader.LoadSpec(Parameters.InputFileName);

            //update the parameters based on the options specified by the user
            specLoader.UpdateParameters();
            
            //start the server on this machine if ServerMachineName matches the current machine name
            if (Parameters.ServerMachineName.Contains(Environment.MachineName.ToLower()))
            {
                serverThread = new Thread(new ThreadStart(ExecuteServer));
                serverThread.Name = "Server";
                serverThread.Start();
            }
            clientThread = new Thread(new ThreadStart(ExecuteClient));
            clientThread.Name = "Client";
            clientThread.Start();
            clientThread.Join();
            if (serverThread != null)
                serverThread.Join();                
            return Parameters.Result;
        }

        //Server
        private void ExecuteServer()
        {
            Server server = new Server();
            server.ExecuteServer();
        }

        //Client
        private void ExecuteClient()
        {
            Client client = new Client();
            client.ExecuteClient();
        }


    }
}
