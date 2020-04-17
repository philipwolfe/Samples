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

namespace Microsoft.NetFx35.Silver.Samples
{
	public sealed partial class POCustomer : SequentialWorkflowActivity
	{
        public POCustomer()
		{
			InitializeComponent();
		}

        public PurchaseOrder PORequest = new Microsoft.NetFx35.Silver.Samples.PurchaseOrder();
        public String SellerAck = default(System.String);

        private void PrepareMessage(object sender, SendActivityEventArgs e)
        {
            this.PORequest.POAmount = 1000;
            this.PORequest.POnumber = 1234;
            this.contextToSend = this.receiveActivity1.GetContext();
        }

        public PurchaseOrder POReceived = new Microsoft.NetFx35.Silver.Samples.PurchaseOrder();
        public LogisticsQuote ReceivedLogisticsQuote = new Microsoft.NetFx35.Silver.Samples.LogisticsQuote();
        public String BuyerAck = default(System.String);

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {

            Console.WriteLine("=============================================");
            Console.WriteLine("Order shipping confirmation received");
            this.BuyerAck = "Order Details Received";
            Console.WriteLine("Shipping Cost :  " + this.ReceivedLogisticsQuote.shippingCost + " Likey Shipping date : " + this.ReceivedLogisticsQuote.likelyShippingDate);

        }

        public System.Collections.Generic.IDictionary<System.Xml.XmlQualifiedName, String> contextToSend = default(System.Collections.Generic.IDictionary<System.Xml.XmlQualifiedName, System.String>);

        private void codeActivity2_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine(this.SellerAck);
        }
	}

}
