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

public struct Result
{
	public bool IsSuccessful;
	public string Message;

	public Result(string successMessage)
		: this(true, successMessage)
	{

	}

	public Result(bool isSuccessful)
		: this(isSuccessful, string.Empty)
	{

	}

	public Result(bool isSuccessful, string message)
	{
		this.IsSuccessful = isSuccessful;
		this.Message = message;
	}
}
