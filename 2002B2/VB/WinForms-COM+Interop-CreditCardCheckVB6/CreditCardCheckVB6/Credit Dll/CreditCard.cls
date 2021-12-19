VERSION 1.0 CLASS
BEGIN
  MultiUse = -1  'True
  Persistable = 0  'NotPersistable
  DataBindingBehavior = 0  'vbNone
  DataSourceBehavior  = 0  'vbNone
  MTSTransactionMode  = 0  'NotAnMTSObject
END
Attribute VB_Name = "CreditCard"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Public Function CheckCreditCard(strCCNumber As String) As String
    Dim strReversed As String
    Dim strCh As String
    Dim intNumber As Integer
    Dim strNumberFinal As String
    Dim intSum As Integer
    Dim i As Integer
    Dim strReturn As String
    
    strReversed = StrReverse(strCCNumber)
    
    For i = 1 To Len(strReversed)
        strCh = Mid(strReversed, i, 1)
        intNumber = CInt(strCh)
        If i Mod 2 = 0 Then
            intNumber = intNumber * 2
            If intNumber > 9 Then
                intNumber = intNumber - 9
            End If
        End If
        strNumberFinal = strNumberFinal & intNumber
    Next i
    
    For i = 1 To Len(strNumberFinal)
        intSum = intSum + Mid(strNumberFinal, i, 1)
    Next i
    
    If intSum Mod 10 = 0 Then
        strReturn = "Valid "
    Else
        strReturn = "Invalid "
    End If
    
    Select Case Left(strCCNumber, 1)
        Case 3
            strReturn = strReturn & "AMEX"
        Case 4
            strReturn = strReturn & "Visa"
        Case 5
            strReturn = strReturn & "Master Card"
        Case 6
            strReturn = strReturn & "Discovery Card"
        Case Else
            strReturn = strReturn & "Unknown"
    End Select
    
    CheckCreditCard = strReturn
        
End Function


