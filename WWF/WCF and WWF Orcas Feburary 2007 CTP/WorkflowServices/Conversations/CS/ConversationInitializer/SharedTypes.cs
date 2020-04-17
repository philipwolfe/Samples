using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Runtime.Serialization;

namespace Microsoft.NetFx35.Silver.Samples
{   
    [DataContract]
	public class PurchaseOrder
	{
        [DataMember]
        public int POnumber;
        [DataMember]
        public int POAmount;
        [DataMember]
        public string CustomerName;
	}

    [DataContract]
    public class LogisticsQuote
    {
        [DataMember]
        public int shippingCost;
        [DataMember]
        public DateTime likelyShippingDate;
    }
}
