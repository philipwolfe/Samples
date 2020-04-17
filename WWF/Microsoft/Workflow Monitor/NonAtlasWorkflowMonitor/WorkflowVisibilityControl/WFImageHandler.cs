using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using WorkflowDesignerControl;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using System.Reflection;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Xml;
using System.Windows.Forms;
using System.Web.SessionState;
using System.Workflow.Runtime.Tracking;
namespace WorkflowVisibilityControl
{
    public class WFImageHandler : IHttpAsyncHandler, IRequiresSessionState
    {

        internal static readonly string XomlExample = @"<SequentialWorkflowActivity x:Name=""HelloWorldWorkflow"" xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/workflow"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""></SequentialWorkflowActivity>";


        public void ProcessRequest(HttpContext context)
        {


        }


        public bool IsReusable
        {
            get { return false; }
        }



        public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
        {
            MyAsyncResult ar = new MyAsyncResult(extraData, cb, context);

            string xoml = WFImageHandler.XomlExample;
            SqlTrackingWorkflowInstance swi = HttpContext.Current.Session["CurrentWF"] as SqlTrackingWorkflowInstance;
            Activity current = null;
            if (swi != null)
            {
                current = swi.WorkflowDefinition;
            }
            else
            {
                current = new WorkflowMarkupSerializer().Deserialize(XmlReader.Create(new StringReader(XomlExample))) as Activity;
            }

            Thread t = new Thread(delegate()
            {

                using (Microsoft.Samples.Workflow.WorkflowMonitor.ViewHost vh = new Microsoft.Samples.Workflow.WorkflowMonitor.ViewHost())
                {
                    vh.OpenWorkflow(current);
                    if (swi != null)
                        vh.SetTrackingInstance(swi);
                    context.Response.ContentType = "image/png";
                    using (MemoryStream ms = new MemoryStream())
                    {
                        vh.SaveWorkflowImage(ms, ImageFormat.Png);
                        ms.Seek(0, 0);
                        context.Response.BinaryWrite(ms.GetBuffer());
                    }
                    context.Response.End();
                    ar.SetComplete();
                }

            });
            t.SetApartmentState(ApartmentState.STA);
            t.Start();
            return ar;
        }

        public void EndProcessRequest(IAsyncResult result)
        {

        }

        string LoadWFType(string tn, Assembly asm)
        {

            Type t = asm.GetType(tn);
            return LoadXomlForWFType(t);
        }
        string LoadXomlForWFType(Type t)
        {

            WorkflowMarkupSerializer xomlSerializer = new WorkflowMarkupSerializer();

            Activity a = (Activity)t.Assembly.CreateInstance(t.FullName);
            StringWriter writer1 = new StringWriter();
            XmlTextWriter xw = new XmlTextWriter(writer1);
            xomlSerializer.Serialize(xw, a);
            return writer1.ToString();
        }

    }

    public class MyAsyncResult : IAsyncResult
    {
        public MyAsyncResult(object state, AsyncCallback cb, HttpContext ctx)
        {

            _asyncState = state;
            _callback = cb;
            context = ctx;

        }
        internal HttpContext context;
        AsyncCallback _callback;

        object _asyncState;
        public object AsyncState
        {
            get { return _asyncState; }
        }
        internal void SetComplete()
        {
            _complete = true;
            lock (_sync)
            {
                if (_completeEvent != null)
                {
                    _completeEvent.Set();
                }
            }
            if (_callback != null)
                _callback(this);
        }
        ManualResetEvent _completeEvent = null;
        bool _complete = false;
        object _sync = new object();
        public System.Threading.WaitHandle AsyncWaitHandle
        {
            get
            {
                if (_completeEvent == null)
                {
                    lock (_sync)
                    {
                        _completeEvent = new ManualResetEvent(false);
                    }
                }
                return _completeEvent;
            }
        }

        public bool CompletedSynchronously
        {
            get { return false; }
        }

        public bool IsCompleted
        {
            get { return _complete; }
        }


    }
}