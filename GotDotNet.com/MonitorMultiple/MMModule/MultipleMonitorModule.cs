using System;
using System.Web;
using System.Collections;
using System.Collections.Specialized;

namespace MMModule
{	
	public sealed class MultipleMonitorModule : IHttpModule
	{
		private static CriticalAppDirWatcher MMMWatcher;
		private object syncRoot = new Object();
		
		public MultipleMonitorModule()
		{
		}

		private void SetupWatcher()
		{
			if(MMMWatcher == null)
			{
				lock(syncRoot)
				{
					if(MMMWatcher == null)
					{
						CriticalAppDirWatcher dw = new CriticalAppDirWatcher( 
							new System.IO.FileSystemEventHandler(FileSystemChanged) );

						System.Threading.Thread.MemoryBarrier();
						MMMWatcher = dw;
					}
				}
			}	
		}

		private void FileSystemChanged(object sender, System.IO.FileSystemEventArgs e)
		{
			//Here's the magic.  This is the same thing the ASP.NET classes
			// ... do whenever a file in the bin directory changes.  It would
			// ... be very easy to let the framework handle all of this if only
			// ... the classes responsible for this (And seemingly only this) 
			// ... weren't all 'internal'.

			HttpRuntime.UnloadAppDomain();

			//You'd probably also want to log the dir that changed. 
		}
		
		

		#region IHttpModule Members
		public void Init(HttpApplication context)
		{
			SetupWatcher();	
		}
		public void Dispose(){}
		#endregion
	}
}
