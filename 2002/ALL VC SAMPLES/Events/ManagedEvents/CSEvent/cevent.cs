namespace CSEvent
{
	using System;

	/// <summary>
	///		Summary description for CEvent.
	/// </summary>
	public delegate void MyEventHandler(int i);

	public class CEvent 
	{
		public event MyEventHandler CMyEvent;
		public void Fire(int i) 
		{
			if (CMyEvent != null) 
			{
				CMyEvent(i);
			}
		}
	};

	public class CR2 
	{
		public void H1(int i) { System.Console.WriteLine("CR2::H1 "+ i); }
		public void H2(int i) { System.Console.WriteLine("CR2::H2 "+ i); }
		public void H3(int i, double j) { System.Console.WriteLine("CR2::H3 "+ i + ": " + j); }
		public void H4(int i, double j) { System.Console.WriteLine("CR2::H4 "+ i + ": " + j); }
		public void Hook(CEvent p, Event p2) 
		{
			p.CMyEvent += new MyEventHandler(H1);
			p.CMyEvent += new MyEventHandler(H2);
			p2.MyEvent += new MyDelegate(H3);
			p2.MyEvent += new MyDelegate(H4);
		}
		public void Unhook(CEvent p, Event p2) 
		{
			p.CMyEvent -= new MyEventHandler(H1);
			p.CMyEvent -= new MyEventHandler(H2);
			p2.MyEvent -= new MyDelegate(H3);
			p2.MyEvent -= new MyDelegate(H4);
		}

		public static void Main() 
		{
			CEvent pS = new CEvent();
			Event pS2 = new Event();
			CR2 pR = new CR2();
			pR.Hook(pS, pS2);
			pS.Fire(17);
			pS2.Fire_MyEvent(777, 3.141593);
			pR.Unhook(pS, pS2);
			pS.Fire(13);
			pS2.Fire_MyEvent(333, 3.141593);
		}
	};


}
