//Copyright (c) 2006 Jon Flanders - http://www.masteringbiztalk.com/
//Permission is hereby granted, free of charge, to any person obtaining a copy of this software and
//associated documentation files (the "Software"), to deal in the Software without restriction, 
//including without limitation the rights to use, copy, modify, merge, publish, distribute, 
//sublicense, and/or sell copies of the Software, and to permit persons to whom the Software 
//is furnished to do so, subject to the following conditions:
//The above copyright notice and this permission notice shall be included 
//in all copies or substantial portions of the Software.
//THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
//INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR
//PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE
//FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE,
//ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.

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
using System.Drawing;
using Bearcanyon;
namespace WorkflowVisibilityControl
{
    public class WFGetImageHandler : IHttpHandler, IRequiresSessionState
    {



        public bool IsReusable
        {
            get { return true; }
        }

        public void ProcessRequest(HttpContext context)
        {
            if (HttpContext.Current.Request["newactivity"] != null)
            {
                string data = HttpContext.Current.Request["newactivity"].ToString();
                string[] sa = data.Trim().Split(' ');
                HttpContext.Current.Session["newact"] = sa[0];
                HttpContext.Current.Session["x"] = sa[1];
                HttpContext.Current.Session["y"] = sa[2];
                context.Response.Write(Guid.NewGuid().ToString() + "|" + HttpContext.Current.Request["id"]);
            }

        }




    }
    public class WFImageHandler : IHttpAsyncHandler, IRequiresSessionState
    {

        internal static readonly string XomlExample = @"<SequentialWorkflowActivity x:Name=""HelloWorldWorkflow"" xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/workflow"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""></SequentialWorkflowActivity>";
       // internal static readonly string XomlExample = @"<StateMachineWorkflowActivity x:Name=""HelloWorldWorkflow"" xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/workflow"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml""></StateMachineWorkflowActivity>";

        Bearcanyon.ThreadPool _pool = InitPool();

        private static Bearcanyon.ThreadPool InitPool()
        {
            Bearcanyon.ThreadPool p = new Bearcanyon.ThreadPool(2, 25, "WFImagePool");
            p.ApartmentState = ApartmentState.STA;
            p.Start();
            return p;
        }

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
            string act = String.Empty;
            if (context.Session["act"] != null)
                act = context.Request["act"];
            string xoml = WFImageHandler.XomlExample;
            if (context.Session["xoml"] != null)
            {
                xoml = context.Session["xoml"].ToString();

            }
            //cmd handling
            object cmd = context.Session["Cmd"];
            string newact = null;
            string pasteact = null;
            int x = 0;
            int y = 0;




            WorkRequestDelegate wc = delegate(object state, DateTime dt)
            {

                using (WorkflowDesignerControl.WorkflowDesignerControl ctrl = new WorkflowDesignerControl.WorkflowDesignerControl())
                {
                    HttpContext.Current = context;
                    ctrl.LoadWorkflow(xoml);
                    //change the view is there is a current one selected
                    object viewdata = context.Session["currentview"];
                    ChangeView(ctrl, viewdata);
                    if (cmd != null)
                    {
                        x = Int32.Parse(context.Session["x"].ToString());
                        y = Int32.Parse(context.Session["y"].ToString());

                        string scmd = cmd.ToString();
                        string xaml=null;
                        string actData = context.Session["actData"].ToString();
                        switch (scmd)
                        {
                            case "Add":
                             
                                xaml = ctrl.AddActivity(actData, x, y, context.Session["lastactivityselected"] != null ? context.Session["lastactivityselected"].ToString() : string.Empty, out act);
                                ChangeView(ctrl, viewdata);
                                break;
                            case "Paste":
                                if (context.Session["cutactivity"] != null)//cut and paste
                                {
                                    Activity[] a = context.Session["cutactivity"] as Activity[];
                                    if (a != null)
                                    {
                                        xaml = ctrl.AddActivity(a, x, y);
                                    }
                                    context.Session["cutactivity"] = null;
                                }
                                else//copy and paste
                                {
                                    xaml = ctrl.CopyActivity(actData, x, y);

                                } 
                                break;
                            case "Delete":
                                xaml = ctrl.DeleteActivity(actData);
                                break;
                            case "Cut":
                                Activity[] ract;
                                xaml = ctrl.CutActivity(actData, out ract);
                                context.Session["cutactivity"] = ract;
                                break;
                            case "ChangeView":
                                ChangeView(ctrl, actData);
                                context.Session["currentview"] = actData;
                                break;
                            default:
                                xaml = xoml;
                                break;

                        }
                        if (xaml != null)
                            context.Session["xoml"] = xaml;
                        context.Session["Cmd"] = null;//set the command to null
                    }



                    using (MemoryStream ms = new MemoryStream())
                    {
                        if (newact != null && act != String.Empty)
                        {
                            ctrl.HighlightActivity(act);
                            context.Session["lastactivityselected"] = act;
                        }
                        
                        ctrl.SaveWorkflowImage(ms, ImageFormat.Png);
                        ms.Seek(0, 0);
                        context.Response.ContentType = "image/png";
                        context.Response.AddHeader("Content-Length", ms.Length.ToString());
                        context.Response.BinaryWrite(ms.GetBuffer());
                        context.Response.Flush();
                      

                    }

                    context.Session["wfbounds"] = ctrl.GetBounds();
                    context.Session["wfproperties"] = ctrl.GetProperties();
                    ar.SetComplete();
                    HttpContext.Current = null;
                }

            };
            _pool.PostRequest(wc);
            return ar;
        }

        private static void ChangeView(WorkflowDesignerControl.WorkflowDesignerControl ctrl, object viewdata)
        {
            if (viewdata != null)
            {
                string[] vdata = viewdata.ToString().Split('|');
                ctrl.ChangeView(vdata[0].Trim(), vdata[1]);
            }
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