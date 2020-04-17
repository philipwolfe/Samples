//----------------------------------------------------------------
// Copyright (c) Microsoft Corporation.  All rights reserved.
//----------------------------------------------------------------

namespace Microsoft.Samples.BlobMessageEncoder
{
    using System;
    using System.IO;
    using System.ServiceModel;
    using System.ServiceModel.Channels;
    using System.Xml;

    class Client
    {
        const string TestFileName = "smallsuccess.gif";

        public static void Main()
        {
            // Typically this request would be constructed by a web browser or non-WCF application instead of using WCF

            Console.WriteLine("Starting client with BlobHttpBinding");

            using (ChannelFactory<IHttpHandler> cf = new ChannelFactory<IHttpHandler>("blobHttpBinding"))
            {
                IHttpHandler channel = cf.CreateChannel();
                Console.WriteLine("Client channel created");

                Message blob = Message.CreateMessage(MessageVersion.None, "*", new BlobBodyWriter(TestFileName));
                HttpRequestMessageProperty httpRequestProperty = new HttpRequestMessageProperty();
                httpRequestProperty.Headers.Add("Content-Type", "application/octet-stream");
                blob.Properties.Add(HttpRequestMessageProperty.Name, httpRequestProperty);

                Console.WriteLine("Client calling service");
                Message reply = channel.ProcessRequest(blob);

                //Get bytes from the reply 
                XmlDictionaryReader reader = reply.GetReaderAtBodyContents();
                reader.MoveToElement();
                String name = reader.Name;
                Console.WriteLine("First element in the blob message is : <" + name + ">");
                byte[] array = reader.ReadElementContentAsBase64();
                String replyMessage = System.Text.Encoding.UTF8.GetString(array);
                Console.WriteLine("Client received a reply from service of length :" + replyMessage.Length);
            }

            Console.WriteLine("Done");
            Console.WriteLine("Press <ENTER> to exit client");
            Console.ReadLine();

        }

        class BlobBodyWriter : BodyWriter
        {
            string testFileName;

            public BlobBodyWriter(string testFileName)
                : base(false)
            {
                this.testFileName = testFileName;
            }

            protected override void OnWriteBodyContents(XmlDictionaryWriter writer)
            {
                writer.WriteStartElement("Binary");

                FileStream fs = new FileStream(this.testFileName, FileMode.Open);
                byte[] tmp = new byte[fs.Length];
                fs.Read(tmp, 0, tmp.Length);
                writer.WriteBase64(tmp, 0, (int)tmp.Length);

                writer.WriteEndElement();
                fs.Close();
            }

        }

    }
}
