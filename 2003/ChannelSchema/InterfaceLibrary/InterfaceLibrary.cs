using System;
using System.Runtime.Remoting.Messaging;

namespace InterfaceLibrary
{
	public interface ITestObject {
		String Ping();
		[OneWay] void OneWayMethod(String s);
		void RegularMethod(String s);
		String AsyncMethod(String s);

		String CallMe(ICallbackObject cb);
		String CallMeOneWay(ICallbackObject cb);
		String CallMeAsync(ICallbackObject cb);
	}
	public interface IKnossosObject : ITestObject { }
	public interface IZakrosObject : ITestObject { }

	public interface ICallbackObject {
		String Callback(String msg);
		[OneWay] void OneWayCallback(String msg);
		String AsyncCallback(String msg);
	}
}
