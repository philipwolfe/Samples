using System;

namespace XBLIP.DAIL
{
	/// <summary>
	/// An interface representing an item in standard response
	/// </summary>
	internal interface IResponseItem:IResponseEntity
	{
		/// <summary>
		/// return the item id attribute value
		/// </summary>
		/// <returns>string, id</returns>
		string getID();

	}
}
