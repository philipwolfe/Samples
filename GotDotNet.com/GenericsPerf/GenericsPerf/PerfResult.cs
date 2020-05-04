using System;

namespace GenericsPerf
{
	public class PerfResult
	{
		long _elapsedAdd;
		long _elapsedGet;

		public PerfResult(long elapsedAdd, long elapsedGet)
		{
			_elapsedAdd = elapsedAdd;
			_elapsedGet = elapsedGet;
		}

		public long ElapsedAdd { get { return _elapsedAdd; } set { _elapsedAdd = value; } }
		public long ElapsedGet { get { return _elapsedGet; } set { _elapsedGet = value; } }
	}
}
