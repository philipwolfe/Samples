//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.BlobMessageEncoder
{
    using System;
    using System.ServiceModel;
    using System.ServiceModel.Channels;

    [ServiceBehavior(InstanceContextMode = InstanceContextMode.Single)]
    class FileService : IHttpHandler
    {
        public Message ProcessRequest(Message request)
        {
            Console.WriteLine("Server received a request from client");            
            HttpResponseMessageProperty httpResponseProperty = new HttpResponseMessageProperty();
            httpResponseProperty.Headers.Add("Content-Type", "application/octet-stream");
            request.Properties.Add(HttpResponseMessageProperty.Name, httpResponseProperty);
            Console.WriteLine("Server is sending back the same image to client");
            return request;
        }
    }
}
