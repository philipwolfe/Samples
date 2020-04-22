using Asterisk.NET.FastAGI.Command;

namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// Default implementation of the AGIChannel interface.
	/// </summary>
	public class AGIChannel : IAGIChannel
	{
		private AGIWriter agiWriter;
		private AGIReader agiReader;

		public AGIChannel(IO.SocketConnection socket)
		{
			this.agiWriter = new AGIWriter(socket);
			this.agiReader = new AGIReader(socket);
		}

		public AGIChannel(AGIWriter agiWriter, AGIReader agiReader)
		{
			this.agiWriter = agiWriter;
			this.agiReader = agiReader;
		}

		public virtual AGIReply SendCommand(Command.AGICommand command)
		{
			lock (this)
			{
				agiWriter.SendCommand(command);
				AGIReply reply = agiReader.ReadReply();
				int status = reply.GetStatus();
				if (status == (int)AGIReplyStatuses.SC_INVALID_OR_UNKNOWN_COMMAND)
					throw new InvalidOrUnknownCommandException(command.BuildCommand());
				else if (reply.GetStatus() == (int)AGIReplyStatuses.SC_INVALID_COMMAND_SYNTAX)
					throw new InvalidCommandSyntaxException(reply.GetSynopsis(), reply.GetUsage());
				return reply;
			}
		}

		public void Answer()
		{
			SendCommand(new AnswerCommand());
		}
		public void Hangup()
		{
			SendCommand(new HangupCommand());
		}

		public void SetAutoHangup(int time)
		{
			SendCommand(new SetAutoHangupCommand(time));
		}
		public void SetCallerId(string callerId)
		{
			SendCommand(new SetCallerIdCommand(callerId));
		}

		public void PlayMusicOnHold()
		{
			SendCommand(new SetMusicOnCommand());
		}

		public void PlayMusicOnHold(string musicOnHoldClass)
		{
			SendCommand(new SetMusicOnCommand(musicOnHoldClass));
		}

		public void StopMusicOnHold()
		{
			SendCommand(new SetMusicOffCommand());
		}

		public int GetChannelStatus()
		{
			AGIReply reply = SendCommand(new ChannelStatusCommand());
			return reply.ResultCode;
		}

		public string GetData(string file)
		{
			AGIReply reply = SendCommand(new GetDataCommand(file));
			return reply.GetResult();
		}
		public string GetData(string file, int timeout)
		{
			AGIReply reply = SendCommand(new GetDataCommand(file, timeout));
			return reply.GetResult();
		}
		public string GetData(string file, int timeout, int maxDigits)
		{
			AGIReply reply = SendCommand(new GetDataCommand(file, timeout, maxDigits));
			return reply.GetResult();
		}
		public char GetOption(string file, string escapeDigits)
		{
			AGIReply reply = SendCommand(new GetOptionCommand(file, escapeDigits));
			return reply.ResultCodeAsChar;
		}

		public char GetOption(string file, string escapeDigits, int timeout)
		{
			AGIReply reply = SendCommand(new GetOptionCommand(file, escapeDigits, timeout));
			return reply.ResultCodeAsChar;
		}
		public int Exec(string application)
		{
			AGIReply reply = SendCommand(new ExecCommand(application));
			return reply.ResultCode;
		}
		public int Exec(string application, string options)
		{
			AGIReply reply = SendCommand(new ExecCommand(application, options));
			return reply.ResultCode;
		}
		public void SetContext(string context)
		{
			SendCommand(new SetContextCommand(context));
		}
		public void SetExtension(string extension)
		{
			SendCommand(new SetExtensionCommand(extension));
		}
		public void SetPriority(int priority)
		{
			SendCommand(new SetPriorityCommand(priority));
		}
		public void StreamFile(string file)
		{
			SendCommand(new StreamFileCommand(file));
		}
		public char StreamFile(string file, string escapeDigits)
		{
			AGIReply reply = SendCommand(new StreamFileCommand(file, escapeDigits));
			return reply.ResultCodeAsChar;
		}
		public void SayDigits(string digits)
		{
			SendCommand(new SayDigitsCommand(digits));
		}

		public char SayDigits(string digits, string escapeDigits)
		{
			AGIReply reply = SendCommand(new SayDigitsCommand(digits, escapeDigits));
			return reply.ResultCodeAsChar;
		}

		public void SayNumber(string number)
		{
			SendCommand(new SayNumberCommand(number));
		}

		public char SayNumber(string number, string escapeDigits)
		{
			AGIReply reply = SendCommand(new SayNumberCommand(number, escapeDigits));
			return reply.ResultCodeAsChar;
		}

		public void SayPhonetic(string text)
		{
			SendCommand(new SayPhoneticCommand(text));
		}

		public char SayPhonetic(string text, string escapeDigits)
		{
			AGIReply reply = SendCommand(new SayPhoneticCommand(text, escapeDigits));
			return reply.ResultCodeAsChar;
		}

		public void SayAlpha(string text)
		{
			SendCommand(new SayAlphaCommand(text));
		}

		public char SayAlpha(string text, string escapeDigits)
		{
			AGIReply reply = SendCommand(new SayAlphaCommand(text, escapeDigits));
			return reply.ResultCodeAsChar;
		}

		public void SayTime(long time)
		{
			SendCommand(new SayTimeCommand(time));
		}

		public char SayTime(long time, string escapeDigits)
		{
			AGIReply reply = SendCommand(new SayTimeCommand(time, escapeDigits));
			return reply.ResultCodeAsChar;
		}

		public string GetVariable(string name)
		{
			AGIReply reply = SendCommand(new GetVariableCommand(name));
			if (reply.ResultCode != 1)
				return null;
			return reply.Extra;
		}

		public void SetVariable(string name, string value)
		{
			SendCommand(new SetVariableCommand(name, value));
		}

		public char WaitForDigit(int timeout)
		{
			AGIReply reply = SendCommand(new WaitForDigitCommand(timeout));
			return reply.ResultCodeAsChar;
		}
	}
}
