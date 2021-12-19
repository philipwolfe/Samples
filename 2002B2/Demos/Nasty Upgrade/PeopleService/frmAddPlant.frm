VERSION 5.00
Begin VB.Form frmAddPlant 
   BorderStyle     =   1  'Fixed Single
   Caption         =   "Plant Add"
   ClientHeight    =   2355
   ClientLeft      =   45
   ClientTop       =   330
   ClientWidth     =   4680
   LinkTopic       =   "Form2"
   MaxButton       =   0   'False
   MinButton       =   0   'False
   ScaleHeight     =   2355
   ScaleWidth      =   4680
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
      Left            =   2640
      TabIndex        =   2
      Top             =   1560
      Width           =   1000
   End
   Begin VB.CommandButton cmdSave 
      Caption         =   "&Save"
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
      Left            =   960
      TabIndex        =   1
      Top             =   1560
      Width           =   1000
   End
   Begin VB.TextBox txtPlantName 
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   960
      TabIndex        =   0
      Top             =   840
      Width           =   2655
   End
   Begin VB.Label Label1 
      Caption         =   "Please enter a new plant name."
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   700
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   375
      Left            =   480
      TabIndex        =   3
      Top             =   240
      Width           =   3855
   End
End
Attribute VB_Name = "frmAddPlant"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False

Option Explicit

'
' This form is uded to add new plant
' Plant can not be deleted, which is also true for
' Equipment as well as Work Order(Task)
'

Private Sub cmdCancel_Click()

'
' If user selects not to add new plant to the list of plants.
'

On Error GoTo errorhandler
    
    Me.Hide
Exit Sub

errorhandler:

MsgBox "Error Number - " & Err.Number & ": WOS : Add Plant - Cancel: Description - " & Err.Description
End Sub

Private Sub cmdSave_Click()

'
' Used to save plant once a value is entered
' It will be saved only after validating
' Code for validation can be found in modPlant module
'

On Error GoTo errorhandler

    ValidatePlant
Exit Sub
errorhandler:

MsgBox "Error Number - " & Err.Number & ": WOS : Add Plant - Validate Plant: Description - " & Err.Description
End Sub

Public Sub AddPlant()

'
'  Once the validation is done the data is saved and
'  user is informed of the addition
'

    Dim rsPlantAdd As ADODB.Recordset
    Dim ans As Integer
    Dim strSQL As String
    Dim strCurType As String
    
On Error GoTo errorhandler
    Me.Height = 3600
    Me.Width = 4410
    
    strSQL = "SELECT * from plant where plant_id = 0"
    strCurType = "Add"
    
    Set rsPlantAdd = RecordsetPlant(strSQL, strCurType)
        
    rsPlantAdd.AddNew
    rsPlantAdd!plant_name = Me.txtPlantName.Text
    rsPlantAdd.MoveNext
    
    Set rsPlantAdd = Nothing
    'Set cnWos = Nothing
    
    ans = MsgBox("New plant: " & txtPlantName.Text & " has been added.", vbOKOnly, "WOS")
    Me.Hide
    frmPlant.RetrievePlant
    frmPlant.cboPlant.AddItem "0 - All Plants"
Exit Sub
errorhandler:

MsgBox "Error Number - " & Err.Number & ": WOS : Add Plant - Add Plant: Description - " & Err.Description
End Sub

