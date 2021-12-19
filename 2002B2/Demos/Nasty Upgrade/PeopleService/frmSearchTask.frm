VERSION 5.00
Begin VB.Form frmSearchTask 
   Caption         =   "Search Work Order"
   ClientHeight    =   3840
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   5340
   LinkTopic       =   "Form1"
   ScaleHeight     =   3840
   ScaleWidth      =   5340
   StartUpPosition =   3  'Windows Default
   Begin VB.TextBox txtEquipID 
      Height          =   285
      Left            =   3480
      TabIndex        =   6
      Top             =   1680
      Width           =   975
   End
   Begin VB.TextBox txtTaskID 
      Height          =   285
      Left            =   3480
      TabIndex        =   7
      Top             =   2040
      Width           =   975
   End
   Begin VB.TextBox txtMiscComments 
      Height          =   285
      Left            =   3480
      TabIndex        =   9
      Top             =   2760
      Width           =   1455
   End
   Begin VB.CommandButton cmdFind 
      Caption         =   "Find >>"
      Height          =   495
      Left            =   3720
      TabIndex        =   10
      Top             =   3240
      Width           =   1215
   End
   Begin VB.TextBox txtDueDate 
      Height          =   285
      Left            =   3480
      TabIndex        =   8
      Top             =   2400
      Width           =   1455
   End
   Begin VB.TextBox txtEquipKey 
      Height          =   285
      Left            =   3480
      TabIndex        =   5
      Top             =   1320
      Width           =   1455
   End
   Begin VB.Frame framTaskType 
      Caption         =   "Work Order Type"
      Height          =   1095
      Left            =   1320
      TabIndex        =   0
      Top             =   120
      Width           =   3615
      Begin VB.OptionButton optUnschedule 
         Caption         =   "Unsheduled"
         Height          =   375
         Left            =   120
         TabIndex        =   3
         Top             =   600
         Width           =   1215
      End
      Begin VB.OptionButton OptDueDate 
         Caption         =   "Due by Date"
         Height          =   375
         Left            =   120
         TabIndex        =   1
         Top             =   240
         Width           =   1215
      End
      Begin VB.OptionButton OptDueMeter 
         Caption         =   "Due by Meter"
         Height          =   375
         Left            =   2040
         TabIndex        =   2
         Top             =   240
         Width           =   1455
      End
      Begin VB.OptionButton OptAll 
         Caption         =   "All"
         Height          =   375
         Left            =   2040
         TabIndex        =   4
         Top             =   600
         Width           =   1215
      End
   End
   Begin VB.Label Label5 
      Alignment       =   1  'Right Justify
      Caption         =   "Work Order ID (Optional):"
      Height          =   255
      Left            =   1560
      TabIndex        =   15
      Top             =   2040
      Width           =   1815
   End
   Begin VB.Label Label4 
      Alignment       =   1  'Right Justify
      Caption         =   "Equip ID (Optional):"
      Height          =   255
      Left            =   1560
      TabIndex        =   14
      Top             =   1680
      Width           =   1815
   End
   Begin VB.Label Label3 
      Alignment       =   1  'Right Justify
      Caption         =   "Word from Work Order Comments (Optional):"
      Height          =   255
      Left            =   0
      TabIndex        =   13
      Top             =   2760
      Width           =   3375
   End
   Begin VB.Label Label2 
      Alignment       =   1  'Right Justify
      Caption         =   "Due Date (if ""Due by Date"" selected) "
      Height          =   255
      Left            =   480
      TabIndex        =   12
      Top             =   2400
      Width           =   2895
   End
   Begin VB.Label Label1 
      Alignment       =   1  'Right Justify
      Caption         =   "Equip Key (Optional):"
      Height          =   255
      Left            =   1560
      TabIndex        =   11
      Top             =   1320
      Width           =   1815
   End
End
Attribute VB_Name = "frmSearchTask"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Private Sub cmdFind_Click()

'
' Evaluates what has been selected or typed for search and
' uses the values to find if there are records based on criteria.
' FindRecords function from frmTask is used with all the criteria
' and value of 1 for checking. If it finds records then it
' calls same function and brings back to the Work Order(task) view with new records
' otherwise tells user to change the search criteria
'

    Dim strOpt, strEquipID, strDate, strMiscComments As String
    Dim intResult As Integer
    
On Error GoTo errorhandler

    If OptDueDate.Value = True And txtDueDate = "" Then
        MsgBox "Due Date is required if the Option is selected."
    ElseIf OptDueDate.Value = False And txtDueDate <> "" Then
        MsgBox "Due date can not be entered for other options."
        txtDueDate.Text = ""
    Else
        If OptDueDate.Value = True Then
            strOpt = "DueDate"
        ElseIf OptDueMeter.Value = True Then
            strOpt = "DueMeter"
        ElseIf optUnschedule.Value = True Then
            strOpt = "Unscheduled"
        Else
            strOpt = "All"
        End If
        
        intResult = frmTask.FindRecords(strOpt, txtEquipKey.Text, txtEquipID.Text, txtTaskID.Text, txtDueDate.Text, txtMiscComments.Text, 1)
        If intResult = 1 Then
            intResult = frmTask.FindRecords(strOpt, txtEquipKey.Text, txtEquipID.Text, txtTaskID.Text, txtDueDate.Text, txtMiscComments.Text, 2)
            Unload Me
        Else
            MsgBox "No records with search criteria."
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: SearchTask - cmdFind_Click: Description - " & Err.Description
End Sub

Private Sub Form_Load()

'
' Starts with option of - All records with Days Cycle
'

    OptDueDate.Value = True
End Sub

Private Sub txtDueDate_Validate(Cancel As Boolean)

'
' If there is a value for date field and format is incorrect it
' clears the field and requests for re-entry
'

On Error GoTo errorhandler

    If IsDate(txtDueDate.Text) = False And txtDueDate.Text <> "" Then
        MsgBox ("Incorrect Format. Please Re-enter.")
        txtDueDate.Text = ""
    End If

Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: SearchTask - txtDueDate_Validate: Description - " & Err.Description
End Sub

