/*=====================================================================
  File:      RBSecObj.cs

  Summary:   Server Code for COM+ Role-Based Security Sample

---------------------------------------------------------------------
  This file is part of the Microsoft .NET Framework SDK Code Samples.

  Copyright (C) Microsoft Corporation.  All rights reserved.

This source code is intended only as a supplement to Microsoft
Development Tools and/or on-line documentation.  See these other
materials for detailed information regarding Microsoft code samples.

THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
PARTICULAR PURPOSE.
=====================================================================*/

using System;
using System.Reflection;
using System.Windows.Forms;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

// the ApplicationName attribute specifies the name of the
// COM+ Application that will hold assembly components
[assembly: ApplicationName("RBSecDemoSvr")]

// the ApplicationActivation.ActivationOption attribute specifies 
// where assembly components are loaded on activation
// Library : components run in the creator's process
// Server : components run in a system process, dllhost.exe
[assembly: ApplicationActivation(ActivationOption.Server)]

// ApplicationAccessControl is a COM+ security attribute that
// enables and configures application-level COM+ security
// The attribute maps to the Securities tab in a COM+
// application properties page
[assembly: ApplicationAccessControl]


namespace Microsoft.Samples.Technologies.ComponentServices.RoleBasedSecurity
{
    // ComponentAccessControl enables security checking
    // at the component level. The attribute maps to the 
    // securities tab in a component within a COM+ application
    [ComponentAccessControl]
    
    // SecurityRole configures a role named RbSecurityDemoRole
    // on our component. SetEveryoneAccess(true) indicates we
    // we want the role to be populated with 'Everyone' when created
    [SecurityRole("RBSecurityDemoRole", SetEveryoneAccess = true)]
    [ComVisible(true)]
    [CLSCompliant(false)]
    public class RBSecurityObject : ServicedComponent
    {
        public bool IsCallerInDemoRole()
        {
            // A real world apps would most likely have a call
            // to ContextUtil.IsSecurityEnabled before any call
            // to IsCallerInRole because IsCallerInRole returns
            // true in all cases when security is disabled
      
            return ContextUtil.IsCallerInRole("RBSecurityDemoRole");

        }

        public string WhoIsCaller() 
        {
            string retVal = "Unknown caller (Security is not enabled)";
              
            if (ContextUtil.IsSecurityEnabled) 
            {
                SecurityCallContext sc;

                // CurrentCall is a static property which
                // contains information about the current caller 
                sc = SecurityCallContext.CurrentCall;

               // retrieve the current caller account name
               retVal = sc.DirectCaller.AccountName;
            }

            return retVal;
         }
    }
}
