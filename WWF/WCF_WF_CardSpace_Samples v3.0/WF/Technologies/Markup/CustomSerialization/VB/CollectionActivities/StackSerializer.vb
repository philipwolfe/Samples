'---------------------------------------------------------------------
'  This file is part of the Windows Workflow Foundation SDK Code Samples.
' 
'  Copyright (C) Microsoft Corporation.  All rights reserved.
' 
'This source code is intended only as a supplement to Microsoft
'Development Tools and/or on-line documentation.  See these other
'materials for detailed information regarding Microsoft code samples.
' 
'THIS CODE AND INFORMATION ARE PROVIDED AS IS WITHOUT WARRANTY OF ANY
'KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
'IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
'PARTICULAR PURPOSE.
'---------------------------------------------------------------------


Imports System
Imports System.Collections
Imports System.ComponentModel.Design.Serialization
Imports System.Workflow.ComponentModel.Serialization
Imports System.Runtime.InteropServices

<ComVisible(False)> _
Public Class StackSerializer
    Inherits WorkflowMarkupSerializer
    Implements IDesignerSerializationProvider

    Protected Overrides Sub AddChild(ByVal serializationManager As WorkflowMarkupSerializationManager, ByVal parentObject As Object, ByVal childObject As Object)

        If parentObject Is Nothing Then
            Throw New ArgumentNullException("parentObject")
        End If

        If (childObject Is Nothing) Then
            Throw New ArgumentNullException("childObject")
        End If

        Dim stack As Stack = TryCast(parentObject, Stack)

        If stack Is Nothing Then
            Throw New Exception(String.Format("The type of parentObject is not {0}", GetType(Stack).FullName))
        End If

        stack.Push(childObject)
    End Sub

    Protected Overrides Function GetChildren(ByVal serializationManager As WorkflowMarkupSerializationManager, ByVal obj As Object) As IList

        If obj Is Nothing Then
            Throw New ArgumentNullException("obj")
        End If

        Dim stack As Stack = TryCast(obj, Stack)

        If stack Is Nothing Then
            Throw New Exception(String.Format("The type of obj is not {0}", GetType(Stack).FullName))
        End If

        Dim arrayList As New ArrayList(stack.ToArray())
        arrayList.Reverse()

        Return arrayList
    End Function

#Region "IDesignerSerializationProvider Members"
    Public Function GetSerializer(ByVal manager As System.ComponentModel.Design.Serialization.IDesignerSerializationManager, ByVal currentSerializer As Object, ByVal objectType As System.Type, ByVal serializerType As System.Type) As Object Implements System.ComponentModel.Design.Serialization.IDesignerSerializationProvider.GetSerializer
        If objectType Is GetType(Stack) Then
            Return Me
        Else
            Return currentSerializer
        End If
    End Function
#End Region

End Class
