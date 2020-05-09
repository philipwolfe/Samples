using System;
using System.Diagnostics;

namespace WhoIsProcUI
{
	/// <summary>
	/// Summary description for ProcessItem.
	/// </summary>
	public class ProcessItem
	{
		public int Pid;
		public TimeSpan CPUTime;
		public ProcessItem(Process p)
		{
			Pid = p.Id;
			CPUTime = p.TotalProcessorTime;
		}
		public override bool Equals(object o)
		{
			Process p = (o as Process);
			if (p != null)
			{
				return (p.Id == Pid) && (p.TotalProcessorTime >= CPUTime);
			}

			ProcessItem pi = (o as ProcessItem);
			if (pi != null)
			{
				return (this.Pid == pi.Pid) && (this.CPUTime >= pi.CPUTime);
			}

			return base.Equals(o);
		}
		public override int GetHashCode()
		{
			return base.GetHashCode ();
		}

	}
}
