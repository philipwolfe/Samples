VERSION 5.00
Object = "{CDE57A40-8B86-11D0-B3C6-00A0C90AEA82}#1.0#0"; "MSDATGRD.OCX"
Object = "{BDC217C8-ED16-11CD-956C-0000C04E4C0A}#1.1#0"; "tabctl32.ocx"
Object = "{C932BA88-4374-101B-A56C-00AA003668DC}#1.1#0"; "msmask32.ocx"
Begin VB.Form frmEquipment 
   Caption         =   "Equipment"
   ClientHeight    =   6630
   ClientLeft      =   60
   ClientTop       =   345
   ClientWidth     =   10590
   BeginProperty Font 
      Name            =   "MS Sans Serif"
      Size            =   12
      Charset         =   0
      Weight          =   700
      Underline       =   0   'False
      Italic          =   0   'False
      Strikethrough   =   0   'False
   EndProperty
   LinkTopic       =   "Form2"
   MDIChild        =   -1  'True
   ScaleHeight     =   6630
   ScaleMode       =   0  'User
   ScaleWidth      =   10590
   WindowState     =   2  'Maximized
   Begin VB.Frame Framform 
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   6495
      Left            =   120
      TabIndex        =   0
      Top             =   0
      Width           =   8895
      Begin VB.TextBox txtCount 
         Alignment       =   2  'Center
         DataField       =   "equip_id"
         DataSource      =   "AdodcMaintenance"
         Enabled         =   0   'False
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         ForeColor       =   &H00FF0000&
         Height          =   285
         Left            =   2880
         Locked          =   -1  'True
         TabIndex        =   96
         TabStop         =   0   'False
         Text            =   "1"
         Top             =   0
         Width           =   2655
      End
      Begin VB.TextBox txtEquipKey 
         DataField       =   "equip_key"
         DataSource      =   "AdodcMaintenance"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   1560
         MaxLength       =   10
         TabIndex        =   1
         Top             =   480
         Width           =   1215
      End
      Begin VB.TextBox txtEquipDesc 
         DataField       =   "equip_desc"
         DataSource      =   "AdodcMaintenance"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   645
         Left            =   1560
         MaxLength       =   100
         MultiLine       =   -1  'True
         ScrollBars      =   2  'Vertical
         TabIndex        =   4
         Top             =   840
         Width           =   6735
      End
      Begin VB.TextBox txtMeterReading 
         DataField       =   "last_meter_reading"
         BeginProperty DataFormat 
            Type            =   1
            Format          =   "0"
            HaveTrueFalseNull=   0
            FirstDayOfWeek  =   0
            FirstWeekOfYear =   0
            LCID            =   1033
            SubFormatType   =   1
         EndProperty
         DataSource      =   "AdodcMaintenance"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   285
         Left            =   4200
         TabIndex        =   2
         Top             =   480
         Width           =   975
      End
      Begin TabDlg.SSTab SSTab1 
         Height          =   4815
         Left            =   360
         TabIndex        =   48
         Top             =   1560
         Width           =   8175
         _ExtentX        =   14420
         _ExtentY        =   8493
         _Version        =   393216
         Tabs            =   2
         Tab             =   1
         TabHeight       =   520
         ForeColor       =   16711680
         TabCaption(0)   =   "Mechanical NP Data"
         TabPicture(0)   =   "frmEquipment.frx":0000
         Tab(0).ControlEnabled=   0   'False
         Tab(0).Control(0)=   "txtMechBelt2"
         Tab(0).Control(1)=   "txtMechBelt1"
         Tab(0).Control(2)=   "txtMechAirFilter"
         Tab(0).Control(3)=   "txtMechOilFilter"
         Tab(0).Control(4)=   "txtMechOil"
         Tab(0).Control(5)=   "txtMechPipeSize"
         Tab(0).Control(6)=   "txtMechPipeType"
         Tab(0).Control(7)=   "txtMechNoOfValvesTypes"
         Tab(0).Control(8)=   "txtMechMiscNPData"
         Tab(0).Control(9)=   "txtMechRecomSpareParts"
         Tab(0).Control(10)=   "txtMechCatNo"
         Tab(0).Control(11)=   "txtMechMaxRpm"
         Tab(0).Control(12)=   "txtMechMinRpm"
         Tab(0).Control(13)=   "txtMechCfm"
         Tab(0).Control(14)=   "txtMechSerial"
         Tab(0).Control(15)=   "txtMechID"
         Tab(0).Control(16)=   "txtMechFrame"
         Tab(0).Control(17)=   "txtMechModel"
         Tab(0).Control(18)=   "txtMechImpSz"
         Tab(0).Control(19)=   "txtMechHp"
         Tab(0).Control(20)=   "txtMechRpm"
         Tab(0).Control(21)=   "txtMechCap"
         Tab(0).Control(22)=   "txtMechSize"
         Tab(0).Control(23)=   "txtMechTdh"
         Tab(0).Control(24)=   "lblMechBelt2"
         Tab(0).Control(25)=   "lblMechBelt1"
         Tab(0).Control(26)=   "lblMechAirFilter"
         Tab(0).Control(27)=   "lblMechOilFilter"
         Tab(0).Control(28)=   "lblMechOil"
         Tab(0).Control(29)=   "lblMechSerial"
         Tab(0).Control(30)=   "lblMechID"
         Tab(0).Control(31)=   "lblMechModel"
         Tab(0).Control(32)=   "lblMechFrame"
         Tab(0).Control(33)=   "lblMechImpSz"
         Tab(0).Control(34)=   "lblMechHp"
         Tab(0).Control(35)=   "lblMechRpm"
         Tab(0).Control(36)=   "lblMechCap"
         Tab(0).Control(37)=   "lblMechtdh"
         Tab(0).Control(38)=   "lblMechSize"
         Tab(0).Control(39)=   "lblMechCatNo"
         Tab(0).Control(40)=   "lblMechMinRpm"
         Tab(0).Control(41)=   "lblMechMaxRpm"
         Tab(0).Control(42)=   "lblMechcfm"
         Tab(0).Control(43)=   "lblMechPipeSize"
         Tab(0).Control(44)=   "lblMechPipeType"
         Tab(0).Control(45)=   "lblMechNoValvesTypes"
         Tab(0).Control(46)=   "lblMechMiscNPData"
         Tab(0).Control(47)=   "lblMechRecomSpareParts"
         Tab(0).ControlCount=   48
         TabCaption(1)   =   "Electrical NP Data"
         TabPicture(1)   =   "frmEquipment.frx":001C
         Tab(1).ControlEnabled=   -1  'True
         Tab(1).Control(0)=   "lblElecRecomSpareParts"
         Tab(1).Control(0).Enabled=   0   'False
         Tab(1).Control(1)=   "lblElecMiscNPData"
         Tab(1).Control(1).Enabled=   0   'False
         Tab(1).Control(2)=   "lblElecOppEndBrg"
         Tab(1).Control(2).Enabled=   0   'False
         Tab(1).Control(3)=   "lblElecShaftEndBrg"
         Tab(1).Control(3).Enabled=   0   'False
         Tab(1).Control(4)=   "lblElecDesign"
         Tab(1).Control(4).Enabled=   0   'False
         Tab(1).Control(5)=   "lblElecInslCl"
         Tab(1).Control(5).Enabled=   0   'False
         Tab(1).Control(6)=   "lblElecDuty"
         Tab(1).Control(6).Enabled=   0   'False
         Tab(1).Control(7)=   "lblElecAmp"
         Tab(1).Control(7).Enabled=   0   'False
         Tab(1).Control(8)=   "lblElecV"
         Tab(1).Control(8).Enabled=   0   'False
         Tab(1).Control(9)=   "lblElecSf"
         Tab(1).Control(9).Enabled=   0   'False
         Tab(1).Control(10)=   "lblElecPhs"
         Tab(1).Control(10).Enabled=   0   'False
         Tab(1).Control(11)=   "lblElecHz"
         Tab(1).Control(11).Enabled=   0   'False
         Tab(1).Control(12)=   "lblElecRpm"
         Tab(1).Control(12).Enabled=   0   'False
         Tab(1).Control(13)=   "lblElecHp"
         Tab(1).Control(13).Enabled=   0   'False
         Tab(1).Control(14)=   "lblElecCatNo"
         Tab(1).Control(14).Enabled=   0   'False
         Tab(1).Control(15)=   "lblElecSerial"
         Tab(1).Control(15).Enabled=   0   'False
         Tab(1).Control(16)=   "lblElecID"
         Tab(1).Control(16).Enabled=   0   'False
         Tab(1).Control(17)=   "lblElecModel"
         Tab(1).Control(17).Enabled=   0   'False
         Tab(1).Control(18)=   "lblElecFrame"
         Tab(1).Control(18).Enabled=   0   'False
         Tab(1).Control(19)=   "txtElecSerial"
         Tab(1).Control(19).Enabled=   0   'False
         Tab(1).Control(20)=   "txtElecID"
         Tab(1).Control(20).Enabled=   0   'False
         Tab(1).Control(21)=   "txtElecModel"
         Tab(1).Control(21).Enabled=   0   'False
         Tab(1).Control(22)=   "txtElecSf"
         Tab(1).Control(22).Enabled=   0   'False
         Tab(1).Control(23)=   "txtElecPhs"
         Tab(1).Control(23).Enabled=   0   'False
         Tab(1).Control(24)=   "txtElecRpm"
         Tab(1).Control(24).Enabled=   0   'False
         Tab(1).Control(25)=   "txtElecHp"
         Tab(1).Control(25).Enabled=   0   'False
         Tab(1).Control(26)=   "txtElecCatNo"
         Tab(1).Control(26).Enabled=   0   'False
         Tab(1).Control(27)=   "txtElecFrame"
         Tab(1).Control(27).Enabled=   0   'False
         Tab(1).Control(28)=   "txtElecDesign"
         Tab(1).Control(28).Enabled=   0   'False
         Tab(1).Control(29)=   "txtElecInslCl"
         Tab(1).Control(29).Enabled=   0   'False
         Tab(1).Control(30)=   "txtElecDuty"
         Tab(1).Control(30).Enabled=   0   'False
         Tab(1).Control(31)=   "txtElecAmp"
         Tab(1).Control(31).Enabled=   0   'False
         Tab(1).Control(32)=   "txtElecV"
         Tab(1).Control(32).Enabled=   0   'False
         Tab(1).Control(33)=   "txtElecOppEndBrg"
         Tab(1).Control(33).Enabled=   0   'False
         Tab(1).Control(34)=   "txtElecShaftEndBrg"
         Tab(1).Control(34).Enabled=   0   'False
         Tab(1).Control(35)=   "txtElecMiscNpData"
         Tab(1).Control(35).Enabled=   0   'False
         Tab(1).Control(36)=   "txtElecRecomSpareParts"
         Tab(1).Control(36).Enabled=   0   'False
         Tab(1).Control(37)=   "txtElecHz"
         Tab(1).Control(37).Enabled=   0   'False
         Tab(1).ControlCount=   38
         Begin VB.TextBox txtElecHz 
            DataField       =   "elec_hz"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   840
            MaxLength       =   3
            TabIndex        =   36
            Top             =   1200
            Width           =   495
         End
         Begin VB.TextBox txtMechBelt2 
            DataField       =   "mech_belt2"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -70560
            MaxLength       =   20
            TabIndex        =   23
            Top             =   2280
            Width           =   2655
         End
         Begin VB.TextBox txtMechBelt1 
            DataField       =   "mech_belt1"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -74160
            MaxLength       =   20
            TabIndex        =   22
            Top             =   2280
            Width           =   2655
         End
         Begin VB.TextBox txtMechAirFilter 
            DataField       =   "mech_air_filter"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -70560
            MaxLength       =   20
            TabIndex        =   21
            Top             =   1920
            Width           =   2655
         End
         Begin VB.TextBox txtMechOilFilter 
            DataField       =   "mech_oil_filter"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -74160
            MaxLength       =   20
            TabIndex        =   20
            Top             =   1920
            Width           =   2655
         End
         Begin VB.TextBox txtMechOil 
            DataField       =   "mech_oil"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -70560
            MaxLength       =   20
            TabIndex        =   19
            Top             =   1560
            Width           =   2655
         End
         Begin VB.TextBox txtElecRecomSpareParts 
            DataField       =   "elec_recommended_spare_parts"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   3240
            MaxLength       =   30
            TabIndex        =   47
            Top             =   3960
            Width           =   2655
         End
         Begin VB.TextBox txtElecMiscNpData 
            DataField       =   "elec_misc_nameplate_data"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   765
            Left            =   3240
            MaxLength       =   65
            MultiLine       =   -1  'True
            ScrollBars      =   2  'Vertical
            TabIndex        =   46
            Top             =   3120
            Width           =   4695
         End
         Begin VB.TextBox txtElecShaftEndBrg 
            DataField       =   "elec_shaft_end_brg"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   3240
            MaxLength       =   13
            TabIndex        =   44
            Top             =   2400
            Width           =   1935
         End
         Begin VB.TextBox txtElecOppEndBrg 
            DataField       =   "elec_opp_end_brg"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   3240
            MaxLength       =   13
            TabIndex        =   45
            Top             =   2760
            Width           =   1935
         End
         Begin VB.TextBox txtElecV 
            DataField       =   "elec_v"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   6000
            MaxLength       =   12
            TabIndex        =   39
            Top             =   1200
            Width           =   1815
         End
         Begin VB.TextBox txtElecAmp 
            DataField       =   "elec_amp"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   840
            MaxLength       =   12
            TabIndex        =   40
            Top             =   1560
            Width           =   1815
         End
         Begin VB.TextBox txtElecDuty 
            DataField       =   "elec_duty"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   3240
            MaxLength       =   5
            TabIndex        =   41
            Top             =   1560
            Width           =   735
         End
         Begin VB.TextBox txtElecInslCl 
            DataField       =   "elec_insl_cl"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   6000
            MaxLength       =   3
            TabIndex        =   42
            Top             =   1560
            Width           =   495
         End
         Begin VB.TextBox txtElecDesign 
            DataField       =   "elec_design"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   7200
            MaxLength       =   3
            TabIndex        =   43
            Top             =   1560
            Width           =   495
         End
         Begin VB.TextBox txtElecFrame 
            DataField       =   "elec_frame"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   840
            MaxLength       =   7
            TabIndex        =   32
            Top             =   840
            Width           =   1095
         End
         Begin VB.TextBox txtElecCatNo 
            DataField       =   "elec_cat_no"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   3240
            MaxLength       =   10
            TabIndex        =   33
            Top             =   840
            Width           =   1095
         End
         Begin VB.TextBox txtElecHp 
            DataField       =   "elec_hp"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   6000
            MaxLength       =   5
            TabIndex        =   34
            Top             =   840
            Width           =   735
         End
         Begin VB.TextBox txtElecRpm 
            DataField       =   "elec_rpm"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   7200
            MaxLength       =   6
            TabIndex        =   35
            Top             =   840
            Width           =   855
         End
         Begin VB.TextBox txtElecPhs 
            DataField       =   "elec_phs"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   3240
            MaxLength       =   2
            TabIndex        =   37
            Top             =   1200
            Width           =   375
         End
         Begin VB.TextBox txtElecSf 
            DataField       =   "elec_sf"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   4200
            MaxLength       =   4
            TabIndex        =   38
            Top             =   1200
            Width           =   615
         End
         Begin VB.TextBox txtElecModel 
            DataField       =   "elec_model"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   6000
            MaxLength       =   15
            TabIndex        =   31
            Top             =   480
            Width           =   1935
         End
         Begin VB.TextBox txtElecID 
            DataField       =   "elec_id"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   3240
            MaxLength       =   13
            TabIndex        =   30
            Top             =   480
            Width           =   1935
         End
         Begin VB.TextBox txtElecSerial 
            DataField       =   "elec_serial"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   840
            MaxLength       =   13
            TabIndex        =   29
            Top             =   480
            Width           =   1935
         End
         Begin VB.TextBox txtMechPipeSize 
            DataField       =   "mech_pipe_size"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -72480
            MaxLength       =   30
            TabIndex        =   24
            Top             =   2640
            Width           =   3975
         End
         Begin VB.TextBox txtMechPipeType 
            DataField       =   "mech_pipe_type"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -72480
            MaxLength       =   20
            TabIndex        =   25
            Top             =   3000
            Width           =   2655
         End
         Begin VB.TextBox txtMechNoOfValvesTypes 
            DataField       =   "mech_no_valves_types"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -72480
            MaxLength       =   30
            TabIndex        =   26
            Top             =   3360
            Width           =   4335
         End
         Begin VB.TextBox txtMechMiscNPData 
            DataField       =   "mech_misc_nameplate_data"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   645
            Left            =   -72480
            MaxLength       =   65
            MultiLine       =   -1  'True
            ScrollBars      =   2  'Vertical
            TabIndex        =   27
            Top             =   3720
            Width           =   5535
         End
         Begin VB.TextBox txtMechRecomSpareParts 
            DataField       =   "mech_recommended_spare_parts"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -72480
            MaxLength       =   30
            TabIndex        =   28
            Top             =   4440
            Width           =   3135
         End
         Begin VB.TextBox txtMechCatNo 
            DataField       =   "mech_cat_no"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -70560
            MaxLength       =   13
            TabIndex        =   15
            Top             =   1200
            Width           =   1815
         End
         Begin VB.TextBox txtMechMaxRpm 
            DataField       =   "mech_max_rpm"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -67920
            MaxLength       =   5
            TabIndex        =   16
            Top             =   1200
            Width           =   735
         End
         Begin VB.TextBox txtMechMinRpm 
            DataField       =   "mech_min_rpm"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -74160
            MaxLength       =   5
            TabIndex        =   17
            Top             =   1560
            Width           =   735
         End
         Begin VB.TextBox txtMechCfm 
            DataField       =   "mech_cfm"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -72360
            MaxLength       =   5
            TabIndex        =   18
            Top             =   1560
            Width           =   735
         End
         Begin VB.TextBox txtMechSerial 
            DataField       =   "mech_serial"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -74160
            MaxLength       =   13
            TabIndex        =   5
            Top             =   480
            Width           =   1935
         End
         Begin VB.TextBox txtMechID 
            DataField       =   "mech_id"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -71640
            MaxLength       =   13
            TabIndex        =   6
            Top             =   480
            Width           =   1935
         End
         Begin VB.TextBox txtMechFrame 
            DataField       =   "mech_frame"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -74160
            MaxLength       =   7
            TabIndex        =   8
            Top             =   840
            Width           =   1095
         End
         Begin VB.TextBox txtMechModel 
            DataField       =   "mech_model"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -69000
            MaxLength       =   15
            TabIndex        =   7
            Top             =   480
            Width           =   1935
         End
         Begin VB.TextBox txtMechImpSz 
            DataField       =   "mech_imp_sz"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -72360
            MaxLength       =   6
            TabIndex        =   9
            Top             =   840
            Width           =   855
         End
         Begin VB.TextBox txtMechHp 
            DataField       =   "mech_hp"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -70560
            MaxLength       =   5
            TabIndex        =   10
            Top             =   840
            Width           =   735
         End
         Begin VB.TextBox txtMechRpm 
            DataField       =   "mech_rpm"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -69240
            MaxLength       =   6
            TabIndex        =   11
            Top             =   840
            Width           =   855
         End
         Begin VB.TextBox txtMechCap 
            DataField       =   "mech_cap"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -67920
            MaxLength       =   6
            TabIndex        =   12
            Top             =   840
            Width           =   855
         End
         Begin VB.TextBox txtMechSize 
            DataField       =   "mech_size"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -74160
            MaxLength       =   8
            TabIndex        =   13
            Top             =   1200
            Width           =   1095
         End
         Begin VB.TextBox txtMechTdh 
            DataField       =   "mech_tdh"
            DataSource      =   "AdodcMaintenance"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   285
            Left            =   -72360
            MaxLength       =   5
            TabIndex        =   14
            Top             =   1200
            Width           =   735
         End
         Begin VB.Label lblMechBelt2 
            Caption         =   "Belt2"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -71040
            TabIndex        =   91
            Top             =   2280
            Width           =   375
         End
         Begin VB.Label lblMechBelt1 
            Caption         =   "Belt1"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -74640
            TabIndex        =   90
            Top             =   2280
            Width           =   375
         End
         Begin VB.Label lblMechAirFilter 
            Caption         =   "Air Filter"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -71160
            TabIndex        =   89
            Top             =   1920
            Width           =   615
         End
         Begin VB.Label lblMechOilFilter 
            Caption         =   "Oil Filter"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -74760
            TabIndex        =   88
            Top             =   1920
            Width           =   615
         End
         Begin VB.Label lblMechOil 
            Caption         =   "Oil"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -70800
            TabIndex        =   87
            Top             =   1560
            Width           =   255
         End
         Begin VB.Label lblElecFrame 
            Caption         =   "frame"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   360
            TabIndex        =   86
            Top             =   840
            Width           =   495
         End
         Begin VB.Label lblElecModel 
            Caption         =   "model"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   5520
            TabIndex        =   85
            Top             =   480
            Width           =   495
         End
         Begin VB.Label lblElecID 
            Caption         =   "id"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   3000
            TabIndex        =   84
            Top             =   480
            Width           =   255
         End
         Begin VB.Label lblElecSerial 
            Caption         =   "serial"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   360
            TabIndex        =   83
            Top             =   480
            Width           =   495
         End
         Begin VB.Label lblElecCatNo 
            Caption         =   "cat no"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   2760
            TabIndex        =   82
            Top             =   840
            Width           =   495
         End
         Begin VB.Label lblElecHp 
            Caption         =   "hp"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   5760
            TabIndex        =   81
            Top             =   840
            Width           =   255
         End
         Begin VB.Label lblElecRpm 
            Caption         =   "rpm"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   6840
            TabIndex        =   80
            Top             =   840
            Width           =   375
         End
         Begin VB.Label lblElecHz 
            Caption         =   "hz"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   600
            TabIndex        =   79
            Top             =   1200
            Width           =   255
         End
         Begin VB.Label lblElecPhs 
            Caption         =   "phs"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   2760
            TabIndex        =   78
            Top             =   1200
            Width           =   375
         End
         Begin VB.Label lblElecSf 
            Caption         =   "sf"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   3960
            TabIndex        =   77
            Top             =   1200
            Width           =   255
         End
         Begin VB.Label lblElecV 
            Caption         =   "v"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   5760
            TabIndex        =   76
            Top             =   1200
            Width           =   135
         End
         Begin VB.Label lblElecAmp 
            Caption         =   "amp"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   480
            TabIndex        =   75
            Top             =   1560
            Width           =   375
         End
         Begin VB.Label lblElecDuty 
            Caption         =   "duty"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   2880
            TabIndex        =   74
            Top             =   1560
            Width           =   375
         End
         Begin VB.Label lblElecInslCl 
            Caption         =   "insl cl"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   5520
            TabIndex        =   73
            Top             =   1560
            Width           =   495
         End
         Begin VB.Label lblElecDesign 
            Caption         =   "design"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   6600
            TabIndex        =   72
            Top             =   1560
            Width           =   495
         End
         Begin VB.Label lblElecShaftEndBrg 
            Caption         =   "shaft end brg"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   2280
            TabIndex        =   71
            Top             =   2400
            Width           =   975
         End
         Begin VB.Label lblElecOppEndBrg 
            Caption         =   "opp. end brg"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   2280
            TabIndex        =   70
            Top             =   2760
            Width           =   975
         End
         Begin VB.Label lblElecMiscNPData 
            Caption         =   "Misc. NP Data"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   2160
            TabIndex        =   69
            Top             =   3120
            Width           =   1095
         End
         Begin VB.Label lblElecRecomSpareParts 
            Caption         =   "Recommended Spare Parts"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   1200
            TabIndex        =   68
            Top             =   3960
            Width           =   2055
         End
         Begin VB.Label lblMechSerial 
            Alignment       =   2  'Center
            Caption         =   "serial"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -74640
            TabIndex        =   67
            Top             =   480
            Width           =   495
         End
         Begin VB.Label lblMechID 
            Caption         =   "id"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -71880
            TabIndex        =   66
            Top             =   480
            Width           =   255
         End
         Begin VB.Label lblMechModel 
            Caption         =   "model"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -69480
            TabIndex        =   65
            Top             =   480
            Width           =   495
         End
         Begin VB.Label lblMechFrame 
            Caption         =   "frame"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -74640
            TabIndex        =   64
            Top             =   840
            Width           =   495
         End
         Begin VB.Label lblMechImpSz 
            Caption         =   "imp sz"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -72840
            TabIndex        =   63
            Top             =   840
            Width           =   495
         End
         Begin VB.Label lblMechHp 
            Caption         =   "hp"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -70800
            TabIndex        =   62
            Top             =   840
            Width           =   255
         End
         Begin VB.Label lblMechRpm 
            Caption         =   "rpm"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -69600
            TabIndex        =   61
            Top             =   840
            Width           =   375
         End
         Begin VB.Label lblMechCap 
            Caption         =   "cap"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -68280
            TabIndex        =   60
            Top             =   840
            Width           =   375
         End
         Begin VB.Label lblMechtdh 
            Alignment       =   1  'Right Justify
            Caption         =   "tdh"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -72720
            TabIndex        =   59
            Top             =   1200
            Width           =   255
         End
         Begin VB.Label lblMechSize 
            Caption         =   "size"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -74520
            TabIndex        =   58
            Top             =   1200
            Width           =   375
         End
         Begin VB.Label lblMechCatNo 
            Caption         =   "cat no"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -71160
            TabIndex        =   57
            Top             =   1200
            Width           =   495
         End
         Begin VB.Label lblMechMinRpm 
            Caption         =   "min rpm"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -74760
            TabIndex        =   56
            Top             =   1560
            Width           =   615
         End
         Begin VB.Label lblMechMaxRpm 
            Caption         =   "max rpm"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -68520
            TabIndex        =   55
            Top             =   1200
            Width           =   615
         End
         Begin VB.Label lblMechcfm 
            Caption         =   "cfm"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -72720
            TabIndex        =   54
            Top             =   1560
            Width           =   375
         End
         Begin VB.Label lblMechPipeSize 
            Caption         =   "Pipe Size(s)"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -73440
            TabIndex        =   53
            Top             =   2640
            Width           =   975
         End
         Begin VB.Label lblMechPipeType 
            Caption         =   "Pipe Type"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -73320
            TabIndex        =   52
            Top             =   3000
            Width           =   735
         End
         Begin VB.Label lblMechNoValvesTypes 
            Caption         =   "No. Valves and Types"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -74160
            TabIndex        =   51
            Top             =   3360
            Width           =   1695
         End
         Begin VB.Label lblMechMiscNPData 
            Caption         =   "Misc. NP Data"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -73680
            TabIndex        =   50
            Top             =   3720
            Width           =   1095
         End
         Begin VB.Label lblMechRecomSpareParts 
            Caption         =   "Recommended Spare Parts"
            BeginProperty Font 
               Name            =   "MS Sans Serif"
               Size            =   8.25
               Charset         =   0
               Weight          =   400
               Underline       =   0   'False
               Italic          =   0   'False
               Strikethrough   =   0   'False
            EndProperty
            Height          =   255
            Left            =   -74520
            TabIndex        =   49
            Top             =   4440
            Width           =   2055
         End
      End
      Begin MSMask.MaskEdBox txtMeterReadingDate 
         Height          =   255
         Left            =   6960
         TabIndex        =   3
         Top             =   480
         Width           =   1095
         _ExtentX        =   1931
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
         TabIndex        =   99
         Top             =   0
         Width           =   2655
      End
      Begin VB.Label lblEquipKey 
         Caption         =   "Equipment Key:"
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
         Left            =   240
         TabIndex        =   95
         Top             =   480
         Width           =   1335
      End
      Begin VB.Label lblEquipDesc 
         Caption         =   "Equipment Desc:"
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
         TabIndex        =   94
         Top             =   840
         Width           =   1455
      End
      Begin VB.Label lblLastMeterReadingDate 
         Caption         =   "Meter Reading Date:"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   5400
         TabIndex        =   93
         Top             =   480
         Width           =   1575
      End
      Begin VB.Label lblLastMeterReading 
         Caption         =   "Meter Reading:"
         BeginProperty Font 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   400
            Underline       =   0   'False
            Italic          =   0   'False
            Strikethrough   =   0   'False
         EndProperty
         Height          =   255
         Left            =   3000
         TabIndex        =   92
         Top             =   480
         Width           =   1215
      End
   End
   Begin VB.Frame FramGrid 
      BeginProperty Font 
         Name            =   "MS Sans Serif"
         Size            =   12
         Charset         =   0
         Weight          =   400
         Underline       =   0   'False
         Italic          =   0   'False
         Strikethrough   =   0   'False
      EndProperty
      Height          =   5895
      Left            =   240
      TabIndex        =   97
      Top             =   0
      Width           =   8175
      Begin MSDataGridLib.DataGrid DGridEquipment 
         Height          =   5535
         Left            =   120
         TabIndex        =   98
         Top             =   240
         Width           =   7935
         _ExtentX        =   13996
         _ExtentY        =   9763
         _Version        =   393216
         AllowUpdate     =   0   'False
         HeadLines       =   1
         RowHeight       =   15
         BeginProperty HeadFont {0BE35203-8F91-11CE-9DE3-00AA004BB851} 
            Name            =   "MS Sans Serif"
            Size            =   8.25
            Charset         =   0
            Weight          =   700
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
         TabIndex        =   100
         Top             =   0
         Width           =   1455
      End
   End
End
Attribute VB_Name = "frmEquipment"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = False
Attribute VB_PredeclaredId = True
Attribute VB_Exposed = False
'Option Explicit

Dim ans As Integer
Dim intStatus As Integer ' 1 - Update, 2 - Add
Dim rsEquipRetrieve As ADODB.Recordset
Dim lngMeterReading As Long

'
' All the functions for Equipment are in this form module with
' the exception of validation and returning recordset

Public Sub SearchRec()
    ' Not supported for equipment
End Sub

Public Sub CheckChange()
    ' This will check if value on any field has been changed before
    ' moving to new window
    If intStatus = 2 Then
        ans = MsgBox("Do you want to save new record?", vbYesNo)
        If ans = 6 Then
            Save
        End If
        ans = 0
    Else
        ChangedData
    End If

End Sub

Public Function CheckRecordset() As Integer

'
' this function is used only to find out
' if there is recordset to work on
'

    Dim strSQL As String

On Error GoTo errorhandler
    
    If intPlantPass = 0 Then
        strSQL = "select distinct e.*, p.* from plant p inner join equipment e on p.plant_id = e.plant_fk where e.plant_fk <> 0"
    Else
        strSQL = "select distinct e.*, p.* from plant p inner join equipment e on p.plant_id = e.plant_fk where e.plant_fk = " & intPlantPass
    End If
    
    Set rsEquipRetrieve = RecordsetEquip(strSQL)
    
    If rsEquipRetrieve.EOF = True Or rsEquipRetrieve.BOF = True Then
        CheckRecordset = 2
        Exit Function
    Else
        CheckRecordset = 1
    End If
    Set rsEquipRetrieve = Nothing
Exit Function
errorhandler:

MsgBox "Error Number - " & Err.Number & ": WOS : Equipment - CheckRecordset: Description - " & Err.Description
End Function

Public Sub FormView()
'
' User can switch between two views
'

On Error GoTo errorhandler

    FramGrid.Visible = False
    Framform.Visible = True

Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS : Equipment - Form View: Description - " & Err.Description
End Sub

Public Sub GridView()
'
' User can switch between two views
'

On Error GoTo errorhandler

    Framform.Visible = False
    FramGrid.Visible = True
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS : Equipment - Grid View: Description - " & Err.Description
End Sub

Public Sub Add()

'
' Used basically to clear the fields in the form
' User is not allowed to add unless a plant has been selected
'

On Error GoTo errorhandler
    ' if intTypeEquip = 1 then it is in add mode coming from outside or any other
    ' way except by clicking "Add"
    ' intTypeEquip = 2 if in AddMode by clicking "Add"
    ' else equipment key is not used
    '
    ' intStatus = 2 is used to know that it is a add and not update
    '
    If intTypeEquip <> 1 Then
        If intPlantPass = 0 Then
            ans = MsgBox("Can not add equipment unless a specific plant is selected. Please exit the application to reselect a plant.")
        Else
            Clear
            lngMeterReading = 0
            intTypeEquip = 2
            intStatus = 2
            txtCount = "New Record"
            FormView
            MDIFormWOS.AddMode
        End If
        Me.txtEquipKey.SetFocus
    Else
        Clear
        lngMeterReading = 0
        intStatus = 2
        txtCount = "New Record"
        FormView
        MDIFormWOS.AddMode
    End If
    Me.lblPlantName.Caption = intPlantPass & " - " & strPlantPass
    Me.lblPlantNameG.Caption = intPlantPass & " - " & strPlantPass
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - Add: Description - " & Err.Description
    
End Sub

Public Sub Cancel()

'
' Unloads and reloads the form
'

On Error GoTo errorhandler

    Unload Me
    frmPlant.CheckAll "equip"

Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - Cancel: Description - " & Err.Description
End Sub

Public Sub Clear()
    
'
' It will first check if data has been changed. It will ask user if he/she
' wants to save the record if changed and then clears the fields on the form
'

On Error GoTo errorhandler
    If intTypeEquip <> 1 Then
        ChangedData
    'Else
    '    intTypeEquip = 2
    End If
    
    Me.txtEquipKey.Text = ""
    Me.txtEquipDesc.Text = ""
    Me.txtMeterReading.Text = ""
    Me.txtMeterReadingDate.Text = ""
    Me.txtMechSerial.Text = ""
    Me.txtMechID.Text = ""
    Me.txtMechModel.Text = ""
    Me.txtMechFrame.Text = ""
    Me.txtMechImpSz.Text = ""
    Me.txtMechHp.Text = ""
    Me.txtMechRpm.Text = ""
    Me.txtMechCap.Text = ""
    Me.txtMechSize.Text = ""
    Me.txtMechTdh.Text = ""
    Me.txtMechCatNo.Text = ""
    Me.txtMechMaxRpm.Text = ""
    Me.txtMechMinRpm.Text = ""
    Me.txtMechCfm.Text = ""
    Me.txtMechOil.Text = ""
    Me.txtMechOilFilter.Text = ""
    Me.txtMechAirFilter.Text = ""
    Me.txtMechBelt1.Text = ""
    Me.txtMechBelt2.Text = ""
    Me.txtMechPipeSize.Text = ""
    Me.txtMechPipeType.Text = ""
    Me.txtMechNoOfValvesTypes.Text = ""
    Me.txtMechMiscNPData.Text = ""
    Me.txtMechRecomSpareParts.Text = ""
    Me.txtElecSerial.Text = ""
    Me.txtElecID.Text = ""
    Me.txtElecModel.Text = ""
    Me.txtElecFrame.Text = ""
    Me.txtElecCatNo.Text = ""
    Me.txtElecHp.Text = ""
    Me.txtElecRpm.Text = ""
    Me.txtElecV.Text = ""
    Me.txtElecAmp.Text = ""
    Me.txtElecHz.Text = ""
    Me.txtElecPhs.Text = ""
    Me.txtElecSf.Text = ""
    Me.txtElecDuty.Text = ""
    Me.txtElecInslCl.Text = ""
    Me.txtElecDesign.Text = ""
    Me.txtElecShaftEndBrg.Text = ""
    Me.txtElecOppEndBrg.Text = ""
    Me.txtElecMiscNpData.Text = ""
    Me.txtElecRecomSpareParts.Text = ""

Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - Clear: Description - " & Err.Description
End Sub

Public Sub Delete()

'
' Deletes the record on display and moves to next record
' if there is no next record then moves to previuos
'

On Error GoTo errorhandler

    ans = 0
    FormView
    ans = MsgBox("Are you sure that you want to delete this record?", vbYesNo, "WOS")
    If ans = 6 Then
        rsEquipRetrieve.Delete
        rsEquipRetrieve.MoveNext
        If rsEquipRetrieve.EOF Then
            rsEquipRetrieve.MovePrevious
        End If
        FillFields
    End If

Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - Delete: Description - " & Err.Description
End Sub

Public Sub RefreshRec()

'
'
'

On Error GoTo errorhandler

    Unload Me
    frmPlant.CheckAll "equip"
    'frmEquipment.Show

Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - Refresh: Description - " & Err.Description
End Sub

Public Sub Save()

Dim strSQL As String

'
' Calls AddUpdateEquip to add or update records
' If there is no existing recordset it creates an empty recordset
'
    
    Dim intResult As Integer

On Error GoTo errorhandler

    
    FormView
    intResult = ValidateEquipment
    If intResult = 0 Then
        If intTypeEquip = 1 Then
            ' do not check if some thing is changed
            strSQL = "Select * from equipment where plant_fk <> 0"
            Set rsEquipRetrieve = RecordsetEquip(strSQL)
            rsEquipRetrieve.AddNew
            intTypeEquip = 0
        ElseIf intTypeEquip = 2 Then
            'AddUpdateEquip
            rsEquipRetrieve.AddNew
            intTypeEquip = 0
        End If
    
        AddUpdateEquip
        If intStatus = 2 Then
            Cancel
        End If
        intStatus = 0
        'MDIFormWOS.cmdAdd.Enabled = True
    End If

Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - Save: Description - " & Err.Description
End Sub

Public Sub AddUpdateEquip()

'
' If intSatus is 1 then it updates the existing recordset otherwise
' adds a new one
'

On Error GoTo errorhandler

    If intStatus = 2 Then
        ' rsEquipRetrieve.AddNew
        ' this has been done when save sub-procedure is called
    Else
        rsEquipRetrieve.Update
    End If
    rsEquipRetrieve!equip_key = Me.txtEquipKey.Text
    rsEquipRetrieve!equip_desc = Me.txtEquipDesc.Text
    If txtMeterReading.Text <> "" Then
        rsEquipRetrieve!last_meter_reading = Me.txtMeterReading.Text
    Else
        rsEquipRetrieve!last_meter_reading = Null
    End If
    If txtMeterReadingDate.Text <> "" Then
        rsEquipRetrieve!last_meter_reading_date = Me.txtMeterReadingDate.Text
    Else
        rsEquipRetrieve!last_meter_reading_date = Null
    End If
    If intPlantPass <> 0 Then
        rsEquipRetrieve!plant_fk = intPlantPass
    End If
    rsEquipRetrieve!mech_serial = Me.txtMechSerial.Text
    rsEquipRetrieve!mech_id = Me.txtMechID.Text
    rsEquipRetrieve!mech_model = Me.txtMechModel.Text
    rsEquipRetrieve!mech_frame = Me.txtMechFrame.Text
    rsEquipRetrieve!mech_imp_sz = Me.txtMechImpSz.Text
    rsEquipRetrieve!mech_hp = Me.txtMechHp.Text
    rsEquipRetrieve!mech_rpm = Me.txtMechRpm.Text
    rsEquipRetrieve!mech_cap = Me.txtMechCap.Text
    rsEquipRetrieve!mech_size = Me.txtMechSize.Text
    rsEquipRetrieve!mech_tdh = Me.txtMechTdh.Text
    rsEquipRetrieve!mech_cat_no = Me.txtMechCatNo.Text
    rsEquipRetrieve!mech_max_rpm = Me.txtMechMaxRpm.Text
    rsEquipRetrieve!mech_min_rpm = Me.txtMechMinRpm.Text
    rsEquipRetrieve!mech_cfm = Me.txtMechCfm.Text
    rsEquipRetrieve!mech_oil = Me.txtMechOil.Text
    rsEquipRetrieve!mech_oil_filter = Me.txtMechOilFilter.Text
    rsEquipRetrieve!mech_air_filter = Me.txtMechAirFilter.Text
    rsEquipRetrieve!mech_belt1 = Me.txtMechBelt1.Text
    rsEquipRetrieve!mech_belt2 = Me.txtMechBelt2.Text
    rsEquipRetrieve!mech_pipe_size = Me.txtMechPipeSize.Text
    rsEquipRetrieve!mech_pipe_type = Me.txtMechPipeType.Text
    rsEquipRetrieve!mech_no_valves_types = Me.txtMechNoOfValvesTypes.Text
    rsEquipRetrieve!mech_misc_nameplate_data = Me.txtMechMiscNPData.Text
    rsEquipRetrieve!mech_recommended_spare_parts = Me.txtMechRecomSpareParts.Text
    rsEquipRetrieve!elec_serial = Me.txtElecSerial.Text
    rsEquipRetrieve!elec_id = Me.txtElecID.Text
    rsEquipRetrieve!elec_model = Me.txtElecModel.Text
    rsEquipRetrieve!elec_frame = Me.txtElecFrame.Text
    rsEquipRetrieve!elec_cat_no = Me.txtElecCatNo.Text
    rsEquipRetrieve!elec_hp = Me.txtElecHp.Text
    rsEquipRetrieve!elec_rpm = Me.txtElecRpm.Text
    rsEquipRetrieve!elec_v = Me.txtElecV.Text
    rsEquipRetrieve!elec_amp = Me.txtElecAmp.Text
    rsEquipRetrieve!elec_hz = Me.txtElecHz.Text
    rsEquipRetrieve!elec_phs = Me.txtElecPhs.Text
    rsEquipRetrieve!elec_sf = Me.txtElecSf.Text
    rsEquipRetrieve!elec_duty = Me.txtElecDuty.Text
    rsEquipRetrieve!elec_insl_cl = Me.txtElecInslCl.Text
    rsEquipRetrieve!elec_design = Me.txtElecDesign.Text
    rsEquipRetrieve!elec_shaft_end_brg = Me.txtElecShaftEndBrg.Text
    rsEquipRetrieve!elec_opp_end_brg = Me.txtElecOppEndBrg.Text
    rsEquipRetrieve!elec_misc_nameplate_data = Me.txtElecMiscNpData.Text
    rsEquipRetrieve!elec_recommended_spare_parts = Me.txtElecRecomSpareParts.Text
      
    rsEquipRetrieve.MoveNext
    rsEquipRetrieve.MovePrevious
    
    If intStatus = 2 Then
        ans = MsgBox("New Equipment: " & txtEquipKey.Text & " has been added.", vbOKOnly, "WOS")
    Else
        ans = MsgBox("The record has been updated.", vbOKOnly, "WOS")
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - AddUpdateEquip: Description - " & Err.Description
End Sub

Private Sub DGridEquipment_RowColChange(LastRow As Variant, ByVal LastCol As Integer)

'
' if Row or col changed in the grid values of the new record
' are placed in the fields of the invisible framform
'

On Error GoTo errorhandler
    If FramGrid.Visible = True Then
        FillFields
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - DGridEquipment RowColChange: Description - " & Err.Description
End Sub

Public Sub FirstRec()

'
' Move the recordset to the first record and fill appropriate fields
'

On Error GoTo errorhandler

    ChangedData
    rsEquipRetrieve.MoveFirst
    FillFields
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - FirstRec: Description - " & Err.Description
End Sub

Public Sub PrintScreen()
    ' do nothing
End Sub

Public Sub LastRec()

'
' Move the recordset to the last record and fill appropriate fields
'

On Error GoTo errorhandler

    ChangedData
    rsEquipRetrieve.MoveLast
    FillFields
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - LastRec: Description - " & Err.Description
End Sub

Public Sub NextRec()

'
' Move the recordset to the next record and fill appropriate fields
'

On Error GoTo errorhandler

    ChangedData
    rsEquipRetrieve.MoveNext
    If rsEquipRetrieve.EOF Then
        rsEquipRetrieve.MovePrevious
        ans = MsgBox("Already at the end of the list. Can not move any further.")
    End If
    FillFields
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - NextRec: Description - " & Err.Description
End Sub

Public Sub PrevRec()

'
' Move the recordset to the previous records and fill appropriate fields
'

On Error GoTo errorhandler

    ChangedData
    rsEquipRetrieve.MovePrevious
    If rsEquipRetrieve.BOF Then
        rsEquipRetrieve.MoveNext
        ans = MsgBox("Already at the beginning of the list. Can not move back any more.")
    End If
    FillFields
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - PrevRec: Description - " & Err.Description
End Sub

Public Sub SetGrid()

'
' When user clicks on GridView button all the column headings are
' set neatly
'
    
    Dim intGridWidth As Integer
    Dim col1, col2, col3, col4 As Column
    
On Error GoTo errorhandler

    Set DGridEquipment.DataSource = rsEquipRetrieve
    
    Set col1 = DGridEquipment.Columns(0)
    Set col2 = DGridEquipment.Columns(1)
    Set col3 = DGridEquipment.Columns(2)
    Set col4 = DGridEquipment.Columns(3)
        
    col1.Caption = "ID"
    col2.Caption = "PLANT"
    col3.Caption = "EQUIP KEY"
    col4.Caption = "EQUIP DESC"
        
    intGridWidth = DGridEquipment.Width
    
    col1.Width = (6 / 81) * intGridWidth
    col2.Width = (12 / 81) * intGridWidth
    col3.Width = (18 / 81) * intGridWidth
    col4.Width = (45 / 81) * intGridWidth
        
    'col1.Locked = True
    'col2.Locked = True
    'col3.Locked = True
    'col4.Locked = True
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - SetGrid: Description - " & Err.Description
End Sub

Private Sub Form_Activate()

'
' This event is used to call FindActive function from MDI form
' so as to enable or disable different buttons based on which form
' is active
'

On Error GoTo errorhandler
    'If CheckRecordset = 1 Then
    MDIFormWOS.FindActive (False)
    If intTypeEquip = 1 Then
        MDIFormWOS.AddMode
    End If
    'End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - Form_Activate: Description - " & Err.Description
End Sub

Public Function FormLoadType()

'
' Initially sql is passed to find out if there is recordset then only
' form is opened if there are records. If there is no records then it is set to add mode
'

    Dim strSQL As String
    
On Error GoTo errorhandler
    
    FormView
    
    If CheckRecordset = 2 Then
        intTypeEquip = 1
        Add
    Else
        If intPlantPass = 0 Then
            strSQL = "select distinct e.*, p.* from plant p inner join equipment e on p.plant_id = e.plant_fk where e.plant_fk <> 0"
        Else
            strSQL = "select distinct e.*, p.* from plant p inner join equipment e on p.plant_id = e.plant_fk where e.plant_fk = " & intPlantPass
        End If
        
        Set rsEquipRetrieve = RecordsetEquip(strSQL)
        rsEquipRetrieve.MoveLast
        rsEquipRetrieve.MoveFirst
        
        FillFields
        
        SetGrid
    End If
Exit Function
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - FormLoadType: Description - " & Err.Description
End Function

Private Sub Form_KeyUp(KeyCode As Integer, Shift As Integer)

'
' This procedure can be used for hotkey functionality, which is
' currently working only for History screen
'

    Dim intKeyValue As Integer
    
On Error GoTo errorhandler

    intKeyValue = KeyCode
    
    ' F8(value 119) save then move to previous record
    ' F9(value 120) save then move to next record
    ' F10(value 121) can be used to save then move to the next(new) record
    
    If intKeyValue = 121 Then
        Save
        intTypeEquip = 2
        Add
        MDIFormWOS.SetFocus
        frmEquipment.SetFocus
        frmEquipment.txtEquipKey.SetFocus
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
        frmEquipment.SetFocus
        frmEquipment.txtEquipKey.SetFocus
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
        frmEquipment.SetFocus
        frmEquipment.txtEquipKey.SetFocus
        'MDIFormWOS.FindActive (False)
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - Form_Keyup: Description - " & Err.Description
End Sub

Private Sub Form_Load()

'
' Setting the size and position of the form and
' calling FormLoadType open in AddMode or Update or View Mode
'

On Error GoTo errorhandler
    intStatus = 0
    Me.Height = 7000
    Me.Width = 9300
    Me.Left = 0
    Me.Top = 0
    FormLoadType
        '"select e.equip_id, e.equip_key, " & _
                                "e.equip_desc, e.mech_serial, " & _
                                "e.mech_id, e.mech_model, " & _
                                "e.mech_frame, e.mech_imp_sz, " & _
                                "e.mech_hp, e.mech_rpm, e.mech_cap, " & _
                                "e.mech_size, e.mech_tdh, e.mech_cat_no, " & _
                                "e.mech_max_rpm, e.mech_min_rpm, " & _
                                "e.mech_cfm, e.mech_pipe_size, " & _
                                "e.mech_pipe_type, e.mech_no_valves_types, " & _
                                "e.mech_misc_nameplate_data, e.mech_recommended_spare_parts, " & _
                                "e.elec_serial, e.elec_id, e.elec_model, e.elec_frame, " & _
                                "e.elec_cat_no, e.elec_hp, e.elec_rpm, e.elec_v, " & _
                                "e.elec_amp, e.elec_hz, e.elec_phs, e.elec_sf, " & _
                                "e.elec_duty, e.elec_insl_cl, e.elec_design, " & _
                                "e.elec_shaft_end_brg, e.elec_opp_end_brg, " & _
                                "e.elec_misc_nameplate_data, e.elec_recommended_spare_parts, " & _
                                "e.last_meter_reading, e.last_meter_reading_date " & _
                                "from equipment e, plant p where e.plant_fk = p.plant_id and p.plant_name = '" & (strPlantPass) & "'"
  
    'AdodcMaintenance.Refresh
    
    'If AdodcMaintenance.Recordset.EOF = True Or AdodcMaintenance.Recordset.BOF = True Then
    '    Ans = MsgBox("There are no records for plant " & strPlantPass)
    '    End
    'Else
    '    AdodcMaintenance.Recordset.MoveLast
    '    intRecordCount = AdodcMaintenance.Recordset.RecordCount
    '    If intRecordCount = 0 Then
    '        Ans = MsgBox("There are not records for plant " & strPlantPass & ". Please enter new equipment for it. ")
    '        Me.Hide
    '        frmAddEquip.Show
    '    End If
        
    '    AdodcMaintenance.Recordset.MoveFirst
    'End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - Form_Load: Description - " & Err.Description
End Sub

Private Sub KeepCount()

'
' Updates the counter positioned at the top of the formview frame
'

On Error GoTo errorhandler

    Me.txtCount = "Record No. " & rsEquipRetrieve.AbsolutePosition & " of " & rsEquipRetrieve.RecordCount & " Records"
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - KeepCount: Description - " & Err.Description
End Sub

Public Sub ChangedData()

'
' Checks if any of the fields has changed since it was retrieved and
' shown on the fields
'

    Dim intChangedCount As Integer
    
'On Error GoTo errorhandler

    intChangedCount = 0
    ans = 0
    If rsEquipRetrieve!equip_key <> Me.txtEquipKey.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!equip_desc <> Me.txtEquipDesc.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!last_meter_reading <> Me.txtMeterReading.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!last_meter_reading_date <> Me.txtMeterReadingDate.Text Or (IsNull(rsEquipRetrieve!last_meter_reading_date) And (Me.txtMeterReadingDate.Text <> "")) Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_serial <> Me.txtMechSerial.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_id <> Me.txtMechID.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_model <> Me.txtMechModel.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_frame <> Me.txtMechFrame.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_imp_sz <> Me.txtMechImpSz.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_hp <> Me.txtMechHp.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_rpm <> Me.txtMechRpm.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_cap <> Me.txtMechCap.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_size <> Me.txtMechSize.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_tdh <> Me.txtMechTdh.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_cat_no <> Me.txtMechCatNo.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_max_rpm <> Me.txtMechMaxRpm.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_min_rpm <> Me.txtMechMinRpm.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_cfm <> Me.txtMechCfm.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_oil <> Me.txtMechOil.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_oil_filter <> Me.txtMechOilFilter.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_air_filter <> Me.txtMechAirFilter.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_belt1 <> Me.txtMechBelt1.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_belt2 <> Me.txtMechBelt2.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_pipe_size <> Me.txtMechPipeSize.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_pipe_type <> Me.txtMechPipeType.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_no_valves_types <> Me.txtMechNoOfValvesTypes.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_misc_nameplate_data <> Me.txtMechMiscNPData.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!mech_recommended_spare_parts <> Me.txtMechRecomSpareParts.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_serial <> Me.txtElecSerial.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_id <> Me.txtElecID.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_model <> Me.txtElecModel.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_frame <> Me.txtElecFrame.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_cat_no <> Me.txtElecCatNo.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_hp <> Me.txtElecHp.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_rpm <> Me.txtElecRpm.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_v <> Me.txtElecV.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_amp <> Me.txtElecAmp.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_hz <> Me.txtElecHz.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_phs <> Me.txtElecPhs.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_sf <> Me.txtElecSf.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_duty <> Me.txtElecDuty.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_insl_cl <> Me.txtElecInslCl.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_design <> Me.txtElecDesign.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_shaft_end_brg <> Me.txtElecShaftEndBrg.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_opp_end_brg <> Me.txtElecOppEndBrg.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_misc_nameplate_data <> Me.txtElecMiscNpData.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If rsEquipRetrieve!elec_recommended_spare_parts <> Me.txtElecRecomSpareParts.Text Then
        intChangedCount = intChangedCount + 1
    End If
    If intChangedCount > 0 Then
        ans = MsgBox("Do you want to save the changed data?", vbYesNo, "WOS")
        If ans = 6 Then
            Save
        End If
    End If
'Exit Sub
'errorhandler:
'MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - ChangedData: Description - " & Err.Description
End Sub

Private Sub FillFields()

'
' Fills all the fields for the current recordset
'

    Dim intCount As Integer
    
On Error GoTo errorhandler

    If rsEquipRetrieve.EOF = True Or rsEquipRetrieve.BOF = True Then
        intCount = rsEquipRetrieve.RecordCount
        If intCount = 0 Then
            MsgBox "There are no more equipment for this plant in the database"
            Unload Me
            frmPlant.CheckAll "equip"
        End If
    Else
        Me.lblPlantName.Caption = intPlantPass & " - " & strPlantPass
        Me.lblPlantNameG.Caption = intPlantPass & " - " & strPlantPass
        'If IsNull(rsEquipRetrieve!plant_id) Then
        '    Me.lblPlantName.Caption = ""
        '    Me.lblPlantNameG.Caption = ""
        'Else
        '    Me.lblPlantName.Caption = rsEquipRetrieve!plant_id & " - " & rsEquipRetrieve!plant_name
        '    Me.lblPlantNameG.Caption = rsEquipRetrieve!plant_id & " - " & rsEquipRetrieve!plant_name
        'End If
        If IsNull(rsEquipRetrieve!equip_key) Then
            Me.txtEquipKey.Text = ""
        Else
            Me.txtEquipKey.Text = rsEquipRetrieve!equip_key
        End If
        If IsNull(rsEquipRetrieve!equip_desc) Then
            Me.txtEquipDesc.Text = ""
        Else
            Me.txtEquipDesc.Text = rsEquipRetrieve!equip_desc
        End If
        If IsNull(rsEquipRetrieve!last_meter_reading) Then
            Me.txtMeterReading.Text = ""
        Else
            Me.txtMeterReading.Text = rsEquipRetrieve!last_meter_reading
        End If
        If IsNull(rsEquipRetrieve!last_meter_reading_date) Then
            Me.txtMeterReadingDate.Text = ""
        Else
            Me.txtMeterReadingDate.Text = rsEquipRetrieve!last_meter_reading_date
        End If
        If IsNull(rsEquipRetrieve!mech_serial) Then
            Me.txtMechSerial.Text = ""
        Else
            Me.txtMechSerial.Text = rsEquipRetrieve!mech_serial
        End If
        If IsNull(rsEquipRetrieve!mech_id) Then
            Me.txtMechID.Text = ""
        Else
            Me.txtMechID.Text = rsEquipRetrieve!mech_id
        End If
        If IsNull(rsEquipRetrieve!mech_model) Then
            Me.txtMechModel.Text = ""
        Else
            Me.txtMechModel.Text = rsEquipRetrieve!mech_model
        End If
        If IsNull(rsEquipRetrieve!mech_frame) Then
            Me.txtMechFrame.Text = ""
        Else
            Me.txtMechFrame.Text = rsEquipRetrieve!mech_frame
        End If
        If IsNull(rsEquipRetrieve!mech_imp_sz) Then
            Me.txtMechImpSz.Text = ""
        Else
            Me.txtMechImpSz.Text = rsEquipRetrieve!mech_imp_sz
        End If
        If IsNull(rsEquipRetrieve!mech_hp) Then
            Me.txtMechHp.Text = ""
        Else
            Me.txtMechHp.Text = rsEquipRetrieve!mech_hp
        End If
        If IsNull(rsEquipRetrieve!mech_rpm) Then
            Me.txtMechRpm.Text = ""
        Else
            Me.txtMechRpm.Text = rsEquipRetrieve!mech_rpm
        End If
        If IsNull(rsEquipRetrieve!mech_cap) Then
            Me.txtMechCap.Text = ""
        Else
            Me.txtMechCap.Text = rsEquipRetrieve!mech_cap
        End If
        If IsNull(rsEquipRetrieve!mech_size) Then
            Me.txtMechSize.Text = ""
        Else
            Me.txtMechSize.Text = rsEquipRetrieve!mech_size
        End If
        If IsNull(rsEquipRetrieve!mech_tdh) Then
            Me.txtMechTdh.Text = ""
        Else
            Me.txtMechTdh.Text = rsEquipRetrieve!mech_tdh
        End If
        If IsNull(rsEquipRetrieve!mech_cat_no) Then
            Me.txtMechCatNo.Text = ""
        Else
            Me.txtMechCatNo.Text = rsEquipRetrieve!mech_cat_no
        End If
        If IsNull(rsEquipRetrieve!mech_max_rpm) Then
            Me.txtMechMaxRpm.Text = ""
        Else
            Me.txtMechMaxRpm.Text = rsEquipRetrieve!mech_max_rpm
        End If
        If IsNull(rsEquipRetrieve!mech_min_rpm) Then
            Me.txtMechMinRpm.Text = ""
        Else
            Me.txtMechMinRpm.Text = rsEquipRetrieve!mech_min_rpm
        End If
        If IsNull(rsEquipRetrieve!mech_cfm) Then
            Me.txtMechCfm.Text = ""
        Else
            Me.txtMechCfm.Text = rsEquipRetrieve!mech_cfm
        End If
        If IsNull(rsEquipRetrieve!mech_oil) Then
            Me.txtMechOil.Text = ""
        Else
            Me.txtMechOil.Text = rsEquipRetrieve!mech_oil
        End If
        If IsNull(rsEquipRetrieve!mech_oil_filter) Then
            Me.txtMechOilFilter.Text = ""
        Else
            Me.txtMechOilFilter.Text = rsEquipRetrieve!mech_oil_filter
        End If
        If IsNull(rsEquipRetrieve!mech_air_filter) Then
            Me.txtMechAirFilter.Text = ""
        Else
            Me.txtMechAirFilter.Text = rsEquipRetrieve!mech_air_filter
        End If
        If IsNull(rsEquipRetrieve!mech_belt1) Then
            Me.txtMechBelt1.Text = ""
        Else
            Me.txtMechBelt1.Text = rsEquipRetrieve!mech_belt1
        End If
        If IsNull(rsEquipRetrieve!mech_belt2) Then
            Me.txtMechBelt2.Text = ""
        Else
            Me.txtMechBelt2.Text = rsEquipRetrieve!mech_belt2
        End If
        If IsNull(rsEquipRetrieve!mech_pipe_size) Then
            Me.txtMechPipeSize.Text = ""
        Else
            Me.txtMechPipeSize.Text = rsEquipRetrieve!mech_pipe_size
        End If
        If IsNull(rsEquipRetrieve!mech_pipe_type) Then
            Me.txtMechPipeType.Text = ""
        Else
            Me.txtMechPipeType.Text = rsEquipRetrieve!mech_pipe_type
        End If
        If IsNull(rsEquipRetrieve!mech_no_valves_types) Then
            Me.txtMechNoOfValvesTypes.Text = ""
        Else
            Me.txtMechNoOfValvesTypes.Text = rsEquipRetrieve!mech_no_valves_types
        End If
        If IsNull(rsEquipRetrieve!mech_misc_nameplate_data) Then
            Me.txtMechMiscNPData.Text = ""
        Else
            Me.txtMechMiscNPData.Text = rsEquipRetrieve!mech_misc_nameplate_data
        End If
        If IsNull(rsEquipRetrieve!mech_recommended_spare_parts) Then
            Me.txtMechRecomSpareParts.Text = ""
        Else
            Me.txtMechRecomSpareParts.Text = rsEquipRetrieve!mech_recommended_spare_parts
        End If
        If IsNull(rsEquipRetrieve!elec_serial) Then
            Me.txtElecSerial.Text = ""
        Else
            Me.txtElecSerial.Text = rsEquipRetrieve!elec_serial
        End If
        If IsNull(rsEquipRetrieve!elec_id) Then
            Me.txtElecID.Text = ""
        Else
            Me.txtElecID.Text = rsEquipRetrieve!elec_id
        End If
        If IsNull(rsEquipRetrieve!elec_model) Then
            Me.txtElecModel.Text = ""
        Else
            Me.txtElecModel.Text = rsEquipRetrieve!elec_model
        End If
        If IsNull(rsEquipRetrieve!elec_frame) Then
            Me.txtElecFrame.Text = ""
        Else
            Me.txtElecFrame.Text = rsEquipRetrieve!elec_frame
        End If
        If IsNull(rsEquipRetrieve!elec_cat_no) Then
            Me.txtElecCatNo.Text = ""
        Else
            Me.txtElecCatNo.Text = rsEquipRetrieve!elec_cat_no
        End If
        If IsNull(rsEquipRetrieve!elec_hp) Then
            Me.txtElecHp.Text = ""
        Else
            Me.txtElecHp.Text = rsEquipRetrieve!elec_hp
        End If
        If IsNull(rsEquipRetrieve!elec_rpm) Then
            Me.txtElecRpm.Text = ""
        Else
            Me.txtElecRpm.Text = rsEquipRetrieve!elec_rpm
        End If
        If IsNull(rsEquipRetrieve!elec_v) Then
            Me.txtElecV.Text = ""
        Else
            Me.txtElecV.Text = rsEquipRetrieve!elec_v
        End If
        If IsNull(rsEquipRetrieve!elec_amp) Then
            Me.txtElecAmp.Text = ""
        Else
            Me.txtElecAmp.Text = rsEquipRetrieve!elec_amp
        End If
        If IsNull(rsEquipRetrieve!elec_hz) Then
            Me.txtElecHz.Text = ""
        Else
            Me.txtElecHz.Text = rsEquipRetrieve!elec_hz
        End If
        If IsNull(rsEquipRetrieve!elec_phs) Then
            Me.txtElecPhs.Text = ""
        Else
            Me.txtElecPhs.Text = rsEquipRetrieve!elec_phs
        End If
        If IsNull(rsEquipRetrieve!elec_sf) Then
            Me.txtElecSf.Text = ""
        Else
            Me.txtElecSf.Text = rsEquipRetrieve!elec_sf
        End If
        If IsNull(rsEquipRetrieve!elec_duty) Then
            Me.txtElecDuty.Text = ""
        Else
            Me.txtElecDuty.Text = rsEquipRetrieve!elec_duty
        End If
        If IsNull(rsEquipRetrieve!elec_insl_cl) Then
            Me.txtElecInslCl.Text = ""
        Else
            Me.txtElecInslCl.Text = rsEquipRetrieve!elec_insl_cl
        End If
        If IsNull(rsEquipRetrieve!elec_design) Then
            Me.txtElecDesign.Text = ""
        Else
            Me.txtElecDesign.Text = rsEquipRetrieve!elec_design
        End If
        If IsNull(rsEquipRetrieve!elec_shaft_end_brg) Then
            Me.txtElecShaftEndBrg.Text = ""
        Else
            Me.txtElecShaftEndBrg.Text = rsEquipRetrieve!elec_shaft_end_brg
        End If
        If IsNull(rsEquipRetrieve!elec_opp_end_brg) Then
            Me.txtElecOppEndBrg.Text = ""
        Else
            Me.txtElecOppEndBrg.Text = rsEquipRetrieve!elec_opp_end_brg
        End If
        If IsNull(rsEquipRetrieve!elec_misc_nameplate_data) Then
            Me.txtElecMiscNpData.Text = ""
        Else
            Me.txtElecMiscNpData.Text = rsEquipRetrieve!elec_misc_nameplate_data
        End If
        If IsNull(rsEquipRetrieve!elec_recommended_spare_parts) Then
            Me.txtElecRecomSpareParts.Text = ""
        Else
            Me.txtElecRecomSpareParts.Text = rsEquipRetrieve!elec_recommended_spare_parts
        End If
        KeepCount
    End If

Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - FillFields: Description - " & Err.Description
End Sub

Private Sub Form_Unload(Cancel As Integer)

'
' Sets the recordset to nothing and sets other form level variables to zero or
' empty string
'

On Error GoTo errorhandler

    Set rsEquipRetrieve = Nothing
    intTypeEquip = 0
    MDIFormWOS.FindActive (True)
    'Set cnWos = Nothing
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - Form_Unload: Description - " & Err.Description
End Sub



Private Sub txtElecAmp_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
    
On Error GoTo errorhandler

    intLen = Len(txtElecAmp.Text)
    If intLen > 12 Then
        Beep
        ans = MsgBox("The APM field can not have more than 12 characters.", vbOKOnly, "WOS")
        txtElecAmp.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecAmp Validate: Description - " & Err.Description
End Sub

Private Sub txtElecCatNo_Validate(Cancel As Boolean)

'
'
'


    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtElecCatNo.Text)
    If intLen > 10 Then
        Beep
        ans = MsgBox("The CAT NO field can not have more than 10 characters.", vbOKOnly, "WOS")
        txtElecCatNo.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecCatNo Validate: Description - " & Err.Description
End Sub

Private Sub txtElecDesign_Validate(Cancel As Boolean)

'
'
'


    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtElecDesign.Text)
    If intLen > 3 Then
        Beep
        ans = MsgBox("The DESIGN field can not have more than 3 characters.", vbOKOnly, "WOS")
        txtElecDesign.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecDesign Validate: Description - " & Err.Description
End Sub

Private Sub txtElecDuty_Validate(Cancel As Boolean)

'
'
'


    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtElecDuty.Text)
    If intLen > 5 Then
        Beep
        ans = MsgBox("The DUTY field can not have more than 5 characters.", vbOKOnly, "WOS")
        txtElecDuty.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecDuty Validate: Description - " & Err.Description
End Sub

Private Sub txtElecFrame_Validate(Cancel As Boolean)

'
'
'


    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtElecFrame.Text)
    If intLen > 7 Then
        Beep
        ans = MsgBox("The FRAME field can not have more than 7 characters.", vbOKOnly, "WOS")
        txtElecFrame.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecFrame Validate: Description - " & Err.Description
End Sub

Private Sub txtElecHp_Validate(Cancel As Boolean)

'
'
'


    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtElecHp.Text)
    If intLen > 5 Then
        Beep
        ans = MsgBox("The HP field can not have more than 5 characters.", vbOKOnly, "WOS")
        txtElecHp.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecHp Validate: Description - " & Err.Description
End Sub

Private Sub txtElecHz_Validate(Cancel As Boolean)

'
'
'


    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtElecHz.Text)
    If intLen > 3 Then
        Beep
        ans = MsgBox("The HZ field can not have more than 3 characters.", vbOKOnly, "WOS")
        txtElecHz.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecHz Validate: Description - " & Err.Description
End Sub

Private Sub txtElecID_Validate(Cancel As Boolean)

'
'
'


    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtElecID.Text)
    If intLen > 13 Then
        Beep
        ans = MsgBox("The ID field can not have more than 13 characters.", vbOKOnly, "WOS")
        txtElecID.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecID Validate: Description - " & Err.Description
End Sub

Private Sub txtElecInslCl_Validate(Cancel As Boolean)

'
'
'


    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtElecInslCl.Text)
    If intLen > 3 Then
        Beep
        ans = MsgBox("The INSL CL field can not have more than 3 characters.", vbOKOnly, "WOS")
        txtElecInslCl.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecInslCl Validate: Description - " & Err.Description
End Sub

Private Sub txtElecMiscNpData_Validate(Cancel As Boolean)

'
'
'


    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtElecMiscNpData.Text)
    If intLen > 65 Then
        Beep
        ans = MsgBox("The MISC NAMEPLATE DATA field can not have more than 65 characters.", vbOKOnly, "WOS")
        txtElecMiscNpData.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecMiscNPData Validate: Description - " & Err.Description
End Sub

Private Sub txtElecModel_Validate(Cancel As Boolean)

'
'
'


    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtElecModel.Text)
    If intLen > 15 Then
        Beep
        ans = MsgBox("The MODEL field can not have more than 15 characters.", vbOKOnly, "WOS")
        txtElecModel.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecModel Validate: Description - " & Err.Description
End Sub

Private Sub txtElecOppEndBrg_Validate(Cancel As Boolean)

'
'
'


    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtElecOppEndBrg.Text)
    If intLen > 13 Then
        Beep
        ans = MsgBox("The OPP END BRG field can not have more than 13 characters.", vbOKOnly, "WOS")
        txtElecOppEndBrg.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecOppEndBrg Validate: Description - " & Err.Description
End Sub

Private Sub txtElecPhs_Validate(Cancel As Boolean)

'
'
'


    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtElecPhs.Text)
    If intLen > 2 Then
        Beep
        ans = MsgBox("The PHS field can not have more than 2 characters.", vbOKOnly, "WOS")
        txtElecPhs.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecPhs Validate: Description - " & Err.Description
End Sub

Private Sub txtElecRecomSpareParts_Validate(Cancel As Boolean)

'
'
'
        
    Dim intLen As Integer
    Dim ans As Integer
    
On Error GoTo errorhandler

    intLen = Len(txtElecRecomSpareParts.Text)
    If intLen > 30 Then
        Beep
        ans = MsgBox("The RECOMMENDED SPARE PARTS field can not have more than 30 characters.", vbOKOnly, "WOS")
        txtElecRecomSpareParts.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecRecomSpareParts Validate: Description - " & Err.Description
End Sub

Private Sub txtElecRpm_Validate(Cancel As Boolean)

'
'
'
    
    
    Dim intLen As Integer
    Dim ans As Integer
    
On Error GoTo errorhandler
    
    intLen = Len(txtElecRpm.Text)
    If intLen > 6 Then
        Beep
        ans = MsgBox("The RPM field can not have more than 6 characters.", vbOKOnly, "WOS")
        txtElecRpm.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecRpm Validate: Description - " & Err.Description
End Sub

Private Sub txtElecSerial_Validate(Cancel As Boolean)

'
'
'


    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtElecSerial.Text)
    If intLen > 13 Then
        Beep
        ans = MsgBox("The SERIAL field can not have more than 13 characters.", vbOKOnly, "WOS")
        txtElecSerial.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecSerial Validate: Description - " & Err.Description
End Sub

Private Sub txtElecSf_Validate(Cancel As Boolean)

'
'
'


    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler
    
    intLen = Len(txtElecSf.Text)
    If intLen > 4 Then
        Beep
        ans = MsgBox("The SF field can not have more than 4 characters.", vbOKOnly, "WOS")
        txtElecSf.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecSf Validate: Description - " & Err.Description
End Sub

Private Sub txtElecShaftEndBrg_Validate(Cancel As Boolean)

'
'
'
    
    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtElecShaftEndBrg.Text)
    If intLen > 13 Then
        Beep
        ans = MsgBox("The SHAFT END BRG field can not have more than 13 characters.", vbOKOnly, "WOS")
        txtElecShaftEndBrg.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecShaftEndBrg Validate: Description - " & Err.Description
End Sub

Private Sub txtElecV_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtElecV.Text)
    If intLen > 12 Then
        Beep
        ans = MsgBox("The V field can not have more than 12 characters.", vbOKOnly, "WOS")
        txtElecV.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtElecV Validate: Description - " & Err.Description
End Sub

Private Sub txtEquipDesc_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtEquipDesc.Text)
    If intLen > 100 Then
        Beep
        ans = MsgBox("The EQUIPMENT DESCRIPTION field can not have more than 100 characters.", vbOKOnly, "WOS")
        txtEquipKey.Text = ""
        Cancel = True
    Else
        If intLen = 0 Then
            Beep
            ans = MsgBox("The EQUIPMENT DESCRIPTION field is a required field.", vbOKOnly, "WOS")
            Cancel = True
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtEquipDesc Validate: Description - " & Err.Description
End Sub


Private Sub txtEquipKey_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtEquipKey.Text)
    If intLen > 10 Then
        Beep
        ans = MsgBox("The EQUIPMENT KEY field can not have more than 10 characters.", vbOKOnly, "WOS")
        txtEquipKey.Text = ""
        Cancel = True
    Else
        If intLen = 0 Then
            Beep
            ans = MsgBox("The EQUIPMENT KEY field is a required field.", vbOKOnly, "WOS")
            Cancel = True
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtEquipKey Validate: Description - " & Err.Description
End Sub

Private Sub txtMechAirFilter_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechAirFilter.Text)
    
    If intLen > 20 Then
        Beep
        ans = MsgBox("The AIR FILTER field can not have more than 20 characters.", vbOKOnly, "WOS")
        txtMechAirFilter.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechAirFilter Validate: Description - " & Err.Description
End Sub

Private Sub txtMechBelt1_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechBelt1.Text)
    
    If intLen > 20 Then
        Beep
        ans = MsgBox("The BELT1 field can not have more than 20 characters.", vbOKOnly, "WOS")
        txtMechBelt1.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMeechBelt1 Validate: Description - " & Err.Description
End Sub

Private Sub txtMechBelt2_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechBelt2.Text)
    
    If intLen > 20 Then
        Beep
        ans = MsgBox("The BELT2 field can not have more than 20 characters.", vbOKOnly, "WOS")
        txtMechBelt2.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechBelt2 Validate: Description - " & Err.Description
End Sub

Private Sub txtMechCap_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechCap.Text)
    
    If intLen > 6 Then
        Beep
        ans = MsgBox("The CAP field can not have more than 6 characters.", vbOKOnly, "WOS")
        txtMechCap.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechCap Validate: Description - " & Err.Description
End Sub

Private Sub txtMechCatNo_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechCatNo.Text)
    
    If intLen > 13 Then
        Beep
        ans = MsgBox("The CAT NO field can not have more than 13 characters.", vbOKOnly, "WOS")
        txtMechCatNo.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechCatNo Validate: Description - " & Err.Description
End Sub

Private Sub txtMechCfm_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechCfm.Text)
    
    If intLen > 5 Then
        Beep
        ans = MsgBox("The CFM field can not have more than 5 characters.", vbOKOnly, "WOS")
        txtMechCfm.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechCfm Validate: Description - " & Err.Description
End Sub

Private Sub txtMechFrame_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechFrame.Text)
    
    If intLen > 7 Then
        Beep
        ans = MsgBox("The FRAME field can not have more than 7 characters.", vbOKOnly, "WOS")
        txtMechFrame.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechFrame Validate: Description - " & Err.Description
End Sub

Private Sub txtMechHp_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechHp.Text)
    
    If intLen > 5 Then
        Beep
        ans = MsgBox("The HP field can not have more than 5 characters.", vbOKOnly, "WOS")
        txtMechHp.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechHp Validate: Description - " & Err.Description
End Sub

Private Sub txtMechID_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechID.Text)
    
    If intLen > 13 Then
        Beep
        ans = MsgBox("The ID field can not have more than 13 characters.", vbOKOnly, "WOS")
        txtMechID.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechID Validate: Description - " & Err.Description
End Sub

Private Sub txtMechImpSz_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechImpSz.Text)
    
    If intLen > 6 Then
        Beep
        ans = MsgBox("The IMP SZ field can not have more than 6 characters.", vbOKOnly, "WOS")
        txtMechImpSz.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechImpSz Validate: Description - " & Err.Description
End Sub

Private Sub txtMechMaxRpm_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechMaxRpm.Text)
    
    If intLen > 5 Then
        Beep
        ans = MsgBox("The MAX RPM field can not have more than 5 characters.", vbOKOnly, "WOS")
        txtMechMaxRpm.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechMaxRpm Validate: Description - " & Err.Description
End Sub

Private Sub txtMechMinRpm_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechMinRpm.Text)
    
    If intLen > 5 Then
        Beep
        ans = MsgBox("The MIN RPM field can not have more than 5 characters.", vbOKOnly, "WOS")
        txtMechMinRpm.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechMinRpm Validate: Description - " & Err.Description
End Sub

Private Sub txtMechMiscNPData_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechMiscNPData.Text)
    
    If intLen > 65 Then
        Beep
        ans = MsgBox("The MISC NAMEPLATE DATA field can not have more than 65 characters.", vbOKOnly, "WOS")
        txtMechMiscNPData.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechMiscNPData Validate: Description - " & Err.Description
End Sub

Private Sub txtMechModel_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechModel.Text)
    
    If intLen > 15 Then
        Beep
        ans = MsgBox("The MODEL field can not have more than 15 characters.", vbOKOnly, "WOS")
        txtMechModel.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechModel Validate: Description - " & Err.Description
End Sub

Private Sub txtMechNoOfValvesTypes_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechNoOfValvesTypes.Text)
    
    If intLen > 30 Then
        Beep
        ans = MsgBox("The NO OF VALVES & TYPES field can not have more than 30 characters.", vbOKOnly, "WOS")
        txtMechNoOfValvesTypes.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechNoOfValvesTypes Validate: Description - " & Err.Description
End Sub

Private Sub txtMechOil_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechOil.Text)
    
    If intLen > 20 Then
        Beep
        ans = MsgBox("The OIL field can not have more than 20 characters.", vbOKOnly, "WOS")
        txtMechOil.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechOil Validate: Description - " & Err.Description
End Sub

Private Sub txtMechOilFilter_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechOilFilter.Text)
    
    If intLen > 20 Then
        Beep
        ans = MsgBox("The OIL FILTER field can not have more than 20 characters.", vbOKOnly, "WOS")
        txtMechOilFilter.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechOilFilter Validate: Description - " & Err.Description
End Sub

Private Sub txtMechPipeSize_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechPipeSize.Text)
    
    If intLen > 30 Then
        Beep
        ans = MsgBox("The PIPE SIZE field can not have more than 30 characters.", vbOKOnly, "WOS")
        txtMechPipeSize.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechPipeSize Validate: Description - " & Err.Description
End Sub

Private Sub txtMechPipeType_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechPipeType.Text)
    
    If intLen > 20 Then
        Beep
        ans = MsgBox("The PIPE TYPE field can not have more than 20 characters.", vbOKOnly, "WOS")
        txtMechPipeType.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechPipeType Validate: Description - " & Err.Description
End Sub

Private Sub txtMechRecomSpareParts_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechRecomSpareParts.Text)
    
    If intLen > 30 Then
        Beep
        ans = MsgBox("The RECOMMENDED SPARE PARTS field can not have more than 30 characters.", vbOKOnly, "WOS")
        txtMechRecomSpareParts.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechRecomSpareParts Validate: Description - " & Err.Description
End Sub

Private Sub txtMechRpm_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechRpm.Text)
    
    If intLen > 6 Then
        Beep
        ans = MsgBox("The RPM field can not have more than 6 characters.", vbOKOnly, "WOS")
        txtMechRpm.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechRpm Validate: Description - " & Err.Description
End Sub

Private Sub txtMechSerial_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechSerial.Text)
    
    If intLen > 13 Then
        Beep
        ans = MsgBox("The SERIAL field can not have more than 13 characters.", vbOKOnly, "WOS")
        txtMechSerial.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechSerial Validate: Description - " & Err.Description
End Sub

Private Sub txtMechSize_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechSize.Text)
    
    If intLen > 8 Then
        Beep
        ans = MsgBox("The SIZE field can not have more than 8 characters.", vbOKOnly, "WOS")
        txtMechSize.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechSize Validate: Description - " & Err.Description
End Sub

Private Sub txtMechTdh_Validate(Cancel As Boolean)

'
'
'

    Dim intLen As Integer
    Dim ans As Integer
On Error GoTo errorhandler

    intLen = Len(txtMechTdh.Text)
    
    If intLen > 5 Then
        Beep
        ans = MsgBox("The TDH field can not have more than 5 characters.", vbOKOnly, "WOS")
        txtMechTdh.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMechTdh Validate: Description - " & Err.Description
End Sub

Private Sub txtMeterReading_GotFocus()

'
'
'

On Error GoTo errorhandler

    If txtMeterReading.Text <> "" Then
        lngMeterReading = 0
        lngMeterReading = CLng(txtMeterReading.Text)
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMeterReading GotFocus: Description - " & Err.Description
End Sub

Private Sub txtMeterReading_Validate(Cancel As Boolean)

'
'
'
    Dim lngNewMeter As Long
On Error GoTo errorhandler

    ans = 0
    lngNewMeter = 0
    If IsNumeric(txtMeterReading.Text) = False And txtMeterReading <> "" Then
        MsgBox "Incorrect Format. Please Re-enter."
        txtMeterReading.Text = ""
        Cancel = True
    Else
        If lngMeterReading > 0 Then
            If txtMeterReading.Text = "" Then
                lngNewMeter = 0
            Else
                lngNewMeter = CLng(txtMeterReading.Text)
            End If
            If lngNewMeter < lngMeterReading Then
                ans = MsgBox("It is not recommended to have new meter reading to be smaller than the old one. ", vbOKOnly)
                'If ans = 6 Then
                '    If IsNull(lngNewMeter) Then
                '        txtMeterReading.Text = ""
                '    Else
                '        txtMeterReading.Text = lngNewMeter
                '    End If
                'Else
                '    If IsNull(lngMeterReading) Then
                '        txtMeterReading.Text = ""
                '    Else
                '        txtMeterReading.Text = lngMeterReading
                '    End If
                'End If
            End If
        End If
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMeterReading Validate: Description - " & Err.Description
End Sub

Private Sub TxtMeterReadingDate_Validate(Cancel As Boolean)

'
'
'

On Error GoTo errorhandler

    If IsDate(txtMeterReadingDate.Text) = False And txtMeterReadingDate <> "" Then
        MsgBox "Incorrect Format. Please Re-enter."
        txtMeterReadingDate.Text = ""
        Cancel = True
    End If
Exit Sub
errorhandler:
MsgBox "Error Number - " & Err.Number & ": WOS: Equipment - txtMeterReadingDate Validate: Description - " & Err.Description
End Sub
