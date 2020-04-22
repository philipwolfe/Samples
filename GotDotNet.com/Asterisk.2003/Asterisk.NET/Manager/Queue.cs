using System.Collections;
using System.Text;

namespace Asterisk.NET.Manager
{
	public class Queue
	{
		private string name;
		private int max;
		private IList entries;

		virtual public string Name
		{
			get { return name; }
		}

		virtual public int Max
		{
			get { return max; }
			set { this.max = value; }
		}

		virtual public IList Entries
		{
			get { return entries; }
		}
		
		public Queue(string name)
		{
			this.name = name;
			this.entries = ArrayList.Synchronized(new ArrayList(new ArrayList()));
		}

		public virtual void  AddEntry(Channel entry)
		{
			if (entry == null) return;
			lock(entries.SyncRoot)
			{
				if(!entries.Contains(entry))
					entries.Add(entry);
			}
		}

		public virtual void  RemoveEntry(Channel entry)
		{
			if (entry == null) return;
			lock(entries.SyncRoot)
			{
				if (entries.Contains(entry))
					entries.Remove(entry);
			}
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder(GetType().FullName);
			sb.Append(": name='" + Name);
			sb.Append("'; max='" + Max);
			sb.Append("'; entries='" + Utils.CollectionToString(Entries));
			sb.Append("'; systemHashcode=" + this.GetHashCode());
			return sb.ToString();
		}
	}
}