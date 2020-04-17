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
/*=====================================================================
  File:      QCObj.cs

  Summary:   Demonstrates how Queued components is used in .NET

=====================================================================*/

using System;
using System.Windows.Forms;
using System.Reflection;
using System.EnterpriseServices;
using System.Runtime.InteropServices;

// the ApplicationName attribute specifies the name of the
// COM+ Application which will hold assembly components
[assembly: ApplicationName("QCDemoSvr")]

// the ApplicationActivation.ActivationOption attribute specifies 
// where assembly components are loaded on activation
// Library : components run in the creator's process
// Server : components run in a system process, dllhost.exe
[assembly: ApplicationActivation(ActivationOption.Server)]

// ApplicationQueuing enables queuing support for the COM+ component.
// On building, a public queue will be created whose name
// is the same as the COM+ application name specified above (qcdemosvr).
// QueueListenerEnabled indicates whether the queued components listener
// is enabled for the application. Since we specifiy true, the listener
// will be launched on application startup and look for messages
// in our public queue to be played back to the component
[assembly: ApplicationQueuing(Enabled=true, QueueListenerEnabled=true)]

// IMPORTANT: for the sake of simplicity, this sample only requires an MSMQ
// workgroup installation and is not set up to work with a domain controller.
// In MSMQ workgroup mode, the active directory certificate store necessary to 
// support message authentication is not available. So, we must disable call
// authentication in our COM+ application in order to avoid an 'Access Denied' 
// exception on creating the queued component. A real-world queued component 
// requiring message authentication would not run in workgroup mode and would 
// not set this attribute. See KnowledgeBase article Q247394 for more information. 
[assembly: ApplicationAccessControl(Value=false, Authentication=AuthenticationOption.None)]


namespace Microsoft.Samples.Technologies.ComponentServices.QueuedComponents
{
    // InterfaceQueuing enables queuing support for the IQComponent
    // interface. Calls on the interface will be queued using MSMQ
    [ComVisible(true)]
    [InterfaceQueuing]
    public interface IQComponent 
    {
        void DisplayMessage(string msg);
    }


    // Our queued component class. Disconnected clients will use a 
    // queue moniker to instantiate the class (see QCForm.cs). Method calls
    // will packaged and placed in the queue. When the COM+ application
    // holding this component is activated, manually or programmatically,
    // the MSMQ listener will automatically retrieve any messages in our
    // queue and pass them to the server code below. For this sample,
    // the result is a series of message boxes corresponding to 
    // individual object calls made from the client application.
    [ComVisible(true)]
    [CLSCompliant(false)]
    public class QComponent : ServicedComponent, IQComponent
    {
        public void DisplayMessage(string msg)
        {
            MessageBox.Show(msg, "Component Processing Message");
        }
    }
}
