using System;


namespace Ironring.Management.MMC
{
	/// <summary>
	/// Generic exception class for the snapin framework
	/// </summary>
	public class SnapinException : ApplicationException
	{
		public SnapinException(string message) : base(message)
		{
		}
    
        public SnapinException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
