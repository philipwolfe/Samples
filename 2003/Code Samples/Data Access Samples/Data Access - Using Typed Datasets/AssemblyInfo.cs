//Copyright (C) 2002 Microsoft Corporation
//All rights reserved.
//THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND, EITHER 
//EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE IMPLIED WARRANTIES OF 
//MERCHANTIBILITY AND/OR FITNESS FOR A PARTICULAR PURPOSE.
//Requires the Trial or Release version of Visual Studio .NET Professional (or greater).

using System;
using System.Reflection;

[assembly: AssemblyTitle("C# How-To: Typed Datasets")]
[assembly: AssemblyDescription("Microsoft C# How-To: Typed Datasets")]
[assembly: AssemblyCompany("Microsoft Corporation")]
[assembly: AssemblyProduct("Microsoft C# How To: 2002")]
[assembly: AssemblyCopyright("Copyright  2002 Microsoft Corporation.  All rights reserved.")]
[assembly: CLSCompliant(true)]
[assembly: AssemblyVersion("1.0.0.0")]

#region " Helper class to get information for the About form. "
// This class uses the System.Reflection.Assembly class to
// access assembly meta-data
// This class is not a normal feature of AssemblyInfo.cs

public class AssemblyInfo
{
	// Used by Helper Functions to access information from Assembly Attributes

	private Type myType;

	public AssemblyInfo() 
	{
		myType = typeof(frmMain);
	}

	public string AsmName {

		get {

			return myType.Assembly.GetName().Name.ToString();

		}

	}

	public string AsmFQName {

		get {

			return myType.Assembly.GetName().FullName.ToString();

		}

	}

	public string CodeBase {

		get {

			return myType.Assembly.CodeBase;

		}

	}

	public string Copyright {

		get {

			Type at = typeof(AssemblyCopyrightAttribute);

			object[] r = myType.Assembly.GetCustomAttributes(at, false);

			AssemblyCopyrightAttribute ct = (AssemblyCopyrightAttribute) r[0];

			return ct.Copyright;

		}

	}

	public string Company {

		get {

            Type at = typeof(AssemblyCompanyAttribute);

			object[] r = myType.Assembly.GetCustomAttributes(at, false);

			AssemblyCompanyAttribute ct = (AssemblyCompanyAttribute) r[0];

			return ct.Company;

		}

	}

	public string Description {

		get {

			Type at = typeof(AssemblyDescriptionAttribute);

			object[] r = myType.Assembly.GetCustomAttributes(at, false);

			AssemblyDescriptionAttribute da = (AssemblyDescriptionAttribute) r[0];

			return da.Description;

		}

	}

	public string Product {

		get {

			Type at = typeof(AssemblyProductAttribute);

			object[] r = myType.Assembly.GetCustomAttributes(at, false);

			AssemblyProductAttribute pt = (AssemblyProductAttribute) r[0];

			return pt.Product;

		}

	}

	public string Title {

		get {

			Type at = typeof(AssemblyTitleAttribute);

			object[] r = myType.Assembly.GetCustomAttributes(at, false);

			AssemblyTitleAttribute ta = (AssemblyTitleAttribute) r[0];

			return ta.Title;

		}

	}

	public string Version {

		get {

			return myType.Assembly.GetName().Version.ToString();

		}

	}

}

#endregion

