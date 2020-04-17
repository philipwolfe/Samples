//---------------------------------------------------------------------
//  This file is part of the WindowsWorkflow.NET web site samples.
// 
//  Copyright (C) Microsoft Corporation.  All rights reserved.
// 
//  This source code is intended only as a supplement to Microsoft
//  Development Tools and/or on-line documentation.  See these other
//  materials for detailed information regarding Microsoft code samples.
// 
//  THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
//  KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
//  IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
//  PARTICULAR PURPOSE.
//---------------------------------------------------------------------

//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50215.44
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </autogenerated>
//------------------------------------------------------------------------------

using System.Configuration;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;

[assembly: SuppressMessage("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "ExpenseApplication.Properties.Settings.get_Default():ExpenseApplication.Properties.Settings")]

namespace ExpenseApplication.Properties
{


	[CompilerGenerated()]
	internal sealed partial class Settings : ApplicationSettingsBase
	{

		private static Settings defaultInstance = new Settings();

		public static Settings Default
		{
			get
			{
				return defaultInstance;
			}
		}
	}
}
