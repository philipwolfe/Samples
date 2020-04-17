using System;
using System.ComponentModel;
using System.ComponentModel.Design;
using System.Collections.Generic;
using System.Drawing;
using System.Workflow.ComponentModel.Compiler;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Workflow.ComponentModel.Design;
using System.Workflow.Runtime;
using System.Workflow.Activities;
using System.Workflow.Activities.Rules;
using System.Threading;
using System.Xml;

namespace Microsoft.WorkflowServices.Samples
{
	public sealed partial class SupplierWorkflow: SequentialWorkflowActivity
	{
		public SupplierWorkflow()
		{
			InitializeComponent();
		}

        public PurchaseOrder order = new PurchaseOrder();
        public string supplierAck = default(string);
        public IDictionary<XmlQualifiedName, string> customerContext = default(IDictionary<XmlQualifiedName, string>);

        private void AcceptOrder(object sender, EventArgs e)
        {
            Console.WriteLine("Order Received...");
            this.supplierAck = "Order Received on " + DateTime.Now;
            this.SendOrderDetails.SetContext(this.customerContext);
        }

        public IDictionary<XmlQualifiedName, string> contextUPS = default(IDictionary<XmlQualifiedName, string>);
        public ShippingQuote quoteUPS = new ShippingQuote();

        private void PrepareUPSRequest(object sender, SendActivityEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("RequestShippingQuote from UPS");
            Console.ResetColor();
            this.contextUPS = this.ReceiveQuoteFromUPS.GetContext();
        }

        public IDictionary<XmlQualifiedName, string> contextFedEx = default(IDictionary<XmlQualifiedName, string>);
        public ShippingQuote quoteFedEx = new ShippingQuote();

        private void PrepareFedExRequest(object sender, SendActivityEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("RequestShippingQuote from Fedex");
            Console.ResetColor();
            this.contextFedEx = this.ReceiveQuoteFromFedex.GetContext();
        }

        public IDictionary<XmlQualifiedName, string> contextUSPS = default(IDictionary<XmlQualifiedName, string>);
        public ShippingQuote quoteUSPS = new ShippingQuote();
        
        private void PrepareUSPSRequest(object sender, SendActivityEventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("RequestShippingQuote from Fedex");
            Console.ResetColor();
            this.contextUSPS = this.ReceiveQuoteFromUSPS.GetContext();
        }

        public PurchaseOrder confirmedOrder = new PurchaseOrder();
        public ShippingQuote confirmedQuote = new ShippingQuote();

        private void PrepareOrderConfirmation(object sender, SendActivityEventArgs e)
        {
            Console.WriteLine("Send OrderConfirmation to Customer");
            confirmedQuote = quoteUPS;
            if (confirmedQuote.ShippingCost > quoteFedEx.ShippingCost)
                confirmedQuote = quoteFedEx;
            if (confirmedQuote.ShippingCost > quoteUSPS.ShippingCost)
                confirmedQuote = quoteUSPS;
        }

        public string ackUPS = default(string);
        public string ackFedEx = default(string);
        public string ackUSPS = default(string);

        private void ReceiveUPSShippingQuote(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Received UPS ShippingQuote");
            Console.WriteLine("Cost: $" + quoteUPS.ShippingCost);
            Console.WriteLine("ShipDate: " + quoteUPS.EstimatedShippingDate);
            Console.ResetColor();
        }

        private void ReceiveFedexShippingQuote(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Received Fedex ShippingQuote");
            Console.WriteLine("Cost: $" + quoteFedEx.ShippingCost);
            Console.WriteLine("ShipDate: " + quoteFedEx.EstimatedShippingDate);
            Console.ResetColor();
        }

        private void ReceiveUSPSShippingQuote(object sender, EventArgs e)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("Received USPS ShippingQuote");
            Console.WriteLine("Cost: $" + quoteUSPS.ShippingCost);
            Console.WriteLine("ShipDate: $" + quoteUSPS.EstimatedShippingDate);
            Console.ResetColor();
        }

	}

}
