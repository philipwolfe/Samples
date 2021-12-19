VERSION 5.00
Begin {AC0714F6-3D04-11D1-AE7D-00A0C90F26F4} Connect 
   ClientHeight    =   9600
   ClientLeft      =   1740
   ClientTop       =   1545
   ClientWidth     =   6720
   _ExtentX        =   11853
   _ExtentY        =   16933
   _Version        =   393216
   Description     =   "View information about Visual Studio commands."
   DisplayName     =   "Command Browser"
   AppName         =   "Microsoft Development Environment"
   AppVer          =   "Microsoft Development Environment 7.0 (Administrative)"
   LoadName        =   "Command Line / Startup"
   LoadBehavior    =   5
   RegLocation     =   "HKEY_LOCAL_MACHINE\Software\Microsoft\VisualStudio\6.0"
   CmdLineSupport  =   -1  'True
End
Attribute VB_Name = "Connect"
Attribute VB_GlobalNameSpace = False
Attribute VB_Creatable = True
Attribute VB_PredeclaredId = False
Attribute VB_Exposed = True
Option Explicit

Public FormDisplayed          As Boolean
Public VSInstance             As EnvDTE.DTE
Dim mcbMenuCommandBar         As Office.CommandBarControl
Dim gwinWindow                As EnvDTE.Window
Dim DismDisplay               As Object
Public WithEvents MenuHandler As CommandBarEvents          'command bar event handler
Attribute MenuHandler.VB_VarHelpID = -1

'------------------------------------------------------
'this method adds the Add-In to VS
'------------------------------------------------------
Private Sub AddinInstance_OnConnection(ByVal Application As Object, ByVal ConnectMode As AddInDesignerObjects.ext_ConnectMode, ByVal AddInInst As Object, custom() As Variant)
    On Error GoTo error_handler
    Const guidMYTOOL$ = "{10676990-4286-11d1-8EB7-000000000000}"
    Const DocObjectProgID$ = "CmdBrowser.Document"
    Const WindowTitle$ = "Command Browser"
    
    'save the vb instance
    Set VSInstance = Application
    
    'this is a good place to set a breakpoint and
    'test various addin objects, properties and methods
    Debug.Print VSInstance.FileName

    If ConnectMode <> ext_cm_External Then
        Set mcbMenuCommandBar = AddToAddInCommandBar("Command Browser")
        'sink the event
        Set Me.MenuHandler = VSInstance.Events.CommandBarEvents(mcbMenuCommandBar)
    End If
    
    If ConnectMode = AddInDesignerObjects.ext_cm_External Then
        Dim aiTmp As EnvDTE.AddIn
        Set aiTmp = VSInstance.AddIns("CmdBrowser.Connect")
        If aiTmp Is Nothing Then
            Set gwinWindow = VSInstance.Windows.CreateToolWindow(VSInstance.AddIns(1), DocObjectProgID$, WindowTitle$, guidMYTOOL$, DismDisplay)
            gwinWindow.Visible = True
        Else
            If aiTmp.Connect = False Then
                Set gwinWindow = VSInstance.Windows.CreateToolWindow(aiTmp, DocObjectProgID$, WindowTitle$, guidMYTOOL$, DismDisplay)
                gwinWindow.Visible = True
            End If
        End If
    Else
        Set gwinWindow = VSInstance.Windows.CreateToolWindow(AddInInst, DocObjectProgID$, WindowTitle$, guidMYTOOL$, DismDisplay)
        gwinWindow.Visible = True
    End If
  
    Set DismDisplay.VSInstance = VSInstance
    'DismDisplay.Populate
    Exit Sub
    
error_handler:
    
    MsgBox Err.Description
    
End Sub

'------------------------------------------------------
'this method removes the Add-In from VS
'------------------------------------------------------
Private Sub AddinInstance_OnDisconnection(ByVal RemoveMode As AddInDesignerObjects.ext_DisconnectMode, custom() As Variant)
    On Error Resume Next
    
    'delete the command bar entry
    mcbMenuCommandBar.Delete
    
    'shut down the Add-In
    If FormDisplayed Then
        SaveSetting App.Title, "Settings", "DisplayOnConnect", "1"
        FormDisplayed = False
    Else
        SaveSetting App.Title, "Settings", "DisplayOnConnect", "0"
    End If

End Sub

Private Sub IDTExtensibility_OnStartupComplete(custom() As Variant)
End Sub

'this event fires when the menu is clicked in the IDE
Private Sub MenuHandler_Click(ByVal CommandBarControl As Object, handled As Boolean, CancelDefault As Boolean)
    gwinWindow.Visible = True
End Sub

Function AddToAddInCommandBar(sCaption As String) As Office.CommandBarControl
    Dim cbMenuCommandBar As Office.CommandBarControl  'command bar object
    Dim cbMenu As Object
  
    On Error GoTo AddToAddInCommandBarErr
    
    'see if we can find the Add-Ins menu
    Set cbMenu = VSInstance.CommandBars("Tools")
    If cbMenu Is Nothing Then
        'not available so we fail
        Exit Function
    End If
    
    'add it to the command bar
    Set cbMenuCommandBar = cbMenu.Controls.Add(1)
    'set the caption
    cbMenuCommandBar.Caption = sCaption
    
    Set AddToAddInCommandBar = cbMenuCommandBar
    
    Exit Function
    
AddToAddInCommandBarErr:

End Function

