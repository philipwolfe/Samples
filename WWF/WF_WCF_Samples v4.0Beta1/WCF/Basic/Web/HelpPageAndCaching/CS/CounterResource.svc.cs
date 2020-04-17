/// Copyright (c) Microsoft Corporation.  All rights reserved.

using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.ServiceModel.Web.Caching;
using System.ServiceModel.Activation;
using System.Net;

[assembly: ContractNamespace("", ClrNamespace = "Counter")]

namespace Microsoft.Samples.HelpPageAndCaching
{
    // NOTE: Please set IncludeExceptionDetailInFaults to false in production environments
    /// <summary>
    /// The Counter service maintains a single counter whose value can be obtained by GET. The counter value can be incremented with POST and can be replaced
    /// with PUT. DELETE will delete the counter.
    /// </summary>
    [ServiceContract]
    [ServiceBehavior(IncludeExceptionDetailInFaults = true, InstanceContextMode = InstanceContextMode.Single, ConcurrencyMode = ConcurrencyMode.Single)]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    public partial class CounterResource 
    {
        // URI template definitions for how clients can access the resource using XML or JSON.
        // The URI template to manipulate the resource in its XML format. The URL is of the form http://<url-for-svc-file>/
        public const string XmlItemTemplate = "";
        // The URI template to manipulate the resource in its JSON format. The URL is of the form http://<url-for-svc-file>/?json
        public const string JsonItemTemplate = "?format=json";


        Counter item = new Counter() { Value = 0 };

        static readonly UriTemplate xmlTemplate = new UriTemplate(XmlItemTemplate);
        static readonly UriTemplate jsonTemplate = new UriTemplate(JsonItemTemplate);

        Counter HandleGet()
        {
            Counter result = this.item;
            if (result == null)
            {
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound();
                return null;
            }
            return result;
        }

        Counter HandleAdd(Counter initialValue, UriTemplate template)
        {
            bool wasResourceCreated;
            if (this.item == null)
            {
                this.item = initialValue;
                wasResourceCreated = true;
            }
            else
            {
                wasResourceCreated = false;
                this.item.Value += initialValue.Value;
            }

            Counter result = this.item;
            if (result == null)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                return null;
            }
            if (wasResourceCreated)
            {
                Uri location = template.BindByPosition(WebOperationContext.Current.IncomingRequest.UriTemplateMatch.BaseUri);
                WebOperationContext.Current.OutgoingResponse.SetStatusAsCreated(location);
            }
            return result;
        }


        Counter HandleUpdate(Counter newValue, UriTemplate template)
        {
            bool wasResourceCreated;
            wasResourceCreated = (this.item == null);
            this.item = newValue;
            
            Counter result = this.item;
            if (result == null)
            {
                WebOperationContext.Current.OutgoingResponse.StatusCode = HttpStatusCode.InternalServerError;
                return null;
            }
            if (wasResourceCreated)
            {
                Uri location = template.BindByPosition(WebOperationContext.Current.IncomingRequest.UriTemplateMatch.BaseUri);
                WebOperationContext.Current.OutgoingResponse.SetStatusAsCreated(location);
            }
            return result;
        }

        void HandleDelete()
        {
            bool canItemBeDeleted = (this.item != null);
            this.item = null;
            
            if (!canItemBeDeleted)
            {
                WebOperationContext.Current.OutgoingResponse.SetStatusAsNotFound();
            }
        }



        [AspNetCacheProfile("CacheFor60Seconds")]
        [WebGet(UriTemplate=XmlItemTemplate)]
        [OperationContract]
        public Counter GetItemInXml()
        {
            return HandleGet();
        }

        [WebInvoke(Method="POST", UriTemplate = XmlItemTemplate)]
        [OperationContract]
        public Counter AddItemInXml(Counter initialValue)
        {
            return HandleAdd(initialValue, xmlTemplate);
        }

        [WebInvoke(Method = "PUT", UriTemplate = XmlItemTemplate)]
        [OperationContract]
        public Counter UpdateItemInXml(Counter newValue)
        {
            return HandleUpdate(newValue, xmlTemplate);
        }

        [AspNetCacheProfile("CacheFor60Seconds")]
        [WebGet(UriTemplate = JsonItemTemplate,ResponseFormat=WebMessageFormat.Json)]
        [OperationContract]
        public Counter GetItemInJson()
        {
            return HandleGet();
        }

        [WebInvoke(Method = "POST", UriTemplate = JsonItemTemplate, ResponseFormat=WebMessageFormat.Json)]
        [OperationContract]
        public Counter AddItemInJson(Counter initialValue)
        {
            return HandleAdd(initialValue, jsonTemplate);
        }

        [WebInvoke(Method = "PUT", UriTemplate = JsonItemTemplate, ResponseFormat=WebMessageFormat.Json)]
        [OperationContract]
        public Counter UpdateItemInJson(Counter newValue)
        {
            return HandleUpdate(newValue, jsonTemplate);
        }

        //XmlItemTemplate is used here because it is the base uri for the item
        [WebInvoke(Method = "DELETE", UriTemplate=XmlItemTemplate)]
        [OperationContract]
        public void DeleteItem()
        {
            HandleDelete();
        }

}

    public class Counter
    {
        public int Value { get; set; }
    }
}
