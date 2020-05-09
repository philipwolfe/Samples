using System;

namespace XBLIP.PAL
{

	/// <summary>
	/// a test profider interface. A specific test provider defines a closed
	/// test that can answer, given a context (username?) and parameters string
	/// the usage level of a request. A test provider may return one of:
	/// <lu>
	///		<li>an "ABORT" string - when the test fails. For example, when a user
	///		does not have a required role</li>
	///		<li>a limiting profile - a section of profile parameters to be inserted into
	///		a profile of a reuqest, to limit the range of items that are allowed by the person.
	///		An example to such a test is a heirarchy test that allows only items that are
	///		in the user heirarchy to be effected by the request
	///		</li>
	///		<li>empty string - when test is OK and no limiting profile is issues</li>
	/// </lu>
	/// </summary>
	public interface IPALTestProvider
	{
		/// <summary>
		/// perform the test with the given parameters
		/// </summary>
		/// <param name="strParams">test specific parameters</param>
		/// <returns>one of 3 results (see class header for specifications)</returns>
		string getLimitiation(string strParams);
	}
}
