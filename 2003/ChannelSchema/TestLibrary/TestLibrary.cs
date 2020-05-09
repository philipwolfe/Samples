using System;
using System.Runtime.Remoting.Messaging;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Services;

namespace TestLibrary {

	using InterfaceLibrary;

    public class TestObject : MarshalByRefObject, ITestObject  {
		public delegate String Delegate(String s);

		public TestObject() : this("Server") {
		}
		public TestObject(String name) {
			Console.WriteLine("{0}: Object Constructor called.", name);
			_name = name;
			_counter = 0;
		}
		String _name = "Server";
        static int _counter = 0;
        public String Ping()
        {
            _counter++;
            Console.WriteLine("\nEntering Ping() on {0}, counter {1}", _name, _counter);
            return String.Format("Returning from Ping() on {0}, counter {1}", _name, _counter);            
        }

        [OneWay] public void OneWayMethod(String s) {
            Console.WriteLine("\nEntering OneWayMethod() on {0} with parameter {1}", _name, s);
        }
 
        public void RegularMethod(String s) {
             Console.WriteLine("\nEntering RegularMethod() on {0} with parameter {1}", _name, s);
        }

        public String AsyncMethod(String s) {
            Console.WriteLine("\nEntering AsyncMethod() on {0} with parameter {1}", _name, s);
            return String.Format("Returning from AsyncMethod() with {0} on {1}", s, _name);
        }

        
		public String CallMe(ICallbackObject cb) {
            Console.WriteLine("\nEntering CallMe() on {0}", _name);
            Console.WriteLine("{0}: Trying a callback...", _name);

			String URL = RemotingServices.GetObjectUri((MarshalByRefObject)cb);
			Console.WriteLine(URL);

			ObjRef objRef = RemotingServices.GetObjRefForProxy((MarshalByRefObject)cb);

			Object[] channelData = objRef.ChannelInfo.ChannelData;


            String result = cb.Callback(String.Format("Calling back from CallMe() on {0} ...", _name));
			Console.WriteLine("Callback result: {0}", result);

            return String.Format("Returning from CallMe() on {0}", _name);
        }

		public String CallMeOneWay(ICallbackObject cb) {
            Console.WriteLine("\nEntering CallMeOneWay() on {0}", _name);
			Console.WriteLine("{0}: Trying a one way callback ...", _name);

			cb.OneWayCallback(String.Format("Calling back from CallMeOneWay() on {0} ...", _name));

			return String.Format("Returning from CallMeOneWay() on {0}", _name);
		}

		public String CallMeAsync(ICallbackObject cb) {
            Console.WriteLine("\nEntering CallMeAsync() on {0}", _name);
			Console.WriteLine("{0}: Trying async callback ...", _name);

			Delegate async = new Delegate(cb.AsyncCallback);
			IAsyncResult asyncResult = async.BeginInvoke(String.Format("Calling back from CallMeAsync() on {0} ...", _name), null, null);
			//
			//Wait for the call to complete
			//
			asyncResult.AsyncWaitHandle.WaitOne();

			String result = async.EndInvoke(asyncResult);

			Console.WriteLine("Callback result: {0}", result);
			return String.Format("Returning from CallMeAsync() on {0}", _name);
		}

		public static String GetURLForObject(MarshalByRefObject obj) {
			// trying for CAOs
			ObjRef o = RemotingServices.GetObjRefForProxy(obj);
			if (o!=null) {
				foreach (object data in o.ChannelInfo.ChannelData) {
					ChannelDataStore ds = data as ChannelDataStore;
					if (ds != null) {
						return ds.ChannelUris[0] + o.URI;
					}
				}
			} 
			else {
				// either SAO or not remote!
				String URL = RemotingServices.GetObjectUri(obj);
				return URL;
			}
			return null;
		}


	}

	public class KnossosObject : TestObject, IKnossosObject {
		public KnossosObject() : base("knossos") { }
	}
	public class ZakrosObject : TestObject, IZakrosObject {
		public ZakrosObject() : base("zakros") { }
	}
}

