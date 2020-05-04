using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace GenericsPerf
{
	public class PhoneNumberTests
	{
		public static PerfResult NonGenericListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			ArrayList list = new ArrayList();

			PhoneNumber[] p = new PhoneNumber[count];
			for (int i = 0; i < count; i++)
			{
				p[i] = new PhoneNumber(r.Next(1, 999), r.Next(1000000, 9999999), r.Next(1, 280), false);
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(p[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			PhoneNumber pp = null;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					pp = (PhoneNumber)list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (pp == null)
			{
				Console.WriteLine("pp shouldn't be null");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult GenericListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			List<PhoneNumber> list = new List<PhoneNumber>();

			PhoneNumber[] p = new PhoneNumber[count];
			for (int i = 0; i < count; i++)
			{
				p[i] = new PhoneNumber(r.Next(1, 999), r.Next(1000000, 9999999), r.Next(1, 280), false);
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(p[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			PhoneNumber pp = null;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					pp = list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (pp == null)
			{
				Console.WriteLine("pp shouldn't be null");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult NonGenericHashtableAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			Hashtable list = new Hashtable();

			PhoneNumber[] p = new PhoneNumber[count];
			for (int i = 0; i < count; i++)
			{
				p[i] = new PhoneNumber(r.Next(1, 999), r.Next(1000000, 9999999), r.Next(1, 280), false);
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, p[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			PhoneNumber pp = null;
			sw.Start();

			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					pp = (PhoneNumber)list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (pp == null)
			{
				Console.WriteLine("pp shouldn't be null");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult GenericHashtableAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			Dictionary<int,PhoneNumber> list = new Dictionary<int,PhoneNumber>();

			PhoneNumber[] p = new PhoneNumber[count];
			for (int i = 0; i < count; i++)
			{
				p[i] = new PhoneNumber(r.Next(1, 999), r.Next(1000000, 9999999), r.Next(1, 280), false);
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, p[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			PhoneNumber pp = null;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					pp = list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (pp == null)
			{
				Console.WriteLine("pp shouldn't be null");
			}
			return new PerfResult(addTime, getTime);
		}

		public static PerfResult NonGenericSortedListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			SortedList list = new SortedList();

			PhoneNumber[] p = new PhoneNumber[count];
			for (int i = 0; i < count; i++)
			{
				p[i] = new PhoneNumber(r.Next(1, 999), r.Next(1000000, 9999999), r.Next(1, 280), false);
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, p[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			PhoneNumber pp = null;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					pp = (PhoneNumber)list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (pp == null)
			{
				Console.WriteLine("pp shouldn't be null");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult GenericSortedListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			SortedDictionary<int,PhoneNumber> list = new SortedDictionary<int,PhoneNumber>();

			PhoneNumber[] p = new PhoneNumber[count];
			for (int i = 0; i < count; i++)
			{
				p[i] = new PhoneNumber(r.Next(1, 999), r.Next(1000000, 9999999), r.Next(1, 280), false);
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, p[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			PhoneNumber pp = null;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 10; j++)
				{
					pp = (PhoneNumber)list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (pp == null)
			{
				Console.WriteLine("pp shouldn't be null");
			}
			return new PerfResult(addTime, getTime);
		}
	}
}