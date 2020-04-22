namespace Asterisk.NET.FastAGI
{
	/// <summary>
	/// The AGIReader reads the replies from the network and parses them using a ReplyBuilder.
	/// </summary>
	public interface IAGIReader
	{
		/// <summary>
		/// Reads the initial request data from Asterisk.
		/// </summary>
		/// <returns>the request read.</returns>
		/// <throws>  AGIException if the request can't be read. </throws>
		AGIRequest ReadRequest();
		
		/// <summary>
		/// Reads one reply to an AGICommand from Asterisk.
		/// </summary>
		/// <returns>the reply read.</returns>
		/// <throws>  AGIException if the reply can't be read. </throws>
		AGIReply ReadReply();
	}
}