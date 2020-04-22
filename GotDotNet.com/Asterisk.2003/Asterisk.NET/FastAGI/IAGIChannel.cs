using System;
namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// Provides the functionality to send AGICommands to Asterisk while handling an
	/// AGIRequest.<br/>
	/// This interface is supposed to be used by AGIScripts for interaction with the
	/// Asterisk server.
	/// </summary>
	public interface IAGIChannel
	{
		/// <summary>
		/// Sends a command to asterisk and returns the corresponding reply.
		/// </summary>
		/// <param name="command">the command to send.</param>
		/// <returns> the reply of the asterisk server containing the return value.</returns>
		/// <throws>  AGIException if the command can't be sent to Asterisk (for example because the channel has been hung up) </throws>
		AGIReply SendCommand(Command.AGICommand command);
		void Answer();
		void Hangup();
		void SetAutoHangup(int time);
		void SetCallerId(string callerId);
		void PlayMusicOnHold();
		void PlayMusicOnHold(string musicOnHoldClass);
		void StopMusicOnHold();
		int GetChannelStatus();
		string GetData(string file);
		string GetData(string file, int timeout);
		string GetData(string file, int timeout, int maxDigits);
		char GetOption(string file, string escapeDigits);
		char GetOption(string file, string escapeDigits, int timeout);
		int Exec(string application);
		int Exec(string application, string options);
		void SetContext(string context);
		void SetExtension(string extension);
		void SetPriority(int priority);
		void StreamFile(string file);
		char StreamFile(string file, string escapeDigits);
		void SayDigits(string digits);
		char SayDigits(string digits, string escapeDigits);
		void SayNumber(string number);
		char SayNumber(string number, string escapeDigits);
		void SayPhonetic(string text);
		char SayPhonetic(string text, string escapeDigits);
		void SayAlpha(string text);
		char SayAlpha(string text, string escapeDigits);
		void SayTime(long time);
		char SayTime(long time, string escapeDigits);
		string GetVariable(string name);
		void SetVariable(string name, string value);
		char WaitForDigit(int timeout);
	}
}