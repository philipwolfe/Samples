using System;

namespace XBLIP.DAIL
{

	/// <summary>
	/// an interface representing a standard response reader.
	/// The interface defines a single method that hands an iterator
	/// for the items
	/// </summary>
	internal interface IResponseReader
	{
		/// <summary>
		///	return an iterator of items
		/// </summary>
		/// <returns>
		/// an iterator of the items in the standard response
		/// </returns>
		IResponseEntityIterator getItemsIterator();
	}
}
