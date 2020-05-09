using System;
using System.Collections;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting.Proxies;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using System.Runtime.Remoting.Channels.Http;

using InterfaceLibrary;



namespace RemotingClient {

	public class CallbackObject : MarshalByRefObject, ICallbackObject {
		public String Callback(String msg) {
			Console.WriteLine("Callback received!");
			return "Return from CallbackObject.Callback";
		}
		[OneWay] public void OneWayCallback(String msg) {
			Console.WriteLine("OneWayCallback received!");
			Console.WriteLine(msg);
		}
		public String AsyncCallback(String msg) {
			Console.WriteLine("AsyncCallback received!");
			Console.WriteLine(msg);
			return "Return from CallbackObject.AsyncCallback.";
		}
	}

	delegate String Delegate(String s);

	/// <summary>
	/// Summary description for Class1.
	/// </summary>
	class Class1 {
		/// <summary>
		/// The main entry point for the application.
		/// </summary>
		[STAThread]
		static void Main(string[] args)	{

			try {

				RemotingConfiguration.Configure(@"..\..\RemotingClient.exe.config");

	
				// create the callback object
				CallbackObject callback = new CallbackObject();

				// convert to ObjRef
				ObjRef objRef = RemotingServices.Marshal(callback);

				// get at the channel data
				Object[] channelData = objRef.ChannelInfo.ChannelData;

				foreach(Object data in channelData) {

					// look for a ChannelDataStore
					if(data is ChannelDataStore) {
						// get at the channel URIs
						String[] channelUris = ((ChannelDataStore)data).ChannelUris;

						// print each uri, the client’s server channel address
						foreach(String uri in channelUris)
							Console.WriteLine(uri); // 
					}
				}
				String url = "http-secure://localhost:6789/KnossosObject.rem";
				IKnossosObject objSecure = (IKnossosObject)RemotingServices.Connect(typeof(IKnossosObject), url);
				Console.WriteLine("Communicating secure with Knossos ");
				Test(objSecure);
				TestCallback(objSecure, callback);
				
				Console.WriteLine();

				url="http-binary://localhost:9090/KnossosObject.rem";
				IKnossosObject objKnossos = (IKnossosObject)RemotingServices.Connect(typeof(IKnossosObject), url);
				Console.WriteLine("Communicating with Knossos");
				Test(objKnossos);
				TestCallback(objKnossos, callback);

				Console.WriteLine();

				url="tcp-soap://localhost:9000/ZakrosObject.soap";
				IZakrosObject objZakros = (IZakrosObject)RemotingServices.Connect(typeof(IZakrosObject), url);
				Console.WriteLine("Communicating with Zakros");
				Test(objZakros);
				TestCallback(objZakros, callback);

			} catch(Exception e) {
				Console.WriteLine(e);
			}

			Console.WriteLine("Press ENTER to quit...");
			Console.ReadLine();
		}


		static void TestCallback(ITestObject obj, ICallbackObject callback) {
			int sync = 1;
			int oneway = 1;
			int async = 1;


			if(sync > 0) {
				Console.WriteLine("Method with Sync Callback from Server");
				while(sync-- > 0) 
					Console.WriteLine(obj.CallMe(callback));
			}
			if(async > 0) {
				Console.WriteLine("Method with Async Callback from Server");
				while(async-- > 0) 
					Console.WriteLine(obj.CallMeAsync(callback));
			}
			if(oneway > 0) {
				Console.WriteLine("Method with OneWay Callback from Server");
				while(oneway-- > 0) 
					Console.WriteLine(obj.CallMeOneWay(callback));
			}

		}
		static void Test(ITestObject obj) {

			int ping = 1;
			int regular = 1;
			int asyncway = 1;
			int oneway = 1;


			if(ping > 0) {
				Console.WriteLine("Calling Ping()");
				while(ping-- > 0)
					Console.WriteLine(obj.Ping());
			}

			if(regular > 0) {
				Console.WriteLine();
				Console.WriteLine("Calling RegularMethod()");
				while(regular-- > 0) {
					obj.RegularMethod(String.Format("param {0}", regular));
				}
			}

			if(oneway > 0) {
				Console.WriteLine();
				Console.WriteLine("Calling OneWayMethod()");
				while(oneway-- > 0)
					obj.OneWayMethod(String.Format("param {0}", oneway));
			}

			if(asyncway > 0) {
				Console.WriteLine();
				Console.WriteLine("Calling AsyncMethod()");
				while(asyncway-- > 0) {
					Delegate async = new Delegate(obj.AsyncMethod);
					IAsyncResult result = async.BeginInvoke(String.Format("param {0}", asyncway), null, null);
					//
					//Wait for the call to complete
					//
					result.AsyncWaitHandle.WaitOne();
					Console.WriteLine(async.EndInvoke(result));
				}
			}

			Console.WriteLine();
		}
	}
}
