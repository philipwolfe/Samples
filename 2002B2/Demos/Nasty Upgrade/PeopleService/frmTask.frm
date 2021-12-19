VERSION 5.00
Object = "{CDE57A40-8B86-11D0-B3C6-00A0C90AEA82}#1.0#0"; "MSDATGRD.OCX"
Object = "{C932BA88-4374-101B-A56C-00AA003668DC}#1.1#0"; "msmask32.ocx"
Begin VB.Form frmTask 
   Caption         =   "Work Order"
   ClientHeight    =   6945
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   11220
   LinkTopic       =   "Form2"
   MDIChild        =   -1  'True
   ScaleHeight     =   6945
   ScaleWidth      =   11220
   WindowState     =   2  'Maximized
   Begin VB.CommandButton cmdPrintForm 
      Caption         =   "Print Work Order"
      Height          =   375
      Left            =   7440
      TabIndex        =   46
      Top             =   6000
      Width           =   1335
   End
   Begin VB.Frame FramForm 
      Height          =   5895
      Left            =   360
      TabIndex        =   3
      Top             =   0
      Width           =   8415
      Begin VB.TextBox txtCreatedby 
         Height          =   285
         Left            =   2520
         MaxLength       =   50
         TabIndex        =   12
         Top             =   4440
         Width           =   2655
      End
      Begin VB.TextBox txtWorkDueWhenMeterReads 
         Enabled         =   0   'False
         Height          =   285
         Left            =   2520
         Locked          =   -1  'True
         TabIndex        =   43
         Top             =   4920
         Width           =   1215
      End
      Begin VB.TextBox txtTaskDesc 
         Height          =   285
         Left            =   2520
         MaxLength       =   50
         TabIndex        =   1
         Top             =   840
         Width           =   4695
      End
      Begin VB.TextBox txtIntervalDays 
         BeginProperty DataFormat 
            Type            =   1
            Format          =   "0"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   1033
            SubFormatType   =   1
         EndProperty
         Height          =   285
         Left            =   2520
         TabIndex        =   2
         Top             =   1200
         Width           =   1215
      End
      Begin VB.TextBox txtIntervalMeter 
         BeginProperty DataFormat 
            Type            =   1
            Format          =   "0"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   1033
            SubFormatType   =   1
         EndProperty
         Height          =   285
         Left            =   2520
         TabIndex        =   5
         Top             =   1560
         Width           =   1215
      End
      Begin VB.TextBox txtToolsRequired 
         Height          =   285
         Left            =   2520
         MaxLength       =   50
         TabIndex        =   9
         Top             =   2280
         Width           =   4695
      End
      Begin VB.TextBox txtLastWorkedMeterReading 
         Height          =   285
         Left            =   6000
         TabIndex        =   6
         Top             =   1560
         Width           =   1215
      End
      Begin VB.TextBox txtMiscComments 
         Height          =   1245
         Left            =   2520
         MaxLength       =   255
         MultiLine       =   -1  'True
         TabIndex        =   11
         Top             =   3000
         Width           =   4695
      End
      Begin VB.TextBox txtLoTo 
         Height          =   285
         Left            =   2520
         MaxLength       =   10
         TabIndex        =   10
         Top             =   2640
         Width           =   1215
      End
      Begin VB.ComboBox cboPriority 
         Height          =   315
         ItemData        =   "frmTask.frx":0000
         Left            =   5520
         List            =   "frmTask.frx":000D
         TabIndex        =   8
         Top             =   1920
         Width           =   1695
      End
      Begin VB.ComboBox cboCycleType 
         Height          =   315
         ItemData        =   "frmTask.frx":0024
         Left            =   2520
         List            =   "frmTask.frx":0031
         TabIndex        =   7
         Top             =   1920
         Width           =   2055
      End
      Begin VB.ComboBox cboEquipID 
         Height          =   315
         Left            =   2520
         TabIndex        =   0
         Top             =   480
         Width           =   4695
      End
      Begin VB.TextBox txtCount 
         Alignment       =   2  'Center
         DataField       =   "equip_id"
         DataSource      =   "AdodcMaintenance"
         Enabled         =   0   'False
         ForeColor       =   &H00FF0000&
         Height          =   285
         Left            =   2640
         Locked          =   -1  'True
         TabIndex        =   37
         TabStop         =   0   'False
         Text            =   "1"
         Top             =   0
         Width           =   2895
      End
      Begin MSMask.MaskEdBox txtLastWorkedDate 
         Height          =   255
         Left            =   6000
         TabIndex        =   4
         Top             =   1200
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
      Begin MSMask.MaskEdBox txtWorkDueDate 
         Height          =   255
         Left            =   6000
         TabIndex        =   44
         Top             =   4920
         Width           =   1215
         _ExtentX        =   2143
         _ExtentY        =   450
         _Version        =   393216
         Enabled         =   0   'False
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
      Begin VB.Label lblCreatedby 
         Alignment       =   1  'Right Justify
         Caption         =   "Created by:"
         Height          =   255
         Left            =   1320
         TabIndex        =   45
         Top             =   4440
         Width           =   1095
      End
      Begin VB.Label lblWorkDueWhenMeterReads 
         Alignment       =   1  'Right Justify
         Caption         =   "Work Due When Meter Reads:"
         Height          =   255
         Left            =   120
         TabIndex        =   42
         Top             =   4920
         Width           =   2415
      End
      Begin VB.Label lblWorkDueDate 
         Alignment       =   1  'Right Justify
         Caption         =   "Work Due Date:"
         Height          =   255
         Left            =   4680
         TabIndex        =   41
         Top             =   4920
         Width           =   1215
      End
      Begin VB.Label lblPlantName 
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
         Left            =   0
         TabIndex        =   39
         Top             =   0
         Width           =   2415
      End
      Begin VB.Label lblMiscComments 
         Alignment       =   1  'Right Justify
         Caption         =   "Comments:"
         Height          =   255
         Left            =   1200
         TabIndex        =   35
         Top             =   3000
         Width           =   1215
      End
      Begin VB.Label lblLoTo 
         Alignment       =   1  'Right Justify
         Caption         =   "Lockout/Tagout:"
         Height          =   255
         Left            =   1320
         TabIndex        =   34
         Top             =   2640
         Width           =   1215
      End
      Begin VB.Label lblLastWorkedDate 
         Alignment       =   1  'Right Justify
         Caption         =   "Last Worked Date:"
         Height          =   255
         Left            =   4440
         TabIndex        =   33
         Top             =   1200
         Width           =   1455
      End
      Begin VB.Label lblLastWorkedMeterReading 
         Alignment       =   1  'Right Justify
         Caption         =   "Last Worked Meter Reading:"
         Height          =   255
         Left            =   3840
         TabIndex        =   32
         Top             =   1560
         Width           =   2055
      End
      Begin VB.Label lblToolsRequired 
         Alignment       =   1  'Right Justify
         Caption         =   "Tools Required:"
         Height          =   255
         Left            =   1200
         TabIndex        =   31
         Top             =   2280
         Width           =   1215
      End
      Begin VB.Label lblIntervalMeter 
         Alignment       =   1  'Right Justify
         Caption         =   "Interval Meter:"
         Height          =   255
         Left            =   1320
         TabIndex        =   30
         Top             =   1560
         Width           =   1095
      End
      Begin VB.Label lblIntervalDays 
         Alignment       =   1  'Right Justify
         Caption         =   "Interval Days:"
         Height          =   255
         Left            =   1440
         TabIndex        =   29
         Top             =   1200
         Width           =   975
      End
      Begin VB.Label lblCycleType 
         Alignment       =   1  'Right Justify
         Caption         =   "Cycle Type:"
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
         Left            =   1080
         TabIndex        =   28
         Top             =   1920
         Width           =   1335
      End
      Begin VB.Label lblPriority 
         Alignment       =   1  'Right Justify
         Caption         =   "Priority:"
         Height          =   255
         Left            =   4800
         TabIndex        =   27
         Top             =   1920
         Width           =   615
      End
      Begin VB.Label lblTaskDesc 
         Alignment       =   1  'Right Justify
         Caption         =   "Work Order Description:"
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
         Left            =   120
         TabIndex        =   26
         Top             =   840
         Width           =   2295
      End
      Begin VB.Label lblEquip 
         Alignment       =   1  'Right Justify
         Caption         =   "Equipment:"
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
         Left            =   1200
         TabIndex        =   25
         Top             =   480
         Width           =   1215
      End
   End
   Begin VB.Frame FramGrid 
      Height          =   5895
      Left            =   480
      TabIndex        =   36
      Top             =   0
      Width           =   10575
      Begin MSDataGridLib.DataGrid DGridTask 
         Height          =   5535
         Left            =   120
         TabIndex        =   38
         Top             =   240
         Width           =   10335
         _ExtentX        =   18230
         _ExtentY        =   9763
         _Version        =   393216
         AllowUpdate     =   0   'False
         HeadLines       =   1
         RowHeight       =   15
         BeginProperty HeadFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         BeginProperty Font {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ColumnCount     =   2
         BeginProperty Column00 
            DataField       =   ""
            Caption         =   ""
            BeginProperty DataFormat {6D835690-900B-11D0-9484-00A0C91110ED} 
               Type            =   0
               Format          =   ""
               HaveTrueFalseNull=   0
               FirstDayOfWeek  =   0
               FirstWeekOfYear =   0
               LCID            =   1033
               SubFormatType   =   0
            EndProperty
         EndProperty
         BeginProperty Column01 
            DataField       =   ""
            Caption         =   ""
            BeginProperty DataFormat {6D835690-900B-11D0-9484-00A0C91110ED} 
               Type            =   0
               Format          =   ""
               HaveTrueFalseNull=   0
               FirstDayOfWeek  =   0
               FirstWeekOfYear =   0
               LCID            =   1033
               SubFormatType   =   0
            EndProperty
         EndProperty
         SplitCount      =   1
         BeginProperty Split0 
            BeginProperty Column00 
            EndProperty
            BeginProperty Column01 
            EndProperty
         EndProperty
      End
      Begin VB.Label lblPlantNameG 
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
         Left            =   0
         TabIndex        =   40
         Top             =   0
         Width           =   1695
      End
   End
   Begin VB.Label Label12 
      Caption         =   "Label12"
      Height          =   495
      Left            =   4680
      TabIndex        =   24
      Top             =   3240
      Width           =   1215
   End
   Begin VB.Label Label11 
      Caption         =   "Label11"
      Height          =   495
      Left            =   4680
      TabIndex        =   23
      Top             =   3240
      Width           =   1215
   End
   Begin VB.Label Label10 
      Caption         =   "Label10"
      Height          =   495
      Left            =   4680
      TabIndex        =   22
      Top             =   3240
      Width           =   1215
   End
   Begin VB.Label Label9 
      Caption         =   "Label9"
      Height          =   495
      Left            =   4680
      TabIndex        =   21
      Top             =   3240
      Width           =   1215
   End
   Begin VB.Label Label8 
      Caption         =   "Label8"
      Height          =   495
      Left            =   4680
      TabIndex        =   20
      Top             =   3240
      Width           =   1215
   End
   Begin VB.Label Label7 
      Caption         =   "Label7"
      Height          =   495
      Left            =   4680
      TabIndex        =   19
      Top             =   3240
      Width           =   1215
   End
   Begin VB.Label Label6 
      Caption         =   "Label6"
      Height          =   495
      Left            =   4680
      TabIndex        =   18
      Top             =   3240
      Width           =   1215
   End
   Begin VB.Label Label5 
      Caption         =   "Label5"
      Height          =   495
      Left            =   4680
      TabIndex        =   17
      Top             =   3240
      Width           =   1215
   End
   Begin VB.Label Label4 
      Caption         =   "Label4"
      Height          =   495
      Left            =   4680
      TabIndex        =   16
      Top             =   3240
      Width           =   1215
   End
   Begin VB.Label Label3 
      Caption         =   "Label3"
      Height          =   495
      Left            =   4680
      TabIndex        =   15
      Top             =   3240
      Width           =   1215
   End
   Begin VB.Label Label2 
      Caption         =   "Label2"
      Height          =   495
      Left            =   4680
      TabIndex        =   14
      Top             =   3240
      Width           =   1215
   End
   Begin VB.Label Label1 
      Caption         =   "Label1"
      Height          =   495
      Left            =   4680
      TabIndex        =   13
      Top             =   3240
      Width           =   1215
   End
End
Attribute VB_Name = "frmTask"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim rsTaskRetrieve As ADODB.Recordset
Dim rsListEquip As ADODB.Recordset
Dim intStatus As Integer ' 2 - add, 1 - update
Dim ans As Integer
Dim strCycleTypeStore, strEquipIDStore, strPriorityStore As String
Dim intEquipIDStore As Integer
Dim intUpdateEquipID As Integer

Dim strPrintOpt, strPrintDate, strPrintEquipKey, strPrintMiscComments As String
Dim intPrintEquip, intPrintTask


Private intUpdate As Integer ' used to update History if equipment changed in Work Order(Task) screen

Public Sub CheckChange()
    ' This will check if value on any field has been changed before
    ' moving to new window
    If intStatus = 2 Then
        ans = MsgBox("Do you want to save the new record?", vbYesNo)
        If ans = 6 Then
            Save
        End If
        ans = 0
    Else
        ChangedData
    End If

End Sub

Public Sub PrintReports()

'
' Opens the DataEnvironment's connection object
' Asks detail or summary report and opens report,
' which can then be printed
'

    Dim intReportAns As Integer
    intPrintTask = 0
    intPrintEquip = 0
    
On Error GoTo errorhandler

    DEnvWos.conWOS.Open
    DEnvWos.comTaskList intPrintEquip, intPrintTask, intPlantPass, strPrintOpt, strPrintDate, strPrintEquipKey, strPrintMiscComments
    intReportAns = MsgBox("Please click YES for detail report, and NO for summarized.", vbYesNo)
    If intReportAns = 6 Then
        DRptTaskList.Show (1)
        DRptTaskList.Top = 1100
        DRptTaskList.Left = 1
        DRptTaskList.Height = 6400
        DRptTaskList.Width = 9300
    Else
        DRptTaskSum.Show (1)
        DRptTaskSum.Top = 1100
        DRptTaskSum.Left = 1
        DRptTaskSum.Height = 6400
        DRptTaskSum.Width = 9300
    End If

Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - PrintReports: Description - " & Err.Description
End Sub

Public Sub SearchRec()

'
' frmSearchTask is opened for entering criteria
'

On Error GoTo errorhandler

    frmSearchTask.Show (1)
Exit Sub

errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - SearchRec: Description - " & Err.Description
End Sub

Public Function FindRecords(ByVal strOption As String, ByVal strEquipKey As String, ByVal strEquipID As String, ByVal strTaskID As String, ByVal strDate As String, ByVal strMiscComments As String, ByVal intRetrievalType As Integer) As Integer

' Takes all the search criteria from search form
' last argument - 1 for checking and 2- for retrieving
'
' Returns 1 - if successful and 0 - if not
'
' This is the function called twice from search form -
' Once to chekc if there are records and then to create sql for new recordset and
' also to store values if user decides to print the retrived recordset
'
    Dim strInitialString, strSQL, strEquipment As String
    Dim rsCheck As ADODB.Recordset

On Error GoTo errorhandler
    ' intRetrievalType is used to know if it is just a check or we need to refresh the window
    strInitialString = ""
    If strEquipKey <> "" Then
        strInitialString = " equip_key = '" & Trim(strEquipKey) & "' "
    End If
    If strEquipID <> "" Then
        If strInitialString <> "" Then
            strInitialString = strInitialString & " and task.equip_id = " & Trim(strEquipID)
        Else
            strInitialString = " task.equip_id = " & Trim(strEquipID)
        End If
    End If
    If strTaskID <> "" Then
        If strInitialString <> "" Then
            strInitialString = strInitialString & " and task.task_id = " & Trim(strTaskID)
        Else
            strInitialString = " task.task_id = " & Trim(strTaskID)
        End If
    End If
    If strDate <> "" Then
        If strInitialString <> "" Then
            strInitialString = strInitialString & " and work_due_date <= datevalue('" & Trim(strDate) & "') "
        Else
            strInitialString = " work_due_date <= datevalue('" & Trim(strDate) & "') "
        End If
    End If
    If strMiscComments <> "" Then
        If strInitialString <> "" Then
            strInitialString = strInitialString & " and misc_comments like '%" & Trim(strMiscComments) & "%' "
        Else
            strInitialString = " misc_comments like '%" & Trim(strMiscComments) & "%' "
        End If
    End If
    
    Select Case strOption
    Case "DueDate"
        If intRetrievalType = 2 Then
            strPrintOpt = "DueDate"
            strPrintDate = strDate
            If strEquipKey <> "" Then
                strPrintEquipKey = strEquipKey
            Else
                strPrintEquipKey = "XXXXXXXXXXX"
            End If
            If strEquipID <> "" Then
                intPrintEquip = CInt(strEquipID)
            Else
                intPrintEquip = 0
            End If
            If strTaskID <> "" Then
                intPrintTask = CInt(strTaskID)
            Else
                intPrintTask = 0
            End If
            If strMiscComments <> "" Then
                strPrintMiscComments = strMiscComments
            Else
                strPrintMiscComments = "XXXXXXXXXXX"
            End If
        End If
        If intPlantPass <> 0 Then
            strSQL = "SELECT task.*, equipment.equip_key from equipment inner join task on task.equip_id = equipment.equip_id where task.plant_fk = " & intPlantPass & " and " & strInitialString
        Else
            strSQL = "SELECT task.*, equipment.equip_key from equipment inner join task on task.equip_id = equipment.equip_id where " & strInitialString
        End If
    Case "DueMeter"
        If intRetrievalType = 2 Then
            strPrintOpt = "DueMeter"
            strPrintDate = "01/01/1955"
            If strEquipKey <> "" Then
                strPrintEquipKey = strEquipKey
            Else
                strPrintEquipKey = "XXXXXXXXXXX"
            End If
                        If strEquipID <> "" Then
                intPrintEquip = CInt(strEquipID)
            Else
                intPrintEquip = 0
            End If
            If strTaskID <> "" Then
                intPrintTask = CInt(strTaskID)
            Else
                intPrintTask = 0
            End If
            If strMiscComments <> "" Then
                strPrintMiscComments = strMiscComments
            Else
                strPrintMiscComments = "XXXXXXXXXXX"
            End If
        End If
        If intPlantPass <> 0 Then
            If strInitialString <> "" Then
                strSQL = "SELECT task.*, equipment.last_meter_reading, equipment.last_meter_reading_date from equipment inner join task on task.equip_id = equipment.equip_id where work_due_when_meter_reads < last_meter_reading and task.plant_fk = " & intPlantPass & " and " & strInitialString
            Else
                strSQL = "SELECT task.*, equipment.last_meter_reading, equipment.last_meter_reading_date from equipment inner join task on task.equip_id = equipment.equip_id where work_due_when_meter_reads < last_meter_reading and task.plant_fk = " & intPlantPass
            End If
        Else
            If strInitialString <> "" Then
                strSQL = "SELECT task.*, equipment.last_meter_reading, equipment.last_meter_reading_date from equipment inner join task on task.equip_id = equipment.equip_id where work_due_when_meter_reads < last_meter_reading and " & strInitialString
            Else
                strSQL = "SELECT task.*, equipment.last_meter_reading, equipment.last_meter_reading_date from equipment inner join task on task.equip_id = equipment.equip_id where work_due_when_meter_reads < last_meter_reading "
            End If
        End If
    Case "Unscheduled"
        If intRetrievalType = 2 Then
            strPrintOpt = "Unschedule"
            strPrintDate = "01/01/1955"
            If strEquipKey <> "" Then
                strPrintEquipKey = strEquipKey
            Else
                strPrintEquipKey = "XXXXXXXXXXX"
            End If
                        If strEquipID <> "" Then
                intPrintEquip = CInt(strEquipID)
            Else
                intPrintEquip = 0
            End If
            If strTaskID <> "" Then
                intPrintTask = CInt(strTaskID)
            Else
                intPrintTask = 0
            End If
            If strMiscComments <> "" Then
                strPrintMiscComments = strMiscComments
            Else
                strPrintMiscComments = "XXXXXXXXXXX"
            End If
        End If
        If intPlantPass <> 0 Then
            If strInitialString <> "" Then
                strSQL = "SELECT task.* from equipment inner join task on task.equip_id = equipment.equip_id where cycle_type = 'Unschedule' and task.plant_fk = " & intPlantPass & " and " & strInitialString
            Else
                strSQL = "SELECT task.* from equipment inner join task on task.equip_id = equipment.equip_id where cycle_type = 'Unschedule' and task.plant_fk = " & intPlantPass
            End If
        Else
            If strInitialString <> "" Then
                strSQL = "SELECT task.* from equipment inner join task on task.equip_id = equipment.equip_id where cycle_type = 'Unschedule' and " & strInitialString
            Else
                strSQL = "SELECT task.* from equipment inner join task on task.equip_id = equipment.equip_id where cycle_type = 'Unschedule' "
            End If
        End If
    Case "All"
        If intRetrievalType = 2 Then
            strPrintOpt = "All"
            strPrintDate = "01/01/1955"
            If strEquipKey <> "" Then
                strPrintEquipKey = strEquipKey
            Else
                strPrintEquipKey = "XXXXXXXXXXX"
            End If
                        If strEquipID <> "" Then
                intPrintEquip = CInt(strEquipID)
            Else
                intPrintEquip = 0
            End If
            If strTaskID <> "" Then
                intPrintTask = CInt(strTaskID)
            Else
                intPrintTask = 0
            End If
            If strMiscComments <> "" Then
                strPrintMiscComments = strMiscComments
            Else
                strPrintMiscComments = "XXXXXXXXXXX"
            End If
        End If
        If strInitialString <> "" Then
            If intPlantPass <> 0 Then
                strSQL = "SELECT task.* from equipment inner join task on task.equip_id = equipment.equip_id where task.plant_fk = " & intPlantPass & " and " & strInitialString
            Else
                strSQL = "SELECT task.* from equipment inner join task on task.equip_id = equipment.equip_id where " & strInitialString
            End If
        Else
            If intPlantPass <> 0 Then
                strSQL = "SELECT * from task where task.plant_fk = " & intPlantPass
            Else
                strSQL = "SELECT * from task where plant_fk <> 0"
            End If
        End If
    End Select
    If intRetrievalType = 1 Then
        ' Just checking if there are records
        Set rsCheck = RecordsetTask(strSQL)
        If rsCheck.EOF = True Or rsCheck.BOF = True Then
            FindRecords = 0
            Set rsCheck = Nothing
            Exit Function
        Else
            rsCheck.MoveFirst
            rsCheck.MoveLast
            If rsCheck.RecordCount > 0 Then
                FindRecords = 1
                Set rsCheck = Nothing
                Exit Function
            End If
        End If
    Else
        ' retrieving records
        ' first setting the existing recordset to nothing
        Set rsTaskRetrieve = Nothing
        Set rsListEquip = Nothing
        Set rsTaskRetrieve = RecordsetTask(strSQL)
        rsTaskRetrieve.MoveLast
        rsTaskRetrieve.MoveFirst
        If intPlantPass = 0 Then
            strEquipment = "select plant_fk, equip_id, equip_desc, last_meter_reading, last_meter_reading_date from equipment where equip_id <> 0"
        Else
            strEquipment = "select plant_fk, equip_id, equip_desc, last_meter_reading, last_meter_reading_date from equipment where plant_fk = " & intPlantPass
        End If
        Set rsListEquip = EquipList(strEquipment)
        cboEquipID.Clear
        Do While Not rsListEquip.EOF
            cboEquipID.AddItem rsListEquip!equip_id & " - " & rsListEquip!equip_desc
            rsListEquip.MoveNext
        Loop
        rsListEquip.MoveFirst
        
        FillFields
            
        SetGrid
    End If
Exit Function
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - FindRecords: Description - " & Err.Description
End Function

Public Function CheckRecordset() As Integer
    
'
' this function is used only to find out
' if there is recordset to work on before
' opening the form
'
    Dim strSQL As String
    
On Error GoTo errorhandler
    
    If strPlantPass = "All Plants" Then
        strSQL = "select * from task where task_id <> 0"
    Else
        strSQL = "select * from task where plant_fk = " & intPlantPass
    End If
    
    Set rsTaskRetrieve = RecordsetTask(strSQL)
    
    If rsTaskRetrieve.EOF = True Or rsTaskRetrieve.BOF = True Then
        CheckRecordset = 2
        Exit Function
    Else
        CheckRecordset = 1
    End If
    Set rsTaskRetrieve = Nothing
Exit Function
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - CheckRecordset: Description - " & Err.Description
End Function

Public Sub FormView()

On Error GoTo errorhandler

    FramGrid.Visible = False
    FramForm.Visible = True
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - FormView: Description - " & Err.Description
End Sub

Public Sub GridView()

On Error GoTo errorhandler

    FramForm.Visible = False
    FramGrid.Visible = True
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - GridView: Description - " & Err.Description
End Sub

Public Sub Add()

'
' intStatus  = 2 is set so that in AddUpdateTask function
' this variable is used to find out if the record is a add
' or update
'

On Error GoTo errorhandler

    Clear
    intStatus = 2
    txtCount = "New Record"
    FormView
    MDIFormWOS.AddMode
    If intTypeTask <> 1 Then
        intTypeTask = 2
        Me.cboEquipID.SetFocus
    End If
    Me.lblPlantName.Caption = intPlantPass & " - " & strPlantPass
    Me.lblPlantNameG.Caption = intPlantPass & " - " & strPlantPass
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - Add: Description - " & Err.Description
End Sub

Public Sub Cancel()

On Error GoTo errorhandler

'
' Unload and reload
'
    Unload Me
    frmPlant.CheckAll "task"
    'frmTask.Show
    'If CheckRecordset = 2 Then
    '    MDIFormWOS.AddMode
    'End If
    'frmTask.SetFocus
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - Cancel: Description - " & Err.Description
End Sub

Public Sub Clear()

'
' Check if any field has been modified and if changed then save
' otherwise clear all the fields on the form
'

On Error GoTo errorhandler
    
    If intTypeTask <> 1 Then
        ChangedData
    End If
    cboEquipID.Text = ""
    txtTaskDesc.Text = ""
    cboPriority.Text = ""
    cboCycleType.Text = ""
    txtIntervalDays.Text = ""
    txtLastWorkedDate.Text = ""
    txtIntervalMeter.Text = ""
    txtLastWorkedMeterReading.Text = ""
    txtToolsRequired.Text = ""
    txtCreatedby.Text = ""
    txtMiscComments.Text = ""
    txtLoTo.Text = ""
    txtWorkDueWhenMeterReads.Text = ""
    txtWorkDueDate.Text = ""
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - Clear: Description - " & Err.Description
End Sub

'Public Sub Delete()
'    ans = 0
'    FormView
'    ans = MsgBox("Are you sure that you want to delete this record?", vbYesNo, "WOS")
'    If ans = 6 Then
'        rsTaskRetrieve.Delete
'        rsTaskRetrieve.MoveNext
'        If rsTaskRetrieve.EOF Then
'            rsTaskRetrieve.MovePrevious
'        End If
'        FillFields
'    End If
'End Sub

Public Sub RefreshRec()

'
' Unload and reload
'

On Error GoTo errorhandler

    Unload Me
    frmPlant.CheckAll "task"
    'frmTask.Show
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - RefreshRec: Description - " & Err.Description
End Sub

Public Sub Save()

' when one clicks add only the fields are cleared
' but there may not be a recordset to add to
' so if there is no recordset then new recordset is created
' Once there is a recordset then AddUpdateTask is called to add the record
'

    Dim strSQL As String
    Dim strAdd As String
    Dim rsUpdate As ADODB.Recordset
    
    Dim intResult As Integer
    
On Error GoTo errorhandler
    
    FormView
    intResult = ValidateTask
    If intResult = 0 Then
        If intTypeTask = 1 Then
            strAdd = "SELECT * from task where plant_fk <> 0"
            Set rsTaskRetrieve = RecordsetTask(strAdd)
            rsTaskRetrieve.AddNew
            intTypeTask = 0
        ElseIf intTypeTask = 2 Then
            rsTaskRetrieve.AddNew
            intTypeTask = 0
        End If
        AddUpdateTask
        If intUpdate = 1 Then
            Dim intPlant As Integer
            rsListEquip.MoveFirst
            rsListEquip.Find ("equip_id = " & intUpdateEquipID)
            intPlant = rsListEquip!plant_fk
            strSQL = "Update work_order set plant_fk = " & Str(intPlant) & " and equip_id = " & Str(intUpdateEquipID) & " where task_id = " & rsTaskRetrieve!task_id
            Set rsUpdate = RecordsetTask(strSQL)
            Set rsUpdate = Nothing
        End If
        If intStatus = 2 Then
            Cancel
        End If
        intStatus = 0
        'MDIFormWOS.cmdAdd.Enabled = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - Save: Description - " & Err.Description
End Sub

Public Sub AddUpdateTask()
    Dim intPos As Integer
    Dim strNum As String
    Dim intNum As Integer
    Dim intLen As Integer
    Dim strEquipID As String
    
    Dim intPlant As Integer
    
    Dim dtLastWorked, dtDueDate As Date
    Dim strDueDate As String
    Dim intIntervalDays As Integer
    
On Error GoTo errorhandler

    If intStatus = 2 Then
        'rsTaskRetrieve.AddNew
    Else
        rsTaskRetrieve.Update
    End If
    
    strEquipID = cboEquipID.Text
    strEquipID = Trim(strEquipID)
    intLen = Len(strEquipID)
    intPos = InStr(strEquipID, " - ")
    
    If intPos = 0 Then
        strNum = strEquipID
    Else
        strNum = Left(strEquipID, intPos - 1)
    End If

    'intNum = CInt(strNum)
    
    
    rsTaskRetrieve!equip_id = strNum
    
    rsListEquip.Find ("equip_id = " & rsTaskRetrieve!equip_id)
    intPlant = rsListEquip!plant_fk
    rsTaskRetrieve!plant_fk = intPlant
    
    rsTaskRetrieve!task_desc = txtTaskDesc.Text
    rsTaskRetrieve!priority = cboPriority.Text
    rsTaskRetrieve!cycle_type = cboCycleType.Text
    If txtIntervalDays.Text <> "" Then
        rsTaskRetrieve!interval_days = txtIntervalDays.Text
    Else
        rsTaskRetrieve!interval_days = Null
    End If
    If txtLastWorkedDate.Text <> "" Then
        rsTaskRetrieve!last_worked_date = txtLastWorkedDate.Text
    Else
        rsTaskRetrieve!last_worked_date = Null
    End If
    If txtIntervalMeter.Text <> "" Then
        rsTaskRetrieve!interval_meter = txtIntervalMeter.Text
    Else
        rsTaskRetrieve!interval_meter = Null
    End If
    If txtLastWorkedMeterReading.Text <> "" Then
        rsTaskRetrieve!last_worked_meter_reading = txtLastWorkedMeterReading.Text
    Else
        rsTaskRetrieve!last_worked_meter_reading = Null
    End If
    rsTaskRetrieve!tools_required = txtToolsRequired.Text
    If txtLastWorkedMeterReading.Text <> "" Then
        rsTaskRetrieve!last_worked_meter_reading = txtLastWorkedMeterReading.Text
    Else
        rsTaskRetrieve!last_worked_meter_reading = Null
    End If
    If txtLastWorkedDate.Text <> "" Then
        rsTaskRetrieve!last_worked_date = txtLastWorkedDate.Text
    Else
        rsTaskRetrieve!last_worked_date = Null
    End If
    rsTaskRetrieve!misc_comments = txtMiscComments.Text
    rsTaskRetrieve!lo_to = txtLoTo.Text
    rsTaskRetrieve!created_by = txtCreatedby.Text

    Select Case cboCycleType.Text
    Case "Days Cycle"
        dtLastWorked = Format(txtLastWorkedDate.Text, "mm/dd/yy")
        intIntervalDays = txtIntervalDays.Text
        dtDueDate = DateAdd("d", intIntervalDays, dtLastWorked)
        txtWorkDueDate.Text = dtDueDate
    Case "Meter Cycle"
        txtWorkDueWhenMeterReads.Text = CLng(txtIntervalMeter.Text) + CLng(txtLastWorkedMeterReading.Text)
    Case "Unschedule"
        Me.txtWorkDueDate.Text = ""
        Me.txtWorkDueWhenMeterReads.Text = ""
    End Select
        
    If txtWorkDueWhenMeterReads.Text <> "" Then
        rsTaskRetrieve!work_due_when_meter_reads = Me.txtWorkDueWhenMeterReads.Text
    Else
        rsTaskRetrieve!work_due_when_meter_reads = Null
    End If
    If txtWorkDueDate.Text <> "" Then
        rsTaskRetrieve!work_due_date = Me.txtWorkDueDate
    Else
        rsTaskRetrieve!work_due_date = Null
    End If
    
    
    rsTaskRetrieve.MoveNext
    rsTaskRetrieve.MovePrevious
    
    If intStatus = 2 Then
        ans = MsgBox("New Work Order: " & txtTaskDesc.Text & " has been added.", vbOKOnly, "WOS")
    Else
        ans = MsgBox("The record has been updated.", vbOKOnly, "WOS")
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - AddUpdateTask: Description - " & Err.Description
End Sub

Private Sub cboCycleType_GotFocus()

On Error GoTo errorhandler

    strCycleTypeStore = ""
    strCycleTypeStore = cboCycleType.Text
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - cboCycleType_GotFocus: Description - " & Err.Description
End Sub

Private Sub cboCycleType_KeyDown(KeyCode As Integer, Shift As Integer)
    Dim ans As Integer
    
On Error GoTo errorhandler

    ans = 0
    ans = MsgBox("Can not edit. Have to select from the list provided.")
    cboCycleType.Text = strCycleTypeStore
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - cboCycleType_KeyDown: Description - " & Err.Description
End Sub

Private Sub cboCycleType_LostFocus()

On Error GoTo errorhandler

    strCycleTypeStore = ""
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - cboCycleType_LostFocus: Description - " & Err.Description
End Sub

Private Sub cboCycleType_Validate(Cancel As Boolean)
    Dim intLen As Integer
    Dim ans As Integer
    
    Dim dtLastWorkedDate, dtDueDate As Date
    Dim intIntervalDays As Long 'Integer
    
On Error GoTo errorhandler

    intLen = Len(cboCycleType.Text)
    If intLen = 0 Then
        Beep
        ans = MsgBox("The CYCLE TYPE field is a required field.", vbOKOnly, "WOS")
        Cancel = True
    End If
    
    If strCycleTypeStore <> cboCycleType.Text Then
        Select Case Trim(cboCycleType.Text)
            Case "Unschedule"
                ans = MsgBox("If you create an unsheduled Work Order, it will not be cycled. Are you sure you want to unschedule this Work Order?", vbYesNo)
                If ans = 6 Then
                    ' continue with the change
                Else
                    If strCycleTypeStore <> "" Then
                        cboCycleType.Text = strCycleTypeStore
                    Else
                        cboCycleType.Text = ""
                    End If
                    Cancel = True
                End If
            Case "Meter Cycle"
                If (Len(txtIntervalMeter.Text) = 0) Or (Len(txtLastWorkedMeterReading.Text) = 0) Then
                    ans = MsgBox("Can not change to METER CYCLE before entering INTERVAL METER and LAST WORKED METER READING.")
                    cboCycleType.Text = strCycleTypeStore
                    Cancel = False
                Else
                    'Dim intNum, intLen2, intPos As Integer
                    'Dim strNum As String
                    'strNum = cboEquipID.Text
                    'strNum = Trim(strNum)
                    'intPos = InStr(strNum, " - ")
                    'If intPos > 0 Then
                    '    strNum = Left(strNum, intPos - 1)
                    'End If
                    'intNum = CInt(strNum)
                    
                    'rsListEquip.MoveFirst
                    'rsListEquip.Find ("equip_id = " & intNum)
                    'If rsListEquip!last_meter_reading < 1 Then
                    '    MsgBox "Can not create meter cycle for this equipment because there is no current meter for the equipment. Please enter met"
                    ' ******** Do we let them create meter cycle for the equipment with no meter reading ????
                    txtWorkDueWhenMeterReads.Text = CLng(txtLastWorkedMeterReading.Text) + CLng(txtIntervalMeter.Text)
                End If
            Case "Days Cycle"
                If (Len(txtIntervalDays.Text) = 0) Or (Len(txtLastWorkedDate.Text) = 0) Then
                    ans = MsgBox("Can not change to DAYS CYCLE before entering INTERVAL DAYS and LAST WORKED DATE.")
                    cboCycleType.Text = strCycleTypeStore
                    Cancel = False
                Else

                    ' get the due date
                    ' txtworkduedate.Text = txt
                    dtLastWorkedDate = txtLastWorkedDate.Text
                    intIntervalDays = txtIntervalDays.Text
                    dtDueDate = DateAdd("d", intIntervalDays, dtLastWorkedDate)
                    Me.txtWorkDueDate.Text = Format(dtDueDate, "mm/dd/yy")
                End If
        End Select
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - cboCycleType_Validate: Description - " & Err.Description
End Sub

'Private Sub cboEquipID_GotFocus()
'    Dim intLen, intPos As Integer
'
'    intEquipIDStore = 0
'    strEquipIDStore = ""
'    strEquipIDStore = cboEquipID.Text
'    If strEquipIDStore <> "" Then
'        strEquipIDStore = Trim(strEquipIDStore)
'        intLen = Len(strEquipIDStore)
'        intPos = InStr(strEquipIDStore, " - ")
'        If intPos > 0 Then
'            strEquipIDStore = Left(strEquipIDStore, intPos - 1)
'        End If
'        intEquipIDStore = CInt(strEquipIDStore)
'    End If
'End Sub

Private Sub cboEquipID_KeyUp(KeyCode As Integer, Shift As Integer)
    Dim intKey As Integer
    Dim intValue As Integer

On Error GoTo errorhandler

    intKey = KeyCode
    If intKey < 48 Or intKey > 57 Then
        MsgBox "This field can only have numbers"
        If intEquipIDStore <> 0 Then
            Me.cboEquipID.Text = intEquipIDStore
        End If
    End If
    If intStatus <> 2 Then
        MsgBox "Value can not be changed after a Work Order is created and saved"
        If intEquipIDStore <> 0 Then
            Me.cboEquipID.Text = intEquipIDStore
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - cboEquipID_KeyUp: Description - " & Err.Description
End Sub

Private Sub cboEquipID_LostFocus()

On Error GoTo errorhandler

    strEquipIDStore = ""
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - cboEquipID_LostFocus: Description - " & Err.Description
End Sub

Private Sub cboEquipID_Validate(Cancel As Boolean)
    Dim intLen2, intPos As Integer
    Dim intEquipID As Integer
    Dim strEquipID As String
    Dim intLen As Integer
    Dim ans As Integer
    
On Error GoTo errorhandler

    intLen = Len(cboEquipID.Text)
    If intLen = 0 Then
        Beep
        ans = MsgBox("The EQUIPMENT field is a required field.", vbOKOnly, "WOS")
        Cancel = True
    Else
        strEquipID = cboEquipID.Text
        strEquipID = Trim(strEquipID)
        intLen2 = Len(strEquipID)
        intPos = InStr(strEquipID, " - ")
        If intPos > 0 Then
            strEquipID = Left(strEquipID, intPos - 1)
        End If
        intEquipID = CInt(strEquipID)
        rsListEquip.MoveFirst
        rsListEquip.Find ("equip_id = " & intEquipID)
        If rsListEquip.EOF = True Or rsListEquip.BOF = True Then
            MsgBox "The equipment you entered was not found in the dropdown."
            Cancel = True
            If strEquipIDStore <> "" Then
                Me.cboEquipID.Text = strEquipIDStore
            Else
                Me.cboEquipID.Text = ""
            End If
        Else
            If intEquipID <> intEquipIDStore And intEquipIDStore <> 0 Then
                If intStatus <> 2 Then
                    MsgBox "Value can not be changed after a Work Order is created and saved"
                    Me.cboEquipID.Text = intEquipIDStore
                End If
                'ans = MsgBox("Are you sure that you want to change equipment. If there are history records for this Work Order, then those recordss will have new equipment assigned.", vbYesNo)
                'If ans = 6 Then
                '    intUpdate = 1
                '    intUpdateEquipID = intEquipID
                'Else
                    ' do not change the value and go to next control
                '    cboEquipID.Text = strEquipIDStore
                'End If
            End If
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - cboEquipID_Validate: Description - " & Err.Description
End Sub

Private Sub cboPriority_GotFocus()

On Error GoTo errorhandler

    strPriorityStore = ""
    strPriorityStore = cboPriority.Text
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - cboPriority_GotFocus: Description - " & Err.Description
End Sub

Private Sub cboPriority_KeyDown(KeyCode As Integer, Shift As Integer)
    Dim ans As Integer
    
On Error GoTo errorhandler

    ans = 0
    ans = MsgBox("Can not edit. Have to select from the list provided.")
    cboPriority.Text = strPriorityStore
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - cboPriority_KeyDown: Description - " & Err.Description
End Sub

Private Sub cboPriority_LostFocus()
    strPriorityStore = ""
End Sub

Private Sub cmdPrintForm_Click()

On Error GoTo errorhandler
    PrintForm
Exit Sub
errorhandler:
    MsgBox "Unable to print to this default printer. Please check that you have a default printer set up correctly.", vbExclamation, "Print Form Error"
End Sub

Private Sub DGridTask_RowColChange(LastRow As Variant, ByVal LastCol As Integer)
    
On Error GoTo errorhandler

    If FramGrid.Visible = True Then
        FillFields
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - DGridTask_RowColChange: Description - " & Err.Description
End Sub

Private Sub Form_Activate()

On Error GoTo errorhandler
    'If CheckRecordset = 1 Then
    MDIFormWOS.FindActive (False)
    If intTypeTask = 1 Then
        MDIFormWOS.cmdSearch.Enabled = False
        MDIFormWOS.cmdPrint.Enabled = False
    Else
        MDIFormWOS.cmdSearch.Enabled = True
        MDIFormWOS.cmdPrint.Enabled = True
    End If
    'End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - Form_Activate: Description - " & Err.Description
End Sub

Private Sub Form_Click()
    ' Do nothing
End Sub

Public Sub FirstRec()

On Error GoTo errorhandler

    ChangedData
    rsTaskRetrieve.MoveFirst
    FillFields
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - FirstRec: Description - " & Err.Description
End Sub

Public Sub LastRec()

On Error GoTo errorhandler

    ChangedData
    rsTaskRetrieve.MoveLast
    FillFields
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - LastRec: Description - " & Err.Description
End Sub

Public Sub NextRec()

On Error GoTo errorhandler

    ChangedData
    rsTaskRetrieve.MoveNext
    If rsTaskRetrieve.EOF Then
        rsTaskRetrieve.MovePrevious
        ans = MsgBox("Already at the end of the list. Can not move any further.")
    End If
    FillFields
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - NextRec: Description - " & Err.Description
End Sub

Public Sub PrevRec()

On Error GoTo errorhandler

    ChangedData
    rsTaskRetrieve.MovePrevious
    If rsTaskRetrieve.BOF Then
        rsTaskRetrieve.MoveNext
        ans = MsgBox("Already at the beginning of the list. Can not move back any more.")
    End If
    FillFields
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - PrevRec: Description - " & Err.Description
End Sub

Public Function FormLoadType()

    Dim ans As Integer
    Dim strSQL, strEquip As String
    Dim strCurType As String
    
On Error GoTo errorhandler

    FormView
    If CheckRecordset = 2 Then
        intTypeTask = 1
        Add
        If strPlantPass = "All Plants" Then
            strEquip = "select plant_fk,equip_id, equip_desc, last_meter_reading, last_meter_reading_date from equipment where equip_id <> 0"
        Else
            strEquip = "select plant_fk,equip_id, equip_desc, last_meter_reading, last_meter_reading_date from equipment where plant_fk = " & intPlantPass
        End If
        
        Set rsListEquip = EquipList(strEquip)
        cboEquipID.Clear
        Do While Not rsListEquip.EOF
            cboEquipID.AddItem rsListEquip!equip_id & " - " & rsListEquip!equip_desc
            rsListEquip.MoveNext
        Loop
        rsListEquip.MoveFirst
    Else
        If strPlantPass = "All Plants" Then
            strSQL = "select DISTINCT t.task_id, t.plant_fk, t.equip_id, e.equip_desc, t.task_desc, t.priority, t.cycle_type, t.interval_days, t.interval_meter, t.tools_required,t.lo_to,t.last_worked_meter_reading,t.last_worked_date, t.created_by, t.misc_comments, t.work_due_when_meter_reads, t.work_due_date, p.*" & _
            " FROM (plant AS p INNER JOIN task AS t ON p.plant_id=t.plant_fk) INNER JOIN equipment AS e ON p.plant_id=e.plant_fk" & _
            " WHERE e.equip_id=t.equip_id And t.plant_fk <> 0"
            'strSQL = "select distinct t.*, p.* from plant p inner join task t on p.plant_id = t.plant_fk where t.plant_fk <> 0"
            strEquip = "select plant_fk, equip_id, equip_desc, last_meter_reading, last_meter_reading_date from equipment where equip_id <> 0"
        Else
            strSQL = "select DISTINCT t.task_id, t.plant_fk, t.equip_id, e.equip_desc, t.task_desc, t.priority, t.cycle_type, t.interval_days, t.interval_meter, t.tools_required,t.lo_to,t.last_worked_meter_reading,t.last_worked_date, t.created_by, t.misc_comments, t.work_due_when_meter_reads, t.work_due_date, p.*" & _
            " FROM (plant AS p INNER JOIN task AS t ON p.plant_id=t.plant_fk) INNER JOIN equipment AS e ON p.plant_id=e.plant_fk" & _
            " WHERE e.equip_id=t.equip_id And t.plant_fk = " & intPlantPass
            'strSQL = "select distinct t.*, p.* from plant p inner join task t on p.plant_id = t.plant_fk where t.plant_fk = " & intPlantPass
            strEquip = "select plant_fk, equip_id, equip_desc, last_meter_reading, last_meter_reading_date from equipment where plant_fk = " & intPlantPass
        End If
        
        Set rsTaskRetrieve = RecordsetTask(strSQL)
        Set rsListEquip = EquipList(strEquip)
        cboEquipID.Clear
        Do While Not rsListEquip.EOF
            cboEquipID.AddItem rsListEquip!equip_id & " - " & rsListEquip!equip_desc
            rsListEquip.MoveNext
        Loop
        rsListEquip.MoveFirst
        rsTaskRetrieve.MoveLast
        rsTaskRetrieve.MoveFirst
        
        FillFields
            
        SetGrid
        
        ' Following are the values,
        ' which will return all the records in the taks table
        strPrintOpt = "All"
        strPrintDate = "01/01/1955"
        strPrintEquipKey = "XXXXXXXXXXX"
        strPrintMiscComments = "XXXXXXXXXXX"
    End If
Exit Function
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - FromLoadType: Description - " & Err.Description
End Function

Private Sub Form_KeyUp(KeyCode As Integer, Shift As Integer)
    Dim intKeyValue As Integer
    
On Error GoTo errorhandler

    intKeyValue = KeyCode
    
    ' F8(value 119) save and move to previous record
    ' F9(value 120) save and move to next record
    ' F10(value 121) can be used to save then move to the next(new) record
    
    If intKeyValue = 121 Then
        Save
        intTypeTask = 2
        Add
        intEquipIDStore = 0
        MDIFormWOS.SetFocus
        frmTask.SetFocus
        frmTask.cboEquipID.SetFocus
        MDIFormWOS.AddMode
    ElseIf intKeyValue = 120 Then
        Save
        If intStatus = 2 Then
            intStatus = 1
        End If
        If MDIFormWOS.cmdFirst.Enabled = False Then
            Cancel
        End If
        If MDIFormWOS.cmdAdd.Enabled = True Then
            NextRec
        End If
        MDIFormWOS.SetFocus
        frmTask.SetFocus
        frmTask.cboEquipID.SetFocus
        'MDIFormWOS.FindActive (False)

    ElseIf intKeyValue = 119 Then
        Save
        If intStatus = 2 Then
            intStatus = 1
        End If
        If MDIFormWOS.cmdFirst.Enabled = False Then
            Cancel
        End If
        If MDIFormWOS.cmdAdd.Enabled = True Then
            PrevRec
        End If
        MDIFormWOS.SetFocus
        frmTask.SetFocus
        frmTask.cboEquipID.SetFocus
        'MDIFormWOS.FindActive (False)
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - Form_KeyUp: Description - " & Err.Description
End Sub

Private Sub Form_Load()

On Error GoTo errorhandler
    intStatus = 0
    Me.Height = 7000
    Me.Width = 9300
    Me.Left = 0
    Me.Top = 0
    FormLoadType
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - Form_Load: Description - " & Err.Description
End Sub

Public Sub SetGrid()
    Dim intGridWidth As Integer
    Dim col1, col2, col3, col4, col5, col6 As Column
    
On Error GoTo errorhandler

    Set DGridTask.DataSource = rsTaskRetrieve
    
    Set col1 = DGridTask.Columns(0)
    Set col2 = DGridTask.Columns(1)
    Set col3 = DGridTask.Columns(2)
    Set col4 = DGridTask.Columns(3)
    Set col5 = DGridTask.Columns(4)
    Set col6 = DGridTask.Columns(5)
        
    col1.Caption = "ID"
    col2.Caption = "PLANT"
    col3.Caption = "EQUIP"
    col4.Caption = "EQUIP DESC"
    col5.Caption = "WORK ORDER DESC"
    col6.Caption = "PRIORITY"
        
    intGridWidth = DGridTask.Width
    
    col1.Width = (5 / 81) * intGridWidth
    col2.Width = (5 / 81) * intGridWidth
    col3.Width = (5 / 81) * intGridWidth
    col4.Width = (28 / 81) * intGridWidth
    col5.Width = (28 / 81) * intGridWidth
    col6.Width = (8 / 81) * intGridWidth
    'col1.Locked = True
    'col2.Locked = True
    'col3.Locked = True
    'col4.Locked = True
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - SetGrid: Description - " & Err.Description
End Sub

Private Sub KeepCount()

On Error GoTo errorhandler

    Me.txtCount = "Record No. " & rsTaskRetrieve.AbsolutePosition & " of " & rsTaskRetrieve.RecordCount & " Records"
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - KeepCount: Description - " & Err.Description
End Sub

Private Sub FillFields()
    Dim intCount As Integer
    
On Error GoTo errorhandler

    If rsTaskRetrieve.EOF = True Or rsTaskRetrieve.BOF = True Then
        intCount = rsTaskRetrieve.RecordCount
        If intCount = 0 Then
            MsgBox "There are no more Work Order for this plant in the database."
            Unload Me
        End If
    Else
        Me.lblPlantName.Caption = intPlantPass & " - " & strPlantPass
        Me.lblPlantNameG.Caption = intPlantPass & " - " & strPlantPass
        
        cboEquipID.Text = rsTaskRetrieve!equip_id
        intEquipIDStore = rsTaskRetrieve!equip_id
        If IsNull(rsTaskRetrieve!task_desc) Then
            txtTaskDesc.Text = ""
        Else
            txtTaskDesc.Text = rsTaskRetrieve!task_desc
        End If
        If IsNull(rsTaskRetrieve!priority) Then
            cboPriority.Text = ""
        Else
            cboPriority.Text = rsTaskRetrieve!priority
        End If
        If IsNull(rsTaskRetrieve!cycle_type) Then
            cboCycleType.Text = ""
        Else
            cboCycleType.Text = rsTaskRetrieve!cycle_type
        End If
        If IsNull(rsTaskRetrieve!interval_days) Then
            txtIntervalDays.Text = ""
        Else
            txtIntervalDays.Text = rsTaskRetrieve!interval_days
        End If
        If IsNull(rsTaskRetrieve!last_worked_date) Then
            txtLastWorkedDate.Text = ""
        Else
            txtLastWorkedDate.Text = rsTaskRetrieve!last_worked_date
        End If
        If IsNull(rsTaskRetrieve!interval_meter) Then
            txtIntervalMeter.Text = ""
        Else
            txtIntervalMeter.Text = rsTaskRetrieve!interval_meter
        End If
        If IsNull(rsTaskRetrieve!last_worked_meter_reading) Then
            txtLastWorkedMeterReading.Text = ""
        Else
            txtLastWorkedMeterReading.Text = rsTaskRetrieve!last_worked_meter_reading
        End If
        If IsNull(rsTaskRetrieve!tools_required) Then
            txtToolsRequired.Text = ""
        Else
            txtToolsRequired.Text = rsTaskRetrieve!tools_required
        End If
        If IsNull(rsTaskRetrieve!created_by) Then
            txtCreatedby.Text = ""
        Else
            txtCreatedby.Text = rsTaskRetrieve!created_by
        End If
        If IsNull(rsTaskRetrieve!misc_comments) Then
            txtMiscComments.Text = ""
        Else
            txtMiscComments.Text = rsTaskRetrieve!misc_comments
        End If
        If IsNull(rsTaskRetrieve!lo_to) Then
            txtLoTo.Text = ""
        Else
            txtLoTo.Text = rsTaskRetrieve!lo_to
        End If
        If IsNull(rsTaskRetrieve!work_due_when_meter_reads) Then
            txtWorkDueWhenMeterReads.Text = ""
        Else
            txtWorkDueWhenMeterReads.Text = rsTaskRetrieve!work_due_when_meter_reads
        End If
        If IsNull(rsTaskRetrieve!work_due_date) Then
            txtWorkDueDate.Text = ""
        Else
            txtWorkDueDate.Text = rsTaskRetrieve!work_due_date
        End If
        KeepCount
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - FillFields: Description - " & Err.Description
End Sub

Public Sub ChangedData()
    Dim intChangedCount As Integer
    Dim strEquipID, strNum As String
    Dim intLen As Integer
    Dim intPos As Integer
    
On Error GoTo errorhandler

    intChangedCount = 0
    ans = 0
    
    strEquipID = cboEquipID.Text
    strEquipID = Trim(strEquipID)
    intLen = Len(strEquipID)
    intPos = InStr(strEquipID, " - ")
    
    If intPos = 0 Then
        strNum = strEquipID
    Else
        strNum = Left(strEquipID, intPos - 1)
    End If
    
    If rsTaskRetrieve!equip_id <> CLng(strNum) Then
        intChangedCount = intChangedCount + 1
    End If
    If rsTaskRetrieve!task_desc <> Me.txtTaskDesc.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsTaskRetrieve!priority <> Me.cboPriority.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsTaskRetrieve!cycle_type <> Me.cboCycleType.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsTaskRetrieve!interval_days <> Me.txtIntervalDays.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsTaskRetrieve!interval_meter <> Me.txtIntervalMeter.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsTaskRetrieve!tools_required <> Me.txtToolsRequired.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsTaskRetrieve!last_worked_meter_reading <> Me.txtLastWorkedMeterReading.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsTaskRetrieve!last_worked_date <> Me.txtLastWorkedDate.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsTaskRetrieve!lo_to <> Me.txtLoTo.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsTaskRetrieve!misc_comments <> Me.txtMiscComments.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsTaskRetrieve!created_by <> Me.txtCreatedby.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsTaskRetrieve!work_due_when_meter_reads <> Me.txtWorkDueWhenMeterReads.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsTaskRetrieve!work_due_date <> Me.txtWorkDueDate.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If intChangedCount > 0 Then
        ans = MsgBox("Do you want to save the changed data?", vbYesNo, "WOS")
        If ans = 6 Then
            Save
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - ChangedData: Description - " & Err.Description
End Sub

Private Sub Form_Unload(Cancel As Integer)

On Error GoTo errorhandler

    Set rsTaskRetrieve = Nothing
    Set rsListEquip = Nothing
    intTypeTask = 0
    MDIFormWOS.FindActive (True)
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - Form_Unload: Description - " & Err.Description
End Sub

Private Sub txtIntervalDays_Validate(Cancel As Boolean)

On Error GoTo errorhandler

    If IsNumeric(txtIntervalDays.Text) = False And txtIntervalDays.Text <> "" Then
        MsgBox "Incorrect Format. Please Re-enter."
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - txtIntervalDays_Validate: Description - " & Err.Description
End Sub

Private Sub txtIntervalMeter_Validate(Cancel As Boolean)

On Error GoTo errorhandler

    If IsNumeric(txtIntervalMeter.Text) = False And txtIntervalMeter.Text <> "" Then
        MsgBox "Incorrect Format. Please Re-enter."
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - txtIntervalMeter_Validate: Description - " & Err.Description
End Sub

Private Sub txtLastWorkedDate_Validate(Cancel As Boolean)

On Error GoTo errorhandler

   If IsDate(txtLastWorkedDate.Text) = False And txtLastWorkedDate.Text <> "" Then
        MsgBox "Incorrect Format. Please Re-enter."
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - txtLastWorkedDate_Validate: Description - " & Err.Description
End Sub

Private Sub txtLastWorkedMeterReading_Validate(Cancel As Boolean)

On Error GoTo errorhandler

   If IsNumeric(txtLastWorkedMeterReading.Text) = False And txtLastWorkedMeterReading.Text <> "" Then
        MsgBox "Incorrect Format. Please Re-enter."
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - txtLastWorkedMeterReading_Validate: Description - " & Err.Description
End Sub

Private Sub txtTaskDesc_Validate(Cancel As Boolean)
    Dim intLen As Integer
    Dim ans As Integer
    
On Error GoTo errorhandler

    intLen = Len(txtTaskDesc.Text)
    If intLen = 0 Then
        Beep
        ans = MsgBox("The WORK ORDER DESCRIPTION field is a required field.", vbOKOnly, "WOS")
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Task - txtTaskDesc_Validate: Description - " & Err.Description
End Sub
