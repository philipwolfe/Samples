namespace Microsoft.ServiceModel.Samples
{
    using System;
    using System.Configuration;
    using System.Messaging;
    using System.ServiceModel;
    using System.Transactions;

    class ClientApplication
    {
        static void Main()
        {
            string queueName = ConfigurationManager.AppSettings["destinationQueueName"];
            if (! MessageQueue.Exists(queueName))
                MessageQueue.Create(queueName, true);

            using (DatagramOrderTakerClient proxy = new DatagramOrderTakerClient("orderTakerEndpoint"))
            {
                PurchaseOrder po = new PurchaseOrder();
                po.CustomerId = "somecustomer.com";

                po.Items = new PurchaseOrderLineItem[2];
                po.Items[0] = new PurchaseOrderLineItem();
                po.Items[0].ProductId = "Blue Widget";
                po.Items[0].Quantity = 54;
                po.Items[0].UnitCost = 29.99F;

                po.Items[1] = new PurchaseOrderLineItem();
                po.Items[1].ProductId = "Red Widget";
                po.Items[1].Quantity = 890;
                po.Items[1].UnitCost = 45.89F;

                using (TransactionScope scope = new TransactionScope(TransactionScopeOption.Required))
                {
                    proxy.SubmitPurchaseOrder(po);
                    scope.Complete();
                }

                Console.WriteLine("Purchase order sent");
            }
        }
    }
}
