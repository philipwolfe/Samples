using System.ServiceProcess;
using System.Messaging;
using System.Threading;
using System;

public class WatchMSMQ:System.ServiceProcess.ServiceBase
{

	// Needed to re-hook the queue
	// in case we're paused.

	private string m_Path;

#region " Component Designer generated code ";

	public WatchMSMQ() 
	{

		// This call is required by the Component Designer.

		InitializeComponent();

		// Add any initialization after the InitializeComponent() call

		this.m_Path = this.qOrders.Path;

	}

	//UserService overrides dispose to clean up the component list.

	protected override void Dispose(bool disposing) {

		if (disposing) {

			if (components != null) {

				components.Dispose();

			}

		}

		base.Dispose(disposing);

	}

	// The main entry point for the process

	[MTAThread]
	static void Main()
	{

		System.ServiceProcess.ServiceBase[] ServicesToRun;

		// More than one NT Service may run within the same process. To add
		// another service to this process, change the following line to
		// create a second service object. For example,
		//
		//   ServicesToRun = new System.ServiceProcess.ServiceBase () {new Service1, new MySecondUserService}
		//

		ServicesToRun = new System.ServiceProcess.ServiceBase[] {new WatchMSMQ()};
		System.ServiceProcess.ServiceBase.Run(ServicesToRun);

	}

	//Required by the Component Designer

	private System.ComponentModel.IContainer components = null;

	// NOTE: The following procedure is required by the Component Designer

	// It can be modified using the Component Designer.  

	// Do not modify it using the code editor.

	internal System.Messaging.MessageQueue qOrders;

	private void InitializeComponent() 
	{

		System.Configuration.AppSettingsReader configurationAppSettings  = new System.Configuration.AppSettingsReader();

		this.qOrders = new System.Messaging.MessageQueue();

		//

		//qOrders

		//

		this.qOrders.Formatter = new System.Messaging.XmlMessageFormatter(new string[] {"Server.MSMQOrders,Server"});

		this.qOrders.Path = (string) configurationAppSettings.GetValue("msmqOrders.Path", typeof(System.String));

		//

		//WatchMSMQ

		//

		this.CanHandlePowerEvent = true;

		this.CanPauseAndContinue = true;

		this.CanShutdown = true;

		this.ServiceName = "WatchMSMQ";

	}

#endregion

	protected override void OnStart(string[] args)
	{

		// Add code here to start your service. This method should set things
		// in motion so your service can do its work.

		try 
		{

			this.HookQueue();
		}
		catch (MessageQueueException exp)
		{

			this.EventLog.WriteEntry(exp.Message);
		}

		catch (Exception exp) 
		{

			this.EventLog.WriteEntry(exp.Message);

		}

	}

	protected override void OnStop()
	{

		// Add code here to perform any tear-down necessary to stop your service.

		UnhookQueue();

	}

	protected override void OnContinue()
	{

		HookQueue();

	}

	protected override void OnPause()
	{

		UnhookQueue();

	}

	protected override bool OnPowerEvent(System.ServiceProcess.PowerBroadcastStatus powerStatus )
	{
		return false;
	}

	protected override void OnShutdown()
	{

		UnhookQueue();

	}

	private void HookQueue()
	{

		try 
		{

			// This is necessary since we unhook
			// when we are stopped.

			if (this.qOrders == null) 
			{

				this.qOrders = new System.Messaging.MessageQueue(this.m_Path);

			}

			// Start waiting for messages to arrive.

			this.qOrders.BeginReceive();
		}
		catch (MessageQueueException exp)
		{

			this.EventLog.WriteEntry(exp.Message);

		}
		catch (Exception exp) 
		{

			this.EventLog.WriteEntry(exp.Message);

		}

	}

	private void UnhookQueue()
	{

		try 
		{

			this.qOrders.Close();
			this.qOrders.Dispose();
			this.qOrders = null;
		}
		catch (MessageQueueException exp)
		{

			this.EventLog.WriteEntry(exp.Message);
		}
		catch (Exception exp) 
		{

			this.EventLog.WriteEntry(exp.Message);

		}

	}

	private void qOrders_ReceiveCompleted(object sender, System.Messaging.ReceiveCompletedEventArgs e ) 
	{

		// This event fires when a message is received.

		try 
		{

			// Get the message

			Message m ;

			m = qOrders.EndReceive(e.AsyncResult);

			// Cast the message body to an object instance
			Server.MSMQOrders o;
			o = (Server.MSMQOrders) m.Body;
			

			// if we did the following line of code:
			// o.Process()
			// our listening thread would be blocked until 
			// it finished. Instead will use the built-in
			// CLR Thread Pool.
			// Note that our MSMQOrders.Process method has to match
			// expected signature defined by the QueueUserWorkItem method.
			// See the documenation for more information.

			ThreadPool.QueueUserWorkItem(new WaitCallback(o.Process));

			// Now continue listening for messages

			this.qOrders.BeginReceive();
		}

		catch (MessageQueueException exp)
		{

			this.EventLog.WriteEntry(exp.Message);
		}

		catch (Exception exp) 
		{

			this.EventLog.WriteEntry(exp.Message);

		}

	}

}

