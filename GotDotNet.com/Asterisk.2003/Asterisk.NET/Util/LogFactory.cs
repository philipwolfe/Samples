using System;
using System.Diagnostics;

namespace Util
{
	public interface ILog
	{
		void debug(object obj);
		void info(object obj);
		void warn(object obj);
		void warn(object obj, Exception ex);
		void error(object obj);
		void error(object obj, Exception ex);
	}

	#region class LogFactory
	/// <summary>
	/// Facade to hide details of the underlying logging system.
	/// </summary>
	public sealed class LogFactory
	{
		private static Log logger;

		/// <summary>
		/// Returns an instance of Log suitable for logging from the given class.
		/// </summary>
		/// <returns> the created logger.</returns>
		public static ILog getLog(Type clazz)
		{
			if(logger == null)
				logger = new Log();
			return logger;
		}
	}
	#endregion

	#region class Log
	/// <summary>
	/// A Log implementation that acts as a proxy to commons-logging.
	/// </summary>
	internal class Log : ILog
	{
		/// <summary>
		/// Creates a new CommonsLoggingLog obtained from commons-logging's LogFactory for the given class.
		/// </summary>
		public Log()
		{
		}

		public virtual void debug(object obj)
		{
			Debug.WriteLine(obj.ToString());
		}

		public virtual void info(object obj)
		{
			Debug.WriteLine(obj.ToString());
		}

		public virtual void warn(object obj)
		{
			Debug.WriteLine("Warning:");
			Debug.WriteLine(obj.ToString());
		}

		public virtual void warn(object obj, Exception ex)
		{
			Debug.WriteLine("Warning:");
			Debug.WriteLine(obj.ToString());
			Debug.WriteLine(ex.ToString());
		}

		public virtual void error(object obj)
		{
			Debug.WriteLine("Error:");
			Debug.WriteLine(obj);
		}

		public virtual void error(object obj, Exception ex)
		{
			Debug.WriteLine("Error:");
			Debug.WriteLine(obj);
			Debug.WriteLine(ex.ToString());
		}
	}
	#endregion
}