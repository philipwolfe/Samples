//	THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
//	KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//	IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//	PARTICULAR PURPOSE.

using System;
using System.Web;
using System.Web.SessionState;
using System.Configuration;

namespace DynamicFileManager
{
	/// <summary>
	/// Summary description for DynamicFileHandler.
	/// </summary>
	public class DynamicFileHandler : IHttpHandler, IRequiresSessionState
	{
		/// <summary>
		/// local reference of the HttpContext
		/// </summary>
		private System.Web.HttpContext context;

		/// <summary>
		/// constructor
		/// </summary>
		public DynamicFileHandler()
		{
		}

		/// <summary>
		/// The file ID of the http request
		/// </summary>
		public string FileID
		{
			get
			{
				FileManager fm = new FileManager();
				string path = context.Request.FilePath;
				char[] slashes = new char[] {'/','\\'};
				int idx = path.LastIndexOfAny(slashes) + 1;
				string file = path.Substring(idx, path.Length - idx -
					(FileManager.FileExtension.Length + 1));
				return file;
			}
		}

		#region Implementation of IHttpHandler
		/// <summary>
		/// returns the requested file if it is a valid file
		/// </summary>
		/// <param name="context"></param>
		public void ProcessRequest(System.Web.HttpContext context)
		{
			this.context = context;
			context.Response.BufferOutput = true;
			
			FileManager fm = new FileManager();
			if (!fm.IsValidFileID(FileID))
			{
				context.Response.StatusCode = 404;
				context.Response.End();
			}

			System.IO.Stream s = null;
			try 
			{
				s = fm.GetLoadStream(FileID);
				int bufferSize = 4096;
				byte[] buffer = new byte[4096];

				if (FileManager.MimeType != null)
				{
					context.Response.ContentType = FileManager.MimeType;
				}

				int numRead = s.Read(buffer, 0, bufferSize);
				while(numRead > 0) 
				{
					context.Response.OutputStream.Write(buffer, 0, numRead);
					numRead = s.Read(buffer, 0, bufferSize);
				}
			}
			catch (Exception ex)
			{
				// any other exception is unknown so log it and rethrow
				context.Trace.Write("DynamicFileHandler", ex.Message);
				context.Response.StatusCode = 404;
			}
			finally
			{
				if (s != null) 
				{
					s.Close();
				}
				context.Response.End();
			}
		}

		/// <summary>
		/// indicates whether another request can use the DynamicFileHandler instance
		/// </summary>
		public bool IsReusable
		{
			get
			{
				return true;
			}
		}
		#endregion
	}
}
