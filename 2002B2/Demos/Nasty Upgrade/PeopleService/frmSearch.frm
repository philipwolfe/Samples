VERSION 5.00
Object = "{C932BA88-4374-101B-A56C-00AA003668DC}#1.1#0"; "msmask32.ocx"
Begin VB.Form frmSearchWO 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Search History"
   ClientHeight    =   5040
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   6540
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   5040
   ScaleWidth      =   6540
   StartUpPosition =   3  'Windows Default
   Begin VB.Frame framWOTypes 
      Caption         =   "Work Order Types"
      Height          =   975
      Left            =   360
      TabIndex        =   18
      Top             =   840
      Width           =   5775
      Begin VB.OptionButton optAll 
         Caption         =   "All"
         Height          =   375
         Left            =   4560
         TabIndex        =   22
         Top             =   360
         Width           =   975
      End
      Begin VB.OptionButton optUnschedule 
         Caption         =   "Unschedule"
         Height          =   375
         Left            =   3120
         TabIndex        =   21
         Top             =   360
         Width           =   1215
      End
      Begin VB.OptionButton OptDueMeter 
         Caption         =   "Due by Meter"
         Height          =   375
         Left            =   1680
         TabIndex        =   20
         Top             =   360
         Width           =   1335
      End
      Begin VB.OptionButton OptDueDate 
         Caption         =   "Due by Date"
         Height          =   375
         Left            =   240
         TabIndex        =   19
         Top             =   360
         Width           =   1215
      End
   End
   Begin VB.TextBox txtInitial 
      Height          =   285
      Left            =   3240
      TabIndex        =   6
      Top             =   3720
      Width           =   1215
   End
   Begin VB.CommandButton cmdFind 
      Caption         =   "Find >>"
      Height          =   495
      Left            =   4800
      TabIndex        =   9
      Top             =   4440
      Width           =   975
   End
   Begin VB.TextBox txtEquipDesc 
      Height          =   285
      Left            =   3240
      TabIndex        =   1
      Top             =   2280
      Width           =   1215
   End
   Begin VB.TextBox txtTaskDesc 
      Height          =   285
      Left            =   3240
      TabIndex        =   2
      Top             =   2640
      Width           =   1215
   End
   Begin VB.TextBox txtTaskMiscComments 
      Height          =   285
      Left            =   3240
      TabIndex        =   4
      Top             =   3000
      Width           =   1215
   End
   Begin VB.TextBox txtComments 
      Height          =   285
      Left            =   3240
      TabIndex        =   5
      Top             =   3360
      Width           =   1215
   End
   Begin VB.TextBox txtEquipKey 
      Height          =   285
      Left            =   3240
      MaxLength       =   10
      TabIndex        =   0
      Top             =   1920
      Width           =   1215
   End
   Begin MSMask.MaskEdBox TxtDateCompleted1 
      Height          =   255
      Left            =   3240
      TabIndex        =   7
      Top             =   4080
      Width           =   1215
      _ExtentX        =   2143
      _ExtentY        =   450
      _Version        =   393216
      MaxLength       =   8
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Format          =   "m/d/yy"
      PromptChar      =   "_"
   End
   Begin MSMask.MaskEdBox TxtDateCompleted2 
      Height          =   255
      Left            =   4800
      TabIndex        =   8
      Top             =   4080
      Width           =   1215
      _ExtentX        =   2143
      _ExtentY        =   450
      _Version        =   393216
      MaxLength       =   8
      BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Format          =   "m/d/yy"
      PromptChar      =   "_"
   End
   Begin VB.Label Label8 
      Alignment       =   1  'Right Justify
      Caption         =   "Initials:"
      Height          =   255
      Left            =   2640
      TabIndex        =   17
      Top             =   3720
      Width           =   495
   End
   Begin VB.Label Label7 
      Alignment       =   1  'Right Justify
      Caption         =   "Equip Key needs to be exact:"
      Height          =   255
      Left            =   960
      TabIndex        =   16
      Top             =   1920
      Width           =   2175
   End
   Begin VB.Label Label6 
      Alignment       =   1  'Right Justify
      Caption         =   "Word(s) from Equip Desc:"
      Height          =   255
      Left            =   960
      TabIndex        =   15
      Top             =   2280
      Width           =   2175
   End
   Begin VB.Label Label5 
      Alignment       =   1  'Right Justify
      Caption         =   "Word(s) from Work Order Desc:"
      Height          =   255
      Left            =   600
      TabIndex        =   14
      Top             =   2640
      Width           =   2535
   End
   Begin VB.Label Label4 
      Alignment       =   1  'Right Justify
      Caption         =   "Word(s) from Work Order Comments:"
      Height          =   255
      Left            =   360
      TabIndex        =   13
      Top             =   3000
      Width           =   2775
   End
   Begin VB.Label Label3 
      Alignment       =   1  'Right Justify
      Caption         =   "Word(s) from History Comments:"
      Height          =   255
      Left            =   360
      TabIndex        =   12
      Top             =   3360
      Width           =   2775
   End
   Begin VB.Label Label2 
      Alignment       =   1  'Right Justify
      Caption         =   "Completed Dates between:"
      Height          =   255
      Left            =   960
      TabIndex        =   11
      Top             =   4080
      Width           =   2175
   End
   Begin VB.Label Label1 
      Alignment       =   2  'Center
      Caption         =   "and"
      Height          =   255
      Left            =   4440
      TabIndex        =   10
      Top             =   4080
      Width           =   375
   End
   Begin VB.Label lblInfo 
      Caption         =   $"frmSearch.frx":0000
      Height          =   615
      Left            =   240
      TabIndex        =   3
      Top             =   120
      Width           =   5655
   End
End
Attribute VB_Name = "frmSearchWO"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub cmdFind_Click()

'
' Evaluates what has been selected or typed for search and
' uses the values to find if there are records based on criteria.
' FindRecords function from frmWorkOrder is used with all the criteria
' and value of 1 for checking. If it finds records then it
' calls same function and brings back to the History view with new records
' otherwise tells user to change the search criteria
'


    Dim intResult As Integer
    Dim strOpt As String
    
On Error GoTo errorhandler


    If OptDueDate.Value = True Then
        strOpt = "DueDate"
    ElseIf OptDueMeter.Value = True Then
        strOpt = "DueMeter"
    ElseIf optUnschedule.Value = True Then
        strOpt = "Unschedule"
    Else
        strOpt = "All"
    End If
    intResult = frmWorkOrder.FindRecords(strOpt, txtEquipKey.Text, txtEquipDesc.Text, txtTaskDesc.Text, txtTaskMiscComments.Text, txtComments.Text, txtInitial.Text, TxtDateCompleted1.Text, TxtDateCompleted2.Text, 1)
    If intResult = 1 Then
        intResult = frmWorkOrder.FindRecords(strOpt, txtEquipKey.Text, txtEquipDesc.Text, txtTaskDesc.Text, txtTaskMiscComments.Text, txtComments.Text, txtInitial.Text, TxtDateCompleted1.Text, TxtDateCompleted2.Text, 2)
        frmWorkOrder.Populate
        Unload Me
    Else
        MsgBox "Records not found for the entered search criteria."
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: SearchWO - cmdFind_Click: Description - " & Err.Description
End Sub

Private Sub Form_Load()

'
' Starts with - All records with Days Cycle
'

    OptDueDate.Value = True
End Sub

Private Sub TxtDateCompleted1_Validate(Cancel As Boolean)

'
' If there is a value for date field and format is incorrect it
' clears the field and requests for re-entry
'

On Error GoTo errorhandler

    If TxtDateCompleted1.Text <> "" Then
        If IsDate(TxtDateCompleted1.Text) = False Then
            MsgBox "Incorrect Format. Please Re-enter."
            Cancel = True
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: SearchWO - txtDateCompleted1_Validate: Description - " & Err.Description
End Sub

Private Sub TxtDateCompleted2_Validate(Cancel As Boolean)

'
' If there is a value for date field and format is incorrect it
' clears the field and requests for re-entry
'

On Error GoTo errorhandler

    If TxtDateCompleted2.Text <> "" Then
        If IsDate(TxtDateCompleted2.Text) = False Then
            MsgBox "Incorrect Format. Please Re-enter."
            Cancel = True
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: SearchWO - txtDateCompleted2_Validate: Description - " & Err.Description
End Sub
