VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsProxy"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

Implements clsAbstract

Dim m_CustomerName As String

Public Property Let clsAbstract_CustomerName(RHS As String)
m_CustomerName = RHS
End Property

Public Property Get clsAbstract_CustomerName() As String
Attribute clsAbstract_CustomerName.VB_UserMemId = 0
clsAbstract_CustomerName = m_CustomerName
End Property
