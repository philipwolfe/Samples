VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 2  'RequiresTransaction
END
Attribute VB_Name = "GetReceipt"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
' ==============================================================================
' Filename: Account.vbp
'
' Summary:  Visual Basic implememtation of the GetReceipt component for the bank sample
' Classes:  GetReceipt.cls
'
' This file is part of the Microsoft COM+ Samples
'
' Copyright (C) 1995-1999 Microsoft Corporation. All rights reserved
'
' This source code is intended only as a supplement to Microsoft
' Development Tools and/or on-line documentation.  See these other
' materials for detailed information reagrding Microsoft code samples.
'
' THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY
' KIND, EITHER EXPRESSED OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE
' IMPLIED WARRANTIES OF MERCHANTABILITY AND/OR FITNESS FOR A
' PARTICULAR PURPOSE.
'

Option Explicit

Implements IGetReceipt

Private Const ERROR_NUMBER = vbObjectError + 0
Private Const APP_ERROR = -2147467008

Public Function IGetReceipt_GetNextReceipt() As Long
' F+F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++F+++
'
' Function: GetNextReceipt
'
' This function uses Shared Properties to get the next receipt value
'
' Args:     None
' Returns:  Long -  next receipt value
'
' F-F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---F---
    
    On Error GoTo ErrorHandler
    
    Dim spmMgr As SharedPropertyGroupManager
    Set spmMgr = CreateObject("MTxSpm.SharedPropertyGroupManager.1")
        
    Dim spmGroup As SharedPropertyGroup
    Dim bResult As Boolean
    Set spmGroup = spmMgr.CreatePropertyGroup("Receipt", LockMethod, Process, bResult)

    Dim spmPropNextReceipt As SharedProperty
    Set spmPropNextReceipt = spmGroup.CreateProperty("Next", bResult)
    
    ' Set the initial value of the Shared Property to
    ' 0 if the Shared Property didn’t already exist.
    ' This is not entirely necessary but demonstrates how to initialize a value.
    If bResult = False Then
        spmPropNextReceipt.Value = 0
    End If

    Dim spmPropMaxNum As SharedProperty
    Set spmPropMaxNum = spmGroup.CreateProperty("MaxNum", bResult)
  
    Dim objReceiptUpdate As IUpdateReceipt
    If spmPropNextReceipt.Value >= spmPropMaxNum.Value Then
        Set objReceiptUpdate = CreateObject("VB6Bank.UpdateReceipt")
        spmPropNextReceipt.Value = objReceiptUpdate.Update
        spmPropMaxNum.Value = spmPropNextReceipt.Value + 100
    End If

    ' Get the next receipt number and update property
    spmPropNextReceipt.Value = spmPropNextReceipt.Value + 1

    GetObjectContext.SetComplete          ' we are finished and happy
    
    IGetReceipt_GetNextReceipt = spmPropNextReceipt.Value
    
    Exit Function
    
ErrorHandler:
    GetObjectContext.SetAbort             ' we are unhappy
    
    IGetReceipt_GetNextReceipt = -1            ' indicate that an error occured
    
    Err.Raise Err.Number, "VB6Bank.GetReceipt.GetNextReceipt", Err.Description
    
End Function

