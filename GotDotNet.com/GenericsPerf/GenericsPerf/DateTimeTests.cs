using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace GenericsPerf
{
	public class DateTimeTests
	{
		public static PerfResult NonGenericListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			ArrayList list = new ArrayList();

			DateTime[] arr = new DateTime[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = new DateTime(r.Next());
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			DateTime d = new DateTime();
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					d = (DateTime)list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (d == DateTime.Now)
			{
				Console.WriteLine("dd shouldn't be now");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult GenericListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			List<DateTime> list = new List<DateTime>();

			DateTime[] arr = new DateTime[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = new DateTime(r.Next());
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			DateTime d = new DateTime();
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					d = list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (d == DateTime.Now)
			{
				Console.WriteLine("dd shouldn't be now");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult NonGenericHashtableAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			Hashtable list = new Hashtable();

			DateTime[] arr = new DateTime[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = new DateTime(r.Next());
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			DateTime d = new DateTime();
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					d = (DateTime)list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (d == DateTime.Now)
			{
				Console.WriteLine("dd shouldn't be now");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult GenericHashtableAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			Dictionary<int,DateTime> list = new Dictionary<int,DateTime>();

			DateTime[] arr = new DateTime[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = new DateTime(r.Next());
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			DateTime d = new DateTime();
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					d = list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (d == DateTime.Now)
			{
				Console.WriteLine("dd shouldn't be now");
			}
			return new PerfResult(addTime, getTime);
		}

		public static PerfResult NonGenericSortedListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			SortedList list = new SortedList();

			DateTime[] arr = new DateTime[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = new DateTime(r.Next());
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			DateTime d = new DateTime();
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					d = (DateTime)list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (d == DateTime.Now)
			{
				Console.WriteLine("dd shouldn't be now");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult GenericSortedListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			SortedDictionary<int,DateTime> list = new SortedDictionary<int,DateTime>();

			DateTime[] arr = new DateTime[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = new DateTime(r.Next());
			}

			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			DateTime d = new DateTime();
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					d = list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (d == DateTime.Now)
			{
				Console.WriteLine("dd shouldn't be now");
			}
			return new PerfResult(addTime, getTime);
		}
	}
}