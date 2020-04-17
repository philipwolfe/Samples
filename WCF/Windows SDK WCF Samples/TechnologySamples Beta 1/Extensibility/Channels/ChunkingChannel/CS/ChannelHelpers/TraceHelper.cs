using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;
using System.Xml.XPath;
using System.Diagnostics;
using System.IO;
namespace Microsoft.Samples.ChannelHelpers
{
    public class TraceSourceHelper : TraceSource
    {
        internal const string TraceRecordNs = "http://schemas.microsoft.com/2004/10/E2ETraceEvent/TraceRecord";
        internal const string TraceRecordName = "TraceRecord";
        public TraceSourceHelper(string sourceName) 
            : base(sourceName)
        {
           
        }
        public void TraceMethod(TraceEventType eventType,string methodName)
        {
            WriteTraceData(eventType, 0, "Information", "", "Method executed", null, methodName, null);

        }
        public void WriteTraceData(TraceEventType eventType, int id, string severity, string traceIdentifier, string description, string traceSource, string methodName, Exception exception)
        {
            if (this.Switch.ShouldTrace(eventType))
            {
                MemoryStream strm = new MemoryStream();
                XmlTextWriter writer = new XmlTextWriter(new StreamWriter(strm));
                writer.WriteStartElement(TraceRecordName);
                writer.WriteAttributeString("xmlns", TraceRecordNs);
                writer.WriteAttributeString("Severity", severity);
                writer.WriteElementString("TraceIdentifier", traceIdentifier);
                writer.WriteElementString("Description", description);
                writer.WriteElementString("AppDomain", AppDomain.CurrentDomain.FriendlyName);
                writer.WriteElementString("MethodName", methodName);
                if (traceSource != null)
                {
                    writer.WriteElementString("Source", traceSource);
                }
                if (exception != null)
                {
                    WriteException(writer, exception);
                }
                writer.WriteEndElement();
                writer.Flush();
                strm.Position = 0;
                XPathDocument doc = new XPathDocument(strm);

                base.TraceData(eventType, id, doc.CreateNavigator());
                writer.Close();
                strm.Close();
            }
        }
        void WriteException(XmlWriter writer, Exception exception)
        {
            if (exception != null)
            {
                writer.WriteStartElement("Exception");
                writer.WriteElementString("ExceptionType", exception.GetType().ToString());
                writer.WriteElementString("Message", exception.Message);
                writer.WriteElementString("StackTrace", exception.StackTrace);
                writer.WriteElementString("ExceptionString", exception.ToString());
                if (exception.InnerException != null)
                {
                    writer.WriteStartElement("InnerException");
                    this.WriteException(writer, exception.InnerException);
                    writer.WriteEndElement();
                }

                writer.WriteEndElement();
            }
        }
    }
}
