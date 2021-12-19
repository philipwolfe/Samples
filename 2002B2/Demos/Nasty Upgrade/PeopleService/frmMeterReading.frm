VERSION 5.00
Object = "{CDE57A40-8B86-11D0-B3C6-00A0C90AEA82}#1.0#0"; "MSDATGRD.OCX"
Begin VB.Form frmMeterReading 
   Caption         =   "Meter Reading"
   ClientHeight    =   6000
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   9180
   LinkTopic       =   "Form2"
   MDIChild        =   -1  'True
   ScaleHeight     =   6000
   ScaleWidth      =   9180
   WindowState     =   2  'Maximized
   Begin MSDataGridLib.DataGrid dgridMeterReading 
      Height          =   5535
      Left            =   120
      TabIndex        =   0
      Top             =   240
      Width           =   8175
      _ExtentX        =   14420
      _ExtentY        =   9763
      _Version        =   393216
      HeadLines       =   1
      RowHeight       =   19
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
         Size            =   9.75
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
      Left            =   120
      TabIndex        =   1
      Top             =   0
      Width           =   2775
   End
End
Attribute VB_Name = "frmMeterReading"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim ans As Integer
Dim lngMeterReading As Long
Dim rsUpdateMeter As ADODB.Recordset

Private Sub DGridMeterReading_GotFocus()

'
' When a cell gets focus it gets the value from it so that it can be used
' for validation
'

On Error GoTo errorhandler

    lngMeterReading = 0
    If IsNull(rsUpdateMeter!last_meter_reading) Then
        lngMeterReading = 0
    Else
        lngMeterReading = rsUpdateMeter!last_meter_reading
    End If
Exit Sub
errorhandler:
    MsgBox "Error Number - " & Err.Number & ": WOS: MeterReading - dgridMeterReading GotFocus: Description - " & Err.Description
End Sub

Private Sub DGridMeterReading_RowColChange(LastRow As Variant, ByVal LastCol As Integer)

'
' If the col or row is changed thenit gets value for the new cell so
' that it can be used for validation
'

On Error GoTo errorhandler


    lngMeterReading = 0
    If IsNull(rsUpdateMeter!last_meter_reading) Then
        lngMeterReading = 0
    Else
        lngMeterReading = rsUpdateMeter!last_meter_reading
    End If
Exit Sub
errorhandler:
    MsgBox "Error Number - " & Err.Number & ": WOS: MeterReading - dgridMeterReading RowColChange: Description - " & Err.Description
End Sub

Private Sub DGridMeterReading_Validate(Cancel As Boolean)

'
' Validates the field before leaving
'
    Dim lngNewMeter As Long
    Dim strequip_key As String

On Error GoTo errorhandler

    ans = 0
    lngNewMeter = 0
    
    strequip_key = rsUpdateMeter!equip_key

    If IsNull(dgridMeterReading.Columns(2)) Or dgridMeterReading.Columns(2) = "" Then
        If lngMeterReading > 0 Then
            ans = MsgBox("It is not suggested to have new meter reading smaller than the old one. Do you want to continue?", vbYesNo)
            If ans = 6 Then
                
            Else
                dgridMeterReading.Columns(2).Value = lngMeterReading
            End If
        End If
    Else                        'If dgridMeterReading.Columns(2).Value <> "" Then
        If IsNumeric(dgridMeterReading.Columns(2).Value) = False And dgridMeterReading.Columns(2).Value <> "" Then
            MsgBox "Incorrect Format. Please Re-enter."
            Cancel = True
        ElseIf IsDate(dgridMeterReading.Columns(3).Value) = False And dgridMeterReading.Columns(2).Value <> "" Then
            MsgBox "Incorrect Format. Please Re-enter."
            Cancel = True
        Else
            lngNewMeter = CLng(dgridMeterReading.Columns(2).Value)
            
            If lngNewMeter < lngMeterReading Then
                ans = MsgBox("It is not suggested to have new meter reading smaller than the old one. Do you want to continue?", vbYesNo)
                If ans = 6 Then
                    If IsNull(lngNewMeter) Then
                        dgridMeterReading.Columns(2).Value = ""
                    Else
                        dgridMeterReading.Columns(2).Value = lngNewMeter
                    End If
                Else
                    If IsNull(lngMeterReading) Then
                        dgridMeterReading.Columns(2).Value = ""
                    Else
                        dgridMeterReading.Columns(2).Value = lngMeterReading
                    End If
                End If
            End If
        End If
    End If
        
Exit Sub
errorhandler:
    MsgBox "Error Number - " & Err.Number & ": WOS: MeterReading - dgridMeterReading Validate: Description - " & Err.Description
End Sub

Public Sub RefreshRec()

'
' Basically unloads and reloads the form
'

On Error GoTo errorhandler

    Unload Me
    frmMeterReading.Show
Exit Sub
errorhandler:
    MsgBox "Error Number - " & Err.Number & ": WOS: MeterReading - RefreshRec: Description - " & Err.Description
End Sub

Private Sub Form_Activate()

'
' Used to know which form is active to enbale or disable buttons which are on MDI form
'

On Error GoTo errorhandler

    MDIFormWOS.FindActive (False)

Exit Sub
errorhandler:
    MsgBox "Error Number - " & Err.Number & ": WOS: MeterReading - Form_Activate: Description - " & Err.Description
End Sub

Private Sub Form_Load()

'
' Sets size and position of the form and retrieves all the records
'

On Error GoTo errorhandler

    Me.Height = 6400
    Me.Width = 9300
    Me.Left = 0
    Me.Top = 0
    UpdateMeterReading

Exit Sub
errorhandler:
    MsgBox "Error Number - " & Err.Number & ": WOS: MeterReading - Form_Load: Description - " & Err.Description
End Sub

Private Sub UpdateMeterReading()

'
' Procedure used to retrieve records and set to the grid
'

    Dim intGridWidth As Integer
    
On Error GoTo errorhandler

    
    Dim I As Integer
    Dim count As Integer
    Dim strSQL As String
    
    If intPlantPass = 0 Then
        strSQL = "SELECT equip_key, equip_desc, last_meter_reading, last_meter_reading_date from equipment where plant_fk <> 0"
    Else
        strSQL = "SELECT equip_key, equip_desc, last_meter_reading, last_meter_reading_date from equipment where plant_fk = " & intPlantPass
    End If
    
    Set rsUpdateMeter = RecordsetEquip(strSQL)
        
    Set dgridMeterReading.DataSource = rsUpdateMeter
    dgridMeterReading.Columns(0).Caption = "EQUIP KEY (LOCKED)"
    dgridMeterReading.Columns(1).Caption = "EQUIP DESC (LOCKED)"
    dgridMeterReading.Columns(2).Caption = "METER READING"
    dgridMeterReading.Columns(3).Caption = "DATE READ"
    intGridWidth = dgridMeterReading.Width
    
    dgridMeterReading.Columns(0).Width = (16 / 81) * intGridWidth
    dgridMeterReading.Columns(1).Width = (35 / 81) * intGridWidth
    dgridMeterReading.Columns(2).Width = (15 / 81) * intGridWidth
    dgridMeterReading.Columns(3).Width = (11.5 / 81) * intGridWidth
    
    dgridMeterReading.Columns(0).Locked = True
    dgridMeterReading.Columns(1).Locked = True
    
    Me.lblPlantName.Caption = intPlantPass & " - " & strPlantPass

    'Set rsUpdateMeter = Nothing
    'Set cnWOS = Nothing
Exit Sub
errorhandler:
    MsgBox "Error Number - " & Err.Number & ": WOS: MeterReading - UpdateMeterReading: Description - " & Err.Description
End Sub

Public Sub Cancel()

'
' Unloads and reloads the form
'

On Error GoTo errorhandler

    Unload Me
    frmMeterReading.Show

Exit Sub
errorhandler:
    MsgBox "Error Number - " & Err.Number & ": WOS: MeterReading - Cancel: Description - " & Err.Description
End Sub

Private Sub Form_Unload(Cancel As Integer)

'
' Unloads the form
' sets the recordset to nothing
' and calls FindActive procedure from MDI form to disable all
' the buttons except equipment, Work Order(Task) and History until one
' form is active
'

On Error GoTo errorhandler

    Set rsUpdateMeter = Nothing
    MDIFormWOS.FindActive (True)

Exit Sub
errorhandler:
    MsgBox "Error Number - " & Err.Number & ": WOS: MeterReading - Form_Unload: Description - " & Err.Description
End Sub
