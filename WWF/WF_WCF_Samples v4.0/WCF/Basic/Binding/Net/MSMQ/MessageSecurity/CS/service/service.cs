﻿//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Messaging;
using System.Net.Security;
using System.Runtime.Serialization;
using System.ServiceModel;

namespace Microsoft.Samples.MSMQMessageSecurity
{
    // Define the Purchase Order Line Item
    [DataContract(Namespace = "http://Microsoft.Samples.MSMQMessageSecurity")]
    public class PurchaseOrderLineItem
    {
        [DataMember]
        public string ProductId;

        [DataMember]
        public float UnitCost;

        [DataMember]
        public int Quantity;

        public override string ToString()
        {
            String displayString = "Order LineItem: " + Quantity + " of "  + ProductId + " @unit price: $" + UnitCost + "\n";
            return displayString;
        }

        public float TotalCost
        {
            get { return UnitCost * Quantity; }
        }
    }

    // Define Purchase Order
    [DataContract(Namespace = "http://Microsoft.Samples.MSMQMessageSecurity")]
    public class PurchaseOrder
    {
        static string[] OrderStates = { "Pending", "Processed", "Shipped" };
        static Random statusIndexer = new Random(137);

        [DataMember]
        public string PONumber;

        [DataMember]
        public string CustomerId;

        [DataMember]
        public PurchaseOrderLineItem[] orderLineItems;

        public float TotalCost
        {
            get
            {
                float totalCost = 0;
                foreach (PurchaseOrderLineItem lineItem in orderLineItems)
                    totalCost += lineItem.TotalCost;
                return totalCost;
            }
        }

        public string Status
        {
            get 
            {
                return OrderStates[statusIndexer.Next(3)];
            }
        }

        public override string ToString()
        {
            System.Text.StringBuilder strbuf = new System.Text.StringBuilder("Purchase Order: " + PONumber + "\n");
            strbuf.Append("\tCustomer: " + CustomerId + "\n");
            strbuf.Append("\tOrderDetails\n");

            foreach (PurchaseOrderLineItem lineItem in orderLineItems)
            {
                strbuf.Append("\t\t" + lineItem.ToString());
            }

            strbuf.Append("\tTotal cost of this order: $" + TotalCost + "\n");
            strbuf.Append("\tOrder status: " + Status + "\n");
            return strbuf.ToString();
        }
    }

    // Order Processing Logic
    // Can replace with transaction-aware resource such as SQL, transacted hashtable to hold orders
    // This example uses a non-transactional resource
    public class Orders
    {
        static Dictionary<string, PurchaseOrder> purchaseOrders = new Dictionary<string, PurchaseOrder>();

        public static void Add(PurchaseOrder po)
        {
            purchaseOrders.Add(po.PONumber, po);
        }

        public static string GetOrderStatus(string poNumber)
        {
            PurchaseOrder po;
            if (purchaseOrders.TryGetValue(poNumber, out po))
                return po.Status;
            else
                return null;
        }

        public static void DeleteOrder(string poNumber)
        {
            if(purchaseOrders[poNumber] != null)
                purchaseOrders.Remove(poNumber);
        }
    }


    // Define a service contract. 
    [ServiceContract(Namespace="http://Microsoft.Samples.MSMQMessageSecurity")]
    public interface IOrderProcessor
    {
        [OperationContract(IsOneWay = true, ProtectionLevel=ProtectionLevel.EncryptAndSign)]
        void SubmitPurchaseOrder(PurchaseOrder po);
    }

    // Service class which implements the service contract.
    // Added code to write output to the console window
    public class OrderProcessorService : IOrderProcessor
    {
        private string GetCallerIdentity()
        {
            // The client certificate is not mapped to a Windows identity by default
            // ServiceSecurityContext.PrimaryIdentity is populated based on the information
            // in the certificate that the client used to authenticate itself to the service
            return ServiceSecurityContext.Current.PrimaryIdentity.Name;
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitPurchaseOrder(PurchaseOrder po)
        {
            Console.WriteLine("Client's Identity {0} ", GetCallerIdentity());
            Orders.Add(po);
            Console.WriteLine("Processing {0} ", po);
        }


        // Host the service within this EXE console application.
        public static void Main()
        {
            // Get MSMQ queue name from app settings in configuration
            string queueName = ConfigurationManager.AppSettings["queueName"];

            // Create the transacted MSMQ queue if necessary.
            if (!MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            // Create a ServiceHost for the OrderProcessorService type.
            ServiceHost serviceHost = new ServiceHost(typeof(OrderProcessorService));

            // Hook on to the service host faulted events
            serviceHost.Faulted += new EventHandler(OnServiceFaulted);

            // Open the ServiceHost to create listeners and start listening for messages.
            serviceHost.Open();

            // The service can now be accessed.
            Console.WriteLine("The service is ready.");
            Console.WriteLine("Press <ENTER> to terminate service.");
            Console.WriteLine();
            Console.ReadLine();

            try
            {
                // Close the ServiceHostB to shutdown the service.
                serviceHost.Close();
            }
            catch (CommunicationObjectFaultedException)
            {
                Console.WriteLine(" Service cannot be closed...it already faulted");
            }   

        }

        public static void OnServiceFaulted(object sender, EventArgs e) 
        {
            Console.WriteLine("Service Faulted. This could be because the message could be poisoned. Ensure that proper security credentials are installed");
        }

    }

}

