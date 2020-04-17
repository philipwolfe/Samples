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
	public sealed partial class UPSConversation: SequentialWorkflowActivity
	{
		public UPSConversation()
		{
			InitializeComponent();
		}

        public System.Collections.Generic.IDictionary<System.Xml.XmlQualifiedName, String> ReceivedContext = default(System.Collections.Generic.IDictionary<System.Xml.XmlQualifiedName, System.String>);
        public PurchaseOrder ReceivedPO = new Microsoft.NetFx35.Silver.Samples.PurchaseOrder();
        public String UPSAck = default(System.String);

        private void codeActivity1_ExecuteCode(object sender, EventArgs e)
        {
            Console.WriteLine("=============================================");
            Console.WriteLine("Received Logistics Quote Request");
            this.UPSAck = "Working On the Quote";
            this.sendActivity1.SetContext(this.ReceivedContext);
        }

        public LogisticsQuote logisticsQuote = new Microsoft.NetFx35.Silver.Samples.LogisticsQuote();

        private void PrepareLogisticsQuote(object sender, SendActivityEventArgs e)
        {
            Random rand = new Random();
            logisticsQuote.shippingCost = rand.Next(99, 999);
            logisticsQuote.likelyShippingDate = DateTime.Now.AddDays(rand.Next(2, 5));
            Console.WriteLine("=============================================");
            Console.WriteLine("Sending Logistics Quote ");
            Console.WriteLine("Shipping Cost : " + logisticsQuote.shippingCost + " Likely Shipping Date : " + logisticsQuote.likelyShippingDate);

        }


	}

}
