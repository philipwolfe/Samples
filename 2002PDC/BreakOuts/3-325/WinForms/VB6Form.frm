VERSION 5.00
Begin VB.Form VB6Form 
   BorderStyle     =   3  'Fixed Dialog
   Caption         =   "VB6 Form"
   ClientHeight    =   5505
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   7320
   LinkTopic       =   "Form1"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5505
   ScaleWidth      =   7320
   ShowInTaskbar   =   0   'False
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame Frame1 
      Caption         =   "Modify Button"
      ForeColor       =   &H00C00000&
      Height          =   4815
      Index           =   1
      Left            =   3720
      TabIndex        =   37
      Top             =   600
      Visible         =   0   'False
      Width           =   3495
      Begin VB.TextBox Text1 
         Height          =   375
         Index           =   10
         Left            =   120
         TabIndex        =   26
         Text            =   "Button"
         Top             =   600
         Width           =   2295
      End
      Begin VB.CommandButton UpdateButton 
         Caption         =   "UPDATE"
         Height          =   375
         Index           =   6
         Left            =   2520
         TabIndex        =   27
         Top             =   600
         Width           =   855
      End
      Begin VB.OptionButton Option1 
         Caption         =   "Flat"
         Height          =   255
         Index           =   7
         Left            =   120
         TabIndex        =   28
         Top             =   1440
         Width           =   2535
      End
      Begin VB.OptionButton Option1 
         Caption         =   "Popup"
         Height          =   255
         Index           =   8
         Left            =   120
         TabIndex        =   29
         Top             =   1680
         Width           =   2535
      End
      Begin VB.OptionButton Option1 
         Caption         =   "Standard"
         Height          =   255
         Index           =   9
         Left            =   120
         TabIndex        =   30
         Top             =   1920
         Value           =   -1  'True
         Width           =   2535
      End
      Begin VB.TextBox Text1 
         Height          =   375
         Index           =   9
         Left            =   1800
         TabIndex        =   31
         Text            =   "10"
         Top             =   4320
         Width           =   615
      End
      Begin VB.CommandButton UpdateButton 
         Caption         =   "UPDATE"
         Height          =   375
         Index           =   5
         Left            =   2520
         TabIndex        =   32
         Top             =   4320
         Width           =   855
      End
      Begin VB.TextBox Text1 
         Height          =   375
         Index           =   8
         Left            =   1080
         TabIndex        =   33
         Text            =   "10"
         Top             =   4320
         Width           =   615
      End
      Begin VB.TextBox Text1 
         Height          =   375
         Index           =   7
         Left            =   1800
         TabIndex        =   34
         Text            =   "30"
         Top             =   3600
         Width           =   615
      End
      Begin VB.TextBox Text1 
         Height          =   375
         Index           =   6
         Left            =   1080
         TabIndex        =   36
         Text            =   "100"
         Top             =   3600
         Width           =   615
      End
      Begin VB.CommandButton UpdateButton 
         Caption         =   "UPDATE"
         Height          =   375
         Index           =   4
         Left            =   2520
         TabIndex        =   35
         Top             =   3600
         Width           =   855
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Text"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Index           =   14
         Left            =   120
         TabIndex        =   45
         Top             =   360
         Width           =   390
      End
      Begin VB.Label Label1 
         BackStyle       =   0  'Transparent
         Caption         =   "Flat Style"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   1
         Left            =   120
         TabIndex        =   44
         Top             =   1200
         Width           =   2055
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Size"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Index           =   12
         Left            =   120
         TabIndex        =   43
         Top             =   3600
         Width           =   375
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Location"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Index           =   11
         Left            =   120
         TabIndex        =   42
         Top             =   4320
         Width           =   750
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "x"
         Height          =   195
         Index           =   10
         Left            =   1080
         TabIndex        =   41
         Top             =   4080
         Width           =   75
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "y"
         Height          =   195
         Index           =   9
         Left            =   1800
         TabIndex        =   40
         Top             =   4080
         Width           =   75
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "width"
         Height          =   195
         Index           =   8
         Left            =   1080
         TabIndex        =   39
         Top             =   3360
         Width           =   375
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "height"
         Height          =   195
         Index           =   7
         Left            =   1800
         TabIndex        =   38
         Top             =   3360
         Width           =   435
      End
   End
   Begin VB.CommandButton CreateButton 
      Caption         =   "Add a System.WinForms.Button"
      Height          =   375
      Index           =   1
      Left            =   3720
      TabIndex        =   25
      Top             =   120
      Visible         =   0   'False
      Width           =   3495
   End
   Begin VB.Frame Frame1 
      Caption         =   "Modify Form"
      ForeColor       =   &H00C00000&
      Height          =   4815
      Index           =   0
      Left            =   120
      TabIndex        =   1
      Top             =   600
      Visible         =   0   'False
      Width           =   3495
      Begin VB.OptionButton Option1 
         Caption         =   "SizableToolWindow"
         Height          =   255
         Index           =   6
         Left            =   120
         TabIndex        =   12
         Top             =   2880
         Width           =   2535
      End
      Begin VB.CommandButton UpdateButton 
         Caption         =   "UPDATE"
         Height          =   375
         Index           =   2
         Left            =   2520
         TabIndex        =   18
         Top             =   4320
         Width           =   855
      End
      Begin VB.CommandButton UpdateButton 
         Caption         =   "UPDATE"
         Height          =   375
         Index           =   1
         Left            =   2520
         TabIndex        =   15
         Top             =   3600
         Width           =   855
      End
      Begin VB.TextBox Text1 
         Height          =   375
         Index           =   4
         Left            =   1800
         TabIndex        =   17
         Text            =   "100"
         Top             =   4320
         Width           =   615
      End
      Begin VB.TextBox Text1 
         Height          =   375
         Index           =   3
         Left            =   1080
         TabIndex        =   16
         Text            =   "100"
         Top             =   4320
         Width           =   615
      End
      Begin VB.TextBox Text1 
         Height          =   375
         Index           =   2
         Left            =   1800
         TabIndex        =   14
         Text            =   "300"
         Top             =   3600
         Width           =   615
      End
      Begin VB.TextBox Text1 
         Height          =   375
         Index           =   1
         Left            =   1080
         TabIndex        =   13
         Text            =   "250"
         Top             =   3600
         Width           =   615
      End
      Begin VB.OptionButton Option1 
         Caption         =   "Sizable"
         Height          =   255
         Index           =   5
         Left            =   120
         TabIndex        =   11
         Top             =   2640
         Value           =   -1  'True
         Width           =   2535
      End
      Begin VB.OptionButton Option1 
         Caption         =   "None"
         Height          =   255
         Index           =   4
         Left            =   120
         TabIndex        =   10
         Top             =   2400
         Width           =   2535
      End
      Begin VB.OptionButton Option1 
         Caption         =   "FixedToolWindow"
         Height          =   255
         Index           =   3
         Left            =   120
         TabIndex        =   9
         Top             =   2160
         Width           =   2535
      End
      Begin VB.OptionButton Option1 
         Caption         =   "FixedSingle"
         Height          =   255
         Index           =   2
         Left            =   120
         TabIndex        =   8
         Top             =   1920
         Width           =   2535
      End
      Begin VB.OptionButton Option1 
         Caption         =   "FixedDialog"
         Height          =   255
         Index           =   1
         Left            =   120
         TabIndex        =   7
         Top             =   1680
         Width           =   2535
      End
      Begin VB.OptionButton Option1 
         Caption         =   "Fixed3D"
         Height          =   255
         Index           =   0
         Left            =   120
         TabIndex        =   6
         Top             =   1440
         Width           =   2535
      End
      Begin VB.CheckBox Check1 
         Caption         =   "Always on Top"
         Height          =   255
         Index           =   2
         Left            =   120
         TabIndex        =   4
         Top             =   840
         Width           =   3015
      End
      Begin VB.CheckBox Check1 
         Caption         =   "Disable Minimize Box"
         Height          =   255
         Index           =   1
         Left            =   120
         TabIndex        =   3
         Top             =   600
         Width           =   3015
      End
      Begin VB.CheckBox Check1 
         Caption         =   "Disable Maximize Box"
         Height          =   255
         Index           =   0
         Left            =   120
         TabIndex        =   2
         Top             =   360
         Width           =   3015
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "height"
         Height          =   195
         Index           =   6
         Left            =   1800
         TabIndex        =   24
         Top             =   3360
         Width           =   435
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "width"
         Height          =   195
         Index           =   5
         Left            =   1080
         TabIndex        =   23
         Top             =   3360
         Width           =   375
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "y"
         Height          =   195
         Index           =   4
         Left            =   1800
         TabIndex        =   22
         Top             =   4080
         Width           =   75
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "x"
         Height          =   195
         Index           =   3
         Left            =   1080
         TabIndex        =   21
         Top             =   4080
         Width           =   75
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Location"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Index           =   2
         Left            =   120
         TabIndex        =   20
         Top             =   4320
         Width           =   750
      End
      Begin VB.Label Label2 
         AutoSize        =   -1  'True
         BackStyle       =   0  'Transparent
         Caption         =   "Size"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   195
         Index           =   1
         Left            =   120
         TabIndex        =   19
         Top             =   3600
         Width           =   375
      End
      Begin VB.Label Label1 
         BackStyle       =   0  'Transparent
         Caption         =   "Border Style"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Index           =   0
         Left            =   120
         TabIndex        =   5
         Top             =   1200
         Width           =   2055
      End
   End
   Begin VB.CommandButton CreateButton 
      Caption         =   "Create a System.WinForms.Form"
      Height          =   375
      Index           =   0
      Left            =   120
      TabIndex        =   0
      Top             =   120
      Width           =   3495
   End
End
Attribute VB_Name = "VB6Form"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
''===========================================================================
''  File:       VB6Form.frm
''
''  Summary:    Uses a System.WinForms.Form from VB6.
''
''---------------------------------------------------------------------------
''  Copyright (C) 1998-2000 Microsoft Corporation.  All rights reserved.
''===========================================================================
Option Explicit
Dim f As System_WinForms.Form
Dim b As System_WinForms.Button

Private Sub CreateButton_Click(Index As Integer)
    If Index = 0 Then
        Me.MousePointer = 11
        Set f = New System_WinForms.Form
        f.Text = "This is a System.WinForms.Form"
        f.Show
        Frame1(0).Visible = True
        CreateButton(1).Visible = True
        CreateButton(0).Enabled = False
        Frame1(0).Caption = Frame1(0).Caption & " (Handle = " & CStr(f.Handle) & ")"
        Me.MousePointer = 0
    Else
        Set b = New System_WinForms.Button
        b.Text = "Button"
        f.Controls.Add b
        Frame1(1).Visible = True
        CreateButton(1).Enabled = False
        Frame1(1).Caption = Frame1(1).Caption & " (Handle = " & CStr(b.Handle) & ")"
    End If
End Sub

Private Sub Check1_Click(Index As Integer)
    If Index = 0 Then
        f.MaximizeBox = Not f.MaximizeBox
    ElseIf Index = 1 Then
        f.MinimizeBox = Not f.MinimizeBox
    ElseIf Index = 2 Then
        f.TopMost = Not f.TopMost
    End If
End Sub

Private Sub Form_Unload(Cancel As Integer)
    If Not f Is Nothing Then f.Close
End Sub

Private Sub Option1_Click(Index As Integer)
    If Index = 0 Then
        f.BorderStyle = FormBorderStyle_Fixed3D
    ElseIf Index = 1 Then
        f.BorderStyle = FormBorderStyle_FixedDialog
    ElseIf Index = 2 Then
        f.BorderStyle = FormBorderStyle_FixedSingle
    ElseIf Index = 3 Then
        f.BorderStyle = FormBorderStyle_FixedToolWindow
    ElseIf Index = 4 Then
        f.BorderStyle = FormBorderStyle_None
    ElseIf Index = 5 Then
        f.BorderStyle = FormBorderStyle_Sizable
    ElseIf Index = 6 Then
        f.BorderStyle = FormBorderStyle_SizableToolWindow
    ElseIf Index = 7 Then
        b.FlatStyle = FlatStyle_Flat
    ElseIf Index = 8 Then
        b.FlatStyle = FlatStyle_Popup
    ElseIf Index = 9 Then
        b.FlatStyle = FlatStyle_Standard
    End If
End Sub

Private Sub UpdateButton_Click(Index As Integer)
    On Error GoTo catch
    If Index = 0 Then
        f.Opacity = CDbl(Text1(0).Text)
    ElseIf Index = 1 Then
        f.SetSize CLng(Text1(1).Text), CLng(Text1(2).Text)
    ElseIf Index = 2 Then
        f.SetLocation CLng(Text1(3).Text), CLng(Text1(4).Text)
    ElseIf Index = 3 Then
        b.Opacity = CDbl(Text1(5).Text)
    ElseIf Index = 4 Then
        b.SetSize CLng(Text1(6).Text), CLng(Text1(7).Text)
    ElseIf Index = 5 Then
        b.SetLocation CLng(Text1(8).Text), CLng(Text1(9).Text)
    ElseIf Index = 6 Then
        b.Text = Text1(10).Text
    End If
    Exit Sub
catch:
    MsgBox "Error #" & Err.Number & ": " & Err.Description, , "Error"
End Sub
