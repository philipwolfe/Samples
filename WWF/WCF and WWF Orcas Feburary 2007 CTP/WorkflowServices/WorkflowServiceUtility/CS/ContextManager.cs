using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Channels;
using System.Workflow.Activities;
using System.Workflow.ComponentModel;
using System.Xml;

namespace Microsoft.WorkflowServices.Samples
{
    // Static methods for managing context.
	public static class ContextManager
	{
        // Apply Context to a SendActivity
        static public void ApplyContext(SendActivity activity, IDictionary<XmlQualifiedName, string> context)
        {
            if (activity.ExecutionStatus == ActivityExecutionStatus.Initialized)
            {
                activity.SetContext(context);
            }
        }

        // Apply EndpointAddress to a SendActivity
        static public void ApplyEndpointAddress(SendActivity activity, EndpointAddress epr)
        {
            if (activity.ExecutionStatus == ActivityExecutionStatus.Initialized)
            {
                if (epr.Uri != null)
                {
                    activity.Endpoint.CustomAddress = epr.Uri.ToString();
                }
                if (epr.Headers != null && epr.Headers.Count > 0)
                {
                    IDictionary<XmlQualifiedName, string> context = new Dictionary<XmlQualifiedName, string>();
                    foreach (AddressHeader header in epr.Headers)
                    {
                        context[new XmlQualifiedName(header.Name, header.Namespace)] = header.GetValue<string>();
                    }
                    activity.SetContext(context);
                }
            }
        }

        // Create EndpointAddress from Uri and Context
        static public EndpointAddress CreateEndpointAddress(string uri, IDictionary<XmlQualifiedName, string> context)
        {
            EndpointAddress epr = null;
            if (context != null && context.Count > 0)
            {
                int i = 0;
                AddressHeader[] headers = new AddressHeader[context.Count];
                foreach (KeyValuePair<XmlQualifiedName, string> item in context)
                {
                    headers[i++] = AddressHeader.CreateAddressHeader(item.Key.Name, item.Key.Namespace, item.Value);
                }
                epr = new EndpointAddress(new Uri(uri), null, new AddressHeaderCollection(headers));
            }
            else
            {
                epr = new EndpointAddress(uri);
            }
            return epr;
        }

        // Create EndpointAddress from Uri and ReceiveActivity
        static public EndpointAddress CreateEndpointAddress(string uri, ReceiveActivity receiveActivity)
        {
            return CreateEndpointAddress(uri, receiveActivity.GetContext());
        }

        // Apply Context to an IClientChannel
        static Uri ccUri = new Uri("http://private/cookiecontainer");
        static public bool ApplyContextToChannel(IDictionary<XmlQualifiedName, string> context, IClientChannel channel)
        {
            if (context != null)
            {
                IContextManager cm = channel.GetProperty<IContextManager>();
                if (cm != null && cm.GetContext() == null)
                {   // apply context to ContextChannel
                    cm.SetContext(context);
                    return true;
                }
                else if (OperationContext.Current != null)
                {   // apply context as HttpCookie
                    CookieContainer cookies = new CookieContainer();
                    foreach (KeyValuePair<XmlQualifiedName, string> item in context)
                    {
                        cookies.Add(ccUri, new Cookie(item.Key.ToString(), item.Value));
                    }
                    if (cookies.Count > 0)
                    {
                        HttpRequestMessageProperty httpRequest = new HttpRequestMessageProperty();
                        OperationContext.Current.OutgoingMessageProperties.Add(HttpRequestMessageProperty.Name, httpRequest);
                        httpRequest.Headers.Add(HttpRequestHeader.Cookie, cookies.GetCookieHeader(ccUri));
                        return true;
                    }
                }
            }
            return false;
        }

        // Extract context from an IClientChannel
        const string WscContextKey = "WscContext";
        static public IDictionary<XmlQualifiedName, string> ExtractContextFromChannel(IClientChannel channel)
        {   // extract context from channel
            IContextManager cm = channel.GetProperty<IContextManager>();
            if (cm != null)
            {   // attempt to extract context from channel
                return cm.GetContext();
            }
            else if (OperationContext.Current != null)
            {   // attempt to extract context from HttpCookie
                CookieContainer cookies = new CookieContainer();
                if (OperationContext.Current.IncomingMessageProperties.ContainsKey(HttpResponseMessageProperty.Name))
                {
                    HttpResponseMessageProperty httpResponse = (HttpResponseMessageProperty)OperationContext.Current.IncomingMessageProperties[HttpResponseMessageProperty.Name];
                    cookies.SetCookies(ccUri, httpResponse.Headers[HttpResponseHeader.SetCookie]);
                }
                if (cookies.Count > 0)
                {   // put WscContext cookie into dictionary
                    Dictionary<XmlQualifiedName, string> newContext = new Dictionary<XmlQualifiedName, string>();
                    foreach (Cookie cookie in cookies.GetCookies(ccUri))
                    {
                        if (cookie.Name.Equals(WscContextKey))
                        {
                            newContext.Add(new XmlQualifiedName(WscContextKey), cookie.Value);
                            break;
                        }
                    }
                    return newContext;
                }
            }
            return null;
        }

        // Deserialize context from file
        static public IDictionary<XmlQualifiedName, string> DepersistContext(string fileName)
        {   // retrieve context from file
            if (File.Exists(fileName))
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<XmlQualifiedName, string>));
                FileStream stream = new FileStream(fileName, FileMode.Open);
                return (Dictionary<XmlQualifiedName, string>)serializer.ReadObject(stream);
            }
            return null;
        }

        // Serialize context into file
        static public void PersistContext(IDictionary<XmlQualifiedName, string> context, string fileName)
        {   // persist context to file
            if (context != null)
            {
                DataContractSerializer serializer = new DataContractSerializer(typeof(Dictionary<XmlQualifiedName, string>));
                FileStream stream = new FileStream(fileName, FileMode.Create);
                serializer.WriteObject(stream, context);
            }
        }

        // Delete context file
        static public void DeleteContext(string fileName)
        {
            if (File.Exists(fileName))
                File.Delete(fileName);
        }

    }
}
