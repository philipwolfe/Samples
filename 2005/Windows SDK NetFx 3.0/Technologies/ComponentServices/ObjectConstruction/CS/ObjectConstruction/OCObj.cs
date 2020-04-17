//-----------------------------------------------------------------------
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
//-----------------------------------------------------------------------
/*
  File:      OCObj.cs

  Summary:   Simple Class for .NET Object Construction Sample

*/
//-----------------------------------------------------------------------

using System;
using System.Reflection;
using System.Windows.Forms;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

// the ApplicationName attribute specifies the name of the
// COM+ Application which will hold assembly components
[assembly : ApplicationName("OCDemoSvr")]

// the ApplicationActivation.ActivationOption attribute specifies 
// where assembly components are loaded on activation
// Library : components run in the creator's process
// Server : components run in a system process, dllhost.exe
[assembly: ApplicationActivation(ActivationOption.Library)]

namespace Microsoft.Samples.Technologies.ComponentServices.ObjectConstruction
{
    // Default value for the Construction string specified here
    [ConstructionEnabled(Default="Default Construction String")]
    [ComVisible(true)]
    [CLSCompliant(false)]
    public class ObjectConstructionTest : ServicedComponent
    {
       public ObjectConstructionTest()
       {
          // Constructor called first on instance creation
          MessageBox.Show("Constructor called", "Object Construction Sample");
       }

       protected override void Construct(string constructString)
       {
          // Construct method called next, after constructor
          MessageBox.Show("IObjectConstruct method called with value \"" + constructString + "\"", "Object Construction Sample");
       }

       public void DoWork ()
       {
          MessageBox.Show("DoWork method called", "Object Construction Sample");
       } 
    }
}
