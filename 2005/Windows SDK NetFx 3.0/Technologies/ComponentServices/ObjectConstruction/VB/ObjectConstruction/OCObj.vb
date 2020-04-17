'  This file is part of the Microsoft .NET Framework SDK Code Samples.
'
'  Copyright (C) Microsoft Corporation.  All rights reserved.
'
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
'
'THIS CODE AND INFORMATION ARE PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'
'---------------------------------------------------------------------
'  File:      OCObj.vb
'
'  Summary:   Simple Class for .NET Object Construction Sample
'
'---------------------------------------------------------------------

Imports System
Imports System.Reflection
Imports System.Windows.Forms
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices

' the ApplicationName attribute specifies the name of the
' COM+ Application which will hold assembly components
<Assembly: ApplicationName("OCDemoSvr")>

' the ApplicationActivation.ActivationOption attribute specifies 
' where assembly components are loaded on activation
' Library : components run in the creator's process
' Server : components run in a system process, dllhost.exe
<Assembly: ApplicationActivation(ActivationOption.Library)>

Namespace Microsoft.Samples.Technologies.ComponentServices.ObjectConstruction

    ' Default value for the Construction string specified here
    ' ES Components are not CLS Compliant
    ' This class should be exposed to COM+
    <ConstructionEnabled([Default]:="Default Construction String"), _
    CLSCompliant(False), _
    ComVisible(True)> _
    Public Class ObjectConstructionTest
        Inherits ServicedComponent

        Public Sub New()
            ' Constructor called first on instance creation
            MessageBox.Show("Constructor called", "Object Construction Sample")
        End Sub 'New


        Protected Overrides Sub Construct(ByVal constructString As String)
            ' Construct method called next, after constructor
            MessageBox.Show("IObjectConstruct method called with value """ & constructString & """", "Object Construction Sample")
        End Sub 'Construct


        Public Sub DoWork()
            MessageBox.Show("DoWork method called", "Object Construction Sample")
        End Sub 'DoWork
    End Class 'ObjectConstructionTest
End Namespace 'OCDemoServerVB
