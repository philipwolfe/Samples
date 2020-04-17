using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Threading;

namespace Microsoft.NetFx35.Silver.Samples
{
	public sealed partial class Workflow1: SequentialWorkflowActivity
	{
		public Workflow1()
		{
			InitializeComponent();
		}

        public PurchaseOrder ReceivedPO = new Microsoft.NetFx35.Silver.Samples.PurchaseOrder();
        public String POAcknowledgement = default(System.String);

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("PO Received...");
            this.POAcknowledgement = "Order Received on " + DateTime.Now;
            this.sendActivity4.SetContext(this.BuyerContext);
        }

        private void PrepareUPSMessage(object sender, SendActivityEventArgs e)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("Sending Logsitics Quote request to UPS...");
            this.UPSContext = this.receiveActivity2.GetContext();
        }

        public System.Collections.Generic.IDictionary<System.Xml.XmlQualifiedName, String> UPSContext = default(System.Collections.Generic.IDictionary<System.Xml.XmlQualifiedName, System.String>);
        public LogisticsQuote UPSLogisticsQuote = new Microsoft.NetFx35.Silver.Samples.LogisticsQuote();

        private void PrepareFedExMessage(object sender, SendActivityEventArgs e)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("Sending Logsitics Quote request to FedEx...");
            this.FedExContext = this.receiveActivity3.GetContext();
        }

        public System.Collections.Generic.IDictionary<System.Xml.XmlQualifiedName, String> FedExContext = default(System.Collections.Generic.IDictionary<System.Xml.XmlQualifiedName, System.String>);
        public LogisticsQuote FedExLogisticsQuote = new Microsoft.NetFx35.Silver.Samples.LogisticsQuote();

        private void PrepareUSPSMessage(object sender, SendActivityEventArgs e)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("Sending Logsitics Quote request to USPS...");
            this.USPSContext = this.receiveActivity4.GetContext();
        }

        public System.Collections.Generic.IDictionary<System.Xml.XmlQualifiedName, String> USPSContext = default(System.Collections.Generic.IDictionary<System.Xml.XmlQualifiedName, System.String>);
        public LogisticsQuote USPSLogisticsQuote = new Microsoft.NetFx35.Silver.Samples.LogisticsQuote();
        public PurchaseOrder POToCustomer = new Microsoft.NetFx35.Silver.Samples.PurchaseOrder();
        public LogisticsQuote LogisticsQuoteToCustomer = new Microsoft.NetFx35.Silver.Samples.LogisticsQuote();

        private void PrepareCustomerMessage(object sender, SendActivityEventArgs e)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("Sending PO Shipping Confirmation Notice to Customer");
            LogisticsQuoteToCustomer = UPSLogisticsQuote;
            if (LogisticsQuoteToCustomer.shippingCost > FedExLogisticsQuote.shippingCost)
            {
                LogisticsQuoteToCustomer = FedExLogisticsQuote;
            }

            if (LogisticsQuoteToCustomer.shippingCost > USPSLogisticsQuote.shippingCost)
            {
                LogisticsQuoteToCustomer = USPSLogisticsQuote;
            }
        }

        public String UPSLogisticsAck = default(System.String);
        public String FedExLogisticsAck = default(System.String);
        public String USPSLogisticsAck = default(System.String);

        private void ReceiveFedexLogisticsQuote(object sender, EventArgs e)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("Received FedEx Logistics Quote...");
            Console.WriteLine("Shippiong Cost : " + FedExLogisticsQuote.shippingCost + " Likely Shipping Date : " + FedExLogisticsQuote.likelyShippingDate);
        }


        public System.Collections.Generic.IDictionary<System.Xml.XmlQualifiedName, String> BuyerContext = default(System.Collections.Generic.IDictionary<System.Xml.XmlQualifiedName, System.String>);

        private void codeActivity3_ExecuteCode_1(object sender, EventArgs e)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("Received UPS Logistics Quote...");
            Console.WriteLine("Shippiong Cost : " + UPSLogisticsQuote.shippingCost + " Likely Shipping Date : " + UPSLogisticsQuote.likelyShippingDate);

        }

        private void codeActivity4_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("Received USPS Logistics Quote...");
            Console.WriteLine("Shippiong Cost : " + USPSLogisticsQuote.shippingCost + " Likely Shipping Date : " + USPSLogisticsQuote.likelyShippingDate);

        }


	}

}
