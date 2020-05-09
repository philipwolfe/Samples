using System;

namespace XSLQueryBuilderApp
{
	
	public abstract class Track:ITrack
	{
		protected DataAccessProvider _dataAccessProvider;
		protected string _label;
		protected int _pipe;

		public const int PIPE_NONE = -2;
		public const int PIPE_PREV = -1;

		public Track():this("")
		{}

		public Track(string iLabel)
		{
			label = iLabel;
			pipe = PIPE_NONE;
		}

		public string label 
		{
			get 
			{
				return _label;
			}
			set 
			{
				_label = value;
			}
		}

		public int pipe 
		{
			get 
			{
				return _pipe;
			}

			set 
			{
				_pipe = value;
			}
		}

		public DataAccessProvider  dataAccessProvider
		{
			get 
			{
				return _dataAccessProvider;
			}

			set 
			{
				_dataAccessProvider = value;
			}
		}

		public override string ToString() 
		{
			return label;
		}

		public abstract void accept(ITrackVisitor visitor);

	}
}
