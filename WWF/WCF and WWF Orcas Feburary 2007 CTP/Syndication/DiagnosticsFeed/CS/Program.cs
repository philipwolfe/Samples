using System;
using System.Collections.Generic;
using System.Diagnostics;

using System.ServiceModel;
using System.ServiceModel.Description;
using System.ServiceModel.Syndication;

using System.Text;

namespace HelloSyndication
{
    [ServiceContract(Namespace = "")]
    interface IDiagnosticsService
    {
        [OperationContract]
        //The [HttpTransferContract] attribute controls how WCF dispatches
        //HTTP requests to service operations based on URI suffix
        //(the part of the request URI after the endpoint address)
        //and HTTP method (GET, POST, PUT, etc).
        [HttpTransferContract( Path="", Method="GET" )]
        SyndicationFeed GetProcesses();
    }

    public class ProcessService : IDiagnosticsService
    {
        public SyndicationFeed GetProcesses()
        {
            Process[] processes = Process.GetProcesses();

            //SyndicationFeed also has convenience constructors
            //that take in common elements like Title and Content.
            SyndicationFeed f = new SyndicationFeed();            

            //Create a title for the feed
            f.Title = SyndicationContent.CreatePlaintextTextSyndicationContent("Currently running processes");
            f.Links.Add(SyndicationLink.CreateSelfLink(OperationContext.Current.IncomingMessageHeaders.To));

            //Create a new RSS/Atom item for each running process
            foreach (Process p in processes)
            {
                //SyndicationItem also has convenience constructors
                //that take in common elements such as Title and Content
                SyndicationItem i = new SyndicationItem();

                //Add an item title.
                i.Title = SyndicationContent.CreatePlaintextTextSyndicationContent(p.ProcessName);

                //Add some HTML content in the summary
                i.Summary = new TextSyndicationContent(String.Format("<b>{0}</b>", p.MainWindowTitle), TextSyndicationContentKind.Html);
                
                //Add some machine-readable XML in the item content.
                i.Content = SyndicationContent.CreateXmlSyndicationContent(new ProcessData(p));

                f.Items.Add(i);
            }

            return f;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //Expand this region to see the code for hosting a Syndication Feed.
            #region Service
            ServiceHost host = new ServiceHost(typeof(ProcessService), new Uri("http://localhost:8080/diagnostics"));

            //Add an endpoint that serves Atom 1.0 content
            ServiceEndpoint atomEndpoint = host.AddServiceEndpoint(typeof(IDiagnosticsService), new WebHttpBinding(), "atom");
            atomEndpoint.Behaviors.Add(new SyndicationBehavior( SyndicationVersion.Atom10 ));

            //Add an endpoint that serves Rss 2.0 content
            ServiceEndpoint rssEndpoint = host.AddServiceEndpoint(typeof(IDiagnosticsService), new WebHttpBinding(), "rss");
            rssEndpoint.Behaviors.Add(new SyndicationBehavior(SyndicationVersion.Rss20));

            host.Open();

            Console.WriteLine("Service host open");

            //The syndication feeds exposed by the service are available
            //at the following URI's (note that the trailing slash is significant
            //in this CTP):

            // http://localhost:8080/diagnostics/rss/
            // http://localhost:8080/diagnostics/atom/

            //These feeds can be viewed directly in an RSS-aware client
            //such as IE7.
            #endregion

            //Expand this region to see the code for consuming a Syndication Feed.
            #region Client
            SyndicationFeed feed = new SyndicationFeed();
            feed.Load( new Uri( "http://localhost:8080/diagnostics/atom/" ));

            foreach (SyndicationItem i in feed.Items)
            {
                XmlSyndicationContent content = i.Content as XmlSyndicationContent;
                ProcessData pd = content.ReadContent<ProcessData>();

                Console.WriteLine(i.Title.Text);
                Console.WriteLine(pd.ToString());
            }
            #endregion

            //Press any key to end the program
            Console.ReadLine();
        }
    }
}
