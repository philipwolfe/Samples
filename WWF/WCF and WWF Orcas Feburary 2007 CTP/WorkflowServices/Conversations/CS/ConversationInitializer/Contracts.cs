using System;
using System.Collections.Generic;
using System.Text;
using System.ServiceModel;
using System.Xml;

namespace Microsoft.NetFx35.Silver.Samples
{
	[ServiceContract]
    public interface IReceiveOrder
	{
        [OperationContract(IsInitiating=true)]
        string ReceiveOrder(PurchaseOrder po, IDictionary<XmlQualifiedName,string> BuyerContext);
	}

    [ServiceContract]
    public interface IOrderDetails
    {
        [OperationContract]
        string ReceiveOrderDetails(PurchaseOrder po, LogisticsQuote lq);
    }

    [ServiceContract]
    public interface IOrderLogisticsRequest
    {
        [OperationContract(IsInitiating=true)]
        string RequestLogisticsQuote(PurchaseOrder po, IDictionary<XmlQualifiedName, string> context);
    }
    [ServiceContract]
    public interface IOrderLogisticsQuotes
    {
        [OperationContract]
        void ReceiveLogisticsQuote(LogisticsQuote lq);
    }

}
