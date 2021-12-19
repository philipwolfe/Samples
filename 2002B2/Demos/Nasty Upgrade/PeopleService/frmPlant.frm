VERSION 5.00
Begin VB.Form frmPlant 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "WOS"
   ClientHeight    =   3195
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   4290
   BeginProperty Font 
      Name            =   "MS Sans Serif"
      Size            =   9.75
      Charset         =   0
      Weight          =   400
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   3195
   ScaleWidth      =   4290
   StartUpPosition =   3  'Windows Default
   Begin VB.CommandButton cmdCreate 
      Caption         =   "C&reate"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   240
      TabIndex        =   4
      Top             =   2280
      Width           =   1095
   End
   Begin VB.CommandButton cmdCancel 
      Caption         =   "&Cancel"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   2880
      TabIndex        =   3
      Top             =   2280
      Width           =   1095
   End
   Begin VB.CommandButton cmdOK 
      Caption         =   "&OK"
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   495
      Left            =   1560
      TabIndex        =   2
      Top             =   2280
      Width           =   1095
   End
   Begin VB.ComboBox cboPlant 
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   8.25
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   315
      ItemData        =   "frmPlant.frx":0000
      Left            =   1080
      List            =   "frmPlant.frx":0002
      TabIndex        =   0
      Top             =   1560
      Width           =   1935
   End
   Begin VB.Label lblRequest 
      Caption         =   "Please Select a plant from the following list and click OK."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   735
      Left            =   360
      TabIndex        =   1
      Top             =   480
      Width           =   3615
   End
End
Attribute VB_Name = "frmPlant"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Private Sub cboPlant_KeyDown(KeyCode As Integer, Shift As Integer)
    
'
' Not allowed to type in have to pick from the list
'

    Dim ans As Integer

On Error GoTo errorhandler
    ans = 0
    ans = MsgBox("Can not edit. Have to select from the list provided.")
    cboPlant.Text = ""

Exit Sub
errorhandler:
    MsgBox "Error Number - " & Err.Number & ": WOS: Plant - cboPlant_KeyDown: Description - " & Err.Description
End Sub

Private Sub cmdCancel_Click()

'
' Exits the application
'

    End
End Sub

Private Sub cmdCreate_Click()

'
' Opens Modal form to add plant
'

On Error GoTo errorhandler

    frmAddPlant.Show (1)

Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Plant - cmdCreate_Click: Description - " & Err.Description

End Sub

Public Function CheckAll(strFrom As String) As Integer
    
'
' This is a very important function
' This is used to check if there are any records starting from equipment
' to Work Order to History for selected plant. Based on all the information
' If there are no equipment records for the selected plant then it will
' open Equipment form to add new records. If "all" plant option has been
' selected then it will warn that equipment can not be added until a plant
' has been selected.
' If there are no Work Order records but there are equipment records then it will
' open Work Order form in add mode.
' If there are Work Orders as well as equipment records but no History records
' then it will open History form in add mode.
' If there are all the records for all three types then it will open
' History in update mode or we can call it view mode if user does not
' change any record.
'
' Note: This function can be written with select case rather than if else
' but since this is an important function and is working this way
' it recommended to keep it this way unless it becomes hard to maintain
'

    ' returns 1 if going in
    ' returns 2 if called from inside
    ' argument - "outside" or "equip" or "task" or "wo"
    Dim intAns As Integer
    
On Error GoTo errorhandler
    
    If frmWorkOrder.CheckRecordset = 2 Then
        ' no history records
        If frmEquipment.CheckRecordset = 2 Then
            ' no equipment records
            If intPlantPass <> 0 Then
                ' if a plant has been selected
                ' open the equipment in add mode
                
                MDIFormWOS.Show
                frmEquipment.Show
                intTypeEquip = 1
                frmEquipment.Add
                frmEquipment.SetFocus
                frmEquipment.txtEquipKey.SetFocus
                MsgBox "Please add equipment for the plant you have selected."
                CheckAll = 1
            Else
                ' if "All Plants" has been selected
                ' force user to select a plant for which to add equipment
                MsgBox "Please select a plant to start entering equipment and other information."
                If strFrom <> "outside" Then
                    Unload MDIFormWOS
                    Exit Function
                End If
            End If
        Else
            ' if there are equipment records atleast we can open MDI form
            MDIFormWOS.Show
            If frmTask.CheckRecordset = 2 Then
                ' if there are no Work Order(Task) records
                If strFrom <> "outside" Then
                    ' if it is coming from inside
                    If strFrom = "equip" Then
                        ' if equipment was clicked
                        '**********
                        Unload frmEquipment
                        frmEquipment.Show
                        frmEquipment.SetFocus
                        frmEquipment.txtEquipKey.SetFocus
                        CheckAll = 1
                    Else
                        ' if Work Order(Task) button was clicked and there are no records
                        ' for Work Order open Work Order form in add mode
                        '**********
                        Unload frmTask
                        frmTask.Show
                        intTypeTask = 1
                        frmTask.Add
                        frmTask.SetFocus
                        frmTask.cboEquipID.SetFocus
                        CheckAll = 1
                    End If
                Else
                    ' if it was from outside
                    ' obviously there are no records so ask user if
                    ' he/she wants to start adding records
                    intAns = MsgBox("Do you want me to open Work Order window to add new Work Orders?", vbYesNo)
                    If intAns = 6 Then
                        ' open the Work Order(task) in add mode
                        frmTask.Show
                        intTypeTask = 1
                        frmTask.Add
                        frmTask.SetFocus
                        frmTask.cboEquipID.SetFocus
                        MsgBox "Please add Work Order for the plant you have selected."
                        CheckAll = 1
                    Else
                        ' If they are not ready to add open equipment
                        ' window in update/view mode
                        '*************
                        Unload frmEquipment
                        frmEquipment.Show
                        frmEquipment.SetFocus
                        frmEquipment.txtEquipKey.SetFocus
                        CheckAll = 1
                    End If
                End If
            Else
                ' if there are Work Order(Task) records for the plant selected
                If strFrom <> "outside" Then
                    ' if it is being called from inside
                    Select Case strFrom
                    Case "equip"
                        ' if equipment button was clicked
                        '**********
                        Unload frmEquipment
                        frmEquipment.Show
                        CheckAll = 1
                        frmEquipment.SetFocus
                        frmEquipment.txtEquipKey.SetFocus
                    Case "task"
                        ' if Work Order(task) button was clicked
                        '***********
                        Unload frmTask
                        frmTask.Show
                        frmTask.SetFocus
                        frmTask.cboEquipID.SetFocus
                        CheckAll = 1
                    Case "wo"
                        ' if History button was clicked
                        ' We already know from the first branch of the
                        ' if statement that there are no History records
                        ' so open History form in add mode
                        '***************
                        Unload frmWorkOrder
                        frmWorkOrder.Show
                        intTypeWO = 1
                        frmWorkOrder.Add
                        frmWorkOrder.SetFocus ' Added 4-10
                        frmWorkOrder.cboEquipID.SetFocus 'Added 4-10
                        MDIFormWOS.AddMode
                        CheckAll = 1
                    End Select
                Else
                    ' if this was called from outside
                    ' We know there are no History records so ask user
                    ' if he/she wants to start adding
                                        
                    intAns = MsgBox("Do you want me to open History Screen to complete Work Orders?", vbYesNo)
                    If intAns = 6 Then
                        ' open the History in add mode
                        frmWorkOrder.Show
                        intTypeWO = 1
                        frmWorkOrder.Add
                        frmWorkOrder.SetFocus 'Added 4-10
                        frmWorkOrder.cboEquipID.SetFocus ' Added 4-10
                        MDIFormWOS.AddMode
                        CheckAll = 1
                    Else
                        ' Show the Work Order(task) form in update/view mode
                        '*************
                        Unload frmTask
                        frmTask.Show
                        frmTask.SetFocus
                        frmTask.cboEquipID.SetFocus
                        CheckAll = 1
                    End If
                End If
            End If
        End If
    Else
        ' if there were History records
        MDIFormWOS.Show
        Select Case strFrom
        Case "outside"
            ' if called from outside open History form in update/view mode
            frmWorkOrder.Show
            frmWorkOrder.SetFocus
            frmWorkOrder.cboEquipID.SetFocus
            CheckAll = 1
        Case "equip"
            ' if equipment was clicked from inside then
            ' open equipment form in update/view mode
            '***********
            Unload frmEquipment
            frmEquipment.Show
            frmEquipment.SetFocus
            frmEquipment.txtEquipKey.SetFocus
            CheckAll = 1
        Case "task"
            ' if Work Order(task) was clicked from inside then
            ' open Work Order(task) form in update/view mode
            '*************
            Unload frmTask
            frmTask.Show
            frmTask.SetFocus
            frmTask.cboEquipID.SetFocus
            CheckAll = 1
        Case "wo"
            ' if History was clicked from inside then
            ' open History form in update/view mode
            '**************
            Unload frmWorkOrder
            frmWorkOrder.Show
            frmWorkOrder.SetFocus
            frmWorkOrder.cboEquipID.SetFocus
            CheckAll = 1
        End Select
    End If
    
Exit Function

errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Plant - CheckAll: Description - " & Err.Description

End Function

Private Sub cmdOK_Click()
    
'
' Gets the values selected from the combo box and enters the application
' with the value
'

    Dim ans As Integer
    Dim intPos As Integer
    Dim strNum As String
    Dim intLen As Integer

On Error GoTo errorhandler
    
    If cboPlant.Text = "" Then
        ans = MsgBox("Please select a plant from the dropdown or create a new plant.", vbOKOnly, "WOS")
    Else
        strPlantPass = cboPlant.Text
        strPlantPass = Trim(strPlantPass)
        intLen = Len(strPlantPass)
        intPos = InStr(strPlantPass, " - ")
        strNum = Left(strPlantPass, intPos - 1)
        ' Stored in Global variables
        intPlantPass = CInt(strNum)
        strPlantPass = Right(strPlantPass, intLen - 4)
        If CheckAll("outside") = 1 Then
            Unload Me
        End If
    End If
    
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WO: Plant - cmdOK_Click: Description - " & Err.Description

End Sub

Private Sub Form_Load()

'
' There is at least "All Plants" Option to start with
' which means nothing until a plant is added to the database
'

On Error GoTo errorhandler

    Me.Height = 3600
    Me.Width = 4410
    RetrievePlant
    cboPlant.AddItem "0 - All Plants"
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Plant - Form_Load: Description - " & Err.Description

End Sub

Public Sub RetrievePlant()
    
'
' Retrieves all the plants from the database and adds them to the combo
' item list
'

    Dim rsPlantRetrieve As ADODB.Recordset
    Dim I As Integer
    Dim count As Integer
    Dim strSQL As String
    Dim strCurType As String
    
On Error GoTo errorhandler

    strSQL = "SELECT * from plant where plant_id <> 0 order by plant_name asc"
    strCurType = "Retrieve"
    
    Set rsPlantRetrieve = RecordsetPlant(strSQL, strCurType)
    
    cboPlant.Clear
    
    If rsPlantRetrieve.EOF = True Or rsPlantRetrieve.BOF = True Then
        MsgBox "There are no plants in the database. Please enter a new plant name."
        frmAddPlant.Show (1)
    Else
        rsPlantRetrieve.MoveLast
        count = rsPlantRetrieve.RecordCount
        rsPlantRetrieve.MoveFirst
        
        For I = 1 To count
            cboPlant.AddItem rsPlantRetrieve!plant_id & " - " & rsPlantRetrieve!plant_name
            rsPlantRetrieve.MoveNext
        Next
    End If
    Set rsPlantRetrieve = Nothing
    'Set cnWos = Nothing
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Plant - RetrievePlant: Description - " & Err.Description
End Sub
