using System;

namespace XBLIP.DAIL
{
	/// <summary>
	/// an interface representing a field of an item in a standard
	/// response
	/// </summary>
	internal interface IResponseItemField:IResponseEntity
	{
		/// <summary>
		/// get the field name
		/// </summary>
		/// <returns>string, name of field</returns>
		string getName();

		/// <summary>
		/// get the content of the field
		/// </summary>
		/// <returns>stirng, content of field</returns>
		string getContent();

		/// <summary>
		/// get the priority attribute of the item. 0 if does not exist
		/// </summary>
		/// <returns>number, priority</returns>
		int getPriority();

		/// <summary>
		/// get the type attribute of the field
		/// </summary>
		/// <returns>string, type</returns>
		string getTypeAttribute();

		/// <summary>
		/// get the order attribute of the field. 0 if does not exist
		/// </summary>
		/// <returns>number, order</returns>
		int getOrder();

	}
}
