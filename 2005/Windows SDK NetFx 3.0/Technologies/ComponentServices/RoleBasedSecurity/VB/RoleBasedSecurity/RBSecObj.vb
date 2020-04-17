'=====================================================================
'  File:      RBSecObj.vb
'
'  Summary:   Server Code for COM+ Role-Based Security Sample
'
'---------------------------------------------------------------------
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
'=====================================================================

Imports System
Imports System.Reflection
Imports System.Windows.Forms
Imports System.EnterpriseServices
Imports System.Runtime.InteropServices

' The ApplicationName attribute specifies the name of the
' COM+ Application that will hold assembly components
<Assembly: ApplicationName("RBSecDemoSvr")>

' the ApplicationActivation.ActivationOption attribute specifies 
' where assembly components are loaded on activation
' Library : components run in the creator's process
' Server : components run in a system process, dllhost.exe
<Assembly: ApplicationActivation(ActivationOption.Server)>

' ApplicationAccessControl is a COM+ security attribute that
' enables and configures application-level COM+ security
' The attribute maps to the Securities tab in a COM+
' application properties page
<Assembly: ApplicationAccessControl()>


Namespace Microsoft.Samples.Technologies.ComponentServices.RoleBasedSecurity

    ' ComponentAccessControl enables security checking
    ' at the component level. The attribute maps to the 
    ' securities tab in a component within a COM+ application
    <ComponentAccessControl(), SecurityRole("RBSecurityDemoRole", SetEveryoneAccess:=True), _
    ComVisible(True), _
    CLSCompliant(False)> _
    Public Class RBSecurityObject

        ' SecurityRole configures a role named RbSecurityDemoRole
        ' on our component. SetEveryoneAccess(true) indicates we
        ' we want the role to be populated with 'Everyone' when created

        Inherits ServicedComponent

        Public Function IsCallerInDemoRole() As Boolean
            ' A real world apps would most likely have a call
            ' to ContextUtil.IsSecurityEnabled before any call
            ' to IsCallerInRole because IsCallerInRole returns
            ' true in all cases when security is disabled
            Return ContextUtil.IsCallerInRole("RBSecurityDemoRole")
        End Function 'IsCallerInDemoRole


        Public Function WhoIsCaller() As String
            Dim retVal As String = "Unknown caller (Security is not enabled)"

            If ContextUtil.IsSecurityEnabled Then
                Dim sc As SecurityCallContext

                ' CurrentCall is a static property which
                ' contains information about the current caller 
                sc = SecurityCallContext.CurrentCall

                ' retrieve the current caller account name
                retVal = sc.DirectCaller.AccountName
            End If

            Return retVal
        End Function 'WhoIsCaller
    End Class 'RBSecurityObject
End Namespace 'Microsoft.Samples.Technologies.ComponentServices.RoleBasedSecurity







