namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.Configuration;
    using System.Messaging;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Runtime.Serialization;
    using System.Text;

    // Define the purchase order
   [DataContract]
   public  class PurchaseOrder
    {
        private string CustomerIdField;
        private PurchaseOrderLineItem[] ItemsField;

       [DataMember]
        public string CustomerId
        {
            get
            {
                return this.CustomerIdField;
            }
            set
            {
                this.CustomerIdField = value;
            }
        }

        [DataMember]
        public PurchaseOrderLineItem[] Items
        {
            get
            {
                return this.ItemsField;
            }
            set
            {
                this.ItemsField = value;
            }
        }
    }

    [DataContract]
    public class PurchaseOrderLineItem 
    {
        private string ProductIdField;
        private int QuantityField;
        private float UnitCostField;

        [DataMember]
        public string ProductId
        {
            get
            {
                return this.ProductIdField;
            }
            set
            {
                this.ProductIdField = value;
            }
        }

        [DataMember]
        public int Quantity
        {
            get
            {
                return this.QuantityField;
            }
            set
            {
                this.QuantityField = value;
            }
        }

        [DataMember]
        public float UnitCost
        {
            get
            {
                return this.UnitCostField;
            }
            set
            {
                this.UnitCostField = value;
            }
        }
    }

    [ServiceContract]
    public interface IDatagramOrderTaker
    {
        [OperationContract(IsOneWay = true, Action = "http://tempuri.org/IDatagramOrderTaker/SubmitPurchaseOrder")]
        void SubmitPurchaseOrder(PurchaseOrder purchaseOrder);
    }

    [ServiceBehavior(AddressFilterMode=AddressFilterMode.Any)]
    class DatagramService : IDatagramOrderTaker
    {
        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void SubmitPurchaseOrder(PurchaseOrder purchaseOrder)
        {
            Console.WriteLine("Purchase order received (datagram)");
            Console.WriteLine("  CustomerId: {0}", purchaseOrder.CustomerId ?? "unspecified customer");
            if (null != purchaseOrder.Items)
            {
                foreach (PurchaseOrderLineItem item in purchaseOrder.Items)
                {
                    Console.WriteLine("    {0} of '{1}' @ ${2:.00}", 
                                      item.Quantity,
                                      item.ProductId ?? "unspecified product",
                                      item.UnitCost);
                }
            }
            Console.WriteLine();
        }

        static void Main()
        {
            string queueName = ConfigurationManager.AppSettings["queueName"];
            if (! MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            using (ServiceHost serviceHost = new ServiceHost(typeof(DatagramService)))
            {
                serviceHost.Open();

                Console.WriteLine("The dead letter service to read datagram messages is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                serviceHost.Close();
            }
        }
    }
}
