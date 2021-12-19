VERSION 5.00
Object = "{CDE57A40-8B86-11D0-B3C6-00A0C90AEA82}#1.0#0"; "MSDATGRD.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "tabctl32.ocx"
Object = "{C932BA88-4374-101B-A56C-00AA003668DC}#1.1#0"; "msmask32.ocx"
Begin VB.Form frmWorkOrder 
   Caption         =   "History"
   ClientHeight    =   8490
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   10590
   KeyPreview      =   -1  'True
   LinkTopic       =   "Form2"
   MDIChild        =   -1  'True
   ScaleHeight     =   8490
   ScaleWidth      =   10590
   WindowState     =   2  'Maximized
   Begin VB.Frame FramForm 
      Height          =   6255
      Left            =   215
      TabIndex        =   1
      Top             =   0
      Width           =   8655
      Begin VB.TextBox txtComments 
         Height          =   765
         Left            =   1560
         MultiLine       =   -1  'True
         TabIndex        =   8
         Top             =   1920
         Width           =   6615
      End
      Begin VB.TextBox txtMaterialsCost 
         Height          =   285
         Left            =   7320
         TabIndex        =   7
         Top             =   1560
         Width           =   855
      End
      Begin VB.ComboBox cboTaskID 
         Height          =   315
         Left            =   1560
         TabIndex        =   2
         Top             =   840
         Width           =   6615
      End
      Begin VB.ComboBox cboEquipID 
         Height          =   315
         ItemData        =   "frmWorkOrder.frx":0000
         Left            =   1560
         List            =   "frmWorkOrder.frx":0002
         TabIndex        =   0
         Top             =   480
         Width           =   6615
      End
      Begin VB.TextBox txtCount 
         Alignment       =   2  'Center
         DataField       =   "equip_id"
         DataSource      =   "AdodcMaintenance"
         Enabled         =   0   'False
         ForeColor       =   &H00FF0000&
         Height          =   285
         Left            =   2880
         Locked          =   -1  'True
         TabIndex        =   17
         TabStop         =   0   'False
         Text            =   "1"
         Top             =   0
         Width           =   2655
      End
      Begin VB.TextBox txtLabor 
         Height          =   285
         Left            =   5240
         TabIndex        =   6
         Top             =   1560
         Width           =   735
      End
      Begin VB.TextBox txtCompletedBy 
         Height          =   285
         Left            =   1560
         TabIndex        =   5
         Top             =   1560
         Width           =   3015
      End
      Begin VB.TextBox txtMeterReadingAtCompletion 
         Height          =   285
         Left            =   7080
         TabIndex        =   4
         Top             =   1200
         Width           =   1095
      End
      Begin MSMask.MaskEdBox txtDateCompleted 
         Height          =   255
         Left            =   1560
         TabIndex        =   3
         Top             =   1200
         Width           =   1215
         _ExtentX        =   2143
         _ExtentY        =   450
         _Version        =   393216
         MaxLength       =   8
         Format          =   "m/d/yy"
         PromptChar      =   "_"
      End
      Begin TabDlg.SSTab SSTab1 
         Height          =   3135
         Left            =   240
         TabIndex        =   20
         TabStop         =   0   'False
         Top             =   2880
         Width           =   8205
         _ExtentX        =   14473
         _ExtentY        =   5530
         _Version        =   393216
         TabHeight       =   520
         ForeColor       =   16711680
         TabCaption(0)   =   "Mechanical"
         TabPicture(0)   =   "frmWorkOrder.frx":0004
         Tab(0).ControlEnabled=   -1  'True
         Tab(0).Control(0)=   "lblMechIDD"
         Tab(0).Control(0).Enabled=   0   'False
         Tab(0).Control(1)=   "lblMechModelD"
         Tab(0).Control(1).Enabled=   0   'False
         Tab(0).Control(2)=   "lblMechFrameD"
         Tab(0).Control(2).Enabled=   0   'False
         Tab(0).Control(3)=   "lblMechRecomSparePartsD"
         Tab(0).Control(3).Enabled=   0   'False
         Tab(0).Control(4)=   "lblMechMiscNPDataD"
         Tab(0).Control(4).Enabled=   0   'False
         Tab(0).Control(5)=   "lblMechNoValvesTypesD"
         Tab(0).Control(5).Enabled=   0   'False
         Tab(0).Control(6)=   "lblMechPipeTypeD"
         Tab(0).Control(6).Enabled=   0   'False
         Tab(0).Control(7)=   "lblMechPipeSizeD"
         Tab(0).Control(7).Enabled=   0   'False
         Tab(0).Control(8)=   "lblMechBelt2D"
         Tab(0).Control(8).Enabled=   0   'False
         Tab(0).Control(9)=   "lblMechBelt1D"
         Tab(0).Control(9).Enabled=   0   'False
         Tab(0).Control(10)=   "lblMechAirFilterD"
         Tab(0).Control(10).Enabled=   0   'False
         Tab(0).Control(11)=   "lblMechOilFilterD"
         Tab(0).Control(11).Enabled=   0   'False
         Tab(0).Control(12)=   "lblMechOilD"
         Tab(0).Control(12).Enabled=   0   'False
         Tab(0).Control(13)=   "lblMechCfmD"
         Tab(0).Control(13).Enabled=   0   'False
         Tab(0).Control(14)=   "lblMechMinRpmD"
         Tab(0).Control(14).Enabled=   0   'False
         Tab(0).Control(15)=   "lblMechMaxRpmD"
         Tab(0).Control(15).Enabled=   0   'False
         Tab(0).Control(16)=   "lblMechCatNoD"
         Tab(0).Control(16).Enabled=   0   'False
         Tab(0).Control(17)=   "lblMechTdhD"
         Tab(0).Control(17).Enabled=   0   'False
         Tab(0).Control(18)=   "lblMechSizeD"
         Tab(0).Control(18).Enabled=   0   'False
         Tab(0).Control(19)=   "lblMechCapD"
         Tab(0).Control(19).Enabled=   0   'False
         Tab(0).Control(20)=   "lblMechRpmD"
         Tab(0).Control(20).Enabled=   0   'False
         Tab(0).Control(21)=   "lblMechImpSzD"
         Tab(0).Control(21).Enabled=   0   'False
         Tab(0).Control(22)=   "lblMechSerialD"
         Tab(0).Control(22).Enabled=   0   'False
         Tab(0).Control(23)=   "lblMechRecomSpareParts"
         Tab(0).Control(23).Enabled=   0   'False
         Tab(0).Control(24)=   "lblMechMiscNPData"
         Tab(0).Control(24).Enabled=   0   'False
         Tab(0).Control(25)=   "lblMechNoValvesTypes"
         Tab(0).Control(25).Enabled=   0   'False
         Tab(0).Control(26)=   "lblMechPipeType"
         Tab(0).Control(26).Enabled=   0   'False
         Tab(0).Control(27)=   "lblMechPipeSize"
         Tab(0).Control(27).Enabled=   0   'False
         Tab(0).Control(28)=   "lblMechcfm"
         Tab(0).Control(28).Enabled=   0   'False
         Tab(0).Control(29)=   "lblMechMaxRpm"
         Tab(0).Control(29).Enabled=   0   'False
         Tab(0).Control(30)=   "lblMechMinRpm"
         Tab(0).Control(30).Enabled=   0   'False
         Tab(0).Control(31)=   "lblMechCatNo"
         Tab(0).Control(31).Enabled=   0   'False
         Tab(0).Control(32)=   "lblMechSize"
         Tab(0).Control(32).Enabled=   0   'False
         Tab(0).Control(33)=   "lblMechtdh"
         Tab(0).Control(33).Enabled=   0   'False
         Tab(0).Control(34)=   "lblMechCap"
         Tab(0).Control(34).Enabled=   0   'False
         Tab(0).Control(35)=   "lblMechRpm"
         Tab(0).Control(35).Enabled=   0   'False
         Tab(0).Control(36)=   "lblMechHp"
         Tab(0).Control(36).Enabled=   0   'False
         Tab(0).Control(37)=   "lblMechImpSz"
         Tab(0).Control(37).Enabled=   0   'False
         Tab(0).Control(38)=   "lblMechFrame"
         Tab(0).Control(38).Enabled=   0   'False
         Tab(0).Control(39)=   "lblMechModel"
         Tab(0).Control(39).Enabled=   0   'False
         Tab(0).Control(40)=   "lblMechID"
         Tab(0).Control(40).Enabled=   0   'False
         Tab(0).Control(41)=   "lblMechSerial"
         Tab(0).Control(41).Enabled=   0   'False
         Tab(0).Control(42)=   "lblMechOil"
         Tab(0).Control(42).Enabled=   0   'False
         Tab(0).Control(43)=   "lblMechOilFilter"
         Tab(0).Control(43).Enabled=   0   'False
         Tab(0).Control(44)=   "lblMechAirFilter"
         Tab(0).Control(44).Enabled=   0   'False
         Tab(0).Control(45)=   "lblMechBelt1"
         Tab(0).Control(45).Enabled=   0   'False
         Tab(0).Control(46)=   "lblMechBelt2"
         Tab(0).Control(46).Enabled=   0   'False
         Tab(0).Control(47)=   "lblMechHpD"
         Tab(0).Control(47).Enabled=   0   'False
         Tab(0).ControlCount=   48
         TabCaption(1)   =   "Electrical"
         TabPicture(1)   =   "frmWorkOrder.frx":0020
         Tab(1).ControlEnabled=   0   'False
         Tab(1).Control(0)=   "lblElecMiscNPDataD"
         Tab(1).Control(1)=   "lblElecRecomSparePartsD"
         Tab(1).Control(2)=   "lblElecOppEndBrgD"
         Tab(1).Control(3)=   "lblElecShaftEndBrgD"
         Tab(1).Control(4)=   "lblElecDesignD"
         Tab(1).Control(5)=   "lblElecInslClD"
         Tab(1).Control(6)=   "lblElecAmpD"
         Tab(1).Control(7)=   "lblElecVD"
         Tab(1).Control(8)=   "lblElecDutyD"
         Tab(1).Control(9)=   "lblElecSfD"
         Tab(1).Control(10)=   "lblElecPhsD"
         Tab(1).Control(11)=   "lblElecHzD"
         Tab(1).Control(12)=   "lblElecRpmD"
         Tab(1).Control(13)=   "lblElecHpD"
         Tab(1).Control(14)=   "lblElecCatNoD"
         Tab(1).Control(15)=   "lblElecFrameD"
         Tab(1).Control(16)=   "lblElecSerialD"
         Tab(1).Control(17)=   "lblElecModelD"
         Tab(1).Control(18)=   "lblElecIDD"
         Tab(1).Control(19)=   "lblElecRecomSpareParts"
         Tab(1).Control(20)=   "lblElecMiscNPData"
         Tab(1).Control(21)=   "lblElecOppEndBrg"
         Tab(1).Control(22)=   "lblElecShaftEndBrg"
         Tab(1).Control(23)=   "lblElecDesign"
         Tab(1).Control(24)=   "lblElecInslCl"
         Tab(1).Control(25)=   "lblElecDuty"
         Tab(1).Control(26)=   "lblElecAmp"
         Tab(1).Control(27)=   "lblElecV"
         Tab(1).Control(28)=   "lblElecSf"
         Tab(1).Control(29)=   "lblElecPhs"
         Tab(1).Control(30)=   "lblElecHz"
         Tab(1).Control(31)=   "lblElecRpm"
         Tab(1).Control(32)=   "lblElecHp"
         Tab(1).Control(33)=   "lblElecCatNo"
         Tab(1).Control(34)=   "lblElecSerial"
         Tab(1).Control(35)=   "lblElecID"
         Tab(1).Control(36)=   "lblElecModel"
         Tab(1).Control(37)=   "lblElecFrame"
         Tab(1).ControlCount=   38
         TabCaption(2)   =   "Work Order"
         TabPicture(2)   =   "frmWorkOrder.frx":003C
         Tab(2).ControlEnabled=   0   'False
         Tab(2).Control(0)=   "txtTaskMiscCommentsD"
         Tab(2).Control(0).Enabled=   0   'False
         Tab(2).Control(1)=   "lblWorkDueDateD"
         Tab(2).Control(2)=   "lblWorkDueWhenMeterReadsD"
         Tab(2).Control(3)=   "lblWorkDueDate"
         Tab(2).Control(4)=   "lblWorkDueWhenMeterReads"
         Tab(2).Control(5)=   "lblCreatedbyD"
         Tab(2).Control(6)=   "Label1"
         Tab(2).Control(7)=   "lblTaskToolsRequiredD"
         Tab(2).Control(8)=   "lblTaskLoToD"
         Tab(2).Control(9)=   "lblTaskLastWorkedMeterD"
         Tab(2).Control(10)=   "lblTaskLastWorkedDateD"
         Tab(2).Control(11)=   "lblTaskIntervalDaysD"
         Tab(2).Control(12)=   "lblTaskIntervalMeterD"
         Tab(2).Control(13)=   "lblTaskPriorityD"
         Tab(2).Control(14)=   "lblTaskCycleTypeD"
         Tab(2).Control(15)=   "lblTaskTaskDescD"
         Tab(2).Control(16)=   "lblMiscComments"
         Tab(2).Control(17)=   "lblLoTo"
         Tab(2).Control(18)=   "lblLastWorkedDate"
         Tab(2).Control(19)=   "lblLastWorkedMeterReading"
         Tab(2).Control(20)=   "lblToolsRequired"
         Tab(2).Control(21)=   "lblIntervalMeter"
         Tab(2).Control(22)=   "lblIntervalDays"
         Tab(2).Control(23)=   "lblCycleType"
         Tab(2).Control(24)=   "lblPriority"
         Tab(2).Control(25)=   "lblTaskDesc"
         Tab(2).ControlCount=   26
         Begin VB.TextBox txtTaskMiscCommentsD 
            Height          =   765
            Left            =   -73560
            Locked          =   -1  'True
            MultiLine       =   -1  'True
            TabIndex        =   10
            TabStop         =   0   'False
            Top             =   2040
            Width           =   6495
         End
         Begin VB.Label lblWorkDueDateD 
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
            Left            =   -73440
            TabIndex        =   134
            Top             =   1560
            Width           =   1335
         End
         Begin VB.Label lblWorkDueWhenMeterReadsD 
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
            Left            =   -68880
            TabIndex        =   133
            Top             =   1320
            Width           =   1335
         End
         Begin VB.Label lblWorkDueDate 
            Alignment       =   1  'Right Justify
            Caption         =   "Work Due Date"
            Height          =   255
            Left            =   -74760
            TabIndex        =   132
            Top             =   1560
            Width           =   1215
         End
         Begin VB.Label lblWorkDueWhenMeterReads 
            Alignment       =   1  'Right Justify
            Caption         =   "Work Due When Meter Reads"
            Height          =   255
            Left            =   -71280
            TabIndex        =   131
            Top             =   1320
            Width           =   2295
         End
         Begin VB.Label lblCreatedbyD 
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
            Left            =   -73440
            TabIndex        =   128
            Top             =   1320
            Width           =   1335
         End
         Begin VB.Label Label1 
            Alignment       =   1  'Right Justify
            Caption         =   "Created by"
            Height          =   255
            Left            =   -74760
            TabIndex        =   127
            Top             =   1320
            Width           =   1215
         End
         Begin VB.Label lblMechHpD 
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
            Left            =   4320
            TabIndex        =   126
            Top             =   600
            Width           =   735
         End
         Begin VB.Label lblTaskToolsRequiredD 
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
            Left            =   -73440
            TabIndex        =   124
            Top             =   1800
            Width           =   6375
         End
         Begin VB.Label lblTaskLoToD 
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
            Left            =   -68880
            TabIndex        =   123
            Top             =   840
            Width           =   1575
         End
         Begin VB.Label lblTaskLastWorkedMeterD 
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
            Left            =   -68880
            TabIndex        =   122
            Top             =   1080
            Width           =   1215
         End
         Begin VB.Label lblTaskLastWorkedDateD 
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
            Left            =   -73440
            TabIndex        =   121
            Top             =   1080
            Width           =   1335
         End
         Begin VB.Label lblTaskIntervalDaysD 
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
            Left            =   -68880
            TabIndex        =   120
            Top             =   600
            Width           =   1215
         End
         Begin VB.Label lblTaskIntervalMeterD 
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
            Left            =   -73440
            TabIndex        =   119
            Top             =   840
            Width           =   1215
         End
         Begin VB.Label lblTaskPriorityD 
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
            Left            =   -71160
            TabIndex        =   118
            Top             =   600
            Width           =   1215
         End
         Begin VB.Label lblTaskCycleTypeD 
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
            Left            =   -73440
            TabIndex        =   117
            Top             =   600
            Width           =   1455
         End
         Begin VB.Label lblTaskTaskDescD 
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
            Left            =   -73440
            TabIndex        =   116
            Top             =   360
            Width           =   6255
         End
         Begin VB.Label lblMechBelt2 
            Alignment       =   1  'Right Justify
            Caption         =   "Belt2"
            Height          =   255
            Left            =   3840
            TabIndex        =   115
            Top             =   1560
            Width           =   375
         End
         Begin VB.Label lblMechBelt1 
            Alignment       =   1  'Right Justify
            Caption         =   "Belt1"
            Height          =   255
            Left            =   600
            TabIndex        =   114
            Top             =   1560
            Width           =   375
         End
         Begin VB.Label lblMechAirFilter 
            Alignment       =   1  'Right Justify
            Caption         =   "Air Filt"
            Height          =   255
            Left            =   3720
            TabIndex        =   113
            Top             =   1320
            Width           =   495
         End
         Begin VB.Label lblMechOilFilter 
            Alignment       =   1  'Right Justify
            Caption         =   "Oil Filt"
            Height          =   255
            Left            =   480
            TabIndex        =   112
            Top             =   1320
            Width           =   495
         End
         Begin VB.Label lblMechOil 
            Alignment       =   1  'Right Justify
            Caption         =   "Oil"
            Height          =   255
            Left            =   3960
            TabIndex        =   111
            Top             =   1080
            Width           =   255
         End
         Begin VB.Label lblMechSerial 
            Alignment       =   1  'Right Justify
            Caption         =   "serial"
            Height          =   255
            Left            =   480
            TabIndex        =   110
            Top             =   360
            Width           =   495
         End
         Begin VB.Label lblMechID 
            Alignment       =   1  'Right Justify
            Caption         =   "id"
            Height          =   255
            Left            =   2880
            TabIndex        =   109
            Top             =   360
            Width           =   255
         End
         Begin VB.Label lblMechModel 
            Alignment       =   1  'Right Justify
            Caption         =   "model"
            Height          =   255
            Left            =   5160
            TabIndex        =   108
            Top             =   360
            Width           =   495
         End
         Begin VB.Label lblMechFrame 
            Alignment       =   1  'Right Justify
            Caption         =   "frame"
            Height          =   255
            Left            =   480
            TabIndex        =   107
            Top             =   600
            Width           =   495
         End
         Begin VB.Label lblMechImpSz 
            Alignment       =   1  'Right Justify
            Caption         =   "imp sz"
            Height          =   255
            Left            =   2040
            TabIndex        =   106
            Top             =   600
            Width           =   495
         End
         Begin VB.Label lblMechHp 
            Alignment       =   1  'Right Justify
            Caption         =   "hp"
            Height          =   255
            Left            =   3960
            TabIndex        =   105
            Top             =   600
            Width           =   255
         End
         Begin VB.Label lblMechRpm 
            Alignment       =   1  'Right Justify
            Caption         =   "rpm"
            Height          =   255
            Left            =   5280
            TabIndex        =   104
            Top             =   600
            Width           =   375
         End
         Begin VB.Label lblMechCap 
            Alignment       =   1  'Right Justify
            Caption         =   "cap"
            Height          =   255
            Left            =   6600
            TabIndex        =   103
            Top             =   600
            Width           =   375
         End
         Begin VB.Label lblMechtdh 
            Alignment       =   1  'Right Justify
            Caption         =   "tdh"
            Height          =   255
            Left            =   2280
            TabIndex        =   102
            Top             =   840
            Width           =   255
         End
         Begin VB.Label lblMechSize 
            Alignment       =   1  'Right Justify
            Caption         =   "size"
            Height          =   255
            Left            =   600
            TabIndex        =   101
            Top             =   840
            Width           =   375
         End
         Begin VB.Label lblMechCatNo 
            Alignment       =   1  'Right Justify
            Caption         =   "cat no"
            Height          =   255
            Left            =   3720
            TabIndex        =   100
            Top             =   840
            Width           =   495
         End
         Begin VB.Label lblMechMinRpm 
            Alignment       =   1  'Right Justify
            Caption         =   "min rpm"
            Height          =   255
            Left            =   360
            TabIndex        =   99
            Top             =   1080
            Width           =   615
         End
         Begin VB.Label lblMechMaxRpm 
            Alignment       =   1  'Right Justify
            Caption         =   "max rpm"
            Height          =   255
            Left            =   6360
            TabIndex        =   98
            Top             =   840
            Width           =   615
         End
         Begin VB.Label lblMechcfm 
            Alignment       =   1  'Right Justify
            Caption         =   "cfm"
            Height          =   255
            Left            =   2160
            TabIndex        =   97
            Top             =   1080
            Width           =   375
         End
         Begin VB.Label lblMechPipeSize 
            Alignment       =   1  'Right Justify
            Caption         =   "Pipe Size(s)"
            Height          =   255
            Left            =   120
            TabIndex        =   96
            Top             =   1800
            Width           =   855
         End
         Begin VB.Label lblMechPipeType 
            Alignment       =   1  'Right Justify
            Caption         =   "Type"
            Height          =   255
            Left            =   5040
            TabIndex        =   95
            Top             =   1800
            Width           =   375
         End
         Begin VB.Label lblMechNoValvesTypes 
            Caption         =   "No. Valves and Types"
            Height          =   255
            Left            =   240
            TabIndex        =   94
            Top             =   2760
            Width           =   1695
         End
         Begin VB.Label lblMechMiscNPData 
            Alignment       =   1  'Right Justify
            Caption         =   "NP Data"
            Height          =   255
            Left            =   360
            TabIndex        =   93
            Top             =   2280
            Width           =   615
         End
         Begin VB.Label lblMechRecomSpareParts 
            Alignment       =   1  'Right Justify
            Caption         =   "Rec. Parts"
            Height          =   255
            Left            =   120
            TabIndex        =   92
            Top             =   2040
            Width           =   855
         End
         Begin VB.Label lblMechSerialD 
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
            TabIndex        =   91
            Top             =   360
            Width           =   1695
         End
         Begin VB.Label lblMechImpSzD 
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
            Left            =   2640
            TabIndex        =   90
            Top             =   600
            Width           =   1215
         End
         Begin VB.Label lblMechRpmD 
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
            Left            =   5760
            TabIndex        =   89
            Top             =   600
            Width           =   735
         End
         Begin VB.Label lblMechCapD 
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
            Left            =   7080
            TabIndex        =   88
            Top             =   600
            Width           =   855
         End
         Begin VB.Label lblMechSizeD 
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
            TabIndex        =   87
            Top             =   840
            Width           =   1095
         End
         Begin VB.Label lblMechTdhD 
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
            Left            =   2640
            TabIndex        =   86
            Top             =   840
            Width           =   855
         End
         Begin VB.Label lblMechCatNoD 
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
            Left            =   4320
            TabIndex        =   85
            Top             =   840
            Width           =   1695
         End
         Begin VB.Label lblMechMaxRpmD 
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
            Left            =   7080
            TabIndex        =   84
            Top             =   840
            Width           =   735
         End
         Begin VB.Label lblMechMinRpmD 
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
            TabIndex        =   83
            Top             =   1080
            Width           =   735
         End
         Begin VB.Label lblMechCfmD 
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
            Left            =   2640
            TabIndex        =   82
            Top             =   1080
            Width           =   855
         End
         Begin VB.Label lblMechOilD 
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
            Left            =   4320
            TabIndex        =   81
            Top             =   1080
            Width           =   2655
         End
         Begin VB.Label lblMechOilFilterD 
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
            TabIndex        =   80
            Top             =   1320
            Width           =   2655
         End
         Begin VB.Label lblMechAirFilterD 
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
            Left            =   4320
            TabIndex        =   79
            Top             =   1320
            Width           =   2655
         End
         Begin VB.Label lblMechBelt1D 
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
            TabIndex        =   78
            Top             =   1560
            Width           =   2655
         End
         Begin VB.Label lblMechBelt2D 
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
            Left            =   4320
            TabIndex        =   77
            Top             =   1560
            Width           =   2655
         End
         Begin VB.Label lblMechPipeSizeD 
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
            TabIndex        =   76
            Top             =   1800
            Width           =   3855
         End
         Begin VB.Label lblMechPipeTypeD 
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
            Left            =   5520
            TabIndex        =   75
            Top             =   1800
            Width           =   2630
         End
         Begin VB.Label lblMechNoValvesTypesD 
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
            Left            =   1920
            TabIndex        =   74
            Top             =   2760
            Width           =   3855
         End
         Begin VB.Label lblMechMiscNPDataD 
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
            Left            =   1080
            TabIndex        =   73
            Top             =   2280
            Width           =   6975
         End
         Begin VB.Label lblMechRecomSparePartsD 
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
            TabIndex        =   72
            Top             =   2040
            Width           =   3855
         End
         Begin VB.Label lblMechFrameD 
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
            TabIndex        =   71
            Top             =   600
            Width           =   975
         End
         Begin VB.Label lblMechModelD 
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
            Left            =   5760
            TabIndex        =   70
            Top             =   360
            Width           =   1935
         End
         Begin VB.Label lblMechIDD 
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
            Left            =   3240
            TabIndex        =   69
            Top             =   360
            Width           =   1695
         End
         Begin VB.Label lblElecFrame 
            Alignment       =   1  'Right Justify
            Caption         =   "frame"
            Height          =   255
            Left            =   -74760
            TabIndex        =   68
            Top             =   600
            Width           =   495
         End
         Begin VB.Label lblElecModel 
            Alignment       =   1  'Right Justify
            Caption         =   "model"
            Height          =   255
            Left            =   -69840
            TabIndex        =   67
            Top             =   360
            Width           =   495
         End
         Begin VB.Label lblElecID 
            Alignment       =   1  'Right Justify
            Caption         =   "id"
            Height          =   255
            Left            =   -72360
            TabIndex        =   66
            Top             =   360
            Width           =   255
         End
         Begin VB.Label lblElecSerial 
            Alignment       =   1  'Right Justify
            Caption         =   "serial"
            Height          =   255
            Left            =   -74760
            TabIndex        =   65
            Top             =   360
            Width           =   495
         End
         Begin VB.Label lblElecCatNo 
            Alignment       =   1  'Right Justify
            Caption         =   "cat no"
            Height          =   255
            Left            =   -72600
            TabIndex        =   64
            Top             =   600
            Width           =   495
         End
         Begin VB.Label lblElecHp 
            Alignment       =   1  'Right Justify
            Caption         =   "hp"
            Height          =   255
            Left            =   -69600
            TabIndex        =   63
            Top             =   600
            Width           =   255
         End
         Begin VB.Label lblElecRpm 
            Alignment       =   1  'Right Justify
            Caption         =   "rpm"
            Height          =   255
            Left            =   -68400
            TabIndex        =   62
            Top             =   600
            Width           =   375
         End
         Begin VB.Label lblElecHz 
            Alignment       =   1  'Right Justify
            Caption         =   "hz"
            Height          =   255
            Left            =   -74520
            TabIndex        =   61
            Top             =   840
            Width           =   255
         End
         Begin VB.Label lblElecPhs 
            Alignment       =   1  'Right Justify
            Caption         =   "phs"
            Height          =   255
            Left            =   -72480
            TabIndex        =   60
            Top             =   840
            Width           =   375
         End
         Begin VB.Label lblElecSf 
            Alignment       =   1  'Right Justify
            Caption         =   "sf"
            Height          =   255
            Left            =   -71400
            TabIndex        =   59
            Top             =   840
            Width           =   255
         End
         Begin VB.Label lblElecV 
            Alignment       =   1  'Right Justify
            Caption         =   "v"
            Height          =   255
            Left            =   -69600
            TabIndex        =   58
            Top             =   840
            Width           =   135
         End
         Begin VB.Label lblElecAmp 
            Alignment       =   1  'Right Justify
            Caption         =   "amp"
            Height          =   255
            Left            =   -74640
            TabIndex        =   57
            Top             =   1080
            Width           =   375
         End
         Begin VB.Label lblElecDuty 
            Alignment       =   1  'Right Justify
            Caption         =   "duty"
            Height          =   255
            Left            =   -72480
            TabIndex        =   56
            Top             =   1080
            Width           =   375
         End
         Begin VB.Label lblElecInslCl 
            Alignment       =   1  'Right Justify
            Caption         =   "insl cl"
            Height          =   255
            Left            =   -69840
            TabIndex        =   55
            Top             =   1080
            Width           =   495
         End
         Begin VB.Label lblElecDesign 
            Alignment       =   1  'Right Justify
            Caption         =   "design"
            Height          =   255
            Left            =   -68400
            TabIndex        =   54
            Top             =   1080
            Width           =   495
         End
         Begin VB.Label lblElecShaftEndBrg 
            Alignment       =   1  'Right Justify
            Caption         =   "shaft end brg"
            Height          =   255
            Left            =   -73800
            TabIndex        =   53
            Top             =   1320
            Width           =   975
         End
         Begin VB.Label lblElecOppEndBrg 
            Alignment       =   1  'Right Justify
            Caption         =   "opp. end brg"
            Height          =   255
            Left            =   -70320
            TabIndex        =   52
            Top             =   1320
            Width           =   975
         End
         Begin VB.Label lblElecMiscNPData 
            Alignment       =   1  'Right Justify
            Caption         =   "Misc. NP Data"
            Height          =   255
            Left            =   -73920
            TabIndex        =   51
            Top             =   1560
            Width           =   1095
         End
         Begin VB.Label lblElecRecomSpareParts 
            Alignment       =   1  'Right Justify
            Caption         =   "Recommended Spare Parts"
            Height          =   255
            Left            =   -74880
            TabIndex        =   50
            Top             =   2160
            Width           =   2055
         End
         Begin VB.Label lblElecIDD 
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
            Left            =   -72000
            TabIndex        =   49
            Top             =   360
            Width           =   1695
         End
         Begin VB.Label lblElecModelD 
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
            Left            =   -69240
            TabIndex        =   48
            Top             =   360
            Width           =   1935
         End
         Begin VB.Label lblElecSerialD 
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
            Left            =   -74160
            TabIndex        =   47
            Top             =   360
            Width           =   1695
         End
         Begin VB.Label lblElecFrameD 
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
            Left            =   -74160
            TabIndex        =   46
            Top             =   600
            Width           =   975
         End
         Begin VB.Label lblElecCatNoD 
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
            Left            =   -72000
            TabIndex        =   45
            Top             =   600
            Width           =   1455
         End
         Begin VB.Label lblElecHpD 
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
            Left            =   -69240
            TabIndex        =   44
            Top             =   600
            Width           =   735
         End
         Begin VB.Label lblElecRpmD 
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
            Left            =   -67920
            TabIndex        =   43
            Top             =   600
            Width           =   855
         End
         Begin VB.Label lblElecHzD 
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
            Left            =   -74160
            TabIndex        =   42
            Top             =   840
            Width           =   495
         End
         Begin VB.Label lblElecPhsD 
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
            Left            =   -72000
            TabIndex        =   41
            Top             =   840
            Width           =   375
         End
         Begin VB.Label lblElecSfD 
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
            Left            =   -71040
            TabIndex        =   40
            Top             =   840
            Width           =   615
         End
         Begin VB.Label lblElecDutyD 
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
            Left            =   -72000
            TabIndex        =   39
            Top             =   1080
            Width           =   735
         End
         Begin VB.Label lblElecVD 
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
            Left            =   -69240
            TabIndex        =   38
            Top             =   840
            Width           =   1575
         End
         Begin VB.Label lblElecAmpD 
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
            Left            =   -74160
            TabIndex        =   37
            Top             =   1080
            Width           =   1575
         End
         Begin VB.Label lblElecInslClD 
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
            Left            =   -69240
            TabIndex        =   36
            Top             =   1080
            Width           =   495
         End
         Begin VB.Label lblElecDesignD 
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
            Left            =   -67800
            TabIndex        =   35
            Top             =   1080
            Width           =   495
         End
         Begin VB.Label lblElecShaftEndBrgD 
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
            Left            =   -72720
            TabIndex        =   34
            Top             =   1320
            Width           =   1695
         End
         Begin VB.Label lblElecOppEndBrgD 
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
            Left            =   -69240
            TabIndex        =   33
            Top             =   1320
            Width           =   1695
         End
         Begin VB.Label lblElecRecomSparePartsD 
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
            Left            =   -72720
            TabIndex        =   32
            Top             =   2160
            Width           =   3855
         End
         Begin VB.Label lblElecMiscNPDataD 
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
            Left            =   -72720
            TabIndex        =   31
            Top             =   1560
            Width           =   5535
         End
         Begin VB.Label lblMiscComments 
            Alignment       =   1  'Right Justify
            Caption         =   "Comments"
            Height          =   255
            Left            =   -74880
            TabIndex        =   30
            Top             =   2040
            Width           =   1215
         End
         Begin VB.Label lblLoTo 
            Alignment       =   1  'Right Justify
            Caption         =   "Lockout/Tagout"
            Height          =   255
            Left            =   -70200
            TabIndex        =   29
            Top             =   840
            Width           =   1215
         End
         Begin VB.Label lblLastWorkedDate 
            Alignment       =   1  'Right Justify
            Caption         =   "Last Worked Date"
            Height          =   255
            Left            =   -74880
            TabIndex        =   28
            Top             =   1080
            Width           =   1335
         End
         Begin VB.Label lblLastWorkedMeterReading 
            Alignment       =   1  'Right Justify
            Caption         =   "Last Worked Meter Reading"
            Height          =   255
            Left            =   -71040
            TabIndex        =   27
            Top             =   1080
            Width           =   2055
         End
         Begin VB.Label lblToolsRequired 
            Alignment       =   1  'Right Justify
            Caption         =   "Tools Required"
            Height          =   255
            Left            =   -74760
            TabIndex        =   26
            Top             =   1800
            Width           =   1215
         End
         Begin VB.Label lblIntervalMeter 
            Alignment       =   1  'Right Justify
            Caption         =   "Interval Meter"
            Height          =   255
            Left            =   -74640
            TabIndex        =   25
            Top             =   840
            Width           =   1095
         End
         Begin VB.Label lblIntervalDays 
            Alignment       =   1  'Right Justify
            Caption         =   "Interval Days"
            Height          =   255
            Left            =   -69960
            TabIndex        =   24
            Top             =   600
            Width           =   975
         End
         Begin VB.Label lblCycleType 
            Alignment       =   1  'Right Justify
            Caption         =   "Cycle Type"
            Height          =   255
            Left            =   -74760
            TabIndex        =   23
            Top             =   600
            Width           =   1215
         End
         Begin VB.Label lblPriority 
            Alignment       =   1  'Right Justify
            Caption         =   "Priority"
            Height          =   255
            Left            =   -71880
            TabIndex        =   22
            Top             =   600
            Width           =   615
         End
         Begin VB.Label lblTaskDesc 
            Alignment       =   1  'Right Justify
            Caption         =   "WO Description"
            Height          =   255
            Left            =   -74760
            TabIndex        =   21
            Top             =   360
            Width           =   1215
         End
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
         TabIndex        =   130
         Top             =   0
         Width           =   2775
      End
      Begin VB.Label lblComments 
         Alignment       =   1  'Right Justify
         Caption         =   "Comments:"
         Height          =   255
         Left            =   570
         TabIndex        =   19
         Top             =   1920
         Width           =   975
      End
      Begin VB.Label lblMaterialsCost 
         Alignment       =   1  'Right Justify
         Caption         =   "Materials Cost $:"
         Height          =   255
         Left            =   6050
         TabIndex        =   18
         Top             =   1560
         Width           =   1215
      End
      Begin VB.Label lblLaborCost 
         Alignment       =   1  'Right Justify
         Caption         =   "Labor:"
         Height          =   255
         Left            =   4680
         TabIndex        =   16
         Top             =   1560
         Width           =   495
      End
      Begin VB.Label lblCompletedBy 
         Alignment       =   1  'Right Justify
         Caption         =   "Completed by:"
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
         Left            =   330
         TabIndex        =   15
         Top             =   1560
         Width           =   1215
      End
      Begin VB.Label lblDateCompleted 
         Alignment       =   1  'Right Justify
         Caption         =   "Date Completed:"
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
         Left            =   90
         TabIndex        =   14
         Top             =   1200
         Width           =   1455
      End
      Begin VB.Label lblMeterReadingatWorkCompletion 
         Alignment       =   1  'Right Justify
         Caption         =   "Meter Read at Completion:"
         Height          =   255
         Left            =   5040
         TabIndex        =   13
         Top             =   1200
         Width           =   1935
      End
      Begin VB.Label lblTaskID 
         Alignment       =   1  'Right Justify
         Caption         =   "Work Order:"
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
         Left            =   330
         TabIndex        =   12
         Top             =   840
         Width           =   1215
      End
      Begin VB.Label lblEquipID 
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
         Left            =   450
         TabIndex        =   11
         Top             =   480
         Width           =   1095
      End
   End
   Begin VB.Frame FramGrid 
      Height          =   5895
      Left            =   240
      TabIndex        =   9
      Top             =   0
      Width           =   8415
      Begin MSDataGridLib.DataGrid DGridWO 
         Height          =   5535
         Left            =   120
         TabIndex        =   125
         Top             =   240
         Width           =   8175
         _ExtentX        =   14420
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
         TabIndex        =   129
         Top             =   0
         Width           =   1815
      End
   End
End
Attribute VB_Name = "frmWorkOrder"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
Option Explicit

Dim rsWORetrieve As ADODB.Recordset
Public rsEquipWO As ADODB.Recordset
Public rsTaskWO As ADODB.Recordset
Dim ans As Integer
Dim intStatus As Integer ' 2 - add, 1 - update
'Dim intTypeWO As Integer ' 1 - new, 2 - existing recordset
Dim intEquipIDStore, intTaskIDStore As Integer
Dim strEquipIDStore, strTaskIDStore As String

' ***************************************
' Used for searching WOs
' ***************************************
Dim strSearchEquipKey, strSearchEquipDesc As String
Dim strSearchTaskDesc, strSearchMiscComments, strSearchComments As String
Dim strSearchInitial, strSearchDate1, strSearchDate2 As String
Dim strState, strSearchOpt As String

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

Private Sub cboEquipID_KeyUp(KeyCode As Integer, Shift As Integer)
    Dim intKey As Integer
    Dim intValue As Integer

On Error GoTo errorhandler

    intKey = KeyCode
    If (intKey < 48 Or intKey > 57) And intKey <> 119 And intKey <> 121 And intKey <> 120 And intKey <> 122 And intKey <> 13 Then
        MsgBox "Equipment field can only have numbers"
        If intEquipIDStore <> 0 Then
            Me.cboEquipID.Text = intEquipIDStore
        End If
    End If
    If intStatus <> 2 Then
        MsgBox "Value can not be changed after History is created and saved"
        If intEquipIDStore <> 0 Then
            Me.cboEquipID.Text = intEquipIDStore
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - cboEquipID_KeyUp: Description - " & Err.Description
End Sub

Private Sub cboEquipID_Validate(Cancel As Boolean)
    Dim ans As Integer
    Dim intPos As Integer
    Dim strNum As String
    Dim intLen As Integer
    Dim strEquipID As String
    Dim intEquipID As Integer

On Error GoTo errorhandler

    
    If cboEquipID.Text = "" Then
        Beep
        ans = MsgBox("Please select an equipment from the dropdown.", vbOKOnly, "WOS")
        Cancel = True
    Else
        strEquipID = cboEquipID.Text
        strEquipID = Trim(strEquipID)
        intLen = Len(strEquipID)
        intPos = InStr(strEquipID, " - ")
        If intPos = 0 Then
            strNum = strEquipID
        Else
            strNum = Left(strEquipID, intPos - 1)
        End If
        intEquipID = CInt(strNum)
        rsEquipWO.MoveFirst
        rsEquipWO.Find ("equip_id = " & intEquipID)
        If rsEquipWO.EOF = True Or rsEquipWO.BOF = True Then
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
                    MsgBox "Value can not be changed after a History is created and saved"
                    Me.cboEquipID.Text = intEquipIDStore
                End If
                'ans = MsgBox("Are you sure that you want to change equipment? Every thing has to be reset if you continue.", vbYesNo)
                'If ans = 6 Then
                '    Clear
                '    rsEquipWO.Find ("equip_id = " & intEquipID)
                '    FillLabelsEquip
                '    PopTaskList intEquipID
                '    ClearTask
                'Else
                '    rsEquipWO.MoveFirst
                '    rsEquipWO.Find ("equip_id = " & intEquipIDStore)
                '    cboEquipID.Text = rsEquipWO!equip_id
                    'FillLabelsEquip
                    'ClearTask
                '    Cancel = True
                'End If
            ElseIf intEquipIDStore = 0 Then
                rsEquipWO.Find ("equip_id = " & intEquipID)
                FillLabelsEquip
                PopTaskList intEquipID
                ClearTask
            End If
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - cboEquipID_Validate: Description - " & Err.Description
End Sub

Public Function Add()

    Dim intEquipL As Integer
    
On Error GoTo errorhandler

    Clear
    txtCount = "New Record"
    FormView
    MDIFormWOS.AddMode
    If intTypeWO <> 1 Then
        intTypeWO = 2
        Me.cboEquipID.SetFocus
    Else
        intEquipL = PopEquipList(0)
    End If
    ' intStatus will be 2 for add
    intStatus = 2
    Me.lblPlantName.Caption = intPlantPass & " - " & strPlantPass
    Me.lblPlantNameG.Caption = intPlantPass & " - " & strPlantPass
Exit Function
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - Add: Description - " & Err.Description
End Function

Public Function UpdateTaskWO(ByVal strmeter As String, ByVal strDate As String) As Integer
'with the update of the History we need to save the information for
' Work Order(task) so that it can be used in the future to calculate the due date
' or the due meter reading
    Dim strSQL, strFind, strCycle As String
    Dim rsupdateTsk As ADODB.Recordset
    Dim rsFindValues As ADODB.Recordset
    Dim intGO As Integer ' if 1 - do it , if 2 - don't do it
    Dim intIntervalMeter, intIntervalDays As Long 'integer
    Dim strDueMeter As String
    Dim dtDateComp, dtDateDue As Date

On Error GoTo errorhandler

    
    strFind = "SELECT interval_days, interval_meter, cycle_type from task where task_id = " & rsWORetrieve!task_id
    Set rsFindValues = RecordsetTask(strFind)
    strCycle = rsFindValues!cycle_type
    Select Case strCycle
    Case "Meter Cycle"
        intIntervalMeter = rsFindValues!interval_meter
        Set rsFindValues = Nothing
        strDueMeter = Str(CLng(strmeter) + intIntervalMeter)
        If strmeter <> "X" And strDate = "X" Then
            strSQL = "UPDATE task set last_worked_meter_reading = " & strmeter & ", work_due_when_meter_reads = " & strDueMeter & " where task_id = " & rsWORetrieve!task_id
            intGO = 1
        ElseIf strmeter = "X" And strDate = "X" Then
            intGO = 2
        Else
            strSQL = "UPDATE task set last_worked_date = '" & strDate & "' , last_worked_meter_reading = " & strmeter & ", work_due_when_meter_reads = " & strDueMeter & " where task_id = " & rsWORetrieve!task_id
            intGO = 1
        End If
        
    Case "Days Cycle"
        intIntervalDays = rsFindValues!interval_days
        Set rsFindValues = Nothing
        dtDateComp = Format(strDate, "mm/dd/yy")
        
        dtDateDue = DateAdd("d", intIntervalDays, dtDateComp)
        If strmeter = "X" And strDate <> "X" Then
            strSQL = "UPDATE task set last_worked_date = '" & strDate & "', work_due_date = '" & dtDateDue & "' where task_id = " & rsWORetrieve!task_id
            intGO = 1
        ElseIf strmeter = "X" And strDate = "X" Then
            intGO = 2
        Else
            strSQL = "UPDATE task set last_worked_date = '" & strDate & "' , last_worked_meter_reading = " & strmeter & ", work_due_date = '" & dtDateDue & "' where task_id = " & rsWORetrieve!task_id
            intGO = 1
        End If
    Case Else
        Set rsFindValues = Nothing
        If strmeter = "X" And strDate <> "X" Then
            strSQL = "UPDATE task set last_worked_date = '" & strDate & "' where task_id = " & rsWORetrieve!task_id
            intGO = 1
        ElseIf strmeter <> "X" And strDate = "X" Then
            strSQL = "UPDATE task set last_worked_meter_reading = " & strmeter & " where task_id = " & rsWORetrieve!task_id
            intGO = 1
        ElseIf strmeter = "X" And strDate = "X" Then
            intGO = 2
        Else
            strSQL = "UPDATE task set last_worked_date = '" & strDate & "' , last_worked_meter_reading = " & strmeter & " where task_id = " & rsWORetrieve!task_id
            intGO = 1
        End If
    End Select
    If intGO = 1 Then
        Set rsupdateTsk = RecordsetTask(strSQL)
        Set rsupdateTsk = Nothing
    End If
    UpdateTaskWO = 1
Exit Function
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - UpdateTaskWO: Description - " & Err.Description
End Function

Public Sub Clear()

On Error GoTo errorhandler

    If intTypeWO <> 1 Then
        ChangedData
        intTypeWO = 0 ' Added 4-10
    End If
        
    ClearTask
    ClearEquip
    'Me.cboEquipID.SetFocus
    cboEquipID.Text = ""
    cboTaskID.Text = ""
    txtMeterReadingAtCompletion = ""
    txtDateCompleted = ""
    txtCompletedBy = ""
    txtLabor = ""
    txtMaterialsCost = ""
    txtComments = ""
    
    intEquipIDStore = 0
    strEquipIDStore = ""
    intTaskIDStore = 0
    strTaskIDStore = ""
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - Clear: Description - " & Err.Description
End Sub

Public Sub Delete()

On Error GoTo errorhandler

    ans = 0
    FormView
    ans = MsgBox("Are you sure that you want to delete this record?", vbYesNo, "WOS")
    If ans = 6 Then
        rsWORetrieve.Delete
        rsWORetrieve.MoveNext
        If rsWORetrieve.RecordCount < 1 Then
            intTypeWO = 1
            Add
        Else
            If rsWORetrieve.EOF Then
                rsWORetrieve.MovePrevious
            End If
            FillFields
            'CalculateFields rsWORetrieve!task_id
            rsEquipWO.MoveFirst
            rsEquipWO.Find ("equip_id = " & rsWORetrieve!equip_id)
            FillLabelsEquip
            rsTaskWO.MoveFirst
            rsTaskWO.Find ("task_id = " & rsWORetrieve!task_id)
            FillLabelsTask
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - Delete: Description - " & Err.Description
End Sub

Public Sub RefreshRec()

On Error GoTo errorhandler

    Unload Me
    intTypeWO = 0
    frmPlant.CheckAll "wo"
    'frmWorkOrder.Show
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - RefreshRec: Description - " & Err.Description
End Sub

Public Sub Save()
    Dim intResult As Integer
    Dim strSQL As String
    
On Error GoTo errorhandler
    FormView
    intResult = ValidateWO
    
    If intResult = 0 Then
        If intTypeWO = 1 Then
            ' do not check if some thing is changed
            strSQL = "Select * from work_order where plant_fk <> 0"
            Set rsWORetrieve = RecordsetWO(strSQL)
            rsWORetrieve.AddNew
            intTypeWO = 0
        ElseIf intTypeWO = 2 Then
            rsWORetrieve.AddNew
            intTypeWO = 0
        End If
        AddUpdateWO
        If intStatus = 2 Then
            Cancel
        End If
        intStatus = 0
        'MDIFormWOS.cmdAdd.Enabled = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - Save: Description - " & Err.Description
End Sub

Public Sub AddUpdateWO()
    Dim strEquipID, strEquipNum, strTaskID, strTaskNum As String
    Dim intLenEquip, intLenTask As Integer
    Dim intPosEquip, intPosTask As Integer
    
On Error GoTo errorhandler

    ans = 0
    
    If intStatus = 2 Then
        'rsWORetrieve.AddNew
    Else
        rsWORetrieve.Update
    End If
    
    ' getting equipment_id value
    strEquipID = cboEquipID.Text
    strEquipID = Trim(strEquipID)
    intLenEquip = Len(strEquipID)
    intPosEquip = InStr(strEquipID, " - ")
    
    If intPosEquip = 0 Then
        strEquipNum = strEquipID
    Else
        strEquipNum = Left(strEquipID, intPosEquip - 1)
    End If
    
    rsWORetrieve!equip_id = strEquipNum
        
    ' getting task_id value
    strTaskID = cboTaskID.Text
    strTaskID = Trim(strTaskID)
    intLenTask = Len(strTaskID)
    intPosTask = InStr(strTaskID, " - ")
    
    If intPosTask = 0 Then
        strTaskNum = strTaskID
    Else
        strTaskNum = Left(strTaskID, intPosTask - 1)
    End If
    
    
    rsWORetrieve!task_id = strTaskNum
    
    Dim intPlant As Integer
    rsTaskWO.Find ("task_id = " & rsWORetrieve!task_id)
    intPlant = rsTaskWO!plant_fk
    rsWORetrieve!plant_fk = intPlant
    If txtMeterReadingAtCompletion.Text <> "" Then
        rsWORetrieve!meter_reading_at_work_completion = txtMeterReadingAtCompletion.Text
    Else
        rsWORetrieve!meter_reading_at_work_completion = Null
    End If
    If txtDateCompleted.Text <> "" Then
        ' does it work if I place "" around the text from txtdatecompleted?
        rsWORetrieve!date_work_completed = txtDateCompleted.Text
    Else
        rsWORetrieve!date_work_completed = Null
    End If
    rsWORetrieve!completed_by = txtCompletedBy.Text
    If txtLabor.Text <> "" Then
        rsWORetrieve!labor = txtLabor.Text
    Else
        rsWORetrieve!labor = Null
    End If
    If txtMaterialsCost.Text <> "" Then
        rsWORetrieve!materials_cost = txtMaterialsCost.Text
    Else
        rsWORetrieve!materials_cost = Null
    End If
    rsWORetrieve!Comments = txtComments.Text
    
    rsWORetrieve.MoveNext
    rsWORetrieve.MovePrevious
    
    Dim strDateCompleted, strMeterReading As String
    If txtMeterReadingAtCompletion.Text <> "" Then
        strMeterReading = txtMeterReadingAtCompletion.Text
    Else
        strMeterReading = "X"
    End If
    If txtDateCompleted.Text <> "" Then
        strDateCompleted = txtDateCompleted.Text
    Else
        strDateCompleted = "X"
    End If
    Dim intupdatetsk As Integer
    intupdatetsk = UpdateTaskWO(strMeterReading, strDateCompleted)
    
    If intStatus = 2 Then
        ans = MsgBox("A record has been added.", vbOKOnly, "WOS")
    Else
        ans = MsgBox("The record has been updated.", vbOKOnly, "WOS")
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - AddUpdateWO: Description - " & Err.Description
End Sub

Public Sub FirstRec()

On Error GoTo errorhandler

    ChangedData
    rsWORetrieve.MoveFirst
    PopTaskList rsWORetrieve!equip_id
    ClearTask
    FillFields
    'CalculateFields rsWORetrieve!task_id
    rsEquipWO.MoveFirst
    rsEquipWO.Find ("equip_id = " & rsWORetrieve!equip_id)
    FillLabelsEquip
    rsTaskWO.MoveFirst
    rsTaskWO.Find ("task_id = " & rsWORetrieve!task_id)
    FillLabelsTask
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - FirstRec: Description - " & Err.Description
End Sub

Public Sub LastRec()

On Error GoTo errorhandler

    ChangedData
    rsWORetrieve.MoveLast
    PopTaskList rsWORetrieve!equip_id
    ClearTask
    FillFields
    'CalculateFields rsWORetrieve!task_id
    rsEquipWO.MoveFirst
    rsEquipWO.Find ("equip_id = " & rsWORetrieve!equip_id)
    FillLabelsEquip
    rsTaskWO.MoveFirst
    rsTaskWO.Find ("task_id = " & rsWORetrieve!task_id)
    FillLabelsTask
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - LastRec: Description - " & Err.Description
End Sub

Public Sub NextRec()

On Error GoTo errorhandler

    ChangedData
    rsWORetrieve.MoveNext
    If rsWORetrieve.EOF Then
        rsWORetrieve.MovePrevious
        ans = MsgBox("Already at the end of the list. Can not move any further.")
    End If
    PopTaskList rsWORetrieve!equip_id
    ClearTask
    FillFields
    'CalculateFields rsWORetrieve!task_id
    rsEquipWO.MoveFirst
    rsEquipWO.Find ("equip_id = " & rsWORetrieve!equip_id)
    FillLabelsEquip
    rsTaskWO.MoveFirst
    rsTaskWO.Find ("task_id = " & rsWORetrieve!task_id)
    FillLabelsTask
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - NextRec: Description - " & Err.Description
End Sub

Public Sub PrevRec()

On Error GoTo errorhandler

    ChangedData
    rsWORetrieve.MovePrevious
    If rsWORetrieve.BOF Then
        rsWORetrieve.MoveNext
        ans = MsgBox("Already at the beginning of the list. Can not move back any more.")
    End If
    PopTaskList rsWORetrieve!equip_id
    ClearTask
    FillFields
    'CalculateFields rsWORetrieve!task_id
    rsEquipWO.MoveFirst
    rsEquipWO.Find ("equip_id = " & rsWORetrieve!equip_id)
    FillLabelsEquip
    rsTaskWO.MoveFirst
    rsTaskWO.Find ("task_id = " & rsWORetrieve!task_id)
    FillLabelsTask
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - PrevRec: Description - " & Err.Description
End Sub

'Private Sub cboTaskID_GotFocus()
'    Dim intLen, intPos As Integer
'
'    intTaskIDStore = 0
'    strTaskIDStore = ""
'    strTaskIDStore = cboTaskID.Text
'    If strTaskIDStore <> "" Then
'        strTaskIDStore = Trim(strTaskIDStore)
'        intLen = Len(strTaskIDStore)
'        intPos = InStr(strTaskIDStore, " - ")
'        If intPos > 0 Then
'            strTaskIDStore = Left(strTaskIDStore, intPos - 1)
'        End If
'        intTaskIDStore = CInt(strTaskIDStore)
'    End If
'End Sub

Private Sub cboTaskID_KeyUp(KeyCode As Integer, Shift As Integer)
    Dim intKey As Integer
    Dim intValue As Integer

On Error GoTo errorhandler

    intKey = KeyCode
    If (intKey < 48 Or intKey > 57) And intKey <> 119 And intKey <> 121 And intKey <> 120 And intKey <> 13 Then
        MsgBox "This field can only have numbers"
        If intTaskIDStore <> 0 Then
            Me.cboTaskID.Text = intTaskIDStore
        End If
    End If
    If intStatus <> 2 Then
        MsgBox "Value can not be changed after a History is created and saved"
        If intTaskIDStore <> 0 Then
            Me.cboTaskID.Text = intTaskIDStore
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - cboTaskID_KeyUp: Description - " & Err.Description
End Sub

Private Sub cboTaskID_Validate(Cancel As Boolean)
    Dim ans As Integer
    Dim intPos As Integer
    Dim strNum As String
    Dim intLen As Integer
    Dim strTaskID As String
    Dim intTaskID As Integer

On Error GoTo errorhandler

    If cboTaskID.Text = "" Then
        Beep
        ans = MsgBox("Please select a Work Order from the dropdown.", vbOKOnly, "WOS")
        Cancel = True
    Else
        strTaskID = cboTaskID.Text
        strTaskID = Trim(strTaskID)
        intLen = Len(strTaskID)
        intPos = InStr(strTaskID, " - ")
        If intPos = 0 Then
            strNum = strTaskID
        Else
            strNum = Left(strTaskID, intPos - 1)
        End If
        intTaskID = CInt(strNum)
        rsTaskWO.MoveFirst
        rsTaskWO.Find ("task_id = " & intTaskID)
        If rsTaskWO.EOF = True Or rsTaskWO.BOF = True Then
            MsgBox "The Work Order you entered is not found in the dropdown."
            Cancel = True
        Else
            'CalculateFields intTaskID
            FillLabelsTask
            If intTaskID <> intTaskIDStore And intTaskIDStore <> 0 Then
                If intStatus <> 2 Then
                    MsgBox "Value can not be changed after a History is created and saved"
                    If intTaskIDStore <> 0 Then
                        Me.cboTaskID.Text = intTaskIDStore
                    End If
                End If
                'ans = MsgBox("Are you sure you want to change Work Order? All the fields has to be reset except equipment info.", vbYesNo)
                'If ans = 6 Then
                '    rsTaskWO.MoveFirst
                '    rsTaskWO.Find ("task_id = " & intTaskID)
                    'CalculateFields (intTaskID)
                '    FillLabelsTask
                'Else
                '    cboTaskID.Text = strNum
                'End If
            End If
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - cboTaskID_Validate: Description - " & Err.Description
End Sub

Private Sub DGridWO_RowColChange(LastRow As Variant, ByVal LastCol As Integer)

On Error GoTo errorhandler

    If FramGrid.Visible = True Then
        PopTaskList rsWORetrieve!equip_id
        ClearTask
        FillFields
        'CalculateFields rsWORetrieve!task_id
        rsEquipWO.MoveFirst
        rsEquipWO.Find ("equip_id = " & rsWORetrieve!equip_id)
        FillLabelsEquip
        rsTaskWO.MoveFirst
        rsTaskWO.Find ("task_id = " & rsWORetrieve!task_id)
        FillLabelsTask
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - Dgrid_RowColChange: Description - " & Err.Description
End Sub

Private Sub Form_Activate()

On Error GoTo errorhandler
    'If CheckRecordset = 1 Then
    MDIFormWOS.FindActive (False)
    'End If
    If intTypeWO = 1 Then
        MDIFormWOS.cmdSearch.Enabled = False
        MDIFormWOS.cmdPrint.Enabled = False
        MDIFormWOS.AddMode
    Else
        MDIFormWOS.cmdSearch.Enabled = True
        MDIFormWOS.cmdPrint.Enabled = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - Form_Activate: Description - " & Err.Description
End Sub

' This has to be modified to allow add as well as update
Private Sub Form_KeyUp(KeyCode As Integer, Shift As Integer)
    Dim intKeyValue As Integer

On Error GoTo errorhandler

    intKeyValue = KeyCode
    ' F8 (value 119) - move previous
    ' F9 (value 120) - move next
    ' F10 (value 121) - new record
    ' F11 (value 122) - save
    Select Case intKeyValue
    Case 122
        If MDIFormWOS.cmdSave.Enabled = True Then
            Save
        End If
    Case 121
        If MDIFormWOS.cmdAdd.Enabled = True Then
            Add
            'intTypeWO = 2
            intEquipIDStore = 0
            intTaskIDStore = 0
            strEquipIDStore = ""
            strTaskIDStore = ""
    
            'MDIFormWOS.SetFocus
            frmWorkOrder.SetFocus
            frmWorkOrder.cboEquipID.SetFocus
        Else
            MsgBox "Data has to be saved before entering another record."
        End If
    Case 120
        If MDIFormWOS.cmdNext.Enabled = True Then
            NextRec
            MDIFormWOS.SetFocus
            frmWorkOrder.SetFocus
            frmWorkOrder.cboEquipID.SetFocus
        Else
            Cancel
        End If
        If intStatus = 2 Then
            intStatus = 1
        End If

    Case 119
        
        If MDIFormWOS.cmdPrevious.Enabled = True Then
            PrevRec
            MDIFormWOS.SetFocus
            frmWorkOrder.SetFocus
            frmWorkOrder.cboEquipID.SetFocus
        Else
            Cancel
        End If
        If intStatus = 2 Then
            intStatus = 1
        End If
    End Select
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - Form_KeyUp: Description - " & Err.Description
End Sub

Private Sub Form_Load()
    Dim intResult As Integer

On Error GoTo errorhandler
    intStatus = 0
    Me.Height = 7000
    Me.Width = 9300
    Me.Left = 0
    Me.Top = 0
    FormView
    strSearchEquipKey = "XXXXXXXXXXX"
    strSearchEquipDesc = "XXXXXXXXXXX"
    strSearchTaskDesc = "XXXXXXXXXXX"
    strSearchMiscComments = "XXXXXXXXXXX"
    strSearchComments = "XXXXXXXXXXX"
    strSearchInitial = "XXXXXXXXXXX"
    strSearchDate1 = "01/01/1955"
    strSearchDate2 = "01/01/2999"
    strSearchOpt = "All"
    
    strState = "Load"
    
    intResult = RetrieveWO(strState, "")
    If intResult = 0 Then
    Else
        FillFields
        SetGrid
        PopEquipList rsWORetrieve!equip_id
        FillLabelsEquip
        PopTaskList rsWORetrieve!equip_id
        FillLabelsTask
        cboTaskID.Text = rsWORetrieve!task_id
        'CalculateFields rsWORetrieve!task_id
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - Form_Load: Description - " & Err.Description
End Sub


Public Sub Populate()

On Error GoTo errorhandler

    FillFields
    SetGrid
    rsEquipWO.MoveFirst
    rsEquipWO.Find ("equip_id = " & rsWORetrieve!equip_id)
    FillLabelsEquip
    PopTaskList rsWORetrieve!equip_id
    rsTaskWO.MoveFirst
    rsTaskWO.Find ("task_id = " & rsWORetrieve!task_id)
    FillLabelsTask
    'CalculateFields rsWORetrieve!task_id
    cboTaskID.Text = rsWORetrieve!task_id
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - Populate: Description - " & Err.Description
End Sub

Public Sub PrintScreen()
    ' Need to print the History record being
    ' looked at or print a report based on the record on the screen
End Sub

Public Sub SetGrid()
    Dim intGridWidth As Integer
    Dim col1, col2, col3, col4, col5, col6 As Column
    
On Error GoTo errorhandler

    Set DGridWO.DataSource = rsWORetrieve
    
    Set col1 = DGridWO.Columns(0)
    Set col2 = DGridWO.Columns(1)
    Set col3 = DGridWO.Columns(2)
    Set col4 = DGridWO.Columns(3)
    Set col5 = DGridWO.Columns(4)
    Set col6 = DGridWO.Columns(5)
        
    col1.Caption = "ID"
    col2.Caption = "PLANT"
    col3.Caption = "EQUIP"
    col4.Caption = "WORK ORDER"
    col5.Caption = "METER READING"
    col6.Caption = "DATE COMPLETED"
        
    intGridWidth = DGridWO.Width
    
    col1.Width = (6 / 81) * intGridWidth
    col2.Width = (7 / 81) * intGridWidth
    col3.Width = (7 / 81) * intGridWidth
    col4.Width = (7 / 81) * intGridWidth
    col5.Width = (24 / 81) * intGridWidth
    col6.Width = (30 / 81) * intGridWidth
        
    'col1.Locked = True
    'col2.Locked = True
    'col3.Locked = True
    'col4.Locked = True
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - SetGrid: Description - " & Err.Description
End Sub

Public Sub ChangedData()
    Dim intChangedCount As Integer
    Dim strEquipID, strEquipNum, strTaskID, strTaskNum As String
    Dim intLenEquip, intLenTask As Integer
    Dim intPosEquip, intPosTask As Integer

On Error GoTo errorhandler

    intChangedCount = 0
    ans = 0
    
    ' Evaluating equipment_id change
    strEquipID = cboEquipID.Text
    strEquipID = Trim(strEquipID)
    intLenEquip = Len(strEquipID)
    intPosEquip = InStr(strEquipID, " - ")
    
    If intPosEquip = 0 Then
        strEquipNum = strEquipID
    Else
        strEquipNum = Left(strEquipID, intPosEquip - 1)
    End If
    
    If rsWORetrieve!equip_id <> CLng(strEquipNum) Then
        intChangedCount = intChangedCount + 1
    End If
    
    ' Evaluating task_id change
    strTaskID = cboTaskID.Text
    strTaskID = Trim(strTaskID)
    intLenTask = Len(strTaskID)
    intPosTask = InStr(strTaskID, " - ")
    
    If intPosTask = 0 Then
        strTaskNum = strTaskID
    Else
        strTaskNum = Left(strTaskID, intPosTask - 1)
    End If
    
    If rsWORetrieve!task_id <> CLng(strTaskNum) Then
        intChangedCount = intChangedCount + 1
    End If
    
    ' Evaluating rest of the fields
    
    If txtMeterReadingAtCompletion.Text <> rsWORetrieve!meter_reading_at_work_completion Then
        intChangedCount = intChangedCount + 1
    End If
    If txtDateCompleted.Text <> "" Then
        If CDate(txtDateCompleted.Text) <> rsWORetrieve!date_work_completed Then
            intChangedCount = intChangedCount + 1
        End If
    Else
        If txtDateCompleted.Text <> rsWORetrieve!date_work_completed Then
            intChangedCount = intChangedCount + 1
        End If
    End If
    If txtCompletedBy.Text <> rsWORetrieve!completed_by Then
        intChangedCount = intChangedCount + 1
    End If
    If txtLabor.Text <> rsWORetrieve!labor Then
        intChangedCount = intChangedCount + 1
    End If
    If txtMaterialsCost.Text <> rsWORetrieve!materials_cost Then
        intChangedCount = intChangedCount + 1
    End If
    If txtComments.Text <> rsWORetrieve!Comments Then
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
MsgBox "Error Number - " & Err.Number & ": WOS: WO - ChangedData: Description - " & Err.Description
End Sub

Private Sub KeepCount()

On Error GoTo errorhandler

    Me.txtCount = "Record No. " & rsWORetrieve.AbsolutePosition & " of " & rsWORetrieve.RecordCount & " Records"
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - KeepCount: Description - " & Err.Description
End Sub

Private Sub FillLabelsEquip()
Dim intCount, I As Integer
'Dim strEq As String

On Error GoTo errorhandler

    If rsEquipWO.EOF = True Or rsEquipWO.BOF = True Then
        'intCount = rsEquipWO.RecordCount
        'rsEquipWO.MoveFirst
        'For I = 0 To intCount
        '    strEq = rsEquipWO!equip_id
        '    rsEquipWO.MoveNext
        'Next
        'If intCount = 0 Then
        '    MsgBox "There are no more equipment for this plant in the database"
        '    Unload Me
        'End If
    Else
        If IsNull(rsEquipWO!mech_serial) Then
            Me.lblMechSerialD.Caption = ""
        Else
            Me.lblMechSerialD.Caption = rsEquipWO!mech_serial
        End If
        If IsNull(rsEquipWO!mech_id) Then
            Me.lblMechIDD.Caption = ""
        Else
            Me.lblMechIDD.Caption = rsEquipWO!mech_id
        End If
        If IsNull(rsEquipWO!mech_model) Then
            Me.lblMechModelD.Caption = ""
        Else
            Me.lblMechModelD.Caption = rsEquipWO!mech_model
        End If
        If IsNull(rsEquipWO!mech_frame) Then
            Me.lblMechFrameD.Caption = ""
        Else
            Me.lblMechFrameD.Caption = rsEquipWO!mech_frame
        End If
        If IsNull(rsEquipWO!mech_imp_sz) Then
            Me.lblMechImpSzD.Caption = ""
        Else
            Me.lblMechImpSzD.Caption = rsEquipWO!mech_imp_sz
        End If
        If IsNull(rsEquipWO!mech_hp) Then
            Me.lblMechHpD.Caption = ""
        Else
            Me.lblMechHpD.Caption = rsEquipWO!mech_hp
        End If
        If IsNull(rsEquipWO!mech_rpm) Then
            Me.lblMechRpmD.Caption = ""
        Else
            Me.lblMechRpmD.Caption = rsEquipWO!mech_rpm
        End If
        If IsNull(rsEquipWO!mech_cap) Then
            Me.lblMechCapD.Caption = ""
        Else
            Me.lblMechCapD.Caption = rsEquipWO!mech_cap
        End If
        If IsNull(rsEquipWO!mech_size) Then
            Me.lblMechSizeD.Caption = ""
        Else
            Me.lblMechSizeD.Caption = rsEquipWO!mech_size
        End If
        If IsNull(rsEquipWO!mech_tdh) Then
            Me.lblMechTdhD.Caption = ""
        Else
            Me.lblMechTdhD.Caption = rsEquipWO!mech_tdh
        End If
        If IsNull(rsEquipWO!mech_cat_no) Then
            Me.lblMechCatNoD.Caption = ""
        Else
            Me.lblMechCatNoD.Caption = rsEquipWO!mech_cat_no
        End If
        If IsNull(rsEquipWO!mech_max_rpm) Then
            Me.lblMechMaxRpmD.Caption = ""
        Else
            Me.lblMechMaxRpmD.Caption = rsEquipWO!mech_max_rpm
        End If
        If IsNull(rsEquipWO!mech_min_rpm) Then
            Me.lblMechMinRpmD.Caption = ""
        Else
            Me.lblMechMinRpmD.Caption = rsEquipWO!mech_min_rpm
        End If
        If IsNull(rsEquipWO!mech_cfm) Then
            Me.lblMechCfmD.Caption = ""
        Else
            Me.lblMechCfmD.Caption = rsEquipWO!mech_cfm
        End If
        If IsNull(rsEquipWO!mech_oil) Then
            Me.lblMechOilD.Caption = ""
        Else
            Me.lblMechOilD.Caption = rsEquipWO!mech_oil
        End If
        If IsNull(rsEquipWO!mech_oil_filter) Then
            Me.lblMechOilFilterD.Caption = ""
        Else
            Me.lblMechOilFilterD.Caption = rsEquipWO!mech_oil_filter
        End If
        If IsNull(rsEquipWO!mech_air_filter) Then
            Me.lblMechAirFilterD.Caption = ""
        Else
            Me.lblMechAirFilterD.Caption = rsEquipWO!mech_air_filter
        End If
        If IsNull(rsEquipWO!mech_belt1) Then
            Me.lblMechBelt1D.Caption = ""
        Else
            Me.lblMechBelt1D.Caption = rsEquipWO!mech_belt1
        End If
        If IsNull(rsEquipWO!mech_belt2) Then
            Me.lblMechBelt2D.Caption = ""
        Else
            Me.lblMechBelt2D.Caption = rsEquipWO!mech_belt2
        End If
        If IsNull(rsEquipWO!mech_pipe_size) Then
            Me.lblMechPipeSizeD.Caption = ""
        Else
            Me.lblMechPipeSizeD.Caption = rsEquipWO!mech_pipe_size
        End If
        If IsNull(rsEquipWO!mech_pipe_type) Then
            Me.lblMechPipeTypeD.Caption = ""
        Else
            Me.lblMechPipeTypeD.Caption = rsEquipWO!mech_pipe_type
        End If
        If IsNull(rsEquipWO!mech_no_valves_types) Then
            Me.lblMechNoValvesTypesD.Caption = ""
        Else
            Me.lblMechNoValvesTypesD.Caption = rsEquipWO!mech_no_valves_types
        End If
        If IsNull(rsEquipWO!mech_misc_nameplate_data) Then
            Me.lblMechMiscNPDataD.Caption = ""
        Else
            Me.lblMechMiscNPDataD.Caption = rsEquipWO!mech_misc_nameplate_data
        End If
        If IsNull(rsEquipWO!mech_recommended_spare_parts) Then
            Me.lblMechRecomSparePartsD.Caption = ""
        Else
            Me.lblMechRecomSparePartsD.Caption = rsEquipWO!mech_recommended_spare_parts
        End If
        If IsNull(rsEquipWO!elec_serial) Then
            Me.lblElecSerialD.Caption = ""
        Else
            Me.lblElecSerialD.Caption = rsEquipWO!elec_serial
        End If
        If IsNull(rsEquipWO!elec_id) Then
            Me.lblElecIDD.Caption = ""
        Else
            Me.lblElecIDD.Caption = rsEquipWO!elec_id
        End If
        If IsNull(rsEquipWO!elec_model) Then
            Me.lblElecModelD.Caption = ""
        Else
            Me.lblElecModelD.Caption = rsEquipWO!elec_model
        End If
        If IsNull(rsEquipWO!elec_frame) Then
            Me.lblElecFrameD.Caption = ""
        Else
            Me.lblElecFrameD.Caption = rsEquipWO!elec_frame
        End If
        If IsNull(rsEquipWO!elec_cat_no) Then
            Me.lblElecCatNoD.Caption = ""
        Else
            Me.lblElecCatNoD.Caption = rsEquipWO!elec_cat_no
        End If
        If IsNull(rsEquipWO!elec_hp) Then
            Me.lblElecHpD.Caption = ""
        Else
            Me.lblElecHpD.Caption = rsEquipWO!elec_hp
        End If
        If IsNull(rsEquipWO!elec_rpm) Then
            Me.lblElecRpmD.Caption = ""
        Else
            Me.lblElecRpmD.Caption = rsEquipWO!elec_rpm
        End If
        If IsNull(rsEquipWO!elec_v) Then
            Me.lblElecVD.Caption = ""
        Else
            Me.lblElecVD.Caption = rsEquipWO!elec_v
        End If
        If IsNull(rsEquipWO!elec_amp) Then
            Me.lblElecAmpD.Caption = ""
        Else
            Me.lblElecAmpD.Caption = rsEquipWO!elec_amp
        End If
        If IsNull(rsEquipWO!elec_hz) Then
            Me.lblElecHzD.Caption = ""
        Else
            Me.lblElecHzD.Caption = rsEquipWO!elec_hz
        End If
        If IsNull(rsEquipWO!elec_phs) Then
            Me.lblElecPhsD.Caption = ""
        Else
            Me.lblElecPhsD.Caption = rsEquipWO!elec_phs
        End If
        If IsNull(rsEquipWO!elec_sf) Then
            Me.lblElecSfD.Caption = ""
        Else
            Me.lblElecSfD.Caption = rsEquipWO!elec_sf
        End If
        If IsNull(rsEquipWO!elec_duty) Then
            Me.lblElecDutyD.Caption = ""
        Else
            Me.lblElecDutyD.Caption = rsEquipWO!elec_duty
        End If
        If IsNull(rsEquipWO!elec_insl_cl) Then
            Me.lblElecInslClD.Caption = ""
        Else
            Me.lblElecInslClD.Caption = rsEquipWO!elec_insl_cl
        End If
        If IsNull(rsEquipWO!elec_design) Then
            Me.lblElecDesignD.Caption = ""
        Else
            Me.lblElecDesignD.Caption = rsEquipWO!elec_design
        End If
        If IsNull(rsEquipWO!elec_shaft_end_brg) Then
            Me.lblElecShaftEndBrgD.Caption = ""
        Else
            Me.lblElecShaftEndBrgD.Caption = rsEquipWO!elec_shaft_end_brg
        End If
        If IsNull(rsEquipWO!elec_opp_end_brg) Then
            Me.lblElecOppEndBrgD.Caption = ""
        Else
            Me.lblElecOppEndBrgD.Caption = rsEquipWO!elec_opp_end_brg
        End If
        If IsNull(rsEquipWO!elec_misc_nameplate_data) Then
            Me.lblElecMiscNPDataD.Caption = ""
        Else
            Me.lblElecMiscNPDataD.Caption = rsEquipWO!elec_misc_nameplate_data
        End If
        If IsNull(rsEquipWO!elec_recommended_spare_parts) Then
            Me.lblElecRecomSparePartsD.Caption = ""
        Else
            Me.lblElecRecomSparePartsD.Caption = rsEquipWO!elec_recommended_spare_parts
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - FillLabelsEquip: Description - " & Err.Description
End Sub

Private Sub FillLabelsTask()
    Dim intCount As Integer
    
On Error GoTo errorhandler

    If rsTaskWO.EOF = True Or rsTaskWO.BOF = True Then
        'intCount = rsTaskRetrieve.RecordCount
        'If intCount = 0 Then
        '    MsgBox "There are no more Work Order for this plant in the database"
        '    Unload Me
        'End If
    Else
        If IsNull(rsTaskWO!task_desc) Then
            lblTaskTaskDescD.Caption = ""
        Else
            lblTaskTaskDescD.Caption = rsTaskWO!task_desc
        End If
        If IsNull(rsTaskWO!priority) Then
            lblTaskPriorityD.Caption = ""
        Else
            lblTaskPriorityD.Caption = rsTaskWO!priority
        End If
        If IsNull(rsTaskWO!cycle_type) Then
            lblTaskCycleTypeD.Caption = ""
        Else
            lblTaskCycleTypeD.Caption = rsTaskWO!cycle_type
        End If
        If IsNull(rsTaskWO!interval_days) Then
            lblTaskIntervalDaysD.Caption = ""
        Else
            lblTaskIntervalDaysD.Caption = rsTaskWO!interval_days
        End If
        If IsNull(rsTaskWO!interval_meter) Then
            lblTaskIntervalMeterD.Caption = ""
        Else
            lblTaskIntervalMeterD.Caption = rsTaskWO!interval_meter
        End If
        If IsNull(rsTaskWO!tools_required) Then
            lblTaskToolsRequiredD.Caption = ""
        Else
            lblTaskToolsRequiredD.Caption = rsTaskWO!tools_required
        End If
        If IsNull(rsTaskWO!last_worked_meter_reading) Then
            lblTaskLastWorkedMeterD.Caption = ""
        Else
            lblTaskLastWorkedMeterD.Caption = rsTaskWO!last_worked_meter_reading
        End If
        If IsNull(rsTaskWO!last_worked_date) Then
            lblTaskLastWorkedDateD.Caption = ""
        Else
            lblTaskLastWorkedDateD.Caption = rsTaskWO!last_worked_date
        End If
        If IsNull(rsTaskWO!misc_comments) Then
            txtTaskMiscCommentsD.Text = ""
        Else
            txtTaskMiscCommentsD.Text = rsTaskWO!misc_comments
        End If
        If IsNull(rsTaskWO!lo_to) Then
            lblTaskLoToD.Caption = ""
        Else
            lblTaskLoToD.Caption = rsTaskWO!lo_to
        End If
        If IsNull(rsTaskWO!created_by) Then
            lblCreatedbyD.Caption = ""
        Else
            lblCreatedbyD.Caption = rsTaskWO!created_by
        End If
        If IsNull(rsTaskWO!work_due_when_meter_reads) Then
            Me.lblWorkDueWhenMeterReadsD.Caption = ""
        Else
            Me.lblWorkDueWhenMeterReadsD.Caption = rsTaskWO!work_due_when_meter_reads
        End If
        If IsNull(rsTaskWO!work_due_date) Then
            Me.lblWorkDueDateD.Caption = ""
        Else
            Me.lblWorkDueDateD.Caption = rsTaskWO!work_due_date
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - FillLabelsTask: Description - " & Err.Description
End Sub

Private Sub FillFields()
    Dim intCount As Integer
    
On Error GoTo errorhandler

    If rsWORetrieve.EOF = True Or rsWORetrieve.BOF = True Then
        intCount = rsWORetrieve.RecordCount
        If intCount = 0 Then
            MsgBox "There are no more History record for this plant in the database"
            Unload Me
        End If
    Else
        
        Me.lblPlantName.Caption = intPlantPass & " - " & strPlantPass
        Me.lblPlantNameG.Caption = intPlantPass & " - " & strPlantPass
        
        cboEquipID.Text = rsWORetrieve!equip_id
        
        intEquipIDStore = rsWORetrieve!equip_id
        
        cboTaskID.Text = rsWORetrieve!task_id
        
        intTaskIDStore = rsWORetrieve!task_id
        
        If IsNull(rsWORetrieve!meter_reading_at_work_completion) Then
            txtMeterReadingAtCompletion.Text = ""
        Else
            txtMeterReadingAtCompletion.Text = rsWORetrieve!meter_reading_at_work_completion
        End If
        If IsNull(rsWORetrieve!date_work_completed) Then
            txtDateCompleted.Text = ""
        Else
            txtDateCompleted.Text = rsWORetrieve!date_work_completed
        End If
        If IsNull(rsWORetrieve!completed_by) Then
            txtCompletedBy.Text = ""
        Else
            txtCompletedBy.Text = rsWORetrieve!completed_by
        End If
        If IsNull(rsWORetrieve!labor) Then
            txtLabor.Text = ""
        Else
            txtLabor.Text = rsWORetrieve!labor
        End If
        If IsNull(rsWORetrieve!materials_cost) Then
            txtMaterialsCost.Text = ""
        Else
            txtMaterialsCost.Text = rsWORetrieve!materials_cost
        End If
        If IsNull(rsWORetrieve!Comments) Then
            txtComments.Text = ""
        Else
            txtComments.Text = rsWORetrieve!Comments
        End If
        KeepCount
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - FillFields: Description - " & Err.Description
End Sub

Public Function RetrieveWO(ByVal strState As String, strSqlA As String) As Integer
    ' returns 1 or 0
    ' 1 - records
    ' 0 - no records
    
    Dim ans As Integer
    Dim strSQL, strWO As String
    Dim strSearchString As String
    'Dim dtDate1, dtDate2 As Date
    
On Error GoTo errorhandler

    If strState = "Load" Then
        If strPlantPass = "All Plants" Then
            strSQL = "select * from work_order where work_order_id <> 0"
        Else
            strSQL = "select * from work_order where plant_fk = " & intPlantPass
        End If
    Else
        strSQL = strSqlA
    End If
    Set rsWORetrieve = RecordsetWO(strSQL)
    If rsWORetrieve.EOF = True Or rsWORetrieve.BOF = True Then
        RetrieveWO = 0
    Else
        rsWORetrieve.MoveLast
        rsWORetrieve.MoveFirst
        RetrieveWO = 1
    End If
Exit Function
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - RetrieveWO: Description - " & Err.Description
End Function

Private Sub Form_Unload(Cancel As Integer)
    
On Error GoTo errorhandler

    Set rsWORetrieve = Nothing
    intTypeWO = 0
    ' All the variable used in search
    strSearchEquipKey = ""
    strSearchEquipDesc = ""
    strSearchTaskDesc = ""
    strSearchMiscComments = ""
    strSearchComments = ""
    strSearchDate1 = ""
    strSearchDate2 = ""
    strSearchOpt = ""
    
    strState = ""

    MDIFormWOS.FindActive (True)
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - Form_Unload: Description - " & Err.Description
End Sub

Public Function PopEquipList(intEquip As Integer) As Integer
    ' value passed either -1 for record existing
    '               or    0 for all list of equipments
    '               or    precise equip_id
    ' Returns 1 for success, 2 for failure
    Dim I, count As Integer
    Dim strSQL As String
    
On Error GoTo errorhandler

    If strPlantPass = "All Plants" Then
        strSQL = "select * from equipment where equip_id <> 0"
    Else
        strSQL = "select * from equipment where plant_fk = " & intPlantPass
    End If
    
    Set rsEquipWO = RecordsetWO(strSQL)
    
    If rsEquipWO.EOF = True Or rsEquipWO.BOF = True Then
        If strPlantPass <> "All Plants" Then
            MsgBox "There are no equipments under the selected plant. Please add new equipment. "
            Unload Me
            frmEquipment.CheckRecordset
            PopEquipList = 2
        Else
            MsgBox "New equipment could not be added until you select a specific plant."
            Unload MDIFormWOS
            frmPlant.Show
            PopEquipList = 2
        End If
        'Do not try to populate the dropdown
    Else
        cboEquipID.Clear
        rsEquipWO.MoveLast
        count = rsEquipWO.RecordCount
        rsEquipWO.MoveFirst
        For I = 1 To count
            cboEquipID.AddItem rsEquipWO!equip_id & " - " & rsEquipWO!equip_desc
            rsEquipWO.MoveNext
        Next
        
        rsEquipWO.MoveFirst
        If intEquip <> 0 Then
            If intEquip = -1 Then
                rsEquipWO.Find ("equip_id = " & rsWORetrieve!equip_id)
            Else
                rsEquipWO.Find ("equip_id = " & intEquip)
            End If
            cboEquipID.Text = Str(intEquip)
        End If
        PopEquipList = 1
            
    End If
Exit Function
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - PopEquipList: Description - " & Err.Description
End Function

Public Function PopTaskList(intEquipID As Integer)
    Dim I, count As Integer
    Dim strSQL As String
    
On Error GoTo errorhandler

    If strPlantPass = "All Plants" Then
        strSQL = "select * from task where task_id <> 0 and equip_id = " & intEquipID
    Else
        strSQL = "select * from task where plant_fk = " & intPlantPass & " and equip_id = " & intEquipID
    End If
    
    Set rsTaskWO = RecordsetWO(strSQL)
    
    If rsTaskWO.EOF = True Or rsTaskWO.BOF = True Then
        MsgBox "There are no Work Orders under the selected equipment. Please select another equipment or create Work Order for the equipment."
        cboTaskID.Clear
        cboEquipID.SetFocus
    Else
        rsTaskWO.MoveLast
        count = rsTaskWO.RecordCount
        rsTaskWO.MoveFirst
        cboTaskID.Clear
        For I = 1 To count
            cboTaskID.AddItem rsTaskWO!task_id & " - " & rsTaskWO!task_desc
            rsTaskWO.MoveNext
        Next
        rsTaskWO.MoveFirst
    End If
Exit Function
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - PopTaskList: Description - " & Err.Description
End Function

Private Sub txtDateCompleted_Validate(Cancel As Boolean)
    
On Error GoTo errorhandler

    If IsDate(txtDateCompleted.Text) = False And txtDateCompleted.Text <> "" Then
        MsgBox "Incorrect Format. Please Re-enter."
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - txtDateCompleted_Validate: Description - " & Err.Description
End Sub

Private Sub txtLabor_Validate(Cancel As Boolean)
    
On Error GoTo errorhandler

    If IsNumeric(txtLabor.Text) = False And txtLabor.Text <> "" Then
        MsgBox "Incorrect Format. Please Re-enter."
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - txtLabor_Validate: Description - " & Err.Description
End Sub

Private Sub txtMaterialsCost_Validate(Cancel As Boolean)
    
On Error GoTo errorhandler

    If IsNumeric(txtMaterialsCost.Text) = False And txtMaterialsCost.Text <> "" Then
        MsgBox "Incorrect Format. Please Re-enter."
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - txtMaterialsCost_Validate: Description - " & Err.Description
End Sub

Private Sub txtMeterReadingAtCompletion_Validate(Cancel As Boolean)
    
On Error GoTo errorhandler

    If IsNumeric(txtMeterReadingAtCompletion.Text) = False And txtMeterReadingAtCompletion.Text <> "" Then
        MsgBox "Incorrect Format. Please Re-enter."
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - txtMeterReadingAtCompletion_Validate: Description - " & Err.Description
End Sub


'Public Sub CalculateFields(intTaskID As Integer)
    ' get the datelastcompleted, meterreadingwhenlastcompleted, intervaldays, intervalmeter
'    Dim intIntervalDays, intIntervalMeter, intDueMeter, intLastWorkedMeter As Integer
'    Dim dtLastWorkedDate, dtDueDate As Date
    ' it would otherwise tell me that it already is at the eof or bof
'    rsTaskWO.MoveFirst
'    rsTaskWO.Find ("task_id = " & intTaskID)
'    Select Case rsTaskWO!cycle_type
'    Case "unscheduled"
        ' do nothing because the values are not supposed to be calculated
'        txtWorkDueWhenMeterReads.Text = ""
'        txtWorkDueDate.Text = ""
'    Case "Days Cycle"
'        dtLastWorkedDate = rsTaskWO!last_worked_date
'        If IsNull(dtLastWorkedDate) Then
            ' ask Bob if he agrees this rule
'            dtLastWorkedDate = rsTaskWO!date_task_created
'        End If
 '       intIntervalDays = rsTaskWO!interval_days
 '       dtDueDate = dtLastWorkedDate + intIntervalDays
 '       txtWorkDueDate.Text = Format(dtDueDate, "mm/dd/yy")
 '   Case "Meter Cycle"
 '       If IsNull(rsTaskWO!last_worked_meter_reading) Then
 '           intLastWorkedMeter = 0
 '       Else
 '           intLastWorkedMeter = rsTaskWO!last_worked_meter_reading
 '       End If
 '       If IsNull(rsTaskWO!interval_meter) Then
 '           intIntervalMeter = 0
 '       Else
 '           intIntervalMeter = rsTaskWO!interval_meter
 '       End If
 '       intDueMeter = intLastWorkedMeter + intIntervalDays
 '       txtWorkDueWhenMeterReads.Text = intDueMeter
 '   End Select
'End Sub

'Private Sub cboEquipID_GotFocus()
'    Dim intLen, intPos As Integer
'
'    intEquipIDStore = 0
'    strEquipIDStore = ""
'    If cboEquipID.Text <> "" Then
'        strEquipIDStore = cboEquipID.Text
'    End If
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
Public Sub PrintReports()
    
On Error GoTo errorhandler

        DEnvWos.conWOS.Open
        'DEnvWos.ComWOList intPlantPass, strSearchOpt, strSearchEquipKey, strSearchEquipDesc, strSearchTaskDesc, strSearchMiscComments, strSearchComments, strSearchInitial, strSearchDate1, strSearchDate2, intPlantPass, strSearchOpt, strSearchEquipKey, strSearchEquipDesc, strSearchTaskDesc, strSearchMiscComments, strSearchComments, strSearchInitial, strSearchDate1, strSearchDate2
        
        Dim cn As ADODB.Connection, rs As ADODB.Recordset, strSQL As String

        Set cn = New ADODB.Connection
        Set rs = New ADODB.Recordset

        cn.Open "Provider=MSDataShape;Data Provider=Microsoft.Jet.OLEDB.4.0;Data Source=C:\Program Files\WORK ORDER\WOS.mdb;"

        strSQL = "SHAPE {SELECT DISTINCT equipment.equip_key, equipment.equip_id, equipment.equip_desc FROM " & _
            "(plant INNER JOIN (equipment INNER JOIN task ON equipment.equip_id = task.equip_id) ON " & _
            "plant.plant_id = equipment.plant_fk) INNER JOIN work_order ON task.task_id = work_order.task_id " & _
            "WHERE ((work_order.plant_fk = " & CStr(intPlantPass) & " AND " & CStr(intPlantPass) & " <> 0) OR (work_order.plant_fk <> 0 AND " & _
            CStr(intPlantPass) & " = 0)) AND " & _
            "(('" & strSearchOpt & "' = 'ALL') OR ('" & strSearchOpt & "' = 'Unschedule' AND task.cycle_type = 'Unschedule') OR " & _
            "('" & strSearchOpt & "' = 'DueDate' AND task.cycle_type = 'Days Cycle') OR ('" & strSearchOpt & "' = 'DueMeter' AND " & _
            "task.cycle_type = 'Meter Cycle')) AND " & _
            "(('" & strSearchEquipKey & "' = 'XXXXXXXXXXX') OR ('" & strSearchEquipKey & "' <> 'XXXXXXXXXXX' AND " & _
            "equipment.equip_key = '" & strSearchEquipKey & "')) AND " & _
            "(('" & strSearchEquipDesc & "' = 'XXXXXXXXXXX') OR ('" & strSearchEquipDesc & "' <> 'XXXXXXXXXXX' AND equipment.equip_desc " & _
            "LIKE '%" & strSearchEquipDesc & "%')) AND (('" & strSearchTaskDesc & "' = 'XXXXXXXXXXX') OR " & _
            "('" & strSearchTaskDesc & "' <> 'XXXXXXXXXXX' AND " & _
            "task.task_desc LIKE '%" & strSearchTaskDesc & "%')) AND (('" & strSearchMiscComments & "' = 'XXXXXXXXXXX') OR " & _
            "('" & strSearchMiscComments & "' <> 'XXXXXXXXXXX' AND task.misc_comments LIKE '%" & strSearchMiscComments & "%')) AND " & _
            "(('" & strSearchComments & "' = 'XXXXXXXXXXX') OR ('" & strSearchComments & "' <> 'XXXXXXXXXXX' AND work_order.comments " & _
            "LIKE '%" & strSearchComments & "%')) AND (('" & strSearchInitial & "' = 'XXXXXXXXXXX') OR ('" & strSearchInitial & "' <> 'XXXXXXXXXXX' AND " & _
            "work_order.completed_by LIKE '%" & strSearchInitial & "%')) AND (('" & strSearchDate1 & "' = '01/01/1955') OR " & _
            "('" & strSearchDate1 & "' <> '01/01/1955' AND work_order.date_work_completed >= datevalue('" & strSearchDate1 & "'))) AND " & _
            "(('" & strSearchDate2 & "' = '01/01/2999') OR ('" & strSearchDate2 & "' <> '01/01/2999' AND " & _
            "work_order.date_work_completed <= datevalue('" & strSearchDate2 & "'))) " & _
            "ORDER BY equipment.equip_key;} AS ComWOList APPEND "
        
        strSQL = strSQL & "({SELECT work_order.*, task.*, equipment.*, plant.* FROM (plant INNER JOIN (equipment INNER JOIN task ON " & _
            "equipment.equip_id = task.equip_id) ON plant.plant_id = equipment.plant_fk) INNER JOIN work_order ON " & _
            "task.task_id = work_order.task_id " & _
            "WHERE ((work_order.plant_fk = " & CStr(intPlantPass) & " AND " & CStr(intPlantPass) & " <> 0) OR (work_order.plant_fk <> 0 AND " & _
            CStr(intPlantPass) & " = 0)) AND " & _
            "(('" & strSearchOpt & "' = 'ALL') OR ('" & strSearchOpt & "' = 'Unschedule' AND task.cycle_type = 'Unschedule') OR " & _
            "('" & strSearchOpt & "' = 'DueDate' AND task.cycle_type = 'Days Cycle') OR ('" & strSearchOpt & "' = 'DueMeter' AND " & _
            "task.cycle_type = 'Meter Cycle')) AND " & _
            "(('" & strSearchEquipKey & "' = 'XXXXXXXXXXX') OR ('" & strSearchEquipKey & "' <> 'XXXXXXXXXXX' AND " & _
            "equipment.equip_key = '" & strSearchEquipKey & "')) AND " & _
            "(('" & strSearchEquipDesc & "' = 'XXXXXXXXXXX') OR ('" & strSearchEquipDesc & "' <> 'XXXXXXXXXXX' AND equipment.equip_desc " & _
            "LIKE '%" & strSearchEquipDesc & "%')) AND (('" & strSearchTaskDesc & "' = 'XXXXXXXXXXX') OR " & _
            "('" & strSearchTaskDesc & "' <> 'XXXXXXXXXXX' AND " & _
            "task.task_desc LIKE '%" & strSearchTaskDesc & "%')) AND (('" & strSearchMiscComments & "' = 'XXXXXXXXXXX') OR " & _
            "('" & strSearchMiscComments & "' <> 'XXXXXXXXXXX' AND task.misc_comments LIKE '%" & strSearchMiscComments & "%')) AND " & _
            "(('" & strSearchComments & "' = 'XXXXXXXXXXX') OR ('" & strSearchComments & "' <> 'XXXXXXXXXXX' AND work_order.comments " & _
            "LIKE '%" & strSearchComments & "%')) AND (('" & strSearchInitial & "' = 'XXXXXXXXXXX') OR ('" & strSearchInitial & "' <> 'XXXXXXXXXXX' AND " & _
            "work_order.completed_by LIKE '%" & strSearchInitial & "%')) AND (('" & strSearchDate1 & "' = '01/01/1955') OR " & _
            "('" & strSearchDate1 & "' <> '01/01/1955' AND work_order.date_work_completed >= datevalue('" & strSearchDate1 & "'))) AND " & _
            "(('" & strSearchDate2 & "' = '01/01/2999') OR ('" & strSearchDate2 & "' <> '01/01/2999' AND " & _
            "work_order.date_work_completed <= datevalue('" & strSearchDate2 & "'))) " & _
            "ORDER BY equipment.equip_key ASC, work_order.date_work_completed ASC;} " & _
            "AS ComWOList2 RELATE 'equip_id' TO 'work_order.equip_id') AS ComWOList2"

        rs.Open strSQL, cn, adOpenStatic, adLockReadOnly, adCmdText

        Set DEnvWos.rsComWOList.DataSource = rs
        
        rs.Close
        cn.Close

        Set rs = Nothing
        Set cn = Nothing

        ans = MsgBox("Please, click YES to get detail report, and NO to get summarized report.", vbYesNo)
        If ans = 6 Then
            'open wo detail report
            DRptWOList.Show (1)
            DRptWOList.Top = 1100
            DRptWOList.Left = 1
            DRptWOList.Height = 6400
            DRptWOList.Width = 9300
            
        Else
            ' open wo summary report
            DRptWOSum.Show (1)
            DRptWOSum.Top = 1100
            DRptWOSum.Left = 1
            DRptWOSum.Height = 6400
            DRptWOSum.Width = 9300
        End If
        
Exit Sub
errorhandler:
    Set rs = Nothing
    Set cn = Nothing

    MsgBox "Error Number - " & Err.Number & ": WOS: WO - PrintReports: Description - " & Err.Description
End Sub

Public Function FindRecords(ByVal strOption As String, ByVal strEquipKey As String, ByVal strEquipDesc As String, ByVal strTaskDesc As String, ByVal strTaskMiscComments As String, ByVal strWOComments As String, ByVal strInitial As String, ByVal strDate1 As String, ByVal strDate2 As String, ByVal intRetrievalType As Integer) As Integer
    Dim intResult As Integer
    Dim strInitialString, strSQL As String
    Dim rsCheck As ADODB.Recordset
    
On Error GoTo errorhandler

    ' intRetrievalType is used to know if it is just a check or we need to refresh the window
    strInitialString = ""
    Select Case strOption
    Case "DueDate"
        strInitialString = " task.cycle_type = 'Days Cycle' "
    Case "DueMeter"
        strInitialString = " task.cycle_type = 'Meter Cycle' "
    Case "Unschedule"
        strInitialString = " task.cycle_type = 'Unschedule' "
    End Select
    If strEquipKey <> "" Then
        If strInitialString <> "" Then
            strInitialString = strInitialString & " and equip_key = '" & Trim(strEquipKey) & "' "
        Else
            strInitialString = " equip_key = '" & Trim(strEquipKey) & "' "
        End If
    End If
    If strEquipDesc <> "" Then
        If strInitialString <> "" Then
            strInitialString = strInitialString & " and equip_desc like '%" & Trim(strEquipDesc) & "%' "
        Else
            strInitialString = " equip_desc like '%" & Trim(strEquipDesc) & "%' "
        End If
    End If
    If strTaskDesc <> "" Then
        If strInitialString <> "" Then
            strInitialString = strInitialString & " and task_desc like '%" & Trim(strTaskDesc) & "%' "
        Else
            strInitialString = " task_desc like '%" & Trim(strTaskDesc) & "%' "
        End If
    End If
    If strTaskMiscComments <> "" Then
        If strInitialString <> "" Then
            strInitialString = strInitialString & " and misc_comments like '%" & Trim(strTaskMiscComments) & "%'"
        Else
            strInitialString = " misc_comments like '%" & Trim(strTaskMiscComments) & "%'"
            End If
    End If
    If strWOComments <> "" Then
        If strInitialString <> "" Then
            strInitialString = strInitialString & " and comments like '%" & Trim(strWOComments) & "%' "
        Else
            strInitialString = " comments like '%" & Trim(strWOComments) & "%' "
        End If
    End If
    If strInitial <> "" Then
        If strInitialString <> "" Then
            strInitialString = strInitialString & " and completed_by like '%" & Trim(strInitial) & "%' "
        Else
            strInitialString = " completed_by like '%" & Trim(strInitial) & "%' "
        End If
    End If
    If strDate1 <> "" Then
        If strInitialString <> "" Then
            strInitialString = strInitialString & " and date_work_completed >= datevalue('" & strDate1 & "') "
        Else
            strInitialString = " date_work_completed >= datevalue('" & strDate1 & "') "
        End If
    End If
    If strDate2 <> "" Then
        If strInitialString <> "" Then
            strInitialString = strInitialString & " and date_work_completed <= datevalue('" & strDate2 & "') "
        Else
            strInitialString = " date_work_completed <= datevalue('" & strDate2 & "') "
        End If
    End If
    If intPlantPass <> 0 Then
        If strInitialString <> "" Then
            strSQL = "SELECT work_order.*,work_order.plant_fk as plant_fk, work_order.equip_id as equip_id, work_order.task_id as task_id,task.*, equipment.*,plant.* FROM (plant INNER JOIN (equipment INNER JOIN task ON [equipment].[equip_id]=[task].[equip_id]) ON [plant].[plant_id]=[equipment].[plant_fk]) INNER JOIN work_order ON [task].[task_id]=[work_order].[task_id] where " & strInitialString & " and work_order.plant_fk = " & intPlantPass & ";"
        Else
            strSQL = "SELECT work_order.*,work_order.plant_fk as plant_fk, work_order.equip_id as equip_id, work_order.task_id as task_id, task.*, equipment.*,plant.* FROM (plant INNER JOIN (equipment INNER JOIN task ON [equipment].[equip_id]=[task].[equip_id]) ON [plant].[plant_id]=[equipment].[plant_fk]) INNER JOIN work_order ON [task].[task_id]=[work_order].[task_id] where work_order.plant_fk = " & intPlantPass & ";"
        End If
    Else
        If strInitialString <> "" Then
            strSQL = "SELECT work_order.*, work_order.plant_fk as plant_fk, work_order.equip_id as equip_id, work_order.task_id as task_id, task.*, equipment.*,plant.* FROM (plant INNER JOIN (equipment INNER JOIN task ON [equipment].[equip_id]=[task].[equip_id]) ON [plant].[plant_id]=[equipment].[plant_fk]) INNER JOIN work_order ON [task].[task_id]=[work_order].[task_id] where " & strInitialString & ";"
        Else
            strSQL = "SELECT work_order.*, work_order.plant_fk as plant_fk, work_order.equip_id as equip_id, work_order.task_id as task_id, task.*, equipment.*,plant.* FROM (plant INNER JOIN (equipment INNER JOIN task ON [equipment].[equip_id]=[task].[equip_id]) ON [plant].[plant_id]=[equipment].[plant_fk]) INNER JOIN work_order ON [task].[task_id]=[work_order].[task_id] where work_order.plant_fk <> 0; "
        End If
    End If
    If intRetrievalType = 2 Then
        Select Case strOption
        Case "DueDate"
            strSearchOpt = "DueDate"
        Case "DueMeter"
            strSearchOpt = "DueMeter"
        Case "Unschedule"
            strSearchOpt = "Unschedule"
        Case "All"
            strSearchOpt = "All"
        End Select
        
        If strEquipKey <> "" Then
            strSearchEquipKey = strEquipKey
        Else
            strSearchEquipKey = "XXXXXXXXXXX"
        End If
        If strEquipDesc <> "" Then
            strSearchEquipDesc = strEquipDesc
        Else
            strSearchEquipDesc = "XXXXXXXXXXX"
        End If
        If strTaskDesc <> "" Then
            strSearchTaskDesc = strTaskDesc
        Else
            strSearchTaskDesc = "XXXXXXXXXXX"
        End If
        If strTaskMiscComments <> "" Then
            strSearchMiscComments = strTaskMiscComments
        Else
            strSearchMiscComments = "XXXXXXXXXXX"
        End If
        If strWOComments <> "" Then
            strSearchComments = strWOComments
        Else
            strSearchComments = "XXXXXXXXXXX"
        End If
        If strInitial <> "" Then
            strSearchInitial = strInitial
        Else
            strSearchInitial = "XXXXXXXXXXX"
        End If
        If strDate1 <> "" Then
            strSearchDate1 = strDate1
        Else
            strSearchDate1 = "01/01/1955"
        End If
        If strDate2 <> "" Then
            strSearchDate2 = strDate2
        Else
            strSearchDate2 = "01/01/2999"
        End If
        strState = "Search"
        intResult = RetrieveWO(strState, strSQL)
        If intResult <> 0 Then
            FindRecords = 1
            FillFields
            SetGrid
            PopEquipList rsWORetrieve!equip_id
            FillLabelsEquip
            PopTaskList rsWORetrieve!equip_id
            FillLabelsTask
            cboTaskID.Text = rsWORetrieve!task_id
            'CalculateFields rsWORetrieve!task_id
            Exit Function
        End If
    Else
        Set rsCheck = RecordsetWO(strSQL)
        If rsCheck.BOF = True Or rsCheck.EOF = True Then
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
    End If
Exit Function
errorhandler:
    Set rsCheck = Nothing
    MsgBox "Error Number - " & Err.Number & ": WOS: WO - FindRecords: Description - " & Err.Description
End Function

Public Function CheckRecordset() As Integer
    ' this function is used only to find out
    ' if there is recordset to work on
    Dim intResult As Integer
    
On Error GoTo errorhandler

    intResult = RetrieveWO("Load", "")
    
    If rsWORetrieve.EOF = True Or rsWORetrieve.BOF = True Then
        CheckRecordset = 2
        Exit Function
    Else
        CheckRecordset = 1
    End If
    'Set rsWORetrieve = Nothing
Exit Function
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - CheckRecordset: Description - " & Err.Description
End Function

Public Sub SearchRec()
    
On Error GoTo errorhandler

    frmSearchWO.Show (1)
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - SearchRec: Description - " & Err.Description
End Sub

Public Sub FormView()
    
On Error GoTo errorhandler

    FramGrid.Visible = False
    FramForm.Visible = True
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - FormView: Description - " & Err.Description
End Sub

Public Sub GridView()
    
On Error GoTo errorhandler

    FramForm.Visible = False
    FramGrid.Visible = True
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - GridView: Description - " & Err.Description
End Sub

Public Sub Cancel()
    
On Error GoTo errorhandler

    Unload Me
    frmPlant.CheckAll "wo"
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - Cancel: Description - " & Err.Description
End Sub

Public Sub ClearTask()
    
On Error GoTo errorhandler
    lblTaskTaskDescD.Caption = ""
    lblTaskPriorityD.Caption = ""
    lblTaskCycleTypeD.Caption = ""
    lblTaskIntervalDaysD.Caption = ""
    lblTaskIntervalMeterD.Caption = ""
    lblTaskToolsRequiredD.Caption = ""
    lblTaskLastWorkedMeterD.Caption = ""
    lblTaskLastWorkedDateD.Caption = ""
    txtTaskMiscCommentsD.Text = ""
    lblTaskLoToD.Caption = ""
    lblCreatedbyD.Caption = ""
    lblWorkDueWhenMeterReadsD.Caption = ""
    lblWorkDueDateD.Caption = ""
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - ClearTask: Description - " & Err.Description
End Sub

Public Sub ClearEquip()
    
On Error GoTo errorhandler

    Me.lblMechSerialD.Caption = ""
    Me.lblMechIDD.Caption = ""
    Me.lblMechModelD.Caption = ""
    Me.lblMechFrameD.Caption = ""
    Me.lblMechImpSzD.Caption = ""
    Me.lblMechHpD.Caption = ""
    Me.lblMechRpmD.Caption = ""
    Me.lblMechCapD.Caption = ""
    Me.lblMechSizeD.Caption = ""
    Me.lblMechTdhD.Caption = ""
    Me.lblMechCatNoD.Caption = ""
    Me.lblMechMaxRpmD.Caption = ""
    Me.lblMechMinRpmD.Caption = ""
    Me.lblMechCfmD.Caption = ""
    Me.lblMechOilD.Caption = ""
    Me.lblMechOilFilterD.Caption = ""
    Me.lblMechAirFilterD.Caption = ""
    Me.lblMechBelt1D.Caption = ""
    Me.lblMechBelt2D.Caption = ""
    Me.lblMechPipeSizeD.Caption = ""
    Me.lblMechPipeTypeD.Caption = ""
    Me.lblMechNoValvesTypesD.Caption = ""
    Me.lblMechMiscNPDataD.Caption = ""
    Me.lblMechRecomSparePartsD.Caption = ""
    Me.lblElecSerialD.Caption = ""
    Me.lblElecIDD.Caption = ""
    Me.lblElecModelD.Caption = ""
    Me.lblElecFrameD.Caption = ""
    Me.lblElecCatNoD.Caption = ""
    Me.lblElecHpD.Caption = ""
    Me.lblElecRpmD.Caption = ""
    Me.lblElecVD.Caption = ""
    Me.lblElecAmpD.Caption = ""
    Me.lblElecHzD.Caption = ""
    Me.lblElecPhsD.Caption = ""
    Me.lblElecSfD.Caption = ""
    Me.lblElecDutyD.Caption = ""
    Me.lblElecInslClD.Caption = ""
    Me.lblElecDesignD.Caption = ""
    Me.lblElecShaftEndBrgD.Caption = ""
    Me.lblElecOppEndBrgD.Caption = ""
    Me.lblElecMiscNPDataD.Caption = ""
    Me.lblElecRecomSparePartsD.Caption = ""
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: WO - ClearEquip: Description - " & Err.Description
End Sub

