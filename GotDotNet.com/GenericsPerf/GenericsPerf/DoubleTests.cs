using System;
using System.Diagnostics;
using System.Collections;
using System.Collections.Generic;

namespace GenericsPerf
{
	public class DoubleTests
	{
		public static PerfResult NonGenericListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			ArrayList list = new ArrayList();

			double[] arr = new double[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.NextDouble();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			Double d = 0;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					d = (Double)list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (d < 0)
			{
				Console.WriteLine("d shouldn't be negative");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult GenericListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			List<double> list = new List<double>();

			double[] arr = new double[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.NextDouble();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			Double d = 0;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					d = list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (d < 0)
			{
				Console.WriteLine("d shouldn't be negative");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult NonGenericHashtableAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			Hashtable list = new Hashtable();

			double[] arr = new double[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.NextDouble();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			Double d = 0;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					d = (Double)list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (d < 0)
			{
				Console.WriteLine("d shouldn't be negative");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult GenericHashtableAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			Dictionary<int,double> list = new Dictionary<int,double>();

			double[] arr = new double[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.NextDouble();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			Double d = 0;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					d = list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (d < 0)
			{
				Console.WriteLine("d shouldn't be negative");
			}
			return new PerfResult(addTime, getTime);
		}

		public static PerfResult NonGenericSortedListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			SortedList list = new SortedList();

			double[] arr = new double[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.NextDouble();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			Double d = 0;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					d = (Double)list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (d < 0)
			{
				Console.WriteLine("d shouldn't be negative");
			}
			return new PerfResult(addTime, getTime);
		}


		public static PerfResult GenericSortedListAddTest(int count, Random r)
		{
			Stopwatch sw = new Stopwatch();
			SortedDictionary<int,Double> list = new SortedDictionary<int,Double>();

			double[] arr = new double[count];
			for (int i = 0; i < count; i++)
			{
				arr[i] = r.NextDouble();
			}

			sw.Start();
			for (int i = 0; i < count; i++)
			{
				list.Add(i, arr[i]);
			}
			long addTime = sw.ElapsedMilliseconds;

			sw.Reset();
			Double d = 0;
			sw.Start();
			for (int i = 0; i < count; i++)
			{
				for (int j = 0; j < 30; j++)
				{
					d = list[i];
				}
			}
			long getTime = sw.ElapsedMilliseconds;

			if (d < 0)
			{
				Console.WriteLine("d shouldn't be negative");
			}
			return new PerfResult(addTime, getTime);
		}
	}
}