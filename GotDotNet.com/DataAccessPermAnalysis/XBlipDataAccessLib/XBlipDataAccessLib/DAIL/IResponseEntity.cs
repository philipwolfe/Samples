using System;

namespace XBLIP.DAIL
{
	/// <summary>
	/// An interface of an entity in a standard response.
	/// </summary>
	internal interface IResponseEntity
	{
		/// <summary>
		/// get an iterator over the child elements of the entity
		/// </summary>
		/// <returns>an iterator of child nodes</returns>
		IResponseEntityIterator getSubEntityIterator();

		/// <summary>
		/// get the XML definition of the entity
		/// </summary>
		/// <returns>xml definition</returns>
		string getDefinition();
	}
}
