using System;

namespace XBLIP.PAL
{
	/// <summary>
	/// An interface used for classes used by <c>AbstractPAL</c> methods to 
	/// retrieve a list of items.
	/// The interface should be implemented by buisnes logic classes that
	/// wish to use <c>censorResponse</c> and <c>retrievePermissions</c> of
	/// <c>AbstractPAL</c>. The single method that this interface defines accepts
	/// a standard request with the id of the queried item, and an action attribute of
	/// the value "Retrieve". The request has always an empty "Data" section and a profile
	/// that should be supported (the profile is defined by tests profile - which probably
	/// are supported - and profile that is given to other actions (in the case
	/// of <c>retrievePermissions</c>). The method then returns a standard response
	/// with empty "Item" tags each including an "id". The items match the profile
	/// given. <c>AbstractPAL</c> uses this interface to get a list of permitted items
	/// according to a given profile, for its own use...
	/// 
	/// It is recomended that if a "Retrieve" action is already to be defined for this
	/// class, that a private class (creatable only by the buisness logic class) will implement
	/// the actual retrieve call without the permission check section. This way the safe
	/// queries from PAL will not have to go through the whole proccess but just the
	/// actual query. The buisness object uses this class also as the regular retrieve
	/// executer.
	/// </summary>
	public interface IItemsListRetriever
	{

		/// <summary>
		/// retrieve a list of items as defined by the standard request
		/// </summary>
		/// <param name="strRequest">a standard "Retrieve" request</param>
		/// <returns>a standard response listing items (no fields required)</returns>
		string retrieveItemsList(string strRequest);
	}
}
