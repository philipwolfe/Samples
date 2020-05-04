using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace GenericsPerf
{
	public class StringTests
	{
		public static PerfResult NonGenericListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			ArrayList list = new ArrayList();

			string[] arr = new string[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.Next().ToString();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			string s = null;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				s = (string)list[i];
			}
			long getTime = sw.ElapsedMilliseconds;

			if (s == "somestring")
			{
				Console.WriteLine("s shouldn't be somestring");
			}
			return new PerfResult(addTime, getTime);
		}

		public static PerfResult GenericListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			List<string> list = new List<string>();

			string[] arr = new string[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.Next().ToString();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			string s = null;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				s = list[i];
			}
			long getTime = sw.ElapsedMilliseconds;

			if (s == "somestring")
			{
				Console.WriteLine("s shouldn't be somestring");
			}
			return new PerfResult(addTime, getTime);
		}

		public static PerfResult NonGenericHashtableAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			Hashtable list = new Hashtable();

			string[] arr = new string[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.Next().ToString();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			string s = null;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				s = (string)list[i];
			}
			long getTime = sw.ElapsedMilliseconds;

			if (s == "somestring")
			{
				Console.WriteLine("s shouldn't be somestring");
			}
			return new PerfResult(addTime, getTime);
		}

		public static PerfResult GenericHashtableAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			Dictionary<int,string> list = new Dictionary<int,string>();

			string[] arr = new string[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.Next().ToString();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			string s = null;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				s = list[i];
			}
			long getTime = sw.ElapsedMilliseconds;

			if (s == "somestring")
			{
				Console.WriteLine("s shouldn't be somestring");
			}
			return new PerfResult(addTime, getTime);
		}

		public static PerfResult NonGenericSortedListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			SortedList list = new SortedList();

			string[] arr = new string[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.Next().ToString();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			string s = null;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				s = (string)list[i];
			}
			long getTime = sw.ElapsedMilliseconds;

			if (s == "somestring")
			{
				Console.WriteLine("s shouldn't be somestring");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult GenericSortedListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			SortedDictionary<int,string> list = new SortedDictionary<int,string>();

			string[] arr = new string[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.Next().ToString();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			string s = null;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				s = list[i];
			}
			long getTime = sw.ElapsedMilliseconds;

			if (s == "somestring")
			{
				Console.WriteLine("s shouldn't be somestring");
			}
			return new PerfResult(addTime, getTime);
		}
	}	
}
