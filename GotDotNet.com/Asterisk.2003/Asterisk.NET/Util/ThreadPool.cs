using System.Threading;
using System.Collections;

namespace Util
{
	/// <summary>
	/// A fixed sized thread pool.
	/// </summary>
	public class ThreadPool
	{
		private ILog logger;
		private bool running;
		private int numThreads;
		private string name;
		private IList jobs;
		
		/// <summary>
		/// Creates a new ThreadPool of numThreads size. These Threads are waiting
		/// for jobs to be added via the addJob method.
		/// </summary>
		/// <param name="name">the name to use for the thread group and worker threads.</param>
		/// <param name="numThreads">the number of threads to create.</param>
		public ThreadPool(string name, int numThreads)
		{
			logger = LogFactory.getLog(GetType());

			this.name = name;
			this.numThreads = numThreads;
			jobs = new ArrayList();
			running = true;
			
			// create and start the threads
			for (int i = 0; i < this.numThreads; i++)
			{
				TaskThread thread;
				thread = new TaskThread(this, this.name + "-TaskThread-" + i);
				thread.Start();
			}
			logger.debug("ThreadPool created with " + this.numThreads + " threads.");
		}
		
		/// <summary>
		/// Gets a job from the queue. If none is availble the calling thread is
		/// blocked until one is added.
		/// </summary>
		/// <returns>the next job to service, <code>null</code> if the worker thread should be shut down.</returns>
		internal virtual IThreadRunnable obtainJob()
		{
			IThreadRunnable job = null;
			lock (jobs)
			{
				while (job == null && running)
				{
					try
					{
						if (jobs.Count == 0)
							Monitor.Wait(jobs);
					}
					catch (ThreadInterruptedException ie)
					{
						logger.error("System.Threading.ThreadInterruptedException.", ie);
					}
					if (jobs.Count > 0)
					{
						job = (IThreadRunnable) jobs[0];
						jobs.RemoveAt(0);
					}
				}
			}
			
			if (running)
			{
				// Got a job from the queue
				return job;
			}
			else
			{
				// Shut down the pool
				return null;
			}
		}
		
		/// <summary> Adds a new job to the queue. This will be picked up by the next available
		/// active thread.
		/// </summary>
		public virtual void  AddJob(IThreadRunnable runnable)
		{
			lock (jobs)
			{
				jobs.Add(runnable);
				Monitor.PulseAll(jobs);
			}
		}
		
		/// <summary> Turn off the pool. Every thread, when finished with its current work,
		/// will realize that the pool is no longer running, and will exit.
		/// </summary>
		public virtual void  Shutdown()
		{
			running = false;
			lock (jobs)
			{
				Monitor.PulseAll(jobs);
			}
			logger.debug("ThreadPool shutting down.");
		}
		
		/// <summary> A TaskThread sits in a loop, asking the pool for a job, and servicing it.</summary>
		internal class TaskThread : Utils.ThreadClass
		{
			private ThreadPool enclosingInstance;
			public ThreadPool Enclosing_Instance
			{
				get { return enclosingInstance; }
			}

			public TaskThread(ThreadPool enclosingInstance, string name)
				: base(name)
			{
				this.enclosingInstance = enclosingInstance;
			}
			
			/// <summary>
			/// Get a job from the pool, run it, repeat. If the obtained job is null, we exit the loop and the thread.
			/// </summary>
			override public void  Run()
			{
				while (true)
				{
					IThreadRunnable job = Enclosing_Instance.obtainJob();
					if (job == null)
					{
						// no more jobs available as ThreadPool has been closed? ->
						// end this Thread
						break;
					}
					job.Run();
				}
			}
		}
	}
}
