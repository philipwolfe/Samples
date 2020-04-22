using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace Microsoft.Samples.SpaceInvaders
{
	public class GameData
	{
		SortedList<long, GameEvent> _data;
		public GameData()
		{
			_data = new SortedList<long, GameEvent>();
		}

		[CLSCompliant(false)]
		public SortedList<long, GameEvent> Events{ get { return _data; } }
	}

	public class GameEvent
	{
		TraceEventType _eventType;
		GameDetail _id;
		string _message;
		long _ticks;

		public GameEvent(string eventType, string id, string message, long ticks)
		{
			_eventType = (TraceEventType)Enum.Parse(typeof(TraceEventType), eventType);
			_id = (GameDetail)Enum.Parse(typeof(GameDetail), id);
			_message = message;
			_ticks = ticks;
		}

		public TraceEventType TraceEventType { get { return _eventType; } }
		public GameDetail GameDetail { get { return _id; } }
		public string Message { get { return _message; } }
		public long Ticks { get { return _ticks; } }
	}
}
