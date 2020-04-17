//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Hands on Labs RC
//
// Copyright (c) Microsoft Corporation. All rights reserved.
//
// This source code is intended only as a supplement to Microsoft
// Development Tools and/or on-line documentation.  See these other
// materials for detailed information regarding Microsoft code samples.
// 
// THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
// KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
// IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
// PARTICULAR PURPOSE.
//--------------------------------------------------------------------------------

[assembly: global::System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1811:AvoidUncalledPrivateCode", Scope = "member", Target = "ManagerApplication.Properties.Settings.get_Default():ManagerApplication.Properties.Settings")]

namespace ManagerApplication.Properties
{


	[global::System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
	internal sealed partial class Settings : global::System.Configuration.ApplicationSettingsBase
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
