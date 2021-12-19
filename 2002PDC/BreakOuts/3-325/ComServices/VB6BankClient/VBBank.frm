VERSION 5.00
Begin VB.Form Form1 
   AutoRedraw      =   -1  'True
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Bank Sample - Visual Basic"
   ClientHeight    =   4320
   ClientLeft      =   5040
   ClientTop       =   5325
   ClientWidth     =   8205
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   PaletteMode     =   1  'UseZOrder
   ScaleHeight     =   4320
   ScaleWidth      =   8205
   Begin VB.Frame Frame7 
      Caption         =   "Language"
      Height          =   735
      Left            =   5760
      TabIndex        =   32
      Top             =   2280
      Width           =   2415
      Begin VB.OptionButton VB6 
         Caption         =   "VB"
         Height          =   255
         Left            =   600
         TabIndex        =   35
         Top             =   360
         Width           =   255
      End
      Begin VB.OptionButton VB7 
         Caption         =   "Option2"
         Height          =   255
         Left            =   1320
         TabIndex        =   34
         Top             =   360
         Width           =   255
      End
      Begin VB.OptionButton CS 
         Caption         =   "Option3"
         Height          =   375
         Left            =   2040
         TabIndex        =   33
         Top             =   240
         Width           =   255
      End
      Begin VB.Label Label12 
         Alignment       =   2  'Center
         Caption         =   "VB6"
         Height          =   375
         Left            =   120
         TabIndex        =   38
         Top             =   240
         Width           =   495
      End
      Begin VB.Label Label11 
         Alignment       =   2  'Center
         Caption         =   "VB7"
         Height          =   375
         Left            =   840
         TabIndex        =   37
         Top             =   240
         Width           =   495
      End
      Begin VB.Label Label10 
         Alignment       =   2  'Center
         Caption         =   "C#"
         Height          =   375
         Left            =   1560
         TabIndex        =   36
         Top             =   240
         Width           =   495
      End
   End
   Begin VB.Frame Frame6 
      Caption         =   "Component"
      Height          =   975
      Left            =   5760
      TabIndex        =   27
      Top             =   1320
      Width           =   2415
      Begin VB.OptionButton StatefulMoveMoney 
         Caption         =   "Option2"
         Height          =   255
         Left            =   2040
         TabIndex        =   40
         Top             =   600
         Width           =   255
      End
      Begin VB.OptionButton MoveMoney 
         Caption         =   "Option2"
         Height          =   255
         Left            =   2040
         TabIndex        =   31
         Top             =   240
         Width           =   255
      End
      Begin VB.OptionButton Account 
         Caption         =   "VB"
         Height          =   255
         Left            =   840
         TabIndex        =   29
         Top             =   240
         Width           =   255
      End
      Begin VB.Label Label6 
         Alignment       =   2  'Center
         Caption         =   "Stateful MoveMoney"
         Height          =   255
         Index           =   1
         Left            =   480
         TabIndex        =   39
         Top             =   600
         Width           =   1575
      End
      Begin VB.Label Label6 
         Alignment       =   2  'Center
         Caption         =   "MoveMoney"
         Height          =   255
         Index           =   0
         Left            =   1080
         TabIndex        =   30
         Top             =   240
         Width           =   975
      End
      Begin VB.Label Label5 
         Alignment       =   2  'Center
         Caption         =   "Account"
         Height          =   255
         Left            =   120
         TabIndex        =   28
         Top             =   240
         Width           =   735
      End
   End
   Begin VB.Frame Frame5 
      Caption         =   "Response (sec)"
      Height          =   975
      Left            =   0
      TabIndex        =   17
      Top             =   2040
      Width           =   5655
      Begin VB.TextBox AvgResp 
         Enabled         =   0   'False
         Height          =   285
         Left            =   4680
         TabIndex        =   22
         Top             =   360
         Width           =   615
      End
      Begin VB.TextBox MaxResp 
         Enabled         =   0   'False
         Height          =   285
         Left            =   2880
         TabIndex        =   20
         Top             =   360
         Width           =   615
      End
      Begin VB.TextBox MinResp 
         Enabled         =   0   'False
         Height          =   285
         Left            =   960
         TabIndex        =   18
         Top             =   360
         Width           =   615
      End
      Begin VB.Label AvgRespCap 
         Caption         =   "Average"
         Height          =   255
         Left            =   3840
         TabIndex        =   23
         Top             =   360
         Width           =   735
      End
      Begin VB.Label Label4 
         Caption         =   "Maximum"
         Height          =   255
         Left            =   2160
         TabIndex        =   21
         Top             =   360
         Width           =   735
      End
      Begin VB.Label Label7 
         Caption         =   "Minimum"
         Height          =   255
         Left            =   240
         TabIndex        =   19
         Top             =   360
         Width           =   735
      End
   End
   Begin VB.Frame Frame3 
      Caption         =   "Result"
      Height          =   1095
      Left            =   0
      TabIndex        =   15
      Top             =   3120
      Width           =   8175
      Begin VB.TextBox Result 
         Height          =   735
         Left            =   120
         MultiLine       =   -1  'True
         TabIndex        =   16
         Top             =   240
         Width           =   7935
      End
   End
   Begin VB.Frame Frame2 
      Caption         =   "Iterations"
      Height          =   615
      Left            =   2760
      TabIndex        =   12
      Top             =   1320
      Width           =   2895
      Begin VB.CheckBox Step 
         Caption         =   "Check1"
         Height          =   255
         Left            =   2520
         TabIndex        =   41
         Top             =   240
         Width           =   255
      End
      Begin VB.TextBox nCurTrans 
         Enabled         =   0   'False
         Height          =   285
         Left            =   240
         TabIndex        =   26
         Text            =   "11111"
         Top             =   240
         Width           =   615
      End
      Begin VB.TextBox nTrans 
         Height          =   285
         Left            =   1200
         TabIndex        =   7
         Top             =   240
         Width           =   615
      End
      Begin VB.Label Label13 
         Caption         =   "&Step"
         Height          =   255
         Left            =   2040
         TabIndex        =   43
         Top             =   240
         Width           =   375
      End
      Begin VB.Label Label9 
         Caption         =   "Label9"
         Height          =   15
         Left            =   2040
         TabIndex        =   42
         Top             =   360
         Width           =   15
      End
      Begin VB.Label Label8 
         Caption         =   "&of"
         Height          =   255
         Left            =   960
         TabIndex        =   13
         Top             =   240
         Width           =   135
      End
   End
   Begin VB.CommandButton Close 
      Cancel          =   -1  'True
      Caption         =   "&Close"
      Height          =   375
      Left            =   5760
      TabIndex        =   9
      Top             =   720
      Width           =   2415
   End
   Begin VB.CommandButton Command1 
      Caption         =   "&Submit"
      Default         =   -1  'True
      Height          =   375
      Index           =   0
      Left            =   5760
      TabIndex        =   8
      Top             =   240
      Width           =   2415
   End
   Begin VB.Frame Frame4 
      Caption         =   "Transaction Type"
      Height          =   615
      Left            =   0
      TabIndex        =   3
      Top             =   1320
      Width           =   2655
      Begin VB.OptionButton Transfer 
         Caption         =   "Trans&fer"
         Height          =   315
         Left            =   1680
         TabIndex        =   6
         Top             =   240
         Width           =   915
      End
      Begin VB.OptionButton Credit 
         Caption         =   "&Credit"
         Height          =   315
         Left            =   240
         TabIndex        =   4
         Top             =   240
         Value           =   -1  'True
         Width           =   735
      End
      Begin VB.OptionButton Debit 
         Caption         =   "&Debit"
         Height          =   315
         Left            =   960
         TabIndex        =   5
         Top             =   240
         Width           =   735
      End
   End
   Begin VB.Frame Frame1 
      Caption         =   "Your Account Information"
      Height          =   1095
      Left            =   0
      TabIndex        =   0
      Top             =   120
      Width           =   5655
      Begin VB.TextBox PrimeAcct 
         Height          =   285
         Left            =   1860
         TabIndex        =   1
         Top             =   360
         Width           =   1215
      End
      Begin VB.TextBox SecondAcct 
         Enabled         =   0   'False
         Height          =   285
         Left            =   1860
         TabIndex        =   14
         Top             =   720
         Width           =   1215
      End
      Begin VB.TextBox Amount 
         Height          =   285
         Left            =   4200
         TabIndex        =   2
         Top             =   360
         Width           =   1215
      End
      Begin VB.Label promptSecondAcct 
         Alignment       =   1  'Right Justify
         Caption         =   "&Transfer to Account "
         Enabled         =   0   'False
         Height          =   315
         Left            =   240
         TabIndex        =   25
         Top             =   720
         Width           =   1515
      End
      Begin VB.Label Label1 
         Alignment       =   1  'Right Justify
         Caption         =   "&Account Number"
         Height          =   315
         Left            =   240
         TabIndex        =   24
         Top             =   360
         Width           =   1515
      End
      Begin VB.Label Label3 
         Caption         =   "Label3"
         Height          =   15
         Left            =   300
         TabIndex        =   11
         Top             =   2100
         Width           =   615
      End
      Begin VB.Label Label2 
         Alignment       =   1  'Right Justify
         Caption         =   "A&mount"
         Height          =   315
         Left            =   3240
         TabIndex        =   10
         Top             =   360
         Width           =   915
      End
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
' ==============================================================================
' Filename: Account.vbp
'
' Summary:  Visual Basic implememtation of the account class for the VBBank sample
' Classes:  Account.cls
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
Private Const APP_ERROR = -2147467008

' Timer Variables
Private Declare Function GetTickCount Lib "kernel32" () As Long
Private Declare Sub Sleep Lib "kernel32" (ByVal dwMilliseconds As Long)
Private StartTime As Long
Private Elapsed As Long
Private AvgResponseTime As Long
Private minRespTime As Long
Private maxRespTime As Long
Private lRet As Long
Private Res As Variant
Private ProgID As String


Private Sub Account_Click()
    VB7.Enabled = True
    CS.Enabled = True
    Transfer.Enabled = False
End Sub

Private Sub Close_Click()
    End
End Sub

Private Sub Command1_Click(Index As Integer)
    Dim lSecondAcct As Long
    Dim TranType As String
    
    Screen.MousePointer = 11
    On Error GoTo ErrorHandler
    
    ' Decide which component to use
    Dim cd  As String
    If Account = True Then
        ProgID = "Bank.Account"
    Else
        ProgID = "Bank.MoveMoney"
    End If
    
    ' Decide which language to use
    If VB7 = True Then
        ProgID = "VB7" + ProgID
    ElseIf CS = True Then
        ProgID = "CSharp" + ProgID
        
    Else ' VB is the default
        ProgID = "VB6" + ProgID
    End If
    
    ' Decide transaction type
    Result = ""
    lSecondAcct = 0
    Dim Mult As Long
    If Debit = True Then
        TranType = 1
        Mult = -1
    ElseIf Credit = True Then
        TranType = 2
        Mult = 1
    Else
        If ProgID = "VB6Bank.Account" Then
            MsgBox "Error. Use MoveMoney component to transfer."
            MoveMoney.SetFocus
            Screen.MousePointer = 0
            Exit Sub
        End If
        If SecondAcct = "" Then
            MsgBox "Error. Transfer to Account must be filled in."
            SecondAcct.SetFocus
            Screen.MousePointer = 0
            Exit Sub
        Else
            TranType = 3
            lSecondAcct = CLng(SecondAcct)
        End If
    End If
   
    ' Create the appropriate MoveMoney object
    On Error GoTo objError
    Dim obj As Object
    Set obj = CreateObject(ProgID)
    On Error GoTo ErrorHandler
    
    If obj Is Nothing Then
        Screen.MousePointer = 0
        MsgBox "Create object " + ProgID + "failed."
        Exit Sub
    End If
    
    InitTimer
    
    ' Call the object
    Dim i As Long
    For i = 1 To nTrans
        StartTimer
        Res = ""
        If Account = True Then
            Dim a As IAccount
            Set a = obj
            Res = a.Post(CLng(PrimeAcct), CLng(Amount * Mult))
        ElseIf MoveMoney = True Then
            Dim m As IMoveMoney
            Set m = obj
            Res = m.Perform(CLng(PrimeAcct), lSecondAcct, CLng(Amount), TranType)
        Else
            m.PrimeAccount = PrimeAcct
            m.SecondAccount = lSecondAcct
            Res = m.StatefulPerform(CLng(Amount), TranType)
        End If
        EndTimer
        nCurTrans = i
        Result = Res
        If lRet <> 0 Then
            Exit For
        End If
        If Step = 1 And i <> nTrans Then
            MsgBox "Step mode, OK to continue"
        End If
    Next i
    
    FinishTimer
    
    Set obj = Nothing
  
    Result = Res
    Screen.MousePointer = 0
    Exit Sub
    
objError:
    MsgBox "Error " & Err.Number & ": Make sure the Sample Bank package has been correctly installed in COM+."
    Screen.MousePointer = 0
    Err.Clear
    Exit Sub
    
ErrorHandler:
    Screen.MousePointer = 0
    MsgBox Err.Number & "(" & Err.Source & ") :" & Err.Description
    Err.Clear

End Sub

Private Sub Credit_Click()
    SecondAcct.Enabled = False
    promptSecondAcct.Enabled = False
    SecondAcct = ""
    Account.Enabled = True
End Sub
Private Sub Debit_Click()
    SecondAcct.Enabled = False
    promptSecondAcct.Enabled = False
    SecondAcct = ""
    Account.Enabled = True
End Sub
Private Sub Form_Load()
    PrimeAcct = 1
    SecondAcct = ""
    Amount = 1
    Result = ""
    Debit = 0
    Credit = 1
    Transfer = 0
    MoveMoney = 1
    VB7 = 1
    nCurTrans = 0
    nTrans = 1
    Step = 0
    MinResp = 0
    MaxResp = 0
    AvgResp = 0
End Sub

Private Sub MoveMoney_Click()
    VB7.Enabled = True
    CS.Enabled = True
    Transfer.Enabled = True
End Sub

Private Sub transfer_Click()
    SecondAcct.Enabled = True
    promptSecondAcct.Enabled = True
    Account.Enabled = False
End Sub

Public Sub StartTimer()
    StartTime = GetTickCount()
End Sub

Public Sub EndTimer()
    Elapsed = GetTickCount - StartTime
    If Elapsed < minRespTime Then minRespTime = Elapsed
    If Elapsed > maxRespTime Then maxRespTime = Elapsed
    AvgResponseTime = AvgResponseTime + Elapsed
End Sub

Public Sub FinishTimer()
    AvgResponseTime = AvgResponseTime / nTrans
    AvgResp = Format(AvgResponseTime / 1000, "#0.###")
    MinResp = Format(minRespTime / 1000, "#0.###")
    MaxResp = Format(maxRespTime / 1000, "#0.###")
    Form1.Refresh
End Sub
Public Sub InitTimer()
    minRespTime = 99999999
    maxRespTime = 0
    AvgResponseTime = 0
End Sub

Private Sub VB7_Click()
    StatefulMoveMoney.Enabled = False
End Sub

Private Sub CS_Click()
    StatefulMoveMoney.Enabled = False
End Sub

Private Sub VB_Click()
    StatefulMoveMoney.Enabled = True
End Sub
Private Sub StatefulMoveMoney_Click()
    VB7.Enabled = False
    CS.Enabled = False
    Transfer.Enabled = True
End Sub

