using System;
using System.IO;
using System.Collections;

namespace Asterisk.NET.FastAGI
{
	public class AGIReader : IAGIReader
	{
		private Util.ILog logger;
		private IO.SocketConnection socket;
		public AGIReader(IO.SocketConnection socket)
		{
			this.logger = Util.LogFactory.getLog(GetType());
			this.socket = socket;
		}

		public virtual AGIRequest ReadRequest()
		{
			string line;
			IList lines = new ArrayList();
			try
			{
				logger.info("AGIReader.ReadRequest():");
				while ((line = socket.ReadLine()) != null)
				{
					if (line.Length == 0)
						break;			
					lines.Add(line);
					logger.info(line);
				}
			}
			catch (IOException e)
			{
				throw new AGINetworkException("Unable to read request from Asterisk: " + e.Message, e);
			}

			AGIRequest request = new AGIRequest(lines);

			request.LocalAddress = socket.LocalAddress;
			request.LocalPort = socket.LocalPort;
			request.RemoteAddress = socket.RemoteAddress;
			request.RemotePort = socket.RemotePort;

			return request;
		}
		
		public virtual AGIReply ReadReply()
		{
			string line;

			IList lines = new ArrayList();
			try
			{
				line = socket.ReadLine();
			}
			catch (IOException e)
			{
				throw new AGINetworkException("Unable to read reply from Asterisk: " + e.Message, e);
			}
			if (line == null)
			{
				throw new AGIHangupException();
			}

			lines.Add(line);
			// read synopsis and usage if statuscode is 520
			if (line.StartsWith(Convert.ToString((int)AGIReplyStatuses.SC_INVALID_COMMAND_SYNTAX)))
			{
				try
				{
					while ((line = socket.ReadLine()) != null)
					{
						lines.Add(line);
						if (line.StartsWith(Convert.ToString((int)AGIReplyStatuses.SC_INVALID_COMMAND_SYNTAX)))
							break;
					}
				}
				catch (IOException e)
				{
					throw new AGINetworkException("Unable to read reply from Asterisk: " + e.Message, e);
				}
			}
			
			return new AGIReply(lines);
		}
	}
}
