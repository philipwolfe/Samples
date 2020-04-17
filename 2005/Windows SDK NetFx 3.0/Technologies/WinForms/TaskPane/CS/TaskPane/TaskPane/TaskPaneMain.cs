//=====================================================================
//  File:      TaskPaneMain.cs
//
//  Summary:   Contains global methods and things to help us manage all
//             the controls at runtime, most notably localisation of
//             resources, etc...
//
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

using System.Resources;




namespace Microsoft.Samples.Windows.Forms.TaskPane
{
    //=----------------------------------------------------------------------=
    // TaskPaneMain
    //=----------------------------------------------------------------------=
    /// <summary>
    ///   A Module with methods and the like which we will use to manage
    ///   globalisation and other aspects of using the controls at runtime.
    /// </summary>
    internal class TaskPaneMain
    {
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                       Private data/types/etc
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        ///
        /// <summary>
        ///   Resource Manager for getting strings.
        /// </summary>
        /// 
        private static ResourceManager s_resourceManager;

 


        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //                            Public Methods
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=
        //=------------------------------------------------------------------=

        //=------------------------------------------------------------------=
        // GetResourceManager
        //=------------------------------------------------------------------=
        /// <summary>
        ///   Returns our resource manager, loading it the first time it is
        ///   required.
        /// </summary>
        /// 
        /// <returns>
        ///   The resource manager to use at runtime.
        /// </returns>
        /// 
        public static ResourceManager GetResourceManager()
        {
            //
            // Load in the manager if necessary.
            //
            if (s_resourceManager == null)
            {
                s_resourceManager = new System.Resources.ResourceManager(
                    "Microsoft.Samples.Windows.Forms.TaskPane.TaskPaneResources",
                    typeof(Microsoft.Samples.Windows.Forms.TaskPane.TaskPane).Assembly);
            }

            return s_resourceManager;
        }

    }

}

