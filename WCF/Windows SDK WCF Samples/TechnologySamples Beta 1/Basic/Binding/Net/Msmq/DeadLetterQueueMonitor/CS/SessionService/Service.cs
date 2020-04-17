namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.Collections.Generic;
    using System.Configuration;
    using System.Messaging;
    using System.ServiceModel;
    using System.Runtime.Serialization;
    using System.Text;

    // Define the purchase order
    [DataContract]
    public class PurchaseOrder 
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
    
    [ServiceContract(SessionMode=SessionMode.Required)]
    public interface ISessionOrderTaker
    {
        [OperationContract(IsOneWay = true, Action="http://tempuri.org/ISessionOrderTaker/StartPurchaseOrder")]
        void StartPurchaseOrder(string customerId);

        [OperationContract(IsOneWay = true, Action="http://tempuri.org/ISessionOrderTaker/AddLineItem")]
        void AddLineItem(Microsoft.ServiceModel.Samples.PurchaseOrderLineItem lineItem);

        [OperationContractAttribute(IsOneWay = true, Action="http://tempuri.org/ISessionOrderTaker/EndPurchaseOrder")]
        void EndPurchaseOrder();
    }

    [ServiceBehavior(InstanceContextMode=InstanceContextMode.PerSession, AddressFilterMode=AddressFilterMode.Any)]
    class SessionService : ISessionOrderTaker
    {
        List<PurchaseOrderLineItem> lineItems = new List<PurchaseOrderLineItem>();


        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void StartPurchaseOrder(string customer)
        {
            Console.WriteLine("Purchase order received (session)");
            Console.WriteLine("  CustomerId: {0}", customer ?? "unspecified customer");
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = false)]
        public void AddLineItem(PurchaseOrderLineItem item)
        {
            lineItems.Add(item);
        }

        [OperationBehavior(TransactionScopeRequired = true, TransactionAutoComplete = true)]
        public void EndPurchaseOrder()
        {
            foreach (PurchaseOrderLineItem item in this.lineItems)
            {
                Console.WriteLine("    {0} of '{1}' @ ${2:.00}", 
                                  item.Quantity,
                                  item.ProductId ?? "unspecified product",
                                  item.UnitCost);
            }
            Console.WriteLine();
        }

        static void Main()
        {
            string queueName = ConfigurationManager.AppSettings["queueName"];
            if (! MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            using (ServiceHost serviceHost = new ServiceHost(typeof(SessionService)))
            {
                serviceHost.Open();

                Console.WriteLine("The dead letter service to read session messages is ready.");
                Console.WriteLine("Press <ENTER> to terminate service.");
                Console.WriteLine();
                Console.ReadLine();

                serviceHost.Close();
            }
        }
    }
}
    
