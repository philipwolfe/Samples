using System;

namespace GenericsPerf
{
	/// <summary>
	/// Summary description for PhoneNumber.
	/// </summary>
	public class PhoneNumber
	{
		int _countryCode;
		int _areaCode;
		int _phoneValue;
		bool _displayCountryCode;

		public PhoneNumber(int areaCode, int phoneValue, int countryCode, bool displayCountryCode)
		{
			_countryCode = countryCode;
			_areaCode = areaCode;
			_phoneValue = phoneValue;
			_displayCountryCode = displayCountryCode;
		}
		public int CountryCode { get { return _countryCode; } }
		public int AreaCode { get { return _areaCode; } }
		public int PhoneValue { get { return _phoneValue; } }
		public bool DisplayCountryCode { get { return _displayCountryCode; } }
	}

}
