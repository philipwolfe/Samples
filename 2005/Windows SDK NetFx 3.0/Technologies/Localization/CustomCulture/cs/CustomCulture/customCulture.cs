//-----------------------------------------------------------------------
//  This file is part of the Microsoft .NET Framework SDK Code Samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//This source code is intended only as a supplement to Microsoft
//Development Tools and/or on-line documentation.  See these other
//materials for detailed information regarding Microsoft code samples.
// 
//THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//PARTICULAR PURPOSE.
//-----------------------------------------------------------------------
using System;
using System.Globalization;

/// <summary>
/// customCultureInfo is derived from the System.Globalization.CultureInfo
/// in order to provide support for a custom culture that is closely related
/// to its parent culture. 
/// In this sample, the custom culture's role is limited to providing access 
/// to custom culture specific resources and providing a date format but the 
/// role of the custom culture could easily be expanded to provide additional 
/// differentiation with its parent culture. To do so, it is necessary to 
/// implement support for the other properties of the base CultureInfo class 
/// by overriding them in the derived class
/// </summary>

namespace Microsoft.Samples.Localization.CustomCulture
{
	public class customCultureInfo : CultureInfo
	{
    private string myDescription;
    private string myName;
    private string myParent;

    // the constructor takes two parameters: the parent name and the custom name
		public customCultureInfo(string parent, string customName) : base(parent)
		{
      myParent      = parent;
      myName        = String.Format("{0}-{1}", parent, customName);
      myDescription = String.Format("Custom Culture ({0})", myName);

      // set formatting for date time
      NumberFormatInfo nfi = (NumberFormatInfo)base.NumberFormat.Clone();
      nfi.CurrencyPositivePattern = 3;
      nfi.CurrencyGroupSeparator = "'";
      nfi.CurrencySymbol = "$";
      nfi.CurrencyDecimalDigits = 0;
      base.NumberFormat = nfi;
		}

    public override String Name
    {
      get { return myName; }
    }

    public override CultureInfo Parent
    {
      get { return new CultureInfo(myParent); }
    }

    public override String EnglishName
    {
      get { return myDescription; }
    }

    public override String NativeName
    {
      get { return myDescription; }
    }

    public override String DisplayName
    {
      get { return myDescription; }
    }
  }
}
