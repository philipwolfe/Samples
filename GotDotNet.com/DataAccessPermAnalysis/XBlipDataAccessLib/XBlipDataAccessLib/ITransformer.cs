using System;

namespace XBLIP
{
	/// <summary>
	/// transformer of a string to another.
	/// used for transforming Requests in DAIL and PAL
	/// to either a series of tracks or a series of tests/groups 
	/// (accordingly). Users of this interface implementations should
	/// be aware of the capabilities of the concrete classes, for some of
	/// they may be good only for request, some of the only for responses 
	/// , or maybe some good only for use with DAIL etc.
	/// </summary>
	public interface ITransformer
	{
		/// <summary>
		/// transform the input string to a returned string
		/// </summary>
		/// <param name="toTransform">string to transform</param>
		/// <returns>a transformed string</returns>
		string transform(string toTransform);
	}
}
