using System;
using System.Diagnostics;

namespace Microsoft.Samples.SpaceInvaders
{

	public sealed class ListenerOperations
	{
		private ListenerOperations() { }

		public static TraceSource InitializeListener() {
			TraceSource ts = new TraceSource("MySource");
			AddListenerToSource(ts, GetListener("error"));
			return ts;
		}

		public static void RemoveListenerFromSource(TraceSource ts, string name)
		{
			foreach (TraceListener tlNext in ts.Listeners)
			{
				if (tlNext.Name == name)
				{
					((TextWriterTraceListener)tlNext).Writer.Close();
					ts.Listeners.Remove(tlNext);
					return;
				}
			}
		}

		public static void AddListenerToSource(TraceSource ts, TraceListener tl) {

			foreach (TraceListener tlNext in ts.Listeners)
			{
				if (tl.Name == tlNext.Name)
				{
					return;
				}
			}

			ts.Listeners.Add(tl);
		}

		public static void StartGameTrace( TraceSource ts) {
			ts.TraceEvent(TraceEventType.Information, (int)GameDetail.GameStarted, "-----------------------------");
			ts.TraceEvent(TraceEventType.Information, (int)GameDetail.GameStarted, "New Game Started!");
			ts.TraceEvent(TraceEventType.Information, (int)GameDetail.GameStarted, "-----------------------------");
		}

		// state why we're REALLY doing this
		public static TextWriterTraceListener GetListener(string name)
		{
			TextWriterTraceListener twtl;

			if (name == "all")
			{
				twtl = new TextWriterTraceListener("all.log", "allfile");
				twtl.TraceOutputOptions = twtl.TraceOutputOptions | TraceOptions.ProcessId;
			}
			else if (name == "error")
			{
				twtl = new TextWriterTraceListener("error.log", "errorfile");
				twtl.Filter = new System.Diagnostics.EventTypeFilter(SourceLevels.Error);
			}
			else if (name == "gamestats")
			{
				twtl = new DelimitedListTraceListener("gameStats.log", "gamestats");
			}
			else if (name == "example")
			{
				twtl = new TextWriterTraceListener("example.log", "examplelog");
				twtl.Filter = new GameDetailFilter(new GameDetail[] {GameDetail.ShipFired, GameDetail.ShipMovedLeft,
						GameDetail.ShipMovedRight});
			}
			else // gamedemo
			{
				twtl = new DelimitedListTraceListener("demo.log", "gamedemo");
			}

			twtl.TraceOutputOptions = twtl.TraceOutputOptions | TraceOptions.Timestamp;
			return twtl;
		}

		public static void Clear(TraceSource ts)
		{
			try
			{
				ts.Flush();
				ListenerOperations.RemoveListenerFromSource(ts, "gamestats");
				ListenerOperations.RemoveListenerFromSource(ts, "gamedemo");
			}
			finally
			{
			}
		}
	}

	public class GameDetailFilter : TraceFilter
	{
		private GameDetail[] _details;

		// default is a statistics filter
		public GameDetailFilter()
		{
			_details = new GameDetail[] {GameDetail.ShipFired, GameDetail.ShipBulletHitInvader, GameDetail.ShipMovedRight,
					GameDetail.ShipMovedLeft, GameDetail.GameStarted};
		}

		public GameDetailFilter(GameDetail[] details)
		{
			_details = details;
		}

		public override bool ShouldTrace(TraceEventCache cache, string source, TraceEventType severity, int id, string formatOrMessage, object[] args, object data1, object[] data)
		{
			foreach (GameDetail gd in _details)
			{
				if ((int)gd == id)
					return true;
			}
			return false;
		}
	}
}
