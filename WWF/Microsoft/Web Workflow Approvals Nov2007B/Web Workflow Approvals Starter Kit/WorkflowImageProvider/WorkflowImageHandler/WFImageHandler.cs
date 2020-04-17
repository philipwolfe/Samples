//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using System.Diagnostics;
using System.IO;
using System.Drawing.Imaging;
using System.Threading;
using System.Reflection;
using System.Workflow.ComponentModel.Serialization;
using System.Workflow.ComponentModel;
using System.Xml;
using System.Windows.Forms;
using WorkflowImageProvider.WorkflowDesigner;

namespace WorkflowImageProvider.WorkflowImageHandler
{
	public class WFImageHandler : IHttpAsyncHandler
	{

		internal static readonly string XomlExample = @"<SequentialWorkflowActivity x:Class=""HelloWorld.HelloWorldWorkflow"" x:Name=""HelloWorldWorkflow"" xmlns=""http://schemas.microsoft.com/winfx/2006/xaml/workflow"" xmlns:x=""http://schemas.microsoft.com/winfx/2006/xaml"">
                                                <CodeActivity x:Name=""CodeActivity1"" ExecuteCode=""CodeActivity1_ExecuteCode""/>
                                                <x:Code>
                                                <![CDATA[
                                                void CodeActivity1_ExecuteCode(object o,EventArgs e)
                                                {
	                                                System.Console.WriteLine(""Hello World"");
                                                }
                                                ]]>
                                                </x:Code>
                                                </SequentialWorkflowActivity>";


		/// <summary>
		/// Enables processing of HTTP Web requests by a custom HttpHandler that implements the <see cref="T:System.Web.IHttpHandler"></see> interface.
		/// </summary>
		/// <param name="context">An <see cref="T:System.Web.HttpContext"></see> object that provides references to the intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
		public void ProcessRequest(HttpContext context)
		{
		}

		/// <summary>
		/// Gets a value indicating whether another request can use the <see cref="T:System.Web.IHttpHandler"></see> instance.
		/// </summary>
		/// <value></value>
		/// <returns>true if the <see cref="T:System.Web.IHttpHandler"></see> instance is reusable; otherwise, false.</returns>
		public bool IsReusable
		{
			get { return false; }
		}

		/// <summary>
		/// Initiates an asynchronous call to the HTTP handler.
		/// </summary>
		/// <param name="context">An <see cref="T:System.Web.HttpContext"></see> object that provides references to intrinsic server objects (for example, Request, Response, Session, and Server) used to service HTTP requests.</param>
		/// <param name="cb">The <see cref="T:System.AsyncCallback"></see> to call when the asynchronous method call is complete. If cb is null, the delegate is not called.</param>
		/// <param name="extraData">Any extra data needed to process the request.</param>
		/// <returns>
		/// An <see cref="T:System.IAsyncResult"></see> that contains information about the status of the process.
		/// </returns>
		public IAsyncResult BeginProcessRequest(HttpContext context, AsyncCallback cb, object extraData)
		{
			MyAsyncResult ar = new MyAsyncResult(extraData, cb, context);

			string act = String.Empty;
			string xoml = WFImageHandler.XomlExample;

			/* try to pull out our activit identifier */
			if (context.Request["act"] != null)
				act = context.Request["act"];

			/* try to pull out the workflow type identifier */
			if (context.Request["type"] != null)
			{
				string stype = context.Request["type"];
				Type type = Type.GetType(stype);
				if (type != null)
				{
					xoml = LoadXomlForWFType(type);
				}
			}

			/* spin up a thread that generate the workflow image */
			Thread t = new Thread(delegate()
			{
				using (WorkflowImageProvider.WorkflowDesigner.WorkflowDesignerControl ctrl = new WorkflowImageProvider.WorkflowDesigner.WorkflowDesignerControl())
				{
					ctrl.Xoml = xoml;
					context.Response.ContentType = "image/png";
					using (MemoryStream ms = new MemoryStream())
					{
						if (act != String.Empty)
							ctrl.HighlightActivity(act);
						ctrl.SaveWorkflowImage(ms, ImageFormat.Png);
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

		/// <summary>
		/// Provides an asynchronous process End method when the process ends.
		/// </summary>
		/// <param name="result">An <see cref="T:System.IAsyncResult"></see> that contains information about the status of the process.</param>
		public void EndProcessRequest(IAsyncResult result)
		{
		}

		/// <summary>
		/// Loads the xoml for the workflow type.
		/// </summary>
		/// <param name="t">The type of workflow.</param>
		/// <returns>the xoml for the workflow type</returns>
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
		internal HttpContext context;
		AsyncCallback _callback;
		object _asyncState;

		ManualResetEvent _completeEvent = null;
		bool _complete = false;
		object _sync = new object();

		/// <summary>
		/// Initializes a new instance of the <see cref="MyAsyncResult"/> class.
		/// </summary>
		/// <param name="state">The state.</param>
		/// <param name="cb">The cb.</param>
		/// <param name="ctx">The CTX.</param>
		public MyAsyncResult(object state, AsyncCallback cb, HttpContext ctx)
		{
			_asyncState = state;
			_callback = cb;
			context = ctx;
		}
		
		/// <summary>
		/// Gets a user-defined object that qualifies or contains information about an asynchronous operation.
		/// </summary>
		/// <value></value>
		/// <returns>A user-defined object that qualifies or contains information about an asynchronous operation.</returns>
		public object AsyncState
		{
			get { return _asyncState; }
		}

		/// <summary>
		/// Sets the complete.
		/// </summary>
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

		/// <summary>
		/// Gets a <see cref="T:System.Threading.WaitHandle"></see> that is used to wait for an asynchronous operation to complete.
		/// </summary>
		/// <value></value>
		/// <returns>A <see cref="T:System.Threading.WaitHandle"></see> that is used to wait for an asynchronous operation to complete.</returns>
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

		/// <summary>
		/// Gets an indication of whether the asynchronous operation completed synchronously.
		/// </summary>
		/// <value></value>
		/// <returns>true if the asynchronous operation completed synchronously; otherwise, false.</returns>
		public bool CompletedSynchronously
		{
			get { return false; }
		}

		/// <summary>
		/// Gets an indication whether the asynchronous operation has completed.
		/// </summary>
		/// <value></value>
		/// <returns>true if the operation is complete; otherwise, false.</returns>
		public bool IsCompleted
		{
			get { return _complete; }
		}
	}
}