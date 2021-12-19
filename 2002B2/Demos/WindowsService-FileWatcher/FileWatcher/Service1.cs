using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.ServiceProcess;
using System.Text;
using System.Threading;
using System.Diagnostics;
using System.IO;

namespace FileWatcher
{
	public class WinServiceMain
	{
		public const string myName = "WinService"; //service name
		public const string dirpath = "C:\\"; //where to watch for files

		static void Main()
		{
			WinService theService = new WinService();
			theService.AutoLog = true;
			System.ServiceProcess.ServiceBase.Run(theService);
		}
		public class WinService : System.ServiceProcess.ServiceBase
		{
			
			private EventLog eLog = new EventLog("", ".", myName);
			private System.ComponentModel.Container components;
			//service worker thread
			System.Threading.Thread t;

			/// <summary> 
			/// Required designer variable.
			/// </summary>
			public WinService()
			{
				// This call is required by the Windows.Forms Component Designer.
				InitializeComponent();
				//this service can be paused and continued
				this.CanPauseAndContinue = true;
				//myName is the service name
				this.ServiceName = myName;
			}

			public void StartWorkerThread()
			{
				MonitorFiles mon = new MonitorFiles();
				//create a new thread
				//mon.StartMonitor is the thread start function
				System.Threading.Thread t = new System.Threading.Thread(new System.Threading.ThreadStart(mon.StartMonitor));
				t.Start();
				eLog.WriteEntry("Worker thread started");
			}
			
			/// <summary> 
			/// Required method for Designer support - do not modify 
			/// the contents of this method with the code editor.
			/// </summary>
			private void InitializeComponent()
			{
				components = new System.ComponentModel.Container();
			}

			/// <summary>
			/// Set things in motion so your service can do its work.
			/// </summary>
			protected override void OnStart(string[] args)
			{
				// TODO: Add code here to start your service.
				eLog.WriteEntry("WinService service started");
				StartWorkerThread();
			}
 
			/// <summary>
			/// Stop this service.
			/// </summary>
			protected override void OnStop()
			{
				eLog.WriteEntry("WinService service stopped");
				StopThread();
				this.Dispose();
			}
			protected override void OnPause()
			{
				eLog.WriteEntry("Attempting to interrupt worker thread");
				StopThread();
			}

			protected override void OnContinue()
			{
				eLog.WriteEntry("Attempting to start worker thread");
				StartWorkerThread();
			}
			private void StopThread()
			{
				//first interrupt it if it's sleeping
				t.Interrupt();
				//stop it
				t.Suspend();
				//wait for it to stop
				t.Join();
				//kill the object reference
				t = null;
				eLog.WriteEntry("Worker thread stopped successfully");
			}
		}
		class MonitorFiles
		{
			EventLog eLog = new EventLog("", ".", myName);
			public void OnFileRename(object source , RenamedEventArgs e )
			{
				//log event
				eLog.WriteEntry("File rename event received for file: " + e.FullPath);
			}
			public void OnFileEvent(object source, FileSystemEventArgs  e)
			{
				//log event
				eLog.WriteEntry("File event received for file: " + e.FullPath);
			}
			public void StartMonitor()
			{
				/*this is the start function for 
				the worker thread
				create the file system watcher
				set the filter
				set the event handlers via delegates
				tell it to start watching the folders*/
				FileSystemWatcher fw = new FileSystemWatcher();
				WaitForChangedResult result;
				fw.Path = dirpath;

				fw.IncludeSubdirectories = true;
				fw.Filter = "*.*";
				fw.Created += new FileSystemEventHandler( this.OnFileEvent);
				fw.Changed += new FileSystemEventHandler( this.OnFileEvent);
				fw.Deleted += new FileSystemEventHandler( this.OnFileEvent);
				fw.Renamed += new RenamedEventHandler( this.OnFileRename);
            
				fw.EnableRaisingEvents = true;
				eLog.WriteEntry("Monitoring changes in " + dirpath);
				try
				{
					while(true)
					{
						//this will put the thread in 
						//a WaitSleepJoin state waiting for notifications
						result = fw.WaitForChanged(WatcherChangeTypes.All);
					}
				}
				catch (Exception e)
				{
					//note, stopping the thread
					//throws a System.Threading.ThreadStopException
					//this is fine and is expected whenever you stop
					//or pause the service
					eLog.WriteEntry("An exception occurred while monitoring changes. Exception is: " + e.ToString());
				}
				finally
				{
					//stop monitoring the directory
					fw.EnableRaisingEvents = false;
					eLog.WriteEntry("Monitoring stopped");
				}
			
			}
			


		}
	}
}
