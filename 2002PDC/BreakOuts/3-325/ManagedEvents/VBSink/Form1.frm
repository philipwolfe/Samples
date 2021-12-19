VERSION 5.00
Begin VB.Form Form1 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Event Demo"
   ClientHeight    =   2730
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   4680
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2730
   ScaleWidth      =   4680
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton Mute 
      Caption         =   "Mute"
      Height          =   495
      Left            =   1680
      TabIndex        =   3
      Top             =   1920
      Width           =   1335
   End
   Begin VB.Timer Timer1 
      Interval        =   1000
      Left            =   2160
      Top             =   1440
   End
   Begin VB.CommandButton ResizeB 
      Caption         =   "Stop"
      Height          =   495
      Left            =   3240
      TabIndex        =   1
      Top             =   1920
      Width           =   1215
   End
   Begin VB.CommandButton Command1 
      Caption         =   "Start"
      Height          =   495
      Left            =   240
      TabIndex        =   0
      Top             =   1920
      Width           =   1215
   End
   Begin VB.Label Panel 
      Alignment       =   2  'Center
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   36
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   855
      Left            =   480
      TabIndex        =   2
      Top             =   480
      Width           =   3735
   End
End
Attribute VB_Name = "Form1"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit
Dim myCls As New Class1
Public nMute As Integer

Private Sub Command1_Click()
    myCls.myButton.CauseClickEvent 10, 10
End Sub

Private Sub Form_Load()
    Set myCls = New Class1
    nMute = 0
End Sub


Private Sub Mute_Click()
    If Mute.Caption = "Mute" Then
        nMute = 100
        Mute.Caption = "Sound"
    Else
        nMute = 0
        Mute.Caption = "Mute"
    End If
End Sub

Private Sub ResizeB_Click()
    myCls.myButton.CauseResizeEvent
End Sub

Private Sub Timer1_Timer()
    myCls.myButton.CausePulse
End Sub
