using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace GenericsPerf
{
	public class IntegerTests
	{
		public static PerfResult NonGenericListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			ArrayList list = new ArrayList();

			int[] arr = new int[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.Next();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			int ii = 0;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					ii = (int)list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (ii < 0)
			{
				Console.WriteLine("ii shouldn't be negative");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult GenericListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			List<int> list = new List<int>();

			int[] arr = new int[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.Next();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			int ii = 0;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					ii = list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (ii < 0)
			{
				Console.WriteLine("ii shouldn't be negative");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult NonGenericHashtableAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			Hashtable list = new Hashtable();

			int[] arr = new int[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.Next();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			int ii = 0;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					ii = (int)list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (ii < 0)
			{
				Console.WriteLine("ii shouldn't be negative");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult GenericHashtableAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			Dictionary<int,int> list = new Dictionary<int,int>();

			int[] arr = new int[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.Next();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			int ii = 0;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					ii = list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (ii < 0)
			{
				Console.WriteLine("ii shouldn't be negative");
			}
			return new PerfResult(addTime, getTime);
		}

		public static PerfResult NonGenericSortedListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			SortedList list = new SortedList();

			int[] arr = new int[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.Next();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			int ii = 0;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				ii = (int)list[i];
			}
			long getTime = sw.ElapsedMilliseconds;

			if (ii < 0)
			{
				Console.WriteLine("ii shouldn't be negative");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult GenericSortedListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			SortedDictionary<int,int> list = new SortedDictionary<int,int>();

			int[] arr = new int[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.Next();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			int ii = 0;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				ii = list[i];
			}
			long getTime = sw.ElapsedMilliseconds;

			if (ii < 0)
			{
				Console.WriteLine("ii shouldn't be negative");
			}
			return new PerfResult(addTime, getTime);
		}
	}
}