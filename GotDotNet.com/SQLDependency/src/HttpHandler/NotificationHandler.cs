using System;
using System.Web;
using System.IO;
using System.Text;
using System.Data;
using System.Collections;
using System.Data.SqlClient;

namespace System.Web.Caching {

	public sealed class NotificationHandler : IHttpHandler {

		public void ProcessRequest(HttpContext context) {
			// Variables for Request
			HttpRequest Request = context.Request;
			HttpResponse Response = context.Response;

			// Cache Key and Handle
			String CacheKey = Request.Params["CacheKey"];
			String CacheHandle = Request.Params["CacheHandle"];

			if (null == CacheKey)
				return;

			// Variable for App Domain specific Cache and Response
			System.Web.Caching.Cache Cache = context.Cache;

			// Purge the Cache
			if (null != CacheKey)
				Cache.Remove(CacheKey);

			Response.Write("Done!");
		}

		public bool IsReusable {
			get {
				return true;			
			}
		}
	}
}
