VERSION 5.00
Begin VB.MDIForm MDIFormWOS 
   BackColor       =   &H8000000C&
   Caption         =   "WORK ORDER APPLICATION"
   ClientHeight    =   7305
   ClientLeft      =   60
   ClientTop       =   435
   ClientWidth     =   9690
   Icon            =   "MDIFormWOS.frx":0000
   LinkTopic       =   "MDIForm1"
   WindowState     =   2  'Maximized
   Begin VB.PictureBox Picture1 
      Align           =   1  'Align Top
      BackColor       =   &H80000004&
      Height          =   495
      Left            =   0
      ScaleHeight     =   435
      ScaleWidth      =   9630
      TabIndex        =   0
      Top             =   0
      Width           =   9690
      Begin VB.CommandButton cmdPrint 
         Height          =   450
         Left            =   7920
         Picture         =   "MDIFormWOS.frx":0442
         Style           =   1  'Graphical
         TabIndex        =   16
         ToolTipText     =   "Print"
         Top             =   0
         Width           =   480
      End
      Begin VB.CommandButton cmdSearch 
         Height          =   450
         Left            =   7320
         Picture         =   "MDIFormWOS.frx":0544
         Style           =   1  'Graphical
         TabIndex        =   15
         ToolTipText     =   "Search"
         Top             =   0
         Width           =   480
      End
      Begin VB.CommandButton cmdCancel 
         Height          =   450
         Left            =   4680
         Picture         =   "MDIFormWOS.frx":0646
         Style           =   1  'Graphical
         TabIndex        =   14
         ToolTipText     =   "Cancel"
         Top             =   0
         Width           =   480
      End
      Begin VB.CommandButton cmdFirst 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   450
         Left            =   5280
         Picture         =   "MDIFormWOS.frx":0748
         Style           =   1  'Graphical
         TabIndex        =   13
         ToolTipText     =   "First"
         Top             =   0
         Width           =   480
      End
      Begin VB.CommandButton cmdPrevious 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   450
         Left            =   5760
         Picture         =   "MDIFormWOS.frx":117A
         Style           =   1  'Graphical
         TabIndex        =   12
         ToolTipText     =   "Previous"
         Top             =   0
         Width           =   480
      End
      Begin VB.CommandButton cmdNext 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   450
         Left            =   6240
         Picture         =   "MDIFormWOS.frx":1BAC
         Style           =   1  'Graphical
         TabIndex        =   11
         ToolTipText     =   "Next"
         Top             =   0
         Width           =   480
      End
      Begin VB.CommandButton cmdLast 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   450
         Left            =   6720
         Picture         =   "MDIFormWOS.frx":25DE
         Style           =   1  'Graphical
         TabIndex        =   10
         ToolTipText     =   "Last"
         Top             =   0
         Width           =   480
      End
      Begin VB.CommandButton cmdAdd 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   450
         Left            =   4200
         Picture         =   "MDIFormWOS.frx":3010
         Style           =   1  'Graphical
         TabIndex        =   9
         ToolTipText     =   "Add"
         Top             =   0
         Width           =   480
      End
      Begin VB.CommandButton cmdDelete 
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   450
         Left            =   3720
         Picture         =   "MDIFormWOS.frx":3112
         Style           =   1  'Graphical
         TabIndex        =   8
         ToolTipText     =   "Delete"
         Top             =   0
         Width           =   480
      End
      Begin VB.CommandButton cmdSave 
         Height          =   450
         Left            =   3240
         Picture         =   "MDIFormWOS.frx":3214
         Style           =   1  'Graphical
         TabIndex        =   7
         ToolTipText     =   "Save"
         Top             =   0
         Width           =   480
      End
      Begin VB.CommandButton cmdRefresh 
         Height          =   450
         Left            =   2640
         Picture         =   "MDIFormWOS.frx":387E
         Style           =   1  'Graphical
         TabIndex        =   6
         ToolTipText     =   "Refresh"
         Top             =   0
         Width           =   480
      End
      Begin VB.CommandButton cmdGridView 
         Height          =   450
         Left            =   2040
         Picture         =   "MDIFormWOS.frx":3CC0
         Style           =   1  'Graphical
         TabIndex        =   5
         ToolTipText     =   "Grid View"
         Top             =   0
         Width           =   480
      End
      Begin VB.CommandButton cmdFormView 
         Height          =   450
         Left            =   1560
         Picture         =   "MDIFormWOS.frx":4102
         Style           =   1  'Graphical
         TabIndex        =   4
         ToolTipText     =   "Form View"
         Top             =   0
         Width           =   480
      End
      Begin VB.CommandButton cmdWorkOrder 
         Height          =   450
         Left            =   960
         Picture         =   "MDIFormWOS.frx":4544
         Style           =   1  'Graphical
         TabIndex        =   3
         ToolTipText     =   "History"
         Top             =   0
         Width           =   480
      End
      Begin VB.CommandButton cmdTask 
         Height          =   450
         Left            =   480
         Picture         =   "MDIFormWOS.frx":4986
         Style           =   1  'Graphical
         TabIndex        =   2
         ToolTipText     =   "Work Order"
         Top             =   0
         Width           =   480
      End
      Begin VB.CommandButton cmdEquipment 
         Height          =   450
         Left            =   0
         Picture         =   "MDIFormWOS.frx":4DC8
         Style           =   1  'Graphical
         TabIndex        =   1
         ToolTipText     =   "Equipment"
         Top             =   0
         Width           =   480
      End
   End
   Begin VB.Menu mnuFile 
      Caption         =   "&File"
      Index           =   0
      Begin VB.Menu mnuExit 
         Caption         =   "&Exit"
      End
   End
   Begin VB.Menu mnuForms 
      Caption         =   "F&orms"
      Begin VB.Menu mnuEquipment 
         Caption         =   "&Equipment"
      End
      Begin VB.Menu mnuTask 
         Caption         =   "&Work Order"
      End
      Begin VB.Menu mnuWorkOrder 
         Caption         =   "&History"
      End
      Begin VB.Menu mnuMeterReading 
         Caption         =   "&Meter Reading"
      End
   End
   Begin VB.Menu mnuReports 
      Caption         =   "&Reports"
      Begin VB.Menu mnuEquipList 
         Caption         =   "&Equipment Detail"
      End
      Begin VB.Menu mnuEquipSum 
         Caption         =   "Equipment &Summary"
      End
      Begin VB.Menu mnuMeterReadingList 
         Caption         =   "&Meter Reading List"
      End
   End
   Begin VB.Menu mnuUtilities 
      Caption         =   "&Utilities"
      Begin VB.Menu mnuNewPlant 
         Caption         =   "Create New Plant"
      End
   End
   Begin VB.Menu mnuHelp 
      Caption         =   "&Help"
      Visible         =   0   'False
      Begin VB.Menu mnuAbout 
         Caption         =   "&About"
      End
   End
End
Attribute VB_Name = "MDIFormWOS"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim ans As Integer
Dim bolCreatePlantClicked As Boolean


Private Sub cmdAdd_Click()
    ActiveForm.Add
End Sub

Private Sub cmdCancel_Click()
    'SaveActive
    ActiveForm.Cancel
End Sub

Private Sub cmdDelete_Click()
    ActiveForm.Delete
End Sub

Private Sub cmdEquipment_Click()
    SaveActive
    frmPlant.CheckAll "equip"
End Sub

Private Sub cmdFirst_Click()
    ActiveForm.FirstRec
End Sub

Private Sub cmdFormView_Click()
    ActiveForm.FormView
End Sub

Private Sub cmdGridView_Click()
    ActiveForm.GridView
End Sub

Private Sub cmdLast_Click()
    ActiveForm.LastRec
End Sub

Private Sub cmdNext_Click()
    ActiveForm.NextRec
End Sub

Private Sub cmdPrevious_Click()
    ActiveForm.PrevRec
End Sub


Private Sub cmdPrint_Click()
    ActiveForm.PrintReports
End Sub

Private Sub cmdRefresh_Click()
    SaveActive
    ActiveForm.RefreshRec
End Sub

Private Sub cmdSave_Click()
    ActiveForm.Save
End Sub

Private Sub cmdSearch_Click()
    ActiveForm.SearchRec
End Sub

Private Sub cmdTask_Click()
    SaveActive
    frmPlant.CheckAll "task"
End Sub

Private Sub cmdWorkOrder_Click()
    SaveActive
    frmPlant.CheckAll "wo"
End Sub

Public Sub SaveActive()
    ' This procedure will save the changes in active form
    ' by calling function under specific form
    Dim strFormName As String

On Error GoTo errorhandler
    strFormName = ""
    If Forms.count > 1 Then
        strFormName = ActiveForm.Name
        If (strFormName = "frmTask" Or strFormName = "frmWorkOrder" Or strFormName = "frmEquipment") Then
            ActiveForm.CheckChange
        End If
        'MsgBox "Active form is " & strFormName
    'Else
        'MsgBox "MDI is the only form"
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: MDI - SaveActive: Description - " & Err.Description
End Sub

Public Sub FindActive(bolAllClosed As Boolean)

On Error GoTo errorhandler

    If bolAllClosed = True Then
        cmdFormView.Enabled = False
        cmdGridView.Enabled = False
        cmdRefresh.Enabled = False
        cmdSave.Enabled = False
        cmdDelete.Enabled = False
        cmdAdd.Enabled = False
        cmdCancel.Enabled = False
        cmdFirst.Enabled = False
        cmdPrevious.Enabled = False
        cmdNext.Enabled = False
        cmdLast.Enabled = False
        cmdSearch.Enabled = False
        cmdPrint.Enabled = False
    Else
        strActiveFormName = ""
        strActiveFormName = ActiveForm.Name
        Select Case strActiveFormName
            Case "frmMeterReading"
                cmdFormView.Enabled = False
                cmdGridView.Enabled = False
                cmdRefresh.Enabled = True
                cmdSave.Enabled = False
                cmdDelete.Enabled = False
                cmdAdd.Enabled = False
                cmdCancel.Enabled = False
                cmdFirst.Enabled = False
                cmdPrevious.Enabled = False
                cmdNext.Enabled = False
                cmdLast.Enabled = False
                cmdSearch.Enabled = False
                cmdPrint.Enabled = False
            Case "frmEquipment"
                cmdFormView.Enabled = True
                cmdGridView.Enabled = True
                cmdRefresh.Enabled = True
                cmdSave.Enabled = True
                cmdDelete.Enabled = False
                cmdAdd.Enabled = True
                cmdCancel.Enabled = True
                cmdFirst.Enabled = True
                cmdPrevious.Enabled = True
                cmdNext.Enabled = True
                cmdLast.Enabled = True
                cmdSearch.Enabled = False
                cmdPrint.Enabled = False
            Case "frmTask"
                cmdFormView.Enabled = True
                cmdGridView.Enabled = True
                cmdRefresh.Enabled = True
                cmdSave.Enabled = True
                cmdDelete.Enabled = False
                cmdAdd.Enabled = True
                cmdCancel.Enabled = True
                cmdFirst.Enabled = True
                cmdPrevious.Enabled = True
                cmdNext.Enabled = True
                cmdLast.Enabled = True
                cmdSearch.Enabled = True
                cmdPrint.Enabled = True
            Case "frmWorkOrder"
                cmdFormView.Enabled = True
                cmdGridView.Enabled = True
                cmdRefresh.Enabled = True
                cmdSave.Enabled = True
                cmdDelete.Enabled = True
                cmdAdd.Enabled = True
                cmdCancel.Enabled = True
                cmdFirst.Enabled = True
                cmdPrevious.Enabled = True
                cmdNext.Enabled = True
                cmdLast.Enabled = True
                cmdSearch.Enabled = True
                cmdPrint.Enabled = True
        End Select
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: MDI - FindActive: Description - " & Err.Description
End Sub

Public Sub AddMode()

On Error GoTo errorhandler

    cmdFormView.Enabled = False
    cmdGridView.Enabled = False
    cmdRefresh.Enabled = False
    cmdSave.Enabled = True
    cmdDelete.Enabled = False
    cmdAdd.Enabled = False
    cmdCancel.Enabled = True
    cmdFirst.Enabled = False
    cmdPrevious.Enabled = False
    cmdNext.Enabled = False
    cmdLast.Enabled = False
    cmdSearch.Enabled = False
    cmdPrint.Enabled = False
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: MDI - AddMode: Description - " & Err.Description
End Sub

Private Sub MDIForm_Load()
    bolCreatePlantClicked = False
End Sub

Private Sub MDIForm_Unload(Cancel As Integer)
    If Not bolCreatePlantClicked Then
        End
    End If
End Sub

Private Sub mnuEquipList_Click()

On Error GoTo errorhandler

    intReport = 0
    intReport = 1
    DEnvWos.conWOS.Open
    DEnvWos.comEquipList intPlantPass
    DRptEquipList.Show (1)
    DRptEquipList.Top = 1100
    DRptEquipList.Left = 1
    DRptEquipList.Height = 6400
    DRptEquipList.Width = 9300
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: MDI - mnuEquipList_Click: Description - " & Err.Description
End Sub

Private Sub mnuEquipment_Click()
    SaveActive
    frmPlant.CheckAll "equip"
End Sub

Private Sub mnuEquipSum_Click()

On Error GoTo errorhandler

    intReport = 0
    intReport = 5
    DEnvWos.conWOS.Open
    DEnvWos.comEquipList intPlantPass
    DRptEquipSum.Show (1)
    DRptEquipSum.Top = 1100
    DRptEquipSum.Left = 1
    DRptEquipSum.Height = 6400
    DRptEquipSum.Width = 9300
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: MDI - mnuEquipSum_Click: Description - " & Err.Description
End Sub

Private Sub mnuExit_Click()
    SaveActive
    End
End Sub

Private Sub mnuMeterReading_Click()

On Error GoTo errorhandler
    If Forms.count > 1 Then
        If ActiveForm.Name = "frmEquipment" Then
            Unload frmEquipment
        End If
    End If
    If frmEquipment.CheckRecordset = 2 Then
        MsgBox "Can not open the Meter Reading Screen because there are no records to update."
    Else
        frmMeterReading.Show
        frmMeterReading.SetFocus
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: MDI - mnuMeterReading_Click: Description - " & Err.Description
End Sub

Private Sub mnuMeterReadingList_Click()

On Error GoTo errorhandler

    intReport = 0
    intReport = 5
    DEnvWos.conWOS.Open
    DEnvWos.comMeterReading intPlantPass
    DRptMeterReading.Show (1)
    DRptMeterReading.Top = 1100
    DRptMeterReading.Left = 1
    DRptMeterReading.Height = 6400
    DRptMeterReading.Width = 9300
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: MDI - mnuMeterReadingList_Click: Description - " & Err.Description
End Sub

Private Sub mnuNewPlant_Click()

On Error GoTo errorhandler
    SaveActive
    bolCreatePlantClicked = True
    Unload MDIFormWOS
    frmPlant.Show
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: MDI - cboEquipID_KeyUp: Description - " & Err.Description
End Sub

Private Sub mnuTask_Click()
    SaveActive
    frmPlant.CheckAll "task"
End Sub

Private Sub mnuWorkOrder_Click()
    SaveActive
    frmPlant.CheckAll "wo"
End Sub
