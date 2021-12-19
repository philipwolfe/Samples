VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "clsCustomer"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = False
Option Explicit

    Dim cProxy As New clsProxy
    Dim m_ID As Integer
 
      Property Get CustomerName() As String
Attribute CustomerName.VB_UserMemId = 0
        CustomerName = cProxy
      End Property
      Property Let CustomerName(sNewValue As String)
        cProxy = sNewValue
      End Property
 
    Function GetIDFromTextBox(txt As TextBox)
      m_ID = txt
    End Function



