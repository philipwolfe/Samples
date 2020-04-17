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

#region Using directives

using System;
using System.Collections.Generic;
using System.Text;

using System.Drawing;

#endregion

namespace Microsoft.Samples.Windows.Forms.BindingSourceSample
{
    public class Flag
    {
        private string      flagName;
        private Image       flagImage;

        public Flag(string name, Image image)
        {
            this.flagName = name;
            this.flagImage = image;
        }

        public string Name
        {
            get { return this.flagName; }
        }

        public Image Image
        {
            get { return this.flagImage; }
        }
    } 
}
