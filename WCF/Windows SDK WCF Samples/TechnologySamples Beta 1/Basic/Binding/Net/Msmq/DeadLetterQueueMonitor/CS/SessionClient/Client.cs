namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.Configuration;
    using System.Messaging;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Transactions;

    class SessionOrderTakerClient : ClientBase<ISessionOrderTaker>, ISessionOrderTaker
    {
        SessionOrderTakerClient(string name)
            : base(name)
        {}

        static void Main()
        {
            string queueName = ConfigurationManager.AppSettings["destinationQueueName"];
            if (! MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            using (SessionOrderTakerClient proxy = new SessionOrderTakerClient("orderTakerEndpoint"))
            {
                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    proxy.StartPurchaseOrder("othercustomer.com");

                    PurchaseOrderLineItem item = new PurchaseOrderLineItem();
                    item.ProductId = "Green Widget";
                    item.Quantity = 22;
                    item.UnitCost = 19.95F;
                    proxy.AddLineItem(item);

                    item.ProductId = "Yellow Widget";
                    item.Quantity = 7;
                    item.UnitCost = 59.99F;
                    proxy.AddLineItem(item);

                    proxy.EndPurchaseOrder();
                    proxy.Close();

                    scope.Complete();
                }

            }

            Console.WriteLine("Purchase order sent");
        }

        public void StartPurchaseOrder(string customer)
        {
            this.Channel.StartPurchaseOrder(customer);
        }

        public void AddLineItem(PurchaseOrderLineItem item)
        {
            this.Channel.AddLineItem(item);
        }

        public void EndPurchaseOrder()
        {   this.Channel.EndPurchaseOrder();
        }
    }
}
