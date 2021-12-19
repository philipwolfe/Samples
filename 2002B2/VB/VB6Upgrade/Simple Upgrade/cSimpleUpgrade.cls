VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "cSimpleUpgrade"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

'***************************************************************
'***  All Variants are upgraded to the new Object Type.

Dim GlobalVariant As Variant
Dim mMyProperty As Integer

'***************************************************************

Private Sub IntegerUpgrade()

'***************************************************************
'*** VB6 16-bit whole number is now Short instead of Integer
'*** Integer in VB.Net is now a 32-bit whole number
'*** Long in VB.Net is now a 64-bit number

    Dim My16bit As Integer
    Dim My32bit As Long
    
    '*** Will be converted to:
    
    'Dim My16bit as Short
    'Dim My32bit as Integer

End Sub

'****************************************************************
'*** The syntax of properties has changed.
'*** The following code:
Public Property Get MyProperty() As Integer
    MyProperty = mMyProperty
End Property

Public Property Let MyProperty(ByVal mValue As Integer)
    mMyProperty = mValue
End Property
'*** Will be upgraded to:
'Property MyProperty() as Short
'    Get
'        MyProperty = mMyProperty
'    End Get
'    Set
'        mMyProperty = Value
'    End Set
'End Property
'*****************************************************************

