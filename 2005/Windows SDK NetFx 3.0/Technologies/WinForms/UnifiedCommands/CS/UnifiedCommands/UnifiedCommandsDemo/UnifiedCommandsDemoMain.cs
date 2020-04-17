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
using System.Resources;
using System.Windows.Forms;

namespace Microsoft.Samples.Windows.Forms.UnifiedCommandsDemo
{
    //=----------------------------------------------------------------------=
    // UnifiedCommandsDemoMain
    //=----------------------------------------------------------------------=
    /// This class holds global routines for our sample, and doesn't actualy
    /// contain any instance members.  The static routines are useful for such
    /// things as getting localized reosurces, etc.
    internal static class UnifiedCommandsDemoMain
    {
		/// The resource manager with which we will work for this dialog, 
        /// particularly for loading in error strings, etc.
        private static ResourceManager s_resourceManager;

        private const string RESFILE_NAMESPACE = "Microsoft.Samples.Windows.Forms.UnifiedCommandsDemo.UnifiedCommandsDemoResources";

        //=------------------------------------------------------------------=
        // GetResourceManager
        //=------------------------------------------------------------------=
        /// Loads in the resource manager for this library if we haven't done
        /// so already.  This just loads in the .resx file containing our 
        /// primary set of localized resources, such as error strings, etc.
        public static ResourceManager GetResourceManager()
        {
            System.Type t;

            // load in the resource manager if we have not yet done so.
            if (s_resourceManager == null)
            {
                t = typeof(Microsoft.Samples.Windows.Forms.UnifiedCommandsDemo.Form1);
                s_resourceManager = new ResourceManager(RESFILE_NAMESPACE, t.Assembly);
            }

			if (s_resourceManager == null)
			{
				throw (new ArgumentNullException());
			}
                        
			return s_resourceManager;
        }

    }
}
