using System;
using System.IO;
using System.Collections;

namespace XSLQueryBuilderApp
{
	public abstract class TrackWriter:ITrackWriter
	{

		private XSLTextWriter _output;
		private const string QUERY_SEPERATOR = "QUERY_SEPERATOR";
		
		protected TrackWriter():this(null) {}

		protected TrackWriter(XSLTextWriter iOutput)
		{
			_output = iOutput;
		}

		public abstract ITrack track 
		{
			get; 
			set;
		}

		public XSLTextWriter output 
		{
			get 
			{
				return _output;
			}

			set 
			{
				_output = value;
			}
		}

		public void write() 
		{
			writeTrackHeader();
			writeTrackBody();
			writeTrackFooter();
		}

		private void writeTrackHeader() 
		{
			_output.WriteStartTextElement();
			writeHeaderStart();
			writeParams();
			_output.WriteString(" \n");
			_output.WriteEndTextElement();
		}

		protected abstract void writeTrackBody();

		private void writeHeaderStart() 
		{
			_output.WriteString(QUERY_SEPERATOR);
			_output.WriteString("-");
			_output.WriteString(track.dataAccessProvider.label);
			_output.WriteString("-");
		}

		private void writeParams() 
		{
			writePipe();
			writeInternalParams();
		}

		protected virtual void writeInternalParams() {}

		private void writePipe()
		{ 
			if(track.pipe != Track.PIPE_NONE) 
			{
				_output.WriteString("_pipe");
				if(track.pipe != Track.PIPE_PREV)
					_output.WriteString(track.pipe.ToString());
				_output.WriteString("_");
			}
		}

		private void writeTrackFooter() 
		{
			_output.WriteTextElement(" \n");
		}

	}
}
