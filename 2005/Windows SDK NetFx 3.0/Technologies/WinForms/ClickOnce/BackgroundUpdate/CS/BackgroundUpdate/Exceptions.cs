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

namespace Microsoft.Samples.Windows.Forms.ClickOnce.BackgroundUpdate
{
    public class TimeTravelNotInventedYetException : Exception
    {
        public TimeTravelNotInventedYetException() : base(BackgroundUpdateMain.GetResourceManager().GetString("excNoTimeTravel"))
        {
        }
    }

    public class NotNetworkDeployedException : Exception
    {
        public NotNetworkDeployedException() : base(BackgroundUpdateMain.GetResourceManager().GetString("excNotNetworkDeployed"))
        {
        }
    }
}
