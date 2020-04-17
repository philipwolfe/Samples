//---------------------------------------------------------------------
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
//---------------------------------------------------------------------

using System;
using System.Windows.Forms.Design;

namespace Microsoft.Samples
{
	/// <summary>
	/// Summary description for IPv5MaskDescriptor.
	/// </summary>
	public class IPv5MaskDescriptor : MaskDescriptor
	{
		public override string Mask
		{
			get { return "099.099.099.099"; }
		}

		public override string Name
		{
			get { return "IPv5 IP address"; }
		}

		public override string Sample
		{
			get { return "128.128.1.0"; }
		}

		public override Type ValidatingType
		{
			get { return typeof(IPv5); }
		}

	}
}
