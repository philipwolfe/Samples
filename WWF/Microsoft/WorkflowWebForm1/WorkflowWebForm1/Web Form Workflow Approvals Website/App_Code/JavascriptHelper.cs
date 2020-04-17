//--------------------------------------------------------------------------------
// This file is a "Sample" as from Windows Workflow Foundation
// Samples
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

using System;
using System.Collections.Generic;
using System.Text;
using System.Web.UI;

public class JavascriptHelper
{
	private const string ScriptFormat = "<script type='text/javascript' language='javascript'>{0}</script>";

	public static string Custom(string script, string key)
	{
		return Custom(null, script, key);
	}

	public static string Custom(Page page, string script, string key)
	{
		string js = string.Format(ScriptFormat, script);

		Register(page, js, key);

		return js;
	}

	public static string Alert(string message, string key)
	{
		return Alert(null, message, key);
	}

	public static string Alert(Page page, string message, string key)
	{
		return Custom(page, string.Format("alert('{0}');", message), key);
	}

	private static void Register(Page page, string javascript, string key)
	{
		if (page != null)
		{
			if (!page.ClientScript.IsClientScriptBlockRegistered(key))
			{
				page.ClientScript.RegisterClientScriptBlock(page.GetType(), key, javascript);
			}
		}
	}
}

