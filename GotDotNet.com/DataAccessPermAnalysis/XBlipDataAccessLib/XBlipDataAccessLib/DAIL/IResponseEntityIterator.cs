using System;

namespace XBLIP.DAIL
{
	/// <summary>
	/// iterator of entities in a standard response
	/// </summary>
	internal interface IResponseEntityIterator
	{
		/// <summary>
		/// get to the next value in the iteration
		/// </summary>
		/// <returns>
		/// the next pointed entity in the iteration
		/// </returns>
		IResponseEntity nextValue();

		/// <summary>
		/// read only property used to get 
		/// the current entity in the iteration
		/// </summary>
		/// <returns>
		/// the current entity
		/// </returns>
		IResponseEntity current 
		{
			get;
		}

		/// <summary>
		/// return whether this iteration is over
		/// </summary>
		/// <returns>true if no more entities are left in this
		/// iteration. false otherwise</returns>
		bool eof();
	}
}
