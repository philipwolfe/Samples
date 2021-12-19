VERSION 5.00
Object = "{3B7C8863-D78F-101B-B9B5-04021C009402}#1.2#0"; "richtx32.ocx"
Begin VB.Form MessageForm 
   Caption         =   "MessageForm"
   ClientHeight    =   6465
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   7245
   LinkTopic       =   "Form1"
   ScaleHeight     =   6465
   ScaleWidth      =   7245
   StartUpPosition =   3  'Windows Default
   Begin RichTextLib.RichTextBox RichTextBox1 
      Height          =   4455
      Left            =   120
      TabIndex        =   4
      Top             =   1920
      Width           =   6975
      _ExtentX        =   12303
      _ExtentY        =   7858
      _Version        =   393217
      Enabled         =   -1  'True
      TextRTF         =   $"MessageForm.frx":0000
   End
   Begin VB.Label labelSent 
      AutoSize        =   -1  'True
      Caption         =   "Sent:"
      Height          =   195
      Left            =   120
      TabIndex        =   5
      Top             =   1200
      Width           =   375
   End
   Begin VB.Label labelSubject 
      Appearance      =   0  'Flat
      BackColor       =   &H00C0FFFF&
      BorderStyle     =   1  'Fixed Single
      Caption         =   "Subject:"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      ForeColor       =   &H00800000&
      Height          =   225
      Left            =   120
      TabIndex        =   3
      Top             =   1560
      Width           =   6975
   End
   Begin VB.Label labelCC 
      AutoSize        =   -1  'True
      Caption         =   "Cc:"
      Height          =   195
      Left            =   120
      TabIndex        =   2
      Top             =   840
      Width           =   240
   End
   Begin VB.Label labelTo 
      AutoSize        =   -1  'True
      Caption         =   "To:"
      Height          =   195
      Left            =   120
      TabIndex        =   1
      Top             =   480
      Width           =   240
   End
   Begin VB.Label labelFrom 
      AutoSize        =   -1  'True
      Caption         =   "From:"
      Height          =   195
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   390
   End
End
Attribute VB_Name = "MessageForm"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
''===========================================================================
''  File:       MessageForm.frm
''
''  Summary:    The form that displays the contents of an e-mail message.
''
''---------------------------------------------------------------------------
''  Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
''===========================================================================
Private Sub Form_Resize()
    labelSubject.Width = Me.ScaleWidth - 240
    RichTextBox1.Width = Me.ScaleWidth - 240
    RichTextBox1.Height = Me.ScaleHeight - RichTextBox1.Top - 120
End Sub
